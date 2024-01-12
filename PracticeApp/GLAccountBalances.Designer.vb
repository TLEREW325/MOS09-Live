<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GLAccountBalances
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
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxJournalTransaction = New System.Windows.Forms.GroupBox
        Me.txtLastArchiveDate = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkArchiveData = New System.Windows.Forms.CheckBox
        Me.chkSuppressZero = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.viewByFilters = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cboYearField = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboGLAccountDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboGLAccount = New System.Windows.Forms.ComboBox
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.MonthTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblMachineHours = New System.Windows.Forms.Label
        Me.lblSetupHours = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtBegBalance = New System.Windows.Forms.TextBox
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.MonthTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MonthTableTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GLAccountsBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvGLAccountTransactions = New System.Windows.Forms.DataGridView
        Me.GLTransactionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLJournalIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionMasterListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLTransactionMasterListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListTableAdapter
        Me.gpxAccountBalance = New System.Windows.Forms.GroupBox
        Me.txtEndBalance = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtGLCreditTotal = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtGLDebitTotal = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GLAccountsBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLJournalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdViewGLListing = New System.Windows.Forms.Button
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.GLJournalsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalsTableAdapter
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.dgvGLArchivedTransactions = New System.Windows.Forms.DataGridView
        Me.GLTransactionKeyColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountNumberColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDescriptionColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDateColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDebitAmountColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionCreditAmountColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionCommentColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLJournalIDColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLBatchNumberColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceNumberColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceLineColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionStatusColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionMasterListArchiveBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLTransactionMasterListArchiveTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListArchiveTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxJournalTransaction.SuspendLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MonthTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLAccountsBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGLAccountTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLTransactionMasterListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxAccountBalance.SuspendLayout()
        CType(Me.GLAccountsBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLJournalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGLArchivedTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLTransactionMasterListArchiveBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gpxJournalTransaction
        '
        Me.gpxJournalTransaction.Controls.Add(Me.txtLastArchiveDate)
        Me.gpxJournalTransaction.Controls.Add(Me.Label1)
        Me.gpxJournalTransaction.Controls.Add(Me.chkArchiveData)
        Me.gpxJournalTransaction.Controls.Add(Me.chkSuppressZero)
        Me.gpxJournalTransaction.Controls.Add(Me.Label12)
        Me.gpxJournalTransaction.Controls.Add(Me.Label14)
        Me.gpxJournalTransaction.Controls.Add(Me.chkDateRange)
        Me.gpxJournalTransaction.Controls.Add(Me.viewByFilters)
        Me.gpxJournalTransaction.Controls.Add(Me.cmdClear)
        Me.gpxJournalTransaction.Controls.Add(Me.dtpEndDate)
        Me.gpxJournalTransaction.Controls.Add(Me.dtpBeginDate)
        Me.gpxJournalTransaction.Controls.Add(Me.cboYearField)
        Me.gpxJournalTransaction.Controls.Add(Me.Label5)
        Me.gpxJournalTransaction.Controls.Add(Me.cboGLAccountDescription)
        Me.gpxJournalTransaction.Controls.Add(Me.cboGLAccount)
        Me.gpxJournalTransaction.Controls.Add(Me.cboMonth)
        Me.gpxJournalTransaction.Controls.Add(Me.Label7)
        Me.gpxJournalTransaction.Controls.Add(Me.cboDivisionID)
        Me.gpxJournalTransaction.Controls.Add(Me.lblMachineHours)
        Me.gpxJournalTransaction.Controls.Add(Me.lblSetupHours)
        Me.gpxJournalTransaction.Controls.Add(Me.Label9)
        Me.gpxJournalTransaction.Controls.Add(Me.Label6)
        Me.gpxJournalTransaction.Location = New System.Drawing.Point(29, 41)
        Me.gpxJournalTransaction.Name = "gpxJournalTransaction"
        Me.gpxJournalTransaction.Size = New System.Drawing.Size(285, 592)
        Me.gpxJournalTransaction.TabIndex = 0
        Me.gpxJournalTransaction.TabStop = False
        Me.gpxJournalTransaction.Text = "GL Account Filters"
        '
        'txtLastArchiveDate
        '
        Me.txtLastArchiveDate.BackColor = System.Drawing.Color.White
        Me.txtLastArchiveDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastArchiveDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastArchiveDate.Location = New System.Drawing.Point(128, 365)
        Me.txtLastArchiveDate.Name = "txtLastArchiveDate"
        Me.txtLastArchiveDate.ReadOnly = True
        Me.txtLastArchiveDate.Size = New System.Drawing.Size(147, 20)
        Me.txtLastArchiveDate.TabIndex = 45
        Me.txtLastArchiveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 365)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 23)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Last Archive Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkArchiveData
        '
        Me.chkArchiveData.AutoSize = True
        Me.chkArchiveData.ForeColor = System.Drawing.Color.Blue
        Me.chkArchiveData.Location = New System.Drawing.Point(18, 333)
        Me.chkArchiveData.Name = "chkArchiveData"
        Me.chkArchiveData.Size = New System.Drawing.Size(120, 17)
        Me.chkArchiveData.TabIndex = 43
        Me.chkArchiveData.Text = "View Archived Data"
        Me.chkArchiveData.UseVisualStyleBackColor = True
        '
        'chkSuppressZero
        '
        Me.chkSuppressZero.AutoSize = True
        Me.chkSuppressZero.Location = New System.Drawing.Point(93, 284)
        Me.chkSuppressZero.Name = "chkSuppressZero"
        Me.chkSuppressZero.Size = New System.Drawing.Size(143, 17)
        Me.chkSuppressZero.TabIndex = 3
        Me.chkSuppressZero.Text = "Suppress Zero Accounts"
        Me.chkSuppressZero.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(15, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(260, 40)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(20, 410)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(255, 33)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(94, 446)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 6
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'viewByFilters
        '
        Me.viewByFilters.Location = New System.Drawing.Point(128, 549)
        Me.viewByFilters.Name = "viewByFilters"
        Me.viewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.viewByFilters.TabIndex = 9
        Me.viewByFilters.Text = "View"
        Me.viewByFilters.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(204, 549)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(93, 512)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpEndDate.TabIndex = 8
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(93, 477)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpBeginDate.TabIndex = 7
        '
        'cboYearField
        '
        Me.cboYearField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboYearField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboYearField.FormattingEnabled = True
        Me.cboYearField.Items.AddRange(New Object() {"2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025"})
        Me.cboYearField.Location = New System.Drawing.Point(91, 235)
        Me.cboYearField.Name = "cboYearField"
        Me.cboYearField.Size = New System.Drawing.Size(184, 21)
        Me.cboYearField.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 236)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 20)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Year"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGLAccountDescription
        '
        Me.cboGLAccountDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccountDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccountDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccountDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboGLAccountDescription.FormattingEnabled = True
        Me.cboGLAccountDescription.Location = New System.Drawing.Point(20, 148)
        Me.cboGLAccountDescription.Name = "cboGLAccountDescription"
        Me.cboGLAccountDescription.Size = New System.Drawing.Size(255, 21)
        Me.cboGLAccountDescription.TabIndex = 2
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboGLAccount
        '
        Me.cboGLAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccount.DisplayMember = "GLAccountNumber"
        Me.cboGLAccount.FormattingEnabled = True
        Me.cboGLAccount.Location = New System.Drawing.Point(96, 112)
        Me.cboGLAccount.Name = "cboGLAccount"
        Me.cboGLAccount.Size = New System.Drawing.Size(179, 21)
        Me.cboGLAccount.TabIndex = 1
        '
        'cboMonth
        '
        Me.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMonth.DataSource = Me.MonthTableBindingSource
        Me.cboMonth.DisplayMember = "MonthName"
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(91, 202)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(184, 21)
        Me.cboMonth.TabIndex = 4
        '
        'MonthTableBindingSource
        '
        Me.MonthTableBindingSource.DataMember = "MonthTable"
        Me.MonthTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 20)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Month"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(91, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(184, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblMachineHours
        '
        Me.lblMachineHours.Location = New System.Drawing.Point(15, 29)
        Me.lblMachineHours.Name = "lblMachineHours"
        Me.lblMachineHours.Size = New System.Drawing.Size(115, 20)
        Me.lblMachineHours.TabIndex = 21
        Me.lblMachineHours.Text = "Division ID"
        Me.lblMachineHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSetupHours
        '
        Me.lblSetupHours.Location = New System.Drawing.Point(15, 113)
        Me.lblSetupHours.Name = "lblSetupHours"
        Me.lblSetupHours.Size = New System.Drawing.Size(115, 20)
        Me.lblSetupHours.TabIndex = 20
        Me.lblSetupHours.Text = "GL Account #"
        Me.lblSetupHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 512)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 20)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "End Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(15, 477)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 20)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Begin Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(20, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 20)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Beg. Balance"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBegBalance
        '
        Me.txtBegBalance.BackColor = System.Drawing.Color.White
        Me.txtBegBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBegBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBegBalance.Location = New System.Drawing.Point(124, 33)
        Me.txtBegBalance.Name = "txtBegBalance"
        Me.txtBegBalance.ReadOnly = True
        Me.txtBegBalance.Size = New System.Drawing.Size(141, 20)
        Me.txtBegBalance.TabIndex = 11
        Me.txtBegBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'MonthTableTableAdapter
        '
        Me.MonthTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GLAccountsBindingSource1
        '
        Me.GLAccountsBindingSource1.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvGLAccountTransactions
        '
        Me.dgvGLAccountTransactions.AllowUserToAddRows = False
        Me.dgvGLAccountTransactions.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvGLAccountTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGLAccountTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvGLAccountTransactions.AutoGenerateColumns = False
        Me.dgvGLAccountTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvGLAccountTransactions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvGLAccountTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLAccountTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLTransactionKeyColumn, Me.GLAccountNumberColumn, Me.GLTransactionDescriptionColumn, Me.GLTransactionDateColumn, Me.GLTransactionDebitAmountColumn, Me.GLTransactionCreditAmountColumn, Me.GLTransactionCommentColumn, Me.GLJournalIDColumn, Me.GLReferenceNumberColumn, Me.GLReferenceLineColumn, Me.GLTransactionStatusColumn, Me.GLBatchNumberColumn, Me.DivisionIDColumn})
        Me.dgvGLAccountTransactions.DataSource = Me.GLTransactionMasterListBindingSource
        Me.dgvGLAccountTransactions.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvGLAccountTransactions.Location = New System.Drawing.Point(330, 48)
        Me.dgvGLAccountTransactions.Name = "dgvGLAccountTransactions"
        Me.dgvGLAccountTransactions.Size = New System.Drawing.Size(700, 702)
        Me.dgvGLAccountTransactions.TabIndex = 28
        Me.dgvGLAccountTransactions.TabStop = False
        '
        'GLTransactionKeyColumn
        '
        Me.GLTransactionKeyColumn.DataPropertyName = "GLTransactionKey"
        Me.GLTransactionKeyColumn.HeaderText = "GL Trans. #"
        Me.GLTransactionKeyColumn.Name = "GLTransactionKeyColumn"
        '
        'GLAccountNumberColumn
        '
        Me.GLAccountNumberColumn.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberColumn.HeaderText = "GL Acct. #"
        Me.GLAccountNumberColumn.Name = "GLAccountNumberColumn"
        '
        'GLTransactionDescriptionColumn
        '
        Me.GLTransactionDescriptionColumn.DataPropertyName = "GLTransactionDescription"
        Me.GLTransactionDescriptionColumn.HeaderText = "Trans. Description"
        Me.GLTransactionDescriptionColumn.Name = "GLTransactionDescriptionColumn"
        '
        'GLTransactionDateColumn
        '
        Me.GLTransactionDateColumn.DataPropertyName = "GLTransactionDate"
        Me.GLTransactionDateColumn.HeaderText = "Trans. Date"
        Me.GLTransactionDateColumn.Name = "GLTransactionDateColumn"
        '
        'GLTransactionDebitAmountColumn
        '
        Me.GLTransactionDebitAmountColumn.DataPropertyName = "GLTransactionDebitAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.GLTransactionDebitAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.GLTransactionDebitAmountColumn.HeaderText = "Debit"
        Me.GLTransactionDebitAmountColumn.Name = "GLTransactionDebitAmountColumn"
        '
        'GLTransactionCreditAmountColumn
        '
        Me.GLTransactionCreditAmountColumn.DataPropertyName = "GLTransactionCreditAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.GLTransactionCreditAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.GLTransactionCreditAmountColumn.HeaderText = "Credit"
        Me.GLTransactionCreditAmountColumn.Name = "GLTransactionCreditAmountColumn"
        '
        'GLTransactionCommentColumn
        '
        Me.GLTransactionCommentColumn.DataPropertyName = "GLTransactionComment"
        Me.GLTransactionCommentColumn.HeaderText = "Comment"
        Me.GLTransactionCommentColumn.Name = "GLTransactionCommentColumn"
        '
        'GLJournalIDColumn
        '
        Me.GLJournalIDColumn.DataPropertyName = "GLJournalID"
        Me.GLJournalIDColumn.HeaderText = "Journal"
        Me.GLJournalIDColumn.Name = "GLJournalIDColumn"
        '
        'GLReferenceNumberColumn
        '
        Me.GLReferenceNumberColumn.DataPropertyName = "GLReferenceNumber"
        Me.GLReferenceNumberColumn.HeaderText = "Ref. #"
        Me.GLReferenceNumberColumn.Name = "GLReferenceNumberColumn"
        '
        'GLReferenceLineColumn
        '
        Me.GLReferenceLineColumn.DataPropertyName = "GLReferenceLine"
        Me.GLReferenceLineColumn.HeaderText = "Ref. Line #"
        Me.GLReferenceLineColumn.Name = "GLReferenceLineColumn"
        '
        'GLTransactionStatusColumn
        '
        Me.GLTransactionStatusColumn.DataPropertyName = "GLTransactionStatus"
        Me.GLTransactionStatusColumn.HeaderText = "GLTransactionStatus"
        Me.GLTransactionStatusColumn.Name = "GLTransactionStatusColumn"
        Me.GLTransactionStatusColumn.Visible = False
        '
        'GLBatchNumberColumn
        '
        Me.GLBatchNumberColumn.DataPropertyName = "GLBatchNumber"
        Me.GLBatchNumberColumn.HeaderText = "GLBatchNumber"
        Me.GLBatchNumberColumn.Name = "GLBatchNumberColumn"
        Me.GLBatchNumberColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'GLTransactionMasterListBindingSource
        '
        Me.GLTransactionMasterListBindingSource.DataMember = "GLTransactionMasterList"
        Me.GLTransactionMasterListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLTransactionMasterListTableAdapter
        '
        Me.GLTransactionMasterListTableAdapter.ClearBeforeFill = True
        '
        'gpxAccountBalance
        '
        Me.gpxAccountBalance.Controls.Add(Me.txtEndBalance)
        Me.gpxAccountBalance.Controls.Add(Me.Label4)
        Me.gpxAccountBalance.Controls.Add(Me.txtGLCreditTotal)
        Me.gpxAccountBalance.Controls.Add(Me.Label3)
        Me.gpxAccountBalance.Controls.Add(Me.txtGLDebitTotal)
        Me.gpxAccountBalance.Controls.Add(Me.Label2)
        Me.gpxAccountBalance.Controls.Add(Me.txtBegBalance)
        Me.gpxAccountBalance.Controls.Add(Me.Label8)
        Me.gpxAccountBalance.Location = New System.Drawing.Point(29, 639)
        Me.gpxAccountBalance.Name = "gpxAccountBalance"
        Me.gpxAccountBalance.Size = New System.Drawing.Size(285, 172)
        Me.gpxAccountBalance.TabIndex = 11
        Me.gpxAccountBalance.TabStop = False
        Me.gpxAccountBalance.Text = "GL Account Balance"
        '
        'txtEndBalance
        '
        Me.txtEndBalance.BackColor = System.Drawing.Color.White
        Me.txtEndBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEndBalance.Location = New System.Drawing.Point(124, 138)
        Me.txtEndBalance.Name = "txtEndBalance"
        Me.txtEndBalance.ReadOnly = True
        Me.txtEndBalance.Size = New System.Drawing.Size(141, 20)
        Me.txtEndBalance.TabIndex = 14
        Me.txtEndBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 20)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Ending Balance"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLCreditTotal
        '
        Me.txtGLCreditTotal.BackColor = System.Drawing.Color.White
        Me.txtGLCreditTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLCreditTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLCreditTotal.Location = New System.Drawing.Point(124, 103)
        Me.txtGLCreditTotal.Name = "txtGLCreditTotal"
        Me.txtGLCreditTotal.ReadOnly = True
        Me.txtGLCreditTotal.Size = New System.Drawing.Size(141, 20)
        Me.txtGLCreditTotal.TabIndex = 13
        Me.txtGLCreditTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 20)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Credits"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGLDebitTotal
        '
        Me.txtGLDebitTotal.BackColor = System.Drawing.Color.White
        Me.txtGLDebitTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLDebitTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGLDebitTotal.Location = New System.Drawing.Point(124, 68)
        Me.txtGLDebitTotal.Name = "txtGLDebitTotal"
        Me.txtGLDebitTotal.ReadOnly = True
        Me.txtGLDebitTotal.Size = New System.Drawing.Size(141, 20)
        Me.txtGLDebitTotal.TabIndex = 12
        Me.txtGLDebitTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 20)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Debits"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLAccountsBindingSource2
        '
        Me.GLAccountsBindingSource2.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource2.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLJournalsBindingSource
        '
        Me.GLJournalsBindingSource.DataMember = "GLJournals"
        Me.GLJournalsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdViewGLListing
        '
        Me.cmdViewGLListing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewGLListing.Location = New System.Drawing.Point(805, 771)
        Me.cmdViewGLListing.Name = "cmdViewGLListing"
        Me.cmdViewGLListing.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewGLListing.TabIndex = 16
        Me.cmdViewGLListing.Text = "View GL Listing"
        Me.cmdViewGLListing.UseVisualStyleBackColor = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'GLJournalsTableAdapter
        '
        Me.GLJournalsTableAdapter.ClearBeforeFill = True
        '
        'dgvGLArchivedTransactions
        '
        Me.dgvGLArchivedTransactions.AllowUserToAddRows = False
        Me.dgvGLArchivedTransactions.AllowUserToDeleteRows = False
        Me.dgvGLArchivedTransactions.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvGLArchivedTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvGLArchivedTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvGLArchivedTransactions.AutoGenerateColumns = False
        Me.dgvGLArchivedTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvGLArchivedTransactions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvGLArchivedTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLArchivedTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLTransactionKeyColumnArchive, Me.GLAccountNumberColumnArchive, Me.GLTransactionDescriptionColumnArchive, Me.GLTransactionDateColumnArchive, Me.GLTransactionDebitAmountColumnArchive, Me.GLTransactionCreditAmountColumnArchive, Me.GLTransactionCommentColumnArchive, Me.GLJournalIDColumnArchive, Me.GLBatchNumberColumnArchive, Me.GLReferenceNumberColumnArchive, Me.GLReferenceLineColumnArchive, Me.GLTransactionStatusColumnArchive, Me.DivisionIDColumnArchive})
        Me.dgvGLArchivedTransactions.DataSource = Me.GLTransactionMasterListArchiveBindingSource
        Me.dgvGLArchivedTransactions.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvGLArchivedTransactions.Location = New System.Drawing.Point(330, 48)
        Me.dgvGLArchivedTransactions.Name = "dgvGLArchivedTransactions"
        Me.dgvGLArchivedTransactions.ReadOnly = True
        Me.dgvGLArchivedTransactions.Size = New System.Drawing.Size(700, 702)
        Me.dgvGLArchivedTransactions.TabIndex = 29
        '
        'GLTransactionKeyColumnArchive
        '
        Me.GLTransactionKeyColumnArchive.DataPropertyName = "GLTransactionKey"
        Me.GLTransactionKeyColumnArchive.HeaderText = "GL Trans. #"
        Me.GLTransactionKeyColumnArchive.Name = "GLTransactionKeyColumnArchive"
        Me.GLTransactionKeyColumnArchive.ReadOnly = True
        '
        'GLAccountNumberColumnArchive
        '
        Me.GLAccountNumberColumnArchive.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberColumnArchive.HeaderText = "GL Acct. #"
        Me.GLAccountNumberColumnArchive.Name = "GLAccountNumberColumnArchive"
        Me.GLAccountNumberColumnArchive.ReadOnly = True
        '
        'GLTransactionDescriptionColumnArchive
        '
        Me.GLTransactionDescriptionColumnArchive.DataPropertyName = "GLTransactionDescription"
        Me.GLTransactionDescriptionColumnArchive.HeaderText = "Trans. Description"
        Me.GLTransactionDescriptionColumnArchive.Name = "GLTransactionDescriptionColumnArchive"
        Me.GLTransactionDescriptionColumnArchive.ReadOnly = True
        '
        'GLTransactionDateColumnArchive
        '
        Me.GLTransactionDateColumnArchive.DataPropertyName = "GLTransactionDate"
        Me.GLTransactionDateColumnArchive.HeaderText = "Date"
        Me.GLTransactionDateColumnArchive.Name = "GLTransactionDateColumnArchive"
        Me.GLTransactionDateColumnArchive.ReadOnly = True
        '
        'GLTransactionDebitAmountColumnArchive
        '
        Me.GLTransactionDebitAmountColumnArchive.DataPropertyName = "GLTransactionDebitAmount"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.GLTransactionDebitAmountColumnArchive.DefaultCellStyle = DataGridViewCellStyle5
        Me.GLTransactionDebitAmountColumnArchive.HeaderText = "Debit"
        Me.GLTransactionDebitAmountColumnArchive.Name = "GLTransactionDebitAmountColumnArchive"
        Me.GLTransactionDebitAmountColumnArchive.ReadOnly = True
        '
        'GLTransactionCreditAmountColumnArchive
        '
        Me.GLTransactionCreditAmountColumnArchive.DataPropertyName = "GLTransactionCreditAmount"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.GLTransactionCreditAmountColumnArchive.DefaultCellStyle = DataGridViewCellStyle6
        Me.GLTransactionCreditAmountColumnArchive.HeaderText = "Credit"
        Me.GLTransactionCreditAmountColumnArchive.Name = "GLTransactionCreditAmountColumnArchive"
        Me.GLTransactionCreditAmountColumnArchive.ReadOnly = True
        '
        'GLTransactionCommentColumnArchive
        '
        Me.GLTransactionCommentColumnArchive.DataPropertyName = "GLTransactionComment"
        Me.GLTransactionCommentColumnArchive.HeaderText = "Comment"
        Me.GLTransactionCommentColumnArchive.Name = "GLTransactionCommentColumnArchive"
        Me.GLTransactionCommentColumnArchive.ReadOnly = True
        '
        'GLJournalIDColumnArchive
        '
        Me.GLJournalIDColumnArchive.DataPropertyName = "GLJournalID"
        Me.GLJournalIDColumnArchive.HeaderText = "Journal"
        Me.GLJournalIDColumnArchive.Name = "GLJournalIDColumnArchive"
        Me.GLJournalIDColumnArchive.ReadOnly = True
        '
        'GLBatchNumberColumnArchive
        '
        Me.GLBatchNumberColumnArchive.DataPropertyName = "GLBatchNumber"
        Me.GLBatchNumberColumnArchive.HeaderText = "Batch #"
        Me.GLBatchNumberColumnArchive.Name = "GLBatchNumberColumnArchive"
        Me.GLBatchNumberColumnArchive.ReadOnly = True
        '
        'GLReferenceNumberColumnArchive
        '
        Me.GLReferenceNumberColumnArchive.DataPropertyName = "GLReferenceNumber"
        Me.GLReferenceNumberColumnArchive.HeaderText = "Ref. #"
        Me.GLReferenceNumberColumnArchive.Name = "GLReferenceNumberColumnArchive"
        Me.GLReferenceNumberColumnArchive.ReadOnly = True
        '
        'GLReferenceLineColumnArchive
        '
        Me.GLReferenceLineColumnArchive.DataPropertyName = "GLReferenceLine"
        Me.GLReferenceLineColumnArchive.HeaderText = "Ref. Line #"
        Me.GLReferenceLineColumnArchive.Name = "GLReferenceLineColumnArchive"
        Me.GLReferenceLineColumnArchive.ReadOnly = True
        '
        'GLTransactionStatusColumnArchive
        '
        Me.GLTransactionStatusColumnArchive.DataPropertyName = "GLTransactionStatus"
        Me.GLTransactionStatusColumnArchive.HeaderText = "GLTransactionStatus"
        Me.GLTransactionStatusColumnArchive.Name = "GLTransactionStatusColumnArchive"
        Me.GLTransactionStatusColumnArchive.ReadOnly = True
        Me.GLTransactionStatusColumnArchive.Visible = False
        '
        'DivisionIDColumnArchive
        '
        Me.DivisionIDColumnArchive.DataPropertyName = "DivisionID"
        Me.DivisionIDColumnArchive.HeaderText = "DivisionID"
        Me.DivisionIDColumnArchive.Name = "DivisionIDColumnArchive"
        Me.DivisionIDColumnArchive.ReadOnly = True
        Me.DivisionIDColumnArchive.Visible = False
        '
        'GLTransactionMasterListArchiveBindingSource
        '
        Me.GLTransactionMasterListArchiveBindingSource.DataMember = "GLTransactionMasterListArchive"
        Me.GLTransactionMasterListArchiveBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLTransactionMasterListArchiveTableAdapter
        '
        Me.GLTransactionMasterListArchiveTableAdapter.ClearBeforeFill = True
        '
        'GLAccountBalances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdViewGLListing)
        Me.Controls.Add(Me.gpxAccountBalance)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxJournalTransaction)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvGLAccountTransactions)
        Me.Controls.Add(Me.dgvGLArchivedTransactions)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GLAccountBalances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation General Ledger Account Balances"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxJournalTransaction.ResumeLayout(False)
        Me.gpxJournalTransaction.PerformLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MonthTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLAccountsBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGLAccountTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLTransactionMasterListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxAccountBalance.ResumeLayout(False)
        Me.gpxAccountBalance.PerformLayout()
        CType(Me.GLAccountsBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLJournalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGLArchivedTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLTransactionMasterListArchiveBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxJournalTransaction As System.Windows.Forms.GroupBox
    Friend WithEvents cboGLAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBegBalance As System.Windows.Forms.TextBox
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblMachineHours As System.Windows.Forms.Label
    Friend WithEvents lblSetupHours As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents MonthTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MonthTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MonthTableTableAdapter
    Friend WithEvents cboGLAccountDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvGLAccountTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents GLTransactionMasterListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLTransactionMasterListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListTableAdapter
    Friend WithEvents gpxAccountBalance As System.Windows.Forms.GroupBox
    Friend WithEvents txtEndBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGLCreditTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGLDebitTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdViewGLListing As System.Windows.Forms.Button
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents GLAccountsBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalsTableAdapter
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cboYearField As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents viewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents chkSuppressZero As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLastArchiveDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkArchiveData As System.Windows.Forms.CheckBox
    Friend WithEvents dgvGLArchivedTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents GLTransactionMasterListArchiveBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLTransactionMasterListArchiveTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListArchiveTableAdapter
    Friend WithEvents GLTransactionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLJournalIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionKeyColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountNumberColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDescriptionColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDateColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDebitAmountColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionCreditAmountColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionCommentColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLJournalIDColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLBatchNumberColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceNumberColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceLineColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionStatusColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
