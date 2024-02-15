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
Imports System.ComponentModel
Public Class TimeSlipPosting
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim adapt, myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As DataSet
    Dim isloaded As Boolean = False
    Const constLabor As Double = 28

    Dim postingErrors As Boolean = False

    Public Sub New()
        InitializeComponent()
        loadTimeSlipEntries()
        isloaded = True
        If dgvTimeSlipEntries.Rows.Count > 0 Then
            cmdPost.Enabled = True
            cmdPostSpecial.Enabled = True
        End If
        usefulFunctions.LoadSecurity(Me)
    End Sub

    Private Sub loadTimeSlipEntries()
        Dim tempIsLoaded = isloaded
        isloaded = False
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As SqlCommand
        ds = New DataSet
        cmd = New SqlCommand("SELECT MachineNumber, TimeSlipLineItemTable.FOXNumber, EmployeeID, EmployeeName, TotalHours, Carbon, SteelSize, LineWeight, PiecesProduced, PostingDate, PartNumber, MachineHours, SetupHours, ToolingHours, OtherHours, ScrapWeight, TimeSlipHeaderTable.TimeSlipKey, TimeSlipLineItemTable.LineKey, TimeSlipLineItemTable.RMID, InventoryPieces, FOXStep, TimeSlipHeaderTable.Shift, TimeSlipLineItemTable.ProductionNumber, FOXProductionNumberSched.ProcessAddFG, ItemList.ItemClass, TimeSlipLineItemTable.OriginalPart, TimeSlipLineItemTable.DivisionID, ItemClass.GLInventoryAccount FROM TimeSlipLineItemTable LEFT OUTER JOIN TimeSlipHeaderTable ON TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey LEFT OUTER JOIN RawMaterialsTable ON TimeSlipLineItemTable.RMID = RawMaterialsTable.RMID LEFT OUTER JOIN FOXProductionNumberSched ON TimeSlipLineItemTable.FOXNumber = FOXProductionNumberSched.FOXNumber AND TimeSlipLineItemTable.ProductionNumber = FOXProductionNumberSched.ProductionNumber AND TimeSlipLineItemTable.FOXStep = FOXProductionNumberSched.ProcessStep LEFT OUTER JOIN ItemList ON TimeSlipLineItemTable.PartNumber = ItemList.ItemID AND TimeSlipLineItemTable.DivisionID = ItemList.DivisionID LEFT OUTER JOIN ItemClass ON ItemList.ItemClass = ItemClass.ItemClassID WHERE Status <> 'POSTED' AND LineKey < 100 and isnull(PostedSpecial, 'False') <> 'True' ORDER BY TimeSlipLineItemTable.TimeSlipKey", con)
        If con.State = ConnectionState.Closed Then con.Open()
        adapt.SelectCommand = cmd
        adapt.Fill(ds, "TimeSlipCombinedData")

        dgvTimeSlipEntries.DataSource = ds.Tables("TimeSlipCombinedData")

        For i As Integer = 0 To dgvTimeSlipEntries.Rows.Count - 1
            ''check to see if we should try and update the process step and check to see if it adds to finished goods
            If dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value = 999 Then
                CheckFOXUnknownStep(i, con)
            End If
            ''check to see if the row needs highlighted
            If dgvTimeSlipEntries.Rows(i).Cells("ProcessAddFG").Value.ToString.Equals("ADDINVENTORY") Then
                dgvTimeSlipEntries.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            ElseIf CheckAddDBAToFG(i, con) Then
                ''will display lines that have a machine of 99 or 98 and are debar of length 12-1/8 or 18-1/8 and FOXs that add to FG from 314 (boxing step) as FG
                dgvTimeSlipEntries.Rows(i).Cells("ProcessAddFG").Value = "ADDINVENTORY"
                dgvTimeSlipEntries.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Next
        If con.State = ConnectionState.Open Then con.Close()

        dgvTimeSlipEntries.Columns("TimeSlipKey").Visible = False
        dgvTimeSlipEntries.Columns("LineKey").Visible = False
        dgvTimeSlipEntries.Columns("RMID").Visible = False
        dgvTimeSlipEntries.Columns("InventoryPieces").Visible = False
        dgvTimeSlipEntries.Columns("EmployeeID").ReadOnly = True
        dgvTimeSlipEntries.Columns("EmployeeID").HeaderText = "Employee ID"
        dgvTimeSlipEntries.Columns("EmployeeName").ReadOnly = True
        dgvTimeSlipEntries.Columns("EmployeeName").HeaderText = "Employee Name"
        dgvTimeSlipEntries.Columns("EmployeeName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvTimeSlipEntries.Columns("Carbon").ReadOnly = True
        dgvTimeSlipEntries.Columns("SteelSize").ReadOnly = True
        dgvTimeSlipEntries.Columns("SteelSize").HeaderText = "Steel Size"
        dgvTimeSlipEntries.Columns("PostingDate").ReadOnly = True
        dgvTimeSlipEntries.Columns("PostingDate").HeaderText = "Posting Date"
        dgvTimeSlipEntries.Columns("MachineNumber").ReadOnly = True
        dgvTimeSlipEntries.Columns("MachineNumber").HeaderText = "Machine #"
        dgvTimeSlipEntries.Columns("FOXNumber").ReadOnly = True
        dgvTimeSlipEntries.Columns("FOXNumber").HeaderText = "FOX #"
        dgvTimeSlipEntries.Columns("PartNumber").ReadOnly = True
        dgvTimeSlipEntries.Columns("PartNumber").HeaderText = "Part #"
        dgvTimeSlipEntries.Columns("TotalHours").ReadOnly = True
        dgvTimeSlipEntries.Columns("TotalHours").HeaderText = "Total Hours"
        dgvTimeSlipEntries.Columns("TotalHours").DefaultCellStyle.Format = "N2"
        dgvTimeSlipEntries.Columns("LineWeight").ReadOnly = True
        dgvTimeSlipEntries.Columns("LineWeight").HeaderText = "Line Weight"
        dgvTimeSlipEntries.Columns("LineWeight").DefaultCellStyle.Format = "N2"
        dgvTimeSlipEntries.Columns("MachineHours").HeaderText = "Machine Hours"
        dgvTimeSlipEntries.Columns("MachineHours").DefaultCellStyle.Format = "N2"
        dgvTimeSlipEntries.Columns("SetupHours").HeaderText = "Setup Hours"
        dgvTimeSlipEntries.Columns("SetupHours").DefaultCellStyle.Format = "N2"
        dgvTimeSlipEntries.Columns("ToolingHours").HeaderText = "Tooling Hours"
        dgvTimeSlipEntries.Columns("ToolingHours").DefaultCellStyle.Format = "N2"
        dgvTimeSlipEntries.Columns("OtherHours").HeaderText = "Other Hours"
        dgvTimeSlipEntries.Columns("OtherHours").DefaultCellStyle.Format = "N2"
        dgvTimeSlipEntries.Columns("PiecesProduced").HeaderText = "Pieces Produced"
        dgvTimeSlipEntries.Columns("ScrapWeight").HeaderText = "Scrap Weight"
        dgvTimeSlipEntries.Columns("ScrapWeight").DefaultCellStyle.Format = "N2"
        dgvTimeSlipEntries.Columns("FOXStep").Visible = False
        dgvTimeSlipEntries.Columns("ProductionNumber").Visible = False
        dgvTimeSlipEntries.Columns("ProcessAddFG").Visible = False
        dgvTimeSlipEntries.Columns("OriginalPart").Visible = False
        dgvTimeSlipEntries.Columns("DivisionID").Visible = False
        dgvTimeSlipEntries.Columns("GLInventoryAccount").Visible = False
        isloaded = tempIsLoaded
    End Sub

    Private Function CheckAddDBAToFG(ByVal i As Integer, ByRef con As SqlConnection) As Boolean
        ''check to see if the part is debar by matching the start of the part number with DBA
        If Not dgvTimeSlipEntries.Rows(i).Cells("PartNumber").Value.ToString.StartsWith("DBA") Then
            Return False
        End If
        ''check to see if the debar is 12-1/8 long andalso check to see if it is 18-1/8 long
        If Not dgvTimeSlipEntries.Rows(i).Cells("PartNumber").Value.ToString.Contains("-194-") AndAlso Not dgvTimeSlipEntries.Rows(i).Cells("PartNumber").Value.ToString.Contains("-290-") Then
            Return False
        End If
        ''check to see if the machine is 099 ANDALSO check to see if the mackine is 098
        If Not dgvTimeSlipEntries.Rows(i).Cells("MachineNumber").Value.ToString.Equals("099") AndAlso Not dgvTimeSlipEntries.Rows(i).Cells("MachineNumber").Value.ToString.Equals("098") AndAlso Not dgvTimeSlipEntries.Rows(i).Cells("MachineNumber").Value.ToString.Equals("097") Then
            Return False
        End If
        ''gets the process that adds the fox to finished goods, if it is not 314 will return false
        Dim cmd = New SqlCommand("SELECT isnull(ProcessID, 'NONE') FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND ProcessAddFG = 'ADDINVENTORY'", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("FOXNumber").Value
        cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("ProductionNumber").Value
        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        If obj IsNot Nothing Then
            If Not obj.ToString.Equals("314") Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub CheckFOXUnknownStep(ByVal i As Integer, ByRef con As SqlConnection)
        Dim cmd = New SqlCommand("SELECT isnull(ProcessStep, 999) as ProcessStep, ProcessAddFG FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND ProcessID = @ProcessID", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("FOXNumber").Value
        cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("ProductionNumber").Value
        cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(i).Cells("MachineNumber").Value

        If con.State = ConnectionState.Closed Then con.Open()
        Dim processStep As Integer = 999
        Dim addFG As String = "NO"
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("ProcessStep")) Then
                processStep = reader.Item("ProcessStep")
            End If
            If Not IsDBNull(reader.Item("ProcessAddFG")) Then
                addFG = reader.Item("ProcessAddFG")
            End If
        End If
        reader.Close()
        If processStep <> 999 Then
            cmd.CommandText = "UPDATE TimeslipLineItemTable SET FOXStep = @FOXStep WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey"
            cmd.Parameters.Add("@FOXStep", SqlDbType.Int).Value = processStep
            cmd.Parameters.Add("@TimeslipKey", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("TimeSlipKey").Value
            cmd.Parameters.Add("@LineKey", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("LineKey").Value

            cmd.ExecuteNonQuery()

            dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value = processStep

            If addFG.Equals("ADDINVENTORY") Then
                dgvTimeSlipEntries.Rows(i).Cells("ProcessAddFG").Value = "ADDINVENTORY"
            End If
        End If
    End Sub

    Private Sub dgvHeaderTimeSLipEntries_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTimeSlipEntries.CellValueChanged
        If isloaded Then
            If dgvTimeSlipEntries.CurrentCell IsNot Nothing Then
                isloaded = False
                Dim currentRow As Integer = dgvTimeSlipEntries.CurrentCell.RowIndex
                Dim currentColumn As Integer = dgvTimeSlipEntries.CurrentCell.ColumnIndex
                Dim totalHours As Double = 0.0
                If IsDBNull(dgvTimeSlipEntries.Rows(currentRow).Cells("MachineHours").Value) = False Then
                    totalHours += dgvTimeSlipEntries.Rows(currentRow).Cells("MachineHours").Value
                Else
                    dgvTimeSlipEntries.Rows(currentRow).Cells("MachineHours").Value = 0.0
                End If
                If IsDBNull(dgvTimeSlipEntries.Rows(currentRow).Cells("SetupHours").Value) = False Then
                    totalHours += dgvTimeSlipEntries.Rows(currentRow).Cells("SetupHours").Value
                Else
                    dgvTimeSlipEntries.Rows(currentRow).Cells("SetupHours").Value = 0.0
                End If
                If IsDBNull(dgvTimeSlipEntries.Rows(currentRow).Cells("ToolingHours").Value) = False Then
                    totalHours += dgvTimeSlipEntries.Rows(currentRow).Cells("ToolingHours").Value
                Else
                    dgvTimeSlipEntries.Rows(currentRow).Cells("ToolingHours").Value = 0.0
                End If
                If IsDBNull(dgvTimeSlipEntries.Rows(currentRow).Cells("OtherHours").Value) = False Then
                    totalHours += dgvTimeSlipEntries.Rows(currentRow).Cells("OtherHours").Value
                Else
                    dgvTimeSlipEntries.Rows(currentRow).Cells("OtherHours").Value = 0.0
                End If
                Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
                Dim cmd As New SqlCommand("SELECT RawMaterialWeight FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(currentRow).Cells("FOXNumber").Value
                If con.State = ConnectionState.Closed Then con.Open()
                Dim perthou As Double = cmd.ExecuteScalar()

                perthou = perthou / 1000
                Dim totalWeight As Double = 0.0

                If IsDBNull(dgvTimeSlipEntries.Rows(currentRow).Cells("PiecesProduced").Value) = False Then
                    totalWeight = dgvTimeSlipEntries.Rows(currentRow).Cells("PiecesProduced").Value * perthou
                Else
                    dgvTimeSlipEntries.Rows(currentRow).Cells("PiecesProduced").Value = 0.0
                End If

                If currentColumn = dgvTimeSlipEntries.Rows(currentRow).Cells("Shift").ColumnIndex Then
                    cmd = New SqlCommand("UPDATE TimeSlipHeaderTable SET Shift = @Shift WHERE TimeSlipKey = @TimeSlipKey", con)
                    With cmd.Parameters
                        .Add("@Shift", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(currentRow).Cells("Shift").Value
                        .Add("@TimeSlipKey", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(currentRow).Cells("TimeSlipKey").Value
                    End With
                Else
                    cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET MachineHours = @MachineHours, SetupHours = @SetupHours, ToolingHours = @ToolingHours, OtherHours = @OtherHours, TotalHours = @TotalHours, PiecesProduced = @PiecesProduced, LineWeight = @LineWeight, ScrapWeight = @ScrapWeight WHERE LineKey = @LineKey AND TimeSlipKey = @TimeSlipKey", con)
                    With cmd.Parameters
                        .Add("@MachineHours", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(currentRow).Cells("MachineHours").Value
                        .Add("@SetupHours", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(currentRow).Cells("SetupHours").Value
                        .Add("@ToolingHours", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(currentRow).Cells("ToolingHours").Value
                        .Add("@OtherHours", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(currentRow).Cells("OtherHours").Value
                        .Add("@TotalHours", SqlDbType.VarChar).Value = totalHours
                        .Add("@PiecesProduced", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(currentRow).Cells("PiecesProduced").Value
                        .Add("@LineWeight", SqlDbType.VarChar).Value = totalWeight
                        .Add("@ScrapWeight", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(currentRow).Cells("ScrapWeight").Value
                        .Add("@LineKey", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(currentRow).Cells("LineKey").Value
                        .Add("@TimeSlipKey", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(currentRow).Cells("TimeSlipKey").Value
                    End With
                End If

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                loadTimeSlipEntries()
                isloaded = True
                dgvTimeSlipEntries.CurrentCell = dgvTimeSlipEntries.Rows(currentRow).Cells(currentColumn)
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPost.Click
        Dim TodaysDate As Date = Now()

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            'Skip Posting Check
        ElseIf Me.dgvTimeSlipEntries.RowCount < 10 Then
            'Skip partial posting
        ElseIf EmployeeLoginName = "CDAVIES" Then
            'Skip Fill In Posting Check
        ElseIf EmployeeLoginName = "JSCHULTZ" And TodaysDate > "12/12/2022" And TodaysDate < "1/1/2023" Then
            'Skip Half day Posting Check
        Else
            Dim MinDate As Date

            Dim MinDateString As String = "SELECT MIN(PostingDate) FROM TimeSlipCombinedData WHERE Status <> @Status"
            Dim MinDateCommand As New SqlCommand(MinDateString, con)
            MinDateCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MinDate = CDate(MinDateCommand.ExecuteScalar)
            Catch ex As System.Exception
                MinDate = Today()
            End Try
            con.Close()

            GlobalTimeSlipValidationDate = MinDate
            GlobalTimeSlipValidation = ""

            Using NewTimeSlipRoster As New TimeSlipRoster
                Dim Result = NewTimeSlipRoster.ShowDialog()
            End Using

            If GlobalTimeSlipValidation = "FAIL" Then
                Exit Sub
            Else
                'Continue with posting
            End If
        End If

        loadTimeSlipEntries()
        postingErrors = False
        tmrPostingMessage.Start()
        pnlPostingMessage.Visible = True
        dgvTimeSlipEntries.ReadOnly = True
        cmdExit.Enabled = False
        cmdPrint.Enabled = False
        cmdPost.Enabled = False
        cmdPostSpecial.Enabled = False

        If dgvTimeSlipEntries.Rows.Count > 0 Then
            bgwkPosting.RunWorkerAsync()
        Else
            MessageBox.Show("Posting has already been completed.", "Posting Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub addToInventoryCosting(ByRef row As DataRow, ByVal itemCost As Double, ByVal division As String, ByVal con As SqlConnection)
        Dim cmd As SqlCommand
        Try
            ''Gets the Max transactionNumber
            cmd = New SqlCommand("DECLARE @MaxTransactionNumber as int = Case WHEN Exists(SELECT isnull(MAX(TransactionNumber), 0) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID) then (SELECT isnull(MAX(TransactionNumber), 0 ) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID) ELSE (SELECT 0) END;", con)
            If row.Item("PiecesProduced") >= 0 Then
                ''Gets the Lower and Upper Limits
                cmd.CommandText += " BEGIN TRAN DECLARE @LowerLimit as int = (case when exists(SELECT isnull(UpperLimit, 0) FROM InventoryCosting WHERE TransactionNumber = @MaxTransactionNumber AND DivisionID = @DivisionID) then (SELECT isnull(UpperLimit, 0) FROM InventoryCosting WHERE TransactionNumber = @MaxTransactionNumber AND DivisionID = @DivisionID) else (select 0) end) + 1;"
                ''Insertion into Inventory Costing
                cmd.CommandText += "  Insert Into InventoryCosting (TransactionNumber, PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, ReferenceNumber, ReferenceLine)values((SELECT isnull(MAX(TransactionNumber) + 1, 63000001) FROM InventoryCosting),@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @LowerLimit + @CostQuantity - 1, @ReferenceNumber, @ReferenceLine); commit tran;"
                cmd.Parameters.Add("@CostQuantity", SqlDbType.VarChar).Value = row.Item("PiecesProduced")
            Else
                ''Gets the Lower and Upper Limits
                cmd.CommandText += " BEGIN TRAN DECLARE @LowerLimit as int = (case when exists(SELECT isnull(UpperLimit, 0) FROM InventoryCosting WHERE TransactionNumber = @MaxTransactionNumber AND DivisionID = @DivisionID) then (SELECT isnull(UpperLimit, 0) FROM InventoryCosting WHERE TransactionNumber = @MaxTransactionNumber AND DivisionID = @DivisionID) else (select 0) end);"
                ''Insertion into Inventory Costing
                cmd.CommandText += " Insert Into InventoryCosting (TransactionNumber, PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, ReferenceNumber, ReferenceLine)values((SELECT isnull(MAX(TransactionNumber) + 1, 63000001) FROM InventoryCosting),@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @LowerLimit - @CostQuantity, @ReferenceNumber, @ReferenceLine); commit tran;"
                cmd.Parameters.Add("@CostQuantity", SqlDbType.VarChar).Value = Math.Abs(row.Item("PiecesProduced"))
            End If
            'Write Values to Inventory Costing Table
            With cmd.Parameters
                .Add("@PartNumber", SqlDbType.VarChar).Value = row.Item("PartNumber")
                .Add("@CostingDate", SqlDbType.VarChar).Value = row.Item("PostingDate")
                .Add("@ItemCost", SqlDbType.VarChar).Value = Math.Abs(Math.Round(itemCost, 5, MidpointRounding.AwayFromZero))
                .Add("@Status", SqlDbType.VarChar).Value = "TIME SLIP"
                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = row.Item("TimeSlipKey")
                .Add("@ReferenceLine", SqlDbType.VarChar).Value = row.Item("LineKey")
            End With

            If EmployeeCompanyCode.Equals("TST") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            sendErrorToDataBase("HeaderTimeSlipVerification - addToInventoryCosting --Error trying to insert into InventoryCosting", "Part #" + row.Item("PartNumber"), ex.ToString(), con)
            postingErrors = True
        End Try
    End Sub

    Private Sub addToInventoryTransaction(ByRef row As DataRow, ByVal extendedCost As Double, ByVal GLAccount As String, ByVal division As String, ByVal con As SqlConnection)
        Dim cmd As SqlCommand
        ''adds the entry into the InventoryTransactionTable
        cmd = New SqlCommand("INSERT INTO InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ExtendedCost, ItemPrice, ExtendedAmount, DivisionID, TransactionMath, GLAccount) VALUES((SELECT isnull(MAX(TransactionNumber) + 1, 867500001) FROM InventoryTransactionTable), @TransactionDate, @Comment, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, (SELECT TOP 1 ShortDescription FROM ItemList WHERE ItemID = @PartNumber AND (DivisionID = 'TWD' OR DivisionID = 'TFP')), (SELECT TOP 1 InventoryPieces FROM TimeSlipLineItemTable WHERE TimeSlipKey = @TransactionTypeNumber AND LineKey = @TransactionTypeLineNumber), @ItemCost, @ExtendedCost, 0, 0, @DivisionID, @TransactionMath, @GLAccount);", con)

        With cmd.Parameters
            .Add("@TransactionDate", SqlDbType.VarChar).Value = row.Item("PostingDate")
            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = row.Item("TimeSlipKey")
            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = row.Item("LineKey")
            .Add("@PartNumber", SqlDbType.VarChar).Value = row.Item("PartNumber")
            .Add("@ExtendedCost", SqlDbType.Float).Value = extendedCost
            .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
        End With
        If row.Item("PiecesProduced") >= 0 Then
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = "Post Production"
            cmd.Parameters.Add("@ItemCost", SqlDbType.Float).Value = Math.Round(extendedCost / row.Item("PiecesProduced"), 5, MidpointRounding.AwayFromZero)
            cmd.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
        Else
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = "Post Production Adjustment"
            cmd.Parameters.Add("@ItemCost", SqlDbType.Float).Value = Math.Round(extendedCost / Math.Abs(row.Item("PiecesProduced")), 5, MidpointRounding.AwayFromZero)
            cmd.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
        End If

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            sendErrorToDataBase("TimeSlipPosting - addToInventoryTransaction --Error adding Inventory Transaction entry", "TimeSlip # " + row.Item("TimeSlipKey").ToString() + " Row # " + row.Item("LineKey").ToString(), ex.ToString(), con)
            postingErrors = True
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String, ByVal con As SqlConnection)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If

        Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Now.Date
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

    Private Sub updateTimeSlipLineItem(ByVal i As Integer, ByVal GLLineCost As Double, ByVal division As String, ByVal con As SqlConnection, Optional ByVal AddInventory As Boolean = False)
        Dim cmd As SqlCommand
        If AddInventory Then
            cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET InventoryPieces = @InventoryPieces, ExtendedCost = @ExtendedCost, Cost = @Cost, DivisionID = @DivisionID WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey;", con)
            cmd.Parameters.Add("@InventoryPieces", SqlDbType.Float).Value = Val(ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced"))
        Else
            cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET ExtendedCost = @ExtendedCost, Cost = @Cost, DivisionID = @DivisionID WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey;", con)
        End If
        If Val(ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced")) >= 0 Then
            cmd.Parameters.Add("@ExtendedCost", SqlDbType.Float).Value = GLLineCost
        Else
            If Val(ds.Tables("TimeSlipCombinedData").Rows(i).Item("TotalHours")) < 0 Then
                If AddInventory Then
                    cmd.CommandText = "UPDATE TimeSlipLineItemTable SET InventoryPieces = @InventoryPieces, ExtendedCost = @ExtendedCost, Cost = @Cost, DivisionID = @DivisionID, TotalHours = (-1 * TotalHours) WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey;"
                Else
                    cmd.CommandText = "UPDATE TimeSlipLineItemTable SET ExtendedCost = @ExtendedCost, Cost = @Cost, DivisionID = @DivisionID, TotalHours = (-1 * TotalHours) WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey;"
                End If

            End If
            cmd.Parameters.Add("@ExtendedCost", SqlDbType.Float).Value = -1 * GLLineCost
        End If

        If Val(dgvTimeSlipEntries.Rows(i).Cells("PiecesProduced").Value) <> 0 Then
            cmd.Parameters.Add("@Cost", SqlDbType.VarChar).Value = Math.Round(GLLineCost / Val(ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced")), 5, MidpointRounding.AwayFromZero)
        Else
            cmd.Parameters.Add("@Cost", SqlDbType.VarChar).Value = 0
        End If
        cmd.Parameters.Add("@TimeSlipKey", SqlDbType.VarChar).Value = Val(ds.Tables("TimeSlipCombinedData").Rows(i).Item("TimeSlipKey"))
        cmd.Parameters.Add("@LineKey", SqlDbType.VarChar).Value = ds.Tables("TimeSlipCombinedData").Rows(i).Item("LineKey")
        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            sendErrorToDataBase("TimeSlipPosting - updateTimeSlipLineItem --Error updating line item data.", "TimeSlip # " + ds.Tables("TimeSlipCombinedData").Rows(i).Item("TimeSlipKey").ToString() + " Line # " + ds.Tables("TimeSlipCombinedData").Rows(i).Item("LineKey").ToString(), ex.ToString(), con)
            postingErrors = True
        End Try

    End Sub

    Private Function getStep(ByVal FOX As String, ByVal Machine As String, ByVal con As SqlConnection) As Integer
        Dim cmd As New SqlCommand("SELECT MachineClass, ProcessStep FROM MachineTable RIGHT OUTER JOIN FOXSched ON ProcessID = MachineID WHERE DivisionID = 'TWD' AND FOXNumber = @FOXNumber;", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOX
        Dim cla As New List(Of String)
        Dim steps As New List(Of Integer)
        Dim currClass As String = ""
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If IsDBNull(reader.Item("MachineClass")) = False Then
                    cla.Add(reader.Item("MachineClass"))
                    steps.Add(reader.Item("ProcessStep"))
                End If
            End While
        End If
        reader.Close()

        cmd = New SqlCommand("SELECT MachineClass FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = 'TWD';", con)
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

    Private Sub removeBoxes(ByRef row As DataRow, ByVal division As String, ByVal con As SqlConnection)
        Dim cmd As SqlCommand
        Try
            'Write Data to Time Slip Line Database Table (Line Items)
            cmd = New SqlCommand("begin tran declare @box as varchar(50) = (CASE WHEN EXISTS(SELECT ItemID FROM BoxType WHERE BoxTypeID = (SELECT BoxType FROM FOXTable WHERE FOXNumber = @FOXNumber)) THEN (SELECT ItemID FROM BoxType WHERE BoxTypeID = (SELECT BoxType FROM FOXTable WHERE FOXNumber = @FOXNumber)) ELSE (SELECT BoxType FROM FOXTable WHERE FOXNumber = @FOXNumber) END), @BoxCount as float = (SELECT TOP 1 BoxCount FROM ItemList WHERE ItemID = @PartNumber AND (DivisionID = 'TWD' OR DivisionID = 'TFP')); if (@box is null or @BoxCount = 0) select 0 else begin Insert Into TimeSlipLineItemTable(TimeSlipKey, LineKey, FOXNumber, MachineNumber, PartNumber, MachineHours, SetupHours, ToolingHours, OtherHours, TotalHours, PiecesProduced, LineWeight, ScrapWeight, InventoryPieces, RMID, ExtendedCost, Cost, DivisionID)Values(@TimeSlipKey, @LineKey, @FOXNumber, 'BOX', @box, 0, 0, 0, 0, 0, -1 * ceiling(@PiecesProduced / @BoxCount), 0, 0, -1 * ceiling(@PiecesProduced / @BoxCount), '', 0, 0, @DivisionID) end; commit tran;", con)

            With cmd.Parameters
                .Add("@TimeSlipKey", SqlDbType.Int).Value = Val(row.Item("TimeSlipKey"))
                .Add("@LineKey", SqlDbType.Int).Value = Val(row.Item("LineKey")) + 100
                .Add("@PostingDate", SqlDbType.Date).Value = row.Item("PostingDate").ToString()
                .Add("@EmployeeID", SqlDbType.VarChar).Value = row.Item("EmployeeID").ToString()
                .Add("@FOXNumber", SqlDbType.Int).Value = Val(row.Item("FOXNumber"))
                .Add("@MachineNumber", SqlDbType.VarChar).Value = row.Item("MachineNumber")
                .Add("@PartNumber", SqlDbType.VarChar).Value = row.Item("PartNumber")
                .Add("@PiecesProduced", SqlDbType.Float).Value = row.Item("PiecesProduced")
                .Add("@ProductionNumber", SqlDbType.Int).Value = row.Item("ProductionNumber")
            End With
            If EmployeeCompanyCode.Equals("TST") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            sendErrorToDataBase("TimeSlipForm - removeBoxes --Error trying to insert BOX REMOVAL entry into TimeSlipLineItemTable", "Employee ID #" + row.Item("EmployeeID").ToString(), ex.ToString(), con)
            postingErrors = True
        End Try
    End Sub

    Private Sub removeBalls(ByRef row As DataRow, ByVal FluxLoad As String, ByVal division As String, ByVal con As SqlConnection)
        Dim cmd As SqlCommand
        Try
            'Write Data to Time Slip Line Database Table (Line Items)
            cmd = New SqlCommand("begin tran declare @SteelCost as float = isnull((SELECT SteelCostPerPound FROM SteelCostingTable WHERE TransactionNumber = (SELECT TOP 1 isnull(MAX(TransactionNumber), 0) FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT case when SUM(UsageWeight) = 0 or SUM(UsageWeight) is null then 1 else SUM(UsageWeight) end FROM SteelUsageTable WHERE RMID = @RMID) BETWEEN LowerLimit and UpperLimit)),0);", con)
            ''this is the entry into the steelTransactionTable
            cmd.CommandText += " INSERT INTO SteelTransactionTable (TransactionNumber, DivisionID, SteelTransactionDate, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType) VALUES ((SELECT isnull(MAX(TransactionNumber) + 1,8800001) FROM SteelTransactionTable), @DivisionID, @PostingDate, (SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID), (SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID), @PiecesProduced, @SteelCost, ROUND(@PiecesProduced * @SteelCost,2), (SELECT MAX(TimeSlipKey) FROM TimeSlipHeaderTable WHERE EmployeeID = @EmployeeID AND PostingDate = @PostingDate), 1, @RMID, 'SUBTRACT', 'TIMESLIP POSTING');"
            ''this is hte entry into the SteelUsageTable
            cmd.CommandText += " INSERT INTO SteelUsageTable (SteelUsageKey, UsageDate, UsageWeight, RMID, DivisionID, Status, ReferenceNumber, PrintDate) VALUES ((SELECT isnull(MAX(SteelUsageKey) + 1, 2200001) FROM SteelUsageTable), @PostingDate, @PiecesProduced, @RMID, @DivisionID, 'POSTED', @ReferenceNumber, CURRENT_TIMESTAMP); COMMIT TRAN;"
            With cmd.Parameters
                .Add("@RMID", SqlDbType.VarChar).Value = FluxLoad
                .Add("@PostingDate", SqlDbType.Date).Value = row.Item("PostingDate").ToString()
                .Add("@EmployeeID", SqlDbType.VarChar).Value = row.Item("EmployeeID").ToString()
                .Add("@PiecesProduced", SqlDbType.Float).Value = row.Item("PiecesProduced")
                .Add("@ReferenceNumber", SqlDbType.Int).Value = Val(row.Item("TimeSlipKey"))
            End With
            If EmployeeCompanyCode.Equals("TST") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As System.Exception
            sendErrorToDataBase("TimeSlipForm - removeBalls --Error trying to insert BALL REMOVAL entry into TimeSlipLineItemTable. FOX " + row.Item("FOXNumber").ToString(), "Employee ID #" + row.Item("EmployeeID").ToString(), ex.ToString(), con)
            postingErrors = True
        End Try
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Using NewPrintTimeSlipPostings As New PrintTimeSlipPostings(ds.Copy())
            Dim Result = NewPrintTimeSlipPostings.ShowDialog()
        End Using
    End Sub

    Private Sub bgwkPosting_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkPosting.DoWork
        Dim FGEntries As New DataSet()
        FGEntries = ds.Clone()

        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL; Async=true;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd As New SqlCommand("UPDATE TimeSlipHeaderTable SET PrintDate = @PrintDate WHERE TimeSlipKey in (SELECT DISTINCT(TimeSlipKey) FROM TimeSlipLineItemTable WHERE Status <> 'POSTED' AND LineKey < 100 and isnull(PostedSpecial, 'False') <> 'True')", con)
        cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime2).Value = Now
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            sendErrorToDataBase("TimeSlipPosting - bgwkPosting --Error trying to update all entries with the print date", "Print Date" + Now.Date.ToString(), ex.ToString(), con)
        End Try

        Dim division As String = "TWD"
        Dim entries As String = ""

        Dim GLCount As Integer = 0
        Dim GLcmd As New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)
        With GLcmd.Parameters
            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Time Slip Posting"
            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        End With

        If EmployeeCompanyCode.Equals("TST") Then
            GLcmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            GLcmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        For i As Integer = 0 To dgvTimeSlipEntries.Rows.Count - 1
            If i = 0 Then
                entries = "TimeSlipKey = " + dgvTimeSlipEntries.Rows(i).Cells("TimeSlipKey").Value.ToString()
            Else
                entries += " OR TimeSlipKey = " + dgvTimeSlipEntries.Rows(i).Cells("TimeSlipKey").Value.ToString()
            End If

            ''Checks to see if TWE part and if it is the first Step in the process.
            If dgvTimeSlipEntries.Rows(i).Cells("ItemClass").Value.ToString.Equals("TW WELD PROD") AndAlso dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value.Equals(1) AndAlso Not dgvTimeSlipEntries.Rows(i).Cells("RMID").Value.Equals("MISC          1") Then
                Dim rw As Data.DataRow = ds.Tables("TimeSlipCombinedData").NewRow()
                For j As Integer = 0 To dgvTimeSlipEntries.Columns.Count - 1
                    ''Dim tst As Object = dgvTimeSlipEntries.Rows(i).Cells(j).Value
                    rw.Item(j) = dgvTimeSlipEntries.Rows(i).Cells(j).Value
                Next
                RemoveTWERawMaterials(rw)
            End If

            Dim paramCount As Integer = 0
            Dim keyCount As Integer = 0
            Dim batchCount As Integer = 0
            Dim FinishedGoodsStepNumber As Integer = 0

            ''retrieves the finished goods step number for the given FOX
            cmd = New SqlCommand("SELECT ProcessStep, DivisionID FROM FoxSched LEFT OUTER JOIN FOXTable ON FOXSched.FOXNumber = FOXTable.FOXNumber WHERE FOXSched.FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY'", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("FOXNumber").Value

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If Not reader.IsDBNull(0) Then
                    FinishedGoodsStepNumber = reader.Item(0)
                End If
                If reader.IsDBNull(1) Then
                    division = "TWD"
                Else
                    division = reader.Item("DivisionID")
                End If
            End If
            reader.Close()

            Dim addFG As String = "NO"
            ''checks to see if the current step is the finished goods step, if not will 
            If dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value.Equals(999) Then
                ''final check to see if a FOX step was added for the given machine
                cmd = New SqlCommand("SELECT ProcessStep, ProcessAddFG, FOXTable.DivisionID FROM FOXSched LEFT OUTER JOIN FOXTable on FoxSched.FOXNumber = FOXTable.FOXNumber WHERE FoxSched.FOXNumber = @FOXNumber AND ProcessID = @ProcessID", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(i).Cells("FOXNumber").Value
                cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(i).Cells("MachineNumber").Value
                Dim foxStep As Integer = 0

                If con.State = ConnectionState.Closed Then con.Open()
                reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If Not IsDBNull(reader.Item("ProcessStep")) Then
                        foxStep = reader.Item("ProcessStep")
                    End If
                    If IsDBNull(reader.Item("ProcessAddFG")) Then
                        addFG = "NO"
                    Else
                        addFG = reader.Item("ProcessAddFG")
                    End If
                    If IsDBNull(reader.Item("DivisionID")) Then
                        division = "TWD"
                    Else
                        division = reader.Item("DivisionID")
                    End If
                End If
                reader.Close()

                If foxStep <> 0 Then
                    cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET FOXStep = @FOXStep WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey", con)
                    cmd.Parameters.Add("@TimeSlipKey", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("FOXNumber").Value
                    cmd.Parameters.Add("@LineKey", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("LineKey").Value
                    cmd.Parameters.Add("@FOXStep", SqlDbType.Int).Value = foxStep

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()

                    isloaded = False
                    dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value = foxStep
                    isloaded = True
                Else
                    ''attempts to find the proper step for the given machine
                    Dim procStep As Integer = getStep(dgvTimeSlipEntries.Rows(i).Cells("FOXNumber").Value, dgvTimeSlipEntries.Rows(i).Cells("MachineNumber").Value, con)
                    If procStep = 0 Then
                        addFG = "NO"
                        cmd = New SqlCommand("SELECT DivisionID FROM FoxTable WHERE FOXNumber = @FOXNumber;", con)
                        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(i).Cells("FOXNumber").Value
                        If con.State = ConnectionState.Closed Then con.Open()
                        reader = cmd.ExecuteReader()
                        reader.Read()
                        If IsDBNull(reader.Item("DivisionID")) Then
                            division = "TWD"
                        Else
                            division = reader.Item("DivisionID")
                        End If
                    Else
                        cmd = New SqlCommand("SELECT ProcessAddFG, FOXTable.DivisionID FROM FoxSched LEFT OUTER JOIN FOXTable on FoxSched.FOXNumber = FOXTable.FOXNumber WHERE FoxSched.FoxNumber = @FOXNumber AND ProcessStep = @ProcessStep;", con)
                        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(i).Cells("FOXNumber").Value
                        cmd.Parameters.Add("@ProcessStep", SqlDbType.VarChar).Value = procStep
                        If con.State = ConnectionState.Closed Then con.Open()
                        reader = cmd.ExecuteReader()
                        reader.Read()
                        If IsDBNull(reader.Item("ProcessAddFG")) Then
                            addFG = "NO"
                        Else
                            addFG = reader.Item("ProcessAddFG")
                        End If
                        If IsDBNull(reader.Item("DivisionID")) Then
                            division = "TWD"
                        Else
                            division = reader.Item("DivisionID")
                        End If
                        cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET FOXStep = @FOXStep WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey", con)
                        cmd.Parameters.Add("@TimeSlipKey", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("FOXNumber").Value
                        cmd.Parameters.Add("@LineKey", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("LineKey").Value
                        cmd.Parameters.Add("@FOXStep", SqlDbType.Int).Value = foxStep

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()

                        isloaded = False
                        dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value = foxStep
                        isloaded = True
                    End If
                End If
                reader.Close()
            ElseIf dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value.Equals(FinishedGoodsStepNumber) Then
                addFG = "ADDINVENTORY"
            End If

            Dim MachineCost As Double = 0.0

            Dim MachineCostStatement As String = "SELECT MachineCostPerHour FROM MachineTable WHERE MachineID = @MachineID AND (DivisionID = 'TWD' OR DivisionID = 'TFP');"
            Dim MachineCostCommand As New SqlCommand(MachineCostStatement, con)
            MachineCostCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(i).Cells("MachineNumber").Value

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MachineCost = CDbl(MachineCostCommand.ExecuteScalar)
            Catch ex As System.Exception
                MachineCost = 0
            End Try
            Dim MachineOverhead As Double = Math.Round(MachineCost * Val(dgvTimeSlipEntries.Rows(i).Cells("TotalHours").Value), 2, MidpointRounding.AwayFromZero)

            ''*******************************************************
            ''*CONSTANT HERE FOR ESTIMATED COST PER HOUR OF EMPLOYEE*
            ''*******************************************************
            Dim laborCost As Double = Math.Round(constLabor * Val(dgvTimeSlipEntries.Rows(i).Cells("TotalHours").Value), 2, MidpointRounding.AwayFromZero)

            '**********************************
            'Write to General Ledger -- MACHINE COST
            '**********************************

            Dim GLLinePostAmount As Double = Math.Round(laborCost + MachineOverhead, 2, MidpointRounding.AwayFromZero)

            If dgvTimeSlipEntries.Rows(i).Cells("MachineNumber").Value.ToString() <> "188" Then
                ''redundent check to make sure its equal
                If GLLinePostAmount - Math.Round(laborCost + MachineOverhead, 2, MidpointRounding.AwayFromZero) <> 0 Then
                    GLLinePostAmount = Math.Round(laborCost + MachineOverhead, 2, MidpointRounding.AwayFromZero)
                End If
                'MACHINE COST CREDIT TO GL
                If GLCount = 0 Then
                    GLcmd.CommandText += String.Concat("(@Key +", GLCount.ToString, ", @GLAccountNumber", GLCount.ToString, ", @GLTransactionDescription, @GLTransactionDate", GLCount.ToString, ", @GLTransactionDebitAmount", GLCount.ToString, ", @GLTransactionCreditAmount", GLCount.ToString, ",  @GLTransactionComment", GLCount.ToString, ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber", GLCount.ToString, ", @GLReferenceLine", GLCount.ToString, ", @GLTransactionStatus)")
                Else
                    GLcmd.CommandText += String.Concat(", (@Key +", GLCount.ToString, ", @GLAccountNumber", GLCount.ToString, ", @GLTransactionDescription, @GLTransactionDate", GLCount.ToString, ", @GLTransactionDebitAmount", GLCount.ToString, ", @GLTransactionCreditAmount", GLCount.ToString, ",  @GLTransactionComment", GLCount.ToString, ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber", GLCount.ToString, ", @GLReferenceLine", GLCount.ToString, ", @GLTransactionStatus)")
                End If
                If dgvTimeSlipEntries.Rows(i).Cells("PiecesProduced").Value < 0 Then
                    If dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value.Equals(999) Or (dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value > FinishedGoodsStepNumber And FinishedGoodsStepNumber > 0) Then
                        GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "51000"
                    Else
                        GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "12800"
                    End If

                    GLcmd.Parameters.Add("@GLTransactionComment" + GLCount.ToString, SqlDbType.VarChar).Value = "Machining Cost for Timeslip Postings Adjustment"
                Else
                    GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "60099"
                    GLcmd.Parameters.Add("@GLTransactionComment" + GLCount.ToString, SqlDbType.VarChar).Value = "Machining Cost for Timeslip Postings"
                End If
                With GLcmd.Parameters
                    .Add("@GLTransactionDebitAmount" + GLCount.ToString, SqlDbType.Float).Value = 0
                    .Add("@GLTransactionCreditAmount" + GLCount.ToString, SqlDbType.Float).Value = MachineOverhead
                    .Add("@GLReferenceNumber" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("TimeSlipKey").Value
                    .Add("@GLReferenceLine" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("LineKey").Value
                    .Add("@GLTransactionDate" + GLCount.ToString, SqlDbType.Date).Value = dgvTimeSlipEntries.Rows(i).Cells("PostingDate").Value
                    .Add("@PostingDate" + GLCount.ToString, SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(i).Cells("PostingDate").Value
                End With

                GLCount += 1
                ''LABOR COST CREDIT TO GL
                GLcmd.CommandText += String.Concat(", (@Key + ", GLCount.ToString, ", @GLAccountNumber", GLCount.ToString, ", @GLTransactionDescription, @GLTransactionDate", GLCount.ToString, ", @GLTransactionDebitAmount", GLCount.ToString, ", @GLTransactionCreditAmount", GLCount.ToString, ",  @GLTransactionComment", GLCount.ToString, ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber", GLCount.ToString, ", @GLReferenceLine", GLCount.ToString, ", @GLTransactionStatus)")
                If dgvTimeSlipEntries.Rows(i).Cells("PiecesProduced").Value < 0 Then
                    If dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value.Equals(999) Or (dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value > FinishedGoodsStepNumber And FinishedGoodsStepNumber > 0) Then
                        GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "51000"
                    Else
                        GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "12800"
                    End If
                    GLcmd.Parameters.Add("@GLTransactionComment" + GLCount.ToString, SqlDbType.VarChar).Value = "Labor Cost for Timeslip Postings Adjustment"
                Else
                    GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "60000"
                    GLcmd.Parameters.Add("@GLTransactionComment" + GLCount.ToString, SqlDbType.VarChar).Value = "Labor Cost for Timeslip Postings"
                End If
                With GLcmd.Parameters
                    .Add("@GLTransactionDebitAmount" + GLCount.ToString, SqlDbType.Float).Value = 0
                    .Add("@GLTransactionCreditAmount" + GLCount.ToString, SqlDbType.Float).Value = laborCost
                    .Add("@GLReferenceNumber" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("TimeSlipKey").Value
                    .Add("@GLReferenceLine" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("LineKey").Value
                    .Add("@GLTransactionDate" + GLCount.ToString, SqlDbType.Date).Value = dgvTimeSlipEntries.Rows(i).Cells("PostingDate").Value
                    .Add("@PostingDate" + GLCount.ToString, SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(i).Cells("PostingDate").Value
                End With

                GLCount += 1
                ''WIP DEBIT for sum of Machine Cost and Labor Cost to GL
                GLcmd.CommandText += String.Concat(", (@Key + ", GLCount.ToString, ", @GLAccountNumber", GLCount.ToString, ", @GLTransactionDescription, @GLTransactionDate", GLCount.ToString, ", @GLTransactionDebitAmount", GLCount.ToString, ", @GLTransactionCreditAmount", GLCount.ToString, ",  @GLTransactionComment", GLCount.ToString, ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber", GLCount.ToString, ", @GLReferenceLine", GLCount.ToString, ", @GLTransactionStatus)")
                If dgvTimeSlipEntries.Rows(i).Cells("PiecesProduced").Value < 0 Then
                    ''reversing the postings for labor and machine cost
                    With GLcmd.Parameters
                        .Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "60099"
                        .Add("@GLTransactionDebitAmount" + GLCount.ToString, SqlDbType.Float).Value = MachineOverhead
                        .Add("@GLTransactionCreditAmount" + GLCount.ToString, SqlDbType.Float).Value = 0
                        .Add("@GLTransactionComment" + GLCount.ToString, SqlDbType.VarChar).Value = "Machine cost for Timeslip Postings Adjustment"
                        .Add("@GLReferenceNumber" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("TimeSlipKey").Value
                        .Add("@GLReferenceLine" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("LineKey").Value
                        .Add("@GLTransactionDate" + GLCount.ToString, SqlDbType.Date).Value = dgvTimeSlipEntries.Rows(i).Cells("PostingDate").Value
                        .Add("@PostingDate" + GLCount.ToString, SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(i).Cells("PostingDate").Value
                    End With
                    GLCount += 1

                    GLcmd.CommandText += String.Concat(", (@Key + ", GLCount.ToString, ", @GLAccountNumber", GLCount.ToString, ", @GLTransactionDescription, @GLTransactionDate", GLCount.ToString, ", @GLTransactionDebitAmount", GLCount.ToString, ", @GLTransactionCreditAmount", GLCount.ToString, ",  @GLTransactionComment", GLCount.ToString, ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber", GLCount.ToString, ", @GLReferenceLine", GLCount.ToString, ", @GLTransactionStatus)")
                    With GLcmd.Parameters
                        .Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "60000"
                        .Add("@GLTransactionDebitAmount" + GLCount.ToString, SqlDbType.Float).Value = laborCost
                        .Add("@GLTransactionCreditAmount" + GLCount.ToString, SqlDbType.Float).Value = 0
                        .Add("@GLTransactionComment" + GLCount.ToString, SqlDbType.VarChar).Value = "Labor Cost for Timeslip Postings Adjustment"
                        .Add("@GLReferenceNumber" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("TimeSlipKey").Value
                        .Add("@GLReferenceLine" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("LineKey").Value
                        .Add("@GLTransactionDate" + GLCount.ToString, SqlDbType.Date).Value = dgvTimeSlipEntries.Rows(i).Cells("PostingDate").Value
                        .Add("@PostingDate" + GLCount.ToString, SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(i).Cells("PostingDate").Value
                    End With
                Else
                    If dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value.Equals(999) Or (dgvTimeSlipEntries.Rows(i).Cells("FOXStep").Value > FinishedGoodsStepNumber And FinishedGoodsStepNumber > 0) Then
                        GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "51000"
                    Else
                        GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "12800"
                    End If
                    With GLcmd.Parameters
                        .Add("@GLTransactionDebitAmount" + GLCount.ToString, SqlDbType.Float).Value = GLLinePostAmount
                        .Add("@GLTransactionCreditAmount" + GLCount.ToString, SqlDbType.Float).Value = 0
                        .Add("@GLTransactionComment" + GLCount.ToString, SqlDbType.VarChar).Value = "Labor & Machine cost for Timeslip Postings"
                        .Add("@GLReferenceNumber" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("TimeSlipKey").Value
                        .Add("@GLReferenceLine" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(i).Cells("LineKey").Value
                        .Add("@GLTransactionDate" + GLCount.ToString, SqlDbType.Date).Value = dgvTimeSlipEntries.Rows(i).Cells("PostingDate").Value
                        .Add("@PostingDate" + GLCount.ToString, SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(i).Cells("PostingDate").Value
                    End With
                End If
                GLCount += 1

            Else
                laborCost = 0
                MachineCost = 0
                GLLinePostAmount = 0
            End If

            If addFG = "ADDINVENTORY" And ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") <> 0 Then
                ''updates the line extended cost and cost and inventory pieces
                updateTimeSlipLineItem(i, GLLinePostAmount, division, con, True)
                FGEntries.Tables("TimeSlipCombinedData").ImportRow(DirectCast(dgvTimeSlipEntries.Rows(i).DataBoundItem, DataRowView).Row)
            ElseIf CheckAddDBAToFG(i, con) Then
                updateTimeSlipLineItem(i, GLLinePostAmount, division, con, True)
                FGEntries.Tables("TimeSlipCombinedData").ImportRow(DirectCast(dgvTimeSlipEntries.Rows(i).DataBoundItem, DataRowView).Row)
            Else
                ''updates the line extended cost and cost
                updateTimeSlipLineItem(i, GLLinePostAmount, division, con)
            End If
            ''Checks to see if we are getting close to the limit for passed parameters
            If GLcmd.Parameters.Count > 2000 Then
                GLcmd.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    GLcmd.ExecuteNonQuery()
                Catch exSQL As SqlException
                    ''if primary key violation is found will try again to post
                    If exSQL.ToString.Contains("Violation of PRIMARY KEY") Then
                        Try
                            GLcmd.ExecuteNonQuery()
                        Catch ex As SqlException
                            sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert Machine Cost and Labor Cost GL Entries into GLTransactionMasterList.", "Timeslip Posting", ex.ToString(), con)
                            MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    Else
                        sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert Machine Cost and Labor Cost GL Entries into GLTransactionMasterList.", "Timeslip Posting", exSQL.ToString(), con)
                        MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Catch ex As System.Exception
                    sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert  Machine Cost and Labor Cost GL Entries into GLTransactionMasterList.", "Timeslip Posting", ex.ToString(), con)
                    MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                GLCount = 0
                GLcmd.CommandText = "BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values"
                With GLcmd.Parameters
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Time Slip Posting"
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If EmployeeCompanyCode.Equals("TST") Then
                    GLcmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                Else
                    GLcmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                End If
            End If
        Next

        GLcmd.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
        If GLCount > 0 Then
            Try
                If con.State = ConnectionState.Closed Then con.Open()
                GLcmd.ExecuteNonQuery()
            Catch exSQL As SqlException
                ''if primary key violation is found will try again to post
                If exSQL.ToString.Contains("Violation of PRIMARY KEY") Then
                    Try
                        GLcmd.ExecuteNonQuery()
                    Catch ex As SqlException
                        sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert Machine Cost and Labor Cost GL Entries into GLTransactionMasterList.", "Timeslip Posting", ex.ToString(), con)
                        MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                Else
                    sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert Machine Cost and Labor Cost GL Entries into GLTransactionMasterList.", "Timeslip Posting", exSQL.ToString(), con)
                    MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As System.Exception
                sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert  Machine Cost and Labor Cost GL Entries into GLTransactionMasterList.", "Timeslip Posting", ex.ToString(), con)
                MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        ''if there are any steps that are adding to inventory this will take care of them
        If FGEntries.Tables("TimeSlipCombinedData").Rows.Count > 0 Then
            Dim CompletionList As New List(Of ProductionCompletion)
            For i As Integer = 0 To FGEntries.Tables("TimeSlipCombinedData").Rows.Count - 1
                Dim OriginalPartCost As Double = 0D
                If Not IsDBNull(FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("OriginalPart")) Then
                    OriginalPartCost = AddEntriesForPartRemoval(FGEntries.Tables("TimeSlipCombinedData").Rows(i))
                End If
                Dim GLFirstAccount As String = ""
                Dim GLSecondAccount As String = "12800"

                Dim cmd1 As New SqlCommand("SELECT DivisionID, FluxLoadNumber FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
                cmd1.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber"))

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd1.ExecuteReader()
                Dim FluxLoad As String = ""
                If reader.HasRows Then
                    reader.Read()
                    division = reader.Item("DivisionID")
                    If Not IsDBNull(reader.Item("FluxLoadNumber")) Then
                        FluxLoad = reader.Item("FluxLoadNumber")
                    End If
                End If
                reader.Close()
                If Not IsDBNull(FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("GLInventoryAccount")) AndAlso Not String.IsNullOrEmpty(FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("GLInventoryAccount")) Then
                    GLFirstAccount = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("GLInventoryAccount")
                Else
                    If division = "TFP" Then
                        GLFirstAccount = "12500"
                    ElseIf FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("ItemClass") = "TW WELD PROD" Then
                        GLFirstAccount = "12150"
                    Else
                        GLFirstAccount = "12100"
                    End If
                End If

                ''gets the Labor and machine cost per piece to make, piece weight, and steel cost per pound for the posting date.
                cmd = New SqlCommand("SELECT (SELECT FinishedWeight / 1000 FROM FOXTable WHERE FOXNumber = @FOXNumber) as PieceWeight, (SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT isnull(SUM(UsageWeight), 1) FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED' AND UsageDate < (SELECT isnull(MAX(PostingDate), @PostingDate) FROM TimeSlipLineItemTable LEFT OUTER JOIN TimeSlipHeaderTable ON TimeSlipHeaderTable.TimeSlipKey = TimeSlipLineItemTable.TimeSlipKey WHERE MachineNumber = (SELECT ProcessID FROM FOXSched WHERE ProcessStep = 1 AND FOXNumber = @FOXNumber))) BETWEEN LowerLimit AND UpperLimit + 1 ORDER BY CostingDate DESC) as SteelCostPerPound FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber AND FOXStep <= @FOXStep and FOXStep > 0 AND MachineNumber <> '188' AND MachineNumber in (SELECT MachineID FROM (SELECT ProcessID, MachineClass FROM FoxSched inner join MachineTable on ProcessID = MachineID WHERE FOXNumber = @FOXNumber) as FOXSched left outer join MachineTable on FoxSched.MachineClass = MachineTable.MachineClass) GROUP BY FOXNumber;", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber")
                cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("RMID")
                cmd.Parameters.Add("@PostingDate", SqlDbType.Date).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PostingDate")
                cmd.Parameters.Add("@FOXStep", SqlDbType.Int).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("FOXStep")

                Dim LaborMachineCostPer As Double = 0D
                Dim partWeight As Double = 0D
                Dim SteelCost As Double = 0D

                If con.State = ConnectionState.Closed Then con.Open()
                reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If Not IsDBNull(reader.Item("pieceWeight")) Then
                        partWeight = reader.Item("pieceWeight")
                    End If
                    If Not IsDBNull(reader.Item("SteelCostPerPound")) Then
                        SteelCost = reader.Item("SteelCostPerPound")
                    End If
                End If
                reader.Close()
                '************************************************************************************************************
                'Get overhead/machine/labor cost
                Dim SumPiecesProduced As Double = 0
                Dim SumOverhead As Double = 0

                Dim SumPiecesProducedStatement As String = "SELECT SUM(PiecesProduced) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber"
                Dim SumPiecesProducedCommand As New SqlCommand(SumPiecesProducedStatement, con)
                SumPiecesProducedCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber")

                Dim SumOverheadCostStatement As String = "SELECT SUM(ExtendedCost) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber"
                Dim SumOverheadCostCommand As New SqlCommand(SumOverheadCostStatement, con)
                SumOverheadCostCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber")

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumPiecesProduced = CDbl(SumPiecesProducedCommand.ExecuteScalar)
                Catch ex As Exception
                    SumPiecesProduced = 0
                End Try
                Try
                    SumOverhead = CDbl(SumOverheadCostCommand.ExecuteScalar)
                Catch ex As Exception
                    SumOverhead = 0
                End Try
                con.Close()

                If SumPiecesProduced <> 0 Then
                    LaborMachineCostPer = SumOverhead / SumPiecesProduced
                Else
                    LaborMachineCostPer = 0
                End If

                'Johns query to get overhead cost - does not work!!!!!!
                '
                'cmd.CommandText = "SELECT SUM(CASE WHEN TotalPieces <= 0 then 0 else TotalCost / TotalPieces END) FROM (SELECT TimeSlipLineItemTable.FOXStep, CASE WHEN SUM(ExtendedCost) < 0 THEN 0 ELSE SUM(ExtendedCost) END as TotalCost, SUM(TimeSlipLineItemTable.PiecesProduced) as TotalPieces FROM TimeSlipLineItemTable INNER JOIN MachineTable ON TimeSlipLineItemTable.MachineNumber = MachineTable.MachineID INNER JOIN (SELECT FOXNumber, PRocessStep, ProcessADdFG FROM FoxSched WHERE ProcessAddFG = 'ADDINVENTORY') AS FOXSched ON TimeSlipLineItemTable.FOXNumber = FoxSched.FOXNumber WHERE TimeSlipLineItemTable.FOXNumber = @FOXNumber AND LineKey < 100 AND FOXStep <> 999 AND FOXStep <= CASE WHEN (FOXSched.ProcessStep is not null) THEN FOXSched.ProcessStep ELSE 10 END GROUP BY TimeslipLineItemTable.FOXStep) as tmp"
                'Dim obj As Object = cmd.ExecuteScalar()
                'If obj IsNot Nothing Then
                '    LaborMachineCostPer = obj
                'End If
                '*************************************************************************************************
                ''double check to make sure there is a steel cost
                If SteelCost = 0 Then
                    cmd = New SqlCommand("IF EXISTS(SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT isnull(SUM(UsageWeight), 1) FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED') BETWEEN LowerLimit AND UpperLimit + 1 ORDER BY CostingDate DESC) SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT isnull(SUM(UsageWeight), 1) FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED') BETWEEN LowerLimit AND UpperLimit + 1 ORDER BY CostingDate DESC ELSE SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID and TransactionNumber = (SELECT TOP 1 MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID) ORDER BY TransactionNumber;", con)
                    cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("RMID")

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SteelCost = Val(cmd.ExecuteScalar())
                    Catch ex As Exception
                        SteelCost = 0
                    End Try

                    ''If for some reason there was still not a steel cost found and the materials is stainless, this will get the cost
                    ''from the next highest diameter stainless that has a cost.
                    If SteelCost = 0 And FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("Carbon").ToString.StartsWith("SS") Then
                        ''Declares the RMID that is the next highest that has a cost. If none is found then will use the RMID from the line
                        cmd = New SqlCommand("DECLARE @RMID as varchar(50) = CASE WHEN EXISTS(SELECT TOP 1 RawMaterialsTable.RMID FROM RawMaterialsTable INNER JOIN SteelCostingTable ON RawMaterialsTable.RMID = SteelCostingTable.RMID WHERE RawMaterialsTable.RMID >= @CurrentRMID AND RawMaterialsTable.Carbon = @Carbon) THEN (SELECT TOP 1 RawMaterialsTable.RMID FROM RawMaterialsTable INNER JOIN SteelCostingTable ON RawMaterialsTable.RMID = SteelCostingTable.RMID WHERE RawMaterialsTable.RMID >= @CurrentRMID AND RawMaterialsTable.Carbon = @Carbon) ELSE (SELECT @CurrentRMID) END;", con)
                        ''This will attempt to get the cost for the RMID
                        cmd.CommandText += "  IF EXISTS(SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT isnull(SUM(UsageWeight), 1) FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED') BETWEEN LowerLimit AND UpperLimit + 1 ORDER BY CostingDate DESC) SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT isnull(SUM(UsageWeight), 1) FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED') BETWEEN LowerLimit AND UpperLimit + 1 ORDER BY CostingDate DESC ELSE SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID and TransactionNumber = (SELECT TOP 1 MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID) ORDER BY TransactionNumber;"
                        cmd.Parameters.Add("@CurrentRMID", SqlDbType.VarChar).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("RMID")
                        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("Carbon")
                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SteelCost = Val(cmd.ExecuteScalar())
                        Catch ex As Exception
                            SteelCost = 0
                        End Try
                    ElseIf SteelCost = 0 And FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("Carbon").ToString.StartsWith("C") Then
                        'If Carbon Steel has no cost, get last transaction cost

                        'Get Max Transaction Number for RMID First
                        Dim MaxTransactionNumber As Integer = 0

                        Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM SteelTransactionTable WHERE RMID = @RMID AND SteelCost <> @SteelCost"
                        Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
                        MaxTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("RMID")
                        MaxTransactionNumberCommand.Parameters.Add("@SteelCost", SqlDbType.VarChar).Value = 0

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            MaxTransactionNumber = 0
                        End Try
                        con.Close()

                        'Get Cost for this Transaction Number
                        Dim GetLastCostStatement As String = "SELECT SteelCost FROM SteelTransactionTable WHERE TransactionNumber = @TransactionNumber"
                        Dim GetLastCostCommand As New SqlCommand(GetLastCostStatement, con)
                        GetLastCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SteelCost = CDbl(GetLastCostCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            SteelCost = 0
                        End Try
                        con.Close()
                    End If
                End If

                Dim GLLinePostAmount As Double = Math.Round(((LaborMachineCostPer + OriginalPartCost) * FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced")) + (FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") * partWeight * SteelCost), 2, MidpointRounding.AwayFromZero)
                ''adds entry to costing tiers for finished goods
                If FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") <> 0 Then
                    If FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") > 0 Then
                        addToInventoryCosting(FGEntries.Tables("TimeSlipCombinedData").Rows(i), GLLinePostAmount / FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced"), division, con)
                    Else
                        addToInventoryCosting(FGEntries.Tables("TimeSlipCombinedData").Rows(i), GLLinePostAmount / Math.Abs(FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced")), division, con)
                    End If
                End If

                ''adds to inventory transaction table
                addToInventoryTransaction(FGEntries.Tables("TimeSlipCombinedData").Rows(i), Math.Abs(GLLinePostAmount), GLFirstAccount, division, con)

                ''Removes boxes from Inventory if necessary
                removeBoxes(FGEntries.Tables("TimeSlipCombinedData").Rows(i), division, con)

                ''Remove ball inventory from Steel
                If Not String.IsNullOrEmpty(FluxLoad) And FluxLoad.Contains("ABALL") Then
                    removeBalls(FGEntries.Tables("TimeSlipCombinedData").Rows(i), FluxLoad, division, con)
                End If

                cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET ExtendedSteelCost = @ExtendedSteelCost, AVGCostPerPiece = @AVGCostPerPiece WHERE TimeSlipKey = @TimeSlipKey and LineKey = @LineKey", con)
                cmd.Parameters.Add("@TimeslipKey", SqlDbType.Int).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("TimeSlipKey")
                cmd.Parameters.Add("@LineKey", SqlDbType.Int).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("LineKey")
                cmd.Parameters.Add("@ExtendedSteelCost", SqlDbType.Float).Value = Math.Round((FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") * partWeight * SteelCost), 2, MidpointRounding.AwayFromZero)
                cmd.Parameters.Add("@AVGCostPerPiece", SqlDbType.Float).Value = Math.Round(LaborMachineCostPer, 7, MidpointRounding.AwayFromZero)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    sendErrorToDataBase("TimeSlipPosting - cmdPost_Click --Error adding ExtendedSteelCost to TimeSlipLineItemTable. " + Math.Round((FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") * partWeight * SteelCost), 2, MidpointRounding.AwayFromZero).ToString(), "TimeSlip #" + FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("TimeSlipKey") + " Line #" + FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("LineKey"), ex.ToString(), con)
                    postingErrors = True
                End Try

                '**********************************
                'Write to General Ledger -- ADD INVENTORY
                '**********************************
                cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)
                With cmd.Parameters
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Time Slip Posting"
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    .Add("@GLTransactionDate", SqlDbType.Date).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PostingDate")
                    .Add("@PostingDate", SqlDbType.VarChar).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PostingDate")
                    .Add("@EmployeeID", SqlDbType.VarChar).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("EmployeeID")
                    .Add("@GLReferenceLine", SqlDbType.Int).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("LineKey")
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("TimeSlipKey").ToString()
                End With

                If EmployeeCompanyCode.Equals("TST") Then
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                Else
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                End If
                'Write Values to General Ledger (DEBIT)
                cmd.CommandText += "(@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"

                If FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") > 0 Then
                    cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLFirstAccount
                    cmd.Parameters.Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Adding Inventory for FOX #" + FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString()
                Else
                    cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLSecondAccount
                    cmd.Parameters.Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Adjusting Inventory for FOX #" + FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString()
                End If
                With cmd.Parameters
                    .Add("GLTransactionDebitAmount", SqlDbType.Float).Value = Math.Abs(GLLinePostAmount)
                    .Add("@GLTransactionCreditAmount", SqlDbType.Float).Value = 0
                End With

                ''GL Credit for WIP from the inventory entry
                cmd.CommandText += ", (@Key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment1, @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"

                If FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced") > 0 Then
                    cmd.Parameters.Add("@GLAccountNumber1", SqlDbType.VarChar).Value = GLSecondAccount
                    cmd.Parameters.Add("@GLTransactionComment1", SqlDbType.VarChar).Value = "Adding Inventory for FOX #" + FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString()
                Else
                    cmd.Parameters.Add("@GLAccountNumber1", SqlDbType.VarChar).Value = GLFirstAccount
                    cmd.Parameters.Add("@GLTransactionComment1", SqlDbType.VarChar).Value = "Adjusting Inventory for FOX #" + FGEntries.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString()
                End If
                With cmd.Parameters
                    .Add("@GLTransactionDebitAmount1", SqlDbType.Float).Value = 0
                    .Add("@GLTransactionCreditAmount1", SqlDbType.Float).Value = Math.Abs(GLLinePostAmount)
                End With

                '**********************************
                'End of Ledger Entry
                '**********************************
                cmd.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                Catch exSQL As SqlException
                    ''if primary key violation is found will try again to post
                    If exSQL.ToString.Contains("Violation of PRIMARY KEY") Then
                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As SqlException
                            sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert Add Finished Goods GL Entries into GLTransactionMasterList.", "EmployeeID #" + dgvTimeSlipEntries.Rows(i).Cells("EmployeeID").Value.ToString(), ex.ToString(), con)
                            MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    Else
                        sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert Add Finished Goods GL Entries into GLTransactionMasterList.", "EmployeeID #" + dgvTimeSlipEntries.Rows(i).Cells("EmployeeID").Value.ToString(), exSQL.ToString(), con)
                        MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Catch ex As System.Exception
                    sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert Add Finished Goods GL Entries into GLTransactionMasterList.", "EmployeeID #" + dgvTimeSlipEntries.Rows(i).Cells("EmployeeID").Value.ToString(), ex.ToString(), con)
                    MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            Next
        End If

        If Not String.IsNullOrEmpty(entries) Then
            'UPDATE Time Slip Header to show POSTED Status
            cmd = New SqlCommand("UPDATE TimeSlipHeaderTable SET Status = 'POSTED' WHERE " + entries, con)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
        End If
        con.Close()
    End Sub

    Private Sub bgwkPosting_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkPosting.RunWorkerCompleted
        tmrPostingMessage.Stop()
        pnlPostingMessage.Visible = False
        lblPostingMessage.Text = "Posting please wait."
        dgvTimeSlipEntries.ReadOnly = False
        loadTimeSlipEntries()
        cmdExit.Enabled = True
        cmdPrint.Enabled = True
        If postingErrors Then
            MessageBox.Show("There were errors in the posting. Contact system admin.", "Postin errors", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub tmrPostingMessage_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPostingMessage.Tick
        Select Case lblPostingMessage.Text
            Case "Posting please wait."
                lblPostingMessage.Text += "."
            Case "Posting please wait.."
                lblPostingMessage.Text += "."
            Case "Posting please wait..."
                lblPostingMessage.Text = "Posting please wait."
        End Select
    End Sub

    Private Sub TimeSlipPosting_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        While bgwkPosting.IsBusy
            System.Threading.Thread.Sleep(1000)
        End While

    End Sub

    Private Sub cmdPostSpecial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostSpecial.Click
        If canPostSpecial() Then
            cmdPostSpecial.Enabled = False
            cmdPost.Enabled = False
            Dim division As String = "TWD"
            Dim lst As New List(Of Integer)
            For i As Integer = 0 To dgvTimeSlipEntries.SelectedCells.Count - 1
                If Not lst.Contains(dgvTimeSlipEntries.SelectedCells(i).RowIndex) Then
                    lst.Add(dgvTimeSlipEntries.SelectedCells(i).RowIndex)
                End If
            Next
            Dim GLCount As Integer = 0
            Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
            Dim cmd As New SqlCommand()

            Dim GLcmd As New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)
            With GLcmd.Parameters
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Time Slip Posting"
                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
            End With

            If EmployeeCompanyCode.Equals("TST") Then
                GLcmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            Else
                GLcmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            End If

            For i As Integer = 0 To lst.Count - 1

                Dim paramCount As Integer = 0
                Dim keyCount As Integer = 0
                Dim batchCount As Integer = 0

                Dim MachineCost As Double = 0.0

                Dim MachineCostStatement As String = "SELECT MachineCostPerHour FROM MachineTable WHERE MachineID = @MachineID AND (DivisionID = 'TWD' OR DivisionID = 'TFP');"
                Dim MachineCostCommand As New SqlCommand(MachineCostStatement, con)
                MachineCostCommand.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = dgvTimeSlipEntries.Rows(lst(i)).Cells("MachineNumber")

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MachineCost = CDbl(MachineCostCommand.ExecuteScalar)
                Catch ex As System.Exception
                    MachineCost = 0
                End Try
                Dim MachineOverhead As Double = Math.Round(MachineCost * Val(dgvTimeSlipEntries.Rows(lst(i)).Cells("TotalHours")), 2, MidpointRounding.AwayFromZero)

                ''*******************************************************
                ''*CONSTANT HERE FOR ESTIMATED COST PER HOUR OF EMPLOYEE*
                ''*******************************************************
                Dim laborCost As Double = Math.Round(constLabor * Val(dgvTimeSlipEntries.Rows(lst(i)).Cells("TotalHours")), 2, MidpointRounding.AwayFromZero)

                '**********************************
                'Write to General Ledger -- MACHINE COST
                '**********************************

                Dim GLLinePostAmount As Double = Math.Round(laborCost + MachineOverhead, 2, MidpointRounding.AwayFromZero)
                If dgvTimeSlipEntries.Rows(lst(i)).Cells("MachineNumber").Value.ToString() <> "188" Then
                    ''redundent check to make sure it doesn't round off
                    If GLLinePostAmount - (Math.Round(laborCost + MachineOverhead, 2, MidpointRounding.AwayFromZero)) <> 0 Then
                        GLLinePostAmount = Math.Round(laborCost + MachineOverhead, 2, MidpointRounding.AwayFromZero)
                    End If
                    'MACHINE COST CREDIT TO GL
                    If GLCount = 0 Then
                        GLcmd.CommandText += String.Concat("(@Key +", GLCount.ToString, ", @GLAccountNumber", GLCount.ToString, ", @GLTransactionDescription, @GLTransactionDate", GLCount.ToString, ", @GLTransactionDebitAmount", GLCount.ToString, ", @GLTransactionCreditAmount", GLCount.ToString, ",  @GLTransactionComment", GLCount.ToString, ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber", GLCount.ToString, ", @GLReferenceLine", GLCount.ToString, ", @GLTransactionStatus)")
                    Else
                        GLcmd.CommandText += String.Concat(", (@Key +", GLCount.ToString, ", @GLAccountNumber", GLCount.ToString, ", @GLTransactionDescription, @GLTransactionDate", GLCount.ToString, ", @GLTransactionDebitAmount", GLCount.ToString, ", @GLTransactionCreditAmount", GLCount.ToString, ",  @GLTransactionComment", GLCount.ToString, ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber", GLCount.ToString, ", @GLReferenceLine", GLCount.ToString, ", @GLTransactionStatus)")
                    End If
                    If dgvTimeSlipEntries.Rows(lst(i)).Cells("PiecesProduced").Value > 0 Then
                        GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "51000"
                    Else
                        GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "12800"
                    End If
                    With GLcmd.Parameters
                        .Add("@GLTransactionComment" + GLCount.ToString, SqlDbType.VarChar).Value = "Labor & Machine cost for Timeslip Postings Adjustment"
                        .Add("@GLTransactionDebitAmount" + GLCount.ToString, SqlDbType.Float).Value = 0
                        .Add("@GLTransactionCreditAmount" + GLCount.ToString, SqlDbType.Float).Value = GLLinePostAmount
                        .Add("@GLReferenceNumber" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(lst(i)).Cells("TimeSlipKey")
                        .Add("@GLReferenceLine" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(lst(i)).Cells("LineKey")
                        .Add("@GLTransactionDate" + GLCount.ToString, SqlDbType.Date).Value = dgvTimeSlipEntries.Rows(lst(i)).Cells("PostingDate")
                    End With

                    GLCount += 1

                    ''WIP DEBIT for sum of Machine Cost and Labor Cost to GL
                    GLcmd.CommandText += String.Concat(", (@Key + ", GLCount.ToString, ", @GLAccountNumber", GLCount.ToString, ", @GLTransactionDescription, @GLTransactionDate", GLCount.ToString, ", @GLTransactionDebitAmount", GLCount.ToString, ", @GLTransactionCreditAmount", GLCount.ToString, ",  @GLTransactionComment", GLCount.ToString, ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber", GLCount.ToString, ", @GLReferenceLine", GLCount.ToString, ", @GLTransactionStatus)")
                    If dgvTimeSlipEntries.Rows(lst(i)).Cells("PiecesProduced").Value > 0 Then
                        GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "12800"
                    Else
                        GLcmd.Parameters.Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "51000"
                    End If
                    With GLcmd.Parameters
                        .Add("@GLTransactionDebitAmount" + GLCount.ToString, SqlDbType.Float).Value = GLLinePostAmount
                        .Add("@GLTransactionCreditAmount" + GLCount.ToString, SqlDbType.Float).Value = 0
                        .Add("@GLTransactionComment" + GLCount.ToString, SqlDbType.VarChar).Value = "Labor & Machine cost for Timeslip Postings Adjustment"
                        .Add("@GLReferenceNumber" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(lst(i)).Cells("TimeSlipKey")
                        .Add("@GLReferenceLine" + GLCount.ToString, SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(lst(i)).Cells("LineKey")
                        .Add("@GLTransactionDate" + GLCount.ToString, SqlDbType.Date).Value = dgvTimeSlipEntries.Rows(lst(i)).Cells("PostingDate")
                    End With
                    GLCount += 1
                End If
                cmd = New SqlCommand("UPDATE TimeSlipLineItemTable SET PostedSpecial = 'True' WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey", con)
                cmd.Parameters.Add("@TimeSlipKey", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(lst(i)).Cells("TimeSlipKey")
                cmd.Parameters.Add("@LineKey", SqlDbType.Int).Value = dgvTimeSlipEntries.Rows(lst(i)).Cells("LineKey")

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
            Next

            GLcmd.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
            If GLCount > 0 Then
                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    GLcmd.ExecuteNonQuery()
                Catch exSQL As SqlException
                    ''if primary key violation is found will try again to post
                    If exSQL.ToString.Contains("Violation of PRIMARY KEY") Then
                        Try
                            GLcmd.ExecuteNonQuery()
                        Catch ex As SqlException
                            sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert Machine Cost and Labor Cost GL Entries into GLTransactionMasterList.", "Timeslip Posting", ex.ToString(), con)
                            MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    Else
                        sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert Machine Cost and Labor Cost GL Entries into GLTransactionMasterList.", "Timeslip Posting", exSQL.ToString(), con)
                        MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Catch ex As System.Exception
                    sendErrorToDataBase("TimeSlipPosting - cmdPostTimeSlip_Click --Error trying to insert  Machine Cost and Labor Cost GL Entries into GLTransactionMasterList.", "Timeslip Posting", ex.ToString(), con)
                    MessageBox.Show("There was a problem posting the time slip", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
            loadTimeSlipEntries()
        End If
    End Sub

    Private Function canPostSpecial() As Boolean
        If dgvTimeSlipEntries.SelectedCells.Count = 0 Then
            MessageBox.Show("You must select row(s) to post", "Select rows", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function

    Private Sub dgvTimeSlipEntries_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvTimeSlipEntries.VisibleChanged
        For i As Integer = 0 To dgvTimeSlipEntries.Rows.Count - 1
            If dgvTimeSlipEntries.Rows(i).Cells("ProcessAddFG").Value.ToString.Equals("ADDINVENTORY") Then
                dgvTimeSlipEntries.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Next
    End Sub

    Private Sub RemoveTWERawMaterials(ByVal rw As Data.DataRow)
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Async=True;Integrated Security=True;Connect Timeout=30")
        Dim CostPerPound As Double = 0

        Dim TotalCost As Double = SteelModule.GetSteelCosting(rw.Item("RMID"), rw.Item("LineWeight"), con, rw.Item("PostingDate"))
        If rw.Item("LineWeight") = 0 Then
            CostPerPound = 0
        Else
            CostPerPound = Math.Round(TotalCost / rw.Item("LineWeight"), 5, MidpointRounding.AwayFromZero)
        End If
        Dim usageKey As Integer = 0

        Dim cmd As SqlCommand = Nothing
        Try
            'Write Data to Steel Usage Table
            cmd = New SqlCommand("DECLARE @Key as int = (SELECT isnull(MAX(SteelUsageKey) + 1, 22000001) FROM SteelUsageTable);" _
                                 + " Insert Into SteelUsageTable(SteelUsageKey, UsageDate, UsageWeight, RMID, DivisionID, Status, ReferenceNumber, ReferenceLineNumber, PrintDate, SteelCost, ExtendedCost)" _
                                 + " Values(@Key, @UsageDate, @UsageWeight, @RMID, @DivisionID, 'POSTED', @ReferenceNumber, 0, @PrintDate, @SteelCost, @ExtendedCost);" _
                                 + " SELECT @Key;", con)

            With cmd.Parameters
                .Add("@UsageDate", SqlDbType.Date).Value = rw.Item("PostingDate")
                .Add("@RMID", SqlDbType.VarChar).Value = rw.Item("RMID")
                .Add("@UsageWeight", SqlDbType.Float).Value = rw.Item("LineWeight")
                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = "FOX #" + rw.Item("FOXNumber").ToString()
                .Add("@PrintDate", SqlDbType.DateTime2).Value = Now
                .Add("@SteelCost", SqlDbType.Float).Value = CostPerPound
                .Add("@ExtendedCost", SqlDbType.Float).Value = TotalCost
            End With

            If EmployeeCompanyCode.Equals("TST") Then
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            Else
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            usageKey = Convert.ToInt32(cmd.ExecuteScalar())
            con.Close()
        Catch ex As System.Exception
            sendErrorToDataBase("SteelWireYardRemoval - bgwkTWERawMaterialsRemoval_DoWork --Error adding Steel Usage Entry", "FOX #" + rw.Item("FOXNumber").ToString, ex.ToString(), con)
        End Try

        ''inserts the entry into the SteelTransactionTable
        cmd = New SqlCommand("INSERT INTO SteelTransactionTable (TransactionNumber, DivisionID, Carbon, SteelSize, Quantity, SteelCost, ExtendedCost, SteelReferenceNumber, SteelReferenceLine, RMID, TransactionMath, TransactionType, SteelTransactionDate)" _
                             + " VALUES((SELECT isnull(MAX(TransactionNumber) + 1,7700001) FROM SteelTransactionTable),@DivisionID, @Carbon, @SteelSize, @Quantity, @SteelCost, @ExtendedCost, @SteelReferenceNumber, 0, @RMID, 'SUBTRACT', 'TIMESLIP REMOVED', @PostingDate);", con)
        With cmd.Parameters
            .Add("@Quantity", SqlDbType.Float).Value = rw.Item("LineWeight")
            .Add("@SteelCost", SqlDbType.Float).Value = CostPerPound
            .Add("@ExtendedCost", SqlDbType.Float).Value = TotalCost
            .Add("@PostingDate", SqlDbType.Date).Value = rw.Item("PostingDate")
            .Add("@EmployeeID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@SteelReferenceNumber", SqlDbType.Int).Value = usageKey
            .Add("@Carbon", SqlDbType.VarChar).Value = rw.Item("Carbon")
            .Add("@SteelSize", SqlDbType.VarChar).Value = rw.Item("SteelSize")
            .Add("@RMID", SqlDbType.VarChar).Value = rw.Item("RMID")
        End With

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()

        cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList)," _
                                 + " @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList);" _
                                 + " SET xact_abort on;" _
                                 + " Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)" _
                                 + " values(@key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @UsageKey, @GLReferenceLine, @GLTransactionStatus)", con)
        With cmd.Parameters
            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12800"
            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Timeslip Raw Materials"
            .Add("@GLTransactionDate", SqlDbType.Date).Value = rw.Item("PostingDate")
            .Add("@GLTransactionDebitAmount", SqlDbType.Float).Value = TotalCost
            .Add("@GLTransactionCreditAmount", SqlDbType.Float).Value = 0
            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Removed TWE Raw Materials"
            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
            .Add("@UsageKey", SqlDbType.VarChar).Value = usageKey.ToString()
            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
        End With

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If
        'Write Values to General Ledger (CREDIT)
        cmd.CommandText += ", (@key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @UsageKey, @GLReferenceLine, @GLTransactionStatus); COMMIT TRAN; SET xact_abort OFF;"
        With cmd.Parameters
            .Add("@GLAccountNumber1", SqlDbType.VarChar).Value = "12000"
            .Add("@GLTransactionDebitAmount1", SqlDbType.Float).Value = 0
            .Add("@GLTransactionCreditAmount1", SqlDbType.Float).Value = TotalCost
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            If ex.ToString.ToLower.Contains("primary key") Then
                Try
                    cmd.ExecuteNonQuery()
                Catch ex1 As Exception
                    sendErrorToDataBase("SteelWireYardRemoval - bgwkTWERawMaterialsRemoval_DoWork --Error adding GL Entries into GLTransactionMasterList", "FOX #" + rw.Item("FOXNumber").ToString, ex1.ToString(), con)
                End Try
            Else
                sendErrorToDataBase("SteelWireYardRemoval - bgwkTWERawMaterialsRemoval_DoWork --Error adding GL Entries into GLTransactionMasterList", "FOX #" + rw.Item("FOXNumber").ToString, ex.ToString(), con)
            End If
        End Try

        con.Close()
    End Sub

    Private Function AddEntriesForPartRemoval(ByVal dr As Data.DataRow) As Double
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;ASYNC=true;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim FIFOList As List(Of Double)
        Try
            FIFOList = GetItemCosting(dr, con)
        Catch ex As Exception
            sendErrorToDataBase("TimeSlipPosting - AddEntriesForPartRemoval --Error getting FIFO", "Part # " + dr.Item("OriginalPart"), ex.ToString(), con)
            FIFOList = New List(Of Double)
            FIFOList.Add(0)
            FIFOList.Add(0)
        End Try
        Try
            ''Adds the GL Entry to add the cost of the parts into WIP
            AddOriginalPartGLEntries(dr, con, FIFOList(1))
        Catch ex As Exception
            sendErrorToDataBase("TimeSlipPosting - AddEntriesForPartRemoval --Error adding GL entries Timeslip#" + dr.Item("TimeSlipKey").ToString, "Part # " + dr.Item("OriginalPart"), ex.ToString(), con)
        End Try
        Try
            ''Adds the Entry for the transaction for the parts
            AddOriginalPartRemovalTransaction(dr, con, FIFOList)
        Catch ex As Exception
            sendErrorToDataBase("TimeSlipPosting - AddEntriesForPartRemoval --Error adding transaction entry Timeslip#" + dr.Item("TimeSlipKey").ToString, "Part # " + dr.Item("OriginalPart"), ex.ToString(), con)
        End Try
        Try
            ''Adds entry into TimeSlip Line Table for Part removal
            AddOriginalPartTimeSlipEntry(dr, con, FIFOList)
        Catch ex As Exception
            sendErrorToDataBase("TimeSlipPosting - AddEntriesForPartRemoval --Error Adding Time slip entry Timeslip#" + dr.Item("TimeSlipKey").ToString, "Part # " + dr.Item("OriginalPart"), ex.ToString(), con)
        End Try
        Return Math.Round(FIFOList(1) / dr.Item("PiecesProduced"), 5, MidpointRounding.AwayFromZero)
    End Function

    Public Function GetItemCosting(ByVal dr As Data.DataRow, ByVal con As SqlConnection) As List(Of Double)
        Dim TotalShipped As Double = 1D
        Dim MaxUpperLimit As Double = 0D
        Dim FIFOCost As Double = 0D
        Dim FIFOExtendedAmount As Double = 0D
        Dim cmd As New SqlCommand("DECLARE @ShipDate date = (SELECT PostingDate FROM TimeSlipHeaderTable WHERE TimeSlipKey = @TimeSlipKey) " _
                                  + " IF EXISTS(SELECT isnull(SUM(QuantityShipped), 1) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> 'YES' AND LineStatus <> 'PENDING') " _
                                   + " SELECT isnull(SUM(QuantityShipped), 1) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> 'YES' AND LineStatus <> 'PENDING'" _
                                   + " ELSE SELECT 1", con)
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = dr.Item("OriginalPart")
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = dr.Item("DivisionID")
        cmd.Parameters.Add("@TimeSlipKey", SqlDbType.Int).Value = dr.Item("TimeSlipKey")

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalShipped = CType(cmd.ExecuteScalar(), Double)
        Catch ex As Exception
        End Try

        ''Gets the max upper limit from the inventory costing table for the given part
        cmd.CommandText = "DECLARE @CostingDate date = (SELECT PostingDate FROM TimeSlipHeaderTable WHERE TimeSlipKey = @TimeSlipKey);" _
        + " DECLARE @MaxTransactionNumber int = (SELECT isnull(MAX(TransactionNumber), 0) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate);" _
        + " IF @MaxTransactionNumber is not null SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @MaxTransactionNumber AND DivisionID = @DivisionID ELSE SELECT 0;"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxUpperLimit = CType(cmd.ExecuteScalar(), Double)
        Catch ex As Exception
        End Try

        If TotalShipped < MaxUpperLimit Then
            Dim UpperLimit As Integer = 0
            Dim LowerLimit As Integer = 0
            Dim QuantityRemaining As Integer = dr.Item("PiecesProduced")
            Dim NoCostTierFound As Boolean = False
            Dim OrderQuantity As Integer = dr.Item("PiecesPRoduced")
            ''FIFO COSTING
            cmd.CommandText = "DECLARE @CostingDate date = (SELECT PostingDate FROM TimeSlipHeaderTable WHERE TimeSlipKey = @TimeSlipKey);" _
            + " DECLARE @TransactionNumber int = (SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalShipped BETWEEN LowerLimit AND UpperLimit)" _
            + " IF @TransactionNumber is null SELECT 0, -1, 0" _
            + " ELSE SELECT ItemCost, UpperLimit, LowerLimit FROM InventoryCosting WHERE DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber"
            cmd.Parameters.Add("@TotalShipped", SqlDbType.Float).Value = TotalShipped

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("ItemCost")) Then
                    FIFOCost = 0
                Else
                    FIFOCost = reader.Item("ItemCost")
                End If
                If IsDBNull(reader.Item("UpperLimit")) Then
                    UpperLimit = 0
                Else
                    UpperLimit = reader.Item("UpperLimit")
                End If
            Else
                FIFOCost = 0
                UpperLimit = 0
            End If
            reader.Close()
            ''Check to make sure a cost tier was found
            If UpperLimit = -1 Then
                NoCostTierFound = True
            End If
            ''check to see if we should stop FIFO Costing
            If NoCostTierFound Then
                FIFOCost = 0
                FIFOExtendedAmount = 0
            Else
                If TotalShipped + OrderQuantity > UpperLimit Then
                    'Quantity crosses a cost tier
                    QuantityRemaining = (TotalShipped + OrderQuantity) - UpperLimit

                    FIFOExtendedAmount = (UpperLimit - TotalShipped) * FIFOCost

                    'Create loop to calculate remainder of quantity
                    Do While QuantityRemaining > 0
                        Dim TempQuantity As Double = 0
                        Dim NextUpperLimit As Integer = 0
                        Dim NextLowerLimit As Integer = 0
                        cmd.Parameters.Add("@TotalShipped", SqlDbType.VarChar).Value = UpperLimit + 1

                        If con.State = ConnectionState.Closed Then con.Open()
                        reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            If IsDBNull(reader.Item("ItemCost")) Then
                                FIFOCost = 0
                            Else
                                FIFOCost = reader.Item("ItemCost")
                            End If
                            If IsDBNull(reader.Item("UpperLimit")) Then
                                NextUpperLimit = 0
                            Else
                                NextUpperLimit = reader.Item("UpperLimit")
                            End If
                            If IsDBNull(reader.Item("LowerLimit")) Then
                                NextLowerLimit = 0
                            Else
                                NextLowerLimit = reader.Item("LowerLimit")
                            End If
                        Else
                            NoCostTierFound = True
                            FIFOCost = 0
                            NextUpperLimit = 0
                            NextLowerLimit = 0
                        End If
                        reader.Close()
                        ''Check to make sure we hit a cost tier
                        If NextUpperLimit = -1 Then
                            NoCostTierFound = True
                        End If
                        ''Check to make sure we need to cost
                        If NoCostTierFound Then
                            QuantityRemaining = 0
                        Else
                            TempQuantity = (NextUpperLimit + 1) - NextLowerLimit

                            If QuantityRemaining > TempQuantity Then
                                'Add to existing FIFO Extended Amount
                                FIFOExtendedAmount = FIFOExtendedAmount + (TempQuantity * FIFOCost)

                                'Redefine Quantity Remaining after the next cost tier
                                QuantityRemaining = QuantityRemaining - TempQuantity
                                UpperLimit = NextUpperLimit
                            Else
                                FIFOExtendedAmount = FIFOExtendedAmount + (QuantityRemaining * FIFOCost)
                                QuantityRemaining = 0
                            End If
                        End If
                    Loop

                    'Run routine if no Cost Tier is retrieved - Use LPC, TC, STD Cost
                    If NoCostTierFound Then
                        cmd.CommandText = "DECLARE @MaxPONumber int = (SELECT isnull(MAX(PurchaseOrderHeaderKey), 0) FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber)" _
                        + " , @MaxTransNumber int = (SELECT isnull(MAX(TransactionNumber), 0) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber)" _
                        + " , @LastPurchaseCost float = 0.0, @TransactionCost float = 0.0" _
                        + " IF @MaxPONumber <> 0 BEGIN" _
                        + " SET @LastPurchaseCost = (SELECT CASE WHEN UnitCost is null THEN 0 ELSE UnitCost END FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND PurchaseOrderHeaderKey = @MaxPONumber) END" _
                        + " IF @LastPurchaseCost = 0 BEGIN" _
                        + " IF @MaxTransNumber <> 0 BEGIN" _
                        + " SET @TransactionCost = (SELECT CASE WHEN ItemCost IS NULL THEN 0 ELSE ItemCost END FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @MaxTransNumber)" _
                        + " IF @TransactionCost = 0 BEGIN SELECT StandardCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @PartNumber END" _
                        + " ELSE BEGIN SELECT @TransactionCost	END END" _
                        + " ELSE BEGIN SELECT isnull(StandardCost, 0) FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @PartNumber END END" _
                        + " ELSE BEGIN SELECT @LastPurchaseCost END"

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            FIFOCost = CDbl(cmd.ExecuteScalar)
                        Catch ex As System.Exception
                            FIFOCost = 0
                        End Try
                        con.Close()
                        FIFOExtendedAmount = FIFOCost * OrderQuantity
                    End If
                Else
                    'Entire quantity falls into one cost tier
                    FIFOExtendedAmount = FIFOCost * OrderQuantity
                End If
            End If

        End If
        Dim lst As New List(Of Double)
        lst.Add(Math.Round(FIFOExtendedAmount / dr.Item("PiecesProduced"), 5, MidpointRounding.AwayFromZero))
        lst.Add(Math.Round(FIFOExtendedAmount, 2, MidpointRounding.AwayFromZero))
        Return lst
    End Function

    Private Sub AddOriginalPartGLEntries(ByVal dr As Data.DataRow, ByVal con As SqlConnection, ByVal extendedCost As Double)
        Dim cmd As New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)
        With cmd.Parameters
            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Time Slip Posting"
            .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
            .Add("@GLTransactionDate", SqlDbType.Date).Value = dr.Item("PostingDate")
            .Add("@PostingDate", SqlDbType.VarChar).Value = dr.Item("PostingDate")
            .Add("@EmployeeID", SqlDbType.VarChar).Value = dr.Item("EmployeeID")
            .Add("@GLReferenceLine", SqlDbType.Int).Value = dr.Item("LineKey") + 200
            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = dr.Item("TimeSlipKey").ToString()
        End With

        If EmployeeCompanyCode.Equals("TST") Then
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        Else
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        End If
        'Write Values to General Ledger (DEBIT)
        cmd.CommandText += "(@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"

        cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12850"
        cmd.Parameters.Add("@GLTransactionComment", SqlDbType.VarChar).Value = "WIP Inventory Part Removal for FOX#" + dr.Item("FOXNumber").ToString()

        With cmd.Parameters
            .Add("GLTransactionDebitAmount", SqlDbType.Float).Value = Math.Abs(extendedCost)
            .Add("@GLTransactionCreditAmount", SqlDbType.Float).Value = 0
        End With

        'Write Values to General Ledger (CREDIT)
        cmd.CommandText += ", (@Key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment1, @DivisionID, @GLJournalID, @batch, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"

        If dr.Item("DivisionID").Equals("TWD") Then
            cmd.Parameters.Add("@GLAccountNumber1", SqlDbType.VarChar).Value = "12100"
            cmd.Parameters.Add("@GLTransactionComment1", SqlDbType.VarChar).Value = "Adding Inventory for FOX #" + dr.Item("FOXNumber").ToString()
        Else
            cmd.Parameters.Add("@GLAccountNumber1", SqlDbType.VarChar).Value = "12500"
            cmd.Parameters.Add("@GLTransactionComment1", SqlDbType.VarChar).Value = "Adjusting Inventory for FOX #" + dr.Item("FOXNumber").ToString()
        End If
        With cmd.Parameters
            .Add("@GLTransactionDebitAmount1", SqlDbType.Float).Value = 0
            .Add("@GLTransactionCreditAmount1", SqlDbType.Float).Value = Math.Abs(extendedCost)
        End With
        cmd.CommandText += " COMMIT TRAN; SET xact_abort off;"
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub AddOriginalPartRemovalTransaction(ByRef dr As Data.DataRow, ByVal con As SqlConnection, ByVal FIFOList As List(Of Double))
        Dim cmd As New SqlCommand("INSERT INTO InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ExtendedCost, ItemPrice, ExtendedAmount, DivisionID, TransactionMath, GLAccount)" _
                                  + " VALUES((SELECT isnull(MAX(TransactionNumber) + 1, 867500001) FROM InventoryTransactionTable), @TransactionDate, @Comment, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, (SELECT TOP 1 ShortDescription FROM ItemList WHERE ItemID = @PartNumber AND DivisionID = @DivisionID), (SELECT TOP 1 InventoryPieces FROM TimeSlipLineItemTable WHERE TimeSlipKey = @TransactionTypeNumber AND LineKey = @TransactionTypeLineNumber), @ItemCost, @ExtendedCost, 0, 0, @DivisionID, 'SUBTRACT', @GLAccount);", con)
        With cmd.Parameters
            .Add("@TransactionDate", SqlDbType.VarChar).Value = dr.Item("PostingDate")
            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = dr.Item("TimeSlipKey")
            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = dr.Item("LineKey") + 200
            .Add("@PartNumber", SqlDbType.VarChar).Value = dr.Item("OriginalPart")
            .Add("@ExtendedCost", SqlDbType.Float).Value = FIFOList(1)
            .Add("@GLAccount", SqlDbType.VarChar).Value = "12850"
            .Add("@Comment", SqlDbType.VarChar).Value = "Post Production Removal"
            .Add("@ItemCost", SqlDbType.Float).Value = FIFOList(0)
            .Add("@DivisionID", SqlDbType.VarChar).Value = dr.Item("DivisionID")
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub AddOriginalPartTimeSlipEntry(ByVal dr As Data.DataRow, ByVal con As SqlConnection, ByVal FIFOList As List(Of Double))
        Dim cmd As New SqlCommand("DECLARE @PieceWeight float = 0;" _
                                  + " IF EXISTS(SELECT isnull(PieceWeight, 0) as PieceWeight FROM ItemList WHERE ItemID = @PartNumber AND DivisionID = @DivisionID) SET @PieceWeight = (SELECT isnull(PieceWeight, 0) as PieceWeight FROM ItemList WHERE ItemID = @PartNumber AND DivisionID = @DivisionID);" _
                                  + " Insert Into TimeSlipLineItemTable(TimeSlipKey, LineKey, FOXNumber, MachineNumber, PartNumber, MachineHours, SetupHours, ToolingHours, OtherHours, TotalHours, PiecesProduced, LineWeight, ScrapWeight, InventoryPieces, RMID, ExtendedCost, Cost, DivisionID) Values" _
                                  + " (@TimeSlipKey, @LineKey, @FOXNumber,'RFP', @PartNumber, 0, 0, 0, 0, 0, @PiecesProduced, @PieceWeight * @PiecesProduced, 0, @PiecesProduced, '', @ExtendedCost, @Cost, @DivisionID)", con)

        With cmd.Parameters
            .Add("@TimeSlipKey", SqlDbType.Int).Value = Val(dr.Item("TimeSlipKey"))
            .Add("@LineKey", SqlDbType.Int).Value = Val(dr.Item("LineKey")) + 200
            .Add("@PostingDate", SqlDbType.Date).Value = dr.Item("PostingDate").ToString()
            .Add("@EmployeeID", SqlDbType.VarChar).Value = dr.Item("EmployeeID").ToString()
            .Add("@FOXNumber", SqlDbType.Int).Value = Val(dr.Item("FOXNumber"))
            .Add("@PartNumber", SqlDbType.VarChar).Value = dr.Item("OriginalPart")
            .Add("@PiecesProduced", SqlDbType.Float).Value = -1 * dr.Item("PiecesProduced")
            .Add("@DivisionID", SqlDbType.VarChar).Value = dr.Item("DivisionID")
            .Add("@Cost", SqlDbType.Float).Value = FIFOList(0)
            .Add("@ExtendedCost", SqlDbType.Float).Value = FIFOList(1)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSelected.Click
        Dim TimeSlipKey As Integer = 0

        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Time Slip?", "DELETE TIME SLIP", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Dim RowIndex As Integer = Me.dgvTimeSlipEntries.CurrentCell.RowIndex

            TimeSlipKey = Me.dgvTimeSlipEntries.Rows(RowIndex).Cells("TimeSlipKey").Value

            cmd = New SqlCommand("DELETE FROM TimeSlipHeaderTable WHERE TimeSlipKey = @TimeSlipKey", con)
            cmd.Parameters.Add("@TimeSlipKey", SqlDbType.VarChar).Value = TimeSlipKey

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            loadTimeSlipEntries()
        ElseIf button = DialogResult.No Then
            Exit Sub
        End If
    End Sub

End Class
