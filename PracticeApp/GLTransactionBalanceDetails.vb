Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Windows.Forms.DataObject
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class GLTransactionBalanceDetails
    Inherits System.Windows.Forms.Form

    Dim GetBeginDate, EndDate, BeginDate, YearDate, MonthDate, ValuationDate As Date
    Dim NewValuationYear, ValuationYear, NewYearOfDate, YearOfDate, MonthOfDate, FiscalYear, NewFiscalYear, YearOfYear, MonthOfYear, Year, intFiscalYear As Integer
    Dim ValuationMonth, GetAccountType, NewBeginDate, strMonthOfYear, strYear, FiscalBeginDate, FiscalBeginYear As String

    Dim CheckGLAccountNumber, GLDate, GLAccountNumber, GLAccountDescription, GLTransactionDescription, GLComment As String
    Dim GLDebitAmount, GLCreditAmount As Double
    Dim GLTransactionKey, GLReferenceNumber, GLReferenceLine As Integer

    Dim RetainedEarnings, BegDebitBalance, BegCreditBalance, AccountBeginningBalance, AccountEndingBalance, AccountChange As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub GLTransactionBalanceDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        LoadGLAccounts()
        LoadGLAccount2()
        ClearVariables()
        ClearData()
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

    Public Sub ClearTransactionData()
        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ZZZ"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLTransactionMasterListQuery")
        dgvGLTransactions.DataSource = ds.Tables("GLTransactionMasterListQuery")
        con.Close()
    End Sub

    Public Sub ShowGLTransactionDataByDateRange()
        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID AND GLTransactionStatus = @GLTransactionStatus AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate ORDER BY GLTransactionDate, GLTransactionKey", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLTransactionMasterListQuery")
        dgvGLTransactions.DataSource = ds.Tables("GLTransactionMasterListQuery")
        con.Close()
    End Sub

    Public Sub ShowGLTransactionDataByPeriod()
        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID AND GLTransactionStatus = @GLTransactionStatus AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate ORDER BY GLTransactionDate, GLTransactionKey", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLTransactionMasterListQuery")
        dgvGLTransactions.DataSource = ds.Tables("GLTransactionMasterListQuery")
        con.Close()
    End Sub

    Public Sub ShowGLTransactionDataByDateRangeAndAccountRange()
        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID AND GLTransactionStatus = @GLTransactionStatus AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber2) AND (GLTransactionDate BETWEEN @BeginDate AND @EndDate) ORDER BY GLAccountNumber, GLTransactionDate, GLTransactionKey", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        cmd.Parameters.Add("@GLAccountNumber2", SqlDbType.VarChar).Value = cboAccount2.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLTransactionMasterListQuery")
        dgvGLTransactions.DataSource = ds.Tables("GLTransactionMasterListQuery")
        con.Close()
    End Sub

    Public Sub ShowGLTransactionDataByPeriodAndAccountRange()
        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID AND GLTransactionStatus = @GLTransactionStatus AND (GLAccountNumber BETWEEN @GLAccountNumber AND @GLAccountNumber2) AND (GLTransactionDate BETWEEN @BeginDate AND @EndDate) ORDER BY GLAccountNumber, GLTransactionDate, GLTransactionKey", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        cmd.Parameters.Add("@GLAccountNumber2", SqlDbType.VarChar).Value = cboAccount2.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLTransactionMasterListQuery")
        dgvGLTransactions.DataSource = ds.Tables("GLTransactionMasterListQuery")
        con.Close()
    End Sub

    Public Sub LoadGLAccounts()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "GLAccounts")
        cboGLAccountNumber.DataSource = ds1.Tables("GLAccounts")
        cboAccountDescription.DataSource = ds1.Tables("GLAccounts")
        con.Close()
        cboGLAccountNumber.SelectedIndex = -1
        cboAccountDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccount2()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLAccounts")
        cboAccount2.DataSource = ds3.Tables("GLAccounts")
        cboAccountDescription2.DataSource = ds3.Tables("GLAccounts")
        con.Close()
        cboAccount2.SelectedIndex = -1
        cboAccountDescription2.SelectedIndex = -1
    End Sub

    Public Sub ShowGLDetails()
        cmd = New SqlCommand("SELECT * FROM GLTempTransactionBalances WHERE DivisionID = @DivisionID ORDER BY GLAccountNumber, PostDate, GLTransactionNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLTempTransactionBalances")
        dgvTempBalances.DataSource = ds2.Tables("GLTempTransactionBalances")
        con.Close()
        dgvTempBalances.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
    End Sub

    Public Sub ClearGLDetails()
        cmd = New SqlCommand("SELECT * FROM GLTempTransactionBalances WHERE DivisionID = @DivisionID ORDER BY PostDate, GLTransactionNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ZZZ"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLTempTransactionBalances")
        dgvTempBalances.DataSource = ds2.Tables("GLTempTransactionBalances")
        con.Close()
    End Sub

    Public Sub GetDateRangeForIncomeAccounts()
        GetBeginDate = dtpBeginDate.Value

        YearOfDate = GetBeginDate.Year
        MonthOfDate = GetBeginDate.Month

        If MonthOfDate >= 5 Then
            'Construct Date Range Beginning number
            strYear = CStr(YearOfDate)
            NewBeginDate = "05/01/" & strYear
        Else
            NewYearOfDate = YearOfDate - 1
            strYear = CStr(NewYearOfDate)
            NewBeginDate = "05/01/" & strYear
        End If
    End Sub

    Public Sub GetPeriodRangeForIncomeAccounts()
        ValuationMonth = cboFiscalPeriod.Text
        ValuationYear = Val(cboFiscalYear.Text)
        NewValuationYear = ValuationYear - 1

        'Period = 4, FiscalDate = 2014 (Sum all before 8/1/2013 to 5/1/2013)

        Select Case ValuationMonth
            Case "9"
                strYear = CStr(ValuationYear)
                NewBeginDate = "05/01/" + strYear
            Case "10"
                strYear = CStr(ValuationYear)
                NewBeginDate = "05/01/" + strYear
            Case "11"
                strYear = CStr(ValuationYear)
                NewBeginDate = "05/01/" + strYear
            Case "12"
                strYear = CStr(ValuationYear)
                NewBeginDate = "05/01/" + strYear
            Case "1"
                strYear = CStr(NewValuationYear)
                NewBeginDate = "05/01/" + strYear
            Case "2"
                strYear = CStr(NewValuationYear)
                NewBeginDate = "05/01/" + strYear
            Case "3"
                strYear = CStr(NewValuationYear)
                NewBeginDate = "05/01/" + strYear
            Case "4"
                strYear = CStr(NewValuationYear)
                NewBeginDate = "05/01/" + strYear
            Case "5"
                strYear = CStr(NewValuationYear)
                NewBeginDate = "05/01/" + strYear
            Case "6"
                strYear = CStr(NewValuationYear)
                NewBeginDate = "05/01/" + strYear
            Case "7"
                strYear = CStr(NewValuationYear)
                NewBeginDate = "05/01/" + strYear
            Case "8"
                strYear = CStr(NewValuationYear)
                NewBeginDate = "05/01/" + strYear
        End Select
    End Sub

    Public Sub GetGLAccountType()
        Dim GetAccountTypeStatement As String = "SELECT GLAccountCashFlowCode FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim GetAccountTypeCommand As New SqlCommand(GetAccountTypeStatement, con)
        GetAccountTypeCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetAccountType = CStr(GetAccountTypeCommand.ExecuteScalar)
        Catch ex As Exception
            GetAccountType = ""
        End Try
        con.Close()
    End Sub

    Public Sub LoadBeginningBalance()
        Dim DebitBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim DebitBalanceCommand As New SqlCommand(DebitBalanceStatement, con)
        DebitBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        DebitBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        DebitBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim CreditBalanceCommand As New SqlCommand(CreditBalanceStatement, con)
        CreditBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        CreditBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        CreditBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BegDebitBalance = CDbl(DebitBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegDebitBalance = 0
        End Try
        Try
            BegCreditBalance = CDbl(CreditBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegCreditBalance = 0
        End Try
        con.Close()

        AccountBeginningBalance = BegDebitBalance - BegCreditBalance
        AccountBeginningBalance = Math.Round(AccountBeginningBalance, 2)
    End Sub

    Public Sub LoadBeginningBalanceForIncomeAccounts()

        Dim DebitBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @BeginDate AND GLtransactionDate < @EndDate)"
        Dim DebitBalanceCommand As New SqlCommand(DebitBalanceStatement, con)
        DebitBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        DebitBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = NewBeginDate
        DebitBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        DebitBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @BeginDate AND GLtransactionDate < @EndDate)"
        Dim CreditBalanceCommand As New SqlCommand(CreditBalanceStatement, con)
        CreditBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        CreditBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = NewBeginDate
        CreditBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        CreditBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BegDebitBalance = CDbl(DebitBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegDebitBalance = 0
        End Try
        Try
            BegCreditBalance = CDbl(CreditBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegCreditBalance = 0
        End Try
        con.Close()

        AccountBeginningBalance = BegDebitBalance - BegCreditBalance
        AccountBeginningBalance = Math.Round(AccountBeginningBalance, 2)
    End Sub

    Public Sub LoadBeginningBalanceForPeriod()
        Dim DebitBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim DebitBalanceCommand As New SqlCommand(DebitBalanceStatement, con)
        DebitBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        DebitBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
        DebitBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim CreditBalanceCommand As New SqlCommand(CreditBalanceStatement, con)
        CreditBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        CreditBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
        CreditBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BegDebitBalance = CDbl(DebitBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegDebitBalance = 0
        End Try
        Try
            BegCreditBalance = CDbl(CreditBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegCreditBalance = 0
        End Try
        con.Close()

        AccountBeginningBalance = BegDebitBalance - BegCreditBalance
        AccountBeginningBalance = Math.Round(AccountBeginningBalance, 2)
    End Sub

    Public Sub LoadBeginningBalanceForPeriodAndIncomeAccounts()
        Dim DebitBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @BeginDate AND GLTransactionDate < @EndDate)"
        Dim DebitBalanceCommand As New SqlCommand(DebitBalanceStatement, con)
        DebitBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        DebitBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = NewBeginDate
        DebitBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = BeginDate
        DebitBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @BeginDate AND GLTransactionDate < @EndDate)"
        Dim CreditBalanceCommand As New SqlCommand(CreditBalanceStatement, con)
        CreditBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        CreditBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = NewBeginDate
        CreditBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = BeginDate
        CreditBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BegDebitBalance = CDbl(DebitBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegDebitBalance = 0
        End Try
        Try
            BegCreditBalance = CDbl(CreditBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegCreditBalance = 0
        End Try
        con.Close()

        AccountBeginningBalance = BegDebitBalance - BegCreditBalance
        AccountBeginningBalance = Math.Round(AccountBeginningBalance, 2)
    End Sub

    Public Sub LoadBeginningBalanceForAccountRange()
        Dim DebitBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim DebitBalanceCommand As New SqlCommand(DebitBalanceStatement, con)
        DebitBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
        DebitBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        DebitBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim CreditBalanceCommand As New SqlCommand(CreditBalanceStatement, con)
        CreditBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
        CreditBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        CreditBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BegDebitBalance = CDbl(DebitBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegDebitBalance = 0
        End Try
        Try
            BegCreditBalance = CDbl(CreditBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegCreditBalance = 0
        End Try
        con.Close()

        AccountBeginningBalance = BegDebitBalance - BegCreditBalance
        AccountBeginningBalance = Math.Round(AccountBeginningBalance, 2)
    End Sub

    Public Sub LoadBeginningBalanceForAccountRangeForIncomeAccounts()
        Dim DebitBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @BeginDate AND GLTransactionDate < @EndDate)"
        Dim DebitBalanceCommand As New SqlCommand(DebitBalanceStatement, con)
        DebitBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
        DebitBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = NewBeginDate
        DebitBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        DebitBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @BeginDate AND GLTransactionDate < @EndDate)"
        Dim CreditBalanceCommand As New SqlCommand(CreditBalanceStatement, con)
        CreditBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
        CreditBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = NewBeginDate
        CreditBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        CreditBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BegDebitBalance = CDbl(DebitBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegDebitBalance = 0
        End Try
        Try
            BegCreditBalance = CDbl(CreditBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegCreditBalance = 0
        End Try
        con.Close()

        AccountBeginningBalance = BegDebitBalance - BegCreditBalance
        AccountBeginningBalance = Math.Round(AccountBeginningBalance, 2)
    End Sub

    Public Sub LoadBeginningBalanceForAccountRangeAndPeriod()
        Dim DebitBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim DebitBalanceCommand As New SqlCommand(DebitBalanceStatement, con)
        DebitBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
        DebitBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
        DebitBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim CreditBalanceCommand As New SqlCommand(CreditBalanceStatement, con)
        CreditBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
        CreditBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
        CreditBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BegDebitBalance = CDbl(DebitBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegDebitBalance = 0
        End Try
        Try
            BegCreditBalance = CDbl(CreditBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegCreditBalance = 0
        End Try
        con.Close()

        AccountBeginningBalance = BegDebitBalance - BegCreditBalance
        AccountBeginningBalance = Math.Round(AccountBeginningBalance, 2)
    End Sub

    Public Sub LoadBeginningBalanceForAccountRangeAndPeriodForIncomeAccounts()
        Dim DebitBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @BeginDate AND GLTransactionDate < @EndDate)"
        Dim DebitBalanceCommand As New SqlCommand(DebitBalanceStatement, con)
        DebitBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
        DebitBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = NewBeginDate
        DebitBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = BeginDate
        DebitBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterListQuery WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @BeginDate AND GLTransactionDate < @EndDate)"
        Dim CreditBalanceCommand As New SqlCommand(CreditBalanceStatement, con)
        CreditBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
        CreditBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = NewBeginDate
        CreditBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = BeginDate
        CreditBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BegDebitBalance = CDbl(DebitBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegDebitBalance = 0
        End Try
        Try
            BegCreditBalance = CDbl(CreditBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            BegCreditBalance = 0
        End Try
        con.Close()

        AccountBeginningBalance = BegDebitBalance - BegCreditBalance
        AccountBeginningBalance = Math.Round(AccountBeginningBalance, 2)
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadGLAccounts()
        LoadGLAccount2()
        ClearVariables()
        ClearData()
    End Sub

    Private Sub chkViewByAccountRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewByAccountRange.CheckedChanged
        If chkViewByAccountRange.Checked = True Then
            cboAccount2.Enabled = True
            cboAccountDescription2.Enabled = True
        Else
            cboAccount2.SelectedIndex = -1
            cboAccountDescription2.SelectedIndex = -1
            cboAccount2.Enabled = False
            cboAccountDescription2.Enabled = False
        End If
    End Sub

    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        If chkDateRange.Checked = True Then
            dtpBeginDate.Enabled = True
            dtpEndDate.Enabled = True
            chkFiscalPeriod.Checked = False
            cboFiscalPeriod.Enabled = False
            cboFiscalYear.Enabled = False
            cboFiscalPeriod.SelectedIndex = -1
            cboFiscalYear.SelectedIndex = -1
        ElseIf chkDateRange.Checked = False Then
            dtpBeginDate.Enabled = False
            dtpEndDate.Enabled = False
            'If unchecked, do not clear Fiscal data
        End If
    End Sub

    Private Sub chkFiscalPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiscalPeriod.CheckedChanged
        If chkFiscalPeriod.Checked = True Then
            cboFiscalPeriod.Enabled = True
            cboFiscalYear.Enabled = True
            chkDateRange.Checked = False
            dtpBeginDate.Enabled = False
            dtpEndDate.Enabled = False
            dtpBeginDate.Text = ""
            dtpEndDate.Text = ""
        ElseIf chkFiscalPeriod.Checked = False Then
            cboFiscalPeriod.Enabled = False
            cboFiscalYear.Enabled = False
            'If unchecked, do not clear date range data
        End If
    End Sub

    Public Sub ClearData()
        cboAccountDescription.SelectedIndex = -1
        cboGLAccountNumber.SelectedIndex = -1
        cboFiscalPeriod.SelectedIndex = -1
        cboFiscalYear.SelectedIndex = -1
        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""
        cboAccount2.SelectedIndex = -1
        cboAccountDescription2.SelectedIndex = -1
        chkDateRange.Checked = False
        chkFiscalPeriod.Checked = False
        chkViewByAccountRange.Checked = False

        If chkDateRange.Checked = False Then
            dtpBeginDate.Enabled = False
            dtpEndDate.Enabled = False
        ElseIf chkDateRange.Checked = True Then
            dtpBeginDate.Enabled = True
            dtpEndDate.Enabled = True
        End If

        If chkFiscalPeriod.Checked = False Then
            cboFiscalPeriod.Enabled = False
            cboFiscalYear.Enabled = False
        ElseIf chkFiscalPeriod.Checked = True Then
            cboFiscalPeriod.Enabled = True
            cboFiscalYear.Enabled = True
        End If

        If chkViewByAccountRange.Checked = True Then
            cboAccount2.Enabled = True
            cboAccountDescription2.Enabled = True
        ElseIf chkViewByAccountRange.Checked = False Then
            cboAccount2.Enabled = False
            cboAccountDescription2.Enabled = False
        End If

        LoadGLAccounts()
        LoadGLAccount2()
        cboGLAccountNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        FiscalYear = 0
        NewFiscalYear = 0
        YearOfYear = 0
        MonthOfYear = 0
        Year = 0
        intFiscalYear = 0
        strMonthOfYear = ""
        strYear = ""
        FiscalBeginDate = ""
        FiscalBeginYear = ""
        CheckGLAccountNumber = ""
        GLDate = ""
        GLAccountNumber = ""
        GLAccountDescription = ""
        GLTransactionDescription = ""
        GLComment = ""
        GLDebitAmount = 0
        GLCreditAmount = 0
        GLTransactionKey = 0
        GLReferenceNumber = 0
        GLReferenceLine = 0
        RetainedEarnings = 0
        BegDebitBalance = 0
        BegCreditBalance = 0
        AccountBeginningBalance = 0
        AccountEndingBalance = 0
        AccountChange = 0
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearGLDetails()
        ClearTransactionData()
    End Sub

    Public Sub GetFiscalDateRange()
        FiscalYear = Val(cboFiscalYear.Text)
        NewFiscalYear = FiscalYear - 1
        FiscalBeginYear = CStr(NewFiscalYear)

        If Val(cboFiscalPeriod.Text) = 9 Then
            BeginDate = "1/1/" + cboFiscalYear.Text
            EndDate = "1/31/" + cboFiscalYear.Text
        ElseIf Val(cboFiscalPeriod.Text) = 10 Then
            BeginDate = "2/1/" + cboFiscalYear.Text
            EndDate = "2/28/" + cboFiscalYear.Text
        ElseIf Val(cboFiscalPeriod.Text) = 11 Then
            BeginDate = "3/1/" + cboFiscalYear.Text
            EndDate = "3/31/" + cboFiscalYear.Text
        ElseIf Val(cboFiscalPeriod.Text) = 12 Then
            BeginDate = "4/1/" + cboFiscalYear.Text
            EndDate = "4/30/" + cboFiscalYear.Text
        ElseIf Val(cboFiscalPeriod.Text) = 1 Then
            BeginDate = "5/1/" + FiscalBeginYear
            EndDate = "5/31/" + FiscalBeginYear
        ElseIf Val(cboFiscalPeriod.Text) = 2 Then
            BeginDate = "6/1/" + FiscalBeginYear
            EndDate = "6/30/" + FiscalBeginYear
        ElseIf Val(cboFiscalPeriod.Text) = 3 Then
            BeginDate = "7/1/" + FiscalBeginYear
            EndDate = "7/31/" + FiscalBeginYear
        ElseIf Val(cboFiscalPeriod.Text) = 4 Then
            BeginDate = "8/1/" + FiscalBeginYear
            EndDate = "8/31/" + FiscalBeginYear
        ElseIf Val(cboFiscalPeriod.Text) = 5 Then
            BeginDate = "9/1/" + FiscalBeginYear
            EndDate = "9/30/" + FiscalBeginYear
        ElseIf Val(cboFiscalPeriod.Text) = 6 Then
            BeginDate = "10/1/" + FiscalBeginYear
            EndDate = "10/31/" + FiscalBeginYear
        ElseIf Val(cboFiscalPeriod.Text) = 7 Then
            BeginDate = "11/1/" + FiscalBeginYear
            EndDate = "11/30/" + FiscalBeginYear
        ElseIf Val(cboFiscalPeriod.Text) = 8 Then
            BeginDate = "12/1/" + FiscalBeginYear
            EndDate = "12/31/" + FiscalBeginYear
        End If
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        If chkViewByAccountRange.Checked = True And chkDateRange.Checked = True And chkFiscalPeriod.Checked = False Then
            If cboAccount2.Text = "" Or cboGLAccountNumber.Text = "" Then
                MsgBox("You must have a valid GL Account # in both fields to select by range.", MsgBoxStyle.OkOnly)
            Else
                FilterByAccountRangeAndDateRange()
            End If
        ElseIf chkViewByAccountRange.Checked = False And chkDateRange.Checked = True And chkFiscalPeriod.Checked = False Then
            FilterByAccountAndDateRange()
        ElseIf chkViewByAccountRange.Checked = True And chkFiscalPeriod.Checked = True And chkDateRange.Checked = False Then
            'Check to see if period combo boxes are filled
            If cboAccount2.Text = "" Or cboGLAccountNumber.Text = "" Then
                MsgBox("You must have a valid GL Account # in both fields to select by range.", MsgBoxStyle.OkOnly)
            Else
                If cboFiscalPeriod.Text = "" Or cboFiscalYear.Text = "" Then
                    MsgBox("You must have a valid fiscal period and year selected.", MsgBoxStyle.OkOnly)
                Else
                    FilterByAccountRangeAndPeriod()
                End If
            End If
        ElseIf chkViewByAccountRange.Checked = False And chkFiscalPeriod.Checked = True And chkDateRange.Checked = False Then
            If cboFiscalPeriod.Text = "" Or cboFiscalYear.Text = "" Then
                MsgBox("You must have a valid fiscal period and year selected.", MsgBoxStyle.OkOnly)
            Else
                FilterByAccountAndPeriod()
            End If
        End If
    End Sub

    Public Sub FilterByAccountAndDateRange()
        'Clear Temp Table
        cmd = New SqlCommand("DELETE FROM GLTempTransactionBalances WHERE DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Filter GL Transactions and sort in order by date, transaction number
        ShowGLTransactionDataByDateRange()

        GetGLAccountType()

        If GetAccountType = "IncomeStatement" Then
            GetDateRangeForIncomeAccounts()
            LoadBeginningBalanceForIncomeAccounts()
        Else
            'Get Beginning balance to write to temp table
            LoadBeginningBalance()
        End If

        'Write values to Temp Table
        For Each row As DataGridViewRow In dgvGLTransactions.Rows
            Try
                GLAccountNumber = row.Cells("GLAccountNumberColumn").Value
            Catch ex As Exception
                GLAccountNumber = ""
            End Try
            Try
                GLAccountDescription = row.Cells("GLAccountShortDescriptionColumn").Value
            Catch ex As Exception
                GLAccountDescription = ""
            End Try
            Try
                GLTransactionKey = row.Cells("GLTransactionKeyColumn").Value
            Catch ex As Exception
                GLTransactionKey = 0
            End Try
            Try
                GLTransactionDescription = row.Cells("GLTransactionDescriptionColumn").Value
            Catch ex As Exception
                GLTransactionDescription = ""
            End Try
            Try
                GLDebitAmount = row.Cells("GLTransactionDebitAmountColumn").Value
            Catch ex As Exception
                GLDebitAmount = 0
            End Try
            Try
                GLCreditAmount = row.Cells("GLTransactionCreditAmountColumn").Value
            Catch ex As Exception
                GLCreditAmount = 0
            End Try
            Try
                GLDate = row.Cells("GLTransactionDateColumn").Value
            Catch ex As Exception
                GLDate = ""
            End Try
            Try
                GLComment = row.Cells("GLTransactionCommentColumn").Value
            Catch ex As Exception
                GLComment = ""
            End Try
            Try
                GLReferenceNumber = row.Cells("GLReferenceNumberColumn").Value
            Catch ex As Exception
                GLReferenceNumber = 0
            End Try
            Try
                GLReferenceLine = row.Cells("GLReferenceLineColumn").Value
            Catch ex As Exception
                GLReferenceLine = 0
            End Try

            'Calculate Ending Balance, Change
            AccountEndingBalance = AccountBeginningBalance + GLDebitAmount - GLCreditAmount
            AccountChange = AccountEndingBalance - AccountBeginningBalance

            AccountEndingBalance = Math.Round(AccountEndingBalance, 2)
            AccountChange = Math.Round(AccountChange, 2)

            'Write Data to temp table
            cmd = New SqlCommand("INSERT INTO GLTempTransactionBalances(PostDate, GLTransactionNumber, GLAccountNumber, GLAccountDescription, GLReferenceNumber, GLReferenceLine, GLComment, GLDebitAmount, GLCreditAmount, GLBeginningBalance, GLEndingBalance, GLChange, GLTransactionDescription, DivisionID) Values (@PostDate, @GLTransactionNumber, @GLAccountNumber, @GLAccountDescription, @GLReferenceNumber, @GLReferenceLine, @GLComment, @GLDebitAmount, @GLCreditAmount, @GLBeginningBalance, @GLEndingBalance, @GLChange, @GLTransactionDescription, @DivisionID)", con)

            With cmd.Parameters
                .Add("@PostDate", SqlDbType.VarChar).Value = GLDate
                .Add("@GLTransactionNumber", SqlDbType.VarChar).Value = GLTransactionKey
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
                .Add("@GLAccountDescription", SqlDbType.VarChar).Value = GLAccountDescription
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = GLReferenceNumber
                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = GLReferenceLine
                .Add("@GLComment", SqlDbType.VarChar).Value = GLComment
                .Add("@GLDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                .Add("@GLBeginningBalance", SqlDbType.VarChar).Value = AccountBeginningBalance
                .Add("@GLEndingBalance", SqlDbType.VarChar).Value = AccountEndingBalance
                .Add("@GLChange", SqlDbType.VarChar).Value = AccountChange
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = GLTransactionDescription
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Reset New Beginning balance
            AccountBeginningBalance = AccountEndingBalance
            AccountChange = 0
            GLDebitAmount = 0
            GLCreditAmount = 0
        Next

        'Load Data into grid
        ShowGLDetails()
    End Sub

    Public Sub FilterByAccountAndPeriod()
        'Clear Temp Table
        cmd = New SqlCommand("DELETE FROM GLTempTransactionBalances WHERE DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Get Fiscal Period
        GetFiscalDateRange()

        'Filter GL Transactions and sort in order by date, transaction number
        ShowGLTransactionDataByPeriod()

        GetGLAccountType()

        If GetAccountType = "IncomeStatement" Then
            GetPeriodRangeForIncomeAccounts()
            LoadBeginningBalanceForPeriodAndIncomeAccounts()
        Else
            'Get Beginning balance to write to temp table
            LoadBeginningBalanceForPeriod()
        End If

        'Write values to Temp Table
        For Each row As DataGridViewRow In dgvGLTransactions.Rows
            Try
                GLAccountNumber = row.Cells("GLAccountNumberColumn").Value
            Catch ex As Exception
                GLAccountNumber = ""
            End Try
            Try
                GLAccountDescription = row.Cells("GLAccountShortDescriptionColumn").Value
            Catch ex As Exception
                GLAccountDescription = ""
            End Try
            Try
                GLTransactionKey = row.Cells("GLTransactionKeyColumn").Value
            Catch ex As Exception
                GLTransactionKey = 0
            End Try
            Try
                GLTransactionDescription = row.Cells("GLTransactionDescriptionColumn").Value
            Catch ex As Exception
                GLTransactionDescription = ""
            End Try
            Try
                GLDebitAmount = row.Cells("GLTransactionDebitAmountColumn").Value
            Catch ex As Exception
                GLDebitAmount = 0
            End Try
            Try
                GLCreditAmount = row.Cells("GLTransactionCreditAmountColumn").Value
            Catch ex As Exception
                GLCreditAmount = 0
            End Try
            Try
                GLDate = row.Cells("GLTransactionDateColumn").Value
            Catch ex As Exception
                GLDate = ""
            End Try
            Try
                GLComment = row.Cells("GLTransactionCommentColumn").Value
            Catch ex As Exception
                GLComment = ""
            End Try
            Try
                GLReferenceNumber = row.Cells("GLReferenceNumberColumn").Value
            Catch ex As Exception
                GLReferenceNumber = 0
            End Try
            Try
                GLReferenceLine = row.Cells("GLReferenceLineColumn").Value
            Catch ex As Exception
                GLReferenceLine = 0
            End Try

            'Calculate Ending Balance, Change
            AccountEndingBalance = AccountBeginningBalance + GLDebitAmount - GLCreditAmount
            AccountChange = AccountEndingBalance - AccountBeginningBalance

            AccountEndingBalance = Math.Round(AccountEndingBalance, 2)
            AccountChange = Math.Round(AccountChange, 2)

            'Write Data to temp table
            cmd = New SqlCommand("INSERT INTO GLTempTransactionBalances(PostDate, GLTransactionNumber, GLAccountNumber, GLAccountDescription, GLReferenceNumber, GLReferenceLine, GLComment, GLDebitAmount, GLCreditAmount, GLBeginningBalance, GLEndingBalance, GLChange, GLTransactionDescription, DivisionID) Values (@PostDate, @GLTransactionNumber, @GLAccountNumber, @GLAccountDescription, @GLReferenceNumber, @GLReferenceLine, @GLComment, @GLDebitAmount, @GLCreditAmount, @GLBeginningBalance, @GLEndingBalance, @GLChange, @GLTransactionDescription, @DivisionID)", con)

            With cmd.Parameters
                .Add("@PostDate", SqlDbType.VarChar).Value = GLDate
                .Add("@GLTransactionNumber", SqlDbType.VarChar).Value = GLTransactionKey
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
                .Add("@GLAccountDescription", SqlDbType.VarChar).Value = GLAccountDescription
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = GLReferenceNumber
                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = GLReferenceLine
                .Add("@GLComment", SqlDbType.VarChar).Value = GLComment
                .Add("@GLDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                .Add("@GLBeginningBalance", SqlDbType.VarChar).Value = AccountBeginningBalance
                .Add("@GLEndingBalance", SqlDbType.VarChar).Value = AccountEndingBalance
                .Add("@GLChange", SqlDbType.VarChar).Value = AccountChange
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = GLTransactionDescription
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Reset New Beginning balance
            AccountBeginningBalance = AccountEndingBalance
            AccountChange = 0
            GLDebitAmount = 0
            GLCreditAmount = 0
        Next

        'Load Data into grid
        ShowGLDetails()
    End Sub

    Public Sub FilterByAccountRangeAndDateRange()
        'Clear Temp Table
        cmd = New SqlCommand("DELETE FROM GLTempTransactionBalances WHERE DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Set first repetition to load beginning balance
        CheckGLAccountNumber = "NONE"

        'Filter GL Transactions and sort in order by date, transaction number
        ShowGLTransactionDataByDateRangeAndAccountRange()

        'Write values to Temp Table
        For Each row As DataGridViewRow In dgvGLTransactions.Rows
            Try
                GLAccountNumber = row.Cells("GLAccountNumberColumn").Value
            Catch ex As Exception
                GLAccountNumber = ""
            End Try
            Try
                GLAccountDescription = row.Cells("GLAccountShortDescriptionColumn").Value
            Catch ex As Exception
                GLAccountDescription = ""
            End Try
            Try
                GLTransactionKey = row.Cells("GLTransactionKeyColumn").Value
            Catch ex As Exception
                GLTransactionKey = 0
            End Try
            Try
                GLTransactionDescription = row.Cells("GLTransactionDescriptionColumn").Value
            Catch ex As Exception
                GLTransactionDescription = ""
            End Try
            Try
                GLDebitAmount = row.Cells("GLTransactionDebitAmountColumn").Value
            Catch ex As Exception
                GLDebitAmount = 0
            End Try
            Try
                GLCreditAmount = row.Cells("GLTransactionCreditAmountColumn").Value
            Catch ex As Exception
                GLCreditAmount = 0
            End Try
            Try
                GLDate = row.Cells("GLTransactionDateColumn").Value
            Catch ex As Exception
                GLDate = ""
            End Try
            Try
                GLComment = row.Cells("GLTransactionCommentColumn").Value
            Catch ex As Exception
                GLComment = ""
            End Try
            Try
                GLReferenceNumber = row.Cells("GLReferenceNumberColumn").Value
            Catch ex As Exception
                GLReferenceNumber = 0
            End Try
            Try
                GLReferenceLine = row.Cells("GLReferenceLineColumn").Value
            Catch ex As Exception
                GLReferenceLine = 0
            End Try

            If GLAccountNumber = CheckGLAccountNumber Then
                AccountBeginningBalance = AccountEndingBalance

                'Calculate Ending Balance, Change
                AccountEndingBalance = AccountBeginningBalance + GLDebitAmount - GLCreditAmount
                AccountChange = AccountEndingBalance - AccountBeginningBalance

                AccountEndingBalance = Math.Round(AccountEndingBalance, 2)
                AccountChange = Math.Round(AccountChange, 2)
            Else
                'Load Correct Beginning Balance for specific account type
                GetGLAccountType()

                If GetAccountType = "IncomeStatement" Then
                    GetDateRangeForIncomeAccounts()
                    LoadBeginningBalanceForAccountRangeForIncomeAccounts()
                Else
                    'Get Beginning balance for first account in Range
                    LoadBeginningBalanceForAccountRange()
                End If

                'Calculate Ending Balance, Change
                AccountEndingBalance = AccountBeginningBalance + GLDebitAmount - GLCreditAmount
                AccountChange = AccountEndingBalance - AccountBeginningBalance

                AccountEndingBalance = Math.Round(AccountEndingBalance, 2)
                AccountChange = Math.Round(AccountChange, 2)
            End If

            'Write Data to temp table
            cmd = New SqlCommand("INSERT INTO GLTempTransactionBalances(PostDate, GLTransactionNumber, GLAccountNumber, GLAccountDescription, GLReferenceNumber, GLReferenceLine, GLComment, GLDebitAmount, GLCreditAmount, GLBeginningBalance, GLEndingBalance, GLChange, GLTransactionDescription, DivisionID) Values (@PostDate, @GLTransactionNumber, @GLAccountNumber, @GLAccountDescription, @GLReferenceNumber, @GLReferenceLine, @GLComment, @GLDebitAmount, @GLCreditAmount, @GLBeginningBalance, @GLEndingBalance, @GLChange, @GLTransactionDescription, @DivisionID)", con)

            With cmd.Parameters
                .Add("@PostDate", SqlDbType.VarChar).Value = GLDate
                .Add("@GLTransactionNumber", SqlDbType.VarChar).Value = GLTransactionKey
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
                .Add("@GLAccountDescription", SqlDbType.VarChar).Value = GLAccountDescription
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = GLReferenceNumber
                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = GLReferenceLine
                .Add("@GLComment", SqlDbType.VarChar).Value = GLComment
                .Add("@GLDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                .Add("@GLBeginningBalance", SqlDbType.VarChar).Value = AccountBeginningBalance
                .Add("@GLEndingBalance", SqlDbType.VarChar).Value = AccountEndingBalance
                .Add("@GLChange", SqlDbType.VarChar).Value = AccountChange
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = GLTransactionDescription
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Reset New Beginning balance
            CheckGLAccountNumber = GLAccountNumber
            AccountChange = 0
            GLDebitAmount = 0
            GLCreditAmount = 0
        Next

        'Load Data into grid
        ShowGLDetails()
    End Sub

    Public Sub FilterByAccountRangeAndPeriod()
        'Clear Temp Table
        cmd = New SqlCommand("DELETE FROM GLTempTransactionBalances WHERE DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Set first repetition to load beginning balance
        CheckGLAccountNumber = "NONE"

        'Get fiscal date range
        GetFiscalDateRange()

        'Filter GL Transactions and sort in order by date, transaction number
        ShowGLTransactionDataByPeriodAndAccountRange()

        'Write values to Temp Table
        For Each row As DataGridViewRow In dgvGLTransactions.Rows
            Try
                GLAccountNumber = row.Cells("GLAccountNumberColumn").Value
            Catch ex As Exception
                GLAccountNumber = ""
            End Try
            Try
                GLAccountDescription = row.Cells("GLAccountShortDescriptionColumn").Value
            Catch ex As Exception
                GLAccountDescription = ""
            End Try
            Try
                GLTransactionKey = row.Cells("GLTransactionKeyColumn").Value
            Catch ex As Exception
                GLTransactionKey = 0
            End Try
            Try
                GLTransactionDescription = row.Cells("GLTransactionDescriptionColumn").Value
            Catch ex As Exception
                GLTransactionDescription = ""
            End Try
            Try
                GLDebitAmount = row.Cells("GLTransactionDebitAmountColumn").Value
            Catch ex As Exception
                GLDebitAmount = 0
            End Try
            Try
                GLCreditAmount = row.Cells("GLTransactionCreditAmountColumn").Value
            Catch ex As Exception
                GLCreditAmount = 0
            End Try
            Try
                GLDate = row.Cells("GLTransactionDateColumn").Value
            Catch ex As Exception
                GLDate = ""
            End Try
            Try
                GLComment = row.Cells("GLTransactionCommentColumn").Value
            Catch ex As Exception
                GLComment = ""
            End Try
            Try
                GLReferenceNumber = row.Cells("GLReferenceNumberColumn").Value
            Catch ex As Exception
                GLReferenceNumber = 0
            End Try
            Try
                GLReferenceLine = row.Cells("GLReferenceLineColumn").Value
            Catch ex As Exception
                GLReferenceLine = 0
            End Try

            If GLAccountNumber = CheckGLAccountNumber Then
                AccountBeginningBalance = AccountEndingBalance

                'Calculate Ending Balance, Change
                AccountEndingBalance = AccountBeginningBalance + GLDebitAmount - GLCreditAmount
                AccountChange = AccountEndingBalance - AccountBeginningBalance

                AccountEndingBalance = Math.Round(AccountEndingBalance, 2)
                AccountChange = Math.Round(AccountChange, 2)
            Else
                'Load Beg. Balance for specific GL Account Type
                GetGLAccountType()

                If GetAccountType = "IncomeStatement" Then
                    GetPeriodRangeForIncomeAccounts()
                    LoadBeginningBalanceForAccountRangeAndPeriodForIncomeAccounts()
                Else
                    'Get Beginning balance for first account in Range
                    LoadBeginningBalanceForAccountRangeAndPeriod()
                End If

                'Calculate Ending Balance, Change
                AccountEndingBalance = AccountBeginningBalance + GLDebitAmount - GLCreditAmount
                AccountChange = AccountEndingBalance - AccountBeginningBalance

                AccountEndingBalance = Math.Round(AccountEndingBalance, 2)
                AccountChange = Math.Round(AccountChange, 2)
            End If

            'Write Data to temp table
            cmd = New SqlCommand("INSERT INTO GLTempTransactionBalances(PostDate, GLTransactionNumber, GLAccountNumber, GLAccountDescription, GLReferenceNumber, GLReferenceLine, GLComment, GLDebitAmount, GLCreditAmount, GLBeginningBalance, GLEndingBalance, GLChange, GLTransactionDescription, DivisionID) Values (@PostDate, @GLTransactionNumber, @GLAccountNumber, @GLAccountDescription, @GLReferenceNumber, @GLReferenceLine, @GLComment, @GLDebitAmount, @GLCreditAmount, @GLBeginningBalance, @GLEndingBalance, @GLChange, @GLTransactionDescription, @DivisionID)", con)

            With cmd.Parameters
                .Add("@PostDate", SqlDbType.VarChar).Value = GLDate
                .Add("@GLTransactionNumber", SqlDbType.VarChar).Value = GLTransactionKey
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
                .Add("@GLAccountDescription", SqlDbType.VarChar).Value = GLAccountDescription
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = GLReferenceNumber
                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = GLReferenceLine
                .Add("@GLComment", SqlDbType.VarChar).Value = GLComment
                .Add("@GLDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                .Add("@GLBeginningBalance", SqlDbType.VarChar).Value = AccountBeginningBalance
                .Add("@GLEndingBalance", SqlDbType.VarChar).Value = AccountEndingBalance
                .Add("@GLChange", SqlDbType.VarChar).Value = AccountChange
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = GLTransactionDescription
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Reset New Beginning balance
            CheckGLAccountNumber = GLAccountNumber
            AccountChange = 0
            GLDebitAmount = 0
            GLCreditAmount = 0
        Next

        'Load Data into grid
        ShowGLDetails()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds2
        Using NewPrintGLTransactionDetail As New PrintGLTransactionDetail
            Dim Result = NewPrintGLTransactionDetail.ShowDialog()
        End Using
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
End Class