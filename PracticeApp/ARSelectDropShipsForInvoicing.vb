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
Public Class ARSelectDropShipsForInvoicing
    Inherits System.Windows.Forms.Form

    Dim CheckZeroCost, CheckSOLink, POQuantityOpen, LineBoxCount, BoxCount, NextReceiverLineNumber, LastReceiverLineNumber, NextReceiverNumber, LastReceiverNumber, NextShipmentLineNumber, LastShipmentLineNumber, NextShipmentNumber, LastShipmentNumber, CountPOLines, POLineNumber, SOLineNumber, CountSOLines, SalesOrderLineNumber, NextInvoiceLineNumber, LastInvoiceLineNumber, SOQuantity, SalesOrderNumber, NextInvoiceNumber, LastInvoiceNumber, NextBatchNumber, LastBatchNumber As Integer
    Dim CertificationType, ShippingMethod, ThirdPartyShipper, CustomerClass, POLineStatus, SOLineStatus, SpecialInstructions, CustomerID, CustomerPO, AdditionalShipTo, HeaderComment, ShipVia, PRONumber As String
    Dim ShipEmail, ShippingAccount, STName, STAddress1, STAddress2, STCity, STState, STZipCode, STCountry, BTAddress1, BTAddress2, BTCity, BTState, BTZipCode, BTCountry, PaymentTerms As String
    Dim LineSalesTax, ExtendedCOS, BatchAmount, SumExtendedCOS, SumInvoiceTotal, SumSalesTax, SumExtendedAmount, SalesTaxRate, InvoiceLineSalesTax, SOLineWeight, SOLineBoxes, SOPrice, InvoiceProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal As Double
    Dim GetItemClass, Salesperson, QuoteNumber, SODebitGLAccount, SOCreditGLAccount, SOLineComment As String
    Dim TotalSalesTax, ShippingLineWeight, ShippingPieceWeight, SumShippingSalesTax, SumShippingWeight, ShipmentTotal, ShippingSumExtendedAmount, SumLineWeight, POFreightCharge, ShippingWeight, QuotedFreight, FreightCharge, ReceiverTotal, ReceiverSumExtendedAmount As Double
    Dim ShipMethodID, VendorID, POHeaderComment, DropShipCOSAccount As String
    Dim ShipDate As Date
    Dim GSTRate, PSTRate, HSTRate, SalesTax1, SalesTax2, SalesTax3 As Double

    'Declare variables from Lot Numbers
    Dim POVendorCode As String = ""
    Dim POVendorDivision As String = ""

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
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ARSelectDropShipsForInvoicing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        'Load ability to change company if administrator
        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearAll()
        ClearVariables()
        ClearDataInDatagrid()

        LoadInvoiceBatchNumber()
        LoadPurchaseOrderNumber()
        cmdGenerateBatchNumber.Focus()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderQuantityStatus WHERE LineStatus = @LineStatus AND DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey, PurchaseOrderLineNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderQuantityStatus")
        dgvPurchaseOrderLines.DataSource = ds.Tables("PurchaseOrderQuantityStatus")
        con.Close()
        For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
            Dim TempPOQuantityOpen As Integer = row.Cells("POQuantityOpenColumn").Value
            row.Cells("QuantityOpenEditModeColumn").Value = TempPOQuantityOpen
        Next
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvPurchaseOrderLines.DataSource = Nothing
    End Sub

    Public Sub ShowDataByPO()
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderQuantityStatus WHERE LineStatus = @LineStatus AND DivisionID = @DivisionID AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey ORDER BY PurchaseOrderHeaderKey, PurchaseOrderLineNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderQuantityStatus")
        dgvPurchaseOrderLines.DataSource = ds.Tables("PurchaseOrderQuantityStatus")
        con.Close()

        For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
            Dim TempPOQuantityOpen As Integer = row.Cells("POQuantityOpenColumn").Value
            row.Cells("QuantityOpenEditModeColumn").Value = TempPOQuantityOpen
        Next
    End Sub

    Public Sub LoadInvoiceBatchNumber()
        cmd = New SqlCommand("SELECT BatchNumber FROM InvoiceProcessingBatchHeader WHERE BatchStatus = @BatchStatus AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "InvoiceProcessingBatchHeader")
        cboInvoiceBatchNumber.DataSource = ds1.Tables("InvoiceProcessingBatchHeader")
        con.Close()
        cboInvoiceBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPurchaseOrderNumber()
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE Status = @Status AND DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "PurchaseOrderHeaderTable")
        cboPurchaseOrderNumber.DataSource = ds2.Tables("PurchaseOrderHeaderTable")
        con.Close()
        cboPurchaseOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = POVendorDivision
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ShipmentHeaderTable")
        cboVendorShipmentNumber.DataSource = ds3.Tables("ShipmentHeaderTable")
        con.Close()
        cboVendorShipmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadLotNumbers()
        cmd = New SqlCommand("SELECT * FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboVendorShipmentNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ShipmentLineLotNumbers")
        dgvLotNumbers.DataSource = ds4.Tables("ShipmentLineLotNumbers")
        con.Close()
    End Sub

    Public Sub GetCanadianTaxRates()
        Dim GSTRateStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GSTRateCommand As New SqlCommand(GSTRateStatement, con)
        GSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
        GSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PSTRateStatement As String = "SELECT SalesTaxRate2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim PSTRateCommand As New SqlCommand(PSTRateStatement, con)
        PSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
        PSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim HSTRateStatement As String = "SELECT SalesTaxRate3 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim HSTRateCommand As New SqlCommand(HSTRateStatement, con)
        HSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
        HSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GSTRate = CDbl(GSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            GSTRate = 0
        End Try
        Try
            PSTRate = CDbl(PSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            PSTRate = 0
        End Try
        Try
            HSTRate = CDbl(HSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            HSTRate = 0
        End Try
        con.Close()
    End Sub

    Public Sub ClearVariables()
        ShippingMethod = ""
        ThirdPartyShipper = ""
        NextReceiverLineNumber = 0
        LastReceiverLineNumber = 0
        NextReceiverNumber = 0
        LastReceiverNumber = 0
        NextShipmentLineNumber = 0
        LastShipmentLineNumber = 0
        NextShipmentNumber = 0
        LastShipmentNumber = 0
        CountPOLines = 0
        POLineNumber = 0
        SOLineNumber = 0
        CountSOLines = 0
        SalesOrderLineNumber = 0
        NextInvoiceLineNumber = 0
        LastInvoiceLineNumber = 0
        SOQuantity = 0
        SalesOrderNumber = 0
        NextInvoiceNumber = 0
        LastInvoiceNumber = 0
        NextBatchNumber = 0
        LastBatchNumber = 0
        POLineStatus = ""
        SOLineStatus = ""
        SpecialInstructions = ""
        CustomerID = ""
        CustomerPO = ""
        AdditionalShipTo = ""
        HeaderComment = ""
        ShipVia = ""
        PRONumber = ""
        STAddress1 = ""
        STAddress2 = ""
        STCity = ""
        STState = ""
        STZipCode = ""
        STCountry = ""
        BTAddress1 = ""
        BTAddress2 = ""
        BTCity = ""
        BTState = ""
        BTZipCode = ""
        BTCountry = ""
        PaymentTerms = ""
        BatchAmount = 0
        SumExtendedCOS = 0
        SumInvoiceTotal = 0
        SumSalesTax = 0
        SumExtendedAmount = 0
        SalesTaxRate = 0
        InvoiceLineSalesTax = 0
        SOLineWeight = 0
        SOLineBoxes = 0
        LineSalesTax = 0
        SOPrice = 0
        InvoiceProductTotal = 0
        InvoiceFreight = 0
        InvoiceSalesTax = 0
        InvoiceTotal = 0
        Salesperson = ""
        QuoteNumber = ""
        SODebitGLAccount = ""
        SOCreditGLAccount = ""
        SOLineComment = ""
        SumShippingWeight = 0
        ShipmentTotal = 0
        ShippingSumExtendedAmount = 0
        SumLineWeight = 0
        POFreightCharge = 0
        ShippingWeight = 0
        QuotedFreight = 0
        FreightCharge = 0
        ReceiverTotal = 0
        ReceiverSumExtendedAmount = 0
        ShipMethodID = ""
        VendorID = ""
        POHeaderComment = ""
        SumShippingSalesTax = 0
        BoxCount = 0
        ShippingLineWeight = 0
        ShippingPieceWeight = 0
        LineBoxCount = 0
        POQuantityOpen = 0
        CheckSOLink = 0
        GetItemClass = ""
        ExtendedCOS = 0
        GSTRate = 0
        PSTRate = 0
        HSTRate = 0
        SalesTax1 = 0
        SalesTax2 = 0
        SalesTax3 = 0
        DropShipCOSAccount = ""
        CheckZeroCost = 0
        CertificationType = ""
        POVendorDivision = ""
        POVendorCode = ""
    End Sub

    Public Sub ClearAll()
        cboInvoiceBatchNumber.Text = ""

        cboInvoiceBatchNumber.SelectedIndex = -1
        cboPurchaseOrderNumber.SelectedIndex = -1
        cboVendorShipmentNumber.SelectedIndex = -1

        gpxShipment.Enabled = False
        cboInvoiceBatchNumber.Focus()
    End Sub

    Public Sub ClearForNextEntry()
        cboPurchaseOrderNumber.SelectedIndex = -1
        cboVendorShipmentNumber.SelectedIndex = -1
        cboPurchaseOrderNumber.Focus()
    End Sub

    Public Sub LoadInvoiceTotal()
        Dim SumExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
        Dim SumExtendedAmountCommand As New SqlCommand(SumExtendedAmountStatement, con)
        SumExtendedAmountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = NextInvoiceNumber
        SumExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SumSalesTaxStatement As String = "SELECT SUM(SalesTax) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
        Dim SumSalesTaxCommand As New SqlCommand(SumSalesTaxStatement, con)
        SumSalesTaxCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = NextInvoiceNumber
        SumSalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SumExtendedCOSStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
        Dim SumExtendedCOSCommand As New SqlCommand(SumExtendedCOSStatement, con)
        SumExtendedCOSCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = NextInvoiceNumber
        SumExtendedCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumExtendedAmount = CDbl(SumExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            SumExtendedAmount = 0
        End Try
        Try
            SumSalesTax = CDbl(SumSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            SumSalesTax = 0
        End Try
        Try
            SumExtendedCOS = CDbl(SumExtendedCOSCommand.ExecuteScalar)
        Catch ex As Exception
            SumExtendedCOS = 0
        End Try
        con.Close()

        SumInvoiceTotal = SumExtendedAmount + SumSalesTax
    End Sub

    Public Sub LoadReceiverTotal()
        Dim ReceiverSumExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
        Dim ReceiverSumExtendedAmountCommand As New SqlCommand(ReceiverSumExtendedAmountStatement, con)
        ReceiverSumExtendedAmountCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = NextReceiverNumber
        ReceiverSumExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ReceiverSumExtendedAmount = CDbl(ReceiverSumExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            ReceiverSumExtendedAmount = 0
        End Try
        con.Close()

        ReceiverTotal = POFreightCharge + ReceiverSumExtendedAmount
    End Sub

    Public Sub LoadShipmentTotal()
        Dim SumShippingExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim SumShippingExtendedAmountCommand As New SqlCommand(SumShippingExtendedAmountStatement, con)
        SumShippingExtendedAmountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
        SumShippingExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SumShippingWeightStatement As String = "SELECT SUM(LineWeight) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim SumShippingWeightCommand As New SqlCommand(SumShippingWeightStatement, con)
        SumShippingWeightCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
        SumShippingWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SumShippingSalesTaxStatement As String = "SELECT SUM(SalesTax) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim SumShippingSalesTaxCommand As New SqlCommand(SumShippingSalesTaxStatement, con)
        SumShippingSalesTaxCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
        SumShippingSalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShippingSumExtendedAmount = CDbl(SumShippingExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            ShippingSumExtendedAmount = 0
        End Try
        Try
            SumShippingWeight = CDbl(SumShippingWeightCommand.ExecuteScalar)
        Catch ex As Exception
            SumShippingWeight = 0
        End Try
        Try
            SumShippingSalesTax = CDbl(SumShippingSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            SumShippingSalesTax = 0
        End Try
        con.Close()

        ShipmentTotal = ShippingSumExtendedAmount + FreightCharge + SumShippingSalesTax
    End Sub

    Private Sub cmdViewByPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByPO.Click
        ShowDataByPO()

        LoadVendorFromPONumber()
        DefineVendorDivision()
        If POVendorDivision = "" Then
            gpxShipment.Enabled = False
        Else
            gpxShipment.Enabled = True
            LoadShipmentNumber()
        End If
    End Sub

    Public Sub LoadVendorFromPONumber()
        Dim POVendorCodeStatement As String = "SELECT VendorID FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim POVendorCodeCommand As New SqlCommand(POVendorCodeStatement, con)
        POVendorCodeCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        POVendorCodeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            POVendorCode = CStr(POVendorCodeCommand.ExecuteScalar)
        Catch ex As Exception
            POVendorCode = ""
        End Try
        con.Close()
    End Sub

    Public Sub DefineVendorDivision()
        Select Case POVendorCode
            Case "TFP ATLANTA"
                POVendorDivision = "ATL"
            Case "TFP CORP"
                POVendorDivision = "TWD"
            Case "TFP DENVER"
                POVendorDivision = "DEN"
            Case "TFP HOUSTON"
                POVendorDivision = "HOU"
            Case "TFP INDIANA"
                POVendorDivision = "CGO"
            Case "TFP IRVING"
                POVendorDivision = "TFT"
            Case "TFP NEVADA"
                POVendorDivision = "CBS"
            Case "TFP TORONTO"
                POVendorDivision = "TOR"
            Case "TFP UTAH"
                POVendorDivision = "SLC"
            Case "TFP VANCOUVER"
                POVendorDivision = "TFF"
            Case "TWE"
                POVendorDivision = "TWE"
            Case "TFP ALBERTA"
                POVendorDivision = "ALB"
            Case "TFP NEW JERSEY"
                POVendorDivision = "TFJ"
            Case Else
                POVendorDivision = ""
        End Select
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoice")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdUnselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnselectAll.Click
        For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoice")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcess.Click
        If cboInvoiceBatchNumber.Text = "" Or cboPurchaseOrderNumber.Text = "" Or Val(cboPurchaseOrderNumber.Text) = 0 Then
            MsgBox("You must have a Batch Number and Purchase Order Number selected.", MsgBoxStyle.OkOnly)
        Else
            'Query database for SO#
            Dim CheckSOLinkStatement As String = "SELECT DropShipSalesOrderNumber FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
            Dim CheckSOLinkCommand As New SqlCommand(CheckSOLinkStatement, con)
            CheckSOLinkCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
            CheckSOLinkCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckSOLink = CInt(CheckSOLinkCommand.ExecuteScalar)
            Catch ex As Exception
                CheckSOLink = 0
            End Try
            con.Close()

            Dim CountPOLines2, CountSOLines2 As Integer

            'Verify that PO and SO have the same number of lines
            Dim CountPOLines2Statement As String = "SELECT COUNT(PurchaseOrderHeaderKey) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
            Dim CountPOLines2Command As New SqlCommand(CountPOLines2Statement, con)
            CountPOLines2Command.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
            CountPOLines2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountPOLines2 = CInt(CountPOLines2Command.ExecuteScalar)
            Catch ex As Exception
                CountPOLines2 = 0
            End Try
            con.Close()

            Dim CountSOLines2Statement As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
            Dim CountSOLines2Command As New SqlCommand(CountSOLines2Statement, con)
            CountSOLines2Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = CheckSOLink
            CountSOLines2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountSOLines2 = CInt(CountSOLines2Command.ExecuteScalar)
            Catch ex As Exception
                CountSOLines2 = 0
            End Try
            con.Close()

            'Verify that PO and SO have the same line numbers
            Dim MAXPOLines2, MAXSOLines2 As Integer

            'Verify that PO and SO have the same number of lines
            Dim MAXPOLines2Statement As String = "SELECT MAX(PurchaseOrderLineNumber) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
            Dim MAXPOLines2Command As New SqlCommand(MAXPOLines2Statement, con)
            MAXPOLines2Command.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
            MAXPOLines2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXPOLines2 = CInt(MAXPOLines2Command.ExecuteScalar)
            Catch ex As Exception
                MAXPOLines2 = 0
            End Try
            con.Close()

            Dim MAXSOLines2Statement As String = "SELECT MAX(SalesOrderLineKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
            Dim MAXSOLines2Command As New SqlCommand(MAXSOLines2Statement, con)
            MAXSOLines2Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = CheckSOLink
            MAXSOLines2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXSOLines2 = CInt(MAXSOLines2Command.ExecuteScalar)
            Catch ex As Exception
                MAXSOLines2 = 0
            End Try
            con.Close()

            If CheckSOLink = 0 Or (CountPOLines2 - CountSOLines2 <> 0) Or (MAXPOLines2 <> MAXSOLines2) Then
                MsgBox("Purchase Order has no linked Sales Order or # of lines are different.", MsgBoxStyle.OkOnly)
            Else
                ShipDate = dtpShipDate.Value

                'Check to see if there are any 0 cost items excluding ferrules
                Dim CheckZeroCostStatement As String = "SELECT COUNT(PurchaseOrderHeaderKey) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID AND UnitCost = @UnitCost AND PartNumber NOT LIKE @PartNumber"
                Dim CheckZeroCostCommand As New SqlCommand(CheckZeroCostStatement, con)
                CheckZeroCostCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                CheckZeroCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CheckZeroCostCommand.Parameters.Add("@UnitCost", SqlDbType.VarChar).Value = 0
                CheckZeroCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = "FER%"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckZeroCost = CInt(CheckZeroCostCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckZeroCost = 0
                End Try
                con.Close()

                If CheckZeroCost <> 0 Then
                    Dim button As DialogResult = MessageBox.Show("You have one or more items on this PO that have zero cost. Do you wish to proceed?", "PROCEED?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button = DialogResult.Yes Then
                        'Create Invoice Batch Form
                        Try
                            cmd = New SqlCommand("Insert Into InvoiceProcessingBatchHeader (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, UserID) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @UserID)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                                .Add("@BatchDate", SqlDbType.VarChar).Value = ShipDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "PO Drop Ship Invoicing"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, DivisionID = @DivisionID, BatchStatus = @BatchStatus, UserID = @UserID WHERE BatchNumber = @BatchNumber", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                                .Add("@BatchDate", SqlDbType.VarChar).Value = ShipDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "PO Drop Ship Invoicing"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End Try
                        '**********************************************************************************************************************
                        'Get PO Data to create Receiver
                        Dim PODate As String

                        Dim GetPODataString As String = "SELECT * FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
                        Dim GetPODataCommand As New SqlCommand(GetPODataString, con)
                        GetPODataCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        GetPODataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Dim reader As SqlDataReader = GetPODataCommand.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            If IsDBNull(reader.Item("VendorID")) Then
                                VendorID = ""
                            Else
                                VendorID = reader.Item("VendorID")
                            End If
                            If IsDBNull(reader.Item("POHeaderComment")) Then
                                POHeaderComment = ""
                            Else
                                POHeaderComment = reader.Item("POHeaderComment")
                            End If
                            If IsDBNull(reader.Item("PODate")) Then
                                PODate = ""
                            Else
                                PODate = reader.Item("PODate")
                            End If
                            If IsDBNull(reader.Item("ShipMethodID")) Then
                                ShipMethodID = ""
                            Else
                                ShipMethodID = reader.Item("ShipMethodID")
                            End If
                            If IsDBNull(reader.Item("FreightCharge")) Then
                                POFreightCharge = 0
                            Else
                                POFreightCharge = reader.Item("FreightCharge")
                            End If
                            If IsDBNull(reader.Item("DropShipSalesOrderNumber")) Then
                                SalesOrderNumber = 0
                            Else
                                SalesOrderNumber = reader.Item("DropShipSalesOrderNumber")
                            End If
                        Else
                            VendorID = ""
                            POHeaderComment = ""
                            PODate = ""
                            ShipMethodID = ""
                            POFreightCharge = 0
                            SalesOrderNumber = 0
                        End If
                        reader.Close()
                        con.Close()
                        '*******************************************************************************************
                        Dim GetSODataString As String = "SELECT * FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                        Dim GetSODataCommand As New SqlCommand(GetSODataString, con)
                        GetSODataCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                        GetSODataCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Dim reader2 As SqlDataReader = GetSODataCommand.ExecuteReader()
                        If reader2.HasRows Then
                            reader2.Read()
                            If IsDBNull(reader2.Item("CustomerID")) Then
                                CustomerID = ""
                            Else
                                CustomerID = reader2.Item("CustomerID")
                            End If
                            If IsDBNull(reader2.Item("CustomerPO")) Then
                                CustomerPO = ""
                            Else
                                CustomerPO = reader2.Item("CustomerPO")
                            End If
                            If IsDBNull(reader2.Item("ShipVia")) Then
                                ShipVia = ""
                            Else
                                ShipVia = reader2.Item("ShipVia")
                            End If
                            If IsDBNull(reader2.Item("HeaderComment")) Then
                                HeaderComment = ""
                            Else
                                HeaderComment = reader2.Item("HeaderComment")
                            End If
                            If IsDBNull(reader2.Item("PRONumber")) Then
                                PRONumber = ""
                            Else
                                PRONumber = reader2.Item("PRONumber")
                            End If
                            If IsDBNull(reader2.Item("SpecialInstructions")) Then
                                SpecialInstructions = ""
                            Else
                                SpecialInstructions = reader2.Item("SpecialInstructions")
                            End If
                            If IsDBNull(reader2.Item("Salesperson")) Then
                                Salesperson = ""
                            Else
                                Salesperson = reader2.Item("Salesperson")
                            End If
                            If IsDBNull(reader2.Item("FreightCharge")) Then
                                FreightCharge = 0
                            Else
                                FreightCharge = reader2.Item("FreightCharge")
                            End If
                            If IsDBNull(reader2.Item("QuoteNumber")) Then
                                QuoteNumber = ""
                            Else
                                QuoteNumber = reader2.Item("QuoteNumber")
                            End If
                            If IsDBNull(reader2.Item("QuotedFreight")) Then
                                QuotedFreight = 0
                            Else
                                QuotedFreight = reader2.Item("QuotedFreight")
                            End If
                            If IsDBNull(reader2.Item("ShippingWeight")) Then
                                ShippingWeight = 0
                            Else
                                ShippingWeight = reader2.Item("ShippingWeight")
                            End If
                            If IsDBNull(reader2.Item("TotalSalesTax")) Then
                                TotalSalesTax = 0
                            Else
                                TotalSalesTax = reader2.Item("TotalSalesTax")
                            End If
                            If IsDBNull(reader2.Item("ShippingMethod")) Then
                                ShippingMethod = ""
                            Else
                                ShippingMethod = reader2.Item("ShippingMethod")
                            End If
                            If IsDBNull(reader2.Item("ThirdPartyShipper")) Then
                                ThirdPartyShipper = ""
                            Else
                                ThirdPartyShipper = reader2.Item("ThirdPartyShipper")
                            End If
                            If IsDBNull(reader2.Item("ShipEmail")) Then
                                ShipEmail = ""
                            Else
                                ShipEmail = reader2.Item("ShipEmail")
                            End If
                            If IsDBNull(reader2.Item("ShippingAccount")) Then
                                ShippingAccount = ""
                            Else
                                ShippingAccount = reader2.Item("ShippingAccount")
                            End If
                            If IsDBNull(reader2.Item("ShipToName")) Then
                                STName = ""
                            Else
                                STName = reader2.Item("ShipToName")
                            End If
                            If IsDBNull(reader2.Item("ShipToAddress1")) Then
                                STAddress1 = ""
                            Else
                                STAddress1 = reader2.Item("ShipToAddress1")
                            End If
                            If IsDBNull(reader2.Item("ShipToAddress2")) Then
                                STAddress2 = ""
                            Else
                                STAddress2 = reader2.Item("ShipToAddress2")
                            End If
                            If IsDBNull(reader2.Item("ShipToCity")) Then
                                STCity = ""
                            Else
                                STCity = reader2.Item("ShipToCity")
                            End If
                            If IsDBNull(reader2.Item("ShipToState")) Then
                                STState = ""
                            Else
                                STState = reader2.Item("ShipToState")
                            End If
                            If IsDBNull(reader2.Item("ShipToZip")) Then
                                STZipCode = ""
                            Else
                                STZipCode = reader2.Item("ShipToZip")
                            End If
                            If IsDBNull(reader2.Item("ShipToCountry")) Then
                                STCountry = ""
                            Else
                                STCountry = reader2.Item("ShipToCountry")
                            End If
                        Else
                            CustomerID = ""
                            CustomerPO = ""
                            ShipVia = ""
                            HeaderComment = ""
                            PRONumber = ""
                            SpecialInstructions = ""
                            Salesperson = ""
                            FreightCharge = 0
                            QuoteNumber = ""
                            QuotedFreight = 0
                            ShippingWeight = 0
                            TotalSalesTax = 0
                            ShippingMethod = "OTHER"
                            ThirdPartyShipper = ""
                            ShipEmail = ""
                            ShippingAccount = ""
                            STName = ""
                            STAddress1 = ""
                            STAddress2 = ""
                            STCity = ""
                            STState = ""
                            STZipCode = ""
                            STCountry = ""
                        End If
                        reader2.Close()
                        con.Close()
                        '***********************************************************************************************
                        'Extract Data from Customer Data to write to Invoice Table
                        Dim BillToAddress1Statement As String = "SELECT BillToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                        Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
                        BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                        BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim BillToAddress2Statement As String = "SELECT BillToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                        Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
                        BillToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                        BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim BillToCityStatement As String = "SELECT BillToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                        Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
                        BillToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                        BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim BillToStateStatement As String = "SELECT BillToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                        Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
                        BillToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                        BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim BillToZipStatement As String = "SELECT BillToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                        Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
                        BillToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                        BillToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim BillToCountryStatement As String = "SELECT BillToCountry FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                        Dim BillToCountryCommand As New SqlCommand(BillToCountryStatement, con)
                        BillToCountryCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                        BillToCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                        Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
                        PaymentTermsCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                        PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim CustomerTaxRateStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                        Dim CustomerTaxRateCommand As New SqlCommand(CustomerTaxRateStatement, con)
                        CustomerTaxRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                        CustomerTaxRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim CustomerClassStatement As String = "SELECT CustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                        Dim CustomerClassCommand As New SqlCommand(CustomerClassStatement, con)
                        CustomerClassCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                        CustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            BTAddress1 = CStr(BillToAddress1Command.ExecuteScalar)
                        Catch ex As Exception
                            BTAddress1 = ""
                        End Try
                        Try
                            BTAddress2 = CStr(BillToAddress2Command.ExecuteScalar)
                        Catch ex As Exception
                            BTAddress2 = ""
                        End Try
                        Try
                            BTCity = CStr(BillToCityCommand.ExecuteScalar)
                        Catch ex As Exception
                            BTCity = ""
                        End Try
                        Try
                            BTState = CStr(BillToStateCommand.ExecuteScalar)
                        Catch ex As Exception
                            BTState = ""
                        End Try
                        Try
                            BTZipCode = CStr(BillToZipCommand.ExecuteScalar)
                        Catch ex As Exception
                            BTZipCode = ""
                        End Try
                        Try
                            BTCountry = CStr(BillToCountryCommand.ExecuteScalar)
                        Catch ex As Exception
                            BTCountry = ""
                        End Try
                        Try
                            PaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
                        Catch ex As Exception
                            PaymentTerms = ""
                        End Try
                        Try
                            SalesTaxRate = CDbl(CustomerTaxRateCommand.ExecuteScalar)
                        Catch ex As Exception
                            SalesTaxRate = 0
                        End Try
                        Try
                            CustomerClass = CStr(CustomerClassCommand.ExecuteScalar)
                        Catch ex As Exception
                            CustomerClass = "STANDARD"
                        End Try
                        con.Close()
                        '********************************************************************************************************
                        'Create New Receiver for Drop Ship PO
                        Dim MAXReceiverNumberStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingHeaderTable"
                        Dim MAXReceiverNumberCommand As New SqlCommand(MAXReceiverNumberStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastReceiverNumber = CInt(MAXReceiverNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            LastReceiverNumber = 0
                        End Try
                        con.Close()

                        NextReceiverNumber = LastReceiverNumber + 1

                        Try
                            'Write to Receiving Header Table
                            cmd = New SqlCommand("Insert Into ReceivingHeaderTable (ReceivingHeaderKey, PONumber, VendorCode, ReceivingDate, InvoiceNumber, HeaderComment, PODate, ShipMethodID, FreightCharge, SalesTax, ProductTotal, POTotal, Status, DivisionID, TransferDivision, ReceivingAgent, Locked, PrintDate)Values(@ReceivingHeaderKey, @PONumber, @VendorCode, @ReceivingDate, @InvoiceNumber, @HeaderComment, @PODate, @ShipMethodID, @FreightCharge, @SalesTax, @ProductTotal, @POTotal, @Status, @DivisionID, @TransferDivision, @ReceivingAgent, @Locked, @PrintDate)", con)

                            With cmd.Parameters
                                .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = NextReceiverNumber
                                .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                .Add("@VendorCode", SqlDbType.VarChar).Value = VendorID
                                .Add("@ReceivingDate", SqlDbType.VarChar).Value = ShipDate
                                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = "DROP SHIP - AUTO"
                                .Add("@HeaderComment", SqlDbType.VarChar).Value = POHeaderComment
                                .Add("@PODate", SqlDbType.VarChar).Value = PODate
                                .Add("@ShipMethodID", SqlDbType.VarChar).Value = ShipMethodID
                                .Add("@FreightCharge", SqlDbType.VarChar).Value = POFreightCharge
                                .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                                .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                                .Add("@POTotal", SqlDbType.VarChar).Value = 0
                                .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@TransferDivision", SqlDbType.VarChar).Value = ""
                                .Add("@ReceivingAgent", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Write to error log
                            Dim TempReceiverNumber As Integer = 0
                            Dim strReceiverNumber As String
                            TempReceiverNumber = NextReceiverNumber
                            strReceiverNumber = CStr(TempReceiverNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Drop Ship Invoicing --- Insert Receiver Header on Process "
                            ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()

                            MsgBox("Error creating receiver. This process will exit.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End Try
                        '*****************************************************************************************************
                        'Create Drop Shipment in Shipment Header Table
                        Dim MAXShipmentNumberStatement As String = "SELECT MAX(ShipmentNumber) FROM ShipmentHeaderTable"
                        Dim MAXShipmentNumberCommand As New SqlCommand(MAXShipmentNumberStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastShipmentNumber = CInt(MAXShipmentNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            LastShipmentNumber = 0
                        End Try
                        con.Close()

                        NextShipmentNumber = LastShipmentNumber + 1

                        Try
                            'Write to Shipment Header Table
                            cmd = New SqlCommand("Insert Into ShipmentHeaderTable (ShipmentNumber, SalesOrderKey, ShipDate, DivisionID, Comment, PickTicketNumber, ShipVia, PRONumber, FreightQuoteNumber, FreightQuoteAmount, FreightActualAmount, ShippingWeight, NumberOfPallets, CustomerID, ShipToID, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZip, ShipCountry, CustomerPO, ShipmentStatus, ProductTotal, TaxTotal, ShipmentTotal, BatchNumber, SpecialInstructions, SalesmanID, Tax2Total, Tax3Total, CertsAutoGenerated, SOLog, PulledBy, CertsPulled, PackingSlip, Locked, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper, ShipToName, ShipEmail, ShippingAccount)Values (@ShipmentNumber, @SalesOrderKey, @ShipDate, @DivisionID, @Comment, @PickTicketNumber, @ShipVia, @PRONumber, @FreightQuoteNumber, @FreightQuoteAmount, @FreightActualAmount, @ShippingWeight, @NumberOfPallets, @CustomerID, @ShipToID, @ShipAddress1, @ShipAddress2, @ShipCity, @ShipState, @ShipZip, @ShipCountry, @CustomerPO, @ShipmentStatus, @ProductTotal, @TaxTotal, @ShipmentTotal, @BatchNumber, @SpecialInstructions, @SalesmanID, @Tax2Total, @Tax3Total, @CertsAutoGenerated, @SOLog, @PulledBy, @CertsPulled, @PackingSlip, @Locked, @CustomerClass, @FOB, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @ShipEmail, @ShippingAccount)", con)

                            With cmd.Parameters
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                .Add("@ShipDate", SqlDbType.VarChar).Value = ShipDate
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@Comment", SqlDbType.VarChar).Value = HeaderComment
                                .Add("@PickTicketNumber", SqlDbType.VarChar).Value = NextReceiverNumber
                                .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                                .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                                .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = QuoteNumber
                                .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = QuotedFreight
                                .Add("@FreightActualAmount", SqlDbType.VarChar).Value = FreightCharge
                                .Add("@ShippingWeight", SqlDbType.VarChar).Value = ShippingWeight
                                .Add("@NumberOfPallets", SqlDbType.VarChar).Value = 1
                                .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                                .Add("@ShipToID", SqlDbType.VarChar).Value = ""
                                .Add("@ShipAddress1", SqlDbType.VarChar).Value = STAddress1
                                .Add("@ShipAddress2", SqlDbType.VarChar).Value = STAddress2
                                .Add("@ShipCity", SqlDbType.VarChar).Value = STCity
                                .Add("@ShipState", SqlDbType.VarChar).Value = STState
                                .Add("@ShipZip", SqlDbType.VarChar).Value = STZipCode
                                .Add("@ShipCountry", SqlDbType.VarChar).Value = STCountry
                                .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                                .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                                .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                                .Add("@TaxTotal", SqlDbType.VarChar).Value = TotalSalesTax
                                .Add("@ShipmentTotal", SqlDbType.VarChar).Value = 0
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = "DROPSHIP"
                                .Add("@SalesmanID", SqlDbType.VarChar).Value = Salesperson
                                .Add("@Tax2Total", SqlDbType.VarChar).Value = 0
                                .Add("@Tax3Total", SqlDbType.VarChar).Value = 0
                                .Add("@CertsAutoGenerated", SqlDbType.VarChar).Value = "NO"
                                .Add("@SOLog", SqlDbType.VarChar).Value = ""
                                .Add("@PulledBy", SqlDbType.VarChar).Value = ""
                                .Add("@CertsPulled", SqlDbType.VarChar).Value = ""
                                .Add("@PackingSlip", SqlDbType.VarChar).Value = ""
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                                .Add("@FOB", SqlDbType.VarChar).Value = "DROPSHIP"
                                .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShippingMethod
                                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ThirdPartyShipper
                                .Add("@ShipToName", SqlDbType.VarChar).Value = STName
                                .Add("@ShipEmail", SqlDbType.VarChar).Value = ShipEmail
                                .Add("@ShippingAccount", SqlDbType.VarChar).Value = ShippingAccount
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Write to error log
                            Dim TempShipmentNumber As Integer = 0
                            Dim strShipmentNumber As String = ""
                            TempShipmentNumber = NextShipmentNumber
                            strShipmentNumber = CStr(TempShipmentNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Drop Ship Invoicing --- Insert Shipment Header on Process "
                            ErrorReferenceNumber = "Receiver # " + strShipmentNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()

                            MsgBox("Error creating shipment. This process will exit.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End Try
                        '*****************************************************************************************************
                        'Get Next Invoice Number
                        Dim MAXInvoiceNumberStatement As String = "SELECT MAX(InvoiceNumber) FROM InvoiceHeaderTable"
                        Dim MAXInvoiceNumberCommand As New SqlCommand(MAXInvoiceNumberStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastInvoiceNumber = CInt(MAXInvoiceNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            LastInvoiceNumber = 0
                        End Try
                        con.Close()

                        NextInvoiceNumber = LastInvoiceNumber + 1

                        Try
                            'Create Invoice Header record
                            cmd = New SqlCommand("Insert Into InvoiceHeaderTable (InvoiceNumber, BatchNumber, InvoiceDate, SalesOrderNumber, ShipmentNumber, DivisionID, CustomerID, CustomerPO, PaymentTerms, Comment, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, ProductTotal, BilledFreight, SalesTax, Discount, InvoiceTotal, InvoiceStatus, ShipVia, PaymentsApplied, InvoiceCOS, PRONumber, SpecialInstructions, DropShipPONumber, SalesTax2, SalesTax3, ReprintBatch, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper) Values (@InvoiceNumber, @BatchNumber, @InvoiceDate, @SalesOrderNumber, @ShipmentNumber, @DivisionID, @CustomerID, @CustomerPO, @PaymentTerms, @Comment, @BTAddress1, @BTAddress2, @BTCity, @BTState, @BTZip, @BTCountry, @ProductTotal, @BilledFreight, @SalesTax, @Discount, @InvoiceTotal, @InvoiceStatus, @ShipVia, @PaymentsApplied, @InvoiceCOS, @PRONumber, @SpecialInstructions, @DropShipPONumber, @SalesTax2, @SalesTax3, @ReprintBatch, @CustomerClass, @FOB, @ShippingMethod, @ThirdPartyShipper)", con)

                            With cmd.Parameters
                                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextInvoiceNumber
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                                .Add("@InvoiceDate", SqlDbType.VarChar).Value = ShipDate
                                .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = SalesOrderNumber
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                                .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                                .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
                                .Add("@Comment", SqlDbType.VarChar).Value = HeaderComment
                                .Add("@BTAddress1", SqlDbType.VarChar).Value = BTAddress1
                                .Add("@BTAddress2", SqlDbType.VarChar).Value = BTAddress2
                                .Add("@BTCity", SqlDbType.VarChar).Value = BTCity
                                .Add("@BTState", SqlDbType.VarChar).Value = BTState
                                .Add("@BTZip", SqlDbType.VarChar).Value = BTZipCode
                                .Add("@BTCountry", SqlDbType.VarChar).Value = BTCountry
                                .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                                .Add("@BilledFreight", SqlDbType.VarChar).Value = FreightCharge
                                .Add("@SalesTax", SqlDbType.VarChar).Value = TotalSalesTax
                                .Add("@Discount", SqlDbType.VarChar).Value = 0
                                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
                                .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
                                .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                                .Add("@PaymentsApplied", SqlDbType.VarChar).Value = 0
                                .Add("@InvoiceCOS", SqlDbType.VarChar).Value = 0
                                .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = "DROPSHIP"
                                .Add("@DropShipPONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                .Add("@SalesTax2", SqlDbType.VarChar).Value = 0
                                .Add("@SalesTax3", SqlDbType.VarChar).Value = 0
                                .Add("@ReprintBatch", SqlDbType.VarChar).Value = ""
                                .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                                .Add("@FOB", SqlDbType.VarChar).Value = "DROPSHIP"
                                .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShippingMethod
                                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ThirdPartyShipper
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Write to error log
                            Dim TempInvoiceNumber As Integer = 0
                            Dim strInvoiceNumber As String = ""
                            TempInvoiceNumber = NextInvoiceNumber
                            strInvoiceNumber = CStr(TempInvoiceNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Drop Ship Invoicing --- Insert Invoice Header on Process "
                            ErrorReferenceNumber = "Receiver # " + strInvoiceNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()

                            MsgBox("Error creating Invoice. This process will exit.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End Try

                        '**************************************************************************************
                        'Line Routine
                        '**************************************************************************************
                        'Extract data from the selected items in the grid to create invoices in the Batch
                        For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
                            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoice")
                            'Declare variables
                            Dim POPartNumber, POPartDescription, LineComment As String
                            Dim POOpenQuantity, POQuantity, POUnitCost, POExtendedAmount As Double
                            Dim POLineNumber As Integer = 0
                            Dim CheckSOPart As Integer = 0

                            If cell.Value = "SELECTED" Then
                                Try
                                    POPartNumber = row.Cells("PartNumberColumn").Value
                                Catch ex As Exception
                                    POPartNumber = ""
                                End Try
                                Try
                                    POPartDescription = row.Cells("PartDescriptionColumn").Value
                                Catch ex As Exception
                                    POPartDescription = ""
                                End Try
                                Try
                                    POQuantity = row.Cells("QuantityOpenEditModeColumn").Value
                                Catch ex As Exception
                                    POQuantity = 0
                                End Try
                                Try
                                    POOpenQuantity = row.Cells("POQuantityOpenColumn").Value
                                Catch ex As Exception
                                    POOpenQuantity = 0
                                End Try
                                Try
                                    POUnitCost = row.Cells("UnitCostColumn").Value
                                Catch ex As Exception
                                    POUnitCost = 0
                                End Try
                                Try
                                    POExtendedAmount = row.Cells("OpenAmountColumn").Value
                                Catch ex As Exception
                                    POExtendedAmount = 0
                                End Try
                                Try
                                    POLineNumber = row.Cells("PurchaseOrderLineNumberColumn").Value
                                Catch ex As Exception
                                    POLineNumber = 1
                                End Try
                                Try
                                    LineComment = row.Cells("LineCommentColumn").Value
                                Catch ex As Exception
                                    LineComment = ""
                                End Try
                                '************************************************************************************************************
                                'Verify that there is a part on the Sales Order with the same quantity
                                Dim CheckSOPartStatement As String = "SELECT SalesOrderLineKey FROM SalesOrderQuantityStatus WHERE ItemID = @ItemID AND DivisionKey = @DivisionKey AND QuantityOpen = @QuantityOpen AND SalesOrderKey = @SalesOrderKey"
                                Dim CheckSOPartCommand As New SqlCommand(CheckSOPartStatement, con)
                                CheckSOPartCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                                CheckSOPartCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = POPartNumber
                                CheckSOPartCommand.Parameters.Add("@QuantityOpen", SqlDbType.VarChar).Value = POOpenQuantity
                                CheckSOPartCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    CheckSOPart = CInt(CheckSOPartCommand.ExecuteScalar)
                                Catch ex As Exception
                                    CheckSOPart = 0
                                End Try
                                con.Close()

                                If CheckSOPart <> 0 Then
                                    'Continue
                                Else
                                    MsgBox("The Sales Order and Purchase Order must match for Drop Ships. Check part and quantity and try again.", MsgBoxStyle.OkOnly)
                                    'Delete Invoice, Shipment, and Receiver and exit subroutine
                                    '************************************************************************************************************
                                    'Delete Receiver
                                    cmd = New SqlCommand("DELETE FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID AND Status = @Status", con)

                                    With cmd.Parameters
                                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = NextReceiverNumber
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    '************************************************************************************************************
                                    'Delete Shipment
                                    cmd = New SqlCommand("DELETE FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID AND ShipmentStatus = @ShipmentStatus", con)

                                    With cmd.Parameters
                                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    '************************************************************************************************************
                                    'Delete Invoice
                                    cmd = New SqlCommand("DELETE FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID AND InvoiceStatus = @InvoiceStatus", con)

                                    With cmd.Parameters
                                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextInvoiceNumber
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    Exit Sub
                                End If
                                '************************************************************************************************************
                                'If PO Quantity = 0 then do not write line into receiver, shipper, or Invoice
                                If POQuantity = 0 Then
                                    'Skip Line
                                Else
                                    'Get Item Class for Part Number
                                    Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                                    Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                                    GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = POPartNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        GetItemClass = "TW CA"
                                    End Try
                                    con.Close()
                                    '************************************************************************************************************
                                    'Extract Sales Order Data from Line Table
                                    Dim SOPriceStatement As String = "SELECT Price FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                    Dim SOPriceCommand As New SqlCommand(SOPriceStatement, con)
                                    SOPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    SOPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    SOPriceCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                    Dim LineCommentStatement As String = "SELECT LineComment FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                    Dim LineCommentCommand As New SqlCommand(LineCommentStatement, con)
                                    LineCommentCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    LineCommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    LineCommentCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                    Dim SODebitGLAccountStatement As String = "SELECT DebitGLAccount FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                    Dim SODebitGLAccountCommand As New SqlCommand(SODebitGLAccountStatement, con)
                                    SODebitGLAccountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    SODebitGLAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    SODebitGLAccountCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                    Dim SOCreditGLAccountStatement As String = "SELECT CreditGLAccount FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                    Dim SOCreditGLAccountCommand As New SqlCommand(SOCreditGLAccountStatement, con)
                                    SOCreditGLAccountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    SOCreditGLAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    SOCreditGLAccountCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                    Dim SOLineBoxesStatement As String = "SELECT LineBoxes FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                    Dim SOLineBoxesCommand As New SqlCommand(SOLineBoxesStatement, con)
                                    SOLineBoxesCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    SOLineBoxesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    SOLineBoxesCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                    Dim SOLineWeightStatement As String = "SELECT OpenLineWeight FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey AND SalesOrderLineKey = @SalesOrderLineKey"
                                    Dim SOLineWeightCommand As New SqlCommand(SOLineWeightStatement, con)
                                    SOLineWeightCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    SOLineWeightCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    SOLineWeightCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                    Dim SOLineNumberStatement As String = "SELECT SalesOrderLineKey FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                    Dim SOLineNumberCommand As New SqlCommand(SOLineNumberStatement, con)
                                    SOLineNumberCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    SOLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    SOLineNumberCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                    Dim CertificationTypeStatement As String = "SELECT CertificationType FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                    Dim CertificationTypeCommand As New SqlCommand(CertificationTypeStatement, con)
                                    CertificationTypeCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    CertificationTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    CertificationTypeCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        SOPrice = CDbl(SOPriceCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        SOPrice = 0
                                    End Try
                                    Try
                                        SOLineComment = CStr(LineCommentCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        SOLineComment = ""
                                    End Try
                                    Try
                                        SODebitGLAccount = CStr(SODebitGLAccountCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        SODebitGLAccount = "20990"
                                    End Try
                                    Try
                                        SOCreditGLAccount = CStr(SOCreditGLAccountCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        SOCreditGLAccount = "12100"
                                    End Try
                                    Try
                                        SOLineBoxes = CDbl(SOLineBoxesCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        SOLineBoxes = 0
                                    End Try
                                    Try
                                        SOLineWeight = CDbl(SOLineWeightCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        SOLineWeight = 0
                                    End Try
                                    Try
                                        SalesOrderLineNumber = CInt(SOLineNumberCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        SalesOrderLineNumber = 0
                                    End Try
                                    Try
                                        CertificationType = CStr(CertificationTypeCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        CertificationType = "0"
                                    End Try
                                    con.Close()
                                    '************************************************************************************************************
                                    'Re-Calculate sales tax for quantity
                                    Dim GetTaxRate1 As Double = 0

                                    Dim GetTaxRate1Statement As String = "SELECT TaxRate1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                                    Dim GetTaxRate1Command As New SqlCommand(GetTaxRate1Statement, con)
                                    GetTaxRate1Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    GetTaxRate1Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        GetTaxRate1 = CDbl(GetTaxRate1Command.ExecuteScalar)
                                    Catch ex As Exception
                                        GetTaxRate1 = 0
                                    End Try
                                    con.Close()
                                    '************************************************************************************************************
                                    'Get Box Count from Item List to calculate Shipping Line Boxes
                                    Dim BoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                                    Dim BoxCountCommand As New SqlCommand(BoxCountStatement, con)
                                    BoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    BoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = POPartNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        BoxCount = CInt(BoxCountCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        BoxCount = 0
                                    End Try
                                    con.Close()

                                    'Calculate Piece Weight to determine Line Weight
                                    If SOQuantity = 0 Then
                                        'Skip
                                    Else
                                        ShippingPieceWeight = SOLineWeight / SOQuantity
                                        ShippingLineWeight = ShippingPieceWeight * POQuantity
                                    End If

                                    'Calculate number of boxes for PO Quantity
                                    If BoxCount = 0 Then
                                        LineBoxCount = 0
                                    Else
                                        LineBoxCount = Round(POQuantity / BoxCount, 0)
                                    End If

                                    'Get Drop Ship COS Account for receiver
                                    Dim DropShipCOSAccountStatement As String = "SELECT GLCOGSAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                                    Dim DropShipCOSAccountCommand As New SqlCommand(DropShipCOSAccountStatement, con)
                                    DropShipCOSAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        DropShipCOSAccount = CStr(DropShipCOSAccountCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        DropShipCOSAccount = "51000"
                                    End Try
                                    con.Close()

                                    'Verify GL Account
                                    If SOCreditGLAccount = "" Then
                                        SOCreditGLAccount = "12100"
                                    End If
                                    '************************************************************************************************************
                                    'Get Next Line Number for Receiver
                                    Dim MAXReceiverLineNumberStatement As String = "SELECT MAX(ReceivingLineKey) FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
                                    Dim MAXReceiverLineNumberCommand As New SqlCommand(MAXReceiverLineNumberStatement, con)
                                    MAXReceiverLineNumberCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = NextReceiverNumber
                                    MAXReceiverLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        LastReceiverLineNumber = CInt(MAXReceiverLineNumberCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        LastReceiverLineNumber = 0
                                    End Try
                                    con.Close()

                                    NextReceiverLineNumber = LastReceiverLineNumber + 1

                                    'Write Line Data to Receiving Line Table
                                    cmd = New SqlCommand("Insert Into ReceivingLineTable (ReceivingHeaderKey, ReceivingLineKey, PartNumber, PartDescription, QuantityReceived, UnitCost, ExtendedAmount, LineStatus, DivisionID, SelectForInvoice, DebitGLAccount, CreditGLAccount, POLineNumber, LineComment, DropShip) Values (@ReceivingHeaderKey, @ReceivingLineKey, @PartNumber, @PartDescription, @QuantityReceived, @UnitCost, @ExtendedAmount, @LineStatus, @DivisionID, @SelectForInvoice, @DebitGLAccount, @CreditGLAccount, @POLineNumber, @LineComment, @DropShip)", con)

                                    With cmd.Parameters
                                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = NextReceiverNumber
                                        .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = NextReceiverLineNumber
                                        .Add("@PartNumber", SqlDbType.VarChar).Value = POPartNumber
                                        .Add("@PartDescription", SqlDbType.VarChar).Value = POPartDescription
                                        .Add("@QuantityReceived", SqlDbType.VarChar).Value = POQuantity
                                        .Add("@UnitCost", SqlDbType.VarChar).Value = POUnitCost
                                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = POUnitCost * POQuantity
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "20990"
                                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = DropShipCOSAccount
                                        .Add("@POLineNumber", SqlDbType.VarChar).Value = POLineNumber
                                        .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                                        .Add("@DropShip", SqlDbType.VarChar).Value = "YES"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    '************************************************************************************************************
                                    ExtendedCOS = POQuantity * POUnitCost
                                    ExtendedCOS = Math.Round(ExtendedCOS, 2)

                                    'No line sales tax for Canadian
                                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                                        InvoiceLineSalesTax = 0
                                    Else
                                        If GetTaxRate1 <> 0 Then
                                            LineSalesTax = POQuantity * SOPrice * GetTaxRate1
                                            LineSalesTax = Math.Round(LineSalesTax, 2)
                                        Else
                                            LineSalesTax = 0
                                        End If
                                    End If
                                    '***********************************************************************************************
                                    Dim LineComplete As String = ""

                                    If POQuantity <= POOpenQuantity Then
                                        LineComplete = "NO"
                                    Else
                                        LineComplete = "YES"
                                    End If
                                    '***********************************************************************************************
                                    'Get Next Line Number for Shipment
                                    Dim MAXShipmentLineNumberStatement As String = "SELECT MAX(ShipmentLineNumber) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                                    Dim MAXShipmentLineNumberCommand As New SqlCommand(MAXShipmentLineNumberStatement, con)
                                    MAXShipmentLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                    MAXShipmentLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        LastShipmentLineNumber = CInt(MAXShipmentLineNumberCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        LastShipmentLineNumber = 0
                                    End Try
                                    con.Close()

                                    NextShipmentLineNumber = LastShipmentLineNumber + 1
                                    '***********************************************************************************************
                                    'Write Line Data to Shipment Line Table
                                    cmd = New SqlCommand("Insert Into ShipmentLineTable (ShipmentNumber, ShipmentLineNumber, PartNumber, PartDescription, QuantityShipped, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, GLDebitAccount, GLCreditAccount, CertificationType, ExtendedCOS, SOLineNumber, Dropship, SerialNumber, BoxWeight, LineComplete) Values (@ShipmentNumber, @ShipmentLineNumber, @PartNumber, @PartDescription, @QuantityShipped, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @GLDebitAccount, @GLCreditAccount, @CertificationType, @ExtendedCOS, @SOLineNumber, @Dropship, @SerialNumber, @BoxWeight, @LineComplete)", con)

                                    With cmd.Parameters
                                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = NextShipmentLineNumber
                                        .Add("@PartNumber", SqlDbType.VarChar).Value = POPartNumber
                                        .Add("@PartDescription", SqlDbType.VarChar).Value = POPartDescription
                                        .Add("@QuantityShipped", SqlDbType.VarChar).Value = POQuantity
                                        .Add("@Price", SqlDbType.VarChar).Value = SOPrice
                                        .Add("@LineComment", SqlDbType.VarChar).Value = SOLineComment
                                        .Add("@LineWeight", SqlDbType.VarChar).Value = ShippingLineWeight
                                        .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxCount
                                        .Add("@SalesTax", SqlDbType.VarChar).Value = LineSalesTax
                                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = POQuantity * SOPrice
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@GLDebitAccount", SqlDbType.VarChar).Value = SODebitGLAccount
                                        .Add("@GLCreditAccount", SqlDbType.VarChar).Value = SOCreditGLAccount
                                        .Add("@CertificationType", SqlDbType.VarChar).Value = CertificationType
                                        .Add("@ExtendedCOS", SqlDbType.VarChar).Value = ExtendedCOS
                                        .Add("@SOLineNumber", SqlDbType.VarChar).Value = SalesOrderLineNumber
                                        .Add("@Dropship", SqlDbType.VarChar).Value = "YES"
                                        .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                        .Add("@BoxWeight", SqlDbType.VarChar).Value = 0
                                        .Add("@LineComplete", SqlDbType.VarChar).Value = LineComplete
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    '************************************************************************************************************
                                    'Get Next Invoice Line Number
                                    Dim MAXInvoiceLineNumberStatement As String = "SELECT MAX(InvoiceLineKey) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey"
                                    Dim MAXInvoiceLineNumberCommand As New SqlCommand(MAXInvoiceLineNumberStatement, con)
                                    MAXInvoiceLineNumberCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = NextInvoiceNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        LastInvoiceLineNumber = CInt(MAXInvoiceLineNumberCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        LastInvoiceLineNumber = 0
                                    End Try
                                    con.Close()

                                    NextInvoiceLineNumber = LastInvoiceLineNumber + 1

                                    'Write lines to Invoice Line Table
                                    cmd = New SqlCommand("Insert Into InvoiceLineTable (InvoiceHeaderKey, InvoiceLineKey, PartNumber, PartDescription, QuantityBilled, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, ExtendedCOS, SOLineNumber, SerialNumber) Values (@InvoiceHeaderKey, @InvoiceLineKey, @PartNumber, @PartDescription, @QuantityBilled, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @ExtendedCOS, @SOLineNumber, @SerialNumber)", con)

                                    With cmd.Parameters
                                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = NextInvoiceNumber
                                        .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = NextInvoiceLineNumber
                                        .Add("@PartNumber", SqlDbType.VarChar).Value = POPartNumber
                                        .Add("@PartDescription", SqlDbType.VarChar).Value = POPartDescription
                                        .Add("@QuantityBilled", SqlDbType.VarChar).Value = POQuantity
                                        .Add("@Price", SqlDbType.VarChar).Value = SOPrice
                                        .Add("@LineComment", SqlDbType.VarChar).Value = SOLineComment
                                        .Add("@LineWeight", SqlDbType.VarChar).Value = ShippingLineWeight
                                        .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxCount
                                        .Add("@SalesTax", SqlDbType.VarChar).Value = LineSalesTax
                                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = POQuantity * SOPrice
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = SODebitGLAccount
                                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = SOCreditGLAccount
                                        .Add("@ExtendedCOS", SqlDbType.VarChar).Value = ExtendedCOS
                                        .Add("@SOLineNumber", SqlDbType.VarChar).Value = SalesOrderLineNumber
                                        .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    '****************************************************************************************************************************************
                                    'Verify Status
                                    Dim SOQuantityOpen As Integer = 0

                                    Dim SOQuantityOpenStatement As String = "SELECT QuantityOpen FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
                                    Dim SOQuantityOpenCommand As New SqlCommand(SOQuantityOpenStatement, con)
                                    SOQuantityOpenCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    SOQuantityOpenCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = SalesOrderLineNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        SOQuantityOpen = CInt(SOQuantityOpenCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        SOQuantityOpen = 0
                                    End Try
                                    con.Close()

                                    If SOQuantityOpen <= 0 Then
                                        SOLineStatus = "CLOSED"
                                    Else
                                        SOLineStatus = "DROPSHIP"
                                    End If

                                    'Update Sales Order Line Status
                                    cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus, EstExtendedCOS = @EstExtendedCOS WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                                    With cmd.Parameters
                                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                        .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = SalesOrderLineNumber
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = SOLineStatus
                                        .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = ExtendedCOS
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()

                                    Dim POQuantityOpenStatement As String = "SELECT POQuantityOpen FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber"
                                    Dim POQuantityOpenCommand As New SqlCommand(POQuantityOpenStatement, con)
                                    POQuantityOpenCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                    POQuantityOpenCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = POLineNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        POQuantityOpen = CInt(POQuantityOpenCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        POQuantityOpen = 0
                                    End Try
                                    con.Close()

                                    If POQuantityOpen <= 0 Then
                                        POLineStatus = "CLOSED"
                                    Else
                                        POLineStatus = "DROPSHIP"
                                    End If

                                    'Update Purchase Order Line Status
                                    cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                                    With cmd.Parameters
                                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                        .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = POLineNumber
                                        .Add("@LineStatus", SqlDbType.VarChar).Value = POLineStatus
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                End If
                            End If 'Close Loop End/If

                            'Dump variables used in loop before next reiteration
                            ExtendedCOS = 0
                            POPartNumber = ""
                            POPartDescription = ""
                            LineComment = ""
                            POOpenQuantity = 0
                            POQuantity = 0
                            POUnitCost = 0
                            POExtendedAmount = 0
                            POLineNumber = 0
                            CheckSOPart = 0
                        Next 'Close loop for adding line items

                        '************************************************************************************************************
                        'Load Lot Numbers (If any)
                        If cboVendorShipmentNumber.Text = "" Or Val(cboVendorShipmentNumber.Text) = 0 Or POVendorCode = "TWE" Then
                            'Skip Lot Number Routine
                        Else
                            LoadLotNumbers()
                        End If
                        '************************************************************************************************************
                        If Me.dgvLotNumbers.RowCount > 0 Then
                            Dim RowLotNumber As String = ""
                            Dim RowPullTestNumber As String = ""
                            Dim RowHeatQuantity As Double = 0
                            Dim GetRowPartNumber As String = ""
                            Dim GetNewShipmentLineNumber As Integer = 0
                            Dim GetNextLotLineNumber As Integer = 0
                            Dim GetLastLotLineNumber As Integer = 0
                            Dim GetRowHeatNumber As String = ""

                            'Get Lot Number data
                            For Each LotRow As DataGridViewRow In dgvLotNumbers.Rows
                                Try
                                    RowLotNumber = LotRow.Cells("LotNumberColumn").Value
                                Catch ex As Exception
                                    RowLotNumber = ""
                                End Try
                                Try
                                    RowPullTestNumber = LotRow.Cells("PullTestNumberColumn").Value
                                Catch ex As Exception
                                    RowPullTestNumber = ""
                                End Try
                                Try
                                    RowHeatQuantity = LotRow.Cells("HeatQuantityColumn").Value
                                Catch ex As Exception
                                    RowHeatQuantity = 0
                                End Try

                                'Get Part Number from Lot
                                Dim GetRowPartNumberStatement As String = "SELECT PartNumber FROM LotNumber WHERE LotNumber = @LotNumber"
                                Dim GetRowPartNumberCommand As New SqlCommand(GetRowPartNumberStatement, con)
                                GetRowPartNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber

                                Dim GetRowHeatNumberStatement As String = "SELECT HeatNumber FROM LotNumber WHERE LotNumber = @LotNumber"
                                Dim GetRowHeatNumberCommand As New SqlCommand(GetRowHeatNumberStatement, con)
                                GetRowHeatNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetRowPartNumber = CStr(GetRowPartNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetRowPartNumber = ""
                                End Try
                                Try
                                    GetRowHeatNumber = CStr(GetRowHeatNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetRowHeatNumber = ""
                                End Try
                                con.Close()

                                'Get Shipment Line Number from New Shipment for specific part
                                Dim GetNewShipmentLineNumberStatement As String = "SELECT ShipmentLineNumber FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                                Dim GetNewShipmentLineNumberCommand As New SqlCommand(GetNewShipmentLineNumberStatement, con)
                                GetNewShipmentLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                GetNewShipmentLineNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetRowPartNumber
                                GetNewShipmentLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetNewShipmentLineNumber = CInt(GetNewShipmentLineNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetNewShipmentLineNumber = 0
                                End Try
                                con.Close()

                                Dim GetLastLotLineNumberStatement As String = "SELECT MAX(LotLineNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                                Dim GetLastLotLineNumberCommand As New SqlCommand(GetLastLotLineNumberStatement, con)
                                GetLastLotLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                GetLastLotLineNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = GetNewShipmentLineNumber

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetLastLotLineNumber = CInt(GetLastLotLineNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetLastLotLineNumber = 0
                                End Try
                                con.Close()

                                GetNextLotLineNumber = GetLastLotLineNumber + 1
                                '************************************************************************************************************
                                Try
                                    'Run Shipment Line Lot Number Insert Routine
                                    cmd = New SqlCommand("INSERT INTO ShipmentLineLotNumbers (ShipmentNumber, ShipmentLineNumber, LotLineNumber, LotNumber, PullTestNumber, HeatQuantity) values (@ShipmentNumber, @ShipmentLineNumber, @LotLineNumber, @LotNumber, @PullTestNumber, @HeatQuantity)", con)

                                    With cmd.Parameters
                                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = GetNewShipmentLineNumber
                                        .Add("@LotLineNumber", SqlDbType.VarChar).Value = GetNextLotLineNumber
                                        .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                                        .Add("@PullTestNumber", SqlDbType.VarChar).Value = RowPullTestNumber
                                        .Add("@HeatQuantity", SqlDbType.VarChar).Value = RowHeatQuantity
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                    '************************************************************************************************************
                                    'Run Invoice Line Lot Number Insert Routine
                                    cmd = New SqlCommand("INSERT INTO InvoiceLotLineTable (InvoiceNumber, InvoiceLineNumber, InvoiceLotLineNumber, InvoiceLotNumber, InvoiceHeatNumber, InvoiceHeatQuantity) values (@InvoiceNumber, @InvoiceLineNumber, @InvoiceLotLineNumber, @InvoiceLotNumber, @InvoiceHeatNumber, @InvoiceHeatQuantity)", con)

                                    With cmd.Parameters
                                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextInvoiceNumber
                                        .Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = GetNewShipmentLineNumber
                                        .Add("@InvoiceLotLineNumber", SqlDbType.VarChar).Value = GetNextLotLineNumber
                                        .Add("@InvoiceLotNumber", SqlDbType.VarChar).Value = RowLotNumber
                                        .Add("@InvoiceHeatNumber", SqlDbType.VarChar).Value = GetRowHeatNumber
                                        .Add("@InvoiceHeatQuantity", SqlDbType.VarChar).Value = RowHeatQuantity
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Skip LOt Number
                                End Try
                                '************************************************************************************************************
                                'Clear Variables
                                RowLotNumber = ""
                                RowPullTestNumber = ""
                                RowHeatQuantity = 0
                                GetRowPartNumber = ""
                                GetNewShipmentLineNumber = 0
                                GetNextLotLineNumber = 0
                                GetLastLotLineNumber = 0
                                GetRowHeatNumber = ""
                            Next
                        Else
                            'Skip Lot Number Routine
                        End If
                        '************************************************************************************************************
                        'Update Receiver Header Totals
                        LoadReceiverTotal()

                        'Update Receiver Header
                        cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET ProductTotal = @ProductTotal, SalesTax = @SalesTax, POTotal = @POTotal, FreightCharge = @FreightCharge WHERE ReceivingHeaderKey = @ReceivingHeaderKey", con)

                        With cmd.Parameters
                            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = NextReceiverNumber
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = ReceiverSumExtendedAmount
                            .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                            .Add("@POTotal", SqlDbType.VarChar).Value = ReceiverTotal
                            .Add("@FreightCharge", SqlDbType.VarChar).Value = POFreightCharge
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Update Shipment Header Totals
                        LoadShipmentTotal()
                        LoadInvoiceTotal()

                        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                            GetCanadianTaxRates()

                            SalesTax1 = ShippingSumExtendedAmount * GSTRate
                            SalesTax2 = ShippingSumExtendedAmount * PSTRate
                            SalesTax3 = ShippingSumExtendedAmount * HSTRate

                            SalesTax1 = Math.Round(SalesTax1, 2)
                            SalesTax2 = Math.Round(SalesTax2, 2)
                            SalesTax3 = Math.Round(SalesTax3, 2)

                            ShipmentTotal = ShippingSumExtendedAmount + FreightCharge + SalesTax1 + SalesTax2 + SalesTax3
                            SumInvoiceTotal = SumExtendedAmount + FreightCharge + SalesTax1 + SalesTax2 + SalesTax3
                        Else
                            SalesTax1 = SumShippingSalesTax
                            'Convert Sum of Sales Tax - totals are correct
                        End If
                        '****************************************************************************************
                        Dim GetVendorPRONumber As String = ""

                        If cboVendorShipmentNumber.Text = "" Or Val(cboVendorShipmentNumber.Text) = 0 Then
                            'Skip PRO Number Routine
                        Else
                            'Get PRO # from vendor shipment
                            Dim GetVendorPRONumberStatement As String = "SELECT PRONumber FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
                            Dim GetVendorPRONumberCommand As New SqlCommand(GetVendorPRONumberStatement, con)
                            GetVendorPRONumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboVendorShipmentNumber.Text)

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetVendorPRONumber = CStr(GetVendorPRONumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetVendorPRONumber = ""
                            End Try
                            con.Close()
                        End If

                        'Update shipment
                        cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ProductTotal = @ProductTotal, TaxTotal = @TaxTotal, ShipmentTotal = @ShipmentTotal, FreightActualAmount = @FreightActualAmount, ShippingWeight = @ShippingWeight, Tax2Total = @Tax2Total, Tax3Total = @Tax3Total, PRONumber = @PRONumber WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = ShippingSumExtendedAmount
                            .Add("@TaxTotal", SqlDbType.VarChar).Value = SalesTax1
                            .Add("@ShipmentTotal", SqlDbType.VarChar).Value = ShipmentTotal
                            .Add("@FreightActualAmount", SqlDbType.VarChar).Value = FreightCharge
                            .Add("@ShippingWeight", SqlDbType.VarChar).Value = SumShippingWeight
                            .Add("@Tax2Total", SqlDbType.VarChar).Value = SalesTax2
                            .Add("@Tax3Total", SqlDbType.VarChar).Value = SalesTax3
                            .Add("@PRONumber", SqlDbType.VarChar).Value = GetVendorPRONumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Update Invoice Header
                        cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET ProductTotal = @ProductTotal, SalesTax = @SalesTax, InvoiceTotal = @InvoiceTotal, InvoiceCOS = @InvoiceCOS, BilledFreight = @BilledFreight, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3, PRONumber = @PRONumber WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextInvoiceNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
                            .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax1
                            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = SumInvoiceTotal
                            .Add("@InvoiceCOS", SqlDbType.VarChar).Value = SumExtendedCOS
                            .Add("@BilledFreight", SqlDbType.VarChar).Value = FreightCharge
                            .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
                            .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
                            .Add("@PRONumber", SqlDbType.VarChar).Value = GetVendorPRONumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Update Sales Order Header Status
                        Dim CountSOLinesString As String = "SELECT Count(SalesOrderKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey"
                        Dim CountSOLinesCommand As New SqlCommand(CountSOLinesString, con)
                        CountSOLinesCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountSOLines = CInt(CountSOLinesCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountSOLines = 0
                        End Try
                        con.Close()

                        SOLineNumber = 1

                        For i As Integer = 1 To CountSOLines
                            Dim LineStatusString As String = "SELECT LineStatus FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
                            Dim LineStatusCommand As New SqlCommand(LineStatusString, con)
                            LineStatusCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                            LineStatusCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = SOLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                SOLineStatus = CStr(LineStatusCommand.ExecuteScalar)
                            Catch ex As Exception
                                SOLineStatus = "OPEN"
                            End Try
                            con.Close()

                            If SOLineStatus <> "CLOSED" Then
                                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey", con)
                                With cmd.Parameters
                                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    .Add("@SOStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                Exit For  'Exit loop - if one line is open, then SO is still open
                            Else
                                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey", con)

                                With cmd.Parameters
                                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    .Add("@SOStatus", SqlDbType.VarChar).Value = "CLOSED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If

                            SOLineNumber = SOLineNumber + 1
                        Next i

                        'Update Purchase Order Header Status
                        Dim CountPOLinesString As String = "SELECT Count(PurchaseOrderHeaderKey) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
                        Dim CountPOLinesCommand As New SqlCommand(CountPOLinesString, con)
                        CountPOLinesCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountPOLines = CInt(CountPOLinesCommand.ExecuteScalar)
                        Catch ex As Exception
                            CountPOLines = 0
                        End Try
                        con.Close()

                        POLineNumber = 1

                        For i As Integer = 1 To CountPOLines
                            Dim POLineStatusString As String = "SELECT LineStatus FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber"
                            Dim POLineStatusCommand As New SqlCommand(POLineStatusString, con)
                            POLineStatusCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                            POLineStatusCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = POLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                POLineStatus = CStr(POLineStatusCommand.ExecuteScalar)
                            Catch ex As Exception
                                POLineStatus = "DROPSHIP"
                            End Try
                            con.Close()

                            If POLineStatus <> "CLOSED" Then
                                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
                                With cmd.Parameters
                                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                    .Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                Exit For  'Exit loop - if one line is open, then SO is still open
                            Else
                                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)

                                With cmd.Parameters
                                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                    .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If
                            POLineNumber = POLineNumber + 1
                        Next i

                        'Load Batch Totals and Update Batch
                        Dim BatchAmountString As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                        Dim BatchAmountCommand As New SqlCommand(BatchAmountString, con)
                        BatchAmountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                        BatchAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            BatchAmount = CDbl(BatchAmountCommand.ExecuteScalar)
                        Catch ex As Exception
                            BatchAmount = 0
                        End Try
                        con.Close()

                        Try
                            'Create Invoice Batch
                            cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Do nothing if batch is already created
                        End Try

                        'Check Lines to close PO and set SO to Invoiced

                        'Default message
                        MsgBox("Invoice created for this drop ship.", MsgBoxStyle.OkOnly)

                        'Clear form and clear variables for next entry
                        ClearVariables()
                        ClearForNextEntry()
                        ShowDataByPO()
                        LoadPurchaseOrderNumber()
                    ElseIf button = DialogResult.No Then
                        'Do nothing 
                    End If
                Else
                    'Create Invoice Batch Form
                    Try
                        cmd = New SqlCommand("Insert Into InvoiceProcessingBatchHeader (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, UserID) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @UserID)", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                            .Add("@BatchDate", SqlDbType.VarChar).Value = ShipDate
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = "PO Drop Ship Invoicing"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, DivisionID = @DivisionID, BatchStatus = @BatchStatus, UserID = @UserID WHERE BatchNumber = @BatchNumber", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                            .Add("@BatchDate", SqlDbType.VarChar).Value = ShipDate
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = "PO Drop Ship Invoicing"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Try
                    '**********************************************************************************************************************
                    'Get PO Data to create Receiver
                    Dim PODate As String

                    Dim GetPODataString As String = "SELECT * FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
                    Dim GetPODataCommand As New SqlCommand(GetPODataString, con)
                    GetPODataCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    GetPODataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim reader As SqlDataReader = GetPODataCommand.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.Item("VendorID")) Then
                            VendorID = ""
                        Else
                            VendorID = reader.Item("VendorID")
                        End If
                        If IsDBNull(reader.Item("POHeaderComment")) Then
                            POHeaderComment = ""
                        Else
                            POHeaderComment = reader.Item("POHeaderComment")
                        End If
                        If IsDBNull(reader.Item("PODate")) Then
                            PODate = ""
                        Else
                            PODate = reader.Item("PODate")
                        End If
                        If IsDBNull(reader.Item("ShipMethodID")) Then
                            ShipMethodID = ""
                        Else
                            ShipMethodID = reader.Item("ShipMethodID")
                        End If
                        If IsDBNull(reader.Item("FreightCharge")) Then
                            POFreightCharge = 0
                        Else
                            POFreightCharge = reader.Item("FreightCharge")
                        End If
                        If IsDBNull(reader.Item("DropShipSalesOrderNumber")) Then
                            SalesOrderNumber = 0
                        Else
                            SalesOrderNumber = reader.Item("DropShipSalesOrderNumber")
                        End If
                    Else
                        VendorID = ""
                        POHeaderComment = ""
                        PODate = ""
                        ShipMethodID = ""
                        POFreightCharge = 0
                        SalesOrderNumber = 0
                    End If
                    reader.Close()
                    con.Close()
                    '*******************************************************************************************
                    Dim GetSODataString As String = "SELECT * FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                    Dim GetSODataCommand As New SqlCommand(GetSODataString, con)
                    GetSODataCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                    GetSODataCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim reader2 As SqlDataReader = GetSODataCommand.ExecuteReader()
                    If reader2.HasRows Then
                        reader2.Read()
                        If IsDBNull(reader2.Item("CustomerID")) Then
                            CustomerID = ""
                        Else
                            CustomerID = reader2.Item("CustomerID")
                        End If
                        If IsDBNull(reader2.Item("CustomerPO")) Then
                            CustomerPO = ""
                        Else
                            CustomerPO = reader2.Item("CustomerPO")
                        End If
                        If IsDBNull(reader2.Item("ShipVia")) Then
                            ShipVia = ""
                        Else
                            ShipVia = reader2.Item("ShipVia")
                        End If
                        If IsDBNull(reader2.Item("HeaderComment")) Then
                            HeaderComment = ""
                        Else
                            HeaderComment = reader2.Item("HeaderComment")
                        End If
                        If IsDBNull(reader2.Item("PRONumber")) Then
                            PRONumber = ""
                        Else
                            PRONumber = reader2.Item("PRONumber")
                        End If
                        If IsDBNull(reader2.Item("SpecialInstructions")) Then
                            SpecialInstructions = ""
                        Else
                            SpecialInstructions = reader2.Item("SpecialInstructions")
                        End If
                        If IsDBNull(reader2.Item("Salesperson")) Then
                            Salesperson = ""
                        Else
                            Salesperson = reader2.Item("Salesperson")
                        End If
                        If IsDBNull(reader2.Item("FreightCharge")) Then
                            FreightCharge = 0
                        Else
                            FreightCharge = reader2.Item("FreightCharge")
                        End If
                        If IsDBNull(reader2.Item("QuoteNumber")) Then
                            QuoteNumber = ""
                        Else
                            QuoteNumber = reader2.Item("QuoteNumber")
                        End If
                        If IsDBNull(reader2.Item("QuotedFreight")) Then
                            QuotedFreight = 0
                        Else
                            QuotedFreight = reader2.Item("QuotedFreight")
                        End If
                        If IsDBNull(reader2.Item("ShippingWeight")) Then
                            ShippingWeight = 0
                        Else
                            ShippingWeight = reader2.Item("ShippingWeight")
                        End If
                        If IsDBNull(reader2.Item("TotalSalesTax")) Then
                            TotalSalesTax = 0
                        Else
                            TotalSalesTax = reader2.Item("TotalSalesTax")
                        End If
                        If IsDBNull(reader2.Item("ShippingMethod")) Then
                            ShippingMethod = ""
                        Else
                            ShippingMethod = reader2.Item("ShippingMethod")
                        End If
                        If IsDBNull(reader2.Item("ThirdPartyShipper")) Then
                            ThirdPartyShipper = ""
                        Else
                            ThirdPartyShipper = reader2.Item("ThirdPartyShipper")
                        End If
                        If IsDBNull(reader2.Item("ShipEmail")) Then
                            ShipEmail = ""
                        Else
                            ShipEmail = reader2.Item("ShipEmail")
                        End If
                        If IsDBNull(reader2.Item("ShippingAccount")) Then
                            ShippingAccount = ""
                        Else
                            ShippingAccount = reader2.Item("ShippingAccount")
                        End If
                        If IsDBNull(reader2.Item("ShipToName")) Then
                            STName = ""
                        Else
                            STName = reader2.Item("ShipToName")
                        End If
                        If IsDBNull(reader2.Item("ShipToAddress1")) Then
                            STAddress1 = ""
                        Else
                            STAddress1 = reader2.Item("ShipToAddress1")
                        End If
                        If IsDBNull(reader2.Item("ShipToAddress2")) Then
                            STAddress2 = ""
                        Else
                            STAddress2 = reader2.Item("ShipToAddress2")
                        End If
                        If IsDBNull(reader2.Item("ShipToCity")) Then
                            STCity = ""
                        Else
                            STCity = reader2.Item("ShipToCity")
                        End If
                        If IsDBNull(reader2.Item("ShipToState")) Then
                            STState = ""
                        Else
                            STState = reader2.Item("ShipToState")
                        End If
                        If IsDBNull(reader2.Item("ShipToZip")) Then
                            STZipCode = ""
                        Else
                            STZipCode = reader2.Item("ShipToZip")
                        End If
                        If IsDBNull(reader2.Item("ShipToCountry")) Then
                            STCountry = ""
                        Else
                            STCountry = reader2.Item("ShipToCountry")
                        End If
                    Else
                        CustomerID = ""
                        CustomerPO = ""
                        ShipVia = ""
                        HeaderComment = ""
                        PRONumber = ""
                        SpecialInstructions = ""
                        Salesperson = ""
                        FreightCharge = 0
                        QuoteNumber = ""
                        QuotedFreight = 0
                        ShippingWeight = 0
                        TotalSalesTax = 0
                        ShippingMethod = "OTHER"
                        ThirdPartyShipper = ""
                        ShipEmail = ""
                        ShippingAccount = ""
                        STName = ""
                        STAddress1 = ""
                        STAddress2 = ""
                        STCity = ""
                        STState = ""
                        STZipCode = ""
                        STCountry = ""
                    End If
                    reader2.Close()
                    con.Close()
                    '***********************************************************************************************
                    'Extract Data from Customer Data to write to Invoice Table
                    Dim BillToAddress1Statement As String = "SELECT BillToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                    Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
                    BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                    BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim BillToAddress2Statement As String = "SELECT BillToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                    Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
                    BillToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                    BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim BillToCityStatement As String = "SELECT BillToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                    Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
                    BillToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                    BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim BillToStateStatement As String = "SELECT BillToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                    Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
                    BillToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                    BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim BillToZipStatement As String = "SELECT BillToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                    Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
                    BillToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                    BillToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim BillToCountryStatement As String = "SELECT BillToCountry FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                    Dim BillToCountryCommand As New SqlCommand(BillToCountryStatement, con)
                    BillToCountryCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                    BillToCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                    Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
                    PaymentTermsCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                    PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim CustomerTaxRateStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                    Dim CustomerTaxRateCommand As New SqlCommand(CustomerTaxRateStatement, con)
                    CustomerTaxRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                    CustomerTaxRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim CustomerClassStatement As String = "SELECT CustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                    Dim CustomerClassCommand As New SqlCommand(CustomerClassStatement, con)
                    CustomerClassCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                    CustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        BTAddress1 = CStr(BillToAddress1Command.ExecuteScalar)
                    Catch ex As Exception
                        BTAddress1 = ""
                    End Try
                    Try
                        BTAddress2 = CStr(BillToAddress2Command.ExecuteScalar)
                    Catch ex As Exception
                        BTAddress2 = ""
                    End Try
                    Try
                        BTCity = CStr(BillToCityCommand.ExecuteScalar)
                    Catch ex As Exception
                        BTCity = ""
                    End Try
                    Try
                        BTState = CStr(BillToStateCommand.ExecuteScalar)
                    Catch ex As Exception
                        BTState = ""
                    End Try
                    Try
                        BTZipCode = CStr(BillToZipCommand.ExecuteScalar)
                    Catch ex As Exception
                        BTZipCode = ""
                    End Try
                    Try
                        BTCountry = CStr(BillToCountryCommand.ExecuteScalar)
                    Catch ex As Exception
                        BTCountry = ""
                    End Try
                    Try
                        PaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
                    Catch ex As Exception
                        PaymentTerms = ""
                    End Try
                    Try
                        SalesTaxRate = CDbl(CustomerTaxRateCommand.ExecuteScalar)
                    Catch ex As Exception
                        SalesTaxRate = 0
                    End Try
                    Try
                        CustomerClass = CStr(CustomerClassCommand.ExecuteScalar)
                    Catch ex As Exception
                        CustomerClass = "STANDARD"
                    End Try
                    con.Close()
                    '********************************************************************************************************
                    'Create New Receiver for Drop Ship PO
                    Dim MAXReceiverNumberStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingHeaderTable"
                    Dim MAXReceiverNumberCommand As New SqlCommand(MAXReceiverNumberStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastReceiverNumber = CInt(MAXReceiverNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastReceiverNumber = 0
                    End Try
                    con.Close()

                    NextReceiverNumber = LastReceiverNumber + 1

                    Try
                        'Write to Receiving Header Table
                        cmd = New SqlCommand("Insert Into ReceivingHeaderTable (ReceivingHeaderKey, PONumber, VendorCode, ReceivingDate, InvoiceNumber, HeaderComment, PODate, ShipMethodID, FreightCharge, SalesTax, ProductTotal, POTotal, Status, DivisionID, TransferDivision, ReceivingAgent, Locked, PrintDate)Values(@ReceivingHeaderKey, @PONumber, @VendorCode, @ReceivingDate, @InvoiceNumber, @HeaderComment, @PODate, @ShipMethodID, @FreightCharge, @SalesTax, @ProductTotal, @POTotal, @Status, @DivisionID, @TransferDivision, @ReceivingAgent, @Locked, @PrintDate)", con)

                        With cmd.Parameters
                            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = NextReceiverNumber
                            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                            .Add("@VendorCode", SqlDbType.VarChar).Value = VendorID
                            .Add("@ReceivingDate", SqlDbType.VarChar).Value = ShipDate
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = "DROP SHIP - AUTO"
                            .Add("@HeaderComment", SqlDbType.VarChar).Value = POHeaderComment
                            .Add("@PODate", SqlDbType.VarChar).Value = PODate
                            .Add("@ShipMethodID", SqlDbType.VarChar).Value = ShipMethodID
                            .Add("@FreightCharge", SqlDbType.VarChar).Value = POFreightCharge
                            .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                            .Add("@POTotal", SqlDbType.VarChar).Value = 0
                            .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TransferDivision", SqlDbType.VarChar).Value = ""
                            .Add("@ReceivingAgent", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber As String
                        TempReceiverNumber = NextReceiverNumber
                        strReceiverNumber = CStr(TempReceiverNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Drop Ship Invoicing --- Insert Receiver Header on Process "
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        MsgBox("Error creating receiver. This process will exit.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End Try
                    '*****************************************************************************************************
                    'Create Drop Shipment in Shipment Header Table
                    Dim MAXShipmentNumberStatement As String = "SELECT MAX(ShipmentNumber) FROM ShipmentHeaderTable"
                    Dim MAXShipmentNumberCommand As New SqlCommand(MAXShipmentNumberStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastShipmentNumber = CInt(MAXShipmentNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastShipmentNumber = 0
                    End Try
                    con.Close()

                    NextShipmentNumber = LastShipmentNumber + 1

                    Try
                        'Write to Shipment Header Table
                        cmd = New SqlCommand("Insert Into ShipmentHeaderTable (ShipmentNumber, SalesOrderKey, ShipDate, DivisionID, Comment, PickTicketNumber, ShipVia, PRONumber, FreightQuoteNumber, FreightQuoteAmount, FreightActualAmount, ShippingWeight, NumberOfPallets, CustomerID, ShipToID, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZip, ShipCountry, CustomerPO, ShipmentStatus, ProductTotal, TaxTotal, ShipmentTotal, BatchNumber, SpecialInstructions, SalesmanID, Tax2Total, Tax3Total, CertsAutoGenerated, SOLog, PulledBy, CertsPulled, PackingSlip, Locked, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper, ShipToName, ShipEmail, ShippingAccount)Values (@ShipmentNumber, @SalesOrderKey, @ShipDate, @DivisionID, @Comment, @PickTicketNumber, @ShipVia, @PRONumber, @FreightQuoteNumber, @FreightQuoteAmount, @FreightActualAmount, @ShippingWeight, @NumberOfPallets, @CustomerID, @ShipToID, @ShipAddress1, @ShipAddress2, @ShipCity, @ShipState, @ShipZip, @ShipCountry, @CustomerPO, @ShipmentStatus, @ProductTotal, @TaxTotal, @ShipmentTotal, @BatchNumber, @SpecialInstructions, @SalesmanID, @Tax2Total, @Tax3Total, @CertsAutoGenerated, @SOLog, @PulledBy, @CertsPulled, @PackingSlip, @Locked, @CustomerClass, @FOB, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @ShipEmail, @ShippingAccount)", con)

                        With cmd.Parameters
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                            .Add("@ShipDate", SqlDbType.VarChar).Value = ShipDate
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Comment", SqlDbType.VarChar).Value = HeaderComment
                            .Add("@PickTicketNumber", SqlDbType.VarChar).Value = NextReceiverNumber
                            .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                            .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                            .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = QuoteNumber
                            .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = QuotedFreight
                            .Add("@FreightActualAmount", SqlDbType.VarChar).Value = FreightCharge
                            .Add("@ShippingWeight", SqlDbType.VarChar).Value = ShippingWeight
                            .Add("@NumberOfPallets", SqlDbType.VarChar).Value = 1
                            .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                            .Add("@ShipToID", SqlDbType.VarChar).Value = ""
                            .Add("@ShipAddress1", SqlDbType.VarChar).Value = STAddress1
                            .Add("@ShipAddress2", SqlDbType.VarChar).Value = STAddress2
                            .Add("@ShipCity", SqlDbType.VarChar).Value = STCity
                            .Add("@ShipState", SqlDbType.VarChar).Value = STState
                            .Add("@ShipZip", SqlDbType.VarChar).Value = STZipCode
                            .Add("@ShipCountry", SqlDbType.VarChar).Value = STCountry
                            .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                            .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                            .Add("@TaxTotal", SqlDbType.VarChar).Value = TotalSalesTax
                            .Add("@ShipmentTotal", SqlDbType.VarChar).Value = 0
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = "DROPSHIP"
                            .Add("@SalesmanID", SqlDbType.VarChar).Value = Salesperson
                            .Add("@Tax2Total", SqlDbType.VarChar).Value = 0
                            .Add("@Tax3Total", SqlDbType.VarChar).Value = 0
                            .Add("@CertsAutoGenerated", SqlDbType.VarChar).Value = "NO"
                            .Add("@SOLog", SqlDbType.VarChar).Value = ""
                            .Add("@PulledBy", SqlDbType.VarChar).Value = ""
                            .Add("@CertsPulled", SqlDbType.VarChar).Value = ""
                            .Add("@PackingSlip", SqlDbType.VarChar).Value = ""
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                            .Add("@FOB", SqlDbType.VarChar).Value = "DROPSHIP"
                            .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShippingMethod
                            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ThirdPartyShipper
                            .Add("@ShipToName", SqlDbType.VarChar).Value = STName
                            .Add("@ShipEmail", SqlDbType.VarChar).Value = ShipEmail
                            .Add("@ShippingAccount", SqlDbType.VarChar).Value = ShippingAccount
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        Dim TempShipmentNumber As Integer = 0
                        Dim strShipmentNumber As String = ""
                        TempShipmentNumber = NextShipmentNumber
                        strShipmentNumber = CStr(TempShipmentNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Drop Ship Invoicing --- Insert Shipment Header on Process "
                        ErrorReferenceNumber = "Receiver # " + strShipmentNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        MsgBox("Error creating shipment. This process will exit.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End Try
                    '*****************************************************************************************************
                    'Get Next Invoice Number
                    Dim MAXInvoiceNumberStatement As String = "SELECT MAX(InvoiceNumber) FROM InvoiceHeaderTable"
                    Dim MAXInvoiceNumberCommand As New SqlCommand(MAXInvoiceNumberStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastInvoiceNumber = CInt(MAXInvoiceNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastInvoiceNumber = 0
                    End Try
                    con.Close()

                    NextInvoiceNumber = LastInvoiceNumber + 1

                    Try
                        'Create Invoice Header record
                        cmd = New SqlCommand("Insert Into InvoiceHeaderTable (InvoiceNumber, BatchNumber, InvoiceDate, SalesOrderNumber, ShipmentNumber, DivisionID, CustomerID, CustomerPO, PaymentTerms, Comment, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, ProductTotal, BilledFreight, SalesTax, Discount, InvoiceTotal, InvoiceStatus, ShipVia, PaymentsApplied, InvoiceCOS, PRONumber, SpecialInstructions, DropShipPONumber, SalesTax2, SalesTax3, ReprintBatch, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper) Values (@InvoiceNumber, @BatchNumber, @InvoiceDate, @SalesOrderNumber, @ShipmentNumber, @DivisionID, @CustomerID, @CustomerPO, @PaymentTerms, @Comment, @BTAddress1, @BTAddress2, @BTCity, @BTState, @BTZip, @BTCountry, @ProductTotal, @BilledFreight, @SalesTax, @Discount, @InvoiceTotal, @InvoiceStatus, @ShipVia, @PaymentsApplied, @InvoiceCOS, @PRONumber, @SpecialInstructions, @DropShipPONumber, @SalesTax2, @SalesTax3, @ReprintBatch, @CustomerClass, @FOB, @ShippingMethod, @ThirdPartyShipper)", con)

                        With cmd.Parameters
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextInvoiceNumber
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = ShipDate
                            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = SalesOrderNumber
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                            .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                            .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
                            .Add("@Comment", SqlDbType.VarChar).Value = HeaderComment
                            .Add("@BTAddress1", SqlDbType.VarChar).Value = BTAddress1
                            .Add("@BTAddress2", SqlDbType.VarChar).Value = BTAddress2
                            .Add("@BTCity", SqlDbType.VarChar).Value = BTCity
                            .Add("@BTState", SqlDbType.VarChar).Value = BTState
                            .Add("@BTZip", SqlDbType.VarChar).Value = BTZipCode
                            .Add("@BTCountry", SqlDbType.VarChar).Value = BTCountry
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                            .Add("@BilledFreight", SqlDbType.VarChar).Value = FreightCharge
                            .Add("@SalesTax", SqlDbType.VarChar).Value = TotalSalesTax
                            .Add("@Discount", SqlDbType.VarChar).Value = 0
                            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
                            .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
                            .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                            .Add("@PaymentsApplied", SqlDbType.VarChar).Value = 0
                            .Add("@InvoiceCOS", SqlDbType.VarChar).Value = 0
                            .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = "DROPSHIP"
                            .Add("@DropShipPONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                            .Add("@SalesTax2", SqlDbType.VarChar).Value = 0
                            .Add("@SalesTax3", SqlDbType.VarChar).Value = 0
                            .Add("@ReprintBatch", SqlDbType.VarChar).Value = ""
                            .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                            .Add("@FOB", SqlDbType.VarChar).Value = "DROPSHIP"
                            .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShippingMethod
                            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ThirdPartyShipper
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String = ""
                        TempInvoiceNumber = NextInvoiceNumber
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Drop Ship Invoicing --- Insert Invoice Header on Process "
                        ErrorReferenceNumber = "Receiver # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        MsgBox("Error creating Invoice. This process will exit.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End Try

                    '**************************************************************************************
                    'Line Routine
                    '**************************************************************************************
                    'Extract data from the selected items in the grid to create invoices in the Batch
                    For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
                        Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoice")
                        'Declare variables
                        Dim POPartNumber, POPartDescription, LineComment As String
                        Dim POOpenQuantity, POQuantity, POUnitCost, POExtendedAmount As Double
                        Dim POLineNumber As Integer = 0
                        Dim CheckSOPart As Integer = 0

                        If cell.Value = "SELECTED" Then
                            Try
                                POPartNumber = row.Cells("PartNumberColumn").Value
                            Catch ex As Exception
                                POPartNumber = ""
                            End Try
                            Try
                                POPartDescription = row.Cells("PartDescriptionColumn").Value
                            Catch ex As Exception
                                POPartDescription = ""
                            End Try
                            Try
                                POQuantity = row.Cells("QuantityOpenEditModeColumn").Value
                            Catch ex As Exception
                                POQuantity = 0
                            End Try
                            Try
                                POOpenQuantity = row.Cells("POQuantityOpenColumn").Value
                            Catch ex As Exception
                                POOpenQuantity = 0
                            End Try
                            Try
                                POUnitCost = row.Cells("UnitCostColumn").Value
                            Catch ex As Exception
                                POUnitCost = 0
                            End Try
                            Try
                                POExtendedAmount = row.Cells("OpenAmountColumn").Value
                            Catch ex As Exception
                                POExtendedAmount = 0
                            End Try
                            Try
                                POLineNumber = row.Cells("PurchaseOrderLineNumberColumn").Value
                            Catch ex As Exception
                                POLineNumber = 1
                            End Try
                            Try
                                LineComment = row.Cells("LineCommentColumn").Value
                            Catch ex As Exception
                                LineComment = ""
                            End Try
                            '************************************************************************************************************
                            'Verify that there is a part on the Sales Order with the same quantity
                            Dim CheckSOPartStatement As String = "SELECT SalesOrderLineKey FROM SalesOrderQuantityStatus WHERE ItemID = @ItemID AND DivisionKey = @DivisionKey AND QuantityOpen = @QuantityOpen AND SalesOrderKey = @SalesOrderKey"
                            Dim CheckSOPartCommand As New SqlCommand(CheckSOPartStatement, con)
                            CheckSOPartCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                            CheckSOPartCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = POPartNumber
                            CheckSOPartCommand.Parameters.Add("@QuantityOpen", SqlDbType.VarChar).Value = POOpenQuantity
                            CheckSOPartCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                CheckSOPart = CInt(CheckSOPartCommand.ExecuteScalar)
                            Catch ex As Exception
                                CheckSOPart = 0
                            End Try
                            con.Close()

                            If CheckSOPart <> 0 Then
                                'Continue
                            Else
                                MsgBox("The Sales Order and Purchase Order must match for Drop Ships. Check part and quantity and try again.", MsgBoxStyle.OkOnly)
                                'Delete Invoice, Shipment, and Receiver and exit subroutine
                                '************************************************************************************************************
                                'Delete Receiver
                                cmd = New SqlCommand("DELETE FROM ReceivingHeaderTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID AND Status = @Status", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = NextReceiverNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                '************************************************************************************************************
                                'Delete Shipment
                                cmd = New SqlCommand("DELETE FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID AND ShipmentStatus = @ShipmentStatus", con)

                                With cmd.Parameters
                                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                '************************************************************************************************************
                                'Delete Invoice
                                cmd = New SqlCommand("DELETE FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID AND InvoiceStatus = @InvoiceStatus", con)

                                With cmd.Parameters
                                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextInvoiceNumber
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                Exit Sub
                            End If
                            '************************************************************************************************************
                            'If PO Quantity = 0 then do not write line into receiver, shipper, or Invoice
                            If POQuantity = 0 Then
                                'Skip Line
                            Else
                                'Get Item Class for Part Number
                                Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                                Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                                GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = POPartNumber

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                                Catch ex As Exception
                                    GetItemClass = "TW CA"
                                End Try
                                con.Close()
                                '************************************************************************************************************
                                'Extract Sales Order Data from Line Table
                                Dim SOPriceStatement As String = "SELECT Price FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                Dim SOPriceCommand As New SqlCommand(SOPriceStatement, con)
                                SOPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                SOPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                SOPriceCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                Dim LineCommentStatement As String = "SELECT LineComment FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                Dim LineCommentCommand As New SqlCommand(LineCommentStatement, con)
                                LineCommentCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                LineCommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                LineCommentCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                Dim SODebitGLAccountStatement As String = "SELECT DebitGLAccount FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                Dim SODebitGLAccountCommand As New SqlCommand(SODebitGLAccountStatement, con)
                                SODebitGLAccountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                SODebitGLAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                SODebitGLAccountCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                Dim SOCreditGLAccountStatement As String = "SELECT CreditGLAccount FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                Dim SOCreditGLAccountCommand As New SqlCommand(SOCreditGLAccountStatement, con)
                                SOCreditGLAccountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                SOCreditGLAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                SOCreditGLAccountCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                Dim SOLineBoxesStatement As String = "SELECT LineBoxes FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                Dim SOLineBoxesCommand As New SqlCommand(SOLineBoxesStatement, con)
                                SOLineBoxesCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                SOLineBoxesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                SOLineBoxesCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                Dim SOLineWeightStatement As String = "SELECT OpenLineWeight FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey AND SalesOrderLineKey = @SalesOrderLineKey"
                                Dim SOLineWeightCommand As New SqlCommand(SOLineWeightStatement, con)
                                SOLineWeightCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                SOLineWeightCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                                SOLineWeightCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                Dim SOLineNumberStatement As String = "SELECT SalesOrderLineKey FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                Dim SOLineNumberCommand As New SqlCommand(SOLineNumberStatement, con)
                                SOLineNumberCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                SOLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                SOLineNumberCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                Dim CertificationTypeStatement As String = "SELECT CertificationType FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
                                Dim CertificationTypeCommand As New SqlCommand(CertificationTypeStatement, con)
                                CertificationTypeCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                CertificationTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                CertificationTypeCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = POLineNumber

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    SOPrice = CDbl(SOPriceCommand.ExecuteScalar)
                                Catch ex As Exception
                                    SOPrice = 0
                                End Try
                                Try
                                    SOLineComment = CStr(LineCommentCommand.ExecuteScalar)
                                Catch ex As Exception
                                    SOLineComment = ""
                                End Try
                                Try
                                    SODebitGLAccount = CStr(SODebitGLAccountCommand.ExecuteScalar)
                                Catch ex As Exception
                                    SODebitGLAccount = "20990"
                                End Try
                                Try
                                    SOCreditGLAccount = CStr(SOCreditGLAccountCommand.ExecuteScalar)
                                Catch ex As Exception
                                    SOCreditGLAccount = "12100"
                                End Try
                                Try
                                    SOLineBoxes = CDbl(SOLineBoxesCommand.ExecuteScalar)
                                Catch ex As Exception
                                    SOLineBoxes = 0
                                End Try
                                Try
                                    SOLineWeight = CDbl(SOLineWeightCommand.ExecuteScalar)
                                Catch ex As Exception
                                    SOLineWeight = 0
                                End Try
                                Try
                                    SalesOrderLineNumber = CInt(SOLineNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    SalesOrderLineNumber = 0
                                End Try
                                Try
                                    CertificationType = CStr(CertificationTypeCommand.ExecuteScalar)
                                Catch ex As Exception
                                    CertificationType = "0"
                                End Try
                                con.Close()
                                '************************************************************************************************************
                                'Get Box Count from Item List to calculate Shipping Line Boxes
                                Dim BoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                                Dim BoxCountCommand As New SqlCommand(BoxCountStatement, con)
                                BoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                BoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = POPartNumber

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    BoxCount = CInt(BoxCountCommand.ExecuteScalar)
                                Catch ex As Exception
                                    BoxCount = 0
                                End Try
                                con.Close()
                                '************************************************************************************************************
                                'Re-Calculate sales tax for quantity
                                Dim GetTaxRate1 As Double = 0

                                Dim GetTaxRate1Statement As String = "SELECT TaxRate1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                                Dim GetTaxRate1Command As New SqlCommand(GetTaxRate1Statement, con)
                                GetTaxRate1Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                GetTaxRate1Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetTaxRate1 = CDbl(GetTaxRate1Command.ExecuteScalar)
                                Catch ex As Exception
                                    GetTaxRate1 = 0
                                End Try
                                con.Close()
                                '************************************************************************************************************
                                'Calculate Piece Weight to determine Line Weight
                                If SOQuantity = 0 Then
                                    'Skip
                                Else
                                    ShippingPieceWeight = SOLineWeight / SOQuantity
                                    ShippingLineWeight = ShippingPieceWeight * POQuantity
                                End If

                                'Calculate number of boxes for PO Quantity
                                If BoxCount = 0 Then
                                    LineBoxCount = 0
                                Else
                                    LineBoxCount = Round(POQuantity / BoxCount, 0)
                                End If

                                'Get Drop Ship COS Account for receiver
                                Dim DropShipCOSAccountStatement As String = "SELECT GLCOGSAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                                Dim DropShipCOSAccountCommand As New SqlCommand(DropShipCOSAccountStatement, con)
                                DropShipCOSAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    DropShipCOSAccount = CStr(DropShipCOSAccountCommand.ExecuteScalar)
                                Catch ex As Exception
                                    DropShipCOSAccount = "51000"
                                End Try
                                con.Close()

                                'Verify GL Account
                                If SOCreditGLAccount = "" Then
                                    SOCreditGLAccount = "12100"
                                End If
                                '************************************************************************************************************
                                'Get Next Line Number for Receiver
                                Dim MAXReceiverLineNumberStatement As String = "SELECT MAX(ReceivingLineKey) FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID"
                                Dim MAXReceiverLineNumberCommand As New SqlCommand(MAXReceiverLineNumberStatement, con)
                                MAXReceiverLineNumberCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = NextReceiverNumber
                                MAXReceiverLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    LastReceiverLineNumber = CInt(MAXReceiverLineNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    LastReceiverLineNumber = 0
                                End Try
                                con.Close()

                                NextReceiverLineNumber = LastReceiverLineNumber + 1

                                'Write Line Data to Receiving Line Table
                                cmd = New SqlCommand("Insert Into ReceivingLineTable (ReceivingHeaderKey, ReceivingLineKey, PartNumber, PartDescription, QuantityReceived, UnitCost, ExtendedAmount, LineStatus, DivisionID, SelectForInvoice, DebitGLAccount, CreditGLAccount, POLineNumber, LineComment, DropShip) Values (@ReceivingHeaderKey, @ReceivingLineKey, @PartNumber, @PartDescription, @QuantityReceived, @UnitCost, @ExtendedAmount, @LineStatus, @DivisionID, @SelectForInvoice, @DebitGLAccount, @CreditGLAccount, @POLineNumber, @LineComment, @DropShip)", con)

                                With cmd.Parameters
                                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = NextReceiverNumber
                                    .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = NextReceiverLineNumber
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = POPartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = POPartDescription
                                    .Add("@QuantityReceived", SqlDbType.VarChar).Value = POQuantity
                                    .Add("@UnitCost", SqlDbType.VarChar).Value = POUnitCost
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = POUnitCost * POQuantity
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "20990"
                                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = DropShipCOSAccount
                                    .Add("@POLineNumber", SqlDbType.VarChar).Value = POLineNumber
                                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                                    .Add("@DropShip", SqlDbType.VarChar).Value = "YES"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                '************************************************************************************************************
                                ExtendedCOS = POQuantity * POUnitCost
                                ExtendedCOS = Math.Round(ExtendedCOS, 2)

                                'No line sales tax for Canadian
                                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                                    InvoiceLineSalesTax = 0
                                Else
                                    If GetTaxRate1 <> 0 Then
                                        LineSalesTax = POQuantity * SOPrice * GetTaxRate1
                                        LineSalesTax = Math.Round(LineSalesTax, 2)
                                    Else
                                        LineSalesTax = 0
                                    End If
                                End If
                                '***********************************************************************************************
                                Dim LineComplete As String = ""

                                If POQuantity <= POOpenQuantity Then
                                    LineComplete = "NO"
                                Else
                                    LineComplete = "YES"
                                End If
                                '************************************************************************************************************
                                'Get Next Line Number for Shipment
                                Dim MAXShipmentLineNumberStatement As String = "SELECT MAX(ShipmentLineNumber) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                                Dim MAXShipmentLineNumberCommand As New SqlCommand(MAXShipmentLineNumberStatement, con)
                                MAXShipmentLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                MAXShipmentLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    LastShipmentLineNumber = CInt(MAXShipmentLineNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    LastShipmentLineNumber = 0
                                End Try
                                con.Close()

                                NextShipmentLineNumber = LastShipmentLineNumber + 1
                                '***********************************************************************************************
                                'Write Line Data to Shipment Line Table
                                cmd = New SqlCommand("Insert Into ShipmentLineTable (ShipmentNumber, ShipmentLineNumber, PartNumber, PartDescription, QuantityShipped, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, GLDebitAccount, GLCreditAccount, CertificationType, ExtendedCOS, SOLineNumber, Dropship, SerialNumber, BoxWeight, LineComplete) Values (@ShipmentNumber, @ShipmentLineNumber, @PartNumber, @PartDescription, @QuantityShipped, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @GLDebitAccount, @GLCreditAccount, @CertificationType, @ExtendedCOS, @SOLineNumber, @Dropship, @SerialNumber, @BoxWeight, @LineComplete)", con)

                                With cmd.Parameters
                                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = NextShipmentLineNumber
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = POPartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = POPartDescription
                                    .Add("@QuantityShipped", SqlDbType.VarChar).Value = POQuantity
                                    .Add("@Price", SqlDbType.VarChar).Value = SOPrice
                                    .Add("@LineComment", SqlDbType.VarChar).Value = SOLineComment
                                    .Add("@LineWeight", SqlDbType.VarChar).Value = ShippingLineWeight
                                    .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxCount
                                    .Add("@SalesTax", SqlDbType.VarChar).Value = LineSalesTax
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = POQuantity * SOPrice
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = SODebitGLAccount
                                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = SOCreditGLAccount
                                    .Add("@CertificationType", SqlDbType.VarChar).Value = CertificationType
                                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = ExtendedCOS
                                    .Add("@SOLineNumber", SqlDbType.VarChar).Value = SalesOrderLineNumber
                                    .Add("@Dropship", SqlDbType.VarChar).Value = "YES"
                                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                    .Add("@BoxWeight", SqlDbType.VarChar).Value = 0
                                    .Add("@LineComplete", SqlDbType.VarChar).Value = LineComplete
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                '************************************************************************************************************
                                'Get Next Invoice Line Number
                                Dim MAXInvoiceLineNumberStatement As String = "SELECT MAX(InvoiceLineKey) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey"
                                Dim MAXInvoiceLineNumberCommand As New SqlCommand(MAXInvoiceLineNumberStatement, con)
                                MAXInvoiceLineNumberCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = NextInvoiceNumber
                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    LastInvoiceLineNumber = CInt(MAXInvoiceLineNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    LastInvoiceLineNumber = 0
                                End Try
                                con.Close()

                                NextInvoiceLineNumber = LastInvoiceLineNumber + 1

                                'Write lines to Invoice Line Table
                                cmd = New SqlCommand("Insert Into InvoiceLineTable (InvoiceHeaderKey, InvoiceLineKey, PartNumber, PartDescription, QuantityBilled, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, ExtendedCOS, SOLineNumber, SerialNumber) Values (@InvoiceHeaderKey, @InvoiceLineKey, @PartNumber, @PartDescription, @QuantityBilled, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @ExtendedCOS, @SOLineNumber, @SerialNumber)", con)

                                With cmd.Parameters
                                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = NextInvoiceNumber
                                    .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = NextInvoiceLineNumber
                                    .Add("@PartNumber", SqlDbType.VarChar).Value = POPartNumber
                                    .Add("@PartDescription", SqlDbType.VarChar).Value = POPartDescription
                                    .Add("@QuantityBilled", SqlDbType.VarChar).Value = POQuantity
                                    .Add("@Price", SqlDbType.VarChar).Value = SOPrice
                                    .Add("@LineComment", SqlDbType.VarChar).Value = SOLineComment
                                    .Add("@LineWeight", SqlDbType.VarChar).Value = ShippingLineWeight
                                    .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxCount
                                    .Add("@SalesTax", SqlDbType.VarChar).Value = LineSalesTax
                                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = POQuantity * SOPrice
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = SODebitGLAccount
                                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = SOCreditGLAccount
                                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = ExtendedCOS
                                    .Add("@SOLineNumber", SqlDbType.VarChar).Value = SalesOrderLineNumber
                                    .Add("@SerialNumber", SqlDbType.VarChar).Value = ""
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                '***************************************************************************************************
                                'Verify Status
                                Dim SOQuantityOpen As Double = 0

                                Dim SOQuantityOpenStatement As String = "SELECT QuantityOpen FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
                                Dim SOQuantityOpenCommand As New SqlCommand(SOQuantityOpenStatement, con)
                                SOQuantityOpenCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                SOQuantityOpenCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = SalesOrderLineNumber

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    SOQuantityOpen = CInt(SOQuantityOpenCommand.ExecuteScalar)
                                Catch ex As Exception
                                    SOQuantityOpen = 0
                                End Try
                                con.Close()

                                If SOQuantityOpen <= 0 Then
                                    SOLineStatus = "CLOSED"
                                Else
                                    SOLineStatus = "DROPSHIP"
                                End If

                                'Update Sales Order Line Status
                                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus, EstExtendedCOS = @EstExtendedCOS WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                                With cmd.Parameters
                                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = SalesOrderLineNumber
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = SOLineStatus
                                    .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = ExtendedCOS
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                Dim POQuantityOpenStatement As String = "SELECT POQuantityOpen FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber"
                                Dim POQuantityOpenCommand As New SqlCommand(POQuantityOpenStatement, con)
                                POQuantityOpenCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                POQuantityOpenCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = POLineNumber

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    POQuantityOpen = CInt(POQuantityOpenCommand.ExecuteScalar)
                                Catch ex As Exception
                                    POQuantityOpen = 0
                                End Try
                                con.Close()

                                If POQuantityOpen <= 0 Then
                                    POLineStatus = "CLOSED"
                                Else
                                    POLineStatus = "DROPSHIP"
                                End If

                                'Update Purchase Order Line Status
                                cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                                With cmd.Parameters
                                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                    .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = POLineNumber
                                    .Add("@LineStatus", SqlDbType.VarChar).Value = POLineStatus
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End If
                        End If 'Close Loop End/If

                        'Dump variables used in loop before next reiteration
                        ExtendedCOS = 0
                        POPartNumber = ""
                        POPartDescription = ""
                        LineComment = ""
                        POOpenQuantity = 0
                        POQuantity = 0
                        POUnitCost = 0
                        POExtendedAmount = 0
                        POLineNumber = 0
                        CheckSOPart = 0
                    Next 'Close loop for adding line items

                    '************************************************************************************************************
                    'Load Lot Numbers (If any)
                    If cboVendorShipmentNumber.Text = "" Or Val(cboVendorShipmentNumber.Text) = 0 Or POVendorCode = "TWE" Then
                        'Skip Lot Number Routine
                    Else
                        LoadLotNumbers()
                    End If
                    '************************************************************************************************************
                    If Me.dgvLotNumbers.RowCount > 0 Then
                        Dim RowLotNumber As String = ""
                        Dim RowPullTestNumber As String = ""
                        Dim RowHeatQuantity As Double = 0
                        Dim GetRowPartNumber As String = ""
                        Dim GetNewShipmentLineNumber As Integer = 0
                        Dim GetNextLotLineNumber As Integer = 0
                        Dim GetLastLotLineNumber As Integer = 0
                        Dim GetRowHeatNumber As String = ""

                        'Get Lot Number data
                        For Each LotRow As DataGridViewRow In dgvLotNumbers.Rows
                            Try
                                RowLotNumber = LotRow.Cells("LotNumberColumn").Value
                            Catch ex As Exception
                                RowLotNumber = ""
                            End Try
                            Try
                                RowPullTestNumber = LotRow.Cells("PullTestNumberColumn").Value
                            Catch ex As Exception
                                RowPullTestNumber = ""
                            End Try
                            Try
                                RowHeatQuantity = LotRow.Cells("HeatQuantityColumn").Value
                            Catch ex As Exception
                                RowHeatQuantity = 0
                            End Try

                            'Get Part Number from Lot
                            Dim GetRowPartNumberStatement As String = "SELECT PartNumber FROM LotNumber WHERE LotNumber = @LotNumber"
                            Dim GetRowPartNumberCommand As New SqlCommand(GetRowPartNumberStatement, con)
                            GetRowPartNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber

                            Dim GetRowHeatNumberStatement As String = "SELECT HeatNumber FROM LotNumber WHERE LotNumber = @LotNumber"
                            Dim GetRowHeatNumberCommand As New SqlCommand(GetRowHeatNumberStatement, con)
                            GetRowHeatNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetRowPartNumber = CStr(GetRowPartNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetRowPartNumber = ""
                            End Try
                            Try
                                GetRowHeatNumber = CStr(GetRowHeatNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetRowHeatNumber = ""
                            End Try
                            con.Close()

                            'Get Shipment Line Number from New Shipment for specific part
                            Dim GetNewShipmentLineNumberStatement As String = "SELECT ShipmentLineNumber FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                            Dim GetNewShipmentLineNumberCommand As New SqlCommand(GetNewShipmentLineNumberStatement, con)
                            GetNewShipmentLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            GetNewShipmentLineNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetRowPartNumber
                            GetNewShipmentLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetNewShipmentLineNumber = CInt(GetNewShipmentLineNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetNewShipmentLineNumber = 0
                            End Try
                            con.Close()

                            Dim GetLastLotLineNumberStatement As String = "SELECT MAX(LotLineNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                            Dim GetLastLotLineNumberCommand As New SqlCommand(GetLastLotLineNumberStatement, con)
                            GetLastLotLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                            GetLastLotLineNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = GetNewShipmentLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetLastLotLineNumber = CInt(GetLastLotLineNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetLastLotLineNumber = 0
                            End Try
                            con.Close()

                            GetNextLotLineNumber = GetLastLotLineNumber + 1
                            '************************************************************************************************************
                            Try
                                'Run Shipment Line Lot Number Insert Routine
                                cmd = New SqlCommand("INSERT INTO ShipmentLineLotNumbers (ShipmentNumber, ShipmentLineNumber, LotLineNumber, LotNumber, PullTestNumber, HeatQuantity) values (@ShipmentNumber, @ShipmentLineNumber, @LotLineNumber, @LotNumber, @PullTestNumber, @HeatQuantity)", con)

                                With cmd.Parameters
                                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = GetNewShipmentLineNumber
                                    .Add("@LotLineNumber", SqlDbType.VarChar).Value = GetNextLotLineNumber
                                    .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                                    .Add("@PullTestNumber", SqlDbType.VarChar).Value = RowPullTestNumber
                                    .Add("@HeatQuantity", SqlDbType.VarChar).Value = RowHeatQuantity
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                                '************************************************************************************************************
                                'Run Invoice Line Lot Number Insert Routine
                                cmd = New SqlCommand("INSERT INTO InvoiceLotLineTable (InvoiceNumber, InvoiceLineNumber, InvoiceLotLineNumber, InvoiceLotNumber, InvoiceHeatNumber, InvoiceHeatQuantity) values (@InvoiceNumber, @InvoiceLineNumber, @InvoiceLotLineNumber, @InvoiceLotNumber, @InvoiceHeatNumber, @InvoiceHeatQuantity)", con)

                                With cmd.Parameters
                                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextInvoiceNumber
                                    .Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = GetNewShipmentLineNumber
                                    .Add("@InvoiceLotLineNumber", SqlDbType.VarChar).Value = GetNextLotLineNumber
                                    .Add("@InvoiceLotNumber", SqlDbType.VarChar).Value = RowLotNumber
                                    .Add("@InvoiceHeatNumber", SqlDbType.VarChar).Value = GetRowHeatNumber
                                    .Add("@InvoiceHeatQuantity", SqlDbType.VarChar).Value = RowHeatQuantity
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Skip Lot Number
                            End Try
                            '************************************************************************************************************
                            'Clear Variables
                            RowLotNumber = ""
                            RowPullTestNumber = ""
                            RowHeatQuantity = 0
                            GetRowPartNumber = ""
                            GetNewShipmentLineNumber = 0
                            GetNextLotLineNumber = 0
                            GetLastLotLineNumber = 0
                            GetRowHeatNumber = ""
                        Next
                    Else
                        'Skip Lot Number Routine
                    End If
                    '************************************************************************************************************
                    'Update Receiver Header Totals
                    LoadReceiverTotal()

                    cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET ProductTotal = @ProductTotal, SalesTax = @SalesTax, POTotal = @POTotal, FreightCharge = @FreightCharge WHERE ReceivingHeaderKey = @ReceivingHeaderKey", con)

                    With cmd.Parameters
                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = NextReceiverNumber
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ReceiverSumExtendedAmount
                        .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                        .Add("@POTotal", SqlDbType.VarChar).Value = ReceiverTotal
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = POFreightCharge
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Update Shipment Header Totals
                    LoadShipmentTotal()
                    LoadInvoiceTotal()

                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        GetCanadianTaxRates()

                        SalesTax1 = ShippingSumExtendedAmount * GSTRate
                        SalesTax2 = ShippingSumExtendedAmount * PSTRate
                        SalesTax3 = ShippingSumExtendedAmount * HSTRate

                        SalesTax1 = Math.Round(SalesTax1, 2)
                        SalesTax2 = Math.Round(SalesTax2, 2)
                        SalesTax3 = Math.Round(SalesTax3, 2)

                        ShipmentTotal = ShippingSumExtendedAmount + FreightCharge + SalesTax1 + SalesTax2 + SalesTax3
                        SumInvoiceTotal = SumExtendedAmount + FreightCharge + SalesTax1 + SalesTax2 + SalesTax3
                    Else
                        SalesTax1 = SumShippingSalesTax
                        'Convert Sum of Sales Tax - totals are correct
                    End If
                    '******************************************************************************************************************************
                    Dim GetVendorPRONumber As String = ""

                    If cboVendorShipmentNumber.Text = "" Or Val(cboVendorShipmentNumber.Text) = 0 Then

                    Else
                        'Get PRO # from vendor shipment
                        Dim GetVendorPRONumberStatement As String = "SELECT PRONumber FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
                        Dim GetVendorPRONumberCommand As New SqlCommand(GetVendorPRONumberStatement, con)
                        GetVendorPRONumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboVendorShipmentNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetVendorPRONumber = CStr(GetVendorPRONumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetVendorPRONumber = ""
                        End Try
                        con.Close()
                    End If

                    'Update shipment
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ProductTotal = @ProductTotal, TaxTotal = @TaxTotal, ShipmentTotal = @ShipmentTotal, FreightActualAmount = @FreightActualAmount, ShippingWeight = @ShippingWeight, Tax2Total = @Tax2Total, Tax3Total = @Tax3Total, PRONumber = @PRONumber WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = NextShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ShippingSumExtendedAmount
                        .Add("@TaxTotal", SqlDbType.VarChar).Value = SalesTax1
                        .Add("@ShipmentTotal", SqlDbType.VarChar).Value = ShipmentTotal
                        .Add("@FreightActualAmount", SqlDbType.VarChar).Value = FreightCharge
                        .Add("@ShippingWeight", SqlDbType.VarChar).Value = SumShippingWeight
                        .Add("@Tax2Total", SqlDbType.VarChar).Value = SalesTax2
                        .Add("@Tax3Total", SqlDbType.VarChar).Value = SalesTax3
                        .Add("@PRONumber", SqlDbType.VarChar).Value = GetVendorPRONumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Update Invoice Header
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET ProductTotal = @ProductTotal, SalesTax = @SalesTax, InvoiceTotal = @InvoiceTotal, InvoiceCOS = @InvoiceCOS, BilledFreight = @BilledFreight, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3, PRONumber = @PRONumber WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextInvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
                        .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax1
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = SumInvoiceTotal
                        .Add("@InvoiceCOS", SqlDbType.VarChar).Value = SumExtendedCOS
                        .Add("@BilledFreight", SqlDbType.VarChar).Value = FreightCharge
                        .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
                        .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
                        .Add("@PRONumber", SqlDbType.VarChar).Value = GetVendorPRONumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '***************************************************************************************************************
                    'Update Sales Order Header Status
                    Dim CountSOLinesString As String = "SELECT Count(SalesOrderKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey"
                    Dim CountSOLinesCommand As New SqlCommand(CountSOLinesString, con)
                    CountSOLinesCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountSOLines = CInt(CountSOLinesCommand.ExecuteScalar)
                    Catch ex As Exception
                        CountSOLines = 0
                    End Try
                    con.Close()

                    SOLineNumber = 1

                    For i As Integer = 1 To CountSOLines
                        Dim LineStatusString As String = "SELECT LineStatus FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
                        Dim LineStatusCommand As New SqlCommand(LineStatusString, con)
                        LineStatusCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                        LineStatusCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = SOLineNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SOLineStatus = CStr(LineStatusCommand.ExecuteScalar)
                        Catch ex As Exception
                            SOLineStatus = "OPEN"
                        End Try
                        con.Close()

                        If SOLineStatus <> "CLOSED" Then
                            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey", con)
                            With cmd.Parameters
                                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                .Add("@SOStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            Exit For  'Exit loop - if one line is open, then SO is still open
                        Else
                            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey", con)

                            With cmd.Parameters
                                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
                                .Add("@SOStatus", SqlDbType.VarChar).Value = "CLOSED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If

                        SOLineNumber = SOLineNumber + 1
                    Next i
                    '****************************************************************************************************
                    'Update Purchase Order Header Status
                    Dim CountPOLinesString As String = "SELECT Count(PurchaseOrderHeaderKey) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
                    Dim CountPOLinesCommand As New SqlCommand(CountPOLinesString, con)
                    CountPOLinesCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountPOLines = CInt(CountPOLinesCommand.ExecuteScalar)
                    Catch ex As Exception
                        CountPOLines = 0
                    End Try
                    con.Close()

                    POLineNumber = 1

                    For i As Integer = 1 To CountPOLines
                        Dim POLineStatusString As String = "SELECT LineStatus FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber"
                        Dim POLineStatusCommand As New SqlCommand(POLineStatusString, con)
                        POLineStatusCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        POLineStatusCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = POLineNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            POLineStatus = CStr(POLineStatusCommand.ExecuteScalar)
                        Catch ex As Exception
                            POLineStatus = "DROPSHIP"
                        End Try
                        con.Close()

                        If POLineStatus <> "CLOSED" Then
                            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                .Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            Exit For  'Exit loop - if one line is open, then SO is still open
                        Else
                            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                        POLineNumber = POLineNumber + 1
                    Next i
                    '**********************************************************************************************************
                    'Load Batch Totals and Update Batch
                    Dim BatchAmountString As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                    Dim BatchAmountCommand As New SqlCommand(BatchAmountString, con)
                    BatchAmountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                    BatchAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        BatchAmount = CDbl(BatchAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        BatchAmount = 0
                    End Try
                    con.Close()

                    Try
                        'Create Invoice Batch
                        cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = BatchAmount
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Do nothing if batch is already created
                    End Try

                    'Check Lines to close PO and set SO to Invoiced

                    'Default message
                    MsgBox("Invoice created for this drop ship.", MsgBoxStyle.OkOnly)

                    'Clear form and clear variables for next entry
                    ClearVariables()
                    ClearForNextEntry()
                    ShowDataByPO()
                    LoadPurchaseOrderNumber()
                End If
            End If
        End If
    End Sub

    Private Sub cmdOpenBatchForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenBatchForm.Click
        Dim FoundForm As Boolean = False

        For Each OpenForm As Form In Application.OpenForms
            If TypeOf OpenForm Is ARProcessBatch Then
                OpenForm.BringToFront()
                OpenForm.WindowState = FormWindowState.Normal
                OpenForm.Focus()
                FoundForm = True
            End If
        Next

        If Not FoundForm Then
            GlobalARBatchNumber = Val(cboInvoiceBatchNumber.Text)
            Dim NewARProcessBatch As New ARProcessBatch
            NewARProcessBatch.Show()
        End If

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdGenerateBatchNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateBatchNumber.Click
        ClearVariables()
        ClearAll()
        ClearDataInDatagrid()

        'Get Next Batch Number
        Dim MAXBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM InvoiceProcessingBatchHeader"
        Dim MAXBatchNumberCommand As New SqlCommand(MAXBatchNumberStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(MAXBatchNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 0
        End Try
        con.Close()

        NextBatchNumber = LastBatchNumber + 1
        cboInvoiceBatchNumber.Text = NextBatchNumber

        ShipDate = dtpShipDate.Value
     
        'Create Invoice Batch
        cmd = New SqlCommand("Insert Into InvoiceProcessingBatchHeader (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus)", con)

        With cmd.Parameters
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboInvoiceBatchNumber.Text)
            .Add("@BatchDate", SqlDbType.VarChar).Value = ShipDate
            .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
            .Add("@BatchDescription", SqlDbType.VarChar).Value = "PO Drop Ship Invoicing"
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdClearForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearForm.Click
        ClearVariables()
        ClearAll()
        ShowDataByPO()
        LoadInvoiceBatchNumber()
        cboInvoiceBatchNumber.Focus()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintDropShipListing As New PrintDropShipListing
            Dim Result = NewPrintDropShipListing.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class