Public Class PrintOkToProcess
    Public Sub New()
        InitializeComponent()

        Dim myReport As New CRXOkToProcess()
        CRVOkToProcess.ReportSource = myReport
    End Sub
End Class