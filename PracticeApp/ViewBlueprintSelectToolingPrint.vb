Public Class ViewBlueprintSelectToolingPrint
    Public SelectedFilePath As String = ""

    Public Sub New()
        InitializeComponent()

        Me.DialogResult = System.Windows.Forms.DialogResult.None
    End Sub
    Public Sub New(ByVal files As System.IO.FileInfo())
        InitializeComponent()
        For i As Integer = 0 To files.Count - 1
            dgvFiles.Rows.Add(files(i).Name)
            dgvFiles.Rows(dgvFiles.Rows.Count - 1).Tag = files(i).FullName
        Next
        Me.DialogResult = System.Windows.Forms.DialogResult.None
    End Sub
    Private Sub dgvFiles_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFiles.CellContentClick
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
            SelectedFilePath = dgvFiles.Rows(e.RowIndex).Tag
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Hide()
        End If
    End Sub

    Private Sub cmdSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelect.Click
        SelectedFilePath = dgvFiles.Rows(dgvFiles.SelectedCells(0).RowIndex).Tag
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub
End Class