<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCashReceipts
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendCashReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendCashBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.chkInvoiceDate = New System.Windows.Forms.CheckBox
        Me.chkPaymentDate = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.ARCustomerPaymentQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.gpxCashReceipts = New System.Windows.Forms.GroupBox
        Me.txtTextSearch = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtCheckNumber = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdViewBatch = New System.Windows.Forms.Button
        Me.cmdViewReceipts = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.dgvCustomerPayment = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPaymentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TenderTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CardNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CardDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CardTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AuthorizationNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDiscountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BankAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARTransactionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTotalCashReceipts = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ARCustomerPaymentQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARCustomerPaymentQueryTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARCustomerPaymentQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxCashReceipts.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCustomerPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem1, Me.AppendCashReceiptToolStripMenuItem, Me.AppendCashBatchToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem1
        '
        Me.PrintListingToolStripMenuItem1.Name = "PrintListingToolStripMenuItem1"
        Me.PrintListingToolStripMenuItem1.Size = New System.Drawing.Size(158, 22)
        Me.PrintListingToolStripMenuItem1.Text = "Print Listing"
        '
        'AppendCashReceiptToolStripMenuItem
        '
        Me.AppendCashReceiptToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppendToolStripMenuItem, Me.ReUploadToolStripMenuItem})
        Me.AppendCashReceiptToolStripMenuItem.Name = "AppendCashReceiptToolStripMenuItem"
        Me.AppendCashReceiptToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.AppendCashReceiptToolStripMenuItem.Text = "Edit Cash Receipt"
        '
        'AppendToolStripMenuItem
        '
        Me.AppendToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanToolStripMenuItem, Me.UploadToolStripMenuItem})
        Me.AppendToolStripMenuItem.Name = "AppendToolStripMenuItem"
        Me.AppendToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.AppendToolStripMenuItem.Text = "Append"
        '
        'ScanToolStripMenuItem
        '
        Me.ScanToolStripMenuItem.Name = "ScanToolStripMenuItem"
        Me.ScanToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ScanToolStripMenuItem.Text = "Scan"
        '
        'UploadToolStripMenuItem
        '
        Me.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem"
        Me.UploadToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.UploadToolStripMenuItem.Text = "Upload"
        '
        'ReUploadToolStripMenuItem
        '
        Me.ReUploadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanToolStripMenuItem1, Me.UploadToolStripMenuItem1})
        Me.ReUploadToolStripMenuItem.Name = "ReUploadToolStripMenuItem"
        Me.ReUploadToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ReUploadToolStripMenuItem.Text = "Re-Upload"
        '
        'ScanToolStripMenuItem1
        '
        Me.ScanToolStripMenuItem1.Name = "ScanToolStripMenuItem1"
        Me.ScanToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.ScanToolStripMenuItem1.Text = "Scan"
        '
        'UploadToolStripMenuItem1
        '
        Me.UploadToolStripMenuItem1.Name = "UploadToolStripMenuItem1"
        Me.UploadToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.UploadToolStripMenuItem1.Text = "Upload"
        '
        'AppendCashBatchToolStripMenuItem
        '
        Me.AppendCashBatchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppendToolStripMenuItem1, Me.ReUploadToolStripMenuItem1})
        Me.AppendCashBatchToolStripMenuItem.Name = "AppendCashBatchToolStripMenuItem"
        Me.AppendCashBatchToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.AppendCashBatchToolStripMenuItem.Text = "Edit Cash Batch"
        '
        'AppendToolStripMenuItem1
        '
        Me.AppendToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AppendToolStripMenuItem2, Me.ScanToolStripMenuItem2})
        Me.AppendToolStripMenuItem1.Name = "AppendToolStripMenuItem1"
        Me.AppendToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.AppendToolStripMenuItem1.Text = "Append"
        '
        'AppendToolStripMenuItem2
        '
        Me.AppendToolStripMenuItem2.Name = "AppendToolStripMenuItem2"
        Me.AppendToolStripMenuItem2.Size = New System.Drawing.Size(107, 22)
        Me.AppendToolStripMenuItem2.Text = "Scan"
        '
        'ScanToolStripMenuItem2
        '
        Me.ScanToolStripMenuItem2.Name = "ScanToolStripMenuItem2"
        Me.ScanToolStripMenuItem2.Size = New System.Drawing.Size(107, 22)
        Me.ScanToolStripMenuItem2.Text = "Upload"
        '
        'ReUploadToolStripMenuItem1
        '
        Me.ReUploadToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScanToolStripMenuItem3, Me.UploadToolStripMenuItem2})
        Me.ReUploadToolStripMenuItem1.Name = "ReUploadToolStripMenuItem1"
        Me.ReUploadToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.ReUploadToolStripMenuItem1.Text = "Re-Upload"
        '
        'ScanToolStripMenuItem3
        '
        Me.ScanToolStripMenuItem3.Name = "ScanToolStripMenuItem3"
        Me.ScanToolStripMenuItem3.Size = New System.Drawing.Size(107, 22)
        Me.ScanToolStripMenuItem3.Text = "Scan"
        '
        'UploadToolStripMenuItem2
        '
        Me.UploadToolStripMenuItem2.Name = "UploadToolStripMenuItem2"
        Me.UploadToolStripMenuItem2.Size = New System.Drawing.Size(107, 22)
        Me.UploadToolStripMenuItem2.Text = "Upload"
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
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'chkInvoiceDate
        '
        Me.chkInvoiceDate.AutoSize = True
        Me.chkInvoiceDate.Location = New System.Drawing.Point(22, 676)
        Me.chkInvoiceDate.Name = "chkInvoiceDate"
        Me.chkInvoiceDate.Size = New System.Drawing.Size(126, 17)
        Me.chkInvoiceDate.TabIndex = 12
        Me.chkInvoiceDate.Text = "Filter by Invoice Date"
        Me.chkInvoiceDate.UseVisualStyleBackColor = True
        '
        'chkPaymentDate
        '
        Me.chkPaymentDate.AutoSize = True
        Me.chkPaymentDate.Checked = True
        Me.chkPaymentDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPaymentDate.Location = New System.Drawing.Point(22, 644)
        Me.chkPaymentDate.Name = "chkPaymentDate"
        Me.chkPaymentDate.Size = New System.Drawing.Size(133, 17)
        Me.chkPaymentDate.TabIndex = 11
        Me.chkPaymentDate.Text = "Filter By Payment Date"
        Me.chkPaymentDate.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(107, 595)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 595)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(107, 559)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 559)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Begin Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Invoice Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(107, 202)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboInvoiceNumber.TabIndex = 4
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(142, 713)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 38)
        Me.cmdViewByFilters.TabIndex = 13
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 264)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Batch Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBatchNumber.DataSource = Me.ARCustomerPaymentQueryBindingSource
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(107, 263)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboBatchNumber.TabIndex = 5
        '
        'ARCustomerPaymentQueryBindingSource
        '
        Me.ARCustomerPaymentQueryBindingSource.DataMember = "ARCustomerPaymentQuery"
        Me.ARCustomerPaymentQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'gpxCashReceipts
        '
        Me.gpxCashReceipts.Controls.Add(Me.txtTextSearch)
        Me.gpxCashReceipts.Controls.Add(Me.Label10)
        Me.gpxCashReceipts.Controls.Add(Me.txtCheckNumber)
        Me.gpxCashReceipts.Controls.Add(Me.Label14)
        Me.gpxCashReceipts.Controls.Add(Me.chkDateRange)
        Me.gpxCashReceipts.Controls.Add(Me.Label12)
        Me.gpxCashReceipts.Controls.Add(Me.cboBatchNumber)
        Me.gpxCashReceipts.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxCashReceipts.Controls.Add(Me.cmdClear)
        Me.gpxCashReceipts.Controls.Add(Me.Label7)
        Me.gpxCashReceipts.Controls.Add(Me.chkInvoiceDate)
        Me.gpxCashReceipts.Controls.Add(Me.cboDivisionID)
        Me.gpxCashReceipts.Controls.Add(Me.Label5)
        Me.gpxCashReceipts.Controls.Add(Me.cboCustomerID)
        Me.gpxCashReceipts.Controls.Add(Me.chkPaymentDate)
        Me.gpxCashReceipts.Controls.Add(Me.cboCustomerName)
        Me.gpxCashReceipts.Controls.Add(Me.cmdViewByFilters)
        Me.gpxCashReceipts.Controls.Add(Me.Label2)
        Me.gpxCashReceipts.Controls.Add(Me.dtpEndDate)
        Me.gpxCashReceipts.Controls.Add(Me.Label1)
        Me.gpxCashReceipts.Controls.Add(Me.Label8)
        Me.gpxCashReceipts.Controls.Add(Me.dtpBeginDate)
        Me.gpxCashReceipts.Controls.Add(Me.Label3)
        Me.gpxCashReceipts.Controls.Add(Me.Label6)
        Me.gpxCashReceipts.Location = New System.Drawing.Point(29, 41)
        Me.gpxCashReceipts.Name = "gpxCashReceipts"
        Me.gpxCashReceipts.Size = New System.Drawing.Size(300, 770)
        Me.gpxCashReceipts.TabIndex = 0
        Me.gpxCashReceipts.TabStop = False
        Me.gpxCashReceipts.Text = "View By Filters"
        '
        'txtTextSearch
        '
        Me.txtTextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextSearch.Location = New System.Drawing.Point(107, 384)
        Me.txtTextSearch.Name = "txtTextSearch"
        Me.txtTextSearch.Size = New System.Drawing.Size(178, 20)
        Me.txtTextSearch.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(19, 384)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 20)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Text Search"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.Location = New System.Drawing.Point(107, 324)
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(178, 20)
        Me.txtCheckNumber.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(28, 489)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(257, 33)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(107, 525)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 8
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(22, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(263, 42)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 713)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 38)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(107, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(178, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(77, 127)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(208, 21)
        Me.cboCustomerID.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(22, 158)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(263, 21)
        Me.cboCustomerName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Customer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 324)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 20)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Check Number"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewBatch
        '
        Me.cmdViewBatch.Enabled = False
        Me.cmdViewBatch.Location = New System.Drawing.Point(808, 773)
        Me.cmdViewBatch.Name = "cmdViewBatch"
        Me.cmdViewBatch.Size = New System.Drawing.Size(71, 38)
        Me.cmdViewBatch.TabIndex = 18
        Me.cmdViewBatch.Text = "View Cash Batch"
        Me.cmdViewBatch.UseVisualStyleBackColor = True
        '
        'cmdViewReceipts
        '
        Me.cmdViewReceipts.Enabled = False
        Me.cmdViewReceipts.Location = New System.Drawing.Point(733, 773)
        Me.cmdViewReceipts.Name = "cmdViewReceipts"
        Me.cmdViewReceipts.Size = New System.Drawing.Size(71, 38)
        Me.cmdViewReceipts.TabIndex = 17
        Me.cmdViewReceipts.Text = "View Cash Receipt"
        Me.cmdViewReceipts.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvCustomerPayment
        '
        Me.dgvCustomerPayment.AllowUserToAddRows = False
        Me.dgvCustomerPayment.AllowUserToDeleteRows = False
        Me.dgvCustomerPayment.AllowUserToOrderColumns = True
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCustomerPayment.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCustomerPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCustomerPayment.AutoGenerateColumns = False
        Me.dgvCustomerPayment.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCustomerPayment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCustomerPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerPayment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.CustomerIDColumn, Me.PaymentDateColumn, Me.CheckNumberColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.InvoiceTotalColumn, Me.PaymentAmountColumn, Me.TotalPaymentsColumn, Me.InvoiceAmountOpenColumn, Me.PaymentTypeColumn, Me.CheckCommentColumn, Me.TenderTypeColumn, Me.CardNumberColumn, Me.CardDateColumn, Me.CardTypeColumn, Me.AuthorizationNumberColumn, Me.ReferenceNumberColumn, Me.CreditCommentColumn, Me.BatchNumberColumn, Me.PaymentIDColumn, Me.PaymentLineNumberColumn, Me.StatusColumn, Me.InvoiceStatusColumn, Me.DiscountAmountColumn, Me.InvoiceAmountColumn, Me.TotalDiscountColumn, Me.BankAccountColumn, Me.ARTransactionKeyColumn})
        Me.dgvCustomerPayment.DataSource = Me.ARCustomerPaymentQueryBindingSource
        Me.dgvCustomerPayment.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvCustomerPayment.Location = New System.Drawing.Point(345, 41)
        Me.dgvCustomerPayment.Name = "dgvCustomerPayment"
        Me.dgvCustomerPayment.Size = New System.Drawing.Size(687, 715)
        Me.dgvCustomerPayment.TabIndex = 16
        Me.dgvCustomerPayment.TabStop = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        Me.DivisionIDColumn.Width = 69
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'PaymentDateColumn
        '
        Me.PaymentDateColumn.DataPropertyName = "PaymentDate"
        Me.PaymentDateColumn.HeaderText = "Payment Date"
        Me.PaymentDateColumn.Name = "PaymentDateColumn"
        Me.PaymentDateColumn.Width = 85
        '
        'CheckNumberColumn
        '
        Me.CheckNumberColumn.DataPropertyName = "CheckNumber"
        Me.CheckNumberColumn.HeaderText = "Check #"
        Me.CheckNumberColumn.Name = "CheckNumberColumn"
        Me.CheckNumberColumn.Width = 65
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.ReadOnly = True
        Me.InvoiceNumberColumn.Width = 85
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.Width = 85
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.ReadOnly = True
        Me.InvoiceTotalColumn.Width = 85
        '
        'PaymentAmountColumn
        '
        Me.PaymentAmountColumn.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.PaymentAmountColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.PaymentAmountColumn.HeaderText = "Payment Amount"
        Me.PaymentAmountColumn.Name = "PaymentAmountColumn"
        Me.PaymentAmountColumn.ReadOnly = True
        Me.PaymentAmountColumn.Width = 85
        '
        'TotalPaymentsColumn
        '
        Me.TotalPaymentsColumn.DataPropertyName = "TotalPayments"
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0"
        Me.TotalPaymentsColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.TotalPaymentsColumn.HeaderText = "Total Payments"
        Me.TotalPaymentsColumn.Name = "TotalPaymentsColumn"
        Me.TotalPaymentsColumn.ReadOnly = True
        Me.TotalPaymentsColumn.Width = 85
        '
        'InvoiceAmountOpenColumn
        '
        Me.InvoiceAmountOpenColumn.DataPropertyName = "InvoiceAmountOpen"
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.InvoiceAmountOpenColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.InvoiceAmountOpenColumn.HeaderText = "Invoice Amount Open"
        Me.InvoiceAmountOpenColumn.Name = "InvoiceAmountOpenColumn"
        Me.InvoiceAmountOpenColumn.ReadOnly = True
        Me.InvoiceAmountOpenColumn.Width = 85
        '
        'PaymentTypeColumn
        '
        Me.PaymentTypeColumn.DataPropertyName = "PaymentType"
        Me.PaymentTypeColumn.HeaderText = "Payment Type"
        Me.PaymentTypeColumn.Name = "PaymentTypeColumn"
        Me.PaymentTypeColumn.Width = 85
        '
        'CheckCommentColumn
        '
        Me.CheckCommentColumn.DataPropertyName = "CheckComment"
        Me.CheckCommentColumn.HeaderText = "Check Comment"
        Me.CheckCommentColumn.Name = "CheckCommentColumn"
        Me.CheckCommentColumn.Width = 101
        '
        'TenderTypeColumn
        '
        Me.TenderTypeColumn.DataPropertyName = "TenderType"
        Me.TenderTypeColumn.HeaderText = "Tender Type"
        Me.TenderTypeColumn.Name = "TenderTypeColumn"
        Me.TenderTypeColumn.Width = 85
        '
        'CardNumberColumn
        '
        Me.CardNumberColumn.DataPropertyName = "CardNumber"
        Me.CardNumberColumn.HeaderText = "Card #"
        Me.CardNumberColumn.Name = "CardNumberColumn"
        Me.CardNumberColumn.Width = 60
        '
        'CardDateColumn
        '
        Me.CardDateColumn.DataPropertyName = "CardDate"
        Me.CardDateColumn.HeaderText = "Card Date"
        Me.CardDateColumn.Name = "CardDateColumn"
        Me.CardDateColumn.Width = 85
        '
        'CardTypeColumn
        '
        Me.CardTypeColumn.DataPropertyName = "CardType"
        Me.CardTypeColumn.HeaderText = "Card Type"
        Me.CardTypeColumn.Name = "CardTypeColumn"
        Me.CardTypeColumn.Width = 85
        '
        'AuthorizationNumberColumn
        '
        Me.AuthorizationNumberColumn.DataPropertyName = "AuthorizationNumber"
        Me.AuthorizationNumberColumn.HeaderText = "Authorization #"
        Me.AuthorizationNumberColumn.Name = "AuthorizationNumberColumn"
        Me.AuthorizationNumberColumn.Width = 85
        '
        'ReferenceNumberColumn
        '
        Me.ReferenceNumberColumn.DataPropertyName = "ReferenceNumber"
        Me.ReferenceNumberColumn.HeaderText = "Reference #"
        Me.ReferenceNumberColumn.Name = "ReferenceNumberColumn"
        Me.ReferenceNumberColumn.Width = 85
        '
        'CreditCommentColumn
        '
        Me.CreditCommentColumn.DataPropertyName = "CreditComment"
        Me.CreditCommentColumn.HeaderText = "Credit Comment"
        Me.CreditCommentColumn.Name = "CreditCommentColumn"
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "Batch #"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.ReadOnly = True
        Me.BatchNumberColumn.Width = 65
        '
        'PaymentIDColumn
        '
        Me.PaymentIDColumn.DataPropertyName = "PaymentID"
        Me.PaymentIDColumn.HeaderText = "Payment ID"
        Me.PaymentIDColumn.Name = "PaymentIDColumn"
        Me.PaymentIDColumn.ReadOnly = True
        Me.PaymentIDColumn.Width = 80
        '
        'PaymentLineNumberColumn
        '
        Me.PaymentLineNumberColumn.DataPropertyName = "PaymentLineNumber"
        Me.PaymentLineNumberColumn.HeaderText = "Payment Line #"
        Me.PaymentLineNumberColumn.Name = "PaymentLineNumberColumn"
        Me.PaymentLineNumberColumn.ReadOnly = True
        Me.PaymentLineNumberColumn.Width = 65
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
        Me.StatusColumn.Width = 85
        '
        'InvoiceStatusColumn
        '
        Me.InvoiceStatusColumn.DataPropertyName = "InvoiceStatus"
        Me.InvoiceStatusColumn.HeaderText = "InvoiceStatus"
        Me.InvoiceStatusColumn.Name = "InvoiceStatusColumn"
        Me.InvoiceStatusColumn.Visible = False
        Me.InvoiceStatusColumn.Width = 97
        '
        'DiscountAmountColumn
        '
        Me.DiscountAmountColumn.DataPropertyName = "DiscountAmount"
        Me.DiscountAmountColumn.HeaderText = "DiscountAmount"
        Me.DiscountAmountColumn.Name = "DiscountAmountColumn"
        Me.DiscountAmountColumn.Visible = False
        Me.DiscountAmountColumn.Width = 110
        '
        'InvoiceAmountColumn
        '
        Me.InvoiceAmountColumn.DataPropertyName = "InvoiceAmount"
        Me.InvoiceAmountColumn.HeaderText = "InvoiceAmount"
        Me.InvoiceAmountColumn.Name = "InvoiceAmountColumn"
        Me.InvoiceAmountColumn.Visible = False
        Me.InvoiceAmountColumn.Width = 103
        '
        'TotalDiscountColumn
        '
        Me.TotalDiscountColumn.DataPropertyName = "TotalDiscount"
        Me.TotalDiscountColumn.HeaderText = "TotalDiscount"
        Me.TotalDiscountColumn.Name = "TotalDiscountColumn"
        Me.TotalDiscountColumn.ReadOnly = True
        Me.TotalDiscountColumn.Visible = False
        Me.TotalDiscountColumn.Width = 98
        '
        'BankAccountColumn
        '
        Me.BankAccountColumn.DataPropertyName = "BankAccount"
        Me.BankAccountColumn.HeaderText = "BankAccount"
        Me.BankAccountColumn.Name = "BankAccountColumn"
        Me.BankAccountColumn.Visible = False
        Me.BankAccountColumn.Width = 97
        '
        'ARTransactionKeyColumn
        '
        Me.ARTransactionKeyColumn.DataPropertyName = "ARTransactionKey"
        Me.ARTransactionKeyColumn.HeaderText = "ARTransactionKey"
        Me.ARTransactionKeyColumn.Name = "ARTransactionKeyColumn"
        Me.ARTransactionKeyColumn.Visible = False
        Me.ARTransactionKeyColumn.Width = 121
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(958, 773)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 20
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(883, 773)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 19
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(354, 781)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 20)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Total Receipts"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalCashReceipts
        '
        Me.txtTotalCashReceipts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalCashReceipts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCashReceipts.Location = New System.Drawing.Point(437, 781)
        Me.txtTotalCashReceipts.Name = "txtTotalCashReceipts"
        Me.txtTotalCashReceipts.Size = New System.Drawing.Size(162, 20)
        Me.txtTotalCashReceipts.TabIndex = 15
        Me.txtTotalCashReceipts.TabStop = False
        Me.txtTotalCashReceipts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(605, 781)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 20)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "(Total from datagrid)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ARCustomerPaymentQueryTableAdapter
        '
        Me.ARCustomerPaymentQueryTableAdapter.ClearBeforeFill = True
        '
        'ViewCashReceipts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdViewBatch)
        Me.Controls.Add(Me.cmdViewReceipts)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTotalCashReceipts)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvCustomerPayment)
        Me.Controls.Add(Me.gpxCashReceipts)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewCashReceipts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Cash Receipts"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARCustomerPaymentQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxCashReceipts.ResumeLayout(False)
        Me.gpxCashReceipts.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCustomerPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents gpxCashReceipts As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dgvCustomerPayment As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCashReceipts As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkInvoiceDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkPaymentDate As System.Windows.Forms.CheckBox
    Friend WithEvents PrintListingToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ARCustomerPaymentQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARCustomerPaymentQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARCustomerPaymentQueryTableAdapter
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents txtCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTextSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPaymentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TenderTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CardNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CardDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CardTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AuthorizationNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDiscountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARTransactionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdViewReceipts As System.Windows.Forms.Button
    Friend WithEvents cmdViewBatch As System.Windows.Forms.Button
    Friend WithEvents AppendCashReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendCashBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReUploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReUploadToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScanToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
End Class
