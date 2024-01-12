<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewGLTransactionListing
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
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.dgvGLTransactions = New System.Windows.Forms.DataGridView
        Me.GLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLJournalIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountCashFlowCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionMasterListQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtLastDate = New System.Windows.Forms.TextBox
        Me.chkViewArchived = New System.Windows.Forms.CheckBox
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.txtReferenceNumber = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboGLAccount = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cboJournal = New System.Windows.Forms.ComboBox
        Me.GLJournalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboGLDescription = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GLJournalsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalsTableAdapter
        Me.GLTransactionMasterListQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListQueryTableAdapter
        Me.dgvArchivedTransactions = New System.Windows.Forms.DataGridView
        Me.GLAccountNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDescriptionColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDebitAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionCreditAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionCommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLJournalIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLBatchNumberColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceNumberColumnArchive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceLineDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionKeyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionMasterListArchiveBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLTransactionMasterListArchiveTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListArchiveTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGLTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLTransactionMasterListQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GLJournalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvArchivedTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLTransactionMasterListArchiveBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.AdminToolStripMenuItem.Text = "Admin"
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
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(217, 724)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 11
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
        Me.cboDivisionID.Location = New System.Drawing.Point(101, 29)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(184, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 30)
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
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'dgvGLTransactions
        '
        Me.dgvGLTransactions.AllowUserToAddRows = False
        Me.dgvGLTransactions.AllowUserToDeleteRows = False
        Me.dgvGLTransactions.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvGLTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGLTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvGLTransactions.AutoGenerateColumns = False
        Me.dgvGLTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvGLTransactions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvGLTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLAccountNumberColumn, Me.GLAccountShortDescriptionColumn, Me.GLTransactionDescriptionColumn, Me.GLTransactionDateColumn, Me.GLTransactionDebitAmountColumn, Me.GLTransactionCreditAmountColumn, Me.GLTransactionCommentColumn, Me.GLBatchNumberColumn, Me.GLReferenceNumberColumn, Me.GLReferenceLineColumn, Me.GLTransactionKeyColumn, Me.GLJournalIDColumn, Me.GLTransactionStatusColumn, Me.GLAccountCashFlowCodeColumn, Me.DivisionIDColumn})
        Me.dgvGLTransactions.DataSource = Me.GLTransactionMasterListQueryBindingSource
        Me.dgvGLTransactions.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvGLTransactions.Location = New System.Drawing.Point(341, 41)
        Me.dgvGLTransactions.Name = "dgvGLTransactions"
        Me.dgvGLTransactions.Size = New System.Drawing.Size(789, 710)
        Me.dgvGLTransactions.TabIndex = 14
        Me.dgvGLTransactions.TabStop = False
        '
        'GLAccountNumberColumn
        '
        Me.GLAccountNumberColumn.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberColumn.HeaderText = "Account #"
        Me.GLAccountNumberColumn.Name = "GLAccountNumberColumn"
        Me.GLAccountNumberColumn.ReadOnly = True
        Me.GLAccountNumberColumn.Width = 85
        '
        'GLAccountShortDescriptionColumn
        '
        Me.GLAccountShortDescriptionColumn.DataPropertyName = "GLAccountShortDescription"
        Me.GLAccountShortDescriptionColumn.HeaderText = "Description"
        Me.GLAccountShortDescriptionColumn.Name = "GLAccountShortDescriptionColumn"
        Me.GLAccountShortDescriptionColumn.ReadOnly = True
        '
        'GLTransactionDescriptionColumn
        '
        Me.GLTransactionDescriptionColumn.DataPropertyName = "GLTransactionDescription"
        Me.GLTransactionDescriptionColumn.HeaderText = "Trans.Description"
        Me.GLTransactionDescriptionColumn.Name = "GLTransactionDescriptionColumn"
        Me.GLTransactionDescriptionColumn.ReadOnly = True
        '
        'GLTransactionDateColumn
        '
        Me.GLTransactionDateColumn.DataPropertyName = "GLTransactionDate"
        Me.GLTransactionDateColumn.HeaderText = "Date"
        Me.GLTransactionDateColumn.Name = "GLTransactionDateColumn"
        Me.GLTransactionDateColumn.ReadOnly = True
        Me.GLTransactionDateColumn.Width = 85
        '
        'GLTransactionDebitAmountColumn
        '
        Me.GLTransactionDebitAmountColumn.DataPropertyName = "GLTransactionDebitAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.GLTransactionDebitAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.GLTransactionDebitAmountColumn.HeaderText = "Debit"
        Me.GLTransactionDebitAmountColumn.Name = "GLTransactionDebitAmountColumn"
        Me.GLTransactionDebitAmountColumn.ReadOnly = True
        Me.GLTransactionDebitAmountColumn.Width = 85
        '
        'GLTransactionCreditAmountColumn
        '
        Me.GLTransactionCreditAmountColumn.DataPropertyName = "GLTransactionCreditAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.GLTransactionCreditAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.GLTransactionCreditAmountColumn.HeaderText = "Credit"
        Me.GLTransactionCreditAmountColumn.Name = "GLTransactionCreditAmountColumn"
        Me.GLTransactionCreditAmountColumn.ReadOnly = True
        Me.GLTransactionCreditAmountColumn.Width = 85
        '
        'GLTransactionCommentColumn
        '
        Me.GLTransactionCommentColumn.DataPropertyName = "GLTransactionComment"
        Me.GLTransactionCommentColumn.HeaderText = "Comment"
        Me.GLTransactionCommentColumn.Name = "GLTransactionCommentColumn"
        Me.GLTransactionCommentColumn.ReadOnly = True
        '
        'GLBatchNumberColumn
        '
        Me.GLBatchNumberColumn.DataPropertyName = "GLBatchNumber"
        Me.GLBatchNumberColumn.HeaderText = "Batch #"
        Me.GLBatchNumberColumn.Name = "GLBatchNumberColumn"
        Me.GLBatchNumberColumn.ReadOnly = True
        Me.GLBatchNumberColumn.Width = 85
        '
        'GLReferenceNumberColumn
        '
        Me.GLReferenceNumberColumn.DataPropertyName = "GLReferenceNumber"
        Me.GLReferenceNumberColumn.HeaderText = "Reference #"
        Me.GLReferenceNumberColumn.Name = "GLReferenceNumberColumn"
        Me.GLReferenceNumberColumn.ReadOnly = True
        Me.GLReferenceNumberColumn.Width = 85
        '
        'GLReferenceLineColumn
        '
        Me.GLReferenceLineColumn.DataPropertyName = "GLReferenceLine"
        Me.GLReferenceLineColumn.HeaderText = "Line #"
        Me.GLReferenceLineColumn.Name = "GLReferenceLineColumn"
        Me.GLReferenceLineColumn.ReadOnly = True
        Me.GLReferenceLineColumn.Width = 85
        '
        'GLTransactionKeyColumn
        '
        Me.GLTransactionKeyColumn.DataPropertyName = "GLTransactionKey"
        Me.GLTransactionKeyColumn.HeaderText = "Trans. #"
        Me.GLTransactionKeyColumn.Name = "GLTransactionKeyColumn"
        Me.GLTransactionKeyColumn.ReadOnly = True
        Me.GLTransactionKeyColumn.Width = 85
        '
        'GLJournalIDColumn
        '
        Me.GLJournalIDColumn.DataPropertyName = "GLJournalID"
        Me.GLJournalIDColumn.HeaderText = "Journal ID"
        Me.GLJournalIDColumn.Name = "GLJournalIDColumn"
        Me.GLJournalIDColumn.ReadOnly = True
        '
        'GLTransactionStatusColumn
        '
        Me.GLTransactionStatusColumn.DataPropertyName = "GLTransactionStatus"
        Me.GLTransactionStatusColumn.HeaderText = "GLTransactionStatus"
        Me.GLTransactionStatusColumn.Name = "GLTransactionStatusColumn"
        Me.GLTransactionStatusColumn.ReadOnly = True
        Me.GLTransactionStatusColumn.Visible = False
        '
        'GLAccountCashFlowCodeColumn
        '
        Me.GLAccountCashFlowCodeColumn.DataPropertyName = "GLAccountCashFlowCode"
        Me.GLAccountCashFlowCodeColumn.HeaderText = "GLAccountCashFlowCode"
        Me.GLAccountCashFlowCodeColumn.Name = "GLAccountCashFlowCodeColumn"
        Me.GLAccountCashFlowCodeColumn.ReadOnly = True
        Me.GLAccountCashFlowCodeColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'GLTransactionMasterListQueryBindingSource
        '
        Me.GLTransactionMasterListQueryBindingSource.DataMember = "GLTransactionMasterListQuery"
        Me.GLTransactionMasterListQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
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
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(113, 687)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpEndDate.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(22, 687)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "End Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(22, 654)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Begin Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(113, 654)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpBeginDate.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtLastDate)
        Me.GroupBox2.Controls.Add(Me.chkViewArchived)
        Me.GroupBox2.Controls.Add(Me.txtBatchNumber)
        Me.GroupBox2.Controls.Add(Me.txtReferenceNumber)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtTextFilter)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cboGLAccount)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dtpEndDate)
        Me.GroupBox2.Controls.Add(Me.dtpBeginDate)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.chkDateRange)
        Me.GroupBox2.Controls.Add(Me.cboJournal)
        Me.GroupBox2.Controls.Add(Me.cmdViewByFilter)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cmdClear)
        Me.GroupBox2.Controls.Add(Me.cboGLDescription)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboDivisionID)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 770)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "View By Filters"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(24, 524)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 20)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Last Archive Date"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLastDate
        '
        Me.txtLastDate.BackColor = System.Drawing.Color.White
        Me.txtLastDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastDate.Location = New System.Drawing.Point(125, 524)
        Me.txtLastDate.Name = "txtLastDate"
        Me.txtLastDate.ReadOnly = True
        Me.txtLastDate.Size = New System.Drawing.Size(160, 20)
        Me.txtLastDate.TabIndex = 55
        Me.txtLastDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkViewArchived
        '
        Me.chkViewArchived.AutoSize = True
        Me.chkViewArchived.ForeColor = System.Drawing.Color.Blue
        Me.chkViewArchived.Location = New System.Drawing.Point(24, 491)
        Me.chkViewArchived.Name = "chkViewArchived"
        Me.chkViewArchived.Size = New System.Drawing.Size(120, 17)
        Me.chkViewArchived.TabIndex = 54
        Me.chkViewArchived.Text = "View Archived Data"
        Me.chkViewArchived.UseVisualStyleBackColor = True
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchNumber.Location = New System.Drawing.Point(101, 341)
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.Size = New System.Drawing.Size(184, 20)
        Me.txtBatchNumber.TabIndex = 5
        '
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenceNumber.Location = New System.Drawing.Point(101, 282)
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(184, 20)
        Me.txtReferenceNumber.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(21, 391)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(264, 33)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Use text filter to filter records by Transaction Description or Transaction Comme" & _
            "nt."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(101, 437)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(184, 20)
        Me.txtTextFilter.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(19, 437)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Text Filter"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 341)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "GL Batch #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 282)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "GL Ref. #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGLAccount
        '
        Me.cboGLAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccount.DisplayMember = "GLAccountNumber"
        Me.cboGLAccount.FormattingEnabled = True
        Me.cboGLAccount.Location = New System.Drawing.Point(101, 130)
        Me.cboGLAccount.Name = "cboGLAccount"
        Me.cboGLAccount.Size = New System.Drawing.Size(184, 21)
        Me.cboGLAccount.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(21, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(267, 40)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(24, 585)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(113, 621)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 7
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cboJournal
        '
        Me.cboJournal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboJournal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboJournal.DataSource = Me.GLJournalsBindingSource
        Me.cboJournal.DisplayMember = "GLJournalID"
        Me.cboJournal.FormattingEnabled = True
        Me.cboJournal.Location = New System.Drawing.Point(101, 222)
        Me.cboJournal.Name = "cboJournal"
        Me.cboJournal.Size = New System.Drawing.Size(184, 21)
        Me.cboJournal.TabIndex = 3
        '
        'GLJournalsBindingSource
        '
        Me.GLJournalsBindingSource.DataMember = "GLJournals"
        Me.GLJournalsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(140, 724)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 10
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 223)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "GL Journal"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGLDescription
        '
        Me.cboGLDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboGLDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboGLDescription.FormattingEnabled = True
        Me.cboGLDescription.Location = New System.Drawing.Point(22, 161)
        Me.cboGLDescription.Name = "cboGLDescription"
        Me.cboGLDescription.Size = New System.Drawing.Size(263, 21)
        Me.cboGLDescription.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "GL Account"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLJournalsTableAdapter
        '
        Me.GLJournalsTableAdapter.ClearBeforeFill = True
        '
        'GLTransactionMasterListQueryTableAdapter
        '
        Me.GLTransactionMasterListQueryTableAdapter.ClearBeforeFill = True
        '
        'dgvArchivedTransactions
        '
        Me.dgvArchivedTransactions.AllowUserToAddRows = False
        Me.dgvArchivedTransactions.AllowUserToDeleteRows = False
        Me.dgvArchivedTransactions.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvArchivedTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvArchivedTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvArchivedTransactions.AutoGenerateColumns = False
        Me.dgvArchivedTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvArchivedTransactions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvArchivedTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchivedTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLAccountNumberDataGridViewTextBoxColumn, Me.GLTransactionDescriptionColumnArchive, Me.GLTransactionDateDataGridViewTextBoxColumn, Me.GLTransactionDebitAmountDataGridViewTextBoxColumn, Me.GLTransactionCreditAmountDataGridViewTextBoxColumn, Me.GLTransactionCommentDataGridViewTextBoxColumn, Me.GLJournalIDDataGridViewTextBoxColumn, Me.GLBatchNumberColumnArchive, Me.GLReferenceNumberColumnArchive, Me.GLReferenceLineDataGridViewTextBoxColumn, Me.GLTransactionStatusDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.GLTransactionKeyDataGridViewTextBoxColumn})
        Me.dgvArchivedTransactions.DataSource = Me.GLTransactionMasterListArchiveBindingSource
        Me.dgvArchivedTransactions.GridColor = System.Drawing.Color.Blue
        Me.dgvArchivedTransactions.Location = New System.Drawing.Point(341, 41)
        Me.dgvArchivedTransactions.Name = "dgvArchivedTransactions"
        Me.dgvArchivedTransactions.ReadOnly = True
        Me.dgvArchivedTransactions.Size = New System.Drawing.Size(789, 710)
        Me.dgvArchivedTransactions.TabIndex = 15
        Me.dgvArchivedTransactions.Visible = False
        '
        'GLAccountNumberDataGridViewTextBoxColumn
        '
        Me.GLAccountNumberDataGridViewTextBoxColumn.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberDataGridViewTextBoxColumn.HeaderText = "Account #"
        Me.GLAccountNumberDataGridViewTextBoxColumn.Name = "GLAccountNumberDataGridViewTextBoxColumn"
        Me.GLAccountNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLTransactionDescriptionColumnArchive
        '
        Me.GLTransactionDescriptionColumnArchive.DataPropertyName = "GLTransactionDescription"
        Me.GLTransactionDescriptionColumnArchive.HeaderText = "Trans. Description"
        Me.GLTransactionDescriptionColumnArchive.Name = "GLTransactionDescriptionColumnArchive"
        Me.GLTransactionDescriptionColumnArchive.ReadOnly = True
        '
        'GLTransactionDateDataGridViewTextBoxColumn
        '
        Me.GLTransactionDateDataGridViewTextBoxColumn.DataPropertyName = "GLTransactionDate"
        Me.GLTransactionDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.GLTransactionDateDataGridViewTextBoxColumn.Name = "GLTransactionDateDataGridViewTextBoxColumn"
        Me.GLTransactionDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLTransactionDebitAmountDataGridViewTextBoxColumn
        '
        Me.GLTransactionDebitAmountDataGridViewTextBoxColumn.DataPropertyName = "GLTransactionDebitAmount"
        Me.GLTransactionDebitAmountDataGridViewTextBoxColumn.HeaderText = "Debit Amount"
        Me.GLTransactionDebitAmountDataGridViewTextBoxColumn.Name = "GLTransactionDebitAmountDataGridViewTextBoxColumn"
        Me.GLTransactionDebitAmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLTransactionCreditAmountDataGridViewTextBoxColumn
        '
        Me.GLTransactionCreditAmountDataGridViewTextBoxColumn.DataPropertyName = "GLTransactionCreditAmount"
        Me.GLTransactionCreditAmountDataGridViewTextBoxColumn.HeaderText = "Credit Amount"
        Me.GLTransactionCreditAmountDataGridViewTextBoxColumn.Name = "GLTransactionCreditAmountDataGridViewTextBoxColumn"
        Me.GLTransactionCreditAmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLTransactionCommentDataGridViewTextBoxColumn
        '
        Me.GLTransactionCommentDataGridViewTextBoxColumn.DataPropertyName = "GLTransactionComment"
        Me.GLTransactionCommentDataGridViewTextBoxColumn.HeaderText = "Comment"
        Me.GLTransactionCommentDataGridViewTextBoxColumn.Name = "GLTransactionCommentDataGridViewTextBoxColumn"
        Me.GLTransactionCommentDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLJournalIDDataGridViewTextBoxColumn
        '
        Me.GLJournalIDDataGridViewTextBoxColumn.DataPropertyName = "GLJournalID"
        Me.GLJournalIDDataGridViewTextBoxColumn.HeaderText = "Journal"
        Me.GLJournalIDDataGridViewTextBoxColumn.Name = "GLJournalIDDataGridViewTextBoxColumn"
        Me.GLJournalIDDataGridViewTextBoxColumn.ReadOnly = True
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
        'GLReferenceLineDataGridViewTextBoxColumn
        '
        Me.GLReferenceLineDataGridViewTextBoxColumn.DataPropertyName = "GLReferenceLine"
        Me.GLReferenceLineDataGridViewTextBoxColumn.HeaderText = "Ref. Line #"
        Me.GLReferenceLineDataGridViewTextBoxColumn.Name = "GLReferenceLineDataGridViewTextBoxColumn"
        Me.GLReferenceLineDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLTransactionStatusDataGridViewTextBoxColumn
        '
        Me.GLTransactionStatusDataGridViewTextBoxColumn.DataPropertyName = "GLTransactionStatus"
        Me.GLTransactionStatusDataGridViewTextBoxColumn.HeaderText = "GLTransactionStatus"
        Me.GLTransactionStatusDataGridViewTextBoxColumn.Name = "GLTransactionStatusDataGridViewTextBoxColumn"
        Me.GLTransactionStatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.GLTransactionStatusDataGridViewTextBoxColumn.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'GLTransactionKeyDataGridViewTextBoxColumn
        '
        Me.GLTransactionKeyDataGridViewTextBoxColumn.DataPropertyName = "GLTransactionKey"
        Me.GLTransactionKeyDataGridViewTextBoxColumn.HeaderText = "GLTransactionKey"
        Me.GLTransactionKeyDataGridViewTextBoxColumn.Name = "GLTransactionKeyDataGridViewTextBoxColumn"
        Me.GLTransactionKeyDataGridViewTextBoxColumn.ReadOnly = True
        Me.GLTransactionKeyDataGridViewTextBoxColumn.Visible = False
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
        'ViewGLTransactionListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.dgvGLTransactions)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvArchivedTransactions)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewGLTransactionListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation GL Transaction Listing"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGLTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLTransactionMasterListQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GLJournalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvArchivedTransactions, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents dgvGLTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboJournal As System.Windows.Forms.ComboBox
    Friend WithEvents GLJournalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalsTableAdapter
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents cboGLDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboGLAccount As System.Windows.Forms.ComboBox
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GLTransactionMasterListQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLTransactionMasterListQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListQueryTableAdapter
    Friend WithEvents AdminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLJournalIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountCashFlowCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtReferenceNumber As System.Windows.Forms.TextBox
    Friend WithEvents chkViewArchived As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtLastDate As System.Windows.Forms.TextBox
    Friend WithEvents dgvArchivedTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents GLTransactionMasterListArchiveBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLTransactionMasterListArchiveTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListArchiveTableAdapter
    Friend WithEvents GLAccountNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDescriptionColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDebitAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionCreditAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionCommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLJournalIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLBatchNumberColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceNumberColumnArchive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceLineDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionKeyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
