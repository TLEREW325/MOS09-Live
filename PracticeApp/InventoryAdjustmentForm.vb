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
Public Class InventoryAdjustmentForm
    Inherits System.Windows.Forms.Form

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer

    Dim FormName As String = "Inventory Adjustment"
    Dim NextCostingTransactionNumber, LastCostingTransactionNumber, AdjustmentItems, NextInventoryTransactionNumber, LastInventoryTransactionNumber, LastBatchNumber, NextBatchNumber, counter, LastTransactionNumber, NextTransactionNumber, NextGLNumber, LastGLNumber As Integer
    Dim AdjustmentTotal, GLCreditAmount, GLDebitAmount, Quantity, Cost, Total, StandardCost As Double
    Dim AdjustmentStatus, GetSerialStatus, GetPurchProdLineID, GetItemClass, CheckItemClass, AdjustmentComment, CurrentPartNumber, PreferredVendor, VendorClass, GLAdjustmentDescription, GLInventoryAccount, GLAdjustmentAccount, ItemClass, BatchStatus, PartNumber, Description, Reason, LongDescription As String
    Dim QuantityOnHand, FIFOCost, BatchCost, TotalBatchCost, LaborRate, OverheadRate As Double
    Dim AdjustmentDate, BatchDate As Date
    Dim RunningSerialCount As Integer = 0
    Dim PrintDate As String = ""
    Dim TodaysDate As Date = Today.ToShortDateString

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim isLoaded = False
    Dim lastBatch As String = ""

    Private Sub InventoryAdjustmentForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()

        'Form Login
        FormLoginRoutine()

        LoadCurrentDivision()

        usefulFunctions.LoadSecurity(Me)

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            Me.dgvAdjustmentLines.Columns("CostColumn").ReadOnly = False
        End If

        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "SLC" Then
            cmdAddSerialNumber.Enabled = True
            txtSerialNumber.Enabled = True
        Else
            cmdAddSerialNumber.Enabled = False
            txtSerialNumber.Enabled = False
        End If

        isLoaded = True
    End Sub

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), &HF060, 1)
            Case &HFFFFFFFF
        End Select
    End Sub

    Private Sub InventoryAdjustmentForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Public Sub FormLoginRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LoginTime", SqlDbType.VarChar).Value = strTodaysTime
            .Add("@LogoutDate", SqlDbType.VarChar).Value = ""
            .Add("@LogoutTime", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub FormLogoutRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = ""
            .Add("@LoginTime", SqlDbType.VarChar).Value = ""
            .Add("@LogoutDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LogoutTime", SqlDbType.VarChar).Value = strTodaysTime
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
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

    Private Sub InventoryAdjustmentForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearVariables()
        ClearAll()
        unlockBatch()
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvAdjustmentLines.CellValueChanged
        If isLoaded Then
            If isSomeoneEditing() Then
                Exit Sub
            End If

            LockBatch()

            Dim LineQuantity, LineExtendedAmount, LineUnitCost As Double
            Dim LineNumber As Integer = 0
            Dim LineReason, LineInventoryAccount, LineAdjustmentAccount As String
            Dim LineStatus As String = ""
            Dim LineComment As String = ""
            Dim LineStatusCount As Integer = 0
            Dim TotalLineStatusCount As Integer = 0

            Dim currentRow As Integer = dgvAdjustmentLines.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvAdjustmentLines.CurrentCell.ColumnIndex

            If dgvAdjustmentLines.Rows(currentRow).Cells("StatusColumn").Value <> "POSTED" Then
                'UPDATE Line Table on changes in the datagrid
                If IsDBNull(dgvAdjustmentLines.Rows(currentRow).Cells("CostColumn").Value) Then
                    LineUnitCost = 0
                Else
                    LineUnitCost = dgvAdjustmentLines.Rows(currentRow).Cells("CostColumn").Value
                End If
                If IsDBNull(dgvAdjustmentLines.Rows(currentRow).Cells("QuantityColumn").Value) Then
                    LineQuantity = 0
                Else
                    LineQuantity = dgvAdjustmentLines.Rows(currentRow).Cells("QuantityColumn").Value
                End If
                If IsDBNull(dgvAdjustmentLines.Rows(currentRow).Cells("AdjustmentNumberColumn").Value) Then
                    LineNumber = 0
                Else
                    LineNumber = dgvAdjustmentLines.Rows(currentRow).Cells("AdjustmentNumberColumn").Value
                End If
                If IsDBNull(dgvAdjustmentLines.Rows(currentRow).Cells("ReasonColumn").Value) Then
                    LineReason = ""
                Else
                    LineReason = dgvAdjustmentLines.Rows(currentRow).Cells("ReasonColumn").Value
                End If
                If IsDBNull(dgvAdjustmentLines.Rows(currentRow).Cells("LineCommentColumn").Value) Then
                    LineComment = ""
                Else
                    LineComment = dgvAdjustmentLines.Rows(currentRow).Cells("LineCommentColumn").Value
                End If
                If IsDBNull(dgvAdjustmentLines.Rows(currentRow).Cells("AdjustmentAccountColumn").Value) Then
                    LineAdjustmentAccount = "59790"
                Else
                    LineAdjustmentAccount = dgvAdjustmentLines.Rows(currentRow).Cells("AdjustmentAccountColumn").Value
                End If
                If IsDBNull(dgvAdjustmentLines.Rows(currentRow).Cells("InventoryAccountColumn").Value) Then
                    LineInventoryAccount = "12100"
                Else
                    LineInventoryAccount = dgvAdjustmentLines.Rows(currentRow).Cells("InventoryAccountColumn").Value
                End If

                LineExtendedAmount = LineUnitCost * LineQuantity
                LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

                Try
                    'UPDATE Inventory Adjustment Table on line changes
                    cmd = New SqlCommand("UPDATE InventoryAdjustmentTable SET Cost = @Cost, Quantity = @Quantity, Total = @Total, Reason = @Reason, InventoryAccount = @InventoryAccount, AdjustmentAccount = @AdjustmentAccount, LineComment = @LineComment WHERE AdjustmentNumber = @AdjustmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@AdjustmentNumber", SqlDbType.VarChar).Value = LineNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Cost", SqlDbType.VarChar).Value = LineUnitCost
                        .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                        .Add("@Total", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@Reason", SqlDbType.VarChar).Value = LineReason
                        .Add("@InventoryAccount", SqlDbType.VarChar).Value = LineInventoryAccount
                        .Add("@AdjustmentAccount", SqlDbType.VarChar).Value = LineAdjustmentAccount
                        .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempAdjustmentNumber As Integer = 0
                    Dim strAdjustmentNumber As String
                    TempAdjustmentNumber = Val(cboBatchNumber.Text)
                    strAdjustmentNumber = CStr(TempAdjustmentNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Adjustment --- Datagrid Update Failure"
                    ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                LoadBatchTotals()
                ShowData()

                'resets the selected cell back to what was changed
                dgvAdjustmentLines.CurrentCell = dgvAdjustmentLines.Rows(currentRow).Cells(currentColumn)
            End If
        End If
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryAdjustmentTable")
        dgvAdjustmentLines.DataSource = ds.Tables("InventoryAdjustmentTable")
        cboDeleteLine.DataSource = ds.Tables("InventoryAdjustmentTable")
        con.Close()

        If Me.dgvAdjustmentLines.RowCount > 0 Then
            cboDivisionID.Enabled = False
        End If
    End Sub


    'Load Control Datasource

    Public Sub LoadItemList()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass Order By ItemID", con)
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

    Public Sub LoadItemDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ItemList")
        cboPartDescription.DataSource = ds5.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadInventoryTransactionNumber()
        cmd = New SqlCommand("SELECT AdjustmentNumber FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber AND Status <> 'POSTED' ORDER BY AdjustmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "InventoryAdjustmentTable")
        cboAdjustmentNumber.DataSource = ds2.Tables("InventoryAdjustmentTable")
        con.Close()
        cboAdjustmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBatchNumber()
        cmd = New SqlCommand("SELECT DISTINCT(BatchNumber) FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID AND Status <> 'POSTED' ORDER BY BatchNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "InventoryAdjustmentTable")
        cboBatchNumber.DataSource = ds3.Tables("InventoryAdjustmentTable")
        con.Close()
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccount()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber < @GLAccountNumber", con)
        cmd.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "GLAccounts")
        cboGLAccountNumber.DataSource = ds4.Tables("GLAccounts")
        cboAccountDescription.DataSource = ds4.Tables("GLAccounts")
        con.Close()
        cboGLAccountNumber.SelectedIndex = -1
        cboAccountDescription.SelectedIndex = -1
    End Sub

    Public Sub ShowSerialLines()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialTempTable WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "AssemblySerialTempTable")
        dgvTempSerialLines.DataSource = ds5.Tables("AssemblySerialTempTable")
        con.Close()
    End Sub


    'Clear Routines

    Public Sub ClearSerialLines()
        dgvTempSerialLines.DataSource = Nothing
    End Sub

    Public Sub ClearLines()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboAdjustmentNumber.SelectedIndex = -1
        cboAccountDescription.SelectedIndex = -1
        cboGLAccountNumber.SelectedIndex = -1
        cboAdjustmentNumber.Text = ""

        txtCost.Clear()
        txtLineTotal.Clear()
        txtQuantity.Clear()
        txtLineComment.Clear()
        txtItemClass.Clear()
        txtInventoryAccount.Clear()
        txtLongDescription.Clear()
        txtSerialNumber.Clear()

        lblQOH.Text = ""

        If cmdGenerateNewAdjustmentNumber.Enabled = False Then
            cmdGenerateNewAdjustmentNumber.Enabled = True
        End If

        cmdGenerateNewAdjustmentNumber.Focus()
    End Sub

    Public Sub ClearAll()
        cboBatchNumber.Text = ""
        cboAdjustmentNumber.Text = ""

        cboAdjustmentNumber.Refresh()
        cboPartDescription.Refresh()
        cboPartNumber.Refresh()
        cboBatchNumber.Refresh()
        cboAccountDescription.Refresh()
        cboGLAccountNumber.Refresh()

        txtLongDescription.Refresh()
        txtQuantity.Refresh()
        txtReason.Refresh()
        txtBatchItems.Refresh()
        txtBatchNumber.Refresh()
        txtCost.Refresh()
        txtLineTotal.Refresh()
        txtBatchStatus.Refresh()
        txtItemClass.Refresh()
        txtInventoryAccount.Refresh()
        txtLineComment.Refresh()

        cboAdjustmentNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboBatchNumber.SelectedIndex = -1
        cboAccountDescription.SelectedIndex = -1
        cboGLAccountNumber.SelectedIndex = -1
        cboDeleteLine.Text = ""

        dtpAdjustmentDate.Text = ""

        txtLongDescription.Clear()
        txtQuantity.Clear()
        txtReason.Clear()
        txtBatchItems.Clear()
        txtBatchNumber.Clear()
        txtBatchTotal.Clear()
        txtCost.Clear()
        txtLineTotal.Clear()
        txtBatchStatus.Clear()
        txtItemClass.Clear()
        txtInventoryAccount.Clear()
        txtSerialNumber.Clear()
        txtLineComment.Clear()

        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "SLC" Then
            txtSerialNumber.Enabled = True
        Else
            txtSerialNumber.Enabled = False
        End If

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            cboDivisionID.Enabled = True
        End If

        lblQOH.Text = ""

        If BatchStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdEnter.Enabled = False
            cmdPostAdjustment.Enabled = False
            cmdSave.Enabled = False
            SaveDataToolStripMenuItem.Enabled = False
            DeleteDataToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnter.Enabled = True
            cmdPostAdjustment.Enabled = True
            cmdSave.Enabled = True
            SaveDataToolStripMenuItem.Enabled = True
            DeleteDataToolStripMenuItem.Enabled = True
        End If

        cmdBatchNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        NextInventoryTransactionNumber = 0
        LastInventoryTransactionNumber = 0
        NextCostingTransactionNumber = 0
        LastCostingTransactionNumber = 0
        LastBatchNumber = 0
        NextBatchNumber = 0
        counter = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        NextGLNumber = 0
        LastGLNumber = 0
        GLCreditAmount = 0
        GLDebitAmount = 0
        Quantity = 0
        Cost = 0
        Total = 0
        StandardCost = 0
        PartNumber = ""
        Description = ""
        Reason = ""
        LongDescription = ""
        BatchStatus = ""
        FIFOCost = 0
        ItemClass = ""
        GLInventoryAccount = ""
        GLAdjustmentAccount = ""
        OverheadRate = 0
        LaborRate = 0
        BatchCost = 0
        TotalBatchCost = 0
        GLAdjustmentDescription = ""
        PreferredVendor = ""
        VendorClass = ""
        CurrentPartNumber = ""
        AdjustmentComment = ""
        QuantityOnHand = 0
        GetItemClass = ""
        CheckItemClass = ""
        lastBatch = ""
        GetSerialStatus = ""
        GetPurchProdLineID = ""
        RunningSerialCount = 0

        If BatchStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdEnter.Enabled = False
            cmdPostAdjustment.Enabled = False
            cmdSave.Enabled = False
            SaveDataToolStripMenuItem.Enabled = False
            DeleteDataToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnter.Enabled = True
            cmdPostAdjustment.Enabled = True
            cmdSave.Enabled = True
            SaveDataToolStripMenuItem.Enabled = True
            DeleteDataToolStripMenuItem.Enabled = True
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvAdjustmentLines.DataSource = Nothing
    End Sub


    'Load Data Routines

    Public Sub LoadBatchTotals()
        Dim AdjustmentTotalStatement As String = "SELECT SUM(Total), COUNT(AdjustmentNumber), MAX(AdjustmentDate) FROM InventoryAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim AdjustmentTotalCommand As New SqlCommand(AdjustmentTotalStatement, con)
        AdjustmentTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        AdjustmentTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = AdjustmentTotalCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.GetValue(0)) Then
                AdjustmentTotal = 0
            Else
                AdjustmentTotal = reader.GetValue(0)
            End If
            If IsDBNull(reader.GetValue(1)) Then
                AdjustmentItems = 0
            Else
                AdjustmentItems = reader.GetValue(1)
            End If
            If IsDBNull(reader.GetValue(2)) Then
                BatchDate = dtpAdjustmentDate.Value
            Else
                BatchDate = reader.GetValue(2)
            End If
        Else
            AdjustmentTotal = 0
            AdjustmentItems = 0
            BatchDate = dtpAdjustmentDate.Value
        End If
        reader.Close()
        con.Close()

        txtBatchTotal.Text = FormatCurrency(AdjustmentTotal, 2)
        txtBatchItems.Text = AdjustmentItems
        txtBatchNumber.Text = cboBatchNumber.Text
        dtpAdjustmentDate.Text = BatchDate
    End Sub

    Public Sub LoadQOH()
        Dim QOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim QOHCommand As New SqlCommand(QOHStatement, con)
        QOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        QOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QuantityOnHand = CDbl(QOHCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityOnHand = 0
        End Try
        con.Close()

        lblQOH.Text = FormatNumber(QuantityOnHand, 2)
    End Sub

    Public Sub LoadPurchaseProductLine()
        Dim CheckSerializedStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CheckSerializedCommand As New SqlCommand(CheckSerializedStatement, con)
        CheckSerializedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CheckSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetPurchProdLineID = CStr(CheckSerializedCommand.ExecuteScalar)
        Catch ex As Exception
            GetPurchProdLineID = ""
        End Try
        con.Close()
    End Sub

    Public Sub LoadSerialStatus()
        Dim CheckSerializedStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
        Dim CheckSerializedCommand As New SqlCommand(CheckSerializedStatement, con)
        CheckSerializedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        CheckSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSerialStatus = CStr(CheckSerializedCommand.ExecuteScalar)
        Catch ex As Exception
            GetSerialStatus = "NO"
        End Try
        con.Close()
    End Sub

    Public Sub LoadAdjustmentData()
        Dim GetAdjustmentDataStatement As String = "SELECT * FROM InventoryAdjustmentTable WHERE AdjustmentNumber = @AdjustmentNumber AND DivisionID = @DivisionID"
        Dim GetAdjustmentDataCommand As New SqlCommand(GetAdjustmentDataStatement, con)
        GetAdjustmentDataCommand.Parameters.Add("@AdjustmentNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
        GetAdjustmentDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetAdjustmentDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("Description")) Then
                Description = ""
            Else
                Description = reader.Item("Description")
            End If
            If IsDBNull(reader.Item("Quantity")) Then
                Quantity = 0
            Else
                Quantity = reader.Item("Quantity")
            End If
            If IsDBNull(reader.Item("Cost")) Then
                Cost = 0
            Else
                Cost = reader.Item("Cost")
            End If
            If IsDBNull(reader.Item("Total")) Then
                Total = 0
            Else
                Total = reader.Item("Total")
            End If
            If IsDBNull(reader.Item("Reason")) Then
                Reason = ""
            Else
                Reason = reader.Item("Reason")
            End If
        Else
            PartNumber = ""
            Description = ""
            Quantity = 0
            Cost = 0
            Total = 0
            Reason = ""
        End If
        reader.Close()
        con.Close()

        cboPartNumber.Text = PartNumber
        cboPartDescription.Text = Description
        txtQuantity.Text = Quantity
        txtCost.Text = Cost
        txtLineTotal.Text = Total
        txtReason.Text = Reason
    End Sub

    Public Sub LoadPartData()
        Dim LongDescriptionStatement As String = "SELECT LongDescription, ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LongDescriptionCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LongDescription")) Then
                LongDescription = ""
            Else
                LongDescription = reader.Item("LongDescription")
            End If
            If IsDBNull(reader.Item("ItemClass")) Then
                ItemClass = ""
            Else
                ItemClass = reader.Item("ItemClass")
            End If
        Else
            LongDescription = ""
            ItemClass = ""
        End If
        reader.Close()
        con.Close()

        txtLongDescription.Text = LongDescription
        txtItemClass.Text = ItemClass

        Dim CreditGLAccountStatement As String = "SELECT GLInventoryAccount, GLAdjustmentAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim CreditGLAccountCommand As New SqlCommand(CreditGLAccountStatement, con)
        CreditGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

        If con.State = ConnectionState.Closed Then con.Open()
        reader = CreditGLAccountCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("GLInventoryAccount")) Then
                GLInventoryAccount = ""
            Else
                GLInventoryAccount = reader.Item("GLInventoryAccount")
            End If
            If IsDBNull(reader.Item("GLAdjustmentAccount")) Then
                GLAdjustmentAccount = ""
            Else
                GLAdjustmentAccount = reader.Item("GLAdjustmentAccount")
            End If
        Else
            GLInventoryAccount = ""
            GLAdjustmentAccount = ""
        End If
        reader.Close()
        con.Close()

        txtInventoryAccount.Text = GLInventoryAccount
        cboGLAccountNumber.Text = GLAdjustmentAccount
    End Sub

    Public Sub LoadPreferredVendor()
        Dim PreferredVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PreferredVendorCommand As New SqlCommand(PreferredVendorStatement, con)
        PreferredVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = CurrentPartNumber
        PreferredVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PreferredVendor = CStr(PreferredVendorCommand.ExecuteScalar)
        Catch ex As Exception
            PreferredVendor = ""
        End Try
        con.Close()

        If PreferredVendor = "CANADIAN" Then
            VendorClass = "CANADIAN"
        ElseIf PreferredVendor = "AMERICAN" Then
            VendorClass = "AMERICAN"
        Else
            Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
            VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = PreferredVendor
            VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VendorClass = CStr(VendorClassCommand.ExecuteScalar)
            Catch ex As Exception
                VendorClass = "CANADIAN"
            End Try
            con.Close()
        End If
    End Sub

    Public Sub LoadFIFOCost()
        Dim TotalQuantityShipped As Double = 0
        Dim TransactionCost As Double = 0
        Dim MaxCost As Integer = 0
        Dim GetMaxTransactionNumber As Integer = 0
        Dim GetUpperLimit As Double = 0
        '******************************************************************************************************************************************
        'Determine Total Quantity Shipped
        Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> @Dropship AND LineStatus <> @LineStatus"
        Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
        TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalQuantityShippedCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text
        TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"
        TotalQuantityShippedCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalQuantityShipped = 0
        End Try
        con.Close()
        '******************************************************************************************************************************************
        'Add Total Quantity used in assemblies
        Dim GetBuildQuantity As Double = 0

        Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
        Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
        TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetBuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            GetBuildQuantity = 0
        End Try
        con.Close()

        GetBuildQuantity = GetBuildQuantity * -1

        TotalQuantityShipped = TotalQuantityShipped + GetBuildQuantity
        '******************************************************************************************************************************************
        'Check to see if Total Quantity Shipped falls within the Cost Tiers
        Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
        Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
        GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpAdjustmentDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetMaxTransactionNumber = CInt(GetMaxTransactionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetMaxTransactionNumber = 0
        End Try
        con.Close()

        Dim GetUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
        Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitStatement, con)
        GetUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber
        GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
        Catch ex As Exception
            GetUpperLimit = 0
        End Try
        con.Close()

        If TotalQuantityShipped = 0 Then
            TotalQuantityShipped = 1
        Else
            TotalQuantityShipped = TotalQuantityShipped + 1
        End If

        If TotalQuantityShipped < GetUpperLimit Then
            'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
            Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
            Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
            ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
            'ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FIFOCost = CDbl(ItemCostCommand.ExecuteScalar)
            Catch ex As Exception
                FIFOCost = 0
            End Try
            con.Close()
        Else
            FIFOCost = 0
        End If
        '*****************************************************************************************************************************************
        If FIFOCost = 0 Then
            'Select Last Transaction
            Dim MaxCostStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim MaxCostCommand As New SqlCommand(MaxCostStatement, con)
            MaxCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            MaxCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxCost = CInt(MaxCostCommand.ExecuteScalar)
            Catch ex As Exception
                MaxCost = 0
            End Try
            con.Close()

            'Load Last Transaction Cost if FIFO = 0
            Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber =  @MaxCost"
            Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
            TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TransactionCostCommand.Parameters.Add("@MaxCost", SqlDbType.VarChar).Value = MaxCost

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
            Catch ex As Exception
                TransactionCost = 0
            End Try
            con.Close()

            FIFOCost = TransactionCost
        End If
        '*****************************************************************************************************************************************
        If FIFOCost = 0 Then
            Dim LastPurchaseCost As Double = 0
            Dim MaxDate As Integer = 0

            Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastPurchaseCost = 0
            End Try
            con.Close()

            FIFOCost = LastPurchaseCost
        End If
        '*****************************************************************************************************************************************
        'Load Standard Unit Cost if Transaction Cost = 0
        If FIFOCost = 0 Then
            'Select Last Transaction
            Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
            StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
            Catch ex As Exception
                StandardCost = 0
            End Try
            con.Close()

            FIFOCost = StandardCost
        End If
        '*****************************************************************************************************************************************
        txtCost.Text = FIFOCost
    End Sub

    Public Sub LoadBatchCost()
        'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
        Dim BatchCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim BatchCostCommand As New SqlCommand(BatchCostStatement, con)
        BatchCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = "Batch Mix"
        BatchCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchCost = CDbl(BatchCostCommand.ExecuteScalar)
        Catch ex As Exception
            BatchCost = 0
        End Try
        con.Close()

        'Add Overhead and Labor
        LaborRate = 0.38
        OverheadRate = 0.38 * 0.75
        TotalBatchCost = BatchCost + LaborRate + OverheadRate

        txtCost.Text = TotalBatchCost
    End Sub

    Public Sub LoadBatchStatus()
        Dim BatchStatusStatement As String = "SELECT COUNT(AdjustmentNumber) FROM InventoryAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND Status <> 'OPEN'"
        Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
        BatchStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim pst As Integer = 0
        Try
            pst = BatchStatusCommand.ExecuteScalar
        Catch ex As Exception
            pst = 0
        End Try
        con.Close()

        If pst > 0 Then
            BatchStatus = "POSTED"
        Else
            BatchStatus = "OPEN"
        End If

        txtBatchStatus.Text = BatchStatus

        If BatchStatus = "POSTED" Then
            cmdDelete.Enabled = False
            cmdEnter.Enabled = False
            cmdPostAdjustment.Enabled = False
            cmdSave.Enabled = False
            SaveDataToolStripMenuItem.Enabled = False
            DeleteDataToolStripMenuItem.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdEnter.Enabled = True
            cmdPostAdjustment.Enabled = True
            cmdSave.Enabled = True
            SaveDataToolStripMenuItem.Enabled = True
            DeleteDataToolStripMenuItem.Enabled = True
        End If
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

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadPartNumberByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
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


    'Text/Combo Box Text Changed Events

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        If isLoaded Then
            Quantity = Val(txtQuantity.Text)
            Cost = Val(txtCost.Text)
            Total = Quantity * Cost
            txtLineTotal.Text = FormatCurrency(Total, 2)

            If (Quantity = 1 Or Quantity = -1) And cboPartNumber.Text <> "" And (cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "SLC") Then
                'Check to see it it is an assembly
                LoadPurchaseProductLine()

                'Check to see if it is serialized
                If GetPurchProdLineID = "ASSEMBLY" Then
                    LoadSerialStatus()

                    If GetSerialStatus = "YES" Then
                        txtSerialNumber.Enabled = True
                    Else
                        txtSerialNumber.Enabled = False
                    End If
                Else
                    txtSerialNumber.Enabled = False
                End If
            Else
                txtSerialNumber.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCost.TextChanged
        If isLoaded Then
            Quantity = Val(txtQuantity.Text)
            Cost = Val(txtCost.Text)
            Total = Quantity * Cost
            txtLineTotal.Text = FormatCurrency(Total, 2)
        End If
    End Sub

    Private Sub cboAdjustmentNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdjustmentNumber.SelectedIndexChanged
        If isLoaded Then
            isLoaded = False
            LoadAdjustmentData()
            LoadQOH()
            LoadPartData()
            isLoaded = True
        End If
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If isLoaded Then
            LoadPartData()
            LoadQOH()
            LoadPartDescriptionByPartNumber()

            If cboPartNumber.Text = "Batch Mix" And cboDivisionID.Text = "CHT" Then
                LoadBatchCost()
            Else
                LoadFIFOCost()
            End If

            If cmdGenerateNewAdjustmentNumber.Enabled = False Then
                cmdGenerateNewAdjustmentNumber.Enabled = True
            End If
        End If
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        If cmdGenerateNewAdjustmentNumber.Enabled = False Then
            cmdGenerateNewAdjustmentNumber.Enabled = True
        End If

        LoadPartNumberByDescription()
    End Sub

    Private Sub cboGLAccountNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGLAccountNumber.SelectedIndexChanged
        Dim GLAdjustmentDescriptionStatement As String = "SELECT GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim GLAdjustmentDescriptionCommand As New SqlCommand(GLAdjustmentDescriptionStatement, con)
        GLAdjustmentDescriptionCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
        Try
            GLAdjustmentDescription = CStr(GLAdjustmentDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            GLAdjustmentDescription = ""
        End Try
        con.Close()

        cboAccountDescription.Text = GLAdjustmentDescription
    End Sub

    Private Sub cboBatchNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBatchNumber.SelectedIndexChanged
        If isLoaded Then
            unlockBatch(lastBatch)
            isLoaded = False
            LoadInventoryTransactionNumber()
            LoadBatchStatus()
            LoadBatchTotals()
            ShowData()
            ShowSerialLines()
            isLoaded = True
            lastBatch = cboBatchNumber.Text
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadBatchNumber()
        LoadItemList()
        LoadItemDescription()
        LoadGLAccount()
        ShowData()
        ClearVariables()
        ClearAll()
    End Sub


    'Functions and Save Routine

    Private Function canAddAdjustmentLine() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must select a batch number", "Select a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        If cboBatchNumber.SelectedIndex = -1 Or Val(cboBatchNumber.Text) = 0 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        If cboAdjustmentNumber.SelectedIndex = -1 Or Val(cboAdjustmentNumber.Text) = 0 Then
            MessageBox.Show("You must enter a valid adjustment number", "Enter a valid adjustment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentNumber.SelectAll()
            cboAdjustmentNumber.Focus()
            Return False
        End If
        If cboPartNumber.SelectedIndex = -1 Or cboPartNumber.Text = "" Then
            MessageBox.Show("You must have a valid part number selected", "Select a valid part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartNumber.SelectAll()
            cboPartNumber.Focus()
            Return False
        End If
        If txtQuantity.Text = "0" Or String.IsNullOrEmpty(txtQuantity.Text) Then
            MessageBox.Show("You must enter a quantity", "Enter a quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.SelectAll()
            txtQuantity.Focus()
            Return False
        End If
        If IsNumeric(txtCost.Text) = False Then
            MessageBox.Show("You must enter a valid cost", "Enter a valid cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCost.SelectAll()
            txtCost.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canPost() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MsgBox("You must have a valid Batch Number selected.", MsgBoxStyle.OkOnly)
        End If
        If cboBatchNumber.SelectedIndex = -1 Or Val(cboBatchNumber.Text) = 0 Then
            MessageBox.Show("You must enter a valid Batch Number", "Enter a valid Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        If dgvAdjustmentLines.Rows.Count = 0 Then
            MessageBox.Show("You can't post an adjustment with no lines", "Unable to post", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAdjustmentNumber.Focus()
            Return False
        End If
        If isPosted() Then
            MessageBox.Show("One or more lines is already posted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        'Prompt before Posting
        Dim button As DialogResult = MessageBox.Show("Do you wish to post all of the adjustments in the GRID?", "POST INVENTORY ADJUSTMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Function isPosted() As Boolean
        For i As Integer = 0 To dgvAdjustmentLines.Rows.Count - 1
            If dgvAdjustmentLines.Rows(i).Cells("StatusColumn").Value = "POSTED" Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must select a batch number", "Select a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If cboBatchNumber.SelectedIndex = -1 Or Val(cboBatchNumber.Text) = 0 Then
            MessageBox.Show("You must enter a valid batch number", "Enter a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If

        If isSomeoneEditing() Then
            Return False
        End If

        'Prompt before Saving
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this Adjustment?", "SAVE INVENTORY ADJUSTMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Function canDeleteBatch() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must select a batch to delete", "Select a batch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If cboBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid batch number", "Select a valid batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        LoadBatchStatus()
        If txtBatchStatus.Text = "POSTED" Then
            MessageBox.Show("Batch has already been posted, you can't delete it", "Can't delete batch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        'Prompt before Saving
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this entire Batch?", "DELETE INVENTORY ADJUSTMENT BATCH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub UpdateInventoryAdjustmentTable()
        'Write Data to Inventory Adjustment Header Database Table
        cmd = New SqlCommand("UPDATE InventoryAdjustmentTable SET AdjustmentDate = @AdjustmentDate, DivisionID = @DivisionID, PartNumber = @PartNumber, Description = @Description, Reason = @Reason, Quantity = @Quantity, Cost = @Cost, Total = @Total, Status = @Status, BatchNumber = @BatchNumber, InventoryAccount = @InventoryAccount, AdjustmentAccount = @AdjustmentAccount, LineComment = @LineComment, AdjustmentAgent = @AdjustmentAgent WHERE AdjustmentNumber = @AdjustmentNumber", con)

        With cmd.Parameters
            .Add("@AdjustmentNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
            .Add("@AdjustmentDate", SqlDbType.VarChar).Value = AdjustmentDate
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@Description", SqlDbType.VarChar).Value = cboPartDescription.Text
            .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
            .Add("@Cost", SqlDbType.VarChar).Value = Val(txtCost.Text)
            .Add("@Total", SqlDbType.VarChar).Value = Total
            .Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text
            .Add("@Status", SqlDbType.VarChar).Value = AdjustmentStatus
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@InventoryAccount", SqlDbType.VarChar).Value = txtInventoryAccount.Text
            .Add("@AdjustmentAccount", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
            .Add("@AdjustmentAgent", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = PrintDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub InsertIntoInventoryAdjustmentTable()
        'Write Data to Inventory Adjustment Header Database Table
        cmd = New SqlCommand("Insert Into InventoryAdjustmentTable(AdjustmentNumber, AdjustmentDate, DivisionID, PartNumber, Description, Reason, Quantity, Cost, Total, Status, BatchNumber, InventoryAccount, AdjustmentAccount, LineComment, AdjustmentAgent, PrintDate)Values(@AdjustmentNumber, @AdjustmentDate, @DivisionID, @PartNumber, @Description, @Reason, @Quantity, @Cost, @Total, @Status, @BatchNumber, @InventoryAccount, @AdjustmentAccount, @LineComment, @AdjustmentAgent, @PrintDate)", con)

        With cmd.Parameters
            .Add("@AdjustmentNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
            .Add("@AdjustmentDate", SqlDbType.VarChar).Value = AdjustmentDate
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@Description", SqlDbType.VarChar).Value = cboPartDescription.Text
            .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
            .Add("@Cost", SqlDbType.VarChar).Value = Val(txtCost.Text)
            .Add("@Total", SqlDbType.VarChar).Value = Total
            .Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text
            .Add("@Status", SqlDbType.VarChar).Value = AdjustmentStatus
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            .Add("@InventoryAccount", SqlDbType.VarChar).Value = txtInventoryAccount.Text
            .Add("@AdjustmentAccount", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
            .Add("@AdjustmentAgent", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
            .Add("@PrintDate", SqlDbType.VarChar).Value = PrintDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Function canExit() As Boolean
        If String.IsNullOrEmpty(cboAdjustmentNumber.Text) Then
            Return False
        End If
        If BatchStatus = "POSTED" Then
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        Return True
    End Function

    Private Function isSomeoneEditing() As Boolean
        cmd = New SqlCommand("SELECT Locked FROM InventoryAdjustmentBatchNumbers WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim personEditing As String = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.GetValue(0)) Then
                personEditing = reader.GetValue(0)
            End If
        End If
        reader.Close()
        con.Close()

        If Not personEditing.Equals("NONE") And Not String.IsNullOrEmpty(personEditing) Then
            If Not personEditing.Equals(EmployeeLoginName) Then
                MessageBox.Show(personEditing + " is currently editing this batch. You are unable to make any changes.", "Unable to save/Post", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadInventoryTransactionNumber()
                LoadBatchStatus()
                LoadBatchTotals()
                ShowData()
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub LockBatch()
        cmd = New SqlCommand("UPDATE InventoryAdjustmentBatchNumbers SET Locked = @Locked WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE InventoryAdjustmentBatchNumbers SET Locked = '' WHERE BatchNumber = @BatchNumber AND Locked = @Locked", con)
        If batch.Equals("none") Then
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
        Else
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = batch
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub


    'Tool Strip Menu Items

    Private Sub PrintDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintDataToolStripMenuItem.Click
        GlobalInventoryAdjustmentBatchNumber = Val(cboBatchNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintInventoryAdjustmentBatch As New PrintInventoryAdjustmentBatch
            Dim result = NewPrintInventoryAdjustmentBatch.ShowDialog()
        End Using
    End Sub

    Private Sub SaveDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDataToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub UnLockBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockBatchToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this batch?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE InventoryAdjustmentBatchNumbers SET Locked = '' WHERE BatchNumber = @BatchNumber", con)
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Batch is now un-locked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You must enter a batch number to un-lock", "Enter a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
        End If
    End Sub

    Private Sub DeleteDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteDataToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub DeleteLineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteLineToolStripMenuItem.Click
        cmdDeleteLine_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        unlockBatch(lastBatch)
        ClearVariables()
        ClearAll()
        ClearDataInDatagrid()
    End Sub


    'Buttons

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            unlockBatch()
        End If

        If cmdGenerateNewAdjustmentNumber.Enabled = False Then
            cmdGenerateNewAdjustmentNumber.Enabled = True
        End If

        ClearVariables()
        ClearAll()
        ClearDataInDatagrid()
        ClearSerialLines()
    End Sub

    Private Sub cmdAddSerialNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSerialNumber.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewAssemblyAddNewSerialNumber As New AssemblyAddNewSerialNumber
            Dim Result = NewAssemblyAddNewSerialNumber.ShowDialog()
        End Using
    End Sub

    Private Sub cmdRemoveSerialNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveSerialNumber.Click
        If dgvTempSerialLines.RowCount <> 0 Then
            Dim RowSerialNumber As String = ""
            Dim RowTransactionNumber As Integer = 0
            Dim RowBatchNumber As Integer = 0

            Dim RowIndex As Integer = Me.dgvTempSerialLines.CurrentCell.RowIndex

            RowSerialNumber = Me.dgvTempSerialLines.Rows(RowIndex).Cells("SerialNumber2Column").Value
            RowTransactionNumber = Me.dgvTempSerialLines.Rows(RowIndex).Cells("TransactionNumber2Column").Value
            RowBatchNumber = Me.dgvTempSerialLines.Rows(RowIndex).Cells("BatchNumber2Column").Value

            Try
                'Remove record from the temp table
                cmd = New SqlCommand("DELETE FROM AssemblySerialTempTable WHERE SerialNumber = @SerialNumber AND BatchNumber = @BatchNumber AND TransactionNumber = @TransactionNumber", con)
                cmd.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = RowBatchNumber
                cmd.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Serial # was removed.", MsgBoxStyle.OkOnly)
                ShowSerialLines()
            Catch ex As Exception
                MsgBox("Serial # cannot be removed at this time.", MsgBoxStyle.OkOnly)
                Exit Sub
            End Try
        Else
            MsgBox("There are no rows to remove.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Form Logout
        FormLogoutRoutine()

        If canExit() Then
            unlockBatch()

            'Prompt before Saving
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Adjustment?", "SAVE INVENTORY ADJUSTMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Try
                    'Write Data to Inventory Adjustment Header Database Table
                    cmd = New SqlCommand("UPDATE InventoryAdjustmentTable SET AdjustmentDate = @AdjustmentDate, DivisionID = @DivisionID, Reason = @Reason, Status = @Status, BatchNumber = @BatchNumber, AdjustmentAgent = @AdjustmentAgent WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@AdjustmentDate", SqlDbType.VarChar).Value = AdjustmentDate
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@AdjustmentAgent", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@PrintDate", SqlDbType.VarChar).Value = ""
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception

                End Try
                '*************************************************************************************************************
                Try
                    'Check and delete Lines with no part number or quantity
                    cmd = New SqlCommand("DELETE FROM InventoryAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND (PartNumber = '' OR Quantity = 0)", con)

                    With cmd.Parameters
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip
                End Try
                ''if the dialog box us exited it will not close the form because the user decided that they didnt want to exit
            ElseIf button = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            ElseIf button = Windows.Forms.DialogResult.No Then
                ''if the adjustment is a blank adjustment it will be deleted from the database
                Try
                    cmd = New SqlCommand("DELETE FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID AND AdjustmentNumber = @AdjustmentNumber AND PartNumber = @PartNumber", con)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    cmd.Parameters.Add("@AdjustmentNumber", SqlDbType.VarChar).Value = cboAdjustmentNumber.Text
                    cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ""

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception

                End Try
            End If
        End If

        unlockBatch()
        ClearVariables()
        ClearAll()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If isSomeoneEditing() Then
            Exit Sub
        End If

        LockBatch()

        'Prompt before Deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Adjustment?", "DELETE INVENTORY ADJUSTMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Dim deleteLine As String = cboDeleteLine.Text

            'Check batch to see if posted
            Dim BatchStatusStatement As String = "SELECT Status FROM InventoryAdjustmentTable WHERE AdjustmentNumber = @AdjustmentNumber AND DivisionID = @DivisionID"
            Dim BatchStatusCommand As New SqlCommand(BatchStatusStatement, con)
            BatchStatusCommand.Parameters.Add("@AdjustmentNumber", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)
            BatchStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                BatchStatus = CStr(BatchStatusCommand.ExecuteScalar)
            Catch ex As Exception
                BatchStatus = ""
            End Try
            con.Close()

            If BatchStatus = "POSTED" Then
                MsgBox("You cannot delete a line from a posted Adjustment Batch.", MsgBoxStyle.OkOnly)
            Else
                Try
                    'Create command to delete data from text boxes
                    cmd = New SqlCommand("DELETE FROM InventoryAdjustmentTable WHERE AdjustmentNumber = @AdjustmentNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@AdjustmentNumber", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempAdjustmentNumber As Integer = 0
                    Dim strAdjustmentNumber As String
                    TempAdjustmentNumber = Val(cboBatchNumber.Text)
                    strAdjustmentNumber = CStr(TempAdjustmentNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Adjustment --- Delete Line Failure"
                    ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                Try
                    'Create command to delete data from text boxes
                    cmd = New SqlCommand("DELETE FROM AssemblySerialTempTable WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempAdjustmentNumber As Integer = 0
                    Dim strAdjustmentNumber As String
                    TempAdjustmentNumber = Val(cboBatchNumber.Text)
                    strAdjustmentNumber = CStr(TempAdjustmentNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Adjustment --- DELETE Line Failure"
                    ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                ShowData()
                ShowSerialLines()
            End If

            isLoaded = False

            If cboAdjustmentNumber.Text = deleteLine Then
                ClearLines()
                LoadInventoryTransactionNumber()
            ElseIf Not String.IsNullOrEmpty(cboAdjustmentNumber.Text) Then
                ''reusing this variable because it is not being uses elsewhere in this function
                deleteLine = cboAdjustmentNumber.Text
                LoadInventoryTransactionNumber()
                cboAdjustmentNumber.Text = deleteLine
            Else
                LoadInventoryTransactionNumber()
            End If

            isLoaded = True

            If dgvAdjustmentLines.Rows.Count = 0 Then
                cboDeleteLine.Text = ""
            End If

            MessageBox.Show("Adjustment has been deleted sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf button = DialogResult.No Then
            cboAdjustmentNumber.Focus()
        End If
    End Sub

    Private Sub cmdGenerateNewAdjustmentNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewAdjustmentNumber.Click
        If isSomeoneEditing() Then
            Exit Sub
        End If

        'ClearTransaction Data
        ClearLines()

        If String.IsNullOrEmpty(cboBatchNumber.Text) = False Then
            LockBatch()
            Dim MAXStatement As String = "SELECT MAX(AdjustmentNumber) FROM InventoryAdjustmentTable"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As Exception
                LastTransactionNumber = 547000000
            End Try
            con.Close()

            NextTransactionNumber = LastTransactionNumber + 1
            cboAdjustmentNumber.Text = NextTransactionNumber

            AdjustmentDate = dtpAdjustmentDate.Value

            Try
                'Reserve Adjustment Number
                cmd = New SqlCommand("Insert Into InventoryAdjustmentTable (AdjustmentNumber, AdjustmentDate, DivisionID, PartNumber, Description, Quantity, Cost, Total, Reason, Status, BatchNumber, InventoryAccount, AdjustmentAccount, AdjustmentAgent, LineComment)values(@AdjustmentNumber, @AdjustmentDate, @DivisionID, @PartNumber, @Description, @Quantity, @Cost, @Total, @Reason, @Status, @BatchNumber, @InventoryAccount, @AdjustmentAccount, @AdjustmentAgent, @LineComment)", con)

                With cmd.Parameters
                    .Add("@AdjustmentNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@AdjustmentDate", SqlDbType.VarChar).Value = AdjustmentDate
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PartNumber", SqlDbType.VarChar).Value = ""
                    .Add("@Description", SqlDbType.VarChar).Value = ""
                    .Add("@Quantity", SqlDbType.VarChar).Value = 0
                    .Add("@Cost", SqlDbType.VarChar).Value = 0
                    .Add("@Total", SqlDbType.VarChar).Value = 0
                    .Add("@Reason", SqlDbType.VarChar).Value = ""
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    .Add("@InventoryAccount", SqlDbType.VarChar).Value = ""
                    .Add("@AdjustmentAccount", SqlDbType.VarChar).Value = ""
                    .Add("@AdjustmentAgent", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@LineComment", SqlDbType.VarChar).Value = ""
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                isLoaded = False
                LoadInventoryTransactionNumber()
                cboAdjustmentNumber.Text = NextTransactionNumber
                isLoaded = True
                cboPartNumber.Focus()
            Catch ex As Exception
                '
            End Try
        Else
            MessageBox.Show("You must enter select a batch number", "Select a batch number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
        End If
    End Sub

    Private Sub cmdPostAdjustment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostAdjustment.Click
        'Declare local variables from the datagrid
        Dim AdjustmentNumber, BatchNumber As Integer
        Dim AdjustmentQuantity, AdjustmentTotal, AdjustmentCost As Double
        Dim PartNumber, PartDescription, AdjustmentReason, InventoryAccount, AdjustmentAccount As String
        Dim PostDivision As String = ""

        If cboDivisionID.Text = "TFP" Then
            PostDivision = "TWD"
        Else
            PostDivision = cboDivisionID.Text
        End If
        '*********************************************************************************
        If canPost() Then
            'Continue
        Else
            Exit Sub
        End If
        '*********************************************************************************
        Try
            'Check and delete Lines with no part number or quantity
            cmd = New SqlCommand("DELETE FROM InventoryAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND (PartNumber = '' OR Quantity = 0)", con)

            With cmd.Parameters
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowData()
        Catch ex As Exception
            'Log error on update failure
            Dim TempAdjustmentNumber As Integer = 0
            Dim strAdjustmentNumber As String
            TempAdjustmentNumber = Val(cboBatchNumber.Text)
            strAdjustmentNumber = CStr(TempAdjustmentNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Inventory Adjustment --- DELETE Blanks lines on POST"
            ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '*********************************************************************************
        AdjustmentDate = dtpAdjustmentDate.Value
        '*********************************************************************************

        '**********************************
        'Write to General Ledger
        '**********************************

        'Clear Running Count Variable
        RunningSerialCount = 0

        'Extract Line data from the datagrid
        For Each row As DataGridViewRow In dgvAdjustmentLines.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("BatchNumberColumn")

            If cell.Value = Val(cboBatchNumber.Text) Then
                Try
                    AdjustmentNumber = row.Cells("AdjustmentNumberColumn").Value
                Catch ex As Exception
                    AdjustmentNumber = 0
                End Try
                Try
                    PartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    AdjustmentTotal = row.Cells("TotalColumn").Value
                Catch ex As Exception
                    AdjustmentTotal = 0
                End Try
                Try
                    AdjustmentReason = row.Cells("ReasonColumn").Value
                Catch ex As Exception
                    AdjustmentReason = ""
                End Try
                Try
                    AdjustmentCost = row.Cells("CostColumn").Value
                Catch ex As Exception
                    AdjustmentCost = 0
                End Try
                Try
                    AdjustmentQuantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    AdjustmentQuantity = 0
                End Try
                Try
                    BatchNumber = row.Cells("BatchNumberColumn").Value
                Catch ex As Exception
                    BatchNumber = 0
                End Try
                Try
                    PartDescription = row.Cells("DescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    InventoryAccount = row.Cells("InventoryAccountColumn").Value
                Catch ex As Exception
                    InventoryAccount = "12150"
                End Try
                Try
                    AdjustmentAccount = row.Cells("AdjustmentAccountColumn").Value
                Catch ex As Exception
                    AdjustmentAccount = "59790"
                End Try
                '*****************************************************************************************************************************************
                'Get Purchase Product ID
                Dim GetPPL As String = ""
                Dim GetSPL As String = ""

                Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim GetSPLStatement As String = "SELECT SalesProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetSPLCommand As New SqlCommand(GetSPLStatement, con)
                GetSPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                GetSPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPPL = CStr(GetPPLCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPPL = ""
                End Try
                Try
                    GetSPL = CStr(GetSPLCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSPL = ""
                End Try
                con.Close()
                '******************************************************************************************************************************************
                'If TWE, count lines and add quantities for serialized assemblies
                If (cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "SLC") And GetPPL = "ASSEMBLY" Then
                    'Check if serialized
                    Dim CheckSerialized As String = ""

                    Dim CheckSerializedStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    Dim CheckSerializedCommand As New SqlCommand(CheckSerializedStatement, con)
                    CheckSerializedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                    CheckSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckSerialized = CStr(CheckSerializedCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckSerialized = "NO"
                    End Try
                    con.Close()
                    '**********************************************
                    If CheckSerialized = "YES" Then
                        RunningSerialCount = RunningSerialCount + AdjustmentQuantity
                    Else
                        'Do nothing
                    End If
                Else
                    'Continue
                End If
                '*****************************************************************************************************************************************
                'Validate GL Accounts
                Dim CountInventoryAccount As Integer = 0
                Dim CountAdjustmentAccount As Integer = 0

                Dim CountInventoryAccountStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
                Dim CountInventoryAccountCommand As New SqlCommand(CountInventoryAccountStatement, con)
                CountInventoryAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = InventoryAccount

                Dim CountAdjustmentAccountStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
                Dim CountAdjustmentAccountCommand As New SqlCommand(CountAdjustmentAccountStatement, con)
                CountAdjustmentAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = AdjustmentAccount

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountInventoryAccount = CInt(CountInventoryAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    CountInventoryAccount = 0
                End Try
                Try
                    CountAdjustmentAccount = CInt(CountAdjustmentAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    CountAdjustmentAccount = 0
                End Try
                con.Close()

                If CountAdjustmentAccount = 0 Or CountInventoryAccount = 0 Then
                    MsgBox("Invalid GL Account. Edit and try again.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Do nothing
                End If
                '*****************************************************************************************************************************************
                'Load Preferrred Vendor from Item List if necessary
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CurrentPartNumber = PartNumber
                    LoadPreferredVendor()
                End If
                '*****************************************************************************************************************************************
                'Get GL Accounts if canadian
                If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And VendorClass = "CANADIAN" Then
                    InventoryAccount = "C$" & InventoryAccount
                    AdjustmentAccount = "C$" & AdjustmentAccount
                Else
                    'Do nothing - GL Accounts are correct
                End If
                '*****************************************************************************************************************************************
                'Set GL Comment if blank
                If AdjustmentReason = "" Then
                    AdjustmentReason = "Part # -- " & PartNumber
                Else
                    'Do nothing
                End If
                '*****************************************************************************************************************************************
                'Convert Adjustment Total to two decimals
                AdjustmentTotal = Math.Round(AdjustmentTotal, 2)
                AdjustmentCost = Math.Round(AdjustmentCost, 4)
                '*****************************************************************************************************************************************
                'Determine if Inventory Adjust is a Credit or Debit
                If AdjustmentTotal > 0 Then
                    GLDebitAmount = AdjustmentTotal
                    GLCreditAmount = 0
                Else
                    GLDebitAmount = 0
                    GLCreditAmount = AdjustmentTotal * -1
                End If
                '*****************************************************************************************************************************************
                Try
                    'Command to write Line Amount to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = InventoryAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Inventory Adjustment"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = AdjustmentDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = GLDebitAmount
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = GLCreditAmount
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = AdjustmentReason
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = BatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = AdjustmentNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempAdjustmentNumber As Integer = 0
                    Dim strAdjustmentNumber As String
                    TempAdjustmentNumber = Val(cboBatchNumber.Text)
                    strAdjustmentNumber = CStr(TempAdjustmentNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Adjustment --- Posting GL Entry Failure"
                    ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*****************************************************************************************************************************************
                Try
                    'Command to write Line Amount to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = AdjustmentAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Inventory Adjustment"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = AdjustmentDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = GLCreditAmount
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = GLDebitAmount
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = AdjustmentReason
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = BatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = AdjustmentNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempAdjustmentNumber As Integer = 0
                    Dim strAdjustmentNumber As String
                    TempAdjustmentNumber = Val(cboBatchNumber.Text)
                    strAdjustmentNumber = CStr(TempAdjustmentNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Adjustment --- Posting GL Entry Failure"
                    ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*****************************************************************************************************************************************
                Try
                    'Close adjustment in Inventory Adjustment Table
                    cmd = New SqlCommand("UPDATE InventoryAdjustmentTable SET Status = @Status, PrintDate = @PrintDate WHERE AdjustmentNumber = @AdjustmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@AdjustmentNumber", SqlDbType.VarChar).Value = AdjustmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                        .Add("@PrintDate", SqlDbType.VarChar).Value = TodaysDate
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempAdjustmentNumber As Integer = 0
                    Dim strAdjustmentNumber As String
                    TempAdjustmentNumber = Val(cboBatchNumber.Text)
                    strAdjustmentNumber = CStr(TempAdjustmentNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Adjustment --- Update Status Failure"
                    ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*****************************************************************************************************************************************
                'Get Item Class 
                GetItemClass = ""

                Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
                GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
                Catch ex As Exception
                    GetItemClass = "TW CA"
                End Try
                con.Close()
                '******************************************************************************************************************************************
                'Get Item Class 
                Dim GetInventoryItem As String = ""

                Dim GetInventoryItemStatement As String = "SELECT InventoryItem FROM ItemClass WHERE ItemClassID = @ItemClassID"
                Dim GetInventoryItemCommand As New SqlCommand(GetInventoryItemStatement, con)
                GetInventoryItemCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = GetItemClass

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetInventoryItem = CStr(GetInventoryItemCommand.ExecuteScalar)
                Catch ex As Exception
                    GetInventoryItem = "YES"
                End Try
                con.Close()

                If GetInventoryItem = "NO" Then
                    CheckItemClass = "NON-INVENTORY"
                Else
                    'Do nothing
                End If
                '*****************************************************************************************************************************************
                If GetPPL = "NON-INVENTORY" Or GetSPL = "SUPPLY" Then
                    CheckItemClass = "NON-INVENTORY"
                End If
                '******************************************************************************************************************************************
                If CheckItemClass = "NON-INVENTORY" Then
                    'Skip Cost Tier
                Else
                    Try
                        'Write Adjustment Data to the Inventory Costing Table
                        'Extract the Upper and Lower Limit of the Inventory Costing Table
                        Dim NewUpperLimit As Double = 0
                        Dim LowerLimit As Double = 0
                        Dim MaxTransactionNumber As Integer = 0
                        Dim UpperLimit As Double = 0
                        Dim MAXDate As String = ""

                        Dim MAXDateStatement As String = "SELECT MAX(CostingDate) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                        MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MAXDate = CStr(MAXDateCommand.ExecuteScalar)
                        Catch ex As Exception
                            MAXDate = ""
                        End Try
                        con.Close()

                        Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate = @CostingDate"
                        Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
                        MaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        MaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        MaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = MAXDate

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
                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                        Catch ex As Exception
                            UpperLimit = 0
                        End Try
                        con.Close()

                        If AdjustmentQuantity < 0 Then
                            LowerLimit = UpperLimit
                            NewUpperLimit = LowerLimit + AdjustmentQuantity
                        Else
                            'Calculate the NEW Lower/Upper Limit for the next post
                            LowerLimit = UpperLimit + 1
                            NewUpperLimit = LowerLimit + AdjustmentQuantity - 1
                        End If

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
                        cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                        With cmd.Parameters
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@CostingDate", SqlDbType.VarChar).Value = AdjustmentDate
                            .Add("@ItemCost", SqlDbType.VarChar).Value = AdjustmentCost
                            .Add("@CostQuantity", SqlDbType.VarChar).Value = AdjustmentQuantity
                            .Add("@Status", SqlDbType.VarChar).Value = "INVENTORY ADJUSTMENT"
                            .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                            .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimit
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = AdjustmentNumber
                            .Add("@ReferenceLine", SqlDbType.VarChar).Value = 1
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Clear costing variables
                        LowerLimit = 0
                        UpperLimit = 0
                        NewUpperLimit = 0
                        NextCostingTransactionNumber = 0
                    Catch ex5 As Exception
                        'Log error on update failure
                        Dim TempAdjustmentNumber As Integer = 0
                        Dim strAdjustmentNumber As String
                        TempAdjustmentNumber = Val(cboBatchNumber.Text)
                        strAdjustmentNumber = CStr(TempAdjustmentNumber)

                        ErrorDate = Today()
                        ErrorComment = ex5.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Inventory Adjustment --- Create Cost Tier Failure"
                        ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
                '*****************************************************************************************************************************************
                Try
                    'Update Adjustment Table to show posted status
                    cmd = New SqlCommand("UPDATE InventoryAdjustmentTable SET Status = @Status WHERE AdjustmentNumber = @AdjustmentNumber", con)
                    cmd.Parameters.Add("@AdjustmentNumber", SqlDbType.VarChar).Value = AdjustmentNumber
                    cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempAdjustmentNumber As Integer = 0
                    Dim strAdjustmentNumber As String
                    TempAdjustmentNumber = Val(cboBatchNumber.Text)
                    strAdjustmentNumber = CStr(TempAdjustmentNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Adjustment --- Update status Failure"
                    ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                'Write Values to Inventory Transaction Table
                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                'If ItemClass is expense / supply then use the actual cost from the shipment line
                If CheckItemClass = "NON-INVENTORY" Then
                    'Do not add Inventory Transaction to Transaction Table
                Else
                    'Write Data to the Inventory Transaction Table
                    Try
                        cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                        With cmd.Parameters
                            '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                            .Add("@TransactionDate", SqlDbType.VarChar).Value = AdjustmentDate
                            .Add("@TransactionType", SqlDbType.VarChar).Value = "Inventory Adjustment"
                            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = AdjustmentNumber
                            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = 1
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@Quantity", SqlDbType.VarChar).Value = AdjustmentQuantity
                            .Add("@ItemCost", SqlDbType.VarChar).Value = AdjustmentCost
                            .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                            .Add("@ExtendedCost", SqlDbType.VarChar).Value = AdjustmentTotal
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                            .Add("@GLAccount", SqlDbType.VarChar).Value = InventoryAccount
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempAdjustmentNumber As Integer = 0
                        Dim strAdjustmentNumber As String
                        TempAdjustmentNumber = Val(cboBatchNumber.Text)
                        strAdjustmentNumber = CStr(TempAdjustmentNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Inventory Adjustment --- Update Inventory Transaction Table Failure"
                        ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If

                '**********************************************************************
                'Clear Variables
                PartNumber = ""
                AdjustmentTotal = 0
                AdjustmentCost = 0
                FIFOCost = 0
                AdjustmentQuantity = 0
                GetItemClass = ""
                CheckItemClass = ""
                GetPPL = ""
                GetSPL = ""
            End If
        Next

        '**********************************
        'End of Ledger Entry
        '**********************************

        'If TWE Update Serial Lines
        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "SLC" Then
            ShowSerialLines()
            '=====================================================================
            'Update Serial Log from the temp table if applicable
            If dgvTempSerialLines.RowCount > 0 Then
                Dim RowPartNumber As String = ""
                Dim RowSerialNumber As String = ""
                Dim RowComment As String = ""
                Dim RowStatus As String = ""
                Dim RowCustomerID As String = ""
                Dim RowBatchNumber As Integer = 0
                Dim RowTransactionNumber As Integer = 0
                Dim RowTotalCost As Double = 0

                For Each row As DataGridViewRow In dgvTempSerialLines.Rows
                    Try
                        RowPartNumber = row.Cells("AssemblyPartNumber2Column").Value
                    Catch ex As Exception
                        RowPartNumber = ""
                    End Try
                    Try
                        RowSerialNumber = row.Cells("SerialNumber2Column").Value
                    Catch ex As Exception
                        RowSerialNumber = ""
                    End Try
                    Try
                        RowComment = row.Cells("Comment2Column").Value
                    Catch ex As Exception
                        RowComment = ""
                    End Try
                    Try
                        RowStatus = row.Cells("Status2Column").Value
                    Catch ex As Exception
                        RowStatus = ""
                    End Try
                    Try
                        RowCustomerID = row.Cells("CustomerID2Column").Value
                    Catch ex As Exception
                        RowCustomerID = ""
                    End Try
                    Try
                        RowBatchNumber = row.Cells("BatchNumber2Column").Value
                    Catch ex As Exception
                        RowBatchNumber = 0
                    End Try
                    Try
                        RowTransactionNumber = row.Cells("TransactionNumber2Column").Value
                    Catch ex As Exception
                        RowTransactionNumber = 0
                    End Try
                    Try
                        RowTotalCost = row.Cells("TotalCost2Column").Value
                    Catch ex As Exception
                        RowTotalCost = 0
                    End Try
                    '****************************************************************************************
                    Try
                        'Insert new Serial Log
                        cmd = New SqlCommand("INSERT INTO AssemblySerialLog (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, TransactionNumber, CustomerID, BatchNumber, BuildNumber) Values(@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @TransactionNumber, @CustomerID, @BatchNumber, @BuildNumber)", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TotalCost", SqlDbType.VarChar).Value = RowTotalCost
                            .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                            .Add("@BuildDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@Status", SqlDbType.VarChar).Value = RowStatus
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                            .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = RowBatchNumber
                            .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Update Serial Log
                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET Comment = @Comment, Status = @Status, TransactionNumber = @TransactionNumber, CustomerID = @CustomerID, BatchNumber = @BatchNumber WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                            .Add("@Status", SqlDbType.VarChar).Value = RowStatus
                            .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomerID
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = RowBatchNumber
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = RowTransactionNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Try
                Next
            End If
        End If
        '======================================================================
        unlockBatch()

        MsgBox("Inventory Adjustments have been posted.", MsgBoxStyle.OkOnly)

        LoadBatchNumber()
        ClearVariables()
        ClearAll()
        ShowData()
        ClearSerialLines()
        LoadInventoryTransactionNumber()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSave() Then
            LockBatch()
            '*************************************************************************************************************
            AdjustmentDate = dtpAdjustmentDate.Value
            '*************************************************************************************************************
            'Write Data to Inventory Adjustment Header Database Table
            cmd = New SqlCommand("UPDATE InventoryAdjustmentTable SET AdjustmentDate = @AdjustmentDate, DivisionID = @DivisionID, Reason = @Reason, Status = @Status, BatchNumber = @BatchNumber, AdjustmentAgent = @AdjustmentAgent WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@AdjustmentDate", SqlDbType.VarChar).Value = AdjustmentDate
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                .Add("@AdjustmentAgent", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@PrintDate", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '*************************************************************************************************************
            Try
                'Check and delete Lines with no part number or quantity
                cmd = New SqlCommand("DELETE FROM InventoryAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND (PartNumber = '' OR Quantity = 0)", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempAdjustmentNumber As Integer = 0
                Dim strAdjustmentNumber As String
                TempAdjustmentNumber = Val(cboBatchNumber.Text)
                strAdjustmentNumber = CStr(TempAdjustmentNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Inventory Adjustment --- SAVE Failure"
                ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            MessageBox.Show("Batch has been saved sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ShowData()
            LoadBatchTotals()
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim LineStatus As String
        Dim LineStatusCount As Integer = 0
        Dim TotalLineStatusCount As Integer = 0
        Dim CountLines As Integer = 0

        If canDeleteBatch() Then
            If txtBatchStatus.Text = "OPEN" Then
                'Write to Audit Trail Table
                Dim AuditComment As String = ""
                Dim AuditBatchNumber As Integer = 0
                Dim strBatchNumber As String = ""

                AuditBatchNumber = Val(cboBatchNumber.Text)
                strBatchNumber = CStr(AuditBatchNumber)
                AuditComment = "Batch #" + strBatchNumber + " was deleted on " + TodaysDate

                Try
                    cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@AuditDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@AuditType", SqlDbType.VarChar).Value = "INVENTORY ADJUSTMENT - DELETION"
                        .Add("@AuditAmount", SqlDbType.VarChar).Value = AdjustmentTotal
                        .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strBatchNumber
                        .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception

                End Try
                '**********************************************************************************************************
                Try
                    'Create command to delete adjustment
                    cmd = New SqlCommand("DELETE FROM InventoryAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempAdjustmentNumber As Integer = 0
                    Dim strAdjustmentNumber As String
                    TempAdjustmentNumber = Val(cboBatchNumber.Text)
                    strAdjustmentNumber = CStr(TempAdjustmentNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Adjustment --- DELETE Adjustment Failure"
                    ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                Try
                    'Create command to delete adjustment
                    cmd = New SqlCommand("DELETE FROM InventoryAdjustmentBatchNumbers WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempAdjustmentNumber As Integer = 0
                    Dim strAdjustmentNumber As String
                    TempAdjustmentNumber = Val(cboBatchNumber.Text)
                    strAdjustmentNumber = CStr(TempAdjustmentNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Adjustment --- DELETE Batch Failure"
                    ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                Try
                    'Create command to delete from serial log
                    cmd = New SqlCommand("DELETE FROM AssemblySerialTempTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempAdjustmentNumber As Integer = 0
                    Dim strAdjustmentNumber As String
                    TempAdjustmentNumber = Val(cboBatchNumber.Text)
                    strAdjustmentNumber = CStr(TempAdjustmentNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Adjustment --- DELETE Assembly LOG Failure"
                    ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                MsgBox("Entire batch has been deleted.", MsgBoxStyle.OkOnly)
                LoadBatchNumber()

                ClearVariables()
                ClearAll()
                ShowData()
                isLoaded = False
                LoadInventoryTransactionNumber()
                isLoaded = True
            Else
                'Check Line Status on Batch Lines
                For Each row As DataGridViewRow In dgvAdjustmentLines.Rows
                    Try
                        LineStatus = row.Cells("StatusColumn").Value
                    Catch ex As Exception
                        LineStatus = ""
                    End Try

                    If LineStatus = "POSTED" Then
                        LineStatusCount = 0
                    Else
                        LineStatusCount = 1
                    End If

                    TotalLineStatusCount = TotalLineStatusCount + LineStatusCount
                Next

                'Check to see if batch has lines
                Dim CountLinesStatement As String = "SELECT COUNT(AdjustmentNumber) FROM InventoryAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                Dim CountLinesCommand As New SqlCommand(CountLinesStatement, con)
                CountLinesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                CountLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountLines = CInt(CountLinesCommand.ExecuteScalar)
                Catch ex As Exception
                    CountLines = 0
                End Try
                con.Close()

                If TotalLineStatusCount = 0 And CountLines > 0 Then
                    MsgBox("You cannot delete this batch - it is posted.", MsgBoxStyle.OkOnly)
                Else
                    'Write to Audit Trail Table
                    Dim AuditComment As String = ""
                    Dim AuditBatchNumber As Integer = 0
                    Dim strBatchNumber As String = ""

                    AuditBatchNumber = Val(cboBatchNumber.Text)
                    strBatchNumber = CStr(AuditBatchNumber)
                    AuditComment = "Batch #" + strBatchNumber + " was deleted on " + TodaysDate

                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "INVENTORY ADJUSTMENT - DELETION"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = AdjustmentTotal
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strBatchNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try
                    '**********************************************************************************************************
                    Try
                        'Create command to save data from text boxes
                        cmd = New SqlCommand("DELETE FROM InventoryAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempAdjustmentNumber As Integer = 0
                        Dim strAdjustmentNumber As String
                        TempAdjustmentNumber = Val(cboBatchNumber.Text)
                        strAdjustmentNumber = CStr(TempAdjustmentNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Inventory Adjustment --- DELETE Adjustment Failure"
                        ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    Try
                        'Create command to save data from text boxes
                        cmd = New SqlCommand("DELETE FROM InventoryAdjustmentBatchNumbers WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempAdjustmentNumber As Integer = 0
                        Dim strAdjustmentNumber As String
                        TempAdjustmentNumber = Val(cboBatchNumber.Text)
                        strAdjustmentNumber = CStr(TempAdjustmentNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Inventory Adjustment --- DELETE Batch Number Failure"
                        ErrorReferenceNumber = "Adj. Batch # " + strAdjustmentNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    MsgBox("Entire batch has been deleted.", MsgBoxStyle.OkOnly)
                    LoadBatchNumber()

                    ClearVariables()
                    ClearAll()
                    LoadBatchNumber()
                    ShowData()
                    isLoaded = False
                    LoadInventoryTransactionNumber()
                    isLoaded = True
                End If
            End If
        End If
    End Sub

    Private Sub cmdBatchNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBatchNumber.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            unlockBatch()
        End If

        'Clear Form
        ClearVariables()
        ClearAll()

        Dim MAXBatchStatement As String = "SELECT MAX(BatchNumber) FROM InventoryAdjustmentBatchNumbers"
        Dim MAXBatchCommand As New SqlCommand(MAXBatchStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(MAXBatchCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 337000000
        End Try
        con.Close()

        txtBatchStatus.Text = "OPEN"
        NextBatchNumber = LastBatchNumber + 1
        cboBatchNumber.Text = NextBatchNumber

        Try
            'Reserve Batch Number
            'Create command to save data from text boxes
            cmd = New SqlCommand("INSERT INTO InventoryAdjustmentBatchNumbers (BatchNumber, DivisionID, Locked) Values (@BatchNumber, @DivisionID, @Locked)", con)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            cmdGenerateNewAdjustmentNumber_Click(sender, e)
            isLoaded = False
            LoadBatchNumber()
            cboBatchNumber.Text = NextBatchNumber
            isLoaded = True
            cboPartNumber.Focus()
            cmdGenerateNewAdjustmentNumber.Enabled = False
            lastBatch = cboBatchNumber.Text
        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        If canAddAdjustmentLine() Then
            'Lock batch so no one else can edit
            LockBatch()

            'Verify that part is not de-activated
            Dim CheckIfDeactivated As String = ""

            Dim CheckIfDeactivatedStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim CheckIfDeactivatedCommand As New SqlCommand(CheckIfDeactivatedStatement, con)
            CheckIfDeactivatedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            CheckIfDeactivatedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckIfDeactivated = CStr(CheckIfDeactivatedCommand.ExecuteScalar)
            Catch ex As Exception
                CheckIfDeactivated = ""
            End Try
            con.Close()

            If CheckIfDeactivated = "DEACTIVATED-PART" Then
                MsgBox("This part is de-activated and you cannot adjust.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Skip
            End If
            '*************************************************************************************************************
            If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "SLC" Then
                'If serial number is added manually and quantity is one, skip serial pop up screen
                If Val(txtQuantity.Text) = 1 And txtSerialNumber.Text <> "" Then
                    'Add Serial number manually

                    'Check to see if serial exists or is new
                    Dim VerifySerialNumber As Integer = 0

                    Dim VerifySerialNumberStatement As String = "SELECT COUNT(SerialNumber) FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status"
                    Dim VerifySerialNumberCommand As New SqlCommand(VerifySerialNumberStatement, con)
                    VerifySerialNumberCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                    VerifySerialNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    VerifySerialNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    VerifySerialNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        VerifySerialNumber = CInt(VerifySerialNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        VerifySerialNumber = 0
                    End Try
                    con.Close()
                    '***********************************************************************************************************
                    If VerifySerialNumber = 0 Then
                        Dim button As DialogResult = MessageBox.Show("This Serial Number does not exist for this part. Do you wish to create it?", "CHECK SERIAL NUMBER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If button = DialogResult.Yes Then
                            '***********************************************************************************
                            Dim SerialLogComment As String = ""

                            If txtLineComment.Text = "" Then
                                SerialLogComment = "Inventory Adjustment"
                            Else
                                SerialLogComment = txtLineComment.Text
                            End If

                            'Write to temp table
                            cmd = New SqlCommand("INSERT INTO AssemblySerialTempTable (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, BuildNumber, CustomerID, BatchNumber, TransactionNumber) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @BuildNumber, @CustomerID, @BatchNumber, @TransactionNumber) ", con)

                            With cmd.Parameters
                                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                                .Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@TotalCost", SqlDbType.VarChar).Value = Total
                                .Add("@Comment", SqlDbType.VarChar).Value = SerialLogComment
                                .Add("@BuildDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@BuildNumber", SqlDbType.VarChar).Value = 0
                                .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                                .Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        ElseIf button = DialogResult.No Then
                            MsgBox("Check serial # and try again.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End If
                    Else
                        '***********************************************************************************
                        'Get serial Data to write to temp table
                        Dim SerialTotalCost As Double = 0
                        Dim SerialComment As String = ""
                        Dim SerialBuildDate As String = ""
                        Dim SerialBuildNumber As Integer = 0

                        If cboDivisionID.Text = "TWE" Then
                            Dim SerialTotalCostStatement As String = "SELECT TotalCost FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                            Dim SerialTotalCostCommand As New SqlCommand(SerialTotalCostStatement, con)
                            SerialTotalCostCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                            SerialTotalCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                            SerialTotalCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                SerialTotalCost = CDbl(SerialTotalCostCommand.ExecuteScalar)
                            Catch ex As Exception
                                SerialTotalCost = 0
                            End Try
                            con.Close()
                        Else
                            Dim SerialTotalCostStatement As String = "SELECT ShipmentPrice FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                            Dim SerialTotalCostCommand As New SqlCommand(SerialTotalCostStatement, con)
                            SerialTotalCostCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                            SerialTotalCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                            SerialTotalCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                SerialTotalCost = CDbl(SerialTotalCostCommand.ExecuteScalar)
                            Catch ex As Exception
                                SerialTotalCost = 0
                            End Try
                            con.Close()
                        End If

                        Dim SerialCommentStatement As String = "SELECT Comment FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                        Dim SerialCommentCommand As New SqlCommand(SerialCommentStatement, con)
                        SerialCommentCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                        SerialCommentCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        SerialCommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim SerialBuildDateStatement As String = "SELECT BuildDate FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                        Dim SerialBuildDateCommand As New SqlCommand(SerialBuildDateStatement, con)
                        SerialBuildDateCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                        SerialBuildDateCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        SerialBuildDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim SerialBuildNumberStatement As String = "SELECT BuildNumber FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                        Dim SerialBuildNumberCommand As New SqlCommand(SerialBuildNumberStatement, con)
                        SerialBuildNumberCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                        SerialBuildNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        SerialBuildNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SerialComment = CStr(SerialCommentCommand.ExecuteScalar)
                        Catch ex As Exception
                            SerialComment = ""
                        End Try
                        Try
                            SerialBuildDate = CStr(SerialBuildDateCommand.ExecuteScalar)
                        Catch ex As Exception
                            SerialBuildDate = ""
                        End Try
                        Try
                            SerialBuildNumber = CInt(SerialBuildNumberCommand.ExecuteScalar)
                        Catch ex As Exception
                            SerialBuildNumber = 0
                        End Try
                        con.Close()

                        If SerialComment = "" Then
                            SerialComment = "Inventory Adjustment"
                        End If

                        'Write to temp table
                        cmd = New SqlCommand("INSERT INTO AssemblySerialTempTable (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, BuildNumber, CustomerID, BatchNumber, TransactionNumber) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @BuildNumber, @CustomerID, @BatchNumber, @TransactionNumber) ", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TotalCost", SqlDbType.VarChar).Value = SerialTotalCost
                            .Add("@Comment", SqlDbType.VarChar).Value = SerialComment
                            .Add("@BuildDate", SqlDbType.VarChar).Value = SerialBuildDate
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@BuildNumber", SqlDbType.VarChar).Value = SerialBuildNumber
                            .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                ElseIf Val(txtQuantity.Text) = -1 And txtSerialNumber.Text <> "" Then
                    'Add Serial number manually

                    'Check to see if serial exists or is new
                    Dim VerifySerialNumber As Integer = 0

                    Dim VerifySerialNumberStatement As String = "SELECT COUNT(SerialNumber) FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status"
                    Dim VerifySerialNumberCommand As New SqlCommand(VerifySerialNumberStatement, con)
                    VerifySerialNumberCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                    VerifySerialNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    VerifySerialNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    VerifySerialNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        VerifySerialNumber = CInt(VerifySerialNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        VerifySerialNumber = 0
                    End Try
                    con.Close()

                    If VerifySerialNumber = 0 And Val(txtQuantity.Text) = -1 Then
                        MsgBox("You cannot remove a serialized assembly if the serial # does not exist.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                    '***********************************************************************************************************
                    'Get serial Data to write to temp table
                    Dim SerialTotalCost As Double = 0
                    Dim SerialComment As String = ""
                    Dim SerialBuildDate As String = ""
                    Dim SerialBuildNumber As Integer = 0

                    If cboDivisionID.Text = "TWE" Then
                        Dim SerialTotalCostStatement As String = "SELECT TotalCost FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                        Dim SerialTotalCostCommand As New SqlCommand(SerialTotalCostStatement, con)
                        SerialTotalCostCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                        SerialTotalCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        SerialTotalCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SerialTotalCost = CDbl(SerialTotalCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            SerialTotalCost = 0
                        End Try
                        con.Close()
                    Else
                        Dim SerialTotalCostStatement As String = "SELECT ShipmentPrice FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                        Dim SerialTotalCostCommand As New SqlCommand(SerialTotalCostStatement, con)
                        SerialTotalCostCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                        SerialTotalCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        SerialTotalCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SerialTotalCost = CDbl(SerialTotalCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            SerialTotalCost = 0
                        End Try
                        con.Close()
                    End If

                    Dim SerialCommentStatement As String = "SELECT Comment FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    Dim SerialCommentCommand As New SqlCommand(SerialCommentStatement, con)
                    SerialCommentCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                    SerialCommentCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    SerialCommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim SerialBuildDateStatement As String = "SELECT BuildDate FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    Dim SerialBuildDateCommand As New SqlCommand(SerialBuildDateStatement, con)
                    SerialBuildDateCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                    SerialBuildDateCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    SerialBuildDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim SerialBuildNumberStatement As String = "SELECT BuildNumber FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    Dim SerialBuildNumberCommand As New SqlCommand(SerialBuildNumberStatement, con)
                    SerialBuildNumberCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                    SerialBuildNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    SerialBuildNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SerialComment = CStr(SerialCommentCommand.ExecuteScalar)
                    Catch ex As Exception
                        SerialComment = ""
                    End Try
                    Try
                        SerialBuildDate = CStr(SerialBuildDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        SerialBuildDate = ""
                    End Try
                    Try
                        SerialBuildNumber = CInt(SerialBuildNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        SerialBuildNumber = 0
                    End Try
                    con.Close()

                    If SerialComment = "" Then
                        SerialComment = "Inventory Adjustment"
                    End If

                    'Write to temp table
                    cmd = New SqlCommand("INSERT INTO AssemblySerialTempTable (AssemblyPartNumber, SerialNumber, DivisionID, TotalCost, Comment, BuildDate, Status, BuildNumber, CustomerID, BatchNumber, TransactionNumber) values (@AssemblyPartNumber, @SerialNumber, @DivisionID, @TotalCost, @Comment, @BuildDate, @Status, @BuildNumber, @CustomerID, @BatchNumber, @TransactionNumber) ", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@TotalCost", SqlDbType.VarChar).Value = SerialTotalCost
                        .Add("@Comment", SqlDbType.VarChar).Value = SerialComment
                        .Add("@BuildDate", SqlDbType.VarChar).Value = SerialBuildDate
                        .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                        .Add("@BuildNumber", SqlDbType.VarChar).Value = SerialBuildNumber
                        .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = Val(cboAdjustmentNumber.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Check for assembly and serial status
                    LoadPurchaseProductLine()

                    If GetPurchProdLineID = "ASSEMBLY" Then
                        LoadSerialStatus()

                        If GetSerialStatus = "YES" And Val(txtQuantity.Text) <> 0 Then
                            'If Assembly is serialized, show popup box to select serial number to enter
                            GlobalSerialFormLocation = "INVENTORYADJUSTMENT"
                            GlobalAssemblyPartNumber = cboPartNumber.Text
                            GlobalSerialAssemblyQuantity = Val(txtQuantity.Text)
                            GlobalDivisionCode = cboDivisionID.Text
                            GlobalAssemblyBatchNumber = Val(cboBatchNumber.Text)
                            GlobalAssemblyTransactionNumber = Val(cboAdjustmentNumber.Text)

                            Using NewAssemblySerialPopup As New AssemblySerialPopup
                                Dim Result = NewAssemblySerialPopup.ShowDialog()
                            End Using

                            'If all serial numbers match quantities, then continue
                            If GlobalSerialValidation = "YES" Then
                                'Continue
                            ElseIf GlobalSerialValidation = "NO" Then
                                MsgBox("Serial Numbers must match the quantity adjusted.", MsgBoxStyle.OkOnly)
                                Exit Sub
                            Else
                                'Continue
                            End If

                            'Fill Line Fields
                            Dim PerUnitCost As Double = 0
                            Dim LineQuantity As Double = 0

                            If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Or cboDivisionID.Text = "SLC" Then
                                LineQuantity = Val(txtQuantity.Text)

                                If LineQuantity < 0 Then
                                    PerUnitCost = GlobalSumSerialCost / (LineQuantity * -1)
                                Else
                                    PerUnitCost = GlobalSumSerialCost / LineQuantity
                                End If

                                PerUnitCost = Math.Round(PerUnitCost, 4)
                                txtCost.Text = PerUnitCost
                                Total = PerUnitCost * LineQuantity
                                txtLineTotal.Text = Total
                            End If
                        Else
                            'Skip
                        End If
                    Else
                        'Do nothing
                    End If
                End If

                'Load Datagrid
                ShowSerialLines()
            Else
                'Skip Serialization
            End If

            '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            'End of TWE Serial Routine
            '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            AdjustmentDate = dtpAdjustmentDate.Value
            '*************************************************************************************************************
            'Define variables before save
            AdjustmentStatus = "OPEN"
            PrintDate = ""

            'Convert TOTAL to two decimals
            Total = Math.Round(Total, 2)

            Try
                InsertIntoInventoryAdjustmentTable()
            Catch ex As Exception
                UpdateInventoryAdjustmentTable()
            End Try
            '*************************************************************************************************************
            'Clear and reset form for next entry
            'LoadItemList()
            'LoadGLAccount()
            LoadBatchTotals()
            ShowData()
            isLoaded = False
            LoadInventoryTransactionNumber()
            ClearLines()

            'Show last record entered
            Dim RowCount As Integer

            Dim MAXLine5Statement As String = "SELECT COUNT(AdjustmentNumber) FROM InventoryAdjustmentTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim MAXLine5Command As New SqlCommand(MAXLine5Statement, con)
            MAXLine5Command.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboBatchNumber.Text)
            MAXLine5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                RowCount = CInt(MAXLine5Command.ExecuteScalar)
            Catch ex As Exception
                RowCount = 0
            End Try
            con.Close()

            Try
                Me.dgvAdjustmentLines.CurrentCell = Me.dgvAdjustmentLines.Rows(RowCount - 1).Cells("AdjustmentNumberColumn")
            Catch ex As Exception
                'Skip
            End Try

            isLoaded = True

            If cmdGenerateNewAdjustmentNumber.Enabled = False Then
                cmdGenerateNewAdjustmentNumber.Enabled = True
            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalInventoryAdjustmentBatchNumber = Val(cboBatchNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintInventoryAdjustmentBatch As New PrintInventoryAdjustmentBatch
            Dim result = NewPrintInventoryAdjustmentBatch.ShowDialog()
        End Using
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If Not String.IsNullOrEmpty(cboBatchNumber.Text) Then
            ''unlocks the batch if the user is the one that has it locked
            unlockBatch()
        End If

        Try
            cmd = New SqlCommand("DELETE FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID AND AdjustmentNumber = @AdjustmentNumber AND PartNumber = @PartNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@AdjustmentNumber", SqlDbType.VarChar).Value = cboAdjustmentNumber.Text
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ""

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip
        End Try

        ClearLines()
        isLoaded = False
        LoadInventoryTransactionNumber()
        isLoaded = True
    End Sub

    Private Sub tabInventoryData_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabInventoryData.SelectedIndexChanged
        If tabInventoryData.TabPages(tabInventoryData.SelectedIndex).Name = "tabSerialLines" Then
            ShowSerialLines()
            dgvTempSerialLines.Visible = True
        Else
            'Do nothing
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub
End Class