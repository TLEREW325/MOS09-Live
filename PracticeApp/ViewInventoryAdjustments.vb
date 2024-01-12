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
Public Class ViewInventoryAdjustments
    Inherits System.Windows.Forms.Form

    Dim AdjustmentFilter, TextFilter, BatchFilter, PartFilter, AccountFilter, StatusFilter, DateFilter, ReasonFilter, ZeroCostFilter As String
    Dim BatchNumber As Integer = 0
    Dim strBatchNumber As String = ""
    Dim BeginDate, EndDate As Date
    Dim AdjustmentNumber As Integer = 0
    Dim strAdjustmentNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewInventoryAdjustments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        LoadCurrentDivision()

        usefulFunctions.LoadSecurity(Me)
    End Sub

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
            Case "TFJ"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFJ'", con)
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

    Public Sub ClearDataInDatagrid()
        dgvInventoryAdjustments.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + cboPartNumber.Text + "'"
        Else
            PartFilter = ""
        End If
        If cboInventoryAccount.Text <> "" Then
            AccountFilter = " AND InventoryAccount = '" + cboInventoryAccount.Text + "'"
        Else
            AccountFilter = ""
        End If
        If cboBatchNumber.Text <> "" Then
            BatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(BatchNumber)
            BatchFilter = " AND BatchNumber = '" + strBatchNumber + "'"
        Else
            BatchFilter = ""
        End If
        If cboAdjustmentNumber.Text <> "" Then
            AdjustmentNumber = Val(cboAdjustmentNumber.Text)
            strAdjustmentNumber = CStr(AdjustmentNumber)
            AdjustmentFilter = " AND AdjustmentNumber = '" + strAdjustmentNumber + "'"
        Else
            AdjustmentFilter = ""
        End If
        If cboStatus.Text <> "" Then
            StatusFilter = " AND Status = '" + cboStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If txtReason.Text <> "" Then
            ReasonFilter = " AND Reason LIKE '%" + txtReason.Text + "%'"
        Else
            ReasonFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + txtTextFilter.Text + "%' OR Reason LIKE '%" + txtTextFilter.Text + "%' OR Description LIKE '%" + txtTextFilter.Text + "%' OR LineComment LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If chkZeroCost.Checked = True Then
            ZeroCostFilter = " AND Total = '0'"
        Else
            ZeroCostFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND AdjustmentDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID" + PartFilter + BatchFilter + AdjustmentFilter + TextFilter + AccountFilter + ReasonFilter + StatusFilter + ZeroCostFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryAdjustmentTable")
        dgvInventoryAdjustments.DataSource = ds.Tables("InventoryAdjustmentTable")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID <> @PurchProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "NON-INVENTORY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBatchNumber()
        cmd = New SqlCommand("SELECT DISTINCT BatchNumber FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "InventoryAdjustmentTable")
        cboBatchNumber.DataSource = ds2.Tables("InventoryAdjustmentTable")
        con.Close()
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccount()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLAccounts")
        cboInventoryAccount.DataSource = ds3.Tables("GLAccounts")
        cboAccountDescription.DataSource = ds3.Tables("GLAccounts")
        con.Close()
        cboInventoryAccount.SelectedIndex = -1
        cboAccountDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID <> @PurchProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "NON-INVENTORY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboPartDescription.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadAdjustmentNumber()
        cmd = New SqlCommand("SELECT AdjustmentNumber FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "InventoryAdjustmentTable")
        cboAdjustmentNumber.DataSource = ds5.Tables("InventoryAdjustmentTable")
        con.Close()
        cboAdjustmentNumber.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPartNumber()
        LoadPartDescription()
        LoadBatchNumber()
        LoadAdjustmentNumber()
        LoadGLAccount()
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

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

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadTotals()
        Dim TotalNumberOfAdjustments As Integer = 0
        Dim TotalAmountOfAdjustments As Double = 0
        Dim TotalQuantityOfAdjustments As Double = 0

        Dim TotalCountStatement As String = "SELECT COUNT(AdjustmentNumber) FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID" + PartFilter + BatchFilter + AdjustmentFilter + TextFilter + AccountFilter + ReasonFilter + StatusFilter + ZeroCostFilter + DateFilter
        Dim TotalCountCommand As New SqlCommand(TotalCountStatement, con)
        TotalCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalCountCommand.Parameters.Add("@@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalCountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalAmountStatement As String = "SELECT SUM(Total) FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID" + PartFilter + BatchFilter + AdjustmentFilter + TextFilter + AccountFilter + ReasonFilter + StatusFilter + ZeroCostFilter + DateFilter
        Dim TotalAmountCommand As New SqlCommand(TotalAmountStatement, con)
        TotalAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalAmountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalAmountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        Dim TotalQuantityStatement As String = "SELECT SUM(Quantity) FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID" + PartFilter + BatchFilter + AdjustmentFilter + TextFilter + AccountFilter + ReasonFilter + StatusFilter + ZeroCostFilter + DateFilter
        Dim TotalQuantityCommand As New SqlCommand(TotalQuantityStatement, con)
        TotalQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        TotalQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalNumberOfAdjustments = CInt(TotalCountCommand.ExecuteScalar)
        Catch ex As Exception
            TotalNumberOfAdjustments = 0
        End Try
        Try
            TotalAmountOfAdjustments = CDbl(TotalAmountCommand.ExecuteScalar)
        Catch ex As Exception
            TotalAmountOfAdjustments = 0
        End Try
        Try
            TotalQuantityOfAdjustments = CDbl(TotalQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            TotalQuantityOfAdjustments = 0
        End Try
        con.Close()

        txtNumberOfAdjustments.Text = FormatNumber(TotalNumberOfAdjustments, 0)
        txtTotalAdjustments.Text = FormatCurrency(TotalAmountOfAdjustments, 2)
        txtTotalQuantity.Text = FormatNumber(TotalQuantityOfAdjustments, 1)
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Public Sub ClearData()
        cboPartNumber.Text = ""
        cboPartDescription.Text = ""
        cboBatchNumber.Text = ""
        cboAccountDescription.Text = ""
        cboInventoryAccount.Text = ""
        cboStatus.Text = ""

        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboBatchNumber.SelectedIndex = -1
        cboAccountDescription.SelectedIndex = -1
        cboInventoryAccount.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        cboAdjustmentNumber.SelectedIndex = -1

        txtReason.Clear()
        txtTextFilter.Clear()
        txtTotalAdjustments.Clear()
        txtNumberOfAdjustments.Clear()
        txtTotalQuantity.Clear()

        chkDateRange.Checked = False
        chkZeroCost.Checked = False

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        BatchFilter = ""
        PartFilter = ""
        AccountFilter = ""
        StatusFilter = ""
        DateFilter = ""
        ReasonFilter = ""
        ZeroCostFilter = ""
        BatchNumber = 0
        strBatchNumber = ""
        strAdjustmentNumber = ""
        AdjustmentNumber = 0
        TextFilter = ""
        AdjustmentFilter = ""
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilters()
        LoadTotals()
    End Sub

    Private Sub dgvInventoryAdjustments_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryAdjustments.CellDoubleClick
        Dim RowBatchNumber As Integer

        Dim RowIndex As Integer = Me.dgvInventoryAdjustments.CurrentCell.RowIndex

        RowBatchNumber = Me.dgvInventoryAdjustments.Rows(RowIndex).Cells("BatchNumberColumn").Value

        GlobalDivisionCode = cboDivisionID.Text
        GlobalInventoryAdjustmentBatchNumber = RowBatchNumber

        Using NewPrintInventoryAdjustmentBatch As New PrintInventoryAdjustmentBatch
            Dim result = NewPrintInventoryAdjustmentBatch.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintInventoryAdjustmentsFiltered As New PrintInventoryAdjustmentsFiltered
            Dim result = NewPrintInventoryAdjustmentsFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintInventoryAdjustmentsFiltered As New PrintInventoryAdjustmentsFiltered
            Dim result = NewPrintInventoryAdjustmentsFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdOpenAdjustmentForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenAdjustmentForm.Click
        Dim NewInventoryAdjustmentForm As New InventoryAdjustmentForm
        NewInventoryAdjustmentForm.Show()
    End Sub

    Private Sub dgvInventoryAdjustments_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryAdjustments.CellValueChanged
        If dgvInventoryAdjustments.RowCount <> 0 Then

            Dim RowAdjustmentNumber As Integer = 0
            Dim RowComment As String = ""

            Dim RowIndex As Integer = Me.dgvInventoryAdjustments.CurrentCell.RowIndex

            Try
                RowAdjustmentNumber = Me.dgvInventoryAdjustments.Rows(RowIndex).Cells("AdjustmentNumberColumn").Value
            Catch ex As Exception
                RowAdjustmentNumber = 0
            End Try
            Try
                RowComment = Me.dgvInventoryAdjustments.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                RowComment = ""
            End Try

            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE InventoryAdjustmentTable SET LineComment = @LineComment WHERE AdjustmentNumber = @AdjustmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@AdjustmentNumber", SqlDbType.VarChar).Value = RowAdjustmentNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@LineComment", SqlDbType.VarChar).Value = RowComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        End If
    End Sub
End Class