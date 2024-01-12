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
Public Class ViewIntercompanyShipments
    Inherits System.Windows.Forms.Form

    Dim SalespersonFilter, ShipViaFilter, ProFilter, ShipmentFilter, PickFilter, CustomerFilter, CustPOFilter, DateFilter, StatusFilter, SOFilter As String
    Dim SONumber, ShipNumber, PickNumber As Integer
    Dim strSONumber, strPickNumber, strShipNumber As String
    Dim FreightActualAmount, FreightQuoteAmount, ProductTotal, TaxTotal, FreightTotal, ShipmentTotal As Double
    Dim ShipmentStatus, PRONumber, FreightQuoteNumber As String
    Dim BeginDate, EndDate As Date
    Dim MasterPickTicketNumber As Integer = 0
    Dim EntryDivision As String

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

    Public Sub ClearData()

        cboShipStatus.Text = ""

        cboShipStatus.SelectedIndex = -1

        txtShipViaSearch.Clear()

        GlobalShipmentNumber = 0

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False
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

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        Dim ShipmentStatus As String = ""

        If cboShipStatus.Text = "OPEN" Then
            ShipmentStatus = "PENDING"
        Else
            ShipmentStatus = cboShipStatus.Text
        End If
        
        CustomerFilter = ""

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
        
        ProFilter = ""

        
        SOFilter = ""

        
        PickFilter = ""

       
        ShipmentFilter = ""

        If txtShipViaSearch.Text <> "" Then
            ShipViaFilter = " AND ShipVia LIKE '%" + txtShipViaSearch.Text + "%'"
        Else
            ShipViaFilter = ""
        End If
        
        SalespersonFilter = ""

        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE (CustomerID = 'TFP ALBERTA' OR CustomerID = 'TFP ATLANTA' OR CustomerID = 'TFP UTAH' OR CustomerID = 'TFP NEVADA' OR CustomerID = 'TFP INDIANA' OR CustomerID = 'WELDING CERAMICS' OR CustomerID = 'TFP DENVER' OR CustomerID = 'TFP HOUSTON' OR CustomerID = 'TFP VANCOUVER' OR CustomerID = 'TFP NEW JERSEY' OR CustomerID = 'TFP IRVING' OR CustomerID = 'TFP TORONTO' OR CustomerID = 'TFP CORP' OR CustomerID = 'TWE') " + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

        ElseIf cboDivisionID.Text = "ALB" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP ALBERTA"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

        ElseIf cboDivisionID.Text = "ATL" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP ATLANTA"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

        ElseIf cboDivisionID.Text = "CBS" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP NEVADA"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

        ElseIf cboDivisionID.Text = "CGO" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP INDIANA"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

        ElseIf cboDivisionID.Text = "CHT" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "WELDING CERAMICS"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

        ElseIf cboDivisionID.Text = "DEN" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP DENVER"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

        ElseIf cboDivisionID.Text = "HOU" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP HOUSTON"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

        ElseIf cboDivisionID.Text = "SLC" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP UTAH"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()


        ElseIf cboDivisionID.Text = "TFF" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP VANCOUVER"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()


        ElseIf cboDivisionID.Text = "TFJ" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP NEW JERSEY"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

        ElseIf cboDivisionID.Text = "TFT" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP IRVING"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()
            Me.dgvProExist.Columns("DivisionIDColumn").Visible = False

        ElseIf cboDivisionID.Text = "TOR" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP TORONTO"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

        ElseIf cboDivisionID.Text = "TWD" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP CORP"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()

        ElseIf cboDivisionID.Text = "TWE" Then
            cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID" + SOFilter + PickFilter + CustPOFilter + ProFilter + CustomerFilter + StatusFilter + ShipmentFilter + ShipViaFilter + SalespersonFilter + DateFilter + " AND (PRONumber <> '' OR DATALENGTH(PRONumber) > 0) ORDER BY ShipmentNumber DESC", con)
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TWE"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentHeaderTable")
            dgvProExist.DataSource = ds.Tables("ShipmentHeaderTable")
            con.Close()
        End If
        If txtCustomerPO.Text = "" Then

        Else
            DropShip()
        End If


        LoadFormatting()
    End Sub

    Public Sub DropShip()

        Dim ShipmentStatus As String = ""

        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        'Displays relevant information
        Dim ItemDataStatement5 As String = "SELECT DropShipSalesOrderNumber FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PONum" + DateFilter
        Dim ItemDataCommand5 As New SqlCommand(ItemDataStatement5, con)
        ItemDataCommand5.Parameters.Add("@PONum", SqlDbType.VarChar).Value = txtCustomerPO.Text
        ItemDataCommand5.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        ItemDataCommand5.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        Dim DropShip As String
        If con.State = ConnectionState.Closed Then con.Open()
        Using reader5 As SqlDataReader = ItemDataCommand5.ExecuteReader
            Try

                If reader5.HasRows Then
                    reader5.Read()
                    If IsDBNull(reader5.Item("DropShipSalesOrderNumber")) Then
                        DropShip = " "
                    Else
                        DropShip = reader5.Item("DropShipSalesOrderNumber")
                    End If
                    con.Close()
                End If
            Catch ex As System.Exception
            End Try
        End Using
        txtDropShip.Text = DropShip
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvProExist.DataSource = Nothing
    End Sub

    Public Sub LoadFormatting()
        Dim ShipmentStatus As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvProExist.Rows
            Try
                ShipmentStatus = row.Cells("ShipmentStatusColumn").Value
            Catch ex As System.Exception
                ShipmentStatus = ""
            End Try

            If ShipmentStatus = "PENDING" Then
                'Me.dgvShipmentHeaders.Rows(RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                Me.dgvProExist.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            ElseIf ShipmentStatus = "SHIPPED" Then
                Me.dgvProExist.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvProExist.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
            ElseIf ShipmentStatus = "INVOICED" Then
                Me.dgvProExist.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvProExist.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                Me.dgvProExist.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvProExist.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        If cboDivisionID.Text = "" Then
            'Do nothing
        Else

        End If
    End Sub

    'Text Box Events
    Private Sub txtShipmentNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    'Load data subroutines

    Private Sub ShipToAddress()
        Dim CustomerIDStatement As String = "SELECT CustomerID FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim CustomerIDCommand As New SqlCommand(CustomerIDStatement, con)
        CustomerIDCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvProExist.CurrentRow.Cells("ShipmentNumberColumn").Value
        CustomerIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipToIDStatement As String = "SELECT ShipToID FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipToIDCommand As New SqlCommand(ShipToIDStatement, con)
        ShipToIDCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvProExist.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipToIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipAddress1Statement As String = "SELECT ShipAddress1 FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipAddress1Command As New SqlCommand(ShipAddress1Statement, con)
        ShipAddress1Command.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvProExist.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipAddress2Statement As String = "SELECT ShipAddress2 FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipAddress2Command As New SqlCommand(ShipAddress2Statement, con)
        ShipAddress2Command.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvProExist.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipCityStatement As String = "SELECT ShipCity FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipCityCommand As New SqlCommand(ShipCityStatement, con)
        ShipCityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvProExist.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipStateStatement As String = "SELECT ShipState FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipStateCommand As New SqlCommand(ShipStateStatement, con)
        ShipStateCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvProExist.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipZipStatement As String = "SELECT ShipZip FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipZipCommand As New SqlCommand(ShipZipStatement, con)
        ShipZipCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvProExist.CurrentRow.Cells("ShipmentNumberColumn").Value
        ShipZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipCountryStatement As String = "SELECT ShipCountry FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim ShipCountryCommand As New SqlCommand(ShipCountryStatement, con)
        ShipCountryCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = dgvProExist.CurrentRow.Cells("ShipmentNumberColumn").Value
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

            'TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub ViewIntercompanyShipments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PurchaseOrderHeaderTable' table. You can move, or remove it, as needed.
        Me.PurchaseOrderHeaderTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PurchaseOrderHeaderTable)
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
        EntryDivision = EmployeeCompanyCode
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

    Private Sub dgvProExist_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProExist.CellClick
        If dgvProExist.RowCount > 0 Then
            Try
                Dim RowIndex As Integer = Me.dgvProExist.CurrentCell.RowIndex
                Dim data As String = Mid(Me.dgvProExist.Rows(RowIndex).Cells("CustomerPODataGridViewTextBoxColumn").Value.ToString(), 4)
                txtCustomerPO.Text = data
                DropShip()
            Catch ex As System.Exception
            End Try
        End If
    End Sub

    Private Sub dgvProExist_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProExist.CellContentDoubleClick
        Dim RowShipNumber As Integer = 0
        Dim RowDivision As String = ""

        Dim RowIndex As Integer = Me.dgvProExist.CurrentCell.RowIndex

        RowShipNumber = Me.dgvProExist.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowDivision = Me.dgvProExist.Rows(RowIndex).Cells("DivisionIDColumn").Value

        GlobalShipmentNumber = RowShipNumber
        GlobalDivisionCode = RowDivision
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

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalDivisionCode = EntryDivision

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalDivisionCode = EntryDivision

        Me.Dispose()
        Me.Close()
    End Sub

End Class