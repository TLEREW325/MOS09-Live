<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInvoiceLines
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewAllLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLast3YearsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RePrintInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomerSummaryReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrintInvoice = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxInvoiceData = New System.Windows.Forms.GroupBox
        Me.cboLineStatus = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboFOB = New System.Windows.Forms.ComboBox
        Me.FOBTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboShipmentNumber = New System.Windows.Forms.ComboBox
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.InvoiceLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvInvoiceLines = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityBilledColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCOSColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOBColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropShipPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.cmdPrintList = New System.Windows.Forms.Button
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.InvoiceLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineQueryTableAdapter
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtTotalQuantity = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtMargin = New System.Windows.Forms.TextBox
        Me.lblMargin = New System.Windows.Forms.Label
        Me.txtCOGS = New System.Windows.Forms.TextBox
        Me.lblCOGS = New System.Windows.Forms.Label
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.FOBTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOBTableTableAdapter
        Me.cmdInvoiceNoFerrules = New System.Windows.Forms.Button
        Me.cmdViewPickTicket = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxInvoiceData.SuspendLayout()
        CType(Me.FOBTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoiceLines, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.EditToolStripMenuItem.Checked = True
        Me.EditToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewAllLinesToolStripMenuItem, Me.ViewLast3YearsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ViewAllLinesToolStripMenuItem
        '
        Me.ViewAllLinesToolStripMenuItem.CheckOnClick = True
        Me.ViewAllLinesToolStripMenuItem.Name = "ViewAllLinesToolStripMenuItem"
        Me.ViewAllLinesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ViewAllLinesToolStripMenuItem.Text = "View All Lines"
        '
        'ViewLast3YearsToolStripMenuItem
        '
        Me.ViewLast3YearsToolStripMenuItem.Checked = True
        Me.ViewLast3YearsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ViewLast3YearsToolStripMenuItem.Name = "ViewLast3YearsToolStripMenuItem"
        Me.ViewLast3YearsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ViewLast3YearsToolStripMenuItem.Text = "View Last Three Years"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem, Me.RePrintInvoiceToolStripMenuItem, Me.CustomerSummaryReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
        '
        'RePrintInvoiceToolStripMenuItem
        '
        Me.RePrintInvoiceToolStripMenuItem.Name = "RePrintInvoiceToolStripMenuItem"
        Me.RePrintInvoiceToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.RePrintInvoiceToolStripMenuItem.Text = "Re-Print Invoice"
        '
        'CustomerSummaryReportToolStripMenuItem
        '
        Me.CustomerSummaryReportToolStripMenuItem.Name = "CustomerSummaryReportToolStripMenuItem"
        Me.CustomerSummaryReportToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CustomerSummaryReportToolStripMenuItem.Text = "Customer Summary Report"
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
        'cmdPrintInvoice
        '
        Me.cmdPrintInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintInvoice.Location = New System.Drawing.Point(905, 771)
        Me.cmdPrintInvoice.Name = "cmdPrintInvoice"
        Me.cmdPrintInvoice.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintInvoice.TabIndex = 25
        Me.cmdPrintInvoice.Text = "Reprint Invoice"
        Me.cmdPrintInvoice.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 27
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxInvoiceData
        '
        Me.gpxInvoiceData.Controls.Add(Me.cboLineStatus)
        Me.gpxInvoiceData.Controls.Add(Me.Label17)
        Me.gpxInvoiceData.Controls.Add(Me.cboFOB)
        Me.gpxInvoiceData.Controls.Add(Me.Label11)
        Me.gpxInvoiceData.Controls.Add(Me.txtCustomerPO)
        Me.gpxInvoiceData.Controls.Add(Me.Label10)
        Me.gpxInvoiceData.Controls.Add(Me.txtTextFilter)
        Me.gpxInvoiceData.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxInvoiceData.Controls.Add(Me.Label14)
        Me.gpxInvoiceData.Controls.Add(Me.chkDateRange)
        Me.gpxInvoiceData.Controls.Add(Me.dtpEndDate)
        Me.gpxInvoiceData.Controls.Add(Me.Label4)
        Me.gpxInvoiceData.Controls.Add(Me.dtpBeginDate)
        Me.gpxInvoiceData.Controls.Add(Me.Label5)
        Me.gpxInvoiceData.Controls.Add(Me.cboCustomerID)
        Me.gpxInvoiceData.Controls.Add(Me.cboCustomerName)
        Me.gpxInvoiceData.Controls.Add(Me.Label3)
        Me.gpxInvoiceData.Controls.Add(Me.Label2)
        Me.gpxInvoiceData.Controls.Add(Me.cboShipmentNumber)
        Me.gpxInvoiceData.Controls.Add(Me.Label7)
        Me.gpxInvoiceData.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxInvoiceData.Controls.Add(Me.Label9)
        Me.gpxInvoiceData.Controls.Add(Me.cmdViewByFilter)
        Me.gpxInvoiceData.Controls.Add(Me.cmdClear)
        Me.gpxInvoiceData.Controls.Add(Me.cboPartNumber)
        Me.gpxInvoiceData.Controls.Add(Me.cboDivisionID)
        Me.gpxInvoiceData.Controls.Add(Me.cboPartDescription)
        Me.gpxInvoiceData.Controls.Add(Me.Label8)
        Me.gpxInvoiceData.Controls.Add(Me.Label1)
        Me.gpxInvoiceData.Controls.Add(Me.Label15)
        Me.gpxInvoiceData.Controls.Add(Me.Label16)
        Me.gpxInvoiceData.Location = New System.Drawing.Point(29, 41)
        Me.gpxInvoiceData.Name = "gpxInvoiceData"
        Me.gpxInvoiceData.Size = New System.Drawing.Size(300, 770)
        Me.gpxInvoiceData.TabIndex = 0
        Me.gpxInvoiceData.TabStop = False
        Me.gpxInvoiceData.Text = "View By Filters"
        '
        'cboLineStatus
        '
        Me.cboLineStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLineStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLineStatus.FormattingEnabled = True
        Me.cboLineStatus.Items.AddRange(New Object() {"OPEN", "CLOSED"})
        Me.cboLineStatus.Location = New System.Drawing.Point(101, 536)
        Me.cboLineStatus.Name = "cboLineStatus"
        Me.cboLineStatus.Size = New System.Drawing.Size(185, 21)
        Me.cboLineStatus.TabIndex = 12
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(20, 537)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 20)
        Me.Label17.TabIndex = 59
        Me.Label17.Text = "Line Status"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFOB
        '
        Me.cboFOB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOB.DataSource = Me.FOBTableBindingSource
        Me.cboFOB.DisplayMember = "FOBID"
        Me.cboFOB.FormattingEnabled = True
        Me.cboFOB.Location = New System.Drawing.Point(101, 415)
        Me.cboFOB.Name = "cboFOB"
        Me.cboFOB.Size = New System.Drawing.Size(185, 21)
        Me.cboFOB.TabIndex = 9
        '
        'FOBTableBindingSource
        '
        Me.FOBTableBindingSource.DataMember = "FOBTable"
        Me.FOBTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(22, 416)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "FOB"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.Location = New System.Drawing.Point(101, 456)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(185, 20)
        Me.txtCustomerPO.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(22, 456)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Cust. PO#"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.Location = New System.Drawing.Point(101, 496)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(185, 20)
        Me.txtTextFilter.TabIndex = 11
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(101, 374)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(185, 21)
        Me.cboInvoiceNumber.TabIndex = 8
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(21, 588)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(110, 624)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 13
        Me.chkDateRange.TabStop = False
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(110, 684)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpEndDate.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(21, 684)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 20)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "End Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(110, 654)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpBeginDate.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(21, 654)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 20)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Begin Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(68, 125)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(218, 21)
        Me.cboCustomerID.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(20, 158)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(266, 21)
        Me.cboCustomerName.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(178, 20)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Customer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(19, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(267, 40)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipmentNumber
        '
        Me.cboShipmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboShipmentNumber.DisplayMember = "ShipmentNumber"
        Me.cboShipmentNumber.FormattingEnabled = True
        Me.cboShipmentNumber.Location = New System.Drawing.Point(101, 333)
        Me.cboShipmentNumber.Name = "cboShipmentNumber"
        Me.cboShipmentNumber.Size = New System.Drawing.Size(185, 21)
        Me.cboShipmentNumber.TabIndex = 7
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(22, 334)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Shipment #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(101, 292)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(185, 21)
        Me.cboSalesOrderNumber.TabIndex = 6
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(22, 293)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Sales Order #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(139, 724)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 16
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(216, 724)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 17
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.DropDownWidth = 250
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(67, 204)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(218, 21)
        Me.cboPartNumber.TabIndex = 4
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
        Me.cboDivisionID.Location = New System.Drawing.Point(87, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(198, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 300
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(19, 237)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(266, 21)
        Me.cboPartDescription.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 206)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Part #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(22, 375)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 20)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Invoice #"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(20, 496)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 20)
        Me.Label16.TabIndex = 53
        Me.Label16.Text = "Text Filter"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InvoiceLineQueryBindingSource
        '
        Me.InvoiceLineQueryBindingSource.DataMember = "InvoiceLineQuery"
        Me.InvoiceLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvInvoiceLines
        '
        Me.dgvInvoiceLines.AllowUserToAddRows = False
        Me.dgvInvoiceLines.AllowUserToDeleteRows = False
        Me.dgvInvoiceLines.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvInvoiceLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInvoiceLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceLines.AutoGenerateColumns = False
        Me.dgvInvoiceLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInvoiceLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.CustomerIDColumn, Me.InvoiceDateColumn, Me.InvoiceHeaderKeyColumn, Me.InvoiceLineKeyColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityBilledColumn, Me.PriceColumn, Me.ExtendedAmountColumn, Me.ExtendedCOSColumn, Me.LineCommentColumn, Me.SerialNumberColumn, Me.SalesOrderNumberColumn, Me.ShipmentNumberColumn, Me.FOBColumn, Me.LineStatusColumn, Me.SalesTaxColumn, Me.LineWeightColumn, Me.LineBoxesColumn, Me.CreditGLAccountColumn, Me.DebitGLAccountColumn, Me.CustomerPOColumn, Me.DropShipPONumberColumn, Me.SOLineNumberColumn, Me.UnitCostColumn, Me.ItemClassColumn, Me.CustomerNameColumn})
        Me.dgvInvoiceLines.DataSource = Me.InvoiceLineQueryBindingSource
        Me.dgvInvoiceLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInvoiceLines.Location = New System.Drawing.Point(346, 41)
        Me.dgvInvoiceLines.Name = "dgvInvoiceLines"
        Me.dgvInvoiceLines.Size = New System.Drawing.Size(784, 611)
        Me.dgvInvoiceLines.TabIndex = 28
        Me.dgvInvoiceLines.TabStop = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        Me.DivisionIDColumn.Width = 65
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer ID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.ReadOnly = True
        Me.InvoiceDateColumn.Width = 85
        '
        'InvoiceHeaderKeyColumn
        '
        Me.InvoiceHeaderKeyColumn.DataPropertyName = "InvoiceHeaderKey"
        Me.InvoiceHeaderKeyColumn.HeaderText = "Invoice #"
        Me.InvoiceHeaderKeyColumn.Name = "InvoiceHeaderKeyColumn"
        Me.InvoiceHeaderKeyColumn.ReadOnly = True
        Me.InvoiceHeaderKeyColumn.Width = 85
        '
        'InvoiceLineKeyColumn
        '
        Me.InvoiceLineKeyColumn.DataPropertyName = "InvoiceLineKey"
        Me.InvoiceLineKeyColumn.HeaderText = "Line #"
        Me.InvoiceLineKeyColumn.Name = "InvoiceLineKeyColumn"
        Me.InvoiceLineKeyColumn.ReadOnly = True
        Me.InvoiceLineKeyColumn.Width = 65
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
        '
        'QuantityBilledColumn
        '
        Me.QuantityBilledColumn.DataPropertyName = "QuantityBilled"
        Me.QuantityBilledColumn.HeaderText = "Quantity Billed"
        Me.QuantityBilledColumn.Name = "QuantityBilledColumn"
        Me.QuantityBilledColumn.ReadOnly = True
        Me.QuantityBilledColumn.Width = 85
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        DataGridViewCellStyle2.Format = "N5"
        DataGridViewCellStyle2.NullValue = "0"
        Me.PriceColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.ReadOnly = True
        Me.PriceColumn.Width = 85
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountColumn.HeaderText = "Ext. Amt."
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 85
        '
        'ExtendedCOSColumn
        '
        Me.ExtendedCOSColumn.DataPropertyName = "ExtendedCOS"
        Me.ExtendedCOSColumn.HeaderText = "COS"
        Me.ExtendedCOSColumn.Name = "ExtendedCOSColumn"
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Heat# / Lot#"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "SO #"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.ReadOnly = True
        Me.SalesOrderNumberColumn.Width = 85
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Ship. #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        Me.ShipmentNumberColumn.Width = 85
        '
        'FOBColumn
        '
        Me.FOBColumn.DataPropertyName = "FOB"
        Me.FOBColumn.HeaderText = "FOB"
        Me.FOBColumn.Name = "FOBColumn"
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        Me.LineStatusColumn.Visible = False
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Visible = False
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        Me.LineWeightColumn.HeaderText = "LineWeight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.ReadOnly = True
        Me.LineWeightColumn.Visible = False
        '
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        Me.LineBoxesColumn.HeaderText = "LineBoxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        Me.LineBoxesColumn.ReadOnly = True
        Me.LineBoxesColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "Credit Account"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.ReadOnly = True
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit Account"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.ReadOnly = True
        Me.DebitGLAccountColumn.Visible = False
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Customer PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        Me.CustomerPOColumn.ReadOnly = True
        '
        'DropShipPONumberColumn
        '
        Me.DropShipPONumberColumn.DataPropertyName = "DropShipPONumber"
        Me.DropShipPONumberColumn.HeaderText = "DS PO #"
        Me.DropShipPONumberColumn.Name = "DropShipPONumberColumn"
        Me.DropShipPONumberColumn.ReadOnly = True
        '
        'SOLineNumberColumn
        '
        Me.SOLineNumberColumn.DataPropertyName = "SOLineNumber"
        Me.SOLineNumberColumn.HeaderText = "SOLineNumber"
        Me.SOLineNumberColumn.Name = "SOLineNumberColumn"
        Me.SOLineNumberColumn.ReadOnly = True
        Me.SOLineNumberColumn.Visible = False
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        Me.UnitCostColumn.HeaderText = "UnitCost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.ReadOnly = True
        Me.UnitCostColumn.Visible = False
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "ItemClass"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.ReadOnly = True
        Me.ItemClassColumn.Visible = False
        '
        'CustomerNameColumn
        '
        Me.CustomerNameColumn.DataPropertyName = "CustomerName"
        Me.CustomerNameColumn.HeaderText = "CustomerName"
        Me.CustomerNameColumn.Name = "CustomerNameColumn"
        Me.CustomerNameColumn.ReadOnly = True
        Me.CustomerNameColumn.Visible = False
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrintList
        '
        Me.cmdPrintList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintList.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrintList.Name = "cmdPrintList"
        Me.cmdPrintList.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintList.TabIndex = 26
        Me.cmdPrintList.Text = "Print Listing"
        Me.cmdPrintList.UseVisualStyleBackColor = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'InvoiceLineQueryTableAdapter
        '
        Me.InvoiceLineQueryTableAdapter.ClearBeforeFill = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtTotalQuantity)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.txtMargin)
        Me.GroupBox3.Controls.Add(Me.lblMargin)
        Me.GroupBox3.Controls.Add(Me.txtCOGS)
        Me.GroupBox3.Controls.Add(Me.lblCOGS)
        Me.GroupBox3.Controls.Add(Me.txtProductTotal)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(346, 674)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 142)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Invoice Line Totals"
        '
        'txtTotalQuantity
        '
        Me.txtTotalQuantity.BackColor = System.Drawing.Color.White
        Me.txtTotalQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalQuantity.Location = New System.Drawing.Point(103, 21)
        Me.txtTotalQuantity.Name = "txtTotalQuantity"
        Me.txtTotalQuantity.ReadOnly = True
        Me.txtTotalQuantity.Size = New System.Drawing.Size(182, 20)
        Me.txtTotalQuantity.TabIndex = 19
        Me.txtTotalQuantity.TabStop = False
        Me.txtTotalQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(13, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 20)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "Total Quantity"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMargin
        '
        Me.txtMargin.BackColor = System.Drawing.Color.White
        Me.txtMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMargin.Location = New System.Drawing.Point(103, 108)
        Me.txtMargin.Name = "txtMargin"
        Me.txtMargin.ReadOnly = True
        Me.txtMargin.Size = New System.Drawing.Size(182, 20)
        Me.txtMargin.TabIndex = 22
        Me.txtMargin.TabStop = False
        Me.txtMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMargin
        '
        Me.lblMargin.Location = New System.Drawing.Point(13, 108)
        Me.lblMargin.Name = "lblMargin"
        Me.lblMargin.Size = New System.Drawing.Size(100, 20)
        Me.lblMargin.TabIndex = 15
        Me.lblMargin.Text = "Margin"
        Me.lblMargin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCOGS
        '
        Me.txtCOGS.BackColor = System.Drawing.Color.White
        Me.txtCOGS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCOGS.Location = New System.Drawing.Point(103, 79)
        Me.txtCOGS.Name = "txtCOGS"
        Me.txtCOGS.ReadOnly = True
        Me.txtCOGS.Size = New System.Drawing.Size(182, 20)
        Me.txtCOGS.TabIndex = 21
        Me.txtCOGS.TabStop = False
        Me.txtCOGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCOGS
        '
        Me.lblCOGS.Location = New System.Drawing.Point(13, 79)
        Me.lblCOGS.Name = "lblCOGS"
        Me.lblCOGS.Size = New System.Drawing.Size(100, 20)
        Me.lblCOGS.TabIndex = 13
        Me.lblCOGS.Text = "Cost of Sales"
        Me.lblCOGS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BackColor = System.Drawing.Color.White
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.Location = New System.Drawing.Point(103, 50)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.ReadOnly = True
        Me.txtProductTotal.Size = New System.Drawing.Size(182, 20)
        Me.txtProductTotal.TabIndex = 20
        Me.txtProductTotal.TabStop = False
        Me.txtProductTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(13, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Product Total"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(675, 674)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(397, 43)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Heat #'s and Lot #'s may be entered into either field - Line Comment or Heat/Lot " & _
            "#. Changes in the datagrid are automatically saved."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(675, 727)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(397, 20)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "To reprint Invoice, select in grid and press reprint."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'FOBTableTableAdapter
        '
        Me.FOBTableTableAdapter.ClearBeforeFill = True
        '
        'cmdInvoiceNoFerrules
        '
        Me.cmdInvoiceNoFerrules.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdInvoiceNoFerrules.Location = New System.Drawing.Point(828, 771)
        Me.cmdInvoiceNoFerrules.Name = "cmdInvoiceNoFerrules"
        Me.cmdInvoiceNoFerrules.Size = New System.Drawing.Size(71, 40)
        Me.cmdInvoiceNoFerrules.TabIndex = 24
        Me.cmdInvoiceNoFerrules.Text = "No Ferrule Report"
        Me.cmdInvoiceNoFerrules.UseVisualStyleBackColor = True
        '
        'cmdViewPickTicket
        '
        Me.cmdViewPickTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPickTicket.ForeColor = System.Drawing.Color.Black
        Me.cmdViewPickTicket.Location = New System.Drawing.Point(751, 770)
        Me.cmdViewPickTicket.Name = "cmdViewPickTicket"
        Me.cmdViewPickTicket.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPickTicket.TabIndex = 23
        Me.cmdViewPickTicket.Text = "View Pick Ticket"
        Me.cmdViewPickTicket.UseVisualStyleBackColor = True
        '
        'ViewInvoiceLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdViewPickTicket)
        Me.Controls.Add(Me.cmdInvoiceNoFerrules)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdPrintInvoice)
        Me.Controls.Add(Me.cmdPrintList)
        Me.Controls.Add(Me.dgvInvoiceLines)
        Me.Controls.Add(Me.gpxInvoiceData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewInvoiceLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Invoice Lines"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxInvoiceData.ResumeLayout(False)
        Me.gpxInvoiceData.PerformLayout()
        CType(Me.FOBTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoiceLines, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdPrintInvoice As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxInvoiceData As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvInvoiceLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdPrintList As System.Windows.Forms.Button
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RePrintInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboShipmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents InvoiceLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineQueryTableAdapter
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents txtMargin As System.Windows.Forms.TextBox
    Friend WithEvents lblMargin As System.Windows.Forms.Label
    Friend WithEvents txtCOGS As System.Windows.Forms.TextBox
    Friend WithEvents lblCOGS As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboFOB As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents FOBTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOBTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOBTableTableAdapter
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityBilledColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCOSColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOBColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropShipPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerSummaryReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboLineStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdInvoiceNoFerrules As System.Windows.Forms.Button
    Friend WithEvents ViewAllLinesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLast3YearsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdViewPickTicket As System.Windows.Forms.Button
End Class
