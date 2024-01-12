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
Public Class PrintFirstPieceInspection
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalInspectionKey = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRFirstPieceViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRFirstPieceViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM QCInspectionHeaderTable WHERE InspectionKey = @InspectionKey", con)
        cmd.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = GlobalInspectionKey

        cmd1 = New SqlCommand("SELECT * FROM QCInspectionFirstPieceTable WHERE InspectionKey = @InspectionKey", con)
        cmd1.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = GlobalInspectionKey

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "QCInspectionHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "QCInspectionFirstPieceTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXFirstPieceInspection1
        MyReport.SetDataSource(ds)
        CRFirstPieceViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintFirstPieceInspection_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalInspectionKey = ""
    End Sub
End Class