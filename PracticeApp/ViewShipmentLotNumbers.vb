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
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Net.Mail
Imports System.Web
Public Class ViewShipmentLotNumbers
    Inherits System.Windows.Forms.Form

    Dim ShipmentFilter, PartFilter, HeatFilter, LotFilter, CustomerFilter, CustPOFilter, DateFilter, StatusFilter, SOFilter As String
    Dim SONumber, ShipmentNumber As Integer
    Dim strSONumber, strShipmentNumber As String
    Dim setting As New My.MySettings()
    Dim BeginDate, EndDate As Date

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewShipmentLotNumbers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        LoadCurrentDivision()
        ClearVariables()
        ClearData()
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

    Public Sub ClearDataInDatagrid()
        dgvShipmentLotQuery.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        Dim ShipmentStatus As String = ""

        If cboShipStatus.Text = "OPEN" Then
            ShipmentStatus = "PENDING"
        Else
            ShipmentStatus = cboShipStatus.Text
        End If

        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboLotNumber.Text <> "" Then
            LotFilter = " AND LotNumber = '" + usefulFunctions.checkQuote(cboLotNumber.Text) + "'"
        Else
            LotFilter = ""
        End If
        If cboHeatNumber.Text <> "" Then
            HeatFilter = " AND HeatNumber = '" + usefulFunctions.checkQuote(cboHeatNumber.Text) + "'"
        Else
            HeatFilter = ""
        End If
        If cboShipStatus.Text <> "" Then
            StatusFilter = " AND ShipmentStatus = '" + ShipmentStatus + "'"
        Else
            StatusFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustPOFilter = " AND CustomerPO LIKE '%" + usefulFunctions.checkQuote(txtCustomerPO.Text) + "%'"
        Else
            CustPOFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value
            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM ShipmentLotLineQuery WHERE DivisionID = @DivisionID AND LotLineNumber <> 0" + SOFilter + CustPOFilter + CustomerFilter + StatusFilter + PartFilter + HeatFilter + LotFilter + ShipmentFilter + DateFilter + " ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentLotLineQuery")
        dgvShipmentLotQuery.DataSource = ds.Tables("ShipmentLotLineQuery")
        con.Close()
    End Sub

    Public Sub LoadCustomerList()
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

    Public Sub LoadSalesOrderNumber()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds2.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID From ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DE-ACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboPartNumber.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadLotNumber()
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "LotNumber")
        cboLotNumber.DataSource = ds4.Tables("LotNumber")
        con.Close()
        cboLotNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT HeatNumber FROM HeatNumberLog", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "HeatNumberLog")
        cboHeatNumber.DataSource = ds5.Tables("HeatNumberLog")
        con.Close()
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "ShipmentHeaderTable")
        cboShipmentNumber.DataSource = ds6.Tables("ShipmentHeaderTable")
        con.Close()
        cboShipmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "CustomerList")
        cboCustomerName.DataSource = ds7.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DE-ACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "ItemList")
        cboDescription.DataSource = ds8.Tables("ItemList")
        con.Close()
        cboDescription.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearVariables()
        ClearData()
        LoadCustomerList()
        LoadCustomerName()
        LoadLotNumber()
        LoadPartNumber()
        LoadPartDescription()
        LoadSalesOrderNumber()
        LoadShipmentNumber()
        LoadHeatNumber()
        ClearDataInDatagrid()
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
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboDescription.Text
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

        cboDescription.Text = PartDescription1
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Public Sub ClearData()
        cboDescription.Text = ""
        cboHeatNumber.Text = ""
        cboLotNumber.Text = ""
        cboPartNumber.Text = ""
        cboSalesOrderNumber.Text = ""
        cboShipmentNumber.Text = ""
        cboShipStatus.Text = ""
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""

        cboDescription.SelectedIndex = -1
        cboHeatNumber.SelectedIndex = -1
        cboLotNumber.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboShipmentNumber.SelectedIndex = -1
        cboShipStatus.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1

        txtCustomerPO.Clear()

        chkDateRange.Checked = False

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboCustomerID.Focus()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintShipmentLotNumbersFiltered As New PrintShipmentLotNumbersFiltered
            Dim result = NewPrintShipmentLotNumbersFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Public Sub ClearVariables()
        ShipmentFilter = ""
        PartFilter = ""
        HeatFilter = ""
        LotFilter = ""
        CustomerFilter = ""
        CustPOFilter = ""
        DateFilter = ""
        StatusFilter = ""
        SOFilter = ""
        SONumber = 0
        ShipmentNumber = 0
        strSONumber = ""
        strShipmentNumber = ""
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdReprintCertBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintCertBatch.Click
        Dim RowShipmentNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowCustomer As String = ""

        Dim RowIndex As Integer = Me.dgvShipmentLotQuery.CurrentCell.RowIndex

        RowDivision = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("DivisionIDColumn").Value
        RowShipmentNumber = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowCustomer = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("CustomerIDColumn").Value
        '*******************************************************************************************************************************************
        'Check to make sure at least one cert will print otherwise do not open Print Form
        Dim CheckForCerts As Integer = 0

        'Get Pull Test Number for selected Lot Number Data
        Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
        CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
        CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader2 As SqlDataReader = CheckForCertsCommand.ExecuteReader()
        If reader2.HasRows Then
            reader2.Read()
            If IsDBNull(reader2.Item("CountShipmentNumber")) Then
                CheckForCerts = 0
            Else
                CheckForCerts = reader2.Item("CountShipmentNumber")
            End If
        Else
            CheckForCerts = 0
        End If
        reader2.Close()
        con.Close()

        If CheckForCerts = 0 Then
            MsgBox("There are no certs to print. If you entered a Lot #, check the error log.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            Dim CheckForNoCerts As Integer = 0

            'Check to see if there are any certs that will not print
            Dim CheckForNoCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountNoCerts FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber = @PullTestNumber"
            Dim CheckForNoCertsCommand As New SqlCommand(CheckForNoCertsStatement, con)
            CheckForNoCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
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

            GlobalShipmentNumber = RowShipmentNumber
            GlobalDivisionCode = RowDivision
            GlobalCertCustomer = RowCustomer

            'Chose the correct Print Form (REMOTE or LOCAL)

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
                Using NewPrintTWCert01Remote As New PrintTWCert01Remote
                    Dim result = NewPrintTWCert01Remote.ShowDialog()
                End Using
            Else
                Using NewPrintTWCertBatch As New PrintTWCert01
                    Dim result = NewPrintTWCertBatch.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub cmdReprintCertSingle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintCertSingle.Click
        Dim RowShipmentNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowLotNumber As String = ""
        Dim RowCustomer As String = ""
        Dim RowHeatNumber As String = ""
        Dim RowPartNumber As String = ""

        If Me.dgvShipmentLotQuery.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentLotQuery.CurrentCell.RowIndex

            RowDivision = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("DivisionIDColumn").Value
            RowShipmentNumber = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            RowLotNumber = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("LotNumberColumn").Value
            RowCustomer = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowHeatNumber = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("HeatNumberColumn").Value
            RowPartNumber = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("PartNumberColumn").Value

            '*******************************************************************************************************************************************
            'Check to make sure at least one cert will print otherwise do not open Print Form
            Dim CheckForCerts As Integer = 0

            'Get Pull Test Number for selected Lot Number Data
            Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
            CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
            CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader2 As SqlDataReader = CheckForCertsCommand.ExecuteReader()
            If reader2.HasRows Then
                reader2.Read()
                If IsDBNull(reader2.Item("CountShipmentNumber")) Then
                    CheckForCerts = 0
                Else
                    CheckForCerts = reader2.Item("CountShipmentNumber")
                End If
            Else
                CheckForCerts = 0
            End If
            reader2.Close()
            con.Close()

            If CheckForCerts = 0 Then
                MsgBox("There are no certs to print. If you entered a Lot #, check the error log.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                Dim CheckForNoCerts As Integer = 0

                'Check to see if there are any certs that will not print
                Dim CheckForNoCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountNoCerts FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber = @PullTestNumber"
                Dim CheckForNoCertsCommand As New SqlCommand(CheckForNoCertsStatement, con)
                CheckForNoCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
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

                CertShipmentNumber = RowShipmentNumber
                GlobalDivisionCode = RowDivision
                CertLotNumber = RowLotNumber
                CertHeatNumber = RowHeatNumber
                CertCustomerID = RowCustomer
                CertPartNumber = RowPartNumber

                'Chose the correct Print Form (REMOTE or LOCAL)

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
                    Using NewPrintTWCertSingleRemote As New PrintTWCertSingleRemote
                        Dim result = NewPrintTWCertSingleRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintTWCertBatch As New PrintTWCertSingle
                        Dim result = NewPrintTWCertBatch.ShowDialog()
                    End Using
                End If
            End If
        Else
            'Skip
        End If
    End Sub

    Private Sub dgvShipmentLotQuery_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentLotQuery.CellDoubleClick
        Dim RowShipmentNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowLotNumber As String = ""
        Dim RowCustomer As String = ""
        Dim RowHeatNumber As String = ""
        Dim RowPartNumber As String = ""

        If Me.dgvShipmentLotQuery.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentLotQuery.CurrentCell.RowIndex

            RowDivision = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("DivisionIDColumn").Value
            RowShipmentNumber = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            RowLotNumber = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("LotNumberColumn").Value
            RowCustomer = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowHeatNumber = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("HeatNumberColumn").Value
            RowPartNumber = Me.dgvShipmentLotQuery.Rows(RowIndex).Cells("PartNumberColumn").Value

            '*******************************************************************************************************************************************
            'Check to make sure at least one cert will print otherwise do not open Print Form
            Dim CheckForCerts As Integer = 0

            'Get Pull Test Number for selected Lot Number Data
            Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
            CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
            CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader2 As SqlDataReader = CheckForCertsCommand.ExecuteReader()
            If reader2.HasRows Then
                reader2.Read()
                If IsDBNull(reader2.Item("CountShipmentNumber")) Then
                    CheckForCerts = 0
                Else
                    CheckForCerts = reader2.Item("CountShipmentNumber")
                End If
            Else
                CheckForCerts = 0
            End If
            reader2.Close()
            con.Close()

            If CheckForCerts = 0 Then
                MsgBox("There are no certs to print. If you entered a Lot #, check the error log.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                CertShipmentNumber = RowShipmentNumber
                GlobalDivisionCode = RowDivision
                CertLotNumber = RowLotNumber
                CertHeatNumber = RowHeatNumber
                CertCustomerID = RowCustomer
                CertPartNumber = RowPartNumber

                'Chose the correct Print Form (REMOTE or LOCAL)

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
                    Using NewPrintTWCertSingleRemote As New PrintTWCertSingleRemote
                        Dim result = NewPrintTWCertSingleRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintTWCertBatch As New PrintTWCertSingle
                        Dim result = NewPrintTWCertBatch.ShowDialog()
                    End Using
                End If
            End If
        Else
            'Skip
        End If
    End Sub
End Class