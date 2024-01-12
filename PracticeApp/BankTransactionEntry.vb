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
Public Class BankTransactionEntry
    Inherits System.Windows.Forms.Form

    Dim NextGLNumber, LastGLNumber, NextBatchNumber, LastBatchNumber, LastTransactionNumber, NextTransactionNumber As Integer
    Dim SelectDate As Date
    Dim BeginDate, EndDate, strYear, StrMonth As String
    Dim intYear, intMonth, ReconciliationMonth As Integer
    Dim ValidateGLAmount, GLBankAccount, BatchStatus, BankAccount, GLBankAccountBatchDate, BatchComment, BatchDate As String
    Dim BatchTotal As Double = 0
    Dim CreditBatchTotal, DebitBatchTotal, BatchBalance As Double

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim isLoaded As Boolean = False

    'Load Routines

    Private Sub BankTransactionEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.GLAccounts' table. You can move, or remove it, as needed.
        Me.GLAccountsTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.GLAccounts)

        LoadCurrentDivision()

        'Set default for division and enable beginning inventory edits
        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        isLoaded = True
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

    Public Sub ShowManualBankTransactions()
        cmd = New SqlCommand("SELECT * FROM BankTransactions WHERE DivisionID = @DivisionID AND Status = @Status AND BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "BankTransactions")
        dgvBankTransactions.DataSource = ds.Tables("BankTransactions")
        cboDeleteTransaction.DataSource = ds.Tables("BankTransactions")
        con.Close()
    End Sub

    Public Sub LoadTransactionNumber()
        cmd = New SqlCommand("SELECT TransactionNumber FROM BankTransactions WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND Status = @Status", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "BankTransactions")
        cboTransactionNumber.DataSource = ds1.Tables("BankTransactions")
        con.Close()
        cboTransactionNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBatchNumber()
        cmd = New SqlCommand("SELECT BatchNumber FROM BankTransactionsBatchHeader WHERE DivisionID = @DivisionID AND BatchStatus = @BatchStatus", con)
        cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "BankTransactionsBatchHeader")
        cboBatchNumber.DataSource = ds2.Tables("BankTransactionsBatchHeader")
        con.Close()
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

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

    Public Sub GetDateRange()
        SelectDate = dtpTransactionDate.Value

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

    Public Sub LoadBatchData()
        Dim GetBatchDataString As String = "SELECT * FROM BankTransactionsBatchHeader WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
        Dim GetBatchDataCommand As New SqlCommand(GetBatchDataString, con)
        GetBatchDataCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        GetBatchDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetBatchDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("BatchDate")) Then
                BatchDate = Today()
            Else
                BatchDate = reader.Item("BatchDate")
            End If
            If IsDBNull(reader.Item("BatchStatus")) Then
                BatchStatus = "OPEN"
            Else
                BatchStatus = reader.Item("BatchStatus")
            End If
            If IsDBNull(reader.Item("BankAccount")) Then
                BankAccount = "10400"
            Else
                BankAccount = reader.Item("BankAccount")
            End If
            If IsDBNull(reader.Item("BatchComment")) Then
                BatchComment = ""
            Else
                BatchComment = reader.Item("BatchComment")
            End If
            If IsDBNull(reader.Item("BatchTotal")) Then
                BatchTotal = 0
            Else
                BatchTotal = reader.Item("BatchTotal")
            End If
        Else
            BatchDate = Today()
            BatchStatus = "OPEN"
            BankAccount = "10400"
            BatchComment = ""
            BatchTotal = 0
        End If
        reader.Close()
        con.Close()

        dtpTransactionDate.Text = BatchDate
        txtBatchStatus.Text = BatchStatus
        txtBatchComment.Text = BatchComment
        fillBankAccount()
        txtBatchTotal.Text = FormatCurrency(BatchTotal, 2)
    End Sub

    Private Sub fillBankAccount()
        Select Case BankAccount
            Case "10200"
                cboBankAccount.Text = "Checking"
            Case "10300"
                cboBankAccount.Text = "Payroll Checking"
            Case "10400"
                cboBankAccount.Text = "Cash Receipts"
            Case "10000"
                cboBankAccount.Text = "Petty Cash"
            Case "C$10200"
                cboBankAccount.Text = "Canadian Checking"
            Case "C$10400"
                cboBankAccount.Text = "Canadian Cash Receipts"
        End Select
    End Sub

    Public Sub LoadBankTransactionData()
        Dim GetTransactionDataString As String = "SELECT * FROM BankTransactions WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND TransactionNumber = @TransactionNumber"
        Dim GetTransactionDataCommand As New SqlCommand(GetTransactionDataString, con)
        GetTransactionDataCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        GetTransactionDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetTransactionDataCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboTransactionNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetTransactionDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("TransactionType")) Then
                cboTransactionType.Text = ""
            Else
                cboTransactionType.Text = reader.Item("TransactionType")
            End If
            If IsDBNull(reader.Item("GLAccount")) Then
                cboGLAccountID.Text = "0"
            Else
                cboGLAccountID.Text = reader.Item("GLAccount")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                txtTransactionComment.Text = ""
            Else
                txtTransactionComment.Text = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("DebitAmount")) = False Then
                txtDebitAmount.Text = reader.Item("DebitAmount")
            End If
            If IsDBNull(reader.Item("CreditAmount")) = False Then
                txtCreditAmount.Text = reader.Item("CreditAmount")
            End If
        Else
            cboTransactionType.Text = ""
            cboGLAccountID.Text = "0"
            txtTransactionComment.Text = ""
            txtDebitAmount.Text = "0"
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub LoadBatchStatus()
        Dim BatchStatusString As String = "SELECT BatchStatus FROM BankTransactionsBatchHeader WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusString, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            BatchStatus = "OPEN"
        End Try
        con.Close()

        txtBatchStatus.Text = BatchStatus

        If BatchStatus = "POSTED" Then
            cmdEnterBankTransaction.Enabled = False
            cmdSaveBatch.Enabled = False
            cmdDeleteTransaction.Enabled = False
            cmdPostBatch.Enabled = False

        Else
            cmdEnterBankTransaction.Enabled = True
            cmdSaveBatch.Enabled = True
            cmdDeleteTransaction.Enabled = True
            cmdPostBatch.Enabled = True
        End If
    End Sub

    Public Sub LoadBatchTotal()
        'Get Next Bank Transaction Number
        Dim CreditBatchTotalString As String = "SELECT SUM(CreditAmount) AS SumCreditAmount, SUM(DebitAmount) as SumDebitAmount FROM BankTransactions WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
        Dim CreditBatchTotalCommand As New SqlCommand(CreditBatchTotalString, con)
        CreditBatchTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        CreditBatchTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = CreditBatchTotalCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SumCreditAmount")) Then
                CreditBatchTotal = 0
            Else
                CreditBatchTotal = reader.Item("SumCreditAmount")
                CreditBatchTotal = Math.Round(CreditBatchTotal, 2)
            End If
            If IsDBNull(reader.Item("SumDebitAmount")) Then
                DebitBatchTotal = 0
            Else
                DebitBatchTotal = reader.Item("SumDebitAmount")
                DebitBatchTotal = Math.Round(DebitBatchTotal, 2)
            End If
        Else
            CreditBatchTotal = 0
            DebitBatchTotal = 0
        End If
        reader.Close()
        con.Close()

        BatchTotal = DebitBatchTotal - CreditBatchTotal
        txtBatchTotal.Text = FormatCurrency(BatchTotal, 2)
        txtCreditTotal.Text = FormatCurrency(CreditBatchTotal, 2)
        txtDebitTotal.Text = FormatCurrency(DebitBatchTotal, 2)
    End Sub

    'Clear Subroutines

    Public Sub ClearData()
        cboBankAccount.SelectedIndex = -1
        cboBatchNumber.SelectedIndex = -1
        cboDeleteTransaction.SelectedIndex = -1
        cboGLAccountID.SelectedIndex = -1
        cboGLAccountName.SelectedIndex = -1
        cboTransactionNumber.SelectedIndex = -1
        cboTransactionType.SelectedIndex = -1

        cboBankAccount.Text = ""
        cboBatchNumber.Text = ""
        cboDeleteTransaction.Text = ""
        cboGLAccountID.Text = ""
        cboGLAccountName.Text = ""
        cboTransactionNumber.Text = ""
        cboTransactionType.Text = ""

        txtBatchComment.Clear()
        txtBatchStatus.Clear()
        txtBatchTotal.Clear()
        txtCreditAmount.Clear()
        txtDebitAmount.Clear()
        txtDebitTotal.Clear()
        txtCreditTotal.Clear()
        txtTransactionComment.Clear()

        dtpTransactionDate.Text = ""

        cmdGenerateBatchNumber.Focus()
    End Sub

    Public Sub ClearLines()
        cboTransactionNumber.Text = ""

        cboTransactionNumber.SelectedIndex = -1
        cboTransactionType.SelectedIndex = -1

        txtCreditAmount.Clear()
        txtDebitAmount.Clear()
        txtTransactionComment.Clear()

        cboTransactionType.Focus()
    End Sub

    Public Sub ClearVariables()
        NextGLNumber = 0
        LastGLNumber = 0
        NextBatchNumber = 0
        LastBatchNumber = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        'SelectDate = Today()
        BeginDate = ""
        EndDate = ""
        strYear = ""
        StrMonth = ""
        intYear = 0
        intMonth = 0
        ReconciliationMonth = 0
        ValidateGLAmount = ""
        GLBankAccount = ""
        BatchStatus = ""
        BankAccount = ""
        GLBankAccountBatchDate = ""
        BatchComment = ""
        BatchDate = ""
        BatchTotal = 0
        CreditBatchTotal = 0
        DebitBatchTotal = 0
        BatchBalance = 0
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvBankTransactions.DataSource = Nothing
    End Sub

    'ComboBox and Text Box changed event

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadBatchNumber()

        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cboBatchNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBatchNumber.SelectedIndexChanged
        If isLoaded Then
            isLoaded = False
            LoadTransactionNumber()
            LoadBatchData()
            LoadBatchStatus()
            LoadBatchTotal()
            ShowManualBankTransactions()
            isLoaded = True

            If dgvBankTransactions.Rows.Count > 0 Then
                If cboBankAccount.Enabled Then
                    cboBankAccount.Enabled = False
                End If
            Else
                If cboBankAccount.Enabled = False Then
                    cboBankAccount.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub cboBankAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBankAccount.SelectedIndexChanged
        'Get Bank Account
        If cboBankAccount.Text = "Checking" Then
            GLBankAccount = "10200"
        ElseIf cboBankAccount.Text = "Payroll Checking" Then
            GLBankAccount = "10300"
        ElseIf cboBankAccount.Text = "Cash Receipts" Then
            GLBankAccount = "10400"
        ElseIf cboBankAccount.Text = "Petty Cash" Then
            GLBankAccount = "10000"
        ElseIf cboBankAccount.Text = "Canadian Checking" Then
            GLBankAccount = "C$10200"
        ElseIf cboBankAccount.Text = "Canadian Cash Receipts" Then
            GLBankAccount = "C$10400"
        Else
            GLBankAccount = "10200"
        End If

        cboGLAccountID.Text = GLBankAccount
    End Sub

    Private Sub cboTransactionNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTransactionNumber.SelectedIndexChanged
        LoadBankTransactionData()
    End Sub

    Private Sub txtDebitAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDebitAmount.TextChanged
        If Val(txtDebitAmount.Text) <> 0 Then txtCreditAmount.Text = 0
    End Sub

    Private Sub txtCreditAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditAmount.TextChanged
        If Val(txtCreditAmount.Text) <> 0 Then txtDebitAmount.Text = 0
    End Sub

    'Functions and sub routines

    Private Function canEnterBankTrans() As Boolean
        'If String.IsNullOrEmpty(cboBatchNumber.Text) Then
        '    MessageBox.Show("You must enter a batch number", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboBatchNumber.Focus()
        '    Return False
        'End If
        'If cboBatchNumber.SelectedIndex = -1 Then
        '    MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboBatchNumber.SelectAll()
        '    cboBatchNumber.Focus()
        '    Return False
        'End If
        'If String.IsNullOrEmpty(cboTransactionNumber.Text) Then
        '    MessageBox.Show("You must enter a transaction number", "Enter a transaction number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboTransactionNumber.Focus()
        '    Return False
        'End If
        'If cboTransactionNumber.SelectedIndex = -1 Then
        '    MessageBox.Show("You must enter a valid transaction number", "Enter a valid transaction number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboTransactionNumber.SelectAll()
        '    cboTransactionNumber.Focus()
        '    Return False
        'End If
        'If String.IsNullOrEmpty(cboTransactionType.Text) Then
        '    MessageBox.Show("You must enter a transaction type", "Enter a transaction type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboTransactionType.Focus()
        '    Return False
        'End If
        'If cboTransactionType.SelectedIndex = -1 Then
        '    MessageBox.Show("You must enter a valid transaction type", "Enter a valid transaction type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboTransactionType.SelectAll()
        '    cboTransactionType.Focus()
        '    Return False
        'End If
        'If String.IsNullOrEmpty(cboGLAccountID.Text) Then
        '    MessageBox.Show("You must enter a GL Account", "Enter a valid GL Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboGLAccountID.Focus()
        '    Return False
        'End If
        'If cboGLAccountID.SelectedIndex = -1 Then
        '    MessageBox.Show("You must enter a valid GL Account", "Enter a valid GL Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboGLAccountID.SelectAll()
        '    cboGLAccountID.Focus()
        '    Return False
        'End If
        Return True
    End Function

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must select a batch", "Select a batch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If cboBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        If dgvBankTransactions.Rows.Count = 0 Then
            MessageBox.Show("There are not transactions in this batch to print", "No transactions to print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTransactionNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canPostBatch() As Boolean
        'If String.IsNullOrEmpty(cboBatchNumber.Text) Then
        '    MessageBox.Show("You must enter a batch number", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboBatchNumber.Focus()
        '    Return False
        'End If
        'If cboBatchNumber.SelectedIndex = -1 Then
        '    MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboBatchNumber.SelectAll()
        '    cboBatchNumber.Focus()
        '    Return False
        'End If
        If txtBatchStatus.Text = "POSTED" Then
            MessageBox.Show("This batch has already been posted", "Already been posted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If dgvBankTransactions.Rows.Count = 0 Then
            MessageBox.Show("There are no transactions for this batch. You must enter transactions to be able to post", "Enter transactions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTransactionNumber.Focus()
            Return False
        End If
        If DebitBatchTotal <> CreditBatchTotal Then
            MsgBox("Batch does not balance. Check your data.", MsgBoxStyle.OkOnly)
            Return False
        End If
        Return True
    End Function

    Private Function canDeleteBatch() As Boolean
        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Batch?", "DELETE BATCH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must enter a batch number", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If Val(cboBatchNumber.Text) = 0 Then
            MsgBox("You must have a valid Batch Number selected", MsgBoxStyle.OkOnly)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        If txtBatchStatus.Text = "POSTED" Then
            MsgBox("You cannot delete lines from a posted batch.", MsgBoxStyle.OkOnly)
            Return False
        End If
        Return True
    End Function

    Private Function canSaveBatch() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must enter a bathc number", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If cboBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        If txtBatchStatus.Text = "POSTED" Then
            MessageBox.Show("Batch has already been POSTED, no more changes can be saved", "Already posted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Function canDeleteTrans() As Boolean
        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Transaction?", "DELETE TRANSACTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must enter a batch number", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        'If cboBatchNumber.SelectedIndex = -1 Then
        '    MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboBatchNumber.SelectAll()
        '    cboBatchNumber.Focus()
        '    Return False
        'End If
        If String.IsNullOrEmpty(cboDeleteTransaction.Text) Then
            MessageBox.Show("You must enter a transaction number", "Enter a transaction number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteTransaction.Focus()
            Return False
        End If
        'If cboDeleteTransaction.SelectedIndex = -1 Then
        '    MessageBox.Show("You must enter a valid transaction number", "Enter a valid transaction number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboDeleteTransaction.SelectAll()
        '    cboDeleteTransaction.Focus()
        '    Return False
        'End If
        If txtBatchStatus.Text = "POSTED" Then
            MsgBox("You cannot delete lines from a posted batch.", MsgBoxStyle.OkOnly)
            Return False
        End If
        Return True
    End Function

    Public Sub UpdateTransactions()
        'Write Data to Bank Transaction Table
        cmd = New SqlCommand("UPDATE BankTransactions SET TransactionType = @TransactionType, TransactionDate = @TransactionDate, DebitAmount = @DebitAmount, CreditAmount = @CreditAmount, Comment = @Comment, Status = @Status, GLAccount = @GLAccount WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)

        With cmd.Parameters
            .Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboTransactionNumber.Text)
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@TransactionType", SqlDbType.VarChar).Value = cboTransactionType.Text
            .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
            .Add("@DebitAmount", SqlDbType.VarChar).Value = Val(txtDebitAmount.Text)
            .Add("@CreditAmount", SqlDbType.VarChar).Value = Val(txtCreditAmount.Text)
            .Add("@Comment", SqlDbType.VarChar).Value = txtTransactionComment.Text
            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
            .Add("@GLAccount", SqlDbType.VarChar).Value = cboGLAccountID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub InsertIntoTransactions()
        'Write Data to Bank Transaction Table
        cmd = New SqlCommand("Insert Into BankTransactions(TransactionNumber, BatchNumber, DivisionID, TransactionType, TransactionDate, DebitAmount, CreditAmount, Comment, Status, GLAccount)values (@TransactionNumber, @BatchNumber, @DivisionID, @TransactionType, @TransactionDate, @DebitAmount, @CreditAmount, @Comment, @Status, @GLAccount)", con)

        With cmd.Parameters
            .Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboTransactionNumber.Text)
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@TransactionType", SqlDbType.VarChar).Value = cboTransactionType.Text
            .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
            .Add("@DebitAmount", SqlDbType.VarChar).Value = Val(txtDebitAmount.Text)
            .Add("@CreditAmount", SqlDbType.VarChar).Value = Val(txtCreditAmount.Text)
            .Add("@Comment", SqlDbType.VarChar).Value = txtTransactionComment.Text
            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
            .Add("@GLAccount", SqlDbType.VarChar).Value = cboGLAccountID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub UpdateBatchHeader()
        'Write Data to Bank Batch Table
        cmd = New SqlCommand("UPDATE BankTransactionsBatchHeader SET BatchTotal = @BatchTotal, BatchDate = @BatchDate, BatchStatus = @BatchStatus, BankAccount = @BankAccount, BatchComment = @BatchComment WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@BatchTotal", SqlDbType.VarChar).Value = Val(txtBatchTotal.Text)
            .Add("@BatchDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@BankAccount", SqlDbType.VarChar).Value = cboBankAccount.Text
            .Add("@BatchComment", SqlDbType.VarChar).Value = txtBatchComment.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub deleteNewUnsavedLine()
        If NextTransactionNumber <> 0 Then
            Try
                'Delete from Bank Transaction Table
                cmd = New SqlCommand("DELETE FROM BankTransactions WHERE DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND Status = @Status", con)

                With cmd.Parameters
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try

            NextTransactionNumber = 0
            LoadTransactionNumber()
        End If
    End Sub

    'Command Buttons

    Private Sub cmdDeleteTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteTransaction.Click
        If canDeleteTrans() Then
            Try
                'Delete from Bank Transaction Table
                cmd = New SqlCommand("DELETE FROM BankTransactions WHERE DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND Status = @Status", con)

                With cmd.Parameters
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboDeleteTransaction.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Bank Transactions --- Delete Transaction"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            ClearLines()

            If cboBankAccount.SelectedIndex <> -1 Then
                cboGLAccountID.Text = GLBankAccount
            End If

            LoadBatchTotal()
            LoadTransactionNumber()
            ShowManualBankTransactions()
            cboDeleteTransaction.Text = ""
            If dgvBankTransactions.Rows.Count > 0 Then
                If cboBankAccount.Enabled Then
                    cboBankAccount.Enabled = False
                End If
            Else
                If cboBankAccount.Enabled = False Then
                    cboBankAccount.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        deleteNewUnsavedLine()
        ClearVariables()
        ClearData()
        ShowManualBankTransactions()
    End Sub

    Private Sub cmdEnterBankTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterBankTransaction.Click
        If canEnterBankTrans() Then
            'Save Batch Header data
            Try
                UpdateBatchHeader()
            Catch ex As Exception
                'Log error on update failure
                Dim TempTransactionNumber As Integer = 0
                Dim strTransactionNumber As String
                TempTransactionNumber = Val(cboTransactionNumber.Text)
                strTransactionNumber = CStr(TempTransactionNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Bank Transactions --- Enter Button - Update Batch Header"
                ErrorReferenceNumber = "Transaction # " + strTransactionNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Validate GL Account
            Dim CheckGLAccount As Integer = 0

            'Check GL Account Number
            Dim CheckGLAccountStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
            Dim CheckGLAccountCommand As New SqlCommand(CheckGLAccountStatement, con)
            CheckGLAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckGLAccount = CInt(CheckGLAccountCommand.ExecuteScalar)
            Catch ex As Exception
                CheckGLAccount = 0
            End Try
            con.Close()

            If CheckGLAccount = 1 Then
                'Continue
            Else
                MsgBox("Invalid GL Account.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'Count if any transactions exist
            Dim CountBankTransactions As Integer = 0

            Dim CountBankTransactionsStatement As String = "SELECT COUNT(TransactionNumber) FROM BankTransactions WHERE TransactionNumber = @TransactionNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim CountBankTransactionsCommand As New SqlCommand(CountBankTransactionsStatement, con)
            CountBankTransactionsCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboTransactionNumber.Text)
            CountBankTransactionsCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            CountBankTransactionsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountBankTransactions = CInt(CountBankTransactionsCommand.ExecuteScalar)
            Catch ex As Exception
                CountBankTransactions = 0
            End Try
            con.Close()

            If CountBankTransactions > 0 Then
                UpdateTransactions()
            Else
                InsertIntoTransactions()
            End If

            'Get Batch Totals
            LoadBatchTotal()

            'Update Batch Total
            'Write Data to Bank Batch Table
            Try
                UpdateBatchHeader()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Bank Transactions --- Enter Button - Update Batch Header"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            ClearLines()
            NextTransactionNumber = 0

            'Refresh datagrid
            ShowManualBankTransactions()
            cboGLAccountID.Text = GLBankAccount

            If cboBankAccount.Enabled Then
                cboBankAccount.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmdSaveBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveBatch.Click
        'If canSaveBatch() Then
        'Load Batch Total
        LoadBatchTotal()

        Try
            UpdateBatchHeader()
        Catch ex As Exception
            'Log error on update failure
            Dim TempBatchNumber As Integer = 0
            Dim strBatchNumber As String
            TempBatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(TempBatchNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Bank Transactions --- Save Button - Update Batch Header"
            ErrorReferenceNumber = "Batch # " + strBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        ShowManualBankTransactions()

        MsgBox("Batch changes have been saved.", MsgBoxStyle.OkOnly)
        'End If
    End Sub

    Private Sub cmdClearBankTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearBankTransaction.Click
        ClearLines()

        If cboBankAccount.SelectedIndex <> -1 Then
            cboGLAccountID.Text = GLBankAccount
        End If

        deleteNewUnsavedLine()
    End Sub

    Private Sub cmdPrintBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintBatch.Click
        'If canPrint() Then
        GlobalDivisionCode = cboDivisionID.Text
        GlobalBankBatchNumber = Val(cboBatchNumber.Text)

        Using NewPrintBankTransactionBatch As New PrintBankBatch
            Dim Result = NewPrintBankTransactionBatch.ShowDialog()
        End Using
        ' End If
    End Sub

    Private Sub cmdPostBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostBatch.Click
        'Load Batch Total
        LoadBatchTotal()

        If canPostBatch() Then
            '************************************************************************************************
            Try
                UpdateBatchHeader()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                TempBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Bank Transactions --- Post Batch - Update Batch Header"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '************************************************************************************************
            'Verify Batch Balance
            Dim LineTransactionNumber, LineBatchNumber As Integer
            Dim LineGLAccount, LineComment As String
            Dim LineDebitAmount, LineCreditAmount As Double

            For Each row As DataGridViewRow In dgvBankTransactions.Rows
                Try
                    LineTransactionNumber = row.Cells("TransactionNumberColumn").Value
                Catch ex As Exception
                    LineTransactionNumber = 0
                End Try
                Try
                    LineBatchNumber = row.Cells("BatchNumberColumn").Value
                Catch ex As Exception
                    LineBatchNumber = 0
                End Try
                Try
                    LineGLAccount = row.Cells("GLAccountColumn").Value
                Catch ex As Exception
                    LineGLAccount = ""
                End Try
                Try
                    LineDebitAmount = row.Cells("DebitAmountColumn").Value
                Catch ex As Exception
                    LineDebitAmount = 0
                End Try
                Try
                    LineCreditAmount = row.Cells("CreditAmountColumn").Value
                Catch ex As Exception
                    LineCreditAmount = 0
                End Try
                Try
                    LineComment = row.Cells("CommentColumn").Value
                Catch ex As Exception
                    LineComment = ""
                End Try
                '*****************************************************************************************
                'Verify that one amount is written
                If LineCreditAmount = 0 And LineDebitAmount <> 0 Then
                    'Do nothing
                    ValidateGLAmount = "TRUE"
                ElseIf LineCreditAmount <> 0 And LineDebitAmount = 0 Then
                    'Do nothing
                    ValidateGLAmount = "TRUE"
                Else
                    ValidateGLAmount = "FALSE"
                    Exit For
                End If
                '******************************************************************************************
                'Insert into GL
                Try
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Bank Transaction"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineDebitAmount
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineCreditAmount
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = LineComment
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "CASHJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = LineBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = LineTransactionNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Bank Transactions --- Post Batch - Insert Into GL"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next
            '************************************************************************************************
            If ValidateGLAmount = "FALSE" Then
                MsgBox("There is an error in the batch - correct error, the post.", MsgBoxStyle.OkOnly)
            Else
                'Update Line Status and Batch Status to POSTED
                'Write Data to Batch Table
                Try
                    cmd = New SqlCommand("UPDATE BankTransactionsBatchHeader SET BatchStatus = @BatchStatus, BankAccount = @BankAccount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"
                        .Add("@BankAccount", SqlDbType.VarChar).Value = cboBankAccount.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Bank Transactions --- Post Batch - Update Batch Header"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*****************************************************************************************
                Try
                    'Write Data to Bank Transaction Table
                    cmd = New SqlCommand("UPDATE BankTransactions SET Status = @Status WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Status", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempBatchNumber As Integer = 0
                    Dim strBatchNumber As String
                    TempBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(TempBatchNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Bank Transactions --- Post Batch - Update Line Status"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '******************************************************************************************
                'ClearForm
                ClearVariables()
                ClearData()
                ShowManualBankTransactions()
                LoadBatchNumber()

                MsgBox("Batch has been posted.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdDeleteBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteBatch.Click
        If canDeleteBatch() Then
            Try
                'Delete from Bank Transaction Table
                cmd = New SqlCommand("DELETE FROM BankTransactionsBatchHeader WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND BatchStatus = @BatchStatus", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try

            ClearVariables()
            ClearData()
            isLoaded = False
            ShowManualBankTransactions()
            LoadBatchNumber()
            isLoaded = True
            If cboBankAccount.Enabled = False Then
                cboBankAccount.Enabled = True
            End If
        End If
    End Sub

    Private Sub cmdGenerateBatchNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateBatchNumber.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        'Get Next Bank Batch Number
        Dim MAXBatchNumberString As String = "SELECT MAX(BatchNumber) FROM BankTransactionsBatchHeader"
        Dim MAXBatchNumberCommand As New SqlCommand(MAXBatchNumberString, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CDbl(MAXBatchNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 684000000
        End Try
        con.Close()

        NextBatchNumber = LastBatchNumber + 1

        Try
            'Write Data to Bank Batch Table
            cmd = New SqlCommand("Insert Into BankTransactionsBatchHeader(BatchNumber, DivisionID, BatchTotal, BatchDate, BatchStatus, BankAccount, BatchComment)values (@BatchNumber, @DivisionID, @BatchTotal, @BatchDate, @BatchStatus, @BankAccount, @BatchComment)", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchTotal", SqlDbType.VarChar).Value = 0
                .Add("@BatchDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@BankAccount", SqlDbType.VarChar).Value = cboBankAccount.Text
                .Add("@BatchComment", SqlDbType.VarChar).Value = txtBatchComment.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            txtBatchStatus.Text = "OPEN"
            cboBatchNumber.Text = NextBatchNumber

            If cboBankAccount.Enabled = False Then
                cboBankAccount.Enabled = True
            End If
        Catch ex As Exception
            'Log error on update failure
            Dim TempBatchNumber As Integer = 0
            Dim strBatchNumber As String
            TempBatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(TempBatchNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Bank Transactions --- Create New Batch Number"
            ErrorReferenceNumber = "Batch # " + strBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub cmdNewTransactionNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewTransactionNumber.Click
        'Get Next Bank Transaction Number
        Dim MAXTransactionNumberString As String = "SELECT MAX(TransactionNumber) FROM BankTransactions"
        Dim MAXTransactionNumberCommand As New SqlCommand(MAXTransactionNumberString, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CDbl(MAXTransactionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionNumber = 15500000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1

        Try
            'Write Data to Bank Transaction Table
            cmd = New SqlCommand("Insert Into BankTransactions(TransactionNumber, BatchNumber, DivisionID, TransactionType, TransactionDate, DebitAmount, CreditAmount, Comment, Status, GLAccount)values (@TransactionNumber, @BatchNumber, @DivisionID, @TransactionType, @TransactionDate, @DebitAmount, @CreditAmount, @Comment, @Status, @GLAccount)", con)

            With cmd.Parameters
                .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@TransactionType", SqlDbType.VarChar).Value = cboTransactionType.Text
                .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
                .Add("@DebitAmount", SqlDbType.VarChar).Value = Val(txtDebitAmount.Text)
                .Add("@CreditAmount", SqlDbType.VarChar).Value = Val(txtCreditAmount.Text)
                .Add("@Comment", SqlDbType.VarChar).Value = txtTransactionComment.Text
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                .Add("@GLAccount", SqlDbType.VarChar).Value = cboGLAccountID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempTransactionNumber As Integer = 0
            Dim strTransactionNumber As String
            TempTransactionNumber = Val(cboTransactionNumber.Text)
            strTransactionNumber = CStr(TempTransactionNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Bank Transactions --- Create New Transaction Number"
            ErrorReferenceNumber = "Transaction # " + strTransactionNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        cboTransactionNumber.Text = NextTransactionNumber
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    'Tool Strip Menu Items

    Private Sub ClearBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBatchToolStripMenuItem.Click
        deleteNewUnsavedLine()
        ClearVariables()
        ClearData()
        ShowManualBankTransactions()
    End Sub

    Private Sub SaveBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBatchToolStripMenuItem.Click
        cmdSaveBatch_Click(sender, e)
    End Sub

    Private Sub PrintBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBatchToolStripMenuItem.Click
        cmdPrintBatch_Click(sender, e)
    End Sub

    Private Sub DeleteBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBatchToolStripMenuItem.Click
        cmdDeleteBatch_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

End Class