<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewReceivingOnTime
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintOnTimeReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxQuotationFilter = New System.Windows.Forms.GroupBox
        Me.cboReceiverNumber = New System.Windows.Forms.ComboBox
        Me.ReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.dgvReceivingPOQuery = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OriginalPODateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipMethodIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightChargeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransferDivisionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeaderCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingOnTimeQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReceivingOnTimeQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingOnTimeQueryTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.ReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxQuotationFilter.SuspendLayout()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReceivingPOQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceivingOnTimeQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintOnTimeReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintOnTimeReportToolStripMenuItem
        '
        Me.PrintOnTimeReportToolStripMenuItem.Name = "PrintOnTimeReportToolStripMenuItem"
        Me.PrintOnTimeReportToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.PrintOnTimeReportToolStripMenuItem.Text = "Print On-Time Report"
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
        'gpxQuotationFilter
        '
        Me.gpxQuotationFilter.Controls.Add(Me.cboReceiverNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.Label7)
        Me.gpxQuotationFilter.Controls.Add(Me.cboStatus)
        Me.gpxQuotationFilter.Controls.Add(Me.Label6)
        Me.gpxQuotationFilter.Controls.Add(Me.Label12)
        Me.gpxQuotationFilter.Controls.Add(Me.Label14)
        Me.gpxQuotationFilter.Controls.Add(Me.chkDateRange)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpEndDate)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPONumber)
        Me.gpxQuotationFilter.Controls.Add(Me.Label8)
        Me.gpxQuotationFilter.Controls.Add(Me.Label3)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpBeginDate)
        Me.gpxQuotationFilter.Controls.Add(Me.Label2)
        Me.gpxQuotationFilter.Controls.Add(Me.txtVendorName)
        Me.gpxQuotationFilter.Controls.Add(Me.cboVendorID)
        Me.gpxQuotationFilter.Controls.Add(Me.cboDivisionID)
        Me.gpxQuotationFilter.Controls.Add(Me.Label5)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdClear)
        Me.gpxQuotationFilter.Controls.Add(Me.Label4)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdView)
        Me.gpxQuotationFilter.Location = New System.Drawing.Point(29, 41)
        Me.gpxQuotationFilter.Name = "gpxQuotationFilter"
        Me.gpxQuotationFilter.Size = New System.Drawing.Size(300, 662)
        Me.gpxQuotationFilter.TabIndex = 1
        Me.gpxQuotationFilter.TabStop = False
        Me.gpxQuotationFilter.Text = "View By Filters"
        '
        'cboReceiverNumber
        '
        Me.cboReceiverNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReceiverNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReceiverNumber.DataSource = Me.ReceivingHeaderTableBindingSource
        Me.cboReceiverNumber.DisplayMember = "ReceivingHeaderKey"
        Me.cboReceiverNumber.FormattingEnabled = True
        Me.cboReceiverNumber.Location = New System.Drawing.Point(91, 326)
        Me.cboReceiverNumber.Name = "cboReceiverNumber"
        Me.cboReceiverNumber.Size = New System.Drawing.Size(195, 21)
        Me.cboReceiverNumber.TabIndex = 4
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
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 327)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Receiver #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "RECEIVED", "CLOSED"})
        Me.cboStatus.Location = New System.Drawing.Point(91, 391)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(195, 21)
        Me.cboStatus.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 394)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Status"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(20, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 40)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 447)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(103, 498)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 6
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(101, 567)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(185, 20)
        Me.dtpEndDate.TabIndex = 8
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPONumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(91, 261)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(195, 21)
        Me.cboPONumber.TabIndex = 3
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 567)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 262)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PO #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(101, 530)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(185, 20)
        Me.dtpBeginDate.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 530)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Begin Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(20, 151)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(266, 63)
        Me.txtVendorName.TabIndex = 2
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(88, 115)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(198, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(88, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(198, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Vendor ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(215, 605)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 10
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
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(141, 605)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 9
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'dgvReceivingPOQuery
        '
        Me.dgvReceivingPOQuery.AllowUserToAddRows = False
        Me.dgvReceivingPOQuery.AllowUserToDeleteRows = False
        Me.dgvReceivingPOQuery.AllowUserToOrderColumns = True
        Me.dgvReceivingPOQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReceivingPOQuery.AutoGenerateColumns = False
        Me.dgvReceivingPOQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReceivingPOQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvReceivingPOQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceivingPOQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.VendorCodeColumn, Me.PONumberColumn, Me.ReceivingHeaderKeyColumn, Me.OriginalPODateColumn, Me.ShipDateColumn, Me.ReceivingDateColumn, Me.ShipMethodIDColumn, Me.ProductTotalColumn, Me.FreightChargeColumn, Me.SalesTaxColumn, Me.POTotalColumn, Me.StatusColumn, Me.TransferDivisionColumn, Me.PODateColumn, Me.HeaderCommentColumn, Me.InvoiceNumberColumn})
        Me.dgvReceivingPOQuery.DataSource = Me.ReceivingOnTimeQueryBindingSource
        Me.dgvReceivingPOQuery.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvReceivingPOQuery.Location = New System.Drawing.Point(346, 41)
        Me.dgvReceivingPOQuery.Name = "dgvReceivingPOQuery"
        Me.dgvReceivingPOQuery.Size = New System.Drawing.Size(784, 712)
        Me.dgvReceivingPOQuery.TabIndex = 2
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'VendorCodeColumn
        '
        Me.VendorCodeColumn.DataPropertyName = "VendorCode"
        Me.VendorCodeColumn.HeaderText = "Vendor"
        Me.VendorCodeColumn.Name = "VendorCodeColumn"
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PO #"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.ReadOnly = True
        Me.PONumberColumn.Width = 80
        '
        'ReceivingHeaderKeyColumn
        '
        Me.ReceivingHeaderKeyColumn.DataPropertyName = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumn.HeaderText = "Receiver #"
        Me.ReceivingHeaderKeyColumn.Name = "ReceivingHeaderKeyColumn"
        Me.ReceivingHeaderKeyColumn.ReadOnly = True
        Me.ReceivingHeaderKeyColumn.Width = 80
        '
        'OriginalPODateColumn
        '
        Me.OriginalPODateColumn.DataPropertyName = "OriginalPODate"
        Me.OriginalPODateColumn.HeaderText = "PO Date"
        Me.OriginalPODateColumn.Name = "OriginalPODateColumn"
        Me.OriginalPODateColumn.Width = 80
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "Promise Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.Width = 80
        '
        'ReceivingDateColumn
        '
        Me.ReceivingDateColumn.DataPropertyName = "ReceivingDate"
        Me.ReceivingDateColumn.HeaderText = "Receiving Date"
        Me.ReceivingDateColumn.Name = "ReceivingDateColumn"
        Me.ReceivingDateColumn.ReadOnly = True
        Me.ReceivingDateColumn.Width = 80
        '
        'ShipMethodIDColumn
        '
        Me.ShipMethodIDColumn.DataPropertyName = "ShipMethodID"
        Me.ShipMethodIDColumn.HeaderText = "Ship Via"
        Me.ShipMethodIDColumn.Name = "ShipMethodIDColumn"
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.ReadOnly = True
        Me.ProductTotalColumn.Width = 80
        '
        'FreightChargeColumn
        '
        Me.FreightChargeColumn.DataPropertyName = "FreightCharge"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.FreightChargeColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.FreightChargeColumn.HeaderText = "Freight Charge"
        Me.FreightChargeColumn.Name = "FreightChargeColumn"
        Me.FreightChargeColumn.ReadOnly = True
        Me.FreightChargeColumn.Width = 80
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.SalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.SalesTaxColumn.HeaderText = "Sales Tax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Width = 80
        '
        'POTotalColumn
        '
        Me.POTotalColumn.DataPropertyName = "POTotal"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.POTotalColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.POTotalColumn.HeaderText = "Receiver Total"
        Me.POTotalColumn.Name = "POTotalColumn"
        Me.POTotalColumn.ReadOnly = True
        Me.POTotalColumn.Width = 80
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        Me.StatusColumn.Visible = False
        '
        'TransferDivisionColumn
        '
        Me.TransferDivisionColumn.DataPropertyName = "TransferDivision"
        Me.TransferDivisionColumn.HeaderText = "TransferDivision"
        Me.TransferDivisionColumn.Name = "TransferDivisionColumn"
        Me.TransferDivisionColumn.ReadOnly = True
        Me.TransferDivisionColumn.Visible = False
        '
        'PODateColumn
        '
        Me.PODateColumn.DataPropertyName = "PODate"
        Me.PODateColumn.HeaderText = "PODate"
        Me.PODateColumn.Name = "PODateColumn"
        Me.PODateColumn.Visible = False
        '
        'HeaderCommentColumn
        '
        Me.HeaderCommentColumn.DataPropertyName = "HeaderComment"
        Me.HeaderCommentColumn.HeaderText = "HeaderComment"
        Me.HeaderCommentColumn.Name = "HeaderCommentColumn"
        Me.HeaderCommentColumn.Visible = False
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "InvoiceNumber"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.ReadOnly = True
        Me.InvoiceNumberColumn.Visible = False
        '
        'ReceivingOnTimeQueryBindingSource
        '
        Me.ReceivingOnTimeQueryBindingSource.DataMember = "ReceivingOnTimeQuery"
        Me.ReceivingOnTimeQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ReceivingOnTimeQueryTableAdapter
        '
        Me.ReceivingOnTimeQueryTableAdapter.ClearBeforeFill = True
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
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ReceivingHeaderTableTableAdapter
        '
        Me.ReceivingHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ViewReceivingOnTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvReceivingPOQuery)
        Me.Controls.Add(Me.gpxQuotationFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewReceivingOnTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Purchase Order On-Time Report"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxQuotationFilter.ResumeLayout(False)
        Me.gpxQuotationFilter.PerformLayout()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReceivingPOQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceivingOnTimeQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxQuotationFilter As System.Windows.Forms.GroupBox
    Friend WithEvents cboReceiverNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents dgvReceivingPOQuery As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ReceivingOnTimeQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingOnTimeQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingOnTimeQueryTableAdapter
    Friend WithEvents Expr1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintOnTimeReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents ReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OriginalPODateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipMethodIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightChargeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransferDivisionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeaderCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
