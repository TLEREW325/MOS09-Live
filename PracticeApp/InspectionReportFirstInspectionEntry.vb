Imports System.Data.SqlClient

Public Class InspectionReportFirstInspectionEntry
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter As New SqlDataAdapter

    Dim key As String = ""
    Dim isLoaded As Boolean = False
    Dim Inspector As String = ""
    Dim controlKey As Boolean = False
    ''***********************
    ''NEEDS TAKEN OUT
    'Dim EmployeeLoginName = "TEST"

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal ke As String, ByVal lot As String, ByVal rev As String)
        InitializeComponent()
        key = ke
        cmd = New SqlCommand("SELECT InspectionKey, InspectionLineNumber, LowSpec, HighSpec, PartDetail, InspectionMethod FROM QCInspectionLineTable WHERE InspectionKey = @InspectionKey AND PartDetail <> '' ORDER BY InspectionLineNumber", con)
        cmd.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = key

        Dim dt As New Data.DataTable("QCInspectionLineTable")
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dt)
        con.Close()

        dgvFirstInspectionEntry.DataSource = dt
        dgvFirstInspectionEntry.Columns.Add("FirstPieceInspection", "Inspection Entry")

        dgvFirstInspectionEntry.Columns("InspectionKey").Visible = False
        dgvFirstInspectionEntry.Columns("InspectionLineNumber").Visible = False

        dgvFirstInspectionEntry.Columns("LowSpec").HeaderText = "Low Spec"
        dgvFirstInspectionEntry.Columns("LowSpec").ReadOnly = True
        dgvFirstInspectionEntry.Columns("HighSpec").HeaderText = "High Spec"
        dgvFirstInspectionEntry.Columns("HighSpec").ReadOnly = True
        dgvFirstInspectionEntry.Columns("PartDetail").HeaderText = "Part Detail"
        dgvFirstInspectionEntry.Columns("PartDetail").ReadOnly = True
        dgvFirstInspectionEntry.Columns("InspectionMethod").HeaderText = "Inspection Method"
        dgvFirstInspectionEntry.Columns("InspectionMethod").ReadOnly = True
        isLoaded = True
        lblInspectionReport.Text = ke
        txtLotNumber.Text = lot
        lblCurrentRevisionLevel.Text = rev
    End Sub

    Private Sub cmdFirstInspectionEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirstInspectionEntry.Click
        If canSubmitEntry() Then
            cmd = New SqlCommand("UPDATE QCInspectionFirstPieceTable SET HasPrinted = 1 WHERE InspectionKey = @InspectionKey AND HasPrinted = 0;", con)
            cmd.CommandText += " DECLARE @FOXNumber int, @PartNumber varchar(50), @Operation varchar(50), @Blueprint varchar(50), @RevLevel varchar(50);"
            cmd.CommandText += " SELECT @FOXNumber = FOXNumber, @PartNumber = PartNumber, @Operation = Operation, @Blueprint = BlueprintNumber, @RevLevel = RevisionLevel FROM QCInspectionHeaderTable WHERE InspectionKey = @InspectionKey;"
            cmd.CommandText += "  INSERT INTO QCInspectionFirstPieceTable (InspectionKey, InspectionLineKey, FOXNumber, PartNumber, Operation, Blueprint, RevLevel, LotNumber, InspectionDateTime, InspectionMeasurement, Inspector, SampleSize, LowSpec, HighSpec, PartDetail) VALUES"
            With cmd.Parameters
                .Add("@InspectionKey", SqlDbType.VarChar).Value = lblInspectionReport.Text
                .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                .Add("@Inspector", SqlDbType.VarChar).Value = Inspector
                .Add("@SampleSize", SqlDbType.Int).Value = txtSampleSize.Text
            End With
            For i As Integer = 0 To dgvFirstInspectionEntry.Rows.Count - 1
                If i = 0 Then
                    cmd.CommandText += " (@InspectionKey, @InspectionLineKey" + i.ToString() + ", @FOXNumber, @PartNumber, @Operation, @Blueprint, @RevLevel, @LotNumber, CURRENT_TIMESTAMP, @InspectionMeasurement" + i.ToString() + ", @Inspector, @SampleSize, @LowSpec" + i.ToString() + ", @HighSpec" + i.ToString() + ", @PartDetail" + i.ToString() + ")"
                Else
                    cmd.CommandText += ", (@InspectionKey, @InspectionLineKey" + i.ToString() + ", @FOXNumber, @PartNumber, @Operation, @Blueprint, @RevLevel, @LotNumber, CURRENT_TIMESTAMP, @InspectionMeasurement" + i.ToString() + ", @Inspector, @SampleSize, @LowSpec" + i.ToString() + ", @HighSpec" + i.ToString() + ", @PartDetail" + i.ToString() + ")"
                End If
                With cmd.Parameters
                    .Add("@InspectionLineKey" + i.ToString(), SqlDbType.Int).Value = dgvFirstInspectionEntry.Rows(i).Cells("InspectionLineNumber").Value
                    .Add("@InspectionMeasurement" + i.ToString(), SqlDbType.VarChar).Value = dgvFirstInspectionEntry.Rows(i).Cells("FirstPieceInspection").Value
                    .Add("@LowSpec" + i.ToString(), SqlDbType.VarChar).Value = dgvFirstInspectionEntry.Rows(i).Cells("LowSpec").Value
                    .Add("@HighSpec" + i.ToString(), SqlDbType.VarChar).Value = dgvFirstInspectionEntry.Rows(i).Cells("HighSpec").Value
                    .Add("@PartDetail" + i.ToString(), SqlDbType.VarChar).Value = dgvFirstInspectionEntry.Rows(i).Cells("PartDetail").Value
                End With
            Next
            If dgvFirstInspectionEntry.Rows.Count > 0 Then
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            Inspector = ""
            MessageBox.Show("Inspection Entry has been added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = System.Windows.Forms.DialogResult.Yes
            Me.Close()
        End If
    End Sub

    Private Function canSubmitEntry() As Boolean
        If String.IsNullOrEmpty(txtSampleSize.Text) Then
            MessageBox.Show("You must enter a number for Sample Size", "Enter a sample size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSampleSize.Focus()
            Return False
        End If
        If Not IsNumeric(txtSampleSize.Text) Then
            MessageBox.Show("You must enter a valid number for Sample Size", "Enter a sample size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSampleSize.SelectAll()
            txtSampleSize.Focus()
            Return False
        End If
        For i As Integer = 0 To dgvFirstInspectionEntry.Rows.Count - 1
            If String.IsNullOrEmpty(dgvFirstInspectionEntry.Rows(i).Cells("FirstPieceInspection").Value) Then
                MessageBox.Show("You must enter values for all entries", "Enter all values", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgvFirstInspectionEntry.Focus()
                dgvFirstInspectionEntry.CurrentCell = dgvFirstInspectionEntry.Rows(i).Cells("FirstPieceInspection")
                Return False
            End If
        Next
        If Not lblCurrentRevisionLevel.Text.Trim(" "c).Equals(txtBlueprintRevisionLevel.Text.Trim(" "c)) Then
            MessageBox.Show("Blueprint revision level must be equal to FOX revision level.", "Blueprint revision level must match.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        cmd = New SqlCommand("SELECT FOXTable.BlueprintRevision FROM FOXTAble INNER JOIN QCInspectionHeaderTable ON FOXTable.FOXNumber = QCInspectionHeaderTable.FOXNumber WHERE QCInspectionHeaderTable.InspectionKey = @InspectionKey", con)
        cmd.Parameters.Add("@InspectionKey", SqlDbType.VarChar).Value = lblInspectionReport.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()
        If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
            If Not lblCurrentRevisionLevel.Text.ToUpper().Equals(obj.ToString.ToUpper()) Then
                If MessageBox.Show("Revision level on the inspection report is not the same as in the FOX, do you wish to continue?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                    Return False
                End If
            End If
        End If
        Dim pass As New PasswordEntry(True)
        If pass.ShowDialog() <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Inspector = pass.txtUserName.Text
        Return True
    End Function

    Private Sub InspectionReportFirstInspectionEntry_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim i As Integer = 0
        While i < dgvFirstInspectionEntry.Rows.Count
            Select Case True
                Case String.IsNullOrEmpty(dgvFirstInspectionEntry.Rows(i).Cells("InspectionMethod").Value.ToString)
                    dgvFirstInspectionEntry.Rows.RemoveAt(i)
                Case (dgvFirstInspectionEntry.Rows(i).Cells("InspectionMethod").Value.ToString.ToLower.Contains("visual") Or dgvFirstInspectionEntry.Rows(i).Cells("InspectionMethod").Value.ToString.ToLower.Contains("go/nogo") Or dgvFirstInspectionEntry.Rows(i).Cells("InspectionMethod").Value.ToString.ToLower.Contains("no go gage") Or dgvFirstInspectionEntry.Rows(i).Cells("InspectionMethod").Value.ToString.ToLower.Contains("nogogage") Or dgvFirstInspectionEntry.Rows(i).Cells("InspectionMethod").Value.ToString.ToLower.Replace(" ", "").Contains("load"))
                    Dim cellChange As New DataGridViewCheckBoxCell
                    cellChange.FalseValue = "NOT OK"
                    cellChange.TrueValue = "OK"
                    dgvFirstInspectionEntry.Item("FirstPieceInspection", i) = cellChange
                    dgvFirstInspectionEntry.Item("FirstPieceInspection", i).Value = "NOT OK"
                    i += 1
                Case Else
                    i += 1
            End Select
        End While
        dgvFirstInspectionEntry.Focus()
        If dgvFirstInspectionEntry.Rows.Count > 0 Then
            dgvFirstInspectionEntry.Rows(0).Cells("FirstPieceInspection").Selected = True
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvFirstInspectionEntry_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvFirstInspectionEntry.DataError
    End Sub

    Private Sub dgvFirstInspectionEntry_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFirstInspectionEntry.CellValueChanged
        If isLoaded AndAlso Not String.IsNullOrEmpty(dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value) Then

            If dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value.ToString.ToLower.Equals("ok") Or dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value.ToString.ToLower.Equals("not ok") Then
                isLoaded = False
                dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value = dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value.ToString.ToUpper()
                isLoaded = True
            Else
                If dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value.ToString.Contains("/") AndAlso Not dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value.ToString.Contains(".") Then
                    isLoaded = False
                    dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value = usefulFunctions.ConvertToDecimal(dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value.ToString.Replace(" ", "-"))
                    isLoaded = True
                End If
            End If
            
            If dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value.ToString.Equals("OK") Then
                dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Style.BackColor = Color.LightGreen
            ElseIf dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value.ToString.Equals("NOT OK") Then
                dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Style.BackColor = Color.LightCoral
            Else
                Dim lowSpec As String = dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("LowSpec").Value
                ''check to see if MIN is in the low spec
                If lowSpec.Contains("MIN") Then
                    lowSpec = lowSpec.Substring(0, lowSpec.IndexOf("M"))
                End If
                ''checks to make sure the it is within spec
                If Val(lowSpec) > Val(dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value) Then
                    dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Style.BackColor = Color.LightCoral
                ElseIf String.IsNullOrEmpty(dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("HighSpec").Value) Then
                    dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Style.BackColor = Color.LightGreen
                Else
                    Dim highSpec As String = dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("HighSpec").Value
                    ''check to see if MAX is in the spec
                    If highSpec.Contains("MAX") Then
                        highSpec = highSpec.Substring(0, highSpec.IndexOf("M"))
                    End If
                    ''check to see if the entered number is below the high spec
                    If Val(highSpec) < Val(dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Value) Then
                        dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Style.BackColor = Color.LightCoral
                    Else
                        dgvFirstInspectionEntry.Rows(e.RowIndex).Cells("FirstPieceInspection").Style.BackColor = Color.LightGreen
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtSampleSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSampleSize.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        End If
        controlKey = False
    End Sub

    Private Sub txtSampleSize_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtSampleSize.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Back Or e.KeyCode = Keys.Tab Then
            controlKey = True
        End If
    End Sub
End Class