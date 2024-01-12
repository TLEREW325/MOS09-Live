<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectInvoicesForPayment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdCheckAll = New System.Windows.Forms.Button
        Me.cmdUnCheckAll = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvVoucherHeader = New System.Windows.Forms.DataGridView
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.cmdProcessForPayment = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SelectForPay = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OnHoldColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WhitePaperColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Checked1099Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherSourceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvVoucherHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCheckAll
        '
        Me.cmdCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCheckAll.Location = New System.Drawing.Point(12, 421)
        Me.cmdCheckAll.Name = "cmdCheckAll"
        Me.cmdCheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdCheckAll.TabIndex = 23
        Me.cmdCheckAll.Text = "Check All"
        Me.cmdCheckAll.UseVisualStyleBackColor = True
        '
        'cmdUnCheckAll
        '
        Me.cmdUnCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUnCheckAll.Location = New System.Drawing.Point(89, 421)
        Me.cmdUnCheckAll.Name = "cmdUnCheckAll"
        Me.cmdUnCheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdUnCheckAll.TabIndex = 24
        Me.cmdUnCheckAll.Text = "Uncheck All"
        Me.cmdUnCheckAll.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(609, 421)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 25
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvVoucherHeader
        '
        Me.dgvVoucherHeader.AllowUserToAddRows = False
        Me.dgvVoucherHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVoucherHeader.AutoGenerateColumns = False
        Me.dgvVoucherHeader.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvVoucherHeader.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvVoucherHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVoucherHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectForPay, Me.VendorIDColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.DueDateColumn, Me.DiscountDateColumn, Me.DiscountAmountColumn, Me.InvoiceTotalColumn, Me.VoucherNumberColumn, Me.PONumberColumn, Me.ReceiptDateColumn, Me.ProductTotalColumn, Me.InvoiceFreightColumn, Me.InvoiceSalesTaxColumn, Me.PaymentTermsColumn, Me.CommentColumn, Me.CheckTypeColumn, Me.OnHoldColumn, Me.WhitePaperColumn, Me.Checked1099Column, Me.VoucherStatusDataGridViewTextBoxColumn, Me.VoucherSourceDataGridViewTextBoxColumn, Me.BatchNumberDataGridViewTextBoxColumn})
        Me.dgvVoucherHeader.DataSource = Me.ReceiptOfInvoiceBatchLineBindingSource
        Me.dgvVoucherHeader.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvVoucherHeader.Location = New System.Drawing.Point(12, 6)
        Me.dgvVoucherHeader.Name = "dgvVoucherHeader"
        Me.dgvVoucherHeader.Size = New System.Drawing.Size(668, 405)
        Me.dgvVoucherHeader.TabIndex = 26
        '
        'ReceiptOfInvoiceBatchLineBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataMember = "ReceiptOfInvoiceBatchLine"
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReceiptOfInvoiceBatchLineTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineTableAdapter.ClearBeforeFill = True
        '
        'cmdProcessForPayment
        '
        Me.cmdProcessForPayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdProcessForPayment.Location = New System.Drawing.Point(532, 421)
        Me.cmdProcessForPayment.Name = "cmdProcessForPayment"
        Me.cmdProcessForPayment.Size = New System.Drawing.Size(71, 40)
        Me.cmdProcessForPayment.TabIndex = 27
        Me.cmdProcessForPayment.Text = "Process For Payment"
        Me.cmdProcessForPayment.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(166, 434)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(360, 23)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Shaded lines with blue text are ACH Payments."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SelectForPay
        '
        Me.SelectForPay.FalseValue = "UNSELECTED"
        Me.SelectForPay.HeaderText = "Select"
        Me.SelectForPay.Name = "SelectForPay"
        Me.SelectForPay.TrueValue = "SELECTED"
        Me.SelectForPay.Width = 60
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor ID"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.Width = 85
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.Width = 80
        '
        'DueDateColumn
        '
        Me.DueDateColumn.DataPropertyName = "DueDate"
        Me.DueDateColumn.HeaderText = "Due Date"
        Me.DueDateColumn.Name = "DueDateColumn"
        Me.DueDateColumn.Width = 80
        '
        'DiscountDateColumn
        '
        Me.DiscountDateColumn.DataPropertyName = "DiscountDate"
        Me.DiscountDateColumn.HeaderText = "Discount Date"
        Me.DiscountDateColumn.Name = "DiscountDateColumn"
        Me.DiscountDateColumn.Width = 80
        '
        'DiscountAmountColumn
        '
        Me.DiscountAmountColumn.DataPropertyName = "DiscountAmount"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.DiscountAmountColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.DiscountAmountColumn.HeaderText = "Discount Amount"
        Me.DiscountAmountColumn.Name = "DiscountAmountColumn"
        Me.DiscountAmountColumn.Width = 85
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.Width = 85
        '
        'VoucherNumberColumn
        '
        Me.VoucherNumberColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn.HeaderText = "Voucher #"
        Me.VoucherNumberColumn.Name = "VoucherNumberColumn"
        Me.VoucherNumberColumn.Width = 80
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PO #"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.Width = 80
        '
        'ReceiptDateColumn
        '
        Me.ReceiptDateColumn.DataPropertyName = "ReceiptDate"
        Me.ReceiptDateColumn.HeaderText = "Receipt Date"
        Me.ReceiptDateColumn.Name = "ReceiptDateColumn"
        Me.ReceiptDateColumn.Width = 80
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.Width = 90
        '
        'InvoiceFreightColumn
        '
        Me.InvoiceFreightColumn.DataPropertyName = "InvoiceFreight"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.InvoiceFreightColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.InvoiceFreightColumn.HeaderText = "InvoiceFreight"
        Me.InvoiceFreightColumn.Name = "InvoiceFreightColumn"
        '
        'InvoiceSalesTaxColumn
        '
        Me.InvoiceSalesTaxColumn.DataPropertyName = "InvoiceSalesTax"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.InvoiceSalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.InvoiceSalesTaxColumn.HeaderText = "Invoice Sales Tax"
        Me.InvoiceSalesTaxColumn.Name = "InvoiceSalesTaxColumn"
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'CheckTypeColumn
        '
        Me.CheckTypeColumn.DataPropertyName = "CheckType"
        Me.CheckTypeColumn.HeaderText = "Check Type"
        Me.CheckTypeColumn.Name = "CheckTypeColumn"
        '
        'OnHoldColumn
        '
        Me.OnHoldColumn.DataPropertyName = "OnHold"
        Me.OnHoldColumn.HeaderText = "OnHold"
        Me.OnHoldColumn.Name = "OnHoldColumn"
        Me.OnHoldColumn.Visible = False
        '
        'WhitePaperColumn
        '
        Me.WhitePaperColumn.DataPropertyName = "WhitePaper"
        Me.WhitePaperColumn.HeaderText = "White Paper?"
        Me.WhitePaperColumn.Name = "WhitePaperColumn"
        '
        'Checked1099Column
        '
        Me.Checked1099Column.DataPropertyName = "Checked1099"
        Me.Checked1099Column.HeaderText = "Checked1099"
        Me.Checked1099Column.Name = "Checked1099Column"
        Me.Checked1099Column.Visible = False
        '
        'VoucherStatusDataGridViewTextBoxColumn
        '
        Me.VoucherStatusDataGridViewTextBoxColumn.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusDataGridViewTextBoxColumn.HeaderText = "VoucherStatus"
        Me.VoucherStatusDataGridViewTextBoxColumn.Name = "VoucherStatusDataGridViewTextBoxColumn"
        Me.VoucherStatusDataGridViewTextBoxColumn.Visible = False
        '
        'VoucherSourceDataGridViewTextBoxColumn
        '
        Me.VoucherSourceDataGridViewTextBoxColumn.DataPropertyName = "VoucherSource"
        Me.VoucherSourceDataGridViewTextBoxColumn.HeaderText = "VoucherSource"
        Me.VoucherSourceDataGridViewTextBoxColumn.Name = "VoucherSourceDataGridViewTextBoxColumn"
        Me.VoucherSourceDataGridViewTextBoxColumn.Visible = False
        '
        'BatchNumberDataGridViewTextBoxColumn
        '
        Me.BatchNumberDataGridViewTextBoxColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberDataGridViewTextBoxColumn.HeaderText = "BatchNumber"
        Me.BatchNumberDataGridViewTextBoxColumn.Name = "BatchNumberDataGridViewTextBoxColumn"
        Me.BatchNumberDataGridViewTextBoxColumn.Visible = False
        '
        'SelectInvoicesForPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 473)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdProcessForPayment)
        Me.Controls.Add(Me.dgvVoucherHeader)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdCheckAll)
        Me.Controls.Add(Me.cmdUnCheckAll)
        Me.Name = "SelectInvoicesForPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Select Invoices For Payment"
        CType(Me.dgvVoucherHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCheckAll As System.Windows.Forms.Button
    Friend WithEvents cmdUnCheckAll As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvVoucherHeader As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents cmdProcessForPayment As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SelectForPay As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OnHoldColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WhitePaperColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Checked1099Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherSourceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
