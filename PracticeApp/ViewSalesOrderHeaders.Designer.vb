<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSalesOrderHeaders
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AllSalesOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LastThreeYearsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBySalesmanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxQuotationFilter = New System.Windows.Forms.GroupBox
        Me.cboSalesOrderKey = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboShipID = New System.Windows.Forms.ComboBox
        Me.AdditionalShipToBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkIncludeSLCLines = New System.Windows.Forms.CheckBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboSalesperson = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.cboSOStatus = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.SOStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdOpenSalesOrder = New System.Windows.Forms.Button
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.dgvSalesOrders = New System.Windows.Forms.DataGridView
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.SOStatusTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SOStatusTableAdapter
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSalesTotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtOrderNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.AdditionalShipToTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalespersonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingMethod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightChargeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropShipPONumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalSalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalSalesTax2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalSalesTax3Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructions = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdditionalShipToColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuoteNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuotedFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeaderCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxQuotationFilter.SuspendLayout()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SOStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSalesOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllSalesOrdersToolStripMenuItem, Me.LastThreeYearsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'AllSalesOrdersToolStripMenuItem
        '
        Me.AllSalesOrdersToolStripMenuItem.CheckOnClick = True
        Me.AllSalesOrdersToolStripMenuItem.Name = "AllSalesOrdersToolStripMenuItem"
        Me.AllSalesOrdersToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.AllSalesOrdersToolStripMenuItem.Text = "All Sales Orders"
        '
        'LastThreeYearsToolStripMenuItem
        '
        Me.LastThreeYearsToolStripMenuItem.Checked = True
        Me.LastThreeYearsToolStripMenuItem.CheckOnClick = True
        Me.LastThreeYearsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LastThreeYearsToolStripMenuItem.Name = "LastThreeYearsToolStripMenuItem"
        Me.LastThreeYearsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.LastThreeYearsToolStripMenuItem.Text = "Last Three Years"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem, Me.PrintBySalesmanToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Sales Order Listing"
        '
        'PrintBySalesmanToolStripMenuItem
        '
        Me.PrintBySalesmanToolStripMenuItem.Name = "PrintBySalesmanToolStripMenuItem"
        Me.PrintBySalesmanToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.PrintBySalesmanToolStripMenuItem.Text = "Print By Salesman"
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
        'gpxQuotationFilter
        '
        Me.gpxQuotationFilter.Controls.Add(Me.cboSalesOrderKey)
        Me.gpxQuotationFilter.Controls.Add(Me.Label18)
        Me.gpxQuotationFilter.Controls.Add(Me.cboShipID)
        Me.gpxQuotationFilter.Controls.Add(Me.chkIncludeSLCLines)
        Me.gpxQuotationFilter.Controls.Add(Me.Label15)
        Me.gpxQuotationFilter.Controls.Add(Me.txtTextFilter)
        Me.gpxQuotationFilter.Controls.Add(Me.Label13)
        Me.gpxQuotationFilter.Controls.Add(Me.Label12)
        Me.gpxQuotationFilter.Controls.Add(Me.Label14)
        Me.gpxQuotationFilter.Controls.Add(Me.chkDateRange)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdClear)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdViewByFilter)
        Me.gpxQuotationFilter.Controls.Add(Me.txtCustomerPO)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpEndDate)
        Me.gpxQuotationFilter.Controls.Add(Me.cboSalesperson)
        Me.gpxQuotationFilter.Controls.Add(Me.Label2)
        Me.gpxQuotationFilter.Controls.Add(Me.Label8)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpBeginDate)
        Me.gpxQuotationFilter.Controls.Add(Me.Label9)
        Me.gpxQuotationFilter.Controls.Add(Me.Label3)
        Me.gpxQuotationFilter.Controls.Add(Me.cboCustomerName)
        Me.gpxQuotationFilter.Controls.Add(Me.cboCustomerID)
        Me.gpxQuotationFilter.Controls.Add(Me.cboSOStatus)
        Me.gpxQuotationFilter.Controls.Add(Me.Label7)
        Me.gpxQuotationFilter.Controls.Add(Me.cboDivisionID)
        Me.gpxQuotationFilter.Controls.Add(Me.Label5)
        Me.gpxQuotationFilter.Controls.Add(Me.Label4)
        Me.gpxQuotationFilter.Controls.Add(Me.Label17)
        Me.gpxQuotationFilter.Location = New System.Drawing.Point(29, 41)
        Me.gpxQuotationFilter.Name = "gpxQuotationFilter"
        Me.gpxQuotationFilter.Size = New System.Drawing.Size(300, 772)
        Me.gpxQuotationFilter.TabIndex = 0
        Me.gpxQuotationFilter.TabStop = False
        Me.gpxQuotationFilter.Text = "View By Filter Fields"
        '
        'cboSalesOrderKey
        '
        Me.cboSalesOrderKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderKey.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderKey.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderKey.FormattingEnabled = True
        Me.cboSalesOrderKey.Location = New System.Drawing.Point(100, 301)
        Me.cboSalesOrderKey.Name = "cboSalesOrderKey"
        Me.cboSalesOrderKey.Size = New System.Drawing.Size(186, 21)
        Me.cboSalesOrderKey.TabIndex = 5
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(16, 302)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 20)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "SO #"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipID
        '
        Me.cboShipID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipID.DataSource = Me.AdditionalShipToBindingSource
        Me.cboShipID.DisplayMember = "ShipToID"
        Me.cboShipID.FormattingEnabled = True
        Me.cboShipID.Location = New System.Drawing.Point(73, 247)
        Me.cboShipID.Name = "cboShipID"
        Me.cboShipID.Size = New System.Drawing.Size(213, 21)
        Me.cboShipID.TabIndex = 4
        '
        'AdditionalShipToBindingSource
        '
        Me.AdditionalShipToBindingSource.DataMember = "AdditionalShipTo"
        Me.AdditionalShipToBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'chkIncludeSLCLines
        '
        Me.chkIncludeSLCLines.AutoSize = True
        Me.chkIncludeSLCLines.ForeColor = System.Drawing.Color.Black
        Me.chkIncludeSLCLines.Location = New System.Drawing.Point(100, 543)
        Me.chkIncludeSLCLines.Name = "chkIncludeSLCLines"
        Me.chkIncludeSLCLines.Size = New System.Drawing.Size(140, 17)
        Me.chkIncludeSLCLines.TabIndex = 9
        Me.chkIncludeSLCLines.Text = "Include SO Status Lines"
        Me.chkIncludeSLCLines.UseVisualStyleBackColor = True
        Me.chkIncludeSLCLines.Visible = False
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(19, 447)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(269, 33)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Text filter will filter by Customer and Ship To Name."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.Location = New System.Drawing.Point(100, 492)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(188, 20)
        Me.txtTextFilter.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(19, 492)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Text Filter"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(17, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 49)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 585)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(100, 621)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 10
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(217, 727)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(140, 727)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 13
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.Location = New System.Drawing.Point(100, 395)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(188, 20)
        Me.txtCustomerPO.TabIndex = 7
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = ""
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(100, 689)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpEndDate.TabIndex = 12
        '
        'cboSalesperson
        '
        Me.cboSalesperson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesperson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesperson.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalesperson.DisplayMember = "SalesPersonID"
        Me.cboSalesperson.DropDownWidth = 250
        Me.cboSalesperson.FormattingEnabled = True
        Me.cboSalesperson.Location = New System.Drawing.Point(19, 124)
        Me.cboSalesperson.Name = "cboSalesperson"
        Me.cboSalesperson.Size = New System.Drawing.Size(269, 21)
        Me.cboSalesperson.TabIndex = 1
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 684)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "End Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Salesperson"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = ""
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(100, 649)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpBeginDate.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(19, 649)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Begin  Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 395)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Customer PO #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(19, 199)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(269, 21)
        Me.cboCustomerName.TabIndex = 3
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
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(73, 167)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(215, 21)
        Me.cboCustomerID.TabIndex = 2
        '
        'cboSOStatus
        '
        Me.cboSOStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSOStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSOStatus.FormattingEnabled = True
        Me.cboSOStatus.Items.AddRange(New Object() {"OPEN", "SHIPPED", "CLOSED", "DROPSHIP", "QUOTE"})
        Me.cboSOStatus.Location = New System.Drawing.Point(100, 348)
        Me.cboSOStatus.Name = "cboSOStatus"
        Me.cboSOStatus.Size = New System.Drawing.Size(188, 21)
        Me.cboSOStatus.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 349)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "SO Status"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(88, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(198, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Customer"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(16, 248)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 20)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Ship ID"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SOStatusBindingSource
        '
        Me.SOStatusBindingSource.DataMember = "SOStatus"
        Me.SOStatusBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdOpenSalesOrder
        '
        Me.cmdOpenSalesOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenSalesOrder.Location = New System.Drawing.Point(903, 773)
        Me.cmdOpenSalesOrder.Name = "cmdOpenSalesOrder"
        Me.cmdOpenSalesOrder.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenSalesOrder.TabIndex = 13
        Me.cmdOpenSalesOrder.Text = "Sales Order Form"
        Me.cmdOpenSalesOrder.UseVisualStyleBackColor = True
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(549, 437)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(186, 21)
        Me.cboSalesOrderNumber.TabIndex = 19
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'dgvSalesOrders
        '
        Me.dgvSalesOrders.AllowUserToAddRows = False
        Me.dgvSalesOrders.AllowUserToDeleteRows = False
        Me.dgvSalesOrders.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSalesOrders.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSalesOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSalesOrders.AutoGenerateColumns = False
        Me.dgvSalesOrders.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSalesOrders.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSalesOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SalesOrderKeyColumn, Me.SalesOrderDateColumn, Me.CustomerIDColumn, Me.CustomerPOColumn, Me.SalespersonColumn, Me.ShipViaColumn, Me.ShippingMethod, Me.ShippingDateColumn, Me.FreightChargeColumn, Me.ProductTotalColumn, Me.SOTotalColumn, Me.DropShipPONumber, Me.TotalSalesTaxColumn, Me.TotalSalesTax2Column, Me.TotalSalesTax3Column, Me.SOStatusColumn, Me.SpecialInstructions, Me.PRONumberColumn, Me.AdditionalShipToColumn, Me.QuoteNumberColumn, Me.QuotedFreightColumn, Me.ShippingWeightColumn, Me.HeaderCommentColumn, Me.DivisionKeyColumn})
        Me.dgvSalesOrders.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.dgvSalesOrders.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSalesOrders.Location = New System.Drawing.Point(344, 41)
        Me.dgvSalesOrders.Name = "dgvSalesOrders"
        Me.dgvSalesOrders.Size = New System.Drawing.Size(786, 618)
        Me.dgvSalesOrders.TabIndex = 25
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(980, 773)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1057, 773)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'SOStatusTableAdapter
        '
        Me.SOStatusTableAdapter.ClearBeforeFill = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.txtProductTotal)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtFreightTotal)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtSalesTotal)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txtOrderNumber)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(344, 679)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(361, 134)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Sales Totals From Grid"
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BackColor = System.Drawing.Color.White
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.Location = New System.Drawing.Point(158, 19)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.ReadOnly = True
        Me.txtProductTotal.Size = New System.Drawing.Size(189, 20)
        Me.txtProductTotal.TabIndex = 11
        Me.txtProductTotal.TabStop = False
        Me.txtProductTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Product Total"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BackColor = System.Drawing.Color.White
        Me.txtFreightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightTotal.Location = New System.Drawing.Point(158, 46)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.ReadOnly = True
        Me.txtFreightTotal.Size = New System.Drawing.Size(189, 20)
        Me.txtFreightTotal.TabIndex = 12
        Me.txtFreightTotal.TabStop = False
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(6, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Freight Billed"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTotal
        '
        Me.txtSalesTotal.BackColor = System.Drawing.Color.White
        Me.txtSalesTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTotal.Location = New System.Drawing.Point(159, 73)
        Me.txtSalesTotal.Name = "txtSalesTotal"
        Me.txtSalesTotal.ReadOnly = True
        Me.txtSalesTotal.Size = New System.Drawing.Size(189, 20)
        Me.txtSalesTotal.TabIndex = 13
        Me.txtSalesTotal.TabStop = False
        Me.txtSalesTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Total Sales (inc. tax)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOrderNumber
        '
        Me.txtOrderNumber.BackColor = System.Drawing.Color.White
        Me.txtOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderNumber.Location = New System.Drawing.Point(159, 100)
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.ReadOnly = True
        Me.txtOrderNumber.Size = New System.Drawing.Size(189, 20)
        Me.txtOrderNumber.TabIndex = 14
        Me.txtOrderNumber.TabStop = False
        Me.txtOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "# of Orders"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(863, 684)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(249, 33)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Changes made in the grid are automatically saved."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AdditionalShipToTableAdapter
        '
        Me.AdditionalShipToTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        Me.SalesOrderKeyColumn.ReadOnly = True
        Me.SalesOrderKeyColumn.Width = 90
        '
        'SalesOrderDateColumn
        '
        Me.SalesOrderDateColumn.DataPropertyName = "SalesOrderDate"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.SalesOrderDateColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.SalesOrderDateColumn.HeaderText = "SO Date"
        Me.SalesOrderDateColumn.Name = "SalesOrderDateColumn"
        Me.SalesOrderDateColumn.Width = 68
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        Me.CustomerIDColumn.Width = 83
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.Width = 87
        '
        'SalespersonColumn
        '
        Me.SalespersonColumn.DataPropertyName = "Salesperson"
        Me.SalespersonColumn.HeaderText = "Salesperson"
        Me.SalespersonColumn.Name = "SalespersonColumn"
        Me.SalespersonColumn.Width = 90
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        Me.ShipViaColumn.Width = 66
        '
        'ShippingMethod
        '
        Me.ShippingMethod.DataPropertyName = "ShippingMethod"
        Me.ShippingMethod.HeaderText = "Ship Method"
        Me.ShippingMethod.Name = "ShippingMethod"
        '
        'ShippingDateColumn
        '
        Me.ShippingDateColumn.DataPropertyName = "ShippingDate"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.ShippingDateColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ShippingDateColumn.HeaderText = "Ship Date"
        Me.ShippingDateColumn.Name = "ShippingDateColumn"
        Me.ShippingDateColumn.Width = 91
        '
        'FreightChargeColumn
        '
        Me.FreightChargeColumn.DataPropertyName = "FreightCharge"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.FreightChargeColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.FreightChargeColumn.HeaderText = "Freight Charge"
        Me.FreightChargeColumn.Name = "FreightChargeColumn"
        Me.FreightChargeColumn.ReadOnly = True
        Me.FreightChargeColumn.Width = 93
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.ReadOnly = True
        Me.ProductTotalColumn.Width = 88
        '
        'SOTotalColumn
        '
        Me.SOTotalColumn.DataPropertyName = "SOTotal"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.SOTotalColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.SOTotalColumn.HeaderText = "SO Total"
        Me.SOTotalColumn.Name = "SOTotalColumn"
        Me.SOTotalColumn.ReadOnly = True
        Me.SOTotalColumn.Width = 69
        '
        'DropShipPONumber
        '
        Me.DropShipPONumber.DataPropertyName = "DropShipPONumber"
        Me.DropShipPONumber.HeaderText = "DS PO #"
        Me.DropShipPONumber.Name = "DropShipPONumber"
        '
        'TotalSalesTaxColumn
        '
        Me.TotalSalesTaxColumn.DataPropertyName = "TotalSalesTax"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.TotalSalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.TotalSalesTaxColumn.HeaderText = "Sales Tax"
        Me.TotalSalesTaxColumn.Name = "TotalSalesTaxColumn"
        Me.TotalSalesTaxColumn.ReadOnly = True
        Me.TotalSalesTaxColumn.Visible = False
        Me.TotalSalesTaxColumn.Width = 79
        '
        'TotalSalesTax2Column
        '
        Me.TotalSalesTax2Column.DataPropertyName = "TotalSalesTax2"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.TotalSalesTax2Column.DefaultCellStyle = DataGridViewCellStyle8
        Me.TotalSalesTax2Column.HeaderText = "PST"
        Me.TotalSalesTax2Column.Name = "TotalSalesTax2Column"
        Me.TotalSalesTax2Column.ReadOnly = True
        Me.TotalSalesTax2Column.Visible = False
        Me.TotalSalesTax2Column.Width = 53
        '
        'TotalSalesTax3Column
        '
        Me.TotalSalesTax3Column.DataPropertyName = "TotalSalesTax3"
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0"
        Me.TotalSalesTax3Column.DefaultCellStyle = DataGridViewCellStyle9
        Me.TotalSalesTax3Column.HeaderText = "HST"
        Me.TotalSalesTax3Column.Name = "TotalSalesTax3Column"
        Me.TotalSalesTax3Column.ReadOnly = True
        Me.TotalSalesTax3Column.Visible = False
        Me.TotalSalesTax3Column.Width = 54
        '
        'SOStatusColumn
        '
        Me.SOStatusColumn.DataPropertyName = "SOStatus"
        Me.SOStatusColumn.HeaderText = "SO Status"
        Me.SOStatusColumn.Name = "SOStatusColumn"
        Me.SOStatusColumn.ReadOnly = True
        Me.SOStatusColumn.Width = 74
        '
        'SpecialInstructions
        '
        Me.SpecialInstructions.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructions.HeaderText = "Special Instructions"
        Me.SpecialInstructions.Name = "SpecialInstructions"
        '
        'PRONumberColumn
        '
        Me.PRONumberColumn.DataPropertyName = "PRONumber"
        Me.PRONumberColumn.HeaderText = "PRO #"
        Me.PRONumberColumn.Name = "PRONumberColumn"
        Me.PRONumberColumn.Width = 88
        '
        'AdditionalShipToColumn
        '
        Me.AdditionalShipToColumn.DataPropertyName = "AdditionalShipTo"
        Me.AdditionalShipToColumn.HeaderText = "Add Ship To"
        Me.AdditionalShipToColumn.Name = "AdditionalShipToColumn"
        Me.AdditionalShipToColumn.ReadOnly = True
        Me.AdditionalShipToColumn.Width = 97
        '
        'QuoteNumberColumn
        '
        Me.QuoteNumberColumn.DataPropertyName = "QuoteNumber"
        Me.QuoteNumberColumn.HeaderText = "Quote Number"
        Me.QuoteNumberColumn.Name = "QuoteNumberColumn"
        Me.QuoteNumberColumn.Width = 93
        '
        'QuotedFreightColumn
        '
        Me.QuotedFreightColumn.DataPropertyName = "QuotedFreight"
        Me.QuotedFreightColumn.HeaderText = "Quoted Freight"
        Me.QuotedFreightColumn.Name = "QuotedFreightColumn"
        Me.QuotedFreightColumn.Width = 94
        '
        'ShippingWeightColumn
        '
        Me.ShippingWeightColumn.DataPropertyName = "ShippingWeight"
        Me.ShippingWeightColumn.HeaderText = "Shipping Weight"
        Me.ShippingWeightColumn.Name = "ShippingWeightColumn"
        Me.ShippingWeightColumn.Width = 101
        '
        'HeaderCommentColumn
        '
        Me.HeaderCommentColumn.DataPropertyName = "HeaderComment"
        Me.HeaderCommentColumn.HeaderText = "Header Comment"
        Me.HeaderCommentColumn.Name = "HeaderCommentColumn"
        Me.HeaderCommentColumn.Width = 105
        '
        'DivisionKeyColumn
        '
        Me.DivisionKeyColumn.DataPropertyName = "DivisionKey"
        Me.DivisionKeyColumn.HeaderText = "Division Key"
        Me.DivisionKeyColumn.Name = "DivisionKeyColumn"
        Me.DivisionKeyColumn.ReadOnly = True
        Me.DivisionKeyColumn.Visible = False
        Me.DivisionKeyColumn.Width = 83
        '
        'ViewSalesOrderHeaders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdOpenSalesOrder)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvSalesOrders)
        Me.Controls.Add(Me.gpxQuotationFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cboSalesOrderNumber)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewSalesOrderHeaders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Sales Orders"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxQuotationFilter.ResumeLayout(False)
        Me.gpxQuotationFilter.PerformLayout()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SOStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSalesOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxQuotationFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenSalesOrder As System.Windows.Forms.Button
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents dgvSalesOrders As System.Windows.Forms.DataGridView
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSOStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboSalesperson As System.Windows.Forms.ComboBox
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents SOStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SOStatusTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SOStatusTableAdapter
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents PrintBySalesmanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFreightTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSalesTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkIncludeSLCLines As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboShipID As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents AdditionalShipToBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdditionalShipToTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboSalesOrderKey As System.Windows.Forms.ComboBox
    Friend WithEvents AllSalesOrdersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LastThreeYearsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalespersonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightChargeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropShipPONumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSalesTax2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalSalesTax3Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructions As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdditionalShipToColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuoteNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuotedFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeaderCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
