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
Public Class PrintLeadTimesFiltered
    Inherits System.Windows.Forms.Form

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalLeadTimeReport = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRLeadViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRLeadViewer.Load
        If GlobalLeadTimeReport = "Lead Times Filtered" Then
            'Loads data into dataset for viewing
            ds = GDS5

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXLeadTimes1
            MyReport.SetDataSource(ds)
            CRLeadViewer.ReportSource = MyReport
            con.Close()
        ElseIf GlobalLeadTimeReport = "Lead Time Report" Then
            'Loads data into dataset for viewing
            ds = GDS5

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXLeadTimeReport1
            MyReport.SetDataSource(ds)
            CRLeadViewer.ReportSource = MyReport
            con.Close()
        Else
            'Do nothing
        End If
    End Sub

    Private Sub PrintLeadTimesFiltered_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalLeadTimeReport = ""
    End Sub
End Class