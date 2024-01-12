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
Public Class CustomerNoteCreation
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim dt As DataTable

    Dim LastNoteNumber, NextNoteNumber As Integer

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdCreateNewNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateNewNote.Click
        If txtNoteCustomer.Text = "" Then
            MsgBox("You must have a valid Customer ID selected.", MsgBoxStyle.OkOnly)
        Else
            'Get Next Note Number
            Dim MaximumNoteString As String = "SELECT MAX(NoteID) FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
            MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtNoteCustomer.Text
            MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastNoteNumber = CInt(MaximumNoteCommand.ExecuteScalar)
            Catch ex As Exception
                LastNoteNumber = 0
            End Try
            con.Close()

            NextNoteNumber = LastNoteNumber + 1

            'Write Data to Customer Note Table
            cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

            With cmd.Parameters
                .Add("@CustomerID", SqlDbType.VarChar).Value = txtNoteCustomer.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@NoteDate", SqlDbType.VarChar).Value = dtpNoteDate.Text
                .Add("@NoteSubject", SqlDbType.VarChar).Value = txtNoteSubject.Text
                .Add("@NoteBody", SqlDbType.VarChar).Value = txtNoteBody.Text
                .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            dtpNoteDate.Text = ""
            txtNoteSubject.Clear()
            txtNoteBody.Clear()
            dtpNoteDate.Focus()

            MsgBox("Customer Note has been added.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub CustomerNoteCreation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalCustomerID = ""
    End Sub

    Private Sub CustomerNoteCreation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtNoteCustomer.Text = GlobalCustomerID
    End Sub
End Class