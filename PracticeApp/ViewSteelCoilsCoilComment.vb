Public Class ViewSteelCoilsCoilComment
    Public Event Hidden()

    Private indx As Integer

    Public ReadOnly Property RowIndex() As Integer
        Get
            Return indx
        End Get
    End Property

    Public Overloads Sub Show(ByVal coilID As String, ByVal RowIndx As Integer, ByVal comment As String)
        Me.DialogResult = System.Windows.Forms.DialogResult.None
        lblCoilID.Text = coilID
        indx = RowIndx
        txtComment.Text = comment
        If String.IsNullOrEmpty(comment) Then
            txtComment.ReadOnly = False
            cmdEdit.Hide()
            cmdAddUpdate.Show()
            txtComment.Focus()
        Else
            txtComment.ReadOnly = True
            cmdEdit.Show()
            cmdAddUpdate.Hide()
            cmdCancel.Focus()
        End If
        MyBase.Show()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        txtComment.ReadOnly = False
        cmdAddUpdate.Show()
        cmdEdit.Hide()
    End Sub

    Private Sub cmdAddUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddUpdate.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
        RaiseEvent Hidden()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
        RaiseEvent Hidden()
    End Sub
End Class