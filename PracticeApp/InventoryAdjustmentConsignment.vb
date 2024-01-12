Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class InventoryAdjustmentConsignment
    Inherits System.Windows.Forms.Form

    Dim WarehouseID As String = ""
    Dim ConsignmentWarehouse As String = ""
    Dim GLInventoryAccount As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub InventoryAdjustmentConsignment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        ClearData()
        ShowData()
    End Sub

    Public Sub ShowData()
        'Loads data in datagrid
        cmd = New SqlCommand("SELECT * FROM ConsignmentAdjustmentTable WHERE DivisionID = @DivisionID AND PostDate = @PostDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PostDate", SqlDbType.VarChar).Value = Today()
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ConsignmentAdjustmentTable")
        dgvConsignmentAdjustments.DataSource = ds.Tables("ConsignmentAdjustmentTable")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescriptionByPartNumber()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
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

        cboDescription.Text = PartDescription1
    End Sub

    Public Sub LoadPartNumberByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboDescription.Text
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

    Public Sub LoadQOH()
        If cboPartNumber.Text <> "" And cboWarehouse.Text <> "" Then
            Dim LoadQOH As Double = 0

            Dim LoadQOHStatement As String = "SELECT QuantityOnHand FROM ConsignmentInventory WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
            Dim LoadQOHCommand As New SqlCommand(LoadQOHStatement, con)
            LoadQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
            LoadQOHCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LoadQOH = CDbl(LoadQOHCommand.ExecuteScalar)
            Catch ex As Exception
                LoadQOH = 0
            End Try
            con.Close()

            lblQOH.Text = LoadQOH
        End If
    End Sub

    Public Sub LoadCost()
        If cboPartNumber.Text <> "" And cboWarehouse.Text <> "" Then
            'Get Cost of Consignment Adjustment
            Dim MAXCostDate As Integer = 0
            Dim LoadUnitCost As Double = 0

            Dim MAXCostDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
            Dim MAXCostDateCommand As New SqlCommand(MAXCostDateStatement, con)
            MAXCostDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
            MAXCostDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXCostDate = CInt(MAXCostDateCommand.ExecuteScalar)
            Catch ex As Exception
                MAXCostDate = 0
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
            LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCostDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LoadUnitCost = CDbl(LastPriceCommand.ExecuteScalar)
                LoadUnitCost = Math.Round(LoadUnitCost, 5)
            Catch ex As Exception
                LoadUnitCost = 0
            End Try
            con.Close()

            txtUnitCost.Text = LoadUnitCost
        End If
    End Sub

    Public Sub ClearData()
        cboPartNumber.SelectedIndex = -1
        cboDescription.SelectedIndex = -1
        cboWarehouse.SelectedIndex = -1

        txtComments.Clear()
        txtExtendedAmount.Clear()
        txtQuantity.Clear()
        txtUnitCost.Clear()

        dtpAdjustmentDate.Text = ""

        lblQOH.Text = ""

        chkSave.Checked = False

        dtpAdjustmentDate.Focus()
    End Sub

    Public Sub ClearDataWithSave()
        cboPartNumber.SelectedIndex = -1
        cboDescription.SelectedIndex = -1

        txtComments.Clear()
        txtExtendedAmount.Clear()
        txtQuantity.Clear()
        txtUnitCost.Clear()

        lblQOH.Text = ""

        cboPartNumber.Focus()
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
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
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

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadWarehouseID()
        ConsignmentWarehouse = cboWarehouse.Text

        'Validate Consignment Warehouse
        Select Case ConsignmentWarehouse
            Case "Downey"
                WarehouseID = "DCW"
                GLInventoryAccount = "12630"
            Case "Phoenix"
                WarehouseID = "PCW"
                GLInventoryAccount = "12660"
            Case "Hayward"
                WarehouseID = "HCW"
                GLInventoryAccount = "12620"
            Case "Bessemer"
                WarehouseID = "BCW"
                GLInventoryAccount = "12610"
            Case "Lewisville"
                WarehouseID = "LCW"
                GLInventoryAccount = "12650"
            Case "Seattle"
                WarehouseID = "SCW"
                GLInventoryAccount = "12640"
            Case "Lyndhurst"
                WarehouseID = "YCW"
                GLInventoryAccount = "12600"
            Case "Renton"
                WarehouseID = "RCW"
                GLInventoryAccount = "12680"
            Case "Lake Stevens"
                WarehouseID = "LSCW"
                GLInventoryAccount = "12690"
            Case "SRL"
                WarehouseID = "SRL"
                GLInventoryAccount = "12670"
            Case Else
                WarehouseID = ""
                GLInventoryAccount = "12100"
        End Select
    End Sub

    Private Sub cmdAddAdjustment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddAdjustment.Click
        'Validate Fields
        Dim CheckPartNumber As Integer = 0
        Dim ValidationRule As String = ""
        Dim ConsignmentWarehouse As String = ""
        Dim WarehouseID As String = ""
        Dim AdjustmentQuantity As Double = 0

        Dim GLIssuesAccount As String = "59790"
        Dim LastTransactionCost As Double = 0
        Dim ExtendedTransactionCost As Double = 0

        AdjustmentQuantity = Val(txtQuantity.Text)

        Dim CheckPartNumberCommand As New SqlCommand("SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)
        CheckPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CheckPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckPartNumber = CInt(CheckPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckPartNumber = 0
        End Try
        con.Close()

        'Load Warehouse ID and GL Account
        ConsignmentWarehouse = cboWarehouse.Text

        Select Case ConsignmentWarehouse
            Case "Downey"
                WarehouseID = "DCW"
                GLInventoryAccount = "12630"
            Case "Phoenix"
                WarehouseID = "PCW"
                GLInventoryAccount = "12660"
            Case "Hayward"
                WarehouseID = "HCW"
                GLInventoryAccount = "12620"
            Case "Bessemer"
                WarehouseID = "BCW"
                GLInventoryAccount = "12610"
            Case "Lewisville"
                WarehouseID = "LCW"
                GLInventoryAccount = "12650"
            Case "Seattle"
                WarehouseID = "SCW"
                GLInventoryAccount = "12640"
            Case "Lyndhurst"
                WarehouseID = "YCW"
                GLInventoryAccount = "12600"
            Case "Renton"
                WarehouseID = "RCW"
                GLInventoryAccount = "12680"
            Case "Lake Stevens"
                WarehouseID = "LSCW"
                GLInventoryAccount = "12690"
            Case "SRL"
                WarehouseID = "SRL"
                GLInventoryAccount = "12670"
            Case Else
                WarehouseID = ""
                GLInventoryAccount = "12100"
        End Select

        If txtQuantity.Text = "" Or Val(txtQuantity.Text) = 0 Or Not IsNumeric(txtQuantity.Text) Or WarehouseID = "" Then
            ValidationRule = "FAIL"
        Else
            ValidationRule = "NO FAIL"
        End If

        If CheckPartNumber = 0 Or ValidationRule = "FAIL" Then
            MsgBox("Check part number, warehouse, and quantity.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If
        '********************************************************************************************************
        'Get Cost of Consignment Adjustment
        If Val(txtUnitCost.Text) = 0 Then
            Dim MAXCostDate As Integer = 0

            Dim MAXCostDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
            Dim MAXCostDateCommand As New SqlCommand(MAXCostDateStatement, con)
            MAXCostDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
            MAXCostDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MAXCostDate = CInt(MAXCostDateCommand.ExecuteScalar)
            Catch ex As Exception
                MAXCostDate = 0
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
            LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MAXCostDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastTransactionCost = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastTransactionCost = 0
            End Try
            con.Close()
        Else
            LastTransactionCost = Val(txtUnitCost.Text)
        End If

        ExtendedTransactionCost = AdjustmentQuantity * LastTransactionCost
        ExtendedTransactionCost = Math.Round(ExtendedTransactionCost, 2)
        txtExtendedAmount.Text = ExtendedTransactionCost
        '********************************************************************************************************
        'Create command to save consignment
        '********************************************************************************************************
        'Get next Adjustment Number
        Dim NextConsignmentNumber, LastConsignmentNumber As Integer

        Dim MaxAdjustmentNumberCommand As New SqlCommand("SELECT MAX(ConsignmentAdjustmentNumber) FROM ConsignmentAdjustmentTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastConsignmentNumber = CInt(MaxAdjustmentNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastConsignmentNumber = 23300000
        End Try
        con.Close()

        NextConsignmentNumber = LastConsignmentNumber + 1
        '********************************************************************************************************
        'Create command to Insert Consignment Adjustments
        cmd = New SqlCommand("INSERT INTO ConsignmentAdjustmentTable (ConsignmentAdjustmentNumber, PartNumber, PartDescription, Quantity , UnitCost, ExtendedAmount, DivisionID, AdjustmentDate, CustomerClass, Comment, PostDate, PostedBy) Values (@ConsignmentAdjustmentNumber, @PartNumber, @PartDescription, @Quantity , @UnitCost, @ExtendedAmount, @DivisionID, @AdjustmentDate, @CustomerClass, @Comment, @PostDate, @PostedBy)", con)

        With cmd.Parameters
            .Add("@ConsignmentAdjustmentNumber", SqlDbType.VarChar).Value = NextConsignmentNumber
            .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@PartDescription", SqlDbType.VarChar).Value = cboDescription.Text
            .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
            .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtExtendedAmount.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@AdjustmentDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
            .Add("@CustomerClass", SqlDbType.VarChar).Value = WarehouseID
            .Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text
            .Add("@PostDate", SqlDbType.VarChar).Value = Now()
            .Add("@PostedBy", SqlDbType.VarChar).Value = EmployeeLoginName
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '********************************************************************************************************
        'Create Inventory Transaction
        'Enter into Inventory Transaction Table for Warehouse ID
        Dim LastITNumber2 As Integer = 0
        Dim NextITNumber2 As Integer = 0

        'Find Next Transaction Number
        Dim ITNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
        Dim ITNumber2Command As New SqlCommand(ITNumber2Statement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastITNumber2 = CInt(ITNumber2Command.ExecuteScalar)
        Catch ex As Exception
            LastITNumber2 = 867500000
        End Try
        con.Close()

        NextITNumber2 = LastITNumber2 + 1

        Try
            'Write Data to the Inventory Transaction Table
            cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

            With cmd.Parameters
                .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextITNumber2
                .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                .Add("@TransactionType", SqlDbType.VarChar).Value = "Consignment Adjustment"
                .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = NextConsignmentNumber
                .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = 1
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboDescription.Text
                .Add("@Quantity", SqlDbType.VarChar).Value = AdjustmentQuantity
                .Add("@ItemCost", SqlDbType.VarChar).Value = LastTransactionCost
                .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedTransactionCost
                .Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
                .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                .Add("@GLAccount", SqlDbType.VarChar).Value = GLInventoryAccount
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip
        End Try
        '********************************************************************************************************
        'Enter into Cost Tier for Warehouse ID

        'Extract the Upper and Lower Limit of the Inventory Costing Table
        Dim NewUpperLimitCosting, LowerLimitCosting, UpperLimitCosting As Double
        Dim MaxTransactionNumber As Integer

        Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
        MaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        MaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            MaxTransactionNumber = 0
        End Try
        con.Close()

        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
        UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber
        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UpperLimitCosting = CDbl(UpperLimitCommand.ExecuteScalar)
        Catch ex As Exception
            UpperLimitCosting = 0
        End Try
        con.Close()
        '********************************************************************************************************
        'Calculate the NEW Lower/Upper Limit for the next post
        LowerLimitCosting = UpperLimitCosting + 1
        NewUpperLimitCosting = LowerLimitCosting + AdjustmentQuantity - 1

        'Get next Transaction Number
        Dim LastCostingTransactionNumber As Integer = 0
        Dim NextCostingTransactionNumber As Integer = 0

        Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
        Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastCostingTransactionNumber = 63600000
        End Try
        con.Close()

        NextCostingTransactionNumber = LastCostingTransactionNumber + 1

        'Write Values to Inventory Costing Table
        Try
            cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

            With cmd.Parameters
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = WarehouseID
                .Add("@CostingDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                .Add("@ItemCost", SqlDbType.VarChar).Value = LastTransactionCost
                .Add("@CostQuantity", SqlDbType.VarChar).Value = AdjustmentQuantity
                .Add("@Status", SqlDbType.VarChar).Value = "CONSIGNMENT ADJUSTMENT"
                .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimitCosting
                .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimitCosting
                .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = NextConsignmentNumber
                .Add("@ReferenceLine", SqlDbType.VarChar).Value = 1
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip
        End Try
        '********************************************************************************************************
        'Create GL Transaction

        'Get next Transaction Number
        Dim LastGLTransactionNumber As Integer = 0
        Dim NextGLTransactionNumber As Integer = 0

        Dim GLTransactionNumberStatement As String = "SELECT MAX(GLTransactionKey) FROM GLTransactionMasterList"
        Dim GLTransactionNumberCommand As New SqlCommand(GLTransactionNumberStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastGLTransactionNumber = CInt(GLTransactionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastGLTransactionNumber = 63600000
        End Try
        con.Close()

        NextGLTransactionNumber = LastGLTransactionNumber + 1

        'Write Debit to GL Transactions
        Try
            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, DivisionID, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount, GLTransactionComment, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @DivisionID, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount, @GLTransactionComment, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

            With cmd.Parameters
                .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLTransactionNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Consignment Inventory Adjustment"
                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedTransactionCost
                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = WarehouseID + " - Adjustment - " + cboPartNumber.Text
                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVENTORYJOURNAL"
                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 0
                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Write Credit to GL Transactions
            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, DivisionID, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount, GLTransactionComment, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values(@GLTransactionKey, @DivisionID, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount, @GLTransactionComment, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

            With cmd.Parameters
                .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLTransactionNumber + 1
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLIssuesAccount
                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Consignment Inventory Adjustment"
                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedTransactionCost
                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = WarehouseID + " - Adjustment - " + cboPartNumber.Text
                .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVENTORYJOURNAL"
                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = 0
                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = 0
                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip
        End Try
        '********************************************************************************************************
        'Clear Fields
        If chkSave.Checked = True Then
            ClearDataWithSave()
        Else
            ClearData()
        End If

        MsgBox("Adjustment has been entered.", MsgBoxStyle.OkOnly)
        ShowData()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearData()
        LoadPartNumber()
        LoadPartDescription()
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        If txtQuantity.Text <> "" And txtUnitCost.Text <> "" Then
            Dim TempUnitCost As Double = 0
            Dim TempQuantity As Double = 0
            Dim TempExtendedCost As Double = 0

            TempUnitCost = Val(txtUnitCost.Text)
            TempQuantity = Val(txtQuantity.Text)
            TempExtendedCost = TempUnitCost * TempQuantity
            TempExtendedCost = Math.Round(TempExtendedCost, 2)

            txtExtendedAmount.Text = TempExtendedCost
        Else
            txtExtendedAmount.Clear()
        End If
    End Sub

    Private Sub txtUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitCost.TextChanged
        If txtQuantity.Text <> "" And txtUnitCost.Text <> "" Then
            Dim TempUnitCost As Double = 0
            Dim TempQuantity As Double = 0
            Dim TempExtendedCost As Double = 0

            TempUnitCost = Val(txtUnitCost.Text)
            TempQuantity = Val(txtQuantity.Text)
            TempExtendedCost = TempUnitCost * TempQuantity
            TempExtendedCost = Math.Round(TempExtendedCost, 2)

            txtExtendedAmount.Text = TempExtendedCost
        Else
            txtExtendedAmount.Clear()
        End If
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If cboPartNumber.Text <> "" Then
            LoadPartDescriptionByPartNumber()
            LoadCost()
            LoadQOH()
        End If
    End Sub

    Private Sub cboDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDescription.SelectedIndexChanged
        If cboDescription.Text <> "" Then
            LoadPartNumberByDescription()
            LoadCost()
            LoadQOH()
        End If
    End Sub

    Private Sub cboWarehouse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWarehouse.SelectedIndexChanged
        LoadWarehouseID()
    End Sub
End Class