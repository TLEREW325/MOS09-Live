<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GLAccountsByDate
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintWTBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxGLData = New System.Windows.Forms.GroupBox
        Me.txtLastArchiveDate = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkArchiveData = New System.Windows.Forms.CheckBox
        Me.cmdBalances2 = New System.Windows.Forms.Button
        Me.cmdFilter2 = New System.Windows.Forms.Button
        Me.chkNonZero = New System.Windows.Forms.CheckBox
        Me.dtpValuationDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GLTransactionMasterListQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvGLValuation = New System.Windows.Forms.DataGridView
        Me.GLAccountNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountShortDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BeginningBalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EndingBalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionValuationFinalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLTransactionValuationFinalTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionValuationFinalTableAdapter
        Me.cmdClear = New System.Windows.Forms.Button
        Me.GLTransactionMasterListQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListQueryTableAdapter
        Me.dgvGLAccounts = New System.Windows.Forms.DataGridView
        Me.GLAccountNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountShortDescriptionColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountDescriptionColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountTypeColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountTypeIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountCashFlowCodeColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxGLData.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLTransactionMasterListQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGLValuation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLTransactionValuationFinalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGLAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintWTBToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintWTBToolStripMenuItem
        '
        Me.PrintWTBToolStripMenuItem.Name = "PrintWTBToolStripMenuItem"
        Me.PrintWTBToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.PrintWTBToolStripMenuItem.Text = "Print WTB"
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
        'gpxGLData
        '
        Me.gpxGLData.Controls.Add(Me.txtLastArchiveDate)
        Me.gpxGLData.Controls.Add(Me.Label4)
        Me.gpxGLData.Controls.Add(Me.chkArchiveData)
        Me.gpxGLData.Controls.Add(Me.cmdBalances2)
        Me.gpxGLData.Controls.Add(Me.cmdFilter2)
        Me.gpxGLData.Controls.Add(Me.chkNonZero)
        Me.gpxGLData.Controls.Add(Me.dtpValuationDate)
        Me.gpxGLData.Controls.Add(Me.Label3)
        Me.gpxGLData.Controls.Add(Me.cboDivisionID)
        Me.gpxGLData.Controls.Add(Me.Label2)
        Me.gpxGLData.Controls.Add(Me.Label1)
        Me.gpxGLData.Location = New System.Drawing.Point(29, 41)
        Me.gpxGLData.Name = "gpxGLData"
        Me.gpxGLData.Size = New System.Drawing.Size(300, 428)
        Me.gpxGLData.TabIndex = 5
        Me.gpxGLData.TabStop = False
        Me.gpxGLData.Text = "GL Valuation Date"
        '
        'txtLastArchiveDate
        '
        Me.txtLastArchiveDate.BackColor = System.Drawing.Color.White
        Me.txtLastArchiveDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastArchiveDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastArchiveDate.Location = New System.Drawing.Point(122, 306)
        Me.txtLastArchiveDate.Name = "txtLastArchiveDate"
        Me.txtLastArchiveDate.ReadOnly = True
        Me.txtLastArchiveDate.Size = New System.Drawing.Size(163, 20)
        Me.txtLastArchiveDate.TabIndex = 20
        Me.txtLastArchiveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 306)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 23)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Last Archive Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkArchiveData
        '
        Me.chkArchiveData.AutoSize = True
        Me.chkArchiveData.ForeColor = System.Drawing.Color.Blue
        Me.chkArchiveData.Location = New System.Drawing.Point(16, 274)
        Me.chkArchiveData.Name = "chkArchiveData"
        Me.chkArchiveData.Size = New System.Drawing.Size(120, 17)
        Me.chkArchiveData.TabIndex = 18
        Me.chkArchiveData.Text = "View Archived Data"
        Me.chkArchiveData.UseVisualStyleBackColor = True
        '
        'cmdBalances2
        '
        Me.cmdBalances2.Enabled = False
        Me.cmdBalances2.Location = New System.Drawing.Point(214, 366)
        Me.cmdBalances2.Name = "cmdBalances2"
        Me.cmdBalances2.Size = New System.Drawing.Size(71, 40)
        Me.cmdBalances2.TabIndex = 17
        Me.cmdBalances2.Text = "GL Balances"
        Me.cmdBalances2.UseVisualStyleBackColor = True
        '
        'cmdFilter2
        '
        Me.cmdFilter2.Location = New System.Drawing.Point(137, 366)
        Me.cmdFilter2.Name = "cmdFilter2"
        Me.cmdFilter2.Size = New System.Drawing.Size(71, 40)
        Me.cmdFilter2.TabIndex = 16
        Me.cmdFilter2.Text = "Apply Filter"
        Me.cmdFilter2.UseVisualStyleBackColor = True
        '
        'chkNonZero
        '
        Me.chkNonZero.AutoSize = True
        Me.chkNonZero.Checked = True
        Me.chkNonZero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNonZero.ForeColor = System.Drawing.Color.Blue
        Me.chkNonZero.Location = New System.Drawing.Point(16, 215)
        Me.chkNonZero.Name = "chkNonZero"
        Me.chkNonZero.Size = New System.Drawing.Size(277, 17)
        Me.chkNonZero.TabIndex = 14
        Me.chkNonZero.Text = "Check here to suppress accounts that have all zeros."
        Me.chkNonZero.UseVisualStyleBackColor = True
        '
        'dtpValuationDate
        '
        Me.dtpValuationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpValuationDate.Location = New System.Drawing.Point(122, 81)
        Me.dtpValuationDate.Name = "dtpValuationDate"
        Me.dtpValuationDate.Size = New System.Drawing.Size(163, 20)
        Me.dtpValuationDate.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(16, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(275, 64)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Select Valuation Date to View / Print Working Trial Balance, and then apply filte" & _
            "r. Datagrid and Print Form will be displayed once you press the GL Balances butt" & _
            "on."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(122, 36)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(163, 21)
        Me.cboDivisionID.TabIndex = 5
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Valuation Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 37)
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
        'GLTransactionMasterListQueryBindingSource
        '
        Me.GLTransactionMasterListQueryBindingSource.DataMember = "GLTransactionMasterListQuery"
        Me.GLTransactionMasterListQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 9
        Me.cmdPrint.Text = "Print WTB"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 10
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvGLValuation
        '
        Me.dgvGLValuation.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvGLValuation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGLValuation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvGLValuation.AutoGenerateColumns = False
        Me.dgvGLValuation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGLValuation.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvGLValuation.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvGLValuation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLValuation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLAccountNumberDataGridViewTextBoxColumn, Me.GLAccountShortDescriptionDataGridViewTextBoxColumn, Me.GLAccountDescriptionDataGridViewTextBoxColumn, Me.BeginningBalanceDataGridViewTextBoxColumn, Me.DebitsDataGridViewTextBoxColumn, Me.CreditsDataGridViewTextBoxColumn, Me.EndingBalanceDataGridViewTextBoxColumn})
        Me.dgvGLValuation.DataSource = Me.GLTransactionValuationFinalBindingSource
        Me.dgvGLValuation.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvGLValuation.Location = New System.Drawing.Point(346, 41)
        Me.dgvGLValuation.Name = "dgvGLValuation"
        Me.dgvGLValuation.ReadOnly = True
        Me.dgvGLValuation.Size = New System.Drawing.Size(684, 713)
        Me.dgvGLValuation.TabIndex = 11
        '
        'GLAccountNumberDataGridViewTextBoxColumn
        '
        Me.GLAccountNumberDataGridViewTextBoxColumn.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberDataGridViewTextBoxColumn.HeaderText = "GL Account Number"
        Me.GLAccountNumberDataGridViewTextBoxColumn.Name = "GLAccountNumberDataGridViewTextBoxColumn"
        Me.GLAccountNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLAccountShortDescriptionDataGridViewTextBoxColumn
        '
        Me.GLAccountShortDescriptionDataGridViewTextBoxColumn.DataPropertyName = "GLAccountShortDescription"
        Me.GLAccountShortDescriptionDataGridViewTextBoxColumn.HeaderText = "Account Description"
        Me.GLAccountShortDescriptionDataGridViewTextBoxColumn.Name = "GLAccountShortDescriptionDataGridViewTextBoxColumn"
        Me.GLAccountShortDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLAccountDescriptionDataGridViewTextBoxColumn
        '
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.DataPropertyName = "GLAccountDescription"
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.HeaderText = "GLAccountDescription"
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.Name = "GLAccountDescriptionDataGridViewTextBoxColumn"
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.Visible = False
        '
        'BeginningBalanceDataGridViewTextBoxColumn
        '
        Me.BeginningBalanceDataGridViewTextBoxColumn.DataPropertyName = "BeginningBalance"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.BeginningBalanceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.BeginningBalanceDataGridViewTextBoxColumn.HeaderText = "Beginning Balance"
        Me.BeginningBalanceDataGridViewTextBoxColumn.Name = "BeginningBalanceDataGridViewTextBoxColumn"
        Me.BeginningBalanceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DebitsDataGridViewTextBoxColumn
        '
        Me.DebitsDataGridViewTextBoxColumn.DataPropertyName = "Debits"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.DebitsDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DebitsDataGridViewTextBoxColumn.HeaderText = "Debits"
        Me.DebitsDataGridViewTextBoxColumn.Name = "DebitsDataGridViewTextBoxColumn"
        Me.DebitsDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CreditsDataGridViewTextBoxColumn
        '
        Me.CreditsDataGridViewTextBoxColumn.DataPropertyName = "Credits"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.CreditsDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.CreditsDataGridViewTextBoxColumn.HeaderText = "Credits"
        Me.CreditsDataGridViewTextBoxColumn.Name = "CreditsDataGridViewTextBoxColumn"
        Me.CreditsDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EndingBalanceDataGridViewTextBoxColumn
        '
        Me.EndingBalanceDataGridViewTextBoxColumn.DataPropertyName = "EndingBalance"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.EndingBalanceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.EndingBalanceDataGridViewTextBoxColumn.HeaderText = "Ending Balance"
        Me.EndingBalanceDataGridViewTextBoxColumn.Name = "EndingBalanceDataGridViewTextBoxColumn"
        Me.EndingBalanceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLTransactionValuationFinalBindingSource
        '
        Me.GLTransactionValuationFinalBindingSource.DataMember = "GLTransactionValuationFinal"
        Me.GLTransactionValuationFinalBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLTransactionValuationFinalTableAdapter
        '
        Me.GLTransactionValuationFinalTableAdapter.ClearBeforeFill = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(805, 772)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'GLTransactionMasterListQueryTableAdapter
        '
        Me.GLTransactionMasterListQueryTableAdapter.ClearBeforeFill = True
        '
        'dgvGLAccounts
        '
        Me.dgvGLAccounts.AllowUserToAddRows = False
        Me.dgvGLAccounts.AllowUserToDeleteRows = False
        Me.dgvGLAccounts.AutoGenerateColumns = False
        Me.dgvGLAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLAccountNumberColumn1, Me.GLAccountShortDescriptionColumn1, Me.GLAccountDescriptionColumn1, Me.GLAccountTypeColumn1, Me.GLAccountTypeIDColumn1, Me.GLAccountCashFlowCodeColumn1})
        Me.dgvGLAccounts.DataSource = Me.GLAccountsBindingSource
        Me.dgvGLAccounts.Location = New System.Drawing.Point(404, 274)
        Me.dgvGLAccounts.Name = "dgvGLAccounts"
        Me.dgvGLAccounts.Size = New System.Drawing.Size(187, 146)
        Me.dgvGLAccounts.TabIndex = 15
        Me.dgvGLAccounts.Visible = False
        '
        'GLAccountNumberColumn1
        '
        Me.GLAccountNumberColumn1.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberColumn1.HeaderText = "GLAccountNumber"
        Me.GLAccountNumberColumn1.Name = "GLAccountNumberColumn1"
        '
        'GLAccountShortDescriptionColumn1
        '
        Me.GLAccountShortDescriptionColumn1.DataPropertyName = "GLAccountShortDescription"
        Me.GLAccountShortDescriptionColumn1.HeaderText = "GLAccountShortDescription"
        Me.GLAccountShortDescriptionColumn1.Name = "GLAccountShortDescriptionColumn1"
        '
        'GLAccountDescriptionColumn1
        '
        Me.GLAccountDescriptionColumn1.DataPropertyName = "GLAccountDescription"
        Me.GLAccountDescriptionColumn1.HeaderText = "GLAccountDescription"
        Me.GLAccountDescriptionColumn1.Name = "GLAccountDescriptionColumn1"
        '
        'GLAccountTypeColumn1
        '
        Me.GLAccountTypeColumn1.DataPropertyName = "GLAccountType"
        Me.GLAccountTypeColumn1.HeaderText = "GLAccountType"
        Me.GLAccountTypeColumn1.Name = "GLAccountTypeColumn1"
        '
        'GLAccountTypeIDColumn1
        '
        Me.GLAccountTypeIDColumn1.DataPropertyName = "GLAccountTypeID"
        Me.GLAccountTypeIDColumn1.HeaderText = "GLAccountTypeID"
        Me.GLAccountTypeIDColumn1.Name = "GLAccountTypeIDColumn1"
        '
        'GLAccountCashFlowCodeColumn1
        '
        Me.GLAccountCashFlowCodeColumn1.DataPropertyName = "GLAccountCashFlowCode"
        Me.GLAccountCashFlowCodeColumn1.HeaderText = "GLAccountCashFlowCode"
        Me.GLAccountCashFlowCodeColumn1.Name = "GLAccountCashFlowCodeColumn1"
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'GLAccountsByDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.dgvGLValuation)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.gpxGLData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvGLAccounts)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GLAccountsByDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation GL Account Balances"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxGLData.ResumeLayout(False)
        Me.gpxGLData.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLTransactionMasterListQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGLValuation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLTransactionValuationFinalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGLAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxGLData As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpValuationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvGLValuation As System.Windows.Forms.DataGridView
    Friend WithEvents GLTransactionValuationFinalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLTransactionValuationFinalTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionValuationFinalTableAdapter
    Friend WithEvents GLAccountNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountShortDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeginningBalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndingBalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkNonZero As System.Windows.Forms.CheckBox
    Friend WithEvents GLTransactionMasterListQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLTransactionMasterListQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListQueryTableAdapter
    Friend WithEvents PrintWTBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvGLAccounts As System.Windows.Forms.DataGridView
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents GLAccountNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountShortDescriptionColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountDescriptionColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountTypeColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountTypeIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountCashFlowCodeColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdBalances2 As System.Windows.Forms.Button
    Friend WithEvents cmdFilter2 As System.Windows.Forms.Button
    Friend WithEvents chkArchiveData As System.Windows.Forms.CheckBox
    Friend WithEvents txtLastArchiveDate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
