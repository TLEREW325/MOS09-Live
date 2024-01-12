Imports System.Windows.Forms

Public Class ShipmentLabelNumber
    Dim labelCount As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If nbrNumberOfLabels.Value > 0 Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("You must enter a number greater than 0", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Sub setLabelNumber(ByRef label As Integer)
        labelCount = label
        nbrNumberOfLabels.Value = labelCount
    End Sub
    Public Function getLabelNumber() As Integer
        Return labelCount
    End Function

    Private Sub nbrNumberOfLabels_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nbrNumberOfLabels.KeyUp
        If e.KeyCode = Keys.Enter Then
            OK_Button.Focus()
        End If
    End Sub
End Class
