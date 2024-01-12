Imports System.Math
Imports System.Data.SqlClient

Public Class APCreateRecurringVouchers
    Inherits System.Windows.Forms.Form

    Dim VendorName As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, dsDGV, dsBackup As DataSet

    Dim DiscountPercent As Double
    Dim DiscountDays, DueDays As Integer
    Dim batchNumber As Integer = 0

    Dim isloaded As Boolean = False

    ''Dim EmployeeCompanyCode As String = "TST"

    Private Sub APcreateRecurringVouchers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDivisionID()
        cboDivisionID.Text = EmployeeCompanyCode
        LoadPaymentTerms()
        setDataGridView()
        LoadDataGridView()
        isloaded = True
    End Sub

    Public Sub ShowVoucherLines()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber;", con)
        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = 0
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "ReceiptOfInvoiceVoucherLines")
        con.Close()

        cboVoucherLine.DisplayMember = "VoucherNumber"
        dgvVoucherLines.DataSource = ds.Tables("ReceiptOfInvoiceVoucherLines")
        cboVoucherLine.DataSource = ds.Tables("ReceiptOfInvoiceVoucherLines")
    End Sub

    Public Sub LoadVendor()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "Vendor")
        con.Close()

        cboVendorID.DisplayMember = "VendorCode"
        cboVendorID.DataSource = ds1.Tables("Vendor")
        cboVendorID.SelectedIndex = -1
    End Sub

    Private Sub LoadVendorClass()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT DISTINCT(VendorClass) FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        ds6 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds6, "Vendor")
        con.Close()

        cboVendorClass.DisplayMember = "VendorClass"
        cboVendorClass.DataSource = ds6.Tables("Vendor")
        cboVendorClass.SelectedIndex = -1
    End Sub

    Private Sub LoadDivisionID()
        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable;", con)
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "DivisionTable")
        con.Close()

        cboDivisionID.DisplayMember = "DivisionKey"
        cboDivisionID.DataSource = ds2.Tables("DivisionTable")
        cboDivisionID.SelectedIndex = -1
    End Sub

    Private Sub LoadPaymentTerms()
        cmd = New SqlCommand("SELECT PmtTermsID FROM PaymentTerms;", con)
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "PaymentTerms")
        con.Close()

        cboPaymentTerms.DisplayMember = "PmtTermsID"
        cboPaymentTerms.DataSource = ds3.Tables("PaymentTerms")
        cboPaymentTerms.SelectedIndex = -1
    End Sub

    Public Sub LoadNonInventoryItems()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT ItemID FROM NonInventoryItemList WHERE DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "NonInventoryItemList")
        con.Close()

        cboItemID.DisplayMember = "ItemID"
        cboItemID.DataSource = ds4.Tables("NonInventoryItemList")
        cboItemID.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccounts()
        'Load GL Accounts
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber < @Canadian;", con)
        cmd.Parameters.Add("@Canadian", SqlDbType.VarChar).Value = "C$"
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "GLAccounts")
        con.Close()

        cboDebitAccount.DisplayMember = "GLAccountNumber"
        cboDebitDescription.DisplayMember = "GLAccountShortDescription"
        cboDebitAccount.DataSource = ds5.Tables("GLAccounts")
        cboDebitDescription.DataSource = ds5.Tables("GLAccounts")
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        If isloaded Then
            LoadVendorName()
            If cboVendorID.SelectedIndex = -1 Then
                cboVendorClass.Text = ""
            Else
                cboVendorClass.Text = ds1.Tables("Vendor").Rows(cboVendorID.SelectedIndex).Item("VendorClass")
            End If
        End If
    End Sub

    Public Sub LoadVendorName()
        Dim paymentTerms As String = ""
        Dim CheckCode As String = ""

        Dim VendorNameString As String = "SELECT VendorName, PaymentTerms, CheckCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID;"
        Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = VendorNameCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("VendorName")) Then
                VendorName = ""
            Else
                VendorName = reader.Item("VendorName")
            End If
            If IsDBNull(reader.Item("PaymentTerms")) Then
                paymentTerms = ""
            Else
                paymentTerms = reader.Item("PaymentTerms")
            End If
            If IsDBNull(reader.Item("CheckCode")) Then
                CheckCode = ""
            Else
                CheckCode = reader.Item("CheckCode")
            End If
        Else
            VendorName = ""
            paymentTerms = ""
            CheckCode = ""
        End If
        reader.Close()
        con.Close()

        txtVendorName.Text = VendorName
        cboPaymentTerms.Text = paymentTerms
        cboCheckType.Text = CheckCode
    End Sub

    Private Sub setDataGridView()
        dsDGV = New DataSet()
        dsDGV.Tables.Add("Lines")
        dsDGV.Tables("Lines").Columns.Add("LineNumber")
        dsDGV.Tables("Lines").Columns.Add("ItemNumber")
        dsDGV.Tables("Lines").Columns.Add("Description")
        dsDGV.Tables("Lines").Columns.Add("Quantity")
        dsDGV.Tables("Lines").Columns.Add("UnitCost")
        dsDGV.Tables("Lines").Columns.Add("ExtendedAmount")
        dsDGV.Tables("Lines").Columns.Add("GLDebitAccount")
        dsDGV.Tables("Lines").Columns.Add("GLCreditAccount")
        dsBackup = New DataSet()
        dsBackup = dsDGV.Clone()
    End Sub

    Private Sub LoadDataGridView()
        dgvVoucherLines.DataSource = dsDGV.Tables("Lines")
        dgvVoucherLines.Columns("LineNumber").HeaderText = "Line #"
        dgvVoucherLines.Columns("LineNumber").ReadOnly = True
        dgvVoucherLines.Columns("ItemNumber").HeaderText = "Item"
        dgvVoucherLines.Columns("ItemNumber").ReadOnly = True
        dgvVoucherLines.Columns("UnitCost").HeaderText = "Unit Cost"
        dgvVoucherLines.Columns("ExtendedAmount").HeaderText = "Extended Amount"
        dgvVoucherLines.Columns("ExtendedAmount").ReadOnly = True
        dgvVoucherLines.Columns("GLDebitAccount").HeaderText = "GL Debit Account"
        dgvVoucherLines.Columns("GLDebitAccount").ReadOnly = True
        dgvVoucherLines.Columns("GLCreditAccount").HeaderText = "GL Credit Account"
        dgvVoucherLines.Columns("GLCreditAccount").ReadOnly = True
        LoadDelete()
    End Sub

    Private Sub LoadDelete()
        cboVoucherLine.DataSource = dsDGV.Tables("Lines")
        cboVoucherLine.DisplayMember = "LineNumber"
        If dgvVoucherLines.Rows.Count > 0 Then
            cboVoucherLine.SelectedIndex = 0
        Else
            isloaded = False
            cboVoucherLine.Text = ""
            isloaded = True
            txtLinePartNumber.Text = ""
            txtLinePartDescription.Text = ""
        End If
    End Sub

    Public Sub LoadItemData()
        cmd = New SqlCommand("SELECT LongDescription, GLDebitAccount, GLCreditAccount FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboItemID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LongDescription")) Then
                txtLongDescription.Text = ""
            Else
                txtLongDescription.Text = reader.Item("LongDescription")
            End If
            If IsDBNull(reader.Item("GLDebitAccount")) Then
                cboDebitAccount.Text = ""
            Else
                cboDebitAccount.Text = reader.Item("GLDebitAccount")
            End If
            If IsDBNull(reader.Item("GLCreditAccount")) Then
                cboCreditAccount.Text = ""
            Else
                cboCreditAccount.Text = reader.Item("GLCreditAccount")
            End If
        Else
            txtLongDescription.Text = ""
            cboDebitAccount.Text = ""
            cboCreditAccount.Text = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadGLAccounts()
        LoadNonInventoryItems()
        LoadVendor()
        LoadVendorClass()
    End Sub

    Private Sub chkManualDiscount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManualDiscount.CheckedChanged
        If chkManualDiscount.Checked Then
            txtDiscountAmount.ReadOnly = False
        Else
            txtDiscountAmount.ReadOnly = True
        End If
    End Sub

    Private Sub txtSalesTaxTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTaxTotal.TextChanged
        updateInvoiceTotal()
    End Sub

    Private Sub updateInvoiceTotal()
        If isloaded Then
            txtInvoiceTotal.Text = FormatCurrency(updateProductTotal() + Val(txtFreightTotal.Text) + Val(txtSalesTaxTotal.Text), 2)
        End If
    End Sub

    Private Sub txtFreightTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightTotal.TextChanged
        updateInvoiceTotal()
    End Sub

    Private Sub txtPurchaseTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPurchaseTotal.TextChanged
        updateInvoiceTotal()
    End Sub

    Private Sub cmdEnterLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterLine.Click
        If canAddLine() Then
            ''takes the entered data for the line and adds it to the dataset and the datagridview
            dsDGV.Tables("Lines").Rows.Add(dsDGV.Tables("Lines").Rows.Count + 1, cboItemID.Text, txtLongDescription.Text, txtQuantity.Text, txtUnitCost.Text, txtExtendedAmount.Text, cboDebitAccount.Text, cboCreditAccount.Text)
            dsBackup.Tables("Lines").Rows.Add(dsDGV.Tables("Lines").Rows.Count + 1, cboItemID.Text, txtLongDescription.Text, txtQuantity.Text, txtUnitCost.Text, txtExtendedAmount.Text, cboDebitAccount.Text, cboCreditAccount.Text)
            updateProductTotal()
            LoadDelete()
            cmdClear_Click(sender, e)
        End If
    End Sub

    Private Function canAddLine() As Boolean
        If String.IsNullOrEmpty(cboItemID.Text) Then
            MessageBox.Show("You must enter an item to add", "Enter an Item to add", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboItemID.Focus()
            Return False
        End If
        If cboItemID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Item", "Enter a vlaid Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboItemID.SelectAll()
            cboItemID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtLongDescription.Text) Then
            MessageBox.Show("You must have a description entered", "Enter a description", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLongDescription.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtQuantity.Text) Then
            MessageBox.Show("You must enter a quantity", "Enter a quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Return False
        End If
        If IsNumeric(txtQuantity.Text) = False Then
            MessageBox.Show("You must enter a number for quantity", "Enter a number for quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.SelectAll()
            txtQuantity.Focus()
            Return False
        End If
        If Val(txtQuantity.Text) < 1 Then
            MessageBox.Show("You must enter a quantity greater than 0", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.SelectAll()
            txtQuantity.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtUnitCost.Text) Then
            MessageBox.Show("You must enter a unit cost", "Enter a unit cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitCost.Focus()
            Return False
        End If
        If IsNumeric(txtUnitCost.Text) = False Then
            MessageBox.Show("You must enter a number for unit cost", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitCost.SelectAll()
            txtUnitCost.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub updateExtendedAmount()
        If isloaded Then
            txtExtendedAmount.Text = Math.Round(Val(txtQuantity.Text) * Val(txtUnitCost.Text), 2)
        End If
    End Sub

    Private Sub txtUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitCost.TextChanged
        updateExtendedAmount()
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        updateExtendedAmount()
    End Sub

    Private Sub cboItemID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemID.SelectedIndexChanged
        If isloaded Then
            LoadItemData()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboItemID.SelectedIndex = -1
        txtQuantity.Text = ""
        txtUnitCost.Text = ""
        txtExtendedAmount.Text = ""
        cboDebitDescription.SelectedIndex = -1
    End Sub

    Private Sub cboVoucherLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVoucherLine.SelectedIndexChanged
        If isloaded Then
            If cboVoucherLine.SelectedIndex <> -1 Then
                txtLinePartNumber.Text = dsDGV.Tables("Lines").Rows(Val(cboVoucherLine.Text) - 1).Item("ItemNumber")
                txtLinePartDescription.Text = dsDGV.Tables("Lines").Rows(Val(cboVoucherLine.Text) - 1).Item("Description")
            End If
        End If
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If cboVoucherLine.SelectedIndex <> -1 Then
            Dim lineNumber = Val(cboVoucherLine.Text) - 1
            dsDGV.Tables("Lines").Rows.RemoveAt(lineNumber)
            updateProductTotal()
            If lineNumber < dsDGV.Tables("Lines").Rows.Count Then
                While lineNumber < dsDGV.Tables("Lines").Rows.Count
                    dsDGV.Tables("Lines").Rows(lineNumber).Item("LineNumber") = lineNumber + 1
                    lineNumber += 1
                End While
            End If
            dsBackup = New DataSet()
            dsBackup = dsDGV.Clone()
            LoadDelete()
        Else
            MessageBox.Show("You must select a valid Line to delete", "Select a valid line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVoucherLine.Focus()
        End If
    End Sub

    Private Sub dgvVoucherLines_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVoucherLines.CellValueChanged
        If isloaded Then
            Dim currentColumn As Integer = dgvVoucherLines.CurrentCell.ColumnIndex
            If dgvVoucherLines.Columns(currentColumn).Name = "UnitCost" Or dgvVoucherLines.Columns(currentColumn).Name = "Quantity" Then
                Dim currentRow As Integer = dgvVoucherLines.CurrentCell.RowIndex
                If checkDGVCellChange(currentRow, currentColumn) Then
                    Dim total As Double = Val(dgvVoucherLines.Rows(currentRow).Cells("UnitCost").Value) * Val(dgvVoucherLines.Rows(currentRow).Cells("Quantity").Value)
                    isloaded = False
                    dgvVoucherLines.Rows(currentRow).Cells("ExtendedAmount").Value = FormatCurrency(total)
                    isloaded = False
                End If
            End If
        End If
    End Sub

    Private Function checkDGVCellChange(ByVal currentRow As Integer, ByVal currentColumn As Integer) As Boolean
        If IsDBNull(dgvVoucherLines.Rows(currentRow).Cells(currentColumn).Value) Then
            MessageBox.Show("You must enter a value for " + dgvVoucherLines.Columns(currentColumn).HeaderText, "Enter a value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            isloaded = False
            dgvVoucherLines.Rows(currentRow).Cells(currentColumn).Value = dsBackup.Tables("Lines").Rows(currentRow).Item(currentColumn)
            isloaded = True
            Return False
        End If
        If IsNumeric(dgvVoucherLines.Rows(currentRow).Cells(currentColumn).Value) = False Then
            MessageBox.Show("You must enter a number for " + dgvVoucherLines.Columns(currentColumn).HeaderText, "Enter a value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            isloaded = False
            dgvVoucherLines.Rows(currentRow).Cells(currentColumn).Value = dsBackup.Tables("Lines").Rows(currentRow).Item(currentColumn)
            isloaded = True
            Return False
        End If
        Return True
    End Function

    Private Sub cmdCreateRecurring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateRecurring.Click
        If canCreate() Then
            LoadPaymentTermDetails()
            Try
                batchNumber = getBatchNumber()
                Dim voucherList As List(Of Integer) = getVoucherList(batchNumber)
                For i As Integer = 0 To voucherList.Count - 1
                    addReceiptOfInvoiceVoucherLines(voucherList(i))
                Next
                isloaded = False
                clearAll()
                isloaded = True
                MessageBox.Show("Recurring payment has been created", "Recurring has been created", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Exception
                MessageBox.Show("There was a problem trying to generate the recurring vouchers. Contact system admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sendErrorToDataBase("APcreateRecurringVouchers - cmdCreateRecurring -- Error trying to create the entries into the database for recurring voucher", "Batch #" + batchNumber.ToString(), ex.ToString())
                ''if it got past the generating a batch number this will remove the entries in the table for this
                If batchNumber <> 0 Then
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber", con)
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = batchNumber
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            End Try
        End If
    End Sub

    Private Function canCreate() As Boolean
        If dgvVoucherLines.Rows.Count = 0 Then
            MessageBox.Show("You must have enter at least 1 line", "Enter a line", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboItemID.Focus()
            Return False
        End If
        If Val(txtInvoiceAmount.Text.Replace("$", "").Replace(",", "")) <> Val(txtInvoiceTotal.Text.Replace("$", "").Replace(",", "")) Then
            MessageBox.Show("Invoice amount entered does not match the amount totaled from the lines, freight and sales tax. Check numbers and try again.", "Does not match", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If rdoBimonth.Checked = False And rdoMonth.Checked = False And rdoQuarterly.Checked = False And rdoSemiAnnual.Checked = False Then
            MessageBox.Show("You must select a repetition period", "Select a repetition period", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrEmpty(txtRepetitions.Text) Then
            MessageBox.Show("You must enter a value for repetition times", "Enter a vlaue", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRepetitions.Focus()
            Return False
        End If
        If IsNumeric(txtRepetitions.Text) = False Then
            MessageBox.Show("You must enter a number for repetitions", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRepetitions.SelectAll()
            txtRepetitions.Focus()
            Return False
        End If
        If checkDate() Then
            Return False
        End If
        If String.IsNullOrEmpty(cboVendorID.Text) Then
            MessageBox.Show("You must select a Vendor ID", "Select a Vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorID.Focus()
            Return False
        End If
        If cboVendorID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Vendor ID", "Enter a valid Vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorID.SelectAll()
            cboVendorID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboVendorClass.Text) Then
            MessageBox.Show("You must select a Vendor Class", "Select a Vendor Class", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorClass.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtInvoiceNumber.Text) Then
            MessageBox.Show("You must enter an Invoice number", "Enter an invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInvoiceNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtInvoiceAmount.Text) Then
            MessageBox.Show("You must enter an amount for the invoice", "Enter an amount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInvoiceAmount.Focus()
            Return False
        End If
        If IsNumeric(txtInvoiceAmount.Text) = False Then
            MessageBox.Show("You must enter a number for invoice amount", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInvoiceAmount.SelectAll()
            txtInvoiceAmount.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboPaymentTerms.Text) Then
            MessageBox.Show("You must select a payment term", "Select a payment term", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPaymentTerms.Focus()
            Return False
        End If
        If cboPaymentTerms.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid payment term", "Enter a valid payment term", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPaymentTerms.SelectAll()
            cboPaymentTerms.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function checkDate() As Boolean
        If dtpStartDate.Value.Year < Today.Year Then
            MessageBox.Show("You must enter a date on or before the current date", "Enter a date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpStartDate.Focus()
            Return True
        End If
        If dtpStartDate.Value.Year = Today.Year Then
            If dtpStartDate.Value.Month < Today.Month Then
                MessageBox.Show("You must enter a date on or before the current date", "Enter a date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtpStartDate.Focus()
                Return True
            End If
            If dtpStartDate.Value.Month = Today.Month Then
                If dtpStartDate.Value.Day < Today.Day Then
                    MessageBox.Show("You must enter a date on or before the current date", "Enter a date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dtpStartDate.Focus()
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Private Function getBatchNumber() As Integer
        Dim batch As Integer = 0

        cmd = New SqlCommand("BEGIN TRAN DECLARE @key as int = (SELECT isnull(MAX(BatchNumber) + 1, 1) FROM ReceiptOfInvoiceBatchHeader); Insert Into ReceiptOfInvoiceBatchHeader(BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus)Values(@key, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus); select @key; commit tran;", con)

        With cmd.Parameters
            .Add("@BatchDate", SqlDbType.VarChar).Value = Today
            .Add("@BatchAmount", SqlDbType.VarChar).Value = "0"
            .Add("@BatchDescription", SqlDbType.VarChar).Value = "RECURRING VOUCHER"
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@BatchStatus", SqlDbType.VarChar).Value = "RECURRING"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        batch = cmd.ExecuteScalar()
        con.Close()
        Return batch
    End Function

    Private Function getVoucherList(ByVal batch As Integer) As List(Of Integer)
        Dim lst As New List(Of Integer)
        Dim voucherNumber As Integer = 0
        Dim times As Integer = Val(txtRepetitions.Text)
        cmd = New SqlCommand("SELECT MAX(VoucherNumber) FROM ReceiptOfInvoiceBatchLine", con)

        If con.State = ConnectionState.Closed Then con.Open()
        voucherNumber = cmd.ExecuteScalar()
        voucherNumber += 1
        Dim currDate As DateTime = dtpStartDate.Value
        Dim diff As Integer = 0
        ''sets discount amount to 0 of nothing is present
        If String.IsNullOrEmpty(txtDiscountAmount.Text) Then
            txtDiscountAmount.Text = "0"
        End If
        ''sets the freight total to 0 if nothing is present
        If String.IsNullOrEmpty(txtFreightTotal.Text) Then
            txtFreightTotal.Text = "0"
        End If
        ''sets the sales tax total to 0 if nothing is presenty
        If String.IsNullOrEmpty(txtSalesTaxTotal.Text) Then
            txtSalesTaxTotal.Text = "0"
        End If
        ''goes through the given amount of timjes and will create entries for each one
        For i As Integer = 1 To times
            Dim tmp As List(Of DateTime) = getDiscountDueDates(currDate)

            cmd = New SqlCommand("Insert Into ReceiptOfInvoiceBatchLine(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, VendorID, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, ReceiptDate, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, DeleteReferenceNumber, OnHold, WhitePaper, CheckType, TempSelected, SelectedInDatagrid, InvoiceAmount, VendorClass)Values(@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @VendorID, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @ReceiptDate, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @DeleteReferenceNumber, @OnHold, @WhitePaper, @CheckType, @TempSelected, @SelectedInDatagrid, @InvoiceAmount, @VendorClass)", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = voucherNumber
                .Add("@BatchNumber", SqlDbType.VarChar).Value = batch
                .Add("@PONumber", SqlDbType.VarChar).Value = 0
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text + currDate.Year.ToString() + "/" + currDate.Month.ToString()
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = tmp(1)
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = Val(txtPurchaseTotal.Text.Replace("$", "").Replace(",", ""))
                .Add("@InvoiceFreight", SqlDbType.VarChar).Value = Val(txtFreightTotal.Text.Replace("$", "").Replace(",", ""))
                .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = Val(txtSalesTaxTotal.Text.Replace("$", "").Replace(",", ""))
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = Val(txtInvoiceTotal.Text.Replace("$", "").Replace(",", ""))
                .Add("@ReceiptDate", SqlDbType.VarChar).Value = tmp(1)
                .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                .Add("@DiscountDate", SqlDbType.VarChar).Value = tmp(0)
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@DueDate", SqlDbType.VarChar).Value = currDate
                .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text.Replace("$", "").Replace(",", ""))
                .Add("@VoucherStatus", SqlDbType.VarChar).Value = "RECURRING"
                .Add("@VoucherSource", SqlDbType.VarChar).Value = "RECURRING VOUCHER"
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = 0
                .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
                .Add("@WhitePaper", SqlDbType.VarChar).Value = "NO"
                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                .Add("@TempSelected", SqlDbType.VarChar).Value = ""
                .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
                .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtInvoiceAmount.Text.Replace("$", "").Replace(",", ""))
                .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            ''sleects the correct checked period and will generate the new date for the next recurrsion
            Select Case True
                Case rdoBimonth.Checked
                    currDate = currDate.AddMonths(2)
                Case rdoMonth.Checked
                    currDate = currDate.AddMonths(1)
                Case rdoQuarterly.Checked
                    currDate = currDate.AddMonths(3)
                Case rdoSemiAnnual.Checked
                    currDate = currDate.AddMonths(6)
            End Select
            lst.Add(voucherNumber)
            voucherNumber += 1
        Next
        con.Close()
        Return lst
    End Function

    Public Sub LoadPaymentTermDetails()
        Dim DiscountPercentStatement As String = "SELECT DiscountPercent, DiscountDays, DueDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
        DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = DiscountPercentCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.GetValue(0)) Then
                DiscountPercent = 0
            Else
                DiscountPercent = reader.GetValue(0)
            End If
            If IsDBNull(reader.GetValue(1)) Then
                DiscountDays = 0
            Else
                DiscountDays = reader.GetValue(1)
            End If
            If IsDBNull(reader.GetValue(2)) Then
                DueDays = 0
            Else
                DueDays = reader.GetValue(2)
            End If
        Else
            DiscountPercent = 0
            DiscountDays = 0
            DueDays = 0
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Function getDiscountDueDates(ByVal dat As DateTime) As List(Of DateTime)
        Dim lst As New List(Of DateTime)
        Dim CurrentDay As Integer = dat.Day
        Dim dueDate As DateTime
        Dim invoiceDate As DateTime
        Dim discDate As DateTime
        'Commands to determine Discount and Due Dates
        Select Case cboPaymentTerms.Text
            Case "20thNet"
                CurrentDay = 20
            Case "15thNet"
                CurrentDay = 15
            Case "10thNet"
                CurrentDay = 10
            Case "1rstNet"
                CurrentDay = 1
            Case Else
                If DiscountDays = 0 Then
                    DiscountDays = DueDays
                End If
                invoiceDate = dat.AddDays(-DueDays)
                discDate = dat.AddDays(DueDays - DiscountDays)

                lst.Add(discDate)
                lst.Add(invoiceDate)
                Return lst
        End Select
        dueDate = dat.Date
        invoiceDate = dat.AddDays(-CurrentDay)
        lst.Add(dueDate)
        lst.Add(invoiceDate)

        Return lst
    End Function

    Private Sub addReceiptOfInvoiceVoucherLines(ByVal voucherNumber As Integer)
        For i As Integer = 0 To dgvVoucherLines.Rows.Count() - 1
            'Write Data to Voucher Line Database Table
            cmd = New SqlCommand("Insert Into ReceiptOfInvoiceVoucherLines(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine, DivisionID)Values(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice, @ReceiverNumber, @ReceiverLine, @DivisionID)", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = voucherNumber
                .Add("@VoucherLine", SqlDbType.VarChar).Value = dgvVoucherLines.Rows(i).Cells("LineNumber").Value
                .Add("@PartNumber", SqlDbType.VarChar).Value = dgvVoucherLines.Rows(i).Cells("ItemNumber").Value
                .Add("@PartDescription", SqlDbType.VarChar).Value = dgvVoucherLines.Rows(i).Cells("Description").Value
                .Add("@Quantity", SqlDbType.VarChar).Value = dgvVoucherLines.Rows(i).Cells("Quantity").Value
                .Add("@UnitCost", SqlDbType.VarChar).Value = dgvVoucherLines.Rows(i).Cells("UnitCost").Value
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(dgvVoucherLines.Rows(i).Cells("UnitCost").Value) * Val(dgvVoucherLines.Rows(i).Cells("Quantity").Value)
                .Add("@GLDebitAccount", SqlDbType.VarChar).Value = dgvVoucherLines.Rows(i).Cells("GLDebitAccount").Value
                .Add("@GLCreditAccount", SqlDbType.VarChar).Value = dgvVoucherLines.Rows(i).Cells("GLCreditAccount").Value
                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "RECURRING"
                .Add("@ReceiverNumber", SqlDbType.VarChar).Value = 0
                .Add("@ReceiverLine", SqlDbType.VarChar).Value = 0
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
    End Sub

    Private Sub clearAll()
        If rdoBimonth.Checked Then
            rdoBimonth.Checked = False
        End If
        If rdoMonth.Checked Then
            rdoMonth.Checked = False
        End If
        If rdoQuarterly.Checked Then
            rdoQuarterly.Checked = False
        End If
        If rdoSemiAnnual.Checked Then
            rdoSemiAnnual.Checked = False
        End If

        txtRepetitions.Clear()
        txtInvoiceAmount.Clear()
        txtInvoiceNumber.Clear()
        txtPurchaseTotal.Clear()
        txtFreightTotal.Clear()
        txtSalesTaxTotal.Clear()
        txtInvoiceTotal.Clear()
        txtComment.Clear()
        txtDiscountAmount.Clear()

        dtpStartDate.Value = Today

        cboVendorID.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1
        cboPaymentTerms.SelectedIndex = -1
        cboVoucherLine.SelectedIndex = -1
        cboCheckType.SelectedIndex = -1

        txtVendorName.Clear()
        If chkManualDiscount.Checked Then
            chkManualDiscount.Checked = False
        End If
        dsDGV.Clear()
        dsBackup.Clear()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If MessageBox.Show("Printing will create the Recurring Voucher and will close the form." + Environment.NewLine + Environment.NewLine + " Do you wish to continue?", "Continue", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            cmdCreateRecurring_Click(sender, e)
            Dim newPrintRecurring As New PrintRecurringVoucher
            newPrintRecurring.setBatch(batchNumber)
            newPrintRecurring.ShowDialog()
        End If
    End Sub

    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division)", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = Today()
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage.Substring(0, 300)
            .Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Function updateProductTotal() As Double
        If String.IsNullOrEmpty(txtSalesTaxTotal.Text) Then
            isloaded = False
            txtSalesTaxTotal.Text = "0"
            isloaded = True
        End If
        If String.IsNullOrEmpty(txtFreightTotal.Text) Then
            isloaded = False
            txtFreightTotal.Text = "0"
            isloaded = True
        End If
        If dgvVoucherLines.Rows.Count > 0 Then
            Dim tot As Double = 0
            For i As Integer = 0 To dgvVoucherLines.Rows.Count - 1
                tot += dgvVoucherLines.Rows(i).Cells("UnitCost").Value * dgvVoucherLines.Rows(i).Cells("Quantity").Value
            Next
            txtPurchaseTotal.Text = FormatCurrency(tot)
            Return System.Math.Round(tot, 2)
        Else
            txtPurchaseTotal.Text = "$0.00"
            Return 0
        End If
    End Function
End Class