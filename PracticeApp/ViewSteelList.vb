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
Public Class ViewSteelList
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim dt As DataTable

    Dim CarbonFilter, SteelSizeFilter, ZeroQOHFilter, TextFilter, TWDFilter, TWEFilter, ToolFilter, ABallFilter, OtherFiler As String
    Dim TotalSteelWeight, TotalCoilQty, TotalValueQty As Double

    Private Sub LoadTotalWeight()
        Dim TotalSteelWeightString As String = "SELECT SUM(SteelEndingInventory) FROM SteelInventoryTotals WHERE RMID NOT LIKE 'ABALL%' AND SteelStatus <> 'CLOSED'" + CarbonFilter + SteelSizeFilter + ZeroQOHFilter + TextFilter + TWDFilter + TWEFilter + ToolFilter + ABallFilter + OtherFiler
        Dim TotalSteelWeightCommand As New SqlCommand(TotalSteelWeightString, con)

        Dim TotalCoilQtyString As String = "SELECT SUM(TotalCoilQuantity) FROM SteelInventoryTotals WHERE RMID NOT LIKE 'ABALL%' AND SteelStatus <> 'CLOSED'" + CarbonFilter + SteelSizeFilter + ZeroQOHFilter + TextFilter + TWDFilter + TWEFilter + ToolFilter + ABallFilter + OtherFiler
        Dim TotalCoilQtyCommand As New SqlCommand(TotalCoilQtyString, con)

        Dim TotalValueQtyString As String = "SELECT SUM(ValuationQuantity) FROM SteelInventoryTotals WHERE RMID NOT LIKE 'ABALL%' AND SteelStatus <> 'CLOSED'" + CarbonFilter + SteelSizeFilter + ZeroQOHFilter + TextFilter + TWDFilter + TWEFilter + ToolFilter + ABallFilter + OtherFiler
        Dim TotalValueQtyCommand As New SqlCommand(TotalValueQtyString, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalSteelWeight = CDbl(TotalSteelWeightCommand.ExecuteScalar)
        Catch ex As Exception
            TotalSteelWeight = 0
        End Try
        Try
            TotalCoilQty = CDbl(TotalCoilQtyCommand.ExecuteScalar)
        Catch ex As Exception
            TotalCoilQty = 0
        End Try
        Try
            TotalValueQty = CDbl(TotalValueQtyCommand.ExecuteScalar)
        Catch ex As Exception
            TotalValueQty = 0
        End Try
        con.Close()

        lblTotalWeight.Text = FormatNumber(TotalSteelWeight, 0)
        lblTotalCoilWeight.Text = FormatNumber(TotalCoilQty, 0)
        lblTotalValueWeight.Text = FormatNumber(TotalValueQty, 0)
    End Sub

    Private Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY Carbon", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "RawMaterialsTable")
        cboCarbon.DataSource = ds1.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable WHERE DivisionID = @DivisionID ORDER BY SteelSize", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSize.SelectedIndex = -1
    End Sub

    Public Sub LoadFormatting()
        Dim RowRMID As String = ""
        Dim RowQOH As Double = 0
        Dim RowValueQuantity As Double = 0
        Dim RowCoilQuantity As Double = 0
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvSteelList.Rows
            Try
                RowRMID = row.Cells("RMIDColumn").Value
            Catch ex As System.Exception
                RowRMID = ""
            End Try
            Try
                RowQOH = row.Cells("SteelEndingInventoryColumn").Value
            Catch ex As System.Exception
                RowQOH = 0
            End Try
            Try
                RowValueQuantity = row.Cells("ValuationQuantityColumn").Value
            Catch ex As System.Exception
                RowValueQuantity = 0
            End Try
            Try
                RowCoilQuantity = row.Cells("TotalCoilQuantityColumn").Value
            Catch ex As System.Exception
                RowCoilQuantity = 0
            End Try

            If RowQOH = RowValueQuantity And RowQOH = RowCoilQuantity Then
                Me.dgvSteelList.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvSteelList.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                Me.dgvSteelList.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightYellow
                Me.dgvSteelList.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub ShowByFilters()
        If cboCarbon.Text <> "" Then
            If chkShowAllTypes.Checked = True Then
                CarbonFilter = " AND Carbon LIKE '" + cboCarbon.Text + "%'"
            Else
                CarbonFilter = " AND Carbon = '" + cboCarbon.Text + "'"
            End If
        Else
            CarbonFilter = ""
        End If
        If cboSize.Text <> "" Then
            SteelSizeFilter = " AND (SteelSize = '" + cboSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSize.Text) + "')"
        Else
            SteelSizeFilter = ""
        End If
        If chkOmitZero.Checked = True Then
            ZeroQOHFilter = " AND SteelEndingInventory <> 0"
        Else
            ZeroQOHFilter = ""
        End If
        If txtTextFilter.Text = "" Then
            TextFilter = ""
        Else
            TextFilter = " AND (RMID LIKE '%" + txtTextFilter.Text + "%' OR Carbon Like '%" + txtTextFilter.Text + "%' OR SteelSize LIKE '%" + txtTextFilter.Text + "%')"
        End If
        If chkABall.Checked = False And chkOther.Checked = False And chkToolSteel.Checked = False And chkTWDSteel.Checked = False And chkTWESteel.Checked = False Then
            TWDFilter = ""
            TWEFilter = ""
            ToolFilter = ""
            OtherFiler = ""
            ABallFilter = ""
        Else
            If chkToolSteel.Checked = True Then
                ToolFilter = " AND SteelClass = 'TOOL STEEL'"
            Else
                ToolFilter = ""
            End If
            If chkTWDSteel.Checked = True Then
                TWDFilter = " AND SteelClass = 'TWD STEEL(INVENTORY)'"
            Else
                TWDFilter = ""
            End If
            If chkTWESteel.Checked = True Then
                TWEFilter = " AND SteelClass = 'TWE STEEL (ACCESSORIES)'"
            Else
                TWEFilter = ""
            End If
            If chkABall.Checked = True Then
                ABallFilter = " AND SteelClass = 'ALUMINUM BALL'"
            Else
                ABallFilter = ""
            End If
            If chkOther.Checked = True Then
                OtherFiler = " AND SteelClass = 'OTHER'"
            Else
                OtherFiler = ""
            End If
        End If

        cmd = New SqlCommand("SELECT * FROM SteelInventoryTotals WHERE SteelStatus <> 'CLOSED' AND RMID <> ''" + CarbonFilter + SteelSizeFilter + ZeroQOHFilter + TextFilter + TWDFilter + TWEFilter + ToolFilter + ABallFilter + OtherFiler + " ORDER BY Carbon, SteelSize DESC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelInventoryTotals")
        dgvSteelList.DataSource = ds.Tables("SteelInventoryTotals")
        con.Close()

        LoadFormatting()
        LoadTotalWeight()
    End Sub

    Public Sub ClearData()
        cboCarbon.SelectedIndex = -1
        cboSize.SelectedIndex = -1

        chkOmitZero.Checked = False
        chkShowAllTypes.Checked = False
        chkABall.Checked = False
        chkOther.Checked = False
        chkToolSteel.Checked = False
        chkTWDSteel.Checked = False
        chkTWESteel.Checked = False

        txtTextFilter.Clear()

        lblTotalCoilWeight.Text = ""
        lblTotalValueWeight.Text = ""
        lblTotalWeight.Text = ""
    End Sub

    Public Sub ClearVariables()
        CarbonFilter = ""
        SteelSizeFilter = ""
        ZeroQOHFilter = ""
        TextFilter = ""
        TWDFilter = ""
        TWEFilter = ""
        ToolFilter = ""
        ABallFilter = ""
        OtherFiler = ""
    End Sub

    Public Sub ClearDatagrid()
        dgvSteelList.DataSource = Nothing
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintListingToolStripMenuItem.Click
        If dgvSteelList.DataSource IsNot Nothing Then
            GDS = ds

            Using NewPrintSteelList As New PrintSteelList()
                Dim Result = NewPrintSteelList.ShowDialog()
            End Using
        Else
            MessageBox.Show("You must view steel.", "View steel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSize.TextChanged
        If cboSize.Text.StartsWith(".") And cboSize.Text.Length = 1 Then
            cboSize.Text = "0."
            cboSize.Select(cboSize.Text.Length, 0)
        End If
    End Sub

    Private Sub cboSize_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSize.Leave
        If Not String.IsNullOrEmpty(cboSize.Text) AndAlso cboSize.SelectedIndex = -1 Then
            If cboSize.Text.Contains("/") Then
                If CType(cboSize.DataSource, Data.DataTable).Select("SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSize.Text) + "'").Length > 0 Then
                    cboSize.Text = usefulFunctions.ConvertToDecimal(cboSize.Text)
                End If
            Else
                If CType(cboSize.DataSource, Data.DataTable).Select("SteelSize = '" + usefulFunctions.GetFractional(cboSize.Text) + "'").Length > 0 Then
                    cboSize.Text = usefulFunctions.GetFractional(cboSize.Text)
                End If
            End If
        End If
    End Sub

    Private Sub ViewSteelList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCarbon()
        LoadSteelSize()

        ClearData()
        ClearVariables()
        ClearDatagrid()
    End Sub

    Private Sub dgvSteelList_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSteelList.ColumnHeaderMouseClick
        LoadFormatting()
    End Sub

    Private Sub dgvSteelList_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSteelList.Sorted
        LoadFormatting()
    End Sub
End Class