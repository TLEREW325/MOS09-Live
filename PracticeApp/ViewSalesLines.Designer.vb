<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSalesLines
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
        Me.gpxQuotationFilter = New System.Windows.Forms.GroupBox
        Me.chkViewClosedWithOpen = New System.Windows.Forms.CheckBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.cboSOStatus = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboSalesPerson = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintCustCopySalesReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvSalesOrderLines = New System.Windows.Forms.DataGridView
        Me.SalesOrderQuantityStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SalesOrderQuantityStatusTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderQuantityStatusTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdOpenSalesOrder = New System.Windows.Forms.Button
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtMargin = New System.Windows.Forms.TextBox
        Me.txtCOGS = New System.Windows.Forms.TextBox
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.lblMargin = New System.Windows.Forms.Label
        Me.lblCOGS = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtQtyOpen = New System.Windows.Forms.TextBox
        Me.txtQtyShipped = New System.Windows.Forms.TextBox
        Me.txtQtyOrdered = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewAllLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLast3YearsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingwQuantityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingwPricingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.DivisionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOrderedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeadTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropShipPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxOrderedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenLineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnPickListColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gpxQuotationFilter.SuspendLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSalesOrderLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpxQuotationFilter
        '
        Me.gpxQuotationFilter.Controls.Add(Me.chkViewClosedWithOpen)
        Me.gpxQuotationFilter.Controls.Add(Me.Label20)
        Me.gpxQuotationFilter.Controls.Add(Me.Label16)
        Me.gpxQuotationFilter.Controls.Add(Me.txtTextFilter)
        Me.gpxQuotationFilter.Controls.Add(Me.cboSOStatus)
        Me.gpxQuotationFilter.Controls.Add(Me.Label15)
        Me.gpxQuotationFilter.Controls.Add(Me.cboSalesPerson)
        Me.gpxQuotationFilter.Controls.Add(Me.Label13)
        Me.gpxQuotationFilter.Controls.Add(Me.Label14)
        Me.gpxQuotationFilter.Controls.Add(Me.chkDateRange)
        Me.gpxQuotationFilter.Controls.Add(Me.Label12)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpEndDate)
        Me.gpxQuotationFilter.Controls.Add(Me.cboCustomerName)
        Me.gpxQuotationFilter.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.cboCustomerID)
        Me.gpxQuotationFilter.Controls.Add(Me.Label9)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdClear)
        Me.gpxQuotationFilter.Controls.Add(Me.Label2)
        Me.gpxQuotationFilter.Controls.Add(Me.cboDivisionID)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpBeginDate)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdViewByFilter)
        Me.gpxQuotationFilter.Controls.Add(Me.Label8)
        Me.gpxQuotationFilter.Controls.Add(Me.Label5)
        Me.gpxQuotationFilter.Controls.Add(Me.Label6)
        Me.gpxQuotationFilter.Controls.Add(Me.Label4)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPartNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.txtCustomerPO)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPartDescription)
        Me.gpxQuotationFilter.Controls.Add(Me.Label3)
        Me.gpxQuotationFilter.Location = New System.Drawing.Point(29, 41)
        Me.gpxQuotationFilter.Name = "gpxQuotationFilter"
        Me.gpxQuotationFilter.Size = New System.Drawing.Size(300, 770)
        Me.gpxQuotationFilter.TabIndex = 0
        Me.gpxQuotationFilter.TabStop = False
        Me.gpxQuotationFilter.Text = "View By Filter Fields"
        '
        'chkViewClosedWithOpen
        '
        Me.chkViewClosedWithOpen.AutoSize = True
        Me.chkViewClosedWithOpen.ForeColor = System.Drawing.Color.Black
        Me.chkViewClosedWithOpen.Location = New System.Drawing.Point(23, 559)
        Me.chkViewClosedWithOpen.Name = "chkViewClosedWithOpen"
        Me.chkViewClosedWithOpen.Size = New System.Drawing.Size(207, 17)
        Me.chkViewClosedWithOpen.TabIndex = 10
        Me.chkViewClosedWithOpen.Text = "View CLOSED lines w/open quantities"
        Me.chkViewClosedWithOpen.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(22, 466)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(267, 31)
        Me.Label20.TabIndex = 53
        Me.Label20.Text = "Text filter on Part # and/or description."
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(22, 500)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 20)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Text Filter"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.Location = New System.Drawing.Point(107, 500)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(180, 20)
        Me.txtTextFilter.TabIndex = 9
        '
        'cboSOStatus
        '
        Me.cboSOStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSOStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSOStatus.FormattingEnabled = True
        Me.cboSOStatus.Items.AddRange(New Object() {"OPEN", "CLOSED", "DROPSHIP"})
        Me.cboSOStatus.Location = New System.Drawing.Point(112, 313)
        Me.cboSOStatus.Name = "cboSOStatus"
        Me.cboSOStatus.Size = New System.Drawing.Size(175, 21)
        Me.cboSOStatus.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(23, 313)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 20)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Line Status"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesPerson
        '
        Me.cboSalesPerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesPerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesPerson.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalesPerson.DisplayMember = "SalesPersonID"
        Me.cboSalesPerson.FormattingEnabled = True
        Me.cboSalesPerson.Location = New System.Drawing.Point(22, 414)
        Me.cboSalesPerson.Name = "cboSalesPerson"
        Me.cboSalesPerson.Size = New System.Drawing.Size(263, 21)
        Me.cboSalesPerson.TabIndex = 8
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(22, 391)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 20)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Salesperson"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(22, 602)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(110, 638)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 11
        Me.chkDateRange.TabStop = False
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(23, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(267, 40)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(110, 698)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpEndDate.TabIndex = 12
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(22, 140)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(265, 21)
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
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(112, 274)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(175, 21)
        Me.cboSalesOrderNumber.TabIndex = 5
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(81, 109)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(206, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(22, 698)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 20)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "End Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(216, 730)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(23, 273)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Sales Order #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(86, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(204, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(110, 668)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpBeginDate.TabIndex = 11
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(136, 730)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 13
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(22, 668)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 20)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Begin Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(23, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Customer"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(23, 352)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Customer PO #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(23, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.DropDownWidth = 250
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(66, 192)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(221, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.Location = New System.Drawing.Point(112, 352)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(175, 20)
        Me.txtCustomerPO.TabIndex = 7
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 300
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(24, 223)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(263, 21)
        Me.cboPartDescription.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(23, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Part #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem, Me.PrintCustCopySalesReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
        '
        'PrintCustCopySalesReportToolStripMenuItem
        '
        Me.PrintCustCopySalesReportToolStripMenuItem.Name = "PrintCustCopySalesReportToolStripMenuItem"
        Me.PrintCustCopySalesReportToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.PrintCustCopySalesReportToolStripMenuItem.Text = "Print Cust Copy Sales Report"
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
        'dgvSalesOrderLines
        '
        Me.dgvSalesOrderLines.AllowUserToAddRows = False
        Me.dgvSalesOrderLines.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSalesOrderLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSalesOrderLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSalesOrderLines.AutoGenerateColumns = False
        Me.dgvSalesOrderLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSalesOrderLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSalesOrderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesOrderLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionKeyColumn, Me.SalesOrderKeyColumn, Me.SalesOrderDateColumn, Me.CustomerIDColumn, Me.ItemIDColumn, Me.DescriptionColumn, Me.QuantityOrderedColumn, Me.QuantityShippedColumn, Me.QuantityOpenColumn, Me.LeadTimeColumn, Me.PriceColumn, Me.CustomerPOColumn, Me.LineCommentColumn, Me.LineWeightColumn, Me.LineBoxesColumn, Me.LineStatusColumn, Me.DropShipPONumberColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.SalesTaxOrderedColumn, Me.SalesTaxShippedColumn, Me.SalesTaxOpenColumn, Me.SalesOrderLineKeyColumn, Me.SOExtendedAmountColumn, Me.ShippingExtendedAmountColumn, Me.OpenExtendedAmountColumn, Me.LineWeightShippedColumn, Me.OpenLineWeightColumn, Me.SOStatusColumn, Me.QuantityOnPickListColumn})
        Me.dgvSalesOrderLines.DataSource = Me.SalesOrderQuantityStatusBindingSource
        Me.dgvSalesOrderLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSalesOrderLines.Location = New System.Drawing.Point(348, 46)
        Me.dgvSalesOrderLines.Name = "dgvSalesOrderLines"
        Me.dgvSalesOrderLines.Size = New System.Drawing.Size(784, 630)
        Me.dgvSalesOrderLines.TabIndex = 19
        Me.dgvSalesOrderLines.TabStop = False
        '
        'SalesOrderQuantityStatusBindingSource
        '
        Me.SalesOrderQuantityStatusBindingSource.DataMember = "SalesOrderQuantityStatus"
        Me.SalesOrderQuantityStatusBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SalesOrderQuantityStatusTableAdapter
        '
        Me.SalesOrderQuantityStatusTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(983, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
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
        'cmdOpenSalesOrder
        '
        Me.cmdOpenSalesOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenSalesOrder.Location = New System.Drawing.Point(906, 771)
        Me.cmdOpenSalesOrder.Name = "cmdOpenSalesOrder"
        Me.cmdOpenSalesOrder.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenSalesOrder.TabIndex = 16
        Me.cmdOpenSalesOrder.Text = "Sales Order Form"
        Me.cmdOpenSalesOrder.UseVisualStyleBackColor = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.txtMargin)
        Me.GroupBox4.Controls.Add(Me.txtCOGS)
        Me.GroupBox4.Controls.Add(Me.txtProductTotal)
        Me.GroupBox4.Controls.Add(Me.lblMargin)
        Me.GroupBox4.Controls.Add(Me.lblCOGS)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Location = New System.Drawing.Point(348, 684)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(220, 127)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Totals from Datagrid ($)"
        '
        'txtMargin
        '
        Me.txtMargin.BackColor = System.Drawing.Color.White
        Me.txtMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMargin.Location = New System.Drawing.Point(84, 91)
        Me.txtMargin.Name = "txtMargin"
        Me.txtMargin.ReadOnly = True
        Me.txtMargin.Size = New System.Drawing.Size(125, 20)
        Me.txtMargin.TabIndex = 15
        Me.txtMargin.TabStop = False
        Me.txtMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCOGS
        '
        Me.txtCOGS.BackColor = System.Drawing.Color.White
        Me.txtCOGS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCOGS.Location = New System.Drawing.Point(84, 59)
        Me.txtCOGS.Name = "txtCOGS"
        Me.txtCOGS.ReadOnly = True
        Me.txtCOGS.Size = New System.Drawing.Size(125, 20)
        Me.txtCOGS.TabIndex = 14
        Me.txtCOGS.TabStop = False
        Me.txtCOGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BackColor = System.Drawing.Color.White
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.Location = New System.Drawing.Point(84, 27)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.ReadOnly = True
        Me.txtProductTotal.Size = New System.Drawing.Size(125, 20)
        Me.txtProductTotal.TabIndex = 13
        Me.txtProductTotal.TabStop = False
        Me.txtProductTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMargin
        '
        Me.lblMargin.Location = New System.Drawing.Point(6, 91)
        Me.lblMargin.Name = "lblMargin"
        Me.lblMargin.Size = New System.Drawing.Size(80, 20)
        Me.lblMargin.TabIndex = 26
        Me.lblMargin.Text = "Est. Margin"
        Me.lblMargin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCOGS
        '
        Me.lblCOGS.Location = New System.Drawing.Point(6, 58)
        Me.lblCOGS.Name = "lblCOGS"
        Me.lblCOGS.Size = New System.Drawing.Size(80, 20)
        Me.lblCOGS.TabIndex = 24
        Me.lblCOGS.Text = "Est. COS"
        Me.lblCOGS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(6, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Product Total"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(903, 693)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 43)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Changes made in the datagrid are automatically saved."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtQtyOpen)
        Me.GroupBox1.Controls.Add(Me.txtQtyShipped)
        Me.GroupBox1.Controls.Add(Me.txtQtyOrdered)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(584, 684)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(220, 127)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totals from Datagrid (Qty)"
        '
        'txtQtyOpen
        '
        Me.txtQtyOpen.BackColor = System.Drawing.Color.White
        Me.txtQtyOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtyOpen.Location = New System.Drawing.Point(84, 91)
        Me.txtQtyOpen.Name = "txtQtyOpen"
        Me.txtQtyOpen.ReadOnly = True
        Me.txtQtyOpen.Size = New System.Drawing.Size(125, 20)
        Me.txtQtyOpen.TabIndex = 15
        Me.txtQtyOpen.TabStop = False
        Me.txtQtyOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQtyShipped
        '
        Me.txtQtyShipped.BackColor = System.Drawing.Color.White
        Me.txtQtyShipped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtyShipped.Location = New System.Drawing.Point(84, 60)
        Me.txtQtyShipped.Name = "txtQtyShipped"
        Me.txtQtyShipped.ReadOnly = True
        Me.txtQtyShipped.Size = New System.Drawing.Size(125, 20)
        Me.txtQtyShipped.TabIndex = 14
        Me.txtQtyShipped.TabStop = False
        Me.txtQtyShipped.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQtyOrdered
        '
        Me.txtQtyOrdered.BackColor = System.Drawing.Color.White
        Me.txtQtyOrdered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtyOrdered.Location = New System.Drawing.Point(84, 29)
        Me.txtQtyOrdered.Name = "txtQtyOrdered"
        Me.txtQtyOrdered.ReadOnly = True
        Me.txtQtyOrdered.Size = New System.Drawing.Size(125, 20)
        Me.txtQtyOrdered.TabIndex = 13
        Me.txtQtyOrdered.TabStop = False
        Me.txtQtyOrdered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(14, 92)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 20)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Qty Open"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(14, 59)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 20)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "Qty Shipped"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(14, 27)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 20)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Qty Ordered"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1, Me.EditToolStripMenuItem1, Me.ReportsToolStripMenuItem1, Me.ExitToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem1.Text = "File"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewAllLinesToolStripMenuItem, Me.ViewLast3YearsToolStripMenuItem})
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'ViewAllLinesToolStripMenuItem
        '
        Me.ViewAllLinesToolStripMenuItem.CheckOnClick = True
        Me.ViewAllLinesToolStripMenuItem.Name = "ViewAllLinesToolStripMenuItem"
        Me.ViewAllLinesToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ViewAllLinesToolStripMenuItem.Text = "View All Lines"
        '
        'ViewLast3YearsToolStripMenuItem
        '
        Me.ViewLast3YearsToolStripMenuItem.Checked = True
        Me.ViewLast3YearsToolStripMenuItem.CheckOnClick = True
        Me.ViewLast3YearsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ViewLast3YearsToolStripMenuItem.Name = "ViewLast3YearsToolStripMenuItem"
        Me.ViewLast3YearsToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ViewLast3YearsToolStripMenuItem.Text = "View Last 3 Years"
        '
        'ReportsToolStripMenuItem1
        '
        Me.ReportsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingwQuantityToolStripMenuItem, Me.PrintListingwPricingToolStripMenuItem})
        Me.ReportsToolStripMenuItem1.Name = "ReportsToolStripMenuItem1"
        Me.ReportsToolStripMenuItem1.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem1.Text = "Reports"
        '
        'PrintListingwQuantityToolStripMenuItem
        '
        Me.PrintListingwQuantityToolStripMenuItem.Name = "PrintListingwQuantityToolStripMenuItem"
        Me.PrintListingwQuantityToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.PrintListingwQuantityToolStripMenuItem.Text = "Print Listing (w/Quantity)"
        '
        'PrintListingwPricingToolStripMenuItem
        '
        Me.PrintListingwPricingToolStripMenuItem.Name = "PrintListingwPricingToolStripMenuItem"
        Me.PrintListingwPricingToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.PrintListingwPricingToolStripMenuItem.Text = "Print Listing (w/Pricing)"
        '
        'ExitToolStripMenuItem2
        '
        Me.ExitToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem3})
        Me.ExitToolStripMenuItem2.Name = "ExitToolStripMenuItem2"
        Me.ExitToolStripMenuItem2.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem2.Text = "Exit"
        '
        'ExitToolStripMenuItem3
        '
        Me.ExitToolStripMenuItem3.Name = "ExitToolStripMenuItem3"
        Me.ExitToolStripMenuItem3.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem3.Text = "Exit"
        '
        'DivisionKeyColumn
        '
        Me.DivisionKeyColumn.DataPropertyName = "DivisionKey"
        Me.DivisionKeyColumn.HeaderText = "Division"
        Me.DivisionKeyColumn.Name = "DivisionKeyColumn"
        Me.DivisionKeyColumn.ReadOnly = True
        Me.DivisionKeyColumn.Visible = False
        Me.DivisionKeyColumn.Width = 69
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
        Me.SalesOrderDateColumn.ReadOnly = True
        Me.SalesOrderDateColumn.Width = 80
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "Part #"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        Me.ItemIDColumn.Width = 120
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.ReadOnly = True
        Me.DescriptionColumn.Width = 150
        '
        'QuantityOrderedColumn
        '
        Me.QuantityOrderedColumn.DataPropertyName = "QuantityOrdered"
        DataGridViewCellStyle3.NullValue = "0"
        Me.QuantityOrderedColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.QuantityOrderedColumn.HeaderText = "Order Qty"
        Me.QuantityOrderedColumn.Name = "QuantityOrderedColumn"
        Me.QuantityOrderedColumn.ReadOnly = True
        Me.QuantityOrderedColumn.Width = 90
        '
        'QuantityShippedColumn
        '
        Me.QuantityShippedColumn.DataPropertyName = "QuantityShipped"
        DataGridViewCellStyle4.NullValue = "0"
        Me.QuantityShippedColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.QuantityShippedColumn.HeaderText = "Ship Qty"
        Me.QuantityShippedColumn.Name = "QuantityShippedColumn"
        Me.QuantityShippedColumn.ReadOnly = True
        Me.QuantityShippedColumn.Width = 90
        '
        'QuantityOpenColumn
        '
        Me.QuantityOpenColumn.DataPropertyName = "QuantityOpen"
        DataGridViewCellStyle5.NullValue = "0"
        Me.QuantityOpenColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.QuantityOpenColumn.HeaderText = "Open Qty"
        Me.QuantityOpenColumn.Name = "QuantityOpenColumn"
        Me.QuantityOpenColumn.ReadOnly = True
        Me.QuantityOpenColumn.Width = 90
        '
        'LeadTimeColumn
        '
        Me.LeadTimeColumn.DataPropertyName = "LeadTime"
        Me.LeadTimeColumn.HeaderText = "Lead Time"
        Me.LeadTimeColumn.Name = "LeadTimeColumn"
        Me.LeadTimeColumn.Width = 90
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        DataGridViewCellStyle6.Format = "N4"
        DataGridViewCellStyle6.NullValue = "0"
        Me.PriceColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.ReadOnly = True
        Me.PriceColumn.Width = 90
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Customer PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.ReadOnly = True
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.LineWeightColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.LineWeightColumn.HeaderText = "Line Weight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.Width = 89
        '
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        Me.LineBoxesColumn.HeaderText = "Line Boxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        Me.LineBoxesColumn.Width = 84
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        Me.LineStatusColumn.Width = 85
        '
        'DropShipPONumberColumn
        '
        Me.DropShipPONumberColumn.DataPropertyName = "DropShipPONumber"
        Me.DropShipPONumberColumn.HeaderText = "PO #"
        Me.DropShipPONumberColumn.Name = "DropShipPONumberColumn"
        Me.DropShipPONumberColumn.Width = 57
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit GL Account"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.ReadOnly = True
        Me.DebitGLAccountColumn.Width = 107
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "Credit GL Account"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.ReadOnly = True
        Me.CreditGLAccountColumn.Width = 109
        '
        'SalesTaxOrderedColumn
        '
        Me.SalesTaxOrderedColumn.DataPropertyName = "SalesTaxOrdered"
        Me.SalesTaxOrderedColumn.HeaderText = "SalesTaxOrdered"
        Me.SalesTaxOrderedColumn.Name = "SalesTaxOrderedColumn"
        Me.SalesTaxOrderedColumn.ReadOnly = True
        Me.SalesTaxOrderedColumn.Visible = False
        Me.SalesTaxOrderedColumn.Width = 114
        '
        'SalesTaxShippedColumn
        '
        Me.SalesTaxShippedColumn.DataPropertyName = "SalesTaxShipped"
        Me.SalesTaxShippedColumn.HeaderText = "SalesTaxShipped"
        Me.SalesTaxShippedColumn.Name = "SalesTaxShippedColumn"
        Me.SalesTaxShippedColumn.ReadOnly = True
        Me.SalesTaxShippedColumn.Visible = False
        Me.SalesTaxShippedColumn.Width = 115
        '
        'SalesTaxOpenColumn
        '
        Me.SalesTaxOpenColumn.DataPropertyName = "SalesTaxOpen"
        Me.SalesTaxOpenColumn.HeaderText = "SalesTaxOpen"
        Me.SalesTaxOpenColumn.Name = "SalesTaxOpenColumn"
        Me.SalesTaxOpenColumn.ReadOnly = True
        Me.SalesTaxOpenColumn.Visible = False
        Me.SalesTaxOpenColumn.Width = 102
        '
        'SalesOrderLineKeyColumn
        '
        Me.SalesOrderLineKeyColumn.DataPropertyName = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumn.HeaderText = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumn.Name = "SalesOrderLineKeyColumn"
        Me.SalesOrderLineKeyColumn.ReadOnly = True
        Me.SalesOrderLineKeyColumn.Visible = False
        Me.SalesOrderLineKeyColumn.Width = 122
        '
        'SOExtendedAmountColumn
        '
        Me.SOExtendedAmountColumn.DataPropertyName = "SOExtendedAmount"
        Me.SOExtendedAmountColumn.HeaderText = "SOExtendedAmount"
        Me.SOExtendedAmountColumn.Name = "SOExtendedAmountColumn"
        Me.SOExtendedAmountColumn.ReadOnly = True
        Me.SOExtendedAmountColumn.Visible = False
        Me.SOExtendedAmountColumn.Width = 128
        '
        'ShippingExtendedAmountColumn
        '
        Me.ShippingExtendedAmountColumn.DataPropertyName = "ShippingExtendedAmount"
        Me.ShippingExtendedAmountColumn.HeaderText = "ShippingExtendedAmount"
        Me.ShippingExtendedAmountColumn.Name = "ShippingExtendedAmountColumn"
        Me.ShippingExtendedAmountColumn.ReadOnly = True
        Me.ShippingExtendedAmountColumn.Visible = False
        Me.ShippingExtendedAmountColumn.Width = 154
        '
        'OpenExtendedAmountColumn
        '
        Me.OpenExtendedAmountColumn.DataPropertyName = "OpenExtendedAmount"
        Me.OpenExtendedAmountColumn.HeaderText = "OpenExtendedAmount"
        Me.OpenExtendedAmountColumn.Name = "OpenExtendedAmountColumn"
        Me.OpenExtendedAmountColumn.ReadOnly = True
        Me.OpenExtendedAmountColumn.Visible = False
        Me.OpenExtendedAmountColumn.Width = 139
        '
        'LineWeightShippedColumn
        '
        Me.LineWeightShippedColumn.DataPropertyName = "LineWeightShipped"
        Me.LineWeightShippedColumn.HeaderText = "Weight Shipped"
        Me.LineWeightShippedColumn.Name = "LineWeightShippedColumn"
        Me.LineWeightShippedColumn.ReadOnly = True
        Me.LineWeightShippedColumn.Visible = False
        Me.LineWeightShippedColumn.Width = 99
        '
        'OpenLineWeightColumn
        '
        Me.OpenLineWeightColumn.DataPropertyName = "OpenLineWeight"
        Me.OpenLineWeightColumn.HeaderText = "Open Weight"
        Me.OpenLineWeightColumn.Name = "OpenLineWeightColumn"
        Me.OpenLineWeightColumn.ReadOnly = True
        Me.OpenLineWeightColumn.Visible = False
        Me.OpenLineWeightColumn.Width = 88
        '
        'SOStatusColumn
        '
        Me.SOStatusColumn.DataPropertyName = "SOStatus"
        Me.SOStatusColumn.HeaderText = "SOStatus"
        Me.SOStatusColumn.Name = "SOStatusColumn"
        Me.SOStatusColumn.ReadOnly = True
        Me.SOStatusColumn.Visible = False
        Me.SOStatusColumn.Width = 77
        '
        'QuantityOnPickListColumn
        '
        Me.QuantityOnPickListColumn.DataPropertyName = "QuantityOnPickList"
        DataGridViewCellStyle8.NullValue = "0"
        Me.QuantityOnPickListColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.QuantityOnPickListColumn.HeaderText = "Quantity On Pick List"
        Me.QuantityOnPickListColumn.Name = "QuantityOnPickListColumn"
        Me.QuantityOnPickListColumn.ReadOnly = True
        Me.QuantityOnPickListColumn.Visible = False
        Me.QuantityOnPickListColumn.Width = 106
        '
        'ViewSalesLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdOpenSalesOrder)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvSalesOrderLines)
        Me.Controls.Add(Me.gpxQuotationFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewSalesLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Sales Order Lines"
        Me.gpxQuotationFilter.ResumeLayout(False)
        Me.gpxQuotationFilter.PerformLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSalesOrderLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxQuotationFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvSalesOrderLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SalesOrderQuantityStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderQuantityStatusTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderQuantityStatusTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdOpenSalesOrder As System.Windows.Forms.Button
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PrintCustCopySalesReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMargin As System.Windows.Forms.Label
    Friend WithEvents txtMargin As System.Windows.Forms.TextBox
    Friend WithEvents lblCOGS As System.Windows.Forms.Label
    Friend WithEvents txtCOGS As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents cboSalesPerson As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents cboSOStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtQtyOpen As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyShipped As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyOrdered As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chkViewClosedWithOpen As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintListingwQuantityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintListingwPricingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewAllLinesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLast3YearsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DivisionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOrderedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropShipPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxOrderedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenLineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnPickListColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
