Public Class PrintCharterSteelDispatchEntry
    Private ds As DataSet

    Public Sub setds(ByVal inData As DataSet)
        ds = inData
    End Sub

    Private Sub mnuItemExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuItemExit.Click
        Me.Close()
    End Sub

    Private Sub CRXChaterSteelDispatchEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRChaterSteelDispatchEntryViewer.Load
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCharterSteelDispatchEntry1
        MyReport.SetDataSource(ds)
        CRChaterSteelDispatchEntryViewer.ReportSource = MyReport
    End Sub
End Class