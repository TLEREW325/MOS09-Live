

Public Class PrintSteelUsage
    Inherits System.Windows.Forms.Form

    Dim dt As Data.DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Public Sub New()
        InitializeComponent()
        Dim MyReport = New CRXSteelConsumptionLines
        CRSteelViewer.ReportSource = MyReport

    End Sub

    Public Sub New(ByVal dt As Data.DataTable)
        InitializeComponent()
        Dim MyReport = New CRXSteelConsumptionLines
        MyReport.SetDataSource(dt)
        CRSteelViewer.ReportSource = MyReport
    End Sub

   
End Class