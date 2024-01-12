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
Public Class CustomerFoxes
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub CustomerFoxes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowCustomerFoxes()
    End Sub

    Public Sub ShowCustomerFoxes()
        cmd = New SqlCommand("SELECT * FROM FOXTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FOXTable")
        dgvFoxTable.DataSource = ds.Tables("FOXTable")
        con.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdFoxForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFoxForm.Click
        Dim RowFOXNumber As Integer

        If Me.dgvFoxTable.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvFoxTable.CurrentCell.RowIndex
            RowFOXNumber = Me.dgvFoxTable.Rows(RowIndex).Cells("FOXNumberColumn").Value

            GlobalFOXNumber = RowFOXNumber
            GlobalDivisionCode = "TFP"

            Dim NewFOXMenu As New FOXMenu
            NewFOXMenu.Show()

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintFOXListing As New PrintFOXListingFiltered
            Dim Result = NewPrintFOXListing.ShowDialog()
        End Using
    End Sub

    Private Sub dgvFoxTable_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFoxTable.CellDoubleClick
        Dim RowFOXNumber As Integer

        If Me.dgvFoxTable.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvFoxTable.CurrentCell.RowIndex
            RowFOXNumber = Me.dgvFoxTable.Rows(RowIndex).Cells("FOXNumberColumn").Value

            GlobalFOXNumber = RowFOXNumber
            GlobalDivisionCode = "TFP"

            Using NewPrintReleaseSchedule As New PrintFOXReleaseSchedule
                Dim Result = NewPrintReleaseSchedule.ShowDialog()
            End Using
        End If
    End Sub
End Class