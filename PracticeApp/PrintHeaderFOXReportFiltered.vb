Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class PrintHeaderFOXReportFiltered
    Inherits System.Windows.Forms.Form

    Dim ds As DataSet

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXFOXHeaderReportFiltered1
        MyReport.SetDataSource(ds)
        CRFOXViewer.ReportSource = MyReport
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class