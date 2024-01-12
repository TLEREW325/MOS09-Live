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
Public Class ViewShipmentStatus
    Inherits System.Windows.Forms.Form

    Dim SalespersonFilter, ShipViaFilter, ProFilter, ShipmentFilter, PickFilter, CustomerFilter, CustPOFilter, DateFilter, StatusFilter, SOFilter As String
    Dim SONumber, ShipNumber, PickNumber As Integer
    Dim strSONumber, strPickNumber, strShipNumber As String
    Dim FreightActualAmount, FreightQuoteAmount, ProductTotal, TaxTotal, FreightTotal, ShipmentTotal As Double
    Dim ShipmentStatus, PRONumber, FreightQuoteNumber As String
    Dim BeginDate, EndDate As Date
    Dim MasterPickTicketNumber As Integer = 0

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Variables to Limit Combo Boxes to last 3 years of data
    Dim SONumberFilter As String = ""
    Dim PickTicketNumberFilter As String = ""
    Dim ShipmentNumberFilter As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim IsLoaded As Boolean

    'Setup for barcode
    Dim LabelFormat(70), V00, V01, V02, V03, V04, V05, V06, V07, V08, V09, V10, V11, V12, V13, V14, V15, V16, V17, V18, V19, V20, V21, V22, V23, V24, V25, V26, V27, V28, VDATA, VDATA1, VBAR, VBAR1 As String
    Dim LabelLines, BarCodeType, NumberOfLables As Integer
    Dim CustomerID, ShipToID, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZip, ShipCountry, ShipToName As String

    'Form Operations

    Private Sub ViewShipmentStatus_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub ShipmentStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        LoadCurrentDivision()
        LastThreeFilter.Checked = True
        AllShipmentsFilter.Checked = False

        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    'Load Data into Datsets for controls and datagrid

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
        dgvShipmentHeaders.DataSource = Nothing
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
        If txtSearchByPro.Text <> "" Then
            ProFilter = " AND PRONumber LIKE '%" + usefulFunctions.checkQuote(txtSearchByPro.Text) + "%'"
        Else
            ProFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboPickNumber.Text <> "" Then
            PickNumber = Val(cboPickNumber.Text)
            strPickNumber = CStr(PickNumber)
            PickFilter = " AND PickTicketNumber = '" + strPickNumber + "'"
        Else
            PickFilter = ""
        End If
        If cboShipmentNumber2.Text <> "" Then
            ShipNumber = Val(cboShipmentNumber2.Text)
            strShipNumber = CStr(ShipNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If txtShipViaSearch.Text <> "" Then
            ShipViaFilter = " AND ShipVia LIKE '%" + txtShipViaSearch.Text + "%'"
        Else
            ShipViaFilter = ""
        End If
        If cboSalesPerson.Text <> "" Then
            SalespersonFilter = " AND SalesmanID = '" + cboSalesPerson.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            If AllShipmentsFilter.Checked = True Then
                DateFilter = ""
            ElseIf LastThreeFilter.Checked = True Then
                DateFilter = " AND ShipDate >= '1/1/2020'"
            Else
                DateFilter = ""
            End If
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID <> @DivisionID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " ORDER BY DivisionID, ShipmentNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvShipmentHeaders.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()
            Me.dgvShipmentHeaders.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvShipmentHeaders.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()
            Me.dgvShipmentHeaders.Columns("DivisionIDColumn").Visible = False
        End If

        LoadFormatting()
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
        If AllShipmentsFilter.Checked = True Then
            SONumberFilter = ""
        ElseIf LastThreeFilter.Checked = True Then
            SONumberFilter = " AND SalesOrderDate >= '1/1/2020'"
        Else
            SONumberFilter = ""
        End If

        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable where DivisionKey = @DivisionKey AND SOStatus <> 'QUOTE'" + SONumberFilter + " ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds2.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomerName.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        If AllShipmentsFilter.Checked = True Then
            ShipmentNumberFilter = ""
        ElseIf LastThreeFilter.Checked = True Then
            ShipmentNumberFilter = " AND ShipDate >= '1/1/2020'"
        Else
            ShipmentNumberFilter = ""
        End If

        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable where DivisionID = @DivisionID" + ShipmentNumberFilter + " ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ShipmentHeaderTable")
        cboShipmentNumber2.DataSource = ds4.Tables("ShipmentHeaderTable")
        con.Close()
        cboShipmentNumber2.SelectedIndex = -1
    End Sub

    Public Sub LoadPickNumber()
        If AllShipmentsFilter.Checked = True Then
            PickTicketNumberFilter = ""
        ElseIf LastThreeFilter.Checked = True Then
            PickTicketNumberFilter = " AND PickDate >= '1/1/2020'"
        Else
            PickTicketNumberFilter = ""
        End If

        cmd = New SqlCommand("SELECT PickListHeaderKey FROM PickListHeaderTable where DivisionID = @DivisionID" + PickTicketNumberFilter + " ORDER BY PickListHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "PickListHeaderTable")
        cboPickNumber.DataSource = ds5.Tables("PickListHeaderTable")
        con.Close()
        cboPickNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesperson()
        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            cmd = New SqlCommand("SELECT SalesPersonID FROM EmployeeData WHERE (DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'ADM') AND SalesPersonID <> '' AND EmployeeStatus <> 'CLOSED' ORDER BY SalesPersonID", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "EmployeeData")
            cboSalesPerson.DataSource = ds6.Tables("EmployeeData")
            con.Close()
            cboSalesPerson.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey AND SalesPersonID <> '' AND EmployeeStatus <> 'CLOSED' ORDER BY SalesPersonID", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds6 = New DataSet()
            myAdapter6.SelectCommand = cmd
            myAdapter6.Fill(ds6, "EmployeeData")
            cboSalesPerson.DataSource = ds6.Tables("EmployeeData")
            con.Close()
            cboSalesPerson.SelectedIndex = -1
        End If
    End Sub

    'Load data subroutines

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

    Public Sub LoadFreightDetails()
        'Extract Shipment Data to update 
        Dim PRONumberStatement As String = "SELECT PRONumber FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim PRONumberCommand As New SqlCommand(PRONumberStatement, con)
        PRONumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
        PRONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim FreightQuoteNumberStatement As String = "SELECT FreightQuoteNumber FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim FreightQuoteNumberCommand As New SqlCommand(FreightQuoteNumberStatement, con)
        FreightQuoteNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
        FreightQuoteNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim FreightQuoteAmountStatement As String = "SELECT FreightQuoteAmount FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim FreightQuoteAmountCommand As New SqlCommand(FreightQuoteAmountStatement, con)
        FreightQuoteAmountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
        FreightQuoteAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim FreightActualAmountStatement As String = "SELECT FreightActualAmount FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim FreightActualAmountCommand As New SqlCommand(FreightActualAmountStatement, con)
        FreightActualAmountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
        FreightActualAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipmentStatusCommand As New SqlCommand(ShipmentStatusStatement, con)
        ShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
        ShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PRONumber = CStr(PRONumberCommand.ExecuteScalar)
        Catch ex As Exception
            PRONumber = ""
        End Try
        Try
            FreightQuoteNumber = CStr(FreightQuoteNumberCommand.ExecuteScalar)
        Catch ex As Exception
            FreightQuoteNumber = ""
        End Try
        Try
            FreightQuoteAmount = CDbl(FreightQuoteAmountCommand.ExecuteScalar)
        Catch ex As Exception
            FreightQuoteAmount = 0
        End Try
        Try
            FreightActualAmount = CDbl(FreightActualAmountCommand.ExecuteScalar)
        Catch ex As Exception
            FreightActualAmount = 0
        End Try
        Try
            ShipmentStatus = CStr(ShipmentStatusCommand.ExecuteScalar)
        Catch ex As Exception
            ShipmentStatus = ""
        End Try
        con.Close()

        txtFreight.Text = FreightActualAmount
        txtPRONumber.Text = PRONumber
        txtQuotedFreight.Text = FreightQuoteAmount
        txtQuoteReferenceNumber.Text = FreightQuoteNumber

        If ShipmentStatus = "INVOICED" Then
            txtFreight.Enabled = False
        Else
            txtFreight.Enabled = True
        End If
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

    Private Sub ShipToAddress()
        Dim CustomerIDStatement As String = "SELECT CustomerID FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim CustomerIDCommand As New SqlCommand(CustomerIDStatement, con)
        CustomerIDCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvShipmentHeaders.CurrentRow.Cells("ShipmentNumberColumn").Value
        CustomerIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToIDStatement As String = "SELECT ShipToID FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipToIDCommand As New SqlCommand(ShipToIDStatement, con)
        ShipToIDCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvShipmentHeaders.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipToIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipAddress1Statement As String = "SELECT ShipAddress1 FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipAddress1Command As New SqlCommand(ShipAddress1Statement, con)
        ShipAddress1Command.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvShipmentHeaders.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipAddress2Statement As String = "SELECT ShipAddress2 FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipAddress2Command As New SqlCommand(ShipAddress2Statement, con)
        ShipAddress2Command.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvShipmentHeaders.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipCityStatement As String = "SELECT ShipCity FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipCityCommand As New SqlCommand(ShipCityStatement, con)
        ShipCityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvShipmentHeaders.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipStateStatement As String = "SELECT ShipState FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipStateCommand As New SqlCommand(ShipStateStatement, con)
        ShipStateCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvShipmentHeaders.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipZipStatement As String = "SELECT ShipZip FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipZipCommand As New SqlCommand(ShipZipStatement, con)
        ShipZipCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvShipmentHeaders.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipCountryStatement As String = "SELECT ShipCountry FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipCountryCommand As New SqlCommand(ShipCountryStatement, con)
        ShipCountryCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvShipmentHeaders.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID = CStr(CustomerIDCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerID = ""
        End Try
        Try
            ShipToID = CStr(ShipToIDCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToID = ""
        End Try
        Try
            ShipAddress1 = CStr(ShipAddress1Command.ExecuteScalar)
        Catch ex As Exception
            ShipAddress1 = ""
        End Try
        Try
            ShipAddress2 = CStr(ShipAddress2Command.ExecuteScalar)
        Catch ex As Exception
            ShipAddress2 = ""
        End Try
        Try
            ShipCity = CStr(ShipCityCommand.ExecuteScalar)
        Catch ex As Exception
            ShipCity = ""
        End Try
        Try
            ShipState = CStr(ShipStateCommand.ExecuteScalar)
        Catch ex As Exception
            ShipState = ""
        End Try
        Try
            ShipCountry = CStr(ShipCountryCommand.ExecuteScalar)
        Catch ex As Exception
            ShipCountry = ""
        End Try
        Try
            ShipZip = CStr(ShipZipCommand.ExecuteScalar)
        Catch ex As Exception
            ShipZip = ""
        End Try
        con.Close()

        If ShipToID = "" Then
            Dim CustomerNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID and DivisionID = @DivisionID"
            Dim CustomerNameCommand As New SqlCommand(CustomerNameStatement, con)
            CustomerNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
            CustomerNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ShipToName = CStr(CustomerNameCommand.ExecuteScalar)
            Catch ex As Exception
                ShipToName = ""
            End Try
            con.Close()
        Else
            Dim ShipToNameStatement As String = "SELECT Name FROM AdditionalShipTo WHERE ShipToID = @ShipToID and CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim ShipToNameCommand As New SqlCommand(ShipToNameStatement, con)
            ShipToNameCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = ShipToID
            ShipToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
            ShipToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ShipToName = CStr(ShipToNameCommand.ExecuteScalar)
            Catch ex As Exception
                ShipToName = ""
            End Try
            con.Close()
        End If
    End Sub

    Public Sub LoadUpdateQOH()
        Try
            Dim CountPickLines As Integer = 0
            Dim QOHPartNumber As String = ""
            Dim PickQOH As Double = 0
            Dim Counter As Integer = 0

            'Count Lines in PickListLineTable for selected Pick Ticket
            Dim CountPickLinesStatement As String = "SELECT COUNT(PickListHeaderKey) FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
            Dim CountPickLinesCommand As New SqlCommand(CountPickLinesStatement, con)
            CountPickLinesCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = MasterPickTicketNumber
            CountPickLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountPickLines = CInt(CountPickLinesCommand.ExecuteScalar)
            Catch ex As Exception
                CountPickLines = 0
            End Try
            con.Close()

            'Set Counter
            Counter = 1

            'Run FOR/NEXT Loop for each line to update QOH
            For i As Integer = 1 To CountPickLines
                'Get Part Number from Pick Ticket
                Dim GetPartNumberStatement As String = "SELECT ItemID FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID AND PickListLineKey = @PickListLineKey"
                Dim GetPartNumberCommand As New SqlCommand(GetPartNumberStatement, con)
                GetPartNumberCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = MasterPickTicketNumber
                GetPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetPartNumberCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = Counter

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    QOHPartNumber = CStr(GetPartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    QOHPartNumber = ""
                End Try
                con.Close()

                Dim GetQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetQOHCommand As New SqlCommand(GetQOHStatement, con)
                GetQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = QOHPartNumber
                GetQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PickQOH = CDbl(GetQOHCommand.ExecuteScalar)
                Catch ex As Exception
                    PickQOH = 0
                End Try
                con.Close()

                'Update PickList
                cmd = New SqlCommand("UPDATE PickListLineTable SET QOH = @QOH WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = MasterPickTicketNumber
                    .Add("@PickListLineKey", SqlDbType.VarChar).Value = Counter
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@QOH", SqlDbType.VarChar).Value = PickQOH
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Counter = Counter + 1
            Next

            PickQOH = 0
            CountPickLines = 0
            Counter = 0
            QOHPartNumber = ""
        Catch ex As Exception
            'Log error on update failure
            Dim TempPickNumber As Integer = 0
            Dim strPickNumber As String
            TempPickNumber = MasterPickTicketNumber
            strPickNumber = CStr(TempPickNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "View Pick Listing --- Update Pick QOH Failure"
            ErrorReferenceNumber = "Pick Ticket # " + strPickNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    'Command Buttons

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        cmdViewUploadedPickTicket.Enabled = False
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClearPRONumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearPRONumber.Click
        txtShipmentNumber.Clear()
        txtQuotedFreight.Clear()
        txtQuoteReferenceNumber.Clear()
        txtFreight.Clear()
        txtPRONumber.Clear()
    End Sub

    Private Sub cmdEnterPRONumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterPRONumber.Click
        'Check Shipment Status - if Shipment has been invoiced, you cannot add freight
        Dim ShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipmentStatusCommand As New SqlCommand(ShipmentStatusStatement, con)
        ShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
        ShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ProductTotalStatement As String = "SELECT ProductTotal FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TaxTotalStatement As String = "SELECT TaxTotal FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim TaxTotalCommand As New SqlCommand(TaxTotalStatement, con)
        TaxTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
        TaxTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShipmentStatus = CStr(ShipmentStatusCommand.ExecuteScalar)
        Catch ex As Exception
            ShipmentStatus = "SHIPPED"
        End Try
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            TaxTotal = CDbl(TaxTotalCommand.ExecuteScalar)
        Catch ex As Exception
            TaxTotal = 0
        End Try
        con.Close()
        '*******************************************************************************************************************************************
        If Val(txtFreight.Text) > 10000 Then
            MsgBox("Freight billed cannot be greater than $10,000.00. Check number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*****************************************************************************************************************************************
        'If Status is Invoiced, add PRO Number, Freight Quote, and Quoted Amount
        If ShipmentStatus = "INVOICED" Then
            Try
                If txtQuotedFreight.Text <> "" Then
                    'UPDATE Shipment Header Table
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET FreightQuoteAmount = @FreightQuoteAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtQuotedFreight.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                If txtQuoteReferenceNumber.Text <> "" Then
                    'UPDATE Shipment Header Table
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET FreightQuoteNumber = @FreightQuoteNumber WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtQuoteReferenceNumber.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                If txtPRONumber.Text <> "" Then
                    'UPDATE Shipment Header Table
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET PRONumber = @PRONumber WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'UPDATE Invoice Table with PRO Numbers
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PRONumber = @PRONumber WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Catch ex As Exception
                'Cannot write to one or more table
            End Try
        Else
            Try
                If txtQuotedFreight.Text <> "" Then
                    'UPDATE Shipment Header Table
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET FreightQuoteAmount = @FreightQuoteAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtQuotedFreight.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                If txtQuoteReferenceNumber.Text <> "" Then
                    'UPDATE Shipment Header Table
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET FreightQuoteNumber = @FreightQuoteNumber WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtQuoteReferenceNumber.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                If txtPRONumber.Text <> "" Then
                    'UPDATE Shipment Header Table
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET PRONumber = @PRONumber WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                If txtFreight.Text <> "" Then
                    'UPDATE Shipment Header Table
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET FreightActualAmount = @FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'UPDATE Shipment Total
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentTotal = ProductTotal + TaxTotal + Tax2Total + Tax3Total + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(txtShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Catch ex As Exception
                'Cannot write to one or more table
            End Try
        End If

        LoadCustomerList()
        ClearData()
        ShowDataByFilters()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
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
            Using NewPrintShipmentConfirmation As New PrintShipmentStatusFilteredRemote
                Dim result = NewPrintShipmentConfirmation.ShowDialog()
            End Using
        Else
            Using NewPrintShipmentConfirmation As New PrintShipmentStatusFiltered
                Dim result = NewPrintShipmentConfirmation.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdReprintPackList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintPackList.Click
        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowCustomer As String = ""

        If Me.dgvShipmentHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex

            RowShipNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            RowCustomer = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowDivision = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value

            'Auto-print certs based on the line items
            GlobalShipmentNumber = RowShipNumber
            GlobalCertCustomer = RowCustomer
            GlobalDivisionCode = RowDivision

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
                Using NewPrintPackingListRemote As New PrintPackingListRemote
                    Dim result = NewPrintPackingListRemote.ShowDialog()
                End Using
            Else
                Using NewPrintPackingList As New PrintPackingList
                    Dim Result = NewPrintPackingList.ShowDialog()
                End Using
            End If
        Else
            'skip
        End If
    End Sub

    Private Sub cmdReprintBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintBOL.Click
        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowCustomer As String = ""

        If Me.dgvShipmentHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex

            RowShipNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            RowCustomer = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowDivision = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value

            'Auto-print certs based on the line items
            GlobalShipmentNumber = RowShipNumber
            GlobalCertCustomer = RowCustomer
            GlobalDivisionCode = RowDivision

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
                Using NewPrintBOLRemote As New PrintBOLRemote
                    Dim Result = NewPrintBOLRemote.ShowDialog()
                End Using
            Else
                Using NewPrintBOL As New PrintBOL
                    Dim Result = NewPrintBOL.ShowDialog()
                End Using
            End If
        Else
            'Skip
        End If
    End Sub

    Private Sub cmdReprintCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintCert.Click
        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowCustomer As String = ""

        If Me.dgvShipmentHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex

            RowShipNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            RowCustomer = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowDivision = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value

            'Auto-print certs based on the line items
            GlobalShipmentNumber = RowShipNumber
            GlobalCertCustomer = RowCustomer
            GlobalDivisionCode = RowDivision
            '*******************************************************************************************************************************************
            'Check to make sure at least one cert will print otherwise do not open Print Form
            Dim CheckForCerts As Integer = 0

            'Get Pull Test Number for selected Lot Number Data
            Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
            CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipNumber
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
                    Using NewPrintTWCert01 As New PrintTWCert01
                        Dim result = NewPrintTWCert01.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub cmdPrintConfirmation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintConfirmation.Click
        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowCustomer As String = ""

        Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex

        RowShipNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowCustomer = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("CustomerIDColumn").Value
        RowDivision = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value

        'Auto-print certs based on the line items
        GlobalShipmentNumber = RowShipNumber
        GlobalCertCustomer = RowCustomer
        GlobalDivisionCode = RowDivision

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
            Using NewPrintShipmentConfirmationRemote As New PrintShipmentConfirmationRemote
                Dim Result = NewPrintShipmentConfirmationRemote.ShowDialog()
            End Using
        Else
            Using NewPrintShipmentConfirmation As New PrintShipmentConfirmation
                Dim Result = NewPrintShipmentConfirmation.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdReprintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintAll.Click
        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowCustomer As String = ""

        Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex

        RowShipNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowCustomer = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("CustomerIDColumn").Value
        RowDivision = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value

        'Auto-print certs based on the line items
        GlobalShipmentNumber = RowShipNumber
        GlobalCertCustomer = RowCustomer
        GlobalDivisionCode = RowDivision

        Using NewPrintAllShippingDocs As New PrintAllShippingDocs
            Dim Result = NewPrintAllShippingDocs.ShowDialog()
        End Using
    End Sub

    Private Sub cmdReprintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintLabel.Click
        If dgvShipmentHeaders.Rows.Count <> 0 Then
            If dgvShipmentHeaders.CurrentRow IsNot Nothing Then
                Dim bc As New BarcodeLabel
                Dim ship As New BarcodeLabel.shippingPallet
                ShipToAddress()
                InitializeBarcodeVariables()
                FillBarCodeVariables(ship)
                ''AddressLabelSetup()
                ''LabelFormat(LabelLines) = "P1"
                bc.shippingPalletLabel(ship)
                bc.PrintBarcodeLine()
                ''PrintBarcodeLine()
                InitializeBarcodeVariables()
            End If
        End If
    End Sub

    Private Sub cmdViewUploadedPickTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewUploadedPickTicket.Click
        Dim UploadedShipmentNumber As String = ""
        Dim ShipmentFilename As String = ""
        Dim ShipmentFilenameAndPath As String = ""

        If Me.dgvShipmentHeaders.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex

            GlobalShipmentNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value

            UploadedShipmentNumber = CStr(GlobalShipmentNumber)
            ShipmentFilename = UploadedShipmentNumber + ".pdf"
            ShipmentFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + ShipmentFilename

            If File.Exists(ShipmentFilenameAndPath) Then
                System.Diagnostics.Process.Start(ShipmentFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        End If

        'Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex

        'GlobalShipmentNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        'GlobalCertCustomer = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("CustomerIDColumn").Value

        'Dim dir As New System.IO.DirectoryInfo("\\TFP-FS\TransferData\Uploaded Pick Tickets")
        'If dir.GetFiles(dgvShipmentHeaders.Rows(dgvShipmentHeaders.SelectedCells(0).RowIndex).Cells("ShipmentNumberColumn").Value.ToString + ".pdf").Length = 0 Then
        '    cmdViewUploadedPickTicket.Enabled = False
        'Else
        '    Dim fls As System.IO.FileInfo() = dir.GetFiles(dgvShipmentHeaders.Rows(dgvShipmentHeaders.SelectedCells(0).RowIndex).Cells("ShipmentNumberColumn").Value.ToString + ".pdf")
        '    GlobalUploadedPickTicket = CStr(dgvShipmentHeaders.Rows(dgvShipmentHeaders.SelectedCells(0).RowIndex).Cells("ShipmentNumberColumn").Value)
        '    If fls.Length > 0 Then
        '        Dim newPrintUploadedPickTickets As New PrintUploadedPickTicket(fls(0).FullName)
        '        newPrintUploadedPickTickets.ShowDialog()
        '    Else
        '        cmdViewUploadedPickTicket.Enabled = False
        '    End If
        'End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdEmailAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmailAll.Click
        Dim LineShipmentNumber As Integer
        Dim RowDivision, RowCustomer As String

        If Me.dgvShipmentHeaders.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex

            LineShipmentNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            RowDivision = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value
            RowCustomer = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("CustomerIDColumn").Value

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

            EmailShipmentNumber = LineShipmentNumber
            GlobalDivisionCode = RowDivision
            EmailCustomerEmailAddress = EmailAddress

            Using NewEmailAllShippingDocs As New EmailAllShippingDocs
                Dim Result = NewEmailAllShippingDocs.ShowDialog()
            End Using
        Else
            'Do nothing
        End If
    End Sub

    'Menu strip items

    Private Sub PrintMultiplePacklToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintMultiplePacklToolStripMenuItem.Click
        'Get new Batch Number
        Dim NewBatchNumber As Integer = 0
        Dim LastBatchNumber As Integer = 0
        Dim SelectedShipment As Integer = 0

        Dim LastBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM ShipmentHeaderTable"
        Dim LastBatchNumberCommand As New SqlCommand(LastBatchNumberStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(LastBatchNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 0
        End Try
        con.Close()

        NewBatchNumber = LastBatchNumber + 1

        'Update selected lines to the new batch number

        For Each row As DataGridViewRow In Me.dgvShipmentHeaders.SelectedRows
            Try
                SelectedShipment = row.Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                SelectedShipment = 0
            End Try

            'Write Data to Invoice Header Database Table
            cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET BatchNumber = @BatchNumber WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = SelectedShipment
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchNumber", SqlDbType.VarChar).Value = NewBatchNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next

        GlobalShipmentPrintType = "PRINT MULTIPLE"
        GlobalShipmentBatchNumber = NewBatchNumber
        GlobalDivisionCode = cboDivisionID.Text

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
            Using NewPrintPackingListRemote As New PrintPackingListRemote
                Dim Result = NewPrintPackingListRemote.ShowDialog()
            End Using
        Else
            Using NewPrintPackingList As New PrintPackingList
                Dim Result = NewPrintPackingList.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub PrintMultipleBOLsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintMultipleBOLsToolStripMenuItem.Click
        'Get new Batch Number
        Dim NewBatchNumber As Integer = 0
        Dim LastBatchNumber As Integer = 0
        Dim SelectedShipment As Integer = 0

        Dim LastBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM ShipmentHeaderTable"
        Dim LastBatchNumberCommand As New SqlCommand(LastBatchNumberStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(LastBatchNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 0
        End Try
        con.Close()

        NewBatchNumber = LastBatchNumber + 1

        'Update selected lines to the new batch number

        For Each row As DataGridViewRow In Me.dgvShipmentHeaders.SelectedRows
            Try
                SelectedShipment = row.Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                SelectedShipment = 0
            End Try

            'Write Data to Invoice Header Database Table
            cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET BatchNumber = @BatchNumber WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = SelectedShipment
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchNumber", SqlDbType.VarChar).Value = NewBatchNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next

        GlobalShipmentPrintType = "PRINT MULTIPLE"
        GlobalShipmentBatchNumber = NewBatchNumber
        GlobalDivisionCode = cboDivisionID.Text

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
            Using NewPrintBOLRemote As New PrintBOLRemote
                Dim Result = NewPrintBOLRemote.ShowDialog()
            End Using
        Else
            Using NewPrintBOL As New PrintBOL
                Dim Result = NewPrintBOL.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub PrintFedexBOLTodayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintFedexBOLTodayToolStripMenuItem.Click
        GlobalShipmentPrintType = "PRINT FEDEX"
        GlobalShipmentDate = dtpBeginDate.Value
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
            Using NewPrintBOLRemote As New PrintBOLRemote
                Dim Result = NewPrintBOLRemote.ShowDialog()
            End Using
        Else
            Using NewPrintBOL As New PrintBOL
                Dim Result = NewPrintBOL.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub PrintPickTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPickTicketToolStripMenuItem.Click
        If dgvShipmentHeaders.RowCount <> 0 Then
            Dim RowPLNumber As Integer
            Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex

            RowPLNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("PickTicketNumberColumn").Value

            GlobalPickListNumber = RowPLNumber
            GlobalDivisionCode = cboDivisionID.Text

            MasterPickTicketNumber = GlobalPickListNumber
            LoadUpdateQOH()

            'Update PickList for a reprint
            cmd = New SqlCommand("UPDATE PickListHeaderTable SET PickCount = @PickCount WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GlobalPickListNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@PickCount", SqlDbType.VarChar).Value = 2
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

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
                Using NewReprintPickListRemote As New ReprintPickListRemote
                    Dim Result = NewReprintPickListRemote.ShowDialog()
                End Using
            Else
                Using NewReprintPickList As New ReprintPickList
                    Dim result = NewReprintPickList.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintShipmentMarginReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintShipmentMarginReportToolStripMenuItem.Click
        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowCustomer As String = ""

        Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex

        RowShipNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowCustomer = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("CustomerIDColumn").Value
        RowDivision = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value

        'Auto-print certs based on the line items
        GlobalShipmentNumber = RowShipNumber
        GlobalCertCustomer = RowCustomer
        GlobalDivisionCode = RowDivision

        Using NewPrintShipmentMargin As New PrintShipmentMargin
            Dim Result = NewPrintShipmentMargin.ShowDialog()
        End Using
    End Sub

    'Datagrid Events

    Private Sub dgvShipmentHeaders_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentHeaders.CellDoubleClick
        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""

        Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex

        RowShipNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowDivision = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value

        GlobalShipmentNumber = RowShipNumber

        If cboDivisionID.Text = "ADM" Then
            GlobalDivisionCode = RowDivision
        Else
            GlobalDivisionCode = cboDivisionID.Text
        End If

        GlobalShipmentPrintType = ""
        GlobalCompleteShipment = ""

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
            Using NewPrintPackingListRemote As New PrintPackingListRemote
                Dim Result = NewPrintPackingListRemote.ShowDialog()
            End Using
        Else
            Using NewPrintPackingList As New PrintPackingList
                Dim Result = NewPrintPackingList.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvShipmentHeaders_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentHeaders.CellValueChanged
        If dgvShipmentHeaders.RowCount <> 0 Then
            Dim ShipmentStatus, DivisionID, ShippingMethod, FreightQuoteNumber, ShipVia, PRONumber, CustomerPO, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZip, ShipCountry, SpecialInstructions, SalesmanID, Comment As String
            Dim ShipmentNumber, NumberOfPallets, NumberOfDoubleStackedPallets, NumberOfPalletsOnFloor As Integer
            Dim ShippingWeight, FreightQuoteAmount As Double

            Dim RowIndex As Integer = Me.dgvShipmentHeaders.CurrentCell.RowIndex
            Try
                ShipmentNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                ShipmentNumber = 0
            End Try
            Try
                DivisionID = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                DivisionID = ""
            End Try
            Try
                Comment = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("CommentColumn").Value
            Catch ex As Exception
                Comment = ""
            End Try
            Try
                ShipVia = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipViaColumn").Value
            Catch ex As Exception
                ShipVia = ""
            End Try
            Try
                PRONumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("PRONumberColumn").Value
            Catch ex As Exception
                PRONumber = ""
            End Try
            Try
                FreightQuoteNumber = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("FreightQuoteNumberColumn").Value
            Catch ex As Exception
                FreightQuoteNumber = ""
            End Try
            Try
                FreightQuoteAmount = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("FreightQuoteAmountColumn").Value
            Catch ex As Exception
                FreightQuoteAmount = 0
            End Try
            Try
                ShippingWeight = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShippingWeightColumn").Value
            Catch ex As Exception
                ShippingWeight = 0
            End Try
            Try
                NumberOfPallets = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("NumberOfPalletsColumn").Value
            Catch ex As Exception
                NumberOfPallets = 0
            End Try
            Try
                NumberOfDoubleStackedPallets = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("DoubleStackedPalletsColumn").Value
            Catch ex As Exception
                NumberOfDoubleStackedPallets = 0
            End Try
            Try
                ShipAddress1 = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipAddress1Column").Value
            Catch ex As Exception
                ShipAddress1 = ""
            End Try
            Try
                ShipAddress2 = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipAddress2Column").Value
            Catch ex As Exception
                ShipAddress2 = ""
            End Try
            Try
                ShipCity = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipCityColumn").Value
            Catch ex As Exception
                ShipCity = ""
            End Try
            Try
                ShipState = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipStateColumn").Value
            Catch ex As Exception
                ShipState = ""
            End Try
            Try
                ShipZip = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipZipColumn").Value
            Catch ex As Exception
                ShipZip = ""
            End Try
            Try
                ShipCountry = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipCountryColumn").Value
            Catch ex As Exception
                ShipCountry = ""
            End Try
            Try
                CustomerPO = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("CustomerPOColumn").Value
            Catch ex As Exception
                CustomerPO = ""
            End Try
            Try
                SpecialInstructions = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("SpecialInstructionsColumn").Value
            Catch ex As Exception
                SpecialInstructions = ""
            End Try
            Try
                SalesmanID = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("SalesmanIDColumn").Value
            Catch ex As Exception
                SalesmanID = ""
            End Try
            Try
                ShippingMethod = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShippingMethodColumn").Value
            Catch ex As Exception
                ShippingMethod = ""
            End Try
            Try
                ShipmentStatus = Me.dgvShipmentHeaders.Rows(RowIndex).Cells("ShipmentStatusColumn").Value
            Catch ex As Exception
                ShipmentStatus = ""
            End Try

            If ShipmentNumber = 0 Then
                'Skip
            Else
                NumberOfPalletsOnFloor = NumberOfPallets - NumberOfDoubleStackedPallets
                Me.dgvShipmentHeaders.Rows(RowIndex).Cells("PalletsOnFloorColumn").Value = NumberOfPalletsOnFloor

                'UPDATE Shipment Header Table
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET Comment = @Comment, ShipVia = @ShipVia, PRONumber = @PRONumber, FreightQuoteNumber = @FreightQuoteNumber, FreightQuoteAmount = @FreightQuoteAmount, ShippingWeight = @ShippingWeight, NumberOfPallets = @NumberOfPallets, DoubleStackedPallets = @DoubleStackedPallets, PalletsOnFloor = @PalletsOnFloor, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZip = @ShipZip, ShipCountry = @ShipCountry, CustomerPO = @CustomerPO, SpecialInstructions = @SpecialInstructions, SalesmanID = @SalesmanID, ShippingMethod = @ShippingMethod WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                    .Add("@Comment", SqlDbType.VarChar).Value = Comment
                    .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                    .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                    .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = FreightQuoteNumber
                    .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = FreightQuoteAmount
                    .Add("@ShippingWeight", SqlDbType.VarChar).Value = ShippingWeight
                    .Add("@NumberOfPallets", SqlDbType.VarChar).Value = NumberOfPallets
                    .Add("@DoubleStackedPallets", SqlDbType.VarChar).Value = NumberOfDoubleStackedPallets
                    .Add("@PalletsOnFloor", SqlDbType.VarChar).Value = NumberOfPalletsOnFloor
                    .Add("@ShipAddress1", SqlDbType.VarChar).Value = ShipAddress1
                    .Add("@ShipAddress2", SqlDbType.VarChar).Value = ShipAddress2
                    .Add("@ShipCity", SqlDbType.VarChar).Value = ShipCity
                    .Add("@ShipState", SqlDbType.VarChar).Value = ShipState
                    .Add("@ShipZip", SqlDbType.VarChar).Value = ShipZip
                    .Add("@ShipCountry", SqlDbType.VarChar).Value = ShipCountry
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                    .Add("@SalesmanID", SqlDbType.VarChar).Value = SalesmanID
                    .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShippingMethod
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Update Invoice with changes on the shipment
                If ShipmentStatus = "INVOICED" Then
                    Dim ProNumberString As String = ""
                    Dim CustomerPOString As String = ""

                    'Check which fields to update
                    If PRONumber = "" Then
                        ProNumberString = ""
                    Else
                        ProNumberString = ", PRONumber = @PRONumber"
                    End If
                    If CustomerPO = "" Then
                        CustomerPOString = ""
                    Else
                        CustomerPOString = ", CustomerPO = @CustomerPO"
                    End If

                    'Write to invoice
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET ShipVia = @ShipVia, ShippingMethod = @ShippingMethod" + CustomerPOString + ProNumberString + " WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShippingMethod
                        .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                        .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub dgvShipmentHeaders_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvShipmentHeaders.ColumnHeaderMouseClick
        LoadFormatting()
    End Sub

    Private Sub dgvShipmentHeaders_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvShipmentHeaders.SelectionChanged
        If dgvShipmentHeaders.SelectedCells.Count > 0 AndAlso dgvShipmentHeaders.SelectedCells(0).RowIndex > -1 Then
            Dim dir As New System.IO.DirectoryInfo("\\TFP-FS\TransferData\UploadedPickTickets")
            If dir.GetFiles(dgvShipmentHeaders.Rows(dgvShipmentHeaders.SelectedCells(0).RowIndex).Cells("ShipmentNumberColumn").Value.ToString + ".pdf").Length = 0 Then
                cmdViewUploadedPickTicket.Enabled = False
            Else
                cmdViewUploadedPickTicket.Enabled = True
            End If
        End If
    End Sub

    'Combo Box Events

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        If cboDivisionID.Text = "" Then
            'Do nothing
        Else
            LoadCustomerList()
            LoadCustomerName()
            LoadSalesOrderNumber()
            LoadPickNumber()
            LoadShipmentNumber()
            LoadSalesperson()
        End If
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If cboCustomerID.Text = "" Then
            'Do nothing
        Else
            LoadCustomerNameByID()
        End If
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        If cboCustomerName.Text = "" Then
            'Do nothing
        Else
            LoadCustomerIDByName()
        End If
    End Sub

    'Text Box Events

    Private Sub txtShipmentNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShipmentNumber.TextChanged
        If txtShipmentNumber.Text = "" Then
            'Do nothing
        Else
            LoadFreightDetails()
        End If
    End Sub

    'Clear / Validation / Formatting

    Public Sub ClearData()
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboSalesOrderNumber.Text = ""
        cboShipStatus.Text = ""
        cboShipmentNumber2.Text = ""
        cboPickNumber.Text = ""
        cboSalesPerson.Text = ""

        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboShipStatus.SelectedIndex = -1
        cboShipmentNumber2.SelectedIndex = -1
        cboPickNumber.SelectedIndex = -1
        cboSalesPerson.SelectedIndex = -1

        txtCustomerPO.Clear()
        txtPRONumber.Clear()
        txtFreight.Clear()
        txtQuotedFreight.Clear()
        txtQuoteReferenceNumber.Clear()
        txtShipmentNumber.Clear()
        txtSearchByPro.Clear()
        txtShipViaSearch.Clear()

        GlobalShipmentNumber = 0

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        CustomerFilter = ""
        CustPOFilter = ""
        DateFilter = ""
        StatusFilter = ""
        ShipmentFilter = ""
        ShipViaFilter = ""
        SOFilter = ""
        SONumber = 0
        strSONumber = ""
        ShipNumber = 0
        strShipNumber = ""
        FreightActualAmount = 0
        FreightQuoteAmount = 0
        ProductTotal = 0
        TaxTotal = 0
        FreightTotal = 0
        ShipmentTotal = 0
        ShipmentStatus = ""
        PRONumber = ""
        FreightQuoteNumber = ""
        PickFilter = ""
        PickNumber = 0
        strPickNumber = ""
        ProFilter = ""
    End Sub

    Public Sub LoadFormatting()
        Dim ShipmentStatus As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvShipmentHeaders.Rows
            Try
                ShipmentStatus = row.Cells("ShipmentStatusColumn").Value
            Catch ex As System.Exception
                ShipmentStatus = ""
            End Try

            If ShipmentStatus = "PENDING" Then
                'Me.dgvShipmentHeaders.Rows(RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                Me.dgvShipmentHeaders.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            ElseIf ShipmentStatus = "SHIPPED" Then
                Me.dgvShipmentHeaders.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvShipmentHeaders.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
            ElseIf ShipmentStatus = "INVOICED" Then
                Me.dgvShipmentHeaders.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvShipmentHeaders.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                Me.dgvShipmentHeaders.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvShipmentHeaders.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub llFreightDetailForm_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llFreightDetailForm.LinkClicked
        Using NewCheckShipmentFreight As New ShipmentCheckFreight
            Dim Result = NewCheckShipmentFreight.ShowDialog()
        End Using
    End Sub

    Public Sub TFPErrorLogUpdate()
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


    'Labels

    Private Sub InitializeBarcodeVariables()
        Dim I As Integer

        For I = 0 To 69
            LabelFormat(I) = ""
        Next I

        V00 = ""
        V01 = ""
        V02 = ""
        V03 = ""
        V04 = ""
        V05 = ""
        V06 = ""
        V07 = ""
        V08 = ""
        V09 = ""
        V10 = ""
        V11 = ""
        V12 = ""
        V13 = ""
        V14 = ""
        V15 = ""
        V16 = ""
        V17 = ""
        V18 = ""
        V19 = ""
        V20 = ""
        V21 = ""
        V22 = ""
        V23 = ""
        V24 = ""
        V25 = ""
        V26 = ""
        V27 = ""
        V28 = ""

        VDATA = ""
        VDATA1 = ""
        VBAR = ""
        VBAR1 = ""

        LabelLines = 0
        NumberOfLables = 1
    End Sub

    Private Sub FillBarCodeVariables(ByRef ship As BarcodeLabel.shippingPallet)
        'V00 = "P" & txtPartNumber.Text
        'V01 = "Q" & txtQuantity.Text
        'V02 = "W" & txtWeight.Text
        'V03 = "S" & txtSerialNumber.Text
        'V04 = txtShortDescription.Text
        'V05 = txtLongDescription.Text
        'V06 = ""
        'V07 = "A" & txtCustomerPO.Text
        'V08 = txtRevisionLevel.Text
        ' V09 = ""

        'special purpose use to truncate string length on lable
        V00 = ShipToName
        ship.street = ShipAddress1
        V01 = ShipAddress1
        ship.address1 = ShipCity & ", " & ShipState & " " & ShipZip
        V02 = ShipCity & ", " & ShipState & " " & ShipZip
        ship.address2 = ShipAddress2
        ship.divisionInfo = cboDivisionID.Text
        V03 = ShipAddress2
        ship.country = ShipCountry
        V04 = ShipCountry

        If V00.Length < 31 Then
            V10 = V00
        Else
            V10 = V00.Substring(0, 30)
        End If

        If V01.Length < 31 Then
            V11 = V01
        Else
            V11 = V01.Substring(0, 30)
        End If

        If V02.Length < 31 Then
            V12 = V02
        Else
            V12 = V02.Substring(0, 30)
        End If

        If V03.Length < 31 Then
            V17 = V03
        Else
            V17 = V03.Substring(0, 30)
        End If

        If V04.Length < 31 Then
            V18 = V04
        Else
            V18 = V04.Substring(0, 30)
        End If

        Select Case cboDivisionID.Text
            Case "TFP"
                V28 = "TFP CORP. MEDINA, OH. 44256 330-725-7741"
            Case "CGO"
                V28 = "TFP CORP. GRIFFITH, IN. 46319 219-513-9572"
            Case "CHT"
                V28 = "WELDING CERAMICS CHATTANOOGA, TN 423-752-5740"
            Case "ATL"
                V28 = "TFP CORP.  NORCROSS, GA. 678-728-0095"
            Case "TFF"
                V28 = "TFP CORP.  SURREY, BC.  V4N 3R7  778-298-1094"
            Case "CBS"
                V28 = "TFP CORP.  LAS VEGAS, NV.  702-737-7940"
            Case "SLC"
                V28 = "TFP CORP.  WEST JORDAN, UT.  801-280-6611"
            Case "TFT"
                V28 = "TFP CORP.  IRVING, TX.  972-986-6368"
            Case "HOU"
                V28 = "TFP CORP.  HOUSTON, TX.  281-598-2330"
            Case "TOR"
                V28 = "TFP CORP.  Stoney Creek, Ont. L8E557  905-643-0969"
            Case "ALB"
                V28 = "TFP CORP.  Calgary, Alb. 587-350-3926"
            Case "TFJ"
                V28 = "TFP CORP.  Clifton, NJ 37408 201-939-6866"
            Case Else
                V28 = "TFP CORP. MEDINA, OH 44256 330-725-7741"
        End Select

        ship.divisionInfo = V28
        'V13 = txtSerialNumber.Text
        'V14 = "V" & txtSupplierNumber.Text
        'V15 = txtCountryOfOrigin.Text
        'V16 = "EH" & txtHeatNumber.Text

        'V18 = "3S" & txtSerialNumber.Text
        'V19 = "K" & txtCustomerPO.Text
        ' V20 = "2P" & txtEngineeringChangeLevel.Text
        'V21 = "1T" & txtSerialNumber.Text
        'V22 = "15K" & txtKanBan.Text
        'V23 = ""
        'V24 = "Z"
        'V25 = "HC"
        'V26 = "7Q"
        'V27 = "K"
        'V28 = "T"

        'VDATA = ""
        'VDATA1 = ""
        'VBAR = ""
        'VBAR1 = ""
    End Sub

    Private Sub PrintBarcodeLine()
        ' Click event handler for a button - designed to show how to use the
        ' SendBytesToPrinter function to send a string to the printer.

        Dim s As String = ""
        Dim pd As New PrintDialog()
        Dim i As Integer
        pd.UseEXDialog = True
        pd.PrinterSettings = New PrinterSettings()
        Dim printers(pd.PrinterSettings.InstalledPrinters.Count) As [String]
        pd.PrinterSettings.InstalledPrinters.CopyTo(printers, 0)
        pd.PrinterSettings.PrinterName = ""
        ''checks to see if the designated printer is present
        While i < printers.Count() - 1
            If String.IsNullOrEmpty(printers(i)) = False And printers(i).Contains("Zebra" + EmployeeCompanyCode) Then
                pd.PrinterSettings.PrinterName = printers(i)
            End If
            i += 1
        End While
        ''checks to see if a printer was selected and if not will show the dialog
        If String.IsNullOrEmpty(pd.PrinterSettings.PrinterName) Then
            ' Open the printer dialog box, and then allow the user to select a printer.
            If pd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                sendToPrinter(pd.PrinterSettings.PrinterName)
            End If
        Else
            sendToPrinter(pd.PrinterSettings.PrinterName)
        End If
    End Sub

    Private Sub sendToPrinter(ByVal printerName As String)
        Dim s As String = ""
        For i = 0 To LabelLines
            ' You need a string to send.
            s += LabelFormat(i) + Environment.NewLine
        Next i
        If s <> "" Then
            RawPrinter.SendStringToPrinter(printerName, s)
        End If
    End Sub

    Private Sub AddressLabelSetup()

        'Standard 4x6 AIAG Label setup

        LabelFormat(0) = "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S2"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes

        LabelFormat(8) = "LO60,900,1,100"
        LabelFormat(9) = "LO60,950,1,100"

        'Fill in Verbiage

        LabelFormat(10) = "A35,10,1,3,1,1,N," & Chr(34) & V28 & Chr(34)
        LabelFormat(11) = "A662,40,1,5,2,1,N," & Chr(34) & V10 & Chr(34)
        LabelFormat(12) = "A554,40,1,5,2,1,N," & Chr(34) & V11 & Chr(34)
        LabelFormat(13) = "A432,40,1,5,2,1,N," & Chr(34) & V17 & Chr(34)
        LabelFormat(14) = "A323,40,1,5,2,1,N," & Chr(34) & V12 & Chr(34)
        LabelFormat(15) = "A223,40,1,5,2,1,N," & Chr(34) & V18 & Chr(34)
        LabelFormat(16) = "A100,700,1,4,2,1,N," & Chr(34) & "PALLET        OF" & Chr(34)

        'Print Label

        LabelFormat(17) = "P1"
        LabelFormat(18) = vbFormFeed
        LabelLines = 17

    End Sub

    Private Sub AllShipmentsFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllShipmentsFilter.Click
        AllShipmentsFilter.Checked = True
        LastThreeFilter.Checked = False
        ClearDataInDatagrid()

        LoadShipmentNumber()
        LoadPickNumber()
        LoadSalesOrderNumber()
    End Sub

    Private Sub LastThreeFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastThreeFilter.Click
        AllShipmentsFilter.Checked = False
        LastThreeFilter.Checked = True
        ClearDataInDatagrid()

        LoadShipmentNumber()
        LoadPickNumber()
        LoadSalesOrderNumber()
    End Sub
End Class