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
Public Class InventoryTransactionMaintenance
    Inherits System.Windows.Forms.Form

    Dim LongDescription, ItemClass, GLAccount As String
    Dim NextTransactionNumber, LastTransactionNumber As Integer
    Dim UnitCost, UnitPrice, ExtendedCost, ExtendedAmount, Quantity As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub InventoryTransactionMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
                cboDivisionID.Enabled = True
            Else
                cboDivisionID.Enabled = False
            End If

            cboDivisionID.Text = EmployeeCompanyCode
        End If

        ClearAll()
        LoadPartNumber()
        ClearDataInDatagrid()

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            'Do nothing
        Else
            'Disable ability to create Inventory Transactions
            cmdAddTransaction.Enabled = False
            cmdGenerateTransactionNumber.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
            cmdDelete.Enabled = False
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

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber ORDER BY TransactionDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryTransactionTable")
        dgvInventoryTransactions.DataSource = ds.Tables("InventoryTransactionTable")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvInventoryTransactions.DataSource = Nothing
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartNumber.DataSource = ds2.Tables("ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadTransactionType()
        cmd = New SqlCommand("SELECT DISTINCT TransactionType FROM InventoryTransactionTable ORDER BY TransactionType", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "InventoryTransactionTable")
        cboTransactionType.DataSource = ds3.Tables("InventoryTransactionTable")
        con.Close()
        cboTransactionType.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        Dim LongDescriptionStatement As String = "SELECT LongDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LongDescription = CStr(LongDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            LongDescription = ""
        End Try
        con.Close()

        txtLongDescription.Text = LongDescription
    End Sub

    Public Sub ClearAll()
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboTransactionMath.SelectedIndex = -1
        cboTransactionType.SelectedIndex = -1

        chkCreateCostTier.Checked = False

        txtExtendedAmount.Clear()
        txtExtendedCost.Clear()
        txtLongDescription.Clear()
        txtQuantity.Clear()
        txtTransactionNumber.Clear()
        txtUnitCost.Clear()
        txtUnitPrice.Clear()
        txtReferenceNumber.Clear()
        txtReferenceLine.Clear()

        cmdGenerateTransactionNumber.Focus()
    End Sub
 
    Public Sub ClearVariables()
        LongDescription = ""
        NextTransactionNumber = 0
        LastTransactionNumber = 0
        Quantity = 0
        UnitCost = 0
        UnitPrice = 0
        ExtendedCost = 0
        ExtendedAmount = 0
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadPartDescription()
        ShowData()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearAll()
        LoadPartNumber()
        LoadTransactionType()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdGenerateTransactionNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateTransactionNumber.Click
        'Find the next Transaction Number to use
        Dim MAXStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionNumber = 1000000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        txtTransactionNumber.Text = NextTransactionNumber

        'Fill variables from text boxes
        UnitCost = Val(txtUnitCost.Text)
        Quantity = Val(txtQuantity.Text)
        UnitPrice = Val(txtUnitPrice.Text)
        ExtendedCost = Quantity * UnitCost
        ExtendedAmount = Quantity * UnitPrice
        txtExtendedCost.Text = FormatCurrency(ExtendedCost, 2)
        txtExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)

        Try
            'Write Data to Inventory Table
            cmd = New SqlCommand("Insert Into InventoryTransactionTable(TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ExtendedCost, ItemPrice, ExtendedAmount, DivisionID, TransactionMath, GLAccount)Values(@TransactionNumber, @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ExtendedCost, @ItemPrice, @ExtendedAmount, @DivisionID, @TransactionMath, @GLAccount)", con)

            With cmd.Parameters
                .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
                .Add("@TransactionType", SqlDbType.VarChar).Value = cboTransactionType.Text
                .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(txtReferenceNumber.Text)
                .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = Val(txtReferenceLine.Text)
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                .Add("@ItemCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
                .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedCost
                .Add("@ItemPrice", SqlDbType.VarChar).Value = Val(txtUnitPrice.Text)
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@TransactionMath", SqlDbType.VarChar).Value = cboTransactionMath.Text
                .Add("@GLAccount", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Do nothing
        End Try
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        UnitCost = Val(txtUnitCost.Text)
        Quantity = Val(txtQuantity.Text)
        UnitPrice = Val(txtUnitPrice.Text)
        ExtendedCost = Quantity * UnitCost
        ExtendedAmount = Quantity * UnitPrice
        txtExtendedCost.Text = FormatCurrency(ExtendedCost, 2)
        txtExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)
    End Sub

    Private Sub txtUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitCost.TextChanged
        UnitCost = Val(txtUnitCost.Text)
        Quantity = Val(txtQuantity.Text)
        UnitPrice = Val(txtUnitPrice.Text)
        ExtendedCost = Quantity * UnitCost
        ExtendedAmount = Quantity * UnitPrice
        txtExtendedCost.Text = FormatCurrency(ExtendedCost, 2)
        txtExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)
    End Sub

    Private Sub txtUnitPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitPrice.TextChanged
        UnitCost = Val(txtUnitCost.Text)
        Quantity = Val(txtQuantity.Text)
        UnitPrice = Val(txtUnitPrice.Text)
        ExtendedCost = Quantity * UnitCost
        ExtendedAmount = Quantity * UnitPrice
        txtExtendedCost.Text = FormatCurrency(ExtendedCost, 2)
        txtExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)
    End Sub

    Private Sub cmdAddTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddTransaction.Click
        If txtTransactionNumber.Text = "" Or cboTransactionMath.Text = "" Then
            MsgBox("You must have a valid Transaction Number and Process selected.", MsgBoxStyle.OkOnly)
        Else
            'Fill variables from text boxes
            UnitCost = Val(txtUnitCost.Text)
            Quantity = Val(txtQuantity.Text)
            UnitPrice = Val(txtUnitPrice.Text)
            ExtendedCost = Quantity * UnitCost
            ExtendedAmount = Quantity * UnitPrice
            txtExtendedCost.Text = FormatCurrency(ExtendedCost, 2)
            txtExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)

            Dim ReferenceNumber As Integer = 0
            Dim ReferenceLine As Integer = 0

            'Get Item Class for Part Number
            Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
            Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
            ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ItemClass = CStr(ItemClassCommand.ExecuteScalar)
            Catch ex As Exception
                ItemClass = "TW CA"
            End Try
            con.Close()

            'Get Inventory Account for Item Class
            Dim InventoryAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
            Dim InventoryAccountCommand As New SqlCommand(InventoryAccountStatement, con)
            InventoryAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GLAccount = CStr(InventoryAccountCommand.ExecuteScalar)
            Catch ex As Exception
                GLAccount = "12100"
            End Try
            con.Close()
            '******************************************************************************************
            If txtReferenceNumber.Text = "" Or Val(txtReferenceNumber.Text) = 0 Then
                ReferenceNumber = 0
            Else
                ReferenceNumber = Val(txtReferenceNumber.Text)
            End If
            If txtReferenceLine.Text = "" Or Val(txtReferenceLine.Text) = 0 Then
                ReferenceLine = 0
            Else
                ReferenceLine = Val(txtReferenceLine.Text)
            End If

            If cboTransactionMath.Text = "ADD" Or cboTransactionMath.Text = "SUBTRACT" Then
                'Write Data to Inventory Transaction Database Table
                cmd = New SqlCommand("UPDATE InventoryTransactionTable SET TransactionDate = @TransactionDate, TransactionType = @TransactionType, TransactionTypeNumber = @TransactionTypeNumber, TransactionTypeLineNumber = @TRansactionTypeLineNumber, PartNumber = @PartNumber, PartDescription = @PartDescription, Quantity = @Quantity, ItemCost = @ItemCost, ExtendedCost = @ExtendedCost, ItemPrice = @ItemPrice, ExtendedAmount = @ExtendedAmount, DivisionID = @DivisionID, TransactionMath = @TransactionMath, GLAccount = @GLAccount WHERE TransactionNumber = @TransactionNumber", con)

                With cmd.Parameters
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(txtTransactionNumber.Text)
                    .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
                    .Add("@TransactionType", SqlDbType.VarChar).Value = cboTransactionType.Text
                    .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = ReferenceNumber
                    .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = ReferenceLine
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                    .Add("@ItemCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedCost
                    .Add("@ItemPrice", SqlDbType.VarChar).Value = Val(txtUnitPrice.Text)
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@TransactionMath", SqlDbType.VarChar).Value = cboTransactionMath.Text
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If chkCreateCostTier.Checked = True Then
                    'Create Cost Tier for part
                    Dim NextCostingTransactionNumber, LastCostingTransactionNumber As Integer
                    Dim NewUpperLimit, LowerLimit, UpperLimit As Double
                    Dim MaxTransactionNumber As Integer
                    Dim MaxDate As String = ""
                    Dim TransactionQuantity As Double
                    TransactionQuantity = Val(txtQuantity.Text)

                    'Get Max date first
                    Dim MAXDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                    Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                    MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MaxDate = CStr(MAXDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        MaxDate = ""
                    End Try
                    con.Close()

                    Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
                    Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
                    MaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    MaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    MaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MaxDate

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        MaxTransactionNumber = 0
                    End Try
                    con.Close()

                    Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID AND PartNumber = @PartNumber"
                    Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                    UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber
                    UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                    Catch ex As Exception
                        UpperLimit = 0
                    End Try
                    con.Close()

                    'Calculate the NEW Lower/Upper Limit for the next post
                    LowerLimit = UpperLimit + 1
                    NewUpperLimit = LowerLimit + TransactionQuantity - 1

                    'Get next Transaction Number
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
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@CostingDate", SqlDbType.VarChar).Value = dtpTransactionDate.Text
                            .Add("@ItemCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
                            .Add("@CostQuantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
                            .Add("@Status", SqlDbType.VarChar).Value = cboTransactionType.Text
                            .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                            .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(txtReferenceNumber.Text)
                            .Add("@ReferenceLine", SqlDbType.VarChar).Value = Val(txtReferenceLine.Text)
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        LowerLimit = 0
                        UpperLimit = 0
                        NewUpperLimit = 0
                        NextCostingTransactionNumber = 0
                        LastCostingTransactionNumber = 0
                    Catch ex As Exception
                        'Skip
                    End Try
                End If

                ClearAll()
                ClearVariables()
                ClearDataInDatagrid()

                MsgBox("Manual Transaction has been added.", MsgBoxStyle.OkOnly)
            Else
                MsgBox("Process has to be ADD or SUBTRACT to continue.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearAll()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Inventory Transaction?", "DELETE TRANSACTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            If dgvInventoryTransactions.RowCount <> 0 Then
                Dim RowTransactionNumber As Integer
                Dim RowIndex As Integer = Me.dgvInventoryTransactions.CurrentCell.RowIndex

                RowTransactionNumber = Me.dgvInventoryTransactions.Rows(RowIndex).Cells("TransactionNumberColumn").Value

                Try
                    'Write Data to Purchase Order Header Database Table
                    cmd = New SqlCommand("DELETE FROM InventoryTransactionTable WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    ClearVariables()
                    ClearAll()
                    ClearDataInDatagrid()
                Catch ex As Exception
                    MsgBox("This Transaction cannot be deleted.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End Try
            Else
                MsgBox("This Transaction cannot be deleted.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        ElseIf button = DialogResult.No Then
            cmdClear.Focus()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        cmdAddTransaction_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintInventoryTransactionsFiltered As New PrintInventoryTransactionsFiltered
            Dim Result = NewPrintInventoryTransactionsFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class