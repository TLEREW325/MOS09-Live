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
Public Class ViewPickTickets
    Inherits System.Windows.Forms.Form

    Dim ShipViaFilter, DateFilter, CustomerFilter, SOFilter, CustPOFilter, SalespersonFilter, StatusFilter As String
    Dim SONumber As Integer
    Dim strSONumber As String
    Dim PLStatus, SalesOrderStatus, GetShippingStatus As String
    Dim BeginDate, EndDate As Date
    Dim PickQOH As Double = 0
    Dim CountPickLines As Integer = 0
    Dim MasterPickTicketNumber As Integer = 0
    Dim Counter As Integer = 0
    Dim QOHPartNumber As String = ""
    Dim SONumberFilter As String = ""
    Dim PickNumberFilter = ""

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
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewPickTickets_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
        ClearVariables()
    End Sub

    Private Sub ViewPickTickets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCurrentDivision()
        ViewAllPickTicketsToolStripMenuItem.Checked = False
        ViewLastThreeYearsToolStripMenuItem.Checked = True

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            Me.dgvPickListHeader.Columns("RunningCountColumn").Visible = True
        Else
            Me.dgvPickListHeader.Columns("RunningCountColumn").Visible = False
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

    Private Sub dgvPickListHeader_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvPickListHeader.CellDoubleClick
        Dim RowPLNumber As Integer
        Dim RowIndex As Integer = Me.dgvPickListHeader.CurrentCell.RowIndex

        RowPLNumber = Me.dgvPickListHeader.Rows(RowIndex).Cells("PickListHeaderKeyColumn").Value

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
                Dim result = NewReprintPickListRemote.ShowDialog()
            End Using
        Else
            Using NewReprintPickList As New ReprintPickList
                Dim result = NewReprintPickList.ShowDialog()
            End Using
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvPickListHeader.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderHeaderKey = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboSalespersonID.Text <> "" Then
            SalespersonFilter = " AND SalesmanID = '" + cboSalespersonID.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If cboStatus.Text <> "" Then
            If cboStatus.Text = "OPEN" Then
                PLStatus = "PENDING"
            ElseIf cboStatus.Text = "CLOSED" Then
                PLStatus = "SHIPPED"
            End If
            StatusFilter = " AND PLStatus = '" + PLStatus + "'"
        Else
            StatusFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustPOFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            CustPOFilter = ""
        End If
        If txtShipVia.Text <> "" Then
            ShipViaFilter = " AND ShipVia LIKE '%" + txtShipVia.Text + "%'"
        Else
            ShipViaFilter = ""
        End If
        If chkDateRange.Checked = False Then
            If ViewAllPickTicketsToolStripMenuItem.Checked = True Then
                DateFilter = ""
            ElseIf ViewLastThreeYearsToolStripMenuItem.Checked = True Then
                DateFilter = " AND PickDate >= '1/1/2020'"
            Else
                DateFilter = ""
            End If
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND PickDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM PickListHeaderTable WHERE DivisionID = @DivisionID" + SOFilter + SalespersonFilter + CustomerFilter + CustPOFilter + StatusFilter + ShipViaFilter + DateFilter + " ORDER BY PickListHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PickListHeaderTable")
        dgvPickListHeader.DataSource = ds.Tables("PickListHeaderTable")
        cboPickTicketNumber.DataSource = ds.Tables("PickListHeaderTable")
        con.Close()
    End Sub

    Public Sub LoadSalesOrder()
        If ViewAllPickTicketsToolStripMenuItem.Checked = True Then
            SONumberFilter = ""
        ElseIf ViewLastThreeYearsToolStripMenuItem.Checked = True Then
            SONumberFilter = " AND SalesOrderDate >= '1/1/2020'"
        Else
            SONumberFilter = ""
        End If

        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable where DivisionKey = @DivisionKey" + SONumberFilter + " ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds1.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerID.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomerName.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadSalespersonTWD()
        cmd = New SqlCommand("SELECT DISTINCT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2 OR DivisionKey = @DivisionKey3", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TFP"
        cmd.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@DivisionKey3", SqlDbType.VarChar).Value = "ADM"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "EmployeeData")
        cboSalespersonID.DataSource = ds3.Tables("EmployeeData")
        con.Close()
        cboSalespersonID.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesperson()
        cmd = New SqlCommand("SELECT DISTINCT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "EmployeeData")
        cboSalespersonID.DataSource = ds3.Tables("EmployeeData")
        con.Close()
        cboSalespersonID.SelectedIndex = -1
    End Sub

    Public Sub LoadPickTicketNumber()
        If ViewAllPickTicketsToolStripMenuItem.Checked = True Then
            PickNumberFilter = ""
        ElseIf ViewLastThreeYearsToolStripMenuItem.Checked = True Then
            PickNumberFilter = " AND PickDate >= '1/1/2020'"
        Else
            PickNumberFilter = ""
        End If

        cmd = New SqlCommand("SELECT PickListHeaderKey FROM PickListHeaderTable where DivisionID = @DivisionID" + PickNumberFilter + " ORDER BY PickListHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "PickListHeaderTable")
        cboPickTicketNumber.DataSource = ds4.Tables("PickListHeaderTable")
        con.Close()
        cboPickTicketNumber.SelectedIndex = -1
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

    Public Sub LoadOpenOrders()
        Dim OpenPicks As Integer = 0
        Dim strOpenPicks As String = ""
        Dim PickString As String = ""

        Dim OpenPicksStatement As String = "SELECT COUNT(PickListHeaderKey) FROM PickListHeaderTable WHERE PLStatus = @PLStatus AND DivisionID = @DivisionID"
        Dim OpenPicksCommand As New SqlCommand(OpenPicksStatement, con)
        OpenPicksCommand.Parameters.Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
        OpenPicksCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OpenPicks = CInt(OpenPicksCommand.ExecuteScalar)
        Catch ex As Exception
            OpenPicks = 0
        End Try
        con.Close()

        strOpenPicks = CStr(OpenPicks)

        If OpenPicks = 1 Then
            PickString = "There is " + strOpenPicks + " open order."
        Else
            PickString = "There are " + strOpenPicks + " open orders."
        End If

        lblOpenOrders.Text = PickString
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

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "ADM" Or cboDivisionID.Text = "TFP" Or cboDivisionID.Text = "TWD" Then
            LoadSalespersonTWD()
        Else
            LoadSalesperson()
        End If

        LoadSalesOrder()
        LoadCustomerList()
        LoadCustomerName()
        LoadOpenOrders()
        LoadPickTicketNumber()

        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearData()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesOrderNumber.SelectedIndex = -1
        cboSalespersonID.SelectedIndex = -1
        cboStatus.SelectedIndex = -1

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        txtCustomerPO.Clear()
        txtShipVia.Clear()

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        DateFilter = ""
        CustomerFilter = ""
        SOFilter = ""
        CustPOFilter = ""
        SalespersonFilter = ""
        StatusFilter = ""
        ShipViaFilter = ""
        SONumber = 0
        strSONumber = ""
        PLStatus = ""
        SalesOrderStatus = ""
        GetShippingStatus = ""
    End Sub

    Public Sub LoadUpdateQOH()
        Try
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

    Private Sub dgvPickListHeader_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPickListHeader.CellValueChanged
        Dim PickDate, CustomerPO, ShipVia, SalesmanID, Comment, SpecialInstructions, PRONumber, ShipDate As String
        Dim PickListHeaderKey As Integer

        If Me.dgvPickListHeader.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPickListHeader.CurrentCell.RowIndex

            Try
                PickListHeaderKey = Me.dgvPickListHeader.Rows(RowIndex).Cells("PickListHeaderKeyColumn").Value
            Catch ex As Exception
                PickListHeaderKey = 0
            End Try
            Try
                PickDate = Me.dgvPickListHeader.Rows(RowIndex).Cells("PickDateColumn").Value
            Catch ex As Exception
                PickDate = ""
            End Try
            Try
                CustomerPO = Me.dgvPickListHeader.Rows(RowIndex).Cells("CustomerPOColumn").Value
            Catch ex As Exception
                CustomerPO = ""
            End Try
            Try
                ShipVia = Me.dgvPickListHeader.Rows(RowIndex).Cells("ShipViaColumn").Value
            Catch ex As Exception
                ShipVia = ""
            End Try
            Try
                SalesmanID = Me.dgvPickListHeader.Rows(RowIndex).Cells("SalesmanIDColumn").Value
            Catch ex As Exception
                SalesmanID = ""
            End Try
            Try
                Comment = Me.dgvPickListHeader.Rows(RowIndex).Cells("CommentColumn").Value
            Catch ex As Exception
                Comment = ""
            End Try
            Try
                SpecialInstructions = Me.dgvPickListHeader.Rows(RowIndex).Cells("SpecialInstructionsColumn").Value
            Catch ex As Exception
                SpecialInstructions = ""
            End Try
            Try
                PRONumber = Me.dgvPickListHeader.Rows(RowIndex).Cells("PRONumberColumn").Value
            Catch ex As Exception
                PRONumber = ""
            End Try
            Try
                ShipDate = Me.dgvPickListHeader.Rows(RowIndex).Cells("ShipDateColumn").Value
            Catch ex As Exception
                ShipDate = ""
            End Try

            Try
                'UPDATE Pick Ticket
                cmd = New SqlCommand("UPDATE PickListHeaderTable SET PickDate = @PickDate, CustomerPO = @CustomerPO, ShipVia = @ShipVia, SalesmanID = @SalesmanID, Comment = @Comment, SpecialInstructions = @SpecialInstructions, PRONumber = @PRONumber, ShipDate = @ShipDate WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = PickListHeaderKey
                    .Add("@PickDate", SqlDbType.VarChar).Value = PickDate
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                    .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                    .Add("@SalesmanID", SqlDbType.VarChar).Value = SalesmanID
                    .Add("@Comment", SqlDbType.VarChar).Value = Comment
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                    .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                    .Add("@ShipDate", SqlDbType.VarChar).Value = ShipDate
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempPickNumber As Integer = 0
                Dim strPickNumber As String
                TempPickNumber = PickListHeaderKey
                strPickNumber = CStr(TempPickNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "View Pick Listing --- Update Pick Header Failure"
                ErrorReferenceNumber = "Pick Ticket # " + strPickNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            Try
                'UPDATE Shipment
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipDate = @ShipDate, CustomerPO = @CustomerPO, ShipVia = @ShipVia, SalesmanID = @SalesmanID, Comment = @Comment, SpecialInstructions = @SpecialInstructions, PRONumber = @PRONumber WHERE PickTicketNumber = @PickTicketNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PickTicketNumber", SqlDbType.VarChar).Value = PickListHeaderKey
                    .Add("@ShipDate", SqlDbType.VarChar).Value = ShipDate
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                    .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                    .Add("@SalesmanID", SqlDbType.VarChar).Value = SalesmanID
                    .Add("@Comment", SqlDbType.VarChar).Value = Comment
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                    .Add("@PRONumber", SqlDbType.VarChar).Value = PRONumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        Else
            'Skip update
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        LoadOpenOrders()
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        LoadOpenOrders()
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintPickListHeaders As New PrintPickListHeaders
            Dim result = NewPrintPickListHeaders.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprint.Click
        GlobalPickListNumber = Val(cboPickTicketNumber.Text)
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
                Dim result = NewReprintPickListRemote.ShowDialog()
            End Using
        Else
            Using NewReprintPickList As New ReprintPickList
                Dim result = NewReprintPickList.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'Extract Sales Order Number
        Dim SalesOrderNumber As Integer

        Dim SalesOrderStatement As String = "SELECT SalesOrderHeaderKey FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID"
        Dim SalesOrderCommand As New SqlCommand(SalesOrderStatement, con)
        SalesOrderCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
        SalesOrderCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SalesOrderNumber = CInt(SalesOrderCommand.ExecuteScalar)
        Catch ex As Exception
            SalesOrderNumber = 0
        End Try
        con.Close()

        'Verify that order has not been shipped
        Dim GetShippingStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE PickTicketNumber = @PickTicketNumber AND SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim GetShippingStatusCommand As New SqlCommand(GetShippingStatusStatement, con)
        GetShippingStatusCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
        GetShippingStatusCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
        GetShippingStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetShippingStatus = CStr(GetShippingStatusCommand.ExecuteScalar)
        Catch ex As Exception
            GetShippingStatus = 0
        End Try
        con.Close()

        If GetShippingStatus = "PENDING" Then
            'Delete Pick Ticket
            cmd = New SqlCommand("Delete FROM PickListHeaderTable Where PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Delete Pending Shipments if any
            cmd = New SqlCommand("Delete FROM ShipmentHeaderTable Where PickTicketNumber = @PickTicketNumber AND SalesOrderKey = @SalesOrderKey And DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'UPDATE Sales Order Table
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus Where SalesOrderKey = @SalesOrderKey", con)
            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SalesOrderNumber
            cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Pick Ticket deleted and Sales Order re-opened.", MsgBoxStyle.OkOnly)
            ClearData()
            ClearVariables()
            dgvPickListHeader.Refresh()
        Else
            MsgBox("Order has already been processed for shipping and can not be deleted.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub DeletePickTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletePickTicketToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
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

    Private Sub cmdPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintAll.Click
        Dim RowPickTicketNumber As Integer = 0

        'Get new Batch Number
        '****************************************************************************************************
        'Use new Batch Number for current selection
        Dim NextPickBatchNumber As Integer = 0
        Dim LastPickBatchNumber As Integer = 0

        Dim PLBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM PickListHeaderTable"
        Dim PLBatchNumberCommand As New SqlCommand(PLBatchNumberStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPickBatchNumber = CInt(PLBatchNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastPickBatchNumber = 874000000
        End Try
        con.Close()

        NextPickBatchNumber = LastPickBatchNumber + 1

        If Me.dgvPickListHeader.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In Me.dgvPickListHeader.SelectedRows
                Try
                    RowPickTicketNumber = row.Cells("PickListHeaderKeyColumn").Value
                Catch ex As Exception
                    RowPickTicketNumber = 0
                End Try

                '****************************************************************************************************
                'Update all Open Picks for division with new batch number
                Try
                    cmd = New SqlCommand("UPDATE PickListHeaderTable SET BatchNumber = @BatchNumber, PickCount = @PickCount WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = RowPickTicketNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = NextPickBatchNumber
                        .Add("@PickCount", SqlDbType.VarChar).Value = 2
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                End Try
                '****************************************************************************************************
            Next
        End If

        'Auto-Print new batch
        GlobalPickBatchNumber = NextPickBatchNumber
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
            Using NewPrintPickTicketBatchRemote As New PrintPickTicketBatchRemote
                Dim Result = NewPrintPickTicketBatchRemote.ShowDialog()
            End Using
        Else
            Using NewPrintPickTicket As New PrintPickTicketBatch
                Dim Result = NewPrintPickTicket.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ClosePickTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClosePickTicketToolStripMenuItem.Click
        'Get Pick Number from datagrid
        Dim PickListHeaderKey As Integer = 0
        Dim PLStatus As String = ""

        If Me.dgvPickListHeader.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPickListHeader.CurrentCell.RowIndex

            Try
                PickListHeaderKey = Me.dgvPickListHeader.Rows(RowIndex).Cells("PickListHeaderKeyColumn").Value
            Catch ex As Exception
                PickListHeaderKey = 0
            End Try
            Try
                PLStatus = Me.dgvPickListHeader.Rows(RowIndex).Cells("PLStatusColumn").Value
            Catch ex As Exception
                PLStatus = ""
            End Try
        Else
            'Do nothing
        End If

        If PLStatus = "SHIPPED" Then
            MsgBox("This pick is already closed.", MsgBoxStyle.OkOnly)
        Else
            'Check for pending shipment
            Dim ShipmentStatus As String = ""

            Dim ShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND PickTicketNumber = @PickTicketNumber"
            Dim ShipmentStatusCommand As New SqlCommand(ShipmentStatusStatement, con)
            ShipmentStatusCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = PickListHeaderKey
            ShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ShipmentStatus = CStr(ShipmentStatusCommand.ExecuteScalar)
            Catch ex As System.Exception
                ShipmentStatus = "NONE"
            End Try
            con.Close()

            If ShipmentStatus = "PENDING" Then
                MsgBox("This pick has a pending shipment. Pick will close when the shipment is processed.", MsgBoxStyle.OkOnly)
            Else
                'Update Header Table
                cmd = New SqlCommand("UPDATE PickListHeaderTable SET PLStatus = @PLStatus WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = PickListHeaderKey
                    .Add("@PLStatus", SqlDbType.VarChar).Value = "SHIPPED"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Update Line table
                cmd = New SqlCommand("UPDATE PickListLineTable SET LineStatus = @LineStatus WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = PickListHeaderKey
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                LoadOpenOrders()

                MsgBox("Pick Ticket is now closed.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub ReOpenPickTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReOpenPickTicketToolStripMenuItem.Click
        'Get Pick Number from datagrid
        Dim PickListHeaderKey As Integer = 0
        Dim PLStatus As String = ""

        If Me.dgvPickListHeader.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPickListHeader.CurrentCell.RowIndex

            Try
                PickListHeaderKey = Me.dgvPickListHeader.Rows(RowIndex).Cells("PickListHeaderKeyColumn").Value
            Catch ex As Exception
                PickListHeaderKey = 0
            End Try
            Try
                PLStatus = Me.dgvPickListHeader.Rows(RowIndex).Cells("PLStatusColumn").Value
            Catch ex As Exception
                PLStatus = ""
            End Try
        Else
            'Do nothing
        End If

        If PLStatus = "PENDING" Then
            MsgBox("This pick is already open.", MsgBoxStyle.OkOnly)
        Else
            'Check for pending shipment
            Dim ShipmentStatus As String = ""

            Dim ShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND PickTicketNumber = @PickTicketNumber"
            Dim ShipmentStatusCommand As New SqlCommand(ShipmentStatusStatement, con)
            ShipmentStatusCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = PickListHeaderKey
            ShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ShipmentStatus = CStr(ShipmentStatusCommand.ExecuteScalar)
            Catch ex As System.Exception
                ShipmentStatus = "NONE"
            End Try
            con.Close()

            If ShipmentStatus <> "PENDING" Then
                MsgBox("This pick has a completed shipment. Pick ticket cannot be re-opened.", MsgBoxStyle.OkOnly)
            Else
                'Update Header Table
                cmd = New SqlCommand("UPDATE PickListHeaderTable SET PLStatus = @PLStatus WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = PickListHeaderKey
                    .Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Update Line Table
                cmd = New SqlCommand("UPDATE PickListLineTable SET LineStatus = @LineStatus WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = PickListHeaderKey
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                LoadOpenOrders()

                MsgBox("Pick Ticket is now open.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub ViewAllPickTicketsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAllPickTicketsToolStripMenuItem.Click
        ViewAllPickTicketsToolStripMenuItem.Checked = True
        ViewLastThreeYearsToolStripMenuItem.Checked = False
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        LoadSalesOrder()
    End Sub

    Private Sub ViewLastThreeYearsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLastThreeYearsToolStripMenuItem.Click
        ViewAllPickTicketsToolStripMenuItem.Checked = False
        ViewLastThreeYearsToolStripMenuItem.Checked = True
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        LoadSalesOrder()
    End Sub
End Class