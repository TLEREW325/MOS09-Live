Public Class ViewInventoryCoilWIP
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()
        Dim MyReport As New CRXInventoryCoilWIP
        MyReport.SetDataSource(ds)
        CRVInventoryCoilWIP.ReportSource = MyReport
    End Sub

    Private Sub CRVInventoryCoilWIP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVInventoryCoilWIP.Load

    End Sub
End Class