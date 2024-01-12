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
Public Class LotNumberPopup
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub LotNumberPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalLotNumberPart = ""
    End Sub

    Private Sub LotNumberPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLotNumbers()
    End Sub

    Public Sub LoadLotNumbers()
        cmd = New SqlCommand("SELECT LotNumber, HeatNumber, PartNumber FROM LotNumber WHERE PartNumber = @PartNumber ORDER BY LotNumber DESC", con)
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalLotNumberPart
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "LotNumber")
        dgvLotNumber.DataSource = ds1.Tables("LotNumber")
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalLotNumberPart = ""

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvLotNumber_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLotNumber.CellDoubleClick
        Dim RowLotNumber As String = ""
        Dim RowIndex As Integer = Me.dgvLotNumber.CurrentCell.RowIndex

        RowLotNumber = Me.dgvLotNumber.Rows(RowIndex).Cells("LotNumberColumn").Value

        GlobalLotNumber = RowLotNumber

        Me.Close()
    End Sub
End Class