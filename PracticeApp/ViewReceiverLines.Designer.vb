<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewReceiverLines
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
        Me.gpxQuotationFilter = New System.Windows.Forms.GroupBox
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboReceiverNumber = New System.Windows.Forms.ComboBox
        Me.ReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkQuantityOpen = New System.Windows.Forms.CheckBox
        Me.cboAPStatus = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadPackingSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadPackingSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendUploadedPackingSlipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReceivingLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.dgvReceivingLines = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQuantityVouchedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityReturnedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingAgent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineQueryTableAdapter
        Me.cmdOpenEditMode = New System.Windows.Forms.Button
        Me.ReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
        Me.cmdViewPackingSlip = New System.Windows.Forms.Button
        Me.SteelYardEntryTotalsTableAdapter1 = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelYardEntryTotalsTableAdapter
        Me.gpxQuotationFilter.SuspendLayout()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReceivingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxQuotationFilter
        '
        Me.gpxQuotationFilter.Controls.Add(Me.txtTextFilter)
        Me.gpxQuotationFilter.Controls.Add(Me.Label6)
        Me.gpxQuotationFilter.Controls.Add(Me.cboReceiverNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.Label2)
        Me.gpxQuotationFilter.Controls.Add(Me.chkQuantityOpen)
        Me.gpxQuotationFilter.Controls.Add(Me.cboAPStatus)
        Me.gpxQuotationFilter.Controls.Add(Me.Label1)
        Me.gpxQuotationFilter.Controls.Add(Me.Label12)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpEndDate)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpBeginDate)
        Me.gpxQuotationFilter.Controls.Add(Me.Label14)
        Me.gpxQuotationFilter.Controls.Add(Me.chkDateRange)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPONumber)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPartDescription)
        Me.gpxQuotationFilter.Controls.Add(Me.Label8)
        Me.gpxQuotationFilter.Controls.Add(Me.txtVendorName)
        Me.gpxQuotationFilter.Controls.Add(Me.Label10)
        Me.gpxQuotationFilter.Controls.Add(Me.cboVendorID)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPartNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.Label9)
        Me.gpxQuotationFilter.Controls.Add(Me.Label3)
        Me.gpxQuotationFilter.Controls.Add(Me.cboDivisionID)
        Me.gpxQuotationFilter.Controls.Add(Me.Label5)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdClear)
        Me.gpxQuotationFilter.Controls.Add(Me.Label4)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdViewByFilter)
        Me.gpxQuotationFilter.Location = New System.Drawing.Point(29, 41)
        Me.gpxQuotationFilter.Name = "gpxQuotationFilter"
        Me.gpxQuotationFilter.Size = New System.Drawing.Size(300, 774)
        Me.gpxQuotationFilter.TabIndex = 0
        Me.gpxQuotationFilter.TabStop = False
        Me.gpxQuotationFilter.Text = "View By Filters"
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(104, 458)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(179, 20)
        Me.txtTextFilter.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 458)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Text Filter"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboReceiverNumber
        '
        Me.cboReceiverNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReceiverNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReceiverNumber.DataSource = Me.ReceivingHeaderTableBindingSource
        Me.cboReceiverNumber.DisplayMember = "ReceivingHeaderKey"
        Me.cboReceiverNumber.FormattingEnabled = True
        Me.cboReceiverNumber.Location = New System.Drawing.Point(104, 320)
        Me.cboReceiverNumber.Name = "cboReceiverNumber"
        Me.cboReceiverNumber.Size = New System.Drawing.Size(179, 21)
        Me.cboReceiverNumber.TabIndex = 5
        '
        'ReceivingHeaderTableBindingSource
        '
        Me.ReceivingHeaderTableBindingSource.DataMember = "ReceivingHeaderTable"
        Me.ReceivingHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 321)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Receiver #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkQuantityOpen
        '
        Me.chkQuantityOpen.AutoSize = True
        Me.chkQuantityOpen.Location = New System.Drawing.Point(105, 519)
        Me.chkQuantityOpen.Name = "chkQuantityOpen"
        Me.chkQuantityOpen.Size = New System.Drawing.Size(112, 17)
        Me.chkQuantityOpen.TabIndex = 9
        Me.chkQuantityOpen.Text = "Quantity Open > 0"
        Me.chkQuantityOpen.UseVisualStyleBackColor = True
        '
        'cboAPStatus
        '
        Me.cboAPStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAPStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAPStatus.FormattingEnabled = True
        Me.cboAPStatus.Items.AddRange(New Object() {"OPEN", "CLOSED"})
        Me.cboAPStatus.Location = New System.Drawing.Point(104, 412)
        Me.cboAPStatus.Name = "cboAPStatus"
        Me.cboAPStatus.Size = New System.Drawing.Size(179, 21)
        Me.cboAPStatus.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 412)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "AP Line Status"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(14, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 40)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(103, 688)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpEndDate.TabIndex = 12
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(103, 658)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpBeginDate.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(17, 592)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(266, 33)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(105, 628)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 10
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPONumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(104, 366)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(179, 21)
        Me.cboPONumber.TabIndex = 6
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 250
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(14, 271)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(269, 21)
        Me.cboPartDescription.TabIndex = 4
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(14, 366)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "PO #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(14, 148)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(269, 65)
        Me.txtVendorName.TabIndex = 2
        Me.txtVendorName.TabStop = False
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 688)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "End Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(101, 112)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(182, 21)
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
        Me.cboPartNumber.DropDownWidth = 200
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(59, 238)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(224, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 658)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Begin Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 20)
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
        Me.cboDivisionID.Location = New System.Drawing.Point(101, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(182, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Vendor ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 729)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(138, 729)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 13
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 17
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem1, Me.UploadPackingSlipToolStripMenuItem, Me.ReUploadPackingSlipToolStripMenuItem, Me.AppendUploadedPackingSlipToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem1
        '
        Me.PrintListingToolStripMenuItem1.Name = "PrintListingToolStripMenuItem1"
        Me.PrintListingToolStripMenuItem1.Size = New System.Drawing.Size(217, 22)
        Me.PrintListingToolStripMenuItem1.Text = "Print Listing"
        '
        'UploadPackingSlipToolStripMenuItem
        '
        Me.UploadPackingSlipToolStripMenuItem.Enabled = False
        Me.UploadPackingSlipToolStripMenuItem.Name = "UploadPackingSlipToolStripMenuItem"
        Me.UploadPackingSlipToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.UploadPackingSlipToolStripMenuItem.Text = "Upload Packing Slip"
        '
        'ReUploadPackingSlipToolStripMenuItem
        '
        Me.ReUploadPackingSlipToolStripMenuItem.Enabled = False
        Me.ReUploadPackingSlipToolStripMenuItem.Name = "ReUploadPackingSlipToolStripMenuItem"
        Me.ReUploadPackingSlipToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ReUploadPackingSlipToolStripMenuItem.Text = "Re-Upload Packing Slip"
        '
        'AppendUploadedPackingSlipToolStripMenuItem
        '
        Me.AppendUploadedPackingSlipToolStripMenuItem.Enabled = False
        Me.AppendUploadedPackingSlipToolStripMenuItem.Name = "AppendUploadedPackingSlipToolStripMenuItem"
        Me.AppendUploadedPackingSlipToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.AppendUploadedPackingSlipToolStripMenuItem.Text = "Append Uploaded Packing Slip"
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
        'ReceivingLineQueryBindingSource
        '
        Me.ReceivingLineQueryBindingSource.DataMember = "ReceivingLineQuery"
        Me.ReceivingLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(979, 775)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 775)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
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
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'dgvReceivingLines
        '
        Me.dgvReceivingLines.AllowUserToAddRows = False
        Me.dgvReceivingLines.AllowUserToDeleteRows = False
        Me.dgvReceivingLines.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvReceivingLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReceivingLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReceivingLines.AutoGenerateColumns = False
        Me.dgvReceivingLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReceivingLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvReceivingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceivingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.ReceivingDateColumn, Me.ReceivingHeaderKeyColumn, Me.ReceivingLineKeyColumn, Me.VendorCodeColumn, Me.PONumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityReceivedColumn, Me.TotalQuantityVouchedColumn, Me.QuantityOpenColumn, Me.QuantityReturnedColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.StatusColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.LineStatusColumn, Me.StatusColumn2, Me.SelectForInvoiceColumn, Me.ReceivingAgent})
        Me.dgvReceivingLines.DataSource = Me.ReceivingLineQueryBindingSource
        Me.dgvReceivingLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvReceivingLines.Location = New System.Drawing.Point(351, 41)
        Me.dgvReceivingLines.Name = "dgvReceivingLines"
        Me.dgvReceivingLines.Size = New System.Drawing.Size(779, 727)
        Me.dgvReceivingLines.TabIndex = 29
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        Me.DivisionIDColumn.Width = 80
        '
        'ReceivingDateColumn
        '
        Me.ReceivingDateColumn.DataPropertyName = "ReceivingDate"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.ReceivingDateColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ReceivingDateColumn.HeaderText = "Date Received"
        Me.ReceivingDateColumn.Name = "ReceivingDateColumn"
        Me.ReceivingDateColumn.ReadOnly = True
        Me.ReceivingDateColumn.Width = 97
        '
        'ReceivingHeaderKeyColumn
        '
        Me.ReceivingHeaderKeyColumn.DataPropertyName = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumn.HeaderText = "Receiver #"
        Me.ReceivingHeaderKeyColumn.Name = "ReceivingHeaderKeyColumn"
        Me.ReceivingHeaderKeyColumn.ReadOnly = True
        Me.ReceivingHeaderKeyColumn.Width = 85
        '
        'ReceivingLineKeyColumn
        '
        Me.ReceivingLineKeyColumn.DataPropertyName = "ReceivingLineKey"
        Me.ReceivingLineKeyColumn.HeaderText = "Line #"
        Me.ReceivingLineKeyColumn.Name = "ReceivingLineKeyColumn"
        Me.ReceivingLineKeyColumn.ReadOnly = True
        Me.ReceivingLineKeyColumn.Width = 60
        '
        'VendorCodeColumn
        '
        Me.VendorCodeColumn.DataPropertyName = "VendorCode"
        Me.VendorCodeColumn.HeaderText = "Vendor"
        Me.VendorCodeColumn.Name = "VendorCodeColumn"
        Me.VendorCodeColumn.ReadOnly = True
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PO#"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.ReadOnly = True
        Me.PONumberColumn.Width = 85
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        Me.PartNumberColumn.Width = 120
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 150
        '
        'QuantityReceivedColumn
        '
        Me.QuantityReceivedColumn.DataPropertyName = "QuantityReceived"
        DataGridViewCellStyle3.NullValue = "0"
        Me.QuantityReceivedColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.QuantityReceivedColumn.HeaderText = "Qty Received"
        Me.QuantityReceivedColumn.Name = "QuantityReceivedColumn"
        Me.QuantityReceivedColumn.ReadOnly = True
        Me.QuantityReceivedColumn.Width = 85
        '
        'TotalQuantityVouchedColumn
        '
        Me.TotalQuantityVouchedColumn.DataPropertyName = "TotalQuantityVouched"
        DataGridViewCellStyle4.NullValue = "0"
        Me.TotalQuantityVouchedColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.TotalQuantityVouchedColumn.HeaderText = "Qty Vouched"
        Me.TotalQuantityVouchedColumn.Name = "TotalQuantityVouchedColumn"
        Me.TotalQuantityVouchedColumn.ReadOnly = True
        Me.TotalQuantityVouchedColumn.Width = 85
        '
        'QuantityOpenColumn
        '
        Me.QuantityOpenColumn.DataPropertyName = "QuantityOpen"
        DataGridViewCellStyle5.NullValue = "0"
        Me.QuantityOpenColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.QuantityOpenColumn.HeaderText = "Qty Unvouched"
        Me.QuantityOpenColumn.Name = "QuantityOpenColumn"
        Me.QuantityOpenColumn.ReadOnly = True
        Me.QuantityOpenColumn.Width = 85
        '
        'QuantityReturnedColumn
        '
        Me.QuantityReturnedColumn.DataPropertyName = "QuantityReturned"
        Me.QuantityReturnedColumn.HeaderText = "Qty Returned"
        Me.QuantityReturnedColumn.Name = "QuantityReturnedColumn"
        Me.QuantityReturnedColumn.ReadOnly = True
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle6.Format = "C4"
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
        Me.ExtendedAmountColumn.HeaderText = "Ext. Amt."
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 85
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        Me.StatusColumn.Visible = False
        Me.StatusColumn.Width = 62
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit Account"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.ReadOnly = True
        Me.DebitGLAccountColumn.Width = 92
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "Credit Account"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.ReadOnly = True
        Me.CreditGLAccountColumn.Width = 94
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        Me.LineStatusColumn.Width = 79
        '
        'StatusColumn2
        '
        Me.StatusColumn2.DataPropertyName = "Status"
        Me.StatusColumn2.HeaderText = "Receiver Status"
        Me.StatusColumn2.Name = "StatusColumn2"
        Me.StatusColumn2.ReadOnly = True
        Me.StatusColumn2.Width = 99
        '
        'SelectForInvoiceColumn
        '
        Me.SelectForInvoiceColumn.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn.HeaderText = "Voucher Status"
        Me.SelectForInvoiceColumn.Name = "SelectForInvoiceColumn"
        Me.SelectForInvoiceColumn.ReadOnly = True
        Me.SelectForInvoiceColumn.Width = 97
        '
        'ReceivingAgent
        '
        Me.ReceivingAgent.DataPropertyName = "ReceivingAgent"
        Me.ReceivingAgent.HeaderText = "Received By?"
        Me.ReceivingAgent.Name = "ReceivingAgent"
        Me.ReceivingAgent.ReadOnly = True
        '
        'ReceivingLineQueryTableAdapter
        '
        Me.ReceivingLineQueryTableAdapter.ClearBeforeFill = True
        '
        'cmdOpenEditMode
        '
        Me.cmdOpenEditMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenEditMode.ForeColor = System.Drawing.Color.Blue
        Me.cmdOpenEditMode.Location = New System.Drawing.Point(351, 774)
        Me.cmdOpenEditMode.Name = "cmdOpenEditMode"
        Me.cmdOpenEditMode.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenEditMode.TabIndex = 14
        Me.cmdOpenEditMode.Text = "Receiver Edit Mode"
        Me.cmdOpenEditMode.UseVisualStyleBackColor = True
        '
        'ReceivingHeaderTableTableAdapter
        '
        Me.ReceivingHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'cmdViewPackingSlip
        '
        Me.cmdViewPackingSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPackingSlip.Enabled = False
        Me.cmdViewPackingSlip.Location = New System.Drawing.Point(902, 775)
        Me.cmdViewPackingSlip.Name = "cmdViewPackingSlip"
        Me.cmdViewPackingSlip.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPackingSlip.TabIndex = 30
        Me.cmdViewPackingSlip.Text = "View Packing"
        Me.cmdViewPackingSlip.UseVisualStyleBackColor = True
        '
        'SteelYardEntryTotalsTableAdapter1
        '
        Me.SteelYardEntryTotalsTableAdapter1.ClearBeforeFill = True
        '
        'ViewReceiverLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdViewPackingSlip)
        Me.Controls.Add(Me.cmdOpenEditMode)
        Me.Controls.Add(Me.dgvReceivingLines)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxQuotationFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewReceiverLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Receiver Lines"
        Me.gpxQuotationFilter.ResumeLayout(False)
        Me.gpxQuotationFilter.PerformLayout()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReceivingLines, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents dgvReceivingLines As System.Windows.Forms.DataGridView
    Friend WithEvents ReceivingLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineQueryTableAdapter
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cboReceiverNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOpenEditMode As System.Windows.Forms.Button
    Friend WithEvents PrintListingToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents cboAPStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkQuantityOpen As System.Windows.Forms.CheckBox
    Friend WithEvents ReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdViewPackingSlip As System.Windows.Forms.Button
    Friend WithEvents UploadPackingSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReUploadPackingSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SteelYardEntryTotalsTableAdapter1 As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelYardEntryTotalsTableAdapter
    Friend WithEvents AppendUploadedPackingSlipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQuantityVouchedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityReturnedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingAgent As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
