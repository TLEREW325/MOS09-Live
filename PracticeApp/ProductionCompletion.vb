Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ProductionCompletion
    Dim ProductionNumber As Integer
    Dim FOXNumber As Integer
    Dim OverrideCancel As Boolean = False
    Dim bgwkFinalizeProductionRun As New System.ComponentModel.BackgroundWorker()
    Public IsRunning As Boolean = True
    Dim UseEOFYearDate As Boolean = False

    Private Class WIPStepSummary
        Public ProcessStep As Integer
        Public ProcessID As String
        Public MachineClass As String
        Public TotalPieces As Double
        Public PiecesPerHour As Double
        Public TotalExtendedCost As Double
        Public Sub New()
        End Sub
        Public Sub New(ByVal ProcStep As Integer, ByVal PiecesProduced As Double, ByVal PCSPerHour As Double, ByVal procID As String, ByVal TotExtendedCost As Double, ByVal MachClass As String)
            ProcessStep = ProcStep
            TotalPieces = PiecesProduced
            PiecesPerHour = PCSPerHour
            ProcessID = procID
            TotalExtendedCost = TotExtendedCost
            MachineClass = MachClass
        End Sub
    End Class

    Public Sub New()
    End Sub

    Public Sub New(ByVal ProdNumber As Integer, ByVal FOX As Integer, Optional ByVal AutoRun As Boolean = False, Optional ByVal ovr As Boolean = False, Optional ByVal useEndOfFiscal As Boolean = False)
        ProductionNumber = ProdNumber
        FOXNumber = FOX
        OverrideCancel = ovr
        UseEOFYearDate = useEndOfFiscal

        SetBGWK(AutoRun)
    End Sub

    Public Sub New(ByVal ProdNumber As String, ByVal FOX As String, Optional ByVal AutoRun As Boolean = False, Optional ByVal ovr As Boolean = False, Optional ByVal useEndOfFiscal As Boolean = False)
        ProductionNumber = Val(ProdNumber)
        FOXNumber = Val(FOX)
        OverrideCancel = ovr
        UseEOFYearDate = useEndOfFiscal

        SetBGWK(AutoRun)
    End Sub

    Public Sub New(ByVal ProdNumber As Object, ByVal FOX As Object, Optional ByVal AutoRun As Boolean = False, Optional ByVal ovr As Boolean = False, Optional ByVal useEndOfFiscal As Boolean = False)
        If TypeOf ProdNumber Is System.String Then
            ProductionNumber = Val(ProdNumber)
        ElseIf TypeOf ProdNumber Is Integer Then
            ProductionNumber = ProdNumber
        ElseIf TypeOf ProdNumber Is Double Then
            ProductionNumber = ProdNumber
        Else
            ProductionNumber = 0
        End If

        If TypeOf FOX Is System.String Then
            FOXNumber = Val(FOX)
        ElseIf TypeOf FOX Is Integer Then
            FOXNumber = FOX
        ElseIf TypeOf FOX Is Double Then
            FOXNumber = FOX
        Else
            FOXNumber = 0
        End If
        OverrideCancel = ovr

        UseEOFYearDate = useEndOfFiscal

        If ProductionNumber = 0 Or FOXNumber = 0 Then
            If ProductionNumber = 0 And FOXNumber = 0 Then
                sendErrorToDataBase("ProductionCompletion - New --Error trying to type FOX or ProductionNumber", "FOX #" + FOX.ToString(), "Production #" + ProdNumber.ToString(), New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30"))
            End If
            IsRunning = False
        Else
            SetBGWK(AutoRun)
        End If

    End Sub

    Private Sub SetBGWK(ByVal Autorun As Boolean)
        bgwkFinalizeProductionRun.WorkerSupportsCancellation = True
        AddHandler bgwkFinalizeProductionRun.DoWork, AddressOf bgwkFinalizeProductionRun_DoWork
        ''automatically starts the accoutning adjustments if set to true
        If Autorun Then
            Run()
        End If
    End Sub

    Public Sub Run()
        bgwkFinalizeProductionRun.RunWorkerAsync()
    End Sub

    Private Sub bgwkFinalizeProductionRun_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim con As New SqlConnection("Data Source=TFP-SQL; Async=True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        ''Gets the FOX step summary for the given FOX and production number
        Dim cmd As New SqlCommand("DECLARE  @AddFGStep as int = (SELECT ProcessStep FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND ProcessAddFG = 'ADDINVENTORY');" _
                                  + " SELECT FOXNumber, ProcessStep, ProcessID, MachineTable.MachineClass, case when ProcessStep = @AddFGStep then PiecesProduced else PiecesProduced - InventoryPieces END as PiecesProduced, CASE WHEN PiecesProduced = 0 AND TotalHours = 0 THEN 0 ELSE (CASE WHEN (PiecesProduced = 0) THEN 1 ELSE PiecesProduced END) / (case when (TotalHours = 0) then 1 else TotalHours END) END as PiecesPerHour, TotalExtendedCost FROM (SELECT ProductionSteps.FOXNumber, ProcessStep, ProcessID, SUM(isnull(TimeSlipLineItemTable.PiecesProduced, 0)) as PiecesProduced,  SUM(isnull(TimeSlipLineItemTable.InventoryPieces, 0)) as InventoryPieces, SUM(isnull(TimeSlipLineItemTable.TotalHours, 0)) as TotalHours, SUM(isnull(TimeSlipLineItemTable.ExtendedCost, 0)) as TotalExtendedCost FROM (SELECT FOXNumber, ProcessStep, ProcessID, ProductionNumber FROM FOXProductionNumberSched WHERE FOXProductionNumberSched.FOXNumber = @FOXNumber AND FOXProductionNumberSched.ProductionNumber = @ProductionNumber AND ProcessStep <= @AddFGStep) as  ProductionSteps  LEFT OUTER JOIN TimeSlipLineItemTable ON ProductionSteps.FOXNumber = TimeSlipLineItemTable.FOXNumber AND ProductionSteps.ProcessStep = TimeSlipLineItemTable.FOXStep AND ProductionSteps.ProductionNumber = TimeSlipLineItemTable.ProductionNumber GROUP BY ProductionSteps.FOXNumber, ProductionSteps.ProcessStep, ProcessID) as Production LEFT OUTER JOIN MachineTable ON Production.ProcessID = MachineTable.MachineID ORDER BY Production.ProcessStep DESC;", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = FOXNumber
        cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = ProductionNumber

        Dim stepList As New List(Of WIPStepSummary)
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                stepList.Add(New WIPStepSummary(reader.Item("ProcessStep"), reader.Item("PiecesProduced"), reader.Item("PiecesPerHour"), reader.Item("ProcessID"), reader.Item("TotalExtendedCost"), reader.Item("MachineClass")))
            End While
        End If
        reader.Close()


        ''check to see if there are any steps in the FOX steps
        If stepList.Count > 0 Then
            cmd.CommandText = "SELECT isnull(SUM(InventoryPieces), 0) FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber"
            Dim FGTotalPieces As Double = Val(cmd.ExecuteScalar())

            Dim GLCount As Integer = 0
            Dim GLcmd As New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList), @batch as int = (SELECT isnull(MAX(GLBatchNumber) + 1, 220001) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)
            With GLcmd.Parameters
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "FOX Production Completion"
                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
            End With

            If EmployeeCompanyCode.Equals("TST") Then
                GLcmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            Else
                GLcmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            End If


            If FGTotalPieces > 0 Or OverrideCancel Then
                For i As Integer = 1 To stepList.Count - 1
                    ''checks to see if the current line is above the FG amount. If so will add new time slip entries to adjust ot FG amount and will cost out the difference from WIP to Cost of Sales
                    If stepList(i).TotalPieces > FGTotalPieces Then
                        Dim difference As Double = stepList(i).TotalPieces - FGTotalPieces
                        Dim CostDifference As Double = Math.Round((difference / stepList(i).TotalPieces) * stepList(i).TotalExtendedCost, 2, MidpointRounding.AwayFromZero)
                        cmd = New SqlCommand("DECLARE @TimeSlipKey as int = (SELECT isnull(MAX(TimeSlipKey) + 1, 1) FROM TimeSlipHeaderTable); INSERT INTO TimeSlipHeaderTable (TimeSlipKey, PostingDate, EmployeeID, Shift, DivisionID, Status, EmployeeName, PrintDate) VALUES (@TimeSlipKey, @PostingDate, 'ADMIN', 1, 'TWD', 'POSTED', 'OVERAGE ADJUSTMENT', @PrintDate); INSERT INTO TimeSlipLineItemTable (TimeSlipKey, LineKey, FOXNumber, MachineNumber, PartNumber, MachineHours, SetupHours, ToolingHours, OtherHours, TotalHours, PiecesProduced, LineWeight, ScrapWeight, InventoryPieces, RMID, ExtendedCost, Cost, FOXStep, DivisionID, ExtendedSteelCost, ProductionNumber, PostedSpecial, PostingChangeComment) SELECT @TimeSlipKey, 1, @FOXNumber, @MachineNumber, PartNumber, @TotalHours, 0, 0, 0, @TotalHours, @PiecesProduced, ROUND((isnull(FinishedWeight, 0) / 1000) * @PiecesProduced, 4), 0, 0, ScheduledRMID, @ExtendedCost, ROUND(ABS(@ExtendedCost) / ABS(@PiecesProduced), 5), @ProcessStep, DivisionID, 0, @ProductionNumber, 'True', 'FOX Completion Overage Adjustment' FROM FOXTable WHERE FOXNumber = @FOXNumber; SELECT @TimeSlipKey;", con)
                        With cmd.Parameters
                            .Add("@FOXNumber", SqlDbType.Int).Value = FOXNumber
                            .Add("@ProductionNumber", SqlDbType.Int).Value = ProductionNumber
                            .Add("@PiecesProduced", SqlDbType.Float).Value = -1 * difference
                            .Add("@TotalHours", SqlDbType.Float).Value = -1 * Math.Round(difference / stepList(i).PiecesPerHour, 2)
                            .Add("@MachineNumber", SqlDbType.VarChar).Value = stepList(i).ProcessID
                            .Add("@ExtendedCost", SqlDbType.Float).Value = -1 * CostDifference
                            .Add("@ProcessStep", SqlDbType.Int).Value = stepList(i).ProcessStep
                        End With
                        If UseEOFYearDate Then
                            cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime2).Value = New Date(Now.Year, 4, 30)
                            cmd.Parameters.Add("@PostingDate", SqlDbType.Date).Value = New Date(Now.Year, 4, 30)
                        Else
                            cmd.Parameters.Add("@PostingDate", SqlDbType.Date).Value = Now
                            cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime2).Value = Now
                        End If

                        If con.State = ConnectionState.Closed Then con.Open()
                        Dim TimeSlipKey As Integer = cmd.ExecuteScalar()
                        If GLCount = 0 Then
                            GLcmd.CommandText += String.Concat("(@Key +", GLCount.ToString, ", @GLAccountNumber", GLCount.ToString, ", @GLTransactionDescription, @GLTransactionDate", GLCount.ToString, ", @GLTransactionDebitAmount", GLCount.ToString, ", @GLTransactionCreditAmount", GLCount.ToString, ",  @GLTransactionComment", GLCount.ToString, ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber", GLCount.ToString, ", @GLReferenceLine", GLCount.ToString, ", @GLTransactionStatus)")
                        Else
                            GLcmd.CommandText += String.Concat(", (@Key +", GLCount.ToString, ", @GLAccountNumber", GLCount.ToString, ", @GLTransactionDescription, @GLTransactionDate", GLCount.ToString, ", @GLTransactionDebitAmount", GLCount.ToString, ", @GLTransactionCreditAmount", GLCount.ToString, ",  @GLTransactionComment", GLCount.ToString, ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber", GLCount.ToString, ", @GLReferenceLine", GLCount.ToString, ", @GLTransactionStatus)")
                        End If
                        With GLcmd.Parameters
                            .Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "12800"
                            .Add("@GLTransactionDebitAmount" + GLCount.ToString, SqlDbType.Float).Value = 0
                            .Add("@GLTransactionCreditAmount" + GLCount.ToString, SqlDbType.Float).Value = CostDifference
                            .Add("@GLTransactionComment" + GLCount.ToString, SqlDbType.VarChar).Value = "FOX Production Completion Overage Adjustment"
                            .Add("@GLReferenceNumber" + GLCount.ToString, SqlDbType.Int).Value = TimeSlipKey
                            .Add("@GLReferenceLine" + GLCount.ToString, SqlDbType.Int).Value = 1

                        End With

                        If UseEOFYearDate Then
                            GLcmd.Parameters.Add("@GLTransactionDate" + GLCount.ToString, SqlDbType.Date).Value = New Date(Now.Year, 4, 30)
                        Else
                            GLcmd.Parameters.Add("@GLTransactionDate" + GLCount.ToString, SqlDbType.Date).Value = Now
                        End If
                        GLCount += 1

                        GLcmd.CommandText += String.Concat(", (@Key + ", GLCount.ToString, ", @GLAccountNumber", GLCount.ToString, ", @GLTransactionDescription, @GLTransactionDate", GLCount.ToString, ", @GLTransactionDebitAmount", GLCount.ToString, ", @GLTransactionCreditAmount", GLCount.ToString, ",  @GLTransactionComment", GLCount.ToString, ", @DivisionID, @GLJournalID, @batch, @GLReferenceNumber", GLCount.ToString, ", @GLReferenceLine", GLCount.ToString, ", @GLTransactionStatus)")
                        With GLcmd.Parameters
                            .Add("@GLAccountNumber" + GLCount.ToString, SqlDbType.VarChar).Value = "51000"
                            .Add("@GLTransactionDebitAmount" + GLCount.ToString, SqlDbType.Float).Value = CostDifference
                            .Add("@GLTransactionCreditAmount" + GLCount.ToString, SqlDbType.Float).Value = 0
                            .Add("@GLTransactionComment" + GLCount.ToString, SqlDbType.VarChar).Value = "FOX Production Completion Overage Adjustment"
                            .Add("@GLReferenceNumber" + GLCount.ToString, SqlDbType.Int).Value = TimeSlipKey
                            .Add("@GLReferenceLine" + GLCount.ToString, SqlDbType.Int).Value = 1
                        End With
                        If UseEOFYearDate Then
                            GLcmd.Parameters.Add("@GLTransactionDate" + GLCount.ToString, SqlDbType.Date).Value = New Date(Now.Year, 4, 30)
                        Else
                            GLcmd.Parameters.Add("@GLTransactionDate" + GLCount.ToString, SqlDbType.Date).Value = Now
                        End If
                        GLCount += 1
                    End If
                Next
                If GLCount > 0 Then
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
                                sendErrorToDataBase("ProductionCompletion - ProductionAdjustment --Error trying to insert Adjustment GL Entries into GLTransactionMasterList.", "Production Completion", ex.ToString(), con)
                            End Try
                        Else
                            sendErrorToDataBase("ProductionCompletion - ProductionAdjustment --Error trying to insert Adjustment GL Entries into GLTransactionMasterList.", "Production Completion", exSQL.ToString(), con)
                        End If
                    Catch ex As System.Exception
                        sendErrorToDataBase("ProductionCompletion - ProductionAdjustment --Error trying to insert  Adjustment GL Entries into GLTransactionMasterList.", "Production Completion", ex.ToString(), con)
                    End Try
                End If
            Else
                sendErrorToDataBase("ProductionCompletion - ProductionAdjustment --FOX did not add to inventory. Production #" + ProductionNumber.ToString(), "FOX #" + FOXNumber.ToString(), "FOX did not add any inventory.", con)
            End If
        End If
        cmd = New SqlCommand("UPDATE FOXProductionNumberHeaderTable SET Status = 'CLOSED', EndDate = @EndDate WHERE ProductionNumber = @ProductionNumber AND FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = FOXNumber
        cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = ProductionNumber
        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = Now

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()

        If con.State = ConnectionState.Open Then con.Close()
        IsRunning = False
    End Sub

    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String, ByVal con As SqlConnection)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If
        Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Now
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
End Class
