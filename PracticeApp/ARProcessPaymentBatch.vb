Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports WIA
Imports PdfSharp.Pdf
Imports System.Threading
Imports iTextSharp.text.Image
Imports PdfSharp
Imports document = iTextSharp.text.Document
Imports System.Drawing
Imports System.ComponentModel
Imports iTextSharp
Imports System.Reflection
Public Class ARProcessPaymentBatch
    Inherits System.Windows.Forms.Form

    'Remote
    Dim isLoaded As Boolean = False
    Dim dir As New System.IO.DirectoryInfo("\\TFP-FS\CashReceipts\UploadedCashBatch\")
    Dim FilesToDelete As List(Of String)
    Dim bgPDF As BackgroundWorker
    Dim bgAppendPDF As BackgroundWorker
    Dim LoadingScreen As New Loading
    Dim ShipmentNumber As Integer = 0
    ''Remote WIA variables
    Dim remoteWIA As MOSRemoteWIA
    Dim bgwkRemoteWIA As BackgroundWorker
    Dim remoteScan As Boolean = False

    'Variables to use for the GL Posting
    Dim CountLineNumber, InvoiceLine, UpdateLines, counter, LastBatchNumber, NextBatchNumber, LastGLNumber, NextGLNumber, LastLineGLNumber, NextLineGLNumber As Integer
    Dim InvoiceStatus, GLCreditAccount, GLDebitAccount, BatchStatus, PartNumber, ItemClass, BatchDate, BankAccount, BatchDescription, CreditGLAccount, DebitGLAccount As String
    Dim InvoiceTotal, InvoicePaymentsApplied, NewInvoicePaymentsApplied, LineCost, ExtendedAmount, BatchAmount, UndistributedAmount, UpdateTotals As Double
    Dim frm As System.Windows.Forms.Form
    Dim TodaysDate As Date = Today.ToShortDateString()

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Dim lastBatch As String = ""

    'Form Operations

    Private Sub ARProcessPaymentBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" And GlobalARDivisionCode = "" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        ElseIf EmployeeCompanyCode = "ADM" And GlobalARDivisionCode <> "" Then
            cboDivisionID.Text = GlobalARDivisionCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
        End If

        If My.Computer.Name.StartsWith("TFP") And EmployeeLoginName <> "JBASSETTI" Then
            cmdRemoteScan.Visible = True
            cmdScan.Visible = False
        Else
            cmdRemoteScan.Visible = False
            cmdScan.Visible = True
        End If

        If My.Computer.Name.StartsWith("TFP") Then
            cmdRemoteScan.Visible = True
            cmdScan.Visible = False
            ReUploadBatchToolStripMenuItem.Enabled = False
            ScanToolStripMenuItem.Enabled = False
            ScanToolStripMenuItem1.Enabled = False
            UploadToolStripMenuItem.Enabled = False
            UploadToolStripMenuItem1.Enabled = False
            AppendBaToolStripMenuItem.Enabled = False
        Else
            cmdRemoteScan.Visible = False
            cmdScan.Visible = True
            ReUploadBatchToolStripMenuItem.Enabled = True
            ScanToolStripMenuItem.Enabled = True
            ScanToolStripMenuItem1.Enabled = True
            UploadToolStripMenuItem.Enabled = True
            UploadToolStripMenuItem1.Enabled = True
            AppendBaToolStripMenuItem.Enabled = True
        End If

        'Load defaults
        LoadBatchNumber()
        isLoaded = True

        If GlobalNewARBatchNumber > 0 Then
            cboBatchNumber.Text = GlobalNewARBatchNumber
            LoadTotals()
            LoadBatchInfo()
            ShowBatchLines()
        Else
            cboBatchNumber.SelectedIndex = -1
            ClearBatch()
            ShowBatchLines()
        End If

        CheckOpenBatches()
        cmdGenerateBatchNumber.Focus()
        cmdUpload.Enabled = False
        cmdScan.Enabled = False
        cmdViewReceipt.Enabled = False
        'If Not dir.Exists Then
        '    dir.Create()
        'End If

        bgPDF = New BackgroundWorker()
        AddHandler bgPDF.DoWork, AddressOf bgwk_Run
        AddHandler bgPDF.RunWorkerCompleted, AddressOf bgwk_Completed
        bgAppendPDF = New BackgroundWorker()
        AddHandler bgAppendPDF.DoWork, AddressOf bgwkAppendPDF_Run
        AddHandler bgAppendPDF.RunWorkerCompleted, AddressOf bgwk_Completed
        LoadingScreen.Text = "Generating PDF"
        LoadingScreen.Label1.Text = "Generating PDF please wait"
        LoadingScreen.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ARProcessPaymentBatch_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            unlockBatch()
        End If
    End Sub

    'Load Datasets into controls/datagrid

    Public Sub ShowBatchLines()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        'cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ARCustomerPayment")
        dgvARCustomerPayments.DataSource = ds.Tables("ARCustomerPayment")
        con.Close()
        Me.dgvARCustomerPayments.Columns("DivisionIDColumn").DefaultCellStyle.ForeColor = Color.Blue

        Try
            For Each row As DataGridViewRow In dgvARCustomerPayments.Rows

                Dim pdfname As String = row.Cells("PaymentIDColumn").Value.ToString
                Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname + ".pdf"
                If File.Exists(CashReceiptExists) Then
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                Else
                    row.DefaultCellStyle.BackColor = Color.LightCoral
                End If
            Next
        Catch ex As System.Exception
            'Error Log
        End Try
    End Sub

    Public Sub ClearBatchLines()
        dgvARCustomerPayments.DataSource = Nothing
    End Sub

    Public Sub LoadBatchNumber()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT BatchNumber FROM ARProcessPaymentBatch WHERE DivisionID = @DivisionID AND BatchStatus = @BatchStatus", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ARProcessPaymentBatch")
        cboBatchNumber.DataSource = ds1.Tables("ARProcessPaymentBatch")
        con.Close()
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadTransactionNumber()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT ARTransactionKey FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ARCustomerPayment")
        cboPaymentID.DataSource = ds3.Tables("ARCustomerPayment")
        con.Close()
        cboPaymentID.SelectedIndex = -1
    End Sub

    'Load data subroutines

    Public Sub LoadTotals()
        'UPDATE TOTALS AND DISTRIBUTABLE AMOUNT
        Dim UpdateTotalsStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE BatchNumber = @BatchNumber"
        Dim UpdateTotalsCommand As New SqlCommand(UpdateTotalsStatement, con)
        UpdateTotalsCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

        Dim UpdateLinesStatement As String = "SELECT COUNT(ARTransactionKey) FROM ARCustomerPayment WHERE BatchNumber = @BatchNumber"
        Dim UpdateLinesCommand As New SqlCommand(UpdateLinesStatement, con)
        UpdateLinesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UpdateTotals = CDbl(UpdateTotalsCommand.ExecuteScalar)
        Catch ex As Exception
            UpdateTotals = 0
        End Try
        Try
            UpdateLines = CInt(UpdateLinesCommand.ExecuteScalar)
        Catch ex As Exception
            UpdateLines = 0
        End Try
        con.Close()

        'UPDATE Distributable Totals
        BatchAmount = Val(txtBatchTotal.Text)
        UndistributedAmount = BatchAmount - UpdateTotals

        txtCurrentTotal.Text = FormatCurrency(UpdateTotals, 2)
        txtUndistributedAmount.Text = FormatCurrency(UndistributedAmount, 2)
        txtEntryNumber.Text = UpdateLines
    End Sub

    Public Sub CheckOpenBatches()
        Dim OpenBatches As Integer = 0
        Dim strOpenBatches As String = ""

        Dim OpenBatchesStatement As String = "SELECT COUNT(BatchNumber) FROM ARProcessPaymentBatch WHERE BatchStatus = @BatchStatus AND DivisionID = @DivisionID"
        Dim OpenBatchesCommand As New SqlCommand(OpenBatchesStatement, con)
        OpenBatchesCommand.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        OpenBatchesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OpenBatches = CInt(OpenBatchesCommand.ExecuteScalar)
        Catch ex As Exception
            OpenBatches = 0
        End Try
        con.Close()

        If OpenBatches = 1 Then
            lblOpenBatches.Visible = True
            lblOpenBatches.Text = "There is 1 Open Batch ready to be processed."
        ElseIf OpenBatches > 1 Then
            lblOpenBatches.Visible = True
            strOpenBatches = CStr(OpenBatches)
            lblOpenBatches.Text = "There are " + strOpenBatches + " Open Batches ready to be processed."
        Else
            lblOpenBatches.Visible = False
        End If
    End Sub

    Public Sub LoadBatchInfo()
        'Load the Batch Totals
        Dim BatchDateStatement As String = "SELECT BatchDate FROM ARProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchDateCommand As New SqlCommand(BatchDateStatement, con)
        BatchDateCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchAmountStatement As String = "SELECT BatchAmount FROM ARProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchAmountCommand As New SqlCommand(BatchAmountStatement, con)
        BatchAmountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchDescriptionStatement As String = "SELECT BatchDescription FROM ARProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchDescriptionCommand As New SqlCommand(BatchDescriptionStatement, con)
        BatchDescriptionCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ARProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchDate = CStr(BatchDateCommand.ExecuteScalar)
        Catch ex As Exception
            BatchDate = GlobalARBatchDate
        End Try
        Try
            BatchAmount = CDbl(BatchAmountCommand.ExecuteScalar)
        Catch ex As Exception
            BatchAmount = 0
        End Try
        Try
            BatchDescription = CStr(BatchDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            BatchDescription = "CASH RECEIPTS / CUSTOMER PAYMENTS"
        End Try
        Try
            BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            BatchStatus = "OPEN"
        End Try
        con.Close()

        dtpBatchCreationDate.Text = BatchDate
        txtBatchTotal.Text = BatchAmount
        txtBatchDescription.Text = BatchDescription
        txtBatchStatus.Text = BatchStatus

        If BatchDescription = "" Then
            BatchDescription = "CASH RECEIPTS / CUSTOMER PAYMENTS"
            txtBatchDescription.Text = BatchDescription
        End If

        If BatchStatus = "POSTED" Then
            cmdPostBatch.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            SaveBatchToolStripMenuItem.Enabled = False
            DeleteBatchToolStripMenuItem.Enabled = False
        Else
            cmdPostBatch.Enabled = True
            cmdSave.Enabled = True
            cmdDelete.Enabled = True
            SaveBatchToolStripMenuItem.Enabled = True
            DeleteBatchToolStripMenuItem.Enabled = True
        End If
    End Sub

    Public Sub LoadBatchStatus()
        Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ARProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            BatchStatus = "OPEN"
        End Try
        con.Close()

        txtBatchStatus.Text = BatchStatus
    End Sub

    'Validation and error checking

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length < 300 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 300)
        End If

        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Function isSomeoneEditing() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            Return False
        End If

        cmd = New SqlCommand("SELECT Locked FROM ARProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim personEditing As String = "NONE"

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.GetValue(0)) Then
                personEditing = reader.GetValue(0)
            End If
        End If
        reader.Close()
        con.Close()

        If Not personEditing.Equals("NONE") And Not String.IsNullOrEmpty(personEditing) Then
            If Not personEditing.Equals(EmployeeLoginName) Then
                MessageBox.Show(personEditing + " is currently editing this batch. You are unable to make any changes.", "Unable to save/Post", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub LockBatch()
        cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET Locked = @Locked WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET Locked = '' WHERE BatchNumber = @BatchNumber AND Locked = @Locked", con)

        If batch.Equals("none") Then
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        Else
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = batch
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Clear Routines

    Public Sub ClearVariables()
        CountLineNumber = 0
        InvoiceLine = 0
        UpdateLines = 0
        counter = 0
        LastBatchNumber = 0
        NextBatchNumber = 0
        LastGLNumber = 0
        NextGLNumber = 0
        LastLineGLNumber = 0
        NextLineGLNumber = 0
        BatchStatus = ""
        PartNumber = ""
        ItemClass = ""
        BatchDate = ""
        BankAccount = ""
        BatchDescription = ""
        CreditGLAccount = ""
        DebitGLAccount = ""
        LineCost = 0
        ExtendedAmount = 0
        BatchAmount = 0
        UndistributedAmount = 0
        UpdateTotals = 0
        GlobalARBatchNumber = 0
        GLCreditAccount = ""
        GLDebitAccount = ""
        lastBatch = ""

        cmdPostBatch.Enabled = True
        cmdSave.Enabled = True
        cmdDelete.Enabled = True
        SaveBatchToolStripMenuItem.Enabled = True
        DeleteBatchToolStripMenuItem.Enabled = True
    End Sub

    Public Sub ClearBatch()
        cboBatchNumber.Refresh()

        cboBatchNumber.Text = ""
        cboBatchNumber.SelectedIndex = -1
        cboPaymentID.SelectedIndex = -1

        dtpBatchCreationDate.Text = ""

        txtBatchTotal.Clear()
        txtCurrentTotal.Clear()
        txtUndistributedAmount.Clear()
        txtEntryNumber.Clear()
        txtBatchDescription.Clear()
        txtBatchStatus.Clear()

        cmdGenerateBatchNumber.Focus()

        cmdPostBatch.Enabled = True
        cmdSave.Enabled = True
        cmdDelete.Enabled = True
        SaveBatchToolStripMenuItem.Enabled = True
        DeleteBatchToolStripMenuItem.Enabled = True

        dgvARCustomerPayments.DataSource = Nothing

        CheckOpenBatches()
    End Sub

    'Command Buttons

    Private Sub cmdGenerateBatchNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateBatchNumber.Click
        If isLoaded Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch()
        End If

        'Clear Form to proceed
        GlobalARDivisionCode = ""
        GlobalARBatchNumber = 0

        ClearVariables()
        ClearBatch()
        ClearBatchLines()

        'Find the next Batch Number to use
        Dim MAXStatement As String = "SELECT MAX(BatchNumber) FROM ARProcessPaymentBatch"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 22000000
        End Try
        con.Close()

        NextBatchNumber = LastBatchNumber + 1
        cboBatchNumber.Text = NextBatchNumber

        Try
            'Write Data to Batch Header Database Table
            cmd = New SqlCommand("Insert Into ARProcessPaymentBatch(BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID)Values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID)", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempBatchNumber As Integer = 0
            Dim strBatchNumber As String
            TempBatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(TempBatchNumber)

            ErrorDate = TodaysDate
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "A/R Payment Batch --- Create New Batch"
            ErrorReferenceNumber = "Batch # " + strBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        cmdUpload.Enabled = True
        cmdScan.Enabled = True
        cmdViewReceipt.Enabled = False
    End Sub

    Private Sub cmdSelectInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectInvoices.Click
        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            LoadBatchStatus()

            If BatchStatus = "OPEN" Then
                ''check to see if this batch is being edited by someone else
                If isSomeoneEditing() Then
                    Exit Sub
                End If

                Try
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, DivisionID = @DivisionID, BatchStatus = @BatchStatus WHERE BatchNumber = @BatchNumber", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "A/R Payment Batch --- Update Batch (L534)"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                GlobalNewARBatchNumber = Val(cboBatchNumber.Text)
                GlobalARDivisionCode = cboDivisionID.Text
                GlobalARBatchDate = dtpBatchCreationDate.Text

                Dim NewARCashReceipts As New ARCashReceipts
                NewARCashReceipts.Show()

                isLoaded = False

                Me.Dispose()
                Me.Close()
            Else
                GlobalNewARBatchNumber = Val(cboBatchNumber.Text)
                GlobalARDivisionCode = cboDivisionID.Text
                GlobalARBatchDate = dtpBatchCreationDate.Text

                Dim NewARCashReceipts As New ARCashReceipts
                NewARCashReceipts.Show()

                isLoaded = False

                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cmdPostBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostBatch.Click
        Dim CheckPaymentStatus As Integer
        '*****************************************************************************
        'Validate Batch
        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*****************************************************************************
        ''check to see if this batch is being edited by someone else
        If isSomeoneEditing() Then
            Exit Sub
        End If
        '*****************************************************************************
        'Check Batch Status before posting
        LoadBatchStatus()

        If BatchStatus = "POSTED" Then
            MsgBox("This Batch is already posted.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*****************************************************************************
        'Check to see if any payments have already been posted
        Dim CheckPaymentStatusStatement As String = "SELECT COUNT(ARTransactionKey) FROM ARCustomerPayment WHERE BatchNumber = @BatchNumber AND Status = @Status"
        Dim CheckPaymentStatusCommand As New SqlCommand(CheckPaymentStatusStatement, con)
        CheckPaymentStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        CheckPaymentStatusCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckPaymentStatus = CInt(CheckPaymentStatusCommand.ExecuteScalar)
        Catch ex As Exception
            CheckPaymentStatus = 0
        End Try
        con.Close()

        If CheckPaymentStatus <> 0 Then
            MsgBox("This Batch is already posted.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '******************************************************************************************************
        If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
            'Skip Date Validation
        Else
            ''Validate Date
            'Dim CurrentDate, TodaysDate As Date
            'Dim MonthOfYear, YearOfYear, TodaysMonthOfYear, TodaysYearOfYear As Integer

            'TodaysDate = Today()
            'CurrentDate = dtpBatchCreationDate.Value

            'MonthOfYear = CurrentDate.Month
            'YearOfYear = CurrentDate.Year
            'TodaysMonthOfYear = TodaysDate.Month
            'TodaysYearOfYear = TodaysDate.Year

            'If TodaysYearOfYear - YearOfYear > 1 Then
            '    MsgBox("You cannot post a Batch to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear < 5 And (TodaysMonthOfYear >= 1 And TodaysMonthOfYear < 5) Then
            '    MsgBox("You cannot post a Batch to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear > 5 And (TodaysMonthOfYear >= 5 And TodaysMonthOfYear <= 12) Then
            '    MsgBox("You cannot post a Batch to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'ElseIf TodaysYearOfYear - YearOfYear = 0 And MonthOfYear < 5 And TodaysMonthOfYear >= 5 Then
            '    MsgBox("You cannot post a Batch to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'ElseIf TodaysYearOfYear - YearOfYear < 0 Then
            '    MsgBox("You cannot post a Batch to a future period.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'ElseIf TodaysYearOfYear - YearOfYear = 0 And TodaysMonthOfYear < MonthOfYear Then
            '    MsgBox("You cannot post a Batch to a future period.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'Else
            '    'Date is okay --- Continue
            'End If
        End If
        '***********************************************************************************************************
        'Retrieve Customer from batch to validate if it is a valid customer ID
        For Each row As DataGridViewRow In dgvARCustomerPayments.Rows
            Dim CheckCustomerID As String = ""
            Dim CheckDivisionID As String = ""

            Try
                CheckCustomerID = row.Cells("CustomerIDColumn").Value
            Catch ex As Exception
                CheckCustomerID = ""
            End Try
            Try
                CheckDivisionID = row.Cells("DivisionIDColumn").Value
            Catch ex As Exception
                CheckDivisionID = ""
            End Try

            'Validate Customer
            Dim ValidateCustomer As String = ""

            Dim ValidateCustomerStatement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim ValidateCustomerCommand As New SqlCommand(ValidateCustomerStatement, con)
            ValidateCustomerCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CheckCustomerID
            ValidateCustomerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CheckDivisionID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ValidateCustomer = CStr(ValidateCustomerCommand.ExecuteScalar)
            Catch ex As Exception
                ValidateCustomer = "INVALID Customer"
            End Try
            con.Close()

            If ValidateCustomer = "" Or ValidateCustomer = "INVALID Customer" Then
                MsgBox("You have one or more invalid Customers in batch. Contact system administrator.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'All Customers are Valid Customers
            End If
        Next
        '*****************************************************************************************************************
        'Update Batch Amount with the summation of the batch lines (ARCustomerPaymentTable)
        Dim SUMPaymentLines As Double = 0

        Dim SUMPaymentLinesStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim SUMPaymentLinesCommand As New SqlCommand(SUMPaymentLinesStatement, con)
        SUMPaymentLinesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        SUMPaymentLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SUMPaymentLines = CDbl(SUMPaymentLinesCommand.ExecuteScalar)
            SUMPaymentLines = Math.Round(SUMPaymentLines, 2)
        Catch ex As Exception
            SUMPaymentLines = 0
        End Try
        con.Close()

        'Update Batch Table with totals
        Try
            cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchAmount", SqlDbType.VarChar).Value = SUMPaymentLines
                .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempBatchNumber As Integer = 0
            Dim strBatchNumber As String
            TempBatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(TempBatchNumber)

            ErrorDate = TodaysDate
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "A/R Payment Batch --- Update Batch Total (L716)"
            ErrorReferenceNumber = "Batch # " + strBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '*******************************************************************************************************************
        'Create variables to retrieve line items
        Dim ARTransactionKey, InvoiceNumber, PaymentID As Integer
        Dim CustomerID, ReferenceNumber, PaymentType As String
        Dim InvoiceAmount, DiscountAmount, PaymentAmount As Double
        Dim CustomerClass As String = ""
        Dim RowDivisionID As String = ""
        Dim RowBankAccount As String = ""

        'Retrieve Receipt Of Invoice Numbers to Post to General Ledger
        For Each row As DataGridViewRow In dgvARCustomerPayments.Rows
            Try
                ARTransactionKey = row.Cells("ARTransactionKeyColumn").Value
            Catch ex As Exception
                ARTransactionKey = 0
            End Try
            Try
                CustomerID = row.Cells("CustomerIDColumn").Value
            Catch ex As Exception
                CustomerID = ""
            End Try
            Try
                InvoiceNumber = row.Cells("InvoiceNumberColumn").Value
            Catch ex As Exception
                InvoiceNumber = 0
            End Try
            Try
                InvoiceAmount = row.Cells("InvoiceAmountColumn").Value
            Catch ex As Exception
                InvoiceAmount = 0
            End Try
            Try
                DiscountAmount = row.Cells("DiscountAmountColumn").Value
            Catch ex As Exception
                DiscountAmount = 0
            End Try
            Try
                PaymentAmount = row.Cells("PaymentAmountColumn").Value
            Catch ex As Exception
                PaymentAmount = 0
            End Try
            Try
                PaymentType = row.Cells("PaymentTypeColumn").Value
            Catch ex As Exception
                PaymentType = "PAYMENT"
            End Try
            Try
                ReferenceNumber = row.Cells("ReferenceNumberColumn").Value
            Catch ex As Exception
                ReferenceNumber = "97000"
            End Try
            Try
                PaymentID = row.Cells("PaymentIDColumn").Value
            Catch ex As Exception
                PaymentID = 0
            End Try
            Try
                RowDivisionID = row.Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivisionID = ""
            End Try
            Try
                RowBankAccount = row.Cells("BankAccountColumn").Value
            Catch ex As Exception
                RowBankAccount = "Cash Receipts"
            End Try
            '*****************************************************************************
            'Define post division
            Dim PostDivision As String = ""

            If RowDivisionID = "TFP" Then
                PostDivision = "TWD"
            Else
                PostDivision = RowDivisionID
            End If
            '*******************************************************************************************************************
            'Define bank accounts
            If RowBankAccount = "Cash Receipts" Then
                DebitGLAccount = "10400"
            ElseIf RowBankAccount = "Checking" Then
                DebitGLAccount = "10200"
            ElseIf RowBankAccount = "Canadian Checking" Then
                DebitGLAccount = "C$10200"
            Else
                DebitGLAccount = "10500"
            End If
            '*******************************************************************************************************************
            If PaymentType = "ADJUSTMENT / WRITE-OFF" Then
                If RowDivisionID = "TFF" Or RowDivisionID = "TOR" Or RowDivisionID = "ALB" Then
                    If ReferenceNumber.StartsWith("C$") Then
                        DebitGLAccount = ReferenceNumber
                    Else
                        DebitGLAccount = "C$" & ReferenceNumber
                    End If
                Else
                    DebitGLAccount = ReferenceNumber
                End If
            Else
                'Do nothing
            End If
            '*******************************************************************************************************************
            'Define credit account
            If RowDivisionID = "TFF" Or RowDivisionID = "TOR" Or RowDivisionID = "ALB" Then
                'Get Customer Class
                Dim CustomerClassStatement As String = "SELECT CustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CustomerClassCommand As New SqlCommand(CustomerClassStatement, con)
                CustomerClassCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                CustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CustomerClass = CStr(CustomerClassCommand.ExecuteScalar)
                Catch ex As Exception
                    CustomerClass = "CANADIAN"
                End Try
                con.Close()
            Else
                'Skip
            End If
            '*******************************************************************************************************************
            If RowDivisionID = "TFF" And CustomerClass = "CANADIAN" Then
                GLCreditAccount = "C$11000"
            ElseIf RowDivisionID = "TOR" And CustomerClass = "CANADIAN" Then
                GLCreditAccount = "C$11000"
            ElseIf RowDivisionID = "ALB" And CustomerClass = "CANADIAN" Then
                GLCreditAccount = "C$11000"
            Else
                GLCreditAccount = "11000"
            End If
            '*******************************************************************************************************************
            Try
                'Writes first value to the General Ledger
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLCreditAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = PaymentAmount
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Customer " & CustomerID & " Invoice Number " & InvoiceNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "CASHJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = ARTransactionKey
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Insert into Audit Trail
                cmd = New SqlCommand("Insert Into AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment,  DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment,  @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "AR Payment Posting"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = PaymentAmount
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = ARTransactionKey
                    .Add("@AuditComment", SqlDbType.VarChar).Value = "Fail on Credit GL Posting first attempt"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '************************************************************************************************************************
                Try
                    'Writes first value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLCreditAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = PaymentAmount
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Customer " & CustomerID & " Invoice Number " & InvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "CASHJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = ARTransactionKey
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex2 As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex2.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "A/R Payment Batch --- GL Credit Posting (L888)"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End Try
            '**********************************************************************************************************************
            'Writes the debit amount to the transaction table
            Try
                'Writes second value to the General Ledger
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = PaymentAmount
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Customer " & CustomerID & "- Invoice Number " & InvoiceNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "CASHJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = ARTransactionKey
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex1 As Exception
                'Insert into Audit Trail
                cmd = New SqlCommand("Insert Into AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment,  DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment,  @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "AR Payment Posting"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = PaymentAmount
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = ARTransactionKey
                    .Add("@AuditComment", SqlDbType.VarChar).Value = "Fail on Debit GL Posting first attempt"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***************************************************************************************************
                Try
                    'Writes second value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = PaymentAmount
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Customer " & CustomerID & "- Invoice Number " & InvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "CASHJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = ARTransactionKey
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex2 As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex2.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "A/R Payment Batch --- GL Debit Posting (L971)"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End Try
            '*******************************************************************************************************************
            Try
                'Update AR Customer Payment Record and AR log to Posted
                cmd = New SqlCommand("UPDATE ARCustomerPayment SET Status = @Status, PaymentDate = @PaymentDate WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ARTransactionKey", SqlDbType.VarChar).Value = ARTransactionKey
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    .Add("@Status", SqlDbType.VarChar).Value = "POSTED"
                    .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Value
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "A/R Payment Batch --- Update Customer Payment Status (L1003)"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*******************************************************************************************************************
            Try
                'Update AR Payment Log to POSTED Status
                cmd = New SqlCommand("UPDATE ARPaymentLog SET PaymentStatus = @PaymentStatus, PaymentDate = @PaymentDate WHERE PaymentID = @PaymentID", con)

                With cmd.Parameters
                    .Add("@PaymentID", SqlDbType.VarChar).Value = PaymentID
                    .Add("@PaymentStatus", SqlDbType.VarChar).Value = "POSTED"
                    .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Value
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "A/R Payment Batch --- Update A/R Payment Log Status (L1033)"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*******************************************************************************************************************
            'Clear variables for next entry
            ARTransactionKey = 0
            InvoiceNumber = 0
            CustomerClass = ""
            CustomerID = ""
            ReferenceNumber = ""
            PaymentType = ""
            InvoiceAmount = 0
            DiscountAmount = 0
            PaymentAmount = 0
        Next
        '*******************************************************************************************************************
        'Retrieve Customer from batch to validate if it is a valid customer ID
        For Each row As DataGridViewRow In dgvARCustomerPayments.Rows
            Dim RecheckInvoiceNumber As Integer = 0
            Dim SumPaymentTotal As Double = 0
            Dim RecheckDivisionID As String = ""

            Try
                RecheckInvoiceNumber = row.Cells("InvoiceNumberColumn").Value
            Catch ex As Exception
                RecheckInvoiceNumber = 0
            End Try
            Try
                RecheckDivisionID = row.Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RecheckDivisionID = ""
            End Try

            'Get sum of Payments for the Invoice number
            Dim SumPaymentTotalStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID AND Status = @Status"
            Dim SumPaymentTotalCommand As New SqlCommand(SumPaymentTotalStatement, con)
            SumPaymentTotalCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RecheckInvoiceNumber
            SumPaymentTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RecheckDivisionID
            SumPaymentTotalCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumPaymentTotal = CDbl(SumPaymentTotalCommand.ExecuteScalar)
                SumPaymentTotal = Math.Round(SumPaymentTotal, 2)
            Catch ex As Exception
                SumPaymentTotal = 0
            End Try
            con.Close()

            Try
                'Update Invoice Record
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PaymentsApplied = @PaymentsApplied WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RecheckInvoiceNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RecheckDivisionID
                    .Add("@PaymentsApplied", SqlDbType.VarChar).Value = SumPaymentTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "**** A/R Process Payment --- Update Invoice Payments Applied Failure (L1108)"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Recheck payments applied to Invoice Total and close if necessary
            Dim GetInvoiceTotal As Double = 0

            Dim GetInvoiceTotalStatement As String = "SELECT InvoiceTotal FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim GetInvoiceTotalCommand As New SqlCommand(GetInvoiceTotalStatement, con)
            GetInvoiceTotalCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RecheckInvoiceNumber
            GetInvoiceTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RecheckDivisionID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetInvoiceTotal = CDbl(GetInvoiceTotalCommand.ExecuteScalar)
                GetInvoiceTotal = Math.Round(GetInvoiceTotal, 2)
            Catch ex As Exception
                GetInvoiceTotal = 0
            End Try
            con.Close()

            If GetInvoiceTotal = SumPaymentTotal Then
                'Close Invoice
                Try
                    'Update Invoice Record
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceStatus = @InvoiceStatus WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RecheckInvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RecheckDivisionID
                        .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = RecheckInvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RecheckDivisionID
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "A/R Payment Batch --- Update Invoice Status (L1169)"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            ElseIf GetInvoiceTotal - SumPaymentTotal < 0.02 And GetInvoiceTotal - SumPaymentTotal > 0 Then
                'Close Invoice
                Try
                    'Update Invoice Record
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceStatus = @InvoiceStatus WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RecheckInvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RecheckDivisionID
                        .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = RecheckInvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RecheckDivisionID
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "A/R Payment Batch --- Update Invoice Status (L1212)"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        Next
        '*******************************************************************************************************************
        'Load Batch Totals
        LoadTotals()
        '*******************************************************************************************************************
        If Val(txtBatchTotal.Text) = 0 And Val(txtCurrentTotal.Text) <> 0 Then
            txtBatchTotal.Text = txtCurrentTotal.Text
        End If

        Try
            'UPDATE Batch Status
            cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET BatchStatus = @BatchStatus, Locked = @Locked, PrintDate = @PrintDate WHERE BatchNumber = @BatchNumber", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"
                .Add("@Locked", SqlDbType.VarChar).Value = ""
                .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempBatchNumber As Integer = 0
            Dim strBatchNumber As String
            TempBatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(TempBatchNumber)

            ErrorDate = TodaysDate
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "A/R Payment Batch --- Update Batch Status (L1253)"
            ErrorReferenceNumber = "Batch # " + strBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '*******************************************************************************************************************
        MsgBox("Batch has been posted.", MsgBoxStyle.OkOnly)

        'Load defaults
        LoadBatchNumber()
        ClearVariables()
        ClearBatch()

        dgvARCustomerPayments.DataSource = Nothing
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Load Batch Status to determine if Batch can be edited
        LoadBatchStatus()
        '************************************************************************************
        If BatchStatus = "POSTED" Then
            MsgBox("Batch has been posted - no changes can be saved.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '************************************************************************************
        ''check to see if this batch is being edited by someone else
        If isSomeoneEditing() Then
            Exit Sub
        End If
        '************************************************************************************
        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid Batch # selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '************************************************************************************
        If Val(txtBatchTotal.Text) = 0 And Val(txtCurrentTotal.Text) <> 0 Then
            txtBatchTotal.Text = 0
        End If
        '************************************************************************************
        'Sum the payments in the batch and update batch totals

        Dim SumPayments As Double = 0

        Dim SumPaymentsStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim SumPaymentsCommand As New SqlCommand(SumPaymentsStatement, con)
        SumPaymentsCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        SumPaymentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumPayments = CDbl(SumPaymentsCommand.ExecuteScalar)
            SumPayments = Math.Round(SumPayments, 2)
        Catch ex As Exception
            SumPayments = 0
        End Try
        con.Close()

        txtBatchTotal.Text = SumPayments
        '************************************************************************************
        Try
            'Write Data to Batch Header Database Table
            cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, DivisionID = @DivisionID, BatchStatus = @BatchStatus, Locked = @Locked WHERE BatchNumber = @BatchNumber", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchStatus", SqlDbType.VarChar).Value = txtBatchStatus.Text
                .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ARCustomerPayment SET PaymentDate = @PaymentDate Where DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE ARPaymentLog SET PaymentDate = @PaymentDate Where DivisionID = @DivisionID AND ARBatchNumber = @ARBatchNumber", con)

            With cmd.Parameters
                .Add("@ARBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Batch has been saved.", MsgBoxStyle.OkOnly)

            LoadTotals()
            ShowBatchLines()
        Catch ex As Exception
            'Log error on update failure
            Dim TempBatchNumber As Integer = 0
            Dim strBatchNumber As String
            TempBatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(TempBatchNumber)

            ErrorDate = TodaysDate
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "A/R Payment Batch --- Save routine (L1347)"
            ErrorReferenceNumber = "Batch # " + strBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid Batch # selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************
        'Load Status
        LoadBatchStatus()
        '*************************************************************************************
        If BatchStatus = "OPEN" Then
            ''check to see if this batch is being edited by someone else
            If Not isSomeoneEditing() Then
                If Val(txtBatchTotal.Text) = 0 And Val(txtCurrentTotal.Text) <> 0 Then
                    txtBatchTotal.Text = 0
                End If
                '************************************************************************************
                'Sum the payments in the batch and update batch totals

                Dim SumPayments As Double = 0

                Dim SumPaymentsStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                Dim SumPaymentsCommand As New SqlCommand(SumPaymentsStatement, con)
                SumPaymentsCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                SumPaymentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumPayments = CDbl(SumPaymentsCommand.ExecuteScalar)
                    SumPayments = Math.Round(SumPayments, 2)
                Catch ex As Exception
                    SumPayments = 0
                End Try
                con.Close()

                txtBatchTotal.Text = SumPayments
                '************************************************************************************
                Try
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, DivisionID = @DivisionID, BatchStatus = @BatchStatus WHERE BatchNumber = @BatchNumber", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = txtBatchStatus.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    LoadTotals()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "A/R Payment Batch --- Save Batch (Print Button) (L1399)"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If

            GDS = ds

            'Choose the correct Print Form (REMOTE or LOCAL)

            'Get Login Type
            Dim GetLoginType As String = ""

            Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
            GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetLoginType = ""
            End Try
            con.Close()

            If GetLoginType = "REMOTE" Then
                Using NewPrintARCustomerPaymentBatchRemote As New PrintARCustomerPaymentBatchRemote
                    Dim result = NewPrintARCustomerPaymentBatchRemote.ShowDialog()
                End Using
            Else
                Using NewPrintARCustomerPaymentBatch As New PrintARCustomerPaymentBatch
                    Dim result = NewPrintARCustomerPaymentBatch.ShowDialog()
                End Using
            End If
        Else
            GDS = ds
            'Choose the correct Print Form (REMOTE or LOCAL)

            'Get Login Type
            Dim GetLoginType As String = ""

            Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
            GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetLoginType = ""
            End Try
            con.Close()

            If GetLoginType = "REMOTE" Then
                Using NewPrintARCustomerPaymentBatchRemote As New PrintARCustomerPaymentBatchRemote
                    Dim result = NewPrintARCustomerPaymentBatchRemote.ShowDialog()
                End Using
            Else
                Using NewPrintARCustomerPaymentBatch As New PrintARCustomerPaymentBatch
                    Dim result = NewPrintARCustomerPaymentBatch.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else



            ''check to see if this batch is being edited by someone else
            If isSomeoneEditing() Then
                Exit Sub
            End If
            '****************************************************************************************************

            'Deletes Saved Receipt
            Dim destinationPath As String = ""
            Dim MoveLocation As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\"
            Dim filename As String = cboBatchNumber.Text + ".pdf"
            destinationPath = System.IO.Path.Combine(MoveLocation, filename)
            If File.Exists(destinationPath) Then
                File.Delete(destinationPath)
                cmdViewReceipt.Enabled = False
                cmdScan.Enabled = False
                cmdUpload.Enabled = False
            End If

            'Delete all entries in AR Customer Payment Table
            cmd = New SqlCommand("DELETE FROM ARCustomerPayment WHERE BatchNumber = @BatchNumber", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '****************************************************************************************************
            'Run Routine to get sum of payments for each invoice and save into Invoice Header Table
            For Each row As DataGridViewRow In dgvARCustomerPayments.Rows
                Dim SumPaymentsTotal As Double = 0

                Dim ARInvoiceNumber As Integer = row.Cells("InvoiceNumberColumn").Value
                Dim ARDivisionID As String = row.Cells("DivisionIDColumn").Value
                Dim ARPaymentID As Integer = row.Cells("PaymentIDColumn").Value
                '****************************************************************
                'Delete record in AR Payment Log
                cmd = New SqlCommand("DELETE FROM ARPaymentLog WHERE PaymentID = @PaymentID", con)
                cmd.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = ARPaymentID

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '****************************************************************
                Dim SumPaymentsTotalStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                Dim SumPaymentsTotalCommand As New SqlCommand(SumPaymentsTotalStatement, con)
                SumPaymentsTotalCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = ARInvoiceNumber
                SumPaymentsTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ARDivisionID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumPaymentsTotal = CDbl(SumPaymentsTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    SumPaymentsTotal = 0
                End Try
                con.Close()
                '****************************************************************
                Dim InvoiceTotalStatement As String = "SELECT InvoiceTotal FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                Dim InvoiceTotalCommand As New SqlCommand(InvoiceTotalStatement, con)
                InvoiceTotalCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = ARInvoiceNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    InvoiceTotal = CDbl(InvoiceTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    InvoiceTotal = 0
                End Try
                con.Close()
                '****************************************************************
                If SumPaymentsTotal = InvoiceTotal Then
                    InvoiceStatus = "CLOSED"
                Else
                    InvoiceStatus = "OPEN"
                End If
                '****************************************************************
                'Update Invoice Header Table with New Payments Applied Amount
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PaymentsApplied = @PaymentsApplied, InvoiceStatus = @InvoiceStatus WHERE InvoiceNumber = @InvoiceNumber", con)
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = ARInvoiceNumber
                cmd.Parameters.Add("@PaymentsApplied", SqlDbType.VarChar).Value = SumPaymentsTotal
                cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = InvoiceStatus

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '****************************************************************
                'UPDATE Invoice Line Table
                cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey", con)
                cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = ARInvoiceNumber
                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = InvoiceStatus

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next
            '***************************************************************************************************
            'Write Data to Batch Header Database Table
            cmd = New SqlCommand("DELETE FROM ARProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Batch has been deleted.", MsgBoxStyle.OkOnly)

            LoadBatchNumber()
            GlobalARDivisionCode = ""
            GlobalARBatchNumber = 0
            ClearVariables()
            ClearBatch()
            ShowBatchLines()
        End If
    End Sub

    Private Sub cmdClearBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearBatch.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch()
        End If

        GlobalARDivisionCode = ""
        GlobalARBatchNumber = 0
        ClearVariables()
        ClearBatch()
        ClearBatchLines()
    End Sub

    Private Sub cmdDeletePaymentRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeletePaymentRecord.Click
        Dim DeletePaymentID, DeletePaymentLineNumber, CountLines, InvoiceNumber As Integer
        Dim SumInvoicePayments As Double
        Dim GetStatus As String

        If cboBatchNumber.Text = "" Or cboPaymentID.Text = "" Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            If cboDivisionID.Text = "ADM" Then
                'Check Batch and Payment Status
                Dim GetStatusStatement As String = "SELECT BatchStatus FROM ARProcessPaymentBatch WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                Dim GetStatusCommand As New SqlCommand(GetStatusStatement, con)
                GetStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetStatus = CStr(GetStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    GetStatus = "OPEN"
                End Try

                If GetStatus = "POSTED" Then
                    MsgBox("Batch is already POSTED - you cannot delete a payment record.", MsgBoxStyle.OkOnly)
                Else
                    ''check to see if this batch is being edited by someone else
                    If isSomeoneEditing() Then
                        Exit Sub
                    End If

                    Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Payment?", "DELETE PAYMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button = DialogResult.Yes Then
                        LockBatch()
                        'Get Payment ID and Line Number to delete record in Payment Log Table
                        Dim PaymentIDStatement As String = "SELECT PaymentID FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND BatchNumber = @BatchNumber"
                        Dim PaymentIDCommand As New SqlCommand(PaymentIDStatement, con)
                        PaymentIDCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        PaymentIDCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                        Dim PaymentLineIDStatement As String = "SELECT PaymentLineNumber FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND BatchNumber = @BatchNumber"
                        Dim PaymentLineIDCommand As New SqlCommand(PaymentLineIDStatement, con)
                        PaymentLineIDCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        PaymentLineIDCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            DeletePaymentID = CInt(PaymentIDCommand.ExecuteScalar)
                        Catch ex As Exception
                            DeletePaymentID = 0
                        End Try
                        Try
                            DeletePaymentLineNumber = CInt(PaymentLineIDCommand.ExecuteScalar)
                        Catch ex As Exception
                            DeletePaymentLineNumber = 0
                        End Try
                        con.Close()

                        'Delete record in AR Payment Lines
                        cmd = New SqlCommand("DELETE FROM ARPaymentLines WHERE PaymentID = @PaymentID AND LineNumber = @LineNumber", con)
                        cmd.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = DeletePaymentID
                        cmd.Parameters.Add("@LineNumber", SqlDbType.VarChar).Value = DeletePaymentLineNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Count Lines in ARPaymentLog Table - if zero, then delete
                        Dim CountLinesStatement As String = "SELECT COUNT(PaymentID) FROM ARPaymentLines WHERE PaymentID = @PaymentID"
                        Dim CountLinesCommand As New SqlCommand(CountLinesStatement, con)
                        CountLinesCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = DeletePaymentID

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountLines = CInt(CountLinesCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountLines = 0
                        End Try
                        con.Close()

                        If CountLines = 0 Then
                            'Delete record in AR Payment Lines
                            cmd = New SqlCommand("DELETE FROM ARPaymentLog WHERE PaymentID = @PaymentID", con)
                            cmd.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = DeletePaymentID

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            'Do nothing - one line is deleted and the others remain
                        End If

                        'Reset Invoice Paid Amount and re-open Invoice Status
                        Dim InvoiceNumberStatement As String = "SELECT InvoiceNumber FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND BatchNumber = @BatchNumber"
                        Dim InvoiceNumberCommand As New SqlCommand(InvoiceNumberStatement, con)
                        InvoiceNumberCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        InvoiceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        InvoiceNumberCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            InvoiceNumber = CInt(InvoiceNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            InvoiceNumber = 0
                        End Try
                        con.Close()

                        'Get Total Payments for the Invoice from the ARPaymentLine Table
                        Dim SumInvoicePaymentsStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLines WHERE ARInvoiceNumber = @ARInvoiceNumber AND DivisionID = @DivisionID"
                        Dim SumInvoicePaymentsCommand As New SqlCommand(SumInvoicePaymentsStatement, con)
                        SumInvoicePaymentsCommand.Parameters.Add("@ARInvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                        SumInvoicePaymentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SumInvoicePayments = CDbl(SumInvoicePaymentsCommand.ExecuteScalar)
                        Catch ex As Exception
                            SumInvoicePayments = 0
                        End Try
                        con.Close()

                        'Update Invoice Table
                        cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PaymentsApplied = @PaymentsApplied, InvoiceStatus = @InvoiceStatus WHERE InvoiceNumber = @InvoiceNumber", con)
                        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                        cmd.Parameters.Add("@PaymentsApplied", SqlDbType.VarChar).Value = SumInvoicePayments
                        cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Update Invoice Line Table
                        cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey", con)
                        cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Delete record from ARCustomerPayment Table and refresh datagrid
                        cmd = New SqlCommand("DELETE FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND BatchNumber = @BatchNumber", con)
                        cmd.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        ShowBatchLines()
                        LoadTransactionNumber()
                        LoadTotals()

                        MsgBox("Payment has been deleted.", MsgBoxStyle.OkOnly)
                    ElseIf button = DialogResult.No Then
                        cmdDeletePaymentRecord.Focus()
                    End If
                End If
            Else
                'Check Batch and Payment Status
                Dim GetStatusStatement As String = "SELECT BatchStatus FROM ARProcessPaymentBatch WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                Dim GetStatusCommand As New SqlCommand(GetStatusStatement, con)
                GetStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetStatus = CStr(GetStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    GetStatus = "OPEN"
                End Try

                If GetStatus = "POSTED" Then
                    MsgBox("Batch is already POSTED - you cannot delete a payment record.", MsgBoxStyle.OkOnly)
                Else
                    ''check to see if this batch is being edited by someone else
                    If isSomeoneEditing() Then
                        Exit Sub
                    End If

                    Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Payment?", "DELETE PAYMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button = DialogResult.Yes Then
                        LockBatch()
                        'Get Payment ID and Line Number to delete record in Payment Log Table
                        Dim PaymentIDStatement As String = "SELECT PaymentID FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                        Dim PaymentIDCommand As New SqlCommand(PaymentIDStatement, con)
                        PaymentIDCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        PaymentIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        PaymentIDCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                        Dim PaymentLineIDStatement As String = "SELECT PaymentLineNumber FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                        Dim PaymentLineIDCommand As New SqlCommand(PaymentLineIDStatement, con)
                        PaymentLineIDCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        PaymentLineIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        PaymentLineIDCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            DeletePaymentID = CInt(PaymentIDCommand.ExecuteScalar)
                        Catch ex As Exception
                            DeletePaymentID = 0
                        End Try
                        Try
                            DeletePaymentLineNumber = CInt(PaymentLineIDCommand.ExecuteScalar)
                        Catch ex As Exception
                            DeletePaymentLineNumber = 0
                        End Try
                        con.Close()

                        'Delete record in AR Payment Lines
                        cmd = New SqlCommand("DELETE FROM ARPaymentLines WHERE PaymentID = @PaymentID AND LineNumber = @LineNumber", con)
                        cmd.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = DeletePaymentID
                        cmd.Parameters.Add("@LineNumber", SqlDbType.VarChar).Value = DeletePaymentLineNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Count Lines in ARPaymentLog Table - if zero, then delete
                        Dim CountLinesStatement As String = "SELECT COUNT(PaymentID) FROM ARPaymentLines WHERE PaymentID = @PaymentID"
                        Dim CountLinesCommand As New SqlCommand(CountLinesStatement, con)
                        CountLinesCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = DeletePaymentID

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountLines = CInt(CountLinesCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountLines = 0
                        End Try
                        con.Close()

                        If CountLines = 0 Then
                            'Delete record in AR Payment Lines
                            cmd = New SqlCommand("DELETE FROM ARPaymentLog WHERE PaymentID = @PaymentID AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = DeletePaymentID
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            'Do nothing - one line is deleted and the others remain
                        End If

                        'Reset Invoice Paid Amount and re-open Invoice Status
                        Dim InvoiceNumberStatement As String = "SELECT InvoiceNumber FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                        Dim InvoiceNumberCommand As New SqlCommand(InvoiceNumberStatement, con)
                        InvoiceNumberCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        InvoiceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        InvoiceNumberCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            InvoiceNumber = CInt(InvoiceNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            InvoiceNumber = 0
                        End Try
                        con.Close()

                        'Get Total Payments for the Invoice from the ARPaymentLine Table
                        Dim SumInvoicePaymentsStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLines WHERE ARInvoiceNumber = @ARInvoiceNumber AND DivisionID = @DivisionID"
                        Dim SumInvoicePaymentsCommand As New SqlCommand(SumInvoicePaymentsStatement, con)
                        SumInvoicePaymentsCommand.Parameters.Add("@ARInvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                        SumInvoicePaymentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SumInvoicePayments = CDbl(SumInvoicePaymentsCommand.ExecuteScalar)
                        Catch ex As Exception
                            SumInvoicePayments = 0
                        End Try
                        con.Close()

                        'Update Invoice Table
                        cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PaymentsApplied = @PaymentsApplied, InvoiceStatus = @InvoiceStatus WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@PaymentsApplied", SqlDbType.VarChar).Value = SumInvoicePayments
                        cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Update Invoice Line Table
                        cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Delete record from ARCustomerPayment Table and refresh datagrid
                        cmd = New SqlCommand("DELETE FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)
                        cmd.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        ShowBatchLines()
                        LoadTransactionNumber()
                        LoadTotals()

                        MsgBox("Payment has been deleted.", MsgBoxStyle.OkOnly)
                    ElseIf button = DialogResult.No Then
                        cmdDeletePaymentRecord.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        LoadBatchStatus()

        'Unlock Batch
        Try
            'Write Data to Batch Header Database Table
            cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET Locked = @Locked WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@Locked", SqlDbType.VarChar).Value = ""
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip
        End Try

        If BatchStatus = "POSTED" Then
            GlobalARDivisionCode = ""
            GlobalNewARBatchNumber = 0

            ClearVariables()
            ClearBatch()
            Me.Dispose()
            Me.Close()
        Else
            If cboBatchNumber.Text = "" Then
                GlobalARDivisionCode = ""
                GlobalNewARBatchNumber = 0

                ClearVariables()
                ClearBatch()
                Me.Dispose()
                Me.Close()
            Else
                'Prompt before Saving
                Dim button As DialogResult = MessageBox.Show("Do you wish to save this Batch?", "SAVE BATCH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Load Totals
                    LoadTotals()

                    Try
                        'Write Data to Batch Header Database Table
                        cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, DivisionID = @DivisionID, BatchStatus = @BatchStatus WHERE BatchNumber = @BatchNumber", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                            .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBatchNumber As Integer = 0
                        Dim strBatchNumber As String
                        TempBatchNumber = Val(cboBatchNumber.Text)
                        strBatchNumber = CStr(TempBatchNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "A/R Payment Batch --- Update Batch (On exit)"
                        ErrorReferenceNumber = "Batch # " + strBatchNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    GlobalARDivisionCode = ""
                    GlobalNewARBatchNumber = 0

                    ClearVariables()
                    ClearBatch()
                    Me.Dispose()
                    Me.Close()
                ElseIf button = DialogResult.No Then
                    GlobalARDivisionCode = ""
                    GlobalNewARBatchNumber = 0

                    ClearVariables()
                    ClearBatch()
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub cmdViewRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewReceipt.Click
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
        If File.Exists(CashReceiptExists) Then
            System.Diagnostics.Process.Start(CashReceiptExists)
        End If
    End Sub

    Private Sub cmdUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpload.Click
        If canSave() Then
            Try
                Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
            Catch ex As System.Exception
            End Try

            Dim MoveLocation As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\"
            Dim destinationPath As String = ""

            Dim fd As OpenFileDialog = New OpenFileDialog()
            Dim strFileName As String = ""

            fd.Title = "Open File Dialog"
            fd.InitialDirectory = "C:\"
            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                strFileName = fd.FileName
            End If

            If File.Exists(strFileName) Then
                Dim filename As String = System.IO.Path.GetFileName(strFileName)
                destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                If File.Exists(destinationPath) Then
                    File.Delete(destinationPath)
                End If
                File.Move(strFileName, destinationPath)
                Dim rename As String = cboBatchNumber.Text + ".pdf"
                My.Computer.FileSystem.RenameFile(destinationPath, rename)
                MsgBox("File Moved")
                Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
                If File.Exists(CashReceiptExists) Then
                    cmdViewReceipt.Enabled = True
                    AppendBaToolStripMenuItem.Enabled = True
                    ReUploadBatchToolStripMenuItem.Enabled = True
                    cmdUpload.Enabled = False
                    cmdScan.Enabled = False
                Else
                    cmdViewReceipt.Enabled = False
                    AppendBaToolStripMenuItem.Enabled = False
                    ReUploadBatchToolStripMenuItem.Enabled = False
                    cmdUpload.Enabled = True
                    cmdScan.Enabled = True
                End If
            Else
                MsgBox("File Not move")
                AppendBaToolStripMenuItem.Enabled = False
                ReUploadBatchToolStripMenuItem.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmdScanRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScan.Click
        ScanCashReceipt()
    End Sub

    Private Sub cmdRemoteScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoteScan.Click
        Dim BatchFilename As String = ""
        Dim BatchFilenameAndPath As String = ""
        Dim strBatchNumber As String = ""

        'Verify that they have a Batch selected
        If cboBatchNumber.Text = "" Then
            MsgBox("You must select a valid Batch.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            strBatchNumber = cboBatchNumber.Text
        End If

        Dim UploadedBatchNumber As String = cboBatchNumber.Text

        BatchFilename = strBatchNumber + ".pdf"
        BatchFilenameAndPath = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + BatchFilename

        If File.Exists(BatchFilenameAndPath) Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to overwrite this scanned Batch?", "OVERWRITE EXISTING BATCH?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete existing Batch before upload
                File.Delete(BatchFilenameAndPath)

                Dim My_Process As New Process()
                'Dim My_Process_Info As New ProcessStartInfo

                Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
                strBatchNumber = CStr(cboBatchNumber.Text)

                BatchFilename = strBatchNumber + ".pdf"
                BatchFilenameAndPath = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + BatchFilename

                'My_Process_Info.UseShellExecute = False
                'My_Process_Info.RedirectStandardOutput = True
                'My_Process_Info.RedirectStandardError = True
                'My_Process_Info.CreateNoWindow = True

                Try
                    My_Process.Start(ApplicationFileAndPath, "-o " & BatchFilenameAndPath)
                    'My_Process.WaitForExit()
                    My_Process.Close()
                Catch ex As Exception
                    '    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber1 As String = ""
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber1 = CStr(TempBatchNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ApplicationFileAndPath & "" & BatchFilenameAndPath
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Receipt Of Goods --- Scan"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber1
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MsgBox("Scan failed", MsgBoxStyle.OkOnly)
                End Try
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        Else
            Dim My_Process As New Process()
            'Dim My_Process_Info As New ProcessStartInfo

            Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
            strBatchNumber = CStr(cboBatchNumber.Text)

            BatchFilename = strBatchNumber + ".pdf"
            BatchFilenameAndPath = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + BatchFilename

            'My_Process_Info.UseShellExecute = False
            'My_Process_Info.RedirectStandardOutput = True
            'My_Process_Info.RedirectStandardError = True
            'My_Process_Info.CreateNoWindow = True

            Try
                My_Process.Start(ApplicationFileAndPath, "-o " & BatchFilenameAndPath)
                'My_Process.WaitForExit()
                My_Process.Close()
            Catch ex As Exception
                '    'Log error on update failure
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber1 As String = ""
                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber1 = CStr(TempBatchNumber)

                ErrorDate = TodaysDate
                ErrorComment = ApplicationFileAndPath & "" & BatchFilenameAndPath
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Cash Receipts Batch --- Scan"
                ErrorReferenceNumber = "Batch # " + strBatchNumber1
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Scan failed", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    'Menu Strip Controls

    Private Sub DeleteBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBatchToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ClearBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBatchToolStripMenuItem.Click
        cmdClearBatch_Click(sender, e)
    End Sub

    Private Sub SaveBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBatchToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub PrintBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBatchToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub UnLockBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockBatchToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this batch?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET Locked = '' WHERE BatchNumber = @BatchNumber", con)
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Batch is now un-locked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You must enter a batch number to un-lock", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
        End If
    End Sub

    Private Sub UploadToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadToolStripMenuItem1.Click
        If canSave() Then
            Try
                Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
            Catch ex As System.Exception
            End Try

            Dim MoveLocation As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\"
            Dim destinationPath As String = ""

            Dim fd As OpenFileDialog = New OpenFileDialog()
            Dim strFileName As String = ""

            fd.Title = "Open File Dialog"
            fd.InitialDirectory = "C:\"
            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                strFileName = fd.FileName
            End If

            If File.Exists(strFileName) Then
                Dim filename As String = System.IO.Path.GetFileName(strFileName)
                destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                If File.Exists(destinationPath) Then
                    File.Delete(destinationPath)
                End If
                File.Move(strFileName, destinationPath)
                Dim rename As String = cboBatchNumber.Text + ".pdf"
                My.Computer.FileSystem.RenameFile(destinationPath, rename)

                MsgBox("File Moved")
                Dim W9Exists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
                If File.Exists(W9Exists) Then
                    cmdViewReceipt.Enabled = True
                Else
                    cmdViewReceipt.Enabled = False
                End If

            Else
                MsgBox("File Not moved")
            End If
        End If

    End Sub

    Private Sub UploadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadToolStripMenuItem.Click
        If canSave() Then
            Dim W9Exists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
            If File.Exists(W9Exists) Then
                Dim name1, name2, final1 As String
                Try
                    Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")

                Catch ex As System.Exception
                End Try

                Dim MoveLocation As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND"
                Dim destinationPath As String = ""

                Dim fd As OpenFileDialog = New OpenFileDialog()
                Dim strFileName As String = ""

                fd.Title = "Open File Dialog"
                fd.InitialDirectory = "C:\"
                fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
                fd.FilterIndex = 2
                fd.RestoreDirectory = True

                If fd.ShowDialog() = DialogResult.OK Then
                    strFileName = fd.FileName
                End If

                If File.Exists(strFileName) Then
                    Dim filename As String = System.IO.Path.GetFileName(strFileName)
                    destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                    If File.Exists(destinationPath) Then
                        File.Delete(destinationPath)
                    End If
                    File.Move(strFileName, destinationPath)
                    Dim rename As String = "Appended2" + ".pdf"
                    My.Computer.FileSystem.RenameFile(destinationPath, rename)
                    Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
                    Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                    My.Computer.FileSystem.MoveFile(initial, final)
                    final1 = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
                    name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                    name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"
                    Dim pathArray = New String() {name1, name2}
                    Try
                        MergePdfFiles(pathArray, final1)
                        MsgBox("File Appended")
                    Catch ex As Exception
                        MsgBox("File Not Appended")
                    End Try

                Else
                    MsgBox("File Not Appended")
                End If
            Else
                MsgBox("No Initial Upload")
            End If
        Else

        End If
    End Sub

    Private Sub ScanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanToolStripMenuItem.Click

        Dim name1, name2, final1 As String
        remoteScan = False
        Dim W9Exists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
        If File.Exists(W9Exists) Then
            If canSave() Then

                ' Deletes the WIA testing temp file
                Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing"
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                ' Creates the folder if the temp folder is not currently created
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")


                path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                'If there had been a previous scan then delete the picture from the picturebox
                GlobalVariables.Counter = 0
                Dim mgr As New WIA.DeviceManagerClass
                Dim Scanner As WIA.Device = Nothing
                If mgr.DeviceInfos.Count > 1 Then
                    ''More than 1 scanner was detected
                    Dim lst As New List(Of Integer)
                    ''Finds all the USB scanners
                    For i As Integer = 1 To mgr.DeviceInfos.Count()
                        If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                            lst.Add(i)
                        End If
                    Next
                    ''Check to see how many usb scanners were found
                    If lst.Count > 1 Or lst.Count = 0 Then
                        Dim selectScanner As New WIA.CommonDialog
                        Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
                    Else
                        Scanner = mgr.DeviceInfos(lst(0)).Connect()
                    End If
                ElseIf mgr.DeviceInfos.Count = 0 Then
                    ''No scanners were detected
                    If My.Computer.Name.ToString.StartsWith("TFP") Then
                        Dim loadingScreen As New Loading

                        bgwkRemoteWIA = New BackgroundWorker()
                        bgwkRemoteWIA.WorkerReportsProgress = True
                        AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_run
                        AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_CompletedAppend
                        AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_Progress
                        remoteScan = True

                        remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, ShipmentNumber)
                        bgwkRemoteWIA.RunWorkerAsync()
                        loadingScreen.Close()
                    Else
                        ''No scanners were detected
                        MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    ''Only 1 scanner is connected
                    Scanner = mgr.DeviceInfos(1).Connect()
                End If

                If Scanner IsNot Nothing Then
                    Dim item As WIA.Item = Scanner.Items(1)
                    Dim obj As Object
                    Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
                    ''Specific scanning properties
                    For Each prop As WIA.Property In Scanner.Items(1).Properties
                        Dim x As WIA.IProperty = prop
                        Select Case prop.PropertyID
                            Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                                obj = 0
                                x.let_Value(obj)
                            Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                                obj = 2
                                x.let_Value(obj)
                            Case "6147" ''(DPI) Horizontal Resolution
                                obj = 200
                                x.let_Value(obj)
                            Case "6148" ''(DPI) Vertical Resolution
                                obj = 200
                                x.let_Value(obj)
                            Case "6151" ''horizontal extent (width)
                                obj = 1700
                                x.let_Value(obj)
                            Case "6152" ''vertical extent (height)
                                obj = 2338
                                x.let_Value(obj)
                        End Select
                    Next

                    Dim dial As New WIA.CommonDialog
                    Dim hasMorePages As Boolean = True
                    Dim ScannedAtleastOnePage As Boolean = False
                    Dim pages As Integer = 0
                    Dim ScannedImages As New List(Of iTextSharp.text.Image)
                    If remoteScan = False Then
                        ''Loops until all pages are scanned.
                        While hasMorePages
                            GlobalVariables.Counter = GlobalVariables.Counter + 1
                            pages += 1
                            Try
                                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                                Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                                Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                                Img.SaveFile(tmp)
                                'ScannedImages.Add(Img.fromfile(tmp))
                                ScannedAtleastOnePage = True
                            Catch ex As System.Exception
                                ''Looks for paper empty error to break the loop and/or to show error message
                                If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                                    If Not ScannedAtleastOnePage Then
                                        MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        GlobalVariables.paperscan = False
                                    Else
                                        GlobalVariables.paperscan = True
                                    End If
                                    hasMorePages = False
                                End If
                            End Try
                        End While

                        'Displays the first saved scan into the picturebox
                        If GlobalVariables.paperscan Then
                            GlobalVariables.StartCounter = 1
                            Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                            GlobalVariables.NextPrevious = GlobalVariables.StartCounter
                        End If
                    End If

                    'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
                    GlobalVariables.previousScan = True
                    GlobalVariables.NextPrevious = 1
                End If
                Dim extensions As New List(Of String)
                extensions.Add("*.bmp")
                Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

                'counts the files in the folder
                Dim fileCount As Integer
                For i As Integer = 0 To extensions.Count - 1
                    fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
                Next
                GlobalVariables.totalfiles = fileCount
            End If
            If remoteScan = False Then
                Try

                    'Variables Declared
                    Dim comboboxSelection As String = cboPaymentID.Text

                    Dim strDir As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\"
                    If Not System.IO.Directory.Exists(strDir) Then System.IO.Directory.CreateDirectory(strDir)

                    'Name of file

                    Dim strFilename As String = "Appended2.pdf"
                    'path to bmp
                    Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                    Dim strCompletePath As String = strDir & strFilename
                    Dim pdfDoc As New document()
                    Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
                    pdfDoc.Open()
                    'Grabs the bmp image seen on screen
                    Dim img As iTextSharp.text.Image = GetInstance(strPathname)
                    'structures it to fit on pdf file
                    img.ScalePercent(72.0F / img.DpiX * 100)
                    img.SetAbsolutePosition(0, 0)
                    'adds image to the document
                    pdfDoc.Add(img)
                    'closes the pdf and saves it
                    pdfDoc.Close()

                    'messagebox confirmation on saving
                    MessageBox.Show("Save Confirmation", "Saved Cash Receipt PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    'declares list of bmp files to be counted
                    Dim extensions As New List(Of String)
                    extensions.Add("*.bmp")
                    Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

                    GlobalVariables.previousScan = True


                    Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
                    Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                    My.Computer.FileSystem.MoveFile(initial, final)
                    final1 = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
                    name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                    name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"

                    Dim bytecount3 As Integer = 0
                    bytecount3 = FileLen(name1)
                    If bytecount3 < 1001 Then
                        My.Computer.FileSystem.DeleteFile(name1)
                        MsgBox("Scanning Error, Initial File Not Valid, Please Re-Upload File")
                        Exit Sub
                    End If

                    Dim bytecount2 As Integer = 0
                    bytecount2 = FileLen(name2)
                    If bytecount2 < 1001 Then
                        My.Computer.FileSystem.DeleteFile(name2)
                        MsgBox("Scanning Error,Appended File Not Valid, Please Re-Upload File")
                        My.Computer.FileSystem.MoveFile(final, initial)
                        Exit Sub
                    End If

                    Dim pathArray = New String() {name1, name2}
                    Try
                        MergePdfFiles(pathArray, final1)
                        MsgBox("File Appended")
                    Catch ex As Exception
                        MsgBox("File Not Appended")
                    End Try


                Catch ex As TargetInvocationException
                    'We only catch this one, so you can catch other exception later on
                    'We get the inner exception because ex is not helpfull
                    Dim iEX = ex.InnerException
                Catch ex As Exception

                End Try
            End If
            Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
            If File.Exists(CashReceiptExists) Then
                cmdViewReceipt.Enabled = True
            Else
                cmdViewReceipt.Enabled = False
            End If
        Else
            MsgBox("No Initial Upload")
        End If

        Dim bytecount As Integer = 0
        bytecount = FileLen("\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf")
        If bytecount = 15 Then
            My.Computer.FileSystem.DeleteFile("\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf")
            MsgBox("Scanning Error, Please ReUpload File")
        End If

    End Sub

    Private Sub ScanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanToolStripMenuItem1.Click
        reScanCashReceipt()
    End Sub

    'Combo Box Events

    Private Sub cboBatchNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBatchNumber.SelectedIndexChanged
        If isLoaded Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch(lastBatch)
        End If
        Dim W9Exists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"

        If File.Exists(W9Exists) Then
            cmdViewReceipt.Enabled = True
            ReUploadBatchToolStripMenuItem.Enabled = True
            AppendBaToolStripMenuItem.Enabled = True
            cmdUpload.Enabled = False
            cmdScan.Enabled = False
        Else
            cmdViewReceipt.Enabled = False
            ReUploadBatchToolStripMenuItem.Enabled = False
            AppendBaToolStripMenuItem.Enabled = False
            cmdUpload.Enabled = True
            cmdScan.Enabled = True
        End If
        LoadBatchInfo()
        ShowBatchLines()
        LoadTransactionNumber()
        lastBatch = cboBatchNumber.Text
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isLoaded Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch(lastBatch)
        End If

        GlobalARDivisionCode = ""
        GlobalARBatchNumber = 0
        ClearVariables()
        ClearBatch()
        LoadBatchNumber()
        ClearBatchLines()

        If cboBatchNumber.Text = "" Then
            cmdViewReceipt.Enabled = False
            cmdUpload.Enabled = False
            cmdScan.Enabled = False

        End If
    End Sub

    Private Sub cboPaymentID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentID.SelectedIndexChanged
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"

        If File.Exists(CashReceiptExists) Then
            cmdViewReceipt.Enabled = True
        Else
            cmdViewReceipt.Enabled = False
        End If
    End Sub

    Private Sub cboPaymentID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPaymentID.TextChanged
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"

        If File.Exists(CashReceiptExists) Then
            cmdViewReceipt.Enabled = True
        Else
            cmdViewReceipt.Enabled = False
        End If
    End Sub

    'Text Box Events

    Private Sub txtBatchTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBatchTotal.TextChanged
        LoadTotals()
    End Sub

    'Background workers

    Private Sub bgwkPDF_Completed(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim images As List(Of System.Drawing.Image) = CType(e.Result, List(Of System.Drawing.Image))
        Dim TotalPages As Integer = images.Count
        While images.Count > 0
            images(0).Dispose()
            images.RemoveAt(0)
        End While
        If FilesToDelete IsNot Nothing AndAlso FilesToDelete.Count > 0 Then
            For Each filename As String In FilesToDelete
                System.IO.File.Delete(filename)
            Next
        End If
        frm.Enabled = True
        LoadingScreen.Hide()

        MessageBox.Show(TotalPages.ToString + " pages have been scanned.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        frm.TopMost = True
        frm.TopMost = False
    End Sub

    Private Sub bgwk_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Try
            Dim images As List(Of System.Drawing.Image) = CType(e.Argument, List(Of System.Drawing.Image))
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream(dir.FullName + "\" + ShipmentNumber.ToString + ".pdf", System.IO.FileMode.Create)).SetFullCompression()

            doc.Open()
            ''Adds images to the pdf
            For Each img As System.Drawing.Image In images
                Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
                iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
                doc.Add(iImage)
                doc.Add(New iTextSharp.text.Paragraph())
            Next
            doc.Close()

            e.Result = images
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwkAppendPDF_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Try
            Dim images As List(Of System.Drawing.Image) = CType(e.Argument, List(Of System.Drawing.Image))
            ''Creates a memory stream for the document
            Using tempStream As New System.IO.MemoryStream()
                Dim copyDoc As New iTextSharp.text.Document()
                Dim copy As New iTextSharp.text.pdf.PdfCopy(copyDoc, tempStream)
                copyDoc.Open()
                Dim pageCounter As Integer = 0
                Dim reader As New iTextSharp.text.pdf.PdfReader(dir.FullName + "\" + ShipmentNumber.ToString + ".pdf")

                ''Gets pages for the pdf document
                Dim numberOfPages As Integer = reader.NumberOfPages
                For currentPage As Integer = 1 To numberOfPages
                    pageCounter += 1
                    Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                    copy.AddPage(importedPage)
                Next
                copy.FreeReader(reader)
                reader.Close()

                System.IO.File.Delete(dir.FullName + "\" + ShipmentNumber.ToString + ".pdf")
                ''Creates a document in memory of the newly scanned pages
                Dim imageStream As New System.IO.MemoryStream()
                Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, imageStream).SetFullCompression()
                doc.Open()

                ''Adds the image to the pdf page
                For Each img As System.Drawing.Image In images
                    Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
                    iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
                    doc.Add(iImage)
                    doc.Add(New iTextSharp.text.Paragraph())
                Next
                doc.Close()

                ''Merges the newly scanned image document into the current document
                reader = New iTextSharp.text.pdf.PdfReader(imageStream.GetBuffer())
                numberOfPages = reader.NumberOfPages

                For currentPage As Integer = 1 To numberOfPages
                    pageCounter += 1
                    Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                    copy.AddPage(importedPage)
                Next

                copy.FreeReader(reader)
                reader.Close()
                copyDoc.Close()
                imageStream.Close()
                imageStream.Dispose()

                Using fs As New System.IO.FileStream(dir.FullName + "\" + cboPaymentID.Text + ".pdf", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                    fs.Write(tempStream.GetBuffer(), 0, tempStream.GetBuffer().Length)
                End Using
            End Using

            e.Result = images
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwk_Completed(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim images As List(Of System.Drawing.Image) = CType(e.Result, List(Of System.Drawing.Image))
        Dim TotalPages As Integer = images.Count

        While images.Count > 0
            images(0).Dispose()
            images.RemoveAt(0)
        End While

        If FilesToDelete IsNot Nothing AndAlso FilesToDelete.Count > 0 Then
            For Each filename As String In FilesToDelete
                System.IO.File.Delete(filename)
            Next
        End If

        frm.Enabled = True
        LoadingScreen.Hide()

        MessageBox.Show("Cash Batch Uploaded With " + TotalPages.ToString + " pages.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub bgwkRemoteWIA_run(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try
            remoteWIA.StartClient()
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwkRemoteWIA_Progress(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        Select Case e.ProgressPercentage
            Case 0
                LoadingScreen.Label1.Text = "Connecting to local system, please wait."
            Case 1
                LoadingScreen.Label1.Text = "Connected to local system, initializing scan."
            Case 2
                LoadingScreen.Label1.Text = "Attempting to scan, please wait."
            Case 3
                LoadingScreen.Label1.Text = "Waiting on file from local system."
            Case 4
                LoadingScreen.Label1.Text = "File received and being saved."
        End Select
    End Sub

    Private Sub bgwkRemoteWIA_Completed(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            LoadingScreen.Hide()

            If remoteWIA.SaveFile(dir.FullName + "\" + cboBatchNumber.Text + ".pdf") Then
                MessageBox.Show("Cash batch uploaded with " + remoteWIA.PageCount() + " pages successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ErrorDescription = "Scan Error"
                ErrorReferenceNumber = ""

                'Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

                'With cmd.Parameters
                '.Add("@Date", SqlDbType.Date).Value = Today()
                '.Add("@Description", SqlDbType.VarChar).Value = ErrorDescription
                '.Add("@ErrorReference", SqlDbType.VarChar).Value = ErrorReferenceNumber
                '.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                '.Add("@Comment", SqlDbType.VarChar).Value = dir.FullName + "\" + ShipmentNumber.ToString() + ".pdf"
                '.Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
                'End With

                'If con.State = ConnectionState.Closed Then con.Open()
                'cmd.ExecuteNonQuery()
                'con.Close()
            End If

            frm.Enabled = True
            frm.TopMost = True
            frm.TopMost = False
        Catch exception As System.Exception
        End Try
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboBatchNumber.Text + ".pdf"

        If File.Exists(CashReceiptExists) Then
            cmdViewReceipt.Enabled = True
        Else
            cmdViewReceipt.Enabled = False
        End If
    End Sub

    Private Sub bgwkRemoteWIA_CompletedAppend(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            LoadingScreen.Hide()
            Dim final1, name1, name2 As String
            If remoteWIA.SaveFile(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf") Then
                MessageBox.Show("Cash batch uploaded with " + remoteWIA.PageCount() + " pages successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                ErrorDescription = "Scan Error"
                ErrorReferenceNumber = ""

                'Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

                'With cmd.Parameters
                '.Add("@Date", SqlDbType.Date).Value = Today()
                '.Add("@Description", SqlDbType.VarChar).Value = ErrorDescription
                '.Add("@ErrorReference", SqlDbType.VarChar).Value = ErrorReferenceNumber
                '.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                '.Add("@Comment", SqlDbType.VarChar).Value = dir.FullName + "\" + ShipmentNumber.ToString() + ".pdf"
                '.Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
                'End With

                'If con.State = ConnectionState.Closed Then con.Open()
                'cmd.ExecuteNonQuery()
                'con.Close()
            End If
            Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
            Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
            My.Computer.FileSystem.MoveFile(initial, final)

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf") And File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf") Then

                final1 = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
                name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"
                Dim pathArray = New String() {name1, name2}

                MergePdfFiles(pathArray, final1)
            End If
            frm.Enabled = True
            frm.TopMost = True
            frm.TopMost = False
        Catch exception As System.Exception
        End Try
    End Sub

    'Misc routines

    Private Sub DeleteDirectory(ByVal path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
            'Delete all child Directories
            For Each dir As String In Directory.GetDirectories(path)
                DeleteDirectory(dir)
            Next
            'Delete a Directory
            Directory.Delete(path)
        End If
    End Sub

    Public Function canSave() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must enter a batch number", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        ElseIf cboBatchNumber.Text = "" Then
            MessageBox.Show("You must enter a batch number", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Public Sub ScanCashReceipt(Optional ByVal newPDF As Boolean = True)
        remoteScan = False
        If canSave() Then

            ' Deletes the WIA testing temp file
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
            ' Creates the folder if the temp folder is not currently created
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")

            If File.Exists("\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf") Then My.Computer.FileSystem.DeleteFile("\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf")


            path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            'If there had been a previous scan then delete the picture from the picturebox
            GlobalVariables.Counter = 0
            Dim mgr As New WIA.DeviceManagerClass
            Dim Scanner As WIA.Device = Nothing
            If mgr.DeviceInfos.Count > 1 Then
                ''More than 1 scanner was detected
                Dim lst As New List(Of Integer)
                ''Finds all the USB scanners
                For i As Integer = 1 To mgr.DeviceInfos.Count()
                    If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                        lst.Add(i)
                    End If
                Next
                ''Check to see how many usb scanners were found
                If lst.Count > 1 Or lst.Count = 0 Then
                    Dim selectScanner As New WIA.CommonDialog
                    Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
                Else
                    Scanner = mgr.DeviceInfos(lst(0)).Connect()
                End If
            ElseIf mgr.DeviceInfos.Count = 0 Then
                ''No scanners were detected
                If My.Computer.Name.ToString.StartsWith("TFP") Then
                    Dim loadingScreen As New Loading


                    bgwkRemoteWIA = New BackgroundWorker()
                    bgwkRemoteWIA.WorkerReportsProgress = True
                    AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_run
                    AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_Completed
                    AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_Progress
                    remoteScan = True

                    remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, ShipmentNumber)
                    bgwkRemoteWIA.RunWorkerAsync()
                Else
                    ''No scanners were detected
                    MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ''Only 1 scanner is connected
                Scanner = mgr.DeviceInfos(1).Connect()
            End If

            If Scanner IsNot Nothing Then
                Dim item As WIA.Item = Scanner.Items(1)
                Dim obj As Object
                Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
                ''Specific scanning properties
                For Each prop As WIA.Property In Scanner.Items(1).Properties
                    Dim x As WIA.IProperty = prop
                    Select Case prop.PropertyID
                        Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                            obj = 0
                            x.let_Value(obj)
                        Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                            obj = 2
                            x.let_Value(obj)
                        Case "6147" ''(DPI) Horizontal Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6148" ''(DPI) Vertical Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6151" ''horizontal extent (width)
                            obj = 1700
                            x.let_Value(obj)
                        Case "6152" ''vertical extent (height)
                            obj = 2338
                            x.let_Value(obj)
                    End Select
                Next

                Dim dial As New WIA.CommonDialog
                Dim hasMorePages As Boolean = True
                Dim ScannedAtleastOnePage As Boolean = False
                Dim pages As Integer = 0
                Dim ScannedImages As New List(Of iTextSharp.text.Image)

                ''Loops until all pages are scanned.
                While hasMorePages
                    GlobalVariables.Counter = GlobalVariables.Counter + 1
                    pages += 1
                    Try
                        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                        Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                        Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                        Img.SaveFile(tmp)
                        'ScannedImages.Add(Img.fromfile(tmp))
                        ScannedAtleastOnePage = True
                    Catch ex As System.Exception
                        ''Looks for paper empty error to break the loop and/or to show error message
                        If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                            If Not ScannedAtleastOnePage Then
                                MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                GlobalVariables.paperscan = False
                            Else
                                GlobalVariables.paperscan = True
                            End If
                            hasMorePages = False
                        End If
                    End Try
                End While
                If remoteScan = False Then
                    'Displays the first saved scan into the picturebox
                    If GlobalVariables.paperscan Then
                        GlobalVariables.StartCounter = 1
                        Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                        GlobalVariables.NextPrevious = GlobalVariables.StartCounter
                    End If
                End If
            End If
            If remoteScan = False Then
                'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
                GlobalVariables.previousScan = True
                GlobalVariables.NextPrevious = 1

                Dim extensions As New List(Of String)
                extensions.Add("*.bmp")
                Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

                'counts the files in the folder
                Dim fileCount As Integer
                For i As Integer = 0 To extensions.Count - 1
                    fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
                Next
                GlobalVariables.totalfiles = fileCount
            End If
        End If
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
        If remoteScan = False Then
            Try
                UploadCashReceipt()


                If File.Exists(CashReceiptExists) Then
                    cmdViewReceipt.Enabled = True
                    AppendBaToolStripMenuItem.Enabled = True

                Else
                    cmdViewReceipt.Enabled = False
                    AppendBaToolStripMenuItem.Enabled = False

                End If
            Catch ex As TargetInvocationException
                'We only catch this one, so you can catch other exception later on
                'We get the inner exception because ex is not helpfull
                Dim iEX = ex.InnerException
            Catch ex As Exception

            End Try
        End If
        Try
            If File.Exists(CashReceiptExists) Then
                cmdViewReceipt.Enabled = True
                AppendBaToolStripMenuItem.Enabled = True
                ReUploadBatchToolStripMenuItem.Enabled = True

            Else
                cmdViewReceipt.Enabled = False
                AppendBaToolStripMenuItem.Enabled = False
                ReUploadBatchToolStripMenuItem.Enabled = False

            End If
        Catch ex As Exception

        End Try
        'Dim bytecount As Integer = 0
        'bytecount = FileLen("\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf")
        'If bytecount < 1001 Then
        '    My.Computer.FileSystem.DeleteFile("\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf")
        '    MsgBox("Scanning Error, Please Re-Upload File")
        'End If
    End Sub

    Public Sub UploadCashReceipt()
        Try
            Dim boolCheck As Boolean = True
            Dim FilesInFolder As Integer
            Dim FullName As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"
            FilesInFolder = Directory.GetFiles(FullName, "*.bmp").Count


            'Variables Declared
            Dim comboboxSelection As String = cboBatchNumber.Text

            Dim strDir As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\"

            'Dim pdfDoc As New document()

            'Name of file
            Dim strFilename As String = cboBatchNumber.Text + ".pdf"
            Dim pdfDoc As New document()
            Dim i As Integer = 1
            Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
            'path to bmp
            Dim strCompletePath As String = strDir & strFilename
            Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
            pdfDoc.Open()
            'Grabs the bmp image seen on screen
            Dim img As iTextSharp.text.Image = GetInstance(strPathname)
            'structures it to fit on pdf file
            img.ScalePercent(72.0F / img.DpiX * 100)
            img.SetAbsolutePosition(0, 0)
            'adds image to the document
            pdfDoc.Add(img)

            i += 1
            While i <= FilesInFolder
                pdfDoc.NewPage()
                strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
                'path to bmp
                strCompletePath = strDir & strFilename
                'Grabs the bmp image seen on screen
                img = GetInstance(strPathname)
                'structures it to fit on pdf file
                img.ScalePercent(72.0F / img.DpiX * 100)
                img.SetAbsolutePosition(0, 0)
                'adds image to the document
                pdfDoc.Add(img)
                i += 1
            End While
            pdfDoc.Close()
        Catch exe As System.Exception
        End Try

    End Sub

    Public Shared Function MergePdfFiles(ByVal pdfFiles() As String, ByVal outputPath As String) As Boolean
        Dim result As Boolean = False
        Dim pdfCount As Integer = 0     'total input pdf file count
        Dim f As Integer = 0    'pointer to current input pdf file
        Dim fileName As String
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim pageCount As Integer = 0
        Dim pdfDoc As iTextSharp.text.Document = Nothing    'the output pdf document
        Dim writer As PdfWriter = Nothing
        Dim cb As PdfContentByte = Nothing

        Dim page As PdfImportedPage = Nothing
        Dim rotation As Integer = 0

        Try
            pdfCount = pdfFiles.Length
            If pdfCount > 1 Then
                'Open the 1st item in the array PDFFiles
                fileName = pdfFiles(f)
                reader = New iTextSharp.text.pdf.PdfReader(fileName)
                'Get page count
                pageCount = reader.NumberOfPages

                pdfDoc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1), 18, 18, 18, 18)

                writer = PdfWriter.GetInstance(pdfDoc, New FileStream(outputPath, FileMode.OpenOrCreate))


                With pdfDoc
                    .Open()
                End With
                'Instantiate a PdfContentByte object
                cb = writer.DirectContent
                'Now loop thru the input pdfs
                While f < pdfCount
                    'Declare a page counter variable
                    Dim i As Integer = 0
                    'Loop thru the current input pdf's pages starting at page 1
                    While i < pageCount
                        i += 1
                        'Get the input page size
                        pdfDoc.SetPageSize(reader.GetPageSizeWithRotation(i))
                        'Create a new page on the output document
                        pdfDoc.NewPage()
                        'If it is the 1st page, we add bookmarks to the page
                        'Now we get the imported page
                        page = writer.GetImportedPage(reader, i)
                        'Read the imported page's rotation
                        rotation = reader.GetPageRotation(i)
                        'Then add the imported page to the PdfContentByte object as a template based on the page's rotation
                        If rotation = 90 Then
                            cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(i).Height)
                        ElseIf rotation = 270 Then
                            cb.AddTemplate(page, 0, 1.0F, -1.0F, 0, reader.GetPageSizeWithRotation(i).Width + 60, -30)
                        Else
                            cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0)
                        End If
                    End While
                    'Increment f and read the next input pdf file
                    f += 1
                    If f < pdfCount Then
                        fileName = pdfFiles(f)
                        reader = New iTextSharp.text.pdf.PdfReader(fileName)
                        pageCount = reader.NumberOfPages
                    End If
                End While
                'When all done, we close the document so that the pdfwriter object can write it to the output file
                pdfDoc.Close()
                result = True
            End If
        Catch ex As Exception
            Return False
        End Try
        Return result
    End Function

    Public Sub reScanCashReceipt(Optional ByVal newPDF As Boolean = True)
        remoteScan = False
        If canSave() Then

            ' Deletes the WIA testing temp file
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
            ' Creates the folder if the temp folder is not currently created
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
            If File.Exists("\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf") Then My.Computer.FileSystem.DeleteFile("\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf")

            path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            'If there had been a previous scan then delete the picture from the picturebox
            GlobalVariables.Counter = 0
            Dim mgr As New WIA.DeviceManagerClass
            Dim Scanner As WIA.Device = Nothing
            If mgr.DeviceInfos.Count > 1 Then
                ''More than 1 scanner was detected
                Dim lst As New List(Of Integer)
                ''Finds all the USB scanners
                For i As Integer = 1 To mgr.DeviceInfos.Count()
                    If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                        lst.Add(i)
                    End If
                Next
                ''Check to see how many usb scanners were found
                If lst.Count > 1 Or lst.Count = 0 Then
                    Dim selectScanner As New WIA.CommonDialog
                    Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
                Else
                    Scanner = mgr.DeviceInfos(lst(0)).Connect()
                End If
            ElseIf mgr.DeviceInfos.Count = 0 Then
                ''No scanners were detected
                If My.Computer.Name.ToString.StartsWith("TFP") Then
                    Dim loadingScreen As New Loading


                    bgwkRemoteWIA = New BackgroundWorker()
                    bgwkRemoteWIA.WorkerReportsProgress = True
                    AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_run
                    AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_Completed
                    AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_Progress
                    remoteScan = True

                    remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, ShipmentNumber)
                    bgwkRemoteWIA.RunWorkerAsync()
                Else
                    ''No scanners were detected
                    MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ''Only 1 scanner is connected
                Scanner = mgr.DeviceInfos(1).Connect()
            End If

            If Scanner IsNot Nothing Then
                Dim item As WIA.Item = Scanner.Items(1)
                Dim obj As Object
                Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
                ''Specific scanning properties
                For Each prop As WIA.Property In Scanner.Items(1).Properties
                    Dim x As WIA.IProperty = prop
                    Select Case prop.PropertyID
                        Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                            obj = 0
                            x.let_Value(obj)
                        Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                            obj = 2
                            x.let_Value(obj)
                        Case "6147" ''(DPI) Horizontal Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6148" ''(DPI) Vertical Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6151" ''horizontal extent (width)
                            obj = 1700
                            x.let_Value(obj)
                        Case "6152" ''vertical extent (height)
                            obj = 2338
                            x.let_Value(obj)
                    End Select
                Next

                Dim dial As New WIA.CommonDialog
                Dim hasMorePages As Boolean = True
                Dim ScannedAtleastOnePage As Boolean = False
                Dim pages As Integer = 0
                Dim ScannedImages As New List(Of iTextSharp.text.Image)

                ''Loops until all pages are scanned.
                While hasMorePages
                    GlobalVariables.Counter = GlobalVariables.Counter + 1
                    pages += 1
                    Try
                        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                        Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                        Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                        Img.SaveFile(tmp)
                        'ScannedImages.Add(Img.fromfile(tmp))
                        ScannedAtleastOnePage = True
                    Catch ex As System.Exception
                        ''Looks for paper empty error to break the loop and/or to show error message
                        If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                            If Not ScannedAtleastOnePage Then
                                MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                GlobalVariables.paperscan = False
                            Else
                                GlobalVariables.paperscan = True
                            End If
                            hasMorePages = False
                        End If
                    End Try
                End While
                If remoteScan = False Then
                    'Displays the first saved scan into the picturebox
                    If GlobalVariables.paperscan Then
                        GlobalVariables.StartCounter = 1
                        Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                        GlobalVariables.NextPrevious = GlobalVariables.StartCounter
                    End If
                End If
            End If
            If remoteScan = False Then
                'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
                GlobalVariables.previousScan = True
                GlobalVariables.NextPrevious = 1

                Dim extensions As New List(Of String)
                extensions.Add("*.bmp")
                Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

                'counts the files in the folder
                Dim fileCount As Integer
                For i As Integer = 0 To extensions.Count - 1
                    fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
                Next
                GlobalVariables.totalfiles = fileCount
            End If
        End If
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf"
        If remoteScan = False Then
            Try
                UploadCashReceipt()


                If File.Exists(CashReceiptExists) Then
                    cmdViewReceipt.Enabled = True
                    AppendBaToolStripMenuItem.Enabled = True

                Else
                    cmdViewReceipt.Enabled = False
                    AppendBaToolStripMenuItem.Enabled = False

                End If
            Catch ex As TargetInvocationException
                'We only catch this one, so you can catch other exception later on
                'We get the inner exception because ex is not helpfull
                Dim iEX = ex.InnerException
            Catch ex As Exception

            End Try
        End If
        Try
            If File.Exists(CashReceiptExists) Then
                cmdViewReceipt.Enabled = True
                AppendBaToolStripMenuItem.Enabled = True
                ReUploadBatchToolStripMenuItem.Enabled = True

            Else
                cmdViewReceipt.Enabled = False
                AppendBaToolStripMenuItem.Enabled = False
                ReUploadBatchToolStripMenuItem.Enabled = False

            End If
        Catch ex As Exception

        End Try
        Dim bytecount As Integer = 0
        bytecount = FileLen("\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf")
        If bytecount < 1001 Then
            My.Computer.FileSystem.DeleteFile("\\TFP-FS\CashReceipts\UploadedCashBatch\" + cboBatchNumber.Text + ".pdf")
            MsgBox("Scanning Error, Please Re-Upload File")
        End If
    End Sub



End Class