<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPurchaseLines
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
        Me.Label15 = New System.Windows.Forms.Label
        Me.chkOpenAndPastDue = New System.Windows.Forms.CheckBox
        Me.cboPurchaseLine = New System.Windows.Forms.ComboBox
        Me.PurchaseProductLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboSONumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboPurchaseOrderNumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboLineStatus = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.PurchaseOrderQuantityStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPOListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdOpenPurchaseOrder = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.PurchaseOrderQuantityStatusTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
        Me.dgvPurchaseLines = New System.Windows.Forms.DataGridView
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODropShipCustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.cboPOLookup = New System.Windows.Forms.ComboBox
        Me.PurchaseProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.cmdGroup = New System.Windows.Forms.Button
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.cmdGroupByVendor = New System.Windows.Forms.Button
        Me.gpxQuotationFilter.SuspendLayout()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvPurchaseLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxQuotationFilter
        '
        Me.gpxQuotationFilter.Controls.Add(Me.Label15)
        Me.gpxQuotationFilter.Controls.Add(Me.chkOpenAndPastDue)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPurchaseLine)
        Me.gpxQuotationFilter.Controls.Add(Me.Label11)
        Me.gpxQuotationFilter.Controls.Add(Me.cboItemClass)
        Me.gpxQuotationFilter.Controls.Add(Me.Label13)
        Me.gpxQuotationFilter.Controls.Add(Me.txtTextFilter)
        Me.gpxQuotationFilter.Controls.Add(Me.Label10)
        Me.gpxQuotationFilter.Controls.Add(Me.cboSONumber)
        Me.gpxQuotationFilter.Controls.Add(Me.Label7)
        Me.gpxQuotationFilter.Controls.Add(Me.Label14)
        Me.gpxQuotationFilter.Controls.Add(Me.chkDateRange)
        Me.gpxQuotationFilter.Controls.Add(Me.Label12)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpEndDate)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPartDescription)
        Me.gpxQuotationFilter.Controls.Add(Me.Label9)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPurchaseOrderNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpBeginDate)
        Me.gpxQuotationFilter.Controls.Add(Me.Label8)
        Me.gpxQuotationFilter.Controls.Add(Me.txtVendorName)
        Me.gpxQuotationFilter.Controls.Add(Me.Label1)
        Me.gpxQuotationFilter.Controls.Add(Me.cboLineStatus)
        Me.gpxQuotationFilter.Controls.Add(Me.Label6)
        Me.gpxQuotationFilter.Controls.Add(Me.cboVendorID)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPartNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.Label3)
        Me.gpxQuotationFilter.Controls.Add(Me.cboDivisionID)
        Me.gpxQuotationFilter.Controls.Add(Me.Label5)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdClear)
        Me.gpxQuotationFilter.Controls.Add(Me.Label4)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdView)
        Me.gpxQuotationFilter.Location = New System.Drawing.Point(29, 41)
        Me.gpxQuotationFilter.Name = "gpxQuotationFilter"
        Me.gpxQuotationFilter.Size = New System.Drawing.Size(300, 775)
        Me.gpxQuotationFilter.TabIndex = 0
        Me.gpxQuotationFilter.TabStop = False
        Me.gpxQuotationFilter.Text = "View By Filters"
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(111, 533)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(174, 33)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "View open PO Lines that are past the expected date."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkOpenAndPastDue
        '
        Me.chkOpenAndPastDue.AutoSize = True
        Me.chkOpenAndPastDue.Location = New System.Drawing.Point(90, 533)
        Me.chkOpenAndPastDue.Name = "chkOpenAndPastDue"
        Me.chkOpenAndPastDue.Size = New System.Drawing.Size(15, 14)
        Me.chkOpenAndPastDue.TabIndex = 50
        Me.chkOpenAndPastDue.UseVisualStyleBackColor = True
        '
        'cboPurchaseLine
        '
        Me.cboPurchaseLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPurchaseLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPurchaseLine.DataSource = Me.PurchaseProductLineBindingSource
        Me.cboPurchaseLine.DisplayMember = "PurchaseProductLineID"
        Me.cboPurchaseLine.FormattingEnabled = True
        Me.cboPurchaseLine.Location = New System.Drawing.Point(92, 407)
        Me.cboPurchaseLine.Name = "cboPurchaseLine"
        Me.cboPurchaseLine.Size = New System.Drawing.Size(194, 21)
        Me.cboPurchaseLine.TabIndex = 8
        '
        'PurchaseProductLineBindingSource
        '
        Me.PurchaseProductLineBindingSource.DataMember = "PurchaseProductLine"
        Me.PurchaseProductLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(18, 408)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 20)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Purch. Line"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(91, 449)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(194, 21)
        Me.cboItemClass.TabIndex = 9
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 450)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 20)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Item Class"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.Location = New System.Drawing.Point(90, 491)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(194, 20)
        Me.txtTextFilter.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 492)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 20)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Text Filter"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSONumber
        '
        Me.cboSONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSONumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSONumber.DisplayMember = "SalesOrderKey"
        Me.cboSONumber.FormattingEnabled = True
        Me.cboSONumber.Location = New System.Drawing.Point(91, 323)
        Me.cboSONumber.Name = "cboSONumber"
        Me.cboSONumber.Size = New System.Drawing.Size(194, 21)
        Me.cboSONumber.TabIndex = 6
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(18, 324)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 20)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "SO #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(18, 589)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(111, 625)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 11
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(18, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(267, 40)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(108, 689)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpEndDate.TabIndex = 13
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(18, 239)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(267, 21)
        Me.cboPartDescription.TabIndex = 4
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 689)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "End Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPurchaseOrderNumber
        '
        Me.cboPurchaseOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPurchaseOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPurchaseOrderNumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPurchaseOrderNumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPurchaseOrderNumber.FormattingEnabled = True
        Me.cboPurchaseOrderNumber.Location = New System.Drawing.Point(91, 281)
        Me.cboPurchaseOrderNumber.Name = "cboPurchaseOrderNumber"
        Me.cboPurchaseOrderNumber.Size = New System.Drawing.Size(194, 21)
        Me.cboPurchaseOrderNumber.TabIndex = 5
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(108, 656)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpBeginDate.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 656)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Begin Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(18, 134)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(267, 49)
        Me.txtVendorName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 282)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "PO #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLineStatus
        '
        Me.cboLineStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLineStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLineStatus.FormattingEnabled = True
        Me.cboLineStatus.Items.AddRange(New Object() {"OPEN", "CLOSED", "DROPSHIP"})
        Me.cboLineStatus.Location = New System.Drawing.Point(90, 365)
        Me.cboLineStatus.Name = "cboLineStatus"
        Me.cboLineStatus.Size = New System.Drawing.Size(194, 21)
        Me.cboLineStatus.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 366)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Line Status"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(85, 104)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(200, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(56, 209)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(229, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Part #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(85, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(200, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Vendor ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(216, 730)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(141, 730)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 14
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'PurchaseOrderQuantityStatusBindingSource
        '
        Me.PurchaseOrderQuantityStatusBindingSource.DataMember = "PurchaseOrderQuantityStatus"
        Me.PurchaseOrderQuantityStatusBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 16
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
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintPOListingToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'PrintPOListingToolStripMenuItem
        '
        Me.PrintPOListingToolStripMenuItem.Name = "PrintPOListingToolStripMenuItem"
        Me.PrintPOListingToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.PrintPOListingToolStripMenuItem.Text = "Print PO Listing"
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
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(425, 784)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(274, 24)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Opens PO Form and closes this form."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenPurchaseOrder
        '
        Me.cmdOpenPurchaseOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenPurchaseOrder.Location = New System.Drawing.Point(348, 776)
        Me.cmdOpenPurchaseOrder.Name = "cmdOpenPurchaseOrder"
        Me.cmdOpenPurchaseOrder.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenPurchaseOrder.TabIndex = 16
        Me.cmdOpenPurchaseOrder.Text = "PO Form"
        Me.cmdOpenPurchaseOrder.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 776)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 776)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderQuantityStatusTableAdapter
        '
        Me.PurchaseOrderQuantityStatusTableAdapter.ClearBeforeFill = True
        '
        'dgvPurchaseLines
        '
        Me.dgvPurchaseLines.AllowUserToAddRows = False
        Me.dgvPurchaseLines.AllowUserToDeleteRows = False
        Me.dgvPurchaseLines.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvPurchaseLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPurchaseLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPurchaseLines.AutoGenerateColumns = False
        Me.dgvPurchaseLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPurchaseLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPurchaseLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPurchaseLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VendorIDColumn, Me.DivisionIDColumn, Me.PODateColumn, Me.PurchaseOrderHeaderKeyColumn, Me.PurchaseOrderLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.OrderQuantityColumn, Me.POQuantityReceivedColumn, Me.POQuantityOpenColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.LineStatusColumn, Me.LineCommentColumn, Me.ShipDateColumn, Me.PODropShipCustomerIDColumn, Me.StatusColumn, Me.SelectForInvoiceColumn, Me.CreditGLAccountColumn, Me.DebitGLAccountColumn, Me.ReceivedAmountColumn, Me.OpenAmountColumn})
        Me.dgvPurchaseLines.DataSource = Me.PurchaseOrderQuantityStatusBindingSource
        Me.dgvPurchaseLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvPurchaseLines.Location = New System.Drawing.Point(350, 41)
        Me.dgvPurchaseLines.Name = "dgvPurchaseLines"
        Me.dgvPurchaseLines.Size = New System.Drawing.Size(782, 729)
        Me.dgvPurchaseLines.TabIndex = 27
        Me.dgvPurchaseLines.TabStop = False
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        Me.DivisionIDColumn.Width = 80
        '
        'PODateColumn
        '
        Me.PODateColumn.DataPropertyName = "PODate"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PODateColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PODateColumn.HeaderText = "PO Date"
        Me.PODateColumn.Name = "PODateColumn"
        Me.PODateColumn.Width = 80
        '
        'PurchaseOrderHeaderKeyColumn
        '
        Me.PurchaseOrderHeaderKeyColumn.DataPropertyName = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn.HeaderText = "PO #"
        Me.PurchaseOrderHeaderKeyColumn.Name = "PurchaseOrderHeaderKeyColumn"
        Me.PurchaseOrderHeaderKeyColumn.Width = 80
        '
        'PurchaseOrderLineNumberColumn
        '
        Me.PurchaseOrderLineNumberColumn.DataPropertyName = "PurchaseOrderLineNumber"
        Me.PurchaseOrderLineNumberColumn.HeaderText = "Line #"
        Me.PurchaseOrderLineNumberColumn.Name = "PurchaseOrderLineNumberColumn"
        Me.PurchaseOrderLineNumberColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.Width = 120
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 150
        '
        'OrderQuantityColumn
        '
        Me.OrderQuantityColumn.DataPropertyName = "OrderQuantity"
        DataGridViewCellStyle3.NullValue = "0"
        Me.OrderQuantityColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.OrderQuantityColumn.HeaderText = "Qty Ordered"
        Me.OrderQuantityColumn.Name = "OrderQuantityColumn"
        Me.OrderQuantityColumn.Width = 85
        '
        'POQuantityReceivedColumn
        '
        Me.POQuantityReceivedColumn.DataPropertyName = "POQuantityReceived"
        DataGridViewCellStyle4.NullValue = "0"
        Me.POQuantityReceivedColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.POQuantityReceivedColumn.HeaderText = "Qty Received"
        Me.POQuantityReceivedColumn.Name = "POQuantityReceivedColumn"
        Me.POQuantityReceivedColumn.ReadOnly = True
        Me.POQuantityReceivedColumn.Width = 85
        '
        'POQuantityOpenColumn
        '
        Me.POQuantityOpenColumn.DataPropertyName = "POQuantityOpen"
        DataGridViewCellStyle5.NullValue = "0"
        Me.POQuantityOpenColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.POQuantityOpenColumn.HeaderText = "Qty Open"
        Me.POQuantityOpenColumn.Name = "POQuantityOpenColumn"
        Me.POQuantityOpenColumn.ReadOnly = True
        Me.POQuantityOpenColumn.Width = 85
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle6.Format = "N4"
        DataGridViewCellStyle6.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 85
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.ExtendedAmountColumn.HeaderText = "Ext Amt"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Width = 85
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.Width = 85
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.Width = 120
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ShipDateColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.Width = 85
        '
        'PODropShipCustomerIDColumn
        '
        Me.PODropShipCustomerIDColumn.DataPropertyName = "PODropShipCustomerID"
        Me.PODropShipCustomerIDColumn.HeaderText = "Customer"
        Me.PODropShipCustomerIDColumn.Name = "PODropShipCustomerIDColumn"
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
        Me.StatusColumn.Width = 62
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.Visible = False
        Me.SelectForInvoiceColumn.Width = 112
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.Visible = False
        Me.CreditGLAccountColumn.Width = 113
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.Visible = False
        Me.DebitGLAccountColumn.Width = 111
        '
        'ReceivedAmountColumn
        '
        Me.ReceivedAmountColumn.DataPropertyName = "ReceivedAmount"
        Me.ReceivedAmountColumn.HeaderText = "ReceivedAmount"
        Me.ReceivedAmountColumn.Name = "ReceivedAmountColumn"
        Me.ReceivedAmountColumn.ReadOnly = True
        Me.ReceivedAmountColumn.Visible = False
        Me.ReceivedAmountColumn.Width = 114
        '
        'OpenAmountColumn
        '
        Me.OpenAmountColumn.DataPropertyName = "OpenAmount"
        Me.OpenAmountColumn.HeaderText = "OpenAmount"
        Me.OpenAmountColumn.Name = "OpenAmountColumn"
        Me.OpenAmountColumn.ReadOnly = True
        Me.OpenAmountColumn.Visible = False
        Me.OpenAmountColumn.Width = 85
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'cboPOLookup
        '
        Me.cboPOLookup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPOLookup.DataSource = Me.PurchaseOrderQuantityStatusBindingSource
        Me.cboPOLookup.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPOLookup.FormattingEnabled = True
        Me.cboPOLookup.Location = New System.Drawing.Point(732, 431)
        Me.cboPOLookup.Name = "cboPOLookup"
        Me.cboPOLookup.Size = New System.Drawing.Size(121, 21)
        Me.cboPOLookup.TabIndex = 28
        '
        'PurchaseProductLineTableAdapter
        '
        Me.PurchaseProductLineTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'cmdGroup
        '
        Me.cmdGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGroup.Location = New System.Drawing.Point(902, 776)
        Me.cmdGroup.Name = "cmdGroup"
        Me.cmdGroup.Size = New System.Drawing.Size(74, 40)
        Me.cmdGroup.TabIndex = 29
        Me.cmdGroup.Text = "Group by Part"
        Me.cmdGroup.UseVisualStyleBackColor = True
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'cmdGroupByVendor
        '
        Me.cmdGroupByVendor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGroupByVendor.Location = New System.Drawing.Point(822, 776)
        Me.cmdGroupByVendor.Name = "cmdGroupByVendor"
        Me.cmdGroupByVendor.Size = New System.Drawing.Size(74, 40)
        Me.cmdGroupByVendor.TabIndex = 30
        Me.cmdGroupByVendor.Text = "Group by Vendor"
        Me.cmdGroupByVendor.UseVisualStyleBackColor = True
        '
        'ViewPurchaseLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdGroupByVendor)
        Me.Controls.Add(Me.cmdGroup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdOpenPurchaseOrder)
        Me.Controls.Add(Me.dgvPurchaseLines)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxQuotationFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cboPOLookup)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewPurchaseLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Purchase Order Lines"
        Me.gpxQuotationFilter.ResumeLayout(False)
        Me.gpxQuotationFilter.PerformLayout()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvPurchaseLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxQuotationFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenPurchaseOrder As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPurchaseOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents PurchaseOrderQuantityStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderQuantityStatusTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
    Friend WithEvents dgvPurchaseLines As System.Windows.Forms.DataGridView
    Friend WithEvents ReceivingDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents PrintPOListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboLineStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboSONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents cboPOLookup As System.Windows.Forms.ComboBox
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboPurchaseLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PurchaseProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODropShipCustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkOpenAndPastDue As System.Windows.Forms.CheckBox
    Friend WithEvents cmdGroup As System.Windows.Forms.Button
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents cmdGroupByVendor As System.Windows.Forms.Button
End Class
