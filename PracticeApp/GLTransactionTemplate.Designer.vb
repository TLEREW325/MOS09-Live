<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GLTransactionTemplate
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteDateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboGLTemplateName = New System.Windows.Forms.ComboBox
        Me.GLJournalTemplateHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dtpTemplateDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdClearLines = New System.Windows.Forms.Button
        Me.cmdAddLine = New System.Windows.Forms.Button
        Me.cboGLAccount = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboGLDescription = New System.Windows.Forms.ComboBox
        Me.txtTransactionComment = New System.Windows.Forms.TextBox
        Me.txtDebitAmount = New System.Windows.Forms.TextBox
        Me.txtCreditAmount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboGLJournalID = New System.Windows.Forms.ComboBox
        Me.GLJournalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtJournalComment = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvTemplateLines = New System.Windows.Forms.DataGridView
        Me.GLLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTemplateNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLJournalTemplateLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLJournalTemplateLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalTemplateLinesTableAdapter
        Me.GLJournalTemplateHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalTemplateHeaderTableAdapter
        Me.GLJournalsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalsTableAdapter
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.txtDivisionID = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboDeleteLine = New System.Windows.Forms.ComboBox
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtDifference = New System.Windows.Forms.TextBox
        Me.txtDebitTotal = New System.Windows.Forms.TextBox
        Me.txtCreditTotal = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.tabLineControl = New System.Windows.Forms.TabControl
        Me.tabAddLine = New System.Windows.Forms.TabPage
        Me.tabInsertLine = New System.Windows.Forms.TabPage
        Me.numLineNumber = New System.Windows.Forms.NumericUpDown
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtInsertComment = New System.Windows.Forms.TextBox
        Me.cmdInsertLine = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboInsertGLAccount = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboInsertGLDescription = New System.Windows.Forms.ComboBox
        Me.txtInsertCredit = New System.Windows.Forms.TextBox
        Me.txtInsertDebit = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GLJournalTemplateHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GLJournalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTemplateLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLJournalTemplateLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tabLineControl.SuspendLayout()
        Me.tabAddLine.SuspendLayout()
        Me.tabInsertLine.SuspendLayout()
        CType(Me.numLineNumber, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearDataToolStripMenuItem, Me.SaveDataToolStripMenuItem, Me.DeleteDateToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear Data"
        '
        'SaveDataToolStripMenuItem
        '
        Me.SaveDataToolStripMenuItem.Name = "SaveDataToolStripMenuItem"
        Me.SaveDataToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.SaveDataToolStripMenuItem.Text = "Save Data"
        '
        'DeleteDateToolStripMenuItem
        '
        Me.DeleteDateToolStripMenuItem.Name = "DeleteDateToolStripMenuItem"
        Me.DeleteDateToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.DeleteDateToolStripMenuItem.Text = "Delete Data"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintDataToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintDataToolStripMenuItem
        '
        Me.PrintDataToolStripMenuItem.Name = "PrintDataToolStripMenuItem"
        Me.PrintDataToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.PrintDataToolStripMenuItem.Text = "Print Data"
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
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(805, 721)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 15
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(728, 721)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 14
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 721)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 17
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 721)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 16
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboGLTemplateName)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 88)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "GL Template Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGLTemplateName
        '
        Me.cboGLTemplateName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLTemplateName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLTemplateName.DataSource = Me.GLJournalTemplateHeaderBindingSource
        Me.cboGLTemplateName.DisplayMember = "TemplateName"
        Me.cboGLTemplateName.FormattingEnabled = True
        Me.cboGLTemplateName.Location = New System.Drawing.Point(18, 43)
        Me.cboGLTemplateName.Name = "cboGLTemplateName"
        Me.cboGLTemplateName.Size = New System.Drawing.Size(266, 21)
        Me.cboGLTemplateName.TabIndex = 0
        '
        'GLJournalTemplateHeaderBindingSource
        '
        Me.GLJournalTemplateHeaderBindingSource.DataMember = "GLJournalTemplateHeader"
        Me.GLJournalTemplateHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtpTemplateDate
        '
        Me.dtpTemplateDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTemplateDate.Location = New System.Drawing.Point(95, 33)
        Me.dtpTemplateDate.Name = "dtpTemplateDate"
        Me.dtpTemplateDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpTemplateDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Creation Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(266, 20)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Transaction Description / Comment"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(11, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Credit Amount"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(11, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Debit Amount"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearLines
        '
        Me.cmdClearLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearLines.Location = New System.Drawing.Point(209, 316)
        Me.cmdClearLines.Name = "cmdClearLines"
        Me.cmdClearLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearLines.TabIndex = 10
        Me.cmdClearLines.Text = "Clear"
        Me.cmdClearLines.UseVisualStyleBackColor = True
        '
        'cmdAddLine
        '
        Me.cmdAddLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddLine.Location = New System.Drawing.Point(132, 316)
        Me.cmdAddLine.Name = "cmdAddLine"
        Me.cmdAddLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddLine.TabIndex = 9
        Me.cmdAddLine.Text = "Add Line"
        Me.cmdAddLine.UseVisualStyleBackColor = True
        '
        'cboGLAccount
        '
        Me.cboGLAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccount.DisplayMember = "GLAccountNumber"
        Me.cboGLAccount.FormattingEnabled = True
        Me.cboGLAccount.Location = New System.Drawing.Point(91, 37)
        Me.cboGLAccount.Name = "cboGLAccount"
        Me.cboGLAccount.Size = New System.Drawing.Size(189, 21)
        Me.cboGLAccount.TabIndex = 4
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboGLDescription
        '
        Me.cboGLDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboGLDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboGLDescription.FormattingEnabled = True
        Me.cboGLDescription.Location = New System.Drawing.Point(16, 74)
        Me.cboGLDescription.Name = "cboGLDescription"
        Me.cboGLDescription.Size = New System.Drawing.Size(264, 21)
        Me.cboGLDescription.TabIndex = 5
        '
        'txtTransactionComment
        '
        Me.txtTransactionComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransactionComment.Location = New System.Drawing.Point(17, 208)
        Me.txtTransactionComment.Multiline = True
        Me.txtTransactionComment.Name = "txtTransactionComment"
        Me.txtTransactionComment.Size = New System.Drawing.Size(263, 86)
        Me.txtTransactionComment.TabIndex = 8
        Me.txtTransactionComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebitAmount
        '
        Me.txtDebitAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitAmount.Location = New System.Drawing.Point(130, 111)
        Me.txtDebitAmount.Name = "txtDebitAmount"
        Me.txtDebitAmount.Size = New System.Drawing.Size(150, 20)
        Me.txtDebitAmount.TabIndex = 6
        Me.txtDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCreditAmount
        '
        Me.txtCreditAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditAmount.Location = New System.Drawing.Point(130, 147)
        Me.txtCreditAmount.Name = "txtCreditAmount"
        Me.txtCreditAmount.Size = New System.Drawing.Size(150, 20)
        Me.txtCreditAmount.TabIndex = 7
        Me.txtCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(11, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "GL Account"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.cboGLJournalID)
        Me.GroupBox3.Controls.Add(Me.dtpTemplateDate)
        Me.GroupBox3.Controls.Add(Me.txtJournalComment)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 135)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 222)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Enter Header Data"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Comment"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGLJournalID
        '
        Me.cboGLJournalID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLJournalID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLJournalID.DataSource = Me.GLJournalsBindingSource
        Me.cboGLJournalID.DisplayMember = "GLJournalID"
        Me.cboGLJournalID.FormattingEnabled = True
        Me.cboGLJournalID.Location = New System.Drawing.Point(94, 64)
        Me.cboGLJournalID.Name = "cboGLJournalID"
        Me.cboGLJournalID.Size = New System.Drawing.Size(190, 21)
        Me.cboGLJournalID.TabIndex = 2
        '
        'GLJournalsBindingSource
        '
        Me.GLJournalsBindingSource.DataMember = "GLJournals"
        Me.GLJournalsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtJournalComment
        '
        Me.txtJournalComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJournalComment.Location = New System.Drawing.Point(17, 123)
        Me.txtJournalComment.Multiline = True
        Me.txtJournalComment.Name = "txtJournalComment"
        Me.txtJournalComment.Size = New System.Drawing.Size(267, 86)
        Me.txtJournalComment.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Journal ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvTemplateLines
        '
        Me.dgvTemplateLines.AllowUserToAddRows = False
        Me.dgvTemplateLines.AllowUserToDeleteRows = False
        Me.dgvTemplateLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTemplateLines.AutoGenerateColumns = False
        Me.dgvTemplateLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTemplateLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTemplateLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTemplateLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLLineNumberColumn, Me.GLAccountNumberColumn, Me.GLDebitAmountColumn, Me.GLCreditAmountColumn, Me.GLTransactionDescriptionColumn, Me.GLTemplateNameColumn})
        Me.dgvTemplateLines.DataSource = Me.GLJournalTemplateLinesBindingSource
        Me.dgvTemplateLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvTemplateLines.Location = New System.Drawing.Point(349, 41)
        Me.dgvTemplateLines.Name = "dgvTemplateLines"
        Me.dgvTemplateLines.Size = New System.Drawing.Size(681, 532)
        Me.dgvTemplateLines.TabIndex = 42
        '
        'GLLineNumberColumn
        '
        Me.GLLineNumberColumn.DataPropertyName = "GLLineNumber"
        Me.GLLineNumberColumn.HeaderText = "Line #"
        Me.GLLineNumberColumn.Name = "GLLineNumberColumn"
        Me.GLLineNumberColumn.ReadOnly = True
        Me.GLLineNumberColumn.Width = 65
        '
        'GLAccountNumberColumn
        '
        Me.GLAccountNumberColumn.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberColumn.HeaderText = "Account #"
        Me.GLAccountNumberColumn.Name = "GLAccountNumberColumn"
        '
        'GLDebitAmountColumn
        '
        Me.GLDebitAmountColumn.DataPropertyName = "GLDebitAmount"
        Me.GLDebitAmountColumn.HeaderText = "Debit Amount"
        Me.GLDebitAmountColumn.Name = "GLDebitAmountColumn"
        '
        'GLCreditAmountColumn
        '
        Me.GLCreditAmountColumn.DataPropertyName = "GLCreditAmount"
        Me.GLCreditAmountColumn.HeaderText = "Credit Amount"
        Me.GLCreditAmountColumn.Name = "GLCreditAmountColumn"
        '
        'GLTransactionDescriptionColumn
        '
        Me.GLTransactionDescriptionColumn.DataPropertyName = "GLTransactionDescription"
        Me.GLTransactionDescriptionColumn.HeaderText = "Description"
        Me.GLTransactionDescriptionColumn.Name = "GLTransactionDescriptionColumn"
        Me.GLTransactionDescriptionColumn.Width = 260
        '
        'GLTemplateNameColumn
        '
        Me.GLTemplateNameColumn.DataPropertyName = "GLTemplateName"
        Me.GLTemplateNameColumn.HeaderText = "GLTemplateName"
        Me.GLTemplateNameColumn.Name = "GLTemplateNameColumn"
        Me.GLTemplateNameColumn.ReadOnly = True
        Me.GLTemplateNameColumn.Visible = False
        '
        'GLJournalTemplateLinesBindingSource
        '
        Me.GLJournalTemplateLinesBindingSource.DataMember = "GLJournalTemplateLines"
        Me.GLJournalTemplateLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GLJournalTemplateLinesTableAdapter
        '
        Me.GLJournalTemplateLinesTableAdapter.ClearBeforeFill = True
        '
        'GLJournalTemplateHeaderTableAdapter
        '
        Me.GLJournalTemplateHeaderTableAdapter.ClearBeforeFill = True
        '
        'GLJournalsTableAdapter
        '
        Me.GLJournalsTableAdapter.ClearBeforeFill = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'txtDivisionID
        '
        Me.txtDivisionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDivisionID.Location = New System.Drawing.Point(513, 63)
        Me.txtDivisionID.Name = "txtDivisionID"
        Me.txtDivisionID.Size = New System.Drawing.Size(150, 20)
        Me.txtDivisionID.TabIndex = 43
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.cboDeleteLine)
        Me.GroupBox4.Controls.Add(Me.cmdDeleteLine)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(349, 586)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(373, 128)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Delete Lines from Template"
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(20, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(217, 35)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Select line # from datagrid or drop down box to delete."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDeleteLine
        '
        Me.cboDeleteLine.DataSource = Me.GLJournalTemplateLinesBindingSource
        Me.cboDeleteLine.DisplayMember = "GLLineNumber"
        Me.cboDeleteLine.FormattingEnabled = True
        Me.cboDeleteLine.Location = New System.Drawing.Point(170, 31)
        Me.cboDeleteLine.Name = "cboDeleteLine"
        Me.cboDeleteLine.Size = New System.Drawing.Size(144, 21)
        Me.cboDeleteLine.TabIndex = 11
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Location = New System.Drawing.Point(243, 67)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 12
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(20, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 20)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Template Line #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(651, 721)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 13
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.txtDifference)
        Me.GroupBox5.Controls.Add(Me.txtDebitTotal)
        Me.GroupBox5.Controls.Add(Me.txtCreditTotal)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Location = New System.Drawing.Point(728, 586)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(302, 128)
        Me.GroupBox5.TabIndex = 44
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Template Totals"
        '
        'txtDifference
        '
        Me.txtDifference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDifference.Location = New System.Drawing.Point(113, 87)
        Me.txtDifference.Name = "txtDifference"
        Me.txtDifference.Size = New System.Drawing.Size(170, 20)
        Me.txtDifference.TabIndex = 45
        Me.txtDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebitTotal
        '
        Me.txtDebitTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitTotal.Location = New System.Drawing.Point(113, 25)
        Me.txtDebitTotal.Name = "txtDebitTotal"
        Me.txtDebitTotal.Size = New System.Drawing.Size(170, 20)
        Me.txtDebitTotal.TabIndex = 41
        Me.txtDebitTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCreditTotal
        '
        Me.txtCreditTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditTotal.Location = New System.Drawing.Point(113, 56)
        Me.txtCreditTotal.Name = "txtCreditTotal"
        Me.txtCreditTotal.Size = New System.Drawing.Size(170, 20)
        Me.txtCreditTotal.TabIndex = 42
        Me.txtCreditTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(25, 85)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Difference"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(25, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Credit Total"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(25, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Debit Total"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabLineControl
        '
        Me.tabLineControl.Controls.Add(Me.tabAddLine)
        Me.tabLineControl.Controls.Add(Me.tabInsertLine)
        Me.tabLineControl.Location = New System.Drawing.Point(29, 363)
        Me.tabLineControl.Name = "tabLineControl"
        Me.tabLineControl.SelectedIndex = 0
        Me.tabLineControl.Size = New System.Drawing.Size(300, 398)
        Me.tabLineControl.TabIndex = 45
        '
        'tabAddLine
        '
        Me.tabAddLine.Controls.Add(Me.Label7)
        Me.tabAddLine.Controls.Add(Me.Label6)
        Me.tabAddLine.Controls.Add(Me.txtTransactionComment)
        Me.tabAddLine.Controls.Add(Me.cmdAddLine)
        Me.tabAddLine.Controls.Add(Me.Label5)
        Me.tabAddLine.Controls.Add(Me.cmdClearLines)
        Me.tabAddLine.Controls.Add(Me.cboGLAccount)
        Me.tabAddLine.Controls.Add(Me.Label4)
        Me.tabAddLine.Controls.Add(Me.cboGLDescription)
        Me.tabAddLine.Controls.Add(Me.txtCreditAmount)
        Me.tabAddLine.Controls.Add(Me.txtDebitAmount)
        Me.tabAddLine.Location = New System.Drawing.Point(4, 22)
        Me.tabAddLine.Name = "tabAddLine"
        Me.tabAddLine.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAddLine.Size = New System.Drawing.Size(292, 372)
        Me.tabAddLine.TabIndex = 0
        Me.tabAddLine.Text = "Add Lines"
        Me.tabAddLine.UseVisualStyleBackColor = True
        '
        'tabInsertLine
        '
        Me.tabInsertLine.Controls.Add(Me.numLineNumber)
        Me.tabInsertLine.Controls.Add(Me.Label19)
        Me.tabInsertLine.Controls.Add(Me.Label15)
        Me.tabInsertLine.Controls.Add(Me.Label16)
        Me.tabInsertLine.Controls.Add(Me.txtInsertComment)
        Me.tabInsertLine.Controls.Add(Me.cmdInsertLine)
        Me.tabInsertLine.Controls.Add(Me.Label17)
        Me.tabInsertLine.Controls.Add(Me.cboInsertGLAccount)
        Me.tabInsertLine.Controls.Add(Me.Label18)
        Me.tabInsertLine.Controls.Add(Me.cboInsertGLDescription)
        Me.tabInsertLine.Controls.Add(Me.txtInsertCredit)
        Me.tabInsertLine.Controls.Add(Me.txtInsertDebit)
        Me.tabInsertLine.Controls.Add(Me.Label14)
        Me.tabInsertLine.Location = New System.Drawing.Point(4, 22)
        Me.tabInsertLine.Name = "tabInsertLine"
        Me.tabInsertLine.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInsertLine.Size = New System.Drawing.Size(292, 372)
        Me.tabInsertLine.TabIndex = 1
        Me.tabInsertLine.Text = "Insert Line"
        Me.tabInsertLine.UseVisualStyleBackColor = True
        '
        'numLineNumber
        '
        Me.numLineNumber.Location = New System.Drawing.Point(181, 15)
        Me.numLineNumber.Name = "numLineNumber"
        Me.numLineNumber.Size = New System.Drawing.Size(99, 20)
        Me.numLineNumber.TabIndex = 55
        Me.numLineNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(13, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(162, 20)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Insert Line After Line #"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(13, 222)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(266, 20)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "Transaction Description / Comment"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(13, 183)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 20)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Credit Amount"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInsertComment
        '
        Me.txtInsertComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInsertComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInsertComment.Location = New System.Drawing.Point(13, 245)
        Me.txtInsertComment.Multiline = True
        Me.txtInsertComment.Name = "txtInsertComment"
        Me.txtInsertComment.Size = New System.Drawing.Size(267, 83)
        Me.txtInsertComment.TabIndex = 49
        Me.txtInsertComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdInsertLine
        '
        Me.cmdInsertLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdInsertLine.Location = New System.Drawing.Point(209, 336)
        Me.cmdInsertLine.Name = "cmdInsertLine"
        Me.cmdInsertLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdInsertLine.TabIndex = 50
        Me.cmdInsertLine.Text = "Insert Line"
        Me.cmdInsertLine.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(13, 157)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 20)
        Me.Label17.TabIndex = 51
        Me.Label17.Text = "Debit Amount"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboInsertGLAccount
        '
        Me.cboInsertGLAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInsertGLAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInsertGLAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboInsertGLAccount.DisplayMember = "GLAccountNumber"
        Me.cboInsertGLAccount.FormattingEnabled = True
        Me.cboInsertGLAccount.Location = New System.Drawing.Point(91, 85)
        Me.cboInsertGLAccount.Name = "cboInsertGLAccount"
        Me.cboInsertGLAccount.Size = New System.Drawing.Size(189, 21)
        Me.cboInsertGLAccount.TabIndex = 44
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(13, 86)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 20)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "GL Account"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboInsertGLDescription
        '
        Me.cboInsertGLDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboInsertGLDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboInsertGLDescription.FormattingEnabled = True
        Me.cboInsertGLDescription.Location = New System.Drawing.Point(13, 115)
        Me.cboInsertGLDescription.Name = "cboInsertGLDescription"
        Me.cboInsertGLDescription.Size = New System.Drawing.Size(267, 21)
        Me.cboInsertGLDescription.TabIndex = 45
        '
        'txtInsertCredit
        '
        Me.txtInsertCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInsertCredit.Location = New System.Drawing.Point(130, 183)
        Me.txtInsertCredit.Name = "txtInsertCredit"
        Me.txtInsertCredit.Size = New System.Drawing.Size(150, 20)
        Me.txtInsertCredit.TabIndex = 48
        Me.txtInsertCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInsertDebit
        '
        Me.txtInsertDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInsertDebit.Location = New System.Drawing.Point(130, 157)
        Me.txtInsertDebit.Name = "txtInsertDebit"
        Me.txtInsertDebit.Size = New System.Drawing.Size(150, 20)
        Me.txtInsertDebit.TabIndex = 47
        Me.txtInsertDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(13, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(267, 35)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "Inserts line after the selected line number and re-numbers the remaining lines."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GLTransactionTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 773)
        Me.Controls.Add(Me.tabLineControl)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.dgvTemplateLines)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtDivisionID)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GLTransactionTemplate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation GL Journal Template"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GLJournalTemplateHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.GLJournalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTemplateLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLJournalTemplateLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tabLineControl.ResumeLayout(False)
        Me.tabAddLine.ResumeLayout(False)
        Me.tabAddLine.PerformLayout()
        Me.tabInsertLine.ResumeLayout(False)
        Me.tabInsertLine.PerformLayout()
        CType(Me.numLineNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpTemplateDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboGLTemplateName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtJournalComment As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboGLJournalID As System.Windows.Forms.ComboBox
    Friend WithEvents txtDebitAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdClearLines As System.Windows.Forms.Button
    Friend WithEvents cmdAddLine As System.Windows.Forms.Button
    Friend WithEvents cboGLAccount As System.Windows.Forms.ComboBox
    Friend WithEvents cboGLDescription As System.Windows.Forms.ComboBox
    Friend WithEvents txtTransactionComment As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvTemplateLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents GLJournalTemplateLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalTemplateLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalTemplateLinesTableAdapter
    Friend WithEvents GLJournalTemplateHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalTemplateHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalTemplateHeaderTableAdapter
    Friend WithEvents GLJournalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLJournalsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLJournalsTableAdapter
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDivisionID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboDeleteLine As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteDateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDifference As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDebitTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditTotal As System.Windows.Forms.TextBox
    Friend WithEvents GLLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTemplateNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabLineControl As System.Windows.Forms.TabControl
    Friend WithEvents tabAddLine As System.Windows.Forms.TabPage
    Friend WithEvents tabInsertLine As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtInsertComment As System.Windows.Forms.TextBox
    Friend WithEvents cmdInsertLine As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboInsertGLAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboInsertGLDescription As System.Windows.Forms.ComboBox
    Friend WithEvents txtInsertCredit As System.Windows.Forms.TextBox
    Friend WithEvents txtInsertDebit As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents numLineNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
