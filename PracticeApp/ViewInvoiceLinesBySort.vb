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
Public Class ViewInvoiceLinesBySort
    Inherits System.Windows.Forms.Form

    Dim TextFilter, CustomerFilter, PartFilter, DateFilter, ItemClassFilter, CustPOFilter, SPLFilter, SalespersonFilter As String
    Dim BeginDate, EndDate As Date
    Dim strBeginDate, strEndDate As String
    Dim ProductTotal, COGS, ProfitMargin, TotalQuantity As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewInvoiceLinesBySalesperson_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.SalesProductLine' table. You can move, or remove it, as needed.
        Me.SalesProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.SalesProductLine)
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
        cboSalesLine.SelectedIndex = -1
        LoadSalesperson()
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

    Public Sub ClearDataInDatagrid()
        Me.dgvInvoiceLines.Columns("DivisionIDColumn").Visible = False
        dgvInvoiceLines.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilter()
        'Construct SQL Statement
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = " + "'" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustPOFilter = " AND CustomerPO LIKE " + "'%" + usefulFunctions.checkQuote(txtCustomerPO.Text) + "%'"
        Else
            CustPOFilter = ""
        End If
        If cboSalesperson.Text <> "" Then
            SalespersonFilter = " AND Salesperson = " + "'" + cboSalesperson.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If cboItemClass.Text <> "" Then
            ItemClassFilter = " AND ItemClass = " + "'" + cboItemClass.Text + "'"
        Else
            ItemClassFilter = ""
        End If
        If cboSalesLine.Text <> "" Then
            SPLFilter = " AND SalesProdLineID = " + "'" + cboSalesLine.Text + "'"
        Else
            SPLFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (CustomerPO LIKE " + "'%" + txtTextFilter.Text + "%' OR PartNumber LIKE " + "'%" + txtTextFilter.Text + "%' OR PartDescription LIKE " + "'%" + txtTextFilter.Text + "%' OR CustomerID LIKE " + "'%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM InvoiceLineQueryICSP WHERE DivisionID <> @DivisionID" + SalespersonFilter + ItemClassFilter + PartFilter + CustPOFilter + CustomerFilter + SPLFilter + TextFilter + DateFilter + " ORDER BY DivisionID, InvoiceHeaderKey", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceLineQueryICSP")
            dgvInvoiceLines.DataSource = ds.Tables("InvoiceLineQueryICSP")
            con.Close()

            Me.dgvInvoiceLines.Columns("DivisionIDColumn").Visible = True

            LoadTotalsADM()
        Else
            cmd = New SqlCommand("SELECT * FROM InvoiceLineQueryICSP WHERE DivisionID = @DivisionID" + SalespersonFilter + ItemClassFilter + PartFilter + CustPOFilter + CustomerFilter + SPLFilter + TextFilter + DateFilter + " ORDER BY InvoiceHeaderKey", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceLineQueryICSP")
            dgvInvoiceLines.DataSource = ds.Tables("InvoiceLineQueryICSP")
            con.Close()

            Me.dgvInvoiceLines.Columns("DivisionIDColumn").Visible = False

            LoadTotals()
        End If
    End Sub

    Public Sub LoadSecurity()
        Select Case EmployeeCompanyCode
            Case "TWD"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtProfitMargin.Visible = True
                    txtCOGS.Visible = True
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtProfitMargin.Visible = False
                    txtCOGS.Visible = False
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = False
                End If
            Case "TWE"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Or EmployeeSecurityCode = "1003" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtProfitMargin.Visible = True
                    txtCOGS.Visible = True
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtProfitMargin.Visible = False
                    txtCOGS.Visible = False
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = False
                End If
            Case "TFP"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtProfitMargin.Visible = True
                    txtCOGS.Visible = True
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtProfitMargin.Visible = False
                    txtCOGS.Visible = False
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = False
                End If
            Case "ADM"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtProfitMargin.Visible = True
                    txtCOGS.Visible = True
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtProfitMargin.Visible = False
                    txtCOGS.Visible = False
                    dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = False
                End If
            Case Else
                lblCOGS.Visible = True
                lblMargin.Visible = True
                txtProfitMargin.Visible = True
                txtCOGS.Visible = True
                dgvInvoiceLines.Columns("ExtendedCOSColumn").Visible = True
        End Select
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

    Public Sub LoadCustomer()
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

    Public Sub LoadSalesperson()
        cmd = New SqlCommand("SELECT DISTINCT (SalesPersonID) FROM EmployeeData WHERE DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2 ORDER BY SalesPersonID", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "ADM"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "EmployeeData")
        cboSalesperson.DataSource = ds3.Tables("EmployeeData")
        con.Close()
        cboSalesperson.SelectedIndex = -1
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

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ItemList")
        cboPartDescription.DataSource = ds5.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadTotalsADM()
        Dim ProductTotalDateStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQueryICSP WHERE DivisionID <> @DivisionID" + SalespersonFilter + ItemClassFilter + PartFilter + CustPOFilter + CustomerFilter + SPLFilter + TextFilter + DateFilter
        Dim ProductTotalDateCommand As New SqlCommand(ProductTotalDateStatement, con)
        ProductTotalDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        ProductTotalDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        ProductTotalDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim COGSDateStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineQueryICSP WHERE DivisionID <> @DivisionID" + SalespersonFilter + ItemClassFilter + PartFilter + CustPOFilter + CustomerFilter + SPLFilter + TextFilter + DateFilter
        Dim COGSDateCommand As New SqlCommand(COGSDateStatement, con)
        COGSDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        COGSDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        COGSDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQueryICSP WHERE DivisionID <> @DivisionID" + SalespersonFilter + ItemClassFilter + PartFilter + CustPOFilter + CustomerFilter + SPLFilter + TextFilter + DateFilter
        Dim TotalQuantityCommand As New SqlCommand(TotalQuantityStatement, con)
        TotalQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        TotalQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalDateCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            COGS = CDbl(COGSDateCommand.ExecuteScalar)
        Catch ex As Exception
            COGS = 0
        End Try
        Try
            TotalQuantity = CDbl(TotalQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            TotalQuantity = 0
        End Try
        con.Close()

        If ProductTotal <> 0 Then
            ProfitMargin = 1 - (COGS / ProductTotal)
        Else
            ProfitMargin = 0.0
        End If

        txtTotalSales.Text = FormatCurrency(ProductTotal, 2)
        txtCOGS.Text = FormatCurrency(COGS, 2)
        txtProfitMargin.Text = FormatPercent(ProfitMargin, 2)
        txtTotalQuantity.Text = FormatNumber(TotalQuantity, 1)
    End Sub

    Public Sub LoadTotals()
        Dim ProductTotalDateStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQueryICSP WHERE DivisionID = @DivisionID" + SalespersonFilter + ItemClassFilter + PartFilter + CustPOFilter + CustomerFilter + SPLFilter + TextFilter + DateFilter
        Dim ProductTotalDateCommand As New SqlCommand(ProductTotalDateStatement, con)
        ProductTotalDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ProductTotalDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        ProductTotalDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim COGSDateStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineQueryICSP WHERE DivisionID = @DivisionID" + SalespersonFilter + ItemClassFilter + PartFilter + CustPOFilter + CustomerFilter + SPLFilter + TextFilter + DateFilter
        Dim COGSDateCommand As New SqlCommand(COGSDateStatement, con)
        COGSDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        COGSDateCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        COGSDateCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQueryICSP WHERE DivisionID = @DivisionID" + SalespersonFilter + ItemClassFilter + PartFilter + CustPOFilter + CustomerFilter + SPLFilter + TextFilter + DateFilter
        Dim TotalQuantityCommand As New SqlCommand(TotalQuantityStatement, con)
        TotalQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalDateCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            COGS = CDbl(COGSDateCommand.ExecuteScalar)
        Catch ex As Exception
            COGS = 0
        End Try
        Try
            TotalQuantity = CDbl(TotalQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            TotalQuantity = 0
        End Try
        con.Close()

        If ProductTotal <> 0 Then
            ProfitMargin = 1 - (COGS / ProductTotal)
        Else
            ProfitMargin = 0.0
        End If

        txtTotalSales.Text = FormatCurrency(ProductTotal, 2)
        txtCOGS.Text = FormatCurrency(COGS, 2)
        txtProfitMargin.Text = FormatPercent(ProfitMargin, 2)
        txtTotalQuantity.Text = FormatNumber(TotalQuantity, 1)
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

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Public Sub ClearData()
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboItemClass.Text = ""
        cboPartDescription.Text = ""
        cboPartNumber.Text = ""
        cboSalesLine.Text = ""
        cboSalesperson.Text = ""

        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboSalesLine.SelectedIndex = -1
        cboSalesperson.SelectedIndex = -1

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False

        txtCOGS.Clear()
        txtProfitMargin.Clear()
        txtTotalSales.Clear()
        txtTotalQuantity.Clear()
        txtTextFilter.Clear()

        cboSalesperson.Focus()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        LoadPartDescription()
        LoadCustomer()
        LoadCustomerName()
        LoadSalesperson()
        LoadSecurity()
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearVariables()
        CustomerFilter = ""
        PartFilter = ""
        DateFilter = ""
        ItemClassFilter = ""
        CustPOFilter = ""
        SPLFilter = ""
        SalespersonFilter = ""
        TextFilter = ""

        ProductTotal = 0
        COGS = 0
        ProfitMargin = 0
        TotalQuantity = 0
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        If rdoGroupByCustomer.Checked = True Then
            GlobalInvoiceSortField = "CUSTOMER"
        ElseIf rdoGroupByPart.Checked = True Then
            GlobalInvoiceSortField = "PARTNUMBER"
        Else
            GlobalInvoiceSortField = "SALESPERSON"
        End If

        Using NewPrintInvoiceLinesBySortFiltered As New PrintInvoiceLinesBySortFiltered
            Dim result = NewPrintInvoiceLinesBySortFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub dgvInvoiceLines_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceLines.CellDoubleClick
        Dim RowInvoiceNumber, RowShipmentNumber, RowSONumber As Integer
        Dim CustomerEmail, RowCustomer As String

        Dim RowIndex As Integer = Me.dgvInvoiceLines.CurrentCell.RowIndex

        RowInvoiceNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("InvoiceHeaderKeyColumn").Value
        RowShipmentNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowSONumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
        RowCustomer = Me.dgvInvoiceLines.Rows(RowIndex).Cells("CustomerIDColumn").Value

        Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
        CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
        CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerEmail = CStr(CustomerEmailCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerEmail = ""
        End Try
        con.Close()

        GlobalShipmentNumber = RowShipmentNumber
        GlobalDivisionCode = cboDivisionID.Text

        'Choose the Invoice Print Form by division
        If RowShipmentNumber = 0 Or RowSONumber = 0 Then
            GlobalInvoiceNumber = RowInvoiceNumber
            GlobalDivisionCode = cboDivisionID.Text
            'Get sring Customer/InvoiceNumber for emails
            EmailInvoiceCustomer = RowCustomer
            EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
            EmailCustomerEmailAddress = CustomerEmail

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
                Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                    Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                End Using
            Else
                Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                    Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                End Using
            End If
        Else
            GlobalInvoiceNumber = RowInvoiceNumber
            GlobalDivisionCode = cboDivisionID.Text
            'Get sring Customer/InvoiceNumber for emails
            EmailInvoiceCustomer = RowCustomer
            EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
            EmailCustomerEmailAddress = CustomerEmail

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
                Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                    Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                End Using
            Else
                Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                    Dim result = NewPrintInvoiceSingle.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalInvoiceNumber = 0
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        Me.Dispose()
        Me.Close()
    End Sub
End Class