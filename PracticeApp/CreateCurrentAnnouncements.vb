Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class CreateCurrentAnnouncements
    Inherits System.Windows.Forms.Form

    Dim Message1, Message2, Message3, Message4 As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Public Sub LoadMessages()
        Dim Message1Statement As String = "SELECT Message1 FROM CurrentAnnouncementTable"
        Dim Message1Command As New SqlCommand(Message1Statement, con)

        Dim Message2Statement As String = "SELECT Message2 FROM CurrentAnnouncementTable"
        Dim Message2Command As New SqlCommand(Message2Statement, con)

        Dim Message3Statement As String = "SELECT Message3 FROM CurrentAnnouncementTable"
        Dim Message3Command As New SqlCommand(Message3Statement, con)

        Dim Message4Statement As String = "SELECT Message4 FROM CurrentAnnouncementTable"
        Dim Message4Command As New SqlCommand(Message4Statement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            Message1 = CStr(Message1Command.ExecuteScalar)
        Catch ex As Exception
            Message1 = ""
        End Try
        Try
            Message2 = CStr(Message2Command.ExecuteScalar)
        Catch ex As Exception
            Message2 = ""
        End Try
        Try
            Message3 = CStr(Message3Command.ExecuteScalar)
        Catch ex As Exception
            Message3 = ""
        End Try
        Try
            Message4 = CStr(Message4Command.ExecuteScalar)
        Catch ex As Exception
            Message4 = ""
        End Try
        con.Close()

        txtMessage1.Text = Message1
        txtMessage2.Text = Message2
        txtMessage3.Text = Message3
        txtMessage4.Text = Message4
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click


        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click


        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        txtMessage1.Clear()
        txtMessage2.Clear()
        txtMessage3.Clear()
        txtMessage4.Clear()
        cmdClearAll.Focus()
    End Sub

    Private Sub cmdDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteAll.Click
        'Create command to delete data from Current Announcements
        cmd = New SqlCommand("DELETE FROM CurrentAnnouncementTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        txtMessage1.Clear()
        txtMessage2.Clear()
        txtMessage3.Clear()
        txtMessage4.Clear()

        MsgBox("All Global Messages have been deleted.", MsgBoxStyle.OkOnly)
        cmdDeleteAll.Focus()
    End Sub

    Private Sub cmdSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveAll.Click
        'Create command to Save all messages

        cmd = New SqlCommand("DELETE From CurrentAnnouncementTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        cmd = New SqlCommand("Insert Into CurrentAnnouncementTable (Message1, Message2, Message3, Message4)Values(@Message1, @Message2, @Message3, @Message4)", con)
        cmd.Parameters.Add("@Message1", SqlDbType.VarChar).Value = txtMessage1.Text
        cmd.Parameters.Add("@Message2", SqlDbType.VarChar).Value = txtMessage2.Text
        cmd.Parameters.Add("@Message3", SqlDbType.VarChar).Value = txtMessage3.Text
        cmd.Parameters.Add("@Message4", SqlDbType.VarChar).Value = txtMessage4.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        MsgBox("All Global Messages have been saved.", MsgBoxStyle.OkOnly)
        cmdSaveAll.Focus()
    End Sub

    Private Sub cndClear1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cndClear1.Click
        txtMessage1.Clear()
    End Sub

    Private Sub cmdClear2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear2.Click
        txtMessage2.Clear()
    End Sub

    Private Sub cmdClear3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear3.Click
        txtMessage3.Clear()
    End Sub

    Private Sub cmdClear4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear4.Click
        txtMessage4.Clear()
    End Sub

    Private Sub cmdAdd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd1.Click
        Try
            cmd = New SqlCommand("UPDATE CurrentAnnouncementTable SET Message1 = @Message1", con)
            cmd.Parameters.Add("@Message1", SqlDbType.VarChar).Value = txtMessage1.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            cmd = New SqlCommand("Insert Into CurrentAnnouncementTable (Message1)Values(@Message1)", con)
            cmd.Parameters.Add("@Message1", SqlDbType.VarChar).Value = txtMessage1.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try
        cmdAdd1.Focus()
    End Sub

    Private Sub cmdAdd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd2.Click
        Try
            cmd = New SqlCommand("UPDATE CurrentAnnouncementTable SET Message2 = @Message2", con)
            cmd.Parameters.Add("@Message2", SqlDbType.VarChar).Value = txtMessage2.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            cmd = New SqlCommand("Insert Into CurrentAnnouncementTable (Message2)Values(@Message2)", con)
            cmd.Parameters.Add("@Message2", SqlDbType.VarChar).Value = txtMessage2.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try
        cmdAdd2.Focus()
    End Sub

    Private Sub cmdAdd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd3.Click
        Try
            cmd = New SqlCommand("UPDATE CurrentAnnouncementTable SET Message3 = @Message3", con)
            cmd.Parameters.Add("@Message3", SqlDbType.VarChar).Value = txtMessage3.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            cmd = New SqlCommand("Insert Into CurrentAnnouncementTable (Message3)Values(@Message3)", con)
            cmd.Parameters.Add("@Message3", SqlDbType.VarChar).Value = txtMessage3.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try
        cmdAdd3.Focus()
    End Sub

    Private Sub cmdAdd4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd4.Click
        Try
            cmd = New SqlCommand("UPDATE CurrentAnnouncementTable SET Message4 = @Message4", con)
            cmd.Parameters.Add("@Message4", SqlDbType.VarChar).Value = txtMessage4.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception


            cmd = New SqlCommand("Insert Into CurrentAnnouncementTable (Message4)Values(@Message4)", con)
            cmd.Parameters.Add("@Message4", SqlDbType.VarChar).Value = txtMessage4.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try
        cmdAdd4.Focus()
    End Sub

    Private Sub CreateCurrentAnnouncements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMessages()
    End Sub
End Class