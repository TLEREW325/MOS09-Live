Public Class SelectFOXFromBlueprint
    Dim FoxesDT As Data.DataTable
    Dim isLoaded As Boolean = False
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal dt As Data.DataTable)
        InitializeComponent()
        FoxesDT = dt
        Dim dgvDT As Data.DataTable = FoxesDT.Clone()
        Dim CurrentRev = FoxesDT.Rows(0).Item("RevisionLevel")
        For i As Integer = 0 To FoxesDT.Rows.Count - 1
            If FoxesDT.Rows(i).Item("RevisionLevel").Equals(CurrentRev) Then
                Dim rw As Data.DataRow = dgvDT.NewRow()
                For j As Integer = 0 To FoxesDT.Columns.Count - 1
                    rw.Item(j) = FoxesDT.Rows(i).Item(j)
                Next
                dgvDT.Rows.Add(rw)
            End If
        Next
        dgvFoundFOXs.DataSource = dgvdt
        SetupDGV()
        isLoaded = True
    End Sub

    Private Sub cmdSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelect.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvFoundFOXs_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dgvFoundFOXs.PreviewKeyDown
        If e.KeyCode = Keys.Return Then
            cmdSelect.Focus()
        End If
    End Sub

    Private Sub dgvFoundFOXs_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFoundFOXs.KeyDown
        If e.KeyCode = Keys.Return Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvFoundFOXs_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvFoundFOXs.MouseDoubleClick
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Yes
            Me.Close()
        End If
    End Sub

    Private Sub chkShoqwOnlyCurrentRev_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShoqwOnlyCurrentRev.CheckedChanged
        If isLoaded Then
            If chkShoqwOnlyCurrentRev.Checked Then
                Dim dgvDT As Data.DataTable = FoxesDT.Clone()
                Dim CurrentRev = FoxesDT.Rows(0).Item("RevisionLevel")
                For i As Integer = 0 To FoxesDT.Rows.Count - 1
                    If FoxesDT.Rows(i).Item("RevisionLevel").Equals(CurrentRev) Then
                        Dim rw As Data.DataRow = dgvDT.NewRow()
                        For j As Integer = 0 To FoxesDT.Columns.Count - 1
                            rw.Item(j) = FoxesDT.Rows(i).Item(j)
                        Next
                        dgvDT.Rows.Add(rw)
                    End If
                Next
                dgvFoundFOXs.DataSource = dgvDT
            Else
                dgvFoundFOXs.DataSource = FoxesDT
            End If
            SetupDGV()
        End If
    End Sub

    Private Sub SetupDGV()
        dgvFoundFOXs.Columns("InspectionKey").HeaderText = "FOX-Operation"
    End Sub

    Private Sub dgvFoundFOXs_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvFoundFOXs.Resize
        Me.Width = dgvFoundFOXs.Width + 3
    End Sub
End Class