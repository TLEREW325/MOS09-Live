<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APProcessVouchers
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
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.PaymentTermsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdGenerateVoucher = New System.Windows.Forms.Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.ReceiptTransactionDescriptionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboVoucherNumber = New System.Windows.Forms.ComboBox
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.gpxVoucherHeader = New System.Windows.Forms.GroupBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.cboCheckType = New System.Windows.Forms.ComboBox
        Me.chkOnHold = New System.Windows.Forms.CheckBox
        Me.chkWhitePaper = New System.Windows.Forms.CheckBox
        Me.dtpDueDateDD = New System.Windows.Forms.DateTimePicker
        Me.dtpDueDate = New System.Windows.Forms.TextBox
        Me.dtpDiscountDateDD = New System.Windows.Forms.DateTimePicker
        Me.dtpDiscountDate = New System.Windows.Forms.TextBox
        Me.dtpReceiptDateDD = New System.Windows.Forms.DateTimePicker
        Me.dtpReceiptDate = New System.Windows.Forms.TextBox
        Me.dtpInvoiceDateDD = New System.Windows.Forms.DateTimePicker
        Me.dtpInvoiceDate = New System.Windows.Forms.TextBox
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.VendorClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtInvoiceAmount = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.llRemitToAddress = New System.Windows.Forms.LinkLabel
        Me.lblCheckCode = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.cmdEnterLine = New System.Windows.Forms.Button
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.cboItemID = New System.Windows.Forms.ComboBox
        Me.NonInventoryItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtDivisionID = New System.Windows.Forms.TextBox
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvVoucherLines = New System.Windows.Forms.DataGridView
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptOfInvoiceVoucherLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceiptOfInvoiceVoucherLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkManualDiscount = New System.Windows.Forms.CheckBox
        Me.txtDiscountAmount = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtInvoiceTotal = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSalesTaxTotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPurchaseTotal = New System.Windows.Forms.TextBox
        Me.cboDebitAccount = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label22 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cboDebitDescription = New System.Windows.Forms.ComboBox
        Me.cboCreditDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCreditAccount = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdEnterVoucher = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.ReceiptTransactionDescriptionTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptTransactionDescriptionTableAdapter
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.NonInventoryItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.PaymentTermsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
        Me.gpxVendorAddress = New System.Windows.Forms.GroupBox
        Me.cmdUpdateVendor = New System.Windows.Forms.Button
        Me.cmdReturnToMain = New System.Windows.Forms.Button
        Me.txtRemitToZip = New System.Windows.Forms.TextBox
        Me.txtRemitToState = New System.Windows.Forms.TextBox
        Me.txtRemitToCountry = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtRemitToCity = New System.Windows.Forms.TextBox
        Me.txtRemitToAddress2 = New System.Windows.Forms.TextBox
        Me.txtRemitToAddress1 = New System.Windows.Forms.TextBox
        Me.txtRemitToVendorID = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtRemitToVendorName = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.VendorClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
        Me.cboVoucherLine = New System.Windows.Forms.ComboBox
        Me.tabLineControls = New System.Windows.Forms.TabControl
        Me.tabEnterNew = New System.Windows.Forms.TabPage
        Me.tabDeleteLine = New System.Windows.Forms.TabPage
        Me.Label34 = New System.Windows.Forms.Label
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.txtLinePartDescription = New System.Windows.Forms.TextBox
        Me.txtLinePartNumber = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptTransactionDescriptionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxVoucherHeader.SuspendLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.GLAccountsBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxVendorAddress.SuspendLayout()
        Me.tabLineControls.SuspendLayout()
        Me.tabEnterNew.SuspendLayout()
        Me.tabDeleteLine.SuspendLayout()
        Me.SuspendLayout()
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.SaveToolStripMenuItem.Text = "Save Voucher"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.PrintToolStripMenuItem.Text = "Print Voucher"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete Voucher"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
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
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 35
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(905, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 34
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(828, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 33
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 36
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(111, 208)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(198, 20)
        Me.txtInvoiceNumber.TabIndex = 6
        Me.txtInvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(15, 298)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(124, 20)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "Receipt Date"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.DataSource = Me.PaymentTermsBindingSource
        Me.cboPaymentTerms.DisplayMember = "PmtTermsID"
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Location = New System.Drawing.Point(111, 328)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(198, 21)
        Me.cboPaymentTerms.TabIndex = 10
        '
        'PaymentTermsBindingSource
        '
        Me.PaymentTermsBindingSource.DataMember = "PaymentTerms"
        Me.PaymentTermsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(15, 359)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(124, 20)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Discount Date"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(15, 208)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 20)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Invoice Number"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(15, 329)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 20)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Payment Terms"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGenerateVoucher
        '
        Me.cmdGenerateVoucher.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateVoucher.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateVoucher.Location = New System.Drawing.Point(93, 28)
        Me.cmdGenerateVoucher.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateVoucher.Name = "cmdGenerateVoucher"
        Me.cmdGenerateVoucher.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateVoucher.TabIndex = 1
        Me.cmdGenerateVoucher.Text = ">>"
        Me.cmdGenerateVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateVoucher.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(15, 238)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(124, 20)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "Invoice Date"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ReceiptTransactionDescriptionBindingSource
        '
        Me.ReceiptTransactionDescriptionBindingSource.DataMember = "ReceiptTransactionDescription"
        Me.ReceiptTransactionDescriptionBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboVoucherNumber
        '
        Me.cboVoucherNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVoucherNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVoucherNumber.DataSource = Me.ReceiptOfInvoiceBatchLineBindingSource
        Me.cboVoucherNumber.DisplayMember = "VoucherNumber"
        Me.cboVoucherNumber.FormattingEnabled = True
        Me.cboVoucherNumber.Location = New System.Drawing.Point(128, 28)
        Me.cboVoucherNumber.Name = "cboVoucherNumber"
        Me.cboVoucherNumber.Size = New System.Drawing.Size(184, 21)
        Me.cboVoucherNumber.TabIndex = 2
        '
        'ReceiptOfInvoiceBatchLineBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataMember = "ReceiptOfInvoiceBatchLine"
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(21, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(124, 20)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Voucher #"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(96, 58)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(216, 21)
        Me.cboVendorID.TabIndex = 3
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'gpxVoucherHeader
        '
        Me.gpxVoucherHeader.Controls.Add(Me.Label35)
        Me.gpxVoucherHeader.Controls.Add(Me.cboCheckType)
        Me.gpxVoucherHeader.Controls.Add(Me.chkOnHold)
        Me.gpxVoucherHeader.Controls.Add(Me.chkWhitePaper)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpDueDateDD)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpDueDate)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpDiscountDateDD)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpDiscountDate)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpReceiptDateDD)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpReceiptDate)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpInvoiceDateDD)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpInvoiceDate)
        Me.gpxVoucherHeader.Controls.Add(Me.cboVendorClass)
        Me.gpxVoucherHeader.Controls.Add(Me.txtInvoiceAmount)
        Me.gpxVoucherHeader.Controls.Add(Me.txtInvoiceNumber)
        Me.gpxVoucherHeader.Controls.Add(Me.cboPaymentTerms)
        Me.gpxVoucherHeader.Controls.Add(Me.Label31)
        Me.gpxVoucherHeader.Controls.Add(Me.Label25)
        Me.gpxVoucherHeader.Controls.Add(Me.Label4)
        Me.gpxVoucherHeader.Controls.Add(Me.Label3)
        Me.gpxVoucherHeader.Controls.Add(Me.txtComment)
        Me.gpxVoucherHeader.Controls.Add(Me.txtVendorName)
        Me.gpxVoucherHeader.Controls.Add(Me.cmdGenerateVoucher)
        Me.gpxVoucherHeader.Controls.Add(Me.cboVoucherNumber)
        Me.gpxVoucherHeader.Controls.Add(Me.Label10)
        Me.gpxVoucherHeader.Controls.Add(Me.cboVendorID)
        Me.gpxVoucherHeader.Controls.Add(Me.Label20)
        Me.gpxVoucherHeader.Controls.Add(Me.Label17)
        Me.gpxVoucherHeader.Controls.Add(Me.Label16)
        Me.gpxVoucherHeader.Controls.Add(Me.Label15)
        Me.gpxVoucherHeader.Controls.Add(Me.Label14)
        Me.gpxVoucherHeader.Controls.Add(Me.llRemitToAddress)
        Me.gpxVoucherHeader.Location = New System.Drawing.Point(29, 142)
        Me.gpxVoucherHeader.Name = "gpxVoucherHeader"
        Me.gpxVoucherHeader.Size = New System.Drawing.Size(329, 669)
        Me.gpxVoucherHeader.TabIndex = 1
        Me.gpxVoucherHeader.TabStop = False
        Me.gpxVoucherHeader.Text = "Voucher Header Information"
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(15, 423)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(93, 20)
        Me.Label35.TabIndex = 94
        Me.Label35.Text = "Check Type"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCheckType
        '
        Me.cboCheckType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCheckType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCheckType.FormattingEnabled = True
        Me.cboCheckType.Items.AddRange(New Object() {"STANDARD", "FEDEX", "INTERCOMPANY", "ACH"})
        Me.cboCheckType.Location = New System.Drawing.Point(111, 422)
        Me.cboCheckType.Name = "cboCheckType"
        Me.cboCheckType.Size = New System.Drawing.Size(198, 21)
        Me.cboCheckType.TabIndex = 93
        '
        'chkOnHold
        '
        Me.chkOnHold.AutoSize = True
        Me.chkOnHold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOnHold.ForeColor = System.Drawing.Color.Blue
        Me.chkOnHold.Location = New System.Drawing.Point(18, 487)
        Me.chkOnHold.Name = "chkOnHold"
        Me.chkOnHold.Size = New System.Drawing.Size(229, 20)
        Me.chkOnHold.TabIndex = 92
        Me.chkOnHold.Text = "Check to place this ON HOLD"
        Me.chkOnHold.UseVisualStyleBackColor = True
        '
        'chkWhitePaper
        '
        Me.chkWhitePaper.AutoSize = True
        Me.chkWhitePaper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWhitePaper.ForeColor = System.Drawing.Color.Blue
        Me.chkWhitePaper.Location = New System.Drawing.Point(18, 459)
        Me.chkWhitePaper.Name = "chkWhitePaper"
        Me.chkWhitePaper.Size = New System.Drawing.Size(252, 20)
        Me.chkWhitePaper.TabIndex = 91
        Me.chkWhitePaper.Text = "Check if it is a white paper check"
        Me.chkWhitePaper.UseVisualStyleBackColor = True
        '
        'dtpDueDateDD
        '
        Me.dtpDueDateDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDueDateDD.Location = New System.Drawing.Point(289, 389)
        Me.dtpDueDateDD.Name = "dtpDueDateDD"
        Me.dtpDueDateDD.Size = New System.Drawing.Size(20, 20)
        Me.dtpDueDateDD.TabIndex = 12
        Me.dtpDueDateDD.TabStop = False
        '
        'dtpDueDate
        '
        Me.dtpDueDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpDueDate.Location = New System.Drawing.Point(111, 389)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(198, 20)
        Me.dtpDueDate.TabIndex = 12
        '
        'dtpDiscountDateDD
        '
        Me.dtpDiscountDateDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDiscountDateDD.Location = New System.Drawing.Point(289, 359)
        Me.dtpDiscountDateDD.Name = "dtpDiscountDateDD"
        Me.dtpDiscountDateDD.Size = New System.Drawing.Size(20, 20)
        Me.dtpDiscountDateDD.TabIndex = 11
        Me.dtpDiscountDateDD.TabStop = False
        '
        'dtpDiscountDate
        '
        Me.dtpDiscountDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpDiscountDate.Location = New System.Drawing.Point(111, 359)
        Me.dtpDiscountDate.Name = "dtpDiscountDate"
        Me.dtpDiscountDate.Size = New System.Drawing.Size(198, 20)
        Me.dtpDiscountDate.TabIndex = 11
        '
        'dtpReceiptDateDD
        '
        Me.dtpReceiptDateDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReceiptDateDD.Location = New System.Drawing.Point(289, 298)
        Me.dtpReceiptDateDD.Name = "dtpReceiptDateDD"
        Me.dtpReceiptDateDD.Size = New System.Drawing.Size(20, 20)
        Me.dtpReceiptDateDD.TabIndex = 9
        Me.dtpReceiptDateDD.TabStop = False
        '
        'dtpReceiptDate
        '
        Me.dtpReceiptDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpReceiptDate.Location = New System.Drawing.Point(111, 298)
        Me.dtpReceiptDate.Name = "dtpReceiptDate"
        Me.dtpReceiptDate.Size = New System.Drawing.Size(198, 20)
        Me.dtpReceiptDate.TabIndex = 9
        '
        'dtpInvoiceDateDD
        '
        Me.dtpInvoiceDateDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInvoiceDateDD.Location = New System.Drawing.Point(289, 238)
        Me.dtpInvoiceDateDD.Name = "dtpInvoiceDateDD"
        Me.dtpInvoiceDateDD.Size = New System.Drawing.Size(20, 20)
        Me.dtpInvoiceDateDD.TabIndex = 7
        Me.dtpInvoiceDateDD.TabStop = False
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(111, 238)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(198, 20)
        Me.dtpInvoiceDate.TabIndex = 7
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.DataSource = Me.VendorClassBindingSource
        Me.cboVendorClass.DisplayMember = "VendClassID"
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(111, 177)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(198, 21)
        Me.cboVendorClass.TabIndex = 5
        '
        'VendorClassBindingSource
        '
        Me.VendorClassBindingSource.DataMember = "VendorClass"
        Me.VendorClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtInvoiceAmount
        '
        Me.txtInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceAmount.Location = New System.Drawing.Point(111, 268)
        Me.txtInvoiceAmount.Name = "txtInvoiceAmount"
        Me.txtInvoiceAmount.Size = New System.Drawing.Size(198, 20)
        Me.txtInvoiceAmount.TabIndex = 8
        Me.txtInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(15, 178)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(124, 20)
        Me.Label31.TabIndex = 90
        Me.Label31.Text = "Vendor Class"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(15, 389)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(124, 20)
        Me.Label25.TabIndex = 77
        Me.Label25.Text = "Due Date"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 268)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 20)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Invoice Amount"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 531)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 20)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Voucher Comment"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(18, 554)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(291, 98)
        Me.txtComment.TabIndex = 13
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorName.Location = New System.Drawing.Point(21, 92)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(291, 67)
        Me.txtVendorName.TabIndex = 4
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'llRemitToAddress
        '
        Me.llRemitToAddress.Location = New System.Drawing.Point(21, 58)
        Me.llRemitToAddress.Name = "llRemitToAddress"
        Me.llRemitToAddress.Size = New System.Drawing.Size(100, 23)
        Me.llRemitToAddress.TabIndex = 88
        Me.llRemitToAddress.TabStop = True
        Me.llRemitToAddress.Text = "Vendor ID"
        Me.llRemitToAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCheckCode
        '
        Me.lblCheckCode.ForeColor = System.Drawing.Color.Blue
        Me.lblCheckCode.Location = New System.Drawing.Point(570, 781)
        Me.lblCheckCode.Name = "lblCheckCode"
        Me.lblCheckCode.Size = New System.Drawing.Size(181, 20)
        Me.lblCheckCode.TabIndex = 93
        Me.lblCheckCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCheckCode.Visible = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(18, 198)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 20)
        Me.Label18.TabIndex = 89
        Me.Label18.Text = "Extended Cost"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedAmount.Enabled = False
        Me.txtExtendedAmount.Location = New System.Drawing.Point(183, 198)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtExtendedAmount.TabIndex = 18
        Me.txtExtendedAmount.TabStop = False
        Me.txtExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(18, 169)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 20)
        Me.Label19.TabIndex = 87
        Me.Label19.Text = "Unit Cost"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(260, 235)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 20
        Me.cmdClear.Text = "Clear Lines"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitCost.Location = New System.Drawing.Point(183, 169)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(148, 20)
        Me.txtUnitCost.TabIndex = 17
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(18, 140)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 20)
        Me.Label21.TabIndex = 85
        Me.Label21.Text = "Quantity"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantity.Location = New System.Drawing.Point(183, 140)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtQuantity.TabIndex = 16
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdEnterLine
        '
        Me.cmdEnterLine.Location = New System.Drawing.Point(183, 236)
        Me.cmdEnterLine.Name = "cmdEnterLine"
        Me.cmdEnterLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnterLine.TabIndex = 19
        Me.cmdEnterLine.Text = "Enter Line"
        Me.cmdEnterLine.UseVisualStyleBackColor = True
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLongDescription.Location = New System.Drawing.Point(18, 73)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(313, 58)
        Me.txtLongDescription.TabIndex = 15
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboItemID
        '
        Me.cboItemID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemID.DataSource = Me.NonInventoryItemListBindingSource
        Me.cboItemID.DisplayMember = "ItemID"
        Me.cboItemID.FormattingEnabled = True
        Me.cboItemID.Location = New System.Drawing.Point(109, 22)
        Me.cboItemID.Name = "cboItemID"
        Me.cboItemID.Size = New System.Drawing.Size(222, 21)
        Me.cboItemID.TabIndex = 14
        '
        'NonInventoryItemListBindingSource
        '
        Me.NonInventoryItemListBindingSource.DataMember = "NonInventoryItemList"
        Me.NonInventoryItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 20)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "Description"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(18, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(124, 20)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Item"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDivisionID
        '
        Me.txtDivisionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDivisionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDivisionID.Enabled = False
        Me.txtDivisionID.Location = New System.Drawing.Point(148, 55)
        Me.txtDivisionID.Name = "txtDivisionID"
        Me.txtDivisionID.Size = New System.Drawing.Size(164, 20)
        Me.txtDivisionID.TabIndex = 0
        Me.txtDivisionID.TabStop = False
        Me.txtDivisionID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchNumber.Enabled = False
        Me.txtBatchNumber.Location = New System.Drawing.Point(148, 29)
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.Size = New System.Drawing.Size(164, 20)
        Me.txtBatchNumber.TabIndex = 0
        Me.txtBatchNumber.TabStop = False
        Me.txtBatchNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 20)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Batch Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 20)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Division ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtBatchNumber)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtDivisionID)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(329, 95)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Batch Information"
        '
        'dgvVoucherLines
        '
        Me.dgvVoucherLines.AllowUserToAddRows = False
        Me.dgvVoucherLines.AllowUserToDeleteRows = False
        Me.dgvVoucherLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVoucherLines.AutoGenerateColumns = False
        Me.dgvVoucherLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvVoucherLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvVoucherLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVoucherLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VoucherNumberColumn, Me.VoucherLineColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn})
        Me.dgvVoucherLines.DataSource = Me.ReceiptOfInvoiceVoucherLinesBindingSource
        Me.dgvVoucherLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvVoucherLines.Location = New System.Drawing.Point(379, 41)
        Me.dgvVoucherLines.Name = "dgvVoucherLines"
        Me.dgvVoucherLines.Size = New System.Drawing.Size(751, 406)
        Me.dgvVoucherLines.TabIndex = 34
        Me.dgvVoucherLines.TabStop = False
        '
        'VoucherNumberColumn
        '
        Me.VoucherNumberColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn.HeaderText = "VoucherNumber"
        Me.VoucherNumberColumn.Name = "VoucherNumberColumn"
        Me.VoucherNumberColumn.Visible = False
        '
        'VoucherLineColumn
        '
        Me.VoucherLineColumn.DataPropertyName = "VoucherLine"
        Me.VoucherLineColumn.HeaderText = "Line #"
        Me.VoucherLineColumn.Name = "VoucherLineColumn"
        Me.VoucherLineColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Item"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.Width = 120
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 165
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Width = 80
        '
        'GLDebitAccountColumn
        '
        Me.GLDebitAccountColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountColumn.HeaderText = "GL Debit Account"
        Me.GLDebitAccountColumn.Name = "GLDebitAccountColumn"
        '
        'GLCreditAccountColumn
        '
        Me.GLCreditAccountColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountColumn.HeaderText = "GL Credit Account"
        Me.GLCreditAccountColumn.Name = "GLCreditAccountColumn"
        '
        'ReceiptOfInvoiceVoucherLinesBindingSource
        '
        Me.ReceiptOfInvoiceVoucherLinesBindingSource.DataMember = "ReceiptOfInvoiceVoucherLines"
        Me.ReceiptOfInvoiceVoucherLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ReceiptOfInvoiceVoucherLinesTableAdapter
        '
        Me.ReceiptOfInvoiceVoucherLinesTableAdapter.ClearBeforeFill = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.chkManualDiscount)
        Me.GroupBox4.Controls.Add(Me.txtDiscountAmount)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtInvoiceTotal)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txtSalesTaxTotal)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txtFreightTotal)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txtPurchaseTotal)
        Me.GroupBox4.Location = New System.Drawing.Point(828, 589)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(302, 166)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Totals"
        '
        'chkManualDiscount
        '
        Me.chkManualDiscount.AutoSize = True
        Me.chkManualDiscount.Location = New System.Drawing.Point(117, 137)
        Me.chkManualDiscount.Name = "chkManualDiscount"
        Me.chkManualDiscount.Size = New System.Drawing.Size(15, 14)
        Me.chkManualDiscount.TabIndex = 88
        Me.chkManualDiscount.UseVisualStyleBackColor = True
        '
        'txtDiscountAmount
        '
        Me.txtDiscountAmount.BackColor = System.Drawing.Color.White
        Me.txtDiscountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiscountAmount.Enabled = False
        Me.txtDiscountAmount.Location = New System.Drawing.Point(147, 132)
        Me.txtDiscountAmount.Name = "txtDiscountAmount"
        Me.txtDiscountAmount.Size = New System.Drawing.Size(137, 20)
        Me.txtDiscountAmount.TabIndex = 86
        Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(14, 134)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 20)
        Me.Label24.TabIndex = 85
        Me.Label24.Text = "Discount Available"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(14, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Invoice Amount"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceTotal
        '
        Me.txtInvoiceTotal.BackColor = System.Drawing.Color.White
        Me.txtInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceTotal.Enabled = False
        Me.txtInvoiceTotal.Location = New System.Drawing.Point(147, 105)
        Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
        Me.txtInvoiceTotal.Size = New System.Drawing.Size(137, 20)
        Me.txtInvoiceTotal.TabIndex = 31
        Me.txtInvoiceTotal.TabStop = False
        Me.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Sales Tax"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTaxTotal
        '
        Me.txtSalesTaxTotal.BackColor = System.Drawing.Color.White
        Me.txtSalesTaxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTaxTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTaxTotal.Location = New System.Drawing.Point(147, 78)
        Me.txtSalesTaxTotal.Name = "txtSalesTaxTotal"
        Me.txtSalesTaxTotal.Size = New System.Drawing.Size(137, 20)
        Me.txtSalesTaxTotal.TabIndex = 30
        Me.txtSalesTaxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Freight"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BackColor = System.Drawing.Color.White
        Me.txtFreightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightTotal.Location = New System.Drawing.Point(147, 51)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.Size = New System.Drawing.Size(137, 20)
        Me.txtFreightTotal.TabIndex = 29
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(14, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Purchase Amount"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPurchaseTotal
        '
        Me.txtPurchaseTotal.BackColor = System.Drawing.Color.White
        Me.txtPurchaseTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseTotal.Enabled = False
        Me.txtPurchaseTotal.Location = New System.Drawing.Point(147, 24)
        Me.txtPurchaseTotal.Name = "txtPurchaseTotal"
        Me.txtPurchaseTotal.Size = New System.Drawing.Size(137, 20)
        Me.txtPurchaseTotal.TabIndex = 28
        Me.txtPurchaseTotal.TabStop = False
        Me.txtPurchaseTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboDebitAccount
        '
        Me.cboDebitAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDebitAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDebitAccount.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ItemClassBindingSource, "GLPurchasesAccount", True))
        Me.cboDebitAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboDebitAccount.DisplayMember = "GLAccountNumber"
        Me.cboDebitAccount.FormattingEnabled = True
        Me.cboDebitAccount.Location = New System.Drawing.Point(102, 28)
        Me.cboDebitAccount.Name = "cboDebitAccount"
        Me.cboDebitAccount.Size = New System.Drawing.Size(182, 21)
        Me.cboDebitAccount.TabIndex = 23
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(20, 29)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 20)
        Me.Label22.TabIndex = 85
        Me.Label22.Text = "Debit Account"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.cboDebitDescription)
        Me.GroupBox5.Controls.Add(Me.cboDebitAccount)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Location = New System.Drawing.Point(828, 471)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(302, 100)
        Me.GroupBox5.TabIndex = 23
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GL Account Information"
        '
        'cboDebitDescription
        '
        Me.cboDebitDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDebitDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDebitDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboDebitDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboDebitDescription.FormattingEnabled = True
        Me.cboDebitDescription.Location = New System.Drawing.Point(23, 56)
        Me.cboDebitDescription.Name = "cboDebitDescription"
        Me.cboDebitDescription.Size = New System.Drawing.Size(261, 21)
        Me.cboDebitDescription.TabIndex = 24
        '
        'cboCreditDescription
        '
        Me.cboCreditDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCreditDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCreditDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCreditDescription.DataSource = Me.GLAccountsBindingSource1
        Me.cboCreditDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboCreditDescription.Enabled = False
        Me.cboCreditDescription.FormattingEnabled = True
        Me.cboCreditDescription.Location = New System.Drawing.Point(851, 524)
        Me.cboCreditDescription.Name = "cboCreditDescription"
        Me.cboCreditDescription.Size = New System.Drawing.Size(261, 21)
        Me.cboCreditDescription.TabIndex = 26
        '
        'GLAccountsBindingSource1
        '
        Me.GLAccountsBindingSource1.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCreditAccount
        '
        Me.cboCreditAccount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCreditAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCreditAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCreditAccount.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ItemClassBindingSource, "GLPurchasesAccount", True))
        Me.cboCreditAccount.DataSource = Me.GLAccountsBindingSource1
        Me.cboCreditAccount.DisplayMember = "GLAccountNumber"
        Me.cboCreditAccount.Enabled = False
        Me.cboCreditAccount.FormattingEnabled = True
        Me.cboCreditAccount.Location = New System.Drawing.Point(930, 497)
        Me.cboCreditAccount.Name = "cboCreditAccount"
        Me.cboCreditAccount.Size = New System.Drawing.Size(182, 21)
        Me.cboCreditAccount.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(848, 498)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 87
        Me.Label9.Text = "Credit Account"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdEnterVoucher
        '
        Me.cmdEnterVoucher.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEnterVoucher.Location = New System.Drawing.Point(383, 771)
        Me.cmdEnterVoucher.Name = "cmdEnterVoucher"
        Me.cmdEnterVoucher.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnterVoucher.TabIndex = 21
        Me.cmdEnterVoucher.Text = "Enter New Voucher"
        Me.cmdEnterVoucher.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(464, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 22
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'ReceiptTransactionDescriptionTableAdapter
        '
        Me.ReceiptTransactionDescriptionTableAdapter.ClearBeforeFill = True
        '
        'ReceiptOfInvoiceBatchLineTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'NonInventoryItemListTableAdapter
        '
        Me.NonInventoryItemListTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'PaymentTermsTableAdapter
        '
        Me.PaymentTermsTableAdapter.ClearBeforeFill = True
        '
        'gpxVendorAddress
        '
        Me.gpxVendorAddress.Controls.Add(Me.cmdUpdateVendor)
        Me.gpxVendorAddress.Controls.Add(Me.cmdReturnToMain)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToZip)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToState)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToCountry)
        Me.gpxVendorAddress.Controls.Add(Me.Label30)
        Me.gpxVendorAddress.Controls.Add(Me.Label29)
        Me.gpxVendorAddress.Controls.Add(Me.Label28)
        Me.gpxVendorAddress.Controls.Add(Me.Label26)
        Me.gpxVendorAddress.Controls.Add(Me.Label23)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToCity)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToAddress2)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToAddress1)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToVendorID)
        Me.gpxVendorAddress.Controls.Add(Me.Label11)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToVendorName)
        Me.gpxVendorAddress.Controls.Add(Me.Label27)
        Me.gpxVendorAddress.Location = New System.Drawing.Point(29, 151)
        Me.gpxVendorAddress.Name = "gpxVendorAddress"
        Me.gpxVendorAddress.Size = New System.Drawing.Size(329, 469)
        Me.gpxVendorAddress.TabIndex = 37
        Me.gpxVendorAddress.TabStop = False
        Me.gpxVendorAddress.Text = "Vendor Remit To Address"
        Me.gpxVendorAddress.Visible = False
        '
        'cmdUpdateVendor
        '
        Me.cmdUpdateVendor.Location = New System.Drawing.Point(164, 413)
        Me.cmdUpdateVendor.Name = "cmdUpdateVendor"
        Me.cmdUpdateVendor.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateVendor.TabIndex = 45
        Me.cmdUpdateVendor.Text = "Update Vendor"
        Me.cmdUpdateVendor.UseVisualStyleBackColor = True
        '
        'cmdReturnToMain
        '
        Me.cmdReturnToMain.Location = New System.Drawing.Point(241, 413)
        Me.cmdReturnToMain.Name = "cmdReturnToMain"
        Me.cmdReturnToMain.Size = New System.Drawing.Size(71, 40)
        Me.cmdReturnToMain.TabIndex = 46
        Me.cmdReturnToMain.Text = "Return To Main"
        Me.cmdReturnToMain.UseVisualStyleBackColor = True
        '
        'txtRemitToZip
        '
        Me.txtRemitToZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemitToZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemitToZip.Location = New System.Drawing.Point(209, 333)
        Me.txtRemitToZip.Name = "txtRemitToZip"
        Me.txtRemitToZip.Size = New System.Drawing.Size(103, 20)
        Me.txtRemitToZip.TabIndex = 43
        Me.txtRemitToZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRemitToState
        '
        Me.txtRemitToState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemitToState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemitToState.Location = New System.Drawing.Point(88, 333)
        Me.txtRemitToState.Name = "txtRemitToState"
        Me.txtRemitToState.Size = New System.Drawing.Size(70, 20)
        Me.txtRemitToState.TabIndex = 42
        Me.txtRemitToState.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRemitToCountry
        '
        Me.txtRemitToCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemitToCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemitToCountry.Location = New System.Drawing.Point(88, 367)
        Me.txtRemitToCountry.Name = "txtRemitToCountry"
        Me.txtRemitToCountry.Size = New System.Drawing.Size(224, 20)
        Me.txtRemitToCountry.TabIndex = 44
        Me.txtRemitToCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(21, 333)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(69, 20)
        Me.Label30.TabIndex = 88
        Me.Label30.Text = "State"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(175, 333)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(28, 20)
        Me.Label29.TabIndex = 87
        Me.Label29.Text = "Zip"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(21, 367)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(69, 20)
        Me.Label28.TabIndex = 86
        Me.Label28.Text = "Country"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(21, 212)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(124, 20)
        Me.Label26.TabIndex = 84
        Me.Label26.Text = "Address 2"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(21, 125)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(124, 20)
        Me.Label23.TabIndex = 83
        Me.Label23.Text = "Address 1"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRemitToCity
        '
        Me.txtRemitToCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemitToCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemitToCity.Location = New System.Drawing.Point(88, 299)
        Me.txtRemitToCity.Name = "txtRemitToCity"
        Me.txtRemitToCity.Size = New System.Drawing.Size(224, 20)
        Me.txtRemitToCity.TabIndex = 41
        Me.txtRemitToCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRemitToAddress2
        '
        Me.txtRemitToAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemitToAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemitToAddress2.Location = New System.Drawing.Point(21, 235)
        Me.txtRemitToAddress2.Multiline = True
        Me.txtRemitToAddress2.Name = "txtRemitToAddress2"
        Me.txtRemitToAddress2.Size = New System.Drawing.Size(291, 50)
        Me.txtRemitToAddress2.TabIndex = 40
        Me.txtRemitToAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRemitToAddress1
        '
        Me.txtRemitToAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemitToAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemitToAddress1.Location = New System.Drawing.Point(21, 148)
        Me.txtRemitToAddress1.Multiline = True
        Me.txtRemitToAddress1.Name = "txtRemitToAddress1"
        Me.txtRemitToAddress1.Size = New System.Drawing.Size(291, 50)
        Me.txtRemitToAddress1.TabIndex = 39
        Me.txtRemitToAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRemitToVendorID
        '
        Me.txtRemitToVendorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemitToVendorID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemitToVendorID.Enabled = False
        Me.txtRemitToVendorID.Location = New System.Drawing.Point(93, 30)
        Me.txtRemitToVendorID.Name = "txtRemitToVendorID"
        Me.txtRemitToVendorID.Size = New System.Drawing.Size(216, 20)
        Me.txtRemitToVendorID.TabIndex = 37
        Me.txtRemitToVendorID.TabStop = False
        Me.txtRemitToVendorID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(18, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 20)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "Vendor"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRemitToVendorName
        '
        Me.txtRemitToVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemitToVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemitToVendorName.Location = New System.Drawing.Point(21, 64)
        Me.txtRemitToVendorName.Multiline = True
        Me.txtRemitToVendorName.Name = "txtRemitToVendorName"
        Me.txtRemitToVendorName.Size = New System.Drawing.Size(291, 43)
        Me.txtRemitToVendorName.TabIndex = 38
        Me.txtRemitToVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(21, 297)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(69, 20)
        Me.Label27.TabIndex = 85
        Me.Label27.Text = "City"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VendorClassTableAdapter
        '
        Me.VendorClassTableAdapter.ClearBeforeFill = True
        '
        'cboVoucherLine
        '
        Me.cboVoucherLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVoucherLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVoucherLine.DataSource = Me.ReceiptOfInvoiceVoucherLinesBindingSource
        Me.cboVoucherLine.DisplayMember = "VoucherLine"
        Me.cboVoucherLine.FormattingEnabled = True
        Me.cboVoucherLine.Location = New System.Drawing.Point(197, 26)
        Me.cboVoucherLine.Name = "cboVoucherLine"
        Me.cboVoucherLine.Size = New System.Drawing.Size(125, 21)
        Me.cboVoucherLine.TabIndex = 37
        '
        'tabLineControls
        '
        Me.tabLineControls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabLineControls.Controls.Add(Me.tabEnterNew)
        Me.tabLineControls.Controls.Add(Me.tabDeleteLine)
        Me.tabLineControls.Location = New System.Drawing.Point(379, 453)
        Me.tabLineControls.Name = "tabLineControls"
        Me.tabLineControls.SelectedIndex = 0
        Me.tabLineControls.Size = New System.Drawing.Size(361, 302)
        Me.tabLineControls.TabIndex = 89
        '
        'tabEnterNew
        '
        Me.tabEnterNew.Controls.Add(Me.Label18)
        Me.tabEnterNew.Controls.Add(Me.cboItemID)
        Me.tabEnterNew.Controls.Add(Me.txtExtendedAmount)
        Me.tabEnterNew.Controls.Add(Me.cmdClear)
        Me.tabEnterNew.Controls.Add(Me.txtUnitCost)
        Me.tabEnterNew.Controls.Add(Me.Label12)
        Me.tabEnterNew.Controls.Add(Me.cmdEnterLine)
        Me.tabEnterNew.Controls.Add(Me.txtQuantity)
        Me.tabEnterNew.Controls.Add(Me.Label19)
        Me.tabEnterNew.Controls.Add(Me.txtLongDescription)
        Me.tabEnterNew.Controls.Add(Me.Label21)
        Me.tabEnterNew.Controls.Add(Me.Label13)
        Me.tabEnterNew.Location = New System.Drawing.Point(4, 22)
        Me.tabEnterNew.Name = "tabEnterNew"
        Me.tabEnterNew.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEnterNew.Size = New System.Drawing.Size(353, 276)
        Me.tabEnterNew.TabIndex = 0
        Me.tabEnterNew.Text = "Enter Lines"
        Me.tabEnterNew.UseVisualStyleBackColor = True
        '
        'tabDeleteLine
        '
        Me.tabDeleteLine.Controls.Add(Me.Label34)
        Me.tabDeleteLine.Controls.Add(Me.cmdDeleteLine)
        Me.tabDeleteLine.Controls.Add(Me.txtLinePartDescription)
        Me.tabDeleteLine.Controls.Add(Me.txtLinePartNumber)
        Me.tabDeleteLine.Controls.Add(Me.cboVoucherLine)
        Me.tabDeleteLine.Controls.Add(Me.Label32)
        Me.tabDeleteLine.Controls.Add(Me.Label33)
        Me.tabDeleteLine.Location = New System.Drawing.Point(4, 22)
        Me.tabDeleteLine.Name = "tabDeleteLine"
        Me.tabDeleteLine.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDeleteLine.Size = New System.Drawing.Size(353, 276)
        Me.tabDeleteLine.TabIndex = 1
        Me.tabDeleteLine.Text = "Delete Line"
        Me.tabDeleteLine.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(20, 219)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(290, 46)
        Me.Label34.TabIndex = 94
        Me.Label34.Text = "To delete a line from the voucher, select the line in the datagrid or from the dr" & _
            "op down box and press ""Delete""."
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Location = New System.Drawing.Point(251, 182)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteLine.TabIndex = 40
        Me.cmdDeleteLine.Text = "Delete"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'txtLinePartDescription
        '
        Me.txtLinePartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinePartDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinePartDescription.Location = New System.Drawing.Point(21, 98)
        Me.txtLinePartDescription.Multiline = True
        Me.txtLinePartDescription.Name = "txtLinePartDescription"
        Me.txtLinePartDescription.Size = New System.Drawing.Size(301, 65)
        Me.txtLinePartDescription.TabIndex = 39
        Me.txtLinePartDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLinePartNumber
        '
        Me.txtLinePartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinePartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinePartNumber.Location = New System.Drawing.Point(87, 64)
        Me.txtLinePartNumber.Name = "txtLinePartNumber"
        Me.txtLinePartNumber.Size = New System.Drawing.Size(235, 20)
        Me.txtLinePartNumber.TabIndex = 38
        Me.txtLinePartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(21, 27)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(112, 20)
        Me.Label32.TabIndex = 89
        Me.Label32.Text = "Voucher Line #"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(21, 64)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(112, 20)
        Me.Label33.TabIndex = 92
        Me.Label33.Text = "Item ID"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'APProcessVouchers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.lblCheckCode)
        Me.Controls.Add(Me.tabLineControls)
        Me.Controls.Add(Me.cmdEnterVoucher)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.dgvVoucherLines)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cboCreditDescription)
        Me.Controls.Add(Me.cboCreditAccount)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.gpxVoucherHeader)
        Me.Controls.Add(Me.gpxVendorAddress)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "APProcessVouchers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Process Vouchers Program"
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptTransactionDescriptionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxVoucherHeader.ResumeLayout(False)
        Me.gpxVoucherHeader.PerformLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.GLAccountsBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxVendorAddress.ResumeLayout(False)
        Me.gpxVendorAddress.PerformLayout()
        Me.tabLineControls.ResumeLayout(False)
        Me.tabEnterNew.ResumeLayout(False)
        Me.tabEnterNew.PerformLayout()
        Me.tabDeleteLine.ResumeLayout(False)
        Me.tabDeleteLine.PerformLayout()
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
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateVoucher As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboVoucherNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents gpxVoucherHeader As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDivisionID As System.Windows.Forms.TextBox
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceAmount As System.Windows.Forms.TextBox
    Friend WithEvents dgvVoucherLines As System.Windows.Forms.DataGridView
    Friend WithEvents ReceiptOfInvoiceVoucherLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceVoucherLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSalesTaxTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFreightTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPurchaseTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboItemID As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnterLine As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboDebitAccount As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdEnterVoucher As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents ReceiptTransactionDescriptionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptTransactionDescriptionTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptTransactionDescriptionTableAdapter
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents NonInventoryItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NonInventoryItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents PaymentTermsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PaymentTermsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboCreditAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GLAccountsBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents cboCreditDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDebitDescription As System.Windows.Forms.ComboBox
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents chkManualDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents llRemitToAddress As System.Windows.Forms.LinkLabel
    Friend WithEvents gpxVendorAddress As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtRemitToCity As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToVendorID As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRemitToVendorName As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtRemitToZip As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToState As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToCountry As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdateVendor As System.Windows.Forms.Button
    Friend WithEvents cmdReturnToMain As System.Windows.Forms.Button
    Friend WithEvents dtpInvoiceDateDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReceiptDateDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDueDateDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDiscountDateDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents VendorClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
    Friend WithEvents cboVoucherLine As System.Windows.Forms.ComboBox
    Friend WithEvents tabLineControls As System.Windows.Forms.TabControl
    Friend WithEvents tabEnterNew As System.Windows.Forms.TabPage
    Friend WithEvents tabDeleteLine As System.Windows.Forms.TabPage
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtLinePartDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtLinePartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpReceiptDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDiscountDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDueDate As System.Windows.Forms.TextBox
    Friend WithEvents chkWhitePaper As System.Windows.Forms.CheckBox
    Friend WithEvents chkOnHold As System.Windows.Forms.CheckBox
    Friend WithEvents lblCheckCode As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboCheckType As System.Windows.Forms.ComboBox
End Class
