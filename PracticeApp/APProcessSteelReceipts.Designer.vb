<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APProcessSteelReceipts
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
        Me.SaveVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxBatchInfo = New System.Windows.Forms.GroupBox
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDivisionID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.gpxVoucherHeader = New System.Windows.Forms.GroupBox
        Me.txtDueDay = New System.Windows.Forms.TextBox
        Me.txtDueYear = New System.Windows.Forms.TextBox
        Me.txtDisDay = New System.Windows.Forms.TextBox
        Me.txtDueMonth = New System.Windows.Forms.TextBox
        Me.txtDisYear = New System.Windows.Forms.TextBox
        Me.txtRecDay = New System.Windows.Forms.TextBox
        Me.txtDisMonth = New System.Windows.Forms.TextBox
        Me.txtRecYear = New System.Windows.Forms.TextBox
        Me.txtInvDay = New System.Windows.Forms.TextBox
        Me.txtRecMonth = New System.Windows.Forms.TextBox
        Me.txtInvYear = New System.Windows.Forms.TextBox
        Me.cboCheckType = New System.Windows.Forms.ComboBox
        Me.txtInvMonth = New System.Windows.Forms.TextBox
        Me.dtpDueDate = New System.Windows.Forms.DateTimePicker
        Me.dtpDiscountDate = New System.Windows.Forms.DateTimePicker
        Me.dtpReceiptDate = New System.Windows.Forms.DateTimePicker
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.txtInvoiceAmount = New System.Windows.Forms.TextBox
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.PaymentTermsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.llLoadVendorWindow = New System.Windows.Forms.LinkLabel
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cmdGenerateVoucher = New System.Windows.Forms.Button
        Me.cboVoucherNumber = New System.Windows.Forms.ComboBox
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboBOL = New System.Windows.Forms.ComboBox
        Me.SteelReceivingLineQuery2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblBOL = New System.Windows.Forms.Label
        Me.cmdSelectByBOL = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxInvoiceTotals = New System.Windows.Forms.GroupBox
        Me.chkManualDiscount = New System.Windows.Forms.CheckBox
        Me.txtPurchaseTotal = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtTermDiscount = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtSalesTaxTotal = New System.Windows.Forms.TextBox
        Me.txtInvoiceTotal = New System.Windows.Forms.TextBox
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.gpxSelectLines = New System.Windows.Forms.GroupBox
        Me.grpDeleteLine = New System.Windows.Forms.GroupBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.cboDeleteLine = New System.Windows.Forms.ComboBox
        Me.ReceiptOfInvoiceVoucherLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblVoucherLine = New System.Windows.Forms.Label
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdEnterNewVoucher = New System.Windows.Forms.Button
        Me.tabVoucherLines = New System.Windows.Forms.TabControl
        Me.tabdgv = New System.Windows.Forms.TabPage
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
        Me.tabAddLine = New System.Windows.Forms.TabPage
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnterLine = New System.Windows.Forms.Button
        Me.cboDebitDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDebitAccount = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.NonInventoryItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.ReceiptOfInvoiceVoucherLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.PaymentTermsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
        Me.NonInventoryItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.SteelReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingHeaderTableTableAdapter
        Me.gpxVendorAddress = New System.Windows.Forms.GroupBox
        Me.txtRemitToAddress2 = New System.Windows.Forms.TextBox
        Me.cmdUpdateVendor = New System.Windows.Forms.Button
        Me.cmdReturnToMain = New System.Windows.Forms.Button
        Me.txtRemitToZip = New System.Windows.Forms.TextBox
        Me.txtRemitToState = New System.Windows.Forms.TextBox
        Me.txtRemitToCountry = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtRemitToCity = New System.Windows.Forms.TextBox
        Me.txtRemitToAddress1 = New System.Windows.Forms.TextBox
        Me.txtRemitToVendorID = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtRemitToVendorName = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSteelPONumber = New System.Windows.Forms.TextBox
        Me.SteelReceivingLineQuery2TableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingLineQuery2TableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxBatchInfo.SuspendLayout()
        Me.gpxVoucherHeader.SuspendLayout()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReceivingLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxInvoiceTotals.SuspendLayout()
        Me.gpxSelectLines.SuspendLayout()
        Me.grpDeleteLine.SuspendLayout()
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabVoucherLines.SuspendLayout()
        Me.tabdgv.SuspendLayout()
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAddLine.SuspendLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxVendorAddress.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveVoucherToolStripMenuItem, Me.PrintVoucherToolStripMenuItem, Me.DeleteVoucherToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveVoucherToolStripMenuItem
        '
        Me.SaveVoucherToolStripMenuItem.Name = "SaveVoucherToolStripMenuItem"
        Me.SaveVoucherToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.SaveVoucherToolStripMenuItem.Text = "Save Voucher"
        '
        'PrintVoucherToolStripMenuItem
        '
        Me.PrintVoucherToolStripMenuItem.Name = "PrintVoucherToolStripMenuItem"
        Me.PrintVoucherToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.PrintVoucherToolStripMenuItem.Text = "Print Voucher"
        '
        'DeleteVoucherToolStripMenuItem
        '
        Me.DeleteVoucherToolStripMenuItem.Name = "DeleteVoucherToolStripMenuItem"
        Me.DeleteVoucherToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.DeleteVoucherToolStripMenuItem.Text = "Delete Voucher"
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
        'gpxVoucherHeader
        '
        Me.gpxVoucherHeader.Controls.Add(Me.txtDueDay)
        Me.gpxVoucherHeader.Controls.Add(Me.txtDueYear)
        Me.gpxVoucherHeader.Controls.Add(Me.txtDisDay)
        Me.gpxVoucherHeader.Controls.Add(Me.txtDueMonth)
        Me.gpxVoucherHeader.Controls.Add(Me.txtDisYear)
        Me.gpxVoucherHeader.Controls.Add(Me.txtRecDay)
        Me.gpxVoucherHeader.Controls.Add(Me.txtDisMonth)
        Me.gpxVoucherHeader.Controls.Add(Me.txtRecYear)
        Me.gpxVoucherHeader.Controls.Add(Me.txtInvDay)
        Me.gpxVoucherHeader.Controls.Add(Me.txtRecMonth)
        Me.gpxVoucherHeader.Controls.Add(Me.txtInvYear)
        Me.gpxVoucherHeader.Controls.Add(Me.cboCheckType)
        Me.gpxVoucherHeader.Controls.Add(Me.txtInvMonth)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpDueDate)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpDiscountDate)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpReceiptDate)
        Me.gpxVoucherHeader.Controls.Add(Me.dtpInvoiceDate)
        Me.gpxVoucherHeader.Controls.Add(Me.txtInvoiceAmount)
        Me.gpxVoucherHeader.Controls.Add(Me.cboPaymentTerms)
        Me.gpxVoucherHeader.Controls.Add(Me.llLoadVendorWindow)
        Me.gpxVoucherHeader.Controls.Add(Me.Label25)
        Me.gpxVoucherHeader.Controls.Add(Me.Label4)
        Me.gpxVoucherHeader.Controls.Add(Me.Label2)
        Me.gpxVoucherHeader.Controls.Add(Me.txtComment)
        Me.gpxVoucherHeader.Controls.Add(Me.txtVendorName)
        Me.gpxVoucherHeader.Controls.Add(Me.cmdGenerateVoucher)
        Me.gpxVoucherHeader.Controls.Add(Me.cboVoucherNumber)
        Me.gpxVoucherHeader.Controls.Add(Me.Label5)
        Me.gpxVoucherHeader.Controls.Add(Me.cboVendorID)
        Me.gpxVoucherHeader.Controls.Add(Me.txtInvoiceNumber)
        Me.gpxVoucherHeader.Controls.Add(Me.Label20)
        Me.gpxVoucherHeader.Controls.Add(Me.Label17)
        Me.gpxVoucherHeader.Controls.Add(Me.Label16)
        Me.gpxVoucherHeader.Controls.Add(Me.Label8)
        Me.gpxVoucherHeader.Controls.Add(Me.Label24)
        Me.gpxVoucherHeader.Controls.Add(Me.Label6)
        Me.gpxVoucherHeader.Location = New System.Drawing.Point(29, 151)
        Me.gpxVoucherHeader.Name = "gpxVoucherHeader"
        Me.gpxVoucherHeader.Size = New System.Drawing.Size(329, 660)
        Me.gpxVoucherHeader.TabIndex = 0
        Me.gpxVoucherHeader.TabStop = False
        Me.gpxVoucherHeader.Text = "Steel Voucher Header Information"
        '
        'txtDueDay
        '
        Me.txtDueDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDueDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDueDay.Location = New System.Drawing.Point(178, 469)
        Me.txtDueDay.MaxLength = 2
        Me.txtDueDay.Name = "txtDueDay"
        Me.txtDueDay.Size = New System.Drawing.Size(45, 20)
        Me.txtDueDay.TabIndex = 19
        Me.txtDueDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDueYear
        '
        Me.txtDueYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDueYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDueYear.Location = New System.Drawing.Point(223, 469)
        Me.txtDueYear.MaxLength = 4
        Me.txtDueYear.Name = "txtDueYear"
        Me.txtDueYear.Size = New System.Drawing.Size(71, 20)
        Me.txtDueYear.TabIndex = 20
        Me.txtDueYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDisDay
        '
        Me.txtDisDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDisDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDisDay.Location = New System.Drawing.Point(178, 429)
        Me.txtDisDay.MaxLength = 2
        Me.txtDisDay.Name = "txtDisDay"
        Me.txtDisDay.Size = New System.Drawing.Size(45, 20)
        Me.txtDisDay.TabIndex = 16
        Me.txtDisDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDueMonth
        '
        Me.txtDueMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDueMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDueMonth.Location = New System.Drawing.Point(133, 469)
        Me.txtDueMonth.MaxLength = 2
        Me.txtDueMonth.Name = "txtDueMonth"
        Me.txtDueMonth.Size = New System.Drawing.Size(45, 20)
        Me.txtDueMonth.TabIndex = 18
        Me.txtDueMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDisYear
        '
        Me.txtDisYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDisYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDisYear.Location = New System.Drawing.Point(223, 429)
        Me.txtDisYear.MaxLength = 4
        Me.txtDisYear.Name = "txtDisYear"
        Me.txtDisYear.Size = New System.Drawing.Size(71, 20)
        Me.txtDisYear.TabIndex = 17
        Me.txtDisYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRecDay
        '
        Me.txtRecDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecDay.Location = New System.Drawing.Point(178, 354)
        Me.txtRecDay.MaxLength = 2
        Me.txtRecDay.Name = "txtRecDay"
        Me.txtRecDay.Size = New System.Drawing.Size(45, 20)
        Me.txtRecDay.TabIndex = 12
        Me.txtRecDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDisMonth
        '
        Me.txtDisMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDisMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDisMonth.Location = New System.Drawing.Point(133, 429)
        Me.txtDisMonth.MaxLength = 2
        Me.txtDisMonth.Name = "txtDisMonth"
        Me.txtDisMonth.Size = New System.Drawing.Size(45, 20)
        Me.txtDisMonth.TabIndex = 15
        Me.txtDisMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRecYear
        '
        Me.txtRecYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecYear.Location = New System.Drawing.Point(223, 354)
        Me.txtRecYear.MaxLength = 4
        Me.txtRecYear.Name = "txtRecYear"
        Me.txtRecYear.Size = New System.Drawing.Size(71, 20)
        Me.txtRecYear.TabIndex = 13
        Me.txtRecYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtInvDay
        '
        Me.txtInvDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvDay.Location = New System.Drawing.Point(178, 265)
        Me.txtInvDay.MaxLength = 2
        Me.txtInvDay.Name = "txtInvDay"
        Me.txtInvDay.Size = New System.Drawing.Size(45, 20)
        Me.txtInvDay.TabIndex = 8
        Me.txtInvDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRecMonth
        '
        Me.txtRecMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecMonth.Location = New System.Drawing.Point(133, 354)
        Me.txtRecMonth.MaxLength = 2
        Me.txtRecMonth.Name = "txtRecMonth"
        Me.txtRecMonth.Size = New System.Drawing.Size(45, 20)
        Me.txtRecMonth.TabIndex = 11
        Me.txtRecMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtInvYear
        '
        Me.txtInvYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvYear.Location = New System.Drawing.Point(223, 265)
        Me.txtInvYear.MaxLength = 4
        Me.txtInvYear.Name = "txtInvYear"
        Me.txtInvYear.Size = New System.Drawing.Size(71, 20)
        Me.txtInvYear.TabIndex = 9
        Me.txtInvYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboCheckType
        '
        Me.cboCheckType.FormattingEnabled = True
        Me.cboCheckType.Items.AddRange(New Object() {"STANDARD", "FEDEX", "INTERCOMPANY", "ACH"})
        Me.cboCheckType.Location = New System.Drawing.Point(133, 195)
        Me.cboCheckType.Name = "cboCheckType"
        Me.cboCheckType.Size = New System.Drawing.Size(180, 21)
        Me.cboCheckType.TabIndex = 5
        '
        'txtInvMonth
        '
        Me.txtInvMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvMonth.Location = New System.Drawing.Point(133, 265)
        Me.txtInvMonth.MaxLength = 2
        Me.txtInvMonth.Name = "txtInvMonth"
        Me.txtInvMonth.Size = New System.Drawing.Size(45, 20)
        Me.txtInvMonth.TabIndex = 7
        Me.txtInvMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpDueDate
        '
        Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDueDate.Location = New System.Drawing.Point(138, 469)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpDueDate.TabIndex = 80
        Me.dtpDueDate.TabStop = False
        '
        'dtpDiscountDate
        '
        Me.dtpDiscountDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDiscountDate.Location = New System.Drawing.Point(138, 429)
        Me.dtpDiscountDate.Name = "dtpDiscountDate"
        Me.dtpDiscountDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpDiscountDate.TabIndex = 80
        Me.dtpDiscountDate.TabStop = False
        '
        'dtpReceiptDate
        '
        Me.dtpReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReceiptDate.Location = New System.Drawing.Point(138, 354)
        Me.dtpReceiptDate.Name = "dtpReceiptDate"
        Me.dtpReceiptDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpReceiptDate.TabIndex = 80
        Me.dtpReceiptDate.TabStop = False
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(138, 265)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpInvoiceDate.TabIndex = 80
        Me.dtpInvoiceDate.TabStop = False
        '
        'txtInvoiceAmount
        '
        Me.txtInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceAmount.Location = New System.Drawing.Point(133, 301)
        Me.txtInvoiceAmount.Name = "txtInvoiceAmount"
        Me.txtInvoiceAmount.Size = New System.Drawing.Size(180, 20)
        Me.txtInvoiceAmount.TabIndex = 10
        Me.txtInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.DataSource = Me.PaymentTermsBindingSource
        Me.cboPaymentTerms.DisplayMember = "PmtTermsID"
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Location = New System.Drawing.Point(133, 393)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(180, 21)
        Me.cboPaymentTerms.TabIndex = 14
        '
        'PaymentTermsBindingSource
        '
        Me.PaymentTermsBindingSource.DataMember = "PaymentTerms"
        Me.PaymentTermsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'llLoadVendorWindow
        '
        Me.llLoadVendorWindow.Location = New System.Drawing.Point(18, 74)
        Me.llLoadVendorWindow.Name = "llLoadVendorWindow"
        Me.llLoadVendorWindow.Size = New System.Drawing.Size(69, 21)
        Me.llLoadVendorWindow.TabIndex = 82
        Me.llLoadVendorWindow.TabStop = True
        Me.llLoadVendorWindow.Text = "Vendor"
        Me.llLoadVendorWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(21, 469)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(124, 20)
        Me.Label25.TabIndex = 77
        Me.Label25.Text = "Due Date"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(21, 301)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 20)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Invoice Amount"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 504)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 20)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Voucher Comment"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(24, 527)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(291, 115)
        Me.txtComment.TabIndex = 21
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorName.Location = New System.Drawing.Point(21, 111)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(291, 66)
        Me.txtVendorName.TabIndex = 4
        Me.txtVendorName.TabStop = False
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGenerateVoucher
        '
        Me.cmdGenerateVoucher.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateVoucher.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateVoucher.Location = New System.Drawing.Point(88, 34)
        Me.cmdGenerateVoucher.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateVoucher.Name = "cmdGenerateVoucher"
        Me.cmdGenerateVoucher.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateVoucher.TabIndex = 1
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
        Me.cboVoucherNumber.Location = New System.Drawing.Point(120, 34)
        Me.cboVoucherNumber.Name = "cboVoucherNumber"
        Me.cboVoucherNumber.Size = New System.Drawing.Size(192, 21)
        Me.cboVoucherNumber.TabIndex = 2
        '
        'ReceiptOfInvoiceBatchLineBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataMember = "ReceiptOfInvoiceBatchLine"
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(21, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Voucher #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(88, 74)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(224, 21)
        Me.cboVendorID.TabIndex = 3
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(89, 231)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(224, 20)
        Me.txtInvoiceNumber.TabIndex = 6
        Me.txtInvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(21, 265)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(124, 20)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "Invoice Date"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(21, 354)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(124, 20)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "Receipt Date"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(21, 392)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 20)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Payment Terms"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(21, 231)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 20)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Invoice #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(21, 429)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(124, 20)
        Me.Label24.TabIndex = 35
        Me.Label24.Text = "Discount Date"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(21, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 20)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Check Type"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBOL
        '
        Me.cboBOL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBOL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBOL.DataSource = Me.SteelReceivingLineQuery2BindingSource
        Me.cboBOL.DisplayMember = "SteelBOLNumber"
        Me.cboBOL.FormattingEnabled = True
        Me.cboBOL.Location = New System.Drawing.Point(66, 35)
        Me.cboBOL.Name = "cboBOL"
        Me.cboBOL.Size = New System.Drawing.Size(184, 21)
        Me.cboBOL.TabIndex = 23
        '
        'SteelReceivingLineQuery2BindingSource
        '
        Me.SteelReceivingLineQuery2BindingSource.DataMember = "SteelReceivingLineQuery2"
        Me.SteelReceivingLineQuery2BindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelReceivingHeaderTableBindingSource
        '
        Me.SteelReceivingHeaderTableBindingSource.DataMember = "SteelReceivingHeaderTable"
        Me.SteelReceivingHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblBOL
        '
        Me.lblBOL.Location = New System.Drawing.Point(17, 35)
        Me.lblBOL.Name = "lblBOL"
        Me.lblBOL.Size = New System.Drawing.Size(177, 20)
        Me.lblBOL.TabIndex = 14
        Me.lblBOL.Text = "BOL #"
        Me.lblBOL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSelectByBOL
        '
        Me.cmdSelectByBOL.Location = New System.Drawing.Point(266, 30)
        Me.cmdSelectByBOL.Name = "cmdSelectByBOL"
        Me.cmdSelectByBOL.Size = New System.Drawing.Size(71, 30)
        Me.cmdSelectByBOL.TabIndex = 24
        Me.cmdSelectByBOL.Text = "Add Lines"
        Me.cmdSelectByBOL.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 27
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(905, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 26
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(828, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 25
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 28
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxInvoiceTotals
        '
        Me.gpxInvoiceTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxInvoiceTotals.Controls.Add(Me.chkManualDiscount)
        Me.gpxInvoiceTotals.Controls.Add(Me.txtPurchaseTotal)
        Me.gpxInvoiceTotals.Controls.Add(Me.Label22)
        Me.gpxInvoiceTotals.Controls.Add(Me.Label21)
        Me.gpxInvoiceTotals.Controls.Add(Me.Label19)
        Me.gpxInvoiceTotals.Controls.Add(Me.txtTermDiscount)
        Me.gpxInvoiceTotals.Controls.Add(Me.Label18)
        Me.gpxInvoiceTotals.Controls.Add(Me.txtSalesTaxTotal)
        Me.gpxInvoiceTotals.Controls.Add(Me.txtInvoiceTotal)
        Me.gpxInvoiceTotals.Controls.Add(Me.txtFreightTotal)
        Me.gpxInvoiceTotals.Location = New System.Drawing.Point(828, 592)
        Me.gpxInvoiceTotals.Name = "gpxInvoiceTotals"
        Me.gpxInvoiceTotals.Size = New System.Drawing.Size(302, 164)
        Me.gpxInvoiceTotals.TabIndex = 21
        Me.gpxInvoiceTotals.TabStop = False
        Me.gpxInvoiceTotals.Text = "Invoice Totals"
        '
        'chkManualDiscount
        '
        Me.chkManualDiscount.AutoSize = True
        Me.chkManualDiscount.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkManualDiscount.Location = New System.Drawing.Point(19, 136)
        Me.chkManualDiscount.Name = "chkManualDiscount"
        Me.chkManualDiscount.Size = New System.Drawing.Size(106, 17)
        Me.chkManualDiscount.TabIndex = 24
        Me.chkManualDiscount.Text = "Manual Discount"
        Me.chkManualDiscount.UseVisualStyleBackColor = True
        '
        'txtPurchaseTotal
        '
        Me.txtPurchaseTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseTotal.Location = New System.Drawing.Point(138, 26)
        Me.txtPurchaseTotal.Name = "txtPurchaseTotal"
        Me.txtPurchaseTotal.ReadOnly = True
        Me.txtPurchaseTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtPurchaseTotal.TabIndex = 24
        Me.txtPurchaseTotal.TabStop = False
        Me.txtPurchaseTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(19, 80)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(117, 20)
        Me.Label22.TabIndex = 68
        Me.Label22.Text = "Sales Tax"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(19, 53)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(95, 20)
        Me.Label21.TabIndex = 66
        Me.Label21.Text = "Freight"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(19, 26)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(95, 20)
        Me.Label19.TabIndex = 64
        Me.Label19.Text = "Purchase Total"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTermDiscount
        '
        Me.txtTermDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTermDiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTermDiscount.Enabled = False
        Me.txtTermDiscount.Location = New System.Drawing.Point(138, 133)
        Me.txtTermDiscount.Name = "txtTermDiscount"
        Me.txtTermDiscount.Size = New System.Drawing.Size(148, 20)
        Me.txtTermDiscount.TabIndex = 28
        Me.txtTermDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(19, 107)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 20)
        Me.Label18.TabIndex = 62
        Me.Label18.Text = "Invoice Total"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTaxTotal
        '
        Me.txtSalesTaxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTaxTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesTaxTotal.Location = New System.Drawing.Point(138, 80)
        Me.txtSalesTaxTotal.Name = "txtSalesTaxTotal"
        Me.txtSalesTaxTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtSalesTaxTotal.TabIndex = 23
        Me.txtSalesTaxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInvoiceTotal
        '
        Me.txtInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceTotal.Location = New System.Drawing.Point(138, 107)
        Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
        Me.txtInvoiceTotal.ReadOnly = True
        Me.txtInvoiceTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtInvoiceTotal.TabIndex = 27
        Me.txtInvoiceTotal.TabStop = False
        Me.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightTotal.Location = New System.Drawing.Point(138, 53)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.Size = New System.Drawing.Size(148, 20)
        Me.txtFreightTotal.TabIndex = 22
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gpxSelectLines
        '
        Me.gpxSelectLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxSelectLines.Controls.Add(Me.cboBOL)
        Me.gpxSelectLines.Controls.Add(Me.lblBOL)
        Me.gpxSelectLines.Controls.Add(Me.cmdSelectByBOL)
        Me.gpxSelectLines.Location = New System.Drawing.Point(379, 41)
        Me.gpxSelectLines.Name = "gpxSelectLines"
        Me.gpxSelectLines.Size = New System.Drawing.Size(353, 75)
        Me.gpxSelectLines.TabIndex = 22
        Me.gpxSelectLines.TabStop = False
        Me.gpxSelectLines.Text = "Select Lines"
        '
        'grpDeleteLine
        '
        Me.grpDeleteLine.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.grpDeleteLine.Controls.Add(Me.Label26)
        Me.grpDeleteLine.Controls.Add(Me.cboDeleteLine)
        Me.grpDeleteLine.Controls.Add(Me.lblVoucherLine)
        Me.grpDeleteLine.Controls.Add(Me.cmdDeleteLine)
        Me.grpDeleteLine.Location = New System.Drawing.Point(379, 592)
        Me.grpDeleteLine.Name = "grpDeleteLine"
        Me.grpDeleteLine.Size = New System.Drawing.Size(337, 127)
        Me.grpDeleteLine.TabIndex = 16
        Me.grpDeleteLine.TabStop = False
        Me.grpDeleteLine.Text = "Delete Line from Voucher"
        '
        'Label26
        '
        Me.Label26.ForeColor = System.Drawing.Color.Blue
        Me.Label26.Location = New System.Drawing.Point(17, 66)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(205, 40)
        Me.Label26.TabIndex = 67
        Me.Label26.Text = "To delete a line from the grid, select Line # from drop down box and hit Delete B" & _
            "utton."
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDeleteLine
        '
        Me.cboDeleteLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeleteLine.DataSource = Me.ReceiptOfInvoiceVoucherLinesBindingSource
        Me.cboDeleteLine.DisplayMember = "VoucherLine"
        Me.cboDeleteLine.FormattingEnabled = True
        Me.cboDeleteLine.Location = New System.Drawing.Point(132, 31)
        Me.cboDeleteLine.Name = "cboDeleteLine"
        Me.cboDeleteLine.Size = New System.Drawing.Size(177, 21)
        Me.cboDeleteLine.TabIndex = 17
        '
        'ReceiptOfInvoiceVoucherLinesBindingSource
        '
        Me.ReceiptOfInvoiceVoucherLinesBindingSource.DataMember = "ReceiptOfInvoiceVoucherLines"
        Me.ReceiptOfInvoiceVoucherLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblVoucherLine
        '
        Me.lblVoucherLine.Location = New System.Drawing.Point(17, 32)
        Me.lblVoucherLine.Name = "lblVoucherLine"
        Me.lblVoucherLine.Size = New System.Drawing.Size(94, 20)
        Me.lblVoucherLine.TabIndex = 14
        Me.lblVoucherLine.Text = "Voucher Line #"
        Me.lblVoucherLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Location = New System.Drawing.Point(238, 66)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 18
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(457, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 20
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdEnterNewVoucher
        '
        Me.cmdEnterNewVoucher.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEnterNewVoucher.Location = New System.Drawing.Point(380, 771)
        Me.cmdEnterNewVoucher.Name = "cmdEnterNewVoucher"
        Me.cmdEnterNewVoucher.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnterNewVoucher.TabIndex = 19
        Me.cmdEnterNewVoucher.Text = "Enter New Voucher"
        Me.cmdEnterNewVoucher.UseVisualStyleBackColor = True
        '
        'tabVoucherLines
        '
        Me.tabVoucherLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabVoucherLines.Controls.Add(Me.tabdgv)
        Me.tabVoucherLines.Controls.Add(Me.tabAddLine)
        Me.tabVoucherLines.Location = New System.Drawing.Point(399, 122)
        Me.tabVoucherLines.Multiline = True
        Me.tabVoucherLines.Name = "tabVoucherLines"
        Me.tabVoucherLines.SelectedIndex = 0
        Me.tabVoucherLines.Size = New System.Drawing.Size(754, 464)
        Me.tabVoucherLines.TabIndex = 42
        '
        'tabdgv
        '
        Me.tabdgv.BackColor = System.Drawing.Color.Transparent
        Me.tabdgv.Controls.Add(Me.dgvVoucherLines)
        Me.tabdgv.Location = New System.Drawing.Point(4, 22)
        Me.tabdgv.Name = "tabdgv"
        Me.tabdgv.Padding = New System.Windows.Forms.Padding(3)
        Me.tabdgv.Size = New System.Drawing.Size(746, 438)
        Me.tabdgv.TabIndex = 0
        Me.tabdgv.Text = "Lines"
        Me.tabdgv.UseVisualStyleBackColor = True
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
        Me.dgvVoucherLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvVoucherLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVoucherLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VoucherNumberColumn, Me.VoucherLineColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn, Me.SelectForInvoiceColumn, Me.ReceiverNumberColumn, Me.ReceiverLineColumn, Me.DivisionIDColumn})
        Me.dgvVoucherLines.DataSource = Me.ReceiptOfInvoiceVoucherLinesBindingSource
        Me.dgvVoucherLines.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvVoucherLines.Location = New System.Drawing.Point(0, 0)
        Me.dgvVoucherLines.Name = "dgvVoucherLines"
        Me.dgvVoucherLines.Size = New System.Drawing.Size(746, 438)
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
        Me.VoucherLineColumn.Width = 60
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        Me.PartNumberColumn.Width = 150
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 90
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle2.Format = "N5"
        DataGridViewCellStyle2.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 90
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
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'tabAddLine
        '
        Me.tabAddLine.BackColor = System.Drawing.Color.Transparent
        Me.tabAddLine.Controls.Add(Me.txtExtendedAmount)
        Me.tabAddLine.Controls.Add(Me.txtQuantity)
        Me.tabAddLine.Controls.Add(Me.txtUnitCost)
        Me.tabAddLine.Controls.Add(Me.cmdClear)
        Me.tabAddLine.Controls.Add(Me.cmdEnterLine)
        Me.tabAddLine.Controls.Add(Me.cboDebitDescription)
        Me.tabAddLine.Controls.Add(Me.cboDebitAccount)
        Me.tabAddLine.Controls.Add(Me.Label27)
        Me.tabAddLine.Controls.Add(Me.cboPartNumber)
        Me.tabAddLine.Controls.Add(Me.Label15)
        Me.tabAddLine.Controls.Add(Me.Label9)
        Me.tabAddLine.Controls.Add(Me.Label14)
        Me.tabAddLine.Controls.Add(Me.Label10)
        Me.tabAddLine.Controls.Add(Me.Label11)
        Me.tabAddLine.Controls.Add(Me.txtLongDescription)
        Me.tabAddLine.Location = New System.Drawing.Point(4, 22)
        Me.tabAddLine.Name = "tabAddLine"
        Me.tabAddLine.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAddLine.Size = New System.Drawing.Size(746, 438)
        Me.tabAddLine.TabIndex = 1
        Me.tabAddLine.Text = "Add Manual Line"
        Me.tabAddLine.UseVisualStyleBackColor = True
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BackColor = System.Drawing.Color.White
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedAmount.Location = New System.Drawing.Point(125, 242)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.ReadOnly = True
        Me.txtExtendedAmount.Size = New System.Drawing.Size(182, 20)
        Me.txtExtendedAmount.TabIndex = 110
        Me.txtExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantity.Location = New System.Drawing.Point(125, 182)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(182, 20)
        Me.txtQuantity.TabIndex = 108
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitCost.Location = New System.Drawing.Point(125, 212)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(182, 20)
        Me.txtUnitCost.TabIndex = 109
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(236, 382)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 114
        Me.cmdClear.Text = "Clear Lines"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnterLine
        '
        Me.cmdEnterLine.Location = New System.Drawing.Point(159, 382)
        Me.cmdEnterLine.Name = "cmdEnterLine"
        Me.cmdEnterLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnterLine.TabIndex = 113
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
        Me.cboDebitDescription.Location = New System.Drawing.Point(19, 338)
        Me.cboDebitDescription.Name = "cboDebitDescription"
        Me.cboDebitDescription.Size = New System.Drawing.Size(288, 21)
        Me.cboDebitDescription.TabIndex = 112
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
        Me.cboDebitAccount.Location = New System.Drawing.Point(125, 307)
        Me.cboDebitAccount.Name = "cboDebitAccount"
        Me.cboDebitAccount.Size = New System.Drawing.Size(182, 21)
        Me.cboDebitAccount.TabIndex = 111
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(19, 307)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(139, 20)
        Me.Label27.TabIndex = 120
        Me.Label27.Text = "Debit Account"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.NonInventoryItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(65, 22)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(242, 21)
        Me.cboPartNumber.TabIndex = 106
        '
        'NonInventoryItemListBindingSource
        '
        Me.NonInventoryItemListBindingSource.DataMember = "NonInventoryItemList"
        Me.NonInventoryItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(19, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(151, 20)
        Me.Label15.TabIndex = 115
        Me.Label15.Text = "Item"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(19, 242)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 20)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "Extended Cost"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(19, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(151, 20)
        Me.Label14.TabIndex = 116
        Me.Label14.Text = "Description"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(19, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 20)
        Me.Label10.TabIndex = 118
        Me.Label10.Text = "Unit Cost"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(19, 182)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(139, 20)
        Me.Label11.TabIndex = 117
        Me.Label11.Text = "Quantity"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLongDescription.Location = New System.Drawing.Point(19, 80)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(288, 72)
        Me.txtLongDescription.TabIndex = 107
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ReceiptOfInvoiceVoucherLinesTableAdapter
        '
        Me.ReceiptOfInvoiceVoucherLinesTableAdapter.ClearBeforeFill = True
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
        'NonInventoryItemListTableAdapter
        '
        Me.NonInventoryItemListTableAdapter.ClearBeforeFill = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'SteelReceivingHeaderTableTableAdapter
        '
        Me.SteelReceivingHeaderTableTableAdapter.ClearBeforeFill = True
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
        Me.gpxVendorAddress.Controls.Add(Me.Label7)
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
        Me.gpxVendorAddress.TabIndex = 68
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
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 367)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 20)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Country"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtSteelPONumber)
        Me.GroupBox1.Location = New System.Drawing.Point(856, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(274, 75)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Steel PO # for selected BOL"
        '
        'txtSteelPONumber
        '
        Me.txtSteelPONumber.BackColor = System.Drawing.Color.White
        Me.txtSteelPONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelPONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelPONumber.Location = New System.Drawing.Point(35, 35)
        Me.txtSteelPONumber.Name = "txtSteelPONumber"
        Me.txtSteelPONumber.ReadOnly = True
        Me.txtSteelPONumber.Size = New System.Drawing.Size(212, 20)
        Me.txtSteelPONumber.TabIndex = 26
        Me.txtSteelPONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SteelReceivingLineQuery2TableAdapter
        '
        Me.SteelReceivingLineQuery2TableAdapter.ClearBeforeFill = True
        '
        'APProcessSteelReceipts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tabVoucherLines)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdEnterNewVoucher)
        Me.Controls.Add(Me.grpDeleteLine)
        Me.Controls.Add(Me.gpxInvoiceTotals)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxSelectLines)
        Me.Controls.Add(Me.gpxVoucherHeader)
        Me.Controls.Add(Me.gpxBatchInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.gpxVendorAddress)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "APProcessSteelReceipts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TFP Corporation Process Steel Receipts"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxBatchInfo.ResumeLayout(False)
        Me.gpxBatchInfo.PerformLayout()
        Me.gpxVoucherHeader.ResumeLayout(False)
        Me.gpxVoucherHeader.PerformLayout()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReceivingLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxInvoiceTotals.ResumeLayout(False)
        Me.gpxInvoiceTotals.PerformLayout()
        Me.gpxSelectLines.ResumeLayout(False)
        Me.grpDeleteLine.ResumeLayout(False)
        CType(Me.ReceiptOfInvoiceVoucherLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabVoucherLines.ResumeLayout(False)
        Me.tabdgv.ResumeLayout(False)
        CType(Me.dgvVoucherLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAddLine.ResumeLayout(False)
        Me.tabAddLine.PerformLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NonInventoryItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxVendorAddress.ResumeLayout(False)
        Me.gpxVendorAddress.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gpxVoucherHeader As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
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
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboBOL As System.Windows.Forms.ComboBox
    Friend WithEvents lblBOL As System.Windows.Forms.Label
    Friend WithEvents cmdSelectByBOL As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxInvoiceTotals As System.Windows.Forms.GroupBox
    Friend WithEvents txtPurchaseTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtTermDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSalesTaxTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtFreightTotal As System.Windows.Forms.TextBox
    Friend WithEvents SaveVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteVoucherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxSelectLines As System.Windows.Forms.GroupBox
    Friend WithEvents grpDeleteLine As System.Windows.Forms.GroupBox
    Friend WithEvents cboDeleteLine As System.Windows.Forms.ComboBox
    Friend WithEvents lblVoucherLine As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdEnterNewVoucher As System.Windows.Forms.Button
    Friend WithEvents chkManualDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents tabVoucherLines As System.Windows.Forms.TabControl
    Friend WithEvents tabdgv As System.Windows.Forms.TabPage
    Friend WithEvents tabAddLine As System.Windows.Forms.TabPage
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnterLine As System.Windows.Forms.Button
    Friend WithEvents cboDebitDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDebitAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDiscountDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReceiptDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvVoucherLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceiptOfInvoiceVoucherLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceVoucherLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceVoucherLinesTableAdapter
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents PaymentTermsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PaymentTermsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
    Friend WithEvents NonInventoryItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NonInventoryItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.NonInventoryItemListTableAdapter
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents SteelReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingHeaderTableTableAdapter
    Friend WithEvents gpxVendorAddress As System.Windows.Forms.GroupBox
    Friend WithEvents txtRemitToAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdateVendor As System.Windows.Forms.Button
    Friend WithEvents cmdReturnToMain As System.Windows.Forms.Button
    Friend WithEvents txtRemitToZip As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToState As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtRemitToCity As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRemitToVendorID As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtRemitToVendorName As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents llLoadVendorWindow As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSteelPONumber As System.Windows.Forms.TextBox
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
    Friend WithEvents SteelReceivingLineQuery2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingLineQuery2TableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingLineQuery2TableAdapter
    Friend WithEvents cboCheckType As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtInvDay As System.Windows.Forms.TextBox
    Friend WithEvents txtInvYear As System.Windows.Forms.TextBox
    Friend WithEvents txtInvMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtRecDay As System.Windows.Forms.TextBox
    Friend WithEvents txtRecYear As System.Windows.Forms.TextBox
    Friend WithEvents txtRecMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtDueDay As System.Windows.Forms.TextBox
    Friend WithEvents txtDueYear As System.Windows.Forms.TextBox
    Friend WithEvents txtDisDay As System.Windows.Forms.TextBox
    Friend WithEvents txtDueMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtDisYear As System.Windows.Forms.TextBox
    Friend WithEvents txtDisMonth As System.Windows.Forms.TextBox
End Class
