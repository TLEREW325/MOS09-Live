<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewTaxCollected
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintTaxSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvInvoiceQuery = New System.Windows.Forms.DataGridView
        Me.InvoiceHeaderQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.InvoiceHeaderQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderQueryTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxInvoiceData = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboSONumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.MonthTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.MonthTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MonthTableTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax3Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BilledFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentCity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentState = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentZip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvInvoiceQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceHeaderQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxInvoiceData.SuspendLayout()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MonthTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintTaxSummaryToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintTaxSummaryToolStripMenuItem
        '
        Me.PrintTaxSummaryToolStripMenuItem.Name = "PrintTaxSummaryToolStripMenuItem"
        Me.PrintTaxSummaryToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.PrintTaxSummaryToolStripMenuItem.Text = "Print Tax Summary"
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
        'dgvInvoiceQuery
        '
        Me.dgvInvoiceQuery.AllowUserToAddRows = False
        Me.dgvInvoiceQuery.AllowUserToDeleteRows = False
        Me.dgvInvoiceQuery.AllowUserToOrderColumns = True
        Me.dgvInvoiceQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceQuery.AutoGenerateColumns = False
        Me.dgvInvoiceQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInvoiceQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceDateColumn, Me.CustomerIDColumn, Me.InvoiceNumberColumn, Me.ProductTotalColumn, Me.SalesTaxColumn, Me.SalesTax2Column, Me.SalesTax3Column, Me.BilledFreightColumn, Me.InvoiceTotalColumn, Me.SalesOrderNumberColumn, Me.ShipmentNumberColumn, Me.InvoiceStatusColumn, Me.DivisionIDColumn, Me.ShipmentCity, Me.ShipmentState, Me.ShipmentZip})
        Me.dgvInvoiceQuery.DataSource = Me.InvoiceHeaderQueryBindingSource
        Me.dgvInvoiceQuery.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInvoiceQuery.Location = New System.Drawing.Point(349, 41)
        Me.dgvInvoiceQuery.Name = "dgvInvoiceQuery"
        Me.dgvInvoiceQuery.Size = New System.Drawing.Size(781, 715)
        Me.dgvInvoiceQuery.TabIndex = 19
        Me.dgvInvoiceQuery.TabStop = False
        '
        'InvoiceHeaderQueryBindingSource
        '
        Me.InvoiceHeaderQueryBindingSource.DataMember = "InvoiceHeaderQuery"
        Me.InvoiceHeaderQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'InvoiceHeaderQueryTableAdapter
        '
        Me.InvoiceHeaderQueryTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 12
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxInvoiceData
        '
        Me.gpxInvoiceData.Controls.Add(Me.Label9)
        Me.gpxInvoiceData.Controls.Add(Me.Label12)
        Me.gpxInvoiceData.Controls.Add(Me.Label14)
        Me.gpxInvoiceData.Controls.Add(Me.chkDateRange)
        Me.gpxInvoiceData.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxInvoiceData.Controls.Add(Me.Label3)
        Me.gpxInvoiceData.Controls.Add(Me.dtpBeginDate)
        Me.gpxInvoiceData.Controls.Add(Me.dtpEndDate)
        Me.gpxInvoiceData.Controls.Add(Me.cboSONumber)
        Me.gpxInvoiceData.Controls.Add(Me.Label5)
        Me.gpxInvoiceData.Controls.Add(Me.cboCustomerName)
        Me.gpxInvoiceData.Controls.Add(Me.Label4)
        Me.gpxInvoiceData.Controls.Add(Me.Label7)
        Me.gpxInvoiceData.Controls.Add(Me.cboDivisionID)
        Me.gpxInvoiceData.Controls.Add(Me.cboYear)
        Me.gpxInvoiceData.Controls.Add(Me.cboCustomerID)
        Me.gpxInvoiceData.Controls.Add(Me.Label8)
        Me.gpxInvoiceData.Controls.Add(Me.cmdView)
        Me.gpxInvoiceData.Controls.Add(Me.cboMonth)
        Me.gpxInvoiceData.Controls.Add(Me.Label6)
        Me.gpxInvoiceData.Controls.Add(Me.cmdClear)
        Me.gpxInvoiceData.Controls.Add(Me.Label2)
        Me.gpxInvoiceData.Controls.Add(Me.Label1)
        Me.gpxInvoiceData.Location = New System.Drawing.Point(29, 41)
        Me.gpxInvoiceData.Name = "gpxInvoiceData"
        Me.gpxInvoiceData.Size = New System.Drawing.Size(300, 770)
        Me.gpxInvoiceData.TabIndex = 0
        Me.gpxInvoiceData.TabStop = False
        Me.gpxInvoiceData.Text = "View By Filters"
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(21, 421)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(262, 40)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Choose Month/Year or Date Range to filter selection."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(23, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 40)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(21, 575)
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
        Me.chkDateRange.Location = New System.Drawing.Point(105, 611)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 7
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(104, 290)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(179, 21)
        Me.cboInvoiceNumber.TabIndex = 4
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 291)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Invoice #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(106, 644)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpBeginDate.TabIndex = 8
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(106, 679)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpEndDate.TabIndex = 9
        '
        'cboSONumber
        '
        Me.cboSONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSONumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSONumber.DisplayMember = "SalesOrderKey"
        Me.cboSONumber.FormattingEnabled = True
        Me.cboSONumber.Location = New System.Drawing.Point(104, 235)
        Me.cboSONumber.Name = "cboSONumber"
        Me.cboSONumber.Size = New System.Drawing.Size(179, 21)
        Me.cboSONumber.TabIndex = 3
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 645)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Begin Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(21, 161)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(264, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 680)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "End Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 236)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Sales Order #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(92, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(193, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboYear
        '
        Me.cboYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Items.AddRange(New Object() {"2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025"})
        Me.cboYear.Location = New System.Drawing.Point(104, 504)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(179, 21)
        Me.cboYear.TabIndex = 6
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(92, 130)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(193, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 505)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Year"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(137, 720)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 10
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cboMonth
        '
        Me.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMonth.DataSource = Me.MonthTableBindingSource
        Me.cboMonth.DisplayMember = "MonthName"
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(104, 476)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(179, 21)
        Me.cboMonth.TabIndex = 5
        '
        'MonthTableBindingSource
        '
        Me.MonthTableBindingSource.DataMember = "MonthTable"
        Me.MonthTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 477)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Month"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 720)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 11
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Customer ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'MonthTableTableAdapter
        '
        Me.MonthTableTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.Width = 80
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer ID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.Width = 80
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.ProductTotalColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.Width = 70
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.SalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.SalesTaxColumn.HeaderText = "Sales Tax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.Width = 70
        '
        'SalesTax2Column
        '
        Me.SalesTax2Column.DataPropertyName = "SalesTax2"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.SalesTax2Column.DefaultCellStyle = DataGridViewCellStyle3
        Me.SalesTax2Column.HeaderText = "PST"
        Me.SalesTax2Column.Name = "SalesTax2Column"
        Me.SalesTax2Column.Width = 70
        '
        'SalesTax3Column
        '
        Me.SalesTax3Column.DataPropertyName = "SalesTax3"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.SalesTax3Column.DefaultCellStyle = DataGridViewCellStyle4
        Me.SalesTax3Column.HeaderText = "HST"
        Me.SalesTax3Column.Name = "SalesTax3Column"
        Me.SalesTax3Column.Width = 70
        '
        'BilledFreightColumn
        '
        Me.BilledFreightColumn.DataPropertyName = "BilledFreight"
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.BilledFreightColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.BilledFreightColumn.HeaderText = "Billed Freight"
        Me.BilledFreightColumn.Name = "BilledFreightColumn"
        Me.BilledFreightColumn.Width = 70
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.Width = 70
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "SO #"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.Width = 85
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.Width = 85
        '
        'InvoiceStatusColumn
        '
        Me.InvoiceStatusColumn.DataPropertyName = "InvoiceStatus"
        Me.InvoiceStatusColumn.HeaderText = "Status"
        Me.InvoiceStatusColumn.Name = "InvoiceStatusColumn"
        Me.InvoiceStatusColumn.Width = 85
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'ShipmentCity
        '
        Me.ShipmentCity.DataPropertyName = "ShipmentCity"
        Me.ShipmentCity.HeaderText = "Shipment City"
        Me.ShipmentCity.Name = "ShipmentCity"
        Me.ShipmentCity.ReadOnly = True
        '
        'ShipmentState
        '
        Me.ShipmentState.DataPropertyName = "ShipmentState"
        Me.ShipmentState.HeaderText = "Shipment State"
        Me.ShipmentState.Name = "ShipmentState"
        Me.ShipmentState.ReadOnly = True
        '
        'ShipmentZip
        '
        Me.ShipmentZip.DataPropertyName = "ShipmentZip"
        Me.ShipmentZip.HeaderText = "Shipment Zip"
        Me.ShipmentZip.Name = "ShipmentZip"
        Me.ShipmentZip.ReadOnly = True
        '
        'ViewTaxCollected
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.gpxInvoiceData)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvInvoiceQuery)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewTaxCollected"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Sales Tax Summary"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvInvoiceQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceHeaderQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxInvoiceData.ResumeLayout(False)
        Me.gpxInvoiceData.PerformLayout()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MonthTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvInvoiceQuery As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents InvoiceHeaderQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderQueryTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxInvoiceData As System.Windows.Forms.GroupBox
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MonthTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MonthTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MonthTableTableAdapter
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboSONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PrintTaxSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax3Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BilledFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentCity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentState As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentZip As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
