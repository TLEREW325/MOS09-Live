Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Net.Mail
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class APProcessForPayment
    Inherits System.Windows.Forms.Form

    Dim DiscountDays, CheckPositionTotal3, CheckPositionTotal2, CheckPositionTotal, VoucherNumber, PONumber As Integer
    Dim DiscountGLAccount, DebitBatchAccount, CreditBatchAccount, CheckVendorID, InvoiceNumber, InvoiceDate, ReceiptDate, DueDate, DiscountDate, VendorID, Comment, PaymentTerms As String
    Dim SUMVoucherTotal3, SUMDiscountAmount3, SUMDiscount3, SUMVoucherTotal2, SUMDiscountAmount2, SUMDiscount2, SUMDiscountAmount, SUMDiscount, SUMVoucherTotal, BatchTotal, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, DiscountAmount, PaymentAmount As Double
    Dim BatchExpenseAccount, BatchVendorClass, CheckType, VendorClass, CheckPrintedStatus, CheckStatus, BatchDate, BatchDescription, BatchStatus As String
    Dim SUMDiscountsInBatch, SUMChecksInBatch, BatchAmount, SUMInvoiceTotal, UndistributedAmount As Double
    Dim CountVendorID, GetPositionNumber, CountVendorLines, CountLines, counter As Integer
    Dim IsExtendedCheck As String = ""
    Dim strCSVFileName As String = ""
    Dim strFileNamePrefix As String = ""
    Dim strCanadianCheckType As String = ""
    Dim strACHFileName As String = ""
    Dim ACHBatchNumber As Integer = 0
    Dim strACHBatchNumber As String = ""
    Dim IsExpenseAccount As String = ""
    Dim SubjectCheckAmount As Double = 0
    Dim strSubjectCheckAmount As String = ""
    Dim NextBatchNumber, LastBatchNumber, LastCheckNumber, NextCheckNumber, GetCheckNumber, LastTransactionNumber, NextTransactionNumber, NextGLNumber, LastGLNumber As Int64

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim AutoprintBatchReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

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
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, APCheckAdapter, APReportAdapter As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, APCheckDataset, APReportDataset As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim isloaded As Boolean = False
    Dim lastBatch As String = ""

    'Form Operations

    Private Sub APProcessForPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Call Disable(Me)

        LoadCurrentDivision()
    
        'Set Company Default
        If EmployeeCompanyCode = "ADM" And ReloadAPDivisionCode = "" Then
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        ElseIf EmployeeCompanyCode = "ADM" And ReloadAPDivisionCode <> "" Then
            cboDivisionID.Enabled = False
            cboDivisionID.Text = ReloadAPDivisionCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        If GlobalAPPFPCheckBox = "YES" Then
            chkExpenseAccount.Checked = True
        Else
            chkExpenseAccount.Checked = False
        End If

        If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
            If GlobalVendorClass <> "" Then
                cboVendorClass.Text = GlobalVendorClass
            End If

            cmdPrintNewChecks.Visible = False
            cmdPrintChecks.Visible = True
        Else
            cmdPrintNewChecks.Visible = True
            cmdPrintChecks.Visible = False
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

    Private Sub APProcessForPayment_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Private Sub APProcessForPayment_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ''unlocks the batch if the user is the one that has it locked
        unlockBatch()
    End Sub

    'Load datasets into controls/datagrid

    Public Sub ShowBatchLines()
        cmd = New SqlCommand("SELECT * FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID ORDER BY VendorID, InvoiceDate", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APVoucherTable")
        dgvBatchLines.DataSource = ds.Tables("APVoucherTable")
        cboDeleteLines.DataSource = ds.Tables("APVoucherTable")
        con.Close()

        FormatWhitePaperChecks()
    End Sub

    Public Sub ClearBatchLines()
        Me.dgvBatchLines.DataSource = Nothing
    End Sub

    Public Sub LoadBatchNumber()
        cmd = New SqlCommand("SELECT BatchNumber FROM APProcessPaymentBatch WHERE DivisionID = @DivisionID And (BatchStatus = @BatchStatus or BatchStatus = @BatchStatus1 OR BatchStatus = @BatchStatus2)", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        cmd.Parameters.Add("@BatchStatus1", SqlDbType.VarChar).Value = "PRINTED"
        cmd.Parameters.Add("@BatchStatus2", SqlDbType.VarChar).Value = "PENDING"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "APProcessPaymentBatch")
        cboBatchNumber.DataSource = ds1.Tables("APProcessPaymentBatch")
        con.Close()
        cboBatchNumber.SelectedIndex = -1
    End Sub

    'Load Data subroutines

    Public Sub SelectDiscountDays()
        'Retrieve Discount Days for selected Payment Term
        Dim DiscountDaysStatement As String = "SELECT DiscountDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DiscountDaysCommand As New SqlCommand(DiscountDaysStatement, con)
        DiscountDaysCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = PaymentTerms

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DiscountDays = CInt(DiscountDaysCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountDays = 0
        End Try
        con.Close()
    End Sub

    Public Sub LoadBatchData()
        'Extract and loab Batch Data
        Dim BatchDateStatement As String = "SELECT BatchDate FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchDateCommand As New SqlCommand(BatchDateStatement, con)
        BatchDateCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchAmountStatement As String = "SELECT BatchAmount FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchAmountCommand As New SqlCommand(BatchAmountStatement, con)
        BatchAmountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchDescriptionStatement As String = "SELECT BatchDescription FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchDescriptionCommand As New SqlCommand(BatchDescriptionStatement, con)
        BatchDescriptionCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchStatusStatement As String = "SELECT BatchStatus FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckTypeStatement As String = "SELECT CheckType FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim CheckTypeCommand As New SqlCommand(CheckTypeStatement, con)
        CheckTypeCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        CheckTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchVendorClassStatement As String = "SELECT VendorClass FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchVendorClassCommand As New SqlCommand(BatchVendorClassStatement, con)
        BatchVendorClassCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchExpenseAccountStatement As String = "SELECT ExpenseAccount FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchExpenseAccountCommand As New SqlCommand(BatchExpenseAccountStatement, con)
        BatchExpenseAccountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchExpenseAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

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
            BatchDescription = "PROCESS FOR PAYMENT"
        End Try
        Try
            BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            BatchStatus = ""
        End Try
        Try
            CheckType = CStr(CheckTypeCommand.ExecuteScalar)
        Catch ex As Exception
            CheckType = ""
        End Try
        Try
            BatchVendorClass = CStr(BatchVendorClassCommand.ExecuteScalar)
        Catch ex As Exception
            BatchVendorClass = ""
        End Try
        Try
            BatchExpenseAccount = CStr(BatchExpenseAccountCommand.ExecuteScalar)
        Catch ex As Exception
            BatchExpenseAccount = "NO"
        End Try
        con.Close()

        If BatchExpenseAccount = "YES" Then
            chkExpenseAccount.Checked = True
        Else
            chkExpenseAccount.Checked = False
        End If

        dtpBatchCreationDate.Text = BatchDate
        txtBatchTotal.Text = BatchAmount
        txtBatchDescription.Text = BatchDescription
        txtBatchStatus.Text = BatchStatus
        cboCheckType.Text = CheckType
        cboVendorClass.Text = BatchVendorClass

        If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
            'Do nothing
        Else
            cboVendorClass.Text = "STANDARD"
        End If

        If CheckType = "" Then
            cboCheckType.Enabled = True
        Else
            cboCheckType.Enabled = False
        End If

        'If Batch Status is POSTED - disable all buttons
        If BatchStatus = "POSTED" Then
            cmdCheckRegister.Enabled = False
            cmdDelete.Enabled = False
            cmdPostBatch.Enabled = False
            cmdSave.Enabled = False
            cmdSelectLines.Enabled = False
            SaveBatchToolStripMenuItem.Enabled = False
            DeleteBatchToolStripMenuItem.Enabled = False
            gpxDeleteVoucher.Enabled = False
            gpxNewBatch.Enabled = False
        ElseIf BatchStatus = "PRINTED" Then
            cmdCheckRegister.Enabled = True
            cmdDelete.Enabled = True
            cmdPostBatch.Enabled = True
            cmdSave.Enabled = True
            cmdSelectLines.Enabled = True
            SaveBatchToolStripMenuItem.Enabled = True
            DeleteBatchToolStripMenuItem.Enabled = True
            gpxDeleteVoucher.Enabled = False
            gpxNewBatch.Enabled = False
        Else
            cmdCheckRegister.Enabled = True
            cmdDelete.Enabled = True
            cmdPostBatch.Enabled = True
            cmdSave.Enabled = True
            cmdSelectLines.Enabled = True
            SaveBatchToolStripMenuItem.Enabled = True
            DeleteBatchToolStripMenuItem.Enabled = True
            gpxDeleteVoucher.Enabled = True
            gpxNewBatch.Enabled = True
        End If
    End Sub

    Public Sub LoadBatchStatus()
        Dim BatchStatusStatement As String = "SELECT BatchStatus FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            BatchStatus = ""
        End Try
        con.Close()

        txtBatchStatus.Text = BatchStatus

        If BatchStatus = "PRINTED" Then
            gpxDeleteVoucher.Enabled = False
            gpxNewBatch.Enabled = False
        Else
            gpxDeleteVoucher.Enabled = True
            gpxNewBatch.Enabled = True
        End If
    End Sub

    Public Sub LoadBatchTotals()
        Dim SUMInvoiceTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim SUMInvoiceTotalCommand As New SqlCommand(SUMInvoiceTotalStatement, con)
        SUMInvoiceTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        SUMInvoiceTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CountLinesStatement As String = "SELECT COUNT(BatchNumber) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim CountLinesCommand As New SqlCommand(CountLinesStatement, con)
        CountLinesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        CountLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SUMDiscountAmountStatement As String = "SELECT SUM(DiscountAmount) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim SUMDiscountAmountCommand As New SqlCommand(SUMDiscountAmountStatement, con)
        SUMDiscountAmountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        SUMDiscountAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SUMInvoiceTotal = CDbl(SUMInvoiceTotalCommand.ExecuteScalar)
            SUMInvoiceTotal = Math.Round(SUMInvoiceTotal, 2)
        Catch ex As Exception
            SUMInvoiceTotal = 0
        End Try
        Try
            CountLines = CInt(CountLinesCommand.ExecuteScalar)
        Catch ex As Exception
            CountLines = 0
        End Try
        Try
            SUMDiscountAmount = CDbl(SUMDiscountAmountCommand.ExecuteScalar)
            SUMDiscountAmount = Math.Round(SUMDiscountAmount, 2)
        Catch ex As Exception
            SUMDiscountAmount = 0
        End Try
        con.Close()

        BatchAmount = SUMInvoiceTotal
        BatchTotal = SUMInvoiceTotal - SUMDiscountAmount

        UndistributedAmount = BatchAmount - BatchTotal
        txtUndistributedAmount.Text = FormatCurrency(UndistributedAmount, 2)
        txtCurrentTotal.Text = FormatCurrency(BatchTotal, 2)
        txtEntryNumber.Text = CountLines
    End Sub

    'Validation and error checking

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
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
        If Val(cboBatchNumber.Text) <> 0 Then
            cmd = New SqlCommand("SELECT Locked FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            Dim personEditing As String = "NONE"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If Not IsDBNull(reader.Item("Locked")) Then
                    personEditing = reader.Item("Locked")
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
        cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET Locked = @Locked WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET Locked = '' WHERE BatchNumber = @BatchNumber AND Locked = @Locked", con)
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

    Public Sub LoadVendorClassForCanadian()
        'Check to see if batch is canadian or american

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            If Me.dgvBatchLines.RowCount > 0 Then
                'Get the voucher number of one voucher in batch
                Dim GetVoucherNumber As Integer = 0

                Dim GetVoucherNumberStatement As String = "SELECT MIN(VoucherNumber) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                Dim GetVoucherNumberCommand As New SqlCommand(GetVoucherNumberStatement, con)
                GetVoucherNumberCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                GetVoucherNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetVoucherNumber = CInt(GetVoucherNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetVoucherNumber = 0
                End Try
                con.Close()

                'Get vendor class of voucher retrieved in first step
                Dim GetVendorClass As String = ""

                Dim GetVendorClassStatement As String = "SELECT VendorClass FROM ReceiptOfVoucherBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim GetVendorClassCommand As New SqlCommand(GetVendorClassStatement, con)
                GetVendorClassCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GetVoucherNumber
                GetVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetVendorClass = CStr(GetVendorClassCommand.ExecuteScalar)
                Catch ex As Exception
                    GetVendorClass = "Canadian"
                End Try
                con.Close()

                'Set vendor class in form
                cboVendorClass.Text = GetVendorClass
            End If
        End If
    End Sub

    'Clear Functions

    Public Sub ClearData()
        cboBatchNumber.Text = ""
        cboBatchNumber.SelectedIndex = -1
        cboDeleteLines.SelectedIndex = -1
        cboCheckType.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1

        dtpBatchCreationDate.Text = ""
        dtpDueDate.Text = ""

        txtBatchDescription.Text = "PROCESS FOR PAYMENT"
        txtBatchTotal.Clear()
        txtCurrentTotal.Clear()
        txtEntryNumber.Clear()
        txtUndistributedAmount.Clear()
        txtBatchStatus.Clear()

        gpxDeleteVoucher.Enabled = True
        gpxNewBatch.Enabled = True
        chkExpenseAccount.Checked = False
        cboCheckType.Enabled = True

        'If Batch Status is POSTED - disable all buttons
        If BatchStatus = "POSTED" Then
            cmdCheckRegister.Enabled = False
            cmdDelete.Enabled = False
            cmdPostBatch.Enabled = False
            cmdSave.Enabled = False
            cmdSelectLines.Enabled = False
            SaveBatchToolStripMenuItem.Enabled = False
            DeleteBatchToolStripMenuItem.Enabled = False
        Else
            cmdCheckRegister.Enabled = True
            cmdDelete.Enabled = True
            cmdPostBatch.Enabled = True
            cmdSave.Enabled = True
            cmdSelectLines.Enabled = True
            SaveBatchToolStripMenuItem.Enabled = True
            DeleteBatchToolStripMenuItem.Enabled = True
        End If

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LoadVendorClassForCanadian()
        Else
            cboVendorClass.SelectedIndex = -1
        End If

        cmdGenerateBatchNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        GetCheckNumber = 0
        VoucherNumber = 0
        PONumber = 0
        CheckVendorID = ""
        InvoiceNumber = ""
        InvoiceDate = ""
        ReceiptDate = ""
        DueDate = ""
        DiscountDate = ""
        VendorID = ""
        Comment = ""
        PaymentTerms = ""
        SUMVoucherTotal = 0
        BatchTotal = 0
        ProductTotal = 0
        InvoiceFreight = 0
        InvoiceSalesTax = 0
        InvoiceTotal = 0
        DiscountAmount = 0
        PaymentAmount = 0
        BatchDate = ""
        BatchDescription = ""
        BatchStatus = ""
        SUMChecksInBatch = 0
        BatchAmount = 0
        SUMInvoiceTotal = 0
        UndistributedAmount = 0
        LastGLNumber = 0
        NextGLNumber = 0
        LastCheckNumber = 0
        NextCheckNumber = 0
        CountLines = 0
        NextBatchNumber = 0
        LastBatchNumber = 0
        counter = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        GlobalAPBatchNumber = 0
        CheckPrintedStatus = ""
        SUMDiscount = 0
        ReloadAPDivisionCode = ""
        SUMVoucherTotal2 = 0
        SUMDiscountAmount2 = 0
        GetPositionNumber = 0
        SUMDiscount2 = 0
        CountVendorID = 0
        DebitBatchAccount = ""
        DiscountGLAccount = ""
        VendorClass = ""
        CheckPositionTotal = 0
        CheckPositionTotal2 = 0
        IsExtendedCheck = ""
        strCSVFileName = ""
        strFileNamePrefix = ""
        strCanadianCheckType = ""
        CheckType = ""
        BatchExpenseAccount = ""
        GlobalAPPFPCheckBox = "NO"

        chkExpenseAccount.Checked = False

        'If Batch Status is POSTED - disable all buttons
        If BatchStatus = "POSTED" Then
            cmdCheckRegister.Enabled = False
            cmdDelete.Enabled = False
            cmdPostBatch.Enabled = False
            cmdSave.Enabled = False
            cmdSelectLines.Enabled = False
            SaveBatchToolStripMenuItem.Enabled = False
            DeleteBatchToolStripMenuItem.Enabled = False
        Else
            cmdCheckRegister.Enabled = True
            cmdDelete.Enabled = True
            cmdPostBatch.Enabled = True
            cmdSave.Enabled = True
            cmdSelectLines.Enabled = True
            SaveBatchToolStripMenuItem.Enabled = True
            DeleteBatchToolStripMenuItem.Enabled = True
        End If
    End Sub

    'Command Buttons

    Private Sub cmdGenerateBatchNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateBatchNumber.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch(lastBatch)
        End If
        'Clear form with new batch number
        ClearVariables()
        ClearData()
        ShowBatchLines()

        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a valid division.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Find the next Batch Number to use
        Dim MAXStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 99900000
        End Try
        con.Close()

        NextBatchNumber = LastBatchNumber + 1
        cboBatchNumber.Text = NextBatchNumber

        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("A valid Batch Number must be selected to create a batch.", MsgBoxStyle.OkOnly)
            cboBatchNumber.Focus()
        Else
            Try
                'Write Data to Batch Header Database Table
                cmd = New SqlCommand("Insert Into APProcessPaymentBatch(BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass, ExpenseAccount)Values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass, @ExpenseAccount)", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                    .Add("@ExpenseAccount", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
        End If

        'Load Default Data
        LoadBatchData()
        LoadBatchTotals()
        ShowBatchLines()
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid AP Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            ''check to see if this batch is being edited by someone else
            If isSomeoneEditing() Then
                Exit Sub
            End If

            If cboDivisionID.Text = "ADM" Then
                MsgBox("You must have a valid division selected.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            LoadBatchStatus()

            If BatchStatus = "PRINTED" Then
                MsgBox("You cannot delete a voucher from a batch after a check is printed.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Voucher(s) from the batch?", "DELETE VOUCHER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                LockBatch()

                Try
                    'Check to see if multi-selected vouchers are present
                    If Me.dgvBatchLines.SelectedRows.Count > 1 Then
                        For Each row As DataGridViewRow In Me.dgvBatchLines.SelectedRows
                            Try
                                VoucherNumber = row.Cells("VoucherNumberColumn").Value
                            Catch ex As Exception
                                VoucherNumber = 0
                            End Try

                            'Reset payable to be re-selected
                            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Delete Payment Voucher
                            cmd = New SqlCommand("DELETE FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                            cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Next
                    Else
                        'Reset payable to be re-selected
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboDeleteLines.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Delete Payment Voucher
                        cmd = New SqlCommand("DELETE FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboDeleteLines.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                Catch ex As Exception
                    MsgBox("Voucher cannot be deleted from Batch. Check all data.", MsgBoxStyle.OkOnly)
                End Try

                'Reload Totals
                LoadBatchTotals()

                'Load Expense Account based on Checkbox
                If chkExpenseAccount.Checked = True Then
                    IsExpenseAccount = "YES"
                Else
                    IsExpenseAccount = "NO"
                End If

                'UPDATE Totals in Batch
                cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, CheckType = @CheckType, VendorClass = @VendorClass, ExpenseAccount = @ExpenseAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = txtBatchStatus.Text
                    .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                    .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowBatchLines()
            ElseIf button = DialogResult.No Then
                cmdClear.Focus()
            End If
        End If
    End Sub

    Private Sub cmdClearGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearGrid.Click
        dtpDueDate.Text = ""
        ShowBatchLines()
    End Sub

    Private Sub cmdSelectLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectLines.Click
        If chkExpenseAccount.Checked = True Then
            GlobalAPPFPCheckBox = "YES"
        Else
            GlobalAPPFPCheckBox = "NO"
        End If
        '************************************************************************************
        'Validate check type
        If cboCheckType.Text = "" Then
            MsgBox("You must select type of check.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            Dim CheckTheCheckType As String = ""
            Dim ValidateCheckType As String = ""

            CheckTheCheckType = cboCheckType.Text
            Select Case CheckTheCheckType
                Case "STANDARD"
                    ValidateCheckType = "OK"
                Case "FEDEX"
                    ValidateCheckType = "OK"
                Case "INTERCOMPANY"
                    ValidateCheckType = "OK"
                Case "ACH"
                    ValidateCheckType = "OK"
                Case Else
                    ValidateCheckType = "NOT OK"
            End Select

            If ValidateCheckType = "NOT OK" Then
                MsgBox("Invalid check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        '************************************************************************************
        If cboBatchNumber.Text = "" Then
            MsgBox("You must select a valid batch number or create a new one to proceed.", MsgBoxStyle.OkOnly)
        Else
            ''check to see if this batch is being edited by someone else
            If isSomeoneEditing() Then
                Exit Sub
            End If

            If cboDivisionID.Text = "ADM" Then
                MsgBox("You must have a valid division selected.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '**************************************************************************************************
            'Update any Receipt Of Invoice records that have a null value
            Try
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET OnHold = @OnHold WHERE DivisionID = @DivisionID AND OnHold IS NULL", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip
            End Try

            If chkExpenseAccount.Checked = True Then
                IsExpenseAccount = "YES"
            Else
                IsExpenseAccount = "NO"
            End If
            '********************************************************************************************************
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                'Check to make sure Canadian or American check type is selected
                If cboVendorClass.Text = "Canadian" Or cboVendorClass.Text = "American" Then
                    Try
                        'Write Data to Batch Header Database Table
                        cmd = New SqlCommand("Insert Into APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, CheckType, VendorClass, ExpenseAccount)values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @CheckType, @VendorClass, @ExpenseAccount)", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                            .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = txtBatchStatus.Text
                            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                            .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                            .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write Data to Batch Header Database Table
                        cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, Locked = @Locked, CheckType = @CheckType, VendorClass = @VendorClass, ExpenseAccount = @ExpenseAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                            .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = txtBatchStatus.Text
                            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                            .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                            .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Try

                    'Check if discount is offered
                    SelectDiscountDays()

                    GlobalCheckType = cboCheckType.Text
                    GlobalVendorClass = cboVendorClass.Text
                    GlobalNewAPBatchNumber = Val(cboBatchNumber.Text)
                    GlobalDueDate = dtpDueDate.Value
                    GlobalDivisionCode = cboDivisionID.Text
                    ReloadAPDivisionCode = cboDivisionID.Text
                    GlobalDiscountDays = DiscountDays

                    Dim NewSelectInvoicesForPayment As New SelectInvoicesForPayment
                    NewSelectInvoicesForPayment.Show()

                    Me.Dispose()
                    Me.Close()
                Else
                    MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                End If
            Else
                Try
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("Insert Into APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, CheckType, VendorClass, ExpenseAccount)values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @CheckType, @VendorClass, @ExpenseAccount)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = txtBatchStatus.Text
                        .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                        .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                        .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, Locked = @Locked, CheckType = @CheckType, VendorClass = @VendorClass, ExpenseAccount = @ExpenseAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = txtBatchStatus.Text
                        .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                        .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                        .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Try

                'Check Discount Days
                SelectDiscountDays()

                GlobalCheckType = cboCheckType.Text
                GlobalVendorClass = cboVendorClass.Text
                GlobalNewAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalDueDate = dtpDueDate.Value
                GlobalDivisionCode = cboDivisionID.Text
                ReloadAPDivisionCode = cboDivisionID.Text
                GlobalDiscountDays = DiscountDays

                Dim NewSelectInvoicesForPayment As New SelectInvoicesForPayment
                NewSelectInvoicesForPayment.Show()

                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cmdCheckRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckRegister.Click
        GlobalAPBatchNumber = Val(cboBatchNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewAPCheckRegister As New APCheckRegister
            Dim result = NewAPCheckRegister.ShowDialog()
        End Using
    End Sub

    Public Sub PrintOnOneCheck()
        Dim VendorInvoiceCount As Integer = 0

        LoadBatchStatus()

        If BatchStatus = "PRINTED" Or txtBatchStatus.Text = "PRINTED" Then
            MsgBox("Checks have already been printed for this Batch.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '********************************************************************************************
        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must have a valid division selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '********************************************************************************************
        'Validation for print checks in Canada
        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And cboVendorClass.Text = "" Then
            MsgBox("You must select a valid check type (American / Canadian) before printing checks.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '********************************************************************************************
        'Validation for print checks in Canada
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            If cboVendorClass.Text = "American" Then
                'Continue
            ElseIf cboVendorClass.Text = "Canadian" Then
                'Continue
            Else
                MsgBox("You must select a valid check type (American / Canadian) before printing checks.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        '********************************************************************************************
        ''check to see if this batch is being edited by someone else
        LockBatch()
        '************************************************************************************
        'Validate check type
        If cboCheckType.Text = "" Then
            MsgBox("You must select type of check.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            Dim CheckTheCheckType As String = ""
            Dim ValidateCheckType As String = ""

            CheckTheCheckType = cboCheckType.Text
            Select Case CheckTheCheckType
                Case "STANDARD"
                    ValidateCheckType = "OK"
                Case "FEDEX"
                    ValidateCheckType = "OK"
                Case "INTERCOMPANY"
                    ValidateCheckType = "OK"
                Case "ACH"
                    ValidateCheckType = "OK"
                Case Else
                    ValidateCheckType = "NOT OK"
            End Select

            If ValidateCheckType = "NOT OK" Then
                MsgBox("Invalid check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If

        If chkExpenseAccount.Checked = True Then
            IsExpenseAccount = "YES"
        Else
            IsExpenseAccount = "NO"
        End If
        '************************************************************************************
        'Save Batch Data
        cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, CheckType = @CheckType, VendorClass = @VendorClass, ExpenseAccount = @ExpenseAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Value
            .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
            .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
            .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
            .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '*************************************************************************************
        GlobalDivisionCode = cboDivisionID.Text
        GlobalCheckType = cboVendorClass.Text
        GlobalVendorClass = cboVendorClass.Text

        'Open Check Number Input Form
        Using NewAPCheckNumberInput As New APCheckNumberInput
            Dim Result = NewAPCheckNumberInput.ShowDialog()
        End Using

        If GlobalAPStartingCheckNumber = 0 Then
            MsgBox("You must have a valid starting Check Number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '**************************************************************************************




        '**************************************************************************************
        'Define and write check position numbers

        'Reset Check Position Number
        cmd = New SqlCommand("UPDATE APVoucherTable SET CheckPositionNumber = @CheckPositionNumber WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@CheckPositionNumber", SqlDbType.VarChar).Value = 0
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '*********************************************************************************


        '*********************************************************************************
        'Run Loop to assign new Check Position Number for each AP Voucher per Vendor
        For Each row As DataGridViewRow In dgvBatchLines.Rows
            Dim PositionVendorID As String = ""
            Dim PositionVoucherNumber, NextPositionNumber, LastPositionNumber As Integer

            Try
                PositionVendorID = row.Cells("VendorIDColumn").Value
            Catch ex As Exception
                PositionVendorID = ""
            End Try
            Try
                PositionVoucherNumber = row.Cells("VoucherNumberColumn").Value
            Catch ex As Exception
                PositionVoucherNumber = 1
            End Try

            'Get Next Position Number
            Dim LastPositionNumberStatement As String = "SELECT MAX(CheckPositionNumber) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND VendorID = @VendorID AND DivisionID = @DivisionID"
            Dim LastPositionNumberCommand As New SqlCommand(LastPositionNumberStatement, con)
            LastPositionNumberCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            LastPositionNumberCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = PositionVendorID
            LastPositionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastPositionNumber = CInt(LastPositionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastPositionNumber = 0
            End Try
            con.Close()

            NextPositionNumber = LastPositionNumber + 1

            'Write check position Number to AP Voucher Table
            cmd = New SqlCommand("UPDATE APVoucherTable SET CheckPositionNumber = @CheckPositionNumber WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = PositionVoucherNumber
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@CheckPositionNumber", SqlDbType.VarChar).Value = NextPositionNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
        '********************************************************************************************



        '********************************************************************************************
        'Assign Global Check Number as the Next Check Number
        NextCheckNumber = GlobalAPStartingCheckNumber

        'Retrieve line data from AP Voucher Table and write to Check Register to print checks
        For Each row As DataGridViewRow In dgvBatchLines.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("BatchNumberColumn")

            'Check to see if this is a reprint of checks
            Dim CheckStatusStatement As String = "SELECT CheckStatus FROM APCheckLog WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID"
            Dim CheckStatusCommand As New SqlCommand(CheckStatusStatement, con)
            CheckStatusCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
            CheckStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckStatus = CStr(CheckStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckStatus = "NO REPRINT"
            End Try
            con.Close()
            '****************************************************************************************************************
            'Delete old check before printing a new record to the database
            If CheckStatus = "CANCELLED" Then
                'Write to check register (Header Table First)
                cmd = New SqlCommand("DELETE FROM APCheckLog WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'Continue
            End If
            '****************************************************************************************************************
            'Get Voucher Data from grid to create checks
            Dim VoucherNumber As Integer = 0
            Dim InvoiceTotal As Double = 0
            Dim VendorID As String = ""
            Dim ReceiptDate As Date

            If cell.Value = Val(cboBatchNumber.Text) Then
                Try
                    VoucherNumber = row.Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    VoucherNumber = 0
                End Try
                Try
                    ReceiptDate = row.Cells("ReceiptDateColumn").Value
                Catch ex As Exception
                    ReceiptDate = Today()
                End Try
                Try
                    InvoiceTotal = row.Cells("InvoiceTotalColumn").Value
                Catch ex As Exception
                    InvoiceTotal = 0
                End Try
                Try
                    VendorID = row.Cells("VendorIDColumn").Value
                Catch ex As Exception
                    VendorID = ""
                End Try
                Try
                    DiscountAmount = row.Cells("DiscountAmountColumn").Value
                Catch ex As Exception
                    DiscountAmount = 0
                End Try

                'Round values to two decimals
                DiscountAmount = Math.Round(DiscountAmount, 2)
                InvoiceTotal = Math.Round(InvoiceTotal, 2)

                'Get Vendor Class from Payable
                Dim VendorClassStatement As String = "SELECT VendorClass FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
                VendorClassCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    VendorClass = CStr(VendorClassCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorClass = "STANDARD"
                End Try
                con.Close()


                '********************************************************************************************************
                'Total check amount and discount for one check
                '********************************************************************************************************
                'Combine and total Vouchers to the same Vendor for payment
                Dim SUMVoucherTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                Dim SUMVoucherTotalCommand As New SqlCommand(SUMVoucherTotalStatement, con)
                SUMVoucherTotalCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                SUMVoucherTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                SUMVoucherTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SUMVoucherTotal = CDbl(SUMVoucherTotalCommand.ExecuteScalar)
                    SUMVoucherTotal = Math.Round(SUMVoucherTotal, 2)
                Catch ex As Exception
                    SUMVoucherTotal = 0
                End Try
                con.Close()

                'Combine and total Discount
                Dim SUMDiscountStatement As String = "SELECT SUM(DiscountAmount) FROM APVoucherTable WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                Dim SUMDiscountCommand As New SqlCommand(SUMDiscountStatement, con)
                SUMDiscountCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                SUMDiscountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                SUMDiscountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SUMDiscount = CDbl(SUMDiscountCommand.ExecuteScalar)
                    SUMDiscount = Math.Round(SUMDiscount, 2)
                Catch ex As Exception
                    SUMDiscount = 0
                End Try
                con.Close()

                'Total # of Invoices on check
                Dim CountInvoicesStatement As String = "SELECT COUNT(VoucherNumber) FROM APVoucherTable WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                Dim CountInvoicesCommand As New SqlCommand(CountInvoicesStatement, con)
                CountInvoicesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                CountInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CountInvoicesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    VendorInvoiceCount = CInt(CountInvoicesCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorInvoiceCount = 0
                End Try
                con.Close()

                If VendorInvoiceCount > 16 Then
                    IsExtendedCheck = "YES"
                Else
                    IsExtendedCheck = "NO"
                End If
                '********************************************************************************************************



                '********************************************************************************************************
                'Check to see if vendor exists in Check Log for current batch
                Dim CheckVendorStatement As String = "SELECT VendorID FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber AND CheckStatus <> @CheckStatus"
                Dim CheckVendorCommand As New SqlCommand(CheckVendorStatement, con)
                CheckVendorCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                CheckVendorCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                CheckVendorCommand.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "DELETED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckVendorID = CStr(CheckVendorCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckVendorID = "NEW-VENDOR"
                End Try
                con.Close()

                If CheckVendorID = "" Then
                    'Write to check register (Header Table First)
                    cmd = New SqlCommand("INSERT INTO APCheckLog (CheckNumber, CheckAmount, CheckDate, DivisionID, VendorID, APBatchNumber, CheckStatus, VendorClass, ExtendedCheck, CheckType)values(@CheckNumber, @CheckAmount, @CheckDate, @DivisionID, @VendorID, @APBatchnumber, @CheckStatus, @VendorClass, @ExtendedCheck, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                        .Add("@CheckAmount", SqlDbType.VarChar).Value = SUMVoucherTotal - SUMDiscount
                        .Add("@CheckDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                        .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                        .Add("@ExtendedCheck", SqlDbType.VarChar).Value = IsExtendedCheck
                        .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Write to check register (Line Table)
                    cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                    With cmd.Parameters
                        .Add("@APCheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                        .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                        .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Increase check Number for next check
                    NextCheckNumber = NextCheckNumber + 1
                ElseIf CheckVendorID = "NEW-VENDOR" Then
                    'Write to check register (Header Table First)
                    cmd = New SqlCommand("INSERT INTO APCheckLog (CheckNumber, CheckAmount, CheckDate, DivisionID, VendorID, APBatchNumber, CheckStatus, VendorClass, ExtendedCheck, CheckType)values(@CheckNumber, @CheckAmount, @CheckDate, @DivisionID, @VendorID, @APBatchnumber, @CheckStatus, @VendorClass, @ExtendedCheck, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                        .Add("@CheckAmount", SqlDbType.VarChar).Value = SUMVoucherTotal - SUMDiscount
                        .Add("@CheckDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                        .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                        .Add("@ExtendedCheck", SqlDbType.VarChar).Value = IsExtendedCheck
                        .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Write to check register (Line Table)
                    cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                    With cmd.Parameters
                        .Add("@APCheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                        .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                        .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Increase check Number for next check
                    NextCheckNumber = NextCheckNumber + 1
                Else
                    'Get check Number for Vendor in current batch
                    Dim GetCheckNumberStatement As String = "SELECT CheckNumber FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber"
                    Dim GetCheckNumberCommand As New SqlCommand(GetCheckNumberStatement, con)
                    GetCheckNumberCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                    GetCheckNumberCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetCheckNumber = CLng(GetCheckNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetCheckNumber = 0
                    End Try
                    con.Close()

                    'Write to check register (Line Table)
                    cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                    With cmd.Parameters
                        .Add("@APCheckNumber", SqlDbType.VarChar).Value = GetCheckNumber
                        .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                        .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            End If
        Next
        '****************************************************************************************************************
        'Select check form if company is TFF or TOR
        If cboDivisionID.Text = "TFF" Then
            'Select American Style Checks
            If cboVendorClass.Text <> "" Then
                If cboVendorClass.Text = "American" Then
                    GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                    GlobalVendorClass = "American"
                    Using NewPrintPTCheckAmerican As New PrintAPChecks
                        Dim result = NewPrintPTCheckAmerican.ShowDialog()
                    End Using
                    cboBatchNumber.Text = GlobalAPBatchNumber
                ElseIf cboVendorClass.Text = "Canadian" Then
                    GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                    GlobalVendorClass = "Canadian"
                    Using NewPrintPTCheckCanadian As New PrintAPChecks
                        Dim result = NewPrintPTCheckCanadian.ShowDialog()
                    End Using
                    cboBatchNumber.SelectedIndex = -1
                    cboBatchNumber.Text = GlobalAPBatchNumber
                Else
                    MsgBox("You must select a valid Check Type.", MsgBoxStyle.OkOnly)
                End If
            Else
                MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
            End If
        ElseIf cboDivisionID.Text = "TOR" Then
            If cboVendorClass.Text = "American" Then
                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalVendorClass = "American"
                Using NewPrintAPChecks As New PrintAPChecks
                    Dim result = NewPrintAPChecks.ShowDialog()
                End Using
                cboBatchNumber.SelectedIndex = -1
                cboBatchNumber.Text = GlobalAPBatchNumber
            ElseIf cboVendorClass.Text = "Canadian" Then
                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalVendorClass = "Canadian"
                Using NewPrintPTCheckCanadian As New PrintAPChecks
                    Dim result = NewPrintPTCheckCanadian.ShowDialog()
                End Using
                cboBatchNumber.SelectedIndex = -1
                cboBatchNumber.Text = GlobalAPBatchNumber
            Else
                MsgBox("You must select a valid Check Type.", MsgBoxStyle.OkOnly)
            End If
        ElseIf cboDivisionID.Text = "ALB" Then
            If cboVendorClass.Text = "American" Then
                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalVendorClass = "American"
                Using NewPrintAPChecks As New PrintAPChecks
                    Dim result = NewPrintAPChecks.ShowDialog()
                End Using
                cboBatchNumber.SelectedIndex = -1
                cboBatchNumber.Text = GlobalAPBatchNumber
            ElseIf cboVendorClass.Text = "Canadian" Then
                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalVendorClass = "Canadian"
                Using NewPrintPTCheckCanadian As New PrintAPChecks
                    Dim result = NewPrintPTCheckCanadian.ShowDialog()
                End Using
                cboBatchNumber.SelectedIndex = -1
                cboBatchNumber.Text = GlobalAPBatchNumber
            Else
                MsgBox("You must select a valid Check Type.", MsgBoxStyle.OkOnly)
            End If
        Else
            GlobalAPBatchNumber = Val(cboBatchNumber.Text)
            GlobalVendorClass = "STANDARD"
            Using NewPrintAPChecks As New PrintAPChecks
                Dim result = NewPrintAPChecks.ShowDialog()
            End Using
            cboBatchNumber.SelectedIndex = -1
            cboBatchNumber.Text = GlobalAPBatchNumber
        End If
    End Sub

    Private Sub cmdPrintChecks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintChecks.Click
        LoadBatchStatus()

        If BatchStatus = "PRINTED" Or txtBatchStatus.Text = "PRINTED" Then
            MsgBox("Checks have already been printed for this Batch.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '********************************************************************************************
        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must have a valid division selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '********************************************************************************************
        'Validation for print checks in Canada
        If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And cboVendorClass.Text = "" Then
            MsgBox("You must select a valid check type (American / Canadian) before printing checks.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '********************************************************************************************
        'Validation for print checks in Canada
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            If cboVendorClass.Text = "American" Then
                'Continue
            ElseIf cboVendorClass.Text = "Canadian" Then
                'Continue
            Else
                MsgBox("You must select a valid check type (American / Canadian) before printing checks.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        '********************************************************************************************
        ''check to see if this batch is being edited by someone else
        If Not isSomeoneEditing() Then
            LockBatch()
            '************************************************************************************
            'Validate check type
            If cboCheckType.Text = "" Then
                MsgBox("You must select type of check.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                Dim CheckTheCheckType As String = ""
                Dim ValidateCheckType As String = ""

                CheckTheCheckType = cboCheckType.Text
                Select Case CheckTheCheckType
                    Case "STANDARD"
                        ValidateCheckType = "OK"
                    Case "FEDEX"
                        ValidateCheckType = "OK"
                    Case "INTERCOMPANY"
                        ValidateCheckType = "OK"
                    Case "ACH"
                        ValidateCheckType = "OK"
                    Case Else
                        ValidateCheckType = "NOT OK"
                End Select

                If ValidateCheckType = "NOT OK" Then
                    MsgBox("Invalid check type.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If

            If chkExpenseAccount.Checked = True Then
                IsExpenseAccount = "YES"
            Else
                IsExpenseAccount = "NO"
            End If
            '************************************************************************************
            'Save Batch Data
            cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, CheckType = @CheckType, VendorClass = @VendorClass, ExpenseAccount = @ExpenseAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Value
                .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
                .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '*************************************************************************************
            GlobalDivisionCode = cboDivisionID.Text
            GlobalVendorClass = cboVendorClass.Text

            'Open Check Number Input Form
            Using NewAPCheckNumberInput As New APCheckNumberInput
                Dim Result = NewAPCheckNumberInput.ShowDialog()
            End Using

            If GlobalAPStartingCheckNumber = 0 Then
                MsgBox("You must have a valid starting Check Number.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '**************************************************************************************
            'Define limits for invoices on a specific check (16 ALL, 14 TFF)
            If cboDivisionID.Text = "TFF" Then
                CheckPositionTotal = 15
                CheckPositionTotal2 = 14
                CheckPositionTotal3 = 28
            ElseIf cboDivisionID.Text = "TOR" And cboVendorClass.Text = "American" Then
                CheckPositionTotal = 17
                CheckPositionTotal2 = 16
                CheckPositionTotal3 = 32
            ElseIf cboDivisionID.Text = "TOR" And cboVendorClass.Text = "Canadian" Then
                CheckPositionTotal = 15
                CheckPositionTotal2 = 14
                CheckPositionTotal3 = 28
            ElseIf cboDivisionID.Text = "ALB" Then
                CheckPositionTotal = 15
                CheckPositionTotal2 = 14
                CheckPositionTotal3 = 28
            Else
                CheckPositionTotal = 17
                CheckPositionTotal2 = 16
                CheckPositionTotal3 = 32
            End If
            '**************************************************************************************
            'Define and write check position numbers

            'Reset Check Position Number
            cmd = New SqlCommand("UPDATE APVoucherTable SET CheckPositionNumber = @CheckPositionNumber WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@CheckPositionNumber", SqlDbType.VarChar).Value = 0
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '*********************************************************************************
            'Run Loop to assign new Check Position Number for each AP Voucher per Vendor
            For Each row As DataGridViewRow In dgvBatchLines.Rows
                Dim PositionVendorID As String = ""
                Dim PositionVoucherNumber, NextPositionNumber, LastPositionNumber As Integer

                Try
                    PositionVendorID = row.Cells("VendorIDColumn").Value
                Catch ex As Exception
                    PositionVendorID = ""
                End Try
                Try
                    PositionVoucherNumber = row.Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    PositionVoucherNumber = 1
                End Try

                'Get Next Position Number
                Dim LastPositionNumberStatement As String = "SELECT MAX(CheckPositionNumber) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND VendorID = @VendorID AND DivisionID = @DivisionID"
                Dim LastPositionNumberCommand As New SqlCommand(LastPositionNumberStatement, con)
                LastPositionNumberCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                LastPositionNumberCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = PositionVendorID
                LastPositionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastPositionNumber = CInt(LastPositionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    LastPositionNumber = 0
                End Try
                con.Close()

                NextPositionNumber = LastPositionNumber + 1

                'Write check position Number to AP Voucher Table
                cmd = New SqlCommand("UPDATE APVoucherTable SET CheckPositionNumber = @CheckPositionNumber WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = PositionVoucherNumber
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CheckPositionNumber", SqlDbType.VarChar).Value = NextPositionNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next
            '********************************************************************************************
            'Assign Global Check Number as the Next Check Number
            NextCheckNumber = GlobalAPStartingCheckNumber

            'Retrieve line data from AP Voucher Table and write to Check Register to print checks
            For Each row As DataGridViewRow In dgvBatchLines.Rows
                Dim cell As DataGridViewTextBoxCell = row.Cells("BatchNumberColumn")

                'Check to see if this is a reprint of checks
                Dim CheckStatusStatement As String = "SELECT CheckStatus FROM APCheckLog WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID"
                Dim CheckStatusCommand As New SqlCommand(CheckStatusStatement, con)
                CheckStatusCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                CheckStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckStatus = CStr(CheckStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckStatus = "NO REPRINT"
                End Try
                con.Close()
                '****************************************************************************************************************
                'Delete old check before printing a new record to the database
                If CheckStatus = "CANCELLED" Then
                    'Write to check register (Header Table First)
                    cmd = New SqlCommand("DELETE FROM APCheckLog WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Continue
                End If
                '****************************************************************************************************************
                'Get Voucher Data from grid to create checks
                Dim VoucherNumber As Integer
                Dim InvoiceTotal As Double
                Dim VendorID As String
                Dim ReceiptDate As Date

                If cell.Value = Val(cboBatchNumber.Text) Then
                    Try
                        VoucherNumber = row.Cells("VoucherNumberColumn").Value
                    Catch ex As Exception
                        VoucherNumber = 0
                    End Try
                    Try
                        ReceiptDate = row.Cells("ReceiptDateColumn").Value
                    Catch ex As Exception
                        ReceiptDate = Today()
                    End Try
                    Try
                        InvoiceTotal = row.Cells("InvoiceTotalColumn").Value
                    Catch ex As Exception
                        InvoiceTotal = 0
                    End Try
                    Try
                        VendorID = row.Cells("VendorIDColumn").Value
                    Catch ex As Exception
                        VendorID = ""
                    End Try
                    Try
                        DiscountAmount = row.Cells("DiscountAmountColumn").Value
                    Catch ex As Exception
                        DiscountAmount = 0
                    End Try

                    'Round values to two decimals
                    DiscountAmount = Math.Round(DiscountAmount, 2)
                    InvoiceTotal = Math.Round(InvoiceTotal, 2)

                    'Get Vendor Class from Payable
                    Dim VendorClassStatement As String = "SELECT VendorClass FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                    Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
                    VendorClassCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                    VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        VendorClass = CStr(VendorClassCommand.ExecuteScalar)
                    Catch ex As Exception
                        VendorClass = ""
                    End Try
                    con.Close()
                    '********************************************************************************************************
                    'Total check amount and discount for check #1
                    '********************************************************************************************************
                    'Combine and total Vouchers to the same Vendor for payment
                    Dim SUMVoucherTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND CheckPositionNumber < @CheckPositionNumber"
                    Dim SUMVoucherTotalCommand As New SqlCommand(SUMVoucherTotalStatement, con)
                    SUMVoucherTotalCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                    SUMVoucherTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    SUMVoucherTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    SUMVoucherTotalCommand.Parameters.Add("@CheckPositionNumber", SqlDbType.VarChar).Value = CheckPositionTotal

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SUMVoucherTotal = CDbl(SUMVoucherTotalCommand.ExecuteScalar)
                        SUMVoucherTotal = Math.Round(SUMVoucherTotal, 2)
                    Catch ex As Exception
                        SUMVoucherTotal = 0
                    End Try
                    con.Close()

                    'Combine and total Discount
                    Dim SUMDiscountStatement As String = "SELECT SUM(DiscountAmount) FROM APVoucherTable WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND CheckPositionNumber < @CheckPositionNumber"
                    Dim SUMDiscountCommand As New SqlCommand(SUMDiscountStatement, con)
                    SUMDiscountCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                    SUMDiscountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    SUMDiscountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    SUMDiscountCommand.Parameters.Add("@CheckPositionNumber", SqlDbType.VarChar).Value = CheckPositionTotal

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SUMDiscount = CDbl(SUMDiscountCommand.ExecuteScalar)
                        SUMDiscount = Math.Round(SUMDiscount, 2)
                    Catch ex As Exception
                        SUMDiscount = 0
                    End Try
                    con.Close()
                    '********************************************************************************************************
                    'Total check amount and discount for check #2
                    '********************************************************************************************************
                    Dim SumVoucherTotal2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND (CheckPositionNumber > @CheckPositionNumber AND CheckPositionNumber <= @CheckPositionNumber3)"
                    Dim SumVoucherTotal2Command As New SqlCommand(SumVoucherTotal2Statement, con)
                    SumVoucherTotal2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                    SumVoucherTotal2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    SumVoucherTotal2Command.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    SumVoucherTotal2Command.Parameters.Add("@CheckPositionNumber", SqlDbType.VarChar).Value = CheckPositionTotal2
                    SumVoucherTotal2Command.Parameters.Add("@CheckPositionNumber3", SqlDbType.VarChar).Value = CheckPositionTotal3

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SUMVoucherTotal2 = CDbl(SumVoucherTotal2Command.ExecuteScalar)
                        SUMVoucherTotal2 = Math.Round(SUMVoucherTotal2, 2)
                    Catch ex As Exception
                        SUMVoucherTotal2 = 0
                    End Try
                    con.Close()

                    'Combine and total Discount
                    Dim SUMDiscount2Statement As String = "SELECT SUM(DiscountAmount) FROM APVoucherTable WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND (CheckPositionNumber > @CheckPositionNumber AND CheckPositionNumber <= @CheckPositionNumber3)"
                    Dim SUMDiscount2Command As New SqlCommand(SUMDiscount2Statement, con)
                    SUMDiscount2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                    SUMDiscount2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    SUMDiscount2Command.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    SUMDiscount2Command.Parameters.Add("@CheckPositionNumber", SqlDbType.VarChar).Value = CheckPositionTotal2
                    SUMDiscount2Command.Parameters.Add("@CheckPositionNumber3", SqlDbType.VarChar).Value = CheckPositionTotal3

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SUMDiscount2 = CDbl(SUMDiscount2Command.ExecuteScalar)
                        SUMDiscount2 = Math.Round(SUMDiscount2, 2)
                    Catch ex As Exception
                        SUMDiscount2 = 0
                    End Try
                    con.Close()
                    '********************************************************************************************************
                    'Total check amount and discount for check #3
                    '********************************************************************************************************
                    Dim SumVoucherTotal3Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND CheckPositionNumber > @CheckPositionNumber3"
                    Dim SumVoucherTotal3Command As New SqlCommand(SumVoucherTotal3Statement, con)
                    SumVoucherTotal3Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                    SumVoucherTotal3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    SumVoucherTotal3Command.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    SumVoucherTotal3Command.Parameters.Add("@CheckPositionNumber3", SqlDbType.VarChar).Value = CheckPositionTotal3

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SUMVoucherTotal3 = CDbl(SumVoucherTotal3Command.ExecuteScalar)
                        SUMVoucherTotal3 = Math.Round(SUMVoucherTotal3, 2)
                    Catch ex As Exception
                        SUMVoucherTotal3 = 0
                    End Try
                    con.Close()

                    'Combine and total Discount
                    Dim SUMDiscount3Statement As String = "SELECT SUM(DiscountAmount) FROM APVoucherTable WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND CheckPositionNumber > @CheckPositionNumber3"
                    Dim SUMDiscount3Command As New SqlCommand(SUMDiscount3Statement, con)
                    SUMDiscount3Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                    SUMDiscount3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    SUMDiscount3Command.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    SUMDiscount3Command.Parameters.Add("@CheckPositionNumber3", SqlDbType.VarChar).Value = CheckPositionTotal3

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SUMDiscount3 = CDbl(SUMDiscount3Command.ExecuteScalar)
                        SUMDiscount3 = Math.Round(SUMDiscount3, 2)
                    Catch ex As Exception
                        SUMDiscount3 = 0
                    End Try
                    con.Close()
                    '********************************************************************************************************
                    'Run routine depending if it is one, two, or three checks
                    '********************************************************************************************************
                    If SUMVoucherTotal2 = 0 Then 'No second Check Batch needed
                        'Check to see if vendor exists in Check Log for current batch
                        Dim CheckVendorStatement As String = "SELECT VendorID FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber AND CheckStatus <> @CheckStatus"
                        Dim CheckVendorCommand As New SqlCommand(CheckVendorStatement, con)
                        CheckVendorCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                        CheckVendorCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        CheckVendorCommand.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "DELETED"

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CheckVendorID = CStr(CheckVendorCommand.ExecuteScalar)
                        Catch ex As Exception
                            CheckVendorID = "NEW-VENDOR"
                        End Try
                        con.Close()

                        If CheckVendorID = "" Then
                            'Write to check register (Header Table First)
                            cmd = New SqlCommand("INSERT INTO APCheckLog (CheckNumber, CheckAmount, CheckDate, DivisionID, VendorID, APBatchNumber, CheckStatus, VendorClass, ExtendedCheck, CheckType)values(@CheckNumber, @CheckAmount, @CheckDate, @DivisionID, @VendorID, @APBatchnumber, @CheckStatus, @VendorClass, @ExtendedCheck, @CheckType)", con)

                            With cmd.Parameters
                                .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@CheckAmount", SqlDbType.VarChar).Value = SUMVoucherTotal - SUMDiscount
                                .Add("@CheckDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                                .Add("@ExtendedCheck", SqlDbType.VarChar).Value = "NO"
                                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Write to check register (Line Table)
                            cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                            With cmd.Parameters
                                .Add("@APCheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Increase check Number for next check
                            NextCheckNumber = NextCheckNumber + 1
                        ElseIf CheckVendorID = "NEW-VENDOR" Then
                            'Write to check register (Header Table First)
                            cmd = New SqlCommand("INSERT INTO APCheckLog (CheckNumber, CheckAmount, CheckDate, DivisionID, VendorID, APBatchNumber, CheckStatus, VendorClass, ExtendedCheck, CheckType)values(@CheckNumber, @CheckAmount, @CheckDate, @DivisionID, @VendorID, @APBatchnumber, @CheckStatus, @VendorClass, @ExtendedCheck, @CheckType)", con)

                            With cmd.Parameters
                                .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@CheckAmount", SqlDbType.VarChar).Value = SUMVoucherTotal - SUMDiscount
                                .Add("@CheckDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                                .Add("@ExtendedCheck", SqlDbType.VarChar).Value = "NO"
                                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Write to check register (Line Table)
                            cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                            With cmd.Parameters
                                .Add("@APCheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Increase check Number for next check
                            NextCheckNumber = NextCheckNumber + 1
                        Else
                            'Get check Number for Vendor in current batch
                            Dim GetCheckNumberStatement As String = "SELECT CheckNumber FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber"
                            Dim GetCheckNumberCommand As New SqlCommand(GetCheckNumberStatement, con)
                            GetCheckNumberCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                            GetCheckNumberCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetCheckNumber = CLng(GetCheckNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetCheckNumber = 0
                            End Try
                            con.Close()

                            'Write to check register (Line Table)
                            cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                            With cmd.Parameters
                                .Add("@APCheckNumber", SqlDbType.VarChar).Value = GetCheckNumber
                                .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    ElseIf SUMVoucherTotal2 > 0 And SUMVoucherTotal3 = 0 Then 'Second Check Batch needed, but not a third
                        'Check to see if vendor exists in Check Log for current batch
                        Dim CheckVendorStatement As String = "SELECT VendorID FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber AND CheckStatus <> @CheckStatus"
                        Dim CheckVendorCommand As New SqlCommand(CheckVendorStatement, con)
                        CheckVendorCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                        CheckVendorCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        CheckVendorCommand.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "DELETED"

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CheckVendorID = CStr(CheckVendorCommand.ExecuteScalar)
                        Catch ex As Exception
                            CheckVendorID = "NEW-VENDOR"
                        End Try
                        con.Close()

                        If CheckVendorID = "" Then
                            'Write to check register (Header Table First)
                            cmd = New SqlCommand("INSERT INTO APCheckLog (CheckNumber, CheckAmount, CheckDate, DivisionID, VendorID, APBatchNumber, CheckStatus, VendorClass, ExtendedCheck, CheckType)values(@CheckNumber, @CheckAmount, @CheckDate, @DivisionID, @VendorID, @APBatchnumber, @CheckStatus, @VendorClass, @ExtendedCheck, @CheckType)", con)

                            With cmd.Parameters
                                .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@CheckAmount", SqlDbType.VarChar).Value = SUMVoucherTotal - SUMDiscount
                                .Add("@CheckDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                                .Add("@ExtendedCheck", SqlDbType.VarChar).Value = "NO"
                                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Write to check register (Line Table)
                            cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                            With cmd.Parameters
                                .Add("@APCheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Increase check Number for next check
                            NextCheckNumber = NextCheckNumber + 1
                        ElseIf CheckVendorID = "NEW-VENDOR" Then
                            'Write to check register (Header Table First)
                            cmd = New SqlCommand("INSERT INTO APCheckLog (CheckNumber, CheckAmount, CheckDate, DivisionID, VendorID, APBatchNumber, CheckStatus, VendorClass, ExtendedCheck, CheckType)values(@CheckNumber, @CheckAmount, @CheckDate, @DivisionID, @VendorID, @APBatchnumber, @CheckStatus, @VendorClass, @ExtendedCheck, @CheckType)", con)

                            With cmd.Parameters
                                .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@CheckAmount", SqlDbType.VarChar).Value = SUMVoucherTotal - SUMDiscount
                                .Add("@CheckDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                                .Add("@ExtendedCheck", SqlDbType.VarChar).Value = "NO"
                                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Write to check register (Line Table)
                            cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                            With cmd.Parameters
                                .Add("@APCheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Increase check Number for next check
                            NextCheckNumber = NextCheckNumber + 1
                        Else
                            'Get AP Check Position Number from the current voucher
                            Dim GetPositionNumberStatement As String = "SELECT CheckPositionNumber FROM APVoucherTable WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                            Dim GetPositionNumberCommand As New SqlCommand(GetPositionNumberStatement, con)
                            GetPositionNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                            GetPositionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            GetPositionNumberCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetPositionNumber = CInt(GetPositionNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetPositionNumber = 0
                            End Try
                            con.Close()

                            'If voucher is for existing vendor in batch - check to see position number and create new Vendor Check
                            If GetPositionNumber <= CheckPositionTotal2 Then
                                'Get check Number for Vendor in current batch
                                Dim GetCheckNumberStatement As String = "SELECT CheckNumber FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber"
                                Dim GetCheckNumberCommand As New SqlCommand(GetCheckNumberStatement, con)
                                GetCheckNumberCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                GetCheckNumberCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetCheckNumber = CLng(GetCheckNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetCheckNumber = 0
                                End Try
                                con.Close()

                                'Write to check register (Line Table)
                                cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                                With cmd.Parameters
                                    .Add("@APCheckNumber", SqlDbType.VarChar).Value = GetCheckNumber
                                    .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                    .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Else 'If Check position number > 16 then create a new check for that vendor
                                'Check to see if second check is created - if no, create new check
                                Dim CheckVendor2Statement As String = "SELECT COUNT(VendorID) FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber AND CheckStatus <> @CheckStatus"
                                Dim CheckVendor2Command As New SqlCommand(CheckVendor2Statement, con)
                                CheckVendor2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                CheckVendor2Command.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                CheckVendor2Command.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "DELETED"

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    CountVendorID = CInt(CheckVendor2Command.ExecuteScalar)
                                Catch ex As Exception
                                    CountVendorID = 1
                                End Try
                                con.Close()

                                If CountVendorID = 1 Then
                                    'Write to check register (Header Table First)
                                    cmd = New SqlCommand("INSERT INTO APCheckLog (CheckNumber, CheckAmount, CheckDate, DivisionID, VendorID, APBatchNumber, CheckStatus, VendorClass, ExtendedCheck, CheckType)values(@CheckNumber, @CheckAmount, @CheckDate, @DivisionID, @VendorID, @APBatchnumber, @CheckStatus, @VendorClass, @ExtendedCheck, @CheckType)", con)

                                    With cmd.Parameters
                                        .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                        .Add("@CheckAmount", SqlDbType.VarChar).Value = SUMVoucherTotal2 - SUMDiscount2
                                        .Add("@CheckDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                        .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"
                                        .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                                        .Add("@ExtendedCheck", SqlDbType.VarChar).Value = "NO"
                                        .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Write to check register (Line Table)
                                    cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                                    With cmd.Parameters
                                        .Add("@APCheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                        .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                        .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                        .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Increase check Number for next check
                                    NextCheckNumber = NextCheckNumber + 1
                                Else
                                    'Get check Number for Vendor in current batch
                                    Dim GetCheckNumberStatement As String = "SELECT MAX(CheckNumber) FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber"
                                    Dim GetCheckNumberCommand As New SqlCommand(GetCheckNumberStatement, con)
                                    GetCheckNumberCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                    GetCheckNumberCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        GetCheckNumber = CLng(GetCheckNumberCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        GetCheckNumber = 0
                                    End Try
                                    con.Close()

                                    'Write to check register (Line Table)
                                    cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                                    With cmd.Parameters
                                        .Add("@APCheckNumber", SqlDbType.VarChar).Value = GetCheckNumber
                                        .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                        .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                        .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                End If
                            End If
                        End If
                    ElseIf SUMVoucherTotal2 > 0 And SUMVoucherTotal3 > 0 Then 'Three checks are needed
                        'Check to see if vendor exists in Check Log for current batch
                        Dim CheckVendorStatement As String = "SELECT VendorID FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber AND CheckStatus <> @CheckStatus"
                        Dim CheckVendorCommand As New SqlCommand(CheckVendorStatement, con)
                        CheckVendorCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                        CheckVendorCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        CheckVendorCommand.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "DELETED"

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CheckVendorID = CStr(CheckVendorCommand.ExecuteScalar)
                        Catch ex As Exception
                            CheckVendorID = "NEW-VENDOR"
                        End Try
                        con.Close()

                        If CheckVendorID = "" Then
                            'Write to check register (Header Table First)
                            cmd = New SqlCommand("INSERT INTO APCheckLog (CheckNumber, CheckAmount, CheckDate, DivisionID, VendorID, APBatchNumber, CheckStatus, VendorClass, ExtendedCheck, CheckType)values(@CheckNumber, @CheckAmount, @CheckDate, @DivisionID, @VendorID, @APBatchnumber, @CheckStatus, @VendorClass, @ExtendedCheck, @CheckType)", con)

                            With cmd.Parameters
                                .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@CheckAmount", SqlDbType.VarChar).Value = SUMVoucherTotal - SUMDiscount
                                .Add("@CheckDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                                .Add("@ExtendedCheck", SqlDbType.VarChar).Value = "NO"
                                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Write to check register (Line Table)
                            cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                            With cmd.Parameters
                                .Add("@APCheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Increase check Number for next check
                            NextCheckNumber = NextCheckNumber + 1
                        ElseIf CheckVendorID = "NEW-VENDOR" Then
                            'Write to check register (Header Table First)
                            cmd = New SqlCommand("INSERT INTO APCheckLog (CheckNumber, CheckAmount, CheckDate, DivisionID, VendorID, APBatchNumber, CheckStatus, VendorClass, ExtendedCheck, CheckType)values(@CheckNumber, @CheckAmount, @CheckDate, @DivisionID, @VendorID, @APBatchnumber, @CheckStatus, @VendorClass, @ExtendedCheck, @CheckType)", con)

                            With cmd.Parameters
                                .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@CheckAmount", SqlDbType.VarChar).Value = SUMVoucherTotal - SUMDiscount
                                .Add("@CheckDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                                .Add("@ExtendedCheck", SqlDbType.VarChar).Value = "NO"
                                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Write to check register (Line Table)
                            cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                            With cmd.Parameters
                                .Add("@APCheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Increase check Number for next check
                            NextCheckNumber = NextCheckNumber + 1
                        Else
                            'Get AP Check Position Number from the current voucher
                            Dim GetPositionNumberStatement As String = "SELECT CheckPositionNumber FROM APVoucherTable WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                            Dim GetPositionNumberCommand As New SqlCommand(GetPositionNumberStatement, con)
                            GetPositionNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                            GetPositionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            GetPositionNumberCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetPositionNumber = CInt(GetPositionNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetPositionNumber = 0
                            End Try
                            con.Close()

                            'If voucher is for existing vendor in batch - check to see position number and create new Vendor Check
                            If GetPositionNumber <= CheckPositionTotal2 Then
                                'Get check Number for Vendor in current batch
                                Dim GetCheckNumberStatement As String = "SELECT CheckNumber FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber"
                                Dim GetCheckNumberCommand As New SqlCommand(GetCheckNumberStatement, con)
                                GetCheckNumberCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                GetCheckNumberCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetCheckNumber = CLng(GetCheckNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetCheckNumber = 0
                                End Try
                                con.Close()

                                'Write to check register (Line Table)
                                cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                                With cmd.Parameters
                                    .Add("@APCheckNumber", SqlDbType.VarChar).Value = GetCheckNumber
                                    .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                    .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                    .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                            ElseIf GetPositionNumber > CheckPositionTotal2 And GetPositionNumber <= CheckPositionTotal3 Then
                                'Check to see if second check is created - if no, create new check
                                Dim CheckVendor2Statement As String = "SELECT COUNT(VendorID) FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber AND CheckStatus <> @CheckStatus"
                                Dim CheckVendor2Command As New SqlCommand(CheckVendor2Statement, con)
                                CheckVendor2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                CheckVendor2Command.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                CheckVendor2Command.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "DELETED"

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    CountVendorID = CInt(CheckVendor2Command.ExecuteScalar)
                                Catch ex As Exception
                                    CountVendorID = 1
                                End Try
                                con.Close()

                                If CountVendorID = 1 Then
                                    'Write to check register (Header Table First)
                                    cmd = New SqlCommand("INSERT INTO APCheckLog (CheckNumber, CheckAmount, CheckDate, DivisionID, VendorID, APBatchNumber, CheckStatus, VendorClass, ExtendedCheck, CheckType)values(@CheckNumber, @CheckAmount, @CheckDate, @DivisionID, @VendorID, @APBatchnumber, @CheckStatus, @VendorClass, @ExtendedCheck, @CheckType)", con)

                                    With cmd.Parameters
                                        .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                        .Add("@CheckAmount", SqlDbType.VarChar).Value = SUMVoucherTotal2 - SUMDiscount2
                                        .Add("@CheckDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                        .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"
                                        .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                                        .Add("@ExtendedCheck", SqlDbType.VarChar).Value = "NO"
                                        .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Write to check register (Line Table)
                                    cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                                    With cmd.Parameters
                                        .Add("@APCheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                        .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                        .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                        .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Increase check Number for next check
                                    NextCheckNumber = NextCheckNumber + 1
                                Else
                                    'Get check Number for Vendor in current batch
                                    Dim GetCheckNumberStatement As String = "SELECT MAX(CheckNumber) FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber"
                                    Dim GetCheckNumberCommand As New SqlCommand(GetCheckNumberStatement, con)
                                    GetCheckNumberCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                    GetCheckNumberCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        GetCheckNumber = CLng(GetCheckNumberCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        GetCheckNumber = 0
                                    End Try
                                    con.Close()

                                    'Write to check register (Line Table)
                                    cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                                    With cmd.Parameters
                                        .Add("@APCheckNumber", SqlDbType.VarChar).Value = GetCheckNumber
                                        .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                        .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                        .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                End If
                            Else 'If Check position number > 32 then create a new check for that vendor
                                'Check to see if second check is created - if no, create new check
                                Dim CheckVendor2Statement As String = "SELECT COUNT(VendorID) FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber AND CheckStatus <> @CheckStatus"
                                Dim CheckVendor2Command As New SqlCommand(CheckVendor2Statement, con)
                                CheckVendor2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                CheckVendor2Command.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                CheckVendor2Command.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "DELETED"

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    CountVendorID = CInt(CheckVendor2Command.ExecuteScalar)
                                Catch ex As Exception
                                    CountVendorID = 2
                                End Try
                                con.Close()

                                If CountVendorID = 2 Then
                                    'Write to check register (Header Table First)
                                    cmd = New SqlCommand("INSERT INTO APCheckLog (CheckNumber, CheckAmount, CheckDate, DivisionID, VendorID, APBatchNumber, CheckStatus, VendorClass, ExtendedCheck, CheckType)values(@CheckNumber, @CheckAmount, @CheckDate, @DivisionID, @VendorID, @APBatchnumber, @CheckStatus, @VendorClass, @ExtendedCheck, @CheckType)", con)

                                    With cmd.Parameters
                                        .Add("@CheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                        .Add("@CheckAmount", SqlDbType.VarChar).Value = SUMVoucherTotal3 - SUMDiscount3
                                        .Add("@CheckDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                        .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                        .Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"
                                        .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                                        .Add("@ExtendedCheck", SqlDbType.VarChar).Value = "NO"
                                        .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Write to check register (Line Table)
                                    cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                                    With cmd.Parameters
                                        .Add("@APCheckNumber", SqlDbType.VarChar).Value = NextCheckNumber
                                        .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                        .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                        .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    'Increase check Number for next check
                                    NextCheckNumber = NextCheckNumber + 1
                                Else
                                    'Get check Number for Vendor in current batch
                                    Dim GetCheckNumberStatement As String = "SELECT MAX(CheckNumber) FROM APCheckLog WHERE VendorID = @VendorID AND APBatchNumber = @APBatchNumber"
                                    Dim GetCheckNumberCommand As New SqlCommand(GetCheckNumberStatement, con)
                                    GetCheckNumberCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                                    GetCheckNumberCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        GetCheckNumber = CLng(GetCheckNumberCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        GetCheckNumber = 0
                                    End Try
                                    con.Close()

                                    'Write to check register (Line Table)
                                    cmd = New SqlCommand("INSERT INTO APCheckLines (APCheckNumber, APVoucherNumber, VoucherAmount, VoucherDate)values(@APCheckNumber, @APVoucherNumber, @VoucherAmount, @VoucherDate)", con)

                                    With cmd.Parameters
                                        .Add("@APCheckNumber", SqlDbType.VarChar).Value = GetCheckNumber
                                        .Add("@APVoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                        .Add("@VoucherAmount", SqlDbType.VarChar).Value = InvoiceTotal
                                        .Add("@VoucherDate", SqlDbType.VarChar).Value = ReceiptDate
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                End If
                            End If
                        End If
                    End If 'Check Batch
                End If
            Next
            '****************************************************************************************************************
            'Select check form if company is TFF or TOR
            If cboDivisionID.Text = "TFF" Then
                'Select American Style Checks
                If cboVendorClass.Text <> "" Then
                    If cboVendorClass.Text = "American" Then
                        GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                        GlobalVendorClass = "American"
                        Using NewPrintPTCheckAmerican As New PrintAPChecks
                            Dim result = NewPrintPTCheckAmerican.ShowDialog()
                        End Using
                        cboBatchNumber.Text = GlobalAPBatchNumber
                    ElseIf cboVendorClass.Text = "Canadian" Then
                        GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                        GlobalVendorClass = "Canadian"
                        Using NewPrintPTCheckCanadian As New PrintAPChecks
                            Dim result = NewPrintPTCheckCanadian.ShowDialog()
                        End Using
                        cboBatchNumber.SelectedIndex = -1
                        cboBatchNumber.Text = GlobalAPBatchNumber
                    Else
                        MsgBox("You must select a valid Check Type.", MsgBoxStyle.OkOnly)
                    End If
                Else
                    MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                End If
            ElseIf cboDivisionID.Text = "TOR" Then
                If cboVendorClass.Text = "American" Then
                    GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                    GlobalVendorClass = "American"
                    Using NewPrintAPChecks As New PrintAPChecks
                        Dim result = NewPrintAPChecks.ShowDialog()
                    End Using
                    cboBatchNumber.SelectedIndex = -1
                    cboBatchNumber.Text = GlobalAPBatchNumber
                ElseIf cboVendorClass.Text = "Canadian" Then
                    GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                    GlobalVendorClass = "Canadian"
                    Using NewPrintPTCheckCanadian As New PrintAPChecks
                        Dim result = NewPrintPTCheckCanadian.ShowDialog()
                    End Using
                    cboBatchNumber.SelectedIndex = -1
                    cboBatchNumber.Text = GlobalAPBatchNumber
                Else
                    MsgBox("You must select a valid Check Type.", MsgBoxStyle.OkOnly)
                End If
            ElseIf cboDivisionID.Text = "ALB" Then
                If cboVendorClass.Text = "American" Then
                    GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                    GlobalVendorClass = "American"
                    Using NewPrintAPChecks As New PrintAPChecks
                        Dim result = NewPrintAPChecks.ShowDialog()
                    End Using
                    cboBatchNumber.SelectedIndex = -1
                    cboBatchNumber.Text = GlobalAPBatchNumber
                ElseIf cboVendorClass.Text = "Canadian" Then
                    GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                    GlobalVendorClass = "Canadian"
                    Using NewPrintPTCheckCanadian As New PrintAPChecks
                        Dim result = NewPrintPTCheckCanadian.ShowDialog()
                    End Using
                    cboBatchNumber.SelectedIndex = -1
                    cboBatchNumber.Text = GlobalAPBatchNumber
                Else
                    MsgBox("You must select a valid Check Type.", MsgBoxStyle.OkOnly)
                End If
            Else
                GlobalAPBatchNumber = Val(cboBatchNumber.Text)
                GlobalVendorClass = "STANDARD"
                Using NewPrintAPChecks As New PrintAPChecks
                    Dim result = NewPrintAPChecks.ShowDialog()
                End Using
                cboBatchNumber.SelectedIndex = -1
                cboBatchNumber.Text = GlobalAPBatchNumber
            End If
        End If
    End Sub

    Private Sub cmdPostBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostBatch.Click
        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must have a valid division selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '************************************************************************************
        'Validate check type
        If cboCheckType.Text = "" Then
            MsgBox("You must select type of check.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            Dim CheckTheCheckType As String = ""
            Dim ValidateCheckType As String = ""

            CheckTheCheckType = cboCheckType.Text
            Select Case CheckTheCheckType
                Case "STANDARD"
                    ValidateCheckType = "OK"
                Case "FEDEX"
                    ValidateCheckType = "OK"
                Case "INTERCOMPANY"
                    ValidateCheckType = "OK"
                Case "ACH"
                    ValidateCheckType = "OK"
                Case Else
                    ValidateCheckType = "NOT OK"
            End Select

            If ValidateCheckType = "NOT OK" Then
                MsgBox("Invalid check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        '************************************************************************************
        ''check to see if this batch is being edited by someone else
        If isSomeoneEditing() Then
            Exit Sub
        End If

        LockBatch()

        'Verify that checks have been printed for this batch before posting
        Dim CheckPrintedStatusStatement As String = "SELECT CheckStatus FROM APCheckLog WHERE APBatchNumber = @APBatchNumber AND DivisionID = @DivisionID"
        Dim CheckPrintedStatusCommand As New SqlCommand(CheckPrintedStatusStatement, con)
        CheckPrintedStatusCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        CheckPrintedStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckPrintedStatus = CStr(CheckPrintedStatusCommand.ExecuteScalar)
        Catch ex As Exception
            CheckPrintedStatus = ""
        End Try
        con.Close()
        '******************************************************************************************************************************************
        If CheckPrintedStatus = "" Or CheckPrintedStatus = "DELETED" Then
            MsgBox("Checks have not been printed for this batch.", MsgBoxStyle.OkOnly)
        Else
            '******************************************************************************************************
            If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Or EmployeeLoginName = "HRYAN" Or EmployeeLoginName = "RMONTEVECCHIO" Or EmployeeLoginName = "KPREST" Then
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
            'Check to see if Batch has been posted in the GL
            Dim CheckBatchPosting As Integer = 0

            Dim CheckBatchPostingStatement As String = "SELECT COUNT(GLTransactionKey) FROM GLTransactionMasterList WHERE GLBatchNumber = @GLBatchNumber AND DivisionID = @DivisionID AND GLJournalID = @GLJournalID"
            Dim CheckBatchPostingCommand As New SqlCommand(CheckBatchPostingStatement, con)
            CheckBatchPostingCommand.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            CheckBatchPostingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            CheckBatchPostingCommand.Parameters.Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckBatchPosting = CInt(CheckBatchPostingCommand.ExecuteScalar)
            Catch ex As Exception
                CheckBatchPosting = 0
            End Try
            con.Close()

            If CheckBatchPosting = 0 Then
                'Continue - no batch exists
            Else
                MsgBox("A GL Posting already exists for this batch. Contact system admin.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '******************************************************************************************************
            Try
                'UPDATE Voucher table to POSTED STATUS
                cmd = New SqlCommand("UPDATE APVoucherTable SET VoucherStatus = @VoucherStatus WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
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

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Post AP Payment Batch --- Update Voucher Status - AP Voucher"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**********************************
            'Write to General Ledger
            '**********************************

            '******************************************************************************************************************************************
            'Sum Check Amounts in batch to write to GL
            Dim SUMChecksInBatchStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE APBatchNumber = @APBatchNumber AND DivisionID = @DivisionID"
            Dim SUMChecksInBatchCommand As New SqlCommand(SUMChecksInBatchStatement, con)
            SUMChecksInBatchCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            SUMChecksInBatchCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMChecksInBatch = CDbl(SUMChecksInBatchCommand.ExecuteScalar)
                SUMChecksInBatch = Math.Round(SUMChecksInBatch, 2)
            Catch ex As Exception
                SUMChecksInBatch = 0
            End Try
            con.Close()

            If chkExpenseAccount.Checked = True Then
                IsExpenseAccount = "YES"
            Else
                IsExpenseAccount = "NO"
            End If
            '******************************************************************************************************************************************
            'Save Batch Data
            cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, CheckType = @CheckType, VendorClass = @VendorClass, ExpenseAccount = @ExpenseAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Value
                .Add("@BatchAmount", SqlDbType.VarChar).Value = SUMChecksInBatch
                .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '******************************************************************************************************************************************
            'Check to see if Credit Account is Checking/Expense
            If chkExpenseAccount.Checked = True Then
                If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And cboVendorClass.Text = "Canadian" Then
                    CreditBatchAccount = "C$10500"
                Else
                    CreditBatchAccount = "10500"
                End If
            Else
                If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And cboVendorClass.Text = "Canadian" Then
                    CreditBatchAccount = "C$10200"
                Else
                    CreditBatchAccount = "10200"
                End If
            End If
            '******************************************************************************************************************************************
            If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And cboVendorClass.Text = "Canadian" Then
                DebitBatchAccount = "C$20000"
            Else
                DebitBatchAccount = "20000"
            End If
            '******************************************************************************************************************************************
            Try
                'Command to write Line Amount to Payables
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitBatchAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Processing"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SUMChecksInBatch
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AP Check Batch Posting"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Try
                    'Command to write Line Amount to Payables
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitBatchAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SUMChecksInBatch
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AP Check Batch Posting"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
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

                    ErrorDate = Today()
                    ErrorComment = ex2.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Post AP Payment Batch --- Debit GL Posting"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End Try

            Try
                'Command to write LineAmount to Banking
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = CreditBatchAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Processing"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SUMChecksInBatch
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AP Check Batch Posting"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 0
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Try
                    'Command to write LineAmount to Banking
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = CreditBatchAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SUMChecksInBatch
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AP Check Batch Posting"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
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

                    ErrorDate = Today()
                    ErrorComment = ex2.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Post AP Payment Batch --- Credit GL Posting"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End Try
            '******************************************************************************************************************************************
            'Check to see if a discount needs to be posted
            Dim SUMDiscountsInBatchStatement As String = "SELECT SUM(DiscountAmount) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim SUMDiscountsInBatchCommand As New SqlCommand(SUMDiscountsInBatchStatement, con)
            SUMDiscountsInBatchCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            SUMDiscountsInBatchCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMDiscountsInBatch = CDbl(SUMDiscountsInBatchCommand.ExecuteScalar)
                SUMDiscountsInBatch = Math.Round(SUMDiscountsInBatch, 2)
            Catch ex As Exception
                SUMDiscountsInBatch = 0
            End Try
            con.Close()
            '******************************************************************************************************************************************
            If SUMDiscountsInBatch = 0 Then
                'Do nothing - no GL Posting
            Else
                Try
                    'Command to remove Discount Amount from Payables
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 2
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DebitBatchAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SUMDiscountsInBatch
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AP Discount Posting"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '******************************************************************************************************************************************
                    'Use canadian discount account if applicable
                    If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And cboVendorClass.Text = "Canadian" Then
                        DiscountGLAccount = "C$69900"
                    Else
                        DiscountGLAccount = "69900"
                    End If
                    '******************************************************************************************************************************************
                    'Command to write Discount to COS
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 3
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = DiscountGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SUMDiscountsInBatch
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AP Discount Posting"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 0
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
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

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Post AP Payment Batch --- GL Posting of discount"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If

            '**********************************
            'End of Ledger Entry
            '**********************************

            '******************************************************************************************************************************************
            Try
                'UPDATE Checks to show POSTED
                cmd = New SqlCommand("UPDATE APCheckLog SET CheckStatus = @CheckStatus WHERE APBatchNumber = @APBatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CheckStatus", SqlDbType.VarChar).Value = "POSTED"
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

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Post AP Payment Batch --- Update Check Batch Status - AP Check Log"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '************************************************************************************************************
            'Change Status in Receipt Of Invoice Table to exclude posted Vouchers from Payables
            For Each row As DataGridViewRow In dgvBatchLines.Rows
                Dim APVoucherNumber As Integer = row.Cells("VoucherNumberColumn").Value

                Try
                    'UPDATE AP Process Payment Batch table to POSTED STATUS
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@VoucherStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = APVoucherNumber
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Post AP Payment Batch --- Update Voucher Status on Post"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next

            '******************************************************************************************************************************************
            'Create Upload File --- Code for Positive Pay Upload File
            '******************************************************************************************************************************************

            Try
                'Load AP Check Dataset based on the batch number
                cmd = New SqlCommand("SELECT * FROM APCheckLog WHERE APBatchNumber = @APBatchNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                If con.State = ConnectionState.Closed Then con.Open()
                APCheckDataset = New DataSet()
                APCheckAdapter.SelectCommand = cmd
                APCheckAdapter.Fill(APCheckDataset, "APCheckLog")
                dgvAPCheckLog.DataSource = APCheckDataset.Tables("APCheckLog")
                con.Close()

                'Create File for export
                Dim CheckNumber As Int64 = 0
                Dim CheckDate As Date
                Dim CheckPayee As String = ""
                Dim CheckAmount As Double = 0
                Dim CheckDivisionID As String = ""
                Dim CheckAccountNumber As String = ""
                Dim strCheckNumber, strCheckAmount, strCheckDate As String
                Dim CheckPayeeName As String = ""
                Dim MinuteDate As Date = Now()

                'Create Filename
                Dim TodaysDate2 As Date = dtpBatchCreationDate.Value
                Dim strDay, strMonth, strYear, strMinute, strHour As String
                Dim intDay, intMonth, intYear, intMinute, intHour As Integer

                intDay = TodaysDate2.Day
                intMonth = TodaysDate2.Month
                intYear = TodaysDate2.Year
                intMinute = MinuteDate.Minute
                intHour = MinuteDate.Hour

                strDay = CStr(intDay)
                strMonth = CStr(intMonth)
                strYear = CStr(intYear)
                strMinute = CStr(intMinute)
                strHour = CStr(intHour)

                If intDay < 10 Then
                    strDay = "0" + strDay
                Else
                    'Do nothing
                End If
                If intMonth < 10 Then
                    strMonth = "0" + strMonth
                Else
                    'Do nothing
                End If

                'Check if it is a white paper check and use a different file name
                Dim IsWhitePaperCheck As Integer = 0

                Dim IsWhitePaperCheckStatement As String = "SELECT COUNT(VoucherNumber) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND CheckType <> @CheckType"
                Dim IsWhitePaperCheckCommand As New SqlCommand(IsWhitePaperCheckStatement, con)
                IsWhitePaperCheckCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                IsWhitePaperCheckCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                IsWhitePaperCheckCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    IsWhitePaperCheck = CInt(IsWhitePaperCheckCommand.ExecuteScalar)
                Catch ex As Exception
                    IsWhitePaperCheck = 0
                End Try
                con.Close()

                If IsWhitePaperCheck > 0 Then
                    strFileNamePrefix = "-WP"
                Else
                    strFileNamePrefix = ""
                End If

                If cboDivisionID.Text = "TOR" And cboVendorClass.Text = "Canadian" Then
                    strCanadianCheckType = "CAN"
                ElseIf cboDivisionID.Text = "TOR" And cboVendorClass.Text = "American" Then
                    strCanadianCheckType = "US"
                ElseIf cboDivisionID.Text = "TFF" And cboVendorClass.Text = "Canadian" Then
                    strCanadianCheckType = "CAN"
                ElseIf cboDivisionID.Text = "TFF" And cboVendorClass.Text = "American" Then
                    strCanadianCheckType = "US"
                ElseIf cboDivisionID.Text = "ALB" And cboVendorClass.Text = "Canadian" Then
                    strCanadianCheckType = "CAN"
                ElseIf cboDivisionID.Text = "ALB" And cboVendorClass.Text = "American" Then
                    strCanadianCheckType = "US"
                Else
                    strCanadianCheckType = ""
                End If

                'Create Filename for positive pay
                strCSVFileName = cboDivisionID.Text + strCanadianCheckType + strFileNamePrefix + "-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"

                'Write to Header Line
                Dim sw As StreamWriter = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileName)

                sw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")

                For Each LineRow As DataGridViewRow In dgvAPCheckLog.Rows
                    Try
                        CheckNumber = LineRow.Cells("LogCheckNumberColumn").Value
                    Catch ex As System.Exception
                        CheckNumber = 0
                    End Try
                    Try
                        CheckPayee = LineRow.Cells("LogVendorIDColumn").Value
                    Catch ex As System.Exception
                        CheckPayee = ""
                    End Try
                    Try
                        CheckAmount = LineRow.Cells("LogCheckAmountColumn").Value
                    Catch ex As System.Exception
                        CheckAmount = 0
                    End Try
                    Try
                        CheckDivisionID = LineRow.Cells("LogDivisionIDColumn").Value
                    Catch ex As System.Exception
                        CheckDivisionID = ""
                    End Try

                    'Get Vendor Name
                    Dim CheckPayeeNameString As String = "SELECT VendorName FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                    Dim CheckPayeeNameCommand As New SqlCommand(CheckPayeeNameString, con)
                    CheckPayeeNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CheckDivisionID
                    CheckPayeeNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = CheckPayee

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckPayeeName = CStr(CheckPayeeNameCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckPayeeName = ""
                    End Try
                    con.Close()

                    'Format Check Date
                    CheckDate = dtpBatchCreationDate.Value

                    Dim strCheckDay, strCheckMonth, strCheckYear As String
                    Dim intCheckDay, intCheckMonth, intCheckYear As Integer

                    intCheckDay = CheckDate.Day
                    intCheckMonth = CheckDate.Month
                    intCheckYear = CheckDate.Year

                    strCheckDay = CStr(intCheckDay)
                    strCheckMonth = CStr(intCheckMonth)
                    strCheckYear = CStr(intCheckYear)

                    If intCheckDay < 10 Then
                        strCheckDay = "0" + strCheckDay
                    End If

                    If intCheckMonth < 10 Then
                        strCheckMonth = "0" + strCheckMonth
                    End If

                    strCheckDate = strCheckMonth + "/" + strCheckDay + "/" + strCheckYear

                    strCheckAmount = CStr(CheckAmount)
                    strCheckNumber = CStr(CheckNumber)

                    'Get Account Number for division
                    Dim CheckAccountNumberString As String = "SELECT AccountNumber FROM DivisionTable WHERE DivisionKey = @DivisionKey"
                    Dim CheckAccountNumberCommand As New SqlCommand(CheckAccountNumberString, con)
                    CheckAccountNumberCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = CheckDivisionID

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckAccountNumber = CStr(CheckAccountNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckAccountNumber = ""
                    End Try
                    con.Close()

                    sw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)

                    'Clear variables
                    CheckNumber = 0
                    CheckPayee = ""
                    CheckAmount = 0
                    CheckDivisionID = ""
                    CheckAccountNumber = ""
                    strCheckNumber = ""
                    strCheckAmount = ""
                    strCheckDate = ""
                    CheckPayeeName = ""
                Next

                sw.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Post AP Payment Batch --- Create Upload File failed"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            '******************************************************************************************************************************************
            'Create Upload File --- Code for ACH Upload File
            '******************************************************************************************************************************************

            'Create filename for ACH upload, if necessary
            If cboCheckType.Text <> "STANDARD" Then
                Try
                    Dim ACHPayee As String = ""
                    Dim ACHAmount As Double = 0
                    Dim ACHDivisionID As String = ""
                    Dim ACHPayeeName As String = ""
                    Dim ACHAccountNumber As String = ""
                    Dim ACHRoutingNumber As String = ""
                    Dim ACHAccountType As String = ""
                    Dim strACHAmount As String = ""

                    If cboVendorClass.Text = "CANADIAN" Then
                        cboVendorClass.Text = "Canadian"
                    End If
                 
                    If cboDivisionID.Text = "TFF" And cboVendorClass.Text = "Canadian" Then
                        'Skip ACH File Upload
                    ElseIf cboDivisionID.Text = "TOR" And cboVendorClass.Text = "Canadian" Then
                        'Skip ACH File Upload
                    ElseIf cboDivisionID.Text = "ALB" And cboVendorClass.Text = "Canadian" Then
                        'Skip ACH File Upload
                    Else
                        ACHBatchNumber = Val(cboBatchNumber.Text)
                        strACHBatchNumber = CStr(ACHBatchNumber)
                        strACHFileName = cboDivisionID.Text + strACHBatchNumber + ".csv"

                        Dim sw2 As StreamWriter = New StreamWriter("\\TFP-FS\TrufitBanking\ACH File Uploads\" + strACHFileName)

                        'Write to Header Line
                        sw2.WriteLine("Beneficiary Name, Beneficiary ABA, Beneficiary Account Number, Beneficiary Account Type, Amount")

                        For Each LineRow As DataGridViewRow In dgvAPCheckLog.Rows
                            Try
                                ACHPayee = LineRow.Cells("LogVendorIDColumn").Value
                            Catch ex As System.Exception
                                ACHPayee = ""
                            End Try
                            Try
                                ACHAmount = LineRow.Cells("LogCheckAmountColumn").Value
                            Catch ex As System.Exception
                                ACHAmount = 0
                            End Try
                            Try
                                ACHDivisionID = LineRow.Cells("LogDivisionIDColumn").Value
                            Catch ex As System.Exception
                                ACHDivisionID = ""
                            End Try

                            strACHAmount = CStr(ACHAmount)

                            'Get Vendor Name
                            Dim ACHPayeeNameString As String = "SELECT VendorName FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                            Dim ACHPayeeNameCommand As New SqlCommand(ACHPayeeNameString, con)
                            ACHPayeeNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ACHDivisionID
                            ACHPayeeNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = ACHPayee

                            Dim ACHAccountNumberString As String = "SELECT VendorAccountNumber FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                            Dim ACHAccountNumberCommand As New SqlCommand(ACHAccountNumberString, con)
                            ACHAccountNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ACHDivisionID
                            ACHAccountNumberCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = ACHPayee

                            Dim ACHRoutingNumberString As String = "SELECT VendorRoutingNumber FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                            Dim ACHRoutingNumberCommand As New SqlCommand(ACHRoutingNumberString, con)
                            ACHRoutingNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ACHDivisionID
                            ACHRoutingNumberCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = ACHPayee

                            Dim ACHAccountTypeString As String = "SELECT VendorAccountType FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                            Dim ACHAccountTypeCommand As New SqlCommand(ACHAccountTypeString, con)
                            ACHAccountTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ACHDivisionID
                            ACHAccountTypeCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = ACHPayee

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                ACHPayeeName = CStr(ACHPayeeNameCommand.ExecuteScalar)
                            Catch ex As Exception
                                ACHPayeeName = ""
                            End Try
                            Try
                                ACHAccountNumber = CStr(ACHAccountNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                ACHAccountNumber = ""
                            End Try
                            Try
                                ACHRoutingNumber = CStr(ACHRoutingNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                ACHRoutingNumber = ""
                            End Try
                            Try
                                ACHAccountType = CStr(ACHAccountTypeCommand.ExecuteScalar)
                            Catch ex As Exception
                                ACHAccountType = ""
                            End Try
                            con.Close()

                            If ACHPayeeName.Length > 22 Then
                                ACHPayeeName = ACHPayeeName.Substring(0, 22)
                            End If

                            'Write lines to file
                            sw2.WriteLine(ACHPayeeName + "," + ACHRoutingNumber + "," + ACHAccountNumber + "," + ACHAccountType + "," + strACHAmount)

                            ACHPayee = ""
                            ACHPayeeName = ""
                            ACHDivisionID = ""
                            ACHAmount = 0
                            ACHAccountNumber = ""
                            ACHRoutingNumber = ""
                            ACHAccountType = ""
                        Next

                        sw2.Close()
                    End If
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Post AP Payment Batch --- Create ACH Upload File failed"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If

            '******************************************************************************************************************************************
            'Files created
            '******************************************************************************************************************************************

            'Update Payment Date to match posted date
            For Each row As DataGridViewRow In dgvBatchLines.Rows
                Dim APVoucherNumber As Integer = row.Cells("VoucherNumberColumn").Value

                Try
                    'UPDATE AP Process Payment Batch table to POSTED STATUS
                    cmd = New SqlCommand("UPDATE APVoucherTable SET PaidDate = @PaidDate WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@PaidDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = APVoucherNumber
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Post AP Payment Batch --- Update Voucher Payment Date on Post"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next

            If chkExpenseAccount.Checked = True Then
                BatchExpenseAccount = "YES"
            Else
                BatchExpenseAccount = "NO"
            End If
            '******************************************************************************************************************************************
            Try
                'UPDATE AP Process Payment Batch table to POSTED STATUS
                cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchStatus = @BatchStatus, Batchdate = @Batchdate, PrintDate = @PrintDate, CheckType = @CheckType, VendorClass = @VendorClass, ExpenseAccount = @ExpenseAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"
                    .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Value
                    .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
                    .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                    .Add("@ExpenseAccount", SqlDbType.VarChar).Value = BatchExpenseAccount
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

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Post AP Payment Batch --- Update Batch Status on Post"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************************************************
            ''Create check remittance, if necessary, and email automatically
            If cboCheckType.Text <> "STANDARD" Then

                Dim RemitCheckNumber As Int64 = 0
                Dim RemitVendorID As String = ""
                Dim RemitEmail As String = ""
                Dim RemitDivision As String = ""
                Dim strRemittanceFileName As String = ""
                Dim strRemitCheckNumber As String = ""

                For Each LineRow As DataGridViewRow In dgvAPCheckLog.Rows
                    Try
                        RemitVendorID = LineRow.Cells("LogVendorIDColumn").Value
                    Catch ex As System.Exception
                        RemitVendorID = ""
                    End Try
                    Try
                        RemitCheckNumber = LineRow.Cells("LogCheckNumberColumn").Value
                    Catch ex As System.Exception
                        RemitCheckNumber = 0
                    End Try
                    Try
                        RemitDivision = LineRow.Cells("LogDivisionIDColumn").Value
                    Catch ex As System.Exception
                        RemitDivision = ""
                    End Try

                    strRemitCheckNumber = CStr(RemitCheckNumber)
                    strACHFileName = RemitDivision + strRemitCheckNumber + ".pdf"

                    'Get email address
                    Dim RemitEmailString As String = "SELECT RemittanceEmail FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                    Dim RemitEmailCommand As New SqlCommand(RemitEmailString, con)
                    RemitEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RemitDivision
                    RemitEmailCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RemitVendorID

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        RemitEmail = CStr(RemitEmailCommand.ExecuteScalar)
                    Catch ex As Exception
                        RemitEmail = ""
                    End Try
                    con.Close()

                    'Get Total Check Amount for the Subject Line
                    Dim SubjectCheckAmountString As String = "SELECT CheckAmount FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckNumber = @CheckNumber"
                    Dim SubjectCheckAmountCommand As New SqlCommand(SubjectCheckAmountString, con)
                    SubjectCheckAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RemitDivision
                    SubjectCheckAmountCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = RemitCheckNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SubjectCheckAmount = CDbl(SubjectCheckAmountCommand.ExecuteScalar)
                        SubjectCheckAmount = Math.Round(SubjectCheckAmount, 2)
                    Catch ex As Exception
                        SubjectCheckAmount = 0
                    End Try
                    con.Close()

                    'Convert Double into string value with two decimal places
                    strSubjectCheckAmount = CStr(SubjectCheckAmount)

                    If strSubjectCheckAmount.Contains(".") Then
                        'Loop to see where the decimal point is
                        Dim TotalStringLength As Integer = strSubjectCheckAmount.Length
                        Dim CharacterCounter As Integer = 1
                        Dim CurrentCharascter As String = ""

                        Do Until CurrentCharascter = "."
                            CurrentCharascter = strSubjectCheckAmount.Substring(TotalStringLength - CharacterCounter, 1)
                            CharacterCounter = CharacterCounter + 1
                        Loop

                        If CharacterCounter = 4 Then
                            'Do nothing - number has two decimals
                        ElseIf CharacterCounter = 3 Then
                            'Add trailing zero
                            strSubjectCheckAmount = strSubjectCheckAmount + "0"
                        ElseIf CharacterCounter = 2 Then
                            'Ends with a decimal - add the zeroes
                            strSubjectCheckAmount = strSubjectCheckAmount + "00"
                        Else
                            'No decimal - add decimal and the zeroes
                            strSubjectCheckAmount = strSubjectCheckAmount + ".00"
                        End If
                    Else
                        strSubjectCheckAmount = strSubjectCheckAmount + ".00"
                    End If

                    'Load dataset for one check
                    Dim OneCheckDataset As DataSet
                    Dim OneCheckAdapter As New SqlDataAdapter
                    Dim OneCheckAdapter2 As New SqlDataAdapter

                    cmd = New SqlCommand("SELECT * FROM APCheckQuery WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = RemitCheckNumber
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RemitDivision

                    'Add division table to dataset
                    cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                    cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = RemitDivision


                    If con.State = ConnectionState.Closed Then con.Open()
                    OneCheckDataset = New DataSet()

                    OneCheckAdapter.SelectCommand = cmd
                    OneCheckAdapter.Fill(OneCheckDataset, "APCheckQuery")

                    OneCheckAdapter2.SelectCommand = cmd2
                    OneCheckAdapter2.Fill(OneCheckDataset, "DivisionTable")
                    con.Close()

                    'Create Remittance file from crystal report
                    MyReport = crxptRemittance1
                    MyReport.SetDataSource(OneCheckDataset)
                    MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TrufitBanking\ACH Remit\" & strACHFileName)
                    con.Close()

                    '***********************************************************************************************
                    'Check if file exists
                    If File.Exists("\\TFP-FS\TrufitBanking\ACH Remit\" + strACHFileName) Then
                        '***********************************************************************************************
                        If RemitEmail = "" Then
                            'Skip
                        Else
                            Try
                                'Set up email to be sent
                                Dim MyMailMessage As New MailMessage()
                                MyMailMessage.From = New MailAddress("achremittance@tfpcorp.com")

                                'Add array of email addresses if necessay
                                'Parse email field to determine how many addresses 
                                If RemitEmail.Contains(";") Then
                                    Dim EmailArray As Array
                                    Dim ArrayCount As Integer = 0
                                    Dim CurrentEmail As String = ""

                                    EmailArray = Split(RemitEmail, ";")
                                    ArrayCount = UBound(EmailArray) + 1
                                    Dim Counter As Integer = 1

                                    For i As Integer = 0 To UBound(EmailArray)
                                        CurrentEmail = EmailArray(ArrayCount - Counter)
                                        MyMailMessage.To.Add(CurrentEmail)
                                        Counter = Counter + 1
                                    Next
                                Else
                                    MyMailMessage.To.Add(RemitEmail)
                                End If

                                MyMailMessage.Attachments.Add(New Attachment("\\TFP-FS\TrufitBanking\ACH Remit\" + strACHFileName))
                                MyMailMessage.Subject = "ACH Remittance / TFP Corporation - ($" + strSubjectCheckAmount + ")"
                                MyMailMessage.ReplyTo = New MailAddress("ap@tfpcorp.com")
                                MyMailMessage.Body = "Auto-sent remittance for ACH transaction. Do not reply to this email address. Contact ap@tfpcorp.com"
                                Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                                SMPT.Port = "587"
                                SMPT.EnableSsl = False
                                SMPT.Credentials = New System.Net.NetworkCredential("achremittance@tfpcorp.com", "1422325bogie")
                                SMPT.Send(MyMailMessage)
                            Catch ex As Exception
                                'Skip
                            End Try
                        End If
                    Else
                        'Skip
                    End If

                    'Clear variables before next repetition
                    RemitCheckNumber = 0
                    RemitVendorID = ""
                    RemitEmail = ""
                    RemitDivision = ""
                    strRemittanceFileName = ""
                    strRemitCheckNumber = ""
                    strACHFileName = ""
                    SubjectCheckAmount = 0
                    strSubjectCheckAmount = ""
                Next
            End If
            '******************************************************************************************************************************************
            'Auto-print full report for the batch
            If cboCheckType.Text = "STANDARD" Then
                'Do nothing - no autoprint
            Else
                AutoprintBatchReportRoutine()
            End If
            '******************************************************************************************************************************************
            MsgBox("This AP Batch has been posted.", MsgBoxStyle.OkOnly)

            unlockBatch()
            cboBatchNumber.Text = ""

            LoadBatchNumber()
            ClearData()
            ClearVariables()
            ShowBatchLines()
            Me.dgvAPCheckLog.DataSource = Nothing
        End If
    End Sub

    Public Sub AutoprintBatchReportRoutine()
        'Create Filename
        Dim strBatchNumber As String = ""
        Dim BatchNumber As Integer = 0
        Dim BatchFilename As String = ""

        BatchNumber = Val(cboBatchNumber.Text)
        strBatchNumber = CStr(BatchNumber)

        BatchFilename = cboDivisionID.Text + strBatchNumber + ".pdf"

        'Load data into Dataset
        cmd = New SqlCommand("SELECT * FROM APProcessPaymentBatch  WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

        'cmd1 = New SqlCommand("SELECT * FROM APVoucherTable WHERE BatchNumber = @BatchNumber", con)
        'cmd1.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

        cmd2 = New SqlCommand("SELECT * FROM APCheckLog WHERE APBatchNumber = @APBatchNumber", con)
        cmd2.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        APReportDataset = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(APReportDataset, "APProcessPaymentBatch")

        'myAdapter1.SelectCommand = cmd1
        'myAdapter1.Fill(APReportDataset, "APVoucherTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(APReportDataset, "APCheckLog")

        AutoprintBatchReport = crxapPaymentBatch1
        AutoprintBatchReport.SetDataSource(APReportDataset)
        AutoprintBatchReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TrufitBanking\APBatchReports\" & BatchFilename)
        AutoprintBatchReport.PrintToPrinter(1, True, 1, 999)
        con.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        ''check to see if this batch is being edited by someone else
        If isSomeoneEditing() Then
            Exit Sub
        End If

        LoadBatchTotals()
        LoadBatchStatus()

        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must have a valid division selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '************************************************************************************
        'Validate check type
        If cboCheckType.Text = "" Then
            MsgBox("You must select type of check.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            Dim CheckTheCheckType As String = ""
            Dim ValidateCheckType As String = ""

            CheckTheCheckType = cboCheckType.Text
            Select Case CheckTheCheckType
                Case "STANDARD"
                    ValidateCheckType = "OK"
                Case "FEDEX"
                    ValidateCheckType = "OK"
                Case "INTERCOMPANY"
                    ValidateCheckType = "OK"
                Case "ACH"
                    ValidateCheckType = "OK"
                Case Else
                    ValidateCheckType = "NOT OK"
            End Select

            If ValidateCheckType = "NOT OK" Then
                MsgBox("Invalid check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        '************************************************************************************
        If chkExpenseAccount.Checked = True Then
            IsExpenseAccount = "YES"
        Else
            IsExpenseAccount = "NO"
        End If
        '************************************************************************************
        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            Try
                'Write Data to Batch Header Database Table
                cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, Locked = @Locked, CheckType = @CheckType, VendorClass = @VendorClass, ExpenseAccount = @ExpenseAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = txtBatchStatus.Text
                    .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                    .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
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

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "AP Process Payment --- Save Routine / Datagrid"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            Try
                'Write Data to Batch Header Database Table
                cmd = New SqlCommand("Insert Into APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, CheckType, VendorClass, ExpenseAccount)values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @CheckType, @VendorClass, @ExpenseAccount)", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = txtBatchStatus.Text
                    .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                    .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Load Defaults
                If cboCheckType.Text = "" Then
                    cboCheckType.Enabled = True
                Else
                    cboCheckType.Enabled = False
                End If

                LoadBatchTotals()
                ShowBatchLines()

                MsgBox("Batch has been updated.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'Write Data to Batch Header Database Table
                cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, Locked = @Locked, CheckType = @CheckType, VendorClass = @VendorClass, ExpenseAccount = @ExpenseAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = txtBatchStatus.Text
                    .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                    .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Load Defaults
                If cboCheckType.Text = "" Then
                    cboCheckType.Enabled = True
                Else
                    cboCheckType.Enabled = False
                End If

                LoadBatchTotals()
                ShowBatchLines()

                MsgBox("Batch has been updated.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalAPBatchNumber = Val(cboBatchNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintAPPaymentBatch As New PrintAPPaymentBatch
            Dim Result = NewPrintAPPaymentBatch.ShowDialog()
        End Using
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        ''check to see if this batch is being edited by someone else
        If isSomeoneEditing() Then
            Exit Sub
        End If

        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must have a valid division selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboBatchNumber.Text = "" Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        Else
            'Check to see if Batch is Posted
            Dim BatchStatusStatement As String = "SELECT BatchStatus FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = ""
            End Try
            con.Close()

            If BatchStatus = "POSTED" Then
                MsgBox("You cannot delete a posted batch.", MsgBoxStyle.OkOnly)
                cmdDelete.Focus()
            Else
                Dim GetChecks As Integer = 0

                'Check to see if checks have been created
                Dim GetChecksStatement As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE APBatchNumber = @APBatchNumber AND DivisionID = @DivisionID"
                Dim GetChecksCommand As New SqlCommand(GetChecksStatement, con)
                GetChecksCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                GetChecksCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetChecks = CInt(GetChecksCommand.ExecuteScalar)
                Catch ex As Exception
                    GetChecks = 0
                End Try

                If GetChecks > 0 Then
                    Dim button1 As DialogResult = MessageBox.Show("Checks have been created for this batch. Do you wish to delete?", "DELETE BATCH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button1 = DialogResult.Yes Then

                        For Each row As DataGridViewRow In dgvBatchLines.Rows
                            Dim VoucherNumber As Integer = row.Cells("VoucherNumberColumn").Value

                            'Reset payables to be selected again.
                            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus Where VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Next

                        'Delete Batch
                        cmd = New SqlCommand("DELETE FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND BatchStatus <> @BatchStatus", con)
                        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Create command to delete payment record
                        cmd = New SqlCommand("DELETE FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        cmd = New SqlCommand("DELETE FROM APCheckLog WHERE APBatchNumber = @APBatchNumber AND DivisionID = @DivisionID AND CheckStatus <> @CheckStatus", con)
                        cmd.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "POSTED"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        'Log Batch Deletion (Audit Trail Table)
                        '***************************************************************************************************
                        'Write to Audit Trail Table
                        Dim AuditComment As String = ""
                        Dim AuditBatchNumber As Integer = 0
                        Dim strBatchNumber As String = ""

                        AuditBatchNumber = Val(cboBatchNumber.Text)
                        strBatchNumber = CStr(AuditBatchNumber)
                        AuditComment = "Check Batch #" + strBatchNumber + " was deleted on " + Today()
                        Try
                            cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@AuditType", SqlDbType.VarChar).Value = "Check Batch Printed - DELETION"
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
                        '**************************************************************************************************
                        'load defaults
                        ClearData()
                        ClearVariables()
                        LoadBatchNumber()
                        cboBatchNumber.Text = ""
                        cboBatchNumber.SelectedIndex = -1
                        cboDeleteLines.SelectedIndex = -1
                        dtpBatchCreationDate.Text = ""
                        txtBatchDescription.Text = "PROCESS FOR PAYMENT"
                        txtBatchTotal.Clear()
                        txtCurrentTotal.Clear()
                        txtEntryNumber.Clear()
                        txtUndistributedAmount.Clear()
                        txtBatchStatus.Clear()
                        cboBatchNumber.Focus()

                        LoadBatchNumber()
                        LoadBatchData()
                        LoadBatchTotals()
                        ShowBatchLines()
                    ElseIf button1 = DialogResult.No Then 'Condition if "GetChecks" = 0
                        'Exit Statement - does not wish to delete
                    End If
                Else
                    For Each row As DataGridViewRow In dgvBatchLines.Rows
                        Dim VoucherNumber As Integer = row.Cells("VoucherNumberColumn").Value

                        'Reset payables to be selected again.
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus Where VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Next

                    'Create command to delete batch
                    cmd = New SqlCommand("DELETE FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND BatchStatus <> @BatchStatus", con)
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Create command to delete payment record
                    cmd = New SqlCommand("DELETE FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    '***************************************************************************************************
                    'Log Batch Deletion (Audit Trail Table)
                    Dim AuditComment As String = ""
                    Dim AuditBatchNumber As Integer = 0
                    Dim strBatchNumber As String = ""

                    AuditBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(AuditBatchNumber)
                    AuditComment = "Check Batch #" + strBatchNumber + " was deleted on " + Today()
                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "Check Batch Not Printed - DELETION"
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
                    '***************************************************************************************************
                    'load defaults
                    ClearData()
                    ClearVariables()
                    LoadBatchNumber()
                    cboBatchNumber.Text = ""
                    cboBatchNumber.SelectedIndex = -1
                    cboDeleteLines.SelectedIndex = -1
                    dtpBatchCreationDate.Text = ""
                    txtBatchDescription.Text = "PROCESS FOR PAYMENT"
                    txtBatchTotal.Clear()
                    txtCurrentTotal.Clear()
                    txtEntryNumber.Clear()
                    txtUndistributedAmount.Clear()
                    txtBatchStatus.Clear()
                    cboBatchNumber.Focus()

                    LoadBatchNumber()
                    LoadBatchData()
                    LoadBatchTotals()
                    ShowBatchLines()
                End If
            End If
        End If
    End Sub

    Private Sub cmdCreateNewBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateNewBatch.Click
        Dim SelectedVoucher As Integer = 0
        Dim ReserveBatchNumber As Integer = 0
        Dim NewBatchTotal As Double = 0
        Dim OldBatchTotal As Double = 0

        '******************************************************
        If chkExpenseAccount.Checked = True Then
            IsExpenseAccount = "YES"
        Else
            IsExpenseAccount = "NO"
        End If
        '******************************************************

        ReserveBatchNumber = Val(cboBatchNumber.Text)

        'Get Next Batch Number
        Dim MAXStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
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
            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass, ExpenseAccount) values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass, @ExpenseAccount)", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchStatus", SqlDbType.VarChar).Value = "PENDING"
                .Add("@Locked", SqlDbType.VarChar).Value = ""
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox("New Batch not created.", MsgBoxStyle.OkOnly)
            Exit Sub
        End Try

        Try
            For Each row As DataGridViewRow In Me.dgvBatchLines.SelectedRows
                Try
                    SelectedVoucher = row.Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    SelectedVoucher = 0
                End Try

                'Write Data to Invoice Header Database Table
                cmd = New SqlCommand("UPDATE APVoucherTable SET BatchNumber = @BatchNumber WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

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
            Dim SUMTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
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

            cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchAmount = @BatchAmount, CheckType = @CheckType, VendorClass = @VendorClass, ExpenseAccount = @ExpenseAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchAmount", SqlDbType.VarChar).Value = NewBatchTotal
                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '*************************************************************************************************
            'Get Old Batch Total
            Dim SUMTotal2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
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

            cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

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
            ClearData()
            LoadBatchNumber()

            cboBatchNumber.Text = ReserveBatchNumber
            txtBatchTotal.Text = OldBatchTotal
            ShowBatchLines()

            MsgBox("New Batch Created.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("There was a problem creating the new batch.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch()
        End If

        ClearVariables()
        ClearData()
        ClearBatchLines()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        LoadBatchTotals()
        LoadBatchStatus()
        GlobalAPPFPCheckBox = "NO"

        If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
            'Unlock Batch
            cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET Locked = @Locked WHERE BatchNumber = @BatchNumber", con)
            cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            GlobalNewAPBatchNumber = 0
            ClearData()
            ClearVariables()

            Me.Dispose()
            Me.Close()
        Else
            ''check to see if this batch is being edited by someone else
            If isSomeoneEditing() Then
                'Unlock Batch
                cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET Locked = @Locked WHERE BatchNumber = @BatchNumber", con)
                cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                GlobalNewAPBatchNumber = 0
                ClearData()
                ClearVariables()

                Me.Dispose()
                Me.Close()
            End If

            If cboBatchNumber.Text = "" Or Val(cboBatchNumber.Text) = 0 Then
                MsgBox("You must have a valid batch # selected.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            If chkExpenseAccount.Checked = True Then
                IsExpenseAccount = "YES"
            Else
                IsExpenseAccount = "NO"
            End If

            'Write Data to Batch Header Database Table
            cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, BatchStatus = @BatchStatus, Locked = '', CheckType = @CheckType, VendorClass = @VendorClass, ExpenseAccount = @ExpenseAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@BatchDate", SqlDbType.VarChar).Value = dtpBatchCreationDate.Text
                .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                .Add("@BatchDescription", SqlDbType.VarChar).Value = txtBatchDescription.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchStatus", SqlDbType.VarChar).Value = txtBatchStatus.Text
                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                .Add("@ExpenseAccount", SqlDbType.VarChar).Value = IsExpenseAccount
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            GlobalNewAPBatchNumber = 0
            ClearData()
            ClearVariables()

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    'Menu Strip Functions

    Private Sub ClearBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBatchToolStripMenuItem.Click
        cmdClear_Click(sender, e)
    End Sub

    Private Sub PrintBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBatchToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub SaveBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBatchToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub DeleteBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBatchToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub UnLockBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockBatchToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this batch?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET Locked = '' WHERE BatchNumber = @BatchNumber", con)
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

    'Combo Box Functions

    Private Sub cboBatchNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBatchNumber.SelectedIndexChanged
        If isloaded Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch(lastBatch)
        End If

        chkExpenseAccount.Checked = False
        LoadBatchData()
        LoadBatchTotals()
        ShowBatchLines()
        lastBatch = cboBatchNumber.Text
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isloaded Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch(lastBatch)
        End If
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            lblCheckType.Visible = True
            cboVendorClass.Visible = True
            cboVendorClass.Text = GlobalCheckType
        Else
            lblCheckType.Visible = False
            cboVendorClass.Visible = False
        End If
        If cboDivisionID.Text = "TST" Then
            cmdPrintNewChecks.Visible = True
            cmdPrintChecks.Visible = False
        Else
            cmdPrintNewChecks.Visible = False
            cmdPrintChecks.Visible = True
        End If

        LoadBatchNumber()

        If GlobalNewAPBatchNumber = 0 Then
            cboBatchNumber.SelectedIndex = -1
            ClearData()
            ClearVariables()
            ShowBatchLines()
            cboBatchNumber.Focus()
        Else
            cboBatchNumber.Text = GlobalNewAPBatchNumber
            LoadBatchData()
            ShowBatchLines()
            cboBatchNumber.Focus()
        End If
    End Sub

    'Datagridview Functions

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvBatchLines.CellValueChanged
        ''check to see if this batch is being edited by someone else
        If isSomeoneEditing() Then
            Exit Sub
        End If

        LockBatch()

        Dim LineInvoiceTotal, LineDiscountAmount, NewPaymentAmount As Double
        Dim LineVoucherNumber As Integer
        Dim LineDueDate, LineInvoiceDate, LineDiscountDate As String

        'UPDATE Line Table on changes in the datagrid and ensure no NULL values
        For Each row As DataGridViewRow In dgvBatchLines.Rows
            Try
                LineVoucherNumber = row.Cells("VoucherNumberColumn").Value
            Catch ex As Exception
                LineVoucherNumber = 0
            End Try
            Try
                LineInvoiceTotal = row.Cells("InvoiceTotalColumn").Value
            Catch ex As Exception
                LineInvoiceTotal = 0
            End Try
            Try
                LineDiscountAmount = row.Cells("DiscountAmountColumn").Value
            Catch ex As Exception
                LineDiscountAmount = 0
            End Try
            Try
                LineDueDate = row.Cells("DueDateColumn").Value
            Catch ex As Exception
                LineDueDate = ""
            End Try
            Try
                LineInvoiceDate = row.Cells("InvoiceDateColumn").Value
            Catch ex As Exception
                LineInvoiceDate = ""
            End Try
            Try
                LineDiscountDate = row.Cells("DiscountDateColumn").Value
            Catch ex As Exception
                LineDiscountDate = ""
            End Try

            NewPaymentAmount = LineInvoiceTotal - LineDiscountAmount
            NewPaymentAmount = Math.Round(NewPaymentAmount, 2)
            LineDiscountAmount = Math.Round(LineDiscountAmount, 2)

            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE APVoucherTable SET PaymentAmount = @PaymentAmount, DiscountAmount = @DiscountAmount, InvoiceDate = @InvoiceDate, DueDate = @DueDate, DiscountDate = @DiscountDate WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = LineVoucherNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PaymentAmount", SqlDbType.VarChar).Value = NewPaymentAmount
                    .Add("@DiscountAmount", SqlDbType.VarChar).Value = LineDiscountAmount
                    .Add("@InvoiceDate", SqlDbType.VarChar).Value = LineInvoiceDate
                    .Add("@DueDate", SqlDbType.VarChar).Value = LineDueDate
                    .Add("@DiscountDate", SqlDbType.VarChar).Value = LineDiscountDate
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempVoucherNumber As Integer = 0
                Dim strVoucherNumber As String
                TempVoucherNumber = LineVoucherNumber
                strVoucherNumber = CStr(TempVoucherNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "AP Process Payment --- Save Routine / Cell Change Event"
                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        Next

        ShowBatchLines()
    End Sub

    'Formatting

    Public Sub FormatWhitePaperChecks()
        Dim CheckType As String = ""
        Dim WhitePaper As String = ""

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvBatchLines.Rows
            Try
                CheckType = row.Cells("CheckTypeColumn").Value
            Catch ex As System.Exception
                CheckType = ""
            End Try
            Try
                WhitePaper = row.Cells("WhitePaperColumn").Value
            Catch ex As System.Exception
                WhitePaper = "NO"
            End Try

            If CheckType <> "STANDARD" Then
                Me.dgvBatchLines.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvBatchLines.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            Else
                Me.dgvBatchLines.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                If WhitePaper = "YES" Then
                    Me.dgvBatchLines.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    Me.dgvBatchLines.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
                End If
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    'Variables to gray out Windows "X" to close form
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

    Private Sub cmdPrintNewChecks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintNewChecks.Click
        If chkExpenseAccount.Checked = True Then
            GlobalAPPFPCheckBox = "YES"
        Else
            GlobalAPPFPCheckBox = "NO"
        End If

        PrintOnOneCheck()
    End Sub

    Private Sub dgvBatchLines_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBatchLines.ColumnHeaderMouseClick
        FormatWhitePaperChecks()
    End Sub

    Private Sub dgvBatchLines_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBatchLines.Sorted
        FormatWhitePaperChecks()
    End Sub

    Private Sub cboCheckType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCheckType.SelectedIndexChanged
        If cboDivisionID.Text = "TWD" And cboCheckType.Text = "ACH" Then
            chkExpenseAccount.Checked = True
        End If
    End Sub

    Private Sub cmdGet80ByteFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGet80ByteFile.Click
        'Carriage Return and Line Feed must be at the end of every record
        'Load AP Check Dataset based on the bath number
        cmd = New SqlCommand("SELECT * FROM APCheckLog WHERE APBatchNumber = @APBatchNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        APCheckDataset = New DataSet()
        APCheckAdapter.SelectCommand = cmd
        APCheckAdapter.Fill(APCheckDataset, "APCheckLog")
        dgvAPCheckLog.DataSource = APCheckDataset.Tables("APCheckLog")
        con.Close()

        'Declare Constants
        Dim OriginatorID As String = "9876543210"
        Dim CPACode As String = "123"
        Dim DueDate As Date = dtpBatchCreationDate.Value
        Dim OriginatorShortName = "TFP CORPORATION"
        Dim FIIDTransitNumber As String = "000412345"
        Dim BankReturnAccount As String = "12345678911 "
        Dim FileCounter As String = ""
        Dim BatchNumber As Integer = Val(cboBatchNumber.Text)
        Dim strBatchNumber As String = CStr(BatchNumber)
        Dim strFileName As String = cboDivisionID.Text + "-" + strBatchNumber + ".csv"

        'Create Header Record
        Dim HeaderC01, HeaderC02, HeaderC03, HeaderC04, HeaderC05, HeaderC06, HeaderC07, HeaderC08, HeaderC09, HeaderC10, TotalHeaderLine As String

        '10 Columns
        '#1 - Record Type (1 Character)
        '#2 - Originator ID Number (10 Characters)
        '#3 - Payment Type (1 Character)
        '#4 - CPA Code (3 Characters)
        '#5 - Due Date (6 Characters DDMMYY)
        '#6 - Originator Short Name (15 Characters)
        '#7 - FI ID / Transit # (9 Characters)
        '#8 - Account Number (12 Characters - 11 plus one space)
        '#9 - File Creation Number (4 Characters starting with 0001)
        '#10 - Filler (19 spaces)

        'Column One
        HeaderC01 = "H"

        'Column Two
        HeaderC02 = OriginatorID

        'Column Three
        HeaderC03 = "C"

        'Column Four
        HeaderC04 = CPACode

        'Column Five
        Dim DayOfDate, MonthOfDate, YearOfDate As Integer
        Dim strDayOfDate, strMonthOfDate, strYearOfDate As String
        Dim FormattedDueDate As String = ""

        DayOfDate = DueDate.Day
        MonthOfDate = DueDate.Month
        YearOfDate = DueDate.Year
        If DayOfDate < 10 Then
            strDayOfDate = "0" + CStr(DayOfDate)
        Else
            strDayOfDate = CStr(DayOfDate)
        End If
        If MonthOfDate < 10 Then
            strMonthOfDate = "0" + CStr(MonthOfDate)
        Else
            strMonthOfDate = CStr(MonthOfDate)
        End If
        strYearOfDate = CStr(YearOfDate)
        strYearOfDate = strYearOfDate.Substring(2, 2)

        FormattedDueDate = strDayOfDate + strMonthOfDate + strYearOfDate

        HeaderC05 = FormattedDueDate

        'Column Six
        HeaderC06 = OriginatorShortName

        'Column Seven
        HeaderC07 = FIIDTransitNumber

        'Column Eight
        HeaderC08 = BankReturnAccount

        'Column Nine
        'Get Next Number
        Dim NextFileNumber, LastFileNumber As Integer

        Dim MAXStatement As String = "SELECT MAX(ACHFileNumber) FROM ACHFileCounterTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastFileNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastFileNumber = 0
        End Try
        con.Close()

        NextFileNumber = LastFileNumber + 1

        FileCounter = CStr(NextFileNumber)

        If FileCounter.Length.Equals(4) Then
            'Do nothing
        ElseIf FileCounter.Length.Equals(3) Then
            FileCounter = "0" + FileCounter
        ElseIf FileCounter.Length.Equals(2) Then
            FileCounter = "00" + FileCounter
        ElseIf FileCounter.Length.Equals(1) Then
            FileCounter = "000" + FileCounter
        End If

        'Write to file number table to record used number
        cmd = New SqlCommand("INSERT INTO ACHFileCounterTable (ACHFileNumber, DivisionID) Values (@ACHFileNumber, @DivisionID)", con)

        With cmd.Parameters
            .Add("@ACHFileNumber", SqlDbType.VarChar).Value = NextFileNumber
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        HeaderC09 = FileCounter

        'Column Ten
        HeaderC10 = "                   "

        TotalHeaderLine = HeaderC01 + HeaderC02 + HeaderC03 + HeaderC04 + HeaderC05 + HeaderC06 + HeaderC07 + HeaderC08 + HeaderC09 + HeaderC10

        'Write Header Line to text file
        Dim sw As StreamWriter = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strFileName)

        sw.WriteLine(TotalHeaderLine)
        'sw.Close()
        '*************************************************************************************************************






        '*************************************************************************************************************
        Dim DetailC01, DetailC02, DetailC03, DetailC04, DetailC05, DetailC06, DetailC07 As String
        Dim TotalDetailLine As String = ""
        Dim InternalRecordID As String = ""
        Dim CheckNumber As Int64 = 0
        Dim strCheckNumber As String = ""
        Dim VendorID As String = ""
        Dim VendorName As String = ""
        Dim VendorAccountNumber As String = ""
        Dim CheckAmount As Double = 0
        Dim strCheckAmount As String = ""
        Dim PayeeName As String = ""
        Dim VendorNameCharacterCount As Integer = 0
        Dim BlankSpaceFiller As String = "                                     "
        Dim VendorTransitNumber As String = ""
        Dim VendorAccountCharacterCount As Integer = 0
        Dim VendorCheckAmountCharacterCount As Integer = 0
        Dim CountCharacters As Integer = 0
        Dim ZeroSpaceFiller As String = "00000000000000000000000000000000000000"

        'Create Detail Records
        '7 Columns
        '#1 - Record Type (1 Character - D for Detail)
        '#2 - Payee Name (Vendor) (23 Characters)
        '#3 - Payment Due Date (6 Characters DDMMYY)
        '#4 - Originator Reference # (19 Characters)
        '#5 - FI ID / Transit Number (9 Characters)
        '#6 - Payee Account # (12 Characters)
        '#7 - Payment Amount (no ., no $, etc. - all numbers with leading zeros)(10 Characters)

        'Create a loop to write all lines in batch as detail records
        For Each LineRow As DataGridViewRow In dgvAPCheckLog.Rows
            Try
                CheckNumber = LineRow.Cells("LogCheckNumberColumn").Value
            Catch ex As System.Exception
                CheckNumber = 1
            End Try
            Try
                VendorID = LineRow.Cells("LogVendorIDColumn").Value
            Catch ex As System.Exception
                VendorID = ""
            End Try
            Try
                CheckAmount = LineRow.Cells("LogCheckAmountColumn").Value
            Catch ex As System.Exception
                CheckAmount = 0
            End Try
            '*******************************************************************
            'Get Vendor Name, Account Number
            Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
            VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = VendorID
            VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim VendorAccountNumberStatement As String = "SELECT VendorAccountNumber FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VendorAccountNumberCommand As New SqlCommand(VendorAccountNumberStatement, con)
            VendorAccountNumberCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = VendorID
            VendorAccountNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim VendorTransitNumberStatement As String = "SELECT VendorRoutingNumber FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VendorTransitNumberCommand As New SqlCommand(VendorTransitNumberStatement, con)
            VendorTransitNumberCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = VendorID
            VendorTransitNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VendorName = CStr(VendorNameCommand.ExecuteScalar)
            Catch ex As Exception
                VendorName = ""
            End Try
            Try
                VendorAccountNumber = CStr(VendorAccountNumberCommand.ExecuteScalar)
            Catch ex As Exception
                VendorAccountNumber = ""
            End Try
            Try
                VendorTransitNumber = CStr(VendorTransitNumberCommand.ExecuteScalar)
            Catch ex As Exception
                VendorTransitNumber = ""
            End Try
            con.Close()
            '**************************************************************




            '***************************************************************
            'Column One
            DetailC01 = "D"
            '***************************************************************
            'Column Two
            VendorNameCharacterCount = VendorName.Length

            If VendorNameCharacterCount > 23 Then
                PayeeName = VendorName.Substring(0, 23)
            ElseIf VendorNameCharacterCount = 23 Then
                PayeeName = VendorName
            Else
                PayeeName = VendorName + BlankSpaceFiller.Substring(0, 23 - VendorNameCharacterCount)
            End If

            DetailC02 = PayeeName
            '***************************************************************
            'Column Three
            DetailC03 = FormattedDueDate
            '***************************************************************
            'Column Four
            Dim CountCheckCharacters As Integer = 0
            strCheckNumber = CStr(CheckNumber)
            CountCheckCharacters = strCheckNumber.Length
            strCheckNumber = ZeroSpaceFiller.Substring(0, 19 - CountCheckCharacters) + strCheckNumber

            DetailC04 = strCheckNumber
            '***************************************************************
            'Column Five
            DetailC05 = VendorTransitNumber
            '***************************************************************
            'Column Six
            VendorAccountCharacterCount = VendorAccountNumber.Length

            DetailC06 = VendorAccountNumber + BlankSpaceFiller.Substring(0, 12 - VendorAccountCharacterCount)
            '***************************************************************
            'Column Seven
            strCheckAmount = CheckAmount.ToString("0.00")
            strCheckAmount = strCheckAmount.Replace(".", "")
            CountCharacters = strCheckAmount.Length
            strCheckAmount = ZeroSpaceFiller.Substring(0, 10 - CountCharacters) + strCheckAmount

            DetailC07 = strCheckAmount
            '***************************************************************
            TotalDetailLine = DetailC01 + DetailC02 + DetailC03 + DetailC04 + DetailC05 + DetailC06 + DetailC07

            sw.WriteLine(TotalDetailLine)
            '***************************************************************
        Next
        '*************************************************************************************************************
        Dim TrailerC01, TrailerC02, TrailerC03, TrailerC04 As String
        Dim TotalTrailerLine As String = ""
        Dim CountPayments As Integer = 0
        Dim strCountPayment As String = ""
        Dim SumPayments As Double = 0
        Dim strSumPayments As String = ""

        'Create Trailer Record
        '4 Columns
        '#1 - Record Type (T for Trailer)
        '#2 - Total Number of payments (8 characters with leading zeros)
        '#3 - Total Value of payments (14 characters with leading zeros)
        '#4 - Filler (57 Spaces)
        '*********************************************************************
        Dim CountPaymentsStatement As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE APBatchNumber = @APBatchNumber AND DivisionID = @DivisionID"
        Dim CountPaymentsCommand As New SqlCommand(CountPaymentsStatement, con)
        CountPaymentsCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        CountPaymentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SumPaymentsStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE APBatchNumber = @APBatchNumber AND DivisionID = @DivisionID"
        Dim SumPaymentsCommand As New SqlCommand(SumPaymentsStatement, con)
        SumPaymentsCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        SumPaymentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountPayments = CInt(CountPaymentsCommand.ExecuteScalar)
        Catch ex As Exception
            CountPayments = 0
        End Try
        Try
            SumPayments = CDbl(SumPaymentsCommand.ExecuteScalar)
        Catch ex As Exception
            SumPayments = 0
        End Try
        con.Close()
        '*********************************************************************
        'Column One
        TrailerC01 = "T"
        '*********************************************************************
        'Column Two
        Dim CountNumberOfCharacters As Integer = 0
        strCountPayment = CStr(CountPayments)

        CountNumberOfCharacters = strCountPayment.Length
        strCountPayment = ZeroSpaceFiller.Substring(0, 8 - CountNumberOfCharacters) + strCountPayment

        TrailerC02 = strCountPayment
        '*********************************************************************
        'Column Three
        Dim CountNumberOfCharacters2 As Integer = 0
        strSumPayments = SumPayments.ToString("0.00")
        strSumPayments = strSumPayments.Replace(".", "")
        CountNumberOfCharacters2 = strSumPayments.Length
        strSumPayments = ZeroSpaceFiller.Substring(0, 14 - CountNumberOfCharacters2) + strSumPayments

        TrailerC03 = strSumPayments
        '*********************************************************************
        'Column Four
        TrailerC04 = "                                                         "
        '*********************************************************************
        TotalTrailerLine = TrailerC01 + TrailerC02 + TrailerC03 + TrailerC04

        sw.WriteLine(TotalTrailerLine)
        sw.Close()
        '*********************************************************************
        MsgBox("File has been created.", MsgBoxStyle.OkOnly)
    End Sub
End Class