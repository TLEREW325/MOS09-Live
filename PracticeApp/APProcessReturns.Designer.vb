<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APProcessReturns
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.chkWhitePaper = New System.Windows.Forms.CheckBox
        Me.cboCheckType = New System.Windows.Forms.ComboBox
        Me.lblCheckCode = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.dtpReturnVoucherDateDD = New System.Windows.Forms.DateTimePicker
        Me.dtpReturnVoucherDate = New System.Windows.Forms.TextBox
        Me.txtReturnAmount = New System.Windows.Forms.TextBox
        Me.lblReturnAmount = New System.Windows.Forms.Label
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.VendorClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.dtpReturnDateDD = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboReturnNumber = New System.Windows.Forms.ComboBox
        Me.VendorReturnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
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
        Me.ReceiptOfInvoiceVoucherLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.VendorReturnTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnTableAdapter
        Me.ReceiptOfInvoiceVoucherLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
        Me.gpxSelectLines = New System.Windows.Forms.GroupBox
        Me.dtpReturnDate = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdSelectByReturn = New System.Windows.Forms.Button
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.gpxTotals = New System.Windows.Forms.GroupBox
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtSalesTaxTotal = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtReturnTotal = New System.Windows.Forms.TextBox
        Me.cmdClearForm = New System.Windows.Forms.Button
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.gpxApplyVendorReturn = New System.Windows.Forms.GroupBox
        Me.txtApplyAmount = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdSelectOpenPayables = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboOpenVoucher = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdApply = New System.Windows.Forms.Button
        Me.cmdEnterNew = New System.Windows.Forms.Button
        Me.VendorClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
        Me.tabLineControl = New System.Windows.Forms.TabControl
        Me.tabVoucherLines = New System.Windows.Forms.TabPage
        Me.tabEditLines = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtDeleteDescription = New System.Windows.Forms.TextBox
        Me.txtDeletePartNumber = New System.Windows.Forms.TextBox
        Me.cboDeleteLine = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.txtLineExtendedCost = New System.Windows.Forms.TextBox
        Me.txtLineCost = New System.Windows.Forms.TextBox
        Me.txtLineQuantity = New System.Windows.Forms.TextBox
        Me.cboPartnumber = New System.Windows.Forms.ComboBox
        Me.NonInventoryItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdAddLine = New System.Windows.Forms.Button
        Me.cmdClearLines = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.NonInventoryItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxBatchInfo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorReturnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxSelectLines.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxTotals.SuspendLayout()
        Me.gpxApplyVendorReturn.SuspendLayout()
        Me.tabLineControl.SuspendLayout()
        Me.tabVoucherLines.SuspendLayout()
        Me.tabEditLines.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.txtBatchNumber.Enabled = False
        Me.txtBatchNumber.Location = New System.Drawing.Point(146, 19)
        Me.txtBatchNumber.Name = "txtBatchNumber"
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
        Me.txtDivisionID.Enabled = False
        Me.txtDivisionID.Location = New System.Drawing.Point(146, 45)
        Me.txtDivisionID.Name = "txtDivisionID"
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
        Me.GroupBox1.Controls.Add(Me.chkWhitePaper)
        Me.GroupBox1.Controls.Add(Me.cboCheckType)
        Me.GroupBox1.Controls.Add(Me.lblCheckCode)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.dtpReturnVoucherDateDD)
        Me.GroupBox1.Controls.Add(Me.dtpReturnVoucherDate)
        Me.GroupBox1.Controls.Add(Me.txtReturnAmount)
        Me.GroupBox1.Controls.Add(Me.lblReturnAmount)
        Me.GroupBox1.Controls.Add(Me.cboVendorClass)
        Me.GroupBox1.Controls.Add(Me.Label17)
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
        Me.GroupBox1.Location = New System.Drawing.Point(29, 126)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(329, 553)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vendor Return Header Information"
        '
        'chkWhitePaper
        '
        Me.chkWhitePaper.AutoSize = True
        Me.chkWhitePaper.ForeColor = System.Drawing.Color.Blue
        Me.chkWhitePaper.Location = New System.Drawing.Point(118, 366)
        Me.chkWhitePaper.Name = "chkWhitePaper"
        Me.chkWhitePaper.Size = New System.Drawing.Size(125, 17)
        Me.chkWhitePaper.TabIndex = 88
        Me.chkWhitePaper.Text = "White Paper Check?"
        Me.chkWhitePaper.UseVisualStyleBackColor = True
        '
        'cboCheckType
        '
        Me.cboCheckType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCheckType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCheckType.FormattingEnabled = True
        Me.cboCheckType.Items.AddRange(New Object() {"STANDARD", "FEDEX", "INTERCOMPANY", "ACH"})
        Me.cboCheckType.Location = New System.Drawing.Point(118, 235)
        Me.cboCheckType.Name = "cboCheckType"
        Me.cboCheckType.Size = New System.Drawing.Size(194, 21)
        Me.cboCheckType.TabIndex = 7
        '
        'lblCheckCode
        '
        Me.lblCheckCode.ForeColor = System.Drawing.Color.Blue
        Me.lblCheckCode.Location = New System.Drawing.Point(118, 387)
        Me.lblCheckCode.Name = "lblCheckCode"
        Me.lblCheckCode.Size = New System.Drawing.Size(191, 20)
        Me.lblCheckCode.TabIndex = 85
        Me.lblCheckCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(22, 236)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(92, 20)
        Me.Label26.TabIndex = 87
        Me.Label26.Text = "Check Type"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpReturnVoucherDateDD
        '
        Me.dtpReturnVoucherDateDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReturnVoucherDateDD.Location = New System.Drawing.Point(291, 58)
        Me.dtpReturnVoucherDateDD.Name = "dtpReturnVoucherDateDD"
        Me.dtpReturnVoucherDateDD.Size = New System.Drawing.Size(20, 20)
        Me.dtpReturnVoucherDateDD.TabIndex = 3
        Me.dtpReturnVoucherDateDD.TabStop = False
        '
        'dtpReturnVoucherDate
        '
        Me.dtpReturnVoucherDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpReturnVoucherDate.Location = New System.Drawing.Point(118, 58)
        Me.dtpReturnVoucherDate.Name = "dtpReturnVoucherDate"
        Me.dtpReturnVoucherDate.Size = New System.Drawing.Size(193, 20)
        Me.dtpReturnVoucherDate.TabIndex = 3
        '
        'txtReturnAmount
        '
        Me.txtReturnAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReturnAmount.Location = New System.Drawing.Point(118, 330)
        Me.txtReturnAmount.Name = "txtReturnAmount"
        Me.txtReturnAmount.Size = New System.Drawing.Size(194, 20)
        Me.txtReturnAmount.TabIndex = 10
        Me.txtReturnAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblReturnAmount
        '
        Me.lblReturnAmount.Location = New System.Drawing.Point(22, 331)
        Me.lblReturnAmount.Name = "lblReturnAmount"
        Me.lblReturnAmount.Size = New System.Drawing.Size(92, 20)
        Me.lblReturnAmount.TabIndex = 84
        Me.lblReturnAmount.Text = "Return Total"
        Me.lblReturnAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.DataSource = Me.VendorClassBindingSource
        Me.cboVendorClass.DisplayMember = "VendClassID"
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(118, 203)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(194, 21)
        Me.cboVendorClass.TabIndex = 6
        '
        'VendorClassBindingSource
        '
        Me.VendorClassBindingSource.DataMember = "VendorClass"
        Me.VendorClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(22, 204)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(92, 20)
        Me.Label17.TabIndex = 82
        Me.Label17.Text = "Vendor Class"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(118, 299)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(194, 20)
        Me.txtInvoiceNumber.TabIndex = 9
        Me.txtInvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(22, 299)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 20)
        Me.Label16.TabIndex = 80
        Me.Label16.Text = "Invoice #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPONumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(118, 267)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(194, 21)
        Me.cboPONumber.TabIndex = 8
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
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
        Me.cboVoucherNumber.TabIndex = 2
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
        Me.Label5.Location = New System.Drawing.Point(22, 268)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 20)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "PO Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 407)
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
        Me.txtComment.Location = New System.Drawing.Point(22, 430)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(289, 111)
        Me.txtComment.TabIndex = 11
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorName.Location = New System.Drawing.Point(21, 125)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(290, 62)
        Me.txtVendorName.TabIndex = 5
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
        Me.cmdGenerateVoucher.TabIndex = 1
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
        Me.cboVendorID.TabIndex = 4
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
        Me.Label11.Text = "Vendor ID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpReturnDateDD
        '
        Me.dtpReturnDateDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReturnDateDD.Location = New System.Drawing.Point(291, 24)
        Me.dtpReturnDateDD.Name = "dtpReturnDateDD"
        Me.dtpReturnDateDD.Size = New System.Drawing.Size(19, 20)
        Me.dtpReturnDateDD.TabIndex = 11
        Me.dtpReturnDateDD.TabStop = False
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(26, 24)
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
        Me.cboReturnNumber.DataSource = Me.VendorReturnBindingSource
        Me.cboReturnNumber.DisplayMember = "ReturnNumber"
        Me.cboReturnNumber.FormattingEnabled = True
        Me.cboReturnNumber.Location = New System.Drawing.Point(117, 54)
        Me.cboReturnNumber.Name = "cboReturnNumber"
        Me.cboReturnNumber.Size = New System.Drawing.Size(192, 21)
        Me.cboReturnNumber.TabIndex = 14
        '
        'VendorReturnBindingSource
        '
        Me.VendorReturnBindingSource.DataMember = "VendorReturn"
        Me.VendorReturnBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(974, 774)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 26
        Me.cmdPrint.Text = "Print Return"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(897, 774)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 25
        Me.cmdDelete.Text = "Delete Return"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(820, 774)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 24
        Me.cmdSave.Text = "Save Return"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1051, 774)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 27
        Me.cmdExit.Text = "Exit Return"
        Me.cmdExit.UseVisualStyleBackColor = True
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
        Me.dgvVoucherLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VoucherNumberColumn, Me.VoucherLineColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn, Me.SelectForInvoiceColumn, Me.ReceiverNumberColumn, Me.ReceiverLineColumn})
        Me.dgvVoucherLines.DataSource = Me.ReceiptOfInvoiceVoucherLinesBindingSource
        Me.dgvVoucherLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvVoucherLines.Location = New System.Drawing.Point(0, 0)
        Me.dgvVoucherLines.Name = "dgvVoucherLines"
        Me.dgvVoucherLines.Size = New System.Drawing.Size(739, 496)
        Me.dgvVoucherLines.TabIndex = 85
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
        Me.VoucherLineColumn.ReadOnly = True
        Me.VoucherLineColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle4.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 80
        '
        'GLDebitAccountColumn
        '
        Me.GLDebitAccountColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountColumn.HeaderText = "Debit Account"
        Me.GLDebitAccountColumn.Name = "GLDebitAccountColumn"
        Me.GLDebitAccountColumn.Width = 80
        '
        'GLCreditAccountColumn
        '
        Me.GLCreditAccountColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountColumn.HeaderText = "Credit Account"
        Me.GLCreditAccountColumn.Name = "GLCreditAccountColumn"
        Me.GLCreditAccountColumn.Width = 80
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.Visible = False
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
        'ReceiptOfInvoiceVoucherLinesBindingSource
        '
        Me.ReceiptOfInvoiceVoucherLinesBindingSource.DataMember = "ReceiptOfInvoiceVoucherLines"
        Me.ReceiptOfInvoiceVoucherLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ReceiptOfInvoiceBatchLineTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineTableAdapter.ClearBeforeFill = True
        '
        'VendorReturnTableAdapter
        '
        Me.VendorReturnTableAdapter.ClearBeforeFill = True
        '
        'ReceiptOfInvoiceVoucherLinesTableAdapter
        '
        Me.ReceiptOfInvoiceVoucherLinesTableAdapter.ClearBeforeFill = True
        '
        'gpxSelectLines
        '
        Me.gpxSelectLines.Controls.Add(Me.dtpReturnDateDD)
        Me.gpxSelectLines.Controls.Add(Me.dtpReturnDate)
        Me.gpxSelectLines.Controls.Add(Me.cboReturnNumber)
        Me.gpxSelectLines.Controls.Add(Me.Label13)
        Me.gpxSelectLines.Controls.Add(Me.cmdSelectByReturn)
        Me.gpxSelectLines.Controls.Add(Me.Label20)
        Me.gpxSelectLines.Location = New System.Drawing.Point(29, 685)
        Me.gpxSelectLines.Name = "gpxSelectLines"
        Me.gpxSelectLines.Size = New System.Drawing.Size(329, 129)
        Me.gpxSelectLines.TabIndex = 12
        Me.gpxSelectLines.TabStop = False
        Me.gpxSelectLines.Text = "Select Lines"
        '
        'dtpReturnDate
        '
        Me.dtpReturnDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpReturnDate.Location = New System.Drawing.Point(118, 24)
        Me.dtpReturnDate.Name = "dtpReturnDate"
        Me.dtpReturnDate.Size = New System.Drawing.Size(191, 20)
        Me.dtpReturnDate.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(26, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 20)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Return Number"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSelectByReturn
        '
        Me.cmdSelectByReturn.Location = New System.Drawing.Point(238, 85)
        Me.cmdSelectByReturn.Name = "cmdSelectByReturn"
        Me.cmdSelectByReturn.Size = New System.Drawing.Size(71, 30)
        Me.cmdSelectByReturn.TabIndex = 15
        Me.cmdSelectByReturn.Text = "Select"
        Me.cmdSelectByReturn.UseVisualStyleBackColor = True
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'gpxTotals
        '
        Me.gpxTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxTotals.Controls.Add(Me.txtProductTotal)
        Me.gpxTotals.Controls.Add(Me.Label6)
        Me.gpxTotals.Controls.Add(Me.txtFreightTotal)
        Me.gpxTotals.Controls.Add(Me.Label8)
        Me.gpxTotals.Controls.Add(Me.Label9)
        Me.gpxTotals.Controls.Add(Me.txtSalesTaxTotal)
        Me.gpxTotals.Controls.Add(Me.Label7)
        Me.gpxTotals.Controls.Add(Me.txtReturnTotal)
        Me.gpxTotals.Location = New System.Drawing.Point(820, 583)
        Me.gpxTotals.Name = "gpxTotals"
        Me.gpxTotals.Size = New System.Drawing.Size(302, 177)
        Me.gpxTotals.TabIndex = 18
        Me.gpxTotals.TabStop = False
        Me.gpxTotals.Text = "Vendor Return Totals"
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BackColor = System.Drawing.Color.White
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductTotal.Enabled = False
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
        'txtSalesTaxTotal
        '
        Me.txtSalesTaxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTaxTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTaxTotal.Location = New System.Drawing.Point(135, 94)
        Me.txtSalesTaxTotal.Name = "txtSalesTaxTotal"
        Me.txtSalesTaxTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtSalesTaxTotal.TabIndex = 20
        Me.txtSalesTaxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 20)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Sales Tax"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReturnTotal
        '
        Me.txtReturnTotal.BackColor = System.Drawing.Color.White
        Me.txtReturnTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReturnTotal.Enabled = False
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
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
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
        Me.gpxApplyVendorReturn.TabIndex = 16
        Me.gpxApplyVendorReturn.TabStop = False
        Me.gpxApplyVendorReturn.Text = "Apply Vendor Return"
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
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(19, 106)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(124, 20)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Amount"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'cboOpenVoucher
        '
        Me.cboOpenVoucher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOpenVoucher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOpenVoucher.DataSource = Me.VendorReturnBindingSource
        Me.cboOpenVoucher.DisplayMember = "ReturnNumber"
        Me.cboOpenVoucher.FormattingEnabled = True
        Me.cboOpenVoucher.Location = New System.Drawing.Point(139, 76)
        Me.cboOpenVoucher.Name = "cboOpenVoucher"
        Me.cboOpenVoucher.Size = New System.Drawing.Size(164, 21)
        Me.cboOpenVoucher.TabIndex = 14
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
        'VendorClassTableAdapter
        '
        Me.VendorClassTableAdapter.ClearBeforeFill = True
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
        Me.tabLineControl.Size = New System.Drawing.Size(747, 522)
        Me.tabLineControl.TabIndex = 86
        '
        'tabVoucherLines
        '
        Me.tabVoucherLines.Controls.Add(Me.dgvVoucherLines)
        Me.tabVoucherLines.Location = New System.Drawing.Point(4, 22)
        Me.tabVoucherLines.Name = "tabVoucherLines"
        Me.tabVoucherLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabVoucherLines.Size = New System.Drawing.Size(739, 496)
        Me.tabVoucherLines.TabIndex = 0
        Me.tabVoucherLines.Text = "Voucher Lines"
        Me.tabVoucherLines.UseVisualStyleBackColor = True
        '
        'tabEditLines
        '
        Me.tabEditLines.Controls.Add(Me.GroupBox3)
        Me.tabEditLines.Controls.Add(Me.GroupBox2)
        Me.tabEditLines.Location = New System.Drawing.Point(4, 22)
        Me.tabEditLines.Name = "tabEditLines"
        Me.tabEditLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEditLines.Size = New System.Drawing.Size(739, 496)
        Me.tabEditLines.TabIndex = 1
        Me.tabEditLines.Text = "Edit / Add / Delete Lines"
        Me.tabEditLines.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.txtDeleteDescription)
        Me.GroupBox3.Controls.Add(Me.txtDeletePartNumber)
        Me.GroupBox3.Controls.Add(Me.cboDeleteLine)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.cmdDeleteLine)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Location = New System.Drawing.Point(371, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(308, 350)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Delete a Line"
        '
        'Label25
        '
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(9, 198)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(284, 78)
        Me.Label25.TabIndex = 85
        Me.Label25.Text = "To remove a line from this voucher, select the line number from the drop down box" & _
            " and press delete."
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDeleteDescription
        '
        Me.txtDeleteDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeleteDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeleteDescription.Location = New System.Drawing.Point(30, 95)
        Me.txtDeleteDescription.Name = "txtDeleteDescription"
        Me.txtDeleteDescription.Size = New System.Drawing.Size(262, 20)
        Me.txtDeleteDescription.TabIndex = 40
        Me.txtDeleteDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDeletePartNumber
        '
        Me.txtDeletePartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeletePartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeletePartNumber.Location = New System.Drawing.Point(101, 63)
        Me.txtDeletePartNumber.Name = "txtDeletePartNumber"
        Me.txtDeletePartNumber.Size = New System.Drawing.Size(191, 20)
        Me.txtDeletePartNumber.TabIndex = 39
        Me.txtDeletePartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboDeleteLine
        '
        Me.cboDeleteLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeleteLine.DataSource = Me.ReceiptOfInvoiceVoucherLinesBindingSource
        Me.cboDeleteLine.DisplayMember = "VoucherLine"
        Me.cboDeleteLine.FormattingEnabled = True
        Me.cboDeleteLine.Location = New System.Drawing.Point(164, 30)
        Me.cboDeleteLine.Name = "cboDeleteLine"
        Me.cboDeleteLine.Size = New System.Drawing.Size(129, 21)
        Me.cboDeleteLine.TabIndex = 38
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(26, 30)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(124, 20)
        Me.Label23.TabIndex = 81
        Me.Label23.Text = "Voucher Line #"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteLine.Location = New System.Drawing.Point(221, 136)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 41
        Me.cmdDeleteLine.Text = "Delete"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(27, 63)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(124, 20)
        Me.Label24.TabIndex = 83
        Me.Label24.Text = "Part #"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLongDescription)
        Me.GroupBox2.Controls.Add(Me.txtLineExtendedCost)
        Me.GroupBox2.Controls.Add(Me.txtLineCost)
        Me.GroupBox2.Controls.Add(Me.txtLineQuantity)
        Me.GroupBox2.Controls.Add(Me.cboPartnumber)
        Me.GroupBox2.Controls.Add(Me.cmdAddLine)
        Me.GroupBox2.Controls.Add(Me.cmdClearLines)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.cboPartDescription)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 350)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add a Line"
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLongDescription.Location = New System.Drawing.Point(23, 109)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(264, 64)
        Me.txtLongDescription.TabIndex = 32
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineExtendedCost
        '
        Me.txtLineExtendedCost.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtLineExtendedCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineExtendedCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineExtendedCost.Location = New System.Drawing.Point(139, 256)
        Me.txtLineExtendedCost.Name = "txtLineExtendedCost"
        Me.txtLineExtendedCost.ReadOnly = True
        Me.txtLineExtendedCost.Size = New System.Drawing.Size(148, 20)
        Me.txtLineExtendedCost.TabIndex = 35
        Me.txtLineExtendedCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineCost
        '
        Me.txtLineCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineCost.Location = New System.Drawing.Point(139, 222)
        Me.txtLineCost.Name = "txtLineCost"
        Me.txtLineCost.Size = New System.Drawing.Size(148, 20)
        Me.txtLineCost.TabIndex = 34
        Me.txtLineCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineQuantity
        '
        Me.txtLineQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineQuantity.Location = New System.Drawing.Point(139, 187)
        Me.txtLineQuantity.Name = "txtLineQuantity"
        Me.txtLineQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtLineQuantity.TabIndex = 33
        Me.txtLineQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPartnumber
        '
        Me.cboPartnumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartnumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartnumber.DataSource = Me.NonInventoryItemListBindingSource
        Me.cboPartnumber.DisplayMember = "ItemID"
        Me.cboPartnumber.FormattingEnabled = True
        Me.cboPartnumber.Location = New System.Drawing.Point(93, 31)
        Me.cboPartnumber.Name = "cboPartnumber"
        Me.cboPartnumber.Size = New System.Drawing.Size(194, 21)
        Me.cboPartnumber.TabIndex = 30
        '
        'NonInventoryItemListBindingSource
        '
        Me.NonInventoryItemListBindingSource.DataMember = "NonInventoryItemList"
        Me.NonInventoryItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdAddLine
        '
        Me.cmdAddLine.Location = New System.Drawing.Point(139, 296)
        Me.cmdAddLine.Name = "cmdAddLine"
        Me.cmdAddLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddLine.TabIndex = 36
        Me.cmdAddLine.Text = "Add Line"
        Me.cmdAddLine.UseVisualStyleBackColor = True
        '
        'cmdClearLines
        '
        Me.cmdClearLines.Location = New System.Drawing.Point(216, 296)
        Me.cmdClearLines.Name = "cmdClearLines"
        Me.cmdClearLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearLines.TabIndex = 37
        Me.cmdClearLines.Text = "Clear Lines"
        Me.cmdClearLines.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(20, 255)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(124, 20)
        Me.Label22.TabIndex = 86
        Me.Label22.Text = "Extended Cost"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(20, 221)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(124, 20)
        Me.Label21.TabIndex = 85
        Me.Label21.Text = "Unit Cost"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(20, 186)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(124, 20)
        Me.Label19.TabIndex = 84
        Me.Label19.Text = "Quantity"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.NonInventoryItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(23, 69)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(264, 21)
        Me.cboPartDescription.TabIndex = 31
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(20, 31)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 20)
        Me.Label18.TabIndex = 79
        Me.Label18.Text = "Part #"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NonInventoryItemListTableAdapter
        '
        Me.NonInventoryItemListTableAdapter.ClearBeforeFill = True
        '
        'APProcessReturns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
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
        Me.Name = "APProcessReturns"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Process Vendor Returns"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxBatchInfo.ResumeLayout(False)
        Me.gpxBatchInfo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorReturnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxSelectLines.ResumeLayout(False)
        Me.gpxSelectLines.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxTotals.ResumeLayout(False)
        Me.gpxTotals.PerformLayout()
        Me.gpxApplyVendorReturn.ResumeLayout(False)
        Me.gpxApplyVendorReturn.PerformLayout()
        Me.tabLineControl.ResumeLayout(False)
        Me.tabVoucherLines.ResumeLayout(False)
        Me.tabEditLines.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dtpReturnDateDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents dgvVoucherLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents cboReturnNumber As System.Windows.Forms.ComboBox
    Friend WithEvents VendorReturnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorReturnTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnTableAdapter
    Friend WithEvents ReceiptOfInvoiceVoucherLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceVoucherLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
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
    Friend WithEvents txtSalesTaxTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtReturnTotal As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearForm As System.Windows.Forms.Button
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents gpxApplyVendorReturn As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboOpenVoucher As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdSelectOpenPayables As System.Windows.Forms.Button
    Friend WithEvents txtApplyAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpReturnVoucherDateDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdEnterNew As System.Windows.Forms.Button
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents VendorClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
    Friend WithEvents tabLineControl As System.Windows.Forms.TabControl
    Friend WithEvents tabVoucherLines As System.Windows.Forms.TabPage
    Friend WithEvents tabEditLines As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents cmdAddLine As System.Windows.Forms.Button
    Friend WithEvents cmdClearLines As System.Windows.Forms.Button
    Friend WithEvents txtLineExtendedCost As System.Windows.Forms.TextBox
    Friend WithEvents txtLineCost As System.Windows.Forms.TextBox
    Friend WithEvents txtLineQuantity As System.Windows.Forms.TextBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartnumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents cboDeleteLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtDeleteDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtDeletePartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents NonInventoryItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NonInventoryItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
    Friend WithEvents txtReturnAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblReturnAmount As System.Windows.Forms.Label
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
    Friend WithEvents dtpReturnVoucherDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpReturnDate As System.Windows.Forms.TextBox
    Friend WithEvents lblCheckCode As System.Windows.Forms.Label
    Friend WithEvents cboCheckType As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents chkWhitePaper As System.Windows.Forms.CheckBox
End Class
