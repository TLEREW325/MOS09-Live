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
Public Class GLTransactionTemplate
    Inherits System.Windows.Forms.Form

    Dim VerifyGLAccount, NextLineNumber, LastLineNumber As Integer
    Dim TemplateDate, TemplateJournal, TemplateComment As String
    Dim TotalDebits, TotalCredits, Difference As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Private Sub GLTransactionTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        If EmployeeCompanyCode = "ADM" Then
            txtDivisionID.Text = EmployeeCompanyCode
            txtDivisionID.Enabled = True
        Else
            txtDivisionID.Text = EmployeeCompanyCode
            txtDivisionID.Enabled = False
        End If

        ClearData()
        ClearVariables()
        LoadGLTemplateName()
        LoadGLAccounts()
        LoadInsertGLAccounts()
        LoadGLJournal()
        ShowData()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM GLJournalTemplateLines WHERE GLTemplateName = @GLTemplateName", con)
        cmd.Parameters.Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLJournalTemplateLines")
        dgvTemplateLines.DataSource = ds.Tables("GLJournalTemplateLines")
        cboDeleteLine.DataSource = ds.Tables("GLJournalTemplateLines")
        con.Close()
        LoadTemplateTotals()
    End Sub

    Public Sub LoadGLAccounts()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "GLAccounts")
        cboGLAccount.DataSource = ds1.Tables("GLAccounts")
        cboGLDescription.DataSource = ds1.Tables("GLAccounts")
        con.Close()
        cboGLAccount.SelectedIndex = -1
        cboGLDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadGLJournal()
        cmd = New SqlCommand("SELECT GLJournalID FROM GLJournals WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLJournals")
        cboGLJournalID.DataSource = ds2.Tables("GLJournals")
        con.Close()
        cboGLJournalID.SelectedIndex = -1
    End Sub

    Public Sub LoadGLTemplateName()
        cmd = New SqlCommand("SELECT TemplateName FROM GLJournalTemplateHeader", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLJournalTemplateHeader")
        cboGLTemplateName.DataSource = ds3.Tables("GLJournalTemplateHeader")
        con.Close()
        cboGLTemplateName.SelectedIndex = -1
    End Sub

    Public Sub LoadInsertGLAccounts()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "GLAccounts")
        cboInsertGLAccount.DataSource = ds4.Tables("GLAccounts")
        cboInsertGLDescription.DataSource = ds4.Tables("GLAccounts")
        con.Close()
        cboInsertGLAccount.SelectedIndex = -1
        cboInsertGLDescription.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboDeleteLine.SelectedIndex = -1
        cboGLAccount.SelectedIndex = -1
        cboGLDescription.SelectedIndex = -1
        cboGLJournalID.SelectedIndex = -1
        cboGLTemplateName.SelectedIndex = -1
        cboInsertGLAccount.SelectedIndex = -1
        cboInsertGLDescription.SelectedIndex = -1

        txtInsertComment.Clear()
        txtInsertCredit.Clear()
        txtInsertDebit.Clear()
        txtCreditAmount.Clear()
        txtDebitAmount.Clear()
        txtJournalComment.Clear()
        txtTransactionComment.Clear()

        cboGLTemplateName.Focus()
    End Sub

    Public Sub ClearVariables()
        VerifyGLAccount = 0
        NextLineNumber = 0
        LastLineNumber = 0
        TemplateDate = ""
        TemplateJournal = ""
        TemplateComment = ""
    End Sub

    Public Sub ClearLines()
        cboGLAccount.SelectedIndex = -1
        cboGLDescription.SelectedIndex = -1
        txtCreditAmount.Clear()
        txtDebitAmount.Clear()
        txtTransactionComment.Clear()
        cboGLAccount.Focus()
    End Sub

    Public Sub ClearInsertLines()
        cboInsertGLAccount.SelectedIndex = -1
        cboInsertGLDescription.SelectedIndex = -1

        txtInsertComment.Clear()
        txtInsertDebit.Clear()
        txtInsertCredit.Clear()

        numLineNumber.Value = 1
    End Sub

    Public Sub LoadTemplateData()
        Dim TemplateDateStatement As String = "SELECT TemplateDate FROM GLJournalTemplateHeader WHERE TemplateName = @TemplateName"
        Dim TemplateDateCommand As New SqlCommand(TemplateDateStatement, con)
        TemplateDateCommand.Parameters.Add("@TemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text

        Dim TemplateCommentStatement As String = "SELECT TemplateComment FROM GLJournalTemplateHeader WHERE TemplateName = @TemplateName"
        Dim TemplateCommentCommand As New SqlCommand(TemplateCommentStatement, con)
        TemplateCommentCommand.Parameters.Add("@TemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text

        Dim TemplateJournalStatement As String = "SELECT TemplateJournal FROM GLJournalTemplateHeader WHERE TemplateName = @TemplateName"
        Dim TemplateJournalCommand As New SqlCommand(TemplateJournalStatement, con)
        TemplateJournalCommand.Parameters.Add("@TemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TemplateDate = CStr(TemplateDateCommand.ExecuteScalar)
        Catch ex As Exception
            TemplateDate = ""
        End Try
        Try
            TemplateComment = CStr(TemplateCommentCommand.ExecuteScalar)
        Catch ex As Exception
            TemplateComment = ""
        End Try
        Try
            TemplateJournal = CStr(TemplateJournalCommand.ExecuteScalar)
        Catch ex As Exception
            TemplateJournal = ""
        End Try
        con.Close()

        cboGLJournalID.Text = TemplateJournal
        txtJournalComment.Text = TemplateComment
        dtpTemplateDate.Text = TemplateDate
    End Sub

    Public Sub LoadTemplateTotals()
        Dim TotalDebitsStatement As String = "SELECT SUM(GLDebitAmount) FROM GLJournalTemplateLines WHERE GLTemplateName = @GLTemplateName"
        Dim TotalDebitsCommand As New SqlCommand(TotalDebitsStatement, con)
        TotalDebitsCommand.Parameters.Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text

        Dim TotalCreditsStatement As String = "SELECT SUM(GLCreditAmount) FROM GLJournalTemplateLines WHERE GLTemplateName = @GLTemplateName"
        Dim TotalCreditsCommand As New SqlCommand(TotalCreditsStatement, con)
        TotalCreditsCommand.Parameters.Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalDebits = CDbl(TotalDebitsCommand.ExecuteScalar)
        Catch ex As Exception
            TotalDebits = 0
        End Try
        Try
            TotalCredits = CDbl(TotalCreditsCommand.ExecuteScalar)
        Catch ex As Exception
            TotalCredits = 0
        End Try
        con.Close()

        Difference = TotalDebits - TotalCredits
        txtCreditTotal.Text = FormatCurrency(TotalCredits, 2)
        txtDebitTotal.Text = FormatCurrency(TotalDebits, 2)
        txtDifference.Text = FormatCurrency(Difference, 2)
    End Sub

    Private Sub cboGLTemplateName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGLTemplateName.SelectedIndexChanged
        LoadTemplateData()
        ShowData()
    End Sub

    Private Sub txtDebitAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDebitAmount.TextChanged
        If Val(txtDebitAmount.Text) <> 0 Then txtCreditAmount.Text = 0
    End Sub

    Private Sub txtCreditAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditAmount.TextChanged
        If Val(txtCreditAmount.Text) <> 0 Then txtDebitAmount.Text = 0
    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        ClearVariables()
        ClearData()
        ShowData()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearData()
        ShowData()
    End Sub

    Private Sub SaveDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDataToolStripMenuItem.Click
        If cboGLTemplateName.Text <> "" Then
            '***********************************************************************************
            'Write / save data to Template Header Table
            Try
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("Insert Into GLJournalTemplateHeader(TemplateName, TemplateDate, TemplateComment, TemplateJournal)Values(@TemplateName, @TemplateDate, @TemplateComment, @TemplateJournal)", con)

                With cmd.Parameters
                    .Add("@TemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                    .Add("@TemplateDate", SqlDbType.VarChar).Value = dtpTemplateDate.Text
                    .Add("@TemplateComment", SqlDbType.VarChar).Value = txtJournalComment.Text
                    .Add("@TemplateJournal", SqlDbType.VarChar).Value = cboGLJournalID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("UPDATE GLJournalTemplateHeader SET TemplateDate = @TemplateDate, TemplateComment = @TemplateComment, TemplateJournal = @TemplateJournal WHERE TemplateName = @TemplateName", con)

                With cmd.Parameters
                    .Add("@TemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                    .Add("@TemplateDate", SqlDbType.VarChar).Value = dtpTemplateDate.Text
                    .Add("@TemplateComment", SqlDbType.VarChar).Value = txtJournalComment.Text
                    .Add("@TemplateJournal", SqlDbType.VarChar).Value = cboGLJournalID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Try

            ShowData()
            '***********************************************************************************
        Else
            MsgBox("You must have a valid Template Name selected.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboGLTemplateName.Text <> "" Then
            '***********************************************************************************
            'Write / save data to Template Header Table
            Try
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("Insert Into GLJournalTemplateHeader(TemplateName, TemplateDate, TemplateComment, TemplateJournal)Values(@TemplateName, @TemplateDate, @TemplateComment, @TemplateJournal)", con)

                With cmd.Parameters
                    .Add("@TemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                    .Add("@TemplateDate", SqlDbType.VarChar).Value = dtpTemplateDate.Text
                    .Add("@TemplateComment", SqlDbType.VarChar).Value = txtJournalComment.Text
                    .Add("@TemplateJournal", SqlDbType.VarChar).Value = cboGLJournalID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("UPDATE GLJournalTemplateHeader SET TemplateDate = @TemplateDate, TemplateComment = @TemplateComment, TemplateJournal = @TemplateJournal WHERE TemplateName = @TemplateName", con)

                With cmd.Parameters
                    .Add("@TemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                    .Add("@TemplateDate", SqlDbType.VarChar).Value = dtpTemplateDate.Text
                    .Add("@TemplateComment", SqlDbType.VarChar).Value = txtJournalComment.Text
                    .Add("@TemplateJournal", SqlDbType.VarChar).Value = cboGLJournalID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Try

            ShowData()
            '***********************************************************************************
        Else
            MsgBox("You must have a valid Template Name selected.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLine.Click
        '***********************************************************************************

        'Verify GL Acount
        Dim VerifyGLAccountStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLAccountCommand As New SqlCommand(VerifyGLAccountStatement, con)
        VerifyGLAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyGLAccount = CInt(VerifyGLAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLAccount = 0
        End Try
        con.Close()

        If VerifyGLAccount = 1 Then
            '***********************************************************************************


            '***********************************************************************************
            'Write / save data to Template Header Table
            Try
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("Insert Into GLJournalTemplateHeader(TemplateName, TemplateDate, TemplateComment, TemplateJournal)Values(@TemplateName, @TemplateDate, @TemplateComment, @TemplateJournal)", con)

                With cmd.Parameters
                    .Add("@TemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                    .Add("@TemplateDate", SqlDbType.VarChar).Value = dtpTemplateDate.Text
                    .Add("@TemplateComment", SqlDbType.VarChar).Value = txtJournalComment.Text
                    .Add("@TemplateJournal", SqlDbType.VarChar).Value = cboGLJournalID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("UPDATE GLJournalTemplateHeader SET TemplateDate = @TemplateDate, TemplateComment = @TemplateComment, TemplateJournal = @TemplateJournal WHERE TemplateName = @TemplateName", con)

                With cmd.Parameters
                    .Add("@TemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                    .Add("@TemplateDate", SqlDbType.VarChar).Value = dtpTemplateDate.Text
                    .Add("@TemplateComment", SqlDbType.VarChar).Value = txtJournalComment.Text
                    .Add("@TemplateJournal", SqlDbType.VarChar).Value = cboGLJournalID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Try
            '***********************************************************************************
            'Get next line number in the template line table
            Dim LastLineNumberStatement As String = "SELECT MAX(GLLineNumber) FROM GLJournalTemplateLines WHERE GLTemplateName = @GLTemplateName"
            Dim LastLineNumberCommand As New SqlCommand(LastLineNumberStatement, con)
            LastLineNumberCommand.Parameters.Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastLineNumber = CInt(LastLineNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastLineNumber = 0
            End Try
            con.Close()

            NextLineNumber = LastLineNumber + 1
            '***********************************************************************************
            'Add lines to Template Line Table
            cmd = New SqlCommand("Insert Into GLJournalTemplateLines(GLTemplateName, GLLineNumber, GLAccountNumber, GLCreditAmount, GLDebitAmount, GLTransactionDescription)Values(@GLTemplateName, @GLLineNumber, @GLAccountNumber, @GLCreditAmount, @GLDebitAmount, @GLTransactionDescription)", con)

            With cmd.Parameters
                .Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                .Add("@GLLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = Val(txtCreditAmount.Text)
                .Add("@GLDebitAmount", SqlDbType.VarChar).Value = Val(txtDebitAmount.Text)
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = txtTransactionComment.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '***********************************************************************************
            ShowData()
            ClearLines()
        Else
            MsgBox("You must have a valid GL Account.", MsgBoxStyle.OkOnly)
        End If

    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        '***********************************************************************************
        'Verify that you wish to delete line
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this line?", "DELETE LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Delete line from Template Line Table
            cmd = New SqlCommand("DELETE FROM GLJournalTemplateLines WHERE GLTemplateName = @GLTemplateName AND GLLineNumber = @GLLineNumber", con)

            With cmd.Parameters
                .Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                .Add("@GLLineNumber", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '***********************************************************************************
            ShowData()

            Dim TempLineNumber As Integer = 1000
            Dim GetLineNumber As Integer = 0

            'Reorder Lines
            For Each row As DataGridViewRow In dgvTemplateLines.Rows
                Try
                    GetLineNumber = row.Cells("GLLineNumberColumn").Value
                Catch ex As Exception
                    GetLineNumber = 0
                End Try

                'Write temp line numbers to Line Table
                cmd = New SqlCommand("UPDATE GLJournalTemplateLines SET GLLineNumber = @GLLineNumberTemp WHERE GLTemplateName = @GLTemplateName AND GLLineNumber = @GLLineNumber", con)

                With cmd.Parameters
                    .Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                    .Add("@GLLineNumber", SqlDbType.VarChar).Value = GetLineNumber
                    .Add("@GLLineNumberTemp", SqlDbType.VarChar).Value = TempLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                TempLineNumber = TempLineNumber + 1
            Next

            'Refresh datagrid
            ShowData()

            TempLineNumber = 1
            GetLineNumber = 0

            'Reorder Lines
            For Each row As DataGridViewRow In dgvTemplateLines.Rows
                Try
                    GetLineNumber = row.Cells("GLLineNumberColumn").Value
                Catch ex As Exception
                    GetLineNumber = 0
                End Try

                'Write temp line numbers to Line Table
                cmd = New SqlCommand("UPDATE GLJournalTemplateLines SET GLLineNumber = @GLLineNumberTemp WHERE GLTemplateName = @GLTemplateName AND GLLineNumber = @GLLineNumber", con)

                With cmd.Parameters
                    .Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                    .Add("@GLLineNumber", SqlDbType.VarChar).Value = GetLineNumber
                    .Add("@GLLineNumberTemp", SqlDbType.VarChar).Value = TempLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                TempLineNumber = TempLineNumber + 1
            Next

            'Refresh datagrid
            ShowData()
        ElseIf button = DialogResult.No Then
            cmdDeleteLine.Focus()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalGLTemplateName = cboGLTemplateName.Text

        Using NewPrintGLTemplate As New PrintGLTemplate
            Dim result = NewPrintGLTemplate.ShowDialog()
        End Using
    End Sub

    Private Sub PrintDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintDataToolStripMenuItem.Click
        GlobalGLTemplateName = cboGLTemplateName.Text

        Using NewPrintGLTemplate As New PrintGLTemplate
            Dim result = NewPrintGLTemplate.ShowDialog()
        End Using
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this template?", "DELETE TEMPLATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Delete line from Template Line Table
            cmd = New SqlCommand("DELETE FROM GLJournalTemplateHeader WHERE TemplateName = @TemplateName", con)

            With cmd.Parameters
                .Add("@TemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cboGLTemplateName.Text = ""
            LoadGLTemplateName()
            ClearVariables()
            ClearData()
            ShowData()
            '***********************************************************************************
        ElseIf button = DialogResult.No Then
            cmdDelete.Focus()
        End If
    End Sub

    Private Sub DeleteDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteDateToolStripMenuItem.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this template?", "DELETE TEMPLATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Delete line from Template Line Table
            cmd = New SqlCommand("DELETE FROM GLJournalTemplateHeader WHERE TemplateName = @TemplateName", con)

            With cmd.Parameters
                .Add("@TemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cboGLTemplateName.Text = ""
            LoadGLTemplateName()
            ClearVariables()
            ClearData()
            ShowData()
            '***********************************************************************************
        ElseIf button = DialogResult.No Then
            cmdDelete.Focus()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvTemplateLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTemplateLines.CellValueChanged
        Dim TemplateName As String = ""
        Dim TemplateLineNumber As Integer = 0
        Dim RowGLAccount As String = ""
        Dim RowDebitAmount As Double = 0
        Dim RowCreditAmount As Double = 0
        Dim RowTransactionDescription As String = ""

        If Me.dgvTemplateLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvTemplateLines.CurrentCell.RowIndex

            Try
                TemplateName = Me.dgvTemplateLines.Rows(RowIndex).Cells("GLTemplateNameColumn").Value
            Catch ex As Exception
                TemplateName = ""
            End Try
            Try
                TemplateLineNumber = Me.dgvTemplateLines.Rows(RowIndex).Cells("GLLineNumberColumn").Value
            Catch ex As Exception
                TemplateLineNumber = 0
            End Try
            Try
                RowGLAccount = Me.dgvTemplateLines.Rows(RowIndex).Cells("GLAccountNumberColumn").Value
            Catch ex As Exception
                RowGLAccount = ""
            End Try
            Try
                RowCreditAmount = Me.dgvTemplateLines.Rows(RowIndex).Cells("GLCreditAmountColumn").Value
            Catch ex As Exception
                RowCreditAmount = 0
            End Try
            Try
                RowDebitAmount = Me.dgvTemplateLines.Rows(RowIndex).Cells("GLDebitAmountColumn").Value
            Catch ex As Exception
                RowDebitAmount = 0
            End Try
            Try
                RowTransactionDescription = Me.dgvTemplateLines.Rows(RowIndex).Cells("GLTransactionDescriptionColumn").Value
            Catch ex As Exception
                RowTransactionDescription = ""
            End Try
            '************************************************************************************************
            'Validate GL Account Number
            Dim ValidateAccountNumber As Integer = 0

            Dim ValidateAccountNumberStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
            Dim ValidateAccountNumberCommand As New SqlCommand(ValidateAccountNumberStatement, con)
            ValidateAccountNumberCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = RowGLAccount

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ValidateAccountNumber = CInt(ValidateAccountNumberCommand.ExecuteScalar)
            Catch ex As Exception
                ValidateAccountNumber = 0
            End Try
            con.Close()
            '************************************************************************************************
            If ValidateAccountNumber = 1 Then
                'Save changes
                cmd = New SqlCommand("UPDATE GLJournalTemplateLines SET GLAccountNumber = @GLAccountNumber, GLCreditAmount = @GLCreditAmount, GLDebitAmount = @GLDebitAmount, GLTransactionDescription = @GLTransactionDescription WHERE GLTemplateName = @GLTemplateName AND GLLineNumber = @GLLineNumber", con)

                With cmd.Parameters
                    .Add("@GLTemplateName", SqlDbType.VarChar).Value = TemplateName
                    .Add("@GLLineNumber", SqlDbType.VarChar).Value = TemplateLineNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RowGLAccount
                    .Add("@GLCreditAmount", SqlDbType.VarChar).Value = RowCreditAmount
                    .Add("@GLDebitAmount", SqlDbType.VarChar).Value = RowDebitAmount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = RowTransactionDescription
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '****************************************************************************************
                'Check Totals
                Dim SumCredits, SumDebits As Double
                SumCredits = 0
                SumDebits = 0

                Dim SumCreditsStatement As String = "SELECT SUM(GLCreditAmount) FROM GLJournalTemplateLines WHERE GLTemplateName = @GLTemplateName"
                Dim SumCreditsCommand As New SqlCommand(SumCreditsStatement, con)
                SumCreditsCommand.Parameters.Add("@GLTemplateName", SqlDbType.VarChar).Value = TemplateName

                Dim SumDebitsStatement As String = "SELECT SUM(GLDebitAmount) FROM GLJournalTemplateLines WHERE GLTemplateName = @GLTemplateName"
                Dim SumDebitsCommand As New SqlCommand(SumDebitsStatement, con)
                SumDebitsCommand.Parameters.Add("@GLTemplateName", SqlDbType.VarChar).Value = TemplateName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumCredits = CDbl(SumCreditsCommand.ExecuteScalar)
                Catch ex As Exception
                    SumCredits = 0
                End Try
                Try
                    SumDebits = CDbl(SumDebitsCommand.ExecuteScalar)
                Catch ex As Exception
                    SumDebits = 0
                End Try
                con.Close()

                If SumCredits = SumDebits Then
                    LoadTemplateTotals()
                Else
                    MsgBox("Debits and credits do not equal.", MsgBoxStyle.OkOnly)
                    LoadTemplateTotals()
                End If
            Else
                MsgBox("Invalid GL Account - no changes will be saved.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdInsertLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsertLine.Click
        If cboGLTemplateName.Text = "" Then
            MsgBox("You must have a valid Template Name.", MsgBoxStyle.OkOnly)
        Else
            'Check valid GL Account
            Dim CheckGLAccount As Integer = 0

            Dim CheckGLAccountStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
            Dim CheckGLAccountCommand As New SqlCommand(CheckGLAccountStatement, con)
            CheckGLAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboInsertGLAccount.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckGLAccount = CInt(CheckGLAccountCommand.ExecuteScalar)
            Catch ex As Exception
                CheckGLAccount = 0
            End Try
            con.Close()

            If CheckGLAccount = 1 Then
                'Proceed - GL Account exists
            Else
                MsgBox("GL Account does not exist.", MsgBoxStyle.OkOnly)
                Exit Sub
                cboInsertGLAccount.Focus()
            End If
            '*************************************************************************************************
            'Count Lines and validate
            Dim CountLines As Integer = 0
            Dim InsertLineNumber As Integer = 0
            Dim StartingLineNumber As Integer = 0

            Dim CountLinesStatement As String = "SELECT COUNT(GLTemplateName) FROM GLJournalTemplateLines WHERE GLTemplateName = @GLTemplateName"
            Dim CountLinesCommand As New SqlCommand(CountLinesStatement, con)
            CountLinesCommand.Parameters.Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountLines = CInt(CountLinesCommand.ExecuteScalar)
            Catch ex As Exception
                CountLines = 0
            End Try
            con.Close()

            InsertLineNumber = numLineNumber.Value + 1

            If CountLines - InsertLineNumber < 2 Then
                MsgBox("You cannot insert a line here.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            If numLineNumber.Value >= CountLines Then
                MsgBox("You cannot insert a line here.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If

            StartingLineNumber = InsertLineNumber
            Dim TempLineNumber As Integer = 0
            TempLineNumber = 1000 + StartingLineNumber
            '************************************************************************************
            'Re-Number Lines after (temporarily)
            For i As Integer = 1 To (CountLines - InsertLineNumber + 1)
                'Re-Number Line (Temp)
                cmd = New SqlCommand("UPDATE GLJournalTemplateLines SET GLLineNumber = @GLLineNumber WHERE GLTemplateName = @GLTemplateName AND GLLineNumber = @GLLineNumber2", con)

                With cmd.Parameters
                    .Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                    .Add("@GLLineNumber", SqlDbType.VarChar).Value = TempLineNumber
                    .Add("@GLLineNumber2", SqlDbType.VarChar).Value = StartingLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                StartingLineNumber = StartingLineNumber + 1
                TempLineNumber = TempLineNumber + 1
            Next i
            '************************************************************************************
            'Insert Line
            cmd = New SqlCommand("Insert Into GLJournalTemplateLines(GLTemplateName, GLLineNumber, GLAccountNumber, GLCreditAmount, GLDebitAmount, GLTransactionDescription)Values(@GLTemplateName, @GLLineNumber, @GLAccountNumber, @GLCreditAmount, @GLDebitAmount, @GLTransactionDescription)", con)

            With cmd.Parameters
                .Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                .Add("@GLLineNumber", SqlDbType.VarChar).Value = InsertLineNumber
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboInsertGLAccount.Text
                .Add("@GLCreditAmount", SqlDbType.VarChar).Value = Val(txtInsertCredit.Text)
                .Add("@GLDebitAmount", SqlDbType.VarChar).Value = Val(txtInsertDebit.Text)
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = txtInsertComment.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '************************************************************************************
            'Re-Number Lines after (temporarily)
            StartingLineNumber = InsertLineNumber + 1
            TempLineNumber = 1000 + StartingLineNumber - 1

            For i As Integer = 1 To (CountLines - InsertLineNumber + 1)
                'Re-Number Line (Temp)
                cmd = New SqlCommand("UPDATE GLJournalTemplateLines SET GLLineNumber = @GLLineNumber WHERE GLTemplateName = @GLTemplateName AND GLLineNumber = @GLLineNumber2", con)

                With cmd.Parameters
                    .Add("@GLTemplateName", SqlDbType.VarChar).Value = cboGLTemplateName.Text
                    .Add("@GLLineNumber", SqlDbType.VarChar).Value = StartingLineNumber
                    .Add("@GLLineNumber2", SqlDbType.VarChar).Value = TempLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                StartingLineNumber = StartingLineNumber + 1
                TempLineNumber = TempLineNumber + 1
            Next i
            '************************************************************************************
            'Load Totals and reload datagrid
            ShowData()
            LoadTemplateTotals()
            ClearInsertLines()
            '************************************************************************************
        End If
    End Sub
End Class