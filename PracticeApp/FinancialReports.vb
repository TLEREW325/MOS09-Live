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
Public Class FinancialReports
    Inherits System.Windows.Forms.Form

    Dim SumIncomeCredits, SumIncomeDebits, SumIncomeBalance, SumExpenseCredits, SumExpenseDebits, SumExpenseBalance, SumCOGSCredits, SumCOGSDebits, SumCOGSBalance, SumTaxCredits, SumTaxDebits, SumTaxBalance, SumOtherCredits, SumOtherDebits, SumOtherBalance, NetIncome As Double

    Dim CurrentMonth As String = ""
    Dim SalesBeginDate, SalesEndDate As String
    Dim ValidMonth As String = ""
    Dim YearString As String = ""
    Dim BeginFiscalYear, EndFiscalYear As String
    Dim BeginFiscalDate, EndFiscalDate As String

    'Trial Balance Variables
    Dim BeginDate, YearDate, MonthDate, ValuationDate As Date
    Dim YearOfYear, MonthOfYear, Year, intFiscalYear As Integer
    Dim strMonthOfYear, strYear, FiscalBeginDate, FiscalBeginYear As String
    Dim RetainedEarnings, DebitREBalance, CreditREBalance As Double

    'Set up variables and database connection
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub FinancialReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
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

    Public Sub LoadInventoryData()
        Dim PartNumber, PartDescription, TransactionDate, GLAccount As String
        Dim Quantity, ItemCost, ExtendedCost As Double

        'Delete Temp Tables
        cmd = New SqlCommand("Delete FROM InventoryValuationTempADD WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        cmd = New SqlCommand("Delete FROM InventoryValuationTempSUBTRACT WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Retrieve line data from Inventory Transaction Table
        For Each row As DataGridViewRow In dgvInventoryTransactions.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("TransactionMathColumn")

            If cell.Value = "ADD" Then
                Try
                    PartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = row.Cells("PartDescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    Quantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    Quantity = 0
                End Try
                Try
                    ItemCost = row.Cells("ItemCostColumn").Value
                Catch ex As Exception
                    ItemCost = 0
                End Try
                Try
                    ExtendedCost = row.Cells("ExtendedCostColumn").Value
                Catch ex As Exception
                    ExtendedCost = 0
                End Try
                Try
                    TransactionDate = row.Cells("TransactionDateColumn").Value
                Catch ex As Exception
                    TransactionDate = ""
                End Try
                Try
                    GLAccount = row.Cells("GLAccountColumn").Value
                Catch ex As Exception
                    GLAccount = "12100"
                End Try

                'Write ADD Data to Temp Table
                cmd = New SqlCommand("INSERT INTO InventoryValuationTempADD (PartNumber, PartDescription, Quantity, Cost, ExtendedCost, Date, DivisionID, GLAccount)values(@PartNumber, @PartDescription, @Quantity, @Cost, @ExtendedCost, @Date, @DivisionID, @GLAccount)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                    .Add("@Cost", SqlDbType.VarChar).Value = ItemCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedCost
                    .Add("@Date", SqlDbType.VarChar).Value = TransactionDate
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

            ElseIf cell.Value = "SUBTRACT" Then
                Try
                    PartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = row.Cells("PartDescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    Quantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    Quantity = 0
                End Try
                Try
                    ItemCost = row.Cells("ItemCostColumn").Value
                Catch ex As Exception
                    ItemCost = 0
                End Try
                Try
                    ExtendedCost = row.Cells("ExtendedCostColumn").Value
                Catch ex As Exception
                    ExtendedCost = 0
                End Try
                Try
                    TransactionDate = row.Cells("TransactionDateColumn").Value
                Catch ex As Exception
                    TransactionDate = ""
                End Try
                Try
                    GLAccount = row.Cells("GLAccountColumn").Value
                Catch ex As Exception
                    GLAccount = "12100"
                End Try

                'Write SUBTRACT Data to Temp Table
                cmd = New SqlCommand("INSERT INTO InventoryValuationTempSUBTRACT (PartNumber, PartDescription, Quantity, Cost, ExtendedCost, Date, DivisionID, GLAccount)values(@PartNumber, @PartDescription, @Quantity, @Cost, @ExtendedCost, @Date, @DivisionID, @GLAccount)", con)

                With cmd.Parameters
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                    .Add("@Cost", SqlDbType.VarChar).Value = ItemCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedCost
                    .Add("@Date", SqlDbType.VarChar).Value = TransactionDate
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'Do nothing
            End If
        Next
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND TransactionDate <= @ValuationDate AND Quantity <> 0", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ValuationDate", SqlDbType.VarChar).Value = dtpInventorySelectDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryTransactionTable")
        dgvInventoryTransactions.DataSource = ds.Tables("InventoryTransactionTable")
        con.Close()
    End Sub

    Public Sub ShowInventoryValue()
        cmd = New SqlCommand("SELECT * FROM InventoryValuationSummary WHERE DivisionID = @DivisionID AND NetQuantity <> 0", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "InventoryValuationSummary")
        dgvValuationSummary.DataSource = ds1.Tables("InventoryValuationSummary")
        con.Close()
    End Sub

    Public Sub ShowDataTB()
        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID AND GLTransactionStatus = @GLTransactionStatus", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLTransactionMasterListQuery")
        dgvGLTransactions.DataSource = ds2.Tables("GLTransactionMasterListQuery")
        con.Close()
    End Sub

    Public Sub ClearDataTB()
        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID AND GLTransactionStatus = @GLTransactionStatus", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "NONE"
        cmd.Parameters.Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLTransactionMasterListQuery")
        dgvGLTransactions.DataSource = ds2.Tables("GLTransactionMasterListQuery")
        con.Close()
    End Sub

    Public Sub ShowDataByBeginDateTB()
        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID AND GLTransactionDate < @BeginDate AND GLTransactionStatus = @GLTransactionStatus", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLTransactionMasterListQuery")
        dgvGLTransactions.DataSource = ds2.Tables("GLTransactionMasterListQuery")
        con.Close()
    End Sub

    Public Sub ShowDataByEndDateTB()
        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID AND GLTransactionDate <= @ValuationDate AND GLTransactionStatus = @GLTransactionStatus", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ValuationDate", SqlDbType.VarChar).Value = dtpTrialBalanceSelectDate.Text
        cmd.Parameters.Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLTransactionMasterListQuery")
        dgvGLTransactions.DataSource = ds2.Tables("GLTransactionMasterListQuery")
        con.Close()
    End Sub

    Public Sub ShowDataDateRangeTB()
        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID AND GLTransactionStatus = @GLTransactionStatus AND GLTransactionDate BETWEEN @BeginDate AND @ValuationDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@ValuationDate", SqlDbType.VarChar).Value = dtpTrialBalanceSelectDate.Text
        cmd.Parameters.Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLTransactionMasterListQuery")
        dgvGLTransactions.DataSource = ds2.Tables("GLTransactionMasterListQuery")
        con.Close()
    End Sub

    Public Sub ShowValuationDataTB()
        cmd = New SqlCommand("SELECT * FROM GLTransactionValuationFinal", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLTransactionValuationFinal")
        dgvGLValuation.DataSource = ds3.Tables("GLTransactionValuationFinal")
        con.Close()
    End Sub

    Public Sub ShowValuationDataNonZeroTB()
        cmd = New SqlCommand("SELECT * FROM GLTransactionValuationFinal WHERE (BeginningBalance > 0) OR (Debits > 0) OR (Credits > 0) OR (EndingBalance > 0) OR (BeginningBalance < 0) OR (Debits < 0) OR (Credits < 0) OR (EndingBalance < 0)", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLTransactionValuationFinal")
        dgvGLValuation.DataSource = ds3.Tables("GLTransactionValuationFinal")
        con.Close()
    End Sub

    Public Sub ClearValuationDataTB()
        cmd = New SqlCommand("SELECT * FROM GLTransactionValuationFinal WHERE GLAccountNumber = @GLAccountNumber", con)
        cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLTransactionValuationFinal")
        dgvGLValuation.DataSource = ds3.Tables("GLTransactionValuationFinal")
        con.Close()
    End Sub

    Public Sub CalculateRetainedEarnings()
        'Calculate Beginning Date to value
        ValuationDate = dtpTrialBalanceSelectDate.Text
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

        Dim DebitREBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterListQuery WHERE GLAccountCashFlowCode = @GLAccountCashFlowCode AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim DebitREBalanceCommand As New SqlCommand(DebitREBalanceStatement, con)
        DebitREBalanceCommand.Parameters.Add("@GLAccountCashFlowCode", SqlDbType.VarChar).Value = "IncomeStatement"
        DebitREBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = FiscalBeginDate
        DebitREBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditREBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterListQuery WHERE GLAccountCashFlowCode = @GLAccountCashFlowCode AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
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

    Private Sub cmdIncomeStatement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIncomeStatement.Click
        If rdoStandard.Checked = True Then
            'Delete select date in table for this division
            cmd = New SqlCommand("DELETE FROM GLIncomeStatementTempSelectDate WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Enter new select date into temp table
            cmd = New SqlCommand("INSERT INTO GLIncomeStatementTempSelectDate (DivisionID, SelectDate)values (@DivisionID, @SelectDate)", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@SelectDate", SqlDbType.VarChar).Value = dtpIncomeSelectDate.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            GlobalSelectDate = dtpIncomeSelectDate.Text
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintIncomeStatement As New PrintIncomeStatement
                Dim Result = NewPrintIncomeStatement.ShowDialog()
            End Using
        Else
            'Delete select date in table for this division
            cmd = New SqlCommand("DELETE FROM GLIncomeStatementTempSelectDate WHERE DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Enter new select date into temp table
            cmd = New SqlCommand("INSERT INTO GLIncomeStatementTempSelectDate (DivisionID, SelectDate)values (@DivisionID, @SelectDate)", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@SelectDate", SqlDbType.VarChar).Value = dtpIncomeSelectDate.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            GlobalSelectDate = dtpIncomeSelectDate.Text
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintIncomeStatement2Year As New PrintIncomeStatement2Year
                Dim Result = NewPrintIncomeStatement2Year.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdPrintBalanceSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintBalanceSheet.Click
        'Get Retained Earning for the period up to the select date
        Dim SumIncomeCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLIncomeStatementStage1 WHERE DivisionID = @DivisionID AND GLAccountTypeID = @GLAccountTypeID AND GLTransactionDate <= @GLTransactionDate"
        Dim SumIncomeCreditsCommand As New SqlCommand(SumIncomeCreditsStatement, con)
        SumIncomeCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumIncomeCreditsCommand.Parameters.Add("@GLAccountTypeID", SqlDbType.VarChar).Value = "1001"
        SumIncomeCreditsCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBalanceSheetSelectDate.Text

        Dim SumIncomeDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLIncomeStatementStage1 WHERE DivisionID = @DivisionID AND GLAccountTypeID = @GLAccountTypeID AND GLTransactionDate <= @GLTransactionDate"
        Dim SumIncomeDebitsCommand As New SqlCommand(SumIncomeDebitsStatement, con)
        SumIncomeDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumIncomeDebitsCommand.Parameters.Add("@GLAccountTypeID", SqlDbType.VarChar).Value = "1001"
        SumIncomeDebitsCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBalanceSheetSelectDate.Text

        Dim SumExpenseCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLIncomeStatementStage1 WHERE DivisionID = @DivisionID AND GLAccountTypeID = @GLAccountTypeID AND GLTransactionDate <= @GLTransactionDate"
        Dim SumExpenseCreditsCommand As New SqlCommand(SumExpenseCreditsStatement, con)
        SumExpenseCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumExpenseCreditsCommand.Parameters.Add("@GLAccountTypeID", SqlDbType.VarChar).Value = "1003"
        SumExpenseCreditsCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBalanceSheetSelectDate.Text

        Dim SumExpenseDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLIncomeStatementStage1 WHERE DivisionID = @DivisionID AND GLAccountTypeID = @GLAccountTypeID AND GLTransactionDate <= @GLTransactionDate"
        Dim SumExpenseDebitsCommand As New SqlCommand(SumExpenseDebitsStatement, con)
        SumExpenseDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumExpenseDebitsCommand.Parameters.Add("@GLAccountTypeID", SqlDbType.VarChar).Value = "1003"
        SumExpenseDebitsCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBalanceSheetSelectDate.Text

        Dim SumCOGSCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLIncomeStatementStage1 WHERE DivisionID = @DivisionID AND GLAccountTypeID = @GLAccountTypeID AND GLTransactionDate <= @GLTransactionDate"
        Dim SumCOGSCreditsCommand As New SqlCommand(SumCOGSCreditsStatement, con)
        SumCOGSCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumCOGSCreditsCommand.Parameters.Add("@GLAccountTypeID", SqlDbType.VarChar).Value = "1002"
        SumCOGSCreditsCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBalanceSheetSelectDate.Text

        Dim SumCOGSDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLIncomeStatementStage1 WHERE DivisionID = @DivisionID AND GLAccountTypeID = @GLAccountTypeID AND GLTransactionDate <= @GLTransactionDate"
        Dim SumCOGSDebitsCommand As New SqlCommand(SumCOGSDebitsStatement, con)
        SumCOGSDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumCOGSDebitsCommand.Parameters.Add("@GLAccountTypeID", SqlDbType.VarChar).Value = "1002"
        SumCOGSDebitsCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBalanceSheetSelectDate.Text

        Dim SumTaxCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLIncomeStatementStage1 WHERE DivisionID = @DivisionID AND GLAccountTypeID = @GLAccountTypeID AND GLTransactionDate <= @GLTransactionDate"
        Dim SumTaxCreditsCommand As New SqlCommand(SumTaxCreditsStatement, con)
        SumTaxCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumTaxCreditsCommand.Parameters.Add("@GLAccountTypeID", SqlDbType.VarChar).Value = "1005"
        SumTaxCreditsCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBalanceSheetSelectDate.Text

        Dim SumTaxDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLIncomeStatementStage1 WHERE DivisionID = @DivisionID AND GLAccountTypeID = @GLAccountTypeID AND GLTransactionDate <= @GLTransactionDate"
        Dim SumTaxDebitsCommand As New SqlCommand(SumTaxDebitsStatement, con)
        SumTaxDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumTaxDebitsCommand.Parameters.Add("@GLAccountTypeID", SqlDbType.VarChar).Value = "1005"
        SumTaxDebitsCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBalanceSheetSelectDate.Text

        Dim SumOtherCreditsStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLIncomeStatementStage1 WHERE DivisionID = @DivisionID AND GLAccountTypeID = @GLAccountTypeID AND GLTransactionDate <= @GLTransactionDate"
        Dim SumOtherCreditsCommand As New SqlCommand(SumOtherCreditsStatement, con)
        SumOtherCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumOtherCreditsCommand.Parameters.Add("@GLAccountTypeID", SqlDbType.VarChar).Value = "1004"
        SumOtherCreditsCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBalanceSheetSelectDate.Text

        Dim SumOtherDebitsStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLIncomeStatementStage1 WHERE DivisionID = @DivisionID AND GLAccountTypeID = @GLAccountTypeID AND GLTransactionDate <= @GLTransactionDate"
        Dim SumOtherDebitsCommand As New SqlCommand(SumOtherDebitsStatement, con)
        SumOtherDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumOtherDebitsCommand.Parameters.Add("@GLAccountTypeID", SqlDbType.VarChar).Value = "1004"
        SumOtherDebitsCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBalanceSheetSelectDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumIncomeCredits = CDbl(SumIncomeCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumIncomeCredits = 0
        End Try
        Try
            SumIncomeDebits = CDbl(SumIncomeDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumIncomeDebits = 0
        End Try
        Try
            SumExpenseDebits = CDbl(SumExpenseDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumExpenseDebits = 0
        End Try
        Try
            SumExpenseCredits = CDbl(SumExpenseCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumExpenseCredits = 0
        End Try
        Try
            SumCOGSDebits = CDbl(SumCOGSDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumCOGSDebits = 0
        End Try
        Try
            SumCOGSCredits = CDbl(SumCOGSCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumCOGSCredits = 0
        End Try
        Try
            SumTaxDebits = CDbl(SumTaxDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumTaxDebits = 0
        End Try
        Try
            SumTaxCredits = CDbl(SumTaxCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumTaxCredits = 0
        End Try
        Try
            SumOtherDebits = CDbl(SumOtherDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumOtherDebits = 0
        End Try
        Try
            SumOtherCredits = CDbl(SumOtherCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumOtherCredits = 0
        End Try
        con.Close()

        SumIncomeBalance = SumIncomeCredits - SumIncomeDebits
        SumExpenseBalance = SumExpenseDebits - SumExpenseCredits
        SumCOGSBalance = SumCOGSDebits - SumCOGSCredits
        SumTaxBalance = SumTaxDebits - SumTaxCredits
        SumOtherBalance = SumOtherDebits - SumOtherCredits

        NetIncome = SumIncomeBalance - (SumExpenseBalance + SumCOGSBalance + SumTaxBalance + SumOtherBalance)

        'Delete select date in table for this division
        cmd = New SqlCommand("DELETE FROM GLBalanceSheetTempSelectDate WHERE DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Enter new select date into temp table
        cmd = New SqlCommand("INSERT INTO GLBalanceSheetTempSelectDate (DivisionID, SelectDate, RetainedEarnings)values (@DivisionID, @SelectDate, @RetainedEarnings)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@SelectDate", SqlDbType.VarChar).Value = dtpBalanceSheetSelectDate.Text
            .Add("@RetainedEarnings", SqlDbType.VarChar).Value = NetIncome
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        GlobalDivisionCode = cboDivisionID.Text
        GlobalSelectDate = dtpBalanceSheetSelectDate.Text

        Using newPrintBalanceSheet As New PrintBalanceSheet
            Dim Result = newPrintBalanceSheet.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdInventoryValuation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInventoryValuation.Click
        ShowData()
        LoadInventoryData()
        ShowInventoryValue()

        GlobalDivisionCode = cboDivisionID.Text
        GlobalValuationDate = dtpInventorySelectDate.Text

        Using NewPrintInventoryValuationByGL As New PrintInventoryValuationByGL
            Dim result = NewPrintInventoryValuationByGL.ShowDialog()
        End Using
    End Sub

    Private Sub cmdAgedPayables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgedPayables.Click
        Using NewAPAgedPayablesDated As New APAgedPayablesDated
            Dim Result = NewAPAgedPayablesDated.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrintInvoiceLinesReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintInvoiceLinesReport.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintUnpostedInvoices As New PrintUnpostedInvoices
            Dim result = NewPrintUnpostedInvoices.ShowDialog()
        End Using
    End Sub

    Private Sub cmdTestOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTestOpenFile.Click
        Using ofd As New OpenFileDialog
            ofd.InitialDirectory = "C:\TransferData\TruweldPackList"
            ofd.Filter = "pdf files (*.pdf)|*.pdf"
            ofd.ShowDialog()
        End Using
    End Sub

    Private Sub cmdAgedReceivables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgedReceivables.Click
        Using NewARAgedReceivablesDated As New ARAgedReceivablesDated
            Dim Result = NewARAgedReceivablesDated.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrintTrialBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintTrialBalance.Click
        'Calculate Beginning Date to value
        ValuationDate = dtpTrialBalanceSelectDate.Text
        MonthDate = ValuationDate
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        'Convert text to dates to compare
        Dim CVFiscalBeginDate, CVGLDate As Date

        'Apply Filter into dataset
        ShowDataByBeginDateTB()

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempDebitBeginning", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Extract Data from filtered dataset to write to temp table
        For Each row As DataGridViewRow In dgvGLTransactions.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("GLDebitAmountColumn")

            If cell.Value <> 0 Then
                Dim GLAccount As String = row.Cells("GLAccountNumberColumn").Value
                Dim GLDebitAmount = row.Cells("GLDebitAmountColumn").Value
                Dim GLDate As String = row.Cells("GLTransactionDateColumn").Value
                Dim GLAccountType As String = row.Cells("GLAccountCashFlowCodeColumn").Value

                'Check account type to determine if value should be written (IS Account / BS Account)
                If GLAccountType = "BalanceSheet" Then
                    'Write Data to temp table
                    cmd = New SqlCommand("Insert INTO GLTempDebitBeginning(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                        .Add("@GlDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf GLAccountType = "IncomeStatement" Then
                    'Get Date Range to beginning of the fiscal year only
                    If MonthOfYear < 5 Then
                        intFiscalYear = MonthDate.Year - 1
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLDebitAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert INTO GLTempDebitBeginning(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GlDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Else
                        intFiscalYear = MonthDate.Year
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLDebitAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert INTO GLTempDebitBeginning(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GlDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    End If
                Else
                    'Account is neither - skip
                End If
            End If
        Next

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempCreditBeginning", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Extract Data from filtered dataset to write to temp table
        For Each row As DataGridViewRow In dgvGLTransactions.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("GLCreditAmountColumn")

            If cell.Value <> 0 Then
                Dim GLAccount As String = row.Cells("GLAccountNumberColumn").Value
                Dim GLCreditAmount = row.Cells("GLCreditAmountColumn").Value
                Dim GLDate As String = row.Cells("GLTransactionDateColumn").Value
                Dim GLAccountType As String = row.Cells("GLAccountCashFlowCodeColumn").Value

                'Check account type to determine if value should be written (IS Account / BS Account)
                If GLAccountType = "BalanceSheet" Then
                    'Write Data to temp table
                    cmd = New SqlCommand("Insert INTO GLTempCreditBeginning(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                        .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf GLAccountType = "IncomeStatement" Then
                    'Get Date Range to beginning of the fiscal year only
                    If MonthOfYear < 5 Then
                        intFiscalYear = MonthDate.Year - 1
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLCreditAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert INTO GLTempCreditBeginning(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Else
                        intFiscalYear = MonthDate.Year
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLCreditAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert INTO GLTempCreditBeginning(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    End If
                Else
                    'Account is neither - skip
                End If
            End If
        Next

        'Apply Filter into dataset
        ShowDataByEndDateTB()

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempDebitEnding", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Extract Data from filtered dataset to write to temp table
        For Each row As DataGridViewRow In dgvGLTransactions.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("GLDebitAmountColumn")

            If cell.Value <> 0 Then
                Dim GLAccount As String = row.Cells("GLAccountNumberColumn").Value
                Dim GLDebitAmount = row.Cells("GLDebitAmountColumn").Value
                Dim GLDate As String = row.Cells("GLTransactionDateColumn").Value
                Dim GLAccountType As String = row.Cells("GLAccountCashFlowCodeColumn").Value

                'Check account type to determine if value should be written (IS Account / BS Account)
                If GLAccountType = "BalanceSheet" Then
                    'Write Data to temp table
                    cmd = New SqlCommand("Insert INTO GLTempDebitEnding(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                        .Add("@GlDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf GLAccountType = "IncomeStatement" Then
                    'Get Date Range to beginning of the fiscal year only
                    If MonthOfYear < 5 Then
                        intFiscalYear = MonthDate.Year - 1
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLDebitAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert INTO GLTempDebitEnding(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GlDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Else
                        intFiscalYear = MonthDate.Year
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLDebitAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert INTO GLTempDebitEnding(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GlDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    End If
                Else
                    'Account is neither - skip
                End If
            End If
        Next

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempCreditEnding", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Extract Data from filtered dataset to write to temp table
        For Each row As DataGridViewRow In dgvGLTransactions.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("GLCreditAmountColumn")

            If cell.Value <> 0 Then
                Dim GLAccount As String = row.Cells("GLAccountNumberColumn").Value
                Dim GLCreditAmount = row.Cells("GLCreditAmountColumn").Value
                Dim GLDate As String = row.Cells("GLTransactionDateColumn").Value
                Dim GLAccountType As String = row.Cells("GLAccountCashFlowCodeColumn").Value

                'Check account type to determine if value should be written (IS Account / BS Account)
                If GLAccountType = "BalanceSheet" Then
                    'Write Data to temp table
                    cmd = New SqlCommand("Insert GLTempCreditEnding(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                        .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf GLAccountType = "IncomeStatement" Then
                    'Get Date Range to beginning of the fiscal year only
                    If MonthOfYear < 5 Then
                        intFiscalYear = MonthDate.Year - 1
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLCreditAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert GLTempCreditEnding(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Else
                        intFiscalYear = MonthDate.Year
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLCreditAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert GLTempCreditEnding(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    End If
                Else
                    'Account is neither - skip
                End If
            End If
        Next

        'Apply Filter into dataset
        ShowDataDateRangeTB()

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempDebitRange", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Extract Data from filtered dataset to write to temp table
        For Each row As DataGridViewRow In dgvGLTransactions.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("GLDebitAmountColumn")

            If cell.Value <> 0 Then
                Dim GLAccount As String = row.Cells("GLAccountNumberColumn").Value
                Dim GLDebitAmount = row.Cells("GLDebitAmountColumn").Value
                Dim GLDate As String = row.Cells("GLTransactionDateColumn").Value
                Dim GLAccountType As String = row.Cells("GLAccountCashFlowCodeColumn").Value

                'Check account type to determine if value should be written (IS Account / BS Account)
                If GLAccountType = "BalanceSheet" Then
                    'Write Data to temp table
                    cmd = New SqlCommand("Insert GLTempDebitRange(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                        .Add("@GlDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf GLAccountType = "IncomeStatement" Then
                    'Get Date Range to beginning of the fiscal year only
                    If MonthOfYear < 5 Then
                        intFiscalYear = MonthDate.Year - 1
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLDebitAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert GLTempDebitRange(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GlDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Else
                        intFiscalYear = MonthDate.Year
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLDebitAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert GLTempDebitRange(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GlDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    End If
                Else
                    'Account is neither - skip
                End If
            End If
        Next

        'Delete Temp Table
        cmd = New SqlCommand("Delete From GLTempCreditRange", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Extract Data from filtered dataset to write to temp table
        For Each row As DataGridViewRow In dgvGLTransactions.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("GLCreditAmountColumn")

            If cell.Value <> 0 Then
                Dim GLAccount As String = row.Cells("GLAccountNumberColumn").Value
                Dim GLCreditAmount = row.Cells("GLCreditAmountColumn").Value
                Dim GLDate As String = row.Cells("GLTransactionDateColumn").Value
                Dim GLAccountType As String = row.Cells("GLAccountCashFlowCodeColumn").Value

                'Check account type to determine if value should be written (IS Account / BS Account)
                If GLAccountType = "BalanceSheet" Then
                    'Write Data to temp table
                    cmd = New SqlCommand("Insert GLTempCreditRange(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                        .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf GLAccountType = "IncomeStatement" Then
                    'Get Date Range to beginning of the fiscal year only
                    If MonthOfYear < 5 Then
                        intFiscalYear = MonthDate.Year - 1
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLCreditAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert GLTempCreditRange(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Else
                        intFiscalYear = MonthDate.Year
                        FiscalBeginYear = Str(intFiscalYear)
                        FiscalBeginDate = "05/01/" + FiscalBeginYear

                        CVGLDate = CDate(GLDate)
                        CVFiscalBeginDate = CDate(FiscalBeginDate)

                        If CVGLDate < CVFiscalBeginDate Then
                            GLCreditAmount = 0
                        Else
                            'Write Data to temp table
                            cmd = New SqlCommand("Insert GLTempCreditRange(TransactionDate, GLAccountNumber, GLCreditAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLCreditAmount, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@TransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccount
                                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    End If
                Else
                    'Account is neither - skip
                End If
            End If
        Next

        'Calculate Retained Earnings
        CalculateRetainedEarnings()

        'Write Data to temp table
        cmd = New SqlCommand("Insert INTO GLTempDebitBeginning(TransactionDate, GLAccountNumber, GLDebitAmount, DivisionID) Values (@TransactionDate, @GLAccountNumber, @GLDebitAmount, @DivisionID)", con)

        With cmd.Parameters
            .Add("@TransactionDate", SqlDbType.VarChar).Value = BeginDate
            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "39500"
            .Add("@GlDebitAmount", SqlDbType.VarChar).Value = RetainedEarnings
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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

        If chkNonZero.Checked = True Then
            ShowValuationDataNonZeroTB()
        Else
            ShowValuationDataTB()
        End If

        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds3
        Using NewPrintGLWTB As New PrintGLWTB
            Dim Result = NewPrintGLWTB.ShowDialog()
        End Using
    End Sub

    Public Sub DefineMonth()
        CurrentMonth = cboMonth.Text
        YearString = cboYear.Text

        Select Case CurrentMonth
            Case "January"
                SalesBeginDate = "01/01/" + YearString
                SalesEndDate = "01/31/" + YearString
                ValidMonth = "YES"
            Case "February"
                SalesBeginDate = "02/01/" + YearString
                SalesEndDate = "02/28/" + YearString
                ValidMonth = "YES"
            Case "March"
                SalesBeginDate = "03/01/" + YearString
                SalesEndDate = "03/31/" + YearString
                ValidMonth = "YES"
            Case "April"
                SalesBeginDate = "04/01/" + YearString
                SalesEndDate = "04/30/" + YearString
                ValidMonth = "YES"
            Case "May"
                SalesBeginDate = "05/01/" + YearString
                SalesEndDate = "05/31/" + YearString
                ValidMonth = "YES"
            Case "June"
                SalesBeginDate = "06/01/" + YearString
                SalesEndDate = "06/30/" + YearString
                ValidMonth = "YES"
            Case "July"
                SalesBeginDate = "07/01/" + YearString
                SalesEndDate = "07/31/" + YearString
                ValidMonth = "YES"
            Case "August"
                SalesBeginDate = "08/01/" + YearString
                SalesEndDate = "08/31/" + YearString
                ValidMonth = "YES"
            Case "September"
                SalesBeginDate = "09/01/" + YearString
                SalesEndDate = "09/30/" + YearString
                ValidMonth = "YES"
            Case "October"
                SalesBeginDate = "10/01/" + YearString
                SalesEndDate = "10/31/" + YearString
                ValidMonth = "YES"
            Case "November"
                SalesBeginDate = "11/01/" + YearString
                SalesEndDate = "11/30/" + YearString
                ValidMonth = "YES"
            Case "December"
                SalesBeginDate = "12/01/" + YearString
                SalesEndDate = "12/31/" + YearString
                ValidMonth = "YES"
            Case Else
                ValidMonth = "NO"
        End Select
    End Sub

    Public Sub DefineFiscalYear()
        Dim strFiscalYear As String = ""
        Dim FiscalYear As Integer = 0
        Dim CurrentYear As Integer = 0
        Dim StrCurrentMonth As String = ""
        Dim StrLastDayofMonth As String = ""
        Dim intCurrentMonth As Integer = 0

        CurrentMonth = cboMonth.Text
        CurrentYear = Val(cboYear.Text)

        Select Case CurrentMonth
            Case "January"
                intCurrentMonth = 1
                StrLastDayofMonth = "/31/"
            Case "February"
                intCurrentMonth = 2
                StrLastDayofMonth = "/28/"
            Case "March"
                intCurrentMonth = 3
                StrLastDayofMonth = "/31/"
            Case "April"
                intCurrentMonth = 4
                StrLastDayofMonth = "/30/"
            Case "May"
                intCurrentMonth = 5
                StrLastDayofMonth = "/31/"
            Case "June"
                intCurrentMonth = 6
                StrLastDayofMonth = "/30/"
            Case "July"
                intCurrentMonth = 7
                StrLastDayofMonth = "/31/"
            Case "August"
                intCurrentMonth = 8
                StrLastDayofMonth = "/31/"
            Case "September"
                intCurrentMonth = 9
                StrLastDayofMonth = "/30/"
            Case "October"
                intCurrentMonth = 10
                StrLastDayofMonth = "/31/"
            Case "November"
                intCurrentMonth = 11
                StrLastDayofMonth = "/30/"
            Case "December"
                intCurrentMonth = 12
                StrLastDayofMonth = "/31/"
            Case Else
                ValidMonth = "NO"
        End Select

        StrCurrentMonth = CStr(intCurrentMonth)

        If intCurrentMonth < 5 Then
            'Define Begin
            FiscalYear = CurrentYear - 1
            strFiscalYear = CStr(FiscalYear)

            BeginFiscalYear = strFiscalYear

            'Define End
            FiscalYear = CurrentYear
            strFiscalYear = CStr(FiscalYear)

            EndFiscalYear = strFiscalYear

            BeginFiscalDate = "05/01/" + BeginFiscalYear
            EndFiscalDate = StrCurrentMonth + StrLastDayofMonth + EndFiscalYear
        Else
            'Define Begin
            FiscalYear = CurrentYear
            strFiscalYear = CStr(FiscalYear)

            BeginFiscalYear = strFiscalYear

            'Define End
            FiscalYear = CurrentYear
            strFiscalYear = CStr(FiscalYear)

            EndFiscalYear = strFiscalYear

            BeginFiscalDate = "05/01/" + BeginFiscalYear
            EndFiscalDate = StrCurrentMonth + StrLastDayofMonth + EndFiscalYear
        End If
    End Sub

    Private Sub cmdReprintMonthReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintMonthReports.Click
        If rdoDailySales.Checked = True Then
            'Define month selected
            DefineMonth()

            'Filter Dataset
            cmd2 = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate BETWEEN @BeginDate AND @EndDate", con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd2.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            cmd2.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = SalesBeginDate
            cmd2.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = SalesEndDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds2, "InvoiceHeaderTable")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport2 = CRXInvoiceDailyTotalsMonth1
            MyReport2.SetDataSource(ds2)
            MyReport2.PrintToPrinter(1, True, 1, 999)
            con.Close()

            ds2 = Nothing
        ElseIf rdoConsignmentSales.Checked = True Then
            'Define month selected
            DefineMonth()

            'Filter Dataset
            cmd = New SqlCommand("SELECT * FROM ConsignmentBillingTable WHERE DivisionID = @DivisionID AND BillDate BETWEEN @BeginDate AND @EndDate", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = SalesBeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = SalesEndDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ConsignmentBillingTable")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXConsignmentBillingMonth1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)
            con.Close()

            ds = Nothing
        ElseIf rdoSalesByItemClass.Checked = True Then
            'Define Fiscal Year
            DefineFiscalYear()

            'Filter Dataset
            cmd3 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate BETWEEN @BeginDate AND @EndDate", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd3.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            cmd3.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginFiscalDate
            cmd3.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndFiscalDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds3, "InvoiceLineQuery")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport3 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport3 = CRXSalesByItemClass_TWDMonth1
            MyReport3.SetDataSource(ds3)
            MyReport3.PrintToPrinter(1, True, 1, 999) '
            con.Close()

            ds3 = Nothing
        ElseIf rdoSalesByState.Checked = True Then
            'Define Fiscal Year
            DefineFiscalYear()

            'Filter Dataset
            cmd4 = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID AND InvoiceDate BETWEEN @BeginDate AND @EndDate", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            cmd4.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginFiscalDate
            cmd4.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndFiscalDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds4, "InvoiceHeaderQuery")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport4 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport4 = CRXCustMTD_YTDInvoicesbyStateMonth1
            MyReport4.SetDataSource(ds4)
            MyReport4.PrintToPrinter(1, True, 1, 999) '
            con.Close()

            ds4 = Nothing
        ElseIf rdoSalesByTerritory.Checked = True Then
            'Define Fiscal Year
            DefineFiscalYear()

            'Filter Dataset
            cmd5 = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceDate BETWEEN @BeginDate AND @EndDate", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd5.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            cmd5.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginFiscalDate
            cmd5.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndFiscalDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds5 = New DataSet()
            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds5, "InvoiceHeaderQuery")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport5 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport5 = CRXCustMTD_YTDInvoicesbyTerritoryMonth1
            MyReport5.SetDataSource(ds5)
            MyReport5.PrintToPrinter(1, True, 1, 999) '
            con.Close()

            ds5 = Nothing
        Else
            'Do nothing
        End If
    End Sub
End Class