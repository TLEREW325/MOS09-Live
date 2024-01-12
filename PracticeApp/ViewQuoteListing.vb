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
Public Class ViewQuoteListing
    Inherits System.Windows.Forms.Form

    Dim CustomerFilter, CustPOFilter, SalespersonFilter, QuoteFilter, DateFilter As String
    Dim QuoteNumber As Integer
    Dim strQuoteNumber As String

    Dim BeginDate, EndDate As Date
    Dim QuoteTotal, ProductTotal, FreightCharge, TotalSalesTax, TotalSalesTax2, TotalSalesTax3, GrandTotalTax As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewQuoteListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        LoadCurrentDivision()
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

    Private Sub dgvQuoteHeader_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvQuoteHeader.CellDoubleClick
        Dim RowQuoteNumber As Integer
        Dim RowIndex As Integer = Me.dgvQuoteHeader.CurrentCell.RowIndex

        RowQuoteNumber = Me.dgvQuoteHeader.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value

        GlobalSONumber = RowQuoteNumber
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
            Using NewPrintQuoteRemote As New PrintQuoteRemote
                Dim result = NewPrintQuoteRemote.ShowDialog()
            End Using
        Else
            Using NewPrintQuote As New PrintQuote
                Dim result = NewPrintQuote.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ViewQuoteListing_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
        ClearVariables()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvQuoteHeader.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSalesperson.Text <> "" Then
            SalespersonFilter = " AND Salesperson = '" + cboSalesperson.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustPOFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            CustPOFilter = ""
        End If
        If cboQuoteNumberFilter.Text <> "" Then
            QuoteNumber = Val(cboQuoteNumberFilter.Text)
            strQuoteNumber = CStr(QuoteNumber)
            QuoteFilter = " AND SalesOrderKey = '" + strQuoteNumber + "'"
        Else
            QuoteFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey and SOStatus = @SOStatus" + CustomerFilter + CustPOFilter + QuoteFilter + SalespersonFilter + DateFilter + " ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderHeaderTable")
        dgvQuoteHeader.DataSource = ds.Tables("SalesOrderHeaderTable")
        cboQuoteNumber.DataSource = ds.Tables("SalesOrderHeaderTable")
        con.Close()
    End Sub

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerList")
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerName.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadQuoteNumber()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SOStatus = @SOStatus ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SalesOrderHeaderTable")
        cboQuoteNumberFilter.DataSource = ds3.Tables("SalesOrderHeaderTable")
        con.Close()
        cboQuoteNumberFilter.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesperson()
        cmd = New SqlCommand("SELECT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboSalesperson.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboSalesperson.SelectedIndex = -1
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
        LoadCustomerList()
        LoadCustomerName()
        LoadSalesperson()
        LoadQuoteNumber()
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Public Sub LoadTotalsByFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSalesperson.Text <> "" Then
            SalespersonFilter = " AND Salesperson = '" + cboSalesperson.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustPOFilter = " AND CustomerPO = '" + txtCustomerPO.Text + "'"
        Else
            CustPOFilter = ""
        End If
        If cboQuoteNumberFilter.Text <> "" Then
            QuoteNumber = Val(cboQuoteNumberFilter.Text)
            strQuoteNumber = CStr(QuoteNumber)
            QuoteFilter = " AND SalesOrderKey = '" + strQuoteNumber + "'"
        Else
            QuoteFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        Dim QuoteTotalStatement As String = "SELECT SUM(SOTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey and SOStatus = @SOStatus" + CustomerFilter + CustPOFilter + SalespersonFilter + QuoteFilter + DateFilter
        Dim QuoteTotalCommand As New SqlCommand(QuoteTotalStatement, con)
        QuoteTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        QuoteTotalCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        QuoteTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        QuoteTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim ProductTotalStatement As String = "SELECT SUM(ProductTotal) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey and SOStatus = @SOStatus" + CustomerFilter + CustPOFilter + SalespersonFilter + QuoteFilter + DateFilter
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        ProductTotalCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        ProductTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        ProductTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim FreightChargeStatement As String = "SELECT SUM(FreightCharge) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey and SOStatus = @SOStatus" + CustomerFilter + CustPOFilter + SalespersonFilter + QuoteFilter + DateFilter
        Dim FreightChargeCommand As New SqlCommand(FreightChargeStatement, con)
        FreightChargeCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        FreightChargeCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        FreightChargeCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        FreightChargeCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalSalesTaxStatement As String = "SELECT SUM(TotalSalesTax) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey and SOStatus = @SOStatus" + CustomerFilter + CustPOFilter + SalespersonFilter + QuoteFilter + DateFilter
        Dim TotalSalesTaxCommand As New SqlCommand(TotalSalesTaxStatement, con)
        TotalSalesTaxCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalSalesTaxCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        TotalSalesTaxCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalSalesTaxCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalSalesTax2Statement As String = "SELECT SUM(TotalSalesTax2) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey and SOStatus = @SOStatus" + CustomerFilter + CustPOFilter + SalespersonFilter + QuoteFilter + DateFilter
        Dim TotalSalesTax2Command As New SqlCommand(TotalSalesTax2Statement, con)
        TotalSalesTax2Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalSalesTax2Command.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        TotalSalesTax2Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalSalesTax2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalSalesTax3Statement As String = "SELECT SUM(TotalSalesTax3) FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey and SOStatus = @SOStatus" + CustomerFilter + CustPOFilter + SalespersonFilter + QuoteFilter + DateFilter
        Dim TotalSalesTax3Command As New SqlCommand(TotalSalesTax3Statement, con)
        TotalSalesTax3Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalSalesTax3Command.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        TotalSalesTax3Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalSalesTax3Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QuoteTotal = CDbl(QuoteTotalCommand.ExecuteScalar)
        Catch ex As Exception
            QuoteTotal = 0
        End Try
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            FreightCharge = CDbl(FreightChargeCommand.ExecuteScalar)
        Catch ex As Exception
            FreightCharge = 0
        End Try
        Try
            TotalSalesTax = CDbl(TotalSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            TotalSalesTax = 0
        End Try
        Try
            TotalSalesTax2 = CDbl(TotalSalesTax2Command.ExecuteScalar)
        Catch ex As Exception
            TotalSalesTax2 = 0
        End Try
        Try
            TotalSalesTax3 = CDbl(TotalSalesTax3Command.ExecuteScalar)
        Catch ex As Exception
            TotalSalesTax3 = 0
        End Try
        con.Close()

        GrandTotalTax = TotalSalesTax + TotalSalesTax2 + TotalSalesTax3

        txtFreightTotal.Text = FormatCurrency(FreightCharge, 2)
        txtTaxTotal.Text = FormatCurrency(GrandTotalTax, 2)
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtQuoteTotal.Text = FormatCurrency(QuoteTotal, 2)
    End Sub

    Public Sub ClearData()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesperson.SelectedIndex = -1
        cboQuoteNumberFilter.SelectedIndex = -1

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        txtCustomerPO.Clear()
        txtQuoteTotal.Clear()
        txtFreightTotal.Clear()
        txtProductTotal.Clear()
        txtTaxTotal.Clear()

        chkDateRange.Checked = False

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        CustomerFilter = ""
        CustPOFilter = ""
        SalespersonFilter = ""
        QuoteFilter = ""
        DateFilter = ""
        QuoteNumber = 0
        strQuoteNumber = ""
        QuoteTotal = 0
        ProductTotal = 0
        TotalSalesTax = 0
        GrandTotalTax = 0
        TotalSalesTax2 = 0
        TotalSalesTax3 = 0
        FreightCharge = 0
    End Sub

    Private Sub cmdOpenQuoteForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenQuoteForm.Click
        GlobalSONumber = Val(cboQuoteNumber.Text)

        Dim NewQuoteForm As New QuoteForm
        NewQuoteForm.Show()
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilters()
        LoadTotalsByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdReprintQuote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintQuote.Click
        GlobalSONumber = Val(cboQuoteNumber.Text)
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
            Using NewPrintQuoteRemote As New PrintQuoteRemote
                Dim result = NewPrintQuoteRemote.ShowDialog()
            End Using
        Else
            Using NewPrintQuote As New PrintQuote
                Dim result = NewPrintQuote.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ReprintQuoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReprintQuoteToolStripMenuItem.Click
        GlobalSONumber = Val(cboQuoteNumber.Text)
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
            Using NewPrintQuoteRemote As New PrintQuoteRemote
                Dim result = NewPrintQuoteRemote.ShowDialog()
            End Using
        Else
            Using NewPrintQuote As New PrintQuote
                Dim result = NewPrintQuote.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintQuoteHeadersFiltered As New PrintQuoteHeadersFiltered
            Dim result = NewPrintQuoteHeadersFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintQuoteListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintQuoteListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintQuoteHeadersFiltered As New PrintQuoteHeadersFiltered
            Dim result = NewPrintQuoteHeadersFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvQuoteHeader_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQuoteHeader.CellValueChanged
        Dim CustomerPO, Salesperson, ShipVia, HeaderComment, ShipDate, SODate As String
        Dim QuoteNumber As Integer

        If Me.dgvQuoteHeader.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvQuoteHeader.CurrentCell.RowIndex

            Try
                QuoteNumber = Me.dgvQuoteHeader.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value
            Catch ex As Exception
                QuoteNumber = 0
            End Try
            Try
                CustomerPO = Me.dgvQuoteHeader.Rows(RowIndex).Cells("CustomerPOColumn").Value
            Catch ex As Exception
                CustomerPO = ""
            End Try
            Try
                Salesperson = Me.dgvQuoteHeader.Rows(RowIndex).Cells("SalespersonColumn").Value
            Catch ex As Exception
                Salesperson = ""
            End Try
            Try
                ShipVia = Me.dgvQuoteHeader.Rows(RowIndex).Cells("ShipViaColumn").Value
            Catch ex As Exception
                ShipVia = ""
            End Try
            Try
                HeaderComment = Me.dgvQuoteHeader.Rows(RowIndex).Cells("HeaderCommentColumn").Value
            Catch ex As Exception
                HeaderComment = ""
            End Try
            Try
                ShipDate = Me.dgvQuoteHeader.Rows(RowIndex).Cells("ShippingDateColumn").Value
            Catch ex As Exception
                ShipDate = ""
            End Try
            Try
                SODate = Me.dgvQuoteHeader.Rows(RowIndex).Cells("SalesOrderDateColumn").Value
            Catch ex As Exception
                SODate = ""
            End Try

            Try
                'UPDATE Quote Table
                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET CustomerPO = @CustomerPO, Salesperson = @Salesperson, ShipVia = @ShipVia, HeaderComment = @HeaderComment, SalesOrderDate = @SalesOrderDate, ShippingDate = @ShippingDate WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = QuoteNumber
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                    .Add("@Salesperson", SqlDbType.VarChar).Value = Salesperson
                    .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                    .Add("@HeaderComment", SqlDbType.VarChar).Value = HeaderComment
                    .Add("@SalesOrderDate", SqlDbType.VarChar).Value = SODate
                    .Add("@ShippingDate", SqlDbType.VarChar).Value = ShipDate
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        End If
    End Sub
End Class