Public Class PrintSteelTransactions
    Inherits System.Windows.Forms.Form

    Public Sub New()
        InitializeComponent()
        LoadCrystal(New DataSet())
    End Sub

    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()
        LoadCrystal(ds)
    End Sub

    Private Sub LoadCrystal(ByVal ds As DataSet)
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSteelTransactions1
        MyReport.SetDataSource(ds)
        CRSteelViewer.ReportSource = MyReport
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class