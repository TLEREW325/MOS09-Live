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
Public Class ConvertSOToPO
    Inherits System.Windows.Forms.Form

    Dim LastLineNumber, NextLineNumber, NextTransactionNumber, LastTransactionNumber, POLineNumber, counter As Integer
    Dim MAXDate, SalesOrderNumber, PurchaseHeader As Integer
    Dim strSalesOrderNumber, strPONumber As String
    Dim ShipMethod, AdditionalShipTo, CustomerName, SalesOrderDate, CustomerID, ShipVia As String
    Dim POTotal, SumExtendedAmount, LastPurchaseCost As Double

    'Variables for Shipping Address
    Dim ShipName, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZipCode, ShipCountry As String

    'Set up variables and database connection
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ConvertSOToPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
        End If

        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        LoadCustomerList()
        LoadCustomerName()
        LoadVendorList()
        LoadSalesOrderNumber()
    End Sub

    Public Sub ClearOnLoad()
        'Clear grids and text boxes on load
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        dtpSalesOrderDate.Text = ""
    End Sub

    Public Sub ClearData()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboVendorName.SelectedIndex = -1

        dtpPODate.Text = ""
        dtpSalesOrderDate.Text = ""

        cboSalesOrderNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        NextTransactionNumber = 0
        LastTransactionNumber = 0
        NextLineNumber = 0
        LastLineNumber = 0
        POLineNumber = 0
        counter = 0
        SalesOrderNumber = 0
        PurchaseHeader = 0
        strSalesOrderNumber = ""
        strPONumber = ""
        SalesOrderDate = ""
        CustomerID = ""
        ShipVia = ""
        MAXDate = 0
        LastPurchaseCost = 0
        CustomerName = ""
        AdditionalShipTo = ""
        ShipName = ""
        ShipAddress1 = ""
        ShipAddress2 = ""
        ShipCity = ""
        ShipState = ""
        ShipZipCode = ""
        ShipCountry = ""
        ShipMethod = ""
    End Sub

    Public Sub ShowSalesOrderLineData()
        cmd = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND LineStatus = @LineStatus AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboSalesOrderNumber.Text)
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderLineTable")
        dgvSalesOrderLines.DataSource = ds.Tables("SalesOrderLineTable")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSalesOrderLines.DataSource = Nothing
    End Sub

    Public Sub LoadSalesOrderNumber()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SOStatus = @SOStatus ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "DROPSHIP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds1.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerID.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorList()
        cmd = New SqlCommand("SELECT VendorCode, VendorName FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "Vendor")
        cboVendorID.DataSource = ds3.Tables("Vendor")
        cboVendorName.DataSource = ds3.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
        cboVendorName.SelectedIndex = -1
    End Sub

    Private Sub LoadCustomerName()
        'Create commands to load Customer List for each division
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "CustomerList")
        con.Close()

        cboCustomerName.DataSource = ds4.Tables("CustomerList")
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1String As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1String, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As System.Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1String As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1String, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As System.Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID1
    End Sub

    Public Sub LoadSalesOrderData()
        Dim GetSODataStatement As String = "SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SalesOrderKey = @SalesOrderKey"
        Dim GetSODataCommand As New SqlCommand(GetSODataStatement, con)
        GetSODataCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetSODataCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboSalesOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetSODataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CustomerID")) Then
                CustomerID = ""
            Else
                CustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("SalesOrderDate")) Then
                SalesOrderDate = dtpSalesOrderDate.Text
            Else
                SalesOrderDate = reader.Item("SalesOrderDate")
            End If
            If IsDBNull(reader.Item("ShipVia")) Then
                ShipVia = ""
            Else
                ShipVia = reader.Item("ShipVia")
            End If
            If IsDBNull(reader.Item("ShippingMethod")) Then
                ShipMethod = ""
            Else
                ShipMethod = reader.Item("ShippingMethod")
            End If
        Else
            CustomerID = ""
            SalesOrderDate = dtpSalesOrderDate.Text
            ShipVia = ""
            ShipMethod = ""
        End If
        reader.Close()
        con.Close()

        Dim CustomerNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
        Dim CustomerNameCommand As New SqlCommand(CustomerNameStatement, con)
        CustomerNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CustomerNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName = CStr(CustomerNameCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerName = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID
        cboCustomerName.Text = CustomerName
        cboShipVia.Text = ShipVia
        cboShipMethod.Text = ShipMethod
        dtpSalesOrderDate.Text = SalesOrderDate
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cboSalesOrderNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalesOrderNumber.SelectedIndexChanged
        ShowSalesOrderLineData()
        LoadSalesOrderData()
    End Sub

    Private Sub cmdCreatePO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreatePO.Click
        If cboCustomerID.Text = "" Or cboVendorID.Text = "" Or cboSalesOrderNumber.Text = "" Then
            MsgBox("You must have a Vendor ID, Customer, and Sales Order Selected", MsgBoxStyle.OkOnly)
        Else
            'Get Sales Order Data
            Dim SOHeaderComment As String = ""
            Dim SpecialInstructions As String = ""
            Dim CommentInstructions As String = ""
            Dim CustomerPO As String = ""

            Dim GetSODataStatement As String = "SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SalesOrderKey = @SalesOrderKey"
            Dim GetSODataCommand As New SqlCommand(GetSODataStatement, con)
            GetSODataCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetSODataCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboSalesOrderNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetSODataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("ShipToName")) Then
                    ShipName = ""
                Else
                    ShipName = reader.Item("ShipToName")
                End If
                If IsDBNull(reader.Item("ShipToAddress1")) Then
                    ShipAddress1 = ""
                Else
                    ShipAddress1 = reader.Item("ShipToAddress1")
                End If
                If IsDBNull(reader.Item("ShipToAddress2")) Then
                    ShipAddress2 = ""
                Else
                    ShipAddress2 = reader.Item("ShipToAddress2")
                End If
                If IsDBNull(reader.Item("ShipToCity")) Then
                    ShipCity = ""
                Else
                    ShipCity = reader.Item("ShipToCity")
                End If
                If IsDBNull(reader.Item("ShipToState")) Then
                    ShipState = ""
                Else
                    ShipState = reader.Item("ShipToState")
                End If
                If IsDBNull(reader.Item("ShipToZip")) Then
                    ShipZipCode = ""
                Else
                    ShipZipCode = reader.Item("ShipToZip")
                End If
                If IsDBNull(reader.Item("ShipToCountry")) Then
                    ShipCountry = ""
                Else
                    ShipCountry = reader.Item("ShipToCountry")
                End If
                If IsDBNull(reader.Item("HeaderComment")) Then
                    SOHeaderComment = ""
                Else
                    SOHeaderComment = reader.Item("HeaderComment")
                End If
                If IsDBNull(reader.Item("SpecialInstructions")) Then
                    SpecialInstructions = ""
                Else
                    SpecialInstructions = reader.Item("SpecialInstructions")
                End If
                If IsDBNull(reader.Item("CustomerPO")) Then
                    CustomerPO = ""
                Else
                    CustomerPO = reader.Item("CustomerPO")
                End If
                If IsDBNull(reader.Item("AdditionalShipTo")) Then
                    AdditionalShipTo = ""
                Else
                    AdditionalShipTo = reader.Item("AdditionalShipTo")
                End If
                If IsDBNull(reader.Item("ShippingMethod")) Then
                    ShipMethod = ""
                Else
                    ShipMethod = reader.Item("ShippingMethod")
                End If
            Else
                ShipState = ""
                ShipCountry = ""
                ShipZipCode = ""
                ShipCity = ""
                ShipAddress1 = ""
                ShipAddress2 = ""
                ShipName = ""
                SOHeaderComment = ""
                SalesOrderDate = dtpSalesOrderDate.Text
                ShipVia = ""
                AdditionalShipTo = ""
                ShipMethod = ""
                SpecialInstructions = ""
            End If
            reader.Close()
            con.Close()

            CommentInstructions = SOHeaderComment + "  ---  " + SpecialInstructions + " --- Cust. PO# " + CustomerPO

            'Creat new PO Number
            Dim MAXStatement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderHeaderTable"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As Exception
                LastTransactionNumber = 45000000
            End Try
            con.Close()

            NextTransactionNumber = LastTransactionNumber + 1
            GlobalPONumber = NextTransactionNumber
            SalesOrderNumber = Val(cboSalesOrderNumber.Text)
            strSalesOrderNumber = CStr(SalesOrderNumber)
            PurchaseHeader = NextTransactionNumber
            strPONumber = CStr(PurchaseHeader)

            'Write Header Data to Purchase Order Header Table
            cmd = New SqlCommand("Insert Into PurchaseOrderHeaderTable(PurchaseOrderHeaderKey, PODate, VendorID, PaymentCode, POHeaderComment, ShipDate, ShipMethodID, FreightCharge, SalesTax, ProductTotal, POTotal, Status, PODropShipCustomerID, POAdditionalShipTo, DivisionID, DropShipSalesOrderNumber, PurchaseAgent, ShipName, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZipCode, ShipCountry, EstTotalWeight, EstTotalBoxes, ShipMethod)values(@PurchaseOrderHeaderKey, @PODate, @VendorID, @PaymentCode, @POHeaderComment, @ShipDate, @ShipMethodID, @FreightCharge, @SalesTax, @ProductTotal, @POTotal, @Status, @PODropShipCustomerID, @POAdditionalShipTo, @DivisionID, @DropShipSalesOrderNumber, @PurchaseAgent, @ShipName, @ShipAddress1, @ShipAddress2, @ShipCity, @ShipState, @ShipZipCode, @ShipCountry, @EstTotalWeight, @EstTotalBoxes, @ShipMethod)", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                .Add("@PODate", SqlDbType.VarChar).Value = dtpPODate.Text
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                .Add("@PaymentCode", SqlDbType.VarChar).Value = "N30"
                .Add("@POHeaderComment", SqlDbType.VarChar).Value = CommentInstructions
                .Add("@ShipDate", SqlDbType.VarChar).Value = dtpPODate.Text
                .Add("@ShipMethodID", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@ShipMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@FreightCharge", SqlDbType.VarChar).Value = 0
                .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                .Add("@POTotal", SqlDbType.VarChar).Value = 0
                .Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"
                .Add("@PODropShipCustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@POAdditionalShipTo", SqlDbType.VarChar).Value = AdditionalShipTo
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@DropShipSalesOrderNumber", SqlDbType.VarChar).Value = Val(cboSalesOrderNumber.Text)
                .Add("@PurchaseAgent", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@ShipName", SqlDbType.VarChar).Value = ShipName
                .Add("@ShipAddress1", SqlDbType.VarChar).Value = ShipAddress1
                .Add("@ShipAddress2", SqlDbType.VarChar).Value = ShipAddress2
                .Add("@ShipCity", SqlDbType.VarChar).Value = ShipCity
                .Add("@ShipState", SqlDbType.VarChar).Value = ShipState
                .Add("@ShipZipCode", SqlDbType.VarChar).Value = ShipZipCode
                .Add("@ShipCountry", SqlDbType.VarChar).Value = ShipCountry
                .Add("@EstTotalWeight", SqlDbType.VarChar).Value = 0
                .Add("@EstTotalBoxes", SqlDbType.VarChar).Value = 0
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Declare variable used in Line Entry
            Dim PartNumber, PartDescription, CreditGLAccount, LineComment As String
            Dim SOLineNumber As Integer
            Dim OrderQuantity, UnitCost As Double

            'Select Lines from Grid to write to the new table.
            For Each row As DataGridViewRow In dgvSalesOrderLines.Rows
                Try
                    SOLineNumber = row.Cells("SalesOrderLineKeyColumn").Value
                Catch ex As Exception
                    SOLineNumber = 100
                End Try
                Try
                    PartNumber = row.Cells("ItemIDColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = row.Cells("DescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    OrderQuantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    OrderQuantity = 0
                End Try
                Try
                    UnitCost = row.Cells("PriceColumn").Value
                Catch ex As Exception
                    UnitCost = 0
                End Try
                Try
                    CreditGLAccount = row.Cells("CreditGLAccountColumn").Value
                Catch ex As Exception
                    CreditGLAccount = "12100"
                End Try
                Try
                    LineComment = row.Cells("LineCommentColumn").Value
                Catch ex As Exception
                    LineComment = ""
                End Try

                'Get Last Purchase Cost for Item
                'Load values into Cost Field (Last Purchase Cost for Remotes, Last Sale Price for TWD)
                Dim MAXDateStatement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXDate = CInt(MAXDateCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXDate = 0
                End Try
                con.Close()

                Dim LastPriceStatement As String = "SELECT UnitCost FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
                Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                LastPriceCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = MAXDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                Catch ex As Exception
                    LastPurchaseCost = 0
                End Try
                con.Close()

                'Get Next Line Number for Sales Order Lines
                Dim MAXLineStatement As String = "SELECT MAX(PurchaseOrderLineNumber) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
                Dim MAXLineCommand As New SqlCommand(MAXLineStatement, con)
                MAXLineCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastLineNumber = CInt(MAXLineCommand.ExecuteScalar)
                Catch ex As Exception
                    LastLineNumber = 0
                End Try
                con.Close()

                NextLineNumber = LastLineNumber + 1

                'Write Line data to new table
                cmd = New SqlCommand("Insert Into PurchaseOrderLineTable(PurchaseOrderHeaderKey, PurchaseOrderLineNumber, PartNumber, PartDescription, OrderQuantity, UnitCost, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, SelectForInvoice, LineComment)Values(@PurchaseOrderHeaderKey, @PurchaseOrderLineNumber, @PartNumber, @PartDescription, @OrderQuantity, @UnitCost, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @SelectForInvoice, @LineComment)", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@OrderQuantity", SqlDbType.VarChar).Value = OrderQuantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = LastPurchaseCost
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = OrderQuantity * LastPurchaseCost
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "20990"
                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = CreditGLAccount
                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear Variables before next entry
                PartNumber = ""
                PartDescription = ""
                LastPurchaseCost = 0
                LineComment = ""
                CreditGLAccount = ""
                OrderQuantity = 0
                UnitCost = 0
            Next

            'Update PO Totals from the line amounts
            Dim SumExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
            Dim SumExtendedAmountCommand As New SqlCommand(SumExtendedAmountStatement, con)
            SumExtendedAmountCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumExtendedAmount = CDbl(SumExtendedAmountCommand.ExecuteScalar)
            Catch ex As Exception
                SumExtendedAmount = 0
            End Try
            con.Close()

            POTotal = SumExtendedAmount

            'Update PO Totals
            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET ProductTotal = @ProductTotal, POTotal = @POTotal  WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
                .Add("@POTotal", SqlDbType.VarChar).Value = POTotal
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Update SO with DS Number
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET DropShipPONumber = @DropShipPONumber WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(cboSalesOrderNumber.Text)
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@DropShipPONumber", SqlDbType.VarChar).Value = NextTransactionNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("New PO has been created.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdPOForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPOForm.Click
        GlobalPONumber = NextTransactionNumber
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPOForm As New POForm
            Dim result = NewPOForm.ShowDialog()
        End Using

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub
End Class