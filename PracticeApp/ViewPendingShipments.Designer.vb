<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPendingShipments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewPendingShipments))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxFilterData = New System.Windows.Forms.GroupBox
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cboSalesman = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboShipmentNumber = New System.Windows.Forms.ComboBox
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdOpenShipmentForm = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.ShipmentLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineQueryTableAdapter
        Me.dgvShipmentLineQuery = New System.Windows.Forms.DataGridView
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickTicketNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesmanIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingMethodColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfPalletsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightActualAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TaxTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertificationTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCOSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tax2TotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tax3TotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropshipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxFilterData.SuspendLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ShipmentLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShipmentLineQuery, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem1})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem1
        '
        Me.PrintListingToolStripMenuItem1.Name = "PrintListingToolStripMenuItem1"
        Me.PrintListingToolStripMenuItem1.Size = New System.Drawing.Size(129, 22)
        Me.PrintListingToolStripMenuItem1.Text = "Print Listing"
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 16
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 17
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxFilterData
        '
        Me.gpxFilterData.Controls.Add(Me.chkDateRange)
        Me.gpxFilterData.Controls.Add(Me.cboSalesman)
        Me.gpxFilterData.Controls.Add(Me.txtCustomerPO)
        Me.gpxFilterData.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxFilterData.Controls.Add(Me.cboShipmentNumber)
        Me.gpxFilterData.Controls.Add(Me.cmdViewByFilters)
        Me.gpxFilterData.Controls.Add(Me.cmdClear)
        Me.gpxFilterData.Controls.Add(Me.Label11)
        Me.gpxFilterData.Controls.Add(Me.Label12)
        Me.gpxFilterData.Controls.Add(Me.Label14)
        Me.gpxFilterData.Controls.Add(Me.dtpEndDate)
        Me.gpxFilterData.Controls.Add(Me.dtpBeginDate)
        Me.gpxFilterData.Controls.Add(Me.Label2)
        Me.gpxFilterData.Controls.Add(Me.Label5)
        Me.gpxFilterData.Controls.Add(Me.cboDivisionID)
        Me.gpxFilterData.Controls.Add(Me.Label4)
        Me.gpxFilterData.Controls.Add(Me.cboCustomerName)
        Me.gpxFilterData.Controls.Add(Me.Label1)
        Me.gpxFilterData.Controls.Add(Me.Label7)
        Me.gpxFilterData.Controls.Add(Me.cboPartDescription)
        Me.gpxFilterData.Controls.Add(Me.cboCustomerID)
        Me.gpxFilterData.Controls.Add(Me.cboPartNumber)
        Me.gpxFilterData.Controls.Add(Me.Label3)
        Me.gpxFilterData.Controls.Add(Me.Label6)
        Me.gpxFilterData.Controls.Add(Me.Label10)
        Me.gpxFilterData.Location = New System.Drawing.Point(29, 41)
        Me.gpxFilterData.Name = "gpxFilterData"
        Me.gpxFilterData.Size = New System.Drawing.Size(300, 656)
        Me.gpxFilterData.TabIndex = 0
        Me.gpxFilterData.TabStop = False
        Me.gpxFilterData.Text = "View By Filters"
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(96, 504)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 9
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cboSalesman
        '
        Me.cboSalesman.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalesman.DisplayMember = "SalesPersonID"
        Me.cboSalesman.FormattingEnabled = True
        Me.cboSalesman.Location = New System.Drawing.Point(90, 425)
        Me.cboSalesman.Name = "cboSalesman"
        Me.cboSalesman.Size = New System.Drawing.Size(190, 21)
        Me.cboSalesman.TabIndex = 8
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
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.Location = New System.Drawing.Point(90, 382)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(190, 20)
        Me.txtCustomerPO.TabIndex = 7
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(90, 294)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(190, 21)
        Me.cboSalesOrderNumber.TabIndex = 5
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboShipmentNumber
        '
        Me.cboShipmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboShipmentNumber.DisplayMember = "ShipmentNumber"
        Me.cboShipmentNumber.FormattingEnabled = True
        Me.cboShipmentNumber.Location = New System.Drawing.Point(90, 338)
        Me.cboShipmentNumber.Name = "cboShipmentNumber"
        Me.cboShipmentNumber.Size = New System.Drawing.Size(190, 21)
        Me.cboShipmentNumber.TabIndex = 6
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(132, 609)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 12
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(209, 609)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(19, 382)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 20)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Cust. PO #"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(20, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(261, 42)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 473)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(261, 33)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(101, 573)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpEndDate.TabIndex = 11
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(101, 537)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpBeginDate.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 573)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 20)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "End Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 537)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 20)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Begin Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(91, 29)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(190, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 295)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 20)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "SO #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(23, 152)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(258, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 339)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 20)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Shipment #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(23, 235)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(258, 21)
        Me.cboPartDescription.TabIndex = 4
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(91, 122)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(190, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(62, 204)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(219, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Part #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Customer ID"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(19, 426)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 20)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Salesman"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.cmdOpenShipmentForm)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 718)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 93)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Open Complete Shipment Form"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(16, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(188, 40)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Select shipment from drop down or grid to go to Complete Shipment Form"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenShipmentForm
        '
        Me.cmdOpenShipmentForm.Location = New System.Drawing.Point(210, 34)
        Me.cmdOpenShipmentForm.Name = "cmdOpenShipmentForm"
        Me.cmdOpenShipmentForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenShipmentForm.TabIndex = 15
        Me.cmdOpenShipmentForm.Text = "Complete Shipment"
        Me.cmdOpenShipmentForm.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(457, 762)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(406, 59)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = resources.GetString("Label9.Text")
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShipmentLineQueryBindingSource
        '
        Me.ShipmentLineQueryBindingSource.DataMember = "ShipmentLineQuery"
        Me.ShipmentLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentLineQueryTableAdapter
        '
        Me.ShipmentLineQueryTableAdapter.ClearBeforeFill = True
        '
        'dgvShipmentLineQuery
        '
        Me.dgvShipmentLineQuery.AllowUserToAddRows = False
        Me.dgvShipmentLineQuery.AllowUserToDeleteRows = False
        Me.dgvShipmentLineQuery.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvShipmentLineQuery.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShipmentLineQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipmentLineQuery.AutoGenerateColumns = False
        Me.dgvShipmentLineQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentLineQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvShipmentLineQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentLineQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDColumn, Me.PaymentTermsColumn, Me.CustomerPOColumn, Me.ShipDateColumn, Me.SalesOrderKeyColumn, Me.PickTicketNumberColumn, Me.ShipmentNumberColumn, Me.ShipmentLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityShippedColumn, Me.PriceColumn, Me.ExtendedAmountColumn, Me.SalesmanIDColumn, Me.ShipViaColumn, Me.ShippingMethodColumn, Me.LineCommentColumn, Me.LineStatusColumn, Me.LineBoxesColumn, Me.DivisionIDColumn, Me.LineWeightColumn, Me.GLDebitAccountDataGridViewTextBoxColumn, Me.GLCreditAccountDataGridViewTextBoxColumn, Me.ShipmentTotalDataGridViewTextBoxColumn, Me.PRONumberDataGridViewTextBoxColumn, Me.SalesTaxColumn, Me.FreightQuoteNumberDataGridViewTextBoxColumn, Me.FreightQuoteAmountDataGridViewTextBoxColumn, Me.ShippingWeightDataGridViewTextBoxColumn, Me.NumberOfPalletsDataGridViewTextBoxColumn, Me.FreightActualAmountDataGridViewTextBoxColumn, Me.TaxTotalColumn, Me.ProductTotalDataGridViewTextBoxColumn, Me.ShipmentStatusDataGridViewTextBoxColumn, Me.CertificationTypeDataGridViewTextBoxColumn, Me.ExtendedCOSDataGridViewTextBoxColumn, Me.SOLineNumberDataGridViewTextBoxColumn, Me.UnitCostDataGridViewTextBoxColumn, Me.Tax2TotalDataGridViewTextBoxColumn, Me.Tax3TotalDataGridViewTextBoxColumn, Me.SerialNumberDataGridViewTextBoxColumn, Me.DropshipDataGridViewTextBoxColumn, Me.SpecialInstructionsDataGridViewTextBoxColumn})
        Me.dgvShipmentLineQuery.DataSource = Me.ShipmentLineQueryBindingSource
        Me.dgvShipmentLineQuery.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipmentLineQuery.Location = New System.Drawing.Point(345, 41)
        Me.dgvShipmentLineQuery.Name = "dgvShipmentLineQuery"
        Me.dgvShipmentLineQuery.ReadOnly = True
        Me.dgvShipmentLineQuery.Size = New System.Drawing.Size(785, 707)
        Me.dgvShipmentLineQuery.TabIndex = 21
        Me.dgvShipmentLineQuery.TabStop = False
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        Me.PaymentTermsColumn.ReadOnly = True
        Me.PaymentTermsColumn.Width = 80
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust. PO #"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.ReadOnly = True
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.ReadOnly = True
        Me.ShipDateColumn.Width = 80
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        Me.SalesOrderKeyColumn.ReadOnly = True
        Me.SalesOrderKeyColumn.Width = 80
        '
        'PickTicketNumberColumn
        '
        Me.PickTicketNumberColumn.DataPropertyName = "PickTicketNumber"
        Me.PickTicketNumberColumn.HeaderText = "Pick Ticket #"
        Me.PickTicketNumberColumn.Name = "PickTicketNumberColumn"
        Me.PickTicketNumberColumn.ReadOnly = True
        Me.PickTicketNumberColumn.Width = 80
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Ship. #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        Me.ShipmentNumberColumn.Width = 80
        '
        'ShipmentLineNumberColumn
        '
        Me.ShipmentLineNumberColumn.DataPropertyName = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn.HeaderText = "Line #"
        Me.ShipmentLineNumberColumn.Name = "ShipmentLineNumberColumn"
        Me.ShipmentLineNumberColumn.ReadOnly = True
        Me.ShipmentLineNumberColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        '
        'QuantityShippedColumn
        '
        Me.QuantityShippedColumn.DataPropertyName = "QuantityShipped"
        Me.QuantityShippedColumn.HeaderText = "Quantity"
        Me.QuantityShippedColumn.Name = "QuantityShippedColumn"
        Me.QuantityShippedColumn.ReadOnly = True
        Me.QuantityShippedColumn.Width = 80
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.ReadOnly = True
        Me.PriceColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ExtendedAmountColumn.HeaderText = "Ext. Amt."
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 80
        '
        'SalesmanIDColumn
        '
        Me.SalesmanIDColumn.DataPropertyName = "SalesmanID"
        Me.SalesmanIDColumn.HeaderText = "Salesman"
        Me.SalesmanIDColumn.Name = "SalesmanIDColumn"
        Me.SalesmanIDColumn.ReadOnly = True
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
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        Me.LineBoxesColumn.HeaderText = "LineBoxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        Me.LineBoxesColumn.ReadOnly = True
        Me.LineBoxesColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        Me.LineWeightColumn.HeaderText = "LineWeight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.ReadOnly = True
        Me.LineWeightColumn.Visible = False
        '
        'GLDebitAccountDataGridViewTextBoxColumn
        '
        Me.GLDebitAccountDataGridViewTextBoxColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountDataGridViewTextBoxColumn.HeaderText = "GLDebitAccount"
        Me.GLDebitAccountDataGridViewTextBoxColumn.Name = "GLDebitAccountDataGridViewTextBoxColumn"
        Me.GLDebitAccountDataGridViewTextBoxColumn.ReadOnly = True
        Me.GLDebitAccountDataGridViewTextBoxColumn.Visible = False
        '
        'GLCreditAccountDataGridViewTextBoxColumn
        '
        Me.GLCreditAccountDataGridViewTextBoxColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountDataGridViewTextBoxColumn.HeaderText = "GLCreditAccount"
        Me.GLCreditAccountDataGridViewTextBoxColumn.Name = "GLCreditAccountDataGridViewTextBoxColumn"
        Me.GLCreditAccountDataGridViewTextBoxColumn.ReadOnly = True
        Me.GLCreditAccountDataGridViewTextBoxColumn.Visible = False
        '
        'ShipmentTotalDataGridViewTextBoxColumn
        '
        Me.ShipmentTotalDataGridViewTextBoxColumn.DataPropertyName = "ShipmentTotal"
        Me.ShipmentTotalDataGridViewTextBoxColumn.HeaderText = "ShipmentTotal"
        Me.ShipmentTotalDataGridViewTextBoxColumn.Name = "ShipmentTotalDataGridViewTextBoxColumn"
        Me.ShipmentTotalDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipmentTotalDataGridViewTextBoxColumn.Visible = False
        '
        'PRONumberDataGridViewTextBoxColumn
        '
        Me.PRONumberDataGridViewTextBoxColumn.DataPropertyName = "PRONumber"
        Me.PRONumberDataGridViewTextBoxColumn.HeaderText = "PRONumber"
        Me.PRONumberDataGridViewTextBoxColumn.Name = "PRONumberDataGridViewTextBoxColumn"
        Me.PRONumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.PRONumberDataGridViewTextBoxColumn.Visible = False
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Visible = False
        '
        'FreightQuoteNumberDataGridViewTextBoxColumn
        '
        Me.FreightQuoteNumberDataGridViewTextBoxColumn.DataPropertyName = "FreightQuoteNumber"
        Me.FreightQuoteNumberDataGridViewTextBoxColumn.HeaderText = "FreightQuoteNumber"
        Me.FreightQuoteNumberDataGridViewTextBoxColumn.Name = "FreightQuoteNumberDataGridViewTextBoxColumn"
        Me.FreightQuoteNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.FreightQuoteNumberDataGridViewTextBoxColumn.Visible = False
        '
        'FreightQuoteAmountDataGridViewTextBoxColumn
        '
        Me.FreightQuoteAmountDataGridViewTextBoxColumn.DataPropertyName = "FreightQuoteAmount"
        Me.FreightQuoteAmountDataGridViewTextBoxColumn.HeaderText = "FreightQuoteAmount"
        Me.FreightQuoteAmountDataGridViewTextBoxColumn.Name = "FreightQuoteAmountDataGridViewTextBoxColumn"
        Me.FreightQuoteAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.FreightQuoteAmountDataGridViewTextBoxColumn.Visible = False
        '
        'ShippingWeightDataGridViewTextBoxColumn
        '
        Me.ShippingWeightDataGridViewTextBoxColumn.DataPropertyName = "ShippingWeight"
        Me.ShippingWeightDataGridViewTextBoxColumn.HeaderText = "ShippingWeight"
        Me.ShippingWeightDataGridViewTextBoxColumn.Name = "ShippingWeightDataGridViewTextBoxColumn"
        Me.ShippingWeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShippingWeightDataGridViewTextBoxColumn.Visible = False
        '
        'NumberOfPalletsDataGridViewTextBoxColumn
        '
        Me.NumberOfPalletsDataGridViewTextBoxColumn.DataPropertyName = "NumberOfPallets"
        Me.NumberOfPalletsDataGridViewTextBoxColumn.HeaderText = "NumberOfPallets"
        Me.NumberOfPalletsDataGridViewTextBoxColumn.Name = "NumberOfPalletsDataGridViewTextBoxColumn"
        Me.NumberOfPalletsDataGridViewTextBoxColumn.ReadOnly = True
        Me.NumberOfPalletsDataGridViewTextBoxColumn.Visible = False
        '
        'FreightActualAmountDataGridViewTextBoxColumn
        '
        Me.FreightActualAmountDataGridViewTextBoxColumn.DataPropertyName = "FreightActualAmount"
        Me.FreightActualAmountDataGridViewTextBoxColumn.HeaderText = "FreightActualAmount"
        Me.FreightActualAmountDataGridViewTextBoxColumn.Name = "FreightActualAmountDataGridViewTextBoxColumn"
        Me.FreightActualAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.FreightActualAmountDataGridViewTextBoxColumn.Visible = False
        '
        'TaxTotalColumn
        '
        Me.TaxTotalColumn.DataPropertyName = "TaxTotal"
        Me.TaxTotalColumn.HeaderText = "TaxTotal"
        Me.TaxTotalColumn.Name = "TaxTotalColumn"
        Me.TaxTotalColumn.ReadOnly = True
        Me.TaxTotalColumn.Visible = False
        '
        'ProductTotalDataGridViewTextBoxColumn
        '
        Me.ProductTotalDataGridViewTextBoxColumn.DataPropertyName = "ProductTotal"
        Me.ProductTotalDataGridViewTextBoxColumn.HeaderText = "ProductTotal"
        Me.ProductTotalDataGridViewTextBoxColumn.Name = "ProductTotalDataGridViewTextBoxColumn"
        Me.ProductTotalDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProductTotalDataGridViewTextBoxColumn.Visible = False
        '
        'ShipmentStatusDataGridViewTextBoxColumn
        '
        Me.ShipmentStatusDataGridViewTextBoxColumn.DataPropertyName = "ShipmentStatus"
        Me.ShipmentStatusDataGridViewTextBoxColumn.HeaderText = "ShipmentStatus"
        Me.ShipmentStatusDataGridViewTextBoxColumn.Name = "ShipmentStatusDataGridViewTextBoxColumn"
        Me.ShipmentStatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipmentStatusDataGridViewTextBoxColumn.Visible = False
        '
        'CertificationTypeDataGridViewTextBoxColumn
        '
        Me.CertificationTypeDataGridViewTextBoxColumn.DataPropertyName = "CertificationType"
        Me.CertificationTypeDataGridViewTextBoxColumn.HeaderText = "CertificationType"
        Me.CertificationTypeDataGridViewTextBoxColumn.Name = "CertificationTypeDataGridViewTextBoxColumn"
        Me.CertificationTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.CertificationTypeDataGridViewTextBoxColumn.Visible = False
        '
        'ExtendedCOSDataGridViewTextBoxColumn
        '
        Me.ExtendedCOSDataGridViewTextBoxColumn.DataPropertyName = "ExtendedCOS"
        Me.ExtendedCOSDataGridViewTextBoxColumn.HeaderText = "ExtendedCOS"
        Me.ExtendedCOSDataGridViewTextBoxColumn.Name = "ExtendedCOSDataGridViewTextBoxColumn"
        Me.ExtendedCOSDataGridViewTextBoxColumn.ReadOnly = True
        Me.ExtendedCOSDataGridViewTextBoxColumn.Visible = False
        '
        'SOLineNumberDataGridViewTextBoxColumn
        '
        Me.SOLineNumberDataGridViewTextBoxColumn.DataPropertyName = "SOLineNumber"
        Me.SOLineNumberDataGridViewTextBoxColumn.HeaderText = "SOLineNumber"
        Me.SOLineNumberDataGridViewTextBoxColumn.Name = "SOLineNumberDataGridViewTextBoxColumn"
        Me.SOLineNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.SOLineNumberDataGridViewTextBoxColumn.Visible = False
        '
        'UnitCostDataGridViewTextBoxColumn
        '
        Me.UnitCostDataGridViewTextBoxColumn.DataPropertyName = "UnitCost"
        Me.UnitCostDataGridViewTextBoxColumn.HeaderText = "UnitCost"
        Me.UnitCostDataGridViewTextBoxColumn.Name = "UnitCostDataGridViewTextBoxColumn"
        Me.UnitCostDataGridViewTextBoxColumn.ReadOnly = True
        Me.UnitCostDataGridViewTextBoxColumn.Visible = False
        '
        'Tax2TotalDataGridViewTextBoxColumn
        '
        Me.Tax2TotalDataGridViewTextBoxColumn.DataPropertyName = "Tax2Total"
        Me.Tax2TotalDataGridViewTextBoxColumn.HeaderText = "Tax2Total"
        Me.Tax2TotalDataGridViewTextBoxColumn.Name = "Tax2TotalDataGridViewTextBoxColumn"
        Me.Tax2TotalDataGridViewTextBoxColumn.ReadOnly = True
        Me.Tax2TotalDataGridViewTextBoxColumn.Visible = False
        '
        'Tax3TotalDataGridViewTextBoxColumn
        '
        Me.Tax3TotalDataGridViewTextBoxColumn.DataPropertyName = "Tax3Total"
        Me.Tax3TotalDataGridViewTextBoxColumn.HeaderText = "Tax3Total"
        Me.Tax3TotalDataGridViewTextBoxColumn.Name = "Tax3TotalDataGridViewTextBoxColumn"
        Me.Tax3TotalDataGridViewTextBoxColumn.ReadOnly = True
        Me.Tax3TotalDataGridViewTextBoxColumn.Visible = False
        '
        'SerialNumberDataGridViewTextBoxColumn
        '
        Me.SerialNumberDataGridViewTextBoxColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberDataGridViewTextBoxColumn.HeaderText = "SerialNumber"
        Me.SerialNumberDataGridViewTextBoxColumn.Name = "SerialNumberDataGridViewTextBoxColumn"
        Me.SerialNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.SerialNumberDataGridViewTextBoxColumn.Visible = False
        '
        'DropshipDataGridViewTextBoxColumn
        '
        Me.DropshipDataGridViewTextBoxColumn.DataPropertyName = "Dropship"
        Me.DropshipDataGridViewTextBoxColumn.HeaderText = "Dropship"
        Me.DropshipDataGridViewTextBoxColumn.Name = "DropshipDataGridViewTextBoxColumn"
        Me.DropshipDataGridViewTextBoxColumn.ReadOnly = True
        Me.DropshipDataGridViewTextBoxColumn.Visible = False
        '
        'SpecialInstructionsDataGridViewTextBoxColumn
        '
        Me.SpecialInstructionsDataGridViewTextBoxColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsDataGridViewTextBoxColumn.HeaderText = "SpecialInstructions"
        Me.SpecialInstructionsDataGridViewTextBoxColumn.Name = "SpecialInstructionsDataGridViewTextBoxColumn"
        Me.SpecialInstructionsDataGridViewTextBoxColumn.ReadOnly = True
        Me.SpecialInstructionsDataGridViewTextBoxColumn.Visible = False
        '
        'ViewPendingShipments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvShipmentLineQuery)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gpxFilterData)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewPendingShipments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Pending Shipments"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxFilterData.ResumeLayout(False)
        Me.gpxFilterData.PerformLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.ShipmentLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShipmentLineQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxFilterData As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByCustomer As System.Windows.Forms.Button
    Friend WithEvents cmdClear1 As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOpenShipmentForm As System.Windows.Forms.Button
    Friend WithEvents cboShipmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ShipmentLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineQueryTableAdapter
    Friend WithEvents dgvShipmentLineQuery As System.Windows.Forms.DataGridView
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboSalesman As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickTicketNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesmanIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethodColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfPalletsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightActualAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertificationTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCOSDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tax2TotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tax3TotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropshipDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
