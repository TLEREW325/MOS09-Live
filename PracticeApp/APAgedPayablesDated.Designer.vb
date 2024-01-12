<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APAgedPayablesDated
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxBatchInfo = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.VendorClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdView = New System.Windows.Forms.Button
        Me.rdoAgeByPost = New System.Windows.Forms.RadioButton
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rdoAgeByInvoice = New System.Windows.Forms.RadioButton
        Me.dtpSelectDate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdViewDetails = New System.Windows.Forms.Button
        Me.cmdARAging = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtTotalPayables = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.dgvAgedPayablesStep1 = New System.Windows.Forms.DataGridView
        Me.VoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaidDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PostingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APAgingQueryDatedStep1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.APAgingQueryDatedStep1TableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APAgingQueryDatedStep1TableAdapter
        Me.dgvAPAgingTempDated = New System.Windows.Forms.DataGridView
        Me.VoucherNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceFreightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherAmountOpenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaidDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APAgingTempDateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.APAgingTempDateTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APAgingTempDateTableAdapter
        Me.dgvAPAgingCategoryDated = New System.Windows.Forms.DataGridView
        Me.InvoiceNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DaysElapsedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AgingLessThan30DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging31To45DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging46To60DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging61To90DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AgingMoreThan90DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectDateDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APAgingCategoryDatedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.APAgingCategoryDatedTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APAgingCategoryDatedTableAdapter
        Me.VendorClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxBatchInfo.SuspendLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvAgedPayablesStep1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APAgingQueryDatedStep1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAPAgingTempDated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APAgingTempDateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAPAgingCategoryDated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APAgingCategoryDatedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gpxBatchInfo.Controls.Add(Me.Label7)
        Me.gpxBatchInfo.Controls.Add(Me.cboVendorClass)
        Me.gpxBatchInfo.Controls.Add(Me.cmdView)
        Me.gpxBatchInfo.Controls.Add(Me.rdoAgeByPost)
        Me.gpxBatchInfo.Controls.Add(Me.cmdClear)
        Me.gpxBatchInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxBatchInfo.Controls.Add(Me.rdoAgeByInvoice)
        Me.gpxBatchInfo.Controls.Add(Me.dtpSelectDate)
        Me.gpxBatchInfo.Controls.Add(Me.Label6)
        Me.gpxBatchInfo.Controls.Add(Me.Label3)
        Me.gpxBatchInfo.Controls.Add(Me.Label5)
        Me.gpxBatchInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxBatchInfo.Name = "gpxBatchInfo"
        Me.gpxBatchInfo.Size = New System.Drawing.Size(260, 379)
        Me.gpxBatchInfo.TabIndex = 0
        Me.gpxBatchInfo.TabStop = False
        Me.gpxBatchInfo.Text = "Aging Date Selection"
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(39, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(207, 26)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Select Vendor Class to show Aging by a specific class. Leave blank to view all."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.DataSource = Me.VendorClassBindingSource
        Me.cboVendorClass.DisplayMember = "VendClassID"
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(96, 264)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(150, 21)
        Me.cboVendorClass.TabIndex = 4
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
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(96, 322)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 5
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'rdoAgeByPost
        '
        Me.rdoAgeByPost.AutoSize = True
        Me.rdoAgeByPost.Location = New System.Drawing.Point(23, 160)
        Me.rdoAgeByPost.Name = "rdoAgeByPost"
        Me.rdoAgeByPost.Size = New System.Drawing.Size(123, 17)
        Me.rdoAgeByPost.TabIndex = 3
        Me.rdoAgeByPost.Text = "Age By Posting Date"
        Me.rdoAgeByPost.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(173, 322)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 6
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(96, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(148, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'rdoAgeByInvoice
        '
        Me.rdoAgeByInvoice.AutoSize = True
        Me.rdoAgeByInvoice.Checked = True
        Me.rdoAgeByInvoice.Location = New System.Drawing.Point(23, 126)
        Me.rdoAgeByInvoice.Name = "rdoAgeByInvoice"
        Me.rdoAgeByInvoice.Size = New System.Drawing.Size(123, 17)
        Me.rdoAgeByInvoice.TabIndex = 2
        Me.rdoAgeByInvoice.TabStop = True
        Me.rdoAgeByInvoice.Text = "Age By Invoice Date"
        Me.rdoAgeByInvoice.UseVisualStyleBackColor = True
        '
        'dtpSelectDate
        '
        Me.dtpSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSelectDate.Location = New System.Drawing.Point(96, 65)
        Me.dtpSelectDate.Name = "dtpSelectDate"
        Me.dtpSelectDate.Size = New System.Drawing.Size(148, 20)
        Me.dtpSelectDate.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(15, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 20)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Filter Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Division ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 265)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 20)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Vendor Class"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdViewDetails)
        Me.GroupBox1.Controls.Add(Me.cmdARAging)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 486)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 157)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datagrid Viewing Selection"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(98, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 40)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Show AP Aging "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(98, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 40)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Show filtered Voucher data in detail"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewDetails
        '
        Me.cmdViewDetails.Location = New System.Drawing.Point(18, 38)
        Me.cmdViewDetails.Name = "cmdViewDetails"
        Me.cmdViewDetails.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewDetails.TabIndex = 7
        Me.cmdViewDetails.Text = "View Details"
        Me.cmdViewDetails.UseVisualStyleBackColor = True
        '
        'cmdARAging
        '
        Me.cmdARAging.Location = New System.Drawing.Point(18, 97)
        Me.cmdARAging.Name = "cmdARAging"
        Me.cmdARAging.Size = New System.Drawing.Size(71, 40)
        Me.cmdARAging.TabIndex = 8
        Me.cmdARAging.Text = "View Aging"
        Me.cmdARAging.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTotalPayables)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 718)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 93)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Total Payables As Of Filter Date"
        '
        'txtTotalPayables
        '
        Me.txtTotalPayables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPayables.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalPayables.Location = New System.Drawing.Point(101, 43)
        Me.txtTotalPayables.Name = "txtTotalPayables"
        Me.txtTotalPayables.Size = New System.Drawing.Size(145, 20)
        Me.txtTotalPayables.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Total"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 10
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 11
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvAgedPayablesStep1
        '
        Me.dgvAgedPayablesStep1.AllowUserToAddRows = False
        Me.dgvAgedPayablesStep1.AutoGenerateColumns = False
        Me.dgvAgedPayablesStep1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAgedPayablesStep1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAgedPayablesStep1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VoucherNumberColumn, Me.PONumberColumn, Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.ReceiptDateColumn, Me.VendorIDColumn, Me.ProductTotalColumn, Me.InvoiceFreightColumn, Me.InvoiceSalesTaxColumn, Me.InvoiceTotalColumn, Me.PaymentTermsColumn, Me.DiscountDateColumn, Me.CommentColumn, Me.DueDateColumn, Me.DiscountAmountColumn, Me.DivisionIDColumn, Me.PaidDateColumn, Me.PaymentAmountColumn, Me.VoucherStatusColumn, Me.PostingDateColumn})
        Me.dgvAgedPayablesStep1.DataSource = Me.APAgingQueryDatedStep1BindingSource
        Me.dgvAgedPayablesStep1.Location = New System.Drawing.Point(312, 41)
        Me.dgvAgedPayablesStep1.Name = "dgvAgedPayablesStep1"
        Me.dgvAgedPayablesStep1.Size = New System.Drawing.Size(706, 251)
        Me.dgvAgedPayablesStep1.TabIndex = 29
        '
        'VoucherNumberColumn
        '
        Me.VoucherNumberColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumn.HeaderText = "VoucherNumber"
        Me.VoucherNumberColumn.Name = "VoucherNumberColumn"
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PONumber"
        Me.PONumberColumn.Name = "PONumberColumn"
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "InvoiceNumber"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "InvoiceDate"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        '
        'ReceiptDateColumn
        '
        Me.ReceiptDateColumn.DataPropertyName = "ReceiptDate"
        Me.ReceiptDateColumn.HeaderText = "ReceiptDate"
        Me.ReceiptDateColumn.Name = "ReceiptDateColumn"
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "VendorID"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ProductTotalColumn.HeaderText = "ProductTotal"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        '
        'InvoiceFreightColumn
        '
        Me.InvoiceFreightColumn.DataPropertyName = "InvoiceFreight"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.InvoiceFreightColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.InvoiceFreightColumn.HeaderText = "InvoiceFreight"
        Me.InvoiceFreightColumn.Name = "InvoiceFreightColumn"
        '
        'InvoiceSalesTaxColumn
        '
        Me.InvoiceSalesTaxColumn.DataPropertyName = "InvoiceSalesTax"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.InvoiceSalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.InvoiceSalesTaxColumn.HeaderText = "InvoiceSalesTax"
        Me.InvoiceSalesTaxColumn.Name = "InvoiceSalesTaxColumn"
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.InvoiceTotalColumn.HeaderText = "InvoiceTotal"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "PaymentTerms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        '
        'DiscountDateColumn
        '
        Me.DiscountDateColumn.DataPropertyName = "DiscountDate"
        Me.DiscountDateColumn.HeaderText = "DiscountDate"
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
        Me.DueDateColumn.HeaderText = "DueDate"
        Me.DueDateColumn.Name = "DueDateColumn"
        '
        'DiscountAmountColumn
        '
        Me.DiscountAmountColumn.DataPropertyName = "DiscountAmount"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.DiscountAmountColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.DiscountAmountColumn.HeaderText = "DiscountAmount"
        Me.DiscountAmountColumn.Name = "DiscountAmountColumn"
        Me.DiscountAmountColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        '
        'PaidDateColumn
        '
        Me.PaidDateColumn.DataPropertyName = "PaidDate"
        Me.PaidDateColumn.HeaderText = "PaidDate"
        Me.PaidDateColumn.Name = "PaidDateColumn"
        Me.PaidDateColumn.ReadOnly = True
        '
        'PaymentAmountColumn
        '
        Me.PaymentAmountColumn.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.PaymentAmountColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.PaymentAmountColumn.HeaderText = "PaymentAmount"
        Me.PaymentAmountColumn.Name = "PaymentAmountColumn"
        Me.PaymentAmountColumn.ReadOnly = True
        '
        'VoucherStatusColumn
        '
        Me.VoucherStatusColumn.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusColumn.HeaderText = "VoucherStatus"
        Me.VoucherStatusColumn.Name = "VoucherStatusColumn"
        Me.VoucherStatusColumn.Visible = False
        '
        'PostingDateColumn
        '
        Me.PostingDateColumn.DataPropertyName = "PostingDate"
        Me.PostingDateColumn.HeaderText = "Posting Date"
        Me.PostingDateColumn.Name = "PostingDateColumn"
        '
        'APAgingQueryDatedStep1BindingSource
        '
        Me.APAgingQueryDatedStep1BindingSource.DataMember = "APAgingQueryDatedStep1"
        Me.APAgingQueryDatedStep1BindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'APAgingQueryDatedStep1TableAdapter
        '
        Me.APAgingQueryDatedStep1TableAdapter.ClearBeforeFill = True
        '
        'dgvAPAgingTempDated
        '
        Me.dgvAPAgingTempDated.AllowUserToAddRows = False
        Me.dgvAPAgingTempDated.AutoGenerateColumns = False
        Me.dgvAPAgingTempDated.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAPAgingTempDated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPAgingTempDated.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VoucherNumberDataGridViewTextBoxColumn, Me.InvoiceNumberDataGridViewTextBoxColumn, Me.PONumberDataGridViewTextBoxColumn, Me.InvoiceDateDataGridViewTextBoxColumn, Me.VendorIDDataGridViewTextBoxColumn, Me.ProductTotalDataGridViewTextBoxColumn, Me.InvoiceFreightDataGridViewTextBoxColumn, Me.InvoiceSalesTaxDataGridViewTextBoxColumn, Me.InvoiceTotalDataGridViewTextBoxColumn, Me.VoucherAmountOpenDataGridViewTextBoxColumn, Me.PaymentTermsDataGridViewTextBoxColumn, Me.DueDateDataGridViewTextBoxColumn, Me.PaidDateDataGridViewTextBoxColumn, Me.PaymentAmountDataGridViewTextBoxColumn, Me.SelectDateDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn})
        Me.dgvAPAgingTempDated.DataSource = Me.APAgingTempDateBindingSource
        Me.dgvAPAgingTempDated.Location = New System.Drawing.Point(312, 41)
        Me.dgvAPAgingTempDated.Name = "dgvAPAgingTempDated"
        Me.dgvAPAgingTempDated.Size = New System.Drawing.Size(706, 523)
        Me.dgvAPAgingTempDated.TabIndex = 30
        '
        'VoucherNumberDataGridViewTextBoxColumn
        '
        Me.VoucherNumberDataGridViewTextBoxColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberDataGridViewTextBoxColumn.HeaderText = "Voucher Number"
        Me.VoucherNumberDataGridViewTextBoxColumn.Name = "VoucherNumberDataGridViewTextBoxColumn"
        '
        'InvoiceNumberDataGridViewTextBoxColumn
        '
        Me.InvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberDataGridViewTextBoxColumn.HeaderText = "Invoice Number"
        Me.InvoiceNumberDataGridViewTextBoxColumn.Name = "InvoiceNumberDataGridViewTextBoxColumn"
        '
        'PONumberDataGridViewTextBoxColumn
        '
        Me.PONumberDataGridViewTextBoxColumn.DataPropertyName = "PONumber"
        Me.PONumberDataGridViewTextBoxColumn.HeaderText = "PO Number"
        Me.PONumberDataGridViewTextBoxColumn.Name = "PONumberDataGridViewTextBoxColumn"
        '
        'InvoiceDateDataGridViewTextBoxColumn
        '
        Me.InvoiceDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateDataGridViewTextBoxColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateDataGridViewTextBoxColumn.Name = "InvoiceDateDataGridViewTextBoxColumn"
        '
        'VendorIDDataGridViewTextBoxColumn
        '
        Me.VendorIDDataGridViewTextBoxColumn.DataPropertyName = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn.HeaderText = "Vendor ID"
        Me.VendorIDDataGridViewTextBoxColumn.Name = "VendorIDDataGridViewTextBoxColumn"
        '
        'ProductTotalDataGridViewTextBoxColumn
        '
        Me.ProductTotalDataGridViewTextBoxColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.ProductTotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.ProductTotalDataGridViewTextBoxColumn.HeaderText = "Product Total"
        Me.ProductTotalDataGridViewTextBoxColumn.Name = "ProductTotalDataGridViewTextBoxColumn"
        '
        'InvoiceFreightDataGridViewTextBoxColumn
        '
        Me.InvoiceFreightDataGridViewTextBoxColumn.DataPropertyName = "InvoiceFreight"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.InvoiceFreightDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.InvoiceFreightDataGridViewTextBoxColumn.HeaderText = "Invoice Freight"
        Me.InvoiceFreightDataGridViewTextBoxColumn.Name = "InvoiceFreightDataGridViewTextBoxColumn"
        '
        'InvoiceSalesTaxDataGridViewTextBoxColumn
        '
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.DataPropertyName = "InvoiceSalesTax"
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0"
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.HeaderText = "Invoice Sales Tax"
        Me.InvoiceSalesTaxDataGridViewTextBoxColumn.Name = "InvoiceSalesTaxDataGridViewTextBoxColumn"
        '
        'InvoiceTotalDataGridViewTextBoxColumn
        '
        Me.InvoiceTotalDataGridViewTextBoxColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.InvoiceTotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.InvoiceTotalDataGridViewTextBoxColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalDataGridViewTextBoxColumn.Name = "InvoiceTotalDataGridViewTextBoxColumn"
        '
        'VoucherAmountOpenDataGridViewTextBoxColumn
        '
        Me.VoucherAmountOpenDataGridViewTextBoxColumn.DataPropertyName = "VoucherAmountOpen"
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = "0"
        Me.VoucherAmountOpenDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.VoucherAmountOpenDataGridViewTextBoxColumn.HeaderText = "Amount Open"
        Me.VoucherAmountOpenDataGridViewTextBoxColumn.Name = "VoucherAmountOpenDataGridViewTextBoxColumn"
        '
        'PaymentTermsDataGridViewTextBoxColumn
        '
        Me.PaymentTermsDataGridViewTextBoxColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsDataGridViewTextBoxColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsDataGridViewTextBoxColumn.Name = "PaymentTermsDataGridViewTextBoxColumn"
        '
        'DueDateDataGridViewTextBoxColumn
        '
        Me.DueDateDataGridViewTextBoxColumn.DataPropertyName = "DueDate"
        Me.DueDateDataGridViewTextBoxColumn.HeaderText = "Due Date"
        Me.DueDateDataGridViewTextBoxColumn.Name = "DueDateDataGridViewTextBoxColumn"
        '
        'PaidDateDataGridViewTextBoxColumn
        '
        Me.PaidDateDataGridViewTextBoxColumn.DataPropertyName = "PaidDate"
        Me.PaidDateDataGridViewTextBoxColumn.HeaderText = "Paid Date"
        Me.PaidDateDataGridViewTextBoxColumn.Name = "PaidDateDataGridViewTextBoxColumn"
        '
        'PaymentAmountDataGridViewTextBoxColumn
        '
        Me.PaymentAmountDataGridViewTextBoxColumn.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = "0"
        Me.PaymentAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.PaymentAmountDataGridViewTextBoxColumn.HeaderText = "Payment Amount"
        Me.PaymentAmountDataGridViewTextBoxColumn.Name = "PaymentAmountDataGridViewTextBoxColumn"
        '
        'SelectDateDataGridViewTextBoxColumn
        '
        Me.SelectDateDataGridViewTextBoxColumn.DataPropertyName = "SelectDate"
        Me.SelectDateDataGridViewTextBoxColumn.HeaderText = "SelectDate"
        Me.SelectDateDataGridViewTextBoxColumn.Name = "SelectDateDataGridViewTextBoxColumn"
        Me.SelectDateDataGridViewTextBoxColumn.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'APAgingTempDateBindingSource
        '
        Me.APAgingTempDateBindingSource.DataMember = "APAgingTempDate"
        Me.APAgingTempDateBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'APAgingTempDateTableAdapter
        '
        Me.APAgingTempDateTableAdapter.ClearBeforeFill = True
        '
        'dgvAPAgingCategoryDated
        '
        Me.dgvAPAgingCategoryDated.AllowUserToAddRows = False
        Me.dgvAPAgingCategoryDated.AllowUserToDeleteRows = False
        Me.dgvAPAgingCategoryDated.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAPAgingCategoryDated.AutoGenerateColumns = False
        Me.dgvAPAgingCategoryDated.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAPAgingCategoryDated.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAPAgingCategoryDated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPAgingCategoryDated.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberDataGridViewTextBoxColumn1, Me.InvoiceDateDataGridViewTextBoxColumn1, Me.VendorIDDataGridViewTextBoxColumn1, Me.DaysElapsedDataGridViewTextBoxColumn, Me.InvoiceTotalDataGridViewTextBoxColumn1, Me.InvoiceAmountOpenDataGridViewTextBoxColumn, Me.AgingLessThan30DataGridViewTextBoxColumn, Me.Aging31To45DataGridViewTextBoxColumn, Me.Aging46To60DataGridViewTextBoxColumn, Me.Aging61To90DataGridViewTextBoxColumn, Me.AgingMoreThan90DataGridViewTextBoxColumn, Me.SelectDateDataGridViewTextBoxColumn1, Me.DivisionIDDataGridViewTextBoxColumn1, Me.DiscountAmountDataGridViewTextBoxColumn, Me.DiscountDateDataGridViewTextBoxColumn, Me.DueDateDataGridViewTextBoxColumn1, Me.VoucherNumberDataGridViewTextBoxColumn1, Me.PaymentAmountDataGridViewTextBoxColumn1, Me.VendorClassColumn})
        Me.dgvAPAgingCategoryDated.DataSource = Me.APAgingCategoryDatedBindingSource
        Me.dgvAPAgingCategoryDated.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvAPAgingCategoryDated.Location = New System.Drawing.Point(312, 41)
        Me.dgvAPAgingCategoryDated.Name = "dgvAPAgingCategoryDated"
        Me.dgvAPAgingCategoryDated.Size = New System.Drawing.Size(718, 724)
        Me.dgvAPAgingCategoryDated.TabIndex = 12
        Me.dgvAPAgingCategoryDated.TabStop = False
        '
        'InvoiceNumberDataGridViewTextBoxColumn1
        '
        Me.InvoiceNumberDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberDataGridViewTextBoxColumn1.HeaderText = "Invoice #"
        Me.InvoiceNumberDataGridViewTextBoxColumn1.Name = "InvoiceNumberDataGridViewTextBoxColumn1"
        Me.InvoiceNumberDataGridViewTextBoxColumn1.Width = 85
        '
        'InvoiceDateDataGridViewTextBoxColumn1
        '
        Me.InvoiceDateDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateDataGridViewTextBoxColumn1.HeaderText = "Aging Date"
        Me.InvoiceDateDataGridViewTextBoxColumn1.Name = "InvoiceDateDataGridViewTextBoxColumn1"
        Me.InvoiceDateDataGridViewTextBoxColumn1.Width = 90
        '
        'VendorIDDataGridViewTextBoxColumn1
        '
        Me.VendorIDDataGridViewTextBoxColumn1.DataPropertyName = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn1.HeaderText = "Vendor ID"
        Me.VendorIDDataGridViewTextBoxColumn1.Name = "VendorIDDataGridViewTextBoxColumn1"
        '
        'DaysElapsedDataGridViewTextBoxColumn
        '
        Me.DaysElapsedDataGridViewTextBoxColumn.DataPropertyName = "DaysElapsed"
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.NullValue = "0"
        Me.DaysElapsedDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle13
        Me.DaysElapsedDataGridViewTextBoxColumn.HeaderText = "Days Elapsed"
        Me.DaysElapsedDataGridViewTextBoxColumn.Name = "DaysElapsedDataGridViewTextBoxColumn"
        Me.DaysElapsedDataGridViewTextBoxColumn.ReadOnly = True
        Me.DaysElapsedDataGridViewTextBoxColumn.Width = 85
        '
        'InvoiceTotalDataGridViewTextBoxColumn1
        '
        Me.InvoiceTotalDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = "0"
        Me.InvoiceTotalDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle14
        Me.InvoiceTotalDataGridViewTextBoxColumn1.HeaderText = "Invoice Total"
        Me.InvoiceTotalDataGridViewTextBoxColumn1.Name = "InvoiceTotalDataGridViewTextBoxColumn1"
        Me.InvoiceTotalDataGridViewTextBoxColumn1.Width = 85
        '
        'InvoiceAmountOpenDataGridViewTextBoxColumn
        '
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.DataPropertyName = "InvoiceAmountOpen"
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = "0"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle15
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.HeaderText = "Amount Open"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.Name = "InvoiceAmountOpenDataGridViewTextBoxColumn"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.ReadOnly = True
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.Width = 85
        '
        'AgingLessThan30DataGridViewTextBoxColumn
        '
        Me.AgingLessThan30DataGridViewTextBoxColumn.DataPropertyName = "AgingLessThan30"
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = "0"
        Me.AgingLessThan30DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle16
        Me.AgingLessThan30DataGridViewTextBoxColumn.HeaderText = "< 30"
        Me.AgingLessThan30DataGridViewTextBoxColumn.Name = "AgingLessThan30DataGridViewTextBoxColumn"
        Me.AgingLessThan30DataGridViewTextBoxColumn.ReadOnly = True
        Me.AgingLessThan30DataGridViewTextBoxColumn.Width = 85
        '
        'Aging31To45DataGridViewTextBoxColumn
        '
        Me.Aging31To45DataGridViewTextBoxColumn.DataPropertyName = "Aging31To45"
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = "0"
        Me.Aging31To45DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle17
        Me.Aging31To45DataGridViewTextBoxColumn.HeaderText = "30 - 45"
        Me.Aging31To45DataGridViewTextBoxColumn.Name = "Aging31To45DataGridViewTextBoxColumn"
        Me.Aging31To45DataGridViewTextBoxColumn.ReadOnly = True
        Me.Aging31To45DataGridViewTextBoxColumn.Width = 85
        '
        'Aging46To60DataGridViewTextBoxColumn
        '
        Me.Aging46To60DataGridViewTextBoxColumn.DataPropertyName = "Aging46To60"
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = "0"
        Me.Aging46To60DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle18
        Me.Aging46To60DataGridViewTextBoxColumn.HeaderText = "46 - 60"
        Me.Aging46To60DataGridViewTextBoxColumn.Name = "Aging46To60DataGridViewTextBoxColumn"
        Me.Aging46To60DataGridViewTextBoxColumn.ReadOnly = True
        Me.Aging46To60DataGridViewTextBoxColumn.Width = 85
        '
        'Aging61To90DataGridViewTextBoxColumn
        '
        Me.Aging61To90DataGridViewTextBoxColumn.DataPropertyName = "Aging61To90"
        DataGridViewCellStyle19.Format = "N2"
        DataGridViewCellStyle19.NullValue = "0"
        Me.Aging61To90DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle19
        Me.Aging61To90DataGridViewTextBoxColumn.HeaderText = "61 - 90"
        Me.Aging61To90DataGridViewTextBoxColumn.Name = "Aging61To90DataGridViewTextBoxColumn"
        Me.Aging61To90DataGridViewTextBoxColumn.ReadOnly = True
        Me.Aging61To90DataGridViewTextBoxColumn.Width = 85
        '
        'AgingMoreThan90DataGridViewTextBoxColumn
        '
        Me.AgingMoreThan90DataGridViewTextBoxColumn.DataPropertyName = "AgingMoreThan90"
        DataGridViewCellStyle20.Format = "N2"
        DataGridViewCellStyle20.NullValue = "0"
        Me.AgingMoreThan90DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle20
        Me.AgingMoreThan90DataGridViewTextBoxColumn.HeaderText = "> 90"
        Me.AgingMoreThan90DataGridViewTextBoxColumn.Name = "AgingMoreThan90DataGridViewTextBoxColumn"
        Me.AgingMoreThan90DataGridViewTextBoxColumn.ReadOnly = True
        Me.AgingMoreThan90DataGridViewTextBoxColumn.Width = 85
        '
        'SelectDateDataGridViewTextBoxColumn1
        '
        Me.SelectDateDataGridViewTextBoxColumn1.DataPropertyName = "SelectDate"
        Me.SelectDateDataGridViewTextBoxColumn1.HeaderText = "SelectDate"
        Me.SelectDateDataGridViewTextBoxColumn1.Name = "SelectDateDataGridViewTextBoxColumn1"
        Me.SelectDateDataGridViewTextBoxColumn1.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn1
        '
        Me.DivisionIDDataGridViewTextBoxColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.Name = "DivisionIDDataGridViewTextBoxColumn1"
        Me.DivisionIDDataGridViewTextBoxColumn1.Visible = False
        '
        'DiscountAmountDataGridViewTextBoxColumn
        '
        Me.DiscountAmountDataGridViewTextBoxColumn.DataPropertyName = "DiscountAmount"
        DataGridViewCellStyle21.Format = "N2"
        DataGridViewCellStyle21.NullValue = "0"
        Me.DiscountAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle21
        Me.DiscountAmountDataGridViewTextBoxColumn.HeaderText = "DiscountAmount"
        Me.DiscountAmountDataGridViewTextBoxColumn.Name = "DiscountAmountDataGridViewTextBoxColumn"
        Me.DiscountAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.DiscountAmountDataGridViewTextBoxColumn.Visible = False
        '
        'DiscountDateDataGridViewTextBoxColumn
        '
        Me.DiscountDateDataGridViewTextBoxColumn.DataPropertyName = "DiscountDate"
        Me.DiscountDateDataGridViewTextBoxColumn.HeaderText = "DiscountDate"
        Me.DiscountDateDataGridViewTextBoxColumn.Name = "DiscountDateDataGridViewTextBoxColumn"
        Me.DiscountDateDataGridViewTextBoxColumn.Visible = False
        '
        'DueDateDataGridViewTextBoxColumn1
        '
        Me.DueDateDataGridViewTextBoxColumn1.DataPropertyName = "DueDate"
        Me.DueDateDataGridViewTextBoxColumn1.HeaderText = "DueDate"
        Me.DueDateDataGridViewTextBoxColumn1.Name = "DueDateDataGridViewTextBoxColumn1"
        Me.DueDateDataGridViewTextBoxColumn1.Visible = False
        '
        'VoucherNumberDataGridViewTextBoxColumn1
        '
        Me.VoucherNumberDataGridViewTextBoxColumn1.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberDataGridViewTextBoxColumn1.HeaderText = "Voucher #"
        Me.VoucherNumberDataGridViewTextBoxColumn1.Name = "VoucherNumberDataGridViewTextBoxColumn1"
        '
        'PaymentAmountDataGridViewTextBoxColumn1
        '
        Me.PaymentAmountDataGridViewTextBoxColumn1.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.NullValue = "0"
        Me.PaymentAmountDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle22
        Me.PaymentAmountDataGridViewTextBoxColumn1.HeaderText = "PaymentAmount"
        Me.PaymentAmountDataGridViewTextBoxColumn1.Name = "PaymentAmountDataGridViewTextBoxColumn1"
        Me.PaymentAmountDataGridViewTextBoxColumn1.ReadOnly = True
        Me.PaymentAmountDataGridViewTextBoxColumn1.Visible = False
        '
        'VendorClassColumn
        '
        Me.VendorClassColumn.DataPropertyName = "VendorClass"
        Me.VendorClassColumn.HeaderText = "VendorClass"
        Me.VendorClassColumn.Name = "VendorClassColumn"
        Me.VendorClassColumn.Visible = False
        '
        'APAgingCategoryDatedBindingSource
        '
        Me.APAgingCategoryDatedBindingSource.DataMember = "APAgingCategoryDated"
        Me.APAgingCategoryDatedBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'APAgingCategoryDatedTableAdapter
        '
        Me.APAgingCategoryDatedTableAdapter.ClearBeforeFill = True
        '
        'VendorClassTableAdapter
        '
        Me.VendorClassTableAdapter.ClearBeforeFill = True
        '
        'APAgedPayablesDated
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpxBatchInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvAPAgingCategoryDated)
        Me.Controls.Add(Me.dgvAPAgingTempDated)
        Me.Controls.Add(Me.dgvAgedPayablesStep1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "APAgedPayablesDated"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Aged Payables By Date Selection"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxBatchInfo.ResumeLayout(False)
        Me.gpxBatchInfo.PerformLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvAgedPayablesStep1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APAgingQueryDatedStep1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAPAgingTempDated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APAgingTempDateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAPAgingCategoryDated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APAgingCategoryDatedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpSelectDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdViewDetails As System.Windows.Forms.Button
    Friend WithEvents cmdARAging As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalPayables As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dgvAgedPayablesStep1 As System.Windows.Forms.DataGridView
    Friend WithEvents APAgingQueryDatedStep1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APAgingQueryDatedStep1TableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APAgingQueryDatedStep1TableAdapter
    Friend WithEvents dgvAPAgingTempDated As System.Windows.Forms.DataGridView
    Friend WithEvents APAgingTempDateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APAgingTempDateTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APAgingTempDateTableAdapter
    Friend WithEvents dgvAPAgingCategoryDated As System.Windows.Forms.DataGridView
    Friend WithEvents APAgingCategoryDatedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APAgingCategoryDatedTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APAgingCategoryDatedTableAdapter
    Friend WithEvents VoucherNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceFreightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSalesTaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherAmountOpenDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaidDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rdoAgeByPost As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAgeByInvoice As System.Windows.Forms.RadioButton
    Friend WithEvents VoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiptDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceSalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaidDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents VendorClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents InvoiceNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DaysElapsedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountOpenDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgingLessThan30DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging31To45DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging46To60DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging61To90DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgingMoreThan90DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectDateDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
