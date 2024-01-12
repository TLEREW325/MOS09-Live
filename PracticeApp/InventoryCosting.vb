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
Public Class InventoryCosting
    Inherits System.Windows.Forms.Form

    Dim LongDescription As String
    Dim NextCostingTransactionNumber, LastCostingTransactionNumber, NextTransactionNumber As Integer
    Dim PartFilter, WarehouseFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub InventoryCosting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        LoadCurrentDivision()

        If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
            gpxAddCostTier.Enabled = True
            gpxRebuildCostTiers.Enabled = True
        Else
            gpxAddCostTier.Enabled = False
            gpxRebuildCostTiers.Enabled = False
        End If

        usefulFunctions.LoadSecurity(Me)
        cboDivisionID.Text = EmployeeCompanyCode
        cboConsignment.Text = ""
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
        dgvInventoryCosting.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        Dim DivisionID As String = ""
        Dim WarehouseName As String = ""
        Dim WarehouseID As String = ""

        WarehouseName = cboConsignment.Text

        Select Case WarehouseName
            Case "Bessemer"
                WarehouseID = "BCW"
            Case "Downey"
                WarehouseID = "DCW"
            Case "Hayward"
                WarehouseID = "HCW"
            Case "Lewisville"
                WarehouseID = "LCW"
            Case "Lyndhurst"
                WarehouseID = "YCW"
            Case "Phoenix"
                WarehouseID = "PCW"
            Case "Seattle"
                WarehouseID = "SCW"
            Case "Renton"
                WarehouseID = "RCW"
            Case "Lake Stevens"
                WarehouseID = "LSCW"
            Case "SRL"
                WarehouseID = "SRL"
            Case Else
                WarehouseID = "TWD"
        End Select

        If cboConsignment.Text = "" Then
            DivisionID = cboDivisionID.Text
        Else
            DivisionID = WarehouseID
        End If

        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM InventoryCosting WHERE DivisionID = @DivisionID" + PartFilter + " ORDER BY PartNumber, CostingDate, TransactionNumber ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryCosting")
        dgvInventoryCosting.DataSource = ds.Tables("InventoryCosting")
        con.Close()
    End Sub

    Public Sub ShowDataForRebuild()
        If txtCostTierPartNumber.Text <> "" And txtCostTierDivision.Text <> "" Then
            PartFilter = " AND PartNumber = '" + txtCostTierPartNumber.Text + "'"
        Else
            MsgBox("You must select a valid part number and division.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        cmd = New SqlCommand("SELECT * FROM InventoryCosting WHERE DivisionID = @DivisionID" + PartFilter + " ORDER BY PartNumber, CostingDate, TransactionNumber ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCostTierDivision.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryCosting")
        dgvInventoryCosting.DataSource = ds.Tables("InventoryCosting")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCostPartNumber()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboCostingPartNumber.DataSource = ds3.Tables("ItemList")
        cboCostDescription.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboCostingPartNumber.SelectedIndex = -1
        cboCostDescription.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboConsignment.SelectedIndex = -1

        txtQtySTD.Clear()
        txtNextPieceSold.Clear()
        txtTotalAssembled.Clear()
        txtTotalBoth.Clear()

        cboPartNumber.Focus()
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
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

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
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

    Public Sub LoadTQS()
        Dim TotalQuantityShippedToDate As Double = 0
        Dim TotalQuantityShippedAndAssembled As Double = 0
        Dim TotalQuantityAssembledToDate As Double = 0
        Dim CostOfNextPieceSold As Double = 0

        Dim TotalQuantityShippedToDateStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND LineStatus <> @LineStatus AND DropShip = @DropShip"
        Dim TotalQuantityShippedToDateCommand As New SqlCommand(TotalQuantityShippedToDateStatement, con)
        TotalQuantityShippedToDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        TotalQuantityShippedToDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalQuantityShippedToDateCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
        TotalQuantityShippedToDateCommand.Parameters.Add("@DropShip", SqlDbType.VarChar).Value = "NO"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityShippedToDate = CDbl(TotalQuantityShippedToDateCommand.ExecuteScalar)
        Catch ex As Exception
            TotalQuantityShippedToDate = 0
        End Try
        con.Close()

        Dim TotalQuantityAssembledToDateStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
        Dim TotalQuantityAssembledToDateCommand As New SqlCommand(TotalQuantityAssembledToDateStatement, con)
        TotalQuantityAssembledToDateCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        TotalQuantityAssembledToDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityAssembledToDate = CDbl(TotalQuantityAssembledToDateCommand.ExecuteScalar)
            TotalQuantityAssembledToDate = TotalQuantityAssembledToDate * -1
        Catch ex As Exception
            TotalQuantityAssembledToDate = 0
        End Try
        con.Close()

        TotalQuantityShippedAndAssembled = TotalQuantityAssembledToDate + TotalQuantityShippedToDate

        Dim MaxTransactionNumber As Integer = 0

        Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantity BETWEEN LowerLimit AND UpperLimit"
        Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
        MaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        MaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MaxTransactionNumberCommand.Parameters.Add("@TotalQuantity", SqlDbType.VarChar).Value = TotalQuantityShippedAndAssembled

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxTransactionNumber = CDbl(MaxTransactionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            MaxTransactionNumber = 0
        End Try
        con.Close()

        Dim NextPieceSoldStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
        Dim NextPieceSoldCommand As New SqlCommand(NextPieceSoldStatement, con)
        NextPieceSoldCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        NextPieceSoldCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        NextPieceSoldCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CostOfNextPieceSold = CDbl(NextPieceSoldCommand.ExecuteScalar)
        Catch ex As Exception
            CostOfNextPieceSold = 0
        End Try
        con.Close()

        txtQtySTD.Text = TotalQuantityShippedToDate
        txtTotalAssembled.Text = TotalQuantityAssembledToDate
        txtTotalBoth.Text = TotalQuantityShippedAndAssembled
        txtNextPieceSold.Text = FormatCurrency(CostOfNextPieceSold, 4)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdEnterNewCostTier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterNewCostTier.Click
        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            If cboCostingPartNumber.Text = "" Then
                MsgBox("You must have a valid Part Number selected.", MsgBoxStyle.OkOnly)
            Else
                'Extract the Upper and Lower Limit of the Inventory Costing Table
                Dim NewUpperLimit, LowerLimit, UpperLimit As Double

                Dim UpperLimitStatement As String = "SELECT MAX(UpperLimit) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboCostingPartNumber.Text
                UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                Catch ex As Exception
                    UpperLimit = 0
                End Try
                con.Close()

                'Calculate the NEW Lower/Upper Limit for the next post
                LowerLimit = UpperLimit + 1
                NewUpperLimit = LowerLimit + Val(txtCostQuantity.Text)

                'Get next Transaction Number
                Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
                Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    LastCostingTransactionNumber = 63600000
                End Try
                con.Close()

                NextCostingTransactionNumber = LastCostingTransactionNumber + 1

                'Write Values to Inventory Costing Table
                cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboCostingPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CostingDate", SqlDbType.VarChar).Value = dtpCostingDate.Text
                    .Add("@ItemCost", SqlDbType.VarChar).Value = Val(txtItemCost.Text)
                    .Add("@CostQuantity", SqlDbType.VarChar).Value = Val(txtCostQuantity.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "MANUAL ENTRY"
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear Lines and refresh datagrid
                cboCostingPartNumber.SelectedIndex = -1
                cboCostDescription.SelectedIndex = -1
                txtCostQuantity.Clear()
                txtItemCost.Clear()
                dtpCostingDate.Text = ""

                ClearDataInDatagrid()
            End If
        Else
            MsgBox("You do not have clearance to edit / add Cost Tiers.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        LoadPartDescription()
        LoadCostPartNumber()
        ClearData()
        ClearDataInDatagrid()

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "ADM" Or cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Or cboDivisionID.Text = "TFF" Then
            cboConsignment.Text = ""
            cboConsignment.Enabled = True
        Else
            cboConsignment.Text = ""
            cboConsignment.Enabled = False
        End If
    End Sub

    Private Sub dgvInventoryCosting_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryCosting.CellValueChanged
        If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
            Dim TransactionNumber As Integer
            Dim ItemCost, CostQuantity, UpperLimit, LowerLimit As Double
            Dim PartNumber As String

            For Each row As DataGridViewRow In dgvInventoryCosting.Rows
                Try
                    TransactionNumber = row.Cells("TransactionNumberColumn").Value
                Catch ex As Exception
                    TransactionNumber = 0
                End Try
                Try
                    PartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    ItemCost = row.Cells("ItemCostColumn").Value
                Catch ex As Exception
                    ItemCost = 0
                End Try
                Try
                    CostQuantity = row.Cells("CostQuantityColumn").Value
                Catch ex As Exception
                    CostQuantity = 0
                End Try
                Try
                    LowerLimit = row.Cells("LowerLimitColumn").Value
                Catch ex As Exception
                    LowerLimit = 0
                End Try
                Try
                    UpperLimit = row.Cells("UpperLimitColumn").Value
                Catch ex As Exception
                    UpperLimit = 0
                End Try

                'Write Values to Inventory Costing Table
                cmd = New SqlCommand("UPDATE InventoryCosting SET ItemCost = @ItemCost, CostQuantity = @CostQuantity, LowerLimit = @LowerLimit, UpperLimit = @UpperLimit WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    '.Add("@CostingDate", SqlDbType.VarChar).Value = CostingDate
                    .Add("@ItemCost", SqlDbType.VarChar).Value = ItemCost
                    .Add("@CostQuantity", SqlDbType.VarChar).Value = CostQuantity
                    '.Add("@Status", SqlDbType.VarChar).Value = Status
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = UpperLimit
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = TransactionNumber
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = TransactionNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next
        Else
            'Dont save changes in datagrid
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintInventoryCostingFiltered As New PrintInventoryCostingFiltered
            Dim Result = NewPrintInventoryCostingFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintReportToolStripMenuItem.Click
        GDS = ds
        Using NewPrintInventoryCostingFiltered As New PrintInventoryCostingFiltered
            Dim Result = NewPrintInventoryCostingFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdUpdateCostTiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim LastPartNumber, NewPartNumber, PartNumber As String
        Dim CostQuantity, LastLowerLimit, LastUpperLimit, LowerLimit, UpperLimit As Double
        Dim TransactionNumber As Integer

        cmd = New SqlCommand("SELECT * FROM InventoryCosting WHERE DivisionID = @DivisionID ORDER BY DivisionID, PartNumber, TransactionNumber ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryCosting")
        dgvInventoryCosting.DataSource = ds.Tables("InventoryCosting")
        con.Close()

        LastPartNumber = ""
        LastLowerLimit = 0
        LastUpperLimit = 0
        UpperLimit = 0
        LowerLimit = 0
        CostQuantity = 0
        NewPartNumber = ""
        PartNumber = ""

        For Each row As DataGridViewRow In dgvInventoryCosting.Rows
            Try
                PartNumber = row.Cells("PartNumberColumn").Value
            Catch ex As Exception
                PartNumber = ""
                MsgBox("Part Fail", MsgBoxStyle.OkOnly)
                Exit For
            End Try
            Try
                CostQuantity = row.Cells("CostQuantityColumn").Value
            Catch ex As Exception
                CostQuantity = 0
                MsgBox("CostQuantity Fail", MsgBoxStyle.OkOnly)
                Exit For
            End Try
            Try
                TransactionNumber = row.Cells("TransactionNumberColumn").Value
            Catch ex As Exception
                TransactionNumber = 0
                MsgBox("TransactionNumber Fail", MsgBoxStyle.OkOnly)
                Exit For
            End Try

            If PartNumber = LastPartNumber Then
                If CostQuantity < 0 Then
                    LowerLimit = LastUpperLimit - 1
                    UpperLimit = LastUpperLimit + CostQuantity
                Else
                    LowerLimit = LastUpperLimit + 1
                    UpperLimit = LastUpperLimit + CostQuantity
                End If
            Else
                LowerLimit = 1
                UpperLimit = CostQuantity
            End If

            Try
                'Write Values to Inventory Costing Table
                cmd = New SqlCommand("UPDATE InventoryCosting SET LowerLimit = @LowerLimit, UpperLimit = @UpperLimit WHERE PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    '.Add("@CostingDate", SqlDbType.VarChar).Value = CostingDate
                    '.Add("@ItemCost", SqlDbType.VarChar).Value = ItemCost
                    '.Add("@CostQuantity", SqlDbType.VarChar).Value = CostQuantity
                    '.Add("@Status", SqlDbType.VarChar).Value = Status
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = UpperLimit
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip
                MsgBox("Update Fail", MsgBoxStyle.OkOnly)
                Exit For
            End Try

            LastPartNumber = PartNumber
            LastLowerLimit = LowerLimit
            LastUpperLimit = UpperLimit
        Next

        MsgBox("Update completed", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
        LoadTQS()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdClearFields_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearFields.Click
        cboCostingPartNumber.SelectedIndex = -1
        cboCostDescription.SelectedIndex = -1
        txtItemCost.Clear()
        txtCostQuantity.Clear()

        dtpCostingDate.Text = ""

        cboCostingPartNumber.Focus()
    End Sub

    Private Sub cmdViewCostTiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewCostTiers.Click
        ShowDataForRebuild()
    End Sub

    Private Sub cmdUpdateCostTiers_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateCostTiers.Click
        If Me.dgvInventoryCosting.RowCount = 0 Then
            MsgBox("Part # has no tiers. Contact admin.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim TransactionNumber As Integer = 0
        Dim CostQuantity As Double = 0
        Dim LowerLimit As Double = 0
        Dim UpperLimit As Double = 0
        Dim LastUpperLimit As Double = 0
        Dim CostingPartNumber As String = ""

        Dim Counter As Integer = 1

        For Each row As DataGridViewRow In dgvInventoryCosting.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                TransactionNumber = row.Cells("TransactionNumberColumn").Value
            Catch ex As Exception
                TransactionNumber = 0
            End Try
            Try
                CostQuantity = row.Cells("CostQuantityColumn").Value
            Catch ex As Exception
                CostQuantity = 0
            End Try
            Try
                LowerLimit = row.Cells("LowerLimitColumn").Value
            Catch ex As Exception
                LowerLimit = 0
            End Try
            Try
                UpperLimit = row.Cells("UpperLimitColumn").Value
            Catch ex As Exception
                UpperLimit = 0
            End Try
            Try
                CostingPartNumber = row.Cells("PartNumberColumn").Value
            Catch ex As Exception
                CostingPartNumber = ""
            End Try
            '*************************************************************************
            'If first repetition then Lower Limit starts as one
            If Counter = 1 Then
                LowerLimit = 1
                UpperLimit = CostQuantity
            Else
                If CostQuantity > 0 Then
                    LowerLimit = LastUpperLimit + 1
                    UpperLimit = LastUpperLimit + CostQuantity
                Else
                    LowerLimit = LastUpperLimit
                    UpperLimit = LastUpperLimit + CostQuantity
                End If
            End If

            'Update Line Number
            Try
                cmd = New SqlCommand("UPDATE InventoryCosting SET LowerLimit = @LowerLimit, UpperLimit = @UpperLimit WHERE PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = txtCostTierPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtCostTierDivision.Text
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = UpperLimit
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip Update
            End Try

            'Advance Counter
            Counter = Counter + 1

            'Clear Variables
            LastUpperLimit = UpperLimit
            UpperLimit = 0
            LowerLimit = 0
            CostQuantity = 0
            TransactionNumber = 0
        Next

        MsgBox("Cost Tiers Repaired.", MsgBoxStyle.OkOnly)

        ShowDataForRebuild()
    End Sub
End Class