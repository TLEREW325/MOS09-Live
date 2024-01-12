Imports System
Imports System.Data.SqlClient

Public Class ViewQCNonConformance
    Inherits System.Windows.Forms.Form

    Dim PartFilter, LotFilter, FOXFilter, TrufitFilter, TruweldFilter, StatusFilter, DateFilter As String
    Dim BeginDate, EndDate As Date
    Dim FOXNumber As Integer
    Dim strFOXNumber As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter2, myAdapter3 As New SqlDataAdapter
    Dim ds, ds2, ds3 As DataSet
    Dim isloaded As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.AcceptButton = cmdView
        LoadPartNumber()
        LoadFOXNumber()
        LoadLotNumber()
        If con.State = ConnectionState.Open Then con.Close()
        isloaded = True
    End Sub

    Public Sub ShowDataByFilters()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboStatus.Text <> "" Then
            StatusFilter = " AND Status = '" + cboStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If cboFOXNumber.Text <> "" Then
            FOXNumber = Val(cboFOXNumber.Text)
            strFOXNumber = CStr(FOXNumber)
            FOXFilter = " AND FOXNumber = '" + strFOXNumber + "'"
        Else
            FOXFilter = ""
        End If
        If cboLotNumber.Text <> "" Then
            LotFilter = " AND QCHoldAdjustmentLotNumber.LotNumber = '" + cboLotNumber.Text + "'"
        Else
            LotFilter = ""
        End If
        If chkTrufit.Checked = True Then
            TrufitFilter = " AND DivisionID = 'TFP'"
        Else
            TrufitFilter = ""
        End If
        If chkTruweld.Checked = True Then
            TruweldFilter = " AND DivisionID = 'TWD'"
        Else
            TruweldFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND QCDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT QCHoldAdjustment.QCTransactionNumber, QCDate, QCAgent, FOXNumber, PartNumber, PartDescription, LongDescription, Status, QuantityOnHold, ReworkHours, CorrectiveAction, NonConFormanceReason, ReworkInstructions, Comment, ApprovedBy, ApprovalDate, MachineNumber, MachineOperator, QCHoldAdjustmentLotNumber.LotNumber FROM QCHoldAdjustment LEFT OUTER JOIN QCHoldAdjustmentLotNumber ON QCHoldAdjustment.QCTransactionNumber = QCHoldAdjustmentLotNumber.QCTransactionNumber WHERE DivisionID <> 'TST'" + PartFilter + StatusFilter + LotFilter + FOXFilter + TrufitFilter + TruweldFilter + DateFilter + " ORDER BY QCHoldAdjustment.QCTransactionNumber, QCHoldAdjustmentLotNumber.LotNumber", con)
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "QCHoldAdjustment")
        con.Close()

        dgvQCHoldAdjustment.DataSource = ds.Tables("QCHoldAdjustment")
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE (DivisionID = 'TWD' OR DivisionID = 'TFP') AND ItemClass <> 'DEACTIVATED-PART' ORDER BY ItemID", con)
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "ItemList")
        con.Close()

        cboPartNumber.DataSource = ds2.Tables("ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadFOXNumber()
        cmd = New SqlCommand("SELECT FOXNumber FROM FOXTable ORDER BY FOXNumber", con)

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
    End Sub

    Public Sub LoadLotNumber()
        cmd = New SqlCommand("SELECT LotNumber FROM LotNumber WHERE Status = 'CLOSED'", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                If Not reader.IsDBNull(0) Then
                    cboLotNumber.Items.Add(reader.Item("LotNumber"))
                End If
            End While
        End If
        reader.Close()
    End Sub

    Public Sub ClearData()
        cboFOXNumber.SelectedIndex = -1
        cboLotNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboStatus.SelectedIndex = -1

        chkDateRange.Checked = False
        chkTrufit.Checked = False
        chkTruweld.Checked = False

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        PartFilter = ""
        LotFilter = ""
        FOXFilter = ""
        TrufitFilter = ""
        TruweldFilter = ""
        StatusFilter = ""
        DateFilter = ""
        FOXNumber = 0
        strFOXNumber = ""
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND (DivisionID = 'TWD' OR DivisionIS = 'TFP')"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalQCTransactionNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalQCTransactionNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If isloaded And cboPartNumber.Focused() Then
            LoadDescriptionByPart()
        End If
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        If isloaded And cboPartDescription.Focused() Then
            LoadPartByDescription()
        End If
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        dgvQCHoldAdjustment.DataSource = Nothing
    End Sub

    Private Sub chkTruweld_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTruweld.CheckedChanged
        If chkTruweld.Checked = True Then
            chkTrufit.Checked = False
        End If
    End Sub

    Private Sub chkTrufit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTrufit.CheckedChanged
        If chkTrufit.Checked = True Then
            chkTruweld.Checked = False
        End If
    End Sub

    Private Sub dgvQCHoldAdjustment_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQCHoldAdjustment.CellDoubleClick
        If e.RowIndex > 0 AndAlso e.RowIndex < dgvQCHoldAdjustment.Rows.Count Then
            Using NewPrintQCNonconReport As New PrintQCNonconReport(dgvQCHoldAdjustment.Rows(e.RowIndex).Cells("QCTransactionNumberColumn").Value)
                Dim Result = NewPrintQCNonconReport.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvQCHoldAdjustment_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQCHoldAdjustment.CellValueChanged
        If CanUpdate(e.RowIndex) Then
            Dim RowLotNumber, RowFOXNumber, RowQCAgent, RowNonConformanceReason, RowReworkInstructions, RowComment, RowApprovedBy, RowApprovalDate As String
            Dim RowTransactionNumber As Integer

            Dim RowIndex As Integer = Me.dgvQCHoldAdjustment.CurrentCell.RowIndex

            Try
                RowTransactionNumber = Me.dgvQCHoldAdjustment.Rows(RowIndex).Cells("QCTransactionNumberColumn").Value
            Catch ex As Exception
                RowTransactionNumber = 0
            End Try
            Try
                RowComment = Me.dgvQCHoldAdjustment.Rows(RowIndex).Cells("CommentColumn").Value
            Catch ex As Exception
                RowComment = ""
            End Try
            Try
                RowQCAgent = Me.dgvQCHoldAdjustment.Rows(RowIndex).Cells("QCAgentColumn").Value
            Catch ex As Exception
                RowQCAgent = ""
            End Try
            Try
                RowLotNumber = Me.dgvQCHoldAdjustment.Rows(RowIndex).Cells("LotNumberColumn").Value
            Catch ex As Exception
                RowLotNumber = ""
            End Try
            Try
                RowFOXNumber = Me.dgvQCHoldAdjustment.Rows(RowIndex).Cells("FOXNumberColumn").Value
            Catch ex As Exception
                RowFOXNumber = ""
            End Try
            Try
                RowNonConformanceReason = Me.dgvQCHoldAdjustment.Rows(RowIndex).Cells("NonConformanceReasonColumn").Value
            Catch ex As Exception
                RowNonConformanceReason = ""
            End Try
            Try
                RowReworkInstructions = Me.dgvQCHoldAdjustment.Rows(RowIndex).Cells("ReworkInstructionsColumn").Value
            Catch ex As Exception
                RowReworkInstructions = ""
            End Try
            Try
                RowApprovedBy = Me.dgvQCHoldAdjustment.Rows(RowIndex).Cells("ApprovedByColumn").Value
            Catch ex As Exception
                RowApprovedBy = 0
            End Try
            Try
                RowApprovalDate = Me.dgvQCHoldAdjustment.Rows(RowIndex).Cells("ApprovalDateColumn").Value
            Catch ex As Exception
                RowApprovalDate = ""
            End Try

            If RowTransactionNumber <> 0 Then
                'Update database table
                cmd = New SqlCommand("UPDATE QCHoldAdjustment SET QCAgent = @QCAgent, NonConformanceReason = @NonConformanceReason, ReworkInstructions = @ReworkInstructions, Comment = @Comment, ApprovedBy = @ApprovedBy, ApprovalDate = @ApprovalDate WHERE QCTransactionNumber = @QCTransactionNumber", con)

                With cmd.Parameters
                    .Add("@QCTransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                    .Add("@QCAgent", SqlDbType.VarChar).Value = RowQCAgent
                    .Add("@NonConformanceReason", SqlDbType.VarChar).Value = RowNonConformanceReason
                    .Add("@ReworkInstructions", SqlDbType.VarChar).Value = RowReworkInstructions
                    .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                    .Add("@ApprovedBy", SqlDbType.VarChar).Value = RowApprovedBy
                    .Add("@ApprovalDate", SqlDbType.VarChar).Value = RowApprovalDate
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Else
            If isloaded Then
                cmd = New SqlCommand("SELECT " + dgvQCHoldAdjustment.Columns(e.ColumnIndex).DataPropertyName + " FROM QCHoldAdjustment WHERE QCTransactionNumber = @QCTransactionNumber", con)
                cmd.Parameters.Add("@QCTransactionNumber", SqlDbType.Int).Value = dgvQCHoldAdjustment.Rows(e.RowIndex).Cells("QCTransactionNumberColumn").Value

                If con.State = ConnectionState.Closed Then con.Open()
                Dim obj As Object = cmd.ExecuteScalar()
                con.Close()
                If Not IsDBNull(obj) And obj IsNot Nothing Then
                    isloaded = False
                    dgvQCHoldAdjustment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = obj
                    isloaded = True
                End If
            End If
        End If
    End Sub

    Private Function CanUpdate(ByVal rowIndex As Integer) As Boolean
        If Not isloaded Then
            Return False
        End If
        If rowIndex < 0 Or rowIndex >= dgvQCHoldAdjustment.Rows.Count Then
            Return False
        End If
        If dgvQCHoldAdjustment.Rows(rowIndex).Cells("StatusColumn").Value.ToString.Equals("CLOSED") Then
            MessageBox.Show("You are can't change a closed QC hold", "Unable to update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If dgvQCHoldAdjustment.Rows(rowIndex).Cells("QCTransactionNumberColumn").Value = 0 Then
            MessageBox.Show("PNC Number doesn't exist or is 0. Unable ot update", "Unable to update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Using NewPrintQCHoldListing As New PrintQCHoldListing(ds.Copy())
            Dim Result = NewPrintQCHoldListing.ShowDialog()
        End Using
    End Sub

    Private Sub PrintQCHoldListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintQCHoldListingToolStripMenuItem.Click
        Using NewPrintQCHoldListing As New PrintQCHoldListing(ds.Copy())
            Dim Result = NewPrintQCHoldListing.ShowDialog()
        End Using
    End Sub

    Private Sub cmdOpenQCHold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenQCHold.Click
        If Me.dgvQCHoldAdjustment.RowCount <> 0 AndAlso dgvQCHoldAdjustment.CurrentCell IsNot Nothing Then
            Dim NewQCInventoryAdjustment As New QCNonConformance(dgvQCHoldAdjustment.Rows(dgvQCHoldAdjustment.CurrentCell.RowIndex).Cells("QCTransactionNumberColumn").Value)
            NewQCInventoryAdjustment.Show()
        Else
            Dim NewQCInventoryAdjustment As New QCNonConformance
            NewQCInventoryAdjustment.Show()
        End If
    End Sub

    Private Sub ViewQCNonConformance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class