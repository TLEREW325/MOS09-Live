Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ItemMaintenanceRacking
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ItemMaintenanceRacking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowData()
        LoadTotalInRack()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM RackingTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber ORDER BY BinNumber ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalMaintenancePartNumber
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RackingTransactionTable")
        dgvInventoryRacking.DataSource = ds.Tables("RackingTransactionTable")
        con.Close()
    End Sub

    Public Sub LoadTotalInRack()
        'Get Rack Totals
        Dim TotalPiecesInRack As Double = 0
        Dim strTotalPiecesInRack As String = ""

        Dim TotalPiecesInRackStatement As String = "SELECT SUM(TotalPieces) FROM RackingTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim TotalPiecesInRackCommand As New SqlCommand(TotalPiecesInRackStatement, con)
        TotalPiecesInRackCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalMaintenancePartNumber
        TotalPiecesInRackCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalPiecesInRack = CDbl(TotalPiecesInRackCommand.ExecuteScalar)
        Catch ex As System.Exception
            TotalPiecesInRack = 0
        End Try
        con.Close()

        strTotalPiecesInRack = CStr(TotalPiecesInRack)

        lblTotalInRack.Text = strTotalPiecesInRack + " total pieces in rack."
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintRackingByFilter As New PrintRackingByFilter
            Dim result = NewPrintRackingByFilter.ShowDialog()
        End Using
    End Sub

    Private Sub dgvInventoryRacking_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryRacking.CellValueChanged
        Dim RackingKey As Integer
        Dim RackingWeight As Double
        Dim BinNumber, HeatNumber, LotNumber, PartNumber As String
        Dim BoxQuantity, PiecesPerBox, TotalPieces, PieceWeight As Double

        If Me.dgvInventoryRacking.RowCount <> 0 Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to update this rack", "UPDATE RACKING DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Dim RowIndex As Integer = Me.dgvInventoryRacking.CurrentCell.RowIndex

                Try
                    RackingKey = Me.dgvInventoryRacking.Rows(RowIndex).Cells("RackingKeyColumn").Value
                Catch ex As Exception
                    RackingKey = 0
                End Try
                Try
                    BinNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("BinNumberColumn").Value
                Catch ex As Exception
                    BinNumber = 0
                End Try
                Try
                    HeatNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("HeatNumberColumn").Value
                Catch ex As Exception
                    HeatNumber = 0
                End Try
                Try
                    LotNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("LotNumberColumn").Value
                Catch ex As Exception
                    LotNumber = 0
                End Try
                Try
                    BoxQuantity = Me.dgvInventoryRacking.Rows(RowIndex).Cells("BoxQuantityColumn").Value
                Catch ex As Exception
                    BoxQuantity = ""
                End Try
                Try
                    PiecesPerBox = Me.dgvInventoryRacking.Rows(RowIndex).Cells("PiecesPerBoxColumn").Value
                Catch ex As Exception
                    PiecesPerBox = 0
                End Try
                Try
                    PartNumber = Me.dgvInventoryRacking.Rows(RowIndex).Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = 0
                End Try

                'Get Piece Weight
                Dim PieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim PieceWeightCommand As New SqlCommand(PieceWeightStatement, con)
                PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PieceWeight = CDbl(PieceWeightCommand.ExecuteScalar)
                Catch ex As System.Exception
                    PieceWeight = 0
                End Try
                con.Close()

                'Calculate Total Rack Pieces and Total Weight
                TotalPieces = BoxQuantity * PiecesPerBox
                RackingWeight = TotalPieces * PieceWeight
                RackingWeight = Math.Round(RackingWeight, 0)

                Try
                    'Update Racking Table
                    cmd = New SqlCommand("UPDATE RackingTransactionTable SET HeatNumber = @HeatNumber, LotNumber = @LotNumber, BoxQuantity = @BoxQuantity, PiecesPerBox = @PiecesPerBox, TotalPieces = @TotalPieces, RackingWeight = @RackingWeight, ActivityDate = @ActivityDate WHERE RackingKey = @RackingKey AND BinNumber = @BinNumber", con)

                    With cmd.Parameters
                        .Add("@RackingKey", SqlDbType.VarChar).Value = RackingKey
                        .Add("@BinNumber", SqlDbType.VarChar).Value = BinNumber
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                        .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                        .Add("@BoxQuantity", SqlDbType.VarChar).Value = BoxQuantity
                        .Add("@PiecesPerBox", SqlDbType.VarChar).Value = PiecesPerBox
                        .Add("@TotalPieces", SqlDbType.VarChar).Value = TotalPieces
                        .Add("@RackingWeight", SqlDbType.VarChar).Value = RackingWeight
                        .Add("@ActivityDate", SqlDbType.VarChar).Value = Today()
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    ShowData()
                    LoadTotalInRack()
                Catch ex As Exception
                    'Skip Update
                End Try
            ElseIf button = DialogResult.No Then
                cmdExit.Focus()
            End If
        Else
            'Skip Update
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub lblTotalInRack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTotalInRack.Click

    End Sub
End Class