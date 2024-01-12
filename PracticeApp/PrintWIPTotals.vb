Public Class PrintWIPTotals
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal dt As System.Data.DataTable)
        InitializeComponent()

        Dim rpt As New CRXWIPTotalValue
        rpt.SetDataSource(dt)

        CRVWIPTotals.ReportSource = rpt
    End Sub
End Class