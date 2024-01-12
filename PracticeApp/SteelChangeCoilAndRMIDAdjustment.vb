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
Public Class SteelChangeCoilAndRMIDAdjustment
    Inherits System.Windows.Forms.Form

    Dim LastBatchNumber, NextBatchNumber As Integer
    Dim CheckNewRMID, CheckNewCarbon, CheckNewSteelSize, CheckNewCoilID As String
    Dim CheckNewCoilWeight, CheckNewCoilCost As Double

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub SteelChangeCoilAndRMIDAdjustment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCarbon()
        LoadSteelSize()
        LoadAdjustmentBatchNumber()
        LoadReworkCarbon()
        LoadReworkSteelSize()

        ClearDataInDatagrid()
        ClearCoilList()
        ClearVariables()
        ClearData()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM SteelChangeCoilAndRMID WHERE SteelAdjustmentBatch = @SteelAdjustmentBatch AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelChangeCoilAndRMID")
        dgvChangeCoils.DataSource = ds.Tables("SteelChangeCoilAndRMID")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvChangeCoils.DataSource = Nothing
    End Sub

    Public Sub ShowCharterCoils()
        cmd = New SqlCommand("SELECT * FROM CharterSteelCoilIdentification WHERE Carbon = @Carbon AND SteelSize = @SteelSize AND Status = 'RAW'", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CharterSteelCoilIdentification")
        dgvCoilList.DataSource = ds1.Tables("CharterSteelCoilIdentification")
        con.Close()
    End Sub

    Public Sub ClearCoilList()
        dgvCoilList.DataSource = Nothing
    End Sub

    Public Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable ORDER BY SteelSize", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "RawMaterialsTable")
        cboSteelSize.DataSource = ds2.Tables("RawMaterialsTable")
        con.Close()
        cboSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable ORDER BY Carbon", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "RawMaterialsTable")
        cboCarbon.DataSource = ds3.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadReworkSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT SteelSize FROM RawMaterialsTable ORDER BY SteelSize", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "RawMaterialsTable")
        cboReworkSteelSize.DataSource = ds5.Tables("RawMaterialsTable")
        con.Close()
        cboReworkSteelSize.SelectedIndex = -1
    End Sub

    Public Sub LoadReworkCarbon()
        cmd = New SqlCommand("SELECT DISTINCT Carbon FROM RawMaterialsTable ORDER BY Carbon", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "RawMaterialsTable")
        cboReworkCoilCarbon.DataSource = ds6.Tables("RawMaterialsTable")
        con.Close()
        cboReworkCoilCarbon.SelectedIndex = -1
    End Sub

    Public Sub LoadAdjustmentBatchNumber()
        cmd = New SqlCommand("SELECT DISTINCT SteelAdjustmentBatch FROM SteelChangeCoilAndRMID ORDER BY SteelAdjustmentBatch DESC", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboAdjustmentBatchNumber.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboSteelSize.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "SteelChangeCoilAndRMID")
        cboAdjustmentBatchNumber.DataSource = ds4.Tables("SteelChangeCoilAndRMID")
        con.Close()
    End Sub

    Public Sub ShowAdjustmentDataToPost()
        cmd = New SqlCommand("SELECT * FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "SteelAdjustmentTable")
        dgvSteelAdjustments.DataSource = ds5.Tables("SteelAdjustmentTable")
        con.Close()
    End Sub

    Public Sub ClearAdjustmentDataToPost()
        dgvSteelAdjustments.DataSource = Nothing
    End Sub

    Public Sub ClearData()
        cboAdjustmentBatchNumber.Text = ""

        cboAdjustmentBatchNumber.SelectedIndex = -1
        cboCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        cboReworkCoilCarbon.SelectedIndex = -1
        cboReworkSteelSize.SelectedIndex = -1

        txtBatchStatus.Clear()
        txtComments.Clear()

        chkKeepCoilIDs.Checked = False
        dtpAdjustmentDate.Text = ""

        cmdAddCoils.Enabled = True
        cmdClearChecks.Enabled = True
        cmdClearCoils.Enabled = True
        cmdDelete.Enabled = True
        cmdPost.Enabled = True
        cmdSave.Enabled = True
        cmdRemoveCoils.Enabled = True
        cmdSelectCoils.Enabled = True

        cboAdjustmentBatchNumber.Focus()
    End Sub

    Public Sub ClearVariables()

    End Sub

    Public Sub LoadAdjustmentData()
        Dim BatchStatus As String = ""
        Dim AdjustmentDate As String = ""

        Dim AdjustmentDateStatement As String = "SELECT MIN(AdjustmentDate) FROM SteelChangeCoilAndRMID WHERE SteelAdjustmentBatch = @SteelAdjustmentBatch AND DivisionID = @DivisionID"
        Dim AdjustmentDateCommand As New SqlCommand(AdjustmentDateStatement, con)
        AdjustmentDateCommand.Parameters.Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
        AdjustmentDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        Dim BatchStatusStatement As String = "SELECT MIN(BatchStatus) FROM SteelChangeCoilAndRMID WHERE SteelAdjustmentBatch = @SteelAdjustmentBatch AND DivisionID = @DivisionID"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AdjustmentDate = CStr(AdjustmentDateCommand.ExecuteScalar)
        Catch ex As Exception
            AdjustmentDate = ""
        End Try
        Try
            BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
        Catch ex As Exception
            BatchStatus = ""
        End Try
        con.Close()

        dtpAdjustmentDate.Text = AdjustmentDate
        txtBatchStatus.Text = BatchStatus

        If BatchStatus = "POSTED" Then
            cmdAddCoils.Enabled = False
            cmdClearChecks.Enabled = False
            cmdClearCoils.Enabled = False
            cmdDelete.Enabled = False
            cmdPost.Enabled = False
            cmdSave.Enabled = False
            cmdRemoveCoils.Enabled = False
            cmdSelectCoils.Enabled = False
        Else
            cmdAddCoils.Enabled = True
            cmdClearChecks.Enabled = True
            cmdClearCoils.Enabled = True
            cmdDelete.Enabled = True
            cmdPost.Enabled = True
            cmdSave.Enabled = True
            cmdRemoveCoils.Enabled = True
            cmdSelectCoils.Enabled = True
        End If
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment.Substring(0, 300)
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdBatchNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBatchNumber.Click
        'Clear Form
        ClearVariables()
        ClearData()
        ClearCoilList()
        ClearDataInDatagrid()

        Dim MAXBatchStatement As String = "SELECT MAX(BatchNumber) FROM SteelAdjustmentTable"
        Dim MAXBatchCommand As New SqlCommand(MAXBatchStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(MAXBatchCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 337000000
        End Try
        con.Close()

        txtBatchStatus.Text = "OPEN"
        NextBatchNumber = LastBatchNumber + 1
        cboAdjustmentBatchNumber.Text = NextBatchNumber

        'Get first adjustment number
        Dim LastAdjustmentNumber, NextAdjustmentNumber As Integer

        Dim LastAdjustmentNumberStatement As String = "SELECT MAX(SteelAdjustmentKey) FROM SteelAdjustmentTable"
        Dim LastAdjustmentNumberCommand As New SqlCommand(LastAdjustmentNumberStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastAdjustmentNumber = CInt(LastAdjustmentNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastAdjustmentNumber = 337000000
        End Try
        con.Close()

        NextAdjustmentNumber = LastAdjustmentNumber + 1

        Try
            'Reserve Batch Number
            cmd = New SqlCommand("INSERT INTO SteelAdjustmentTable (SteelAdjustmentKey, BatchNumber, DivisionID, RMID, Locked) Values (@SteelAdjustmentKey, @BatchNumber, @DivisionID, @RMID, @Locked)", con)
            cmd.Parameters.Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = NextAdjustmentNumber
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = "TEMP"
            cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = ""

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub cmdSelectCoils_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectCoils.Click
        ShowCharterCoils()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalSteelAdjustmentNumber = Val(cboAdjustmentBatchNumber.Text)

        Using NewSteelCoilTransfer As New PrintSteelCoilTransfer
            Dim Result = NewSteelCoilTransfer.ShowDialog()
        End Using
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboAdjustmentBatchNumber.Text = "" Or Val(cboAdjustmentBatchNumber.Text) = 0 Then
            MsgBox("You must select a valid batch #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If txtBatchStatus.Text <> "OPEN" Then
            MsgBox("Batch must be open to delete.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            'Delete Batch
            cmd = New SqlCommand("DELETE FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND Status = @Status", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("DELETE FROM SteelChangeCoilAndRMID WHERE SteelAdjustmentBatch = @SteelAdjustmentBatch AND DivisionID = @DivisionID AND BatchStatus = @BatchStatus", con)
            cmd.Parameters.Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Clear Fields
            ClearCoilList()
            ClearData()
            ClearVariables()
            ClearDataInDatagrid()
        Catch ex As Exception
            'Error Log
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboAdjustmentBatchNumber.Text = "" Or Val(cboAdjustmentBatchNumber.Text) = 0 Then
            MsgBox("You must select a valid batch #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If txtBatchStatus.Text <> "OPEN" Then
            MsgBox("Batch must be open to delete.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Save Batch Header Data
        Try
            cmd = New SqlCommand("UPDATE SteelAdjustmentTable SET AdjustmentDate = @AdjustmentDate, Comment = @Comment WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND Status = @Status", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
            cmd.Parameters.Add("@AdjustmentDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmd = New SqlCommand("UPDATE SteelChangeCoilAndRMID SET AdjustmentDate = @AdjustmentDate, Comments = @Comments WHERE SteelAdjustmentBatch = @SteelAdjustmentBatch AND DivisionID = @DivisionID AND BatchStatus = @BatchStatus", con)
            cmd.Parameters.Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
            cmd.Parameters.Add("@AdjustmentDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = txtComments.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowData()
            MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Error Check
        End Try
    End Sub

    Private Sub cmdClearCoils_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearCoils.Click
        cboCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        ClearCoilList()
    End Sub

    Private Sub cmdClearChecks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearChecks.Click
        For Each row As DataGridViewRow In dgvCoilList.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectCoil")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdAddCoils_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddCoils.Click
        'Validate Fields
        If Val(cboAdjustmentBatchNumber.Text) = 0 Then
            MsgBox("You must have a valid batch #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Me.dgvCoilList.RowCount = 0 Then
            MsgBox("You must select coils from list.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '****************************************************************************
        'Verify that steel exists
        Dim CheckRMID As Integer = 0

        Dim CheckRMIDStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
        Dim CheckRMIDCommand As New SqlCommand(CheckRMIDStatement, con)
        CheckRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboReworkCoilCarbon.Text
        CheckRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboReworkSteelSize.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckRMID = CInt(CheckRMIDCommand.ExecuteScalar)
        Catch ex As Exception
            CheckRMID = 0
        End Try
        con.Close()

        If CheckRMID = 0 Then
            MsgBox("Raw Material does not exist in the system.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Skip
        End If
        '****************************************************************************
        Dim RowRMID As String = ""
        Dim GetSteelUnitCost As Double = 0
        Dim RowCoilCost As Double = 0

        'Retrieve line data from PO Table and write to Receipt Of Invoice Table
        For Each row As DataGridViewRow In dgvCoilList.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectCoil")

            If cell.Value = "SELECTED" Then
                Dim RowCoilID As String = row.Cells("CoilIDColumn2").Value
                Dim RowHeatNumber As String = row.Cells("HeatNumberColumn2").Value
                Dim RowWeight As Double = row.Cells("WeightColumn2").Value
                Dim RowCarbon As String = row.Cells("CarbonColumn2").Value
                Dim RowSteelSize As String = row.Cells("SteelSizeColumn2").Value

                'Get RMID
                Dim RowRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
                Dim RowRMIDCommand As New SqlCommand(RowRMIDStatement, con)
                RowRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = RowCarbon
                RowRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = RowSteelSize

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    RowRMID = CStr(RowRMIDCommand.ExecuteScalar)
                Catch ex As Exception
                    RowRMID = ""
                End Try
                con.Close()

                If RowRMID = "" Then
                    MsgBox("Raw material does not exist in database.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*********************************************************************************************
                'Get Coil Cost
                Dim MaxTransactionNumber As Integer = 0

                Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID"
                Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
                MaxTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID
          
                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    MaxTransactionNumber = 0
                End Try
                con.Close()

                Dim GetSteelUnitCostStatement As String = "SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND TransactionNumber = @TransactionNumber"
                Dim GetSteelUnitCostCommand As New SqlCommand(GetSteelUnitCostStatement, con)
                GetSteelUnitCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                GetSteelUnitCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSteelUnitCost = CDbl(GetSteelUnitCostCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSteelUnitCost = 0
                End Try
                con.Close()

                RowCoilCost = RowWeight * GetSteelUnitCost
                RowCoilCost = Math.Round(RowCoilCost, 2)
                '***********************************************************************************************
                'Get Next Adjustment # for batch
                Dim LastAdjustmentNumber, NextAdjustmentNumber As Integer

                Dim LastAdjustmentNumberStatement As String = "SELECT MAX(SteelAdjustmentKey) FROM SteelAdjustmentTable"
                Dim LastAdjustmentNumberCommand As New SqlCommand(LastAdjustmentNumberStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAdjustmentNumber = CInt(LastAdjustmentNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    LastAdjustmentNumber = 337000000
                End Try
                con.Close()

                NextAdjustmentNumber = LastAdjustmentNumber + 1
                '************************************************************************************************
                'Write Line data to new table
                cmd = New SqlCommand("Insert Into SteelAdjustmentTable(SteelAdjustmentKey, BatchNumber, DivisionID, RMID, SteelCarbon, SteelSize, AdjustmentDate, AdjustmentWeight, AdjustmentCost, AdjustmentTotal, Comment, Status, Locked, UserID, ChangeRMID, ChangeCoilID) Values (@SteelAdjustmentKey, @BatchNumber, @DivisionID, @RMID, @SteelCarbon, @SteelSize, @AdjustmentDate, @AdjustmentWeight, @AdjustmentCost, @AdjustmentTotal, @Comment, @Status, @Locked, @UserID, @ChangeRMID, @ChangeCoilID)", con)

                With cmd.Parameters
                    .Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = NextAdjustmentNumber
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    .Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                    .Add("@SteelCarbon", SqlDbType.VarChar).Value = RowCarbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = RowSteelSize
                    .Add("@AdjustmentDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                    .Add("@AdjustmentWeight", SqlDbType.VarChar).Value = RowWeight
                    .Add("@AdjustmentCost", SqlDbType.VarChar).Value = GetSteelUnitCost
                    .Add("@AdjustmentTotal", SqlDbType.VarChar).Value = RowCoilCost
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    '.Add("@PrintDate", SqlDbType.VarChar).Value = ""
                    .Add("@ChangeRMID", SqlDbType.VarChar).Value = ""
                    .Add("@ChangeCoilID", SqlDbType.VarChar).Value = ""
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '************************************************************************************************
                Dim AddCoilID As String = ""

                If chkKeepCoilIDs.Checked = True Then
                    AddCoilID = RowCoilID
                Else
                    AddCoilID = ""
                End If
                '************************************************************************************************
                Dim AddReworkRMID As String = ""

                If cboReworkCoilCarbon.Text <> "" Or cboReworkSteelSize.Text <> "" Then
                    Dim AddReworkRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
                    Dim AddReworkRMIDCommand As New SqlCommand(AddReworkRMIDStatement, con)
                    AddReworkRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboReworkCoilCarbon.Text
                    AddReworkRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboReworkSteelSize.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        AddReworkRMID = CStr(AddReworkRMIDCommand.ExecuteScalar)
                    Catch ex As Exception
                        AddReworkRMID = ""
                    End Try
                    con.Close()
                Else
                    AddReworkRMID = ""
                End If
                '************************************************************************************************
                'Write Line data to new table
                cmd = New SqlCommand("Insert Into SteelChangeCoilAndRMID(SteelAdjustmentBatch, SteelAdjustmentNumber, DivisionID, AdjustmentDate, RMID, Carbon, SteelSize, CoilID, CoilWeight, HeatNumber, CoilCost, ReworkRMID, ReworkCarbon, ReworkSteelSize, ReworkCoilID, ReworkCoilWeight, ReworkHeatNumber, ReworkCoilCost, Username, Comments, BatchStatus, BatchType) Values (@SteelAdjustmentBatch, @SteelAdjustmentNumber, @DivisionID, @AdjustmentDate, @RMID, @Carbon, @SteelSize, @CoilID, @CoilWeight, @HeatNumber, @CoilCost, @ReworkRMID, @ReworkCarbon, @ReworkSteelSize, @ReworkCoilID, @ReworkCoilWeight, @ReworkHeatNumber, @ReworkCoilCost, @Username, @Comments, @BatchStatus, @BatchType)", con)

                With cmd.Parameters
                    .Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@SteelAdjustmentNumber", SqlDbType.VarChar).Value = NextAdjustmentNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    .Add("@AdjustmentDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                    .Add("@RMID", SqlDbType.VarChar).Value = RowRMID
                    .Add("@Carbon", SqlDbType.VarChar).Value = RowCarbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = RowSteelSize
                    .Add("@CoilID", SqlDbType.VarChar).Value = RowCoilID
                    .Add("@CoilWeight", SqlDbType.VarChar).Value = RowWeight
                    .Add("@HeatNumber", SqlDbType.VarChar).Value = ROWHeatNumber
                    .Add("@CoilCost", SqlDbType.VarChar).Value = RowCoilCost
                    .Add("@ReworkRMID", SqlDbType.VarChar).Value = AddReworkRMID
                    .Add("@ReworkCarbon", SqlDbType.VarChar).Value = cboReworkCoilCarbon.Text
                    .Add("@ReworkSteelSize", SqlDbType.VarChar).Value = cboReworkSteelSize.Text
                    .Add("@ReworkCoilID", SqlDbType.VarChar).Value = AddCoilID
                    .Add("@ReworkCoilWeight", SqlDbType.VarChar).Value = RowWeight
                    .Add("@ReworkHeatNumber", SqlDbType.VarChar).Value = ROWHeatNumber
                    .Add("@ReworkCoilCost", SqlDbType.VarChar).Value = RowCoilCost
                    .Add("@Username", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@Comments", SqlDbType.VarChar).Value = txtComments.text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@BatchType", SqlDbType.VarChar).Value = "COIL/RMID"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear Variables after line entry
                NextAdjustmentNumber = 0
                LastAdjustmentNumber = 0
            End If
        Next
        '******************************************************************************************
        'Delete any adjustment rows with no RMID
        cmd = New SqlCommand("DELETE FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber AND RMID = @RMID AND Locked = @Locked", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
        cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = ""
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = "TEMP"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Show lines in datagrid
        ShowData()

        'Clear line in coil table
        cboCarbon.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
        ClearCoilList()
    End Sub

    Private Sub cmdRemoveCoils_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveCoils.Click
        If Me.dgvChangeCoils.RowCount > 0 Then
            Dim RowAdjustmentNumber As Integer
            Dim RowIndex As Integer = Me.dgvChangeCoils.CurrentCell.RowIndex

            RowAdjustmentNumber = Me.dgvChangeCoils.Rows(RowIndex).Cells("SteelAdjustmentNumberColumn").Value

            'Delete from Steel Adjustment Table
            cmd = New SqlCommand("DELETE FROM SteelAdjustmentTable WHERE BatchNumber = @BatchNumber AND SteelAdjustmentKey = @SteelAdjustmentKey AND Status = @Status", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
            cmd.Parameters.Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = RowAdjustmentNumber
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Delete from Steel Change Coil/RMID Table
            cmd = New SqlCommand("DELETE FROM SteelChangeCoilAndRMID WHERE SteelAdjustmentBatch = @SteelAdjustmentBatch AND SteelAdjustmentNumber = @SteelAdjustmentNumber AND BatchStatus = @BatchStatus", con)
            cmd.Parameters.Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
            cmd.Parameters.Add("@SteelAdjustmentNumber", SqlDbType.VarChar).Value = RowAdjustmentNumber
            cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Reload datagrid
            ShowData()
        End If
    End Sub

    Private Sub cmdPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPost.Click
        'Validation
        If cboAdjustmentBatchNumber.Text = "" Or Val(cboAdjustmentBatchNumber.Text) = 0 Then
            MsgBox("You must select a valid batch #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If txtBatchStatus.Text <> "OPEN" Then
            MsgBox("Batch must be open to post.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Me.dgvChangeCoils.RowCount = 0 Then
            MsgBox("There are no lines to post.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '**************************************************************************************************
        'Check rows in datagrid - verify that fields are properly filled out
        Dim CheckNewRMID, CheckNewCarbon, CheckNewSteelSize, CheckNewCoilID As String
        Dim CheckNewCoilWeight As Double
        For Each LineRow As DataGridViewRow In dgvChangeCoils.Rows
            Try
                CheckNewRMID = LineRow.Cells("ReworkRMIDColumn").Value
            Catch ex As System.Exception
                CheckNewRMID = ""
            End Try
            Try
                CheckNewCarbon = LineRow.Cells("ReworkCarbonColumn").Value
            Catch ex As System.Exception
                CheckNewCarbon = ""
            End Try
            Try
                CheckNewSteelSize = LineRow.Cells("ReworkSteelSizeColumn").Value
            Catch ex As System.Exception
                CheckNewSteelSize = ""
            End Try
            Try
                CheckNewCoilID = LineRow.Cells("ReworkCoilIDColumn").Value
            Catch ex As System.Exception
                CheckNewCoilID = ""
            End Try
            Try
                CheckNewCoilWeight = LineRow.Cells("ReworkCoilWeightColumn").Value
            Catch ex As System.Exception
                CheckNewCoilWeight = 0
            End Try

            If CheckNewCarbon = "" Or CheckNewCoilID = "" Or CheckNewCoilWeight = 0 Or CheckNewRMID = "" Or CheckNewSteelSize = "" Then
                MsgBox("One or more fields in the datagrid are missing.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Next
        '****************************************************************************************************
        Try
            'Update existing Inventory adjustments to a negative value
            cmd = New SqlCommand("UPDATE SteelAdjustmentTable SET AdjustmentWeight = (AdjustmentWeight * -1), AdjustmentTotal = (AdjustmentTotal * -1) WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND Status = @Status", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            Dim AdjustmentBatchNumber As Integer
            AdjustmentBatchNumber = Val(cboAdjustmentBatchNumber.Text)
            Dim strBatchNumber As String = ""

            strBatchNumber = CStr(AdjustmentBatchNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = "TWD"
            ErrorDescription = "Failure of update to change adjustment table - Steel Transfer Coils"
            ErrorReferenceNumber = "Batch # " + strBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        Try
            'Update Steel Coil Change Table
            cmd = New SqlCommand("UPDATE SteelChangeCoilAndRMID SET CoilWeight = (CoilWeight * -1), CoilCost = (CoilCost * -1) WHERE SteelAdjustmentBatch = @SteelAdjustmentBatch AND DivisionID = @DivisionID AND BatchStatus = @BatchStatus", con)
            cmd.Parameters.Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            Dim AdjustmentBatchNumber As Integer
            AdjustmentBatchNumber = Val(cboAdjustmentBatchNumber.Text)
            Dim strBatchNumber As String = ""

            strBatchNumber = CStr(AdjustmentBatchNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = "TWD"
            ErrorDescription = "Failure of update to change coil table - Steel Transfer Coils"
            ErrorReferenceNumber = "Batch # " + strBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '*****************************************************************************************************
        'Create second Inventory Adjustment in the same table
        Dim NextRMID, NextCarbon, NextSteelSize, LastRMID, LastCoilID, NextCoilID, NextHeatNumber As String
        Dim NextCoilWeight, NextCoilCost As Double

        For Each Row As DataGridViewRow In dgvChangeCoils.Rows
            Try
                NextRMID = Row.Cells("ReworkRMIDColumn").Value
            Catch ex As System.Exception
                NextRMID = ""
            End Try
            Try
                NextCarbon = Row.Cells("ReworkCarbonColumn").Value
            Catch ex As System.Exception
                NextCarbon = ""
            End Try
            Try
                NextSteelSize = Row.Cells("ReworkSteelSizeColumn").Value
            Catch ex As System.Exception
                NextSteelSize = ""
            End Try
            Try
                LastRMID = Row.Cells("RMIDColumn").Value
            Catch ex As System.Exception
                LastRMID = ""
            End Try
            Try
                LastCoilID = Row.Cells("CoilIDColumn").Value
            Catch ex As System.Exception
                LastCoilID = ""
            End Try
            Try
                NextCoilID = Row.Cells("ReworkCoilIDColumn").Value
            Catch ex As System.Exception
                NextCoilID = ""
            End Try
            Try
                NextCoilWeight = Row.Cells("ReworkCoilWeightColumn").Value
            Catch ex As System.Exception
                NextCoilWeight = 0
            End Try
            Try
                NextCoilCost = Row.Cells("ReworkCoilCostColumn").Value
            Catch ex As System.Exception
                NextCoilCost = 0
            End Try
            Try
                NextHeatNumber = Row.Cells("ReworkHeatNumberColumn").Value
            Catch ex As System.Exception
                NextHeatNumber = ""
            End Try

            Dim GetSteelUnitCost As Double = 0

            GetSteelUnitCost = NextCoilCost / NextCoilWeight
            GetSteelUnitCost = Math.Round(GetSteelUnitCost, 4)
            '***********************************************************************************************
            'Get Next Adjustment # for batch
            Dim LastAdjustmentNumber, NextAdjustmentNumber As Integer

            Dim LastAdjustmentNumberStatement As String = "SELECT MAX(SteelAdjustmentKey) FROM SteelAdjustmentTable"
            Dim LastAdjustmentNumberCommand As New SqlCommand(LastAdjustmentNumberStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastAdjustmentNumber = CInt(LastAdjustmentNumberCommand.ExecuteScalar)
            Catch ex As Exception
                LastAdjustmentNumber = 337000000
            End Try
            con.Close()

            NextAdjustmentNumber = LastAdjustmentNumber + 1
            '************************************************************************************************
            'Write Line data to new table
            cmd = New SqlCommand("Insert Into SteelAdjustmentTable(SteelAdjustmentKey, BatchNumber, DivisionID, RMID, SteelCarbon, SteelSize, AdjustmentDate, AdjustmentWeight, AdjustmentCost, AdjustmentTotal, Comment, Status, Locked, UserID, ChangeRMID, ChangeCoilID) Values (@SteelAdjustmentKey, @BatchNumber, @DivisionID, @RMID, @SteelCarbon, @SteelSize, @AdjustmentDate, @AdjustmentWeight, @AdjustmentCost, @AdjustmentTotal, @Comment, @Status, @Locked, @UserID, @ChangeRMID, @ChangeCoilID)", con)

            With cmd.Parameters
                .Add("@SteelAdjustmentKey", SqlDbType.VarChar).Value = NextAdjustmentNumber
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                .Add("@RMID", SqlDbType.VarChar).Value = NextRMID
                .Add("@SteelCarbon", SqlDbType.VarChar).Value = NextCarbon
                .Add("@SteelSize", SqlDbType.VarChar).Value = NextSteelSize
                .Add("@AdjustmentDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                .Add("@AdjustmentWeight", SqlDbType.VarChar).Value = NextCoilWeight
                .Add("@AdjustmentCost", SqlDbType.VarChar).Value = GetSteelUnitCost
                .Add("@AdjustmentTotal", SqlDbType.VarChar).Value = NextCoilCost
                .Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                '.Add("@PrintDate", SqlDbType.VarChar).Value = ""
                .Add("@ChangeRMID", SqlDbType.VarChar).Value = LastRMID
                .Add("@ChangeCoilID", SqlDbType.VarChar).Value = LastCoilID
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Update Charter table
            If NextCoilID = LastCoilID Then
                'Run Update command
                Try
                    'Update existing Inventory adjustments to a negative value
                    cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Carbon = @Carbon, SteelSize = @SteelSize, Weight = @Weight WHERE CoilID = @CoilID AND Status = @Status", con)
                    cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = NextCoilID
                    cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "RAW"
                    cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = NextCarbon
                    cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = NextSteelSize
                    cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = NextCoilWeight

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                    Dim AdjustmentBatchNumber As Integer
                    AdjustmentBatchNumber = Val(cboAdjustmentBatchNumber.Text)
                    Dim strBatchNumber As String = ""

                    strBatchNumber = CStr(AdjustmentBatchNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = "TWD"
                    ErrorDescription = "Failure of coil table update - Steel Transfer Coils"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Get Coil Data from Charter Table to write new entry
                Dim GetDespatchNumber, GetPONumber, GetSONumber, GetDescription, GetLotNumber, GetComment, GetAnnealLotNumber, GetInventoryID, GetLocation As String

                Dim GetCoilDataStatement As String = "SELECT * FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID"
                Dim GetCoilDataCommand As New SqlCommand(GetCoilDataStatement, con)
                GetCoilDataCommand.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = LastCoilID

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = GetCoilDataCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("DespatchNumber")) Then
                        GetDespatchNumber = ""
                    Else
                        GetDespatchNumber = reader.Item("DespatchNumber")
                    End If
                    If IsDBNull(reader.Item("PurchaseOrderNumber")) Then
                        GetPONumber = ""
                    Else
                        GetPONumber = reader.Item("PurchaseOrderNumber")
                    End If
                    If IsDBNull(reader.Item("SalesOrderNumber")) Then
                        GetSONumber = ""
                    Else
                        GetSONumber = reader.Item("SalesOrderNumber")
                    End If
                    If IsDBNull(reader.Item("Description")) Then
                        GetDescription = ""
                    Else
                        GetDescription = reader.Item("Description")
                    End If
                    If IsDBNull(reader.Item("LotNumber")) Then
                        GetLotNumber = ""
                    Else
                        GetLotNumber = reader.Item("LotNumber")
                    End If
                    If IsDBNull(reader.Item("Comment")) Then
                        GetComment = ""
                    Else
                        GetComment = reader.Item("Comment")
                    End If
                    If IsDBNull(reader.Item("AnnealLot")) Then
                        GetAnnealLotNumber = ""
                    Else
                        GetAnnealLotNumber = reader.Item("AnnealLot")
                    End If
                    If IsDBNull(reader.Item("InventoryID")) Then
                        GetInventoryID = ""
                    Else
                        GetInventoryID = reader.Item("InventoryID")
                    End If
                    If IsDBNull(reader.Item("Location")) Then
                        GetLocation = ""
                    Else
                        GetLocation = reader.Item("Location")
                    End If
                Else
                    GetAnnealLotNumber = ""
                    GetPONumber = ""
                    GetDespatchNumber = ""
                    GetSONumber = ""
                    GetComment = ""
                    GetDescription = ""
                    GetInventoryID = ""
                    GetLocation = ""
                    GetLotNumber = ""
                End If
                reader.Close()
                con.Close()
                '********************************************************************************************
                Try
                    'Run insert command and close old coil
                    cmd = New SqlCommand("Insert Into CharterSteelCoilIdentification(CoilID, HeatNumber, Weight, LotNumber, Carbon, SteelSize, ReceiveDate, DespatchNumber, SalesOrderNumber, PurchaseOrderNumber, Description, Status, Location, InventoryID, AnnealLot, Comment) Values (@CoilID, @HeatNumber, @Weight, @LotNumber, @Carbon, @SteelSize, @ReceiveDate, @DespatchNumber, @SalesOrderNumber, @PurchaseOrderNumber, @Description, @Status, @Location, @InventoryID, @AnnealLot, @Comment)", con)

                    With cmd.Parameters
                        .Add("@CoilID", SqlDbType.VarChar).Value = NextCoilID
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = NextHeatNumber
                        .Add("@Weight", SqlDbType.VarChar).Value = NextCoilWeight
                        .Add("@LotNumber", SqlDbType.VarChar).Value = GetLotNumber
                        .Add("@Carbon", SqlDbType.VarChar).Value = NextCarbon
                        .Add("@SteelSize", SqlDbType.VarChar).Value = NextSteelSize
                        .Add("@ReceiveDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                        .Add("@DespatchNumber", SqlDbType.VarChar).Value = GetDespatchNumber
                        .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = GetSONumber
                        .Add("@PurchaseOrderNumber", SqlDbType.VarChar).Value = GetPONumber
                        .Add("@Description", SqlDbType.VarChar).Value = GetDescription
                        .Add("@Status", SqlDbType.VarChar).Value = "RAW"
                        .Add("@Location", SqlDbType.VarChar).Value = GetLocation
                        .Add("@InventoryID", SqlDbType.VarChar).Value = GetInventoryID
                        .Add("@AnnealLot", SqlDbType.VarChar).Value = GetAnnealLotNumber
                        .Add("@Comment", SqlDbType.VarChar).Value = GetComment
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                    Dim AdjustmentBatchNumber As Integer
                    AdjustmentBatchNumber = Val(cboAdjustmentBatchNumber.Text)
                    Dim strBatchNumber As String = ""

                    strBatchNumber = CStr(AdjustmentBatchNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = "TWD"
                    ErrorDescription = "Failure to insert into coil table - Steel Transfer Coils"
                    ErrorReferenceNumber = "Batch # " + strBatchNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************************
                'Close old coil
                Try
                    'Update existing Inventory adjustments to a negative value
                    cmd = New SqlCommand("UPDATE CharterSteelCoilIdentification SET Status = @Status WHERE CoilID = @CoilID", con)
                    cmd.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = LastCoilID
                    cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                End Try

                'Clear variables for coil data
                GetAnnealLotNumber = ""
                GetPONumber = ""
                GetDespatchNumber = ""
                GetSONumber = ""
                GetComment = ""
                GetDescription = ""
                GetInventoryID = ""
                GetLocation = ""
                GetLotNumber = ""
            End If

            'Clear variables for loop
            NextCarbon = ""
            NextSteelSize = ""
            NextCoilCost = 0
            NextCoilWeight = 0
            LastRMID = ""
            LastCoilID = ""
            NextRMID = ""
            GetSteelUnitCost = 0
        Next
        '************************************************************************************************
        'Load Steel adjustments into data table and run loop
        ShowAdjustmentDataToPost()

        'For each row, create steel transaction, and cost tier
        Dim SteelAdjustmentKey As Integer = 0
        Dim PostRMID, PostCarbon, PostSteelSize As String
        Dim PostCoilWeight, PostCoilUnitCost, PostCoilTotalCost As Double

        For Each Row As DataGridViewRow In dgvSteelAdjustments.Rows
            Try
                SteelAdjustmentKey = Row.Cells("SteelAdjustmentKeyColumn3").Value
            Catch ex As System.Exception
                SteelAdjustmentKey = 0
            End Try
            Try
                PostRMID = Row.Cells("RMIDColumn3").Value
            Catch ex As System.Exception
                PostRMID = ""
            End Try
            Try
                PostCarbon = Row.Cells("SteelCarbonColumn3").Value
            Catch ex As System.Exception
                PostCarbon = ""
            End Try
            Try
                PostSteelSize = Row.Cells("SteelSizeColumn3").Value
            Catch ex As System.Exception
                PostSteelSize = 0
            End Try
            Try
                PostCoilWeight = Row.Cells("AdjustmentWeightColumn3").Value
            Catch ex As System.Exception
                PostCoilWeight = 0
            End Try
            Try
                PostCoilUnitCost = Row.Cells("AdjustmentCostColumn3").Value
            Catch ex As System.Exception
                PostCoilUnitCost = 0
            End Try
            Try
                PostCoilTotalCost = Row.Cells("AdjustmentTotalColumn3").Value
            Catch ex As System.Exception
                PostCoilTotalCost = 0
            End Try

            'Create Steel Transaction
            cmd = New SqlCommand("Insert Into SteelTransactionTable(TransactionNumber, DivisionID, SteelTransactionDate, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType) Values ((SELECT isnull(MAX(TransactionNumber) + 1, 2200000) FROM SteelTransactionTable), @DivisionID, @SteelTransactionDate, @Carbon, @SteelSize, @Quantity, @SteelCost, @ExtendedCost, @SteelReferenceNumber, @SteelReferenceLine, @RMID, @TransactionMath, @TransactionType)", con)

            With cmd.Parameters
                '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCoilID
                .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                .Add("@SteelTransactionDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                .Add("@Carbon", SqlDbType.VarChar).Value = PostCarbon
                .Add("@SteelSize", SqlDbType.VarChar).Value = PostSteelSize
                .Add("@Quantity", SqlDbType.VarChar).Value = PostCoilWeight
                .Add("@SteelCost", SqlDbType.VarChar).Value = PostCoilUnitCost
                .Add("@ExtendedCost", SqlDbType.VarChar).Value = PostCoilTotalCost
                .Add("@SteelReferenceNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                .Add("@SteelReferenceLine", SqlDbType.VarChar).Value = SteelAdjustmentKey
                .Add("@RMID", SqlDbType.VarChar).Value = PostRMID
                .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                .Add("@TransactionType", SqlDbType.VarChar).Value = "STEEL ADJUSTMENT"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '****************************************************************************************************
            'Create Cost Tier
            If PostCoilWeight < 0 Then
                'Get Max Transaction Number to get last Upper Limit
                Dim MaxCostingTransactionNumber As Integer = 0
                Dim GetUpperLimit, GetLowerLimit, NewUpperLimit As Double

                Dim MaxCostingTransactionNumberStatement As String = "SELECT MAX(TransactionNUmber) FROM SteelCostingTable WHERE RMID = @RMID"
                Dim MaxCostingTransactionNumberCommand As New SqlCommand(MaxCostingTransactionNumberStatement, con)
                MaxCostingTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = PostRMID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MaxCostingTransactionNumber = CInt(MaxCostingTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    MaxCostingTransactionNumber = 0
                End Try
                con.Close()

                Dim GetUpperLimitStatement As String = "SELECT UpperLimit FROM SteelCostingTable WHERE RMID = @RMID AND TransactionNumber = @TransactionNumber"
                Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitStatement, con)
                GetUpperLimitCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = PostRMID
                GetUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxCostingTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
                Catch ex As Exception
                    GetUpperLimit = 0
                End Try
                con.Close()

                GetLowerLimit = GetUpperLimit
                NewUpperLimit = GetUpperLimit + PostCoilWeight

                'Insert into cost tier
                cmd = New SqlCommand("Insert Into SteelCostingTable(RMID, Carbon, SteelSize, CostingDate, SteelCostPerPound, CostingQuantity, LowerLimit, UpperLimit, Status, TransactionNumber, ReferenceNumber, ReferenceLine) Values (@RMID, @Carbon, @SteelSize, @CostingDate, @SteelCostPerPound, @CostingQuantity, @LowerLimit, @UpperLimit, @Status, (SELECT isnull(MAX(TransactionNumber) + 1, 2200000) FROM SteelCostingTable), @ReferenceNumber, @ReferenceLine)", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = PostRMID
                    .Add("@Carbon", SqlDbType.VarChar).Value = PostCarbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = PostSteelSize
                    .Add("@CostingDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                    .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = PostCoilUnitCost
                    .Add("@CostingQuantity", SqlDbType.VarChar).Value = PostCoilWeight
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = GetLowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                    .Add("@Status", SqlDbType.VarChar).Value = "STEEL ADJUSTMENT"
                    '.Add("@TransactionNumber", SqlDbType.VarChar).Value = SteelAdjustmentKey
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = SteelAdjustmentKey
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'Get Max Transaction Number to get last Upper Limit
                Dim MaxCostingTransactionNumber As Integer = 0
                Dim GetUpperLimit, GetLowerLimit, NewUpperLimit As Double

                Dim MaxCostingTransactionNumberStatement As String = "SELECT MAX(TransactionNUmber) FROM SteelCostingTable WHERE RMID = @RMID"
                Dim MaxCostingTransactionNumberCommand As New SqlCommand(MaxCostingTransactionNumberStatement, con)
                MaxCostingTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = PostRMID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MaxCostingTransactionNumber = CInt(MaxCostingTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    MaxCostingTransactionNumber = 0
                End Try
                con.Close()

                Dim GetUpperLimitStatement As String = "SELECT UpperLimit FROM SteelCostingTable WHERE RMID = @RMID AND TransactionNumber = @TransactionNumber"
                Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitStatement, con)
                GetUpperLimitCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = PostRMID
                GetUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxCostingTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
                Catch ex As Exception
                    GetUpperLimit = 0
                End Try
                con.Close()

                GetLowerLimit = GetUpperLimit + 1
                NewUpperLimit = GetUpperLimit + PostCoilWeight

                'Insert into cost tier
                cmd = New SqlCommand("Insert Into SteelCostingTable(RMID, Carbon, SteelSize, CostingDate, SteelCostPerPound, CostingQuantity, LowerLimit, UpperLimit, Status, TransactionNumber, ReferenceNumber, ReferenceLine) Values (@RMID, @Carbon, @SteelSize, @CostingDate, @SteelCostPerPound, @CostingQuantity, @LowerLimit, @UpperLimit, @Status, (SELECT isnull(MAX(TransactionNumber) + 1, 2200000) FROM SteelCostingTable), @ReferenceNumber, @ReferenceLine)", con)

                With cmd.Parameters
                    .Add("@RMID", SqlDbType.VarChar).Value = PostRMID
                    .Add("@Carbon", SqlDbType.VarChar).Value = PostCarbon
                    .Add("@SteelSize", SqlDbType.VarChar).Value = PostSteelSize
                    .Add("@CostingDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                    .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = PostCoilUnitCost
                    .Add("@CostingQuantity", SqlDbType.VarChar).Value = PostCoilWeight
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = GetLowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                    .Add("@Status", SqlDbType.VarChar).Value = "STEEL ADJUSTMENT"
                    '.Add("@TransactionNumber", SqlDbType.VarChar).Value = SteelAdjustmentKey
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@ReferenceLine", SqlDbType.VarChar).Value = SteelAdjustmentKey
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        '**************************************************************************************
        'Create GL Entry
        Dim SumOfOldCoils, SumOfNewCoils, NetCoilDifference As Double

        Dim SumOfOldCoilsStatement As String = "SELECT SUM(CoilCost) FROM SteelChangeCoilAndRMID WHERE SteelAdjustmentBatch = @SteelAdjustmentBatch AND DivisionID = @DivisionID"
        Dim SumOfOldCoilsCommand As New SqlCommand(SumOfOldCoilsStatement, con)
        SumOfOldCoilsCommand.Parameters.Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
        SumOfOldCoilsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        Dim SumOfNewCoilsStatement As String = "SELECT SUM(ReworkCoilCost) FROM SteelChangeCoilAndRMID WHERE SteelAdjustmentBatch = @SteelAdjustmentBatch AND DivisionID = @DivisionID"
        Dim SumOfNewCoilsCommand As New SqlCommand(SumOfNewCoilsStatement, con)
        SumOfNewCoilsCommand.Parameters.Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
        SumOfNewCoilsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumOfOldCoils = CDbl(SumOfOldCoilsCommand.ExecuteScalar)
        Catch ex As Exception
            SumOfOldCoils = 0
        End Try
        Try
            SumOfNewCoils = CDbl(SumOfNewCoilsCommand.ExecuteScalar)
        Catch ex As Exception
            SumOfNewCoils = 0
        End Try
        con.Close()

        NetCoilDifference = (SumOfOldCoils * -1) - SumOfNewCoils
        NetCoilDifference = Math.Round(NetCoilDifference, 2)

        If NetCoilDifference > 0 And NetCoilDifference < 10 Then
            'Skip Posting
        ElseIf NetCoilDifference < 0 And NetCoilDifference > -10 Then
            'Skip Posting
        ElseIf NetCoilDifference > 0 And NetCoilDifference >= 10 Then
            'Credit Raw Materials and Debit Adjustment Account
            Try
                'CREDIT ENTRY ***************************************************************************
                'Command to write Sales Tax to GL
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    ' .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12000"
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Adjustment - Transfer Coils"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = NetCoilDifference
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Difference on Coils"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 1
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                'DEBIT ENTRY **********************************************************************
                'Command to write Sales Tax to GL
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "59790"
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Adjustment - Transfer Coils"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = NetCoilDifference
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Credit Difference on Coils"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 1
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Invoice add tax error
                Dim AdjustmentBatchNumber As Integer
                AdjustmentBatchNumber = Val(cboAdjustmentBatchNumber.Text)
                Dim strBatchNumber As String = ""

                strBatchNumber = CStr(AdjustmentBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = "TWD"
                ErrorDescription = "Failure of GL Posting - Steel Transfer Coils"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        ElseIf NetCoilDifference < 0 And NetCoilDifference <= -10 Then
            'Debit Raw Materials and Credit Adjustment Account
            Try
                'CREDIT ENTRY ***************************************************************************
                'Command to write Sales Tax to GL
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    ' .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12000"
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Adjustment - Transfer Coils"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = NetCoilDifference * -1
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Debit Difference on Coils"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 1
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                'DEBIT ENTRY **********************************************************************
                'Command to write Sales Tax to GL
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 7700000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "59790"
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Steel Adjustment - Transfer Coils"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = NetCoilDifference * -1
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Debit Difference on Coils"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 1
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Invoice add tax error
                Dim AdjustmentBatchNumber As Integer
                AdjustmentBatchNumber = Val(cboAdjustmentBatchNumber.Text)
                Dim strBatchNumber As String = ""

                strBatchNumber = CStr(AdjustmentBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = "TWD"
                ErrorDescription = "Failure of GL Posting - Steel Transfer Coils"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
        '***************************************************************************************
        'Close Adjustment
        Try
            'Update existing Inventory adjustments to a negative value
            cmd = New SqlCommand("UPDATE SteelAdjustmentTable SET Status = @Status, PrintDate = @PrintDate, Locked = @Locked WHERE BatchNumber = @BatchNumber", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"
            cmd.Parameters.Add("@PrintDate", SqlDbType.VarChar).Value = Today()
            cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            Dim AdjustmentBatchNumber As Integer
            AdjustmentBatchNumber = Val(cboAdjustmentBatchNumber.Text)
            Dim strBatchNumber As String = ""

            strBatchNumber = CStr(AdjustmentBatchNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = "TWD"
            ErrorDescription = "Failure on post updating steel adjustment table - Steel Transfer Coils"
            ErrorReferenceNumber = "Batch # " + strBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        Try
            'Update existing Inventory adjustments to a negative value
            cmd = New SqlCommand("UPDATE SteelChangeCoilAndRMID SET BatchStatus = @BatchStatus WHERE SteelAdjustmentBatch = @SteelAdjustmentBatch", con)
            cmd.Parameters.Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
            cmd.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
        End Try

        MsgBox("Coil Adjustment has been transferred and posted.", MsgBoxStyle.OkOnly)
        '*************************************************************************************
        'Clear Fields
        ClearVariables()
        ClearData()
        ClearCoilList()
        ClearDataInDatagrid()
        ClearAdjustmentDataToPost()
    End Sub

    Private Sub dgvChangeCoils_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChangeCoils.CellValueChanged
        If Me.dgvChangeCoils.RowCount = 0 Then

        Else
            Dim RowSteelAdjustmentNumber As Integer = 0
            Dim RowReworkCarbon, RowReworkSteelSize, RowReworkCoilID, RowReworkRMID As String
            Dim RowReworkCoilWeight As Double = 0
            Dim RowReworkCoilCost As Double = 0
            Dim RowOldCost As Double = 0
            Dim RowOldWeight As Double = 0

            Dim currentRow As Integer = dgvChangeCoils.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvChangeCoils.CurrentCell.ColumnIndex

            'Retrieve line data from PO Table and write to Receipt Of Invoice Table
            If IsDBNull(dgvChangeCoils.Rows(currentRow).Cells("SteelAdjustmentNumberColumn").Value) Then
                RowSteelAdjustmentNumber = 0
            Else
                RowSteelAdjustmentNumber = dgvChangeCoils.Rows(currentRow).Cells("SteelAdjustmentNumberColumn").Value
            End If
            If IsDBNull(dgvChangeCoils.Rows(currentRow).Cells("ReworkCarbonColumn").Value) Then
                RowReworkCarbon = ""
            Else
                RowReworkCarbon = dgvChangeCoils.Rows(currentRow).Cells("ReworkCarbonColumn").Value
                'RowReworkCarbon = RowReworkCarbon.ToUpper
            End If
            If IsDBNull(dgvChangeCoils.Rows(currentRow).Cells("ReworkSteelSizeColumn").Value) Then
                RowReworkSteelSize = ""
            Else
                RowReworkSteelSize = dgvChangeCoils.Rows(currentRow).Cells("ReworkSteelSizeColumn").Value
                'RowReworkSteelSize = RowReworkSteelSize.ToUpper
            End If
            If IsDBNull(dgvChangeCoils.Rows(currentRow).Cells("ReworkCoilIDColumn").Value) Then
                RowReworkCoilID = ""
            Else
                RowReworkCoilID = dgvChangeCoils.Rows(currentRow).Cells("ReworkCoilIDColumn").Value
                'RowReworkCoilID = RowReworkCoilID.ToUpper
            End If
            If IsDBNull(dgvChangeCoils.Rows(currentRow).Cells("ReworkCoilWeightColumn").Value) Then
                RowReworkCoilWeight = 0
            Else
                RowReworkCoilWeight = dgvChangeCoils.Rows(currentRow).Cells("ReworkCoilWeightColumn").Value
            End If
            If IsDBNull(dgvChangeCoils.Rows(currentRow).Cells("ReworkCoilWeightColumn").Value) Then
                RowReworkCoilWeight = 0
            Else
                RowReworkCoilWeight = dgvChangeCoils.Rows(currentRow).Cells("ReworkCoilWeightColumn").Value
            End If
            If IsDBNull(dgvChangeCoils.Rows(currentRow).Cells("CoilCostColumn").Value) Then
                RowOldCost = 0
            Else
                RowOldCost = dgvChangeCoils.Rows(currentRow).Cells("CoilCostColumn").Value
            End If
            If IsDBNull(dgvChangeCoils.Rows(currentRow).Cells("CoilWeightColumn").Value) Then
                RowOldWeight = 0
            Else
                RowOldWeight = dgvChangeCoils.Rows(currentRow).Cells("CoilWeightColumn").Value
            End If

            'Get RMID
            Dim RowRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
            Dim RowRMIDCommand As New SqlCommand(RowRMIDStatement, con)
            RowRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = RowReworkCarbon
            RowRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = RowReworkSteelSize

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                RowReworkRMID = CStr(RowRMIDCommand.ExecuteScalar)
            Catch ex As Exception
                RowReworkRMID = ""
            End Try
            con.Close()
            '*********************************************************************************************
            If RowOldCost = 0 Then
                'Get Coil Cost
                Dim MaxTransactionNumber As Integer = 0
                Dim GetSteelUnitCost As Double = 0

                Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID"
                Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
                MaxTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowReworkRMID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    MaxTransactionNumber = 0
                End Try
                con.Close()

                Dim GetSteelUnitCostStatement As String = "SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND TransactionNumber = @TransactionNumber"
                Dim GetSteelUnitCostCommand As New SqlCommand(GetSteelUnitCostStatement, con)
                GetSteelUnitCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RowReworkRMID
                GetSteelUnitCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSteelUnitCost = CDbl(GetSteelUnitCostCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSteelUnitCost = 0
                End Try
                con.Close()

                RowReworkCoilCost = RowReworkCoilWeight * GetSteelUnitCost
                RowReworkCoilCost = Math.Round(RowReworkCoilCost, 2)
            Else
                Dim GetSteelUnitCost As Double = 0

                GetSteelUnitCost = RowOldCost / RowOldWeight
                RowReworkCoilCost = RowReworkCoilWeight * GetSteelUnitCost
                RowReworkCoilCost = Math.Round(RowReworkCoilCost, 2)
            End If
            '***********************************************************************************************
            Try
                'Update Table
                cmd = New SqlCommand("UPDATE SteelChangeCoilAndRMID SET ReworkRMID = @ReworkRMID, ReworkCarbon = @ReworkCarbon, ReworkSteelSize = @ReworkSteelSize, ReworkCoilID = @ReworkCoilID, ReworkCoilWeight = @ReworkCoilWeight, ReworkCoilCost = @ReworkCoilCost WHERE SteelAdjustmentBatch = @SteelAdjustmentBatch AND SteelAdjustmentNumber = @SteelAdjustmentNumber", con)

                With cmd.Parameters
                    .Add("@SteelAdjustmentBatch", SqlDbType.VarChar).Value = Val(cboAdjustmentBatchNumber.Text)
                    .Add("@SteelAdjustmentNumber", SqlDbType.VarChar).Value = RowSteelAdjustmentNumber
                    .Add("@ReworkRMID", SqlDbType.VarChar).Value = RowReworkRMID
                    .Add("@ReworkCarbon", SqlDbType.VarChar).Value = RowReworkCarbon
                    .Add("@ReworkSteelSize", SqlDbType.VarChar).Value = RowReworkSteelSize
                    .Add("@ReworkCoilID", SqlDbType.VarChar).Value = RowReworkCoilID
                    .Add("@ReworkCoilWeight", SqlDbType.VarChar).Value = RowReworkCoilWeight
                    .Add("@ReworkCoilCost", SqlDbType.VarChar).Value = RowReworkCoilCost
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear Variables
                RowSteelAdjustmentNumber = 0
                RowReworkCarbon = ""
                RowReworkSteelSize = ""
                RowReworkCoilID = ""
                RowReworkRMID = ""
                RowReworkCoilWeight = 0
                RowReworkCoilCost = 0
                RowOldCost = 0
                RowOldWeight = 0

                'Reload Data
                ShowData()
            Catch ex As Exception
                'Error Check
                Dim AdjustmentBatchNumber As Integer
                AdjustmentBatchNumber = Val(cboAdjustmentBatchNumber.Text)
                Dim strBatchNumber As String = ""

                strBatchNumber = CStr(AdjustmentBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = "TWD"
                ErrorDescription = "Failure of datagrid updates - Steel Transfer Coils"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Private Sub cboAdjustmentBatchNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdjustmentBatchNumber.SelectedIndexChanged
        LoadAdjustmentData()
        ShowData()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearCoilList()
        ClearVariables()
        ClearData()
        ClearAdjustmentDataToPost()
        ClearDataInDatagrid()

        cboAdjustmentBatchNumber.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckAll.Click
        For Each row As DataGridViewRow In dgvCoilList.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectCoil")
            cell.Value = "SELECTED"
        Next
    End Sub

End Class