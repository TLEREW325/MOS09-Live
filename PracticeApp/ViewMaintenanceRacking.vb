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

Public Class ViewMaintenanceRacking

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable
    Dim tableName As String = "MaintenanceRackingTable"

    Dim BeginDate, EndDate As Date

    Dim PartFilter, DescriptionFilter, RackFilter, WeightFilter, CommentFilter, DivisionFilter, DateFilter, VendorFilter As String
    'Closes the form
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    'Loads division into combobox
    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case GlobalDivisionCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                cboDivisionID.DisplayMember = "DivisionKey"
                con.Close()

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = True
            Case "ALB"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "ATL"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "CBS"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "CHT"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "CGO"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "DEN"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "HOU"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "LLH"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "SLC"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "TFF"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "TFJ"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "TFP"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "TFT"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "TOR"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "TWD"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case "TWE"

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                cboDivisionID.DisplayMember = "DivisionKey"
                con.Close()

                cboDivisionID.Text = GlobalDivisionCode
                cboDivisionID.Enabled = False
        End Select
    End Sub
    'Clears the data out of the input places and then it reassigns the division into the combobox
    Public Sub cleardata()
        cboDivisionID.Text = GlobalDivisionCode
        txtDesc.Text = ""
        txtPartNum.Text = ""
        txtRackLocation.Text = ""
        txtWeight.Text = ""
        dtpDateEntry.Value = Now
        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        txtVendor.Text = ""
        'dgvMainRack.DataSource = Nothing
        rchComment.Text = ""
        txtSearch.Text = ""
        txtPartNumView.Text = ""
        txtPartDescView.Text = ""
        txtBinNumView.Text = ""
        txtWeightView.Text = ""
        txtCommentView.Text = ""
        txtVendorView.Text = ""
    End Sub

    'When loading the form, will place current division into the combobox and pull in the records associated with that division
    Private Sub ViewMaintenanceRacking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalDivisionCode = EmployeeCompanyCode

        

        LoadCurrentDivision()

        Try
            If cboDivisionID.Text = "ADM" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ALB" Then

                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ATL" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CBS" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CGO" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CHT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "DEN" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "HOU" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "SLC" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFF" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFJ" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TFT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TOR" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWD" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWE" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TST" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                dgvMainRack.DataMember = "MaintenanceRackingTable"
                con.Close()
            End If
            If (EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1003 Or EmployeeSecurityCode = 1007 Or EmployeeSecurityCode = 1015 Or GlobalDivisionCode = "TST" Or GlobalDivisionCode = "ADM") Then

                cmdAdd.Visible = True
                cmdAdd.Enabled = True
                cmdRemove.Enabled = True
                cmdRemove.Visible = True
                'dgvMainRack.Columns("PartNumberDataGridViewTextBoxColumn").ReadOnly = False
                dgvMainRack.Columns("PartDescriptionDataGridViewTextBoxColumn").ReadOnly = False
                'dgvMainRack.Columns("DivisionIDDataGridViewTextBoxColumn").ReadOnly = False
                'dgvMainRack.Columns("BinNumberDataGridViewTextBoxColumn").ReadOnly = False
                dgvMainRack.Columns("WeightDataGridViewTextBoxColumn").ReadOnly = False
                dgvMainRack.Columns("CommentDataGridViewTextBoxColumn").ReadOnly = False
                dgvMainRack.Columns("VendorDataGridViewTextBoxColumn").ReadOnly = False
                'dgvMainRack.Columns("DateDataGridViewTextBoxColumn").ReadOnly = False

            Else

                cmdAdd.Enabled = False
                cmdAdd.Visible = False
                cmdRemove.Enabled = False
                cmdRemove.Visible = False
                'dgvMainRack.Columns("PartNumberDataGridViewTextBoxColumn").ReadOnly = True
                dgvMainRack.Columns("PartDescriptionDataGridViewTextBoxColumn").ReadOnly = True
                'dgvMainRack.Columns("DivisionIDDataGridViewTextBoxColumn").ReadOnly = True
                'dgvMainRack.Columns("BinNumberDataGridViewTextBoxColumn").ReadOnly = True
                dgvMainRack.Columns("WeightDataGridViewTextBoxColumn").ReadOnly = True
                dgvMainRack.Columns("CommentDataGridViewTextBoxColumn").ReadOnly = True
                dgvMainRack.Columns("VendorDataGridViewTextBoxColumn").ReadOnly = True
                'dgvMainRack.Columns("DateDataGridViewTextBoxColumn").ReadOnly = True

            End If
        Catch ex As System.Exception
        End Try
    End Sub
    'Loads data into the table based on specifics declared in the form
    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Dim searchFilter As String
        cboDivisionID.Text = UCase(cboDivisionID.Text)
        If txtSearch.Text <> "" Then
            searchFilter = " AND (PartDescription LIKE '%" + txtSearch.Text + "%' OR Comment LIKE '%" + txtSearch.Text + "%')"
            If chkDateRange.Checked = True Then
                BeginDate = dtpBeginDate.Value
                EndDate = dtpEndDate.Value

                DateFilter = " AND Date BETWEEN @BeginDate AND @EndDate"
            Else
                DateFilter = ""
            End If
            If cboDivisionID.Text = "ADM" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable Where (DivisionID = 'TST' OR DivisionID = 'ALB' OR DivisionID = 'ATL' OR DivisionID = 'CBS' OR DivisionID = 'CGO' OR DivisionID = 'CHT' OR DivisionID = 'DEN' OR DivisionID = 'HOU' OR DivisionID = 'SLC' OR DivisionID = 'TFF' OR DivisionID = 'TFJ' OR DivisionID = 'TFT' OR DivisionID = 'TOR' OR DivisionID = 'TWD' OR DivisionID = 'TWE')" + searchFilter + DateFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()
            Else
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + searchFilter + DateFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()
            End If
        Else
            If txtPartNum.Text <> "" Then
                PartFilter = " AND PartNumber = '" + txtPartNumView.Text + "'"
            Else
                PartFilter = ""
            End If

            If txtDesc.Text <> "" Then
                DescriptionFilter = " AND PartDescription = '" + txtPartDescView.Text + "'"
            Else
                DescriptionFilter = ""
            End If

            If txtRackLocation.Text <> "" Then
                RackFilter = " AND BinNumber = '" + txtBinNumView.Text + "'"
            Else
                RackFilter = ""
            End If

            If txtWeight.Text <> "" Then
                WeightFilter = " AND Weight = '" + txtWeightView.Text + "'"
            Else
                WeightFilter = ""
            End If

            If rchComment.Text <> "" Then
                CommentFilter = " AND Comment  = '" + txtCommentView.Text + "'"
            Else
                CommentFilter = ""
            End If

            If cboDivisionID.Text <> "" Then
                DivisionFilter = " AND DivisionID = '" + cboDivisionID.Text + "'"
            Else
                DivisionFilter = ""
            End If

            If txtVendor.Text <> "" Then
                VendorFilter = " AND Vendor = '" + txtVendorView.Text + "'"
            Else
                VendorFilter = ""
            End If

            If chkDateRange.Checked = True Then
                BeginDate = dtpBeginDate.Value
                EndDate = dtpEndDate.Value

                DateFilter = " AND Date BETWEEN @BeginDate AND @EndDate"
            Else
                DateFilter = ""
            End If

            If cboDivisionID.Text = "ADM" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable Where (DivisionID = 'TST' OR DivisionID = 'ALB' OR DivisionID = 'ATL' OR DivisionID = 'CBS' OR DivisionID = 'CGO' OR DivisionID = 'CHT' OR DivisionID = 'DEN' OR DivisionID = 'HOU' OR DivisionID = 'SLC' OR DivisionID = 'TFF' OR DivisionID = 'TFJ' OR DivisionID = 'TFT' OR DivisionID = 'TOR' OR DivisionID = 'TWD' OR DivisionID = 'TWE')" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ALB" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ATL" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CBS" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CGO" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + "Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CHT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "DEN" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "HOU" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "SLC" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TFF" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TFJ" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TFT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TOR" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWD" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWE" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TST" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID" + PartFilter + DescriptionFilter + RackFilter + WeightFilter + CommentFilter + DateFilter + VendorFilter + " Order By BinNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            End If
        End If
    End Sub
    'Makes sure all fields are filled in
    Function Validation() As Boolean
        If txtPartNum.Text = "" Then
            MsgBox("Please Insert A Part Number")
            txtPartNum.Focus()
            Return False
        End If
        If txtDesc.Text = "" Then
            MsgBox("Please Insert A Part Description")
            txtDesc.Focus()
            Return False
        End If
        If txtRackLocation.Text = "" Then
            MsgBox("Please Insert A Rack Location")
            txtRackLocation.Focus()
            Return False
        End If
        If txtWeight.Text = "" Then
            MsgBox("Please Insert A Weight")
            txtWeight.Focus()
            Return False
        End If
        If cboDivisionID.Text = "" Then
            MsgBox("Please Choose A Division")
            cboDivisionID.Focus()
            Return False
        End If
        If txtVendor.Text = "" Then
            MsgBox("Please Choose A Vendor")
            txtVendor.Focus()
            Return False
        End If
        
        Return True
    End Function
    'Adds or updates the records into the sql database and the table
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        cboDivisionID.Text = UCase(cboDivisionID.Text)
        If Validation() Then
            Dim exists As Boolean = False
            Dim autho As Integer = 0
            Dim ItemDataStatement As String = "SELECT BinNumber FROM MaintenanceRackingTable WHERE BinNumber = @BinNumber"
            Dim ItemDataCommand As New SqlCommand(ItemDataStatement, con)
            ItemDataCommand.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = txtRackLocation.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Using reader As SqlDataReader = ItemDataCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("BinNumber")) Then
                        autho = 0
                    Else
                        autho = reader.Item("BinNumber")
                    End If
                End If
                reader.Close()
            End Using

            Dim chosenautho = txtRackLocation.Text
            Dim comString = autho.ToString
            Dim length As Integer = comString.Length

            Dim exists2 As Boolean = False
            Dim autho2 As String = ""

            Dim ItemDataStatement2 As String = "SELECT PartNumber FROM MaintenanceRackingTable WHERE PartNumber = @PartNumber"
            Dim ItemDataCommand2 As New SqlCommand(ItemDataStatement2, con)
            ItemDataCommand2.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNum.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Using reader As SqlDataReader = ItemDataCommand2.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("PartNumber")) Then
                        autho2 = 0
                    Else
                        autho2 = reader.Item("PartNumber")
                    End If
                End If
                reader.Close()
            End Using

            Dim chosenautho2 = txtPartNum.Text
            Dim comString2 = autho2
            Dim length2 As Integer = comString2.Length

            If chosenautho = comString And chosenautho2 = comString2 Then
                'update

                cmd = New SqlCommand("UPDATE MaintenanceRackingTable SET PartDescription = @PartDescription, DivisionID = @DivisionID, Weight = @Weight, Comment = @Comment, Vendor = @Vendor, Date = @Date WHERE BinNumber = @BinNumber AND PartNumber = @PartNumberOld", con)
                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNum.Text
                    .Add("@Date", SqlDbType.VarChar).Value = dtpDateEntry.Value
                    .Add("@PartDescription", SqlDbType.VarChar).Value = txtDesc.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Weight", SqlDbType.VarChar).Value = txtWeight.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = rchComment.Text
                    .Add("@Vendor", SqlDbType.VarChar).Value = txtVendor.Text
                    .Add("@BinNumber", SqlDbType.VarChar).Value = txtRackLocation.Text
                    .Add("@PartNumberOld", SqlDbType.VarChar).Value = txtPartNum.Text
                End With
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Updated Bin")

            Else
                'insert
                cmd = New SqlCommand("INSERT INTO MaintenanceRackingTable (PartNumber, Date, PartDescription, DivisionID, Weight, Comment, Vendor, BinNumber)Values(@PartNumber, @Date, @PartDescription, @DivisionID, @Weight, @Comment, @Vendor, @BinNumber)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNum.Text
                    .Add("@Date", SqlDbType.VarChar).Value = dtpDateEntry.Value
                    .Add("@PartDescription", SqlDbType.VarChar).Value = txtDesc.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Weight", SqlDbType.VarChar).Value = txtWeight.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = rchComment.Text
                    .Add("@Vendor", SqlDbType.VarChar).Value = txtVendor.Text
                    .Add("@BinNumber", SqlDbType.VarChar).Value = txtRackLocation.Text

                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Saved New Bin")
            End If
        End If
        cleardata()
        LoadCurrentDivision()
        Try
            If cboDivisionID.Text = "ADM" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ALB" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ATL" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CBS" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CGO" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CHT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "DEN" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "HOU" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "SLC" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFF" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFJ" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TFT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TOR" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWD" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWE" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TST" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                dgvMainRack.DataMember = "MaintenanceRackingTable"
                con.Close()
            End If
        Catch ex As System.Exception
        End Try
        LoadCurrentDivision()
    End Sub
    'Removes record from the table where the part number and bin number are the same
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        'Delete Data in the MaintenanceRackingTable
        Try
            cmd = New SqlCommand("DELETE FROM MaintenanceRackingTable WHERE BinNumber = @BinNumber AND PartNumber = @PartNumber", con)
            cmd.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = txtRackLocation.Text
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNum.Text
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Record Deleted")
        Catch ex As System.Exception
            MsgBox("Record Does Not Exists")

        End Try
        LoadCurrentDivision()
        
        Try
            If cboDivisionID.Text = "ADM" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ALB" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ATL" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CBS" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CGO" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CHT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "DEN" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "HOU" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "SLC" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFF" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFJ" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TFT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TOR" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWD" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWE" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TST" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                dgvMainRack.DataMember = "MaintenanceRackingTable"
                con.Close()
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    'Calls the cleardata function to clear all of the inputed fields
    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cleardata()
        cboDivisionID.Text = UCase(cboDivisionID.Text)
        Try
            If cboDivisionID.Text = "ADM" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ALB" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ATL" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CBS" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CGO" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CHT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "DEN" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "HOU" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "SLC" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFF" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFJ" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TFT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TOR" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWD" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWE" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TST" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                dgvMainRack.DataMember = "MaintenanceRackingTable"
                con.Close()
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    'Repulls data into the table based on division
    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        dgvMainRack.DataSource = Nothing
        Try
            If cboDivisionID.Text = "ADM" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ALB" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ATL" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CBS" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CGO" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CHT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "DEN" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "HOU" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "SLC" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFF" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFJ" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TFT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TOR" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWD" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWE" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TST" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                dgvMainRack.DataMember = "MaintenanceRackingTable"
                con.Close()
            End If
        Catch ex As System.Exception
        End Try
    End Sub
    'Loads the row clicked on's data into the fields for modification and deletion
    Private Sub dgvMainRack_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMainRack.CellClick
        If dgvMainRack.RowCount > 0 Then
            Try
                Dim RowIndex As Integer = Me.dgvMainRack.CurrentCell.RowIndex
                Dim part, desc, datee, bin, comment, weight, vendor As String
                part = Me.dgvMainRack.Rows(RowIndex).Cells("PartNumberDataGridViewTextBoxColumn").Value.ToString()
                desc = Me.dgvMainRack.Rows(RowIndex).Cells("PartDescriptionDataGridViewTextBoxColumn").Value.ToString()
                datee = Me.dgvMainRack.Rows(RowIndex).Cells("DateDataGridViewTextBoxColumn").Value.ToString()
                bin = Me.dgvMainRack.Rows(RowIndex).Cells("BinNumberDataGridViewTextBoxColumn").Value.ToString()
                comment = Me.dgvMainRack.Rows(RowIndex).Cells("CommentDataGridViewTextBoxColumn").Value.ToString()
                weight = Me.dgvMainRack.Rows(RowIndex).Cells("WeightDataGridViewTextBoxColumn").Value.ToString()
                vendor = Me.dgvMainRack.Rows(RowIndex).Cells("VendorDataGridViewTextBoxColumn").Value.ToString()
                txtPartNum.Text = part
                txtDesc.Text = desc
                dtpDateEntry.Value = Convert.ToDateTime(datee)
                txtRackLocation.Text = bin
                rchComment.Text = comment
                txtWeight.Text = weight
                txtVendor.Text = vendor
                If Me.dgvMainRack.Rows(RowIndex).Cells("DivisionIDDataGridViewTextBoxColumn").Value.ToString() = "" Then
                    cboDivisionID.Text = GlobalDivisionCode
                Else
                    cboDivisionID.Text = Me.dgvMainRack.Rows(RowIndex).Cells("DivisionIDDataGridViewTextBoxColumn").Value.ToString()
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cboDivisionID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDivisionID.TextChanged
        dgvMainRack.DataSource = Nothing
        Try
            If cboDivisionID.Text = "ADM" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ALB" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ATL" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CBS" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CGO" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CHT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "DEN" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "HOU" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "SLC" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFF" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFJ" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TFT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TOR" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWD" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWE" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TST" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                dgvMainRack.DataMember = "MaintenanceRackingTable"
                con.Close()
            End If
        Catch ex As System.Exception
        End Try

        SendKeys.Send("{End}")
    End Sub
    'Opens up the report that
    Private Sub cmdViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewReport.Click
        Dim NewVendorInformation As New PrintMaintenanceRackingReport
        NewVendorInformation.Show()
    End Sub

    Private Sub cmdViewAll_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAll.Click
        cboDivisionID.Text = UCase(cboDivisionID.Text)
        Try
            If cboDivisionID.Text = "ADM" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ALB" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ATL" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CBS" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CGO" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CHT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "DEN" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "HOU" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "SLC" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFF" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFJ" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TFT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TOR" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWD" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWE" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TST" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                dgvMainRack.DataMember = "MaintenanceRackingTable"
                con.Close()
            End If
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub dgvMainRack_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMainRack.CellValueChanged
        Dim partNumber, partDescription, comment, vendor, binNumber, divisionID As String
        Dim weight As Decimal = 0
        If (EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1003 Or EmployeeSecurityCode = 1007 Or EmployeeSecurityCode = 1015 Or GlobalDivisionCode = "TST" Or GlobalDivisionCode = "ADM") Then
            If Me.dgvMainRack.RowCount <> 0 Then
                Dim rowIndex As Integer = Me.dgvMainRack.CurrentCell.RowIndex

                Try
                    partNumber = Me.dgvMainRack.Rows(rowIndex).Cells("PartNumberDataGridViewTextBoxColumn").Value
                Catch ex As Exception
                    partNumber = ""
                End Try

                Try
                    partDescription = Me.dgvMainRack.Rows(rowIndex).Cells("PartDescriptionDataGridViewTextBoxColumn").Value
                Catch ex As Exception
                    partDescription = ""
                End Try

                Try
                    comment = Me.dgvMainRack.Rows(rowIndex).Cells("CommentDataGridViewTextBoxColumn").Value
                Catch ex As Exception
                    comment = ""
                End Try

                Try
                    vendor = Me.dgvMainRack.Rows(rowIndex).Cells("VendorDataGridViewTextBoxColumn").Value
                Catch ex As Exception
                    vendor = ""
                End Try

                Try
                    binNumber = Me.dgvMainRack.Rows(rowIndex).Cells("BinNumberDataGridViewTextBoxColumn").Value
                Catch ex As Exception
                    binNumber = ""
                End Try

                Try
                    divisionID = Me.dgvMainRack.Rows(rowIndex).Cells("DivisionIDDataGridViewTextBoxColumn").Value
                Catch ex As Exception
                    divisionID = ""
                End Try

                Try
                    weight = Me.dgvMainRack.Rows(rowIndex).Cells("WeightDataGridViewTextBoxColumn").Value
                Catch ex As Exception
                    weight = 0
                End Try
                Try
                    'UPDATE Maintenance Racking Table based on 
                    cmd = New SqlCommand("UPDATE MaintenanceRackingTable SET PartDescription = @PartDescription, Weight = @Weight, Comment = @Comment, Vendor = @Vendor WHERE PartNumber = @PartNumber AND BinNumber = @BinNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PartNumber", SqlDbType.VarChar).Value = partNumber
                        .Add("@PartDescription", SqlDbType.VarChar).Value = partDescription
                        .Add("@Weight", SqlDbType.VarChar).Value = weight
                        .Add("@Comment", SqlDbType.VarChar).Value = comment
                        .Add("@BinNumber", SqlDbType.VarChar).Value = binNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = divisionID
                        .Add("@Vendor", SqlDbType.VarChar).Value = vendor
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()


                Catch ex As System.Exception

                End Try
            End If

        End If

        cleardata()
        LoadCurrentDivision()
        Try
            If cboDivisionID.Text = "ADM" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ALB" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "ATL" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CBS" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CGO" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "CHT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "DEN" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "HOU" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "SLC" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFF" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()


            ElseIf cboDivisionID.Text = "TFJ" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TFT" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TOR" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWD" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TWE" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                con.Close()

            ElseIf cboDivisionID.Text = "TST" Then
                cmd = New SqlCommand("SELECT * FROM MaintenanceRackingTable WHERE DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "MaintenanceRackingTable")
                dgvMainRack.DataSource = ds.Tables("MaintenanceRackingTable")
                dgvMainRack.DataMember = "MaintenanceRackingTable"
                con.Close()
            End If
        Catch ex As System.Exception
        End Try
        LoadCurrentDivision()
    End Sub
End Class