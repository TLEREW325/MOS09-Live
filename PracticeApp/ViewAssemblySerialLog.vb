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
Public Class ViewAssemblySerialLog
    Inherits System.Windows.Forms.Form

    Dim WarehouseName, WarehouseID, LongDescription, TextFilter, DivisionFilter, WarehouseFilter, CustomerFilter, DateFilter, SerialFilter, PartFilter, StatusFilter As String
    Dim BeginDate, EndDate As Date

    'Configure Data Connection and declare variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As New DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewAssemblySerialLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCurrentDivision()

        'Set default for division and enable beginning inventory edits
        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
            cmdAddSerialNumber.Enabled = True
            cmdDeactivateSN.Enabled = True
            cmdDeleteSerialNumber.Enabled = True
            cmdOpenOrClose.Enabled = True
            cmdUpdateSerialNumber.Enabled = True
        ElseIf EmployeeCompanyCode = "TWE" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
            Me.dgvSerialLog.Columns("TotalCostColumn").Visible = True
            Me.dgvSerialLog.Columns("ShipmentPriceColumn").Visible = True
            cmdAddSerialNumber.Enabled = True
            cmdDeactivateSN.Enabled = True
            cmdDeleteSerialNumber.Enabled = True
            cmdOpenOrClose.Enabled = True
            cmdUpdateSerialNumber.Enabled = True
        ElseIf EmployeeCompanyCode = "TWD" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
            Me.dgvSerialLog.Columns("TotalCostColumn").Visible = True
            Me.dgvSerialLog.Columns("ShipmentPriceColumn").Visible = True
            cmdAddSerialNumber.Enabled = True
            cmdDeactivateSN.Enabled = True
            cmdDeleteSerialNumber.Enabled = True
            cmdOpenOrClose.Enabled = True
            cmdUpdateSerialNumber.Enabled = True
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
            Me.dgvSerialLog.Columns("TotalCostColumn").Visible = False
            Me.dgvSerialLog.Columns("ShipmentPriceColumn").Visible = True
            cmdAddSerialNumber.Enabled = False
            cmdDeactivateSN.Enabled = False
            cmdDeleteSerialNumber.Enabled = False
            cmdOpenOrClose.Enabled = False
            cmdUpdateSerialNumber.Enabled = False
        End If

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            Me.dgvSerialLog.Columns("TotalCostColumn").ReadOnly = False
            Me.dgvSerialLog.Columns("StatusColumn").ReadOnly = False
            Me.dgvSerialLog.Columns("CustomerIDColumn").ReadOnly = False
            Me.dgvSerialLog.Columns("BuildNumberColumn").ReadOnly = False
            Me.dgvSerialLog.Columns("TransactionNumberColumn").ReadOnly = False
            Me.dgvSerialLog.Columns("BatchNumberColumn").ReadOnly = False
            Me.dgvSerialLog.Columns("ShipmentNumberColumn").ReadOnly = False
            Me.dgvSerialLog.Columns("ShipmentDateColumn").ReadOnly = False
            Me.dgvSerialLog.Columns("InvoiceNumberColumn").ReadOnly = False
            Me.dgvSerialLog.Columns("InvoiceDateColumn").ReadOnly = False
        Else
            Me.dgvSerialLog.Columns("TotalCostColumn").ReadOnly = True
            Me.dgvSerialLog.Columns("StatusColumn").ReadOnly = True
            Me.dgvSerialLog.Columns("CustomerIDColumn").ReadOnly = True
            Me.dgvSerialLog.Columns("BuildNumberColumn").ReadOnly = True
            Me.dgvSerialLog.Columns("TransactionNumberColumn").ReadOnly = True
            Me.dgvSerialLog.Columns("BatchNumberColumn").ReadOnly = True
            Me.dgvSerialLog.Columns("ShipmentNumberColumn").ReadOnly = True
            Me.dgvSerialLog.Columns("ShipmentDateColumn").ReadOnly = True
            Me.dgvSerialLog.Columns("InvoiceNumberColumn").ReadOnly = True
            Me.dgvSerialLog.Columns("InvoiceDateColumn").ReadOnly = True
        End If
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

    Public Sub ClearDataInDatagrid()
        dgvSerialLog.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND AssemblyPartNumber = '" + cboPartNumber.Text + "'"
        Else
            PartFilter = ""
        End If
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + cboCustomerID.Text + "'"
        Else
            CustomerFilter = ""
        End If
        If cboWarehouse.Text <> "" Then
            WarehouseName = cboWarehouse.Text

            Select Case WarehouseName
                Case "Bessemer"
                    WarehouseID = "BCW"
                Case "Downey"
                    WarehouseID = "DCW"
                Case "Hayward"
                    WarehouseID = "HCW"
                Case "Lewisville"
                    WarehouseID = "LCW"
                Case "Lyndhurst"
                    WarehouseID = "YCW"
                Case "Phoenix"
                    WarehouseID = "PCW"
                Case "Seattle"
                    WarehouseID = "SCW"
                Case "SRL"
                    WarehouseID = "SRL"
            End Select
            WarehouseFilter = " AND DivisionID = '" + WarehouseID + "'"
        Else
            WarehouseFilter = ""
        End If
        If txtSerialNumber.Text <> "" Then
            SerialFilter = " AND SerialNumber = '" + txtSerialNumber.Text + "'"
        Else
            SerialFilter = ""
        End If
        If cboStatus.Text <> "" Then
            StatusFilter = " AND Status = '" + cboStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "ADM" Or cboDivisionID.Text = "TST" Then
            DivisionFilter = " AND DivisionID <> 'ZZZ'"
        Else
            DivisionFilter = " AND DivisionID = '" + cboDivisionID.Text + "'"
        End If
        If txtTextSearch.Text <> "" Then
            TextFilter = " AND SerialNumber LIKE '%" + txtTextSearch.Text + "%'"
        Else
            TextFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND BuildDate Between @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE DivisionID <> @DivisionID" + StatusFilter + DivisionFilter + WarehouseFilter + CustomerFilter + PartFilter + SerialFilter + TextFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "QQQ"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "AssemblySerialLog")
        dgvSerialLog.DataSource = ds.Tables("AssemblySerialLog")
        con.Close()

        'Load formatting
        LoadFormatting()
    End Sub

    Public Sub LoadFormatting()
        Dim SerialStatus As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvSerialLog.Rows
            Try
                SerialStatus = row.Cells("StatusColumn").Value
            Catch ex As System.Exception
                SerialStatus = ""
            End Try

            If SerialStatus = "OPEN" Then
                Me.dgvSerialLog.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightSalmon
                Me.dgvSerialLog.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
            ElseIf SerialStatus = "CLOSED" Then
                Me.dgvSerialLog.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvSerialLog.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ElseIf SerialStatus = "AVAILABLE" Then
                Me.dgvSerialLog.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvSerialLog.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                Me.dgvSerialLog.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvSerialLog.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub LoadPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND PurchProdLineID = @PurchProdLineID AND ItemClass <> @ItemClass ", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND PurchProdLineID = @PurchProdLineID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PurchProdLineID", SqlDbType.VarChar).Value = "ASSEMBLY"
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomer()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomerID.DataSource = ds3.Tables("CustomerList")
        cboCustomerName.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
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

    Public Sub LoadLongDescription()
        Dim LongDescriptionStatement As String = "SELECT LongDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
        LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LongDescription = CStr(LongDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            LongDescription = ""
        End Try
        con.Close()

        txtLongDescription.Text = LongDescription
    End Sub

    Private Sub cmdUpdateSerialNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateSerialNumber.Click
        If Me.dgvSerialLog.RowCount = 0 Then
            'Do nothing
        Else
            Dim RowTransactionNumber As Integer = 0
            Dim RowSerialNumber As String = ""
            Dim RowPartNumber As String = ""
            Dim RowStatus As String = ""

            Dim button As DialogResult = MessageBox.Show("Do you wish to update this S/N to the oldest build?", "UPDATE SERIAL NUMBER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then

                Dim RowIndex As Integer = Me.dgvSerialLog.CurrentCell.RowIndex

                Try
                    RowTransactionNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("TransactionNumberColumn").Value
                Catch ex As Exception
                    RowTransactionNumber = 0
                End Try
                Try
                    RowPartNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value
                Catch ex As Exception
                    RowPartNumber = ""
                End Try
                Try
                    RowStatus = Me.dgvSerialLog.Rows(RowIndex).Cells("StatusColumn").Value
                Catch ex As Exception
                    RowStatus = ""
                End Try
                Try
                    RowSerialNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("SerialNumberColumn").Value
                Catch ex As Exception
                    RowSerialNumber = ""
                End Try
                '*******************************************************************************************************
                'Get Oldest Build Number
                If RowTransactionNumber > 0 Then
                    MsgBox("This serial number has already been applied to a build.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '*******************************************************************************************************
                'Get Oldest Build Number
                If RowStatus <> "AVAILABLE" Then
                    MsgBox("This serial number is not AVAILABLE.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '********************************************************************************************************
                Dim MinBuildDate As Integer = 0

                Dim MinBuildDateStatement As String = "SELECT MIN(BuildTransactionNumber) FROM AssemblyBuildHeaderTable WHERE SerialNumber = @SerialNumber AND DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber"
                Dim MinBuildDateCommand As New SqlCommand(MinBuildDateStatement, con)
                MinBuildDateCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                MinBuildDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                MinBuildDateCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = ""

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MinBuildDate = CInt(MinBuildDateCommand.ExecuteScalar)
                Catch ex As Exception
                    MinBuildDate = 0
                End Try
                con.Close()

                If MinBuildDate = 0 Then
                    MsgBox("There are no builds without a serial # assigned.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*******************************************************************************************************
                'Get Build Info based on the Build Number
                Dim BuildDate As String = ""
                Dim BuildComment As String = ""
                Dim BuildCost As Double = 0

                Dim BuildDateStatement As String = "SELECT BuildDate FROM AssemblyBuildHeaderTable WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID"
                Dim BuildDateCommand As New SqlCommand(BuildDateStatement, con)
                BuildDateCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = MinBuildDate
                BuildDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim BuildCommentStatement As String = "SELECT BuildComment FROM AssemblyBuildHeaderTable WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID"
                Dim BuildCommentCommand As New SqlCommand(BuildCommentStatement, con)
                BuildCommentCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = MinBuildDate
                BuildCommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim BuildCostStatement As String = "SELECT BuildCost FROM AssemblyBuildHeaderTable WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID"
                Dim BuildCostCommand As New SqlCommand(BuildCostStatement, con)
                BuildCostCommand.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = MinBuildDate
                BuildCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    BuildDate = CStr(BuildDateCommand.ExecuteScalar)
                Catch ex As Exception
                    BuildDate = ""
                End Try
                Try
                    BuildComment = CStr(BuildCommentCommand.ExecuteScalar)
                Catch ex As Exception
                    BuildComment = ""
                End Try
                Try
                    BuildCost = CDbl(BuildCostCommand.ExecuteScalar)
                Catch ex As Exception
                    BuildCost = 0
                End Try
                con.Close()
                '*****************************************************************************************
                'Update serial log with build info
                cmd = New SqlCommand("UPDATE AssemblySerialLog SET TotalCost = @TotalCost, Comment = @Comment, BuildDate = @BuildDate, Status = @Status, TransactionNumber = @TransactionNumber, CustomerID = @CustomerID, BatchNumber = @BatchNumber, BuildNumber = @BuildNumber WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@TotalCost", SqlDbType.VarChar).Value = BuildCost
                    .Add("@Comment", SqlDbType.VarChar).Value = BuildComment
                    .Add("@BuildDate", SqlDbType.VarChar).Value = BuildDate
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                    .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@BuildNumber", SqlDbType.VarChar).Value = MinBuildDate
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************
                'Update Build Header Table with Serial Number
                cmd = New SqlCommand("UPDATE AssemblyBuildHeaderTable SET SerialNumber = @SerialNumber WHERE BuildTransactionNumber = @BuildTransactionNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = MinBuildDate
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Serial Log and Build Table updated.", MsgBoxStyle.OkOnly)

                ShowDataByFilters()
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmdDeactivateSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeactivateSN.Click
        If Me.dgvSerialLog.RowCount = 0 Then
            'Do nothing
        Else
            Dim RowSerialNumber As String = ""
            Dim RowStatus As String = ""
            Dim RowPartNumber As String = ""

            Dim RowIndex As Integer = Me.dgvSerialLog.CurrentCell.RowIndex

            RowSerialNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("SerialNumberColumn").Value
            RowStatus = Me.dgvSerialLog.Rows(RowIndex).Cells("StatusColumn").Value
            RowPartNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value

            If RowStatus = "AVAILABLE" Then
                'Update Serial Log
                cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, Comment = @Comment WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                    .Add("@Comment", SqlDbType.VarChar).Value = "MANUAL CLOSE"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowDataByFilters()

                MsgBox("This serial number is closed.", MsgBoxStyle.OkOnly)
            Else
                MsgBox("You must have a valid S/N and status must be AVAILABLE.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub dgvSerialLog_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSerialLog.CellValueChanged
        If Me.dgvSerialLog.RowCount = 0 Then
            'Do nothing
        Else
            'Declare variables
            Dim RowDivision As String = ""
            Dim RowComment As String = ""
            Dim RowSerialNumber As String = ""
            Dim RowPartNumber As String = ""
            Dim RowStatus As String = ""
            Dim RowTotalCost As Double = 0

            Dim RowIndex As Integer = Me.dgvSerialLog.CurrentCell.RowIndex

            If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
                Try
                    RowDivision = Me.dgvSerialLog.Rows(RowIndex).Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivision = ""
                End Try
                Try
                    RowComment = Me.dgvSerialLog.Rows(RowIndex).Cells("CommentColumn").Value
                Catch ex As Exception
                    RowComment = ""
                End Try
                Try
                    RowSerialNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("SerialNumberColumn").Value
                Catch ex As Exception
                    RowSerialNumber = ""
                End Try
                Try
                    RowPartNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value
                Catch ex As Exception
                    RowPartNumber = ""
                End Try
                Try
                    RowStatus = Me.dgvSerialLog.Rows(RowIndex).Cells("StatusColumn").Value
                Catch ex As Exception
                    RowStatus = ""
                End Try
                Try
                    RowTotalCost = Me.dgvSerialLog.Rows(RowIndex).Cells("TotalCostColumn").Value
                Catch ex As Exception
                    RowTotalCost = 0
                End Try

                'Validate specific fields
                If RowStatus = "CLOSED" Or RowStatus = "AVAILABLE" Or RowStatus = "OPEN" Then
                    'Continue to save
                Else
                    Exit Sub
                End If
                If RowPartNumber = "" Then
                    Exit Sub
                End If
                If RowSerialNumber = "" Then
                    Exit Sub
                End If
                If RowDivision = "" Then
                    Exit Sub
                End If

                'Update Serial Log
                cmd = New SqlCommand("UPDATE AssemblySerialLog SET Comment = @Comment, TotalCost = @TotalCost, Status = @Status WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                    .Add("@TotalCost", SqlDbType.VarChar).Value = RowTotalCost
                    .Add("@Status", SqlDbType.VarChar).Value = RowStatus
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                Try
                    RowDivision = Me.dgvSerialLog.Rows(RowIndex).Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivision = ""
                End Try
                Try
                    RowComment = Me.dgvSerialLog.Rows(RowIndex).Cells("CommentColumn").Value
                Catch ex As Exception
                    RowComment = ""
                End Try
                Try
                    RowSerialNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("SerialNumberColumn").Value
                Catch ex As Exception
                    RowSerialNumber = ""
                End Try
                Try
                    RowPartNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value
                Catch ex As Exception
                    RowPartNumber = ""
                End Try

                'Update Serial Log
                cmd = New SqlCommand("UPDATE AssemblySerialLog SET Comment = @Comment WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub

    Private Sub dgvSerialLog_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSerialLog.CellDoubleClick
        Dim RowBuildNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowPartNumber As String = ""

        If Me.dgvSerialLog.RowCount > 0 And cboDivisionID.Text = "TWE" Then
            Dim RowIndex As Integer = Me.dgvSerialLog.CurrentCell.RowIndex

            Try
                RowBuildNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("BuildNumberColumn").Value
            Catch ex As Exception
                RowBuildNumber = 0
            End Try
            Try
                RowDivision = Me.dgvSerialLog.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try
            Try
                RowPartNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try

            If RowBuildNumber = 0 Then
                MsgBox("There is no build for this serial #. This will display the default BOM.", MsgBoxStyle.OkOnly)

                GlobalDivisionCode = cboDivisionID.Text
                GlobalAssemblyPartNumber = RowPartNumber

                Using NewPrintAssemblyBOM As New PrintAssemblyBOM
                    Dim Result = NewPrintAssemblyBOM.ShowDialog()
                End Using
            Else
                GlobalAssemblyTransactionNumber = RowBuildNumber

                If cboDivisionID.Text = "ADM" Then
                    GlobalDivisionCode = RowDivision
                Else
                    GlobalDivisionCode = cboDivisionID.Text
                End If

                Using NewPrintAssemblyBuildBOM As New PrintAssemblyBuildBOM
                    Dim Result = NewPrintAssemblyBuildBOM.ShowDialog()
                End Using
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "ADM" Then
            dgvSerialLog.Columns("TotalCostColumn").Visible = True
            cmdUpdateSerialNumber.Enabled = True
            cmdDeactivateSN.Enabled = True
            cmdAddSerialNumber.Enabled = True
            cmdDeactivateSN.Enabled = True
            cmdDeleteSerialNumber.Enabled = True
            cmdOpenOrClose.Enabled = True
            cmdUpdateSerialNumber.Enabled = True
            AddSerialNumbersStringToolStripMenuItem.Enabled = True
        Else
            If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
                dgvSerialLog.Columns("TotalCostColumn").Visible = True
                dgvSerialLog.Columns("ShipmentPriceColumn").Visible = True
                cmdUpdateSerialNumber.Enabled = True
                cmdDeactivateSN.Enabled = True
                cmdAddSerialNumber.Enabled = True
                cmdDeactivateSN.Enabled = True
                cmdDeleteSerialNumber.Enabled = True
                cmdOpenOrClose.Enabled = True
                cmdUpdateSerialNumber.Enabled = True
                AddSerialNumbersStringToolStripMenuItem.Enabled = True
            Else
                dgvSerialLog.Columns("TotalCostColumn").Visible = False
                dgvSerialLog.Columns("ShipmentPriceColumn").Visible = True
                cmdUpdateSerialNumber.Enabled = False
                cmdDeactivateSN.Enabled = False
                cmdAddSerialNumber.Enabled = False
                cmdDeactivateSN.Enabled = False
                cmdDeleteSerialNumber.Enabled = False
                cmdOpenOrClose.Enabled = False
                cmdUpdateSerialNumber.Enabled = False
                AddSerialNumbersStringToolStripMenuItem.Enabled = False
            End If
        End If

        ClearData()
        LoadPartNumber()
        LoadPartDescription()
        LoadCustomer()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadLongDescription()
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Public Sub ClearData()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboWarehouse.SelectedIndex = -1
        txtLongDescription.Clear()
        txtSerialNumber.Clear()
        txtTextSearch.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        LongDescription = ""
        DateFilter = ""
        SerialFilter = ""
        PartFilter = ""
        StatusFilter = ""
        WarehouseFilter = ""
        WarehouseID = ""
        TextFilter = ""
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearAllToolStripMenuItem.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintSerialLog As New PrintSerialLog
            Dim Result = NewPrintSerialLog.ShowDialog()
        End Using
    End Sub

    Private Sub PrintSerialListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSerialListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintSerialLog As New PrintSerialLog
            Dim Result = NewPrintSerialLog.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdAddSerialNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSerialNumber.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewAssemblyAddNewSerialNumber As New AssemblyAddNewSerialNumber
            Dim Result = NewAssemblyAddNewSerialNumber.ShowDialog()
        End Using
    End Sub

    Private Sub AddSerialNumbersStringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddSerialNumbersStringToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewAssemblyAddAvailableSerialNumbers As New AssemblyAddAvailableSerialNumbers
            Dim Result = NewAssemblyAddAvailableSerialNumbers.ShowDialog()
        End Using
    End Sub

    Private Sub dgvSerialLog_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSerialLog.ColumnHeaderMouseClick
        LoadFormatting()
    End Sub

    Private Sub cmdOpenOrClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenOrClose.Click
        Dim RowSerialNumber As String = ""
        Dim RowDivision As String = ""
        Dim RowPartNumber As String = ""
        Dim RowStatus As String = ""

        If Me.dgvSerialLog.RowCount > 0 And cboDivisionID.Text = "TWE" Then
            Dim RowIndex As Integer = Me.dgvSerialLog.CurrentCell.RowIndex

            Try
                RowSerialNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("SerialNumberColumn").Value
            Catch ex As Exception
                RowSerialNumber = ""
            End Try
            Try
                RowDivision = Me.dgvSerialLog.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try
            Try
                RowPartNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowStatus = Me.dgvSerialLog.Rows(RowIndex).Cells("StatusColumn").Value
            Catch ex As Exception
                RowStatus = ""
            End Try

            If RowStatus = "CLOSED" Then
                Dim button As DialogResult = MessageBox.Show("This serial # is closed. Do you wish to re-open?", "UPDATE SERIAL #", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then

                    'Update Serial Log
                    cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Refresh Datagrid
                    MsgBox("This serial # is now open.", MsgBoxStyle.OkOnly)
                    ShowDataByFilters()
                Else
                    Exit Sub
                End If
            ElseIf RowStatus = "OPEN" Then
                Dim button As DialogResult = MessageBox.Show("This serial # is open. Do you wish to close it?", "UPDATE SERIAL #", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then

                    'Update Serial Log
                    cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                        .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Refresh Datagrid
                    MsgBox("This serial # is now closed.", MsgBoxStyle.OkOnly)
                    ShowDataByFilters()
                Else
                    Exit Sub
                End If
            Else
                'Do nothing if not open or closed.
            End If
        End If
    End Sub

    Private Sub cmdDeleteSerialNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSerialNumber.Click
        If Me.dgvSerialLog.RowCount = 0 Then
            'Do nothing
        Else
            Dim RowSerialNumber As String = ""
            Dim RowStatus As String = ""
            Dim RowPartNumber As String = ""
            Dim RowBuildNumber As Integer = 0
            Dim RowCustomer As String = ""

            Dim RowIndex As Integer = Me.dgvSerialLog.CurrentCell.RowIndex

            RowSerialNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("SerialNumberColumn").Value
            RowStatus = Me.dgvSerialLog.Rows(RowIndex).Cells("StatusColumn").Value
            RowPartNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("AssemblyPartNumberColumn").Value
            RowBuildNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("BuildNumberColumn").Value
            RowCustomer = Me.dgvSerialLog.Rows(RowIndex).Cells("CustomerIDColumn").Value

            If RowStatus = "AVAILABLE" Then
                'Update Serial Log
                cmd = New SqlCommand("DELETE FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowDataByFilters()

                MsgBox("This serial number has been deleted.", MsgBoxStyle.OkOnly)
            ElseIf RowStatus = "CLOSED" Then
                If RowBuildNumber = 0 And RowCustomer = "" Then
                    'Update Serial Log
                    cmd = New SqlCommand("DELETE FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    ShowDataByFilters()

                    MsgBox("This serial number has been deleted.", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("You must have a valid S/N and status must be AVAILABLE.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
        End If
    End Sub
End Class