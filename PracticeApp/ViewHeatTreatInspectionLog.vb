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
Public Class ViewHeatTreatInspectionLog
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim ds As DataSet


    Public Sub New()
        InitializeComponent()

        LoadFOXNumber()
        LoadLotNumber()
        LoadHeatNumber()
        LoadCustomerID()
        LoadBlueprint()
        LoadBatchNumber()
        LoadCarbon()
        LoadFinishedDiameter()
        LoadAnnealLot()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable;", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboFOXNumber.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()

    End Sub

    Public Sub LoadLotNumber()
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber;", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboLotNumber.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Public Sub LoadHeatNumber()
        cmd = New SqlCommand("SELECT DISTINCT(HeatNumber) FROM HeatNumberLog;", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboHeatNumber.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Public Sub LoadCustomerID()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE (DivisionID = 'TFP' OR DivisionID = 'TWD') AND CustomerClass <> 'DE-ACTIVATED' ORDER BY CustomerID;", con)

        Dim ds4 As New DataSet()
        Dim myAdapter4 As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "CustomerList")

        cboCustomerID.DisplayMember = "CustomerID"
        cboCustomerName.DisplayMember = "CustomerName"
        cboCustomerID.DataSource = ds4.Tables("CustomerList")
        cboCustomerName.DataSource = ds4.Tables("CustomerList")
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadBlueprint()
        cmd = New SqlCommand("SELECT DISTINCT(BlueprintNumber) FROM FOXTable;", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboBlueprint.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadBatchNumber()
        cmd = New SqlCommand("SELECT DISTINCT(BatchNumber) FROM HeatTreatInspectionLog", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboDAQBatchNumber.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()

    End Sub

    Public Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT(Carbon) as Carbon FROM RawMaterialsTable;", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboGrade.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Public Sub LoadFinishedDiameter()
        cmd = New SqlCommand("SELECT DISTINCT(FinishDiameter) as FinishDiameter FROM HeatTreatInspectionLog;", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboFinishedSize.Items.Add(reader.Item(0))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Private Sub LoadAnnealLot()
        cmd = New SqlCommand("SELECT DISTINCT(AnnealLot) FROM CharterSteelCoilIdentification", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                cboAnnealLot.Items.Add(reader.Item("AnnealLot"))
            End While
        End If
        reader.Close()
    End Sub

    Public Sub ClearData()

        cboFOXNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cboFOXNumber.Text = ""
        End If
        cboGrade.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboGrade.Text) Then
            cboGrade.Text = ""
        End If
        cboLotNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboLotNumber.Text) Then
            cboLotNumber.Text = ""
        End If
        cboFinishedSize.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFinishedSize.Text) Then
            cboFinishedSize.Text = ""
        End If
        cboHeatNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboHeatNumber.Text) Then
            cboHeatNumber.Text = ""
        End If
        cboCustomerID.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCustomerID.Text) Then
            cboCustomerID.Text = ""
        End If
        cboBlueprint.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboBlueprint.Text) Then
            cboBlueprint.Text = ""
        End If
        cboCustomerName.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCustomerName.Text) Then
            cboCustomerName.Text = ""
        End If
        cboProcessType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboProcessType.Text) Then
            cboProcessType.Text = ""
        End If
        cboDAQBatchNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboDAQBatchNumber.Text) Then
            cboDAQBatchNumber.Text = ""
        End If
        cboAnnealLot.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboAnnealLot.Text) Then
            cboAnnealLot.Text = ""
        End If

        txtWeightTotal.Clear()

        chkUseDates.Checked = False

        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now

        cboCustomerID.Focus()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Dim isFirst As Boolean = True
        cmd = New SqlCommand("SELECT HeatTreatInspectionLog.HeatTreatRecordNumber as [Heat Record #], HeatNumber as [Heat #], FOXNumber as [FOX #], BatchNumber as [DAQ Batch #], CreationDate as [Creation Date], LotNumber as [Lot #], RMID, PartNumber as [Part #], CustomerID as [Customer ID], AnnealLotNumber as [Anneal Lot #], FinishDiameter as [Finish Diameter], WeightPerLoad as [Weight Per Load], ProcessDescription as [Process Description], ProgramDescription as [Program Description], BlueprintNumber as [Blueprint #], Comments, AustenizingFurnace as [Austenizing Fernace], AustenizingTemperature as [Austenizing Temperature], AustenizingTime as [Austenizing Time], TemperingTemperature as [Tempering Temperature], TemperingTime as [Tempering Time], CoreScaleMeanAvg as [Core Scale Mean Average], Surface1MeanAvg as [Surface Scale 1 Mean Average], Surface2MeanAvg as [Surface Scale 2 Mean Average], OperatorName as [Operator Name], Shift, QuenchTemperature as [Quench Temperature], Signoff1 as [Signoff 1], Signoff2 as [Signoff 2], Signoff3 as [Signoff 3], Status FROM HeatTreatInspectionLog LEFT OUTER JOIN  HeatTreatTemperatureDraw ON HeatTreatInspectionLog.HeatTreatRecordNumber = HeatTreatTemperatureDraw.HeatTreatRecordNumber LEFT OUTER JOIN (SELECT HTLog.HeatTreatRecordNumber, isnull(CoreTotalAverage,0) / isnull(CoreLines,1) as CoreScaleMeanAvg, isnull(Surface1TotalAverage,0) / isnull(Surface1Lines,1) as Surface1MeanAvg, isnull(Surface2TotalAverage,0) / isnull(Surface2Lines,1) as Surface2MeanAvg FROM (SELECT HeatTreatRecordNumber FROM HeatTreatInspectionLog) as HTLog LEFT OUTER JOIN (SELECT HeatTreatRecordNumber, SUM(LineAverage) as CoreTotalAverage, MAX(SampleNumber) as CoreLines FROM HeatTreatRockwellTest WHERE TestType = 'Core Scale' GROUP BY HeatTreatRecordNumber) as CoreAvg ON HTLog.HeatTreatRecordNumber = CoreAvg.HeatTreatRecordNumber LEFT OUTER JOIN (SELECT HeatTreatRecordNumber, SUM(LineAverage) as Surface1TotalAverage, MAX(SampleNumber) as Surface1Lines FROM HeatTreatRockwellTest WHERE TestType = 'Surface Scale 1' GROUP BY HeatTreatRecordNumber) as Surf1Avg ON Surf1Avg.HeatTreatRecordNumber = HTLog.HeatTreatRecordNumber LEFT OUTER JOIN (SELECT HeatTreatRecordNumber, SUM(LineAverage) as Surface2TotalAverage, MAX(SampleNumber) as Surface2Lines FROM HeatTreatRockwellTest WHERE TestType = 'Surface Scale 2' GROUP BY HeatTreatRecordNumber) as Surf2Avg ON Surf2Avg.HeatTreatRecordNumber = HTLog.HeatTreatRecordNumber) as HeatTreatRockwellTest on HeatTreatInspectionLog.HeatTreatRecordNumber = HeatTreatRockwellTest.HeatTreatRecordNumber", con)
        If String.IsNullOrEmpty(cboCustomerID.Text) = False Then
            If isFirst Then
                cmd.CommandText += " WHERE CustomerID = @CustomerID"
                isFirst = False
            Else
                cmd.CommandText += " AND CustomerID = @CustomerID"
            End If
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        End If
        If Not String.IsNullOrEmpty(cboGrade.Text) Then
            If isFirst Then
                cmd.CommandText += " WHERE RMID Like @Grade"
                isFirst = False
            Else
                cmd.CommandText += " AND RMID Like @Grade"
            End If
            cmd.Parameters.Add("@Grade", SqlDbType.VarChar).Value = cboGrade.Text + "%"
        End If
        If Not String.IsNullOrEmpty(cboFinishedSize.Text) Then
            If isFirst Then
                cmd.CommandText += " WHERE FinishDiameter = @FinishDiameter"
                isFirst = False
            Else
                cmd.CommandText += " AND FinishDiameter = @FinishDiameter"
            End If
            cmd.Parameters.Add("@FinishDiameter", SqlDbType.VarChar).Value = cboFinishedSize.Text
        End If
        If String.IsNullOrEmpty(cboLotNumber.Text) = False Then
            If isFirst Then
                cmd.CommandText += " WHERE LotNumber like @LotNumber"
                isFirst = False
            Else
                cmd.CommandText += " AND LotNumber like @LotNumber"
            End If
            cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = cboLotNumber.Text + "%"
        End If

        If String.IsNullOrEmpty(cboBlueprint.Text) = False Then
            If isFirst Then
                cmd.CommandText += " WHERE BlueprintNumber = @BlueprintNumber"
                isFirst = False
            Else
                cmd.CommandText += " AND BlueprintNumber = @BlueprintNumber"
            End If
            cmd.Parameters.Add("@BlueprintNumber", SqlDbType.VarChar).Value = cboBlueprint.Text
        End If
        If String.IsNullOrEmpty(cboFOXNumber.Text) = False Then
            If isFirst Then
                cmd.CommandText += " WHERE FOXNumber = @FOXNumber"
                isFirst = False
            Else
                cmd.CommandText += " AND FOXNumber = @FOXNumber"
            End If
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        End If
        If String.IsNullOrEmpty(cboHeatNumber.Text) = False Then
            If isFirst Then
                cmd.CommandText += " WHERE HeatNumber = @HeatNumber"
                isFirst = False
            Else
                cmd.CommandText += " AND HeatNumber = @HeatNumber"
            End If
            cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = cboHeatNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboProcessType.Text) Then
            If isFirst Then
                cmd.CommandText += " WHERE ProcessDescription = @ProcessDescription"
                isFirst = False
            Else
                cmd.CommandText += " AND ProcessDescription = @ProcessDescription"
            End If
            cmd.Parameters.Add("@ProcessDescription", SqlDbType.VarChar).Value = cboProcessType.Text
        End If
        If Not String.IsNullOrEmpty(cboDAQBatchNumber.Text) Then
            If isFirst Then
                cmd.CommandText += " WHERE BatchNumber = @BatchNumber"
                isFirst = False
            Else
                cmd.CommandText += " AND BatchNumber = @BatchNumber"
            End If
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboDAQBatchNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboAnnealLot.Text) Then
            If isFirst Then
                cmd.CommandText += " WHERE AnnealLotNumber = @AnnealLotNumber"
                isFirst = False
            Else
                cmd.CommandText += " AND AnnealLotNumber = @AnnealLotNumber"
            End If
            cmd.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = cboAnnealLot.Text
        End If
        If chkUseDates.Checked Then
            If isFirst Then
                cmd.CommandText += " WHERE CreationDate BETWEEN @BeginDate AND @EndDate"
                isFirst = False
            Else
                cmd.CommandText += " AND CreationDate BETWEEN @BeginDate AND @EndDate"
            End If
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value.Date
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value.Date
        End If
        cmd.CommandText += " ORDER BY HeatTreatInspectionLog.HeatTreatRecordNumber;"

        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "HeatTreatInspectionLog")
        con.Close()

        dgvHeatTreatLog.DataSource = ds.Tables("HeatTreatInspectionLog")

        LoadTotal()
    End Sub

    Public Sub LoadTotal()
        Dim WeightTotal As Double = 0

        Dim DateFilter, AnnealFilter, BatchFilter, ProcessFilter, HeatFilter, FOXFilter, BlueprintFilter, LotFilter, FinishDiameterFilter, GradeFilter, CustomerFilter As String

        If cboAnnealLot.Text <> "" Then
            AnnealFilter = " AND AnnealLotNumber = '" + cboAnnealLot.Text + "'"
        Else
            AnnealFilter = ""
        End If
        If cboProcessType.Text <> "" Then
            ProcessFilter = " AND ProcessDescription = '" + cboProcessType.Text + "'"
        Else
            ProcessFilter = ""
        End If
        If cboDAQBatchNumber.Text <> "" Then
            BatchFilter = " AND BatchNumber = '" + cboDAQBatchNumber.Text + "'"
        Else
            BatchFilter = ""
        End If
        If cboHeatNumber.Text <> "" Then
            HeatFilter = " AND HeatNumber = '" + cboHeatNumber.Text + "'"
        Else
            HeatFilter = ""
        End If
        If cboFOXNumber.Text <> "" Then
            FOXFilter = " AND FOXNumber = '" + cboFOXNumber.Text + "'"
        Else
            FOXFilter = ""
        End If
        If cboBlueprint.Text <> "" Then
            BlueprintFilter = " AND BlueprintNumber = '" + cboBlueprint.Text + "'"
        Else
            BlueprintFilter = ""
        End If
        If cboLotNumber.Text <> "" Then
            LotFilter = " AND LotNumber = '" + cboLotNumber.Text + "'"
        Else
            LotFilter = ""
        End If
        If cboFinishedSize.Text <> "" Then
            FinishDiameterFilter = " AND FinishDiameter = '" + cboFinishedSize.Text + "'"
        Else
            FinishDiameterFilter = ""
        End If
        If cboGrade.Text <> "" Then
            GradeFilter = " AND RMID LIKE '" + cboGrade.Text + "%'"
        Else
            GradeFilter = ""
        End If
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + cboCustomerID.Text + "'"
        Else
            CustomerFilter = ""
        End If
        If chkUseDates.Checked = True Then
            DateFilter = " AND CreationDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        Dim WeightTotalStatement As String = "SELECT SUM(WeightPerLoad) FROM HeatTreatInspectionLog WHERE DivisionID <> 'ADM'" + AnnealFilter + BatchFilter + ProcessFilter + HeatFilter + FOXFilter + BlueprintFilter + LotFilter + FinishDiameterFilter + GradeFilter + CustomerFilter + DateFilter
        Dim WeightTotalCommand As New SqlCommand(WeightTotalStatement, con)
        WeightTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        WeightTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            WeightTotal = CDbl(WeightTotalCommand.ExecuteScalar)
        Catch ex As Exception
            WeightTotal = 0
        End Try
        con.Close()

        txtWeightTotal.Text = WeightTotal
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdOpenHeatTreatLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenHeatTreatLog.Click
        Dim NewHeatTreatDataForm As New HeatTreatDataForm
        If dgvHeatTreatLog.CurrentCell Is Nothing Then
            NewHeatTreatDataForm.Show()
        Else
            NewHeatTreatDataForm.Show()
            NewHeatTreatDataForm.cboHeatTreatFileNumber.Text = dgvHeatTreatLog.Rows(dgvHeatTreatLog.CurrentCell.RowIndex).Cells("Heat Record #").Value.ToString()
        End If

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        dgvHeatTreatLog.DataSource = Nothing
    End Sub

    Private Sub cmdPrintCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintCert.Click
        If canPrintCert() Then
            If dgvHeatTreatLog.SelectedRows.Count > 1 Then
                Dim heats(dgvHeatTreatLog.SelectedRows.Count - 1) As String
                For i As Integer = 0 To dgvHeatTreatLog.SelectedRows.Count - 1
                    heats(i) = dgvHeatTreatLog.SelectedRows(i).Cells("Heat Record #").Value.ToString()
                Next
                Dim newPrintHTCert As New PrintHeatTreatCert(heats)
                newPrintHTCert.ShowDialog()
            Else
                If dgvHeatTreatLog.SelectedCells.Count = 1 Then
                    Dim newPrintHTCert As New PrintHeatTreatCert(dgvHeatTreatLog.Rows(dgvHeatTreatLog.CurrentCell.RowIndex).Cells("Heat Record #").Value.ToString())
                    newPrintHTCert.ShowDialog()
                Else
                    Dim heats As New List(Of String)
                    Dim rowIndexes As New List(Of Integer)
                    For i As Integer = 0 To dgvHeatTreatLog.SelectedCells.Count - 1
                        If Not rowIndexes.Contains(dgvHeatTreatLog.Rows(dgvHeatTreatLog.SelectedCells(i).RowIndex).Cells("Heat Record #").Value) Then
                            heats.Add(dgvHeatTreatLog.Rows(dgvHeatTreatLog.SelectedCells(i).RowIndex).Cells("Heat Record #").Value.ToString())
                        End If
                    Next
                    Dim newPrintHTCert As New PrintHeatTreatCert(heats.ToArray())
                    newPrintHTCert.ShowDialog()
                End If

            End If
        End If
    End Sub

    Private Function canPrintCert() As Boolean
        If dgvHeatTreatLog.Rows.Count = 0 Then
            MessageBox.Show("There are no selected rows to create a Certification.", "No Selected rows", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvHeatTreatLog.SelectedRows.Count > 1 Then
            Dim partNumber As String = dgvHeatTreatLog.SelectedRows(0).Cells("Part #").Value
            For i As Integer = 0 To dgvHeatTreatLog.SelectedRows.Count - 1
                If Not partNumber.Equals(dgvHeatTreatLog.SelectedRows(i).Cells("Part #").Value) Then
                    MessageBox.Show("Selected do not all have the same Part Number. All rows must be the same part to create a Certification.", "Unable to create Certification.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                If Not dgvHeatTreatLog.SelectedRows(i).Cells("Status").Value.ToString.Equals("LOCKED") Then
                    MessageBox.Show("Heat Treat data for record # " + dgvHeatTreatLog.SelectedRows(i).Cells("Heat Record #n").Value.ToString + " is not locked. Unable to print Certification.", "Unable to print Certification", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                If dgvHeatTreatLog.SelectedRows(i).Cells("Process Description").Value.ToString.Contains("Anneal") Then
                    MessageBox.Show("Heat Treat data for record # " + dgvHeatTreatLog.SelectedRows(i).Cells("Heat Record #").Value.ToString + " is an Anneal. Unable to print Certification.", "Unable to print Certification", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Next
        Else
            If dgvHeatTreatLog.SelectedCells.Count = 0 Then
                If Not dgvHeatTreatLog.Rows(dgvHeatTreatLog.SelectedCells(0).RowIndex).Cells("Status").Value.ToString.Equals("LOCKED") Then
                    MessageBox.Show("Heat Treat data is not locked. Unable to create certification.", "Unable to create certification", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                If dgvHeatTreatLog.Rows(dgvHeatTreatLog.SelectedCells(0).RowIndex).Cells("Process Description").Value.ToString.Contains("Anneal") Then
                    MessageBox.Show("Heat Treat data for record # " + dgvHeatTreatLog.Rows(dgvHeatTreatLog.SelectedCells(0).RowIndex).Cells("Heat Record #").Value.ToString + " is an Anneal. Unable to print Certification.", "Unable to print Certification", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Else
                For i As Integer = 0 To dgvHeatTreatLog.SelectedCells.Count - 1
                    If Not dgvHeatTreatLog.Rows(dgvHeatTreatLog.SelectedCells(i).RowIndex).Cells("Status").Value.ToString.Equals("LOCKED") Then
                        MessageBox.Show("Heat Treat data for record # " + dgvHeatTreatLog.Rows(dgvHeatTreatLog.SelectedCells(i).RowIndex).Cells("Heat Record #").Value.ToString + " is not locked. Unable to create certification.", "Unable to create certification", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                    If dgvHeatTreatLog.Rows(dgvHeatTreatLog.SelectedCells(i).RowIndex).Cells("Process Description").Value.ToString.Contains("Anneal") Then
                        MessageBox.Show("Heat Treat data for record # " + dgvHeatTreatLog.Rows(dgvHeatTreatLog.SelectedCells(i).RowIndex).Cells("Heat Record #").Value.ToString + " is an Anneal. Unable to print Certification.", "Unable to print Certification", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                Next
            End If
        End If

        Return True
    End Function

    Private Sub cboLotNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLotNumber.TextChanged
        If cboLotNumber.Text.Length > 1 And cboLotNumber.Text.Length < 3 Then
            If cboLotNumber.Text.ElementAt(0) = "s" Then
                cboLotNumber.Text = cboLotNumber.Text.Substring(1, cboLotNumber.Text.Length - 1)
                cboLotNumber.Select(cboLotNumber.Text.Length, 0)
            End If
        End If
    End Sub

    Private Sub ViewHeatTreatInspectionLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class