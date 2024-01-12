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
Public Class ViewTimeSlips
    Inherits System.Windows.Forms.Form

    Dim DivisionFilter, EmployeeIDFilter, FOXFilter, RMIDFilter, PartFilter, PartTextFilter, DateFilter, MachineFilter, FinishedGoodsFiter, TextFilter As String
    Dim FOXNumber As Integer = 0
    Dim strFOXNumber As String = ""
    Dim BeginDate, EndDate As String
    Dim GetRMID As String = ""
    Dim TotalInventoryPieces As Integer = 0
    Dim TotalSteelCost, TotalOverheadCost, TotalCost, TotalProductionQuantity, TotalLineWeight As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewTimeSlips_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.MachineTable' table. You can move, or remove it, as needed.
        Me.MachineTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.MachineTable)

        LoadCurrentDivision()

        ClearData()
        ClearVariables()
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

    Public Sub ShowDataByFilters()
        Dim LoadCombinedDivision As String = ""

        If cboDivisionID.Text = "ADM" Then
            DivisionFilter = "DivisionID <> 'TST'"
        Else
            DivisionFilter = "DivisionID = '" + cboDivisionID.Text + "'"
        End If
        If cboFOXNumber.Text <> "" Then
            FOXNumber = Val(cboFOXNumber.Text)
            strFOXNumber = CStr(FOXNumber)
            FOXFilter = " AND FOXNumber = '" + strFOXNumber + "'"
        Else
            FOXFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If

        LoadRMID()

        If GetRMID <> "" Then
            RMIDFilter = " AND RMID = '" + GetRMID + "'"
        Else
            RMIDFilter = ""
        End If
        If cboMachineNumber.Text <> "" Then
            MachineFilter = " AND MachineNumber = '" + cboMachineNumber.Text + "'"
        Else
            MachineFilter = ""
        End If
        If txtEmployeeNumber.Text <> "" Then
            EmployeeIDFilter = " AND EmployeeID = '" + txtEmployeeNumber.Text + "'"
        Else
            EmployeeIDFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND EmployeeName LIKE '%" + txtTextFilter.Text + "%'"
        Else
            TextFilter = ""
        End If
        If txtPartTextFilter.Text <> "" Then
            PartTextFilter = " AND PartNumber LIKE '%" + txtPartTextFilter.Text + "%'"
        Else
            PartTextFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND PostingDate BETWEEN @BeginDate AND @EndDate"
        End If
        If chkShowFG.Checked = False Then
            FinishedGoodsFiter = ""
        Else
            FinishedGoodsFiter = " AND InventoryPieces > 0"
        End If

        cmd = New SqlCommand("SELECT * FROM TimeSlipCombinedData WHERE " + DivisionFilter + FOXFilter + PartFilter + EmployeeIDFilter + PartTextFilter + RMIDFilter + TextFilter + FinishedGoodsFiter + MachineFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "TimeSlipCombinedData")
        dgvTimeSlipPostings.DataSource = ds.Tables("TimeSlipCombinedData")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvTimeSlipPostings.DataSource = Nothing
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "FOXTable")
        cboFOXNumber.DataSource = ds1.Tables("FOXTable")
        con.Close()
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartNumber.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID Order BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboPartDescription.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT(Carbon) FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY Carbon", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "RawMaterialsTable")
        cboSteelCarbon.DataSource = ds4.Tables("RawMaterialsTable")
        con.Close()
        cboSteelCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT(SteelSize) FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY SteelSize", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "RawMaterialsTable")
        cboSteelSize.DataSource = ds5.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadRMID()
        Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
        GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboSteelCarbon.Text
        GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetRMID = CStr(GetRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            GetRMID = ""
        End Try
        con.Close()
    End Sub

    Public Sub LoadTotals()
        If cboDivisionID.Text = "ADM" Then
            DivisionFilter = "DivisionID <> 'TST'"
        Else
            DivisionFilter = "DivisionID = '" + cboDivisionID.Text + "'"
        End If
        If cboFOXNumber.Text <> "" Then
            FOXNumber = Val(cboFOXNumber.Text)
            strFOXNumber = CStr(FOXNumber)
            FOXFilter = " AND FOXNumber = '" + strFOXNumber + "'"
        Else
            FOXFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        LoadRMID()
        If GetRMID <> "" Then
            RMIDFilter = " AND RMID = '" + GetRMID + "'"
        Else
            RMIDFilter = ""
        End If
        If cboMachineNumber.Text <> "" Then
            MachineFilter = " AND MachineNumber = '" + cboMachineNumber.Text + "'"
        Else
            MachineFilter = ""
        End If
        If txtEmployeeNumber.Text <> "" Then
            EmployeeIDFilter = " AND EmployeeID = '" + txtEmployeeNumber.Text + "'"
        Else
            EmployeeIDFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND EmployeeName LIKE '%" + txtTextFilter.Text + "%'"
        Else
            TextFilter = ""
        End If
        If txtPartTextFilter.Text <> "" Then
            PartTextFilter = " AND PartNumber LIKE '%" + txtPartTextFilter.Text + "%'"
        Else
            PartTextFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND PostingDate BETWEEN @BeginDate AND @EndDate"
        End If
        If chkShowFG.Checked = False Then
            FinishedGoodsFiter = ""
        Else
            FinishedGoodsFiter = " AND InventoryPieces > 0"
        End If

        Dim TotalInventoryPiecesStatement As String = "SELECT SUM(InventoryPieces) FROM TimeSlipCombinedData WHERE " + DivisionFilter + FOXFilter + PartFilter + PartTextFilter + EmployeeIDFilter + RMIDFilter + TextFilter + FinishedGoodsFiter + MachineFilter + DateFilter
        Dim TotalInventoryPiecesCommand As New SqlCommand(TotalInventoryPiecesStatement, con)
        TotalInventoryPiecesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalInventoryPiecesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalInventoryPiecesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalSteelCostStatement As String = "SELECT SUM(ExtendedSteelCost) FROM TimeSlipCombinedData WHERE " + DivisionFilter + FOXFilter + PartFilter + PartTextFilter + EmployeeIDFilter + RMIDFilter + TextFilter + FinishedGoodsFiter + MachineFilter + DateFilter
        Dim TotalSteelCostCommand As New SqlCommand(TotalSteelCostStatement, con)
        TotalSteelCostCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalSteelCostCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalSteelCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalOverheadeCostStatement As String = "SELECT SUM(ExtendedCost) FROM TimeSlipCombinedData WHERE " + DivisionFilter + FOXFilter + PartFilter + PartTextFilter + EmployeeIDFilter + RMIDFilter + TextFilter + FinishedGoodsFiter + MachineFilter + DateFilter
        Dim TotalOverheadeCostCommand As New SqlCommand(TotalOverheadeCostStatement, con)
        TotalOverheadeCostCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalOverheadeCostCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalOverheadeCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalProductionPiecesStatement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipCombinedData WHERE FOXStep <> 0 AND " + DivisionFilter + FOXFilter + PartFilter + PartTextFilter + EmployeeIDFilter + RMIDFilter + TextFilter + FinishedGoodsFiter + MachineFilter + DateFilter
        Dim TotalProductionPiecesCommand As New SqlCommand(TotalProductionPiecesStatement, con)
        TotalProductionPiecesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalProductionPiecesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalProductionPiecesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalSteelWeightStatement As String = "SELECT SUM(LineWeight) FROM TimeSlipCombinedData WHERE FOXStep <> 0 AND " + DivisionFilter + FOXFilter + PartFilter + PartTextFilter + EmployeeIDFilter + RMIDFilter + TextFilter + FinishedGoodsFiter + MachineFilter + DateFilter
        Dim TotalSteelWeightCommand As New SqlCommand(TotalSteelWeightStatement, con)
        TotalSteelWeightCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalSteelWeightCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalSteelWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalInventoryPieces = CInt(TotalInventoryPiecesCommand.ExecuteScalar)
        Catch ex As Exception
            TotalInventoryPieces = 0
        End Try
        Try
            TotalSteelCost = CDbl(TotalSteelCostCommand.ExecuteScalar)
        Catch ex As Exception
            TotalSteelCost = 0
        End Try
        Try
            TotalOverheadCost = CDbl(TotalOverheadeCostCommand.ExecuteScalar)
        Catch ex As Exception
            TotalOverheadCost = 0
        End Try
        Try
            TotalProductionQuantity = CDbl(TotalProductionPiecesCommand.ExecuteScalar)
        Catch ex As Exception
            TotalProductionQuantity = 0
        End Try
        Try
            TotalLineWeight = CDbl(TotalSteelWeightCommand.ExecuteScalar)
        Catch ex As Exception
            TotalLineWeight = 0
        End Try
        con.Close()

        TotalCost = TotalSteelCost + TotalOverheadCost

        txtTotalInventoryPieces.Text = FormatNumber(TotalInventoryPieces, 0)
        txtTotalSteelWeight.Text = FormatNumber(TotalLineWeight, 1)
        txtTotalOtherCost.Text = FormatCurrency(TotalOverheadCost, 2)
        txtTotalSteelCost.Text = FormatCurrency(TotalSteelCost, 2)
        txtTotalCost.Text = FormatCurrency(TotalCost, 2)
        txtTotalProduction.Text = FormatNumber(TotalProductionQuantity, 0)
    End Sub

    Public Sub ClearVariables()
        FOXFilter = ""
        RMIDFilter = ""
        PartFilter = ""
        DateFilter = ""
        MachineFilter = ""
        FinishedGoodsFiter = ""
        EmployeeIDFilter = ""
        TextFilter = ""
        DivisionFilter = ""
        FOXNumber = 0
        strFOXNumber = ""
        BeginDate = ""
        EndDate = ""
        GetRMID = ""

        TotalCost = 0
        TotalInventoryPieces = 0
        TotalOverheadCost = 0
        TotalSteelCost = 0
        TotalProductionQuantity = 0
        TotalLineWeight = 0
    End Sub

    Public Sub ClearData()
        cboFOXNumber.SelectedIndex = -1
        cboMachineNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboSteelCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1

        lblMachineName.Text = ""

        txtTextFilter.Clear()
        txtTotalCost.Clear()
        txtTotalInventoryPieces.Clear()
        txtTotalOtherCost.Clear()
        txtTotalSteelCost.Clear()
        txtPartTextFilter.Clear()
        txtTotalProduction.Clear()
        txtEmployeeNumber.Clear()
        txtTotalSteelWeight.Clear()

        chkDateRange.Checked = False
        chkShowFG.Checked = False

        cboFOXNumber.Focus()
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

    Public Sub LoadMachineName()
        Dim MachineName As String = ""

        Dim MachineNameStatement As String = "SELECT Description FROM MachineTable WHERE MachineID = @MachineID"
        Dim MachineNameCommand As New SqlCommand(MachineNameStatement, con)
        MachineNameCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MachineName = CStr(MachineNameCommand.ExecuteScalar)
        Catch ex As Exception
            MachineName = ""
        End Try
        con.Close()

        lblMachineName.Text = MachineName
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        LoadPartDescription()
        LoadCarbon()
        LoadSteelSize()
        LoadFOXNumber()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
        LoadTotals()
    End Sub

    Private Sub cboMachineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMachineNumber.SelectedIndexChanged
        LoadMachineName()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Using NewMachinePopup As New MachinePopup
            Dim result = NewMachinePopup.ShowDialog
        End Using
    End Sub
End Class