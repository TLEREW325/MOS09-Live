<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewARAging
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxAPAging = New System.Windows.Forms.GroupBox
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.SalesTerritoryQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboSalesTerritory = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.ARCustomerPaymentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.rdoCanadian = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.rdoAmerican = New System.Windows.Forms.RadioButton
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdCustomerAccounts = New System.Windows.Forms.Button
        Me.ARAgingCategoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ARCustomerPaymentTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARCustomerPaymentTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvARAging = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentsAppliedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceAmountOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AgingLessThan30Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging31To45Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging46To60Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aging61To90Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AgingMoreThan90Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DaysElapsedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TodaysDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTermsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARAgingCategoryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARAgingCategoryTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdPrintStatements = New System.Windows.Forms.Button
        Me.cmdClear3 = New System.Windows.Forms.Button
        Me.cmdViewByCategory = New System.Windows.Forms.Button
        Me.cboAgingCategory = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAgingTotals = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.SalesTerritoryQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesTerritoryQueryTableAdapter
        Me.PaymentTermsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PaymentTermsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxAPAging.SuspendLayout()
        CType(Me.SalesTerritoryQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARCustomerPaymentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARAgingCategoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvARAging, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gpxAPAging
        '
        Me.gpxAPAging.Controls.Add(Me.cboPaymentTerms)
        Me.gpxAPAging.Controls.Add(Me.Label11)
        Me.gpxAPAging.Controls.Add(Me.cboSalesTerritory)
        Me.gpxAPAging.Controls.Add(Me.Label10)
        Me.gpxAPAging.Controls.Add(Me.Label14)
        Me.gpxAPAging.Controls.Add(Me.chkDateRange)
        Me.gpxAPAging.Controls.Add(Me.Label9)
        Me.gpxAPAging.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxAPAging.Controls.Add(Me.dtpEndDate)
        Me.gpxAPAging.Controls.Add(Me.rdoCanadian)
        Me.gpxAPAging.Controls.Add(Me.Label8)
        Me.gpxAPAging.Controls.Add(Me.cboCustomerName)
        Me.gpxAPAging.Controls.Add(Me.dtpBeginDate)
        Me.gpxAPAging.Controls.Add(Me.Label6)
        Me.gpxAPAging.Controls.Add(Me.Label3)
        Me.gpxAPAging.Controls.Add(Me.rdoAmerican)
        Me.gpxAPAging.Controls.Add(Me.cboDivisionID)
        Me.gpxAPAging.Controls.Add(Me.cboCustomerID)
        Me.gpxAPAging.Controls.Add(Me.cmdView)
        Me.gpxAPAging.Controls.Add(Me.cmdClear)
        Me.gpxAPAging.Controls.Add(Me.Label2)
        Me.gpxAPAging.Controls.Add(Me.Label1)
        Me.gpxAPAging.Location = New System.Drawing.Point(29, 41)
        Me.gpxAPAging.Name = "gpxAPAging"
        Me.gpxAPAging.Size = New System.Drawing.Size(300, 591)
        Me.gpxAPAging.TabIndex = 0
        Me.gpxAPAging.TabStop = False
        Me.gpxAPAging.Text = "View By Customer"
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.DataSource = Me.PaymentTermsBindingSource
        Me.cboPaymentTerms.DisplayMember = "PmtTermsID"
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Location = New System.Drawing.Point(106, 343)
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(179, 21)
        Me.cboPaymentTerms.TabIndex = 7
        '
        'SalesTerritoryQueryBindingSource
        '
        Me.SalesTerritoryQueryBindingSource.DataMember = "SalesTerritoryQuery"
        Me.SalesTerritoryQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 344)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "Payment Terms"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesTerritory
        '
        Me.cboSalesTerritory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesTerritory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesTerritory.DataSource = Me.SalesTerritoryQueryBindingSource
        Me.cboSalesTerritory.DisplayMember = "TerritoryID"
        Me.cboSalesTerritory.FormattingEnabled = True
        Me.cboSalesTerritory.Location = New System.Drawing.Point(106, 300)
        Me.cboSalesTerritory.Name = "cboSalesTerritory"
        Me.cboSalesTerritory.Size = New System.Drawing.Size(179, 21)
        Me.cboSalesTerritory.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 301)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "Sales Territory"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(17, 406)
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
        Me.chkDateRange.Location = New System.Drawing.Point(106, 442)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 8
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Location = New System.Drawing.Point(17, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 20)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Canada Only"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.ARCustomerPaymentBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(106, 257)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(179, 21)
        Me.cboInvoiceNumber.TabIndex = 5
        '
        'ARCustomerPaymentBindingSource
        '
        Me.ARCustomerPaymentBindingSource.DataMember = "ARCustomerPayment"
        Me.ARCustomerPaymentBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(106, 508)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'rdoCanadian
        '
        Me.rdoCanadian.AutoSize = True
        Me.rdoCanadian.Checked = True
        Me.rdoCanadian.Location = New System.Drawing.Point(17, 204)
        Me.rdoCanadian.Name = "rdoCanadian"
        Me.rdoCanadian.Size = New System.Drawing.Size(70, 17)
        Me.rdoCanadian.TabIndex = 4
        Me.rdoCanadian.TabStop = True
        Me.rdoCanadian.Text = "Canadian"
        Me.rdoCanadian.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 508)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(17, 102)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(263, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(106, 473)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 473)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Begin Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 258)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Invoice #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoAmerican
        '
        Me.rdoAmerican.AutoSize = True
        Me.rdoAmerican.Location = New System.Drawing.Point(17, 181)
        Me.rdoAmerican.Name = "rdoAmerican"
        Me.rdoAmerican.Size = New System.Drawing.Size(69, 17)
        Me.rdoAmerican.TabIndex = 3
        Me.rdoAmerican.Text = "American"
        Me.rdoAmerican.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(90, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(195, 21)
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
        Me.cboCustomerID.DropDownWidth = 250
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(88, 71)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(195, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(137, 545)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 11
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 545)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Customer ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCustomerAccounts
        '
        Me.cmdCustomerAccounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCustomerAccounts.Location = New System.Drawing.Point(905, 771)
        Me.cmdCustomerAccounts.Name = "cmdCustomerAccounts"
        Me.cmdCustomerAccounts.Size = New System.Drawing.Size(71, 40)
        Me.cmdCustomerAccounts.TabIndex = 15
        Me.cmdCustomerAccounts.Text = "Customer Accounts"
        Me.cmdCustomerAccounts.UseVisualStyleBackColor = True
        '
        'ARAgingCategoryBindingSource
        '
        Me.ARAgingCategoryBindingSource.DataMember = "ARAgingCategory"
        Me.ARAgingCategoryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ARCustomerPaymentTableAdapter
        '
        Me.ARCustomerPaymentTableAdapter.ClearBeforeFill = True
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
        'dgvARAging
        '
        Me.dgvARAging.AllowUserToAddRows = False
        Me.dgvARAging.AllowUserToDeleteRows = False
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvARAging.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvARAging.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvARAging.AutoGenerateColumns = False
        Me.dgvARAging.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvARAging.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvARAging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvARAging.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.CustomerIDColumn, Me.InvoiceNumberColumn, Me.InvoiceTotalColumn, Me.PaymentsAppliedColumn, Me.InvoiceAmountOpenColumn, Me.AgingLessThan30Column, Me.Aging31To45Column, Me.Aging46To60Column, Me.Aging61To90Column, Me.AgingMoreThan90Column, Me.DaysElapsedColumn, Me.TodaysDateColumn, Me.InvoiceDateColumn, Me.CustomerClassColumn, Me.PaymentTermsColumn})
        Me.dgvARAging.DataSource = Me.ARAgingCategoryBindingSource
        Me.dgvARAging.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvARAging.Location = New System.Drawing.Point(350, 41)
        Me.dgvARAging.Name = "dgvARAging"
        Me.dgvARAging.ReadOnly = True
        Me.dgvARAging.Size = New System.Drawing.Size(780, 724)
        Me.dgvARAging.TabIndex = 18
        Me.dgvARAging.TabStop = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'InvoiceNumberColumn
        '
        Me.InvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn.HeaderText = "Invoice #"
        Me.InvoiceNumberColumn.Name = "InvoiceNumberColumn"
        Me.InvoiceNumberColumn.ReadOnly = True
        Me.InvoiceNumberColumn.Width = 85
        '
        'InvoiceTotalColumn
        '
        Me.InvoiceTotalColumn.DataPropertyName = "InvoiceTotal"
        DataGridViewCellStyle20.Format = "N2"
        DataGridViewCellStyle20.NullValue = "0"
        Me.InvoiceTotalColumn.DefaultCellStyle = DataGridViewCellStyle20
        Me.InvoiceTotalColumn.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumn.Name = "InvoiceTotalColumn"
        Me.InvoiceTotalColumn.ReadOnly = True
        Me.InvoiceTotalColumn.Width = 85
        '
        'PaymentsAppliedColumn
        '
        Me.PaymentsAppliedColumn.DataPropertyName = "PaymentsApplied"
        DataGridViewCellStyle21.Format = "N2"
        DataGridViewCellStyle21.NullValue = "0"
        Me.PaymentsAppliedColumn.DefaultCellStyle = DataGridViewCellStyle21
        Me.PaymentsAppliedColumn.HeaderText = "Payments Applied"
        Me.PaymentsAppliedColumn.Name = "PaymentsAppliedColumn"
        Me.PaymentsAppliedColumn.ReadOnly = True
        Me.PaymentsAppliedColumn.Width = 85
        '
        'InvoiceAmountOpenColumn
        '
        Me.InvoiceAmountOpenColumn.DataPropertyName = "InvoiceAmountOpen"
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.NullValue = "0"
        Me.InvoiceAmountOpenColumn.DefaultCellStyle = DataGridViewCellStyle22
        Me.InvoiceAmountOpenColumn.HeaderText = "Amount Open"
        Me.InvoiceAmountOpenColumn.Name = "InvoiceAmountOpenColumn"
        Me.InvoiceAmountOpenColumn.ReadOnly = True
        Me.InvoiceAmountOpenColumn.Width = 85
        '
        'AgingLessThan30Column
        '
        Me.AgingLessThan30Column.DataPropertyName = "AgingLessThan30"
        DataGridViewCellStyle23.Format = "N2"
        DataGridViewCellStyle23.NullValue = "0"
        Me.AgingLessThan30Column.DefaultCellStyle = DataGridViewCellStyle23
        Me.AgingLessThan30Column.HeaderText = "< 30"
        Me.AgingLessThan30Column.Name = "AgingLessThan30Column"
        Me.AgingLessThan30Column.ReadOnly = True
        Me.AgingLessThan30Column.Width = 85
        '
        'Aging31To45Column
        '
        Me.Aging31To45Column.DataPropertyName = "Aging31To45"
        DataGridViewCellStyle24.Format = "N2"
        DataGridViewCellStyle24.NullValue = "0"
        Me.Aging31To45Column.DefaultCellStyle = DataGridViewCellStyle24
        Me.Aging31To45Column.HeaderText = "31 - 45"
        Me.Aging31To45Column.Name = "Aging31To45Column"
        Me.Aging31To45Column.ReadOnly = True
        Me.Aging31To45Column.Width = 85
        '
        'Aging46To60Column
        '
        Me.Aging46To60Column.DataPropertyName = "Aging46To60"
        DataGridViewCellStyle25.Format = "N2"
        DataGridViewCellStyle25.NullValue = "0"
        Me.Aging46To60Column.DefaultCellStyle = DataGridViewCellStyle25
        Me.Aging46To60Column.HeaderText = "46 - 60"
        Me.Aging46To60Column.Name = "Aging46To60Column"
        Me.Aging46To60Column.ReadOnly = True
        Me.Aging46To60Column.Width = 85
        '
        'Aging61To90Column
        '
        Me.Aging61To90Column.DataPropertyName = "Aging61To90"
        DataGridViewCellStyle26.Format = "N2"
        DataGridViewCellStyle26.NullValue = "0"
        Me.Aging61To90Column.DefaultCellStyle = DataGridViewCellStyle26
        Me.Aging61To90Column.HeaderText = "61 - 90"
        Me.Aging61To90Column.Name = "Aging61To90Column"
        Me.Aging61To90Column.ReadOnly = True
        Me.Aging61To90Column.Width = 85
        '
        'AgingMoreThan90Column
        '
        Me.AgingMoreThan90Column.DataPropertyName = "AgingMoreThan90"
        DataGridViewCellStyle27.Format = "N2"
        DataGridViewCellStyle27.NullValue = "0"
        Me.AgingMoreThan90Column.DefaultCellStyle = DataGridViewCellStyle27
        Me.AgingMoreThan90Column.HeaderText = "> 90"
        Me.AgingMoreThan90Column.Name = "AgingMoreThan90Column"
        Me.AgingMoreThan90Column.ReadOnly = True
        Me.AgingMoreThan90Column.Width = 85
        '
        'DaysElapsedColumn
        '
        Me.DaysElapsedColumn.DataPropertyName = "DaysElapsed"
        Me.DaysElapsedColumn.HeaderText = "DaysElapsed"
        Me.DaysElapsedColumn.Name = "DaysElapsedColumn"
        Me.DaysElapsedColumn.ReadOnly = True
        Me.DaysElapsedColumn.Visible = False
        '
        'TodaysDateColumn
        '
        Me.TodaysDateColumn.DataPropertyName = "TodaysDate"
        Me.TodaysDateColumn.HeaderText = "TodaysDate"
        Me.TodaysDateColumn.Name = "TodaysDateColumn"
        Me.TodaysDateColumn.ReadOnly = True
        Me.TodaysDateColumn.Visible = False
        '
        'InvoiceDateColumn
        '
        Me.InvoiceDateColumn.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumn.HeaderText = "Invoice Date"
        Me.InvoiceDateColumn.Name = "InvoiceDateColumn"
        Me.InvoiceDateColumn.ReadOnly = True
        '
        'CustomerClassColumn
        '
        Me.CustomerClassColumn.DataPropertyName = "CustomerClass"
        Me.CustomerClassColumn.HeaderText = "CustomerClass"
        Me.CustomerClassColumn.Name = "CustomerClassColumn"
        Me.CustomerClassColumn.ReadOnly = True
        Me.CustomerClassColumn.Visible = False
        '
        'PaymentTermsColumn
        '
        Me.PaymentTermsColumn.DataPropertyName = "PaymentTerms"
        Me.PaymentTermsColumn.HeaderText = "Payment Terms"
        Me.PaymentTermsColumn.Name = "PaymentTermsColumn"
        Me.PaymentTermsColumn.ReadOnly = True
        '
        'ARAgingCategoryTableAdapter
        '
        Me.ARAgingCategoryTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmdPrintStatements)
        Me.GroupBox2.Controls.Add(Me.cmdClear3)
        Me.GroupBox2.Controls.Add(Me.cmdViewByCategory)
        Me.GroupBox2.Controls.Add(Me.cboAgingCategory)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 651)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 160)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "View Invoices By Aging Category"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(20, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(188, 30)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Print all Customer Statements for selected Aging Category."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintStatements
        '
        Me.cmdPrintStatements.Location = New System.Drawing.Point(216, 116)
        Me.cmdPrintStatements.Name = "cmdPrintStatements"
        Me.cmdPrintStatements.Size = New System.Drawing.Size(71, 30)
        Me.cmdPrintStatements.TabIndex = 17
        Me.cmdPrintStatements.Text = "Print"
        Me.cmdPrintStatements.UseVisualStyleBackColor = True
        '
        'cmdClear3
        '
        Me.cmdClear3.Location = New System.Drawing.Point(214, 69)
        Me.cmdClear3.Name = "cmdClear3"
        Me.cmdClear3.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear3.TabIndex = 16
        Me.cmdClear3.Text = "Clear"
        Me.cmdClear3.UseVisualStyleBackColor = True
        '
        'cmdViewByCategory
        '
        Me.cmdViewByCategory.Location = New System.Drawing.Point(137, 69)
        Me.cmdViewByCategory.Name = "cmdViewByCategory"
        Me.cmdViewByCategory.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByCategory.TabIndex = 15
        Me.cmdViewByCategory.Text = "View"
        Me.cmdViewByCategory.UseVisualStyleBackColor = True
        '
        'cboAgingCategory
        '
        Me.cboAgingCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAgingCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAgingCategory.FormattingEnabled = True
        Me.cboAgingCategory.Items.AddRange(New Object() {"Less than 30", "31 - 45", "46 - 60", "61 - 90", "Over 90"})
        Me.cboAgingCategory.Location = New System.Drawing.Point(108, 33)
        Me.cboAgingCategory.Name = "cboAgingCategory"
        Me.cboAgingCategory.Size = New System.Drawing.Size(179, 21)
        Me.cboAgingCategory.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Aging Category"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgingTotals
        '
        Me.txtAgingTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAgingTotals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAgingTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgingTotals.Location = New System.Drawing.Point(441, 783)
        Me.txtAgingTotals.Name = "txtAgingTotals"
        Me.txtAgingTotals.Size = New System.Drawing.Size(184, 20)
        Me.txtAgingTotals.TabIndex = 36
        Me.txtAgingTotals.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(349, 783)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Aging Totals"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Visible = False
        '
        'SalesTerritoryQueryTableAdapter
        '
        Me.SalesTerritoryQueryTableAdapter.ClearBeforeFill = True
        '
        'PaymentTermsBindingSource
        '
        Me.PaymentTermsBindingSource.DataMember = "PaymentTerms"
        Me.PaymentTermsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PaymentTermsTableAdapter
        '
        Me.PaymentTermsTableAdapter.ClearBeforeFill = True
        '
        'ViewARAging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.txtAgingTotals)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdCustomerAccounts)
        Me.Controls.Add(Me.dgvARAging)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxAPAging)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewARAging"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Accounts Receivables Aging"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxAPAging.ResumeLayout(False)
        Me.gpxAPAging.PerformLayout()
        CType(Me.SalesTerritoryQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARCustomerPaymentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARAgingCategoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvARAging, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxAPAging As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCustomerAccounts As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ARCustomerPaymentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARCustomerPaymentTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARCustomerPaymentTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvARAging As System.Windows.Forms.DataGridView
    Friend WithEvents ARAgingCategoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARAgingCategoryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARAgingCategoryTableAdapter
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rdoCanadian As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAmerican As System.Windows.Forms.RadioButton
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClear3 As System.Windows.Forms.Button
    Friend WithEvents cmdViewByCategory As System.Windows.Forms.Button
    Friend WithEvents cboAgingCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintStatements As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAgingTotals As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboSalesTerritory As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents SalesTerritoryQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesTerritoryQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesTerritoryQueryTableAdapter
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentsAppliedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmountOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgingLessThan30Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging31To45Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging46To60Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aging61To90Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgingMoreThan90Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DaysElapsedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TodaysDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTermsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PaymentTermsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
End Class
