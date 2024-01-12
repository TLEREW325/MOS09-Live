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
Public Class PrintInventoryTubTag
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub CRTagViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRTagViewer.Load
        If GlobalInventoryTagPrintMethod = "PRINTSINGLE" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM TFPInventoryTubQuery WHERE InventoryKey = @InventoryKey", con)
            cmd.Parameters.Add("@InventoryKey", SqlDbType.VarChar).Value = GlobalInventoryTagID

            cmd1 = New SqlCommand("SELECT * FROM TFPInventoryFOXProcesses WHERE InventoryKey = @InventoryKey ORDER BY InventoryKey, FOXNumber, ProcessStep", con)
            cmd1.Parameters.Add("@InventoryKey", SqlDbType.VarChar).Value = GlobalInventoryTagID

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "TFPInventoryTubQuery")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "TFPInventoryFOXProcesses")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXInventoryTubTag1
            MyReport.SetDataSource(ds)
            CRTagViewer.ReportSource = MyReport
            con.Close()
        ElseIf GlobalInventoryTagPrintMethod = "PRINTALL" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM TFPInventoryTubQuery WHERE InventoryStatus = @InventoryStatus", con)
            cmd.Parameters.Add("@InventoryStatus", SqlDbType.VarChar).Value = "OPEN"

            cmd1 = New SqlCommand("SELECT * FROM TFPInventoryFOXProcesses ORDER BY InventoryKey, FOXNumber, ProcessStep", con)
            'cmd1.Parameters.Add("@InventoryKey", SqlDbType.VarChar).Value = GlobalInventoryTagID

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "TFPInventoryTubQuery")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "TFPInventoryFOXProcesses")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXInventoryTubTag1
            MyReport.SetDataSource(ds)
            CRTagViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalInventoryTagPrintMethod = ""
        GlobalInventoryTagID = 0

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintInventoryTubTag_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalInventoryTagPrintMethod = ""
        GlobalInventoryTagID = 0
    End Sub
End Class