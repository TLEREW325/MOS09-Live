Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class TimeSlipPostingNew
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    'Declare Variable for form use
    Dim constLaborRate As Double = 28.0
    Dim constOverheadRate As Double = (constLaborRate * 0.75)
    Dim SteelCostPerPound As Double = 0
    Dim MachineRatePerHour As Double = 0
    Dim TotalExtendedCost, FoxStepPieceExtendedCost, SteelExtendedCost, MachineExtendedCost, OverheadExtendedCost, LaborExtendedCost As Double
    Dim FinishedGoodsPieceCost As Double = 0
    Dim CurrentRMID As String = ""
    Dim CurrentFOXNumber As Integer = 0
    Dim FOXStepPieceCost As Double = 0
    Dim TotalPieceCost As Double = 0












    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length > 399 Then
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub ShowTimesSlipLines()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM TimeSlipCombinedData WHERE Status = @Status ORDER BY EmployeeID", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "TimeSlipCombinedData")
        dgvTimeSlipEntries.DataSource = ds.Tables("TimeSlipCombinedData")
        con.Close()
    End Sub

    Private Sub TimeSlipPostingNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowTimesSlipLines()
    End Sub

    Private Sub cmdPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPost.Click
        'Update all fields (Extended Cost, Rate Fields)
        Dim LineTimeslipKey, LineLineKey As Integer
        Dim LineRMID As String = ""
        Dim LineTotalHours As Double = 0
        Dim LinePiecesProduced As Double = 0
        Dim LineInventoryPieces As Double = 0
        Dim LineLineWeight As Double = 0
        Dim LineScrapWeight As Double = 0
        Dim LinePartNumber As String = ""
        Dim LineADDToFG As String = ""
        Dim LineMachineCost As Double = 0
        Dim LineFOXNumber As Integer = 0

        'Update rows in database
        For Each LineRow As DataGridViewRow In dgvTimeSlipEntries.Rows
            Try
                LineTimeslipKey = LineRow.Cells("TimeSlipKeyColumn").Value
            Catch ex As System.Exception
                LineTimeslipKey = 0
            End Try
            Try
                LineLineKey = LineRow.Cells("LineKeyColumn").Value
            Catch ex As System.Exception
                LineLineKey = 0
            End Try
            Try
                LineRMID = LineRow.Cells("RMIDColumn").Value
            Catch ex As System.Exception
                LineRMID = ""
            End Try
            Try
                LineTotalHours = LineRow.Cells("TotalHoursColumn").Value
            Catch ex As System.Exception
                LineTotalHours = 0
            End Try
            Try
                LinePiecesProduced = LineRow.Cells("PiecesProducedColumn").Value
            Catch ex As System.Exception
                LinePiecesProduced = 0
            End Try
            Try
                LineInventoryPieces = LineRow.Cells("InventoryPiecesColumn").Value
            Catch ex As System.Exception
                LineInventoryPieces = 0
            End Try
            Try
                LineLineWeight = LineRow.Cells("LineWeightColumn").Value
            Catch ex As System.Exception
                LineLineWeight = 0
            End Try
            Try
                LineScrapWeight = LineRow.Cells("ScrapWeightColumn").Value
            Catch ex As System.Exception
                LineScrapWeight = 0
            End Try
            Try
                LineTotalHours = LineRow.Cells("TotalHoursColumn").Value
            Catch ex As System.Exception
                LineTotalHours = 0
            End Try
            Try
                LinePiecesProduced = LineRow.Cells("PiecesProducedColumn").Value
            Catch ex As System.Exception
                LinePiecesProduced = 0
            End Try
            Try
                LineInventoryPieces = LineRow.Cells("InventoryPiecesColumn").Value
            Catch ex As System.Exception
                LineInventoryPieces = 0
            End Try
            Try
                LinePartNumber = LineRow.Cells("PartNumberColumn").Value
            Catch ex As System.Exception
                LinePartNumber = 0
            End Try
            Try
                LineADDToFG = LineRow.Cells("ProcessAddFGColumn").Value
            Catch ex As System.Exception
                LineADDToFG = "NO"
            End Try
            Try
                LineFOXNumber = LineRow.Cells("FOXNumberColumn").Value
            Catch ex As System.Exception
                LineFOXNumber = 0
            End Try

            'If Line ADD To FG is "YES" then get steel cost
            If LineADDToFG = "YES" Then
                'Get Steel Cost
                CurrentRMID = LineRMID

                GetSteelCost()

                SteelExtendedCost = (LineLineWeight - LineScrapWeight) * SteelCostPerPound
                SteelExtendedCost = Math.Round(SteelExtendedCost, 2)

                'Get FOX Step Cost 
                CurrentFOXNumber = LineFOXNumber

                GetFOXStepPieceCost()

                FoxStepPieceExtendedCost = LinePiecesProduced * FOXStepPieceCost
                FoxStepPieceExtendedCost = Math.Round(FoxStepPieceExtendedCost, 2)
            Else
                SteelExtendedCost = 0
                SteelCostPerPound = 0
                FOXStepPieceCost = 0
                FoxStepPieceExtendedCost = 0
            End If

            'Calculate Machine Cost, Overhead Cost, and Labor Cost

            'Machine
            MachineRatePerHour = LineMachineCost
            MachineExtendedCost = MachineRatePerHour * LineTotalHours
            MachineExtendedCost = Math.Round(MachineExtendedCost, 2)

            'Labor
            LaborExtendedCost = constLaborRate * LineTotalHours
            LaborExtendedCost = Math.Round(LaborExtendedCost, 2)

            'Overhead
            OverheadExtendedCost = constOverheadRate * LineTotalHours
            OverheadExtendedCost = Math.Round(OverheadExtendedCost, 2)

            'Get Total Piece Cost
            TotalExtendedCost = MachineExtendedCost + LaborExtendedCost + OverheadExtendedCost + FoxStepPieceExtendedCost + SteelExtendedCost
            If LinePiecesProduced <> 0 Then
                TotalPieceCost = TotalExtendedCost / LinePiecesProduced
            Else
                TotalPieceCost = 0
            End If

            Try

            Catch ex As Exception

            End Try

            'Update Time Line Line Item Table
            cmd = New SqlCommand("UPDATE TimeSlipLineItemTableNew SET LaborExtendedCost = @LaborExtendedCost, OverheadExtendedCost = @OverheadExtendedCost, MachineExtendedCost = @MachineExtendedCost, SteelExtendedCost = @SteelExtendedCost, FOXStepExtendedCost = @FOXStepExtendedCost, TotalExtendedCost = @TotalExtendedCost, LaborRate = @LaborRate, OverheadRate = @OverheadRate, MachineRate = @MachineRate, SteelCostPerLB = @SteelCostPerLB, FOXStepCost = @FOXStepCost, TotalPieceCost = @TotalPieceCost WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey", con)

            With cmd.Parameters
                .Add("@TimeSlipKey", SqlDbType.VarChar).Value = LineTimeslipKey
                .Add("@LineKey", SqlDbType.VarChar).Value = LineLineKey
                .Add("@LaborExtendedCost", SqlDbType.VarChar).Value = LaborExtendedCost
                .Add("@OverheadExtendedCost", SqlDbType.VarChar).Value = OverheadExtendedCost
                .Add("@MachineExtendedCost", SqlDbType.VarChar).Value = MachineExtendedCost
                .Add("@SteelExtendedCost", SqlDbType.VarChar).Value = SteelExtendedCost
                .Add("@FOXStepExtendedCost", SqlDbType.VarChar).Value = FoxStepPieceExtendedCost
                .Add("@TotalExtendedCost", SqlDbType.VarChar).Value = TotalExtendedCost
                .Add("@LaborRate", SqlDbType.VarChar).Value = constLaborRate
                .Add("@OverheadRate", SqlDbType.VarChar).Value = constOverheadRate
                .Add("@MachineRate", SqlDbType.VarChar).Value = MachineRatePerHour
                .Add("@SteelCostPerLB", SqlDbType.VarChar).Value = SteelCostPerPound
                .Add("@FOXStepCost", SqlDbType.VarChar).Value = FOXStepPieceCost
                .Add("@TotalPieceCost", SqlDbType.VarChar).Value = TotalPieceCost
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            '*****************************************************************************
            'Post to General Ledger


































        Next
    End Sub

    Public Sub GetFOXStepPieceCost()
        'Get the summation of Total Cost for the FOX, excluding the finished goods step.
        'After, sum the number of pieces run, except for finished goods
        'Use the average cost to determine FOX Step Piece Cost
        'Only do this process for the current production run

        Dim MAXStepNumber As Integer = 0
        Dim FGStepNumber As Integer = 0

        'Get max fox step number - if it is one, then skip this and set FOXStepPieceCost to zero
        Dim GetMaxStepStatement As String = "SELECT MAX(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber"
        Dim GetMaxStepCommand As New SqlCommand(GetMaxStepStatement, con)
        GetMaxStepCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = CurrentFOXNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MAXStepNumber = CInt(GetMaxStepCommand.ExecuteScalar)
        Catch ex As Exception
            MAXStepNumber = 0
        End Try
        con.Close()

        'If Max Step Number is one, then no added fox costs are added
        If MAXStepNumber = 1 Then
            FOXStepPieceCost = 0
        ElseIf MAXStepNumber > 1 Then
            'Get finished goods step number
            Dim GetFGStepStatement As String = "SELECT ProcessStep FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY'"
            Dim GetFGStepCommand As New SqlCommand(GetFGStepStatement, con)
            GetFGStepCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = CurrentFOXNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FGStepNumber = CInt(GetFGStepCommand.ExecuteScalar)
            Catch ex As Exception
                FGStepNumber = 0
            End Try
            con.Close()

            'Get current production number
            Dim CurrentProductionNumber As Integer = 0

            Dim GetProductionNumberStatement As String = "SELECT ProductionNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN'"
            Dim GetProductionNumberCommand As New SqlCommand(GetProductionNumberStatement, con)
            GetProductionNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = CurrentFOXNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CurrentProductionNumber = CInt(GetProductionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                CurrentProductionNumber = 0
            End Try
            con.Close()

            'If Current Production Number = 0, then start a new production run
            If CurrentProductionNumber = 0 Then
                Dim GetLastProductionNumber, GetNextProductionNumber As Integer

                Dim GetLastNumberStatement As String = "SELECT MAX(ProductionNumber) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber"
                Dim GetLastNumberCommand As New SqlCommand(GetLastNumberStatement, con)
                GetLastNumberCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = CurrentFOXNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLastProductionNumber = CInt(GetLastNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetLastProductionNumber = 0
                End Try
                con.Close()

                GetNextProductionNumber = GetLastProductionNumber + 1

                'Create header table entry (Leave End Date as a null value)
                cmd = New SqlCommand("INSERT INTO FOXProductionNumberHeaderTable (ProductionNumber, FOXNumber, StartDate, ProductionQuantity, Status) values (@ProductionNumber, @FOXNumber, @StartDate, @ProductionQuantity, @Status)", con)

                With cmd.Parameters
                    .Add("@ProductionNumber", SqlDbType.VarChar).Value = GetNextProductionNumber
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = CurrentFOXNumber
                    .Add("@StartDate", SqlDbType.VarChar).Value = Now()
                    .Add("@ProductionQuantity", SqlDbType.VarChar).Value = 0
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Run Loop to create line table entries
                Dim LineCounter As Integer = 1

                For i As Integer = 1 To MAXStepNumber
                    'Get process ID for specific process step
                    Dim CurrentProcessID As String = ""
                    Dim CurrentProcessAddToFG As String = ""

                    Dim GetProcessIDStatement As String = "SELECT ProcessID FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep"
                    Dim GetProcessIDCommand As New SqlCommand(GetProcessIDStatement, con)
                    GetProcessIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = CurrentFOXNumber
                    GetProcessIDCommand.Parameters.Add("@ProcessStep", SqlDbType.VarChar).Value = LineCounter

                    Dim GetProcessFGStatement As String = "SELECT ProcessAddFG FROM FOXSched WHERE FOXNumber = @FOXNumber AND ProcessStep = @ProcessStep"
                    Dim GetProcessFGCommand As New SqlCommand(GetProcessFGStatement, con)
                    GetProcessFGCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = CurrentFOXNumber
                    GetProcessFGCommand.Parameters.Add("@ProcessStep", SqlDbType.VarChar).Value = LineCounter

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CurrentProcessID = CStr(GetProcessIDCommand.ExecuteScalar)
                    Catch ex As Exception
                        CurrentProcessID = ""
                    End Try
                    Try
                        CurrentProcessAddToFG = CStr(GetProcessFGCommand.ExecuteScalar)
                    Catch ex As Exception
                        CurrentProcessAddToFG = ""
                    End Try
                    con.Close()


                    'Create line table entry for all steps
                    cmd = New SqlCommand("INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, StartDate, ProductionQuantity, Status) values (@ProductionNumber, @FOXNumber, @StartDate, @ProductionQuantity, @Status)", con)

                    With cmd.Parameters
                        .Add("@ProductionNumber", SqlDbType.VarChar).Value = GetNextProductionNumber
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = CurrentFOXNumber
                        .Add("@ProcessStep", SqlDbType.VarChar).Value = LineCounter
                        .Add("@ProcessID", SqlDbType.VarChar).Value = CurrentProcessID
                        .Add("@ProcessAddFG", SqlDbType.VarChar).Value = CurrentProcessAddToFG
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    LineCounter = LineCounter + 1
                Next



            Else
                'Do nothing - production number is okay
            End If

            'Sum time slip entries for the specific fox and current production run.











        Else
            FOXStepPieceCost = 0
        End If
    End Sub

    Public Sub GetSteelCost()
        Dim SteelUsedToDate As Double = 0
        Dim SteelUsageDate As Date = Now()

        Dim SteelUsedToDateStatement As String = "SELECT SUM(UsageWeight) FROM SteelUsageTable WHERE RMID = @RMID AND UsageDate <= @UsageDate AND Status = 'POSTED'"
        Dim SteelUsedToDateCommand As New SqlCommand(SteelUsedToDateStatement, con)
        SteelUsedToDateCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CurrentRMID
        SteelUsedToDateCommand.Parameters.Add("@UsageDate", SqlDbType.VarChar).Value = SteelUsageDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelUsedToDate = CDbl(SteelUsedToDateCommand.ExecuteScalar)
        Catch ex As Exception
            SteelUsedToDate = 0
        End Try
        con.Close()

        'Find MAX Cost Tier by date
        Dim MAXTransactionDate As Date

        Dim MAXTransactionDateStatement As String = "SELECT MAX(CostingDate) FROM SteelCostingTable WHERE RMID = @RMID AND CostingDate <= @CostingDate AND @SteelUsedToDate BETWEEN LowerLimit AND UpperLimit"
        Dim MAXTransactionDateCommand As New SqlCommand(MAXTransactionDateStatement, con)
        MAXTransactionDateCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CurrentRMID
        MAXTransactionDateCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = SteelUsageDate
        MAXTransactionDateCommand.Parameters.Add("@SteelUsedToDate", SqlDbType.VarChar).Value = SteelUsedToDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MAXTransactionDate = CDate(MAXTransactionDateCommand.ExecuteScalar)
        Catch ex As Exception
            MAXTransactionDate = Now()
        End Try
        con.Close()

        'If multiple dates, get highest transaction number
        Dim MAXTransactionNumber As Integer = 0

        Dim MAXTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM SteelCostingTable WHERE RMID = @RMID AND CostingDate = @CostingDate AND @SteelUsedToDate BETWEEN LowerLimit AND UpperLimit"
        Dim MAXTransactionNumberCommand As New SqlCommand(MAXTransactionNumberStatement, con)
        MAXTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CurrentRMID
        MAXTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MAXTransactionDate
        MAXTransactionNumberCommand.Parameters.Add("@SteelUsedToDate", SqlDbType.VarChar).Value = SteelUsedToDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MAXTransactionNumber = CInt(MAXTransactionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            MAXTransactionNumber = 0
        End Try
        con.Close()

        'Get the steel cost of the tier
        Dim SteelCostPerPoundStatement As String = "SELECT SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND TransactionNumber = @TransactionNumber"
        Dim SteelCostPerPoundCommand As New SqlCommand(SteelCostPerPoundStatement, con)
        SteelCostPerPoundCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CurrentRMID
        SteelCostPerPoundCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXTransactionNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelCostPerPound = CDbl(SteelCostPerPoundCommand.ExecuteScalar)
        Catch ex As Exception
            SteelCostPerPound = 0
        End Try
        con.Close()

        If SteelCostPerPound = 0 Then
            'Get Steel Cost from Steel Receiving Lines
            Dim MAXSteelReceiver As Integer = 0

            Dim MAXSteelReceiverStatement As String = "SELECT MAX(SteelReceivingHeaderKey) FROM SteelReceivingLineQuery WHERE RMID = @RMID AND ReceivingDate <= @ReceivingDate AND ReceivingStatus = 'RECEIVED'"
            Dim MAXSteelReceiverCommand As New SqlCommand(MAXSteelReceiverStatement, con)
            MAXSteelReceiverCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CurrentRMID
            MAXSteelReceiverCommand.Parameters.Add("@ReceivingDate", SqlDbType.VarChar).Value = SteelUsageDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXSteelReceiver = CInt(MAXSteelReceiverCommand.ExecuteScalar)
            Catch ex As Exception
                MAXSteelReceiver = 0
            End Try
            con.Close()

            'Get steel Cost for that receiver
            Dim GetReceiverCostStatement As String = "SELECT SteelCostPerPound FROM SteelReceivingLineQuery WHERE RMID = @RMID AND ReceivingDate <= @ReceivingDate AND ReceivingStatus = 'RECEIVED'"
            Dim GetReceiverCostCommand As New SqlCommand(GetReceiverCostStatement, con)
            GetReceiverCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CurrentRMID
            GetReceiverCostCommand.Parameters.Add("@ReceivingDate", SqlDbType.VarChar).Value = SteelUsageDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SteelCostPerPound = CInt(GetReceiverCostCommand.ExecuteScalar)
            Catch ex As Exception
                SteelCostPerPound = 0
            End Try
            con.Close()
        Else
            'Do nothing - steel cost per pound is correct
        End If
    End Sub

    Public Sub AddToInventoryTransactionTable()

    End Sub

    Public Sub CreateCostTier()

    End Sub

    Public Sub RemovesBoxesFromInventory()

    End Sub

    Public Sub RemoveAluminumBallsFromInventory()

    End Sub

    Public Sub RemoveTWESteelFromInventory()

    End Sub





    Private Sub cmdDeleteSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSelected.Click
        If Me.dgvTimeSlipEntries.RowCount > 0 Then
            Dim RowTimeSlipKey, RowTimeSlipLineKey As Integer
    
            Dim RowIndex As Integer = Me.dgvTimeSlipEntries.CurrentCell.RowIndex

            Try
                RowTimeSlipKey = Me.dgvTimeSlipEntries.Rows(RowIndex).Cells("TimeSlipKeyColumn").Value
            Catch ex As Exception
                RowTimeSlipKey = 0
            End Try
            Try
                RowTimeSlipLineKey = Me.dgvTimeSlipEntries.Rows(RowIndex).Cells("LineKeyColumn").Value
            Catch ex As Exception
                RowTimeSlipLineKey = 0
            End Try

            If RowTimeSlipKey = 0 Or RowTimeSlipLineKey = 0 Then
                MsgBox("You must select a valid time slip in the datagrid.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this time slip?", "DELETE TIME SLIP", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'UPDATE Invoice Lines
                cmd = New SqlCommand("DELETE FROM TimeSlipLineItem WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey", con)

                With cmd.Parameters
                    .Add("@TimeSlipKey", SqlDbType.VarChar).Value = RowTimeSlipKey
                    .Add("@LineKey", SqlDbType.VarChar).Value = RowTimeSlipLineKey
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If

            'Refresh Datagrid
            ShowTimesSlipLines()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Using NewPrintTimeSlipPostings As New PrintTimeSlipPostings()
            Dim Result = NewPrintTimeSlipPostings.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvTimeSlipEntries_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTimeSlipEntries.CellContentClick

    End Sub
End Class
