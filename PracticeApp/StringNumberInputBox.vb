Public Class StringNumberInputBox
    Dim NumericTextOnly As Boolean
    Public Sub New()
        InitializeComponent()
        Me.AcceptButton = cmdOk
    End Sub

    Public Sub New(ByVal InputMessage As String, ByVal inputValue As String, ByVal InputLength As Integer, ByVal NumericOnly As Boolean)
        InitializeComponent()
        lblInputMessage.Text = InputMessage
        txtInput.MaxLength = InputLength
        txtInput.Text = inputValue
        NumericTextOnly = NumericOnly
        Me.AcceptButton = cmdOk
    End Sub

    Private Sub txtInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInput.KeyPress
        If NumericTextOnly Then
            If Not IsNumeric(e.KeyChar) And Not e.KeyChar <> vbBack And Not e.KeyChar = vbCrLf Then
                e.KeyChar = Nothing
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub StringNumberInputBox_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = System.Windows.Forms.DialogResult.None Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub
End Class