<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewVoucherLines
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
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxAPVoucherData = New System.Windows.Forms.GroupBox
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.cboVoucherNumber = New System.Windows.Forms.ComboBox
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.rdoReceiptDate = New System.Windows.Forms.RadioButton
        Me.rdoInvoiceDate = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ReceiptOfInvoiceVoucherLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClear1 = New System.Windows.Forms.Button
        Me.cboReceiverNumber = New System.Windows.Forms.ComboBox
        Me.ReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.dgvROIVoucherLines = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherLineDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverLineDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherSourceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptOfInvoiceVoucherLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLineQueryTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.ReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAPVoucherData.SuspendLayout()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceVoucherLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvROIVoucherLines, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxAPVoucherData
        '
        Me.gpxAPVoucherData.Controls.Add(Me.txtTextFilter)
        Me.gpxAPVoucherData.Controls.Add(Me.cboVoucherNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label9)
        Me.gpxAPVoucherData.Controls.Add(Me.Label8)
        Me.gpxAPVoucherData.Controls.Add(Me.rdoReceiptDate)
        Me.gpxAPVoucherData.Controls.Add(Me.rdoInvoiceDate)
        Me.gpxAPVoucherData.Controls.Add(Me.Label14)
        Me.gpxAPVoucherData.Controls.Add(Me.chkDateRange)
        Me.gpxAPVoucherData.Controls.Add(Me.Label12)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPONumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label2)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPartDescription)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdClear1)
        Me.gpxAPVoucherData.Controls.Add(Me.cboReceiverNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPartNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpEndDate)
        Me.gpxAPVoucherData.Controls.Add(Me.txtVendorName)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPVoucherData.Controls.Add(Me.Label4)
        Me.gpxAPVoucherData.Controls.Add(Me.Label6)
        Me.gpxAPVoucherData.Controls.Add(Me.Label5)
        Me.gpxAPVoucherData.Controls.Add(Me.cboVendorID)
        Me.gpxAPVoucherData.Controls.Add(Me.Label7)
        Me.gpxAPVoucherData.Controls.Add(Me.cboDivisionID)
        Me.gpxAPVoucherData.Controls.Add(Me.Label3)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdViewByFilters)
        Me.gpxAPVoucherData.Controls.Add(Me.Label1)
        Me.gpxAPVoucherData.Controls.Add(Me.Label10)
        Me.gpxAPVoucherData.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPVoucherData.Name = "gpxAPVoucherData"
        Me.gpxAPVoucherData.Size = New System.Drawing.Size(300, 770)
        Me.gpxAPVoucherData.TabIndex = 0
        Me.gpxAPVoucherData.TabStop = False
        Me.gpxAPVoucherData.Text = "View By Filters"
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(105, 478)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(181, 20)
        Me.txtTextFilter.TabIndex = 8
        '
        'cboVoucherNumber
        '
        Me.cboVoucherNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVoucherNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVoucherNumber.DataSource = Me.ReceiptOfInvoiceBatchLineBindingSource
        Me.cboVoucherNumber.DisplayMember = "VoucherNumber"
        Me.cboVoucherNumber.FormattingEnabled = True
        Me.cboVoucherNumber.Location = New System.Drawing.Point(105, 368)
        Me.cboVoucherNumber.Name = "cboVoucherNumber"
        Me.cboVoucherNumber.Size = New System.Drawing.Size(181, 21)
        Me.cboVoucherNumber.TabIndex = 6
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
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(21, 369)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 20)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Voucher #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(109, 659)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 45)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Select date to filter list by."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoReceiptDate
        '
        Me.rdoReceiptDate.AutoSize = True
        Me.rdoReceiptDate.Location = New System.Drawing.Point(15, 687)
        Me.rdoReceiptDate.Name = "rdoReceiptDate"
        Me.rdoReceiptDate.Size = New System.Drawing.Size(88, 17)
        Me.rdoReceiptDate.TabIndex = 13
        Me.rdoReceiptDate.TabStop = True
        Me.rdoReceiptDate.Text = "Receipt Date"
        Me.rdoReceiptDate.UseVisualStyleBackColor = True
        '
        'rdoInvoiceDate
        '
        Me.rdoInvoiceDate.AutoSize = True
        Me.rdoInvoiceDate.Checked = True
        Me.rdoInvoiceDate.Location = New System.Drawing.Point(15, 659)
        Me.rdoInvoiceDate.Name = "rdoInvoiceDate"
        Me.rdoInvoiceDate.Size = New System.Drawing.Size(86, 17)
        Me.rdoInvoiceDate.TabIndex = 12
        Me.rdoInvoiceDate.TabStop = True
        Me.rdoInvoiceDate.Text = "Invoice Date"
        Me.rdoInvoiceDate.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(18, 522)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(102, 558)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 9
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(24, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 40)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPONumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(105, 313)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(181, 21)
        Me.cboPONumber.TabIndex = 5
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 314)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "PO Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ReceiptOfInvoiceVoucherLineQueryBindingSource
        Me.cboPartDescription.DisplayMember = "PartDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(21, 259)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboPartDescription.TabIndex = 4
        '
        'ReceiptOfInvoiceVoucherLineQueryBindingSource
        '
        Me.ReceiptOfInvoiceVoucherLineQueryBindingSource.DataMember = "ReceiptOfInvoiceVoucherLineQuery"
        Me.ReceiptOfInvoiceVoucherLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClear1
        '
        Me.cmdClear1.Location = New System.Drawing.Point(211, 725)
        Me.cmdClear1.Name = "cmdClear1"
        Me.cmdClear1.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear1.TabIndex = 15
        Me.cmdClear1.Text = "Clear"
        Me.cmdClear1.UseVisualStyleBackColor = True
        '
        'cboReceiverNumber
        '
        Me.cboReceiverNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReceiverNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReceiverNumber.DataSource = Me.ReceivingHeaderTableBindingSource
        Me.cboReceiverNumber.DisplayMember = "ReceivingHeaderKey"
        Me.cboReceiverNumber.FormattingEnabled = True
        Me.cboReceiverNumber.Location = New System.Drawing.Point(105, 423)
        Me.cboReceiverNumber.Name = "cboReceiverNumber"
        Me.cboReceiverNumber.Size = New System.Drawing.Size(181, 21)
        Me.cboReceiverNumber.TabIndex = 7
        '
        'ReceivingHeaderTableBindingSource
        '
        Me.ReceivingHeaderTableBindingSource.DataMember = "ReceivingHeaderTable"
        Me.ReceivingHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ReceiptOfInvoiceVoucherLineQueryBindingSource
        Me.cboPartNumber.DisplayMember = "PartNumber"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(64, 230)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(222, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(101, 617)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpEndDate.TabIndex = 11
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(21, 141)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(265, 50)
        Me.txtVendorName.TabIndex = 2
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(101, 587)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpBeginDate.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 587)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Begin Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 230)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Part #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 617)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "End Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(80, 113)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(206, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 424)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Receiver #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(107, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(179, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Vendor ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(134, 725)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 14
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(21, 478)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 20)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Text Filter"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvROIVoucherLines
        '
        Me.dgvROIVoucherLines.AllowUserToAddRows = False
        Me.dgvROIVoucherLines.AllowUserToDeleteRows = False
        Me.dgvROIVoucherLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvROIVoucherLines.AutoGenerateColumns = False
        Me.dgvROIVoucherLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvROIVoucherLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvROIVoucherLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvROIVoucherLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.VendorIDDataGridViewTextBoxColumn, Me.VoucherNumberColumn, Me.VoucherLineDataGridViewTextBoxColumn, Me.PartNumberDataGridViewTextBoxColumn, Me.PartDescriptionDataGridViewTextBoxColumn, Me.QuantityDataGridViewTextBoxColumn, Me.UnitCostDataGridViewTextBoxColumn, Me.ExtendedAmountDataGridViewTextBoxColumn, Me.InvoiceNumberDataGridViewTextBoxColumn, Me.InvoiceDateDataGridViewTextBoxColumn, Me.ReceivingDate, Me.BatchDate, Me.PONumberDataGridViewTextBoxColumn, Me.ReceiverNumberDataGridViewTextBoxColumn, Me.ReceiverLineDataGridViewTextBoxColumn, Me.GLDebitAccountDataGridViewTextBoxColumn, Me.GLCreditAccountDataGridViewTextBoxColumn, Me.VoucherStatusDataGridViewTextBoxColumn, Me.VoucherSourceDataGridViewTextBoxColumn, Me.PaymentTermsDataGridViewTextBoxColumn, Me.SelectForInvoiceDataGridViewTextBoxColumn, Me.BatchNumberDataGridViewTextBoxColumn})
        Me.dgvROIVoucherLines.DataSource = Me.ReceiptOfInvoiceVoucherLineQueryBindingSource
        Me.dgvROIVoucherLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvROIVoucherLines.Location = New System.Drawing.Point(346, 41)
        Me.dgvROIVoucherLines.Name = "dgvROIVoucherLines"
        Me.dgvROIVoucherLines.ReadOnly = True
        Me.dgvROIVoucherLines.Size = New System.Drawing.Size(784, 712)
        Me.dgvROIVoucherLines.TabIndex = 16
        Me.dgvROIVoucherLines.TabStop = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'VendorIDDataGridViewTextBoxColumn
        '
        Me.VendorIDDataGridViewTextBoxColumn.DataPropertyName = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn.HeaderText = "Vendor"
        Me.VendorIDDataGridViewTextBoxColumn.Name = "VendorIDDataGridViewTextBoxColumn"
        Me.VendorIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VoucherNumberColumn
        '
        Me.VoucherNumberColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn.HeaderText = "Voucher #"
        Me.VoucherNumberColumn.Name = "VoucherNumberColumn"
        Me.VoucherNumberColumn.ReadOnly = True
        Me.VoucherNumberColumn.Width = 85
        '
        'VoucherLineDataGridViewTextBoxColumn
        '
        Me.VoucherLineDataGridViewTextBoxColumn.DataPropertyName = "VoucherLine"
        Me.VoucherLineDataGridViewTextBoxColumn.HeaderText = "Line #"
        Me.VoucherLineDataGridViewTextBoxColumn.Name = "VoucherLineDataGridViewTextBoxColumn"
        Me.VoucherLineDataGridViewTextBoxColumn.ReadOnly = True
        Me.VoucherLineDataGridViewTextBoxColumn.Width = 65
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part #"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PartDescriptionDataGridViewTextBoxColumn
        '
        Me.PartDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.PartDescriptionDataGridViewTextBoxColumn.Name = "PartDescriptionDataGridViewTextBoxColumn"
        Me.PartDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QuantityDataGridViewTextBoxColumn
        '
        Me.QuantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.HeaderText = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.Name = "QuantityDataGridViewTextBoxColumn"
        Me.QuantityDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UnitCostDataGridViewTextBoxColumn
        '
        Me.UnitCostDataGridViewTextBoxColumn.DataPropertyName = "UnitCost"
        Me.UnitCostDataGridViewTextBoxColumn.HeaderText = "Unit Cost"
        Me.UnitCostDataGridViewTextBoxColumn.Name = "UnitCostDataGridViewTextBoxColumn"
        Me.UnitCostDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ExtendedAmountDataGridViewTextBoxColumn
        '
        Me.ExtendedAmountDataGridViewTextBoxColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountDataGridViewTextBoxColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountDataGridViewTextBoxColumn.Name = "ExtendedAmountDataGridViewTextBoxColumn"
        Me.ExtendedAmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'InvoiceNumberDataGridViewTextBoxColumn
        '
        Me.InvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberDataGridViewTextBoxColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberDataGridViewTextBoxColumn.Name = "InvoiceNumberDataGridViewTextBoxColumn"
        Me.InvoiceNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'InvoiceDateDataGridViewTextBoxColumn
        '
        Me.InvoiceDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateDataGridViewTextBoxColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateDataGridViewTextBoxColumn.Name = "InvoiceDateDataGridViewTextBoxColumn"
        Me.InvoiceDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ReceivingDate
        '
        Me.ReceivingDate.DataPropertyName = "ReceivingDate"
        Me.ReceivingDate.HeaderText = "Rcd. Date"
        Me.ReceivingDate.Name = "ReceivingDate"
        Me.ReceivingDate.ReadOnly = True
        '
        'BatchDate
        '
        Me.BatchDate.DataPropertyName = "BatchDate"
        Me.BatchDate.HeaderText = "Post Date"
        Me.BatchDate.Name = "BatchDate"
        Me.BatchDate.ReadOnly = True
        '
        'PONumberDataGridViewTextBoxColumn
        '
        Me.PONumberDataGridViewTextBoxColumn.DataPropertyName = "PONumber"
        Me.PONumberDataGridViewTextBoxColumn.HeaderText = "PO #"
        Me.PONumberDataGridViewTextBoxColumn.Name = "PONumberDataGridViewTextBoxColumn"
        Me.PONumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ReceiverNumberDataGridViewTextBoxColumn
        '
        Me.ReceiverNumberDataGridViewTextBoxColumn.DataPropertyName = "ReceiverNumber"
        Me.ReceiverNumberDataGridViewTextBoxColumn.HeaderText = "Receiver #"
        Me.ReceiverNumberDataGridViewTextBoxColumn.Name = "ReceiverNumberDataGridViewTextBoxColumn"
        Me.ReceiverNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.ReceiverNumberDataGridViewTextBoxColumn.Width = 85
        '
        'ReceiverLineDataGridViewTextBoxColumn
        '
        Me.ReceiverLineDataGridViewTextBoxColumn.DataPropertyName = "ReceiverLine"
        Me.ReceiverLineDataGridViewTextBoxColumn.HeaderText = "Rec. Line #"
        Me.ReceiverLineDataGridViewTextBoxColumn.Name = "ReceiverLineDataGridViewTextBoxColumn"
        Me.ReceiverLineDataGridViewTextBoxColumn.ReadOnly = True
        Me.ReceiverLineDataGridViewTextBoxColumn.Width = 65
        '
        'GLDebitAccountDataGridViewTextBoxColumn
        '
        Me.GLDebitAccountDataGridViewTextBoxColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountDataGridViewTextBoxColumn.HeaderText = "Debit Acct"
        Me.GLDebitAccountDataGridViewTextBoxColumn.Name = "GLDebitAccountDataGridViewTextBoxColumn"
        Me.GLDebitAccountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLCreditAccountDataGridViewTextBoxColumn
        '
        Me.GLCreditAccountDataGridViewTextBoxColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountDataGridViewTextBoxColumn.HeaderText = "Credit Acct"
        Me.GLCreditAccountDataGridViewTextBoxColumn.Name = "GLCreditAccountDataGridViewTextBoxColumn"
        Me.GLCreditAccountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VoucherStatusDataGridViewTextBoxColumn
        '
        Me.VoucherStatusDataGridViewTextBoxColumn.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusDataGridViewTextBoxColumn.HeaderText = "Voucher Status"
        Me.VoucherStatusDataGridViewTextBoxColumn.Name = "VoucherStatusDataGridViewTextBoxColumn"
        Me.VoucherStatusDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VoucherSourceDataGridViewTextBoxColumn
        '
        Me.VoucherSourceDataGridViewTextBoxColumn.DataPropertyName = "VoucherSource"
        Me.VoucherSourceDataGridViewTextBoxColumn.HeaderText = "Voucher Source"
        Me.VoucherSourceDataGridViewTextBoxColumn.Name = "VoucherSourceDataGridViewTextBoxColumn"
        Me.VoucherSourceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PaymentTermsDataGridViewTextBoxColumn
        '
        Me.PaymentTermsDataGridViewTextBoxColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsDataGridViewTextBoxColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsDataGridViewTextBoxColumn.Name = "PaymentTermsDataGridViewTextBoxColumn"
        Me.PaymentTermsDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SelectForInvoiceDataGridViewTextBoxColumn
        '
        Me.SelectForInvoiceDataGridViewTextBoxColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.Name = "SelectForInvoiceDataGridViewTextBoxColumn"
        Me.SelectForInvoiceDataGridViewTextBoxColumn.ReadOnly = True
        Me.SelectForInvoiceDataGridViewTextBoxColumn.Visible = False
        '
        'BatchNumberDataGridViewTextBoxColumn
        '
        Me.BatchNumberDataGridViewTextBoxColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberDataGridViewTextBoxColumn.HeaderText = "BatchNumber"
        Me.BatchNumberDataGridViewTextBoxColumn.Name = "BatchNumberDataGridViewTextBoxColumn"
        Me.BatchNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.BatchNumberDataGridViewTextBoxColumn.Visible = False
        '
        'ReceiptOfInvoiceVoucherLineQueryTableAdapter
        '
        Me.ReceiptOfInvoiceVoucherLineQueryTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ReceivingHeaderTableTableAdapter
        '
        Me.ReceivingHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ReceiptOfInvoiceBatchLineTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineTableAdapter.ClearBeforeFill = True
        '
        'ViewVoucherLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvROIVoucherLines)
        Me.Controls.Add(Me.gpxAPVoucherData)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewVoucherLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Voucher Lines"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAPVoucherData.ResumeLayout(False)
        Me.gpxAPVoucherData.PerformLayout()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceVoucherLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvROIVoucherLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxAPVoucherData As System.Windows.Forms.GroupBox
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClear1 As System.Windows.Forms.Button
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvROIVoucherLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceiptOfInvoiceVoucherLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceVoucherLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLineQueryTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboReceiverNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rdoReceiptDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInvoiceDate As System.Windows.Forms.RadioButton
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherLineDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverLineDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherSourceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboVoucherNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
