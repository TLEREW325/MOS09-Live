<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewEFTRemittance
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboCheckType = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.lblDateFilter = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvVouchers = New System.Windows.Forms.DataGridView
        Me.PaidDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RemittanceEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherSourceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CompanyNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeleteReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WhitePaperCheckColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OnHoldColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptOfInvoiceBatchLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceiptOfInvoiceBatchLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineQueryTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdRemmittance = New System.Windows.Forms.Button
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdEmailRemittance = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtInvoiceTotal = New System.Windows.Forms.TextBox
        Me.txtNumberOfInvoices = New System.Windows.Forms.TextBox
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVouchers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCheckType)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cmdViewByFilter)
        Me.GroupBox1.Controls.Add(Me.dtpEndDate)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.dtpBeginDate)
        Me.GroupBox1.Controls.Add(Me.lblDateFilter)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 338)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select By Filters"
        '
        'cboCheckType
        '
        Me.cboCheckType.FormattingEnabled = True
        Me.cboCheckType.Items.AddRange(New Object() {"STANDARD", "ACH", "FEDEX", "INTERCOMPANY"})
        Me.cboCheckType.Location = New System.Drawing.Point(101, 134)
        Me.cboCheckType.Name = "cboCheckType"
        Me.cboCheckType.Size = New System.Drawing.Size(180, 21)
        Me.cboCheckType.TabIndex = 72
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(20, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(261, 40)
        Me.Label12.TabIndex = 71
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(211, 291)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 67
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(137, 291)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 65
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(101, 254)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpEndDate.TabIndex = 59
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 254)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "End Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(105, 21)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(176, 21)
        Me.cboDivisionID.TabIndex = 44
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(101, 218)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpBeginDate.TabIndex = 58
        '
        'lblDateFilter
        '
        Me.lblDateFilter.Location = New System.Drawing.Point(20, 218)
        Me.lblDateFilter.Name = "lblDateFilter"
        Me.lblDateFilter.Size = New System.Drawing.Size(100, 20)
        Me.lblDateFilter.TabIndex = 61
        Me.lblDateFilter.Text = "Begin Date"
        Me.lblDateFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Check Type"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvVouchers
        '
        Me.dgvVouchers.AllowUserToAddRows = False
        Me.dgvVouchers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVouchers.AutoGenerateColumns = False
        Me.dgvVouchers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvVouchers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvVouchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVouchers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PaidDateColumn, Me.DivisionIDColumn, Me.VendorIDColumn, Me.VoucherNumberColumn, Me.BatchNumberColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.ProductTotalColumn, Me.InvoiceFreightColumn, Me.InvoiceSalesTaxColumn, Me.InvoiceTotalColumn, Me.PaymentTermsColumn, Me.DiscountDateColumn, Me.DueDateColumn, Me.RemittanceEmailColumn, Me.VendorAccountNumberColumn, Me.ReceiptDateColumn, Me.CommentColumn, Me.VoucherStatusColumn, Me.VoucherSourceColumn, Me.CompanyNameColumn, Me.VendorNameColumn, Me.DiscountAmountColumn, Me.InvoiceAmountColumn, Me.DeleteReferenceNumberColumn, Me.WhitePaperCheckColumn, Me.OnHoldColumn, Me.CheckTypeColumn, Me.CheckCodeColumn, Me.VendorClassColumn, Me.PONumberColumn})
        Me.dgvVouchers.DataSource = Me.ReceiptOfInvoiceBatchLineQueryBindingSource
        Me.dgvVouchers.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvVouchers.Location = New System.Drawing.Point(345, 41)
        Me.dgvVouchers.Name = "dgvVouchers"
        Me.dgvVouchers.Size = New System.Drawing.Size(785, 657)
        Me.dgvVouchers.TabIndex = 2
        '
        'PaidDateColumn
        '
        Me.PaidDateColumn.DataPropertyName = "PaidDate"
        Me.PaidDateColumn.HeaderText = "Paid Date"
        Me.PaidDateColumn.Name = "PaidDateColumn"
        Me.PaidDateColumn.Width = 80
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Width = 65
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor ID"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        '
        'VoucherNumberColumn
        '
        Me.VoucherNumberColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn.HeaderText = "Voucher #"
        Me.VoucherNumberColumn.Name = "VoucherNumberColumn"
        Me.VoucherNumberColumn.Width = 80
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "Batch #"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Width = 80
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.Width = 80
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.Width = 80
        '
        'InvoiceFreightColumn
        '
        Me.InvoiceFreightColumn.DataPropertyName = "InvoiceFreight"
        Me.InvoiceFreightColumn.HeaderText = "Freight"
        Me.InvoiceFreightColumn.Name = "InvoiceFreightColumn"
        Me.InvoiceFreightColumn.Width = 80
        '
        'InvoiceSalesTaxColumn
        '
        Me.InvoiceSalesTaxColumn.DataPropertyName = "InvoiceSalesTax"
        Me.InvoiceSalesTaxColumn.HeaderText = "Sales Tax"
        Me.InvoiceSalesTaxColumn.Name = "InvoiceSalesTaxColumn"
        Me.InvoiceSalesTaxColumn.Width = 80
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.Width = 80
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        Me.PaymentTermsColumn.Width = 80
        '
        'DiscountDateColumn
        '
        Me.DiscountDateColumn.DataPropertyName = "DiscountDate"
        Me.DiscountDateColumn.HeaderText = "Discount Date"
        Me.DiscountDateColumn.Name = "DiscountDateColumn"
        Me.DiscountDateColumn.Width = 80
        '
        'DueDateColumn
        '
        Me.DueDateColumn.DataPropertyName = "DueDate"
        Me.DueDateColumn.HeaderText = "Due Date"
        Me.DueDateColumn.Name = "DueDateColumn"
        Me.DueDateColumn.Width = 80
        '
        'RemittanceEmailColumn
        '
        Me.RemittanceEmailColumn.DataPropertyName = "RemittanceEmail"
        Me.RemittanceEmailColumn.HeaderText = "Remittance Email"
        Me.RemittanceEmailColumn.Name = "RemittanceEmailColumn"
        '
        'VendorAccountNumberColumn
        '
        Me.VendorAccountNumberColumn.DataPropertyName = "VendorAccountNumber"
        Me.VendorAccountNumberColumn.HeaderText = "Account #"
        Me.VendorAccountNumberColumn.Name = "VendorAccountNumberColumn"
        '
        'ReceiptDateColumn
        '
        Me.ReceiptDateColumn.DataPropertyName = "ReceiptDate"
        Me.ReceiptDateColumn.HeaderText = "Receipt Date"
        Me.ReceiptDateColumn.Name = "ReceiptDateColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'VoucherStatusColumn
        '
        Me.VoucherStatusColumn.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusColumn.HeaderText = "Voucher Status"
        Me.VoucherStatusColumn.Name = "VoucherStatusColumn"
        '
        'VoucherSourceColumn
        '
        Me.VoucherSourceColumn.DataPropertyName = "VoucherSource"
        Me.VoucherSourceColumn.HeaderText = "Voucher Source"
        Me.VoucherSourceColumn.Name = "VoucherSourceColumn"
        '
        'CompanyNameColumn
        '
        Me.CompanyNameColumn.DataPropertyName = "CompanyName"
        Me.CompanyNameColumn.HeaderText = "CompanyName"
        Me.CompanyNameColumn.Name = "CompanyNameColumn"
        Me.CompanyNameColumn.Visible = False
        '
        'VendorNameColumn
        '
        Me.VendorNameColumn.DataPropertyName = "VendorName"
        Me.VendorNameColumn.HeaderText = "VendorName"
        Me.VendorNameColumn.Name = "VendorNameColumn"
        Me.VendorNameColumn.Visible = False
        '
        'DiscountAmountColumn
        '
        Me.DiscountAmountColumn.DataPropertyName = "DiscountAmount"
        Me.DiscountAmountColumn.HeaderText = "DiscountAmount"
        Me.DiscountAmountColumn.Name = "DiscountAmountColumn"
        Me.DiscountAmountColumn.Visible = False
        '
        'InvoiceAmountColumn
        '
        Me.InvoiceAmountColumn.DataPropertyName = "InvoiceAmount"
        Me.InvoiceAmountColumn.HeaderText = "Invoice Amount"
        Me.InvoiceAmountColumn.Name = "InvoiceAmountColumn"
        Me.InvoiceAmountColumn.Visible = False
        '
        'DeleteReferenceNumberColumn
        '
        Me.DeleteReferenceNumberColumn.DataPropertyName = "DeleteReferenceNumber"
        Me.DeleteReferenceNumberColumn.HeaderText = "DeleteReferenceNumber"
        Me.DeleteReferenceNumberColumn.Name = "DeleteReferenceNumberColumn"
        Me.DeleteReferenceNumberColumn.Visible = False
        '
        'WhitePaperCheckColumn
        '
        Me.WhitePaperCheckColumn.DataPropertyName = "WhitePaperCheck"
        Me.WhitePaperCheckColumn.HeaderText = "WhitePaperCheck"
        Me.WhitePaperCheckColumn.Name = "WhitePaperCheckColumn"
        Me.WhitePaperCheckColumn.Visible = False
        '
        'OnHoldColumn
        '
        Me.OnHoldColumn.DataPropertyName = "OnHold"
        Me.OnHoldColumn.HeaderText = "OnHold"
        Me.OnHoldColumn.Name = "OnHoldColumn"
        Me.OnHoldColumn.Visible = False
        '
        'CheckTypeColumn
        '
        Me.CheckTypeColumn.DataPropertyName = "CheckType"
        Me.CheckTypeColumn.HeaderText = "CheckType"
        Me.CheckTypeColumn.Name = "CheckTypeColumn"
        Me.CheckTypeColumn.Visible = False
        '
        'CheckCodeColumn
        '
        Me.CheckCodeColumn.DataPropertyName = "CheckCode"
        Me.CheckCodeColumn.HeaderText = "Check Code"
        Me.CheckCodeColumn.Name = "CheckCodeColumn"
        Me.CheckCodeColumn.Visible = False
        '
        'VendorClassColumn
        '
        Me.VendorClassColumn.DataPropertyName = "VendorClass"
        Me.VendorClassColumn.HeaderText = "Vendor Class"
        Me.VendorClassColumn.Name = "VendorClassColumn"
        Me.VendorClassColumn.Visible = False
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PO #"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.Visible = False
        '
        'ReceiptOfInvoiceBatchLineQueryBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineQueryBindingSource.DataMember = "ReceiptOfInvoiceBatchLineQuery"
        Me.ReceiptOfInvoiceBatchLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ReceiptOfInvoiceBatchLineQueryTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineQueryTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 18
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 19
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdRemmittance
        '
        Me.cmdRemmittance.Location = New System.Drawing.Point(199, 33)
        Me.cmdRemmittance.Name = "cmdRemmittance"
        Me.cmdRemmittance.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemmittance.TabIndex = 20
        Me.cmdRemmittance.Text = "Remittance Report"
        Me.cmdRemmittance.UseVisualStyleBackColor = True
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Location = New System.Drawing.Point(199, 140)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(71, 40)
        Me.cmdExportExcel.TabIndex = 21
        Me.cmdExportExcel.Text = "View Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmdEmailRemittance)
        Me.GroupBox2.Controls.Add(Me.cmdExportExcel)
        Me.GroupBox2.Controls.Add(Me.cmdRemmittance)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 385)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 313)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print / Export"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(23, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(170, 40)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "Automatically email the Excel File to FEDEX after the EFT is made."
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(20, 140)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(170, 40)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "Exports and opens the Excel File to view."
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(23, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 40)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Print Summary Report to be accompanied with the white paper checks."
        '
        'cmdEmailRemittance
        '
        Me.cmdEmailRemittance.Location = New System.Drawing.Point(199, 244)
        Me.cmdEmailRemittance.Name = "cmdEmailRemittance"
        Me.cmdEmailRemittance.Size = New System.Drawing.Size(71, 40)
        Me.cmdEmailRemittance.TabIndex = 22
        Me.cmdEmailRemittance.Text = "Email Remittance"
        Me.cmdEmailRemittance.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtInvoiceTotal)
        Me.GroupBox3.Controls.Add(Me.txtNumberOfInvoices)
        Me.GroupBox3.Location = New System.Drawing.Point(345, 714)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(341, 97)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datagrid Total"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 20)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Remittance Total"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "# of Invoices"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceTotal
        '
        Me.txtInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceTotal.Location = New System.Drawing.Point(138, 54)
        Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
        Me.txtInvoiceTotal.Size = New System.Drawing.Size(184, 20)
        Me.txtInvoiceTotal.TabIndex = 1
        Me.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumberOfInvoices
        '
        Me.txtNumberOfInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfInvoices.Location = New System.Drawing.Point(138, 28)
        Me.txtNumberOfInvoices.Name = "txtNumberOfInvoices"
        Me.txtNumberOfInvoices.Size = New System.Drawing.Size(184, 20)
        Me.txtNumberOfInvoices.TabIndex = 0
        Me.txtNumberOfInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ViewEFTRemittance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvVouchers)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewEFTRemittance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corpration EFT Remittance"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVouchers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvVouchers As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceiptOfInvoiceBatchLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineQueryTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdRemmittance As System.Windows.Forms.Button
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateFilter As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCheckType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberOfInvoices As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdEmailRemittance As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PaidDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemittanceEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherSourceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompanyNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeleteReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WhitePaperCheckColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OnHoldColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
