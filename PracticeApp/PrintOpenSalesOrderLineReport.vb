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
Public Class PrintOpenSalesOrderLineReport
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalOpenOrderReport = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CROpenViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CROpenViewer.Load
        If GlobalOpenOrderReport = "YES" Then
            'Loads data into dataset for viewing
            ds = GDS

            If con.State = ConnectionState.Closed Then con.Open()
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXOpenSOReport1
            MyReport.SetDataSource(ds)
            CROpenViewer.ReportSource = MyReport
            con.Close()
        Else
            'Loads data into dataset for viewing
            ds = GDS

            If con.State = ConnectionState.Closed Then con.Open()
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXOpenSOLines1
            MyReport.SetDataSource(ds)
            CROpenViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub



    Private Sub PrintOpenSalesOrderLineReport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalOpenOrderReport = ""
    End Sub
End Class