<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewVoucherListing
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gpxAPVoucherData = New System.Windows.Forms.GroupBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.chkViewDeleted = New System.Windows.Forms.CheckBox
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboVoucherNumber2 = New System.Windows.Forms.ComboBox
        Me.ReceiptOfInvoiceBatchLinePDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.VendorClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.rdoPostDate = New System.Windows.Forms.RadioButton
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rdoReceiptDate = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.rdoInvoiceDate = New System.Windows.Forms.RadioButton
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.lblDateFilter = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewAllOpenUnpostedVouchersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.VoucherLines = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.dgvBatchLinePostDate = New System.Windows.Forms.DataGridView
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PostingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherSourceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeleteReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptOfInvoiceBatchLinePDTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLinePDTableAdapter
        Me.VendorClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
        Me.cboVoucherNumber = New System.Windows.Forms.ComboBox
        Me.dgvDeletedVouchers = New System.Windows.Forms.DataGridView
        Me.VendorIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceFreightColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSalesTaxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptDateColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorClassColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherSourceColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeleteReferenceNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeleteVoucherHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DeleteVoucherHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DeleteVoucherHeaderTableTableAdapter
        Me.gpxAPVoucherData.SuspendLayout()
        CType(Me.ReceiptOfInvoiceBatchLinePDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvBatchLinePostDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDeletedVouchers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeleteVoucherHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxAPVoucherData
        '
        Me.gpxAPVoucherData.Controls.Add(Me.cboStatus)
        Me.gpxAPVoucherData.Controls.Add(Me.Label11)
        Me.gpxAPVoucherData.Controls.Add(Me.chkViewDeleted)
        Me.gpxAPVoucherData.Controls.Add(Me.txtTextFilter)
        Me.gpxAPVoucherData.Controls.Add(Me.Label10)
        Me.gpxAPVoucherData.Controls.Add(Me.cboVoucherNumber2)
        Me.gpxAPVoucherData.Controls.Add(Me.Label5)
        Me.gpxAPVoucherData.Controls.Add(Me.Label12)
        Me.gpxAPVoucherData.Controls.Add(Me.cboVendorClass)
        Me.gpxAPVoucherData.Controls.Add(Me.Label4)
        Me.gpxAPVoucherData.Controls.Add(Me.Label14)
        Me.gpxAPVoucherData.Controls.Add(Me.chkDateRange)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdClear)
        Me.gpxAPVoucherData.Controls.Add(Me.txtInvoiceNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdViewByFilter)
        Me.gpxAPVoucherData.Controls.Add(Me.Label7)
        Me.gpxAPVoucherData.Controls.Add(Me.Label9)
        Me.gpxAPVoucherData.Controls.Add(Me.rdoPostDate)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPONumber)
        Me.gpxAPVoucherData.Controls.Add(Me.rdoReceiptDate)
        Me.gpxAPVoucherData.Controls.Add(Me.Label2)
        Me.gpxAPVoucherData.Controls.Add(Me.rdoInvoiceDate)
        Me.gpxAPVoucherData.Controls.Add(Me.txtVendorName)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpEndDate)
        Me.gpxAPVoucherData.Controls.Add(Me.cboVendorID)
        Me.gpxAPVoucherData.Controls.Add(Me.Label6)
        Me.gpxAPVoucherData.Controls.Add(Me.cboDivisionID)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPVoucherData.Controls.Add(Me.lblDateFilter)
        Me.gpxAPVoucherData.Controls.Add(Me.Label3)
        Me.gpxAPVoucherData.Controls.Add(Me.Label1)
        Me.gpxAPVoucherData.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPVoucherData.Name = "gpxAPVoucherData"
        Me.gpxAPVoucherData.Size = New System.Drawing.Size(300, 773)
        Me.gpxAPVoucherData.TabIndex = 0
        Me.gpxAPVoucherData.TabStop = False
        Me.gpxAPVoucherData.Text = "View By Filter Fields"
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"POSTED", "CLOSED"})
        Me.cboStatus.Location = New System.Drawing.Point(103, 379)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(181, 21)
        Me.cboStatus.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 379)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 20)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Status"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkViewDeleted
        '
        Me.chkViewDeleted.AutoSize = True
        Me.chkViewDeleted.Location = New System.Drawing.Point(101, 455)
        Me.chkViewDeleted.Name = "chkViewDeleted"
        Me.chkViewDeleted.Size = New System.Drawing.Size(137, 17)
        Me.chkViewDeleted.TabIndex = 9
        Me.chkViewDeleted.Text = "View Deleted Vouchers"
        Me.chkViewDeleted.UseVisualStyleBackColor = True
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(103, 415)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(181, 20)
        Me.txtTextFilter.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 415)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 20)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Text Filter"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVoucherNumber2
        '
        Me.cboVoucherNumber2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVoucherNumber2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVoucherNumber2.DataSource = Me.ReceiptOfInvoiceBatchLinePDBindingSource
        Me.cboVoucherNumber2.DisplayMember = "VoucherNumber"
        Me.cboVoucherNumber2.FormattingEnabled = True
        Me.cboVoucherNumber2.Location = New System.Drawing.Point(103, 343)
        Me.cboVoucherNumber2.Name = "cboVoucherNumber2"
        Me.cboVoucherNumber2.Size = New System.Drawing.Size(181, 21)
        Me.cboVoucherNumber2.TabIndex = 6
        '
        'ReceiptOfInvoiceBatchLinePDBindingSource
        '
        Me.ReceiptOfInvoiceBatchLinePDBindingSource.DataMember = "ReceiptOfInvoiceBatchLinePD"
        Me.ReceiptOfInvoiceBatchLinePDBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 343)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 20)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Voucher #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(20, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 40)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.DataSource = Me.VendorClassBindingSource
        Me.cboVendorClass.DisplayMember = "VendClassID"
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(103, 272)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(181, 21)
        Me.cboVendorClass.TabIndex = 4
        '
        'VendorClassBindingSource
        '
        Me.VendorClassBindingSource.DataMember = "VendorClass"
        Me.VendorClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 271)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 20)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Vendor Class"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(20, 492)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(104, 528)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 10
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(211, 727)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 17
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(103, 308)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(181, 20)
        Me.txtInvoiceNumber.TabIndex = 5
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(137, 727)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 16
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(133, 662)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 33)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Select date to filter list by."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 307)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Invoice #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoPostDate
        '
        Me.rdoPostDate.AutoSize = True
        Me.rdoPostDate.Location = New System.Drawing.Point(20, 698)
        Me.rdoPostDate.Name = "rdoPostDate"
        Me.rdoPostDate.Size = New System.Drawing.Size(72, 17)
        Me.rdoPostDate.TabIndex = 15
        Me.rdoPostDate.Text = "Post Date"
        Me.rdoPostDate.UseVisualStyleBackColor = True
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPONumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(103, 236)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(181, 21)
        Me.cboPONumber.TabIndex = 3
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'rdoReceiptDate
        '
        Me.rdoReceiptDate.AutoSize = True
        Me.rdoReceiptDate.Location = New System.Drawing.Point(20, 670)
        Me.rdoReceiptDate.Name = "rdoReceiptDate"
        Me.rdoReceiptDate.Size = New System.Drawing.Size(88, 17)
        Me.rdoReceiptDate.TabIndex = 14
        Me.rdoReceiptDate.Text = "Receipt Date"
        Me.rdoReceiptDate.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "PO Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoInvoiceDate
        '
        Me.rdoInvoiceDate.AutoSize = True
        Me.rdoInvoiceDate.Checked = True
        Me.rdoInvoiceDate.Location = New System.Drawing.Point(20, 642)
        Me.rdoInvoiceDate.Name = "rdoInvoiceDate"
        Me.rdoInvoiceDate.Size = New System.Drawing.Size(86, 17)
        Me.rdoInvoiceDate.TabIndex = 13
        Me.rdoInvoiceDate.TabStop = True
        Me.rdoInvoiceDate.Text = "Invoice Date"
        Me.rdoInvoiceDate.UseVisualStyleBackColor = True
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(22, 151)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(262, 67)
        Me.txtVendorName.TabIndex = 2
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(104, 599)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpEndDate.TabIndex = 12
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(83, 120)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(201, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 599)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "End Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(105, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(179, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(104, 563)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpBeginDate.TabIndex = 11
        '
        'lblDateFilter
        '
        Me.lblDateFilter.Location = New System.Drawing.Point(20, 563)
        Me.lblDateFilter.Name = "lblDateFilter"
        Me.lblDateFilter.Size = New System.Drawing.Size(100, 20)
        Me.lblDateFilter.TabIndex = 13
        Me.lblDateFilter.Text = "Begin Date"
        Me.lblDateFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Vendor ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 18
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewAllOpenUnpostedVouchersToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ViewAllOpenUnpostedVouchersToolStripMenuItem
        '
        Me.ViewAllOpenUnpostedVouchersToolStripMenuItem.Name = "ViewAllOpenUnpostedVouchersToolStripMenuItem"
        Me.ViewAllOpenUnpostedVouchersToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.ViewAllOpenUnpostedVouchersToolStripMenuItem.Text = "View All Open/Unposted Vouchers"
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
        Me.cmdPrint.Location = New System.Drawing.Point(980, 774)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 16
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1057, 774)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 17
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'VoucherLines
        '
        Me.VoucherLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VoucherLines.Location = New System.Drawing.Point(342, 774)
        Me.VoucherLines.Name = "VoucherLines"
        Me.VoucherLines.Size = New System.Drawing.Size(71, 40)
        Me.VoucherLines.TabIndex = 15
        Me.VoucherLines.Text = "View/Edit Voucher"
        Me.VoucherLines.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(429, 782)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(251, 25)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Opens the Edit Voucher Form and closes this form."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvBatchLinePostDate
        '
        Me.dgvBatchLinePostDate.AllowUserToAddRows = False
        Me.dgvBatchLinePostDate.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvBatchLinePostDate.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBatchLinePostDate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBatchLinePostDate.AutoGenerateColumns = False
        Me.dgvBatchLinePostDate.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvBatchLinePostDate.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvBatchLinePostDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBatchLinePostDate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VendorIDColumn, Me.PONumberColumn, Me.PostingDateColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.ReceiptDateColumn, Me.ProductTotalColumn, Me.InvoiceFreightColumn, Me.InvoiceSalesTaxColumn, Me.InvoiceTotalColumn, Me.InvoiceAmountColumn, Me.PaymentTermsColumn, Me.DiscountDateColumn, Me.CommentColumn, Me.DueDateColumn, Me.DiscountAmountColumn, Me.VoucherStatusColumn, Me.VoucherSourceColumn, Me.VendorClassColumn, Me.DivisionIDColumn, Me.DeleteReferenceNumberColumn, Me.VoucherNumberColumn, Me.BatchNumberColumn, Me.UserID, Me.CheckTypeColumn})
        Me.dgvBatchLinePostDate.DataSource = Me.ReceiptOfInvoiceBatchLinePDBindingSource
        Me.dgvBatchLinePostDate.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvBatchLinePostDate.Location = New System.Drawing.Point(342, 41)
        Me.dgvBatchLinePostDate.Name = "dgvBatchLinePostDate"
        Me.dgvBatchLinePostDate.Size = New System.Drawing.Size(786, 714)
        Me.dgvBatchLinePostDate.TabIndex = 18
        Me.dgvBatchLinePostDate.TabStop = False
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.ReadOnly = True
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PO #"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.ReadOnly = True
        '
        'PostingDateColumn
        '
        Me.PostingDateColumn.DataPropertyName = "PostingDate"
        Me.PostingDateColumn.HeaderText = "Post Date"
        Me.PostingDateColumn.Name = "PostingDateColumn"
        Me.PostingDateColumn.ReadOnly = True
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
        'ReceiptDateColumn
        '
        Me.ReceiptDateColumn.DataPropertyName = "ReceiptDate"
        Me.ReceiptDateColumn.HeaderText = "Receipt Date"
        Me.ReceiptDateColumn.Name = "ReceiptDateColumn"
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.ReadOnly = True
        '
        'InvoiceFreightColumn
        '
        Me.InvoiceFreightColumn.DataPropertyName = "InvoiceFreight"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.InvoiceFreightColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.InvoiceFreightColumn.HeaderText = "Freight"
        Me.InvoiceFreightColumn.Name = "InvoiceFreightColumn"
        Me.InvoiceFreightColumn.ReadOnly = True
        '
        'InvoiceSalesTaxColumn
        '
        Me.InvoiceSalesTaxColumn.DataPropertyName = "InvoiceSalesTax"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.InvoiceSalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.InvoiceSalesTaxColumn.HeaderText = "Sales Tax"
        Me.InvoiceSalesTaxColumn.Name = "InvoiceSalesTaxColumn"
        Me.InvoiceSalesTaxColumn.ReadOnly = True
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.ReadOnly = True
        '
        'InvoiceAmountColumn
        '
        Me.InvoiceAmountColumn.DataPropertyName = "InvoiceAmount"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.InvoiceAmountColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.InvoiceAmountColumn.HeaderText = "Invoice Amount"
        Me.InvoiceAmountColumn.Name = "InvoiceAmountColumn"
        Me.InvoiceAmountColumn.ReadOnly = True
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        '
        'DiscountDateColumn
        '
        Me.DiscountDateColumn.DataPropertyName = "DiscountDate"
        Me.DiscountDateColumn.HeaderText = "Discount Date"
        Me.DiscountDateColumn.Name = "DiscountDateColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'DueDateColumn
        '
        Me.DueDateColumn.DataPropertyName = "DueDate"
        Me.DueDateColumn.HeaderText = "Due Date"
        Me.DueDateColumn.Name = "DueDateColumn"
        '
        'DiscountAmountColumn
        '
        Me.DiscountAmountColumn.DataPropertyName = "DiscountAmount"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.DiscountAmountColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.DiscountAmountColumn.HeaderText = "Discount Available"
        Me.DiscountAmountColumn.Name = "DiscountAmountColumn"
        '
        'VoucherStatusColumn
        '
        Me.VoucherStatusColumn.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusColumn.HeaderText = "Voucher Status"
        Me.VoucherStatusColumn.Name = "VoucherStatusColumn"
        Me.VoucherStatusColumn.ReadOnly = True
        '
        'VoucherSourceColumn
        '
        Me.VoucherSourceColumn.DataPropertyName = "VoucherSource"
        Me.VoucherSourceColumn.HeaderText = "Voucher Source"
        Me.VoucherSourceColumn.Name = "VoucherSourceColumn"
        Me.VoucherSourceColumn.ReadOnly = True
        '
        'VendorClassColumn
        '
        Me.VendorClassColumn.DataPropertyName = "VendorClass"
        Me.VendorClassColumn.HeaderText = "Vendor Class"
        Me.VendorClassColumn.Name = "VendorClassColumn"
        Me.VendorClassColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'DeleteReferenceNumberColumn
        '
        Me.DeleteReferenceNumberColumn.DataPropertyName = "DeleteReferenceNumber"
        Me.DeleteReferenceNumberColumn.HeaderText = "Receiver #"
        Me.DeleteReferenceNumberColumn.Name = "DeleteReferenceNumberColumn"
        Me.DeleteReferenceNumberColumn.ReadOnly = True
        '
        'VoucherNumberColumn
        '
        Me.VoucherNumberColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn.HeaderText = "Voucher #"
        Me.VoucherNumberColumn.Name = "VoucherNumberColumn"
        Me.VoucherNumberColumn.ReadOnly = True
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "Batch #"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.ReadOnly = True
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "User"
        Me.UserID.Name = "UserID"
        '
        'CheckTypeColumn
        '
        Me.CheckTypeColumn.DataPropertyName = "CheckType"
        Me.CheckTypeColumn.HeaderText = "Check Type"
        Me.CheckTypeColumn.Name = "CheckTypeColumn"
        '
        'ReceiptOfInvoiceBatchLinePDTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLinePDTableAdapter.ClearBeforeFill = True
        '
        'VendorClassTableAdapter
        '
        Me.VendorClassTableAdapter.ClearBeforeFill = True
        '
        'cboVoucherNumber
        '
        Me.cboVoucherNumber.DataSource = Me.ReceiptOfInvoiceBatchLinePDBindingSource
        Me.cboVoucherNumber.DisplayMember = "VoucherNumber"
        Me.cboVoucherNumber.FormattingEnabled = True
        Me.cboVoucherNumber.Location = New System.Drawing.Point(98, 265)
        Me.cboVoucherNumber.Name = "cboVoucherNumber"
        Me.cboVoucherNumber.Size = New System.Drawing.Size(121, 21)
        Me.cboVoucherNumber.TabIndex = 26
        '
        'dgvDeletedVouchers
        '
        Me.dgvDeletedVouchers.AllowUserToAddRows = False
        Me.dgvDeletedVouchers.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvDeletedVouchers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDeletedVouchers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDeletedVouchers.AutoGenerateColumns = False
        Me.dgvDeletedVouchers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvDeletedVouchers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvDeletedVouchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDeletedVouchers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VendorIDColumn1, Me.VoucherNumberColumn1, Me.BatchNumberColumn1, Me.PONumberColumn1, Me.InvoiceNumberColumn1, Me.InvoiceDateColumn1, Me.ProductTotalColumn1, Me.InvoiceFreightColumn1, Me.InvoiceSalesTaxColumn1, Me.InvoiceTotalColumn1, Me.ReceiptDateColumn1, Me.InvoiceAmountColumn1, Me.PaymentTermsColumn1, Me.DueDateColumn1, Me.DiscountDateColumn1, Me.DiscountAmountColumn1, Me.CommentColumn1, Me.VendorClassColumn1, Me.VoucherStatusColumn1, Me.VoucherSourceColumn1, Me.DivisionIDColumn1, Me.DeleteReferenceNumberColumn1})
        Me.dgvDeletedVouchers.DataSource = Me.DeleteVoucherHeaderTableBindingSource
        Me.dgvDeletedVouchers.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvDeletedVouchers.Location = New System.Drawing.Point(342, 41)
        Me.dgvDeletedVouchers.Name = "dgvDeletedVouchers"
        Me.dgvDeletedVouchers.ReadOnly = True
        Me.dgvDeletedVouchers.Size = New System.Drawing.Size(774, 714)
        Me.dgvDeletedVouchers.TabIndex = 27
        '
        'VendorIDColumn1
        '
        Me.VendorIDColumn1.DataPropertyName = "VendorID"
        Me.VendorIDColumn1.HeaderText = "Vendor"
        Me.VendorIDColumn1.Name = "VendorIDColumn1"
        Me.VendorIDColumn1.ReadOnly = True
        '
        'VoucherNumberColumn1
        '
        Me.VoucherNumberColumn1.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn1.HeaderText = "Voucher #"
        Me.VoucherNumberColumn1.Name = "VoucherNumberColumn1"
        Me.VoucherNumberColumn1.ReadOnly = True
        '
        'BatchNumberColumn1
        '
        Me.BatchNumberColumn1.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn1.HeaderText = "Batch #"
        Me.BatchNumberColumn1.Name = "BatchNumberColumn1"
        Me.BatchNumberColumn1.ReadOnly = True
        '
        'PONumberColumn1
        '
        Me.PONumberColumn1.DataPropertyName = "PONumber"
        Me.PONumberColumn1.HeaderText = "PO #"
        Me.PONumberColumn1.Name = "PONumberColumn1"
        Me.PONumberColumn1.ReadOnly = True
        '
        'InvoiceNumberColumn1
        '
        Me.InvoiceNumberColumn1.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn1.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn1.Name = "InvoiceNumberColumn1"
        Me.InvoiceNumberColumn1.ReadOnly = True
        '
        'InvoiceDateColumn1
        '
        Me.InvoiceDateColumn1.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn1.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn1.Name = "InvoiceDateColumn1"
        Me.InvoiceDateColumn1.ReadOnly = True
        '
        'ProductTotalColumn1
        '
        Me.ProductTotalColumn1.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0"
        Me.ProductTotalColumn1.DefaultCellStyle = DataGridViewCellStyle9
        Me.ProductTotalColumn1.HeaderText = "Product Total"
        Me.ProductTotalColumn1.Name = "ProductTotalColumn1"
        Me.ProductTotalColumn1.ReadOnly = True
        '
        'InvoiceFreightColumn1
        '
        Me.InvoiceFreightColumn1.DataPropertyName = "InvoiceFreight"
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.InvoiceFreightColumn1.DefaultCellStyle = DataGridViewCellStyle10
        Me.InvoiceFreightColumn1.HeaderText = "Freight"
        Me.InvoiceFreightColumn1.Name = "InvoiceFreightColumn1"
        Me.InvoiceFreightColumn1.ReadOnly = True
        '
        'InvoiceSalesTaxColumn1
        '
        Me.InvoiceSalesTaxColumn1.DataPropertyName = "InvoiceSalesTax"
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = "0"
        Me.InvoiceSalesTaxColumn1.DefaultCellStyle = DataGridViewCellStyle11
        Me.InvoiceSalesTaxColumn1.HeaderText = "Sales Tax"
        Me.InvoiceSalesTaxColumn1.Name = "InvoiceSalesTaxColumn1"
        Me.InvoiceSalesTaxColumn1.ReadOnly = True
        '
        'InvoiceTotalColumn1
        '
        Me.InvoiceTotalColumn1.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = "0"
        Me.InvoiceTotalColumn1.DefaultCellStyle = DataGridViewCellStyle12
        Me.InvoiceTotalColumn1.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn1.Name = "InvoiceTotalColumn1"
        Me.InvoiceTotalColumn1.ReadOnly = True
        '
        'ReceiptDateColumn1
        '
        Me.ReceiptDateColumn1.DataPropertyName = "ReceiptDate"
        Me.ReceiptDateColumn1.HeaderText = "Receipt Date"
        Me.ReceiptDateColumn1.Name = "ReceiptDateColumn1"
        Me.ReceiptDateColumn1.ReadOnly = True
        '
        'InvoiceAmountColumn1
        '
        Me.InvoiceAmountColumn1.DataPropertyName = "InvoiceAmount"
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = "0"
        Me.InvoiceAmountColumn1.DefaultCellStyle = DataGridViewCellStyle13
        Me.InvoiceAmountColumn1.HeaderText = "Invoice Amount"
        Me.InvoiceAmountColumn1.Name = "InvoiceAmountColumn1"
        Me.InvoiceAmountColumn1.ReadOnly = True
        '
        'PaymentTermsColumn1
        '
        Me.PaymentTermsColumn1.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn1.HeaderText = "Payment Terms"
        Me.PaymentTermsColumn1.Name = "PaymentTermsColumn1"
        Me.PaymentTermsColumn1.ReadOnly = True
        '
        'DueDateColumn1
        '
        Me.DueDateColumn1.DataPropertyName = "DueDate"
        Me.DueDateColumn1.HeaderText = "Due Date"
        Me.DueDateColumn1.Name = "DueDateColumn1"
        Me.DueDateColumn1.ReadOnly = True
        '
        'DiscountDateColumn1
        '
        Me.DiscountDateColumn1.DataPropertyName = "DiscountDate"
        Me.DiscountDateColumn1.HeaderText = "Discount Date"
        Me.DiscountDateColumn1.Name = "DiscountDateColumn1"
        Me.DiscountDateColumn1.ReadOnly = True
        '
        'DiscountAmountColumn1
        '
        Me.DiscountAmountColumn1.DataPropertyName = "DiscountAmount"
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = "0"
        Me.DiscountAmountColumn1.DefaultCellStyle = DataGridViewCellStyle14
        Me.DiscountAmountColumn1.HeaderText = "Discount Amount"
        Me.DiscountAmountColumn1.Name = "DiscountAmountColumn1"
        Me.DiscountAmountColumn1.ReadOnly = True
        '
        'CommentColumn1
        '
        Me.CommentColumn1.DataPropertyName = "Comment"
        Me.CommentColumn1.HeaderText = "Comment"
        Me.CommentColumn1.Name = "CommentColumn1"
        Me.CommentColumn1.ReadOnly = True
        '
        'VendorClassColumn1
        '
        Me.VendorClassColumn1.DataPropertyName = "VendorClass"
        Me.VendorClassColumn1.HeaderText = "Vendor Class"
        Me.VendorClassColumn1.Name = "VendorClassColumn1"
        Me.VendorClassColumn1.ReadOnly = True
        '
        'VoucherStatusColumn1
        '
        Me.VoucherStatusColumn1.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusColumn1.HeaderText = "Voucher Status"
        Me.VoucherStatusColumn1.Name = "VoucherStatusColumn1"
        Me.VoucherStatusColumn1.ReadOnly = True
        '
        'VoucherSourceColumn1
        '
        Me.VoucherSourceColumn1.DataPropertyName = "VoucherSource"
        Me.VoucherSourceColumn1.HeaderText = "Voucher Source"
        Me.VoucherSourceColumn1.Name = "VoucherSourceColumn1"
        Me.VoucherSourceColumn1.ReadOnly = True
        '
        'DivisionIDColumn1
        '
        Me.DivisionIDColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn1.HeaderText = "Division"
        Me.DivisionIDColumn1.Name = "DivisionIDColumn1"
        Me.DivisionIDColumn1.ReadOnly = True
        '
        'DeleteReferenceNumberColumn1
        '
        Me.DeleteReferenceNumberColumn1.DataPropertyName = "DeleteReferenceNumber"
        Me.DeleteReferenceNumberColumn1.HeaderText = "Ref. #"
        Me.DeleteReferenceNumberColumn1.Name = "DeleteReferenceNumberColumn1"
        Me.DeleteReferenceNumberColumn1.ReadOnly = True
        '
        'DeleteVoucherHeaderTableBindingSource
        '
        Me.DeleteVoucherHeaderTableBindingSource.DataMember = "DeleteVoucherHeaderTable"
        Me.DeleteVoucherHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'DeleteVoucherHeaderTableTableAdapter
        '
        Me.DeleteVoucherHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ViewVoucherListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.VoucherLines)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxAPVoucherData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvBatchLinePostDate)
        Me.Controls.Add(Me.cboVoucherNumber)
        Me.Controls.Add(Me.dgvDeletedVouchers)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewVoucherListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Voucher Listing"
        Me.gpxAPVoucherData.ResumeLayout(False)
        Me.gpxAPVoucherData.PerformLayout()
        CType(Me.ReceiptOfInvoiceBatchLinePDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvBatchLinePostDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDeletedVouchers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeleteVoucherHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxAPVoucherData As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents lblDateFilter As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents VoucherLines As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rdoPostDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdoReceiptDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInvoiceDate As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvBatchLinePostDate As System.Windows.Forms.DataGridView
    Friend WithEvents ReceiptOfInvoiceBatchLinePDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLinePDTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLinePDTableAdapter
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents ViewAllOpenUnpostedVouchersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents VendorClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboVoucherNumber As System.Windows.Forms.ComboBox
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboVoucherNumber2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkViewDeleted As System.Windows.Forms.CheckBox
    Friend WithEvents dgvDeletedVouchers As System.Windows.Forms.DataGridView
    Friend WithEvents DeleteVoucherHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DeleteVoucherHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DeleteVoucherHeaderTableTableAdapter
    Friend WithEvents VendorIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceFreightColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSalesTaxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDateColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherSourceColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeleteReferenceNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherSourceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeleteReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
