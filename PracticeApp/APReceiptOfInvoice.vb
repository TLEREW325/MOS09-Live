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
Public Class APReceiptOfInvoice
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""
    Dim FormName As String = "AP Receipt Of Invoice"

    Dim LineNumber, NewCurrentYear, NewCurrentMonth, CurrentDay, CurrentMonth, CurrentYear, DeleteReferenceNumber, DiscountDays, DueDays, PONumber, ReceiverNumber, counter, LastVoucherNumber, NextVoucherNumber, LastBatchNumber, NextBatchNumber As Integer
    Dim Checked1099, DueDateStr, Comment, VoucherStatus, GLCreditAccount, GLDebitAccount, PartDescription, VendorName, BatchDate, BatchDescription, DivisionID, InvoiceNumber, InvoiceDate, VendorID, ReceiptDate, PaymentTerms, PaymentTerms1, DiscountDate As String
    Dim DiscountAmount, DiscountPercent, BatchAmount, ProductTotal, FreightTotal, SalesTaxTotal, InvoiceTotal, VoucherQuantity, Quantity, InvoiceManualTotal As Double
    Dim InvoiceAmount, SUMInvoiceTotal, SUMExtendedAmount, ExtendedAmount, UnitCost, UndistributedAmount, CurrentAmount, BatchCurrentAmount As Double
    Dim NewDueDate, InvoiceDate1, DueDate, DiscountDate1 As Date
    Dim ManualDiscountSelected, WhitePaper, CheckCode, OnHoldStatus, VendorClass, VoucherPartNumber, UniqueInvoice, GLDescription As String
    Dim SelectPOLine, LastLineNumber, NextLineNumber, TempVoucherLine As Integer
    Dim GetExtendedAmount, RoundingAmount, ADDUnitCost, ADDExtendedAmount As Double
    Dim TotalQuantityVouched, TotalReceiverQuantity, ADDQuantity, CheckQuantity As Double
    Dim VendorAddress1, VendorAddress2, VendorCity, VendorState, VendorZip, VendorCountry As String
    Dim CheckReceiverLine, CheckReceiverNumber As Integer
    Dim CheckPartNumber, CheckVoucherStatus As String
    Dim CheckUnitCost As Double = 0
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

    Dim dir As New System.IO.DirectoryInfo("\\TFP-FS\TransferData\UploadedPackingSlips")

    'Load Datasets

    Public Sub ShowVoucherLines()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber", con)
        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceiptOfInvoiceVoucherLines")
        dgvVoucherLines.DataSource = ds.Tables("ReceiptOfInvoiceVoucherLines")
        cboVoucherLineNumber.DataSource = ds.Tables("ReceiptOfInvoiceVoucherLines")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvVoucherLines.DataSource = Nothing
    End Sub

    Public Sub LoadPONumber()
        'Load PO Number table for specific division
        cmd = New SqlCommand("SELECT DISTINCT(PONumber) FROM ReceivingLineQuery WHERE Status = @Status AND TotalQuantityVouched <= QuantityReceived AND SelectForInvoice <> @SelectForInvoice AND DivisionID = @DivisionID AND VendorCode = @VendorCode", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
        cmd.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ReceivingLineQuery")
        cboPONumber.DataSource = ds1.Tables("ReceivingLineQuery")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendor()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "Vendor")
        cboVendorID.DataSource = ds2.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadVoucher()
        'Load Voucher Number for specific division
        cmd = New SqlCommand("SELECT VoucherNumber FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND VoucherSource = @VoucherSource AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = txtBatchNumber.Text
        cmd.Parameters.Add("@VoucherSource", SqlDbType.VarChar).Value = "PO RECEIPT"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ReceiptOfInvoiceBatchLine")
        cboVoucherNumber.DataSource = ds3.Tables("ReceiptOfInvoiceBatchLine")
        con.Close()
        cboVoucherNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadNoninventoryItems()
        'Load Voucher Number for specific division
        cmd = New SqlCommand("SELECT ItemID FROM NonInventoryItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "NonInventoryItemList")
        cboPartNumber.DataSource = ds4.Tables("NonInventoryItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccounts()
        'Load GL Accounts
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber < @Canadian", con)
        cmd.Parameters.Add("@Canadian", SqlDbType.VarChar).Value = "C$0"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "GLAccounts")
        cboDebitAccount.DataSource = ds5.Tables("GLAccounts")
        cboDebitDescription.DataSource = ds5.Tables("GLAccounts")
        con.Close()
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1
    End Sub

    'Insert or Update Routines

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

        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = SUMInvoiceTotal

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub InsertIntoHeaderTable()
        'Get Next Voucher Number
        Dim MAXStatement As String = "SELECT MAX(VoucherNumber) FROM ReceiptOfInvoiceBatchLine"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastVoucherNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastVoucherNumber = 330000000
        End Try
        con.Close()

        NextVoucherNumber = LastVoucherNumber + 1
        cboVoucherNumber.Text = NextVoucherNumber

        'Write To Database
        cmd = New SqlCommand("Insert Into ReceiptOfInvoiceBatchLine(VoucherNumber, BatchNumber, PONumber,InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, InvoiceAmount, VendorClass, DeleteReferenceNumber, OnHold, CheckType, TempSelected, SelectedInDatagrid, WhitePaper, ManualDiscountSelected, Checked1099)Values(@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @VendorID, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @InvoiceAmount, @VendorClass, @DeleteReferenceNumber, @OnHold, @CheckType, @TempSelected, @SelectedInDatagrid, @WhitePaper, @ManualDiscountSelected, @Checked1099)", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
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
            .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtTermDiscount.Text)
            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@VoucherSource", SqlDbType.VarChar).Value = "PO RECEIPT"
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = 0
            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
            .Add("@TempSelected", SqlDbType.VarChar).Value = ""
            .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
            .Add("@WhitePaper", SqlDbType.VarChar).Value = "NO"
            .Add("@ManualDiscountSelected", SqlDbType.VarChar).Value = "NO"
            .Add("@Checked1099", SqlDbType.VarChar).Value = "NO"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub UpdateHeaderTable()
        'Validate Fields and Load Totals First
        Dim IsWhitePaperChecked As String = ""
        Dim IsDiscountSelected As String = ""

        If chkWhitePaper.Checked = True And cboCheckType.Text = "STANDARD" Then
            IsWhitePaperChecked = "YES"
        Else
            IsWhitePaperChecked = "NO"
        End If
        If chkManualDiscount.Checked = True Then
            IsDiscountSelected = "YES"
        Else
            IsDiscountSelected = "NO"
        End If
        If Checked1099 = "" Then
            Checked1099 = "NO"
        End If

        'Reload Totals
        ReLoadVoucherTotals()

        'UPDATE Data in Voucher Header Table (Batch Line)
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET PONumber = @PONumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, VendorClass = @VendorClass, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, DeleteReferenceNumber = @DeleteReferenceNumber, OnHold = @OnHold, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper, ManualDiscountSelected = @ManualDiscountSelected, Checked1099 = @Checked1099 WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
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
            .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtTermDiscount.Text)
            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@VoucherSource", SqlDbType.VarChar).Value = "PO RECEIPT"
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = ReceiverNumber
            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
            .Add("@TempSelected", SqlDbType.VarChar).Value = ""
            .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
            .Add("@WhitePaper", SqlDbType.VarChar).Value = IsWhitePaperChecked
            .Add("@ManualDiscountSelected", SqlDbType.VarChar).Value = IsDiscountSelected
            .Add("@Checked1099", SqlDbType.VarChar).Value = Checked1099
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Load data

    Private Sub APReceiptOfInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Log in Form Login Table
        FormLoginRoutine()

        Call Disable(Me)
        Me.CenterToScreen()

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.VendorClass' table. You can move, or remove it, as needed.
        Me.VendorClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.VendorClass)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ReceiptTransactionDescription' table. You can move, or remove it, as needed.
        Me.PaymentTermsTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PaymentTerms)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ReceiptTransactionDescription' table. You can move, or remove it, as needed.
        Me.ReceiptTransactionDescriptionTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ReceiptTransactionDescription)

        'Load default from Batch Form
        txtDivisionID.Text = GlobalAPDivisionID
        txtBatchNumber.Text = GlobalAPBatchNumber

        LoadVendor()
        LoadVoucher()
        LoadNoninventoryItems()
        LoadGLAccounts()
        ClearOnLoad()

        If GlobalVoucherNumber > 0 Then
            txtBatchNumber.Text = GlobalAPBatchNumber
            cboVoucherNumber.Text = GlobalVoucherNumber
            cboPONumber.Text = GlobalAPPONumber
            LoadVoucherInfo()
            LoadVoucherTotals()
        Else
            cboVoucherNumber.SelectedIndex = -1
        End If

        ShowVoucherLines()
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

    Public Sub LoadVoucherTotals()
        'Calculate the totals from the lines selected (Only used on load)
        Dim PurchaseTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim PurchaseTotalCommand As New SqlCommand(PurchaseTotalStatement, con)
        PurchaseTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        PurchaseTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

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

        Dim InvoiceAmountStatement As String = "SELECT InvoiceAmount FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceAmountCommand As New SqlCommand(InvoiceAmountStatement, con)
        InvoiceAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim DiscountAmountStatement As String = "SELECT DiscountAmount FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim DiscountAmountCommand As New SqlCommand(DiscountAmountStatement, con)
        DiscountAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DiscountAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(PurchaseTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            FreightTotal = CDbl(InvoiceFreightCommand.ExecuteScalar)
        Catch ex As Exception
            FreightTotal = 0
        End Try
        Try
            SalesTaxTotal = CDbl(InvoiceSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            SalesTaxTotal = 0
        End Try
        Try
            InvoiceTotal = CDbl(InvoiceTotalCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceTotal = 0
        End Try
        Try
            InvoiceAmount = CDbl(InvoiceAmountCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceAmount = 0
        End Try
        Try
            DiscountAmount = CDbl(DiscountAmountCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountAmount = 0
        End Try
        con.Close()

        ProductTotal = Math.Round(ProductTotal, 2)
        FreightTotal = Math.Round(FreightTotal, 2)
        SalesTaxTotal = Math.Round(SalesTaxTotal, 2)
        DiscountAmount = Math.Round(DiscountAmount, 2)

        txtFreightTotal.Text = FreightTotal
        txtSalesTaxTotal.Text = SalesTaxTotal
        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtInvoiceAmount.Text = InvoiceAmount
        txtTermDiscount.Text = DiscountAmount
    End Sub

    Public Sub ReLoadVoucherTotals()
        'Calculate the totals from the lines selected
        Dim PurchaseTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim PurchaseTotalCommand As New SqlCommand(PurchaseTotalStatement, con)
        PurchaseTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        PurchaseTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(PurchaseTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        con.Close()

        FreightTotal = Val(txtFreightTotal.Text)
        SalesTaxTotal = Val(txtSalesTaxTotal.Text)

        ProductTotal = Math.Round(ProductTotal, 2)
        FreightTotal = Math.Round(FreightTotal, 2)
        SalesTaxTotal = Math.Round(SalesTaxTotal, 2)
    
        InvoiceTotal = ProductTotal + FreightTotal + SalesTaxTotal
        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)

        If chkManualDiscount.Checked = True Then
            'Discount is the value of the text field
        Else
            DiscountAmount = DiscountPercent * ProductTotal
            DiscountAmount = Math.Round(DiscountAmount, 2)
            txtTermDiscount.Text = DiscountAmount
        End If
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
            'Discount is the value of the text field
        Else
            If DiscountPercent > 0 Then
                ReLoadVoucherTotals()
            End If
        End If
    End Sub

    Public Sub LoadFreightTotals()
        Dim POFreight As Double = 0
        Dim VoucherFreight As Double = 0
        Dim POTax As Double = 0

        Dim POFreightStatement As String = "SELECT FreightCharge FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim POFreightCommand As New SqlCommand(POFreightStatement, con)
        POFreightCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        POFreightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim POTaxStatement As String = "SELECT SalesTax FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim POTaxCommand As New SqlCommand(POTaxStatement, con)
        POTaxCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        POTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VoucherFreightStatement As String = "SELECT SUM(InvoiceFreight) FROM ReceiptOfInvoiceBatchLine WHERE PONumber = @PONumber AND DivisionID = @DivisionID AND VoucherNumber <> @VoucherNumber"
        Dim VoucherFreightCommand As New SqlCommand(VoucherFreightStatement, con)
        VoucherFreightCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        VoucherFreightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        VoucherFreightCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            POFreight = CDbl(POFreightCommand.ExecuteScalar)
        Catch ex As Exception
            POFreight = 0
        End Try
        Try
            POTax = CDbl(POTaxCommand.ExecuteScalar)
        Catch ex As Exception
            POTax = 0
        End Try
        Try
            VoucherFreight = CDbl(VoucherFreightCommand.ExecuteScalar)
        Catch ex As Exception
            VoucherFreight = 0
        End Try
        con.Close()

        If Val(cboPONumber.Text) = 0 Or cboPONumber.Text = "" Then
            txtFreightVouched.Text = 0
            txtFreightOnPO.Text = 0
            txtTaxOnPO.Text = 0
        Else
            txtFreightVouched.Text = FormatCurrency(VoucherFreight, 2)
            txtFreightOnPO.Text = FormatCurrency(POFreight, 2)
            txtTaxOnPO.Text = FormatCurrency(POTax, 2)
        End If
    End Sub

    Public Sub LoadVoucherInfo()
        'Load the Voucher Totals
        Dim PONumberStatement As String = "SELECT PONumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
        PONumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        PONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim ReceiverNumberStatement As String = "SELECT DeleteReferenceNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim ReceiverNumberCommand As New SqlCommand(ReceiverNumberStatement, con)
        ReceiverNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        ReceiverNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceNumberStatement As String = "SELECT InvoiceNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceNumberCommand As New SqlCommand(InvoiceNumberStatement, con)
        InvoiceNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceDateStatement As String = "SELECT InvoiceDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceDateCommand As New SqlCommand(InvoiceDateStatement, con)
        InvoiceDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim ReceiptDateStatement As String = "SELECT ReceiptDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim ReceiptDateCommand As New SqlCommand(ReceiptDateStatement, con)
        ReceiptDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        ReceiptDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

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

        Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
        PaymentTermsCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim DiscountDateStatement As String = "SELECT DiscountDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim DiscountDateCommand As New SqlCommand(DiscountDateStatement, con)
        DiscountDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DiscountDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim CommentStatement As String = "SELECT Comment FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim CommentCommand As New SqlCommand(CommentStatement, con)
        CommentCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        CommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim DueDateStatement As String = "SELECT DueDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim DueDateCommand As New SqlCommand(DueDateStatement, con)
        DueDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DueDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

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
            PONumber = CInt(PONumberCommand.ExecuteScalar)
        Catch ex As Exception
            PONumber = 0
        End Try
        Try
            ReceiverNumber = CInt(ReceiverNumberCommand.ExecuteScalar)
        Catch ex As Exception
            ReceiverNumber = 0
        End Try
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
            FreightTotal = CDbl(InvoiceFreightCommand.ExecuteScalar)
        Catch ex As Exception
            FreightTotal = 0
        End Try
        Try
            SalesTaxTotal = CDbl(InvoiceSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            SalesTaxTotal = 0
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
            PaymentTerms1 = CStr(PaymentTermsCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentTerms1 = "N30"
        End Try
        Try
            DiscountDate = CStr(DiscountDateCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountDate = ""
        End Try
        Try
            Comment = CStr(CommentCommand.ExecuteScalar)
        Catch ex As Exception
            Comment = ""
        End Try
        Try
            DueDateStr = CStr(DueDateCommand.ExecuteScalar)
        Catch ex As Exception
            DueDateStr = ""
        End Try
        Try
            DiscountAmount = CDbl(DiscountAmountCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountAmount = 0
        End Try
        Try
            VoucherStatus = CStr(VoucherStatusCommand.ExecuteScalar)
        Catch ex As Exception
            VoucherStatus = "OPEN"
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

        cboVendorID.Text = VendorID
        txtInvoiceNumber.Text = InvoiceNumber
        dtpInvoiceDateDD.Text = InvoiceDate
        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
        txtFreightTotal.Text = FreightTotal
        txtSalesTaxTotal.Text = SalesTaxTotal
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtTermDiscount.Text = DiscountAmount
        txtInvoiceAmount.Text = InvoiceAmount
        cboPONumber.Text = PONumber
        dtpDueDateDD.Text = DueDateStr
        dtpReceiptDateDD.Text = ReceiptDate
        dtpDiscountDateDD.Text = DiscountDate
        txtComment.Text = Comment
        cboCheckType.Text = CheckType
        cboPaymentTerms.Text = PaymentTerms1

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
            cmdSave.Enabled = False
            cmdSelectByPO.Enabled = False
            cmdGenerateVoucher.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            cmdSelectByPO.Enabled = True
            cmdGenerateVoucher.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            DeleteToolStripMenuItem.Enabled = True
        End If
    End Sub

    Public Sub LoadRemitToAddress()
        If cboVendorID.Text = "" Then
            'Skip
        Else
            'Clear variables first
            txtRemitToZip.Clear()
            txtRemitToCity.Clear()
            txtRemitToAddress1.Clear()
            txtRemitToAddress2.Clear()
            txtRemitToState.Clear()

            VendorAddress1 = ""
            VendorAddress2 = ""
            VendorCity = ""
            VendorState = ""
            VendorZip = ""
            VendorCountry = ""

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
        End If
    End Sub

    'Clear Routines

    Public Sub ClearOnLoad()
        'Clear Invoice Header
        cboPartNumber.Text = ""
        cboPaymentTerms.Text = ""
        cboPONumber.Text = ""
        cboVendorID.Text = ""
        cboVoucherNumber.Text = ""
        cboCheckType.Text = ""

        cboPaymentTerms.Refresh()
        cboPONumber.Refresh()
        cboVoucherNumber.Refresh()
        cboVendorID.Refresh()
        cboPartNumber.Refresh()
        cboCheckType.Refresh()

        cboPaymentTerms.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1
        cboVoucherNumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1
        cboCheckType.SelectedIndex = -1

        dtpDiscountDateDD.Text = ""
        dtpInvoiceDateDD.Text = ""
        dtpReceiptDateDD.Text = ""

        txtFreightTotal.Refresh()
        txtInvoiceNumber.Refresh()
        txtInvoiceTotal.Refresh()
        txtPurchaseTotal.Refresh()
        txtSalesTaxTotal.Refresh()
        txtTermDiscount.Refresh()
        txtLongDescription.Refresh()
        txtQuantity.Refresh()
        txtUnitCost.Refresh()
        txtExtendedAmount.Refresh()
        txtComment.Refresh()
        txtInvoiceAmount.Refresh()
        txtVendorName.Refresh()

        txtFreightTotal.Clear()
        txtInvoiceNumber.Clear()
        txtInvoiceTotal.Clear()
        txtPurchaseTotal.Clear()
        txtSalesTaxTotal.Clear()
        txtTermDiscount.Clear()
        txtLongDescription.Clear()
        txtQuantity.Clear()
        txtUnitCost.Clear()
        txtExtendedAmount.Clear()
        txtComment.Clear()
        txtInvoiceAmount.Clear()
        txtVendorName.Clear()
        txtFreightVouched.Clear()
        txtFreightOnPO.Clear()
        txtTaxOnPO.Clear()
        txtRemitToAddress1.Clear()
        txtRemitToAddress2.Clear()
        txtRemitToCity.Clear()
        txtRemitToCountry.Clear()
        txtRemitToState.Clear()
        txtRemitToZip.Clear()
        txtRemitToVendorID.Clear()
        txtRemitToVendorName.Clear()

        chkManualDiscount.Checked = False
        chkWhitePaper.Checked = False
        chkOnHold.Checked = False

        txtTermDiscount.Enabled = False

        If VoucherStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            cmdSelectByPO.Enabled = False
            cmdGenerateVoucher.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            cmdSelectByPO.Enabled = True
            cmdGenerateVoucher.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            DeleteToolStripMenuItem.Enabled = True
        End If

        cmdGenerateVoucher.Focus()
    End Sub

    Public Sub ClearVariables()
        DeleteReferenceNumber = 0
        DiscountDays = 0
        DueDays = 0
        Quantity = 0
        PONumber = 0
        ReceiverNumber = 0
        counter = 0
        LastVoucherNumber = 0
        NextVoucherNumber = 0
        LastBatchNumber = 0
        NextBatchNumber = 0
        DueDateStr = ""
        Comment = ""
        VoucherStatus = ""
        GLCreditAccount = ""
        GLDebitAccount = ""
        PartDescription = ""
        VendorName = ""
        BatchDate = ""
        BatchDescription = ""
        InvoiceNumber = ""
        InvoiceDate = ""
        VendorID = ""
        ReceiptDate = ""
        PaymentTerms = ""
        DiscountDate = ""
        DiscountAmount = 0
        DiscountPercent = 0
        BatchAmount = 0
        ProductTotal = 0
        FreightTotal = 0
        SalesTaxTotal = 0
        InvoiceTotal = 0
        InvoiceManualTotal = 0
        SUMInvoiceTotal = 0
        SUMExtendedAmount = 0
        ExtendedAmount = 0
        UnitCost = 0
        UndistributedAmount = 0
        CurrentAmount = 0
        BatchCurrentAmount = 0
        UniqueInvoice = ""
        InvoiceAmount = 0
        LastLineNumber = 0
        NextLineNumber = 0
        ADDUnitCost = 0
        ADDExtendedAmount = 0
        ADDQuantity = 0
        GLDescription = ""
        GLDebitAccount = ""
        VendorState = ""
        VendorAddress1 = ""
        VendorAddress2 = ""
        VendorCountry = ""
        VendorCity = ""
        VendorZip = ""
        VendorName = ""
        GlobalVoucherNumber = 0
        RoundingAmount = 0
        GetExtendedAmount = 0
        CheckReceiverLine = 0
        CheckReceiverNumber = 0
        CheckQuantity = 0
        CheckPartNumber = ""
        CheckUnitCost = 0
        TotalQuantityVouched = 0
        TotalReceiverQuantity = 0
        VendorClass = ""
        PaymentTerms1 = ""
        CheckType = ""
        OnHoldStatus = "NO"
        CheckCode = ""
        WhitePaper = "NO"
        LineNumber = 0
        ManualDiscountSelected = ""
        Checked1099 = ""
    End Sub

    Public Sub ClearInvoice()
        'Clear Invoice Header
        cboPaymentTerms.Refresh()
        cboPONumber.Refresh()
        cboVoucherNumber.Refresh()
        cboVendorID.Refresh()
        cboPartNumber.Refresh()
        cboCheckType.Refresh()

        cboPaymentTerms.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1
        cboVoucherNumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1
        cboCheckType.SelectedIndex = -1

        dtpDiscountDateDD.Text = ""
        dtpInvoiceDateDD.Text = ""
        dtpReceiptDateDD.Text = ""

        txtFreightTotal.Refresh()
        txtInvoiceNumber.Refresh()
        txtInvoiceTotal.Refresh()
        txtPurchaseTotal.Refresh()
        txtSalesTaxTotal.Refresh()
        txtTermDiscount.Refresh()
        txtLongDescription.Refresh()
        txtQuantity.Refresh()
        txtUnitCost.Refresh()
        txtExtendedAmount.Refresh()
        txtComment.Refresh()
        txtInvoiceAmount.Refresh()
        txtVendorName.Refresh()

        txtFreightTotal.Clear()
        txtInvoiceNumber.Clear()
        txtInvoiceTotal.Clear()
        txtPurchaseTotal.Clear()
        txtSalesTaxTotal.Clear()
        txtTermDiscount.Clear()
        txtLongDescription.Clear()
        txtQuantity.Clear()
        txtUnitCost.Clear()
        txtExtendedAmount.Clear()
        txtComment.Clear()
        txtInvoiceAmount.Clear()
        txtVendorName.Clear()
        txtRemitToAddress1.Clear()
        txtRemitToAddress2.Clear()
        txtRemitToCity.Clear()
        txtRemitToCountry.Clear()
        txtRemitToState.Clear()
        txtRemitToVendorID.Clear()
        txtRemitToVendorName.Clear()
        txtRemitToZip.Clear()
        txtTaxOnPO.Clear()
        txtFreightOnPO.Clear()
        txtFreightVouched.Clear()

        chkManualDiscount.Checked = False
        chkOnHold.Checked = False
        chkWhitePaper.Checked = False

        txtTermDiscount.Enabled = False

        cboVoucherNumber.Focus()

        If VoucherStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            cmdSelectByPO.Enabled = False
            cmdGenerateVoucher.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            cmdSelectByPO.Enabled = True
            cmdGenerateVoucher.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            DeleteToolStripMenuItem.Enabled = True
        End If
    End Sub

    'Validation and Error checking

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
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

    Private Sub SelectPOLines_closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ShowVoucherLines()
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
    End Sub

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

    Public Sub FormLoginRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LoginTime", SqlDbType.VarChar).Value = strTodaysTime
            .Add("@LogoutDate", SqlDbType.VarChar).Value = ""
            .Add("@LogoutTime", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub FormLogoutRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = ""
            .Add("@LoginTime", SqlDbType.VarChar).Value = ""
            .Add("@LogoutDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LogoutTime", SqlDbType.VarChar).Value = strTodaysTime
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Combobox Routines

    Private Sub cboPONumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPONumber.TextChanged
        ShowVoucherLines()
        LoadFreightTotals()
    End Sub

    Private Sub cboPaymentTerms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentTerms.SelectedIndexChanged
        LoadPaymentTermDetails()

        If cboPaymentTerms.Text = "CREDIT CARD" Then
            cboPaymentTerms.ForeColor = Color.Red
        Else
            cboPaymentTerms.ForeColor = Color.Black
        End If
    End Sub

    Private Sub cboVoucherNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVoucherNumber.SelectedIndexChanged
        LoadVoucherInfo()
        LoadVoucherTotals()
        ShowVoucherLines()
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        'Command to load Payment Terms from Vendor
        Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
        PaymentTermsCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
        VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim CheckCodeStatement As String = "SELECT CheckCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim CheckCodeCommand As New SqlCommand(CheckCodeStatement, con)
        CheckCodeCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        CheckCodeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim Checked1099Statement As String = "SELECT Checked1099 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim Checked1099Command As New SqlCommand(Checked1099Statement, con)
        Checked1099Command.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        Checked1099Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentTerms = "N30"
        End Try
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
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
            Checked1099 = CStr(Checked1099Command.ExecuteScalar)
        Catch ex As Exception
            Checked1099 = "NO"
        End Try
        con.Close()

        cboPaymentTerms.Text = PaymentTerms
        LoadPaymentTermDetails()

        If cboPaymentTerms.Text = "CREDIT CARD" Then
            cboPaymentTerms.ForeColor = Color.Red
        Else
            cboPaymentTerms.ForeColor = Color.Black
        End If

        'Set defaults and load payment info for Vendor
        cboPONumber.Text = ""
        txtVendorName.Text = VendorName
        cboVendorClass.Text = VendorClass
        cboCheckType.Text = CheckCode

        LoadRemitToAddress()

        txtRemitToVendorID.Text = cboVendorID.Text
        txtRemitToVendorName.Text = txtVendorName.Text

        'Load all PO's for the specific Vendor
        LoadPONumber()
        cboPONumber.SelectedIndex = -1
    End Sub

    Private Sub cboVendorID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedValueChanged
        cboPaymentTerms.Enabled = True
        LoadPONumber()
        LoadRemitToAddress()
        cboPONumber.SelectedIndex = -1
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        'Find the line items info
        Dim PartDescriptionStatement As String = "SELECT ShortDescription FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescriptionCommand As New SqlCommand(PartDescriptionStatement, con)
        PartDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim GLDebitAccountStatement As String = "SELECT GLDebitAccount FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GLDebitAccountCommand As New SqlCommand(GLDebitAccountStatement, con)
        GLDebitAccountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        GLDebitAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            PartDescription = ""
        End Try
        Try
            GLDebitAccount = CStr(GLDebitAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLDebitAccount = ""
        End Try
        con.Close()

        Dim GLDebitDescriptionStatement As String = "SELECT GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim GLDebitDescriptionCommand As New SqlCommand(GLDebitDescriptionStatement, con)
        GLDebitDescriptionCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLDebitAccount

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GLDescription = CStr(GLDebitDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            GLDescription = ""
        End Try
        con.Close()

        txtLongDescription.Text = PartDescription
        cboDebitAccount.Text = GLDebitAccount
        cboDebitDescription.Text = GLDescription
    End Sub

    'Textbox Routines

    Private Sub txtFreightTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightTotal.TextChanged
        FreightTotal = Val(txtFreightTotal.Text)
        InvoiceTotal = ProductTotal + SalesTaxTotal + FreightTotal
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Private Sub txtSalesTaxTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTaxTotal.TextChanged
        SalesTaxTotal = Val(txtSalesTaxTotal.Text)
        InvoiceTotal = ProductTotal + SalesTaxTotal + FreightTotal
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        ADDQuantity = Val(txtQuantity.Text)
        ADDUnitCost = Val(txtUnitCost.Text)
        ADDExtendedAmount = ADDQuantity * ADDUnitCost
        ADDExtendedAmount = Math.Round(ADDExtendedAmount, 2)
        txtExtendedAmount.Text = ADDExtendedAmount
    End Sub

    Private Sub txtUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitCost.TextChanged
        ADDQuantity = Val(txtQuantity.Text)
        ADDUnitCost = Val(txtUnitCost.Text)
        ADDExtendedAmount = ADDQuantity * ADDUnitCost
        ADDExtendedAmount = Math.Round(ADDExtendedAmount, 2)
        txtExtendedAmount.Text = ADDExtendedAmount
    End Sub

    'Datagrid Routines

    Private Sub dgvVoucherLines_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvVoucherLines.SelectionChanged
        CheckPackingSlipUpload()
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvVoucherLines.CellValueChanged
        Dim LineOrderQuantity As Double = 0
        Dim LineExtendedAmount As Double = 0
        Dim LineUnitCost As Double = 0
        Dim LineNumber As Integer
        Dim LinePartNumber, LinePartDescription, LineGLDebitAccount, LineGLCreditAccount As String

        If Me.dgvVoucherLines.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvVoucherLines.CurrentCell.RowIndex

            LineUnitCost = Me.dgvVoucherLines.Rows(RowIndex).Cells("UnitCostColumn").Value
            LineOrderQuantity = Me.dgvVoucherLines.Rows(RowIndex).Cells("QuantityColumn").Value
            LinePartNumber = Me.dgvVoucherLines.Rows(RowIndex).Cells("PartNumberColumn").Value
            LinePartDescription = Me.dgvVoucherLines.Rows(RowIndex).Cells("PartDescriptionColumn").Value
            LineGLCreditAccount = Me.dgvVoucherLines.Rows(RowIndex).Cells("GLCreditAccountColumn").Value
            LineGLDebitAccount = Me.dgvVoucherLines.Rows(RowIndex).Cells("GLDebitAccountColumn").Value
            LineNumber = Me.dgvVoucherLines.Rows(RowIndex).Cells("VoucherLineColumn").Value

            LineExtendedAmount = LineUnitCost * LineOrderQuantity
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
            LineUnitCost = Math.Round(LineUnitCost, 6)

            Try
                'UPDATE ROI based on line changes
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET PartNumber = @PartNumber, PartDescription = @PartDescription, UnitCost = @UnitCost, Quantity = @Quantity, ExtendedAmount = @ExtendedAmount, GLCreditAccount = @GLCreditAccount, GLDebitAccount = @GLDebitAccount, DivisionID = @DivisionID WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = LineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = LinePartDescription
                    .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                    .Add("@Quantity", SqlDbType.VarChar).Value = LineOrderQuantity
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = LineGLCreditAccount
                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = LineGLDebitAccount
                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = txtDivisionID.Text
                ErrorDescription = "ROI Voucher Form - Update cell value - ROI Line Update"
                ErrorReferenceNumber = "Voucher # " + cboVoucherNumber.Text
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Load Totals and Update Header Table
            ReLoadVoucherTotals()

            Try
                'UPDATE ROI Batch Line Table on changes
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@InvoiceFreight", SqlDbType.VarChar).Value = FreightTotal
                    .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = SalesTaxTotal
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtTermDiscount.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = txtDivisionID.Text
                ErrorDescription = "ROI Voucher Form - Update cell value - ROI Header update"
                ErrorReferenceNumber = "Voucher # " + cboVoucherNumber.Text
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Reload datagrid
            ShowVoucherLines()
        Else
            'Do nothing
        End If
    End Sub

    'Command Button Routines

    Private Sub cmdSelectByPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectByPO.Click
        If cboVoucherNumber.Text = "" Then
            MsgBox("A valid Voucher Number must be selected to create a Voucher.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
        Else
            'Verify Invoice Number
            VerifyUniqueInvoiceNumber()

            If UniqueInvoice = "YES" Then
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
                Try
                    UpdateHeaderTable()
                Catch ex As Exception
                    'Error Log

                End Try

                'Declare global variables
                GlobalVoucherNumber = Val(cboVoucherNumber.Text)
                GlobalAPDivisionID = txtDivisionID.Text
                GlobalAPPONumber = Val(cboPONumber.Text)
                GlobalAPBatchNumber = Val(txtBatchNumber.Text)
                GlobalAPVendorID = cboVendorID.Text

                'Open selection form
                Dim NewSelectPOLines As New SelectPOLines
                NewSelectPOLines.Show()

                Me.Dispose()
                Me.Close()
            Else
                MsgBox("This Invoice Number has already been used.", MsgBoxStyle.OkOnly)
                txtInvoiceNumber.Focus()
            End If
        End If
    End Sub

    Private Sub cmdGenerateVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateVoucher.Click
        'Validate fields before creating new voucher
        If cboVoucherNumber.Text = "" Or txtBatchNumber.Text = "" Or txtDivisionID.Text = "" Then
            'Do not save, clear form and get next voucher number
            ClearVariables()
            ClearInvoice()
            ClearDataInDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNoninventoryItems()
            cboVoucherNumber.Focus()

            Try
                InsertIntoHeaderTable()
            Catch ex As Exception
                'Error Log
            End Try

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
                ClearVariables()
                ClearInvoice()
                ClearDataInDatagrid()
                LoadVendor()
                LoadVoucher()
                LoadNoninventoryItems()
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
                DiscountAmount = Val(txtTermDiscount.Text)
            Else
                DiscountAmount = DiscountPercent * ProductTotal
            End If

            ProductTotal = SUMExtendedAmount
            InvoiceTotal = ProductTotal + SalesTaxTotal + FreightTotal

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

            txtFreightTotal.Text = FreightTotal
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
            txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
            txtSalesTaxTotal.Text = SalesTaxTotal
            txtTermDiscount.Text = DiscountAmount

            'verify that Invoice Amount equals Invoice Total
            InvoiceAmount = Val(txtInvoiceAmount.Text)

            If InvoiceAmount <> InvoiceTotal Then
                MsgBox("The Invoice Total does not match. Check your totals.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Proceed
            End If

            'Clear text fields for next entry
            ClearVariables()
            ClearInvoice()
            ClearDataInDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNoninventoryItems()
            cboVoucherNumber.Focus()

            InsertIntoHeaderTable()
        Else
            'Do not save, clear form and get next voucher number
            ClearVariables()
            ClearInvoice()
            ClearDataInDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNoninventoryItems()
            cboVoucherNumber.Focus()

            InsertIntoHeaderTable()

            Exit Sub
        End If
    End Sub

    Private Sub cmdClearInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ClearVariables()
        ClearOnLoad()
        ClearDataInDatagrid()
        ClearInvoice()
        LoadVendor()
        LoadVoucher()
    End Sub

    Private Sub cmdViewPackingSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPackingSlip.Click
        If dgvVoucherLines.SelectedCells.Count > 0 AndAlso dgvVoucherLines.SelectedCells(0).RowIndex >= 0 Then
            PackingSlipScannerUploadAPI.ViewPackingSlip(dir, dgvVoucherLines.Rows(dgvVoucherLines.SelectedCells(0).RowIndex).Cells("ReceiverNumberColumn").Value.ToString)
        End If
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If cboVoucherNumber.Text = "" Or cboVoucherLineNumber.Text = "" Then
            MsgBox("You must select a valid Voucher Number/Line Number to delete", MsgBoxStyle.OkOnly)
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
                'Prompt before deleting
                Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Voucher Line?", "DELETE VOUCHER LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Change Status of Receiving Line and Receiving Header Table, if necessary
                    Dim ReceiverNumber As Integer = 0
                    Dim ReceiverLineNumber As Integer = 0

                    Dim ReceiverNumberStatement As String = "SELECT ReceiverNumber FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                    Dim ReceiverNumberCommand As New SqlCommand(ReceiverNumberStatement, con)
                    ReceiverNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    ReceiverNumberCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboVoucherLineNumber.Text)

                    Dim ReceiverLineNumberStatement As String = "SELECT ReceiverLine FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                    Dim ReceiverLineNumberCommand As New SqlCommand(ReceiverLineNumberStatement, con)
                    ReceiverLineNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    ReceiverLineNumberCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboVoucherLineNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ReceiverNumber = CInt(ReceiverNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        ReceiverNumber = 0
                    End Try
                    Try
                        ReceiverLineNumber = CInt(ReceiverLineNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        ReceiverLineNumber = 0
                    End Try
                    con.Close()

                    cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey", con)
                    cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                    cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey", con)
                    cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                    cmd.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = ReceiverLineNumber
                    cmd.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Delete Voucher
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)
                    cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    cmd.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboVoucherLineNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '*******************************************************************************************************************************
                    'Check line quantities in datagrid, and delete any zero quantity lines
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)
                    cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    cmd.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboVoucherLineNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Reload datagrid
                    ShowVoucherLines()

                    'Renumber lines
                    Dim TempLineNumber As Integer = 1000

                    For Each row As DataGridViewRow In dgvVoucherLines.Rows
                        Dim LineNumber As Integer
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
                        Dim LineNumber As Integer

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
                    '**************************************************************************************************
                    'Refresh Datagrid on Delete and update totals
                    ReLoadVoucherTotals()
                    UpdateBatchTotal()
                    ShowVoucherLines()
                ElseIf button = DialogResult.No Then
                    cmdDeleteLine.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmdEnterVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterVoucher.Click
        'Validate fields before creating new voucher
        If cboVoucherNumber.Text = "" Or txtBatchNumber.Text = "" Or txtDivisionID.Text = "" Then
            'Do not save, clear form and get next voucher number
            ClearVariables()
            ClearInvoice()
            ClearDataInDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNoninventoryItems()
            cboVoucherNumber.Focus()

            Try
                InsertIntoHeaderTable()
            Catch ex As Exception
                'Error Log
            End Try

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
                ClearVariables()
                ClearInvoice()
                ClearDataInDatagrid()
                LoadVendor()
                LoadVoucher()
                LoadNoninventoryItems()
                cboVoucherNumber.Focus()

                Try
                    InsertIntoHeaderTable()
                Catch ex As Exception
                    'Error Log

                End Try

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
                DiscountAmount = Val(txtTermDiscount.Text)
            Else
                DiscountAmount = DiscountPercent * ProductTotal
            End If

            ProductTotal = SUMExtendedAmount
            InvoiceTotal = ProductTotal + SalesTaxTotal + FreightTotal

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

            txtFreightTotal.Text = FreightTotal
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
            txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
            txtSalesTaxTotal.Text = SalesTaxTotal
            txtTermDiscount.Text = DiscountAmount

            'verify that Invoice Amount equals Invoice Total
            InvoiceAmount = Val(txtInvoiceAmount.Text)

            If InvoiceAmount <> InvoiceTotal Then
                MsgBox("The Invoice Total does not match. Check your totals.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Proceed
            End If

            'Clear text fields for next entry
            ClearVariables()
            ClearInvoice()
            ClearDataInDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNoninventoryItems()
            cboVoucherNumber.Focus()

            Try
                InsertIntoHeaderTable()
            Catch ex As Exception
                'Error Log

            End Try
        Else
            'Do not save, clear form and get next voucher number
            ClearVariables()
            ClearInvoice()
            ClearDataInDatagrid()
            LoadVendor()
            LoadVoucher()
            LoadNoninventoryItems()
            cboVoucherNumber.Focus()

            Try
                InsertIntoHeaderTable()
            Catch ex As Exception
                'Error Log

            End Try

            Exit Sub
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number and a valid Invoice Number.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
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
                GlobalVoucherNumber = Val(cboVoucherNumber.Text)
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Else
                'Verify Invoice Number
                VerifyUniqueInvoiceNumber()

                If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then
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
                        If cboCheckType.Text = "ACH" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "FEDEX" Then
                            chkWhitePaper.Checked = True
                        Else
                            chkWhitePaper.Checked = False
                        End If
                    End If
                    '************************************************************************************************************************************************
                    If chkOnHold.Checked = True Then
                        OnHoldStatus = "YES"
                    Else
                        OnHoldStatus = "NO"
                    End If
                    '************************************************************************************************************************************************
                    'Verify that a valid PO Number is present
                    If cboPONumber.Text = "" Then
                        Dim PONumberStatement As String = "SELECT PONumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
                        Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
                        PONumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            PONumber = CInt(PONumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            PONumber = 0
                        End Try
                        con.Close()

                        cboPONumber.Text = PONumber
                    Else
                        'Do nothing - valid PO
                    End If
                    '************************************************************************************************************************************************
                    Try
                        'UPDATE Data in Voucher Header Table (Batch Line)
                        UpdateHeaderTable()

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
                            Dim LineNumber As Integer
                            Try
                                LineNumber = row.Cells("VoucherLineColumn").Value
                            Catch ex2 As Exception
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
                            Dim LineNumber As Integer

                            Try
                                LineNumber = row.Cells("VoucherLineColumn").Value
                            Catch ex2 As Exception
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

                        'Reload Voucher Lines in grid
                        ShowVoucherLines()
                        '****************************************************************************************************************
                        'Check to see if rounding is needed
                        If Val(txtInvoiceAmount.Text) = InvoiceTotal Then
                            'Do nothing - no rounding is needed
                        Else
                            Dim button3 As DialogResult = MessageBox.Show("Do you wish to round the difference?", "ROUND DIFFERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If button3 = DialogResult.Yes Then
                                Dim SUMNewExtendedAmount, NewExtendedAmount, NewPrice, GetLineQuantity As Double
                                RoundingAmount = Val(txtInvoiceAmount.Text) - InvoiceTotal

                                Dim GetExtendedAmountStatement As String = "SELECT ExtendedAmount FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                                Dim GetExtendedAmountCommand As New SqlCommand(GetExtendedAmountStatement, con)
                                GetExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                GetExtendedAmountCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = 1

                                Dim GetLineQuantityStatement As String = "SELECT Quantity FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                                Dim GetLineQuantityCommand As New SqlCommand(GetLineQuantityStatement, con)
                                GetLineQuantityCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                GetLineQuantityCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = 1

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetExtendedAmount = CDbl(GetExtendedAmountCommand.ExecuteScalar)
                                Catch ex1 As Exception
                                    GetExtendedAmount = 0
                                End Try
                                Try
                                    GetLineQuantity = CDbl(GetLineQuantityCommand.ExecuteScalar)
                                Catch ex1 As Exception
                                    GetLineQuantity = 0
                                End Try
                                con.Close()

                                NewExtendedAmount = GetExtendedAmount + RoundingAmount
                                NewExtendedAmount = Math.Round(NewExtendedAmount, 2)

                                If GetLineQuantity = 0 Then
                                    NewPrice = 0
                                Else
                                    NewPrice = NewExtendedAmount / GetLineQuantity
                                    NewPrice = Math.Round(NewPrice, 5)
                                End If

                                'Update Line Database Table
                                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = @ExtendedAmount, UnitCost = @UnitCost WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)
                                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                cmd.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = 1
                                cmd.Parameters.Add("@ExtendedAmount", SqlDbType.VarChar).Value = NewExtendedAmount
                                cmd.Parameters.Add("@UnitCost", SqlDbType.VarChar).Value = NewPrice

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                Dim SUMNewExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                                Dim SUMNewExtendedAmountCommand As New SqlCommand(SUMNewExtendedAmountStatement, con)
                                SUMNewExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    SUMNewExtendedAmount = CDbl(SUMNewExtendedAmountCommand.ExecuteScalar)
                                Catch ex1 As Exception
                                    SUMNewExtendedAmount = 0
                                End Try
                                con.Close()

                                SUMNewExtendedAmount = Math.Round(SUMNewExtendedAmount, 2)

                                'Update Header Database Table
                                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = SUMNewExtendedAmount
                                cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = Val(txtInvoiceAmount.Text)

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                ShowVoucherLines()
                                LoadVoucherTotals()
                            ElseIf button3 = DialogResult.No Then
                                cmdClear.Focus()
                            End If
                        End If
                        '***********************************************************************************************
                        'UPDATE Receiving Line Table
                        For Each row As DataGridViewRow In dgvVoucherLines.Rows
                            Try
                                CheckReceiverNumber = row.Cells("ReceiverNumberColumn").Value
                            Catch ex2 As Exception
                                CheckReceiverNumber = 0
                            End Try
                            Try
                                CheckReceiverLine = row.Cells("ReceiverLineColumn").Value
                            Catch ex2 As Exception
                                CheckReceiverLine = 0
                            End Try
                            Try
                                CheckPartNumber = row.Cells("PartNumberColumn").Value
                            Catch ex2 As Exception
                                CheckPartNumber = ""
                            End Try

                            'Extract data from Receiving Line Query
                            Dim SelectPOLineStatement As String = "SELECT POLineNumber FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND PartNumber = @PartNumber AND ReceivingLineKey = @ReceivingLineKey"
                            Dim SelectPOLineCommand As New SqlCommand(SelectPOLineStatement, con)
                            SelectPOLineCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            SelectPOLineCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                            SelectPOLineCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                SelectPOLine = CInt(SelectPOLineCommand.ExecuteScalar)
                            Catch ex1 As Exception
                                SelectPOLine = 0
                            End Try
                            con.Close()

                            'Get Total Amount Received
                            Dim TotalReceiverQuantityStatement As String = "SELECT QuantityReceived FROM ReceivingLineQuery1 WHERE PONumber = @PONumber AND PartNumber = @PartNumber AND POLineNumber = @POLineNumber"
                            Dim TotalReceiverQuantityCommand As New SqlCommand(TotalReceiverQuantityStatement, con)
                            TotalReceiverQuantityCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                            TotalReceiverQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                            TotalReceiverQuantityCommand.Parameters.Add("@POLineNumber", SqlDbType.VarChar).Value = SelectPOLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                TotalReceiverQuantity = CDbl(TotalReceiverQuantityCommand.ExecuteScalar)
                            Catch ex1 As Exception
                                TotalReceiverQuantity = 0
                            End Try
                            con.Close()

                            'Get Total Amount Vouched
                            Dim TotalQuantityVouchedStatement As String = "SELECT QuantityVouched FROM ReceiverVoucherSummary WHERE ReceiverNumber = @ReceiverNumber AND PartNumber = @PartNumber AND ReceiverLine = @ReceiverLine"
                            Dim TotalQuantityVouchedCommand As New SqlCommand(TotalQuantityVouchedStatement, con)
                            TotalQuantityVouchedCommand.Parameters.Add("@ReceiverNumber", SqlDbType.VarChar).Value = CheckReceiverNumber
                            TotalQuantityVouchedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                            TotalQuantityVouchedCommand.Parameters.Add("@ReceiverLine", SqlDbType.VarChar).Value = CheckReceiverLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                TotalQuantityVouched = CDbl(TotalQuantityVouchedCommand.ExecuteScalar)
                            Catch ex1 As Exception
                                TotalQuantityVouched = 0
                            End Try
                            con.Close()

                            If TotalQuantityVouched < TotalReceiverQuantity Then
                                'Update Receiving Line table to show line received
                                cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'Update Header Table
                                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                                    .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Else
                                'Update Receiving Line table to show line received
                                cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If
                        Next
                        '***********************************************************************************************
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

                        'Determine if manual discount amount
                        If chkManualDiscount.Checked = True Then
                            DiscountAmount = Val(txtTermDiscount.Text)
                        Else
                            DiscountAmount = DiscountPercent * ProductTotal
                        End If

                        ProductTotal = SUMExtendedAmount
                        InvoiceTotal = ProductTotal + SalesTaxTotal + FreightTotal

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

                        txtFreightTotal.Text = FreightTotal
                        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
                        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                        txtSalesTaxTotal.Text = SalesTaxTotal
                        txtTermDiscount.Text = DiscountAmount
                    Catch ex As Exception
                        'Error Log

                    End Try

                    GlobalVoucherNumber = Val(cboVoucherNumber.Text)
                    Using NewPrintVoucher As New PrintVoucher
                        Dim Result = NewPrintVoucher.ShowDialog()
                    End Using
                Else
                    MsgBox("This Invoice Number has already been used or is blank.", MsgBoxStyle.OkOnly)
                    txtInvoiceNumber.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number and a valid Invoice Number.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
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
                MsgBox("Voucher cannot be saved at this time.", MsgBoxStyle.OkOnly)
            Else
                'Verify Invoice Number
                VerifyUniqueInvoiceNumber()

                If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then
                    '*****************************************************************************************************
                    'Validate Dates
                    ValidateDates()

                    If CheckAndValidateDates = "NOT OKAY" Then
                        Dim button As DialogResult = MessageBox.Show("One of your dates is more than 90 days out. Do you wish to continue?", "DATE 90 DAYS OR OVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If button = DialogResult.Yes Then
                            'Do nothing and continue
                        ElseIf button = DialogResult.No Then
                            Exit Sub
                        End If
                    Else
                        'Do nothing
                    End If
                    '*****************************************************************************************************
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
                    'Verify that a valid PO Number is present
                    If cboPONumber.Text = "" Then
                        Dim PONumberStatement As String = "SELECT PONumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
                        Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
                        PONumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            PONumber = CInt(PONumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            PONumber = 0
                        End Try
                        con.Close()

                        cboPONumber.Text = PONumber
                    Else
                        'Do nothing - valid PO
                    End If
                    '************************************************************************************************************************************************
                    Try
                        'UPDATE Data in Voucher Header Table (Batch Line)
                        UpdateHeaderTable()
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
                            Dim LineNumber As Integer
                            Try
                                LineNumber = row.Cells("VoucherLineColumn").Value
                            Catch ex2 As Exception
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
                            Dim LineNumber As Integer

                            Try
                                LineNumber = row.Cells("VoucherLineColumn").Value
                            Catch ex2 As Exception
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

                        'Reload Voucher Lines in grid
                        ShowVoucherLines()
                        '****************************************************************************************************************
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

                        'Determine if manual discount amount
                        If chkManualDiscount.Checked = True Then
                            DiscountAmount = Val(txtTermDiscount.Text)
                        Else
                            DiscountAmount = DiscountPercent * ProductTotal
                        End If

                        ProductTotal = SUMExtendedAmount
                        InvoiceTotal = ProductTotal + SalesTaxTotal + FreightTotal

                        ProductTotal = Math.Round(ProductTotal, 2)
                        DiscountAmount = Math.Round(DiscountAmount, 2)
                        InvoiceTotal = Math.Round(InvoiceTotal, 2)

                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                        cmd.Parameters.Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '************************************************************************
                        'Check to see if rounding is needed
                        If Val(txtInvoiceAmount.Text) = InvoiceTotal Then
                            'Do nothing - no rounding is needed
                        Else
                            Dim button As DialogResult = MessageBox.Show("Do you wish to round the difference?", "ROUND DIFFERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If button = DialogResult.Yes Then
                                Dim SUMNewExtendedAmount, NewExtendedAmount, NewPrice, GetLineQuantity As Double
                                RoundingAmount = Val(txtInvoiceAmount.Text) - InvoiceTotal

                                Dim GetExtendedAmountStatement As String = "SELECT ExtendedAmount FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                                Dim GetExtendedAmountCommand As New SqlCommand(GetExtendedAmountStatement, con)
                                GetExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                GetExtendedAmountCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = 1

                                Dim GetLineQuantityStatement As String = "SELECT Quantity FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                                Dim GetLineQuantityCommand As New SqlCommand(GetLineQuantityStatement, con)
                                GetLineQuantityCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                GetLineQuantityCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = 1

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetExtendedAmount = CDbl(GetExtendedAmountCommand.ExecuteScalar)
                                Catch ex1 As Exception
                                    GetExtendedAmount = 0
                                End Try
                                Try
                                    GetLineQuantity = CDbl(GetLineQuantityCommand.ExecuteScalar)
                                Catch ex1 As Exception
                                    GetLineQuantity = 0
                                End Try
                                con.Close()

                                NewExtendedAmount = GetExtendedAmount + RoundingAmount
                                NewExtendedAmount = Math.Round(NewExtendedAmount, 2)

                                If GetLineQuantity = 0 Then
                                    NewPrice = 0
                                Else
                                    NewPrice = NewExtendedAmount / GetLineQuantity
                                    NewPrice = Math.Round(NewPrice, 5)
                                End If

                                'Update Line Database Table
                                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = @ExtendedAmount, UnitCost = @UnitCost WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)
                                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                cmd.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = 1
                                cmd.Parameters.Add("@ExtendedAmount", SqlDbType.VarChar).Value = NewExtendedAmount
                                cmd.Parameters.Add("@UnitCost", SqlDbType.VarChar).Value = NewPrice

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                Dim SUMNewExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                                Dim SUMNewExtendedAmountCommand As New SqlCommand(SUMNewExtendedAmountStatement, con)
                                SUMNewExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    SUMNewExtendedAmount = CDbl(SUMNewExtendedAmountCommand.ExecuteScalar)
                                Catch ex1 As Exception
                                    SUMNewExtendedAmount = 0
                                End Try
                                con.Close()

                                SUMNewExtendedAmount = Math.Round(SUMNewExtendedAmount, 2)

                                'Update Header Database Table
                                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = SUMNewExtendedAmount
                                cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = Val(txtInvoiceAmount.Text)

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                ShowVoucherLines()
                                LoadVoucherTotals()
                            ElseIf button = DialogResult.No Then
                                cmdClear.Focus()
                            End If
                        End If
                        '***********************************************************************************************
                        'UPDATE Receiving Line Table
                        For Each row As DataGridViewRow In dgvVoucherLines.Rows
                            Try
                                CheckReceiverNumber = row.Cells("ReceiverNumberColumn").Value
                            Catch ex2 As Exception
                                CheckReceiverNumber = 0
                            End Try
                            Try
                                CheckReceiverLine = row.Cells("ReceiverLineColumn").Value
                            Catch ex2 As Exception
                                CheckReceiverLine = 0
                            End Try
                            Try
                                CheckPartNumber = row.Cells("PartNumberColumn").Value
                            Catch ex2 As Exception
                                CheckPartNumber = ""
                            End Try

                            'Extract data from Receiving Line Query
                            Dim SelectPOLineStatement As String = "SELECT POLineNumber FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND PartNumber = @PartNumber AND ReceivingLineKey = @ReceivingLineKey"
                            Dim SelectPOLineCommand As New SqlCommand(SelectPOLineStatement, con)
                            SelectPOLineCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            SelectPOLineCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                            SelectPOLineCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                SelectPOLine = CInt(SelectPOLineCommand.ExecuteScalar)
                            Catch ex1 As Exception
                                SelectPOLine = 0
                            End Try
                            con.Close()

                            'Get Total Amount Received
                            Dim TotalReceiverQuantityStatement As String = "SELECT QuantityReceived FROM ReceivingLineQuery1 WHERE PONumber = @PONumber AND PartNumber = @PartNumber AND POLineNumber = @POLineNumber"
                            Dim TotalReceiverQuantityCommand As New SqlCommand(TotalReceiverQuantityStatement, con)
                            TotalReceiverQuantityCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                            TotalReceiverQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                            TotalReceiverQuantityCommand.Parameters.Add("@POLineNumber", SqlDbType.VarChar).Value = SelectPOLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                TotalReceiverQuantity = CDbl(TotalReceiverQuantityCommand.ExecuteScalar)
                            Catch ex1 As Exception
                                TotalReceiverQuantity = 0
                            End Try
                            con.Close()

                            'Get Total Amount Vouched
                            Dim TotalQuantityVouchedStatement As String = "SELECT QuantityVouched FROM ReceiverVoucherSummary WHERE ReceiverNumber = @ReceiverNumber AND PartNumber = @PartNumber AND ReceiverLine = @ReceiverLine"
                            Dim TotalQuantityVouchedCommand As New SqlCommand(TotalQuantityVouchedStatement, con)
                            TotalQuantityVouchedCommand.Parameters.Add("@ReceiverNumber", SqlDbType.VarChar).Value = CheckReceiverNumber
                            TotalQuantityVouchedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                            TotalQuantityVouchedCommand.Parameters.Add("@ReceiverLine", SqlDbType.VarChar).Value = CheckReceiverLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                TotalQuantityVouched = CDbl(TotalQuantityVouchedCommand.ExecuteScalar)
                            Catch ex1 As Exception
                                TotalQuantityVouched = 0
                            End Try
                            con.Close()

                            If TotalQuantityVouched < TotalReceiverQuantity Then
                                'Update Receiving Line table to show line received
                                cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Update Header Table
                                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                                    .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Else
                                'Update Receiving Line table to show line received
                                cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If
                        Next
                        '***********************************************************************************************
                        txtFreightTotal.Text = FreightTotal
                        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
                        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                        txtSalesTaxTotal.Text = SalesTaxTotal
                        txtTermDiscount.Text = DiscountAmount

                        MsgBox("Voucher has been updated.", MsgBoxStyle.OkOnly)
                    Catch ex As Exception
                        'Error Log

                    End Try
                Else
                    MsgBox("This Invoice Number has already been used or is blank.", MsgBoxStyle.OkOnly)
                    txtInvoiceNumber.Focus()
                End If
            End If
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
                    MsgBox("Voucher cannot be deleted at this time.", MsgBoxStyle.OkOnly)
                Else
                    'Get Receiving Number and Line from datagrid
                    Dim ReceiverNumber, ReceivingLineNumber As Integer
                    ReceiverNumber = 0
                    ReceivingLineNumber = 0

                    'Get Receiver Number if it exists in Line Table
                    For Each row As DataGridViewRow In dgvVoucherLines.Rows
                        Try
                            ReceiverNumber = row.Cells("ReceiverNumberColumn").Value
                        Catch ex As Exception
                            ReceiverNumber = 0
                        End Try
                        Try
                            ReceivingLineNumber = row.Cells("ReceiverLineColumn").Value
                        Catch ex As Exception
                            ReceivingLineNumber = 0
                        End Try

                        If ReceiverNumber = 0 Then
                            'Change Status of Receiving Line and Receiving Header Table, if necessary
                            Dim DeleteReferenceNumberStatement As String = "SELECT DeleteReferenceNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                            Dim DeleteReferenceNumberCommand As New SqlCommand(DeleteReferenceNumberStatement, con)
                            DeleteReferenceNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            DeleteReferenceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                DeleteReferenceNumber = CInt(DeleteReferenceNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                DeleteReferenceNumber = 1
                            End Try
                            con.Close()

                            cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = DeleteReferenceNumber
                            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = DeleteReferenceNumber
                            cmd.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                            cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            Try
                                'Update Receiving Line Table
                                cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                                    .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = ReceivingLineNumber
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                Dim ErrorVoucherNumber As Integer
                                Dim strErrorVoucherNumber As String

                                ErrorVoucherNumber = Val(cboVoucherNumber.Text)
                                strErrorVoucherNumber = CStr(ErrorVoucherNumber)

                                ErrorDate = Today.ToShortDateString()
                                ErrorDescription = "AP Receipt of Invoice"
                                ErrorUser = EmployeeLoginName
                                ErrorComment = "Receiver line not reset on delete"
                                ErrorDivision = txtDivisionID.Text
                                ErrorReferenceNumber = "Voucher # - " + strErrorVoucherNumber

                                TFPErrorLogUpdate()
                            End Try

                            Try
                                'Update Receiving Header Table
                                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                Dim ErrorVoucherNumber As Integer
                                Dim strErrorVoucherNumber As String

                                ErrorVoucherNumber = Val(cboVoucherNumber.Text)
                                strErrorVoucherNumber = CStr(ErrorVoucherNumber)

                                ErrorDate = Today.ToShortDateString()
                                ErrorDescription = "AP Receipt of Invoice"
                                ErrorUser = EmployeeLoginName
                                ErrorComment = "Receiver header not reset on delete"
                                ErrorDivision = txtDivisionID.Text
                                ErrorReferenceNumber = "Voucher # - " + strErrorVoucherNumber

                                TFPErrorLogUpdate()
                            End Try
                        End If
                    Next

                    'Create command to save data from text boxes
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Clear text boxes on delete
                    ClearVariables()
                    ClearOnLoad()
                    ClearDataInDatagrid()
                    ClearInvoice()
                    LoadVendor()
                    LoadVoucher()
                End If
            ElseIf button = DialogResult.No Then
                cmdDelete.Focus()
            End If
        End If
    End Sub

    Private Sub cmdSelectMultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectMultiple.Click
        If Not String.IsNullOrEmpty(cboVendorID.Text) Then
            'Verify Invoice Number
            VerifyUniqueInvoiceNumber()

            If UniqueInvoice = "YES" Then
                'Make sure that Discount Date is not changed for N30
                VerifyDiscount()

                If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                    DiscountDate = dtpDueDateDD.Text
                    dtpDiscountDateDD.Text = DiscountDate
                Else
                    DiscountDate = dtpDiscountDateDD.Text
                End If

                Dim test As String = ds1.Tables("ReceivingHeaderTable").Rows(ds1.Tables("ReceivingHeaderTable").Rows.Count - 1).Item("PONumber").ToString()
                cmd = New SqlCommand("IF EXISTS(SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID)" _
                                     + " UPDATE ReceiptOfInvoiceBatchLine SET PONumber = @PONumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, InvoiceAmount = @InvoiceAmount, VendorClass = @VendorClass WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID" _
                                     + " ELSE Insert Into ReceiptOfInvoiceBatchLine(VoucherNumber, BatchNumber, PONumber,InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, InvoiceAmount, VendorClass)Values(@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @VendorID, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @InvoiceAmount, @VendorClass)", con)
                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@PONumber", SqlDbType.VarChar).Value = Val(ds1.Tables("ReceivingHeaderTable").Rows(ds1.Tables("ReceivingHeaderTable").Rows.Count - 1).Item("PONumber").ToString())
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                    .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDateDD.Text
                    .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDateDD.Text
                    .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@InvoiceFreight", SqlDbType.VarChar).Value = FreightTotal
                    .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = SalesTaxTotal
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                    .Add("@DiscountDate", SqlDbType.VarChar).Value = DiscountDate
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDateDD.Text
                    .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtTermDiscount.Text)
                    .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@VoucherSource", SqlDbType.VarChar).Value = "PO RECEIPT"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                    .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtInvoiceAmount.Text)
                    .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                End With

                Try
                    'Write Data to Batch Line (Voucher) Database Table
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    Dim ErrorVoucherNumber As Integer
                    Dim strErrorVoucherNumber As String

                    ErrorVoucherNumber = Val(cboVoucherNumber.Text)
                    strErrorVoucherNumber = CStr(ErrorVoucherNumber)

                    ErrorDate = Today.ToShortDateString()
                    ErrorDescription = "AP Receipt of Invoice"
                    ErrorUser = EmployeeLoginName
                    ErrorComment = "Error selecting multiple POs"
                    ErrorDivision = txtDivisionID.Text
                    ErrorReferenceNumber = "Voucher # - " + strErrorVoucherNumber

                    TFPErrorLogUpdate()
                End Try

                Dim lst As New List(Of String)
                For Each rw As DataRow In ds1.Tables("ReceivingHeaderTable").Rows
                    lst.Add(rw.Item("PONumber").ToString())
                Next

                Dim newSelectMultiplePO As New SelectMultiplePO(lst)
                newSelectMultiplePO.ShowDialog()
                If newSelectMultiplePO.DialogResult = Windows.Forms.DialogResult.Yes Then
                    Dim POArray As String() = newSelectMultiplePO.GetPOList()

                    If POArray IsNot Nothing Then
                        For Each PONumb As String In POArray
                            'Declare global variables
                            GlobalVoucherNumber = Val(cboVoucherNumber.Text)
                            GlobalAPDivisionID = txtDivisionID.Text
                            GlobalAPPONumber = Val(PONumb)
                            GlobalAPBatchNumber = Val(txtBatchNumber.Text)
                            GlobalAPVendorID = cboVendorID.Text

                            'Open selection form
                            Dim NewSelectPOLines As New SelectPOLines(False)
                            Me.Hide()
                            NewSelectPOLines.ShowDialog()
                            Me.Show()
                            Me.BringToFront()
                            If NewSelectPOLines.DialogResult = Windows.Forms.DialogResult.Cancel Then
                                Exit Sub
                            End If
                        Next
                    End If
                Else
                    Exit Sub
                End If
                ShowVoucherLines()
            Else
                MsgBox("This Invoice Number has already been used.", MsgBoxStyle.OkOnly)
                txtInvoiceNumber.Focus()
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Form Logout Routine
        FormLogoutRoutine()
        '****************************************************************************************************
        If Val(cboVoucherNumber.Text) = 0 Then
            'Update Batch Header Total
            UpdateBatchTotal()
            ClearOnLoad()
            ClearVariables()

            GlobalAPPONumber = 0
            GlobalVoucherNumber = 0

            GlobalAPDivisionID = txtDivisionID.Text
            GlobalAPBatchNumber = txtBatchNumber.Text

            Dim NewAPProcessBatch As New APProcessBatch
            NewAPProcessBatch.Show()

            Me.Dispose()
            Me.Close()
            Exit Sub
        End If
        '****************************************************************************************************
        'Prompt before exiting
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this Voucher? (Voucher will be deleted if NO)", "SAVE VOUCHER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Verify Invoice Number
            VerifyUniqueInvoiceNumber()

            If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then
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
                Else
                    '*****************************************************************************************************
                    'Validate Dates
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
                    '*****************************************************************************************************
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
                        If cboCheckType.Text = "ACH" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "FEDEX" Then
                            chkWhitePaper.Checked = True
                        Else
                            chkWhitePaper.Checked = False
                        End If
                    End If
                    '************************************************************************************************************************************************
                    If chkOnHold.Checked = True Then
                        OnHoldStatus = "YES"
                    Else
                        OnHoldStatus = "NO"
                    End If
                    '************************************************************************************************************************************************
                    'Verify that a valid PO Number is present
                    If cboPONumber.Text = "" Then
                        Dim PONumberStatement As String = "SELECT PONumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
                        Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
                        PONumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            PONumber = CInt(PONumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            PONumber = 0
                        End Try
                        con.Close()

                        cboPONumber.Text = PONumber
                    Else
                        'Do nothing - valid PO
                    End If
                    '************************************************************************************************************************************************
                    Try
                        'UPDATE Data in Voucher Header Table (Batch Line)
                        UpdateHeaderTable()
                        '************************************************************************
                        'Check to see if rounding is needed
                        If Val(txtInvoiceAmount.Text) = InvoiceTotal Then
                            'Do nothing - no rounding is needed
                        Else
                            Dim button1 As DialogResult = MessageBox.Show("Do you wish to round the difference?", "ROUND DIFFERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If button1 = DialogResult.Yes Then

                                If Val(txtInvoiceAmount.Text) = 0 And InvoiceTotal <> 0 Then
                                    MsgBox("You cannot round a voucher to zero. Check data and try again.", MsgBoxStyle.OkOnly)
                                    Exit Sub
                                End If

                                Dim SUMNewExtendedAmount, NewExtendedAmount, NewPrice, GetLineQuantity As Double
                                RoundingAmount = Val(txtInvoiceAmount.Text) - InvoiceTotal

                                Dim GetExtendedAmountStatement As String = "SELECT ExtendedAmount FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                                Dim GetExtendedAmountCommand As New SqlCommand(GetExtendedAmountStatement, con)
                                GetExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                GetExtendedAmountCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = 1

                                Dim GetLineQuantityStatement As String = "SELECT Quantity FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                                Dim GetLineQuantityCommand As New SqlCommand(GetLineQuantityStatement, con)
                                GetLineQuantityCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                GetLineQuantityCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = 1

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetExtendedAmount = CDbl(GetExtendedAmountCommand.ExecuteScalar)
                                Catch ex1 As Exception
                                    GetExtendedAmount = 0
                                End Try
                                Try
                                    GetLineQuantity = CDbl(GetLineQuantityCommand.ExecuteScalar)
                                Catch ex1 As Exception
                                    GetLineQuantity = 0
                                End Try
                                con.Close()

                                NewExtendedAmount = GetExtendedAmount + RoundingAmount
                                NewExtendedAmount = Math.Round(NewExtendedAmount, 2)

                                If GetLineQuantity = 0 Then
                                    NewPrice = 0
                                Else
                                    NewPrice = NewExtendedAmount / GetLineQuantity
                                    NewPrice = Math.Round(NewPrice, 5)
                                End If

                                If GetExtendedAmount > 0 And NewExtendedAmount < 0 Then
                                    MsgBox("Cannot round this line. It will create a negative amount.", MsgBoxStyle.OkOnly)
                                    Exit Sub
                                End If

                                'Update Line Database Table
                                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = @ExtendedAmount, UnitCost = @UnitCost WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)
                                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                cmd.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = 1
                                cmd.Parameters.Add("@ExtendedAmount", SqlDbType.VarChar).Value = NewExtendedAmount
                                cmd.Parameters.Add("@UnitCost", SqlDbType.VarChar).Value = NewPrice

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                Dim SUMNewExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                                Dim SUMNewExtendedAmountCommand As New SqlCommand(SUMNewExtendedAmountStatement, con)
                                SUMNewExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    SUMNewExtendedAmount = CDbl(SUMNewExtendedAmountCommand.ExecuteScalar)
                                Catch ex1 As Exception
                                    SUMNewExtendedAmount = 0
                                End Try
                                con.Close()

                                SUMNewExtendedAmount = Math.Round(SUMNewExtendedAmount, 2)

                                'Update Header Database Table
                                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = SUMNewExtendedAmount
                                cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = Val(txtInvoiceAmount.Text)

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                ShowVoucherLines()
                                LoadVoucherTotals()
                            ElseIf button1 = DialogResult.No Then
                                cmdClear.Focus()
                            End If
                        End If
                        '***********************************************************************************************
                        'UPDATE Receiving Line Table
                        For Each row As DataGridViewRow In dgvVoucherLines.Rows
                            Try
                                CheckReceiverNumber = row.Cells("ReceiverNumberColumn").Value
                            Catch ex2 As Exception
                                CheckReceiverNumber = 0
                            End Try
                            Try
                                CheckReceiverLine = row.Cells("ReceiverLineColumn").Value
                            Catch ex2 As Exception
                                CheckReceiverLine = 0
                            End Try
                            Try
                                CheckPartNumber = row.Cells("PartNumberColumn").Value
                            Catch ex2 As Exception
                                CheckPartNumber = ""
                            End Try

                            'Extract data from Receiving Line Query
                            Dim SelectPOLineStatement As String = "SELECT POLineNumber FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND PartNumber = @PartNumber AND ReceivingLineKey = @ReceivingLineKey"
                            Dim SelectPOLineCommand As New SqlCommand(SelectPOLineStatement, con)
                            SelectPOLineCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            SelectPOLineCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                            SelectPOLineCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                SelectPOLine = CInt(SelectPOLineCommand.ExecuteScalar)
                            Catch ex1 As Exception
                                SelectPOLine = 0
                            End Try
                            con.Close()

                            'Get Total Amount Received
                            Dim TotalReceiverQuantityStatement As String = "SELECT QuantityReceived FROM ReceivingLineQuery1 WHERE PONumber = @PONumber AND PartNumber = @PartNumber AND POLineNumber = @POLineNumber"
                            Dim TotalReceiverQuantityCommand As New SqlCommand(TotalReceiverQuantityStatement, con)
                            TotalReceiverQuantityCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                            TotalReceiverQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                            TotalReceiverQuantityCommand.Parameters.Add("@POLineNumber", SqlDbType.VarChar).Value = SelectPOLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                TotalReceiverQuantity = CDbl(TotalReceiverQuantityCommand.ExecuteScalar)
                            Catch ex1 As Exception
                                TotalReceiverQuantity = 0
                            End Try
                            con.Close()

                            'Get Total Amount Vouched
                            Dim TotalQuantityVouchedStatement As String = "SELECT QuantityVouched FROM ReceiverVoucherSummary WHERE ReceiverNumber = @ReceiverNumber AND PartNumber = @PartNumber AND ReceiverLine = @ReceiverLine"
                            Dim TotalQuantityVouchedCommand As New SqlCommand(TotalQuantityVouchedStatement, con)
                            TotalQuantityVouchedCommand.Parameters.Add("@ReceiverNumber", SqlDbType.VarChar).Value = CheckReceiverNumber
                            TotalQuantityVouchedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                            TotalQuantityVouchedCommand.Parameters.Add("@ReceiverLine", SqlDbType.VarChar).Value = CheckReceiverLine

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                TotalQuantityVouched = CDbl(TotalQuantityVouchedCommand.ExecuteScalar)
                            Catch ex1 As Exception
                                TotalQuantityVouched = 0
                            End Try
                            con.Close()

                            If TotalQuantityVouched < TotalReceiverQuantity Then
                                'Update Receiving Line table to show line received
                                cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                'Update Header Table
                                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                                    .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Else
                                'Update Receiving Line table to show line received
                                cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If
                        Next
                        '***********************************************************************************************
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

                        'Determine if manual discount amount
                        If chkManualDiscount.Checked = True Then
                            DiscountAmount = Val(txtTermDiscount.Text)
                        Else
                            DiscountAmount = DiscountPercent * ProductTotal
                        End If

                        ProductTotal = SUMExtendedAmount
                        InvoiceTotal = ProductTotal + SalesTaxTotal + FreightTotal

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

                        txtFreightTotal.Text = FormatCurrency(FreightTotal, 2)
                        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
                        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                        txtSalesTaxTotal.Text = FormatCurrency(SalesTaxTotal, 2)
                        txtTermDiscount.Text = DiscountAmount
                    Catch ex As Exception
                        'Error Log

                    End Try

                    'Update Batch Header Total
                    UpdateBatchTotal()
                    ClearOnLoad()
                    ClearVariables()

                    GlobalAPPONumber = 0
                    GlobalVoucherNumber = 0

                    GlobalAPDivisionID = txtDivisionID.Text
                    GlobalAPBatchNumber = txtBatchNumber.Text

                    Dim NewAPProcessBatch As New APProcessBatch
                    NewAPProcessBatch.Show()

                    Me.Dispose()
                    Me.Close()
                End If
            Else
                MsgBox("This Invoice Number has already been used or is blank.", MsgBoxStyle.OkOnly)
                txtInvoiceNumber.Focus()
            End If
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
                MsgBox("Voucher cannot be deleted at this time.", MsgBoxStyle.OkOnly)
            Else
                'Get Receiving Number and Line from datagrid
                Dim ReceiverNumber, ReceivingLineNumber As Integer
                ReceiverNumber = 0
                ReceivingLineNumber = 0

                'Get Receiver Number if it exists in Line Table
                For Each row As DataGridViewRow In dgvVoucherLines.Rows
                    Try
                        ReceiverNumber = row.Cells("ReceiverNumberColumn").Value
                    Catch ex As Exception
                        ReceiverNumber = 0
                    End Try
                    Try
                        ReceivingLineNumber = row.Cells("ReceiverLineColumn").Value
                    Catch ex As Exception
                        ReceivingLineNumber = 0
                    End Try

                    If ReceiverNumber = 0 Then
                        'Change Status of Receiving Line and Receiving Header Table, if necessary
                        Dim DeleteReferenceNumberStatement As String = "SELECT DeleteReferenceNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                        Dim DeleteReferenceNumberCommand As New SqlCommand(DeleteReferenceNumberStatement, con)
                        DeleteReferenceNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        DeleteReferenceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            DeleteReferenceNumber = CInt(DeleteReferenceNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            DeleteReferenceNumber = 1
                        End Try
                        con.Close()

                        cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = DeleteReferenceNumber
                        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = DeleteReferenceNumber
                        cmd.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        Try
                            'Update Receiving Line Table
                            cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                                .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = ReceivingLineNumber
                                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            Dim ErrorVoucherNumber As Integer
                            Dim strErrorVoucherNumber As String

                            ErrorVoucherNumber = Val(cboVoucherNumber.Text)
                            strErrorVoucherNumber = CStr(ErrorVoucherNumber)

                            ErrorDate = Today.ToShortDateString()
                            ErrorDescription = "AP Receipt of Invoice"
                            ErrorUser = EmployeeLoginName
                            ErrorComment = "Receiver line not reset on exit"
                            ErrorDivision = txtDivisionID.Text
                            ErrorReferenceNumber = "Voucher # - " + strErrorVoucherNumber

                            TFPErrorLogUpdate()
                        End Try

                        Try
                            'Update Receiving Header Table
                            cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            Dim ErrorVoucherNumber As Integer
                            Dim strErrorVoucherNumber As String

                            ErrorVoucherNumber = Val(cboVoucherNumber.Text)
                            strErrorVoucherNumber = CStr(ErrorVoucherNumber)

                            ErrorDate = Today.ToShortDateString()
                            ErrorDescription = "AP Receipt of Invoice"
                            ErrorUser = EmployeeLoginName
                            ErrorComment = "Receiver header not reset on exit"
                            ErrorDivision = txtDivisionID.Text
                            ErrorReferenceNumber = "Voucher # - " + strErrorVoucherNumber

                            TFPErrorLogUpdate()
                        End Try
                    End If
                Next

                'Create command to save data from text boxes
                cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Update Batch Header Total
                UpdateBatchTotal()
                ClearOnLoad()
                ClearVariables()

                GlobalAPPONumber = 0
                GlobalVoucherNumber = 0

                GlobalAPDivisionID = txtDivisionID.Text
                GlobalAPBatchNumber = txtBatchNumber.Text
                Dim NewAPProcessBatch As New APProcessBatch
                NewAPProcessBatch.Show()

                Me.Dispose()
                Me.Close()
            End If
        End If
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

    Private Sub cmdEnterLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterLine.Click
        If cboDebitAccount.Text = "" Then
            MsgBox("Select GL Accounts for Voucher Line", MsgBoxStyle.OkOnly)
        Else
            If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
                MsgBox("You must have a valid Voucher Number and Invoice Number.", MsgBoxStyle.OkOnly)
                cboVoucherNumber.Focus()
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
                '**********************************************************************************************************
                'Validate Part Number
                Dim ValidatePart As Integer = 0

                Dim ValidatePartStatement As String = "SELECT COUNT(ItemID) FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim ValidatePartCommand As New SqlCommand(ValidatePartStatement, con)
                ValidatePartCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                ValidatePartCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ValidatePart = CInt(ValidatePartCommand.ExecuteScalar)
                Catch ex As Exception
                    ValidatePart = 0
                End Try
                con.Close()

                If ValidatePart = 0 Then
                    MsgBox("Part # does not exist in the Non-Inventory Item List", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '**********************************************************************************************************
                'Validate GL Account
                Dim ValidateGLAccount As Integer = 0

                Dim ValidateGLAccountStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
                Dim ValidateGLAccountCommand As New SqlCommand(ValidateGLAccountStatement, con)
                ValidateGLAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboDebitAccount.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ValidateGLAccount = CInt(ValidateGLAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    ValidateGLAccount = 0
                End Try
                con.Close()

                If ValidateGLAccount = 0 Then
                    MsgBox("GL Account does not exist.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '**********************************************************************************************************
                If CheckVoucherStatus <> "OPEN" Then
                    MsgBox("Lines cannot be added.", MsgBoxStyle.OkOnly)
                Else
                    'Verify that Invoice Number is Unique
                    VerifyUniqueInvoiceNumber()

                    If UniqueInvoice = "YES" Then
                        If Val(txtUnitCost.Text) < 0 Then
                            MsgBox("Unit Cost must be a positive number. For a negative value, set quantity to a negative.", MsgBoxStyle.OkOnly)
                            Exit Sub
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
                        'Make sure that Discount Date is not changed for N30
                        VerifyDiscount()

                        If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                            DiscountDate = dtpDueDateDD.Text
                            dtpDiscountDateDD.Text = DiscountDate
                        Else
                            DiscountDate = dtpDiscountDateDD.Text
                        End If
                        '************************************************************************************************************************************************
                        Try
                            'UPDATE Data in Voucher Header Table (Batch Line)
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

                        Try
                            'Write Data to Voucher Line Database Table
                            cmd = New SqlCommand("Insert Into ReceiptOfInvoiceVoucherLines(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine, DivisionID)Values(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice, @ReceiverNumber, @ReceiverLine, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@VoucherLine", SqlDbType.VarChar).Value = NextLineNumber
                                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                                .Add("@PartDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
                                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                                .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
                                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtExtendedAmount.Text)
                                .Add("@GLDebitAccount", SqlDbType.VarChar).Value = cboDebitAccount.Text
                                .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "20000"
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
                                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                                .Add("@PartDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
                                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                                .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
                                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtExtendedAmount.Text)
                                .Add("@GLDebitAccount", SqlDbType.VarChar).Value = cboDebitAccount.Text
                                .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "20000"
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

                        'Determine if manual discount amount
                        If chkManualDiscount.Checked = True Then
                            DiscountAmount = Val(txtTermDiscount.Text)
                        Else
                            DiscountAmount = DiscountPercent * ProductTotal
                        End If

                        ProductTotal = SUMExtendedAmount
                        InvoiceTotal = ProductTotal + SalesTaxTotal + FreightTotal

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

                        txtFreightTotal.Text = FreightTotal
                        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
                        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                        txtSalesTaxTotal.Text = SalesTaxTotal
                        txtTermDiscount.Text = DiscountAmount

                        'Clear fields for next line entry
                        cboPartNumber.SelectedIndex = -1
                        txtLongDescription.Clear()
                        txtQuantity.Clear()
                        txtUnitCost.Clear()
                        txtExtendedAmount.Clear()
                        cboDebitAccount.SelectedIndex = -1
                        tabVoucherLines.SelectedIndex = 0
                        cboPartNumber.Focus()
                    Else
                        MsgBox("This Invoice Number has already been used.", MsgBoxStyle.OkOnly)
                        txtInvoiceNumber.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboPartNumber.SelectedIndex = -1
        txtLongDescription.Clear()
        txtExtendedAmount.Clear()
        txtQuantity.Clear()
        txtUnitCost.Clear()
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1
        cboPartNumber.Focus()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearOnLoad()
        ClearDataInDatagrid()
        LoadVoucher()
        LoadVendor()
    End Sub

    'Menu Strip Routines

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        cmdClearAll_Click(sender, e)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub UploadPackingSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadPackingSlipToolStripMenuItem.Click
        Dim psUpload As New PackingSlipScannerUploadAPI(New Windows.Forms.Button(), New Windows.Forms.Control(dgvVoucherLines.Rows(dgvVoucherLines.SelectedCells(0).RowIndex).Cells("ReceiverNumberColumn").Value), New Windows.Forms.ToolStripMenuItem(), Me, AppendUploadedPackingSlipToolStripMenuItem)
        psUpload.UploadPackingSlip()
        CheckPackingSlipUpload()
        Me.BringToFront()
    End Sub

    Private Sub ReUploadPackingSlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReUploadPackingSlipToolStripMenuItem.Click
        Dim psUpload As New PackingSlipScannerUploadAPI(New Windows.Forms.Button(), New Windows.Forms.Control(dgvVoucherLines.Rows(dgvVoucherLines.SelectedCells(0).RowIndex).Cells("ReceiverNumberColumn").Value), New Windows.Forms.ToolStripMenuItem(), Me, AppendUploadedPackingSlipToolStripMenuItem)
        psUpload.ReUploadPackingSlip()
        CheckPackingSlipUpload()
        Me.BringToFront()
    End Sub

    'Date Routines

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
        dtpDiscountDate.Text = dtpDiscountDateDD.Value.ToShortDateString()
    End Sub

    Private Sub dtpReceiptDateDD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReceiptDateDD.ValueChanged
        dtpReceiptDate.Text = dtpReceiptDateDD.Value.ToShortDateString()
    End Sub

    Private Sub dtpDueDateDD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDueDateDD.ValueChanged
        dtpDueDate.Text = dtpDueDateDD.Value.ToShortDateString()
    End Sub

    Private Sub dtpDueDate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDueDate.Enter
        dtpDueDate.Text = usefulFunctions.formatDate(dtpDueDate.Text)
        dtpDueDate.Select(0, 2)
    End Sub

    Private Sub dtpDueDate_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtpDueDate.MouseClick
        selectDTPLocation(dtpDueDate)
    End Sub

    'Miscellaneous Routines

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

    Private Sub APReceiptOfInvoice_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Private Sub chkManualDiscount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManualDiscount.CheckedChanged
        If chkManualDiscount.Checked = True Then
            txtTermDiscount.Enabled = True
        Else
            txtTermDiscount.Enabled = False
        End If
    End Sub

    Private Sub llVendorID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llVendorID.LinkClicked
        gpxVoucherHeader.Visible = False
        gpxVendorAddress.Visible = True

        LoadRemitToAddress()
    End Sub

    Private Sub CheckPackingSlipUpload()
        If dgvVoucherLines.SelectedCells.Count > 0 AndAlso dgvVoucherLines.SelectedCells(0).RowIndex >= 0 Then
            Dim fls As IO.FileInfo() = dir.GetFiles(dgvVoucherLines.Rows(dgvVoucherLines.SelectedCells(0).RowIndex).Cells("ReceiverNumberColumn").Value.ToString + ".pdf")
            If fls.Length > 0 Then
                cmdViewPackingSlip.Enabled = True
                UploadPackingSlipToolStripMenuItem.Enabled = False
                ReUploadPackingSlipToolStripMenuItem.Enabled = True
            Else
                cmdViewPackingSlip.Enabled = False
                UploadPackingSlipToolStripMenuItem.Enabled = True
                ReUploadPackingSlipToolStripMenuItem.Enabled = False
            End If
        Else
            cmdViewPackingSlip.Enabled = False
            UploadPackingSlipToolStripMenuItem.Enabled = True
            ReUploadPackingSlipToolStripMenuItem.Enabled = False
        End If
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

    Private Sub cboPONumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPONumber.SelectedIndexChanged
        LoadFreightTotals()
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
End Class