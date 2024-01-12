<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GLTransactionBalanceDetails
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
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkViewByAccountRange = New System.Windows.Forms.CheckBox
        Me.cboGLAccountNumber = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboAccount2 = New System.Windows.Forms.ComboBox
        Me.cboAccountDescription2 = New System.Windows.Forms.ComboBox
        Me.cboAccountDescription = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.Label3 = New System.Windows.Forms.Label
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvGLTransactions = New System.Windows.Forms.DataGridView
        Me.GLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLJournalIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountCashFlowCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionMasterListQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLTransactionMasterListQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListQueryTableAdapter
        Me.dgvTempBalances = New System.Windows.Forms.DataGridView
        Me.PostDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLBeginningBalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLEndingBalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLChangeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDescriptionDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceLineDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTempTransactionBalancesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLTempTransactionBalancesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTempTransactionBalancesTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkFiscalPeriod = New System.Windows.Forms.CheckBox
        Me.cboFiscalYear = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboFiscalPeriod = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvGLTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLTransactionMasterListQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTempBalances, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLTempTransactionBalancesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkViewByAccountRange)
        Me.GroupBox1.Controls.Add(Me.cboGLAccountNumber)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.cboAccount2)
        Me.GroupBox1.Controls.Add(Me.cboAccountDescription2)
        Me.GroupBox1.Controls.Add(Me.cboAccountDescription)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 245)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Account Number"
        '
        'chkViewByAccountRange
        '
        Me.chkViewByAccountRange.AutoSize = True
        Me.chkViewByAccountRange.ForeColor = System.Drawing.Color.Blue
        Me.chkViewByAccountRange.Location = New System.Drawing.Point(19, 140)
        Me.chkViewByAccountRange.Name = "chkViewByAccountRange"
        Me.chkViewByAccountRange.Size = New System.Drawing.Size(231, 17)
        Me.chkViewByAccountRange.TabIndex = 3
        Me.chkViewByAccountRange.Text = "Select second Account if viewing by range."
        Me.chkViewByAccountRange.UseVisualStyleBackColor = True
        '
        'cboGLAccountNumber
        '
        Me.cboGLAccountNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccountNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccountNumber.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccountNumber.DisplayMember = "GLAccountNumber"
        Me.cboGLAccountNumber.FormattingEnabled = True
        Me.cboGLAccountNumber.Location = New System.Drawing.Point(100, 66)
        Me.cboGLAccountNumber.Name = "cboGLAccountNumber"
        Me.cboGLAccountNumber.Size = New System.Drawing.Size(184, 21)
        Me.cboGLAccountNumber.TabIndex = 1
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
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(100, 29)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(184, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboAccount2
        '
        Me.cboAccount2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccount2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccount2.DataSource = Me.GLAccountsBindingSource
        Me.cboAccount2.DisplayMember = "GLAccountNumber"
        Me.cboAccount2.FormattingEnabled = True
        Me.cboAccount2.Location = New System.Drawing.Point(100, 169)
        Me.cboAccount2.Name = "cboAccount2"
        Me.cboAccount2.Size = New System.Drawing.Size(184, 21)
        Me.cboAccount2.TabIndex = 4
        '
        'cboAccountDescription2
        '
        Me.cboAccountDescription2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountDescription2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountDescription2.DataSource = Me.GLAccountsBindingSource
        Me.cboAccountDescription2.DisplayMember = "GLAccountShortDescription"
        Me.cboAccountDescription2.FormattingEnabled = True
        Me.cboAccountDescription2.Location = New System.Drawing.Point(19, 205)
        Me.cboAccountDescription2.Name = "cboAccountDescription2"
        Me.cboAccountDescription2.Size = New System.Drawing.Size(265, 21)
        Me.cboAccountDescription2.TabIndex = 5
        '
        'cboAccountDescription
        '
        Me.cboAccountDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboAccountDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboAccountDescription.FormattingEnabled = True
        Me.cboAccountDescription.Location = New System.Drawing.Point(19, 102)
        Me.cboAccountDescription.Name = "cboAccountDescription"
        Me.cboAccountDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboAccountDescription.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "GL Account"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "GL Account"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Begin Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkDateRange)
        Me.GroupBox2.Controls.Add(Me.dtpEndDate)
        Me.GroupBox2.Controls.Add(Me.dtpBeginDate)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 318)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 139)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "View By Date Range"
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Blue
        Me.chkDateRange.Location = New System.Drawing.Point(22, 31)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(165, 17)
        Me.chkDateRange.TabIndex = 6
        Me.chkDateRange.Text = "Check to view by date range."
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(103, 100)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpEndDate.TabIndex = 8
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(103, 64)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpBeginDate.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "End Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvGLTransactions
        '
        Me.dgvGLTransactions.AllowUserToAddRows = False
        Me.dgvGLTransactions.AllowUserToDeleteRows = False
        Me.dgvGLTransactions.AutoGenerateColumns = False
        Me.dgvGLTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLAccountNumberColumn, Me.GLTransactionKeyColumn, Me.GLTransactionDescriptionColumn, Me.GLTransactionDateColumn, Me.GLTransactionDebitAmountColumn, Me.GLTransactionCreditAmountColumn, Me.GLTransactionCommentColumn, Me.DivisionIDColumn, Me.GLJournalIDColumn, Me.GLBatchNumberColumn, Me.GLReferenceNumberColumn, Me.GLReferenceLineColumn, Me.GLTransactionStatusColumn, Me.GLAccountShortDescriptionColumn, Me.GLAccountCashFlowCodeColumn})
        Me.dgvGLTransactions.DataSource = Me.GLTransactionMasterListQueryBindingSource
        Me.dgvGLTransactions.Location = New System.Drawing.Point(489, 64)
        Me.dgvGLTransactions.Name = "dgvGLTransactions"
        Me.dgvGLTransactions.Size = New System.Drawing.Size(219, 209)
        Me.dgvGLTransactions.TabIndex = 10
        '
        'GLAccountNumberColumn
        '
        Me.GLAccountNumberColumn.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberColumn.HeaderText = "GLAccountNumber"
        Me.GLAccountNumberColumn.Name = "GLAccountNumberColumn"
        '
        'GLTransactionKeyColumn
        '
        Me.GLTransactionKeyColumn.DataPropertyName = "GLTransactionKey"
        Me.GLTransactionKeyColumn.HeaderText = "GLTransactionKey"
        Me.GLTransactionKeyColumn.Name = "GLTransactionKeyColumn"
        '
        'GLTransactionDescriptionColumn
        '
        Me.GLTransactionDescriptionColumn.DataPropertyName = "GLTransactionDescription"
        Me.GLTransactionDescriptionColumn.HeaderText = "GLTransactionDescription"
        Me.GLTransactionDescriptionColumn.Name = "GLTransactionDescriptionColumn"
        '
        'GLTransactionDateColumn
        '
        Me.GLTransactionDateColumn.DataPropertyName = "GLTransactionDate"
        Me.GLTransactionDateColumn.HeaderText = "GLTransactionDate"
        Me.GLTransactionDateColumn.Name = "GLTransactionDateColumn"
        '
        'GLTransactionDebitAmountColumn
        '
        Me.GLTransactionDebitAmountColumn.DataPropertyName = "GLTransactionDebitAmount"
        Me.GLTransactionDebitAmountColumn.HeaderText = "GLTransactionDebitAmount"
        Me.GLTransactionDebitAmountColumn.Name = "GLTransactionDebitAmountColumn"
        '
        'GLTransactionCreditAmountColumn
        '
        Me.GLTransactionCreditAmountColumn.DataPropertyName = "GLTransactionCreditAmount"
        Me.GLTransactionCreditAmountColumn.HeaderText = "GLTransactionCreditAmount"
        Me.GLTransactionCreditAmountColumn.Name = "GLTransactionCreditAmountColumn"
        '
        'GLTransactionCommentColumn
        '
        Me.GLTransactionCommentColumn.DataPropertyName = "GLTransactionComment"
        Me.GLTransactionCommentColumn.HeaderText = "GLTransactionComment"
        Me.GLTransactionCommentColumn.Name = "GLTransactionCommentColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        '
        'GLJournalIDColumn
        '
        Me.GLJournalIDColumn.DataPropertyName = "GLJournalID"
        Me.GLJournalIDColumn.HeaderText = "GLJournalID"
        Me.GLJournalIDColumn.Name = "GLJournalIDColumn"
        '
        'GLBatchNumberColumn
        '
        Me.GLBatchNumberColumn.DataPropertyName = "GLBatchNumber"
        Me.GLBatchNumberColumn.HeaderText = "GLBatchNumber"
        Me.GLBatchNumberColumn.Name = "GLBatchNumberColumn"
        '
        'GLReferenceNumberColumn
        '
        Me.GLReferenceNumberColumn.DataPropertyName = "GLReferenceNumber"
        Me.GLReferenceNumberColumn.HeaderText = "GLReferenceNumber"
        Me.GLReferenceNumberColumn.Name = "GLReferenceNumberColumn"
        '
        'GLReferenceLineColumn
        '
        Me.GLReferenceLineColumn.DataPropertyName = "GLReferenceLine"
        Me.GLReferenceLineColumn.HeaderText = "GLReferenceLine"
        Me.GLReferenceLineColumn.Name = "GLReferenceLineColumn"
        '
        'GLTransactionStatusColumn
        '
        Me.GLTransactionStatusColumn.DataPropertyName = "GLTransactionStatus"
        Me.GLTransactionStatusColumn.HeaderText = "GLTransactionStatus"
        Me.GLTransactionStatusColumn.Name = "GLTransactionStatusColumn"
        '
        'GLAccountShortDescriptionColumn
        '
        Me.GLAccountShortDescriptionColumn.DataPropertyName = "GLAccountShortDescription"
        Me.GLAccountShortDescriptionColumn.HeaderText = "GLAccountShortDescription"
        Me.GLAccountShortDescriptionColumn.Name = "GLAccountShortDescriptionColumn"
        '
        'GLAccountCashFlowCodeColumn
        '
        Me.GLAccountCashFlowCodeColumn.DataPropertyName = "GLAccountCashFlowCode"
        Me.GLAccountCashFlowCodeColumn.HeaderText = "GLAccountCashFlowCode"
        Me.GLAccountCashFlowCodeColumn.Name = "GLAccountCashFlowCodeColumn"
        '
        'GLTransactionMasterListQueryBindingSource
        '
        Me.GLTransactionMasterListQueryBindingSource.DataMember = "GLTransactionMasterListQuery"
        Me.GLTransactionMasterListQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLTransactionMasterListQueryTableAdapter
        '
        Me.GLTransactionMasterListQueryTableAdapter.ClearBeforeFill = True
        '
        'dgvTempBalances
        '
        Me.dgvTempBalances.AllowUserToAddRows = False
        Me.dgvTempBalances.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvTempBalances.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTempBalances.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTempBalances.AutoGenerateColumns = False
        Me.dgvTempBalances.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTempBalances.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTempBalances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTempBalances.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PostDateDataGridViewTextBoxColumn, Me.GLTransactionNumberDataGridViewTextBoxColumn, Me.GLAccountNumberDataGridViewTextBoxColumn1, Me.GLAccountDescriptionDataGridViewTextBoxColumn, Me.GLBeginningBalanceDataGridViewTextBoxColumn, Me.GLDebitAmountDataGridViewTextBoxColumn, Me.GLCreditAmountDataGridViewTextBoxColumn, Me.GLEndingBalanceDataGridViewTextBoxColumn, Me.GLChangeDataGridViewTextBoxColumn, Me.GLCommentDataGridViewTextBoxColumn, Me.GLTransactionDescriptionDataGridViewTextBoxColumn1, Me.GLReferenceNumberDataGridViewTextBoxColumn1, Me.GLReferenceLineDataGridViewTextBoxColumn1})
        Me.dgvTempBalances.DataSource = Me.GLTempTransactionBalancesBindingSource
        Me.dgvTempBalances.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvTempBalances.Location = New System.Drawing.Point(347, 41)
        Me.dgvTempBalances.Name = "dgvTempBalances"
        Me.dgvTempBalances.Size = New System.Drawing.Size(683, 715)
        Me.dgvTempBalances.TabIndex = 18
        Me.dgvTempBalances.TabStop = False
        '
        'PostDateDataGridViewTextBoxColumn
        '
        Me.PostDateDataGridViewTextBoxColumn.DataPropertyName = "PostDate"
        Me.PostDateDataGridViewTextBoxColumn.HeaderText = "Post Date"
        Me.PostDateDataGridViewTextBoxColumn.Name = "PostDateDataGridViewTextBoxColumn"
        Me.PostDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLTransactionNumberDataGridViewTextBoxColumn
        '
        Me.GLTransactionNumberDataGridViewTextBoxColumn.DataPropertyName = "GLTransactionNumber"
        Me.GLTransactionNumberDataGridViewTextBoxColumn.HeaderText = "Trans. #"
        Me.GLTransactionNumberDataGridViewTextBoxColumn.Name = "GLTransactionNumberDataGridViewTextBoxColumn"
        Me.GLTransactionNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLAccountNumberDataGridViewTextBoxColumn1
        '
        Me.GLAccountNumberDataGridViewTextBoxColumn1.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberDataGridViewTextBoxColumn1.HeaderText = "Account #"
        Me.GLAccountNumberDataGridViewTextBoxColumn1.Name = "GLAccountNumberDataGridViewTextBoxColumn1"
        Me.GLAccountNumberDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'GLAccountDescriptionDataGridViewTextBoxColumn
        '
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.DataPropertyName = "GLAccountDescription"
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.Name = "GLAccountDescriptionDataGridViewTextBoxColumn"
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLBeginningBalanceDataGridViewTextBoxColumn
        '
        Me.GLBeginningBalanceDataGridViewTextBoxColumn.DataPropertyName = "GLBeginningBalance"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.GLBeginningBalanceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.GLBeginningBalanceDataGridViewTextBoxColumn.HeaderText = "Beg. Balance"
        Me.GLBeginningBalanceDataGridViewTextBoxColumn.Name = "GLBeginningBalanceDataGridViewTextBoxColumn"
        Me.GLBeginningBalanceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLDebitAmountDataGridViewTextBoxColumn
        '
        Me.GLDebitAmountDataGridViewTextBoxColumn.DataPropertyName = "GLDebitAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.GLDebitAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.GLDebitAmountDataGridViewTextBoxColumn.HeaderText = "Debit"
        Me.GLDebitAmountDataGridViewTextBoxColumn.Name = "GLDebitAmountDataGridViewTextBoxColumn"
        Me.GLDebitAmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLCreditAmountDataGridViewTextBoxColumn
        '
        Me.GLCreditAmountDataGridViewTextBoxColumn.DataPropertyName = "GLCreditAmount"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.GLCreditAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.GLCreditAmountDataGridViewTextBoxColumn.HeaderText = "Credit"
        Me.GLCreditAmountDataGridViewTextBoxColumn.Name = "GLCreditAmountDataGridViewTextBoxColumn"
        Me.GLCreditAmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLEndingBalanceDataGridViewTextBoxColumn
        '
        Me.GLEndingBalanceDataGridViewTextBoxColumn.DataPropertyName = "GLEndingBalance"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.GLEndingBalanceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.GLEndingBalanceDataGridViewTextBoxColumn.HeaderText = "End Balance"
        Me.GLEndingBalanceDataGridViewTextBoxColumn.Name = "GLEndingBalanceDataGridViewTextBoxColumn"
        Me.GLEndingBalanceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLChangeDataGridViewTextBoxColumn
        '
        Me.GLChangeDataGridViewTextBoxColumn.DataPropertyName = "GLChange"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.GLChangeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.GLChangeDataGridViewTextBoxColumn.HeaderText = "Change"
        Me.GLChangeDataGridViewTextBoxColumn.Name = "GLChangeDataGridViewTextBoxColumn"
        Me.GLChangeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLCommentDataGridViewTextBoxColumn
        '
        Me.GLCommentDataGridViewTextBoxColumn.DataPropertyName = "GLComment"
        Me.GLCommentDataGridViewTextBoxColumn.HeaderText = "Comment"
        Me.GLCommentDataGridViewTextBoxColumn.Name = "GLCommentDataGridViewTextBoxColumn"
        '
        'GLTransactionDescriptionDataGridViewTextBoxColumn1
        '
        Me.GLTransactionDescriptionDataGridViewTextBoxColumn1.DataPropertyName = "GLTransactionDescription"
        Me.GLTransactionDescriptionDataGridViewTextBoxColumn1.HeaderText = "Trans. Description"
        Me.GLTransactionDescriptionDataGridViewTextBoxColumn1.Name = "GLTransactionDescriptionDataGridViewTextBoxColumn1"
        '
        'GLReferenceNumberDataGridViewTextBoxColumn1
        '
        Me.GLReferenceNumberDataGridViewTextBoxColumn1.DataPropertyName = "GLReferenceNumber"
        Me.GLReferenceNumberDataGridViewTextBoxColumn1.HeaderText = "Ref. #"
        Me.GLReferenceNumberDataGridViewTextBoxColumn1.Name = "GLReferenceNumberDataGridViewTextBoxColumn1"
        Me.GLReferenceNumberDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'GLReferenceLineDataGridViewTextBoxColumn1
        '
        Me.GLReferenceLineDataGridViewTextBoxColumn1.DataPropertyName = "GLReferenceLine"
        Me.GLReferenceLineDataGridViewTextBoxColumn1.HeaderText = "Ref. Line"
        Me.GLReferenceLineDataGridViewTextBoxColumn1.Name = "GLReferenceLineDataGridViewTextBoxColumn1"
        Me.GLReferenceLineDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'GLTempTransactionBalancesBindingSource
        '
        Me.GLTempTransactionBalancesBindingSource.DataMember = "GLTempTransactionBalances"
        Me.GLTempTransactionBalancesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLTempTransactionBalancesTableAdapter
        '
        Me.GLTempTransactionBalancesTableAdapter.ClearBeforeFill = True
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
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkFiscalPeriod)
        Me.GroupBox3.Controls.Add(Me.cboFiscalYear)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cboFiscalPeriod)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 489)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 139)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "View By Fiscal Period"
        '
        'chkFiscalPeriod
        '
        Me.chkFiscalPeriod.AutoSize = True
        Me.chkFiscalPeriod.ForeColor = System.Drawing.Color.Blue
        Me.chkFiscalPeriod.Location = New System.Drawing.Point(22, 31)
        Me.chkFiscalPeriod.Name = "chkFiscalPeriod"
        Me.chkFiscalPeriod.Size = New System.Drawing.Size(170, 17)
        Me.chkFiscalPeriod.TabIndex = 9
        Me.chkFiscalPeriod.Text = "Check to view by fiscal period."
        Me.chkFiscalPeriod.UseVisualStyleBackColor = True
        '
        'cboFiscalYear
        '
        Me.cboFiscalYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFiscalYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFiscalYear.FormattingEnabled = True
        Me.cboFiscalYear.Items.AddRange(New Object() {"2013", "2014", "2015", "2016", "2017", "2018", "2019"})
        Me.cboFiscalYear.Location = New System.Drawing.Point(103, 100)
        Me.cboFiscalYear.Name = "cboFiscalYear"
        Me.cboFiscalYear.Size = New System.Drawing.Size(184, 21)
        Me.cboFiscalYear.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Year"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFiscalPeriod
        '
        Me.cboFiscalPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFiscalPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFiscalPeriod.FormattingEnabled = True
        Me.cboFiscalPeriod.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboFiscalPeriod.Location = New System.Drawing.Point(103, 64)
        Me.cboFiscalPeriod.Name = "cboFiscalPeriod"
        Me.cboFiscalPeriod.Size = New System.Drawing.Size(184, 21)
        Me.cboFiscalPeriod.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fiscal Period"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewByFilters.Location = New System.Drawing.Point(139, 45)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewByFilters.TabIndex = 12
        Me.cmdViewByFilters.Text = "Enter"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.cmdClear)
        Me.GroupBox4.Controls.Add(Me.cmdViewByFilters)
        Me.GroupBox4.Location = New System.Drawing.Point(28, 711)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(301, 100)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(16, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(268, 20)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Select filters above to run report."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(216, 45)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'GLTransactionBalanceDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvTempBalances)
        Me.Controls.Add(Me.dgvGLTransactions)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GLTransactionBalanceDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation GL Account Details"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvGLTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLTransactionMasterListQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTempBalances, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLTempTransactionBalancesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cboGLAccountNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboAccountDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvGLTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents GLTransactionMasterListQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLTransactionMasterListQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListQueryTableAdapter
    Friend WithEvents dgvTempBalances As System.Windows.Forms.DataGridView
    Friend WithEvents GLTempTransactionBalancesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLTempTransactionBalancesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTempTransactionBalancesTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents GLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLJournalIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountCashFlowCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cboFiscalYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboFiscalPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdClear2 As System.Windows.Forms.Button
    Friend WithEvents cboAccount2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboAccountDescription2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkViewByAccountRange As System.Windows.Forms.CheckBox
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents chkFiscalPeriod As System.Windows.Forms.CheckBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PostDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLBeginningBalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLEndingBalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLChangeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDescriptionDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceLineDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
