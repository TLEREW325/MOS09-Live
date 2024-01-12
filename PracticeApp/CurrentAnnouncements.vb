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
Public Class CurrentAnnouncements
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

    Private Sub CurrentAnnouncements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMessages()
    End Sub
End Class