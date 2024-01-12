<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewShipmentLotNumbers
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxViewShippingStatus = New System.Windows.Forms.GroupBox
        Me.cboShipmentNumber = New System.Windows.Forms.ComboBox
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboShipStatus = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.ShipmentLotLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentLotLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLotLineQueryTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.dgvShipmentLotQuery = New System.Windows.Forms.DataGridView
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PullTestNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLotLineQueryBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdReprintCertSingle = New System.Windows.Forms.Button
        Me.cmdReprintCertBatch = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxViewShippingStatus.SuspendLayout()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentLotLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShipmentLotQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentLotLineQueryBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gpxViewShippingStatus
        '
        Me.gpxViewShippingStatus.Controls.Add(Me.cboShipmentNumber)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label9)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboHeatNumber)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label6)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboLotNumber)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label5)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboDescription)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboPartNumber)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label4)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboShipStatus)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label15)
        Me.gpxViewShippingStatus.Controls.Add(Me.txtCustomerPO)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label13)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label14)
        Me.gpxViewShippingStatus.Controls.Add(Me.chkDateRange)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label7)
        Me.gpxViewShippingStatus.Controls.Add(Me.cmdClear)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxViewShippingStatus.Controls.Add(Me.cmdViewByFilters)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboCustomerName)
        Me.gpxViewShippingStatus.Controls.Add(Me.dtpEndDate)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboCustomerID)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label8)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label12)
        Me.gpxViewShippingStatus.Controls.Add(Me.dtpBeginDate)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label2)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label3)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboDivisionID)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label1)
        Me.gpxViewShippingStatus.Location = New System.Drawing.Point(27, 41)
        Me.gpxViewShippingStatus.Name = "gpxViewShippingStatus"
        Me.gpxViewShippingStatus.Size = New System.Drawing.Size(300, 770)
        Me.gpxViewShippingStatus.TabIndex = 0
        Me.gpxViewShippingStatus.TabStop = False
        Me.gpxViewShippingStatus.Text = "View By Filters"
        '
        'cboShipmentNumber
        '
        Me.cboShipmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboShipmentNumber.DisplayMember = "ShipmentNumber"
        Me.cboShipmentNumber.FormattingEnabled = True
        Me.cboShipmentNumber.Location = New System.Drawing.Point(102, 236)
        Me.cboShipmentNumber.Name = "cboShipmentNumber"
        Me.cboShipmentNumber.Size = New System.Drawing.Size(183, 21)
        Me.cboShipmentNumber.TabIndex = 4
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 237)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 20)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Ship. #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatNumber.DisplayMember = "HeatNumber"
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(67, 512)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(218, 21)
        Me.cboHeatNumber.TabIndex = 10
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 513)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 20)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Heat #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.DataSource = Me.LotNumberBindingSource
        Me.cboLotNumber.DisplayMember = "LotNumber"
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(67, 463)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(218, 21)
        Me.cboLotNumber.TabIndex = 9
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 464)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 20)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Lot #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDescription
        '
        Me.cboDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDescription.DataSource = Me.ItemListBindingSource
        Me.cboDescription.DisplayMember = "ShortDescription"
        Me.cboDescription.FormattingEnabled = True
        Me.cboDescription.Location = New System.Drawing.Point(19, 407)
        Me.cboDescription.Name = "cboDescription"
        Me.cboDescription.Size = New System.Drawing.Size(266, 21)
        Me.cboDescription.TabIndex = 8
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
        Me.cboPartNumber.Location = New System.Drawing.Point(67, 376)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(218, 21)
        Me.cboPartNumber.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 377)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Part #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipStatus
        '
        Me.cboShipStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipStatus.FormattingEnabled = True
        Me.cboShipStatus.Items.AddRange(New Object() {"OPEN", "SHIPPED", "INVOICED"})
        Me.cboShipStatus.Location = New System.Drawing.Point(102, 327)
        Me.cboShipStatus.Name = "cboShipStatus"
        Me.cboShipStatus.Size = New System.Drawing.Size(183, 21)
        Me.cboShipStatus.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(17, 328)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(132, 20)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Ship. Status"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.Location = New System.Drawing.Point(102, 281)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(183, 20)
        Me.txtCustomerPO.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 281)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Cust. PO#"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(20, 593)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(106, 629)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 11
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(16, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(269, 29)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(218, 726)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(102, 193)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(183, 21)
        Me.cboSalesOrderNumber.TabIndex = 3
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(141, 726)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 14
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(19, 139)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(266, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(106, 692)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpEndDate.TabIndex = 13
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(67, 108)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(218, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(22, 692)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 20)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(17, 194)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(132, 20)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Sales Order #"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(106, 657)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpBeginDate.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(22, 657)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Begin Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Customer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(102, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(183, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShipmentLotLineQueryBindingSource
        '
        Me.ShipmentLotLineQueryBindingSource.DataMember = "ShipmentLotLineQuery"
        Me.ShipmentLotLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentLotLineQueryTableAdapter
        '
        Me.ShipmentLotLineQueryTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(884, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 18
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 19
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
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'dgvShipmentLotQuery
        '
        Me.dgvShipmentLotQuery.AllowUserToAddRows = False
        Me.dgvShipmentLotQuery.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvShipmentLotQuery.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShipmentLotQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipmentLotQuery.AutoGenerateColumns = False
        Me.dgvShipmentLotQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentLotQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentLotQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDColumn, Me.ShipmentNumberColumn, Me.PartNumberColumn, Me.ShortDescriptionColumn, Me.LotNumberColumn, Me.HeatNumberColumn, Me.HeatQuantityColumn, Me.SalesOrderKeyColumn, Me.ShipDateColumn, Me.CustomerPOColumn, Me.FOXNumberColumn, Me.ShipmentStatusColumn, Me.DivisionIDColumn, Me.ShipmentLineNumberColumn, Me.LotLineNumberColumn, Me.PullTestNumberColumn})
        Me.dgvShipmentLotQuery.DataSource = Me.ShipmentLotLineQueryBindingSource1
        Me.dgvShipmentLotQuery.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipmentLotQuery.Location = New System.Drawing.Point(343, 41)
        Me.dgvShipmentLotQuery.Name = "dgvShipmentLotQuery"
        Me.dgvShipmentLotQuery.Size = New System.Drawing.Size(687, 716)
        Me.dgvShipmentLotQuery.TabIndex = 20
        Me.dgvShipmentLotQuery.TabStop = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Ship. #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        Me.ShipmentNumberColumn.Width = 80
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "Description"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        Me.ShortDescriptionColumn.ReadOnly = True
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        Me.LotNumberColumn.ReadOnly = True
        Me.LotNumberColumn.Width = 80
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.ReadOnly = True
        Me.HeatNumberColumn.Width = 80
        '
        'HeatQuantityColumn
        '
        Me.HeatQuantityColumn.DataPropertyName = "HeatQuantity"
        Me.HeatQuantityColumn.HeaderText = "Heat Qty."
        Me.HeatQuantityColumn.Name = "HeatQuantityColumn"
        Me.HeatQuantityColumn.ReadOnly = True
        Me.HeatQuantityColumn.Width = 80
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        Me.SalesOrderKeyColumn.ReadOnly = True
        Me.SalesOrderKeyColumn.Width = 80
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.ReadOnly = True
        Me.ShipDateColumn.Width = 80
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust. PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.ReadOnly = True
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        Me.FOXNumberColumn.Width = 80
        '
        'ShipmentStatusColumn
        '
        Me.ShipmentStatusColumn.DataPropertyName = "ShipmentStatus"
        Me.ShipmentStatusColumn.HeaderText = "Status"
        Me.ShipmentStatusColumn.Name = "ShipmentStatusColumn"
        Me.ShipmentStatusColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'ShipmentLineNumberColumn
        '
        Me.ShipmentLineNumberColumn.DataPropertyName = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn.HeaderText = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn.Name = "ShipmentLineNumberColumn"
        Me.ShipmentLineNumberColumn.ReadOnly = True
        Me.ShipmentLineNumberColumn.Visible = False
        '
        'LotLineNumberColumn
        '
        Me.LotLineNumberColumn.DataPropertyName = "LotLineNumber"
        Me.LotLineNumberColumn.HeaderText = "LotLineNumber"
        Me.LotLineNumberColumn.Name = "LotLineNumberColumn"
        Me.LotLineNumberColumn.ReadOnly = True
        Me.LotLineNumberColumn.Visible = False
        '
        'PullTestNumberColumn
        '
        Me.PullTestNumberColumn.DataPropertyName = "PullTestNumber"
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        Me.PullTestNumberColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PullTestNumberColumn.HeaderText = "Pull Test #"
        Me.PullTestNumberColumn.Name = "PullTestNumberColumn"
        Me.PullTestNumberColumn.ReadOnly = True
        '
        'ShipmentLotLineQueryBindingSource1
        '
        Me.ShipmentLotLineQueryBindingSource1.DataMember = "ShipmentLotLineQuery"
        Me.ShipmentLotLineQueryBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdReprintCertSingle
        '
        Me.cmdReprintCertSingle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReprintCertSingle.Location = New System.Drawing.Point(343, 771)
        Me.cmdReprintCertSingle.Name = "cmdReprintCertSingle"
        Me.cmdReprintCertSingle.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprintCertSingle.TabIndex = 16
        Me.cmdReprintCertSingle.Text = "Re-Print Cert"
        Me.cmdReprintCertSingle.UseVisualStyleBackColor = True
        '
        'cmdReprintCertBatch
        '
        Me.cmdReprintCertBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReprintCertBatch.Location = New System.Drawing.Point(420, 771)
        Me.cmdReprintCertBatch.Name = "cmdReprintCertBatch"
        Me.cmdReprintCertBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprintCertBatch.TabIndex = 17
        Me.cmdReprintCertBatch.Text = "Re-Print Cert Batch"
        Me.cmdReprintCertBatch.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(497, 778)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(293, 33)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "Re-print a single cert or all certs for a selected shipment by clicking the selec" & _
            "ted shipment in the datagrid."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewShipmentLotNumbers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdReprintCertBatch)
        Me.Controls.Add(Me.cmdReprintCertSingle)
        Me.Controls.Add(Me.dgvShipmentLotQuery)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxViewShippingStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewShipmentLotNumbers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Shipment Lot Numbers"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxViewShippingStatus.ResumeLayout(False)
        Me.gpxViewShippingStatus.PerformLayout()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentLotLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShipmentLotQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentLotLineQueryBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxViewShippingStatus As System.Windows.Forms.GroupBox
    Friend WithEvents cboShipStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ShipmentLotLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentLotLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLotLineQueryTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents cboShipmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvShipmentLotQuery As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentLotLineQueryBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents cmdReprintCertSingle As System.Windows.Forms.Button
    Friend WithEvents cmdReprintCertBatch As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PullTestNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
