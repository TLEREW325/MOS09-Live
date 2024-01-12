Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class PrintWIP
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = crxwip1
        MyReport.SetDataSource(ds)
        CRVWIP.ReportSource = MyReport
    End Sub
End Class