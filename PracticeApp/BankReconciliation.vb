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
Public Class BankReconciliation
    Inherits System.Windows.Forms.Form

    Dim SumClearedARBTCredits, SumClearedARBTDebits, SumClearedARCredits, SumClearedARDebits, BeginningClearedARBalance As Double
    Dim EndingStatmentBalance As Double = 0
    Dim APVariance, EndingOSAPBalance, BeginningOSAPBalance, SumAPCredits, SumAPDebits, SumAPBookBalance, SumOutstandingAPDebits, SumOutstandingAPCredits, SumClearedAPDebits, SumClearedAPCredits As Double
    Dim ARVariance, EndingOSARBalance, BeginningOSARBalance, SumARCredits, SumARDebits, SumARBookBalance, SumOutstandingARCredits, SumOutstandingARDebits As Double
    Dim NextBatchNumber, LastBatchNumber, LastTransactionNumber, NextTransactionNumber As Integer
    Dim SelectDate As Date
    Dim BeginDate, EndDate, strYear, StrMonth As String
    Dim intYear, intMonth, ReconciliationMonth As Integer
    Dim SumOutstandingARPayments As Double = 0

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myadapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub BankReconciliation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        'Set default for division and enable beginning inventory edits
        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        LoadBatchNumber()
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

    Public Sub ShowLines()
        cmd = New SqlCommand("SELECT * FROM BankReconciliationLineTable WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "BankReconciliationLineTable")
        dgvBankRec.DataSource = ds.Tables("BankReconciliationLineTable")
        con.Close()
    End Sub

    Public Sub LoadBatchNumber()
        cmd = New SqlCommand("SELECT BatchNumber FROM BankReconciliationBatchHeader WHERE DivisionID = @DivisionID ORDER BY BatchNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "BankReconciliationBatchHeader")
        cboBatchNumber.DataSource = ds1.Tables("BankReconciliationBatchHeader")
        con.Close()
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadARPaymentLog()
        cmd = New SqlCommand("SELECT * FROM ARPaymentLog WHERE DivisionID = @DivisionID AND PaymentStatus = @PaymentStatus AND PaymentDate <= @EndDate", con)
        cmd.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ARPaymentLog")
        dgvARPaymentLog.DataSource = ds2.Tables("ARPaymentLog")
        con.Close()
    End Sub

    Public Sub LoadAPCheckLog()
        cmd = New SqlCommand("SELECT * FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckStatus = @CheckStatus", con)
        cmd.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "APCheckLog")
        dgvAPCheckLog.DataSource = ds3.Tables("APCheckLog")
        con.Close()
    End Sub

    Public Sub LoadARBankTransaction()
        cmd = New SqlCommand("SELECT * FROM BankTransactions WHERE DivisionID = @DivisionID AND Status = @Status AND GLAccount = @GLAccount AND TransactionDate >= @EndDate", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@GLAccount", SqlDbType.VarChar).Value = "10400"
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "BankTransactions")
        dgvBankTransactions.DataSource = ds4.Tables("BankTransactions")
        con.Close()
    End Sub

    Public Sub LoadAPBankTransaction()
        cmd = New SqlCommand("SELECT * FROM BankTransactions WHERE DivisionID = @DivisionID AND Status = @Status AND GLAccount = @GLAccount", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@GLAccount", SqlDbType.VarChar).Value = "10200"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "BankTransactions")
        dgvBankTransactions.DataSource = ds5.Tables("BankTransactions")
        con.Close()
    End Sub

    Public Sub ClearData()
        cboBankAccount.Text = ""
        cboBatchNumber.Text = ""

        cboBankAccount.SelectedIndex = -1
        cboBatchNumber.SelectedIndex = -1

        txtBatchStatus.Clear()
        txtComment.Clear()
        txtEndingStatementBalance.Clear()

        lblBookBalance.Text = ""
        lblClearedCredits.Text = ""
        lblClearedDebits.Text = ""
        lblClearedEndingTotal.Text = ""
        lblClearedStatementBalance.Text = ""
        lblClearedSubtotal.Text = ""
        lblClearedVariance.Text = ""
        lblOSCredits.Text = ""
        lblOSDebits.Text = ""
        lblOSEndingTotal.Text = ""
        lblOSStatementBalance.Text = ""
        lblOSVariance.Text = ""

        dtpPostDate.Text = ""

        cmdGenerateNewBatch.Focus()
    End Sub

    Public Sub ClearVariables()

    End Sub

    Public Sub GetDateRange()
        SelectDate = dtpPostDate.Value

        'Find current year to calculate correct Begin, End Dates
        intMonth = SelectDate.Month
        ReconciliationMonth = intMonth
        intYear = SelectDate.Year
        strYear = CStr(intYear)

        'Determine Rec Month
        Select Case ReconciliationMonth
            Case 1
                BeginDate = "01/01/" + strYear
                EndDate = "01/31/" + strYear
            Case 2
                BeginDate = "02/01/" + strYear
                EndDate = "02/28/" + strYear
            Case 3
                BeginDate = "03/01/" + strYear
                EndDate = "03/31/" + strYear
            Case 4
                BeginDate = "04/01/" + strYear
                EndDate = "04/30/" + strYear
            Case 5
                BeginDate = "05/01/" + strYear
                EndDate = "05/31/" + strYear
            Case 6
                BeginDate = "06/01/" + strYear
                EndDate = "06/30/" + strYear
            Case 7
                BeginDate = "07/01/" + strYear
                EndDate = "07/31/" + strYear
            Case 8
                BeginDate = "08/01/" + strYear
                EndDate = "08/31/" + strYear
            Case 9
                BeginDate = "09/01/" + strYear
                EndDate = "09/30/" + strYear
            Case 10
                BeginDate = "10/01/" + strYear
                EndDate = "10/31/" + strYear
            Case 11
                BeginDate = "11/01/" + strYear
                EndDate = "11/30/" + strYear
            Case 12
                BeginDate = "12/01/" + strYear
                EndDate = "12/31/" + strYear
        End Select
    End Sub

    Public Sub LoadBookValueAR()
        Dim SumARCreditsString As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber"
        Dim SumARCreditsCommand As New SqlCommand(SumARCreditsString, con)
        SumARCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumARCreditsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10400"

        Dim SumARDebitsString As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber"
        Dim SumARDebitsCommand As New SqlCommand(SumARDebitsString, con)
        SumARDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumARDebitsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10400"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumARCredits = CDbl(SumARCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumARCredits = 0
        End Try
        Try
            SumARDebits = CDbl(SumARDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumARDebits = 0
        End Try
        con.Close()

        SumARBookBalance = SumARDebits - SumARCredits
        lblBookBalance.Text = FormatCurrency(SumARBookBalance, 2)
    End Sub

    Public Sub LoadAROutstanding()
        Dim BTCredit, BTDebit, ARCredit, ARDebit As Double

        Dim GetBTARCreditsString As String = "SELECT SUM(CreditAmount) FROM BankTransactions WHERE DivisionID = @DivisionID AND GLAccount = @GLAccount AND Status = @Status AND TRansactionDate <= @EndDate"
        Dim GetBTARCreditsCommand As New SqlCommand(GetBTARCreditsString, con)
        GetBTARCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetBTARCreditsCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"
        GetBTARCreditsCommand.Parameters.Add("@GLAccount", SqlDbType.VarChar).Value = "10400"
        GetBTARCreditsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim GetBTARDebitsString As String = "SELECT SUM(DebitAmount) FROM BankTransactions WHERE DivisionID = @DivisionID AND GLAccount = @GLAccount AND Status = @Status AND TRansactionDate <= @EndDate"
        Dim GetBTARDebitsCommand As New SqlCommand(GetBTARDebitsString, con)
        GetBTARDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetBTARDebitsCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"
        GetBTARDebitsCommand.Parameters.Add("@GLAccount", SqlDbType.VarChar).Value = "10400"
        GetBTARDebitsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BTCredit = CDbl(GetBTARCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            BTDebit = 0
        End Try
        Try
            BTDebit = CDbl(GetBTARDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            BTDebit = 0
        End Try
        con.Close()

        Dim SumOSARCreditsString As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE DivisionID = @DivisionID AND PaymentStatus = @PaymentStatus AND PaymentAmount < @PaymentAmount AND PaymentDate <= @EndDate"
        Dim SumOSARCreditsCommand As New SqlCommand(SumOSARCreditsString, con)
        SumOSARCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumOSARCreditsCommand.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = "POSTED"
        SumOSARCreditsCommand.Parameters.Add("@PaymentAmount", SqlDbType.VarChar).Value = 0
        SumOSARCreditsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim SumOSARDebitsString As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE DivisionID = @DivisionID AND PaymentStatus = @PaymentStatus AND PaymentAmount > @PaymentAmount AND PaymentDate <= @EndDate"
        Dim SumOSARDebitsCommand As New SqlCommand(SumOSARDebitsString, con)
        SumOSARDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumOSARDebitsCommand.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = "POSTED"
        SumOSARDebitsCommand.Parameters.Add("@PaymentAmount", SqlDbType.VarChar).Value = 0
        SumOSARDebitsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ARCredit = CDbl(SumOSARCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            ARCredit = 0
        End Try
        Try
            ARDebit = CDbl(SumOSARDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            ARDebit = 0
        End Try
        con.Close()

        SumOutstandingARCredits = ARCredit + BTCredit
        SumOutstandingARDebits = ARDebit + BTDebit

        lblOSCredits.Text = FormatCurrency(SumOutstandingARCredits, 2)
        lblOSDebits.Text = FormatCurrency(SumOutstandingARDebits, 2)
    End Sub

    Public Sub LoadAROutstandingTotals()
        EndingStatmentBalance = Val(txtEndingStatementBalance.Text)

        lblOSStatementBalance.Text = FormatCurrency(EndingStatmentBalance, 2)
        lblClearedEndingTotal.Text = FormatCurrency(EndingStatmentBalance, 2)

        EndingOSARBalance = SumOutstandingARPayments + SumOutstandingARDebits - SumOutstandingARCredits + EndingStatmentBalance
        lblOSEndingTotal.Text = FormatCurrency(EndingOSARBalance, 2)
        ARVariance = EndingOSARBalance - SumARBookBalance
        lblOSVariance.Text = FormatCurrency(ARVariance, 2)
    End Sub

    Private Sub dgvBankRec_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBankRec.CellValueChanged
        Dim CheckValue As String = ""
        Dim TransactionNumber As Integer = 0
        Dim TransactionType As String = ""

        If Me.dgvBankRec.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvBankRec.CurrentCell.RowIndex

            Try
                CheckValue = Me.dgvBankRec.Rows(RowIndex).Cells("SelectColumn").Value
            Catch ex As Exception
                CheckValue = "UNCHECKED"
            End Try
            Try
                TransactionNumber = Me.dgvBankRec.Rows(RowIndex).Cells("TransactionNumberColumn").Value
            Catch ex As Exception
                TransactionNumber = 0
            End Try
            Try
                TransactionType = Me.dgvBankRec.Rows(RowIndex).Cells("TransactionTypeColumn").Value
            Catch ex As Exception
                TransactionType = cboBankAccount.Text
            End Try

            If CheckValue = "CHECKED" Then
                'Update Batch Data in the temp table
                cmd = New SqlCommand("UPDATE BankReconciliationLineTable SET Status = @Status WHERE BatchNumber = @BatchNumber AND TransactionNumber = @TransactionNumber", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                    .Add("@Status", SqlDbType.VarChar).Value = "PENDING"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If TransactionType = "Cash Receipt" Then
                    'Update Batch Data in the temp table
                    cmd = New SqlCommand("UPDATE ARPaymentLog SET PaymentStatus = @PaymentStatus WHERE PaymentID = @PaymentID AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PaymentID", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PaymentStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf TransactionType = "Checking" Then
                    'Update Batch Data in the temp table
                    cmd = New SqlCommand("UPDATE APCheckLog SET CheckStatus = @Status WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@CheckNumber", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@CheckStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf TransactionType = "Bank Transaction" Then
                    'Update Batch Data in the temp table
                    cmd = New SqlCommand("UPDATE BankTransactions SET Status = @Status WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else

                End If
            Else
                'Update Batch Data in the temp table
                cmd = New SqlCommand("UPDATE BankReconciliationLineTable SET Status = @Status WHERE BatchNumber = @BatchNumber AND TransactionNumber = @TransactionNumber", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If TransactionType = "Cash Receipt" Then
                    'Update Batch Data in the temp table
                    cmd = New SqlCommand("UPDATE ARPaymentLog SET PaymentStatus = @PaymentStatus WHERE PaymentID = @PaymentID AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PaymentID", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PaymentStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf TransactionType = "Checking" Then
                    'Update Batch Data in the temp table
                    cmd = New SqlCommand("UPDATE APCheckLog SET CheckStatus = @Status WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@CheckNumber", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@CheckStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf TransactionType = "Bank Transaction" Then
                    'Update Batch Data in the temp table
                    cmd = New SqlCommand("UPDATE BankTransactions SET Status = @Status WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Status", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else

                End If
            End If
        End If

        'Load Totals
        GetDateRange()
        LoadARBeginningCleared()
        LoadARClearedDebitsAndCredits()
        LoadARClearedTotals()

        LoadAROutstanding()
        LoadBookValueAR()
        LoadAROutstandingTotals()
    End Sub

    Public Sub LoadARClearedDebitsAndCredits()
        Dim SumClearedARCreditsString As String = "SELECT SUM(CreditAmount) FROM BankReconciliationLineTable WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND Status = @Status"
        Dim SumClearedARCreditsCommand As New SqlCommand(SumClearedARCreditsString, con)
        SumClearedARCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumClearedARCreditsCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "PENDING"
        SumClearedARCreditsCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

        Dim SumClearedARDebitsString As String = "SELECT SUM(DebitAmount) FROM BankReconciliationLineTable WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND Status = @Status"
        Dim SumClearedARDebitsCommand As New SqlCommand(SumClearedARDebitsString, con)
        SumClearedARDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumClearedARDebitsCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "PENDING"
        SumClearedARDebitsCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumClearedARCredits = CDbl(SumClearedARCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumClearedARCredits = 0
        End Try
        Try
            SumClearedARDebits = CDbl(SumClearedARDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumClearedARDebits = 0
        End Try
        con.Close()

        lblClearedCredits.Text = FormatCurrency(SumClearedARCredits, 2)
        lblClearedDebits.Text = FormatCurrency(SumClearedARDebits, 2)
    End Sub

    Public Sub LoadARBeginningCleared()
        Dim SumClearedARCreditsString As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE DivisionID = @DivisionID AND PaymentStatus = @PaymentStatus AND PaymentAmount < 0 AND PaymentDate < @BeginDate"
        Dim SumClearedARCreditsCommand As New SqlCommand(SumClearedARCreditsString, con)
        SumClearedARCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumClearedARCreditsCommand.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = "POSTED"
        SumClearedARCreditsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate

        Dim SumClearedARDebitsString As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE DivisionID = @DivisionID AND PaymentStatus = @PaymentStatus AND PaymentAmount > 0 AND PaymentDate < @BeginDate"
        Dim SumClearedARDebitsCommand As New SqlCommand(SumClearedARDebitsString, con)
        SumClearedARDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumClearedARDebitsCommand.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = "POSTED"
        SumClearedARDebitsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate

        Dim SumClearedBegBTDebitsString As String = "SELECT SUM(DebitAmount) FROM BankTransactions WHERE DivisionID = @DivisionID AND Status = @Status AND TransactionDate < @BeginDate"
        Dim SumClearedBegBTDebitsCommand As New SqlCommand(SumClearedBegBTDebitsString, con)
        SumClearedBegBTDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumClearedBegBTDebitsCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"
        SumClearedBegBTDebitsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate

        Dim SumClearedBegBTCreditsString As String = "SELECT SUM(CreditAmount) FROM BankTransactions WHERE DivisionID = @DivisionID AND Status = @Status AND TransactionDate < @BeginDate"
        Dim SumClearedBegBTCreditsCommand As New SqlCommand(SumClearedBegBTCreditsString, con)
        SumClearedBegBTCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumClearedBegBTCreditsCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"
        SumClearedBegBTCreditsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumClearedARCredits = CDbl(SumClearedARCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumClearedARCredits = 0
        End Try
        Try
            SumClearedARDebits = CDbl(SumClearedARDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumClearedARDebits = 0
        End Try
        Try
            SumClearedARBTDebits = CDbl(SumClearedBegBTDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumClearedARBTDebits = 0
        End Try
        Try
            SumClearedARBTCredits = CDbl(SumClearedBegBTCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumClearedARBTCredits = 0
        End Try
        con.Close()

        BeginningClearedARBalance = (SumClearedARDebits + SumClearedARBTDebits) - (SumClearedARCredits + SumClearedARBTCredits)
        lblClearedStatementBalance.Text = FormatCurrency(BeginningClearedARBalance, 2)
    End Sub

    Public Sub LoadARClearedTotals()
        Dim ClearedSubtotal As Double = 0
        Dim ClearedEndingStatementBalance As Double = 0
        Dim ARClearedVariance As Double = 0

        ClearedEndingStatementBalance = Val(txtEndingStatementBalance.Text)
        ClearedSubtotal = SumClearedARDebits - SumClearedARCredits + BeginningClearedARBalance
        txtOne.Text = SumClearedARDebits
        txtTwo.Text = SumClearedARCredits
        ARClearedVariance = ClearedSubtotal - ClearedEndingStatementBalance

        lblClearedSubtotal.Text = FormatCurrency(ClearedSubtotal, 2)
        lblClearedVariance.Text = FormatCurrency(ARClearedVariance, 2)
    End Sub











    Public Sub LoadAPOutstanding()
        Dim SumOSAPCreditsString As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckStatus = @CheckStatus AND CheckAmount <> 0 AND CheckDate BETWEEN @BeginDate AND @EndDate"
        Dim SumOSAPCreditsCommand As New SqlCommand(SumOSAPCreditsString, con)
        SumOSAPCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumOSAPCreditsCommand.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "POSTED"
        SumOSAPCreditsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumOSAPCreditsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim SumOSAPDebitsString As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckStatus = @CheckStatus AND CheckAmount <> 0 CheckDate BETWEEN @BeginDate AND @EndDate"
        Dim SumOSAPDebitsCommand As New SqlCommand(SumOSAPDebitsString, con)
        SumOSAPDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumOSAPDebitsCommand.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "POSTED"
        SumOSAPDebitsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumOSAPDebitsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumOutstandingAPCredits = CDbl(SumOSAPCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumOutstandingAPCredits = 0
        End Try
        Try
            SumOutstandingAPDebits = CDbl(SumOSAPDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumOutstandingAPDebits = 0
        End Try
        con.Close()

        lblOSCredits.Text = FormatCurrency(SumOutstandingAPCredits, 2)
        lblOSDebits.Text = FormatCurrency(SumOutstandingAPDebits, 2)
    End Sub

    Public Sub LoadAllAPOutstanding()
        Dim SumOSAPCreditsString As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckStatus = @CheckStatus AND CheckAmount <> 0"
        Dim SumOSAPCreditsCommand As New SqlCommand(SumOSAPCreditsString, con)
        SumOSAPCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumOSAPCreditsCommand.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "POSTED"

        Dim SumOSAPDebitsString As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckStatus = @CheckStatus AND CheckAmount <> 0"
        Dim SumOSAPDebitsCommand As New SqlCommand(SumOSAPDebitsString, con)
        SumOSAPDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumOSAPDebitsCommand.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "POSTED"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumOutstandingAPCredits = CDbl(SumOSAPCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumOutstandingAPCredits = 0
        End Try
        Try
            SumOutstandingAPDebits = CDbl(SumOSAPDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumOutstandingAPDebits = 0
        End Try
        con.Close()

        lblOSCredits.Text = FormatCurrency(SumOutstandingAPCredits, 2)
        lblOSDebits.Text = FormatCurrency(SumOutstandingAPDebits, 2)
    End Sub

    Public Sub LoadAPBeginning()
        Dim SumClearedAPCreditsString As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckStatus = @CheckStatus AND CheckAmount < 0 CheckDate < @BeginDate"
        Dim SumClearedAPCreditsCommand As New SqlCommand(SumClearedAPCreditsString, con)
        SumClearedAPCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumClearedAPCreditsCommand.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "CLEARED"
        SumClearedAPCreditsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumClearedAPCreditsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim SumClearedAPDebitsString As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckStatus = @CheckStatus AND CheckAmount > 0 CheckDate < @BeginDate"
        Dim SumClearedAPDebitsCommand As New SqlCommand(SumClearedAPDebitsString, con)
        SumClearedAPDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumClearedAPDebitsCommand.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "CLEARED"
        SumClearedAPDebitsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumClearedAPDebitsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumClearedAPCredits = CDbl(SumClearedAPCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumClearedAPCredits = 0
        End Try
        Try
            SumClearedAPDebits = CDbl(SumClearedAPDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumClearedAPDebits = 0
        End Try
        con.Close()

        BeginningOSAPBalance = SumClearedAPDebits - SumClearedAPCredits
        lblOSStatementBalance.Text = FormatCurrency(BeginningOSAPBalance, 2)
    End Sub

    Public Sub LoadBookValueAP()
        Dim SumAPCreditsString As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumAPCreditsCommand As New SqlCommand(SumAPCreditsString, con)
        SumAPCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumAPCreditsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10200"
        SumAPCreditsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumAPCreditsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim SumAPDebitsString As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber BETWEEN @BeginDate AND @EndDate"
        Dim SumAPDebitsCommand As New SqlCommand(SumAPDebitsString, con)
        SumAPDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumAPDebitsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10200"
        SumAPDebitsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumAPDebitsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumAPCredits = CDbl(SumAPCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumAPCredits = 0
        End Try
        Try
            SumAPDebits = CDbl(SumAPDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumAPDebits = 0
        End Try
        con.Close()

        SumAPBookBalance = SumAPCredits - SumAPDebits
        lblBookBalance.Text = FormatCurrency(SumAPBookBalance, 2)
    End Sub

    Public Sub LoadAllBookValueAP()
        Dim SumAPCreditsString As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber"
        Dim SumAPCreditsCommand As New SqlCommand(SumAPCreditsString, con)
        SumAPCreditsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumAPCreditsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10200"

        Dim SumAPDebitsString As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber"
        Dim SumAPDebitsCommand As New SqlCommand(SumAPDebitsString, con)
        SumAPDebitsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumAPDebitsCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10200"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumAPCredits = CDbl(SumAPCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            SumAPCredits = 0
        End Try
        Try
            SumAPDebits = CDbl(SumAPDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            SumAPDebits = 0
        End Try
        con.Close()

        SumAPBookBalance = SumAPCredits - SumAPDebits
        lblBookBalance.Text = FormatCurrency(SumAPBookBalance, 2)
    End Sub

    Public Sub LoadAPTotals()
        EndingOSAPBalance = BeginningOSAPBalance + SumOutstandingAPDebits - SumOutstandingAPCredits
        lblOSEndingTotal.Text = FormatCurrency(EndingOSAPBalance, 2)
        APVariance = EndingOSAPBalance - SumAPBookBalance
        lblOSVariance.Text = FormatCurrency(APVariance, 2)
    End Sub

    Public Sub LoadAllAPTotals()
        BeginningOSAPBalance = 0
        EndingOSAPBalance = BeginningOSAPBalance + SumOutstandingAPDebits - SumOutstandingAPCredits
        lblOSEndingTotal.Text = FormatCurrency(EndingOSAPBalance, 2)
        APVariance = EndingOSAPBalance - SumAPBookBalance
        lblOSVariance.Text = FormatCurrency(APVariance, 2)
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

    End Sub

    Private Sub PrintBankReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBankReportToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdGenerateNewBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewBatch.Click
        ClearData()
        ClearVariables()

        'Create new batch
        Dim LastBatchNumber As Integer = 0
        Dim NextBatchNumber As Integer = 0

        Dim GetMAXBatchNumberString As String = "SELECT MAX(BatchNumber) FROM BankReconciliationBatchHeader"
        Dim GetMAXBatchNumberCommand As New SqlCommand(GetMAXBatchNumberString, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(GetMAXBatchNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 4700000
        End Try
        con.Close()

        NextBatchNumber = LastBatchNumber + 1
        cboBatchNumber.Text = NextBatchNumber

        Try
            'Write to database
            cmd = New SqlCommand("INSERT INTO BankReconciliationBatchHeader (BatchNumber, BankAccount, DivisionID, Comment, BatchAmount, BatchDate, BatchStatus) values (@BatchNumber, @BankAccount, @DivisionID, @Comment, @BatchAmount, @BatchDate, @BatchStatus)", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                .Add("@BankAccount", SqlDbType.VarChar).Value = cboBankAccount.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Comment", SqlDbType.VarChar).Value = "BANK REC BATCH"
                .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtEndingStatementBalance.Text)
                .Add("@BatchDate", SqlDbType.VarChar).Value = dtpPostDate.Text
                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            txtBatchStatus.Text = "OPEN"
            txtComment.Text = "BANK REC BATCH"
        Catch ex As Exception
            'Error Log
        End Try
    End Sub

    Private Sub cboBatchNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBatchNumber.SelectedIndexChanged
        ShowLines()

        'Load Totals
        GetDateRange()

        LoadARBeginningCleared()
        LoadARClearedDebitsAndCredits()
        LoadARClearedTotals()

        LoadAROutstanding()
        LoadAROutstandingTotals()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Dim ARPaymentID As Integer = 0
        Dim APPaymentID As Integer = 0
        Dim ARCustomerID As String = ""
        Dim APVendorID As String = ""
        Dim APCreditAmount As Double = 0
        Dim APDebitAmount As Double = 0
        Dim ARDebitAmount As Double = 0
        Dim ARCreditAmount As Double = 0
        Dim ARDate As String = ""
        Dim APDate As String = ""
        Dim ARPaymentNumber As String = ""

        'Save Batch Data
        cmd = New SqlCommand("UPDATE BankReconciliationBatchHeader SET BankAccount = @BankAccount, Comment = @Comment, BatchAmount = @BatchAmount, BatchDate = @BatchDate, BatchStatus = @BatchStatus WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@BankAccount", SqlDbType.VarChar).Value = cboBankAccount.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@BatchAmount", SqlDbType.VarChar).Value = Val(txtEndingStatementBalance.Text)
            .Add("@BatchDate", SqlDbType.VarChar).Value = dtpPostDate.Text
            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Select date range
        GetDateRange()

        'Load Bank Transactions into datagrid
        If cboBankAccount.Text = "Cash Receipts" Then
            'Load dataset into grid
            LoadARPaymentLog()
            LoadARBankTransaction()

            'Get data from both datagrids and write to batch lines
            'Get Line Data
            For Each row As DataGridViewRow In dgvARPaymentLog.Rows
                Try
                    ARPaymentID = row.Cells("ARPaymentIDColumn").Value
                Catch ex As System.Exception
                    ARPaymentID = 0
                End Try
                Try
                    ARPaymentNumber = row.Cells("ARPaymentNumberColumn").Value
                Catch ex As System.Exception
                    ARPaymentNumber = ""
                End Try
                Try
                    ARCustomerID = row.Cells("ARCustomerIDColumn").Value
                Catch ex As System.Exception
                    ARCustomerID = ""
                End Try
                Try
                    ARDebitAmount = row.Cells("ARPaymentAmountColumn").Value
                Catch ex As System.Exception
                    ARDebitAmount = 0
                End Try
                Try
                    ARDate = row.Cells("ARPaymentDateColumn").Value
                Catch ex As System.Exception
                    ARDate = ""
                End Try

                'Write to database
                cmd = New SqlCommand("INSERT INTO BankReconciliationLineTable (CheckNumber, PaymentNumber, Date, DebitAmount, CreditAmount, PayerPayee, TransactionNumber, TransactionType, Description, DivisionID, Comment, Status, BatchNumber, CheckOrUncheck) values (@CheckNumber, @PaymentNumber, @Date, @DebitAmount, @CreditAmount, @PayerPayee, @TransactionNumber, @TransactionType, @Description, @DivisionID, @Comment, @Status, @BatchNumber, @CheckOrUncheck)", con)

                With cmd.Parameters
                    .Add("@CheckNumber", SqlDbType.VarChar).Value = 0
                    .Add("@PaymentNumber", SqlDbType.VarChar).Value = ARPaymentNumber
                    .Add("@Date", SqlDbType.VarChar).Value = ARDate
                    .Add("@DebitAmount", SqlDbType.VarChar).Value = ARDebitAmount
                    .Add("@CreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@PayerPayee", SqlDbType.VarChar).Value = ARCustomerID
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = ARPaymentID
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Cash Receipt"
                    .Add("@Description", SqlDbType.VarChar).Value = "AR Bank Reconciliation"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@CheckOrUncheck", SqlDbType.VarChar).Value = "UNCHECKED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next

            'Get Line Data
            For Each row As DataGridViewRow In dgvBankTransactions.Rows
                Try
                    ARPaymentID = row.Cells("BTTransactionNumberColumn").Value
                Catch ex As System.Exception
                    ARPaymentID = 0
                End Try
                Try
                    ARDebitAmount = row.Cells("BTDebitAmountColumn").Value
                Catch ex As System.Exception
                    ARDebitAmount = 0
                End Try
                Try
                    ARCreditAmount = row.Cells("BTCreditAmountColumn").Value
                Catch ex As System.Exception
                    ARCreditAmount = 0
                End Try
                Try
                    ARDate = row.Cells("BTTransactionDateColumn").Value
                Catch ex As System.Exception
                    ARDate = ""
                End Try

                'Write to database
                cmd = New SqlCommand("INSERT INTO BankReconciliationLineTable (CheckNumber, PaymentNumber, Date, DebitAmount, CreditAmount, PayerPayee, TransactionNumber, TransactionType, Description, DivisionID, Comment, Status, BatchNumber) values (@CheckNumber, @PaymentNumber, @Date, @DebitAmount, @CreditAmount, @PayerPayee, @TransactionNumber, @TransactionType, @Description, @DivisionID, @Comment, @Status, @BatchNumber)", con)

                With cmd.Parameters
                    .Add("@CheckNumber", SqlDbType.VarChar).Value = 0
                    .Add("@PaymentNumber", SqlDbType.VarChar).Value = ARPaymentNumber
                    .Add("@Date", SqlDbType.VarChar).Value = ARDate
                    .Add("@DebitAmount", SqlDbType.VarChar).Value = ARDebitAmount
                    .Add("@CreditAmount", SqlDbType.VarChar).Value = ARCreditAmount
                    .Add("@PayerPayee", SqlDbType.VarChar).Value = ARCustomerID
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = ARPaymentID
                    .Add("@TransactionType", SqlDbType.VarChar).Value = "Bank Transaction"
                    .Add("@Description", SqlDbType.VarChar).Value = "AR Bank Reconciliation"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next

            ShowLines()

            LoadAROutstanding()
            LoadBookValueAR()
            LoadAROutstandingTotals()

            LoadARBeginningCleared()
            LoadARClearedDebitsAndCredits()
            LoadARClearedTotals()
        ElseIf cboBankAccount.Text = "Checking" Then














        ElseIf cboBankAccount.Text = "Due To Parent" Then







        Else
            MsgBox("Please select a valid Bank Account.", MsgBoxStyle.OkOnly)
            cboBankAccount.Focus()
        End If
    End Sub


    Private Sub cboBankAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBankAccount.SelectedIndexChanged

    End Sub

    Private Sub cmdDeleteBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteBatch.Click
        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this batch?", "DELETE BATCH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then

            'Write to database
            cmd = New SqlCommand("DELETE FROM BankReconciliationBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Clear fields and reload datagrid
            ClearData()
            ClearVariables()

            ShowLines()
        ElseIf button = DialogResult.No Then
            cmdDeleteBatch.Focus()
        End If
    End Sub

    Private Sub cmdCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckAll.Click
        'Update Line Data in the temp table
        cmd = New SqlCommand("UPDATE BankReconciliationLineTable SET Status = @Status, CheckOrUncheck = @CheckOrUncheck WHERE BatchNumber = @BatchNumber", con)

        With cmd.Parameters
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@Status", SqlDbType.VarChar).Value = "PENDING"
            .Add("@CheckOrUncheck", SqlDbType.VarChar).Value = "CHECKED"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Reload datagrid
        ShowLines()

        'Load Totals
        GetDateRange()
        LoadARBeginningCleared()
        LoadARClearedDebitsAndCredits()
        LoadARClearedTotals()
        LoadBookValueAR()
        LoadAROutstanding()
        LoadAROutstandingTotals()
    End Sub

    Private Sub cmdUncheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUncheckAll.Click
        'Update Batch Data in the temp table
        cmd = New SqlCommand("UPDATE BankReconciliationLineTable SET Status = @Status, CheckOrUncheck = @CheckOrUncheck WHERE BatchNumber = @BatchNumber", con)

        With cmd.Parameters
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
            .Add("@CheckOrUncheck", SqlDbType.VarChar).Value = "UNCHECKED"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Reload datagrid
        ShowLines()

        'Load Totals
        GetDateRange()
        LoadARBeginningCleared()
        LoadARClearedDebitsAndCredits()
        LoadARClearedTotals()
        LoadBookValueAR()
        LoadAROutstanding()
        LoadAROutstandingTotals()
    End Sub

    Private Sub dgvBankRec_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBankRec.CurrentCellDirtyStateChanged
        If dgvBankRec.IsCurrentCellDirty Then
            dgvBankRec.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

End Class