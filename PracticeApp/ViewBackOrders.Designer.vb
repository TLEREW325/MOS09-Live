<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewBackOrders
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gpxBackOrderFilters = New System.Windows.Forms.GroupBox
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.chkBackOrders = New System.Windows.Forms.CheckBox
        Me.chkPickedOrders = New System.Windows.Forms.CheckBox
        Me.chkOpenOrders = New System.Windows.Forms.CheckBox
        Me.cboSalesperson = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBOListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdOpenSOForm = New System.Windows.Forms.Button
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.cmdCompleteShipment = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkPrintPackingList = New System.Windows.Forms.CheckBox
        Me.chkPrintPickTicket = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdProcessAll = New System.Windows.Forms.Button
        Me.cmdProcessBackOrder = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdItemList = New System.Windows.Forms.Button
        Me.lblLoading = New System.Windows.Forms.Label
        Me.BGLoading = New System.ComponentModel.BackgroundWorker
        Me.cmdViewWIP = New System.Windows.Forms.Button
        Me.dgvBackOrderLineQuery = New System.Windows.Forms.DataGridView
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOrderedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenLineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeadTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingMethodColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalespersonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MAXShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BackOrderTestBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BackOrderTestTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BackOrderTestTableAdapter
        Me.dgvSOLines = New System.Windows.Forms.DataGridView
        Me.SOSalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOSalesOrderLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SODivisionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SODescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOQuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOSalesTaxOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOOpenLineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SODebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOCreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOCertificationTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderQuantityStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SalesOrderQuantityStatusTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderQuantityStatusTableAdapter
        Me.Label16 = New System.Windows.Forms.Label
        Me.gpxBackOrderFilters.SuspendLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvBackOrderLineQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BackOrderTestBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSOLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxBackOrderFilters
        '
        Me.gpxBackOrderFilters.Controls.Add(Me.txtTextFilter)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label15)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label13)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label11)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label10)
        Me.gpxBackOrderFilters.Controls.Add(Me.chkBackOrders)
        Me.gpxBackOrderFilters.Controls.Add(Me.chkPickedOrders)
        Me.gpxBackOrderFilters.Controls.Add(Me.chkOpenOrders)
        Me.gpxBackOrderFilters.Controls.Add(Me.cboSalesperson)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label6)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label14)
        Me.gpxBackOrderFilters.Controls.Add(Me.chkDateRange)
        Me.gpxBackOrderFilters.Controls.Add(Me.dtpEndDate)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label9)
        Me.gpxBackOrderFilters.Controls.Add(Me.dtpBeginDate)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label8)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label12)
        Me.gpxBackOrderFilters.Controls.Add(Me.txtCustomerPO)
        Me.gpxBackOrderFilters.Controls.Add(Me.cboCustomerName)
        Me.gpxBackOrderFilters.Controls.Add(Me.cboCustomerID)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label1)
        Me.gpxBackOrderFilters.Controls.Add(Me.cboDivisionID)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label5)
        Me.gpxBackOrderFilters.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxBackOrderFilters.Controls.Add(Me.cmdClear)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label2)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label4)
        Me.gpxBackOrderFilters.Controls.Add(Me.cmdViewByFilter)
        Me.gpxBackOrderFilters.Controls.Add(Me.cboPartDescription)
        Me.gpxBackOrderFilters.Controls.Add(Me.cboPartNumber)
        Me.gpxBackOrderFilters.Controls.Add(Me.Label3)
        Me.gpxBackOrderFilters.Location = New System.Drawing.Point(29, 41)
        Me.gpxBackOrderFilters.Name = "gpxBackOrderFilters"
        Me.gpxBackOrderFilters.Size = New System.Drawing.Size(300, 770)
        Me.gpxBackOrderFilters.TabIndex = 0
        Me.gpxBackOrderFilters.TabStop = False
        Me.gpxBackOrderFilters.Text = "View By Filters"
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(110, 337)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(177, 20)
        Me.txtTextFilter.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(18, 337)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 20)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "Text Filter"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Location = New System.Drawing.Point(23, 466)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 20)
        Me.Label13.TabIndex = 27
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(23, 499)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 20)
        Me.Label11.TabIndex = 26
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Location = New System.Drawing.Point(23, 532)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 20)
        Me.Label10.TabIndex = 25
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkBackOrders
        '
        Me.chkBackOrders.AutoSize = True
        Me.chkBackOrders.Location = New System.Drawing.Point(50, 535)
        Me.chkBackOrders.Name = "chkBackOrders"
        Me.chkBackOrders.Size = New System.Drawing.Size(240, 17)
        Me.chkBackOrders.TabIndex = 11
        Me.chkBackOrders.Text = "View Back Orders (Open Order w/prev. ship.)"
        Me.chkBackOrders.UseVisualStyleBackColor = True
        '
        'chkPickedOrders
        '
        Me.chkPickedOrders.AutoSize = True
        Me.chkPickedOrders.Location = New System.Drawing.Point(50, 502)
        Me.chkPickedOrders.Name = "chkPickedOrders"
        Me.chkPickedOrders.Size = New System.Drawing.Size(125, 17)
        Me.chkPickedOrders.TabIndex = 10
        Me.chkPickedOrders.Text = "View Orders w/Picks"
        Me.chkPickedOrders.UseVisualStyleBackColor = True
        '
        'chkOpenOrders
        '
        Me.chkOpenOrders.AutoSize = True
        Me.chkOpenOrders.Location = New System.Drawing.Point(50, 468)
        Me.chkOpenOrders.Name = "chkOpenOrders"
        Me.chkOpenOrders.Size = New System.Drawing.Size(162, 17)
        Me.chkOpenOrders.TabIndex = 9
        Me.chkOpenOrders.Text = "View Open Orders (no Picks)"
        Me.chkOpenOrders.UseVisualStyleBackColor = True
        '
        'cboSalesperson
        '
        Me.cboSalesperson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesperson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesperson.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalesperson.DisplayMember = "SalesPersonID"
        Me.cboSalesperson.FormattingEnabled = True
        Me.cboSalesperson.Location = New System.Drawing.Point(23, 411)
        Me.cboSalesperson.Name = "cboSalesperson"
        Me.cboSalesperson.Size = New System.Drawing.Size(264, 21)
        Me.cboSalesperson.TabIndex = 8
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
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 388)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Salesperson"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(18, 591)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(113, 627)
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
        Me.dtpEndDate.Location = New System.Drawing.Point(110, 692)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpEndDate.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(22, 692)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 20)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "End Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(110, 657)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpBeginDate.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(22, 657)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 20)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Begin Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(20, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(267, 40)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Location = New System.Drawing.Point(110, 306)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(177, 20)
        Me.txtCustomerPO.TabIndex = 6
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(20, 134)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(267, 21)
        Me.cboCustomerName.TabIndex = 2
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
        Me.cboCustomerID.Location = New System.Drawing.Point(94, 105)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(193, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 306)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Customer PO #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.cboDivisionID.Size = New System.Drawing.Size(193, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Customer ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(110, 274)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(177, 21)
        Me.cboSalesOrderNumber.TabIndex = 5
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(216, 727)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 16
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 275)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Sales Order #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(141, 727)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 15
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 300
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(21, 215)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(266, 21)
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
        Me.cboPartNumber.DropDownWidth = 250
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(94, 182)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(193, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 183)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Part Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1061, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 19
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintBOListingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintBOListingToolStripMenuItem
        '
        Me.PrintBOListingToolStripMenuItem.Name = "PrintBOListingToolStripMenuItem"
        Me.PrintBOListingToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.PrintBOListingToolStripMenuItem.Text = "Print Back Order Listing"
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(984, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 14
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdOpenSOForm
        '
        Me.cmdOpenSOForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenSOForm.ForeColor = System.Drawing.Color.Black
        Me.cmdOpenSOForm.Location = New System.Drawing.Point(830, 771)
        Me.cmdOpenSOForm.Name = "cmdOpenSOForm"
        Me.cmdOpenSOForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenSOForm.TabIndex = 13
        Me.cmdOpenSOForm.Text = "SO Form"
        Me.cmdOpenSOForm.UseVisualStyleBackColor = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'cmdCompleteShipment
        '
        Me.cmdCompleteShipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCompleteShipment.ForeColor = System.Drawing.Color.Black
        Me.cmdCompleteShipment.Location = New System.Drawing.Point(907, 771)
        Me.cmdCompleteShipment.Name = "cmdCompleteShipment"
        Me.cmdCompleteShipment.Size = New System.Drawing.Size(71, 40)
        Me.cmdCompleteShipment.TabIndex = 21
        Me.cmdCompleteShipment.Text = "Shipment Completion"
        Me.cmdCompleteShipment.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.chkPrintPackingList)
        Me.GroupBox1.Controls.Add(Me.chkPrintPickTicket)
        Me.GroupBox1.Location = New System.Drawing.Point(735, 646)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(395, 119)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Print Options for selected order in datagrid"
        '
        'chkPrintPackingList
        '
        Me.chkPrintPackingList.AutoSize = True
        Me.chkPrintPackingList.Location = New System.Drawing.Point(25, 56)
        Me.chkPrintPackingList.Name = "chkPrintPackingList"
        Me.chkPrintPackingList.Size = New System.Drawing.Size(204, 17)
        Me.chkPrintPackingList.TabIndex = 1
        Me.chkPrintPackingList.Text = "Print Packing List(s) for selected order"
        Me.chkPrintPackingList.UseVisualStyleBackColor = True
        '
        'chkPrintPickTicket
        '
        Me.chkPrintPickTicket.AutoSize = True
        Me.chkPrintPickTicket.Location = New System.Drawing.Point(25, 30)
        Me.chkPrintPickTicket.Name = "chkPrintPickTicket"
        Me.chkPrintPickTicket.Size = New System.Drawing.Size(200, 17)
        Me.chkPrintPickTicket.TabIndex = 0
        Me.chkPrintPickTicket.Text = "Print Pick Ticket(s) for selected order"
        Me.chkPrintPickTicket.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdProcessAll)
        Me.GroupBox2.Controls.Add(Me.cmdProcessBackOrder)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(350, 646)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(379, 119)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Process Back Order for selected order"
        '
        'cmdProcessAll
        '
        Me.cmdProcessAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdProcessAll.ForeColor = System.Drawing.Color.Blue
        Me.cmdProcessAll.Location = New System.Drawing.Point(290, 67)
        Me.cmdProcessAll.Name = "cmdProcessAll"
        Me.cmdProcessAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdProcessAll.TabIndex = 49
        Me.cmdProcessAll.Text = "Process All"
        Me.cmdProcessAll.UseVisualStyleBackColor = True
        '
        'cmdProcessBackOrder
        '
        Me.cmdProcessBackOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdProcessBackOrder.ForeColor = System.Drawing.Color.Blue
        Me.cmdProcessBackOrder.Location = New System.Drawing.Point(213, 67)
        Me.cmdProcessBackOrder.Name = "cmdProcessBackOrder"
        Me.cmdProcessBackOrder.Size = New System.Drawing.Size(71, 40)
        Me.cmdProcessBackOrder.TabIndex = 15
        Me.cmdProcessBackOrder.Text = "Process Back Order"
        Me.cmdProcessBackOrder.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(22, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(322, 56)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Select Back Order from datagrid (shaded gray) and press ""Process Backorder"" to cr" & _
            "eate/print Pick Ticket and create the pending shipment."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdItemList
        '
        Me.cmdItemList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdItemList.ForeColor = System.Drawing.Color.Black
        Me.cmdItemList.Location = New System.Drawing.Point(735, 771)
        Me.cmdItemList.Name = "cmdItemList"
        Me.cmdItemList.Size = New System.Drawing.Size(71, 40)
        Me.cmdItemList.TabIndex = 25
        Me.cmdItemList.Text = "Item Form"
        Me.cmdItemList.UseVisualStyleBackColor = True
        '
        'lblLoading
        '
        Me.lblLoading.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.Blue
        Me.lblLoading.Location = New System.Drawing.Point(573, 260)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(380, 125)
        Me.lblLoading.TabIndex = 62
        Me.lblLoading.Text = "LOADING..."
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLoading.Visible = False
        '
        'BGLoading
        '
        '
        'cmdViewWIP
        '
        Me.cmdViewWIP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewWIP.ForeColor = System.Drawing.Color.Black
        Me.cmdViewWIP.Location = New System.Drawing.Point(658, 771)
        Me.cmdViewWIP.Name = "cmdViewWIP"
        Me.cmdViewWIP.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewWIP.TabIndex = 63
        Me.cmdViewWIP.Text = "View WIP"
        Me.cmdViewWIP.UseVisualStyleBackColor = True
        Me.cmdViewWIP.Visible = False
        '
        'dgvBackOrderLineQuery
        '
        Me.dgvBackOrderLineQuery.AllowUserToAddRows = False
        Me.dgvBackOrderLineQuery.AllowUserToDeleteRows = False
        Me.dgvBackOrderLineQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBackOrderLineQuery.AutoGenerateColumns = False
        Me.dgvBackOrderLineQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvBackOrderLineQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvBackOrderLineQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBackOrderLineQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDColumn, Me.SalesOrderKeyColumn, Me.ItemIDColumn, Me.DescriptionColumn, Me.QuantityOrderedColumn, Me.QuantityShippedColumn, Me.QuantityOpenColumn, Me.QuantityOnHandColumn, Me.OpenLineWeightColumn, Me.SalesOrderDateColumn, Me.LeadTimeColumn, Me.ShipViaColumn, Me.ShippingMethodColumn, Me.SalespersonColumn, Me.ShippingDateColumn, Me.CustomerPOColumn, Me.LineCommentColumn, Me.LineStatusColumn, Me.SOStatusColumn, Me.MAXShipmentNumberColumn, Me.SalesOrderLineKeyColumn, Me.DivisionKeyColumn})
        Me.dgvBackOrderLineQuery.DataSource = Me.BackOrderTestBindingSource
        Me.dgvBackOrderLineQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvBackOrderLineQuery.Location = New System.Drawing.Point(350, 41)
        Me.dgvBackOrderLineQuery.Name = "dgvBackOrderLineQuery"
        Me.dgvBackOrderLineQuery.ReadOnly = True
        Me.dgvBackOrderLineQuery.Size = New System.Drawing.Size(780, 599)
        Me.dgvBackOrderLineQuery.TabIndex = 64
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        Me.SalesOrderKeyColumn.ReadOnly = True
        Me.SalesOrderKeyColumn.Width = 80
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "Part #"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.ReadOnly = True
        '
        'QuantityOrderedColumn
        '
        Me.QuantityOrderedColumn.DataPropertyName = "QuantityOrdered"
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.QuantityOrderedColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.QuantityOrderedColumn.HeaderText = "Order Qty"
        Me.QuantityOrderedColumn.Name = "QuantityOrderedColumn"
        Me.QuantityOrderedColumn.ReadOnly = True
        Me.QuantityOrderedColumn.Width = 80
        '
        'QuantityShippedColumn
        '
        Me.QuantityShippedColumn.DataPropertyName = "QuantityShipped"
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.QuantityShippedColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.QuantityShippedColumn.HeaderText = "Qty Shipped"
        Me.QuantityShippedColumn.Name = "QuantityShippedColumn"
        Me.QuantityShippedColumn.ReadOnly = True
        Me.QuantityShippedColumn.Width = 80
        '
        'QuantityOpenColumn
        '
        Me.QuantityOpenColumn.DataPropertyName = "QuantityOpen"
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = "0"
        Me.QuantityOpenColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.QuantityOpenColumn.HeaderText = "Open Qty"
        Me.QuantityOpenColumn.Name = "QuantityOpenColumn"
        Me.QuantityOpenColumn.ReadOnly = True
        Me.QuantityOpenColumn.Width = 80
        '
        'QuantityOnHandColumn
        '
        Me.QuantityOnHandColumn.DataPropertyName = "QuantityOnHand"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = "0"
        Me.QuantityOnHandColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.QuantityOnHandColumn.HeaderText = "QOH"
        Me.QuantityOnHandColumn.Name = "QuantityOnHandColumn"
        Me.QuantityOnHandColumn.ReadOnly = True
        Me.QuantityOnHandColumn.Width = 80
        '
        'OpenLineWeightColumn
        '
        Me.OpenLineWeightColumn.DataPropertyName = "OpenLineWeight"
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = "0"
        Me.OpenLineWeightColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.OpenLineWeightColumn.HeaderText = "Open Weight"
        Me.OpenLineWeightColumn.Name = "OpenLineWeightColumn"
        Me.OpenLineWeightColumn.ReadOnly = True
        Me.OpenLineWeightColumn.Width = 80
        '
        'SalesOrderDateColumn
        '
        Me.SalesOrderDateColumn.DataPropertyName = "SalesOrderDate"
        Me.SalesOrderDateColumn.HeaderText = "SO Date"
        Me.SalesOrderDateColumn.Name = "SalesOrderDateColumn"
        Me.SalesOrderDateColumn.ReadOnly = True
        Me.SalesOrderDateColumn.Width = 80
        '
        'LeadTimeColumn
        '
        Me.LeadTimeColumn.DataPropertyName = "LeadTime"
        Me.LeadTimeColumn.HeaderText = "Lead Time"
        Me.LeadTimeColumn.Name = "LeadTimeColumn"
        Me.LeadTimeColumn.ReadOnly = True
        Me.LeadTimeColumn.Width = 80
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        Me.ShipViaColumn.ReadOnly = True
        '
        'ShippingMethodColumn
        '
        Me.ShippingMethodColumn.DataPropertyName = "ShippingMethod"
        Me.ShippingMethodColumn.HeaderText = "Ship Method"
        Me.ShippingMethodColumn.Name = "ShippingMethodColumn"
        Me.ShippingMethodColumn.ReadOnly = True
        '
        'SalespersonColumn
        '
        Me.SalespersonColumn.DataPropertyName = "Salesperson"
        Me.SalespersonColumn.HeaderText = "Salesperson"
        Me.SalespersonColumn.Name = "SalespersonColumn"
        Me.SalespersonColumn.ReadOnly = True
        '
        'ShippingDateColumn
        '
        Me.ShippingDateColumn.DataPropertyName = "ShippingDate"
        Me.ShippingDateColumn.HeaderText = "Ship Date"
        Me.ShippingDateColumn.Name = "ShippingDateColumn"
        Me.ShippingDateColumn.ReadOnly = True
        Me.ShippingDateColumn.Width = 80
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust. PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.ReadOnly = True
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.ReadOnly = True
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        Me.LineStatusColumn.Visible = False
        '
        'SOStatusColumn
        '
        Me.SOStatusColumn.DataPropertyName = "SOStatus"
        Me.SOStatusColumn.HeaderText = "SOStatus"
        Me.SOStatusColumn.Name = "SOStatusColumn"
        Me.SOStatusColumn.ReadOnly = True
        Me.SOStatusColumn.Visible = False
        '
        'MAXShipmentNumberColumn
        '
        Me.MAXShipmentNumberColumn.DataPropertyName = "MAXShipmentNumber"
        Me.MAXShipmentNumberColumn.HeaderText = "MAXShipmentNumber"
        Me.MAXShipmentNumberColumn.Name = "MAXShipmentNumberColumn"
        Me.MAXShipmentNumberColumn.ReadOnly = True
        Me.MAXShipmentNumberColumn.Visible = False
        '
        'SalesOrderLineKeyColumn
        '
        Me.SalesOrderLineKeyColumn.DataPropertyName = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumn.HeaderText = "SalesOrderLineKey"
        Me.SalesOrderLineKeyColumn.Name = "SalesOrderLineKeyColumn"
        Me.SalesOrderLineKeyColumn.ReadOnly = True
        Me.SalesOrderLineKeyColumn.Visible = False
        '
        'DivisionKeyColumn
        '
        Me.DivisionKeyColumn.DataPropertyName = "DivisionKey"
        Me.DivisionKeyColumn.HeaderText = "DivisionKey"
        Me.DivisionKeyColumn.Name = "DivisionKeyColumn"
        Me.DivisionKeyColumn.ReadOnly = True
        Me.DivisionKeyColumn.Visible = False
        '
        'BackOrderTestBindingSource
        '
        Me.BackOrderTestBindingSource.DataMember = "BackOrderTest"
        Me.BackOrderTestBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'BackOrderTestTableAdapter
        '
        Me.BackOrderTestTableAdapter.ClearBeforeFill = True
        '
        'dgvSOLines
        '
        Me.dgvSOLines.AllowUserToAddRows = False
        Me.dgvSOLines.AllowUserToDeleteRows = False
        Me.dgvSOLines.AutoGenerateColumns = False
        Me.dgvSOLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSOLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SOSalesOrderKeyColumn, Me.SOSalesOrderLineKeyColumn, Me.SODivisionKeyColumn, Me.SOItemIDColumn, Me.SODescriptionColumn, Me.SOQuantityOpenColumn, Me.SOSalesTaxOpenColumn, Me.SOPriceColumn, Me.SOLineCommentColumn, Me.SOLineWeightColumn, Me.SOLineBoxesColumn, Me.SOOpenLineWeightColumn, Me.SODebitGLAccountColumn, Me.SOCreditGLAccountColumn, Me.SOCertificationTypeColumn})
        Me.dgvSOLines.DataSource = Me.SalesOrderQuantityStatusBindingSource
        Me.dgvSOLines.Location = New System.Drawing.Point(674, 217)
        Me.dgvSOLines.Name = "dgvSOLines"
        Me.dgvSOLines.ReadOnly = True
        Me.dgvSOLines.Size = New System.Drawing.Size(80, 61)
        Me.dgvSOLines.TabIndex = 65
        '
        'SOSalesOrderKeyColumn
        '
        Me.SOSalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SOSalesOrderKeyColumn.HeaderText = "SalesOrderKey"
        Me.SOSalesOrderKeyColumn.Name = "SOSalesOrderKeyColumn"
        Me.SOSalesOrderKeyColumn.ReadOnly = True
        '
        'SOSalesOrderLineKeyColumn
        '
        Me.SOSalesOrderLineKeyColumn.DataPropertyName = "SalesOrderLineKey"
        Me.SOSalesOrderLineKeyColumn.HeaderText = "SalesOrderLineKey"
        Me.SOSalesOrderLineKeyColumn.Name = "SOSalesOrderLineKeyColumn"
        Me.SOSalesOrderLineKeyColumn.ReadOnly = True
        '
        'SODivisionKeyColumn
        '
        Me.SODivisionKeyColumn.DataPropertyName = "DivisionKey"
        Me.SODivisionKeyColumn.HeaderText = "DivisionKey"
        Me.SODivisionKeyColumn.Name = "SODivisionKeyColumn"
        Me.SODivisionKeyColumn.ReadOnly = True
        '
        'SOItemIDColumn
        '
        Me.SOItemIDColumn.DataPropertyName = "ItemID"
        Me.SOItemIDColumn.HeaderText = "ItemID"
        Me.SOItemIDColumn.Name = "SOItemIDColumn"
        Me.SOItemIDColumn.ReadOnly = True
        '
        'SODescriptionColumn
        '
        Me.SODescriptionColumn.DataPropertyName = "Description"
        Me.SODescriptionColumn.HeaderText = "Description"
        Me.SODescriptionColumn.Name = "SODescriptionColumn"
        Me.SODescriptionColumn.ReadOnly = True
        '
        'SOQuantityOpenColumn
        '
        Me.SOQuantityOpenColumn.DataPropertyName = "QuantityOpen"
        Me.SOQuantityOpenColumn.HeaderText = "QuantityOpen"
        Me.SOQuantityOpenColumn.Name = "SOQuantityOpenColumn"
        Me.SOQuantityOpenColumn.ReadOnly = True
        '
        'SOSalesTaxOpenColumn
        '
        Me.SOSalesTaxOpenColumn.DataPropertyName = "SalesTaxOpen"
        Me.SOSalesTaxOpenColumn.HeaderText = "SalesTaxOpen"
        Me.SOSalesTaxOpenColumn.Name = "SOSalesTaxOpenColumn"
        Me.SOSalesTaxOpenColumn.ReadOnly = True
        '
        'SOPriceColumn
        '
        Me.SOPriceColumn.DataPropertyName = "Price"
        Me.SOPriceColumn.HeaderText = "Price"
        Me.SOPriceColumn.Name = "SOPriceColumn"
        Me.SOPriceColumn.ReadOnly = True
        '
        'SOLineCommentColumn
        '
        Me.SOLineCommentColumn.DataPropertyName = "LineComment"
        Me.SOLineCommentColumn.HeaderText = "LineComment"
        Me.SOLineCommentColumn.Name = "SOLineCommentColumn"
        Me.SOLineCommentColumn.ReadOnly = True
        '
        'SOLineWeightColumn
        '
        Me.SOLineWeightColumn.DataPropertyName = "LineWeight"
        Me.SOLineWeightColumn.HeaderText = "LineWeight"
        Me.SOLineWeightColumn.Name = "SOLineWeightColumn"
        Me.SOLineWeightColumn.ReadOnly = True
        '
        'SOLineBoxesColumn
        '
        Me.SOLineBoxesColumn.DataPropertyName = "LineBoxes"
        Me.SOLineBoxesColumn.HeaderText = "LineBoxes"
        Me.SOLineBoxesColumn.Name = "SOLineBoxesColumn"
        Me.SOLineBoxesColumn.ReadOnly = True
        '
        'SOOpenLineWeightColumn
        '
        Me.SOOpenLineWeightColumn.DataPropertyName = "OpenLineWeight"
        Me.SOOpenLineWeightColumn.HeaderText = "OpenLineWeight"
        Me.SOOpenLineWeightColumn.Name = "SOOpenLineWeightColumn"
        Me.SOOpenLineWeightColumn.ReadOnly = True
        '
        'SODebitGLAccountColumn
        '
        Me.SODebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.SODebitGLAccountColumn.HeaderText = "DebitGLAccount"
        Me.SODebitGLAccountColumn.Name = "SODebitGLAccountColumn"
        Me.SODebitGLAccountColumn.ReadOnly = True
        '
        'SOCreditGLAccountColumn
        '
        Me.SOCreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.SOCreditGLAccountColumn.HeaderText = "CreditGLAccount"
        Me.SOCreditGLAccountColumn.Name = "SOCreditGLAccountColumn"
        Me.SOCreditGLAccountColumn.ReadOnly = True
        '
        'SOCertificationTypeColumn
        '
        Me.SOCertificationTypeColumn.DataPropertyName = "CertificationType"
        Me.SOCertificationTypeColumn.HeaderText = "CertificationType"
        Me.SOCertificationTypeColumn.Name = "SOCertificationTypeColumn"
        Me.SOCertificationTypeColumn.ReadOnly = True
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
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(22, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(337, 34)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Choose between pick ticket and packing list when you double-click in datagrid."
        '
        'ViewBackOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.lblLoading)
        Me.Controls.Add(Me.dgvBackOrderLineQuery)
        Me.Controls.Add(Me.cmdViewWIP)
        Me.Controls.Add(Me.cmdItemList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCompleteShipment)
        Me.Controls.Add(Me.cmdOpenSOForm)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxBackOrderFilters)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvSOLines)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewBackOrders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation - Manage Open Orders and Back Orders"
        Me.gpxBackOrderFilters.ResumeLayout(False)
        Me.gpxBackOrderFilters.PerformLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvBackOrderLineQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BackOrderTestBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSOLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxBackOrderFilters As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdOpenSOForm As System.Windows.Forms.Button
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents TotalQuantityShippedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintBOListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboSalesperson As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents chkBackOrders As System.Windows.Forms.CheckBox
    Friend WithEvents chkPickedOrders As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpenOrders As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCompleteShipment As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPrintPackingList As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintPickTicket As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdProcessBackOrder As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdItemList As System.Windows.Forms.Button
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents BGLoading As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmdViewWIP As System.Windows.Forms.Button
    Friend WithEvents dgvBackOrderLineQuery As System.Windows.Forms.DataGridView
    Friend WithEvents BackOrderTestBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BackOrderTestTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BackOrderTestTableAdapter
    Friend WithEvents dgvSOLines As System.Windows.Forms.DataGridView
    Friend WithEvents SalesOrderQuantityStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderQuantityStatusTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderQuantityStatusTableAdapter
    Friend WithEvents SOSalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOSalesOrderLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SODivisionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SODescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOQuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOSalesTaxOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOOpenLineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SODebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOCreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOCertificationTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdProcessAll As System.Windows.Forms.Button
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOrderedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenLineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethodColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalespersonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MAXShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
