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
Public Class NonInventoryItems
    Inherits System.Windows.Forms.Form

    Dim CreditShortDescription, DebitShortDescription, CreationDate, Comment, GLCreditAccount, GLDebitAccount, ItemClass, ShortDescription, LongDescription, PurchaseProductLine, SalesProductLine, PreferredVendor As String
    Dim StandardCost As Double
    Dim StandardOrderQuantity As Integer
    Dim CurrentDivision As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub NonInventoryItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.GLAccounts' table. You can move, or remove it, as needed.
        Me.GLAccountsTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.GLAccounts)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PurchaseProductLine' table. You can move, or remove it, as needed.
        Me.PurchaseProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PurchaseProductLine)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.SalesProductLine' table. You can move, or remove it, as needed.
        Me.SalesProductLineTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.SalesProductLine)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        usefulFunctions.LoadSecurity(Me)
        cboDivisionID.Text = EmployeeCompanyCode
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM NonInventoryItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "NonInventoryItemList")
        dgvNonInventoryItemList.DataSource = ds.Tables("NonInventoryItemList")
        con.Close()
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "Vendor")
        cboPreferredVendor.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboPreferredVendor.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM NonInventoryItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "NonInventoryItemList")
        cboPartNumber.DataSource = ds2.Tables("NonInventoryItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM NonInventoryItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "NonInventoryItemList")
        cboShortDescription.DataSource = ds3.Tables("NonInventoryItemList")
        con.Close()
        cboShortDescription.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        'Clear text boxes
        txtComment.Refresh()
        txtLongDescription.Refresh()
        txtStandardCost.Refresh()
        txtStandardOrderQuantity.Refresh()
        txtComment.Refresh()
        txtLongDescription.Refresh()
        txtCreditDescription.Refresh()
        txtDebitDescription.Refresh()

        cboShortDescription.Refresh()
        cboPartNumber.Refresh()
        cboPreferredVendor.Refresh()
        cboPurchaseProductLineID.Refresh()
        cboSalesProductLineID.Refresh()
        cboItemClass.Refresh()
        cboCreditGLAccount.Refresh()
        cboDebitGLAccount.Refresh()
        cboPartNumber.Refresh()

        cboPartNumber.SelectedIndex = -1
        cboPreferredVendor.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboShortDescription.SelectedIndex = -1
        cboCreditGLAccount.SelectedIndex = -1
        cboDebitGLAccount.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPurchaseProductLineID.SelectedIndex = -1
        cboSalesProductLineID.SelectedIndex = -1

        txtComment.Clear()
        txtLongDescription.Clear()
        txtStandardCost.Clear()
        txtStandardOrderQuantity.Clear()
        txtComment.Clear()
        txtLongDescription.Clear()
        txtCreditDescription.Clear()
        txtDebitDescription.Clear()

        chkCreateAll.Checked = False

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        CreditShortDescription = ""
        DebitShortDescription = ""
        CreationDate = ""
        Comment = ""
        GLCreditAccount = ""
        GLDebitAccount = ""
        ItemClass = ""
        ShortDescription = ""
        LongDescription = ""
        PurchaseProductLine = ""
        SalesProductLine = ""
        PreferredVendor = ""
        StandardCost = 0
        StandardOrderQuantity = 0
    End Sub

    Public Sub LoadNonInventoryData()
        Dim LongDescriptionStatement As String = "SELECT LongDescription FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ItemClassStatement As String = "SELECT ItemClass FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
        ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PurchaseProductLineStatement As String = "SELECT PurchaseProductLineID FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PurchaseProductLineCommand As New SqlCommand(PurchaseProductLineStatement, con)
        PurchaseProductLineCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PurchaseProductLineCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SalesProductLineStatement As String = "SELECT SalesProductLine FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim SalesProductLineCommand As New SqlCommand(SalesProductLineStatement, con)
        SalesProductLineCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        SalesProductLineCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim StandardCostStatement As String = "SELECT StandardCost FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
        StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim StandardOrderQuantityStatement As String = "SELECT StandardOrderQuantity FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim StandardOrderQuantityCommand As New SqlCommand(StandardOrderQuantityStatement, con)
        StandardOrderQuantityCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        StandardOrderQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PreferredVendorStatement As String = "SELECT PreferredVendor FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PreferredVendorCommand As New SqlCommand(PreferredVendorStatement, con)
        PreferredVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PreferredVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreationDateStatement As String = "SELECT CreationDate FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CreationDateCommand As New SqlCommand(CreationDateStatement, con)
        CreationDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CreationDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CommentStatement As String = "SELECT Comment FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CommentCommand As New SqlCommand(CommentStatement, con)
        CommentCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim GLDebitAccountStatement As String = "SELECT GLDebitAccount FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GLDebitAccountCommand As New SqlCommand(GLDebitAccountStatement, con)
        GLDebitAccountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        GLDebitAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim GLCreditAccountStatement As String = "SELECT GLCreditAccount FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GLCreditAccountCommand As New SqlCommand(GLCreditAccountStatement, con)
        GLCreditAccountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        GLCreditAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LongDescription = CStr(LongDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            LongDescription = ""
        End Try
        Try
            ItemClass = CStr(ItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            ItemClass = "EXPENSES"
        End Try
        Try
            PurchaseProductLine = CStr(PurchaseProductLineCommand.ExecuteScalar)
        Catch ex As Exception
            PurchaseProductLine = "EXPENSES"
        End Try
        Try
            SalesProductLine = CStr(SalesProductLineCommand.ExecuteScalar)
        Catch ex As Exception
            SalesProductLine = "SUPPLY"
        End Try
        Try
            StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
        Catch ex As Exception
            StandardCost = 0
        End Try
        Try
            StandardOrderQuantity = CInt(StandardOrderQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            StandardOrderQuantity = 1
        End Try
        Try
            PreferredVendor = CStr(PreferredVendorCommand.ExecuteScalar)
        Catch ex As Exception
            PreferredVendor = ""
        End Try
        Try
            CreationDate = CStr(CreationDateCommand.ExecuteScalar)
        Catch ex As Exception
            CreationDate = ""
        End Try
        Try
            Comment = CStr(CommentCommand.ExecuteScalar)
        Catch ex As Exception
            Comment = ""
        End Try
        Try
            GLDebitAccount = CStr(GLDebitAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLDebitAccount = "78000"
        End Try
        Try
            GLCreditAccount = CStr(GLCreditAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GLCreditAccount = "20000"
        End Try
        con.Close()

        cboPreferredVendor.Text = PreferredVendor
        cboPurchaseProductLineID.Text = PurchaseProductLine
        cboSalesProductLineID.Text = SalesProductLine
        txtComment.Text = Comment
        txtLongDescription.Text = LongDescription
        txtStandardCost.Text = StandardCost
        txtStandardOrderQuantity.Text = StandardOrderQuantity
        cboCreditGLAccount.Text = GLCreditAccount
        cboDebitGLAccount.Text = GLDebitAccount
        cboItemClass.Text = ItemClass
    End Sub

    Public Sub LoadDebitDescription()
        Dim DebitShortDescriptionStatement As String = "SELECT GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim DebitShortDescriptionCommand As New SqlCommand(DebitShortDescriptionStatement, con)
        DebitShortDescriptionCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboDebitGLAccount.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DebitShortDescription = CStr(DebitShortDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            DebitShortDescription = ""
        End Try
        con.Close()

        txtDebitDescription.Text = DebitShortDescription
    End Sub

    Public Sub LoadCreditDescription()
        Dim CreditShortDescriptionStatement As String = "SELECT GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim CreditShortDescriptionCommand As New SqlCommand(CreditShortDescriptionStatement, con)
        CreditShortDescriptionCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboCreditGLAccount.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CreditShortDescription = CStr(CreditShortDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            CreditShortDescription = ""
        End Try
        con.Close()

        txtCreditDescription.Text = CreditShortDescription
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadNonInventoryData()
        LoadDescriptionByPart()
    End Sub

    Private Sub cboShortDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShortDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        'Load Defaults
        LoadPartNumber()
        LoadPartDescription()
        LoadVendor()
        ClearData()
        ShowData()
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM NonInventoryItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboShortDescription.Text
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

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
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

        cboShortDescription.Text = PartDescription1
    End Sub

    Private Sub dgvNonInventoryItemList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNonInventoryItemList.CellValueChanged
        If dgvNonInventoryItemList.RowCount = 0 Then
            'Skip
        Else
            Dim RowPartNumber, RowPartDescription, RowComment, RowCreditAccount, RowDebitAccount, RowDivision, RowSPL, RowPPL, RowItemClass, RowVendor As String
            Dim RowStandardCost As Double = 0

            Dim RowIndex As Integer = Me.dgvNonInventoryItemList.CurrentCell.RowIndex

            Try
                RowPartNumber = Me.dgvNonInventoryItemList.Rows(RowIndex).Cells("ItemIDColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowPartDescription = Me.dgvNonInventoryItemList.Rows(RowIndex).Cells("ShortDescriptionColumn").Value
            Catch ex As Exception
                RowPartDescription = ""
            End Try
            Try
                RowItemClass = Me.dgvNonInventoryItemList.Rows(RowIndex).Cells("ItemClassColumn").Value
            Catch ex As Exception
                RowItemClass = ""
            End Try
            Try
                RowPPL = Me.dgvNonInventoryItemList.Rows(RowIndex).Cells("PurchaseProductLineColumn").Value
            Catch ex As Exception
                RowPPL = ""
            End Try
            Try
                RowSPL = Me.dgvNonInventoryItemList.Rows(RowIndex).Cells("SalesProductLineColumn").Value
            Catch ex As Exception
                RowSPL = ""
            End Try
            Try
                RowStandardCost = Me.dgvNonInventoryItemList.Rows(RowIndex).Cells("StandardCostColumn").Value
            Catch ex As Exception
                RowStandardCost = 0
            End Try
            Try
                RowDivision = Me.dgvNonInventoryItemList.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try
            Try
                RowVendor = Me.dgvNonInventoryItemList.Rows(RowIndex).Cells("PreferredVendorColumn").Value
            Catch ex As Exception
                RowVendor = ""
            End Try
            Try
                RowComment = Me.dgvNonInventoryItemList.Rows(RowIndex).Cells("CommentColumn").Value
            Catch ex As Exception
                RowComment = ""
            End Try
            Try
                RowDebitAccount = Me.dgvNonInventoryItemList.Rows(RowIndex).Cells("GLDebitAccountColumn").Value
            Catch ex As Exception
                RowDebitAccount = ""
            End Try
            Try
                RowCreditAccount = Me.dgvNonInventoryItemList.Rows(RowIndex).Cells("GLCreditAccountColumn").Value
            Catch ex As Exception
                RowCreditAccount = ""
            End Try
            '***********************************************************************************
            'Validate Fields
            Dim CheckForItemClass As Integer = 0
            Dim CheckForDebitAccount As Integer = 0
            Dim CheckForCreditAccount As Integer = 0

            Dim CheckForItemClassStatement As String = "SELECT COUNT(ItemClassID) FROM ItemClass WHERE ItemClassID = @ItemClassID"
            Dim CheckForItemClassCommand As New SqlCommand(CheckForItemClassStatement, con)
            CheckForItemClassCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = RowItemClass

            Dim CheckForDebitAccountStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
            Dim CheckForDebitAccountCommand As New SqlCommand(CheckForDebitAccountStatement, con)
            CheckForDebitAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = RowDebitAccount

            Dim CheckForCreditAccountStatement As String = "SELECT COUNT(GLAccountNumber) FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
            Dim CheckForCreditAccountCommand As New SqlCommand(CheckForCreditAccountStatement, con)
            CheckForCreditAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = RowCreditAccount

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckForItemClass = CInt(CheckForItemClassCommand.ExecuteScalar)
            Catch ex As Exception
                CheckForItemClass = 0
            End Try
            Try
                CheckForDebitAccount = CInt(CheckForDebitAccountCommand.ExecuteScalar)
            Catch ex As Exception
                CheckForDebitAccount = 0
            End Try
            Try
                CheckForCreditAccount = CInt(CheckForCreditAccountCommand.ExecuteScalar)
            Catch ex As Exception
                CheckForCreditAccount = 0
            End Try
            con.Close()

            If CheckForItemClass = 0 Then
                MsgBox("Invalid Item Class. Changes will not be saved.", MsgBoxStyle.OkOnly)
                ShowData()
                Exit Sub
            End If

            If CheckForDebitAccount = 0 Then
                MsgBox("Invalid Debit Account. Changes will not be saved.", MsgBoxStyle.OkOnly)
                ShowData()
                Exit Sub
            End If

            If CheckForCreditAccount = 0 Then
                MsgBox("Invalid Credit Account. Changes will not be saved.", MsgBoxStyle.OkOnly)
                ShowData()
                Exit Sub
            End If

            If RowPartDescription = "" Then
                MsgBox("Invalid part description. Changes will not be saved.", MsgBoxStyle.OkOnly)
                ShowData()
                Exit Sub
            End If
            '******************************************************************************************
            'Save changes in datagrid
            cmd = New SqlCommand("UPDATE NonInventoryItemList SET ShortDescription = @ShortDescription, ItemClass = @ItemClass, PurchaseProductLine = @PurchaseProductLine, SalesProductLine = @SalesProductLine, StandardCost = @StandardCost, PreferredVendor = @PreferredVendor, Comment = @Comment, GLDebitAccount = @GLDebitAccount, GLCreditAccount = @GLCreditAccount WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                .Add("@ShortDescription", SqlDbType.VarChar).Value = RowPartDescription
                '.Add("@LongDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
                .Add("@ItemClass", SqlDbType.VarChar).Value = RowItemClass
                .Add("@PurchaseProductLine", SqlDbType.VarChar).Value = RowPPL
                .Add("@SalesProductLine", SqlDbType.VarChar).Value = RowSPL
                .Add("@StandardCost", SqlDbType.VarChar).Value = RowStandardCost
                '.Add("@StandardOrderQuantity", SqlDbType.VarChar).Value = Val(txtStandardOrderQuantity.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                '.Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                .Add("@PreferredVendor", SqlDbType.VarChar).Value = RowVendor
                .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                .Add("@GLDebitAccount", SqlDbType.VarChar).Value = RowDebitAccount
                .Add("@GLCreditAccount", SqlDbType.VarChar).Value = RowCreditAccount
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Public Sub InsertIntoNonInventoryList()
        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("Insert Into NonInventoryItemList(ItemID, ShortDescription, LongDescription, ItemClass, PurchaseProductLine, SalesProductLine, StandardCost, StandardOrderQuantity, DivisionID, CreationDate, PreferredVendor, Comment, GLDebitAccount, GLCreditAccount)Values(@ItemID, @ShortDescription, @LongDescription, @ItemClass, @PurchaseProductLine, @SalesProductLine, @StandardCost, @StandardOrderQuantity, @DivisionID, @CreationDate, @PreferredVendor, @Comment, @GLDebitAccount, @GLCreditAccount)", con)

        With cmd.Parameters
            .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@ShortDescription", SqlDbType.VarChar).Value = cboShortDescription.Text
            .Add("@LongDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
            .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
            .Add("@PurchaseProductLine", SqlDbType.VarChar).Value = cboPurchaseProductLineID.Text
            .Add("@SalesProductLine", SqlDbType.VarChar).Value = cboSalesProductLineID.Text
            .Add("@StandardCost", SqlDbType.VarChar).Value = Val(txtStandardCost.Text)
            .Add("@StandardOrderQuantity", SqlDbType.VarChar).Value = Val(txtStandardOrderQuantity.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision
            .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
            .Add("@PreferredVendor", SqlDbType.VarChar).Value = cboPreferredVendor.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@GLDebitAccount", SqlDbType.VarChar).Value = cboDebitGLAccount.Text
            .Add("@GLCreditAccount", SqlDbType.VarChar).Value = cboCreditGLAccount.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub UpdateNonInventoryList()
        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("UPDATE NonInventoryItemList SET ShortDescription = @ShortDescription, LongDescription = @LongDescription, ItemClass = @ItemClass, PurchaseProductLine = @PurchaseProductLine, SalesProductLine = @SalesProductLine, StandardCost = @StandardCost, StandardOrderQuantity = @StandardOrderQuantity, CreationDate = @CreationDate, PreferredVendor = @PreferredVendor, Comment = @Comment, GLDebitAccount = @GLDebitAccount, GLCreditAccount = @GLCreditAccount WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@ShortDescription", SqlDbType.VarChar).Value = cboShortDescription.Text
            .Add("@LongDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
            .Add("@ItemClass", SqlDbType.VarChar).Value = cboItemClass.Text
            .Add("@PurchaseProductLine", SqlDbType.VarChar).Value = cboPurchaseProductLineID.Text
            .Add("@SalesProductLine", SqlDbType.VarChar).Value = cboSalesProductLineID.Text
            .Add("@StandardCost", SqlDbType.VarChar).Value = Val(txtStandardCost.Text)
            .Add("@StandardOrderQuantity", SqlDbType.VarChar).Value = Val(txtStandardOrderQuantity.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = CurrentDivision
            .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
            .Add("@PreferredVendor", SqlDbType.VarChar).Value = cboPreferredVendor.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@GLDebitAccount", SqlDbType.VarChar).Value = cboDebitGLAccount.Text
            .Add("@GLCreditAccount", SqlDbType.VarChar).Value = cboCreditGLAccount.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        If cboPartNumber.Text = "" Or cboShortDescription.Text = "" Then
            MsgBox("You must have a valid part # and description.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboCreditGLAccount.Text = "" Or cboDebitGLAccount.Text = "" Then
            MsgBox("You must have a valid G/L Accounts", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a specific division.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '***************************************************************************************
        If chkCreateAll.Checked = True Then
            'Create Non-inventory item in all divisions

            'Add part to each division
            Try
                CurrentDivision = "ATL"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "ATL"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "CBS"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "CBS"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "CGO"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "CGO"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "CHT"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "CHT"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "DEN"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "DEN"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "HOU"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "HOU"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "SLC"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "SLC"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "TFF"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "TFF"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "TFT"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "TFT"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "TWD"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "TWD"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "TWE"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "TWE"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "TOR"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "TOR"
                UpdateNonInventoryList()
            End Try

            Try
                CurrentDivision = "ALB"
                InsertIntoNonInventoryList()
            Catch ex As Exception
                CurrentDivision = "ALB"
                UpdateNonInventoryList()
            End Try

            'Clear the text boxes
            ClearVariables()
            ClearData()
            ShowData()
            MsgBox("Part has been created in all divisions.", MsgBoxStyle.OkOnly)
        Else
            Try
                CurrentDivision = cboDivisionID.Text

                InsertIntoNonInventoryList()

                'Clear the text boxes
                ClearVariables()
                ClearData()
                ShowData()
                MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                CurrentDivision = cboDivisionID.Text

                UpdateNonInventoryList()

                'Clear the text boxes
                ClearVariables()
                ClearData()
                ShowData()
                MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub cboDebitGLAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDebitGLAccount.SelectedIndexChanged
        LoadDebitDescription()
    End Sub

    Private Sub cboCreditGLAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCreditGLAccount.SelectedIndexChanged
        LoadCreditDescription()
    End Sub

    Private Sub cmdClearLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLines.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintNonInventoryItems As New PrintNonInventoryItems
            Dim Result = NewPrintNonInventoryItems.ShowDialog
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboPartNumber.Text = "" Then
            MsgBox("You must have a valid Non-Inventory Item selected.", MsgBoxStyle.OkOnly)
        Else
            'Check for activity
            Dim CheckForActivity As Integer = 0

            Dim CheckForActivityStatement As String = "SELECT COUNT(PartNumber) FROM ReceiptOfInvoiceVoucherLines WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim CheckForActivityCommand As New SqlCommand(CheckForActivityStatement, con)
            CheckForActivityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            CheckForActivityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckForActivity = CInt(CheckForActivityCommand.ExecuteScalar)
            Catch ex As Exception
                CheckForActivity = 0
            End Try
            con.Close()

            If CheckForActivity <> 0 Then
                MsgBox("This part has activity and cannot be deleted.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'Validate deletion of data
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Non-Inventory Item?", "DELETE ITEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete from table
                cmd = New SqlCommand("Delete FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear text boxes after deletion
                ClearVariables()
                ClearData()
                ShowData()
            ElseIf button = DialogResult.No Then
                MsgBox("Data will not be deleted.", MsgBoxStyle.OkOnly)
                cmdDelete.Focus()
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

End Class