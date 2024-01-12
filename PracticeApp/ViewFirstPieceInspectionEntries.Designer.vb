<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewFirstPieceInspectionEntries
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxFilters = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtOperationSearch = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtInspectorSearch = New System.Windows.Forms.TextBox
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboBlueprintNumber = New System.Windows.Forms.ComboBox
        Me.FOXTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.lblFoxNumberLabel = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrintListing = New System.Windows.Forms.Button
        Me.dgvInspectionEntry = New System.Windows.Forms.DataGridView
        Me.InspectionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InspectionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlueprintNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevisionLevelColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OperationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeaderCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShiftColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OperatorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QCInspectionHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.QCInspectionHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.QCInspectionHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.FOXTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxFilters.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInspectionEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QCInspectionHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ExitToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem1})
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
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Edit"
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
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem2})
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'ExitToolStripMenuItem2
        '
        Me.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2"
        Me.ExitToolStripMenuItem2.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem2.Text = "Exit"
        '
        'gpxFilters
        '
        Me.gpxFilters.Controls.Add(Me.cboDivisionID)
        Me.gpxFilters.Controls.Add(Me.Label7)
        Me.gpxFilters.Controls.Add(Me.txtOperationSearch)
        Me.gpxFilters.Controls.Add(Me.Label6)
        Me.gpxFilters.Controls.Add(Me.txtInspectorSearch)
        Me.gpxFilters.Controls.Add(Me.cboCustomerName)
        Me.gpxFilters.Controls.Add(Me.cboCustomerID)
        Me.gpxFilters.Controls.Add(Me.Label5)
        Me.gpxFilters.Controls.Add(Me.chkDateRange)
        Me.gpxFilters.Controls.Add(Me.dtpEndDate)
        Me.gpxFilters.Controls.Add(Me.Label4)
        Me.gpxFilters.Controls.Add(Me.dtpBeginDate)
        Me.gpxFilters.Controls.Add(Me.Label13)
        Me.gpxFilters.Controls.Add(Me.cmdClear)
        Me.gpxFilters.Controls.Add(Me.cmdViewByFilters)
        Me.gpxFilters.Controls.Add(Me.Label3)
        Me.gpxFilters.Controls.Add(Me.cboBlueprintNumber)
        Me.gpxFilters.Controls.Add(Me.Label2)
        Me.gpxFilters.Controls.Add(Me.cboPartDescription)
        Me.gpxFilters.Controls.Add(Me.cboPartNumber)
        Me.gpxFilters.Controls.Add(Me.Label1)
        Me.gpxFilters.Controls.Add(Me.cboFOXNumber)
        Me.gpxFilters.Controls.Add(Me.lblFoxNumberLabel)
        Me.gpxFilters.Location = New System.Drawing.Point(29, 41)
        Me.gpxFilters.Name = "gpxFilters"
        Me.gpxFilters.Size = New System.Drawing.Size(300, 636)
        Me.gpxFilters.TabIndex = 0
        Me.gpxFilters.TabStop = False
        Me.gpxFilters.Text = "View By Filters"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(88, 36)
        Me.cboDivisionID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(197, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(13, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Division"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOperationSearch
        '
        Me.txtOperationSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperationSearch.Location = New System.Drawing.Point(85, 436)
        Me.txtOperationSearch.Name = "txtOperationSearch"
        Me.txtOperationSearch.Size = New System.Drawing.Size(197, 20)
        Me.txtOperationSearch.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 436)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "Operation"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInspectorSearch
        '
        Me.txtInspectorSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInspectorSearch.Location = New System.Drawing.Point(85, 388)
        Me.txtInspectorSearch.Name = "txtInspectorSearch"
        Me.txtInspectorSearch.Size = New System.Drawing.Size(197, 20)
        Me.txtInspectorSearch.TabIndex = 8
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(12, 265)
        Me.cboCustomerName.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(270, 21)
        Me.cboCustomerName.TabIndex = 6
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(85, 236)
        Me.cboCustomerID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(197, 21)
        Me.cboCustomerID.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Customer"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(108, 491)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 10
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(108, 559)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpEndDate.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 559)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "End Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(108, 526)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpBeginDate.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(12, 526)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 75
        Me.Label13.Text = "Begin Date"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 593)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(135, 593)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 13
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 388)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Inspector"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBlueprintNumber
        '
        Me.cboBlueprintNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBlueprintNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBlueprintNumber.DataSource = Me.FOXTableBindingSource
        Me.cboBlueprintNumber.DisplayMember = "BlueprintNumber"
        Me.cboBlueprintNumber.FormattingEnabled = True
        Me.cboBlueprintNumber.Location = New System.Drawing.Point(85, 339)
        Me.cboBlueprintNumber.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        Me.cboBlueprintNumber.Name = "cboBlueprintNumber"
        Me.cboBlueprintNumber.Size = New System.Drawing.Size(197, 21)
        Me.cboBlueprintNumber.TabIndex = 7
        '
        'FOXTableBindingSource
        '
        Me.FOXTableBindingSource.DataMember = "FOXTable"
        Me.FOXTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 342)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Blueprint #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(15, 181)
        Me.cboPartDescription.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(270, 21)
        Me.cboPartDescription.TabIndex = 4
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(55, 151)
        Me.cboPartNumber.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(227, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Part #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.DataSource = Me.FOXTableBindingSource
        Me.cboFOXNumber.DisplayMember = "FOXNumber"
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(135, 91)
        Me.cboFOXNumber.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(148, 21)
        Me.cboFOXNumber.TabIndex = 2
        '
        'lblFoxNumberLabel
        '
        Me.lblFoxNumberLabel.Location = New System.Drawing.Point(12, 92)
        Me.lblFoxNumberLabel.Name = "lblFoxNumberLabel"
        Me.lblFoxNumberLabel.Size = New System.Drawing.Size(100, 20)
        Me.lblFoxNumberLabel.TabIndex = 0
        Me.lblFoxNumberLabel.Text = "FOX #"
        Me.lblFoxNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrintListing
        '
        Me.cmdPrintListing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintListing.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrintListing.Name = "cmdPrintListing"
        Me.cmdPrintListing.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintListing.TabIndex = 17
        Me.cmdPrintListing.Text = "Print Listing"
        Me.cmdPrintListing.UseVisualStyleBackColor = True
        '
        'dgvInspectionEntry
        '
        Me.dgvInspectionEntry.AllowUserToAddRows = False
        Me.dgvInspectionEntry.AutoGenerateColumns = False
        Me.dgvInspectionEntry.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInspectionEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInspectionEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InspectionKeyColumn, Me.CustomerColumn, Me.InspectionDateColumn, Me.FOXNumberColumn, Me.PartNumberColumn, Me.DescriptionColumn, Me.BlueprintNumberColumn, Me.RevisionLevelColumn, Me.OperationColumn, Me.LotNumberColumn, Me.HeaderCommentColumn, Me.ShiftColumn, Me.MachineNumberColumn, Me.OperatorColumn, Me.DivisionIDColumn})
        Me.dgvInspectionEntry.DataSource = Me.QCInspectionHeaderTableBindingSource
        Me.dgvInspectionEntry.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvInspectionEntry.Location = New System.Drawing.Point(349, 41)
        Me.dgvInspectionEntry.Name = "dgvInspectionEntry"
        Me.dgvInspectionEntry.Size = New System.Drawing.Size(781, 711)
        Me.dgvInspectionEntry.TabIndex = 16
        '
        'InspectionKeyColumn
        '
        Me.InspectionKeyColumn.DataPropertyName = "InspectionKey"
        Me.InspectionKeyColumn.HeaderText = "Inspection #"
        Me.InspectionKeyColumn.Name = "InspectionKeyColumn"
        Me.InspectionKeyColumn.ReadOnly = True
        '
        'CustomerColumn
        '
        Me.CustomerColumn.DataPropertyName = "Customer"
        Me.CustomerColumn.HeaderText = "Customer"
        Me.CustomerColumn.Name = "CustomerColumn"
        Me.CustomerColumn.ReadOnly = True
        Me.CustomerColumn.Width = 120
        '
        'InspectionDateColumn
        '
        Me.InspectionDateColumn.DataPropertyName = "InspectionDate"
        Me.InspectionDateColumn.HeaderText = "Inspection Date"
        Me.InspectionDateColumn.Name = "InspectionDateColumn"
        Me.InspectionDateColumn.ReadOnly = True
        Me.InspectionDateColumn.Width = 80
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        Me.FOXNumberColumn.Width = 80
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.ReadOnly = True
        '
        'BlueprintNumberColumn
        '
        Me.BlueprintNumberColumn.DataPropertyName = "BlueprintNumber"
        Me.BlueprintNumberColumn.HeaderText = "B/P #"
        Me.BlueprintNumberColumn.Name = "BlueprintNumberColumn"
        Me.BlueprintNumberColumn.ReadOnly = True
        Me.BlueprintNumberColumn.Width = 80
        '
        'RevisionLevelColumn
        '
        Me.RevisionLevelColumn.DataPropertyName = "RevisionLevel"
        Me.RevisionLevelColumn.HeaderText = "Rev."
        Me.RevisionLevelColumn.Name = "RevisionLevelColumn"
        Me.RevisionLevelColumn.ReadOnly = True
        Me.RevisionLevelColumn.Width = 80
        '
        'OperationColumn
        '
        Me.OperationColumn.DataPropertyName = "Operation"
        Me.OperationColumn.HeaderText = "Operation"
        Me.OperationColumn.Name = "OperationColumn"
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        '
        'HeaderCommentColumn
        '
        Me.HeaderCommentColumn.DataPropertyName = "HeaderComment"
        Me.HeaderCommentColumn.HeaderText = "Comment"
        Me.HeaderCommentColumn.Name = "HeaderCommentColumn"
        '
        'ShiftColumn
        '
        Me.ShiftColumn.DataPropertyName = "Shift"
        Me.ShiftColumn.HeaderText = "Shift"
        Me.ShiftColumn.Name = "ShiftColumn"
        '
        'MachineNumberColumn
        '
        Me.MachineNumberColumn.DataPropertyName = "MachineNumber"
        Me.MachineNumberColumn.HeaderText = "Machine #"
        Me.MachineNumberColumn.Name = "MachineNumberColumn"
        '
        'OperatorColumn
        '
        Me.OperatorColumn.DataPropertyName = "Operator"
        Me.OperatorColumn.HeaderText = "Operator"
        Me.OperatorColumn.Name = "OperatorColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Width = 80
        '
        'QCInspectionHeaderTableBindingSource
        '
        Me.QCInspectionHeaderTableBindingSource.DataMember = "QCInspectionHeaderTable"
        Me.QCInspectionHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'QCInspectionHeaderTableTableAdapter
        '
        Me.QCInspectionHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'FOXTableTableAdapter
        '
        Me.FOXTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ViewFirstPieceInspectionEntries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvInspectionEntry)
        Me.Controls.Add(Me.cmdPrintListing)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxFilters)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(1080, 760)
        Me.Name = "ViewFirstPieceInspectionEntries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation First Piece Inspections"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxFilters.ResumeLayout(False)
        Me.gpxFilters.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInspectionEntry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QCInspectionHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxFilters As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents lblFoxNumberLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboBlueprintNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdPrintListing As System.Windows.Forms.Button
    Friend WithEvents txtOperationSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtInspectorSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvInspectionEntry As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents QCInspectionHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents QCInspectionHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.QCInspectionHeaderTableTableAdapter
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents FOXTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOXTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents InspectionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InspectionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlueprintNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevisionLevelColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperationColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeaderCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperatorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
