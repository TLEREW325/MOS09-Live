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
'updatedeleteline function: put ds in the call function parameter and in the function used byval ds as dataset <- is this ok? (did this to get rid of global variables)
Public Class SteelAdjustmentForm
    Inherits System.Windows.Forms.Form

    Dim SteelBatchItems As Integer = 0
    Dim SteelBatchWeight As Double = 0
    Dim SteelBatchAmount As Double = 0
    Dim IsSteelTypeValid As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim isloaded As Boolean = False
    Dim controlKey As Boolean = False
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12, myAdapter13, myAdapter14, myAdapter15, myAdapter16, myAdapter17, myAdapter18 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvSteelAdjustmentLines.CellValueChanged
        If isloaded AndAlso Not isSomeoneEditing() Then

            Dim LineExtendedAmount, LineUnitCost, LineOrderQuantity As Double
            Dim LineNumber As Integer
            Dim comment As String
            Dim currentRow As Integer = dgvSteelAdjustmentLines.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvSteelAdjustmentLines.CurrentCell.ColumnIndex

            If dgvSteelAdjustmentLines.Rows(currentRow).Cells("Status").Value.ToString.Equals("CLOSED") Then
                MessageBox.Show("Line can't be changed. Status showing closed. Contact system admin", "Unable to change values", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ShowData()
                dgvSteelAdjustmentLines.CurrentCell = dgvSteelAdjustmentLines.Rows(currentRow).Cells(currentColumn)
                Exit Sub
            End If
            ''UPDATE Line Table on changes in the datagrid
            If IsDBNull(dgvSteelAdjustmentLines.Rows(currentRow).Cells("AdjustmentCostColumn").Value) Then
                LineUnitCost = 0
            Else
                LineUnitCost = dgvSteelAdjustmentLines.Rows(currentRow).Cells("AdjustmentCostColumn").Value
            End If
            If IsDBNull(dgvSteelAdjustmentLines.Rows(currentRow).Cells("AdjustmentWeightColumn").Value) Then
                LineOrderQuantity = 0
            Else
                LineOrderQuantity = dgvSteelAdjustmentLines.Rows(currentRow).Cells("AdjustmentWeightColumn").Value
            End If
            If IsDBNull(dgvSteelAdjustmentLines.Rows(currentRow).Cells("SteelAdjustmentKeyColumn").Value) Then
                LineNumber = -1
            Else
                LineNumber = dgvSteelAdjustmentLines.Rows(currentRow).Cells("SteelAdjustmentKeyColumn").Value
            End If
            If IsDBNull(dgvSteelAdjustmentLines.Rows(currentRow).Cells("CommentColumn").Value) Then
                comment = ""
            Else
                comment = dgvSteelAdjustmentLines.Rows(currentRow).Cells("CommentColumn").Value
            End If

            LineExtendedAmount = Math.Round(LineUnitCost * LineOrderQuantity, 2, MidpointRounding.AwayFromZero)

            'UPDATE Purchase Order Extended Amount based on line changes
            Dim cmd As New SqlCommand("UPDATE SteelAdjustmentTable SET AdjustmentCost = @AdjustmentCost, AdjustmentWeight = @AdjustmentWeight, AdjustmentTotal = @AdjustmentTotal, Comment = @Comment WHERE SteelAdjustmentKey = @SteelAdjustmentKey;", con)

            With cmd.Parameters
                .Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = LineNumber
                .Add("@AdjustmentCost", SqlDbType.VarChar).Value = LineUnitCost
                .Add("@AdjustmentWeight", SqlDbType.VarChar).Value = LineOrderQuantity
                .Add("@AdjustmentTotal", SqlDbType.VarChar).Value = LineExtendedAmount
                .Add("@Comment", SqlDbType.VarChar).Value = comment
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadAdjustmentBatchTotals()
            isloaded = False
            ShowData()

            ''resets the position in the datagrid to the last position
            Try
                dgvSteelAdjustmentLines.CurrentCell = dgvSteelAdjustmentLines.Rows(currentRow).Cells(currentColumn)
            Catch ex As System.Exception

            End Try

            isloaded = True
        End If
    End Sub

    Public Sub ShowData()
        Dim cmd As New SqlCommand("SELECT * FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber;", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "SteelAdjustmentTable")
        con.Close()
        If cboDeleteLine.DisplayMember <> "SteelAdjustmentKey" Then cboDeleteLine.DisplayMember = "SteelAdjustmentKey"
        cboDeleteLine.DataSource = ds.Tables("SteelAdjustmentTable")
        dgvSteelAdjustmentLines.DataSource = ds.Tables("SteelAdjustmentTable")
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSteelAdjustmentLines.DataSource = Nothing
    End Sub

    Public Sub LoadCarbon()
        Dim cmd As New SqlCommand("SELECT DISTINCT(Carbon) FROM RawMaterialsTable;", con)
        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "RawMaterialsTable")
        con.Close()

        cboAdjustCarbon.DisplayMember = "Carbon"
        cboAdjustCarbon.DataSource = ds.Tables("RawMaterialsTable")
        cboAdjustCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelSize()
        Dim tmp As String = cboAdjustSteelSize.Text
        Dim cmd As New SqlCommand("SELECT DISTINCT(SteelSize) FROM RawMaterialsTable WHERE Carbon = @Carbon;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboAdjustCarbon.Text
        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "RawMaterialsTable")
        con.Close()

        cboAdjustSteelSize.DisplayMember = "SteelSize"
        cboAdjustSteelSize.DataSource = ds.Tables("RawMaterialsTable")
        cboAdjustSteelSize.SelectedIndex = -1

        cboAdjustSteelSize.Text = tmp
    End Sub

    Public Sub LoadAdjustmentNumber()
        Dim chg As Integer
        If String.IsNullOrEmpty(cboAdjustmentBatchNumber.Text) Then
            chg = -1
        Else
            chg = cboAdjustmentBatchNumber.Text
        End If

        Dim cmd As New SqlCommand("SELECT SteelAdjustmentKey FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber;", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = chg
        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "SteelAdjustmentTable")
        con.Close()

        cboAdjustmentNumber.DisplayMember = "SteelAdjustmentKey"
        cboAdjustmentNumber.DataSource = ds.Tables("SteelAdjustmentTable")
        cboAdjustmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBatchNumber()
        Dim cmd As New SqlCommand("SELECT DISTINCT(BatchNumber) FROM SteelAdjustmentTable WHERE DivisionID = @DivisionID ORDER BY BatchNumber DESC;", con)
        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        Dim ds As New DataSet()
        Dim myAdapter As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "SteelAdjustmentTable")
        con.Close()

        cboAdjustmentBatchNumber.DisplayMember = "BatchNumber"
        cboAdjustmentBatchNumber.DataSource = ds.Tables("SteelAdjustmentTable")
        cboAdjustmentBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBatchStatus()
        Dim BatchStatus As String
        Dim BatchStatusStatement As String = "SELECT Status, AdjustmentDate FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber;"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = BatchStatusCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Status")) Then
                BatchStatus = "OPEN"
            Else
                BatchStatus = reader.Item("Status")
            End If
            If IsDBNull(reader.Item("AdjustmentDate")) Then
                dtpAdjustmentDate.Value = Today.Date
            Else
                dtpAdjustmentDate.Value = reader.Item("AdjustmentDate")
            End If
        Else
            BatchStatus = "OPEN"
            dtpAdjustmentDate.Value = Today.Date
        End If
        reader.Close()
        con.Close()

        txtBatchStatus.Text = BatchStatus

        If BatchStatus = "CLOSED" Then
            cmdDelete.Enabled = False
            cmdEnter.Enabled = False
            cmdPostAdjustment.Enabled = False
            cmdDeleteAdjustment.Enabled = False
            DeleteAdjustmentToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnter.Enabled = True
            cmdPostAdjustment.Enabled = True
            cmdDeleteAdjustment.Enabled = True
            DeleteAdjustmentToolStripMenuItem.Enabled = True
        End If
    End Sub

    Public Sub LoadAdjustmentData()
        Dim AdjustmentWeight As Double = 0.0
        Dim AdjustmentCost As Double = 0.0
        Dim AdjustmentTotal As Double
        Dim RMID, SteelCarbon, SteelSize, AdjustmentDate, Comment As String

        Dim RMIDStatement As String = "SELECT RMID, SteelCarbon, SteelSize, AdjustmentDate, AdjustmentWeight, AdjustmentCost, Comment, AdjustmentTotal FROM SteelAdjustmentTable WHERE SteelAdjustmentKey = @SteelAdjustmentKey;"
        Dim RMIDCommand As New SqlCommand(RMIDStatement, con)
        RMIDCommand.Parameters.Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = RMIDCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("RMID")) Then
                RMID = ""
            Else
                RMID = reader.Item("RMID")
            End If
            If IsDBNull(reader.Item("SteelCarbon")) Then
                SteelCarbon = ""
            Else
                SteelCarbon = reader.Item("SteelCarbon")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                SteelSize = ""
            Else
                SteelSize = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("AdjustmentDate")) Then
                AdjustmentDate = Today()
            Else
                AdjustmentDate = reader.Item("AdjustmentDate")
            End If
            If IsDBNull(reader.Item("AdjustmentWeight")) Then
                AdjustmentWeight = 0
            Else
                AdjustmentWeight = reader.Item("AdjustmentWeight")
            End If
            If IsDBNull(reader.Item("AdjustmentCost")) Then
                AdjustmentCost = 0
            Else
                AdjustmentCost = reader.Item("AdjustmentCost")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                Comment = ""
            Else
                Comment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("AdjustmentTotal")) Then
                AdjustmentTotal = 0
            Else
                AdjustmentTotal = reader.Item("AdjustmentTotal")
            End If
        Else
            RMID = ""
            SteelCarbon = ""
            SteelSize = ""
            AdjustmentDate = Today()
            AdjustmentWeight = 0
            AdjustmentCost = 0
            Comment = ""
            AdjustmentTotal = 0
        End If
        reader.Close()
        con.Close()

        isloaded = False
        cboAdjustCarbon.Text = SteelCarbon
        cboAdjustSteelSize.Text = SteelSize
        txtAdjustmentCost.Text = Math.Round(AdjustmentCost, 4)
        txtAdjustmentWeight.Text = AdjustmentWeight
        txtAdjustmentTotal.Text = Math.Round(AdjustmentTotal, 2)
        txtComment.Text = Comment
        isloaded = True
    End Sub

    Public Sub LoadAdjustmentBatchTotals()
        Dim SteelBatchAmountStatement As String = "SELECT SUM(AdjustmentTotal) FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber"
        Dim SteelBatchAmountCommand As New SqlCommand(SteelBatchAmountStatement, con)
        SteelBatchAmountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)

        Dim SteelBatchItemsStatement As String = "SELECT COUNT(SteelAdjustmentKey) FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber"
        Dim SteelBatchItemsCommand As New SqlCommand(SteelBatchItemsStatement, con)
        SteelBatchItemsCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)

        Dim SteelBatchWeightStatement As String = "SELECT SUM(AdjustmentWeight) FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber"
        Dim SteelBatchWeightCommand As New SqlCommand(SteelBatchWeightStatement, con)
        SteelBatchWeightCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelBatchAmount = CDbl(SteelBatchAmountCommand.ExecuteScalar)
        Catch ex As Exception
            SteelBatchAmount = 0
        End Try
        Try
            SteelBatchItems = CInt(SteelBatchItemsCommand.ExecuteScalar)
        Catch ex As Exception
            SteelBatchItems = 0
        End Try
        Try
            SteelBatchWeight = CDbl(SteelBatchWeightCommand.ExecuteScalar)
        Catch ex As Exception
            SteelBatchWeight = 0
        End Try
        con.Close()

        txtTotalCost.Text = SteelBatchAmount
        txtTotalItems.Text = SteelBatchItems
        txtTotalWeight.Text = SteelBatchWeight
    End Sub

    Public Sub ClearAdjustmentLines()
        cboAdjustmentNumber.Refresh()
        cboAdjustCarbon.Refresh()
        cboAdjustSteelSize.Refresh()
        isloaded = False
        cboAdjustmentNumber.SelectedIndex = -1
        cboAdjustCarbon.SelectedIndex = -1
        cboAdjustSteelSize.SelectedIndex = -1
        isloaded = True
        txtAdjustmentCost.Clear()

        ''checks the cost and if 0 will enable it
        txtAdjustmentTotal.Clear()
        txtAdjustmentWeight.Clear()
        txtComment.Clear()
        lblQOHLabel.Hide()
        lblQOH.Hide()
        lblQOH.Text = ""
    End Sub

    Public Sub ClearData()
        'Clear all data from text boxes
        cboAdjustmentBatchNumber.Refresh()
        cboAdjustmentNumber.Refresh()
        cboAdjustCarbon.Refresh()

        cboAdjustmentNumber.DataSource = Nothing
        dgvSteelAdjustmentLines.DataSource = Nothing
        cboDeleteLine.DataSource = Nothing

        If Not String.IsNullOrEmpty(cboDeleteLine.Text) Then
            cboDeleteLine.Text = ""
        End If

        cboAdjustmentBatchNumber.SelectedIndex = -1
        cboAdjustmentNumber.SelectedIndex = -1
        cboAdjustCarbon.SelectedIndex = -1
        cboAdjustSteelSize.SelectedIndex = -1
        cboAdjustSteelSize.Text = ""

        dtpAdjustmentDate.Value = Now
        chkChangeCoilSteelType.Checked = False

        txtAdjustmentCost.Clear()
        ''checks the value if 0 will enable it
        txtAdjustmentWeight.Clear()
        txtAdjustmentTotal.Clear()
        txtComment.Clear()
        txtTotalCost.Clear()
        txtTotalItems.Clear()
        txtTotalWeight.Clear()
        txtBatchStatus.Clear()
        txtCoilID.Clear()

        lblOldSteelType.Text = ""

        cmdDelete.Enabled = True
        cmdEnter.Enabled = True
        cmdPostAdjustment.Enabled = True

        cboAdjustmentBatchNumber.Focus()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearAdjustmentLines()
    End Sub

    Private Sub cmdGenerateAdjustmentNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateAdjustmentNumber.Click
        Dim LastTransactionNumber As Integer
        Dim NextTransactionNumber As Integer
        If canGenerateNewAdjustment() Then
            'Clear form on next number
            ClearAdjustmentLines()

            Dim MAXStatement As String = "SELECT MAX(SteelAdjustmentKey) FROM SteelAdjustmentTable;"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As System.Exception
                LastTransactionNumber = 52000
            End Try
            con.Close()

            NextTransactionNumber = LastTransactionNumber + 1
            cboAdjustmentNumber.Text = NextTransactionNumber

            'Save Adjustment number so it can not be selected again
            Try
                updateOrInsertIntoSteelAdjustmentTable("OPEN", 0)
            Catch ex As System.Exception
                sendErrorToDataBase("SteelAdjustmentForm - cmdGenerateAdjustmentNumber --Error trying to insert new steelAdjustmentKey into SteelAdjustmentTable", "Steel adjustment #" + NextTransactionNumber.ToString(), ex.ToString())
                MessageBox.Show("Unable to save newly generated adjustment number. Contact your system admin", "Unable to generate new adjustment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
            isloaded = False
            LoadAdjustmentNumber()
            cboAdjustmentNumber.Text = NextTransactionNumber
            isloaded = True
            cboAdjustCarbon.Focus()
        End If

    End Sub

    Private Function canGenerateNewAdjustment() As Boolean
        If isSomeoneEditing() Then
            Return False
        End If
        If String.IsNullOrEmpty(cboAdjustmentBatchNumber.Text) Then
            MessageBox.Show("You must enter a batch before generating a new Adjustment", "Generate Batch First", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentBatchNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Public Sub ValidateSteel()
        Dim CheckRMIDInSteelList As Integer = 0

        Dim CheckScheduledRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize AND DivisionID = @DivisionID AND SteelStatus <> 'CLOSED'"
        Dim CheckScheduledRMIDCommand As New SqlCommand(CheckScheduledRMIDStatement, con)
        CheckScheduledRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboAdjustCarbon.Text
        CheckScheduledRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboAdjustSteelSize.Text
        CheckScheduledRMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckRMIDInSteelList = CInt(CheckScheduledRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            CheckRMIDInSteelList = 0
        End Try
        con.Close()

        If CheckRMIDInSteelList = 0 Then
            IsSteelTypeValid = "INVALID STEEL"
        Else
            IsSteelTypeValid = "VALID STEEL"
        End If
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If canAddAdjust() Then
            If Val(txtAdjustmentTotal.Text) = 0 Then txtAdjustmentTotal.Text = Math.Round(Val(txtAdjustmentCost.Text) * Val(txtAdjustmentWeight.Text), 2, MidpointRounding.AwayFromZero)
            '**********************************************************************************
            'Check if RMID is valid
            ValidateSteel()

            If IsSteelTypeValid = "INVALID STEEL" Then
                MsgBox("Selected Steel is either closed or does not exist.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '**********************************************************************************
            Try
                updateOrInsertIntoSteelAdjustmentTable("OPEN")
            Catch ex As System.Exception
                sendErrorToDataBase("SteelAdjustmentForm - cmdEnter_Click --Error trying to insert/update into SteelAdjustmentTable", "Batch #" + cboAdjustmentBatchNumber.Text, ex.ToString())
            End Try

            'If checked, change coil id steel type
            If chkChangeCoilSteelType.Checked = True Then
                'Verify steel type and coil
                Dim CheckCoil As Integer = 0

                Dim CheckCoilStatement As String = "SELECT COUNT(CoilID) FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID AND Status = @Status"
                Dim CheckCoilCommand As New SqlCommand(CheckCoilStatement, con)
                CheckCoilCommand.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
                CheckCoilCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "RAW"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckCoil = CInt(CheckCoilCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckCoil = 0
                End Try
                con.Close()

                If CheckCoil = 1 Then
                    'Change Coil Steel Type
                    cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Carbon = @Carbon, SteelType = @SteelType WHERE CoilID = @CoilID", con)

                    With cmd.Parameters
                        .Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text
                        .Add("@Carbon", SqlDbType.VarChar).Value = cboAdjustCarbon.Text
                        .Add("@SteelSize", SqlDbType.VarChar).Value = cboAdjustSteelSize.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Update Steel adjustment table to show old RMID
                    cmd = New SqlCommand("UPDATE SteelAdjustmentTable SET ChangeRMID = @ChangeRMID, ChangeCoilID = @ChangeCoilID WHERE SteelAdjustmentKey = @SteelAdjustmentKey", con)

                    With cmd.Parameters
                        .Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
                        .Add("@ChangeRMID", SqlDbType.VarChar).Value = lblOldSteelType.Text
                        .Add("@ChangeCoilID", SqlDbType.VarChar).Value = txtCoilID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    MsgBox("Coil does not exist or is not in inventory.", MsgBoxStyle.OkOnly)
                End If
            Else
                'Do nothing
            End If

            'Empty text boxes and populate datagrid
            ClearAdjustmentLines()
            ShowData()
            LoadAdjustmentBatchTotals()
            cboAdjustmentNumber.SelectedIndex = -1
            cmdGenerateAdjustmentNumber.Focus()
        End If
    End Sub

    Private Function canAddAdjust() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentBatchNumber.Text) Then
            MessageBox.Show("You must select a batch number", "Select a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentBatchNumber.Focus()
            Return False
        End If
        If cboAdjustmentBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentBatchNumber.SelectAll()
            cboAdjustmentBatchNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        If String.IsNullOrEmpty(cboAdjustmentNumber.Text) Then
            MessageBox.Show("You must select an adjustment number", "Select an adjustment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentNumber.Focus()
            Return False
        End If
        If cboAdjustmentNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid adjustment number", "Enter a valid adjustment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentNumber.SelectAll()
            cboAdjustmentNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboAdjustCarbon.Text) Then
            MessageBox.Show("You must select a carbon", "Select a carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustCarbon.Focus()
            Return False
        End If
        If cboAdjustCarbon.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid carbon", "Enter a valid carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustCarbon.SelectAll()
            cboAdjustCarbon.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboAdjustSteelSize.Text) Then
            MessageBox.Show("You must enter a Steel Size", "Enter a Steel Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustSteelSize.Focus()
            Return False
        End If
        If cboAdjustSteelSize.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Steel Size", "Enter a valid Steel Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustSteelSize.SelectAll()
            cboAdjustSteelSize.Focus()
            Return False
        End If
        If checkValidSteel() Then
            MessageBox.Show("Carbon/Steel Size combination does not match any Raw Materials entered. Make sure you entered the correct Carbon/Steel Size.", "Invalid Carbon/Steel Size", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(txtAdjustmentWeight.Text) Then
            MessageBox.Show("You must enter an adjustment weight", "Enter an adjustment weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAdjustmentWeight.Focus()
            Return False
        End If
        If txtAdjustmentWeight.Text = "0" Then
            MessageBox.Show("You must enter number other than zero for the adjustment weight", "Enter a number for adjustment weight", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAdjustmentWeight.SelectAll()
            txtAdjustmentWeight.Focus()
            Return False
        End If
        If IsNumeric(txtAdjustmentWeight.Text) = False Then
            MessageBox.Show("You must enter a number for the weight", "Etner a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAdjustmentWeight.SelectAll()
            txtAdjustmentWeight.Focus()
            Return False
        End If
        If txtAdjustmentCost.Enabled Then
            If String.IsNullOrEmpty(txtAdjustmentCost.Text) Then
                MessageBox.Show("You must enter an adjustment cost", "Enter an adjustment cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAdjustmentCost.Focus()
                Return False
            End If
            If IsNumeric(txtAdjustmentCost.Text) = False Then
                MessageBox.Show("You must enter a numeric cost", "Enter a numeric cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAdjustmentCost.SelectAll()
                txtAdjustmentCost.Focus()
                Return False
            End If
            If Val(txtAdjustmentCost.Text) <= 0 AndAlso EmployeeSecurityCode > 1002 Then
                MessageBox.Show("You must enter an adjustment unit cost greater than 0", "Enter an adjustment unit cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAdjustmentCost.SelectAll()
                txtAdjustmentCost.Focus()
                Return False
            End If
        End If

        If checkRMID() Then
            Return False
        End If

        Dim cmd As New SqlCommand("SELECT Status FROM SteelAdjustmentTable WHERE SteelAdjustmentKey = @SteelAdjustmentKey AND BatchNumber = @BatchNumber;", con)
        cmd.Parameters.Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = cboAdjustmentNumber.Text
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboAdjustmentBatchNumber.Text
        Dim stat As String = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            stat = cmd.ExecuteScalar()
        Catch ex As System.Exception

        End Try
        con.Close()

        If stat.Equals("CLOSED") Then
            MessageBox.Show("Line can't be changed, status is showing CLOSED", "Unable to change line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Function checkRMID() As Boolean
        Dim RMId As String
        Dim cmd As New SqlCommand("SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @Size;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboAdjustCarbon.Text
        cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = cboAdjustSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("RMID")) Then
                RMId = ""
            Else
                RMId = reader.Item("RMID")
            End If
        Else
            RMId = ""
        End If
        reader.Close()
        con.Close()

        If String.IsNullOrEmpty(RMId) Then
            MessageBox.Show("Steel carbon and size entered do not match a valid raw material. Check entries for carbon and size and try again", "Not a valid raw material", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustCarbon.SelectAll()
            cboAdjustCarbon.Focus()
            Return True
        End If
        Return False
    End Function

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, ExitToolStripMenuItem1.Click
        If Not String.IsNullOrEmpty(cboAdjustmentBatchNumber.Text) Then
            unlockBatch()
        End If
        isloaded = False
        ClearData()
        Me.Close()
    End Sub

    Private Sub txtAdjustmentWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdjustmentWeight.TextChanged
        If isloaded Then
            updateAdjustmentTotal()
        End If
    End Sub

    Private Sub updateAdjustmentTotal()
        txtAdjustmentTotal.Text = FormatCurrency(Val(txtAdjustmentWeight.Text) * Val(txtAdjustmentCost.Text), 2)
    End Sub

    Private Sub cboAdjustmentNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdjustmentNumber.SelectedIndexChanged
        If isloaded Then
            LoadAdjustmentData()
            LoadAdjustmentBatchTotals()
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click, DeleteAdjustmentToolStripMenuItem.Click
        Dim RowChangeRMID, RowChangeCoilID As String

        'Prompt before deleting
        If canDeleteBatch() Then
            'Reset any coil changes made in the adjustment
            For Each LineRow As DataGridViewRow In dgvSteelAdjustmentLines.Rows
                Try
                    RowChangeRMID = LineRow.Cells("ChangeRMIDColumn").Value
                Catch ex As System.Exception
                    RowChangeRMID = ""
                End Try
                Try
                    RowChangeCoilID = LineRow.Cells("ChangeCoilIDColumn").Value
                Catch ex As System.Exception
                    RowChangeCoilID = ""
                End Try

                'Get Carbon and Steel Size for the specific RMID
                Dim GetCarbon As String = ""
                Dim GetSteelSize As String = ""

                Dim GetCarbonStatement As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID"
                Dim GetCarbonCommand As New SqlCommand(GetCarbonStatement, con)
                GetCarbonCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowChangeRMID

                Dim GetSteelSizeStatement As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID"
                Dim GetSteelSizeCommand As New SqlCommand(GetSteelSizeStatement, con)
                GetSteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowChangeRMID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetCarbon = CStr(GetCarbonCommand.ExecuteScalar)
                Catch ex As Exception
                    GetCarbon = ""
                End Try
                Try
                    GetSteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSteelSize = ""
                End Try
                con.Close()

                If RowChangeCoilID <> "" And RowChangeRMID <> "" Then
                    'Update Coil Table
                    cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Carbon = @Carbon, SteelSize = @SteelSize WHERE CoilID = @CoilID", con)

                    With cmd.Parameters
                        .Add("@CoilID", SqlDbType.VarChar).Value = RowChangeCoilID
                        .Add("@Carbon", SqlDbType.VarChar).Value = GetCarbon
                        .Add("@SteelSize", SqlDbType.VarChar).Value = GetSteelSize
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Do nothing
                End If

                GetCarbon = ""
                GetSteelSize = ""
                RowChangeCoilID = ""
                RowChangeRMID = ""
            Next
            '**********************************************************************************************************
            Try
                'Create command to delete data from text boxes
                Dim cmd As New SqlCommand("DELETE FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber;", con)
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("SteelAdjustmentForm - cmdDelete_Click --Error trying to delete batch from SteelAdjustmentTable", "Batch #" + cboAdjustmentBatchNumber.Text, ex.ToString())
                MessageBox.Show("There was a problem deleting batch. Contact system admin", "Error deleting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            '***************************************************************************************************
            'Write to Audit Trail Table
            Dim AuditComment As String = ""
            Dim AuditAdjustmentNumber As Integer = 0
            Dim strAdjustmentNumber As String = ""

            AuditAdjustmentNumber = Val(cboAdjustmentBatchNumber.Text)
            strAdjustmentNumber = CStr(AuditAdjustmentNumber)
            AuditComment = "Adjustment #" + strAdjustmentNumber + " was deleted on " + Today()

            Try
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "STEEL ADJUSTMENT BATCH - DELETION"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = Val(txtTotalCost.Text)
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strAdjustmentNumber
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
            '**************************************************************************************************
            MessageBox.Show("Batch has been deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            isloaded = False
            ClearData()
            LoadBatchNumber()
            isloaded = True
        End If
    End Sub

    Private Function canDeleteBatch() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentBatchNumber.Text) Then
            MessageBox.Show("You must select a batch number to delete", "Select a batch to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentBatchNumber.Focus()
            Return False
        End If
        If cboAdjustmentBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a vlaid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentBatchNumber.SelectAll()
            cboAdjustmentBatchNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this batch?", "Delete batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cmdPostAdjustment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostAdjustment.Click
        Dim CreditAmount, DebitAmount As Double
        If canPost() Then
            LoadAdjustmentBatchTotals()

            ''adds cost tier (if needed) and does steel Transaction
            adjustCostTiersAndTransaction()

            '**********************************
            'Write to General Ledger
            '**********************************

            'Determine if Adjustment Total is a credit or a debit
            If SteelBatchAmount < 0 Then
                DebitAmount = 0
                CreditAmount = SteelBatchAmount * -1
            Else
                DebitAmount = SteelBatchAmount
                CreditAmount = 0
            End If

            Try
                'Write values to the GL Transaction Table
                Dim cmd As New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 22000001) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus);", con)

                With cmd.Parameters
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12000"
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Adjustment"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = DebitAmount
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CreditAmount
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Adjustment Batch Total"
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With
                If EmployeeCompanyCode.Equals("TST") Then
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                Else
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                End If

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("SteelAdjustmentForm - cmdPostAdjustment_Click --Errortrying to write valuse to GLTransactionMasterList", "Batch #" + cboAdjustmentBatchNumber.Text, ex.ToString())
                MessageBox.Show("There was an error writing to GL. Contact system admin", "Error writing to GL", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'Determine if Adjustment Total is a credit or a debit
            If SteelBatchAmount < 0 Then
                CreditAmount = 0
                DebitAmount = SteelBatchAmount * -1
            Else
                CreditAmount = SteelBatchAmount
                DebitAmount = 0
            End If

            Try
                'Write values to the GL Transaction Table
                Dim cmd As New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 22000001) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus);", con)

                With cmd.Parameters
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "59700"
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Adjustment"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = DebitAmount
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = CreditAmount
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Adjustment Batch Total"
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "ADJJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If EmployeeCompanyCode.Equals("TST") Then
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                Else
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                End If

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("SteelAdjustmentForm - cmdPostAdjustment_Click --Errortrying to write valuse to GLTransactionMasterList", "Batch #" + cboAdjustmentBatchNumber.Text, ex.ToString())
                MessageBox.Show("There was an error writing to GL. Contact system admin", "Error writing to GL", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            '**********************************
            'End of Ledger Entry
            '**********************************

            Try
                'Update Steel Adjustment Table to close Adjustment Lines
                Dim cmd As New SqlCommand("UPDATE SteelAdjustmentTable SET Status = 'CLOSED', Locked = '', PrintDate = @PrintDate WHERE BatchNumber = @BatchNumber;", con)
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime2).Value = Now

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("SteelAdjustmentForm - cmdPostAdjustment_Click --Error trying to update status to CLOSED in SteelAdjustmentTable", "Batch #" + cboAdjustmentBatchNumber.Text, ex.ToString())
                MessageBox.Show("There was an error closing adjustment lines, contact system admin", "Error closing lines", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'Reset Form
            isloaded = False
            LoadBatchNumber()
            ClearData()
            isloaded = True

            'Prompt before saving
            MsgBox("Steel Adjustment has been posted.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canPost() As Boolean
        If isSomeoneEditing() Then
            Exit Function
        End If
        If String.IsNullOrEmpty(cboAdjustmentBatchNumber.Text) Then
            MessageBox.Show("You must select a batch to POST", "Select a batch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentBatchNumber.Focus()
            Return False
        End If
        If dgvSteelAdjustmentLines.RowCount = 0 Then
            MessageBox.Show("There are no adjustments to POST", "Enter adjustments", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentNumber.Focus()
            Return False
        End If
        'Save before posting
        If MessageBox.Show("Do you wish to Save and Post this Steel Adjustment? No further changes may be made after it is posted.", "POST STEEL ADJUSTMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If

        Return True
    End Function

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click, PrintAdjustmentToolStripMenuItem.Click
        If canPrint() Then
            Using NewPrintSteelAdjustment As New PrintSteelAdjustment(cboAdjustmentBatchNumber.Text)
                NewPrintSteelAdjustment.ShowDialog()
            End Using
        End If
    End Sub

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentBatchNumber.Text) Then
            MessageBox.Show("You must select a Batch Number.", "Select a Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentBatchNumber.Focus()
            Return False
        End If
        If cboAdjustmentBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Batch Number", "Enter a valid Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentBatchNumber.SelectAll()
            cboAdjustmentBatchNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdBatchNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBatchNumber.Click
        Dim LastBatchNumber As Integer
        Dim NextBatchNumber As Integer
        If Not String.IsNullOrEmpty(cboAdjustmentBatchNumber.Text) Then
            unlockBatch()
        End If
        'Clear form on next number
        isloaded = False
        ClearData()
        isloaded = True

        'Get next Steel Adjustment Batch Number
        Try
            Dim MAXBatchStatement As String = "SELECT MAX(BatchNumber) FROM SteelAdjustmentTable;"
            Dim MAXBatchCommand As New SqlCommand(MAXBatchStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastBatchNumber = CInt(MAXBatchCommand.ExecuteScalar)
            Catch ex As System.Exception
                LastBatchNumber = 65000
            End Try
            con.Close()
        Catch ex As System.Exception
            sendErrorToDataBase("SteelAdjustmentForm - cmdBatchNumber_Click --Error trying to generate new batch number", "Batch #" + LastBatchNumber.ToString(), ex.ToString())
            MessageBox.Show("Unable to generate new batch number, contact system admin", "Unable to generate new batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
        NextBatchNumber = LastBatchNumber + 1
        cboAdjustmentBatchNumber.Text = NextBatchNumber
        cmdGenerateAdjustmentNumber_Click(sender, e)
        isloaded = False
        LoadBatchNumber()
        cboAdjustmentBatchNumber.Text = NextBatchNumber
        isloaded = True
        LoadBatchStatus()
        Dim lastBatch As String = cboAdjustmentBatchNumber.Text
    End Sub

    Private Sub cboAdjustmentBatchNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdjustmentBatchNumber.SelectedIndexChanged
        Dim lastBatch As String = ""
        If isloaded Then
            If Not String.IsNullOrEmpty(lastBatch) Then
                unlockBatch()
            End If
            Dim batch As String = cboAdjustmentBatchNumber.Text
            isloaded = False
            ClearData()
            cboAdjustmentBatchNumber.Text = batch
            LoadAdjustmentNumber()
            LoadAdjustmentBatchTotals()
            LoadBatchStatus()
            ShowData()
            isloaded = True
            lastBatch = cboAdjustmentBatchNumber.Text
        End If
    End Sub

    Private Sub cmdClearBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearBatch.Click, ClearFormToolStripMenuItem.Click
        unlockBatch()
        isloaded = False
        ClearData()
        isloaded = True
    End Sub

    Private Sub updateOrInsertIntoSteelAdjustmentTable(Optional ByVal status As String = "OPEN", Optional ByVal adjTotal As Double = 0)
        Dim cmd As New SqlCommand("IF EXISTS(SELECT SteelAdjustmentKey FROM SteelAdjustmentTable WHERE SteelAdjustmentKey = @SteelAdjustmentKey) UPDATE SteelAdjustmentTable SET RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @SteelCarbon AND SteelSize = @SteelSize), AdjustmentDate = @AdjustmentDate, AdjustmentWeight = @AdjustmentWeight, Comment = @Comment, SteelCarbon = @SteelCarbon, SteelSize = @SteelSize, AdjustmentCost = @AdjustmentCost, AdjustmentTotal = @AdjustmentTotal, Status = @Status, DivisionID = @DivisionID, BatchNumber = @BatchNumber, Locked = @Locked, UserID = @Locked, ChangeRMID = @ChangeRMID, ChangeCoilID = @ChangeCoilID WHERE SteelAdjustmentKey = @SteelAdjustmentKey ELSE Insert Into SteelAdjustmentTable(SteelAdjustmentKey, RMID, SteelCarbon, SteelSize, AdjustmentDate, AdjustmentWeight, AdjustmentCost, Comment, DivisionID, BatchNumber, AdjustmentTotal, Status, Locked, UserID) Values (@SteelAdjustmentKey, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @SteelCarbon AND SteelSize = @SteelSize), @SteelCarbon, @SteelSize, @AdjustmentDate, @AdjustmentWeight, @AdjustmentCost, @Comment, @DivisionID, @BatchNumber, @AdjustmentTotal, @Status, @Locked, @Locked);", con)

        With cmd.Parameters
            .Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = cboAdjustmentNumber.Text
            .Add("@AdjustmentDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
            .Add("@AdjustmentWeight", SqlDbType.VarChar).Value = Val(txtAdjustmentWeight.Text)
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@SteelCarbon", SqlDbType.VarChar).Value = cboAdjustCarbon.Text
            .Add("@SteelSize", SqlDbType.VarChar).Value = cboAdjustSteelSize.Text
            .Add("@AdjustmentCost", SqlDbType.VarChar).Value = Val(txtAdjustmentCost.Text)
            .Add("@AdjustmentTotal", SqlDbType.VarChar).Value = Math.Round(Val(txtAdjustmentTotal.Text.Replace("$", "").Replace(",", "")), 2)
            .Add("@Status", SqlDbType.VarChar).Value = status
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
            .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@ChangeRMID", SqlDbType.VarChar).Value = ""
            .Add("@ChangeCoilID", SqlDbType.VarChar).Value = ""
        End With

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If

        'Write error to eroor log
        Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @DivisionID);", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
        End With

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdDeleteAdjustment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteAdjustment.Click
        If canDeleteAdjustment() Then
            LockBatch()
            Dim reader As SqlDataReader = Nothing

            Try
                'Check if RMID was changed on a coil and revert
                Dim CheckAjustmentChangeRMID As String = ""
                Dim CheckAjustmentChangeCoil As String = ""

                Dim CheckAjustmentChangeRMIDStatement As String = "SELECT ChangeRMID FROM SteelAdjustmentTable WHERE SteelAdjustmentKey = @SteelAdjustmentKey"
                Dim CheckAjustmentChangeRMIDCommand As New SqlCommand(CheckAjustmentChangeRMIDStatement, con)
                CheckAjustmentChangeRMIDCommand.Parameters.Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)

                Dim CheckAjustmentChangeCoilIDStatement As String = "SELECT ChangeCoilID FROM SteelAdjustmentTable WHERE SteelAdjustmentKey = @SteelAdjustmentKey"
                Dim CheckAjustmentChangeCoilIDCommand As New SqlCommand(CheckAjustmentChangeCoilIDStatement, con)
                CheckAjustmentChangeCoilIDCommand.Parameters.Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckAjustmentChangeRMID = CStr(CheckAjustmentChangeRMIDCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckAjustmentChangeRMID = ""
                End Try
                Try
                    CheckAjustmentChangeCoil = CStr(CheckAjustmentChangeCoilIDCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckAjustmentChangeCoil = ""
                End Try
                con.Close()

                If CheckAjustmentChangeCoil = "" And CheckAjustmentChangeRMID = "" Then
                    'Skip
                Else
                    'Get Carbon and steel size from RMID
                    Dim GetCarbon As String = ""
                    Dim GetSteelSize As String = ""

                    Dim GetCarbonStatement As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID"
                    Dim GetCarbonCommand As New SqlCommand(GetCarbonStatement, con)
                    GetCarbonCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CheckAjustmentChangeRMID

                    Dim GetSteelSizeStatement As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID"
                    Dim GetSteelSizeCommand As New SqlCommand(GetSteelSizeStatement, con)
                    GetSteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CheckAjustmentChangeRMID

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetCarbon = CStr(GetCarbonCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetCarbon = ""
                    End Try
                    Try
                        GetSteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetSteelSize = ""
                    End Try
                    con.Close()

                    'Update Coil Table
                    cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Carbon = @Carbon, SteelSize = @SteelSize WHERE CoilID = @CoilID", con)

                    With cmd.Parameters
                        .Add("@CoilID", SqlDbType.VarChar).Value = CheckAjustmentChangeCoil
                        .Add("@Carbon", SqlDbType.VarChar).Value = GetCarbon
                        .Add("@SteelSize", SqlDbType.VarChar).Value = GetSteelSize
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
                '******************************************************************************************************************
                cmd = New SqlCommand("DELETE SteelAdjustmentTable WHERE SteelAdjustmentKey = @SteelAdjustmentKey;", con)
                cmd.CommandText += " SELECT isnull(SUM(AdjustmentWeight),0) as TotalWeight, isnull(SUM(AdjustmentTotal), 0) as TotalCost, isnull(Count(SteelAdjustmentKey), 0) as TotalItems FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber"

                With cmd.Parameters
                    .Add("@SteelAdjustmentKey", SqlDbType.Int).Value = Val(cboDeleteLine.Text)
                    .Add("@BatchNumber", SqlDbType.Int).Value = Val(cboAdjustmentBatchNumber.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    If reader.Read() Then
                        txtTotalWeight.Text = reader.Item("TotalWeight").ToString
                        txtTotalCost.Text = FormatNumber(reader.Item("TotalCost"), 2)
                        txtTotalItems.Text = reader.Item("TotalItems").ToString
                    Else
                        txtTotalWeight.Text = "0"
                        txtTotalCost.Text = "$0.00"
                        txtTotalItems.Text = "0"
                    End If
                Else
                    txtTotalWeight.Text = "0"
                    txtTotalCost.Text = "$0.00"
                    txtTotalItems.Text = "0"
                End If
                reader.Close()
                con.Close()
            Catch ex As System.Exception
                If reader IsNot Nothing Then reader.Close()
                If con.State = ConnectionState.Open Then con.Close()
                sendErrorToDataBase("SteelAdjustmentForm - cmdDeleteAdjustment_Click --Error trying to delete adjustment line", "Adjustment #" + cboDeleteLine.Text, ex.ToString())
                MessageBox.Show("There was an error trying to delete selected adjustment. Contact system admin", "Unable to delete adjustment", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            isloaded = False
            ShowData()
            LoadAdjustmentNumber()
            isloaded = True
            MessageBox.Show("Adjustment has been deleted sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canDeleteAdjustment() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentBatchNumber.Text) Then
            MessageBox.Show("You must select a batch number", "Select a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentBatchNumber.Focus()
            Return False
        End If
        If cboAdjustmentBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentBatchNumber.SelectAll()
            cboAdjustmentBatchNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        If dgvSteelAdjustmentLines.Rows.Count = 0 Then
            MessageBox.Show("There are no adjustments attached to the batch", "No adjustments", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboDeleteLine.Text) Then
            MessageBox.Show("You must select an adjustment to delete", "Select an adjustment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteLine.Focus()
            Return False
        End If
        If cboDeleteLine.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid adjustment number", "Enter a valid adjustment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteLine.SelectAll()
            cboDeleteLine.Focus()
            Return False
        End If
        Dim cmd As New SqlCommand("SELECT Status FROM SteelAdjustmentTable WHERE SteelAdjustmentKey = @SteelAdjustmentKey AND BatchNumber = @BatchNumber;", con)
        cmd.Parameters.Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
        Dim stat As String = "CLOSED"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            stat = cmd.ExecuteScalar()
        Catch ex As System.Exception

        End Try
        con.Close()

        If stat.Equals("CLOSED") Then
            MessageBox.Show("Line is CLOSED and can't be deleted.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub txtAdjustmentCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdjustmentCost.TextChanged
        If isloaded And txtAdjustmentCost.ReadOnly = False Then
            updateAdjustmentTotal()
        End If
    End Sub

    Private Sub cboAdjustCarbon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdjustCarbon.SelectedIndexChanged
        If isloaded Then
            LoadSteelSize()
            If String.IsNullOrEmpty(cboAdjustSteelSize.Text) = False Then
                LoadSteelCost()
                loadQOH()
            End If
        End If
    End Sub

    Private Sub cboAdjustSteelSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdjustSteelSize.SelectedIndexChanged
        If isloaded Then
            If String.IsNullOrEmpty(cboAdjustCarbon.Text) = False Then
                LoadSteelCost()
                loadQOH()
            End If
        End If
    End Sub

    Private Sub LoadSteelCost()
        Dim cmd As New SqlCommand("SELECT isnull(SteelCostPerPound, 0) FROM SteelCostingTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND (SELECT isnull(case when SUM(UsageWeight)=0 then 1 else SUM(UsageWeight) END, 1) FROM SteelUsageTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND Status = 'POSTED' AND UsageDate <= @PostingDate) BETWEEN LowerLimit AND UpperLimit AND CostingDate <= @PostingDate;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboAdjustCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboAdjustSteelSize.Text
        cmd.Parameters.Add("@PostingDate", SqlDbType.Date).Value = dtpAdjustmentDate.Value

        Dim cost As Double = 0.0

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cost = cmd.ExecuteScalar()
        Catch ex As System.Exception
        End Try

        If cost = 0 Then
            Dim cmd1 As New SqlCommand("SELECT isnull(SteelCostPerPound, 0) FROM SteelCostingTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND (SELECT isnull(case when SUM(UsageWeight)=0 then 1 else SUM(UsageWeight) END, 1) FROM SteelUsageTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) AND Status = 'POSTED') BETWEEN LowerLimit AND UpperLimit;", con)
            cmd1.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboAdjustCarbon.Text
            cmd1.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboAdjustSteelSize.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                cost = cmd1.ExecuteScalar()
            Catch ex As System.Exception
            End Try

            If cost = 0 Then
                Dim cmd2 As New SqlCommand("SELECT (SteelExtendedCost / isnull(ReceiveWeight, 1)) FROM SteelReceivingLineTable  WHERE SteelReceivingHeaderKey = (SELECT MAX(SteelReceivingHeaderKey) FROM SteelReceivingLineTable  WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize));", con)
                cmd2.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboAdjustCarbon.Text
                cmd2.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboAdjustSteelSize.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    cost = cmd2.ExecuteScalar()
                Catch ex As System.Exception
                    sendErrorToDataBase("SteelAdjustmentForm - LoadSteelCost --Error trying to get the cost of the currently selected Carbon/Steel Size", " Carbon - " + cboAdjustCarbon.Text + " Size - " + cboAdjustSteelSize.Text, ex.ToString())
                End Try
            End If

        End If
        con.Close()
        txtAdjustmentCost.Text = Math.Round(cost, 4, MidpointRounding.AwayFromZero)
    End Sub

    Private Sub adjustCostTiersAndTransaction()
        ShowData()
        For i As Integer = 0 To dgvSteelAdjustmentLines.Rows.Count - 1
            If dgvSteelAdjustmentLines.Rows(i).Cells("StatusColumn").Value.ToString().Equals("OPEN") Then
                If dgvSteelAdjustmentLines.Rows(i).Cells("AdjustmentWeightColumn").Value < 0 Then
                    ''lowers cost tier
                    addCostTier(i, False)
                Else
                    ''raises cost tier
                    addCostTier(i)
                End If
                addTransactionEntry(i)
            End If
        Next
    End Sub

    Private Sub addTransactionEntry(ByVal i As Integer)
        Dim cmd As New SqlCommand("INSERT INTO SteelTransactionTable (TransactionNumber, DivisionID, RMID, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, TransactionMath, TransactionType, SteelTransactionDate) VALUES((SELECT isnull(MAX(TransactionNumber) + 1, 7700001) FROM SteelTransactionTable), @DivisionID, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @Carbon, @SteelSize, @Quantity, @SteelCostPerPound, @ExtendedCost, @SteelReferenceNumber, @SteelReferenceLineNumber, @TransactionMath, @TransactionType, @SteelTransactionDate);", con)

        With cmd.Parameters
            .Add("@Carbon", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("SteelCarbonColumn").Value
            .Add("@SteelSize", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("SteelSizeColumn").Value
            .Add("@SteelTransactionDate", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("AdjustmentDateColumn").Value
            .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("AdjustmentCostColumn").Value
            .Add("@SteelReferenceNumber", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("SteelAdjustmentKeyColumn").Value
            .Add("@SteelReferenceLineNumber", SqlDbType.VarChar).Value = i + 1
            .Add("@Quantity", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("AdjustmentWeightColumn").Value
            .Add("@ExtendedCost", SqlDbType.Float).Value = dgvSteelAdjustmentLines.Rows(i).Cells("AdjustmentTotalColumn").Value
            .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
            .Add("@TransactionType", SqlDbType.VarChar).Value = "STEEL ADJUSTMENT"
        End With

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub addCostTier(ByVal i As Integer, Optional ByVal notNegAdj As Boolean = True)
        Dim NewUpperLimit, LowerLimit, UpperLimit As Double

        Dim UpperLimitCommand As New SqlCommand("SELECT UpperLimit FROM SteelCostingTable WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID);", con)
        UpperLimitCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("RMIDColumn").Value

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
        Catch ex As System.Exception
            UpperLimit = 0
        End Try
        con.Close()

        'Calculate the NEW Lower/Upper Limit for the next post
        If notNegAdj Then
            LowerLimit = UpperLimit + 1
            NewUpperLimit = LowerLimit + dgvSteelAdjustmentLines.Rows(i).Cells("AdjustmentWeightColumn").Value - 1
        Else
            LowerLimit = UpperLimit

            NewUpperLimit = LowerLimit + dgvSteelAdjustmentLines.Rows(i).Cells("AdjustmentWeightColumn").Value
        End If

        Try
            Dim cmd As New SqlCommand("Insert Into SteelCostingTable (RMID, Carbon, SteelSize, CostingDate, SteelCostPerPound, CostingQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@RMID, @Carbon, @SteelSize, @CostingDate, @SteelCostPerPound, @CostingQuantity, @Status, @LowerLimit, @UpperLimit, (SELECT isnull(MAX(TransactionNumber) + 1, 73700001) FROM SteelCostingTable), @ReferenceNumber, @ReferenceLine);", con)

            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("RMIDColumn").Value
                .Add("@Carbon", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("SteelCarbonColumn").Value
                .Add("@SteelSize", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("SteelSizeColumn").Value
                .Add("@CostingDate", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("AdjustmentDateColumn").Value
                .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("AdjustmentCostColumn").Value
                .Add("@CostingQuantity", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("AdjustmentWeightColumn").Value
                .Add("@Status", SqlDbType.VarChar).Value = "STEEL ADJUSTMENT"
                .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = dgvSteelAdjustmentLines.Rows(i).Cells("SteelAdjustmentKeyColumn").Value
                .Add("@ReferenceLine", SqlDbType.VarChar).Value = i + 1
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            sendErrorToDataBase("SteelCoilReceiving - addCostTiers --Error trying to insert RMID " + dgvSteelAdjustmentLines.Rows(i).Cells("RMIDColumn").Value.ToString() + " into SteelCostingTable", "Adjustment #" + dgvSteelAdjustmentLines.Rows(i).Cells("SteelAdjustmentKeyColumn").Value.ToString(), ex.ToString())
            MessageBox.Show("There was an issue with updating cost tiers. Contact system admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Function checkValidSteel() As Boolean
        Dim cmd As New SqlCommand("SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboAdjustCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboAdjustSteelSize.Text
        Dim cnt As Integer = 0

        If con.State = ConnectionState.Closed Then con.Open()
        cnt = cmd.ExecuteScalar()
        con.Close()

        If cnt > 0 Then
            Return False
        End If
        Return True
    End Function

    Private Function isSomeoneEditing() As Boolean
        Dim cmd As New SqlCommand("SELECT Locked FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        Dim personEditing As String = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.GetValue(0)) Then
                personEditing = reader.GetValue(0)
            End If
        End If
        reader.Close()
        con.Close()

        If Not personEditing.Equals("NONE") And Not String.IsNullOrEmpty(personEditing) Then
            If Not personEditing.Equals(EmployeeLoginName) Then
                MessageBox.Show(personEditing + " is currently editing this batch. You are unable to make any changes.", "Unable to save/Post", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub LockBatch()
        Dim cmd As New SqlCommand("UPDATE SteelAdjustmentTable SET Locked = @Locked WHERE BatchNumber = @BatchNumber;", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboAdjustmentBatchNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        Dim cmd As New SqlCommand("UPDATE SteelAdjustmentTable SET Locked = '' WHERE BatchNumber = @BatchNumber AND Locked = @Locked;", con)
        If batch.Equals("none") Then
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
        Else
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = batch
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub SteelAdjustmentForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(cboAdjustmentBatchNumber.Text) Then
            unlockBatch()
        End If
    End Sub

    Private Sub UnLockBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockBatchToolStripMenuItem.Click
        If cboAdjustmentBatchNumber.SelectedIndex <> -1 Then
            Dim cmd As New SqlCommand("UPDATE SteelAdjustmentTable SET Locked = '' WHERE BatchNumber = @BatchNumber;", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Private Sub loadQOH()
        ''take the selected steelsize and carbon from combo-boxes and load the QOH onto label

        If Not String.IsNullOrEmpty(cboAdjustCarbon.Text) And Not String.IsNullOrEmpty(cboAdjustSteelSize.Text) Then ''this code makes sure that the comboboxes are not empty before loading QOH

            Dim cmd As New SqlCommand("Select isnull(SteelEndingInventory, 0) from SteelInventoryTotals Where Steelsize = @Steelsize and Carbon = @Carbon", con)
            cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboAdjustCarbon.Text
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboAdjustSteelSize.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            con.Close()

            If obj IsNot Nothing Then
                lblQOHLabel.Show()
                lblQOH.Show()
                lblQOH.Text = obj.ToString()
            Else
                lblQOHLabel.Hide()
                lblQOH.Hide()
                lblQOH.Text = ""
            End If

        Else
            lblQOHLabel.Hide()
            lblQOH.Hide()
            lblQOH.Text = ""
        End If
    End Sub

    Private Sub cboAdjustSteelSize_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAdjustSteelSize.KeyPress
        If e.KeyChar.Equals("."c) And (cboAdjustSteelSize.Text.Length = 0 Or cboAdjustSteelSize.SelectionLength = cboAdjustSteelSize.Text.Length) Then
            cboAdjustSteelSize.Text = "0."
            e.KeyChar = Nothing
            cboAdjustSteelSize.SelectionStart = cboAdjustSteelSize.Text.Length
            cboAdjustSteelSize.SelectionLength = 0
        End If
    End Sub

    Private Sub txt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdjustmentWeight.KeyDown, txtAdjustmentCost.KeyDown
        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
            controlKey = True
        ElseIf (e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.OemPeriod) AndAlso (Not CType(sender, System.Windows.Forms.TextBox).Text.Contains(".") Or (CType(sender, System.Windows.Forms.TextBox).Text.Contains(".") AndAlso CType(sender, System.Windows.Forms.TextBox).SelectionLength = CType(sender, System.Windows.Forms.TextBox).Text.Length)) Then
            controlKey = True
        ElseIf (e.KeyCode = Keys.Subtract Or e.KeyCode = Keys.OemMinus) AndAlso (Not CType(sender, System.Windows.Forms.TextBox).Text.Contains("-") Or (CType(sender, System.Windows.Forms.TextBox).Text.Contains("-") AndAlso CType(sender, System.Windows.Forms.TextBox).SelectionLength = CType(sender, System.Windows.Forms.TextBox).Text.Length)) Then
            controlKey = True
        End If
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdjustmentWeight.KeyPress, txtAdjustmentCost.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        Else
            controlKey = False
        End If
    End Sub

    Private Sub txtAdjustmentWeight_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtAdjustmentWeight.PreviewKeyDown
        If e.KeyCode = Keys.OemMinus Or e.KeyCode = Keys.Subtract Then
            If Not txtAdjustmentWeight.Text.Length = 0 AndAlso Not (txtAdjustmentWeight.Text.Length = txtAdjustmentWeight.SelectionLength) AndAlso Not txtAdjustmentWeight.Text.Contains("-") Then
                txtAdjustmentWeight.Text = "-" + txtAdjustmentWeight.Text
                txtAdjustmentWeight.SelectionStart = txtAdjustmentWeight.Text.Length
            End If
        End If
    End Sub

    Private Sub chkChangeCoilSteelType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChangeCoilSteelType.CheckedChanged
        txtCoilID.Clear()

        If chkChangeCoilSteelType.Checked = True Then
            txtCoilID.ReadOnly = False
        Else
            txtCoilID.ReadOnly = True
        End If
    End Sub

    Private Sub txtCoilID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoilID.TextChanged
        'Load RMID on Coil ID text change
        Dim GetCoilSteelSize, GetCoilSteelType, GetCoilRMID As String

        'Get RMID from the Coil Carbon/Steel Size
        Dim GetCoilSteelSizeStatement As String = "SELECT SteelSize FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID"
        Dim GetCoilSteelSizeCommand As New SqlCommand(GetCoilSteelSizeStatement, con)
        GetCoilSteelSizeCommand.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text

        Dim GetCoilSteelTypeStatement As String = "SELECT Carbon FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID"
        Dim GetCoilSteelTypeCommand As New SqlCommand(GetCoilSteelTypeStatement, con)
        GetCoilSteelTypeCommand.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = txtCoilID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetCoilSteelSize = CStr(GetCoilSteelSizeCommand.ExecuteScalar)
        Catch ex As Exception
            GetCoilSteelSize = ""
        End Try
        Try
            GetCoilSteelType = CStr(GetCoilSteelTypeCommand.ExecuteScalar)
        Catch ex As Exception
            GetCoilSteelType = ""
        End Try
        con.Close()

        Dim GetCoilRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim GetCoilRMIDCommand As New SqlCommand(GetCoilRMIDStatement, con)
        GetCoilRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = GetCoilSteelType
        GetCoilRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = GetCoilSteelSize

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetCoilRMID = CStr(GetCoilRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            GetCoilRMID = ""
        End Try
        con.Close()

        lblOldSteelType.Text = GetCoilRMID
    End Sub

    Private Sub SteelAdjustmentForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        usefulFunctions.LoadSecurity(Me)
        If txtAdjustmentCost.Enabled Then txtAdjustmentCost.TabStop = True
        'Load Defaults
        LoadBatchNumber()
        LoadCarbon()
        ClearData()
        isloaded = True
    End Sub
End Class