<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ARAgedReceivablesDated
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvARInvoiceLines = New System.Windows.Forms.DataGridView
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BilledFreightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARTransactionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARAgingCalculationsFinalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.gpxBatchInfo = New System.Windows.Forms.GroupBox
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpSelectDate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ARAgingCalculationsFinalTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARAgingCalculationsFinalTableAdapter
        Me.dgvFilteredTemp = New System.Windows.Forms.DataGridView
        Me.InvoiceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BilledFreightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentsTermsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiscountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARTransactionKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARAgingTempDateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ARAgingTempDateTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARAgingTempDateTableAdapter
        Me.dgvARAgingDated = New System.Windows.Forms.DataGridView
        Me.InvoiceNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DaysElapsedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AgingLessThan30DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging31To45DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging46To60DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging61To90DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AgingMoreThan90DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARAgingCategoryDatedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ARAgingCategoryDatedTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARAgingCategoryDatedTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdViewDetails = New System.Windows.Forms.Button
        Me.cmdARAging = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtTotalReceivables = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdPrintStatements = New System.Windows.Forms.Button
        Me.rdoCanadian = New System.Windows.Forms.RadioButton
        Me.rdoAmerican = New System.Windows.Forms.RadioButton
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvARInvoiceLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARAgingCalculationsFinalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxBatchInfo.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFilteredTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARAgingTempDateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvARAgingDated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARAgingCategoryDatedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
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
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
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
        'dgvARInvoiceLines
        '
        Me.dgvARInvoiceLines.AllowUserToAddRows = False
        Me.dgvARInvoiceLines.AutoGenerateColumns = False
        Me.dgvARInvoiceLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvARInvoiceLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvARInvoiceLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberColumn, Me.InvoiceDateColumn, Me.SalesOrderNumberColumn, Me.ShipmentNumberColumn, Me.DivisionIDColumn, Me.CustomerIDColumn, Me.CustomerPOColumn, Me.PaymentTermsColumn, Me.CommentColumn, Me.BilledFreightColumn, Me.SalesTaxColumn, Me.ProductTotalColumn, Me.DiscountColumn, Me.InvoiceTotalColumn, Me.PaymentAmountColumn, Me.ARTransactionKeyColumn, Me.PaymentDateColumn, Me.InvoiceAmountOpenColumn})
        Me.dgvARInvoiceLines.DataSource = Me.ARAgingCalculationsFinalBindingSource
        Me.dgvARInvoiceLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvARInvoiceLines.Location = New System.Drawing.Point(335, 41)
        Me.dgvARInvoiceLines.Name = "dgvARInvoiceLines"
        Me.dgvARInvoiceLines.Size = New System.Drawing.Size(695, 616)
        Me.dgvARInvoiceLines.TabIndex = 1
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice Number"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "Sales Order #"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division ID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer ID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Customer PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'BilledFreightColumn
        '
        Me.BilledFreightColumn.DataPropertyName = "BilledFreight"
        Me.BilledFreightColumn.HeaderText = "Billed Freight"
        Me.BilledFreightColumn.Name = "BilledFreightColumn"
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "Sales Tax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        Me.ProductTotalColumn.HeaderText = "Product Total"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        '
        'DiscountColumn
        '
        Me.DiscountColumn.DataPropertyName = "Discount"
        Me.DiscountColumn.HeaderText = "Discount"
        Me.DiscountColumn.Name = "DiscountColumn"
        Me.DiscountColumn.Visible = False
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        '
        'PaymentAmountColumn
        '
        Me.PaymentAmountColumn.DataPropertyName = "PaymentAmount"
        Me.PaymentAmountColumn.HeaderText = "Payment Amount"
        Me.PaymentAmountColumn.Name = "PaymentAmountColumn"
        Me.PaymentAmountColumn.ReadOnly = True
        Me.PaymentAmountColumn.Visible = False
        '
        'ARTransactionKeyColumn
        '
        Me.ARTransactionKeyColumn.DataPropertyName = "ARTransactionKey"
        Me.ARTransactionKeyColumn.HeaderText = "ARTransactionKey"
        Me.ARTransactionKeyColumn.Name = "ARTransactionKeyColumn"
        Me.ARTransactionKeyColumn.ReadOnly = True
        Me.ARTransactionKeyColumn.Visible = False
        '
        'PaymentDateColumn
        '
        Me.PaymentDateColumn.DataPropertyName = "PaymentDate"
        Me.PaymentDateColumn.HeaderText = "Payment Date"
        Me.PaymentDateColumn.Name = "PaymentDateColumn"
        Me.PaymentDateColumn.ReadOnly = True
        Me.PaymentDateColumn.Visible = False
        '
        'InvoiceAmountOpenColumn
        '
        Me.InvoiceAmountOpenColumn.DataPropertyName = "InvoiceAmountOpen"
        Me.InvoiceAmountOpenColumn.HeaderText = "Invoice Amount Open"
        Me.InvoiceAmountOpenColumn.Name = "InvoiceAmountOpenColumn"
        Me.InvoiceAmountOpenColumn.ReadOnly = True
        Me.InvoiceAmountOpenColumn.Visible = False
        '
        'ARAgingCalculationsFinalBindingSource
        '
        Me.ARAgingCalculationsFinalBindingSource.DataMember = "ARAgingCalculationsFinal"
        Me.ARAgingCalculationsFinalBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gpxBatchInfo
        '
        Me.gpxBatchInfo.Controls.Add(Me.rdoCanadian)
        Me.gpxBatchInfo.Controls.Add(Me.rdoAmerican)
        Me.gpxBatchInfo.Controls.Add(Me.cboCustomerName)
        Me.gpxBatchInfo.Controls.Add(Me.cmdView)
        Me.gpxBatchInfo.Controls.Add(Me.cmdClear)
        Me.gpxBatchInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxBatchInfo.Controls.Add(Me.cboCustomerID)
        Me.gpxBatchInfo.Controls.Add(Me.Label7)
        Me.gpxBatchInfo.Controls.Add(Me.dtpSelectDate)
        Me.gpxBatchInfo.Controls.Add(Me.Label6)
        Me.gpxBatchInfo.Controls.Add(Me.Label3)
        Me.gpxBatchInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxBatchInfo.Name = "gpxBatchInfo"
        Me.gpxBatchInfo.Size = New System.Drawing.Size(300, 337)
        Me.gpxBatchInfo.TabIndex = 2
        Me.gpxBatchInfo.TabStop = False
        Me.gpxBatchInfo.Text = "Aging Date Selection"
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(25, 173)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(255, 21)
        Me.cboCustomerName.TabIndex = 30
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(136, 293)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 22
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(209, 293)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 23
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(97, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(183, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(82, 137)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(198, 21)
        Me.cboCustomerID.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(25, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 20)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Customer"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpSelectDate
        '
        Me.dtpSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSelectDate.Location = New System.Drawing.Point(97, 83)
        Me.dtpSelectDate.Name = "dtpSelectDate"
        Me.dtpSelectDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpSelectDate.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(23, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 20)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Aging Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(23, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Division ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 20
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 21
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ARAgingCalculationsFinalTableAdapter
        '
        Me.ARAgingCalculationsFinalTableAdapter.ClearBeforeFill = True
        '
        'dgvFilteredTemp
        '
        Me.dgvFilteredTemp.AllowUserToAddRows = False
        Me.dgvFilteredTemp.AllowUserToDeleteRows = False
        Me.dgvFilteredTemp.AutoGenerateColumns = False
        Me.dgvFilteredTemp.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFilteredTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFilteredTemp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberDataGridViewTextBoxColumn, Me.InvoiceDateDataGridViewTextBoxColumn, Me.SalesOrderNumberDataGridViewTextBoxColumn, Me.ShipmentNumberDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.CustomerIDDataGridViewTextBoxColumn, Me.CustomerPODataGridViewTextBoxColumn, Me.BilledFreightDataGridViewTextBoxColumn, Me.SalesTaxDataGridViewTextBoxColumn, Me.ProductTotalDataGridViewTextBoxColumn, Me.InvoiceTotalDataGridViewTextBoxColumn, Me.PaymentAmountDataGridViewTextBoxColumn, Me.InvoiceAmountOpenDataGridViewTextBoxColumn, Me.PaymentsTermsDataGridViewTextBoxColumn, Me.CommentDataGridViewTextBoxColumn, Me.DiscountDataGridViewTextBoxColumn, Me.PaymentDateDataGridViewTextBoxColumn, Me.ARTransactionKeyDataGridViewTextBoxColumn})
        Me.dgvFilteredTemp.DataSource = Me.ARAgingTempDateBindingSource
        Me.dgvFilteredTemp.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvFilteredTemp.Location = New System.Drawing.Point(335, 41)
        Me.dgvFilteredTemp.Name = "dgvFilteredTemp"
        Me.dgvFilteredTemp.Size = New System.Drawing.Size(695, 616)
        Me.dgvFilteredTemp.TabIndex = 22
        '
        'InvoiceNumberDataGridViewTextBoxColumn
        '
        Me.InvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberDataGridViewTextBoxColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberDataGridViewTextBoxColumn.Name = "InvoiceNumberDataGridViewTextBoxColumn"
        Me.InvoiceNumberDataGridViewTextBoxColumn.Width = 85
        '
        'InvoiceDateDataGridViewTextBoxColumn
        '
        Me.InvoiceDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateDataGridViewTextBoxColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateDataGridViewTextBoxColumn.Name = "InvoiceDateDataGridViewTextBoxColumn"
        Me.InvoiceDateDataGridViewTextBoxColumn.Width = 85
        '
        'SalesOrderNumberDataGridViewTextBoxColumn
        '
        Me.SalesOrderNumberDataGridViewTextBoxColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberDataGridViewTextBoxColumn.HeaderText = "Sales Order #"
        Me.SalesOrderNumberDataGridViewTextBoxColumn.Name = "SalesOrderNumberDataGridViewTextBoxColumn"
        Me.SalesOrderNumberDataGridViewTextBoxColumn.Width = 85
        '
        'ShipmentNumberDataGridViewTextBoxColumn
        '
        Me.ShipmentNumberDataGridViewTextBoxColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberDataGridViewTextBoxColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberDataGridViewTextBoxColumn.Name = "ShipmentNumberDataGridViewTextBoxColumn"
        Me.ShipmentNumberDataGridViewTextBoxColumn.Width = 85
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'CustomerIDDataGridViewTextBoxColumn
        '
        Me.CustomerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDDataGridViewTextBoxColumn.HeaderText = "Customer ID"
        Me.CustomerIDDataGridViewTextBoxColumn.Name = "CustomerIDDataGridViewTextBoxColumn"
        '
        'CustomerPODataGridViewTextBoxColumn
        '
        Me.CustomerPODataGridViewTextBoxColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPODataGridViewTextBoxColumn.HeaderText = "Customer PO"
        Me.CustomerPODataGridViewTextBoxColumn.Name = "CustomerPODataGridViewTextBoxColumn"
        Me.CustomerPODataGridViewTextBoxColumn.Width = 90
        '
        'BilledFreightDataGridViewTextBoxColumn
        '
        Me.BilledFreightDataGridViewTextBoxColumn.DataPropertyName = "BilledFreight"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.BilledFreightDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.BilledFreightDataGridViewTextBoxColumn.HeaderText = "Billed Freight"
        Me.BilledFreightDataGridViewTextBoxColumn.Name = "BilledFreightDataGridViewTextBoxColumn"
        Me.BilledFreightDataGridViewTextBoxColumn.Width = 85
        '
        'SalesTaxDataGridViewTextBoxColumn
        '
        Me.SalesTaxDataGridViewTextBoxColumn.DataPropertyName = "SalesTax"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.SalesTaxDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.SalesTaxDataGridViewTextBoxColumn.HeaderText = "Sales Tax"
        Me.SalesTaxDataGridViewTextBoxColumn.Name = "SalesTaxDataGridViewTextBoxColumn"
        Me.SalesTaxDataGridViewTextBoxColumn.Width = 85
        '
        'ProductTotalDataGridViewTextBoxColumn
        '
        Me.ProductTotalDataGridViewTextBoxColumn.DataPropertyName = "ProductTotal"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ProductTotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ProductTotalDataGridViewTextBoxColumn.HeaderText = "Product Total"
        Me.ProductTotalDataGridViewTextBoxColumn.Name = "ProductTotalDataGridViewTextBoxColumn"
        Me.ProductTotalDataGridViewTextBoxColumn.Width = 85
        '
        'InvoiceTotalDataGridViewTextBoxColumn
        '
        Me.InvoiceTotalDataGridViewTextBoxColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.InvoiceTotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.InvoiceTotalDataGridViewTextBoxColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalDataGridViewTextBoxColumn.Name = "InvoiceTotalDataGridViewTextBoxColumn"
        Me.InvoiceTotalDataGridViewTextBoxColumn.Width = 85
        '
        'PaymentAmountDataGridViewTextBoxColumn
        '
        Me.PaymentAmountDataGridViewTextBoxColumn.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.PaymentAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.PaymentAmountDataGridViewTextBoxColumn.HeaderText = "Payment Amount"
        Me.PaymentAmountDataGridViewTextBoxColumn.Name = "PaymentAmountDataGridViewTextBoxColumn"
        Me.PaymentAmountDataGridViewTextBoxColumn.Width = 85
        '
        'InvoiceAmountOpenDataGridViewTextBoxColumn
        '
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.DataPropertyName = "InvoiceAmountOpen"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.HeaderText = "Invoice Amount Open"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.Name = "InvoiceAmountOpenDataGridViewTextBoxColumn"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn.Width = 85
        '
        'PaymentsTermsDataGridViewTextBoxColumn
        '
        Me.PaymentsTermsDataGridViewTextBoxColumn.DataPropertyName = "PaymentsTerms"
        Me.PaymentsTermsDataGridViewTextBoxColumn.HeaderText = "Payment Terms"
        Me.PaymentsTermsDataGridViewTextBoxColumn.Name = "PaymentsTermsDataGridViewTextBoxColumn"
        Me.PaymentsTermsDataGridViewTextBoxColumn.Width = 85
        '
        'CommentDataGridViewTextBoxColumn
        '
        Me.CommentDataGridViewTextBoxColumn.DataPropertyName = "Comment"
        Me.CommentDataGridViewTextBoxColumn.HeaderText = "Comment"
        Me.CommentDataGridViewTextBoxColumn.Name = "CommentDataGridViewTextBoxColumn"
        '
        'DiscountDataGridViewTextBoxColumn
        '
        Me.DiscountDataGridViewTextBoxColumn.DataPropertyName = "Discount"
        Me.DiscountDataGridViewTextBoxColumn.HeaderText = "Discount"
        Me.DiscountDataGridViewTextBoxColumn.Name = "DiscountDataGridViewTextBoxColumn"
        Me.DiscountDataGridViewTextBoxColumn.Visible = False
        '
        'PaymentDateDataGridViewTextBoxColumn
        '
        Me.PaymentDateDataGridViewTextBoxColumn.DataPropertyName = "PaymentDate"
        Me.PaymentDateDataGridViewTextBoxColumn.HeaderText = "PaymentDate"
        Me.PaymentDateDataGridViewTextBoxColumn.Name = "PaymentDateDataGridViewTextBoxColumn"
        Me.PaymentDateDataGridViewTextBoxColumn.Visible = False
        '
        'ARTransactionKeyDataGridViewTextBoxColumn
        '
        Me.ARTransactionKeyDataGridViewTextBoxColumn.DataPropertyName = "ARTransactionKey"
        Me.ARTransactionKeyDataGridViewTextBoxColumn.HeaderText = "ARTransactionKey"
        Me.ARTransactionKeyDataGridViewTextBoxColumn.Name = "ARTransactionKeyDataGridViewTextBoxColumn"
        Me.ARTransactionKeyDataGridViewTextBoxColumn.Visible = False
        '
        'ARAgingTempDateBindingSource
        '
        Me.ARAgingTempDateBindingSource.DataMember = "ARAgingTempDate"
        Me.ARAgingTempDateBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ARAgingTempDateTableAdapter
        '
        Me.ARAgingTempDateTableAdapter.ClearBeforeFill = True
        '
        'dgvARAgingDated
        '
        Me.dgvARAgingDated.AllowUserToAddRows = False
        Me.dgvARAgingDated.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvARAgingDated.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvARAgingDated.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvARAgingDated.AutoGenerateColumns = False
        Me.dgvARAgingDated.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvARAgingDated.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvARAgingDated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvARAgingDated.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberDataGridViewTextBoxColumn1, Me.InvoiceDateDataGridViewTextBoxColumn1, Me.CustomerIDDataGridViewTextBoxColumn1, Me.InvoiceTotalDataGridViewTextBoxColumn1, Me.InvoiceAmountOpenDataGridViewTextBoxColumn1, Me.DaysElapsedDataGridViewTextBoxColumn, Me.AgingLessThan30DataGridViewTextBoxColumn, Me.Aging31To45DataGridViewTextBoxColumn, Me.Aging46To60DataGridViewTextBoxColumn, Me.Aging61To90DataGridViewTextBoxColumn, Me.AgingMoreThan90DataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn1, Me.SelectDateDataGridViewTextBoxColumn, Me.PaymentAmountDataGridViewTextBoxColumn1, Me.CustomerClassColumn})
        Me.dgvARAgingDated.DataSource = Me.ARAgingCategoryDatedBindingSource
        Me.dgvARAgingDated.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvARAgingDated.Location = New System.Drawing.Point(335, 41)
        Me.dgvARAgingDated.Name = "dgvARAgingDated"
        Me.dgvARAgingDated.Size = New System.Drawing.Size(695, 716)
        Me.dgvARAgingDated.TabIndex = 23
        '
        'InvoiceNumberDataGridViewTextBoxColumn1
        '
        Me.InvoiceNumberDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberDataGridViewTextBoxColumn1.HeaderText = "Invoice #"
        Me.InvoiceNumberDataGridViewTextBoxColumn1.Name = "InvoiceNumberDataGridViewTextBoxColumn1"
        Me.InvoiceNumberDataGridViewTextBoxColumn1.Width = 90
        '
        'InvoiceDateDataGridViewTextBoxColumn1
        '
        Me.InvoiceDateDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateDataGridViewTextBoxColumn1.HeaderText = "Invoice Date"
        Me.InvoiceDateDataGridViewTextBoxColumn1.Name = "InvoiceDateDataGridViewTextBoxColumn1"
        Me.InvoiceDateDataGridViewTextBoxColumn1.Width = 90
        '
        'CustomerIDDataGridViewTextBoxColumn1
        '
        Me.CustomerIDDataGridViewTextBoxColumn1.DataPropertyName = "CustomerID"
        Me.CustomerIDDataGridViewTextBoxColumn1.HeaderText = "Customer ID"
        Me.CustomerIDDataGridViewTextBoxColumn1.Name = "CustomerIDDataGridViewTextBoxColumn1"
        '
        'InvoiceTotalDataGridViewTextBoxColumn1
        '
        Me.InvoiceTotalDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.InvoiceTotalDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle8
        Me.InvoiceTotalDataGridViewTextBoxColumn1.HeaderText = "Invoice Total"
        Me.InvoiceTotalDataGridViewTextBoxColumn1.Name = "InvoiceTotalDataGridViewTextBoxColumn1"
        Me.InvoiceTotalDataGridViewTextBoxColumn1.Width = 85
        '
        'InvoiceAmountOpenDataGridViewTextBoxColumn1
        '
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceAmountOpen"
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle9
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn1.HeaderText = "Open Amount"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn1.Name = "InvoiceAmountOpenDataGridViewTextBoxColumn1"
        Me.InvoiceAmountOpenDataGridViewTextBoxColumn1.Width = 85
        '
        'DaysElapsedDataGridViewTextBoxColumn
        '
        Me.DaysElapsedDataGridViewTextBoxColumn.DataPropertyName = "DaysElapsed"
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = "0"
        Me.DaysElapsedDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.DaysElapsedDataGridViewTextBoxColumn.HeaderText = "Days Elapsed"
        Me.DaysElapsedDataGridViewTextBoxColumn.Name = "DaysElapsedDataGridViewTextBoxColumn"
        Me.DaysElapsedDataGridViewTextBoxColumn.ReadOnly = True
        Me.DaysElapsedDataGridViewTextBoxColumn.Width = 75
        '
        'AgingLessThan30DataGridViewTextBoxColumn
        '
        Me.AgingLessThan30DataGridViewTextBoxColumn.DataPropertyName = "AgingLessThan30"
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = "0"
        Me.AgingLessThan30DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.AgingLessThan30DataGridViewTextBoxColumn.HeaderText = "< 30"
        Me.AgingLessThan30DataGridViewTextBoxColumn.Name = "AgingLessThan30DataGridViewTextBoxColumn"
        Me.AgingLessThan30DataGridViewTextBoxColumn.ReadOnly = True
        Me.AgingLessThan30DataGridViewTextBoxColumn.Width = 85
        '
        'Aging31To45DataGridViewTextBoxColumn
        '
        Me.Aging31To45DataGridViewTextBoxColumn.DataPropertyName = "Aging31To45"
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = "0"
        Me.Aging31To45DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.Aging31To45DataGridViewTextBoxColumn.HeaderText = "31 - 45"
        Me.Aging31To45DataGridViewTextBoxColumn.Name = "Aging31To45DataGridViewTextBoxColumn"
        Me.Aging31To45DataGridViewTextBoxColumn.ReadOnly = True
        Me.Aging31To45DataGridViewTextBoxColumn.Width = 85
        '
        'Aging46To60DataGridViewTextBoxColumn
        '
        Me.Aging46To60DataGridViewTextBoxColumn.DataPropertyName = "Aging46To60"
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = "0"
        Me.Aging46To60DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle13
        Me.Aging46To60DataGridViewTextBoxColumn.HeaderText = "46 - 60"
        Me.Aging46To60DataGridViewTextBoxColumn.Name = "Aging46To60DataGridViewTextBoxColumn"
        Me.Aging46To60DataGridViewTextBoxColumn.ReadOnly = True
        Me.Aging46To60DataGridViewTextBoxColumn.Width = 85
        '
        'Aging61To90DataGridViewTextBoxColumn
        '
        Me.Aging61To90DataGridViewTextBoxColumn.DataPropertyName = "Aging61To90"
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = "0"
        Me.Aging61To90DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle14
        Me.Aging61To90DataGridViewTextBoxColumn.HeaderText = "61 - 90"
        Me.Aging61To90DataGridViewTextBoxColumn.Name = "Aging61To90DataGridViewTextBoxColumn"
        Me.Aging61To90DataGridViewTextBoxColumn.ReadOnly = True
        Me.Aging61To90DataGridViewTextBoxColumn.Width = 85
        '
        'AgingMoreThan90DataGridViewTextBoxColumn
        '
        Me.AgingMoreThan90DataGridViewTextBoxColumn.DataPropertyName = "AgingMoreThan90"
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = "0"
        Me.AgingMoreThan90DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle15
        Me.AgingMoreThan90DataGridViewTextBoxColumn.HeaderText = "> 90"
        Me.AgingMoreThan90DataGridViewTextBoxColumn.Name = "AgingMoreThan90DataGridViewTextBoxColumn"
        Me.AgingMoreThan90DataGridViewTextBoxColumn.ReadOnly = True
        Me.AgingMoreThan90DataGridViewTextBoxColumn.Width = 85
        '
        'DivisionIDDataGridViewTextBoxColumn1
        '
        Me.DivisionIDDataGridViewTextBoxColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.Name = "DivisionIDDataGridViewTextBoxColumn1"
        Me.DivisionIDDataGridViewTextBoxColumn1.Visible = False
        '
        'SelectDateDataGridViewTextBoxColumn
        '
        Me.SelectDateDataGridViewTextBoxColumn.DataPropertyName = "SelectDate"
        Me.SelectDateDataGridViewTextBoxColumn.HeaderText = "SelectDate"
        Me.SelectDateDataGridViewTextBoxColumn.Name = "SelectDateDataGridViewTextBoxColumn"
        Me.SelectDateDataGridViewTextBoxColumn.Visible = False
        '
        'PaymentAmountDataGridViewTextBoxColumn1
        '
        Me.PaymentAmountDataGridViewTextBoxColumn1.DataPropertyName = "PaymentAmount"
        Me.PaymentAmountDataGridViewTextBoxColumn1.HeaderText = "Payment Amount"
        Me.PaymentAmountDataGridViewTextBoxColumn1.Name = "PaymentAmountDataGridViewTextBoxColumn1"
        Me.PaymentAmountDataGridViewTextBoxColumn1.Visible = False
        Me.PaymentAmountDataGridViewTextBoxColumn1.Width = 85
        '
        'CustomerClassColumn
        '
        Me.CustomerClassColumn.DataPropertyName = "CustomerClass"
        Me.CustomerClassColumn.HeaderText = "CustomerClass"
        Me.CustomerClassColumn.Name = "CustomerClassColumn"
        Me.CustomerClassColumn.Visible = False
        '
        'ARAgingCategoryDatedBindingSource
        '
        Me.ARAgingCategoryDatedBindingSource.DataMember = "ARAgingCategoryDated"
        Me.ARAgingCategoryDatedBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ARAgingCategoryDatedTableAdapter
        '
        Me.ARAgingCategoryDatedTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdViewDetails)
        Me.GroupBox1.Controls.Add(Me.cmdARAging)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 429)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 139)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datagrid Viewing Selection"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(98, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 40)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Show AR Aging "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(98, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 40)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Show filtered Invoice data in detail"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewDetails
        '
        Me.cmdViewDetails.Location = New System.Drawing.Point(18, 28)
        Me.cmdViewDetails.Name = "cmdViewDetails"
        Me.cmdViewDetails.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewDetails.TabIndex = 22
        Me.cmdViewDetails.Text = "View Details"
        Me.cmdViewDetails.UseVisualStyleBackColor = True
        '
        'cmdARAging
        '
        Me.cmdARAging.Location = New System.Drawing.Point(18, 78)
        Me.cmdARAging.Name = "cmdARAging"
        Me.cmdARAging.Size = New System.Drawing.Size(71, 40)
        Me.cmdARAging.TabIndex = 23
        Me.cmdARAging.Text = "View Aging"
        Me.cmdARAging.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTotalReceivables)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 736)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 75)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Total Receivables As Of Filter Date"
        '
        'txtTotalReceivables
        '
        Me.txtTotalReceivables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalReceivables.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalReceivables.Location = New System.Drawing.Point(100, 34)
        Me.txtTotalReceivables.Name = "txtTotalReceivables"
        Me.txtTotalReceivables.Size = New System.Drawing.Size(180, 20)
        Me.txtTotalReceivables.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Total"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.cmdPrintStatements)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 607)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 78)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Print Statement(s)"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(19, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 35)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Prints all Customer Statements based on filter"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintStatements
        '
        Me.cmdPrintStatements.Location = New System.Drawing.Point(209, 25)
        Me.cmdPrintStatements.Name = "cmdPrintStatements"
        Me.cmdPrintStatements.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintStatements.TabIndex = 24
        Me.cmdPrintStatements.Text = "Print Statements"
        Me.cmdPrintStatements.UseVisualStyleBackColor = True
        '
        'rdoCanadian
        '
        Me.rdoCanadian.AutoSize = True
        Me.rdoCanadian.Checked = True
        Me.rdoCanadian.Location = New System.Drawing.Point(25, 245)
        Me.rdoCanadian.Name = "rdoCanadian"
        Me.rdoCanadian.Size = New System.Drawing.Size(153, 17)
        Me.rdoCanadian.TabIndex = 1
        Me.rdoCanadian.TabStop = True
        Me.rdoCanadian.Text = "Canadian (for Canada only)"
        Me.rdoCanadian.UseVisualStyleBackColor = True
        '
        'rdoAmerican
        '
        Me.rdoAmerican.AutoSize = True
        Me.rdoAmerican.Location = New System.Drawing.Point(25, 222)
        Me.rdoAmerican.Name = "rdoAmerican"
        Me.rdoAmerican.Size = New System.Drawing.Size(154, 17)
        Me.rdoAmerican.TabIndex = 0
        Me.rdoAmerican.Text = "American (for Canada Only)"
        Me.rdoAmerican.UseVisualStyleBackColor = True
        '
        'ARAgedReceivablesDated
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxBatchInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvARAgingDated)
        Me.Controls.Add(Me.dgvFilteredTemp)
        Me.Controls.Add(Me.dgvARInvoiceLines)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ARAgedReceivablesDated"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Aged Receivables"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvARInvoiceLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARAgingCalculationsFinalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxBatchInfo.ResumeLayout(False)
        Me.gpxBatchInfo.PerformLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFilteredTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARAgingTempDateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvARAgingDated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARAgingCategoryDatedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvARInvoiceLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents gpxBatchInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpSelectDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ARAgingCalculationsFinalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARAgingCalculationsFinalTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARAgingCalculationsFinalTableAdapter
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BilledFreightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARTransactionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvFilteredTemp As System.Windows.Forms.DataGridView
    Friend WithEvents ARAgingTempDateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARAgingTempDateTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARAgingTempDateTableAdapter
    Friend WithEvents dgvARAgingDated As System.Windows.Forms.DataGridView
    Friend WithEvents ARAgingCategoryDatedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARAgingCategoryDatedTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARAgingCategoryDatedTableAdapter
    Friend WithEvents InvoiceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BilledFreightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountOpenDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentsTermsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARTransactionKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewDetails As System.Windows.Forms.Button
    Friend WithEvents cmdARAging As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalReceivables As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintStatements As System.Windows.Forms.Button
    Friend WithEvents rdoCanadian As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAmerican As System.Windows.Forms.RadioButton
    Friend WithEvents InvoiceNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountOpenDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DaysElapsedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgingLessThan30DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging31To45DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging46To60DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging61To90DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgingMoreThan90DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
