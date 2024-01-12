<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPickTickets
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
        Me.gpxViewPickTickets = New System.Windows.Forms.GroupBox
        Me.txtShipVia = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboSalespersonID = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeletePickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClosePickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReOpenPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewAllPickTicketsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLastThreeYearsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.dgvPickListHeader = New System.Windows.Forms.DataGridView
        Me.PickListHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PickListHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
        Me.SalesOrderHeaderTableBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdReprint = New System.Windows.Forms.Button
        Me.cboPickTicketNumber = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.lblMessage1 = New System.Windows.Forms.Label
        Me.lblMessage2 = New System.Windows.Forms.Label
        Me.cmdPrintAll = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblOpenOrders = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickListHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RunningCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderHeaderColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingMethodColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesmanIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdditionalShipToColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ThirdPartyShipperColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipEmailColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickTicketType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gpxViewPickTickets.SuspendLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvPickListHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpxViewPickTickets
        '
        Me.gpxViewPickTickets.Controls.Add(Me.txtShipVia)
        Me.gpxViewPickTickets.Controls.Add(Me.Label10)
        Me.gpxViewPickTickets.Controls.Add(Me.cboSalespersonID)
        Me.gpxViewPickTickets.Controls.Add(Me.Label9)
        Me.gpxViewPickTickets.Controls.Add(Me.cboStatus)
        Me.gpxViewPickTickets.Controls.Add(Me.Label8)
        Me.gpxViewPickTickets.Controls.Add(Me.chkDateRange)
        Me.gpxViewPickTickets.Controls.Add(Me.Label14)
        Me.gpxViewPickTickets.Controls.Add(Me.txtCustomerPO)
        Me.gpxViewPickTickets.Controls.Add(Me.Label15)
        Me.gpxViewPickTickets.Controls.Add(Me.dtpEndDate)
        Me.gpxViewPickTickets.Controls.Add(Me.cboCustomerName)
        Me.gpxViewPickTickets.Controls.Add(Me.cboCustomerID)
        Me.gpxViewPickTickets.Controls.Add(Me.dtpBeginDate)
        Me.gpxViewPickTickets.Controls.Add(Me.Label4)
        Me.gpxViewPickTickets.Controls.Add(Me.Label3)
        Me.gpxViewPickTickets.Controls.Add(Me.Label5)
        Me.gpxViewPickTickets.Controls.Add(Me.cmdClear)
        Me.gpxViewPickTickets.Controls.Add(Me.Label7)
        Me.gpxViewPickTickets.Controls.Add(Me.cmdView)
        Me.gpxViewPickTickets.Controls.Add(Me.cboDivisionID)
        Me.gpxViewPickTickets.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxViewPickTickets.Controls.Add(Me.Label1)
        Me.gpxViewPickTickets.Controls.Add(Me.Label2)
        Me.gpxViewPickTickets.Location = New System.Drawing.Point(29, 41)
        Me.gpxViewPickTickets.Name = "gpxViewPickTickets"
        Me.gpxViewPickTickets.Size = New System.Drawing.Size(300, 568)
        Me.gpxViewPickTickets.TabIndex = 0
        Me.gpxViewPickTickets.TabStop = False
        Me.gpxViewPickTickets.Text = "View By Filters"
        '
        'txtShipVia
        '
        Me.txtShipVia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipVia.Location = New System.Drawing.Point(96, 358)
        Me.txtShipVia.Name = "txtShipVia"
        Me.txtShipVia.Size = New System.Drawing.Size(189, 20)
        Me.txtShipVia.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 359)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 20)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "Ship Via"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalespersonID
        '
        Me.cboSalespersonID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalespersonID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalespersonID.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalespersonID.DisplayMember = "SalesPersonID"
        Me.cboSalespersonID.FormattingEnabled = True
        Me.cboSalespersonID.Location = New System.Drawing.Point(96, 270)
        Me.cboSalespersonID.Name = "cboSalespersonID"
        Me.cboSalespersonID.Size = New System.Drawing.Size(189, 21)
        Me.cboSalespersonID.TabIndex = 5
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
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 271)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 20)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Salesperson"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "CLOSED"})
        Me.cboStatus.Location = New System.Drawing.Point(96, 314)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(189, 21)
        Me.cboStatus.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 315)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 20)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Order Status"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(93, 425)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 8
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(16, 398)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 30)
        Me.Label14.TabIndex = 56
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.Location = New System.Drawing.Point(96, 227)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(189, 20)
        Me.txtCustomerPO.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(18, 61)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(267, 40)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(96, 487)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(19, 135)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(266, 21)
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
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(96, 104)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(189, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(96, 455)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 455)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Begin Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Customer ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 487)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "End Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 522)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 227)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Customer PO#"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(137, 522)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 11
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(96, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(189, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(96, 183)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboSalesOrderNumber.TabIndex = 3
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Sales Order #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeletePickTicketToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'DeletePickTicketToolStripMenuItem
        '
        Me.DeletePickTicketToolStripMenuItem.Name = "DeletePickTicketToolStripMenuItem"
        Me.DeletePickTicketToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.DeletePickTicketToolStripMenuItem.Text = "Delete Pick Ticket"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClosePickTicketToolStripMenuItem, Me.ReOpenPickTicketToolStripMenuItem, Me.ViewAllPickTicketsToolStripMenuItem, Me.ViewLastThreeYearsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ClosePickTicketToolStripMenuItem
        '
        Me.ClosePickTicketToolStripMenuItem.Name = "ClosePickTicketToolStripMenuItem"
        Me.ClosePickTicketToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ClosePickTicketToolStripMenuItem.Text = "Close Pick Ticket"
        '
        'ReOpenPickTicketToolStripMenuItem
        '
        Me.ReOpenPickTicketToolStripMenuItem.Name = "ReOpenPickTicketToolStripMenuItem"
        Me.ReOpenPickTicketToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ReOpenPickTicketToolStripMenuItem.Text = "Re-Open Pick Ticket"
        '
        'ViewAllPickTicketsToolStripMenuItem
        '
        Me.ViewAllPickTicketsToolStripMenuItem.CheckOnClick = True
        Me.ViewAllPickTicketsToolStripMenuItem.Name = "ViewAllPickTicketsToolStripMenuItem"
        Me.ViewAllPickTicketsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ViewAllPickTicketsToolStripMenuItem.Text = "View All Pick Tickets"
        '
        'ViewLastThreeYearsToolStripMenuItem
        '
        Me.ViewLastThreeYearsToolStripMenuItem.Checked = True
        Me.ViewLastThreeYearsToolStripMenuItem.CheckOnClick = True
        Me.ViewLastThreeYearsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ViewLastThreeYearsToolStripMenuItem.Name = "ViewLastThreeYearsToolStripMenuItem"
        Me.ViewLastThreeYearsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ViewLastThreeYearsToolStripMenuItem.Text = "View Last Three Years"
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(984, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 20
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1061, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 21
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'dgvPickListHeader
        '
        Me.dgvPickListHeader.AllowUserToAddRows = False
        Me.dgvPickListHeader.AllowUserToDeleteRows = False
        Me.dgvPickListHeader.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvPickListHeader.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPickListHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPickListHeader.AutoGenerateColumns = False
        Me.dgvPickListHeader.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPickListHeader.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPickListHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPickListHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipDateColumn, Me.PickListHeaderKeyColumn, Me.RunningCountColumn, Me.SalesOrderHeaderColumn, Me.CustomerIDColumn, Me.CustomerPOColumn, Me.ShipViaColumn, Me.ShippingMethodColumn, Me.CommentColumn, Me.SalesmanIDColumn, Me.SpecialInstructionsColumn, Me.PRONumberColumn, Me.AdditionalShipToColumn, Me.PLStatusColumn, Me.DivisionIDColumn, Me.BatchNumberColumn, Me.PickDateColumn, Me.ThirdPartyShipperColumn, Me.ShipToNameColumn, Me.ShipToAddress1Column, Me.ShipToAddress2Column, Me.ShipToCityColumn, Me.ShipToStateColumn, Me.ShipToZipColumn, Me.ShipToCountryColumn, Me.ShipEmailColumn, Me.ShippingAccountColumn, Me.PickTicketType})
        Me.dgvPickListHeader.DataSource = Me.PickListHeaderTableBindingSource
        Me.dgvPickListHeader.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvPickListHeader.Location = New System.Drawing.Point(344, 41)
        Me.dgvPickListHeader.Name = "dgvPickListHeader"
        Me.dgvPickListHeader.Size = New System.Drawing.Size(788, 718)
        Me.dgvPickListHeader.TabIndex = 19
        '
        'PickListHeaderTableBindingSource
        '
        Me.PickListHeaderTableBindingSource.DataMember = "PickListHeaderTable"
        Me.PickListHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PickListHeaderTableTableAdapter
        '
        Me.PickListHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableBindingSource1
        '
        Me.SalesOrderHeaderTableBindingSource1.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdReprint
        '
        Me.cmdReprint.Location = New System.Drawing.Point(137, 62)
        Me.cmdReprint.Name = "cmdReprint"
        Me.cmdReprint.Size = New System.Drawing.Size(71, 30)
        Me.cmdReprint.TabIndex = 15
        Me.cmdReprint.Text = "Re-Print"
        Me.cmdReprint.UseVisualStyleBackColor = True
        '
        'cboPickTicketNumber
        '
        Me.cboPickTicketNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPickTicketNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPickTicketNumber.DataSource = Me.PickListHeaderTableBindingSource
        Me.cboPickTicketNumber.DisplayMember = "PickListHeaderKey"
        Me.cboPickTicketNumber.FormattingEnabled = True
        Me.cboPickTicketNumber.Location = New System.Drawing.Point(96, 28)
        Me.cboPickTicketNumber.Name = "cboPickTicketNumber"
        Me.cboPickTicketNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboPickTicketNumber.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(15, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Pick Ticket #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(214, 62)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 30)
        Me.cmdDelete.TabIndex = 16
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboPickTicketNumber)
        Me.GroupBox2.Controls.Add(Me.cmdReprint)
        Me.GroupBox2.Controls.Add(Me.cmdDelete)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 615)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 111)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reprint or Delete Pick Ticket"
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'lblMessage1
        '
        Me.lblMessage1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage1.ForeColor = System.Drawing.Color.Blue
        Me.lblMessage1.Location = New System.Drawing.Point(441, 776)
        Me.lblMessage1.Name = "lblMessage1"
        Me.lblMessage1.Size = New System.Drawing.Size(151, 30)
        Me.lblMessage1.TabIndex = 57
        Me.lblMessage1.Text = "Changes made in the datagrid are automatically saved."
        Me.lblMessage1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMessage2
        '
        Me.lblMessage2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage2.ForeColor = System.Drawing.Color.Blue
        Me.lblMessage2.Location = New System.Drawing.Point(627, 776)
        Me.lblMessage2.Name = "lblMessage2"
        Me.lblMessage2.Size = New System.Drawing.Size(151, 30)
        Me.lblMessage2.TabIndex = 58
        Me.lblMessage2.Text = "Changes made will update the existing Packing Slip."
        Me.lblMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintAll
        '
        Me.cmdPrintAll.Location = New System.Drawing.Point(214, 26)
        Me.cmdPrintAll.Name = "cmdPrintAll"
        Me.cmdPrintAll.Size = New System.Drawing.Size(71, 30)
        Me.cmdPrintAll.TabIndex = 18
        Me.cmdPrintAll.Text = "Print All"
        Me.cmdPrintAll.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblOpenOrders)
        Me.GroupBox1.Controls.Add(Me.cmdPrintAll)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 732)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 74)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Print Selected Pick Tickets from Datagrid"
        '
        'lblOpenOrders
        '
        Me.lblOpenOrders.ForeColor = System.Drawing.Color.Red
        Me.lblOpenOrders.Location = New System.Drawing.Point(6, 26)
        Me.lblOpenOrders.Name = "lblOpenOrders"
        Me.lblOpenOrders.Size = New System.Drawing.Size(202, 23)
        Me.lblOpenOrders.TabIndex = 58
        Me.lblOpenOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.Width = 65
        '
        'PickListHeaderKeyColumn
        '
        Me.PickListHeaderKeyColumn.DataPropertyName = "PickListHeaderKey"
        Me.PickListHeaderKeyColumn.FillWeight = 14.21027!
        Me.PickListHeaderKeyColumn.HeaderText = "Pick List #"
        Me.PickListHeaderKeyColumn.Name = "PickListHeaderKeyColumn"
        Me.PickListHeaderKeyColumn.ReadOnly = True
        Me.PickListHeaderKeyColumn.Width = 65
        '
        'RunningCountColumn
        '
        Me.RunningCountColumn.DataPropertyName = "RunningCount"
        Me.RunningCountColumn.HeaderText = "Count #"
        Me.RunningCountColumn.Name = "RunningCountColumn"
        Me.RunningCountColumn.Visible = False
        '
        'SalesOrderHeaderColumn
        '
        Me.SalesOrderHeaderColumn.DataPropertyName = "SalesOrderHeaderKey"
        Me.SalesOrderHeaderColumn.FillWeight = 62.97735!
        Me.SalesOrderHeaderColumn.HeaderText = "SO #"
        Me.SalesOrderHeaderColumn.Name = "SalesOrderHeaderColumn"
        Me.SalesOrderHeaderColumn.ReadOnly = True
        Me.SalesOrderHeaderColumn.Width = 65
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.FillWeight = 257.1554!
        Me.CustomerIDColumn.HeaderText = "Customer ID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.FillWeight = 507.6141!
        Me.CustomerPOColumn.HeaderText = "Customer PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.Width = 80
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.FillWeight = 14.21027!
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        Me.ShipViaColumn.Width = 80
        '
        'ShippingMethodColumn
        '
        Me.ShippingMethodColumn.DataPropertyName = "ShippingMethod"
        Me.ShippingMethodColumn.HeaderText = "Ship Method"
        Me.ShippingMethodColumn.Name = "ShippingMethodColumn"
        Me.ShippingMethodColumn.ReadOnly = True
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'SalesmanIDColumn
        '
        Me.SalesmanIDColumn.DataPropertyName = "SalesmanID"
        Me.SalesmanIDColumn.FillWeight = 14.21027!
        Me.SalesmanIDColumn.HeaderText = "Salesman"
        Me.SalesmanIDColumn.Name = "SalesmanIDColumn"
        Me.SalesmanIDColumn.Width = 80
        '
        'SpecialInstructionsColumn
        '
        Me.SpecialInstructionsColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsColumn.FillWeight = 14.21027!
        Me.SpecialInstructionsColumn.HeaderText = "Special Instructions"
        Me.SpecialInstructionsColumn.Name = "SpecialInstructionsColumn"
        '
        'PRONumberColumn
        '
        Me.PRONumberColumn.DataPropertyName = "PRONumber"
        Me.PRONumberColumn.FillWeight = 14.21027!
        Me.PRONumberColumn.HeaderText = "PRO #"
        Me.PRONumberColumn.Name = "PRONumberColumn"
        Me.PRONumberColumn.Width = 80
        '
        'AdditionalShipToColumn
        '
        Me.AdditionalShipToColumn.DataPropertyName = "AdditionalShipTo"
        Me.AdditionalShipToColumn.FillWeight = 14.21027!
        Me.AdditionalShipToColumn.HeaderText = "Additional Ship To"
        Me.AdditionalShipToColumn.Name = "AdditionalShipToColumn"
        Me.AdditionalShipToColumn.ReadOnly = True
        Me.AdditionalShipToColumn.Width = 80
        '
        'PLStatusColumn
        '
        Me.PLStatusColumn.DataPropertyName = "PLStatus"
        Me.PLStatusColumn.HeaderText = "Status"
        Me.PLStatusColumn.Name = "PLStatusColumn"
        Me.PLStatusColumn.ReadOnly = True
        Me.PLStatusColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division ID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "Batch Number"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.ReadOnly = True
        Me.BatchNumberColumn.Visible = False
        '
        'PickDateColumn
        '
        Me.PickDateColumn.DataPropertyName = "PickDate"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PickDateColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PickDateColumn.FillWeight = 86.99143!
        Me.PickDateColumn.HeaderText = "Pick Date"
        Me.PickDateColumn.Name = "PickDateColumn"
        Me.PickDateColumn.Width = 65
        '
        'ThirdPartyShipperColumn
        '
        Me.ThirdPartyShipperColumn.DataPropertyName = "ThirdPartyShipper"
        Me.ThirdPartyShipperColumn.HeaderText = "3rd Party"
        Me.ThirdPartyShipperColumn.Name = "ThirdPartyShipperColumn"
        '
        'ShipToNameColumn
        '
        Me.ShipToNameColumn.DataPropertyName = "ShipToName"
        Me.ShipToNameColumn.HeaderText = "Ship To Name"
        Me.ShipToNameColumn.Name = "ShipToNameColumn"
        '
        'ShipToAddress1Column
        '
        Me.ShipToAddress1Column.DataPropertyName = "ShipToAddress1"
        Me.ShipToAddress1Column.HeaderText = "Ship To Address1"
        Me.ShipToAddress1Column.Name = "ShipToAddress1Column"
        '
        'ShipToAddress2Column
        '
        Me.ShipToAddress2Column.DataPropertyName = "ShipToAddress2"
        Me.ShipToAddress2Column.HeaderText = "Ship To Address2"
        Me.ShipToAddress2Column.Name = "ShipToAddress2Column"
        '
        'ShipToCityColumn
        '
        Me.ShipToCityColumn.DataPropertyName = "ShipToCity"
        Me.ShipToCityColumn.HeaderText = "Ship To City"
        Me.ShipToCityColumn.Name = "ShipToCityColumn"
        '
        'ShipToStateColumn
        '
        Me.ShipToStateColumn.DataPropertyName = "ShipToState"
        Me.ShipToStateColumn.HeaderText = "Ship To State"
        Me.ShipToStateColumn.Name = "ShipToStateColumn"
        '
        'ShipToZipColumn
        '
        Me.ShipToZipColumn.DataPropertyName = "ShipToZip"
        Me.ShipToZipColumn.HeaderText = "Ship To Zip"
        Me.ShipToZipColumn.Name = "ShipToZipColumn"
        '
        'ShipToCountryColumn
        '
        Me.ShipToCountryColumn.DataPropertyName = "ShipToCountry"
        Me.ShipToCountryColumn.HeaderText = "Ship To Country"
        Me.ShipToCountryColumn.Name = "ShipToCountryColumn"
        '
        'ShipEmailColumn
        '
        Me.ShipEmailColumn.DataPropertyName = "ShipEmail"
        Me.ShipEmailColumn.HeaderText = "Ship Email"
        Me.ShipEmailColumn.Name = "ShipEmailColumn"
        '
        'ShippingAccountColumn
        '
        Me.ShippingAccountColumn.DataPropertyName = "ShippingAccount"
        Me.ShippingAccountColumn.HeaderText = "Shipping Account"
        Me.ShippingAccountColumn.Name = "ShippingAccountColumn"
        '
        'PickTicketType
        '
        Me.PickTicketType.DataPropertyName = "PickTicketType"
        Me.PickTicketType.HeaderText = "PT Type?"
        Me.PickTicketType.Name = "PickTicketType"
        Me.PickTicketType.ReadOnly = True
        Me.PickTicketType.Width = 80
        '
        'ViewPickTickets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblMessage2)
        Me.Controls.Add(Me.lblMessage1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvPickListHeader)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxViewPickTickets)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewPickTickets"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Pick Ticket Listing"
        Me.gpxViewPickTickets.ResumeLayout(False)
        Me.gpxViewPickTickets.PerformLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvPickListHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxViewPickTickets As System.Windows.Forms.GroupBox
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents dgvPickListHeader As System.Windows.Forms.DataGridView
    Friend WithEvents PickListHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PickListHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
    Friend WithEvents cmdReprint As System.Windows.Forms.Button
    Friend WithEvents cboPickTicketNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SalesOrderHeaderTableBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DeletePickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboSalespersonID As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents lblMessage1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintAll As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblOpenOrders As System.Windows.Forms.Label
    Friend WithEvents ClosePickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReOpenPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage2 As System.Windows.Forms.Label
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents txtShipVia As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ViewAllPickTicketsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLastThreeYearsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickListHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RunningCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderHeaderColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethodColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesmanIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdditionalShipToColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ThirdPartyShipperColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipEmailColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickTicketType As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
