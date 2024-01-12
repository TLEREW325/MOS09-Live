<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APReceiptOfInvoice
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadPackingSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadPackingSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendUploadedPackingSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.ReceivingLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.ReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.gpxBatchInfo = New System.Windows.Forms.GroupBox
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDivisionID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTermDiscount = New System.Windows.Forms.TextBox
        Me.txtSalesTaxTotal = New System.Windows.Forms.TextBox
        Me.txtPurchaseTotal = New System.Windows.Forms.TextBox
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.txtInvoiceTotal = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.gpxInvoiceTotals = New System.Windows.Forms.GroupBox
        Me.chkManualDiscount = New System.Windows.Forms.CheckBox
        Me.cmdSelectByPO = New System.Windows.Forms.Button
        Me.ReceiptOfInvoiceVoucherLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceiptOfInvoiceVoucherLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
        Me.gpxVoucherHeader = New System.Windows.Forms.GroupBox
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.PaymentTermsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label39 = New System.Windows.Forms.Label
        Me.cboCheckType = New System.Windows.Forms.ComboBox
        Me.chkOnHold = New System.Windows.Forms.CheckBox
        Me.chkWhitePaper = New System.Windows.Forms.CheckBox
        Me.dtpReceiptDateDD = New System.Windows.Forms.DateTimePicker
        Me.dtpDiscountDateDD = New System.Windows.Forms.DateTimePicker
        Me.dtpDueDateDD = New System.Windows.Forms.DateTimePicker
        Me.dtpDueDate = New System.Windows.Forms.TextBox
        Me.dtpReceiptDate = New System.Windows.Forms.TextBox
        Me.dtpInvoiceDateDD = New System.Windows.Forms.DateTimePicker
        Me.dtpDiscountDate = New System.Windows.Forms.TextBox
        Me.dtpInvoiceDate = New System.Windows.Forms.TextBox
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.VendorClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtInvoiceAmount = New System.Windows.Forms.TextBox
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.llVendorID = New System.Windows.Forms.LinkLabel
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cmdGenerateVoucher = New System.Windows.Forms.Button
        Me.cboVoucherNumber = New System.Windows.Forms.ComboBox
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ReceiptTransactionDescriptionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceiptTransactionDescriptionTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptTransactionDescriptionTableAdapter
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.PaymentTermsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.NonInventoryItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.dgvVoucherLines = New System.Windows.Forms.DataGridView
        Me.gpxSelectLines = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.ReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.cboVoucherLineNumber = New System.Windows.Forms.ComboBox
        Me.cmdEnterVoucher = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.tabVoucherLines = New System.Windows.Forms.TabControl
        Me.tabVoucherLineItems = New System.Windows.Forms.TabPage
        Me.tabAddNew = New System.Windows.Forms.TabPage
        Me.Label28 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnterLine = New System.Windows.Forms.Button
        Me.cboDebitDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDebitAccount = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.NonInventoryItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.gpxVendorAddress = New System.Windows.Forms.GroupBox
        Me.txtRemitToAddress2 = New System.Windows.Forms.TextBox
        Me.cmdUpdateVendor = New System.Windows.Forms.Button
        Me.cmdReturnToMain = New System.Windows.Forms.Button
        Me.txtRemitToZip = New System.Windows.Forms.TextBox
        Me.txtRemitToState = New System.Windows.Forms.TextBox
        Me.txtRemitToCountry = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtRemitToCity = New System.Windows.Forms.TextBox
        Me.txtRemitToAddress1 = New System.Windows.Forms.TextBox
        Me.txtRemitToVendorID = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtRemitToVendorName = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.VendorClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
        Me.cmdSelectMultiple = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtTaxOnPO = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txtFreightVouched = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.txtFreightOnPO = New System.Windows.Forms.TextBox
        Me.cmdViewPackingSlip = New System.Windows.Forms.Button
        Me.ReceivingLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineQueryTableAdapter
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxBatchInfo.SuspendLayout()
        Me.gpxInvoiceTotals.SuspendLayout()
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxVoucherHeader.SuspendLayout()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptTransactionDescriptionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxSelectLines.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabVoucherLines.SuspendLayout()
        Me.tabVoucherLineItems.SuspendLayout()
        Me.tabAddNew.SuspendLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxVendorAddress.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadPackingSlipToolStripMenuItem, Me.ReUploadPackingSlipToolStripMenuItem, Me.AppendUploadedPackingSlipToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'UploadPackingSlipToolStripMenuItem
        '
        Me.UploadPackingSlipToolStripMenuItem.Enabled = False
        Me.UploadPackingSlipToolStripMenuItem.Name = "UploadPackingSlipToolStripMenuItem"
        Me.UploadPackingSlipToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.UploadPackingSlipToolStripMenuItem.Text = "Upload Packing Slip"
        '
        'ReUploadPackingSlipToolStripMenuItem
        '
        Me.ReUploadPackingSlipToolStripMenuItem.Enabled = False
        Me.ReUploadPackingSlipToolStripMenuItem.Name = "ReUploadPackingSlipToolStripMenuItem"
        Me.ReUploadPackingSlipToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ReUploadPackingSlipToolStripMenuItem.Text = "Re-Upload Packing Slip"
        '
        'AppendUploadedPackingSlipToolStripMenuItem
        '
        Me.AppendUploadedPackingSlipToolStripMenuItem.Enabled = False
        Me.AppendUploadedPackingSlipToolStripMenuItem.Name = "AppendUploadedPackingSlipToolStripMenuItem"
        Me.AppendUploadedPackingSlipToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.AppendUploadedPackingSlipToolStripMenuItem.Text = "Append Uploaded Packing Slip"
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1058, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 29
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(809, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 26
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(892, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 27
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(975, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 28
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(6, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 20)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "PO Number"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.ReceivingLineQueryBindingSource
        Me.cboPONumber.DisplayMember = "PONumber"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(81, 28)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(177, 21)
        Me.cboPONumber.TabIndex = 17
        '
        'ReceivingLineQueryBindingSource
        '
        Me.ReceivingLineQueryBindingSource.DataMember = "ReceivingLineQuery"
        Me.ReceivingLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReceivingHeaderTableBindingSource
        '
        Me.ReceivingHeaderTableBindingSource.DataMember = "ReceivingHeaderTable"
        Me.ReceivingHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'gpxBatchInfo
        '
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchNumber)
        Me.gpxBatchInfo.Controls.Add(Me.Label1)
        Me.gpxBatchInfo.Controls.Add(Me.txtDivisionID)
        Me.gpxBatchInfo.Controls.Add(Me.Label3)
        Me.gpxBatchInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxBatchInfo.Name = "gpxBatchInfo"
        Me.gpxBatchInfo.Size = New System.Drawing.Size(329, 95)
        Me.gpxBatchInfo.TabIndex = 0
        Me.gpxBatchInfo.TabStop = False
        Me.gpxBatchInfo.Text = "Batch Information"
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
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 20)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Division ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTermDiscount
        '
        Me.txtTermDiscount.BackColor = System.Drawing.Color.White
        Me.txtTermDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTermDiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTermDiscount.Enabled = False
        Me.txtTermDiscount.Location = New System.Drawing.Point(158, 125)
        Me.txtTermDiscount.Name = "txtTermDiscount"
        Me.txtTermDiscount.Size = New System.Drawing.Size(148, 20)
        Me.txtTermDiscount.TabIndex = 25
        Me.txtTermDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalesTaxTotal
        '
        Me.txtSalesTaxTotal.BackColor = System.Drawing.Color.White
        Me.txtSalesTaxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTaxTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTaxTotal.Location = New System.Drawing.Point(158, 72)
        Me.txtSalesTaxTotal.Name = "txtSalesTaxTotal"
        Me.txtSalesTaxTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtSalesTaxTotal.TabIndex = 23
        Me.txtSalesTaxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPurchaseTotal
        '
        Me.txtPurchaseTotal.BackColor = System.Drawing.Color.White
        Me.txtPurchaseTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseTotal.Enabled = False
        Me.txtPurchaseTotal.Location = New System.Drawing.Point(158, 18)
        Me.txtPurchaseTotal.Name = "txtPurchaseTotal"
        Me.txtPurchaseTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtPurchaseTotal.TabIndex = 21
        Me.txtPurchaseTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BackColor = System.Drawing.Color.White
        Me.txtFreightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightTotal.Location = New System.Drawing.Point(158, 45)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtFreightTotal.TabIndex = 22
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInvoiceTotal
        '
        Me.txtInvoiceTotal.BackColor = System.Drawing.Color.White
        Me.txtInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceTotal.Enabled = False
        Me.txtInvoiceTotal.Location = New System.Drawing.Point(158, 99)
        Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
        Me.txtInvoiceTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtInvoiceTotal.TabIndex = 24
        Me.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(19, 125)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(103, 20)
        Me.Label23.TabIndex = 70
        Me.Label23.Text = "Discount Available"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(19, 72)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(85, 20)
        Me.Label22.TabIndex = 68
        Me.Label22.Text = "Sales Tax"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(19, 43)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(85, 20)
        Me.Label21.TabIndex = 66
        Me.Label21.Text = "Freight"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(19, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 20)
        Me.Label19.TabIndex = 64
        Me.Label19.Text = "Purchase Total"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(19, 99)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 20)
        Me.Label18.TabIndex = 62
        Me.Label18.Text = "Invoice Total"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxInvoiceTotals
        '
        Me.gpxInvoiceTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxInvoiceTotals.Controls.Add(Me.chkManualDiscount)
        Me.gpxInvoiceTotals.Controls.Add(Me.txtPurchaseTotal)
        Me.gpxInvoiceTotals.Controls.Add(Me.Label22)
        Me.gpxInvoiceTotals.Controls.Add(Me.Label21)
        Me.gpxInvoiceTotals.Controls.Add(Me.Label23)
        Me.gpxInvoiceTotals.Controls.Add(Me.Label19)
        Me.gpxInvoiceTotals.Controls.Add(Me.txtTermDiscount)
        Me.gpxInvoiceTotals.Controls.Add(Me.Label18)
        Me.gpxInvoiceTotals.Controls.Add(Me.txtSalesTaxTotal)
        Me.gpxInvoiceTotals.Controls.Add(Me.txtInvoiceTotal)
        Me.gpxInvoiceTotals.Controls.Add(Me.txtFreightTotal)
        Me.gpxInvoiceTotals.Location = New System.Drawing.Point(809, 600)
        Me.gpxInvoiceTotals.Name = "gpxInvoiceTotals"
        Me.gpxInvoiceTotals.Size = New System.Drawing.Size(321, 155)
        Me.gpxInvoiceTotals.TabIndex = 21
        Me.gpxInvoiceTotals.TabStop = False
        Me.gpxInvoiceTotals.Text = "Invoice Totals"
        '
        'chkManualDiscount
        '
        Me.chkManualDiscount.AutoSize = True
        Me.chkManualDiscount.Location = New System.Drawing.Point(128, 129)
        Me.chkManualDiscount.Name = "chkManualDiscount"
        Me.chkManualDiscount.Size = New System.Drawing.Size(15, 14)
        Me.chkManualDiscount.TabIndex = 67
        Me.chkManualDiscount.UseVisualStyleBackColor = True
        '
        'cmdSelectByPO
        '
        Me.cmdSelectByPO.Location = New System.Drawing.Point(298, 28)
        Me.cmdSelectByPO.Name = "cmdSelectByPO"
        Me.cmdSelectByPO.Size = New System.Drawing.Size(58, 25)
        Me.cmdSelectByPO.TabIndex = 18
        Me.cmdSelectByPO.Text = "Select"
        Me.cmdSelectByPO.UseVisualStyleBackColor = True
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
        'gpxVoucherHeader
        '
        Me.gpxVoucherHeader.Controls.Add(Me.cboPaymentTerms)
        Me.gpxVoucherHeader.Controls.Add(Me.Label39)
        Me.gpxVoucherHeader.Controls.Add(Me.cboCheckType)
        Me.gpxVoucherHeader.Controls.Add(Me.chkOnHold)
        Me.gpxVoucherHeader.Controls.Add(Me.chkWhitePaper)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpReceiptDateDD)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpDiscountDateDD)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpDueDateDD)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpDueDate)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpReceiptDate)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpInvoiceDateDD)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpDiscountDate)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpInvoiceDate)
        Me.gpxVoucherHeader.Controls.Add(Me.cboVendorClass)
        Me.gpxVoucherHeader.Controls.Add(Me.txtInvoiceAmount)
        Me.gpxVoucherHeader.Controls.Add(Me.txtInvoiceNumber)
        Me.gpxVoucherHeader.Controls.Add(Me.Label35)
        Me.gpxVoucherHeader.Controls.Add(Me.cboVendorID)
        Me.gpxVoucherHeader.Controls.Add(Me.llVendorID)
        Me.gpxVoucherHeader.Controls.Add(Me.Label25)
        Me.gpxVoucherHeader.Controls.Add(Me.Label4)
        Me.gpxVoucherHeader.Controls.Add(Me.Label2)
        Me.gpxVoucherHeader.Controls.Add(Me.Label24)
        Me.gpxVoucherHeader.Controls.Add(Me.txtComment)
        Me.gpxVoucherHeader.Controls.Add(Me.txtVendorName)
        Me.gpxVoucherHeader.Controls.Add(Me.cmdGenerateVoucher)
        Me.gpxVoucherHeader.Controls.Add(Me.cboVoucherNumber)
        Me.gpxVoucherHeader.Controls.Add(Me.Label5)
        Me.gpxVoucherHeader.Controls.Add(Me.Label20)
        Me.gpxVoucherHeader.Controls.Add(Me.Label17)
        Me.gpxVoucherHeader.Controls.Add(Me.Label16)
        Me.gpxVoucherHeader.Controls.Add(Me.Label8)
        Me.gpxVoucherHeader.Location = New System.Drawing.Point(29, 142)
        Me.gpxVoucherHeader.Name = "gpxVoucherHeader"
        Me.gpxVoucherHeader.Size = New System.Drawing.Size(329, 669)
        Me.gpxVoucherHeader.TabIndex = 1
        Me.gpxVoucherHeader.TabStop = False
        Me.gpxVoucherHeader.Text = "Voucher Header Information"
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.DataSource = Me.PaymentTermsBindingSource
        Me.cboPaymentTerms.DisplayMember = "PmtTermsID"
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Location = New System.Drawing.Point(127, 357)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(186, 21)
        Me.cboPaymentTerms.TabIndex = 11
        '
        'PaymentTermsBindingSource
        '
        Me.PaymentTermsBindingSource.DataMember = "PaymentTerms"
        Me.PaymentTermsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(21, 196)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(100, 20)
        Me.Label39.TabIndex = 81
        Me.Label39.Text = "Check Type"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCheckType
        '
        Me.cboCheckType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCheckType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCheckType.FormattingEnabled = True
        Me.cboCheckType.Items.AddRange(New Object() {"STANDARD", "FEDEX", "INTERCOMPANY", "ACH"})
        Me.cboCheckType.Location = New System.Drawing.Point(127, 196)
        Me.cboCheckType.Name = "cboCheckType"
        Me.cboCheckType.Size = New System.Drawing.Size(186, 21)
        Me.cboCheckType.TabIndex = 6
        '
        'chkOnHold
        '
        Me.chkOnHold.AutoSize = True
        Me.chkOnHold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOnHold.ForeColor = System.Drawing.Color.Blue
        Me.chkOnHold.Location = New System.Drawing.Point(24, 493)
        Me.chkOnHold.Name = "chkOnHold"
        Me.chkOnHold.Size = New System.Drawing.Size(229, 20)
        Me.chkOnHold.TabIndex = 15
        Me.chkOnHold.Text = "Check to place this ON HOLD"
        Me.chkOnHold.UseVisualStyleBackColor = True
        '
        'chkWhitePaper
        '
        Me.chkWhitePaper.AutoSize = True
        Me.chkWhitePaper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWhitePaper.ForeColor = System.Drawing.Color.Blue
        Me.chkWhitePaper.Location = New System.Drawing.Point(24, 458)
        Me.chkWhitePaper.Name = "chkWhitePaper"
        Me.chkWhitePaper.Size = New System.Drawing.Size(252, 20)
        Me.chkWhitePaper.TabIndex = 14
        Me.chkWhitePaper.Text = "Check if it is a white paper check"
        Me.chkWhitePaper.UseVisualStyleBackColor = True
        '
        'dtpReceiptDateDD
        '
        Me.dtpReceiptDateDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReceiptDateDD.Location = New System.Drawing.Point(294, 325)
        Me.dtpReceiptDateDD.Name = "dtpReceiptDateDD"
        Me.dtpReceiptDateDD.Size = New System.Drawing.Size(19, 20)
        Me.dtpReceiptDateDD.TabIndex = 9
        Me.dtpReceiptDateDD.TabStop = False
        '
        'dtpDiscountDateDD
        '
        Me.dtpDiscountDateDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDiscountDateDD.Location = New System.Drawing.Point(294, 392)
        Me.dtpDiscountDateDD.Name = "dtpDiscountDateDD"
        Me.dtpDiscountDateDD.Size = New System.Drawing.Size(19, 20)
        Me.dtpDiscountDateDD.TabIndex = 12
        Me.dtpDiscountDateDD.TabStop = False
        '
        'dtpDueDateDD
        '
        Me.dtpDueDateDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDueDateDD.Location = New System.Drawing.Point(294, 424)
        Me.dtpDueDateDD.Name = "dtpDueDateDD"
        Me.dtpDueDateDD.Size = New System.Drawing.Size(19, 20)
        Me.dtpDueDateDD.TabIndex = 11
        Me.dtpDueDateDD.TabStop = False
        '
        'dtpDueDate
        '
        Me.dtpDueDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpDueDate.Location = New System.Drawing.Point(127, 422)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(186, 20)
        Me.dtpDueDate.TabIndex = 13
        '
        'dtpReceiptDate
        '
        Me.dtpReceiptDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpReceiptDate.Location = New System.Drawing.Point(127, 325)
        Me.dtpReceiptDate.Name = "dtpReceiptDate"
        Me.dtpReceiptDate.Size = New System.Drawing.Size(186, 20)
        Me.dtpReceiptDate.TabIndex = 10
        '
        'dtpInvoiceDateDD
        '
        Me.dtpInvoiceDateDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInvoiceDateDD.Location = New System.Drawing.Point(294, 261)
        Me.dtpInvoiceDateDD.Name = "dtpInvoiceDateDD"
        Me.dtpInvoiceDateDD.Size = New System.Drawing.Size(19, 20)
        Me.dtpInvoiceDateDD.TabIndex = 7
        Me.dtpInvoiceDateDD.TabStop = False
        '
        'dtpDiscountDate
        '
        Me.dtpDiscountDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpDiscountDate.Location = New System.Drawing.Point(127, 390)
        Me.dtpDiscountDate.Name = "dtpDiscountDate"
        Me.dtpDiscountDate.Size = New System.Drawing.Size(186, 20)
        Me.dtpDiscountDate.TabIndex = 12
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(127, 261)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(186, 20)
        Me.dtpInvoiceDate.TabIndex = 8
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.DataSource = Me.VendorClassBindingSource
        Me.cboVendorClass.DisplayMember = "VendClassID"
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(127, 163)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(186, 21)
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
        Me.txtInvoiceAmount.Location = New System.Drawing.Point(127, 293)
        Me.txtInvoiceAmount.Name = "txtInvoiceAmount"
        Me.txtInvoiceAmount.Size = New System.Drawing.Size(186, 20)
        Me.txtInvoiceAmount.TabIndex = 9
        Me.txtInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(127, 229)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(186, 20)
        Me.txtInvoiceNumber.TabIndex = 7
        Me.txtInvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(21, 163)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(100, 20)
        Me.Label35.TabIndex = 79
        Me.Label35.Text = "Vendor Class"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(93, 55)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(219, 21)
        Me.cboVendorID.TabIndex = 3
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'llVendorID
        '
        Me.llVendorID.Location = New System.Drawing.Point(20, 55)
        Me.llVendorID.Name = "llVendorID"
        Me.llVendorID.Size = New System.Drawing.Size(100, 23)
        Me.llVendorID.TabIndex = 67
        Me.llVendorID.TabStop = True
        Me.llVendorID.Text = "Vendor ID"
        Me.llVendorID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(21, 422)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(100, 20)
        Me.Label25.TabIndex = 77
        Me.Label25.Text = "Due Date"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(21, 293)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Invoice Amount"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 529)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 20)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Voucher Comment"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(21, 390)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 20)
        Me.Label24.TabIndex = 35
        Me.Label24.Text = "Discount Date"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(22, 552)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(291, 108)
        Me.txtComment.TabIndex = 16
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorName.Location = New System.Drawing.Point(20, 86)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(291, 67)
        Me.txtVendorName.TabIndex = 4
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGenerateVoucher
        '
        Me.cmdGenerateVoucher.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateVoucher.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateVoucher.Location = New System.Drawing.Point(116, 25)
        Me.cmdGenerateVoucher.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateVoucher.Name = "cmdGenerateVoucher"
        Me.cmdGenerateVoucher.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateVoucher.TabIndex = 2
        Me.cmdGenerateVoucher.TabStop = False
        Me.cmdGenerateVoucher.Text = ">>"
        Me.cmdGenerateVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateVoucher.UseVisualStyleBackColor = False
        '
        'cboVoucherNumber
        '
        Me.cboVoucherNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVoucherNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVoucherNumber.DataSource = Me.ReceiptOfInvoiceBatchLineBindingSource
        Me.cboVoucherNumber.DisplayMember = "VoucherNumber"
        Me.cboVoucherNumber.FormattingEnabled = True
        Me.cboVoucherNumber.Location = New System.Drawing.Point(148, 25)
        Me.cboVoucherNumber.Name = "cboVoucherNumber"
        Me.cboVoucherNumber.Size = New System.Drawing.Size(164, 21)
        Me.cboVoucherNumber.TabIndex = 2
        '
        'ReceiptOfInvoiceBatchLineBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataMember = "ReceiptOfInvoiceBatchLine"
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Voucher Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(21, 260)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 20)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "Invoice Date"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(21, 326)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 20)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "Receipt Date"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(21, 358)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 20)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Payment Terms"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(21, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Invoice Number"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ReceiptTransactionDescriptionBindingSource
        '
        Me.ReceiptTransactionDescriptionBindingSource.DataMember = "ReceiptTransactionDescription"
        Me.ReceiptTransactionDescriptionBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
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
        'PaymentTermsTableAdapter
        '
        Me.PaymentTermsTableAdapter.ClearBeforeFill = True
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedAmount.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReceiptOfInvoiceVoucherLinesBindingSource, "ExtendedAmount", True))
        Me.txtExtendedAmount.Location = New System.Drawing.Point(154, 244)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtExtendedAmount.TabIndex = 30
        Me.txtExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.NonInventoryItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(105, 41)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(197, 21)
        Me.cboPartNumber.TabIndex = 26
        '
        'NonInventoryItemListBindingSource
        '
        Me.NonInventoryItemListBindingSource.DataMember = "NonInventoryItemList"
        Me.NonInventoryItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(24, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 20)
        Me.Label15.TabIndex = 95
        Me.Label15.Text = "Item"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(24, 66)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(124, 20)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Description"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitCost.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReceiptOfInvoiceVoucherLinesBindingSource, "UnitCost", True))
        Me.txtUnitCost.Location = New System.Drawing.Point(154, 214)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(148, 20)
        Me.txtUnitCost.TabIndex = 29
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLongDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReceiptOfInvoiceVoucherLinesBindingSource, "PartDescription", True))
        Me.txtLongDescription.Location = New System.Drawing.Point(27, 89)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(275, 72)
        Me.txtLongDescription.TabIndex = 27
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantity.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReceiptOfInvoiceVoucherLinesBindingSource, "Quantity", True))
        Me.txtQuantity.Location = New System.Drawing.Point(154, 184)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtQuantity.TabIndex = 28
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(24, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 99
        Me.Label9.Text = "Extended Cost"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(24, 214)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 20)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "Unit Cost"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(24, 184)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "Quantity"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvVoucherLines
        '
        Me.dgvVoucherLines.AllowUserToAddRows = False
        Me.dgvVoucherLines.AllowUserToDeleteRows = False
        Me.dgvVoucherLines.AutoGenerateColumns = False
        Me.dgvVoucherLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvVoucherLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvVoucherLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvVoucherLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVoucherLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VoucherNumberColumn, Me.VoucherLineColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn, Me.ReceiverNumberColumn, Me.ReceiverLineColumn})
        Me.dgvVoucherLines.DataSource = Me.ReceiptOfInvoiceVoucherLinesBindingSource
        Me.dgvVoucherLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvVoucherLines.Location = New System.Drawing.Point(0, 0)
        Me.dgvVoucherLines.Name = "dgvVoucherLines"
        Me.dgvVoucherLines.Size = New System.Drawing.Size(740, 414)
        Me.dgvVoucherLines.TabIndex = 33
        Me.dgvVoucherLines.TabStop = False
        '
        'gpxSelectLines
        '
        Me.gpxSelectLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxSelectLines.Controls.Add(Me.cboPONumber)
        Me.gpxSelectLines.Controls.Add(Me.Label12)
        Me.gpxSelectLines.Controls.Add(Me.Label7)
        Me.gpxSelectLines.Controls.Add(Me.cmdSelectByPO)
        Me.gpxSelectLines.Location = New System.Drawing.Point(379, 27)
        Me.gpxSelectLines.Name = "gpxSelectLines"
        Me.gpxSelectLines.Size = New System.Drawing.Size(384, 109)
        Me.gpxSelectLines.TabIndex = 16
        Me.gpxSelectLines.TabStop = False
        Me.gpxSelectLines.Text = "Select Lines"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(48, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(296, 15)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Select Vendor to see all open PO's for that selected Vendor."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ReceivingHeaderTableTableAdapter
        '
        Me.ReceivingHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmdDeleteLine)
        Me.GroupBox1.Controls.Add(Me.cboVoucherLineNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(383, 600)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 155)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Delete Line from Voucher"
        '
        'Label26
        '
        Me.Label26.ForeColor = System.Drawing.Color.Blue
        Me.Label26.Location = New System.Drawing.Point(21, 81)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(196, 41)
        Me.Label26.TabIndex = 66
        Me.Label26.Text = "To delete a line from the grid, select Line # from drop down box and hit Delete B" & _
            "utton."
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(21, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 20)
        Me.Label13.TabIndex = 65
        Me.Label13.Text = "Voucher Line #"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Location = New System.Drawing.Point(231, 82)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 18
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'cboVoucherLineNumber
        '
        Me.cboVoucherLineNumber.DataSource = Me.ReceiptOfInvoiceVoucherLinesBindingSource
        Me.cboVoucherLineNumber.DisplayMember = "VoucherLine"
        Me.cboVoucherLineNumber.FormattingEnabled = True
        Me.cboVoucherLineNumber.Location = New System.Drawing.Point(124, 27)
        Me.cboVoucherLineNumber.Name = "cboVoucherLineNumber"
        Me.cboVoucherLineNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboVoucherLineNumber.TabIndex = 17
        '
        'cmdEnterVoucher
        '
        Me.cmdEnterVoucher.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEnterVoucher.Location = New System.Drawing.Point(383, 771)
        Me.cmdEnterVoucher.Name = "cmdEnterVoucher"
        Me.cmdEnterVoucher.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnterVoucher.TabIndex = 19
        Me.cmdEnterVoucher.Text = "Enter New Voucher"
        Me.cmdEnterVoucher.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(464, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 20
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'tabVoucherLines
        '
        Me.tabVoucherLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabVoucherLines.Controls.Add(Me.tabVoucherLineItems)
        Me.tabVoucherLines.Controls.Add(Me.tabAddNew)
        Me.tabVoucherLines.Location = New System.Drawing.Point(379, 142)
        Me.tabVoucherLines.Name = "tabVoucherLines"
        Me.tabVoucherLines.SelectedIndex = 0
        Me.tabVoucherLines.Size = New System.Drawing.Size(751, 443)
        Me.tabVoucherLines.TabIndex = 66
        '
        'tabVoucherLineItems
        '
        Me.tabVoucherLineItems.Controls.Add(Me.dgvVoucherLines)
        Me.tabVoucherLineItems.Location = New System.Drawing.Point(4, 22)
        Me.tabVoucherLineItems.Name = "tabVoucherLineItems"
        Me.tabVoucherLineItems.Padding = New System.Windows.Forms.Padding(3)
        Me.tabVoucherLineItems.Size = New System.Drawing.Size(743, 417)
        Me.tabVoucherLineItems.TabIndex = 0
        Me.tabVoucherLineItems.Text = "Voucher Lines"
        Me.tabVoucherLineItems.UseVisualStyleBackColor = True
        '
        'tabAddNew
        '
        Me.tabAddNew.Controls.Add(Me.Label28)
        Me.tabAddNew.Controls.Add(Me.cmdClear)
        Me.tabAddNew.Controls.Add(Me.cmdEnterLine)
        Me.tabAddNew.Controls.Add(Me.cboDebitDescription)
        Me.tabAddNew.Controls.Add(Me.cboDebitAccount)
        Me.tabAddNew.Controls.Add(Me.Label27)
        Me.tabAddNew.Controls.Add(Me.cboPartNumber)
        Me.tabAddNew.Controls.Add(Me.txtExtendedAmount)
        Me.tabAddNew.Controls.Add(Me.Label15)
        Me.tabAddNew.Controls.Add(Me.Label9)
        Me.tabAddNew.Controls.Add(Me.Label14)
        Me.tabAddNew.Controls.Add(Me.Label10)
        Me.tabAddNew.Controls.Add(Me.txtQuantity)
        Me.tabAddNew.Controls.Add(Me.Label11)
        Me.tabAddNew.Controls.Add(Me.txtUnitCost)
        Me.tabAddNew.Controls.Add(Me.txtLongDescription)
        Me.tabAddNew.Location = New System.Drawing.Point(4, 22)
        Me.tabAddNew.Name = "tabAddNew"
        Me.tabAddNew.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAddNew.Size = New System.Drawing.Size(743, 417)
        Me.tabAddNew.TabIndex = 1
        Me.tabAddNew.Text = "Add New Voucher Line"
        Me.tabAddNew.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.ForeColor = System.Drawing.Color.Blue
        Me.Label28.Location = New System.Drawing.Point(348, 112)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(264, 73)
        Me.Label28.TabIndex = 105
        Me.Label28.Text = "Use this function to manually add lines to the Voucher that were not entered on t" & _
            "he Purchase Order."
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(231, 290)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 34
        Me.cmdClear.Text = "Clear Lines"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnterLine
        '
        Me.cmdEnterLine.Location = New System.Drawing.Point(154, 290)
        Me.cmdEnterLine.Name = "cmdEnterLine"
        Me.cmdEnterLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnterLine.TabIndex = 33
        Me.cmdEnterLine.Text = "Enter Line"
        Me.cmdEnterLine.UseVisualStyleBackColor = True
        '
        'cboDebitDescription
        '
        Me.cboDebitDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDebitDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDebitDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboDebitDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboDebitDescription.FormattingEnabled = True
        Me.cboDebitDescription.Location = New System.Drawing.Point(351, 78)
        Me.cboDebitDescription.Name = "cboDebitDescription"
        Me.cboDebitDescription.Size = New System.Drawing.Size(261, 21)
        Me.cboDebitDescription.TabIndex = 32
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDebitAccount
        '
        Me.cboDebitAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDebitAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDebitAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboDebitAccount.DisplayMember = "GLAccountNumber"
        Me.cboDebitAccount.FormattingEnabled = True
        Me.cboDebitAccount.Location = New System.Drawing.Point(430, 42)
        Me.cboDebitAccount.Name = "cboDebitAccount"
        Me.cboDebitAccount.Size = New System.Drawing.Size(182, 21)
        Me.cboDebitAccount.TabIndex = 31
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(348, 43)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(112, 20)
        Me.Label27.TabIndex = 102
        Me.Label27.Text = "Debit Account"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NonInventoryItemListTableAdapter
        '
        Me.NonInventoryItemListTableAdapter.ClearBeforeFill = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'gpxVendorAddress
        '
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToAddress2)
        Me.gpxVendorAddress.Controls.Add(Me.cmdUpdateVendor)
        Me.gpxVendorAddress.Controls.Add(Me.cmdReturnToMain)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToZip)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToState)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToCountry)
        Me.gpxVendorAddress.Controls.Add(Me.Label30)
        Me.gpxVendorAddress.Controls.Add(Me.Label29)
        Me.gpxVendorAddress.Controls.Add(Me.Label6)
        Me.gpxVendorAddress.Controls.Add(Me.Label31)
        Me.gpxVendorAddress.Controls.Add(Me.Label32)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToCity)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToAddress1)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToVendorID)
        Me.gpxVendorAddress.Controls.Add(Me.Label33)
        Me.gpxVendorAddress.Controls.Add(Me.txtRemitToVendorName)
        Me.gpxVendorAddress.Controls.Add(Me.Label34)
        Me.gpxVendorAddress.Location = New System.Drawing.Point(29, 151)
        Me.gpxVendorAddress.Name = "gpxVendorAddress"
        Me.gpxVendorAddress.Size = New System.Drawing.Size(329, 469)
        Me.gpxVendorAddress.TabIndex = 67
        Me.gpxVendorAddress.TabStop = False
        Me.gpxVendorAddress.Text = "Vendor Remit To Address"
        Me.gpxVendorAddress.Visible = False
        '
        'txtRemitToAddress2
        '
        Me.txtRemitToAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemitToAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemitToAddress2.Location = New System.Drawing.Point(20, 235)
        Me.txtRemitToAddress2.Multiline = True
        Me.txtRemitToAddress2.Name = "txtRemitToAddress2"
        Me.txtRemitToAddress2.Size = New System.Drawing.Size(291, 50)
        Me.txtRemitToAddress2.TabIndex = 89
        Me.txtRemitToAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(21, 367)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 20)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Country"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(21, 212)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(124, 20)
        Me.Label31.TabIndex = 84
        Me.Label31.Text = "Address 2"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(21, 125)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(124, 20)
        Me.Label32.TabIndex = 83
        Me.Label32.Text = "Address 1"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.txtRemitToVendorID.Location = New System.Drawing.Point(73, 30)
        Me.txtRemitToVendorID.Name = "txtRemitToVendorID"
        Me.txtRemitToVendorID.Size = New System.Drawing.Size(236, 20)
        Me.txtRemitToVendorID.TabIndex = 37
        Me.txtRemitToVendorID.TabStop = False
        Me.txtRemitToVendorID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(18, 30)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(124, 20)
        Me.Label33.TabIndex = 79
        Me.Label33.Text = "Vendor"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(21, 297)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(69, 20)
        Me.Label34.TabIndex = 85
        Me.Label34.Text = "City"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VendorClassTableAdapter
        '
        Me.VendorClassTableAdapter.ClearBeforeFill = True
        '
        'cmdSelectMultiple
        '
        Me.cmdSelectMultiple.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectMultiple.Location = New System.Drawing.Point(545, 771)
        Me.cmdSelectMultiple.Name = "cmdSelectMultiple"
        Me.cmdSelectMultiple.Size = New System.Drawing.Size(71, 40)
        Me.cmdSelectMultiple.TabIndex = 17
        Me.cmdSelectMultiple.Text = "Select Multiple"
        Me.cmdSelectMultiple.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTaxOnPO)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.txtFreightVouched)
        Me.GroupBox2.Controls.Add(Me.Label36)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.txtFreightOnPO)
        Me.GroupBox2.Location = New System.Drawing.Point(831, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(299, 109)
        Me.GroupBox2.TabIndex = 68
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Freight/Tax Totals"
        '
        'txtTaxOnPO
        '
        Me.txtTaxOnPO.BackColor = System.Drawing.Color.White
        Me.txtTaxOnPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxOnPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTaxOnPO.Location = New System.Drawing.Point(136, 76)
        Me.txtTaxOnPO.Name = "txtTaxOnPO"
        Me.txtTaxOnPO.ReadOnly = True
        Me.txtTaxOnPO.Size = New System.Drawing.Size(148, 20)
        Me.txtTaxOnPO.TabIndex = 71
        Me.txtTaxOnPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(6, 76)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(85, 20)
        Me.Label38.TabIndex = 72
        Me.Label38.Text = "Tax On PO"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightVouched
        '
        Me.txtFreightVouched.BackColor = System.Drawing.Color.White
        Me.txtFreightVouched.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightVouched.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightVouched.Location = New System.Drawing.Point(136, 49)
        Me.txtFreightVouched.Name = "txtFreightVouched"
        Me.txtFreightVouched.ReadOnly = True
        Me.txtFreightVouched.Size = New System.Drawing.Size(148, 20)
        Me.txtFreightVouched.TabIndex = 67
        Me.txtFreightVouched.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(6, 49)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(85, 20)
        Me.Label36.TabIndex = 70
        Me.Label36.Text = "Freight Vouched"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(6, 22)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(85, 20)
        Me.Label37.TabIndex = 69
        Me.Label37.Text = "Freight On PO"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightOnPO
        '
        Me.txtFreightOnPO.BackColor = System.Drawing.Color.White
        Me.txtFreightOnPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightOnPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightOnPO.Location = New System.Drawing.Point(136, 22)
        Me.txtFreightOnPO.Name = "txtFreightOnPO"
        Me.txtFreightOnPO.ReadOnly = True
        Me.txtFreightOnPO.Size = New System.Drawing.Size(148, 20)
        Me.txtFreightOnPO.TabIndex = 68
        Me.txtFreightOnPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdViewPackingSlip
        '
        Me.cmdViewPackingSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPackingSlip.Enabled = False
        Me.cmdViewPackingSlip.Location = New System.Drawing.Point(626, 771)
        Me.cmdViewPackingSlip.Name = "cmdViewPackingSlip"
        Me.cmdViewPackingSlip.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPackingSlip.TabIndex = 69
        Me.cmdViewPackingSlip.Text = "View Packing"
        Me.cmdViewPackingSlip.UseVisualStyleBackColor = True
        '
        'ReceivingLineQueryTableAdapter
        '
        Me.ReceivingLineQueryTableAdapter.ClearBeforeFill = True
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
        Me.VoucherLineColumn.ReadOnly = True
        Me.VoucherLineColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.Width = 150
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 170
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle2.Format = "N6"
        DataGridViewCellStyle2.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        '
        'GLDebitAccountColumn
        '
        Me.GLDebitAccountColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountColumn.HeaderText = "GLDebitAccount"
        Me.GLDebitAccountColumn.Name = "GLDebitAccountColumn"
        Me.GLDebitAccountColumn.Visible = False
        '
        'GLCreditAccountColumn
        '
        Me.GLCreditAccountColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountColumn.HeaderText = "GLCreditAccount"
        Me.GLCreditAccountColumn.Name = "GLCreditAccountColumn"
        Me.GLCreditAccountColumn.Visible = False
        '
        'ReceiverNumberColumn
        '
        Me.ReceiverNumberColumn.DataPropertyName = "ReceiverNumber"
        Me.ReceiverNumberColumn.HeaderText = "ReceiverNumber"
        Me.ReceiverNumberColumn.Name = "ReceiverNumberColumn"
        Me.ReceiverNumberColumn.Visible = False
        '
        'ReceiverLineColumn
        '
        Me.ReceiverLineColumn.DataPropertyName = "ReceiverLine"
        Me.ReceiverLineColumn.HeaderText = "ReceiverLine"
        Me.ReceiverLineColumn.Name = "ReceiverLineColumn"
        Me.ReceiverLineColumn.Visible = False
        '
        'APReceiptOfInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdViewPackingSlip)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdSelectMultiple)
        Me.Controls.Add(Me.tabVoucherLines)
        Me.Controls.Add(Me.cmdEnterVoucher)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxSelectLines)
        Me.Controls.Add(Me.gpxInvoiceTotals)
        Me.Controls.Add(Me.gpxBatchInfo)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.gpxVoucherHeader)
        Me.Controls.Add(Me.gpxVendorAddress)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "APReceiptOfInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Receipt Of Invoice"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxBatchInfo.ResumeLayout(False)
        Me.gpxBatchInfo.PerformLayout()
        Me.gpxInvoiceTotals.ResumeLayout(False)
        Me.gpxInvoiceTotals.PerformLayout()
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxVoucherHeader.ResumeLayout(False)
        Me.gpxVoucherHeader.PerformLayout()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptTransactionDescriptionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxSelectLines.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.tabVoucherLines.ResumeLayout(False)
        Me.tabVoucherLineItems.ResumeLayout(False)
        Me.tabAddNew.ResumeLayout(False)
        Me.tabAddNew.PerformLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxVendorAddress.ResumeLayout(False)
        Me.gpxVendorAddress.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents gpxBatchInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDivisionID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTermDiscount As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesTaxTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtPurchaseTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtFreightTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents gpxInvoiceTotals As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelectByPO As System.Windows.Forms.Button
    Friend WithEvents ReceiptOfInvoiceVoucherLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceVoucherLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
    Friend WithEvents gpxVoucherHeader As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dtpDueDateDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cmdGenerateVoucher As System.Windows.Forms.Button
    Friend WithEvents cboVoucherNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents dtpInvoiceDateDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDiscountDateDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtpReceiptDateDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ReceiptTransactionDescriptionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptTransactionDescriptionTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptTransactionDescriptionTableAdapter
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents PaymentTermsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PaymentTermsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgvVoucherLines As System.Windows.Forms.DataGridView
    Friend WithEvents gpxSelectLines As System.Windows.Forms.GroupBox
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents ReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents cboVoucherLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdEnterVoucher As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents tabVoucherLines As System.Windows.Forms.TabControl
    Friend WithEvents tabVoucherLineItems As System.Windows.Forms.TabPage
    Friend WithEvents tabAddNew As System.Windows.Forms.TabPage
    Friend WithEvents cboDebitDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDebitAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnterLine As System.Windows.Forms.Button
    Friend WithEvents NonInventoryItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NonInventoryItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents chkManualDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents llVendorID As System.Windows.Forms.LinkLabel
    Friend WithEvents gpxVendorAddress As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpdateVendor As System.Windows.Forms.Button
    Friend WithEvents cmdReturnToMain As System.Windows.Forms.Button
    Friend WithEvents txtRemitToZip As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToState As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtRemitToCity As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToVendorID As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtRemitToVendorName As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents VendorClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDueDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDiscountDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpReceiptDate As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectMultiple As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFreightVouched As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtFreightOnPO As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxOnPO As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtRemitToAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdViewPackingSlip As System.Windows.Forms.Button
    Friend WithEvents UploadPackingSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReUploadPackingSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendUploadedPackingSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkWhitePaper As System.Windows.Forms.CheckBox
    Friend WithEvents chkOnHold As System.Windows.Forms.CheckBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cboCheckType As System.Windows.Forms.ComboBox
    Friend WithEvents ReceivingLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineQueryTableAdapter
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
