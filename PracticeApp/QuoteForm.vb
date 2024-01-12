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
Public Class QuoteForm
    Inherits System.Windows.Forms.Form

    Dim QOH, CheckOrderQuantity, NewOrderQuantity As Double
    Dim TotalShippingWeight, LineQuantity, LinePrice, LineTax, TaxRate, FreightCharge, NewExtendedAmount As Double
    Dim TotalSalesTax, TotalSalesTax2, TotalSalesTax3, LastPurchaseCost, ItemPrice, LastSalesPrice, PieceWeight, StandardPrice, EstFreight, ItemPieceWeight, TotalLineWeight, TotalOrderWeight, LineTotal, ProductTotal, QuoteTotal As Double
    Dim AddAccessory, LongDescription, SpecialInstructions, ShipToID, ShipToName, ShipVia, ItemClass, CreditGLAccount, DebitGLAccount, QuoteStatus, PartNumber, PartDescription, CheckPartNumber As String
    Dim MAXDate, Counter, LastTransactionNumber, NextTransactionNumber, LastLineNumber, NextLineNumber, GetLineNumber As Integer
    Dim CountPartNumber, BoxCount, LineBoxes As Integer
    Dim ThirdPartyShipper, ShippingMethod, PricingLevel, CustomerPO, CustomerID, CustomerName, Salesperson, HeaderComment, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry As String
    Dim AddTaxRate1, AddTaxRate2, AddTaxRate3 As Double

    'Variables for TWD Price Adjustments
    Dim AdjustedLastSalesPrice As Double = 0
    Dim CurrentPartNumber As String = ""

    Dim ShippingDate, SalesOrderDate As Date
    Dim LoadQuoteDate, LoadShipDate As String

    'Variables for line items
    Dim EditLinePart, EditLineDescription, EditLineLeadTime, EditLineComment As String
    Dim EditLineQuantity, EditNewLineQuantity As Double
    Dim EditLineExtendedAmount, EditLinePrice, EditItemPrice, EditLineTotal, EditLineSalesTax As Double

    'Variables for Canadian Tax
    Dim GSTTaxRate, PSTTaxRate, HSTTaxRate, GSTExtendedAmount, PSTExtendedAmount, HSTExtendedAmount As Double
    Dim SalesTaxRate, SalesTaxRate2, SalesTaxRate3, HSTValue As Double

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    'Form Operations

    Private Sub QuoteForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadCurrentDivision()

        'Initialize Data
        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboSalesperson.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
            cboSalesperson.Text = EmployeeSalespersonCode
        ElseIf EmployeeCompanyCode = "CBS" Then
            cboDivisionID.Enabled = False
            cboSalesperson.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
            cboSalesperson.Text = EmployeeSalespersonCode
        Else
            cboDivisionID.Enabled = False
            cboSalesperson.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
            cboSalesperson.Text = EmployeeSalespersonCode
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
            Case "TFJ"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFJ'", con)
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
        If ErrorComment.Length > 400 Then
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

    Private Sub QuoteForm_Closing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closing
        GlobalSONumber = 0
        ClearData()
        ClearVariables()
    End Sub

    'Load Datasets and controls

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderLineTable")
        dgvSalesOrderLines.DataSource = ds.Tables("SalesOrderLineTable")
        cboQuoteLineNumber.DataSource = ds.Tables("SalesOrderLineTable")
        con.Close()
    End Sub

    Public Sub LoadCustomerList()
        'Select Division Customer
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerList")
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        'Select Division Customer
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerName.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        'Select Division Part Number
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND SalesProdLineID <> @SalesProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SUPPLY"
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboPartNumber.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        'Select Division Part Number
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND SalesProdLineID <> @SalesProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SUPPLY"
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboPartDescription.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadQuoteNumber()
        'Select Open Quotes for specific division
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SOStatus = @SOStatus ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "SalesOrderHeaderTable")
        cboQuoteNumber.DataSource = ds5.Tables("SalesOrderHeaderTable")
        con.Close()
        cboQuoteNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadAdditionalShipTo()
        'Select Division Customer
        cmd = New SqlCommand("SELECT ShipToID FROM AdditionalShipTo WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "AdditionalShipTo")
        cboShipToID.DataSource = ds6.Tables("AdditionalShipTo")
        con.Close()
        cboShipToID.SelectedIndex = -1
    End Sub

    Public Sub LoadEditPartNumber()
        'Select Division Part Number
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND SalesProdLineID <> @SalesProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SUPPLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "ItemList")
        cboQuoteLinePart.DataSource = ds7.Tables("ItemList")
        cboQuoteLineDescription.DataSource = ds7.Tables("ItemList")
        con.Close()
        cboQuoteLinePart.SelectedIndex = -1
        cboQuoteLineDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesperson()
        'Select Open Quotes for specific division
        cmd = New SqlCommand("SELECT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "EmployeeData")
        cboSalesperson.DataSource = ds8.Tables("EmployeeData")
        con.Close()
        cboSalesperson.SelectedIndex = -1
    End Sub

    'Load Data

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadQuoteData()
        Dim T1, T2, T3 As Double

        Dim LoadShipToAddress1 As String = ""
        Dim LoadShipToAddress2 = ""
        Dim LoadShipToCity As String = ""
        Dim LoadShipToCountry As String = ""
        Dim LoadShipToName As String = ""
        Dim LoadShipToState As String = ""
        Dim LoadShipToZip As String = ""

        Dim SalesOrderDateStatement As String = "SELECT SalesOrderDate FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SalesOrderDateCommand As New SqlCommand(SalesOrderDateStatement, con)
        SalesOrderDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        SalesOrderDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerIDStatement As String = "SELECT CustomerID FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim CustomerIDCommand As New SqlCommand(CustomerIDStatement, con)
        CustomerIDCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        CustomerIDCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShippingDateStatement As String = "SELECT ShippingDate FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShippingDateCommand As New SqlCommand(ShippingDateStatement, con)
        ShippingDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ShippingDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim HeaderCommentStatement As String = "SELECT HeaderComment FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim HeaderCommentCommand As New SqlCommand(HeaderCommentStatement, con)
        HeaderCommentCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        HeaderCommentCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim FreightChargeStatement As String = "SELECT FreightCharge FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim FreightChargeCommand As New SqlCommand(FreightChargeStatement, con)
        FreightChargeCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        FreightChargeCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipViaStatement As String = "SELECT ShipVia FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipViaCommand As New SqlCommand(ShipViaStatement, con)
        ShipViaCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ShipViaCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToIDStatement As String = "SELECT AdditionalShipTo FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToIDCommand As New SqlCommand(ShipToIDStatement, con)
        ShipToIDCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ShipToIDCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalespersonStatement As String = "SELECT Salesperson FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SalespersonCommand As New SqlCommand(SalespersonStatement, con)
        SalespersonCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        SalespersonCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SpecialInstructionsStatement As String = "SELECT SpecialInstructions FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SpecialInstructionsCommand As New SqlCommand(SpecialInstructionsStatement, con)
        SpecialInstructionsCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        SpecialInstructionsCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalSalesTax2Statement As String = "SELECT TotalSalesTax2 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim TotalSalesTax2Command As New SqlCommand(TotalSalesTax2Statement, con)
        TotalSalesTax2Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        TotalSalesTax2Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalSalesTax3Statement As String = "SELECT TotalSalesTax3 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim TotalSalesTax3Command As New SqlCommand(TotalSalesTax3Statement, con)
        TotalSalesTax3Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        TotalSalesTax3Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalSalesTaxStatement As String = "SELECT TotalSalesTax FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim TotalSalesTaxCommand As New SqlCommand(TotalSalesTaxStatement, con)
        TotalSalesTaxCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        TotalSalesTaxCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ProductTotalStatement As String = "SELECT ProductTotal FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SOTotalStatement As String = "SELECT SOTotal FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOTotalCommand As New SqlCommand(SOTotalStatement, con)
        SOTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        SOTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalShippingWeightStatement As String = "SELECT ShippingWeight FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim TotalShippingWeightCommand As New SqlCommand(TotalShippingWeightStatement, con)
        TotalShippingWeightCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        TotalShippingWeightCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerPOStatement As String = "SELECT CustomerPO FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim CustomerPOCommand As New SqlCommand(CustomerPOStatement, con)
        CustomerPOCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        CustomerPOCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ThirdPartyShipperStatement As String = "SELECT ThirdPartyShipper FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ThirdPartyShipperCommand As New SqlCommand(ThirdPartyShipperStatement, con)
        ThirdPartyShipperCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ThirdPartyShipperCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShippingMethodStatement As String = "SELECT ShippingMethod FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShippingMethodCommand As New SqlCommand(ShippingMethodStatement, con)
        ShippingMethodCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ShippingMethodCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToNameStatement As String = "SELECT ShipToName FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToNameCommand As New SqlCommand(ShipToNameStatement, con)
        ShipToNameCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ShipToNameCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToAddress1Statement As String = "SELECT ShipToAddress1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToAddress1Command As New SqlCommand(ShipToAddress1Statement, con)
        ShipToAddress1Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ShipToAddress1Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToAddress2Statement As String = "SELECT ShipToAddress2 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToAddress2Command As New SqlCommand(ShipToAddress2Statement, con)
        ShipToAddress2Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ShipToAddress2Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToCityStatement As String = "SELECT ShipToCity FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToCityCommand As New SqlCommand(ShipToCityStatement, con)
        ShipToCityCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ShipToCityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToStateStatement As String = "SELECT ShipToState FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToStateCommand As New SqlCommand(ShipToStateStatement, con)
        ShipToStateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ShipToStateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToZipStatement As String = "SELECT ShipToZip FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToZipCommand As New SqlCommand(ShipToZipStatement, con)
        ShipToZipCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ShipToZipCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToCountryStatement As String = "SELECT ShipToCountry FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToCountryCommand As New SqlCommand(ShipToCountryStatement, con)
        ShipToCountryCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ShipToCountryCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadQuoteDate = CStr(SalesOrderDateCommand.ExecuteScalar)
        Catch ex As Exception
            LoadQuoteDate = dtpQuoteDate.Text
        End Try
        Try
            CustomerID = CStr(CustomerIDCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerID = ""
        End Try
        Try
            LoadShipDate = CStr(ShippingDateCommand.ExecuteScalar)
        Catch ex As Exception
            LoadShipDate = dtpDeliveryDate.Text
        End Try
        Try
            HeaderComment = CStr(HeaderCommentCommand.ExecuteScalar)
        Catch ex As Exception
            HeaderComment = ""
        End Try
        Try
            FreightCharge = CDbl(FreightChargeCommand.ExecuteScalar)
        Catch ex As Exception
            FreightCharge = 0
        End Try
        Try
            ShipVia = CStr(ShipViaCommand.ExecuteScalar)
        Catch ex As Exception
            ShipVia = "Delivery"
        End Try
        Try
            ShipToID = CStr(ShipToIDCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToID = ""
        End Try
        Try
            Salesperson = CStr(SalespersonCommand.ExecuteScalar)
        Catch ex As Exception
            Salesperson = EmployeeSalespersonCode
        End Try
        Try
            SpecialInstructions = CStr(SpecialInstructionsCommand.ExecuteScalar)
        Catch ex As Exception
            SpecialInstructions = ""
        End Try
        Try
            TotalSalesTax2 = CDbl(TotalSalesTax2Command.ExecuteScalar)
            T2 = TotalSalesTax2
        Catch ex As Exception
            TotalSalesTax2 = 0
            T2 = TotalSalesTax2
        End Try
        Try
            TotalSalesTax3 = CDbl(TotalSalesTax3Command.ExecuteScalar)
            T3 = TotalSalesTax3
        Catch ex As Exception
            TotalSalesTax3 = 0
            T3 = TotalSalesTax3
        End Try
        Try
            TotalSalesTax = CDbl(TotalSalesTaxCommand.ExecuteScalar)
            T1 = TotalSalesTax
        Catch ex As Exception
            TotalSalesTax = 0
            T1 = TotalSalesTax
        End Try
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            QuoteTotal = CDbl(SOTotalCommand.ExecuteScalar)
        Catch ex As Exception
            QuoteTotal = 0
        End Try
        Try
            TotalShippingWeight = CDbl(TotalShippingWeightCommand.ExecuteScalar)
        Catch ex As Exception
            TotalShippingWeight = 0
        End Try
        Try
            CustomerPO = CStr(CustomerPOCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerPO = ""
        End Try
        Try
            ThirdPartyShipper = CStr(ThirdPartyShipperCommand.ExecuteScalar)
        Catch ex As Exception
            ThirdPartyShipper = ""
        End Try
        Try
            ShippingMethod = CStr(ShippingMethodCommand.ExecuteScalar)
        Catch ex As Exception
            ShippingMethod = ""
        End Try
        Try
            ShippingMethod = CStr(ShippingMethodCommand.ExecuteScalar)
        Catch ex As Exception
            ShippingMethod = ""
        End Try
        Try
            LoadShipToName = CStr(ShipToNameCommand.ExecuteScalar)
        Catch ex As Exception
            LoadShipToName = ""
        End Try
        Try
            LoadShipToAddress1 = CStr(ShipToAddress1Command.ExecuteScalar)
        Catch ex As Exception
            LoadShipToAddress1 = ""
        End Try
        Try
            LoadShipToAddress2 = CStr(ShipToAddress2Command.ExecuteScalar)
        Catch ex As Exception
            LoadShipToAddress2 = ""
        End Try
        Try
            LoadShipToCity = CStr(ShipToCityCommand.ExecuteScalar)
        Catch ex As Exception
            LoadShipToCity = ""
        End Try
        Try
            LoadShipToState = CStr(ShipToStateCommand.ExecuteScalar)
        Catch ex As Exception
            LoadShipToState = ""
        End Try
        Try
            LoadShipToZip = CStr(ShipToZipCommand.ExecuteScalar)
        Catch ex As Exception
            LoadShipToZip = ""
        End Try
        Try
            LoadShipToCountry = CStr(ShipToCountryCommand.ExecuteScalar)
        Catch ex As Exception
            LoadShipToCountry = ""
        End Try
        con.Close()

        cboShipMethod.Text = ShippingMethod
        cboCustomerID.Text = CustomerID
        cboShipToID.Text = ShipToID

        txtComment.Text = HeaderComment
        txtFreightCharge.Text = FreightCharge
        txtCustomerPO.Text = CustomerPO
        cboShipVia.Text = ShipVia
        cboSalesperson.Text = Salesperson
        txtSpecialInstructions.Text = SpecialInstructions
        txtThirdPartyShipper.Text = ThirdPartyShipper

        txtShipToName.Text = LoadShipToName
        txtShipToAddress1.Text = LoadShipToAddress1
        txtShipToAddress2.Text = LoadShipToAddress2
        txtShipToCity.Text = LoadShipToCity
        txtShipToCountry.Text = LoadShipToCountry
        txtShipToState.Text = LoadShipToState
        txtShipToZip.Text = LoadShipToZip

        dtpQuoteDate.Value = LoadQuoteDate
        dtpDeliveryDate.Value = LoadShipDate

        If TotalSalesTax2 > 0 Then chkADDPST.Checked = True
        If TotalSalesTax3 > 0 Then chkADDHST.Checked = True

        lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
        lblFreightCharge.Text = FormatCurrency(FreightCharge, 2)
        lblEstimatedWeight.Text = FormatNumber(TotalShippingWeight, 1)

        lblHSTExtendedAmount.Text = FormatCurrency(T3, 2)
        lblPSTExtendedAmount.Text = FormatCurrency(T2, 2)
        lblSalesTax.Text = FormatCurrency(T1, 2)
        lblQuoteTotal.Text = FormatCurrency(QuoteTotal, 2)
    End Sub

    Public Sub LoadLineData()
        Dim ItemIDStatement As String = "SELECT ItemID FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
        Dim ItemIDCommand As New SqlCommand(ItemIDStatement, con)
        ItemIDCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ItemIDCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = Val(cboQuoteLineNumber.Text)

        Dim DescriptionStatement As String = "SELECT Description FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
        Dim DescriptionCommand As New SqlCommand(DescriptionStatement, con)
        DescriptionCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        DescriptionCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = Val(cboQuoteLineNumber.Text)

        Dim QuantityStatement As String = "SELECT Quantity FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
        Dim QuantityCommand As New SqlCommand(QuantityStatement, con)
        QuantityCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        QuantityCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = Val(cboQuoteLineNumber.Text)

        Dim PriceStatement As String = "SELECT Price FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
        Dim PriceCommand As New SqlCommand(PriceStatement, con)
        PriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        PriceCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = Val(cboQuoteLineNumber.Text)

        Dim ExtendedAmountStatement As String = "SELECT ExtendedAmount FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
        Dim ExtendedAmountCommand As New SqlCommand(ExtendedAmountStatement, con)
        ExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ExtendedAmountCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = Val(cboQuoteLineNumber.Text)

        Dim LeadTimeStatement As String = "SELECT LeadTime FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
        Dim LeadTimeCommand As New SqlCommand(LeadTimeStatement, con)
        LeadTimeCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        LeadTimeCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = Val(cboQuoteLineNumber.Text)

        Dim LineCommentStatement As String = "SELECT LineComment FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey"
        Dim LineCommentCommand As New SqlCommand(LineCommentStatement, con)
        LineCommentCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        LineCommentCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = Val(cboQuoteLineNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            EditLinePart = CStr(ItemIDCommand.ExecuteScalar)
        Catch ex As Exception
            EditLinePart = ""
        End Try
        Try
            EditLineDescription = CStr(DescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            EditLineDescription = ""
        End Try
        Try
            EditLineQuantity = CDbl(QuantityCommand.ExecuteScalar)
        Catch ex As Exception
            EditLineQuantity = 0
        End Try
        Try
            EditLinePrice = CDbl(PriceCommand.ExecuteScalar)
        Catch ex As Exception
            EditLinePrice = 0
        End Try
        Try
            EditLineExtendedAmount = CDbl(ExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            EditLineExtendedAmount = 0
        End Try
        Try
            EditLineLeadTime = CStr(LeadTimeCommand.ExecuteScalar)
        Catch ex As Exception
            EditLineLeadTime = ""
        End Try
        Try
            EditLineComment = CStr(LineCommentCommand.ExecuteScalar)
        Catch ex As Exception
            EditLineComment = ""
        End Try
        con.Close()

        cboQuoteLinePart.Text = EditLinePart
        cboQuoteLineDescription.Text = EditLineDescription
        txtQuoteLineQuantity.Text = EditLineQuantity
        txtQuoteExtendedAmount.Text = FormatCurrency(EditLineExtendedAmount, 2)
        txtQuoteLineComment.Text = EditLineComment
        txtQuoteLineLeadTime.Text = EditLineLeadTime
        txtQuoteLinePrice.Text = EditLinePrice
    End Sub

    Public Sub LoadShipToDetails()
        Dim AddNameStatement As String = "SELECT Name FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipToID = @ShipToID"
        Dim AddNameCommand As New SqlCommand(AddNameStatement, con)
        AddNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        AddNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AddNameCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text

        Dim AddAddress1Statement As String = "SELECT Address1 FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipToID = @ShipToID"
        Dim AddAddress1Command As New SqlCommand(AddAddress1Statement, con)
        AddAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        AddAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AddAddress1Command.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text

        Dim AddAddress2Statement As String = "SELECT Address2 FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipToID = @ShipToID"
        Dim AddAddress2Command As New SqlCommand(AddAddress2Statement, con)
        AddAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        AddAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AddAddress2Command.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text

        Dim AddCityStatement As String = "SELECT City FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipToID = @ShipToID"
        Dim AddCityCommand As New SqlCommand(AddCityStatement, con)
        AddCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        AddCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AddCityCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text

        Dim AddStateStatement As String = "SELECT State FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipToID = @ShipToID"
        Dim AddStateCommand As New SqlCommand(AddStateStatement, con)
        AddStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        AddStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AddStateCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text

        Dim AddZipStatement As String = "SELECT Zip FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipToID = @ShipToID"
        Dim AddZipCommand As New SqlCommand(AddZipStatement, con)
        AddZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        AddZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AddZipCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text

        Dim AddCountryStatement As String = "SELECT Country FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipToID = @ShipToID"
        Dim AddCountryCommand As New SqlCommand(AddCountryStatement, con)
        AddCountryCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        AddCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AddCountryCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShipToName = CStr(AddNameCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToName = ""
        End Try
        Try
            ShipToAddress1 = CStr(AddAddress1Command.ExecuteScalar)
        Catch ex As Exception
            ShipToAddress1 = ""
        End Try
        Try
            ShipToAddress2 = CStr(AddAddress2Command.ExecuteScalar)
        Catch ex As Exception
            ShipToAddress2 = ""
        End Try
        Try
            ShipToCity = CStr(AddCityCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToCity = ""
        End Try
        Try
            ShipToState = CStr(AddStateCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToState = ""
        End Try
        Try
            ShipToZip = CStr(AddZipCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToZip = ""
        End Try
        Try
            ShipToCountry = CStr(AddCountryCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToCountry = "USA"
        End Try
        con.Close()

        'Load values into Labels
        txtShipToName.Text = ShipToName
        txtShipToAddress1.Text = ShipToAddress1
        txtShipToAddress2.Text = ShipToAddress2
        txtShipToCity.Text = ShipToCity
        txtShipToState.Text = ShipToState
        txtShipToZip.Text = ShipToZip
        txtShipToCountry.Text = ShipToCountry
    End Sub

    Public Sub LoadLastSalesPriceTWDRevised()
        'Declare variables
        Dim MaxDate As Integer = 0
        Dim GetItemClass As String = ""
        Dim GetSPL As String = ""
        Dim GetYearPricingDate As Date
        Dim LastSalesPrice As Double = 0
        Dim AdjustedLastSalesPrice As Double = 0
        Dim GetBracketNumber As Integer = 0
        Dim GetPriceAdjustmentPercentage1 As Double = 0
        Dim GetPriceAdjustmentPercentage2 As Double = 0
        Dim GetPriceAdjustmentPercentage3 As Double = 0
        Dim GetPriceAdjustmentPercentage4 As Double = 0
        Dim GetPriceAdjustmentPercentage5 As Double = 0
        Dim GetPriceAdjustmentPercentage6 As Double = 0
        '***************************************************************************************
        'Get Item Class of part (as well as if it is stainless)
        Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
        GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            GetItemClass = ""
        End Try
        con.Close()

        Dim GetSPLStatement As String = "SELECT SalesProdLineID FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim GetSPLCommand As New SqlCommand(GetSPLStatement, con)
        GetSPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetSPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSPL = CStr(GetSPLCommand.ExecuteScalar)
        Catch ex As Exception
            GetSPL = ""
        End Try
        con.Close()

        If cboCustomerID.Text = "" Then
            '***************************************************************************************
            'Get last sales date from invoice line table
            Dim MAXDateStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT SalesOrderDate FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetYearPricingDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()

            'If price date is beyond the bracket, exit routine
            If GetYearPricingDate > "4/30/2022" Then
                'Pricing is current
                LastSalesPrice = Math.Round(LastSalesPrice, 4)
                txtLinePrice.Text = LastSalesPrice
                lblUpdatedPrice.Visible = False

                Exit Sub
            Else
                'Determine the Price Increase Bracket it is in
                Dim GetBracketNumberStatement As String = "SELECT CostTierNumber FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND @PriceDate BETWEEN BeginDate AND EndDate"
                Dim GetBracketNumberCommand As New SqlCommand(GetBracketNumberStatement, con)
                GetBracketNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetBracketNumberCommand.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                GetBracketNumberCommand.Parameters.Add("@PriceDate", SqlDbType.VarChar).Value = GetYearPricingDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetBracketNumber = CInt(GetBracketNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetBracketNumber = 0
                End Try
                con.Close()

                Select Case GetBracketNumber
                    Case 1
                        'Increase price for 6 brackets (plus stainless)

                        'Get % for first bracket (Tier 1)
                        Dim GetPercentage1Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage1Command As New SqlCommand(GetPercentage1Statement, con)
                        GetPercentage1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage1Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage1Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 1

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage1 = CDbl(GetPercentage1Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage1 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage1)

                        'Get % for second bracket (Tier 2)
                        Dim GetPercentage2Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage2Command As New SqlCommand(GetPercentage2Statement, con)
                        GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage2Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage2Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 2

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage2 = CDbl(GetPercentage2Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage2 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage2)

                        'Get % for third bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for fourth bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for fifth bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case 2
                        'Increase price for 5 brackets (plus stainless)

                        'Get % for first bracket (Tier 2)
                        Dim GetPercentage2Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage2Command As New SqlCommand(GetPercentage2Statement, con)
                        GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage2Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage2Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 2

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage2 = CDbl(GetPercentage2Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage2 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage2)

                        'Get % for second bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for third bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for fourth bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case 3
                        'Increase price for FOUR brackets (plus stainless)

                        'Get % for first bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for second bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for third bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case 4
                        'Increase price for THREE brackets (Tier 4) plus stainless

                        'Get % for first bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for second bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case 5
                        'Increase price for 2 bracketS (Tier 5) plus stainless

                        'Get % for first bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case 6
                        'Increase price for 1 bracket (Tier 6)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case Else
                        'Pricing is current
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                        Exit Sub
                End Select
            End If
            '***************************************************************************************
        Else   'Load last price for specific customer
            '***************************************************************************************
            'Get last sales date from invoice line table
            Dim MAXDateStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND CustomerID = @CustomerID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            MAXDateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT SalesOrderDate FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetYearPricingDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()

            'If price date is beyond the bracket, exit routine
            If GetYearPricingDate > "4/30/2022" Then
                'Pricing is current
                LastSalesPrice = Math.Round(LastSalesPrice, 4)
                txtLinePrice.Text = LastSalesPrice
                lblUpdatedPrice.Visible = False

                Exit Sub
            Else
                '***************************************************************************************
                'Determine the Price Increase Bracket it is in
                Dim GetBracketNumberStatement As String = "SELECT CostTierNumber FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND @PriceDate BETWEEN BeginDate AND EndDate"
                Dim GetBracketNumberCommand As New SqlCommand(GetBracketNumberStatement, con)
                GetBracketNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetBracketNumberCommand.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                GetBracketNumberCommand.Parameters.Add("@PriceDate", SqlDbType.VarChar).Value = GetYearPricingDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetBracketNumber = CInt(GetBracketNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetBracketNumber = 0
                End Try
                con.Close()


                Select Case GetBracketNumber
                    Case 1
                        'Increase price for 6 brackets (plus stainless)

                        'Get % for first bracket (Tier 1)
                        Dim GetPercentage1Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage1Command As New SqlCommand(GetPercentage1Statement, con)
                        GetPercentage1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage1Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage1Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 1

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage1 = CDbl(GetPercentage1Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage1 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage1)

                        'Get % for second bracket (Tier 2)
                        Dim GetPercentage2Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage2Command As New SqlCommand(GetPercentage2Statement, con)
                        GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage2Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage2Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 2

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage2 = CDbl(GetPercentage2Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage2 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage2)

                        'Get % for third bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for fourth bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for fifth bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case 2
                        'Increase price for 5 brackets (plus stainless)

                        'Get % for first bracket (Tier 2)
                        Dim GetPercentage2Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage2Command As New SqlCommand(GetPercentage2Statement, con)
                        GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage2Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage2Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 2

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage2 = CDbl(GetPercentage2Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage2 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage2)

                        'Get % for second bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for third bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for fourth bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case 3
                        'Increase price for FOUR brackets (plus stainless)

                        'Get % for first bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for second bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for third bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case 4
                        'Increase price for THREE brackets (Tier 4) plus stainless

                        'Get % for first bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for second bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case 5
                        'Increase price for 2 bracketS (Tier 5) plus stainless

                        'Get % for first bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case 6
                        'Increase price for 1 bracket (Tier 6)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                    Case Else
                        'Pricing is current
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLinePrice.Text = AdjustedLastSalesPrice
                        lblUpdatedPrice.Visible = True
                        Exit Sub
                End Select
            End If
        End If
    End Sub

    Public Sub LoadLastSalesPrice()
        'Determine if Item Class is subject to price increase
        Dim CheckItemClass As String = ItemClass
        Dim PriceIncreaseItem As String = ""

        Select Case CheckItemClass
            Case "TW CA", "TW SC", "TW DB", "TW DS", "TW TT", "TW TP", "TW CD", "TW NT", "TW CS", "TW PS", "TW CH", "TW IT", "TW SK", "TW SH", "TW TR", "TW TF", "TW RA", "TW KO"
                PriceIncreaseItem = "5PERCENT"
            Case "WASHERS", "U BOLTS", "TURNBUCKLES", "THREADED ROD", "TC BOLTS", "SOCKET SCREW", "SES", "SCREWS", "RIVET", "PUNCHES", "PINS", "MISC BOLTS", "METRIC", "LOCK NUTS", "LAG BOLTS", "JAM NUTS", "HEX NUTS", "HEX BOLTS", "EYE BOLTS", "EXP ANCHOR", "EPOXY", "DIES", "DES", "CUTTERS", "CPG NUTS", "CLEVIS", "CARR BOLTS", "BITS", "ANCHOR BOLTS"
                PriceIncreaseItem = "12PERCENT"
            Case "WC FERRULES", "WC WELD TILES"
                PriceIncreaseItem = "7PERCENT"
            Case "TW WELD PROD", "TWE ASSEMBLIES", "TWE STUD EQUIP COMP", "TWE CD COMPONENTS"
                PriceIncreaseItem = "5PERCENT"
            Case Else
                PriceIncreaseItem = "NO"
        End Select

        'Load values into Price Field
        Dim GetYearPricingDate As Date
        Dim UpdatedLastSalesPrice As Double = 0

        If cboDivisionID.Text = "SLC" Then
            Dim MAXDateStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MAXDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT SalesOrderDate FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetYearPricingDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MAXDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MAXDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()
        Else
            Dim MAXDateStatement As String = "SELECT MAX(InvoiceHeaderKey) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MAXDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT InvoiceDate FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceHeaderKey = @InvoiceHeaderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetYearPricingDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = MAXDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceHeaderKey = @InvoiceHeaderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = MAXDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()
        End If

        If GetYearPricingDate < GlobalTWDPriceChangeDate And cboDivisionID.Text = "TWD" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWD
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalTWDPriceChangeDate And cboDivisionID.Text = "SLC" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWD
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalSLCPriceChangeDate And cboDivisionID.Text = "SLC" And PriceIncreaseItem = "12PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierSLC
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalCHTPriceChangeDate And cboDivisionID.Text = "CHT" And PriceIncreaseItem = "7PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierCHT
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalTWEPriceChangeDate And cboDivisionID.Text = "TWE" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWE
            lblUpdatedPrice.Visible = True
        Else
            UpdatedLastSalesPrice = LastSalesPrice
            lblUpdatedPrice.Visible = False
        End If

        If UpdatedLastSalesPrice = 0 Then
            txtLinePrice.Clear()
        Else
            txtLinePrice.Text = UpdatedLastSalesPrice
        End If
    End Sub

    Public Sub LoadLastPurchaseCost()
        Dim strLastPurchaseCost As String = ""

        'Load values into Price Field (Last Purchase Cost for Remotes, Last Sale Price for TWD)
        Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
        MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MAXDate = CInt(MAXDateCommand.ExecuteScalar)
        Catch ex As Exception
            MAXDate = 0
        End Try
        con.Close()

        Dim LastCostStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
        Dim LastCostCommand As New SqlCommand(LastCostStatement, con)
        LastCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LastCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        LastCostCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MAXDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPurchaseCost = CDbl(LastCostCommand.ExecuteScalar)
        Catch ex As Exception
            LastPurchaseCost = 0
        End Try
        con.Close()

        If LastPurchaseCost = 0 Then
            lblLastPurchaseCost.Text = ""
        Else
            LastPurchaseCost = Math.Round(LastPurchaseCost, 4)
            strLastPurchaseCost = CStr(LastPurchaseCost)
            lblLastPurchaseCost.Text = "Last Cost - " + strLastPurchaseCost
        End If
    End Sub

    Public Sub LoadItemInfo()
        Dim strQOH As String = ""

        Dim BoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim BoxCountCommand As New SqlCommand(BoxCountStatement, con)
        BoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        BoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PartDescriptionStatement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescriptionCommand As New SqlCommand(PartDescriptionStatement, con)
        PartDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim LongDescriptionStatement As String = "SELECT LongDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PieceWeightCommand As New SqlCommand(PieceWeightStatement, con)
        PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim QOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim QOHCommand As New SqlCommand(QOHStatement, con)
        QOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        QOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
        ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BoxCount = CInt(BoxCountCommand.ExecuteScalar)
        Catch ex As Exception
            BoxCount = 0
        End Try
        Try
            PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            PartDescription = ""
        End Try
        Try
            PieceWeight = CDbl(PieceWeightCommand.ExecuteScalar)
        Catch ex As Exception
            PieceWeight = 0
        End Try
        Try
            QOH = CInt(QOHCommand.ExecuteScalar)
        Catch ex As Exception
            QOH = 0
        End Try
        Try
            LongDescription = CStr(LongDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            LongDescription = ""
        End Try
        Try
            ItemClass = CStr(ItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            ItemClass = ""
        End Try
        con.Close()

        'Load values into textboxes
        cboPartDescription.Text = PartDescription
        lblLongDescription.Text = LongDescription

        If QOH = 0 Then
            lblQOH.Text = ""
        Else
            strQOH = CStr(QOH)
            lblQOH.Text = "QOH - " + strQOH
        End If
    End Sub

    Public Sub LoadCustomerData()
        'Load Customer Name into text box based on Customer ID
        Dim CustomerNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerNameCommand As New SqlCommand(CustomerNameStatement, con)
        CustomerNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToAddress1Statement As String = "SELECT ShipToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipToAddress1Command As New SqlCommand(ShipToAddress1Statement, con)
        ShipToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToAddress2Statement As String = "SELECT ShipToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipToAddress2Command As New SqlCommand(ShipToAddress2Statement, con)
        ShipToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToCityStatement As String = "SELECT ShipToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipToCityCommand As New SqlCommand(ShipToCityStatement, con)
        ShipToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToStateStatement As String = "SELECT ShipToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipToStateCommand As New SqlCommand(ShipToStateStatement, con)
        ShipToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToZipStatement As String = "SELECT ShipToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipToZipCommand As New SqlCommand(ShipToZipStatement, con)
        ShipToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToCountryStatement As String = "SELECT ShipToCountry FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipToCountryCommand As New SqlCommand(ShipToCountryStatement, con)
        ShipToCountryCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipToCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SpecialInstructionsStatement As String = "SELECT ShippingDetails FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim SpecialInstructionsCommand As New SqlCommand(SpecialInstructionsStatement, con)
        SpecialInstructionsCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        SpecialInstructionsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesTaxRateStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim SalesTaxRateCommand As New SqlCommand(SalesTaxRateStatement, con)
        SalesTaxRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        SalesTaxRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesTaxRate2Statement As String = "SELECT SalesTaxRate2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim SalesTaxRate2Command As New SqlCommand(SalesTaxRate2Statement, con)
        SalesTaxRate2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        SalesTaxRate2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesTaxRate3Statement As String = "SELECT SalesTaxRate3 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim SalesTaxRate3Command As New SqlCommand(SalesTaxRate3Statement, con)
        SalesTaxRate3Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        SalesTaxRate3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PricingLevelStatement As String = "SELECT PricingLevel FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim PricingLevelCommand As New SqlCommand(PricingLevelStatement, con)
        PricingLevelCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        PricingLevelCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName = CStr(CustomerNameCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerName = cboCustomerName.Text
        End Try
        Try
            ShipToAddress1 = CStr(ShipToAddress1Command.ExecuteScalar)
        Catch ex As Exception
            ShipToAddress1 = ""
        End Try
        Try
            ShipToAddress2 = CStr(ShipToAddress2Command.ExecuteScalar)
        Catch ex As Exception
            ShipToAddress2 = ""
        End Try
        Try
            ShipToCity = CStr(ShipToCityCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToCity = ""
        End Try
        Try
            ShipToState = CStr(ShipToStateCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToState = ""
        End Try
        Try
            ShipToZip = CStr(ShipToZipCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToZip = ""
        End Try
        Try
            ShipToCountry = CStr(ShipToCountryCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToCountry = "USA"
        End Try
        Try
            SpecialInstructions = CStr(SpecialInstructionsCommand.ExecuteScalar)
        Catch ex As Exception
            SpecialInstructions = ""
        End Try
        Try
            SalesTaxRate = CDbl(SalesTaxRateCommand.ExecuteScalar)
        Catch ex As Exception
            SalesTaxRate = 0
        End Try
        Try
            SalesTaxRate2 = CDbl(SalesTaxRate2Command.ExecuteScalar)
        Catch ex As Exception
            SalesTaxRate2 = 0
        End Try
        Try
            SalesTaxRate3 = CDbl(SalesTaxRate3Command.ExecuteScalar)
        Catch ex As Exception
            SalesTaxRate3 = 0
        End Try
        Try
            PricingLevel = CStr(PricingLevelCommand.ExecuteScalar)
        Catch ex As Exception
            PricingLevel = ""
        End Try
        con.Close()

        'Load values into Labels
        cboCustomerName.Text = CustomerName
        txtShipToAddress1.Text = ShipToAddress1
        txtShipToAddress2.Text = ShipToAddress2
        txtShipToCity.Text = ShipToCity
        txtShipToState.Text = ShipToState
        txtShipToZip.Text = ShipToZip
        txtShipToCountry.Text = ShipToCountry

        GSTTaxRate = SalesTaxRate
        PSTTaxRate = SalesTaxRate2
        HSTTaxRate = SalesTaxRate3

        'If Customer is taxable, check box
        If cboDivisionID.Text <> "TFF" And SalesTaxRate > 0 Then
            chkTaxable.Checked = True
            txtTaxRate.Text = SalesTaxRate
        End If

        If cboDivisionID.Text = "TWD" Then
            PricingToolStripMenuItem.Visible = True
            PricingToolStripMenuItem.ForeColor = Color.Blue
            PricingToolStripMenuItem.Text = PricingLevel
        Else
            PricingToolStripMenuItem.Visible = False
            PricingToolStripMenuItem.Text = ""
        End If

        If txtSpecialInstructions.Text = "" Then
            txtSpecialInstructions.Text = SpecialInstructions
        Else
            'Do not load Special Instructions if field is not blank
        End If
    End Sub

    Public Sub CalculateTotals()
        'Show Totals
        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
        SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SUMSalesTaxStatement As String = "SELECT SUM(SalesTax) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim SUMSalesTaxCommand As New SqlCommand(SUMSalesTaxStatement, con)
        SUMSalesTaxCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        SUMSalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SUMLineWeightStatement As String = "SELECT SUM(LineWeight) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim SUMLineWeightCommand As New SqlCommand(SUMLineWeightStatement, con)
        SUMLineWeightCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        SUMLineWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            TotalSalesTax = CDbl(SUMSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            TotalSalesTax = 0
        End Try
        Try
            TotalOrderWeight = CDbl(SUMLineWeightCommand.ExecuteScalar)
        Catch ex As Exception
            TotalOrderWeight = 0
        End Try
        con.Close()

        TotalSalesTax = Math.Round(TotalSalesTax, 2)
        ProductTotal = Math.Round(ProductTotal, 2)

        FreightCharge = Val(txtFreightCharge.Text)
        QuoteTotal = FreightCharge + ProductTotal + TotalSalesTax

        TotalSalesTax2 = 0
        TotalSalesTax3 = 0

        'Load totals into text boxes
        lblEstimatedWeight.Text = FormatNumber(TotalOrderWeight, 2)
        lblSalesTax.Text = FormatCurrency(TotalSalesTax, 2)
        lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
        lblFreightCharge.Text = FormatCurrency(FreightCharge, 2)
        lblQuoteTotal.Text = FormatCurrency(QuoteTotal, 2)

        If ProductTotal = 0 Then
            AddTaxRate1 = 0
        Else
            AddTaxRate1 = TotalSalesTax / ProductTotal
        End If

        AddTaxRate1 = Math.Round(AddTaxRate1, 4)
        AddTaxRate2 = 0
        AddTaxRate3 = 0
    End Sub

    Public Sub LoadQuantityOnHand()
        Dim QuantityOnHand, QuantityCommitted, QuantityAvailable As Double
        Dim strQuantityCommitted, strQuantityAvailable As String
        Dim CommentString As String = ""

        'Show Quantity On Hand for specific division
        Dim QuantityOnHandString As String = "SELECT QuantityOnHand, OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim QuantityOnHandCommand As New SqlCommand(QuantityOnHandString, con)
        QuantityOnHandCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        QuantityOnHandCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = QuantityOnHandCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("QuantityOnHand")) Then
                QuantityOnHand = 0
            Else
                QuantityOnHand = reader.Item("QuantityOnHand")
            End If
            If IsDBNull(reader.Item("OpenSOQuantity")) Then
                QuantityCommitted = 0
            Else
                QuantityCommitted = reader.Item("OpenSOQuantity")
            End If
        Else
            QuantityOnHand = 0
            QuantityCommitted = 0
        End If
        reader.Close()
        con.Close()

        QuantityAvailable = QuantityOnHand - QuantityCommitted

        strQuantityAvailable = CStr(QuantityAvailable)
        strQuantityCommitted = CStr(QuantityCommitted)

        CommentString = "Quantity Available - " + strQuantityAvailable + " , Quantity Committed - " + strQuantityCommitted

        lblQuantityAvailable.Text = CommentString
    End Sub

    Public Sub CalculateCanadianTotals()
        Dim SUMProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim SUMProductTotalCommand As New SqlCommand(SUMProductTotalStatement, con)
        SUMProductTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        SUMProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim HSTValueStatement As String = "SELECT TotalSalesTax3 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim HSTValueCommand As New SqlCommand(HSTValueStatement, con)
        HSTValueCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        HSTValueCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(SUMProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            HSTValue = CDbl(HSTValueCommand.ExecuteScalar)
        Catch ex As Exception
            HSTValue = 0
        End Try
        con.Close()

        FreightCharge = Val(txtFreightCharge.Text)

        If HSTValue > 0 And txtHSTRate.Text = "" Then
            HSTTaxRate = HSTValue / ProductTotal
            txtHSTRate.Text = HSTTaxRate
        ElseIf HSTValue > 0 And txtHSTRate.Text <> "" Then
            HSTTaxRate = Val(txtHSTRate.Text)
        Else
            HSTTaxRate = Val(txtHSTRate.Text)
        End If

        GSTTaxRate = 0.05
        PSTTaxRate = 0.07

        If chkADDPST.Checked = True Then
            GSTExtendedAmount = GSTTaxRate * (ProductTotal + FreightCharge)
            PSTExtendedAmount = PSTTaxRate * (ProductTotal + FreightCharge)
            HSTExtendedAmount = 0
        ElseIf chkADDHST.Checked = True Then
            GSTExtendedAmount = 0
            PSTExtendedAmount = 0
            HSTExtendedAmount = HSTTaxRate * (ProductTotal + FreightCharge)
        Else
            GSTExtendedAmount = GSTTaxRate * (ProductTotal + FreightCharge)
            PSTExtendedAmount = 0
            HSTExtendedAmount = 0
        End If

        PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
        GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
        HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

        TotalSalesTax = GSTExtendedAmount
        TotalSalesTax2 = PSTExtendedAmount
        TotalSalesTax3 = HSTExtendedAmount

        QuoteTotal = FreightCharge + ProductTotal + GSTExtendedAmount + PSTExtendedAmount + HSTExtendedAmount

        lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
        lblSalesTax.Text = FormatCurrency(GSTExtendedAmount, 2)
        lblPSTExtendedAmount.Text = FormatCurrency(PSTExtendedAmount, 2)
        lblHSTExtendedAmount.Text = FormatCurrency(HSTExtendedAmount, 2)
        lblQuoteTotal.Text = FormatCurrency(QuoteTotal, 2)

        AddTaxRate1 = GSTTaxRate
        AddTaxRate2 = PSTTaxRate
        AddTaxRate3 = HSTTaxRate
    End Sub

    Public Sub LoadTotals()
        Dim TotalSalesTax2Statement As String = "SELECT TotalSalesTax2 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim TotalSalesTax2Command As New SqlCommand(TotalSalesTax2Statement, con)
        TotalSalesTax2Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        TotalSalesTax2Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalSalesTax3Statement As String = "SELECT TotalSalesTax3 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim TotalSalesTax3Command As New SqlCommand(TotalSalesTax3Statement, con)
        TotalSalesTax3Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        TotalSalesTax3Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalSalesTaxStatement As String = "SELECT TotalSalesTax FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim TotalSalesTaxCommand As New SqlCommand(TotalSalesTaxStatement, con)
        TotalSalesTaxCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        TotalSalesTaxCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ProductTotalStatement As String = "SELECT ProductTotal FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SOTotalStatement As String = "SELECT SOTotal FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim SOTotalCommand As New SqlCommand(SOTotalStatement, con)
        SOTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        SOTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalShippingWeightStatement As String = "SELECT ShippingWeight FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim TotalShippingWeightCommand As New SqlCommand(TotalShippingWeightStatement, con)
        TotalShippingWeightCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        TotalShippingWeightCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim FreightChargeStatement As String = "SELECT FreightCharge FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim FreightChargeCommand As New SqlCommand(FreightChargeStatement, con)
        FreightChargeCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        FreightChargeCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalSalesTax2 = CDbl(TotalSalesTax2Command.ExecuteScalar)
        Catch ex As Exception
            TotalSalesTax2 = 0
        End Try
        Try
            TotalSalesTax3 = CDbl(TotalSalesTax3Command.ExecuteScalar)
        Catch ex As Exception
            TotalSalesTax3 = 0
        End Try
        Try
            TotalSalesTax = CDbl(TotalSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            TotalSalesTax = 0
        End Try
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            QuoteTotal = CDbl(SOTotalCommand.ExecuteScalar)
        Catch ex As Exception
            QuoteTotal = 0
        End Try
        Try
            TotalShippingWeight = CDbl(TotalShippingWeightCommand.ExecuteScalar)
        Catch ex As Exception
            TotalShippingWeight = 0
        End Try
        Try
            FreightCharge = CDbl(FreightChargeCommand.ExecuteScalar)
        Catch ex As Exception
            FreightCharge = 0
        End Try
        con.Close()

        lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
        lblFreightCharge.Text = FormatCurrency(FreightCharge, 2)
        lblEstimatedWeight.Text = FormatNumber(TotalShippingWeight, 1)
        lblHSTExtendedAmount.Text = FormatCurrency(TotalSalesTax3, 2)
        lblPSTExtendedAmount.Text = FormatCurrency(TotalSalesTax2, 2)
        lblSalesTax.Text = FormatCurrency(TotalSalesTax, 2)
        lblQuoteTotal.Text = FormatCurrency(QuoteTotal, 2)
    End Sub

    Public Sub LoadCanadianTaxRates()
        chkADDHST.Checked = False
        chkADDPST.Checked = False

        Dim GSTRateString As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GSTRateCommand As New SqlCommand(GSTRateString, con)
        GSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PSTRateString As String = "SELECT SalesTaxRate2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim PSTRateCommand As New SqlCommand(PSTRateString, con)
        PSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        PSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim HSTRateString As String = "SELECT SalesTaxRate3 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim HSTRateCommand As New SqlCommand(HSTRateString, con)
        HSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        HSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GSTTaxRate = CDbl(GSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            GSTTaxRate = 0
        End Try
        Try
            PSTTaxRate = CDbl(PSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            PSTTaxRate = 0
        End Try
        Try
            HSTTaxRate = CDbl(HSTRateCommand.ExecuteScalar)
        Catch ex As Exception
            HSTTaxRate = 0
        End Try
        con.Close()

        If PSTTaxRate > 0 Then chkADDPST.Checked = True
        If HSTTaxRate > 0 Then chkADDHST.Checked = True
    End Sub

    Public Sub LoadTaxRate()
        Dim SalesTaxStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim SalesTaxCommand As New SqlCommand(SalesTaxStatement, con)
        SalesTaxCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        SalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TaxRate = CDbl(SalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            TaxRate = 0
        End Try
        con.Close()

        txtTaxRate.Text = TaxRate
    End Sub

    'Error Checking and Clear Commands

    Public Sub ClearData()
        cboCustomerName.Text = ""
        cboPartDescription.Text = ""
        cboCustomerID.Text = ""
        cboPartNumber.Text = ""
        cboQuoteNumber.Text = ""
        cboShipVia.Text = ""
        cboShipToID.Text = ""
        cboQuoteLineDescription.Text = ""
        cboQuoteLineNumber.Text = ""
        cboQuoteLinePart.Text = ""
        cboShipMethod.Text = ""

        cboCustomerName.Refresh()
        cboPartDescription.Refresh()
        cboCustomerID.Refresh()
        cboPartNumber.Refresh()
        cboQuoteNumber.Refresh()
        cboShipVia.Refresh()
        cboShipToID.Refresh()
        cboQuoteLineDescription.Refresh()
        cboQuoteLineNumber.Refresh()
        cboQuoteLinePart.Refresh()

        txtComment.Refresh()
        txtContact.Refresh()
        txtFreightCharge.Refresh()
        txtLinePrice.Refresh()
        txtQuantity.Refresh()
        txtLeadDate.Refresh()
        txtLineComment.Refresh()
        txtShipToAddress1.Refresh()
        txtShipToAddress2.Refresh()
        txtShipToCity.Refresh()
        txtShipToState.Refresh()
        txtShipToZip.Refresh()
        txtShipToCountry.Refresh()
        txtExtendedAmount.Refresh()
        txtQuoteExtendedAmount.Refresh()
        txtQuoteLineComment.Refresh()
        txtQuoteLineLeadTime.Refresh()
        txtQuoteLinePrice.Refresh()
        txtQuoteLineQuantity.Refresh()
        txtExtendedAmount.Refresh()
        txtHSTRate.Refresh()
        txtLinePrice.Refresh()
        txtQuantity.Refresh()
        txtSpecialInstructions.Refresh()
        txtTaxRate.Refresh()
        txtCustomerPO.Refresh()

        cboCustomerName.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboQuoteNumber.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboShipToID.SelectedIndex = -1
        cboQuoteLineDescription.SelectedIndex = -1
        cboQuoteLineNumber.SelectedIndex = -1
        cboQuoteLinePart.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1

        cboSalesperson.Text = EmployeeSalespersonCode

        txtComment.Clear()
        txtContact.Clear()
        txtFreightCharge.Clear()
        txtLinePrice.Clear()
        txtQuantity.Clear()
        txtLeadDate.Clear()
        txtLineComment.Clear()
        txtShipToAddress1.Clear()
        txtShipToAddress2.Clear()
        txtShipToCity.Clear()
        txtShipToState.Clear()
        txtShipToZip.Clear()
        txtShipToCountry.Clear()
        txtShipToName.Clear()
        txtExtendedAmount.Clear()
        txtQuoteExtendedAmount.Clear()
        txtQuoteLineComment.Clear()
        txtQuoteLineLeadTime.Clear()
        txtQuoteLinePrice.Clear()
        txtQuoteLineQuantity.Clear()
        txtExtendedAmount.Clear()
        txtHSTRate.Clear()
        txtLinePrice.Clear()
        txtQuantity.Clear()
        txtSpecialInstructions.Clear()
        txtTaxRate.Clear()
        txtCustomerPO.Clear()
        txtThirdPartyShipper.Clear()

        lblEstimatedWeight.Text = ""
        lblFreightCharge.Text = ""
        lblProductTotal.Text = ""
        lblQuoteTotal.Text = ""
        lblSalesTax.Text = ""
        lblLastPurchaseCost.Text = ""
        lblHSTExtendedAmount.Text = ""
        lblPSTExtendedAmount.Text = ""
        lblLongDescription.Text = ""
        lblQOH.Text = ""
        lblQuantityAvailable.Text = ""

        lblUpdatedPrice.Visible = False

        chkADDHST.Checked = False
        chkADDPST.Checked = False
        chkTaxable.Checked = False
        chkNewCustomer.Checked = False

        dtpQuoteDate.Text = ""
        dtpDeliveryDate.Text = ""

        If EmployeeCompanyCode = "CBS" Then
            cboShipVia.Text = "Will Call"
        Else
            cboShipVia.Text = "Delivery"
        End If

        cmdGenerateNewQuote.Focus()
    End Sub

    Public Sub ClearVariables()
        ThirdPartyShipper = ""
        ShippingMethod = ""
        PricingLevel = ""
        CountPartNumber = 0
        LineQuantity = 0
        LinePrice = 0
        LineTax = 0
        TaxRate = 0
        FreightCharge = 0
        NewExtendedAmount = 0
        TotalSalesTax = 0
        TotalSalesTax2 = 0
        TotalSalesTax3 = 0
        LastPurchaseCost = 0
        ItemPrice = 0
        LastSalesPrice = 0
        PieceWeight = 0
        StandardPrice = 0
        EstFreight = 0
        ItemPieceWeight = 0
        TotalLineWeight = 0
        TotalOrderWeight = 0
        LineTotal = 0
        ProductTotal = 0
        QuoteTotal = 0
        LongDescription = ""
        SpecialInstructions = ""
        ShipToID = ""
        ShipToName = ""
        ShipVia = ""
        ItemClass = ""
        CreditGLAccount = ""
        DebitGLAccount = ""
        QuoteStatus = ""
        PartNumber = ""
        PartDescription = ""
        CheckPartNumber = ""
        MAXDate = 0
        QOH = 0
        Counter = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        LastLineNumber = 0
        NextLineNumber = 0
        CheckOrderQuantity = 0
        GetLineNumber = 0
        NewOrderQuantity = 0
        BoxCount = 0
        LineBoxes = 0
        CustomerID = ""
        CustomerName = ""
        Salesperson = ""
        HeaderComment = ""
        ShipToAddress1 = ""
        ShipToAddress2 = ""
        ShipToCity = ""
        ShipToState = ""
        ShipToZip = ""
        ShipToCountry = ""
        GSTTaxRate = 0
        PSTTaxRate = 0
        HSTTaxRate = 0
        GSTExtendedAmount = 0
        PSTExtendedAmount = 0
        HSTExtendedAmount = 0
        SalesTaxRate = 0
        SalesTaxRate2 = 0
        SalesTaxRate3 = 0
        TotalShippingWeight = 0
        EditLinePart = ""
        EditLineDescription = ""
        EditLineLeadTime = ""
        EditLineComment = ""
        EditLineQuantity = 0
        EditLineExtendedAmount = 0
        EditLinePrice = 0
        EditLineSalesTax = 0
        HSTValue = 0
        CustomerPO = ""
        AddTaxRate1 = 0
        AddTaxRate2 = 0
        AddTaxRate3 = 0
    End Sub

    Public Sub ClearShippingAddress()
        cboShipToID.SelectedIndex = -1
        txtShipToName.Clear()
        txtShipToAddress1.Clear()
        txtShipToAddress2.Clear()
        txtShipToCity.Clear()
        txtShipToCountry.Clear()
        txtShipToState.Clear()
        txtShipToZip.Clear()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSalesOrderLines.DataSource = Nothing
    End Sub

    'Datagrid Operations

    Private Sub dgvSalesOrderLines_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSalesOrderLines.CellContentClick
        Dim LineNumber As Integer

        If Me.dgvSalesOrderLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvSalesOrderLines.CurrentCell.RowIndex

            Try
                LineNumber = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("SalesOrderLineKeyColumn").Value
            Catch ex As Exception
                LineNumber = 0
            End Try

            cboQuoteLineNumber.Text = LineNumber
        End If
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvSalesOrderLines.CellValueChanged
        Dim OldQuoteQuantity, LineQuantity, CurrentLineTax, OldQuotePrice, PriceDifference, LineExtendedAmount, LinePrice, LineSalesTax, LineWeight, LineBoxes As Double
        Dim LineNumber As Integer
        Dim LinePartNumber, LineComment, LinePartDescription As String

        If Me.dgvSalesOrderLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvSalesOrderLines.CurrentCell.RowIndex

            Try
                LinePrice = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("PriceColumn").Value
            Catch ex As Exception
                LinePrice = 0
            End Try
            Try
                LineQuantity = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("QuantityColumn").Value
            Catch ex As Exception
                LineQuantity = 0
            End Try
            Try
                LineNumber = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("SalesOrderLineKeyColumn").Value
            Catch ex As Exception
                LineNumber = 0
            End Try
            Try
                LinePartNumber = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("ItemIDColumn").Value
            Catch ex As Exception
                LinePartNumber = ""
            End Try
            Try
                LinePartDescription = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("DescriptionColumn").Value
            Catch ex As Exception
                LinePartDescription = ""
            End Try
            Try
                LineComment = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                LineComment = ""
            End Try
            Try
                CurrentLineTax = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("SalesTaxColumn").Value
            Catch ex As Exception
                CurrentLineTax = 0
            End Try
            '********************************************************************************************************************************
            'Get weight and box count to update lines
            Dim PieceWeightString As String = "SELECT PieceWeight FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim PieceWeightCommand As New SqlCommand(PieceWeightString, con)
            PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = LinePartNumber
            PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim BoxCountString As String = "SELECT BoxCount FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim BoxCountCommand As New SqlCommand(BoxCountString, con)
            BoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = LinePartNumber
            BoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PieceWeight = CDbl(PieceWeightCommand.ExecuteScalar)
            Catch ex As Exception
                PieceWeight = 0
            End Try
            Try
                BoxCount = CInt(BoxCountCommand.ExecuteScalar)
            Catch ex As Exception
                BoxCount = 0
            End Try
            con.Close()
            '********************************************************************************************************************************
            'Get old price and quantity to determine if changes have been made
            Dim OldQuoteQuantityString As String = "SELECT Quantity FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey AND DivisionID = @DivisionID"
            Dim OldQuoteQuantityCommand As New SqlCommand(OldQuoteQuantityString, con)
            OldQuoteQuantityCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
            OldQuoteQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            OldQuoteQuantityCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = LineNumber

            Dim OldQuotePriceString As String = "SELECT Price FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey AND DivisionID = @DivisionID"
            Dim OldQuotePriceCommand As New SqlCommand(OldQuotePriceString, con)
            OldQuotePriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
            OldQuotePriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            OldQuotePriceCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = LineNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                OldQuoteQuantity = CDbl(OldQuoteQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                OldQuoteQuantity = 0
            End Try
            Try
                OldQuotePrice = CDbl(OldQuotePriceCommand.ExecuteScalar)
            Catch ex As Exception
                OldQuotePrice = 0
            End Try
            con.Close()
            '********************************************************************************************************************************
            'Calculate Line Totals
            LineWeight = PieceWeight * LineQuantity
            LineExtendedAmount = LinePrice * LineQuantity
            '********************************************************************************************************************************
            If BoxCount = 0 Then
                LineBoxes = 0
            Else
                LineBoxes = LineQuantity / BoxCount
            End If
            '********************************************************************************************************************************
            'Compare prices to see if change is made
            PriceDifference = OldQuotePrice - LinePrice
            If PriceDifference < 0 Then PriceDifference = PriceDifference * -1

            If PriceDifference < 0.01 And OldQuoteQuantity = LineQuantity Then
                LineSalesTax = CurrentLineTax
            Else
                'Load Tax Rate if customer is taxable
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    LineSalesTax = 0
                Else
                    LoadTaxRate()

                    LineSalesTax = TaxRate * LineExtendedAmount
                End If
            End If

            'Round variables
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
            '********************************************************************************************************************************
            'UPDATE Sales Order based on line changes
            cmd = New SqlCommand("UPDATE SalesOrderLineTable SET ItemID = @ItemID, Description = @Description, Price = @Price, Quantity = @Quantity, ExtendedAmount = @ExtendedAmount, SalesTax = @SalesTax, LineWeight = @LineWeight, LineBoxes = @LineBoxes, LineComment = @LineComment WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = LineNumber
                .Add("@ItemID", SqlDbType.VarChar).Value = LinePartNumber
                .Add("@Description", SqlDbType.VarChar).Value = LinePartDescription
                .Add("@Price", SqlDbType.VarChar).Value = LinePrice
                .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                .Add("@SalesTax", SqlDbType.VarChar).Value = LineSalesTax
                .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeight
                .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxes
                .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************************************************
            'Calculate totals
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                'Calculate totals based on user entry
                If chkADDPST.Checked = True Then
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = 0

                    FreightCharge = Val(txtFreightCharge.Text)

                    PSTExtendedAmount = (ProductTotal + FreightCharge) * PSTTaxRate
                    GSTExtendedAmount = (ProductTotal + FreightCharge) * GSTTaxRate
                    HSTExtendedAmount = (ProductTotal + FreightCharge) * HSTTaxRate

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                ElseIf chkADDHST.Checked = True Then
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = Val(txtHSTRate.Text)

                    FreightCharge = Val(txtFreightCharge.Text)

                    PSTExtendedAmount = 0
                    GSTExtendedAmount = 0
                    HSTExtendedAmount = (ProductTotal + FreightCharge) * HSTTaxRate

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                Else
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = 0

                    FreightCharge = Val(txtFreightCharge.Text)

                    PSTExtendedAmount = 0
                    GSTExtendedAmount = (ProductTotal + FreightCharge) * GSTTaxRate
                    HSTExtendedAmount = 0

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                End If
            Else
                CalculateTotals()
            End If
            '********************************************************************************
            'Update quote header Table
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET FreightCharge = @FreightCharge, TotalSalesTax = @TotalSalesTax, ProductTotal = @ProductTotal, SOTotal = @SOTotal, TotalSalesTax2 = @TotalSalesTax2, TotalSalesTax3 = @TotalSalesTax3 WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                .Add("@TotalSalesTax", SqlDbType.VarChar).Value = TotalSalesTax
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@SOTotal", SqlDbType.VarChar).Value = QuoteTotal
                .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = TotalSalesTax2
                .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = TotalSalesTax3
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Load Total Weight
            LoadTotals()
            '********************************************************************************************************************************
            'Clear Variables
            LineWeight = 0
            PieceWeight = 0
            LineBoxes = 0
            LinePrice = 0
            LineQuantity = 0
            LineExtendedAmount = 0
            LinePartNumber = ""
            LinePartDescription = ""
            LineComment = ""
            OldQuoteQuantity = 0
            CurrentLineTax = 0
            OldQuotePrice = 0
            PriceDifference = 0
            LineSalesTax = 0
            LineWeight = 0
            LineBoxes = 0
            TotalSalesTax = 0
            TotalSalesTax2 = 0
            TotalSalesTax3 = 0
            ProductTotal = 0
            QuoteTotal = 0

            ShowData()
            LoadTotals()
        End If
    End Sub

    'Combo Box events

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        'Set date format
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LabelPSTTotal.Visible = True
            LabelHSTTotal.Visible = True
            LabelGSTTotal.Text = "GST"
            lblPSTExtendedAmount.Visible = True
            lblHSTExtendedAmount.Visible = True
            chkADDHST.Visible = True
            chkADDPST.Visible = True
            chkTaxable.Visible = False
            cmdRemoveSalesTax.Visible = False
            dgvSalesOrderLines.Columns("SalesTaxColumn").Visible = False
        Else
            LabelPSTTotal.Visible = False
            LabelHSTTotal.Visible = False
            LabelGSTTotal.Text = "Sales Tax"
            lblPSTExtendedAmount.Visible = False
            lblHSTExtendedAmount.Visible = False
            chkTaxable.Visible = True
            chkADDHST.Visible = False
            chkADDPST.Visible = False
            cmdRemoveSalesTax.Visible = True
            dgvSalesOrderLines.Columns("SalesTaxColumn").Visible = True
        End If

        'Initialize Data
        LoadCustomerList()
        LoadCustomerName()
        LoadPartNumber()
        LoadPartDescription()
        LoadEditPartNumber()
        LoadQuoteNumber()
        LoadSalesperson()
        ClearVariables()
        ClearData()

        If EmployeeCompanyCode = "CBS" Then
            cboShipVia.Text = "Will Call"
            cboSalesperson.Enabled = True
        ElseIf EmployeeCompanyCode = "SLC" Then
            cboShipVia.Text = "SEE SALESMAN"
        Else
            cboShipVia.Text = "Delivery"
        End If

        If GlobalSONumber < 1 Then
            cboQuoteNumber.SelectedIndex = -1
        Else
            cboQuoteNumber.Text = GlobalSONumber
        End If

        ShowData()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        ClearShippingAddress()

        LoadAdditionalShipTo()
        LoadCustomerData()
        LoadCustomerNameByID()

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LoadCanadianTaxRates()
        End If

        'Create variables to use in lookup tables
        GlobalCustomerID = cboCustomerID.Text
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If cboPartNumber.Text = "" Then
            'Do nothing
            lblLastPurchaseCost.Text = ""
            lblQOH.Text = ""
            lblQuantityAvailable.Text = ""
        Else
            LoadItemInfo()
            LoadLastPurchaseCost()
            LoadDescriptionByPart()
            LoadQuantityOnHand()

            If cboDivisionID.Text = "TWD" Then
                CurrentPartNumber = cboPartNumber.Text

                LoadLastSalesPriceTWDRevised()
            Else
                LoadLastSalesPrice()
            End If

            'Create variables to use in lookup tables
            GlobalMaintenancePartNumber = cboPartNumber.Text
        End If
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboShipToID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipToID.SelectedIndexChanged
        LoadShipToDetails()
    End Sub

    Private Sub cboQuoteLineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboQuoteLineNumber.SelectedIndexChanged
        LoadLineData()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboQuoteNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboQuoteNumber.SelectedIndexChanged
        If Val(cboQuoteNumber.Text) > 0 Then
            ClearShippingAddress()
            ShowData()
            LoadQuoteData()
        Else
            ClearVariables()
            ClearData()
            ShowData()
        End If
    End Sub

    Private Sub cboShipMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipMethod.SelectedIndexChanged
        If cboShipMethod.Text = "THIRD PARTY" Then
            txtThirdPartyShipper.Enabled = True
        Else
            txtThirdPartyShipper.Enabled = False
            txtThirdPartyShipper.Clear()
        End If
    End Sub

    'Test Box Events

    Private Sub txtHSTRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHSTRate.TextChanged
        'Recalc HST and totals on change
        Dim SUMProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim SUMProductTotalCommand As New SqlCommand(SUMProductTotalStatement, con)
        SUMProductTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
        SUMProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(SUMProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        con.Close()

        FreightCharge = Val(txtFreightCharge.Text)

        HSTExtendedAmount = (ProductTotal + FreightCharge) * Val(txtHSTRate.Text)
        PSTExtendedAmount = 0
        GSTExtendedAmount = 0
        QuoteTotal = PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + FreightCharge + ProductTotal

        lblHSTExtendedAmount.Text = FormatCurrency(HSTExtendedAmount, 2)
        lblQuoteTotal.Text = FormatCurrency(QuoteTotal, 2)
    End Sub

    Private Sub txtFreightCharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightCharge.TextChanged
        FreightCharge = Val(txtFreightCharge.Text)
        lblFreightCharge.Text = FormatCurrency(FreightCharge, 2)

        If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
            'Update Tax with change in freight anount
            CalculateCanadianTotals()
        Else
            CalculateTotals()
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        LineQuantity = Val(txtQuantity.Text)
        ItemPrice = Val(txtLinePrice.Text)
        LineTotal = ItemPrice * LineQuantity
        txtExtendedAmount.Text = FormatCurrency(LineTotal, 2)
    End Sub

    Private Sub txtLinePrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLinePrice.TextChanged
        LineQuantity = Val(txtQuantity.Text)
        ItemPrice = Val(txtLinePrice.Text)
        LineTotal = ItemPrice * LineQuantity
        txtExtendedAmount.Text = FormatCurrency(LineTotal, 2)
    End Sub

    Private Sub txtQuoteLineQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuoteLineQuantity.TextChanged
        EditNewLineQuantity = Val(txtQuoteLineQuantity.Text)
        EditItemPrice = Val(txtQuoteLinePrice.Text)
        EditLineTotal = EditItemPrice * EditNewLineQuantity
        txtQuoteExtendedAmount.Text = FormatCurrency(EditLineTotal, 2)
    End Sub

    Private Sub txtQuoteLinePrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuoteLinePrice.TextChanged
        EditNewLineQuantity = Val(txtQuoteLineQuantity.Text)
        EditItemPrice = Val(txtQuoteLinePrice.Text)
        EditLineTotal = EditItemPrice * EditNewLineQuantity
        txtQuoteExtendedAmount.Text = FormatCurrency(EditLineTotal, 2)
    End Sub

    'Command Buttons

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If cboQuoteNumber.Text = "" Or Val(cboQuoteNumber.Text) = 0 Or cboCustomerID.Text = "" Then
            MsgBox("You must have a valid Quote Number / Customer selected.", MsgBoxStyle.OkOnly)
        Else
            '********************************************************************************
            If cboCustomerID.Text <> "" Or cboCustomerName.Text <> "" Then
                'Continue
            Else
                MsgBox("You must have a valid customer ID and name.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '********************************************************************************
            'Check if Customer Exits
            Dim CheckCustomer As Integer = 0

            Dim CheckCustomerStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CheckCustomerCommand As New SqlCommand(CheckCustomerStatement, con)
            CheckCustomerCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CheckCustomerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckCustomer = CInt(CheckCustomerCommand.ExecuteScalar)
            Catch ex As Exception
                CheckCustomer = 0
            End Try
            con.Close()

            If CheckCustomer = 0 Then
                'Add customer to database if necessary
                If chkNewCustomer.Checked = True Then
                    Try
                        'Create command to insert new record into database
                        SaveInsertIntoCustomerList()
                        chkNewCustomer.Checked = False
                    Catch ex As Exception
                        'Error Log
                    End Try
                Else
                    'Ask if new customer should be created
                    Dim button1 As DialogResult = MessageBox.Show("Customer does not exist - do you wish to create it?", "NEW CUSTOMER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button1 = DialogResult.Yes Then
                        Try
                            'Create command to insert new record into database
                            SaveInsertIntoCustomerList()
                            chkNewCustomer.Checked = False
                        Catch ex As Exception
                            'Error Log
                        End Try
                    ElseIf button1 = DialogResult.No Then
                        'Exit save 
                        MsgBox("Quote will not be saved.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                End If
            Else
                'Continue
                chkNewCustomer.Checked = False
            End If
            '********************************************************************************
            'Check to make sure Quote/Sales Order is correct
            Dim CheckDivision As String = ""

            Dim CheckDivisionStatement As String = "SELECT DivisionKey FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim CheckDivisionCommand As New SqlCommand(CheckDivisionStatement, con)
            CheckDivisionCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckDivision = CStr(CheckDivisionCommand.ExecuteScalar)
            Catch ex As Exception
                CheckDivision = ""
            End Try
            con.Close()

            If CheckDivision <> cboDivisionID.Text Then
                MsgBox("There is an issue with this quote. Contact ADMIN.", MsgBoxStyle.OkOnly)

                'Error Log
                Dim TempQuoteNumber As Integer = 0
                Dim strQuoteNumber As String
                TempQuoteNumber = Val(cboQuoteNumber.Text)
                strQuoteNumber = CStr(TempQuoteNumber)

                ErrorDate = Today()
                ErrorComment = "Division " + cboDivisionID.Text + " does not match SO Division - " + CheckDivision
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Quote Form - ADD LINES - Invalid Division"
                ErrorReferenceNumber = "Quote # " + strQuoteNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                Exit Sub
            Else
                'Skip
            End If
            '********************************************************************************
            Try
                'Recalculate grid totals in case of changes
                cmd = New SqlCommand("Update SalesOrderLineTable SET ExtendedAmount = Quantity * Price WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip - no lines
            End Try

            If Not IsNumeric(txtQuantity.Text) Or Not IsNumeric(txtLinePrice.Text) Then
                MessageBox.Show("Please enter numeric data in Quantity and Price Fields", "INVALID ENTRY")
            Else
                '********************************************************************************
                'Validate part number
                Dim CountPartNumberStatement As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim CountPartNumberCommand As New SqlCommand(CountPartNumberStatement, con)
                CountPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                CountPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountPartNumber = CInt(CountPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    CountPartNumber = 0
                End Try
                con.Close()

                If CountPartNumber = 0 Then
                    MsgBox("This part number does not exist in the database. Please create it first in Item Maintenance.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '********************************************************************************
                'Load previous totals
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CalculateCanadianTotals()
                Else
                    CalculateTotals()
                    'Total Order Weight is defined
                End If

                'Define Current Piece Weight Variable
                Dim GetPieceWeight As Double = 0

                'Load Current Variables
                LineQuantity = Val(txtQuantity.Text)
                LinePrice = Val(txtLinePrice.Text)

                'Get Part Number piece weight
                Dim GetPieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetPieceWeightCommand As New SqlCommand(GetPieceWeightStatement, con)
                GetPieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                GetPieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPieceWeight = CDbl(GetPieceWeightCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPieceWeight = 0
                End Try
                con.Close()

                TotalLineWeight = GetPieceWeight * LineQuantity
                TotalOrderWeight = TotalOrderWeight + TotalLineWeight
                lblEstimatedWeight.Text = TotalOrderWeight

                TotalLineWeight = Math.Round(TotalLineWeight, 1)

                LineTotal = LinePrice * LineQuantity

                If chkTaxable.Checked = True Then
                    LineTax = LineTotal * Val(txtTaxRate.Text)
                    TotalSalesTax = TotalSalesTax + LineTax
                Else
                    LineTax = 0
                End If

                ProductTotal = ProductTotal + LineTotal
                lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
                QuoteTotal = ProductTotal + FreightCharge + TotalSalesTax

                'Round variables
                LineTotal = Math.Round(LineTotal, 2)
                '********************************************************************************
                SalesOrderDate = dtpQuoteDate.Value
                ShippingDate = dtpDeliveryDate.Value
                '********************************************************************************
                'Do not write Line Tax if Canadian
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    LineTax = 0
                Else
                    'Do nothing
                End If
                '********************************************************************************
                'Calculate the Line box count
                If BoxCount = 0 Then
                    LineBoxes = 0
                Else
                    LineBoxes = LineQuantity / BoxCount
                    LineBoxes = Math.Round(LineBoxes, 1)
                End If
                '********************************************************************************
                Try
                    'Write Data to Sales Order Header Database Table
                    SaveUpdateSalesOrderHeader()
                Catch ex As Exception
                    MsgBox("There is an issue with this quote. Contact ADMIN.", MsgBoxStyle.OkOnly)

                    'Error Log
                    Dim TempQuoteNumber As Integer = 0
                    Dim strQuoteNumber As String
                    TempQuoteNumber = Val(cboQuoteNumber.Text)
                    strQuoteNumber = CStr(TempQuoteNumber)

                    ErrorDate = Today()
                    ErrorComment = "Division " + cboDivisionID.Text + " does not match SO Division - " + CheckDivision
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Quote Form - ADD LINES - UPDATE COMMAND"
                    ErrorReferenceNumber = "Quote # " + strQuoteNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                End Try
                '********************************************************************************
                'Determine Line Number
                Dim MAXLineStatement As String = "SELECT MAX(SalesOrderLineKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey"
                Dim MAXLineCommand As New SqlCommand(MAXLineStatement, con)
                MAXLineCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = cboQuoteNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastLineNumber = CInt(MAXLineCommand.ExecuteScalar)
                Catch ex As Exception
                    LastLineNumber = 0
                End Try
                con.Close()

                NextLineNumber = LastLineNumber + 1
                '********************************************************************************
                'Get GL Accounts
                Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
                ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ItemClass = CStr(ItemClassCommand.ExecuteScalar)
                Catch ex As Exception
                    ItemClass = "TW CA"
                End Try
                con.Close()

                Dim DebitGLAccountStatement As String = "SELECT GLSalesOffsetAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                Dim DebitGLAccountCommand As New SqlCommand(DebitGLAccountStatement, con)
                DebitGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                Dim CreditGLAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                Dim CreditGLAccountCommand As New SqlCommand(CreditGLAccountStatement, con)
                CreditGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    DebitGLAccount = CStr(DebitGLAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    DebitGLAccount = "49999"
                End Try
                Try
                    CreditGLAccount = CStr(CreditGLAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    CreditGLAccount = "12150"
                End Try
                con.Close()
                '********************************************************************************
                'Get Certification Type
                'If cert code is blank, get default
                Dim GetCertCode As String = "0"

                Dim GetCertCodeStatement As String = "SELECT CertificationType FROM FOXTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                Dim GetCertCodeCommand As New SqlCommand(GetCertCodeStatement, con)
                GetCertCodeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                GetCertCodeCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetCertCode = CStr(GetCertCodeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetCertCode = "0"
                End Try
                con.Close()

                If GetCertCode = "" Then
                    'If Cert Code is blank, use default
                    Dim NewGetCertCode As String = ""

                    Select Case ItemClass
                        Case "TW DS"
                            NewGetCertCode = "1"
                        Case "TW CA"
                            NewGetCertCode = "1"
                        Case "TW SC"
                            NewGetCertCode = "1"
                        Case "TW DB"
                            NewGetCertCode = "2"
                        Case "TW TT"
                            NewGetCertCode = "6"
                        Case "TW TP"
                            NewGetCertCode = "6"
                        Case "TW CS"
                            NewGetCertCode = "6"
                        Case "TW NT"
                            NewGetCertCode = "6"
                        Case "TW PS"
                            NewGetCertCode = "1"
                        Case Else
                            NewGetCertCode = "0"
                    End Select

                    GetCertCode = NewGetCertCode
                Else
                    'Do nothing
                End If
                '********************************************************************************
                'Write Data to Sales Order Line Database Table (Line Items)
                cmd = New SqlCommand("Insert Into SalesOrderLineTable(SalesOrderKey, SalesOrderLineKey, ItemID, Description, Quantity, Price, LineComment, SalesTax, DivisionID, ExtendedAmount, LineWeight, LineBoxes, LineStatus, DebitGLAccount, CreditGLAccount, LeadTime, CertificationType, EstExtendedCOS, ShippedPrevious)Values(@SalesOrderKey, @SalesOrderLineKey, @ItemID, @Description, @Quantity, @Price, @LineComment, @SalesTax, @DivisionID, @ExtendedAmount, @LineWeight, @LineBoxes, @LineStatus, @DebitGLAccount, @CreditGLAccount, @LeadTime, @CertificationType, @EstExtendedCOS, @ShippedPrevious)", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = NextLineNumber
                    .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@Description", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                    .Add("@Price", SqlDbType.VarChar).Value = Val(txtLinePrice.Text)
                    .Add("@SalesTax", SqlDbType.VarChar).Value = LineTax
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineTotal
                    .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "QUOTE"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@LineWeight", SqlDbType.VarChar).Value = TotalLineWeight
                    .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxes
                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = DebitGLAccount
                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = CreditGLAccount
                    .Add("@LeadTime", SqlDbType.VarChar).Value = txtLeadDate.Text
                    .Add("@CertificationType", SqlDbType.VarChar).Value = GetCertCode
                    .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = 0
                    .Add("@ShippedPrevious", SqlDbType.VarChar).Value = 0
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***************************************************************************************
                'Get Nominal Diameter and Nominal Length
                Dim NominalDiameter, NominalLength As Double

                Dim GetNominalDiameterStatement As String = "SELECT NominalDiameter FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetNominalDiameterCommand As New SqlCommand(GetNominalDiameterStatement, con)
                GetNominalDiameterCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                GetNominalDiameterCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim GetNominalLengthStatement As String = "SELECT NominalLength FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetNominalLengthCommand As New SqlCommand(GetNominalLengthStatement, con)
                GetNominalLengthCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                GetNominalLengthCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim AddAccessoryStatement As String = "SELECT AddAccessory FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim AddAccessoryCommand As New SqlCommand(AddAccessoryStatement, con)
                AddAccessoryCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                AddAccessoryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    NominalDiameter = CDbl(GetNominalDiameterCommand.ExecuteScalar)
                Catch ex As Exception
                    NominalDiameter = 0
                End Try
                Try
                    NominalLength = CDbl(GetNominalLengthCommand.ExecuteScalar)
                Catch ex As Exception
                    NominalLength = 0
                End Try
                Try
                    AddAccessory = CStr(AddAccessoryCommand.ExecuteScalar)
                Catch ex As Exception
                    AddAccessory = "NO"
                End Try
                con.Close()
                '*******************************************************************************
                'If accessories are associated with this item, bring up accessory form
                If AddAccessory = "YES" Then
                    GlobalDivisionCode = cboDivisionID.Text
                    GlobalOrderQuantity = Val(txtQuantity.Text)
                    GlobalNominalDiameter = NominalDiameter
                    GlobalSONumber = Val(cboQuoteNumber.Text)
                    GlobalSOUnitPrice = Val(txtLinePrice.Text)
                    GlobalSOStatus = "QUOTE"
                    GlobalItemClass = ItemClass
                    GlobalNominalLength = NominalLength

                    Using NewSOAccessoriesForm As New SOAccessoriesForm
                        Dim result = NewSOAccessoriesForm.ShowDialog
                    End Using
                Else
                    'Do nothing
                End If

                'Update Datagrid
                ShowData()
                '***************************************************************************************
                'Update Header Table based on line amount
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CalculateCanadianTotals()

                    'Update quote header Table
                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET FreightCharge = @FreightCharge, TotalSalesTax = @TotalSalesTax, ProductTotal = @ProductTotal, SOTotal = @SOTotal, TotalSalesTax2 = @TotalSalesTax2, TotalSalesTax3 = @TotalSalesTax3 WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                        .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                        .Add("@TotalSalesTax", SqlDbType.VarChar).Value = GSTExtendedAmount
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        .Add("@SOTotal", SqlDbType.VarChar).Value = QuoteTotal
                        .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = PSTExtendedAmount
                        .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = HSTExtendedAmount
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    CalculateTotals()

                    'Update quote header Table
                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET FreightCharge = @FreightCharge, TotalSalesTax = @TotalSalesTax, ProductTotal = @ProductTotal, SOTotal = @SOTotal, TotalSalesTax2 = @TotalSalesTax2, TotalSalesTax3 = @TotalSalesTax3 WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                        .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                        .Add("@TotalSalesTax", SqlDbType.VarChar).Value = TotalSalesTax
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        .Add("@SOTotal", SqlDbType.VarChar).Value = QuoteTotal
                        .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = 0
                        .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = 0
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
                '*******************************************************************************
                'Call procedure to populate grid on form
                ShowData()

                Try
                    'Set focus to current cell in the datagrid
                    Me.dgvSalesOrderLines.Rows(dgvSalesOrderLines.Rows.Count - 1).Selected = True
                    Me.dgvSalesOrderLines.CurrentCell = Me.dgvSalesOrderLines.Rows(Me.dgvSalesOrderLines.Rows.Count - 1).Cells(1)
                Catch ex As Exception
                    'Skip
                End Try

                cboPartNumber.SelectedIndex = -1
                cboPartDescription.SelectedIndex = -1
                lblLongDescription.Text = ""
                txtQuantity.Clear()
                txtLinePrice.Clear()
                txtExtendedAmount.Clear()
                txtLeadDate.Clear()
                txtLineComment.Clear()
                '********************************************************************************
                'Initialize values
                TotalLineWeight = 0
                GetPieceWeight = 0
                LineTotal = 0
                cboPartNumber.SelectedIndex = -1
                cboPartNumber.Focus()
            End If
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdConvertToSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConvertToSO.Click
        'Verify text field is not empty
        If cboQuoteNumber.Text = "" Or cboCustomerID.Text = "" Then
            MsgBox("You must have a valid Quote Number / Customer to convert to a Sales Order", MsgBoxStyle.OkOnly)
        Else
            '********************************************************************************
            'Prompt before converting
            Dim button As DialogResult = MessageBox.Show("Do you wish to convert this Quote to a Sales Order?", "CONVERT QUOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                '********************************************************************************
                If cboCustomerID.Text <> "" Or cboCustomerName.Text <> "" Then
                    'Continue
                Else
                    MsgBox("You must have a valid customer ID and name.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '********************************************************************************
                'Check if Customer Exits
                Dim CheckCustomer As Integer = 0

                Dim CheckCustomerStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CheckCustomerCommand As New SqlCommand(CheckCustomerStatement, con)
                CheckCustomerCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                CheckCustomerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckCustomer = CInt(CheckCustomerCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckCustomer = 0
                End Try
                con.Close()

                If CheckCustomer = 0 Then
                    'Add customer to database if necessary
                    If chkNewCustomer.Checked = True Then
                        Try
                            'Create command to insert new record into database
                            SaveInsertIntoCustomerList()
                            chkNewCustomer.Checked = False
                        Catch ex As Exception
                            'Error Log
                        End Try
                    Else
                        'Ask if new customer should be created
                        Dim button1 As DialogResult = MessageBox.Show("Customer does not exist - do you wish to create it?", "NEW CUSTOMER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If button1 = DialogResult.Yes Then
                            Try
                                'Create command to insert new record into database
                                SaveInsertIntoCustomerList()
                                chkNewCustomer.Checked = False
                            Catch ex As Exception
                                'Error Log
                            End Try
                        ElseIf button1 = DialogResult.No Then
                            'Exit save 
                            MsgBox("Quote will not be saved.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End If
                    End If
                Else
                    'Continue
                    chkNewCustomer.Checked = False
                End If
                '********************************************************************************
                'Check to make sure Quote/Sales Order is correct
                Dim CheckDivision As String = ""

                Dim CheckDivisionStatement As String = "SELECT DivisionKey FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
                Dim CheckDivisionCommand As New SqlCommand(CheckDivisionStatement, con)
                CheckDivisionCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckDivision = CStr(CheckDivisionCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckDivision = ""
                End Try
                con.Close()

                If CheckDivision <> cboDivisionID.Text Then
                    MsgBox("There is an issue with this quote. Contact ADMIN.", MsgBoxStyle.OkOnly)

                    'Error Log
                    Dim TempQuoteNumber As Integer = 0
                    Dim strQuoteNumber As String
                    TempQuoteNumber = Val(cboQuoteNumber.Text)
                    strQuoteNumber = CStr(TempQuoteNumber)

                    ErrorDate = Today()
                    ErrorComment = "Division " + cboDivisionID.Text + " does not match SO Division - " + CheckDivision
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Quote Form - CONVERT TO SO - Invalid Division"
                    ErrorReferenceNumber = "Quote # " + strQuoteNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                Else
                    'Skip
                End If
                '********************************************************************************
                'Recalculate grid totals in case of changes
                cmd = New SqlCommand("Update SalesOrderLineTable SET ExtendedAmount = Quantity * Price WHERE SalesOrderKey = @SalesOrderKey", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '********************************************************************************
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do not update ship address
                End If
                '********************************************************************************
                'Calculate totals
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    'Calculate totals based on user entry
                    If chkADDPST.Checked = True Then
                        'Get sum of lines for product total
                        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                        SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ProductTotal = 0
                        End Try
                        con.Close()

                        PSTTaxRate = 0.07
                        GSTTaxRate = 0.05
                        HSTTaxRate = 0

                        PSTExtendedAmount = ProductTotal * PSTTaxRate
                        GSTExtendedAmount = ProductTotal * GSTTaxRate
                        HSTExtendedAmount = ProductTotal * HSTTaxRate

                        PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                        GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                        HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                        TotalSalesTax = GSTExtendedAmount
                        TotalSalesTax2 = PSTExtendedAmount
                        TotalSalesTax3 = HSTExtendedAmount

                        FreightCharge = Val(txtFreightCharge.Text)

                        QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                    ElseIf chkADDHST.Checked = True Then
                        'Get sum of lines for product total
                        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                        SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ProductTotal = 0
                        End Try
                        con.Close()

                        PSTTaxRate = 0.07
                        GSTTaxRate = 0.05
                        HSTTaxRate = Val(txtHSTRate.Text)

                        PSTExtendedAmount = 0
                        GSTExtendedAmount = 0
                        HSTExtendedAmount = ProductTotal * HSTTaxRate

                        PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                        GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                        HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                        TotalSalesTax = GSTExtendedAmount
                        TotalSalesTax2 = PSTExtendedAmount
                        TotalSalesTax3 = HSTExtendedAmount

                        FreightCharge = Val(txtFreightCharge.Text)

                        QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                    Else
                        'Get sum of lines for product total
                        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                        SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ProductTotal = 0
                        End Try
                        con.Close()

                        PSTTaxRate = 0.07
                        GSTTaxRate = 0.05
                        HSTTaxRate = 0

                        PSTExtendedAmount = 0
                        GSTExtendedAmount = ProductTotal * GSTTaxRate
                        HSTExtendedAmount = 0

                        PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                        GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                        HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                        TotalSalesTax = GSTExtendedAmount
                        TotalSalesTax2 = PSTExtendedAmount
                        TotalSalesTax3 = HSTExtendedAmount

                        FreightCharge = Val(txtFreightCharge.Text)

                        QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                    End If
                Else
                    CalculateTotals()
                End If
                '********************************************************************************
                SalesOrderDate = dtpQuoteDate.Value
                ShippingDate = dtpDeliveryDate.Value
                '********************************************************************************
                'Convert Quote to Open Sales Order
                Try
                    'Write Data to Sales Order Header Database Table
                    SaveUpdateSalesOrderHeader()
                Catch ex As Exception
                    MsgBox("There is an issue with this quote. Contact ADMIN.", MsgBoxStyle.OkOnly)

                    'Error Log
                    Dim TempQuoteNumber As Integer = 0
                    Dim strQuoteNumber As String
                    TempQuoteNumber = Val(cboQuoteNumber.Text)
                    strQuoteNumber = CStr(TempQuoteNumber)

                    ErrorDate = Today()
                    ErrorComment = "Division " + cboDivisionID.Text + " does not match SO Division - " + CheckDivision
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Quote Form - CONVERT TO SO - UPDATE COMMAND"
                    ErrorReferenceNumber = "Quote # " + strQuoteNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                End Try
                '********************************************************************************
                'Update Header to open
                cmd = New SqlCommand("Update SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '********************************************************************************
                'Update line to open
                cmd = New SqlCommand("Update SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '********************************************************************************
                'Prompt after conversion
                MsgBox("This Quote has been converted to a Sales Order", MsgBoxStyle.OkOnly)

                'Refresh data in grid
                GlobalSONumber = Val(cboQuoteNumber.Text)
                '********************************************************************************
                Me.Dispose()
                Me.Close()

                Using NewSOForm As New SOForm
                    Dim result = NewSOForm.ShowDialog()
                End Using
            ElseIf button = DialogResult.No Then
                MsgBox("This Quote cannot be converted to a Sales Order", MsgBoxStyle.OkOnly)
                cmdDelete.Focus()
            End If
        End If
    End Sub

    Private Sub ConvertToSalesOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConvertToSalesOrderToolStripMenuItem.Click
        cmdConvertToSO_Click(sender, e)
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        lblLongDescription.Text = ""

        txtQuantity.Clear()
        txtLinePrice.Clear()
        txtLeadDate.Clear()
        txtLineComment.Clear()
        txtExtendedAmount.Clear()

        lblUpdatedPrice.Visible = False
        lblQuantityAvailable.Text = ""
        lblQOH.Text = ""
        lblLastPurchaseCost.Text = ""

        cboPartNumber.Focus()
    End Sub

    Private Sub cmdGenerateNewQuote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewQuote.Click
        'Clear data on next Quote Number
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        'Save Quote Number so it can not be selected again
        Try
            'Write Data to Sales Order Header Database Table
            SaveInsertIntoSalesOrderHeader()
        Catch ex As Exception
            'Write error list
            Dim TempQuoteNumber As Integer = 0
            Dim strQuoteNumber As String
            TempQuoteNumber = Val(cboQuoteNumber.Text)
            strQuoteNumber = CStr(TempQuoteNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Quote Form - Generate New Quote Failure"
            ErrorReferenceNumber = "Quote # " + strQuoteNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            ClearData()
            ClearVariables()
            ClearDataInDatagrid()
            cboQuoteNumber.SelectedIndex = -1
            MsgBox("This next Quote # has been taken. Select a new Quote #.", MsgBoxStyle.OkOnly)
        End Try

        cboQuoteNumber.Focus()
    End Sub

    Private Sub cmdPriceSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenOrders.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewCustomerOpenOrders As New CustomerOpenOrders
            Dim result = NewCustomerOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub cmdCustomerSalesHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomerSalesHistory.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalCustomerName = cboCustomerName.Text
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalMaintenancePartDescription = cboPartDescription.Text

        Using NewViewCustomerSalesHistory As New ViewCustomerSalesHistory
            Dim result = NewViewCustomerSalesHistory.ShowDialog()
        End Using
    End Sub

    Private Sub cmdSaveLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLine.Click
        If cboQuoteNumber.Text <> "" And cboQuoteLineNumber.Text <> "" Then
            'Get Sales Tax if Customer is taxable
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                LoadTaxRate()
            Else
                'Tax determined by checked boxes
            End If

            EditLinePrice = Val(txtQuoteLinePrice.Text)
            EditLineQuantity = Val(txtQuoteLineQuantity.Text)

            EditLineTotal = EditLinePrice * EditLineQuantity
            EditLineSalesTax = EditLineTotal * TaxRate
            EditLineTotal = Math.Round(EditLineTotal, 2)

            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                EditLineSalesTax = 0
            Else
                'Do nothing - tax is correct
            End If
            '********************************************************************************
            'Write Data to Sales Order Line Database Table (Line Items)
            cmd = New SqlCommand("UPDATE SalesOrderLineTable SET ItemID = @ItemID, Description = @Description, Quantity = @Quantity, Price = @Price, SalesTax = @SalesTax, ExtendedAmount = @ExtendedAmount, LineComment = @LineComment, LeadTime = @Leadtime WHERE SalesorderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = Val(cboQuoteLineNumber.Text)
                .Add("@ItemID", SqlDbType.VarChar).Value = cboQuoteLinePart.Text
                .Add("@Description", SqlDbType.VarChar).Value = cboQuoteLineDescription.Text
                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuoteLineQuantity.Text)
                .Add("@Price", SqlDbType.VarChar).Value = Val(txtQuoteLinePrice.Text)
                .Add("@SalesTax", SqlDbType.VarChar).Value = EditLineSalesTax
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = EditLineTotal
                .Add("@LineComment", SqlDbType.VarChar).Value = txtQuoteLineComment.Text
                .Add("@LeadTime", SqlDbType.VarChar).Value = txtQuoteLineLeadTime.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************************************************
            'Reload datagrid
            ShowData()
            '********************************************************************************
            'Calculate totals
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                'Calculate totals based on user entry
                If chkADDPST.Checked = True Then
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = 0

                    PSTExtendedAmount = ProductTotal * PSTTaxRate
                    GSTExtendedAmount = ProductTotal * GSTTaxRate
                    HSTExtendedAmount = ProductTotal * HSTTaxRate

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    FreightCharge = Val(txtFreightCharge.Text)

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                ElseIf chkADDHST.Checked = True Then
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = Val(txtHSTRate.Text)

                    PSTExtendedAmount = 0
                    GSTExtendedAmount = 0
                    HSTExtendedAmount = ProductTotal * HSTTaxRate

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    FreightCharge = Val(txtFreightCharge.Text)

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                Else
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = 0

                    PSTExtendedAmount = 0
                    GSTExtendedAmount = ProductTotal * GSTTaxRate
                    HSTExtendedAmount = 0

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    FreightCharge = Val(txtFreightCharge.Text)

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                End If
            Else
                CalculateTotals()
            End If
            '********************************************************************************
            'Update header table on line changes
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET ProductTotal = @ProductTotal, FreightCharge = @FreightCharge, SOTotal = @SOTotal, TotalSalesTax = @TotalSalesTax, TotalSalesTax2 = @TotalSalesTax2, TotalSalesTax3 = @TotalSalesTax3 WHERE SalesorderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                .Add("@SOTotal", SqlDbType.VarChar).Value = QuoteTotal
                .Add("@TotalSalesTax", SqlDbType.VarChar).Value = TotalSalesTax
                .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = TotalSalesTax2
                .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = TotalSalesTax3
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Load totals after changes
            LoadTotals()
            '********************************************************************************
        Else
            MsgBox("You must have a valid Quote Number and Line Number selected.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        'Delete and re-number lines in the quote
        Dim NewLineNumber, OldLineNumber, TempLineNumber As Integer

        TempLineNumber = 1000

        If cboQuoteNumber.Text <> "" And cboQuoteLineNumber.Text <> "" Then
            'Delete Line
            cmd = New SqlCommand("DELETE FROM SalesOrderLineTable WHERE SalesorderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = Val(cboQuoteLineNumber.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************************************************
            'Reload updated Datagrid
            ShowData()
            '********************************************************************************
            'Reorder Lines
            'Retrieve line data from SO Table
            For Each row As DataGridViewRow In dgvSalesOrderLines.Rows
                Try
                    OldLineNumber = row.Cells("SalesOrderLineKeyColumn").Value
                Catch ex As Exception
                    OldLineNumber = 0
                End Try

                'After getting line number, update it 
                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET SalesOrderLineKey = @SalesOrderLineKeyTemp WHERE SalesorderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = OldLineNumber
                    .Add("@SalesOrderLineKeyTemp", SqlDbType.VarChar).Value = TempLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                TempLineNumber = TempLineNumber + 1
            Next

            'Reload updated datagrid
            ShowData()
            TempLineNumber = 0
            NewLineNumber = 1

            For Each row As DataGridViewRow In dgvSalesOrderLines.Rows
                Try
                    TempLineNumber = row.Cells("SalesOrderLineKeyColumn").Value
                Catch ex As Exception
                    TempLineNumber = 0
                End Try

                'After getting line number, update it 
                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET SalesOrderLineKey = @SalesOrderLineKey WHERE SalesorderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKeyTemp", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = NewLineNumber
                    .Add("@SalesOrderLineKeyTemp", SqlDbType.VarChar).Value = TempLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                NewLineNumber = NewLineNumber + 1
            Next
            '********************************************************************************
            'Reload updates into datagrid
            ShowData()
            '********************************************************************************
            'Calculate totals
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                'Calculate totals based on user entry
                If chkADDPST.Checked = True Then
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = 0

                    PSTExtendedAmount = ProductTotal * PSTTaxRate
                    GSTExtendedAmount = ProductTotal * GSTTaxRate
                    HSTExtendedAmount = ProductTotal * HSTTaxRate

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    FreightCharge = Val(txtFreightCharge.Text)

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                ElseIf chkADDHST.Checked = True Then
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = Val(txtHSTRate.Text)

                    PSTExtendedAmount = 0
                    GSTExtendedAmount = 0
                    HSTExtendedAmount = ProductTotal * HSTTaxRate

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    FreightCharge = Val(txtFreightCharge.Text)

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                Else
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = 0

                    PSTExtendedAmount = 0
                    GSTExtendedAmount = ProductTotal * GSTTaxRate
                    HSTExtendedAmount = 0

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    FreightCharge = Val(txtFreightCharge.Text)

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                End If
            Else
                CalculateTotals()
            End If
            '********************************************************************************
            'Update header table on line changes
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET ProductTotal = @ProductTotal, FreightCharge = @FreightCharge, SOTotal = @SOTotal, TotalSalesTax = @TotalSalesTax, TotalSalesTax2 = @TotalSalesTax2, TotalSalesTax3 = @TotalSalesTax3 WHERE SalesorderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
                .Add("@SOTotal", SqlDbType.VarChar).Value = QuoteTotal
                .Add("@TotalSalesTax", SqlDbType.VarChar).Value = TotalSalesTax
                .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = TotalSalesTax2
                .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = TotalSalesTax3
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Load totals after changes
            LoadTotals()
            '********************************************************************************
        Else
            MsgBox("You must have a valid Quote Number and Line Number selected.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdRemoveSalesTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveSalesTax.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to remove Sales Tax from this quote?", "REMOVE TAX", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Dim SumQuoteLines, SumFreight, SumQuoteTotal As Double

            Try
                'Load Product Total and Freight to re-calc Quote Total
                Dim SUMStatement1 As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                Dim SUMCommand1 As New SqlCommand(SUMStatement1, con)
                SUMCommand1.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                SUMCommand1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim SELStatement3 As String = "SELECT FreightCharge FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                Dim SELCommand3 As New SqlCommand(SELStatement3, con)
                SELCommand3.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                SELCommand3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumQuoteLines = CDbl(SUMCommand1.ExecuteScalar)
                Catch ex As Exception
                    SumQuoteLines = 0
                End Try
                Try
                    SumFreight = CDbl(SELCommand3.ExecuteScalar)
                Catch ex As Exception
                    SumFreight = 0
                End Try
                con.Close()

                SumQuoteTotal = SumQuoteLines + SumFreight
                '************************************************************************************************
                'Write Data to Sales Order Header Database Table (One Time)
                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET TotalSalesTax = @TotalSalesTax, TotalSalesTax2 = @TotalSalesTax2, TotalSalesTax3 = @TotalSalesTax3, TaxRate1 = @TaxRate1, TaxRate2 = @TaxRate2, TaxRate3 = @TaxRate3, SOTotal = @SOTotal WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@TotalSalesTax", SqlDbType.VarChar).Value = 0
                    .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = 0
                    .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = 0
                    .Add("@TaxRate1", SqlDbType.VarChar).Value = 0
                    .Add("@TaxRate2", SqlDbType.VarChar).Value = 0
                    .Add("@TaxRate3", SqlDbType.VarChar).Value = 0
                    .Add("@SOTotal", SqlDbType.VarChar).Value = SumQuoteTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '************************************************************************************************
                'Write Data to Sales Order Header Database Table (One Time)
                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET SalesTax = @SalesTax WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '************************************************************************************************
                ShowData()
                lblQuoteTotal.Text = FormatCurrency(SumQuoteTotal, 2)
                lblSalesTax.Text = FormatCurrency(0, 2)
                chkTaxable.Checked = False
                txtTaxRate.Visible = False

                LoadTotals()

                MsgBox("Sales Tax has been removed.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                MsgBox("There is an error - sales tax not removed.", MsgBoxStyle.OkOnly)
            End Try
        ElseIf button = DialogResult.No Then
            cmdRemoveSalesTax.Focus()
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboQuoteNumber.Text = "" Or cboCustomerID.Text = "" Then
            MsgBox("You must have a valid Quote Number / Customer selected to save this quote", MsgBoxStyle.OkOnly)
        Else
            'Prompt before Saving
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Quote?", "SAVE QUOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                '********************************************************************************
                If cboCustomerID.Text <> "" Or cboCustomerName.Text <> "" Then
                    'Continue
                Else
                    MsgBox("You must have a valid customer ID and name.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '********************************************************************************
                'Check if Customer Exits
                Dim CheckCustomer As Integer = 0

                Dim CheckCustomerStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CheckCustomerCommand As New SqlCommand(CheckCustomerStatement, con)
                CheckCustomerCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                CheckCustomerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckCustomer = CInt(CheckCustomerCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckCustomer = 0
                End Try
                con.Close()

                If CheckCustomer = 0 Then
                    'Add customer to database if necessary
                    If chkNewCustomer.Checked = True Then
                        Try
                            'Create command to insert new record into database
                            SaveInsertIntoCustomerList()
                            chkNewCustomer.Checked = False
                        Catch ex As Exception
                            'Error Log
                        End Try
                    Else
                        'Ask if new customer should be created
                        Dim button1 As DialogResult = MessageBox.Show("Customer does not exist - do you wish to create it?", "NEW CUSTOMER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If button1 = DialogResult.Yes Then
                            Try
                                'Create command to insert new record into database
                                SaveInsertIntoCustomerList()
                                chkNewCustomer.Checked = False
                            Catch ex As Exception
                                'Error Log
                            End Try
                        ElseIf button1 = DialogResult.No Then
                            'Exit save 
                            MsgBox("Quote will not be saved.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End If
                    End If
                Else
                    'Continue
                    chkNewCustomer.Checked = False
                End If
                '********************************************************************************
                'Check to make sure Quote/Sales Order is correct
                Dim CheckDivision As String = ""

                Dim CheckDivisionStatement As String = "SELECT DivisionKey FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
                Dim CheckDivisionCommand As New SqlCommand(CheckDivisionStatement, con)
                CheckDivisionCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckDivision = CStr(CheckDivisionCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckDivision = ""
                End Try
                con.Close()

                If CheckDivision <> cboDivisionID.Text Then
                    MsgBox("There is an issue with this quote. Contact ADMIN.", MsgBoxStyle.OkOnly)

                    'Error Log
                    Dim TempQuoteNumber As Integer = 0
                    Dim strQuoteNumber As String
                    TempQuoteNumber = Val(cboQuoteNumber.Text)
                    strQuoteNumber = CStr(TempQuoteNumber)

                    ErrorDate = Today()
                    ErrorComment = "Division " + cboDivisionID.Text + " does not match SO Division - " + CheckDivision
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Quote Form - SAVE Button - Invalid Division"
                    ErrorReferenceNumber = "Quote # " + strQuoteNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                Else
                    'Skip
                End If
                '********************************************************************************
                'Recalculate grid totals in case of changes
                cmd = New SqlCommand("Update SalesOrderLineTable SET ExtendedAmount = Quantity * Price WHERE SalesOrderKey = @SalesOrderKey", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '********************************************************************************
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do not update ship address
                End If
                '********************************************************************************
                'Calculate totals
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    'Calculate totals based on user entry
                    If chkADDPST.Checked = True Then
                        'Get sum of lines for product total
                        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                        SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ProductTotal = 0
                        End Try
                        con.Close()

                        PSTTaxRate = 0.07
                        GSTTaxRate = 0.05
                        HSTTaxRate = 0

                        PSTExtendedAmount = ProductTotal * PSTTaxRate
                        GSTExtendedAmount = ProductTotal * GSTTaxRate
                        HSTExtendedAmount = ProductTotal * HSTTaxRate

                        PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                        GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                        HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                        TotalSalesTax = GSTExtendedAmount
                        TotalSalesTax2 = PSTExtendedAmount
                        TotalSalesTax3 = HSTExtendedAmount

                        FreightCharge = Val(txtFreightCharge.Text)

                        QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                    ElseIf chkADDHST.Checked = True Then
                        'Get sum of lines for product total
                        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                        SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ProductTotal = 0
                        End Try
                        con.Close()

                        PSTTaxRate = 0.07
                        GSTTaxRate = 0.05
                        HSTTaxRate = Val(txtHSTRate.Text)

                        PSTExtendedAmount = 0
                        GSTExtendedAmount = 0
                        HSTExtendedAmount = ProductTotal * HSTTaxRate

                        PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                        GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                        HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                        TotalSalesTax = GSTExtendedAmount
                        TotalSalesTax2 = PSTExtendedAmount
                        TotalSalesTax3 = HSTExtendedAmount

                        FreightCharge = Val(txtFreightCharge.Text)

                        QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                    Else
                        'Get sum of lines for product total
                        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                        SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ProductTotal = 0
                        End Try
                        con.Close()

                        PSTTaxRate = 0.07
                        GSTTaxRate = 0.05
                        HSTTaxRate = 0

                        PSTExtendedAmount = 0
                        GSTExtendedAmount = ProductTotal * GSTTaxRate
                        HSTExtendedAmount = 0

                        PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                        GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                        HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                        TotalSalesTax = GSTExtendedAmount
                        TotalSalesTax2 = PSTExtendedAmount
                        TotalSalesTax3 = HSTExtendedAmount

                        FreightCharge = Val(txtFreightCharge.Text)

                        QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                    End If

                    AddTaxRate1 = GSTTaxRate
                    AddTaxRate2 = PSTTaxRate
                    AddTaxRate3 = HSTTaxRate
                Else
                    CalculateTotals()
                End If
                '********************************************************************************
                SalesOrderDate = dtpQuoteDate.Value
                ShippingDate = dtpDeliveryDate.Value
                '********************************************************************************
                Try
                    'Write Data to Sales Order Header Database Table
                    SaveUpdateSalesOrderHeader()
                Catch ex As Exception
                    MsgBox("There is an issue with this quote. Contact ADMIN.", MsgBoxStyle.OkOnly)

                    'Error Log
                    Dim TempQuoteNumber As Integer = 0
                    Dim strQuoteNumber As String
                    TempQuoteNumber = Val(cboQuoteNumber.Text)
                    strQuoteNumber = CStr(TempQuoteNumber)

                    ErrorDate = Today()
                    ErrorComment = "Failure updating quote header table (L5184)"
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Quote Form - SAVE Button - UPDATE HEADER"
                    ErrorReferenceNumber = "Quote # " + strQuoteNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                End Try
                '********************************************************************************
                'Load totals
                LoadTotals()

                'Prompt after Save
                MsgBox("This data has been saved.", MsgBoxStyle.OkOnly)
            ElseIf button = DialogResult.No Then
                cmdSave.Focus()
            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboQuoteNumber.Text = "" Then
            MsgBox("You must have a valid Quote Number selected to print this quote", MsgBoxStyle.OkOnly)
        Else
            '********************************************************************************
            If cboCustomerID.Text <> "" Or cboCustomerName.Text <> "" Then
                'Continue
            Else
                MsgBox("You must have a valid customer ID and name.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '********************************************************************************
            'Check if Customer Exits
            Dim CheckCustomer As Integer = 0

            Dim CheckCustomerStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CheckCustomerCommand As New SqlCommand(CheckCustomerStatement, con)
            CheckCustomerCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CheckCustomerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckCustomer = CInt(CheckCustomerCommand.ExecuteScalar)
            Catch ex As Exception
                CheckCustomer = 0
            End Try
            con.Close()

            If CheckCustomer = 0 Then
                'Add customer to database if necessary
                If chkNewCustomer.Checked = True Then
                    Try
                        'Create command to insert new record into database
                        SaveInsertIntoCustomerList()
                        chkNewCustomer.Checked = False
                    Catch ex As Exception
                        'Error Log
                    End Try
                Else
                    'Ask if new customer should be created
                    Dim button1 As DialogResult = MessageBox.Show("Customer does not exist - do you wish to create it?", "NEW CUSTOMER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button1 = DialogResult.Yes Then
                        Try
                            'Create command to insert new record into database
                            SaveInsertIntoCustomerList()
                            chkNewCustomer.Checked = False
                        Catch ex As Exception
                            'Error Log
                        End Try
                    ElseIf button1 = DialogResult.No Then
                        'Exit save 
                        MsgBox("Quote will not be saved.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                End If
            Else
                'Continue
                chkNewCustomer.Checked = False
            End If
            '********************************************************************************
            'Check to make sure Quote/Sales Order is correct
            Dim CheckDivision As String = ""

            Dim CheckDivisionStatement As String = "SELECT DivisionKey FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim CheckDivisionCommand As New SqlCommand(CheckDivisionStatement, con)
            CheckDivisionCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckDivision = CStr(CheckDivisionCommand.ExecuteScalar)
            Catch ex As Exception
                CheckDivision = ""
            End Try
            con.Close()

            If CheckDivision <> cboDivisionID.Text Then
                MsgBox("There is an issue with this quote. Contact ADMIN.", MsgBoxStyle.OkOnly)

                'Error Log
                Dim TempQuoteNumber As Integer = 0
                Dim strQuoteNumber As String
                TempQuoteNumber = Val(cboQuoteNumber.Text)
                strQuoteNumber = CStr(TempQuoteNumber)

                ErrorDate = Today()
                ErrorComment = "Division " + cboDivisionID.Text + " does not match SO Division - " + CheckDivision
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Quote Form - PRINT BUTTON - Invalid Division"
                ErrorReferenceNumber = "Quote # " + strQuoteNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                Exit Sub
            Else
                'Skip
            End If
            '********************************************************************************
            'Recalculate grid totals in case of changes
            cmd = New SqlCommand("Update SalesOrderLineTable SET ExtendedAmount = Quantity * Price WHERE SalesOrderKey = @SalesOrderKey", con)
            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************************************************
            'Calculate totals
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                'Calculate totals based on user entry
                If chkADDPST.Checked = True Then
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = 0

                    PSTExtendedAmount = ProductTotal * PSTTaxRate
                    GSTExtendedAmount = ProductTotal * GSTTaxRate
                    HSTExtendedAmount = ProductTotal * HSTTaxRate

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    FreightCharge = Val(txtFreightCharge.Text)

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                ElseIf chkADDHST.Checked = True Then
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = Val(txtHSTRate.Text)

                    PSTExtendedAmount = 0
                    GSTExtendedAmount = 0
                    HSTExtendedAmount = ProductTotal * HSTTaxRate

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    FreightCharge = Val(txtFreightCharge.Text)

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                Else
                    'Get sum of lines for product total
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                    SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProductTotal = 0
                    End Try
                    con.Close()

                    PSTTaxRate = 0.07
                    GSTTaxRate = 0.05
                    HSTTaxRate = 0

                    PSTExtendedAmount = 0
                    GSTExtendedAmount = ProductTotal * GSTTaxRate
                    HSTExtendedAmount = 0

                    PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                    GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                    HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                    TotalSalesTax = GSTExtendedAmount
                    TotalSalesTax2 = PSTExtendedAmount
                    TotalSalesTax3 = HSTExtendedAmount

                    FreightCharge = Val(txtFreightCharge.Text)

                    QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                End If
            Else
                CalculateTotals()
            End If
            '********************************************************************************
            If cboShipToID.Text <> "" Then
                Try
                    SaveInsertAdditionalShipTo()
                Catch ex As Exception
                    SaveUpdateAdditionalShipTo()
                End Try
            Else
                'Do not update ship address
            End If
            '********************************************************************************
            SalesOrderDate = dtpQuoteDate.Value
            ShippingDate = dtpDeliveryDate.Value
            '********************************************************************************
            Try
                'Write Data to Sales Order Header Database Table
                SaveUpdateSalesOrderHeader()
            Catch ex As Exception
                MsgBox("There is an issue with this quote. Contact ADMIN.", MsgBoxStyle.OkOnly)

                'Error Log
                Dim TempQuoteNumber As Integer = 0
                Dim strQuoteNumber As String
                TempQuoteNumber = Val(cboQuoteNumber.Text)
                strQuoteNumber = CStr(TempQuoteNumber)

                ErrorDate = Today()
                ErrorComment = "Failure updating quote header table (L5448)"
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Quote Form - PRINT Button - UPDATE HEADER"
                ErrorReferenceNumber = "Quote # " + strQuoteNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                Exit Sub
            End Try
            '********************************************************************************
            LoadTotals()
            '********************************************************************************
            GlobalSONumber = Val(cboQuoteNumber.Text)
            GlobalDivisionCode = cboDivisionID.Text

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
                Using NewPrintQuoteRemote As New PrintQuoteRemote
                    Dim result = NewPrintQuoteRemote.ShowDialog()
                End Using
            Else
                Using NewPrintQuote As New PrintQuote
                    Dim result = NewPrintQuote.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'Verify text field is not empty
        If cboQuoteNumber.Text = "" Then
            MsgBox("You must have a valid Quote Number to delete", MsgBoxStyle.OkOnly)
        Else
            'Prompt before deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Quote?", "DELETE QUOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then

                'Create command to delete data from text boxes
                cmd = New SqlCommand("DELETE FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey AND SOStatus = @SOStatus", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Prompt after deletion
                MsgBox("This Quote has been deleted", MsgBoxStyle.OkOnly)

                'Clear Text boxes and set defaults on delete
                cboQuoteNumber.Text = ""
                LoadQuoteNumber()
                ClearVariables()
                ClearData()

                'Refresh Data in grid
                ShowData()
                cboQuoteNumber.Focus()

            ElseIf button = DialogResult.No Then
                MsgBox("This Quote cannot be deleted", MsgBoxStyle.OkOnly)
                cmdDelete.Focus()
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If cboQuoteNumber.Text = "" Then
            GlobalSONumber = 0
            ClearVariables()
            ClearData()
            Me.Dispose()
            Me.Close()
        Else
            'Prompt before Exiting
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Quote?", "SAVE QUOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                '********************************************************************************
                If cboCustomerID.Text <> "" Or cboCustomerName.Text <> "" Then
                    'Continue
                Else
                    MsgBox("You must have a valid customer ID and name.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '********************************************************************************
                'Check if Customer Exits
                Dim CheckCustomer As Integer = 0

                Dim CheckCustomerStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CheckCustomerCommand As New SqlCommand(CheckCustomerStatement, con)
                CheckCustomerCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                CheckCustomerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckCustomer = CInt(CheckCustomerCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckCustomer = 0
                End Try
                con.Close()

                If CheckCustomer = 0 Then
                    'Add customer to database if necessary
                    If chkNewCustomer.Checked = True Then
                        Try
                            'Create command to insert new record into database
                            SaveInsertIntoCustomerList()
                            chkNewCustomer.Checked = False
                        Catch ex As Exception
                            'Error Log
                        End Try
                    Else
                        'Ask if new customer should be created
                        Dim button1 As DialogResult = MessageBox.Show("Customer does not exist - do you wish to create it?", "NEW CUSTOMER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If button1 = DialogResult.Yes Then
                            Try
                                'Create command to insert new record into database
                                SaveInsertIntoCustomerList()
                                chkNewCustomer.Checked = False
                            Catch ex As Exception
                                'Error Log
                            End Try
                        ElseIf button1 = DialogResult.No Then
                            'Exit save 
                            MsgBox("Quote will not be saved.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End If
                    End If
                Else
                    'Continue
                End If
                '********************************************************************************
                'Check to make sure Quote/Sales Order is correct
                Dim CheckDivision As String = ""

                Dim CheckDivisionStatement As String = "SELECT DivisionKey FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
                Dim CheckDivisionCommand As New SqlCommand(CheckDivisionStatement, con)
                CheckDivisionCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckDivision = CStr(CheckDivisionCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckDivision = ""
                End Try
                con.Close()

                If CheckDivision <> cboDivisionID.Text Then
                    MsgBox("There is an issue with this quote. Contact ADMIN.", MsgBoxStyle.OkOnly)

                    'Error Log
                    Dim TempQuoteNumber As Integer = 0
                    Dim strQuoteNumber As String
                    TempQuoteNumber = Val(cboQuoteNumber.Text)
                    strQuoteNumber = CStr(TempQuoteNumber)

                    ErrorDate = Today()
                    ErrorComment = "Division " + cboDivisionID.Text + " does not match SO Division - " + CheckDivision
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Quote Form - EXIT BUTTON - Invalid Division"
                    ErrorReferenceNumber = "Quote # " + strQuoteNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                Else
                    'Skip
                End If
                '********************************************************************************
                'Calculate totals
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    'Calculate totals based on user entry
                    If chkADDPST.Checked = True Then
                        'Get sum of lines for product total
                        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                        SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ProductTotal = 0
                        End Try
                        con.Close()

                        FreightCharge = Val(txtFreightCharge.Text)

                        PSTTaxRate = 0.07
                        GSTTaxRate = 0.05
                        HSTTaxRate = 0

                        PSTExtendedAmount = (ProductTotal + FreightCharge) * PSTTaxRate
                        GSTExtendedAmount = (ProductTotal + FreightCharge) * GSTTaxRate
                        HSTExtendedAmount = (ProductTotal + FreightCharge) * HSTTaxRate

                        PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                        GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                        HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                        TotalSalesTax = GSTExtendedAmount
                        TotalSalesTax2 = PSTExtendedAmount
                        TotalSalesTax3 = HSTExtendedAmount

                        QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                    ElseIf chkADDHST.Checked = True Then
                        'Get sum of lines for product total
                        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                        SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ProductTotal = 0
                        End Try
                        con.Close()

                        PSTTaxRate = 0.07
                        GSTTaxRate = 0.05
                        HSTTaxRate = Val(txtHSTRate.Text)

                        FreightCharge = Val(txtFreightCharge.Text)

                        PSTExtendedAmount = 0
                        GSTExtendedAmount = 0
                        HSTExtendedAmount = (ProductTotal + FreightCharge) * HSTTaxRate

                        PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                        GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                        HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                        TotalSalesTax = GSTExtendedAmount
                        TotalSalesTax2 = PSTExtendedAmount
                        TotalSalesTax3 = HSTExtendedAmount

                        QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                    Else
                        'Get sum of lines for product total
                        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
                        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                        SUMExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
                        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ProductTotal = 0
                        End Try
                        con.Close()

                        PSTTaxRate = 0.07
                        GSTTaxRate = 0.05
                        HSTTaxRate = 0

                        FreightCharge = Val(txtFreightCharge.Text)

                        PSTExtendedAmount = 0
                        GSTExtendedAmount = (ProductTotal + FreightCharge) * GSTTaxRate
                        HSTExtendedAmount = 0

                        PSTExtendedAmount = Math.Round(PSTExtendedAmount, 2)
                        GSTExtendedAmount = Math.Round(GSTExtendedAmount, 2)
                        HSTExtendedAmount = Math.Round(HSTExtendedAmount, 2)

                        TotalSalesTax = GSTExtendedAmount
                        TotalSalesTax2 = PSTExtendedAmount
                        TotalSalesTax3 = HSTExtendedAmount

                        QuoteTotal = FreightCharge + PSTExtendedAmount + GSTExtendedAmount + HSTExtendedAmount + ProductTotal
                    End If
                Else
                    CalculateTotals()
                End If
                '********************************************************************************
                Try
                    'Write Data to Sales Order Header Database Table
                    SaveUpdateSalesOrderHeader()
                Catch ex As Exception
                    MsgBox("There is an issue with this quote. Contact ADMIN.", MsgBoxStyle.OkOnly)

                    'Error Log
                    Dim TempQuoteNumber As Integer = 0
                    Dim strQuoteNumber As String
                    TempQuoteNumber = Val(cboQuoteNumber.Text)
                    strQuoteNumber = CStr(TempQuoteNumber)

                    ErrorDate = Today()
                    ErrorComment = "Failure updating quote header table (L5759)"
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Quote Form - EXIT Button - UPDATE HEADER"
                    ErrorReferenceNumber = "Quote # " + strQuoteNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    Exit Sub
                End Try

                GlobalSONumber = 0
                ClearVariables()
                ClearData()
                Me.Dispose()
                Me.Close()
            ElseIf button = DialogResult.No Then
                GlobalSONumber = 0
                ClearVariables()
                ClearData()
                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    'Menu Strip events

    Private Sub ClearAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearAllToolStripMenuItem.Click
        ClearVariables()
        ClearData()
        ShowData()
    End Sub

    Private Sub ClearQuoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearQuoteToolStripMenuItem.Click
        ClearVariables()
        ClearData()
        ShowData()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem2.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    'Save/Update Operations

    Public Sub SaveInsertIntoCustomerList()
        'Check for Canadian Customers
        Dim CustomerClass As String = ""
        Dim BankAccount As String = ""

        If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
            CustomerClass = "CANADIAN"
            BankAccount = "Canadian Checking"
        ElseIf cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
            CustomerClass = "STANDARD"
            BankAccount = "Checking"
        Else
            CustomerClass = "STANDARD"
            BankAccount = "Cash Receipts"
        End If

        'Create command to insert new record into database
        cmd = New SqlCommand("Insert Into CustomerList (CustomerID, CustomerName, CustomerDate, DivisionID, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry, Comments, PaymentTerms, CreditLimit, SalesTaxRate, PreferredShipper, OldCustomerNumber, CustomerClass, SalesTerritory, ShippingDetails, OnHoldStatus, APPhoneNumber, APFAXNumber, APEmailAddress, InvoiceEmail, APContactName, SalesTaxRate2, SalesTaxRate3, SalesTaxID, AccountingHold, PricingLevel, BillingType, ShippingAccount, BankAccount)Values(@CustomerID, @CustomerName, @CustomerDate, @DivisionID, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @BillToAddress1, @BillToAddress2, @BillToCity, @BillToState, @BillToZip, @BillToCountry, @Comments, @PaymentTerms, @CreditLimit, @SalesTaxRate, @PreferredShipper, @OldCustomerNumber, @CustomerClass, @SalesTerritory, @ShippingDetails, @OnHoldStatus, @APPhoneNumber, @APFAXNumber, @APEmailAddress, @InvoiceEmail, @APContactName, @SalesTaxRate2, @SalesTaxRate3, @SalesTaxID, @AccountingHold, @PricingLevel, @BillingType, @ShippingAccount, @BankAccount)", con)

        With cmd.Parameters
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
            .Add("@CustomerDate", SqlDbType.VarChar).Value = SalesOrderDate
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtShipToAddress1.Text
            .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtShipToAddress2.Text
            .Add("@ShipToCity", SqlDbType.VarChar).Value = txtShipToCity.Text
            .Add("@ShipToState", SqlDbType.VarChar).Value = txtShipToState.Text
            .Add("@ShipToZip", SqlDbType.VarChar).Value = txtShipToZip.Text
            .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtShipToCountry.Text
            .Add("@BillToAddress1", SqlDbType.VarChar).Value = txtShipToAddress1.Text
            .Add("@BillToAddress2", SqlDbType.VarChar).Value = txtShipToAddress2.Text
            .Add("@BillToCity", SqlDbType.VarChar).Value = txtShipToCity.Text
            .Add("@BillToState", SqlDbType.VarChar).Value = txtShipToState.Text
            .Add("@BillToZip", SqlDbType.VarChar).Value = txtShipToZip.Text
            .Add("@BillToCountry", SqlDbType.VarChar).Value = txtShipToCountry.Text
            .Add("@Comments", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
            .Add("@CreditLimit", SqlDbType.VarChar).Value = 0
            .Add("@SalesTaxRate", SqlDbType.VarChar).Value = 0
            .Add("@SalesTaxRate2", SqlDbType.VarChar).Value = 0
            .Add("@SalesTaxRate3", SqlDbType.VarChar).Value = 0
            .Add("@PreferredShipper", SqlDbType.VarChar).Value = "Delivery"
            .Add("@OldCustomerNumber", SqlDbType.VarChar).Value = ""
            .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
            .Add("@SalesTerritory", SqlDbType.VarChar).Value = ""
            .Add("@ShippingDetails", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
            .Add("@OnHoldStatus", SqlDbType.VarChar).Value = "YES"
            .Add("@APPhoneNumber", SqlDbType.VarChar).Value = ""
            .Add("@APFAXNumber", SqlDbType.VarChar).Value = ""
            .Add("@APEmailAddress", SqlDbType.VarChar).Value = ""
            .Add("@InvoiceEmail", SqlDbType.VarChar).Value = ""
            .Add("@APContactName", SqlDbType.VarChar).Value = txtContact.Text
            .Add("@SalesTaxID", SqlDbType.VarChar).Value = ""
            .Add("@AccountingHold", SqlDbType.VarChar).Value = "NO"
            .Add("@PricingLevel", SqlDbType.VarChar).Value = ""
            .Add("@BillingType", SqlDbType.VarChar).Value = "STANDARD"
            .Add("@ShippingAccount", SqlDbType.VarChar).Value = ""
            .Add("@BankAccount", SqlDbType.VarChar).Value = BankAccount
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub SaveInsertIntoSalesOrderHeader()
        Dim FOB As String = ""

        If cboDivisionID.Text = "TWD" Then
            FOB = "Medina"
        Else
            FOB = "Standard"
        End If

        If txtShipToName.Text = "" Or txtShipToName.Text = "DEFAULT SHIP TO" Then
            ShipToName = cboCustomerName.Text
        Else
            ShipToName = txtShipToName.Text
        End If
        '********************************************************************************
        SalesOrderDate = dtpQuoteDate.Value
        ShippingDate = dtpDeliveryDate.Value
        '********************************************************************************
        Dim MAXStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderHeaderTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionNumber = 65000000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        cboQuoteNumber.Text = NextTransactionNumber
        '*********************************************************************************
        'Write Data to Sales Order Header Database Table
        cmd = New SqlCommand("Insert Into SalesOrderHeaderTable(SalesOrderKey, SalesOrderDate, CustomerID, CustomerPO, CustomerPOType, SalesPerson, DivisionKey, ShipVia, ShippingDate, HeaderComment, PRONumber, FreightCharge, TotalSalesTax, TotalSalesTax2, TotalSalesTax3, TaxOnFreight, ProductTotal, SOTotal, TotalEstCOS, TaxRate1, TaxRate2, TaxRate3, SOStatus, AdditionalShipTo, QuoteNumber, QuotedFreight, ShippingWeight, SpecialInstructions, DropShipPONumber, FOB, CustomerClass, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ShipEmail, ShippingAccount, SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3, Locked, SalesOrderType, WorkOrderNumber)Values(@SalesOrderKey, @SalesOrderDate, @CustomerID, @CustomerPO, @CustomerPOType, @SalesPerson, @DivisionKey, @ShipVia, @ShippingDate, @HeaderComment, @PRONumber, @FreightCharge, @TotalSalesTax, @TotalSalesTax2, @TotalSalesTax3, @TaxOnFreight, @ProductTotal, @SOTotal, @TotalEstCOS, @TaxRate1, @TaxRate2, @TaxRate3, @SOStatus, @AdditionalShipTo, @QuoteNumber, @QuotedFreight, @ShippingWeight, @SpecialInstructions, @DropShipPONumber, @FOB, @CustomerClass, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @ShipEmail, @ShippingAccount, @SpecialLabelLine1, @SpecialLabelLine2, @SpecialLabelLine3, @Locked, @SalesOrderType, @WorkOrderNumber)", con)

        With cmd.Parameters
            .Add("@SalesOrderKey", SqlDbType.VarChar).Value = NextTransactionNumber
            .Add("@SalesOrderDate", SqlDbType.VarChar).Value = SalesOrderDate
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
            .Add("@CustomerPOType", SqlDbType.VarChar).Value = txtCustomerPO.Text
            .Add("@SalesPerson", SqlDbType.VarChar).Value = cboSalesperson.Text
            .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@ShippingDate", SqlDbType.VarChar).Value = ShippingDate
            .Add("@HeaderComment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@PRONumber", SqlDbType.VarChar).Value = ""
            .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
            .Add("@TotalSalesTax", SqlDbType.VarChar).Value = TotalSalesTax
            .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = TotalSalesTax2
            .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = TotalSalesTax3
            .Add("@TaxOnFreight", SqlDbType.VarChar).Value = 0
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@SOTotal", SqlDbType.VarChar).Value = QuoteTotal
            .Add("@TotalEstCOS", SqlDbType.VarChar).Value = 0
            .Add("@TaxRate1", SqlDbType.VarChar).Value = 0
            .Add("@TaxRate2", SqlDbType.VarChar).Value = 0
            .Add("@TaxRate3", SqlDbType.VarChar).Value = 0
            .Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
            .Add("@QuoteNumber", SqlDbType.VarChar).Value = ""
            .Add("@QuotedFreight", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
            .Add("@ShippingWeight", SqlDbType.VarChar).Value = TotalOrderWeight
            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
            .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
            .Add("@FOB", SqlDbType.VarChar).Value = FOB
            .Add("@CustomerClass", SqlDbType.VarChar).Value = "STANDARD"
            .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
            .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
            .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtShipToAddress1.Text
            .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtShipToAddress2.Text
            .Add("@ShipToCity", SqlDbType.VarChar).Value = txtShipToCity.Text
            .Add("@ShipToState", SqlDbType.VarChar).Value = txtShipToState.Text
            .Add("@ShipToZip", SqlDbType.VarChar).Value = txtShipToZip.Text
            .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtShipToCountry.Text
            .Add("@ShipEmail", SqlDbType.VarChar).Value = ""
            .Add("@ShippingAccount", SqlDbType.VarChar).Value = ""
            .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = ""
            .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = ""
            .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = ""
            .Add("@Locked", SqlDbType.VarChar).Value = ""
            .Add("@SalesOrderType", SqlDbType.VarChar).Value = "Q"
            .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = 0
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub SaveUpdateSalesOrderHeader()
        Dim FOB As String = ""

        If cboDivisionID.Text = "TWD" Then
            FOB = "Medina"
        Else
            FOB = "STANDARD"
        End If

        If txtShipToName.Text = "" Or txtShipToName.Text = "DEFAULT SHIP TO" Then
            ShipToName = cboCustomerName.Text
        Else
            ShipToName = txtShipToName.Text
        End If
        '********************************************************************************
        SalesOrderDate = dtpQuoteDate.Value
        ShippingDate = dtpDeliveryDate.Value
        '********************************************************************************
        'Write Data to Sales Order Header Database Table (One Time)
        cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SalesOrderDate = @SalesOrderDate, CustomerID = @CustomerID, CustomerPO = @CustomerPO, CustomerPOType = @CustomerPOType, SalesPerson = @SalesPerson, ShipVia = @ShipVia, ShippingDate = @ShippingDate, HeaderComment = @HeaderComment, PRONumber = @PRONumber, FreightCharge = @FreightCharge, TotalSalesTax = @TotalSalesTax, TotalSalesTax2 = @TotalSalesTax2, TotalSalesTax3 = @TotalSalesTax3, TaxOnFreight = @TaxOnFreight, @ProductTotal = @ProductTotal, SOTotal = @SOTotal, TotalEstCOS = @TotalEstCOS, TaxRate1 = @TaxRate1, TaxRate2 = @TaxRate2, TaxRate3 = @TaxRate3, SOStatus = @SOStatus, AdditionalShipTo = @AdditionalShipTo, QuoteNumber = @QuoteNumber, QuotedFreight = @QuotedFreight, ShippingWeight = @ShippingWeight, SpecialInstructions = @SpecialInstructions, DropShipPONumber = @DropShipPONumber, FOB = @FOB, CustomerClass = @CustomerClass, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName, ShipToAddress1 = @ShipToAddress1, ShipToAddress2 = @ShipToAddress2, ShipToCity = @ShipToCity, ShipToState = @ShipToState, ShipToZip = @ShipToZip, ShipToCountry = @ShipToCountry, ShipEmail = @ShipEmail, ShippingAccount = @ShippingAccount, SpecialLabelLine1 = @SpecialLabelLine1, SpecialLabelLine2 = @SpecialLabelLine2, SpecialLabelLine3 = @SpecialLabelLine3, Locked = @Locked, SalesOrderType = @SalesOrderType, WorkOrderNumber = @WorkOrderNumber WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

        With cmd.Parameters
            .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
            .Add("@SalesOrderDate", SqlDbType.VarChar).Value = SalesOrderDate
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
            .Add("@CustomerPOType", SqlDbType.VarChar).Value = txtCustomerPO.Text
            .Add("@SalesPerson", SqlDbType.VarChar).Value = cboSalesperson.Text
            .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@ShippingDate", SqlDbType.VarChar).Value = ShippingDate
            .Add("@HeaderComment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@PRONumber", SqlDbType.VarChar).Value = ""
            .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
            .Add("@TotalSalesTax", SqlDbType.VarChar).Value = TotalSalesTax
            .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = TotalSalesTax2
            .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = TotalSalesTax3
            .Add("@TaxOnFreight", SqlDbType.VarChar).Value = 0
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@SOTotal", SqlDbType.VarChar).Value = QuoteTotal
            .Add("@TotalEstCOS", SqlDbType.VarChar).Value = 0
            .Add("@TaxRate1", SqlDbType.VarChar).Value = AddTaxRate1
            .Add("@TaxRate2", SqlDbType.VarChar).Value = AddTaxRate2
            .Add("@TaxRate3", SqlDbType.VarChar).Value = AddTaxRate3
            .Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
            .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
            .Add("@QuoteNumber", SqlDbType.VarChar).Value = ""
            .Add("@QuotedFreight", SqlDbType.VarChar).Value = Val(txtFreightCharge.Text)
            .Add("@ShippingWeight", SqlDbType.VarChar).Value = TotalOrderWeight
            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
            .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
            .Add("@FOB", SqlDbType.VarChar).Value = FOB
            .Add("@CustomerClass", SqlDbType.VarChar).Value = "STANDARD"
            .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
            .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
            .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtShipToAddress1.Text
            .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtShipToAddress2.Text
            .Add("@ShipToCity", SqlDbType.VarChar).Value = txtShipToCity.Text
            .Add("@ShipToState", SqlDbType.VarChar).Value = txtShipToState.Text
            .Add("@ShipToZip", SqlDbType.VarChar).Value = txtShipToZip.Text
            .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtShipToCountry.Text
            .Add("@ShipEmail", SqlDbType.VarChar).Value = ""
            .Add("@ShippingAccount", SqlDbType.VarChar).Value = ""
            .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = ""
            .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = ""
            .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = ""
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@SalesOrderType", SqlDbType.VarChar).Value = "Q"
            .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = 0
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub SaveInsertAdditionalShipTo()
        cmd = New SqlCommand("INSERT INTO AdditionalShipTo (ShipToID, CustomerID, DivisionID, Address1, Address2, City, State, Zip, Country, Name) values (@ShipToID, @CustomerID, @DivisionID, @Address1, @Address2, @City, @State, @Zip, @Country, @Name)", con)

        With cmd.Parameters
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Address1", SqlDbType.VarChar).Value = txtShipToAddress1.Text
            .Add("@Address2", SqlDbType.VarChar).Value = txtShipToAddress2.Text
            .Add("@City", SqlDbType.VarChar).Value = txtShipToCity.Text
            .Add("@State", SqlDbType.VarChar).Value = txtShipToState.Text
            .Add("@Zip", SqlDbType.VarChar).Value = txtShipToZip.Text
            .Add("@Country", SqlDbType.VarChar).Value = txtShipToCountry.Text
            .Add("@Name", SqlDbType.VarChar).Value = txtShipToName.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub SaveUpdateAdditionalShipTo()
        cmd = New SqlCommand("UPDATE AdditionalShipTo SET Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, Name = @Name WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Address1", SqlDbType.VarChar).Value = txtShipToAddress1.Text
            .Add("@Address2", SqlDbType.VarChar).Value = txtShipToAddress2.Text
            .Add("@City", SqlDbType.VarChar).Value = txtShipToCity.Text
            .Add("@State", SqlDbType.VarChar).Value = txtShipToState.Text
            .Add("@Zip", SqlDbType.VarChar).Value = txtShipToZip.Text
            .Add("@Country", SqlDbType.VarChar).Value = txtShipToCountry.Text
            .Add("@Name", SqlDbType.VarChar).Value = txtShipToName.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Other Controls

    Private Sub chkADDPST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkADDPST.CheckedChanged
        If chkADDPST.Checked = True Then
            Dim SUMProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
            Dim SUMProductTotalCommand As New SqlCommand(SUMProductTotalStatement, con)
            SUMProductTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
            SUMProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(SUMProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            con.Close()

            FreightCharge = Val(txtFreightCharge.Text)

            chkADDHST.Checked = False

            PSTTaxRate = 0.07
            GSTTaxRate = 0.05

            PSTExtendedAmount = PSTTaxRate * (ProductTotal + FreightCharge)
            GSTExtendedAmount = GSTTaxRate * (ProductTotal + FreightCharge)
            HSTExtendedAmount = 0

            lblHSTExtendedAmount.Text = FormatCurrency(HSTExtendedAmount, 2)
            lblSalesTax.Text = FormatCurrency(GSTExtendedAmount, 2)
            lblPSTExtendedAmount.Text = FormatCurrency(PSTExtendedAmount, 2)

            QuoteTotal = Val(txtFreightCharge.Text) + ProductTotal + PSTExtendedAmount + GSTExtendedAmount
            lblQuoteTotal.Text = FormatCurrency(QuoteTotal, 2)
        ElseIf chkADDPST.Checked = False Then
            Dim SUMProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
            Dim SUMProductTotalCommand As New SqlCommand(SUMProductTotalStatement, con)
            SUMProductTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
            SUMProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(SUMProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            con.Close()

            FreightCharge = Val(txtFreightCharge.Text)

            PSTTaxRate = 0.07
            GSTTaxRate = 0.05

            PSTExtendedAmount = 0
            GSTExtendedAmount = GSTTaxRate * (ProductTotal + FreightCharge)
            HSTExtendedAmount = 0

            lblHSTExtendedAmount.Text = FormatCurrency(HSTExtendedAmount, 2)
            lblSalesTax.Text = FormatCurrency(GSTExtendedAmount, 2)
            lblPSTExtendedAmount.Text = FormatCurrency(PSTExtendedAmount, 2)

            QuoteTotal = Val(txtFreightCharge.Text) + ProductTotal + PSTExtendedAmount + GSTExtendedAmount
            lblQuoteTotal.Text = FormatCurrency(QuoteTotal, 2)
        End If
    End Sub

    Private Sub chkADDHST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkADDHST.CheckedChanged
        If chkADDHST.Checked = True Then
            Dim HSTRateString As String = "SELECT SalesTaxRate3 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim HSTRateCommand As New SqlCommand(HSTRateString, con)
            HSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            HSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim SUMProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
            Dim SUMProductTotalCommand As New SqlCommand(SUMProductTotalStatement, con)
            SUMProductTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
            SUMProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim GetHSTValueStatement As String = "SELECT TotalSalesTax3 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
            Dim GetHSTValueCommand As New SqlCommand(GetHSTValueStatement, con)
            GetHSTValueCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
            GetHSTValueCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                HSTTaxRate = CDbl(HSTRateCommand.ExecuteScalar)
            Catch ex As Exception
                HSTTaxRate = 0
            End Try
            Try
                ProductTotal = CDbl(SUMProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                HSTValue = CDbl(GetHSTValueCommand.ExecuteScalar)
            Catch ex As Exception
                HSTValue = 0
            End Try
            con.Close()

            FreightCharge = Val(txtFreightCharge.Text)

            chkADDPST.Checked = False
            txtHSTRate.Visible = True

            If HSTValue = 0 Then
                txtHSTRate.Text = HSTTaxRate
            Else
                HSTTaxRate = HSTValue / (ProductTotal + FreightCharge)
                txtHSTRate.Text = HSTTaxRate
            End If

            GSTExtendedAmount = 0
            PSTExtendedAmount = 0
            HSTExtendedAmount = (ProductTotal + FreightCharge) * HSTTaxRate

            lblHSTExtendedAmount.Text = FormatCurrency(HSTExtendedAmount, 2)
            lblPSTExtendedAmount.Text = FormatCurrency(PSTExtendedAmount, 2)
            lblSalesTax.Text = FormatCurrency(GSTExtendedAmount, 2)

            QuoteTotal = HSTExtendedAmount + PSTExtendedAmount + GSTExtendedAmount + FreightCharge + ProductTotal
            lblQuoteTotal.Text = FormatCurrency(QuoteTotal, 2)
        ElseIf chkADDHST.Checked = False Then
            Dim SUMProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
            Dim SUMProductTotalCommand As New SqlCommand(SUMProductTotalStatement, con)
            SUMProductTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboQuoteNumber.Text)
            SUMProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(SUMProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            con.Close()

            FreightCharge = Val(txtFreightCharge.Text)

            GSTTaxRate = 0.05

            txtHSTRate.Visible = False

            GSTExtendedAmount = GSTTaxRate * (ProductTotal + FreightCharge)
            PSTExtendedAmount = 0
            HSTExtendedAmount = 0

            lblHSTExtendedAmount.Text = FormatCurrency(HSTExtendedAmount, 2)
            lblPSTExtendedAmount.Text = FormatCurrency(PSTExtendedAmount, 2)
            lblSalesTax.Text = FormatCurrency(GSTExtendedAmount, 2)

            QuoteTotal = HSTExtendedAmount + PSTExtendedAmount + GSTExtendedAmount + FreightCharge + ProductTotal
            lblQuoteTotal.Text = FormatCurrency(QuoteTotal, 2)
        End If
    End Sub

    Private Sub chkTaxable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTaxable.CheckedChanged
        If chkTaxable.Checked = True Then
            Dim SalesTaxStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim SalesTaxCommand As New SqlCommand(SalesTaxStatement, con)
            SalesTaxCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            SalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TaxRate = CDbl(SalesTaxCommand.ExecuteScalar)
            Catch ex As Exception
                TaxRate = 0
            End Try
            con.Close()

            txtTaxRate.Text = TaxRate
            txtTaxRate.Visible = True

            'Calculate Sales Tax for line
            LineTotal = LinePrice * LineQuantity
            LineTax = LineTotal * TaxRate
            TotalSalesTax = TotalSalesTax + LineTax
        Else
            txtTaxRate.Visible = False
            LineTax = 0
            TotalSalesTax = TotalSalesTax + LineTax
        End If
    End Sub

    Private Sub llCustomerID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llCustomerID.LinkClicked
        GlobalDivisionCode = cboDivisionID.Text
        GlobalCustomerID = cboCustomerID.Text

        Using NewCustomerInfoPopup As New CustomerInfoPopup
            Dim Result = NewCustomerInfoPopup.ShowDialog()
        End Using
    End Sub

    Private Sub llPriceLookup_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPriceLookup.LinkClicked
        GlobalDivisionCode = cboDivisionID.Text
        GlobalSOPartNumber = cboPartNumber.Text
        GlobalSOCustomerID = cboCustomerID.Text

        Using NewSOSalesPricePopup As New SOSalesPricePopup
            Dim Result = NewSOSalesPricePopup.ShowDialog()
        End Using
    End Sub
End Class