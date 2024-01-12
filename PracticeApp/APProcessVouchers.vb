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
Public Class APProcessVouchers
    Inherits System.Windows.Forms.Form

    Dim NewCurrentYear, NewCurrentMonth, CurrentDay, CurrentMonth, CurrentYear, DueDays, DiscountDays, LineNumber, LastLineNumber, NextLineNumber, PONumber, ReceiverNumber, counter, LastVoucherNumber, NextVoucherNumber As Integer
    Dim Checked1099, ManualDiscountSelected, WhitePaper, OnHoldStatus, DefaultGLAccount, UniqueInvoice, GLDebitName, GLCreditName, VoucherStatus, DueDateStr, Comment, DefaultItem, GLDebitAccount, GLCreditAccount, GLDebitDescription, GLCreditDescription, VendorName, DivisionID, InvoiceNumber, InvoiceDate, VendorID, ReceiptDate, VendorPaymentTerms, VoucherPaymentTerms, DiscountDate, LongDescription, ItemClass As String
    Dim SUMInvoiceTotal, DiscountAmount, DiscountRate, TermDiscountTotal, RunningProductTotal, BatchAmount, ProductTotal, InvoiceFreight, InvoiceSalesTax, Quantity, InvoiceTotal As Double
    Dim InvoiceAmount, DiscountPercent, ExtendedAmount, UnitCost, SUMExtendedAmount As Double
    Dim NewDueDate, InvoiceDate1, DueDate, DiscountDate1 As Date
    Dim CheckCode, Temp1, VendorClass, VendorAddress1, VendorAddress2, VendorCity, VendorState, VendorZip, VendorCountry As String
    Dim CountVoucherLines, TempVoucherLine As Integer
    Dim CheckVoucherStatus As String = ""
    Dim CheckType As String = ""
    Dim TodaysDate As Date
    Dim CheckAndValidateDates As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Dim tabCount As Integer = 1

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0

    'Form operations

    Private Sub APProcessVouchers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PaymentTerms' table. You can move, or remove it, as needed.
        Me.PaymentTermsTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PaymentTerms)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ReceiptTransactionDescription' table. You can move, or remove it, as needed.
        Me.ReceiptTransactionDescriptionTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ReceiptTransactionDescription)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.VendorClass' table. You can move, or remove it, as needed.
        Me.VendorClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.VendorClass)

        ClearVariables()
        ClearAll()

        'Load default from Batch Form
        txtDivisionID.Text = GlobalAPDivisionID
        txtBatchNumber.Text = GlobalAPBatchNumber

        LoadVendor()
        LoadVoucher()
        LoadGLAccounts()
        LoadNonInventoryItems()
        ShowVoucherLines()

        'dtpDiscountDate.Text = Today.Date.ToShortDateString
        'dtpDueDate.Text = Today.Date.ToShortDateString
        'dtpInvoiceDate.Text = Today.Date.ToShortDateString
        'dtpReceiptDate.Text = Today.Date.ToShortDateString
    End Sub

    'Load datasets into controls

    Public Sub ShowVoucherLines()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber", con)
        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceiptOfInvoiceVoucherLines")
        dgvVoucherLines.DataSource = ds.Tables("ReceiptOfInvoiceVoucherLines")
        cboVoucherLine.DataSource = ds.Tables("ReceiptOfInvoiceVoucherLines")
        con.Close()
    End Sub

    Public Sub ClearDatagrid()
        Me.dgvVoucherLines.DataSource = Nothing
    End Sub

    Public Sub LoadVendor()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "Vendor")
        cboVendorID.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadVoucher()
        'Load Voucher Number for specific division
        cmd = New SqlCommand("SELECT VoucherNumber FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND (VoucherSource = @VoucherSource OR VoucherSource = @VoucherSource1) AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber
        cmd.Parameters.Add("@VoucherSource", SqlDbType.VarChar).Value = "VOUCHER RECEIPT"
        cmd.Parameters.Add("@VoucherSource1", SqlDbType.VarChar).Value = "RECURRING VOUCHER"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ReceiptOfInvoiceBatchLine")
        cboVoucherNumber.DataSource = ds2.Tables("ReceiptOfInvoiceBatchLine")
        con.Close()
        cboVoucherNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccounts()
        'Load GL Accounts
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber < @Canadian", con)
        cmd.Parameters.Add("@Canadian", SqlDbType.VarChar).Value = "C$"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLAccounts")
        cboDebitAccount.DataSource = ds3.Tables("GLAccounts")
        cboDebitDescription.DataSource = ds3.Tables("GLAccounts")
        con.Close()
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadNonInventoryItems()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT ItemID FROM NonInventoryItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "NonInventoryItemList")
        cboItemID.DataSource = ds4.Tables("NonInventoryItemList")
        con.Close()
        cboItemID.SelectedIndex = -1
    End Sub

    'Load data

    Public Sub LoadVoucherInfo()
        'Load the Voucher Totals
        Dim InvoiceNumberStatement As String = "SELECT InvoiceNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceNumberCommand As New SqlCommand(InvoiceNumberStatement, con)
        InvoiceNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceDateStatement As String = "SELECT InvoiceDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceDateCommand As New SqlCommand(InvoiceDateStatement, con)
        InvoiceDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorIDStatement As String = "SELECT VendorID FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim VendorIDCommand As New SqlCommand(VendorIDStatement, con)
        VendorIDCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        VendorIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim ProductTotalStatement As String = "SELECT ProductTotal FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceFreightStatement As String = "SELECT InvoiceFreight FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceFreightCommand As New SqlCommand(InvoiceFreightStatement, con)
        InvoiceFreightCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceFreightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceSalesTaxStatement As String = "SELECT InvoiceSalesTax FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceSalesTaxCommand As New SqlCommand(InvoiceSalesTaxStatement, con)
        InvoiceSalesTaxCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceSalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceTotalStatement As String = "SELECT InvoiceTotal FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceTotalCommand As New SqlCommand(InvoiceTotalStatement, con)
        InvoiceTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim ReceiptDateStatement As String = "SELECT ReceiptDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim ReceiptDateCommand As New SqlCommand(ReceiptDateStatement, con)
        ReceiptDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        ReceiptDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
        PaymentTermsCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim DiscountDateStatement As String = "SELECT DiscountDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim DiscountDateCommand As New SqlCommand(DiscountDateStatement, con)
        DiscountDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DiscountDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim DueDateStatement As String = "SELECT DueDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim DueDateCommand As New SqlCommand(DueDateStatement, con)
        DueDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DueDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim CommentStatement As String = "SELECT Comment FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim CommentCommand As New SqlCommand(CommentStatement, con)
        CommentCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        CommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim DiscountAmountStatement As String = "SELECT DiscountAmount FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim DiscountAmountCommand As New SqlCommand(DiscountAmountStatement, con)
        DiscountAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DiscountAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim VoucherStatusCommand As New SqlCommand(VoucherStatusStatement, con)
        VoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        VoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceAmountStatement As String = "SELECT InvoiceAmount FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceAmountCommand As New SqlCommand(InvoiceAmountStatement, con)
        InvoiceAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim CheckTypeStatement As String = "SELECT CheckType FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim CheckTypeCommand As New SqlCommand(CheckTypeStatement, con)
        CheckTypeCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        CheckTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim OnHoldStatusStatement As String = "SELECT OnHold FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim OnHoldStatusCommand As New SqlCommand(OnHoldStatusStatement, con)
        OnHoldStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        OnHoldStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim WhitePaperStatement As String = "SELECT WhitePaper FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim WhitePaperCommand As New SqlCommand(WhitePaperStatement, con)
        WhitePaperCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        WhitePaperCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim ManualDiscountSelectedStatement As String = "SELECT ManualDiscountSelected FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim ManualDiscountSelectedCommand As New SqlCommand(ManualDiscountSelectedStatement, con)
        ManualDiscountSelectedCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        ManualDiscountSelectedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim Checked1099Statement As String = "SELECT Checked1099 FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim Checked1099Command As New SqlCommand(Checked1099Statement, con)
        Checked1099Command.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        Checked1099Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            InvoiceNumber = CStr(InvoiceNumberCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceNumber = ""
        End Try
        Try
            InvoiceDate = CStr(InvoiceDateCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceDate = ""
        End Try
        Try
            VendorID = CStr(VendorIDCommand.ExecuteScalar)
        Catch ex As Exception
            VendorID = ""
        End Try
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            InvoiceFreight = CDbl(InvoiceFreightCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceFreight = 0
        End Try
        Try
            InvoiceSalesTax = CDbl(InvoiceSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceSalesTax = 0
        End Try
        Try
            InvoiceTotal = CDbl(InvoiceTotalCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceTotal = 0
        End Try
        Try
            ReceiptDate = CStr(ReceiptDateCommand.ExecuteScalar)
        Catch ex As Exception
            ReceiptDate = ""
        End Try
        Try
            VoucherPaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
        Catch ex As Exception
            VoucherPaymentTerms = "N30"
        End Try
        Try
            DiscountDate = CStr(DiscountDateCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountDate = ""
        End Try
        Try
            DueDateStr = CStr(DueDateCommand.ExecuteScalar)
        Catch ex As Exception
            DueDateStr = ""
        End Try
        Try
            Comment = CStr(CommentCommand.ExecuteScalar)
        Catch ex As Exception
            Comment = ""
        End Try
        Try
            DiscountAmount = CDbl(DiscountAmountCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountAmount = 0
        End Try
        Try
            VoucherStatus = CStr(VoucherStatusCommand.ExecuteScalar)
        Catch ex As Exception
            VoucherStatus = ""
        End Try
        Try
            InvoiceAmount = CDbl(InvoiceAmountCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceAmount = 0
        End Try
        Try
            CheckType = CStr(CheckTypeCommand.ExecuteScalar)
        Catch ex As Exception
            CheckType = "STANDARD"
        End Try
        Try
            OnHoldStatus = CStr(OnHoldStatusCommand.ExecuteScalar)
        Catch ex As Exception
            OnHoldStatus = "NO"
        End Try
        Try
            WhitePaper = CStr(WhitePaperCommand.ExecuteScalar)
        Catch ex As Exception
            WhitePaper = "NO"
        End Try
        Try
            ManualDiscountSelected = CStr(ManualDiscountSelectedCommand.ExecuteScalar)
        Catch ex As Exception
            ManualDiscountSelected = "NO"
        End Try
        Try
            Checked1099 = CStr(Checked1099Command.ExecuteScalar)
        Catch ex As Exception
            Checked1099 = "NO"
        End Try
        con.Close()

        txtInvoiceNumber.Text = InvoiceNumber
        txtComment.Text = Comment
        dtpInvoiceDateDD.Text = InvoiceDate
        cboVendorID.Text = VendorID
        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
        txtFreightTotal.Text = InvoiceFreight
        txtSalesTaxTotal.Text = InvoiceSalesTax
        txtInvoiceAmount.Text = InvoiceAmount
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        dtpReceiptDateDD.Text = ReceiptDate
        dtpDueDateDD.Text = DueDateStr
        dtpDiscountDateDD.Text = DiscountDate
        txtDiscountAmount.Text = DiscountAmount
        cboPaymentTerms.Text = VoucherPaymentTerms
        cboCheckType.Text = CheckType

        If cboPaymentTerms.Text = "CREDIT CARD" Then
            cboPaymentTerms.ForeColor = Color.Red
        Else
            cboPaymentTerms.ForeColor = Color.Black
        End If
        If WhitePaper = "YES" Then
            chkWhitePaper.Checked = True
        Else
            chkWhitePaper.Checked = False
        End If
        If ManualDiscountSelected = "YES" Then
            chkManualDiscount.Checked = True
        Else
            chkManualDiscount.Checked = False
        End If

        'If Check Type is not standard, remove White Paper Check designation
        If CheckType = "STANDARD" Then
            chkWhitePaper.Enabled = True
        ElseIf CheckType = "ACH" Then
            chkWhitePaper.Checked = False
            chkWhitePaper.Enabled = False
        ElseIf CheckType = "FEDEX" Then
            chkWhitePaper.Checked = False
            chkWhitePaper.Enabled = False
        ElseIf CheckType = "INTERCOMPANY" Then
            chkWhitePaper.Checked = False
            chkWhitePaper.Enabled = False
        End If

        If OnHoldStatus = "YES" Then
            chkOnHold.Checked = True
        Else
            chkOnHold.Checked = False
        End If

        If VoucherStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdEnterLine.Enabled = False
            cmdEnterVoucher.Enabled = False
            cmdSave.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnterLine.Enabled = True
            cmdEnterVoucher.Enabled = True
            cmdSave.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            DeleteToolStripMenuItem.Enabled = True
        End If
    End Sub

    Public Sub LoadRemitToAddress()
        Dim VendorAddress1Statement As String = "SELECT VendorAddress1 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorAddress1Command As New SqlCommand(VendorAddress1Statement, con)
        VendorAddress1Command.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorAddress2Statement As String = "SELECT VendorAddress2 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorAddress2Command As New SqlCommand(VendorAddress2Statement, con)
        VendorAddress2Command.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorCityStatement As String = "SELECT VendorCity FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorCityCommand As New SqlCommand(VendorCityStatement, con)
        VendorCityCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorStateStatement As String = "SELECT VendorState FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorStateCommand As New SqlCommand(VendorStateStatement, con)
        VendorStateCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorZipStatement As String = "SELECT VendorZip FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorZipCommand As New SqlCommand(VendorZipStatement, con)
        VendorZipCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorCountryStatement As String = "SELECT VendorCountry FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorCountryCommand As New SqlCommand(VendorCountryStatement, con)
        VendorCountryCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorAddress1 = CStr(VendorAddress1Command.ExecuteScalar)
        Catch ex As Exception
            VendorAddress1 = ""
        End Try
        Try
            VendorAddress2 = CStr(VendorAddress2Command.ExecuteScalar)
        Catch ex As Exception
            VendorAddress2 = ""
        End Try
        Try
            VendorCity = CStr(VendorCityCommand.ExecuteScalar)
        Catch ex As Exception
            VendorCity = ""
        End Try
        Try
            VendorState = CStr(VendorStateCommand.ExecuteScalar)
        Catch ex As Exception
            VendorState = ""
        End Try
        Try
            VendorZip = CStr(VendorZipCommand.ExecuteScalar)
        Catch ex As Exception
            VendorZip = ""
        End Try
        Try
            VendorCountry = CStr(VendorCountryCommand.ExecuteScalar)
        Catch ex As Exception
            VendorCountry = ""
        End Try
        con.Close()

        txtRemitToAddress1.Text = VendorAddress1
        txtRemitToAddress2.Text = VendorAddress2
        txtRemitToCity.Text = VendorCity
        txtRemitToCountry.Text = VendorCountry
        txtRemitToZip.Text = VendorZip
        txtRemitToState.Text = VendorState
    End Sub

    Public Sub LoadItemData()
        Dim LongDescriptionStatement As String = "SELECT ShortDescription FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboItemID.Text
        LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim GLDebitAccountStatement As String = "SELECT GLDebitAccount FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GLDebitAccountCommand As New SqlCommand(GLDebitAccountStatement, con)
        GLDebitAccountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboItemID.Text
        GLDebitAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim GLCreditAccountStatement As String = "SELECT GLCreditAccount FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GLCreditAccountCommand As New SqlCommand(GLCreditAccountStatement, con)
        GLCreditAccountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboItemID.Text
        GLCreditAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LongDescription = CStr(LongDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            LongDescription = ""
        End Try
        Try
            GLDebitAccount = CStr(GLDebitAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLDebitAccount = cboDebitAccount.Text
        End Try
        Try
            GLCreditAccount = CStr(GLCreditAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLCreditAccount = cboCreditAccount.Text
        End Try
        con.Close()

        txtLongDescription.Text = LongDescription
        cboCreditAccount.Text = GLCreditAccount
        cboDebitAccount.Text = GLDebitAccount
    End Sub

    Public Sub LoadLineData()
        Dim LinePartNumber, LineDescription As String
        txtLinePartNumber.Clear()
        txtLinePartDescription.Clear()

        Dim LinePartNumberStatement As String = "SELECT PartNumber FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
        Dim LinePartNumberCommand As New SqlCommand(LinePartNumberStatement, con)
        LinePartNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        LinePartNumberCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboVoucherLine.Text)

        Dim LinePartDescriptionStatement As String = "SELECT PartDescription FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
        Dim LinePartDescriptionCommand As New SqlCommand(LinePartDescriptionStatement, con)
        LinePartDescriptionCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        LinePartDescriptionCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboVoucherLine.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LinePartNumber = CStr(LinePartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LinePartNumber = ""
        End Try
        Try
            LineDescription = CStr(LinePartDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            LineDescription = ""
        End Try
        con.Close()

        txtLinePartNumber.Text = LinePartNumber
        txtLinePartDescription.Text = LineDescription
    End Sub

    Public Sub LoadPaymentTermDetails()
        Dim DiscountPercentStatement As String = "SELECT DiscountPercent FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
        DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

        Dim DiscountDaysStatement As String = "SELECT DiscountDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DiscountDaysCommand As New SqlCommand(DiscountDaysStatement, con)
        DiscountDaysCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

        Dim DueDaysStatement As String = "SELECT DueDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DueDaysCommand As New SqlCommand(DueDaysStatement, con)
        DueDaysCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DiscountPercent = CDbl(DiscountPercentCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountPercent = 0
        End Try
        Try
            DiscountDays = CInt(DiscountDaysCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountDays = 0
        End Try
        Try
            DueDays = CInt(DueDaysCommand.ExecuteScalar)
        Catch ex As Exception
            DueDays = 0
        End Try
        con.Close()

        DiscountRate = DiscountPercent

        'Commands to determine Discount and Due Dates
        InvoiceDate1 = dtpInvoiceDateDD.Text

        If cboPaymentTerms.Text = "20thNet" Then
            CurrentDay = InvoiceDate1.Day
            CurrentMonth = InvoiceDate1.Month
            CurrentYear = InvoiceDate1.Year

            If CurrentMonth = 12 Then
                NewCurrentMonth = 1
                NewCurrentYear = CurrentYear + 1
            Else
                NewCurrentMonth = CurrentMonth + 1
                NewCurrentYear = CurrentYear
            End If

            NewDueDate = CStr(NewCurrentMonth) + "/20/" + CStr(NewCurrentYear)

            dtpDueDateDD.Text = NewDueDate
            dtpDiscountDateDD.Text = NewDueDate
        ElseIf cboPaymentTerms.Text = "15thNet" Then
            CurrentDay = InvoiceDate1.Day
            CurrentMonth = InvoiceDate1.Month
            CurrentYear = InvoiceDate1.Year

            If CurrentMonth = 12 Then
                NewCurrentMonth = 1
                NewCurrentYear = CurrentYear + 1
            Else
                NewCurrentMonth = CurrentMonth + 1
                NewCurrentYear = CurrentYear
            End If

            NewDueDate = CStr(NewCurrentMonth) + "/15/" + CStr(NewCurrentYear)

            dtpDueDateDD.Text = NewDueDate
            dtpDiscountDateDD.Text = NewDueDate
        ElseIf cboPaymentTerms.Text = "10thNet" Then
            CurrentDay = InvoiceDate1.Day
            CurrentMonth = InvoiceDate1.Month
            CurrentYear = InvoiceDate1.Year

            If CurrentMonth = 12 Then
                NewCurrentMonth = 1
                NewCurrentYear = CurrentYear + 1
            Else
                NewCurrentMonth = CurrentMonth + 1
                NewCurrentYear = CurrentYear
            End If

            NewDueDate = CStr(NewCurrentMonth) + "/10/" + CStr(NewCurrentYear)

            dtpDueDateDD.Text = NewDueDate
            dtpDiscountDateDD.Text = NewDueDate
        ElseIf cboPaymentTerms.Text = "1rstNet" Then
            CurrentDay = InvoiceDate1.Day
            CurrentMonth = InvoiceDate1.Month
            CurrentYear = InvoiceDate1.Year

            If CurrentMonth = 12 Then
                NewCurrentMonth = 1
                NewCurrentYear = CurrentYear + 1
            Else
                NewCurrentMonth = CurrentMonth + 1
                NewCurrentYear = CurrentYear
            End If

            NewDueDate = CStr(NewCurrentMonth) + "/01/" + CStr(NewCurrentYear)

            dtpDueDateDD.Text = NewDueDate
            dtpDiscountDateDD.Text = NewDueDate
        ElseIf cboPaymentTerms.Text = "9thNET" Then
            CurrentDay = InvoiceDate1.Day
            CurrentMonth = InvoiceDate1.Month
            CurrentYear = InvoiceDate1.Year

            If CurrentMonth = 12 Then
                NewCurrentMonth = 1
                NewCurrentYear = CurrentYear + 1
            Else
                NewCurrentMonth = CurrentMonth + 1
                NewCurrentYear = CurrentYear
            End If

            NewDueDate = CStr(NewCurrentMonth) + "/09/" + CStr(NewCurrentYear)

            dtpDueDateDD.Text = NewDueDate
            dtpDiscountDateDD.Text = NewDueDate
        Else
            If DiscountDays = 0 Then
                DiscountDays = DueDays
            Else
                'Do nothing
            End If

            DueDate = InvoiceDate1.AddDays(DueDays)
            DiscountDate1 = InvoiceDate1.AddDays(DiscountDays)

            dtpDiscountDateDD.Text = DiscountDate1
            dtpDueDateDD.Text = DueDate
        End If

        If chkManualDiscount.Checked = True Then
            'Do nothing
        Else
            If DiscountPercent > 0 Then
                ReLoadVoucherTotals()
            End If
        End If
    End Sub

    Public Sub LoadIntercompanyDueDate()
        Dim DissectInvoiceDate As Date
        Dim intDay, intMonth, intYear As Integer
        Dim intNewDay, intNewMonth, intNewYear As Integer
        Dim strNewDay, strNewMonth, strNewYear As String
        Dim strInterCompanyDueDate As String = ""
        DissectInvoiceDate = dtpInvoiceDateDD.Value

        intDay = DissectInvoiceDate.Day
        intMonth = DissectInvoiceDate.Month
        intYear = DissectInvoiceDate.Year

        If intDay <= 15 Then
            intNewDay = 5
            If intMonth < 12 Then
                intNewMonth = intMonth + 1
            Else
                intNewMonth = 1
            End If
        Else
            intNewDay = 20
            If intMonth < 12 Then
                intNewMonth = intMonth + 1
            Else
                intNewMonth = 1
            End If
        End If

        If intMonth = 12 Then
            intNewYear = intYear + 1
        Else
            intNewYear = intYear
        End If

        strNewDay = CStr(intNewDay)
        strNewMonth = CStr(intNewMonth)
        strNewYear = CStr(intNewYear)

        strInterCompanyDueDate = strNewMonth + "/" + strNewDay + "/" + strNewYear

        dtpDiscountDateDD.Text = strInterCompanyDueDate
        dtpDueDateDD.Text = strInterCompanyDueDate
    End Sub

    Public Sub LoadFEDEXDueDate()
        Dim DissectInvoiceDate As Date
        Dim intDay, intMonth, intYear As Integer
        Dim intNewDay, intNewMonth, intNewYear As Integer
        Dim strNewDay, strNewMonth, strNewYear As String
        Dim strFedexDueDate As String = ""
        DissectInvoiceDate = dtpInvoiceDateDD.Value

        intDay = DissectInvoiceDate.Day
        intMonth = DissectInvoiceDate.Month
        intYear = DissectInvoiceDate.Year

        If intDay <= 10 Then
            intNewDay = 15
            intNewMonth = intMonth
        ElseIf intDay > 10 And intDay <= 20 Then
            intNewDay = 25
            intNewMonth = intMonth
        ElseIf intDay > 20 And intDay <= 31 Then
            intNewDay = 5
            If intMonth < 12 Then
                intNewMonth = intMonth + 1
            Else
                intNewMonth = 1
            End If
        Else
            'Do nothing
        End If

        If intMonth = 12 And intNewDay = 5 Then
            intNewYear = intYear + 1
        Else
            intNewYear = intYear
        End If

        strNewDay = CStr(intNewDay)
        strNewMonth = CStr(intNewMonth)
        strNewYear = CStr(intNewYear)

        strFedexDueDate = strNewMonth + "/" + strNewDay + "/" + strNewYear

        dtpDiscountDateDD.Text = strFedexDueDate
        dtpDueDateDD.Text = strFedexDueDate
    End Sub

    Public Sub LoadVendorDefaults()
        'Command to load Payment Terms from Vendor
        Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
        PaymentTermsCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim DefaultItemStatement As String = "SELECT DefaultItem FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim DefaultItemCommand As New SqlCommand(DefaultItemStatement, con)
        DefaultItemCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        DefaultItemCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim DefaultGLAccountStatement As String = "SELECT DefaultGLAccount FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim DefaultGLAccountCommand As New SqlCommand(DefaultGLAccountStatement, con)
        DefaultGLAccountCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        DefaultGLAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
        VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim CheckCodeStatement As String = "SELECT CheckCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim CheckCodeCommand As New SqlCommand(CheckCodeStatement, con)
        CheckCodeCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        CheckCodeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim WhitePaperCheckStatement As String = "SELECT WhitePaperCheck FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim WhitePaperCheckCommand As New SqlCommand(WhitePaperCheckStatement, con)
        WhitePaperCheckCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        WhitePaperCheckCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim Checked1099CheckStatement As String = "SELECT Checked1099 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim Checked1099CheckCommand As New SqlCommand(Checked1099CheckStatement, con)
        Checked1099CheckCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        Checked1099CheckCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorPaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
        Catch ex As Exception
            VendorPaymentTerms = "N30"
        End Try
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
        End Try
        Try
            DefaultItem = CStr(DefaultItemCommand.ExecuteScalar)
        Catch ex As Exception
            DefaultItem = ""
        End Try
        Try
            DefaultGLAccount = CStr(DefaultGLAccountCommand.ExecuteScalar)
        Catch ex As Exception
            DefaultGLAccount = ""
        End Try
        Try
            VendorClass = CStr(VendorClassCommand.ExecuteScalar)
        Catch ex As Exception
            VendorClass = ""
        End Try
        Try
            CheckCode = CStr(CheckCodeCommand.ExecuteScalar)
        Catch ex As Exception
            CheckCode = "STANDARD"
        End Try
        Try
            WhitePaper = CStr(WhitePaperCheckCommand.ExecuteScalar)
        Catch ex As Exception
            WhitePaper = "NO"
        End Try
        Try
            Checked1099 = CStr(Checked1099CheckCommand.ExecuteScalar)
        Catch ex As Exception
            Checked1099 = "NO"
        End Try
        con.Close()

        If CheckCode = "" Then
            CheckCode = "STANDARD"
        End If
        If WhitePaper = "YES" Then
            chkWhitePaper.Checked = True
        Else
            chkWhitePaper.Checked = False
        End If

        'Load text boxes
        txtVendorName.Text = VendorName
        cboPaymentTerms.Text = VendorPaymentTerms
        cboVendorClass.Text = VendorClass
        cboCheckType.Text = CheckCode

        If cboPaymentTerms.Text = "CREDIT CARD" Then
            cboPaymentTerms.ForeColor = Color.Red
        Else
            cboPaymentTerms.ForeColor = Color.Black
        End If
        If DefaultItem = "" And DefaultGLAccount <> "" Then
            cboItemID.SelectedIndex = -1
            txtLongDescription.Clear()
            cboDebitAccount.Text = DefaultGLAccount
        ElseIf DefaultGLAccount = "" And DefaultItem <> "" Then
            cboItemID.Text = DefaultItem
        ElseIf DefaultGLAccount <> "" And DefaultItem <> "" Then
            cboItemID.Text = DefaultItem
            cboDebitAccount.Text = DefaultGLAccount
        Else
            cboDebitAccount.SelectedIndex = -1
            cboItemID.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadGLDebitAccountName()
        Dim GLDebitNameStatement As String = "SELECT GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim GLDebitNameCommand As New SqlCommand(GLDebitNameStatement, con)
        GLDebitNameCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboDebitAccount.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GLDebitName = CStr(GLDebitNameCommand.ExecuteScalar)
        Catch ex As Exception
            GLDebitName = ""
        End Try
        con.Close()

        cboDebitDescription.Text = GLDebitName
    End Sub

    Public Sub LoadGLCreditAccountName()
        Dim GLCreditNameStatement As String = "SELECT GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim GLCreditNameCommand As New SqlCommand(GLCreditNameStatement, con)
        GLCreditNameCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboCreditAccount.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GLCreditName = CStr(GLCreditNameCommand.ExecuteScalar)
        Catch ex As Exception
            GLCreditName = ""
        End Try
        con.Close()

        cboCreditDescription.Text = GLCreditName
    End Sub

    Public Sub LoadVoucherTotals()
        'Only used when voucher is loaded - else use re-load
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        Dim InvoiceFreightStatement As String = "SELECT InvoiceFreight FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim InvoiceFreightCommand As New SqlCommand(InvoiceFreightStatement, con)
        InvoiceFreightCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        Dim InvoiceSalesTaxStatement As String = "SELECT InvoiceSalesTax FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim InvoiceSalesTaxCommand As New SqlCommand(InvoiceSalesTaxStatement, con)
        InvoiceSalesTaxCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            InvoiceFreight = CDbl(InvoiceFreightCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceFreight = 0
        End Try
        Try
            InvoiceSalesTax = CDbl(InvoiceSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceSalesTax = 0
        End Try
        con.Close()

        If chkManualDiscount.Checked = True Then
            DiscountAmount = Val(txtDiscountAmount.Text)
        Else
            DiscountAmount = DiscountRate * ProductTotal
        End If

        DiscountAmount = Math.Round(DiscountAmount, 2)
        ProductTotal = Math.Round(ProductTotal, 2)
        InvoiceFreight = Math.Round(InvoiceFreight, 2)
        InvoiceSalesTax = Math.Round(InvoiceSalesTax, 2)
        InvoiceTotal = Math.Round(InvoiceTotal, 2)

        InvoiceTotal = ProductTotal + InvoiceSalesTax + InvoiceFreight

        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
        txtFreightTotal.Text = InvoiceFreight
        txtSalesTaxTotal.Text = InvoiceSalesTax
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtDiscountAmount.Text = DiscountAmount
    End Sub

    Public Sub ReLoadVoucherTotals()
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        con.Close()

        If chkManualDiscount.Checked = True Then
            DiscountAmount = Val(txtDiscountAmount.Text)
        Else
            DiscountAmount = DiscountRate * ProductTotal
        End If
        con.Close()

        DiscountAmount = Math.Round(DiscountAmount, 2)
        ProductTotal = Math.Round(ProductTotal, 2)

        InvoiceSalesTax = Val(txtSalesTaxTotal.Text)
        InvoiceFreight = Val(txtFreightTotal.Text)

        InvoiceFreight = Math.Round(InvoiceFreight, 2)
        InvoiceSalesTax = Math.Round(InvoiceSalesTax, 2)

        InvoiceTotal = ProductTotal + InvoiceSalesTax + InvoiceFreight
        InvoiceTotal = Math.Round(InvoiceTotal, 2)

        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtDiscountAmount.Text = DiscountAmount
    End Sub

    Public Sub UpdateBatchTotal()
        Dim SUMInvoiceTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber"
        Dim SUMInvoiceTotalCommand As New SqlCommand(SUMInvoiceTotalStatement, con)
        SUMInvoiceTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SUMInvoiceTotal = CDbl(SUMInvoiceTotalCommand.ExecuteScalar)
        Catch ex As Exception
            SUMInvoiceTotal = 0
        End Try
        con.Close()

        SUMInvoiceTotal = Math.Round(SUMInvoiceTotal, 2)

        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = SUMInvoiceTotal

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Validation and clear functions

    Public Sub ValidateDates()
        'Check to see if Invoice Date, Due Date, or Discount Date is more than 60 days different from today
        Dim CheckInvoiceDate, CheckDueDate, CheckDiscountDate As Date
        Dim DateDifference1 As Integer = 0
        Dim DateDifference2 As Integer = 0
        Dim DateDifference3 As Integer = 0

        TodaysDate = Today()
        CheckInvoiceDate = dtpInvoiceDateDD.Value
        CheckDueDate = dtpDueDateDD.Value
        CheckDiscountDate = dtpDiscountDateDD.Value

        'Invoice Date
        If CheckInvoiceDate > TodaysDate Then
            DateDifference1 = DateDiff(DateInterval.Day, TodaysDate, CheckInvoiceDate)
        Else
            DateDifference1 = DateDiff(DateInterval.Day, CheckInvoiceDate, TodaysDate)
        End If

        'Due Date
        If CheckDueDate > TodaysDate Then
            DateDifference2 = DateDiff(DateInterval.Day, TodaysDate, CheckDueDate)
        Else
            DateDifference2 = DateDiff(DateInterval.Day, CheckDueDate, TodaysDate)
        End If

        'Discount Date
        If CheckDiscountDate > TodaysDate Then
            DateDifference3 = DateDiff(DateInterval.Day, TodaysDate, CheckDiscountDate)
        Else
            DateDifference3 = DateDiff(DateInterval.Day, CheckDiscountDate, TodaysDate)
        End If

        If DateDifference1 < 90 And DateDifference2 < 90 And DateDifference3 < 90 Then
            CheckAndValidateDates = "OKAY"
        Else
            CheckAndValidateDates = "NOT OKAY"
        End If
    End Sub

    Public Sub VerifyUniqueInvoiceNumber()
        Dim UniqueInvoiceStatement As String = "SELECT InvoiceNumber FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherNumber <> @VoucherNumber AND InvoiceNumber = @InvoiceNumber AND VendorID = @VendorID"
        Dim UniqueInvoiceCommand As New SqlCommand(UniqueInvoiceStatement, con)
        UniqueInvoiceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        UniqueInvoiceCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        UniqueInvoiceCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
        UniqueInvoiceCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UniqueInvoice = CStr(UniqueInvoiceCommand.ExecuteScalar)
        Catch ex As Exception
            UniqueInvoice = "YES"
        End Try
        con.Close()

        If UniqueInvoice = "" Then
            UniqueInvoice = "YES"
        End If
    End Sub

    Public Sub VerifyDiscount()
        Dim DiscountPercentStatement As String = "SELECT DiscountPercent FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
        DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

        Dim DiscountDaysStatement As String = "SELECT DiscountDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DiscountDaysCommand As New SqlCommand(DiscountDaysStatement, con)
        DiscountDaysCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DiscountPercent = CDbl(DiscountPercentCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountPercent = 0
        End Try
        Try
            DiscountDays = CInt(DiscountDaysCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountDays = 0
        End Try
        con.Close()

        DiscountRate = DiscountPercent
    End Sub

    Public Sub ClearAll()
        'Clear Invoice Header
        cboVoucherNumber.Text = ""
        cboCreditAccount.Text = ""
        cboCreditDescription.Text = ""
        cboDebitAccount.Text = ""
        cboDebitDescription.Text = ""
        cboItemID.Text = ""
        cboPaymentTerms.Text = ""
        cboVendorID.Text = ""
        cboCheckType.Text = ""

        cboVoucherNumber.Refresh()
        cboCreditAccount.Refresh()
        cboCreditDescription.Refresh()
        cboDebitAccount.Refresh()
        cboDebitDescription.Refresh()
        cboItemID.Refresh()
        cboPaymentTerms.Refresh()
        cboVendorID.Refresh()
        cboCheckType.Refresh()

        cboPaymentTerms.SelectedIndex = -1
        cboVoucherNumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboItemID.SelectedIndex = -1
        cboDebitAccount.SelectedIndex = -1
        cboCreditAccount.SelectedIndex = -1
        cboCreditDescription.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1
        cboVoucherLine.SelectedIndex = -1
        cboCheckType.SelectedIndex = -1

        dtpDiscountDateDD.Text = ""
        dtpReceiptDateDD.Text = ""
        dtpInvoiceDateDD.Text = ""
        dtpDueDateDD.Text = ""

        txtComment.Refresh()
        txtExtendedAmount.Refresh()
        txtFreightTotal.Refresh()
        txtInvoiceAmount.Refresh()
        txtInvoiceNumber.Refresh()
        txtLongDescription.Refresh()
        txtPurchaseTotal.Refresh()
        txtQuantity.Refresh()
        txtSalesTaxTotal.Refresh()
        txtUnitCost.Refresh()
        txtVendorName.Refresh()
        txtInvoiceTotal.Refresh()
        txtDiscountAmount.Refresh()

        txtComment.Clear()
        txtExtendedAmount.Clear()
        txtFreightTotal.Clear()
        txtInvoiceAmount.Clear()
        txtInvoiceNumber.Clear()
        txtLongDescription.Clear()
        txtPurchaseTotal.Clear()
        txtQuantity.Clear()
        txtSalesTaxTotal.Clear()
        txtUnitCost.Clear()
        txtVendorName.Clear()
        txtInvoiceTotal.Clear()
        txtDiscountAmount.Clear()
        txtRemitToAddress1.Clear()
        txtRemitToAddress2.Clear()
        txtRemitToCity.Clear()
        txtRemitToCountry.Clear()
        txtRemitToVendorID.Clear()
        txtRemitToState.Clear()
        txtRemitToVendorName.Clear()
        txtRemitToZip.Clear()
        txtLinePartNumber.Clear()
        txtLinePartDescription.Clear()

        lblCheckCode.Text = ""

        chkManualDiscount.Checked = False
        chkWhitePaper.Checked = False
        chkOnHold.Checked = False

        txtDiscountAmount.Enabled = False
        cboPaymentTerms.Enabled = True

        cmdGenerateVoucher.Focus()

        cmdDelete.Enabled = True
        cmdEnterLine.Enabled = True
        cmdEnterVoucher.Enabled = True
        cmdSave.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        DeleteToolStripMenuItem.Enabled = True
    End Sub

    Public Sub ClearVariables()
        DueDays = 0
        DiscountDays = 0
        LineNumber = 0
        LastLineNumber = 0
        NextLineNumber = 0
        Quantity = 0
        PONumber = 0
        ReceiverNumber = 0
        counter = 0
        LastVoucherNumber = 0
        NextVoucherNumber = 0
        GLDebitName = ""
        GLCreditName = ""
        VoucherStatus = ""
        DueDateStr = ""
        Comment = ""
        DefaultItem = ""
        GLDebitAccount = ""
        GLCreditAccount = ""
        GLDebitDescription = ""
        GLCreditDescription = ""
        VendorName = ""
        InvoiceNumber = ""
        InvoiceDate = ""
        VendorID = ""
        ReceiptDate = ""
        VendorPaymentTerms = ""
        VoucherPaymentTerms = ""
        DiscountDate = ""
        LongDescription = ""
        ItemClass = ""
        SUMInvoiceTotal = 0
        DiscountAmount = 0
        DiscountRate = 0
        TermDiscountTotal = 0
        RunningProductTotal = 0
        BatchAmount = 0
        ProductTotal = 0
        InvoiceFreight = 0
        InvoiceSalesTax = 0
        InvoiceTotal = 0
        DiscountPercent = 0
        ExtendedAmount = 0
        UnitCost = 0
        SUMExtendedAmount = 0
        InvoiceAmount = 0
        UniqueInvoice = ""
        DefaultGLAccount = ""
        VendorAddress1 = ""
        VendorAddress2 = ""
        VendorCity = ""
        VendorCountry = ""
        VendorZip = ""
        VendorState = ""
        VendorName = ""
        GlobalVoucherNumber = 0
        VendorClass = ""
        InvoiceAmount = 0
        CheckType = "STANDARD"
        OnHoldStatus = "NO"
        CheckCode = ""
        CheckAndValidateDates = ""
        ManualDiscountSelected = ""
        Checked1099 = "NO"

        InvoiceDate1 = Today()
        DueDate = Today()
        DiscountDate1 = Today()

        cmdDelete.Enabled = True
        cmdEnterLine.Enabled = True
        cmdEnterVoucher.Enabled = True
        cmdSave.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        DeleteToolStripMenuItem.Enabled = True
    End Sub

    Private Function checkRecurring() As Boolean
        cmd = New SqlCommand("SELECT VoucherSource, DeleteReferenceNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        Dim sour As String = ""
        Dim refer As Integer = 0
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.GetValue(0)) Then
                sour = ""
            Else
                sour = reader.GetValue(0)
            End If
            If IsDBNull(reader.GetValue(1)) Then
                refer = 0
            Else
                refer = reader.GetValue(1)
            End If
        Else
            sour = ""
            refer = 0
        End If
        reader.Close()
        con.Close()
        If sour = "RECURRING VOUCHER" Then
            cmd = New SqlCommand("SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND VoucherStatus = 'RECURRING'", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = refer
            If con.State = ConnectionState.Closed Then con.Open()
            Dim cnt As Integer = cmd.ExecuteScalar()
            con.Close()
            If cnt > 0 Then
                ''since a batch exists for this will send it back to the master
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = DeleteReferenceNumber, VoucherStatus = 'RECURRING', DeleteReferenceNumber = 0 WHERE BatchNumber = @BatchNumber AND VoucherNumber = @VoucherNumber", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = txtBatchNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                Dim LastBatchNumber As Integer = 0
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

                Dim NextBatchNumber As Integer = LastBatchNumber + 1

                cmd = New SqlCommand("INSERT INTO ReceiptOfInvoiceBatchHeader (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus) Values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @divisionID, @BatchStatus)", con)
                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber.ToString()
                    .Add("@BatchDate", SqlDbType.VarChar).Value = Today.ToString()
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = "0"
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = "RECURRING VOUCHER"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "RECURRING"
                End With
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = @NewBatch, VoucherStatus = 'RECURRING', DeleteReferenceNumber = 0 WHERE BatchNumber = @BatchNumber AND VoucherNumber = @VoucherNumber", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = cboVoucherNumber.Text
                cmd.Parameters.Add("@NewBatch", SqlDbType.VarChar).Value = NextBatchNumber.ToString()
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = txtBatchNumber.Text

                cmd.ExecuteNonQuery()
                con.Close()
            End If
            Return True
        End If
        Return False
    End Function

    'Save and Insert Routines

    Public Sub InsertIntoHeaderTable()
        'Get Max Voucher Number
        Dim MaxVoucherNumber As Integer = 0
        Dim NextVoucherNumber As Integer = 0

        Dim MaxVoucherNumberStatement As String = "SELECT MAX(VoucherNumber) FROM ReceiptOfInvoiceBatchLine"
        Dim MaxVoucherNumberCommand As New SqlCommand(MaxVoucherNumberStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxVoucherNumber = CInt(MaxVoucherNumberCommand.ExecuteScalar)
        Catch ex1 As Exception
            MaxVoucherNumber = 0
        End Try
        con.Close()

        NextVoucherNumber = MaxVoucherNumber + 1

        cboVoucherNumber.Text = NextVoucherNumber

        If Checked1099 = "" Then
            Checked1099 = "NO"
        End If

        'Write Data to Batch Line (Voucher Header) Database Table
        cmd = New SqlCommand("Insert Into ReceiptOfInvoiceBatchLine(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, VendorID, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, ReceiptDate, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, DeleteReferenceNumber, InvoiceAmount, VendorClass, OnHold, CheckType, TempSelected, SelectedInDatagrid, WhitePaper, ManualDiscountSelected, Checked1099)Values(@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @VendorID, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @ReceiptDate, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @DeleteReferenceNumber, @InvoiceAmount, @VendorClass, @OnHold, @CheckType, @TempSelected, @SelectedInDatagrid, @WhitePaper, @ManualDiscountSelected, @Checked1099)", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDateDD.Text
            .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDateDD.Text
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = Val(txtFreightTotal.Text)
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = Val(txtSalesTaxTotal.Text)
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtInvoiceAmount.Text)
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
            .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDiscountDateDD.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDateDD.Text
            .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@VoucherSource", SqlDbType.VarChar).Value = "VOUCHER RECEIPT"
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = 0
            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
            .Add("@TempSelected", SqlDbType.VarChar).Value = ""
            .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
            .Add("@WhitePaper", SqlDbType.VarChar).Value = "NO"
            .Add("@ManualDiscountSelected", SqlDbType.VarChar).Value = "NO"
            .Add("@Checked1099", SqlDbType.VarChar).Value = Checked1099
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub UpdateHeaderTable()
        'Validate Fields and Load Totals First
        Dim IsWhitePaperChecked As String = ""
        Dim IsDiscountChecked As String = ""

        If chkWhitePaper.Checked = True And cboCheckType.Text = "STANDARD" Then
            IsWhitePaperChecked = "YES"
        Else
            IsWhitePaperChecked = "NO"
        End If
        If chkManualDiscount.Checked = True Then
            IsDiscountChecked = "YES"
        Else
            IsDiscountChecked = "NO"
        End If
        If Checked1099 = "" Then
            Checked1099 = "NO"
        End If
        If chkOnHold.Checked = True Then
            OnHoldStatus = "YES"
        Else
            OnHoldStatus = "NO"
        End If
        '************************************************************************************************************************************************

        ReLoadVoucherTotals()

        'Update Receipt of Invoice Batch Line Table
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = @BatchNumber, PONumber = @PONumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, VendorID = @VendorID, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, ReceiptDate = @ReceiptDate, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, DeleteReferenceNumber = @DeleteReferenceNumber, InvoiceAmount = @InvoiceAmount, VendorClass = @VendorClass, OnHold = @OnHold, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper, ManualDiscountSelected = @ManualDiscountSelected, Checked1099 = @Checked1099  WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDateDD.Text
            .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDateDD.Text
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = Val(txtFreightTotal.Text)
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = Val(txtSalesTaxTotal.Text)
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtInvoiceAmount.Text)
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
            .Add("@DiscountDate", SqlDbType.VarChar).Value = DiscountDate
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDateDD.Text
            .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@VoucherSource", SqlDbType.VarChar).Value = "VOUCHER RECEIPT"
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = 0
            .Add("@OnHold", SqlDbType.VarChar).Value = OnHoldStatus
            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
            .Add("@TempSelected", SqlDbType.VarChar).Value = ""
            .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
            .Add("@WhitePaper", SqlDbType.VarChar).Value = IsWhitePaperChecked
            .Add("@ManualDiscountSelected", SqlDbType.VarChar).Value = IsDiscountChecked
            .Add("@Checked1099", SqlDbType.VarChar).Value = Checked1099
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Datagrid functions

    Private Sub dgvVoucherLines_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvVoucherLines.CellValueChanged
        Dim LineOrderQuantity, LineExtendedAmount, LineUnitCost As Double
        Dim LineNumber As Integer
        Dim LineDescription As String

        If Me.dgvVoucherLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvVoucherLines.CurrentCell.RowIndex

            LineUnitCost = Me.dgvVoucherLines.Rows(RowIndex).Cells("UnitCostColumn").Value
            LineOrderQuantity = Me.dgvVoucherLines.Rows(RowIndex).Cells("QuantityColumn").Value
            LineDescription = Me.dgvVoucherLines.Rows(RowIndex).Cells("PartDescriptionColumn").Value
            LineNumber = Me.dgvVoucherLines.Rows(RowIndex).Cells("VoucherLineColumn").Value

            If LineUnitCost < 0 Then
                MsgBox("Unit Cost must be a positive number. For a negative value, set quantity to a negative.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            LineExtendedAmount = LineUnitCost * LineOrderQuantity
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
            LineUnitCost = Math.Round(LineUnitCost, 4)

            'UPDATE Purchase Order Extended Amount based on line changes
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET UnitCost = @UnitCost, Quantity = @Quantity, ExtendedAmount = @ExtendedAmount, PartDescription = @PartDescription WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@VoucherLine", SqlDbType.VarChar).Value = LineNumber
                .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                .Add("@Quantity", SqlDbType.VarChar).Value = LineOrderQuantity
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                .Add("@PartDescription", SqlDbType.VarChar).Value = LineDescription
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            'No lines - do nothing
        End If

        'Load Totals and Update Header Table
        ReLoadVoucherTotals()

        'UPDATE Purchase Order Extended Amount based on line changes
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        ShowVoucherLines()
    End Sub

    'Command buttons

    Private Sub cmdGenerateVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateVoucher.Click
        'Validate fields before creating new voucher
        If cboVoucherNumber.Text = "" Or txtBatchNumber.Text = "" Or txtDivisionID.Text = "" Then
            'Do not save, clear form and get next voucher number
            RunningProductTotal = 0
            ClearVariables()
            ClearAll()
            ClearDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNonInventoryItems()
            cboVoucherNumber.Focus()

            InsertIntoHeaderTable()

            Exit Sub
        End If
        '*****************************************************************************************************************
        If cboVoucherNumber.Text <> "" Or txtBatchNumber.Text <> "" Or txtDivisionID.Text <> "" Then
            'Check to see if Voucher is already posted
            Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
            Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
            CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckVoucherStatus = "POSTED"
            End Try
            con.Close()

            If CheckVoucherStatus = "POSTED" Then
                'Do not save, clear form and get next voucher number
                RunningProductTotal = 0
                ClearVariables()
                ClearAll()
                ClearDatagrid()
                LoadVendor()
                LoadVoucher()
                LoadNonInventoryItems()
                cboVoucherNumber.Focus()

                InsertIntoHeaderTable()

                Exit Sub
            End If
            '**************************************************************************************************************
            'Save data and continue
            'Check line quantities in datagrid, and delete any zero quantity lines
            cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND Quantity = @Quantity AND UnitCost = @UnitCost", con)
            cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            cmd.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = 0
            cmd.Parameters.Add("@UnitCost", SqlDbType.VarChar).Value = 0

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Reload datagrid
            ShowVoucherLines()

            'Renumber lines
            Dim TempLineNumber As Integer = 1000

            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Try
                    LineNumber = row.Cells("VoucherLineColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try

                'UPDATE Voucher Lines
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber
                    .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                TempLineNumber = TempLineNumber + 1
            Next

            'Reload datagrid
            ShowVoucherLines()

            'Renumber lines
            Dim TempLineNumber2 As Integer = 1

            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Try
                    LineNumber = row.Cells("VoucherLineColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try

                'UPDATE Voucher Lines
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber2
                    .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                TempLineNumber2 = TempLineNumber2 + 1
            Next

            'Reload datagrid
            ShowVoucherLines()

            'Make sure that Discount Date is not changed for N30
            VerifyDiscount()

            If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                DiscountDate = dtpDueDateDD.Text
                dtpDiscountDateDD.Text = DiscountDate
            Else
                DiscountDate = dtpDiscountDateDD.Text
            End If

            'If Voucher is a credit, automatically set due date, discount date to Invoice Date
            If InvoiceTotal < 0 Then
                DiscountDate = dtpInvoiceDateDD.Text
                dtpDiscountDateDD.Text = dtpInvoiceDateDD.Text
                dtpDueDateDD.Text = dtpInvoiceDateDD.Text
            End If

            Try
                UpdateHeaderTable()
            Catch ex As Exception
                'Error Log

            End Try

            'Update Totals from the line items
            Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
            Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
            SUMExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

            Dim DiscountPercentStatement As String = "SELECT DiscountPercent FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
            Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
            DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMExtendedAmount = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
            Catch ex1 As Exception
                SUMExtendedAmount = 0
            End Try
            Try
                DiscountPercent = CDbl(DiscountPercentCommand.ExecuteScalar)
            Catch ex1 As Exception
                DiscountPercent = 0
            End Try
            con.Close()

            'Verify manual Discount
            If chkManualDiscount.Checked = True Then
                DiscountAmount = Val(txtDiscountAmount.Text)
            Else
                DiscountAmount = DiscountPercent * ProductTotal
            End If

            ProductTotal = SUMExtendedAmount
            InvoiceTotal = ProductTotal + InvoiceSalesTax + InvoiceFreight

            ProductTotal = Math.Round(ProductTotal, 2)
            DiscountAmount = Math.Round(DiscountAmount, 2)
            InvoiceTotal = Math.Round(InvoiceTotal, 2)

            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber", con)
            cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            cmd.Parameters.Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            txtFreightTotal.Text = InvoiceFreight
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
            txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
            txtSalesTaxTotal.Text = InvoiceSalesTax
            txtDiscountAmount.Text = DiscountAmount

            'verify that Invoice Amount equals Invoice Total
            InvoiceAmount = Val(txtInvoiceAmount.Text)

            If InvoiceAmount <> InvoiceTotal Then
                MsgBox("The Invoice Total does not match. Check your totals.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Proceed
            End If

            'Clear text fields for next entry
            RunningProductTotal = 0
            ClearVariables()
            ClearAll()
            ClearDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNonInventoryItems()
            cboVoucherNumber.Focus()

            InsertIntoHeaderTable()
        Else
            'Do not save, clear form and get next voucher number
            RunningProductTotal = 0
            ClearVariables()
            ClearAll()
            ClearDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNonInventoryItems()
            cboVoucherNumber.Focus()

            InsertIntoHeaderTable()

            Exit Sub
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboItemID.SelectedIndex = -1
        txtLongDescription.Clear()
        txtQuantity.Clear()
        txtUnitCost.Clear()
        txtExtendedAmount.Clear()
        cboItemID.Focus()
    End Sub

    Private Sub cmdReturnToMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReturnToMain.Click
        gpxVoucherHeader.Visible = True
        gpxVendorAddress.Visible = False
    End Sub

    Private Sub cmdUpdateVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateVendor.Click
        Try
            cmd = New SqlCommand("UPDATE Vendor SET VendorName = @VendorName, VendorAddress1 = @VendorAddress1, VendorAddress2 = @VendorAddress2, VendorCity = @VendorCity, VendorState = @VendorState, VendorZip = @VendorZip, VendorCountry = @VendorCountry WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                .Add("@VendorName", SqlDbType.VarChar).Value = txtRemitToVendorName.Text
                .Add("@VendorAddress1", SqlDbType.VarChar).Value = txtRemitToAddress1.Text
                .Add("@VendorAddress2", SqlDbType.VarChar).Value = txtRemitToAddress2.Text
                .Add("@VendorCity", SqlDbType.VarChar).Value = txtRemitToCity.Text
                .Add("@VendorState", SqlDbType.VarChar).Value = txtRemitToState.Text
                .Add("@VendorZip", SqlDbType.VarChar).Value = txtRemitToZip.Text
                .Add("@VendorCountry", SqlDbType.VarChar).Value = txtRemitToCountry.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            txtVendorName.Text = txtRemitToVendorName.Text
            MsgBox("Vendor Updated!", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Do nothing
        End Try
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearAll()
        ClearDatagrid()
        LoadVendor()
        LoadVoucher()
        LoadNonInventoryItems()
    End Sub

    Private Sub cmdEnterLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterLine.Click
        If cboCreditAccount.Text = "" Or cboDebitAccount.Text = "" Then
            MsgBox("Select GL Accounts for Voucher Line", MsgBoxStyle.OkOnly)
        Else
            If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
                MsgBox("You must have a valid Voucher Number and Invoice Number.", MsgBoxStyle.OkOnly)
                cboVoucherNumber.Focus()
            Else
                'Verify that Invoice Number is Unique
                VerifyUniqueInvoiceNumber()

                If UniqueInvoice = "YES" Then
                    'Check to see if Voucher is already posted
                    Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                    Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
                    CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckVoucherStatus = "POSTED"
                    End Try
                    con.Close()

                    If CheckVoucherStatus <> "OPEN" Then
                        MsgBox("Lines cannot be entered at this time.", MsgBoxStyle.OkOnly)
                    Else
                        If Val(txtUnitCost.Text) < 0 Then
                            MsgBox("Unit Cost must be a positive number. For a negative value, set quantity to a negative.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End If

                        'Make sure that Discount Date is not changed for N30
                        VerifyDiscount()

                        If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                            DiscountDate = dtpDueDateDD.Text
                            dtpDiscountDateDD.Text = DiscountDate
                        Else
                            DiscountDate = dtpDiscountDateDD.Text
                        End If
                        '************************************************************************************************************************************************
                        'Determine check type
                        If cboCheckType.Text = "" Then
                            MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        Else
                            'Continue
                        End If
                        '************************************************************************************************************************************************
                        If chkOnHold.Checked = True Then
                            OnHoldStatus = "YES"
                        Else
                            OnHoldStatus = "NO"
                        End If
                        '************************************************************************************************************************************************
                        'If Voucher is a credit, automatically set due date, discount date to Invoice Date
                        If InvoiceTotal < 0 Then
                            DiscountDate = dtpInvoiceDateDD.Text
                            dtpDiscountDateDD.Text = dtpInvoiceDateDD.Text
                            dtpDueDateDD.Text = dtpInvoiceDateDD.Text
                            cboPaymentTerms.Text = "NetDue"
                            txtDiscountAmount.Text = 0
                        End If
                        '************************************************************************************************************************************************
                        Try
                            'Update ROI Batch LIne Table
                            UpdateHeaderTable()
                        Catch ex As Exception
                            'Error Log

                        End Try

                        'Commands to Generate new line number for entries
                        Dim MAXLineStatement As String = "SELECT MAX(VoucherLine) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                        Dim MAXLineCommand As New SqlCommand(MAXLineStatement, con)
                        MAXLineCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastLineNumber = CInt(MAXLineCommand.ExecuteScalar)
                        Catch ex As Exception
                            LastLineNumber = 0
                        End Try
                        con.Close()

                        NextLineNumber = LastLineNumber + 1

                        'Round entries into line table
                        Dim LineQuantity, LineUnitCost, LineExtendedAmount As Double

                        LineQuantity = Val(txtQuantity.Text)
                        LineUnitCost = Val(txtUnitCost.Text)
                        LineExtendedAmount = Val(txtExtendedAmount.Text)
                        LineUnitCost = Math.Round(LineUnitCost, 4)
                        LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

                        Try
                            'Write Data to Voucher Line Database Table
                            cmd = New SqlCommand("Insert Into ReceiptOfInvoiceVoucherLines(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine, DivisionID)Values(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice, @ReceiverNumber, @ReceiverLine, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@VoucherLine", SqlDbType.VarChar).Value = NextLineNumber
                                .Add("@PartNumber", SqlDbType.VarChar).Value = cboItemID.Text
                                .Add("@PartDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
                                .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                                .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                                .Add("@GLDebitAccount", SqlDbType.VarChar).Value = cboDebitAccount.Text
                                .Add("@GLCreditAccount", SqlDbType.VarChar).Value = cboCreditAccount.Text
                                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "RECEIVED"
                                .Add("@ReceiverNumber", SqlDbType.VarChar).Value = 0
                                .Add("@ReceiverLine", SqlDbType.VarChar).Value = 0
                                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                            'Show line in datagrid
                            ShowVoucherLines()
                        Catch ex As Exception
                            'Write Data to Batch Line (Voucher) Database Table
                            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET PartNumber = @PartNumber, PartDescription = @PartDescription, Quantity = @Quantity, UnitCost = @UnitCost, ExtendedAmount = @ExtendedAmount, GLDebitAccount = @GLDebitAccount, GLCreditAccount = @GLCreditAccount, SelectForInvoice = @SelectForInvoice, ReceiverNumber = @ReceiverNumber, ReceiverLine = @ReceiverLine, DivisionID = @DivisionID WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)

                            With cmd.Parameters
                                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@VoucherLine", SqlDbType.VarChar).Value = NextLineNumber
                                .Add("@PartNumber", SqlDbType.VarChar).Value = cboItemID.Text
                                .Add("@PartDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
                                .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                                .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                                .Add("@GLDebitAccount", SqlDbType.VarChar).Value = cboDebitAccount.Text
                                .Add("@GLCreditAccount", SqlDbType.VarChar).Value = cboCreditAccount.Text
                                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "RECEIVED"
                                .Add("@ReceiverNumber", SqlDbType.VarChar).Value = 0
                                .Add("@ReceiverLine", SqlDbType.VarChar).Value = 0
                                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Show line in datagrid
                            ShowVoucherLines()
                        End Try

                        'Update Totals from the line items
                        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                        SUMExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                        Dim DiscountPercentStatement As String = "SELECT DiscountPercent FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
                        Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
                        DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SUMExtendedAmount = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                        Catch ex1 As Exception
                            SUMExtendedAmount = 0
                        End Try
                        Try
                            DiscountPercent = CDbl(DiscountPercentCommand.ExecuteScalar)
                        Catch ex1 As Exception
                            DiscountPercent = 0
                        End Try
                        con.Close()

                        'Verify manual Discount
                        If chkManualDiscount.Checked = True Then
                            DiscountAmount = Val(txtDiscountAmount.Text)
                        Else
                            DiscountAmount = DiscountPercent * ProductTotal
                        End If

                        InvoiceSalesTax = Val(txtSalesTaxTotal.Text)
                        InvoiceFreight = Val(txtFreightTotal.Text)
                        ProductTotal = SUMExtendedAmount
                        InvoiceTotal = ProductTotal + InvoiceSalesTax + InvoiceFreight

                        ProductTotal = Math.Round(ProductTotal, 2)
                        DiscountAmount = Math.Round(DiscountAmount, 2)
                        InvoiceTotal = Math.Round(InvoiceTotal, 2)

                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber", con)
                        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                        cmd.Parameters.Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
                        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                        txtDiscountAmount.Text = DiscountAmount

                        'Clear fields for next line entry
                        cboItemID.SelectedIndex = -1
                        txtLongDescription.Clear()
                        txtQuantity.Clear()
                        txtUnitCost.Clear()
                        txtExtendedAmount.Clear()
                        cboDebitAccount.SelectedIndex = -1
                        cboItemID.Focus()
                    End If
                Else
                    MsgBox("This Invoice Number has already been used.", MsgBoxStyle.OkOnly)
                    txtInvoiceNumber.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Or cboVendorID.Text = "" Then
            MsgBox("You must have a valid Voucher #,Invoice #, and Vendor.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
            Exit Sub
        End If
        '**************************************************************************************
        'Verify Invoice Number
        VerifyUniqueInvoiceNumber()

        If UniqueInvoice = "YES" Then
            'Check to see if Voucher is already posted
            Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
            Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
            CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckVoucherStatus = "POSTED"
            End Try
            con.Close()

            If CheckVoucherStatus <> "OPEN" Then
                'Open Print Form
                Exit Sub
            Else
                '*******************************************************************************************************************************
                'Check line quantities in datagrid, and delete any zero quantity lines
                cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND Quantity = @Quantity AND UnitCost = @UnitCost", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                cmd.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = 0
                cmd.Parameters.Add("@UnitCost", SqlDbType.VarChar).Value = 0

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Reload datagrid
                ShowVoucherLines()

                'Renumber lines
                Dim TempLineNumber As Integer = 1000

                For Each row As DataGridViewRow In dgvVoucherLines.Rows
                    Try
                        LineNumber = row.Cells("VoucherLineColumn").Value
                    Catch ex As Exception
                        LineNumber = 0
                    End Try

                    'UPDATE Voucher Lines
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber
                        .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    TempLineNumber = TempLineNumber + 1
                Next

                'Reload datagrid
                ShowVoucherLines()

                'Renumber lines
                Dim TempLineNumber2 As Integer = 1

                For Each row As DataGridViewRow In dgvVoucherLines.Rows
                    Try
                        LineNumber = row.Cells("VoucherLineColumn").Value
                    Catch ex As Exception
                        LineNumber = 0
                    End Try

                    'UPDATE Voucher Lines
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber2
                        .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    TempLineNumber2 = TempLineNumber2 + 1
                Next

                'Reload datagrid
                ShowVoucherLines()
                '******************************************************************************************************
                'Make sure that Discount Date is not changed for N30
                VerifyDiscount()

                If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                    DiscountDate = dtpDueDateDD.Text
                    dtpDiscountDateDD.Text = DiscountDate
                Else
                    DiscountDate = dtpDiscountDateDD.Text
                End If

                'If Voucher is a credit, automatically set due date, discount date to Invoice Date
                If InvoiceTotal < 0 Then
                    DiscountDate = dtpInvoiceDateDD.Text
                    dtpDiscountDateDD.Text = dtpInvoiceDateDD.Text
                    dtpDueDateDD.Text = dtpInvoiceDateDD.Text
                    cboPaymentTerms.Text = "NetDue"
                    txtDiscountAmount.Text = 0
                End If
                '************************************************************************************************************************************************
                'Determine check type
                If cboCheckType.Text = "" Then
                    MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '************************************************************************************************************************************************
                Try
                    'Write Data to Batch Line (Voucher Header) Database Table
                    UpdateHeaderTable()
                Catch ex As Exception
                    'Error Log

                End Try

                'Update Totals from the line items
                Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                SUMExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                Dim DiscountPercentStatement As String = "SELECT DiscountPercent FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
                Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
                DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SUMExtendedAmount = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                Catch ex1 As Exception
                    SUMExtendedAmount = 0
                End Try
                Try
                    DiscountPercent = CDbl(DiscountPercentCommand.ExecuteScalar)
                Catch ex1 As Exception
                    DiscountPercent = 0
                End Try
                con.Close()

                'Verify manual Discount
                If chkManualDiscount.Checked = True Then
                    DiscountAmount = Val(txtDiscountAmount.Text)
                Else
                    DiscountAmount = DiscountPercent * ProductTotal
                End If

                InvoiceSalesTax = Val(txtSalesTaxTotal.Text)
                InvoiceFreight = Val(txtFreightTotal.Text)
                ProductTotal = SUMExtendedAmount
                InvoiceTotal = ProductTotal + InvoiceSalesTax + InvoiceFreight

                ProductTotal = Math.Round(ProductTotal, 2)
                DiscountAmount = Math.Round(DiscountAmount, 2)
                InvoiceTotal = Math.Round(InvoiceTotal, 2)

                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                cmd.Parameters.Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
                txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                txtDiscountAmount.Text = DiscountAmount

                MsgBox("Voucher has been updated.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdEnterVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterVoucher.Click
        'Validate fields before creating new voucher
        If cboVoucherNumber.Text = "" Or txtBatchNumber.Text = "" Or txtDivisionID.Text = "" Then
            'Do not save, clear form and get next voucher number
            RunningProductTotal = 0
            ClearVariables()
            ClearAll()
            ClearDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNonInventoryItems()
            cboVoucherNumber.Focus()

            InsertIntoHeaderTable()

            Exit Sub
        End If
        '*****************************************************************************************************************
        If cboVoucherNumber.Text <> "" Or txtBatchNumber.Text <> "" Or txtDivisionID.Text <> "" Then
            'Check to see if Voucher is already posted
            Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
            Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
            CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckVoucherStatus = "POSTED"
            End Try
            con.Close()

            If CheckVoucherStatus = "POSTED" Then
                'Do not save, clear form and get next voucher number
                RunningProductTotal = 0
                ClearVariables()
                ClearAll()
                ClearDatagrid()
                LoadVendor()
                LoadVoucher()
                LoadNonInventoryItems()
                cboVoucherNumber.Focus()

                InsertIntoHeaderTable()

                Exit Sub
            End If
            '**************************************************************************************************************
            'Save data and continue
            'Check line quantities in datagrid, and delete any zero quantity lines
            cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND Quantity = @Quantity AND UnitCost = @UnitCost", con)
            cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            cmd.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = 0
            cmd.Parameters.Add("@UnitCost", SqlDbType.VarChar).Value = 0

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Reload datagrid
            ShowVoucherLines()

            'Renumber lines
            Dim TempLineNumber As Integer = 1000

            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Try
                    LineNumber = row.Cells("VoucherLineColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try

                'UPDATE Voucher Lines
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber
                    .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                TempLineNumber = TempLineNumber + 1
            Next

            'Reload datagrid
            ShowVoucherLines()

            'Renumber lines
            Dim TempLineNumber2 As Integer = 1

            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Try
                    LineNumber = row.Cells("VoucherLineColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try

                'UPDATE Voucher Lines
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber2
                    .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                TempLineNumber2 = TempLineNumber2 + 1
            Next

            'Reload datagrid
            ShowVoucherLines()

            'Make sure that Discount Date is not changed for N30
            VerifyDiscount()

            If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                DiscountDate = dtpDueDateDD.Text
                dtpDiscountDateDD.Text = DiscountDate
            Else
                DiscountDate = dtpDiscountDateDD.Text
            End If

            'If Voucher is a credit, automatically set due date, discount date to Invoice Date
            If InvoiceTotal < 0 Then
                DiscountDate = dtpInvoiceDateDD.Text
                dtpDiscountDateDD.Text = dtpInvoiceDateDD.Text
                dtpDueDateDD.Text = dtpInvoiceDateDD.Text
            End If

            Try
                UpdateHeaderTable()
            Catch ex As Exception
                'Error Log

            End Try

            'Update Totals from the line items
            Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
            Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
            SUMExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

            Dim DiscountPercentStatement As String = "SELECT DiscountPercent FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
            Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
            DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMExtendedAmount = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
            Catch ex1 As Exception
                SUMExtendedAmount = 0
            End Try
            Try
                DiscountPercent = CDbl(DiscountPercentCommand.ExecuteScalar)
            Catch ex1 As Exception
                DiscountPercent = 0
            End Try
            con.Close()

            'Verify manual Discount
            If chkManualDiscount.Checked = True Then
                DiscountAmount = Val(txtDiscountAmount.Text)
            Else
                DiscountAmount = DiscountPercent * ProductTotal
            End If

            InvoiceSalesTax = Val(txtSalesTaxTotal.Text)
            InvoiceFreight = Val(txtFreightTotal.Text)
            ProductTotal = SUMExtendedAmount
            InvoiceTotal = ProductTotal + InvoiceSalesTax + InvoiceFreight

            ProductTotal = Math.Round(ProductTotal, 2)
            DiscountAmount = Math.Round(DiscountAmount, 2)
            InvoiceTotal = Math.Round(InvoiceTotal, 2)

            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber", con)
            cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            cmd.Parameters.Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
            txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
            txtDiscountAmount.Text = DiscountAmount

            'verify that Invoice Amount equals Invoice Total
            InvoiceAmount = Val(txtInvoiceAmount.Text)

            If InvoiceAmount <> InvoiceTotal Then
                MsgBox("The Invoice Total does not match. Check your totals.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Proceed
            End If

            'Clear text fields for next entry
            RunningProductTotal = 0
            ClearVariables()
            ClearAll()
            ClearDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNonInventoryItems()
            cboVoucherNumber.Focus()

            InsertIntoHeaderTable()
        Else
            'Do not save, clear form and get next voucher number
            RunningProductTotal = 0
            ClearVariables()
            ClearAll()
            ClearDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNonInventoryItems()
            cboVoucherNumber.Focus()

            InsertIntoHeaderTable()

            Exit Sub
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Or cboVendorID.Text = "" Then
            MsgBox("You must have a valid Voucher #,Invoice #, and Vendor.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
            Exit Sub
        End If
        '*********************************************************************************************
        'Verify Invoice Number
        VerifyUniqueInvoiceNumber()

        If UniqueInvoice = "YES" Then
            'Check to see if Voucher is already posted
            Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
            Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
            CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckVoucherStatus = "POSTED"
            End Try
            con.Close()

            If CheckVoucherStatus <> "OPEN" Then
                'Open Print Form
                GlobalVoucherNumber = Val(cboVoucherNumber.Text)
                Dim NewPrintVoucher As New PrintVoucher
                NewPrintVoucher.Show()
            Else
                '*******************************************************************************************************************************
                'Check line quantities in datagrid, and delete any zero quantity lines
                cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND Quantity = @Quantity AND UnitCost = @UnitCost", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                cmd.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = 0
                cmd.Parameters.Add("@UnitCost", SqlDbType.VarChar).Value = 0

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Reload datagrid
                ShowVoucherLines()

                'Renumber lines
                Dim TempLineNumber As Integer = 1000

                For Each row As DataGridViewRow In dgvVoucherLines.Rows
                    Try
                        LineNumber = row.Cells("VoucherLineColumn").Value
                    Catch ex As Exception
                        LineNumber = 0
                    End Try

                    'UPDATE Voucher Lines
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber
                        .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    TempLineNumber = TempLineNumber + 1
                Next

                'Reload datagrid
                ShowVoucherLines()

                'Renumber lines
                Dim TempLineNumber2 As Integer = 1

                For Each row As DataGridViewRow In dgvVoucherLines.Rows
                    Try
                        LineNumber = row.Cells("VoucherLineColumn").Value
                    Catch ex As Exception
                        LineNumber = 0
                    End Try

                    'UPDATE Voucher Lines
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber2
                        .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    TempLineNumber2 = TempLineNumber2 + 1
                Next

                'Reload datagrid
                ShowVoucherLines()
                '******************************************************************************************************
                'Make sure that Discount Date is not changed for N30
                VerifyDiscount()

                If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                    DiscountDate = dtpDueDateDD.Text
                    dtpDiscountDateDD.Text = DiscountDate
                Else
                    DiscountDate = dtpDiscountDateDD.Text
                End If

                'If Voucher is a credit, automatically set due date, discount date to Invoice Date
                If InvoiceTotal < 0 Then
                    DiscountDate = dtpInvoiceDateDD.Text
                    dtpDiscountDateDD.Text = dtpInvoiceDateDD.Text
                    dtpDueDateDD.Text = dtpInvoiceDateDD.Text
                    cboPaymentTerms.Text = "NetDue"
                    txtDiscountAmount.Text = 0
                End If
                '************************************************************************************************************************************************
                'Determine check type
                If cboCheckType.Text = "" Then
                    MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '************************************************************************************************************************************************
                Try
                    'Write Data to Batch Line (Voucher Header) Database Table
                    UpdateHeaderTable()
                Catch ex As Exception
                    'Error Log

                End Try

                'Update Totals from the line items
                Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                SUMExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                Dim DiscountPercentStatement As String = "SELECT DiscountPercent FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
                Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
                DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SUMExtendedAmount = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                Catch ex1 As Exception
                    SUMExtendedAmount = 0
                End Try
                Try
                    DiscountPercent = CDbl(DiscountPercentCommand.ExecuteScalar)
                Catch ex1 As Exception
                    DiscountPercent = 0
                End Try
                con.Close()

                'Verify manual Discount
                If chkManualDiscount.Checked = True Then
                    DiscountAmount = Val(txtDiscountAmount.Text)
                Else
                    DiscountAmount = DiscountPercent * ProductTotal
                End If

                InvoiceSalesTax = Val(txtSalesTaxTotal.Text)
                InvoiceFreight = Val(txtFreightTotal.Text)
                ProductTotal = SUMExtendedAmount
                InvoiceTotal = ProductTotal + InvoiceSalesTax + InvoiceFreight

                ProductTotal = Math.Round(ProductTotal, 2)
                DiscountAmount = Math.Round(DiscountAmount, 2)
                InvoiceTotal = Math.Round(InvoiceTotal, 2)

                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                cmd.Parameters.Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
                txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                txtDiscountAmount.Text = DiscountAmount

                MsgBox("Voucher has been updated.", MsgBoxStyle.OkOnly)

                'Open Print Form
                GlobalVoucherNumber = Val(cboVoucherNumber.Text)
                Dim NewPrintVoucher As New PrintVoucher
                NewPrintVoucher.Show()
            End If
        Else
            MsgBox("This Invoice Number has already been used or is blank.", MsgBoxStyle.OkOnly)
            txtInvoiceNumber.Focus()
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboVoucherNumber.Text = "" Then
            MsgBox("You must select a valid Voucher Number to delete", MsgBoxStyle.OkOnly)
        Else
            'Prompt before deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Voucher?", "DELETE VOUCHER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Check to see if Voucher is already posted
                Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
                CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckVoucherStatus = "POSTED"
                End Try
                con.Close()

                If CheckVoucherStatus <> "OPEN" Then
                    MsgBox("Voucher cannot be deleted.", MsgBoxStyle.OkOnly)
                Else
                    If checkRecurring() Then
                        ClearVariables()
                        ClearAll()
                        ClearDatagrid()
                        LoadVendor()
                        LoadVoucher()
                        LoadNonInventoryItems()
                        Exit Sub
                    End If
                    'Create command to delete data
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Clear text boxes on delete
                    ClearVariables()
                    ClearAll()
                    ClearDatagrid()
                    LoadVendor()
                    LoadVoucher()
                    LoadNonInventoryItems()
                End If
            ElseIf button = DialogResult.No Then
                cmdClear.Focus()
            End If
        End If
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If cboVoucherNumber.Text = "" Or cboVoucherLine.Text = "" Then
            MsgBox("You must have a valid Voucher Number and Line # selected.", MsgBoxStyle.OkOnly)
        Else
            'Check to see if Voucher is already posted
            Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
            Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
            CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckVoucherStatus = "POSTED"
            End Try
            con.Close()

            If CheckVoucherStatus <> "OPEN" Then
                MsgBox("Line cannot be deleted at this time.", MsgBoxStyle.OkOnly)
            Else
                Try
                    'Delete line
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)
                    cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    cmd.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboVoucherLine.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Refresh datagrid
                    ShowVoucherLines()

                    'Renumber Lines in datagrid
                    Dim TempLineNumber As Integer = 1000

                    For Each row As DataGridViewRow In dgvVoucherLines.Rows
                        Try
                            LineNumber = row.Cells("VoucherLineColumn").Value
                        Catch ex As Exception
                            LineNumber = 0
                        End Try

                        'UPDATE Voucher Lines
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber
                            .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        TempLineNumber = TempLineNumber + 1
                    Next

                    'Reload datagrid
                    ShowVoucherLines()

                    'Renumber lines
                    Dim TempLineNumber2 As Integer = 1

                    For Each row As DataGridViewRow In dgvVoucherLines.Rows
                        Try
                            LineNumber = row.Cells("VoucherLineColumn").Value
                        Catch ex As Exception
                            LineNumber = 0
                        End Try

                        'UPDATE Voucher Lines
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber2
                            .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        TempLineNumber2 = TempLineNumber2 + 1
                    Next

                    'Reload datagrid
                    ShowVoucherLines()

                    'Save Totals
                    'Update Totals from the line items
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                    Dim DiscountPercentStatement As String = "SELECT DiscountPercent FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
                    Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
                    DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SUMExtendedAmount = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex1 As Exception
                        SUMExtendedAmount = 0
                    End Try
                    Try
                        DiscountPercent = CDbl(DiscountPercentCommand.ExecuteScalar)
                    Catch ex1 As Exception
                        DiscountPercent = 0
                    End Try
                    con.Close()

                    'Verify manual Discount
                    If chkManualDiscount.Checked = True Then
                        DiscountAmount = Val(txtDiscountAmount.Text)
                    Else
                        DiscountAmount = DiscountPercent * ProductTotal
                    End If

                    InvoiceFreight = Val(txtFreightTotal.Text)
                    InvoiceSalesTax = Val(txtSalesTaxTotal.Text)
                    ProductTotal = SUMExtendedAmount
                    InvoiceTotal = ProductTotal + InvoiceSalesTax + InvoiceFreight

                    ProductTotal = Math.Round(ProductTotal, 2)
                    DiscountAmount = Math.Round(DiscountAmount, 2)
                    InvoiceTotal = Math.Round(InvoiceTotal, 2)

                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber", con)
                    cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    cmd.Parameters.Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                    txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
                    tabLineControls.SelectedIndex = 0

                    MsgBox("Voucher Line deleted.", MsgBoxStyle.OkOnly)
                Catch ex As Exception
                    MsgBox("Delete line failed. Check data and try again.", MsgBoxStyle.OkOnly)
                End Try
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If VoucherStatus = "POSTED" Then
            ClearAll()
            ClearVariables()

            GlobalAPDivisionID = txtDivisionID.Text
            GlobalAPBatchNumber = Val(txtBatchNumber.Text)

            Dim NewAPProcessBatch As New APProcessBatch
            NewAPProcessBatch.Show()

            Me.Dispose()
            Me.Close()
            Exit Sub
        End If
        '**************************************************************************************
        If Val(cboVoucherNumber.Text) = 0 Or cboVoucherNumber.Text = "" Then
            ClearAll()
            ClearVariables()

            GlobalAPDivisionID = txtDivisionID.Text
            GlobalAPBatchNumber = Val(txtBatchNumber.Text)

            Dim NewAPProcessBatch As New APProcessBatch
            NewAPProcessBatch.Show()

            Me.Dispose()
            Me.Close()
            Exit Sub
        End If
        '**************************************************************************************
        'Prompt before exiting
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this Voucher? (Voucher will be deleted if NO)", "SAVE VOUCHER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            '**************************************************************************************
            'Verify that the Invoice Number is Unique
            VerifyUniqueInvoiceNumber()

            If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" And cboVendorID.Text <> "" Then
                'Do nothing and continue
            Else
                MsgBox("This Invoice Number has already been used or is blank.", MsgBoxStyle.OkOnly)
                txtInvoiceNumber.Focus()
                Exit Sub
            End If
            '**************************************************************************************
            'Validate dates
            ValidateDates()

            If CheckAndValidateDates = "NOT OKAY" Then
                Dim button2 As DialogResult = MessageBox.Show("One of your dates is more than 90 days out. Do you wish to continue?", "DATE 90 DAYS OR OVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If button2 = DialogResult.Yes Then
                    'Do nothing and continue
                ElseIf button2 = DialogResult.No Then
                    Exit Sub
                End If
            Else
                'Do nothing
            End If
            '**************************************************************************************
            'Check to see if Voucher is already posted
            Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
            Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
            CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckVoucherStatus = "POSTED"
            End Try
            con.Close()

            If CheckVoucherStatus <> "OPEN" Then
                MsgBox("Voucher cannot be saved at this time.", MsgBoxStyle.OkOnly)

                'Write updated totals to Batch Header Table
                UpdateBatchTotal()
                ClearAll()
                ClearVariables()

                GlobalAPDivisionID = txtDivisionID.Text
                GlobalAPBatchNumber = Val(txtBatchNumber.Text)

                Dim NewAPProcessBatch2 As New APProcessBatch
                NewAPProcessBatch2.Show()

                Me.Dispose()
                Me.Close()
            Else
                'Do nothing and continue
            End If
            '**************************************************************************************
            'Make sure that Discount Date is not changed for N30
            VerifyDiscount()

            If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                DiscountDate = dtpDueDateDD.Text
                dtpDiscountDateDD.Text = DiscountDate
            Else
                DiscountDate = dtpDiscountDateDD.Text
            End If
            '************************************************************************************************************************************************
            'Determine check type
            If cboCheckType.Text = "" Then
                MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '**************************************************************************************
            'If Voucher is a credit, automatically set due date, discount date to Invoice Date
            If InvoiceTotal < 0 Then
                DiscountDate = dtpInvoiceDateDD.Text
                dtpDiscountDateDD.Text = dtpInvoiceDateDD.Text
                dtpDueDateDD.Text = dtpInvoiceDateDD.Text
                cboPaymentTerms.Text = "NetDue"
                txtDiscountAmount.Text = 0
            End If
            '**************************************************************************************
            'UPDATE Data to Batch Line (Voucher Header) Database Table
            UpdateHeaderTable()
            '*********************************************************************************************
            'Renumber lines

            'Starting Temp Row Number
            TempVoucherLine = 10000

            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Dim TempVoucherLineNumber As Integer = row.Cells("VoucherLineColumn").Value

                'Reorder row numbers - assign temp row number
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine1", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@VoucherLine1", SqlDbType.VarChar).Value = TempVoucherLineNumber
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = TempVoucherLine
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                TempVoucherLine = TempVoucherLine + 1
            Next

            ShowVoucherLines()

            'Assign re-ordered Line Numbers
            Dim FinalVoucherLine As Integer = 1

            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Dim FinalVoucherLineNumber As Integer = row.Cells("VoucherLineColumn").Value

                'Reorder row numbers - assign row number
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine1", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@VoucherLine1", SqlDbType.VarChar).Value = FinalVoucherLineNumber
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = FinalVoucherLine
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                FinalVoucherLine = FinalVoucherLine + 1
            Next
            '*********************************************************************************************
            'Show data with re-ordered lines
            ShowVoucherLines()
            '******************************************************************************************************************************************
            'Update Totals from the line items
            Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
            Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
            SUMExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

            Dim DiscountPercentStatement As String = "SELECT DiscountPercent FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
            Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
            DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMExtendedAmount = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
            Catch ex1 As Exception
                SUMExtendedAmount = 0
            End Try
            Try
                DiscountPercent = CDbl(DiscountPercentCommand.ExecuteScalar)
            Catch ex1 As Exception
                DiscountPercent = 0
            End Try
            con.Close()

            'Verify manual Discount
            If chkManualDiscount.Checked = True Then
                DiscountAmount = Val(txtDiscountAmount.Text)
            Else
                DiscountAmount = DiscountPercent * ProductTotal
            End If

            InvoiceSalesTax = Val(txtSalesTaxTotal.Text)
            InvoiceFreight = Val(txtFreightTotal.Text)
            ProductTotal = SUMExtendedAmount
            InvoiceTotal = ProductTotal + InvoiceSalesTax + InvoiceFreight

            ProductTotal = Math.Round(ProductTotal, 2)
            DiscountAmount = Math.Round(DiscountAmount, 2)
            InvoiceTotal = Math.Round(InvoiceTotal, 2)

            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber", con)
            cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            cmd.Parameters.Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'verify that Invoice Amount equals Invoice Total
            InvoiceAmount = Val(txtInvoiceAmount.Text)

            If InvoiceAmount <> InvoiceTotal Then
                MsgBox("The Invoice Total does not match. Check your totals.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Proceed
            End If

            'Write updated totals to Batch Header Table
            UpdateBatchTotal()
            ClearAll()
            ClearVariables()

            GlobalAPDivisionID = txtDivisionID.Text
            GlobalAPBatchNumber = Val(txtBatchNumber.Text)

            Dim NewAPProcessBatch As New APProcessBatch
            NewAPProcessBatch.Show()

            Me.Dispose()
            Me.Close()
        ElseIf button = DialogResult.No Then
            'Check to see if Voucher is already posted
            Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
            Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
            CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
            Catch ex As Exception
                CheckVoucherStatus = "POSTED"
            End Try
            con.Close()

            If CheckVoucherStatus <> "OPEN" Then
                MsgBox("Voucher cannot be deleted.", MsgBoxStyle.OkOnly)
            Else
                'Create command to delete data
                cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Write updated totals to Batch Header Table
                UpdateBatchTotal()
                ClearAll()
                ClearVariables()
                GlobalVoucherNumber = 0

                GlobalAPDivisionID = txtDivisionID.Text
                GlobalAPBatchNumber = Val(txtBatchNumber.Text)

                Dim NewAPProcessBatch As New APProcessBatch
                NewAPProcessBatch.Show()

                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    'Menu strip functions

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        LoadVendor()
        LoadVoucher()
        LoadNonInventoryItems()
        ClearVariables()
        ClearAll()
        ShowVoucherLines()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    'Combo box functions

    Private Sub cboDebitAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDebitAccount.SelectedIndexChanged
        LoadGLDebitAccountName()
    End Sub

    Private Sub cboCreditAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCreditAccount.SelectedIndexChanged
        LoadGLCreditAccountName()
    End Sub

    Private Sub cboVoucherLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVoucherLine.SelectedIndexChanged
        LoadLineData()
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        cboPaymentTerms.Enabled = True
        LoadVendorDefaults()
        LoadPaymentTermDetails()
        LoadRemitToAddress()
        txtRemitToVendorID.Text = cboVendorID.Text
        txtRemitToVendorName.Text = txtVendorName.Text
    End Sub

    Private Sub cboVoucherNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVoucherNumber.SelectedIndexChanged
        'ClearVariables()
        'ClearAll()

        LoadVoucherInfo()
        LoadVoucherTotals()
        ShowVoucherLines()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemID.SelectedIndexChanged
        LoadItemData()
    End Sub

    Private Sub cboPaymentTerms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentTerms.SelectedIndexChanged
        LoadPaymentTermDetails()

        If cboPaymentTerms.Text = "CREDIT CARD" Then
            cboPaymentTerms.ForeColor = Color.Red
        Else
            cboPaymentTerms.ForeColor = Color.Black
        End If
    End Sub

    Private Sub cboCheckType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCheckType.SelectedIndexChanged
        'If Check Type is not standard, remove White Paper Check designation
        If cboCheckType.Text = "STANDARD" Then
            chkWhitePaper.Enabled = True
        ElseIf cboCheckType.Text = "ACH" Then
            chkWhitePaper.Checked = False
            chkWhitePaper.Enabled = False
        ElseIf cboCheckType.Text = "FEDEX" Then
            chkWhitePaper.Checked = False
            chkWhitePaper.Enabled = False
        ElseIf cboCheckType.Text = "INTERCOMPANY" Then
            chkWhitePaper.Checked = False
            chkWhitePaper.Enabled = False
        End If
    End Sub

    'Text box functions

    Private Sub txtUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitCost.TextChanged
        UnitCost = Val(txtUnitCost.Text)
        ExtendedAmount = Quantity * UnitCost
        ExtendedAmount = Math.Round(ExtendedAmount, 2)
        txtExtendedAmount.Text = ExtendedAmount
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        Quantity = Val(txtQuantity.Text)
        ExtendedAmount = Quantity * UnitCost
        ExtendedAmount = Math.Round(ExtendedAmount, 2)
        txtExtendedAmount.Text = ExtendedAmount
    End Sub

    Private Sub txtSalesTaxTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTaxTotal.TextChanged
        InvoiceSalesTax = Val(txtSalesTaxTotal.Text)
        InvoiceFreight = Val(txtFreightTotal.Text)
        InvoiceTotal = InvoiceFreight + InvoiceSalesTax + ProductTotal
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Private Sub txtFreightTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightTotal.TextChanged
        InvoiceSalesTax = Val(txtSalesTaxTotal.Text)
        InvoiceFreight = Val(txtFreightTotal.Text)
        InvoiceTotal = InvoiceFreight + InvoiceSalesTax + ProductTotal
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    'Miscellaneous control functions (Date time picker, check boxes, etc.)

    Private Sub chkManualDiscount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManualDiscount.CheckedChanged
        If chkManualDiscount.Checked = True Then
            txtDiscountAmount.Enabled = True
        Else
            txtDiscountAmount.Enabled = False
        End If
    End Sub

    Private Sub llRemitToAddress_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llRemitToAddress.LinkClicked
        gpxVendorAddress.Visible = True
        gpxVoucherHeader.Visible = False
    End Sub

    Private Sub dtpInvoiceDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInvoiceDateDD.ValueChanged
        LoadPaymentTermDetails()
        dtpInvoiceDate.Text = dtpInvoiceDateDD.Value.ToShortDateString()

        If CheckCode = "INTERCOMPANY" Then
            LoadIntercompanyDueDate()
            cboPaymentTerms.Enabled = False
            'ElseIf CheckCode = "FEDEX" Then
            '    LoadFEDEXDueDate()
            '    cboPaymentTerms.Enabled = False
        Else
            cboPaymentTerms.Enabled = True
        End If
    End Sub

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

    Private Sub APProcessVouchers_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Private Sub dtpInvoiceDate_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dtpInvoiceDate.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.Tab
                e.IsInputKey = True
        End Select
    End Sub

    Private Sub dtpInvoiceDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpInvoiceDate.KeyDown
        If e.KeyCode = Keys.Tab Then
            usefulFunctions.keyDownCheckCase(dtpInvoiceDate, txtInvoiceAmount)
        End If
    End Sub

    Private Sub dtpInvoiceDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInvoiceDate.Leave
        dtpInvoiceDate.Text = usefulFunctions.formatDate(dtpInvoiceDate.Text)
        dtpInvoiceDateDD.Text = dtpInvoiceDate.Text
    End Sub

    Private Sub dtpReceiptDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpReceiptDate.KeyDown
        If e.KeyCode = Keys.Tab Then
            usefulFunctions.keyDownCheckCase(dtpReceiptDate, cboPaymentTerms)
        End If
    End Sub

    Private Sub dtpReceiptDate_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dtpReceiptDate.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.Tab
                e.IsInputKey = True
        End Select
    End Sub

    Private Sub dtpReceiptDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReceiptDate.Leave
        dtpReceiptDate.Text = usefulFunctions.formatDate(dtpReceiptDate.Text)
        dtpReceiptDateDD.Text = dtpReceiptDate.Text
    End Sub

    Private Sub dtpDiscountDate_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dtpDiscountDate.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.Tab
                e.IsInputKey = True
        End Select
    End Sub

    Private Sub dtpDiscountDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDiscountDate.Leave
        dtpDiscountDate.Text = usefulFunctions.formatDate(dtpDiscountDate.Text)
        dtpDiscountDateDD.Text = dtpDiscountDate.Text
    End Sub

    Private Sub dtpDiscountDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDiscountDate.KeyDown
        If e.KeyCode = Keys.Tab Then
            usefulFunctions.keyDownCheckCase(dtpDiscountDate, dtpDueDate)
        End If
    End Sub

    Private Sub dtpDueDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDueDate.KeyDown
        If e.KeyCode = Keys.Tab Then
            usefulFunctions.keyDownCheckCase(dtpDueDate, txtComment)
        End If
    End Sub

    Private Sub dtpDueDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDueDate.Leave
        dtpDueDate.Text = usefulFunctions.formatDate(dtpDueDate.Text)
        dtpDueDateDD.Text = dtpDueDate.Text
    End Sub

    Private Sub dtpDueDate_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dtpDueDate.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.Tab
                e.IsInputKey = True
        End Select
    End Sub

    Private Sub dtpInvoiceDate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInvoiceDate.Enter
        dtpInvoiceDate.Text = usefulFunctions.formatDate(dtpInvoiceDate.Text)
        dtpInvoiceDate.Select(0, 2)
    End Sub

    Private Sub dtpInvoiceDate_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtpInvoiceDate.MouseClick
        selectDTPLocation(dtpInvoiceDate)
    End Sub

    Private Sub dtpReceiptDate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReceiptDate.Enter
        dtpReceiptDate.Text = usefulFunctions.formatDate(dtpReceiptDate.Text)
        dtpReceiptDate.Select(0, 2)
    End Sub

    Private Sub dtpReceiptDate_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtpReceiptDate.MouseClick
        selectDTPLocation(dtpReceiptDate)
    End Sub

    Private Sub dtpDiscountDate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDiscountDate.Enter
        dtpDiscountDate.Text = usefulFunctions.formatDate(dtpDiscountDate.Text)
        dtpDiscountDate.Select(0, 2)
    End Sub

    Private Sub dtpDiscountDate_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtpDiscountDate.MouseClick
        selectDTPLocation(dtpDiscountDate)
    End Sub

    Private Sub dtpInvoiceDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInvoiceDate.TextChanged
        If dtpInvoiceDate.Focused Then
            autoMoveInDateString(dtpInvoiceDate)
        End If
    End Sub

    Private Sub dtpReceiptDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReceiptDate.TextChanged
        If dtpReceiptDate.Focused Then
            autoMoveInDateString(dtpReceiptDate)
        End If
    End Sub

    Private Sub dtpDiscountDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDiscountDate.TextChanged
        If dtpDiscountDate.Focused Then
            autoMoveInDateString(dtpDiscountDate)
        End If
    End Sub

    Private Sub dtpDueDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDueDate.TextChanged
        If dtpDueDate.Focused Then
            autoMoveInDateString(dtpDueDate)
        End If
    End Sub

    Private Sub dtpDiscountDateDD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDiscountDateDD.ValueChanged
        dtpDiscountDate.Text = usefulFunctions.formatDate(dtpDiscountDateDD.Value.ToShortDateString())
    End Sub

    Private Sub dtpReceiptDateDD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReceiptDateDD.ValueChanged
        dtpReceiptDate.Text = usefulFunctions.formatDate(dtpReceiptDateDD.Value.ToShortDateString())
    End Sub

    Private Sub dtpDueDateDD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDueDateDD.ValueChanged
        dtpDueDate.Text = usefulFunctions.formatDate(dtpDueDateDD.Value.ToShortDateString())
    End Sub

    Private Sub dtpDueDate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDueDate.Enter
        dtpDueDate.Text = usefulFunctions.formatDate(dtpDueDate.Text)
        dtpDueDate.Select(0, 2)
    End Sub

    Private Sub dtpDueDate_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtpDueDate.MouseClick
        selectDTPLocation(dtpDueDate)
    End Sub

    Private Sub txtInvoiceNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInvoiceNumber.LostFocus
        If txtInvoiceNumber.Text.EndsWith(" ") Then
            txtInvoiceNumber.Text = txtInvoiceNumber.Text.TrimEnd(" ")
        End If
    End Sub

    Private Sub txtInvoiceNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoiceNumber.TextChanged
        'If txtInvoiceNumber.Text.EndsWith(" ") Then
        '    txtInvoiceNumber.Text = txtInvoiceNumber.Text.Replace(" ", "")
        'End If
    End Sub
End Class