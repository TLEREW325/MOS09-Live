Imports System.Data.SqlClient

Public Class ViewWIP
    Public Class FOXData
        Public FOXNumber As String
        Public Description As String
        Public Steps As Dictionary(Of Integer, stepInfo)
        Public Sub New()
            FOXNumber = ""
            Description = ""
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

    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim ds, dsView As DataSet

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If bgwkGetWIP.IsBusy Then
            bgwkGetWIP.CancelAsync()
            lblBGWKWaitMessage.Text = "Cancelling, please wait"
            tmrChangeText.Stop()
        End If
        While bgwkGetWIP.IsBusy
            System.Threading.Thread.Sleep(500)
        End While
        Me.Dispose()
        Me.Close()
    End Sub
    Public Sub New()
        InitializeComponent()

        LoadFOXNumber()
        LoadItemClass()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboFOXNumber.Refresh()
        dtpStartDate.Refresh()
        dtpEndDate.Refresh()
        chkShowTFP.Checked = True
        chkShowTWD.Checked = True
        cboFOXNumber.SelectedIndex = -1
        dtpStartDate.Value = Today.Date
        dtpEndDate.Value = Today.Date
        dgvWIPEntries.Rows.Clear()
        dgvWIPEntries.Columns.Clear()
        chkBeginningOfTime.Checked = False
        chkOrderByPartNumber.Checked = False
        cboItemClass.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboItemClass.Text) Then
            cboItemClass.Text = ""
        End If
        cboItemDiameter.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboItemDiameter.Text) Then
            cboItemDiameter.Text = ""
        End If
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
    End Sub

    Private Sub LoadItemClass()
        cmd = New SqlCommand("SELECT ItemClassID FROM ItemClass WHERE (ItemClassID like 'TW %' OR ItemClassID = 'Trufit Parts') and ItemClassID <> 'TW WELD PROD'", con)
        Dim dt As New Data.DataTable("ItemClass")
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(dt)
        con.Close()

        cboItemClass.DisplayMember = "ItemClassID"
        cboItemClass.DataSource = dt
        cboItemClass.SelectedIndex = -1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        dgvWIPEntries.Rows.Clear()
        dgvWIPEntries.Columns.Clear()
        If bgwkGetWIP.IsBusy Then
            bgwkGetWIP.CancelAsync()
            lblBGWKWaitMessage.Text = "Cancelling, please wait"
        End If
        While bgwkGetWIP.IsBusy
            System.Windows.Forms.Application.DoEvents()
        End While
        cmd1 = New SqlCommand("SELECT PostingDate, TimeSlipCombinedData.FOXNumber, MachineNumber, Description, PiecesProduced, InventoryPieces, ShortDescription, MachineClass, ROUND(PiecesProduced / (CASE WHEN TotalHours = 0 THEN 1 ELSE TotalHours END), 7) AS PiecesPerHour, MachineCostPerHour, TotalHours, FOXStep, ItemID FROM (SELECT PostingDate, TimeSlipCombinedData.FOXNumber, MachineNumber, MachineTable.Description, PiecesProduced, InventoryPieces, ItemList.ShortDescription, MachineTable.MachineClass, ROUND(PiecesProduced / (CASE WHEN TotalHours = 0 THEN 1 ELSE TotalHours END), 7) AS PiecesPerHour, MachineCostPerHour, TotalHours, FOXStep, ItemList.ItemID, ProductionNumber FROM TimeSlipCombinedData INNER JOIN ItemList on TimeSlipCombinedData.FOXNumber = ItemList.FOXNumber and TimeSlipCombinedData.PartNumber = ItemList.ItemID LEFT OUTER JOIN MachineTable on TimeSlipCombinedData.MachineNumber = MachineTable.MachineID WHERE (ItemList.DivisionID = 'TWD' or ItemList.DivisionID = 'TFP') AND MachineTable.DivisionID = 'TWD' AND TimeSlipCombinedData.FOXStep <> 0 AND FOXStep <> 999", con1)
        If Not String.IsNullOrEmpty(cboItemClass.Text) Then
            cmd1.CommandText += " AND ItemList.ItemClass = @ItemClass"
            cmd1.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
        End If
        If Not String.IsNullOrEmpty(cboItemDiameter.Text) Then
            cmd1.CommandText += " AND ItemList.NominalDiameter BETWEEN (@NominalDiameter - 0.001) AND (@NominalDiameter + 0.001)"
            cmd1.Parameters.Add("@NominalDiameter", SqlDbType.Float).Value = Val(usefulFunctions.ConvertToDecimal(cboItemDiameter.Text))
        End If
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cmd1.CommandText += " AND TimeSlipCombinedData.FOXNumber = @FOXNumber"
            cmd1.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        End If
        Select Case True
            Case chkShowTFP.Checked And chkShowTWD.Checked
                If EmployeeCompanyCode.Equals("TST") Then
                    cmd1.CommandText += " AND (TimeSlipCombinedData.DivisionID = 'TWD' or TimeSlipCombinedData.DivisionID = 'TFP' or TimeSlipCombinedData.DivisionID = 'TST')"
                Else
                    cmd1.CommandText += " AND (TimeSlipCombinedData.DivisionID = 'TWD' or TimeSlipCombinedData.DivisionID = 'TFP')"
                End If

            Case chkShowTFP.Checked And Not chkShowTWD.Checked
                If EmployeeCompanyCode.Equals("TST") Then
                    cmd1.CommandText += " AND (TimeSlipCombinedData.DivisionID = 'TFP' or TimeSlipCombinedData.DivisionID = 'TST')"
                Else
                    cmd1.CommandText += " AND TimeSlipCombinedData.DivisionID = 'TFP'"
                End If

            Case Not chkShowTFP.Checked And chkShowTWD.Checked
                If EmployeeCompanyCode.Equals("TST") Then
                    cmd1.CommandText += " AND (TimeSlipCombinedData.DivisionID = 'TWD' or TimeSlipCombinedData.DivisionID = 'TST')"
                Else
                    cmd1.CommandText += " AND TimeSlipCombinedData.DivisionID = 'TWD'"
                End If

        End Select
        Dim beginDate As Date
        Dim endDate As Date
        If Not chkBeginningOfTime.Checked Then
            cmd1.CommandText += " AND PostingDate BETWEEN @StartDate AND @EndDate"
            cmd1.Parameters.Add("@StartDate", SqlDbType.Date).Value = dtpStartDate.Value
            beginDate = dtpStartDate.Value
            cmd1.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
            endDate = dtpEndDate.Value
        Else
            cmd1.CommandText += " AND PostingDate BETWEEN @StartDate AND @EndDate"
            cmd1.Parameters.Add("@StartDate", SqlDbType.Date).Value = New Date(2016, 1, 1)
            beginDate = New Date(2016, 1, 1)
            cmd1.Parameters.Add("@EndDate", SqlDbType.Date).Value = Now.Date
            endDate = Now.Date
        End If
        If chkOrderByPartNumber.Checked Then
            cmd1.CommandText += ") as TimeSlipCombinedData  INNER JOIN (SELECT ProductionNumber, FOXNumber FROM FOXProductionNumberHeaderTable WHERE Status = 'OPEN') as FOXProductionNumberHeaderTable ON TimeSlipCombinedData.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber AND FOXProductionNumberHeaderTable.ProductionNumber  = TimeSlipCombinedData.ProductionNumber ORDER BY ItemID, TimeSlipCombinedData.FOXNumber, PostingDate ASC, MachineNumber, PiecesProduced;"
        Else
            cmd1.CommandText += ") as TimeSlipCombinedData  INNER JOIN (SELECT ProductionNumber, FOXNumber FROM FOXProductionNumberHeaderTable WHERE Status = 'OPEN') as FOXProductionNumberHeaderTable ON TimeSlipCombinedData.FOXNumber = FOXProductionNumberHeaderTable.FOXNumber AND FOXProductionNumberHeaderTable.ProductionNumber  = TimeSlipCombinedData.ProductionNumber ORDER BY TimeSlipCombinedData.FOXNumber, PostingDate ASC, MachineNumber, PiecesProduced, ItemID;"
        End If

        bgwkGetWIP.RunWorkerAsync(New Date() {beginDate, endDate})
        pnlCancelBGWK.Visible = True
        tmrChangeText.Start()
    End Sub

    ''gets the requested time period and or fox data fro mthe timeslip table
    Private Sub getTimeSlipData(ByRef dsTimeSlip As DataSet)
        Dim timeAdapt As New SqlDataAdapter
        timeAdapt.SelectCommand = cmd1

        If con1.State = ConnectionState.Closed Then con1.Open()
        timeAdapt.Fill(dsTimeSlip, "TimeSlipCombinedData")
        con1.Close()
    End Sub

    Private Sub FillFoxes(ByRef ds As DataSet, ByRef foxes As Dictionary(Of String, FOXData))
        For i As Integer = 0 To ds.Tables("TimeSlipCombinedData").Rows.Count - 1
            If Not foxes.ContainsKey(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString()) Then
                foxes.Add(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString, New FOXData(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString, ds.Tables("TimeSlipCombinedData").Rows(i).Item("ShortDescription").ToString))
            End If
        Next
    End Sub

    ''gets the steps and the machine class for the given FOX
    Private Sub LoadSteps(ByRef foxes As Dictionary(Of String, FOXData))
        For i As Integer = 0 To foxes.Count - 1
            Dim lst As New List(Of stepInfo)
            cmd1 = New SqlCommand("SELECT ProcessStep, MachineClass, MachineID, MachineTable.Description, ProcessAddFG FROM FoxSched LEFT OUTER JOIN MachineTable on ProcessID = MachineID AND DivisionID = 'TWD' WHERE FOXNumber = @FOXNumber ORDER BY ProcessStep DESC;", con1)
            cmd1.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = foxes.ElementAt(i).Key

            If con1.State = ConnectionState.Closed Then con1.Open()
            Dim reader As SqlDataReader = cmd1.ExecuteReader()
            If reader.HasRows Then
                Do While reader.Read()
                    Dim FOXStep As New stepInfo
                    If IsDBNull(reader.Item("ProcessStep")) Then
                        FOXStep.stepNumber = 0
                    Else
                        FOXStep.stepNumber = reader.Item("ProcessStep")
                    End If
                    If IsDBNull(reader.Item("MachineClass")) Then
                        FOXStep.machineClass = "HDR"
                    Else
                        FOXStep.machineClass = reader.Item("MachineClass")
                    End If
                    If IsDBNull(reader.Item("MachineID")) Then
                        FOXStep.DefaultMachine = "001"
                    Else
                        FOXStep.DefaultMachine = reader.Item("MachineID")
                    End If
                    If IsDBNull(reader.Item("Description")) Then
                        FOXStep.machineDescription = "001 Progressive Header"
                    Else
                        FOXStep.machineDescription = reader.Item("Description")
                    End If
                    If IsDBNull(reader.Item("ProcessAddFG")) Then
                        FOXStep.addFG = False
                    Else
                        If reader.Item("ProcessAddFG") = "ADDINVENTORY" Then
                            FOXStep.addFG = True
                        Else
                            FOXStep.addFG = False
                        End If
                    End If
                    FOXStep.pieces = 0
                    lst.Add(FOXStep)
                    foxes(foxes.ElementAt(i).Key).Steps.Add(FOXStep.stepNumber, FOXStep)
                Loop
            End If
            reader.Close()
        Next
        con1.Close()
    End Sub

    Private Sub AddPieceCounts(ByRef foxes As Dictionary(Of String, FOXData), ByRef ds As DataSet, ByVal StartDate As Date, ByVal EndDate As Date)
        For i As Integer = 0 To ds.Tables("TimeSlipCombinedData").Rows.Count - 1

            If Not foxes.ContainsKey(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString()) Then
                ''needs to go find the data to ass the element
            End If
            ''check to make sure ti matched a step in the given FOX if still true it will need to go to the unknown step
            If Not foxes(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString()).Steps.ContainsKey(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXStep")) Then
                If Not foxes(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString()).Steps.ContainsKey(999) Then
                    foxes(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString()).Steps.Add(999, New stepInfo("UNKNOWN"))
                End If

                ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXStep") = 999
            End If
            foxes(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString()).Steps(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXStep")).pieces += ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced")
            foxes(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXNumber").ToString()).Steps(ds.Tables("TimeSlipCombinedData").Rows(i).Item("FOXStep")).machinesRan.Add(New machineInfo(ds.Tables("TimeSlipCombinedData").Rows(i).Item("PostingDate"), ds.Tables("TimeSlipCombinedData").Rows(i).Item("MachineNumber").ToString(), ds.Tables("TimeSlipCombinedData").Rows(i).Item("Description").ToString(), ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesProduced").ToString(), ds.Tables("TimeSlipCombinedData").Rows(i).Item("PiecesPerHour"), ds.Tables("TimeSlipCombinedData").Rows(i).Item("MachineCostPerHour"), ds.Tables("TimeSlipCombinedData").Rows(i).Item("TotalHours")))
        Next
        ''changes the piece counts based on what the steps have done
        For i As Integer = 0 To foxes.Count - 1
            If foxes(foxes.ElementAt(i).Key).Steps.Count > 1 Then
                Dim foxKey As Integer = foxes.ElementAt(i).Key
                Dim HighestPrevStep As Integer = GetFGAmount(foxKey.ToString(), StartDate, EndDate)
                For j As Integer = 1 To foxes(foxes.ElementAt(i).Key).Steps.Count - 1
                    If Not foxes(foxKey).Steps(foxes(foxKey).Steps.ElementAt(j).Key).machineClass.Equals("UNKNOWN") Then
                        Dim prevStep As Integer = foxes(foxKey).Steps.ElementAt(j - 1).Key
                        Dim currStep As Integer = foxes(foxKey).Steps.ElementAt(j).Key
                        ''check to see if the previous step had the the same or more pieces and if it had more will just use the total from the current step instead of the previous step total
                        If HighestPrevStep < (foxes(foxKey).Steps(prevStep).pieces + foxes(foxKey).Steps(prevStep).appliedPieces) Then
                            HighestPrevStep = (foxes(foxKey).Steps(prevStep).pieces + foxes(foxKey).Steps(prevStep).appliedPieces)
                        End If
                        If HighestPrevStep > foxes(foxKey).Steps(currStep).pieces Then
                            foxes(foxKey).Steps(currStep).appliedPieces = foxes(foxKey).Steps(currStep).pieces
                            foxes(foxKey).Steps(currStep).pieces = 0
                        Else
                            foxes(foxKey).Steps(currStep).appliedPieces = HighestPrevStep
                            foxes(foxKey).Steps(currStep).pieces -= HighestPrevStep
                        End If

                        If foxes(foxKey).Steps(prevStep).pieces < 0 Then
                            foxes(foxKey).Steps(prevStep).pieces = 0
                        End If
                    End If
                Next
            End If
            'If foxes(foxes.ElementAt(i).Key).Steps(foxes(foxes.ElementAt(i).Key).Steps.ElementAt(1).Key).pieces - foxes(foxes.ElementAt(i).Key).Steps(foxes(foxes.ElementAt(i).Key).Steps.ElementAt(2).Key).appliedPieces > 0 Then
            '    If foxes(foxes.ElementAt(i).Key).Steps(foxes(foxes.ElementAt(i).Key).Steps.ElementAt(foxes(foxes.ElementAt(i).Key).Steps.Count - 1).Key).machineClass.Equals("UNKNOWN") Then
            '        foxes(foxes.ElementAt(i).Key).Steps(foxes(foxes.ElementAt(i).Key).Steps.ElementAt(foxes(foxes.ElementAt(i).Key).Steps.Count - 1).Key).pieces = foxes(foxes.ElementAt(i).Key).Steps(foxes(foxes.ElementAt(i).Key).Steps.ElementAt(foxes(foxes.ElementAt(i).Key).Steps.Count).Key).pieces - (foxes(foxes.ElementAt(i).Key).Steps(foxes(foxes.ElementAt(i).Key).Steps.ElementAt(2).Key).pieces - foxes(foxes.ElementAt(i).Key).Steps(foxes(foxes.ElementAt(i).Key).Steps.ElementAt(2).Key).appliedPieces)
            '    End If
            'End If
        Next
        If con1.State = ConnectionState.Open Then con1.Close()
    End Sub

    Private Function GetFGAmount(ByVal FOXNumber As String, ByVal StartDate As Date, ByVal EndDate As Date) As Integer
        Dim FGAmount As Integer = 0
        cmd1 = New SqlCommand("DECLARE @ProductionNumber as int = (SELECT TOP 1 isnull(MAX(ProductionNumber), 80316) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber); SELECT SUM(InventoryPieces) FROM TimeSlipLineItemTable INNER JOIN TimeSlipHeaderTable ON TimeSlipLineItemTable.TimeSlipKey = TimeSlipHeaderTable.TimeSlipKey WHERE FOXNumber = @FOXNumber AND PostingDate BETWEEN @StartDate AND @EndDate AND ProductionNumber = @ProductionNumber AND FOXStep = (SELECT ProcessStep FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber AND ProcessAddFG = 'ADDINVENTORY')", con1)
        cmd1.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = FOXNumber
        cmd1.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate
        cmd1.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate

        If con1.State = ConnectionState.Closed Then con1.Open()
        Dim obj As Object = cmd1.ExecuteScalar()

        If Not IsDBNull(obj) Then
            If obj IsNot Nothing Then
                FGAmount = obj
            End If
        End If
        Return FGAmount
    End Function

    Private Sub RemoveZeroPieces(ByRef foxes As Dictionary(Of String, FOXData))
        Dim i As Integer = 0
        While i < foxes.Count
            Dim j As Integer = 0
            Dim currFOX As Integer = foxes.ElementAt(i).Key
            Dim FGAmount As Double = 0D
            While j < foxes(currFOX).Steps.Count
                ''removes step if 0 or if its adding to finished goods
                Dim currStep As Integer = foxes(currFOX).Steps.ElementAt(j).Key
                If foxes(currFOX).Steps(currStep).pieces = 0 Or foxes(currFOX).Steps(currStep).addFG Then
                    If foxes(currFOX).Steps(currStep).addFG Then
                        FGAmount = (foxes(currFOX).Steps(currStep).pieces + foxes(currFOX).Steps(currStep).appliedPieces)
                    End If
                    foxes(currFOX).Steps.Remove(currStep)
                Else
                    Dim pc As Double = foxes(currFOX).Steps(currStep).appliedPieces
                    Dim app As Double = foxes(currFOX).Steps(currStep).pieces
                    ''check to see if the FG amount is more than the applied and remaining pieces
                    If foxes(currFOX).Steps(currStep).pieces + foxes(currFOX).Steps(currStep).appliedPieces > FGAmount Then
                        ''check to see if the applied pieces is more than the FG amount, if so will 
                        If foxes(currFOX).Steps(currStep).appliedPieces < FGAmount Then
                            foxes(currFOX).Steps(currStep).pieces -= (FGAmount - foxes(currFOX).Steps(currStep).appliedPieces)
                            foxes(currFOX).Steps(currStep).appliedPieces = FGAmount
                        End If
                        ''check again to make sure that we still need to process the step
                        If foxes(currFOX).Steps(currStep).pieces > 0 Then
                            Dim MachineTotal As Integer = 0
                            Dim pos As Integer = foxes(currFOX).Steps(currStep).machinesRan.Count - 1
                            While MachineTotal <> foxes(currFOX).Steps(currStep).pieces And pos >= 0
                                If MachineTotal + foxes(currFOX).Steps(currStep).machinesRan(pos).quantityRan > foxes(currFOX).Steps(currStep).pieces Then
                                    foxes(currFOX).Steps(currStep).machinesRan(pos).quantityRan = foxes(currFOX).Steps(currStep).pieces - MachineTotal
                                    MachineTotal += foxes(currFOX).Steps(currStep).machinesRan(pos).quantityRan
                                Else
                                    MachineTotal += foxes(currFOX).Steps(currStep).machinesRan(pos).quantityRan
                                End If
                                pos -= 1
                            End While
                            If pos >= 0 Then
                                For p As Integer = 0 To pos
                                    foxes(currFOX).Steps(currStep).machinesRan.RemoveAt(0)
                                Next
                            End If
                            j += 1
                        Else
                            ''removes the step after adjusting the applied piece count for the FG amount difference and it put the remaining piece count at or below 0
                            foxes(currFOX).Steps.Remove(currStep)
                        End If
                    Else
                        ''removes step since FG amount is more than the applied and remaining piece count total
                        foxes(currFOX).Steps.Remove(currStep)
                    End If
                End If
            End While
            If foxes(currFOX).Steps.Count = 0 Then
                foxes.Remove(currFOX)
            Else
                i += 1
            End If
        End While
    End Sub

    Private Sub RemoveAboveFGStep(ByRef foxes As Dictionary(Of String, FOXData))
        Dim i As Integer = 0
        While i < foxes.Count
            Dim ky As Integer = foxes.ElementAt(i).Key
            Dim j As Integer = foxes(ky).Steps.Count - 1
            Dim NotFG As Boolean = True
            While j > 0 And NotFG
                If foxes(ky).Steps(foxes(ky).Steps.ElementAt(j).Key).addFG Then
                    NotFG = False
                Else
                    j -= 1
                End If
            End While
            Dim diff As Integer = j
            While j > 0
                foxes(ky).Steps.Remove(foxes(ky).Steps.ElementAt(j - 1).Key)
                j -= 1
            End While
            i += 1
        End While
    End Sub


    Private Sub DisplayFOXSteps(ByRef foxes As Dictionary(Of String, FOXData))
        FormatDGV()
        For i As Integer = 0 To foxes.Count - 1
            Dim currFOX As Integer = foxes.ElementAt(i).Key
            dgvWIPEntries.Rows.Add("FOX Number")

            dgvWIPEntries.Rows(dgvWIPEntries.RowCount - 1).DefaultCellStyle.Font = New System.Drawing.Font(Control.DefaultFont.FontFamily, 10, FontStyle.Underline Or FontStyle.Bold, GraphicsUnit.Point)
            dgvWIPEntries.Rows.Add(foxes(foxes.ElementAt(i).Key).FOXNumber, foxes(foxes.ElementAt(i).Key).Description)
            dgvWIPEntries.Rows(dgvWIPEntries.RowCount - 1).DefaultCellStyle.Font = New System.Drawing.Font(Control.DefaultFont.FontFamily, 10, FontStyle.Regular, GraphicsUnit.Point)
            dgvWIPEntries.Rows.Add()

            Dim steelPostDate As String = "1900-01-01"
            ''goes through the step (backwards) and will print a header each time it does a new step 
            For j As Integer = foxes(currFOX).Steps.Count - 1 To 0 Step -1
                Dim currStep As Integer = foxes(currFOX).Steps.ElementAt(j).Key
                dgvWIPEntries.Rows.Add("", "Step #", "Machine Class", "Default Machine", "Machine Description", "Total Pieces Produced")

                dgvWIPEntries.Rows(dgvWIPEntries.RowCount - 1).DefaultCellStyle.Font = New System.Drawing.Font(Control.DefaultFont.FontFamily, 10, FontStyle.Underline Or FontStyle.Bold, GraphicsUnit.Point)

                dgvWIPEntries.Rows.Add("", foxes(currFOX).Steps(currStep).stepNumber, foxes(currFOX).Steps(currStep).machineClass, foxes(currFOX).Steps(currStep).DefaultMachine, foxes(currFOX).Steps(currStep).machineDescription, foxes(currFOX).Steps(currStep).pieces)
                dgvWIPEntries.Rows.Add()
                dgvWIPEntries.Rows.Add("", "", "Date Posted", "Machine ID", "Machine Description", "Pieces Produced")
                dgvWIPEntries.Rows(dgvWIPEntries.RowCount - 1).DefaultCellStyle.Font = New System.Drawing.Font(Control.DefaultFont.FontFamily, 10, FontStyle.Underline Or FontStyle.Bold, GraphicsUnit.Point)
                If currStep = 1 Then
                    steelPostDate = foxes(currFOX).Steps(currStep).machinesRan(foxes(currFOX).Steps(currStep).machinesRan.Count - 1).dateRan
                End If
                ''goes through all the machines and will add them to the DGV
                For p As Integer = 0 To foxes(currFOX).Steps(currStep).machinesRan.Count - 1
                    If foxes(currFOX).Steps(currStep).machinesRan(p).quantityRan > 0 Then
                        ''check to see if pieces per hour can be used for calculations
                        If foxes(currFOX).Steps(currStep).machinesRan(p).PiecesPerHour = 0 Then
                            If foxes(currFOX).Steps(currStep).machinesRan(p).dateRan.Contains(" ") Then
                                dgvWIPEntries.Rows.Add("", "", foxes(currFOX).Steps(currStep).machinesRan(p).dateRan.Substring(0, foxes(currFOX).Steps(currStep).machinesRan(p).dateRan.IndexOf(" ")), foxes(currFOX).Steps(currStep).machinesRan(p).machineID, foxes(currFOX).Steps(currStep).machinesRan(p).machineDescription, foxes(currFOX).Steps(currStep).machinesRan(p).quantityRan)
                            Else
                                dgvWIPEntries.Rows.Add("", "", foxes(currFOX).Steps(currStep).machinesRan(p).dateRan, foxes(currFOX).Steps(currStep).machinesRan(p).machineID, foxes(currFOX).Steps(currStep).machinesRan(p).machineDescription, foxes(currFOX).Steps(currStep).machinesRan(p).quantityRan)
                            End If
                        Else
                            If foxes(currFOX).Steps(currStep).machinesRan(p).dateRan.Contains(" ") Then
                                dgvWIPEntries.Rows.Add("", "", foxes(currFOX).Steps(currStep).machinesRan(p).dateRan.Substring(0, foxes(currFOX).Steps(currStep).machinesRan(p).dateRan.IndexOf(" ")), foxes(currFOX).Steps(currStep).machinesRan(p).machineID, foxes(currFOX).Steps(currStep).machinesRan(p).machineDescription, foxes(currFOX).Steps(currStep).machinesRan(p).quantityRan)
                            Else
                                dgvWIPEntries.Rows.Add("", "", foxes(currFOX).Steps(currStep).machinesRan(p).dateRan, foxes(currFOX).Steps(currStep).machinesRan(p).machineID, foxes(currFOX).Steps(currStep).machinesRan(p).machineDescription, foxes(currFOX).Steps(currStep).machinesRan(p).quantityRan)
                            End If
                        End If
                    End If
                Next
                dgvWIPEntries.Rows.Add()
            Next
            ''this will stop it form adding a black line at the bottom of the DGV
            If i <> foxes.Count - 1 Then
                dgvWIPEntries.Rows(dgvWIPEntries.RowCount - 1).DefaultCellStyle.BackColor = Color.Black
                dgvWIPEntries.Rows(dgvWIPEntries.RowCount - 1).Height = 1
            End If
        Next
        con1.Close()
    End Sub

    Private Sub FormatDGV()
        dgvWIPEntries.DefaultCellStyle.SelectionBackColor = Color.White
        dgvWIPEntries.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvWIPEntries.Columns.Add("FOXNumber", "")
        dgvWIPEntries.Columns("FOXNumber").Width = 100
        dgvWIPEntries.Columns.Add("StepNumber", "")
        dgvWIPEntries.Columns("StepNumber").Width = 300
        dgvWIPEntries.Columns.Add("MachineClass", "")
        dgvWIPEntries.Columns("MachineClass").Width = 125
        dgvWIPEntries.Columns.Add("MachineID", "")
        dgvWIPEntries.Columns("MachineID").Width = 175
        dgvWIPEntries.Columns.Add("MachineDescription", "")
        dgvWIPEntries.Columns("MachineDescription").Width = 175
        dgvWIPEntries.Columns.Add("PiecesProduced", "")
        dgvWIPEntries.Columns("PiecesProduced").Width = 175
    End Sub

    ''calculates the remaining pieces for each step based on what is in the proceeding steps
    Private Sub calculateTotals(ByRef steps As List(Of stepInfo))
        For i As Integer = 0 To steps.Count - 2
            If steps(i + 1).stepNumber <> 999 Then
                steps(i).pieces -= steps(i + 1).pieces
            End If
        Next
    End Sub
    ''adds formatting ot make the data easier to read
    Private Sub addFormatting()
        dgvWIPEntries.Columns("FOXNumber").HeaderText = "FOX Number"
        dgvWIPEntries.Columns("FOXNumber").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvWIPEntries.Columns("ShortDescription").HeaderText = "Part Description"
        dgvWIPEntries.Columns("ShortDescription").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvWIPEntries.Columns("FOXNumber").DefaultCellStyle.Font = New System.Drawing.Font(DefaultFont.FontFamily, 11, FontStyle.Bold, GraphicsUnit.Point)
        dgvWIPEntries.Columns("ProcessStep").HeaderText = "Step #"
        dgvWIPEntries.Columns("ProcessStep").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvWIPEntries.Columns("MachineClass").HeaderText = "Class - Description"
        dgvWIPEntries.Columns("PostingDate").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvWIPEntries.Columns("PostingDate").HeaderText = "Date Produced"
        dgvWIPEntries.Columns("MachineClass").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvWIPEntries.Columns("MachineNumber").HeaderText = "Machine Used"
        dgvWIPEntries.Columns("MachineNumber").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvWIPEntries.Columns("PiecesProduced").HeaderText = "Pieces Completed"
        dgvWIPEntries.Columns("PiecesProduced").SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim currentFOX As String = ""
        Dim dsTemp As New DataSet
        dsTemp.Tables.Add("TimeSlipWHIPREport")
        dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("FOXNumber")
        dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("ShortDescription")
        dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("ProcessStep")
        dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("PostingDate")
        dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("MachineNumber")
        dsTemp.Tables("TimeSlipWHIPREport").Columns.Add("PiecesProduced")

        For i As Integer = 0 To dgvWIPEntries.Rows.Count - 1
            dsTemp.Tables("TimeSlipWHIPREport").Rows.Add(dgvWIPEntries.Rows(i).Cells("FOXNumber").Value, dgvWIPEntries.Rows(i).Cells("MachineDescription").Value, dgvWIPEntries.Rows(i).Cells("StepNumber").Value, dgvWIPEntries.Rows(i).Cells("MachineClass").Value, dgvWIPEntries.Rows(i).Cells("MachineID").Value, dgvWIPEntries.Rows(i).Cells("PiecesProduced").Value)
            If IsDBNull(dsTemp.Tables("TimeSlipWHIPREport").Rows(i).Item("FOXNumber")) Then
                dsTemp.Tables("TimeSlipWHIPREport").Rows(i).Item("FOXNumber") = currentFOX
            Else
                currentFOX = dsTemp.Tables("TimeSlipWHIPREport").Rows(i).Item("FOXNumber")
            End If
        Next

        Dim newPrintWIP As New PrintWIP(dsTemp)
        newPrintWIP.ShowDialog()
    End Sub

    ''gets the description for the passed machine
    Private Function getMachineDescription(ByVal machine As String) As String
        cmd = New SqlCommand("SELECT Description FROM MachineTable WHERE MachineID = @MachineID;", con)
        cmd.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = machine
        Dim descr As String = ""

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            descr = cmd.ExecuteScalar()
        Catch ex As System.Exception
            descr = "UNKNOWN"
        End Try
        con.Close()

        Return " - " + descr
    End Function

    Private Sub bgwkGetWIP_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkGetWIP.DoWork
        Dim dates As Date() = e.Argument
        Dim beginDate As Date = dates(0)
        Dim endDate As Date = dates(1)
        Dim ds As New DataSet
        getTimeSlipData(ds)
        Dim foxes As New Dictionary(Of String, FOXData)
        'Dim foxes As New List(Of FOXData)
        If bgwkGetWIP.CancellationPending Then
            e.Cancel = True
            e.Result = foxes
            Exit Sub
        End If
        FillFoxes(ds, foxes)
        If bgwkGetWIP.CancellationPending Then
            e.Cancel = True
            e.Result = foxes
            Exit Sub
        End If
        LoadSteps(foxes)
        If bgwkGetWIP.CancellationPending Then
            e.Cancel = True
            e.Result = foxes
            Exit Sub
        End If
        AddPieceCounts(foxes, ds, beginDate, endDate)
        If bgwkGetWIP.CancellationPending Then
            e.Cancel = True
            e.Result = foxes
            Exit Sub
        End If
        RemoveAboveFGStep(foxes)
        If bgwkGetWIP.CancellationPending Then
            e.Cancel = True
            e.Result = foxes
            Exit Sub
        End If
        RemoveZeroPieces(foxes)
        e.Result = foxes
    End Sub

    Private Sub bgwkGetWIP_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkGetWIP.RunWorkerCompleted
        lblBGWKWaitMessage.Text = "Building Report Please Wait"
        pnlCancelBGWK.Visible = False
        If Not e.Cancelled Then
            Dim foxes As Dictionary(Of String, FOXData) = e.Result
            DisplayFOXSteps(foxes)
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If bgwkGetWIP.IsBusy Then
            bgwkGetWIP.CancelAsync()
            lblBGWKWaitMessage.Text = "Cancelling, please wait"
            tmrChangeText.Stop()
        End If
    End Sub

    Private Sub ViewWIP_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If bgwkGetWIP.IsBusy Then
            bgwkGetWIP.CancelAsync()
            lblBGWKWaitMessage.Text = "Cancelling, please wait"
            tmrChangeText.Stop()
        End If
        While bgwkGetWIP.IsBusy
            System.Threading.Thread.Sleep(500)
        End While
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

    Private Sub cboFOXNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFOXNumber.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub cboItemDiameter_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemDiameter.Leave
        If cboItemDiameter.SelectedIndex = -1 AndAlso Not String.IsNullOrEmpty(cboItemDiameter.Text) Then
            If Not cboItemDiameter.Text.Contains("/") Then
                cboItemDiameter.Text = usefulFunctions.GetFractional(cboItemDiameter.Text)
            End If
        End If
    End Sub

    Private Sub ViewWIP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
