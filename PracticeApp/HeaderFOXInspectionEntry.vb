Public Class HeaderFOXInspectionEntry
    Dim lowSpec As String = ""
    Dim HighSpec As String = ""
    Dim sampleSize As Integer = 0

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        If canSubmit() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Yes
            Me.Close()
        End If
    End Sub

    Private Function canSubmit() As Boolean
        If String.IsNullOrEmpty(txtMeasurement.Text) Then
            customWarningMessageBox("You must enter a measurement in order to submit", "Enter a measurement")
            txtMeasurement.Focus()
            Return False
        End If
        If lowSpec.Contains("MIN") Then
            lowSpec = lowSpec.Substring(0, lowSpec.IndexOf("M"))
        End If
        If HighSpec.Contains("M") Then
            HighSpec = HighSpec.Substring(0, HighSpec.IndexOf("M"))
        End If
        If (IsNumeric(lowSpec) Or IsNumeric(HighSpec)) And IsNumeric(txtMeasurement.Text) = False Then
            customWarningMessageBox("Invalid entry, please check entry and try again.", "Check entry")
            Return False
        End If
        If IsNumeric(txtMeasurement.Text) Then
            ''checks to see if there is a low spec entered
            If String.IsNullOrEmpty(lowSpec) = False Then
                If IsNumeric(lowSpec) Then
                    ''checks to make sure the entered measurement is greater than the low spec
                    If Val(txtMeasurement.Text) < Val(lowSpec) Then
                        Dim rslt As DialogResult = customYesNoMessageBox("You are about to submit a value lower than the minimum specification. Do you wish to continue?")
                        If rslt <> System.Windows.Forms.DialogResult.Yes Then
                            Return False
                        End If
                    End If
                End If
            End If
            ''checks to see if there is a high spec entered
            If String.IsNullOrEmpty(HighSpec) = False Then
                ''checks to make sure there is a numeric value to test against
                If IsNumeric(HighSpec) Then
                    ''checks to make sure that the measurement is less than the high spec
                    If Val(txtMeasurement.Text) > Val(HighSpec) Then
                        Dim rslt As DialogResult = customYesNoMessageBox("You are about to submit a value higher than the maximum specification. Do you wish to continue?")
                        If rslt <> System.Windows.Forms.DialogResult.Yes Then
                            Return False
                        End If
                    End If
                End If
            End If
        End If
        Return True
    End Function
   
    ''sets the sampleSize
    Public Sub setSampleSize(ByVal samp As Integer)
        sampleSize = samp
    End Sub
    ''sets the low spec
    Public Sub setLowSpec(ByVal low As String)
        lowSpec = low
    End Sub
    ''sets the high spec
    Public Sub setHighSpec(ByVal high As String)
        HighSpec = high
    End Sub
    Public Function getMeasurement() As String
        Return txtMeasurement.Text
    End Function

    Private Sub cmdGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub cmdNoGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNoGo.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub txtMeasurement_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMeasurement.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdSubmit.Focus()
        End If
    End Sub
End Class