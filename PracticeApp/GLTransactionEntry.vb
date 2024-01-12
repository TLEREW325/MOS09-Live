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
Public Class GLTransactionEntry
    Inherits System.Windows.Forms.Form

    Dim LongDescription, ItemClass, GLAccount As String
    Dim NextTransactionNumber, LastTransactionNumber As Integer
    Dim UnitCost, UnitPrice, ExtendedCost, ExtendedAmount, Quantity As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub ClearData()
        cboAccountNumber.SelectedIndex = -1
        cboJournalID.SelectedIndex = -1

        txtBatchNumber.Clear()
        txtCredit.Clear()
        txtDebit.Clear()
        txtGLComment.Clear()
        txtGLTransactionDescription.Clear()
        txtGLTransactionKey.Clear()
        txtReferenceLine.Clear()
        txtReferenceNumber.Clear()

        dtpTransactionDate.Text = ""
    End Sub

    Private Sub GLTransactionEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.GLAccounts' table. You can move, or remove it, as needed.
        Me.GLAccountsTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.GLAccounts)

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
                cboDivisionID.Enabled = True
            Else
                cboDivisionID.Enabled = False
            End If

            cboDivisionID.Text = EmployeeCompanyCode
        End If

        ClearData()
    End Sub

    Private Sub cmdAddGLTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddGLTransaction.Click
        'Validate Fields
        If txtGLTransactionKey.Text = "" Then
            MsgBox("You must have a valid transaction number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtCredit.Text = "" And txtDebit.Text = "" Then
            MsgBox("You must enter a credit or debit amount.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If Val(txtCredit.Text) <> 0 And Val(txtDebit.Text) <> 0 Then
            MsgBox("Credit and debit cannont both have a dollar amount.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboJournalID.Text = "" Then
            MsgBox("You must select a valid Journal ID.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Save to database
        Try
            cmd = New SqlCommand("UPDATE GLTransactionMasterList SET GLAccountNumber = @GLAccountNumber, GLTransactionDescription = @GLTransactionDescription, GLTransactionDate = @GLTransactionDate, GLTransactionDebitAmount = @GLTransactionDebitAmount, GLTransactionCreditAmount = @GLTransactionCreditAmount, GLTransactionComment = @GLTransactionComment, GLJournalID = @GLJournalID, GLBatchNumber = @GLBatchNumber, GLReferenceNumber = @GLReferenceNumber, GLReferenceLine = @GLReferenceLine, GLTransactionStatus = @GLTransactionStatus WHERE GLTransactionKey = @GLTransactionKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboAccountNumber.Text
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = txtGLTransactionDescription.Text
                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtDebit.Text)
                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtCredit.Text)
                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtGLComment.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@GLJournalID", SqlDbType.VarChar).Value = cboJournalID.Text
                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = txtBatchNumber.Text
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = txtReferenceNumber.Text
                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = txtReferenceLine.Text
                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Do nothing
        End Try

        'Clear Form
        ClearData()

        MsgBox("GL Transaction added.", MsgBoxStyle.OkOnly)

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

    Public Sub LoadGLJournalID()
        cmd = New SqlCommand("SELECT GLJournalID FROM GLJournals WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLJournals")
        cboJournalID.DataSource = ds.Tables("GLJournals")
        con.Close()
        cboJournalID.SelectedIndex = -1
    End Sub

    Private Sub cmdGenerateTransactionNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateTransactionNumber.Click
        'Get Next Transaction Number
        Dim MAXStatement As String = "SELECT MAX(GLTransactionKey) FROM GLTransactionMasterList"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionNumber = 1000000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        txtGLTransactionKey.Text = NextTransactionNumber

        'Save (INSERT) into database
        Try
            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount, GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)Values(@GLTransactionKey, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount, @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

            With cmd.Parameters
                .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboAccountNumber.Text
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = txtGLTransactionDescription.Text
                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtDebit.Text)
                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtCredit.Text)
                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = txtGLComment.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@GLJournalID", SqlDbType.VarChar).Value = cboJournalID.Text
                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = txtBatchNumber.Text
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = txtReferenceNumber.Text
                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = txtReferenceLine.Text
                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Do nothing
        End Try
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadGLJournalID()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class