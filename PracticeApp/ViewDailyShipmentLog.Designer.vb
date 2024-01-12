<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewDailyShipmentLog
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintDetailedLogReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxShipmentLog = New System.Windows.Forms.GroupBox
        Me.chkIncludeTFP = New System.Windows.Forms.CheckBox
        Me.chkCompleted = New System.Windows.Forms.CheckBox
        Me.txtShipVia = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboSalesperson = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboShipmentNumber = New System.Windows.Forms.ComboBox
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdShipmentDetails = New System.Windows.Forms.Button
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.dgvShipmentHeader = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightActualAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfPalletsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesmanIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickTicketNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TaxTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtShipmentTotal = New System.Windows.Forms.TextBox
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.txtTaxTotal = New System.Windows.Forms.TextBox
        Me.txtFreightTotal = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdPrintListing = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtTotalPallets = New System.Windows.Forms.TextBox
        Me.txtTotalNumberOfShipments = New System.Windows.Forms.TextBox
        Me.txtTotalWeight = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.ViewAllShipmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLast3YearsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.gpxShipmentLog.SuspendLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShipmentHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewAllShipmentsToolStripMenuItem, Me.ViewLast3YearsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem, Me.PrintDetailedLogReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
        '
        'PrintDetailedLogReportToolStripMenuItem
        '
        Me.PrintDetailedLogReportToolStripMenuItem.Name = "PrintDetailedLogReportToolStripMenuItem"
        Me.PrintDetailedLogReportToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.PrintDetailedLogReportToolStripMenuItem.Text = "Print Detailed Log Report"
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
        'gpxShipmentLog
        '
        Me.gpxShipmentLog.Controls.Add(Me.chkIncludeTFP)
        Me.gpxShipmentLog.Controls.Add(Me.chkCompleted)
        Me.gpxShipmentLog.Controls.Add(Me.txtShipVia)
        Me.gpxShipmentLog.Controls.Add(Me.Label18)
        Me.gpxShipmentLog.Controls.Add(Me.cboSalesperson)
        Me.gpxShipmentLog.Controls.Add(Me.Label15)
        Me.gpxShipmentLog.Controls.Add(Me.cboShipmentNumber)
        Me.gpxShipmentLog.Controls.Add(Me.txtCustomerPO)
        Me.gpxShipmentLog.Controls.Add(Me.Label13)
        Me.gpxShipmentLog.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxShipmentLog.Controls.Add(Me.Label6)
        Me.gpxShipmentLog.Controls.Add(Me.Label5)
        Me.gpxShipmentLog.Controls.Add(Me.Label2)
        Me.gpxShipmentLog.Controls.Add(Me.Label14)
        Me.gpxShipmentLog.Controls.Add(Me.chkDateRange)
        Me.gpxShipmentLog.Controls.Add(Me.dtpEndDate)
        Me.gpxShipmentLog.Controls.Add(Me.cboCustomerName)
        Me.gpxShipmentLog.Controls.Add(Me.cmdViewByFilters)
        Me.gpxShipmentLog.Controls.Add(Me.Label8)
        Me.gpxShipmentLog.Controls.Add(Me.cmdClear)
        Me.gpxShipmentLog.Controls.Add(Me.cboCustomerID)
        Me.gpxShipmentLog.Controls.Add(Me.dtpBeginDate)
        Me.gpxShipmentLog.Controls.Add(Me.cboDivisionID)
        Me.gpxShipmentLog.Controls.Add(Me.Label7)
        Me.gpxShipmentLog.Controls.Add(Me.Label3)
        Me.gpxShipmentLog.Controls.Add(Me.Label1)
        Me.gpxShipmentLog.Location = New System.Drawing.Point(29, 41)
        Me.gpxShipmentLog.Name = "gpxShipmentLog"
        Me.gpxShipmentLog.Size = New System.Drawing.Size(300, 674)
        Me.gpxShipmentLog.TabIndex = 0
        Me.gpxShipmentLog.TabStop = False
        Me.gpxShipmentLog.Text = "View By Filters"
        '
        'chkIncludeTFP
        '
        Me.chkIncludeTFP.AutoSize = True
        Me.chkIncludeTFP.Checked = True
        Me.chkIncludeTFP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeTFP.Location = New System.Drawing.Point(113, 430)
        Me.chkIncludeTFP.Name = "chkIncludeTFP"
        Me.chkIncludeTFP.Size = New System.Drawing.Size(90, 17)
        Me.chkIncludeTFP.TabIndex = 49
        Me.chkIncludeTFP.Text = "Include TFP?"
        Me.chkIncludeTFP.UseVisualStyleBackColor = True
        '
        'chkCompleted
        '
        Me.chkCompleted.AutoSize = True
        Me.chkCompleted.Checked = True
        Me.chkCompleted.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompleted.Location = New System.Drawing.Point(110, 392)
        Me.chkCompleted.Name = "chkCompleted"
        Me.chkCompleted.Size = New System.Drawing.Size(152, 17)
        Me.chkCompleted.TabIndex = 48
        Me.chkCompleted.Text = "Completed Shipments Only"
        Me.chkCompleted.UseVisualStyleBackColor = True
        '
        'txtShipVia
        '
        Me.txtShipVia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipVia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipVia.Location = New System.Drawing.Point(108, 343)
        Me.txtShipVia.Name = "txtShipVia"
        Me.txtShipVia.Size = New System.Drawing.Size(176, 20)
        Me.txtShipVia.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(17, 343)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 20)
        Me.Label18.TabIndex = 47
        Me.Label18.Text = "Ship Via"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesperson
        '
        Me.cboSalesperson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesperson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesperson.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalesperson.DisplayMember = "SalesPersonID"
        Me.cboSalesperson.DropDownWidth = 250
        Me.cboSalesperson.FormattingEnabled = True
        Me.cboSalesperson.Location = New System.Drawing.Point(108, 268)
        Me.cboSalesperson.Name = "cboSalesperson"
        Me.cboSalesperson.Size = New System.Drawing.Size(176, 21)
        Me.cboSalesperson.TabIndex = 5
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
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(17, 269)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 20)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Salesman"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipmentNumber
        '
        Me.cboShipmentNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboShipmentNumber.DisplayMember = "ShipmentNumber"
        Me.cboShipmentNumber.FormattingEnabled = True
        Me.cboShipmentNumber.Location = New System.Drawing.Point(108, 192)
        Me.cboShipmentNumber.Name = "cboShipmentNumber"
        Me.cboShipmentNumber.Size = New System.Drawing.Size(176, 21)
        Me.cboShipmentNumber.TabIndex = 3
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.Location = New System.Drawing.Point(108, 306)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(176, 20)
        Me.txtCustomerPO.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(17, 306)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Customer PO#"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.DropDownWidth = 250
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(108, 230)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(176, 21)
        Me.cboSalesOrderNumber.TabIndex = 4
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 231)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Sales Order #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Shipment #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(15, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(269, 40)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(17, 485)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(110, 521)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 8
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(110, 585)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(15, 149)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(270, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(137, 627)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 11
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 585)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 627)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(83, 113)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(201, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(110, 552)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(109, 27)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(175, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 552)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Begin Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Customer ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(50, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 19)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Opens Shipment Viewer"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdShipmentDetails
        '
        Me.cmdShipmentDetails.Location = New System.Drawing.Point(213, 25)
        Me.cmdShipmentDetails.Name = "cmdShipmentDetails"
        Me.cmdShipmentDetails.Size = New System.Drawing.Size(71, 40)
        Me.cmdShipmentDetails.TabIndex = 14
        Me.cmdShipmentDetails.Text = "View/Edit Shipment"
        Me.cmdShipmentDetails.UseVisualStyleBackColor = True
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvShipmentHeader
        '
        Me.dgvShipmentHeader.AllowDrop = True
        Me.dgvShipmentHeader.AllowUserToAddRows = False
        Me.dgvShipmentHeader.AllowUserToDeleteRows = False
        Me.dgvShipmentHeader.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvShipmentHeader.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShipmentHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipmentHeader.AutoGenerateColumns = False
        Me.dgvShipmentHeader.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentHeader.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvShipmentHeader.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvShipmentHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.ShipmentNumberColumn, Me.SalesOrderKeyColumn, Me.ShipDateColumn, Me.CustomerIDColumn, Me.CustomerPOColumn, Me.ProductTotalColumn, Me.FreightActualAmountColumn, Me.ShipmentTotalColumn, Me.ShippingWeightColumn, Me.NumberOfPalletsColumn, Me.ShipViaColumn, Me.PRONumberColumn, Me.FreightQuoteNumberColumn, Me.FreightQuoteAmountColumn, Me.ShipToIDColumn, Me.ShipAddress1Column, Me.ShipAddress2Column, Me.ShipCityColumn, Me.ShipStateColumn, Me.ShipZipColumn, Me.ShipCountryColumn, Me.CommentColumn, Me.SpecialInstructionsColumn, Me.SalesmanIDColumn, Me.PickTicketNumberColumn, Me.BatchNumberColumn, Me.ShipmentStatusColumn, Me.TaxTotalColumn})
        Me.dgvShipmentHeader.DataSource = Me.ShipmentHeaderTableBindingSource
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvShipmentHeader.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvShipmentHeader.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipmentHeader.Location = New System.Drawing.Point(349, 41)
        Me.dgvShipmentHeader.Name = "dgvShipmentHeader"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvShipmentHeader.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvShipmentHeader.Size = New System.Drawing.Size(781, 618)
        Me.dgvShipmentHeader.TabIndex = 17
        Me.dgvShipmentHeader.TabStop = False
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
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        Me.ShipmentNumberColumn.Width = 80
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
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.ShipDateColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.ReadOnly = True
        Me.ShipDateColumn.Width = 75
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer ID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Customer PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.Width = 85
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.ReadOnly = True
        Me.ProductTotalColumn.Width = 80
        '
        'FreightActualAmountColumn
        '
        Me.FreightActualAmountColumn.DataPropertyName = "FreightActualAmount"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.FreightActualAmountColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.FreightActualAmountColumn.HeaderText = "Freight"
        Me.FreightActualAmountColumn.Name = "FreightActualAmountColumn"
        Me.FreightActualAmountColumn.ReadOnly = True
        Me.FreightActualAmountColumn.Width = 80
        '
        'ShipmentTotalColumn
        '
        Me.ShipmentTotalColumn.DataPropertyName = "ShipmentTotal"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ShipmentTotalColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ShipmentTotalColumn.HeaderText = "Shipment Total"
        Me.ShipmentTotalColumn.Name = "ShipmentTotalColumn"
        Me.ShipmentTotalColumn.ReadOnly = True
        Me.ShipmentTotalColumn.Width = 80
        '
        'ShippingWeightColumn
        '
        Me.ShippingWeightColumn.DataPropertyName = "ShippingWeight"
        Me.ShippingWeightColumn.HeaderText = "Shipping Weight"
        Me.ShippingWeightColumn.Name = "ShippingWeightColumn"
        Me.ShippingWeightColumn.Width = 80
        '
        'NumberOfPalletsColumn
        '
        Me.NumberOfPalletsColumn.DataPropertyName = "NumberOfPallets"
        Me.NumberOfPalletsColumn.HeaderText = "Number Of Pallets"
        Me.NumberOfPalletsColumn.Name = "NumberOfPalletsColumn"
        Me.NumberOfPalletsColumn.Width = 80
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        '
        'PRONumberColumn
        '
        Me.PRONumberColumn.DataPropertyName = "PRONumber"
        Me.PRONumberColumn.HeaderText = "PRO Number"
        Me.PRONumberColumn.Name = "PRONumberColumn"
        '
        'FreightQuoteNumberColumn
        '
        Me.FreightQuoteNumberColumn.DataPropertyName = "FreightQuoteNumber"
        Me.FreightQuoteNumberColumn.HeaderText = "Freight Quote #"
        Me.FreightQuoteNumberColumn.Name = "FreightQuoteNumberColumn"
        Me.FreightQuoteNumberColumn.Width = 80
        '
        'FreightQuoteAmountColumn
        '
        Me.FreightQuoteAmountColumn.DataPropertyName = "FreightQuoteAmount"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.FreightQuoteAmountColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.FreightQuoteAmountColumn.HeaderText = "Freight Quote Amount"
        Me.FreightQuoteAmountColumn.Name = "FreightQuoteAmountColumn"
        Me.FreightQuoteAmountColumn.Width = 80
        '
        'ShipToIDColumn
        '
        Me.ShipToIDColumn.DataPropertyName = "ShipToID"
        Me.ShipToIDColumn.HeaderText = "Ship To ID"
        Me.ShipToIDColumn.Name = "ShipToIDColumn"
        '
        'ShipAddress1Column
        '
        Me.ShipAddress1Column.DataPropertyName = "ShipAddress1"
        Me.ShipAddress1Column.HeaderText = "Ship Address 1"
        Me.ShipAddress1Column.Name = "ShipAddress1Column"
        '
        'ShipAddress2Column
        '
        Me.ShipAddress2Column.DataPropertyName = "ShipAddress2"
        Me.ShipAddress2Column.HeaderText = "Ship Address 2"
        Me.ShipAddress2Column.Name = "ShipAddress2Column"
        '
        'ShipCityColumn
        '
        Me.ShipCityColumn.DataPropertyName = "ShipCity"
        Me.ShipCityColumn.HeaderText = "Ship City"
        Me.ShipCityColumn.Name = "ShipCityColumn"
        '
        'ShipStateColumn
        '
        Me.ShipStateColumn.DataPropertyName = "ShipState"
        Me.ShipStateColumn.HeaderText = "Ship State"
        Me.ShipStateColumn.Name = "ShipStateColumn"
        '
        'ShipZipColumn
        '
        Me.ShipZipColumn.DataPropertyName = "ShipZip"
        Me.ShipZipColumn.HeaderText = "Ship Zip"
        Me.ShipZipColumn.Name = "ShipZipColumn"
        '
        'ShipCountryColumn
        '
        Me.ShipCountryColumn.DataPropertyName = "ShipCountry"
        Me.ShipCountryColumn.HeaderText = "Ship Country"
        Me.ShipCountryColumn.Name = "ShipCountryColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'SpecialInstructionsColumn
        '
        Me.SpecialInstructionsColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsColumn.HeaderText = "Special Instructions"
        Me.SpecialInstructionsColumn.Name = "SpecialInstructionsColumn"
        '
        'SalesmanIDColumn
        '
        Me.SalesmanIDColumn.DataPropertyName = "SalesmanID"
        Me.SalesmanIDColumn.HeaderText = "Salesman"
        Me.SalesmanIDColumn.Name = "SalesmanIDColumn"
        '
        'PickTicketNumberColumn
        '
        Me.PickTicketNumberColumn.DataPropertyName = "PickTicketNumber"
        Me.PickTicketNumberColumn.HeaderText = "Pick Ticket #"
        Me.PickTicketNumberColumn.Name = "PickTicketNumberColumn"
        Me.PickTicketNumberColumn.Visible = False
        Me.PickTicketNumberColumn.Width = 85
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "Batch Number"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Visible = False
        '
        'ShipmentStatusColumn
        '
        Me.ShipmentStatusColumn.DataPropertyName = "ShipmentStatus"
        Me.ShipmentStatusColumn.HeaderText = "Shipment Status"
        Me.ShipmentStatusColumn.Name = "ShipmentStatusColumn"
        Me.ShipmentStatusColumn.Visible = False
        '
        'TaxTotalColumn
        '
        Me.TaxTotalColumn.DataPropertyName = "TaxTotal"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.TaxTotalColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.TaxTotalColumn.HeaderText = "Tax Total"
        Me.TaxTotalColumn.Name = "TaxTotalColumn"
        Me.TaxTotalColumn.ReadOnly = True
        Me.TaxTotalColumn.Visible = False
        Me.TaxTotalColumn.Width = 80
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(905, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print Detail Report"
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
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtShipmentTotal)
        Me.GroupBox2.Controls.Add(Me.txtProductTotal)
        Me.GroupBox2.Controls.Add(Me.txtTaxTotal)
        Me.GroupBox2.Controls.Add(Me.txtFreightTotal)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(349, 676)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(298, 135)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Shipment Totals"
        '
        'txtShipmentTotal
        '
        Me.txtShipmentTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipmentTotal.Location = New System.Drawing.Point(136, 101)
        Me.txtShipmentTotal.Name = "txtShipmentTotal"
        Me.txtShipmentTotal.Size = New System.Drawing.Size(147, 20)
        Me.txtShipmentTotal.TabIndex = 3
        Me.txtShipmentTotal.TabStop = False
        Me.txtShipmentTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductTotal.Location = New System.Drawing.Point(136, 23)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.Size = New System.Drawing.Size(147, 20)
        Me.txtProductTotal.TabIndex = 0
        Me.txtProductTotal.TabStop = False
        Me.txtProductTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTaxTotal
        '
        Me.txtTaxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTaxTotal.Location = New System.Drawing.Point(136, 75)
        Me.txtTaxTotal.Name = "txtTaxTotal"
        Me.txtTaxTotal.Size = New System.Drawing.Size(147, 20)
        Me.txtTaxTotal.TabIndex = 2
        Me.txtTaxTotal.TabStop = False
        Me.txtTaxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightTotal
        '
        Me.txtFreightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightTotal.Location = New System.Drawing.Point(136, 49)
        Me.txtFreightTotal.Name = "txtFreightTotal"
        Me.txtFreightTotal.Size = New System.Drawing.Size(147, 20)
        Me.txtFreightTotal.TabIndex = 1
        Me.txtFreightTotal.TabStop = False
        Me.txtFreightTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(20, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Product Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(20, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Freight Total"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(20, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Sales Tax Total"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(20, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Shipment Total"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmdShipmentDetails)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 732)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 79)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View Shipment Details"
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(902, 685)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(228, 34)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Changes to certain fields may be made in the datagrid and the changes will be aut" & _
            "omatically saved."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(905, 716)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(225, 34)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "To reprint Packing List, double click on Shipment in the datagrid."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintListing
        '
        Me.cmdPrintListing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintListing.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrintListing.Name = "cmdPrintListing"
        Me.cmdPrintListing.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintListing.TabIndex = 39
        Me.cmdPrintListing.Text = "Print Listing"
        Me.cmdPrintListing.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtTotalPallets)
        Me.GroupBox3.Controls.Add(Me.txtTotalNumberOfShipments)
        Me.GroupBox3.Controls.Add(Me.txtTotalWeight)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Location = New System.Drawing.Point(660, 676)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(236, 134)
        Me.GroupBox3.TabIndex = 40
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Shipment Details"
        '
        'txtTotalPallets
        '
        Me.txtTotalPallets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPallets.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalPallets.Location = New System.Drawing.Point(112, 23)
        Me.txtTotalPallets.Name = "txtTotalPallets"
        Me.txtTotalPallets.Size = New System.Drawing.Size(114, 20)
        Me.txtTotalPallets.TabIndex = 10
        Me.txtTotalPallets.TabStop = False
        Me.txtTotalPallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNumberOfShipments
        '
        Me.txtTotalNumberOfShipments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalNumberOfShipments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalNumberOfShipments.Location = New System.Drawing.Point(112, 101)
        Me.txtTotalNumberOfShipments.Name = "txtTotalNumberOfShipments"
        Me.txtTotalNumberOfShipments.Size = New System.Drawing.Size(114, 20)
        Me.txtTotalNumberOfShipments.TabIndex = 12
        Me.txtTotalNumberOfShipments.TabStop = False
        Me.txtTotalNumberOfShipments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalWeight.Location = New System.Drawing.Point(112, 62)
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.Size = New System.Drawing.Size(114, 20)
        Me.txtTotalWeight.TabIndex = 11
        Me.txtTotalWeight.TabStop = False
        Me.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(6, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 20)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "Total Pallets"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(6, 62)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 20)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "Total Weight"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(6, 101)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 20)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "Total # Shipments"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewAllShipmentsToolStripMenuItem
        '
        Me.ViewAllShipmentsToolStripMenuItem.CheckOnClick = True
        Me.ViewAllShipmentsToolStripMenuItem.Name = "ViewAllShipmentsToolStripMenuItem"
        Me.ViewAllShipmentsToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ViewAllShipmentsToolStripMenuItem.Text = "View All Shipments"
        '
        'ViewLast3YearsToolStripMenuItem
        '
        Me.ViewLast3YearsToolStripMenuItem.Checked = True
        Me.ViewLast3YearsToolStripMenuItem.CheckOnClick = True
        Me.ViewLast3YearsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ViewLast3YearsToolStripMenuItem.Name = "ViewLast3YearsToolStripMenuItem"
        Me.ViewLast3YearsToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ViewLast3YearsToolStripMenuItem.Text = "View Last 3 Years"
        '
        'ViewDailyShipmentLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdPrintListing)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvShipmentHeader)
        Me.Controls.Add(Me.gpxShipmentLog)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewDailyShipmentLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Daily Shipment Log"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxShipmentLog.ResumeLayout(False)
        Me.gpxShipmentLog.PerformLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShipmentHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxShipmentLog As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdShipmentDetails As System.Windows.Forms.Button
    Friend WithEvents cboShipmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dgvShipmentHeader As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtShipmentTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtFreightTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents cboSalesperson As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintListing As System.Windows.Forms.Button
    Friend WithEvents PrintDetailedLogReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightActualAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfPalletsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesmanIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickTicketNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtShipVia As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents chkCompleted As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncludeTFP As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalPallets As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNumberOfShipments As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ViewAllShipmentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLast3YearsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
