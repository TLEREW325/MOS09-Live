<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaintainRecurringVouchers
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
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxVoucherInfo = New System.Windows.Forms.GroupBox
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.txtSalesTax = New System.Windows.Forms.TextBox
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.txtDiscount = New System.Windows.Forms.TextBox
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.txtInvoiceAmount = New System.Windows.Forms.TextBox
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.lblProductTotal = New System.Windows.Forms.Label
        Me.lblSalesTax = New System.Windows.Forms.Label
        Me.lblFreightCharge = New System.Windows.Forms.Label
        Me.lblDiscountAmount = New System.Windows.Forms.Label
        Me.lblPaymentTerms = New System.Windows.Forms.Label
        Me.lblInvoiceTotal = New System.Windows.Forms.Label
        Me.lblInvoiceNumber = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.lblVendorName = New System.Windows.Forms.Label
        Me.lblVendorClass = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.dtpLastModifiedDate = New System.Windows.Forms.DateTimePicker
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.lblRecurringBatchNumber = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdSaveBatch = New System.Windows.Forms.Button
        Me.cmdCreateNew = New System.Windows.Forms.Button
        Me.tabCtrl = New System.Windows.Forms.TabControl
        Me.tabOccurrences = New System.Windows.Forms.TabPage
        Me.pnlNewDateTime = New System.Windows.Forms.Panel
        Me.dtpChangeDate = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.dgvRecurrences = New System.Windows.Forms.DataGridView
        Me.tabLines = New System.Windows.Forms.TabPage
        Me.dgvLines = New System.Windows.Forms.DataGridView
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboItemID = New System.Windows.Forms.ComboBox
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.lblItemID = New System.Windows.Forms.Label
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboLineNumber = New System.Windows.Forms.ComboBox
        Me.lblLineNumber = New System.Windows.Forms.Label
        Me.cmdSaveLineChanges = New System.Windows.Forms.Button
        Me.cboDeleteVoucherNumber = New System.Windows.Forms.ComboBox
        Me.lblDeleteOccurrence = New System.Windows.Forms.Label
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdDeleteRecurrence = New System.Windows.Forms.Button
        Me.grpDeleteRecurrence = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cboDebitDescription = New System.Windows.Forms.ComboBox
        Me.cboDebitAccount = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cboCreditDescription = New System.Windows.Forms.ComboBox
        Me.cboCreditAccount = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.tabCtrlLines = New System.Windows.Forms.TabControl
        Me.tabAddLine = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboAddItemID = New System.Windows.Forms.ComboBox
        Me.txtAddExtendedCost = New System.Windows.Forms.TextBox
        Me.cmdClearAddLines = New System.Windows.Forms.Button
        Me.txtAddUnitCost = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdEnterLine = New System.Windows.Forms.Button
        Me.txtAddQuantity = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAddDescription = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.tabEditLine = New System.Windows.Forms.TabPage
        Me.lblRowNumber = New System.Windows.Forms.Label
        Me.dtpNotificationTime = New System.Windows.Forms.DateTimePicker
        Me.lblNotificationTime = New System.Windows.Forms.Label
        Me.dtpNotificationDate = New System.Windows.Forms.DateTimePicker
        Me.lblNotificationDate = New System.Windows.Forms.Label
        Me.gpxVoucherInfo.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.tabCtrl.SuspendLayout()
        Me.tabOccurrences.SuspendLayout()
        Me.pnlNewDateTime.SuspendLayout()
        CType(Me.dgvRecurrences, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLines.SuspendLayout()
        CType(Me.dgvLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDeleteRecurrence.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tabCtrlLines.SuspendLayout()
        Me.tabAddLine.SuspendLayout()
        Me.tabEditLine.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 723)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 26
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(805, 723)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 25
        Me.cmdDelete.Text = "Delete Batch"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 723)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 27
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxVoucherInfo
        '
        Me.gpxVoucherInfo.Controls.Add(Me.txtProductTotal)
        Me.gpxVoucherInfo.Controls.Add(Me.txtSalesTax)
        Me.gpxVoucherInfo.Controls.Add(Me.txtFreightTotal)
        Me.gpxVoucherInfo.Controls.Add(Me.txtDiscount)
        Me.gpxVoucherInfo.Controls.Add(Me.cboPaymentTerms)
        Me.gpxVoucherInfo.Controls.Add(Me.txtInvoiceAmount)
        Me.gpxVoucherInfo.Controls.Add(Me.txtInvoiceNumber)
        Me.gpxVoucherInfo.Controls.Add(Me.cboVendorClass)
        Me.gpxVoucherInfo.Controls.Add(Me.lblProductTotal)
        Me.gpxVoucherInfo.Controls.Add(Me.lblSalesTax)
        Me.gpxVoucherInfo.Controls.Add(Me.lblFreightCharge)
        Me.gpxVoucherInfo.Controls.Add(Me.lblDiscountAmount)
        Me.gpxVoucherInfo.Controls.Add(Me.lblPaymentTerms)
        Me.gpxVoucherInfo.Controls.Add(Me.lblInvoiceTotal)
        Me.gpxVoucherInfo.Controls.Add(Me.lblInvoiceNumber)
        Me.gpxVoucherInfo.Controls.Add(Me.txtVendorName)
        Me.gpxVoucherInfo.Controls.Add(Me.lblVendorName)
        Me.gpxVoucherInfo.Controls.Add(Me.lblVendorClass)
        Me.gpxVoucherInfo.Controls.Add(Me.Label7)
        Me.gpxVoucherInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxVoucherInfo.Controls.Add(Me.dtpLastModifiedDate)
        Me.gpxVoucherInfo.Controls.Add(Me.cboBatchNumber)
        Me.gpxVoucherInfo.Controls.Add(Me.lblRecurringBatchNumber)
        Me.gpxVoucherInfo.Controls.Add(Me.Label8)
        Me.gpxVoucherInfo.Controls.Add(Me.txtComment)
        Me.gpxVoucherInfo.Controls.Add(Me.cboVendorID)
        Me.gpxVoucherInfo.Controls.Add(Me.Label10)
        Me.gpxVoucherInfo.Controls.Add(Me.Label16)
        Me.gpxVoucherInfo.Location = New System.Drawing.Point(12, 45)
        Me.gpxVoucherInfo.Name = "gpxVoucherInfo"
        Me.gpxVoucherInfo.Size = New System.Drawing.Size(314, 708)
        Me.gpxVoucherInfo.TabIndex = 0
        Me.gpxVoucherInfo.TabStop = False
        Me.gpxVoucherInfo.Text = "Voucher Information"
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.Location = New System.Drawing.Point(104, 356)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.ReadOnly = True
        Me.txtProductTotal.Size = New System.Drawing.Size(189, 20)
        Me.txtProductTotal.TabIndex = 128
        Me.txtProductTotal.TabStop = False
        '
        'txtSalesTax
        '
        Me.txtSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax.Location = New System.Drawing.Point(104, 420)
        Me.txtSalesTax.Name = "txtSalesTax"
        Me.txtSalesTax.Size = New System.Drawing.Size(189, 20)
        Me.txtSalesTax.TabIndex = 126
        Me.txtSalesTax.TabStop = False
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightTotal.Location = New System.Drawing.Point(104, 388)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.Size = New System.Drawing.Size(189, 20)
        Me.txtFreightTotal.TabIndex = 124
        Me.txtFreightTotal.TabStop = False
        '
        'txtDiscount
        '
        Me.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscount.Location = New System.Drawing.Point(104, 452)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(189, 20)
        Me.txtDiscount.TabIndex = 122
        Me.txtDiscount.TabStop = False
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Location = New System.Drawing.Point(104, 323)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(189, 21)
        Me.cboPaymentTerms.TabIndex = 121
        '
        'txtInvoiceAmount
        '
        Me.txtInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceAmount.Location = New System.Drawing.Point(104, 484)
        Me.txtInvoiceAmount.Name = "txtInvoiceAmount"
        Me.txtInvoiceAmount.ReadOnly = True
        Me.txtInvoiceAmount.Size = New System.Drawing.Size(189, 20)
        Me.txtInvoiceAmount.TabIndex = 117
        Me.txtInvoiceAmount.TabStop = False
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(104, 291)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.ReadOnly = True
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(189, 20)
        Me.txtInvoiceNumber.TabIndex = 115
        Me.txtInvoiceNumber.TabStop = False
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.DisplayMember = "VendorCode"
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(104, 258)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(189, 21)
        Me.cboVendorClass.TabIndex = 111
        '
        'lblProductTotal
        '
        Me.lblProductTotal.Location = New System.Drawing.Point(10, 356)
        Me.lblProductTotal.Name = "lblProductTotal"
        Me.lblProductTotal.Size = New System.Drawing.Size(87, 20)
        Me.lblProductTotal.TabIndex = 129
        Me.lblProductTotal.Text = "Product Total"
        Me.lblProductTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSalesTax
        '
        Me.lblSalesTax.Location = New System.Drawing.Point(10, 420)
        Me.lblSalesTax.Name = "lblSalesTax"
        Me.lblSalesTax.Size = New System.Drawing.Size(87, 20)
        Me.lblSalesTax.TabIndex = 127
        Me.lblSalesTax.Text = "Sales Tax"
        Me.lblSalesTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFreightCharge
        '
        Me.lblFreightCharge.Location = New System.Drawing.Point(10, 388)
        Me.lblFreightCharge.Name = "lblFreightCharge"
        Me.lblFreightCharge.Size = New System.Drawing.Size(87, 20)
        Me.lblFreightCharge.TabIndex = 125
        Me.lblFreightCharge.Text = "Freight"
        Me.lblFreightCharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDiscountAmount
        '
        Me.lblDiscountAmount.Location = New System.Drawing.Point(10, 452)
        Me.lblDiscountAmount.Name = "lblDiscountAmount"
        Me.lblDiscountAmount.Size = New System.Drawing.Size(87, 20)
        Me.lblDiscountAmount.TabIndex = 123
        Me.lblDiscountAmount.Text = "Discount"
        Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPaymentTerms
        '
        Me.lblPaymentTerms.Location = New System.Drawing.Point(10, 324)
        Me.lblPaymentTerms.Name = "lblPaymentTerms"
        Me.lblPaymentTerms.Size = New System.Drawing.Size(87, 20)
        Me.lblPaymentTerms.TabIndex = 120
        Me.lblPaymentTerms.Text = "Payment Terms"
        Me.lblPaymentTerms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInvoiceTotal
        '
        Me.lblInvoiceTotal.Location = New System.Drawing.Point(10, 484)
        Me.lblInvoiceTotal.Name = "lblInvoiceTotal"
        Me.lblInvoiceTotal.Size = New System.Drawing.Size(104, 20)
        Me.lblInvoiceTotal.TabIndex = 118
        Me.lblInvoiceTotal.Text = "Total Per Invoice"
        Me.lblInvoiceTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInvoiceNumber
        '
        Me.lblInvoiceNumber.Location = New System.Drawing.Point(10, 291)
        Me.lblInvoiceNumber.Name = "lblInvoiceNumber"
        Me.lblInvoiceNumber.Size = New System.Drawing.Size(87, 20)
        Me.lblInvoiceNumber.TabIndex = 116
        Me.lblInvoiceNumber.Text = "Invoice Number"
        Me.lblInvoiceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendorName.Location = New System.Drawing.Point(13, 194)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(286, 49)
        Me.txtVendorName.TabIndex = 114
        Me.txtVendorName.TabStop = False
        '
        'lblVendorName
        '
        Me.lblVendorName.Location = New System.Drawing.Point(11, 171)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(87, 20)
        Me.lblVendorName.TabIndex = 113
        Me.lblVendorName.Text = "Vendor Name"
        Me.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVendorClass
        '
        Me.lblVendorClass.Location = New System.Drawing.Point(10, 259)
        Me.lblVendorClass.Name = "lblVendorClass"
        Me.lblVendorClass.Size = New System.Drawing.Size(87, 20)
        Me.lblVendorClass.TabIndex = 112
        Me.lblVendorClass.Text = "Vendor Class"
        Me.lblVendorClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(11, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 20)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Division ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(141, 27)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(153, 21)
        Me.cboDivisionID.TabIndex = 2
        '
        'dtpLastModifiedDate
        '
        Me.dtpLastModifiedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLastModifiedDate.Location = New System.Drawing.Point(141, 101)
        Me.dtpLastModifiedDate.Name = "dtpLastModifiedDate"
        Me.dtpLastModifiedDate.Size = New System.Drawing.Size(153, 20)
        Me.dtpLastModifiedDate.TabIndex = 3
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(141, 63)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(153, 21)
        Me.cboBatchNumber.TabIndex = 1
        '
        'lblRecurringBatchNumber
        '
        Me.lblRecurringBatchNumber.Location = New System.Drawing.Point(11, 63)
        Me.lblRecurringBatchNumber.Name = "lblRecurringBatchNumber"
        Me.lblRecurringBatchNumber.Size = New System.Drawing.Size(129, 20)
        Me.lblRecurringBatchNumber.TabIndex = 106
        Me.lblRecurringBatchNumber.Text = "Recurring Batch Number"
        Me.lblRecurringBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 536)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(173, 20)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "Recurring Voucher Comment"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(15, 557)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(278, 123)
        Me.txtComment.TabIndex = 12
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(99, 142)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(195, 21)
        Me.cboVendorID.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(11, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(124, 20)
        Me.Label10.TabIndex = 78
        Me.Label10.Text = "Vendor ID"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(11, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 20)
        Me.Label16.TabIndex = 110
        Me.Label16.Text = "Last Modified Date"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(805, 677)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 21
        Me.cmdClear.Text = "Clear All"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 96
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
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
        'cmdSaveBatch
        '
        Me.cmdSaveBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveBatch.Location = New System.Drawing.Point(959, 677)
        Me.cmdSaveBatch.Name = "cmdSaveBatch"
        Me.cmdSaveBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveBatch.TabIndex = 23
        Me.cmdSaveBatch.Text = "Save Batch"
        Me.cmdSaveBatch.UseVisualStyleBackColor = True
        '
        'cmdCreateNew
        '
        Me.cmdCreateNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCreateNew.Location = New System.Drawing.Point(882, 677)
        Me.cmdCreateNew.Name = "cmdCreateNew"
        Me.cmdCreateNew.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateNew.TabIndex = 22
        Me.cmdCreateNew.Text = "Create New"
        Me.cmdCreateNew.UseVisualStyleBackColor = True
        '
        'tabCtrl
        '
        Me.tabCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabCtrl.Controls.Add(Me.tabOccurrences)
        Me.tabCtrl.Controls.Add(Me.tabLines)
        Me.tabCtrl.Location = New System.Drawing.Point(349, 27)
        Me.tabCtrl.Name = "tabCtrl"
        Me.tabCtrl.SelectedIndex = 0
        Me.tabCtrl.Size = New System.Drawing.Size(681, 411)
        Me.tabCtrl.TabIndex = 97
        '
        'tabOccurrences
        '
        Me.tabOccurrences.Controls.Add(Me.pnlNewDateTime)
        Me.tabOccurrences.Controls.Add(Me.dgvRecurrences)
        Me.tabOccurrences.Location = New System.Drawing.Point(4, 22)
        Me.tabOccurrences.Name = "tabOccurrences"
        Me.tabOccurrences.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOccurrences.Size = New System.Drawing.Size(673, 385)
        Me.tabOccurrences.TabIndex = 0
        Me.tabOccurrences.Text = "Occurrences"
        Me.tabOccurrences.UseVisualStyleBackColor = True
        '
        'pnlNewDateTime
        '
        Me.pnlNewDateTime.Controls.Add(Me.dtpChangeDate)
        Me.pnlNewDateTime.Controls.Add(Me.Label14)
        Me.pnlNewDateTime.Location = New System.Drawing.Point(323, 229)
        Me.pnlNewDateTime.Name = "pnlNewDateTime"
        Me.pnlNewDateTime.Size = New System.Drawing.Size(165, 66)
        Me.pnlNewDateTime.TabIndex = 109
        Me.pnlNewDateTime.Visible = False
        '
        'dtpChangeDate
        '
        Me.dtpChangeDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpChangeDate.Location = New System.Drawing.Point(19, 34)
        Me.dtpChangeDate.Margin = New System.Windows.Forms.Padding(7)
        Me.dtpChangeDate.Name = "dtpChangeDate"
        Me.dtpChangeDate.Size = New System.Drawing.Size(131, 20)
        Me.dtpChangeDate.TabIndex = 30
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Change Date"
        '
        'dgvRecurrences
        '
        Me.dgvRecurrences.AllowUserToAddRows = False
        Me.dgvRecurrences.AllowUserToDeleteRows = False
        Me.dgvRecurrences.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRecurrences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRecurrences.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvRecurrences.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRecurrences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecurrences.Location = New System.Drawing.Point(0, 0)
        Me.dgvRecurrences.Name = "dgvRecurrences"
        Me.dgvRecurrences.ReadOnly = True
        Me.dgvRecurrences.Size = New System.Drawing.Size(673, 385)
        Me.dgvRecurrences.TabIndex = 0
        '
        'tabLines
        '
        Me.tabLines.Controls.Add(Me.dgvLines)
        Me.tabLines.Location = New System.Drawing.Point(4, 22)
        Me.tabLines.Name = "tabLines"
        Me.tabLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLines.Size = New System.Drawing.Size(673, 385)
        Me.tabLines.TabIndex = 1
        Me.tabLines.Text = "Lines"
        '
        'dgvLines
        '
        Me.dgvLines.AllowUserToAddRows = False
        Me.dgvLines.AllowUserToDeleteRows = False
        Me.dgvLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLines.Location = New System.Drawing.Point(0, 0)
        Me.dgvLines.Name = "dgvLines"
        Me.dgvLines.ReadOnly = True
        Me.dgvLines.Size = New System.Drawing.Size(673, 337)
        Me.dgvLines.TabIndex = 0
        Me.dgvLines.TabStop = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(40, 209)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 20)
        Me.Label18.TabIndex = 101
        Me.Label18.Text = "Extended Cost"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemID
        '
        Me.cboItemID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemID.FormattingEnabled = True
        Me.cboItemID.Location = New System.Drawing.Point(131, 33)
        Me.cboItemID.Name = "cboItemID"
        Me.cboItemID.Size = New System.Drawing.Size(197, 21)
        Me.cboItemID.TabIndex = 90
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedAmount.Location = New System.Drawing.Point(180, 209)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.ReadOnly = True
        Me.txtExtendedAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtExtendedAmount.TabIndex = 95
        Me.txtExtendedAmount.TabStop = False
        Me.txtExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitCost.Location = New System.Drawing.Point(180, 180)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(148, 20)
        Me.txtUnitCost.TabIndex = 93
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblItemID
        '
        Me.lblItemID.Location = New System.Drawing.Point(35, 32)
        Me.lblItemID.Name = "lblItemID"
        Me.lblItemID.Size = New System.Drawing.Size(124, 20)
        Me.lblItemID.TabIndex = 97
        Me.lblItemID.Text = "Item"
        Me.lblItemID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantity.Location = New System.Drawing.Point(180, 151)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtQuantity.TabIndex = 92
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(40, 180)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 20)
        Me.Label19.TabIndex = 100
        Me.Label19.Text = "Unit Cost"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Location = New System.Drawing.Point(57, 84)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(271, 58)
        Me.txtDescription.TabIndex = 91
        Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(40, 151)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 20)
        Me.Label21.TabIndex = 99
        Me.Label21.Text = "Quantity"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(37, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 20)
        Me.Label13.TabIndex = 98
        Me.Label13.Text = "Description"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLineNumber
        '
        Me.cboLineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLineNumber.FormattingEnabled = True
        Me.cboLineNumber.Location = New System.Drawing.Point(180, 6)
        Me.cboLineNumber.Name = "cboLineNumber"
        Me.cboLineNumber.Size = New System.Drawing.Size(148, 21)
        Me.cboLineNumber.TabIndex = 102
        '
        'lblLineNumber
        '
        Me.lblLineNumber.Location = New System.Drawing.Point(37, 6)
        Me.lblLineNumber.Name = "lblLineNumber"
        Me.lblLineNumber.Size = New System.Drawing.Size(124, 20)
        Me.lblLineNumber.TabIndex = 103
        Me.lblLineNumber.Text = "Line Number"
        Me.lblLineNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSaveLineChanges
        '
        Me.cmdSaveLineChanges.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveLineChanges.Location = New System.Drawing.Point(257, 235)
        Me.cmdSaveLineChanges.Name = "cmdSaveLineChanges"
        Me.cmdSaveLineChanges.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveLineChanges.TabIndex = 98
        Me.cmdSaveLineChanges.Text = "Save Line Changes"
        Me.cmdSaveLineChanges.UseVisualStyleBackColor = True
        '
        'cboDeleteVoucherNumber
        '
        Me.cboDeleteVoucherNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteVoucherNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeleteVoucherNumber.FormattingEnabled = True
        Me.cboDeleteVoucherNumber.Location = New System.Drawing.Point(151, 22)
        Me.cboDeleteVoucherNumber.Name = "cboDeleteVoucherNumber"
        Me.cboDeleteVoucherNumber.Size = New System.Drawing.Size(153, 21)
        Me.cboDeleteVoucherNumber.TabIndex = 122
        '
        'lblDeleteOccurrence
        '
        Me.lblDeleteOccurrence.Location = New System.Drawing.Point(6, 21)
        Me.lblDeleteOccurrence.Name = "lblDeleteOccurrence"
        Me.lblDeleteOccurrence.Size = New System.Drawing.Size(151, 20)
        Me.lblDeleteOccurrence.TabIndex = 122
        Me.lblDeleteOccurrence.Text = "Occurrence Voucher #"
        Me.lblDeleteOccurrence.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(151, 49)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(153, 20)
        Me.dtpInvoiceDate.TabIndex = 122
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 20)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Invoice  Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteRecurrence
        '
        Me.cmdDeleteRecurrence.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteRecurrence.Location = New System.Drawing.Point(233, 75)
        Me.cmdDeleteRecurrence.Name = "cmdDeleteRecurrence"
        Me.cmdDeleteRecurrence.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteRecurrence.TabIndex = 98
        Me.cmdDeleteRecurrence.Text = "Delete Recurrence"
        Me.cmdDeleteRecurrence.UseVisualStyleBackColor = True
        '
        'grpDeleteRecurrence
        '
        Me.grpDeleteRecurrence.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDeleteRecurrence.Controls.Add(Me.cmdDeleteRecurrence)
        Me.grpDeleteRecurrence.Controls.Add(Me.cboDeleteVoucherNumber)
        Me.grpDeleteRecurrence.Controls.Add(Me.dtpInvoiceDate)
        Me.grpDeleteRecurrence.Controls.Add(Me.lblDeleteOccurrence)
        Me.grpDeleteRecurrence.Controls.Add(Me.Label2)
        Me.grpDeleteRecurrence.Location = New System.Drawing.Point(708, 546)
        Me.grpDeleteRecurrence.Name = "grpDeleteRecurrence"
        Me.grpDeleteRecurrence.Size = New System.Drawing.Size(322, 125)
        Me.grpDeleteRecurrence.TabIndex = 98
        Me.grpDeleteRecurrence.TabStop = False
        Me.grpDeleteRecurrence.Text = "Delete Recurrence"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.cboDebitDescription)
        Me.GroupBox5.Controls.Add(Me.cboDebitAccount)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Location = New System.Drawing.Point(708, 454)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(322, 84)
        Me.GroupBox5.TabIndex = 104
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GL Account Information"
        '
        'cboDebitDescription
        '
        Me.cboDebitDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDebitDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDebitDescription.FormattingEnabled = True
        Me.cboDebitDescription.Location = New System.Drawing.Point(43, 50)
        Me.cboDebitDescription.Name = "cboDebitDescription"
        Me.cboDebitDescription.Size = New System.Drawing.Size(261, 21)
        Me.cboDebitDescription.TabIndex = 20
        '
        'cboDebitAccount
        '
        Me.cboDebitAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDebitAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDebitAccount.FormattingEnabled = True
        Me.cboDebitAccount.Location = New System.Drawing.Point(122, 22)
        Me.cboDebitAccount.Name = "cboDebitAccount"
        Me.cboDebitAccount.Size = New System.Drawing.Size(182, 21)
        Me.cboDebitAccount.TabIndex = 19
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(6, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 20)
        Me.Label22.TabIndex = 85
        Me.Label22.Text = "Debit Account"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCreditDescription
        '
        Me.cboCreditDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCreditDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCreditDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCreditDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboCreditDescription.Enabled = False
        Me.cboCreditDescription.FormattingEnabled = True
        Me.cboCreditDescription.Location = New System.Drawing.Point(732, 517)
        Me.cboCreditDescription.Name = "cboCreditDescription"
        Me.cboCreditDescription.Size = New System.Drawing.Size(261, 21)
        Me.cboCreditDescription.TabIndex = 106
        '
        'cboCreditAccount
        '
        Me.cboCreditAccount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCreditAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCreditAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCreditAccount.DisplayMember = "GLAccountNumber"
        Me.cboCreditAccount.Enabled = False
        Me.cboCreditAccount.FormattingEnabled = True
        Me.cboCreditAccount.Location = New System.Drawing.Point(811, 490)
        Me.cboCreditAccount.Name = "cboCreditAccount"
        Me.cboCreditAccount.Size = New System.Drawing.Size(182, 21)
        Me.cboCreditAccount.TabIndex = 105
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(729, 491)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Credit Account"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteLine.Location = New System.Drawing.Point(180, 235)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 104
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'tabCtrlLines
        '
        Me.tabCtrlLines.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.tabCtrlLines.Controls.Add(Me.tabAddLine)
        Me.tabCtrlLines.Controls.Add(Me.tabEditLine)
        Me.tabCtrlLines.Location = New System.Drawing.Point(349, 441)
        Me.tabCtrlLines.Name = "tabCtrlLines"
        Me.tabCtrlLines.SelectedIndex = 0
        Me.tabCtrlLines.Size = New System.Drawing.Size(353, 312)
        Me.tabCtrlLines.TabIndex = 108
        '
        'tabAddLine
        '
        Me.tabAddLine.BackColor = System.Drawing.SystemColors.Control
        Me.tabAddLine.Controls.Add(Me.Label1)
        Me.tabAddLine.Controls.Add(Me.cboAddItemID)
        Me.tabAddLine.Controls.Add(Me.txtAddExtendedCost)
        Me.tabAddLine.Controls.Add(Me.cmdClearAddLines)
        Me.tabAddLine.Controls.Add(Me.txtAddUnitCost)
        Me.tabAddLine.Controls.Add(Me.Label12)
        Me.tabAddLine.Controls.Add(Me.cmdEnterLine)
        Me.tabAddLine.Controls.Add(Me.txtAddQuantity)
        Me.tabAddLine.Controls.Add(Me.Label4)
        Me.tabAddLine.Controls.Add(Me.txtAddDescription)
        Me.tabAddLine.Controls.Add(Me.Label5)
        Me.tabAddLine.Controls.Add(Me.Label6)
        Me.tabAddLine.Location = New System.Drawing.Point(4, 22)
        Me.tabAddLine.Name = "tabAddLine"
        Me.tabAddLine.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAddLine.Size = New System.Drawing.Size(345, 286)
        Me.tabAddLine.TabIndex = 0
        Me.tabAddLine.Text = "Add Line"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(36, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Extended Cost"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAddItemID
        '
        Me.cboAddItemID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAddItemID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAddItemID.FormattingEnabled = True
        Me.cboAddItemID.Location = New System.Drawing.Point(127, 21)
        Me.cboAddItemID.Name = "cboAddItemID"
        Me.cboAddItemID.Size = New System.Drawing.Size(197, 21)
        Me.cboAddItemID.TabIndex = 90
        '
        'txtAddExtendedCost
        '
        Me.txtAddExtendedCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddExtendedCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddExtendedCost.Location = New System.Drawing.Point(176, 197)
        Me.txtAddExtendedCost.Name = "txtAddExtendedCost"
        Me.txtAddExtendedCost.ReadOnly = True
        Me.txtAddExtendedCost.Size = New System.Drawing.Size(148, 20)
        Me.txtAddExtendedCost.TabIndex = 95
        Me.txtAddExtendedCost.TabStop = False
        Me.txtAddExtendedCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClearAddLines
        '
        Me.cmdClearAddLines.Location = New System.Drawing.Point(253, 236)
        Me.cmdClearAddLines.Name = "cmdClearAddLines"
        Me.cmdClearAddLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAddLines.TabIndex = 96
        Me.cmdClearAddLines.Text = "Clear"
        Me.cmdClearAddLines.UseVisualStyleBackColor = True
        '
        'txtAddUnitCost
        '
        Me.txtAddUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddUnitCost.Location = New System.Drawing.Point(176, 168)
        Me.txtAddUnitCost.Name = "txtAddUnitCost"
        Me.txtAddUnitCost.Size = New System.Drawing.Size(148, 20)
        Me.txtAddUnitCost.TabIndex = 93
        Me.txtAddUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(36, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(124, 20)
        Me.Label12.TabIndex = 97
        Me.Label12.Text = "Item"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdEnterLine
        '
        Me.cmdEnterLine.Location = New System.Drawing.Point(176, 236)
        Me.cmdEnterLine.Name = "cmdEnterLine"
        Me.cmdEnterLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnterLine.TabIndex = 94
        Me.cmdEnterLine.Text = "Enter Line"
        Me.cmdEnterLine.UseVisualStyleBackColor = True
        '
        'txtAddQuantity
        '
        Me.txtAddQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddQuantity.Location = New System.Drawing.Point(176, 139)
        Me.txtAddQuantity.Name = "txtAddQuantity"
        Me.txtAddQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtAddQuantity.TabIndex = 92
        Me.txtAddQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(36, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Unit Cost"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddDescription
        '
        Me.txtAddDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddDescription.Location = New System.Drawing.Point(36, 72)
        Me.txtAddDescription.Multiline = True
        Me.txtAddDescription.Name = "txtAddDescription"
        Me.txtAddDescription.Size = New System.Drawing.Size(288, 58)
        Me.txtAddDescription.TabIndex = 91
        Me.txtAddDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(36, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Quantity"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(36, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 20)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "Description"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabEditLine
        '
        Me.tabEditLine.BackColor = System.Drawing.SystemColors.Control
        Me.tabEditLine.Controls.Add(Me.cmdDeleteLine)
        Me.tabEditLine.Controls.Add(Me.cmdSaveLineChanges)
        Me.tabEditLine.Controls.Add(Me.cboItemID)
        Me.tabEditLine.Controls.Add(Me.cboLineNumber)
        Me.tabEditLine.Controls.Add(Me.lblItemID)
        Me.tabEditLine.Controls.Add(Me.lblLineNumber)
        Me.tabEditLine.Controls.Add(Me.txtUnitCost)
        Me.tabEditLine.Controls.Add(Me.Label13)
        Me.tabEditLine.Controls.Add(Me.txtQuantity)
        Me.tabEditLine.Controls.Add(Me.Label21)
        Me.tabEditLine.Controls.Add(Me.txtExtendedAmount)
        Me.tabEditLine.Controls.Add(Me.Label18)
        Me.tabEditLine.Controls.Add(Me.Label19)
        Me.tabEditLine.Controls.Add(Me.txtDescription)
        Me.tabEditLine.Location = New System.Drawing.Point(4, 22)
        Me.tabEditLine.Name = "tabEditLine"
        Me.tabEditLine.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEditLine.Size = New System.Drawing.Size(345, 286)
        Me.tabEditLine.TabIndex = 1
        Me.tabEditLine.Text = "Edit Line"
        '
        'lblRowNumber
        '
        Me.lblRowNumber.AutoSize = True
        Me.lblRowNumber.Location = New System.Drawing.Point(136, 14)
        Me.lblRowNumber.Name = "lblRowNumber"
        Me.lblRowNumber.Size = New System.Drawing.Size(0, 13)
        Me.lblRowNumber.TabIndex = 33
        Me.lblRowNumber.Visible = False
        '
        'dtpNotificationTime
        '
        Me.dtpNotificationTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpNotificationTime.Location = New System.Drawing.Point(47, 81)
        Me.dtpNotificationTime.Margin = New System.Windows.Forms.Padding(7)
        Me.dtpNotificationTime.Name = "dtpNotificationTime"
        Me.dtpNotificationTime.ShowUpDown = True
        Me.dtpNotificationTime.Size = New System.Drawing.Size(131, 20)
        Me.dtpNotificationTime.TabIndex = 32
        '
        'lblNotificationTime
        '
        Me.lblNotificationTime.AutoSize = True
        Me.lblNotificationTime.Location = New System.Drawing.Point(16, 61)
        Me.lblNotificationTime.Name = "lblNotificationTime"
        Me.lblNotificationTime.Size = New System.Drawing.Size(86, 13)
        Me.lblNotificationTime.TabIndex = 31
        Me.lblNotificationTime.Text = "Notification Time"
        '
        'dtpNotificationDate
        '
        Me.dtpNotificationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNotificationDate.Location = New System.Drawing.Point(47, 34)
        Me.dtpNotificationDate.Margin = New System.Windows.Forms.Padding(7)
        Me.dtpNotificationDate.Name = "dtpNotificationDate"
        Me.dtpNotificationDate.Size = New System.Drawing.Size(131, 20)
        Me.dtpNotificationDate.TabIndex = 30
        '
        'lblNotificationDate
        '
        Me.lblNotificationDate.AutoSize = True
        Me.lblNotificationDate.Location = New System.Drawing.Point(16, 14)
        Me.lblNotificationDate.Name = "lblNotificationDate"
        Me.lblNotificationDate.Size = New System.Drawing.Size(86, 13)
        Me.lblNotificationDate.TabIndex = 29
        Me.lblNotificationDate.Text = "Notification Date"
        '
        'MaintainRecurringVouchers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 773)
        Me.Controls.Add(Me.tabCtrlLines)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.cboCreditDescription)
        Me.Controls.Add(Me.cboCreditAccount)
        Me.Controls.Add(Me.grpDeleteRecurrence)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tabCtrl)
        Me.Controls.Add(Me.cmdSaveBatch)
        Me.Controls.Add(Me.cmdCreateNew)
        Me.Controls.Add(Me.gpxVoucherInfo)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdClear)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MaintainRecurringVouchers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Recurring Vouchers"
        Me.gpxVoucherInfo.ResumeLayout(False)
        Me.gpxVoucherInfo.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tabCtrl.ResumeLayout(False)
        Me.tabOccurrences.ResumeLayout(False)
        Me.pnlNewDateTime.ResumeLayout(False)
        Me.pnlNewDateTime.PerformLayout()
        CType(Me.dgvRecurrences, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLines.ResumeLayout(False)
        CType(Me.dgvLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDeleteRecurrence.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.tabCtrlLines.ResumeLayout(False)
        Me.tabAddLine.ResumeLayout(False)
        Me.tabAddLine.PerformLayout()
        Me.tabEditLine.ResumeLayout(False)
        Me.tabEditLine.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxVoucherInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents CycleLengthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRecurringBatchNumber As System.Windows.Forms.Label
    Friend WithEvents cboBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VoucherNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillingDayOfMonthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillingStartDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecurringAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CycleRepetitionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpLastModifiedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdSaveBatch As System.Windows.Forms.Button
    Friend WithEvents cmdCreateNew As System.Windows.Forms.Button
    Friend WithEvents lblVendorClass As System.Windows.Forms.Label
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents lblVendorName As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoiceTotal As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoiceNumber As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents lblPaymentTerms As System.Windows.Forms.Label
    Friend WithEvents tabCtrl As System.Windows.Forms.TabControl
    Friend WithEvents tabOccurrences As System.Windows.Forms.TabPage
    Friend WithEvents tabLines As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboItemID As System.Windows.Forms.ComboBox
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents lblItemID As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblLineNumber As System.Windows.Forms.Label
    Friend WithEvents cboLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSaveLineChanges As System.Windows.Forms.Button
    Friend WithEvents lblDeleteOccurrence As System.Windows.Forms.Label
    Friend WithEvents cboDeleteVoucherNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDeleteRecurrence As System.Windows.Forms.Button
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpDeleteRecurrence As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDebitDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDebitAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboCreditDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboCreditAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvRecurrences As System.Windows.Forms.DataGridView
    Friend WithEvents dgvLines As System.Windows.Forms.DataGridView
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents lblProductTotal As System.Windows.Forms.Label
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblSalesTax As System.Windows.Forms.Label
    Friend WithEvents txtSalesTax As System.Windows.Forms.TextBox
    Friend WithEvents lblFreightCharge As System.Windows.Forms.Label
    Friend WithEvents txtFreightTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblDiscountAmount As System.Windows.Forms.Label
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents tabCtrlLines As System.Windows.Forms.TabControl
    Friend WithEvents tabAddLine As System.Windows.Forms.TabPage
    Friend WithEvents tabEditLine As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboAddItemID As System.Windows.Forms.ComboBox
    Friend WithEvents txtAddExtendedCost As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearAddLines As System.Windows.Forms.Button
    Friend WithEvents txtAddUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdEnterLine As System.Windows.Forms.Button
    Friend WithEvents txtAddQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAddDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblRowNumber As System.Windows.Forms.Label
    Friend WithEvents dtpNotificationTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNotificationTime As System.Windows.Forms.Label
    Friend WithEvents dtpNotificationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNotificationDate As System.Windows.Forms.Label
    Friend WithEvents pnlNewDateTime As System.Windows.Forms.Panel
    Friend WithEvents dtpChangeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
