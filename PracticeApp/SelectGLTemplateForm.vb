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
Public Class SelectGLTemplateForm
    Inherits System.Windows.Forms.Form

    Dim NextBatchNumber, LastBatchNumber, NextTransactionNumber, LastTransactionNumber As Integer
    Dim JournalID, JournalComment, AccountDescription As String


    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Dim division As String = ""

    Private Sub SelectGLTemplateForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        LoadGLTemplateName()
        ShowData()
    End Sub


    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM GLJournalTemplateLines WHERE GLTemplateName = @GLTemplateName", con)
        cmd.Parameters.Add("@GLTemplateName", SqlDbType.VarChar).Value = cboTemplateName.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLJournalTemplateLines")
        dgvSelectTemplateLines.DataSource = ds.Tables("GLJournalTemplateLines")
        con.Close()
    End Sub


    Public Sub LoadGLTemplateName()
        cmd = New SqlCommand("SELECT TemplateName FROM GLJournalTemplateHeader", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLJournalTemplateHeader")
        cboTemplateName.DataSource = ds3.Tables("GLJournalTemplateHeader")
        con.Close()
        cboTemplateName.SelectedIndex = -1
    End Sub

    Private Sub cmdClearTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearTransaction.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdLoadTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadTemplate.Click
        'Get Template Data
        Dim JournalIDStatement As String = "SELECT TemplateJournal FROM GLJournalTemplateHeader WHERE TemplateName = @TemplateName"
        Dim JournalIDCommand As New SqlCommand(JournalIDStatement, con)
        JournalIDCommand.Parameters.Add("@TemplateName", SqlDbType.VarChar).Value = cboTemplateName.Text

        Dim JournalCommentStatement As String = "SELECT TemplateComment FROM GLJournalTemplateHeader WHERE TemplateName = @TemplateName"
        Dim JournalCommentCommand As New SqlCommand(JournalCommentStatement, con)
        JournalCommentCommand.Parameters.Add("@TemplateName", SqlDbType.VarChar).Value = cboTemplateName.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            JournalID = CStr(JournalIDCommand.ExecuteScalar)
        Catch ex As Exception
            JournalID = "GENERALJOURNAL"
        End Try
        Try
            JournalComment = CStr(JournalCommentCommand.ExecuteScalar)
        Catch ex As Exception
            JournalComment = "General Journal Posting"
        End Try
        con.Close()

        'Get GL Batch Number
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

        'Command to write Header Data
        cmd = New SqlCommand("Insert Into GLJournalHeaderTable (DivisionID, JournalDate, JournalID, JournalComment, GLJournalBatchNumber, GLJournalStatus)values(@DivisionID, @JournalDate, @JournalID, @JournalComment, @GLJournalBatchNumber, @GLJournalStatus)", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            .Add("@JournalDate", SqlDbType.VarChar).Value = Today()
            .Add("@JournalID", SqlDbType.VarChar).Value = JournalID
            .Add("@JournalComment", SqlDbType.VarChar).Value = JournalComment
            .Add("@GLJournalBatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
            .Add("@GLJournalStatus", SqlDbType.VarChar).Value = "OPEN"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Get line data from template
        Dim GLAccountNumber, GLDescription As String
        Dim GLCreditAmount, GLDebitAmount As Double

        For Each row As DataGridViewRow In dgvSelectTemplateLines.Rows
            Try
                GLAccountNumber = row.Cells("GLAccountNumberColumn").Value
            Catch ex As Exception
                GLAccountNumber = ""
            End Try
            Try
                GLDescription = row.Cells("GLTransactionDescriptionColumn").Value
            Catch ex As Exception
                GLDescription = ""
            End Try
            Try
                GLCreditAmount = row.Cells("GLCreditAmountColumn").Value
            Catch ex As Exception
                GLCreditAmount = 0
            End Try
            Try
                GLDebitAmount = row.Cells("GLDebitAmountColumn").Value
            Catch ex As Exception
                GLDebitAmount = 0
            End Try

            'Get GL Account Description for GL Account
            Dim AccountDescriptionStatement As String = "SELECT GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
            Dim AccountDescriptionCommand As New SqlCommand(AccountDescriptionStatement, con)
            AccountDescriptionCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                AccountDescription = CStr(AccountDescriptionCommand.ExecuteScalar)
            Catch ex As Exception
                AccountDescription = ""
            End Try
            con.Close()

            'Extract the next GL Transaction Number
            Dim MAXStatement As String = "SELECT MAX(GLJournalTransactionNumber) FROM GLJournalLineTable WHERE GLBatchNumber = @GLBatchNumber"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)
            MAXCommand.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = NextBatchNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As Exception
                LastTransactionNumber = 41500000
            End Try
            con.Close()

            NextTransactionNumber = LastTransactionNumber + 1

            'Write Data to GL Journal Line Table
            cmd = New SqlCommand("INSERT INTO GLJournalLineTable (GLJournalTransactionNumber, GLDebitAmount, GLCreditAmount, JournalTransactionDescription, GLAccountNumber, GLBatchNumber, GLAccountDescription)values(@GLJournalTransactionNumber, @GLDebitAmount, @GLCreditAmount, @JournalTransactionDescription, @GLAccountNumber, @GLBatchNumber, @GLAccountDescription)", con)

            With cmd.Parameters
                .Add("@GLJournalTransactionNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                .Add("@GLDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                .Add("@JournalTransactionDescription", SqlDbType.VarChar).Value = GLDescription
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAccountNumber
                .Add("@GLAccountDescription", SqlDbType.VarChar).Value = AccountDescription
                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next

        GlobalGLBatchNumber = NextBatchNumber

        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboTemplateName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTemplateName.SelectedIndexChanged
        ShowData()
    End Sub

    Public Sub setDivision(ByVal divis As String)
        division = divis
    End Sub
    Public Function getBatch() As String
        Return NextBatchNumber
    End Function
End Class