Public Class TFPQuoteSelectNextForm

    Private Sub cmdCustomerMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomerMaintenance.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Retry
        Me.Close()
    End Sub

    Private Sub cmdFOXMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFOXMaintenance.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdItemMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemMaintenance.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Close()
    End Sub
End Class