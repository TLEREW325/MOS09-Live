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
Public Class EquipmentProductionScheduling
    Inherits System.Windows.Forms.Form

    'Set up variables and database connection
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")

    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable
    Dim TWDDataset As DataSet
    Dim TWDAdapter As New SqlDataAdapter

    Dim BeginDate As Date
    Dim EndDate As Date

    Private Sub EquipmentProductionScheduling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()
        LoadItemClass()
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

    Public Sub ShowData()
        'Load Datagrid
        cmd = New SqlCommand("SELECT * FROM ADMInventoryTotal WHERE DivisionID = @DivisionID AND FOXNumber <> 0 AND OpenSOQuantity <> 0 AND (ItemClass LIKE 'TWE%' OR ItemClass = 'TW WELD PROD') ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ADMInventoryTotal")
        dgvEquipmentScheduling.DataSource = ds.Tables("ADMInventoryTotal")
        con.Close()
    End Sub

    Public Sub ShowDataByFilter()
        'Load Datagrid
        cmd = New SqlCommand("SELECT * FROM ADMInventoryTotal WHERE DivisionID = @DivisionID AND FOXNumber <> 0 AND ItemClass = @ItemClass AND OpenSOQuantity <> 0 ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ADMInventoryTotal")
        dgvEquipmentScheduling.DataSource = ds.Tables("ADMInventoryTotal")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvEquipmentScheduling.DataSource = Nothing
    End Sub

    Public Sub LoadItemClass()
        'Load Datagrid
        cmd = New SqlCommand("SELECT ItemClassID FROM ItemClass WHERE ItemClassID = 'TW WELD PROD' OR ItemClassID = 'TWE ASSEMBLIES' OR ItemClassID = 'TWE CD COMPONENTS' OR ItemClassID = 'TWE GENERATORS' OR ItemClassID = 'TWE STUD EQUIP COMP'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemClass")
        cboItemClass.DataSource = ds1.Tables("ItemClass")
        con.Close()
        cboItemClass.SelectedIndex = -1
    End Sub

    Private Sub cmdLoadDatagrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadDatagrid.Click
        ClearDataInDatagrid()

        If cboItemClass.Text = "" Then
            ShowData()
            LoadProductionVariables()
        Else
            ShowDataByFilter()
            LoadProductionVariables()
        End If
    End Sub

    Public Sub DefineDateRange()
        Dim TodaysDate As Date = Today
        Dim intMonth As Integer = TodaysDate.Month
        Dim intYear As Integer = TodaysDate.Year
        Dim intYearMinusOne As Integer = intYear - 1
        Dim strYear As String = CStr(intYear)
        Dim strYearMinusOne As String = CStr(intYearMinusOne)

        Select Case intMonth
            Case 1
                BeginDate = "12/1/" + strYearMinusOne
                EndDate = "12/31/" + strYearMinusOne
            Case 2
                BeginDate = "1/1/" + strYear
                EndDate = "1/31/" + strYear
            Case 3
                BeginDate = "2/1/" + strYear
                EndDate = "2/28/" + strYear
            Case 4
                BeginDate = "3/1/" + strYear
                EndDate = "3/31/" + strYear
            Case 5
                BeginDate = "4/1/" + strYear
                EndDate = "4/30/" + strYear
            Case 6
                BeginDate = "5/1/" + strYear
                EndDate = "5/31/" + strYear
            Case 7
                BeginDate = "6/1/" + strYear
                EndDate = "6/30/" + strYear
            Case 8
                BeginDate = "7/1/" + strYear
                EndDate = "7/31/" + strYear
            Case 9
                BeginDate = "8/1/" + strYear
                EndDate = "8/31/" + strYear
            Case 10
                BeginDate = "9/1/" + strYear
                EndDate = "9/30/" + strYear
            Case 11
                BeginDate = "10/1/" + strYear
                EndDate = "10/31/" + strYear
            Case 12
                BeginDate = "11/1/" + strYear
                EndDate = "11/30/" + strYear
        End Select
    End Sub

    Public Sub LoadProductionVariables()
        Dim RowPartNumber As String = ""
        Dim RowQOH As Double = 0

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvEquipmentScheduling.Rows
            Try
                RowPartNumber = row.Cells("ItemIDColumn").Value
            Catch ex As System.Exception
                RowPartNumber = ""
            End Try
            Try
                RowQOH = row.Cells("QuantityOnHandColumn").Value
            Catch ex As System.Exception
                RowQOH = 0
            End Try

            'Get Specific Data for Part
            Dim GetTWEQOH As Integer = 0
            Dim GetTWEOpenPOQuantity As Integer = 0

            Dim GetTWEQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetTWEQOHCommand As New SqlCommand(GetTWEQOHStatement, con)
            GetTWEQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            GetTWEQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

            Dim GetTWEOpenPOQuantityStatement As String = "SELECT OpenPOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetTWEOpenPOQuantityCommand As New SqlCommand(GetTWEOpenPOQuantityStatement, con)
            GetTWEOpenPOQuantityCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            GetTWEOpenPOQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetTWEQOH = CInt(GetTWEQOHCommand.ExecuteScalar)
            Catch ex As Exception
                GetTWEQOH = 0
            End Try
            Try
                GetTWEOpenPOQuantity = CInt(GetTWEOpenPOQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                GetTWEOpenPOQuantity = 0
            End Try
            con.Close()

            'Get Last Month Shipped
            DefineDateRange()

            Dim GetQuantityShippedLastMonth As Double = 0
            Dim GetQuantityAssembledLastMonth As Double = 0

            Dim GetQuantityShippedLastMonthStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipmentStatus <> 'PENDING' AND ShipDate BETWEEN @BeginDate AND @EndDate"
            Dim GetQuantityShippedLastMonthCommand As New SqlCommand(GetQuantityShippedLastMonthStatement, con)
            GetQuantityShippedLastMonthCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
            GetQuantityShippedLastMonthCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
            GetQuantityShippedLastMonthCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            GetQuantityShippedLastMonthCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim GetQuantityAssembledLastMonthStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND ComponentPartNumber <> AssemblyPartNumber AND DivisionID = @DivisionID AND BuildDate BETWEEN @BeginDate AND @EndDate"
            Dim GetQuantityAssembledLastMonthCommand As New SqlCommand(GetQuantityAssembledLastMonthStatement, con)
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = RowPartNumber
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetQuantityShippedLastMonth = CDbl(GetQuantityShippedLastMonthCommand.ExecuteScalar)
            Catch ex As Exception
                GetQuantityShippedLastMonth = 0
            End Try
            Try
                GetQuantityAssembledLastMonth = CDbl(GetQuantityAssembledLastMonthCommand.ExecuteScalar)
                GetQuantityAssembledLastMonth = GetQuantityAssembledLastMonth * -1
            Catch ex As Exception
                GetQuantityAssembledLastMonth = 0
            End Try
            con.Close()

            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("TWEQOHColumn").Value = GetTWEQOH
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("TWEPOQtyColumn").Value = GetTWEOpenPOQuantity
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("MonthShippedColumn").Value = GetQuantityShippedLastMonth
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("AssemblyQuantityColumn").Value = GetQuantityAssembledLastMonth
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("TWEUsageColumn").Value = GetQuantityAssembledLastMonth + GetQuantityShippedLastMonth

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvEquipmentScheduling_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvEquipmentScheduling.ColumnHeaderMouseClick
        Dim RowPartNumber As String = ""
        Dim RowQOH As Double = 0

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvEquipmentScheduling.Rows
            Try
                RowPartNumber = row.Cells("ItemIDColumn").Value
            Catch ex As System.Exception
                RowPartNumber = ""
            End Try
            Try
                RowQOH = row.Cells("QuantityOnHandColumn").Value
            Catch ex As System.Exception
                RowQOH = 0
            End Try

            'Get Specific Data for Part
            Dim GetTWEQOH As Integer = 0
            Dim GetTWEOpenPOQuantity As Integer = 0

            Dim GetTWEQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetTWEQOHCommand As New SqlCommand(GetTWEQOHStatement, con)
            GetTWEQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            GetTWEQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

            Dim GetTWEOpenPOQuantityStatement As String = "SELECT OpenPOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetTWEOpenPOQuantityCommand As New SqlCommand(GetTWEOpenPOQuantityStatement, con)
            GetTWEOpenPOQuantityCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            GetTWEOpenPOQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetTWEQOH = CInt(GetTWEQOHCommand.ExecuteScalar)
            Catch ex As Exception
                GetTWEQOH = 0
            End Try
            Try
                GetTWEOpenPOQuantity = CInt(GetTWEOpenPOQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                GetTWEOpenPOQuantity = 0
            End Try
            con.Close()

            'Get Last Month Shipped
            DefineDateRange()

            Dim GetQuantityShippedLastMonth As Double = 0
            Dim GetQuantityAssembledLastMonth As Double = 0

            Dim GetQuantityShippedLastMonthStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipmentStatus <> 'PENDING' AND ShipDate BETWEEN @BeginDate AND @EndDate"
            Dim GetQuantityShippedLastMonthCommand As New SqlCommand(GetQuantityShippedLastMonthStatement, con)
            GetQuantityShippedLastMonthCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
            GetQuantityShippedLastMonthCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
            GetQuantityShippedLastMonthCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            GetQuantityShippedLastMonthCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim GetQuantityAssembledLastMonthStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND ComponentPartNumber <> AssemblyPartNumber AND DivisionID = @DivisionID AND BuildDate BETWEEN @BeginDate AND @EndDate"
            Dim GetQuantityAssembledLastMonthCommand As New SqlCommand(GetQuantityAssembledLastMonthStatement, con)
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = RowPartNumber
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetQuantityShippedLastMonth = CDbl(GetQuantityShippedLastMonthCommand.ExecuteScalar)
            Catch ex As Exception
                GetQuantityShippedLastMonth = 0
            End Try
            Try
                GetQuantityAssembledLastMonth = CDbl(GetQuantityAssembledLastMonthCommand.ExecuteScalar)
                GetQuantityAssembledLastMonth = GetQuantityAssembledLastMonth * -1
            Catch ex As Exception
                GetQuantityAssembledLastMonth = 0
            End Try
            con.Close()

            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("TWEQOHColumn").Value = GetTWEQOH
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("TWEPOQtyColumn").Value = GetTWEOpenPOQuantity
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("MonthShippedColumn").Value = GetQuantityShippedLastMonth
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("AssemblyQuantityColumn").Value = GetQuantityAssembledLastMonth
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("TWEUsageColumn").Value = GetQuantityAssembledLastMonth + GetQuantityShippedLastMonth

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub dgvEquipmentScheduling_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvEquipmentScheduling.Sorted
        Dim RowPartNumber As String = ""
        Dim RowQOH As Double = 0

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvEquipmentScheduling.Rows
            Try
                RowPartNumber = row.Cells("ItemIDColumn").Value
            Catch ex As System.Exception
                RowPartNumber = ""
            End Try
            Try
                RowQOH = row.Cells("QuantityOnHandColumn").Value
            Catch ex As System.Exception
                RowQOH = 0
            End Try

            'Get Specific Data for Part
            Dim GetTWEQOH As Integer = 0
            Dim GetTWEOpenPOQuantity As Integer = 0

            Dim GetTWEQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetTWEQOHCommand As New SqlCommand(GetTWEQOHStatement, con)
            GetTWEQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            GetTWEQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

            Dim GetTWEOpenPOQuantityStatement As String = "SELECT OpenPOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetTWEOpenPOQuantityCommand As New SqlCommand(GetTWEOpenPOQuantityStatement, con)
            GetTWEOpenPOQuantityCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
            GetTWEOpenPOQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetTWEQOH = CInt(GetTWEQOHCommand.ExecuteScalar)
            Catch ex As Exception
                GetTWEQOH = 0
            End Try
            Try
                GetTWEOpenPOQuantity = CInt(GetTWEOpenPOQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                GetTWEOpenPOQuantity = 0
            End Try
            con.Close()

            'Get Last Month Shipped
            DefineDateRange()

            Dim GetQuantityShippedLastMonth As Double = 0
            Dim GetQuantityAssembledLastMonth As Double = 0

            Dim GetQuantityShippedLastMonthStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipmentStatus <> 'PENDING' AND ShipDate BETWEEN @BeginDate AND @EndDate"
            Dim GetQuantityShippedLastMonthCommand As New SqlCommand(GetQuantityShippedLastMonthStatement, con)
            GetQuantityShippedLastMonthCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
            GetQuantityShippedLastMonthCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
            GetQuantityShippedLastMonthCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            GetQuantityShippedLastMonthCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim GetQuantityAssembledLastMonthStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND ComponentPartNumber <> AssemblyPartNumber AND DivisionID = @DivisionID AND BuildDate BETWEEN @BeginDate AND @EndDate"
            Dim GetQuantityAssembledLastMonthCommand As New SqlCommand(GetQuantityAssembledLastMonthStatement, con)
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = RowPartNumber
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            GetQuantityAssembledLastMonthCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetQuantityShippedLastMonth = CDbl(GetQuantityShippedLastMonthCommand.ExecuteScalar)
            Catch ex As Exception
                GetQuantityShippedLastMonth = 0
            End Try
            Try
                GetQuantityAssembledLastMonth = CDbl(GetQuantityAssembledLastMonthCommand.ExecuteScalar)
                GetQuantityAssembledLastMonth = GetQuantityAssembledLastMonth * -1
            Catch ex As Exception
                GetQuantityAssembledLastMonth = 0
            End Try
            con.Close()

            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("TWEQOHColumn").Value = GetTWEQOH
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("TWEPOQtyColumn").Value = GetTWEOpenPOQuantity
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("MonthShippedColumn").Value = GetQuantityShippedLastMonth
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("AssemblyQuantityColumn").Value = GetQuantityAssembledLastMonth
            Me.dgvEquipmentScheduling.Rows(RowIndex).Cells("TWEUsageColumn").Value = GetQuantityAssembledLastMonth + GetQuantityShippedLastMonth

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub cmdPrintListing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintListing.Click
        'Copy data to temp table

        'Delete temp data first
        cmd = New SqlCommand("DELETE FROM EquipmentProductionTempTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Add Lines to temp table
        Dim RowPartNumber, RowFOXNumber, RowPartDescription As String
        Dim RowTWEQOH, RowTWDQOH, RowOpenPOQuantity, RowOpenSOQuantity, RowTWEShippedLM, RowTWEAssembledLM, RowTotalUsageLM As Double

        For Each row As DataGridViewRow In dgvEquipmentScheduling.Rows
            Try
                RowPartNumber = row.Cells("ItemIDColumn").Value
            Catch ex As System.Exception
                RowPartNumber = ""
            End Try
            Try
                RowFOXNumber = row.Cells("FOXNumberColumn").Value
            Catch ex As System.Exception
                RowFOXNumber = ""
            End Try
            Try
                RowPartDescription = row.Cells("ShortDescriptionColumn").Value
            Catch ex As System.Exception
                RowPartDescription = ""
            End Try
            Try
                RowTWDQOH = row.Cells("QuantityOnHandColumn").Value
            Catch ex As System.Exception
                RowTWDQOH = 0
            End Try
            Try
                RowTWEQOH = row.Cells("TWEQOHColumn").Value
            Catch ex As System.Exception
                RowTWEQOH = 0
            End Try
            Try
                RowOpenPOQuantity = row.Cells("TWEPOQtyColumn").Value
            Catch ex As System.Exception
                RowOpenPOQuantity = 0
            End Try
            Try
                RowOpenSOQuantity = row.Cells("OpenSOQuantityColumn").Value
            Catch ex As System.Exception
                RowOpenSOQuantity = 0
            End Try
            Try
                RowTWEShippedLM = row.Cells("MonthShippedColumn").Value
            Catch ex As System.Exception
                RowTWEShippedLM = 0
            End Try
            Try
                RowTWEAssembledLM = row.Cells("AssemblyQuantityColumn").Value
            Catch ex As System.Exception
                RowTWEAssembledLM = 0
            End Try
            Try
                RowTotalUsageLM = row.Cells("TWEUsageColumn").Value
            Catch ex As System.Exception
                RowTotalUsageLM = 0
            End Try

            'Insert Into Temp Table
            cmd = New SqlCommand("INSERT INTO EquipmentProductionTempTable (DivisionID, FOXNumber, PartNumber, PartDescription, TWEQOH, TWDQOH, OpenPOQuantity, OpenSOQuantity, TWEShippedLM, TWEAssembledLM, TotalUsageLM) values (@DivisionID, @FOXNumber, @PartNumber, @PartDescription, @TWEQOH, @TWDQOH, @OpenPOQuantity, @OpenSOQuantity, @TWEShippedLM, @TWEAssembledLM, @TotalUsageLM)", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber
                .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                .Add("@PartDescription", SqlDbType.VarChar).Value = RowPartDescription
                .Add("@TWEQOH", SqlDbType.VarChar).Value = RowTWEQOH
                .Add("@TWDQOH", SqlDbType.VarChar).Value = RowTWDQOH
                .Add("@OpenPOQuantity", SqlDbType.VarChar).Value = RowOpenPOQuantity
                .Add("@OpenSOQuantity", SqlDbType.VarChar).Value = RowOpenSOQuantity
                .Add("@TWEShippedLM", SqlDbType.VarChar).Value = RowTWEShippedLM
                .Add("@TWEAssembledLM", SqlDbType.VarChar).Value = RowTWEAssembledLM
                .Add("@TotalUsageLM", SqlDbType.VarChar).Value = RowTotalUsageLM
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next

        Using NewPrintEquipmentProduction As New PrintEquipmentProduction
            Dim Result = NewPrintEquipmentProduction.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrintListing_Click(sender, e)
    End Sub
End Class