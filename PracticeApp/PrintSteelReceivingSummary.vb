Public Class PrintSteelReceivingSummary
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal ds As DataSet, ByVal columnList As List(Of String))
        InitializeComponent()
        Dim MyReport As New CRXSteelReceivingSummary()

        If columnList.Count > 12 Then
            For i As Integer = 0 To 11
                Dim fname As TextObject = MyReport.ReportDefinition.ReportObjects("txtMonth" + (i + 1).ToString())
                fname.Text = columnList(i)
            Next
        ElseIf columnList.Count > 0 Then
            For i As Integer = 0 To columnList.Count - 1
                Dim fname As TextObject = MyReport.ReportDefinition.ReportObjects("txtMonth" + (i + 1).ToString())
                fname.Text = columnList(i)
            Next
        End If
        MyReport.SetDataSource(ds.Tables("SteelUsageMonthSummary"))
        CRVSteelReceivingSummary.ReportSource = MyReport
    End Sub
End Class