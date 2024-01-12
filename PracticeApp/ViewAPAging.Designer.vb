<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAPAging
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
        Me.gpxAPAging = New System.Windows.Forms.GroupBox
        Me.chkOver90 = New System.Windows.Forms.CheckBox
        Me.chkLessThan90 = New System.Windows.Forms.CheckBox
        Me.chkLessThan60 = New System.Windows.Forms.CheckBox
        Me.chkLessthan45 = New System.Windows.Forms.CheckBox
        Me.chkLessthan30 = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboVendorClass = New System.Windows.Forms.ComboBox
        Me.VendorClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.APVoucherTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintAgingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvAPAging = New System.Windows.Forms.DataGridView
        Me.InvoiceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AgingLessThan30DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging31To45DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging46To60DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging61To90DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AgingMoreThan90DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TodaysDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DaysElapsedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APAgingCategoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.APAgingCategoryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APAgingCategoryTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.APVoucherTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APVoucherTableTableAdapter
        Me.txtOpenPayableTotal = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.VendorClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
        Me.gpxAPAging.SuspendLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APVoucherTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvAPAging, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APAgingCategoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxAPAging
        '
        Me.gpxAPAging.Controls.Add(Me.chkOver90)
        Me.gpxAPAging.Controls.Add(Me.chkLessThan90)
        Me.gpxAPAging.Controls.Add(Me.chkLessThan60)
        Me.gpxAPAging.Controls.Add(Me.chkLessthan45)
        Me.gpxAPAging.Controls.Add(Me.chkLessthan30)
        Me.gpxAPAging.Controls.Add(Me.Label14)
        Me.gpxAPAging.Controls.Add(Me.chkDateRange)
        Me.gpxAPAging.Controls.Add(Me.Label12)
        Me.gpxAPAging.Controls.Add(Me.dtpEndDate)
        Me.gpxAPAging.Controls.Add(Me.cboVendorClass)
        Me.gpxAPAging.Controls.Add(Me.txtVendorName)
        Me.gpxAPAging.Controls.Add(Me.Label8)
        Me.gpxAPAging.Controls.Add(Me.Label4)
        Me.gpxAPAging.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPAging.Controls.Add(Me.Label7)
        Me.gpxAPAging.Controls.Add(Me.cboDivisionID)
        Me.gpxAPAging.Controls.Add(Me.cboVendorID)
        Me.gpxAPAging.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxAPAging.Controls.Add(Me.Label3)
        Me.gpxAPAging.Controls.Add(Me.cmdViewByFilters)
        Me.gpxAPAging.Controls.Add(Me.cmdClear)
        Me.gpxAPAging.Controls.Add(Me.Label2)
        Me.gpxAPAging.Controls.Add(Me.Label1)
        Me.gpxAPAging.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPAging.Name = "gpxAPAging"
        Me.gpxAPAging.Size = New System.Drawing.Size(300, 770)
        Me.gpxAPAging.TabIndex = 0
        Me.gpxAPAging.TabStop = False
        Me.gpxAPAging.Text = "Filter By Vendor"
        '
        'chkOver90
        '
        Me.chkOver90.AutoSize = True
        Me.chkOver90.Location = New System.Drawing.Point(30, 479)
        Me.chkOver90.Name = "chkOver90"
        Me.chkOver90.Size = New System.Drawing.Size(64, 17)
        Me.chkOver90.TabIndex = 9
        Me.chkOver90.Text = "Over 90"
        Me.chkOver90.UseVisualStyleBackColor = True
        '
        'chkLessThan90
        '
        Me.chkLessThan90.AutoSize = True
        Me.chkLessThan90.Location = New System.Drawing.Point(30, 453)
        Me.chkLessThan90.Name = "chkLessThan90"
        Me.chkLessThan90.Size = New System.Drawing.Size(65, 17)
        Me.chkLessThan90.TabIndex = 8
        Me.chkLessThan90.Text = "60 to 90"
        Me.chkLessThan90.UseVisualStyleBackColor = True
        '
        'chkLessThan60
        '
        Me.chkLessThan60.AutoSize = True
        Me.chkLessThan60.Location = New System.Drawing.Point(30, 427)
        Me.chkLessThan60.Name = "chkLessThan60"
        Me.chkLessThan60.Size = New System.Drawing.Size(65, 17)
        Me.chkLessThan60.TabIndex = 7
        Me.chkLessThan60.Text = "46 to 60"
        Me.chkLessThan60.UseVisualStyleBackColor = True
        '
        'chkLessthan45
        '
        Me.chkLessthan45.AutoSize = True
        Me.chkLessthan45.Location = New System.Drawing.Point(30, 401)
        Me.chkLessthan45.Name = "chkLessthan45"
        Me.chkLessthan45.Size = New System.Drawing.Size(65, 17)
        Me.chkLessthan45.TabIndex = 6
        Me.chkLessthan45.Text = "31 to 45"
        Me.chkLessthan45.UseVisualStyleBackColor = True
        '
        'chkLessthan30
        '
        Me.chkLessthan30.AutoSize = True
        Me.chkLessthan30.Location = New System.Drawing.Point(30, 375)
        Me.chkLessthan30.Name = "chkLessthan30"
        Me.chkLessthan30.Size = New System.Drawing.Size(87, 17)
        Me.chkLessthan30.TabIndex = 5
        Me.chkLessthan30.Text = "Less than 30"
        Me.chkLessthan30.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(27, 583)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(112, 619)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 10
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(18, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 40)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(112, 687)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpEndDate.TabIndex = 12
        '
        'cboVendorClass
        '
        Me.cboVendorClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorClass.DataSource = Me.VendorClassBindingSource
        Me.cboVendorClass.DisplayMember = "VendClassID"
        Me.cboVendorClass.FormattingEnabled = True
        Me.cboVendorClass.Location = New System.Drawing.Point(109, 294)
        Me.cboVendorClass.Name = "cboVendorClass"
        Me.cboVendorClass.Size = New System.Drawing.Size(178, 21)
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
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(22, 150)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(265, 78)
        Me.txtVendorName.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(21, 687)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(27, 295)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Vendor Class"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(112, 652)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpBeginDate.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 652)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Begin Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(88, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(199, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.DropDownWidth = 250
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(88, 119)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(199, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.APVoucherTableBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(109, 257)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboInvoiceNumber.TabIndex = 3
        '
        'APVoucherTableBindingSource
        '
        Me.APVoucherTableBindingSource.DataMember = "APVoucherTable"
        Me.APVoucherTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(27, 258)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Invoice #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(137, 722)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 13
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(216, 722)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Vendor ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 29)
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
        Me.MenuStrip1.TabIndex = 6
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintAgingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintAgingToolStripMenuItem
        '
        Me.PrintAgingToolStripMenuItem.Name = "PrintAgingToolStripMenuItem"
        Me.PrintAgingToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.PrintAgingToolStripMenuItem.Text = "Print Aging"
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
        'dgvAPAging
        '
        Me.dgvAPAging.AllowUserToAddRows = False
        Me.dgvAPAging.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvAPAging.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAPAging.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAPAging.AutoGenerateColumns = False
        Me.dgvAPAging.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAPAging.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAPAging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPAging.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberDataGridViewTextBoxColumn, Me.InvoiceDateDataGridViewTextBoxColumn, Me.VendorIDDataGridViewTextBoxColumn, Me.InvoiceTotalDataGridViewTextBoxColumn, Me.InvoiceAmountOpenDataGridViewTextBoxColumn, Me.DueDateDataGridViewTextBoxColumn, Me.AgingLessThan30DataGridViewTextBoxColumn, Me.Aging31To45DataGridViewTextBoxColumn, Me.Aging46To60DataGridViewTextBoxColumn, Me.Aging61To90DataGridViewTextBoxColumn, Me.AgingMoreThan90DataGridViewTextBoxColumn, Me.DiscountDateDataGridViewTextBoxColumn, Me.DiscountAmountDataGridViewTextBoxColumn, Me.TodaysDateDataGridViewTextBoxColumn, Me.DaysElapsedDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.PaymentAmountDataGridViewTextBoxColumn, Me.VoucherNumberDataGridViewTextBoxColumn, Me.VendorClassColumn})
        Me.dgvAPAging.DataSource = Me.APAgingCategoryBindingSource
        Me.dgvAPAging.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvAPAging.Location = New System.Drawing.Point(349, 41)
        Me.dgvAPAging.Name = "dgvAPAging"
        Me.dgvAPAging.Size = New System.Drawing.Size(781, 722)
        Me.dgvAPAging.TabIndex = 19
        Me.dgvAPAging.TabStop = False
        '
        'InvoiceNumberDataGridViewTextBoxColumn
        '
        Me.InvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberDataGridViewTextBoxColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberDataGridViewTextBoxColumn.Name = "InvoiceNumberDataGridViewTextBoxColumn"
        Me.InvoiceNumberDataGridViewTextBoxColumn.Width = 85
        '
        'InvoiceDateDataGridViewTextBoxColumn
        '
        Me.InvoiceDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateDataGridViewTextBoxColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateDataGridViewTextBoxColumn.Name = "InvoiceDateDataGridViewTextBoxColumn"
        Me.InvoiceDateDataGridViewTextBoxColumn.Width = 85
        '
        'VendorIDDataGridViewTextBoxColumn
        '
        Me.VendorIDDataGridViewTextBoxColumn.DataPropertyName = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn.HeaderText = "Vendor ID"
        Me.VendorIDDataGridViewTextBoxColumn.Name = "VendorIDDataGridViewTextBoxColumn"
        '
        'InvoiceTotalDataGridViewTextBoxColumn
        '
        Me.InvoiceTotalDataGridViewTextBoxColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.InvoiceTotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.InvoiceTotalDataGridViewTextBoxColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalDataGridViewTextBoxColumn.Name = "InvoiceTotalDataGridViewTextBoxColumn"
        Me.InvoiceTotalDataGridViewTextBoxColumn.Width = 85
        '
        'InvoiceAmountOpenDataGridViewTextBoxColumn
        '
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.DataPropertyName = "InvoiceAmountOpen"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.HeaderText = "Amount Open"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.Name = "InvoiceAmountOpenDataGridViewTextBoxColumn"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.ReadOnly = True
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.Width = 85
        '
        'DueDateDataGridViewTextBoxColumn
        '
        Me.DueDateDataGridViewTextBoxColumn.DataPropertyName = "DueDate"
        Me.DueDateDataGridViewTextBoxColumn.HeaderText = "Due Date"
        Me.DueDateDataGridViewTextBoxColumn.Name = "DueDateDataGridViewTextBoxColumn"
        Me.DueDateDataGridViewTextBoxColumn.Width = 85
        '
        'AgingLessThan30DataGridViewTextBoxColumn
        '
        Me.AgingLessThan30DataGridViewTextBoxColumn.DataPropertyName = "AgingLessThan30"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.AgingLessThan30DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.AgingLessThan30DataGridViewTextBoxColumn.HeaderText = "< 30"
        Me.AgingLessThan30DataGridViewTextBoxColumn.Name = "AgingLessThan30DataGridViewTextBoxColumn"
        Me.AgingLessThan30DataGridViewTextBoxColumn.ReadOnly = True
        Me.AgingLessThan30DataGridViewTextBoxColumn.Width = 85
        '
        'Aging31To45DataGridViewTextBoxColumn
        '
        Me.Aging31To45DataGridViewTextBoxColumn.DataPropertyName = "Aging31To45"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.Aging31To45DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.Aging31To45DataGridViewTextBoxColumn.HeaderText = "31 - 45"
        Me.Aging31To45DataGridViewTextBoxColumn.Name = "Aging31To45DataGridViewTextBoxColumn"
        Me.Aging31To45DataGridViewTextBoxColumn.ReadOnly = True
        Me.Aging31To45DataGridViewTextBoxColumn.Width = 85
        '
        'Aging46To60DataGridViewTextBoxColumn
        '
        Me.Aging46To60DataGridViewTextBoxColumn.DataPropertyName = "Aging46To60"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.Aging46To60DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.Aging46To60DataGridViewTextBoxColumn.HeaderText = "46 - 60"
        Me.Aging46To60DataGridViewTextBoxColumn.Name = "Aging46To60DataGridViewTextBoxColumn"
        Me.Aging46To60DataGridViewTextBoxColumn.ReadOnly = True
        Me.Aging46To60DataGridViewTextBoxColumn.Width = 85
        '
        'Aging61To90DataGridViewTextBoxColumn
        '
        Me.Aging61To90DataGridViewTextBoxColumn.DataPropertyName = "Aging61To90"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.Aging61To90DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.Aging61To90DataGridViewTextBoxColumn.HeaderText = "61 - 90"
        Me.Aging61To90DataGridViewTextBoxColumn.Name = "Aging61To90DataGridViewTextBoxColumn"
        Me.Aging61To90DataGridViewTextBoxColumn.ReadOnly = True
        Me.Aging61To90DataGridViewTextBoxColumn.Width = 85
        '
        'AgingMoreThan90DataGridViewTextBoxColumn
        '
        Me.AgingMoreThan90DataGridViewTextBoxColumn.DataPropertyName = "AgingMoreThan90"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.AgingMoreThan90DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.AgingMoreThan90DataGridViewTextBoxColumn.HeaderText = "> 90"
        Me.AgingMoreThan90DataGridViewTextBoxColumn.Name = "AgingMoreThan90DataGridViewTextBoxColumn"
        Me.AgingMoreThan90DataGridViewTextBoxColumn.ReadOnly = True
        Me.AgingMoreThan90DataGridViewTextBoxColumn.Width = 85
        '
        'DiscountDateDataGridViewTextBoxColumn
        '
        Me.DiscountDateDataGridViewTextBoxColumn.DataPropertyName = "DiscountDate"
        Me.DiscountDateDataGridViewTextBoxColumn.HeaderText = "Discount Date"
        Me.DiscountDateDataGridViewTextBoxColumn.Name = "DiscountDateDataGridViewTextBoxColumn"
        Me.DiscountDateDataGridViewTextBoxColumn.Width = 85
        '
        'DiscountAmountDataGridViewTextBoxColumn
        '
        Me.DiscountAmountDataGridViewTextBoxColumn.DataPropertyName = "DiscountAmount"
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0"
        Me.DiscountAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.DiscountAmountDataGridViewTextBoxColumn.HeaderText = "Discount Amount"
        Me.DiscountAmountDataGridViewTextBoxColumn.Name = "DiscountAmountDataGridViewTextBoxColumn"
        Me.DiscountAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.DiscountAmountDataGridViewTextBoxColumn.Visible = False
        Me.DiscountAmountDataGridViewTextBoxColumn.Width = 85
        '
        'TodaysDateDataGridViewTextBoxColumn
        '
        Me.TodaysDateDataGridViewTextBoxColumn.DataPropertyName = "TodaysDate"
        Me.TodaysDateDataGridViewTextBoxColumn.HeaderText = "TodaysDate"
        Me.TodaysDateDataGridViewTextBoxColumn.Name = "TodaysDateDataGridViewTextBoxColumn"
        Me.TodaysDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.TodaysDateDataGridViewTextBoxColumn.Visible = False
        '
        'DaysElapsedDataGridViewTextBoxColumn
        '
        Me.DaysElapsedDataGridViewTextBoxColumn.DataPropertyName = "DaysElapsed"
        Me.DaysElapsedDataGridViewTextBoxColumn.HeaderText = "DaysElapsed"
        Me.DaysElapsedDataGridViewTextBoxColumn.Name = "DaysElapsedDataGridViewTextBoxColumn"
        Me.DaysElapsedDataGridViewTextBoxColumn.ReadOnly = True
        Me.DaysElapsedDataGridViewTextBoxColumn.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'PaymentAmountDataGridViewTextBoxColumn
        '
        Me.PaymentAmountDataGridViewTextBoxColumn.DataPropertyName = "PaymentAmount"
        Me.PaymentAmountDataGridViewTextBoxColumn.HeaderText = "PaymentAmount"
        Me.PaymentAmountDataGridViewTextBoxColumn.Name = "PaymentAmountDataGridViewTextBoxColumn"
        Me.PaymentAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.PaymentAmountDataGridViewTextBoxColumn.Visible = False
        '
        'VoucherNumberDataGridViewTextBoxColumn
        '
        Me.VoucherNumberDataGridViewTextBoxColumn.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberDataGridViewTextBoxColumn.HeaderText = "Voucher #"
        Me.VoucherNumberDataGridViewTextBoxColumn.Name = "VoucherNumberDataGridViewTextBoxColumn"
        '
        'VendorClassColumn
        '
        Me.VendorClassColumn.DataPropertyName = "VendorClass"
        Me.VendorClassColumn.HeaderText = "VendorClass"
        Me.VendorClassColumn.Name = "VendorClassColumn"
        Me.VendorClassColumn.Visible = False
        '
        'APAgingCategoryBindingSource
        '
        Me.APAgingCategoryBindingSource.DataMember = "APAgingCategory"
        Me.APAgingCategoryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'APAgingCategoryTableAdapter
        '
        Me.APAgingCategoryTableAdapter.ClearBeforeFill = True
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
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'APVoucherTableTableAdapter
        '
        Me.APVoucherTableTableAdapter.ClearBeforeFill = True
        '
        'txtOpenPayableTotal
        '
        Me.txtOpenPayableTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOpenPayableTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpenPayableTotal.Location = New System.Drawing.Point(625, 784)
        Me.txtOpenPayableTotal.Name = "txtOpenPayableTotal"
        Me.txtOpenPayableTotal.Size = New System.Drawing.Size(182, 20)
        Me.txtOpenPayableTotal.TabIndex = 15
        Me.txtOpenPayableTotal.TabStop = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(458, 784)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(161, 20)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "TOTAL OPEN PAYABLES"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VendorClassTableAdapter
        '
        Me.VendorClassTableAdapter.ClearBeforeFill = True
        '
        'ViewAPAging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtOpenPayableTotal)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvAPAging)
        Me.Controls.Add(Me.gpxAPAging)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewAPAging"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Accounts Payable Aging"
        Me.gpxAPAging.ResumeLayout(False)
        Me.gpxAPAging.PerformLayout()
        CType(Me.VendorClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APVoucherTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvAPAging, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APAgingCategoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxAPAging As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvAPAging As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents APAgingCategoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APAgingCategoryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APAgingCategoryTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents APVoucherTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APVoucherTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APVoucherTableTableAdapter
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOpenPayableTotal As System.Windows.Forms.TextBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents InvoiceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountOpenDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgingLessThan30DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging31To45DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging46To60DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging61To90DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgingMoreThan90DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TodaysDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DaysElapsedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboVendorClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents VendorClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorClassTableAdapter
    Friend WithEvents PrintAgingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents chkOver90 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLessThan90 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLessThan60 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLessthan45 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLessthan30 As System.Windows.Forms.CheckBox
End Class
