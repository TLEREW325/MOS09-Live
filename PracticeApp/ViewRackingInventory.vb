Public Class ViewRackingInventory
    Dim ds As DataSet

    Public Sub New(ByVal PassingData As DataSet)
        InitializeComponent()
        GetView(PassingData)
        Me.CenterToScreen()
        If My.Computer.Name.Equals("Tablet") Then
            CRRackingViewer.Size = New System.Drawing.Size(1200, 750)
        Else
            CRRackingViewer.Size = New System.Drawing.Size(1024, 750)
        End If
    End Sub

    Private Sub GetView(ByVal PassedData As DataSet)

        ds = PassedData
        Dim MyReport As New CRXRackingFilter()
        MyReport.SetDataSource(ds)
        CRRackingViewer.ReportSource = MyReport

    End Sub
End Class