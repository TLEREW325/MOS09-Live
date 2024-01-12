Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class RackingLocations
    Dim adap As New SqlDataAdapter
    Dim isLoaded As Boolean = False
    Dim ds As DataSet
    Dim cmd, cmd1 As SqlCommand
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Private Sub GetRacking(ByVal PassedData As String)

        cmd = New SqlCommand("Select RackingKey, PartNumber, PartDescription, BinNumber, BoxQuantity, PiecesPerBox, TotalPieces, RackingWeight, CASE WHEN TotalPieces = 0 THEN 0 ELSE (ROUND(RackingWeight / TotalPieces, 5)) END as PieceWeight From RackingTransactionTable where (DivisionID = 'TST') and PartNumber = @PartNumber", con)
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PassedData
        ds = New DataSet
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(ds, "RackingTransactionTable")
        dgvRackingLocations.DataSource = ds.Tables("RackingTransactionTable").Copy()
        con.Close()

        setupDGV()


        isLoaded = True
    End Sub

    Private Sub setupDGV()
        dgvRackingLocations.Columns("RackingKey").Visible = False
        dgvRackingLocations.Columns("PartNumber").HeaderText = "Part Number"
        dgvRackingLocations.Columns("PartNumber").ReadOnly = True
        dgvRackingLocations.Columns("PartDescription").HeaderText = "Part Description"
        dgvRackingLocations.Columns("PartDescription").ReadOnly = True
        dgvRackingLocations.Columns("BinNumber").HeaderText = "Bin Number"
        dgvRackingLocations.Columns("BinNumber").ReadOnly = True
        dgvRackingLocations.Columns("BoxQuantity").HeaderText = "Box Quantity"
        dgvRackingLocations.Columns("BoxQuantity").ReadOnly = False
        dgvRackingLocations.Columns("PiecesPerBox").HeaderText = "Piece Count"
        dgvRackingLocations.Columns("PiecesPerBox").ReadOnly = False
        dgvRackingLocations.Columns("TotalPieces").HeaderText = "Total Pieces"
        dgvRackingLocations.Columns("TotalPieces").ReadOnly = True
        dgvRackingLocations.Columns("RackingWeight").HeaderText = "Racking Weight"
        dgvRackingLocations.Columns("RackingWeight").ReadOnly = True
        dgvRackingLocations.Columns("PieceWeight").Visible = False
        Dim chk = New DataGridViewCheckBoxColumn
        dgvRackingLocations.Columns.Add(chk)
        chk.HeaderText = "Confirmed"
        chk.Name = "chk"
        chk.Frozen = True
        chk.DisplayIndex = 0
    End Sub
 

    Public Sub New(ByVal PassingData As String) 'get value from previous form's partnumber and pass it into this dgv. passing data inside getracking passes info from this function to the getracking() function 
        InitializeComponent()
        Me.CenterToScreen()
        If My.Computer.Name.Equals("Tablet") Then
            Me.dgvRackingLocations.Font = New System.Drawing.Font(dgvRackingLocations.Font.FontFamily, 12, dgvRackingLocations.Font.Style)

        Else
            pnlTablet.Hide()
            dgvRackingLocations.Font = New System.Drawing.Font(dgvRackingLocations.Font.FontFamily, 10, dgvRackingLocations.Font.Style)
            Me.Size = New Size(1024, 750)
            dgvRackingLocations.Location = New System.Drawing.Point(35, 27)
            dgvRackingLocations.Size = New System.Drawing.Size(954, 640)
            dgvRackingLocations.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Bottom
            cmdUpdate.Location = New System.Drawing.Point(766, 670)
            cmdUpdate.Font = New System.Drawing.Font(cmdUpdate.Font.FontFamily, 10, cmdUpdate.Font.Style)
            cmdUpdate.Size = New System.Drawing.Size(71, 40)
            cmdUpdate.Text = "Update"
            cmdUpdate.Anchor = AnchorStyles.Right Or AnchorStyles.Bottom
            cmdExit.Location = New System.Drawing.Point(918, 670)
            cmdPrint.Location = New System.Drawing.Point(842, 670)
            cmdExit.Size = New System.Drawing.Size(71, 40)
            cmdPrint.Size = New System.Drawing.Size(71, 40)
            cmdExit.Font = New System.Drawing.Font(cmdExit.Font.FontFamily, 10, cmdExit.Font.Style)
            cmdPrint.Font = New System.Drawing.Font(cmdExit.Font.FontFamily, 10, cmdExit.Font.Style)
            cmdExit.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            cmdPrint.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right


        End If

        GetRacking(PassingData)

    End Sub
  

    Private Sub cmdZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdZero.Click

        Dim insertText = "0"
        Dim insertPos As Integer = txtCellValue.SelectionStart

        If txtCellValue.SelectionLength >= 1 Then
            txtCellValue.SelectedText = "0"
        Else
            txtCellValue.Text = txtCellValue.Text.Insert(insertPos, insertText)
            txtCellValue.SelectionStart = insertPos + insertText.Length
        End If
    End Sub
    Private Sub cmdOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOne.Click
        Dim insertText = "1"
        Dim insertPos As Integer = txtCellValue.SelectionStart

        If txtCellValue.SelectionLength >= 1 Then
            txtCellValue.SelectedText = "1"
        Else
            txtCellValue.Text = txtCellValue.Text.Insert(insertPos, insertText)
            txtCellValue.SelectionStart = insertPos + insertText.Length
        End If
    End Sub
    Private Sub cmdTwo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTwo.Click
        Dim insertText = "2"
        Dim insertPos As Integer = txtCellValue.SelectionStart

        If txtCellValue.SelectionLength >= 1 Then
            txtCellValue.SelectedText = "2"
        Else
            txtCellValue.Text = txtCellValue.Text.Insert(insertPos, insertText)
            txtCellValue.SelectionStart = insertPos + insertText.Length
        End If
    End Sub
    Private Sub cmdThree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThree.Click
        Dim insertText = "3"
        Dim insertPos As Integer = txtCellValue.SelectionStart

        If txtCellValue.SelectionLength >= 1 Then
            txtCellValue.SelectedText = "3"
        Else
            txtCellValue.Text = txtCellValue.Text.Insert(insertPos, insertText)
            txtCellValue.SelectionStart = insertPos + insertText.Length
        End If
    End Sub
    Private Sub cmdFour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFour.Click
        Dim insertText = "4"
        Dim insertPos As Integer = txtCellValue.SelectionStart

        If txtCellValue.SelectionLength >= 1 Then
            txtCellValue.SelectedText = "4"
        Else
            txtCellValue.Text = txtCellValue.Text.Insert(insertPos, insertText)
            txtCellValue.SelectionStart = insertPos + insertText.Length
        End If
    End Sub
    Private Sub cmdFive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFive.Click
        Dim insertText = "5"
        Dim insertPos As Integer = txtCellValue.SelectionStart

        If txtCellValue.SelectionLength >= 1 Then
            txtCellValue.SelectedText = "5"
        Else
            txtCellValue.Text = txtCellValue.Text.Insert(insertPos, insertText)
            txtCellValue.SelectionStart = insertPos + insertText.Length
        End If
    End Sub
    Private Sub cmdSix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSix.Click
        Dim insertText = "6"
        Dim insertPos As Integer = txtCellValue.SelectionStart

        If txtCellValue.SelectionLength >= 1 Then
            txtCellValue.SelectedText = "6"
        Else
            txtCellValue.Text = txtCellValue.Text.Insert(insertPos, insertText)
            txtCellValue.SelectionStart = insertPos + insertText.Length
        End If
    End Sub
    Private Sub cmdSeven_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeven.Click
        Dim insertText = "7"
        Dim insertPos As Integer = txtCellValue.SelectionStart

        If txtCellValue.SelectionLength >= 1 Then
            txtCellValue.SelectedText = "7"
        Else
            txtCellValue.Text = txtCellValue.Text.Insert(insertPos, insertText)
            txtCellValue.SelectionStart = insertPos + insertText.Length
        End If
    End Sub
    Private Sub cmdEight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEight.Click
        Dim insertText = "8"
        Dim insertPos As Integer = txtCellValue.SelectionStart

        If txtCellValue.SelectionLength >= 1 Then
            txtCellValue.SelectedText = "8"
        Else
            txtCellValue.Text = txtCellValue.Text.Insert(insertPos, insertText)
            txtCellValue.SelectionStart = insertPos + insertText.Length
        End If
    End Sub
    Private Sub cmdNine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNine.Click
        Dim insertText = "9"
        Dim insertPos As Integer = txtCellValue.SelectionStart

        If txtCellValue.SelectionLength >= 1 Then
            txtCellValue.SelectedText = "9"
        Else
            txtCellValue.Text = txtCellValue.Text.Insert(insertPos, insertText)
            txtCellValue.SelectionStart = insertPos + insertText.Length
        End If
    End Sub
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtCellValue.Clear()
    End Sub

    Private Sub cmdUpdateCell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateCell.Click
        If TypeOf dgvRackingLocations.CurrentCell.Value Is Integer Then
            If txtCellValue.Text <> "" Then
                dgvRackingLocations.CurrentCell.Value = Val(txtCellValue.Text)
            End If

            txtCellValue.Clear()
        End If
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click


        cmd = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID)", con)
        cmd.CommandText += " SELECT @ActivityDateTime, BinNumber, PartNumber, HeatNumber, LotNumber, TotalPieces, @TotalPieces, @TotalPieces - TotalPieces, DivisionID, 'UPDATED', @UserID  FROM RackingTransactionTable WHERE RackingKey = @RackingKey;"
        cmd.CommandText += " Update RackingMasterList set BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces,  RackingWeight = @RackingWeight Where RackingKey = @RackingKey;"
        cmd.CommandText += " Update RackingTransactionTable set BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces,  RackingWeight = @RackingWeight, ActivityDate = @ActivityDateTime Where RackingKey = @RackingKey;"


        cmd.Parameters.Add("@RackingKey", SqlDbType.Int)
        cmd.Parameters.Add("@BoxQuantity", SqlDbType.Int)
        cmd.Parameters.Add("@PiecesPerBox", SqlDbType.Int)
        cmd.Parameters.Add("@TotalPieces", SqlDbType.Int)
        cmd.Parameters.Add("@RackingWeight", SqlDbType.Float)
        cmd.Parameters.Add("@ActivityDateTime", SqlDbType.DateTime2).Value = Now
        cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName

        cmd1 = New SqlCommand("INSERT INTO TFPRackingActivityLog (ActivityDateTime, OriginalTotalPieces, CurrentTotalPieces, TotalPiecesDifference, DivisionID, TransactionType, UserID)", con)
        cmd1.CommandText += " SELECT @ActivityDateTime, TotalPieces, 0, -1 * TotalPieces, DivisionID, 'DELETED', @UserID FROM RackingTransactionTable WHERE RackingKey = @RackingKey;"
        cmd1.CommandText += " DELETE from RackingTransactionTable where RackingKey = @RackingKey"

        cmd1.Parameters.Add("@RackingKey", SqlDbType.Int)
        cmd1.Parameters.Add("@ActivityDateTime", SqlDbType.DateTime2).Value = Now
        cmd1.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName

        For i As Integer = 0 To dgvRackingLocations.Rows.Count - 1

            If Not dgvRackingLocations.Rows(i).Cells("BoxQuantity").Value.Equals(ds.Tables("RackingTransactionTable").Rows(i).Item("BoxQuantity")) Or Not dgvRackingLocations.Rows(i).Cells("PiecesPerBox").Value.Equals(ds.Tables("RackingTransactionTable").Rows(i).Item("PiecesPerBox")) Then
                If dgvRackingLocations.Rows(i).Cells("BoxQuantity").Value = 0 Or dgvRackingLocations.Rows(i).Cells("PiecesPerBox").Value = 0 Then
                    cmd1.Parameters("@RackingKey").Value = dgvRackingLocations.Rows(i).Cells("RackingKey").Value
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd1.ExecuteNonQuery()
                Else
                    cmd.Parameters("@RackingKey").Value = dgvRackingLocations.Rows(i).Cells("RackingKey").Value
                    cmd.Parameters("@BoxQuantity").Value = dgvRackingLocations.Rows(i).Cells("BoxQuantity").Value
                    cmd.Parameters("@PiecesPerBox").Value = dgvRackingLocations.Rows(i).Cells("PiecesPerBox").Value
                    cmd.Parameters("@TotalPieces").Value = dgvRackingLocations.Rows(i).Cells("TotalPieces").Value
                    cmd.Parameters("@RackingWeight").Value = dgvRackingLocations.Rows(i).Cells("RackingWeight").Value
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                End If
            End If

        Next
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub



    Private Sub dgvRackingLocations_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRackingLocations.CellValueChanged
        If isLoaded Then
      
            For i As Integer = 0 To dgvRackingLocations.Rows.Count - 1

            
                dgvRackingLocations.Rows(i).Cells("TotalPieces").Value = (dgvRackingLocations.Rows(i).Cells("PiecesPerBox").Value * dgvRackingLocations.Rows(i).Cells("BoxQuantity").Value)
                dgvRackingLocations.Rows(i).Cells("RackingWeight").Value = (ds.Tables("RackingTransactionTable").Rows(i).Item("PieceWeight") * dgvRackingLocations.Rows(i).Cells("TotalPieces").Value)      '((RackingWeight/(BoxQuantity*PiecesPerBox))*(@BoxQuantity*@PiecesPerBox))


            Next
        End If
    
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub CloseWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseWindowToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub PrintToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem1.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim newViewRackingInventory As New ViewRackingInventory(ds)
        newViewRackingInventory.ShowDialog()
    End Sub
End Class