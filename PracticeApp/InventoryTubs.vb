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
Public Class InventoryTubs
    Inherits System.Windows.Forms.Form

    Dim FormLastFoxStep As Integer = 0

    'Labor cost per piece is calculated as Total Extended Cost from time slip table divided total number of pieces (.0457)

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub InventoryTubs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdAdd

        ShowData()

        If EmployeeSecurityCode = 1001 Then
            gpxAdminControl.Enabled = True
        End If

        'Clear Text Fields
        ClearData()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM TFPInventoryTubs WHERE InventoryStatus <> 'CLOSED' ORDER BY InventoryKey DESC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "TFPInventoryTubs")
        dgvInventoryTubs.DataSource = ds.Tables("TFPInventoryTubs")
        con.Close()
    End Sub

    Public Sub ShowFoxSteps()
        cmd = New SqlCommand("SELECT * FROM FOXSched WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = lblFOXNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "FOXSched")
        dgvFoxProcesses.DataSource = ds1.Tables("FOXSched")
        con.Close()
    End Sub

    Public Sub GetLotNumberData()
        Dim PartNumber As String = ""
        Dim FOXNumber As Integer = 0
        Dim LastFoxStep As Integer = 0

        Dim GetPartNumberString As String = "SELECT PartNumber FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetPartNumberCommand As New SqlCommand(GetPartNumberString, con)
        GetPartNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = lblLotNumber.Text

        Dim GetFOXNumberString As String = "SELECT FOXNumber FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetFOXNumberCommand As New SqlCommand(GetFOXNumberString, con)
        GetFOXNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = lblLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber = CStr(GetPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            PartNumber = ""
        End Try
        Try
            FOXNumber = CInt(GetFOXNumberCommand.ExecuteScalar)
        Catch ex As Exception
            FOXNumber = 0
        End Try
        con.Close()

        Dim GetFOXStepString As String = "SELECT MAX(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessADDFG = 'ADDINVENTORY'"
        Dim GetFOXStepCommand As New SqlCommand(GetFOXStepString, con)
        GetFOXStepCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastFoxStep = CInt(GetFOXStepCommand.ExecuteScalar)
        Catch ex As Exception
            LastFoxStep = 0
        End Try
        con.Close()

        FormLastFoxStep = LastFoxStep
        lblFOXNumber.Text = FOXNumber
        lblPartNumber.Text = PartNumber
    End Sub

    Public Sub ClearData()
        txtScanLotNumber.Clear()
        txtTubNumber.Clear()

        dtpInventoryDate.Text = ""

        lblFOXNumber.Text = ""
        lblPartNumber.Text = ""
        lblLotNumber.Text = ""

        txtScanLotNumber.Focus()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If lblLotNumber.Text <> "" And lblFOXNumber.Text <> "" And lblPartNumber.Text <> "" Then
            'Continue
        Else
            MsgBox("One or more fields are missing. Re-scan Lot #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Load FOX Processes
        ShowFoxSteps()

        'Get Lot Division
        Dim LotDivision As String = ""

        Dim LotDivisionString As String = "SELECT DivisionID FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim LotDivisionCommand As New SqlCommand(LotDivisionString, con)
        LotDivisionCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = lblLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LotDivision = CStr(LotDivisionCommand.ExecuteScalar)
        Catch ex As Exception
            LotDivision = ""
        End Try
        con.Close()

        'Get Inventory Key
        Dim MaxInventoryKey As Integer = 0
        Dim NextInventoryKey As Integer = 0
        Dim InventoryStatus As String = ""
        Dim LastLineNumber, NextLineNumber As Integer

        Dim MAXInventoryKeyString As String = "SELECT MAX(InventoryKey) FROM TFPInventoryTubs"
        Dim MAXInventoryKeyCommand As New SqlCommand(MAXInventoryKeyString, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxInventoryKey = CInt(MAXInventoryKeyCommand.ExecuteScalar)
        Catch ex As Exception
            MaxInventoryKey = 0
        End Try
        con.Close()

        NextInventoryKey = MaxInventoryKey + 1

        'Get Next Line Number
        Dim MAXLineNumberString As String = "SELECT MAX(InventoryLineNumber) FROM TFPInventoryTubs WHERE InventoryStatus = 'OPEN'"
        Dim MAXLineNumberCommand As New SqlCommand(MAXLineNumberString, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastLineNumber = CInt(MAXLineNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastLineNumber = 0
        End Try
        con.Close()

        NextLineNumber = LastLineNumber + 1

        Try
            cmd = New SqlCommand("INSERT INTO TFPInventoryTubs (InventoryKey, InventoryLineNumber, LotNumber, FOXNumber, PartNumber, PieceCount, NetWeight, InventoryDate, LastProcess, ScannedDate, MachineLaborCost, TubNumber, InventoryStatus, DivisionID) values (@InventoryKey, @InventoryLineNumber, @LotNumber, @FOXNumber, @PartNumber, @PieceCount, @NetWeight, @InventoryDate, @LastProcess, @ScannedDate, @MachineLaborCost, @TubNumber, @InventoryStatus, @DivisionID)", con)

            With cmd.Parameters
                .Add("@InventoryKey", SqlDbType.VarChar).Value = NextInventoryKey
                .Add("@InventoryLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                .Add("@LotNumber", SqlDbType.VarChar).Value = lblLotNumber.Text
                .Add("@FOXNumber", SqlDbType.VarChar).Value = lblFOXNumber.Text
                .Add("@PartNumber", SqlDbType.VarChar).Value = lblPartNumber.Text
                .Add("@PieceCount", SqlDbType.VarChar).Value = 0
                .Add("@NetWeight", SqlDbType.VarChar).Value = 0
                .Add("@InventoryDate", SqlDbType.VarChar).Value = dtpInventoryDate.Text
                .Add("@LastProcess", SqlDbType.VarChar).Value = FormLastFoxStep
                .Add("@ScannedDate", SqlDbType.VarChar).Value = Now()
                .Add("@MachineLaborCost", SqlDbType.VarChar).Value = 0
                .Add("@TubNumber", SqlDbType.VarChar).Value = txtTubNumber.Text
                .Add("@InventoryStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@DivisionID", SqlDbType.VarChar).Value = LotDivision
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Get Fox Processes and add to child table
            Dim ProcessStep As Integer = 0
            Dim ProcessID As String = ""
            Dim AddToFG As String = ""

            For Each LineRow As DataGridViewRow In dgvFoxProcesses.Rows
                Try
                    ProcessStep = LineRow.Cells("ProcessStepColumnFP").Value
                Catch ex As System.Exception
                    ProcessStep = 1
                End Try
                Try
                    ProcessID = LineRow.Cells("ProcessIDColumnFP").Value
                Catch ex As System.Exception
                    ProcessID = ""
                End Try
                Try
                    AddToFG = LineRow.Cells("ProcessAddFGColumnFP").Value
                Catch ex As System.Exception
                    AddToFG = ""
                End Try

                Dim MachineCost As Double = 0
                Dim MachineDescription As String = ""
                Dim LotRMID As String = ""

                Dim MachineDescriptionString As String = "SELECT Description FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
                Dim MachineDescriptionCommand As New SqlCommand(MachineDescriptionString, con)
                MachineDescriptionCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = ProcessID
                MachineDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                Dim MachineCostString As String = "SELECT MachineCostPerHour FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
                Dim MachineCostCommand As New SqlCommand(MachineCostString, con)
                MachineCostCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = ProcessID
                MachineCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MachineDescription = CStr(MachineDescriptionCommand.ExecuteScalar)
                Catch ex As Exception
                    MachineDescription = ""
                End Try
                Try
                    MachineCost = CDbl(MachineCostCommand.ExecuteScalar)
                Catch ex As Exception
                    MachineCost = 0
                End Try
                con.Close()

                'Get Steel From Lot
                Dim LotRMIDString As String = "SELECT RMID FROM LotNumber WHERE LotNumber = @LotNumber AND DivisionID = @DivisionID"
                Dim LotRMIDCommand As New SqlCommand(LotRMIDString, con)
                LotRMIDCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = lblLotNumber.Text
                LotRMIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = LotDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LotRMID = CStr(LotRMIDCommand.ExecuteScalar)
                Catch ex As Exception
                    LotRMID = ""
                End Try
                con.Close()

                'Insert into child table
                cmd = New SqlCommand("INSERT INTO TFPInventoryFOXProcesses (InventoryKey, FOXNumber, ProcessStep, ProcessID, ProcessDescription, ProcessAddFG, InventoryDate, MachineCost, RMID) values (@InventoryKey, @FOXNumber, @ProcessStep, @ProcessID, @ProcessDescription, @ProcessAddFG, @InventoryDate, @MachineCost, @RMID)", con)

                With cmd.Parameters
                    .Add("@InventoryKey", SqlDbType.VarChar).Value = NextInventoryKey
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = lblFOXNumber.Text
                    .Add("@ProcessStep", SqlDbType.VarChar).Value = ProcessStep
                    .Add("@ProcessID", SqlDbType.VarChar).Value = ProcessID
                    .Add("@ProcessDescription", SqlDbType.VarChar).Value = MachineDescription
                    .Add("@ProcessAddFG", SqlDbType.VarChar).Value = AddToFG
                    .Add("@InventoryDate", SqlDbType.VarChar).Value = dtpInventoryDate.Text
                    .Add("@MachineCost", SqlDbType.VarChar).Value = MachineCost
                    .Add("@RMID", SqlDbType.VarChar).Value = LotRMID
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next

            ClearData()
            dgvFoxProcesses.DataSource = Nothing
            ShowData()
            txtScanLotNumber.Focus()
        Catch ex As Exception
            MsgBox("Entry failed.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub

    Private Sub cmdDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSelected.Click
        Dim RowInventoryNumber As Integer = 0
        Dim RowLineNumber As Integer = 0

        If Me.dgvInventoryTubs.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvInventoryTubs.CurrentCell.RowIndex

            RowInventoryNumber = Me.dgvInventoryTubs.Rows(RowIndex).Cells("InventoryKeyColumn").Value
            RowLineNumber = Me.dgvInventoryTubs.Rows(RowIndex).Cells("InventoryLineNumberColumn").Value

            Try
                cmd = New SqlCommand("DELETE FROM TFPInventoryTubs WHERE InventoryKey = @InventoryKey AND InventoryLineNumber = @InventoryLineNumber", con)

                With cmd.Parameters
                    .Add("@InventoryKey", SqlDbType.VarChar).Value = RowInventoryNumber
                    .Add("@InventoryLineNumber", SqlDbType.VarChar).Value = RowLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                cmd = New SqlCommand("DELETE FROM TFPInventoryFOXProcesses WHERE InventoryKey = @InventoryKey", con)

                With cmd.Parameters
                    .Add("@InventoryKey", SqlDbType.VarChar).Value = RowInventoryNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ClearData()
                ShowData()
                txtScanLotNumber.Focus()
            Catch ex As Exception
                MsgBox("Delete failed.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to close all previous entries", "CLOSE INVENTORY TUBS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Try
                cmd = New SqlCommand("UPDATE TFPInventoryTubs SET InventoryStatus ='CLOSED'", con)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ClearData()
                ShowData()
                txtScanLotNumber.Focus()
            Catch ex As Exception
                MsgBox("Close failed.", MsgBoxStyle.OkOnly)
            End Try
        ElseIf button = DialogResult.No Then
            txtScanLotNumber.Focus()
        End If
    End Sub

    Private Sub cmdReLoadForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReLoadForm.Click
        ShowData()

        'Clear Text Fields
        ClearData()
    End Sub

    Private Sub cmdPrintInventoryTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintInventoryTags.Click
        GlobalInventoryTagPrintMethod = "PRINTALL"

        Using NewPrintInventoryTubTag As New PrintInventoryTubTag
            Dim result = NewPrintInventoryTubTag.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrintSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPrintSelected.Click
        If Me.dgvInventoryTubs.RowCount > 0 Then
            Dim RowInventoryNumber As Integer = 0

            Dim RowIndex As Integer = Me.dgvInventoryTubs.CurrentCell.RowIndex

            RowInventoryNumber = Me.dgvInventoryTubs.Rows(RowIndex).Cells("InventoryKeyColumn").Value

            GlobalInventoryTagID = RowInventoryNumber
            GlobalInventoryTagPrintMethod = "PRINTSINGLE"

            Using NewPrintInventoryTubTag As New PrintInventoryTubTag
                Dim result = NewPrintInventoryTubTag.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdPrintSelected1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintSelected.Click
        For Each LineRow As DataGridViewRow In dgvInventoryTubs.SelectedRows
            Dim RowInventoryKey As Integer = 0

            Try
                RowInventoryKey = LineRow.Cells("InventoryKeyColumn").Value
            Catch ex As System.Exception
                RowInventoryKey = 0
            End Try

            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM TFPInventoryTubQuery WHERE InventoryKey = @InventoryKey", con)
            cmd.Parameters.Add("@InventoryKey", SqlDbType.VarChar).Value = RowInventoryKey

            cmd1 = New SqlCommand("SELECT * FROM TFPInventoryFOXProcesses WHERE InventoryKey = @InventoryKey", con)
            cmd1.Parameters.Add("@InventoryKey", SqlDbType.VarChar).Value = RowInventoryKey

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "TFPInventoryTubQuery")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "TFPInventoryFOXProcesses")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXInventoryTubTag1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)
            con.Close()

            RowInventoryKey = 0
        Next
    End Sub

    Private Sub ViewPrintSelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewPrintSelectedToolStripMenuItem.Click
        cmdPrintSelected_Click(sender, e)
    End Sub

    Private Sub ViewPrintAllTagsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewPrintAllTagsToolStripMenuItem.Click
        cmdPrintInventoryTags_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtScanLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanLotNumber.TextChanged
        If txtScanLotNumber.Text.Length > 0 Then
            Select Case txtScanLotNumber.Text.Substring(0, 1).ToUpper
                Case "S"
                    If txtScanLotNumber.Text.Length = 1 Then
                        txtScanLotNumber.Text = ""
                    Else
                        lblLotNumber.Text = txtScanLotNumber.Text.Substring(1)
                    End If

                Case Else
                    lblLotNumber.Text = txtScanLotNumber.Text
            End Select
        End If

        GetLotNumberData()
    End Sub

    Private Sub dgvInventoryTubs_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryTubs.CellValueChanged
        If Me.dgvInventoryTubs.RowCount > 0 Then

            Dim RowInventoryNumber As Integer = 0
            Dim RowInventoryLineNumber As Integer = 0
            Dim RowPieceCount As Double = 0
            Dim RowNetWeight As Double = 0
            Dim RowTubNumber As String = ""
            Dim RowLastProcess As Integer = 0

            Dim RowIndex As Integer = Me.dgvInventoryTubs.CurrentCell.RowIndex

            RowInventoryNumber = Me.dgvInventoryTubs.Rows(RowIndex).Cells("InventoryKeyColumn").Value
            RowInventoryLineNumber = Me.dgvInventoryTubs.Rows(RowIndex).Cells("InventoryLineNumberColumn").Value
            RowPieceCount = Me.dgvInventoryTubs.Rows(RowIndex).Cells("PieceCountColumn").Value
            RowNetWeight = Me.dgvInventoryTubs.Rows(RowIndex).Cells("NetWeightColumn").Value
            RowTubNumber = Me.dgvInventoryTubs.Rows(RowIndex).Cells("TubNumberColumn").Value
            RowLastProcess = Me.dgvInventoryTubs.Rows(RowIndex).Cells("LastProcessColumn").Value

            Try
                cmd = New SqlCommand("UPDATE TFPInventoryTubs SET PieceCount = @PieceCount, NetWeight = @NetWeight, LastProcess = @LastProcess, TubNumber = @TubNumber WHERE InventoryKey = @InventoryKey AND InventoryLineNumber = @InventoryLineNumber", con)

                With cmd.Parameters
                    .Add("@InventoryKey", SqlDbType.VarChar).Value = RowInventoryNumber
                    .Add("@InventoryLineNumber", SqlDbType.VarChar).Value = RowInventoryLineNumber
                    .Add("@PieceCount", SqlDbType.VarChar).Value = RowPieceCount
                    .Add("@NetWeight", SqlDbType.VarChar).Value = RowNetWeight
                    .Add("@LastProcess", SqlDbType.VarChar).Value = RowLastProcess
                    .Add("@TubNumber", SqlDbType.VarChar).Value = RowTubNumber
                    .Add("@InventoryStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdViewPrintList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPrintList.Click
        Using NewPrintInventoryTubList As New PrintInventoryTubList
            Dim result = NewPrintInventoryTubList.ShowDialog
        End Using
    End Sub

    Private Sub cmdViewPrintSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPrintSummary.Click
        If Me.dgvInventoryTubs.RowCount > 0 Then
            '************************************************************************************
            'Clear Temp Table
            Try
                cmd = New SqlCommand("DELETE FROM TempWIPInventoryTagTable", con)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
            '**************************************************************************************
            For Each LineRow As DataGridViewRow In dgvInventoryTubs.Rows
                Dim TotalSteelCost As Double = 0
                Dim SteelCostPerPound As Double = 0
                Dim MachineCostPerPiece As Double = 0
                Dim TotalMachineCost As Double = 0
                Dim LaborCostPerPiece As Double = 0.0457
                Dim TotalLaborCost As Double = 0
                Dim TotalWIPAmount As Double = 0

                Dim RowInventoryKey As Integer = 0
                Dim RowInventoryLineNumber As Integer = 0
                Dim RowFOXNumber As Integer = 0
                Dim RowWIPQuantity As Double = 0
                Dim RowNetWeight As Double = 0
                Dim RowLastProcess As Integer = 0
                Dim RowRMID As String = ""
                Dim RowPartNumber As String = ""
                Dim RowDivision As String = ""

                Try
                    RowInventoryKey = LineRow.Cells("InventoryKeyColumn").Value
                Catch ex As Exception
                    RowInventoryKey = 0
                End Try
                Try
                    RowInventoryLineNumber = LineRow.Cells("InventoryLineNumberColumn").Value
                Catch ex As Exception
                    RowInventoryLineNumber = 0
                End Try
                Try
                    RowFOXNumber = LineRow.Cells("FOXNumberColumn").Value
                Catch ex As Exception
                    RowFOXNumber = 0
                End Try
                Try
                    RowPartNumber = LineRow.Cells("PartNumberColumn").Value
                Catch ex As System.Exception
                    RowPartNumber = ""
                End Try
                Try
                    RowLastProcess = LineRow.Cells("LastProcessColumn").Value
                Catch ex As Exception
                    RowLastProcess = 0
                End Try
                Try
                    RowWIPQuantity = LineRow.Cells("PieceCountColumn").Value
                Catch ex As Exception
                    RowWIPQuantity = 0
                End Try
                Try
                    RowNetWeight = LineRow.Cells("NetWeightColumn").Value
                Catch ex As Exception
                    RowNetWeight = 0
                End Try
                '**********************************************************************************************
                If RowFOXNumber > 9999 Then
                    RowDivision = "TFP"
                Else
                    RowDivision = "TWD"
                End If
                '**********************************************************************************************
                Dim GetRowRMIDString As String = "SELECT RMID FROM TFPInventoryTubQuery WHERE InventoryKey = @InventoryKey"
                Dim GetRowRMIDCommand As New SqlCommand(GetRowRMIDString, con)
                GetRowRMIDCommand.Parameters.Add("@InventoryKey", SqlDbType.VarChar).Value = RowInventoryKey

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    RowRMID = CStr(GetRowRMIDCommand.ExecuteScalar)
                Catch ex As Exception
                    RowRMID = ""
                End Try
                con.Close()
                '**********************************************************************************************
                'Get Steel Cost Per Pound
                Dim GetMAXSteelTransactionNumber As Integer = 0

                Dim GetMAXSteelTransactionNumberString As String = "SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID AND CostingDate <= @CostingDate"
                Dim GetMAXSteelTransactionNumberCommand As New SqlCommand(GetMAXSteelTransactionNumberString, con)
                GetMAXSteelTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                GetMAXSteelTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpInventoryDate.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMAXSteelTransactionNumber = CInt(GetMAXSteelTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMAXSteelTransactionNumber = 0
                End Try
                con.Close()

                Dim SteelCostPerPoundString As String = "SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND TransactionNumber = @TransactionNumber"
                Dim SteelCostPerPoundCommand As New SqlCommand(SteelCostPerPoundString, con)
                SteelCostPerPoundCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                SteelCostPerPoundCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMAXSteelTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SteelCostPerPound = CDbl(SteelCostPerPoundCommand.ExecuteScalar)
                Catch ex As Exception
                    SteelCostPerPound = 0
                End Try
                con.Close()
                '*************************************************************************************************
                'Get Steel WIP Cost for line item

                TotalSteelCost = SteelCostPerPound * RowNetWeight
                TotalSteelCost = Math.Round(TotalSteelCost, 2)
                '**************************************************************************************************
                'Run Loop for Labor Cost and machine Cost for each step completed

                If RowLastProcess = 0 Then
                    MachineCostPerPiece = 0
                    TotalMachineCost = 0
                    LaborCostPerPiece = 0.0457
                    TotalLaborCost = 0
                ElseIf RowLastProcess = 1 Then
                    'Get MachineID for Step 1
                    Dim GetMachineID As String = ""

                    Dim GetMachineIDString As String = "SELECT ProcessID FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep"
                    Dim GetMachineIDCommand As New SqlCommand(GetMachineIDString, con)
                    GetMachineIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber
                    GetMachineIDCommand.Parameters.Add("@ProcessStep", SqlDbType.VarChar).Value = 1

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMachineID = CStr(GetMachineIDCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMachineID = ""
                    End Try
                    con.Close()

                    'Get Pieces per hour and machine cost per hour
                    Dim MachineCostPerHour As Double = 0
                    Dim MachinePiecesPerHour As Double = 0

                    Dim MachineCostPerHourString As String = "SELECT MachineCostPerHour FROM MachineTable WHERE MachineID = @MachineID"
                    Dim MachineCostPerHourCommand As New SqlCommand(MachineCostPerHourString, con)
                    MachineCostPerHourCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = GetMachineID

                    Dim MachinePiecesPerHourString As String = "SELECT MaxPiecesPerHour FROM MachineTable WHERE MachineID = @MachineID"
                    Dim MachinePiecesPerHourCommand As New SqlCommand(MachinePiecesPerHourString, con)
                    MachinePiecesPerHourCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = GetMachineID

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MachineCostPerHour = CDbl(MachineCostPerHourCommand.ExecuteScalar)
                    Catch ex As Exception
                        MachineCostPerHour = 0
                    End Try
                    Try
                        MachinePiecesPerHour = CDbl(MachinePiecesPerHourCommand.ExecuteScalar)
                    Catch ex As Exception
                        MachinePiecesPerHour = 0
                    End Try
                    con.Close()

                    If MachineCostPerHour = 0 Or MachinePiecesPerHour = 0 Then
                        MachineCostPerPiece = 0
                        TotalMachineCost = 0
                        LaborCostPerPiece = 0.0457
                        TotalLaborCost = 0
                    Else
                        MachineCostPerPiece = MachineCostPerHour / MachinePiecesPerHour
                        TotalMachineCost = MachineCostPerPiece * RowWIPQuantity
                        TotalMachineCost = Math.Round(TotalMachineCost, 2)
                        MachineCostPerPiece = Math.Round(MachineCostPerPiece, 4)
                        LaborCostPerPiece = 0.0457
                        TotalLaborCost = 0.0457 * RowWIPQuantity
                        TotalLaborCost = Math.Round(TotalLaborCost, 2)
                    End If
                Else
                    Dim Counter2 As Integer = RowLastProcess

                    For i As Integer = RowLastProcess To 1 Step -1
                        'Get MachineID for Step
                        Dim GetMachineID As String = ""
                        Dim TempTotalMachineCost As Double = 0
                        Dim TempTotalLaborCost As Double = 0

                        Dim GetMachineIDString As String = "SELECT ProcessID FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep"
                        Dim GetMachineIDCommand As New SqlCommand(GetMachineIDString, con)
                        GetMachineIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber
                        GetMachineIDCommand.Parameters.Add("@ProcessStep", SqlDbType.VarChar).Value = Counter2

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetMachineID = CStr(GetMachineIDCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetMachineID = ""
                        End Try
                        con.Close()

                        'Get Pieces per hour and machine cost per hour
                        Dim MachineCostPerHour As Double = 0
                        Dim MachinePiecesPerHour As Double = 0

                        Dim MachineCostPerHourString As String = "SELECT MachineCostPerHour FROM MachineTable WHERE MachineID = @MachineID"
                        Dim MachineCostPerHourCommand As New SqlCommand(MachineCostPerHourString, con)
                        MachineCostPerHourCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = GetMachineID

                        Dim MachinePiecesPerHourString As String = "SELECT MaxPiecesPerHour FROM MachineTable WHERE MachineID = @MachineID"
                        Dim MachinePiecesPerHourCommand As New SqlCommand(MachinePiecesPerHourString, con)
                        MachinePiecesPerHourCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = GetMachineID

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MachineCostPerHour = CDbl(MachineCostPerHourCommand.ExecuteScalar)
                        Catch ex As Exception
                            MachineCostPerHour = 0
                        End Try
                        Try
                            MachinePiecesPerHour = CDbl(MachinePiecesPerHourCommand.ExecuteScalar)
                        Catch ex As Exception
                            MachinePiecesPerHour = 0
                        End Try
                        con.Close()

                        If MachineCostPerHour = 0 Or MachinePiecesPerHour = 0 Then
                            MachineCostPerPiece = 0
                            TempTotalMachineCost = 0
                            LaborCostPerPiece = 0.0457
                            TempTotalLaborCost = 0
                        Else
                            MachineCostPerPiece = MachineCostPerHour / MachinePiecesPerHour
                            MachineCostPerHour = MachineCostPerPiece * RowWIPQuantity
                            TempTotalMachineCost = Math.Round(TempTotalMachineCost, 2)
                            MachineCostPerPiece = Math.Round(MachineCostPerPiece, 4)
                            LaborCostPerPiece = 0.0457
                            TempTotalLaborCost = 0.0457 * RowWIPQuantity
                            TempTotalLaborCost = Math.Round(TempTotalLaborCost, 2)
                        End If

                        TotalMachineCost = TotalMachineCost + TempTotalMachineCost
                        TotalLaborCost = TotalLaborCost + TempTotalLaborCost

                        Counter2 = Counter2 - 1
                    Next

                    'Calculate Machine cost for all FOX Processes per piece
                    If TotalMachineCost = 0 Or RowWIPQuantity = 0 Then
                        MachineCostPerPiece = 0
                    Else
                        MachineCostPerPiece = TotalMachineCost / RowWIPQuantity
                    End If
                End If

                'Calculate Total WIP Amount Per Line
                TotalWIPAmount = TotalSteelCost + TotalMachineCost + TotalLaborCost

                'Write to Temp Table
                Try
                    cmd = New SqlCommand("INSERT INTO TempWIPInventoryTagTable (WIPInventoryKey, InventoryLineNumber, FOXNumber, PartNumber, RMID, WIPQuantity, WIPWeight, SteelCost, SteelAmount, MachineCost, MachineAmount, LaborCost, LaborAmount, TotalWIPAmount, LastProcessStep, DivisionID, InventoryDate) values (@WIPInventoryKey, @InventoryLineNumber, @FOXNumber, @PartNumber, @RMID, @WIPQuantity, @WIPWeight, @SteelCost, @SteelAmount, @MachineCost, @MachineAmount, @LaborCost, @LaborAmount, @TotalWIPAmount, @LastProcessStep, @DivisionID, @InventoryDate)", con)

                    With cmd.Parameters
                        .Add("@WIPInventoryKey", SqlDbType.VarChar).Value = RowInventoryKey
                        .Add("@InventoryLineNumber", SqlDbType.VarChar).Value = RowInventoryLineNumber
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                        .Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                        .Add("@WIPQuantity", SqlDbType.VarChar).Value = RowWIPQuantity
                        .Add("@WIPWeight", SqlDbType.VarChar).Value = RowNetWeight
                        .Add("@SteelCost", SqlDbType.VarChar).Value = SteelCostPerPound
                        .Add("@SteelAmount", SqlDbType.VarChar).Value = TotalSteelCost
                        .Add("@MachineCost", SqlDbType.VarChar).Value = MachineCostPerPiece
                        .Add("@MachineAmount", SqlDbType.VarChar).Value = TotalMachineCost
                        .Add("@LaborCost", SqlDbType.VarChar).Value = 0.0457
                        .Add("@LaborAmount", SqlDbType.VarChar).Value = TotalLaborCost
                        .Add("@TotalWIPAmount", SqlDbType.VarChar).Value = TotalWIPAmount
                        .Add("@LastProcessStep", SqlDbType.VarChar).Value = RowLastProcess
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                        .Add("@InventoryDate", SqlDbType.VarChar).Value = dtpInventoryDate.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception

                End Try
            Next

            Using NewPrintInventoryWIPReport As New PrintInventoryTubWIPReport
                Dim Result = NewPrintInventoryWIPReport.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdUpdateProcesses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateProcesses.Click
        If Me.dgvInventoryTubs.RowCount > 0 Then

            For Each LineRow As DataGridViewRow In dgvInventoryTubs.Rows

                Dim RowInventoryKey As Integer = 0
                Dim RowFOXNumber As Integer = 0

                Try
                    RowInventoryKey = LineRow.Cells("InventoryKeyColumn").Value
                Catch ex As System.Exception
                    RowInventoryKey = 0
                End Try
                Try
                    RowFOXNumber = LineRow.Cells("FOXNumberColumn").Value
                Catch ex As System.Exception
                    RowFOXNumber = 0
                End Try

                'Get RMID from FOX
                Dim GetRowRMID As String = ""

                Dim GetRowRMIDString As String = "SELECT RMID FROM FOXTable WHERE FOXNumber = @FOXNumber"
                Dim GetRowRMIDCommand As New SqlCommand(GetRowRMIDString, con)
                GetRowRMIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetRowRMID = CStr(GetRowRMIDCommand.ExecuteScalar)
                Catch ex As Exception
                    GetRowRMID = ""
                End Try
                con.Close()

                'Count the Number of Fox Steps
                Dim CountSteps As Integer = 0

                Dim GetStepCountString As String = "SELECT COUNT(FOXNumber) FROM FOXSched WHERE FOXNumber = @FOXNumber"
                Dim GetStepCountCommand As New SqlCommand(GetStepCountString, con)
                GetStepCountCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountSteps = CInt(GetStepCountCommand.ExecuteScalar)
                Catch ex As Exception
                    CountSteps = 0
                End Try
                con.Close()

                Dim Counter As Integer = 1

                'Run Loop to add all FOX Steps to table
                For i As Integer = 1 To CountSteps
                    Dim ProcessID As String = ""
                    Dim ProcessADDFG As String = ""
                    Dim ProcessDescription As String = ""
                    Dim MachineCost As Double = 0
                    Dim IsAddToFG As String = ""

                    'Get Machine Number/ID
                    Dim GetProcessIDString As String = "SELECT ProcessID FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep"
                    Dim GetProcessIDCommand As New SqlCommand(GetProcessIDString, con)
                    GetProcessIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber
                    GetProcessIDCommand.Parameters.Add("@ProcessStep", SqlDbType.VarChar).Value = Counter

                    Dim IsAddToFGString As String = "SELECT ProcessAddFG FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep"
                    Dim IsAddToFGCommand As New SqlCommand(IsAddToFGString, con)
                    IsAddToFGCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber
                    IsAddToFGCommand.Parameters.Add("@ProcessStep", SqlDbType.VarChar).Value = Counter

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProcessID = CStr(GetProcessIDCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProcessID = ""
                    End Try
                    Try
                        IsAddToFG = CStr(IsAddToFGCommand.ExecuteScalar)
                    Catch ex As Exception
                        IsAddToFG = "NO"
                    End Try
                    con.Close()

                    'Get Machine Dtails
                    Dim GetDescriptionString As String = "SELECT Description FROM MachineTable WHERE MachineID = @MachineID"
                    Dim GetDescriptionCommand As New SqlCommand(GetDescriptionString, con)
                    GetDescriptionCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = ProcessID

                    Dim GetMachineCostString As String = "SELECT MachineCostPerHour FROM MachineTable WHERE MachineID = @MachineID"
                    Dim GetMachineCostCommand As New SqlCommand(GetMachineCostString, con)
                    GetMachineCostCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = ProcessID

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ProcessDescription = CStr(GetDescriptionCommand.ExecuteScalar)
                    Catch ex As Exception
                        ProcessDescription = ""
                    End Try
                    Try
                        MachineCost = CDbl(GetMachineCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        MachineCost = 0
                    End Try
                    con.Close()

                    'Write to Child Table
                    Try
                        cmd = New SqlCommand("INSERT INTO TFPInventoryFOXProcesses (InventoryKey, FOXNumber, ProcessStep, ProcessID, ProcessDescription, ProcessADDFG, InventoryDate, MachineCost, RMID) values (@InventoryKey, @FOXNumber, @ProcessStep, @ProcessID, @ProcessDescription, @ProcessADDFG, @InventoryDate, @MachineCost, @RMID)", con)

                        With cmd.Parameters
                            .Add("@InventoryKey", SqlDbType.VarChar).Value = RowInventoryKey
                            .Add("@FOXNumber", SqlDbType.VarChar).Value = RowFOXNumber
                            .Add("@ProcessStep", SqlDbType.VarChar).Value = Counter
                            .Add("@ProcessID", SqlDbType.VarChar).Value = ProcessID
                            .Add("@ProcessDescription", SqlDbType.VarChar).Value = ProcessDescription
                            .Add("@ProcessADDFG", SqlDbType.VarChar).Value = IsAddToFG
                            .Add("@InventoryDate", SqlDbType.VarChar).Value = dtpInventoryDate.Text
                            .Add("@MachineCost", SqlDbType.VarChar).Value = MachineCost
                            .Add("@RMID", SqlDbType.VarChar).Value = GetRowRMID
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try

                    Counter = Counter + 1
                Next i

            Next

            MsgBox("Processes Updated!", MsgBoxStyle.OkOnly)

        End If
    End Sub
End Class