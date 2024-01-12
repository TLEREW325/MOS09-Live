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
Public Class ViewShippingFreightDetails
    Inherits System.Windows.Forms.Form

    Dim TextFilter, PickFilter, ShipmentFilter, ShipViaFilter, ShipMethodFilter, DateFilter, CustomerFilter, InvoiceFilter, SOFilter, CustomerPOFilter As String
    Dim InvoiceNumber, SONumber, PickNumber, ShipmentNumber As Integer
    Dim strInvoiceNumber, strSOnumber, strPickNumber, strShipmentNumber As String
    Dim TotalFreightBilled, TotalFreightQuoted As Double
    Dim BeginDate, EndDate As Date

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    'Form Operations

    Private Sub ViewShippingFreightDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadCurrentDivision()
    End Sub

    Private Sub ViewShippingFreightDetails_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    'Load data into datasets

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
        dgvShippingDetails.DataSource = Nothing
        Me.dgvShippingDetails.Columns("DivisionIDColumn").Visible = False
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboShipVia.Text <> "" Then
            ShipViaFilter = " AND ShipVia LIKE '%" + cboShipVia.Text + "%'"
        Else
            ShipViaFilter = ""
        End If
        If txtTextSearch.Text <> "" Then
            TextFilter = " AND (PRONumber LIKE '%" + txtTextSearch.Text + "%' OR FreightQuoteNumber LIKE '%" + txtTextSearch.Text + "%' OR CustomerPO LIKE '%" + txtTextSearch.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboShipMethod.Text <> "" Then
            ShipMethodFilter = " AND ShippingMethod = '" + cboShipMethod.Text + "'"
        Else
            ShipMethodFilter = ""
        End If
        If cboInvoiceNumber.Text <> "" Then
            InvoiceNumber = Val(cboInvoiceNumber.Text)
            strInvoiceNumber = CStr(InvoiceNumber)
            InvoiceFilter = " AND InvoiceNumber = '" + strInvoiceNumber + "'"
        Else
            InvoiceFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboPickNumber.Text <> "" Then
            PickNumber = Val(cboPickNumber.Text)
            strPickNumber = CStr(PickNumber)
            PickFilter = " AND PickTicketNumber = '" + strPickNumber + "'"
        Else
            PickFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustomerPOFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            CustomerPOFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSOnumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSOnumber + "'"
        Else
            SOFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ShippingFreightDetails WHERE DivisionID <> @DivisionID" + CustomerFilter + InvoiceFilter + SOFilter + PickFilter + ShipmentFilter + ShipViaFilter + ShipMethodFilter + CustomerPOFilter + TextFilter + DateFilter + " ORDER BY DivisionID, CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShippingFreightDetails")
            dgvShippingDetails.DataSource = ds.Tables("ShippingFreightDetails")
            con.Close()
            Me.dgvShippingDetails.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM ShippingFreightDetails WHERE DivisionID = @DivisionID" + CustomerFilter + InvoiceFilter + SOFilter + PickFilter + ShipmentFilter + ShipViaFilter + ShipMethodFilter + CustomerPOFilter + TextFilter + DateFilter + " ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShippingFreightDetails")
            dgvShippingDetails.DataSource = ds.Tables("ShippingFreightDetails")
            con.Close()
            Me.dgvShippingDetails.Columns("DivisionIDColumn").Visible = False
        End If
    End Sub

    Public Sub LoadCustomerID()
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

    Public Sub LoadInvoiceNumber()
        cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID ORDER BY InvoiceNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "InvoiceHeaderTable")
        cboInvoiceNumber.DataSource = ds2.Tables("InvoiceHeaderTable")
        con.Close()
        cboInvoiceNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesOrderNumber()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds4.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "CustomerList")
        cboCustomerName.DataSource = ds5.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadPickNumber()
        cmd = New SqlCommand("SELECT PickListHeaderKey FROM PickListHeaderTable WHERE DivisionID = @DivisionID ORDER BY PickListHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "PickListHeaderTable")
        cboPickNumber.DataSource = ds6.Tables("PickListHeaderTable")
        con.Close()
        cboPickNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "ShipmentHeaderTable")
        cboShipmentNumber.DataSource = ds7.Tables("ShipmentHeaderTable")
        con.Close()
        cboShipmentNumber.SelectedIndex = -1
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

    Public Sub LoadTotalFreightBilledByFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboShipVia.Text <> "" Then
            ShipViaFilter = " AND ShipVia = '" + cboShipVia.Text + "'"
        Else
            ShipViaFilter = ""
        End If
        If txtTextSearch.Text <> "" Then
            TextFilter = " AND (PRONumber LIKE '%" + txtTextSearch.Text + "%' OR FreightQuoteNumber LIKE '%" + txtTextSearch.Text + "%' OR CustomerPO LIKE '%" + txtTextSearch.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboShipMethod.Text <> "" Then
            ShipMethodFilter = " AND ShippingMethod = '" + cboShipMethod.Text + "'"
        Else
            ShipMethodFilter = ""
        End If
        If cboInvoiceNumber.Text <> "" Then
            InvoiceNumber = Val(cboInvoiceNumber.Text)
            strInvoiceNumber = CStr(InvoiceNumber)
            InvoiceFilter = " AND InvoiceNumber = '" + strInvoiceNumber + "'"
        Else
            InvoiceFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboPickNumber.Text <> "" Then
            PickNumber = Val(cboPickNumber.Text)
            strPickNumber = CStr(PickNumber)
            PickFilter = " AND PickTicketNumber = '" + strPickNumber + "'"
        Else
            PickFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustomerPOFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            CustomerPOFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSOnumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSOnumber + "'"
        Else
            SOFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            Dim TotalFreightBilledStatement As String = "SELECT SUM(FreightActualAmount) FROM ShippingFreightDetails WHERE DivisionID <> @DivisionID" + CustomerFilter + InvoiceFilter + SOFilter + PickFilter + ShipmentFilter + ShipViaFilter + ShipMethodFilter + CustomerPOFilter + TextFilter + DateFilter
            Dim TotalFreightBilledCommand As New SqlCommand(TotalFreightBilledStatement, con)
            TotalFreightBilledCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalFreightBilledCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalFreightBilledCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalFreightQuotedStatement As String = "SELECT SUM(FreightQuoteAmount) FROM ShippingFreightDetails WHERE DivisionID <> @DivisionID" + CustomerFilter + InvoiceFilter + SOFilter + PickFilter + ShipmentFilter + ShipViaFilter + ShipMethodFilter + CustomerPOFilter + TextFilter + DateFilter
            Dim TotalFreightQuotedCommand As New SqlCommand(TotalFreightQuotedStatement, con)
            TotalFreightQuotedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalFreightQuotedCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalFreightQuotedCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalFreightBilled = CDbl(TotalFreightBilledCommand.ExecuteScalar)
            Catch ex As Exception
                TotalFreightBilled = 0
            End Try
            Try
                TotalFreightQuoted = CDbl(TotalFreightQuotedCommand.ExecuteScalar)
            Catch ex As Exception
                TotalFreightQuoted = 0
            End Try
            con.Close()
        Else
            Dim TotalFreightBilledStatement As String = "SELECT SUM(FreightActualAmount) FROM ShippingFreightDetails WHERE DivisionID = @DivisionID" + CustomerFilter + InvoiceFilter + SOFilter + PickFilter + ShipmentFilter + ShipViaFilter + ShipMethodFilter + CustomerPOFilter + TextFilter + DateFilter
            Dim TotalFreightBilledCommand As New SqlCommand(TotalFreightBilledStatement, con)
            TotalFreightBilledCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalFreightBilledCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalFreightBilledCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim TotalFreightQuotedStatement As String = "SELECT SUM(FreightQuoteAmount) FROM ShippingFreightDetails WHERE DivisionID = @DivisionID" + CustomerFilter + InvoiceFilter + SOFilter + PickFilter + ShipmentFilter + ShipViaFilter + ShipMethodFilter + CustomerPOFilter + TextFilter + DateFilter
            Dim TotalFreightQuotedCommand As New SqlCommand(TotalFreightQuotedStatement, con)
            TotalFreightQuotedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalFreightQuotedCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalFreightQuotedCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalFreightBilled = CDbl(TotalFreightBilledCommand.ExecuteScalar)
            Catch ex As Exception
                TotalFreightBilled = 0
            End Try
            Try
                TotalFreightQuoted = CDbl(TotalFreightQuotedCommand.ExecuteScalar)
            Catch ex As Exception
                TotalFreightQuoted = 0
            End Try
            con.Close()
        End If

        txtBilledFreight.Text = FormatCurrency(TotalFreightBilled, 2)
        txtQuotedFreight.Text = FormatCurrency(TotalFreightQuoted, 2)
    End Sub

    'Datagridview Events

    Private Sub dgvShippingDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim RowInvoiceNumber, RowSONumber, RowShipmentNumber As Integer
        Dim RowDivision As String = ""
        Dim RowIndex As Integer = Me.dgvShippingDetails.CurrentCell.RowIndex

        RowInvoiceNumber = Me.dgvShippingDetails.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
        RowSONumber = Me.dgvShippingDetails.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value
        RowShipmentNumber = Me.dgvShippingDetails.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowDivision = Me.dgvShippingDetails.Rows(RowIndex).Cells("DivisionIDColumn").Value

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
            'Choose the Invoice Print Form by division
            If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = RowDivision
                Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                    Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                End Using
            Else
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = RowDivision
                Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                    Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                End Using
            End If
        Else
            'Choose the Invoice Print Form by division
            If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = RowDivision
                Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                    Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                End Using
            Else
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = RowDivision
                Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                    Dim result = NewPrintInvoiceSingle.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub dgvShippingDetails_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If dgvShippingDetails.RowCount <> 0 Then
            Dim QuoteReferenceNumber, ShipVia, PRONumber, CustomerPO As String
            Dim ShipmentNumber, NumberOfPallets As Integer
            Dim QuotedFreight, ShipWeight, FreightActualAmount As Double

            Dim RowIndex As Integer = Me.dgvShippingDetails.CurrentCell.RowIndex
            Try
                QuoteReferenceNumber = Me.dgvShippingDetails.Rows(RowIndex).Cells("FreightQuoteNumberColumn").Value
            Catch ex As Exception
                QuoteReferenceNumber = ""
            End Try
            Try
                ShipVia = Me.dgvShippingDetails.Rows(RowIndex).Cells("ShipViaColumn").Value
            Catch ex As Exception
                ShipVia = ""
            End Try
            Try
                PRONumber = Me.dgvShippingDetails.Rows(RowIndex).Cells("PRONumberColumn").Value
            Catch ex As Exception
                PRONumber = ""
            End Try
            Try
                CustomerPO = Me.dgvShippingDetails.Rows(RowIndex).Cells("CustomerPOColumn").Value
            Catch ex As Exception
                CustomerPO = ""
            End Try
            Try
                ShipmentNumber = Me.dgvShippingDetails.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                ShipmentNumber = 0
            End Try
            Try
                FreightActualAmount = Me.dgvShippingDetails.Rows(RowIndex).Cells("FreightActualAmountColumn").Value
            Catch ex As Exception
                FreightActualAmount = 0
            End Try
            Try
                NumberOfPallets = Me.dgvShippingDetails.Rows(RowIndex).Cells("NumberOfPalletsColumn").Value
            Catch ex As Exception
                NumberOfPallets = 0
            End Try
            Try
                QuotedFreight = Me.dgvShippingDetails.Rows(RowIndex).Cells("FreightQuoteAmountColumn").Value
            Catch ex As Exception
                QuotedFreight = 0
            End Try
            Try
                ShipWeight = Me.dgvShippingDetails.Rows(RowIndex).Cells("ShippingWeightColumn").Value
            Catch ex As Exception
                ShipWeight = 0
            End Try

            If ShipmentNumber = 0 Then
                'Skip
            Else
                'UPDATE Shipment Header Table
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipVia = @ShipVia, PRONumber = @PRONumber, FreightQuoteNumber = @FreightQuoteNumber, FreightQuoteAmount = @FreightQuoteAmount, ShippingWeight = @ShippingWeight, FreightActualAmount = @FreightActualAmount, NumberOfPallets = @NumberOfPallets, CustomerPO = @CustomerPO WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                    .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                    .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = QuoteReferenceNumber
                    .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = QuotedFreight
                    .Add("@ShippingWeight", SqlDbType.VarChar).Value = ShipWeight
                    .Add("@FreightActualAmount", SqlDbType.VarChar).Value = FreightActualAmount
                    .Add("@NumberOfPallets", SqlDbType.VarChar).Value = NumberOfPallets
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Re-Calculate Shipment Totals
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentTotal = TaxTotal + Tax2Total + Tax3Total + ProductTotal + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Else
            'Do nothing
        End If
    End Sub

    'Command Button Events

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilters()
        LoadTotalFreightBilledByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintShipmentFreightDetails As New PrintShipmentFreightDetails
            Dim Result = NewPrintShipmentFreightDetails.ShowDialog
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    'Menu Strip Events

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintShipmentFreightDetails As New PrintShipmentFreightDetails
            Dim Result = NewPrintShipmentFreightDetails.ShowDialog
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    'Combo Box Events

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadInvoiceNumber()
        LoadCustomerID()
        LoadCustomerName()
        LoadSalesOrderNumber()
        LoadPickNumber()
        LoadShipmentNumber()

        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    'Clear Routines

    Public Sub ClearData()
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboInvoiceNumber.Text = ""
        cboSalesOrderNumber.Text = ""
        cboShipmentNumber.Text = ""
        cboShipMethod.Text = ""
        cboShipVia.Text = ""
        cboPickNumber.Text = ""

        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboInvoiceNumber.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboShipmentNumber.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboPickNumber.SelectedIndex = -1

        txtBilledFreight.Clear()
        txtQuotedFreight.Clear()
        txtCustomerPO.Clear()
        txtTextSearch.Clear()

        chkDateRange.Checked = False

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboCustomerName.Focus()
    End Sub

    Public Sub ClearVariables()
        DateFilter = ""
        CustomerFilter = ""
        InvoiceFilter = ""
        SOFilter = ""
        CustomerPOFilter = ""
        InvoiceNumber = 0
        SONumber = 0
        strInvoiceNumber = ""
        strSOnumber = ""
        TotalFreightBilled = 0
        TotalFreightQuoted = 0
    End Sub
End Class