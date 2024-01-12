Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class MaintainRecurringVouchers
    Inherits System.Windows.Forms.Form

    Dim NextVoucherNumber, LastVoucherNumber, LastBatchNumber, NextBatchNumber As Integer
    Dim ItemClass, GLAccount, DefaultItem As String
    Dim CycleRepetition, CycleLength As Integer
    ''NEEDS TAKEN OUT********************************************
    ''Dim EmployeeCompanyCode As String = "TST"
    ''***********************************************************
    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, dsRecurrences, dsLines As DataSet

    Dim DiscountPercent As Double
    Dim DiscountDays, DueDays As Integer

    Dim isloaded As Boolean = False
    Dim termsChanged As Boolean = False

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode, VendorName, VendorClass FROM Vendor WHERE DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds1 = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds1, "Vendor")
        con.Close()

        cboVendorID.DisplayMember = "VendorCode"
        cboVendorID.DataSource = ds1.Tables("Vendor")
        cboVendorID.SelectedIndex = -1
    End Sub

    Private Sub LoadBatches()
        cmd = New SqlCommand("SELECT BatchNumber FROM ReceiptOfInvoiceBatchHeader WHERE BatchStatus = 'RECURRING' AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "ReceiptOfInvoiceBatchHeader")
        con.Close()

        cboBatchNumber.DisplayMember = "BatchNumber"
        cboBatchNumber.DataSource = ds.Tables("ReceiptOfInvoiceBatchHeader")
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadDivisions()
        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable;", con)
        ds2 = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds2, "DivisionTable")
        con.Close()

        cboDivisionID.DisplayMember = "DivisionKey"
        cboDivisionID.DataSource = ds2.Tables("DivisionTable")
        cboDivisionID.SelectedIndex = -1
    End Sub

    Private Sub LoadVendorClass()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT DISTINCT(VendorClass) FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> 'DE-ACTIVATED';", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds3 = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds3, "Vendor")
        con.Close()

        cboVendorClass.DisplayMember = "VendorClass"
        cboVendorClass.DataSource = ds3.Tables("Vendor")
        cboVendorClass.SelectedIndex = -1
    End Sub

    Private Sub LoadPaymentTerms()
        cmd = New SqlCommand("SELECT PmtTermsID FROM PaymentTerms;", con)
        ds4 = New DataSet()
        myAdapter.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds4, "PaymentTerms")
        con.Close()
        cboPaymentTerms.DataSource = ds4.Tables("PaymentTerms")
        cboPaymentTerms.DisplayMember = "PmtTermsID"
        cboPaymentTerms.SelectedIndex = -1
    End Sub


    Public Sub LoadNonInventoryItems()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT ItemID FROM NonInventoryItemList WHERE DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds5 = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds5, "NonInventoryItemList")
        con.Close()

        cboItemID.DisplayMember = "ItemID"
        cboItemID.DataSource = ds5.Tables("NonInventoryItemList")
        cboItemID.SelectedIndex = -1
        ds7 = ds5.Copy()

        cboAddItemID.DisplayMember = "ItemID"
        cboAddItemID.DataSource = ds7.Tables("NonInventoryItemList")
        cboAddItemID.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccounts()
        'Load GL Accounts
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber < @Canadian", con)
        cmd.Parameters.Add("@Canadian", SqlDbType.VarChar).Value = "C$"
        ds6 = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds6, "GLAccounts")
        con.Close()

        cboDebitAccount.DisplayMember = "GLAccountNumber"
        cboDebitDescription.DisplayMember = "GLAccountShortDescription"
        cboDebitAccount.DataSource = ds6.Tables("GLAccounts")
        cboDebitDescription.DataSource = ds6.Tables("GLAccounts")
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboBatchNumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1
        cboPaymentTerms.SelectedIndex = -1
        cboItemID.SelectedIndex = -1
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1

        txtQuantity.Clear()
        txtUnitCost.Clear()
        txtDescription.Clear()
        txtInvoiceNumber.Clear()
        txtComment.Clear()
        txtFreightTotal.Clear()
        txtSalesTax.Clear()
        txtDiscount.Clear()
        txtProductTotal.Clear()
        txtVendorName.Clear()
        txtInvoiceAmount.Clear()

        dtpInvoiceDate.Value = Today
        dtpLastModifiedDate.Value = Today
        cboBatchNumber.Focus()

        dsRecurrences = New DataSet()
        dgvRecurrences.DataSource = dsRecurrences
        dsLines = New DataSet()
        dgvLines.DataSource = dsLines
        cboDeleteVoucherNumber.SelectedIndex = -1
        cboDeleteVoucherNumber.DataSource = dsRecurrences
        cboDeleteVoucherNumber.Text = ""
        termsChanged = False
    End Sub

    Private Sub clearAddLines()
        cboAddItemID.SelectedIndex = -1
        txtAddDescription.Clear()
        txtAddQuantity.Clear()
        txtAddUnitCost.Clear()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub MaintainRecurringVouchers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If EmployeeCompanyCode <> "ADM" Then
            cboDivisionID.Enabled = False
        End If
        LoadPaymentTerms()
        LoadDivisions()
        LoadGLAccounts()
        isloaded = True
        cboDivisionID.Text = EmployeeCompanyCode
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        clearAddLines()
        dsRecurrences.Clear()
        dsLines.Clear()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cboBatchNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBatchNumber.SelectedIndexChanged
        If isloaded Then
            If cboBatchNumber.SelectedIndex <> -1 Then
                LoadRecurrences()
                If dsRecurrences.Tables("ReceiptOfInvoiceBatchLine").Rows.Count > 0 Then
                    LoadRecurringBatchDetails()
                    LoadLines()
                End If
            End If
        End If
    End Sub
    ''sets the repeated data to the proper fields on the form
    Private Sub LoadRecurringBatchDetails()
        cboVendorID.Text = dgvRecurrences.Rows(0).Cells("VendorID").Value
        cboVendorClass.Text = dgvRecurrences.Rows(0).Cells("VendorClass").Value
        txtInvoiceNumber.Text = dgvRecurrences.Rows(0).Cells("InvoiceNumber").Value
        txtInvoiceAmount.Text = dgvRecurrences.Rows(0).Cells("InvoiceTotal").Value
        txtProductTotal.Text = dgvRecurrences.Rows(0).Cells("ProductTotal").Value
        txtFreightTotal.Text = dgvRecurrences.Rows(0).Cells("InvoiceFreight").Value
        txtSalesTax.Text = dgvRecurrences.Rows(0).Cells("InvoiceSalesTax").Value
        txtDiscount.Text = dgvRecurrences.Rows(0).Cells("DiscountAmount").Value
        cboPaymentTerms.Text = dgvRecurrences.Rows(0).Cells("PaymentTerms").Value
        txtComment.Text = dgvRecurrences.Rows(0).Cells("Comment").Value
    End Sub
    ''sets the Recurrences so that only Voucher numver and dates show i nthe datagridview
    Private Sub setDGVRecurrences()
        dgvRecurrences.Columns("BatchNumber").Visible = False
        dgvRecurrences.Columns("PONumber").Visible = False
        dgvRecurrences.Columns("InvoiceNumber").Visible = False
        dgvRecurrences.Columns("VendorID").Visible = False
        dgvRecurrences.Columns("VendorClass").Visible = False
        dgvRecurrences.Columns("ProductTotal").Visible = False
        dgvRecurrences.Columns("InvoiceFreight").Visible = False
        dgvRecurrences.Columns("InvoiceSalesTax").Visible = False
        dgvRecurrences.Columns("InvoiceTotal").Visible = False
        dgvRecurrences.Columns("InvoiceAmount").Visible = False
        dgvRecurrences.Columns("PaymentTerms").Visible = False
        dgvRecurrences.Columns("Comment").Visible = False
        dgvRecurrences.Columns("DiscountAmount").Visible = False
        dgvRecurrences.Columns("VoucherStatus").Visible = False
        dgvRecurrences.Columns("DivisionID").Visible = False
        dgvRecurrences.Columns("DeleteReferenceNumber").Visible = False
        dgvRecurrences.Columns("VoucherSource").Visible = False

        dgvRecurrences.Columns("VoucherNumber").HeaderText = "Voucher Number"
        dgvRecurrences.Columns("InvoiceDate").HeaderText = "Invoice Date"
        dgvRecurrences.Columns("DiscountDate").HeaderText = "Discount Date"
        dgvRecurrences.Columns("DueDate").HeaderText = "Due Date"
    End Sub
    ''loads all the occurances for the given batch
    Private Sub LoadRecurrences()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber;", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text
        dsRecurrences = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dsRecurrences, "ReceiptOfInvoiceBatchLine")
        con.Close()

        dgvRecurrences.DataSource = dsRecurrences.Tables("ReceiptOfInvoiceBatchLine")
        setDGVRecurrences()

        cboDeleteVoucherNumber.DataSource = dsRecurrences.Tables("ReceiptOfInvoiceBatchLine")
        cboDeleteVoucherNumber.DisplayMember = "VoucherNumber"
    End Sub
    ''loads the lines associated to the current batch of occurances
    Private Sub LoadLines()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber;", con)
        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = dgvRecurrences.Rows(0).Cells("VoucherNumber").Value
        myAdapter.SelectCommand = cmd
        dsLines = New DataSet()
        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(dsLines, "ReceiptOfInvoiceVoucherLines")
        con.Close()
        dgvLines.DataSource = dsLines.Tables("ReceiptOfInvoiceVoucherLines")
        setDGVLines()
        isloaded = False
        cboLineNumber.DisplayMember = "VoucherLine"
        cboLineNumber.DataSource = dsLines.Tables("ReceiptOfInvoiceVoucherLines")
        cboLineNumber.SelectedIndex = -1
        isloaded = True
    End Sub
    ''sets up the datagridview so that things that don't need to be shown aren't
    Private Sub setDGVLines()
        dgvLines.Columns("VoucherNumber").Visible = False
        dgvLines.Columns("SelectForInvoice").Visible = False
        dgvLines.Columns("ReceiverNumber").Visible = False
        dgvLines.Columns("ReceiverLine").Visible = False

        dgvLines.Columns("VoucherLine").HeaderText = "Voucher Line #"
        dgvLines.Columns("PartNumber").HeaderText = "Item ID"
        dgvLines.Columns("PartDescription").HeaderText = "Description"
        dgvLines.Columns("UnitCost").HeaderText = "Unit Cost"
        dgvLines.Columns("ExtendedAmount").HeaderText = "Extended Amount"
        dgvLines.Columns("GLDebitAccount").HeaderText = "GL Debit Account"
        dgvLines.Columns("GLCreditAccount").HeaderText = "GL Credit Account"
    End Sub

    Private Sub updateExtendedCost()
        txtExtendedAmount.Text = Val(txtQuantity.Text) * Val(txtUnitCost.Text)
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        updateExtendedCost()
    End Sub

    Private Sub txtUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitCost.TextChanged
        updateExtendedCost()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isloaded Then
            isloaded = False
            ClearData()
            LoadBatches()
            LoadVendor()
            LoadVendorClass()
            LoadNonInventoryItems()
            isloaded = True
        End If
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        If isloaded Then
            ''checks to see if the index is -1 if so will clear else will fill
            If cboVendorID.SelectedIndex <> -1 Then
                txtVendorName.Text = ds1.Tables("Vendor").Rows(cboVendorID.SelectedIndex).Item("VendorName")
                cboVendorClass.Text = ds1.Tables("Vendor").Rows(cboVendorID.SelectedIndex).Item("VendorClass")
            Else
                txtVendorName.Clear()
                cboVendorClass.Text = ""
            End If
        End If
    End Sub

    Private Sub cboDeleteVoucherNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDeleteVoucherNumber.SelectedIndexChanged
        If isloaded Then
            If cboDeleteVoucherNumber.SelectedIndex <> -1 Then
                ''fills the invoice date for deletion group
                If dgvRecurrences.Rows.Count > 0 Then
                    dtpInvoiceDate.Text = dsRecurrences.Tables("ReceiptOfInvoiceBatchLine").Rows(cboDeleteVoucherNumber.SelectedIndex).Item("InvoiceDate")
                Else
                    dtpInvoiceDate.Text = Today
                End If
            End If
        End If
    End Sub

    Private Sub cboLineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLineNumber.SelectedIndexChanged
        If isloaded Then
            If cboLineNumber.SelectedIndex <> -1 Then
                ''fills the fields in the edit line group
                cboItemID.Text = dgvLines.Rows(cboLineNumber.SelectedIndex).Cells("PartNumber").Value
                txtDescription.Text = dgvLines.Rows(cboLineNumber.SelectedIndex).Cells("PartDescription").Value
                txtQuantity.Text = dgvLines.Rows(cboLineNumber.SelectedIndex).Cells("Quantity").Value
                txtUnitCost.Text = dgvLines.Rows(cboLineNumber.SelectedIndex).Cells("UnitCost").Value
                If cboLineNumber.Focused Then
                    cboDebitAccount.Text = dgvLines.Rows(cboLineNumber.SelectedIndex).Cells("GLDebitAccount").Value
                    cboDebitDescription.SelectedIndex = cboDebitAccount.SelectedIndex
                    cboCreditAccount.Text = dgvLines.Rows(cboLineNumber.SelectedIndex).Cells("GLCreditAccount").Value
                End If
            End If
        End If
    End Sub

    Private Sub cmdDeleteRecurrence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRecurrence.Click
        If canDeleteRecurrence() Then
            Dim rslt As DialogResult = MessageBox.Show("Are you sure you wish to delete this Recurrence?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rslt = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = cboDeleteVoucherNumber.Text
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Occurrance Voucher has been deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadRecurrences()
                LoadLines()
                ''updates the batch date
                updateModDate()
            End If
        End If
    End Sub
    ''checks to make sure there is something valid to delete ofr a single occurance
    Private Function canDeleteRecurrence() As Boolean
        If String.IsNullOrEmpty(cboDeleteVoucherNumber.Text) Then
            MessageBox.Show("You must select a Occurrence Voucher Number", "Select a Occurrence Voucher Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteVoucherNumber.Focus()
            Return False
        End If
        If cboDeleteVoucherNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Occurrence Voucher Number", "Enter a valid Ocurrence Voucher Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDeleteVoucherNumber.SelectAll()
            cboDeleteVoucherNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If canDeleteBatch() Then
            If MessageBox.Show("Are you sure you wish to delete all occurrances?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber", con)
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                isloaded = False
                ClearData()
                LoadBatches()
                isloaded = True
                MessageBox.Show("Recurrance Batch has been deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    '' makes sure there is a valid batch to delete
    Private Function canDeleteBatch() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must select a Recurrance Batch to delete", "Select a Recurrance Batch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If cboBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Recurrance Batch Number", "Enter a valid Recurrance Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdSaveLineChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLineChanges.Click
        If canSaveLineChanged() Then
            If MessageBox.Show("These changes will change all recurrences, do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ''goes through all the occurances and will update each with the lines new info
                For i As Integer = 0 To dgvRecurrences.Rows.Count - 1
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET PartNumber = @PartNumber, PartDescription = @Description, Quantity = @Quantity, UnitCost = @UnitCost, ExtendedAmount = @ExtendedAmount, GLDebitAccount = @GLDebitAccount, GLCreditAccount = @GLCreditAccount WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine;", con)
                    With cmd.Parameters
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboItemID.Text
                        .Add("@Description", SqlDbType.VarChar).Value = txtDescription.Text
                        .Add("@Quantity", SqlDbType.VarChar).Value = txtQuantity.Text
                        .Add("@UnitCost", SqlDbType.VarChar).Value = txtUnitCost.Text
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = txtExtendedAmount.Text
                        .Add("@GLDebitAccount", SqlDbType.VarChar).Value = cboDebitAccount.Text
                        .Add("@GLCreditAccount", SqlDbType.VarChar).Value = cboCreditAccount.Text
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = dgvRecurrences.Rows(i).Cells("VoucherNumber").Value
                        .Add("@VoucherLine", SqlDbType.VarChar).Value = cboLineNumber.Text
                    End With
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                Next
                con.Close()
                isloaded = False
                LoadLines()
                isloaded = True
                ''gets the product total for the lines
                Dim total As Double = getProductCost()
                ''checks the total that was just retrieved and compares it against what is already there and will update if needed
                If Val(txtProductTotal.Text) <> total Then
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceTotal WHERE BatchNumber = @BatchNumber;", con)
                    With cmd.Parameters
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = total
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = Convert.ToString(total + Val(txtFreightTotal.Text) + Val(txtSalesTax.Text))
                    End With
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
                isloaded = False
                LoadRecurrences()
                LoadRecurringBatchDetails()
                isloaded = True
                MessageBox.Show("Line has been updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ''updates the batch date
                updateModDate()
            End If
        End If
    End Sub

    Private Function canSaveLineChanged() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must select a Recurring Batch Number", "Select a Recurring Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If cboBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Recurring Batch Number", "Enter a Valid Recurring Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLineNumber.Text) Then
            MessageBox.Show("You must select a line number", "Select a line number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLineNumber.Focus()
            Return False
        End If
        If cboLineNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid line number", "Enter a valid line number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLineNumber.SelectAll()
            cboLineNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboItemID.Text) Then
            MessageBox.Show("You must select an Item ID", "Select an Item ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboItemID.Focus()
            Return False
        End If
        If cboItemID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Item ID", "Enter a valid Item ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboItemID.Select()
            cboItemID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtQuantity.Text) Then
            MessageBox.Show("You must enter a quantity", "Enter a quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Return False
        End If
        If IsNumeric(txtQuantity.Text) = False Then
            MessageBox.Show("You must enter a number for quantity", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.SelectAll()
            txtQuantity.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtUnitCost.Text) Then
            MessageBox.Show("You must enter a Unit Cost", "Enter a Unit Cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitCost.Focus()
            Return False
        End If
        If IsNumeric(txtUnitCost.Text) = False Then
            MessageBox.Show("You must enter a number for Unit Cost", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitCost.SelectAll()
            txtUnitCost.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboDebitAccount.Text) Then
            MessageBox.Show("You must select a Debit Account", "Select a Debit Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDebitAccount.Focus()
            Return False
        End If
        If cboDebitAccount.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Debit Account", "Enter a Debit Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDebitAccount.SelectAll()
            cboDebitAccount.Focus()
            Return False
        End If
        Return True
    End Function
    ''gets the product total from the lines
    Private Function getProductCost() As Double
        Dim tot As Double = 0
        If dgvLines.Rows.Count > 0 Then
            For i As Integer = 0 To dgvLines.Rows.Count - 1
                tot += Val(dgvLines.Rows(i).Cells("ExtendedAmount").Value)
            Next
        End If
        Return System.Math.Round(tot, 2)
    End Function

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If canDeleteLine() Then
            If MessageBox.Show("These changes will change all recurrences, do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ''goes through all the occurances and will delete the line number from each
                Dim deletedLineNumber As Integer = Val(cboLineNumber.Text)
                Dim needNumberChange As Boolean = False
                ''checks to see if line numbers need changed and if so will trigger the in loop method call
                If deletedLineNumber < dgvLines.Rows.Count Then
                    needNumberChange = True
                End If
                For i As Integer = 0 To dgvRecurrences.Rows.Count - 1
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine;", con)
                    cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = dgvRecurrences.Rows(i).Cells("VoucherNumber").Value
                    cmd.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = cboLineNumber.Text
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    If needNumberChange Then
                        updateLineNumbers(dgvRecurrences.Rows(i).Cells("VoucherNumber").Value, deletedLineNumber)
                    End If
                Next
                con.Close()
                Dim batch As Integer = Val(cboBatchNumber.Text)
                ClearData()
                cboBatchNumber.Text = batch
                LoadRecurringBatchDetails()
                LoadLines()
                LoadRecurrences()
                MessageBox.Show("Line has been deleted from all occurances", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ''updates the batch date
                updateModDate()
            End If
        End If
    End Sub

    Private Function canDeleteLine() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must select a Recurring Batch Number", "Select a Recurring Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If cboBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Recurring Batch Number", "Enter a Valid Recurring Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLineNumber.Text) Then
            MessageBox.Show("You must select a line number to change", "Select a line number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLineNumber.Focus()
            Return False
        End If
        If cboLineNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid line number", "Enter a valid line number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLineNumber.SelectAll()
            cboLineNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdEnterLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterLine.Click
        If canAddLine() Then
            If MessageBox.Show("This will add the line to all remaining occurances, do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Dim newLineNumber As Integer = dgvLines.Rows.Count + 1
                For i As Integer = 0 To dgvRecurrences.Rows.Count - 1
                    cmd = New SqlCommand("INSERT INTO ReceiptOfInvoiceVoucherLines (VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine) VALUES(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, 'RECURRING', 0, 0);", con)
                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.Int).Value = dgvRecurrences.Rows(i).Cells("VoucherNumber").Value
                        .Add("@VoucherLine", SqlDbType.Int).Value = newLineNumber.ToString()
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboAddItemID.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = txtAddDescription.Text
                        .Add("@Quantity", SqlDbType.Float).Value = Val(txtAddQuantity.Text)
                        .Add("@UnitCost", SqlDbType.Float).Value = Val(txtAddUnitCost.Text)
                        .Add("@ExtendedAmount", SqlDbType.Float).Value = Val(txtAddExtendedCost.Text)
                        .Add("@GLDebitAccount", SqlDbType.VarChar).Value = cboDebitAccount.Text
                        .Add("@GLCreditAccount", SqlDbType.VarChar).Value = cboCreditAccount.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                Next
                isloaded = False
                LoadLines()
                isloaded = True
                ''gets the product total for the lines
                Dim total As Double = getProductCost()
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceTotal WHERE BatchNumber = @BatchNumber;", con)
                With cmd.Parameters
                    .Add("@ProductTotal", SqlDbType.Float).Value = total
                    .Add("@BatchNumber", SqlDbType.Int).Value = Val(cboBatchNumber.Text)
                    .Add("@InvoiceTotal", SqlDbType.Float).Value = Convert.ToString(total + Val(txtFreightTotal.Text) + Val(txtSalesTax.Text))
                End With
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                isloaded = False
                LoadRecurrences()
                LoadRecurringBatchDetails()
                isloaded = True
                clearAddLines()
                cboDebitDescription.SelectedIndex = -1
                MessageBox.Show("Line has been added to all occurances", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ''updates the batch date
                updateModDate()
            End If
        End If
    End Sub

    Private Function canAddLine() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must select a Recurrance Batch Number", "Select a Recurrance Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If cboBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Recurrance Batch Number", "Enter a valid Recurrance Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboAddItemID.Text) Then
            MessageBox.Show("You must enter an item to add", "Enter an Item to add", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAddItemID.Focus()
            Return False
        End If
        If cboAddItemID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Item", "Enter a valid Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAddItemID.SelectAll()
            cboAddItemID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAddDescription.Text) Then
            MessageBox.Show("You must have a description entered", "Enter a description", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddDescription.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAddQuantity.Text) Then
            MessageBox.Show("You must enter a quantity", "Enter a quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddQuantity.Focus()
            Return False
        End If
        If IsNumeric(txtAddQuantity.Text) = False Then
            MessageBox.Show("You must enter a number for quantity", "Enter a number for quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddQuantity.SelectAll()
            txtAddQuantity.Focus()
            Return False
        End If
        If Val(txtAddQuantity.Text) < 1 Then
            MessageBox.Show("You must enter a quantity greater than 0", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddQuantity.SelectAll()
            txtAddQuantity.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAddUnitCost.Text) Then
            MessageBox.Show("You must enter a unit cost", "Enter a unit cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddUnitCost.Focus()
            Return False
        End If
        If IsNumeric(txtAddUnitCost.Text) = False Then
            MessageBox.Show("You must enter a number for unit cost", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddUnitCost.SelectAll()
            txtAddUnitCost.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdClearAddLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAddLines.Click
        clearAddLines()
        cboDebitDescription.SelectedIndex = -1
    End Sub

    Private Sub updateAddExtendedAmount()
        txtAddExtendedCost.Text = Val(txtAddQuantity.Text) * Val(txtAddUnitCost.Text)
    End Sub

    Private Sub txtAddQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddQuantity.TextChanged
        updateAddExtendedAmount()
    End Sub

    Private Sub txtAddUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddUnitCost.TextChanged
        isloaded = False
        updateAddExtendedAmount()
        isloaded = True
    End Sub

    Private Sub cboAddItemID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddItemID.SelectedIndexChanged
        If isloaded Then
            LoadItemData()
        End If
    End Sub

    Public Sub LoadItemData()
        cmd = New SqlCommand("SELECT LongDescription, GLDebitAccount, GLCreditAccount FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID;", con)
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboAddItemID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LongDescription")) Then
                txtAddDescription.Text = ""
            Else
                txtAddDescription.Text = reader.Item("LongDescription")
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
            txtAddDescription.Text = ""
            cboDebitAccount.Text = ""
            cboCreditAccount.Text = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub cmdSaveBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveBatch.Click
        If canSaveBatch() Then
            If termsChanged Then
                LoadPaymentTermDetails()
                For i As Integer = 0 To dgvRecurrences.Rows.Count - 1
                    Dim lst As List(Of DateTime) = getDiscountDueDates(dgvRecurrences.Rows(i).Cells("DueDate").Value)
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET DiscountDate = @DiscountDate, InvoiceDate = @InvoiceDate, ReceiptDate = @InvoiceDate, PaymentTerms = @PaymentTerms WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND VoucherStatus <> 'CLOSED';", con)
                    With cmd.Parameters
                        .Add("@DiscountDate", SqlDbType.VarChar).Value = lst(0)
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = lst(1)
                        .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = dgvRecurrences.Rows(i).Cells("VoucherNumber").Value
                        .Add("@BatchNumber", SqlDbType.Int).Value = Val(cboBatchNumber.Text)
                    End With
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Next
                termsChanged = False
            End If
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VendorID = @VendorID, VendorClass = @VendorClass, Comment = @Comment, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceTotal WHERE BatchNumber = @BatchNumber AND VoucherStatus <> 'CLOSED';", con)
            With cmd.Parameters
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text
                .Add("@InvoiceFreight", SqlDbType.VarChar).Value = txtFreightTotal.Text
                .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = txtSalesTax.Text
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = Convert.ToString(getProductCost() + Val(txtFreightTotal.Text) + Val(txtSalesTax.Text))
            End With
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            ''updates the batch date
            updateModDate()
            LoadRecurrences()
            LoadLines()
            LoadRecurringBatchDetails()
            MessageBox.Show("Batch has been updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canSaveBatch() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must select a Recurrance Batch Number", "Select a Recurrance Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If cboBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Recurrance Batch Number", "Enter a Recurrance Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
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
        If cboVendorClass.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Vendor Class", "Enter a valid Vendor Class", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorClass.SelectAll()
            cboVendorClass.Focus()
            Return False
        End If
        Return True
    End Function
    ''gets discount and due dates from the given date
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
    ''gets the payment term details from the DB
    Public Sub LoadPaymentTermDetails()
        Dim DiscountPercentStatement As String = "SELECT DiscountPercent, DiscountDays, DueDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID;"
        Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
        DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = DiscountPercentCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("DiscountPercent")) Then
                DiscountPercent = 0
            Else
                DiscountPercent = reader.Item("DiscountPercent")
            End If
            If IsDBNull(reader.Item("DiscountDays")) Then
                DiscountDays = 0
            Else
                DiscountDays = reader.Item("DiscountDays")
            End If
            If IsDBNull(reader.Item("DueDays")) Then
                DueDays = 0
            Else
                DueDays = reader.Item("DueDays")
            End If
        Else
            DiscountPercent = 0
            DiscountDays = 0
            DueDays = 0
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub cboPaymentTerms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentTerms.SelectedIndexChanged
        If isloaded Then
            If cboPaymentTerms.Focused Then
                termsChanged = True
            End If
        End If
    End Sub
    ''updates the batch with the most recent modificaiton date
    Private Sub updateModDate()
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchDate = @BatchDate WHERE BatchNumber = @BatchNumber;", con)
        cmd.Parameters.Add("@BatchDate", SqlDbType.VarChar).Value = Today.ToString()
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = cboBatchNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cboDebitAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDebitAccount.SelectedIndexChanged
        If isloaded Then
            If cboDebitAccount.SelectedIndex <> -1 Then
                cboDebitDescription.SelectedIndex = cboDebitAccount.SelectedIndex
            End If
        End If
    End Sub

    Private Sub updateLineNumbers(ByVal voucherNumber As Integer, ByVal start As Integer)
        While start < dgvLines.Rows.Count
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @NewLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine;", con)
            With cmd.Parameters
                .Add("@NewLine", SqlDbType.VarChar).Value = start.ToString()
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = voucherNumber.ToString()
                .Add("@VoucherLine", SqlDbType.VarChar).Value = Convert.ToString(start + 1)
            End With
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            start += 1
        End While
    End Sub

    Private Sub cmdCreateNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateNew.Click
        Dim newAPCreateReucrring As New APCreateRecurringVouchers
        Me.Hide()
        newAPCreateReucrring.ShowDialog()
        Dim batch As String = ""
        ''checks to see if there was something entered into the batch number field and if so will attempt to save state while loading new batch nubers in if they go to the creation form
        If String.IsNullOrEmpty(cboBatchNumber.Text) = False Then
            batch = cboBatchNumber.Text
        End If
        isloaded = False
        LoadBatches()
        If String.IsNullOrEmpty(batch) = False Then
            cboBatchNumber.Text = batch
        End If
        isloaded = True
        Me.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If canPrint() Then
            Dim newPrintRecurringVoucher As New PrintRecurringVoucher
            newPrintRecurringVoucher.setBatch(cboBatchNumber.Text)
            newPrintRecurringVoucher.ShowDialog()
        End If
    End Sub

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboBatchNumber.Text) Then
            MessageBox.Show("You must select a Recurring Batch Number", "Select a Recurring Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.Focus()
            Return False
        End If
        If cboBatchNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Recurring Batch Number", "Enter a valid Recurring Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBatchNumber.SelectAll()
            cboBatchNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub txtFreightTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightTotal.TextChanged
        updateInvoiceTotal()
    End Sub

    Private Sub updateInvoiceTotal()
        txtInvoiceAmount.Text = Val(txtProductTotal.Text) + Val(txtFreightTotal.Text) + Val(txtSalesTax.Text)
    End Sub

    Private Sub txtSalesTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTax.TextChanged
        updateInvoiceTotal()
    End Sub

    Private Sub dgvRecurrences_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvRecurrences.MouseUp
        Dim ht As DataGridView.HitTestInfo = dgvRecurrences.HitTest(e.X, e.Y)
        ''check to make sure we hit a cell
        If ht.Type = DataGridViewHitTestType.Cell Then
            ''check to see if that cell is the date or time cell for Notifications
            If dgvRecurrences.Columns(ht.ColumnIndex).Name.Equals("InvoiceDate") Then
                Dim pnlXPos As Double = 0
                ''check to see if it was the date cell if so will change the x position variable accordingly
                pnlXPos = ht.ColumnX - ((pnlNewDateTime.Width - dgvLines.Columns(ht.ColumnIndex).Width) / 2)
                'If dgvRecurrences.Columns(ht.ColumnIndex).Name.Equals("InvoiceDate") Then

                'Else
                '    pnlXPos = dgvRecurrences.Location.X + ht.ColumnX - pnlNewDateTime.Width
                'End If
                ''check to see if the position of the panel plus the height wil lgo below the DGV, if so will position above the cell not below
                If dgvRecurrences.Location.Y + ht.RowY + dgvRecurrences.Rows(ht.RowIndex).Height + pnlNewDateTime.Height > dgvRecurrences.Location.Y + dgvRecurrences.Height Then
                    pnlNewDateTime.Location = New System.Drawing.Point(pnlXPos, dgvRecurrences.Location.Y + ht.RowY - pnlNewDateTime.Height)
                Else
                    pnlNewDateTime.Location = New System.Drawing.Point(pnlXPos, dgvRecurrences.Location.Y + ht.RowY + dgvRecurrences.Rows(ht.RowIndex).Height)
                End If
                ''makes sure that the current cell is the cell that was hit
                dgvRecurrences.CurrentCell = dgvRecurrences.Rows(ht.RowIndex).Cells(ht.ColumnIndex)
                pnlNewDateTime.Show()
                pnlNewDateTime.Focus()
            End If
        End If
    End Sub

    Private Sub pnlNewDateTime_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlNewDateTime.Enter
        lblRowNumber.Text = dgvRecurrences.CurrentCell.RowIndex.ToString()
        dtpChangeDate.Value = dgvRecurrences.Rows(dgvRecurrences.CurrentCell.RowIndex).Cells("InvoiceDate").Value
    End Sub

    Private Sub pnlNewDateTime_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlNewDateTime.Leave
        pnlNewDateTime.Hide()
        Dim testDate As String = dgvRecurrences.Rows(lblRowNumber.Text).Cells("InvoiceDate").Value.ToString().Substring(0, dgvRecurrences.Rows(lblRowNumber.Text).Cells("InvoiceDate").Value.ToString().IndexOf(" "))
        Dim dtpDate As String = dtpChangeDate.Value.ToShortDateString

        If (testDate <> dtpDate) Then
            cmd = New SqlCommand("DECLARE @DiscountDate DATE, @DueDate DATE;", con)
            cmd.CommandText += " IF EXISTS(SELECT DiscountDays, DueDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID) "
            cmd.CommandText += " SELECT @DiscountDate = CASE WHEN DiscountDays = 0 THEN DATEADD(DAY,DueDays,@InvoiceDate) ELSE DATEADD(DAY,DiscountDays,@InvoiceDate) END, @DueDate = DATEADD(DAY,DueDays,@InvoiceDate) FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID;"
            cmd.CommandText += " ELSE SELECT @DiscountDate = CASE WHEN DiscountDays = 0 THEN DATEADD(DAY,DueDays,@InvoiceDate) ELSE DATEADD(DAY,DiscountDays,@InvoiceDate) END, @DueDate = DATEADD(DAY,DueDays,@InvoiceDate) FROM PaymentTerms WHERE PmtTermsID = 'N30';"
            cmd.CommandText += " UPDATE ReceiptOfInvoiceBatchLine  SET InvoiceDate = @InvoiceDate, ReceiptDate = @InvoiceDate, DiscountDate = @DiscountDate, DueDate = @DueDate WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber;"
            cmd.CommandText += " SELECT @DiscountDate as DiscountDate, @DueDate as DueDate"

            cmd.Parameters.Add("@VoucherNumber", SqlDbType.Int).Value = dgvRecurrences.Rows(lblRowNumber.Text).Cells("VoucherNumber").Value
            cmd.Parameters.Add("@BatchNumber", SqlDbType.Int).Value = Val(cboBatchNumber.Text)
            cmd.Parameters.Add("@InvoiceDate", SqlDbType.Date).Value = New Date(dtpChangeDate.Value.Year, dtpChangeDate.Value.Month, dtpChangeDate.Value.Day)
            cmd.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text
            Dim discountDate, dueDate As Date
            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                discountDate = reader.Item("DiscountDate")
                dueDate = reader.Item("DueDate")
            End If
            reader.Close()
            con.Close()
            isloaded = False
            dgvRecurrences.Rows(lblRowNumber.Text).Cells("InvoiceDate").Value = dtpChangeDate.Value
            dgvRecurrences.Rows(lblRowNumber.Text).Cells("ReceiptDate").Value = dtpChangeDate.Value
            dgvRecurrences.Rows(lblRowNumber.Text).Cells("DiscountDate").Value = discountDate
            dgvRecurrences.Rows(lblRowNumber.Text).Cells("DueDate").Value = dueDate
            isloaded = True
        End If
    End Sub
End Class