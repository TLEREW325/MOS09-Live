Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class LotNumberMaintenanceFOXSchedVerification
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand

    Dim MachineDS As New DataSet()
    Dim machineIDCheck As New List(Of String)
    Dim isLoaded As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal FOXNumber As String)
        InitializeComponent()

        usefulFunctions.LoadSecurity(Me)

        lblFOXNumber.Text = FOXNumber

        LoadFOXSched()
        LoadProcessID()

        If con.State = ConnectionState.Open Then con.Close()
        isLoaded = True
    End Sub

    Private Sub LoadFOXSched()
        cmd = New SqlCommand("SELECT ProcessStep as OrigionalStep, ProcessStep, ProcessID, ProcessAddFG FROM FOXSched WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(lblFOXNumber.Text)

        Dim tempds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()

        adap.Fill(tempds, "FOXSched")

        dgvFOXRouting.DataSource = tempds.Tables("FOXSched")
        SetupDGV()
    End Sub

    Private Sub LoadProcessID()
        cmd = New SqlCommand("SELECT MachineID, Description FROM MachineTable WHERE DivisionID = 'TWD'", con)

        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(MachineDS, "MachineTable")

        cboProcessID.DisplayMember = "MachineID"
        cboProcessID.DataSource = MachineDS.Tables("MachineTable")
        cboProcessID.SelectedIndex = -1

        For i As Integer = 0 To MachineDS.Tables("MachineTable").Rows.Count - 1
            machineIDCheck.Add(MachineDS.Tables("MachineTable").Rows(i).Item("MachineID").ToString())
        Next
    End Sub

    Private Sub SetupDGV()
        dgvFOXRouting.Columns("OrigionalStep").Visible = False
        dgvFOXRouting.Columns("ProcessStep").HeaderText = "Process Step"
        dgvFOXRouting.Columns("ProcessID").HeaderText = "Process ID"
        dgvFOXRouting.Columns("ProcessAddFG").HeaderText = "Add FG?"

        For i As Integer = 0 To dgvFOXRouting.Rows.Count - 1
            Dim chkbx As New DataGridViewCheckBoxCell
            chkbx.TrueValue = "ADDINVENTORY"
            chkbx.FalseValue = "NO"

            chkbx.Value = dgvFOXRouting.Rows(i).Cells("ProcessAddFG").Value
            dgvFOXRouting.Rows(i).Cells("ProcessAddFG") = chkbx
        Next
    End Sub

    Private Sub LotNumberMaintenanceFOXSchedVerification_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = System.Windows.Forms.DialogResult.None Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Hide()
        End If
    End Sub

    Private Sub cmdGenerateProcessStep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateProcessStep.Click
        'Clear on next process number
        txtProcessStep.Clear()
        cboProcessID.SelectedIndex = -1

        'Find the next Step Number to use
        cmd = New SqlCommand("SELECT isnull(MAX(ProcessStep) + 1, 1) FROM FoxSched Where FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(lblFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            txtProcessStep.Text = cmd.ExecuteScalar
        Catch ex As System.Exception
            txtProcessStep.Text = 1
        End Try
        con.Close()
    End Sub

    Private Sub cboProcessID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProcessID.SelectedIndexChanged
        If isLoaded Then
            If cboProcessID.SelectedIndex <> -1 Then
                txtMachineDescription.Text = MachineDS.Tables("MachineTable").Rows(cboProcessID.SelectedIndex).Item("Description")
            Else
                txtMachineDescription.Clear()
            End If
        End If
    End Sub

    Private Sub cmdAddProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddProcess.Click
        ''Add Process to FOX Record
        If canAddStep() Then

            Dim FinishedGoods As String = "NO"

            ''check to see if there is a need to remove
            If chkAddToFinishedGoods.Checked Then
                'remove any previous inventory add to finished goods
                cmd = New SqlCommand("DECLARE @ProductionNumber as int = CASE WHEN EXISTS(SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') THEN (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') ELSE (SELECT 0) END; UPDATE FOXSched SET ProcessAddFG = 'NO' WHERE FOXNumber = @FOXNumber; IF @ProductionNumber <> 0 UPDATE FOXProductionNumberSched SET ProcessAddFG = 'NO' WHERE FOXNumber = @FOXNumber and ProductionNumber = @ProductionNumber;", con)
                ''Adds Audit trail entry for finished goods.
                cmd.CommandText += " DECLARE @DivisionID as varchar(50) = (SELECT DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber); INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID);"

                FinishedGoods = "ADDINVENTORY"
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(lblFOXNumber.Text)
                cmd.Parameters.Add("@AuditDate", SqlDbType.Date).Value = Now
                cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                cmd.Parameters.Add("@AuditType", SqlDbType.VarChar).Value = "FOX FINISHED GOODS STEP ADDED"
                cmd.Parameters.Add("@AuditAmount", SqlDbType.Float).Value = Val(txtProcessStep.Text)
                cmd.Parameters.Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(lblFOXNumber.Text)
                cmd.Parameters.Add("@AuditComment", SqlDbType.VarChar).Value = "FOX #" + lblFOXNumber.Text + " Process Step # " + txtProcessStep.Text + " Process ID # " + cboProcessID.Text + " now adds to finished goods."

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
            End If

            Try
                'DECLARATIONS for production number and division ID
                cmd = New SqlCommand("DECLARE @ProductionNumber as int = CASE WHEN EXISTS(SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') THEN (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') ELSE (SELECT 0) END, @DivisionID as varchar(50) = (SELECT DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber);", con)
                '' check to see if the process step exists
                cmd.CommandText += " if exists(select ProcessStep from FOXSched where FOXNumber = @foxnumber and ProcessStep = @processstep)"
                ''updates the FOX sched process step number at or above the current position being added
                cmd.CommandText += " BEGIN UPDATE FOXSched SET ProcessStep = ProcessStep + 1 WHERE FOXNumber = @foxnumber and ProcessStep >= @processstep;"
                ''updates the production number fox sched process step number at or above current position being added
                cmd.CommandText += "  if (@ProductionNumber <> 0) BEGIN update FOXProductionNumberSched set ProcessStep = ProcessStep + 1 where FOXNumber = @foxnumber and ProcessStep >= @processstep and ProductionNumber = @ProductionNumber;"
                ''Updates the timeslip line item so that it will corrispond to the proper step, if there is an entry for the FOX
                cmd.CommandText += " UPDATE TimeSlipLineItemTable SET FOXStep = FOXStep + 1 WHERE ProductionNumber = @ProductionNumber AND FOXNumber = @FOXNumber AND FOXStep >= @ProcessStep; END end"
                ''Inserts the new step into the fox sched
                cmd.CommandText += " INSERT into FOXSched (FOXNumber, ProcessStep, ProcessID, ProcessRemoveRM, ProcessAddFG)values(@foxnumber, @processstep, @processid, 'NO', @processaddfg);"
                ''Inserts the new step into the fox production number sched
                cmd.CommandText += " if (@ProductionNumber <> 0) insert into FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) values (@ProductionNumber, @foxnumber, @processstep, @processid, @processaddfg);"
                ''Adds the audit trail entry
                cmd.CommandText += " INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID);"

                With cmd.Parameters
                    .Add("@foxnumber", SqlDbType.VarChar).Value = Val(lblFOXNumber.Text)
                    .Add("@processstep", SqlDbType.VarChar).Value = Val(txtProcessStep.Text)
                    .Add("@processid", SqlDbType.VarChar).Value = cboProcessID.Text
                    .Add("@processaddfg", SqlDbType.VarChar).Value = FinishedGoods
                    .Add("@AuditDate", SqlDbType.Date).Value = Now
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "FOX STEP ADDED"
                    .Add("@AuditAmount", SqlDbType.Float).Value = Val(txtProcessStep.Text)
                    .Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(lblFOXNumber.Text)
                    .Add("@AuditComment", SqlDbType.VarChar).Value = "FOX #" + lblFOXNumber.Text + " Process Step # " + txtProcessStep.Text + " Process ID # " + cboProcessID.Text + " is now a part of the routing."
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                sendErrorToDataBase("LotNumberMaintenanceFOXSchedVerificaiton - cmdAddProcess_Click -- adding new process to FOX", "FOX #" + lblFOXNumber.Text, ex.ToString())
            End Try

            isLoaded = False
            LoadFOXSched()
            isLoaded = True
            cboProcessID.SelectedIndex = -1
            txtProcessStep.Clear()
            chkAddToFinishedGoods.Checked = False
        End If
    End Sub

    Private Function canAddStep() As Boolean
        If String.IsNullOrEmpty(txtProcessStep.Text) Then
            MessageBox.Show("You must enter a Process Step Number", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProcessStep.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboProcessID.Text) Then
            MessageBox.Show("You must enter a Process ID", "Enter a Process ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProcessID.Focus()
            Return False
        End If
        If cboProcessID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Process ID", "Enter a valid Process ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProcessID.SelectAll()
            cboProcessID.Focus()
            Return False
        End If
        Return True
    End Function

    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)
        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End With
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub


    Private Sub cmdDeleteProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteProcess.Click
        If canDeleteProcess() Then
            Dim currentRow As Integer = dgvFOXRouting.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvFOXRouting.CurrentCell.ColumnIndex
            ''DECLARATIONS for Division Id and Production Number
            cmd = New SqlCommand("DECLARE @DivisionID as varchar(50) = (SELECT DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber), @ProductionNumber as int = CASE WHEN EXISTS(SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') THEN (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') ELSE (SELECT 0) END;", con)
            ''Deletes the fox Sched step
            cmd.CommandText += " DELETE FROM FoxSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep AND ProcessID = @ProcessID;"
            ''Deletes the fox production number sched step if a production number exists
            cmd.CommandText += " IF (@ProductionNumber <> 0) DELETE FoxProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep AND ProcessID = @ProcessID AND ProductionNumber = @ProductionNumber; "
            ''Adds audit entry for the deletion of a step
            cmd.CommandText += " INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType + ' STEP DELETED', @AuditAmount, @AuditReferenceNumber, @AuditComment + ' was deleted from the routing.', @DivisionID);"
            ''Adds audit entry for if it has to renumber the routing
            cmd.CommandText += " IF ((SELECT Count(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep > @ProcessStep) <> 0) INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType + ' PROCESS STEPS RENUMBERED', @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID);"
            ''Renumbers the process steps that cam after the deleted step
            cmd.CommandText += "  UPDATE FoxSched SET ProcessStep = ProcessStep - 1 WHERE FOXNumber = @FOXNumber AND ProcessStep > @ProcessStep; IF (@ProductionNumber <> 0) UPDATE FOXProductionNumberSched SET ProcessStep = ProcessStep - 1 WHERE FOXNumber = @FOXNumber AND ProcessStep > @ProcessStep AND ProductionNumber = @ProductionNumber;"
            ''Checks to see if the FOX still has a finished goods step. If it does not this will add it into the final step in the routing. Also adds audit trail entry if needed
            cmd.CommandText += " IF ((SELECT Count(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY') = 0) BEGIN IF ((SELECT Count(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber) > 0) BEGIN DECLARE @MaxStep as int = (SELECT MAX(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber); DECLARE @MaxProcessID as varchar(50) = (SELECT ProcessID FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @MaxStep); UPDATE FOXSched SET ProcessAddFG = 'ADDINVENTORY' WHERE ProcessStep = @MaxStep AND FOXNumber = @FOXNumber; INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, 'FOX FINISHED GOODS STEP CHANGED', @AuditAmount, @AuditReferenceNumber, 'FOX # ' + Cast(@FOXNumber as varchar(10)) + ' Process Step # ' + Cast(@MaxStep as varchar(5)) + ' Process ID # ' + @MaxProcessID + ' added as finished goods step', @DivisionID); IF (@ProductionNumber <> 0) UPDATE FOXProductionNumberSched SET ProcessAddFG = 'ADDINVENTORY' WHERE FOXNumber = @FOXnumber AND ProcessStep = @MaxStep AND ProductionNumber = @ProductionNumber; END END"


            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(lblFOXNumber.Text)
            cmd.Parameters.Add("@ProcessStep", SqlDbType.VarChar).Value = dgvFOXRouting.Rows(currentRow).Cells("ProcessStep").Value
            cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = dgvFOXRouting.Rows(currentRow).Cells("ProcessID").Value
            ''Audit trail parameters
            cmd.Parameters.Add("@AuditDate", SqlDbType.Date).Value = Now
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            cmd.Parameters.Add("@AuditType", SqlDbType.VarChar).Value = "FOX "
            cmd.Parameters.Add("@AuditAmount", SqlDbType.Float).Value = Val(dgvFOXRouting.Rows(currentRow).Cells("ProcessStep").Value)
            cmd.Parameters.Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(lblFOXNumber.Text)
            cmd.Parameters.Add("@AuditComment", SqlDbType.VarChar).Value = "FOX # " + lblFOXNumber.Text + " Process Step # " + dgvFOXRouting.Rows(currentRow).Cells("ProcessStep").Value.ToString() + " Process ID # " + dgvFOXRouting.Rows(currentRow).Cells("ProcessID").Value.ToString()

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Clear text boxes
            LoadFOXSched()
            ''check to make sure that there are rows in the DGV before trying to select current cell
            If dgvFOXRouting.Rows.Count > 0 Then
                If currentRow <= dgvFOXRouting.Rows.Count - 1 Then
                    dgvFOXRouting.CurrentCell = dgvFOXRouting.Rows(currentRow).Cells(currentColumn)
                Else
                    If dgvFOXRouting.Rows.Count > 0 Then
                        dgvFOXRouting.CurrentCell = dgvFOXRouting.Rows(currentRow - 1).Cells(currentColumn)
                    End If
                End If
            End If
        End If
    End Sub

    Private Function canDeleteProcess()
        If dgvFOXRouting.CurrentCell Is Nothing Then
            MessageBox.Show("You must select a Process Step to Delete", "Select a Process Step", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dgvFOXRouting.Focus()
            Return False
        End If
        If dgvFOXRouting.CurrentCell.RowIndex = -1 Then
            MessageBox.Show("You must select a valid Process Step", "Select a valid Process Step", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dgvFOXRouting.Focus()
            Return False
        End If
        ''Declaring production number
        cmd = New SqlCommand("DECLARE @ProductionNumber as int = CASE WHEN EXISTS(SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') THEN (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') ELSE (SELECT 0) END;", con)
        ''Checking to make sure its a valid production number and if it is counting how many lines have been posted to time slips for the given fox, process Step and production number
        cmd.CommandText += " IF (@ProductionNumber <> 0) SELECT Count(TimeSlipKey) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND FOXStep >= @FOXStep ELSE SELECT 0;"

        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(lblFOXNumber.Text)
        cmd.Parameters.Add("@FOXStep", SqlDbType.Int).Value = Val(dgvFOXRouting.Rows(dgvFOXRouting.CurrentCell.RowIndex).Cells("ProcessStep").Value)

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() > 0 Then
            con.Close()
            MessageBox.Show("There has been production ran on the step or steps after the one you are trying to delete.", "Unable to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If MessageBox.Show("Do you wish to delete the process step?", "DELETE DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub dgvFOXRouting_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFOXRouting.CellValueChanged
        If canSaveProcessChanges() Then

            If dgvFOXRouting.Columns(e.ColumnIndex).Name.Equals("ProcessID") Or dgvFOXRouting.Columns(e.ColumnIndex).Name.Equals("ProcessAddFG") Then
                If dgvFOXRouting.Columns(e.ColumnIndex).Name.Equals("ProcessAddFG") Then
                    Dim FinishedGoods As String = "NO"
                    If dgvFOXRouting.Rows(e.RowIndex).Cells("ProcessAddFG").Value.ToString() = "NO" Then
                        Dim addFGFound As Boolean = False
                        For i As Integer = 0 To dgvFOXRouting.Rows.Count - 1
                            If dgvFOXRouting.Rows(i).Cells("ProcessAddFG").Value.ToString.Equals("ADDINVENTORY") Then
                                addFGFound = True
                            End If
                        Next

                        If Not addFGFound Then
                            isLoaded = False
                            dgvFOXRouting.Rows(e.RowIndex).Cells("ProcessAddFG").Value = "ADDINVENTORY"
                            isLoaded = True
                            cmd = New SqlCommand("DECLARE @ProductionNumber as int = CASE WHEN EXISTS(SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') THEN (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') ELSE (SELECT 0) END; Update FoxSched SET ProcessAddFG = 'NO' WHERE FOXNumber = @FOXNumber; Update FoxProductionNumberSched SET ProcessAddFG = 'NO' WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber;", con)

                            FinishedGoods = "ADDINVENTORY"
                            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(lblFOXNumber.Text)

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                        End If
                    Else
                        cmd = New SqlCommand("DECLARE @DivisionID as varchar(50) = (SELECT DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber), @ProductionNumber as int = CASE WHEN EXISTS(SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') THEN (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') ELSE (SELECT 0) END; Update FoxSched SET ProcessAddFG = 'NO' WHERE FOXNumber = @FOXNumber; Update FoxProductionNumberSched SET ProcessAddFG = 'NO' WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber;", con)
                        ''Adds Audit trail entry for finished goods.
                        cmd.CommandText += "  INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID);"

                        FinishedGoods = "ADDINVENTORY"
                        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(lblFOXNumber.Text)
                        cmd.Parameters.Add("@AuditDate", SqlDbType.Date).Value = Now
                        cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        cmd.Parameters.Add("@AuditType", SqlDbType.VarChar).Value = "FOX FINISHED GOODS STEP ADDED"
                        cmd.Parameters.Add("@AuditAmount", SqlDbType.Float).Value = Val(dgvFOXRouting.Rows(e.RowIndex).Cells("ProcessStep").Value)
                        cmd.Parameters.Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(lblFOXNumber.Text)
                        cmd.Parameters.Add("@AuditComment", SqlDbType.VarChar).Value = "FOX #" + lblFOXNumber.Text + " Process Step # " + dgvFOXRouting.Rows(e.RowIndex).Cells("ProcessStep").Value.ToString() + " Machine # " + dgvFOXRouting.Rows(e.RowIndex).Cells("ProcessID").Value.ToString() + " now adds to finished goods."

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                    End If
                End If

                isLoaded = False
                If Val(dgvFOXRouting.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString) <> 0 Then
                    While dgvFOXRouting.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Length <> 3
                        dgvFOXRouting.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0" + dgvFOXRouting.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
                    End While
                Else
                    dgvFOXRouting.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dgvFOXRouting.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.ToUpper()
                End If

                cmd = New SqlCommand("DECLARE @DivisionID as varchar(50) = (SELECT DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber), @ProductionNumber as int = CASE WHEN EXISTS(SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') THEN (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') ELSE (SELECT 0) END;", con)
                cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = dgvFOXRouting.Rows(e.RowIndex).Cells("ProcessID").Value
                cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(lblFOXNumber.Text)
                cmd.Parameters.Add("@ProcessStep", SqlDbType.Int).Value = dgvFOXRouting.Rows(e.RowIndex).Cells("ProcessStep").Value
                cmd.Parameters.Add("@ProcessAddFG", SqlDbType.VarChar).Value = dgvFOXRouting.Rows(e.RowIndex).Cells("ProcessAddFG").Value

                If Not dgvFOXRouting.Columns(e.ColumnIndex).Name.Equals("ProcessAddFG") Then
                    ''Adds Audit Trail entry
                    cmd.CommandText += "  DECLARE @OriginalData as varchar(100) = (SELECT 'FOX # ' + Cast(@FOXNumber as Varchar(10)) + ' Process Step # ' + Cast(ProcessStep as varchar(5)) + ' Process ID # ' + ProcessID + ' changed to ' FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep); INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) VALUES (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @OriginalData + @AuditComment, @DivisionID);"

                    cmd.Parameters.Add("@AuditDate", SqlDbType.Date).Value = Now
                    cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    cmd.Parameters.Add("@AuditType", SqlDbType.VarChar).Value = "FOX FINISHED GOODS STEP ADDED"
                    cmd.Parameters.Add("@AuditAmount", SqlDbType.Float).Value = Val(dgvFOXRouting.Rows(e.RowIndex).Cells("ProcessStep").Value)
                    cmd.Parameters.Add("@AuditReferenceNumber", SqlDbType.Int).Value = Val(lblFOXNumber.Text)
                    cmd.Parameters.Add("@AuditComment", SqlDbType.VarChar).Value = " Process Step # " + dgvFOXRouting.Rows(e.RowIndex).Cells("ProcessStep").Value.ToString() + " Process ID # " + dgvFOXRouting.Rows(e.RowIndex).Cells("ProcessID").Value.ToString()
                End If

                cmd.CommandText += "  UPDATE FOXSched SET ProcessID = @ProcessID, ProcessAddFG = @ProcessAddFG WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep;  IF @ProductionNumber <> 0 UPDATE FOXProductionNumberSched SET ProcessAddFG = @ProcessAddFG, ProcessID = @ProcessID WHERE ProductionNumber = @ProductionNumber AND FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep;"
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                LoadFOXSched()
                If con.State = ConnectionState.Open Then con.Close()
                dgvFOXRouting.ClearSelection()
                dgvFOXRouting.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
                dgvFOXRouting.CurrentCell = dgvFOXRouting.Rows(e.RowIndex).Cells(e.ColumnIndex)
                isLoaded = True
            End If
        End If
    End Sub
    Private Function canSaveProcessChanges() As Boolean
        If Not isLoaded Then
            Return False
        End If
        If dgvFOXRouting.Rows.Count = 0 Then
            MessageBox.Show("There are no processes to save.", "Enter a process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProcessStep.Focus()
            Return False
        End If
        For i As Integer = 0 To dgvFOXRouting.RowCount - 1
            ''check to make sure the value entered is valid for machine ID
            If Not machineIDCheck.Contains(dgvFOXRouting.Rows(i).Cells("ProcessID").Value.ToString()) Then
                If Not machineIDCheck.Contains(dgvFOXRouting.Rows(i).Cells("ProcessID").Value.ToString().ToUpper()) Then
                    MessageBox.Show("Process ID " + dgvFOXRouting.Rows(i).Cells("ProcessID").Value.ToString() + " for step #" + dgvFOXRouting.Rows(i).Cells("ProcessStep").Value.ToString() + " is not a valid Process ID. Check the Process ID and try again", "Invalid Process ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dgvFOXRouting.Focus()
                    dgvFOXRouting.CurrentCell = dgvFOXRouting.Rows(i).Cells("ProcessID")
                    Return False
                Else
                    dgvFOXRouting.Rows(i).Cells("ProcessID").Value = dgvFOXRouting.Rows(i).Cells("ProcessID").Value.ToString.ToUpper
                End If

            End If
        Next
        Return True
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub dgvFOXRouting_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvFOXRouting.VisibleChanged
        For i As Integer = 0 To dgvFOXRouting.Rows.Count - 1
            Dim chkbx As New DataGridViewCheckBoxCell
            chkbx.TrueValue = "ADDINVENTORY"
            chkbx.FalseValue = "NO"

            chkbx.Value = dgvFOXRouting.Rows(i).Cells("ProcessAddFG").Value
            dgvFOXRouting.Rows(i).Cells("ProcessAddFG") = chkbx
        Next
    End Sub

    Private Sub dgvFOXRouting_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFOXRouting.CellContentClick
        If dgvFOXRouting.Columns(e.ColumnIndex).DataPropertyName.Equals("ProcessAddFG") Then
            dgvFOXRouting.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
End Class