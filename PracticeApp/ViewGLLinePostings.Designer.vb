<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewGLLinePostings
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxInvoiceFilter = New System.Windows.Forms.GroupBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cboAccountDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cboAccountNumber = New System.Windows.Forms.ComboBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.dgvGLInvoiceLines = New System.Windows.Forms.DataGridView
        Me.IVGLTransactionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVGLTransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVGLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVGLTransactionDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVGLTransactionDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVGLTransactionCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVPartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityBilledColumnIV = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVGLTransactionCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVGLReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVGLReferenceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVCustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVInvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVSalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVGLTransactionStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVGLJournalIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVGLBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLInvoiceLineDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLInvoiceLineDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLInvoiceLineDataTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrintReport = New System.Windows.Forms.Button
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdoShipment = New System.Windows.Forms.RadioButton
        Me.rdoReceiver = New System.Windows.Forms.RadioButton
        Me.rdoWCProduction = New System.Windows.Forms.RadioButton
        Me.rdoInvoice = New System.Windows.Forms.RadioButton
        Me.dgvReceivingLines = New System.Windows.Forms.DataGridView
        Me.RCGLTransactionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCGLTransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCGLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCGLTransactionDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCGLTransactionDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCGLTransactionCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCGLTransactionCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCGLJournalIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCGLBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCGLReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCGLReferenceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCPartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCQuantityReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCUnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCVendorCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCGLTransactionStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RCDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReceivingLineDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLReceivingLineDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLReceivingLineDataTableAdapter
        Me.dgvShipmentLines = New System.Windows.Forms.DataGridView
        Me.SHGLTransactionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHGLTransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHGLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHGLTransactionDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHGLTransactionDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHGLTransactionCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHGLTransactionCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHGLReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHGLReferenceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHPartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHQuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHCustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHGLBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHGLJournalIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHGLTransactionStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLShipmentLineDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLShipmentLineDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLShipmentLineDataTableAdapter
        Me.dgvWCLines = New System.Windows.Forms.DataGridView
        Me.WCGLTransactionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCGLTransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCGLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCGLTransactionDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCGLTransactionDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCGLTransactionCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCGLReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCGLReferenceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCPartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCProductionQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCUnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCGLTransactionCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCGLJournalIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCGLBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCGLTransactionStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLWCProductionLineDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLWCProductionLineDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLWCProductionLineDataTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxInvoiceFilter.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGLInvoiceLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLInvoiceLineDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvReceivingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLReceivingLineDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShipmentLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLShipmentLineDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWCLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLWCProductionLineDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
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
        'gpxInvoiceFilter
        '
        Me.gpxInvoiceFilter.Controls.Add(Me.txtVendorName)
        Me.gpxInvoiceFilter.Controls.Add(Me.cboVendorID)
        Me.gpxInvoiceFilter.Controls.Add(Me.Label4)
        Me.gpxInvoiceFilter.Controls.Add(Me.Label14)
        Me.gpxInvoiceFilter.Controls.Add(Me.chkDateRange)
        Me.gpxInvoiceFilter.Controls.Add(Me.cboAccountDescription)
        Me.gpxInvoiceFilter.Controls.Add(Me.cboCustomerID)
        Me.gpxInvoiceFilter.Controls.Add(Me.dtpEndDate)
        Me.gpxInvoiceFilter.Controls.Add(Me.cboCustomerName)
        Me.gpxInvoiceFilter.Controls.Add(Me.Label3)
        Me.gpxInvoiceFilter.Controls.Add(Me.dtpBeginDate)
        Me.gpxInvoiceFilter.Controls.Add(Me.cmdViewByFilters)
        Me.gpxInvoiceFilter.Controls.Add(Me.cboAccountNumber)
        Me.gpxInvoiceFilter.Controls.Add(Me.cmdClear)
        Me.gpxInvoiceFilter.Controls.Add(Me.Label2)
        Me.gpxInvoiceFilter.Controls.Add(Me.Label9)
        Me.gpxInvoiceFilter.Controls.Add(Me.cboPartNumber)
        Me.gpxInvoiceFilter.Controls.Add(Me.cboPartDescription)
        Me.gpxInvoiceFilter.Controls.Add(Me.Label5)
        Me.gpxInvoiceFilter.Controls.Add(Me.Label7)
        Me.gpxInvoiceFilter.Location = New System.Drawing.Point(27, 245)
        Me.gpxInvoiceFilter.Name = "gpxInvoiceFilter"
        Me.gpxInvoiceFilter.Size = New System.Drawing.Size(304, 566)
        Me.gpxInvoiceFilter.TabIndex = 0
        Me.gpxInvoiceFilter.TabStop = False
        Me.gpxInvoiceFilter.Text = "View By Filters"
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(21, 153)
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(264, 20)
        Me.txtVendorName.TabIndex = 47
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.CustomerListBindingSource
        Me.cboVendorID.DisplayMember = "CustomerID"
        Me.cboVendorID.DropDownWidth = 250
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(96, 121)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(189, 21)
        Me.cboVendorID.TabIndex = 44
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(21, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 20)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Vendor"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(21, 388)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(255, 33)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(99, 424)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 42
        Me.chkDateRange.TabStop = False
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cboAccountDescription
        '
        Me.cboAccountDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboAccountDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboAccountDescription.DropDownWidth = 300
        Me.cboAccountDescription.FormattingEnabled = True
        Me.cboAccountDescription.Location = New System.Drawing.Point(21, 340)
        Me.cboAccountDescription.Name = "cboAccountDescription"
        Me.cboAccountDescription.Size = New System.Drawing.Size(264, 21)
        Me.cboAccountDescription.TabIndex = 15
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(96, 31)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(189, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(97, 483)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpEndDate.TabIndex = 11
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(20, 62)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(265, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Customer ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(97, 448)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpBeginDate.TabIndex = 10
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(138, 520)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(72, 30)
        Me.cmdViewByFilters.TabIndex = 3
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cboAccountNumber
        '
        Me.cboAccountNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountNumber.DataSource = Me.GLAccountsBindingSource
        Me.cboAccountNumber.DisplayMember = "GLAccountNumber"
        Me.cboAccountNumber.DropDownWidth = 250
        Me.cboAccountNumber.FormattingEnabled = True
        Me.cboAccountNumber.Location = New System.Drawing.Point(96, 304)
        Me.cboAccountNumber.Name = "cboAccountNumber"
        Me.cboAccountNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboAccountNumber.TabIndex = 14
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 520)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(72, 30)
        Me.cmdClear.TabIndex = 4
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 483)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "End Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(21, 304)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 20)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Account #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(96, 209)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboPartNumber.TabIndex = 5
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 300
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(21, 246)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(264, 21)
        Me.cboPartDescription.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(21, 210)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 20)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Part Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 448)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Begin Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(96, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(189, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'dgvGLInvoiceLines
        '
        Me.dgvGLInvoiceLines.AllowUserToAddRows = False
        Me.dgvGLInvoiceLines.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvGLInvoiceLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGLInvoiceLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvGLInvoiceLines.AutoGenerateColumns = False
        Me.dgvGLInvoiceLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvGLInvoiceLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvGLInvoiceLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLInvoiceLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IVGLTransactionColumn, Me.IVGLTransactionDateColumn, Me.IVGLAccountNumberColumn, Me.IVGLTransactionDescriptionColumn, Me.IVGLTransactionDebitAmountColumn, Me.IVGLTransactionCreditAmountColumn, Me.IVPartNumberColumn, Me.IVPartDescriptionColumn, Me.QuantityBilledColumnIV, Me.IVPriceColumn, Me.IVExtendedAmountColumn, Me.IVGLTransactionCommentColumn, Me.IVGLReferenceNumberColumn, Me.IVGLReferenceLineColumn, Me.IVCustomerIDColumn, Me.IVInvoiceDateColumn, Me.IVSalesOrderNumberColumn, Me.IVShipmentNumberColumn, Me.IVGLTransactionStatusColumn, Me.IVDivisionIDColumn, Me.IVGLJournalIDColumn, Me.IVGLBatchNumberColumn})
        Me.dgvGLInvoiceLines.DataSource = Me.GLInvoiceLineDataBindingSource
        Me.dgvGLInvoiceLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvGLInvoiceLines.Location = New System.Drawing.Point(349, 41)
        Me.dgvGLInvoiceLines.Name = "dgvGLInvoiceLines"
        Me.dgvGLInvoiceLines.Size = New System.Drawing.Size(781, 722)
        Me.dgvGLInvoiceLines.TabIndex = 18
        Me.dgvGLInvoiceLines.TabStop = False
        '
        'IVGLTransactionColumn
        '
        Me.IVGLTransactionColumn.DataPropertyName = "GLTransactionKey"
        Me.IVGLTransactionColumn.HeaderText = "Trans. #"
        Me.IVGLTransactionColumn.Name = "IVGLTransactionColumn"
        Me.IVGLTransactionColumn.Width = 85
        '
        'IVGLTransactionDateColumn
        '
        Me.IVGLTransactionDateColumn.DataPropertyName = "GLTransactionDate"
        Me.IVGLTransactionDateColumn.HeaderText = "Date"
        Me.IVGLTransactionDateColumn.Name = "IVGLTransactionDateColumn"
        Me.IVGLTransactionDateColumn.Width = 90
        '
        'IVGLAccountNumberColumn
        '
        Me.IVGLAccountNumberColumn.DataPropertyName = "GLAccountNumber"
        Me.IVGLAccountNumberColumn.HeaderText = "Account #"
        Me.IVGLAccountNumberColumn.Name = "IVGLAccountNumberColumn"
        Me.IVGLAccountNumberColumn.Width = 85
        '
        'IVGLTransactionDescriptionColumn
        '
        Me.IVGLTransactionDescriptionColumn.DataPropertyName = "GLTransactionDescription"
        Me.IVGLTransactionDescriptionColumn.HeaderText = "Description"
        Me.IVGLTransactionDescriptionColumn.Name = "IVGLTransactionDescriptionColumn"
        '
        'IVGLTransactionDebitAmountColumn
        '
        Me.IVGLTransactionDebitAmountColumn.DataPropertyName = "GLTransactionDebitAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.IVGLTransactionDebitAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.IVGLTransactionDebitAmountColumn.HeaderText = "Debit"
        Me.IVGLTransactionDebitAmountColumn.Name = "IVGLTransactionDebitAmountColumn"
        Me.IVGLTransactionDebitAmountColumn.Width = 90
        '
        'IVGLTransactionCreditAmountColumn
        '
        Me.IVGLTransactionCreditAmountColumn.DataPropertyName = "GLTransactionCreditAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.IVGLTransactionCreditAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.IVGLTransactionCreditAmountColumn.HeaderText = "Credit"
        Me.IVGLTransactionCreditAmountColumn.Name = "IVGLTransactionCreditAmountColumn"
        Me.IVGLTransactionCreditAmountColumn.Width = 90
        '
        'IVPartNumberColumn
        '
        Me.IVPartNumberColumn.DataPropertyName = "PartNumber"
        Me.IVPartNumberColumn.HeaderText = "Part Number"
        Me.IVPartNumberColumn.Name = "IVPartNumberColumn"
        '
        'IVPartDescriptionColumn
        '
        Me.IVPartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.IVPartDescriptionColumn.HeaderText = "Part Description"
        Me.IVPartDescriptionColumn.Name = "IVPartDescriptionColumn"
        '
        'QuantityBilledColumnIV
        '
        Me.QuantityBilledColumnIV.DataPropertyName = "QuantityBilled"
        DataGridViewCellStyle4.NullValue = "0"
        Me.QuantityBilledColumnIV.DefaultCellStyle = DataGridViewCellStyle4
        Me.QuantityBilledColumnIV.HeaderText = "Quantity Billed"
        Me.QuantityBilledColumnIV.Name = "QuantityBilledColumnIV"
        Me.QuantityBilledColumnIV.Width = 90
        '
        'IVPriceColumn
        '
        Me.IVPriceColumn.DataPropertyName = "Price"
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = "0"
        Me.IVPriceColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.IVPriceColumn.HeaderText = "Price"
        Me.IVPriceColumn.Name = "IVPriceColumn"
        Me.IVPriceColumn.Width = 90
        '
        'IVExtendedAmountColumn
        '
        Me.IVExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.IVExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.IVExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.IVExtendedAmountColumn.Name = "IVExtendedAmountColumn"
        Me.IVExtendedAmountColumn.Width = 90
        '
        'IVGLTransactionCommentColumn
        '
        Me.IVGLTransactionCommentColumn.DataPropertyName = "GLTransactionComment"
        Me.IVGLTransactionCommentColumn.HeaderText = "Comment"
        Me.IVGLTransactionCommentColumn.Name = "IVGLTransactionCommentColumn"
        '
        'IVGLReferenceNumberColumn
        '
        Me.IVGLReferenceNumberColumn.DataPropertyName = "GLReferenceNumber"
        Me.IVGLReferenceNumberColumn.HeaderText = "Invoice #"
        Me.IVGLReferenceNumberColumn.Name = "IVGLReferenceNumberColumn"
        Me.IVGLReferenceNumberColumn.Width = 90
        '
        'IVGLReferenceLineColumn
        '
        Me.IVGLReferenceLineColumn.DataPropertyName = "GLReferenceLine"
        Me.IVGLReferenceLineColumn.HeaderText = "Line #"
        Me.IVGLReferenceLineColumn.Name = "IVGLReferenceLineColumn"
        Me.IVGLReferenceLineColumn.Width = 90
        '
        'IVCustomerIDColumn
        '
        Me.IVCustomerIDColumn.DataPropertyName = "CustomerID"
        Me.IVCustomerIDColumn.HeaderText = "Customer ID"
        Me.IVCustomerIDColumn.Name = "IVCustomerIDColumn"
        '
        'IVInvoiceDateColumn
        '
        Me.IVInvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.IVInvoiceDateColumn.HeaderText = "Invoice Date"
        Me.IVInvoiceDateColumn.Name = "IVInvoiceDateColumn"
        Me.IVInvoiceDateColumn.Width = 90
        '
        'IVSalesOrderNumberColumn
        '
        Me.IVSalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.IVSalesOrderNumberColumn.HeaderText = "SO #"
        Me.IVSalesOrderNumberColumn.Name = "IVSalesOrderNumberColumn"
        Me.IVSalesOrderNumberColumn.Width = 90
        '
        'IVShipmentNumberColumn
        '
        Me.IVShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.IVShipmentNumberColumn.HeaderText = "Shipment #"
        Me.IVShipmentNumberColumn.Name = "IVShipmentNumberColumn"
        Me.IVShipmentNumberColumn.Width = 90
        '
        'IVGLTransactionStatusColumn
        '
        Me.IVGLTransactionStatusColumn.DataPropertyName = "GLTransactionStatus"
        Me.IVGLTransactionStatusColumn.HeaderText = "GLTransactionStatus"
        Me.IVGLTransactionStatusColumn.Name = "IVGLTransactionStatusColumn"
        Me.IVGLTransactionStatusColumn.Visible = False
        '
        'IVDivisionIDColumn
        '
        Me.IVDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.IVDivisionIDColumn.HeaderText = "DivisionID"
        Me.IVDivisionIDColumn.Name = "IVDivisionIDColumn"
        Me.IVDivisionIDColumn.Visible = False
        '
        'IVGLJournalIDColumn
        '
        Me.IVGLJournalIDColumn.DataPropertyName = "GLJournalID"
        Me.IVGLJournalIDColumn.HeaderText = "Journal ID"
        Me.IVGLJournalIDColumn.Name = "IVGLJournalIDColumn"
        Me.IVGLJournalIDColumn.Visible = False
        '
        'IVGLBatchNumberColumn
        '
        Me.IVGLBatchNumberColumn.DataPropertyName = "GLBatchNumber"
        Me.IVGLBatchNumberColumn.HeaderText = "Batch #"
        Me.IVGLBatchNumberColumn.Name = "IVGLBatchNumberColumn"
        Me.IVGLBatchNumberColumn.Width = 90
        '
        'GLInvoiceLineDataBindingSource
        '
        Me.GLInvoiceLineDataBindingSource.DataMember = "GLInvoiceLineData"
        Me.GLInvoiceLineDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLInvoiceLineDataTableAdapter
        '
        Me.GLInvoiceLineDataTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 21
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrintReport
        '
        Me.cmdPrintReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintReport.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrintReport.Name = "cmdPrintReport"
        Me.cmdPrintReport.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintReport.TabIndex = 20
        Me.cmdPrintReport.Text = "Print Listing"
        Me.cmdPrintReport.UseVisualStyleBackColor = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoShipment)
        Me.GroupBox1.Controls.Add(Me.rdoReceiver)
        Me.GroupBox1.Controls.Add(Me.rdoWCProduction)
        Me.GroupBox1.Controls.Add(Me.rdoInvoice)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 184)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Division / GL Posting Type"
        '
        'rdoShipment
        '
        Me.rdoShipment.AutoSize = True
        Me.rdoShipment.Location = New System.Drawing.Point(20, 119)
        Me.rdoShipment.Name = "rdoShipment"
        Me.rdoShipment.Size = New System.Drawing.Size(138, 17)
        Me.rdoShipment.TabIndex = 7
        Me.rdoShipment.TabStop = True
        Me.rdoShipment.Text = "View Shipment Postings"
        Me.rdoShipment.UseVisualStyleBackColor = True
        '
        'rdoReceiver
        '
        Me.rdoReceiver.AutoSize = True
        Me.rdoReceiver.Location = New System.Drawing.Point(20, 96)
        Me.rdoReceiver.Name = "rdoReceiver"
        Me.rdoReceiver.Size = New System.Drawing.Size(137, 17)
        Me.rdoReceiver.TabIndex = 6
        Me.rdoReceiver.TabStop = True
        Me.rdoReceiver.Text = "View Receiver Postings"
        Me.rdoReceiver.UseVisualStyleBackColor = True
        '
        'rdoWCProduction
        '
        Me.rdoWCProduction.AutoSize = True
        Me.rdoWCProduction.Location = New System.Drawing.Point(20, 142)
        Me.rdoWCProduction.Name = "rdoWCProduction"
        Me.rdoWCProduction.Size = New System.Drawing.Size(166, 17)
        Me.rdoWCProduction.TabIndex = 5
        Me.rdoWCProduction.TabStop = True
        Me.rdoWCProduction.Text = "View WC Production Postings"
        Me.rdoWCProduction.UseVisualStyleBackColor = True
        '
        'rdoInvoice
        '
        Me.rdoInvoice.AutoSize = True
        Me.rdoInvoice.Checked = True
        Me.rdoInvoice.Location = New System.Drawing.Point(20, 74)
        Me.rdoInvoice.Name = "rdoInvoice"
        Me.rdoInvoice.Size = New System.Drawing.Size(129, 17)
        Me.rdoInvoice.TabIndex = 4
        Me.rdoInvoice.TabStop = True
        Me.rdoInvoice.Text = "View Invoice Postings"
        Me.rdoInvoice.UseVisualStyleBackColor = True
        '
        'dgvReceivingLines
        '
        Me.dgvReceivingLines.AllowUserToAddRows = False
        Me.dgvReceivingLines.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvReceivingLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvReceivingLines.AutoGenerateColumns = False
        Me.dgvReceivingLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReceivingLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvReceivingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceivingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RCGLTransactionKeyColumn, Me.RCGLTransactionDateColumn, Me.RCGLAccountNumberColumn, Me.RCGLTransactionDescriptionColumn, Me.RCGLTransactionDebitAmountColumn, Me.RCGLTransactionCreditAmountColumn, Me.RCGLTransactionCommentColumn, Me.RCGLJournalIDColumn, Me.RCGLBatchNumberColumn, Me.RCGLReferenceNumberColumn, Me.RCGLReferenceLineColumn, Me.RCPartNumberColumn, Me.RCPartDescriptionColumn, Me.RCQuantityReceivedColumn, Me.RCUnitCostColumn, Me.RCExtendedAmountColumn, Me.RCPONumberColumn, Me.RCVendorCodeColumn, Me.RCGLTransactionStatusColumn, Me.RCDivisionIDColumn})
        Me.dgvReceivingLines.DataSource = Me.GLReceivingLineDataBindingSource
        Me.dgvReceivingLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvReceivingLines.Location = New System.Drawing.Point(349, 41)
        Me.dgvReceivingLines.Name = "dgvReceivingLines"
        Me.dgvReceivingLines.ReadOnly = True
        Me.dgvReceivingLines.Size = New System.Drawing.Size(681, 624)
        Me.dgvReceivingLines.TabIndex = 23
        '
        'RCGLTransactionKeyColumn
        '
        Me.RCGLTransactionKeyColumn.DataPropertyName = "GLTransactionKey"
        Me.RCGLTransactionKeyColumn.HeaderText = "Trans. #"
        Me.RCGLTransactionKeyColumn.Name = "RCGLTransactionKeyColumn"
        Me.RCGLTransactionKeyColumn.ReadOnly = True
        '
        'RCGLTransactionDateColumn
        '
        Me.RCGLTransactionDateColumn.DataPropertyName = "GLTransactionDate"
        Me.RCGLTransactionDateColumn.HeaderText = "Date"
        Me.RCGLTransactionDateColumn.Name = "RCGLTransactionDateColumn"
        Me.RCGLTransactionDateColumn.ReadOnly = True
        '
        'RCGLAccountNumberColumn
        '
        Me.RCGLAccountNumberColumn.DataPropertyName = "GLAccountNumber"
        Me.RCGLAccountNumberColumn.HeaderText = "GL Account"
        Me.RCGLAccountNumberColumn.Name = "RCGLAccountNumberColumn"
        Me.RCGLAccountNumberColumn.ReadOnly = True
        '
        'RCGLTransactionDescriptionColumn
        '
        Me.RCGLTransactionDescriptionColumn.DataPropertyName = "GLTransactionDescription"
        Me.RCGLTransactionDescriptionColumn.HeaderText = "Trans. Description"
        Me.RCGLTransactionDescriptionColumn.Name = "RCGLTransactionDescriptionColumn"
        Me.RCGLTransactionDescriptionColumn.ReadOnly = True
        '
        'RCGLTransactionDebitAmountColumn
        '
        Me.RCGLTransactionDebitAmountColumn.DataPropertyName = "GLTransactionDebitAmount"
        Me.RCGLTransactionDebitAmountColumn.HeaderText = "Debit"
        Me.RCGLTransactionDebitAmountColumn.Name = "RCGLTransactionDebitAmountColumn"
        Me.RCGLTransactionDebitAmountColumn.ReadOnly = True
        '
        'RCGLTransactionCreditAmountColumn
        '
        Me.RCGLTransactionCreditAmountColumn.DataPropertyName = "GLTransactionCreditAmount"
        Me.RCGLTransactionCreditAmountColumn.HeaderText = "Credit"
        Me.RCGLTransactionCreditAmountColumn.Name = "RCGLTransactionCreditAmountColumn"
        Me.RCGLTransactionCreditAmountColumn.ReadOnly = True
        '
        'RCGLTransactionCommentColumn
        '
        Me.RCGLTransactionCommentColumn.DataPropertyName = "GLTransactionComment"
        Me.RCGLTransactionCommentColumn.HeaderText = "Comment"
        Me.RCGLTransactionCommentColumn.Name = "RCGLTransactionCommentColumn"
        Me.RCGLTransactionCommentColumn.ReadOnly = True
        '
        'RCGLJournalIDColumn
        '
        Me.RCGLJournalIDColumn.DataPropertyName = "GLJournalID"
        Me.RCGLJournalIDColumn.HeaderText = "Journal"
        Me.RCGLJournalIDColumn.Name = "RCGLJournalIDColumn"
        Me.RCGLJournalIDColumn.ReadOnly = True
        '
        'RCGLBatchNumberColumn
        '
        Me.RCGLBatchNumberColumn.DataPropertyName = "GLBatchNumber"
        Me.RCGLBatchNumberColumn.HeaderText = "Batch #"
        Me.RCGLBatchNumberColumn.Name = "RCGLBatchNumberColumn"
        Me.RCGLBatchNumberColumn.ReadOnly = True
        '
        'RCGLReferenceNumberColumn
        '
        Me.RCGLReferenceNumberColumn.DataPropertyName = "GLReferenceNumber"
        Me.RCGLReferenceNumberColumn.HeaderText = "Reciever #"
        Me.RCGLReferenceNumberColumn.Name = "RCGLReferenceNumberColumn"
        Me.RCGLReferenceNumberColumn.ReadOnly = True
        '
        'RCGLReferenceLineColumn
        '
        Me.RCGLReferenceLineColumn.DataPropertyName = "GLReferenceLine"
        Me.RCGLReferenceLineColumn.HeaderText = "Receiver Line"
        Me.RCGLReferenceLineColumn.Name = "RCGLReferenceLineColumn"
        Me.RCGLReferenceLineColumn.ReadOnly = True
        '
        'RCPartNumberColumn
        '
        Me.RCPartNumberColumn.DataPropertyName = "PartNumber"
        Me.RCPartNumberColumn.HeaderText = "Part Number"
        Me.RCPartNumberColumn.Name = "RCPartNumberColumn"
        Me.RCPartNumberColumn.ReadOnly = True
        '
        'RCPartDescriptionColumn
        '
        Me.RCPartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.RCPartDescriptionColumn.HeaderText = "Part Description"
        Me.RCPartDescriptionColumn.Name = "RCPartDescriptionColumn"
        Me.RCPartDescriptionColumn.ReadOnly = True
        '
        'RCQuantityReceivedColumn
        '
        Me.RCQuantityReceivedColumn.DataPropertyName = "QuantityReceived"
        Me.RCQuantityReceivedColumn.HeaderText = "Quantity Received"
        Me.RCQuantityReceivedColumn.Name = "RCQuantityReceivedColumn"
        Me.RCQuantityReceivedColumn.ReadOnly = True
        '
        'RCUnitCostColumn
        '
        Me.RCUnitCostColumn.DataPropertyName = "UnitCost"
        Me.RCUnitCostColumn.HeaderText = "Unit Cost"
        Me.RCUnitCostColumn.Name = "RCUnitCostColumn"
        Me.RCUnitCostColumn.ReadOnly = True
        '
        'RCExtendedAmountColumn
        '
        Me.RCExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.RCExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.RCExtendedAmountColumn.Name = "RCExtendedAmountColumn"
        Me.RCExtendedAmountColumn.ReadOnly = True
        '
        'RCPONumberColumn
        '
        Me.RCPONumberColumn.DataPropertyName = "PONumber"
        Me.RCPONumberColumn.HeaderText = "PO Number"
        Me.RCPONumberColumn.Name = "RCPONumberColumn"
        Me.RCPONumberColumn.ReadOnly = True
        '
        'RCVendorCodeColumn
        '
        Me.RCVendorCodeColumn.DataPropertyName = "VendorCode"
        Me.RCVendorCodeColumn.HeaderText = "Vendor"
        Me.RCVendorCodeColumn.Name = "RCVendorCodeColumn"
        Me.RCVendorCodeColumn.ReadOnly = True
        '
        'RCGLTransactionStatusColumn
        '
        Me.RCGLTransactionStatusColumn.DataPropertyName = "GLTransactionStatus"
        Me.RCGLTransactionStatusColumn.HeaderText = "GLTransactionStatus"
        Me.RCGLTransactionStatusColumn.Name = "RCGLTransactionStatusColumn"
        Me.RCGLTransactionStatusColumn.ReadOnly = True
        Me.RCGLTransactionStatusColumn.Visible = False
        '
        'RCDivisionIDColumn
        '
        Me.RCDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.RCDivisionIDColumn.HeaderText = "DivisionID"
        Me.RCDivisionIDColumn.Name = "RCDivisionIDColumn"
        Me.RCDivisionIDColumn.ReadOnly = True
        Me.RCDivisionIDColumn.Visible = False
        '
        'GLReceivingLineDataBindingSource
        '
        Me.GLReceivingLineDataBindingSource.DataMember = "GLReceivingLineData"
        Me.GLReceivingLineDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLReceivingLineDataTableAdapter
        '
        Me.GLReceivingLineDataTableAdapter.ClearBeforeFill = True
        '
        'dgvShipmentLines
        '
        Me.dgvShipmentLines.AllowUserToAddRows = False
        Me.dgvShipmentLines.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvShipmentLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvShipmentLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipmentLines.AutoGenerateColumns = False
        Me.dgvShipmentLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SHGLTransactionKeyColumn, Me.SHGLTransactionDateColumn, Me.SHGLAccountNumberColumn, Me.SHGLTransactionDescriptionColumn, Me.SHGLTransactionDebitAmountColumn, Me.SHGLTransactionCreditAmountColumn, Me.SHGLTransactionCommentColumn, Me.SHGLReferenceNumberColumn, Me.SHGLReferenceLineColumn, Me.SHPartNumberColumn, Me.SHPartDescriptionColumn, Me.SHQuantityShippedColumn, Me.SHPriceColumn, Me.SHExtendedAmountColumn, Me.SHCustomerIDColumn, Me.SHGLBatchNumberColumn, Me.SHGLJournalIDColumn, Me.SHGLTransactionStatusColumn, Me.SHDivisionIDColumn})
        Me.dgvShipmentLines.DataSource = Me.GLShipmentLineDataBindingSource
        Me.dgvShipmentLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipmentLines.Location = New System.Drawing.Point(349, 41)
        Me.dgvShipmentLines.Name = "dgvShipmentLines"
        Me.dgvShipmentLines.ReadOnly = True
        Me.dgvShipmentLines.Size = New System.Drawing.Size(781, 724)
        Me.dgvShipmentLines.TabIndex = 24
        '
        'SHGLTransactionKeyColumn
        '
        Me.SHGLTransactionKeyColumn.DataPropertyName = "GLTransactionKey"
        Me.SHGLTransactionKeyColumn.HeaderText = "Trans. #"
        Me.SHGLTransactionKeyColumn.Name = "SHGLTransactionKeyColumn"
        Me.SHGLTransactionKeyColumn.ReadOnly = True
        '
        'SHGLTransactionDateColumn
        '
        Me.SHGLTransactionDateColumn.DataPropertyName = "GLTransactionDate"
        Me.SHGLTransactionDateColumn.HeaderText = "Date"
        Me.SHGLTransactionDateColumn.Name = "SHGLTransactionDateColumn"
        Me.SHGLTransactionDateColumn.ReadOnly = True
        '
        'SHGLAccountNumberColumn
        '
        Me.SHGLAccountNumberColumn.DataPropertyName = "GLAccountNumber"
        Me.SHGLAccountNumberColumn.HeaderText = "GL Account"
        Me.SHGLAccountNumberColumn.Name = "SHGLAccountNumberColumn"
        Me.SHGLAccountNumberColumn.ReadOnly = True
        '
        'SHGLTransactionDescriptionColumn
        '
        Me.SHGLTransactionDescriptionColumn.DataPropertyName = "GLTransactionDescription"
        Me.SHGLTransactionDescriptionColumn.HeaderText = "Description"
        Me.SHGLTransactionDescriptionColumn.Name = "SHGLTransactionDescriptionColumn"
        Me.SHGLTransactionDescriptionColumn.ReadOnly = True
        '
        'SHGLTransactionDebitAmountColumn
        '
        Me.SHGLTransactionDebitAmountColumn.DataPropertyName = "GLTransactionDebitAmount"
        Me.SHGLTransactionDebitAmountColumn.HeaderText = "Debit"
        Me.SHGLTransactionDebitAmountColumn.Name = "SHGLTransactionDebitAmountColumn"
        Me.SHGLTransactionDebitAmountColumn.ReadOnly = True
        '
        'SHGLTransactionCreditAmountColumn
        '
        Me.SHGLTransactionCreditAmountColumn.DataPropertyName = "GLTransactionCreditAmount"
        Me.SHGLTransactionCreditAmountColumn.HeaderText = "Credit"
        Me.SHGLTransactionCreditAmountColumn.Name = "SHGLTransactionCreditAmountColumn"
        Me.SHGLTransactionCreditAmountColumn.ReadOnly = True
        '
        'SHGLTransactionCommentColumn
        '
        Me.SHGLTransactionCommentColumn.DataPropertyName = "GLTransactionComment"
        Me.SHGLTransactionCommentColumn.HeaderText = "Comment"
        Me.SHGLTransactionCommentColumn.Name = "SHGLTransactionCommentColumn"
        Me.SHGLTransactionCommentColumn.ReadOnly = True
        '
        'SHGLReferenceNumberColumn
        '
        Me.SHGLReferenceNumberColumn.DataPropertyName = "GLReferenceNumber"
        Me.SHGLReferenceNumberColumn.HeaderText = "Ship. #"
        Me.SHGLReferenceNumberColumn.Name = "SHGLReferenceNumberColumn"
        Me.SHGLReferenceNumberColumn.ReadOnly = True
        '
        'SHGLReferenceLineColumn
        '
        Me.SHGLReferenceLineColumn.DataPropertyName = "GLReferenceLine"
        Me.SHGLReferenceLineColumn.HeaderText = "Line #"
        Me.SHGLReferenceLineColumn.Name = "SHGLReferenceLineColumn"
        Me.SHGLReferenceLineColumn.ReadOnly = True
        '
        'SHPartNumberColumn
        '
        Me.SHPartNumberColumn.DataPropertyName = "PartNumber"
        Me.SHPartNumberColumn.HeaderText = "Part Number"
        Me.SHPartNumberColumn.Name = "SHPartNumberColumn"
        Me.SHPartNumberColumn.ReadOnly = True
        '
        'SHPartDescriptionColumn
        '
        Me.SHPartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.SHPartDescriptionColumn.HeaderText = "Description"
        Me.SHPartDescriptionColumn.Name = "SHPartDescriptionColumn"
        Me.SHPartDescriptionColumn.ReadOnly = True
        '
        'SHQuantityShippedColumn
        '
        Me.SHQuantityShippedColumn.DataPropertyName = "QuantityShipped"
        Me.SHQuantityShippedColumn.HeaderText = "Quantity Shipped"
        Me.SHQuantityShippedColumn.Name = "SHQuantityShippedColumn"
        Me.SHQuantityShippedColumn.ReadOnly = True
        '
        'SHPriceColumn
        '
        Me.SHPriceColumn.DataPropertyName = "Price"
        Me.SHPriceColumn.HeaderText = "Price"
        Me.SHPriceColumn.Name = "SHPriceColumn"
        Me.SHPriceColumn.ReadOnly = True
        '
        'SHExtendedAmountColumn
        '
        Me.SHExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.SHExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.SHExtendedAmountColumn.Name = "SHExtendedAmountColumn"
        Me.SHExtendedAmountColumn.ReadOnly = True
        '
        'SHCustomerIDColumn
        '
        Me.SHCustomerIDColumn.DataPropertyName = "CustomerID"
        Me.SHCustomerIDColumn.HeaderText = "Customer"
        Me.SHCustomerIDColumn.Name = "SHCustomerIDColumn"
        Me.SHCustomerIDColumn.ReadOnly = True
        '
        'SHGLBatchNumberColumn
        '
        Me.SHGLBatchNumberColumn.DataPropertyName = "GLBatchNumber"
        Me.SHGLBatchNumberColumn.HeaderText = "Batch #"
        Me.SHGLBatchNumberColumn.Name = "SHGLBatchNumberColumn"
        Me.SHGLBatchNumberColumn.ReadOnly = True
        '
        'SHGLJournalIDColumn
        '
        Me.SHGLJournalIDColumn.DataPropertyName = "GLJournalID"
        Me.SHGLJournalIDColumn.HeaderText = "Journal"
        Me.SHGLJournalIDColumn.Name = "SHGLJournalIDColumn"
        Me.SHGLJournalIDColumn.ReadOnly = True
        '
        'SHGLTransactionStatusColumn
        '
        Me.SHGLTransactionStatusColumn.DataPropertyName = "GLTransactionStatus"
        Me.SHGLTransactionStatusColumn.HeaderText = "GLTransactionStatus"
        Me.SHGLTransactionStatusColumn.Name = "SHGLTransactionStatusColumn"
        Me.SHGLTransactionStatusColumn.ReadOnly = True
        Me.SHGLTransactionStatusColumn.Visible = False
        '
        'SHDivisionIDColumn
        '
        Me.SHDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.SHDivisionIDColumn.HeaderText = "DivisionID"
        Me.SHDivisionIDColumn.Name = "SHDivisionIDColumn"
        Me.SHDivisionIDColumn.ReadOnly = True
        Me.SHDivisionIDColumn.Visible = False
        '
        'GLShipmentLineDataBindingSource
        '
        Me.GLShipmentLineDataBindingSource.DataMember = "GLShipmentLineData"
        Me.GLShipmentLineDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLShipmentLineDataTableAdapter
        '
        Me.GLShipmentLineDataTableAdapter.ClearBeforeFill = True
        '
        'dgvWCLines
        '
        Me.dgvWCLines.AllowUserToAddRows = False
        Me.dgvWCLines.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvWCLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvWCLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvWCLines.AutoGenerateColumns = False
        Me.dgvWCLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvWCLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvWCLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWCLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WCGLTransactionKeyColumn, Me.WCGLTransactionDateColumn, Me.WCGLAccountNumberColumn, Me.WCGLTransactionDescriptionColumn, Me.WCGLTransactionDebitAmountColumn, Me.WCGLTransactionCreditAmountColumn, Me.WCGLReferenceNumberColumn, Me.WCGLReferenceLineColumn, Me.WCPartNumberColumn, Me.WCPartDescriptionColumn, Me.WCProductionQuantityColumn, Me.WCUnitCostColumn, Me.WCExtendedCostColumn, Me.WCGLTransactionCommentColumn, Me.WCGLJournalIDColumn, Me.WCGLBatchNumberColumn, Me.WCDivisionIDColumn, Me.WCGLTransactionStatusColumn})
        Me.dgvWCLines.DataSource = Me.GLWCProductionLineDataBindingSource
        Me.dgvWCLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvWCLines.Location = New System.Drawing.Point(349, 41)
        Me.dgvWCLines.Name = "dgvWCLines"
        Me.dgvWCLines.ReadOnly = True
        Me.dgvWCLines.Size = New System.Drawing.Size(781, 724)
        Me.dgvWCLines.TabIndex = 25
        '
        'WCGLTransactionKeyColumn
        '
        Me.WCGLTransactionKeyColumn.DataPropertyName = "GLTransactionKey"
        Me.WCGLTransactionKeyColumn.HeaderText = "Trans. #"
        Me.WCGLTransactionKeyColumn.Name = "WCGLTransactionKeyColumn"
        Me.WCGLTransactionKeyColumn.ReadOnly = True
        '
        'WCGLTransactionDateColumn
        '
        Me.WCGLTransactionDateColumn.DataPropertyName = "GLTransactionDate"
        Me.WCGLTransactionDateColumn.HeaderText = "Date"
        Me.WCGLTransactionDateColumn.Name = "WCGLTransactionDateColumn"
        Me.WCGLTransactionDateColumn.ReadOnly = True
        '
        'WCGLAccountNumberColumn
        '
        Me.WCGLAccountNumberColumn.DataPropertyName = "GLAccountNumber"
        Me.WCGLAccountNumberColumn.HeaderText = "GL Account"
        Me.WCGLAccountNumberColumn.Name = "WCGLAccountNumberColumn"
        Me.WCGLAccountNumberColumn.ReadOnly = True
        '
        'WCGLTransactionDescriptionColumn
        '
        Me.WCGLTransactionDescriptionColumn.DataPropertyName = "GLTransactionDescription"
        Me.WCGLTransactionDescriptionColumn.HeaderText = "Description"
        Me.WCGLTransactionDescriptionColumn.Name = "WCGLTransactionDescriptionColumn"
        Me.WCGLTransactionDescriptionColumn.ReadOnly = True
        '
        'WCGLTransactionDebitAmountColumn
        '
        Me.WCGLTransactionDebitAmountColumn.DataPropertyName = "GLTransactionDebitAmount"
        Me.WCGLTransactionDebitAmountColumn.HeaderText = "Debit"
        Me.WCGLTransactionDebitAmountColumn.Name = "WCGLTransactionDebitAmountColumn"
        Me.WCGLTransactionDebitAmountColumn.ReadOnly = True
        '
        'WCGLTransactionCreditAmountColumn
        '
        Me.WCGLTransactionCreditAmountColumn.DataPropertyName = "GLTransactionCreditAmount"
        Me.WCGLTransactionCreditAmountColumn.HeaderText = "Credit"
        Me.WCGLTransactionCreditAmountColumn.Name = "WCGLTransactionCreditAmountColumn"
        Me.WCGLTransactionCreditAmountColumn.ReadOnly = True
        '
        'WCGLReferenceNumberColumn
        '
        Me.WCGLReferenceNumberColumn.DataPropertyName = "GLReferenceNumber"
        Me.WCGLReferenceNumberColumn.HeaderText = "Production #"
        Me.WCGLReferenceNumberColumn.Name = "WCGLReferenceNumberColumn"
        Me.WCGLReferenceNumberColumn.ReadOnly = True
        '
        'WCGLReferenceLineColumn
        '
        Me.WCGLReferenceLineColumn.DataPropertyName = "GLReferenceLine"
        Me.WCGLReferenceLineColumn.HeaderText = "Line #"
        Me.WCGLReferenceLineColumn.Name = "WCGLReferenceLineColumn"
        Me.WCGLReferenceLineColumn.ReadOnly = True
        '
        'WCPartNumberColumn
        '
        Me.WCPartNumberColumn.DataPropertyName = "PartNumber"
        Me.WCPartNumberColumn.HeaderText = "Part Number"
        Me.WCPartNumberColumn.Name = "WCPartNumberColumn"
        Me.WCPartNumberColumn.ReadOnly = True
        '
        'WCPartDescriptionColumn
        '
        Me.WCPartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.WCPartDescriptionColumn.HeaderText = "Part Description"
        Me.WCPartDescriptionColumn.Name = "WCPartDescriptionColumn"
        Me.WCPartDescriptionColumn.ReadOnly = True
        '
        'WCProductionQuantityColumn
        '
        Me.WCProductionQuantityColumn.DataPropertyName = "ProductionQuantity"
        Me.WCProductionQuantityColumn.HeaderText = "Production Quantity"
        Me.WCProductionQuantityColumn.Name = "WCProductionQuantityColumn"
        Me.WCProductionQuantityColumn.ReadOnly = True
        '
        'WCUnitCostColumn
        '
        Me.WCUnitCostColumn.DataPropertyName = "UnitCost"
        Me.WCUnitCostColumn.HeaderText = "Unit Cost"
        Me.WCUnitCostColumn.Name = "WCUnitCostColumn"
        Me.WCUnitCostColumn.ReadOnly = True
        '
        'WCExtendedCostColumn
        '
        Me.WCExtendedCostColumn.DataPropertyName = "ExtendedCost"
        Me.WCExtendedCostColumn.HeaderText = "Extended Cost"
        Me.WCExtendedCostColumn.Name = "WCExtendedCostColumn"
        Me.WCExtendedCostColumn.ReadOnly = True
        '
        'WCGLTransactionCommentColumn
        '
        Me.WCGLTransactionCommentColumn.DataPropertyName = "GLTransactionComment"
        Me.WCGLTransactionCommentColumn.HeaderText = "Comment"
        Me.WCGLTransactionCommentColumn.Name = "WCGLTransactionCommentColumn"
        Me.WCGLTransactionCommentColumn.ReadOnly = True
        '
        'WCGLJournalIDColumn
        '
        Me.WCGLJournalIDColumn.DataPropertyName = "GLJournalID"
        Me.WCGLJournalIDColumn.HeaderText = "Journal"
        Me.WCGLJournalIDColumn.Name = "WCGLJournalIDColumn"
        Me.WCGLJournalIDColumn.ReadOnly = True
        '
        'WCGLBatchNumberColumn
        '
        Me.WCGLBatchNumberColumn.DataPropertyName = "GLBatchNumber"
        Me.WCGLBatchNumberColumn.HeaderText = "Batch #"
        Me.WCGLBatchNumberColumn.Name = "WCGLBatchNumberColumn"
        Me.WCGLBatchNumberColumn.ReadOnly = True
        '
        'WCDivisionIDColumn
        '
        Me.WCDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.WCDivisionIDColumn.HeaderText = "DivisionID"
        Me.WCDivisionIDColumn.Name = "WCDivisionIDColumn"
        Me.WCDivisionIDColumn.ReadOnly = True
        Me.WCDivisionIDColumn.Visible = False
        '
        'WCGLTransactionStatusColumn
        '
        Me.WCGLTransactionStatusColumn.DataPropertyName = "GLTransactionStatus"
        Me.WCGLTransactionStatusColumn.HeaderText = "GLTransactionStatus"
        Me.WCGLTransactionStatusColumn.Name = "WCGLTransactionStatusColumn"
        Me.WCGLTransactionStatusColumn.ReadOnly = True
        Me.WCGLTransactionStatusColumn.Visible = False
        '
        'GLWCProductionLineDataBindingSource
        '
        Me.GLWCProductionLineDataBindingSource.DataMember = "GLWCProductionLineData"
        Me.GLWCProductionLineDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLWCProductionLineDataTableAdapter
        '
        Me.GLWCProductionLineDataTableAdapter.ClearBeforeFill = True
        '
        'ViewGLLinePostings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvWCLines)
        Me.Controls.Add(Me.dgvShipmentLines)
        Me.Controls.Add(Me.dgvReceivingLines)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrintReport)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvGLInvoiceLines)
        Me.Controls.Add(Me.gpxInvoiceFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewGLLinePostings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation GL Line Postings"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxInvoiceFilter.ResumeLayout(False)
        Me.gpxInvoiceFilter.PerformLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGLInvoiceLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLInvoiceLineDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvReceivingLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLReceivingLineDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShipmentLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLShipmentLineDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWCLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLWCProductionLineDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxInvoiceFilter As System.Windows.Forms.GroupBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents dgvGLInvoiceLines As System.Windows.Forms.DataGridView
    Friend WithEvents GLInvoiceLineDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLInvoiceLineDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLInvoiceLineDataTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrintReport As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboAccountDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboAccountNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoShipment As System.Windows.Forms.RadioButton
    Friend WithEvents rdoReceiver As System.Windows.Forms.RadioButton
    Friend WithEvents rdoWCProduction As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInvoice As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents IVGLTransactionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVGLTransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVGLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVGLTransactionDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVGLTransactionDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVGLTransactionCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVPartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityBilledColumnIV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVGLTransactionCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVGLReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVGLReferenceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVCustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVInvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVSalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVGLTransactionStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVGLJournalIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVGLBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvReceivingLines As System.Windows.Forms.DataGridView
    Friend WithEvents GLReceivingLineDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLReceivingLineDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLReceivingLineDataTableAdapter
    Friend WithEvents dgvShipmentLines As System.Windows.Forms.DataGridView
    Friend WithEvents GLShipmentLineDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLShipmentLineDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLShipmentLineDataTableAdapter
    Friend WithEvents dgvWCLines As System.Windows.Forms.DataGridView
    Friend WithEvents RCGLTransactionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCGLTransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCGLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCGLTransactionDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCGLTransactionDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCGLTransactionCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCGLTransactionCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCGLJournalIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCGLBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCGLReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCGLReferenceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCPartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCQuantityReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCUnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCVendorCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCGLTransactionStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RCDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLTransactionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLTransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLTransactionDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLTransactionDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLTransactionCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLTransactionCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLReferenceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHPartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHQuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHCustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLJournalIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHGLTransactionStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLWCProductionLineDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLWCProductionLineDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLWCProductionLineDataTableAdapter
    Friend WithEvents WCGLTransactionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCGLTransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCGLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCGLTransactionDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCGLTransactionDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCGLTransactionCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCGLReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCGLReferenceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCPartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCProductionQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCUnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCGLTransactionCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCGLJournalIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCGLBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCGLTransactionStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
