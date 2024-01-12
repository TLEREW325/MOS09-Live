<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewWorkOrders
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
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.cboSalesperson = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboWOStatus = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboSONumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cmdClear1 = New System.Windows.Forms.Button
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.dgvWorkOrderHeaderTable = New System.Windows.Forms.DataGridView
        Me.CustomerIDDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalespersonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkOrderDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeaderCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkOrderTotallColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkOrderStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipMethodColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateClosedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WorkOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.WorkOrderHeaderTableTableAdapter
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.dgvWorkOrderLineTable = New System.Windows.Forms.DataGridView
        Me.WorkOrderNumberColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkOrderLineNumberColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LongDescriptionColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumnLT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkOrderLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WorkOrderLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.WorkOrderLineTableTableAdapter
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWorkOrderHeaderTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WorkOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWorkOrderLineTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WorkOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFilter)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboCustomerName)
        Me.GroupBox1.Controls.Add(Me.cboCustomerID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCustomerPO)
        Me.GroupBox1.Controls.Add(Me.cboSalesperson)
        Me.GroupBox1.Controls.Add(Me.cboWOStatus)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cboSONumber)
        Me.GroupBox1.Controls.Add(Me.chkDateRange)
        Me.GroupBox1.Controls.Add(Me.cmdClear1)
        Me.GroupBox1.Controls.Add(Me.dtpEndDate)
        Me.GroupBox1.Controls.Add(Me.dtpBeginDate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmdViewByFilters)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 770)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Show By Filters"
        '
        'txtFilter
        '
        Me.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFilter.Location = New System.Drawing.Point(99, 448)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(181, 20)
        Me.txtFilter.TabIndex = 65
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 448)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 20)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Text Filter"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(13, 150)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(265, 21)
        Me.cboCustomerName.TabIndex = 63
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(73, 121)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(205, 21)
        Me.cboCustomerID.TabIndex = 62
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(11, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Customer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Location = New System.Drawing.Point(97, 253)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(181, 20)
        Me.txtCustomerPO.TabIndex = 51
        '
        'cboSalesperson
        '
        Me.cboSalesperson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesperson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesperson.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalesperson.DisplayMember = "SalesPersonID"
        Me.cboSalesperson.FormattingEnabled = True
        Me.cboSalesperson.Location = New System.Drawing.Point(97, 297)
        Me.cboSalesperson.Name = "cboSalesperson"
        Me.cboSalesperson.Size = New System.Drawing.Size(181, 21)
        Me.cboSalesperson.TabIndex = 56
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboWOStatus
        '
        Me.cboWOStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboWOStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboWOStatus.FormattingEnabled = True
        Me.cboWOStatus.Items.AddRange(New Object() {"OPEN", "PENDING", "CLOSED"})
        Me.cboWOStatus.Location = New System.Drawing.Point(97, 342)
        Me.cboWOStatus.Name = "cboWOStatus"
        Me.cboWOStatus.Size = New System.Drawing.Size(181, 21)
        Me.cboWOStatus.TabIndex = 57
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(16, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 40)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(14, 596)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSONumber
        '
        Me.cboSONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSONumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSONumber.DisplayMember = "SalesOrderKey"
        Me.cboSONumber.FormattingEnabled = True
        Me.cboSONumber.Location = New System.Drawing.Point(97, 208)
        Me.cboSONumber.Name = "cboSONumber"
        Me.cboSONumber.Size = New System.Drawing.Size(181, 21)
        Me.cboSONumber.TabIndex = 55
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(98, 632)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 52
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cmdClear1
        '
        Me.cmdClear1.Location = New System.Drawing.Point(209, 730)
        Me.cmdClear1.Name = "cmdClear1"
        Me.cmdClear1.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear1.TabIndex = 58
        Me.cmdClear1.Text = "Clear"
        Me.cmdClear1.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(97, 691)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpEndDate.TabIndex = 54
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(97, 661)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpBeginDate.TabIndex = 53
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 661)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Begin Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 691)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "End Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(132, 730)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 57
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(99, 34)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(179, 21)
        Me.cboDivisionID.TabIndex = 47
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 20)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Cust. PO #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 341)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 20)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "WO Status"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 297)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 20)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Salesperson"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 20)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Sales Order #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'dgvWorkOrderHeaderTable
        '
        Me.dgvWorkOrderHeaderTable.AllowUserToAddRows = False
        Me.dgvWorkOrderHeaderTable.AllowUserToDeleteRows = False
        Me.dgvWorkOrderHeaderTable.AutoGenerateColumns = False
        Me.dgvWorkOrderHeaderTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvWorkOrderHeaderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWorkOrderHeaderTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDDColumn, Me.SalespersonColumn, Me.WorkOrderNumberColumn, Me.WorkOrderDateColumn, Me.CustomerPOColumn, Me.SalesOrderNumberColumn, Me.HeaderCommentColumn, Me.SpecialInstructionsColumn, Me.TotalExtendedCostColumn, Me.TotalFreightColumn, Me.TotalTaxColumn, Me.WorkOrderTotallColumn, Me.WorkOrderStatusColumn, Me.ShipViaColumn, Me.ShipMethodColumn, Me.ShipToIDColumn, Me.ShipToNameColumn, Me.ShipToAddress1Column, Me.ShipToAddress2Column, Me.ShipToCityColumn, Me.ShipToStateColumn, Me.ShipToZipColumn, Me.ShipToCountryColumn, Me.DateClosedColumn, Me.DivisionIDColumn})
        Me.dgvWorkOrderHeaderTable.DataSource = Me.WorkOrderHeaderTableBindingSource
        Me.dgvWorkOrderHeaderTable.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvWorkOrderHeaderTable.Location = New System.Drawing.Point(349, 75)
        Me.dgvWorkOrderHeaderTable.Name = "dgvWorkOrderHeaderTable"
        Me.dgvWorkOrderHeaderTable.ReadOnly = True
        Me.dgvWorkOrderHeaderTable.Size = New System.Drawing.Size(781, 415)
        Me.dgvWorkOrderHeaderTable.TabIndex = 3
        '
        'CustomerIDDColumn
        '
        Me.CustomerIDDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDDColumn.HeaderText = "Customer"
        Me.CustomerIDDColumn.Name = "CustomerIDDColumn"
        Me.CustomerIDDColumn.ReadOnly = True
        '
        'SalespersonColumn
        '
        Me.SalespersonColumn.DataPropertyName = "Salesperson"
        Me.SalespersonColumn.HeaderText = "Salesperson"
        Me.SalespersonColumn.Name = "SalespersonColumn"
        Me.SalespersonColumn.ReadOnly = True
        '
        'WorkOrderNumberColumn
        '
        Me.WorkOrderNumberColumn.DataPropertyName = "WorkOrderNumber"
        Me.WorkOrderNumberColumn.HeaderText = "WO #"
        Me.WorkOrderNumberColumn.Name = "WorkOrderNumberColumn"
        Me.WorkOrderNumberColumn.ReadOnly = True
        '
        'WorkOrderDateColumn
        '
        Me.WorkOrderDateColumn.DataPropertyName = "WorkOrderDate"
        Me.WorkOrderDateColumn.HeaderText = "WO Date"
        Me.WorkOrderDateColumn.Name = "WorkOrderDateColumn"
        Me.WorkOrderDateColumn.ReadOnly = True
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust. PO #"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.ReadOnly = True
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "SO #"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.ReadOnly = True
        '
        'HeaderCommentColumn
        '
        Me.HeaderCommentColumn.DataPropertyName = "HeaderComment"
        Me.HeaderCommentColumn.HeaderText = "Comment"
        Me.HeaderCommentColumn.Name = "HeaderCommentColumn"
        Me.HeaderCommentColumn.ReadOnly = True
        '
        'SpecialInstructionsColumn
        '
        Me.SpecialInstructionsColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsColumn.HeaderText = "Special Instructions"
        Me.SpecialInstructionsColumn.Name = "SpecialInstructionsColumn"
        Me.SpecialInstructionsColumn.ReadOnly = True
        '
        'TotalExtendedCostColumn
        '
        Me.TotalExtendedCostColumn.DataPropertyName = "TotalExtendedCost"
        Me.TotalExtendedCostColumn.HeaderText = "Total Extended Cost"
        Me.TotalExtendedCostColumn.Name = "TotalExtendedCostColumn"
        Me.TotalExtendedCostColumn.ReadOnly = True
        '
        'TotalFreightColumn
        '
        Me.TotalFreightColumn.DataPropertyName = "TotalFreight"
        Me.TotalFreightColumn.HeaderText = "Total Freight"
        Me.TotalFreightColumn.Name = "TotalFreightColumn"
        Me.TotalFreightColumn.ReadOnly = True
        '
        'TotalTaxColumn
        '
        Me.TotalTaxColumn.DataPropertyName = "TotalTax"
        Me.TotalTaxColumn.HeaderText = "Total Tax"
        Me.TotalTaxColumn.Name = "TotalTaxColumn"
        Me.TotalTaxColumn.ReadOnly = True
        '
        'WorkOrderTotallColumn
        '
        Me.WorkOrderTotallColumn.DataPropertyName = "WorkOrderTotal"
        Me.WorkOrderTotallColumn.HeaderText = "Work Order Total"
        Me.WorkOrderTotallColumn.Name = "WorkOrderTotallColumn"
        Me.WorkOrderTotallColumn.ReadOnly = True
        '
        'WorkOrderStatusColumn
        '
        Me.WorkOrderStatusColumn.DataPropertyName = "WorkOrderStatus"
        Me.WorkOrderStatusColumn.HeaderText = "Work Order Status"
        Me.WorkOrderStatusColumn.Name = "WorkOrderStatusColumn"
        Me.WorkOrderStatusColumn.ReadOnly = True
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        Me.ShipViaColumn.ReadOnly = True
        '
        'ShipMethodColumn
        '
        Me.ShipMethodColumn.DataPropertyName = "ShipMethod"
        Me.ShipMethodColumn.HeaderText = "Ship Method"
        Me.ShipMethodColumn.Name = "ShipMethodColumn"
        Me.ShipMethodColumn.ReadOnly = True
        '
        'ShipToIDColumn
        '
        Me.ShipToIDColumn.DataPropertyName = "ShipToID"
        Me.ShipToIDColumn.HeaderText = "ShipToID"
        Me.ShipToIDColumn.Name = "ShipToIDColumn"
        Me.ShipToIDColumn.ReadOnly = True
        '
        'ShipToNameColumn
        '
        Me.ShipToNameColumn.DataPropertyName = "ShipToName"
        Me.ShipToNameColumn.HeaderText = "Ship To Name"
        Me.ShipToNameColumn.Name = "ShipToNameColumn"
        Me.ShipToNameColumn.ReadOnly = True
        '
        'ShipToAddress1Column
        '
        Me.ShipToAddress1Column.DataPropertyName = "ShipToAddress1"
        Me.ShipToAddress1Column.HeaderText = "Ship To Address 1"
        Me.ShipToAddress1Column.Name = "ShipToAddress1Column"
        Me.ShipToAddress1Column.ReadOnly = True
        '
        'ShipToAddress2Column
        '
        Me.ShipToAddress2Column.DataPropertyName = "ShipToAddress2"
        Me.ShipToAddress2Column.HeaderText = "Ship To Address 2"
        Me.ShipToAddress2Column.Name = "ShipToAddress2Column"
        Me.ShipToAddress2Column.ReadOnly = True
        '
        'ShipToCityColumn
        '
        Me.ShipToCityColumn.DataPropertyName = "ShipToCity"
        Me.ShipToCityColumn.HeaderText = "Ship To City"
        Me.ShipToCityColumn.Name = "ShipToCityColumn"
        Me.ShipToCityColumn.ReadOnly = True
        '
        'ShipToStateColumn
        '
        Me.ShipToStateColumn.DataPropertyName = "ShipToState"
        Me.ShipToStateColumn.HeaderText = "Ship To State"
        Me.ShipToStateColumn.Name = "ShipToStateColumn"
        Me.ShipToStateColumn.ReadOnly = True
        '
        'ShipToZipColumn
        '
        Me.ShipToZipColumn.DataPropertyName = "ShipToZip"
        Me.ShipToZipColumn.HeaderText = "Ship To Zip"
        Me.ShipToZipColumn.Name = "ShipToZipColumn"
        Me.ShipToZipColumn.ReadOnly = True
        '
        'ShipToCountryColumn
        '
        Me.ShipToCountryColumn.DataPropertyName = "ShipToCountry"
        Me.ShipToCountryColumn.HeaderText = "Ship To Country"
        Me.ShipToCountryColumn.Name = "ShipToCountryColumn"
        Me.ShipToCountryColumn.ReadOnly = True
        '
        'DateClosedColumn
        '
        Me.DateClosedColumn.DataPropertyName = "DateClosed"
        Me.DateClosedColumn.HeaderText = "Date Closed"
        Me.DateClosedColumn.Name = "DateClosedColumn"
        Me.DateClosedColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'WorkOrderHeaderTableBindingSource
        '
        Me.WorkOrderHeaderTableBindingSource.DataMember = "WorkOrderHeaderTable"
        Me.WorkOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'WorkOrderHeaderTableTableAdapter
        '
        Me.WorkOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(982, 771)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 40)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Print Listing"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(905, 771)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 40)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Clear All"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dgvWorkOrderLineTable
        '
        Me.dgvWorkOrderLineTable.AllowUserToAddRows = False
        Me.dgvWorkOrderLineTable.AllowUserToDeleteRows = False
        Me.dgvWorkOrderLineTable.AutoGenerateColumns = False
        Me.dgvWorkOrderLineTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvWorkOrderLineTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWorkOrderLineTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WorkOrderNumberColumnLT, Me.WorkOrderLineNumberColumnLT, Me.PartNumberColumnLT, Me.PartDescriptionColumnLT, Me.QuantityColumnLT, Me.UnitCostColumnLT, Me.ExtendedAmountColumnLT, Me.LineCommentColumnLT, Me.CreditGLAccountColumnLT, Me.DebitGLAccountColumnLT, Me.DivisionIDColumnLT, Me.LineStatusColumnLT, Me.LongDescriptionColumnLT, Me.SalesTaxColumnLT})
        Me.dgvWorkOrderLineTable.DataSource = Me.WorkOrderLineTableBindingSource
        Me.dgvWorkOrderLineTable.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvWorkOrderLineTable.Location = New System.Drawing.Point(349, 540)
        Me.dgvWorkOrderLineTable.Name = "dgvWorkOrderLineTable"
        Me.dgvWorkOrderLineTable.ReadOnly = True
        Me.dgvWorkOrderLineTable.Size = New System.Drawing.Size(781, 212)
        Me.dgvWorkOrderLineTable.TabIndex = 6
        '
        'WorkOrderNumberColumnLT
        '
        Me.WorkOrderNumberColumnLT.DataPropertyName = "WorkOrderNumber"
        Me.WorkOrderNumberColumnLT.HeaderText = "WO #"
        Me.WorkOrderNumberColumnLT.Name = "WorkOrderNumberColumnLT"
        Me.WorkOrderNumberColumnLT.ReadOnly = True
        Me.WorkOrderNumberColumnLT.Width = 60
        '
        'WorkOrderLineNumberColumnLT
        '
        Me.WorkOrderLineNumberColumnLT.DataPropertyName = "WorkOrderLineNumber"
        Me.WorkOrderLineNumberColumnLT.HeaderText = "Line #"
        Me.WorkOrderLineNumberColumnLT.Name = "WorkOrderLineNumberColumnLT"
        Me.WorkOrderLineNumberColumnLT.ReadOnly = True
        Me.WorkOrderLineNumberColumnLT.Width = 60
        '
        'PartNumberColumnLT
        '
        Me.PartNumberColumnLT.DataPropertyName = "PartNumber"
        Me.PartNumberColumnLT.HeaderText = "Part #"
        Me.PartNumberColumnLT.Name = "PartNumberColumnLT"
        Me.PartNumberColumnLT.ReadOnly = True
        Me.PartNumberColumnLT.Width = 120
        '
        'PartDescriptionColumnLT
        '
        Me.PartDescriptionColumnLT.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumnLT.HeaderText = "Description"
        Me.PartDescriptionColumnLT.Name = "PartDescriptionColumnLT"
        Me.PartDescriptionColumnLT.ReadOnly = True
        Me.PartDescriptionColumnLT.Width = 120
        '
        'QuantityColumnLT
        '
        Me.QuantityColumnLT.DataPropertyName = "Quantity"
        Me.QuantityColumnLT.HeaderText = "Quantity"
        Me.QuantityColumnLT.Name = "QuantityColumnLT"
        Me.QuantityColumnLT.ReadOnly = True
        Me.QuantityColumnLT.Width = 60
        '
        'UnitCostColumnLT
        '
        Me.UnitCostColumnLT.DataPropertyName = "UnitCost"
        Me.UnitCostColumnLT.HeaderText = "Unit Cost"
        Me.UnitCostColumnLT.Name = "UnitCostColumnLT"
        Me.UnitCostColumnLT.ReadOnly = True
        Me.UnitCostColumnLT.Width = 80
        '
        'ExtendedAmountColumnLT
        '
        Me.ExtendedAmountColumnLT.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumnLT.HeaderText = "Ext. Cost"
        Me.ExtendedAmountColumnLT.Name = "ExtendedAmountColumnLT"
        Me.ExtendedAmountColumnLT.ReadOnly = True
        Me.ExtendedAmountColumnLT.Width = 80
        '
        'LineCommentColumnLT
        '
        Me.LineCommentColumnLT.DataPropertyName = "LineComment"
        Me.LineCommentColumnLT.HeaderText = "Comment"
        Me.LineCommentColumnLT.Name = "LineCommentColumnLT"
        Me.LineCommentColumnLT.ReadOnly = True
        Me.LineCommentColumnLT.Width = 200
        '
        'CreditGLAccountColumnLT
        '
        Me.CreditGLAccountColumnLT.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumnLT.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountColumnLT.Name = "CreditGLAccountColumnLT"
        Me.CreditGLAccountColumnLT.ReadOnly = True
        Me.CreditGLAccountColumnLT.Visible = False
        '
        'DebitGLAccountColumnLT
        '
        Me.DebitGLAccountColumnLT.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumnLT.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountColumnLT.Name = "DebitGLAccountColumnLT"
        Me.DebitGLAccountColumnLT.ReadOnly = True
        Me.DebitGLAccountColumnLT.Visible = False
        '
        'DivisionIDColumnLT
        '
        Me.DivisionIDColumnLT.DataPropertyName = "DivisionID"
        Me.DivisionIDColumnLT.HeaderText = "DivisionID"
        Me.DivisionIDColumnLT.Name = "DivisionIDColumnLT"
        Me.DivisionIDColumnLT.ReadOnly = True
        '
        'LineStatusColumnLT
        '
        Me.LineStatusColumnLT.DataPropertyName = "LineStatus"
        Me.LineStatusColumnLT.HeaderText = "LineStatus"
        Me.LineStatusColumnLT.Name = "LineStatusColumnLT"
        Me.LineStatusColumnLT.ReadOnly = True
        '
        'LongDescriptionColumnLT
        '
        Me.LongDescriptionColumnLT.DataPropertyName = "LongDescription"
        Me.LongDescriptionColumnLT.HeaderText = "LongDescription"
        Me.LongDescriptionColumnLT.Name = "LongDescriptionColumnLT"
        Me.LongDescriptionColumnLT.ReadOnly = True
        Me.LongDescriptionColumnLT.Visible = False
        '
        'SalesTaxColumnLT
        '
        Me.SalesTaxColumnLT.DataPropertyName = "SalesTax"
        Me.SalesTaxColumnLT.HeaderText = "SalesTax"
        Me.SalesTaxColumnLT.Name = "SalesTaxColumnLT"
        Me.SalesTaxColumnLT.ReadOnly = True
        Me.SalesTaxColumnLT.Visible = False
        '
        'WorkOrderLineTableBindingSource
        '
        Me.WorkOrderLineTableBindingSource.DataMember = "WorkOrderLineTable"
        Me.WorkOrderLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'WorkOrderLineTableTableAdapter
        '
        Me.WorkOrderLineTableTableAdapter.ClearBeforeFill = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(346, 512)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(443, 25)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "WORK ORDER LINE ITEMS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(346, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(443, 25)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "WORK ORDERS"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewWorkOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgvWorkOrderLineTable)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvWorkOrderHeaderTable)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewWorkOrders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Work Orders"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWorkOrderHeaderTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWorkOrderLineTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboSalesperson As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboSONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboWOStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents cmdClear1 As System.Windows.Forms.Button
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents dgvWorkOrderHeaderTable As System.Windows.Forms.DataGridView
    Friend WithEvents WorkOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.WorkOrderHeaderTableTableAdapter
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dgvWorkOrderLineTable As System.Windows.Forms.DataGridView
    Friend WithEvents WorkOrderLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkOrderLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.WorkOrderLineTableTableAdapter
    Friend WithEvents WorkOrderNumberColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkOrderLineNumberColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongDescriptionColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumnLT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalespersonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkOrderDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeaderCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkOrderTotallColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkOrderStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipMethodColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateClosedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
