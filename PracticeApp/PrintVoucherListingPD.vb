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
Public Class PrintVoucherListingPD
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalVoucherType = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRVoucherViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVoucherViewer.Load
        If GlobalVoucherType = "POSTED" Then
            'Loads data into dataset for viewing
            ds = GDS

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXVoucherListingPD1
            MyReport.SetDataSource(ds)
            CRVoucherViewer.ReportSource = MyReport
            con.Close()
        ElseIf GlobalVoucherType = "DELETED" Then
            'Loads data into dataset for viewing
            ds = GDS

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXDeletedVoucherListing1
            MyReport.SetDataSource(ds)
            CRVoucherViewer.ReportSource = MyReport
            con.Close()
        Else
            'Loads data into dataset for viewing
            ds = GDS

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXVoucherListingPD1
            MyReport.SetDataSource(ds)
            CRVoucherViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub PrintVoucherListingPD_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalVoucherType = ""
    End Sub
End Class