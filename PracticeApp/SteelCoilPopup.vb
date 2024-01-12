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
Public Class SteelCoilPopup
    Inherits System.Windows.Forms.Form

    Dim CoilLocation, CoilComment As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim dt As DataTable

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        GlobalCoilID = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdAddUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddUpdate.Click
        If lblCoilID.Text <> "" Then
            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Location = @Location, Comment = @Comment WHERE CoilID = @CoilID", con)

                With cmd.Parameters
                    .Add("@CoilID", SqlDbType.VarChar).Value = lblCoilID.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@Location", SqlDbType.VarChar).Value = txtLocation.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Comment/Location added.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'Error Log
            End Try
        End If
    End Sub

    Private Sub SteelCoilPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblCoilID.Text = GlobalCoilID

        Dim CoilCommentString As String = "SELECT Comment FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID"
        Dim CoilCommentCommand As New SqlCommand(CoilCommentString, con)
        CoilCommentCommand.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = lblCoilID.Text

        Dim CoilLocationString As String = "SELECT Location FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID"
        Dim CoilLocationCommand As New SqlCommand(CoilLocationString, con)
        CoilLocationCommand.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = lblCoilID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CoilComment = CStr(CoilCommentCommand.ExecuteScalar)
        Catch ex As Exception
            CoilComment = ""
        End Try
        Try
            CoilLocation = CStr(CoilLocationCommand.ExecuteScalar)
        Catch ex As Exception
            CoilLocation = ""
        End Try
        con.Close()

        txtComment.Text = CoilComment
        txtLocation.Text = CoilLocation
    End Sub
End Class