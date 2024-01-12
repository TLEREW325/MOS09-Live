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
Public Class ARCustomerAccounts
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim CustomerMargin, TotalCostOfSales, TotalFreightCollected, TotalSales, AverageTotal, AROutstanding, AR31To45, AR46To60, AR61To90, ARLessThan30, AROver91 As Double
    Dim LastActivityDate As String = ""
    Dim CustomerClass As String = ""
    Dim NumberOfOrders As Integer = 0

    'Variables to calculate MTD and YTD Sales
    Dim YearDate, MonthDate, BeginDate, EndDate As Date
    Dim YearOfYear, MonthOfYear, Year As Integer
    Dim strMonthOfYear, strYear As String
    Dim MTDSales, YTDSales As Double

    Private Sub ARCustomerAccounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If GlobalCustomerID = "" Then
            cboCustomerID.SelectedIndex = -1
            ClearInvoiceData()
            ClearSalesOrders()
            ClearItemsSold()
        Else
            cboCustomerID.Text = GlobalCustomerID
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

    Public Sub ClearInvoiceData()
        dgvOpenInvoices.DataSource = Nothing
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderQuery")
        dgvOpenInvoices.DataSource = ds.Tables("InvoiceHeaderQuery")
        con.Close()
    End Sub

    Public Sub ShowClosed()
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceStatus = @InvoiceStatus", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderQuery")
        dgvOpenInvoices.DataSource = ds.Tables("InvoiceHeaderQuery")
        con.Close()
    End Sub

    Public Sub ShowOpen()
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceStatus = @InvoiceStatus", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderQuery")
        dgvOpenInvoices.DataSource = ds.Tables("InvoiceHeaderQuery")
        con.Close()
    End Sub

    Public Sub LoadCustomer()
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

    Public Sub ClearSalesOrders()
        dgvSalesOrders.DataSource = Nothing
    End Sub

    Public Sub ShowAllSalesOrders()
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE CustomerID = @CustomerID And DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SalesOrderHeaderTable")
        dgvSalesOrders.DataSource = ds2.Tables("SalesOrderHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowOpenSalesOrders()
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE CustomerID = @CustomerID And DivisionKey = @DivisionKey AND (SOStatus = @SOStatus OR SOStatus = @SOStatus1 OR SOStatus = @SOStatus2)", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "COMMITTED"
        cmd.Parameters.Add("@SOStatus1", SqlDbType.VarChar).Value = "OPEN"
        cmd.Parameters.Add("@SOStatus2", SqlDbType.VarChar).Value = "PICKED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SalesOrderHeaderTable")
        dgvSalesOrders.DataSource = ds2.Tables("SalesOrderHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowShippedSalesOrders()
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE CustomerID = @CustomerID And DivisionKey = @DivisionKey AND (SOStatus = @SOStatus OR SOStatus = @SOStatus1)", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "CLOSED"
        cmd.Parameters.Add("@SOStatus1", SqlDbType.VarChar).Value = "SHIPPED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SalesOrderHeaderTable")
        dgvSalesOrders.DataSource = ds2.Tables("SalesOrderHeaderTable")
        con.Close()
    End Sub

    Public Sub ClearItemsSold()
        dgvShipLines.DataSource = Nothing
    End Sub

    Public Sub ShowItemsSold()
        cmd = New SqlCommand("SELECT * FROM ShipmentLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ShipmentLineQuery")
        dgvShipLines.DataSource = ds3.Tables("ShipmentLineQuery")
        con.Close()
    End Sub

    Public Sub ShowItemsSoldByPart()
        cmd = New SqlCommand("SELECT * FROM ShipmentLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PartNumber = @PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ShipmentLineQuery")
        dgvShipLines.DataSource = ds3.Tables("ShipmentLineQuery")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboPartNumber.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ItemList")
        cboPartDescription.DataSource = ds5.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CustomerList")
        cboCustomerName.DataSource = ds6.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub ShowCustomerNotes()
        cmd = New SqlCommand("SELECT * FROM CustomerNotes WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID ORDER BY NoteDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "CustomerNotes")
        dgvCustomerNotes.DataSource = ds7.Tables("CustomerNotes")
        con.Close()
    End Sub

    Public Sub ClearCustomerNotes()
        dgvCustomerNotes.DataSource = Nothing
    End Sub

    Public Sub ShowARAging()
        cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID ORDER BY InvoiceDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "ARAgingCategory")
        DataGridView4.DataSource = ds8.Tables("ARAgingCategory")
        con.Close()
    End Sub

    Public Sub ClearARAging()
        DataGridView4.DataSource = Nothing
    End Sub

    Public Sub ShowCashReceipts()
        cmd = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID ORDER BY PaymentDate DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd
        myAdapter9.Fill(ds9, "ARCustomerPayment")
        DataGridView5.DataSource = ds9.Tables("ARCustomerPayment")
        con.Close()
    End Sub

    Public Sub ClearCashReceipts()
        DataGridView5.DataSource = Nothing
    End Sub

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

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
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

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
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

    Public Sub LoadPaymentTerms()
        Dim PaymentTerms As String = ""

        Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
        PaymentTermsCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentTerms = ""
        End Try
        con.Close()

        txtPaymentTerms.Text = PaymentTerms
    End Sub

    Public Sub ClearData()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        txt30Days.Clear()
        txt31To45Days.Clear()
        txt46To60Days.Clear()
        txt61To90Days.Clear()
        txt90Days.Clear()
        txtAverageOrder.Clear()
        txtCurrentBalance.Clear()
        txtLastActivity.Clear()
        txtMTDSales.Clear()
        txtTotalSales.Clear()
        txtYTDSales.Clear()
        txtTotalFreightCollected.Clear()
        txtTotalCost.Clear()
        txtCustomerMargin.Clear()
        txtNumberOfOrders.Clear()
        txtPaymentTerms.Clear()

        dgvCustomerNotes.DataSource = Nothing
        dgvOpenInvoices.DataSource = Nothing
        dgvSalesOrders.DataSource = Nothing
        dgvShipLines.DataSource = Nothing
        DataGridView4.DataSource = Nothing
        DataGridView5.DataSource = Nothing

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        TotalSales = 0
        AverageTotal = 0
        AROutstanding = 0
        AR31To45 = 0
        AR46To60 = 0
        AR61To90 = 0
        ARLessThan30 = 0
        AROver91 = 0
        LastActivityDate = ""
        YearOfYear = 0
        MonthOfYear = 0
        Year = 0
        strMonthOfYear = ""
        strYear = ""
        MTDSales = 0
        YTDSales = 0
        TotalFreightCollected = 0
        CustomerMargin = 0
        TotalCostOfSales = 0
        CustomerClass = ""
        NumberOfOrders = 0
    End Sub

    Public Sub LoadTotalFreight()
        Dim TotalFreightCollectedString As String = "SELECT SUM(BilledFreight) FROM InvoiceHeaderTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim TotalFreightCollectedCommand As New SqlCommand(TotalFreightCollectedString, con)
        TotalFreightCollectedCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        TotalFreightCollectedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalFreightCollected = CDbl(TotalFreightCollectedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalFreightCollected = 0
        End Try
        con.Close()

        txtTotalFreightCollected.Text = FormatCurrency(TotalFreightCollected, 2)
    End Sub

    Public Sub LoadCustomerClass()
        Dim CustomerClassString As String = "SELECT CustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerClassCommand As New SqlCommand(CustomerClassString, con)
        CustomerClassCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerClass = CStr(CustomerClassCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerClass = "STANDARD"
        End Try
        con.Close()
    End Sub

    Public Sub LoadCustomerARAging()
        Dim AgingLessThan30String As String = "SELECT SUM(AgingLessThan30) FROM ARAgingCategory WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim AgingLessThan30Command As New SqlCommand(AgingLessThan30String, con)
        AgingLessThan30Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        AgingLessThan30Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Aging31To45String As String = "SELECT SUM(Aging31To45) FROM ARAgingCategory WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim Aging31To45Command As New SqlCommand(Aging31To45String, con)
        Aging31To45Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        Aging31To45Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Aging46To60String As String = "SELECT SUM(Aging46To60) FROM ARAgingCategory WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim Aging46To60Command As New SqlCommand(Aging46To60String, con)
        Aging46To60Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        Aging46To60Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Aging61To90String As String = "SELECT SUM(Aging61To90) FROM ARAgingCategory WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim Aging61To90Command As New SqlCommand(Aging61To90String, con)
        Aging61To90Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        Aging61To90Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim AgingMoreThan90String As String = "SELECT SUM(AgingMoreThan90) FROM ARAgingCategory WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim AgingMoreThan90Command As New SqlCommand(AgingMoreThan90String, con)
        AgingMoreThan90Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        AgingMoreThan90Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ARLessThan30 = CDbl(AgingLessThan30Command.ExecuteScalar)
        Catch ex As Exception
            ARLessThan30 = 0
        End Try
        Try
            AR31To45 = CDbl(Aging31To45Command.ExecuteScalar)
        Catch ex As Exception
            AR31To45 = 0
        End Try
        Try
            AR46To60 = CDbl(Aging46To60Command.ExecuteScalar)
        Catch ex As Exception
            AR46To60 = 0
        End Try
        Try
            AR61To90 = CDbl(Aging61To90Command.ExecuteScalar)
        Catch ex As Exception
            AR61To90 = 0
        End Try
        Try
            AROver91 = CDbl(AgingMoreThan90Command.ExecuteScalar)
        Catch ex As Exception
            AROver91 = 0
        End Try
        con.Close()

        AROutstanding = AR31To45 + AR46To60 + AR61To90 + ARLessThan30 + AROver91

        txt30Days.Text = FormatCurrency(ARLessThan30, 2)
        txt31To45Days.Text = FormatCurrency(AR31To45, 2)
        txt46To60Days.Text = FormatCurrency(AR46To60, 2)
        txt61To90Days.Text = FormatCurrency(AR61To90, 2)
        txt90Days.Text = FormatCurrency(AROver91, 2)
        txtCurrentBalance.Text = FormatCurrency(AROutstanding, 2)
    End Sub

    Public Sub LoadCustomerHistory()
        'Calculate MTD Totals
        MonthDate = Today()
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = MonthDate

        Dim MTDSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDSalesCommand As New SqlCommand(MTDSalesStatement, con)
        MTDSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        MTDSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDSales = CDbl(MTDSalesCommand.ExecuteScalar)
        Catch ex As Exception
            MTDSales = 0
        End Try
        con.Close()

        txtMTDSales.Text = FormatCurrency(MTDSales, 2)
        '*********************************************************************************************************
        'Calculate YTD Totals
        YearDate = Today()
        YearOfYear = YearDate.Year
        MonthOfYear = YearDate.Month

        If MonthOfYear < 5 Then
            YearOfYear = YearOfYear - 1
        End If

        strYear = CStr(YearOfYear)
        BeginDate = "05/01/" + strYear
        EndDate = YearDate

        Dim YTDSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDSalesCommand As New SqlCommand(YTDSalesStatement, con)
        YTDSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        YTDSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim NumberOfOrdersStatement As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND CustomerID = @CustomerID AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Dim NumberOfOrdersCommand As New SqlCommand(NumberOfOrdersStatement, con)
        NumberOfOrdersCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        NumberOfOrdersCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        NumberOfOrdersCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        NumberOfOrdersCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDSales = CDbl(YTDSalesCommand.ExecuteScalar)
        Catch ex As Exception
            YTDSales = 0
        End Try
        Try
            NumberOfOrders = CInt(NumberOfOrdersCommand.ExecuteScalar)
        Catch ex As Exception
            NumberOfOrders = 0
        End Try
        con.Close()

        txtNumberOfOrders.Text = FormatNumber(NumberOfOrders, 0)
        txtYTDSales.Text = FormatCurrency(YTDSales, 2)
        '********************************************************************************************************************************
        'Populates calculated Customer stats in labels
        Dim AverageStatement As String = "SELECT AVG(SOTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND CustomerID = @CustomerID"
        Dim AverageCommand As New SqlCommand(AverageStatement, con)
        AverageCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        AverageCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        Dim LastActivityStatement As String = "SELECT MAX(SalesOrderDate) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND CustomerID = @CustomerID"
        Dim LastActivityCommand As New SqlCommand(LastActivityStatement, con)
        LastActivityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        LastActivityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        Dim TotalSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
        Dim TotalSalesCommand As New SqlCommand(TotalSalesStatement, con)
        TotalSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        Dim TotalCostStatement As String = "SELECT SUM(InvoiceCOS) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
        Dim TotalCostCommand As New SqlCommand(TotalCostStatement, con)
        TotalCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalCostCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AverageTotal = CDbl(AverageCommand.ExecuteScalar)
        Catch ex As Exception
            AverageTotal = 0
        End Try
        Try
            LastActivityDate = CStr(LastActivityCommand.ExecuteScalar)
        Catch ex As Exception
            LastActivityDate = "NONE"
        End Try
        Try
            TotalSales = CDbl(TotalSalesCommand.ExecuteScalar)
        Catch ex As Exception
            TotalSales = 0
        End Try
        Try
            TotalCostOfSales = CDbl(TotalCostCommand.ExecuteScalar)
        Catch ex As Exception
            TotalCostOfSales = 0
        End Try
        con.Close()

        If TotalSales = 0 Then
            CustomerMargin = 0
        Else
            CustomerMargin = 1 - (TotalCostOfSales / TotalSales)
        End If

        txtTotalCost.Text = FormatCurrency(TotalCostOfSales, 2)
        txtCustomerMargin.Text = FormatPercent(CustomerMargin, 2)
        txtAverageOrder.Text = FormatCurrency(AverageTotal, 2)
        txtTotalSales.Text = FormatCurrency(TotalSales, 2)
        txtLastActivity.Text = LastActivityDate
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        GlobalCustomerID = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        GlobalCustomerID = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If cboCustomerID.Text = "" Then
            'Do nothing
        Else
            LoadCustomerNameByID()
            LoadCustomerARAging()
            LoadCustomerHistory()
            LoadTotalFreight()
            LoadCustomerClass()
            ShowData()
            ShowAllSalesOrders()
            ShowItemsSold()
            ShowCustomerNotes()
            ShowARAging()
            ShowCashReceipts()
            LoadPaymentTerms()
        End If
    End Sub

    Private Sub cmdShowClosed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowClosed.Click
        ShowClosed()
    End Sub

    Private Sub cmdShowOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowOpen.Click
        ShowOpen()
    End Sub

    Private Sub cmdShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowAll.Click
        ShowData()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub cmdOpenCustomerForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenCustomerForm.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalCustomerName = cboCustomerName.Text

        Dim NewCustomerData As New CustomerData
        NewCustomerData.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintInvoiceListing As New PrintInvoiceListDatagrid
            Dim Result = NewPrintInvoiceListing.ShowDialog()
        End Using
    End Sub

    Private Sub ARAgingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARAgingToolStripMenuItem.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintCustomerARAging As New PrintCustomerARAging
            Dim Result = NewPrintCustomerARAging.ShowDialog()
        End Using
    End Sub

    Private Sub ARCustomerStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARCustomerStatementToolStripMenuItem.Click
        cmdPrintStatement_Click(sender, e)
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomer()
        LoadCustomerName()
        LoadPartNumber()
        LoadPartDescription()
        ClearData()
        ClearVariables()

        ClearInvoiceData()
        ClearSalesOrders()
        ClearItemsSold()
    End Sub

    Private Sub cmdViewShippedOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewShippedOrders.Click
        ShowShippedSalesOrders()
    End Sub

    Private Sub cmdViewOpenOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewOpenOrders.Click
        ShowOpenSalesOrders()
    End Sub

    Private Sub cmdAllOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllOrders.Click
        ShowAllSalesOrders()
    End Sub

    Private Sub cmdPrintOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintOrders.Click
        GDS = ds2

        Using NewPrintSalesOrderListing As New PrintSalesOrderListing
            Dim Result = NewPrintSalesOrderListing.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrintStatement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintStatement.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text
        EmailInvoiceCustomer = cboCustomerID.Text
        GetCustomerEmail()

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
            Using NewPrintARCustomerStatementSingleRemote As New PrintARCustomerStatementSingleRemote
                Dim Result = NewPrintARCustomerStatementSingleRemote.ShowDialog()
            End Using
        Else
            Using NewPrintARCustomerStatementSingle As New PrintARCustomerStatementSingle
                Dim Result = NewPrintARCustomerStatementSingle.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdReprintSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintSalesOrder.Click
        Dim RowSONumber As Integer
        Dim RowStatus As String
        Dim RowIndex As Integer = Me.dgvSalesOrders.CurrentCell.RowIndex

        RowSONumber = Me.dgvSalesOrders.Rows(RowIndex).Cells("SalesOrderKeyColumn1").Value
        RowStatus = Me.dgvSalesOrders.Rows(RowIndex).Cells("SOStatusColumn1").Value

        If RowStatus = "QUOTE" Then
            'Choose correct print form for Quotes
            If cboDivisionID.Text = "TFP" Then
                GlobalSONumber = RowSONumber
                GlobalDivisionCode = cboDivisionID.Text

                Using NewPrintTFQuote As New PrintTFQuote
                    Dim result = NewPrintTFQuote.ShowDialog()
                End Using
            Else
                GlobalSONumber = RowSONumber
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
        Else
            'Choose correct print form for Sales Orders
            If cboDivisionID.Text = "TFP" Then
                GlobalSONumber = RowSONumber
                GlobalDivisionCode = cboDivisionID.Text

                Using NewPrintTFAcknowledgement As New PrintTFAcknowledgement
                    Dim result = NewPrintTFAcknowledgement.ShowDialog()
                End Using
            Else
                GlobalSONumber = RowSONumber
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
                    Using NewPrintSalesOrderRemote As New PrintSalesOrderRemote
                        Dim result = NewPrintSalesOrderRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintSalesOrder As New PrintSalesOrder
                        Dim result = NewPrintSalesOrder.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Public Sub GetCustomerEmail()
        Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
        CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            EmailCustomerEmailAddress = CStr(CustomerEmailCommand.ExecuteScalar)
        Catch ex As Exception
            EmailCustomerEmailAddress = ""
        End Try
        con.Close()
    End Sub

    Private Sub cmdReprintInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintInvoice.Click
        Dim RowInvoiceNumber, RowSONumber, RowShipmentNumber As Integer
        Dim RowDivision, RowCustomer, CustomerEmail As String

        If Me.dgvOpenInvoices.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvOpenInvoices.CurrentCell.RowIndex

            RowInvoiceNumber = Me.dgvOpenInvoices.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            RowSONumber = Me.dgvOpenInvoices.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
            RowShipmentNumber = Me.dgvOpenInvoices.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            RowDivision = Me.dgvOpenInvoices.Rows(RowIndex).Cells("DivisionIDColumn").Value
            RowCustomer = Me.dgvOpenInvoices.Rows(RowIndex).Cells("CustomerIDColumn").Value

            Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
            CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
            CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerEmail = CStr(CustomerEmailCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerEmail = ""
            End Try
            con.Close()

            'Choose the Invoice Print Form by division
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get sring Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerName.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                            Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                            Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                        End Using
                    End If
                Else
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get sring Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerName.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                            Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                            Dim result = NewPrintInvoiceBatch.ShowDialog()
                        End Using
                    End If
                End If
            Else
                If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get sring Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerName.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                            Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                            Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                        End Using
                    End If
                Else
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get sring Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerName.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                            Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                            Dim result = NewPrintInvoiceBatch.ShowDialog()
                        End Using
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdViewByPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByPart.Click
        ShowItemsSoldByPart()
    End Sub

    Private Sub cmdViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAll.Click
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1

        ShowItemsSold()
    End Sub

    Private Sub cmdPrintItemsSold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintItemsSold.Click
        GDS = ds3

        Using NewPrintItemSoldFiltered As New PrintItemsSoldFiltered
            Dim Result = NewPrintItemSoldFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub CustomerNotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerNotesToolStripMenuItem.Click
        GlobalCustomerID = cboCustomerID.Text

        Using NewCustomerNotes As New CustomerNotes
            Dim Result = NewCustomerNotes.ShowDialog
        End Using
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub dgvCustomerNotes_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomerNotes.CellDoubleClick
        GlobalCustomerID = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Me.tabMain.SelectedIndex = 0

        Using NewCustomerNoteCreation As New CustomerNoteCreation
            Dim Result = NewCustomerNoteCreation.ShowDialog()
        End Using
    End Sub

    Private Sub tabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMain.SelectedIndexChanged
        ShowCustomerNotes()
    End Sub

    Private Sub dgvOpenInvoices_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpenInvoices.CellDoubleClick
        If dgvOpenInvoices.RowCount <> 0 Then
            Dim RowInvoiceNumber, RowSONumber, RowShipmentNumber As Integer
            Dim CustomerEmail As String

            Dim RowIndex As Integer = Me.dgvOpenInvoices.CurrentCell.RowIndex

            RowInvoiceNumber = Me.dgvOpenInvoices.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            RowSONumber = Me.dgvOpenInvoices.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
            RowShipmentNumber = Me.dgvOpenInvoices.Rows(RowIndex).Cells("ShipmentNumberColumn").Value

            Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
            CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerEmail = CStr(CustomerEmailCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerEmail = ""
            End Try
            con.Close()

            'Choose the Invoice Print Form by division
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerID.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                            Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                            Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                        End Using
                    End If
                Else
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerID.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                            Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                            Dim result = NewPrintInvoiceBatch.ShowDialog()
                        End Using
                    End If
                End If
            Else
                If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerID.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                            Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                            Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                        End Using
                    End If
                Else
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerID.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                            Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                            Dim result = NewPrintInvoiceBatch.ShowDialog()
                        End Using
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgvSalesOrders_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSalesOrders.CellDoubleClick
        If dgvSalesOrders.RowCount <> 0 Then
            Dim RowSONumber As Integer
            Dim RowStatus As String
            Dim RowIndex As Integer = Me.dgvSalesOrders.CurrentCell.RowIndex

            RowSONumber = Me.dgvSalesOrders.Rows(RowIndex).Cells("SalesOrderKeyColumn1").Value
            RowStatus = Me.dgvSalesOrders.Rows(RowIndex).Cells("SOStatusColumn1").Value

            If RowStatus = "QUOTE" Then
                'Choose correct print form for Quotes
                If cboDivisionID.Text = "TFP" Then
                    GlobalSONumber = RowSONumber
                    GlobalDivisionCode = cboDivisionID.Text

                    Using NewPrintTFQuote As New PrintTFQuote
                        Dim result = NewPrintTFQuote.ShowDialog()
                    End Using
                Else
                    GlobalSONumber = RowSONumber
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
            Else
                'Choose correct print form for Sales Orders
                If cboDivisionID.Text = "TFP" Then
                    GlobalSONumber = RowSONumber
                    GlobalDivisionCode = cboDivisionID.Text

                    Using NewPrintTFAcknowledgement As New PrintTFAcknowledgement
                        Dim result = NewPrintTFAcknowledgement.ShowDialog()
                    End Using
                Else
                    GlobalSONumber = RowSONumber
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
                        Using NewPrintSalesOrderRemote As New PrintSalesOrderRemote
                            Dim result = NewPrintSalesOrderRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintSalesOrder As New PrintSalesOrder
                            Dim result = NewPrintSalesOrder.ShowDialog()
                        End Using
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView4_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellDoubleClick
        If Me.DataGridView4.RowCount <> 0 Then
            Dim RowInvoiceNumber, RowSONumber, RowShipmentNumber As Integer
            Dim CustomerEmail As String

            Dim RowIndex As Integer = Me.DataGridView4.CurrentCell.RowIndex

            RowInvoiceNumber = Me.DataGridView4.Rows(RowIndex).Cells("AgingInvoiceNumberColumn").Value

            Dim GetShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim GetShipmentNumberCommand As New SqlCommand(GetShipmentNumberStatement, con)
            GetShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
            GetShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim GetSalesOrderNumberStatement As String = "SELECT SalesOrderNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim GetSalesOrderNumberCommand As New SqlCommand(GetSalesOrderNumberStatement, con)
            GetSalesOrderNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
            GetSalesOrderNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                RowShipmentNumber = CInt(GetShipmentNumberCommand.ExecuteScalar)
            Catch ex As Exception
                RowShipmentNumber = 0
            End Try
            Try
                RowSONumber = CInt(GetSalesOrderNumberCommand.ExecuteScalar)
            Catch ex As Exception
                RowSONumber = 0
            End Try
            con.Close()

            Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
            CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerEmail = CStr(CustomerEmailCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerEmail = ""
            End Try
            con.Close()

            'Choose the Invoice Print Form by division
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerID.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                            Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                            Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                        End Using
                    End If
                Else
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerID.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                            Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                            Dim result = NewPrintInvoiceBatch.ShowDialog()
                        End Using
                    End If
                End If
            Else
                If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerID.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                            Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                            Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                        End Using
                    End If
                Else
                    GlobalInvoiceNumber = RowInvoiceNumber
                    GlobalDivisionCode = cboDivisionID.Text
                    'Get string Customer/InvoiceNumber for emails
                    EmailInvoiceCustomer = cboCustomerID.Text
                    EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                    EmailCustomerEmailAddress = CustomerEmail

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
                        Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                            Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                            Dim result = NewPrintInvoiceBatch.ShowDialog()
                        End Using
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdPrintCerts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintCerts.Click
        Dim LineInvoiceNumber, LineShipmentNumber, LineSONumber As Integer
        Dim RowDivision, RowCustomer As String

        If Me.dgvOpenInvoices.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvOpenInvoices.CurrentCell.RowIndex

            LineInvoiceNumber = Me.dgvOpenInvoices.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            LineShipmentNumber = Me.dgvOpenInvoices.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            LineSONumber = Me.dgvOpenInvoices.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
            RowDivision = Me.dgvOpenInvoices.Rows(RowIndex).Cells("DivisionIDColumn").Value
            RowCustomer = Me.dgvOpenInvoices.Rows(RowIndex).Cells("CustomerIDColumn").Value

            'Get Invoice Email Address
            Dim EmailAddressStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailAddressCommand As New SqlCommand(EmailAddressStatement, con)
            EmailAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
            EmailAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailAddress = CStr(EmailAddressCommand.ExecuteScalar)
            Catch ex As Exception
                EmailAddress = ""
            End Try
            con.Close()

            EmailInvoiceNumber = LineInvoiceNumber
            EmailSalesOrderNumber = LineSONumber
            EmailShipmentNumber = LineShipmentNumber
            EmailInvoiceCustomer = RowCustomer
            GlobalDivisionCode = RowDivision
            EmailCustomerEmailAddress = EmailAddress

            Dim CheckForNoCerts As Integer = 0

            'Check to see if there are any certs that will not print
            Dim CheckForNoCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountNoCerts FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber = @PullTestNumber"
            Dim CheckForNoCertsCommand As New SqlCommand(CheckForNoCertsStatement, con)
            CheckForNoCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = LineShipmentNumber
            CheckForNoCertsCommand.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = "NO CERT"

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader3 As SqlDataReader = CheckForNoCertsCommand.ExecuteReader()
            If reader3.HasRows Then
                reader3.Read()
                If IsDBNull(reader3.Item("CountNoCerts")) Then
                    CheckForNoCerts = 0
                Else
                    CheckForNoCerts = reader3.Item("CountNoCerts")
                End If
            Else
                CheckForNoCerts = 0
            End If
            reader3.Close()
            con.Close()

            If CheckForNoCerts = 0 Then
                'Set Global Variable to NO
                GlobalPrintNoCertPage = "NO"
            Else
                'Set Global Variable to YES
                GlobalPrintNoCertPage = "YES"
            End If

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
                Using NewEmailAllInvoiceDocsRemote As New EmailAllInvoiceDocsRemote
                    Dim Result = NewEmailAllInvoiceDocsRemote.ShowDialog()
                End Using
            Else
                Using NewEmailAllInvoiceDocs As New EmailAllInvoiceDocs
                    Dim Result = NewEmailAllInvoiceDocs.ShowDialog()
                End Using
            End If
        Else
            'Do nothing
        End If
    End Sub
End Class