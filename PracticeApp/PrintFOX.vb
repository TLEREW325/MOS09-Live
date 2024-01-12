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
Public Class PrintFOX
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalFOXNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRFOXViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRFOXViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM FOXTable WHERE (DivisionID = @DivisionID1 OR DivisionID = @DivisionID2) AND FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@DivisionID1", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = GlobalFOXNumber

        cmd1 = New SqlCommand("SELECT * FROM FoxSched", con)

        cmd2 = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = @DivisionID1 OR DivisionID = @DivisionID2", con)
        cmd2.Parameters.Add("@DivisionID1", SqlDbType.VarChar).Value = "TWD"
        cmd2.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"

        cmd3 = New SqlCommand("SELECT * FROM RawMaterialsTable WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FOXTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "FoxSched")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "ItemList")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "RawMaterialsTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXPrintFOX1
        MyReport.SetDataSource(ds)
        CRFOXViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintFOX_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalFOXNumber = 0
    End Sub
End Class