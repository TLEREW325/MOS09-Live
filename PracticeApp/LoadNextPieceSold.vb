Public Class LoadNextPieceSold

    Private Sub LoadNextPieceSold_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalNextPieceSold = 0
    End Sub

    Private Sub LoadNextPieceSold_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtNextPieceSold.Text = FormatCurrency(GlobalNextPieceSold, 4)
        Label2.Focus()
    End Sub
End Class