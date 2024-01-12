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
Public Class PrintWCProduction
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRProductionViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRProductionViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM FerruleProductionLineQuery WHERE FerruleTransactionKey = @FerruleTransactionKey", con)
        cmd.Parameters.Add("@FerruleTransactionKey", SqlDbType.VarChar).Value = GlobalWCProductionNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FerruleProductionLineQuery")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXWCProduction1
        MyReport.SetDataSource(ds)
        CRProductionViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class