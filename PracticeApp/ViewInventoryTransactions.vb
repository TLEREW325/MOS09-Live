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
Public Class ViewInventoryTransactions
    Inherits System.Windows.Forms.Form

    Dim ZeroCostFilter, DateFilter, PartFilter, TransactionFilter, TypeFilter, GLFilter As String
    Dim TransactionTypeNumber As Integer
    Dim strTransactionNumber, strBeginDate, strEndDate As String
    Dim BeginDate, EndDate, TransactionDate As Date
    Dim DivisionID As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=45")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewInventoryTransactions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.GLAccounts' table. You can move, or remove it, as needed.
        Me.GLAccountsTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.GLAccounts)

        usefulFunctions.LoadSecurity(Me)

        LoadCurrentDivision()

        If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
            cboDivisionID.Enabled = True
        Else
            Me.dgvInventoryTransactions.ReadOnly = True
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

    Public Sub ShowDataByFilter()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboGLAccount.Text <> "" Then
            GLFilter = " AND GLAccount = '" + cboGLAccount.Text + "'"
        Else
            GLFilter = ""
        End If
        If cboTransType.Text <> "" Then
            TypeFilter = " AND TransactionType = '" + cboTransType.Text + "'"
        Else
            TypeFilter = ""
        End If
        If cboTransactionTypeNumber.Text <> "" Then
            TransactionTypeNumber = Val(cboTransactionTypeNumber.Text)
            strTransactionNumber = CStr(TransactionTypeNumber)
            TransactionFilter = " AND TransactionTypeNumber = '" + strTransactionNumber + "'"
        Else
            TransactionFilter = ""
        End If
        If chkZeroCost.Checked = True Then
            ZeroCostFilter = " AND ExtendedCost = 0"
        Else
            ZeroCostFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value
 
            strBeginDate = CStr(BeginDate)
            strEndDate = CStr(EndDate)

            DateFilter = " AND TransactionDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM InventoryTransactionTable WHERE DivisionID = @DivisionID" + PartFilter + GLFilter + TransactionFilter + TypeFilter + ZeroCostFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
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
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadTypeNumber()
        cmd = New SqlCommand("SELECT DISTINCT TransactionTypeNumber FROM InventoryTransactionTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "InventoryTransactionTable")
        cboTransactionTypeNumber.DataSource = ds3.Tables("InventoryTransactionTable")
        con.Close()
        cboTransactionTypeNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadTypeDescription()
        cmd = New SqlCommand("SELECT DISTINCT TransactionType FROM InventoryTransactionTable", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "InventoryTransactionTable")
        cboTransType.DataSource = ds4.Tables("InventoryTransactionTable")
        con.Close()
        cboTransType.SelectedIndex = -1
    End Sub

    Private Sub dgvInventoryTransactions_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryTransactions.CellDoubleClick
        Dim RowTransactionTypeNumber As Integer
        Dim RowType As String
        Dim RowIndex As Integer = Me.dgvInventoryTransactions.CurrentCell.RowIndex

        RowTransactionTypeNumber = Me.dgvInventoryTransactions.Rows(RowIndex).Cells("TransactionTypeNumberColumn").Value
        RowType = Me.dgvInventoryTransactions.Rows(RowIndex).Cells("TransactionTypeColumn").Value

        Select Case RowType
            Case "Inventory Adjustment"
                Dim GetBatchNumberStatement As String = "SELECT BatchNumber FROM InventoryAdjustmentTable WHERE AdjustmentNumber = @AdjustmentNumber AND DivisionID = @DivisionID"
                Dim GetBatchNumberCommand As New SqlCommand(GetBatchNumberStatement, con)
                GetBatchNumberCommand.Parameters.Add("@AdjustmentNumber", SqlDbType.VarChar).Value = RowTransactionTypeNumber
                GetBatchNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GlobalInventoryAdjustmentBatchNumber = CInt(GetBatchNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GlobalInventoryAdjustmentBatchNumber = 0
                End Try
                con.Close()

                GlobalDivisionCode = cboDivisionID.Text
                If GlobalInventoryAdjustmentBatchNumber = 0 Then
                    'Do nothing
                Else
                    Using NewPrintInventoryAdjustmentBatch As New PrintInventoryAdjustmentBatch
                        Dim Result = NewPrintInventoryAdjustmentBatch.ShowDialog()
                    End Using
                End If
            Case "Customer Shipment"
                GlobalDivisionCode = cboDivisionID.Text
                GlobalShipmentNumber = RowTransactionTypeNumber

                'Choose the correct Print Form (REMOTE or LOCAL)

                'Get Login Type
                Dim GetLoginType As String = ""

                Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetLoginType = ""
                End Try
                con.Close()

                If GetLoginType = "REMOTE" Then
                    Using NewPrintPackingListRemote As New PrintPackingListRemote
                        Dim Result = NewPrintPackingListRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintPackingList As New PrintPackingList
                        Dim Result = NewPrintPackingList.ShowDialog()
                    End Using
                End If
            Case "Customer Return"
                GlobalDivisionCode = cboDivisionID.Text
                GlobalCustomerReturnNumber = RowTransactionTypeNumber

                'Choose the correct Print Form (REMOTE or LOCAL)

                'Get Login Type
                Dim GetLoginType As String = ""

                Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetLoginType = ""
                End Try
                con.Close()

                If GetLoginType = "REMOTE" Then
                    Using NewPrintCustomerReturnRemote As New PrintCustomerReturnRemote
                        Dim Result = NewPrintCustomerReturnRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintCustomerReturn As New PrintCustomerReturn
                        Dim Result = NewPrintCustomerReturn.ShowDialog()
                    End Using
                End If
            Case "RECEIPT OF GOODS"
                GlobalDivisionCode = cboDivisionID.Text
                GlobalReceiverNumber = RowTransactionTypeNumber

                Using NewPrintReceiver As New PrintReceiver
                    Dim Result = NewPrintReceiver.ShowDialog()
                End Using
            Case "VENDOR RETURN"
                GlobalDivisionCode = cboDivisionID.Text
                GlobalVendorReturnNumber = RowTransactionTypeNumber

                Using NewPrintVendorReturn As New PrintVendorReturn
                    Dim Result = NewPrintVendorReturn.ShowDialog()
                End Using
            Case Else
                'Do nothing
        End Select
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "TWD" Then
            ViewBessemerTransactionsToolStripMenuItem.Enabled = True
            ViewHaywardTransactionsToolStripMenuItem.Enabled = True
            ViewDowneyTransactionsToolStripMenuItem.Enabled = True
            ViewPhoenixTransactionsToolStripMenuItem.Enabled = True
            ViewLewisvilleTransactionsToolStripMenuItem.Enabled = True
            ViewLyndhurstTransactionsToolStripMenuItem.Enabled = True
            ViewSeattleTransactionsToolStripMenuItem.Enabled = True
            ViewRentonTransactionsToolStripMenuItem.Enabled = True
            ViewLakeStevensTransactionsToolStripMenuItem.Enabled = True
        Else
            ViewBessemerTransactionsToolStripMenuItem.Enabled = False
            ViewHaywardTransactionsToolStripMenuItem.Enabled = False
            ViewDowneyTransactionsToolStripMenuItem.Enabled = False
            ViewPhoenixTransactionsToolStripMenuItem.Enabled = False
            ViewLewisvilleTransactionsToolStripMenuItem.Enabled = False
            ViewLyndhurstTransactionsToolStripMenuItem.Enabled = False
            ViewSeattleTransactionsToolStripMenuItem.Enabled = False
            ViewRentonTransactionsToolStripMenuItem.Enabled = False
            ViewLakeStevensTransactionsToolStripMenuItem.Enabled = False
        End If

        LoadPartNumber()
        LoadPartDescription()
        LoadTypeNumber()
        LoadTypeDescription()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearData()
        cboPartNumber.Text = ""
        cboPartDescription.Text = ""
        cboTransactionTypeNumber.Text = ""
        cboGLAccount.Text = ""
        cboGLDescription.Text = ""
        cboTransType.Text = ""

        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboTransactionTypeNumber.SelectedIndex = -1
        cboGLAccount.SelectedIndex = -1
        cboGLDescription.SelectedIndex = -1
        cboTransType.SelectedIndex = -1

        txtInventoryQuantity.Clear()
        txtInventoryValue.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False
        chkinventoryValue.Checked = False
        chkinventoryValue.Visible = True

        lblConsignmentTotals.Visible = False

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        DateFilter = ""
        PartFilter = ""
        TransactionFilter = ""
        GLFilter = ""
        TransactionTypeNumber = 0
        strTransactionNumber = ""
        strBeginDate = ""
        strEndDate = ""
        GlobalShipmentNumber = 0
        GlobalVendorReturnNumber = 0
        GlobalCustomerReturnNumber = 0
        GlobalInventoryAdjustmentBatchNumber = 0
        GlobalReceiverNumber = 0
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub ViewInventoryTransactions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
        ClearVariables()
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        DivisionID = cboDivisionID.Text
        ShowDataByFilter()
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

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintInventoryTransactionsFiltered As New PrintInventoryTransactionsFiltered
            Dim Result = NewPrintInventoryTransactionsFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub GetInventoryValueByConsigment()
        Dim SumQuantityADD As Double = 0
        Dim SumQuantitySUBTRACT As Double = 0
        Dim SumValueADD As Double = 0
        Dim SumValueSUBTRACT As Double = 0
        Dim InventoryValue As Double = 0
        Dim InventoryQuantity As Double = 0

        If cboPartNumber.Text <> "" Then

            'Get Sum of the Adds for Quantity
            Dim SumQuantityADDStatement As String = "SELECT SUM(Quantity) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionDate <= @TransactionDate AND TransactionMath = @TransactionMath"
            Dim SumQuantityADDCommand As New SqlCommand(SumQuantityADDStatement, con)
            SumQuantityADDCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            SumQuantityADDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            SumQuantityADDCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = EndDate
            SumQuantityADDCommand.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumQuantityADD = CDbl(SumQuantityADDCommand.ExecuteScalar)
            Catch ex As Exception
                SumQuantityADD = 0
            End Try
            con.Close()

            'Get Sum of the Subtracts for Quantity
            Dim SumQuantitySUBTRACTStatement As String = "SELECT SUM(Quantity) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionDate <= @TransactionDate AND TransactionMath = @TransactionMath"
            Dim SumQuantitySUBTRACTCommand As New SqlCommand(SumQuantitySUBTRACTStatement, con)
            SumQuantitySUBTRACTCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            SumQuantitySUBTRACTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            SumQuantitySUBTRACTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = EndDate
            SumQuantitySUBTRACTCommand.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumQuantitySUBTRACT = CDbl(SumQuantitySUBTRACTCommand.ExecuteScalar)
            Catch ex As Exception
                SumQuantitySUBTRACT = 0
            End Try
            con.Close()

            'Get Sum of the ADDS for Value
            Dim SumValueADDStatement As String = "SELECT SUM(ExtendedCost) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionDate <= @TransactionDate AND TransactionMath = @TransactionMath"
            Dim SumValueADDCommand As New SqlCommand(SumValueADDStatement, con)
            SumValueADDCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            SumValueADDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            SumValueADDCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = EndDate
            SumValueADDCommand.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumValueADD = CDbl(SumValueADDCommand.ExecuteScalar)
            Catch ex As Exception
                SumValueADD = 0
            End Try
            con.Close()

            'Get Sum of the SUBTRACTS for Value
            Dim SumValueSUBTRACTStatement As String = "SELECT SUM(ExtendedCost) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionDate <= @TransactionDate AND TransactionMath = @TransactionMath"
            Dim SumValueSUBTRACTCommand As New SqlCommand(SumValueSUBTRACTStatement, con)
            SumValueSUBTRACTCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            SumValueSUBTRACTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            SumValueSUBTRACTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = EndDate
            SumValueSUBTRACTCommand.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumValueSUBTRACT = CDbl(SumValueSUBTRACTCommand.ExecuteScalar)
            Catch ex As Exception
                SumValueSUBTRACT = 0
            End Try
            con.Close()

            InventoryQuantity = SumQuantityADD - SumQuantitySUBTRACT
            InventoryQuantity = Math.Round(InventoryQuantity, 2)

            InventoryValue = SumValueADD - SumValueSUBTRACT
            InventoryValue = Math.Round(InventoryValue, 2)

            chkinventoryValue.Visible = False
            lblConsignmentTotals.Visible = True
            lblConsignmentTotals.Text = "Consignment Totals"

            txtInventoryQuantity.Text = InventoryQuantity
            txtInventoryValue.Text = InventoryValue
        Else
            txtInventoryQuantity.Clear()
            txtInventoryValue.Clear()
        End If
    End Sub

    Private Sub chkinventoryValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkinventoryValue.CheckedChanged
        Dim SumQuantityADD As Double = 0
        Dim SumQuantitySUBTRACT As Double = 0
        Dim SumValueADD As Double = 0
        Dim SumValueSUBTRACT As Double = 0
        Dim InventoryValue As Double = 0
        Dim InventoryQuantity As Double = 0

        If chkinventoryValue.Checked = True And cboPartNumber.Text <> "" Then
    
            EndDate = dtpEndDate.Value

            'Get Sum of the Adds for Quantity
            Dim SumQuantityADDStatement As String = "SELECT SUM(Quantity) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionDate <= @TransactionDate AND TransactionMath = @TransactionMath"
            Dim SumQuantityADDCommand As New SqlCommand(SumQuantityADDStatement, con)
            SumQuantityADDCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            SumQuantityADDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SumQuantityADDCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = EndDate
            SumQuantityADDCommand.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumQuantityADD = CDbl(SumQuantityADDCommand.ExecuteScalar)
            Catch ex As Exception
                SumQuantityADD = 0
            End Try
            con.Close()

            'Get Sum of the Subtracts for Quantity
            Dim SumQuantitySUBTRACTStatement As String = "SELECT SUM(Quantity) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionDate <= @TransactionDate AND TransactionMath = @TransactionMath"
            Dim SumQuantitySUBTRACTCommand As New SqlCommand(SumQuantitySUBTRACTStatement, con)
            SumQuantitySUBTRACTCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            SumQuantitySUBTRACTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SumQuantitySUBTRACTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = EndDate
            SumQuantitySUBTRACTCommand.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumQuantitySUBTRACT = CDbl(SumQuantitySUBTRACTCommand.ExecuteScalar)
            Catch ex As Exception
                SumQuantitySUBTRACT = 0
            End Try
            con.Close()

            'Get Sum of the ADDS for Value
            Dim SumValueADDStatement As String = "SELECT SUM(ExtendedCost) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionDate <= @TransactionDate AND TransactionMath = @TransactionMath"
            Dim SumValueADDCommand As New SqlCommand(SumValueADDStatement, con)
            SumValueADDCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            SumValueADDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SumValueADDCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = EndDate
            SumValueADDCommand.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumValueADD = CDbl(SumValueADDCommand.ExecuteScalar)
            Catch ex As Exception
                SumValueADD = 0
            End Try
            con.Close()

            'Get Sum of the SUBTRACTS for Value
            Dim SumValueSUBTRACTStatement As String = "SELECT SUM(ExtendedCost) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionDate <= @TransactionDate AND TransactionMath = @TransactionMath"
            Dim SumValueSUBTRACTCommand As New SqlCommand(SumValueSUBTRACTStatement, con)
            SumValueSUBTRACTCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            SumValueSUBTRACTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SumValueSUBTRACTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = EndDate
            SumValueSUBTRACTCommand.Parameters.Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumValueSUBTRACT = CDbl(SumValueSUBTRACTCommand.ExecuteScalar)
            Catch ex As Exception
                SumValueSUBTRACT = 0
            End Try
            con.Close()

            InventoryQuantity = SumQuantityADD - SumQuantitySUBTRACT
            InventoryQuantity = Math.Round(InventoryQuantity, 2)

            InventoryValue = SumValueADD - SumValueSUBTRACT
            InventoryValue = Math.Round(InventoryValue, 2)

            txtInventoryQuantity.Text = InventoryQuantity
            txtInventoryValue.Text = InventoryValue
        Else
            txtInventoryQuantity.Clear()
            txtInventoryValue.Clear()
        End If
    End Sub

    Private Sub dgvInventoryTransactions_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInventoryTransactions.CellValueChanged
        Dim TransactionNumber As Integer = 0
        Dim GLAccount As String = ""
        Dim ItemCost As Double = 0
        Dim ItemPrice As Double = 0
        Dim Quantity As Double = 0
        Dim ExtendedCost, ExtendedAmount As Double

        If Me.dgvInventoryTransactions.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvInventoryTransactions.CurrentCell.RowIndex

            Try
                TransactionNumber = Me.dgvInventoryTransactions.Rows(RowIndex).Cells("TransactionNumberColumn").Value
            Catch ex As Exception
                TransactionNumber = 0
            End Try
            Try
                GLAccount = Me.dgvInventoryTransactions.Rows(RowIndex).Cells("GLAccountColumn").Value
            Catch ex As Exception
                GLAccount = ""
            End Try
            Try
                Quantity = Me.dgvInventoryTransactions.Rows(RowIndex).Cells("QuantityColumn").Value
            Catch ex As Exception
                Quantity = 0
            End Try
            Try
                ItemCost = Me.dgvInventoryTransactions.Rows(RowIndex).Cells("ItemCostColumn").Value
            Catch ex As Exception
                ItemCost = 0
            End Try
            Try
                ItemPrice = Me.dgvInventoryTransactions.Rows(RowIndex).Cells("ItemPriceColumn").Value
            Catch ex As Exception
                ItemPrice = 0
            End Try
       
            If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                ExtendedCost = ItemCost * Quantity
                ExtendedAmount = ItemPrice * Quantity

                ExtendedCost = Math.Round(ExtendedCost, 2)
                ExtendedAmount = Math.Round(ExtendedAmount, 2)

                'UPDATE Inventory Transactions
                cmd = New SqlCommand("UPDATE InventoryTransactionTable SET Quantity = @Quantity, ItemCost = @ItemCost, ItemPrice = @ItemPrice, ExtendedCost = @ExtendedCost, ExtendedAmount = @ExtendedAmount, GLAccount = @GLAccount WHERE TransactionNumber = @TransactionNumber", con)

                With cmd.Parameters
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                    .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                    .Add("@ItemCost", SqlDbType.VarChar).Value = ItemCost
                    .Add("@ItemPrice", SqlDbType.VarChar).Value = ItemPrice
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = ExtendedCost
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                    .Add("@GLAccount", SqlDbType.VarChar).Value = GLAccount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'Do nothing
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ViewHaywardTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewHaywardTransactionsToolStripMenuItem.Click
        DivisionID = "HCW"
        ShowDataByFilter()
        GetInventoryValueByConsigment()
    End Sub

    Private Sub ViewDowneyTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewDowneyTransactionsToolStripMenuItem.Click
        DivisionID = "DCW"
        ShowDataByFilter()
        GetInventoryValueByConsigment()
    End Sub

    Private Sub ViewPhoenixTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewPhoenixTransactionsToolStripMenuItem.Click
        DivisionID = "PCW"
        ShowDataByFilter()
        GetInventoryValueByConsigment()
    End Sub

    Private Sub ViewLyndhurstTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLyndhurstTransactionsToolStripMenuItem.Click
        DivisionID = "YCW"
        ShowDataByFilter()
        GetInventoryValueByConsigment()
    End Sub

    Private Sub ViewLewisvilleTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLewisvilleTransactionsToolStripMenuItem.Click
        DivisionID = "LCW"
        ShowDataByFilter()
        GetInventoryValueByConsigment()
    End Sub

    Private Sub ViewSeattleTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewSeattleTransactionsToolStripMenuItem.Click
        DivisionID = "SCW"
        ShowDataByFilter()
        GetInventoryValueByConsigment()
    End Sub

    Private Sub ViewBessemerTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewBessemerTransactionsToolStripMenuItem.Click
        DivisionID = "BCW"
        ShowDataByFilter()
        GetInventoryValueByConsigment()
    End Sub

    Private Sub ViewRentonTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewRentonTransactionsToolStripMenuItem.Click
        DivisionID = "RCW"
        ShowDataByFilter()
        GetInventoryValueByConsigment()
    End Sub

    Private Sub ViewLakeStevensTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLakeStevensTransactionsToolStripMenuItem.Click
        DivisionID = "LSCW"
        ShowDataByFilter()
        GetInventoryValueByConsigment()
    End Sub
End Class