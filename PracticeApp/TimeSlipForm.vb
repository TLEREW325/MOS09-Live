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
Public Class TimeSlipForm
    Inherits System.Windows.Forms.Form

    'Configure Data Connection and declare variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, dsEmployeeID, dsCarbon, dsSteelSize As DataSet
    Dim isloaded = False
    Dim needsSaved As Boolean = False
    Dim shouldMove As Boolean = True
    Dim controlKey As Boolean = False
    Const constLabor As Double = 28
    Dim OriginalPart As String = Nothing

    Dim NewProductionQuantityEntry As StringNumberInputBox

    Public Sub New()
        InitializeComponent()

        If Now.DayOfWeek.Equals(DayOfWeek.Monday) Then
            dtpTimeSlipDate.Value = Now.AddDays(-3)
        Else
            If EmployeeLoginName = "CDAVIES" Then
                'Skip Back Date
            Else
                dtpTimeSlipDate.Value = Now.AddDays(-1)
            End If
        End If
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvTimeSlipLines.CellValueChanged
        If isloaded Then
            isloaded = False
            If EmployeeSecurityCode > 1002 And Not IsDBNull(dgvTimeSlipLines.Rows(e.RowIndex).Cells("PiecesProduced").Value) Then
                If dgvTimeSlipLines.Rows(e.RowIndex).Cells("PiecesProduced").Value < 0 Then
                    MessageBox.Show("You can not add a negative piece count", "Unable to add a negative piece count", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ShowTimeSlipData()
                    isloaded = True
                    Exit Sub
                End If
            End If

            Dim currentRow As Integer = e.RowIndex
            Dim currentColumn As Integer = e.ColumnIndex

            Dim totalHours As Double = 0.0
            If IsDBNull(dgvTimeSlipLines.Rows(currentRow).Cells("MachineHours").Value) = False Then
                totalHours += dgvTimeSlipLines.Rows(currentRow).Cells("MachineHours").Value
            Else
                dgvTimeSlipLines.Rows(currentRow).Cells("MachineHours").Value = 0.0
            End If
            If IsDBNull(dgvTimeSlipLines.Rows(currentRow).Cells("SetupHours").Value) = False Then
                totalHours += dgvTimeSlipLines.Rows(currentRow).Cells("SetupHours").Value
            Else
                dgvTimeSlipLines.Rows(currentRow).Cells("SetupHours").Value = 0.0
            End If
            If IsDBNull(dgvTimeSlipLines.Rows(currentRow).Cells("ToolingHours").Value) = False Then
                totalHours += dgvTimeSlipLines.Rows(currentRow).Cells("ToolingHours").Value
            Else
                dgvTimeSlipLines.Rows(currentRow).Cells("ToolingHours").Value = 0.0
            End If
            If IsDBNull(dgvTimeSlipLines.Rows(currentRow).Cells("OtherHours").Value) = False Then
                totalHours += dgvTimeSlipLines.Rows(currentRow).Cells("OtherHours").Value
            Else
                dgvTimeSlipLines.Rows(currentRow).Cells("OtherHours").Value = 0.0
            End If

            cmd = New SqlCommand("SELECT RawMaterialWeight FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = dgvTimeSlipLines.Rows(currentRow).Cells("FOXNumber").Value
            If con.State = ConnectionState.Closed Then con.Open()
            Dim perthou As Double = cmd.ExecuteScalar()
            con.Close()
            perthou = perthou / 1000
            Dim totalWeight As Double = 0.0
            If IsDBNull(dgvTimeSlipLines.Rows(currentRow).Cells("PiecesProduced").Value) = False Then
                totalWeight = dgvTimeSlipLines.Rows(currentRow).Cells("PiecesProduced").Value * perthou
            Else
                dgvTimeSlipLines.Rows(currentRow).Cells("PiecesProducedColumn").Value = 0.0
            End If

            cmd = New SqlCommand("UPDATE TimeSlipCombinedData SET MachineHours = @MachineHours, SetupHours = @SetupHours, ToolingHours = @ToolingHours, OtherHours = @OtherHours, TotalHours = @TotalHours, PiecesProduced = @PiecesProduced, LineWeight = @LineWeight, ScrapWeight = @ScrapWeight WHERE LineKey = @LineKey AND TimeSlipKey = (SELECT TimeSlipKey FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED')", con)

            With cmd.Parameters
                .Add("@MachineHours", SqlDbType.VarChar).Value = dgvTimeSlipLines.Rows(currentRow).Cells("MachineHours").Value
                .Add("@SetupHours", SqlDbType.VarChar).Value = dgvTimeSlipLines.Rows(currentRow).Cells("SetupHours").Value
                .Add("@ToolingHours", SqlDbType.VarChar).Value = dgvTimeSlipLines.Rows(currentRow).Cells("ToolingHours").Value
                .Add("@OtherHours", SqlDbType.VarChar).Value = dgvTimeSlipLines.Rows(currentRow).Cells("OtherHours").Value
                .Add("@TotalHours", SqlDbType.VarChar).Value = totalHours
                .Add("@PiecesProduced", SqlDbType.VarChar).Value = dgvTimeSlipLines.Rows(currentRow).Cells("PiecesProduced").Value
                .Add("@LineWeight", SqlDbType.VarChar).Value = totalWeight
                .Add("@ScrapWeight", SqlDbType.VarChar).Value = dgvTimeSlipLines.Rows(currentRow).Cells("ScrapWeight").Value
                .Add("@LineKey", SqlDbType.VarChar).Value = dgvTimeSlipLines.Rows(currentRow).Cells("LineKey").Value
                .Add("@PostingDate", SqlDbType.VarChar).Value = dtpTimeSlipDate.Value
                .Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
            End With
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowTimeSlipData()
            isloaded = True
            dgvTimeSlipLines.CurrentCell = dgvTimeSlipLines.Rows(currentRow).Cells(currentColumn)
        End If
    End Sub

    Public Sub ShowTimeSlipData()
        cmd = New SqlCommand("SELECT LineKey, FOXNumber, PartNumber, MachineNumber, MachineHours, SetupHours, ToolingHours, OtherHours, TotalHours, PiecesProduced, LineWeight, ScrapWeight, RMID, InventoryPieces FROM TimeSlipLineItemTable WHERE TimeSlipKey = (SELECT TimeSlipKey FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED') ORDER BY LineKey", con)
        cmd.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = dtpTimeSlipDate.Value
        cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "TimeSlipLineItemTable")
        con.Close()

        cboDeleteLine.DataSource = ds.Tables("TimeSlipLineItemTable")
        cboDeleteLine.DisplayMember = "LineKey"
        ''checks to see if isloaded was set to false before getting ot this point
        Dim changeBack As Boolean = True
        If isloaded = False Then
            changeBack = False
        Else
            isloaded = True
        End If
        dgvTimeSlipLines.DataSource = ds.Tables("TimeSlipLineItemTable")

        dgvTimeSlipLines.Columns("RMID").Visible = False
        dgvTimeSlipLines.Columns("InventoryPieces").Visible = False
        dgvTimeSlipLines.Columns("LineKey").Visible = False

        dgvTimeSlipLines.Columns("PartNumber").ReadOnly = True
        dgvTimeSlipLines.Columns("MachineNumber").ReadOnly = True
        dgvTimeSlipLines.Columns("TotalHours").ReadOnly = True
        dgvTimeSlipLines.Columns("LineWeight").ReadOnly = True
        dgvTimeSlipLines.Columns("FOXNumber").ReadOnly = True

        dgvTimeSlipLines.Columns("FOXNumber").HeaderText = "Fox #"
        dgvTimeSlipLines.Columns("PartNumber").HeaderText = "Part #"
        dgvTimeSlipLines.Columns("MachineNumber").HeaderText = "Machine #"
        dgvTimeSlipLines.Columns("MachineHours").HeaderText = "Machine Hours"
        dgvTimeSlipLines.Columns("SetupHours").HeaderText = "Setup Hours"
        dgvTimeSlipLines.Columns("ToolingHours").HeaderText = "Tooling Hours"
        dgvTimeSlipLines.Columns("OtherHours").HeaderText = "Other Hours"
        dgvTimeSlipLines.Columns("TotalHours").HeaderText = "Total Hours"
        dgvTimeSlipLines.Columns("PiecesProduced").HeaderText = "Pieces Produced"
        dgvTimeSlipLines.Columns("LineWeight").HeaderText = "Line Weight"
        dgvTimeSlipLines.Columns("LineWeight").DefaultCellStyle.Format = "N2"
        dgvTimeSlipLines.Columns("ScrapWeight").HeaderText = "Scrap Weight"
        ''will turn isloaded back on if it was found to be on
        If changeBack Then
            isloaded = True
        End If
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable WHERE DivisionID = 'TFP' OR DivisionID = 'TWD' AND Status <> 'INACTIVE'", con)
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "FOXTable")
        con.Close()

        cboFOXNumber.DisplayMember = "FOXNumber"
        cboFOXNumber.DataSource = ds2.Tables("FOXTable")
        cboFOXNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadCarbon()
        cmd = New SqlCommand("SELECT DISTINCT(Carbon) FROM RawMaterialsTable WHERE DivisionID = 'TWD'", con)
        dsCarbon = New DataSet()
        myAdapter3.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(dsCarbon, "RawMaterialsTable")
        con.Close()

        cboCarbon.DisplayMember = "Carbon"
        cboCarbon.DataSource = dsCarbon.Tables("RawMaterialsTable")
        cboCarbon.SelectedIndex = -1
    End Sub

    Private Sub LoadSteelSize()
        cmd = New SqlCommand("SELECT DISTINCT(SteelSize) FROM RawMaterialsTable WHERE DivisionID = 'TWD'", con)
        dsSteelSize = New DataSet()
        myAdapter3.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(dsSteelSize, "RawMaterialsTable")
        con.Close()

        cboDiameter.DisplayMember = "SteelSize"
        cboDiameter.DataSource = dsSteelSize.Tables("RawMaterialsTable")
        cboDiameter.SelectedIndex = -1
    End Sub

    Public Sub LoadMachineNumber()
        cmd = New SqlCommand("SELECT MachineID FROM MachineTable", con)
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "MachineTable")
        con.Close()

        cboMachineNumber.DisplayMember = "MachineID"
        cboMachineNumber.DataSource = ds4.Tables("MachineTable")
        cboMachineNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadTimeSlipData()
        Dim Shift As Integer = 1
        Dim Status As String = "OPEN"

        Dim cmd As New SqlCommand("SELECT Shift, Status FROM TimeSlipHeaderTable WHERE TimeSlipKey = (SELECT TimeSlipKey FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED')", con)
        cmd.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = dtpTimeSlipDate.Value
        cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Shift")) Then
                Shift = 1
            Else
                Shift = reader.Item("Shift")
            End If
            If IsDBNull(reader.Item("Status")) Then
                Status = "OPEN"
            Else
                Status = reader.Item("Status")
            End If
            cboShiftNumber.Text = Shift
        Else
            Status = "OPEN"
        End If
        reader.Close()
        con.Close()

        If Status = "POSTED" Then
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            DeleteDataToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            DeleteDataToolStripMenuItem.Enabled = True
        End If

    End Sub

    Public Sub LoadFoxData()
        Dim Partnumber, carb, siz As String
        Dim PieceWeightPer1000 As Double

        Dim cmd As New SqlCommand("SELECT PartNumber, RawMaterialsTable.Carbon, RawMaterialsTable.SteelSize, FinishedWeight FROM FOXTable Left Outer Join RawMaterialsTable on FOXTable.RMID = RawMaterialsTable.RMID WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(cboFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("Carbon")) Then
                carb = ""
            Else
                carb = reader.Item("Carbon")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                siz = ""
            Else
                siz = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("FinishedWeight")) Then
                PieceWeightPer1000 = 0
            Else
                PieceWeightPer1000 = reader.Item("FinishedWeight")
            End If
        Else
            PartNumber = ""
            carb = ""
            siz = ""
            PieceWeightPer1000 = 0
        End If
        reader.Close()
        con.Close()

        txtPartNumber.Text = PartNumber
        cboCarbon.Text = carb
        cboDiameter.Text = siz
        lblPieceWeightPer1000.Text = PieceWeightPer1000
        If PieceWeightPer1000 <> 0 Then
            lblPieceWeightSingle.Text = (Val(lblPieceWeightPer1000.Text) / 1000).ToString()
        End If
    End Sub

    Public Sub LoadPartData()
        cmd = New SqlCommand("SELECT LongDescription FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP')", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LongDescription")) Then
                txtPartDescription.Text = ""
            Else
                txtPartDescription.Text = reader.Item("LongDescription")
            End If
        Else
            txtPartDescription.Text = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub LoadFOXRouting()
        cmd = New SqlCommand("SELECT ProcessStep, ProcessID, ProcessAddFG FROM FOXSched WHERE FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)

        Dim tempds As New DataSet
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "FOXSched")
        con.Close()

        dgvFOXRouting.DataSource = tempds.Tables("FOXSched")
        dgvFOXRouting.Columns("ProcessAddFG").Visible = False
        ColorRoutingLines()
    End Sub

    Private Sub ColorRoutingLines()
        For i As Integer = 0 To dgvFOXRouting.Rows.Count - 1
            If dgvFOXRouting.Rows(i).Cells("ProcessAddFG").Value.ToString.Equals("ADDINVENTORY") Then
                dgvFOXRouting.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
            End If
        Next
    End Sub

    Public Sub LoadSteelCost()
        Dim SteelCost As Double = 0
        cmd = New SqlCommand("SELECT SteelCostPerPound FROM SteelCostingTable WHERE TransactionNumber = (SELECT MAX(TransactionNumber FROM SteelCostingTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize))", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboDiameter.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SteelCost = cmd.ExecuteScalar()
        Catch ex As System.Exception
            SteelCost = 0
        End Try
        con.Close()

        If SteelCost = 0 Then
            cmd = New SqlCommand("SELECT SteelCostPerPound FROM SteelReceivingLineQuery WHERE SteelReceivingHeaderKey = (SELECT MAX(SteelReceivingHeaderKey) FROM SteelReceivingLineTable WHERE RMID = (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize))", con)
            cmd.Parameters.Add("@Carbon", SqlDbType.VarBinary).Value = cboCarbon.Text
            cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboDiameter.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SteelCost = cmd.ExecuteScalar()
            Catch ex As System.Exception
                SteelCost = 0
            End Try
            con.Close()
        End If
    End Sub

    Private Sub LoadEmployeeNumber()
        cmd = New SqlCommand("SELECT EmployeeID FROM EmployeeData", con)
        dsEmployeeID = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dsEmployeeID, "EmployeeData")
        con.Close()

        cboEmployeeID.DisplayMember = "EmployeeID"
        cboEmployeeID.DataSource = dsEmployeeID.Tables("EmployeeData")
        cboEmployeeID.SelectedIndex = -1
    End Sub

    Private Sub LoadEmployeeName()
        Dim first, last As String
        Dim Shift As Integer = 1
        cmd = New SqlCommand("SELECT EmployeeFirst, EmployeeLast, Shift FROM EmployeeData WHERE EmployeeID = @EmployeeID", con)
        cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("EmployeeFirst")) Then
                first = ""
            Else
                first = reader.Item("EmployeeFirst")
            End If
            If IsDBNull(reader.Item("EmployeeLast")) Then
                last = ""
            Else
                last = reader.Item("EmployeeLast")
            End If
            If Not IsDBNull(reader.Item("Shift")) Then
                Shift = reader.Item("Shift")
            End If
        Else
            first = ""
            last = ""
            Shift = 1
        End If
        reader.Close()
        con.Close()

        lblEmployeeName.Text = first + " " + last
        cboShiftNumber.Text = Shift.ToString()
    End Sub

    Public Sub ClearVariables()
        needsSaved = False
    End Sub

    Public Sub ClearData()
        gpxTimeSlip.Enabled = True

        cboEmployeeID.Refresh()
        cboFOXNumber.Refresh()
        cboMachineNumber.Refresh()
        cboCarbon.Refresh()
        cboDiameter.Refresh()

        txtMachineHours.Refresh()
        txtOtherHours.Refresh()
        txtPiecesProduced.Refresh()
        txtScrapWeight.Refresh()
        txtSetupHours.Refresh()
        txtToolingHours.Refresh()
        txtWeightProduced.Refresh()

        cboEmployeeID.SelectedIndex = -1
        cboFOXNumber.SelectedIndex = -1
        cboMachineNumber.SelectedIndex = -1
        cboCarbon.SelectedIndex = -1
        cboDiameter.SelectedIndex = -1
        cboShiftNumber.SelectedIndex = 0
        cboDeleteLine.Text = ""

        txtPartNumber.Clear()
        txtMachineHours.Clear()
        txtOtherHours.Clear()
        txtPiecesProduced.Clear()
        txtScrapWeight.Clear()
        txtSetupHours.Clear()
        txtToolingHours.Clear()
        txtWeightProduced.Clear()

        lblEmployeeName.Text = ""
        lblPieceWeightPer1000.Text = ""
        lblPieceWeightSingle.Text = ""

        dgvFOXRouting.DataSource = Nothing

        cmdDelete.Enabled = True
        cmdSave.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        DeleteDataToolStripMenuItem.Enabled = True

        chkFromAnotherPart.Enabled = False
        chkFromAnotherPart.Checked = False
        cboEmployeeID.Focus()
    End Sub

    Public Sub ClearLines()
        cboMachineNumber.Refresh()
        cboFOXNumber.Refresh()
        cboCarbon.Refresh()
        cboDiameter.Refresh()

        cboCarbon.SelectedIndex = -1
        cboDiameter.SelectedIndex = -1
        cboFOXNumber.SelectedIndex = -1
        cboMachineNumber.SelectedIndex = -1

        txtOtherHours.Clear()
        txtMachineHours.Clear()
        txtPiecesProduced.Clear()
        txtScrapWeight.Clear()
        txtSetupHours.Clear()
        txtToolingHours.Clear()
        txtWeightProduced.Clear()
        txtPartNumber.Clear()
        lblTotalLineHours.Text = ""
        lblPieceWeightPer1000.Text = ""
        lblPieceWeightSingle.Text = ""
        chkRollerAttached.Checked = False
        chkFromAnotherPart.Enabled = False
        chkFromAnotherPart.Checked = False
        cboEmployeeID.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If canExit() Then
            'Save Data to Time Slip Header Database Table
            cmd = New SqlCommand("UPDATE TimeSlipHeaderTable SET PostingDate = @PostingDate, EmployeeID = @EmployeeID, Shift = @Shift, DivisionID = @DivisionID WHERE TimeSlipKey = (SELECT TimeSlipKey FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED')", con)

            With cmd.Parameters
                .Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
                .Add("@PostingDate", SqlDbType.VarChar).Value = dtpTimeSlipDate.Text
                .Add("@Shift", SqlDbType.VarChar).Value = Val(cboShiftNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Time Slip data has been saved", MsgBoxStyle.OkOnly)
        End If
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Function canExit() As Boolean
        If GetStatus().Equals("POSTED") Then
            Return False
        End If
        If needsSaved = False Then
            Return False
        End If
        If MessageBox.Show("Do you wish to save any changes in this Time Slip?", "SAVE TIME SLIP", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Function GetStatus() As String
        Dim Status As String = "OPEN"
        cmd = New SqlCommand("SELECT Status FROM TimeSlipHeaderTable WHERE TimeSlipKey = (SELECT TimeSlipKey FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED')", con)
        cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
        cmd.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = dtpTimeSlipDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()
        If Not IsDBNull(obj) Then
            If obj IsNot Nothing Then
                Status = obj
            End If
        End If
        Return Status
    End Function

    Private Sub TimeSlipForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load defaults and clear text boxes on load
        LoadFOXNumber()
        LoadCarbon()
        LoadSteelSize()
        LoadMachineNumber()
        LoadEmployeeNumber()

        'Initialize starting values
        ShowTimeSlipData()
        cboEmployeeID.Focus()
        cboShiftNumber.SelectedIndex = 0
        isloaded = True
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        'Clear text boxes
        ClearLines()
        ShowTimeSlipData()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub Hours_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMachineHours.TextChanged, txtSetupHours.TextChanged, txtToolingHours.TextChanged, txtOtherHours.TextChanged
        updateHourTotals()
    End Sub

    Private Sub updateHourTotals()
        lblTotalLineHours.Text = Math.Round(Val(txtMachineHours.Text) + Val(txtSetupHours.Text) + Val(txtToolingHours.Text) + Val(txtOtherHours.Text), 2)
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click, SaveToolStripMenuItem.Click
        If canSave() Then
            If updateTimeSlipHeaderTable() Then
                MsgBox("Time Slip Data has been saved. Don't forget to post data.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboEmployeeID.Text) = False Then
            If cboEmployeeID.SelectedIndex = -1 Then
                MessageBox.Show("You must enter a valid Employee Number.", "Enter a valid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboEmployeeID.SelectAll()
                cboEmployeeID.Focus()
                Return False
            End If

            ''Check to see if steel is de-activated
            'Dim ValidateSteel As Integer = 0

            'Dim ValidateSteelStatement As String = "SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize AND SteelStatus <> 'CLOSED' AND DivisionID = 'TWD'"
            'Dim ValidateSteelCommand As New SqlCommand(ValidateSteelStatement, con)
            'ValidateSteelCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
            'ValidateSteelCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboDiameter.Text

            'If con.State = ConnectionState.Closed Then con.Open()
            'Try
            '    ValidateSteel = CInt(ValidateSteelCommand.ExecuteScalar)
            'Catch ex As Exception
            '    ValidateSteel = 0
            'End Try
            'con.Close()

            'If ValidateSteel = 0 Then
            '    MessageBox.Show("Steel does not exist or is closed (de-activated).", "Enter a valid steel.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Return False
            'End If
        End If
        Return True
    End Function

    Private Sub cmdEnterData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterData.Click
        If canEnter() Then
            
            Dim foxStep As Integer = getFOXStep(cboMachineNumber.Text)
            If foxStep = 0 Then
                con.Close()
                Exit Sub
            End If

            ''checks to see if there is an entry for the given Employee if not this will enter one for them into the header table
            cmd = New SqlCommand("if (SELECT Count(TimeSlipKey) FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED') = 0 begin INSERT INTO TimeSlipHeaderTable (TimeSlipKey, PostingDate, EmployeeID, Shift, DivisionID, Status, EmployeeName, PostedBy) VALUES((SELECT ISNULL(MAX(TimeSlipKey) + 1, 220001) FROM TimeSlipHeaderTable), @PostingDate, @EmployeeID, @Shift, @DivisionID, 'OPEN', @EmployeeName, @PostedBy) end", con)
            cmd.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = dtpTimeSlipDate.Text
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
            cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = lblEmployeeName.Text
            cmd.Parameters.Add("@Shift", SqlDbType.VarChar).Value = cboShiftNumber.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            cmd.Parameters.Add("@PostedBy", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()

            Try
                ''writes the time slip line item to the DB and will also check if add to FG and will add the piece count to the invnetory column if needed
                cmd = New SqlCommand("Insert Into TimeSlipLineItemTable(TimeSlipKey, LineKey, FOXNumber, MachineNumber, PartNumber, MachineHours, SetupHours, ToolingHours, OtherHours, PiecesProduced, ScrapWeight, LineWeight, TotalHours, InventoryPieces, RMID, ExtendedCost, Cost, FOXStep, DivisionID, PostedSpecial, PostingReversed, PostingAddFG, ProductionNumber, OriginalPart)" _
                                     + " Values((SELECT isnull(TimeSlipKey, (SELECT isnull(MAX(TimeSlipKey) + 1, 220001) FROM TimeSlipHeaderTable)) FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED'), (SELECT isnull(MAX(LineKey) + 1, 1) FROM TimeSlipLineItemTable WHERE TimeSlipKey = (SELECT isnull(TimeSlipKey, (SELECT isnull(MAX(TimeSlipKey) + 1, 220001) FROM TimeSlipHeaderTable)) FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED')), @FOXNumber, @MachineNumber, @PartNumber, @MachineHours, @SetupHours, @ToolingHours, @OtherHours, @PiecesProduced, @ScrapWeight, @LineWeight, @TotalHours, 0, (SELECT TOP 1 RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @ExtendedCost, @Cost, @FOXStep, (SELECT case when @DivisionID = '' then DivisionID else @DivisionID end FROM FOXTable WHERE FOXNumber = @FOXNumber), 'False', 'False', 'False' , (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN'), @OriginalPart)", con)

                With cmd.Parameters
                    .Add("@PostingDate", SqlDbType.VarChar).Value = dtpTimeSlipDate.Value
                    .Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                    .Add("@MachineNumber", SqlDbType.VarChar).Value = cboMachineNumber.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                    .Add("@MachineHours", SqlDbType.VarChar).Value = Val(txtMachineHours.Text)
                    .Add("@SetupHours", SqlDbType.VarChar).Value = Val(txtSetupHours.Text)
                    .Add("@ToolingHours", SqlDbType.VarChar).Value = Val(txtToolingHours.Text)
                    .Add("@OtherHours", SqlDbType.VarChar).Value = Val(txtOtherHours.Text)
                    .Add("@PiecesProduced", SqlDbType.VarChar).Value = txtPiecesProduced.Text
                    .Add("@ScrapWeight", SqlDbType.VarChar).Value = Val(txtScrapWeight.Text)
                    .Add("@LineWeight", SqlDbType.VarChar).Value = Val(txtPiecesProduced.Text) * Val(lblPieceWeightSingle.Text)
                    .Add("@TotalHours", SqlDbType.VarChar).Value = Val(txtMachineHours.Text) + Val(txtSetupHours.Text) + Val(txtToolingHours.Text) + Val(txtOtherHours.Text)
                    .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                    .Add("@SteelSize", SqlDbType.VarChar).Value = cboDiameter.Text
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = 0
                    .Add("@Cost", SqlDbType.VarChar).Value = 0
                    .Add("@FOXStep", SqlDbType.VarChar).Value = foxStep
                End With

                ''Check to see if the user selected to remove from an existing part. (ONLY EFFECTS INVENTORY NOT RACKING)
                If OriginalPart IsNot Nothing Then
                    cmd.Parameters.Add("@OriginalPart", SqlDbType.VarChar).Value = OriginalPart
                Else
                    cmd.Parameters.Add("@OriginalPart", SqlDbType.VarChar).Value = DBNull.Value
                End If

                If EmployeeCompanyCode.Equals("TST") Then
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                Else
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ""
                End If
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
            Catch ex As SqlException
                sendErrorToDataBase("TimeSlipForm - cmdEnterData_Click --Error trying to insert into TimeSlipLineItemTable", "Employee ID #" + cboEmployeeID.Text, ex.ToString())
            End Try

            OriginalPart = Nothing

            If chkRollerAttached.Checked Then
                foxStep = getFOXStep("188")
                If foxStep = 0 Then
                    con.Close()
                    'Clear data and reset form
                    ClearLines()
                    ShowTimeSlipData()
                    Exit Sub
                End If

                Try
                    ''writes the time slip line item to the DB and will also check if add to FG and will add the piece count to the inventory column if needed
                    cmd = New SqlCommand("Insert Into TimeSlipLineItemTable(TimeSlipKey, LineKey, FOXNumber, MachineNumber, PartNumber, MachineHours, SetupHours, ToolingHours, OtherHours, PiecesProduced, ScrapWeight, LineWeight, TotalHours, InventoryPieces, RMID, ExtendedCost, Cost, FOXStep, DivisionID, PostedSpecial, PostingReversed, PostingAddFG, ProductionNumber)Values((SELECT isnull(TimeSlipKey, (SELECT isnull(MAX(TimeSlipKey) + 1, 220001) FROM TimeSlipHeaderTable)) FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED'), (SELECT isnull(MAX(LineKey) + 1, 1) FROM TimeSlipLineItemTable WHERE TimeSlipKey = (SELECT isnull(TimeSlipKey, (SELECT isnull(MAX(TimeSlipKey) + 1, 220001) FROM TimeSlipHeaderTable)) FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED')), @FOXNumber, @MachineNumber, @PartNumber, @MachineHours, @SetupHours, @ToolingHours, @OtherHours, @PiecesProduced, @ScrapWeight, @LineWeight, @TotalHours, 0, (SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize), @ExtendedCost, @Cost, @FOXStep, (SELECT case when @DivisionID = '' then DivisionID else @DivisionID end FROM FOXTable WHERE FOXNumber = @FOXNumber), 'False', 'False', 'False', (SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN'))", con)

                    With cmd.Parameters
                        .Add("@PostingDate", SqlDbType.VarChar).Value = dtpTimeSlipDate.Value
                        .Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
                        .Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                        .Add("@MachineNumber", SqlDbType.VarChar).Value = "188"
                        .Add("@PartNumber", SqlDbType.VarChar).Value = txtPartNumber.Text
                        .Add("@MachineHours", SqlDbType.VarChar).Value = Val(txtMachineHours.Text)
                        .Add("@SetupHours", SqlDbType.VarChar).Value = Val(txtSetupHours.Text)
                        .Add("@ToolingHours", SqlDbType.VarChar).Value = Val(txtToolingHours.Text)
                        .Add("@OtherHours", SqlDbType.VarChar).Value = Val(txtOtherHours.Text)
                        .Add("@PiecesProduced", SqlDbType.VarChar).Value = txtPiecesProduced.Text
                        .Add("@ScrapWeight", SqlDbType.VarChar).Value = Val(txtScrapWeight.Text)
                        .Add("@LineWeight", SqlDbType.VarChar).Value = Val(txtPiecesProduced.Text) * Val(lblPieceWeightSingle.Text)
                        .Add("@TotalHours", SqlDbType.VarChar).Value = Val(txtMachineHours.Text) + Val(txtSetupHours.Text) + Val(txtToolingHours.Text) + Val(txtOtherHours.Text)
                        .Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
                        .Add("@SteelSize", SqlDbType.VarChar).Value = cboDiameter.Text
                        .Add("@ExtendedCost", SqlDbType.VarChar).Value = 0
                        .Add("@Cost", SqlDbType.VarChar).Value = 0
                        .Add("@FOXStep", SqlDbType.VarChar).Value = foxStep
                    End With
                    If EmployeeCompanyCode.Equals("TST") Then
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                    Else
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ""
                    End If

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    sendErrorToDataBase("TimeSlipForm - cmdEnterData_Click --Error trying to insert into TimeSlipLineItemTable for Attached Roller", "Employee ID #" + cboEmployeeID.Text, ex.ToString())
                End Try
            End If
            con.Close()

            'Clear data and reset form
            ClearLines()
            ShowTimeSlipData()

            shouldMove = False
        End If
    End Sub

    Private Function canEnter() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            shouldMove = False
            MessageBox.Show("You must select a FOX", "Select a FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        If cboFOXNumber.SelectedIndex = -1 Then
            shouldMove = False
            MessageBox.Show("You must enter a valid FOX", "Enter a valid FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.SelectAll()
            cboFOXNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboEmployeeID.Text) Then
            shouldMove = False
            MessageBox.Show("You must select a valid Employee Number", "Select a valid Employe Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboEmployeeID.Focus()
            Return False
        End If
        If cboEmployeeID.SelectedIndex = -1 Then
            shouldMove = False
            MessageBox.Show("You must enter a valid Employee Number", "Enter a valid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboEmployeeID.SelectAll()
            cboEmployeeID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboMachineNumber.Text) Then
            shouldMove = False
            MessageBox.Show("You must select a machine number", "Select a machine number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMachineNumber.Focus()
            Return False
        End If
        If cboMachineNumber.SelectedIndex = -1 Then
            shouldMove = False
            MessageBox.Show("You must enter a valid machine number", "Enter a valid machine number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMachineNumber.SelectAll()
            cboMachineNumber.Focus()
            Return False
        End If
        If Val(lblPieceWeightSingle.Text) <= 0 Then
            cmd = New SqlCommand("SELECT FinishedWeight FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj1 As Object = cmd.ExecuteScalar()

            If obj1 Is Nothing Then
                con.Close()
                MessageBox.Show("FOX #" + cboFOXNumber.Text + " does not have a valid per thousand weight. Unable to add the time slip entry.", "Unable to add timeslip entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf IsDBNull(obj1) Then
                con.Close()
                MessageBox.Show("FOX #" + cboFOXNumber.Text + " does not have a valid per thousand weight. Unable to add the time slip entry.", "Unable to add timeslip entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            ElseIf Val(obj1) = 0 Then
                con.Close()
                MessageBox.Show("FOX #" + cboFOXNumber.Text + " does not have a valid per thousand weight. Unable to add the time slip entry.", "Unable to add timeslip entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            Else
                lblPieceWeightPer1000.Text = obj1.ToString
                lblPieceWeightSingle.Text = (CType(obj1, Double) / 1000).ToString()
            End If

        End If
        cmd = New SqlCommand("SELECT ItemClass FROM ItemList INNER JOIN FOXTable ON ItemList.ItemID = FOXTable.PartNumber AND ItemList.DivisionID = FOXTable.DivisionID WHERE FOXTable.FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        If obj Is Nothing Then
            con.Close()
            MessageBox.Show("Part does not exist in the system. Unable to post to this FOX.", "Unable to post to FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If obj.ToString().Equals("DEACTIVATED-PART") Then
            con.Close()
            MessageBox.Show("Part has been deactivated in the system. Unable to post to this FOX.", "Unable to post to FOX.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim ProductionNumber As Integer = 0
        Dim division As String = ""

        cmd = New SqlCommand("SELECT ISNULL(ProductionNumber, 0) as ProductionNumber, DivisionID FROM (SELECT FOXNumber, ProductionNumber as ProductionNumber FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber AND Status = 'OPEN') as FOXProductionNumberHeaderTable RIGHT OUTER JOIN (SELECT FOXNumber, DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber) as FOXTable ON FOXProductionNumberHeaderTable.FOXNumber = FOXTable.FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not reader.IsDBNull(0) Then
                ProductionNumber = reader.Item("ProductionNumber")
            End If
            If Not reader.IsDBNull(1) Then
                division = reader.Item("DivisionID")
            End If
        Else
            reader.Close()
            con.Close()
            MessageBox.Show("There was an issue locating some data. Contact system admin.", "Unable to proceed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        reader.Close()

        ''check to see if a production number is open and exists
        If ProductionNumber = 0 Then
            If division.Equals("TWD") Then
                cmd.CommandText = "SELECT COUNT(ProcessStep) FROM FOXSched WHERE FOXNumber = @FOXNumber"

                If con.State = ConnectionState.Closed Then con.Open()
                obj = cmd.ExecuteScalar()
                Dim steps As Integer = 0
                If obj IsNot Nothing Then
                    steps = obj
                End If
                ''checks the step count to see how many steps the FOX has. If the FOX only has 1 step will just generate the new production number. anything else will cause a message
                Select Case steps
                    Case Is > 1
                        If MessageBox.Show("There is no current Production Number. Would you like to start a new production?", "Would you like to start a new production", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                            Return False
                        End If

                        ProductionNumber = ProductionAPI.StartNewProduction(0, Val(cboFOXNumber.Text), GenerateNewProductionQuantityByFOX(cboFOXNumber.Text, con))
                        If ProductionNumber = 0 Then
                            MessageBox.Show("There was a problem with generating a new Production Number. Contact system admin.", "Unable to continue", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return False
                        End If
                    Case Is = 1
                        ProductionNumber = ProductionAPI.StartNewProduction(0, Val(cboFOXNumber.Text), GenerateNewProductionQuantityByFOX(cboFOXNumber.Text, con))
                        If ProductionNumber = 0 Then
                            MessageBox.Show("There was a problem with generating a new Production Number. Contact system admin.", "Unable to continue", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return False
                        End If
                    Case Is < 1
                        MessageBox.Show("FOX doesn't contain any steps. Unable to add entry to a FOX without steps.", "Unable to continue", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                End Select
            ElseIf division.Equals("TFP") Then
                cmd.CommandText = "DECLARE @ProductionNumber as int = (CASE WHEN EXISTS(SELECT isnull(MAX(ProductionNumber), 0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber) THEN (SELECT isnull(MAX(ProductionNumber),0) FROM FOXProductionNumberHeaderTable WHERE FOXNumber = @FOXNumber) ELSE (SELECT 0) END); IF (@ProductionNumber = 0) BEGIN INSERT INTO FOXProductionNumberHeaderTable (ProductionNumber, FOXNumber, ProductionQuantity, StartDate, Status) VALUES (80316, @FOXNumber, @ProductionQuantity, CURRENT_TIMESTAMP, 'OPEN'); INSERT INTO FOXProductionNumberSched (ProductionNumber, FOXNumber, ProcessStep, ProcessID, ProcessAddFG) SELECT 80316, @FOXNumber, ProcessStep, ProcessID, ProcessAddFG FROM FOXSched WHERE FOXNumber = @FOXNumber; SELECT 80316; END ELSE BEGIN UPDATE FOXProductionNumberHeaderTable SET ProductionQuantity = @ProductionQuantity, Status = 'OPEN' WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber; SELECT @ProductionNumber; END;"
                cmd.Parameters.Add("@ProductionQuantity", SqlDbType.Int).Value = Val(GenerateNewProductionQuantityByFOX(cboFOXNumber.Text, con))

                If con.State = ConnectionState.Closed Then con.Open()
                ProductionNumber = cmd.ExecuteScalar()
            End If
        End If

        cmd = New SqlCommand("SELECT COUNT(ProcessID) FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProductionNumber = @ProductionNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = ProductionNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ''check ot make sure there are steps for the FOX
        If cmd.ExecuteScalar() = 0 Then
            con.Close()
            MessageBox.Show("There are no processes for the given FOX. You are unable to post against a FOX with no processes.", "No processes for FOX", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        cmd = New SqlCommand("SELECT COUNT(ProcessID) FROM FOXProductionNumberSched WHERE FOXNumber = @FOXNumber AND ProcessID = @ProcessID AND ProductionNumber = @ProductionNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = cboMachineNumber.Text
        cmd.Parameters.Add("@ProductionNumber", SqlDbType.Int).Value = ProductionNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ''check to see if the machine number entered is in the FOX sched and if not will ask if they wish to proceed with adding the entry
        If cmd.ExecuteScalar() = 0 Then
            If Not similarMachine() Then
                If MessageBox.Show("Current selected machine is not part of the FOX Processes and is not a similar machine for any of the FOX steps. Do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                    shouldMove = False
                    cboMachineNumber.SelectAll()
                    cboMachineNumber.Focus()
                    Return False
                End If
            End If
        End If

        cmd = New SqlCommand("SELECT COUNT(ProcessID) FROM FoxSched WHERE FOXNumber = @FOXNumber AND ProcessAddFG = 'ADDINVENTORY'", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        If cmd.ExecuteScalar() = 0 Then
            con.Close()
            MessageBox.Show("FOX doesn't have a FINISHED GOODS step. Unable to add an entry.", "No FINISHED GOODS step", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboCarbon.Text) Then
            If con.State = ConnectionState.Open Then con.Close()
            shouldMove = False
            MessageBox.Show("You must select a Carbon.", "Select a Carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCarbon.Focus()
            Return False
        End If
        If cboCarbon.SelectedIndex = -1 Then
            If con.State = ConnectionState.Open Then con.Close()
            shouldMove = False
            MessageBox.Show("You must enter a valid Carbon.", "Enter a valid Carbon", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCarbon.SelectAll()
            cboCarbon.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboDiameter.Text) Then
            shouldMove = False
            MessageBox.Show("You must enter a valid Diameter.", "Enter a valid Diameter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDiameter.Focus()
            Return False
        End If
        If cboDiameter.SelectedIndex = -1 Then
            If con.State = ConnectionState.Open Then con.Close()
            shouldMove = False
            MessageBox.Show("You must enter a valid Diameter.", "Enter a valid Diameter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDiameter.SelectAll()
            cboDiameter.Focus()
            Return False
        End If

        cmd = New SqlCommand("IF exists(SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize) SELECT COUNT(RMID) FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize ELSE SELECT 0;", con)
        cmd.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = cboCarbon.Text
        cmd.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = cboDiameter.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            If cmd.ExecuteScalar() = 0 Then
                con.Close()
                MessageBox.Show("Carbon and diameter combination do not exist in the Raw Materials Table. Please check the combination and try again.", "Unable to add", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboDiameter.SelectAll()
                cboDiameter.Focus()
                Return False
            End If
        Catch ex As System.Exception
            sendErrorToDataBase("TimeSlipForm - canEnter -- Error checking to make sure a valid RMID can be found for line entry", "Carbon - " + cboCarbon.Text + " Size - " + cboDiameter.Text, ex.ToString())
        End Try
        con.Close()
        If String.IsNullOrEmpty(txtMachineHours.Text) = False Then
            If IsNumeric(txtMachineHours.Text) = False Then
                shouldMove = False
                MessageBox.Show("Machine Hours entered is not a number, enter a number.", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMachineHours.SelectAll()
                txtMachineHours.Focus()
                Return False
            End If
            If Val(txtMachineHours.Text) >= 20 Then
                If MessageBox.Show("Machine Hours entered is " + txtMachineHours.Text + " is this correct?", "Correct number entered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) <> System.Windows.Forms.DialogResult.Yes Then
                    shouldMove = False
                    txtMachineHours.SelectAll()
                    txtMachineHours.Focus()
                    Return False
                End If
            End If
        End If
        If String.IsNullOrEmpty(txtSetupHours.Text) = False Then
            If IsNumeric(txtSetupHours.Text) = False Then
                shouldMove = False
                MessageBox.Show("Setup Hours entered is not a number, enter a number.", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSetupHours.SelectAll()
                txtSetupHours.Focus()
                Return False
            End If
            If Val(txtSetupHours.Text) >= 20 Then
                If MessageBox.Show("Setup Hours entered is " + txtSetupHours.Text + " is this correct?", "Correct number entered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) <> System.Windows.Forms.DialogResult.Yes Then
                    shouldMove = False
                    txtSetupHours.SelectAll()
                    txtSetupHours.Focus()
                    Return False
                End If
            End If
        End If
        If String.IsNullOrEmpty(txtToolingHours.Text) = False Then
            If IsNumeric(txtToolingHours.Text) = False Then
                shouldMove = False
                MessageBox.Show("Tooling Hours entered is not a number, enter a number.", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtToolingHours.SelectAll()
                txtToolingHours.Focus()
                Return False
            End If
            If Val(txtToolingHours.Text) >= 20 Then
                If MessageBox.Show("Tooling Hours entered is " + txtToolingHours.Text + " is this correct?", "Correct number entered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) <> System.Windows.Forms.DialogResult.Yes Then
                    shouldMove = False
                    txtToolingHours.SelectAll()
                    txtToolingHours.Focus()
                    Return False
                End If
            End If
        End If
        If String.IsNullOrEmpty(txtOtherHours.Text) = False Then
            If IsNumeric(txtOtherHours.Text) = False Then
                shouldMove = False
                MessageBox.Show("Other Hours entered is not a number, enter a number, enter a number.", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtOtherHours.SelectAll()
                txtOtherHours.Focus()
                Return False
            End If
            If Val(txtOtherHours.Text) >= 20 Then
                If MessageBox.Show("Other Hours entered is " + txtOtherHours.Text + " is this correct?", "Correct number entered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) <> System.Windows.Forms.DialogResult.Yes Then
                    shouldMove = False
                    txtOtherHours.SelectAll()
                    txtOtherHours.Focus()
                    Return False
                End If
            End If
        End If
        If IsNumeric(lblTotalLineHours.Text) = False Then
            shouldMove = False
            MessageBox.Show("You must enter at least 1 entry for hours, enter a number.", "Enter hours", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMachineHours.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtPiecesProduced.Text) Then
            shouldMove = False
            MessageBox.Show("You must enter a number for Pieces Produced, enter a number.", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiecesProduced.Focus()
            Return False
        End If
        If IsNumeric(txtPiecesProduced.Text) = False Then
            shouldMove = False
            MessageBox.Show("Pieces Produced is not a number, enter a number.", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPiecesProduced.SelectAll()
            txtPiecesProduced.Focus()
            Return False
        End If
        If EmployeeSecurityCode > 1002 Then
            If Val(txtPiecesProduced.Text) < 0 Then
                MessageBox.Show("You can not add a line with a negative piece count", "Unable to add line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPiecesProduced.SelectAll()
                txtPiecesProduced.Focus()
                Return False
            End If
        End If
        If chkFromAnotherPart.Checked Then
            Dim inp As New InputComboBox("Part Number", Nothing)
            ''Checks the part number for the an ending of z for zinc, n for nickel and b for bent
            If txtPartNumber.Text.EndsWith("-Z") Or txtPartNumber.Text.EndsWith("-N") Or txtPartNumber.Text.EndsWith("-B") Then
                inp.cboInputValue.Text = txtPartNumber.Text.Replace("-Z", "").Replace("-N", "").Replace("-B", "")
                If inp.cboInputValue.SelectedIndex = -1 Then
                    inp.cboInputValue.Text = ""
                End If
            End If
            If inp.ShowDialog() <> DialogResult.OK Then
                OriginalPart = Nothing
                Return False
            End If
            OriginalPart = inp.cboInputValue.Text
        End If
        Return True
    End Function

    Private Function getFOXStep(ByVal machine As String) As Integer
        cmd = New SqlCommand("SELECT ProcessStep, ProcessID, Description, ProcessAddFG FROM FOXSched LEFT OUTER JOIN MachineTable ON ProcessID = MachineID WHERE FOXNumber = @FOXNumber AND ProcessID = @ProcessID", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = machine
        Dim foxStep As String = ""
        Dim stepList As New List(Of Integer)
        Dim stepDescriptions As New List(Of String)
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        ''getting step data from the FOXSched for the entered FOX   
        If reader.HasRows Then
            While reader.Read()
                If Not IsDBNull(reader.Item("ProcessStep")) Then
                    stepList.Add(reader.Item("ProcessStep"))
                    If Not IsDBNull(reader.Item("ProcessID")) And Not IsDBNull(reader.Item("Description")) Then
                        If Not IsDBNull(reader.Item("Description")) Then
                            If reader.Item("ProcessAddFG").ToString().Equals("ADDINVENTORY") Then
                                stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " " + reader.Item("Description") + " (ADDS INVENTORY)")
                            Else
                                stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " " + reader.Item("Description"))
                            End If
                        Else
                            stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " " + reader.Item("Description"))
                        End If

                    ElseIf Not IsDBNull(reader.Item("ProcessID")) Then

                        If Not IsDBNull(reader.Item("ProcessAddFG")) Then
                            If reader.Item("ProcessAddFG").ToString().Equals("ADDINVENTORY") Then
                                stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " (ADDS INVENTORY)")
                            Else
                                stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID"))
                            End If
                        Else
                            stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID"))
                        End If
                    End If
                End If
            End While
            reader.Close()

            If stepDescriptions.Count > 1 Then
                Dim lst As String = ""
                ''adding the different steps to a singuar string to use in the input box
                For i As Integer = 0 To stepDescriptions.Count - 1
                    lst += stepDescriptions(i) + Chr(10)
                Next
                Dim validEntry As Boolean = False
                While Not validEntry
                    Dim selectFOXStep As New TimeSlipSelectFOXStep("Specify which step." + Chr(10) + Chr(10) + lst, "Which Step")
                    If selectFOXStep.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                        Return 0
                    End If
                    foxStep = selectFOXStep.getEnteredStep()
                    If String.IsNullOrEmpty(foxStep) Then
                        Return 0
                    End If
                    ''check to make sure the entered value is a number
                    If IsNumeric(foxStep) Then
                        ''check to see if 0 was entered and if so will exit
                        If Val(foxStep) = 0 Then
                            Return 0
                        End If
                        ''check to make sure it is a valid step number
                        For i As Integer = 0 To stepList.Count - 1
                            If Val(foxStep) = stepList(i) Then
                                validEntry = True
                                Exit For
                            End If
                        Next
                    End If
                End While
            Else
                reader.Close()
                Return stepList(0)
            End If
        Else
            reader.Close()
            If machine.Equals("707") Or machine.Equals("706") Or machine.Equals("708") Or machine.Equals("097") Or machine.Equals("098") Or machine.Equals("099") Then
                cmd = New SqlCommand("SELECT ProcessStep, ProcessID, Description, ProcessAddFG FROM FOXSched LEFT OUTER JOIN MachineTable ON ProcessID = MachineID WHERE FOXNumber = @FOXNumber AND ", con)
                cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
                foxStep = ""
                stepList = New List(Of Integer)
                stepDescriptions = New List(Of String)

                Select Case machine
                    Case "706"
                        cmd.CommandText += " (ProcessID = '707' OR ProcessID = '708')"
                    Case "707"
                        cmd.CommandText += " (ProcessID = '706' OR ProcessID = '708')"
                    Case "708"
                        cmd.CommandText += " (ProcessID = '706' OR ProcessID = '707')"
                    Case "098"
                        cmd.CommandText += " (ProcessID = '097' OR ProcessID = '099')"
                    Case "099"
                        cmd.CommandText += " (ProcessID = '097' OR ProcessID = '098')"
                    Case "097"
                        cmd.CommandText += " (ProcessID = '098' OR ProcessID = '099')"
                End Select

                If con.State = ConnectionState.Closed Then con.Open()
                reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        If Not IsDBNull(reader.Item("ProcessStep")) Then
                            stepList.Add(reader.Item("ProcessStep"))
                            If Not IsDBNull(reader.Item("ProcessID")) And Not IsDBNull(reader.Item("Description")) Then
                                If Not IsDBNull(reader.Item("Description")) Then
                                    If reader.Item("ProcessAddFG").ToString().Equals("ADDINVENTORY") Then
                                        stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " " + reader.Item("Description") + " (ADDS INVENTORY)")
                                    Else
                                        stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " " + reader.Item("Description"))
                                    End If
                                Else
                                    stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " " + reader.Item("Description"))
                                End If

                            ElseIf Not IsDBNull(reader.Item("ProcessID")) Then

                                If Not IsDBNull(reader.Item("ProcessAddFG")) Then
                                    If reader.Item("ProcessAddFG").ToString().Equals("ADDINVENTORY") Then
                                        stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " (ADDS INVENTORY)")
                                    Else
                                        stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID"))
                                    End If
                                Else
                                    stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID"))
                                End If
                            End If
                        End If
                    End While
                    reader.Close()
                    If stepDescriptions.Count > 1 Then
                        Dim lst As String = ""
                        ''adding the different steps to a singuar string to use in the input box
                        For i As Integer = 0 To stepDescriptions.Count - 1
                            lst += stepDescriptions(i) + Chr(10)
                        Next
                        Dim validEntry As Boolean = False
                        While Not validEntry
                            Dim selectFOXStep As New TimeSlipSelectFOXStep("Specify which step." + Chr(10) + Chr(10) + lst, "Which Step")
                            If selectFOXStep.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                                Return 0
                            End If
                            foxStep = selectFOXStep.getEnteredStep()
                            If String.IsNullOrEmpty(foxStep) Then
                                Return 0
                            End If
                            ''check to make sure the entered value is a number
                            If IsNumeric(foxStep) Then
                                ''check to see if 0 was entered and if so will exit
                                If Val(foxStep) = 0 Then
                                    Return 0
                                End If
                                ''check to make sure it is a valid step number
                                For i As Integer = 0 To stepList.Count - 1
                                    If Val(foxStep) = stepList(i) Then
                                        validEntry = True
                                        Exit For
                                    End If
                                Next
                            End If
                        End While
                        reader.Close()
                    Else
                        reader.Close()
                        Return stepList(0)
                    End If
                End If
                If Not reader.IsClosed Then
                    reader.Close()
                End If
            End If

            cmd = New SqlCommand("SELECT ProcessStep, ProcessID, Description, ProcessAddFG FROM FOXSched INNER JOIN MachineTable ON ProcessID = MachineID WHERE FOXNumber = @FOXNumber AND MachineClass = (SELECT TOP 1 MachineClass FROM MachineTable WHERE MachineID = @MachineID)", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
            cmd.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = machine
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    If Not IsDBNull(reader.Item("ProcessStep")) Then
                        stepList.Add(reader.Item("ProcessStep"))
                        If Not IsDBNull(reader.Item("ProcessID")) And Not IsDBNull(reader.Item("Description")) Then
                            If Not IsDBNull(reader.Item("ProcessAddFG")) Then
                                If reader.Item("ProcessAddFG").ToString().Equals("ADDINVENTORY") Then
                                    stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " " + reader.Item("Description") + " (ADDS INVENTORY)")
                                Else
                                    stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " " + reader.Item("Description"))
                                End If
                            Else
                                stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " " + reader.Item("Description"))
                            End If

                        ElseIf Not IsDBNull(reader.Item("ProcessID")) Then

                            If Not IsDBNull(reader.Item("Description")) Then
                                If reader.Item("Description").ToString().Equals("ADDINVENTORY") Then
                                    stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID") + " (ADDS INVENTORY)")
                                Else
                                    stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID"))
                                End If
                            Else
                                stepDescriptions.Add("Step #" + stepList(stepList.Count - 1).ToString() + " - " + reader.Item("ProcessID"))
                            End If
                        End If
                    End If
                End While
                reader.Close()
                If stepDescriptions.Count > 1 Then
                    Dim lst As String = ""
                    ''adding the different steps to a singuar string to use in the input box
                    For i As Integer = 0 To stepDescriptions.Count - 1
                        lst += stepDescriptions(i) + Chr(10)
                    Next
                    Dim validEntry As Boolean = False
                    While Not validEntry
                        Dim selectFOXStep As New TimeSlipSelectFOXStep("Specify which step." + Chr(10) + Chr(10) + lst, "Which Step")
                        If selectFOXStep.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                            Return 0
                        End If
                        foxStep = selectFOXStep.getEnteredStep()
                        If String.IsNullOrEmpty(foxStep) Then
                            Return 0
                        End If
                        ''check to make sure the entered value is a number
                        If IsNumeric(foxStep) Then
                            ''check to see if 0 was entered and if so will exit
                            If Val(foxStep) = 0 Then
                                Return 0
                            End If
                            ''check to make sure it is a valid step number
                            For i As Integer = 0 To stepList.Count - 1
                                If Val(foxStep) = stepList(i) Then
                                    validEntry = True
                                    Exit For
                                End If
                            Next
                        End If
                    End While
                Else
                    reader.Close()
                    Return stepList(0)
                End If
            Else
                reader.Close()
                ''if it cant find a step in the FOX to associate will default it to an unknown step
                Return 999
            End If
            End If
            reader.Close()
            Return Val(foxStep)
    End Function

    Private Function similarMachine() As Boolean
        cmd = New SqlCommand("SELECT MachineClass FROM MachineTable RIGHT OUTER JOIN FOXSched ON ProcessID = MachineID WHERE DivisionID = 'TWD' AND FOXNumber = @FOXNumber", con)
        cmd.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = cboFOXNumber.Text
        Dim cla As New List(Of String)
        Dim currClass As String = ""
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If IsDBNull(reader.Item("MachineClass")) = False Then
                    cla.Add(reader.Item("MachineClass"))
                End If
            End While
        End If
        reader.Close()

        cmd = New SqlCommand("SELECT MachineClass FROM MachineTable WHERE MachineID = @MachineID AND DivisionID = 'TWD'", con)
        cmd.Parameters.Add("@MachineID", SqlDbType.VarChar).Value = cboMachineNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()

        Try
            currClass = cmd.ExecuteScalar()
        Catch ex As System.Exception

        End Try

        Dim i As Integer = 0
        While i < cla.Count
            If cla(i).Equals(currClass) Then
                Return True
            End If
            i += 1
        End While
        Return False
    End Function

    Public Sub ClearTimeSlipLines()
        'Clear fields
        cboFOXNumber.SelectedIndex = -1
        cboMachineNumber.SelectedIndex = -1
        cboCarbon.SelectedIndex = -1
        cboDiameter.SelectedIndex = -1

        txtMachineHours.Clear()
        txtToolingHours.Clear()
        txtSetupHours.Clear()
        txtOtherHours.Clear()
        txtPiecesProduced.Clear()
        txtScrapWeight.Clear()
        txtWeightProduced.Clear()
        txtPartNumber.Clear()
        lblTotalLineHours.Text = ""
        cboFOXNumber.Focus()
    End Sub

    Private Sub txtPiecesProduced_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiecesProduced.TextChanged
        If txtPiecesProduced.Focused Then
            txtWeightProduced.Text = Math.Round(Val(txtPiecesProduced.Text) * Val(lblPieceWeightSingle.Text), 2)
        End If
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click, DeleteDataToolStripMenuItem.Click
        If canDelete() Then
            'Create command to delete data from text boxes
            cmd = New SqlCommand("DELETE FROM TimeSlipHeaderTable WHERE TimeSlipKey = (SELECT TimeSlipKey FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED')", con)
            cmd.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = dtpTimeSlipDate.Value
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ClearData()
            ClearVariables()
        End If
    End Sub

    Private Function canDelete() As Boolean
        If GetStatus().Equals("CLOSED") Then
            MessageBox.Show("You can't delete a closed time slip", "Unable to complete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If MessageBox.Show("Do you wish to delete this Posting?", "DELETE POSTING", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> System.Windows.Forms.DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub cboFOXNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOXNumber.SelectedIndexChanged
        If isloaded Then
            LoadFoxData()
            LoadPartData()
            LoadFOXRouting()
            CheckFromAnotherPartEnable()
        End If
    End Sub

    Private Sub ClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click, ClearDataToolStripMenuItem.Click
        ClearVariables()
        ClearData()
        ShowTimeSlipData()
    End Sub

    Private Sub PrintTimeSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintTimeSlip.Click, PrintDataToolStripMenuItem.Click
        If canPrint() Then
            cmd = New SqlCommand("SELECT * FROM TimeSlipCombinedData WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED'", con)
            cmd.Parameters.Add("@PostingDate", SqlDbType.Date).Value = dtpTimeSlipDate.Value.ToShortDateString()
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
            Dim tempDS As New DataSet
            Dim tempadap As New SqlDataAdapter(cmd)
            If con.State = ConnectionState.Closed Then con.Open()
            tempadap.Fill(tempDS, "TimeSlipCombinedData")
            con.Close()

            Using NewPrintTimeSlipPostings As New PrintTimeSlipPostings(tempDS)
                Dim Result = NewPrintTimeSlipPostings.ShowDialog()
            End Using
        End If
    End Sub

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboEmployeeID.Text) Then
            MessageBox.Show("You must enter an Employee Number", "Enter an Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboEmployeeID.Focus()
            Return False
        End If
        If dgvTimeSlipLines.RowCount = 0 Then
            MessageBox.Show("There is no data to print", "Enter timeslip data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

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

    Private Sub cboEmployeeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmployeeID.SelectedIndexChanged
        If isloaded Then
            LoadEmployeeName()
            LoadTimeSlipData()
            ShowTimeSlipData()
        End If
    End Sub

    Private Sub dtpTimeSlipDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTimeSlipDate.ValueChanged
        If isloaded And dtpTimeSlipDate.Focused Then
            needsSaved = True
            If Not String.IsNullOrEmpty(cboEmployeeID.Text) Then
                ShowTimeSlipData()
            End If
        End If
    End Sub

    Private Sub cboShiftNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShiftNumber.SelectedIndexChanged
        If isloaded And cboShiftNumber.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub cmdDeleteEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteEntry.Click
        If canDeleteLine() Then
            cmd = New SqlCommand("DECLARE @TimeSlipKey as int = (SELECT TimeSlipKey FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED'); DELETE TimeSlipLineItemTable WHERE TimeSlipKey = @TimeSlipKey AND LineKey = @LineKey;", con)
            ''Updates the line number of all lines that were above the deleted line
            cmd.CommandText += " UPDATE TimeSlipLineItemTable SET LineKey = (LineKey - 1) WHERE TimeSlipKey = @TimeSlipKey AND LineKey > @LineKey;"
            cmd.Parameters.Add("@PostingDate", SqlDbType.VarChar).Value = dtpTimeSlipDate.Value
            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
            cmd.Parameters.Add("@LineKey", SqlDbType.VarChar).Value = cboDeleteLine.Text
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowTimeSlipData()
            If dgvTimeSlipLines.Rows.Count = 0 Then
                cboDeleteLine.Text = ""
            End If
        End If
    End Sub

    Private Function canDeleteLine() As Boolean
        If GetStatus().Equals("POSTED") Then
            MessageBox.Show("You can't delete lines from a POSTED Timeslip.", "Unable to delete line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(cboDeleteLine.Text) Then
            MessageBox.Show("You must select a line number.", "Select a line number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteLine.Focus()
            Return False
        End If
        If cboDeleteLine.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid line number to delete.", "Enter a line number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteLine.SelectAll()
            cboDeleteLine.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function updateTimeSlipHeaderTable() As Boolean
        Try
            'Write Data to Time Slip Header Database Table
            cmd = New SqlCommand("UPDATE TimeSlipHeaderTable SET PostingDate = @PostingDate, EmployeeID = @EmployeeID, Shift = @Shift, DivisionID = @DivisionID, Status = @Status WHERE TimeSlipKey = (SELECT TimeSlipKey FROM TimeSlipHeaderTable WHERE PostingDate = @PostingDate AND EmployeeID = @EmployeeID AND Status <> 'POSTED')", con)

            With cmd.Parameters
                .Add("@PostingDate", SqlDbType.Date).Value = dtpTimeSlipDate.Text
                .Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
                .Add("@Shift", SqlDbType.Int).Value = Val(cboShiftNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            sendErrorToDataBase("TimeSlipForm - cmdSave_Click-- Error trying to update TimeSlipHeader info", "Employee ID #" + cboEmployeeID.Text, ex.ToString())
            Return False
        End Try

        needsSaved = False

        Return True
    End Function

    Private Sub txtWeightProduced_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWeightProduced.TextChanged
        If txtWeightProduced.Focused Then
            If Not lblPieceWeightSingle.Equals("0") And Not String.IsNullOrEmpty(lblPieceWeightSingle.Text) Then
                txtPiecesProduced.Text = Math.Round(Val(txtWeightProduced.Text) / Val(lblPieceWeightSingle.Text), 0, MidpointRounding.AwayFromZero)
            Else
                txtPiecesProduced.Text = "0"
            End If
        End If
    End Sub

    Private Sub ComboBox_Textbox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScrapWeight.KeyUp, txtWeightProduced.KeyUp, txtPiecesProduced.KeyUp, cboDiameter.KeyUp, cboCarbon.KeyUp, txtOtherHours.KeyUp, txtToolingHours.KeyUp, txtSetupHours.KeyUp, txtMachineHours.KeyUp, cboShiftNumber.KeyUp, cboEmployeeID.KeyUp, cboFOXNumber.KeyUp, cboMachineNumber.KeyUp
        If e.KeyCode = Keys.Enter And shouldMove Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            e.Handled = True
        Else
            shouldMove = True
        End If
    End Sub

    Private Sub cboEmployeeID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmployeeID.Leave
        If cboEmployeeID.SelectedIndex = -1 And isloaded Then
            ''will add leading zero's until it hits 4
            If Not String.IsNullOrEmpty(cboEmployeeID.Text) Then
                If cboEmployeeID.Text.Length < 4 Then
                    Dim temp As String = cboEmployeeID.Text
                    While temp.Length < 4
                        temp = "0" + temp
                    End While
                    cboEmployeeID.Text = temp
                    If cboEmployeeID.SelectedIndex = -1 Then
                        lblEmployeeName.Text = ""
                        ShowTimeSlipData()
                    End If
                End If
            Else
                isloaded = False
                ClearData()
                cboShiftNumber.Focus()
                isloaded = True
            End If
        End If
    End Sub

    Private Sub cboMachineNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMachineNumber.Leave
        If isloaded Then
            If IsNumeric(cboMachineNumber.Text) And cboMachineNumber.Text.Length < 3 Then
                Dim temp As String = cboMachineNumber.Text
                While temp.Length < 3
                    temp = "0" + temp
                End While
                cboMachineNumber.Text = temp
                CheckFromAnotherPartEnable()
            End If
        End If
    End Sub

    Private Sub lblPieceWeightSingle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPieceWeightSingle.TextChanged
        If Not String.IsNullOrEmpty(txtPiecesProduced.Text) And Not String.IsNullOrEmpty(lblPieceWeightSingle.Text) Then
            txtWeightProduced.Text = Math.Round(Val(txtPiecesProduced.Text) * Val(lblPieceWeightSingle.Text), 2)
        End If
    End Sub

    Private Sub Hours_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMachineHours.KeyPress, txtSetupHours.KeyPress, txtToolingHours.KeyPress, txtOtherHours.KeyPress
        If Not IsNumeric(e.KeyChar) And Not controlKey Then
            e.KeyChar = Nothing
        Else
            controlKey = False
        End If
    End Sub

    Private Sub Hours_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMachineHours.KeyDown, txtSetupHours.KeyDown, txtToolingHours.KeyDown, txtOtherHours.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Back Then
            controlKey = True
        ElseIf (e.KeyCode = Keys.Decimal Or e.KeyCode = Keys.OemPeriod) Then
            If Not CType(sender, System.Windows.Forms.TextBox).Text.Contains(".") Then
                controlKey = True
            End If
        End If
    End Sub

    Private Sub TimeSlipForm_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If NewProductionQuantityEntry IsNot Nothing Then
            If NewProductionQuantityEntry.Visible Then
                NewProductionQuantityEntry.BringToFront()
            End If
        End If
    End Sub

    Private Sub dgvFOXRouting_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvFOXRouting.VisibleChanged
        ColorRoutingLines()
    End Sub

    Private Sub cboMachineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMachineNumber.SelectedIndexChanged
        If isloaded Then
            CheckFromAnotherPartEnable()
        End If
    End Sub

    Private Sub CheckFromAnotherPartEnable()
        If cboMachineNumber.SelectedIndex <> -1 AndAlso dgvFOXRouting.Rows.Count > 0 Then
            Dim dr() As Data.DataRow = CType(dgvFOXRouting.DataSource, Data.DataTable).Select("ProcessAddFG = 'ADDINVENTORY'")
            If dr.Count > 0 Then
                If dr(0).Item("ProcessID").Equals(cboMachineNumber.Text) AndAlso (cboMachineNumber.Text.Equals("ZIN") Or cboMachineNumber.Text.Equals("NKL") Or cboMachineNumber.Text.Equals("702") Or cboMachineNumber.Text.Equals("703") Or cboMachineNumber.Text.Equals("704")) Then
                    chkFromAnotherPart.Enabled = True
                Else
                    chkFromAnotherPart.Enabled = False
                End If
            Else
                chkFromAnotherPart.Enabled = False
            End If
        Else
            chkFromAnotherPart.Enabled = False
        End If
    End Sub
End Class