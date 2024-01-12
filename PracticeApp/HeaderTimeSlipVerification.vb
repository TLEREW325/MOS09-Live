Imports System.Data.SqlClient
Imports System
Public Class HeaderTimeSlipVerification
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim ds As DataSet
    Dim adapt As New SqlDataAdapter
    Dim isloaded As Boolean = False
    Const constLabor As Double = 20

    ''NEEDS COMMENTED OUT
    ''Dim EmployeeCompanyCode As String = "TWD"


    Private Sub HeaderTimeSlipVerification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadHeaderTimeSlipEntries()
        isloaded = True
    End Sub

    Private Sub loadHeaderTimeSlipEntries()
        ds = New DataSet
        cmd = New SqlCommand("SELECT Shift, EmployeeID, PostingDate, MachineNumber, FOXNumber, PartNumber, MachineHours, SetupHours, ToolingHours, OtherHours, TotalHours, PiecesProduced, LineWeight, ScrapWeight, TimeSlipKey, LineKey, RMID, InventoryPieces FROM TimeSlipCombinedData WHERE Status = 'HEAD'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        adapt.SelectCommand = cmd
        adapt.Fill(ds, "TimeSlipCombinedData")
        con.Close()

        dgvHeaderTimeSLipEntries.DataSource = ds.Tables("TimeSlipCombinedData")
        dgvHeaderTimeSLipEntries.Columns("TimeSlipKey").Visible = False
        dgvHeaderTimeSLipEntries.Columns("LineKey").Visible = False
        dgvHeaderTimeSLipEntries.Columns("RMID").Visible = False
        dgvHeaderTimeSLipEntries.Columns("InventoryPieces").Visible = False
        dgvHeaderTimeSLipEntries.Columns("EmployeeID").ReadOnly = True
        dgvHeaderTimeSLipEntries.Columns("EmployeeID").HeaderText = "Employee ID"
        dgvHeaderTimeSLipEntries.Columns("PostingDate").ReadOnly = True
        dgvHeaderTimeSLipEntries.Columns("PostingDate").HeaderText = "Posting Date"
        dgvHeaderTimeSLipEntries.Columns("MachineNumber").ReadOnly = True
        dgvHeaderTimeSLipEntries.Columns("MachineNumber").HeaderText = "Machine #"
        dgvHeaderTimeSLipEntries.Columns("FOXNumber").ReadOnly = True
        dgvHeaderTimeSLipEntries.Columns("FOXNumber").HeaderText = "FOX #"
        dgvHeaderTimeSLipEntries.Columns("PartNumber").ReadOnly = True
        dgvHeaderTimeSLipEntries.Columns("PartNumber").HeaderText = "Part #"
        dgvHeaderTimeSLipEntries.Columns("TotalHours").ReadOnly = True
        dgvHeaderTimeSLipEntries.Columns("TotalHours").HeaderText = "Total Hours"
        dgvHeaderTimeSLipEntries.Columns("LineWeight").ReadOnly = True
        dgvHeaderTimeSLipEntries.Columns("LineWeight").HeaderText = "Line Weight"
        dgvHeaderTimeSLipEntries.Columns("MachineHours").HeaderText = "Machine Hours"
        dgvHeaderTimeSLipEntries.Columns("SetupHours").HeaderText = "Setup Hours"
        dgvHeaderTimeSLipEntries.Columns("ToolingHours").HeaderText = "Tooling Hours"
        dgvHeaderTimeSLipEntries.Columns("OtherHours").HeaderText = "Other Hours"
        dgvHeaderTimeSLipEntries.Columns("PiecesProduced").HeaderText = "Pieces Produced"
        dgvHeaderTimeSLipEntries.Columns("ScrapWeight").HeaderText = "Scrap Weight"
    End Sub

    Private Sub dgvHeaderTimeSLipEntries_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHeaderTimeSLipEntries.CellValueChanged
        If isloaded Then
            isloaded = False
            Dim currentRow As Integer = dgvHeaderTimeSLipEntries.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvHeaderTimeSLipEntries.CurrentCell.ColumnIndex
            Dim totalHours As Double = 0.0
            If IsDBNull(dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("MachineHours").Value) = False Then
                totalHours += dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("MachineHours").Value
            Else
                dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("MachineHours").Value = 0.0
            End If
            If IsDBNull(dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("SetupHours").Value) = False Then
                totalHours += dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("SetupHours").Value
            Else
                dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("SetupHours").Value = 0.0
            End If
            If IsDBNull(dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("ToolingHours").Value) = False Then
                totalHours += dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("ToolingHours").Value
            Else
                dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("ToolingHours").Value = 0.0
            End If
            If IsDBNull(dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("OtherHours").Value) = False Then
                totalHours += dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("OtherHours").Value
            Else
                dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("OtherHours").Value = 0.0
            End If

            cmd = New SqlCommand("SELECT RawMaterialWeight FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("FOXNumber").Value
            If con.State = ConnectionState.Closed Then con.Open()
            Dim perthou As Double = cmd.ExecuteScalar()
            con.Close()
            perthou = perthou / 1000
            Dim totalWeight As Double = 0.0
            If IsDBNull(dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("PiecesProduced").Value) = False Then
                totalWeight = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("PiecesProduced").Value * perthou
            Else
                dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("PiecesProduced").Value = 0.0
            End If
            If currentColumn = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("Shift").ColumnIndex Then
                cmd = New SqlCommand("UPDATE TimeSlipHeaderTable SET Shift = @Shift WHERE TimeSlipKey = @TimeSlipKey", con)
                With cmd.Parameters
                    .Add("@Shift", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("Shift").Value
                    .Add("@TimeSlipKey", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("TimeSlipKey").Value
                End With
            Else
                cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET Shift = @Shift, MachineHours = @MachineHours, SetupHours = @SetupHours, ToolingHours = @ToolingHours, OtherHours = @OtherHours, TotalHours = @TotalHours, PiecesProduced = @PiecesProduced, LineWeight = @LineWeight, ScrapWeight = @ScrapWeight WHERE LineKey = @LineKey AND TimeSlipKey = @TimeSlipKey", con)
                With cmd.Parameters
                    .Add("@MachineHours", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("MachineHours").Value
                    .Add("@SetupHours", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("SetupHours").Value
                    .Add("@ToolingHours", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("ToolingHours").Value
                    .Add("@OtherHours", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("OtherHours").Value
                    .Add("@TotalHours", SqlDbType.VarChar).Value = totalHours
                    .Add("@PiecesProduced", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("PiecesProduced").Value
                    .Add("@LineWeight", SqlDbType.VarChar).Value = totalWeight
                    .Add("@ScrapWeight", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("ScrapWeight").Value
                    .Add("@LineKey", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("LineKey").Value
                    .Add("@TimeSlipKey", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells("TimeSlipKey").Value
                End With
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            loadHeaderTimeSlipEntries()
            isloaded = True
            dgvHeaderTimeSLipEntries.CurrentCell = dgvHeaderTimeSLipEntries.Rows(currentRow).Cells(currentColumn)
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPost.Click
        If canPost() Then

            'Extract Data from Datagrid
            For i As Integer = 0 To dgvHeaderTimeSLipEntries.Rows.Count - 1

                Dim cell As DataGridViewTextBoxCell = dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey")

                Dim LineKey As Integer = dgvHeaderTimeSLipEntries.Rows(i).Cells("LineKey").Value
                Dim FOXNumber As String = dgvHeaderTimeSLipEntries.Rows(i).Cells("FOXNumber").Value
                Dim PartNumber As String = dgvHeaderTimeSLipEntries.Rows(i).Cells("PartNumber").Value
                Dim MachineNumber As String = dgvHeaderTimeSLipEntries.Rows(i).Cells("MachineNumber").Value
                Dim MachineHours As Double = dgvHeaderTimeSLipEntries.Rows(i).Cells("MachineHours").Value
                Dim SetupHours As Double = dgvHeaderTimeSLipEntries.Rows(i).Cells("SetupHours").Value
                Dim ToolingHours As Double = dgvHeaderTimeSLipEntries.Rows(i).Cells("ToolingHours").Value
                Dim OtherHours As Double = dgvHeaderTimeSLipEntries.Rows(i).Cells("OtherHours").Value
                Dim TotalHours As Double = dgvHeaderTimeSLipEntries.Rows(i).Cells("TotalHours").Value
                Dim PiecesProduced As Integer = dgvHeaderTimeSLipEntries.Rows(i).Cells("PiecesProduced").Value
                Dim LineWeight As Double = dgvHeaderTimeSLipEntries.Rows(i).Cells("LineWeight").Value
                Dim ScrapWeight As Double = dgvHeaderTimeSLipEntries.Rows(i).Cells("ScrapWeight").Value
                Dim InventoryPieces As Integer = dgvHeaderTimeSLipEntries.Rows(i).Cells("InventoryPieces").Value
                Dim RMID As String = dgvHeaderTimeSLipEntries.Rows(i).Cells("RMID").Value

                Dim addFG, division As String
                cmd = New SqlCommand("SELECT ProcessAddFG, FOXTable.DivisionID FROM FoxSched LEFT OUTER JOIN FOXTable on FoxSched.FOXNumber = FOXTable.FOXNumber WHERE FoxSched.FoxNumber = @FOXNumber AND ProcessID = @ProcessID", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
                cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = MachineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.GetValue(0)) Then
                        addFG = "NO"
                    Else
                        addFG = reader.GetValue(0)
                    End If
                    If IsDBNull(reader.GetValue(1)) Then
                        division = "TWD"
                    Else
                        division = reader.GetValue(1)
                    End If
                Else
                    reader.Close()
                    con.Close()

                    Dim procStep As Integer = getStep(FOXNumber, MachineNumber)
                    If procStep = 0 Then
                        addFG = "NO"
                        division = "TWD"
                    Else
                        cmd = New SqlCommand("SELECT ProcessAddFG, FOXTable.DivisionID FROM FoxSched LEFT OUTER JOIN FOXTable on FoxSched.FOXNumber = FOXTable.FOXNumber WHERE FoxSched.FoxNumber = @FOXNumber AND ProcessStep = @ProcessStep", con)
                        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
                        cmd.Parameters.Add("@ProcessStep", SqlDbType.VarChar).Value = procStep
                        If con.State = ConnectionState.Closed Then con.Open()
                        reader = cmd.ExecuteReader()
                        reader.Read()

                        If IsDBNull(reader.GetValue(0)) Then
                            addFG = "NO"
                        Else
                            addFG = reader.GetValue(0)
                        End If
                        If IsDBNull(reader.GetValue(1)) Then
                            division = "TWD"
                        Else
                            division = reader.GetValue(1)
                        End If
                    End If
                End If
                reader.Close()
                con.Close()
                'Extract the Machine Cost
                Dim MachineCost As Double

                Dim MachineCostStatement As String = "SELECT MachineCostPerHour FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = @DivisionID"
                Dim MachineCostCommand As New SqlCommand(MachineCostStatement, con)
                MachineCostCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = MachineNumber
                MachineCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MachineCost = CDbl(MachineCostCommand.ExecuteScalar)
                Catch ex As Exception
                    MachineCost = 0
                End Try
                con.Close()
                '**********************************
                'Write to General Ledger -- MACHINE COST
                '**********************************
                Try
                    'Write Values to General Ledger (CREDIT)
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, (SELECT isnull(MAX(GLBatchNumber), 220001) FROM GLTransactionMasterList), @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)
                    With cmd.Parameters
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = 60099
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Time Slip Posting"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = Today()
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = MachineCost
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Machining Cost for FOX #" + dgvHeaderTimeSLipEntries.Rows(i).Cells("FOXNumber").Value.ToString()
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("LineKey").Value
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
                Catch ex As Exception
                    sendErrorToDataBase("HeaderTimeSlipVerification - cmdPostTimeSlip_Click --Error trying to insert credit into GLTransactionMasterList. Line #" + i.ToString(), "Time slip #" + dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value.ToString(), ex.ToString())
                    MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                '**********************************
                'End of Ledger Entry -- MACHINE COST
                '**********************************
                ''*******************************************************
                ''*CONSTANT HERE FOR ESTIMATED COST PER HOUR OF EMPLOYEE*
                ''*******************************************************
                Dim laborCost As Double = Math.Round(constLabor * Val(dgvHeaderTimeSLipEntries.Rows(i).Cells("TotalHours").Value), 2)

                '**********************************
                'Write to General Ledger -- LABOR COST
                '**********************************
                Try
                    'Write Values to General Ledger (CREDIT)
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, (SELECT isnull(MAX(GLBatchNumber), 220001) FROM GLTransactionMasterList), @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)
                    With cmd.Parameters
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = 60000
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Time Slip Posting"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = Today()
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = laborCost
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Labor Cost for FOX #" + dgvHeaderTimeSLipEntries.Rows(i).Cells("FOXNumber").Value.ToString()
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("LineKey").Value
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
                Catch ex As Exception
                    sendErrorToDataBase("HeaderTimeSlipVerification - cmdPostTimeSlip_Click --Error trying to insert credit into GLTransactionMasterList. Line #" + i.ToString(), "Time slip #" + dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value.ToString(), ex.ToString())
                    MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                '**********************************
                'End of Ledger Entry -- LABOR COST
                '**********************************
                Dim GLLinePostAmount As Double = laborCost + (MachineCost * dgvHeaderTimeSLipEntries.Rows(i).Cells("TotalHours").Value)
                If addFG = "ADDINVENTORY" And dgvHeaderTimeSLipEntries.Rows(i).Cells("PiecesProduced").Value <> 0 Then

                    Dim weight As Double = dgvHeaderTimeSLipEntries.Rows(i).Cells("LineWeight").Value

                    Dim TSRawMaterialCost As Double = 0.0
                    Dim SteelCost As Double = 0.0
                    cmd = New SqlCommand("SELECT ((SELECT SUM(TotalHours) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber)/SUM(PiecesProduced)), (SELECT FinishedWeight / 1000 FROM FOXTable WHERE FOXNumber = @FOXNumber), (SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT SUM(UsageWeight) FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED') BETWEEN LowerLimit AND UpperLimit + 1) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber", con)
                    cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("FOXNumber").Value
                    cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("RMID").Value

                    Dim partTime As Double = 0.0
                    Dim partWeight As Double = 0.0
                    If con.State = ConnectionState.Closed Then con.Open()
                    reader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.GetValue(0)) = False Then
                            partTime = reader.GetValue(0)
                        End If
                        If IsDBNull(reader.GetValue(1)) = False Then
                            partWeight = reader.GetValue(1)
                        End If
                        If IsDBNull(reader.GetValue(2)) = False Then
                            SteelCost = reader.GetValue(2)
                        End If
                    End If
                    reader.Close()
                    con.Close()

                    ''calculates the machineOverhead, the laborCost and steel cost for the part then adds them together for the GL posting and the adding to inventory
                    GLLinePostAmount = Math.Round((dgvHeaderTimeSLipEntries.Rows(i).Cells("PiecesProduced").Value * partTime * MachineCost) + (dgvHeaderTimeSLipEntries.Rows(i).Cells("PiecesProduced").Value * partTime * constLabor) + (dgvHeaderTimeSLipEntries.Rows(i).Cells("PiecesProduced").Value * partWeight * SteelCost), 2)

                    Dim GLFirstAccount As String = ""
                    Dim GLSecondAccount As String = ""
                    ''updates the timeSlip line
                    updateTimeSlipLineItem(i, GLLinePostAmount)

                    isloaded = False
                    dgvHeaderTimeSLipEntries.Rows(i).Cells("InventoryPieces").Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("PiecesProduced").Value
                    isloaded = True

                    addToInventoryCosting(i, GLLinePostAmount, division)
                    GLSecondAccount = "12800"
                    If division = "TFP" Then
                        GLFirstAccount = "12500"
                    Else
                        GLFirstAccount = "12100"
                    End If
                    addToInventoryTransaction(i, GLFirstAccount, division)

                    '**********************************
                    'Write to General Ledger
                    '**********************************

                    Try
                        'Write Values to General Ledger (DEBIT)
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList), @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)
                        With cmd.Parameters
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLFirstAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Time Slip Posting"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = Today()
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = GLLinePostAmount
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Adding Inventory for FOX #" + dgvHeaderTimeSLipEntries.Rows(i).Cells("FOXNumber").Value.ToString()
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("LineKey").Value
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
                    Catch ex As Exception
                        sendErrorToDataBase("HeaderTimeSlipVerification - cmdPostTimeSlip_Click --Error trying to insert debit into GLTransactionMasterLoist. Line #" + i.ToString(), "Time slip #" + dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value.ToString(), ex.ToString())
                        MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try

                    Try
                        'Write Values to General Ledger (CREDIT)
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, (SELECT isnull(MAX(GLBatchNumber), 220001) FROM GLTransactionMasterList), @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)
                        With cmd.Parameters
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLSecondAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Time Slip Posting"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = Today()
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = GLLinePostAmount
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Adding Inventory for FOX #" + dgvHeaderTimeSLipEntries.Rows(i).Cells("FOXNumber").Value.ToString()
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("LineKey").Value
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
                    Catch ex As Exception
                        sendErrorToDataBase("HeaderTimeSlipVerification - cmdPostTimeSlip_Click --Error trying to insert credit into GLTransactionMasterList. Line #" + i.ToString(), "Time slip #" + dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value.ToString(), ex.ToString())
                        MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try

                    '**********************************
                    'End of Ledger Entry
                    '**********************************
                Else
                    updateTimeSlipLineItem(i, GLLinePostAmount)
                End If
                'UPDATE Time Slip Header to show POSTED Status
                cmd = New SqlCommand("UPDATE TimeSlipHeaderTable SET Status = @Status WHERE TimeSlipKey = @TimeSlipKey", con)
                With cmd.Parameters
                    .Add("@TimeSlipKey", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value
                    .Add("@Status", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next

            loadHeaderTimeSlipEntries()
            MsgBox("Time Slip has been posted.", MsgBoxStyle.OkOnly)

        End If
    End Sub

    Private Function canPost() As Boolean
        For i As Integer = 0 To dgvHeaderTimeSLipEntries.Rows.Count - 1
            If IsDBNull(dgvHeaderTimeSLipEntries.Rows(i).Cells("Shift").Value) Then
                MessageBox.Show("You must enter a Shift number for each line.", "Enter a Shift number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgvHeaderTimeSLipEntries.CurrentCell = dgvHeaderTimeSLipEntries.Rows(i).Cells("Shift")
                dgvHeaderTimeSLipEntries.Focus()
                Return False
            End If
        Next
        Return True
    End Function
    ''updates inventory costing teirs and  updates the timeslip line with the info
    Private Sub addToInventoryCosting(ByVal i As Integer, ByVal steelCost As Double, ByVal division As String)
        'Extract the Upper and Lower Limit of the Inventory Costing Table
        Dim NewUpperLimit, LowerLimit, UpperLimit As Integer

        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = (SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID)"
        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("PartNumber").Value
        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UpperLimit = CInt(UpperLimitCommand.ExecuteScalar)
        Catch ex As Exception
            UpperLimit = 0
        End Try
        con.Close()

        'Calculate the NEW Lower/Upper Limit for the next post
        LowerLimit = UpperLimit + 1
        NewUpperLimit = LowerLimit + Val(dgvHeaderTimeSLipEntries.Rows(i).Cells("InventoryPieces").Value)

        Try
            'Write Values to Inventory Costing Table
            cmd = New SqlCommand("Insert Into InventoryCosting (TransactionNumber, PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, ReferenceNumber, ReferenceLine)values((SELECT isnull(MAX(TransactionNumber) + 1, 63000001) FROM InventoryCosting),@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @ReferenceNumber, @ReferenceLine)", con)
            With cmd.Parameters
                .Add("@PartNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("PartNumber").Value
                .Add("@DivisionID", SqlDbType.VarChar).Value = division
                .Add("@CostingDate", SqlDbType.VarChar).Value = Today()
                .Add("@ItemCost", SqlDbType.VarChar).Value = steelCost
                .Add("@CostQuantity", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("InventoryPieces").Value
                .Add("@Status", SqlDbType.VarChar).Value = "TIME SLIP"
                .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value
                .Add("@ReferenceLine", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("LineKey").Value
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            sendErrorToDataBase("HeaderTimeSlipVerification - addToInventoryCosting --Error trying to insert into InventoryCosting", "Part #" + dgvHeaderTimeSLipEntries.Rows(i).Cells("PartNumber").Value, ex.ToString())
            MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    ''adds the entry into the inventory transaction table
    Private Sub addToInventoryTransaction(ByVal i As Integer, ByVal GLAccount As String, ByVal division As String)
        ''adds the entry into the InventoryTransactionTable
        Dim test As String = dgvHeaderTimeSLipEntries.Rows(i).Cells("LineKey").Value
        cmd = New SqlCommand("INSERT INTO InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ExtendedCost, ItemPrice, ExtendedAmount, DivisionID, TransactionMath, GLAccount) VALUES((SELECT isnull(MAX(TransactionNumber) + 1, 867500001) FROM InventoryTransactionTable), @TransactionDate, 'Post Production', @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, (SELECT ShortDescription FROM ItemList WHERE ItemID = @PartNumber AND (DivisionID = 'TWD' OR DivisionID = 'TFP')), (SELECT InventoryPieces FROM TimeSlipLineItemTable WHERE TimeSlipKey = @TransactionTypeNumber AND LineKey = @TransactionTypeLineNumber), (SELECT Cost FROM TimeSlipLineItemTable WHERE TimeSlipKey = @TransactionTypeNumber AND LineKey = @TransactionTypeLineNumber), (SELECT ExtendedCost FROM TimeSlipLineItemTable WHERE TimeSlipKey = @TransactionTypeNumber AND LineKey = @TransactionTypeLineNumber), @ItemPrice, @ExtendedAmount, @DivisionID, 'ADD', @GLAccount)", con)
        With cmd.Parameters
            .Add("@TransactionDate", SqlDbType.VarChar).Value = Today
            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value
            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("LineKey").Value
            .Add("@PartNumber", SqlDbType.VarChar).Value = dgvHeaderTimeSLipEntries.Rows(i).Cells("PartNumber").Value
            .Add("@ItemPrice", SqlDbType.VarChar).Value = "0"
            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = "0"
            .Add("@DivisionID", SqlDbType.VarChar).Value = division
            .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division)", con)
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

    Private Sub updateTimeSlipLineItem(ByVal i As Integer, ByVal GLLineCost As Double)
        cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET InventoryPieces = @InventoryPieces, ExtendedCost = @ExtendedCost, Cost = @Cost WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey", con)
        cmd.Parameters.Add("@InventoryPieces", SqlDbType.Float).Value = Val(dgvHeaderTimeSLipEntries.Rows(i).Cells("PiecesProduced").Value)
        cmd.Parameters.Add("@ExtendedCost", SqlDbType.Float).Value = GLLineCost
        If Val(dgvHeaderTimeSLipEntries.Rows(i).Cells("PiecesProduced").Value) <> 0 Then
            cmd.Parameters.Add("@Cost", SqlDbType.VarChar).Value = Math.Round(GLLineCost / Val(dgvHeaderTimeSLipEntries.Rows(i).Cells("PiecesProduced").Value), 2)
        Else
            cmd.Parameters.Add("@Cost", SqlDbType.VarChar).Value = 0
        End If
        cmd.Parameters.Add("@TimeSlipKey", SqlDbType.VarChar).Value = Val(dgvHeaderTimeSLipEntries.Rows(i).Cells("TimeSlipKey").Value)
        cmd.Parameters.Add("@LineKey", SqlDbType.VarChar).Value = i + 1

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Function getStep(ByVal FOX As String, ByVal Machine As String) As Integer
        cmd = New SqlCommand("SELECT MachineClass, ProcessStep FROM MachineTable RIGHT OUTER JOIN FOXSched ON ProcessID = MachineID WHERE DivisionID = 'TWD' AND FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOX
        Dim cla As New List(Of String)
        Dim steps As New List(Of Integer)
        Dim currClass As String = ""
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If IsDBNull(reader.GetValue(0)) = False Then
                    cla.Add(reader.GetValue(0))
                    steps.Add(reader.GetValue(1))
                End If
            End While
        End If
        reader.Close()

        cmd = New SqlCommand("SELECT MachineClass FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = 'TWD'", con)
        cmd.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = Machine
        If con.State = ConnectionState.Closed Then con.Open()

        Try
            currClass = cmd.ExecuteScalar()
        Catch ex As Exception

        End Try
        con.Close()
        Dim i As Integer = 0
        While i < cla.Count
            If cla(i).Equals(currClass) Then
                Return steps(i)
            End If
            i += 1
        End While
        Return 0
    End Function
End Class
