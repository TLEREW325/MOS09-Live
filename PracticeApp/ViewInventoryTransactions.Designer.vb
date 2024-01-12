<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInventoryTransactions
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveChangesInDatagridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewHaywardTransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewDowneyTransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewPhoenixTransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLyndhurstTransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLewisvilleTransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewSeattleTransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewBessemerTransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLakeStevensTransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewRentonTransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.gpxInventoryFilters = New System.Windows.Forms.GroupBox
        Me.cboTransType = New System.Windows.Forms.ComboBox
        Me.InventoryTransactionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.chkZeroCost = New System.Windows.Forms.CheckBox
        Me.cboGLDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboGLAccount = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cboTransactionTypeNumber = New System.Windows.Forms.ComboBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.dgvInventoryTransactions = New System.Windows.Forms.DataGridView
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionMathColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryTransactionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryTransactionTableTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkinventoryValue = New System.Windows.Forms.CheckBox
        Me.txtInventoryValue = New System.Windows.Forms.TextBox
        Me.txtInventoryQuantity = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblConsignmentTotals = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxInventoryFilters.SuspendLayout()
        CType(Me.InventoryTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventoryTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveChangesInDatagridToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveChangesInDatagridToolStripMenuItem
        '
        Me.SaveChangesInDatagridToolStripMenuItem.Name = "SaveChangesInDatagridToolStripMenuItem"
        Me.SaveChangesInDatagridToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.SaveChangesInDatagridToolStripMenuItem.Text = "Save Changes in Datagrid"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewHaywardTransactionsToolStripMenuItem, Me.ViewDowneyTransactionsToolStripMenuItem, Me.ViewPhoenixTransactionsToolStripMenuItem, Me.ViewLyndhurstTransactionsToolStripMenuItem, Me.ViewLewisvilleTransactionsToolStripMenuItem, Me.ViewSeattleTransactionsToolStripMenuItem, Me.ViewBessemerTransactionsToolStripMenuItem, Me.ViewLakeStevensTransactionsToolStripMenuItem, Me.ViewRentonTransactionsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ViewHaywardTransactionsToolStripMenuItem
        '
        Me.ViewHaywardTransactionsToolStripMenuItem.Enabled = False
        Me.ViewHaywardTransactionsToolStripMenuItem.Name = "ViewHaywardTransactionsToolStripMenuItem"
        Me.ViewHaywardTransactionsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewHaywardTransactionsToolStripMenuItem.Text = "View Hayward Transactions"
        '
        'ViewDowneyTransactionsToolStripMenuItem
        '
        Me.ViewDowneyTransactionsToolStripMenuItem.Enabled = False
        Me.ViewDowneyTransactionsToolStripMenuItem.Name = "ViewDowneyTransactionsToolStripMenuItem"
        Me.ViewDowneyTransactionsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewDowneyTransactionsToolStripMenuItem.Text = "View Downey Transactions"
        '
        'ViewPhoenixTransactionsToolStripMenuItem
        '
        Me.ViewPhoenixTransactionsToolStripMenuItem.Enabled = False
        Me.ViewPhoenixTransactionsToolStripMenuItem.Name = "ViewPhoenixTransactionsToolStripMenuItem"
        Me.ViewPhoenixTransactionsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewPhoenixTransactionsToolStripMenuItem.Text = "View Phoenix Transactions"
        '
        'ViewLyndhurstTransactionsToolStripMenuItem
        '
        Me.ViewLyndhurstTransactionsToolStripMenuItem.Enabled = False
        Me.ViewLyndhurstTransactionsToolStripMenuItem.Name = "ViewLyndhurstTransactionsToolStripMenuItem"
        Me.ViewLyndhurstTransactionsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewLyndhurstTransactionsToolStripMenuItem.Text = "View Lyndhurst Transactions"
        '
        'ViewLewisvilleTransactionsToolStripMenuItem
        '
        Me.ViewLewisvilleTransactionsToolStripMenuItem.Enabled = False
        Me.ViewLewisvilleTransactionsToolStripMenuItem.Name = "ViewLewisvilleTransactionsToolStripMenuItem"
        Me.ViewLewisvilleTransactionsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewLewisvilleTransactionsToolStripMenuItem.Text = "View Lewisville Transactions"
        '
        'ViewSeattleTransactionsToolStripMenuItem
        '
        Me.ViewSeattleTransactionsToolStripMenuItem.Enabled = False
        Me.ViewSeattleTransactionsToolStripMenuItem.Name = "ViewSeattleTransactionsToolStripMenuItem"
        Me.ViewSeattleTransactionsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewSeattleTransactionsToolStripMenuItem.Text = "View Seattle Transactions"
        '
        'ViewBessemerTransactionsToolStripMenuItem
        '
        Me.ViewBessemerTransactionsToolStripMenuItem.Enabled = False
        Me.ViewBessemerTransactionsToolStripMenuItem.Name = "ViewBessemerTransactionsToolStripMenuItem"
        Me.ViewBessemerTransactionsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewBessemerTransactionsToolStripMenuItem.Text = "View Bessemer Transactions"
        '
        'ViewLakeStevensTransactionsToolStripMenuItem
        '
        Me.ViewLakeStevensTransactionsToolStripMenuItem.Enabled = False
        Me.ViewLakeStevensTransactionsToolStripMenuItem.Name = "ViewLakeStevensTransactionsToolStripMenuItem"
        Me.ViewLakeStevensTransactionsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewLakeStevensTransactionsToolStripMenuItem.Text = "View Lake Stevens Transactions"
        '
        'ViewRentonTransactionsToolStripMenuItem
        '
        Me.ViewRentonTransactionsToolStripMenuItem.Enabled = False
        Me.ViewRentonTransactionsToolStripMenuItem.Name = "ViewRentonTransactionsToolStripMenuItem"
        Me.ViewRentonTransactionsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewRentonTransactionsToolStripMenuItem.Text = "View Renton Transactions"
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
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(101, 542)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(101, 510)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 542)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "End Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 510)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Begin Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(84, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(198, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxInventoryFilters
        '
        Me.gpxInventoryFilters.Controls.Add(Me.cboTransType)
        Me.gpxInventoryFilters.Controls.Add(Me.Label10)
        Me.gpxInventoryFilters.Controls.Add(Me.chkZeroCost)
        Me.gpxInventoryFilters.Controls.Add(Me.cboGLDescription)
        Me.gpxInventoryFilters.Controls.Add(Me.cboGLAccount)
        Me.gpxInventoryFilters.Controls.Add(Me.Label4)
        Me.gpxInventoryFilters.Controls.Add(Me.Label8)
        Me.gpxInventoryFilters.Controls.Add(Me.Label12)
        Me.gpxInventoryFilters.Controls.Add(Me.Label14)
        Me.gpxInventoryFilters.Controls.Add(Me.chkDateRange)
        Me.gpxInventoryFilters.Controls.Add(Me.cboTransactionTypeNumber)
        Me.gpxInventoryFilters.Controls.Add(Me.cmdClear)
        Me.gpxInventoryFilters.Controls.Add(Me.Label7)
        Me.gpxInventoryFilters.Controls.Add(Me.cboPartDescription)
        Me.gpxInventoryFilters.Controls.Add(Me.dtpEndDate)
        Me.gpxInventoryFilters.Controls.Add(Me.cmdViewByFilter)
        Me.gpxInventoryFilters.Controls.Add(Me.dtpBeginDate)
        Me.gpxInventoryFilters.Controls.Add(Me.Label3)
        Me.gpxInventoryFilters.Controls.Add(Me.cboPartNumber)
        Me.gpxInventoryFilters.Controls.Add(Me.Label2)
        Me.gpxInventoryFilters.Controls.Add(Me.cboDivisionID)
        Me.gpxInventoryFilters.Controls.Add(Me.Label5)
        Me.gpxInventoryFilters.Controls.Add(Me.Label1)
        Me.gpxInventoryFilters.Location = New System.Drawing.Point(29, 41)
        Me.gpxInventoryFilters.Name = "gpxInventoryFilters"
        Me.gpxInventoryFilters.Size = New System.Drawing.Size(300, 620)
        Me.gpxInventoryFilters.TabIndex = 0
        Me.gpxInventoryFilters.TabStop = False
        Me.gpxInventoryFilters.Text = "View By Filters"
        '
        'cboTransType
        '
        Me.cboTransType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTransType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTransType.DataSource = Me.InventoryTransactionTableBindingSource
        Me.cboTransType.DisplayMember = "TransactionType"
        Me.cboTransType.FormattingEnabled = True
        Me.cboTransType.Location = New System.Drawing.Point(88, 256)
        Me.cboTransType.Name = "cboTransType"
        Me.cboTransType.Size = New System.Drawing.Size(194, 21)
        Me.cboTransType.TabIndex = 5
        '
        'InventoryTransactionTableBindingSource
        '
        Me.InventoryTransactionTableBindingSource.DataMember = "InventoryTransactionTable"
        Me.InventoryTransactionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(15, 257)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 20)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Trans. Type"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkZeroCost
        '
        Me.chkZeroCost.AutoSize = True
        Me.chkZeroCost.Location = New System.Drawing.Point(18, 389)
        Me.chkZeroCost.Name = "chkZeroCost"
        Me.chkZeroCost.Size = New System.Drawing.Size(215, 17)
        Me.chkZeroCost.TabIndex = 7
        Me.chkZeroCost.Text = "Check to view transactions at zero cost."
        Me.chkZeroCost.UseVisualStyleBackColor = True
        '
        'cboGLDescription
        '
        Me.cboGLDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboGLDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboGLDescription.FormattingEnabled = True
        Me.cboGLDescription.Location = New System.Drawing.Point(15, 216)
        Me.cboGLDescription.Name = "cboGLDescription"
        Me.cboGLDescription.Size = New System.Drawing.Size(267, 21)
        Me.cboGLDescription.TabIndex = 4
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboGLAccount
        '
        Me.cboGLAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccount.DisplayMember = "GLAccountNumber"
        Me.cboGLAccount.FormattingEnabled = True
        Me.cboGLAccount.Location = New System.Drawing.Point(88, 184)
        Me.cboGLAccount.Name = "cboGLAccount"
        Me.cboGLAccount.Size = New System.Drawing.Size(194, 21)
        Me.cboGLAccount.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 20)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "GL Account"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(18, 336)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(261, 29)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Trans. Type # may be Shipment #, Receiver #, Return #, etc. depending on the type" & _
            " of transaction."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(15, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(261, 55)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(15, 435)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 28)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(99, 479)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 8
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cboTransactionTypeNumber
        '
        Me.cboTransactionTypeNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTransactionTypeNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTransactionTypeNumber.DataSource = Me.InventoryTransactionTableBindingSource
        Me.cboTransactionTypeNumber.DisplayMember = "TransactionTypeNumber"
        Me.cboTransactionTypeNumber.FormattingEnabled = True
        Me.cboTransactionTypeNumber.Location = New System.Drawing.Point(88, 303)
        Me.cboTransactionTypeNumber.Name = "cboTransactionTypeNumber"
        Me.cboTransactionTypeNumber.Size = New System.Drawing.Size(194, 21)
        Me.cboTransactionTypeNumber.TabIndex = 6
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 578)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 303)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Trans. Type #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(15, 142)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(267, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(136, 578)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 11
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(69, 110)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(213, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Part #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'dgvInventoryTransactions
        '
        Me.dgvInventoryTransactions.AllowUserToAddRows = False
        Me.dgvInventoryTransactions.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvInventoryTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventoryTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryTransactions.AutoGenerateColumns = False
        Me.dgvInventoryTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryTransactions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInventoryTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransactionNumberColumn, Me.TransactionDateColumn, Me.TransactionTypeColumn, Me.TransactionTypeNumberColumn, Me.TransactionTypeLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.ItemCostColumn, Me.ItemPriceColumn, Me.ExtendedCostColumn, Me.ExtendedAmountColumn, Me.TransactionMathColumn, Me.DivisionIDColumn, Me.GLAccountColumn})
        Me.dgvInventoryTransactions.DataSource = Me.InventoryTransactionTableBindingSource
        Me.dgvInventoryTransactions.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInventoryTransactions.Location = New System.Drawing.Point(344, 41)
        Me.dgvInventoryTransactions.Name = "dgvInventoryTransactions"
        Me.dgvInventoryTransactions.Size = New System.Drawing.Size(686, 722)
        Me.dgvInventoryTransactions.TabIndex = 18
        Me.dgvInventoryTransactions.TabStop = False
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "Trans. #"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.ReadOnly = True
        Me.TransactionNumberColumn.Width = 65
        '
        'TransactionDateColumn
        '
        Me.TransactionDateColumn.DataPropertyName = "TransactionDate"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.TransactionDateColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.TransactionDateColumn.HeaderText = "Date"
        Me.TransactionDateColumn.Name = "TransactionDateColumn"
        Me.TransactionDateColumn.Width = 80
        '
        'TransactionTypeColumn
        '
        Me.TransactionTypeColumn.DataPropertyName = "TransactionType"
        Me.TransactionTypeColumn.HeaderText = "Type"
        Me.TransactionTypeColumn.Name = "TransactionTypeColumn"
        Me.TransactionTypeColumn.ReadOnly = True
        Me.TransactionTypeColumn.Width = 80
        '
        'TransactionTypeNumberColumn
        '
        Me.TransactionTypeNumberColumn.DataPropertyName = "TransactionTypeNumber"
        Me.TransactionTypeNumberColumn.HeaderText = "Type #"
        Me.TransactionTypeNumberColumn.Name = "TransactionTypeNumberColumn"
        Me.TransactionTypeNumberColumn.ReadOnly = True
        Me.TransactionTypeNumberColumn.Width = 80
        '
        'TransactionTypeLineNumberColumn
        '
        Me.TransactionTypeLineNumberColumn.DataPropertyName = "TransactionTypeLineNumber"
        Me.TransactionTypeLineNumberColumn.HeaderText = "Line #"
        Me.TransactionTypeLineNumberColumn.Name = "TransactionTypeLineNumberColumn"
        Me.TransactionTypeLineNumberColumn.ReadOnly = True
        Me.TransactionTypeLineNumberColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle3.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        '
        'ItemCostColumn
        '
        Me.ItemCostColumn.DataPropertyName = "ItemCost"
        DataGridViewCellStyle4.Format = "N4"
        DataGridViewCellStyle4.NullValue = "0"
        Me.ItemCostColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ItemCostColumn.HeaderText = "Item Cost"
        Me.ItemCostColumn.Name = "ItemCostColumn"
        '
        'ItemPriceColumn
        '
        Me.ItemPriceColumn.DataPropertyName = "ItemPrice"
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ItemPriceColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ItemPriceColumn.HeaderText = "Item Price"
        Me.ItemPriceColumn.Name = "ItemPriceColumn"
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.ExtendedCostColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ExtendedCostColumn.HeaderText = "Extended Cost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        '
        'TransactionMathColumn
        '
        Me.TransactionMathColumn.DataPropertyName = "TransactionMath"
        Me.TransactionMathColumn.HeaderText = "Process"
        Me.TransactionMathColumn.Name = "TransactionMathColumn"
        Me.TransactionMathColumn.ReadOnly = True
        Me.TransactionMathColumn.Width = 65
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division ID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'GLAccountColumn
        '
        Me.GLAccountColumn.DataPropertyName = "GLAccount"
        Me.GLAccountColumn.HeaderText = "Inv. Account"
        Me.GLAccountColumn.Name = "GLAccountColumn"
        Me.GLAccountColumn.ReadOnly = True
        '
        'InventoryTransactionTableTableAdapter
        '
        Me.InventoryTransactionTableTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 17
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 16
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkinventoryValue)
        Me.GroupBox1.Controls.Add(Me.txtInventoryValue)
        Me.GroupBox1.Controls.Add(Me.txtInventoryQuantity)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblConsignmentTotals)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 678)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 133)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Inventory Totals"
        '
        'chkinventoryValue
        '
        Me.chkinventoryValue.AutoSize = True
        Me.chkinventoryValue.Location = New System.Drawing.Point(24, 30)
        Me.chkinventoryValue.Name = "chkinventoryValue"
        Me.chkinventoryValue.Size = New System.Drawing.Size(260, 17)
        Me.chkinventoryValue.TabIndex = 13
        Me.chkinventoryValue.Text = "Check for Value/Quantity of Part by the End Date"
        Me.chkinventoryValue.UseVisualStyleBackColor = True
        '
        'txtInventoryValue
        '
        Me.txtInventoryValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryValue.Location = New System.Drawing.Point(99, 93)
        Me.txtInventoryValue.Name = "txtInventoryValue"
        Me.txtInventoryValue.Size = New System.Drawing.Size(183, 20)
        Me.txtInventoryValue.TabIndex = 15
        Me.txtInventoryValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInventoryQuantity
        '
        Me.txtInventoryQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryQuantity.Location = New System.Drawing.Point(99, 65)
        Me.txtInventoryQuantity.Name = "txtInventoryQuantity"
        Me.txtInventoryQuantity.Size = New System.Drawing.Size(183, 20)
        Me.txtInventoryQuantity.TabIndex = 14
        Me.txtInventoryQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 20)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Inv. Value"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Inv. Qty."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConsignmentTotals
        '
        Me.lblConsignmentTotals.ForeColor = System.Drawing.Color.Blue
        Me.lblConsignmentTotals.Location = New System.Drawing.Point(97, 27)
        Me.lblConsignmentTotals.Name = "lblConsignmentTotals"
        Me.lblConsignmentTotals.Size = New System.Drawing.Size(185, 20)
        Me.lblConsignmentTotals.TabIndex = 15
        Me.lblConsignmentTotals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewInventoryTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvInventoryTransactions)
        Me.Controls.Add(Me.gpxInventoryFilters)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewInventoryTransactions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Transactions"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxInventoryFilters.ResumeLayout(False)
        Me.gpxInventoryFilters.PerformLayout()
        CType(Me.InventoryTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventoryTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpxInventoryFilters As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents dgvInventoryTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryTransactionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryTransactionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryTransactionTableTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cboTransactionTypeNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveChangesInDatagridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboGLDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboGLAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionMathColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkZeroCost As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtInventoryValue As System.Windows.Forms.TextBox
    Friend WithEvents txtInventoryQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkinventoryValue As System.Windows.Forms.CheckBox
    Friend WithEvents ViewHaywardTransactionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewDowneyTransactionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewPhoenixTransactionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLyndhurstTransactionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLewisvilleTransactionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewSeattleTransactionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewBessemerTransactionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblConsignmentTotals As System.Windows.Forms.Label
    Friend WithEvents cboTransType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ViewLakeStevensTransactionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewRentonTransactionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
