<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewLeadTimes
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxAPVoucherData = New System.Windows.Forms.GroupBox
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label9 = New System.Windows.Forms.Label
        Me.chkBlank = New System.Windows.Forms.CheckBox
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboSalesperson = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.SalesOrderLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SalesOrderLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineQueryTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.txtdatedifference = New System.Windows.Forms.TextBox
        Me.cmdPrintLeadReport = New System.Windows.Forms.Button
        Me.dgvSalesOrderLineQueryLeadTimes = New System.Windows.Forms.DataGridView
        Me.DivisionKeyColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderDateColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOpenColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeadTimeDateColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalespersonColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderLineKeyColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeadTimeColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderLineQueryLeadTimesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SalesOrderLineQueryLeadTimesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineQueryLeadTimesTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAPVoucherData.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSalesOrderLineQueryLeadTimes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderLineQueryLeadTimesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gpxAPVoucherData
        '
        Me.gpxAPVoucherData.Controls.Add(Me.cboItemClass)
        Me.gpxAPVoucherData.Controls.Add(Me.Label9)
        Me.gpxAPVoucherData.Controls.Add(Me.chkBlank)
        Me.gpxAPVoucherData.Controls.Add(Me.txtTextFilter)
        Me.gpxAPVoucherData.Controls.Add(Me.Label10)
        Me.gpxAPVoucherData.Controls.Add(Me.cboSalesperson)
        Me.gpxAPVoucherData.Controls.Add(Me.Label6)
        Me.gpxAPVoucherData.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label4)
        Me.gpxAPVoucherData.Controls.Add(Me.Label12)
        Me.gpxAPVoucherData.Controls.Add(Me.Label14)
        Me.gpxAPVoucherData.Controls.Add(Me.chkDateRange)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpEndDate)
        Me.gpxAPVoucherData.Controls.Add(Me.txtCustomerPO)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCustomerName)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPVoucherData.Controls.Add(Me.Label7)
        Me.gpxAPVoucherData.Controls.Add(Me.Label2)
        Me.gpxAPVoucherData.Controls.Add(Me.Label8)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCustomerID)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPartDescription)
        Me.gpxAPVoucherData.Controls.Add(Me.cboDivisionID)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPartNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label3)
        Me.gpxAPVoucherData.Controls.Add(Me.Label5)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdViewByFilter)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdClear)
        Me.gpxAPVoucherData.Controls.Add(Me.Label1)
        Me.gpxAPVoucherData.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPVoucherData.Name = "gpxAPVoucherData"
        Me.gpxAPVoucherData.Size = New System.Drawing.Size(300, 770)
        Me.gpxAPVoucherData.TabIndex = 0
        Me.gpxAPVoucherData.TabStop = False
        Me.gpxAPVoucherData.Text = "View By Filters"
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(90, 261)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(194, 21)
        Me.cboItemClass.TabIndex = 5
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 262)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "Item Class"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkBlank
        '
        Me.chkBlank.AutoSize = True
        Me.chkBlank.Checked = True
        Me.chkBlank.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBlank.Location = New System.Drawing.Point(90, 474)
        Me.chkBlank.Name = "chkBlank"
        Me.chkBlank.Size = New System.Drawing.Size(160, 17)
        Me.chkBlank.TabIndex = 11
        Me.chkBlank.Text = "Omit Lines W/O Lead Times"
        Me.chkBlank.UseVisualStyleBackColor = True
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(90, 432)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(194, 20)
        Me.txtTextFilter.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 432)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Text Filter"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesperson
        '
        Me.cboSalesperson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesperson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesperson.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalesperson.DisplayMember = "SalesPersonID"
        Me.cboSalesperson.FormattingEnabled = True
        Me.cboSalesperson.Location = New System.Drawing.Point(90, 347)
        Me.cboSalesperson.Name = "cboSalesperson"
        Me.cboSalesperson.Size = New System.Drawing.Size(194, 21)
        Me.cboSalesperson.TabIndex = 7
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 348)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Salesperson"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(90, 304)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(194, 21)
        Me.cboSalesOrderNumber.TabIndex = 6
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 305)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "SO #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(15, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 40)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(18, 571)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(266, 33)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "To include date range in the filter, you must check the box. Filter is for Sales " & _
            "Order Date."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(104, 619)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 12
        Me.chkDateRange.TabStop = False
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(104, 679)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpEndDate.TabIndex = 14
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Location = New System.Drawing.Point(90, 390)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(194, 20)
        Me.txtCustomerPO.TabIndex = 8
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(19, 140)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(265, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(104, 647)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpBeginDate.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 679)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "End Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 390)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Cust. PO#"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 649)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Begin Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(72, 109)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(212, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(14, 214)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(270, 21)
        Me.cboPartDescription.TabIndex = 4
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(90, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(194, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(72, 182)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(212, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Customer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Part #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(136, 722)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 15
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 722)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 16
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1051, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 21
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(974, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 20
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'SalesOrderLineQueryBindingSource
        '
        Me.SalesOrderLineQueryBindingSource.DataMember = "SalesOrderLineQuery"
        Me.SalesOrderLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SalesOrderLineQueryTableAdapter
        '
        Me.SalesOrderLineQueryTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'txtdatedifference
        '
        Me.txtdatedifference.Location = New System.Drawing.Point(504, 641)
        Me.txtdatedifference.Name = "txtdatedifference"
        Me.txtdatedifference.Size = New System.Drawing.Size(171, 20)
        Me.txtdatedifference.TabIndex = 18
        Me.txtdatedifference.Visible = False
        '
        'cmdPrintLeadReport
        '
        Me.cmdPrintLeadReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintLeadReport.Location = New System.Drawing.Point(349, 771)
        Me.cmdPrintLeadReport.Name = "cmdPrintLeadReport"
        Me.cmdPrintLeadReport.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintLeadReport.TabIndex = 19
        Me.cmdPrintLeadReport.Text = "Lead Report"
        Me.cmdPrintLeadReport.UseVisualStyleBackColor = True
        '
        'dgvSalesOrderLineQueryLeadTimes
        '
        Me.dgvSalesOrderLineQueryLeadTimes.AllowUserToAddRows = False
        Me.dgvSalesOrderLineQueryLeadTimes.AllowUserToDeleteRows = False
        Me.dgvSalesOrderLineQueryLeadTimes.AllowUserToOrderColumns = True
        Me.dgvSalesOrderLineQueryLeadTimes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSalesOrderLineQueryLeadTimes.AutoGenerateColumns = False
        Me.dgvSalesOrderLineQueryLeadTimes.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSalesOrderLineQueryLeadTimes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSalesOrderLineQueryLeadTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesOrderLineQueryLeadTimes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionKeyColumnLT, Me.SalesOrderKeyColumnLT, Me.SalesOrderDateColumnLT, Me.CustomerIDColumnLT, Me.ItemIDColumnLT, Me.DescriptionColumnLT, Me.QuantityOpenColumnLT, Me.LeadTimeDateColumnLT, Me.LineCommentColumnLT, Me.CustomerPOColumnLT, Me.SalespersonColumnLT, Me.LineStatusColumnLT, Me.SalesOrderLineKeyColumnLT, Me.LeadTimeColumnLT, Me.QuantityColumnLT})
        Me.dgvSalesOrderLineQueryLeadTimes.DataSource = Me.SalesOrderLineQueryLeadTimesBindingSource
        Me.dgvSalesOrderLineQueryLeadTimes.GridColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvSalesOrderLineQueryLeadTimes.Location = New System.Drawing.Point(349, 41)
        Me.dgvSalesOrderLineQueryLeadTimes.Name = "dgvSalesOrderLineQueryLeadTimes"
        Me.dgvSalesOrderLineQueryLeadTimes.Size = New System.Drawing.Size(773, 707)
        Me.dgvSalesOrderLineQueryLeadTimes.TabIndex = 20
        '
        'DivisionKeyColumnLT
        '
        Me.DivisionKeyColumnLT.DataPropertyName = "DivisionKey"
        Me.DivisionKeyColumnLT.HeaderText = "Division"
        Me.DivisionKeyColumnLT.Name = "DivisionKeyColumnLT"
        Me.DivisionKeyColumnLT.ReadOnly = True
        Me.DivisionKeyColumnLT.Visible = False
        Me.DivisionKeyColumnLT.Width = 65
        '
        'SalesOrderKeyColumnLT
        '
        Me.SalesOrderKeyColumnLT.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumnLT.HeaderText = "SO #"
        Me.SalesOrderKeyColumnLT.Name = "SalesOrderKeyColumnLT"
        Me.SalesOrderKeyColumnLT.ReadOnly = True
        Me.SalesOrderKeyColumnLT.Width = 65
        '
        'SalesOrderDateColumnLT
        '
        Me.SalesOrderDateColumnLT.DataPropertyName = "SalesOrderDate"
        Me.SalesOrderDateColumnLT.HeaderText = "Date"
        Me.SalesOrderDateColumnLT.Name = "SalesOrderDateColumnLT"
        Me.SalesOrderDateColumnLT.ReadOnly = True
        Me.SalesOrderDateColumnLT.Width = 65
        '
        'CustomerIDColumnLT
        '
        Me.CustomerIDColumnLT.DataPropertyName = "CustomerID"
        Me.CustomerIDColumnLT.HeaderText = "Customer"
        Me.CustomerIDColumnLT.Name = "CustomerIDColumnLT"
        Me.CustomerIDColumnLT.ReadOnly = True
        '
        'ItemIDColumnLT
        '
        Me.ItemIDColumnLT.DataPropertyName = "ItemID"
        Me.ItemIDColumnLT.HeaderText = "Part #"
        Me.ItemIDColumnLT.Name = "ItemIDColumnLT"
        Me.ItemIDColumnLT.ReadOnly = True
        '
        'DescriptionColumnLT
        '
        Me.DescriptionColumnLT.DataPropertyName = "Description"
        Me.DescriptionColumnLT.HeaderText = "Description"
        Me.DescriptionColumnLT.Name = "DescriptionColumnLT"
        Me.DescriptionColumnLT.ReadOnly = True
        '
        'QuantityOpenColumnLT
        '
        Me.QuantityOpenColumnLT.DataPropertyName = "QuantityOpen"
        Me.QuantityOpenColumnLT.HeaderText = "Qty. Open"
        Me.QuantityOpenColumnLT.Name = "QuantityOpenColumnLT"
        Me.QuantityOpenColumnLT.ReadOnly = True
        '
        'LeadTimeDateColumnLT
        '
        Me.LeadTimeDateColumnLT.DataPropertyName = "LeadTimeDate"
        DataGridViewCellStyle1.Format = "MM/dd/yyyy"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.LeadTimeDateColumnLT.DefaultCellStyle = DataGridViewCellStyle1
        Me.LeadTimeDateColumnLT.HeaderText = "Lead Time"
        Me.LeadTimeDateColumnLT.Name = "LeadTimeDateColumnLT"
        '
        'LineCommentColumnLT
        '
        Me.LineCommentColumnLT.DataPropertyName = "LineComment"
        Me.LineCommentColumnLT.HeaderText = "Comment"
        Me.LineCommentColumnLT.Name = "LineCommentColumnLT"
        '
        'CustomerPOColumnLT
        '
        Me.CustomerPOColumnLT.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumnLT.HeaderText = "Cust. PO"
        Me.CustomerPOColumnLT.Name = "CustomerPOColumnLT"
        Me.CustomerPOColumnLT.ReadOnly = True
        '
        'SalespersonColumnLT
        '
        Me.SalespersonColumnLT.DataPropertyName = "Salesperson"
        Me.SalespersonColumnLT.HeaderText = "Salesperson"
        Me.SalespersonColumnLT.Name = "SalespersonColumnLT"
        Me.SalespersonColumnLT.ReadOnly = True
        '
        'LineStatusColumnLT
        '
        Me.LineStatusColumnLT.DataPropertyName = "LineStatus"
        Me.LineStatusColumnLT.HeaderText = "Line Status"
        Me.LineStatusColumnLT.Name = "LineStatusColumnLT"
        Me.LineStatusColumnLT.ReadOnly = True
        '
        'SalesOrderLineKeyColumnLT
        '
        Me.SalesOrderLineKeyColumnLT.DataPropertyName = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumnLT.HeaderText = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumnLT.Name = "SalesOrderLineKeyColumnLT"
        Me.SalesOrderLineKeyColumnLT.ReadOnly = True
        Me.SalesOrderLineKeyColumnLT.Visible = False
        '
        'LeadTimeColumnLT
        '
        Me.LeadTimeColumnLT.DataPropertyName = "LeadTime"
        Me.LeadTimeColumnLT.HeaderText = "LeadTime"
        Me.LeadTimeColumnLT.Name = "LeadTimeColumnLT"
        Me.LeadTimeColumnLT.Visible = False
        '
        'QuantityColumnLT
        '
        Me.QuantityColumnLT.DataPropertyName = "Quantity"
        Me.QuantityColumnLT.HeaderText = "Quantity"
        Me.QuantityColumnLT.Name = "QuantityColumnLT"
        Me.QuantityColumnLT.ReadOnly = True
        Me.QuantityColumnLT.Visible = False
        Me.QuantityColumnLT.Width = 90
        '
        'SalesOrderLineQueryLeadTimesBindingSource
        '
        Me.SalesOrderLineQueryLeadTimesBindingSource.DataMember = "SalesOrderLineQueryLeadTimes"
        Me.SalesOrderLineQueryLeadTimesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SalesOrderLineQueryLeadTimesTableAdapter
        '
        Me.SalesOrderLineQueryLeadTimesTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'ViewLeadTimes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvSalesOrderLineQueryLeadTimes)
        Me.Controls.Add(Me.cmdPrintLeadReport)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxAPVoucherData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtdatedifference)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewLeadTimes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Lead Time Scheduler"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAPVoucherData.ResumeLayout(False)
        Me.gpxAPVoucherData.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSalesOrderLineQueryLeadTimes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderLineQueryLeadTimesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxAPVoucherData As System.Windows.Forms.GroupBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents SalesOrderLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineQueryTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents cboSalesperson As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents txtdatedifference As System.Windows.Forms.TextBox
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkBlank As System.Windows.Forms.CheckBox
    Friend WithEvents cmdPrintLeadReport As System.Windows.Forms.Button
    Friend WithEvents dgvSalesOrderLineQueryLeadTimes As System.Windows.Forms.DataGridView
    Friend WithEvents SalesOrderLineQueryLeadTimesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderLineQueryLeadTimesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineQueryLeadTimesTableAdapter
    Friend WithEvents DivisionKeyColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderDateColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTimeDateColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalespersonColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderLineKeyColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTimeColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
End Class
