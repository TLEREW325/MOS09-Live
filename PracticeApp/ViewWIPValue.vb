Imports System.Data.SqlClient

Public Class ViewWIPValue
    Public Class FOXData
        Public FOXNumber As String
        Dim Description As String
        Public Steps As Dictionary(Of Integer, stepInfo)
        Public Sub New()
            FOXNumber = ""
            Steps = New Dictionary(Of Integer, stepInfo)
        End Sub
        Public Sub New(ByVal fox As String)
            FOXNumber = fox
            Steps = New Dictionary(Of Integer, stepInfo)
        End Sub
        Public Sub New(ByVal fox As String, ByVal descr As String)
            FOXNumber = fox
            Description = descr
            Steps = New Dictionary(Of Integer, stepInfo)
        End Sub
    End Class
    ''sub class needed to keep data together
    Public Class stepInfo
        Public stepNumber As Integer
        Public machineClass As String
        Public DefaultMachine As String
        Public machineDescription As String
        Public machinesRan As New List(Of machineInfo)
        Public pieces As Integer
        Public appliedPieces As Integer
        Public addFG As Boolean
        Public ExtendedCost As Double
        Public Sub New()
        End Sub
        Public Sub New(ByVal machClass As String)
            machineClass = machClass
            If machineClass.Equals("UNKNOWN") Then
                stepNumber = 999
            End If
        End Sub
    End Class
    ''for each machine
    Public Class machineInfo
        Public dateRan As String
        Public machineID As String
        Public machineDescription As String
        Public quantityRan As String
        Public MachineCostPerHour As Double
        Public PiecesPerHour As Double
        Public MachineCost As Double
        Public TotalHours As Double
        Public Sub New()
        End Sub
        Public Sub New(ByVal dat As String, ByVal machID As String, ByVal machDesc As String, ByVal pieces As String, ByVal piecesPH As Double, ByVal machCost As Double, ByVal totHours As Double)
            dateRan = dat
            machineID = machID
            machineDescription = machDesc
            quantityRan = pieces
            PiecesPerHour = piecesPH
            MachineCostPerHour = machCost
            TotalHours = totHours
        End Sub
    End Class
    ''for each machine
    Private Class Totals
        ''values needed for totals
        Public totalPieceValue As Double = 0
        Public totalSteelValue As Double = 0
        Public totalLaborValue As Double = 0
        Public totalMachineValue As Double = 0
    End Class
    ''used for costing labor and machine cost on a given step
    Private Class MachinesUsed
        Public MachineNumber As String
        Public TotalPieces As Double
        Public PiecesPerHour As Double
        Public Sub New()
            MachineNumber = ""
            TotalPieces = 0
            PiecesPerHour = 0
        End Sub
        Public Sub New(ByVal machine As String, ByVal total As Double, ByVal pph As Double)
            MachineNumber = machine
            TotalPieces = total
            PiecesPerHour = pph
        End Sub
    End Class
    ''constant for calculating labor
    Const constLabor As Double = 20

    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL; ASYNC=true;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim ds, dsView As DataSet
    Dim machineCost As New Dictionary(Of String, Double)

    Public Sub New()
        InitializeComponent()

        GetMachineCosts()
        LoadFOXNumber()
    End Sub

    Private Sub GetMachineCosts()
        cmd = New SqlCommand("SELECT MachineID, MachineCostPerHour FROM MachineTable WHERE DivisionID = 'TWD'", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) And Not reader.IsDBNull(1) Then
                    If Not machineCost.ContainsKey(reader.Item("MachineID")) Then
                        machineCost.Add(reader.Item("MachineID"), reader.Item("MachineCostPerHour"))
                    End If
                End If
            End While
        End If
        reader.Close()
    End Sub


    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If bgwkCalculateCosts.IsBusy Then
            bgwkCalculateCosts.CancelAsync()
            lblBGWKWaitMessage.Text = "Cancelling, please wait"
            tmrChangeText.Stop()
        End If

        While bgwkCalculateCosts.IsBusy
            System.Threading.Thread.Sleep(500)
        End While

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboFOXNumber.Refresh()
        dtpStartDate.Refresh()
        dtpEndDate.Refresh()
        cboFOXNumber.SelectedIndex = -1
        dtpStartDate.Value = Now
        dtpEndDate.Value = Now
        dgvWIPEntries.DataSource = Nothing
        dgvWIPEntries.Rows.Clear()
        dgvWIPEntries.Columns.Clear()
        txtTotalWIPValue.Clear()
        txtTotalSteelValue.Clear()
        txtTotalLaborCost.Clear()
        txtTotalMachineOverhead.Clear()
        chkTruFitOnly.Checked = False
        chkTruWeldOnly.Checked = False
        chkViewClosedFoxs.Checked = False
        chkViewClosedProduction.Checked = False
    End Sub

    Private Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable;", con)
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "FOXTable")
        con.Close()

        cboFOXNumber.DisplayMember = "FOXNumber"
        cboFOXNumber.DataSource = ds.Tables("FOXTable")
        cboFOXNumber.SelectedIndex = -1

        cboWIPTotalFOX.DisplayMember = "FOXNumber"
        cboWIPTotalFOX.DataSource = ds.Tables("FOXTable").Copy()
        cboWIPTotalFOX.SelectedIndex = -1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        dgvWIPEntries.DataSource = Nothing
        dgvWIPEntries.Rows.Clear()
        dgvWIPEntries.Columns.Clear()
        If bgwkCalculateCosts.IsBusy Then
            bgwkCalculateCosts.CancelAsync()
            lblBGWKWaitMessage.Text = "Cancelling, please wait"
        End If
        While bgwkCalculateCosts.IsBusy
            System.Windows.Forms.Application.DoEvents()
        End While

        Dim whereCond As New Dictionary(Of String, Object)

        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            
            whereCond.Add("FOXNumber", cboFOXNumber.Text)
        End If
        whereCond.Add("StartDate", dtpStartDate.Value)
        whereCond.Add("EndDate", dtpEndDate.Value)

        If chkViewClosedFoxs.Checked Then
            whereCond.Add("FOXTable.Status", "INACTIVE")
        Else
            whereCond.Add("FOXTable.Status", "ACTIVE")
        End If
        If chkViewClosedProduction.Checked Then
            whereCond.Add("FOXProductionNumberHeaderTable.Status", "CLOSED")
        Else
            whereCond.Add("FOXProductionNumberHeaderTable.Status", "OPEN")
        End If

        If chkTruFitOnly.Checked Then
            whereCond.Add("DivisionID", "TFP")
        ElseIf chkTruWeldOnly.Checked Then
            whereCond.Add("DivisionID", "TWD")
        End If

        bgwkCalculateCosts.RunWorkerAsync(whereCond)
        pnlCancelBGWK.Show()
    End Sub

    Private Sub DisplayFOXSteps(ByVal dt As Data.DataTable)
        FormatDGV()
        Dim TotalLaborCost As Double = 0D
        Dim TotalMachineCost As Double = 0D
        Dim TotalRawMaterialCost As Double = 0D
        Dim cmd As New SqlCommand("SELECT FoxSched.ProcessID, MachineTable.Description FROM FoxSched INNER JOIN MachineTable ON FoxSched.ProcessID = MachineTable.MachineID WHERE MachineTable.DivisionID = 'TWD' AND FOXSched.FOXNumber = @FOXNumber AND FoxSched.ProcessStep = @ProcessStep", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int)
        cmd.Parameters.Add("@ProcessStep", SqlDbType.Int)
        Dim i As Integer = 0
        While i < dt.Rows.Count
            Dim currFOX As Integer = dt.Rows(i).Item("FOXNumber")
            ''starts the fox with the headers
            dgvWIPEntries.Rows.Add("FOX Number")
            dgvWIPEntries.Rows(dgvWIPEntries.RowCount - 1).DefaultCellStyle.Font = New System.Drawing.Font(Control.DefaultFont.FontFamily, 10, FontStyle.Underline Or FontStyle.Bold, GraphicsUnit.Point)
            dgvWIPEntries.Rows.Add(dt.Rows(i).Item("FOXNumber"))
            dgvWIPEntries.Rows(dgvWIPEntries.RowCount - 1).DefaultCellStyle.Font = New System.Drawing.Font(Control.DefaultFont.FontFamily, 10, FontStyle.Regular, GraphicsUnit.Point)
            dgvWIPEntries.Rows.Add()
            While i < dt.Rows.Count AndAlso currFOX = dt.Rows(i).Item("FOXNumber")
                ''goes through the step (backwards) and will print a header each time it does a new step
                Dim currStep As Integer = dt.Rows(i).Item("FOXStep")
                Dim stepPieces As Integer = 0
                Dim stepLabor As Double = 0D
                Dim stepMachine As Double = 0D
                Dim stepSteel As Double = 0D
                dgvWIPEntries.Rows.Add("", "Step #", "", "Default Machine", "Machine Description", "Total Pieces Produced", "Total Labor Cost", "Total Machine Cost", "Total Steel Cost", "Total Cost")
                dgvWIPEntries.Rows(dgvWIPEntries.RowCount - 1).DefaultCellStyle.Font = New System.Drawing.Font(Control.DefaultFont.FontFamily, 10, FontStyle.Underline Or FontStyle.Bold, GraphicsUnit.Point)

                dgvWIPEntries.Rows.Add("", currStep, "", "", "", "", "", "", "", "")
                Dim stepTitleRow As Integer = dgvWIPEntries.Rows.Count - 1
                dgvWIPEntries.Rows.Add()
                dgvWIPEntries.Rows.Add("", "", "Date Posted", "Machine ID", "Machine Description", "Pieces Produced", "Labor Cost", "Machine Cost", "Steel Cost", "Entry Cost")
                dgvWIPEntries.Rows(dgvWIPEntries.RowCount - 1).DefaultCellStyle.Font = New System.Drawing.Font(Control.DefaultFont.FontFamily, 10, FontStyle.Underline Or FontStyle.Bold, GraphicsUnit.Point)

                While i < dt.Rows.Count AndAlso currStep = dt.Rows(i).Item("FOXStep") AndAlso currFOX = dt.Rows(i).Item("FOXNumber")
                    dgvWIPEntries.Rows.Add("", "", dt.Rows(i).Item("PostingDate").ToString.Substring(0, dt.Rows(i).Item("PostingDate").ToString.IndexOf(" ")), dt.Rows(i).Item("MachineNumber"), dt.Rows(i).Item("Description"), dt.Rows(i).Item("PiecesProduced"), FormatCurrency(dt.Rows(i).Item("LaborCost")), FormatCurrency(dt.Rows(i).Item("MachineCost")), FormatCurrency(dt.Rows(i).Item("SteelCost")), FormatCurrency(dt.Rows(i).Item("LaborCost") + dt.Rows(i).Item("MachineCost") + dt.Rows(i).Item("SteelCost")))
                    stepPieces += dt.Rows(i).Item("PiecesProduced")
                    stepLabor += dt.Rows(i).Item("LaborCost")
                    stepMachine += dt.Rows(i).Item("MachineCost")
                    stepSteel += dt.Rows(i).Item("SteelCost")
                    i += 1
                End While
                cmd.Parameters("@FOXNumber").Value = currFOX
                cmd.Parameters("@ProcessStep").Value = currStep
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    dgvWIPEntries.Rows(stepTitleRow).Cells("MachineID").Value = reader.Item(0)
                    dgvWIPEntries.Rows(stepTitleRow).Cells("MachineDescription").Value = reader.Item(1)
                End If
                reader.Close()

                dgvWIPEntries.Rows(stepTitleRow).Cells("PiecesProduced").Value = stepPieces
                dgvWIPEntries.Rows(stepTitleRow).Cells("LaborCost").Value = FormatCurrency(stepLabor)
                dgvWIPEntries.Rows(stepTitleRow).Cells("MachineCost").Value = FormatCurrency(stepMachine)
                dgvWIPEntries.Rows(stepTitleRow).Cells("SteelCost").Value = FormatCurrency(stepSteel)
                dgvWIPEntries.Rows(stepTitleRow).Cells("TotalCost").Value = FormatCurrency(stepLabor + stepSteel + stepMachine)

                TotalLaborCost += stepLabor
                TotalMachineCost += stepMachine
                TotalRawMaterialCost += stepSteel
            End While

            ''this will stop it form adding a black line at the bottom of the DGV
            If i < dt.Rows.Count - 1 Then
                dgvWIPEntries.Rows.Add()
                dgvWIPEntries.Rows(dgvWIPEntries.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Black
                dgvWIPEntries.Rows(dgvWIPEntries.Rows.Count - 1).Height = 1
            End If
        End While
        con1.Close()
        txtTotalSteelValue.Text = FormatCurrency(TotalRawMaterialCost)
        txtTotalLaborCost.Text = FormatCurrency(TotalLaborCost)
        txtTotalMachineOverhead.Text = FormatCurrency(TotalMachineCost)
        txtTotalWIPValue.Text = FormatCurrency(TotalMachineCost + TotalLaborCost + TotalRawMaterialCost)
    End Sub

    Private Sub FormatDGV()
        dgvWIPEntries.DefaultCellStyle.SelectionBackColor = Color.White
        dgvWIPEntries.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvWIPEntries.Columns.Add("FOXNumber", "")
        dgvWIPEntries.Columns("FOXNumber").Width = 100
        dgvWIPEntries.Columns.Add("StepNumber", "")
        dgvWIPEntries.Columns("StepNumber").Width = 90
        dgvWIPEntries.Columns.Add("MachineClass", "")
        dgvWIPEntries.Columns("MachineClass").Width = 125
        dgvWIPEntries.Columns.Add("MachineID", "")
        dgvWIPEntries.Columns("MachineID").Width = 175
        dgvWIPEntries.Columns.Add("MachineDescription", "")
        dgvWIPEntries.Columns("MachineDescription").Width = 175
        dgvWIPEntries.Columns.Add("PiecesProduced", "")
        dgvWIPEntries.Columns("PiecesProduced").Width = 175
        dgvWIPEntries.Columns.Add("LaborCost", "")
        dgvWIPEntries.Columns("LaborCost").Width = 145
        dgvWIPEntries.Columns.Add("MachineCost", "")
        dgvWIPEntries.Columns("MachineCost").Width = 160
        dgvWIPEntries.Columns.Add("SteelCost", "")
        dgvWIPEntries.Columns("SteelCost").Width = 145
        dgvWIPEntries.Columns.Add("TotalCost", "")
        dgvWIPEntries.Columns("TotalCost").Width = 145
    End Sub

    Private Sub bgwkCalculateCosts_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkCalculateCosts.DoWork
        Dim dt As Data.DataTable = ProductionAPI.GetWIPValue(e.Argument, con1)
        e.Result = dt
    End Sub

    Private Sub bgwkCalculateCosts_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkCalculateCosts.RunWorkerCompleted
        pnlCancelBGWK.Hide()
        dgvWIPEntries.ColumnHeadersVisible = False
        DisplayFOXSteps(e.Result)
    End Sub

    Private Sub tmrChangeText_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrChangeText.Tick
        Select Case lblBGWKWaitMessage.Text
            Case "Building Report Please Wait"
                lblBGWKWaitMessage.Text = "Building Report Please Wait."
            Case "Building Report Please Wait."
                lblBGWKWaitMessage.Text = "Building Report Please Wait.."
            Case "Building Report Please Wait.."
                lblBGWKWaitMessage.Text = "Building Report Please Wait..."
            Case "Building Report Please Wait..."
                lblBGWKWaitMessage.Text = "Building Report Please Wait"
        End Select
    End Sub

    Private Sub ViewWIPValue_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If bgwkCalculateCosts.IsBusy Then
            bgwkCalculateCosts.CancelAsync()
            lblBGWKWaitMessage.Text = "Cancelling, please wait"
            tmrChangeText.Stop()
        End If

        While bgwkCalculateCosts.IsBusy
            System.Threading.Thread.Sleep(500)
        End While
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If bgwkCalculateCosts.IsBusy Then
            bgwkCalculateCosts.CancelAsync()
            lblBGWKWaitMessage.Text = "Cancelling, please wait"
            tmrChangeText.Stop()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).TableName.Equals("WIPTotals") Then
                Dim tbl As System.Data.DataTable = ds.Tables(0).Copy()
                tbl.Columns("WIPPieces").ColumnName = "PiecesProduced"
                tbl.Columns("WIPLabor").ColumnName = "MachineHours"
                tbl.Columns("WIPMachine").ColumnName = "ToolingHours"
                tbl.Columns("WIPTotal").ColumnName = "TotalHours"
                tbl.Columns("WIPAVGSteelCost").ColumnName = "Cost"

                Dim newPrintWIWPTotals As New PrintWIPTotals(tbl)
                newPrintWIWPTotals.ShowDialog()
            Else
                Dim currentFOX As String = ""
                Dim dsTemp As New DataSet
                dsTemp.Tables.Add("TimeSlipWHIPREport")
                dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("PartNumber")
                dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("MachineNumber")
                dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("EmployeeID")
                dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("DivisionID")
                dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("Status")
                dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("RMID")

                dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("MachineClass")
                dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("ProcessID")
                dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("ProcessAddFG")

                For i As Integer = 0 To dgvWIPEntries.Rows.Count - 1
                    dsTemp.Tables("TimeSlipWHIPREport").Rows.Add(dgvWIPEntries.Rows(i).Cells("FOXNumber").Value, dgvWIPEntries.Rows(i).Cells("StepNumber").Value, dgvWIPEntries.Rows(i).Cells("MachineClass").Value, dgvWIPEntries.Rows(i).Cells("MachineID").Value, dgvWIPEntries.Rows(i).Cells("MachineDescription").Value, dgvWIPEntries.Rows(i).Cells("PiecesProduced").Value, dgvWIPEntries.Rows(i).Cells("LaborCost").Value, dgvWIPEntries.Rows(i).Cells("MachineCost").Value, dgvWIPEntries.Rows(i).Cells("SteelCost").Value)
                    If IsDBNull(dsTemp.Tables("TimeSlipWHIPREport").Rows(i).Item("PartNumber")) Then
                        dsTemp.Tables("TimeSlipWHIPREport").Rows(i).Item("PartNumber") = currentFOX
                    Else
                        If Not String.IsNullOrEmpty(dsTemp.Tables("TimeSlipWHIPREport").Rows(i).Item("PartNumber")) Then
                            currentFOX = dsTemp.Tables("TimeSlipWHIPREport").Rows(i).Item("PartNumber")
                        Else
                            dsTemp.Tables("TimeSlipWHIPREport").Rows(i).Item("PartNumber") = currentFOX
                        End If
                    End If
                Next
                Dim newPrintWIPValue As New PrintWIPValue(dsTemp)
                newPrintWIPValue.ShowDialog()

            End If
        End If
    End Sub

    Private Sub bgwkGenerateWIPTotals_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkGenerateWIPTotals.DoWork
        Dim tempds As New DataSet
        Dim adap As New SqlDataAdapter(cmd)

        If con1.State = ConnectionState.Closed Then con1.Open()
        adap.Fill(tempds, "WIPTotals")
        con1.Close()
        e.Result = tempds
    End Sub

    Private Sub pnlCancelBGWK_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlCancelBGWK.VisibleChanged
        If pnlCancelBGWK.Visible Then
            tmrChangeText.Start()
            gpxWIPBreakdown.Enabled = False
            gpxWIPTotals.Enabled = False
        Else
            tmrChangeText.Stop()
            lblBGWKWaitMessage.Text = "Building Report Please Wait"
            gpxWIPBreakdown.Enabled = True
            gpxWIPTotals.Enabled = True
        End If
    End Sub

    Private Sub cmdViewWIPTotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewWIPTotals.Click
        dgvWIPEntries.DataSource = Nothing
        dgvWIPEntries.Rows.Clear()
        dgvWIPEntries.Columns.Clear()
        ''Deletes all the temp tables if they currently exist
        cmd = New SqlCommand("IF OBJECT_ID('tempdb..#AVGMatCost') IS NOT NULL DROP TABLE #AVGMatCost; IF OBJECT_ID('tempdb..#ProdCurrent') IS NOT NULL DROP TABLE #ProdCurrent; IF OBJECT_ID('tempdb..#WIPCurrent') IS NOT NULL DROP TABLE #WIPCurrent; IF OBJECT_ID('tempdb..#FGCurrent') IS NOT NULL DROP TABLE #FGCurrent;", con1)
        ''Creates all the temp tables
        cmd.CommandText += " Create table #AVGMatCost(FOXNumber int, SteelCostPerPiece float); CREATE table #ProdCurrent (TimeSlipKey int,	LineKey int, FOXNumber int,	ProductionNumber int, FOXStep int, SteelCostPerPiece float,	PiecesProduced int,	inventoryPieces int); CREATE TABLE #WIPCurrent (FOXNumber int, TotalWIPPieces int, LaborCost float, MachineCost float, TotalWIPCost float); CREATE TABLE #FGCurrent (FOXNumber int, TotalInventoryPieces int, AVGSteelCost float, TotalFGCost float);"
        ''INSERTS into the #AVGMatCost table
        cmd.CommandText += " INSERT INTO #AVGMatCost SELECT FOXNumber, (CAST(FOXTable.FinishedWeight as float) / 1000) * AVGSteelCostPerPound as CostPerPiece FROM FOXTable"
        cmd.CommandText += " LEFT OUTER JOIN (SELECT RMID, AVG(SteelCostPerPound) as AVGSteelCostPerPound FROM SteelCostingTable GROUP BY RMID) as SteelCost on FOXtable.RMID = SteelCost.RMID;"
        ''INSERTS into the #ProdCurrent table
        cmd.CommandText += " INSERT INTO #ProdCurrent SELECT TimeSlipLineItemTable.TimeSlipKey, TimeSlipLineItemTable.LineKey, Prod.FOXNumber, Prod.ProductionNumber, TimeSlipLineItemTable.FOXStep,"
        cmd.CommandText += " CASE WHEN  TimeSlipLineItemTable.ExtendedSteelCost is not null and TimeSlipLineItemTable.ExtendedSteelCost <> 0 THEN TimeSlipLineItemTable.ExtendedSteelCost / TimeSlipLineItemTable.InventoryPieces ELSE Prod.SteelCostPerPiece END as SteelCostPerPiece,"
        cmd.CommandText += " TimeSlipLineItemTable.PiecesProduced, TimeSlipLineItemTable.InventoryPieces FROM TimeSlipLineItemTable"
        cmd.CommandText += " INNER JOIN  (SELECT FOXProductionNumberHeaderTable.FOXNumber, ProductionNumber, #AVGMatCost.SteelCostPerPiece FROM FOXProductionNumberHeaderTable"
        cmd.CommandText += " LEFT OUTER JOIN #AVGMatCost ON FOXProductionNumberHeaderTable.FOXNumber = #AVGMatCost.FOXNumber WHERE Status = 'OPEN') as Prod"
        cmd.CommandText += " ON TimeSlipLineItemTable.FOXNumber = Prod.FOXNumber AND TimeSlipLineItemTable.ProductionNumber = Prod.ProductionNumber WHERE FOXStep <> 999 AND LineKey < 100;"
        ''INSERTS into the #WIPCurrentTable
        cmd.CommandText += " INSERT INTO #WIPCurrent SELECT LaborCost.FOXNumber, SUM(LaborCost.TotalPieces) as TotalPieces, SUM(LaborCost.LaborCost) as TotalLabor, SUM(MAchineCost.MachineCost) as TotalMachine, SUM(LaborCost.LaborCost + MachineCost.MachineCost) as TotalCost FROM "
        cmd.CommandText += " (SELECT #ProdCurrent.FOXNumber, #ProdCurrent.FOXStep, SUM(CASE WHEN #ProdCurrent.FOXStep = 1 then #ProdCurrent.PiecesProduced else 0 end) as TotalPieces, SUM((-1 * GLTransactionMasterList.GLTransactionDebitAmount) + GLTransactionMasterList.GLTransactionCreditAmount) as LaborCost FROM GLTransactionMasterList INNER JOIN #ProdCurrent"
        cmd.CommandText += " ON GLTransactionMasterList.GLReferenceNumber = #ProdCurrent.TimeSlipKey and GLTransactionMasterList.GLReferenceLine = #ProdCurrent.LineKey WHERE GLAccountNumber = '60000'"
        cmd.CommandText += " GROUP BY #ProdCurrent.FOXNumber, #ProdCurrent.FOXStep) as LaborCost INNER JOIN"
        cmd.CommandText += " (SELECT #ProdCurrent.FOXNumber, #ProdCurrent.FOXStep, SUM((-1 * GLTransactionMasterList.GLTransactionDebitAmount) + GLTransactionMasterList.GLTransactionCreditAmount) as MachineCost FROM GLTransactionMasterList INNER JOIN #ProdCurrent"
        cmd.CommandText += " ON GLTransactionMasterList.GLReferenceNumber = #ProdCurrent.TimeSlipKey and GLTransactionMasterList.GLReferenceLine = #ProdCurrent.LineKey WHERE GLAccountNumber = '60099'"
        cmd.CommandText += " GROUP BY #ProdCurrent.FOXNumber, #ProdCurrent.FOXStep) as MachineCost ON LaborCost.FOXNumber = MachineCost.FOXNumber AND LaborCost.FOXStep = MachineCost.FOXStep GROUP BY LaborCost.FOXNumber;"
        ''INSERTS into th #FGCurrent table
        cmd.CommandText += " INSERT INTO #FGCurrent SELECT #ProdCurrent.FOXNumber, SUM(#ProdCurrent.inventoryPieces) as TotalInventoryPieces,"
        cmd.CommandText += " SUM( GLTransactionMasterList.GLTransactionDebitAmount + (-1 * GLTransactionMasterList.GLTransactionCreditAmount)) as TotalCost,"
        cmd.CommandText += " AVG(#ProdCurrent.SteelCostPerPiece) as AVGSteelCostPerPiece FROM GLTransactionMasterList INNER JOIN #ProdCurrent"
        cmd.CommandText += " ON GLTransactionMasterList.GLReferenceNumber = #ProdCurrent.TimeSlipKey and GLTransactionMasterList.GLReferenceLine = #ProdCurrent.LineKey WHERE (GLAccountNumber = '12100' OR GLAccountNumber = '12500') AND #ProdCurrent.inventoryPieces <> 0"
        cmd.CommandText += " GROUP BY #ProdCurrent.FOXNumber;"
        ''Actual Query for getting WIP Pice Counts, labor and machine costs, and cost of steel based on the pieces and an average steel cost.
        cmd.CommandText += " SELECT sg1.FOXNumber, sg1.TotalWIPPieces - sg1.TotalInventoryPieces as WIPPieces,"
        cmd.CommandText += " ROUND(CASE WHEN sg1.PercentLeftInWIP > 0 THEN sg1.PercentLeftInWIP * sg1.LaborCost ELSE 0 END, 2) as WIPLabor,"
        cmd.CommandText += " ROUND(CASE WHEN sg1.PercentLeftInWIP > 0 THEN sg1.PercentLeftInWIP * sg1.MachineCost ELSE 0 END, 2) as WIPMachine,"
        cmd.CommandText += " ROUND(CASE WHEN sg1.PercentLeftInWIP > 0 THEN sg1.PercentLeftInWIP * sg1.TotalWIPCost ELSE 0 END, 2) as WIPTotal,"
        cmd.CommandText += " CASE WHEN (sg1.TotalWIPPieces - sg1.TotalInventoryPieces) < 0 THEN 0 ELSE isnull(ROUND(#AVGMatCost.SteelCostPerPiece * (sg1.TotalWIPPieces - sg1.TotalInventoryPieces), 2), 0) END as WIPAVGSteelCost"
        cmd.CommandText += " FROM (SELECT #WIPCurrent.FOXNumber, #WIPCurrent.TotalWIPPieces, #FGCurrent.TotalInventoryPieces, #WIPCurrent.TotalWIPCost, #FGCurrent.TotalFGCost,"
        cmd.CommandText += " CASE WHEN #FGCurrent.TotalInventoryPieces < #WIPCurrent.TotalWIPPieces THEN (1 - (CAST(#FGCurrent.TotalInventoryPieces as FLOAT) / #WIPCurrent.TotalWIPPieces)) ELSE 0 END as PercentLeftInWIP,"
        cmd.CommandText += " #WIPCurrent.LaborCost, #WIPCurrent.MachineCost FROM #WIPCurrent INNER JOIN #FGCurrent ON #WIPCurrent.FOXNumber = #FGCurrent.FOXNumber) as sg1"
        cmd.CommandText += " LEFT OUTER JOIN #AVGMatCost ON sg1.FOXNumber = #AVGMatCost.FOXNumber WHERE (sg1.TotalWIPPieces- sg1.TotalInventoryPieces) <> 0"

        If Not String.IsNullOrEmpty(cboWIPTotalFOX.Text) Then
            cmd.CommandText += " AND sg1.FOXNumber = @FOXnumber"
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboWIPTotalFOX.Text)
        End If

        ''deletes the tables used for this calculation
        cmd.CommandText += "; DROP TABLE #AVGMatCost"
        cmd.CommandText += " DROP TABLE #ProdCurrent;"
        cmd.CommandText += " DROP TABLE #WIPCurrent;"
        cmd.CommandText += " DROP TABLE #FGCurrent;"
        pnlCancelBGWK.Show()
        bgwkGenerateWIPTotals.RunWorkerAsync()
    End Sub

    Private Sub bgwkGenerateWIPTotals_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkGenerateWIPTotals.RunWorkerCompleted
        pnlCancelBGWK.Hide()

        ds = e.Result

        Dim TotalSteel As Double = 0
        Dim TotalLabor As Double = 0
        Dim TotalMachine As Double = 0

        For Each rw As DataRow In ds.Tables("WIPTotals").Rows
            TotalLabor += rw.Item("WIPLabor")
            TotalMachine += rw.Item("WIPMachine")
            TotalSteel += rw.Item("WIPAVGSteelCost")
        Next

        txtTotalLaborCost.Text = FormatCurrency(TotalLabor)
        txtTotalMachineOverhead.Text = FormatCurrency(TotalMachine)
        txtTotalSteelValue.Text = FormatCurrency(TotalSteel)
        txtTotalWIPValue.Text = FormatCurrency(TotalLabor + TotalMachine + TotalSteel)
        dgvWIPEntries.ColumnHeadersVisible = True
        dgvWIPEntries.DataSource = ds.Tables("WIPTotals")
        dgvWIPEntries.Columns("FOXNumber").HeaderText = "FOX Number"
        dgvWIPEntries.Columns("WIPPieces").HeaderText = "WIP Pieces"
        dgvWIPEntries.Columns("WIPPieces").DefaultCellStyle.Format = "N0"
        dgvWIPEntries.Columns("WIPLabor").HeaderText = "WIPLabor"
        dgvWIPEntries.Columns("WIPLabor").DefaultCellStyle.Format = "C2"
        dgvWIPEntries.Columns("WIPMachine").HeaderText = "WIPMachine"
        dgvWIPEntries.Columns("WIPMachine").DefaultCellStyle.Format = "C2"
        dgvWIPEntries.Columns("WIPTotal").HeaderText = "WIP Total"
        dgvWIPEntries.Columns("WIPTotal").DefaultCellStyle.Format = "C2"
        dgvWIPEntries.Columns("WIPAVGSteelCost").HeaderText = "Steel Cost"
        dgvWIPEntries.Columns("WIPAVGSteelCost").DefaultCellStyle.Format = "C2"
    End Sub

    Private Sub cmdClearWIPTotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearWIPTotals.Click
        cboWIPTotalFOX.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboWIPTotalFOX.Text) Then
            cboWIPTotalFOX.Text = ""
        End If
        dgvWIPEntries.DataSource = Nothing
        dgvWIPEntries.Rows.Clear()
        dgvWIPEntries.Columns.Clear()
        txtTotalWIPValue.Clear()
        txtTotalSteelValue.Clear()
        txtTotalLaborCost.Clear()
        txtTotalMachineOverhead.Clear()
    End Sub

    Private Sub chkTruFitOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTruFitOnly.CheckedChanged
        If chkTruFitOnly.Checked AndAlso chkTruFitOnly.Focused Then
            chkTruWeldOnly.Checked = False
        End If
    End Sub

    Private Sub chkTruWeldOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTruWeldOnly.CheckedChanged
        If chkTruWeldOnly.Checked AndAlso chkTruWeldOnly.Focused Then
            chkTruFitOnly.Checked = False
        End If
    End Sub

    Private Sub ViewWIPValue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
