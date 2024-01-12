Public Class TimeSlipSelectFOXStep

    Public Sub New()
        InitializeComponent()
        txtStepNumber.Focus()
    End Sub

    Public Sub New(ByVal message As String, ByVal title As String)
        InitializeComponent()
        lblMessage.Text = message
        Me.Text = title
        Me.Size = New System.Drawing.Size(Me.Size.Width, lblMessage.Size.Height + 125)
        txtStepNumber.Focus()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtStepNumber_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStepNumber.Enter
        txtStepNumber.SelectAll()
    End Sub

    Public Function getEnteredStep() As Integer
        Return Val(txtStepNumber.Text)
    End Function

    Private Sub txtStepNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStepNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdOk.Focus()
            e.Handled = True
        End If
    End Sub
End Class