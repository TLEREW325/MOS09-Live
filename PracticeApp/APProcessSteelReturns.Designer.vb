<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APProcessSteelReturns
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
        Me.SaveReturnVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintReturnVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteReturnVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxBatchInfo = New System.Windows.Forms.GroupBox
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDivisionID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboCheckType = New System.Windows.Forms.ComboBox
        Me.dtpVoucherDate = New System.Windows.Forms.DateTimePicker
        Me.txtReturnAmount = New System.Windows.Forms.TextBox
        Me.lblReturnAmount = New System.Windows.Forms.Label
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.SteelPurchaseOrderHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboVoucherNumber = New System.Windows.Forms.ComboBox
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cmdGenerateVoucher = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboReturnNumber = New System.Windows.Forms.ComboBox
        Me.SteelReturnHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxSelectLines = New System.Windows.Forms.GroupBox
        Me.dtpReturnDate = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdSelectByReturn = New System.Windows.Forms.Button
        Me.gpxTotals = New System.Windows.Forms.GroupBox
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtOtherTotal = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtReturnTotal = New System.Windows.Forms.TextBox
        Me.cmdClearForm = New System.Windows.Forms.Button
        Me.cmdEnterNew = New System.Windows.Forms.Button
        Me.tabLineControl = New System.Windows.Forms.TabControl
        Me.tabVoucherLines = New System.Windows.Forms.TabPage
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
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptOfInvoiceVoucherLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabEditLines = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtDeleteDescription = New System.Windows.Forms.TextBox
        Me.txtDeletePartNumber = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cboDeleteLine = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.cboDebitDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDebitAccount = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.cboLinePartNumber = New System.Windows.Forms.ComboBox
        Me.NonInventoryItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtLineExtendedAmount = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtLineQuantity = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtLineUnitCost = New System.Windows.Forms.TextBox
        Me.txtLineDescription = New System.Windows.Forms.TextBox
        Me.cmdAddLine = New System.Windows.Forms.Button
        Me.cmdClearLines = New System.Windows.Forms.Button
        Me.cmdApply = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboOpenVoucher = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdSelectOpenPayables = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtApplyAmount = New System.Windows.Forms.TextBox
        Me.gpxApplyVendorReturn = New System.Windows.Forms.GroupBox
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.SteelPurchaseOrderHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
        Me.SteelReturnHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnHeaderTableTableAdapter
        Me.NonInventoryItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
        Me.ReceiptOfInvoiceVoucherLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.gpxBatchInfo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReturnHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxSelectLines.SuspendLayout()
        Me.gpxTotals.SuspendLayout()
        Me.tabLineControl.SuspendLayout()
        Me.tabVoucherLines.SuspendLayout()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEditLines.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxApplyVendorReturn.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveReturnVoucherToolStripMenuItem, Me.PrintReturnVoucherToolStripMenuItem, Me.DeleteReturnVoucherToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveReturnVoucherToolStripMenuItem
        '
        Me.SaveReturnVoucherToolStripMenuItem.Name = "SaveReturnVoucherToolStripMenuItem"
        Me.SaveReturnVoucherToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SaveReturnVoucherToolStripMenuItem.Text = "Save Return Voucher"
        '
        'PrintReturnVoucherToolStripMenuItem
        '
        Me.PrintReturnVoucherToolStripMenuItem.Name = "PrintReturnVoucherToolStripMenuItem"
        Me.PrintReturnVoucherToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.PrintReturnVoucherToolStripMenuItem.Text = "Print Return Voucher"
        '
        'DeleteReturnVoucherToolStripMenuItem
        '
        Me.DeleteReturnVoucherToolStripMenuItem.Name = "DeleteReturnVoucherToolStripMenuItem"
        Me.DeleteReturnVoucherToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.DeleteReturnVoucherToolStripMenuItem.Text = "Delete Return Voucher"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
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
        'gpxBatchInfo
        '
        Me.gpxBatchInfo.Controls.Add(Me.txtBatchNumber)
        Me.gpxBatchInfo.Controls.Add(Me.Label1)
        Me.gpxBatchInfo.Controls.Add(Me.txtDivisionID)
        Me.gpxBatchInfo.Controls.Add(Me.Label2)
        Me.gpxBatchInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxBatchInfo.Name = "gpxBatchInfo"
        Me.gpxBatchInfo.Size = New System.Drawing.Size(329, 79)
        Me.gpxBatchInfo.TabIndex = 0
        Me.gpxBatchInfo.TabStop = False
        Me.gpxBatchInfo.Text = "Batch Information"
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchNumber.Location = New System.Drawing.Point(146, 19)
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.ReadOnly = True
        Me.txtBatchNumber.Size = New System.Drawing.Size(164, 20)
        Me.txtBatchNumber.TabIndex = 0
        Me.txtBatchNumber.TabStop = False
        Me.txtBatchNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 19)
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
        Me.txtDivisionID.Location = New System.Drawing.Point(146, 45)
        Me.txtDivisionID.Name = "txtDivisionID"
        Me.txtDivisionID.ReadOnly = True
        Me.txtDivisionID.Size = New System.Drawing.Size(164, 20)
        Me.txtDivisionID.TabIndex = 0
        Me.txtDivisionID.TabStop = False
        Me.txtDivisionID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 20)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Division ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.cboCheckType)
        Me.GroupBox1.Controls.Add(Me.dtpVoucherDate)
        Me.GroupBox1.Controls.Add(Me.txtReturnAmount)
        Me.GroupBox1.Controls.Add(Me.lblReturnAmount)
        Me.GroupBox1.Controls.Add(Me.txtInvoiceNumber)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cboPONumber)
        Me.GroupBox1.Controls.Add(Me.cboVoucherNumber)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtComment)
        Me.GroupBox1.Controls.Add(Me.txtVendorName)
        Me.GroupBox1.Controls.Add(Me.cmdGenerateVoucher)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cboVendorID)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 126)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(329, 543)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Steel Vendor Return Header Information"
        '
        'cboCheckType
        '
        Me.cboCheckType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCheckType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCheckType.FormattingEnabled = True
        Me.cboCheckType.Items.AddRange(New Object() {"STANDARD", "FEDEX", "INTERCOMPANY", "ACH"})
        Me.cboCheckType.Location = New System.Drawing.Point(116, 211)
        Me.cboCheckType.Name = "cboCheckType"
        Me.cboCheckType.Size = New System.Drawing.Size(193, 21)
        Me.cboCheckType.TabIndex = 6
        '
        'dtpVoucherDate
        '
        Me.dtpVoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVoucherDate.Location = New System.Drawing.Point(117, 58)
        Me.dtpVoucherDate.Name = "dtpVoucherDate"
        Me.dtpVoucherDate.Size = New System.Drawing.Size(194, 20)
        Me.dtpVoucherDate.TabIndex = 4
        '
        'txtReturnAmount
        '
        Me.txtReturnAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReturnAmount.Location = New System.Drawing.Point(116, 327)
        Me.txtReturnAmount.Name = "txtReturnAmount"
        Me.txtReturnAmount.Size = New System.Drawing.Size(193, 20)
        Me.txtReturnAmount.TabIndex = 9
        Me.txtReturnAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblReturnAmount
        '
        Me.lblReturnAmount.Location = New System.Drawing.Point(20, 328)
        Me.lblReturnAmount.Name = "lblReturnAmount"
        Me.lblReturnAmount.Size = New System.Drawing.Size(124, 20)
        Me.lblReturnAmount.TabIndex = 84
        Me.lblReturnAmount.Text = "Return Total"
        Me.lblReturnAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(116, 289)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(193, 20)
        Me.txtInvoiceNumber.TabIndex = 8
        Me.txtInvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(20, 289)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 20)
        Me.Label16.TabIndex = 80
        Me.Label16.Text = "Invoice #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.SteelPurchaseOrderHeaderBindingSource
        Me.cboPONumber.DisplayMember = "SteelPurchaseOrderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(116, 250)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(193, 21)
        Me.cboPONumber.TabIndex = 7
        '
        'SteelPurchaseOrderHeaderBindingSource
        '
        Me.SteelPurchaseOrderHeaderBindingSource.DataMember = "SteelPurchaseOrderHeader"
        Me.SteelPurchaseOrderHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboVoucherNumber
        '
        Me.cboVoucherNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVoucherNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVoucherNumber.DataSource = Me.ReceiptOfInvoiceBatchLineBindingSource
        Me.cboVoucherNumber.DisplayMember = "VoucherNumber"
        Me.cboVoucherNumber.FormattingEnabled = True
        Me.cboVoucherNumber.Location = New System.Drawing.Point(117, 24)
        Me.cboVoucherNumber.Name = "cboVoucherNumber"
        Me.cboVoucherNumber.Size = New System.Drawing.Size(194, 21)
        Me.cboVoucherNumber.TabIndex = 3
        '
        'ReceiptOfInvoiceBatchLineBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataMember = "ReceiptOfInvoiceBatchLine"
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(20, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 20)
        Me.Label15.TabIndex = 78
        Me.Label15.Text = "Date"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 20)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Steel PO #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 372)
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
        Me.txtComment.Location = New System.Drawing.Point(23, 395)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(288, 120)
        Me.txtComment.TabIndex = 10
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorName.Location = New System.Drawing.Point(20, 125)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(290, 62)
        Me.txtVendorName.TabIndex = 5
        Me.txtVendorName.TabStop = False
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGenerateVoucher
        '
        Me.cmdGenerateVoucher.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateVoucher.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateVoucher.Location = New System.Drawing.Point(84, 25)
        Me.cmdGenerateVoucher.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateVoucher.Name = "cmdGenerateVoucher"
        Me.cmdGenerateVoucher.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateVoucher.TabIndex = 2
        Me.cmdGenerateVoucher.Text = ">>"
        Me.cmdGenerateVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateVoucher.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(20, 25)
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
        Me.cboVendorID.Location = New System.Drawing.Point(117, 91)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(194, 21)
        Me.cboVendorID.TabIndex = 5
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(20, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 20)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Steel Vendor"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(20, 212)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(124, 20)
        Me.Label29.TabIndex = 86
        Me.Label29.Text = "Check Type"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(6, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(124, 20)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "Return Date"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboReturnNumber
        '
        Me.cboReturnNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnNumber.DataSource = Me.SteelReturnHeaderTableBindingSource
        Me.cboReturnNumber.DisplayMember = "SteelReturnNumber"
        Me.cboReturnNumber.FormattingEnabled = True
        Me.cboReturnNumber.Location = New System.Drawing.Point(117, 54)
        Me.cboReturnNumber.Name = "cboReturnNumber"
        Me.cboReturnNumber.Size = New System.Drawing.Size(192, 21)
        Me.cboReturnNumber.TabIndex = 13
        '
        'SteelReturnHeaderTableBindingSource
        '
        Me.SteelReturnHeaderTableBindingSource.DataMember = "SteelReturnHeaderTable"
        Me.SteelReturnHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(874, 774)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 26
        Me.cmdPrint.Text = "Print Return"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(797, 774)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 25
        Me.cmdDelete.Text = "Delete Return"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(720, 774)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 24
        Me.cmdSave.Text = "Save Return"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(951, 774)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 27
        Me.cmdExit.Text = "Exit Return"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxSelectLines
        '
        Me.gpxSelectLines.Controls.Add(Me.dtpReturnDate)
        Me.gpxSelectLines.Controls.Add(Me.cboReturnNumber)
        Me.gpxSelectLines.Controls.Add(Me.Label13)
        Me.gpxSelectLines.Controls.Add(Me.cmdSelectByReturn)
        Me.gpxSelectLines.Controls.Add(Me.Label20)
        Me.gpxSelectLines.Location = New System.Drawing.Point(29, 685)
        Me.gpxSelectLines.Name = "gpxSelectLines"
        Me.gpxSelectLines.Size = New System.Drawing.Size(329, 129)
        Me.gpxSelectLines.TabIndex = 11
        Me.gpxSelectLines.TabStop = False
        Me.gpxSelectLines.Text = "Select Lines"
        '
        'dtpReturnDate
        '
        Me.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReturnDate.Location = New System.Drawing.Point(117, 20)
        Me.dtpReturnDate.Name = "dtpReturnDate"
        Me.dtpReturnDate.Size = New System.Drawing.Size(192, 20)
        Me.dtpReturnDate.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(6, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 20)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Steel Return #"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSelectByReturn
        '
        Me.cmdSelectByReturn.Location = New System.Drawing.Point(238, 85)
        Me.cmdSelectByReturn.Name = "cmdSelectByReturn"
        Me.cmdSelectByReturn.Size = New System.Drawing.Size(71, 30)
        Me.cmdSelectByReturn.TabIndex = 14
        Me.cmdSelectByReturn.Text = "Select"
        Me.cmdSelectByReturn.UseVisualStyleBackColor = True
        '
        'gpxTotals
        '
        Me.gpxTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxTotals.Controls.Add(Me.txtProductTotal)
        Me.gpxTotals.Controls.Add(Me.Label6)
        Me.gpxTotals.Controls.Add(Me.txtFreightTotal)
        Me.gpxTotals.Controls.Add(Me.Label8)
        Me.gpxTotals.Controls.Add(Me.Label9)
        Me.gpxTotals.Controls.Add(Me.txtOtherTotal)
        Me.gpxTotals.Controls.Add(Me.Label7)
        Me.gpxTotals.Controls.Add(Me.txtReturnTotal)
        Me.gpxTotals.Location = New System.Drawing.Point(720, 583)
        Me.gpxTotals.Name = "gpxTotals"
        Me.gpxTotals.Size = New System.Drawing.Size(302, 177)
        Me.gpxTotals.TabIndex = 18
        Me.gpxTotals.TabStop = False
        Me.gpxTotals.Text = "Vendor Return Totals"
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductTotal.Location = New System.Drawing.Point(135, 38)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.ReadOnly = True
        Me.txtProductTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtProductTotal.TabIndex = 18
        Me.txtProductTotal.TabStop = False
        Me.txtProductTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 20)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Freight"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightTotal.Location = New System.Drawing.Point(135, 66)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtFreightTotal.TabIndex = 19
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 20)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Return Amount"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 20)
        Me.Label9.TabIndex = 77
        Me.Label9.Text = "Product Amount"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOtherTotal
        '
        Me.txtOtherTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOtherTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOtherTotal.Location = New System.Drawing.Point(135, 94)
        Me.txtOtherTotal.Name = "txtOtherTotal"
        Me.txtOtherTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtOtherTotal.TabIndex = 20
        Me.txtOtherTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 20)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Other"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReturnTotal
        '
        Me.txtReturnTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtReturnTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReturnTotal.Location = New System.Drawing.Point(134, 122)
        Me.txtReturnTotal.Name = "txtReturnTotal"
        Me.txtReturnTotal.ReadOnly = True
        Me.txtReturnTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtReturnTotal.TabIndex = 21
        Me.txtReturnTotal.TabStop = False
        Me.txtReturnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearForm.Location = New System.Drawing.Point(452, 774)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearForm.TabIndex = 23
        Me.cmdClearForm.Text = "Clear Form"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'cmdEnterNew
        '
        Me.cmdEnterNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEnterNew.Location = New System.Drawing.Point(375, 774)
        Me.cmdEnterNew.Name = "cmdEnterNew"
        Me.cmdEnterNew.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnterNew.TabIndex = 22
        Me.cmdEnterNew.Text = "Enter New Voucher"
        Me.cmdEnterNew.UseVisualStyleBackColor = True
        '
        'tabLineControl
        '
        Me.tabLineControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabLineControl.Controls.Add(Me.tabVoucherLines)
        Me.tabLineControl.Controls.Add(Me.tabEditLines)
        Me.tabLineControl.Location = New System.Drawing.Point(375, 41)
        Me.tabLineControl.Name = "tabLineControl"
        Me.tabLineControl.SelectedIndex = 0
        Me.tabLineControl.Size = New System.Drawing.Size(647, 522)
        Me.tabLineControl.TabIndex = 86
        '
        'tabVoucherLines
        '
        Me.tabVoucherLines.Controls.Add(Me.dgvVoucherLines)
        Me.tabVoucherLines.Location = New System.Drawing.Point(4, 22)
        Me.tabVoucherLines.Name = "tabVoucherLines"
        Me.tabVoucherLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabVoucherLines.Size = New System.Drawing.Size(639, 496)
        Me.tabVoucherLines.TabIndex = 0
        Me.tabVoucherLines.Text = "Voucher Lines"
        Me.tabVoucherLines.UseVisualStyleBackColor = True
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
        Me.dgvVoucherLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VoucherNumberColumn, Me.VoucherLineColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn, Me.SelectForInvoiceColumn, Me.ReceiverNumberColumn, Me.ReceiverLineColumn, Me.DivisionIDColumn})
        Me.dgvVoucherLines.DataSource = Me.ReceiptOfInvoiceVoucherLinesBindingSource
        Me.dgvVoucherLines.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvVoucherLines.Location = New System.Drawing.Point(0, 0)
        Me.dgvVoucherLines.Name = "dgvVoucherLines"
        Me.dgvVoucherLines.Size = New System.Drawing.Size(639, 496)
        Me.dgvVoucherLines.TabIndex = 0
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
        Me.VoucherLineColumn.Width = 60
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        Me.PartNumberColumn.Width = 130
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 150
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle2.Format = "N5"
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
        Me.ExtendedAmountColumn.HeaderText = "Ext. Amt."
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 80
        '
        'GLDebitAccountColumn
        '
        Me.GLDebitAccountColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountColumn.HeaderText = "Debit Account"
        Me.GLDebitAccountColumn.Name = "GLDebitAccountColumn"
        Me.GLDebitAccountColumn.ReadOnly = True
        '
        'GLCreditAccountColumn
        '
        Me.GLCreditAccountColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountColumn.HeaderText = "Credit Account"
        Me.GLCreditAccountColumn.Name = "GLCreditAccountColumn"
        Me.GLCreditAccountColumn.ReadOnly = True
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "Select For Invoice"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.ReadOnly = True
        '
        'ReceiverNumberColumn
        '
        Me.ReceiverNumberColumn.DataPropertyName = "ReceiverNumber"
        Me.ReceiverNumberColumn.HeaderText = "Receiver #"
        Me.ReceiverNumberColumn.Name = "ReceiverNumberColumn"
        Me.ReceiverNumberColumn.ReadOnly = True
        '
        'ReceiverLineColumn
        '
        Me.ReceiverLineColumn.DataPropertyName = "ReceiverLine"
        Me.ReceiverLineColumn.HeaderText = "Receiver Line #"
        Me.ReceiverLineColumn.Name = "ReceiverLineColumn"
        Me.ReceiverLineColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'ReceiptOfInvoiceVoucherLinesBindingSource
        '
        Me.ReceiptOfInvoiceVoucherLinesBindingSource.DataMember = "ReceiptOfInvoiceVoucherLines"
        Me.ReceiptOfInvoiceVoucherLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tabEditLines
        '
        Me.tabEditLines.Controls.Add(Me.GroupBox3)
        Me.tabEditLines.Controls.Add(Me.GroupBox2)
        Me.tabEditLines.Location = New System.Drawing.Point(4, 22)
        Me.tabEditLines.Name = "tabEditLines"
        Me.tabEditLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEditLines.Size = New System.Drawing.Size(639, 496)
        Me.tabEditLines.TabIndex = 1
        Me.tabEditLines.Text = " Add / Delete Lines"
        Me.tabEditLines.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtDeleteDescription)
        Me.GroupBox3.Controls.Add(Me.txtDeletePartNumber)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.cboDeleteLine)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.cmdDeleteLine)
        Me.GroupBox3.Location = New System.Drawing.Point(331, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(305, 335)
        Me.GroupBox3.TabIndex = 40
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Delete a Line"
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(14, 123)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 20)
        Me.Label24.TabIndex = 109
        Me.Label24.Text = "Description"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(17, 65)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 20)
        Me.Label17.TabIndex = 108
        Me.Label17.Text = "Part Number"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDeleteDescription
        '
        Me.txtDeleteDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeleteDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeleteDescription.Location = New System.Drawing.Point(17, 146)
        Me.txtDeleteDescription.Multiline = True
        Me.txtDeleteDescription.Name = "txtDeleteDescription"
        Me.txtDeleteDescription.ReadOnly = True
        Me.txtDeleteDescription.Size = New System.Drawing.Size(270, 70)
        Me.txtDeleteDescription.TabIndex = 43
        Me.txtDeleteDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDeletePartNumber
        '
        Me.txtDeletePartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeletePartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeletePartNumber.Location = New System.Drawing.Point(17, 88)
        Me.txtDeletePartNumber.Name = "txtDeletePartNumber"
        Me.txtDeletePartNumber.ReadOnly = True
        Me.txtDeletePartNumber.Size = New System.Drawing.Size(273, 20)
        Me.txtDeletePartNumber.TabIndex = 42
        Me.txtDeletePartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(17, 230)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(270, 35)
        Me.Label25.TabIndex = 85
        Me.Label25.Text = "To remove a line from this voucher, select the line number from the drop down box" & _
            " and press delete."
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDeleteLine
        '
        Me.cboDeleteLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeleteLine.DataSource = Me.ReceiptOfInvoiceVoucherLinesBindingSource
        Me.cboDeleteLine.DisplayMember = "VoucherLine"
        Me.cboDeleteLine.FormattingEnabled = True
        Me.cboDeleteLine.Location = New System.Drawing.Point(163, 30)
        Me.cboDeleteLine.Name = "cboDeleteLine"
        Me.cboDeleteLine.Size = New System.Drawing.Size(129, 21)
        Me.cboDeleteLine.TabIndex = 41
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(17, 29)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(124, 20)
        Me.Label23.TabIndex = 81
        Me.Label23.Text = "Voucher Line #"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteLine.Location = New System.Drawing.Point(221, 278)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 44
        Me.cmdDeleteLine.Text = "Delete"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.cboDebitDescription)
        Me.GroupBox2.Controls.Add(Me.cboDebitAccount)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.cboLinePartNumber)
        Me.GroupBox2.Controls.Add(Me.txtLineExtendedAmount)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.txtLineQuantity)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtLineUnitCost)
        Me.GroupBox2.Controls.Add(Me.txtLineDescription)
        Me.GroupBox2.Controls.Add(Me.cmdAddLine)
        Me.GroupBox2.Controls.Add(Me.cmdClearLines)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(313, 473)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add a Line"
        '
        'Label28
        '
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(18, 201)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(275, 26)
        Me.Label28.TabIndex = 113
        Me.Label28.Text = "Lines for credit are added as a negative quantity."
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDebitDescription
        '
        Me.cboDebitDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDebitDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDebitDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboDebitDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboDebitDescription.FormattingEnabled = True
        Me.cboDebitDescription.Location = New System.Drawing.Point(18, 384)
        Me.cboDebitDescription.Name = "cboDebitDescription"
        Me.cboDebitDescription.Size = New System.Drawing.Size(275, 21)
        Me.cboDebitDescription.TabIndex = 37
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
        Me.cboDebitAccount.Location = New System.Drawing.Point(111, 356)
        Me.cboDebitAccount.Name = "cboDebitAccount"
        Me.cboDebitAccount.Size = New System.Drawing.Size(182, 21)
        Me.cboDebitAccount.TabIndex = 36
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(17, 356)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(112, 20)
        Me.Label27.TabIndex = 112
        Me.Label27.Text = "Debit Account"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLinePartNumber
        '
        Me.cboLinePartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLinePartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLinePartNumber.DataSource = Me.NonInventoryItemListBindingSource
        Me.cboLinePartNumber.DisplayMember = "ItemID"
        Me.cboLinePartNumber.FormattingEnabled = True
        Me.cboLinePartNumber.Location = New System.Drawing.Point(61, 32)
        Me.cboLinePartNumber.Name = "cboLinePartNumber"
        Me.cboLinePartNumber.Size = New System.Drawing.Size(232, 21)
        Me.cboLinePartNumber.TabIndex = 31
        '
        'NonInventoryItemListBindingSource
        '
        Me.NonInventoryItemListBindingSource.DataMember = "NonInventoryItemList"
        Me.NonInventoryItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtLineExtendedAmount
        '
        Me.txtLineExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineExtendedAmount.Location = New System.Drawing.Point(145, 305)
        Me.txtLineExtendedAmount.Name = "txtLineExtendedAmount"
        Me.txtLineExtendedAmount.ReadOnly = True
        Me.txtLineExtendedAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtLineExtendedAmount.TabIndex = 35
        Me.txtLineExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(17, 32)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 20)
        Me.Label18.TabIndex = 105
        Me.Label18.Text = "Item"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(18, 305)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 20)
        Me.Label19.TabIndex = 109
        Me.Label19.Text = "Extended Cost"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(17, 65)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(124, 20)
        Me.Label21.TabIndex = 106
        Me.Label21.Text = "Description"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(18, 275)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 20)
        Me.Label22.TabIndex = 108
        Me.Label22.Text = "Unit Cost"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineQuantity
        '
        Me.txtLineQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineQuantity.Location = New System.Drawing.Point(145, 245)
        Me.txtLineQuantity.Name = "txtLineQuantity"
        Me.txtLineQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtLineQuantity.TabIndex = 33
        Me.txtLineQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(18, 245)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(112, 20)
        Me.Label26.TabIndex = 107
        Me.Label26.Text = "Quantity"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineUnitCost
        '
        Me.txtLineUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineUnitCost.Location = New System.Drawing.Point(145, 275)
        Me.txtLineUnitCost.Name = "txtLineUnitCost"
        Me.txtLineUnitCost.Size = New System.Drawing.Size(148, 20)
        Me.txtLineUnitCost.TabIndex = 34
        Me.txtLineUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineDescription
        '
        Me.txtLineDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineDescription.Location = New System.Drawing.Point(18, 88)
        Me.txtLineDescription.Multiline = True
        Me.txtLineDescription.Name = "txtLineDescription"
        Me.txtLineDescription.Size = New System.Drawing.Size(275, 95)
        Me.txtLineDescription.TabIndex = 32
        Me.txtLineDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdAddLine
        '
        Me.cmdAddLine.Location = New System.Drawing.Point(144, 423)
        Me.cmdAddLine.Name = "cmdAddLine"
        Me.cmdAddLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddLine.TabIndex = 38
        Me.cmdAddLine.Text = "Add Line"
        Me.cmdAddLine.UseVisualStyleBackColor = True
        '
        'cmdClearLines
        '
        Me.cmdClearLines.Location = New System.Drawing.Point(222, 423)
        Me.cmdClearLines.Name = "cmdClearLines"
        Me.cmdClearLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearLines.TabIndex = 39
        Me.cmdClearLines.Text = "Clear Lines"
        Me.cmdClearLines.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        Me.cmdApply.ForeColor = System.Drawing.Color.Black
        Me.cmdApply.Location = New System.Drawing.Point(244, 141)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(58, 25)
        Me.cmdApply.TabIndex = 17
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 20)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Voucher Number"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOpenVoucher
        '
        Me.cboOpenVoucher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOpenVoucher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOpenVoucher.FormattingEnabled = True
        Me.cboOpenVoucher.Location = New System.Drawing.Point(139, 76)
        Me.cboOpenVoucher.Name = "cboOpenVoucher"
        Me.cboOpenVoucher.Size = New System.Drawing.Size(164, 21)
        Me.cboOpenVoucher.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(19, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(284, 43)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "To post the Vendor Return against an outstanding Open Payable, select the  Vouche" & _
            "r Number for the Drop Down list or hit ""Select"" to view all."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSelectOpenPayables
        '
        Me.cmdSelectOpenPayables.Location = New System.Drawing.Point(180, 141)
        Me.cmdSelectOpenPayables.Name = "cmdSelectOpenPayables"
        Me.cmdSelectOpenPayables.Size = New System.Drawing.Size(58, 25)
        Me.cmdSelectOpenPayables.TabIndex = 16
        Me.cmdSelectOpenPayables.Text = "Select"
        Me.cmdSelectOpenPayables.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(19, 106)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(124, 20)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Amount"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtApplyAmount
        '
        Me.txtApplyAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApplyAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApplyAmount.Location = New System.Drawing.Point(139, 106)
        Me.txtApplyAmount.Name = "txtApplyAmount"
        Me.txtApplyAmount.Size = New System.Drawing.Size(164, 20)
        Me.txtApplyAmount.TabIndex = 15
        Me.txtApplyAmount.TabStop = False
        Me.txtApplyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gpxApplyVendorReturn
        '
        Me.gpxApplyVendorReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxApplyVendorReturn.Controls.Add(Me.txtApplyAmount)
        Me.gpxApplyVendorReturn.Controls.Add(Me.Label14)
        Me.gpxApplyVendorReturn.Controls.Add(Me.cmdSelectOpenPayables)
        Me.gpxApplyVendorReturn.Controls.Add(Me.Label12)
        Me.gpxApplyVendorReturn.Controls.Add(Me.cboOpenVoucher)
        Me.gpxApplyVendorReturn.Controls.Add(Me.Label4)
        Me.gpxApplyVendorReturn.Controls.Add(Me.cmdApply)
        Me.gpxApplyVendorReturn.Enabled = False
        Me.gpxApplyVendorReturn.Location = New System.Drawing.Point(375, 583)
        Me.gpxApplyVendorReturn.Name = "gpxApplyVendorReturn"
        Me.gpxApplyVendorReturn.Size = New System.Drawing.Size(323, 177)
        Me.gpxApplyVendorReturn.TabIndex = 13
        Me.gpxApplyVendorReturn.TabStop = False
        Me.gpxApplyVendorReturn.Text = "Apply Vendor Return"
        '
        'ReceiptOfInvoiceBatchLineTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'SteelPurchaseOrderHeaderTableAdapter
        '
        Me.SteelPurchaseOrderHeaderTableAdapter.ClearBeforeFill = True
        '
        'SteelReturnHeaderTableTableAdapter
        '
        Me.SteelReturnHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'NonInventoryItemListTableAdapter
        '
        Me.NonInventoryItemListTableAdapter.ClearBeforeFill = True
        '
        'ReceiptOfInvoiceVoucherLinesTableAdapter
        '
        Me.ReceiptOfInvoiceVoucherLinesTableAdapter.ClearBeforeFill = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(146, 369)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(163, 20)
        Me.TextBox3.TabIndex = 87
        '
        'APProcessSteelReturns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.tabLineControl)
        Me.Controls.Add(Me.cmdEnterNew)
        Me.Controls.Add(Me.gpxApplyVendorReturn)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.gpxTotals)
        Me.Controls.Add(Me.gpxSelectLines)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxBatchInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "APProcessSteelReturns"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Process Steel Vendor Returns"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxBatchInfo.ResumeLayout(False)
        Me.gpxBatchInfo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReturnHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxSelectLines.ResumeLayout(False)
        Me.gpxTotals.ResumeLayout(False)
        Me.gpxTotals.PerformLayout()
        Me.tabLineControl.ResumeLayout(False)
        Me.tabVoucherLines.ResumeLayout(False)
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEditLines.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxApplyVendorReturn.ResumeLayout(False)
        Me.gpxApplyVendorReturn.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxBatchInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDivisionID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cmdGenerateVoucher As System.Windows.Forms.Button
    Friend WithEvents cboVoucherNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboReturnNumber As System.Windows.Forms.ComboBox
    Friend WithEvents gpxSelectLines As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectByReturn As System.Windows.Forms.Button
    Friend WithEvents SaveReturnVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintReturnVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteReturnVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxTotals As System.Windows.Forms.GroupBox
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFreightTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOtherTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtReturnTotal As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearForm As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdEnterNew As System.Windows.Forms.Button
    Friend WithEvents tabLineControl As System.Windows.Forms.TabControl
    Friend WithEvents tabVoucherLines As System.Windows.Forms.TabPage
    Friend WithEvents tabEditLines As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddLine As System.Windows.Forms.Button
    Friend WithEvents cmdClearLines As System.Windows.Forms.Button
    Friend WithEvents txtReturnAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblReturnAmount As System.Windows.Forms.Label
    Friend WithEvents cboLinePartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtLineExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtLineQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtLineUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents txtLineDescription As System.Windows.Forms.TextBox
    Friend WithEvents cboDebitDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDebitAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboOpenVoucher As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectOpenPayables As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtApplyAmount As System.Windows.Forms.TextBox
    Friend WithEvents gpxApplyVendorReturn As System.Windows.Forms.GroupBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents SteelPurchaseOrderHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelPurchaseOrderHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
    Friend WithEvents SteelReturnHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReturnHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnHeaderTableTableAdapter
    Friend WithEvents NonInventoryItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NonInventoryItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
    Friend WithEvents dtpVoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvVoucherLines As System.Windows.Forms.DataGridView
    Friend WithEvents ReceiptOfInvoiceVoucherLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceVoucherLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboDeleteLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents txtDeleteDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtDeletePartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cboCheckType As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
End Class
