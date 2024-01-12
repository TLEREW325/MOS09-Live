
Public Class PrintSteelPurchaseLines
    Inherits System.Windows.Forms.Form
    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub New()
        InitializeComponent()
        Dim MyReport = New CRXSteelPurchaseLines
        CRPurchaseViewer.ReportSource = MyReport

    End Sub
    Public Sub New(ByVal dt As Data.DataTable)
        InitializeComponent()
        Dim MyReport = New CRXSteelPurchaseLines
        MyReport.SetDataSource(dt)
        CRPurchaseViewer.ReportSource = MyReport

    End Sub
End Class