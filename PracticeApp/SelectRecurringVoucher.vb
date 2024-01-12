Imports System.Data.SqlClient
Imports System
Public Class SelectRecurringVoucher
    Dim cmd As SqlCommand
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim ds As DataSet
    Dim adapt As New SqlDataAdapter

    Dim batchNumber As Integer
    Dim division As String

    Public Sub setBatchNumber(ByVal batch As Integer, ByVal div As String)
        batchNumber = batch
        division = div
        LoadDGV()
    End Sub

    Private Sub LoadDGV()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherStatus = 'RECURRING' AND DivisionID = @DivisionID AND DueDate <= @Date", con)
        cmd.Parameters.Add("@Date", SqlDbType.VarChar).Value = Today.Date.AddDays(15)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = division
        ds = New DataSet
        adapt.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        adapt.Fill(ds, "Lines")
        con.Close()
        Dim slt As New DataGridViewCheckBoxColumn
        With slt
            .HeaderText = "Select For Batch"
            .Name = "SelectForBatch"
            .ReadOnly = False
        End With
        dgvSelectLines.Columns.Add(slt)
        dgvSelectLines.DataSource = ds.Tables("Lines")
        setupDGV()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdAddToBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToBatch.Click
        For i As Integer = 0 To dgvSelectLines.Rows.Count - 1
            If dgvSelectLines.Rows(i).Cells("SelectForBatch").Value Then
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET DeleteReferenceNumber = @CurrentBatch, BatchNumber = @BatchNumber, VoucherStatus = 'OPEN' WHERE BatchNumber = @CurrentBatch AND VoucherNumber = @Voucher", con)
                cmd.Parameters.Add("@BatchNumber", SqlDbType.Int).Value = batchNumber
                cmd.Parameters.Add("@CurrentBatch", SqlDbType.VarChar).Value = dgvSelectLines.Rows(i).Cells("BatchNumber").Value
                cmd.Parameters.Add("@Voucher", SqlDbType.VarChar).Value = dgvSelectLines.Rows(i).Cells("VoucherNumber").Value
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        If dgvSelectLines.Rows.Count > 0 Then
            For i As Integer = 0 To dgvSelectLines.Rows.Count - 1
                dgvSelectLines.Rows(i).Cells("SelectForBatch").Value = True
            Next
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        If dgvSelectLines.Rows.Count > 0 Then
            For i As Integer = 0 To dgvSelectLines.Rows.Count - 1
                dgvSelectLines.Rows(i).Cells("SelectForBatch").Value = False
            Next
        End If
    End Sub

    Private Sub setupDGV()
        ''makes some columns inviible to the user
        dgvSelectLines.Columns("BatchNumber").Visible = False
        dgvSelectLines.Columns("DeleteReferenceNumber").Visible = False
        dgvSelectLines.Columns("VoucherSource").Visible = False
        dgvSelectLines.Columns("VendorClass").Visible = False
        dgvSelectLines.Columns("DivisionID").Visible = False
        dgvSelectLines.Columns("InvoiceAmount").Visible = False
        ''sets up the datagridview so that the column names are easier to read
        dgvSelectLines.Columns("VoucherNumber").HeaderText = "Voucher #"
        dgvSelectLines.Columns("PONumber").HeaderText = "PO #"
        dgvSelectLines.Columns("InvoiceNumber").HeaderText = "Invoice #"
        dgvSelectLines.Columns("InvoiceDate").HeaderText = "Invoice Date"
        dgvSelectLines.Columns("ReceiptDate").HeaderText = "Receipt Date"
        dgvSelectLines.Columns("VendorID").HeaderText = "Vendor ID"
        dgvSelectLines.Columns("ProductTotal").HeaderText = "Product Total"
        dgvSelectLines.Columns("InvoiceFreight").HeaderText = "Invoice Freight"
        dgvSelectLines.Columns("InvoiceSalesTax").HeaderText = "Invoice Sales Tax"
        dgvSelectLines.Columns("InvoiceTotal").HeaderText = "Invoice Total"
        dgvSelectLines.Columns("PaymentTerms").HeaderText = "Payment Terms"
        dgvSelectLines.Columns("DiscountDate").HeaderText = "Discount Date"
        dgvSelectLines.Columns("DueDate").HeaderText = "Due Date"
        dgvSelectLines.Columns("DiscountAmount").HeaderText = "Discount Amount"
        dgvSelectLines.Columns("VoucherStatus").HeaderText = "Type"

        For i As Integer = 1 To dgvSelectLines.Columns.Count - 1
            If dgvSelectLines.Columns(i).Visible Then
                dgvSelectLines.Columns(i).ReadOnly = True
            End If
        Next
    End Sub
End Class
