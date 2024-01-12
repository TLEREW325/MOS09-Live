Public Class PrintQCHoldListing
    Inherits System.Windows.Forms.Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()
        Dim MyReport = New CRXQCHoldListing()
        MyReport.SetDataSource(ds)
        CRHoldViewer.ReportSource = MyReport
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalQCTransactionNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub
End Class