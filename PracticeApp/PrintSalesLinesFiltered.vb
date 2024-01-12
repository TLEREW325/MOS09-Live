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
Public Class PrintSalesLinesFiltered
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalDivisionCode = ""
        GDS = New DataSet
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRSalesViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRSalesViewer.Load
        'Loads data into dataset for viewing
        ds = GDS

        If GlobalDivisionCode = "SLC" Then
            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXSalesOrderLinesPrice1
            MyReport.SetDataSource(ds)
            CRSalesViewer.ReportSource = MyReport
            con.Close()
        Else
            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXSalesOrderLines1
            MyReport.SetDataSource(ds)
            CRSalesViewer.ReportSource = MyReport
            con.Close()
        End If
 
    End Sub

    Private Sub PrintSalesLinesFiltered_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalDivisionCode = ""
        GDS = New DataSet
    End Sub
End Class