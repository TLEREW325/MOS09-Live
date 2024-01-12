Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ManageShipments
    Inherits System.Windows.Forms.Form

    Dim DateFilter, CustomerFilter, CustomerFilter2, SOFilter, CustPOFilter, SalespersonFilter, ShipViaFilter As String

    Dim TotalWeight As Double = 0
    Dim TotalPallets As Integer = 0
    Dim TotalBoxes As Integer = 0
    Dim TotalOrders As Integer = 0
    Dim TotalPalletWeight As Double = 0

    Dim BeginDate, Enddate As Date

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ManageShipments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        LoadCustomer()
        LoadCustomer2()
        LoadCustomerName()
        LoadCustomerName2()
        LoadSalesperson()
        LoadShipMethod()

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

    Public Sub ClearData()
        cboCustomerID.SelectedIndex = -1
        cboCustomerID2.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboCustomerName2.SelectedIndex = -1
        cboSalespersonID.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1

        txtCustomerPO.Clear()
        txtNumberOfOrders.Clear()
        txtTotalBoxes.Clear()
        txtTotalPallets.Clear()
        txtTotalWeight.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        DateFilter = ""
        CustomerFilter = ""
        CustomerFilter2 = ""
        SOFilter = ""
        CustPOFilter = ""
        SalespersonFilter = ""
        ShipViaFilter = ""

        TotalWeight = 0
        TotalPallets = 0
        TotalBoxes = 0
        TotalOrders = 0
        TotalPalletWeight = 0
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvPickLines.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboCustomerID2.Text <> "" Then
            CustomerFilter2 = " OR CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID2.Text) + "'"
        Else
            CustomerFilter2 = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustPOFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            CustPOFilter = ""
        End If
        If cboShipVia.Text <> "" Then
            ShipViaFilter = " AND ItemID = '" + cboShipVia.Text + "'"
        Else
            ShipViaFilter = ""
        End If
        If cboSalespersonID.Text <> "" Then
            SalespersonFilter = " AND SalesmanID = '" + cboSalespersonID.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            Enddate = dtpEndDate.Text

            DateFilter = " AND PickDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM PickListLineQOH WHERE PLStatus = @PLStatus AND DivisionID = @DivisionID" + CustomerFilter + CustomerFilter2 + CustPOFilter + ShipViaFilter + DateFilter + " ORDER BY PickListHeaderKey, PickListLineKey", con)
        cmd.Parameters.Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = Enddate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PickListLineQOH")
        dgvPickLines.DataSource = ds.Tables("PickListLineQOH")
        con.Close()

        Dim QuantityOpenOnPick As Double = 0

        For Each row As DataGridViewRow In dgvPickLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectLine")
            cell.Value = "SELECTED"

            Try
                QuantityOpenOnPick = row.Cells("QuantityColumn").Value
            Catch ex As Exception
                QuantityOpenOnPick = 0
            End Try

            row.Cells("QuantityToPickColumn").Value = QuantityOpenOnPick
        Next
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

    Public Sub LoadCustomerName()
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

    Public Sub LoadSalesperson()
        cmd = New SqlCommand("SELECT DISTINCT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "ADM"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "EmployeeData")
        cboSalespersonID.DataSource = ds3.Tables("EmployeeData")
        con.Close()
        cboSalespersonID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomer2()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomerID2.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomerID2.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName2()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "CustomerList")
        cboCustomerName2.DataSource = ds5.Tables("CustomerList")
        con.Close()
        cboCustomerName2.SelectedIndex = -1
    End Sub

    Public Sub LoadShipMethod()
        cmd = New SqlCommand("SELECT ShipMethID FROM ShipMethod", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "ShipMethod")
        cboShipVia.DataSource = ds6.Tables("ShipMethod")
        con.Close()
        cboShipVia.SelectedIndex = -1
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

    Public Sub LoadCustomerID2ByName()
        Dim CustomerID2 As String = ""

        Dim CustomerID2Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID2Command As New SqlCommand(CustomerID2Statement, con)
        CustomerID2Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName2.Text
        CustomerID2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID2 = CStr(CustomerID2Command.ExecuteScalar)
        Catch ex As Exception
            CustomerID2 = ""
        End Try
        con.Close()

        cboCustomerID2.Text = CustomerID2
    End Sub

    Public Sub LoadCustomerName2ByID()
        Dim CustomerName2 As String = ""

        Dim CustomerName2Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName2Command As New SqlCommand(CustomerName2Statement, con)
        CustomerName2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID2.Text
        CustomerName2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName2 = CStr(CustomerName2Command.ExecuteScalar)
        Catch ex As Exception
            CustomerName2 = ""
        End Try
        con.Close()

        cboCustomerName2.Text = CustomerName2
    End Sub

    Public Sub LoadTruckLoadTotalsForFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboCustomerID2.Text <> "" Then
            CustomerFilter2 = " OR CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID2.Text) + "'"
        Else
            CustomerFilter2 = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustPOFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            CustPOFilter = ""
        End If
        If cboShipVia.Text <> "" Then
            ShipViaFilter = " AND ItemID = '" + cboShipVia.Text + "'"
        Else
            ShipViaFilter = ""
        End If
        If cboSalespersonID.Text <> "" Then
            SalespersonFilter = " AND SalesmanID = '" + cboSalespersonID.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            Enddate = dtpEndDate.Text

            DateFilter = " AND PickDate BETWEEN @BeginDate AND @EndDate"
        End If

        Dim TotalBoxesStatement As String = "SELECT SUM(LineBoxes) FROM PickListLineQOH WHERE PLStatus = @PLStatus AND DivisionID = @DivisionID" + CustPOFilter + CustomerFilter + CustomerFilter2 + ShipViaFilter + SalespersonFilter + DateFilter
        Dim TotalBoxesCommand As New SqlCommand(TotalBoxesStatement, con)
        TotalBoxesCommand.Parameters.Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
        TotalBoxesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalBoxesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalBoxesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = Enddate

        Dim TotalOrdersStatement As String = "SELECT COUNT(DISTINCT(PickListHeaderKey)) FROM PickListLineQOH WHERE PLStatus = @PLStatus AND DivisionID = @DivisionID" + CustPOFilter + CustomerFilter + CustomerFilter2 + ShipViaFilter + SalespersonFilter + DateFilter
        Dim TotalOrdersCommand As New SqlCommand(TotalOrdersStatement, con)
        TotalOrdersCommand.Parameters.Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
        TotalOrdersCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalOrdersCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalOrdersCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = Enddate

        Dim TotalWeightStatement As String = "SELECT SUM(LineWeight) FROM PickListLineQOH WHERE PLStatus = @PLStatus AND DivisionID = @DivisionID" + CustPOFilter + CustomerFilter + CustomerFilter2 + ShipViaFilter + SalespersonFilter + DateFilter
        Dim TotalWeightCommand As New SqlCommand(TotalWeightStatement, con)
        TotalWeightCommand.Parameters.Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
        TotalWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalWeightCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalWeightCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = Enddate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalBoxes = CInt(TotalBoxesCommand.ExecuteScalar)
        Catch ex As Exception
            TotalBoxes = 0
        End Try
        Try
            TotalOrders = CInt(TotalOrdersCommand.ExecuteScalar)
        Catch ex As Exception
            TotalOrders = 0
        End Try
        Try
            TotalWeight = CDbl(TotalWeightCommand.ExecuteScalar)
        Catch ex As Exception
            TotalWeight = 0
        End Try
        con.Close()

        TotalPallets = Val(txtTotalPallets.Text)
        TotalPalletWeight = TotalPallets * 34
        TotalWeight = Math.Round(TotalWeight, 0)

        txtTotalBoxes.Text = TotalBoxes
        txtNumberOfOrders.Text = TotalOrders
        txtTotalWeight.Text = TotalWeight + TotalPalletWeight
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboCustomerID2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID2.SelectedIndexChanged
        LoadCustomerName2ByID()
    End Sub

    Private Sub cboCustomerName2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName2.SelectedIndexChanged
        LoadCustomerID2ByName()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilter()
        LoadTruckLoadTotalsForFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        Dim QuantityOpenOnPick As Double = 0

        For Each row As DataGridViewRow In dgvPickLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectLine")
            cell.Value = "SELECTED"
        Next

        For Each row As DataGridViewRow In dgvPickLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectLine")
            If cell.Value = "SELECTED" Then

                Try
                    QuantityOpenOnPick = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    QuantityOpenOnPick = 0
                End Try

                row.Cells("QuantityToPickColumn").Value = QuantityOpenOnPick
            End If
        Next
    End Sub

    Private Sub cmdUnselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnselectAll.Click
        For Each row As DataGridViewRow In dgvPickLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectLine")
            cell.Value = "UNSELECTED"

            row.Cells("QuantityToPickColumn").Value = 0
        Next

        txtNumberOfOrders.Clear()
        txtTotalBoxes.Clear()
        txtTotalPallets.Clear()
        txtTotalWeight.Clear()
    End Sub

    Private Sub cmdReprintPicks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintPicks.Click
        If Me.dgvPickLines.RowCount <> 0 Then
            Dim PickListHeaderKey As Integer = 0
            Dim LastBatchNumber, NextBatchNumber As Integer
            Dim QuantityToPick As Integer = 0
            Dim SerialNumber As String = ""
            Dim PickListLineKey As Integer = 0
            Dim SerialQuantityComment As String = 0
            Dim strQuantityToPick As String = ""
            Dim QuantityOpen As Double = 0

            'Get new batch number and write to header table
            Dim LastBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM PickListHeaderTable"
            Dim LastBatchNumberCommand As New SqlCommand(LastBatchNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastBatchNumber = CInt(LastBatchNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastBatchNumber = 0
            End Try
            con.Close()

            NextBatchNumber = LastBatchNumber + 1

            For Each row As DataGridViewRow In dgvPickLines.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectLine")

                If cell.Value = "SELECTED" Then
                    Try
                        PickListHeaderKey = row.Cells("PickListHeaderKeyColumn").Value
                    Catch ex As Exception
                        PickListHeaderKey = 0
                    End Try
                    Try
                        PickListLineKey = row.Cells("PickListLineKeyColumn").Value
                    Catch ex As Exception
                        PickListLineKey = 0
                    End Try
                    Try
                        QuantityOpen = row.Cells("QuantityColumn").Value
                    Catch ex As Exception
                        QuantityOpen = 0
                    End Try
                    Try
                        QuantityToPick = row.Cells("QuantityToPickColumn").Value
                    Catch ex As Exception
                        QuantityToPick = 0
                    End Try
                    Try
                        SerialNumber = row.Cells("SerialNumberColumn").Value
                    Catch ex As Exception
                        SerialNumber = 0
                    End Try

                    'Write Batch Number to header table
                    cmd = New SqlCommand("UPDATE PickListHeaderTable SET BatchNumber = @BatchNumber, PickCount = @PickCount WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = PickListHeaderKey
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                    cmd.Parameters.Add("@PickCount", SqlDbType.VarChar).Value = 2

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    If QuantityOpen - QuantityToPick > 0 Then
                        strQuantityToPick = CStr(QuantityToPick)
                        SerialQuantityComment = "********** SHIP " + strQuantityToPick + " pieces of the line for this order.**********"

                        'Write Quantity Comment to serial number line
                        cmd = New SqlCommand("UPDATE PickListLineTable SET SerialNumber = @SerialNumber WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = PickListHeaderKey
                        cmd.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = PickListLineKey
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = SerialQuantityComment

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    ElseIf QuantityOpen - QuantityToPick < 0 Then
                        strQuantityToPick = CStr(QuantityToPick)
                        SerialQuantityComment = "********** OVERSHIP " + strQuantityToPick + " pieces of the line for this order.**********"

                        'Write Quantity Comment to serial number line
                        cmd = New SqlCommand("UPDATE PickListLineTable SET SerialNumber = @SerialNumber WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = PickListHeaderKey
                        cmd.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = PickListLineKey
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = SerialQuantityComment

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    ElseIf QuantityOpen - QuantityToPick = 0 Then
                        'Write Quantity Comment to serial number line
                        cmd = New SqlCommand("UPDATE PickListLineTable SET SerialNumber = @SerialNumber WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = PickListHeaderKey
                        cmd.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = PickListLineKey
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = ""

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    ElseIf QuantityOpen - QuantityToPick = QuantityOpen Then
                        SerialQuantityComment = "********** Do not PICK/SHIP this line with this order.**********"

                        'Write Quantity Comment to serial number line
                        cmd = New SqlCommand("UPDATE PickListLineTable SET SerialNumber = @SerialNumber WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = PickListHeaderKey
                        cmd.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = PickListLineKey
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = SerialQuantityComment

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                End If

                PickListHeaderKey = 0
                PickListLineKey = 0
                QuantityToPick = 0
                SerialQuantityComment = ""
                strQuantityToPick = ""
            Next

            GlobalDivisionCode = cboDivisionID.Text
            GlobalPickBatchNumber = NextBatchNumber

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
                Using NewPrintPickTicketBatchRemote As New PrintPickTicketBatchRemote
                    Dim Result = NewPrintPickTicketBatchRemote.ShowDialog
                End Using
            Else
                Using NewPrintPickTicketBatch As New PrintPickTicketBatch
                    Dim Result = NewPrintPickTicketBatch.ShowDialog
                End Using
            End If
        End If
    End Sub

    Private Sub PrintSelectedPicksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSelectedPicksToolStripMenuItem.Click
        cmdReprintPicks_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintPickQOHFiltered As New PrintPickQOHFiltered
            Dim Result = NewPrintPickQOHFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvPickLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPickLines.CellValueChanged
        If Me.dgvPickLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPickLines.CurrentCell.RowIndex
            Dim RowQuantityOpen As Double = 0
            Dim CheckSelected As String = ""
            Dim RowQuantityPicked As Double = 0

            RowQuantityPicked = Me.dgvPickLines.Rows(RowIndex).Cells("QuantityToPickColumn").Value
            CheckSelected = Me.dgvPickLines.Rows(RowIndex).Cells("SelectLine").Value

            If CheckSelected = "SELECTED" And RowQuantityPicked = 0 Then
                RowQuantityOpen = Me.dgvPickLines.Rows(RowIndex).Cells("QuantityColumn").Value
                Me.dgvPickLines.Rows(RowIndex).Cells("QuantityToPickColumn").Value = RowQuantityOpen
            ElseIf CheckSelected = "SELECTED" And RowQuantityPicked <> 0 Then
                'Skip Line
            ElseIf CheckSelected = "UNSELECTED" Then
                Me.dgvPickLines.Rows(RowIndex).Cells("QuantityToPickColumn").Value = 0
            End If
        End If

        Dim RowOpenAmount As Double = 0
        Dim RowPLLine As Integer = 0
        Dim RowPLHeader As Integer = 0
        Dim RunningLineWeight As Double = 0
        Dim RunningLineBoxes As Double = 0
        Dim RowPickCount As Double = 0
        Dim QuantityToPick As Integer = 0
        Dim QuantityOpen As Integer = 0
        Dim SalesOrderNumber As Integer = 0
        Dim OrderCount As Integer = 0
        Dim LastSalesOrderNumber As Integer = 0

        TotalBoxes = 0
        TotalOrders = 0
        TotalWeight = 0
        OrderCount = 0

        If Me.dgvPickLines.RowCount <> 0 Then
            Dim RowWeight As Double = 0
            Dim RowBoxes As Double = 0

            For Each row As DataGridViewRow In dgvPickLines.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectLine")

                If cell.Value = "SELECTED" Then
                    Try
                        RowWeight = row.Cells("LineWeightColumn").Value
                    Catch ex As Exception
                        RowWeight = 0
                    End Try
                    Try
                        RowBoxes = row.Cells("LineBoxesColumn").Value
                    Catch ex As Exception
                        RowBoxes = 0
                    End Try
                    Try
                        QuantityToPick = row.Cells("QuantityToPickColumn").Value
                    Catch ex As Exception
                        QuantityToPick = 0
                    End Try
                    Try
                        QuantityOpen = row.Cells("QuantityColumn").Value
                    Catch ex As Exception
                        QuantityOpen = 0
                    End Try
                    Try
                        SalesOrderNumber = row.Cells("SalesOrderHeaderKeyColumn").Value
                    Catch ex As Exception
                        SalesOrderNumber = 0
                    End Try

                    If QuantityToPick = -1 Then QuantityToPick = 0

                    If QuantityToPick = 0 Then
                        RunningLineWeight = RunningLineWeight + RowWeight
                        RunningLineBoxes = RunningLineBoxes + RowBoxes

                        RowWeight = 0
                        RowBoxes = 0
                    Else
                        RowWeight = (RowWeight / QuantityOpen) * QuantityToPick
                        RowBoxes = QuantityToPick / (QuantityOpen / RowBoxes)

                        RunningLineWeight = RunningLineWeight + RowWeight
                        RunningLineBoxes = RunningLineBoxes + RowBoxes

                        RowWeight = 0
                        RowBoxes = 0
                    End If

                    'Count # of Orders
                    If SalesOrderNumber = LastSalesOrderNumber Then
                        'skip
                        SalesOrderNumber = 0
                    Else
                        OrderCount = OrderCount + 1
                        LastSalesOrderNumber = SalesOrderNumber
                        SalesOrderNumber = 0
                    End If
                Else
                    'Skip
                End If
            Next

            Dim PalletCount As Integer = 0
            PalletCount = Val(txtTotalPallets.Text)

            TotalWeight = RunningLineWeight + (PalletCount * 34)
            TotalWeight = Math.Round(TotalWeight, 0)
            txtTotalWeight.Text = TotalWeight
            txtNumberOfOrders.Text = (Math.Round(OrderCount, 0))

            TotalBoxes = RunningLineBoxes
            TotalBoxes = Math.Round(TotalBoxes, 0)
            txtTotalBoxes.Text = TotalBoxes
        Else
            'Skip Update
        End If
    End Sub

    Private Sub dgvPickLines_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPickLines.CurrentCellDirtyStateChanged
        If dgvPickLines.IsCurrentCellDirty Then
            dgvPickLines.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub txtTotalPallets_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPallets.TextChanged
        Dim RowOpenAmount As Double = 0
        Dim RowPLLine As Integer = 0
        Dim RowPLHeader As Integer = 0
        Dim RunningLineWeight As Double = 0
        Dim RunningLineBoxes As Double = 0
        Dim RowPickCount As Double = 0
        Dim QuantityToPick As Integer = 0
        Dim QuantityOpen As Integer = 0
        Dim SalesOrderNumber As Integer = 0
        Dim OrderCount As Integer = 0
        Dim LastSalesOrderNumber As Integer = 0

        TotalBoxes = 0
        TotalOrders = 0
        TotalWeight = 0
        OrderCount = 0

        If Me.dgvPickLines.RowCount <> 0 Then
            Dim RowWeight As Double = 0
            Dim RowBoxes As Double = 0

            For Each row As DataGridViewRow In dgvPickLines.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectLine")

                If cell.Value = "SELECTED" Then
                    Try
                        RowWeight = row.Cells("LineWeightColumn").Value
                    Catch ex As Exception
                        RowWeight = 0
                    End Try
                    Try
                        RowBoxes = row.Cells("LineBoxesColumn").Value
                    Catch ex As Exception
                        RowBoxes = 0
                    End Try
                    Try
                        QuantityToPick = row.Cells("QuantityToPickColumn").Value
                    Catch ex As Exception
                        QuantityToPick = 0
                    End Try
                    Try
                        QuantityOpen = row.Cells("QuantityColumn").Value
                    Catch ex As Exception
                        QuantityOpen = 0
                    End Try
                    Try
                        SalesOrderNumber = row.Cells("SalesOrderHeaderKeyColumn").Value
                    Catch ex As Exception
                        SalesOrderNumber = 0
                    End Try

                    If QuantityToPick = 0 Then
                        RunningLineWeight = RunningLineWeight + RowWeight
                        RunningLineBoxes = RunningLineBoxes + RowBoxes

                        RowWeight = 0
                        RowBoxes = 0
                    Else
                        RowWeight = (RowWeight / QuantityOpen) * QuantityToPick
                        RowBoxes = QuantityToPick / (QuantityOpen / RowBoxes)

                        RunningLineWeight = RunningLineWeight + RowWeight
                        RunningLineBoxes = RunningLineBoxes + RowBoxes

                        RowWeight = 0
                        RowBoxes = 0
                    End If

                    'Count # of Orders
                    If SalesOrderNumber = LastSalesOrderNumber Then
                        'skip
                        SalesOrderNumber = 0
                    Else
                        OrderCount = OrderCount + 1
                        LastSalesOrderNumber = SalesOrderNumber
                        SalesOrderNumber = 0
                    End If
                Else
                    'Skip
                End If
            Next

            Dim PalletCount As Integer = 0
            PalletCount = Val(txtTotalPallets.Text)

            TotalWeight = RunningLineWeight + (PalletCount * 34)
            TotalWeight = Math.Round(TotalWeight, 0)
            txtTotalWeight.Text = TotalWeight
            txtNumberOfOrders.Text = (Math.Round(OrderCount, 0))

            TotalBoxes = RunningLineBoxes
            TotalBoxes = Math.Round(TotalBoxes, 0)
            txtTotalBoxes.Text = TotalBoxes
        Else
            'Skip Update
        End If
    End Sub

End Class