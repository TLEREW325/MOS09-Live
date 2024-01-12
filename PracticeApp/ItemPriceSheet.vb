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
Public Class ItemPriceSheet
    Inherits System.Windows.Forms.Form

    Dim TextFilter, PartFilter, ItemClassFilter As String
    Dim LongDescription As String
    Dim StandardCost, StandardPrice, LastCost, LastPrice, AverageCost, AveragePrice As Double
    Dim MaxDate1, MaxDate2 As Integer

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ItemPriceSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)

        LoadCurrentDivision()

        usefulFunctions.LoadSecurity(Me)
        cboDivisionID.Text = EmployeeCompanyCode

        If GlobalMaintenancePartNumber = "" Then
            cboPartNumber.SelectedIndex = -1
        Else
            cboPartNumber.Text = GlobalMaintenancePartNumber
            cboPartDescription.Text = GlobalMaintenancePartDescription
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
        dgvPriceSheets.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber >= '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass LIKE '%" + cboItemClass.Text + "%'"
        Else
            ItemClassFilter = ""
        End If
        If txtSearch.Text <> "" Then
            TextFilter = " AND (PartDescription LIKE '%" + usefulFunctions.checkQuote(txtSearch.Text) + "%' OR PartNumber LIKE '%" + usefulFunctions.checkQuote(txtSearch.Text) + "%')"
        Else
            TextFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM ItemPriceSheetQuery WHERE DivisionID = @DivisionID" + PartFilter + ItemClassFilter + TextFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemPriceSheetQuery")
        dgvPriceSheets.DataSource = ds.Tables("ItemPriceSheetQuery")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass Order by ShortDescription", con)
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

    Public Sub LoadLongDescription()
        Dim LongDescriptionString As String = "SELECT LongDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionString, con)
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LongDescription = CStr(LongDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            LongDescription = ""
        End Try
        con.Close()

        txtLongDescription.Text = LongDescription
    End Sub

    Public Sub LoadCostingAndPricing()
        'Get Standard Pricing
        Dim StandardCostString As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim StandardCostCommand As New SqlCommand(StandardCostString, con)
        StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim StandardPriceString As String = "SELECT StandardPrice FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim StandardPriceCommand As New SqlCommand(StandardPriceString, con)
        StandardPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        StandardPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
        Catch ex As Exception
            StandardCost = 0
        End Try
        Try
            StandardPrice = CDbl(StandardPriceCommand.ExecuteScalar)
        Catch ex As Exception
            StandardPrice = 0
        End Try
        con.Close()

        txtStandardCost.Text = StandardCost
        txtStandardPrice.Text = StandardPrice

        'Get Last Cost/Price
        Dim MAXDate1Statement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim MAXDate1Command As New SqlCommand(MAXDate1Statement, con)
        MAXDate1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXDate1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxDate1 = CInt(MAXDate1Command.ExecuteScalar)
        Catch ex As Exception
            MaxDate1 = 0
        End Try
        con.Close()

        'Load values into Cost Field
        Dim LastCostStatement As String = "SELECT UnitCost FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
        Dim LastCostCommand As New SqlCommand(LastCostStatement, con)
        LastCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LastCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        LastCostCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = MaxDate1

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastCost = CDbl(LastCostCommand.ExecuteScalar)
        Catch ex As Exception
            LastCost = 0
        End Try
        con.Close()

        txtLastCost.Text = FormatCurrency(LastCost, 4)

        Dim MAXDate2Statement As String = "SELECT MAX(InvoiceHeaderKey) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim MAXDate2Command As New SqlCommand(MAXDate2Statement, con)
        MAXDate2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXDate2Command.Parameters.Add("@PartNumber ", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxDate2 = CInt(MAXDate2Command.ExecuteScalar)
        Catch ex As Exception
            MaxDate2 = 0
        End Try
        con.Close()

        'Load values into Price Field
        Dim LastPriceStatement As String = "SELECT Price FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceHeaderKey = @InvoiceHeaderKey"
        Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
        LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        LastPriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = MaxDate2

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPrice = CDbl(LastPriceCommand.ExecuteScalar)
        Catch ex As Exception
            LastPrice = 0
        End Try
        con.Close()

        txtLastPrice.Text = FormatCurrency(LastPrice, 4)

        'Get Average Cost / Price
        Dim AverageCostStatement As String = "SELECT AVG(UnitCost) FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim AverageCostCommand As New SqlCommand(AverageCostStatement, con)
        AverageCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AverageCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AverageCost = CDbl(AverageCostCommand.ExecuteScalar)
        Catch ex As Exception
            AverageCost = 0
        End Try
        con.Close()

        txtAverageCost.Text = FormatCurrency(AverageCost, 4)

        Dim AveragePriceStatement As String = "SELECT AVG(Price) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim AveragePriceCommand As New SqlCommand(AveragePriceStatement, con)
        AveragePriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AveragePriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AveragePrice = CDbl(AveragePriceCommand.ExecuteScalar)
        Catch ex As Exception
            AveragePrice = 0
        End Try
        con.Close()

        txtAveragePrice.Text = FormatCurrency(AveragePrice, 4)
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadLongDescription()
        LoadCostingAndPricing()
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Public Sub ClearData()
        cboPartDescription.Text = ""
        cboPartNumber.Text = ""
        cboItemClass.Text = ""

        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1

        txtLongDescription.Clear()
        txtAverageCost.Clear()
        txtAveragePrice.Clear()
        txtLastCost.Clear()
        txtLastPrice.Clear()
        txtStandardCost.Clear()
        txtStandardPrice.Clear()
        txtSearch.Clear()

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        TextFilter = ""
        PartFilter = ""
        ItemClassFilter = ""
        LongDescription = ""
        StandardCost = 0
        StandardPrice = 0
        LastCost = 0
        LastPrice = 0
        AverageCost = 0
        AveragePrice = 0
        MaxDate1 = 0
        MaxDate2 = 0
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdOpenItemForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenItemForm.Click
        If dgvPriceSheets.RowCount <> 0 Then
            Dim RowPartNumber As String
            Dim RowIndex As Integer = Me.dgvPriceSheets.CurrentCell.RowIndex

            RowPartNumber = Me.dgvPriceSheets.Rows(RowIndex).Cells("PartNumberColumn").Value

            GlobalPartNumberLookup = RowPartNumber
        End If

        GlobalDivisionCode = cboDivisionID.Text

        Dim NewItemMaintenance As New ItemMaintenance
        NewItemMaintenance.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintItemPriceSheet As New PrintItemPriceSheetFiltered
            Dim result = NewPrintItemPriceSheet.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        LoadPartDescription()
        ClearData()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvPriceSheets_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPriceSheets.CellDoubleClick
        If dgvPriceSheets.RowCount <> 0 Then
            Dim RowPartNumber As String
            Dim RowIndex As Integer = Me.dgvPriceSheets.CurrentCell.RowIndex

            RowPartNumber = Me.dgvPriceSheets.Rows(RowIndex).Cells("PartNumberColumn").Value

            GlobalPartNumberLookup = RowPartNumber
        End If

        GlobalDivisionCode = cboDivisionID.Text

        Dim NewItemLookup As New ItemLookup
        NewItemLookup.Show()
    End Sub

    Private Sub dgvPriceSheets_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPriceSheets.CellValueChanged
        Dim StandardUnitCost, StandardUnitPrice, B100To199, B200To299, B300To399, B400To499, B500To749, B750To999, B1000To2499, B2500To4999, B5000To9999, B10000To24999, B25000To49999, B50000To99999, B100000AndUp As Double
        Dim PartNumber As String = ""

        If Me.dgvPriceSheets.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPriceSheets.CurrentCell.RowIndex

            Try
                PartNumber = Me.dgvPriceSheets.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                StandardUnitCost = Me.dgvPriceSheets.Rows(RowIndex).Cells("StandardUnitCostColumn").Value
            Catch ex As Exception
                StandardUnitCost = 0
            End Try
            Try
                StandardUnitPrice = Me.dgvPriceSheets.Rows(RowIndex).Cells("StandardUnitPriceColumn").Value
            Catch ex As Exception
                StandardUnitPrice = 0
            End Try
            Try
                B100To199 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B100To199Column").Value
            Catch ex As Exception
                B100To199 = 0
            End Try
            Try
                B200To299 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B200To299Column").Value
            Catch ex As Exception
                B200To299 = 0
            End Try
            Try
                B300To399 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B300To399Column").Value
            Catch ex As Exception
                B300To399 = 0
            End Try
            Try
                B400To499 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B400To499Column").Value
            Catch ex As Exception
                B400To499 = 0
            End Try
            Try
                B500To749 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B500To749Column").Value
            Catch ex As Exception
                B500To749 = 0
            End Try
            Try
                B750To999 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B750To999Column").Value
            Catch ex As Exception
                B750To999 = 0
            End Try
            Try
                B1000To2499 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B1000To2499Column").Value
            Catch ex As Exception
                B1000To2499 = 0
            End Try
            Try
                B2500To4999 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B2500To4999Column").Value
            Catch ex As Exception
                B2500To4999 = 0
            End Try
            Try
                B5000To9999 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B5000To9999Column").Value
            Catch ex As Exception
                B5000To9999 = 0
            End Try
            Try
                B10000To24999 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B10000To24999Column").Value
            Catch ex As Exception
                B10000To24999 = 0
            End Try
            Try
                B25000To49999 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B25000To49999Column").Value
            Catch ex As Exception
                B25000To49999 = 0
            End Try
            Try
                B50000To99999 = Me.dgvPriceSheets.Rows(RowIndex).Cells("B50000To99999Column").Value
            Catch ex As Exception
                B50000To99999 = 0
            End Try
            Try
                B100000AndUp = Me.dgvPriceSheets.Rows(RowIndex).Cells("B100000AndUpColumn").Value
            Catch ex As Exception
                B100000AndUp = 0
            End Try

            Try
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("UPDATE ItemPriceSheet SET StandardUnitCost = @StandardUnitCost, StandardUnitPrice = @StandardUnitCost, B100To199 = @B100To199, B200To299 = @B200To299, B300To399 = @B300To399, B400To499 = @B400To499, B500To749 = @B500To749, B750To999 = @B750To999, B1000To2499 = @B1000To2499, B2500To4999 = @B2500To4999, B5000To9999 = @B5000To9999, B10000To24999 = @B10000To24999, B25000To49999 = @B25000To49999, B50000To99999 = @B50000To99999, B100000AndUp = @B100000AndUp WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@StandardUnitCost", SqlDbType.VarChar).Value = StandardUnitCost
                    .Add("@StandardUnitPrice", SqlDbType.VarChar).Value = StandardUnitPrice
                    .Add("@B100To199", SqlDbType.VarChar).Value = B100To199
                    .Add("@B200To299", SqlDbType.VarChar).Value = B200To299
                    .Add("@B300To399", SqlDbType.VarChar).Value = B300To399
                    .Add("@B400To499", SqlDbType.VarChar).Value = B400To499
                    .Add("@B500To749", SqlDbType.VarChar).Value = B500To749
                    .Add("@B750To999", SqlDbType.VarChar).Value = B750To999
                    .Add("@B1000To2499", SqlDbType.VarChar).Value = B1000To2499
                    .Add("@B2500To4999", SqlDbType.VarChar).Value = B2500To4999
                    .Add("@B5000To9999", SqlDbType.VarChar).Value = B5000To9999
                    .Add("@B10000To24999", SqlDbType.VarChar).Value = B10000To24999
                    .Add("@B25000To49999", SqlDbType.VarChar).Value = B25000To49999
                    .Add("@B50000To99999", SqlDbType.VarChar).Value = B50000To99999
                    .Add("@B100000AndUp", SqlDbType.VarChar).Value = B100000AndUp
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If StandardUnitCost = 0 Then
                    'skip update
                Else
                    'Update Item List with new Standard Cost and Price
                    cmd = New SqlCommand("UPDATE ItemList SET StandardCost = @StandardCost WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@StandardCost", SqlDbType.VarChar).Value = StandardUnitCost
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                If StandardUnitPrice = 0 Then
                    'Skip Update
                Else
                    'Update Item List with new Standard Cost and Price
                    cmd = New SqlCommand("UPDATE ItemList SET StandardPrice = @StandardPrice WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@StandardPrice", SqlDbType.VarChar).Value = StandardUnitPrice
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Catch ex As Exception
                'Do nothing
            End Try
        Else
            'Skip update
        End If
    End Sub
End Class