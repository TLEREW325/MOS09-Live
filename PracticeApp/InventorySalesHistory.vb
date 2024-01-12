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
Public Class InventorySalesHistory
    Inherits System.Windows.Forms.Form

    Dim CurrentDate As Date
    Dim CurrentYear, YearTwo, YearThree, YearFour, YearFive As Integer
    Dim strCurrentYear, strYearTwo, strYearThree, strYearFour, strYearFive As String
    Dim BeginYearPrefix, EndYearPrefix As String
    Dim BeginYear, EndYear As String

    Dim YearOneSales, YearOneQuantity, YearTwoSales, YearTwoQuantity, YearThreeSales, YearThreeQuantity, YearFourSales, YearFourQuantity, YearFiveSales, YearFiveQuantity As Double
    Dim MinPrice, MaxPrice As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadPartsByItemClass()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription, DivisionID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass = @ItemClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemList")
        dgvItemList.DataSource = ds.Tables("ItemList")
        con.Close()
    End Sub

    Public Sub LoadTotals()
        cmd = New SqlCommand("SELECT * FROM InventoryFiveYearHistory WHERE DivisionID = @DivisionID AND ItemClass = @ItemClass ORDER BY PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "InventoryFiveYearHistory")
        dgvInventorySalesHistory.DataSource = ds1.Tables("InventoryFiveYearHistory")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvInventorySalesHistory.DataSource = Nothing
    End Sub

    Public Sub DefineYearRange()
        CurrentDate = Today()

        CurrentYear = CurrentDate.Year
        YearTwo = CurrentYear - 1
        YearThree = CurrentYear - 2
        YearFour = CurrentYear - 3
        YearFive = CurrentYear - 4
        strCurrentYear = CStr(CurrentYear)
        strYearTwo = CStr(YearTwo)
        strYearThree = CStr(YearThree)
        strYearFour = CStr(YearFour)
        strYearFive = CStr(YearFive)

        BeginYearPrefix = "1/01/"
        EndYearPrefix = "12/31/"
    End Sub

    Public Sub FormatDatagrid()
        Me.dgvInventorySalesHistory.Columns("YearOneQuantityColumn1").HeaderText = "Quantity Sold (" + strCurrentYear + ")"
        Me.dgvInventorySalesHistory.Columns("YearOneSalesColumn1").HeaderText = "Total Sales (" + strCurrentYear + ")"
        Me.dgvInventorySalesHistory.Columns("YearTwoQuantityColumn1").HeaderText = "Quantity Sold (" + strYearTwo + ")"
        Me.dgvInventorySalesHistory.Columns("YearTwoSalesColumn1").HeaderText = "Total Sales (" + strYearTwo + ")"
        Me.dgvInventorySalesHistory.Columns("YearThreeQuantityColumn1").HeaderText = "Quantity Sold (" + strYearThree + ")"
        Me.dgvInventorySalesHistory.Columns("YearThreeSalesColumn1").HeaderText = "Total Sales (" + strYearThree + ")"
        Me.dgvInventorySalesHistory.Columns("YearFourQuantityColumn1").HeaderText = "Quantity Sold (" + strYearFour + ")"
        Me.dgvInventorySalesHistory.Columns("YearFourSalesColumn1").HeaderText = "Total Sales (" + strYearFour + ")"
        Me.dgvInventorySalesHistory.Columns("YearFiveQuantityColumn1").HeaderText = "Quantity Sold (" + strYearFive + ")"
        Me.dgvInventorySalesHistory.Columns("YearFiveSalesColumn1").HeaderText = "Total Sales (" + strYearFive + ")"
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Dim PartNumber, PartDescription, DivisionID As String
        'Load Datagrid with parts for selected item class
        LoadPartsByItemClass()
        '******************************************************************************
        'Clear Temp Table
        cmd = New SqlCommand("DELETE FROM InventoryFiveYearHistory WHERE ItemClass = @ItemClass AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '******************************************************************************
        'Define Year
        DefineYearRange()
        '******************************************************************************
        'For each line, get data
        For Each row As DataGridViewRow In dgvItemList.Rows
            Try
                PartNumber = row.Cells("ItemIDColumn").Value
            Catch ex As System.Exception
                PartNumber = ""
            End Try
            Try
                DivisionID = row.Cells("DivisionIDColumn").Value
            Catch ex As System.Exception
                DivisionID = ""
            End Try
            Try
                PartDescription = row.Cells("ShortDescriptionColumn").Value
            Catch ex As System.Exception
                PartDescription = ""
            End Try

            'Get Year Data
            Dim YearOneSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim YearOneSalesCommand As New SqlCommand(YearOneSalesStatement, con)
            YearOneSalesCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            YearOneSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            YearOneSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strCurrentYear
            YearOneSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strCurrentYear

            Dim YearOneQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim YearOneQuantityCommand As New SqlCommand(YearOneQuantityStatement, con)
            YearOneQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            YearOneQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            YearOneQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strCurrentYear
            YearOneQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strCurrentYear

            Dim YearTwoSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim YearTwoSalesCommand As New SqlCommand(YearTwoSalesStatement, con)
            YearTwoSalesCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            YearTwoSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            YearTwoSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strYearTwo
            YearTwoSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strYearTwo

            Dim YearTwoQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim YearTwoQuantityCommand As New SqlCommand(YearTwoQuantityStatement, con)
            YearTwoQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            YearTwoQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            YearTwoQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strYearTwo
            YearTwoQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strYearTwo

            Dim YearThreeSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim YearThreeSalesCommand As New SqlCommand(YearThreeSalesStatement, con)
            YearThreeSalesCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            YearThreeSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            YearThreeSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strYearThree
            YearThreeSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strYearThree

            Dim YearThreeQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim YearThreeQuantityCommand As New SqlCommand(YearThreeQuantityStatement, con)
            YearThreeQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            YearThreeQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            YearThreeQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strYearThree
            YearThreeQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strYearThree

            Dim YearFourSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim YearFourSalesCommand As New SqlCommand(YearFourSalesStatement, con)
            YearFourSalesCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            YearFourSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            YearFourSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strYearFour
            YearFourSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strYearFour

            Dim YearFourQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim YearFourQuantityCommand As New SqlCommand(YearFourQuantityStatement, con)
            YearFourQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            YearFourQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            YearFourQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strYearFour
            YearFourQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strYearFour

            Dim YearFiveSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim YearFiveSalesCommand As New SqlCommand(YearFiveSalesStatement, con)
            YearFiveSalesCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            YearFiveSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            YearFiveSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strYearFive
            YearFiveSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strYearFive

            Dim YearFiveQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim YearFiveQuantityCommand As New SqlCommand(YearFiveQuantityStatement, con)
            YearFiveQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            YearFiveQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            YearFiveQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strYearFive
            YearFiveQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strYearFive

            Dim MinPriceStatement As String = "SELECT MIN(Price) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim MinPriceCommand As New SqlCommand(MinPriceStatement, con)
            MinPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            MinPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            MinPriceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strYearFive
            MinPriceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strCurrentYear

            Dim MaxPriceStatement As String = "SELECT MAX(Price) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            Dim MaxPriceCommand As New SqlCommand(MaxPriceStatement, con)
            MaxPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            MaxPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            MaxPriceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginYearPrefix + strYearFive
            MaxPriceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndYearPrefix + strCurrentYear

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                YearOneSales = CDbl(YearOneSalesCommand.ExecuteScalar)
            Catch ex As Exception
                YearOneSales = 0
            End Try
            Try
                YearOneQuantity = CDbl(YearOneQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                YearOneQuantity = 0
            End Try
            Try
                YearTwoSales = CDbl(YearTwoSalesCommand.ExecuteScalar)
            Catch ex As Exception
                YearTwoSales = 0
            End Try
            Try
                YearTwoQuantity = CDbl(YearTwoQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                YearTwoQuantity = 0
            End Try
            Try
                YearThreeSales = CDbl(YearThreeSalesCommand.ExecuteScalar)
            Catch ex As Exception
                YearThreeSales = 0
            End Try
            Try
                YearThreeQuantity = CDbl(YearThreeQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                YearThreeQuantity = 0
            End Try
            Try
                YearFourSales = CDbl(YearFourSalesCommand.ExecuteScalar)
            Catch ex As Exception
                YearFourSales = 0
            End Try
            Try
                YearFourQuantity = CDbl(YearFourQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                YearFourQuantity = 0
            End Try
            Try
                YearFiveSales = CDbl(YearFiveSalesCommand.ExecuteScalar)
            Catch ex As Exception
                YearFiveSales = 0
            End Try
            Try
                YearFiveQuantity = CDbl(YearFiveQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                YearFiveQuantity = 0
            End Try
            Try
                MinPrice = CDbl(MinPriceCommand.ExecuteScalar)
            Catch ex As Exception
                MinPrice = 0
            End Try
            Try
                MaxPrice = CDbl(MaxPriceCommand.ExecuteScalar)
            Catch ex As Exception
                MaxPrice = 0
            End Try
            con.Close()

            'Insert Into Temp Table
            '******************************************************************************
            'Clear Temp Table
            cmd = New SqlCommand("INSERT INTO InventoryFiveYearHistory (DivisionID, PartNumber, PartDescription, ItemClass, CurrentDate, MinPrice, MaxPrice, YearOneQuantity, YearOneSales, YearTwoQuantity, YearTwoSales, YearThreeQuantity, YearThreeSales, YearFourQuantity, YearFourSales, YearFiveQuantity, YearFiveSales) Values (@DivisionID, @PartNumber, @PartDescription, @ItemClass, @CurrentDate, @MinPrice, @MaxPrice, @YearOneQuantity, @YearOneSales, @YearTwoQuantity, @YearTwoSales, @YearThreeQuantity, @YearThreeSales, @YearFourQuantity, @YearFourSales, @YearFiveQuantity, @YearFiveSales)", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
                .Add("@CurrentDate", SqlDbType.VarChar).Value = Today()
                .Add("@MinPrice", SqlDbType.VarChar).Value = MinPrice
                .Add("@MaxPrice", SqlDbType.VarChar).Value = MaxPrice
                .Add("@YearOneQuantity", SqlDbType.VarChar).Value = YearOneQuantity
                .Add("@YearOneSales", SqlDbType.VarChar).Value = YearOneSales
                .Add("@YearTwoQuantity", SqlDbType.VarChar).Value = YearTwoQuantity
                .Add("@YearTwoSales", SqlDbType.VarChar).Value = YearTwoSales
                .Add("@YearThreeQuantity", SqlDbType.VarChar).Value = YearThreeQuantity
                .Add("@YearThreeSales", SqlDbType.VarChar).Value = YearThreeSales
                .Add("@YearFourQuantity", SqlDbType.VarChar).Value = YearFourQuantity
                .Add("@YearFourSales", SqlDbType.VarChar).Value = YearFourSales
                .Add("@YearFiveQuantity", SqlDbType.VarChar).Value = YearFiveQuantity
                .Add("@YearFiveSales", SqlDbType.VarChar).Value = YearFiveSales
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '******************************************************************************
            'Clear Variables
            YearOneQuantity = 0
            YearOneSales = 0
            YearTwoQuantity = 0
            YearTwoSales = 0
            YearThreeQuantity = 0
            YearThreeSales = 0
            YearFourQuantity = 0
            YearFourSales = 0
            YearFiveQuantity = 0
            YearFiveSales = 0
            MinPrice = 0
            MaxPrice = 0
            PartNumber = ""
            PartDescription = ""
        Next

        'Show data in datagrid
        LoadTotals()

        'Format datagrid
        FormatDatagrid()

        MsgBox("Sales data is loaded.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub InventorySalesHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        cboItemClass.SelectedIndex = -1
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

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearDataInDatagrid()
        cboItemClass.SelectedIndex = -1
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds1

        Using NewPrintInventorySales5Year As New PrintInventorySales5Year
            Dim Result = NewPrintInventorySales5Year.ShowDialog()
        End Using
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class