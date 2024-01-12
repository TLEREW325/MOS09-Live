Public Class PrintFOXReleaseScheduleCompressed

    Public Sub New(ByVal dt As Data.DataTable)
        InitializeComponent()
        Dim report As New CRXFOXReleaseListingCompressed
        report.SetDataSource(dt)

        CRVFOXReleaseScheduleCompressed.ReportSource = report
    End Sub

    Private Sub PrintFOXReleaseScheduleCompressed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class