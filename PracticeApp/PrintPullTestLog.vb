Public Class PrintPullTestLog
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal tbl As System.Data.DataTable)
        InitializeComponent()

        Dim myDoc As New CRXPullTestLog

        myDoc.SetDataSource(tbl)

        crvPullTestLog.ReportSource = myDoc
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub
End Class