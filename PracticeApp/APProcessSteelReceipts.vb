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
Public Class APProcessSteelReceipts
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim NewCurrentYear, NewCurrentMonth, CurrentDay, CurrentMonth, CurrentYear, DeleteReferenceNumber, DiscountDays, DueDays, SteelPONumber, ReceiverNumber, counter, LastVoucherNumber, NextVoucherNumber, LastBatchNumber, NextBatchNumber As Integer
    Dim DueDateStr, Comment, VoucherStatus, VoucherSource, GLCreditAccount, GLDebitAccount, PartDescription, PartGLAccount, VendorName, BatchDate, BatchDescription, DivisionID, InvoiceNumber, InvoiceDate, VendorID, ReceiptDate, PaymentTerms, PaymentTerms1, DiscountDate As String
    Dim DiscountAmount, DiscountPercent, BatchAmount, ProductTotal, FreightTotal, SalesTaxTotal, InvoiceTotal, VoucherQuantity, Quantity, InvoiceManualTotal As Double
    Dim InvoiceAmount, SUMInvoiceTotal, SUMExtendedAmount, ExtendedAmount, UnitCost, UndistributedAmount, CurrentAmount, BatchCurrentAmount As Double
    Dim NewDueDate, InvoiceDate1, DueDate, DiscountDate1 As Date
    Dim ManualDiscountSelected, OnHoldStatus, VendorClass, VoucherPartNumber, UniqueInvoice, GLDescription As String
    Dim SelectPOLine, LastLineNumber, NextLineNumber, TempVoucherLine As Integer
    Dim GetExtendedAmount, RoundingAmount, ADDUnitCost, ADDExtendedAmount As Double
    Dim TotalQuantityVouched, TotalReceiverQuantity, ADDQuantity, CheckQuantity As Double
    Dim VendorCheckType, VendorAddress1, VendorAddress2, VendorCity, VendorState, VendorZip, VendorCountry As String
    Dim CheckReceiverLine, CheckReceiverNumber As Integer
    Dim CheckPartNumber, CheckVoucherStatus As String
    Dim CheckUnitCost As Double = 0
    Dim CheckType As String = ""
    Dim ValidateCheckType As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    'Form Functions

    Private Sub APProcessSteelReceipts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()

        'Load default from Batch Form
        txtDivisionID.Text = GlobalAPDivisionID
        txtBatchNumber.Text = GlobalAPBatchNumber

        LoadVendor()
        LoadVoucher()
        LoadNoninventoryItems()
        LoadGLAccounts()
        LoadPaymentTerms()
        ClearOnLoad()

        If GlobalVoucherNumber > 0 Then
            txtBatchNumber.Text = GlobalAPBatchNumber
            cboVoucherNumber.Text = GlobalVoucherNumber
            txtSteelPONumber.Text = GlobalAPPONumber
            LoadVoucherData()
            LoadVoucherTotals()
        Else
            cboVoucherNumber.SelectedIndex = -1
        End If

        ShowVoucherLines()
    End Sub

    Private Sub APProcessSteelReceipts_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    'Load dataset into controls

    Public Sub ShowVoucherLines()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber", con)
        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceiptOfInvoiceVoucherLines")
        dgvVoucherLines.DataSource = ds.Tables("ReceiptOfInvoiceVoucherLines")
        cboDeleteLine.DataSource = ds.Tables("ReceiptOfInvoiceVoucherLines")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvVoucherLines.DataSource = Nothing
    End Sub

    Public Sub LoadVendor()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass = @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
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
        cmd.Parameters.Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL RECEIPT"
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

    Public Sub LoadSteelBOLNumber()
        'Load Voucher Number for specific division
        cmd = New SqlCommand("SELECT DISTINCT (SteelBOLNumber) FROM SteelReceivingLineQuery2 WHERE SteelVendor = @SteelVendor AND DivisionID = @DivisionID AND SelectForInvoice = @SelectForInvoice ORDER BY SteelBOLNumber DESC", con)
        cmd.Parameters.Add("@SteelVendor", SqlDbType.VarChar).Value = cboVendorID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "SteelReceivingLineQuery2")
        cboBOL.DataSource = ds6.Tables("SteelReceivingLineQuery2")
        con.Close()
        cboBOL.SelectedIndex = -1
    End Sub

    Public Sub LoadPaymentTerms()
        'Load Voucher Number for specific division
        cmd = New SqlCommand("SELECT PmtTermsID FROM PaymentTerms", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "PaymentTerms")
        cboPaymentTerms.DataSource = ds7.Tables("PaymentTerms")
        con.Close()
        cboPaymentTerms.SelectedIndex = -1
    End Sub

    'Load data function

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
        InvoiceDate1 = dtpInvoiceDate.Text

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

            dtpDueDate.Text = NewDueDate
            dtpDiscountDate.Text = NewDueDate
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

            dtpDueDate.Text = NewDueDate
            dtpDiscountDate.Text = NewDueDate
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

            dtpDueDate.Text = NewDueDate
            dtpDiscountDate.Text = NewDueDate
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

            dtpDueDate.Text = NewDueDate
            dtpDiscountDate.Text = NewDueDate
        Else
            If DiscountDays = 0 Then
                DiscountDays = DueDays
            Else
                'Do nothing
            End If

            DueDate = InvoiceDate1.AddDays(DueDays)
            DiscountDate1 = InvoiceDate1.AddDays(DiscountDays)

            dtpDiscountDate.Text = DiscountDate1
            dtpDueDate.Text = DueDate
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
            cboCheckType.SelectedIndex = -1

            VendorAddress1 = ""
            VendorAddress2 = ""
            VendorCity = ""
            VendorState = ""
            VendorZip = ""
            VendorCountry = ""
            VendorCheckType = ""

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

            Dim VendorCheckTypeStatement As String = "SELECT CheckCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VendorCheckTypeCommand As New SqlCommand(VendorCheckTypeStatement, con)
            VendorCheckTypeCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
            VendorCheckTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

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
            Try
                VendorCheckType = CStr(VendorCheckTypeCommand.ExecuteScalar)
            Catch ex As Exception
                VendorCheckType = "STANDARD"
            End Try
            con.Close()

            txtRemitToAddress1.Text = VendorAddress1
            txtRemitToAddress2.Text = VendorAddress2
            txtRemitToCity.Text = VendorCity
            txtRemitToCountry.Text = VendorCountry
            txtRemitToZip.Text = VendorZip
            txtRemitToState.Text = VendorState
            cboCheckType.Text = VendorCheckType
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
    End Sub

    Public Sub LoadVoucherData()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PONumber")) Then
                SteelPONumber = 0
            Else
                SteelPONumber = reader.Item("PONumber")
            End If
            If IsDBNull(reader.Item("InvoiceNumber")) Then
                InvoiceNumber = ""
            Else
                InvoiceNumber = reader.Item("InvoiceNumber")
            End If
            If IsDBNull(reader.Item("InvoiceDate")) Then
                InvoiceDate = Now
            Else
                InvoiceDate = reader.Item("InvoiceDate")
            End If
            If IsDBNull(reader.Item("ReceiptDate")) Then
                ReceiptDate = Now
            Else
                ReceiptDate = reader.Item("ReceiptDate")
            End If
            If IsDBNull(reader.Item("VendorID")) Then
                VendorID = ""
            Else
                VendorID = reader.Item("VendorID")
            End If
            If IsDBNull(reader.Item("ProductTotal")) Then
                ProductTotal = 0
            Else
                ProductTotal = reader.Item("ProductTotal")
            End If
            If IsDBNull(reader.Item("InvoiceFreight")) Then
                FreightTotal = 0
            Else
                FreightTotal = reader.Item("InvoiceFreight")
            End If
            If IsDBNull(reader.Item("InvoiceSalesTax")) Then
                SalesTaxTotal = 0
            Else
                SalesTaxTotal = reader.Item("InvoiceSalesTax")
            End If
            If IsDBNull(reader.Item("InvoiceTotal")) Then
                InvoiceTotal = 0
            Else
                InvoiceTotal = reader.Item("InvoiceTotal")
            End If
            If IsDBNull(reader.Item("PaymentTerms")) Then
                PaymentTerms = ""
            Else
                PaymentTerms = reader.Item("PaymentTerms")
            End If
            If IsDBNull(reader.Item("DiscountDate")) Then
                DiscountDate = Now
            Else
                DiscountDate = reader.Item("DiscountDate")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                Comment = ""
            Else
                Comment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("DueDate")) Then
                DueDate = Now
            Else
                DueDate = reader.Item("DueDate")
            End If
            If IsDBNull(reader.Item("DiscountAmount")) Then
                DiscountAmount = 0
            Else
                DiscountAmount = reader.Item("DiscountAmount")
            End If
            If IsDBNull(reader.Item("VoucherStatus")) Then
                VoucherStatus = ""
            Else
                VoucherStatus = reader.Item("VoucherStatus")
            End If
            If IsDBNull(reader.Item("VoucherSource")) Then
                VoucherSource = ""
            Else
                VoucherSource = reader.Item("VoucherSource")
            End If
            If IsDBNull(reader.Item("InvoiceAmount")) Then
                InvoiceAmount = 0
            Else
                InvoiceAmount = reader.Item("InvoiceAmount")
            End If
            If IsDBNull(reader.Item("CheckType")) Then
                CheckType = "STANDARD"
            Else
                CheckType = reader.Item("CheckType")
            End If
            If IsDBNull(reader.Item("ManualDiscountSelected")) Then
                ManualDiscountSelected = "NO"
            Else
                ManualDiscountSelected = reader.Item("ManualDiscountSelected")
            End If
        Else
            SteelPONumber = 0
            InvoiceNumber = ""
            InvoiceDate = Now
            ReceiptDate = Now
            VendorID = ""
            ProductTotal = 0
            FreightTotal = 0
            SalesTaxTotal = 0
            InvoiceTotal = 0
            PaymentTerms = ""
            DiscountDate = Now
            Comment = ""
            DueDate = Now
            DiscountAmount = 0
            VoucherStatus = ""
            VoucherSource = ""
            InvoiceAmount = 0
            CheckType = "STANDARD"
            ManualDiscountSelected = "NO"
        End If
        reader.Close()
        con.Close()

        cboVendorID.Text = VendorID
        cboPaymentTerms.Text = PaymentTerms
        cboCheckType.Text = CheckType

        If ManualDiscountSelected = "YES" Then
            chkManualDiscount.Checked = True
        Else
            chkManualDiscount.Checked = False
        End If

        txtInvoiceAmount.Text = InvoiceAmount
        txtComment.Text = Comment
        txtFreightTotal.Text = FreightTotal
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal)
        txtInvoiceNumber.Text = InvoiceNumber
        txtPurchaseTotal.Text = FormatCurrency(ProductTotal)
        txtSalesTaxTotal.Text = SalesTaxTotal
        txtTermDiscount.Text = DiscountAmount
        txtSteelPONumber.Text = SteelPONumber

        dtpInvoiceDate.Text = InvoiceDate
        dtpDueDate.Text = DueDate
        dtpReceiptDate.Text = ReceiptDate
        dtpDiscountDate.Text = DiscountDate
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

        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = SUMInvoiceTotal

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub LoadSteelPONumberForBOL()
        Dim SteelPONumberStatement As String = "SELECT PONumber FROM SteelReceivingLineQuery WHERE SteelBOLNumber = @SteelBOLNumber"
        Dim SteelPONumberCommand As New SqlCommand(SteelPONumberStatement, con)
        SteelPONumberCommand.Parameters.Add("@SteelBOLNumber", SqlDbType.VarChar).Value = cboBOL.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelPONumber = CInt(SteelPONumberCommand.ExecuteScalar)
        Catch ex As Exception
            SteelPONumber = 0
        End Try
        con.Close()

        txtSteelPONumber.Text = SteelPONumber
    End Sub

    Public Sub LoadItemDescription()
        Dim PartDescriptionStatement As String = "SELECT ShortDescription FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescriptionCommand As New SqlCommand(PartDescriptionStatement, con)
        PartDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim PartGLAccountStatement As String = "SELECT GLDebitAccount FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartGLAccountCommand As New SqlCommand(PartGLAccountStatement, con)
        PartGLAccountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartGLAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            PartDescription = ""
        End Try
        Try
            PartGLAccount = CStr(PartGLAccountCommand.ExecuteScalar)
        Catch ex As Exception
            PartGLAccount = ""
        End Try
        con.Close()

        txtLongDescription.Text = PartDescription
        cboDebitAccount.Text = PartGLAccount
    End Sub

    Public Sub LoadVoucherTotals()
        'Calculate the totals from the lines selected
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        Dim InvoiceFreightStatement As String = "SELECT InvoiceFreight FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim InvoiceFreightCommand As New SqlCommand(InvoiceFreightStatement, con)
        InvoiceFreightCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        Dim InvoiceSalesTaxStatement As String = "SELECT InvoiceSalesTax FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim InvoiceSalesTaxCommand As New SqlCommand(InvoiceSalesTaxStatement, con)
        InvoiceSalesTaxCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        Dim InvoiceTotalStatement As String = "SELECT InvoiceTotal FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim InvoiceTotalCommand As New SqlCommand(InvoiceTotalStatement, con)
        InvoiceTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        Dim InvoiceAmountStatement As String = "SELECT InvoiceAmount FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim InvoiceAmountCommand As New SqlCommand(InvoiceAmountStatement, con)
        InvoiceAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        Dim DiscountAmountStatement As String = "SELECT DiscountAmount FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim DiscountAmountCommand As New SqlCommand(DiscountAmountStatement, con)
        DiscountAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        Dim ManualDiscountSelectedStatement As String = "SELECT ManualDiscountSelected FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim ManualDiscountSelectedCommand As New SqlCommand(ManualDiscountSelectedStatement, con)
        ManualDiscountSelectedCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
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
            InvoiceAmount = CDbl(InvoiceAmountCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceAmount = 0
        End Try
        Try
            DiscountAmount = CDbl(DiscountAmountCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountAmount = 0
        End Try
        Try
            ManualDiscountSelected = CStr(ManualDiscountSelectedCommand.ExecuteScalar)
        Catch ex As Exception
            ManualDiscountSelected = "NO"
        End Try
        con.Close()

        If ManualDiscountSelected = "YES" Then
            chkManualDiscount.Checked = True
        Else
            chkManualDiscount.Checked = False
        End If

        ProductTotal = Math.Round(ProductTotal, 2)
        FreightTotal = Math.Round(FreightTotal, 2)
        SalesTaxTotal = Math.Round(SalesTaxTotal, 2)
        DiscountAmount = Math.Round(DiscountAmount, 2)

        txtFreightTotal.Text = FreightTotal
        txtSalesTaxTotal.Text = SalesTaxTotal
        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtInvoiceAmount.Text = InvoiceAmount
    End Sub

    Public Sub ReLoadVoucherTotals()
        'Calculate the totals from the lines selected
        Dim PurchaseTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim PurchaseTotalCommand As New SqlCommand(PurchaseTotalStatement, con)
        PurchaseTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(PurchaseTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        con.Close()

        If chkManualDiscount.Checked = True Then
            DiscountAmount = Val(txtTermDiscount.Text)
        Else
            DiscountAmount = DiscountPercent * ProductTotal
        End If

        FreightTotal = Val(txtFreightTotal.Text)
        SalesTaxTotal = Val(txtSalesTaxTotal.Text)


        ProductTotal = Math.Round(ProductTotal, 2)
        FreightTotal = Math.Round(FreightTotal, 2)
        SalesTaxTotal = Math.Round(SalesTaxTotal, 2)
        DiscountAmount = Math.Round(DiscountAmount, 2)

        InvoiceTotal = ProductTotal + FreightTotal + SalesTaxTotal
        txtPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtTermDiscount.Text = DiscountAmount
    End Sub

    'Save Functions

    Public Sub InsertROIDatabase()
        'Write Data to Batch Line (Voucher) Database Table
        cmd = New SqlCommand("Insert Into ReceiptOfInvoiceBatchLine(VoucherNumber, BatchNumber, PONumber,InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, VendorClass, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, InvoiceAmount, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, DeleteReferenceNumber, OnHold, WhitePaper, CheckType, TempSelected, SelectedInDatagrid, ManualDiscountSelected)Values(@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @VendorID, @VendorClass, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @InvoiceAmount, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @DeleteReferenceNumber, @OnHold, @WhitePaper, @CheckType, @TempSelected, @SelectedInDatagrid, @ManualDiscountSelected)", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(txtSteelPONumber.Text)
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
            .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = FreightTotal
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = SalesTaxTotal
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtInvoiceAmount.Text)
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
            .Add("@DiscountDate", SqlDbType.VarChar).Value = DiscountDate
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
            .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtTermDiscount.Text)
            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL RECEIPT"
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = 0
            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
            .Add("@WhitePaper", SqlDbType.VarChar).Value = "NO"
            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
            .Add("@TempSelected", SqlDbType.VarChar).Value = ""
            .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
            .Add("@ManualDiscountSelected", SqlDbType.VarChar).Value = "NO"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub UpdateROIToDatabase()
        'See if Discount Check Box is checked
        Dim IsDiscountSelected As String = ""

        If chkManualDiscount.Checked = True Then
            IsDiscountSelected = "YES"
        Else
            IsDiscountSelected = "NO"
        End If

        ReLoadVoucherTotals()

        'UPDATE Data in Voucher Header Table (Batch Line)
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET PONumber = @PONumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, VendorClass = @VendorClass, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, DeleteReferenceNumber = @DeleteReferenceNumber, OnHold = @OnHold, WhitePaper = @WhitePaper, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, ManualDiscountSelected = @ManualDiscountSelected WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(txtSteelPONumber.Text)
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
            .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = FreightTotal
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = SalesTaxTotal
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtInvoiceAmount.Text)
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
            .Add("@DiscountDate", SqlDbType.VarChar).Value = DiscountDate
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
            .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtTermDiscount.Text)
            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL RECEIPT"
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = 0
            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
            .Add("@WhitePaper", SqlDbType.VarChar).Value = "NO"
            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
            .Add("@TempSelected", SqlDbType.VarChar).Value = ""
            .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
            .Add("@ManualDiscountSelected", SqlDbType.VarChar).Value = IsDiscountSelected
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Validation, clear, and error-checking

    Public Sub ClearOnLoad()
        'Clear Invoice Header
        cboPartNumber.Text = ""
        cboPaymentTerms.Text = ""
        cboBOL.Text = ""
        cboVendorID.Text = ""
        cboVoucherNumber.Text = ""

        cboPaymentTerms.Refresh()
        cboBOL.Refresh()
        cboVoucherNumber.Refresh()
        cboVendorID.Refresh()
        cboPartNumber.Refresh()
        cboCheckType.Refresh()

        cboPaymentTerms.SelectedIndex = -1
        cboBOL.SelectedIndex = -1
        cboVoucherNumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1
        cboCheckType.SelectedIndex = -1

        dtpDiscountDate.Text = ""
        dtpInvoiceDate.Text = ""
        dtpReceiptDate.Text = ""

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
        txtSteelPONumber.Refresh()

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
        txtRemitToZip.Clear()
        txtRemitToVendorID.Clear()
        txtRemitToVendorName.Clear()
        txtSteelPONumber.Clear()

        chkManualDiscount.Checked = False

        txtTermDiscount.Enabled = False

        If VoucherStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            cmdSelectByBOL.Enabled = False
            cmdGenerateVoucher.Enabled = False
            'SaveToolStripMenuItem.Enabled = False
            'DeleteToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            cmdSelectByBOL.Enabled = True
            cmdGenerateVoucher.Enabled = True
            'SaveToolStripMenuItem.Enabled = True
            'DeleteToolStripMenuItem.Enabled = True
        End If

        cmdGenerateVoucher.Focus()
    End Sub

    Public Sub ClearVariables()
        DeleteReferenceNumber = 0
        DiscountDays = 0
        DueDays = 0
        Quantity = 0
        SteelPONumber = 0
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
        VendorCheckType = ""
        OnHoldStatus = "NO"
        PartGLAccount = ""
        ValidateCheckType = ""
        ManualDiscountSelected = "NO"
    End Sub

    Public Sub ClearInvoice()
        'Clear Invoice Header
        cboPaymentTerms.Refresh()
        cboBOL.Refresh()
        cboVoucherNumber.Refresh()
        cboVendorID.Refresh()
        cboPartNumber.Refresh()
        cboCheckType.Refresh()

        cboPaymentTerms.SelectedIndex = -1
        cboBOL.SelectedIndex = -1
        cboVoucherNumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1
        cboCheckType.SelectedIndex = -1

        dtpDiscountDate.Text = ""
        dtpInvoiceDate.Text = ""
        dtpReceiptDate.Text = ""

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
        txtSteelPONumber.Refresh()

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
        txtSteelPONumber.Clear()

        chkManualDiscount.Checked = False

        txtTermDiscount.Enabled = False

        cboVoucherNumber.Focus()

        If VoucherStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            cmdSelectByBOL.Enabled = False
            cmdGenerateVoucher.Enabled = False
            'SaveToolStripMenuItem.Enabled = False
            'DeleteToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            cmdSelectByBOL.Enabled = True
            cmdGenerateVoucher.Enabled = True
            'SaveToolStripMenuItem.Enabled = True
            'DeleteToolStripMenuItem.Enabled = True
        End If
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Log error to error log
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

    'Datagridview Functions

    Private Sub dgvVoucherLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVoucherLines.CellValueChanged
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

    'Command Buttons

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number and a valid Invoice Number.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
            Exit Sub
        End If
        '******************************************************************************************
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

            Exit Sub
        End If
        '*******************************************************************************************
        'Verify Invoice Number
        VerifyUniqueInvoiceNumber()

        If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then
            'Make sure that Discount Date is not changed for N30
            VerifyDiscount()

            If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                DiscountDate = dtpDueDate.Text
                dtpDiscountDate.Text = DiscountDate
            Else
                DiscountDate = dtpDiscountDate.Text
            End If
            '********************************************************************************************
            'Verify that a valid PO Number is present
            If txtSteelPONumber.Text = "" Then
                Dim PONumberStatement As String = "SELECT PONumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
                Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
                PONumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SteelPONumber = CInt(PONumberCommand.ExecuteScalar)
                Catch ex As Exception
                    SteelPONumber = 0
                End Try
                con.Close()

                txtSteelPONumber.Text = SteelPONumber
            Else
                'Do nothing - valid PO
            End If
            '************************************************************************************************************************************************
            'Determine check type
            If cboCheckType.Text = "" Then
                MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                If cboCheckType.Text = "ACH" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "STANDARD" Then
                    ValidateCheckType = "OKAY"
                Else
                    ValidateCheckType = "NOT OKAY"
                End If
            End If

            If ValidateCheckType = "NOT OKAY" Then
                MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '************************************************************************************************************************************************
            Try
                'Write Data to Batch Line (Voucher) Database Table
                InsertROIDatabase()
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

                'Reload Voucher Lines in grid
                ShowVoucherLines()
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

                    'Get Total Amount Received
                    Dim TotalReceiverQuantityStatement As String = "SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND RMID = @RMID AND SteelReceivingLineKey = @SteelReceivingLineKey"
                    Dim TotalReceiverQuantityCommand As New SqlCommand(TotalReceiverQuantityStatement, con)
                    TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                    TotalReceiverQuantityCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CheckPartNumber
                    TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine

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
                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        'Update Header Table
                        cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET Status = @Status WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                            .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        'Update Receiving Line table to show line received
                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
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
                'Update Database - Header Data (Receipt Of Invoice Batch Line)
                UpdateROIToDatabase()
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

                    'Get Total Amount Received
                    Dim TotalReceiverQuantityStatement As String = "SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND RMID = @RMID AND SteelReceivingLineKey = @SteelReceivingLineKey"
                    Dim TotalReceiverQuantityCommand As New SqlCommand(TotalReceiverQuantityStatement, con)
                    TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                    TotalReceiverQuantityCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CheckPartNumber
                    TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine

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
                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        'Update Header Table
                        cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                            .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        'Update Receiving Line table to show line received
                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
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
            End Try

            GlobalVoucherNumber = Val(cboVoucherNumber.Text)
            Using NewPrintVoucher As New PrintVoucher
                Dim Result = NewPrintVoucher.ShowDialog()
            End Using
        Else
            MsgBox("This Invoice Number has already been used or is blank.", MsgBoxStyle.OkOnly)
            txtInvoiceNumber.Focus()
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboVoucherNumber.Text = "" Then
            MsgBox("You must select a valid Voucher Number to delete", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

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

                        cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = DeleteReferenceNumber
                        cmd.Parameters.Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)
                        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = DeleteReferenceNumber
                        cmd.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        Try
                            'Update Receiving Line Table
                            cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                            With cmd.Parameters
                                .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                                .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = ReceivingLineNumber
                                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
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
                            ErrorDescription = "AP Steel Receipt"
                            ErrorUser = EmployeeLoginName
                            ErrorComment = "Receiver line not reset on delete"
                            ErrorDivision = txtDivisionID.Text
                            ErrorReferenceNumber = "Voucher # - " + strErrorVoucherNumber

                            TFPErrorLogUpdate()
                        End Try

                        Try
                            'Update Receiving Header Table
                            cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                            cmd.Parameters.Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
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
                            ErrorDescription = "AP Steel Receipt"
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
                ClearInvoice()
                LoadVendor()
                LoadVoucher()
                ShowVoucherLines()
            End If
        ElseIf button = DialogResult.No Then
            cmdDelete.Focus()
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number and a valid Invoice Number.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
            Exit Sub
        End If
        '**********************************************************************************
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
            Exit Sub
        End If
        '**********************************************************************************
        'Verify Invoice Number
        VerifyUniqueInvoiceNumber()

        If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then
            'Make sure that Discount Date is not changed for N30
            VerifyDiscount()

            If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                DiscountDate = dtpDueDate.Text
                dtpDiscountDate.Text = DiscountDate
            Else
                DiscountDate = dtpDiscountDate.Text
            End If

            'Verify that a valid PO Number is present
            If txtSteelPONumber.Text = "" Then
                Dim PONumberStatement As String = "SELECT PONumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
                Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
                PONumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SteelPONumber = CInt(PONumberCommand.ExecuteScalar)
                Catch ex As Exception
                    SteelPONumber = 0
                End Try
                con.Close()

                txtSteelPONumber.Text = SteelPONumber
            Else
                'Do nothing - valid PO
            End If
            '************************************************************************************************************************************************
            'Determine check type
            If cboCheckType.Text = "" Then
                MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                If cboCheckType.Text = "ACH" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "STANDARD" Then
                    ValidateCheckType = "OKAY"
                Else
                    ValidateCheckType = "NOT OKAY"
                End If
            End If

            If ValidateCheckType = "NOT OKAY" Then
                MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '************************************************************************************************************************************************
            Try
                'Write Data to Batch Line (Voucher) Database Table
                InsertROIDatabase()
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

                MsgBox("Voucher has been created.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'Update Database - Header Data (Receipt Of Invoice Batch Line)
                UpdateROIToDatabase()
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

                    'Get Total Amount Received
                    Dim TotalReceiverQuantityStatement As String = "SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND RMID = @RMID AND SteelReceivingLineKey = @SteelReceivingLineKey"
                    Dim TotalReceiverQuantityCommand As New SqlCommand(TotalReceiverQuantityStatement, con)
                    TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                    TotalReceiverQuantityCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CheckPartNumber
                    TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine

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
                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Update Header Table
                        cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                            .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        'Update Receiving Line table to show line received
                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
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
            End Try
        Else
            MsgBox("This Invoice Number has already been used or is blank.", MsgBoxStyle.OkOnly)
            txtInvoiceNumber.Focus()
        End If
    End Sub

    Private Sub cmdEnterNewVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterNewVoucher.Click
        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number and a valid Invoice Number.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
            Exit Sub
        End If
        '*****************************************************************************************
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
            ClearVariables()
            ClearOnLoad()
            LoadVoucher()
            LoadVendor()
            ShowVoucherLines()

            Exit Sub
        End If
        '*******************************************************************************************
        'Verify Invoice Number
        VerifyUniqueInvoiceNumber()

        If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then
            'Make sure that Discount Date is not changed for N30
            VerifyDiscount()

            If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                DiscountDate = dtpDueDate.Text
                dtpDiscountDate.Text = DiscountDate
            Else
                DiscountDate = dtpDiscountDate.Text
            End If
            '************************************************************************************************************************************************
            'Determine check type
            If cboCheckType.Text = "" Then
                MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                If cboCheckType.Text = "ACH" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "STANDARD" Then
                    ValidateCheckType = "OKAY"
                Else
                    ValidateCheckType = "NOT OKAY"
                End If
            End If

            If ValidateCheckType = "NOT OKAY" Then
                MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '************************************************************************************************************************************************
            'Verify that a valid PO Number is present
            If txtSteelPONumber.Text = "" Then
                Dim PONumberStatement As String = "SELECT PONumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
                Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
                PONumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SteelPONumber = CInt(PONumberCommand.ExecuteScalar)
                Catch ex As Exception
                    SteelPONumber = 0
                End Try
                con.Close()

                txtSteelPONumber.Text = SteelPONumber
            Else
                'Do nothing - valid PO
            End If

            Try
                'Write Data to Batch Line (Voucher Header) Database Table
                InsertROIDatabase()
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

                'Reload Voucher Lines in grid
                ShowVoucherLines()
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

                    'Get Total Amount Received
                    Dim TotalReceiverQuantityStatement As String = "SELECT SUM(ReceiveQuantity) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND RMID = @RMID AND SteelReceivingLineKey = @SteelReceivingLineKey"
                    Dim TotalReceiverQuantityCommand As New SqlCommand(TotalReceiverQuantityStatement, con)
                    TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                    TotalReceiverQuantityCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CheckPartNumber
                    TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine

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
                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        'Update Header Table
                        cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                            .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        'Update Receiving Line table to show line received
                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                        With cmd.Parameters
                            .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
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

                MsgBox("Voucher has been created.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'Update Database - Header Data (Receipt Of Invoice Batch Line)
                UpdateROIToDatabase()
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
                    Catch ex1 As Exception
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

                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber", con)
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
                    Dim button2 As DialogResult = MessageBox.Show("Do you wish to round the difference?", "ROUND DIFFERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button2 = DialogResult.Yes Then

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

                        SUMNewExtendedAmount = Math.Round(SUMExtendedAmount, 2)

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
                    ElseIf button2 = DialogResult.No Then

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
                            '*******************************************************************************************************
                            'Get Total Amount Received
                            Dim TotalReceiverQuantityStatement As String = "SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND RMID = @RMID AND SteelReceivingLineKey = @SteelReceivingLineKey"
                            Dim TotalReceiverQuantityCommand As New SqlCommand(TotalReceiverQuantityStatement, con)
                            TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                            TotalReceiverQuantityCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CheckPartNumber
                            TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine

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
                                cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                                With cmd.Parameters
                                    .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Update Header Table
                                cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)

                                With cmd.Parameters
                                    .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                                    .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Else
                                'Update Receiving Line table to show line received
                                cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                                With cmd.Parameters
                                    .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                    .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If
                        Next

                        'Exit routine if no to rounding
                        Exit Sub
                    End If
                End If

                '***********************************************************************************************
                ClearVariables()
                ClearOnLoad()
                '***********************************************************************************************************

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

                'Write Data to Batch Line (Voucher Header) Database Table
                InsertROIDatabase()

                LoadVoucher()
                LoadVendor()
                ShowVoucherLines()
                cboVoucherNumber.Text = NextVoucherNumber

                cboVendorID.Focus()
            End Try
        Else
            MsgBox("This Invoice Number has already been used or is blank.", MsgBoxStyle.OkOnly)
            txtInvoiceNumber.Focus()
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearOnLoad()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If cboVoucherNumber.Text = "" Or cboDeleteLine.Text = "" Then
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
                    ReceiverNumberCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)

                    Dim ReceiverLineNumberStatement As String = "SELECT ReceiverLine FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                    Dim ReceiverLineNumberCommand As New SqlCommand(ReceiverLineNumberStatement, con)
                    ReceiverLineNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    ReceiverLineNumberCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)

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

                    If ReceiverNumber = 0 Then
                        'Skip
                    Else
                        cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)
                        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                        cmd.Parameters.Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)
                        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                        cmd.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = ReceiverLineNumber
                        cmd.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Delete Voucher
                        cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)
                        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        cmd.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                    '*******************************************************************************************************************************
                    'Check line quantities in datagrid, and delete any zero quantity lines
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)
                    cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    cmd.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)

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

    Private Sub cmdSelectByBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectByBOL.Click
        If cboVoucherNumber.Text = "" Then
            MsgBox("A valid Voucher Number must be selected to create a Voucher.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
            Exit Sub
        End If
        '**************************************************************************************
        'Verify Invoice Number
        VerifyUniqueInvoiceNumber()

        If UniqueInvoice = "YES" Then
            'Make sure that Discount Date is not changed for N30
            VerifyDiscount()

            If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                DiscountDate = dtpDueDate.Text
                dtpDiscountDate.Text = DiscountDate
            Else
                DiscountDate = dtpDiscountDate.Text
            End If
            '************************************************************************************************************************************************
            'Determine check type
            If cboCheckType.Text = "" Then
                MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                If cboCheckType.Text = "ACH" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "STANDARD" Then
                    ValidateCheckType = "OKAY"
                Else
                    ValidateCheckType = "NOT OKAY"
                End If
            End If

            If ValidateCheckType = "NOT OKAY" Then
                MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '************************************************************************************************************************************************
            Try
                'Write Data to Batch Line (Voucher) Database Table
                InsertROIDatabase()
            Catch ex As Exception
                'Update Database - Header Data (Receipt Of Invoice Batch Line)
                UpdateROIToDatabase()
            End Try

            'Declare global variables
            GlobalVoucherNumber = Val(cboVoucherNumber.Text)
            GlobalAPDivisionID = txtDivisionID.Text
            GlobalAPPONumber = Val(txtSteelPONumber.Text)
            GlobalAPBatchNumber = Val(txtBatchNumber.Text)
            GlobalAPVendorID = cboVendorID.Text
            GlobalAPSteelBOLNumber = cboBOL.Text

            'Open selection form
            Dim NewSelectSteelPOLines As New SelectSteelPOLines
            NewSelectSteelPOLines.Show()

            Me.Dispose()
            Me.Close()
        Else
            MsgBox("This Invoice Number has already been used.", MsgBoxStyle.OkOnly)
            txtInvoiceNumber.Focus()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
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
        Else
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
                        'Make sure that Discount Date is not changed for N30
                        VerifyDiscount()

                        If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                            DiscountDate = dtpDueDate.Text
                            dtpDiscountDate.Text = DiscountDate
                        Else
                            DiscountDate = dtpDiscountDate.Text
                        End If

                        'Verify that a valid PO Number is present
                        If txtSteelPONumber.Text = "" Then
                            Dim PONumberStatement As String = "SELECT PONumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
                            Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
                            PONumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                SteelPONumber = CInt(PONumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                SteelPONumber = 0
                            End Try
                            con.Close()

                            txtSteelPONumber.Text = SteelPONumber
                        Else
                            'Do nothing - valid PO
                        End If
                        '************************************************************************************************************************************************
                        'Determine check type
                        If cboCheckType.Text = "" Then
                            MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        Else
                            If cboCheckType.Text = "ACH" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "STANDARD" Then
                                ValidateCheckType = "OKAY"
                            Else
                                ValidateCheckType = "NOT OKAY"
                            End If
                        End If

                        If ValidateCheckType = "NOT OKAY" Then
                            MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        Else
                            'Continue
                        End If
                        '************************************************************************************************************************************************
                        Try
                            'Write Data to Batch Line (Voucher) Database Table
                            InsertROIDatabase()
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

                            'Reload datagrid
                            ShowVoucherLines()
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

                                'Get Total Amount Received
                                Dim TotalReceiverQuantityStatement As String = "SELECT SUM(ReceiveWeight) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND RMID = @RMID AND SteelReceivingLineKey = @SteelReceivingLineKey"
                                Dim TotalReceiverQuantityCommand As New SqlCommand(TotalReceiverQuantityStatement, con)
                                TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                TotalReceiverQuantityCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CheckPartNumber
                                TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine

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
                                    cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                                    With cmd.Parameters
                                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                        .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'Update Header Table
                                    cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                                        .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Else
                                    'Update Receiving Line table to show line received
                                    cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                                    With cmd.Parameters
                                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                        .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                End If
                            Next
                            '***********************************************************************************************
                            'Show data with re-ordered lines
                            ShowVoucherLines()
                            '*********************************************************************************************
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
                            'Update Database - Header Data (Receipt Of Invoice Batch Line)
                            UpdateROIToDatabase()
                            '************************************************************************
                            Dim CheckRoundingAmount As Double = 0
                            Dim CheckRoundingTotal As Double = 0

                            CheckRoundingAmount = Val(txtInvoiceAmount.Text)
                            CheckRoundingTotal = Math.Round(InvoiceTotal, 2)
                            CheckRoundingAmount = Math.Round(CheckRoundingAmount, 2)

                            'Check to see if rounding is needed
                            If CheckRoundingAmount = CheckRoundingTotal Then
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
                                    Exit Sub
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

                                'Get Total Amount Received
                                Dim TotalReceiverQuantityStatement As String = "SELECT SUM(ReceiveQuantity) FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND RMID = @RMID AND SteelReceivingLineKey = @SteelReceivingLineKey"
                                Dim TotalReceiverQuantityCommand As New SqlCommand(TotalReceiverQuantityStatement, con)
                                TotalReceiverQuantityCommand.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                TotalReceiverQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CheckPartNumber
                                TotalReceiverQuantityCommand.Parameters.Add("@POLineNumber", SqlDbType.VarChar).Value = CheckReceiverLine

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
                                    cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                                    With cmd.Parameters
                                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                        .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
                                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    'Update Header Table
                                    cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                                        .Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Else
                                    'Update Receiving Line table to show line received
                                    cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                                    With cmd.Parameters
                                        .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = CheckReceiverNumber
                                        .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = CheckReceiverLine
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

                            cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)
                            cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = DeleteReferenceNumber
                            cmd.Parameters.Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)
                            cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = DeleteReferenceNumber
                            cmd.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = ReceivingLineNumber
                            cmd.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                            cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            Try
                                'Update Receiving Line Table
                                cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND SteelReceivingLineKey = @SteelReceivingLineKey", con)

                                With cmd.Parameters
                                    .Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                                    .Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = ReceivingLineNumber
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
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
                                cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @ReceivingStatus WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                                cmd.Parameters.Add("@ReceivingStatus", SqlDbType.VarChar).Value = "RECEIVED"
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
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboPartNumber.SelectedIndex = -1
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1

        txtLongDescription.Clear()
        txtQuantity.Clear()
        txtUnitCost.Clear()
        txtExtendedAmount.Clear()

        cboPartNumber.Focus()
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

    Private Sub cmdGenerateVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateVoucher.Click
        'Clear form on next number
        ClearVariables()
        ClearOnLoad()
        ClearDataInDatagrid()

        'Find the next Voucher Number to use
        Dim MAXStatement As String = "SELECT MAX(VoucherNumber) FROM ReceiptOfInvoiceBatchLine"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastVoucherNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastVoucherNumber = 3300000
        End Try
        con.Close()

        NextVoucherNumber = LastVoucherNumber + 1
        cboVoucherNumber.Text = NextVoucherNumber

        'Write Data to Batch Line (Voucher Header) Database Table
        InsertROIDatabase()

        GlobalVoucherNumber = Val(cboVoucherNumber.Text)
    End Sub

    Private Sub cmdEnterLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterLine.Click
        If cboDebitAccount.Text = "" Then
            MsgBox("Select GL Accounts for Voucher Line", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number and Invoice Number.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
            Exit Sub
        End If

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
            Exit Sub
        End If
        '**********************************************************************************************************

        'Verify that Invoice Number is Unique
        VerifyUniqueInvoiceNumber()

        If UniqueInvoice = "YES" Then
            If Val(txtUnitCost.Text) < 0 Then
                MsgBox("Unit Cost must be a positive number. For a negative value, set quantity to a negative.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'Make sure that Discount Date is not changed for N30
            VerifyDiscount()

            If DiscountDays = 0 Or DiscountPercent = 0 Or cboPaymentTerms.Text = "N30" Or cboPaymentTerms.Text = "N15" Or cboPaymentTerms.Text = "N11" Or cboPaymentTerms.Text = "N10" Or cboPaymentTerms.Text = "N25" Or cboPaymentTerms.Text = "NetDue" Then
                DiscountDate = dtpDueDate.Text
                dtpDiscountDate.Text = DiscountDate
            Else
                DiscountDate = dtpDiscountDate.Text
            End If

            Try
                'Write Data to Batch Line (Voucher) Database Table
                InsertROIDatabase()
            Catch ex As Exception
                'Update Database - Header Data (Receipt Of Invoice Batch Line)
                UpdateROIToDatabase()
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
    End Sub

    'Menu Strip Functions

    Private Sub PrintVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintVoucherToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub SaveVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveVoucherToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub DeleteVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteVoucherToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        cmdClearAll_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    'Combo Box Functions

    Private Sub cboVoucherNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVoucherNumber.SelectedIndexChanged
        LoadVoucherData()
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
        con.Close()

        cboPaymentTerms.Text = PaymentTerms
        LoadPaymentTermDetails()

        'Set defaults and load payment info for Vendor
        txtVendorName.Text = VendorName

        LoadRemitToAddress()
        LoadSteelBOLNumber()

        txtRemitToVendorID.Text = cboVendorID.Text
        txtRemitToVendorName.Text = txtVendorName.Text
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadItemDescription()
    End Sub

    Private Sub cboPaymentTerms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentTerms.SelectedIndexChanged
        LoadPaymentTermDetails()
    End Sub

    Private Sub cboBOL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBOL.SelectedIndexChanged
        If cboBOL.Text = "" Then
            'Do nothing
        Else
            LoadSteelPONumberForBOL()
        End If
    End Sub

    'Text Box Functions

    Private Sub txtFreightTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightTotal.TextChanged
        SalesTaxTotal = Val(txtSalesTaxTotal.Text)
        FreightTotal = Val(txtFreightTotal.Text)
        InvoiceTotal = ProductTotal + SalesTaxTotal + FreightTotal
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Private Sub txtSalesTaxTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTaxTotal.TextChanged
        SalesTaxTotal = Val(txtSalesTaxTotal.Text)
        FreightTotal = Val(txtFreightTotal.Text)
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

    'Miscellaneous Functions (Link Label, Date Time Picker, etc.)

    Private Sub dtpInvoiceDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInvoiceDate.ValueChanged
        LoadPaymentTermDetails()

        'Load Date Fields into text boxes
        Dim CurrentDate As Date = dtpInvoiceDate.Value
        Dim CurrentDay, CurrentMonth, CurrentYear As Integer
        Dim strCurrentDay, strCurrentMonth, strCurrentYear As String

        CurrentDay = CurrentDate.Day
        CurrentMonth = CurrentDate.Month
        CurrentYear = CurrentDate.Year

        If CurrentDay < 10 Then
            strCurrentDay = "0" + CStr(CurrentDay)
        Else
            strCurrentDay = CStr(CurrentDay)
        End If
        If CurrentMonth < 10 Then
            strCurrentMonth = "0" + CStr(CurrentMonth)
        Else
            strCurrentMonth = CStr(CurrentMonth)
        End If

        strCurrentYear = CStr(CurrentYear)

        txtInvDay.Text = strCurrentDay
        txtInvMonth.Text = strCurrentMonth
        txtInvYear.Text = strCurrentYear
    End Sub

    Private Sub dtpReceiptDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReceiptDate.ValueChanged
        'Load Date Fields into text boxes
        Dim CurrentDate As Date = dtpReceiptDate.Value
        Dim CurrentDay, CurrentMonth, CurrentYear As Integer
        Dim strCurrentDay, strCurrentMonth, strCurrentYear As String

        CurrentDay = CurrentDate.Day
        CurrentMonth = CurrentDate.Month
        CurrentYear = CurrentDate.Year

        If CurrentDay < 10 Then
            strCurrentDay = "0" + CStr(CurrentDay)
        Else
            strCurrentDay = CStr(CurrentDay)
        End If
        If CurrentMonth < 10 Then
            strCurrentMonth = "0" + CStr(CurrentMonth)
        Else
            strCurrentMonth = CStr(CurrentMonth)
        End If

        strCurrentYear = CStr(CurrentYear)

        txtRecDay.Text = strCurrentDay
        txtRecMonth.Text = strCurrentMonth
        txtRecYear.Text = strCurrentYear
    End Sub

    Private Sub dtpDiscountDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDiscountDate.ValueChanged
        'Load Date Fields into text boxes
        Dim CurrentDate As Date = dtpDiscountDate.Value
        Dim CurrentDay, CurrentMonth, CurrentYear As Integer
        Dim strCurrentDay, strCurrentMonth, strCurrentYear As String

        CurrentDay = CurrentDate.Day
        CurrentMonth = CurrentDate.Month
        CurrentYear = CurrentDate.Year

        If CurrentDay < 10 Then
            strCurrentDay = "0" + CStr(CurrentDay)
        Else
            strCurrentDay = CStr(CurrentDay)
        End If
        If CurrentMonth < 10 Then
            strCurrentMonth = "0" + CStr(CurrentMonth)
        Else
            strCurrentMonth = CStr(CurrentMonth)
        End If

        strCurrentYear = CStr(CurrentYear)

        txtDisDay.Text = strCurrentDay
        txtDisMonth.Text = strCurrentMonth
        txtDisYear.Text = strCurrentYear
    End Sub

    Private Sub dtpDueDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDueDate.ValueChanged
        'Load Date Fields into text boxes
        Dim CurrentDate As Date = dtpDueDate.Value
        Dim CurrentDay, CurrentMonth, CurrentYear As Integer
        Dim strCurrentDay, strCurrentMonth, strCurrentYear As String

        CurrentDay = CurrentDate.Day
        CurrentMonth = CurrentDate.Month
        CurrentYear = CurrentDate.Year

        If CurrentDay < 10 Then
            strCurrentDay = "0" + CStr(CurrentDay)
        Else
            strCurrentDay = CStr(CurrentDay)
        End If
        If CurrentMonth < 10 Then
            strCurrentMonth = "0" + CStr(CurrentMonth)
        Else
            strCurrentMonth = CStr(CurrentMonth)
        End If

        strCurrentYear = CStr(CurrentYear)

        txtDueDay.Text = strCurrentDay
        txtDueMonth.Text = strCurrentMonth
        txtDueYear.Text = strCurrentYear
    End Sub

    Private Sub llLoadVendorWindow_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLoadVendorWindow.LinkClicked
        gpxVoucherHeader.Visible = False
        gpxVendorAddress.Visible = True

        LoadRemitToAddress()
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

    Private Sub chkManualDiscount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManualDiscount.CheckedChanged
        If chkManualDiscount.Checked = True Then
            txtTermDiscount.Enabled = True
        Else
            txtTermDiscount.Enabled = False
        End If
    End Sub

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0

    Private Sub txtInvMonth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvMonth.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtInvMonth.Text + "/" + txtInvDay.Text + "/" + txtInvYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpInvoiceDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtInvDay_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvDay.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtInvMonth.Text + "/" + txtInvDay.Text + "/" + txtInvYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpInvoiceDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtInvYear_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvYear.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtInvMonth.Text + "/" + txtInvDay.Text + "/" + txtInvYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpInvoiceDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRecMonth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecMonth.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtRecMonth.Text + "/" + txtRecDay.Text + "/" + txtRecYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpReceiptDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRecDay_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecDay.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtRecMonth.Text + "/" + txtRecDay.Text + "/" + txtRecYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpReceiptDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRecYear_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecYear.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtRecMonth.Text + "/" + txtRecDay.Text + "/" + txtRecYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpReceiptDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDisMonth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDisMonth.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtDisMonth.Text + "/" + txtDisDay.Text + "/" + txtDisYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpDiscountDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDisDay_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDisDay.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtDisMonth.Text + "/" + txtDisDay.Text + "/" + txtDisYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpDiscountDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDisYear_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDisYear.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtDisMonth.Text + "/" + txtDisDay.Text + "/" + txtDisYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpDiscountDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDueMonth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDueMonth.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtDueMonth.Text + "/" + txtDueDay.Text + "/" + txtDueYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpDueDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDueDay_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDueDay.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtDueMonth.Text + "/" + txtDueDay.Text + "/" + txtDueYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpDueDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDueYear_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDueYear.LostFocus
        Dim ConcatenatedDate As String = ""
        Dim dateConcatenatedDate As Date

        Try
            ConcatenatedDate = txtDueMonth.Text + "/" + txtDueDay.Text + "/" + txtDueYear.Text
            dateConcatenatedDate = CDate(ConcatenatedDate)

            dtpDueDate.Value = dateConcatenatedDate
        Catch ex As Exception

        End Try
    End Sub

    Private Sub KeyPressOnDateTextBoxes(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisDay.KeyPress, txtDisMonth.KeyPress, txtDisYear.KeyPress, txtDueDay.KeyPress, txtDueMonth.KeyPress, txtDueYear.KeyPress, txtRecDay.KeyPress, txtRecMonth.KeyPress, txtRecYear.KeyPress, txtInvDay.KeyPress, txtInvMonth.KeyPress, txtInvYear.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

End Class