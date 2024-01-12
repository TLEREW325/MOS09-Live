
Public Class PrintMachineList

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = crxManufacturingMaintenanceList1
        MyReport.SetDataSource(ds)
        CRVMachineList.ReportSource = MyReport
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub
End Class