Public Class PrintWIPValue
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = crxwipValue1
        MyReport.SetDataSource(ds)
        CRVWIPValue.ReportSource = MyReport
    End Sub
End Class