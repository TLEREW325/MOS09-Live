Imports System.Data.SqlClient

Public Class QCNonConformanceRacking
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim ds As DataSet
    Dim addRackControl As New QCNonConformanceRackingAddToRacking()
    Public Sub New()
        InitializeComponent()

        ShowAllRacks()

    End Sub

    Public Sub ShowAllRacks()
        cmd = New SqlCommand("SELECT * FROM QCRackingTable WHERE DivisionID <> @DivisionID ORDER BY BinNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "QCRackingTable")
        con.Close()

        dgvQCRacking.DataSource = ds.Tables("QCRackingTable")
        Dim sug As New AutoCompleteStringCollection
        For i As Integer = 0 To dgvQCRacking.Rows.Count - 1
            sug.Add(dgvQCRacking.Rows(i).Cells("BinNumberColumn").Value)
        Next
        txtDeleteBin.AutoCompleteCustomSource = sug
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If String.IsNullOrEmpty(txtDeleteBin.Text) Then
            'Delete Line from datagrid
            If Me.dgvQCRacking.RowCount <> 0 Then
                Dim button As DialogResult = MessageBox.Show("Do you wish to delete this entry from the Rack", "DELETE BIN LOCATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    Dim RowRackingKey As Integer
                    Dim RowIndex As Integer = Me.dgvQCRacking.CurrentCell.RowIndex

                    RowRackingKey = Me.dgvQCRacking.Rows(RowIndex).Cells("RackingKeyColumn").Value

                    cmd = New SqlCommand("Delete FROM QCRackingTable WHERE RackingKey = @RackingKey", con)
                    cmd.Parameters.Add("@RackingKey", SqlDbType.VarChar).Value = RowRackingKey

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    ShowAllRacks()
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            Else
                'Do Nothing
            End If
        Else
            If txtDeleteBin.Text < "AB100" Or txtDeleteBin.Text > "AB130" Then
                MsgBox("You must select a QC Bin Location to delete.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this entire rack?", "DELETE ENTIRE RACK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                cmd = New SqlCommand("Delete FROM QCRackingTable WHERE BinNumber = @BinNumber", con)
                cmd.Parameters.Add("@BinNumber", SqlDbType.VarChar).Value = txtDeleteBin.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowAllRacks()
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        End If
    End Sub

    Private Sub dgvQCRacking_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQCRacking.CellValueChanged
        Dim LineRackingKey, LineBoxQuantity, LinePiecesPerBox, LineTotalPieces As Integer
        Dim LinePartNumber, LineDescription, LineLotNumber, LineFoxNumber, LineHoldReason As String
        Dim LineTotalWeight As Double

        If Me.dgvQCRacking.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvQCRacking.CurrentCell.RowIndex

            Try
                LineRackingKey = Me.dgvQCRacking.Rows(RowIndex).Cells("RackingKeyColumn").Value
            Catch ex As System.Exception
                LineRackingKey = 0
            End Try
            Try
                LinePartNumber = Me.dgvQCRacking.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As System.Exception
                LinePartNumber = ""
            End Try
            Try
                LineDescription = Me.dgvQCRacking.Rows(RowIndex).Cells("DescriptionColumn").Value
            Catch ex As System.Exception
                LineDescription = ""
            End Try
            Try
                LineLotNumber = Me.dgvQCRacking.Rows(RowIndex).Cells("LotNumberColumn").Value
            Catch ex As System.Exception
                LineLotNumber = ""
            End Try
            Try
                LineFoxNumber = Me.dgvQCRacking.Rows(RowIndex).Cells("FoxNumberColumn").Value
            Catch ex As System.Exception
                LineFoxNumber = ""
            End Try
            Try
                LineHoldReason = Me.dgvQCRacking.Rows(RowIndex).Cells("HoldReasonColumn").Value
            Catch ex As System.Exception
                LineHoldReason = ""
            End Try
            Try
                LineBoxQuantity = Me.dgvQCRacking.Rows(RowIndex).Cells("BoxQuantityColumn").Value
            Catch ex As System.Exception
                LineBoxQuantity = 0
            End Try
            Try
                LinePiecesPerBox = Me.dgvQCRacking.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value
            Catch ex As System.Exception
                LinePiecesPerBox = 0
            End Try
            Try
                LineTotalWeight = Me.dgvQCRacking.Rows(RowIndex).Cells("TotalWeightColumn").Value
            Catch ex As System.Exception
                LineTotalWeight = 0
            End Try

            'Get Total # of pieces
            LineTotalPieces = LineBoxQuantity * LinePiecesPerBox

            'UPDATE QC Racking
            cmd = New SqlCommand("UPDATE QCRackingTable SET PartNumber = @PartNumber, Description = @Description, LotNumber = @LotNumber, FoxNumber = @FoxNumber, HoldReason = @HoldReason, BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, TotalWeight = @TotalWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey", con)

            With cmd.Parameters
                .Add("@RackingKey", SqlDbType.VarChar).Value = LineRackingKey
                .Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                .Add("@Description", SqlDbType.VarChar).Value = LineDescription
                .Add("@LotNumber", SqlDbType.VarChar).Value = LineLotNumber
                .Add("@FoxNumber", SqlDbType.VarChar).Value = LineFoxNumber
                .Add("@HoldReason", SqlDbType.VarChar).Value = LineHoldReason
                .Add("@BoxQuantity", SqlDbType.VarChar).Value = LineBoxQuantity
                .Add("@PiecesPerBox", SqlDbType.VarChar).Value = LinePiecesPerBox
                .Add("@TotalPieces", SqlDbType.VarChar).Value = LineTotalPieces
                .Add("@TotalWeight", SqlDbType.VarChar).Value = LineTotalWeight
                .Add("@ActivityDate", SqlDbType.VarChar).Value = Now.Date.ToShortDateString()
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Datagrid has been updated.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Using NewPrintQCRackLocations As New PrintQCRackLocations(ds.Copy())
            Dim Result = NewPrintQCRackLocations.ShowDialog()
        End Using
    End Sub

    Private Sub cmdAddToRacking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToRacking.Click
        GlobalDivisionCode = EmployeeCompanyCode
        GlobalQCTransactionNumber = 0

        Using NewQCAddToRack As New QCNonConformanceRackingAddToRacking()
            Dim Result = NewQCAddToRack.ShowDialog()
        End Using

        ShowAllRacks()
    End Sub

    Private Sub QCHoldRacking_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        addRackControl.Dispose()
    End Sub
End Class