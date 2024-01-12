Imports System.Data.SqlClient

Public Class ViewFOXStepCosting
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Const LaborCost As Double = 20D

    Public Sub New()
        InitializeComponent()

        LoadFOXNumbers()
        Me.AcceptButton = cmdView
    End Sub

    Public Sub New(ByVal fox As String)
        InitializeComponent()

        LoadFOXNumbers()
        cboFOXNumber.Text = fox
        Me.AcceptButton = cmdView
    End Sub

    Private Sub LoadFOXNumbers()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboFOXNumber.Items.Add(reader.Item("FOXNumber"))
                End If
            End While
        End If
        reader.Close()
        con.Close()
        If cboFOXNumber.SelectedIndex <> -1 Then
            cboFOXNumber.SelectedIndex = -1
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        If canView() Then
            cmd = New SqlCommand("SELECT FOXStep, ProcessID, ProcessAddFG, PieceSum, TotalHours, MachineTable.MachineCostPerHour, 20 as LaborCostPerHour, ROUND(MachineTable.MachineCostPerHour * TotalHours,2) as TotalMachineCost, ROUND(TotalHours * 20, 2) as TotalLaborCost, ROUND((MachineTable.MachineCostPerHour * TotalHours) + (TotalHours * 20), 2) as TotalCost FROM (SELECT FOXNumber, FOXStep, ProcessID, isnull(ProcessAddFG, 'NO') as ProcessAddFG, SUM(TotalPieces) as PieceSum, SUM(TotalHours) as TotalHours, case when SUM(TotalHours) = 0 then 0 else SUM(TotalPieces) / SUM(TotalHours) END as PiecesPerHour FROM (SELECT TimeSlipLineItemTable.FOXNumber, ProcessAddFG, FOXStep, isnull(ProcessID, MachineNumber) as ProcessID, SUM(PiecesProduced) as TotalPieces, SUM(TotalHours) as TotalHours FROM TimeSlipLineItemTable LEFT OUTER JOIN FOXSched ON TimeSlipLineItemTable.FOXNumber = FoxSched.FOXNumber and TimeSlipLineItemTable.FOXStep = FoxSched.ProcessStep  WHERE TimeslipLineItemTable.FOXNumber = @FOXNumber AND (FOXStep < 100 OR FOXStep > 900) AND FOXStep <> 0 and TimeSlipKey IN (SELECT TimeslipKey FROM TimeSlipHeaderTable WHERE PostingDate BETWEEN @BeginDate AND @EndDate) GROUP BY TimeSlipLineItemTable.FOXNumber, FOXStep, ProcessID, MachineNumber, ProcessAddFG UNION SELECT FOXNumber, ProcessAddFG, ProcessStep, ProcessID, 0, 0 FROM FoxSched WHERE FOXNumber = @FOXNumber GROUP BY FOXNumber, ProcessStep, ProcessID, ProcessAddFG) as TimeSlipSUM GROUP BY FOXNumber, FOXStep, ProcessID, ProcessAddFG) as ProdData LEFT OUTER JOIN MachineTable ON ProdData.ProcessID = MachineTable.MachineID ORDER BY FOXStep, ProcessID, ProcessAddFG", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpStartDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value

            Dim ProData As New DataSet()
            Dim adap As New SqlDataAdapter(cmd)
            If con.State = ConnectionState.Closed Then con.Open()
            adap.Fill(ProData, "Production")
            cmd.CommandText = "DECLARE @RMID as varchar(50) = (SELECT TOP 1 RMID FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber AND FOXStep = 1 AND TimeSlipKey = (SELECT MAX(TimeSlipKey) FROM TimeSlipHeaderTable WHERE TimeSlipKey in (SELECT TimeSlipHeaderTable.TimeSlipKey FROM TimeSlipHeaderTable RIGHT OUTER JOIN TimeSlipLineItemTable ON TimeSlipHeaderTable.TimeSlipKey = TimeSlipLineItemTable.TimeSlipKey WHERE PostingDate BETWEEN @BeginDate AND @EndDate AND FOXNumber = @FOXNumber AND FOXStep = 1))); SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND SteelCostingTable.TransactionNumber = (SELECT MAX(TransactionNumber) FROM SteelTransactionTable WHERE RMID = @RMID) ORDER BY CostingDate DESC"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            Dim SteelCostPerPound As Double = 0D
            If IsDBNull(obj) Then
                cmd.CommandText = "DECLARE @RMID as varchar(50) = (SELECT TOP 1 RMID FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber AND FOXStep = 1 AND TimeSlipKey = (SELECT MAX(TimeSlipKey) FROM TimeSlipHeaderTable WHERE TimeSlipKey in (SELECT TimeSlipHeaderTable.TimeSlipKey FROM TimeSlipHeaderTable RIGHT OUTER JOIN TimeSlipLineItemTable ON TimeSlipHeaderTable.TimeSlipKey = TimeSlipLineItemTable.TimeSlipKey WHERE PostingDate BETWEEN @BeginDate AND @EndDate AND FOXNumber = @FOXNumber AND FOXStep = 1))); SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT isnull(SUM(UsageWeight), 1) FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED' AND UsageDate < @EndDate) BETWEEN LowerLimit AND UpperLimit + 1 ORDER BY CostingDate DESC"
                If con.State = ConnectionState.Closed Then con.Open()
                obj = cmd.ExecuteScalar()
                If Not IsDBNull(obj) Then
                    SteelCostPerPound = Convert.ToDouble(obj)
                End If
            ElseIf Convert.ToDouble(obj) = 0 Then
                cmd.CommandText = "DECLARE @RMID as varchar(50) = (SELECT TOP 1 RMID FROM TimeSlipLineItemTable WHERE FOXNumber = @FOXNumber AND FOXStep = 1 AND TimeSlipKey = (SELECT MAX(TimeSlipKey) FROM TimeSlipHeaderTable WHERE TimeSlipKey in (SELECT TimeSlipHeaderTable.TimeSlipKey FROM TimeSlipHeaderTable RIGHT OUTER JOIN TimeSlipLineItemTable ON TimeSlipHeaderTable.TimeSlipKey = TimeSlipLineItemTable.TimeSlipKey WHERE PostingDate BETWEEN @BeginDate AND @EndDate AND FOXNumber = @FOXNumber AND FOXStep = 1))); SELECT TOP 1 SteelCostPerPound FROM SteelCostingTable WHERE RMID = @RMID AND (SELECT isnull(SUM(UsageWeight), 1) FROM SteelUsageTable WHERE RMID = @RMID AND Status = 'POSTED' AND UsageDate < @EndDate) BETWEEN LowerLimit AND UpperLimit + 1 ORDER BY CostingDate DESC"
                If con.State = ConnectionState.Closed Then con.Open()
                obj = cmd.ExecuteScalar()
                If Not IsDBNull(obj) Then
                    SteelCostPerPound = Convert.ToDouble(obj)
                End If
            Else
                SteelCostPerPound = Convert.ToDouble(obj)
            End If
            cmd = New SqlCommand("SELECT isnull(FinishedWeight, 0) / 1000 FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(cboFOXNumber.Text)

            Dim pieceWeight As Double = 0D

            If con.State = ConnectionState.Closed Then con.Open()
            obj = cmd.ExecuteScalar()
            If Not IsDBNull(obj) Then
                pieceWeight = Convert.ToDouble(obj)
            End If
            ProData.Tables("Production").Columns.Add("PiecesPerHour")
            cmd = New SqlCommand("SELECT CASE WHEN SUM(TotalHours) = 0 THEN 0 ELSE ROUND(SUM(PiecesProduced) / SUM(TotalHours), 4) END FROM TimeSlipLineItemTable WHERE MachineNumber = @MachineNumber", con)
            cmd.Parameters.Add("@MachineNumber", SqlDbType.VarChar)

            For i As Integer = 0 To ProData.Tables("Production").Rows.Count - 1
                cmd.Parameters("@MachineNumber").Value = ProData.Tables("Production").Rows(i).Item("ProcessID")

                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj1 As Object = cmd.ExecuteScalar()
                If IsDBNull(obj1) Then
                    ProData.Tables("Production").Rows(i).Item("PiecesPerHour") = 0
                Else
                    ProData.Tables("Production").Rows(i).Item("PiecesPerHour") = Convert.ToDouble(obj1)
                End If
            Next
            con.Close()

            dgvFOXProcessCosting.DataSource = ProData.Tables("Production")
            dgvFOXProcessCosting.Columns("FOXStep").HeaderText = "Step"
            dgvFOXProcessCosting.Columns("ProcessID").HeaderText = "Machine"
            dgvFOXProcessCosting.Columns("ProcessAddFG").HeaderText = "Process Add FG"
            dgvFOXProcessCosting.Columns("PieceSum").HeaderText = "Total Pieces"
            dgvFOXProcessCosting.Columns("TotalHours").HeaderText = "Total Hours"
            dgvFOXProcessCosting.Columns("MachineCostPerHour").HeaderText = "Machine Cost Per Hour"
            dgvFOXProcessCosting.Columns("MachineCostPerHour").DefaultCellStyle.Format = "C2"
            dgvFOXProcessCosting.Columns("LaborCostPerHour").HeaderText = "Labor Cost Per Hour"
            dgvFOXProcessCosting.Columns("LaborCostPerHour").DefaultCellStyle.Format = "C2"
            dgvFOXProcessCosting.Columns("TotalMachineCost").HeaderText = "Total Machine Cost"
            dgvFOXProcessCosting.Columns("TotalMachineCost").DefaultCellStyle.Format = "C2"
            dgvFOXProcessCosting.Columns("TotalLaborCost").HeaderText = "Total Labor Cost"
            dgvFOXProcessCosting.Columns("TotalLaborCost").DefaultCellStyle.Format = "C2"
            dgvFOXProcessCosting.Columns("TotalCost").HeaderText = "Total Cost"
            dgvFOXProcessCosting.Columns("TotalCost").DefaultCellStyle.Format = "C2"
            dgvFOXProcessCosting.Columns("PiecesPerHour").HeaderText = "Average Pieces Per Hour"

            lblPieceWeight.Text = pieceWeight.ToString()
            lblSteelCostPerPound.Text = FormatCurrency(SteelCostPerPound)
        End If
    End Sub

    Private Function canView() As Boolean
        If String.IsNullOrEmpty(cboFOXNumber.Text) Then
            MessageBox.Show("You must enter a FOX Number", "Enter a FOX Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFOXNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboFOXNumber.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboFOXNumber.Text) Then
            cboFOXNumber.Text = ""
        End If
        dtpStartDate.Value = Now.Date
        dtpEndDate.Value = Now.Date
        lblSteelCostPerPound.Text = ""
        lblPieceWeight.Text = ""
        dgvFOXProcessCosting.DataSource = Nothing
        cboFOXNumber.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ViewFOXStepCosting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class