Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.Net.Mail
Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ViewCustomerListing
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim HoldStatus, AccountingHold As String
    Dim PaymentFilter, DateFilter, BeginsFilter, TextFilter, CustomerFilter, ClassFilter, TerritoryFilter, CreditHoldFilter, AccountingFilter, StateFilter, STStateFilter, BTStateFilter, ZipFilter, AR30Filter, AR45Filter, AR60Filter, AR90Filter, AR90PlusFilter As String
    Dim TodaysDate As Date
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim StatementFileName As String = ""
    Dim DatagridToolTip As New ToolTip

    'Configure Data Connection and declare variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As New DataTable


    'Initial Events

    Private Sub CustomerListingDisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)

        TodaysDate = Today.ToShortDateString()

        If EmployeeCompanyCode = "ADM" Then
            cboState.Text = ""
            cboState.SelectedIndex = -1
        End If

        'Set security for auto-email
        If EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1001 Or EmployeeLoginName = "JBASSETTI" Then
            cmdAutoEmailStatements.Enabled = True
        Else
            cmdAutoEmailStatements.Enabled = False
        End If

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

    Public Sub LoadDatagridToolTip()

        'dgvCustomerList.CurrentCell.ToolTipText("TESTING 1 2 3")

        'DatagridToolTip.ToolTipIcon = ToolTipIcon.Info
        'DatagridToolTip.ToolTipTitle = "Customer Data"
        'DatagridToolTip.SetToolTip(dgvCustomerList, dgvCustomerList.CurrentCell.ToolTipText)
        'DatagridToolTip.IsBalloon = False
        'DatagridToolTip.UseAnimation = False
    End Sub

    'Load Datasets

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboCustomerClass.Text <> "" Then
            ClassFilter = " AND CustomerClass = '" + cboCustomerClass.Text + "'"
        Else
            ClassFilter = ""
        End If
        If cboSalesTerritory.Text <> "" Then
            TerritoryFilter = " AND SalesTerritory = '" + cboSalesTerritory.Text + "'"
        Else
            TerritoryFilter = ""
        End If
        If txtSearch.Text <> "" Then
            TextFilter = " AND (CustomerID LIKE '%" + txtSearch.Text + "%' OR CustomerName LIKE '%" + txtSearch.Text + "%')"
        Else
            TextFilter = ""
        End If
        If txtBegins.Text <> "" Then
            BeginsFilter = " AND (CustomerID LIKE '" + txtBegins.Text + "%' OR CustomerName LIKE '" + txtBegins.Text + "%')"
        Else
            BeginsFilter = ""
        End If
        If cboPaymentTerms.Text <> "" Then
            PaymentFilter = " AND PaymentTerms = '" + cboPaymentTerms.Text + "'"
        Else
            PaymentFilter = ""
        End If
        If cboState.Text <> "" Then
            If chkBTState.Checked = True And chkSTState.Checked <> True Then
                BTStateFilter = " AND (BillToState = '" + cboState.Text + "' OR ShipToState = '" + cboState.Text + "')"
                STStateFilter = ""
                StateFilter = ""
            ElseIf chkSTState.Checked = True And chkBTState.Checked = True Then
                BTStateFilter = ""
                STStateFilter = ""
                StateFilter = " AND BillToState = '" + cboState.Text + "'"
            ElseIf chkBTState.Checked <> True And chkSTState.Checked = True Then
                BTStateFilter = ""
                STStateFilter = " AND ShipToState = '" + cboState.Text + "'"
                StateFilter = ""
            Else
                BTStateFilter = ""
                STStateFilter = ""
                StateFilter = " AND (BillToState = '" + cboState.Text + "' OR ShipToState = '" + cboState.Text + "')"
            End If
        Else
            StateFilter = ""
            STStateFilter = ""
            BTStateFilter = ""
        End If
        If txtZipCode.Text <> "" Then
            ZipFilter = " AND BillToZip = '" + txtZipCode.Text + "'"
        Else
            ZipFilter = ""
        End If
        If chkAccountingHold.Checked = True Then
            AccountingFilter = " AND AccountingHold = 'YES'"
        Else
            AccountingFilter = ""
        End If
        If chkViewByHold.Checked = True Then
            CreditHoldFilter = " AND OnHoldStatus = 'YES'"
        Else
            CreditHoldFilter = ""
        End If
        If chkAR30.Checked = True Then
            AR30Filter = " AND AgingLessThan30 <> 0"
        Else
            AR30Filter = ""
        End If
        If chkAR45.Checked = True Then
            AR45Filter = " AND Aging31To45 <> 0"
        Else
            AR45Filter = ""
        End If
        If chkAR60.Checked = True Then
            AR60Filter = " AND Aging46To60 <> 0"
        Else
            AR60Filter = ""
        End If
        If chkAR90.Checked = True Then
            AR90Filter = " AND Aging61To90 <> 0"
        Else
            AR90Filter = ""
        End If
        If chkAR90Plus.Checked = True Then
            AR90PlusFilter = " AND AgingMoreThan90 <> 0"
        Else
            AR90PlusFilter = ""
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND CustomerDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM CustomerListWithAgingQuery WHERE DivisionID <> @DivisionID" + CustomerFilter + ClassFilter + TerritoryFilter + CreditHoldFilter + AccountingFilter + TextFilter + BeginsFilter + AR30Filter + AR45Filter + AR60Filter + AR90Filter + AR90PlusFilter + StateFilter + STStateFilter + BTStateFilter + ZipFilter + PaymentFilter + DateFilter + " ORDER BY DivisionID, CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Value
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "CustomerListWithAgingQuery")
            dgvCustomerList.DataSource = ds.Tables("CustomerListWithAgingQuery")
            con.Close()

            Me.dgvCustomerList.Columns("DivisionIDColumn").Visible = True
            Me.dgvCustomerList.Columns("CustomerNameColumn").Frozen = True
        Else
            cmd = New SqlCommand("SELECT * FROM CustomerListWithAgingQuery WHERE DivisionID = @DivisionID" + CustomerFilter + ClassFilter + TerritoryFilter + CreditHoldFilter + AccountingFilter + TextFilter + BeginsFilter + AR30Filter + AR45Filter + AR60Filter + AR90Filter + AR90PlusFilter + StateFilter + STStateFilter + BTStateFilter + ZipFilter + PaymentFilter + DateFilter + " ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Value
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "CustomerListWithAgingQuery")
            dgvCustomerList.DataSource = ds.Tables("CustomerListWithAgingQuery")
            con.Close()

            Me.dgvCustomerList.Columns("DivisionIDColumn").Visible = False
            Me.dgvCustomerList.Columns("CustomerNameColumn").Frozen = True
        End If

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            If Me.dgvCustomerList.RowCount > 0 Then
                Me.dgvCustomerList.Columns("OnHoldStatusColumn").ReadOnly = False
                Me.dgvCustomerList.Columns("SalesTaxRateColumn").ReadOnly = False
                Me.dgvCustomerList.Columns("SalesTaxRate2Column").ReadOnly = False
                Me.dgvCustomerList.Columns("SalesTaxRate3Column").ReadOnly = False
                Me.dgvCustomerList.Columns("SalesTaxStatusColumn").ReadOnly = False
            End If
        Else
            If Me.dgvCustomerList.RowCount > 0 Then
                Me.dgvCustomerList.Columns("OnHoldStatusColumn").Visible = True
                Me.dgvCustomerList.Columns("SalesTaxRateColumn").ReadOnly = True
                Me.dgvCustomerList.Columns("SalesTaxRate2Column").ReadOnly = True
                Me.dgvCustomerList.Columns("SalesTaxRate3Column").ReadOnly = True
                Me.dgvCustomerList.Columns("SalesTaxStatusColumn").ReadOnly = True
            End If
        End If
    End Sub

    Public Sub ShowTWECustomers()
        cmd = New SqlCommand("SELECT * FROM CustomerListWithAgingQuery WHERE DivisionID = @DivisionID ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CustomerListWithAgingQuery")
        dgvCustomerList.DataSource = ds.Tables("CustomerListWithAgingQuery")
        con.Close()

        Me.dgvCustomerList.Columns("DivisionIDColumn").Visible = True
        Me.dgvCustomerList.Columns("CustomerNameColumn").Frozen = True
    End Sub

    Public Sub ShowTWDCustomers()
        cmd = New SqlCommand("SELECT * FROM CustomerListWithAgingQuery WHERE DivisionID = @DivisionID ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CustomerListWithAgingQuery")
        dgvCustomerList.DataSource = ds.Tables("CustomerListWithAgingQuery")
        con.Close()

        Me.dgvCustomerList.Columns("DivisionIDColumn").Visible = True
        Me.dgvCustomerList.Columns("CustomerNameColumn").Frozen = True
    End Sub

    Public Sub LoadCustomerClass()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerClass FROM CustomerListWithAgingQuery WHERE DivisionID <> @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT DISTINCT CustomerClass FROM CustomerListWithAgingQuery WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerListWithAgingQuery")
        cboCustomerClass.DataSource = ds1.Tables("CustomerListWithAgingQuery")
        con.Close()
        cboCustomerClass.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesTerritory()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT SalesTerritory FROM CustomerListWithAgingQuery WHERE DivisionID <> @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT DISTINCT SalesTerritory FROM CustomerListWithAgingQuery WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerListWithAgingQuery")
        cboSalesTerritory.DataSource = ds2.Tables("CustomerListWithAgingQuery")
        con.Close()
        cboSalesTerritory.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomer()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerID FROM CustomerListWithAgingQuery WHERE DivisionID <> @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        Else
            cmd = New SqlCommand("SELECT CustomerID FROM CustomerListWithAgingQuery WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerListWithAgingQuery")
        cboCustomerID.DataSource = ds3.Tables("CustomerListWithAgingQuery")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerName FROM CustomerListWithAgingQuery WHERE DivisionID <> @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        Else
            cmd = New SqlCommand("SELECT CustomerName FROM CustomerListWithAgingQuery WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerListWithAgingQuery")
        cboCustomerName.DataSource = ds4.Tables("CustomerListWithAgingQuery")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    'Load data

    Public Sub LoadCustomerIDByName()
        If cboDivisionID.Text = "ADM" Then
            Dim CustomerID1 As String = ""

            Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID <> @DivisionID"
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
        Else
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
        End If
    End Sub

    Public Sub LoadCustomerNameByID()
        If cboDivisionID.Text = "ADM" Then
            Dim CustomerName1 As String = ""

            Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID <> @DivisionID"
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
        Else
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
        End If
    End Sub

    'Error log, clear, validation

    Public Sub ClearData()
        cboCustomerClass.Text = ""
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboSalesTerritory.Text = ""
        cboState.Text = ""
        cboPaymentTerms.Text = ""

        cboCustomerClass.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboSalesTerritory.SelectedIndex = -1
        cboState.SelectedIndex = -1
        cboPaymentTerms.SelectedIndex = -1

        txtZipCode.Clear()
        txtSearch.Clear()
        txtBegins.Clear()

        chkAccountingHold.Checked = False
        chkAR30.Checked = False
        chkAR45.Checked = False
        chkAR60.Checked = False
        chkAR90.Checked = False
        chkAR90Plus.Checked = False
        chkBTState.Checked = False
        chkSTState.Checked = False
        chkViewByHold.Checked = False
        chkDateRange.Checked = False

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        HoldStatus = ""
        AccountingHold = ""
        CustomerFilter = ""
        ClassFilter = ""
        TerritoryFilter = ""
        CreditHoldFilter = ""
        AccountingFilter = ""
        TextFilter = ""
        BeginsFilter = ""
        StateFilter = ""
        STStateFilter = ""
        BTStateFilter = ""
        ZipFilter = ""
        AR30Filter = ""
        AR45Filter = ""
        AR60Filter = ""
        AR90Filter = ""
        AR90PlusFilter = ""
        PaymentFilter = ""
    End Sub

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length > 400 Then
            ErrorComment = ErrorComment.Substring(0, 400)
        End If

        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvCustomerList.DataSource = Nothing
    End Sub

    'Command Buttons

    Private Sub cmdPrintCustomerStatement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintCustomerStatement.Click
        If Me.dgvCustomerList.RowCount <> 0 Then
            Dim RowCustomer, RowEmailAddress As String
            Dim RowDivision As String = ""
            Dim RowIndex As Integer = Me.dgvCustomerList.CurrentCell.RowIndex

            RowCustomer = Me.dgvCustomerList.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowEmailAddress = Me.dgvCustomerList.Rows(RowIndex).Cells("APEmailAddressColumn").Value
            RowDivision = Me.dgvCustomerList.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalCustomerID = RowCustomer
            GlobalDivisionCode = RowDivision
            EmailInvoiceCustomer = RowCustomer
            EmailCustomerEmailAddress = RowEmailAddress

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
                Using NewPrintARCustomerStatementSingleRemote As New PrintARCustomerStatementSingleRemote
                    Dim Result = NewPrintARCustomerStatementSingleRemote.ShowDialog()
                End Using
            Else
                Using NewPrintARCustomerStatementSingle As New PrintARCustomerStatementSingle
                    Dim Result = NewPrintARCustomerStatementSingle.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintCustomerListFiltered As New PrintCustomerListFiltered
            Dim Result = NewPrintCustomerListFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdOpenCustomerForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenCustomerForm.Click
        If Me.dgvCustomerList.RowCount <> 0 Then
            Dim RowCustomer As String
            Dim RowIndex As Integer = Me.dgvCustomerList.CurrentCell.RowIndex

            RowCustomer = Me.dgvCustomerList.Rows(RowIndex).Cells("CustomerIDColumn").Value

            GlobalCustomerID = RowCustomer
            GlobalDivisionCode = cboDivisionID.Text

            Dim NewCustomerData As New CustomerData
            NewCustomerData.Show()
        Else
            Dim NewCustomerData As New CustomerData
            NewCustomerData.Show()
        End If
    End Sub

    Private Sub cmdPrintPhoneList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPhoneList.Click
        GlobalCustomerInactivityReport = "NO"

        GDS = ds

        Using NewPrintCustomerListFiltered As New PrintCustomerListFiltered
            Dim result = NewPrintCustomerListFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrintAddresses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintAddresses.Click
        GDS = ds
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintCustomerAddressBook As New PrintCustomerAddressBook
            Dim result = NewPrintCustomerAddressBook.ShowDialog()
        End Using
    End Sub

    Private Sub cmdARReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdARReport.Click
        GDS = ds

        Using NewPrintCustomerARReport As New PrintCustomerARReport
            Dim result = NewPrintCustomerARReport.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()

        GDS = New DataSet
        ds = New DataSet

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdAutoEmailStatements_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoEmailStatements.Click
        Dim RowCustomerID, RowStatementEmail, RowDivisionID As String

        'Filter List to those customers who have a statement email address
        cmd = New SqlCommand("SELECT * FROM CustomerListWithAgingQuery WHERE DivisionID = @DivisionID AND StatementEmail <> '' AND PaymentTerms <> 'CREDIT CARD' ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CustomerListWithAgingQuery")
        dgvCustomerList.DataSource = ds.Tables("CustomerListWithAgingQuery")
        con.Close()

        Me.dgvCustomerList.Columns("DivisionIDColumn").Visible = False
        Me.dgvCustomerList.Columns("CustomerNameColumn").Frozen = True

        Dim button As DialogResult = MessageBox.Show("Do you wish to auto-email statements to customers?", "AUTO-EMAIL STATEMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Proceed
            If Me.dgvCustomerList.RowCount > 0 Then
                'Run this in a For/Each Loop
                For Each LineRow As DataGridViewRow In dgvCustomerList.Rows
                    'Get Customer ID, Division, and Customer Statement email
                    Try
                        RowCustomerID = LineRow.Cells("CustomerIDColumn").Value
                    Catch ex As System.Exception
                        RowCustomerID = ""
                    End Try
                    Try
                        RowStatementEmail = LineRow.Cells("StatementEmailColumn").Value
                    Catch ex As System.Exception
                        RowStatementEmail = ""
                    End Try
                    Try
                        RowDivisionID = LineRow.Cells("DivisionIDColumn").Value
                    Catch ex As System.Exception
                        RowDivisionID = ""
                    End Try

                    RowStatementEmail = RowStatementEmail.Replace(vbCr, " ")
                    RowStatementEmail = RowStatementEmail.Replace(vbCrLf, " ")
                    RowStatementEmail = RowStatementEmail.Replace(vbLf, " ")
                    RowStatementEmail = RowStatementEmail.Replace(vbCr, " ")
                    RowStatementEmail = RowStatementEmail.Replace(vbCrLf, " ")
                    RowStatementEmail = RowStatementEmail.Replace(vbLf, " ")


                    'Check for Outstanding Balance
                    Dim CheckOutstandingBalance As Double = 0

                    Dim CheckOutstandingBalanceStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceStatus = 'OPEN'"
                    Dim CheckOutstandingBalanceCommand As New SqlCommand(CheckOutstandingBalanceStatement, con)
                    CheckOutstandingBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    CheckOutstandingBalanceCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckOutstandingBalance = CDbl(CheckOutstandingBalanceCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckOutstandingBalance = 0
                    End Try
                    con.Close()

                    If CheckOutstandingBalance <= 0 Then
                        'Skip
                    Else
                        'Create File Name and set path
                        StatementFileName = RowDivisionID + RowCustomerID + ".pdf"

                        'Create pdf of statement
                        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID

                        cmd1 = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
                        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                        cmd1.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID

                        cmd2 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
                        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                        cmd2.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID

                        cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                        cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = RowDivisionID

                        cmd4 = New SqlCommand("SELECT * FROM ARAgingQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
                        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                        cmd4.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID

                        cmd5 = New SqlCommand("SELECT * FROM CustomerContacts WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
                        cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                        cmd5.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID

                        If con.State = ConnectionState.Closed Then con.Open()
                        ds = New DataSet()

                        myAdapter.SelectCommand = cmd
                        myAdapter.Fill(ds, "InvoiceHeaderTable")

                        myAdapter1.SelectCommand = cmd1
                        myAdapter1.Fill(ds, "ARAgingCategory")

                        myAdapter2.SelectCommand = cmd2
                        myAdapter2.Fill(ds, "CustomerList")

                        myAdapter3.SelectCommand = cmd3
                        myAdapter3.Fill(ds, "DivisionTable")

                        myAdapter4.SelectCommand = cmd4
                        myAdapter4.Fill(ds, "ARAgingQuery")

                        myAdapter5.SelectCommand = cmd5
                        myAdapter5.Fill(ds, "CustomerContacts")

                        'Sets up viewer to display data from the loaded dataset
                        MyReport = CRXCustStatement1
                        MyReport.SetDataSource(ds)
                        'CRStatementViewer.ReportSource = MyReport
                        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldCustomerStatements\" & StatementFileName)
                        con.Close()

                        'Attach and send email
                        '***********************************************************************************************
                        'Check if file exists
                        If File.Exists("\\TFP-FS\TransferData\TruweldCustomerStatements\" + StatementFileName) Then
                            '***********************************************************************************************
                            Try
                                'Set up email to be sent
                                Dim MyMailMessage As New MailMessage()
                                MyMailMessage.From = New MailAddress("customerstatements@tfpcorp.com")

                                'Add array of email addresses if necessay
                                'Parse email field to determine how many addresses 
                                If RowStatementEmail.Contains(";") Then
                                    Dim EmailArray As Array
                                    Dim ArrayCount As Integer = 0
                                    Dim CurrentEmail As String = ""

                                    EmailArray = Split(RowStatementEmail, ";")
                                    ArrayCount = UBound(EmailArray) + 1
                                    Dim Counter As Integer = 1

                                    For i As Integer = 0 To UBound(EmailArray)
                                        CurrentEmail = EmailArray(ArrayCount - Counter)
                                        MyMailMessage.To.Add(CurrentEmail)
                                        Counter = Counter + 1
                                    Next
                                Else
                                    MyMailMessage.To.Add(RowStatementEmail)
                                End If

                                MyMailMessage.Attachments.Add(New Attachment("\\TFP-FS\TransferData\TruweldCustomerStatements\" + StatementFileName))
                                MyMailMessage.Subject = "Customer Statement / TFP Corporation - " + cboDivisionID.Text + " Division"
                                MyMailMessage.ReplyTo = New MailAddress("ar@tfpcorp.com")
                                MyMailMessage.Body = "This Customer Statement was auto-generated from our system. If you have any questions, comments, or concerns email us at ar@tfpcorp.com or call 1-800-321-5588. Thank you for your business."
                                Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                                SMPT.Port = 587
                                'SMPT.Timeout = 1500
                                SMPT.EnableSsl = False
                                SMPT.Credentials = New System.Net.NetworkCredential("customerstatements@tfpcorp.com", "1422325bogie")
                                SMPT.Send(MyMailMessage)

                                'Create customer note
                                Dim LastNoteNumber, NextNoteNumber As Integer

                                'Get Next Note Number
                                Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                                Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
                                MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID
                                MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID

                                If con.State = ConnectionState.Closed Then con.Open()
                                Dim reader As SqlDataReader = MaximumNoteCommand.ExecuteReader()
                                If reader.HasRows Then
                                    reader.Read()
                                    If IsDBNull(reader.Item("MAXNoteID")) Then
                                        LastNoteNumber = 0
                                    Else
                                        LastNoteNumber = reader.Item("MAXNoteID")
                                    End If
                                Else
                                    LastNoteNumber = 0
                                End If
                                reader.Close()
                                con.Close()

                                NextNoteNumber = LastNoteNumber + 1

                                Dim MessageBodyText As String = ""

                                MessageBodyText = EmployeeLoginName + " emailed a Customer Statement to " + RowCustomerID

                                'Write Data to Customer Note Table
                                cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

                                With cmd.Parameters
                                    .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                                    .Add("@NoteDate", SqlDbType.VarChar).Value = Today()
                                    .Add("@NoteSubject", SqlDbType.VarChar).Value = "Auto-Email Customer Statements"
                                    .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
                                    .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                Dim CheckEx As String
                                CheckEx = ex.ToString()
                                If CheckEx.Length() > 400 Then
                                    CheckEx = ""
                                Else
                                    CheckEx = ex.ToString()
                                End If

                                'Log error on update failure
                                ErrorDate = Today()
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Auto-email Statements --- Failure"
                                ErrorReferenceNumber = "Statement failed " + RowDivisionID + RowCustomerID
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        Else
                            MsgBox("File does not exist.", MsgBoxStyle.OkOnly)
                        End If

                        'Clear Variables
                        RowCustomerID = ""
                        RowDivisionID = ""
                        RowStatementEmail = ""
                        StatementFileName = ""
                    End If
                Next

                MsgBox("All statements sent.", MsgBoxStyle.OkOnly)
            Else
                MsgBox("There are no customers set up to auto-email.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        ElseIf button = DialogResult.No Then
            ClearData()
            ClearVariables()
            ClearDataInDatagrid()
            Exit Sub
        End If
    End Sub

    Private Sub cmdPrintAddShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintAddShipTo.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintShippingAddresses As New PrintShippingAddresses
            Dim Result = NewPrintShippingAddresses.ShowDialog()
        End Using
    End Sub

    Private Sub cmdAddCustomerToDivision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddCustomerToDivision.Click
        Dim AccountingHold, OnHoldStatus, PaymentTerms, ShipEmail, SalesTaxID, SalesTaxStatus, ConfirmationEmail, StatementEmail, CertEmail, PackingListEmail, SalesContactEmail, CustomerClass, BillingType, InvoiceEmail, InvoiceCertEmail, CustomerID, CustomerName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry, Comments, PreferredShipper, SalesTerritory, ShippingDetails, APPhoneNumber, APFAXNumber, APEmailAddress, APContactName As String
        Dim CountDivision, CountCustomerID, CountCustomerName As Integer
        Dim TaxRate1, TaxRate2, TaxRate3 As Double


        If txtNewDivision.Text = cboDivisionID.Text Then
            MsgBox("You must select a different division than the one you are in.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '************************************************************************************
        'Verify Division
        Dim CountDivisionStatement As String = "SELECT COUNT(DivisionKey) FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim CountDivisionCommand As New SqlCommand(CountDivisionStatement, con)
        CountDivisionCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = txtNewDivision.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountDivision = CInt(CountDivisionCommand.ExecuteScalar)
        Catch ex As Exception
            CountDivision = 0
        End Try
        con.Close()

        If CountDivision = 0 Then
            MsgBox("You must select a valid division.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************
        If Me.dgvCustomerList.RowCount = 0 Then
            MsgBox("You must select a line in the datagrid.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************
        Dim RowIndex As Integer = Me.dgvCustomerList.CurrentCell.RowIndex

        Try
            CustomerID = Me.dgvCustomerList.Rows(RowIndex).Cells("CustomerIDColumn").Value
        Catch ex As Exception
            CustomerID = ""
        End Try
        Try
            CustomerName = Me.dgvCustomerList.Rows(RowIndex).Cells("CustomerNameColumn").Value
        Catch ex As Exception
            CustomerName = ""
        End Try
        '*************************************************************************************
        'Verify if Customer ID or Customer Name already exists
        Dim CountCustomerIDStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
        Dim CountCustomerIDCommand As New SqlCommand(CountCustomerIDStatement, con)
        CountCustomerIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtNewDivision.Text
        CountCustomerIDCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID

        Dim CountCustomerNameStatement As String = "SELECT COUNT(CustomerName) FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerName = @CustomerName"
        Dim CountCustomerNameCommand As New SqlCommand(CountCustomerNameStatement, con)
        CountCustomerNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtNewDivision.Text
        CountCustomerNameCommand.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = CustomerName

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountCustomerID = CInt(CountCustomerIDCommand.ExecuteScalar)
        Catch ex As Exception
            CountCustomerID = 0
        End Try
        Try
            CountCustomerName = CInt(CountCustomerNameCommand.ExecuteScalar)
        Catch ex As Exception
            CountCustomerName = 0
        End Try
        con.Close()

        If CountCustomerName + CountCustomerID <> 0 Then
            MsgBox("Customer ID or Customer Name already exists in this division.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************
        'Get row data from datagrid
        Try
            ShipToAddress1 = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToAddress1Column").Value
        Catch ex As Exception
            ShipToAddress1 = ""
        End Try
        Try
            ShipToAddress2 = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToAddress2Column").Value
        Catch ex As Exception
            ShipToAddress2 = ""
        End Try
        Try
            ShipToCity = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToCityColumn").Value
        Catch ex As Exception
            ShipToCity = ""
        End Try
        Try
            ShipToState = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToStateColumn").Value
        Catch ex As Exception
            ShipToState = ""
        End Try
        Try
            ShipToZip = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToZipColumn").Value
        Catch ex As Exception
            ShipToZip = ""
        End Try
        Try
            ShipToCountry = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToCountryColumn").Value
        Catch ex As Exception
            ShipToCountry = ""
        End Try
        Try
            ShipEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipEmailColumn").Value
        Catch ex As Exception
            ShipEmail = ""
        End Try
        Try
            BillToAddress1 = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToAddress1Column").Value
        Catch ex As Exception
            BillToAddress1 = ""
        End Try
        Try
            BillToAddress2 = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToAddress2Column").Value
        Catch ex As Exception
            BillToAddress2 = ""
        End Try
        Try
            BillToCity = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToCityColumn").Value
        Catch ex As Exception
            BillToCity = ""
        End Try
        Try
            BillToState = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToStateColumn").Value
        Catch ex As Exception
            BillToState = ""
        End Try
        Try
            BillToZip = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToZipColumn").Value
        Catch ex As Exception
            BillToZip = ""
        End Try
        Try
            BillToCountry = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToCountryColumn").Value
        Catch ex As Exception
            BillToCountry = ""
        End Try
        Try
            Comments = Me.dgvCustomerList.Rows(RowIndex).Cells("CommentsColumn").Value
        Catch ex As Exception
            Comments = ""
        End Try
        Try
            PaymentTerms = Me.dgvCustomerList.Rows(RowIndex).Cells("PaymentTermsColumn").Value
        Catch ex As Exception
            PaymentTerms = "N30"
        End Try
        Try
            OnHoldStatus = Me.dgvCustomerList.Rows(RowIndex).Cells("OnHoldStatusColumn").Value
        Catch ex As Exception
            OnHoldStatus = ""
        End Try
        Try
            AccountingHold = Me.dgvCustomerList.Rows(RowIndex).Cells("AccountingHoldColumn").Value
        Catch ex As Exception
            AccountingHold = ""
        End Try
        Try
            TaxRate1 = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTaxRateColumn").Value
        Catch ex As Exception
            TaxRate1 = 0
        End Try
        Try
            TaxRate2 = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTaxRate2Column").Value
        Catch ex As Exception
            TaxRate2 = 0
        End Try
        Try
            TaxRate3 = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTaxRate3Column").Value
        Catch ex As Exception
            TaxRate3 = 0
        End Try
        Try
            SalesTaxID = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTaxIDColumn").Value
        Catch ex As Exception
            SalesTaxID = ""
        End Try
        Try
            SalesTaxStatus = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTaxStatusColumn").Value
        Catch ex As Exception
            SalesTaxStatus = "TAXABLE"
        End Try
        Try
            PreferredShipper = Me.dgvCustomerList.Rows(RowIndex).Cells("PreferredShipperColumn").Value
        Catch ex As Exception
            PreferredShipper = ""
        End Try
        Try
            CustomerClass = Me.dgvCustomerList.Rows(RowIndex).Cells("CustomerClassColumn").Value
        Catch ex As Exception
            CustomerClass = ""
        End Try
        Try
            SalesTerritory = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTerritoryColumn").Value
        Catch ex As Exception
            SalesTerritory = ""
        End Try
        Try
            ShippingDetails = Me.dgvCustomerList.Rows(RowIndex).Cells("ShippingDetailsColumn").Value
        Catch ex As Exception
            ShippingDetails = ""
        End Try
        Try
            APPhoneNumber = Me.dgvCustomerList.Rows(RowIndex).Cells("APPhoneNumberColumn").Value
        Catch ex As Exception
            APPhoneNumber = ""
        End Try
        Try
            APFAXNumber = Me.dgvCustomerList.Rows(RowIndex).Cells("APFAXNumberColumn").Value
        Catch ex As Exception
            APFAXNumber = ""
        End Try
        Try
            APEmailAddress = Me.dgvCustomerList.Rows(RowIndex).Cells("APEmailAddressColumn").Value
        Catch ex As Exception
            APEmailAddress = ""
        End Try
        Try
            InvoiceEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("InvoiceEmailColumn").Value
        Catch ex As Exception
            InvoiceEmail = ""
        End Try
        Try
            ConfirmationEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("ConfirmationEmailolumn").Value
        Catch ex As Exception
            ConfirmationEmail = ""
        End Try
        Try
            StatementEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("StatementEmailColumn").Value
        Catch ex As Exception
            StatementEmail = ""
        End Try
        Try
            CertEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("CertEmailColumn").Value
        Catch ex As Exception
            CertEmail = ""
        End Try
        Try
            PackingListEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("PackingListEmailColumn").Value
        Catch ex As Exception
            PackingListEmail = ""
        End Try
        Try
            SalesContactEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesContactEmailColumn").Value
        Catch ex As Exception
            SalesContactEmail = ""
        End Try
        Try
            APContactName = Me.dgvCustomerList.Rows(RowIndex).Cells("APContactNameColumn").Value
        Catch ex As Exception
            APContactName = ""
        End Try
        Try
            SalesTaxID = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTaxIDColumn").Value
        Catch ex As Exception
            SalesTaxID = ""
        End Try
        Try
            SalesTaxStatus = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTaxStatusColumn").Value
        Catch ex As Exception
            SalesTaxStatus = "TAXABLE"
        End Try
        Try
            CustomerClass = Me.dgvCustomerList.Rows(RowIndex).Cells("CustomerClasslColumn").Value
        Catch ex As Exception
            CustomerClass = "STANDARD"
        End Try
        Try
            BillingType = Me.dgvCustomerList.Rows(RowIndex).Cells("BillingTypeColumn").Value
        Catch ex As Exception
            BillingType = "STANDARD"
        End Try
        Try
            InvoiceCertEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("InvoiceCertEmailColumn").Value
        Catch ex As Exception
            InvoiceCertEmail = ""
        End Try
        '**********************************************************************************************
        If txtNewDivision.Text = "ALB" Or txtNewDivision.Text = "TFF" Or txtNewDivision.Text = "TOR" Then
            CustomerClass = "CANADIAN"
        Else
            'Do nothing - take customer class from other division
        End If
        '***********************************************************************************************
        'Add to Customer List
        Try
            'Create command to update database and fill with text box enties
            cmd = New SqlCommand("INSERT INTO CustomerList (CustomerID, DivisionID, CustomerName, CustomerDate, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ShipEmail, BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry, Comments, PaymentTerms, CreditLimit, SalesTaxRate, SalesTaxRate2, SalesTaxRate3, SalesTaxID, SalesTaxStatus, PreferredShipper, OldCustomerNumber, CustomerClass, SalesTerritory, ShippingDetails, OnHoldStatus, APPhoneNumber, APFAXNumber, APEmailAddress, InvoiceEmail, InvoiceCertEmail, ConfirmationEmail, StatementEmail, CertEmail, PackingListEmail, SalesContactEmail, APContactName, AccountingHold, PricingLevel, BillingType,  ShippingAccount, BankAccount) values (@CustomerID, @DivisionID, @CustomerName, @CustomerDate, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @ShipEmail, @BillToAddress1, @BillToAddress2, @BillToCity, @BillToState, @BillToZip, @BillToCountry, @Comments, @PaymentTerms, @CreditLimit, @SalesTaxRate, @SalesTaxRate2, @SalesTaxRate3, @SalesTaxID, @SalesTaxStatus, @PreferredShipper, @OldCustomerNumber, @CustomerClass, @SalesTerritory, @ShippingDetails, @OnHoldStatus, @APPhoneNumber, @APFAXNumber, @APEmailAddress, @InvoiceEmail, @InvoiceCertEmail, @ConfirmationEmail, @StatementEmail, @CertEmail, @PackingListEmail, @SalesContactEmail, @APContactName, @AccountingHold, @PricingLevel, @BillingType, @ShippingAccount, @BankAccount)", con)

            With cmd.Parameters
                .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID.ToUpper
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtNewDivision.Text
                .Add("@CustomerName", SqlDbType.VarChar).Value = CustomerName.ToUpper
                .Add("@CustomerDate", SqlDbType.VarChar).Value = TodaysDate
                .Add("@ShipToAddress1", SqlDbType.VarChar).Value = ShipToAddress1.ToUpper
                .Add("@ShipToAddress2", SqlDbType.VarChar).Value = ShipToAddress2.ToUpper
                .Add("@ShipToCity", SqlDbType.VarChar).Value = ShipToCity.ToUpper
                .Add("@ShipToState", SqlDbType.VarChar).Value = ShipToState.ToUpper
                .Add("@ShipToZip", SqlDbType.VarChar).Value = ShipToZip
                .Add("@ShipToCountry", SqlDbType.VarChar).Value = ShipToCountry.ToUpper
                .Add("@ShipEmail", SqlDbType.VarChar).Value = ShipEmail
                .Add("@BillToAddress1", SqlDbType.VarChar).Value = BillToAddress1.ToUpper
                .Add("@BillToAddress2", SqlDbType.VarChar).Value = BillToAddress2.ToUpper
                .Add("@BillToCity", SqlDbType.VarChar).Value = BillToCity.ToUpper
                .Add("@BillToState", SqlDbType.VarChar).Value = BillToState.ToUpper
                .Add("@BillToZip", SqlDbType.VarChar).Value = BillToZip
                .Add("@BillToCountry", SqlDbType.VarChar).Value = BillToCountry.ToUpper
                .Add("@Comments", SqlDbType.VarChar).Value = Comments
                .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
                .Add("@CreditLimit", SqlDbType.VarChar).Value = 0
                .Add("@SalesTaxRate", SqlDbType.VarChar).Value = TaxRate1
                .Add("@SalesTaxRate2", SqlDbType.VarChar).Value = TaxRate2
                .Add("@SalesTaxRate3", SqlDbType.VarChar).Value = TaxRate3
                .Add("@SalesTaxID", SqlDbType.VarChar).Value = SalesTaxID
                .Add("@SalesTaxStatus", SqlDbType.VarChar).Value = SalesTaxStatus
                .Add("@PreferredShipper", SqlDbType.VarChar).Value = PreferredShipper
                .Add("@OldCustomerNumber", SqlDbType.VarChar).Value = ""
                .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                .Add("@SalesTerritory", SqlDbType.VarChar).Value = SalesTerritory
                .Add("@ShippingDetails", SqlDbType.VarChar).Value = ShippingDetails
                .Add("@OnHoldStatus", SqlDbType.VarChar).Value = OnHoldStatus
                .Add("@APPhoneNumber", SqlDbType.VarChar).Value = APPhoneNumber
                .Add("@APFAXNumber", SqlDbType.VarChar).Value = APFAXNumber
                .Add("@APEmailAddress", SqlDbType.VarChar).Value = APEmailAddress
                .Add("@InvoiceEmail", SqlDbType.VarChar).Value = InvoiceEmail
                .Add("@InvoiceCertEmail", SqlDbType.VarChar).Value = InvoiceCertEmail
                .Add("@ConfirmationEmail", SqlDbType.VarChar).Value = ConfirmationEmail
                .Add("@StatementEmail", SqlDbType.VarChar).Value = StatementEmail
                .Add("@CertEmail", SqlDbType.VarChar).Value = CertEmail
                .Add("@PackingListEmail", SqlDbType.VarChar).Value = PackingListEmail
                .Add("@SalesContactEmail", SqlDbType.VarChar).Value = SalesContactEmail
                .Add("@APContactName", SqlDbType.VarChar).Value = APContactName
                .Add("@AccountingHold", SqlDbType.VarChar).Value = AccountingHold
                .Add("@PricingLevel", SqlDbType.VarChar).Value = "STANDARD"
                .Add("@BillingType", SqlDbType.VarChar).Value = "STANDARD"
                .Add("@ShippingAccount", SqlDbType.VarChar).Value = ""
                .Add("@BankAccount", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '****************************************************************************************
            'Write to Audit Trail Table
            Dim AuditComment As String = ""
            Dim AuditCustomer As String = ""

            AuditCustomer = CustomerID
            AuditComment = "A new customer was created in " + txtNewDivision.Text + " by " + EmployeeLoginName

            Try
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = TodaysDate
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "Customer Listing - Create Customer in another division"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = AuditCustomer
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
            '******************************************************************************************

            MsgBox("Customer has been created.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("There was an error creating this customer.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    'Menu strip items

    Private Sub PrintCustomersAddressesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCustomersAddressesToolStripMenuItem.Click
        GDS = ds

        Using NewPrintCustomerAddressBook As New PrintCustomerAddressBook
            Dim result = NewPrintCustomerAddressBook.ShowDialog()
        End Using
    End Sub

    Private Sub PrintCustomerPhoneListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCustomerPhoneListToolStripMenuItem.Click
        GDS = ds

        Using NewPrintCustomerListFiltered As New PrintCustomerListFiltered
            Dim result = NewPrintCustomerListFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CustomerInactivityReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerInactivityReportToolStripMenuItem.Click
        If Me.dgvCustomerList.RowCount = 0 Then
            MsgBox("Filter dataset before running report.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Determine cutoff date
            TodaysDate = Today()
            Dim CutoffDate As String
            Dim InactivityCustomerID, InactivityDivision, InactivityCustomerName As String
            Dim CountCustomerSales As Integer = 0
            Dim LastActivityDate As Date

            'Delete temp table
            If cboDivisionID.Text = "ADM" Then
                cmd = New SqlCommand("DELETE FROM TempCustomerInactivityTable", con)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                cmd = New SqlCommand("DELETE FROM TempCustomerInactivityTable WHERE DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            Dim DayOfMonth, MonthOfYear, YearOfYear, NewYearOfYear As Integer
            Dim strDayOfMonth, strMonthOfYear, strYearOfYear, strCutoffDate As String

            DayOfMonth = TodaysDate.Day
            MonthOfYear = TodaysDate.Month
            YearOfYear = TodaysDate.Year

            NewYearOfYear = YearOfYear - 1

            strDayOfMonth = CStr(DayOfMonth)
            strMonthOfYear = CStr(MonthOfYear)
            strYearOfYear = CStr(NewYearOfYear)

            strCutoffDate = strMonthOfYear + "/" + strDayOfMonth + "/" + strYearOfYear
            CutoffDate = CDate(strCutoffDate)

            'Get Customer ID
            For Each row As DataGridViewRow In dgvCustomerList.Rows
                Try
                    InactivityCustomerID = row.Cells("CustomerIDColumn").Value
                Catch ex As System.Exception
                    InactivityCustomerID = ""
                End Try
                Try
                    InactivityCustomerName = row.Cells("CustomerNameColumn").Value
                Catch ex As System.Exception
                    InactivityCustomerName = ""
                End Try
                Try
                    InactivityDivision = row.Cells("DivisionIDColumn").Value
                Catch ex As System.Exception
                    InactivityDivision = ""
                End Try

                Dim CountCustomerSalesStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate > @InvoiceDate"
                Dim CountCustomerSalesCommand As New SqlCommand(CountCustomerSalesStatement, con)
                CountCustomerSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = InactivityDivision
                CountCustomerSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = InactivityCustomerID
                CountCustomerSalesCommand.Parameters.Add("@InvoiceDate", SqlDbType.VarChar).Value = CutoffDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountCustomerSales = CInt(CountCustomerSalesCommand.ExecuteScalar)
                Catch ex As Exception
                    CountCustomerSales = 0
                End Try
                con.Close()

                If CountCustomerSales = 0 Then
                    'Get Last Activity Date
                    Dim LastActivityDateStatement As String = "SELECT MAX(InvoiceDate) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
                    Dim LastActivityDateCommand As New SqlCommand(LastActivityDateStatement, con)
                    LastActivityDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = InactivityDivision
                    LastActivityDateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = InactivityCustomerID

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastActivityDate = CDate(LastActivityDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastActivityDate = "1/1/1900"
                    End Try
                    con.Close()

                    'Insert Customer into temp table
                    cmd = New SqlCommand("INSERT INTO TempCustomerInactivityTable (CustomerID, CustomerName, DivisionID, LastActivityDate) values (@CustomerID, @CustomerName, @DivisionID, @LastActivityDate)", con)

                    With cmd.Parameters
                        .Add("@CustomerID", SqlDbType.VarChar).Value = InactivityCustomerID
                        .Add("@CustomerName", SqlDbType.VarChar).Value = InactivityCustomerName
                        .Add("@DivisionID", SqlDbType.VarChar).Value = InactivityDivision
                        .Add("@LastActivityDate", SqlDbType.VarChar).Value = LastActivityDate
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'clear variables
                    InactivityCustomerID = ""
                    InactivityCustomerName = ""
                    InactivityDivision = ""
                    LastActivityDate = "1/1/1900"
                Else
                    'Skip Customer
                End If
            Next

            'Open Crystal Report Print Form
            GlobalDivisionCode = cboDivisionID.Text
            GlobalCustomerInactivityReport = "YES"

            Using NewPrintCustomerListing As New PrintCustomerListFiltered
                Dim Result = NewPrintCustomerListing.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ViewTWDCLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewTWDCLToolStripMenuItem.Click
        ShowTWDCustomers()
    End Sub

    Private Sub ViewTWECLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewTWECLToolStripMenuItem.Click
        ShowTWECustomers()
    End Sub

    Private Sub PrintCustomerListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCustomerListToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintCustomerListFiltered As New PrintCustomerListFiltered
            Dim Result = NewPrintCustomerListFiltered.ShowDialog()
        End Using
    End Sub

    'Datagrid events

    Private Sub dgvCustomerList_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomerList.CellDoubleClick
        Dim RowDivision, RowCustomer, RowEmailAddress As String

        Dim RowIndex As Integer = Me.dgvCustomerList.CurrentCell.RowIndex

        RowCustomer = Me.dgvCustomerList.Rows(RowIndex).Cells("CustomerIDColumn").Value
        RowEmailAddress = Me.dgvCustomerList.Rows(RowIndex).Cells("APEmailAddressColumn").Value
        RowDivision = Me.dgvCustomerList.Rows(RowIndex).Cells("DivisionIDColumn").Value

        GlobalCustomerID = RowCustomer
        GlobalDivisionCode = RowDivision
        EmailInvoiceCustomer = RowCustomer
        EmailCustomerEmailAddress = RowEmailAddress

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
            Using NewPrintARCustomerStatementSingleRemote As New PrintARCustomerStatementSingleRemote
                Dim Result = NewPrintARCustomerStatementSingleRemote.ShowDialog()
            End Using
        Else
            Using NewPrintARCustomerStatementSingle As New PrintARCustomerStatementSingle
                Dim Result = NewPrintARCustomerStatementSingle.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvCustomerList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomerList.CellValueChanged
        Dim RowSalesTaxStatus, RowOnHoldStatus, RowDivision, CustomerID, CustomerName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry, Comments, PreferredShipper, SalesTerritory, ShippingDetails, APPhoneNumber, APFAXNumber, APEmailAddress, APContactName As String
        Dim CreditLimit, SalesTaxRate1, SalesTaxRate2, SalesTaxRate3 As Double
        Dim RowInvoiceEmail, RowInvoiceCertEmail, RowSalesContactEmail, RowShippingAccount, RowConfirmationEmail, RowStatementEmail, RowCertEmail, RowPackingListEmail As String

        If Me.dgvCustomerList.RowCount = 0 Then
            'Skip if datagrid is blank
        Else
            Dim RowIndex As Integer = Me.dgvCustomerList.CurrentCell.RowIndex
            Try
                CustomerID = Me.dgvCustomerList.Rows(RowIndex).Cells("CustomerIDColumn").Value
            Catch ex As Exception
                CustomerID = ""
            End Try
            Try
                CustomerName = Me.dgvCustomerList.Rows(RowIndex).Cells("CustomerNameColumn").Value
            Catch ex As Exception
                CustomerName = ""
            End Try
            Try
                ShipToAddress1 = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToAddress1Column").Value
            Catch ex As Exception
                ShipToAddress1 = ""
            End Try
            Try
                ShipToAddress2 = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToAddress2Column").Value
            Catch ex As Exception
                ShipToAddress2 = ""
            End Try
            Try
                ShipToCity = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToCityColumn").Value
            Catch ex As Exception
                ShipToCity = ""
            End Try
            Try
                ShipToState = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToStateColumn").Value
            Catch ex As Exception
                ShipToState = ""
            End Try
            Try
                ShipToZip = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToZipColumn").Value
            Catch ex As Exception
                ShipToZip = ""
            End Try
            Try
                ShipToCountry = Me.dgvCustomerList.Rows(RowIndex).Cells("ShipToCountryColumn").Value
            Catch ex As Exception
                ShipToCountry = ""
            End Try
            Try
                BillToAddress1 = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToAddress1Column").Value
            Catch ex As Exception
                BillToAddress1 = ""
            End Try
            Try
                BillToAddress2 = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToAddress2Column").Value
            Catch ex As Exception
                BillToAddress2 = ""
            End Try
            Try
                BillToCity = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToCityColumn").Value
            Catch ex As Exception
                BillToCity = ""
            End Try
            Try
                BillToState = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToStateColumn").Value
            Catch ex As Exception
                BillToState = ""
            End Try
            Try
                BillToZip = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToZipColumn").Value
            Catch ex As Exception
                BillToZip = ""
            End Try
            Try
                BillToCountry = Me.dgvCustomerList.Rows(RowIndex).Cells("BillToCountryColumn").Value
            Catch ex As Exception
                BillToCountry = ""
            End Try
            Try
                Comments = Me.dgvCustomerList.Rows(RowIndex).Cells("CommentsColumn").Value
            Catch ex As Exception
                Comments = ""
            End Try
            Try
                PreferredShipper = Me.dgvCustomerList.Rows(RowIndex).Cells("PreferredShipperColumn").Value
            Catch ex As Exception
                PreferredShipper = ""
            End Try
            Try
                SalesTerritory = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTerritoryColumn").Value
            Catch ex As Exception
                SalesTerritory = ""
            End Try
            Try
                ShippingDetails = Me.dgvCustomerList.Rows(RowIndex).Cells("ShippingDetailsColumn").Value
            Catch ex As Exception
                ShippingDetails = ""
            End Try
            Try
                APPhoneNumber = Me.dgvCustomerList.Rows(RowIndex).Cells("APPhoneNumberColumn").Value
            Catch ex As Exception
                APPhoneNumber = ""
            End Try
            Try
                APFAXNumber = Me.dgvCustomerList.Rows(RowIndex).Cells("APFAXNumberColumn").Value
            Catch ex As Exception
                APFAXNumber = ""
            End Try
            Try
                APEmailAddress = Me.dgvCustomerList.Rows(RowIndex).Cells("APEmailAddressColumn").Value
            Catch ex As Exception
                APEmailAddress = ""
            End Try
            Try
                APContactName = Me.dgvCustomerList.Rows(RowIndex).Cells("APContactNameColumn").Value
            Catch ex As Exception
                APContactName = ""
            End Try
            Try
                CreditLimit = Me.dgvCustomerList.Rows(RowIndex).Cells("CreditLimitColumn").Value
            Catch ex As Exception
                CreditLimit = 0
            End Try
            Try
                SalesTaxRate1 = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTaxRateColumn").Value
            Catch ex As Exception
                SalesTaxRate1 = 0
            End Try
            Try
                SalesTaxRate2 = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTaxRate2Column").Value
            Catch ex As Exception
                SalesTaxRate2 = 0
            End Try
            Try
                SalesTaxRate3 = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTaxRate3Column").Value
            Catch ex As Exception
                SalesTaxRate3 = 0
            End Try
            Try
                RowDivision = Me.dgvCustomerList.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try
            Try
                RowOnHoldStatus = Me.dgvCustomerList.Rows(RowIndex).Cells("OnHoldStatusColumn").Value
            Catch ex As Exception
                RowOnHoldStatus = "NO"
            End Try
            Try
                RowShippingAccount = Me.dgvCustomerList.Rows(RowIndex).Cells("ShippingAccountColumn").Value
            Catch ex As Exception
                RowShippingAccount = ""
            End Try
            Try
                RowConfirmationEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("ConfirmationEmailColumn").Value
            Catch ex As Exception
                RowConfirmationEmail = ""
            End Try
            Try
                RowStatementEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("StatementEmailColumn").Value
            Catch ex As Exception
                RowStatementEmail = ""
            End Try
            Try
                RowCertEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("CertEmailColumn").Value
            Catch ex As Exception
                RowCertEmail = ""
            End Try
            Try
                RowPackingListEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("PackingListEmailColumn").Value
            Catch ex As Exception
                RowPackingListEmail = ""
            End Try
            Try
                RowSalesContactEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesContactEmailColumn").Value
            Catch ex As Exception
                RowSalesContactEmail = ""
            End Try
            Try
                RowSalesTaxStatus = Me.dgvCustomerList.Rows(RowIndex).Cells("SalesTaxStatusColumn").Value
            Catch ex As Exception
                RowSalesTaxStatus = ""
            End Try
            Try
                RowInvoiceEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("InvoiceEmailColumn").Value
            Catch ex As Exception
                RowInvoiceEmail = ""
            End Try
            Try
                RowInvoiceCertEmail = Me.dgvCustomerList.Rows(RowIndex).Cells("InvoiceCertEmailColumn").Value
            Catch ex As Exception
                RowInvoiceCertEmail = ""
            End Try

            If CustomerID = "" Then
                'Skip save procedure
            Else
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("UPDATE CustomerList SET CustomerName = @CustomerName, ShipToAddress1 = @ShipToAddress1, ShipToAddress2 = @ShipToAddress2, ShipToCity = @ShipToCity, ShipToState = @ShipToState, ShipToZip = @ShipToZip, ShipToCountry = @ShipToCountry, BillToAddress1 = @BillToAddress1, BillToAddress2 = @BillToAddress2, BillToCity = @BillToCity, BillToState = @BillToState, BillToZip = @BillToZip, BillToCountry = @BillToCountry, Comments = @Comments, CreditLimit = @CreditLimit, SalesTaxRate = @SalesTaxRate, PreferredShipper = @PreferredShipper, SalesTerritory = @SalesTerritory, ShippingDetails = @ShippingDetails, APContactName = @APContactName, APPhoneNumber = @APPhoneNumber, APFAXNumber = @APFAXNumber, APEmailAddress = @APEmailAddress, InvoiceEmail = @InvoiceEmail, InvoiceCertEmail = @InvoiceCertEmail, SalesTaxRate2 = @SalesTaxRate2, SalesTaxRate3 = @SalesTaxRate3, OnHoldStatus = @OnHoldStatus, ShippingAccount = @ShippingAccount, ConfirmationEmail = @ConfirmationEmail, StatementEmail = @StatementEmail, CertEmail = @CertEmail, PackingListEmail = @PackingListEmail, SalesContactEmail = @SalesContactEmail, SalesTaxStatus = @SalesTaxStatus WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@CustomerName", SqlDbType.VarChar).Value = CustomerName
                    '.Add("@CustomerDate", SqlDbType.VarChar).Value = CustomerDate
                    .Add("@ShipToAddress1", SqlDbType.VarChar).Value = ShipToAddress1
                    .Add("@ShipToAddress2", SqlDbType.VarChar).Value = ShipToAddress2
                    .Add("@ShipToCity", SqlDbType.VarChar).Value = ShipToCity
                    .Add("@ShipToState", SqlDbType.VarChar).Value = ShipToState
                    .Add("@ShipToZip", SqlDbType.VarChar).Value = ShipToZip
                    .Add("@ShipToCountry", SqlDbType.VarChar).Value = ShipToCountry
                    .Add("@ShipEmail", SqlDbType.VarChar).Value = ShipToCountry
                    .Add("@BillToAddress1", SqlDbType.VarChar).Value = BillToAddress1
                    .Add("@BillToAddress2", SqlDbType.VarChar).Value = BillToAddress2
                    .Add("@BillToCity", SqlDbType.VarChar).Value = BillToCity
                    .Add("@BillToState", SqlDbType.VarChar).Value = BillToState
                    .Add("@BillToZip", SqlDbType.VarChar).Value = BillToZip
                    .Add("@BillToCountry", SqlDbType.VarChar).Value = BillToCountry
                    .Add("@Comments", SqlDbType.VarChar).Value = Comments
                    '.Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                    .Add("@CreditLimit", SqlDbType.VarChar).Value = CreditLimit
                    .Add("@SalesTaxRate", SqlDbType.VarChar).Value = SalesTaxRate1
                    .Add("@SalesTaxRate2", SqlDbType.VarChar).Value = SalesTaxRate2
                    .Add("@SalesTaxRate3", SqlDbType.VarChar).Value = SalesTaxRate3
                    .Add("@PreferredShipper", SqlDbType.VarChar).Value = PreferredShipper
                    '.Add("@OldCustomerNumber", SqlDbType.VarChar).Value = txtOldCustomerNumber.Text
                    '.Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                    .Add("@SalesTerritory", SqlDbType.VarChar).Value = SalesTerritory
                    .Add("@ShippingDetails", SqlDbType.VarChar).Value = ShippingDetails
                    .Add("@OnHoldStatus", SqlDbType.VarChar).Value = RowOnHoldStatus
                    .Add("@APPhoneNumber", SqlDbType.VarChar).Value = APPhoneNumber
                    .Add("@APFAXNumber", SqlDbType.VarChar).Value = APFAXNumber
                    .Add("@APEmailAddress", SqlDbType.VarChar).Value = APEmailAddress
                    .Add("@InvoiceEmail", SqlDbType.VarChar).Value = RowInvoiceEmail
                    .Add("@InvoiceCertEmail", SqlDbType.VarChar).Value = RowInvoiceCertEmail
                    .Add("@APContactName", SqlDbType.VarChar).Value = APContactName
                    '.Add("@SalesTaxID", SqlDbType.VarChar).Value = txtTaxID.Text
                    '.Add("@AccountingHold", SqlDbType.VarChar).Value = AccountingHold
                    '.Add("@PricingLevel", SqlDbType.VarChar).Value = SalesTerritory
                    '.Add("@BillingType", SqlDbType.VarChar).Value = ShippingDetails
                    .Add("@ShippingAccount", SqlDbType.VarChar).Value = RowShippingAccount
                    '.Add("@BankAccount", SqlDbType.VarChar).Value = APPhoneNumber
                    .Add("@ConfirmationEmail", SqlDbType.VarChar).Value = RowConfirmationEmail
                    .Add("@StatementEmail", SqlDbType.VarChar).Value = RowStatementEmail
                    .Add("@CertEmail", SqlDbType.VarChar).Value = RowCertEmail
                    .Add("@PackingListEmail", SqlDbType.VarChar).Value = RowPackingListEmail
                    .Add("@SalesContactEmail", SqlDbType.VarChar).Value = RowSalesContactEmail
                    .Add("@SalesTaxStatus", SqlDbType.VarChar).Value = RowSalesTaxStatus
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub

    Private Sub dgvCustomerList_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCustomerList.MouseHover
        LoadDatagridToolTip()
    End Sub

    'Combo Box Events

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If cboCustomerID.Text <> "" Then
            LoadCustomerNameByID()
        End If
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        If cboCustomerName.Text <> "" Then
            LoadCustomerIDByName()
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerClass()
        LoadCustomer()
        LoadCustomerName()
        LoadSalesTerritory()
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        If cboDivisionID.Text = "TWE" Then
            ViewTWECLToolStripMenuItem.Enabled = False
            ViewTWDCLToolStripMenuItem.Enabled = True
        ElseIf cboDivisionID.Text = "TWD" Then
            ViewTWECLToolStripMenuItem.Enabled = True
            ViewTWDCLToolStripMenuItem.Enabled = False
        Else
            ViewTWECLToolStripMenuItem.Enabled = False
            ViewTWDCLToolStripMenuItem.Enabled = False
        End If
    End Sub

End Class