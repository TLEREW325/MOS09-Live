Public Class SelectMultiplePO
    Dim SelectedList As New List(Of String)

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal lst As List(Of String))
        InitializeComponent()

        For Each InString As String In lst
            dgvSelectedPO.Rows.Add(False, InString)
        Next
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub cmdCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckAll.Click
        For i As Integer = 0 To dgvSelectedPO.Rows.Count - 1
            dgvSelectedPO.Rows(i).Cells("SelectPO").Value = True
        Next
    End Sub

    Private Sub cmdUncheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUncheckAll.Click
        For i As Integer = 0 To dgvSelectedPO.Rows.Count - 1
            dgvSelectedPO.Rows(i).Cells("SelectPO").Value = False
        Next
    End Sub

    Public Function GetPOList() As String()
        If SelectedList.Count() > 0 Then
            Return SelectedList.ToArray()
        End If
        Return Nothing
    End Function

    Private Sub dgvSelectedPO_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSelectedPO.CellValueChanged
        If dgvSelectedPO.Columns(e.ColumnIndex).Name.Equals("SelectPO") Then
            If dgvSelectedPO.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "True" Then
                If Not SelectedList.Contains(dgvSelectedPO.Rows(e.RowIndex).Cells("PONumber").Value) Then
                    SelectedList.Add(dgvSelectedPO.Rows(e.RowIndex).Cells("PONumber").Value)
                End If
            Else
                If SelectedList.Contains(dgvSelectedPO.Rows(e.RowIndex).Cells("PONumber").Value) Then
                    SelectedList.Remove(dgvSelectedPO.Rows(e.RowIndex).Cells("PONumber").Value)
                End If
            End If
        End If
    End Sub
End Class