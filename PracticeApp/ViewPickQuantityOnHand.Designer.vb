<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPickQuantityOnHand
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintSinglePickTicketToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintAllPickTicketsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxAPVoucherData = New System.Windows.Forms.GroupBox
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.chkQOH = New System.Windows.Forms.CheckBox
        Me.cboSalesperson = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboPickTicketNumber = New System.Windows.Forms.ComboBox
        Me.PickListLineQOHBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrintSinglePick = New System.Windows.Forms.Button
        Me.cmdPrintAllPicks = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.PickListLineQOHTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListLineQOHTableAdapter
        Me.Label10 = New System.Windows.Forms.Label
        Me.dgvPickListLineQOH = New System.Windows.Forms.DataGridView
        Me.PickListHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesmanIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertificationTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalShipQuantityPendingColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickListLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAPVoucherData.SuspendLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PickListLineQOHBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPickListLineQOH, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem1, Me.PrintSinglePickTicketToolStripMenuItem1, Me.PrintAllPickTicketsToolStripMenuItem1})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem1
        '
        Me.PrintListingToolStripMenuItem1.Name = "PrintListingToolStripMenuItem1"
        Me.PrintListingToolStripMenuItem1.Size = New System.Drawing.Size(179, 22)
        Me.PrintListingToolStripMenuItem1.Text = "Print Listing"
        '
        'PrintSinglePickTicketToolStripMenuItem1
        '
        Me.PrintSinglePickTicketToolStripMenuItem1.Name = "PrintSinglePickTicketToolStripMenuItem1"
        Me.PrintSinglePickTicketToolStripMenuItem1.Size = New System.Drawing.Size(179, 22)
        Me.PrintSinglePickTicketToolStripMenuItem1.Text = "Print Single Pick Ticket"
        '
        'PrintAllPickTicketsToolStripMenuItem1
        '
        Me.PrintAllPickTicketsToolStripMenuItem1.Name = "PrintAllPickTicketsToolStripMenuItem1"
        Me.PrintAllPickTicketsToolStripMenuItem1.Size = New System.Drawing.Size(179, 22)
        Me.PrintAllPickTicketsToolStripMenuItem1.Text = "Print All Pick Tickets"
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
        Me.gpxAPVoucherData.Controls.Add(Me.chkDateRange)
        Me.gpxAPVoucherData.Controls.Add(Me.Label14)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpEndDate)
        Me.gpxAPVoucherData.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPVoucherData.Controls.Add(Me.Label6)
        Me.gpxAPVoucherData.Controls.Add(Me.Label11)
        Me.gpxAPVoucherData.Controls.Add(Me.chkQOH)
        Me.gpxAPVoucherData.Controls.Add(Me.cboSalesperson)
        Me.gpxAPVoucherData.Controls.Add(Me.Label4)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdViewByFilters)
        Me.gpxAPVoucherData.Controls.Add(Me.Label12)
        Me.gpxAPVoucherData.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCustomerName)
        Me.gpxAPVoucherData.Controls.Add(Me.Label7)
        Me.gpxAPVoucherData.Controls.Add(Me.cboCustomerID)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPartDescription)
        Me.gpxAPVoucherData.Controls.Add(Me.cboDivisionID)
        Me.gpxAPVoucherData.Controls.Add(Me.cboPartNumber)
        Me.gpxAPVoucherData.Controls.Add(Me.Label3)
        Me.gpxAPVoucherData.Controls.Add(Me.Label5)
        Me.gpxAPVoucherData.Controls.Add(Me.cmdClear)
        Me.gpxAPVoucherData.Controls.Add(Me.Label1)
        Me.gpxAPVoucherData.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPVoucherData.Name = "gpxAPVoucherData"
        Me.gpxAPVoucherData.Size = New System.Drawing.Size(300, 621)
        Me.gpxAPVoucherData.TabIndex = 0
        Me.gpxAPVoucherData.TabStop = False
        Me.gpxAPVoucherData.Text = "View By Filters"
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(94, 479)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 61
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(14, 455)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 30)
        Me.Label14.TabIndex = 62
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(94, 544)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDate.TabIndex = 58
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(94, 512)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpBeginDate.TabIndex = 57
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 512)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 20)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "Begin Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(14, 544)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 20)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "End Date"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkQOH
        '
        Me.chkQOH.AutoSize = True
        Me.chkQOH.Location = New System.Drawing.Point(94, 419)
        Me.chkQOH.Name = "chkQOH"
        Me.chkQOH.Size = New System.Drawing.Size(122, 17)
        Me.chkQOH.TabIndex = 42
        Me.chkQOH.Text = "QOH > Qty. Ordered"
        Me.chkQOH.UseVisualStyleBackColor = True
        '
        'cboSalesperson
        '
        Me.cboSalesperson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesperson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesperson.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalesperson.DisplayMember = "SalesPersonID"
        Me.cboSalesperson.FormattingEnabled = True
        Me.cboSalesperson.Location = New System.Drawing.Point(94, 324)
        Me.cboSalesperson.Name = "cboSalesperson"
        Me.cboSalesperson.Size = New System.Drawing.Size(194, 21)
        Me.cboSalesperson.TabIndex = 6
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
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 325)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Salesperson"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(137, 578)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 8
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(21, 70)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 40)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(94, 371)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(194, 21)
        Me.cboSalesOrderNumber.TabIndex = 7
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(20, 153)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(263, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(24, 372)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "SO #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(89, 122)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(194, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(20, 230)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(263, 21)
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
        Me.cboDivisionID.Location = New System.Drawing.Point(89, 30)
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
        Me.cboPartNumber.Location = New System.Drawing.Point(89, 199)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(194, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Customer ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Part Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 578)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.cboPickTicketNumber)
        Me.GroupBox3.Controls.Add(Me.cmdPrintSinglePick)
        Me.GroupBox3.Controls.Add(Me.cmdPrintAllPicks)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 668)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 143)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Print Pick Tickets"
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(22, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(186, 30)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Print all Pick Tickets in the datagrid"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(22, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(186, 30)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Print single Pick Ticket (select in grid or from combo box)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPickTicketNumber
        '
        Me.cboPickTicketNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPickTicketNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPickTicketNumber.DataSource = Me.PickListLineQOHBindingSource
        Me.cboPickTicketNumber.DisplayMember = "PickListHeaderKey"
        Me.cboPickTicketNumber.FormattingEnabled = True
        Me.cboPickTicketNumber.Location = New System.Drawing.Point(107, 28)
        Me.cboPickTicketNumber.Name = "cboPickTicketNumber"
        Me.cboPickTicketNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboPickTicketNumber.TabIndex = 13
        '
        'PickListLineQOHBindingSource
        '
        Me.PickListLineQOHBindingSource.DataMember = "PickListLineQOH"
        Me.PickListLineQOHBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrintSinglePick
        '
        Me.cmdPrintSinglePick.Location = New System.Drawing.Point(214, 64)
        Me.cmdPrintSinglePick.Name = "cmdPrintSinglePick"
        Me.cmdPrintSinglePick.Size = New System.Drawing.Size(71, 30)
        Me.cmdPrintSinglePick.TabIndex = 14
        Me.cmdPrintSinglePick.Text = "Print"
        Me.cmdPrintSinglePick.UseVisualStyleBackColor = True
        '
        'cmdPrintAllPicks
        '
        Me.cmdPrintAllPicks.Location = New System.Drawing.Point(214, 100)
        Me.cmdPrintAllPicks.Name = "cmdPrintAllPicks"
        Me.cmdPrintAllPicks.Size = New System.Drawing.Size(71, 30)
        Me.cmdPrintAllPicks.TabIndex = 15
        Me.cmdPrintAllPicks.Text = "Print All"
        Me.cmdPrintAllPicks.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Pick Ticket #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'PickListLineQOHTableAdapter
        '
        Me.PickListLineQOHTableAdapter.ClearBeforeFill = True
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(631, 776)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(245, 30)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Changes made in the datagrid are automatically saved."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvPickListLineQOH
        '
        Me.dgvPickListLineQOH.AllowUserToAddRows = False
        Me.dgvPickListLineQOH.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvPickListLineQOH.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPickListLineQOH.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPickListLineQOH.AutoGenerateColumns = False
        Me.dgvPickListLineQOH.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPickListLineQOH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPickListLineQOH.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PickListHeaderKeyColumn, Me.SalesOrderHeaderKeyColumn, Me.CustomerIDColumn, Me.CustomerPOColumn, Me.ShipDateColumn, Me.ItemIDColumn, Me.DescriptionColumn, Me.QuantityColumn, Me.QuantityOnHandColumn, Me.SalesmanIDColumn, Me.LineCommentColumn, Me.SerialNumberColumn, Me.LineWeightColumn, Me.LineBoxesColumn, Me.PickDateColumn, Me.CertificationTypeColumn, Me.GLCreditAccountColumn, Me.GLDebitAccountColumn, Me.SOLineNumberColumn, Me.PriceColumn, Me.LineStatusColumn, Me.ExtendedAmountColumn, Me.SalesTaxColumn, Me.TotalShipQuantityPendingColumn, Me.DivisionIDColumn, Me.PickListLineKeyColumn})
        Me.dgvPickListLineQOH.DataSource = Me.PickListLineQOHBindingSource
        Me.dgvPickListLineQOH.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvPickListLineQOH.Location = New System.Drawing.Point(344, 41)
        Me.dgvPickListLineQOH.Name = "dgvPickListLineQOH"
        Me.dgvPickListLineQOH.Size = New System.Drawing.Size(786, 708)
        Me.dgvPickListLineQOH.TabIndex = 59
        '
        'PickListHeaderKeyColumn
        '
        Me.PickListHeaderKeyColumn.DataPropertyName = "PickListHeaderKey"
        Me.PickListHeaderKeyColumn.HeaderText = "Pick #"
        Me.PickListHeaderKeyColumn.Name = "PickListHeaderKeyColumn"
        Me.PickListHeaderKeyColumn.ReadOnly = True
        Me.PickListHeaderKeyColumn.Width = 65
        '
        'SalesOrderHeaderKeyColumn
        '
        Me.SalesOrderHeaderKeyColumn.DataPropertyName = "SalesOrderHeaderKey"
        Me.SalesOrderHeaderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderHeaderKeyColumn.Name = "SalesOrderHeaderKeyColumn"
        Me.SalesOrderHeaderKeyColumn.ReadOnly = True
        Me.SalesOrderHeaderKeyColumn.Width = 60
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust. PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.Width = 80
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.Width = 65
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
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.ReadOnly = True
        Me.QuantityColumn.Width = 65
        '
        'QuantityOnHandColumn
        '
        Me.QuantityOnHandColumn.DataPropertyName = "QuantityOnHand"
        Me.QuantityOnHandColumn.HeaderText = "QOH"
        Me.QuantityOnHandColumn.Name = "QuantityOnHandColumn"
        Me.QuantityOnHandColumn.ReadOnly = True
        Me.QuantityOnHandColumn.Width = 65
        '
        'SalesmanIDColumn
        '
        Me.SalesmanIDColumn.DataPropertyName = "SalesmanID"
        Me.SalesmanIDColumn.HeaderText = "Salesman"
        Me.SalesmanIDColumn.Name = "SalesmanIDColumn"
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Serial Number"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        Me.LineWeightColumn.HeaderText = "Line Weight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        '
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        Me.LineBoxesColumn.HeaderText = "Line Boxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        '
        'PickDateColumn
        '
        Me.PickDateColumn.DataPropertyName = "PickDate"
        Me.PickDateColumn.HeaderText = "Pick Date"
        Me.PickDateColumn.Name = "PickDateColumn"
        Me.PickDateColumn.Visible = False
        '
        'CertificationTypeColumn
        '
        Me.CertificationTypeColumn.DataPropertyName = "CertificationType"
        Me.CertificationTypeColumn.HeaderText = "Cert. Type"
        Me.CertificationTypeColumn.Name = "CertificationTypeColumn"
        Me.CertificationTypeColumn.Visible = False
        '
        'GLCreditAccountColumn
        '
        Me.GLCreditAccountColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountColumn.HeaderText = "Credit Acct."
        Me.GLCreditAccountColumn.Name = "GLCreditAccountColumn"
        Me.GLCreditAccountColumn.Visible = False
        '
        'GLDebitAccountColumn
        '
        Me.GLDebitAccountColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountColumn.HeaderText = "Debit Acct."
        Me.GLDebitAccountColumn.Name = "GLDebitAccountColumn"
        Me.GLDebitAccountColumn.Visible = False
        '
        'SOLineNumberColumn
        '
        Me.SOLineNumberColumn.DataPropertyName = "SOLineNumber"
        Me.SOLineNumberColumn.HeaderText = "SO Line #"
        Me.SOLineNumberColumn.Name = "SOLineNumberColumn"
        Me.SOLineNumberColumn.Visible = False
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.Visible = False
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.Visible = False
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "Ext. Amt."
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Visible = False
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "Sales Tax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.Visible = False
        '
        'TotalShipQuantityPendingColumn
        '
        Me.TotalShipQuantityPendingColumn.DataPropertyName = "TotalShipQuantityPending"
        Me.TotalShipQuantityPendingColumn.HeaderText = "Qty. Pending"
        Me.TotalShipQuantityPendingColumn.Name = "TotalShipQuantityPendingColumn"
        Me.TotalShipQuantityPendingColumn.ReadOnly = True
        Me.TotalShipQuantityPendingColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division ID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'PickListLineKeyColumn
        '
        Me.PickListLineKeyColumn.DataPropertyName = "PickListLineKey"
        Me.PickListLineKeyColumn.HeaderText = "Line #"
        Me.PickListLineKeyColumn.Name = "PickListLineKeyColumn"
        Me.PickListLineKeyColumn.Visible = False
        '
        'ViewPickQuantityOnHand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvPickListLineQOH)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.gpxAPVoucherData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewPickQuantityOnHand"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Quantity On Hand (Committed Lines for Picking)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAPVoucherData.ResumeLayout(False)
        Me.gpxAPVoucherData.PerformLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.PickListLineQOHBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPickListLineQOH, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdViewByCustomer As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintSinglePick As System.Windows.Forms.Button
    Friend WithEvents cmdPrintAllPicks As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboPickTicketNumber As System.Windows.Forms.ComboBox
    Friend WithEvents PrintListingToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintSinglePickTicketToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintAllPickTicketsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cboSalesperson As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents PickListLineQOHBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PickListLineQOHTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListLineQOHTableAdapter
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkQOH As System.Windows.Forms.CheckBox
    Friend WithEvents dgvPickListLineQOH As System.Windows.Forms.DataGridView
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PickListHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesmanIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertificationTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalShipQuantityPendingColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickListLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
