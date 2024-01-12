Public Class PrintOkToShip

    Public Sub New()
        InitializeComponent()

        Dim myReport As New CRXOkToShip()
        CRVOkToShip.ReportSource = myReport
    End Sub
End Class