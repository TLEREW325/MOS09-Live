Public Class PrintCustomerSalesRanking

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal ds As DataSet)
        InitializeComponent()

        Dim MyReport As New CRXCustomerSalesRanking
        MyReport.SetDataSource(ds)
        CRVCustomerSalesRanking.ReportSource = MyReport
    End Sub
End Class