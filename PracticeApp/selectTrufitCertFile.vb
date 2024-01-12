Public Class selectTrufitCertFile

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdLoadCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadCert.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgvFileNames_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvFileNames.DoubleClick
        If dgvFileNames.CurrentCell.RowIndex >= 0 Then
            cmdLoadCert_Click(sender, e)
        End If
    End Sub

    Public Sub SizeForm()
        Dim gridWidth As Integer = 0
        For i As Integer = 0 To dgvFileNames.Columns.Count - 1
            If dgvFileNames.Columns(i).Visible Then
                gridWidth += dgvFileNames.Columns(i).Width
            End If
        Next
        If gridWidth > 0 Then
            Me.Width = gridWidth
        End If
    End Sub
End Class