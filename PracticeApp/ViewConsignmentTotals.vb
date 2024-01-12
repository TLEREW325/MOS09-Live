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
Public Class ViewConsignmentTotals
    Inherits System.Windows.Forms.Form

    Dim TotalInvoices, TotalShipments, TotalReturns, TotalAdjustments As Double
    Dim WarehouseID, WarehouseName As String
    Dim SumTotalInvoices, SumTotalShipments, SumTotalReturns, SumTotalAdjustments As Double
    Dim Index As Integer = 0
    Dim SumTotalInventoryValue As Double = 0

    'Variables used in valuation
    Dim ShippingCOS, InvoiceCOS, ReturnCOS, AdjustmentCOS As Double

    'Define Arrays
    Dim WarehouseIDArray(0 To 9) As String
    Dim WarehouseNameArray(0 To 9) As String
    Dim ConsignmentInventoryValue(0 To 9) As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewConsignmentTotals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
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

    Public Sub FillArray()
        WarehouseIDArray(0) = "BCW"
        WarehouseIDArray(1) = "DCW"
        WarehouseIDArray(2) = "HCW"
        WarehouseIDArray(3) = "LCW"
        WarehouseIDArray(4) = "LSCW"
        WarehouseIDArray(5) = "PCW"
        WarehouseIDArray(6) = "RCW"
        WarehouseIDArray(7) = "SCW"
        WarehouseIDArray(8) = "YCW"
        WarehouseIDArray(9) = "SRL"
        WarehouseNameArray(0) = "Bessemer"
        WarehouseNameArray(1) = "Downey"
        WarehouseNameArray(2) = "Hayward"
        WarehouseNameArray(3) = "Lewisville"
        WarehouseNameArray(4) = "Lake Stevens"
        WarehouseNameArray(5) = "Phoenix"
        WarehouseNameArray(6) = "Renton"
        WarehouseNameArray(7) = "Seattle"
        WarehouseNameArray(8) = "Lyndhurst"
        WarehouseNameArray(9) = "SRL Industries"
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvConsignmentTotals.DataSource = Nothing
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM ConsignmentTempTotals WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ConsignmentTempTotals")
        dgvConsignmentTotals.DataSource = ds.Tables("ConsignmentTempTotals")
        con.Close()

        LoadFormatting()
    End Sub

    Public Sub LoadFormatting()
        Dim WarehouseID As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvConsignmentTotals.Rows
            Try
                WarehouseID = row.Cells("WarehouseIDColumn").Value
            Catch ex As System.Exception
                WarehouseID = ""
            End Try

            If WarehouseID = "TOTAL" Then
                Me.dgvConsignmentTotals.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
                Me.dgvConsignmentTotals.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub ClearData()
        dtpBeginDate.Text = ""
        dtpEndingDate.Text = ""

        TotalInvoices = 0
        TotalShipments = 0
        TotalReturns = 0
        TotalAdjustments = 0
        SumTotalInvoices = 0
        SumTotalShipments = 0
        SumTotalReturns = 0
        SumTotalAdjustments = 0
        Index = 0

        txtBessemerIV.Clear()
        txtDowneyIV.Clear()
        txtHaywardIV.Clear()
        txtLakeStevensIV.Clear()
        txtLewisvilleIV.Clear()
        txtLyndhurstIV.Clear()
        txtPhoenixIV.Clear()
        txtRentonIV.Clear()
        txtSeattleIV.Clear()
        txtSRLIV.Clear()
        txtTotalValue.Clear()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub LoadConsignmentValue()
        Index = 0

        FillArray()

        For i As Integer = 0 To 9
            Dim ShippingCOSStatement As String = "SELECT SUM(ExtendedCost) FROM ConsignmentShippingTable WHERE CustomerClass = @CustomerClass AND DivisionID = @DivisionID AND ShipDate <= @EndDate"
            Dim ShippingCOSCommand As New SqlCommand(ShippingCOSStatement, con)
            ShippingCOSCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = WarehouseIDArray(Index)
            ShippingCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ShippingCOSCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndingDate.Text

            Dim InvoiceCOSStatement As String = "SELECT SUM(ExtendedCost) FROM ConsignmentBillingTable WHERE CustomerClass = @CustomerClass AND DivisionID = @DivisionID AND BillDate <= @EndDate"
            Dim InvoiceCOSCommand As New SqlCommand(InvoiceCOSStatement, con)
            InvoiceCOSCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = WarehouseIDArray(Index)
            InvoiceCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            InvoiceCOSCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndingDate.Text

            Dim ReturnCOSStatement As String = "SELECT SUM(ExtendedCost) FROM ConsignmentReturnTable WHERE CustomerClass = @CustomerClass AND DivisionID = @DivisionID AND ReturnDate <= @EndDate"
            Dim ReturnCOSCommand As New SqlCommand(ReturnCOSStatement, con)
            ReturnCOSCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = WarehouseIDArray(Index)
            ReturnCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ReturnCOSCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndingDate.Text

            Dim AdjustmentCOSStatement As String = "SELECT SUM(ExtendedAmount) FROM ConsignmentAdjustmentTable WHERE CustomerClass = @CustomerClass AND DivisionID = @DivisionID AND AdjustmentDate <= @EndDate"
            Dim AdjustmentCOSCommand As New SqlCommand(AdjustmentCOSStatement, con)
            AdjustmentCOSCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = WarehouseIDArray(Index)
            AdjustmentCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            AdjustmentCOSCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndingDate.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ShippingCOS = CDbl(ShippingCOSCommand.ExecuteScalar)
            Catch ex As Exception
                ShippingCOS = 0
            End Try
            Try
                InvoiceCOS = CDbl(InvoiceCOSCommand.ExecuteScalar)
            Catch ex As Exception
                InvoiceCOS = 0
            End Try
            Try
                AdjustmentCOS = CDbl(AdjustmentCOSCommand.ExecuteScalar)
            Catch ex As Exception
                AdjustmentCOS = 0
            End Try
            Try
                ReturnCOS = CDbl(ReturnCOSCommand.ExecuteScalar)
            Catch ex As Exception
                ReturnCOS = 0
            End Try
            con.Close()

            ConsignmentInventoryValue(Index) = (ShippingCOS + ReturnCOS + AdjustmentCOS) - InvoiceCOS
            SumTotalInventoryValue = SumTotalInventoryValue + ConsignmentInventoryValue(Index)

            Select Case Index
                Case 0
                    txtBessemerIV.Text = FormatCurrency(ConsignmentInventoryValue(Index), 2)
                Case 1
                    txtDowneyIV.Text = FormatCurrency(ConsignmentInventoryValue(Index), 2)
                Case 2
                    txtHaywardIV.Text = FormatCurrency(ConsignmentInventoryValue(Index), 2)
                Case 3
                    txtLewisvilleIV.Text = FormatCurrency(ConsignmentInventoryValue(Index), 2)
                Case 4
                    txtLakeStevensIV.Text = FormatCurrency(ConsignmentInventoryValue(Index), 2)
                Case 5
                    txtPhoenixIV.Text = FormatCurrency(ConsignmentInventoryValue(Index), 2)
                Case 6
                    txtRentonIV.Text = FormatCurrency(ConsignmentInventoryValue(Index), 2)
                Case 7
                    txtSeattleIV.Text = FormatCurrency(ConsignmentInventoryValue(Index), 2)
                Case 8
                    txtLyndhurstIV.Text = FormatCurrency(ConsignmentInventoryValue(Index), 2)
                Case 9
                    txtSRLIV.Text = FormatCurrency(ConsignmentInventoryValue(Index), 2)
            End Select

            'Clear variables
            ReturnCOS = 0
            InvoiceCOS = 0
            ShippingCOS = 0
            AdjustmentCOS = 0

            Index = Index + 1
        Next i

        txtTotalValue.Text = FormatCurrency(SumTotalInventoryValue, 2)
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        FillArray()

        'Clear Variables
        SumTotalAdjustments = 0
        SumTotalInvoices = 0
        SumTotalReturns = 0
        SumTotalAdjustments = 0
        Index = 0

        'Delete previous data in temp table
        cmd = New SqlCommand("DELETE FROM ConsignmentTempTotals", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Define consignment divisions and names (Create array with indices)
        For i As Integer = 0 To 9
            'For each consignment warehouse get shipments, invoices, returns, and adjustments (Totals)
            Dim SumShippingStatement As String = "SELECT SUM(ExtendedCost) FROM ConsignmentShippingTable WHERE CustomerClass = @CustomerClass AND DivisionID = @DivisionID AND ShipDate BETWEEN @BeginDate AND @EndDate"
            Dim SumShippingCommand As New SqlCommand(SumShippingStatement, con)
            SumShippingCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = WarehouseIDArray(Index)
            SumShippingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SumShippingCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            SumShippingCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndingDate.Text

            Dim SumInvoicesStatement As String = "SELECT SUM(ExtendedAmount) FROM ConsignmentBillingTable WHERE CustomerClass = @CustomerClass AND DivisionID = @DivisionID AND BillDate BETWEEN @BeginDate AND @EndDate"
            Dim SumInvoicesCommand As New SqlCommand(SumInvoicesStatement, con)
            SumInvoicesCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = WarehouseIDArray(Index)
            SumInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SumInvoicesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            SumInvoicesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndingDate.Text

            Dim SumReturnsStatement As String = "SELECT SUM(ExtendedAmount) FROM ConsignmentReturnTable WHERE CustomerClass = @CustomerClass AND DivisionID = @DivisionID AND ReturnDate BETWEEN @BeginDate AND @EndDate"
            Dim SumReturnsCommand As New SqlCommand(SumReturnsStatement, con)
            SumReturnsCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = WarehouseIDArray(Index)
            SumReturnsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SumReturnsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            SumReturnsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndingDate.Text

            Dim SumAdjustmentsStatement As String = "SELECT SUM(ExtendedAmount) FROM ConsignmentAdjustmentTable WHERE CustomerClass = @CustomerClass AND DivisionID = @DivisionID AND AdjustmentDate BETWEEN @BeginDate AND @EndDate"
            Dim SumAdjustmentsCommand As New SqlCommand(SumAdjustmentsStatement, con)
            SumAdjustmentsCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = WarehouseIDArray(Index)
            SumAdjustmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SumAdjustmentsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            SumAdjustmentsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndingDate.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalShipments = CDbl(SumShippingCommand.ExecuteScalar)
            Catch ex As Exception
                TotalShipments = 0
            End Try
            Try
                TotalInvoices = CDbl(SumInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                TotalInvoices = 0
            End Try
            Try
                TotalReturns = CDbl(SumReturnsCommand.ExecuteScalar)
            Catch ex As Exception
                TotalReturns = 0
            End Try
            Try
                TotalAdjustments = CDbl(SumAdjustmentsCommand.ExecuteScalar)
            Catch ex As Exception
                TotalAdjustments = 0
            End Try
            con.Close()

            'Write to temp table
            cmd = New SqlCommand("INSERT INTO ConsignmentTempTotals (WarehouseID, WarehouseName, TotalShipments, TotalInvoices, TotalReturns, TotalAdjustments, BeginDate, EndDate, DivisionID)values (@WarehouseID, @WarehouseName, @TotalShipments, @TotalInvoices, @TotalReturns, @TotalAdjustments, @BeginDate, @EndDate, @DivisionID)", con)

            With cmd.Parameters
                .Add("@WarehouseID", SqlDbType.VarChar).Value = WarehouseIDArray(Index)
                .Add("@WarehouseName", SqlDbType.VarChar).Value = WarehouseNameArray(Index)
                .Add("@TotalShipments", SqlDbType.VarChar).Value = TotalShipments
                .Add("@TotalInvoices", SqlDbType.VarChar).Value = TotalInvoices
                .Add("@TotalReturns", SqlDbType.VarChar).Value = TotalReturns
                .Add("@TotalAdjustments", SqlDbType.VarChar).Value = TotalAdjustments
                .Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
                .Add("@Enddate", SqlDbType.VarChar).Value = dtpEndingDate.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            SumTotalAdjustments = SumTotalAdjustments + TotalAdjustments
            SumTotalInvoices = SumTotalInvoices + TotalInvoices
            SumTotalReturns = SumTotalReturns + TotalReturns
            SumTotalShipments = SumTotalShipments + TotalShipments

            TotalInvoices = 0
            TotalAdjustments = 0
            TotalReturns = 0
            TotalShipments = 0

            Index = Index + 1
        Next i

        'Write Totals to temp table
        cmd = New SqlCommand("INSERT INTO ConsignmentTempTotals (WarehouseID, WarehouseName, TotalShipments, TotalInvoices, TotalReturns, TotalAdjustments, BeginDate, EndDate, DivisionID)values (@WarehouseID, @WarehouseName, @TotalShipments, @TotalInvoices, @TotalReturns, @TotalAdjustments, @BeginDate, @EndDate, @DivisionID)", con)

        With cmd.Parameters
            .Add("@WarehouseID", SqlDbType.VarChar).Value = "TOTAL"
            .Add("@WarehouseName", SqlDbType.VarChar).Value = "TOTAL"
            .Add("@TotalShipments", SqlDbType.VarChar).Value = SumTotalShipments
            .Add("@TotalInvoices", SqlDbType.VarChar).Value = SumTotalInvoices
            .Add("@TotalReturns", SqlDbType.VarChar).Value = SumTotalReturns
            .Add("@TotalAdjustments", SqlDbType.VarChar).Value = SumTotalAdjustments
            .Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            .Add("@Enddate", SqlDbType.VarChar).Value = dtpEndingDate.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Load data in datagrid
        ShowData()

        LoadConsignmentValue()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintConsignmentTotals As New PrintConsignmentTotals
            Dim result = NewPrintConsignmentTotals.ShowDialog()
        End Using
    End Sub

    Private Sub PrintReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintReportToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub
End Class