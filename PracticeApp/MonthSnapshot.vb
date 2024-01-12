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
Public Class MonthSnapshot
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim TodaysDate As Date = Today.ToShortDateString()

    Dim BeginMonthPrefix, EndMonthPrefix As String
    Dim BeginYearSuffix, EndYearSuffix As String
    Dim LYBeginYearSuffix, LYEndYearSuffix As String
    Dim BeginDate, EndDate As String
    Dim LYBeginDate, LYEndDate As String

    Dim TotalPOQuantity, TotalSOQuantity, TotalShipmentQuantity, TotalInvoiceQuantity, TotalCustomerReturnQuantity, TotalReceiverQuantity, TotalVendorReturnQuantity, TotalAdjustmentQuantity, TotalCashReceiptsQuantity, TotalVoucherQuantity, TotalQuoteQuantity As Integer
    Dim TotalPOAmount, TotalSOAmount, TotalShipmentAmount, TotalInvoiceAmount, TotalCustomerReturnAmount, TotalReceiverAmount, TotalVendorReturnAmount, TotalAdjustmentAmount, TotalInventoryChange, TotalCashReceiptsAmount, TotalVoucherAmount, TotalQuoteAmount As Double
    Dim SteelPOAmount, SteelPOQuantity, SteelYardReturn, SteelUsage, SteelNetChange, SteelReceiverQuantity, SteelReceiverAmount, SteelReturnAmount, SteelReturnQuantity, SteelAdjustmentAmount, SteelAdjustmentQuantity As Double
    Dim ChangeInInventoryValue, TotalRentalBilled, TotalLaborRepairBilled, TotalLineFreight, TotalBilledFreight, TotalCombinedFreight As Double
    Dim LYTotalQuoteAmount, LYTotalReturnAmount, LYTotalOrders, LYTotalInvoiceAmount, LYTotalShipmentAmount As Double

    Private Sub MonthSnapshot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        ClearVariables()
        ClearData()
        LoadMonth()
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

    Public Sub LoadMonth()
        cmd = New SqlCommand("SELECT * FROM MonthTable ORDER BY MonthNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "MonthTable")
        cboMonth.DataSource = ds.Tables("MonthTable")
        con.Close()
        cboMonth.SelectedIndex = -1
    End Sub

    Public Sub DefineMonth()
        Dim CurrentMonth As String = ""
        CurrentMonth = cboMonth.Text

        Select Case CurrentMonth
            Case "January"
                BeginMonthPrefix = "01/01/"
                EndMonthPrefix = "01/31/"
            Case "February"
                BeginMonthPrefix = "02/01/"
                EndMonthPrefix = "02/28/"
            Case "March"
                BeginMonthPrefix = "03/01/"
                EndMonthPrefix = "03/31/"
            Case "April"
                BeginMonthPrefix = "04/01/"
                EndMonthPrefix = "04/30/"
            Case "May"
                BeginMonthPrefix = "05/01/"
                EndMonthPrefix = "05/31/"
            Case "June"
                BeginMonthPrefix = "06/01/"
                EndMonthPrefix = "06/30/"
            Case "July"
                BeginMonthPrefix = "07/01/"
                EndMonthPrefix = "07/31/"
            Case "August"
                BeginMonthPrefix = "08/01/"
                EndMonthPrefix = "08/31/"
            Case "September"
                BeginMonthPrefix = "09/01/"
                EndMonthPrefix = "09/30/"
            Case "October"
                BeginMonthPrefix = "10/01/"
                EndMonthPrefix = "10/31/"
            Case "November"
                BeginMonthPrefix = "11/01/"
                EndMonthPrefix = "11/30/"
            Case "December"
                BeginMonthPrefix = "12/01/"
                EndMonthPrefix = "12/31/"
        End Select
    End Sub

    Public Sub LoadSalesTotals()
        'Load Sales Total for Month
        Dim TotalOrderAmountStatement As String = "SELECT SUM(ProductTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND DivisionKey = @DivisionKey AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalOrderAmountCommand As New SqlCommand(TotalOrderAmountStatement, con)
        TotalOrderAmountCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalOrderAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalOrderAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalOrderAmountCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        Dim TotalOrderQuantityStatement As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND DivisionKey = @DivisionKey AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalOrderQuantityCommand As New SqlCommand(TotalOrderQuantityStatement, con)
        TotalOrderQuantityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalOrderQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalOrderQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalOrderQuantityCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalSOAmount = CDbl(TotalOrderAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalSOAmount = 0
        End Try
        Try
            TotalSOQuantity = CInt(TotalOrderQuantityCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalSOQuantity = 0
        End Try
        con.Close()

        txtTotalOrders.Text = FormatCurrency(TotalSOAmount, 2)
        txtNumberOfOrders.Text = FormatNumber(TotalSOQuantity, 0)
        '*******************************************************************************************************************
        'Load Shipment Total for Month
        Dim TotalShipmentAmountStatement As String = "SELECT SUM(ProductTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND DivisionID = @DivisionID AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalShipmentAmountCommand As New SqlCommand(TotalShipmentAmountStatement, con)
        TotalShipmentAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalShipmentAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalShipmentAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalShipmentAmountCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"

        Dim TotalShipmentQuantityStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND DivisionID = @DivisionID AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalShipmentQuantityCommand As New SqlCommand(TotalShipmentQuantityStatement, con)
        TotalShipmentQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalShipmentQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalShipmentQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalShipmentQuantityCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalShipmentAmount = CDbl(TotalShipmentAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalShipmentAmount = 0
        End Try
        Try
            TotalShipmentQuantity = CInt(TotalShipmentQuantityCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalShipmentQuantity = 0
        End Try
        con.Close()

        txtTotalShipments.Text = FormatCurrency(TotalShipmentAmount, 2)
        txtNumberOfShipments.Text = FormatNumber(TotalShipmentQuantity, 0)
        '********************************************************************************************************************
        'Load Invoice Total for Month
        Dim TotalInvoiceAmountStatement As String = "SELECT SUM(ProductTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalInvoiceAmountCommand As New SqlCommand(TotalInvoiceAmountStatement, con)
        TotalInvoiceAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalInvoiceAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalInvoiceAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalInvoiceQuantityStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalInvoiceQuantityCommand As New SqlCommand(TotalInvoiceQuantityStatement, con)
        TotalInvoiceQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalInvoiceQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalInvoiceQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalInvoiceAmount = CDbl(TotalInvoiceAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalInvoiceAmount = 0
        End Try
        Try
            TotalInvoiceQuantity = CInt(TotalInvoiceQuantityCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalInvoiceQuantity = 0
        End Try
        con.Close()

        txtTotalInvoices.Text = FormatCurrency(TotalInvoiceAmount, 2)
        txtNumberOfInvoices.Text = FormatNumber(TotalInvoiceQuantity, 0)
        '********************************************************************************************************************
        'Load Customer Return Total for Month
        Dim TotalCustomerReturnAmountStatement As String = "SELECT SUM(ProductTotal) FROM ReturnProductHeaderTable WHERE ReturnStatus <> @ReturnStatus AND DivisionID = @DivisionID AND ReturnDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalCustomerReturnAmountCommand As New SqlCommand(TotalCustomerReturnAmountStatement, con)
        TotalCustomerReturnAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalCustomerReturnAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalCustomerReturnAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalCustomerReturnAmountCommand.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"

        Dim TotalCustomerReturnQuantityStatement As String = "SELECT COUNT(ReturnNumber) FROM ReturnProductHeaderTable WHERE ReturnStatus <> @ReturnStatus AND DivisionID = @DivisionID AND ReturnDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalCustomerReturnQuantityCommand As New SqlCommand(TotalCustomerReturnQuantityStatement, con)
        TotalCustomerReturnQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalCustomerReturnQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalCustomerReturnQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalCustomerReturnQuantityCommand.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalCustomerReturnAmount = CDbl(TotalCustomerReturnAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalCustomerReturnAmount = 0
        End Try
        Try
            TotalCustomerReturnQuantity = CInt(TotalCustomerReturnQuantityCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalCustomerReturnQuantity = 0
        End Try
        con.Close()

        txtTotalCustomerReturns.Text = FormatCurrency(TotalCustomerReturnAmount, 2)
        txtNumberOfCustomerReturns.Text = FormatNumber(TotalCustomerReturnQuantity, 0)
        '***********************************************************************************************************************
        'Load Customer Return Total for Month
        Dim TotalQuoteAmountStatement As String = "SELECT SUM(ProductTotal) FROM SalesOrderHeaderTable WHERE SOStatus = @SOStatus AND DivisionKey = @DivisionKey AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalQuoteAmountCommand As New SqlCommand(TotalQuoteAmountStatement, con)
        TotalQuoteAmountCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalQuoteAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalQuoteAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalQuoteAmountCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        Dim TotalQuoteQuantityStatement As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE SOStatus = @SOStatus AND DivisionKey = @DivisionKey AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalQuoteQuantityCommand As New SqlCommand(TotalQuoteQuantityStatement, con)
        TotalQuoteQuantityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalQuoteQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalQuoteQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        TotalQuoteQuantityCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuoteAmount = CDbl(TotalQuoteAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalQuoteAmount = 0
        End Try
        Try
            TotalQuoteQuantity = CInt(TotalQuoteQuantityCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalQuoteQuantity = 0
        End Try
        con.Close()

        txtTotalQuoteAmount.Text = FormatCurrency(TotalQuoteAmount, 2)
        txtNumberOfQuotes.Text = FormatNumber(TotalQuoteQuantity, 0)
    End Sub

    Public Sub LoadSalesTotalsForLastYear()
        'Load Sales Total for Month
        Dim TotalOrderAmountStatement As String = "SELECT SUM(ProductTotal) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND DivisionKey = @DivisionKey AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalOrderAmountCommand As New SqlCommand(TotalOrderAmountStatement, con)
        TotalOrderAmountCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalOrderAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = LYBeginDate
        TotalOrderAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = LYEndDate
        TotalOrderAmountCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        'Dim TotalOrderQuantityStatement As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE SOStatus <> @SOStatus AND DivisionKey = @DivisionKey AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        'Dim TotalOrderQuantityCommand As New SqlCommand(TotalOrderQuantityStatement, con)
        'TotalOrderQuantityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        'TotalOrderQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        'TotalOrderQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        'TotalOrderQuantityCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LYTotalOrders = CDbl(TotalOrderAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            LYTotalOrders = 0
        End Try
        'Try
        '    TotalSOQuantity = CInt(TotalOrderQuantityCommand.ExecuteScalar)
        'Catch ex As System.Exception
        '    TotalSOQuantity = 0
        'End Try
        con.Close()

        txtLYTotalOrders.Text = FormatCurrency(LYTotalOrders, 2)
        'txtNumberOfOrders.Text = FormatNumber(TotalSOQuantity, 0)
        '*******************************************************************************************************************
        'Load Shipment Total for Month
        Dim TotalShipmentAmountStatement As String = "SELECT SUM(ProductTotal) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND DivisionID = @DivisionID AND ShipDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalShipmentAmountCommand As New SqlCommand(TotalShipmentAmountStatement, con)
        TotalShipmentAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalShipmentAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = LYBeginDate
        TotalShipmentAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = LYEndDate
        TotalShipmentAmountCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"

        'Dim TotalShipmentQuantityStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE ShipmentStatus <> @ShipmentStatus AND DivisionID = @DivisionID AND ShipDate BETWEEN @BeginDate AND @EndDate"
        'Dim TotalShipmentQuantityCommand As New SqlCommand(TotalShipmentQuantityStatement, con)
        'TotalShipmentQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        'TotalShipmentQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        'TotalShipmentQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        'TotalShipmentQuantityCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LYTotalShipmentAmount = CDbl(TotalShipmentAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            LYTotalShipmentAmount = 0
        End Try
        'Try
        '    TotalShipmentQuantity = CInt(TotalShipmentQuantityCommand.ExecuteScalar)
        'Catch ex As System.Exception
        '    TotalShipmentQuantity = 0
        'End Try
        con.Close()

        txtLYTotalShipments.Text = FormatCurrency(LYTotalShipmentAmount, 2)
        'txtNumberOfShipments.Text = FormatNumber(TotalShipmentQuantity, 0)
        '********************************************************************************************************************
        'Load Invoice Total for Month
        Dim TotalInvoiceAmountStatement As String = "SELECT SUM(ProductTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalInvoiceAmountCommand As New SqlCommand(TotalInvoiceAmountStatement, con)
        TotalInvoiceAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalInvoiceAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = LYBeginDate
        TotalInvoiceAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = LYEndDate

        'Dim TotalInvoiceQuantityStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        'Dim TotalInvoiceQuantityCommand As New SqlCommand(TotalInvoiceQuantityStatement, con)
        'TotalInvoiceQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        'TotalInvoiceQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        'TotalInvoiceQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LYTotalInvoiceAmount = CDbl(TotalInvoiceAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            LYTotalInvoiceAmount = 0
        End Try
        'Try
        '    TotalInvoiceQuantity = CInt(TotalInvoiceQuantityCommand.ExecuteScalar)
        'Catch ex As System.Exception
        '    TotalInvoiceQuantity = 0
        'End Try
        con.Close()

        txtLYTotalInvoices.Text = FormatCurrency(LYTotalInvoiceAmount, 2)
        'txtNumberOfInvoices.Text = FormatNumber(TotalInvoiceQuantity, 0)
        '********************************************************************************************************************
        'Load Customer Return Total for Month
        Dim TotalCustomerReturnAmountStatement As String = "SELECT SUM(ProductTotal) FROM ReturnProductHeaderTable WHERE ReturnStatus <> @ReturnStatus AND DivisionID = @DivisionID AND ReturnDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalCustomerReturnAmountCommand As New SqlCommand(TotalCustomerReturnAmountStatement, con)
        TotalCustomerReturnAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalCustomerReturnAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = LYBeginDate
        TotalCustomerReturnAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = LYEndDate
        TotalCustomerReturnAmountCommand.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"

        'Dim TotalCustomerReturnQuantityStatement As String = "SELECT COUNT(ReturnNumber) FROM ReturnProductHeaderTable WHERE ReturnStatus <> @ReturnStatus AND DivisionID = @DivisionID AND ReturnDate BETWEEN @BeginDate AND @EndDate"
        'Dim TotalCustomerReturnQuantityCommand As New SqlCommand(TotalCustomerReturnQuantityStatement, con)
        'TotalCustomerReturnQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        'TotalCustomerReturnQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        'TotalCustomerReturnQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        'TotalCustomerReturnQuantityCommand.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LYTotalReturnAmount = CDbl(TotalCustomerReturnAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            LYTotalReturnAmount = 0
        End Try
        'Try
        '    TotalCustomerReturnQuantity = CInt(TotalCustomerReturnQuantityCommand.ExecuteScalar)
        'Catch ex As System.Exception
        '    TotalCustomerReturnQuantity = 0
        'End Try
        con.Close()

        txtLYTotalCustomerReturns.Text = FormatCurrency(LYTotalReturnAmount, 2)
        'txtNumberOfCustomerReturns.Text = FormatNumber(TotalCustomerReturnQuantity, 0)
        '***********************************************************************************************************************
        'Load Customer Return Total for Month
        Dim TotalQuoteAmountStatement As String = "SELECT SUM(ProductTotal) FROM SalesOrderHeaderTable WHERE SOStatus = @SOStatus AND DivisionKey = @DivisionKey AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalQuoteAmountCommand As New SqlCommand(TotalQuoteAmountStatement, con)
        TotalQuoteAmountCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalQuoteAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = LYBeginDate
        TotalQuoteAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = LYEndDate
        TotalQuoteAmountCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        'Dim TotalQuoteQuantityStatement As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE SOStatus = @SOStatus AND DivisionKey = @DivisionKey AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        'Dim TotalQuoteQuantityCommand As New SqlCommand(TotalQuoteQuantityStatement, con)
        'TotalQuoteQuantityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        'TotalQuoteQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        'TotalQuoteQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        'TotalQuoteQuantityCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LYTotalQuoteAmount = CDbl(TotalQuoteAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            LYTotalQuoteAmount = 0
        End Try
        'Try
        '    TotalQuoteQuantity = CInt(TotalQuoteQuantityCommand.ExecuteScalar)
        'Catch ex As System.Exception
        '    TotalQuoteQuantity = 0
        'End Try
        con.Close()

        txtLYTotalQuoteAmount.Text = FormatCurrency(LYTotalQuoteAmount, 2)
        'txtNumberOfQuotes.Text = FormatNumber(TotalQuoteQuantity, 0)
    End Sub

    Public Sub LoadMiscTotals()
        '***********************************************************************************************************************
        'Load Freight Billed Total for Month
        Dim TotalBilledFreightStatement As String = "SELECT SUM(BilledFreight) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalBilledFreightCommand As New SqlCommand(TotalBilledFreightStatement, con)
        TotalBilledFreightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalBilledFreightCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalBilledFreightCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalLineFreightStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber LIKE '%FREIGHT%' AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalLineFreightCommand As New SqlCommand(TotalLineFreightStatement, con)
        TotalLineFreightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalLineFreightCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalLineFreightCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalBilledFreight = CDbl(TotalBilledFreightCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalBilledFreight = 0
        End Try
        Try
            TotalLineFreight = CDbl(TotalLineFreightCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalLineFreight = 0
        End Try
        con.Close()

        TotalCombinedFreight = TotalBilledFreight + TotalLineFreight

        txtFreightBilled.Text = FormatCurrency(TotalCombinedFreight, 2)
        '**********************************************************************************************
        'Load RENTAL Billed Total for Month
        Dim TotalBilledRentalStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber LIKE '%RENT%' AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalBilledRentalCommand As New SqlCommand(TotalBilledRentalStatement, con)
        TotalBilledRentalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalBilledRentalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalBilledRentalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalRentalBilled = CDbl(TotalBilledRentalCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalRentalBilled = 0
        End Try
        con.Close()

        txtRentalBilled.Text = FormatCurrency(TotalRentalBilled, 2)
        '**********************************************************************************************
        'Load Labor/Repair Billed Total for Month
        Dim TotalBilledLaborStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND (PartNumber like '%LABOR%' OR PartNumber LIKE '%REPAIR%') AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalBilledLaborCommand As New SqlCommand(TotalBilledLaborStatement, con)
        TotalBilledLaborCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalBilledLaborCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalBilledLaborCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalLaborRepairBilled = CDbl(TotalBilledLaborCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalLaborRepairBilled = 0
        End Try
        con.Close()

        txtLaborBilled.Text = FormatCurrency(TotalLaborRepairBilled, 2)
        '*************************************************************************************************
        'Load Change In Inventory Value
        Dim SumOfAdds, SumOfSubtracts As Double

        Dim SumOfAddsStatement As String = "SELECT SUM(ExtendedCost) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND TransactionMath = 'ADD' AND TransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumOfAddsCommand As New SqlCommand(SumOfAddsStatement, con)
        SumOfAddsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumOfAddsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumOfAddsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim SumOfSubtractsStatement As String = "SELECT SUM(ExtendedCost) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND TransactionMath = 'SUBTRACT' AND TransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumOfSubtractsCommand As New SqlCommand(SumOfSubtractsStatement, con)
        SumOfSubtractsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumOfSubtractsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumOfSubtractsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumOfAdds = CDbl(SumOfAddsCommand.ExecuteScalar)
        Catch ex As System.Exception
            SumOfAdds = 0
        End Try
        Try
            SumOfSubtracts = CDbl(SumOfSubtractsCommand.ExecuteScalar)
        Catch ex As System.Exception
            SumOfSubtracts = 0
        End Try
        con.Close()

        ChangeInInventoryValue = SumOfAdds - SumOfSubtracts

        txtChangeInInventory.Text = FormatCurrency(ChangeInInventoryValue, 2)
        '***********************************************************************************************************************
        'Load Customer Return Total for Month
        Dim TotalAdjustmentAmountStatement As String = "SELECT SUM(Total) FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID AND AdjustmentDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalAdjustmentAmountCommand As New SqlCommand(TotalAdjustmentAmountStatement, con)
        TotalAdjustmentAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalAdjustmentAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalAdjustmentAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalAdjustmentQuantityStatement As String = "SELECT COUNT(AdjustmentNumber) FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID AND AdjustmentDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalAdjustmentQuantityCommand As New SqlCommand(TotalAdjustmentQuantityStatement, con)
        TotalAdjustmentQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalAdjustmentQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalAdjustmentQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalAdjustmentAmount = CDbl(TotalAdjustmentAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalAdjustmentAmount = 0
        End Try
        Try
            TotalAdjustmentQuantity = CInt(TotalAdjustmentQuantityCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalAdjustmentQuantity = 0
        End Try
        con.Close()

        txtTotalAdjustmentDollars.Text = FormatCurrency(TotalAdjustmentAmount, 2)
        txtTotalAdjustmentNumber.Text = FormatNumber(TotalAdjustmentQuantity, 0)
    End Sub

    Public Sub LoadPurchaseTotals()
        'Load Purchase Order Total for Month
        Dim TotalPOAmountStatement As String = "SELECT SUM(ProductTotal) FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID AND PODate BETWEEN @BeginDate AND @EndDate"
        Dim TotalPOAmountCommand As New SqlCommand(TotalPOAmountStatement, con)
        TotalPOAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalPOAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalPOAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalPOQuantityStatement As String = "SELECT COUNT(PurchaseOrderHeaderKey) FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID AND PODate BETWEEN @BeginDate AND @EndDate"
        Dim TotalPOQuantityCommand As New SqlCommand(TotalPOQuantityStatement, con)
        TotalPOQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalPOQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalPOQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalPOAmount = CDbl(TotalPOAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalPOAmount = 0
        End Try
        Try
            TotalPOQuantity = CInt(TotalPOQuantityCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalPOQuantity = 0
        End Try
        con.Close()

        txtTotalPOs.Text = FormatCurrency(TotalPOAmount, 2)
        txtNumberOfPOs.Text = FormatNumber(TotalPOQuantity, 0)
        '*********************************************************************************************************************
        'Load Receiver Total for Month
        Dim TotalReceiverAmountStatement As String = "SELECT SUM(ProductTotal) FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalReceiverAmountCommand As New SqlCommand(TotalReceiverAmountStatement, con)
        TotalReceiverAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalReceiverAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalReceiverAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalReceiverQuantityStatement As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalReceiverQuantityCommand As New SqlCommand(TotalReceiverQuantityStatement, con)
        TotalReceiverQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalReceiverQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalReceiverQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalReceiverAmount = CDbl(TotalReceiverAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalReceiverAmount = 0
        End Try
        Try
            TotalReceiverQuantity = CInt(TotalReceiverQuantityCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalReceiverQuantity = 0
        End Try
        con.Close()

        txtTotalReceived.Text = FormatCurrency(TotalReceiverAmount, 2)
        txtNumberOfReceivers.Text = FormatNumber(TotalReceiverQuantity, 0)
        '*********************************************************************************************************************
        'Load Vendor Return Total for Month
        Dim TotalVendorReturnAmountStatement As String = "SELECT SUM(ProductTotal) FROM VendorReturn WHERE DivisionID = @DivisionID AND ReturnDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalVendorReturnAmountCommand As New SqlCommand(TotalVendorReturnAmountStatement, con)
        TotalVendorReturnAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalVendorReturnAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalVendorReturnAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalVendorReturnQuantityStatement As String = "SELECT COUNT(ReturnNumber) FROM VendorReturn WHERE DivisionID = @DivisionID AND ReturnDate BETWEEN @BeginDate AND @EndDate"
        Dim TotalVendorReturnQuantityCommand As New SqlCommand(TotalVendorReturnQuantityStatement, con)
        TotalVendorReturnQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalVendorReturnQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalVendorReturnQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalVendorReturnAmount = CDbl(TotalVendorReturnAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalVendorReturnAmount = 0
        End Try
        Try
            TotalVendorReturnQuantity = CInt(TotalVendorReturnQuantityCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalVendorReturnQuantity = 0
        End Try
        con.Close()

        txtTotalVendorReturns.Text = FormatCurrency(TotalVendorReturnAmount, 2)
        txtNumberOfVendorReturns.Text = FormatNumber(TotalVendorReturnQuantity, 0)
    End Sub

    Public Sub LoadARData()
        Dim AgingLessThan30, Aging31To45, Aging46To60, Aging61To90, AgingMoreThan90, TotalReceivables As Double

        Dim ARPaymentsReceivedStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPaymentQuery WHERE DivisionID = @DivisionID AND PaymentDate BETWEEN @BeginDate AND @EndDate"
        Dim ARPaymentsReceivedCommand As New SqlCommand(ARPaymentsReceivedStatement, con)
        ARPaymentsReceivedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ARPaymentsReceivedCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        ARPaymentsReceivedCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim ARPaymentsQuantityStatement As String = "SELECT COUNT(ARTransactionKey) FROM ARCustomerPaymentQuery WHERE DivisionID = @DivisionID AND PaymentDate BETWEEN @BeginDate AND @EndDate"
        Dim ARPaymentsQuantityCommand As New SqlCommand(ARPaymentsQuantityStatement, con)
        ARPaymentsQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ARPaymentsQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        ARPaymentsQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim AgingLessThan30Statement As String = "SELECT SUM(AgingLessThan30) FROM ARAgingCategory WHERE DivisionID = @DivisionID"
        Dim AgingLessThan30Command As New SqlCommand(AgingLessThan30Statement, con)
        AgingLessThan30Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Aging31To45Statement As String = "SELECT SUM(Aging31To45) FROM ARAgingCategory WHERE DivisionID = @DivisionID"
        Dim Aging31To45Command As New SqlCommand(Aging31To45Statement, con)
        Aging31To45Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Aging46To60Statement As String = "SELECT SUM(Aging46To60) FROM ARAgingCategory WHERE DivisionID = @DivisionID"
        Dim Aging46To60Command As New SqlCommand(Aging46To60Statement, con)
        Aging46To60Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Aging61To90Statement As String = "SELECT SUM(Aging61To90) FROM ARAgingCategory WHERE DivisionID = @DivisionID"
        Dim Aging61To90Command As New SqlCommand(Aging61To90Statement, con)
        Aging61To90Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim AgingMoreThan90Statement As String = "SELECT SUM(AgingMoreThan90) FROM ARAgingCategory WHERE DivisionID = @DivisionID"
        Dim AgingMoreThan90Command As New SqlCommand(AgingMoreThan90Statement, con)
        AgingMoreThan90Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalCashReceiptsAmount = CDbl(ARPaymentsReceivedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalCashReceiptsAmount = 0
        End Try
        Try
            TotalCashReceiptsQuantity = CInt(ARPaymentsQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            TotalCashReceiptsQuantity = 0
        End Try
        Try
            AgingLessThan30 = CDbl(AgingLessThan30Command.ExecuteScalar)
        Catch ex As Exception
            AgingLessThan30 = 0
        End Try
        Try
            Aging31To45 = CDbl(Aging31To45Command.ExecuteScalar)
        Catch ex As Exception
            Aging31To45 = 0
        End Try
        Try
            Aging46To60 = CDbl(Aging46To60Command.ExecuteScalar)
        Catch ex As Exception
            Aging46To60 = 0
        End Try
        Try
            Aging61To90 = CDbl(Aging61To90Command.ExecuteScalar)
        Catch ex As Exception
            Aging61To90 = 0
        End Try
        Try
            AgingMoreThan90 = CDbl(AgingMoreThan90Command.ExecuteScalar)
        Catch ex As Exception
            AgingMoreThan90 = 0
        End Try
        con.Close()

        TotalReceivables = AgingLessThan30 + Aging31To45 + Aging46To60 + Aging61To90 + AgingMoreThan90

        txtTotalCashReceipts.Text = FormatCurrency(TotalCashReceiptsAmount, 2)
        txtNumberOfCashReceipts.Text = FormatNumber(TotalCashReceiptsQuantity, 0)
        txtAging31.Text = FormatCurrency(Aging31To45, 2)
        txtAging46.Text = FormatCurrency(Aging46To60, 2)
        txtAging61.Text = FormatCurrency(Aging61To90, 2)
        txtAging30.Text = FormatCurrency(AgingLessThan30, 2)
        txtAging90.Text = FormatCurrency(AgingMoreThan90, 2)
        txtTotalOpenInvoices.Text = FormatCurrency(TotalReceivables, 2)
    End Sub

    Public Sub LoadAPData()
        Dim APAgingLessThan30, APAging31To45, APAging46To60, APAging61To90, APAgingMoreThan90, TotalPayables As Double

        Dim APPaymentsMadeStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate BETWEEN @BeginDate AND @EndDate"
        Dim APPaymentsMadeCommand As New SqlCommand(APPaymentsMadeStatement, con)
        APPaymentsMadeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        APPaymentsMadeCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        APPaymentsMadeCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim CountAPPaymentsMadeStatement As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate BETWEEN @BeginDate AND @EndDate"
        Dim CountAPPaymentsMadeCommand As New SqlCommand(CountAPPaymentsMadeStatement, con)
        CountAPPaymentsMadeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CountAPPaymentsMadeCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        CountAPPaymentsMadeCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim APAgingLessThan30Statement As String = "SELECT SUM(AgingLessThan30) FROM APAgingCategory WHERE DivisionID = @DivisionID"
        Dim APAgingLessThan30Command As New SqlCommand(APAgingLessThan30Statement, con)
        APAgingLessThan30Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim APAging31To45Statement As String = "SELECT SUM(Aging31To45) FROM APAgingCategory WHERE DivisionID = @DivisionID"
        Dim APAging31To45Command As New SqlCommand(APAging31To45Statement, con)
        APAging31To45Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim APAging46To60Statement As String = "SELECT SUM(Aging46To60) FROM APAgingCategory WHERE DivisionID = @DivisionID"
        Dim APAging46To60Command As New SqlCommand(APAging46To60Statement, con)
        APAging46To60Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim APAging61To90Statement As String = "SELECT SUM(Aging61To90) FROM APAgingCategory WHERE DivisionID = @DivisionID"
        Dim APAging61To90Command As New SqlCommand(APAging61To90Statement, con)
        APAging61To90Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim APAgingMoreThan90Statement As String = "SELECT SUM(AgingMoreThan90) FROM APAgingCategory WHERE DivisionID = @DivisionID"
        Dim APAgingMoreThan90Command As New SqlCommand(APAgingMoreThan90Statement, con)
        APAgingMoreThan90Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalVoucherAmount = CDbl(APPaymentsMadeCommand.ExecuteScalar)
        Catch ex As Exception
            TotalVoucherAmount = 0
        End Try
        Try
            TotalVoucherQuantity = CInt(CountAPPaymentsMadeCommand.ExecuteScalar)
        Catch ex As Exception
            TotalVoucherQuantity = 0
        End Try
        Try
            APAgingLessThan30 = CDbl(APAgingLessThan30Command.ExecuteScalar)
        Catch ex As Exception
            APAgingLessThan30 = 0
        End Try
        Try
            APAging31To45 = CDbl(APAging31To45Command.ExecuteScalar)
        Catch ex As Exception
            APAging31To45 = 0
        End Try
        Try
            APAging46To60 = CDbl(APAging46To60Command.ExecuteScalar)
        Catch ex As Exception
            APAging46To60 = 0
        End Try
        Try
            APAging61To90 = CDbl(APAging61To90Command.ExecuteScalar)
        Catch ex As Exception
            APAging61To90 = 0
        End Try
        Try
            APAgingMoreThan90 = CDbl(APAgingMoreThan90Command.ExecuteScalar)
        Catch ex As Exception
            APAgingMoreThan90 = 0
        End Try
        con.Close()

        TotalPayables = APAgingLessThan30 + APAging31To45 + APAging46To60 + APAging61To90 + APAgingMoreThan90

        txtTotalPayments.Text = FormatCurrency(TotalVoucherAmount, 2)
        txtNumberOfPayments.Text = FormatNumber(TotalVoucherQuantity, 0)
        txtAPAging31.Text = FormatCurrency(APAging31To45, 2)
        txtAPAging46.Text = FormatCurrency(APAging46To60, 2)
        txtAPAging61.Text = FormatCurrency(APAging61To90, 2)
        txtAPAging30.Text = FormatCurrency(APAgingLessThan30, 2)
        txtAPAging90.Text = FormatCurrency(APAgingMoreThan90, 2)
        txtTotalOpenPayables.Text = FormatCurrency(TotalPayables, 2)
    End Sub

    Public Sub LoadSteelData()
        'Load Steel Purchase Total for Month
        Dim SteelPurchaseAmountStatement As String = "SELECT SUM(SteelPurchaseTotal) FROM SteelPurchaseOrderHeader WHERE DivisionID = @DivisionID AND SteelPurchaseOrderDate BETWEEN @BeginDate AND @EndDate"
        Dim SteelPurchaseAmountCommand As New SqlCommand(SteelPurchaseAmountStatement, con)
        SteelPurchaseAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SteelPurchaseAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SteelPurchaseAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim SteelPurchaseNumberStatement As String = "SELECT COUNT(SteelPurchaseOrderKey) FROM SteelPurchaseOrderHeader WHERE DivisionID = @DivisionID AND SteelPurchaseOrderDate BETWEEN @BeginDate AND @EndDate"
        Dim SteelPurchaseNumberCommand As New SqlCommand(SteelPurchaseNumberStatement, con)
        SteelPurchaseNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SteelPurchaseNumberCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SteelPurchaseNumberCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelPOAmount = CDbl(SteelPurchaseAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelPOAmount = 0
        End Try
        Try
            SteelPOQuantity = CDbl(SteelPurchaseNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelPOQuantity = 0
        End Try
        con.Close()

        txtSteelPOs.Text = FormatCurrency(SteelPOAmount, 2)
        txtNumberOfSteelPOs.Text = FormatNumber(SteelPOQuantity, 0)
        '*******************************************************************************************************************
        'Load Steel Receiver Total for Month
        Dim SteelReceivingAmountStatement As String = "SELECT SUM(SteelTotal) FROM SteelReceivingHeaderTable WHERE DivisionID = @DivisionID AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Dim SteelReceivingAmountCommand As New SqlCommand(SteelReceivingAmountStatement, con)
        SteelReceivingAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SteelReceivingAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SteelReceivingAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim SteelReceivingNumberStatement As String = "SELECT COUNT(SteelReceivingHeaderKey) FROM SteelReceivingHeaderTable WHERE DivisionID = @DivisionID AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Dim SteelReceivingNumberCommand As New SqlCommand(SteelReceivingNumberStatement, con)
        SteelReceivingNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SteelReceivingNumberCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SteelReceivingNumberCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelReceiverAmount = CDbl(SteelReceivingAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelReceiverAmount = 0
        End Try
        Try
            SteelReceiverQuantity = CDbl(SteelReceivingNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelReceiverQuantity = 0
        End Try
        con.Close()

        txtSteelReceivers.Text = FormatCurrency(SteelReceiverAmount, 2)
        txtNumberOfSteelReceipts.Text = FormatNumber(SteelReceiverQuantity, 0)
        '*******************************************************************************************************************
        'Load Steel Adjustment Total for Month
        Dim SteelAdjustmentAmountStatement As String = "SELECT SUM(AdjustmentTotal) FROM SteelAdjustmentTable WHERE DivisionID = @DivisionID AND AdjustmentDate BETWEEN @BeginDate AND @EndDate"
        Dim SteelAdjustmentAmountCommand As New SqlCommand(SteelAdjustmentAmountStatement, con)
        SteelAdjustmentAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SteelAdjustmentAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SteelAdjustmentAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim SteelAdjustmentNumberStatement As String = "SELECT COUNT(SteelAdjustmentKey) FROM SteelAdjustmentTable WHERE DivisionID = @DivisionID AND AdjustmentDate BETWEEN @BeginDate AND @EndDate"
        Dim SteelAdjustmentNumberCommand As New SqlCommand(SteelAdjustmentNumberStatement, con)
        SteelAdjustmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SteelAdjustmentNumberCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SteelAdjustmentNumberCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelAdjustmentAmount = CDbl(SteelAdjustmentAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelAdjustmentAmount = 0
        End Try
        Try
            SteelAdjustmentQuantity = CDbl(SteelAdjustmentNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelAdjustmentQuantity = 0
        End Try
        con.Close()

        txtSteelAdjustments.Text = FormatCurrency(SteelAdjustmentAmount, 2)
        txtNumberOfSteelAdj.Text = FormatNumber(SteelAdjustmentQuantity, 0)
        '*******************************************************************************************************************
        'Load Steel Return Total for Month
        Dim SteelReturnAmountStatement As String = "SELECT SUM(ProductTotal) FROM SteelReturnHeaderTable WHERE DivisionID = @DivisionID AND ReturnDate BETWEEN @BeginDate AND @EndDate"
        Dim SteelReturnAmountCommand As New SqlCommand(SteelReturnAmountStatement, con)
        SteelReturnAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SteelReturnAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SteelReturnAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim SteelReturnNumberStatement As String = "SELECT COUNT(SteelReturnNumber) FROM SteelReturnHeaderTable WHERE DivisionID = @DivisionID AND ReturnDate BETWEEN @BeginDate AND @EndDate"
        Dim SteelReturnNumberCommand As New SqlCommand(SteelReturnNumberStatement, con)
        SteelReturnNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SteelReturnNumberCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SteelReturnNumberCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelReturnAmount = CDbl(SteelReturnAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelReturnAmount = 0
        End Try
        Try
            SteelReturnQuantity = CDbl(SteelReturnNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelReturnQuantity = 0
        End Try
        con.Close()

        txtSteelReturns.Text = FormatCurrency(SteelReturnAmount, 2)
        txtNumberOfSteelReturns.Text = FormatNumber(SteelReturnQuantity, 0)
    End Sub

    Public Sub LoadSteelStockStatus()
        'Load Steel Return Total for Month
        Dim SteelUsageQuantityStatement As String = "SELECT SUM(UsageWeight) FROM SteelUsageTable WHERE DivisionID = @DivisionID AND UsageDate BETWEEN @BeginDate AND @EndDate"
        Dim SteelUsageQuantityCommand As New SqlCommand(SteelUsageQuantityStatement, con)
        SteelUsageQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SteelUsageQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SteelUsageQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim SteelYardReturnQuantityStatement As String = "SELECT SUM(ReturnWeight) FROM SteelYardEntryTable WHERE DivisionID = @DivisionID AND ReturnDate BETWEEN @BeginDate AND @EndDate"
        Dim SteelYardReturnQuantityCommand As New SqlCommand(SteelYardReturnQuantityStatement, con)
        SteelYardReturnQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SteelYardReturnQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SteelYardReturnQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelUsage = CDbl(SteelUsageQuantityCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelUsage = 0
        End Try
        Try
            SteelYardReturn = CDbl(SteelYardReturnQuantityCommand.ExecuteScalar)
        Catch ex As System.Exception
            SteelYardReturn = 0
        End Try
        con.Close()

        SteelNetChange = SteelUsage - SteelYardReturn

        txtSteelUsageQuantity.Text = FormatNumber(SteelUsage, 0)
        txtSteelYardQuantity.Text = FormatNumber(SteelYardReturn, 0)
        txtSteelUsagenet.Text = FormatNumber(SteelNetChange, 0)
    End Sub

    Public Sub ClearData()
        cboMonth.SelectedIndex = -1
        cboYear.SelectedIndex = -1

        txtAging30.Clear()
        txtAging31.Clear()
        txtAging46.Clear()
        txtAging61.Clear()
        txtAging90.Clear()
        txtAPAging30.Clear()
        txtAPAging31.Clear()
        txtAPAging46.Clear()
        txtAging61.Clear()
        txtAPAging90.Clear()
        txtChangeInInventory.Clear()
        txtFreightBilled.Clear()
        txtLaborBilled.Clear()
        txtNumberOfCashReceipts.Clear()
        txtNumberOfCustomerReturns.Clear()
        txtNumberOfInvoices.Clear()
        txtNumberOfOrders.Clear()
        txtNumberOfPayments.Clear()
        txtNumberOfPOs.Clear()
        txtNumberOfQuotes.Clear()
        txtNumberOfReceivers.Clear()
        txtNumberOfShipments.Clear()
        txtNumberOfVendorReturns.Clear()
        txtNumberOfSteelAdj.Clear()
        txtNumberOfSteelPOs.Clear()
        txtNumberOfSteelReceipts.Clear()
        txtNumberOfSteelReturns.Clear()
        txtRentalBilled.Clear()
        txtSteelAdjustments.Clear()
        txtSteelPOs.Clear()
        txtSteelReceivers.Clear()
        txtSteelReturns.Clear()
        txtSteelUsagenet.Clear()
        txtSteelUsageQuantity.Clear()
        txtSteelYardQuantity.Clear()
        txtTotalAdjustmentDollars.Clear()
        txtTotalAdjustmentNumber.Clear()
        txtTotalCashReceipts.Clear()
        txtTotalCustomerReturns.Clear()
        txtTotalInvoices.Clear()
        txtTotalOpenInvoices.Clear()
        txtTotalOpenPayables.Clear()
        txtTotalOrders.Clear()
        txtTotalPayments.Clear()
        txtTotalPOs.Clear()
        txtTotalQuoteAmount.Clear()
        txtTotalReceived.Clear()
        txtTotalShipments.Clear()
        txtTotalVendorReturns.Clear()
        txtLYTotalCustomerReturns.Clear()
        txtLYTotalInvoices.Clear()
        txtLYTotalOrders.Clear()
        txtLYTotalQuoteAmount.Clear()
        txtLYTotalShipments.Clear()
    End Sub

    Public Sub ClearVariables()
        TotalPOQuantity = 0
        TotalSOQuantity = 0
        TotalShipmentQuantity = 0
        TotalInvoiceQuantity = 0
        TotalCustomerReturnQuantity = 0
        TotalReceiverQuantity = 0
        TotalVendorReturnQuantity = 0
        TotalAdjustmentQuantity = 0
        TotalCashReceiptsQuantity = 0
        TotalVoucherQuantity = 0
        TotalQuoteQuantity = 0
        TotalPOAmount = 0
        TotalSOAmount = 0
        TotalShipmentAmount = 0
        TotalInvoiceAmount = 0
        TotalCustomerReturnAmount = 0
        TotalReceiverAmount = 0
        TotalVendorReturnAmount = 0
        TotalAdjustmentAmount = 0
        TotalInventoryChange = 0
        TotalCashReceiptsAmount = 0
        TotalVoucherAmount = 0
        TotalQuoteAmount = 0
        SteelPOAmount = 0
        SteelPOQuantity = 0
        SteelYardReturn = 0
        SteelUsage = 0
        SteelNetChange = 0
        SteelReceiverQuantity = 0
        SteelReceiverAmount = 0
        SteelReturnAmount = 0
        SteelReturnQuantity = 0
        SteelAdjustmentAmount = 0
        SteelAdjustmentQuantity = 0
        ChangeInInventoryValue = 0
        TotalRentalBilled = 0
        TotalLaborRepairBilled = 0
        TotalLineFreight = 0
        TotalBilledFreight = 0
        TotalCombinedFreight = 0
        LYTotalQuoteAmount = 0
        LYTotalReturnAmount = 0
        LYTotalOrders = 0
        LYTotalInvoiceAmount = 0
        LYTotalShipmentAmount = 0
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

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Dim CurrentYear, YearMinusOne As Integer

        'Define Month
        DefineMonth()

        'Load year and create begin and end date
        BeginYearSuffix = cboYear.Text
        EndYearSuffix = cboYear.Text

        BeginDate = BeginMonthPrefix + BeginYearSuffix
        EndDate = EndMonthPrefix + EndYearSuffix

        CurrentYear = Val(cboYear.Text)
        YearMinusOne = CurrentYear - 1
        LYEndYearSuffix = CStr(YearMinusOne)

        LYBeginDate = BeginMonthPrefix + LYEndYearSuffix
        LYEndDate = EndMonthPrefix + LYEndYearSuffix

        'Run Queries
        LoadSalesTotals()
        LoadSalesTotalsForLastYear()
        LoadMiscTotals()
        LoadPurchaseTotals()
        LoadAPData()
        LoadARData()
        LoadSteelData()
        LoadSteelStockStatus()

        cmdPrint.Enabled = True
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        'Delete data in temp table for this division
        cmd = New SqlCommand("DELETE FROM MonthTotalTempTable WHERE DivisionID = @DivisionID AND MonthField = @MonthField AND YearField = @YearField", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '************************************************************************************************
        'Round Variables
        TotalQuoteAmount = Math.Round(TotalQuoteAmount, 2)
        TotalAdjustmentAmount = Math.Round(TotalAdjustmentAmount, 2)
        TotalCashReceiptsAmount = Math.Round(TotalCashReceiptsAmount, 2)
        TotalCombinedFreight = Math.Round(TotalCombinedFreight, 2)
        TotalCustomerReturnAmount = Math.Round(TotalCustomerReturnAmount, 2)
        TotalInventoryChange = Math.Round(TotalInventoryChange, 2)
        TotalInvoiceAmount = Math.Round(TotalInvoiceAmount, 2)
        TotalLaborRepairBilled = Math.Round(TotalLaborRepairBilled, 2)
        TotalRentalBilled = Math.Round(TotalRentalBilled, 2)
        TotalPOAmount = Math.Round(TotalPOAmount, 2)
        TotalReceiverAmount = Math.Round(TotalReceiverAmount, 2)
        TotalShipmentAmount = Math.Round(TotalShipmentAmount, 2)
        TotalSOAmount = Math.Round(TotalSOAmount, 2)
        TotalVendorReturnAmount = Math.Round(TotalVendorReturnAmount, 2)
        TotalVoucherAmount = Math.Round(TotalVoucherAmount, 2)
        SteelAdjustmentAmount = Math.Round(SteelAdjustmentAmount, 2)
        SteelPOAmount = Math.Round(SteelPOAmount, 2)
        SteelReturnAmount = Math.Round(SteelReturnAmount, 2)
        SteelReceiverAmount = Math.Round(SteelReceiverAmount, 2)
        SteelNetChange = Math.Round(SteelNetChange, 0)


        '************************************************************************************************
        'Write values to temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Month To Date Quotes (Count)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalQuoteQuantity
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************

        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Month To Date Quotes (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalQuoteAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Month To Date Orders (Count)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalSOQuantity
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Month To Date Orders (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalSOAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Month To Date Shipments (Count)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalShipmentQuantity
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************

        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Month To Date Shipments (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalShipmentAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Month To Date Customer Returns (Count)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalCustomerReturnQuantity
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Month To Date Customer Returns (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalCustomerReturnAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Month To Date Invoices (Count)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalInvoiceQuantity
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Month To Date Invoices (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalInvoiceAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Freight Billed for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalCombinedFreight
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Labor/Repair Charges Billed for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalLaborRepairBilled
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Rental Charges Billed for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalRentalBilled
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Changes in Inventory Value for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = ChangeInInventoryValue
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Inventory Adjustments for Month (Count)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalAdjustmentQuantity
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Inventory Adjustments for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalAdjustmentAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Purchase Orders for Month (Count)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalPOQuantity
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Purchase Orders for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalPOAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Receivers for Month (Count)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalReceiverQuantity
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Receivers for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalReceiverAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Vendor Returns for Month (Count)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalVendorReturnQuantity
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Vendor Returns for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalVendorReturnAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Cash Receipts for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalCashReceiptsAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total A/P Payments for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = TotalVoucherAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        'Add Steel Totals

        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Steel Purchases for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = SteelPOAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Steel Received for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = SteelReceiverAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Steel Returned for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = SteelReturnAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Steel Adjusted for Month (Dollars)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = SteelAdjustmentAmount
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Write values top temp table in database
        cmd = New SqlCommand("Insert Into MonthTotalTempTable (DivisionID, FieldText, QuantityField, AmountField, MonthField, YearField, PrintDate)Values(@DivisionID, @FieldText, @QuantityField, @AmountField, @MonthField, @YearField, @PrintDate)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@FieldText", SqlDbType.VarChar).Value = "Total Steel Used in Production for Month (Lbs.)"
            .Add("@QuantityField", SqlDbType.VarChar).Value = 0
            .Add("@AmountField", SqlDbType.VarChar).Value = SteelNetChange
            .Add("@MonthField", SqlDbType.VarChar).Value = cboMonth.Text
            .Add("@YearField", SqlDbType.VarChar).Value = cboYear.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************
        GlobalMonthField = cboMonth.Text
        GlobalYearField = cboYear.Text
        GlobalDivisionCode = cboDivisionID.Text
        '********************************************************************************************************************
        'Open Print Form
        Using NewPrintMonthSnapshot As New PrintMonthSnapshot
            Dim Result = NewPrintMonthSnapshot.ShowDialog()
        End Using
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        cmdPrint.Enabled = False
    End Sub
End Class