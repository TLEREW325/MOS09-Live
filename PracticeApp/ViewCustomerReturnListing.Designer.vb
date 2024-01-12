<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCustomerReturnListing
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReturnProductHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxCustomerReturnsFilter = New System.Windows.Forms.GroupBox
        Me.cboDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboSalesperson = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboReturnNumber = New System.Windows.Forms.ComboBox
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboReturnStatus = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ReturnProductHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.ReturnProductLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReturnProductLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductLineQueryTableAdapter
        Me.dgvReturnLineQuery = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCOSColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalespersonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOBColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTotalSales = New System.Windows.Forms.TextBox
        Me.txtTotalCOS = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxCustomerReturnsFilter.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReturnProductLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReturnLineQuery, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'ReturnProductHeaderTableBindingSource
        '
        Me.ReturnProductHeaderTableBindingSource.DataMember = "ReturnProductHeaderTable"
        Me.ReturnProductHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1061, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(983, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxCustomerReturnsFilter
        '
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.cboDescription)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.cboPartNumber)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.Label9)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.Label14)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.chkDateRange)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.dtpEndDate)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.Label2)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.dtpBeginDate)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.Label6)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.Label12)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.cboSalesperson)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.Label8)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.cboReturnNumber)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.cboCustomerName)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.Label1)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.cboCustomerID)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.Label7)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.cboDivisionID)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.cboReturnStatus)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.Label5)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.Label3)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.cmdClear)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.Label4)
        Me.gpxCustomerReturnsFilter.Controls.Add(Me.cmdView)
        Me.gpxCustomerReturnsFilter.Location = New System.Drawing.Point(29, 41)
        Me.gpxCustomerReturnsFilter.Name = "gpxCustomerReturnsFilter"
        Me.gpxCustomerReturnsFilter.Size = New System.Drawing.Size(300, 769)
        Me.gpxCustomerReturnsFilter.TabIndex = 0
        Me.gpxCustomerReturnsFilter.TabStop = False
        Me.gpxCustomerReturnsFilter.Text = "View By Filters"
        '
        'cboDescription
        '
        Me.cboDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDescription.DataSource = Me.ItemListBindingSource
        Me.cboDescription.DisplayMember = "ShortDescription"
        Me.cboDescription.DropDownWidth = 300
        Me.cboDescription.FormattingEnabled = True
        Me.cboDescription.Location = New System.Drawing.Point(21, 235)
        Me.cboDescription.Name = "cboDescription"
        Me.cboDescription.Size = New System.Drawing.Size(262, 21)
        Me.cboDescription.TabIndex = 4
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
        Me.cboPartNumber.DropDownWidth = 250
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(94, 204)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 205)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 20)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Part #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(18, 586)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(265, 33)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(96, 622)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 9
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(96, 684)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(187, 20)
        Me.dtpEndDate.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 686)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 20)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "End Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(96, 649)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(187, 20)
        Me.dtpBeginDate.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 651)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 20)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Begin Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(18, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(271, 42)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesperson
        '
        Me.cboSalesperson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesperson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesperson.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalesperson.DisplayMember = "SalesPersonID"
        Me.cboSalesperson.DropDownWidth = 250
        Me.cboSalesperson.FormattingEnabled = True
        Me.cboSalesperson.Location = New System.Drawing.Point(21, 492)
        Me.cboSalesperson.Name = "cboSalesperson"
        Me.cboSalesperson.Size = New System.Drawing.Size(262, 21)
        Me.cboSalesperson.TabIndex = 8
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 469)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 20)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Salesperson"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboReturnNumber
        '
        Me.cboReturnNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnNumber.DataSource = Me.ReturnProductHeaderTableBindingSource
        Me.cboReturnNumber.DisplayMember = "ReturnNumber"
        Me.cboReturnNumber.FormattingEnabled = True
        Me.cboReturnNumber.Location = New System.Drawing.Point(94, 356)
        Me.cboReturnNumber.Name = "cboReturnNumber"
        Me.cboReturnNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboReturnNumber.TabIndex = 6
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(21, 154)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(262, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(94, 302)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboSalesOrderNumber.TabIndex = 5
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 358)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Return #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(94, 123)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(189, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(18, 302)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Sales Order #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(94, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(189, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboReturnStatus
        '
        Me.cboReturnStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnStatus.FormattingEnabled = True
        Me.cboReturnStatus.Items.AddRange(New Object() {"OPEN", "PENDING", "CLOSED"})
        Me.cboReturnStatus.Location = New System.Drawing.Point(94, 416)
        Me.cboReturnStatus.Name = "cboReturnStatus"
        Me.cboReturnStatus.Size = New System.Drawing.Size(189, 21)
        Me.cboReturnStatus.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Customer ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 418)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Return Status"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 722)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(135, 722)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 12
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ReturnProductHeaderTableTableAdapter
        '
        Me.ReturnProductHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'ReturnProductLineQueryBindingSource
        '
        Me.ReturnProductLineQueryBindingSource.DataMember = "ReturnProductLineQuery"
        Me.ReturnProductLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ReturnProductLineQueryTableAdapter
        '
        Me.ReturnProductLineQueryTableAdapter.ClearBeforeFill = True
        '
        'dgvReturnLineQuery
        '
        Me.dgvReturnLineQuery.AllowUserToAddRows = False
        Me.dgvReturnLineQuery.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvReturnLineQuery.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReturnLineQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReturnLineQuery.AutoGenerateColumns = False
        Me.dgvReturnLineQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReturnLineQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvReturnLineQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.CustomerIDColumn, Me.ReturnDateColumn, Me.ReturnNumberColumn, Me.ReturnLineNumberColumn, Me.SalesOrderNumberColumn, Me.PartNumberColumn, Me.DescriptionColumn, Me.QuantityColumn, Me.UnitPriceColumn, Me.ExtendedAmountColumn, Me.ExtendedCOSColumn, Me.LineCommentColumn, Me.SalespersonColumn, Me.LineStatusColumn, Me.CreditGLAccountColumn, Me.DebitGLAccountColumn, Me.SalesTaxColumn, Me.SOLineNumberColumn, Me.FOBColumn, Me.CustomerClassColumn})
        Me.dgvReturnLineQuery.DataSource = Me.ReturnProductLineQueryBindingSource
        Me.dgvReturnLineQuery.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvReturnLineQuery.Location = New System.Drawing.Point(347, 41)
        Me.dgvReturnLineQuery.Name = "dgvReturnLineQuery"
        Me.dgvReturnLineQuery.Size = New System.Drawing.Size(783, 638)
        Me.dgvReturnLineQuery.TabIndex = 20
        Me.dgvReturnLineQuery.TabStop = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        Me.DivisionIDColumn.Width = 80
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'ReturnDateColumn
        '
        Me.ReturnDateColumn.DataPropertyName = "ReturnDate"
        Me.ReturnDateColumn.HeaderText = "Return Date"
        Me.ReturnDateColumn.Name = "ReturnDateColumn"
        Me.ReturnDateColumn.ReadOnly = True
        Me.ReturnDateColumn.Width = 80
        '
        'ReturnNumberColumn
        '
        Me.ReturnNumberColumn.DataPropertyName = "ReturnNumber"
        Me.ReturnNumberColumn.HeaderText = "Return #"
        Me.ReturnNumberColumn.Name = "ReturnNumberColumn"
        Me.ReturnNumberColumn.ReadOnly = True
        Me.ReturnNumberColumn.Width = 65
        '
        'ReturnLineNumberColumn
        '
        Me.ReturnLineNumberColumn.DataPropertyName = "ReturnLineNumber"
        Me.ReturnLineNumberColumn.HeaderText = "Line #"
        Me.ReturnLineNumberColumn.Name = "ReturnLineNumberColumn"
        Me.ReturnLineNumberColumn.ReadOnly = True
        Me.ReturnLineNumberColumn.Visible = False
        Me.ReturnLineNumberColumn.Width = 65
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "SO #"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.ReadOnly = True
        Me.SalesOrderNumberColumn.Width = 65
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
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.ReadOnly = True
        Me.QuantityColumn.Width = 80
        '
        'UnitPriceColumn
        '
        Me.UnitPriceColumn.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle2.Format = "N5"
        DataGridViewCellStyle2.NullValue = "0"
        Me.UnitPriceColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.UnitPriceColumn.HeaderText = "Unit Price"
        Me.UnitPriceColumn.Name = "UnitPriceColumn"
        Me.UnitPriceColumn.ReadOnly = True
        Me.UnitPriceColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        '
        'ExtendedCOSColumn
        '
        Me.ExtendedCOSColumn.DataPropertyName = "ExtendedCOS"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.ExtendedCOSColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ExtendedCOSColumn.HeaderText = "Extended COS"
        Me.ExtendedCOSColumn.Name = "ExtendedCOSColumn"
        Me.ExtendedCOSColumn.ReadOnly = True
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'SalespersonColumn
        '
        Me.SalespersonColumn.DataPropertyName = "Salesperson"
        Me.SalespersonColumn.HeaderText = "Salesperson"
        Me.SalespersonColumn.Name = "SalespersonColumn"
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "Credit Account"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.ReadOnly = True
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit Account"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.ReadOnly = True
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Visible = False
        '
        'SOLineNumberColumn
        '
        Me.SOLineNumberColumn.DataPropertyName = "SOLineNumber"
        Me.SOLineNumberColumn.HeaderText = "SOLineNumber"
        Me.SOLineNumberColumn.Name = "SOLineNumberColumn"
        Me.SOLineNumberColumn.ReadOnly = True
        Me.SOLineNumberColumn.Visible = False
        '
        'FOBColumn
        '
        Me.FOBColumn.DataPropertyName = "FOB"
        Me.FOBColumn.HeaderText = "FOB"
        Me.FOBColumn.Name = "FOBColumn"
        '
        'CustomerClassColumn
        '
        Me.CustomerClassColumn.DataPropertyName = "CustomerClass"
        Me.CustomerClassColumn.HeaderText = "Customer Class"
        Me.CustomerClassColumn.Name = "CustomerClassColumn"
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtTotalSales)
        Me.GroupBox1.Controls.Add(Me.txtTotalCOS)
        Me.GroupBox1.Location = New System.Drawing.Point(347, 691)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(331, 119)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datagrid Totals"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(131, 20)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Total Product Returns"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(131, 20)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Total COS"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalSales
        '
        Me.txtTotalSales.BackColor = System.Drawing.Color.White
        Me.txtTotalSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalSales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSales.Location = New System.Drawing.Point(154, 71)
        Me.txtTotalSales.Name = "txtTotalSales"
        Me.txtTotalSales.ReadOnly = True
        Me.txtTotalSales.Size = New System.Drawing.Size(160, 20)
        Me.txtTotalSales.TabIndex = 1
        Me.txtTotalSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCOS
        '
        Me.txtTotalCOS.BackColor = System.Drawing.Color.White
        Me.txtTotalCOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalCOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCOS.Location = New System.Drawing.Point(154, 33)
        Me.txtTotalCOS.Name = "txtTotalCOS"
        Me.txtTotalCOS.ReadOnly = True
        Me.txtTotalCOS.Size = New System.Drawing.Size(160, 20)
        Me.txtTotalCOS.TabIndex = 0
        Me.txtTotalCOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ViewCustomerReturnListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvReturnLineQuery)
        Me.Controls.Add(Me.gpxCustomerReturnsFilter)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewCustomerReturnListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Customer Return Listing"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxCustomerReturnsFilter.ResumeLayout(False)
        Me.gpxCustomerReturnsFilter.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReturnProductLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReturnLineQuery, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents gpxCustomerReturnsFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboReturnStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ReturnProductHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReturnProductHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSalesperson As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents cboReturnNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ReturnProductLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReturnProductLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductLineQueryTableAdapter
    Friend WithEvents dgvReturnLineQuery As System.Windows.Forms.DataGridView
    Friend WithEvents cboDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalCOS As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSales As System.Windows.Forms.TextBox
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCOSColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalespersonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOBColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
