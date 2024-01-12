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
Public Class GLJournalTransactions
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim ValidateGLAccount, LastBatchNumber, NextBatchNumber, LastTransactionNumber, NextTransactionNumber, counter, GLReferenceNumber, GLReferenceLine As Integer
    Dim GetJournalStatus, JournalDescription As String
    Dim NextJournalTransactionNumber, LastJournalTransactionNumber, GLBatchNumber, LastGLNumber As Integer
    Dim GLBatchStatus, GLAccountNumber, GLAccountDescription, GLTransactionDescription, GLTransactionDate, GLTransactionComment, GLJournalID As String
    Dim BatchBalance, SUMGLDebitAmount, SUMGLCreditAmount, GLTransactionDebitAmount, GLTransactionCreditAmount As Double
    Dim LineGLJournalTransactionNumber As Integer
    Dim LineJournalTransactionDescription, LineGLAccountNumber, LineGLAccountDescription As String
    Dim LineGLDebitAmount, LineGLCreditAmount As Double
    Dim TodaysDate As Date = Today.ToShortDateString()

    Dim isLoaded As Boolean = False

    Private Sub GLJournalTransactions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearVariables()
        ClearAll()
    End Sub

    Private Sub GLJournalTransactions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        End If

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LoadGLAccountsCanadian()
        Else
            LoadGLAccountsAmerican()
        End If

        If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
            AdminControlToolStripMenuItem.Enabled = True
        Else
            AdminControlToolStripMenuItem.Enabled = False
        End If

        If GlobalGLBatchNumber <> 0 Then
            cboDivisionID.Text = GlobalDivisionCode
            cboGLBatchNumber.Text = GlobalGLBatchNumber
        End If

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

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment.Substring(0, 300)
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvJournalTransactions.CellValueChanged
        If isLoaded Then
            'Check if batch is posted
            Dim GetJournalStatusStatement As String = "SELECT GLJournalStatus FROM GLJournalHeaderTable WHERE GLJournalBatchNumber = @GLJournalBatchNumber AND DivisionID = @DivisionID"
            Dim GetJournalStatusCommand As New SqlCommand(GetJournalStatusStatement, con)
            GetJournalStatusCommand.Parameters.Add("@GLJournalBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
            GetJournalStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetJournalStatus = CStr(GetJournalStatusCommand.ExecuteScalar)
            Catch ex As Exception
                GetJournalStatus = "OPEN"
            End Try
            con.Close()

            If GetJournalStatus = "OPEN" Then
                Dim currentRow As Integer = dgvJournalTransactions.CurrentCell.RowIndex
                Dim currentColumn As Integer = dgvJournalTransactions.CurrentCell.ColumnIndex

                If IsDBNull(dgvJournalTransactions.Rows(currentRow).Cells("GLJournalTransactionNumberColumn").Value) Then
                    LineGLJournalTransactionNumber = 0
                Else
                    LineGLJournalTransactionNumber = dgvJournalTransactions.Rows(currentRow).Cells("GLJournalTransactionNumberColumn").Value
                End If
                If IsDBNull(dgvJournalTransactions.Rows(currentRow).Cells("GLDebitAmountColumn").Value) Then
                    LineGLDebitAmount = 0
                Else
                    LineGLDebitAmount = dgvJournalTransactions.Rows(currentRow).Cells("GLDebitAmountColumn").Value
                End If
                If IsDBNull(dgvJournalTransactions.Rows(currentRow).Cells("GLCreditAmountColumn").Value) Then
                    LineGLCreditAmount = 0
                Else
                    LineGLCreditAmount = dgvJournalTransactions.Rows(currentRow).Cells("GLCreditAmountColumn").Value
                End If
                If IsDBNull(dgvJournalTransactions.Rows(currentRow).Cells("JournalTransactionDescriptionColumn").Value) Then
                    LineJournalTransactionDescription = ""
                Else
                    LineJournalTransactionDescription = dgvJournalTransactions.Rows(currentRow).Cells("JournalTransactionDescriptionColumn").Value
                End If
                If IsDBNull(dgvJournalTransactions.Rows(currentRow).Cells("GLAccountNumberColumn").Value) Then
                    LineGLAccountNumber = ""
                Else
                    LineGLAccountNumber = dgvJournalTransactions.Rows(currentRow).Cells("GLAccountNumberColumn").Value
                End If
                If IsDBNull(dgvJournalTransactions.Rows(currentRow).Cells("GLAccountDescriptionColumn").Value) Then
                    LineGLAccountDescription = ""
                Else
                    LineGLAccountDescription = dgvJournalTransactions.Rows(currentRow).Cells("GLAccountDescriptionColumn").Value
                End If

                Try
                    'UPDATE Journal Lines
                    cmd = New SqlCommand("UPDATE GLJournalLineTable SET GLDebitAmount = @GLDebitAmount, GLCreditAmount = @GLCreditAmount, JournalTransactionDescription = @JournalTransactionDescription, GLAccountNumber = @GLAccountNumber, GLAccountDescription = @GLAccountDescription WHERE GLBatchNumber = @GLBatchNumber AND GLJournalTransactionNumber = @GLJournalTransactionNumber", con)

                    With cmd.Parameters
                        .Add("@GLJournalTransactionNumber", SqlDbType.VarChar).Value = LineGLJournalTransactionNumber
                        .Add("@GLDebitAmount", SqlDbType.VarChar).Value = LineGLDebitAmount
                        .Add("@GLCreditAmount", SqlDbType.VarChar).Value = LineGLCreditAmount
                        .Add("@JournalTransactionDescription", SqlDbType.VarChar).Value = LineJournalTransactionDescription
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineGLAccountNumber
                        .Add("@GLAccountDescription", SqlDbType.VarChar).Value = LineGLAccountDescription
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempGLBatchNumber As Integer = 0
                    Dim strGLBatchNumber As String
                    TempGLBatchNumber = Val(cboGLBatchNumber.Text)
                    strGLBatchNumber = CStr(TempGLBatchNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "GL Journal --- Cell value changed update lines"
                    ErrorReferenceNumber = "Batch # " + strGLBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                    MsgBox("Invalid Data.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End Try
                CalculateBatchTotals()
                isLoaded = False
                ShowData()
                isLoaded = True
                dgvJournalTransactions.CurrentCell = dgvJournalTransactions.Rows(currentRow).Cells(currentColumn)
            End If
        End If
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM GLJournalLineTable WHERE GLBatchNumber = @GLBatchNumber", con)
        cmd.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLJournalLineTable")
        dgvJournalTransactions.DataSource = ds.Tables("GLJournalLineTable")
        cboDeleteLines.DataSource = ds.Tables("GLJournalLineTable")
        con.Close()
        If dgvJournalTransactions.Rows.Count = 0 Then
            If cboDeleteLines.Text <> "" Then
                cboDeleteLines.Text = ""
            End If
        End If
    End Sub

    Public Sub LoadGLAccountsAmerican()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber NOT LIKE 'C$%'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "GLAccounts")
        cboGLAccount.DataSource = ds1.Tables("GLAccounts")
        cboShortDescription.DataSource = ds1.Tables("GLAccounts")
        con.Close()
        cboGLAccount.SelectedIndex = -1
        cboShortDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccountsCanadian()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "GLAccounts")
        cboGLAccount.DataSource = ds1.Tables("GLAccounts")
        cboShortDescription.DataSource = ds1.Tables("GLAccounts")
        con.Close()
        cboGLAccount.SelectedIndex = -1
        cboShortDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadGLJournal()
        cmd = New SqlCommand("SELECT GLJournalID FROM GLJournals WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLJournals")
        cboJournalID.DataSource = ds2.Tables("GLJournals")
        con.Close()
        cboJournalID.SelectedIndex = -1
    End Sub

    Public Sub LoadGLBatchNumber()
        cmd = New SqlCommand("SELECT DISTINCT GLJournalBatchNumber FROM GLJournalHeaderTable WHERE DivisionID = @DivisionID AND GLJournalStatus = @GLJournalStatus", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@GLJournalStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLJournalHeaderTable")
        cboGLBatchNumber.DataSource = ds3.Tables("GLJournalHeaderTable")
        con.Close()
        cboGLBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub ClearLines()
        cboGLAccount.SelectedIndex = -1
        cboShortDescription.SelectedIndex = -1
        txtCreditAmount.Clear()
        txtDebitAmount.Clear()
        txtGLAccountDescription.Clear()
        txtGLTransactionDescription.Text = "GL Journal Posting"
        cboGLAccount.Focus()
    End Sub

    Public Sub ClearAll()
        cboGLAccount.Refresh()
        cboJournalID.Refresh()
        cboShortDescription.Refresh()
        cboGLBatchNumber.Refresh()
        cboGLBatchNumber.Text = ""
        cboJournalID.Text = ""

        txtBatchBalance.Refresh()
        txtCreditAmount.Refresh()
        txtCreditTotal.Refresh()
        txtDebitAmount.Refresh()
        txtDebitTotal.Refresh()
        txtGLAccountDescription.Refresh()
        txtGLComment.Refresh()
        txtGLTransactionDescription.Refresh()

        cboGLAccount.SelectedIndex = -1
        cboJournalID.SelectedIndex = -1
        cboShortDescription.SelectedIndex = -1
        cboGLBatchNumber.SelectedIndex = -1
        cboDeleteLines.SelectedIndex = -1
        cboDeleteLines.Text = ""

        txtBatchBalance.Clear()
        txtCreditAmount.Clear()
        txtCreditTotal.Clear()
        txtDebitAmount.Clear()
        txtDebitTotal.Clear()
        txtGLAccountDescription.Clear()
        txtGLComment.Clear()
        txtGLTransactionDescription.Text = "GL Journal Posting"
        txtBatchStatus.Clear()
        ReversalCheckBox.CheckState = CheckState.Unchecked

        dtpPostingDate.Text = Today()
        DTPReversalDate.Text = Today()

        chkAdminControl.Checked = False

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LoadGLAccountsCanadian()
        Else
            LoadGLAccountsAmerican()
        End If

        If GLBatchStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdEnterTransaction.Enabled = False
            cmdSave.Enabled = False
            cmdPostTransactions.Enabled = False
            SaveBatchToolStripMenuItem.Enabled = False
            DeleteBatchToolStripMenuItem.Enabled = False
            dgvJournalTransactions.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnterTransaction.Enabled = True
            cmdSave.Enabled = True
            cmdPostTransactions.Enabled = True
            SaveBatchToolStripMenuItem.Enabled = True
            DeleteBatchToolStripMenuItem.Enabled = True
            dgvJournalTransactions.Enabled = True
        End If

        cmdGenerateTransactionNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        LastBatchNumber = 0
        NextBatchNumber = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        counter = 0
        GLReferenceNumber = 0
        GLReferenceLine = 0
        JournalDescription = ""
        GLAccountNumber = ""
        GLBatchNumber = 0
        LastGLNumber = 0
        GLAccountDescription = ""
        GLTransactionDescription = ""
        GLTransactionDate = ""
        GLTransactionComment = ""
        GLJournalID = ""
        GLBatchStatus = ""
        BatchBalance = 0
        SUMGLDebitAmount = 0
        SUMGLCreditAmount = 0
        GLTransactionDebitAmount = 0
        GLTransactionCreditAmount = 0
        GetJournalStatus = ""
        ValidateGLAccount = 0
        GlobalGLBatchNumber = 0

        If GLBatchStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdEnterTransaction.Enabled = False
            cmdSave.Enabled = False
            cmdPostTransactions.Enabled = False
            SaveBatchToolStripMenuItem.Enabled = False
            DeleteBatchToolStripMenuItem.Enabled = False
            dgvJournalTransactions.Enabled = False

        Else
            cmdDelete.Enabled = True
            cmdEnterTransaction.Enabled = True
            cmdSave.Enabled = True
            cmdPostTransactions.Enabled = True
            SaveBatchToolStripMenuItem.Enabled = True
            DeleteBatchToolStripMenuItem.Enabled = True
            dgvJournalTransactions.Enabled = True
        End If
    End Sub

    Public Sub LoadGLBatchData()
        Dim GLTransactionDateStatement As String = "SELECT JournalDate, JournalComment, JournalID, GLJournalStatus FROM GLJournalHeaderTable WHERE GLJournalBatchNumber = @GLJournalBatchNumber AND DivisionID = @DivisionID"
        Dim GLTransactionDateCommand As New SqlCommand(GLTransactionDateStatement, con)
        GLTransactionDateCommand.Parameters.Add("@GLJournalBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
        GLTransactionDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GLTransactionDateCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.GetValue(0)) Then
                GLTransactionDate = ""
            Else
                GLTransactionDate = reader.GetValue(0)
            End If
            If IsDBNull(reader.GetValue(1)) Then
                GLTransactionComment = ""
            Else
                GLTransactionComment = reader.GetValue(1)
            End If
            If IsDBNull(reader.GetValue(2)) Then
                GLJournalID = ""
            Else
                GLJournalID = reader.GetValue(2)
            End If
            If IsDBNull(reader.GetValue(3)) Then
                GLBatchStatus = "OPEN"
            Else
                GLBatchStatus = reader.GetValue(3)
            End If
        Else
            GLTransactionDate = ""
            GLTransactionComment = ""
            GLJournalID = ""
            GLBatchStatus = "OPEN"
        End If
        reader.Close()
        con.Close()

        cboJournalID.Text = GLJournalID
        txtGLComment.Text = GLTransactionComment
        dtpPostingDate.Text = GLTransactionDate
        txtBatchStatus.Text = GLBatchStatus

        If GLBatchStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdEnterTransaction.Enabled = False
            cmdSave.Enabled = False
            cmdPostTransactions.Enabled = False
            SaveBatchToolStripMenuItem.Enabled = False
            DeleteBatchToolStripMenuItem.Enabled = False
            dgvJournalTransactions.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnterTransaction.Enabled = True
            cmdSave.Enabled = True
            cmdPostTransactions.Enabled = True
            SaveBatchToolStripMenuItem.Enabled = True
            DeleteBatchToolStripMenuItem.Enabled = True
            dgvJournalTransactions.Enabled = True
        End If
    End Sub

    Public Sub LoadBatchStatus()
        Dim GLBatchStatusStatement As String = "SELECT GLJournalStatus FROM GLJournalHeaderTable WHERE GLJournalBatchNumber = @GLJournalBatchNumber AND DivisionID = @DivisionID"
        Dim GLBatchStatusCommand As New SqlCommand(GLBatchStatusStatement, con)
        GLBatchStatusCommand.Parameters.Add("@GLJournalBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
        GLBatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GLBatchStatus = CStr(GLBatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            GLBatchStatus = "OPEN"
        End Try
        con.Close()

        txtBatchStatus.Text = GLBatchStatus

        If GLBatchStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdEnterTransaction.Enabled = False
            cmdSave.Enabled = False
            cmdPostTransactions.Enabled = False
            SaveBatchToolStripMenuItem.Enabled = False
            DeleteBatchToolStripMenuItem.Enabled = False
            dgvJournalTransactions.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnterTransaction.Enabled = True
            cmdSave.Enabled = True
            cmdPostTransactions.Enabled = True
            SaveBatchToolStripMenuItem.Enabled = True
            DeleteBatchToolStripMenuItem.Enabled = True
            dgvJournalTransactions.Enabled = True
        End If
    End Sub

    Public Sub CalculateBatchTotals()
        SUMGLDebitAmount = 0
        SUMGLCreditAmount = 0

        Dim SUMDebitAmountStatement As String = "SELECT SUM(GLDebitAmount), SUM(GLCreditAmount) FROM GLJournalLineTable WHERE GLBatchNumber = @GLBatchNumber"
        Dim SUMDebitAmountCommand As New SqlCommand(SUMDebitAmountStatement, con)
        SUMDebitAmountCommand.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = SUMDebitAmountCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.GetValue(0)) Then
                SUMGLDebitAmount = 0
            Else
                SUMGLDebitAmount = reader.GetValue(0)
            End If
            If IsDBNull(reader.GetValue(1)) Then
                SUMGLCreditAmount = 0
            Else
                SUMGLCreditAmount = reader.GetValue(1)
            End If
        Else
            SUMGLDebitAmount = 0
            SUMGLCreditAmount = 0
        End If
        reader.Close()
        con.Close()

        txtCreditTotal.Text = SUMGLCreditAmount
        txtDebitTotal.Text = SUMGLDebitAmount

        'Calculate Balance
        BatchBalance = 0
        BatchBalance = Val(txtDebitTotal.Text) - Val(txtCreditTotal.Text)
        If BatchBalance < 0 Then
            BatchBalance = BatchBalance * -1
        End If

        txtCreditTotal.Text = FormatCurrency(SUMGLCreditAmount, 2)
        txtDebitTotal.Text = FormatCurrency(SUMGLDebitAmount, 2)
        txtBatchBalance.Text = FormatCurrency(BatchBalance, 2)
    End Sub

    Private Sub cmdGenerateTransactionNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateTransactionNumber.Click
        'Clear form for next number
        ClearVariables()
        ClearAll()

        'Get next Batch Number
        Dim MAXBatchStatement As String = "SELECT MAX(GLJournalBatchNumber) FROM GLJournalHeaderTable"
        Dim MAXBatchCommand As New SqlCommand(MAXBatchStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(MAXBatchCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 358000000
        End Try
        con.Close()

        NextBatchNumber = LastBatchNumber + 1
        cboGLBatchNumber.Text = NextBatchNumber
        Try
            'Command to write Header Data
            cmd = New SqlCommand("Insert Into GLJournalHeaderTable (DivisionID, JournalDate, JournalID, JournalComment, GLJournalBatchNumber, GLJournalStatus)values(@DivisionID, @JournalDate, @JournalID, @JournalComment, @GLJournalBatchNumber, @GLJournalStatus)", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@JournalDate", SqlDbType.VarChar).Value = dtpPostingDate.Text
                .Add("@JournalID", SqlDbType.VarChar).Value = cboJournalID.Text
                .Add("@JournalComment", SqlDbType.VarChar).Value = txtGLTransactionDescription.Text
                .Add("@GLJournalBatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                .Add("@GLJournalStatus", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempGLBatchNumber As Integer = 0
            Dim strGLBatchNumber As String
            TempGLBatchNumber = Val(cboGLBatchNumber.Text)
            strGLBatchNumber = CStr(TempGLBatchNumber)

            ErrorDate = TodaysDate
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "GL Journal --- Create New Transaction"
            ErrorReferenceNumber = "Batch # " + strGLBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        isLoaded = False
        LoadGLBatchNumber()
        cboGLBatchNumber.Text = NextBatchNumber
        isLoaded = True
    End Sub

    Private Sub cmdClearTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearTransaction.Click
        ClearLines()
    End Sub

    Private Sub txtDebitAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDebitAmount.TextChanged
        If Val(txtDebitAmount.Text) <> 0 Then txtCreditAmount.Text = 0
    End Sub

    Private Sub txtCreditAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditAmount.TextChanged
        If Val(txtCreditAmount.Text) <> 0 Then txtDebitAmount.Text = 0
    End Sub

    Private Sub cmdEnterTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterTransaction.Click
        If canEnterTransaction() Then
            'Extract the next GL Transaction Number
            Dim MAXStatement As String = "SELECT MAX(GLJournalTransactionNumber) FROM GLJournalLineTable WHERE GLBatchNumber = @GLBatchNumber"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)
            MAXCommand.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastJournalTransactionNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As Exception
                LastJournalTransactionNumber = 41500000
            End Try
            con.Close()

            NextJournalTransactionNumber = LastJournalTransactionNumber + 1

            Try
                'Write Data to GL Journal Line Table
                cmd = New SqlCommand("INSERT INTO GLJournalLineTable (GLJournalTransactionNumber, GLDebitAmount, GLCreditAmount, JournalTransactionDescription, GLAccountNumber, GLBatchNumber, GLAccountDescription)values(@GLJournalTransactionNumber, @GLDebitAmount, @GLCreditAmount, @JournalTransactionDescription, @GLAccountNumber, @GLBatchNumber, @GLAccountDescription)", con)

                With cmd.Parameters
                    .Add("@GLJournalTransactionNumber", SqlDbType.VarChar).Value = NextJournalTransactionNumber
                    .Add("@GLDebitAmount", SqlDbType.VarChar).Value = Val(txtDebitAmount.Text)
                    .Add("@GLCreditAmount", SqlDbType.VarChar).Value = Val(txtCreditAmount.Text)
                    .Add("@JournalTransactionDescription", SqlDbType.VarChar).Value = txtGLTransactionDescription.Text
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                    .Add("@GLAccountDescription", SqlDbType.VarChar).Value = cboShortDescription.Text
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Verify data and clear text boxes
                CalculateBatchTotals()
                ClearLines()
                ShowData()
            Catch ex As Exception
                'Log error on update failure
                Dim TempGLBatchNumber As Integer = 0
                Dim strGLBatchNumber As String
                TempGLBatchNumber = Val(cboGLBatchNumber.Text)
                strGLBatchNumber = CStr(TempGLBatchNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "GL Journal --- Add line"
                ErrorReferenceNumber = "Batch # " + strGLBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Data has not been entered - check all values and try to re-enter", MsgBoxStyle.OkOnly)
                cboGLBatchNumber.Focus()
            End Try
        End If
    End Sub

    Private Function canEnterTransaction() As Boolean
        If String.IsNullOrEmpty(cboGLBatchNumber.Text) Then
            MessageBox.Show("You must select a batch number", "Select a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.Focus()
            Return False
        End If
        If cboGLBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.SelectAll()
            cboGLBatchNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboGLAccount.Text) Then
            MessageBox.Show("You must select an account", "Select an account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLAccount.Focus()
            Return False
        End If
        'Validate GL Account
        Dim ValidateGLAccountStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim ValidateGLAccountCommand As New SqlCommand(ValidateGLAccountStatement, con)
        ValidateGLAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ValidateGLAccount = CInt(ValidateGLAccountCommand.ExecuteScalar)
        Catch ex As Exception
            ValidateGLAccount = 0
        End Try
        con.Close()

        If ValidateGLAccount <> 1 Then
            MessageBox.Show("You must enter a valid account number", "Enter a valid account number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLAccount.SelectAll()
            cboGLAccount.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdPostTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostTransactions.Click
        If canPost() Then
            Try
                For Each row As DataGridViewRow In dgvJournalTransactions.Rows
                    Try
                        LineGLJournalTransactionNumber = row.Cells("GLJournalTransactionNumberColumn").Value
                    Catch ex As Exception
                        LineGLJournalTransactionNumber = 0
                    End Try
                    Try
                        LineGLDebitAmount = row.Cells("GLDebitAmountColumn").Value
                    Catch ex As Exception
                        LineGLDebitAmount = 0
                    End Try
                    Try
                        LineGLCreditAmount = row.Cells("GLCreditAmountColumn").Value
                    Catch ex As Exception
                        LineGLCreditAmount = 0
                    End Try
                    Try
                        LineJournalTransactionDescription = row.Cells("JournalTransactionDescriptionColumn").Value
                    Catch ex As Exception
                        LineJournalTransactionDescription = ""
                    End Try
                    Try
                        LineGLAccountNumber = row.Cells("GLAccountNumberColumn").Value
                    Catch ex As Exception
                        LineGLAccountNumber = ""
                    End Try
                    Try
                        LineGLAccountDescription = row.Cells("GLAccountDescriptionColumn").Value
                    Catch ex As Exception
                        LineGLAccountDescription = ""
                    End Try
                    '***************************************************************************************************
                    'Validate GL Account
                    Dim CountLineAccountNumber As Integer = 0

                    Dim CountLineAccountNumberStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
                    Dim CountLineAccountNumberCommand As New SqlCommand(CountLineAccountNumberStatement, con)
                    CountLineAccountNumberCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineGLAccountNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountLineAccountNumber = CInt(CountLineAccountNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        CountLineAccountNumber = 0
                    End Try

                    If CountLineAccountNumber = 0 Then
                        MsgBox("Invalid GL Account. Correct and try again.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    Else
                        'Do Nothing
                    End If
                    '***************************************************************************************************
                    If LineJournalTransactionDescription = "" Then
                        LineJournalTransactionDescription = "GENERAL JOURNAL ENTRY"
                    End If

                    Try
                        'UPDATE Purchase Order Extended Amount based on line changes
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineGLAccountNumber
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = LineJournalTransactionDescription
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpPostingDate.Text
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineGLDebitAmount
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineGLCreditAmount
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtGLComment.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = cboJournalID.Text
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = LineGLJournalTransactionNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Try again it first posting fails
                        Try
                            'UPDATE Purchase Order Extended Amount based on line changes
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineGLAccountNumber
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = LineJournalTransactionDescription
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpPostingDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineGLDebitAmount
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineGLCreditAmount
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtGLComment.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = cboJournalID.Text
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = LineGLJournalTransactionNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex10 As Exception
                            'Log error on update failure
                            Dim TempGLBatchNumber As Integer = 0
                            Dim strGLBatchNumber As String
                            TempGLBatchNumber = Val(cboGLBatchNumber.Text)
                            strGLBatchNumber = CStr(TempGLBatchNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex10.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "GL Journal --- Ledger Posting"
                            ErrorReferenceNumber = "Shipment # " + strGLBatchNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    End Try
                    '**************************************************************************************************************
                    'If Transaction will reverse, write to transaction Table
                    If ReversalCheckBox.CheckState = CheckState.Checked Then
                        Try
                            'UPDATE GL Transaction Master List
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineGLAccountNumber
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = LineJournalTransactionDescription & " - REVERSAL"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = DTPReversalDate.Text
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineGLCreditAmount
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineGLDebitAmount
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "REVERSAL " & txtGLComment.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = cboJournalID.Text
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = LineGLJournalTransactionNumber
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'If it fails, try again
                            Try
                                'UPDATE GL Transaction Master List
                                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                With cmd.Parameters
                                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineGLAccountNumber
                                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = LineJournalTransactionDescription & " - REVERSAL"
                                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = DTPReversalDate.Text
                                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineGLCreditAmount
                                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineGLDebitAmount
                                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "REVERSAL " & txtGLComment.Text
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    .Add("@GLJournalID", SqlDbType.VarChar).Value = cboJournalID.Text
                                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = LineGLJournalTransactionNumber
                                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex10 As Exception
                                'Log error on update failure
                                Dim TempGLBatchNumber As Integer = 0
                                Dim strGLBatchNumber As String
                                TempGLBatchNumber = Val(cboGLBatchNumber.Text)
                                strGLBatchNumber = CStr(TempGLBatchNumber)

                                ErrorDate = TodaysDate
                                ErrorComment = ex10.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "GL Journal --- Ledger Posting"
                                ErrorReferenceNumber = "Shipment # " + strGLBatchNumber
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                    End If
                    '************************************************************************************************
                    Try
                        'Command to write Header Data
                        cmd = New SqlCommand("UPDATE GLJournalHeaderTable SET JournalDate = @JournalDate, JournalID = @JournalID, JournalComment = @JournalComment, GLJournalStatus = @GLJournalStatus, PrintDate = @PrintDate, PostedBy = @PostedBy WHERE GLJournalBatchNumber = @GLJournalBatchNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@JournalDate", SqlDbType.VarChar).Value = dtpPostingDate.Text
                            .Add("@JournalID", SqlDbType.VarChar).Value = cboJournalID.Text
                            .Add("@JournalComment", SqlDbType.VarChar).Value = txtGLComment.Text
                            .Add("@GLJournalBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                            .Add("@GLJournalStatus", SqlDbType.VarChar).Value = "POSTED"
                            .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
                            .Add("@PostedBy", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempGLBatchNumber As Integer = 0
                        Dim strGLBatchNumber As String
                        TempGLBatchNumber = Val(cboGLBatchNumber.Text)
                        strGLBatchNumber = CStr(TempGLBatchNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "GL Journal --- Update Journal Header Table"
                        ErrorReferenceNumber = "Shipment # " + strGLBatchNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Next
                '*********************************************************************************************************
                MsgBox("Batch has posted and posting will print.", MsgBoxStyle.OkOnly)

                'Clear Variables and reset form
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    LoadGLAccountsCanadian()
                Else
                    LoadGLAccountsAmerican()
                End If

                LoadGLJournal()
                LoadGLBatchNumber()
                ClearAll()
                ClearVariables()
                ShowData()
                cboGLBatchNumber.Enabled = True
                ShowData()
            Catch ex As Exception
                MsgBox("There was an error saving this data - please re-check and save again.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Function canPost() As Boolean
        If String.IsNullOrEmpty(cboGLBatchNumber.Text) Then
            MessageBox.Show("You must select a batch number to post", "Select a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.Focus()
            Return False
        End If
        If cboGLBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid batch number to post", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.SelectAll()
            cboGLBatchNumber.Focus()
            Return False
        End If
        If dgvJournalTransactions.Rows.Count = 0 Then
            MessageBox.Show("You must add some transactions in order to be able to post", "Enter some transactions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLAccount.Focus()
            Return False
        End If
        getStatus()
        If GetJournalStatus <> "OPEN" Then
            MessageBox.Show("You can't post a batch that is not open", "Batch already posted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.SelectAll()
            cboGLBatchNumber.Focus()
            Return False
        End If
        CalculateBatchTotals()
        If chkAdminControl.Checked = True Then
            'Skip Balance Validation - allow unbalanced post
        Else
            If txtBatchBalance.Text <> 0 Then
                MessageBox.Show("Balance is not 0. Unable to post with a balance other than 0", "Not balanced", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboGLAccount.Focus()
                Return False
            End If
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to POST this Journal Batch?", "POST JOURNAL BATCH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        ClearVariables()
        ClearAll()
        ShowData()
    End Sub

    Private Sub cboGLBatchNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGLBatchNumber.SelectedIndexChanged
        If isLoaded Then
            isLoaded = False
            LoadBatchStatus()
            LoadGLBatchData()
            CalculateBatchTotals()
            ShowData()
            isLoaded = True
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearAll()
        ShowData()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LoadGLAccountsCanadian()
        Else
            LoadGLAccountsAmerican()
        End If

        LoadGLJournal()
        LoadGLBatchNumber()
        ClearAll()
        ShowData()
    End Sub

    Private Sub cboGLAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGLAccount.SelectedIndexChanged
        If isLoaded Then
            Dim GLAccountDescriptionStatement As String = "SELECT GLAccountDescription FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
            Dim GLAccountDescriptionCommand As New SqlCommand(GLAccountDescriptionStatement, con)
            GLAccountDescriptionCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GLAccountDescription = CStr(GLAccountDescriptionCommand.ExecuteScalar)
            Catch ex As Exception
                GLAccountDescription = ""
            End Try
            con.Close()

            txtGLAccountDescription.Text = GLAccountDescription
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSave() Then
            Try
                'Command to write Header Data
                cmd = New SqlCommand("UPDATE GLJournalHeaderTable SET DivisionID = @DivisionID, JournalDate = @JournalDate, JournalID = @JournalID, JournalComment = @JournalComment, GLJournalStatus = @GLJournalStatus WHERE GLJournalBatchNumber = @GLJournalBatchNumber", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@JournalDate", SqlDbType.VarChar).Value = dtpPostingDate.Text
                    .Add("@JournalID", SqlDbType.VarChar).Value = cboJournalID.Text
                    .Add("@JournalComment", SqlDbType.VarChar).Value = txtGLComment.Text
                    .Add("@GLJournalBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                    .Add("@GLJournalStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Verify data and clear text boxes
                MsgBox("Data has been saved into Journal and is ready to be posted.", MsgBoxStyle.OkOnly)
                CalculateBatchTotals()
                ClearLines()
                ShowData()
            Catch ex As Exception
                'Log error on update failure
                Dim TempGLBatchNumber As Integer = 0
                Dim strGLBatchNumber As String
                TempGLBatchNumber = Val(cboGLBatchNumber.Text)
                strGLBatchNumber = CStr(TempGLBatchNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "GL Journal --- Save Button update Journal Header"
                ErrorReferenceNumber = "Batch # " + strGLBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboGLBatchNumber.Text) Then
            MessageBox.Show("You must select a batch number", "Select a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.Focus()
            Return False
        End If
        If cboGLBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.SelectAll()
            cboGLBatchNumber.Focus()
            Return False
        End If
        getStatus()
        If GetJournalStatus <> "OPEN" Then
            MessageBox.Show("You must select a batch that has a status of OPEN in order to save.", "Select a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.SelectAll()
            cboGLBatchNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub getStatus()
        'Check if batch is posted
        Dim GetJournalStatusStatement As String = "SELECT GLJournalStatus FROM GLJournalHeaderTable WHERE GLJournalBatchNumber = @GLJournalBatchNumber AND DivisionID = @DivisionID"
        Dim GetJournalStatusCommand As New SqlCommand(GetJournalStatusStatement, con)
        GetJournalStatusCommand.Parameters.Add("@GLJournalBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
        GetJournalStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetJournalStatus = CStr(GetJournalStatusCommand.ExecuteScalar)
        Catch ex As Exception
            GetJournalStatus = "OPEN"
        End Try
        con.Close()
    End Sub

    Private Sub SaveBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBatchToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub cmdDeleteTransactionLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteTransactionLine.Click
        If canDeleteLine() Then
            Try
                cmd = New SqlCommand("DELETE FROM GLJournalLineTable WHERE GLBatchNumber = @GLBatchNumber AND GLJournalTransactionNumber = @GLJournalTransactionNumber", con)
                cmd.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                cmd.Parameters.Add("@GLJournalTransactionNumber", SqlDbType.VarChar).Value = Val(cboDeleteLines.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

            Catch ex As Exception
                'Log error on update failure
                Dim TempGLBatchNumber As Integer = 0
                Dim strGLBatchNumber As String
                TempGLBatchNumber = Val(cboGLBatchNumber.Text)
                strGLBatchNumber = CStr(TempGLBatchNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "GL Journal --- Delete Line failure"
                ErrorReferenceNumber = "Batch # " + strGLBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            'Refresh grid and update total
            ShowData()
            CalculateBatchTotals()

            'Verify deletion and clear text boxes
            MsgBox("Line Data has been deleted", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canDeleteLine() As Boolean
        If String.IsNullOrEmpty(cboGLBatchNumber.Text) Then
            MessageBox.Show("You must select a batch number", "Select a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.Focus()
            Return False
        End If
        If cboGLBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.SelectAll()
            cboGLBatchNumber.Focus()
            Return False
        End If
        getStatus()
        If GetJournalStatus <> "OPEN" Then
            MessageBox.Show("You must select a batch that has a status of OPEN in order to delete.", "Select a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.SelectAll()
            cboGLBatchNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboDeleteLines.Text) Then
            MessageBox.Show("You must select a transaction to delete", "Select a transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteLines.Focus()
            Return False
        End If
        If cboDeleteLines.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid transaction number to delete", "Enter a valid transaction number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteLines.SelectAll()
            cboDeleteLines.Focus()
            Return False
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Journal Transaction?", "DELETE JOURNAL TRANSACTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If canDeleteBatch() Then
            '*****************************************************************************************************
            'Write to Audit Trail Table
            Dim AuditComment As String = ""
            Dim AuditBatchNumber As Integer = 0
            Dim strBatchNumber As String = ""

            AuditBatchNumber = Val(cboGLBatchNumber.Text)
            strBatchNumber = CStr(AuditBatchNumber)
            AuditComment = "GL Journal Batch #" + strBatchNumber + " was deleted on " + Today()

            Try
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "GL JOURNAL - DELETION"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strBatchNumber
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
            '*****************************************************************************************************
            Try
                'Delete Data to GL Master List
                cmd = New SqlCommand("DELETE FROM GLJournalHeaderTable WHERE GLJournalBatchNumber = @GLJournalBatchNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@GLJournalBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempGLBatchNumber As Integer = 0
                Dim strGLBatchNumber As String
                TempGLBatchNumber = Val(cboGLBatchNumber.Text)
                strGLBatchNumber = CStr(TempGLBatchNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "GL Journal --- Delete Button"
                ErrorReferenceNumber = "Batch # " + strGLBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MessageBox.Show("There was a problem deleting the batch. Contact system admin", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'Verify deletion and clear text boxes
            MsgBox("Journal Data has been deleted", MsgBoxStyle.OkOnly)
            ClearVariables()
            ClearAll()
            LoadGLBatchNumber()
            ShowData()
        End If
    End Sub

    Private Function canDeleteBatch() As Boolean
        If String.IsNullOrEmpty(cboGLBatchNumber.Text) Then
            MessageBox.Show("You must select a batch number", "Select a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.Focus()
            Return False
        End If
        If cboGLBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.SelectAll()
            cboGLBatchNumber.Focus()
            Return False
        End If
        getStatus()
        If GetJournalStatus <> "OPEN" Then
            MessageBox.Show("You must select a batch that has a status of OPEN in order to delete.", "Select a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboGLBatchNumber.SelectAll()
            cboGLBatchNumber.Focus()
            Return False
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Journal Batch?", "DELETE JOURNAL TRANSACTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub DeleteBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBatchToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboGLBatchNumber.Text = "" Or GetJournalStatus <> "OPEN" Then
            'Print without saving
            GDS = ds
            GlobalGLBatchNumber = Val(cboGLBatchNumber.Text)
            Using NewPrintGLJournalFiltered As New PrintGLJournalFiltered
                Dim Result = NewPrintGLJournalFiltered.ShowDialog()
            End Using
        Else
            Try
                'Command to write Header Data
                cmd = New SqlCommand("UPDATE GLJournalHeaderTable SET DivisionID = @DivisionID, JournalDate = @JournalDate, JournalID = @JournalID, JournalComment = @JournalComment, GLJournalStatus = @GLJournalStatus WHERE GLJournalBatchNumber = @GLJournalBatchNumber", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@JournalDate", SqlDbType.VarChar).Value = dtpPostingDate.Text
                    .Add("@JournalID", SqlDbType.VarChar).Value = cboJournalID.Text
                    .Add("@JournalComment", SqlDbType.VarChar).Value = txtGLComment.Text
                    .Add("@GLJournalBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                    .Add("@GLJournalStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempGLBatchNumber As Integer = 0
                Dim strGLBatchNumber As String
                TempGLBatchNumber = Val(cboGLBatchNumber.Text)
                strGLBatchNumber = CStr(TempGLBatchNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "GL Journal --- Print Button update Journal Header"
                ErrorReferenceNumber = "Batch # " + strGLBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            GDS = ds
            GlobalGLBatchNumber = Val(cboGLBatchNumber.Text)
            Using NewPrintGLJournalFiltered As New PrintGLJournalFiltered
                Dim Result = NewPrintGLJournalFiltered.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub PrintBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBatchToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearAll()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearAll()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub SelectTemplateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectTemplateToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text

        Dim NewSelectGLTemplateForm As New SelectGLTemplateForm
        Me.Hide()
        Dim result = NewSelectGLTemplateForm.ShowDialog()
        If result = Windows.Forms.DialogResult.Yes Then
            isLoaded = False
            LoadGLBatchNumber()
            isLoaded = True
            cboGLBatchNumber.Text = NewSelectGLTemplateForm.getBatch()
        End If
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub DeleteMultipleLinesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMultipleLinesToolStripMenuItem.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete the selected rows?", "DELETE ROWS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            For Each row As DataGridViewRow In Me.dgvJournalTransactions.SelectedRows
                Try
                    LineGLJournalTransactionNumber = row.Cells("GLJournalTransactionNumberColumn").Value
                Catch ex As Exception
                    LineGLJournalTransactionNumber = 0
                End Try
                Try
                    cmd = New SqlCommand("DELETE FROM GLJournalLineTable WHERE GLBatchNumber = @GLBatchNumber AND GLJournalTransactionNumber = @GLJournalTransactionNumber", con)
                    cmd.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboGLBatchNumber.Text)
                    cmd.Parameters.Add("@GLJournalTransactionNumber", SqlDbType.VarChar).Value = LineGLJournalTransactionNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempGLBatchNumber As Integer = 0
                    Dim strGLBatchNumber As String
                    TempGLBatchNumber = Val(cboGLBatchNumber.Text)
                    strGLBatchNumber = CStr(TempGLBatchNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "GL Journal --- Delete Multiple Lines"
                    ErrorReferenceNumber = "Batch # " + strGLBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MessageBox.Show("There was a problem deleting the lines. Contact system admin", "Unable to delete selected lines", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            Next

            ShowData()
        ElseIf button = DialogResult.No Then
            'Do nothing
            cboGLAccount.Focus()
        End If
    End Sub

    Private Sub AdminControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminControlToolStripMenuItem.Click
        chkAdminControl.Enabled = True
    End Sub
End Class