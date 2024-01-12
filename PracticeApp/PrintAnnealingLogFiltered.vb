
Public Class PrintAnnealingLogFiltered
    Inherits System.Windows.Forms.Form

    Public Sub New()
        InitializeComponent()
        Dim MyReport = New CRXAnnealingLog
        CRLogViewer.ReportSource = MyReport
    End Sub

    Public Sub New(ByVal dt As Data.DataTable)
        InitializeComponent()
        Dim MyReport = New CRXAnnealingLog
        MyReport.SetDataSource(dt)
        CRLogViewer.ReportSource = MyReport
    End Sub

    Public Sub New(ByVal ds As Data.DataSet)
        InitializeComponent()
        Dim MyReport = New CRXAnnealingLog
        MyReport.SetDataSource(ds)
        CRLogViewer.ReportSource = MyReport
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class