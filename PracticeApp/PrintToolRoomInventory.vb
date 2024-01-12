Public Class PrintToolRoomInventory
    Dim ds As New DataSet()

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal dsIn As DataSet)
        InitializeComponent()
        ds = dsIn
    End Sub
    Private Sub PrintToolRoomInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = crxPrintToolRoomInventory1
        MyReport.SetDataSource(ds)
        CRVPrintToolRoomInventory.ReportSource = MyReport
    End Sub
End Class