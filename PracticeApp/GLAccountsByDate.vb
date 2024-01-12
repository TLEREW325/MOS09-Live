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
Public Class GLAccountsByDate
    Inherits System.Windows.Forms.Form

    Dim BeginDate, YearDate, MonthDate, ValuationDate As Date
    Dim YearOfYear, MonthOfYear, Year, intFiscalYear As Integer
    Dim strMonthOfYear, strYear, FiscalBeginDate, FiscalBeginYear As String

    Dim RetainedEarnings, DebitREBalance, CreditREBalance As Double
    Dim BegFiscalDate, EndFiscalDate, LastEndDate As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub GLAccountsByDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        ClearData()
        ClearValuationData()
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

    Public Sub ShowValuationData()
        cmd = New SqlCommand("SELECT * FROM GLTransactionValuationFinal", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "GLTransactionValuationFinal")
        dgvGLValuation.DataSource = ds1.Tables("GLTransactionValuationFinal")
        con.Close()
        dgvGLValuation.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
    End Sub

    Public Sub ShowValuationDataNonZero()
        cmd = New SqlCommand("SELECT * FROM GLTransactionValuationFinal WHERE (BeginningBalance > 0) OR (Debits > 0) OR (Credits > 0) OR (EndingBalance > 0) OR (BeginningBalance < 0) OR (Debits < 0) OR (Credits < 0) OR (EndingBalance < 0)", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "GLTransactionValuationFinal")
        dgvGLValuation.DataSource = ds1.Tables("GLTransactionValuationFinal")
        con.Close()
        dgvGLValuation.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
    End Sub

    Public Sub ClearData()
        dtpValuationDate.Text = ""

        chkArchiveData.Checked = False
        txtLastArchiveDate.Clear()

        cmdBalances2.Enabled = False

        dtpValuationDate.Focus()
    End Sub

    Public Sub ClearValuationData()
        dgvGLValuation.DataSource = Nothing
    End Sub

    Public Sub ShowGLAccountsAmerican()
        cmd = New SqlCommand("SELECT * FROM GLAccounts WHERE GLAccountNumber NOT LIKE 'C$%'", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLAccounts")
        dgvGLAccounts.DataSource = ds3.Tables("GLAccounts")
        con.Close()
    End Sub

    Public Sub ShowGLAccountsCanadian()
        cmd = New SqlCommand("SELECT * FROM GLAccounts", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLAccounts")
        dgvGLAccounts.DataSource = ds3.Tables("GLAccounts")
        con.Close()
    End Sub

    Public Sub CalculateRetainedEarnings()
        Dim CheckArchiveData As String = ""

        'Calculate Beginning Date to value
        ValuationDate = dtpValuationDate.Text
        MonthDate = ValuationDate
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear

        'Get Date Range to beginning of the fiscal year only
        If MonthOfYear < 5 Then
            intFiscalYear = MonthDate.Year - 1
            FiscalBeginYear = Str(intFiscalYear)
            FiscalBeginDate = "05/01/" + FiscalBeginYear
        Else
            intFiscalYear = MonthDate.Year
            FiscalBeginYear = Str(intFiscalYear)
            FiscalBeginDate = "05/01/" + FiscalBeginYear
        End If

        If chkArchiveData.Checked = True Then
            CheckArchiveData = "Archive"
        Else
            CheckArchiveData = ""
        End If

        Dim DebitREBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchiveData + "Query WHERE GLAccountCashFlowCode = @GLAccountCashFlowCode AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim DebitREBalanceCommand As New SqlCommand(DebitREBalanceStatement, con)
        DebitREBalanceCommand.Parameters.Add("@GLAccountCashFlowCode", SqlDbType.VarChar).Value = "IncomeStatement"
        DebitREBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = FiscalBeginDate
        DebitREBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditREBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchiveData + "Query WHERE GLAccountCashFlowCode = @GLAccountCashFlowCode AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim CreditREBalanceCommand As New SqlCommand(CreditREBalanceStatement, con)
        CreditREBalanceCommand.Parameters.Add("@GLAccountCashFlowCode", SqlDbType.VarChar).Value = "IncomeStatement"
        CreditREBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = FiscalBeginDate
        CreditREBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DebitREBalance = CDbl(DebitREBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            DebitREBalance = 0
        End Try
        Try
            CreditREBalance = CDbl(CreditREBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            CreditREBalance = 0
        End Try
        con.Close()

        RetainedEarnings = DebitREBalance - CreditREBalance
    End Sub

    Public Sub DefineFiscalYear()
        BegFiscalDate = "1/1/2001"
        EndFiscalDate = "1/1/2001"
        LastEndDate = "1/1/2001"

        If dtpValuationDate.Value > "4/30/2011" And dtpValuationDate.Value < "5/1/2012" Then
            BegFiscalDate = "5/1/2011"
            EndFiscalDate = "4/30/2012"
            LastEndDate = "4/30/2011"
        ElseIf dtpValuationDate.Value > "4/30/2012" And dtpValuationDate.Value < "5/1/2013" Then
            BegFiscalDate = "5/1/2012"
            EndFiscalDate = "4/30/2013"
            LastEndDate = "4/30/2012"
        ElseIf dtpValuationDate.Value > "4/30/2013" And dtpValuationDate.Value < "5/1/2014" Then
            BegFiscalDate = "5/1/2013"
            EndFiscalDate = "4/30/2014"
            LastEndDate = "4/30/2013"
        ElseIf dtpValuationDate.Value > "4/30/2014" And dtpValuationDate.Value < "5/1/2015" Then
            BegFiscalDate = "5/1/2014"
            EndFiscalDate = "4/30/2015"
            LastEndDate = "4/30/2014"
        ElseIf dtpValuationDate.Value > "4/30/2015" And dtpValuationDate.Value < "5/1/2016" Then
            BegFiscalDate = "5/1/2015"
            EndFiscalDate = "4/30/2016"
            LastEndDate = "4/30/2015"
        ElseIf dtpValuationDate.Value > "4/30/2016" And dtpValuationDate.Value < "5/1/2017" Then
            BegFiscalDate = "5/1/2016"
            EndFiscalDate = "4/30/2017"
            LastEndDate = "4/30/2016"
        ElseIf dtpValuationDate.Value > "4/30/2017" And dtpValuationDate.Value < "5/1/2018" Then
            BegFiscalDate = "5/1/2017"
            EndFiscalDate = "4/30/2018"
            LastEndDate = "4/30/2017"
        ElseIf dtpValuationDate.Value > "4/30/2018" And dtpValuationDate.Value < "5/1/2019" Then
            BegFiscalDate = "5/1/2018"
            EndFiscalDate = "4/30/2019"
            LastEndDate = "4/30/2018"
        ElseIf dtpValuationDate.Value > "4/30/2019" And dtpValuationDate.Value < "5/1/2020" Then
            BegFiscalDate = "5/1/2019"
            EndFiscalDate = "4/30/2020"
            LastEndDate = "4/30/2019"
        ElseIf dtpValuationDate.Value > "4/30/2020" And dtpValuationDate.Value < "5/1/2021" Then
            BegFiscalDate = "5/1/2020"
            EndFiscalDate = "4/30/2021"
            LastEndDate = "4/30/2020"
        ElseIf dtpValuationDate.Value > "4/30/2021" And dtpValuationDate.Value < "5/1/2022" Then
            BegFiscalDate = "5/1/2021"
            EndFiscalDate = "4/30/2022"
            LastEndDate = "4/30/2021"
        ElseIf dtpValuationDate.Value > "4/30/2022" And dtpValuationDate.Value < "5/1/2023" Then
            BegFiscalDate = "5/1/2022"
            EndFiscalDate = "4/30/2023"
            LastEndDate = "4/30/2022"
        ElseIf dtpValuationDate.Value > "4/30/2023" And dtpValuationDate.Value < "5/1/2024" Then
            BegFiscalDate = "5/1/2023"
            EndFiscalDate = "4/30/2024"
            LastEndDate = "4/30/2023"
        End If
    End Sub

    Private Sub cmdFilter2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter2.Click
        If isSomeoneEditing() Then
            Exit Sub
        End If

        Dim GLBegDebitTotal2, GLBegDebitTotal, GLBegCreditTotal2, GLBegCreditTotal, GLCurrentDebitTotal, GLCurrentCreditTotal, GLEndDebitTotal, GLEndCreditTotal As Double
        GLBegDebitTotal = 0
        GLBegCreditTotal = 0
        GLCurrentDebitTotal = 0
        GLCurrentCreditTotal = 0
        GLEndDebitTotal = 0
        GLEndCreditTotal = 0
        Dim CheckArchiveData As String = ""

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempDebitBeginning", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempCreditBeginning", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempDebitRange", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempCreditRange", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempDebitEnding", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempCreditEnding", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Show all GL Accounts
        If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
            ShowGLAccountsCanadian()
        Else
            ShowGLAccountsAmerican()
        End If

        'Calculate Beginning of Month Date
        ValuationDate = dtpValuationDate.Text
        MonthDate = ValuationDate
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear

        'Calculate Beginning Date to value
        DefineFiscalYear()

        'Define wheteher it is archive data or not
        If chkArchiveData.Checked = True Then
            CheckArchiveData = "Archive"
        Else
            CheckArchiveData = ""
        End If

        'Extract Data from filtered dataset to write to temp table
        For Each row As DataGridViewRow In dgvGLAccounts.Rows
            Dim GLAccount As String = row.Cells("GLAccountNumberColumn1").Value
            Dim GLCashFlowCode As String = row.Cells("GLAccountCashFlowCodeColumn1").Value

            'Check account type to determine if value should be written (IS Account / BS Account)
            If GLCashFlowCode = "BalanceSheet" Then
                'Get Beginning Balance
                Dim GetBegDebitBalance2Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchiveData + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @EndDate"
                Dim GetBegDebitBalance2Command As New SqlCommand(GetBegDebitBalance2Statement, con)
                GetBegDebitBalance2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = BeginDate
                GetBegDebitBalance2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetBegDebitBalance2Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLBegDebitTotal = CDbl(GetBegDebitBalance2Command.ExecuteScalar)
                Catch ex As Exception
                    GLBegDebitTotal = 0
                End Try
                con.Close()

                'Write Data to temp table
                cmd = New SqlCommand("Insert INTO GLTempDebitBeginning(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID, Locked) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID, @Locked)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLDebitAmount", SqlDbType.VarChar).Value = GLBegDebitTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Dim GetBegCreditBalance2Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchiveData + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @EndDate"
                Dim GetBegCreditBalance2Command As New SqlCommand(GetBegCreditBalance2Statement, con)
                GetBegCreditBalance2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = BeginDate
                GetBegCreditBalance2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetBegCreditBalance2Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLBegCreditTotal = CDbl(GetBegCreditBalance2Command.ExecuteScalar)
                Catch ex As Exception
                    GLBegCreditTotal = 0
                End Try
                con.Close()

                'Write Data to temp table
                cmd = New SqlCommand("Insert INTO GLTempCreditBeginning(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLBegCreditTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*************************************************************************************************************************************************
                'Get Current Balance
                Dim CurrentDebitBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchiveData + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
                Dim CurrentDebitBalanceCommand As New SqlCommand(CurrentDebitBalanceStatement, con)
                CurrentDebitBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                CurrentDebitBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                CurrentDebitBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CurrentDebitBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLCurrentDebitTotal = CDbl(CurrentDebitBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    GLCurrentDebitTotal = 0
                End Try
                con.Close()

                'Write Data to temp table
                cmd = New SqlCommand("Insert INTO GLTempDebitRange(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLDebitAmount", SqlDbType.VarChar).Value = GLCurrentDebitTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Dim CurrentCreditBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchiveData + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
                Dim CurrentCreditBalanceCommand As New SqlCommand(CurrentCreditBalanceStatement, con)
                CurrentCreditBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                CurrentCreditBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                CurrentCreditBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CurrentCreditBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLCurrentCreditTotal = CDbl(CurrentCreditBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    GLCurrentCreditTotal = 0
                End Try
                con.Close()

                'Write Data to temp table
                cmd = New SqlCommand("Insert INTO GLTempCreditRange(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCurrentCreditTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***********************************************************************************************************************************************************
                GLEndDebitTotal = GLBegDebitTotal + GLCurrentDebitTotal
                GLEndCreditTotal = GLBegCreditTotal + GLCurrentCreditTotal

                'Write Data to temp table
                cmd = New SqlCommand("Insert INTO GLTempDebitEnding(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLDebitAmount", SqlDbType.VarChar).Value = GLEndDebitTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                cmd = New SqlCommand("Insert INTO GLTempCreditEnding(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLEndCreditTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            ElseIf GLCashFlowCode = "IncomeStatement" Then
                Dim GetBegDebitBalance2Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchiveData + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND (GLTransactionDate >= @BeginDate AND GLTransactionDate < @EndDate)"
                Dim GetBegDebitBalance2Command As New SqlCommand(GetBegDebitBalance2Statement, con)
                GetBegDebitBalance2Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BegFiscalDate
                GetBegDebitBalance2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = BeginDate
                GetBegDebitBalance2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetBegDebitBalance2Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLBegDebitTotal2 = CDbl(GetBegDebitBalance2Command.ExecuteScalar)
                Catch ex As Exception
                    GLBegDebitTotal2 = 0
                End Try
                con.Close()

                'Write Data to temp table
                cmd = New SqlCommand("Insert INTO GLTempDebitBeginning(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID, Locked) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID, @Locked)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLDebitAmount", SqlDbType.VarChar).Value = GLBegDebitTotal2
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Dim GetBegCreditBalance2Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchiveData + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND (GLTransactionDate >= @BeginDate AND GLTransactionDate < @EndDate)"
                Dim GetBegCreditBalance2Command As New SqlCommand(GetBegCreditBalance2Statement, con)
                GetBegCreditBalance2Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BegFiscalDate
                GetBegCreditBalance2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = BeginDate
                GetBegCreditBalance2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetBegCreditBalance2Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLBegCreditTotal2 = CDbl(GetBegCreditBalance2Command.ExecuteScalar)
                Catch ex As Exception
                    GLBegCreditTotal2 = 0
                End Try
                con.Close()

                'Write Data to temp table
                cmd = New SqlCommand("Insert INTO GLTempCreditBeginning(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLBegCreditTotal2
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*************************************************************************************************************************************************
                'Get Current Balance
                Dim CurrentDebitBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchiveData + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
                Dim CurrentDebitBalanceCommand As New SqlCommand(CurrentDebitBalanceStatement, con)
                CurrentDebitBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                CurrentDebitBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                CurrentDebitBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CurrentDebitBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLCurrentDebitTotal = CDbl(CurrentDebitBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    GLCurrentDebitTotal = 0
                End Try
                con.Close()

                'Write Data to temp table
                cmd = New SqlCommand("Insert INTO GLTempDebitRange(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLDebitAmount", SqlDbType.VarChar).Value = GLCurrentDebitTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Dim CurrentCreditBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchiveData + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
                Dim CurrentCreditBalanceCommand As New SqlCommand(CurrentCreditBalanceStatement, con)
                CurrentCreditBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                CurrentCreditBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                CurrentCreditBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CurrentCreditBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GLCurrentCreditTotal = CDbl(CurrentCreditBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    GLCurrentCreditTotal = 0
                End Try
                con.Close()

                'Write Data to temp table
                cmd = New SqlCommand("Insert INTO GLTempCreditRange(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCurrentCreditTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***********************************************************************************************************************************************************
                GLEndDebitTotal = GLBegDebitTotal2 + GLCurrentDebitTotal
                GLEndCreditTotal = GLBegCreditTotal2 + GLCurrentCreditTotal

                'Write Data to temp table
                cmd = New SqlCommand("Insert INTO GLTempDebitEnding(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLDebitAmount", SqlDbType.VarChar).Value = GLEndDebitTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                cmd = New SqlCommand("Insert INTO GLTempCreditEnding(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpValuationDate.Value
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                    .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLEndCreditTotal
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next

        'Calculate Retained Earnings
        CalculateRetainedEarnings()

        'Write Data to temp table
        cmd = New SqlCommand("Insert INTO GLTempDebitBeginning(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID, Locked) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID, @Locked)", con)

        With cmd.Parameters
            .Add("@TransactionDate", SqlDbType.VarChar).Value = BeginDate
            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "39500"
            .Add("@GlDebitAmount", SqlDbType.VarChar).Value = RetainedEarnings
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Write Data to temp table
        cmd = New SqlCommand("Insert INTO GLTempDebitEnding(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

        With cmd.Parameters
            .Add("@TransactionDate", SqlDbType.VarChar).Value = BeginDate
            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "39500"
            .Add("@GlDebitAmount", SqlDbType.VarChar).Value = RetainedEarnings
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        unlockBatch()

        MsgBox("GL Valuation completed. You may now view data.", MsgBoxStyle.OkOnly)
        cmdBalances2.Enabled = True
    End Sub

    Private Sub cmdBalances2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBalances2.Click
        If chkNonZero.Checked = True Then
            ShowValuationDataNonZero()
        Else
            ShowValuationData()
        End If
    End Sub

    Private Sub dtpValuationDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpValuationDate.ValueChanged
        ValuationDate = dtpValuationDate.Value
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds1
        Using NewPrintGLWTB As New PrintGLWTB
            Dim Result = NewPrintGLWTB.ShowDialog()
        End Using
    End Sub

    Private Sub PrintWTBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintWTBToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds1
        Using NewPrintGLWTB As New PrintGLWTB
            Dim Result = NewPrintGLWTB.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearValuationData()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearValuationData()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Function isSomeoneEditing() As Boolean
        cmd = New SqlCommand("SELECT Locked FROM GLTempDebitBeginning", con)
        Dim personEditing As String = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.GetValue(0)) Then
                personEditing = reader.GetValue(0)
            End If
        End If
        reader.Close()
        con.Close()

        If Not personEditing.Equals("NONE") And Not String.IsNullOrEmpty(personEditing) Then
            If Not personEditing.Equals(EmployeeLoginName) Then
                MessageBox.Show(personEditing + " is currently editing this batch. You are unable to make any changes.", "Unable to save/Post", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub LockBatch()
        cmd = New SqlCommand("UPDATE GLTempDebitBeginning SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch()
        cmd = New SqlCommand("UPDATE GLTempDebitBeginning SET Locked = ''", con)
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub chkArchiveData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkArchiveData.CheckedChanged
        If chkArchiveData.Checked = True Then
            'Get Last Archive Date
            Dim LastDate As Date

            Dim LastDateStatement As String = "SELECT MAX(GLTransactionDate) FROM GLTransactionMasterListArchive WHERE DivisionID = @DivisionID"
            Dim LastDateCommand As New SqlCommand(LastDateStatement, con)
            LastDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastDate = CDate(LastDateCommand.ExecuteScalar)
            Catch ex As Exception
                LastDate = "1/1/1900"
            End Try
            con.Close()

            txtLastArchiveDate.Text = LastDate
        Else
            'Do nothing
            txtLastArchiveDate.Clear()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearValuationData()
    End Sub
End Class