<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPOHeaders
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxViewTransferOrders = New System.Windows.Forms.GroupBox
        Me.txtTextSearch = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.chkUseDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.POStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvPurchaseOrderHeaders = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightChargeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POHeaderCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipMethodIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipMethodColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseAgentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropShipSalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODropShipCustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipZipCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstTotalWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstTotalBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.POStatusTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.POStatusTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxAddFreight = New System.Windows.Forms.GroupBox
        Me.cmdReprint = New System.Windows.Forms.Button
        Me.cmdAddFreight = New System.Windows.Forms.Button
        Me.txtPOFreight = New System.Windows.Forms.TextBox
        Me.cboPurchaseOrderNumber = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboOpenPOForm = New System.Windows.Forms.Button
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.gpxViewTransferOrders.SuspendLayout()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.POStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.dgvPurchaseOrderHeaders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxAddFreight.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1057, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 20
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxViewTransferOrders
        '
        Me.gpxViewTransferOrders.Controls.Add(Me.txtTextSearch)
        Me.gpxViewTransferOrders.Controls.Add(Me.Label15)
        Me.gpxViewTransferOrders.Controls.Add(Me.cboStatus)
        Me.gpxViewTransferOrders.Controls.Add(Me.Label13)
        Me.gpxViewTransferOrders.Controls.Add(Me.Label14)
        Me.gpxViewTransferOrders.Controls.Add(Me.Label12)
        Me.gpxViewTransferOrders.Controls.Add(Me.chkUseDateRange)
        Me.gpxViewTransferOrders.Controls.Add(Me.dtpEndDate)
        Me.gpxViewTransferOrders.Controls.Add(Me.cboPONumber)
        Me.gpxViewTransferOrders.Controls.Add(Me.dtpBeginDate)
        Me.gpxViewTransferOrders.Controls.Add(Me.Label7)
        Me.gpxViewTransferOrders.Controls.Add(Me.txtVendorName)
        Me.gpxViewTransferOrders.Controls.Add(Me.cboVendorID)
        Me.gpxViewTransferOrders.Controls.Add(Me.Label10)
        Me.gpxViewTransferOrders.Controls.Add(Me.Label8)
        Me.gpxViewTransferOrders.Controls.Add(Me.Label3)
        Me.gpxViewTransferOrders.Controls.Add(Me.cmdClear)
        Me.gpxViewTransferOrders.Controls.Add(Me.cmdView)
        Me.gpxViewTransferOrders.Controls.Add(Me.cboDivisionID)
        Me.gpxViewTransferOrders.Controls.Add(Me.Label2)
        Me.gpxViewTransferOrders.Controls.Add(Me.Label1)
        Me.gpxViewTransferOrders.Location = New System.Drawing.Point(29, 41)
        Me.gpxViewTransferOrders.Name = "gpxViewTransferOrders"
        Me.gpxViewTransferOrders.Size = New System.Drawing.Size(300, 584)
        Me.gpxViewTransferOrders.TabIndex = 0
        Me.gpxViewTransferOrders.TabStop = False
        Me.gpxViewTransferOrders.Text = "View By Filters"
        '
        'txtTextSearch
        '
        Me.txtTextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextSearch.Location = New System.Drawing.Point(105, 347)
        Me.txtTextSearch.Name = "txtTextSearch"
        Me.txtTextSearch.Size = New System.Drawing.Size(182, 20)
        Me.txtTextSearch.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(19, 348)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 20)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Text Filter"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "CLOSED"})
        Me.cboStatus.Location = New System.Drawing.Point(105, 300)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(182, 21)
        Me.cboStatus.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 301)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Status"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 388)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(19, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 46)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkUseDateRange
        '
        Me.chkUseDateRange.AutoSize = True
        Me.chkUseDateRange.Location = New System.Drawing.Point(107, 424)
        Me.chkUseDateRange.Name = "chkUseDateRange"
        Me.chkUseDateRange.Size = New System.Drawing.Size(106, 17)
        Me.chkUseDateRange.TabIndex = 5
        Me.chkUseDateRange.Text = "Use Date Range"
        Me.chkUseDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(104, 502)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpEndDate.TabIndex = 7
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPONumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(105, 253)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(182, 21)
        Me.cboPONumber.TabIndex = 2
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(104, 461)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpBeginDate.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 461)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Begin Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(21, 155)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(267, 70)
        Me.txtVendorName.TabIndex = 2
        Me.txtVendorName.TabStop = False
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(104, 98)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(184, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 254)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "PO #"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 502)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Vendor ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(217, 540)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(142, 540)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 8
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
        Me.cboDivisionID.Location = New System.Drawing.Point(104, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(184, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Vendor Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'POStatusBindingSource
        '
        Me.POStatusBindingSource.DataMember = "POStatus"
        Me.POStatusBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip2.TabIndex = 7
        Me.MenuStrip2.Text = "MenuStrip2"
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
        'dgvPurchaseOrderHeaders
        '
        Me.dgvPurchaseOrderHeaders.AllowUserToAddRows = False
        Me.dgvPurchaseOrderHeaders.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvPurchaseOrderHeaders.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPurchaseOrderHeaders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPurchaseOrderHeaders.AutoGenerateColumns = False
        Me.dgvPurchaseOrderHeaders.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPurchaseOrderHeaders.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPurchaseOrderHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPurchaseOrderHeaders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.PurchaseOrderHeaderKeyColumn, Me.PODateColumn, Me.VendorIDColumn, Me.ProductTotalColumn, Me.SalesTaxColumn, Me.FreightChargeColumn, Me.POTotalColumn, Me.ShipDateColumn, Me.POHeaderCommentColumn, Me.PaymentCodeColumn, Me.ShipMethodIDColumn, Me.ShipMethodColumn, Me.StatusColumn, Me.PurchaseAgentColumn, Me.DropShipSalesOrderNumberColumn, Me.PODropShipCustomerIDColumn, Me.ShipNameColumn, Me.ShipAddress1Column, Me.ShipAddress2Column, Me.ShipCityColumn, Me.ShipStateColumn, Me.ShipZipCodeColumn, Me.ShipCountryColumn, Me.EstTotalWeightColumn, Me.EstTotalBoxesColumn})
        Me.dgvPurchaseOrderHeaders.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.dgvPurchaseOrderHeaders.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvPurchaseOrderHeaders.Location = New System.Drawing.Point(346, 41)
        Me.dgvPurchaseOrderHeaders.Name = "dgvPurchaseOrderHeaders"
        Me.dgvPurchaseOrderHeaders.Size = New System.Drawing.Size(784, 707)
        Me.dgvPurchaseOrderHeaders.TabIndex = 15
        Me.dgvPurchaseOrderHeaders.TabStop = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        Me.DivisionIDColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'PurchaseOrderHeaderKeyColumn
        '
        Me.PurchaseOrderHeaderKeyColumn.DataPropertyName = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn.HeaderText = "PO #"
        Me.PurchaseOrderHeaderKeyColumn.Name = "PurchaseOrderHeaderKeyColumn"
        Me.PurchaseOrderHeaderKeyColumn.ReadOnly = True
        Me.PurchaseOrderHeaderKeyColumn.Width = 65
        '
        'PODateColumn
        '
        Me.PODateColumn.DataPropertyName = "PODate"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.PODateColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PODateColumn.HeaderText = "PO Date"
        Me.PODateColumn.Name = "PODateColumn"
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.ReadOnly = True
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
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.SalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.SalesTaxColumn.HeaderText = "Sales Tax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        '
        'FreightChargeColumn
        '
        Me.FreightChargeColumn.DataPropertyName = "FreightCharge"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.FreightChargeColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.FreightChargeColumn.HeaderText = "Freight Charge"
        Me.FreightChargeColumn.Name = "FreightChargeColumn"
        '
        'POTotalColumn
        '
        Me.POTotalColumn.DataPropertyName = "POTotal"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.POTotalColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.POTotalColumn.HeaderText = "PO Total"
        Me.POTotalColumn.Name = "POTotalColumn"
        Me.POTotalColumn.ReadOnly = True
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ShipDateColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        '
        'POHeaderCommentColumn
        '
        Me.POHeaderCommentColumn.DataPropertyName = "POHeaderComment"
        Me.POHeaderCommentColumn.HeaderText = "Comment"
        Me.POHeaderCommentColumn.Name = "POHeaderCommentColumn"
        '
        'PaymentCodeColumn
        '
        Me.PaymentCodeColumn.DataPropertyName = "PaymentCode"
        Me.PaymentCodeColumn.HeaderText = "Payment Code"
        Me.PaymentCodeColumn.Name = "PaymentCodeColumn"
        '
        'ShipMethodIDColumn
        '
        Me.ShipMethodIDColumn.DataPropertyName = "ShipMethodID"
        Me.ShipMethodIDColumn.HeaderText = "Ship Via"
        Me.ShipMethodIDColumn.Name = "ShipMethodIDColumn"
        '
        'ShipMethodColumn
        '
        Me.ShipMethodColumn.DataPropertyName = "ShipMethod"
        Me.ShipMethodColumn.HeaderText = "Ship Method"
        Me.ShipMethodColumn.Name = "ShipMethodColumn"
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        '
        'PurchaseAgentColumn
        '
        Me.PurchaseAgentColumn.DataPropertyName = "PurchaseAgent"
        Me.PurchaseAgentColumn.HeaderText = "Purchase Agent"
        Me.PurchaseAgentColumn.Name = "PurchaseAgentColumn"
        '
        'DropShipSalesOrderNumberColumn
        '
        Me.DropShipSalesOrderNumberColumn.DataPropertyName = "DropShipSalesOrderNumber"
        Me.DropShipSalesOrderNumberColumn.HeaderText = "SO #"
        Me.DropShipSalesOrderNumberColumn.Name = "DropShipSalesOrderNumberColumn"
        '
        'PODropShipCustomerIDColumn
        '
        Me.PODropShipCustomerIDColumn.DataPropertyName = "PODropShipCustomerID"
        Me.PODropShipCustomerIDColumn.HeaderText = "Customer"
        Me.PODropShipCustomerIDColumn.Name = "PODropShipCustomerIDColumn"
        Me.PODropShipCustomerIDColumn.ReadOnly = True
        '
        'ShipNameColumn
        '
        Me.ShipNameColumn.DataPropertyName = "ShipName"
        Me.ShipNameColumn.HeaderText = "Ship Name"
        Me.ShipNameColumn.Name = "ShipNameColumn"
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
        'ShipZipCodeColumn
        '
        Me.ShipZipCodeColumn.DataPropertyName = "ShipZipCode"
        Me.ShipZipCodeColumn.HeaderText = "Ship Zip Code"
        Me.ShipZipCodeColumn.Name = "ShipZipCodeColumn"
        '
        'ShipCountryColumn
        '
        Me.ShipCountryColumn.DataPropertyName = "ShipCountry"
        Me.ShipCountryColumn.HeaderText = "Ship Country"
        Me.ShipCountryColumn.Name = "ShipCountryColumn"
        '
        'EstTotalWeightColumn
        '
        Me.EstTotalWeightColumn.DataPropertyName = "EstTotalWeight"
        Me.EstTotalWeightColumn.HeaderText = "Est Total Weight"
        Me.EstTotalWeightColumn.Name = "EstTotalWeightColumn"
        '
        'EstTotalBoxesColumn
        '
        Me.EstTotalBoxesColumn.DataPropertyName = "EstTotalBoxes"
        Me.EstTotalBoxesColumn.HeaderText = "Est Total Boxes"
        Me.EstTotalBoxesColumn.Name = "EstTotalBoxesColumn"
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'POStatusTableAdapter
        '
        Me.POStatusTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(980, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 19
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxAddFreight
        '
        Me.gpxAddFreight.Controls.Add(Me.cmdReprint)
        Me.gpxAddFreight.Controls.Add(Me.cmdAddFreight)
        Me.gpxAddFreight.Controls.Add(Me.txtPOFreight)
        Me.gpxAddFreight.Controls.Add(Me.cboPurchaseOrderNumber)
        Me.gpxAddFreight.Controls.Add(Me.Label4)
        Me.gpxAddFreight.Controls.Add(Me.Label6)
        Me.gpxAddFreight.Controls.Add(Me.Label5)
        Me.gpxAddFreight.Location = New System.Drawing.Point(29, 631)
        Me.gpxAddFreight.Name = "gpxAddFreight"
        Me.gpxAddFreight.Size = New System.Drawing.Size(300, 180)
        Me.gpxAddFreight.TabIndex = 10
        Me.gpxAddFreight.TabStop = False
        Me.gpxAddFreight.Text = "Add Freight to Purchase Order"
        '
        'cmdReprint
        '
        Me.cmdReprint.Location = New System.Drawing.Point(211, 125)
        Me.cmdReprint.Name = "cmdReprint"
        Me.cmdReprint.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprint.TabIndex = 14
        Me.cmdReprint.Text = "Re-Print PO"
        Me.cmdReprint.UseVisualStyleBackColor = True
        '
        'cmdAddFreight
        '
        Me.cmdAddFreight.Location = New System.Drawing.Point(136, 125)
        Me.cmdAddFreight.Name = "cmdAddFreight"
        Me.cmdAddFreight.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddFreight.TabIndex = 13
        Me.cmdAddFreight.Text = "Add Freight"
        Me.cmdAddFreight.UseVisualStyleBackColor = True
        '
        'txtPOFreight
        '
        Me.txtPOFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPOFreight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPOFreight.Location = New System.Drawing.Point(102, 60)
        Me.txtPOFreight.Name = "txtPOFreight"
        Me.txtPOFreight.Size = New System.Drawing.Size(180, 20)
        Me.txtPOFreight.TabIndex = 12
        Me.txtPOFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPurchaseOrderNumber
        '
        Me.cboPurchaseOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPurchaseOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPurchaseOrderNumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPurchaseOrderNumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPurchaseOrderNumber.FormattingEnabled = True
        Me.cboPurchaseOrderNumber.Location = New System.Drawing.Point(101, 25)
        Me.cboPurchaseOrderNumber.Name = "cboPurchaseOrderNumber"
        Me.cboPurchaseOrderNumber.Size = New System.Drawing.Size(184, 21)
        Me.cboPurchaseOrderNumber.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Freight Charge"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "PO Number"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(16, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(269, 28)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "To add freight to a closed Purchase Order, you must do it here."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOpenPOForm
        '
        Me.cboOpenPOForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboOpenPOForm.Location = New System.Drawing.Point(346, 771)
        Me.cboOpenPOForm.Name = "cboOpenPOForm"
        Me.cboOpenPOForm.Size = New System.Drawing.Size(71, 40)
        Me.cboOpenPOForm.TabIndex = 15
        Me.cboOpenPOForm.Text = "PO Form"
        Me.cboOpenPOForm.UseVisualStyleBackColor = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(450, 771)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(192, 40)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Opens Purchase Order Form by the selected Purchase Order Number."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(772, 774)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(147, 40)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Changes is the datagrid are automatically saved."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewPOHeaders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.gpxAddFreight)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.dgvPurchaseOrderHeaders)
        Me.Controls.Add(Me.gpxViewTransferOrders)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cboOpenPOForm)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Name = "ViewPOHeaders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Purchase Order Listing"
        Me.gpxViewTransferOrders.ResumeLayout(False)
        Me.gpxViewTransferOrders.PerformLayout()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.POStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.dgvPurchaseOrderHeaders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxAddFreight.ResumeLayout(False)
        Me.gpxAddFreight.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxViewTransferOrders As System.Windows.Forms.GroupBox
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvPurchaseOrderHeaders As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents POStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents POStatusTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.POStatusTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents gpxAddFreight As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddFreight As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents cboOpenPOForm As System.Windows.Forms.Button
    Friend WithEvents cboPurchaseOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtPOFreight As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdReprint As System.Windows.Forms.Button
    Friend WithEvents chkUseDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightChargeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POHeaderCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipMethodIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipMethodColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseAgentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropShipSalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODropShipCustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipZipCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstTotalWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstTotalBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTextSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
