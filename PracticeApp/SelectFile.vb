Public Class SelectFile

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
End Class