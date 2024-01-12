Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ViewSteelCoils
    Inherits System.Windows.Forms.Form

    Dim PONumber As Integer = 0
    Dim TotalNumberOfCoils As Integer = 0
    Dim TotalSteelWeight As Double = 0

    'Variables for filters
    Dim strPONumber, TextFilter, StatusFilter, CoilIDFilter, HeatFilter, CarbonFilter, SteelSizeFilter, DateFilter, POFilter, AnnealLotFilter, LocationFilter, InventoryIDFilter, DespatchFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim dt As DataTable

    Dim CoilComment As New SteelCoilPopup()

    Private Sub ViewSteelCoils_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        If EmployeeLoginName = "RBENNETT" Or EmployeeLoginName = "AFINCHAM" Or EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            AddNewCoilDataToolStripMenuItem.Enabled = True
            CloseCoilToolStripMenuItem.Enabled = True
            Me.dgvSteelCoils.Columns("StatusColumn").ReadOnly = False
        Else
            AddNewCoilDataToolStripMenuItem.Enabled = False
            CloseCoilToolStripMenuItem.Enabled = False
            Me.dgvSteelCoils.Columns("StatusColumn").ReadOnly = True
        End If

        LoadCarbon()
        LoadSteelSize()
        LoadCoilID()
        LoadAnnealingLots()
        LoadDespatchNumber()
        LoadPurchaseOrder()
        LoadHeatNumber()

        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSteelCoils.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboCoilID.Text <> "" Then
            CoilIDFilter = " AND CoilID = '" + cboCoilID.Text + "'"
        Else
            CoilIDFilter = ""
        End If
        If cboAnnealingLot.Text <> "" Then
            AnnealLotFilter = " AND AnnealLot = '" + cboAnnealingLot.Text + "'"
        Else
            AnnealLotFilter = ""
        End If
        If cboCarbon.Text <> "" Then
            If chkShowAllTypes.Checked = True Then
                CarbonFilter = " AND Carbon LIKE '" + cboCarbon.Text + "%'"
            Else
                CarbonFilter = " AND Carbon = '" + cboCarbon.Text + "'"
            End If
        Else
            CarbonFilter = ""
        End If
        If cboSteelSize.Text <> "" Then
            SteelSizeFilter = " AND (SteelSize = '" + cboSteelSize.Text + "' OR SteelSize = '" + usefulFunctions.ConvertToDecimal(cboSteelSize.Text) + "')"
        Else
            SteelSizeFilter = ""
        End If
        If txtTextSearch.Text <> "" Then
            TextFilter = " AND (Carbon LIKE '%" + txtTextSearch.Text + "%' OR SteelSize LIKE '%" + txtTextSearch.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboPONumber.Text <> "" Then
            PONumber = Val(cboPONumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PurchaseOrderNumber = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If cboDespatchNumber.Text <> "" Then
            DespatchFilter = " AND DespatchNumber = '" + cboDespatchNumber.Text + "'"
        Else
            DespatchFilter = ""
        End If
        If txtInventoryID.Text <> "" Then
            InventoryIDFilter = " AND InventoryID = '" + txtInventoryID.Text + "'"
        Else
            InventoryIDFilter = ""
        End If
        If cboHeatNumber.Text <> "" Then
            HeatFilter = " AND HeatNumber = '" + cboHeatNumber.Text + "'"
        Else
            HeatFilter = ""
        End If
        If txtLocation.Text <> "" Then
            LocationFilter = " AND Location LIKE '%" + txtLocation.Text + "%'"
        Else
            LocationFilter = ""
        End If
        If cboStatus.Text <> "" Then
            StatusFilter = " AND Status = '" + cboStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND ReceiveDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM CharterSteelCoilIdentification WHERE Status <> @Status" + POFilter + CoilIDFilter + CarbonFilter + SteelSizeFilter + TextFilter + HeatFilter + LocationFilter + StatusFilter + AnnealLotFilter + DespatchFilter + InventoryIDFilter + DateFilter + " ORDER BY Carbon, SteelSize", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "DELETED"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CharterSteelCoilIdentification")
        dgvSteelCoils.DataSource = ds.Tables("CharterSteelCoilIdentification")
        con.Close()

        LoadFormatting()
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
        cboSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub LoadPurchaseOrder()
        cmd = New SqlCommand("SELECT SteelPurchaseOrderKey FROM SteelPurchaseOrderHeader WHERE DivisionID = @DivisionID ORDER BY SteelPurchaseOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SteelPurchaseOrderHeader")
        cboPONumber.DataSource = ds3.Tables("SteelPurchaseOrderHeader")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Private Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT HeatNumber FROM HeatNumberLog ORDER BY HeatNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "HeatNumberLog")
        cboHeatNumber.DataSource = ds4.Tables("HeatNumberLog")
        con.Close()
        cboHeatNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadCoilID()
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification ORDER BY HeatNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "CharterSteelCoilIdentification")
        cboCoilID.DataSource = ds5.Tables("CharterSteelCoilIdentification")
        con.Close()
        cboCoilID.SelectedIndex = -1
    End Sub

    Private Sub LoadDespatchNumber()
        cmd = New SqlCommand("SELECT DISTINCT DespatchNumber FROM CharterSteelCoilIdentification ORDER BY DespatchNumber DESC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CharterSteelCoilIdentification")
        cboDespatchNumber.DataSource = ds6.Tables("CharterSteelCoilIdentification")
        con.Close()
        cboDespatchNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadAnnealingLots()
        cmd = New SqlCommand("SELECT AnnealLotNumber FROM AnnealingLog ORDER BY AnnealLotNumber DESC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "AnnealingLog")
        cboAnnealingLot.DataSource = ds7.Tables("AnnealingLog")
        con.Close()
        cboAnnealingLot.SelectedIndex = -1
    End Sub

    Private Sub LoadTotals()
        cmd.CommandText = "SELECT COUNT(CharterSteelCoilIdentification.CoilID) as CoilCount, SUM(Weight) as TotalWeight FROM CharterSteelCoilIdentification WHERE Status <> @Status" + POFilter + CoilIDFilter + CarbonFilter + SteelSizeFilter + HeatFilter + LocationFilter + StatusFilter + AnnealLotFilter + DespatchFilter + InventoryIDFilter + DateFilter

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CoilCount")) Then
                TotalNumberOfCoils = 0
            Else
                TotalNumberOfCoils = reader.Item("CoilCount")
            End If
            If IsDBNull(reader.Item("TotalWeight")) Then
                TotalSteelWeight = 0
            Else
                TotalSteelWeight = reader.Item("TotalWeight")
            End If
        Else
            TotalNumberOfCoils = 0
            TotalSteelWeight = 0
        End If
        reader.Close()
        con.Close()

        txtTotalCoils.Text = FormatNumber(TotalNumberOfCoils, 0)
        txtTotalWeight.Text = FormatNumber(TotalSteelWeight, 1)
    End Sub

    Public Sub ClearData()
        cboCarbon.SelectedIndex = -1
        cboCoilID.SelectedIndex = -1
        cboDespatchNumber.SelectedIndex = -1
        cboHeatNumber.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboAnnealingLot.SelectedIndex = -1

        cboStatus.Text = "RAW"

        If Not String.IsNullOrEmpty(cboAnnealingLot.Text) Then
            cboAnnealingLot.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboCarbon.Text) Then
            cboCarbon.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboCoilID.Text) Then
            cboCoilID.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboDespatchNumber.Text) Then
            cboDespatchNumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cboHeatNumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboPONumber.Text) Then
            cboPONumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboSteelSize.Text) Then
            cboSteelSize.Text = ""
        End If

        txtTotalCoils.Clear()
        txtTotalWeight.Clear()
        txtLocation.Clear()
        txtInventoryID.Clear()
        txtTextSearch.Clear()

        chkDateRange.Checked = False
        chkShowAllTypes.Checked = False

        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now

        cboCoilID.Focus()
    End Sub

    Public Sub ClearVariables()
        PONumber = 0
        TotalNumberOfCoils = 0
        TotalSteelWeight = 0
        strPONumber = ""
        StatusFilter = ""
        CoilIDFilter = ""
        HeatFilter = ""
        CarbonFilter = ""
        SteelSizeFilter = ""
        DateFilter = ""
        POFilter = ""
        AnnealLotFilter = ""
        LocationFilter = ""
        InventoryIDFilter = ""
        DespatchFilter = ""
        TextFilter = ""
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
        LoadTotals()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub dgvSteelCoils_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSteelCoils.CellDoubleClick
        If dgvSteelCoils.RowCount = 0 Then
            'Skip
        Else
            Dim RowCoilID As String = ""

            Dim RowIndex As Integer = Me.dgvSteelCoils.CurrentCell.RowIndex

            Try
                RowCoilID = Me.dgvSteelCoils.Rows(RowIndex).Cells("CoilIDColumn").Value
            Catch ex As Exception
                RowCoilID = ""
            End Try

            GlobalCoilID = RowCoilID

            Using NewSteelCoilPopup As New SteelCoilPopup
                Dim Result = NewSteelCoilPopup.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvSteelCoils_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSteelCoils.CellValueChanged
        If dgvSteelCoils.RowCount = 0 Then
            'Skip
        Else
            Dim RowStatus, RowCoilID, RowHeatNumber, RowCarbon, RowSteelSize, RowDescription, RowComment, RowLocation, RowAnnealLot, RowInventoryID As String

            Dim RowIndex As Integer = Me.dgvSteelCoils.CurrentCell.RowIndex

            Try
                RowCoilID = Me.dgvSteelCoils.Rows(RowIndex).Cells("CoilIDColumn").Value
            Catch ex As Exception
                RowCoilID = ""
            End Try
            Try
                RowHeatNumber = Me.dgvSteelCoils.Rows(RowIndex).Cells("HeatNumberColumn").Value
            Catch ex As Exception
                RowHeatNumber = ""
            End Try
            Try
                RowCarbon = Me.dgvSteelCoils.Rows(RowIndex).Cells("CarbonColumn").Value
            Catch ex As Exception
                RowCarbon = ""
            End Try
            Try
                RowSteelSize = Me.dgvSteelCoils.Rows(RowIndex).Cells("SteelSizeColumn").Value
            Catch ex As Exception
                RowSteelSize = ""
            End Try
            Try
                RowDescription = Me.dgvSteelCoils.Rows(RowIndex).Cells("DescriptionColumn").Value
            Catch ex As Exception
                RowDescription = ""
            End Try
            Try
                RowComment = Me.dgvSteelCoils.Rows(RowIndex).Cells("CommentColumn").Value
            Catch ex As Exception
                RowComment = ""
            End Try
            Try
                RowLocation = Me.dgvSteelCoils.Rows(RowIndex).Cells("LocationColumn").Value
            Catch ex As Exception
                RowLocation = ""
            End Try
            Try
                RowAnnealLot = Me.dgvSteelCoils.Rows(RowIndex).Cells("AnnealLotColumn").Value
            Catch ex As Exception
                RowAnnealLot = ""
            End Try
            Try
                RowInventoryID = Me.dgvSteelCoils.Rows(RowIndex).Cells("InventoryIDColumn").Value
            Catch ex As Exception
                RowInventoryID = ""
            End Try
            Try
                RowStatus = Me.dgvSteelCoils.Rows(RowIndex).Cells("StatusColumn").Value
            Catch ex As Exception
                RowStatus = ""
            End Try

            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET HeatNumber = @HeatNumber, Carbon = @Carbon, SteelSize = @SteelSize, Description = @Description, Location = @Location, InventoryID = @InventoryID, AnnealLot = @AnnealLot, Comment = @Comment, Status = @Status WHERE CoilID = @CoilID", con)

                With cmd.Parameters
                    .Add("@CoilID", SqlDbType.VarChar).Value = RowCoilID
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                    .Add("@Carbon", SqlDbType.VarChar).Value = RowCarbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = RowSteelSize
                    .Add("@Description", SqlDbType.VarChar).Value = RowDescription
                    .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                    .Add("@Location", SqlDbType.VarChar).Value = RowLocation
                    .Add("@AnnealLot", SqlDbType.VarChar).Value = RowAnnealLot
                    .Add("@InventoryID", SqlDbType.VarChar).Value = RowInventoryID
                    .Add("@Status", SqlDbType.VarChar).Value = RowStatus
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
            End Try
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintListingToolStripMenuItem.Click
        GDS = ds

        Using NewPrintCoilListing As New PrintCoilListing
            Dim Result = NewPrintCoilListing.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrintCoilTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintCoilTag.Click
        If dgvSteelCoils.Rows.Count > 0 Then
            If dgvSteelCoils.CurrentRow IsNot Nothing Then
                Dim barc As New BarcodeLabel
                barc.setupYardLabel(dgvSteelCoils.CurrentRow.Cells("CoilIDColumn").Value, 1)
                If Environment.UserName.Contains("WireyardTablet") Then
                    barc.PrintBarcodeLine("ZebraWireyard")
                Else
                    barc.PrintBarcodeLine()
                End If
            End If
        End If
    End Sub

    Public Sub LoadFormatting()
        Dim RowComment As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvSteelCoils.Rows
            Try
                RowComment = row.Cells("CommentColumn").Value
            Catch ex As System.Exception
                RowComment = ""
            End Try

            If RowComment = "" Then
                Me.dgvSteelCoils.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvSteelCoils.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                Me.dgvSteelCoils.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvSteelCoils.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub dgvSteelCoils_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvSteelCoils.Sorted
        LoadFormatting()
    End Sub

    Private Sub cboCarbon_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCarbon.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboHeatNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboHeatNumber.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboStatus_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboStatus.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSteelSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSteelSize.TextChanged
        If cboSteelSize.Text.StartsWith(".") Then
            cboSteelSize.Text = "0."
            cboSteelSize.Select(cboSteelSize.Text.Length, 0)
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub AddNewCoilDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewCoilDataToolStripMenuItem.Click
        Using NewSteelAddNewCoil As New SteelAddNewCoilForm
            Dim Result = NewSteelAddNewCoil.ShowDialog()
        End Using
    End Sub

    Private Sub CloseCoilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseCoilToolStripMenuItem.Click
        Dim RowCoilID, RowCoilStatus As String

        If Me.dgvSteelCoils.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvSteelCoils.CurrentCell.RowIndex

            Try
                RowCoilID = Me.dgvSteelCoils.Rows(RowIndex).Cells("CoilIDColumn").Value
            Catch ex As Exception
                RowCoilID = ""
            End Try
            Try
                RowCoilStatus = Me.dgvSteelCoils.Rows(RowIndex).Cells("StatusColumn").Value
            Catch ex As Exception
                RowCoilStatus = ""
            End Try

            If RowCoilStatus = "RAW" Then
                Try
                    'UPDATE Purchase Order Extended Amount based on line changes
                    cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Status = @Status WHERE CoilID = @CoilID", con)

                    With cmd.Parameters
                        .Add("@CoilID", SqlDbType.VarChar).Value = RowCoilID
                        .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    cmdView_Click(sender, e)
                Catch ex As Exception
                    'Error Log
                End Try
            Else
                MsgBox("Coil is not in wireyard inventory.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub ViewCoilsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewCoilsToolStripMenuItem.Click
        cmdView_Click(sender, e)
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        cmdClear_Click(sender, e)
    End Sub

    Private Sub PrintCoilTagToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCoilTagToolStripMenuItem.Click
        cmdPrintCoilTag_Click(sender, e)
    End Sub
End Class