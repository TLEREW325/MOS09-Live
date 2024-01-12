Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class APProcessBatch
    Inherits System.Windows.Forms.Form

    Dim GetPOLineNumber, GetReceiverNumber, GetReceiverLine, CountVoucherLines, CheckReceiver, VoucherNumber, ReceiverNumber, NegativeConversion, UpdateLines, counter, LastBatchNumber, NextBatchNumber, CountLineNumber, PostingLineNumber As Integer
    Dim SalesTaxCreditAccount, SalesTaxDebitAccount, FreightDebitAccount, FreightCreditAccount, VendorClass, VoucherSource, CheckBatchStatus, CheckVoucherStatus, BatchStatus, BatchDate, BatchDescription, VoucherPartNumber As String
    Dim SumPOExtendedAmount, SumBatch, BatchAmount, UndistributedAmount, UpdateTotals As Double
    Dim ReceiverQuantityOpen, VoucherQuantityReceived, ExtendedAmount, ReceiverUnitCost, ReceiverExtendedCost, CostAdjustmentAmount, VoucherExtendedAmount, VoucherUnitCost As Double
    Dim GLCreditAccount, GLDebitAccount, ReceiverDebitAccount, ReceiverCreditAccount As String
    Dim VoucherReceiverNumber, VoucherReceiverLine, DeleteReferenceNumber As Integer

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim isloaded As Boolean = False
    Dim lastBatch As String = ""

    Private Sub APProcessBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Call Disable(Me)

        If EmployeeSecurityCode > 1002 Then
            UnLockBatchToolStripMenuItem.Visible = False
        End If

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" And GlobalAPDivisionID = "" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        ElseIf EmployeeCompanyCode = "ADM" And GlobalAPDivisionID <> "" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = GlobalAPDivisionID
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            ManuallyCloseBatchToolStripMenuItem.Enabled = True
        Else
            ManuallyCloseBatchToolStripMenuItem.Enabled = False
        End If

        'Load defaults
        LoadBatchNumber()
        ClearBatch()
        isloaded = True

        If GlobalAPBatchNumber > 0 Then
            cboBatchNumber.Text = GlobalAPBatchNumber
            LoadTotals()
            LoadBatchInfo()
            ShowBatchLines()
            LoadOpenBatches()
        Else
            cboBatchNumber.SelectedIndex = -1
            ShowBatchLines()
            LoadOpenBatches()
        End If
    End Sub

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFJ"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFJ'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Public Sub LoadBatchNumber()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT BatchNumber FROM ReceiptOfInvoiceBatchHeader WHERE DivisionID = @DivisionID AND BatchStatus = @BatchStatus", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceiptOfInvoiceBatchHeader")
        cboBatchNumber.DataSource = ds.Tables("ReceiptOfInvoiceBatchHeader")
        con.Close()
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub ShowBatchLines()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID ORDER BY VendorID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ReceiptOfInvoiceBatchLine")
        dgvBatchItems.DataSource = ds1.Tables("ReceiptOfInvoiceBatchLine")
        con.Close()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length > 399 Then
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

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

    Public Sub LoadOpenBatches()
        Dim OpenBatches As Integer = 0
        Dim strOpenBatches As String = ""

        Dim OpenBatchesStatement As String = "SELECT Count(BatchNumber) FROM ReceiptOfInvoiceBatchHeader WHERE BatchStatus = @BatchStatus AND DivisionID = @DivisionID"
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

        strOpenBatches = CStr(OpenBatches)

        If OpenBatches = 0 Then
            lblOpenBatches.Text = "There are no open batches waiting to be processed."
        ElseIf OpenBatches = 1 Then
            lblOpenBatches.Text = "There is one batch waiting to be processed."
        Else
            lblOpenBatches.Text = "There are " + strOpenBatches + " waiting to be processed."
        End If
    End Sub

    Public Sub LoadBatchInfo()
        'Load the Batch Totals
        Dim BatchDateStatement As String = "SELECT BatchDate FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchDateCommand As New SqlCommand(BatchDateStatement, con)
        BatchDateCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchAmountStatement As String = "SELECT BatchAmount FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchAmountCommand As New SqlCommand(BatchAmountStatement, con)
        BatchAmountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchDescriptionStatement As String = "SELECT BatchDescription FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchDescriptionCommand As New SqlCommand(BatchDescriptionStatement, con)
        BatchDescriptionCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchDate = CStr(BatchDateCommand.ExecuteScalar)
        Catch ex As Exception
            BatchDate = ""
        End Try
        Try
            BatchAmount = CDbl(BatchAmountCommand.ExecuteScalar)
        Catch ex As Exception
            BatchAmount = 0
        End Try
        Try
            BatchDescription = CStr(BatchDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            BatchDescription = "Receipt Of Invoice Batch"
        End Try
        Try
            BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            BatchStatus = "OPEN"
        End Try
        con.Close()

        If BatchDescription = "" Then
            BatchDescription = "Receipt Of Invoice Batch"
        End If

        dtpBatchCreationDate.Text = BatchDate
        txtBatchTotal.Text = BatchAmount
        txtBatchDescription.Text = BatchDescription
        txtBatchStatus.Text = BatchStatus

        If BatchStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdPostBatch.Enabled = False
            cmdSave.Enabled = False
            SaveBatchToolStripMenuItem.Enabled = False
            DeleteBatchToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdPostBatch.Enabled = True
            cmdSave.Enabled = True
            SaveBatchToolStripMenuItem.Enabled = True
            DeleteBatchToolStripMenuItem.Enabled = True
        End If
    End Sub

    Public Sub ClearBatch()
        cboBatchNumber.Text = ""
        cboBatchNumber.Refresh()
        cboBatchNumber.SelectedIndex = -1

        dtpBatchCreationDate.Text = Today()

        txtBatchDescription.Refresh()
        txtBatchTotal.Refresh()
        txtCurrentTotal.Refresh()
        txtEntryNumber.Refresh()
        txtUndistributedAmount.Refresh()
        txtBatchStatus.Refresh()

        txtBatchTotal.Clear()
        txtCurrentTotal.Clear()
        txtUndistributedAmount.Clear()
        txtEntryNumber.Clear()
        txtBatchStatus.Clear()
        txtBatchDescription.Text = "RECEIPT OF INVOICE"

        cmdDelete.Enabled = True
        cmdPostBatch.Enabled = True
        cmdSave.Enabled = True
        SaveBatchToolStripMenuItem.Enabled = True
        DeleteBatchToolStripMenuItem.Enabled = True

        LoadOpenBatches()
        cmdGenerateBatchNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        UpdateLines = 0
        counter = 0
        LastBatchNumber = 0
        NextBatchNumber = 0
        CountLineNumber = 0
        PostingLineNumber = 0
        BatchStatus = ""
        BatchDate = ""
        BatchDescription = ""
        BatchAmount = 0
        UndistributedAmount = 0
        UpdateTotals = 0
        ExtendedAmount = 0
        GLCreditAccount = ""
        GLDebitAccount = ""
        ReceiverNumber = 0
        CostAdjustmentAmount = 0
        VoucherPartNumber = ""
        VoucherQuantityReceived = 0
        ReceiverExtendedCost = 0
        ReceiverUnitCost = 0
        VoucherExtendedAmount = 0
        VoucherUnitCost = 0
        ReceiverDebitAccount = ""
        ReceiverCreditAccount = ""
        VoucherReceiverNumber = 0
        VoucherReceiverLine = 0
        ReceiverQuantityOpen = 0
        CheckBatchStatus = ""
        CheckVoucherStatus = ""
        VoucherSource = ""
        VendorClass = ""
        FreightDebitAccount = ""
        FreightCreditAccount = ""
        SalesTaxCreditAccount = ""
        SalesTaxDebitAccount = ""
        GetPOLineNumber = 0
        SumPOExtendedAmount = 0
    End Sub

    Public Sub LoadTotals()
        'UPDATE TOTALS AND DISTRIBUTABLE AMOUNT
        Dim BatchAmountStatement As String = "SELECT BatchAmount FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchAmountCommand As New SqlCommand(BatchAmountStatement, con)
        BatchAmountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim UpdateTotalsStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim UpdateTotalsCommand As New SqlCommand(UpdateTotalsStatement, con)
        UpdateTotalsCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        UpdateTotalsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim UpdateLinesStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim UpdateLinesCommand As New SqlCommand(UpdateLinesStatement, con)
        UpdateLinesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        UpdateLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchAmount = CDbl(BatchAmountCommand.ExecuteScalar)
        Catch ex As Exception
            BatchAmount = Val(txtBatchTotal.Text)
        End Try
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
        UndistributedAmount = BatchAmount - UpdateTotals
        txtBatchTotal.Text = BatchAmount
        txtCurrentTotal.Text = FormatCurrency(UpdateTotals, 2)
        txtUndistributedAmount.Text = FormatCurrency(UndistributedAmount, 2)
        txtEntryNumber.Text = UpdateLines
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        ''unlocks the batch if the user is the one that has it locked
        unlockBatch()
        ClearVariables()
        ClearBatch()
        LoadBatchNumber()
        ShowBatchLines()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isloaded Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch(lastBatch)
        End If
        'Load defaults
        ClearVariables()
        ClearBatch()
        LoadBatchNumber()
        ShowBatchLines()
        checkRecurringToAdd()
    End Sub

    Private Sub cboBatchNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBatchNumber.SelectedIndexChanged
        If isloaded Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch(lastBatch)
        End If
        LoadBatchInfo()
        ShowBatchLines()
        LoadTotals()
        LoadOpenBatches()
        lastBatch = cboBatchNumber.Text
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch()
        End If
        ClearVariables()
        ClearBatch()
        LoadBatchNumber()
        ShowBatchLines()
    End Sub

    Private Sub cmdGenerateBatchNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateBatchNumber.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch(lastBatch)
        End If

        'Clear form for new batch number
        ClearVariables()
        ClearBatch()
        ShowBatchLines()

        'Find the next Batch Number to use
        Dim MAX1Statement As String = "SELECT MAX(BatchNumber) FROM ReceiptOfInvoiceBatchHeader"
        Dim MAX1Command As New SqlCommand(MAX1Statement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(MAX1Command.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 2200000
        End Try
        con.Close()

        NextBatchNumber = LastBatchNumber + 1
        cboBatchNumber.Text = NextBatchNumber

        Try
            'Write Data to Batch Header Database Table
            cmd = New SqlCommand("Insert Into ReceiptOfInvoiceBatchHeader(BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID)Values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID)", con)

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
            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Generate Batch Number --- Update Batch Table"
            ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        'Load Batch Info
        LoadBatchInfo()
        LoadOpenBatches()
    End Sub

    Private Sub cmdOpenReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenReturn.Click
        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else

            'Check Batch Status
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "POSTED"
            End Try
            con.Close()

            If BatchStatus = "POSTED" Or BatchStatus = "CLOSED" Then
                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalAPDivisionID = cboDivisionID.Text

                Dim NewAPProcessReturns As New APProcessReturns
                NewAPProcessReturns.Show()

                Me.Dispose()
                Me.Close()
            Else
                ''check to see if this batch is being edited by someone else
                If isSomeoneEditing() Then
                    Exit Sub
                End If
                Try
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, Locked = @Locked WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Save Open Return --- Update Batch Table"
                    ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalAPDivisionID = cboDivisionID.Text

                Dim NewAPProcessReturns As New APProcessReturns
                NewAPProcessReturns.Show()

                isloaded = False

                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cmdOpenAPVoucherForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenAPVoucherForm.Click
        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            'Check Batch Status
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "POSTED"
            End Try
            con.Close()

            If BatchStatus = "POSTED" Or BatchStatus = "CLOSED" Then
                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalAPDivisionID = cboDivisionID.Text

                Dim NewAPProcessVouchers As New APProcessVouchers
                NewAPProcessVouchers.Show()

                Me.Dispose()
                Me.Close()
            Else
                ''check to see if this batch is being edited by someone else
                If isSomeoneEditing() Then
                    Exit Sub
                End If
                Try
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, Locked = @Locked WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Save AP Voucher --- Update Batch Table"
                    ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalAPDivisionID = cboDivisionID.Text

                Dim NewAPProcessVouchers As New APProcessVouchers
                NewAPProcessVouchers.Show()

                isloaded = False

                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cmdOpenAPPOForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenAPPOForm.Click
        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            'Check Batch Status
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "POSTED"
            End Try
            con.Close()

            If BatchStatus = "POSTED" Or BatchStatus = "CLOSED" Then
                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalAPDivisionID = cboDivisionID.Text

                Dim NewAPReceiptOfInvoice As New APReceiptOfInvoice
                NewAPReceiptOfInvoice.Show()

                Me.Dispose()
                Me.Close()
            Else
                ''check to see if this batch is being edited by someone else
                If isSomeoneEditing() Then
                    Exit Sub
                End If

                Try
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, Locked = @Locked WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Save AP PO --- Update Batch Table"
                    ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalAPDivisionID = cboDivisionID.Text

                Dim NewAPReceiptOfInvoice As New APReceiptOfInvoice
                NewAPReceiptOfInvoice.Show()

                isloaded = False

                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cmdSteelBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSteelBOL.Click
        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            'Check Batch Status
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "POSTED"
            End Try
            con.Close()

            If BatchStatus <> "POSTED" And BatchStatus <> "CLOSED" Then
                ''check to see if this batch is being edited by someone else
                If isSomeoneEditing() Then
                    Exit Sub
                End If
                Try
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, Locked = @Locked WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Save Steel BOL --- Update Batch Table"
                    ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If

            GlobalAPBatchNumber = Val(cboBatchNumber.Text)
            GlobalAPDivisionID = cboDivisionID.Text

            Dim NewAPProcessSteelReceipts As New APProcessSteelReceipts()
            NewAPProcessSteelReceipts.Show()

            isloaded = False

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub cmdPostBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostBatch.Click
        ''check to see if this batch is being edited by someone else
        If isSomeoneEditing() Then
            Exit Sub
        End If
        '*****************************************************************************************************************
        'Check to see if any vouchers in the batch are already posted in the GL
        'If so, Exit Sub and log error.
        For Each row2 As DataGridViewRow In dgvBatchItems.Rows
            Dim VoucherNumber As Integer = 0
            Dim CountPostedVouchers As Integer = 0

            'Extract row data from the datagrid - one row at a time
            Try
                VoucherNumber = row2.Cells("VoucherNumberColumn").Value
            Catch ex As Exception
                VoucherNumber = 0
            End Try

            'Count voucher lines
            Dim CountVoucherLines As Integer = 0

            Dim CountVoucherLinesStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
            Dim CountVoucherLinesCommand As New SqlCommand(CountVoucherLinesStatement, con)
            CountVoucherLinesCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
            CountVoucherLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountVoucherLines = CInt(CountVoucherLinesCommand.ExecuteScalar)
            Catch ex As Exception
                CountVoucherLines = 0
            End Try
            con.Close()

            If CountVoucherLines = 0 Then
                MsgBox("One or more Vouchers in this batch has no line items.", MsgBoxStyle.OkOnly)
                'Error Log
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                Dim strVoucherNumber As String = "'"
                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)
                strVoucherNumber = CStr(VoucherNumber)

                ErrorDate = Today()
                ErrorComment = "Voucher has no line items -- " + strVoucherNumber
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Post AP Batch --- Check Voucher Lines"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                Exit Sub
            End If

            'Check Each Voucher to see if it is already posted
            Dim CountPostedVouchersStatement As String = "SELECT COUNT(GLTransactionKey) FROM GLTransactionMasterList WHERE GLBatchNumber = @GLBatchNumber AND GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID"
            Dim CountPostedVouchersCommand As New SqlCommand(CountPostedVouchersStatement, con)
            CountPostedVouchersCommand.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            CountPostedVouchersCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
            CountPostedVouchersCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountPostedVouchers = CInt(CountPostedVouchersCommand.ExecuteScalar)
            Catch ex As Exception
                CountPostedVouchers = 0
            End Try
            con.Close()

            If CountPostedVouchers > 0 Then
                MsgBox("One or more Vouchers in this batch has already been posted.", MsgBoxStyle.OkOnly)
                'Error Log
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                Dim strVoucherNumber As String = "'"
                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)
                strVoucherNumber = CStr(VoucherNumber)

                ErrorDate = Today()
                ErrorComment = "Voucher is already posted -- " + strVoucherNumber
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Post AP Batch --- Check Vouchers in GL"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                Exit Sub
            End If
        Next
        '*****************************************************************************************************************
        'Check if Batch is posted
        Dim CheckBatchStatusStatement As String = "SELECT BatchStatus FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim CheckBatchStatusCommand As New SqlCommand(CheckBatchStatusStatement, con)
        CheckBatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        CheckBatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckBatchStatus = CStr(CheckBatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            CheckBatchStatus = "POSTED"
        End Try
        con.Close()
        '**************************************************************************************************************
        If cboBatchNumber.Text = "" Or CheckBatchStatus <> "OPEN" Then
            MsgBox("You must have a valid Batch Number selected and Batch has to be open", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
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
            Try
                'Load Batch Totals
                LoadTotals()
                '**************************************************************************************************************
                Try
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex9 As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = Today()
                    ErrorComment = ex9.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Post AP Batch --- Update Batch Status - ROI Batch Header"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '**************************************************************************************************************
                'Retrieve Receipt Of Invoice Numbers to Post to General Ledger
                For Each row As DataGridViewRow In dgvBatchItems.Rows
                    Dim VoucherNumber, PONumber As Integer
                    Dim InvoiceFreight, InvoiceSalesTax, ProductTotal, InvoiceTotal, DiscountAmount, InvoiceAmount As Double
                    Dim VoucherStatus, InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, PaymentTerms, DiscountDate, Comment, DueDate, VoucherSource As String

                    'Extract row data from the datagrid - one row at a time
                    Try
                        VoucherNumber = row.Cells("VoucherNumberColumn").Value
                    Catch ex As Exception
                        VoucherNumber = 0
                    End Try
                    Try
                        InvoiceFreight = row.Cells("InvoiceFreightColumn").Value
                    Catch ex As Exception
                        InvoiceFreight = 0
                    End Try
                    Try
                        InvoiceSalesTax = row.Cells("InvoiceSalesTaxColumn").Value
                    Catch ex As Exception
                        InvoiceSalesTax = 0
                    End Try
                    Try
                        InvoiceTotal = row.Cells("InvoiceTotalColumn").Value
                    Catch ex As Exception
                        InvoiceTotal = 0
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
                        ProductTotal = row.Cells("ProductTotalColumn").Value
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    Try
                        PONumber = row.Cells("PONumberColumn").Value
                    Catch ex As Exception
                        PONumber = 0
                    End Try
                    Try
                        InvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                    Catch ex As Exception
                        InvoiceNumber = ""
                    End Try
                    Try
                        VendorID = row.Cells("VendorIDColumn").Value
                    Catch ex As Exception
                        VendorID = ""
                    End Try
                    Try
                        PaymentTerms = row.Cells("PaymentTermsColumn").Value
                    Catch ex As Exception
                        PaymentTerms = "N30"
                    End Try
                    Try
                        Comment = row.Cells("CommentColumn").Value
                    Catch ex As Exception
                        Comment = ""
                    End Try
                    Try
                        InvoiceDate = row.Cells("InvoiceDateColumn").Value
                    Catch ex As Exception
                        InvoiceDate = ""
                    End Try
                    Try
                        ReceiptDate = row.Cells("ReceiptDateColumn").Value
                    Catch ex As Exception
                        ReceiptDate = ""
                    End Try
                    Try
                        DueDate = row.Cells("DueDateColumn").Value
                    Catch ex As Exception
                        DueDate = ""
                    End Try
                    Try
                        DiscountDate = row.Cells("DiscountDateColumn").Value
                    Catch ex As Exception
                        DiscountDate = ""
                    End Try
                    Try
                        VoucherSource = row.Cells("VoucherSourceColumn").Value
                    Catch ex As Exception
                        VoucherSource = ""
                    End Try
                    Try
                        DeleteReferenceNumber = row.Cells("DeleteReferenceNumberColumn").Value
                    Catch ex As Exception
                        DeleteReferenceNumber = 0
                    End Try
                    Try
                        VoucherStatus = row.Cells("VoucherStatusColumn").Value
                    Catch ex As Exception
                        VoucherStatus = "OPEN"
                    End Try
                    Try
                        VendorClass = row.Cells("VendorClassColumn").Value
                    Catch ex As Exception
                        VendorClass = ""
                    End Try

                    'Set Receiver Number as default from voucher -- could be receiver or vendor return
                    ReceiverNumber = DeleteReferenceNumber

                    'Round variables to two decimals
                    InvoiceFreight = Math.Round(InvoiceFreight, 2)
                    InvoiceSalesTax = Math.Round(InvoiceSalesTax, 2)
                    InvoiceTotal = Math.Round(InvoiceTotal, 2)
                    DiscountAmount = Math.Round(DiscountAmount, 2)
                    ProductTotal = Math.Round(ProductTotal, 2)
                    InvoiceAmount = Math.Round(InvoiceAmount, 2)
                    '**************************************************************************************************************
                    Try
                        'UPDATE the Status of the Voucher
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex8 As Exception
                        'Log error on update failure
                        Dim TempVoucherNumber As Integer = 0
                        Dim strVoucherNumber As String
                        TempVoucherNumber = VoucherNumber
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = Today()
                        ErrorComment = ex8.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Post AP Batch --- Update Voucher Status - ROI Batch Lines"
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '**************************************************************************************************************
                    'Find the number of Voucher Lines for each voucher
                    Dim CountLineStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                    Dim CountLineCommand As New SqlCommand(CountLineStatement, con)
                    CountLineCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountLineNumber = CInt(CountLineCommand.ExecuteScalar)
                    Catch ex As Exception
                        CountLineNumber = 1
                    End Try
                    con.Close()

                    PostingLineNumber = 1

                    For i As Integer = 1 To CountLineNumber
                        Dim GLDebitAccountStatement As String = "SELECT GLDebitAccount FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                        Dim GLDebitAccountCommand As New SqlCommand(GLDebitAccountStatement, con)
                        GLDebitAccountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        GLDebitAccountCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = PostingLineNumber

                        Dim GLCreditAccountStatement As String = "SELECT GLCreditAccount FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                        Dim GLCreditAccountCommand As New SqlCommand(GLCreditAccountStatement, con)
                        GLCreditAccountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        GLCreditAccountCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = PostingLineNumber

                        Dim VoucherPartNumberStatement As String = "SELECT PartNumber FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                        Dim VoucherPartNumberCommand As New SqlCommand(VoucherPartNumberStatement, con)
                        VoucherPartNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        VoucherPartNumberCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = PostingLineNumber

                        Dim VoucherQuantityReceivedStatement As String = "SELECT Quantity FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                        Dim VoucherQuantityReceivedCommand As New SqlCommand(VoucherQuantityReceivedStatement, con)
                        VoucherQuantityReceivedCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        VoucherQuantityReceivedCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = PostingLineNumber

                        Dim VoucherExtendedAmountStatement As String = "SELECT ExtendedAmount FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                        Dim VoucherExtendedAmountCommand As New SqlCommand(VoucherExtendedAmountStatement, con)
                        VoucherExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        VoucherExtendedAmountCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = PostingLineNumber

                        Dim VoucherUnitCostStatement As String = "SELECT UnitCost FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                        Dim VoucherUnitCostCommand As New SqlCommand(VoucherUnitCostStatement, con)
                        VoucherUnitCostCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        VoucherUnitCostCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = PostingLineNumber

                        Dim VoucherReceiverNumberStatement As String = "SELECT ReceiverNumber FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                        Dim VoucherReceiverNumberCommand As New SqlCommand(VoucherReceiverNumberStatement, con)
                        VoucherReceiverNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        VoucherReceiverNumberCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = PostingLineNumber

                        Dim VoucherReceiverLineStatement As String = "SELECT ReceiverLine FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                        Dim VoucherReceiverLineCommand As New SqlCommand(VoucherReceiverLineStatement, con)
                        VoucherReceiverLineCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        VoucherReceiverLineCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = PostingLineNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GLDebitAccount = CStr(GLDebitAccountCommand.ExecuteScalar)
                        Catch ex As Exception
                            GLDebitAccount = "20999" 'Purchase Clearing
                        End Try
                        Try
                            GLCreditAccount = CStr(GLCreditAccountCommand.ExecuteScalar)
                        Catch ex As Exception
                            GLCreditAccount = "20000" 'Accounts Payable
                        End Try
                        Try
                            VoucherPartNumber = CStr(VoucherPartNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            VoucherPartNumber = ""
                        End Try
                        Try
                            VoucherQuantityReceived = CDbl(VoucherQuantityReceivedCommand.ExecuteScalar)
                        Catch ex As Exception
                            VoucherQuantityReceived = 0
                        End Try
                        Try
                            VoucherExtendedAmount = CDbl(VoucherExtendedAmountCommand.ExecuteScalar)
                        Catch ex As Exception
                            VoucherExtendedAmount = 0
                        End Try
                        Try
                            VoucherUnitCost = CDbl(VoucherUnitCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            VoucherUnitCost = 0
                        End Try
                        Try
                            VoucherReceiverNumber = CInt(VoucherReceiverNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            VoucherReceiverNumber = 0
                        End Try
                        Try
                            VoucherReceiverLine = CInt(VoucherReceiverLineCommand.ExecuteScalar)
                        Catch ex As Exception
                            VoucherReceiverLine = 0
                        End Try
                        con.Close()
                        '*************************************************************************************************************
                        'Enter as positive and reverse GL Accounts for a credit
                        Dim NewGLDebitAccount As String = ""
                        Dim NewGLCreditAccount As String = ""

                        If VoucherExtendedAmount < 0 And VoucherSource = "VOUCHER RECEIPT" Then
                            'Flip the accounts
                            NewGLDebitAccount = GLCreditAccount
                            NewGLCreditAccount = GLDebitAccount
                            GLDebitAccount = NewGLDebitAccount
                            GLCreditAccount = NewGLCreditAccount
                            'Convert negative to positive
                            VoucherExtendedAmount = VoucherExtendedAmount * -1
                        ElseIf VoucherExtendedAmount < 0 And VoucherSource = "VENDOR RETURN" Then
                            'Convert negative to positive
                            VoucherExtendedAmount = VoucherExtendedAmount * -1
                        ElseIf VoucherExtendedAmount > 0 And VoucherSource = "VENDOR RETURN" Then
                            'Flip accounts, but do not convert
                            NewGLDebitAccount = GLCreditAccount
                            NewGLCreditAccount = GLDebitAccount
                            GLDebitAccount = NewGLDebitAccount
                            GLCreditAccount = NewGLCreditAccount
                        ElseIf VoucherExtendedAmount < 0 And VoucherSource = "PO RECEIPT" Then
                            'Flip the accounts
                            NewGLDebitAccount = GLCreditAccount
                            NewGLCreditAccount = GLDebitAccount
                            GLDebitAccount = NewGLDebitAccount
                            GLCreditAccount = NewGLCreditAccount
                            'Convert negative to positive
                            VoucherExtendedAmount = VoucherExtendedAmount * -1
                        ElseIf VoucherExtendedAmount < 0 And VoucherSource = "STEEL VENDOR RETURN" Then
                            'Flip the accounts
                            NewGLDebitAccount = GLCreditAccount
                            NewGLCreditAccount = GLDebitAccount
                            GLDebitAccount = NewGLDebitAccount
                            GLCreditAccount = NewGLCreditAccount
                            VoucherExtendedAmount = VoucherExtendedAmount * -1
                        ElseIf VoucherExtendedAmount > 0 And VoucherSource = "STEEL VENDOR RETURN" Then
                            ''for steel venfor returns if positive, flips the accounts
                            NewGLDebitAccount = GLCreditAccount
                            NewGLCreditAccount = GLDebitAccount
                            GLDebitAccount = NewGLDebitAccount
                            GLCreditAccount = NewGLCreditAccount
                        Else
                            'Do nothing
                            'Positive PO RECIEPT and Positive VOUCHER RECEIPT work correctly
                        End If
                        '*************************************************************************************************************
                        'If division is Canadian, convert GL Account to canadian where applicable
                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then '
                            GLDebitAccount = "C$" & GLDebitAccount
                            GLCreditAccount = "C$" & GLCreditAccount
                        Else
                            'Do nothing - Vendor Class not needed
                        End If
                        '*************************************************************************************************************
                        'Write debit value to the GL Transaction Table
                        Try
                            'Writes first value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = VoucherExtendedAmount
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / InvoiceNumber -- " & InvoiceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = PostingLineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception 'If the first value fails, get new transaction number and try again
                            Try
                                'Writes first value to the General Ledger
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLDebitAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = VoucherExtendedAmount
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = PostingLineNumber
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex2 As Exception
                                'Log error on update failure
                                Dim TempVoucherNumber As Integer = 0
                                Dim strVoucherNumber As String
                                TempVoucherNumber = VoucherNumber
                                strVoucherNumber = CStr(TempVoucherNumber)

                                ErrorDate = Today()
                                ErrorComment = ex2.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Post AP Batch --- GL Debit Amount Fail"
                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                        '*************************************************************************************************************
                        'Write credit value to the GL Transaction Table
                        Try
                            'Writes second value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = VoucherExtendedAmount
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = PostingLineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If VoucherSource.Equals("STEEL RECEIPT") Then
                                cmd.Parameters("@GLAccountNumber").Value = "20000"
                            End If

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception 'If value fails, get new transaction number and try again
                            Try
                                'Writes second value to the General Ledger
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLCreditAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = VoucherExtendedAmount
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = PostingLineNumber
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If VoucherSource.Equals("STEEL RECEIPT") Then
                                    cmd.Parameters("@GLAccountNumber").Value = "20000"
                                End If

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex2 As Exception
                                'Log error on update failure
                                Dim TempVoucherNumber As Integer = 0
                                Dim strVoucherNumber As String
                                TempVoucherNumber = VoucherNumber
                                strVoucherNumber = CStr(TempVoucherNumber)

                                ErrorDate = Today()
                                ErrorComment = ex2.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Post AP Batch --- GL Credit Amount Fail"
                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                        '*******************************************************************************************
                        If VoucherSource = "PO RECEIPT" Then
                            '*******************************************************************************************
                            'Check for Cost Adjustment and close receiver if applicable
                            If VoucherReceiverNumber > 0 And VoucherReceiverLine > 0 Then
                                Dim GetClearingQuantityStatement As String = "SELECT QuantityOpen FROM ReceiverPurchaseClearing WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID"
                                Dim GetClearingQuantityCommand As New SqlCommand(GetClearingQuantityStatement, con)
                                GetClearingQuantityCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetClearingQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetClearingQuantityCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    ReceiverQuantityOpen = CDbl(GetClearingQuantityCommand.ExecuteScalar)
                                Catch ex As Exception
                                    ReceiverQuantityOpen = 0
                                End Try
                                con.Close()

                                If ReceiverQuantityOpen = 0 Then
                                    'Close Receiver
                                    cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                        .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Else
                                    cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                        .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                End If
                            Else
                                'Do nothing - run other routine
                            End If
                            '*******************************************************************************************
                            'Run routine to verify Cost Adjustments
                            If VoucherSource = "PO RECEIPT" And VoucherReceiverNumber > 0 And VoucherReceiverLine > 0 Then
                                Dim GetLineCostStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID AND ReceivingLineKey = @ReceivingLineKey"
                                Dim GetLineCostCommand As New SqlCommand(GetLineCostStatement, con)
                                GetLineCostCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetLineCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetLineCostCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetDebitAccountStatement As String = "SELECT DebitGLAccount FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID AND ReceivingLineKey = @ReceivingLineKey"
                                Dim GetDebitAccountCommand As New SqlCommand(GetDebitAccountStatement, con)
                                GetDebitAccountCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetDebitAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetDebitAccountCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetCreditAccountStatement As String = "SELECT CreditGLAccount FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID AND ReceivingLineKey = @ReceivingLineKey"
                                Dim GetCreditAccountCommand As New SqlCommand(GetCreditAccountStatement, con)
                                GetCreditAccountCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetCreditAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetCreditAccountCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetPOLineNumberStatement As String = "SELECT POLineNumber FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID AND ReceivingLineKey = @ReceivingLineKey"
                                Dim GetPOLineNumberCommand As New SqlCommand(GetPOLineNumberStatement, con)
                                GetPOLineNumberCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetPOLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetPOLineNumberCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    ReceiverUnitCost = CDbl(GetLineCostCommand.ExecuteScalar)
                                Catch ex As Exception
                                    ReceiverUnitCost = 0
                                End Try
                                Try
                                    ReceiverDebitAccount = CStr(GetDebitAccountCommand.ExecuteScalar)
                                    If ReceiverDebitAccount = "" Then
                                        ReceiverDebitAccount = "20999"
                                    End If
                                Catch ex As Exception
                                    ReceiverDebitAccount = "20999"
                                End Try
                                Try
                                    ReceiverCreditAccount = CStr(GetCreditAccountCommand.ExecuteScalar)
                                    If ReceiverCreditAccount = "" Then
                                        ReceiverCreditAccount = "59790"
                                    End If
                                Catch ex As Exception
                                    ReceiverCreditAccount = "59790"
                                End Try
                                Try
                                    GetPOLineNumber = CInt(GetPOLineNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetPOLineNumber = 0
                                End Try
                                con.Close()

                                'Get PO Number from Receiver
                                Dim GetPONumber As Integer = 0

                                Dim GetPONumberStatement As String = "SELECT PONumber FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
                                Dim GetPONumberCommand As New SqlCommand(GetPONumberStatement, con)
                                GetPONumberCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetPONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetPONumber = CInt(GetPONumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetPONumber = 0
                                End Try
                                con.Close()

                                ReceiverUnitCost = Math.Round(ReceiverUnitCost, 6)
                                VoucherUnitCost = Math.Round(VoucherUnitCost, 6)

                                If ReceiverUnitCost = VoucherUnitCost Then
                                    'Do nothing - Cost is correct, no adjustment
                                Else
                                    ReceiverExtendedCost = ReceiverUnitCost * VoucherQuantityReceived
                                    CostAdjustmentAmount = ReceiverExtendedCost - VoucherExtendedAmount
                                    CostAdjustmentAmount = Math.Round(CostAdjustmentAmount, 2)

                                    'Update PO to new cost from Voucher
                                    Try
                                        'Update PO Line with new cost
                                        cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET UnitCost = @UnitCost WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                                        With cmd.Parameters
                                            .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GetPONumber
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                            .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = GetPOLineNumber
                                            .Add("@UnitCost", SqlDbType.VarChar).Value = VoucherUnitCost
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()

                                        'Calculate new extended cost from new unit cost
                                        cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET ExtendedAmount = OrderQuantity * UnitCost WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                                        With cmd.Parameters
                                            .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GetPONumber
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()

                                        'Get Sum Extended Amount of lines for product total to update Header
                                        Dim SumPOExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
                                        Dim SumPOExtendedAmountCommand As New SqlCommand(SumPOExtendedAmountStatement, con)
                                        SumPOExtendedAmountCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GetPONumber
                                        SumPOExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            SumPOExtendedAmount = CDbl(SumPOExtendedAmountCommand.ExecuteScalar)
                                        Catch ex As Exception
                                            SumPOExtendedAmount = 0
                                        End Try
                                        con.Close()

                                        'Update Header Table with new Product Total
                                        cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET ProductTotal = @ProductTotal WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                                        With cmd.Parameters
                                            .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GetPONumber
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                            .Add("@ProductTotal", SqlDbType.VarChar).Value = SumPOExtendedAmount
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()

                                        'Update PO Total
                                        cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET POTotal = ProductTotal + FreightCharge + SalesTax WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                                        With cmd.Parameters
                                            .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GetPONumber
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                        '*******************************************************************************************************
                                        If VoucherUnitCost > 0 Then
                                            'Update Cost Tier
                                            cmd = New SqlCommand("UPDATE InventoryCosting SET ItemCost = @ItemCost WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ReferenceNumber = @ReferenceNumber AND ReferenceLine = @ReferenceLine", con)

                                            With cmd.Parameters
                                                .Add("@PartNumber", SqlDbType.VarChar).Value = VoucherPartNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                                .Add("@ReferenceLine", SqlDbType.VarChar).Value = VoucherReceiverLine
                                                .Add("@ItemCost", SqlDbType.VarChar).Value = VoucherUnitCost
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        End If
                                        '*******************************************************************************************************
                                    Catch ex As Exception
                                        'Skip update if fails
                                    End Try

                                    If CostAdjustmentAmount > 0.01 Then
                                        'Convert GL Account to Canadian where applicable
                                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                                            ReceiverCreditAccount = "C$" & ReceiverCreditAccount
                                            ReceiverDebitAccount = "C$" & ReceiverDebitAccount
                                        Else
                                            'Do nothing Vendor Class not needed
                                        End If

                                        Try
                                            'Write to Debit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Debit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Debit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '*********************************************************************************************************
                                        Try
                                            'Write to Credit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Credit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Credit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                    ElseIf CostAdjustmentAmount < -0.01 Then
                                        'Convert GL Account to Canadian where applicable
                                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                                            ReceiverCreditAccount = "C$" & ReceiverCreditAccount
                                            ReceiverDebitAccount = "C$" & ReceiverDebitAccount
                                        Else
                                            'Do nothing Vendor Class not needed
                                        End If
                                        '****************************************************************************************************************************
                                        Try
                                            'Write to Credit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Credit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Credit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '****************************************************************************************************************************
                                        Try
                                            'Write to Debit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Debit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Credit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '*******************************************************************************************
                                        'Clear Data before next entry
                                        ReceiverExtendedCost = 0
                                        ReceiverUnitCost = 0
                                        VoucherQuantityReceived = 0
                                        VoucherUnitCost = 0
                                        CostAdjustmentAmount = 0
                                        ReceiverExtendedCost = 0
                                        VoucherExtendedAmount = 0
                                    Else
                                        'Do nothing = no adjustment
                                    End If
                                End If
                            Else
                                'Do nothing - no routine for Cost Adjustments
                            End If
                        ElseIf VoucherSource = "VENDOR RETURN" Then
                            'Get data from Vendor Return instead of receiver to close lines
                            If VoucherReceiverNumber > 0 And VoucherReceiverLine > 0 Then
                                Dim GetClearingQuantityStatement As String = "SELECT QuantityOpen FROM VendorReturnPurchaseClearing WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber AND DivisionID = @DivisionID"
                                Dim GetClearingQuantityCommand As New SqlCommand(GetClearingQuantityStatement, con)
                                GetClearingQuantityCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetClearingQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetClearingQuantityCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = VoucherReceiverLine

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    ReceiverQuantityOpen = CDbl(GetClearingQuantityCommand.ExecuteScalar)
                                Catch ex As Exception
                                    ReceiverQuantityOpen = 0
                                End Try
                                con.Close()

                                'Exclude

                                If ReceiverQuantityOpen = 0 Then
                                    'Close return
                                    cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@ReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                        .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = VoucherReceiverLine
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Else
                                    cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@ReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                        .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = VoucherReceiverLine
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                End If

                                'Open or close Vendor Return based on if any lines are open.
                                Dim CountOpenReturnLines As Integer = 0

                                Dim CountOpenReturnLinesStatement As String = "SELECT COUNT(ReturnNumber) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber AND LineStatus = 'OPEN' AND DivisionID = @DivisionID"
                                Dim CountOpenReturnLinesCommand As New SqlCommand(CountOpenReturnLinesStatement, con)
                                CountOpenReturnLinesCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                CountOpenReturnLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    CountOpenReturnLines = CDbl(CountOpenReturnLinesCommand.ExecuteScalar)
                                Catch ex As Exception
                                    CountOpenReturnLines = 0
                                End Try
                                con.Close()

                                If CountOpenReturnLines > 0 Then
                                    cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = 'POSTED' WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@ReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Else
                                    cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = 'CLOSED' WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@ReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                End If
                            Else
                                'Do nothing - run other routine
                            End If
                            '*******************************************************************************************
                            'Run routine to verify Cost Adjustments
                            If VoucherSource = "VENDOR RETURN" And VoucherReceiverNumber > 0 Then
                                Dim GetLineCostStatement As String = "SELECT Cost FROM VendorReturnLineQuery WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID AND ReturnLineNumber = @ReturnLineNumber"
                                Dim GetLineCostCommand As New SqlCommand(GetLineCostStatement, con)
                                GetLineCostCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetLineCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetLineCostCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetDebitAccountStatement As String = "SELECT DebitGLAccount FROM VendorReturnLineQuery WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID AND ReturnLineNumber = @ReturnLineNumber"
                                Dim GetDebitAccountCommand As New SqlCommand(GetDebitAccountStatement, con)
                                GetDebitAccountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetDebitAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetDebitAccountCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetCreditAccountStatement As String = "SELECT CreditGLAccount FROM VendorReturnLineQuery WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID AND ReturnLineNumber = @ReturnLineNumber"
                                Dim GetCreditAccountCommand As New SqlCommand(GetCreditAccountStatement, con)
                                GetCreditAccountCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetCreditAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetCreditAccountCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = VoucherReceiverLine

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    ReceiverUnitCost = CDbl(GetLineCostCommand.ExecuteScalar)
                                Catch ex As Exception
                                    ReceiverUnitCost = 0
                                End Try
                                'GL Accounts are reversed on the Voucher Cost Adjustment for Vendor Returns
                                Try
                                    ReceiverDebitAccount = CStr(GetCreditAccountCommand.ExecuteScalar)
                                    If ReceiverDebitAccount = "" Then
                                        ReceiverDebitAccount = "59790"
                                    End If
                                Catch ex As Exception
                                    ReceiverDebitAccount = "59790"
                                End Try
                                Try
                                    ReceiverCreditAccount = CStr(GetDebitAccountCommand.ExecuteScalar)
                                    If ReceiverCreditAccount = "" Then
                                        ReceiverCreditAccount = "20999"
                                    End If
                                Catch ex As Exception
                                    ReceiverCreditAccount = "20999"
                                End Try
                                con.Close()

                                ReceiverUnitCost = Math.Round(ReceiverUnitCost, 6)
                                VoucherUnitCost = Math.Round(VoucherUnitCost, 6)

                                If ReceiverUnitCost = VoucherUnitCost Then
                                    'Do nothing - Cost is correct, no adjustment
                                Else
                                    If VoucherQuantityReceived < 0 Then VoucherQuantityReceived = VoucherQuantityReceived * -1
                                    ReceiverExtendedCost = ReceiverUnitCost * VoucherQuantityReceived
                                    CostAdjustmentAmount = ReceiverExtendedCost - VoucherExtendedAmount
                                    CostAdjustmentAmount = Math.Round(CostAdjustmentAmount, 2)

                                    If CostAdjustmentAmount > 0.01 Then
                                        'Convert GL Account to Canadian where applicable
                                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                                            ReceiverCreditAccount = "C$" & ReceiverCreditAccount
                                            ReceiverDebitAccount = "C$" & ReceiverDebitAccount
                                        Else
                                            'Do nothing Vendor Class not needed
                                        End If
                                        '**************************************************************************************************
                                        Try
                                            'Write to Debit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Debit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Debit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '***********************************************************************************************************************************************
                                        Try
                                            'Write to Credit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Credit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Credit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                    ElseIf CostAdjustmentAmount < -0.01 Then
                                        'Convert GL Account to Canadian where applicable
                                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                                            ReceiverCreditAccount = "C$" & ReceiverCreditAccount
                                            ReceiverDebitAccount = "C$" & ReceiverDebitAccount
                                        Else
                                            'Do nothing Vendor Class not needed
                                        End If
                                        '***********************************************************************************************************
                                        Try
                                            'Write to Credit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Credit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Debit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '**********************************************************************************************************************
                                        Try
                                            'Write to Debit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Debit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Credit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '*******************************************************************************************
                                        'Clear Data before next entry
                                        ReceiverExtendedCost = 0
                                        ReceiverUnitCost = 0
                                        VoucherQuantityReceived = 0
                                        VoucherUnitCost = 0
                                        CostAdjustmentAmount = 0
                                        ReceiverExtendedCost = 0
                                        VoucherExtendedAmount = 0
                                    Else
                                        'Do nothing = no adjustment
                                    End If
                                End If
                            Else
                                'Do nothing - no routine for Cost Adjustments
                            End If
                        ElseIf VoucherSource = "VOUCHER RECEIPT" Then
                            'Do nothing - no cost adjustments and no receivers or returns to close
                        ElseIf VoucherSource = "STEEL VENDOR RETURN" Then
                            'Get data from Vendor Return instead of receiver to close lines
                            'Make sure that Steel Vendor is processed in full before closing lines.
                            Dim GetSteelVoucherQuantity As Double = 0
                            Dim SteelReturnQuantity As Double = 0

                            Dim GetSteelVoucherQuantityStatement As String = "SELECT SUM(Quantity) FROM ReceiptOfInvoiceVoucherLines WHERE ReceiverNumber = @ReceiverNumber AND ReceiverLine = @ReceiverLine AND DivisionID = @DivisionID"
                            Dim GetSteelVoucherQuantityCommand As New SqlCommand(GetSteelVoucherQuantityStatement, con)
                            GetSteelVoucherQuantityCommand.Parameters.Add("@ReceiverNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                            GetSteelVoucherQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            GetSteelVoucherQuantityCommand.Parameters.Add("@ReceiverLine", SqlDbType.VarChar).Value = VoucherReceiverLine

                            Dim SteelReturnQuantityStatement As String = "SELECT ReturnQuantity FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine"
                            Dim SteelReturnQuantityCommand As New SqlCommand(SteelReturnQuantityStatement, con)
                            SteelReturnQuantityCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                            SteelReturnQuantityCommand.Parameters.Add("@SteelReturnLine", SqlDbType.VarChar).Value = VoucherReceiverLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetSteelVoucherQuantity = CDbl(GetSteelVoucherQuantityCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetSteelVoucherQuantity = 0
                            End Try
                            Try
                                SteelReturnQuantity = CDbl(SteelReturnQuantityCommand.ExecuteScalar)
                            Catch ex As Exception
                                SteelReturnQuantity = 0
                            End Try
                            con.Close()

                            'Convert Steel Voucher Quantity to a positive number
                            GetSteelVoucherQuantity = GetSteelVoucherQuantity * -1

                            If GetSteelVoucherQuantity < SteelReturnQuantity Then
                                'Open Line Number
                                cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = @LineStatus WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)

                                With cmd.Parameters
                                    .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                    .Add("@SteelReturnLine", SqlDbType.VarChar).Value = VoucherReceiverLine
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Else
                                'Close Line Number
                                cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = @LineStatus WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)

                                With cmd.Parameters
                                    .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                    .Add("@SteelReturnLine", SqlDbType.VarChar).Value = VoucherReceiverLine
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If
                            '*******************************************************************************************
                            'Run routine to verify Cost Adjustments
                            If VoucherSource = "STEEL VENDOR RETURN" And VoucherReceiverNumber > 0 Then
                                Dim GetLineCostStatement As String = "SELECT UnitCost FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine"
                                Dim GetLineCostCommand As New SqlCommand(GetLineCostStatement, con)
                                GetLineCostCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetLineCostCommand.Parameters.Add("@SteelReturnLine", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetDebitAccountStatement As String = "SELECT GLDebitAccount FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine"
                                Dim GetDebitAccountCommand As New SqlCommand(GetDebitAccountStatement, con)
                                GetDebitAccountCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetDebitAccountCommand.Parameters.Add("@SteelReturnLine", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetCreditAccountStatement As String = "SELECT GLCreditAccount FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine"
                                Dim GetCreditAccountCommand As New SqlCommand(GetCreditAccountStatement, con)
                                GetCreditAccountCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetCreditAccountCommand.Parameters.Add("@SteelReturnLine", SqlDbType.VarChar).Value = VoucherReceiverLine

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    ReceiverUnitCost = CDbl(GetLineCostCommand.ExecuteScalar)
                                Catch ex As Exception
                                    ReceiverUnitCost = 0
                                End Try
                                'GL Accounts are reversed on the Voucher Cost Adjustment for Vendor Returns
                                Try
                                    ReceiverDebitAccount = CStr(GetCreditAccountCommand.ExecuteScalar)
                                    If ReceiverDebitAccount = "" Then
                                        ReceiverDebitAccount = "12000"
                                    End If
                                Catch ex As Exception
                                    ReceiverDebitAccount = "12000"
                                End Try
                                Try
                                    ReceiverCreditAccount = CStr(GetDebitAccountCommand.ExecuteScalar)
                                    If ReceiverCreditAccount = "" Then
                                        ReceiverCreditAccount = "20995"
                                    End If
                                Catch ex As Exception
                                    ReceiverCreditAccount = "20995"
                                End Try
                                con.Close()

                                ReceiverUnitCost = Math.Round(ReceiverUnitCost, 6)
                                VoucherUnitCost = Math.Round(VoucherUnitCost, 6)

                                If ReceiverUnitCost = VoucherUnitCost Then
                                    'Do nothing - Cost is correct, no adjustment
                                Else
                                    If VoucherQuantityReceived < 0 Then VoucherQuantityReceived = VoucherQuantityReceived * -1
                                    ReceiverExtendedCost = ReceiverUnitCost * VoucherQuantityReceived
                                    CostAdjustmentAmount = ReceiverExtendedCost - VoucherExtendedAmount
                                    CostAdjustmentAmount = Math.Round(CostAdjustmentAmount, 2)

                                    If CostAdjustmentAmount > 0.01 Then
                                        'Convert GL Account to Canadian where applicable
                                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                                            ReceiverCreditAccount = "C$" & ReceiverCreditAccount
                                            ReceiverDebitAccount = "C$" & ReceiverDebitAccount
                                        Else
                                            'Do nothing Vendor Class not needed
                                        End If
                                        '**************************************************************************************************
                                        Try
                                            'Write to Debit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Debit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Debit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '***********************************************************************************************************************************************
                                        Try
                                            'Write to Credit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Credit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Credit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                    ElseIf CostAdjustmentAmount < -0.01 Then
                                        'Convert GL Account to Canadian where applicable
                                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                                            ReceiverCreditAccount = "C$" & ReceiverCreditAccount
                                            ReceiverDebitAccount = "C$" & ReceiverDebitAccount
                                        Else
                                            'Do nothing Vendor Class not needed
                                        End If
                                        '***********************************************************************************************************
                                        Try
                                            'Write to Credit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Credit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Debit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '**********************************************************************************************************************
                                        Try
                                            'Write to Debit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Debit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Vendor Return Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Credit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '*******************************************************************************************
                                        'Clear Data before next entry
                                        ReceiverExtendedCost = 0
                                        ReceiverUnitCost = 0
                                        VoucherQuantityReceived = 0
                                        VoucherUnitCost = 0
                                        CostAdjustmentAmount = 0
                                        ReceiverExtendedCost = 0
                                        VoucherExtendedAmount = 0
                                    Else
                                        'Do nothing = no adjustment
                                    End If
                                End If
                            Else
                                'Do nothing - no routine for Cost Adjustments
                            End If
                        ElseIf VoucherSource = "STEEL RECEIPT" Then
                            '*******************************************************************************************
                            'Check for Cost Adjustment and close receiver if applicable
                            If VoucherReceiverNumber > 0 And VoucherReceiverLine > 0 Then
                                Dim GetVoucherQuantity As Double = 0
                                Dim GetReceiverQuantity As Double = 0

                                Dim GetVoucherQuantityStatement As String = "SELECT SUM(Quantity) FROM ReceiptOfInvoiceVoucherLines WHERE ReceiverNumber = @ReceiverNumber AND ReceiverLine = @ReceiverLine AND DivisionID = @DivisionID"
                                Dim GetVoucherQuantityCommand As New SqlCommand(GetVoucherQuantityStatement, con)
                                GetVoucherQuantityCommand.Parameters.Add("@ReceiverNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetVoucherQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetVoucherQuantityCommand.Parameters.Add("@ReceiverLine", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetReceiverQuantityStatement As String = "SELECT ReceiveWeight FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey"
                                Dim GetReceiverQuantityCommand As New SqlCommand(GetReceiverQuantityStatement, con)
                                GetReceiverQuantityCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetReceiverQuantityCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetVoucherQuantity = CDbl(GetVoucherQuantityCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetVoucherQuantity = 0
                                End Try
                                Try
                                    GetReceiverQuantity = CDbl(GetReceiverQuantityCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetReceiverQuantity = 0
                                End Try
                                con.Close()

                                If GetVoucherQuantity >= GetReceiverQuantity Then
                                    'Close Receiver
                                    cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                                    With cmd.Parameters
                                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                        .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine
                                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Else
                                    cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                                    With cmd.Parameters
                                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                        .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine
                                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                End If
                            Else
                                'Do nothing - run other routine
                            End If
                            '*******************************************************************************************
                            'Run routine to verify Cost Adjustments
                            If VoucherSource = "STEEL RECEIPT" And VoucherReceiverNumber > 0 Then
                                Dim GetReceiverRMID As String = ""

                                Dim GetLineCostStatement As String = "SELECT SteelUnitCost FROM SteelReceivingLineQuery2 WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID AND SteelReceivingLineKey = @SteelReceivingLineKey"
                                Dim GetLineCostCommand As New SqlCommand(GetLineCostStatement, con)
                                GetLineCostCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetLineCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetLineCostCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetDebitAccountStatement As String = "SELECT CreditGLAccount FROM SteelReceivingLineQuery2 WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID AND SteelReceivingLineKey = @SteelReceivingLineKey"
                                Dim GetDebitAccountCommand As New SqlCommand(GetDebitAccountStatement, con)
                                GetDebitAccountCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetDebitAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetDebitAccountCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetCreditAccountStatement As String = "SELECT DebitGLAccount FROM SteelReceivingLineQuery2 WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID AND SteelReceivingLineKey = @SteelReceivingLineKey"
                                Dim GetCreditAccountCommand As New SqlCommand(GetCreditAccountStatement, con)
                                GetCreditAccountCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetCreditAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetCreditAccountCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetPOLineNumberStatement As String = "SELECT MIN(POLineNumber) FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey"
                                Dim GetPOLineNumberCommand As New SqlCommand(GetPOLineNumberStatement, con)
                                GetPOLineNumberCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetPOLineNumberCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                Dim GetReceiverRMIDStatement As String = "SELECT RMID FROM SteelReceivingLineQuery2 WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey"
                                Dim GetReceiverRMIDCommand As New SqlCommand(GetReceiverRMIDStatement, con)
                                GetReceiverRMIDCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetReceiverRMIDCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    ReceiverUnitCost = CDbl(GetLineCostCommand.ExecuteScalar)
                                Catch ex As Exception
                                    ReceiverUnitCost = 0
                                End Try
                                Try
                                    ReceiverDebitAccount = CStr(GetDebitAccountCommand.ExecuteScalar)
                                    If ReceiverDebitAccount = "" Then
                                        ReceiverDebitAccount = "12000"
                                    End If
                                Catch ex As Exception
                                    ReceiverDebitAccount = "12000"
                                End Try
                                Try
                                    ReceiverCreditAccount = CStr(GetCreditAccountCommand.ExecuteScalar)
                                    If ReceiverCreditAccount = "" Then
                                        ReceiverCreditAccount = "20995"
                                    End If
                                Catch ex As Exception
                                    ReceiverCreditAccount = "20995"
                                End Try
                                Try
                                    GetPOLineNumber = CInt(GetPOLineNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetPOLineNumber = 0
                                End Try
                                Try
                                    GetReceiverRMID = CStr(GetReceiverRMIDCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetReceiverRMID = ""
                                End Try
                                con.Close()

                                'Get PO Number from Receiver
                                Dim GetPONumber As Integer = 0

                                Dim GetPONumberStatement As String = "SELECT MIN(PONumber) FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey"
                                Dim GetPONumberCommand As New SqlCommand(GetPONumberStatement, con)
                                GetPONumberCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                GetPONumberCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = VoucherReceiverLine

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetPONumber = CInt(GetPONumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetPONumber = 0
                                End Try
                                con.Close()

                                ReceiverUnitCost = Math.Round(ReceiverUnitCost, 6)
                                VoucherUnitCost = Math.Round(VoucherUnitCost, 6)

                                If ReceiverUnitCost = VoucherUnitCost Then
                                    'Do nothing - Cost is correct, no adjustment
                                Else
                                    ReceiverExtendedCost = ReceiverUnitCost * VoucherQuantityReceived
                                    CostAdjustmentAmount = ReceiverExtendedCost - VoucherExtendedAmount
                                    CostAdjustmentAmount = Math.Round(CostAdjustmentAmount, 2)
                                    '**********************************************************************************
                                    'Update PO to new cost from Voucher
                                    Try
                                        'Update PO Line with new cost
                                        cmd = New SqlCommand("UPDATE SteelPurchaseLine SET PurchasePricePerPound = @PurchasePricePerPound WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey AND SteelPurchaseLineNumber = @SteelPurchaseLineNumber", con)

                                        With cmd.Parameters
                                            .Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GetPONumber
                                            .Add("@SteelPurchaseLineNumber", SqlDbType.VarChar).Value = GetPOLineNumber
                                            .Add("@PurchasePricePerPound", SqlDbType.VarChar).Value = VoucherUnitCost
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Log error on update failure
                                        Dim TempVoucherNumber As Integer = 0
                                        Dim strVoucherNumber As String = ""
                                        Dim strPONumber As String = ""

                                        TempVoucherNumber = VoucherNumber
                                        strVoucherNumber = CStr(TempVoucherNumber)
                                        strPONumber = CStr(GetPONumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Post AP Batch --- Steel PO Line Update Fail"
                                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber + " PO# - " + strPONumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                    '***********************************************************************************
                                    Try
                                        'Calculate new extended cost from new unit cost
                                        cmd = New SqlCommand("UPDATE SteelPurchaseLine SET ExtendedAmount = PurchaseQuantity * PurchasePricePerPound WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey", con)

                                        With cmd.Parameters
                                            .Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GetPONumber
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Log error on update failure
                                        Dim TempVoucherNumber As Integer = 0
                                        Dim strVoucherNumber As String = ""
                                        Dim strPONumber As String = ""

                                        TempVoucherNumber = VoucherNumber
                                        strVoucherNumber = CStr(TempVoucherNumber)
                                        strPONumber = CStr(GetPONumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Post AP Batch --- Steel PO Line Update Fail"
                                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber + " PO# - " + strPONumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                    '***********************************************************************************
                                    Try
                                        'Get Sum Extended Amount of lines for product total to update Header
                                        Dim SumPOExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = @SteelPurchaseOrderHeaderKey"
                                        Dim SumPOExtendedAmountCommand As New SqlCommand(SumPOExtendedAmountStatement, con)
                                        SumPOExtendedAmountCommand.Parameters.Add("@SteelPurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GetPONumber

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            SumPOExtendedAmount = CDbl(SumPOExtendedAmountCommand.ExecuteScalar)
                                        Catch ex As Exception
                                            SumPOExtendedAmount = 0
                                        End Try
                                        con.Close()

                                        'Update Header Table with new Product Total
                                        cmd = New SqlCommand("UPDATE SteelPurchaseOrderHeader SET SteelTotal = @SteelTotal WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey AND DivisionID = @DivisionID", con)

                                        With cmd.Parameters
                                            .Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = GetPONumber
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                            .Add("@SteelTotal", SqlDbType.VarChar).Value = SumPOExtendedAmount
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Log error on update failure
                                        Dim TempVoucherNumber As Integer = 0
                                        Dim strVoucherNumber As String = ""
                                        Dim strPONumber As String = ""

                                        TempVoucherNumber = VoucherNumber
                                        strVoucherNumber = CStr(TempVoucherNumber)
                                        strPONumber = CStr(GetPONumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Post AP Batch --- Steel PO Header Update Fail"
                                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber + " PO# - " + strPONumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                    '*******************************************************************************************************
                                    Try
                                        'Update PO Total
                                        cmd = New SqlCommand("UPDATE SteelPurchaseOrderHeader SET SteelPurchaseTotal = SteelTotal + FreightTotal + OtherTotal WHERE SteelPurchaseOrderKey = @SteelPurchaseOrderKey AND DivisionID = @DivisionID", con)

                                        With cmd.Parameters
                                            .Add("@SteelPurchaseOrderKey", SqlDbType.VarChar).Value = GetPONumber
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Log error on update failure
                                        Dim TempVoucherNumber As Integer = 0
                                        Dim strVoucherNumber As String = ""
                                        Dim strPONumber As String = ""

                                        TempVoucherNumber = VoucherNumber
                                        strVoucherNumber = CStr(TempVoucherNumber)
                                        strPONumber = CStr(GetPONumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Post AP Batch --- Steel PO Header Update Fail"
                                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber + " PO# - " + strPONumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                    '*******************************************************************************************************
                                    Try
                                        If VoucherUnitCost > 0 Then
                                            'Update Cost Tier
                                            cmd = New SqlCommand("UPDATE SteelCostingTable SET SteelCostPerPound = @SteelCostPerPound WHERE RMID = @RMID AND ReferenceNumber = @ReferenceNumber AND ReferenceLine = @ReferenceLine", con)

                                            With cmd.Parameters
                                                .Add("@RMID", SqlDbType.VarChar).Value = GetReceiverRMID
                                                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = VoucherReceiverNumber
                                                .Add("@ReferenceLine", SqlDbType.VarChar).Value = VoucherReceiverLine
                                                .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = VoucherUnitCost
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        End If
                                    Catch ex As Exception
                                        'Log error on update failure
                                        Dim TempVoucherNumber As Integer = 0
                                        Dim strVoucherNumber As String = ""
                                        Dim strPONumber As String = ""

                                        TempVoucherNumber = VoucherNumber
                                        strVoucherNumber = CStr(TempVoucherNumber)
                                        strPONumber = CStr(GetPONumber)

                                        ErrorDate = Today()
                                        ErrorComment = ex.ToString()
                                        ErrorDivision = cboDivisionID.Text
                                        ErrorDescription = "Post AP Batch --- Steel Costing Fail"
                                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber + " PO# - " + strPONumber
                                        ErrorUser = EmployeeLoginName

                                        TFPErrorLogUpdate()
                                    End Try
                                    '*******************************************************************************************************
                                    If CostAdjustmentAmount > 0.01 Then
                                        'Convert GL Account to Canadian where applicable
                                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                                            ReceiverCreditAccount = "C$" & ReceiverCreditAccount
                                            ReceiverDebitAccount = "C$" & ReceiverDebitAccount
                                        Else
                                            'Do nothing Vendor Class not needed
                                        End If

                                        Try
                                            'Write to Debit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Debit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Debit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '*********************************************************************************************************
                                        Try
                                            'Write to Credit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Credit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Credit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                    ElseIf CostAdjustmentAmount < -0.01 Then
                                        'Convert GL Account to Canadian where applicable
                                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                                            ReceiverCreditAccount = "C$" & ReceiverCreditAccount
                                            ReceiverDebitAccount = "C$" & ReceiverDebitAccount
                                        Else
                                            'Do nothing Vendor Class not needed
                                        End If
                                        '****************************************************************************************************************************
                                        Try
                                            'Write to Credit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Credit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Credit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '****************************************************************************************************************************
                                        Try
                                            'Write to Debit Side of a Voucher Cost Adjustment
                                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                            With cmd.Parameters
                                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                            End With

                                            If con.State = ConnectionState.Closed Then con.Open()
                                            cmd.ExecuteNonQuery()
                                            con.Close()
                                        Catch ex As Exception
                                            Try
                                                'Write to Debit Side of a Voucher Cost Adjustment
                                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                                With cmd.Parameters
                                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment"
                                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount * -1
                                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Receiver Number -- " & ReceiverNumber
                                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                                End With

                                                If con.State = ConnectionState.Closed Then con.Open()
                                                cmd.ExecuteNonQuery()
                                                con.Close()
                                            Catch ex8 As Exception
                                                'Log error on update failure
                                                Dim TempVoucherNumber As Integer = 0
                                                Dim strVoucherNumber As String
                                                TempVoucherNumber = VoucherNumber
                                                strVoucherNumber = CStr(TempVoucherNumber)

                                                ErrorDate = Today()
                                                ErrorComment = ex8.ToString()
                                                ErrorDivision = cboDivisionID.Text
                                                ErrorDescription = "Post AP Batch --- Voucher Cost Adj Credit Fail"
                                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                                ErrorUser = EmployeeLoginName

                                                TFPErrorLogUpdate()
                                            End Try
                                        End Try
                                        '*******************************************************************************************
                                        'Clear Data before next entry
                                        ReceiverExtendedCost = 0
                                        ReceiverUnitCost = 0
                                        VoucherQuantityReceived = 0
                                        VoucherUnitCost = 0
                                        CostAdjustmentAmount = 0
                                        ReceiverExtendedCost = 0
                                        VoucherExtendedAmount = 0
                                    Else
                                        'Do nothing = no adjustment
                                    End If
                                End If
                            Else
                                'Do nothing - no routine for Cost Adjustments
                            End If
                        End If
                        '*******************************************************************************************
                        'Update Voucher Line Status to show as posted
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET SelectForInvoice = @SelectForInvoice WHERE VoucherNumber = @VoucherNumber", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        PostingLineNumber = PostingLineNumber + 1
                    Next i
                    '*********************************************************************************
                    'End of Line Routine
                    '*********************************************************************************
                    If InvoiceFreight > 0 Then
                        'Convert GL Account to Canadian where applicable
                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                            FreightDebitAccount = "C$62000"
                            FreightCreditAccount = "C$20000"
                        Else
                            FreightDebitAccount = "62000"
                            FreightCreditAccount = "20000"
                        End If
                        '***************************************************************************************************************
                        Try
                            'Write to Debit Side of Freight Transaction
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Freight Charges"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = InvoiceFreight
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            Try
                                'Write to Debit Side of Freight Transaction
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightDebitAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Freight Charges"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = InvoiceFreight
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex8 As Exception
                                'Log error on update failure
                                Dim TempVoucherNumber As Integer = 0
                                Dim strVoucherNumber As String
                                TempVoucherNumber = VoucherNumber
                                strVoucherNumber = CStr(TempVoucherNumber)

                                ErrorDate = Today()
                                ErrorComment = ex8.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Post AP Batch --- Freight Debit Fail"
                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                        '****************************************************************************************************************************
                        Try
                            'Write to Credit Side of Freight Transaction
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Freight Post To Payables"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = InvoiceFreight
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            Try
                                'Write to Credit Side of Freight Transaction
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightCreditAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Freight Post To Payables"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = InvoiceFreight
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex8 As Exception
                                'Log error on update failure
                                Dim TempVoucherNumber As Integer = 0
                                Dim strVoucherNumber As String
                                TempVoucherNumber = VoucherNumber
                                strVoucherNumber = CStr(TempVoucherNumber)

                                ErrorDate = Today()
                                ErrorComment = ex8.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Post AP Batch --- Freight Credit Fail"
                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                    ElseIf InvoiceFreight < 0 Then
                        'Convert GL Account to Canadian where applicable
                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                            FreightDebitAccount = "C$20000"
                            FreightCreditAccount = "C$62000"
                        Else
                            FreightDebitAccount = "20000"
                            FreightCreditAccount = "62000"
                        End If
                        '************************************************************************************************************
                        Try
                            'Write to Debit Side of Freight Transaction
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Freight Charges"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = InvoiceFreight * -1
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            Try
                                'Write to Debit Side of Freight Transaction
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightDebitAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Freight Charges"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = InvoiceFreight * -1
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex8 As Exception
                                'Log error on update failure
                                Dim TempVoucherNumber As Integer = 0
                                Dim strVoucherNumber As String
                                TempVoucherNumber = VoucherNumber
                                strVoucherNumber = CStr(TempVoucherNumber)

                                ErrorDate = Today()
                                ErrorComment = ex8.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Post AP Batch --- Freight Debit Fail"
                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                        '******************************************************************************************************************
                        Try
                            'Write to Credit Side of Freight Transaction
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Freight Post To Payables"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = InvoiceFreight * -1
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            Try
                                'Write to Credit Side of Freight Transaction
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    ' .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightCreditAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Freight Post To Payables"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = InvoiceFreight * -1
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex8 As Exception
                                'Log error on update failure
                                Dim TempVoucherNumber As Integer = 0
                                Dim strVoucherNumber As String
                                TempVoucherNumber = VoucherNumber
                                strVoucherNumber = CStr(TempVoucherNumber)

                                ErrorDate = Today()
                                ErrorComment = ex8.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Post AP Batch --- Freight Credit Fail"
                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                    End If
                    '*********************************************************************************
                    If InvoiceSalesTax > 0 Then
                        'Convert GL Account to Canadian where applicable
                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                            SalesTaxDebitAccount = "C$14500"
                            SalesTaxCreditAccount = "C$20000"
                        ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "AMERICAN" Then
                            SalesTaxDebitAccount = "14500"
                            SalesTaxCreditAccount = "20000"
                        Else
                            SalesTaxDebitAccount = "78000"
                            SalesTaxCreditAccount = "20000"
                        End If
                        '*************************************************************************************************************
                        Try
                            'Update GL Transactions
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Sales Tax Paid"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = InvoiceSalesTax
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            Try
                                'Update GL Transactions
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxDebitAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Sales Tax Paid"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = InvoiceSalesTax
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex8 As Exception
                                'Log error on update failure
                                Dim TempVoucherNumber As Integer = 0
                                Dim strVoucherNumber As String
                                TempVoucherNumber = VoucherNumber
                                strVoucherNumber = CStr(TempVoucherNumber)

                                ErrorDate = Today()
                                ErrorComment = ex8.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Post AP Batch --- Sales Tax Debit Fail"
                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                        '******************************************************************************************************************************************
                        Try
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Sales Tax Post To Payables"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = InvoiceSalesTax
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            Try
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxCreditAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Sales Tax Post To Payables"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = InvoiceSalesTax
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex8 As Exception
                                'Log error on update failure
                                Dim TempVoucherNumber As Integer = 0
                                Dim strVoucherNumber As String
                                TempVoucherNumber = VoucherNumber
                                strVoucherNumber = CStr(TempVoucherNumber)

                                ErrorDate = Today()
                                ErrorComment = ex8.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Post AP Batch --- Sales Tax Credit Fail"
                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                    ElseIf InvoiceSalesTax < 0 Then
                        'Convert GL Account to Canadian where applicable
                        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                            SalesTaxDebitAccount = "C$20000"
                            SalesTaxCreditAccount = "C$14500"
                        ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "AMERICAN" Then
                            SalesTaxDebitAccount = "20000"
                            SalesTaxCreditAccount = "14500"
                        Else
                            SalesTaxDebitAccount = "20000"
                            SalesTaxCreditAccount = "78000"
                        End If
                        '*************************************************************************************************************
                        Try
                            'Update GL Transactions
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Sales Tax Paid"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = InvoiceSalesTax * -1
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            Try
                                '**************************************************************************************************************
                                'Update GL Transactions
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxDebitAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Sales Tax Paid"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = InvoiceSalesTax * -1
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex8 As Exception
                                'Log error on update failure
                                Dim TempVoucherNumber As Integer = 0
                                Dim strVoucherNumber As String
                                TempVoucherNumber = VoucherNumber
                                strVoucherNumber = CStr(TempVoucherNumber)

                                ErrorDate = Today()
                                ErrorComment = ex8.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Post AP Batch --- Sales Tax Debit Fail"
                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                        '********************************************************************************************************************
                        Try
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Sales Tax Post To Payables"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = InvoiceSalesTax * -1
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            Try
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxCreditAccount
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Sales Tax Post To Payables"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = InvoiceSalesTax * -1
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = VendorID & " -- Vendor" & " / Invoice Number -- " & InvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex8 As Exception
                                'Log error on update failure
                                Dim TempVoucherNumber As Integer = 0
                                Dim strVoucherNumber As String
                                TempVoucherNumber = VoucherNumber
                                strVoucherNumber = CStr(TempVoucherNumber)

                                ErrorDate = Today()
                                ErrorComment = ex8.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Post AP Batch --- Sales Tax Credit Fail"
                                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                    End If
                    '**************************************************************************************************************
                    If VoucherSource = "PO RECEIPT" Then
                        'Check Status of the receiver and close if necessary
                        Dim CountOpenLines As Integer = 0

                        'Get number of open lines
                        Dim CountOpenLinesStatement As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingLineTable WHERE SelectForInvoice = @SelectForInvoice AND ReceivingHeaderKey = @ReceivingHeaderKey"
                        Dim CountOpenLinesCommand As New SqlCommand(CountOpenLinesStatement, con)
                        CountOpenLinesCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                        CountOpenLinesCommand.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountOpenLines = CInt(CountOpenLinesCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountOpenLines = 0
                        End Try
                        con.Close()
                        '**************************************************************************************************************
                        If CountOpenLines = 0 Then
                            'UPDATE the Status of the Receiver
                            cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            'UPDATE the Status of the Receiver
                            cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    ElseIf VoucherSource = "VENDOR RETURN" Then
                        'Check Status of the return and close if necessary
                        Dim CountOpenLines As Integer = 0

                        'Get number of open lines
                        Dim CountOpenLinesStatement As String = "SELECT COUNT(ReturnNumber) FROM VendorReturnLine WHERE LineStatus = @LineStatus AND ReturnNumber = @ReturnNumber"
                        Dim CountOpenLinesCommand As New SqlCommand(CountOpenLinesStatement, con)
                        CountOpenLinesCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReceiverNumber
                        CountOpenLinesCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountOpenLines = CInt(CountOpenLinesCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountOpenLines = 0
                        End Try
                        con.Close()
                        '**************************************************************************************************************
                        If CountOpenLines = 0 Then
                            'UPDATE the Status of the Receiver
                            cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ReturnNumber", SqlDbType.VarChar).Value = ReceiverNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "CLOSED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            'UPDATE the Status of the Receiver
                            cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ReturnNumber", SqlDbType.VarChar).Value = ReceiverNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Else
                        'Skip - no receiver or return to close
                    End If
                Next
                '**************************************************************************************************************
                'Reload Batch Totals
                LoadTotals()

                Try
                    'UPDATE the Status of the Batch
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchStatus = @BatchStatus, BatchAmount = @BatchAmount, PrintDate = @PrintDate, Locked = '' WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = UpdateTotals
                        .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex7 As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = Today()
                    ErrorComment = ex7.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Post AP Batch --- Update Batch Status - ROI Batch Header"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '**************************************************************************************************************
                Try
                    'UPDATE the Status of the Voucher
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex7 As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = Today()
                    ErrorComment = ex7.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Post AP Batch --- Update Voucher Status - ROI Batch Line"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '**************************************************************************************************************
                'Clear data and reset defaults
                MsgBox("Your Batch has been posted.", MsgBoxStyle.OkOnly)
                LoadBatchNumber()
                ClearVariables()
                ClearBatch()
                ShowBatchLines()
            Catch ex9 As Exception
                MsgBox("There was a problem in posting. Batch did not post.", MsgBoxStyle.OkOnly)

                'Log error on update failure
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex9.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Post AP Batch --- Batch did not Post"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboBatchNumber.Text = "" Then
            MsgBox("A valid Batch Number must be selected to save a batch.", MsgBoxStyle.OkOnly)
            cboBatchNumber.Focus()
        Else
            ''check to see if this batch is being edited by someone else
            If isSomeoneEditing() Then
                Exit Sub
            End If

            'Check Batch Status
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "POSTED"
            End Try
            con.Close()

            If BatchStatus = "POSTED" Then
                MsgBox("Batch is already posted and changes cannot be saved.", MsgBoxStyle.OkOnly)
            Else
                Try
                    'Save data in datagrid
                    Dim Updater As New SqlCommandBuilder(myAdapter1)
                    Me.Validate()
                    Me.myAdapter1.Update(Me.ds1.Tables("ReceiptOfInvoiceBatchLine"))
                    Me.ds1.AcceptChanges()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Save AP Batch --- Update datagrid command"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Write Data to Batch Header Database Table
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, Locked = @Locked WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                End With
                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    con.Close()

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "APProcessBatch - cmdSave_Click --Error updating Batch Header Info"
                    ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                'Load Updated Totals into Batch
                LoadTotals()

                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = UpdateTotals

                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    con.Close()

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "APProcessBatch - cmdSave_Click --Error updating Batch Amount"
                    ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try


                MsgBox("Batch has been updated.", MsgBoxStyle.OkOnly)

                'Shows (clears) any line in datagrid unless they exist for that batch
                ShowBatchLines()
                LoadTotals()
                LoadOpenBatches()
            End If
        End If
    End Sub

    Private Sub SaveBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBatchToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            'Check Batch Status
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "POSTED"
            End Try
            con.Close()

            If BatchStatus = "POSTED" Then
                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text

                Dim NewPrintAPProcessBatch As New PrintAPProcessBatch
                NewPrintAPProcessBatch.Show()
            Else
                If Not isSomeoneEditing() Then
                    Try
                        'Write Data to Batch Header Database Table
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, DivisionID = @DivisionID, BatchStatus = @BatchStatus, Locked = @Locked WHERE BatchNumber = @BatchNumber", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                            .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "APProcessBatch - cmdPrint_Click --Error updating Batch Info"
                        ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If

                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text

                Dim NewPrintAPProcessBatch As New PrintAPProcessBatch
                NewPrintAPProcessBatch.Show()
            End If
        End If
    End Sub

    Private Sub PrintBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBatchToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboBatchNumber.Text = "" Then
            MsgBox("You must select a valid Batch Number to delete", MsgBoxStyle.OkOnly)
        Else
            ''check to see if this batch is being edited by someone else
            If isSomeoneEditing() Then
                Exit Sub
            End If
            'Prompt before deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Batch?", "DELETE BATCH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Check Batch Status
                Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
                BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    BatchStatus = "POSTED"
                End Try
                con.Close()

                If BatchStatus = "POSTED" Then
                    MsgBox("This batch is Posted - it cannot be deleted.", MsgBoxStyle.OkOnly)
                Else
                    'resets the voucher back to the initial batch
                    resetRecurring()

                    'Set receivers/returns back to be processed again
                    Dim DeleteVoucherTotal As Double = 0
                    Dim DeleteVendorID As String = ""

                    For Each row As DataGridViewRow In dgvBatchItems.Rows
                        Try
                            DeleteReferenceNumber = row.Cells("DeleteReferenceNumberColumn").Value
                        Catch ex As Exception
                            DeleteReferenceNumber = 0
                        End Try
                        Try
                            VoucherNumber = row.Cells("VoucherNumberColumn").Value
                        Catch ex As Exception
                            VoucherNumber = 0
                        End Try
                        Try
                            VoucherSource = row.Cells("VoucherSourceColumn").Value
                        Catch ex As Exception
                            VoucherSource = ""
                        End Try
                        Try
                            DeleteVoucherTotal = row.Cells("InvoiceTotalColumn").Value
                        Catch ex As Exception
                            DeleteVoucherTotal = 0
                        End Try
                        Try
                            DeleteVendorID = row.Cells("VendorIDColumn").Value
                        Catch ex As Exception
                            DeleteVendorID = ""
                        End Try
                        '*********************************************************************************************
                        'Write to Audit Trail Table
                        Dim AuditComment As String = ""
                        Dim AuditVoucherNumber As Integer = 0
                        Dim strVoucherNumber As String = ""

                        AuditVoucherNumber = VoucherNumber
                        strVoucherNumber = CStr(AuditVoucherNumber)
                        AuditComment = "Voucher #" + strVoucherNumber + " for vendor " + DeleteVendorID + " was deleted on " + Today()

                        Try
                            cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@AuditType", SqlDbType.VarChar).Value = "VOUCHER - DELETION (Unposted Batch)"
                                .Add("@AuditAmount", SqlDbType.VarChar).Value = DeleteVoucherTotal
                                .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strVoucherNumber
                                .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                                .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception

                        End Try
                        '*********************************************************************************************
                        'Check if Voucher is a return
                        If VoucherSource = "VENDOR RETURN" Then
                            cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ReturnNumber", SqlDbType.VarChar).Value = DeleteReferenceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Update Vendor Return Lines
                            cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ReturnNumber", SqlDbType.VarChar).Value = DeleteReferenceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        ElseIf VoucherSource = "STEEL VENDOR RETURN" Then
                            'Reset Steel Return
                            cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = @ReturnStatus WHERE SteelReturnNumber = @SteelReturnNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = DeleteReferenceNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Update Steel Vendor Return Lines
                            cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = @LineStatus WHERE SteelReturnNumber = @SteelReturnNumber", con)

                            With cmd.Parameters
                                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = DeleteReferenceNumber
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            If DeleteReferenceNumber > 0 Then
                                'Check if Receiver # is written in the line table
                                Dim CheckReceiverStatement As String = "SELECT MAX(ReceiverNumber) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                                Dim CheckReceiverCommand As New SqlCommand(CheckReceiverStatement, con)
                                CheckReceiverCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                CheckReceiverCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    CheckReceiver = CInt(CheckReceiverCommand.ExecuteScalar)
                                Catch ex As Exception
                                    CheckReceiver = 0
                                End Try
                                con.Close()

                                If CheckReceiver > 0 Then ' Reset the Receiver by the data in the voucher line table
                                    'Count Voucher Lines to run a loop
                                    Dim CountVoucherLinesStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                                    Dim CountVoucherLinesCommand As New SqlCommand(CountVoucherLinesStatement, con)
                                    CountVoucherLinesCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    CountVoucherLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        CountVoucherLines = CInt(CountVoucherLinesCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        CountVoucherLines = 0
                                    End Try
                                    con.Close()

                                    'Initialize first line number
                                    Dim VoucherLineNumber As Integer = 1

                                    For i As Integer = 1 To CountVoucherLines
                                        'Get Receiver Number and Line to reset Receiver
                                        Dim GetReceiverNumberStatement As String = "SELECT ReceiverNumber FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                                        Dim GetReceiverNumberCommand As New SqlCommand(GetReceiverNumberStatement, con)
                                        GetReceiverNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                        GetReceiverNumberCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = VoucherLineNumber

                                        'Get Receiver Number and Line to reset Receiver
                                        Dim GetReceiverLineStatement As String = "SELECT ReceiverLine FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                                        Dim GetReceiverLineCommand As New SqlCommand(GetReceiverLineStatement, con)
                                        GetReceiverLineCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                        GetReceiverLineCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = VoucherLineNumber

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        Try
                                            GetReceiverNumber = CInt(GetReceiverNumberCommand.ExecuteScalar)
                                        Catch ex As Exception
                                            GetReceiverNumber = 0
                                        End Try
                                        Try
                                            GetReceiverLine = CInt(GetReceiverLineCommand.ExecuteScalar)
                                        Catch ex As Exception
                                            GetReceiverLine = 0
                                        End Try
                                        con.Close()

                                        cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID", con)

                                        With cmd.Parameters
                                            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = GetReceiverNumber
                                            .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = GetReceiverLine
                                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                            .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()

                                        VoucherLineNumber = VoucherLineNumber + 1
                                    Next i

                                    'UPDATE Receiver Header
                                    cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = GetReceiverNumber
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Else
                                    'UPDATE Receiver Header (old way)
                                    cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = DeleteReferenceNumber
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = DeleteReferenceNumber
                                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                End If
                            Else
                                'Does not need to be reset
                            End If
                        End If
                    Next

                    'Delete record from table
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND BatchStatus <> @BatchStatus", con)
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Clear text boxes on delete
                    ClearVariables()
                    ClearBatch()
                    LoadBatchNumber()
                    ShowBatchLines()
                    cboBatchNumber.Focus()
                End If
            ElseIf button = DialogResult.No Then
                cmdClear.Focus()
            End If
        End If
    End Sub

    Private Sub DeleteBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBatchToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If cboBatchNumber.Text = "" Then
            GlobalAPBatchNumber = 0
            GlobalAPPONumber = 0
            GlobalReceiverNumber = 0
            ClearVariables()
            ClearBatch()
            Me.Dispose()
            Me.Close()
        Else
            'Check Batch Status
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "POSTED"
            End Try
            con.Close()

            If BatchStatus = "POSTED" Then
                GlobalAPBatchNumber = 0
                GlobalAPPONumber = 0
                GlobalReceiverNumber = 0
                ClearVariables()
                ClearBatch()
                Me.Dispose()
                Me.Close()
            Else
                'Prompt before exiting
                Dim button As DialogResult = MessageBox.Show("Do you wish to save changes to this Batch?", "SAVE BATCH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    ''check to see if this batch is being edited by someone else
                    If isSomeoneEditing() Then
                        GlobalAPBatchNumber = 0
                        GlobalAPPONumber = 0
                        GlobalReceiverNumber = 0
                        ClearVariables()
                        ClearBatch()
                        Me.Dispose()
                        Me.Close()
                    End If
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, DivisionID = @DivisionID WHERE BatchNumber = @BatchNumber", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Load Updated Totals into Batch
                    LoadTotals()

                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = @BatchAmount, Locked = '' WHERE BatchNumber = @BatchNumber", con)
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = UpdateTotals

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    GlobalAPBatchNumber = 0
                    GlobalAPPONumber = 0
                    GlobalReceiverNumber = 0
                    ClearVariables()
                    ClearBatch()
                    Me.Dispose()
                    Me.Close()
                ElseIf button = DialogResult.No Then
                    GlobalAPBatchNumber = 0
                    GlobalAPPONumber = 0
                    GlobalReceiverNumber = 0
                    ClearVariables()
                    ClearBatch()
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        ' The return value specifies the previous state of the menu item (it is either      
        ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates   that the menu item does not exist.      
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
            Case MF_ENABLED
            Case MF_GRAYED
            Case &HFFFFFFFF
                Throw New Exception("The Close menu item does not exist.")
            Case Else
        End Select
    End Sub

    Private Sub APProcessBatch_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Private Sub cmdSelectRecurring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectRecurring.Click
        If canSelectRecurring() Then
            LockBatch()

            Dim newSelectRecurring As New SelectRecurringVoucher
            newSelectRecurring.setBatchNumber(Convert.ToInt32(cboBatchNumber.Text), cboDivisionID.Text)
            Me.Hide()
            If newSelectRecurring.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                ShowBatchLines()
            End If
            Me.Show()
            Me.BringToFront()
            checkRecurringToAdd()
        End If
    End Sub

    Private Function canSelectRecurring() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must select a Batch Number", "Select a Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        ''check to see if this batch is being edited by someone else
        If isSomeoneEditing() Then
            Return False
        End If
        Return True
    End Function

    ''resets the recurring vouchers back to the managed batch
    Private Sub resetRecurring()
        For i As Integer = 0 To dgvBatchItems.Rows.Count - 1
            cmd = New SqlCommand("SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND VoucherStatus = 'RECURRING'", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = dgvBatchItems.Rows(i).Cells("DeleteReferenceNumberColumn").Value
            If con.State = ConnectionState.Closed Then con.Open()
            Dim cnt As Integer = cmd.ExecuteScalar()
            con.Close()
            If cnt > 0 Then
                ''since a batch exists for this will send it back to the master
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = DeleteReferenceNumber, VoucherStatus = 'RECURRING', DeleteReferenceNumber = 0 WHERE BatchNumber = @BatchNumber AND VoucherNumber = @VoucherNumber", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = dgvBatchItems.Rows(i).Cells("VoucherNumberColumn").Value
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                If dgvBatchItems.Rows(i).Cells("VoucherSourceColumn").Value = "RECURRING VOUCHER" Then

                    ''Since no batch exsists for this recurring voucher to go back to, this will create one and sent it to the created one
                    Dim MAX1Statement As String = "SELECT MAX(BatchNumber) FROM ReceiptOfInvoiceBatchHeader"
                    Dim MAX1Command As New SqlCommand(MAX1Statement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastBatchNumber = CInt(MAX1Command.ExecuteScalar)
                    Catch ex As Exception
                        LastBatchNumber = 2200000
                    End Try
                    con.Close()

                    NextBatchNumber = LastBatchNumber + 1

                    cmd = New SqlCommand("INSERT INTO ReceiptOfInvoiceBatchHeader (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus) Values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @divisionID, @BatchStatus)", con)
                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber.ToString()
                        .Add("@BatchDate", SqlDbType.VarChar).Value = Today.ToString()
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = "0"
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "RECURRING VOUCHER"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "RECURRING"
                    End With
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = @NewBatch, VoucherStatus = 'RECURRING', DeleteReferenceNumber = 0 WHERE BatchNumber = @BatchNumber AND VoucherNumber = @VoucherNumber", con)
                    cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = dgvBatchItems.Rows(i).Cells("VoucherNumberColumn").Value
                    cmd.Parameters.Add("@NewBatch", SqlDbType.VarChar).Value = NextBatchNumber.ToString()
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text

                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            End If
        Next
        ''checks to see if a recurring is waiting to be added
        checkRecurringToAdd()
        ShowBatchLines()
    End Sub

    ''will flash the recurring ot select label for the user to get their attention
    Private Sub recurringWarning_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRecurringWarning.Tick
        If lblRecurringToSelect.Visible Then
            lblRecurringToSelect.Visible = False
            tmrRecurringWarning.Interval = 1000
        Else
            lblRecurringToSelect.Visible = True
            tmrRecurringWarning.Interval = 2000
        End If
    End Sub

    Private Sub checkRecurringToAdd()
        cmd = New SqlCommand("SELECT Count(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE VoucherStatus = 'RECURRING' AND DueDate <= @DueDate AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DueDate", SqlDbType.VarChar).Value = Today.Date.AddDays(15)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim cnt As Integer = cmd.ExecuteScalar()
        con.Close()
        If cnt > 0 Then
            lblRecurringToSelect.Visible = True
            If tmrRecurringWarning.Enabled = False Then
                tmrRecurringWarning.Start()
            End If
        Else
            lblRecurringToSelect.Visible = False
            If tmrRecurringWarning.Enabled Then
                tmrRecurringWarning.Stop()
            End If
        End If
    End Sub

    Private Sub SteelInvoicing(ByVal row As DataGridViewRow)
        Dim vouch As Integer = row.Cells("VoucherNumberColumn").Value
        cmd = New SqlCommand("SELECT ReceiptOfInvoiceVoucherLines.VoucherNumber, ReceiptOfInvoiceVoucherLines.VoucherLine, ReceiptOfInvoiceVoucherLines.Quantity, ReceiptOfInvoiceVoucherLines.UnitCost, ReceiptOfInvoiceVoucherLines.ExtendedAmount, ReceiptOfInvoiceVoucherLines.ReceiverNumber, ReceiptOfInvoiceVoucherLines.ReceiverLine, SteelReceivingLineTable.ReceiveWeight, SteelReceivingLineTable.SteelExtendedCost FROM ReceiptOfInvoiceVoucherLines" _
                             + " INNER JOIN SteelReceivingLineTable ON ReceiptOfInvoiceVoucherLines.ReceiverNumber = SteelReceivingLineTable.SteelReceivingHeaderKey AND ReceiptOfInvoiceVoucherLines.ReceiverLine = SteelReceivingLineTable.SteelReceivingLineKey" _
                             + " WHERE VoucherNumber = @VoucherNumber ORDER BY VoucherLine", con)
        cmd.Parameters.Add("@VoucherNumber", SqlDbType.Int).Value = row.Cells("VoucherNumberColumn").Value

        Dim dt As New Data.DataTable("ReceiptOfInvoiceVoucherLines")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)

        For Each dtRow As Data.DataRow In dt.Rows
            If (dtRow.Item("SteelExtendedCost") <> dtRow.Item("ExtendedAmount")) And (dtRow.Item("ReceiveWeight") = dtRow.Item("Quantity")) Then
                Dim origCredit As String = GLCreditAccount
                Dim OrigDebit As String = GLDebitAccount
                GLCreditAccount = "12000"
                'Write to Debit Side of a Voucher Cost Adjustment
                CostAdjustmentAmount = Math.Round(dtRow.Item("ExtendedAmount") - dtRow.Item("SteelExtendedCost"), 2, MidpointRounding.AwayFromZero)
                ''checks to see if the amount is negative, if so will switch the debit, credit accounts and abs the difference
                If CostAdjustmentAmount < 0 Then
                    CostAdjustmentAmount = Math.Abs(CostAdjustmentAmount)
                Else
                    Dim tmp As String = GLCreditAccount
                    GLCreditAccount = GLDebitAccount
                    GLDebitAccount = tmp
                End If
                ''updates the cost of the steel on the PO so that when more is received the cost will be correct
                updateSteelPOCost(dtRow.Item("UnitCost"), dtRow.Item("ReceiverNumber"), dtRow.Item("ReceiverLine"))
                ''updates the costing tier for the steel so that it is correct
                updateSteelCostTier(dtRow.Item("UnitCost"), dtRow.Item("ReceiverNumber"), dtRow.Item("ReceiverLine"))
                ''adds the adjustment to the GL
                addCostAdjustmentGLEntry(dtRow.Item("VoucherNumber"), dtRow.Item("VoucherLine"), dtRow.Item("ReceiverNumber"), dtRow.Item("ReceiverLine"))
                ''Resets the GL account variables to their original values
                GLCreditAccount = origCredit
                GLDebitAccount = OrigDebit
            End If
            ''updates the SteelReceivingLineTable Line so that it cant be invoiced again
            updateSteelReceiving(dtRow.Item("ReceiverNumber"), dtRow.Item("ReceiverLine"))
        Next
        ''checks the SteelReceivingLines to see if there are anymore lines open, if not will clost the SteelRecevingHeaderTable
        checkSteelReceivingLinesOpen(dt.Rows(0).Item("ReceiverNumber"))
        If con.State = ConnectionState.Open Then con.Close()

    End Sub

    Private Sub addCostAdjustmentGLEntry(ByVal voucherNumber As Integer, ByVal voucherLine As Integer, ByVal Receiver As Integer, ByVal ReceiverLine As Integer)
        cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)
        cmd.CommandText += " (@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"

        With cmd.Parameters
            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLDebitAccount
            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment(STEEL)"
            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Receiver Number " & Receiver.ToString
            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = voucherNumber.ToString
            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = voucherLine.ToString
            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        End With

        If cboDivisionID.Text.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        cmd.CommandText += ", (@Key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"
        With cmd.Parameters
            .Add("@GLAccountNumber1", SqlDbType.VarChar).Value = GLCreditAccount
            .Add("@GLTransactionDebitAmount1", SqlDbType.VarChar).Value = 0
            .Add("@GLTransactionCreditAmount1", SqlDbType.VarChar).Value = CostAdjustmentAmount
        End With
        cmd.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "APProcessBatch - addCostAdjustmentGLEntry --Error Inserting GL DEBIT transaction for Steel Cost adjustment"
            ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub updateSteelPOCost(ByVal unitCost As Double, ByVal Receiver As Integer, ByVal ReceiverLine As Integer)
        cmd = New SqlCommand(" UPDATE SteelPurchaseLine SET PurchasePricePerPound = @PurchasePricePerPound, ExtendedAmount = ROUND(@PurchasePricePerPound * PurchaseQuantity, 2) FROM SteelPurchaseLine INNER JOIN SteelReceivingCoilLines ON SteelPurchaseLine.SteelPurchaseOrderHeaderKey = SteelReceivingCoilLines.PONumber AND SteelPurchaseLine.SteelPurchaseLineNumber = SteelReceivingCoilLines.POLineNumber  WHERE SteelReceivingHeaderKey = @SteelReceivingKey AND SteelReceivingLineKey = @SteelReceivingLineKey;", con)
        cmd.Parameters.Add("@PurchasePricePerPound", SqlDbType.VarChar).Value = Math.Round(unitCost, 5, MidpointRounding.AwayFromZero)
        cmd.Parameters.Add("@SteelReceivingKey", SqlDbType.VarChar).Value = Receiver
        cmd.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = ReceiverLine

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        ''updates the totals in the PO
        updatePOHeaderTable(Receiver, ReceiverLine)
    End Sub

    Private Sub updatePOHeaderTable(ByVal Receiver As Integer, ByVal ReceiverLine As Integer)
        Dim SteelTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = (SELECT TOP 1 PONumber FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingKey AND SteelReceivingLineKey = @SteelReceivingLineKey);"
        Dim SteelTotalCommand As New SqlCommand(SteelTotalStatement, con)
        SteelTotalCommand.Parameters.Add("@SteelReceivingKey", SqlDbType.VarChar).Value = Receiver
        SteelTotalCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = ReceiverLine
        Dim SteelTotal As Double = 0

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelTotal = CDbl(SteelTotalCommand.ExecuteScalar)
        Catch ex As Exception
            SteelTotal = 0
        End Try
        con.Close()

        cmd = New SqlCommand("UPDATE SteelPurchaseOrderHeader SET SteelTotal = @SteelTotal, SteelPurchaseTotal = (FreightTotal + OtherTotal + @SteelTotal) WHERE SteelPurchaseOrderKey = (SELECT TOP 1 PONumber FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingKey AND SteelReceivingLineKey = @SteelReceivingLineKey);", con)
        With cmd.Parameters
            .Add("@SteelTotal", SqlDbType.VarChar).Value = SteelTotal
            cmd.Parameters.Add("@SteelReceivingKey", SqlDbType.VarChar).Value = Receiver
            cmd.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = ReceiverLine
        End With
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "APProcessBatch - updatePOHeaderTable --Error updating Steel PO Cost Per Pound"
            ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

    End Sub

    Private Sub updateSteelCostTier(ByVal unitCost As Double, ByVal Receiver As Integer, ByVal ReceiverLine As Integer)
        cmd = New SqlCommand("UPDATE SteelCostingTable SET SteelCostPerPound = @CostPerPound WHERE ReferenceNumber = @SteelReceivingKey AND ReferenceLine = @SteelReceivingLineKey;", con)
        cmd.Parameters.Add("@CostPerPound", SqlDbType.VarChar).Value = Math.Round(unitCost, 5, MidpointRounding.AwayFromZero)
        cmd.Parameters.Add("@SteelReceivingKey", SqlDbType.VarChar).Value = Receiver
        cmd.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = ReceiverLine

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "APProcessBatch - updateSteelCostTier --Error updating Cost Tier"
            ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try


    End Sub

    Private Sub updateSteelReceiving(ByVal Receiver As Integer, ByVal ReceiverLine As Integer)
        'Close Receiver
        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE SteelReceivingHeaderKey = @ReceivingHeaderKey AND SteelReceivingLineKey = @ReceivingLineKey;", con)

        With cmd.Parameters
            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Receiver
            .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = ReceiverLine
            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
            .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
        End With
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "APProcessBatch - updateSteelReceiving --Error updating Receiving Status"
            ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

    End Sub

    Private Sub checkSteelReceivingLinesOpen(ByVal Receiver As Integer)
        cmd = New SqlCommand("SELECT COUNT(SteelReceivingHeaderKey) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @ReceivingHeaderKey;", con)
        cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Receiver

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() = 0 Then
            cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = 'CLOSED' WHERE SteelReceivingHeaderKey = @ReceivingHeaderKey;", con)
            cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = Receiver
            cmd.ExecuteNonQuery()
        End If
        con.Close()
    End Sub

    Private Sub cmdSelectSteelReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectSteelReturn.Click
        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else

            'Check Batch Status
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = "POSTED"
            End Try
            con.Close()

            If BatchStatus = "POSTED" Or BatchStatus = "CLOSED" Then
                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalAPDivisionID = cboDivisionID.Text

                Dim NewAPProcessReturns As New APProcessReturns
                NewAPProcessReturns.Show()

                Me.Dispose()
                Me.Close()
            Else
                ''check to see if this batch is being edited by someone else
                If isSomeoneEditing() Then
                    Exit Sub
                End If
                Try
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, Locked = @Locked WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Save Open Return --- Update Batch Table"
                    ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalAPDivisionID = cboDivisionID.Text

                Dim NewAPProcessSteelReturns As New APProcessSteelReturns
                NewAPProcessSteelReturns.Show()

                isloaded = False

                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Function isSomeoneEditing() As Boolean
        If Val(cboBatchNumber.Text) <> 0 Then
            cmd = New SqlCommand("SELECT Locked FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID;", con)
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
        End If
        Return False
    End Function

    Private Sub LockBatch()
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET Locked = @Locked WHERE BatchNumber = @BatchNumber;", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET Locked = '' WHERE BatchNumber = @BatchNumber AND Locked = @Locked;", con)
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

    Private Sub APProcessBatch_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ''unlocks the batch if the user is the one that has it locked
        unlockBatch()
    End Sub

    Private Sub UnLockBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockBatchToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this batch?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET Locked = '' WHERE BatchNumber = @BatchNumber;", con)
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

    Private Sub cmdSplitSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSplitSelected.Click
        If canSplit() Then
            cmd = New SqlCommand("DECLARE @BatchNumber as int = (SELECT isnull(MAX(BatchNumber)+1, 2200001) FROM ReceiptOfInvoiceBatchHeader); Insert Into ReceiptOfInvoiceBatchHeader(BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, UserID)Values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @UserID); UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = @BatchNumber WHERE", con)
            With cmd.Parameters
                .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            End With

            For i As Integer = 0 To dgvBatchItems.SelectedRows.Count - 1
                If i = 0 Then
                    cmd.CommandText += " (VoucherNumber = @VoucherNumber" + i.ToString()
                Else
                    cmd.CommandText += " OR VoucherNumber = @VoucherNumber" + i.ToString()
                End If

                With cmd.Parameters
                    .Add("@VoucherNumber" + i.ToString(), SqlDbType.Int).Value = dgvBatchItems.SelectedRows(i).Cells("VoucherNumberColumn").Value
                End With
            Next
            'Write Data to Batch Header Database Table

            cmd.CommandText += ") AND DivisionID = @DivisionID; SELECT @BatchNumber;"

            Dim newBatchNumber As Integer = 0

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            If Not IsDBNull(obj) Then
                newBatchNumber = Convert.ToInt32(obj)
            End If

            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = (SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @CurrentBatchNumber) WHERE BatchNumber = @CurrentBatchNumber; UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = (SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @NewBatchNumber) WHERE BatchNumber = @NewBatchNumber", con)
            cmd.Parameters.Add("@CurrentBatchNumber", SqlDbType.Int).Value = cboBatchNumber.Text
            cmd.Parameters.Add("@NewBatchNumber", SqlDbType.Int).Value = newBatchNumber

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Dim currentBatch As String = cboBatchNumber.Text
            LoadBatchNumber()
            cboBatchNumber.Text = currentBatch
            MessageBox.Show("Lines have been split to batch #" + newBatchNumber.ToString(), "Split success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canSplit() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must enter a batch number", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If dgvBatchItems.Rows.Count = 0 Then
            MessageBox.Show("You have lines to split a batch", "Enter some lines", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvBatchItems.SelectedRows.Count = 0 Then
            MessageBox.Show("You must select a row to split to a new batch", "Select a row", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub ManuallyCloseBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManuallyCloseBatchToolStripMenuItem.Click
        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            'Do nothing
            Exit Sub
        End If

        If txtBatchStatus.Text <> "OPEN" Then
            'Do nothing
            Exit Sub
        End If
        '*********************************************************************************************
        'Write to Audit Trail Table
        Dim AuditComment As String = ""
        Dim AuditBatchNumber As Integer = 0
        Dim strBatchNumber As String = ""

        AuditBatchNumber = Val(cboBatchNumber.Text)
        strBatchNumber = CStr(AuditBatchNumber)
        AuditComment = "Batch #" + strBatchNumber + " for an AP Batch was manually closed one " + Today()

        Try
            cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

            With cmd.Parameters
                .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@AuditType", SqlDbType.VarChar).Value = "AP Process Batch (Manual Close)"
                .Add("@AuditAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strBatchNumber
                .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try
        '************************************************************************************************
        'Close Batch
        Try
            'Write Data to Batch Header Database Table
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchStatus = @BatchStatus, Locked = @Locked WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@BatchDescription", SqlDbType.VarChar).Value = "Manual Close"
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"
                .Add("@Locked", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Batch is now posted and can be paid.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "AP Process Batch --- Fail on manual close."
            ErrorReferenceNumber = "Batch # " + cboBatchNumber.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Public Sub CreateNewBatch()
        If Me.dgvBatchItems.RowCount = 0 Then
            MsgBox("You must have lines in the datagrid.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must have a valid batch number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim SelectedVoucher As Integer = 0
        Dim ReserveBatchNumber As Integer = 0
        Dim NewBatchTotal As Double = 0
        Dim OldBatchTotal As Double = 0

        ReserveBatchNumber = Val(cboBatchNumber.Text)

        'Get Next Batch Number
        Dim MAXStatement As String = "SELECT MAX(BatchNumber) FROM ReceiptOfInvoiceBatchHeader"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 99900000
        End Try
        con.Close()

        NextBatchNumber = LastBatchNumber + 1

        'Create New Batch
        Try
            'Write Data to Invoice Header Database Table
            cmd = New SqlCommand("INSERT INTO ReceiptOfInvoiceBatchHeader (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, PrintDate) values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @PrintDate)", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@Locked", SqlDbType.VarChar).Value = ""
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@PrintDate", SqlDbType.VarChar).Value = Now()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox("New Batch not created.", MsgBoxStyle.OkOnly)
            Exit Sub
        End Try

        Try
            For Each row As DataGridViewRow In Me.dgvBatchItems.SelectedRows
                Try
                    SelectedVoucher = row.Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    SelectedVoucher = 0
                End Try

                'Write Data to Invoice Header Database Table
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = @BatchNumber WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = SelectedVoucher
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next
            '***************************************************************************************************
            'Get new Batch Total
            Dim SUMTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim SUMTotalCommand As New SqlCommand(SUMTotalStatement, con)
            SUMTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
            SUMTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                NewBatchTotal = CDbl(SUMTotalCommand.ExecuteScalar)
            Catch ex As Exception
                NewBatchTotal = 0
            End Try
            con.Close()

            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchAmount", SqlDbType.VarChar).Value = NewBatchTotal
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '*************************************************************************************************
            'Get Old Batch Total
            Dim SUMTotal2Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim SUMTotal2Command As New SqlCommand(SUMTotal2Statement, con)
            SUMTotal2Command.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            SUMTotal2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                OldBatchTotal = CDbl(SUMTotal2Command.ExecuteScalar)
            Catch ex As Exception
                OldBatchTotal = 0
            End Try
            con.Close()

            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchAmount", SqlDbType.VarChar).Value = OldBatchTotal
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '***************************************************************************************************
            'Clear variables and reload form
            ClearVariables()
            LoadBatchNumber()

            cboBatchNumber.Text = ReserveBatchNumber
            txtBatchTotal.Text = OldBatchTotal
            ShowBatchLines()

            MsgBox("New Batch Created.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("There was a problem creating the new batch.", MsgBoxStyle.OkOnly)
        End Try
    End Sub
End Class