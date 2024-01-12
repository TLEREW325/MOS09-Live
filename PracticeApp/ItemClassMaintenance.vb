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
Public Class ItemClassMaintenance
    Inherits System.Windows.Forms.Form

    Dim InventoryItem, ItemClassID, ItemClassName, GLSalesAccount, GLReturnsAccount, GLInventoryAccount, GLCOGSAccount, GLPurchasesAccount, GLSalesOffsetAccount, GLAdjustmentAccount, GLIssuesAccount As String
    Dim VerifyGLSalesAccount, VerifyGLReturnsAccount, VerifyGLInventoryAccount, VerifyGLCOGSAccount, VerifyGLPurchasesAccount, VerifyGLSalesOffsetAccount, VerifyGLAdjustmentAccount, VerifyGLIssuesAccount As String

    'Setup variables and data connection
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ItemClassMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.SalesProductLine' table. You can move, or remove it, as needed.
        Me.SalesProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.SalesProductLine)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PurchaseProductLine' table. You can move, or remove it, as needed.
        Me.PurchaseProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PurchaseProductLine)

        'Load Datagrid
        ShowData()

        'Set permissions
        usefulFunctions.LoadSecurity(Me)

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            Me.dgvItemClassList.Columns("ItemClassIDColumn").ReadOnly = True
        End If

        'Clear text boxes on load
        LoadItemClass()
        ClearData()
        cboItemClassID.Focus()
    End Sub

    Private Sub dgvItemClassList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemClassList.CellValueChanged
        If Me.dgvItemClassList.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvItemClassList.CurrentCell.RowIndex

            Try
                ItemClassID = Me.dgvItemClassList.Rows(RowIndex).Cells("ItemClassIDColumn").Value
            Catch ex As Exception
                ItemClassID = ""
            End Try
            Try
                ItemClassName = Me.dgvItemClassList.Rows(RowIndex).Cells("ItemClassNameColumn").Value
            Catch ex As Exception
                ItemClassName = ""
            End Try
            Try
                GLSalesAccount = Me.dgvItemClassList.Rows(RowIndex).Cells("GLSalesAccountColumn").Value
            Catch ex As Exception
                GLSalesAccount = ""
            End Try
            Try
                GLSalesOffsetAccount = Me.dgvItemClassList.Rows(RowIndex).Cells("GLSalesOffsetAccountColumn").Value
            Catch ex As Exception
                GLSalesOffsetAccount = ""
            End Try
            Try
                GLReturnsAccount = Me.dgvItemClassList.Rows(RowIndex).Cells("GLReturnsAccountColumn").Value
            Catch ex As Exception
                GLReturnsAccount = ""
            End Try
            Try
                GLInventoryAccount = Me.dgvItemClassList.Rows(RowIndex).Cells("GLInventoryAccountColumn").Value
            Catch ex As Exception
                GLInventoryAccount = ""
            End Try
            Try
                GLCOGSAccount = Me.dgvItemClassList.Rows(RowIndex).Cells("GLCOGSAccountColumn").Value
            Catch ex As Exception
                GLCOGSAccount = ""
            End Try
            Try
                GLPurchasesAccount = Me.dgvItemClassList.Rows(RowIndex).Cells("GLPurchasesAccountColumn").Value
            Catch ex As Exception
                GLPurchasesAccount = ""
            End Try
            Try
                GLAdjustmentAccount = Me.dgvItemClassList.Rows(RowIndex).Cells("GLAdjustmentAccountColumn").Value
            Catch ex As Exception
                GLAdjustmentAccount = ""
            End Try
            Try
                GLIssuesAccount = Me.dgvItemClassList.Rows(RowIndex).Cells("GLIssuesAccountColumn").Value
            Catch ex As Exception
                GLIssuesAccount = ""
            End Try

            If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                VeryGLAccountsByDatgridLines()

                If VerifyGLAdjustmentAccount = "INVALID" Or VerifyGLCOGSAccount = "INVALID" Or VerifyGLInventoryAccount = "INVALID" Or VerifyGLIssuesAccount = "INVALID" Or VerifyGLPurchasesAccount = "INVALID" Or VerifyGLReturnsAccount = "INVALID" Or VerifyGLSalesAccount = "INVALID" Or VerifyGLSalesOffsetAccount = "INVALID" Or VerifyGLAdjustmentAccount = "" Or VerifyGLCOGSAccount = "" Or VerifyGLInventoryAccount = "INVALID" Or VerifyGLIssuesAccount = "" Or VerifyGLPurchasesAccount = "" Or VerifyGLReturnsAccount = "" Or VerifyGLSalesAccount = "" Or VerifyGLSalesOffsetAccount = "" Then
                    MsgBox("There are one or more invalid GL Accounts for this Item Class - fix and try again.", MsgBoxStyle.OkOnly)
                    ShowData()
                    Exit Sub
                Else
                    'Create command to update database and fill with text box enties
                    cmd = New SqlCommand("UPDATE ItemClass SET ItemClassName = @ItemClassName, GLSalesAccount = @GLSalesAccount, GLReturnsAccount = @GLReturnsAccount, GLInventoryAccount = @GLInventoryAccount, GLCOGSAccount = @GLCOGSAccount, GLPurchasesAccount = @GLPurchasesAccount, GLSalesOffsetAccount = @GLSalesOffsetAccount, GLAdjustmentAccount = @GLAdjustmentAccount, GLIssuesAccount = @GLIssuesAccount WHERE ItemClassID = @ItemClassID", con)

                    With cmd.Parameters
                        .Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClassID
                        .Add("@ItemClassName", SqlDbType.VarChar).Value = ItemClassName
                        .Add("@GLSalesAccount", SqlDbType.VarChar).Value = GLSalesAccount
                        .Add("@GLReturnsAccount", SqlDbType.VarChar).Value = GLReturnsAccount
                        .Add("@GLInventoryAccount", SqlDbType.VarChar).Value = GLInventoryAccount
                        .Add("@GLCOGSAccount", SqlDbType.VarChar).Value = GLCOGSAccount
                        .Add("@GLPurchasesAccount", SqlDbType.VarChar).Value = GLPurchasesAccount
                        .Add("@GLSalesOffsetAccount", SqlDbType.VarChar).Value = GLSalesOffsetAccount
                        .Add("@GLAdjustmentAccount", SqlDbType.VarChar).Value = GLAdjustmentAccount
                        .Add("@GLIssuesAccount", SqlDbType.VarChar).Value = GLIssuesAccount
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Else
                'Error Log
            End If
        Else
            'Skip Update
        End If
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM ItemClass", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ItemClass")
        dgvItemClassList.DataSource = ds.Tables("ItemClass")
        con.Close()
    End Sub

    Public Sub LoadItemClass()
        cmd = New SqlCommand("SELECT ItemClassID, ItemClassName FROM ItemClass", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemClass")
        cboItemClassID.DataSource = ds1.Tables("ItemClass")
        cboItemClassName.DataSource = ds1.Tables("ItemClass")
        con.Close()
        cboItemClassID.SelectedIndex = -1
        cboItemClassName.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        'Clear text boxes on load
        cboItemClassID.SelectedIndex = -1
        cboItemClassName.SelectedIndex = -1
        cboPurchaseClassID.SelectedIndex = -1
        cboSalesClassID.SelectedIndex = -1

        txtGLAdjustments.Clear()
        txtGLCOGS.Clear()
        txtGLInventory.Clear()
        txtGLIssues.Clear()
        txtGLPurchases.Clear()
        txtGLReturns.Clear()
        txtGLSales.Clear()
        txtGLSalesOffset.Clear()
        txtPurchaseClassName.Clear()
        txtSalesClassName.Clear()
        cboItemClassID.Focus()

        chkInventory.Checked = False

        'Set permissions
        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            cmdAddNewItemClass.Enabled = True
        Else
            cmdAddNewItemClass.Enabled = False
        End If
    End Sub

    Public Sub LoadItemClassData()
        Dim GLSalesAccountStatement As String = "SELECT GLSalesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLSalesAccountCommand As New SqlCommand(GLSalesAccountStatement, con)
        GLSalesAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClassID.Text

        Dim GLReturnsAccountStatement As String = "SELECT GLReturnsAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLReturnsAccountCommand As New SqlCommand(GLReturnsAccountStatement, con)
        GLReturnsAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClassID.Text

        Dim GLInventoryAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLInventoryAccountCommand As New SqlCommand(GLInventoryAccountStatement, con)
        GLInventoryAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClassID.Text

        Dim GLCOGSAccountStatement As String = "SELECT GLCOGSAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLCOGSAccountCommand As New SqlCommand(GLCOGSAccountStatement, con)
        GLCOGSAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClassID.Text

        Dim GLPurchasesAccountStatement As String = "SELECT GLPurchasesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLPurchasesAccountCommand As New SqlCommand(GLPurchasesAccountStatement, con)
        GLPurchasesAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClassID.Text

        Dim GLSalesOffsetAccountStatement As String = "SELECT GLSalesOffsetAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLSalesOffsetAccountCommand As New SqlCommand(GLSalesOffsetAccountStatement, con)
        GLSalesOffsetAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClassID.Text

        Dim GLAdjustmentAccountStatement As String = "SELECT GLAdjustmentAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLAdjustmentAccountCommand As New SqlCommand(GLAdjustmentAccountStatement, con)
        GLAdjustmentAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClassID.Text

        Dim GLIssuesAccountStatement As String = "SELECT GLIssuesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GLIssuesAccountCommand As New SqlCommand(GLIssuesAccountStatement, con)
        GLIssuesAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClassID.Text

        Dim InventoryItemStatement As String = "SELECT InventoryItem FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim InventoryItemCommand As New SqlCommand(InventoryItemStatement, con)
        InventoryItemCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClassID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GLSalesAccount = CStr(GLSalesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLSalesAccount = ""
        End Try
        Try
            GLReturnsAccount = CStr(GLReturnsAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLReturnsAccount = ""
        End Try
        Try
            GLInventoryAccount = CStr(GLInventoryAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLInventoryAccount = ""
        End Try
        Try
            GLCOGSAccount = CStr(GLCOGSAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLCOGSAccount = ""
        End Try
        Try
            GLPurchasesAccount = CStr(GLPurchasesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLPurchasesAccount = ""
        End Try
        Try
            GLSalesOffsetAccount = CStr(GLSalesOffsetAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLSalesOffsetAccount = ""
        End Try
        Try
            GLAdjustmentAccount = CStr(GLAdjustmentAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLAdjustmentAccount = ""
        End Try
        Try
            GLIssuesAccount = CStr(GLIssuesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLIssuesAccount = ""
        End Try
        Try
            InventoryItem = CStr(InventoryItemCommand.ExecuteScalar)
        Catch ex As Exception
            InventoryItem = "YES"
        End Try
        con.Close()

        If InventoryItem = "YES" Then
            chkInventory.Checked = True
        Else
            chkInventory.Checked = False
        End If

        txtGLAdjustments.Text = GLAdjustmentAccount
        txtGLCOGS.Text = GLCOGSAccount
        txtGLInventory.Text = GLInventoryAccount
        txtGLIssues.Text = GLIssuesAccount
        txtGLPurchases.Text = GLPurchasesAccount
        txtGLReturns.Text = GLReturnsAccount
        txtGLSales.Text = GLSalesAccount
        txtGLSalesOffset.Text = GLSalesOffsetAccount
    End Sub

    Public Sub VerifyGLAccount()
        Dim VerifyGLSalesAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLSalesAccountCommand As New SqlCommand(VerifyGLSalesAccountStatement, con)
        VerifyGLSalesAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = txtGLSales.Text

        Dim VerifyGLReturnsAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLReturnsAccountCommand As New SqlCommand(VerifyGLReturnsAccountStatement, con)
        VerifyGLReturnsAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = txtGLReturns.Text

        Dim VerifyGLInventoryAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLInventoryAccountCommand As New SqlCommand(VerifyGLInventoryAccountStatement, con)
        VerifyGLInventoryAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = txtGLInventory.Text

        Dim VerifyGLCOGSAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLCOGSAccountCommand As New SqlCommand(VerifyGLCOGSAccountStatement, con)
        VerifyGLCOGSAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = txtGLCOGS.Text

        Dim VerifyGLPurchasesAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLPurchasesAccountCommand As New SqlCommand(VerifyGLPurchasesAccountStatement, con)
        VerifyGLPurchasesAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = txtGLPurchases.Text

        Dim VerifyGLSalesOffsetAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLSalesOffsetAccountCommand As New SqlCommand(VerifyGLSalesOffsetAccountStatement, con)
        VerifyGLSalesOffsetAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = txtGLSalesOffset.Text

        Dim VerifyGLAdjustmentAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLAdjustmentAccountCommand As New SqlCommand(VerifyGLAdjustmentAccountStatement, con)
        VerifyGLAdjustmentAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = txtGLAdjustments.Text

        Dim VerifyGLIssuesAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLIssuesAccountCommand As New SqlCommand(VerifyGLIssuesAccountStatement, con)
        VerifyGLIssuesAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = txtGLIssues.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyGLSalesAccount = CStr(VerifyGLSalesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLSalesAccount = "INVALID"
        End Try
        Try
            VerifyGLReturnsAccount = CStr(VerifyGLReturnsAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLReturnsAccount = "INVALID"
        End Try
        Try
            VerifyGLInventoryAccount = CStr(VerifyGLInventoryAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLInventoryAccount = "INVALID"
        End Try
        Try
            VerifyGLCOGSAccount = CStr(VerifyGLCOGSAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLCOGSAccount = "INVALID"
        End Try
        Try
            VerifyGLPurchasesAccount = CStr(VerifyGLPurchasesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLPurchasesAccount = "INVALID"
        End Try
        Try
            VerifyGLSalesOffsetAccount = CStr(VerifyGLSalesOffsetAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLSalesOffsetAccount = "INVALID"
        End Try
        Try
            VerifyGLAdjustmentAccount = CStr(VerifyGLAdjustmentAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLAdjustmentAccount = "INVALID"
        End Try
        Try
            VerifyGLIssuesAccount = CStr(VerifyGLIssuesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLIssuesAccount = "INVALID"
        End Try
        con.Close()
    End Sub

    Public Sub VeryGLAccountsByDatgridLines()
        Dim VerifyGLSalesAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLSalesAccountCommand As New SqlCommand(VerifyGLSalesAccountStatement, con)
        VerifyGLSalesAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLSalesAccount

        Dim VerifyGLReturnsAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLReturnsAccountCommand As New SqlCommand(VerifyGLReturnsAccountStatement, con)
        VerifyGLReturnsAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLReturnsAccount

        Dim VerifyGLInventoryAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLInventoryAccountCommand As New SqlCommand(VerifyGLInventoryAccountStatement, con)
        VerifyGLInventoryAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLInventoryAccount

        Dim VerifyGLCOGSAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLCOGSAccountCommand As New SqlCommand(VerifyGLCOGSAccountStatement, con)
        VerifyGLCOGSAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLCOGSAccount

        Dim VerifyGLPurchasesAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLPurchasesAccountCommand As New SqlCommand(VerifyGLPurchasesAccountStatement, con)
        VerifyGLPurchasesAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPurchasesAccount

        Dim VerifyGLSalesOffsetAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLSalesOffsetAccountCommand As New SqlCommand(VerifyGLSalesOffsetAccountStatement, con)
        VerifyGLSalesOffsetAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLSalesOffsetAccount

        Dim VerifyGLAdjustmentAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLAdjustmentAccountCommand As New SqlCommand(VerifyGLAdjustmentAccountStatement, con)
        VerifyGLAdjustmentAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLAdjustmentAccount

        Dim VerifyGLIssuesAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim VerifyGLIssuesAccountCommand As New SqlCommand(VerifyGLIssuesAccountStatement, con)
        VerifyGLIssuesAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLIssuesAccount

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyGLSalesAccount = CStr(VerifyGLSalesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLSalesAccount = "INVALID"
        End Try
        Try
            VerifyGLReturnsAccount = CStr(VerifyGLReturnsAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLReturnsAccount = "INVALID"
        End Try
        Try
            VerifyGLInventoryAccount = CStr(VerifyGLInventoryAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLInventoryAccount = "INVALID"
        End Try
        Try
            VerifyGLCOGSAccount = CStr(VerifyGLCOGSAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLCOGSAccount = "INVALID"
        End Try
        Try
            VerifyGLPurchasesAccount = CStr(VerifyGLPurchasesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLPurchasesAccount = "INVALID"
        End Try
        Try
            VerifyGLSalesOffsetAccount = CStr(VerifyGLSalesOffsetAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLSalesOffsetAccount = "INVALID"
        End Try
        Try
            VerifyGLAdjustmentAccount = CStr(VerifyGLAdjustmentAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLAdjustmentAccount = "INVALID"
        End Try
        Try
            VerifyGLIssuesAccount = CStr(VerifyGLIssuesAccountCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyGLIssuesAccount = "INVALID"
        End Try
        con.Close()
    End Sub

    Private Sub cboItemClassID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemClassID.SelectedIndexChanged
        LoadItemClassData()
    End Sub

    Private Sub cboItemClassName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemClassName.SelectedIndexChanged
        LoadItemClassData()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearItemClass.Click
        'Clear text boxes and show full inventory list
        cboItemClassID.SelectedIndex = -1
        cboItemClassName.SelectedIndex = -1

        txtGLAdjustments.Clear()
        txtGLCOGS.Clear()
        txtGLInventory.Clear()
        txtGLIssues.Clear()
        txtGLPurchases.Clear()
        txtGLReturns.Clear()
        txtGLSales.Clear()
        txtGLSalesOffset.Clear()

        chkInventory.Checked = False

        cboItemClassID.Focus()
    End Sub

    Private Sub cmdClearSPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearSPL.Click
        'Clear text boxes
        cboSalesClassID.SelectedIndex = -1
        txtSalesClassName.Clear()
        cboSalesClassID.Focus()

        ShowData()
    End Sub

    Private Sub cmdClearPPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearPPL.Click
        'Clear text boxes
        cboPurchaseClassID.SelectedIndex = -1
        txtPurchaseClassName.Clear()
        cboPurchaseClassID.Focus()

        ShowData()
    End Sub

    Private Sub cmdAddNewSPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNewSPL.Click
        Try
            'Create command to update database and fill with text box enties
            cmd = New SqlCommand("Insert Into SalesProductLine(SalesProdLineID, SalesProdLineDescription )Values(@SalesProdLineID, @SalesProdLineDescription  )", con)

            With cmd.Parameters
                .Add("@SalesProdLineID", SqlDbType.VarChar).Value = cboSalesClassID.Text
                .Add("@SalesProdLineDescription", SqlDbType.VarChar).Value = txtSalesClassName.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Clear text boxes after entry
            cboSalesClassID.SelectedIndex = -1
            txtSalesClassName.Clear()
            MsgBox("A new Sales Class has been created", MsgBoxStyle.OkOnly)
            cboSalesClassID.Focus()
        Catch ex As Exception
            'Error Log
        End Try
    End Sub

    Private Sub cmdAddNewItemClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNewItemClass.Click
        If cboItemClassID.Text = "" Then
            MsgBox("You must have a valid Item Class ID selected.", MsgBoxStyle.OkOnly)
        Else
            'Verify that there is a valid GL Account
            VerifyGLAccount()

            If VerifyGLAdjustmentAccount = "INVALID" Or VerifyGLCOGSAccount = "INVALID" Or VerifyGLInventoryAccount = "INVALID" Or VerifyGLIssuesAccount = "INVALID" Or VerifyGLPurchasesAccount = "INVALID" Or VerifyGLReturnsAccount = "INVALID" Or VerifyGLSalesAccount = "INVALID" Or VerifyGLSalesOffsetAccount = "INVALID" Or VerifyGLAdjustmentAccount = "" Or VerifyGLCOGSAccount = "" Or VerifyGLInventoryAccount = "INVALID" Or VerifyGLIssuesAccount = "" Or VerifyGLPurchasesAccount = "" Or VerifyGLReturnsAccount = "" Or VerifyGLSalesAccount = "" Or VerifyGLSalesOffsetAccount = "" Then
                MsgBox("There are one or more invalid GL Accounts for this Item Class - fix and try again.", MsgBoxStyle.OkOnly)
            Else
                SaveUpdateItemClass()

                'Clear text boxes after entry
                ClearData()
                ShowData()

                MsgBox("A new Item Class has been created", MsgBoxStyle.OkOnly)

                cboItemClassID.Focus()
            End If
        End If
    End Sub

    Private Sub cmdAddNewPPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNewPPL.Click
        Try
            'Create command to update database and fill with text box enties
            cmd = New SqlCommand("Insert Into PurchaseProductLine(PurchaseProductLineID, PurchaseProductLineDescription )Values(@PurchaseProductLineID, @PurchaseProductLineDescription  )", con)

            With cmd.Parameters
                .Add("@PurchaseProductLineID", SqlDbType.VarChar).Value = cboPurchaseClassID.Text
                .Add("@PurchaseProductLineDescription", SqlDbType.VarChar).Value = txtPurchaseClassName.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Clear text boxes after entry
            cboPurchaseClassID.SelectedIndex = -1
            txtPurchaseClassName.Clear()
            MsgBox("A new Purchase Class has been created", MsgBoxStyle.OkOnly)
            cboPurchaseClassID.Focus()
        Catch ex As Exception
            'Error Log
        End Try
    End Sub

    Public Sub SaveUpdateItemClass()
        If chkInventory.Checked = True Then
            InventoryItem = "YES"
        Else
            InventoryItem = "NO"
        End If

        Try
            'Create command to update database and fill with text box enties
            cmd = New SqlCommand("Insert Into ItemClass(ItemClassID, ItemClassName, GLSalesAccount, GLReturnsAccount, GLInventoryAccount, GLCOGSAccount, GLPurchasesAccount, GLSalesOffsetAccount, GLAdjustmentAccount, GLIssuesAccount, InventoryItem)Values(@ItemClassID, @ItemClassName, @GLSalesAccount, @GLReturnsAccount, @GLInventoryAccount, @GLCOGSAccount, @GLPurchasesAccount, @GLSalesOffsetAccount, @GLAdjustmentAccount, @GLIssuesAccount, @InventoryItem)", con)

            With cmd.Parameters
                .Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClassID.Text
                .Add("@ItemClassName", SqlDbType.VarChar).Value = cboItemClassName.Text
                .Add("@GLSalesAccount", SqlDbType.VarChar).Value = txtGLSales.Text
                .Add("@GLReturnsAccount", SqlDbType.VarChar).Value = txtGLReturns.Text
                .Add("@GLInventoryAccount", SqlDbType.VarChar).Value = txtGLInventory.Text
                .Add("@GLCOGSAccount", SqlDbType.VarChar).Value = txtGLCOGS.Text
                .Add("@GLPurchasesAccount", SqlDbType.VarChar).Value = txtGLPurchases.Text
                .Add("@GLSalesOffsetAccount", SqlDbType.VarChar).Value = txtGLSalesOffset.Text
                .Add("@GLAdjustmentAccount", SqlDbType.VarChar).Value = txtGLAdjustments.Text
                .Add("@GLIssuesAccount", SqlDbType.VarChar).Value = txtGLIssues.Text
                .Add("@InventoryItem", SqlDbType.VarChar).Value = InventoryItem
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Create command to update database and fill with text box enties
            cmd = New SqlCommand("UPDATE ItemClass SET ItemClassName = @ItemClassName, GLSalesAccount = @GLSalesAccount, GLReturnsAccount = @GLReturnsAccount, GLInventoryAccount = @GLInventoryAccount, GLCOGSAccount = @GLCOGSAccount, GLPurchasesAccount = @GLPurchasesAccount, GLSalesOffsetAccount = @GLSalesOffsetAccount, GLAdjustmentAccount = @GLAdjustmentAccount, GLIssuesAccount = @GLIssuesAccount, InventoryItem = @InventoryItem WHERE ItemClassID = @ItemClassID", con)

            With cmd.Parameters
                .Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClassID.Text
                .Add("@ItemClassName", SqlDbType.VarChar).Value = cboItemClassName.Text
                .Add("@GLSalesAccount", SqlDbType.VarChar).Value = txtGLSales.Text
                .Add("@GLReturnsAccount", SqlDbType.VarChar).Value = txtGLReturns.Text
                .Add("@GLInventoryAccount", SqlDbType.VarChar).Value = txtGLInventory.Text
                .Add("@GLCOGSAccount", SqlDbType.VarChar).Value = txtGLCOGS.Text
                .Add("@GLPurchasesAccount", SqlDbType.VarChar).Value = txtGLPurchases.Text
                .Add("@GLSalesOffsetAccount", SqlDbType.VarChar).Value = txtGLSalesOffset.Text
                .Add("@GLAdjustmentAccount", SqlDbType.VarChar).Value = txtGLAdjustments.Text
                .Add("@GLIssuesAccount", SqlDbType.VarChar).Value = txtGLIssues.Text
                .Add("@InventoryItem", SqlDbType.VarChar).Value = InventoryItem
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        ClearData()
        ShowData()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub chkInventory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInventory.CheckedChanged
        If chkInventory.Checked = True Then
            InventoryItem = "YES"
        Else
            InventoryItem = "NO"
        End If
    End Sub
End Class