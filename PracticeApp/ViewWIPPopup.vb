Public Class ViewWIPPopup

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal obj As Object)
        InitializeComponent()

        If TypeOf obj Is String Then
            ProductionAPI.LoadSingleFOXProductionData(New WIPDataPassed(dgvWIP, DirectCast(obj, String), pnlNoWIPData))
        ElseIf TypeOf obj Is DataSet Then
            Dim lst As New List(Of String)
            Dim ds As DataSet = obj
            Dim ColumnName As String = "PartNumber"
            If Not ds.Tables(0).Columns.Contains(ColumnName) Then
                Select Case True
                    Case "PartNumberColumn"
                        ColumnName = "PartNumberColumn"
                    Case "ItemID"
                        ColumnName = "ItemID"
                    Case "ItemIDColumn"
                        ColumnName = "ItemIDColumn"
                    Case Else
                        Exit Sub
                End Select
            End If
            For Each partnumber As String In ds.Tables(0).Rows.Item(ColumnName).ToString
                lst.Add(partnumber)
            Next
        ElseIf TypeOf obj Is List(Of String) Then
            ProductionAPI.LoadMultipleFOXProductionData(New WIPDataPassed(dgvWIP, DirectCast(obj, List(Of String))))
        End If
        If dgvWIP.Rows.Count > 29 Then
            Me.Height = 800
        Else
            If dgvWIP.Rows.Count > 1 Then
                If dgvWIP.Rows.Count <= 5 Then
                    If dgvWIP.Rows.Count <= 2 Then
                        Me.Height = dgvWIP.Rows.Count * 30 + 75
                    Else
                        Me.Height = dgvWIP.Rows.Count * 26 + 75
                    End If

                Else
                    Me.Height = dgvWIP.Rows.Count * 25 + 75
                End If

            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dgvWIP_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvWIP.VisibleChanged
        If dgvWIP.Visible Then
            Dim colWidth As Integer = 0
            For i As Integer = 0 To dgvWIP.Columns.Count - 1
                colWidth += dgvWIP.Columns(i).Width
            Next
            If colWidth = 0 Or dgvWIP.Rows.Count = 0 Then
                colWidth = 500
            End If
            Me.Width = colWidth + 40
            dgvWIP.Width = Me.Width - 20
            cmdExit.Location = New System.Drawing.Point(Me.Width - 100, cmdExit.Location.Y)
        End If
    End Sub
End Class