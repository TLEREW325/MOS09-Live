Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintPTCheckAmerican
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintPTCheck_A_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Deletes Open Checks when form closes
        cmd = New SqlCommand("Delete from APCheckLog WHERE APBatchNumber = @APBatchNumber And CheckStatus = @CheckStatus", con)
        cmd.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber
        cmd.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub CRCheckViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCheckViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM APCheckQuery WHERE APBatchNumber = @APBatchNumber", con)
        cmd.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APCheckQuery")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXPTCheckType1
        MyReport.SetDataSource(ds)
        CRCheckViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        CRCheckViewer.PrintReport()

        Dim button As DialogResult = MessageBox.Show("Did the checks print correctly?", "TFP CORP CHECK PRINTING", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            cmd = New SqlCommand("UPDATE APCheckLog SET CheckStatus = @CheckStatus WHERE APBatchNumber = @APBatchNumber", con)
            cmd.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber
            cmd.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Change Batch Status so the checks can not be printed again
            cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchStatus = @BatchStatus WHERE BatchNumber = @BatchNumber", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber
            cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "PRINTED"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Me.Dispose()
            Me.Close()
        ElseIf button = DialogResult.No Then
            cmd = New SqlCommand("Delete from APCheckLog WHERE APBatchNumber = @APBatchNumber And CheckStatus = @CheckStatus", con)
            cmd.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber
            cmd.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE APVoucherTable SET CheckPositionNumber = @CheckPositionNumber WHERE BatchNumber = @BatchNumber", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber
            cmd.Parameters.Add("@CheckPositionNumber", SqlDbType.VarChar).Value = 0

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("You may print these checks again.", MsgBoxStyle.OkOnly)

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub PrintChecksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintChecksToolStripMenuItem.Click
        CRCheckViewer.PrintReport()

        Dim button As DialogResult = MessageBox.Show("Did the checks print correctly?", "TFP CORP CHECK PRINTING", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            cmd = New SqlCommand("UPDATE APCheckLog SET CheckStatus = @CheckStatus WHERE APBatchNumber = @APBatchNumber", con)
            cmd.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber
            cmd.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Change Batch Status so the checks can not be printed again
            cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchStatus = @BatchStatus WHERE BatchNumber = @BatchNumber", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber
            cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "PRINTED"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Me.Dispose()
            Me.Close()
        ElseIf button = DialogResult.No Then
            cmd = New SqlCommand("Delete from APCheckLog WHERE APBatchNumber = @APBatchNumber And CheckStatus = @CheckStatus", con)
            cmd.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber
            cmd.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE APVoucherTable SET CheckPositionNumber = @CheckPositionNumber WHERE BatchNumber = @BatchNumber", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber
            cmd.Parameters.Add("@CheckPositionNumber", SqlDbType.VarChar).Value = 0

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("You may print these checks again.", MsgBoxStyle.OkOnly)

            Me.Dispose()
            Me.Close()
        End If
    End Sub
End Class