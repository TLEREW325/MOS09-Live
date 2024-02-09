<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAPVouchersPaid
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintVoucherListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Print1099sForSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxAPVoucherData = New System.Windows.Forms.GroupBox
        Me.cmdVendor1099 = New System.Windows.Forms.Button
        Me.chkChecked1099 = New System.Windows.Forms.CheckBox
        Me.cboCheckType = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.rdoPaymentDate = New System.Windows.Forms.RadioButton
        Me.rdoInvoiceDate = New System.Windows.Forms.RadioButton
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.APCheckQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtCheckNumber = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.dgvAPVouchers = New System.Windows.Forms.DataGridView
        Me.CheckNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaidDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APBatchNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Checked1099Column = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CheckTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APVoucherNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorAddress1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorCityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorStateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorZipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorAddress2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorCountryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceFreightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OverrideVendorName = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.OverrideNameText = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APCheckQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckQueryTableAdapter
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPaymentTotal = New System.Windows.Forms.TextBox
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmd1099 = New System.Windows.Forms.Button
        Me.gpxPrint1099s = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdPrint1099Misc = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAPVoucherData.SuspendLayout()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APCheckQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAPVouchers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gpxPrint1099s.SuspendLayout()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintVoucherListingToolStripMenuItem, Me.Print1099sForSelectionToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintVoucherListingToolStripMenuItem
        '
        Me.PrintVoucherListingToolStripMenuItem.Name = "PrintVoucherListingToolStripMenuItem"
        Me.PrintVoucherListingToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PrintVoucherListingToolStripMenuItem.Text = "Print Voucher Listing"
        '
        'Print1099sForSelectionToolStripMenuItem
        '
        Me.Print1099sForSelectionToolStripMenuItem.Name = "Print1099sForSelectionToolStripMenuItem"
        Me.Print1099sForSelectionToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.Print1099sForSelectionToolStripMenuItem.Text = "Print 1099's for selection"
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
        Me.cmdPrint.Location = New System.Drawing.Point(983, 773)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 16
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1058, 773)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 17
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxAPVoucherData
        '
        Me.gpxAPVoucherData.Controls.Add(Me.cmdVendor1099)
        Me.gpxAPVoucherData.Controls.Add(Me.chkChecked1099)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCheckType)
        Me.gpxAPVoucherData.Controls.Add(Me.Label5)
        Me.gpxAPVoucherData.Controls.Add(Me.Label13)
        Me.gpxAPVoucherData.Controls.Add(Me.rdoPaymentDate)
        Me.gpxAPVoucherData.Controls.Add(Me.rdoInvoiceDate)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPONumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label14)
        Me.gpxAPVoucherData.Controls.Add(Me.chkDateRange)
        Me.gpxAPVoucherData.Controls.Add(Me.Label12)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpEndDate)
        Me.gpxAPVoucherData.Controls.Add(Me.cboBatchNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPVoucherData.Controls.Add(Me.Label8)
        Me.gpxAPVoucherData.Controls.Add(Me.txtVendorName)
        Me.gpxAPVoucherData.Controls.Add(Me.Label7)
        Me.gpxAPVoucherData.Controls.Add(Me.cboVendorID)
        Me.gpxAPVoucherData.Controls.Add(Me.Label4)
        Me.gpxAPVoucherData.Controls.Add(Me.cboDivisionID)
        Me.gpxAPVoucherData.Controls.Add(Me.txtCheckNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label3)
        Me.gpxAPVoucherData.Controls.Add(Me.txtInvoiceNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label2)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdViewByFilter)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdClear)
        Me.gpxAPVoucherData.Controls.Add(Me.Label1)
        Me.gpxAPVoucherData.Controls.Add(Me.Label6)
        Me.gpxAPVoucherData.Controls.Add(Me.Label11)
        Me.gpxAPVoucherData.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPVoucherData.Name = "gpxAPVoucherData"
        Me.gpxAPVoucherData.Size = New System.Drawing.Size(300, 772)
        Me.gpxAPVoucherData.TabIndex = 0
        Me.gpxAPVoucherData.TabStop = False
        Me.gpxAPVoucherData.Text = "View By Filters"
        '
        'cmdVendor1099
        '
        Me.cmdVendor1099.Location = New System.Drawing.Point(22, 728)
        Me.cmdVendor1099.Name = "cmdVendor1099"
        Me.cmdVendor1099.Size = New System.Drawing.Size(71, 30)
        Me.cmdVendor1099.TabIndex = 50
        Me.cmdVendor1099.Text = "View 1099"
        Me.cmdVendor1099.UseVisualStyleBackColor = True
        '
        'chkChecked1099
        '
        Me.chkChecked1099.AutoSize = True
        Me.chkChecked1099.Location = New System.Drawing.Point(85, 477)
        Me.chkChecked1099.Name = "chkChecked1099"
        Me.chkChecked1099.Size = New System.Drawing.Size(165, 17)
        Me.chkChecked1099.TabIndex = 8
        Me.chkChecked1099.Text = "Vendor receives a 1099 Form"
        Me.chkChecked1099.UseVisualStyleBackColor = True
        '
        'cboCheckType
        '
        Me.cboCheckType.FormattingEnabled = True
        Me.cboCheckType.Items.AddRange(New Object() {"CHECK", "ACH"})
        Me.cboCheckType.Location = New System.Drawing.Point(114, 231)
        Me.cboCheckType.Name = "cboCheckType"
        Me.cboCheckType.Size = New System.Drawing.Size(171, 21)
        Me.cboCheckType.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(23, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Check Type"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(136, 673)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(149, 33)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "Select date to filter list by."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoPaymentDate
        '
        Me.rdoPaymentDate.AutoSize = True
        Me.rdoPaymentDate.Location = New System.Drawing.Point(22, 692)
        Me.rdoPaymentDate.Name = "rdoPaymentDate"
        Me.rdoPaymentDate.Size = New System.Drawing.Size(92, 17)
        Me.rdoPaymentDate.TabIndex = 13
        Me.rdoPaymentDate.Text = "Payment Date"
        Me.rdoPaymentDate.UseVisualStyleBackColor = True
        '
        'rdoInvoiceDate
        '
        Me.rdoInvoiceDate.AutoSize = True
        Me.rdoInvoiceDate.Checked = True
        Me.rdoInvoiceDate.Location = New System.Drawing.Point(22, 664)
        Me.rdoInvoiceDate.Name = "rdoInvoiceDate"
        Me.rdoInvoiceDate.Size = New System.Drawing.Size(86, 17)
        Me.rdoInvoiceDate.TabIndex = 12
        Me.rdoInvoiceDate.TabStop = True
        Me.rdoInvoiceDate.Text = "Invoice Date"
        Me.rdoInvoiceDate.UseVisualStyleBackColor = True
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPONumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(85, 381)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(200, 21)
        Me.cboPONumber.TabIndex = 6
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(21, 521)
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
        Me.chkDateRange.Location = New System.Drawing.Point(114, 557)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 9
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(23, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 40)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(113, 625)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(172, 20)
        Me.dtpEndDate.TabIndex = 11
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBatchNumber.DataSource = Me.APCheckQueryBindingSource
        Me.cboBatchNumber.DisplayMember = "APBatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(85, 429)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(200, 21)
        Me.cboBatchNumber.TabIndex = 7
        '
        'APCheckQueryBindingSource
        '
        Me.APCheckQueryBindingSource.DataMember = "APCheckQuery"
        Me.APCheckQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(113, 595)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(172, 20)
        Me.dtpBeginDate.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(20, 625)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(23, 157)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(262, 50)
        Me.txtVendorName.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 595)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Begin Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.DropDownWidth = 250
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(85, 120)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(200, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(23, 430)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Batch #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(85, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(200, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckNumber.Location = New System.Drawing.Point(85, 334)
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(200, 20)
        Me.txtCheckNumber.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(23, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Vendor ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(23, 287)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(262, 20)
        Me.txtInvoiceNumber.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(23, 264)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Invoice #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(118, 728)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 14
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 728)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(23, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(23, 334)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Check #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(23, 382)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "PO #"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'dgvAPVouchers
        '
        Me.dgvAPVouchers.AllowUserToAddRows = False
        Me.dgvAPVouchers.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvAPVouchers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAPVouchers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAPVouchers.AutoGenerateColumns = False
        Me.dgvAPVouchers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAPVouchers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAPVouchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPVouchers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CheckNumberColumn, Me.VendorIDColumn, Me.VendorNameColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.InvoiceTotalColumn, Me.DiscountAmountColumn, Me.PaymentAmountColumn, Me.ReceiptDateColumn, Me.DueDateColumn, Me.DiscountDateColumn, Me.PaidDateColumn, Me.CommentColumn, Me.PaymentTermsColumn, Me.VoucherNumberColumn, Me.PONumberDataGridViewTextBoxColumn, Me.APBatchNumberDataGridViewTextBoxColumn, Me.Checked1099Column, Me.CheckTypeColumn, Me.CheckStatusDataGridViewTextBoxColumn, Me.VoucherStatusDataGridViewTextBoxColumn, Me.VoucherDateDataGridViewTextBoxColumn, Me.VoucherAmountDataGridViewTextBoxColumn, Me.APVoucherNumberDataGridViewTextBoxColumn, Me.VendorAddress1DataGridViewTextBoxColumn, Me.VendorCityDataGridViewTextBoxColumn, Me.VendorStateDataGridViewTextBoxColumn, Me.VendorZipDataGridViewTextBoxColumn, Me.VendorAddress2DataGridViewTextBoxColumn, Me.VendorCountryDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.CheckDateDataGridViewTextBoxColumn, Me.CheckAmountDataGridViewTextBoxColumn, Me.ProductTotalDataGridViewTextBoxColumn, Me.InvoiceFreightDataGridViewTextBoxColumn, Me.InvoiceSalesTaxDataGridViewTextBoxColumn, Me.OverrideVendorName, Me.OverrideNameText})
        Me.dgvAPVouchers.DataSource = Me.APCheckQueryBindingSource
        Me.dgvAPVouchers.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvAPVouchers.Location = New System.Drawing.Point(346, 41)
        Me.dgvAPVouchers.Name = "dgvAPVouchers"
        Me.dgvAPVouchers.Size = New System.Drawing.Size(784, 670)
        Me.dgvAPVouchers.TabIndex = 30
        Me.dgvAPVouchers.TabStop = False
        '
        'CheckNumberColumn
        '
        Me.CheckNumberColumn.DataPropertyName = "CheckNumber"
        Me.CheckNumberColumn.HeaderText = "Check Number"
        Me.CheckNumberColumn.Name = "CheckNumberColumn"
        Me.CheckNumberColumn.ReadOnly = True
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor ID"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.ReadOnly = True
        '
        'VendorNameColumn
        '
        Me.VendorNameColumn.DataPropertyName = "VendorName"
        Me.VendorNameColumn.HeaderText = "Vendor Name"
        Me.VendorNameColumn.Name = "VendorNameColumn"
        Me.VendorNameColumn.ReadOnly = True
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
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.ReadOnly = True
        '
        'DiscountAmountColumn
        '
        Me.DiscountAmountColumn.DataPropertyName = "DiscountAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.DiscountAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DiscountAmountColumn.HeaderText = "Discount Amount"
        Me.DiscountAmountColumn.Name = "DiscountAmountColumn"
        Me.DiscountAmountColumn.ReadOnly = True
        '
        'PaymentAmountColumn
        '
        Me.PaymentAmountColumn.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.PaymentAmountColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.PaymentAmountColumn.HeaderText = "Payment Amount"
        Me.PaymentAmountColumn.Name = "PaymentAmountColumn"
        Me.PaymentAmountColumn.ReadOnly = True
        '
        'ReceiptDateColumn
        '
        Me.ReceiptDateColumn.DataPropertyName = "ReceiptDate"
        Me.ReceiptDateColumn.HeaderText = "Receipt Date"
        Me.ReceiptDateColumn.Name = "ReceiptDateColumn"
        '
        'DueDateColumn
        '
        Me.DueDateColumn.DataPropertyName = "DueDate"
        Me.DueDateColumn.HeaderText = "Due Date"
        Me.DueDateColumn.Name = "DueDateColumn"
        '
        'DiscountDateColumn
        '
        Me.DiscountDateColumn.DataPropertyName = "DiscountDate"
        Me.DiscountDateColumn.HeaderText = "Discount Date"
        Me.DiscountDateColumn.Name = "DiscountDateColumn"
        '
        'PaidDateColumn
        '
        Me.PaidDateColumn.DataPropertyName = "PaidDate"
        Me.PaidDateColumn.HeaderText = "Paid Date"
        Me.PaidDateColumn.Name = "PaidDateColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        '
        'VoucherNumberColumn
        '
        Me.VoucherNumberColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn.HeaderText = "Voucher #"
        Me.VoucherNumberColumn.Name = "VoucherNumberColumn"
        Me.VoucherNumberColumn.ReadOnly = True
        '
        'PONumberDataGridViewTextBoxColumn
        '
        Me.PONumberDataGridViewTextBoxColumn.DataPropertyName = "PONumber"
        Me.PONumberDataGridViewTextBoxColumn.HeaderText = "PO #"
        Me.PONumberDataGridViewTextBoxColumn.Name = "PONumberDataGridViewTextBoxColumn"
        Me.PONumberDataGridViewTextBoxColumn.Visible = False
        '
        'APBatchNumberDataGridViewTextBoxColumn
        '
        Me.APBatchNumberDataGridViewTextBoxColumn.DataPropertyName = "APBatchNumber"
        Me.APBatchNumberDataGridViewTextBoxColumn.HeaderText = "Batch #"
        Me.APBatchNumberDataGridViewTextBoxColumn.Name = "APBatchNumberDataGridViewTextBoxColumn"
        '
        'Checked1099Column
        '
        Me.Checked1099Column.DataPropertyName = "Checked1099"
        Me.Checked1099Column.FalseValue = "NO"
        Me.Checked1099Column.HeaderText = "1099?"
        Me.Checked1099Column.IndeterminateValue = "NO"
        Me.Checked1099Column.Name = "Checked1099Column"
        Me.Checked1099Column.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Checked1099Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Checked1099Column.TrueValue = "YES"
        '
        'CheckTypeColumn
        '
        Me.CheckTypeColumn.DataPropertyName = "CheckType"
        Me.CheckTypeColumn.HeaderText = "Check Type"
        Me.CheckTypeColumn.Name = "CheckTypeColumn"
        '
        'CheckStatusDataGridViewTextBoxColumn
        '
        Me.CheckStatusDataGridViewTextBoxColumn.DataPropertyName = "CheckStatus"
        Me.CheckStatusDataGridViewTextBoxColumn.HeaderText = "Check Status"
        Me.CheckStatusDataGridViewTextBoxColumn.Name = "CheckStatusDataGridViewTextBoxColumn"
        '
        'VoucherStatusDataGridViewTextBoxColumn
        '
        Me.VoucherStatusDataGridViewTextBoxColumn.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusDataGridViewTextBoxColumn.HeaderText = "Voucher Status"
        Me.VoucherStatusDataGridViewTextBoxColumn.Name = "VoucherStatusDataGridViewTextBoxColumn"
        '
        'VoucherDateDataGridViewTextBoxColumn
        '
        Me.VoucherDateDataGridViewTextBoxColumn.DataPropertyName = "VoucherDate"
        Me.VoucherDateDataGridViewTextBoxColumn.HeaderText = "Voucher Date"
        Me.VoucherDateDataGridViewTextBoxColumn.Name = "VoucherDateDataGridViewTextBoxColumn"
        '
        'VoucherAmountDataGridViewTextBoxColumn
        '
        Me.VoucherAmountDataGridViewTextBoxColumn.DataPropertyName = "VoucherAmount"
        Me.VoucherAmountDataGridViewTextBoxColumn.HeaderText = "Voucher Amount"
        Me.VoucherAmountDataGridViewTextBoxColumn.Name = "VoucherAmountDataGridViewTextBoxColumn"
        '
        'APVoucherNumberDataGridViewTextBoxColumn
        '
        Me.APVoucherNumberDataGridViewTextBoxColumn.DataPropertyName = "APVoucherNumber"
        Me.APVoucherNumberDataGridViewTextBoxColumn.HeaderText = "APVoucherNumber"
        Me.APVoucherNumberDataGridViewTextBoxColumn.Name = "APVoucherNumberDataGridViewTextBoxColumn"
        Me.APVoucherNumberDataGridViewTextBoxColumn.Visible = False
        '
        'VendorAddress1DataGridViewTextBoxColumn
        '
        Me.VendorAddress1DataGridViewTextBoxColumn.DataPropertyName = "VendorAddress1"
        Me.VendorAddress1DataGridViewTextBoxColumn.HeaderText = "VendorAddress1"
        Me.VendorAddress1DataGridViewTextBoxColumn.Name = "VendorAddress1DataGridViewTextBoxColumn"
        Me.VendorAddress1DataGridViewTextBoxColumn.Visible = False
        '
        'VendorCityDataGridViewTextBoxColumn
        '
        Me.VendorCityDataGridViewTextBoxColumn.DataPropertyName = "VendorCity"
        Me.VendorCityDataGridViewTextBoxColumn.HeaderText = "VendorCity"
        Me.VendorCityDataGridViewTextBoxColumn.Name = "VendorCityDataGridViewTextBoxColumn"
        Me.VendorCityDataGridViewTextBoxColumn.Visible = False
        '
        'VendorStateDataGridViewTextBoxColumn
        '
        Me.VendorStateDataGridViewTextBoxColumn.DataPropertyName = "VendorState"
        Me.VendorStateDataGridViewTextBoxColumn.HeaderText = "VendorState"
        Me.VendorStateDataGridViewTextBoxColumn.Name = "VendorStateDataGridViewTextBoxColumn"
        Me.VendorStateDataGridViewTextBoxColumn.Visible = False
        '
        'VendorZipDataGridViewTextBoxColumn
        '
        Me.VendorZipDataGridViewTextBoxColumn.DataPropertyName = "VendorZip"
        Me.VendorZipDataGridViewTextBoxColumn.HeaderText = "VendorZip"
        Me.VendorZipDataGridViewTextBoxColumn.Name = "VendorZipDataGridViewTextBoxColumn"
        Me.VendorZipDataGridViewTextBoxColumn.Visible = False
        '
        'VendorAddress2DataGridViewTextBoxColumn
        '
        Me.VendorAddress2DataGridViewTextBoxColumn.DataPropertyName = "VendorAddress2"
        Me.VendorAddress2DataGridViewTextBoxColumn.HeaderText = "VendorAddress2"
        Me.VendorAddress2DataGridViewTextBoxColumn.Name = "VendorAddress2DataGridViewTextBoxColumn"
        Me.VendorAddress2DataGridViewTextBoxColumn.Visible = False
        '
        'VendorCountryDataGridViewTextBoxColumn
        '
        Me.VendorCountryDataGridViewTextBoxColumn.DataPropertyName = "VendorCountry"
        Me.VendorCountryDataGridViewTextBoxColumn.HeaderText = "VendorCountry"
        Me.VendorCountryDataGridViewTextBoxColumn.Name = "VendorCountryDataGridViewTextBoxColumn"
        Me.VendorCountryDataGridViewTextBoxColumn.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "Division"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        '
        'CheckDateDataGridViewTextBoxColumn
        '
        Me.CheckDateDataGridViewTextBoxColumn.DataPropertyName = "CheckDate"
        Me.CheckDateDataGridViewTextBoxColumn.HeaderText = "Check Date"
        Me.CheckDateDataGridViewTextBoxColumn.Name = "CheckDateDataGridViewTextBoxColumn"
        Me.CheckDateDataGridViewTextBoxColumn.Visible = False
        '
        'CheckAmountDataGridViewTextBoxColumn
        '
        Me.CheckAmountDataGridViewTextBoxColumn.DataPropertyName = "CheckAmount"
        Me.CheckAmountDataGridViewTextBoxColumn.HeaderText = "Check Amount"
        Me.CheckAmountDataGridViewTextBoxColumn.Name = "CheckAmountDataGridViewTextBoxColumn"
        Me.CheckAmountDataGridViewTextBoxColumn.Visible = False
        '
        'ProductTotalDataGridViewTextBoxColumn
        '
        Me.ProductTotalDataGridViewTextBoxColumn.DataPropertyName = "ProductTotal"
        Me.ProductTotalDataGridViewTextBoxColumn.HeaderText = "ProductTotal"
        Me.ProductTotalDataGridViewTextBoxColumn.Name = "ProductTotalDataGridViewTextBoxColumn"
        Me.ProductTotalDataGridViewTextBoxColumn.Visible = False
        '
        'InvoiceFreightDataGridViewTextBoxColumn
        '
        Me.InvoiceFreightDataGridViewTextBoxColumn.DataPropertyName = "InvoiceFreight"
        Me.InvoiceFreightDataGridViewTextBoxColumn.HeaderText = "InvoiceFreight"
        Me.InvoiceFreightDataGridViewTextBoxColumn.Name = "InvoiceFreightDataGridViewTextBoxColumn"
        Me.InvoiceFreightDataGridViewTextBoxColumn.Visible = False
        '
        'InvoiceSalesTaxDataGridViewTextBoxColumn
        '
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.DataPropertyName = "InvoiceSalesTax"
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.HeaderText = "InvoiceSalesTax"
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.Name = "InvoiceSalesTaxDataGridViewTextBoxColumn"
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.Visible = False
        '
        'OverrideVendorName
        '
        Me.OverrideVendorName.FalseValue = "False"
        Me.OverrideVendorName.HeaderText = "Override 1099 Name"
        Me.OverrideVendorName.Name = "OverrideVendorName"
        Me.OverrideVendorName.TrueValue = "True"
        Me.OverrideVendorName.Visible = False
        '
        'OverrideNameText
        '
        Me.OverrideNameText.HeaderText = "1099 Name"
        Me.OverrideNameText.Name = "OverrideNameText"
        Me.OverrideNameText.Visible = False
        '
        'APCheckQueryTableAdapter
        '
        Me.APCheckQueryTableAdapter.ClearBeforeFill = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(40, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Payment Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPaymentTotal
        '
        Me.txtPaymentTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPaymentTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentTotal.Location = New System.Drawing.Point(40, 46)
        Me.txtPaymentTotal.Name = "txtPaymentTotal"
        Me.txtPaymentTotal.Size = New System.Drawing.Size(162, 20)
        Me.txtPaymentTotal.TabIndex = 14
        Me.txtPaymentTotal.TabStop = False
        Me.txtPaymentTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtPaymentTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(346, 730)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(241, 83)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datagrid Total"
        '
        'cmd1099
        '
        Me.cmd1099.Location = New System.Drawing.Point(218, 23)
        Me.cmd1099.Name = "cmd1099"
        Me.cmd1099.Size = New System.Drawing.Size(71, 43)
        Me.cmd1099.TabIndex = 50
        Me.cmd1099.Text = "Print 1099's"
        Me.cmd1099.UseVisualStyleBackColor = True
        '
        'gpxPrint1099s
        '
        Me.gpxPrint1099s.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPrint1099s.Controls.Add(Me.cmdPrint1099Misc)
        Me.gpxPrint1099s.Controls.Add(Me.cmd1099)
        Me.gpxPrint1099s.Controls.Add(Me.Label10)
        Me.gpxPrint1099s.Enabled = False
        Me.gpxPrint1099s.Location = New System.Drawing.Point(605, 730)
        Me.gpxPrint1099s.Name = "gpxPrint1099s"
        Me.gpxPrint1099s.Size = New System.Drawing.Size(372, 83)
        Me.gpxPrint1099s.TabIndex = 35
        Me.gpxPrint1099s.TabStop = False
        Me.gpxPrint1099s.Text = "Print 1099's for Vendors"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(6, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(206, 46)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Filter the datagrid and then press ""Print 1099's"" to print all Vendor 1099 Forms " & _
            "for the selected filter."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint1099Misc
        '
        Me.cmdPrint1099Misc.Location = New System.Drawing.Point(295, 23)
        Me.cmdPrint1099Misc.Name = "cmdPrint1099Misc"
        Me.cmdPrint1099Misc.Size = New System.Drawing.Size(71, 43)
        Me.cmdPrint1099Misc.TabIndex = 51
        Me.cmdPrint1099Misc.Text = "Print 1099 Misc"
        Me.cmdPrint1099Misc.UseVisualStyleBackColor = True
        '
        'ViewAPVouchersPaid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.gpxPrint1099s)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvAPVouchers)
        Me.Controls.Add(Me.gpxAPVoucherData)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewAPVouchersPaid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Voucher Payments"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAPVoucherData.ResumeLayout(False)
        Me.gpxAPVoucherData.PerformLayout()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APCheckQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAPVouchers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpxPrint1099s.ResumeLayout(False)
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents dgvAPVouchers As System.Windows.Forms.DataGridView
    Friend WithEvents APCheckQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APCheckQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckQueryTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cboBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PrintVoucherListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rdoPaymentDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInvoiceDate As System.Windows.Forms.RadioButton
    Friend WithEvents cboCheckType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkChecked1099 As System.Windows.Forms.CheckBox
    Friend WithEvents Print1099sForSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gpxPrint1099s As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmd1099 As System.Windows.Forms.Button
    Friend WithEvents cmdVendor1099 As System.Windows.Forms.Button
    Friend WithEvents CheckNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaidDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APBatchNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Checked1099Column As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CheckTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APVoucherNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorAddress1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorCityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorStateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorZipDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorAddress2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorCountryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceFreightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSalesTaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OverrideVendorName As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OverrideNameText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdPrint1099Misc As System.Windows.Forms.Button
End Class
