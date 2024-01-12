<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BankTransactionEntry
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdNewTransactionNumber = New System.Windows.Forms.Button
        Me.cboTransactionNumber = New System.Windows.Forms.ComboBox
        Me.BankTransactionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtDebitAmount = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtTransactionComment = New System.Windows.Forms.TextBox
        Me.cmdClearBankTransaction = New System.Windows.Forms.Button
        Me.cmdEnterBankTransaction = New System.Windows.Forms.Button
        Me.txtCreditAmount = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cboGLAccountName = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboGLAccountID = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.cboTransactionType = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.dtpTransactionDate = New System.Windows.Forms.DateTimePicker
        Me.cmdGenerateBatchNumber = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdDeleteBatch = New System.Windows.Forms.Button
        Me.cmdPrintBatch = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtBatchComment = New System.Windows.Forms.TextBox
        Me.txtBatchStatus = New System.Windows.Forms.TextBox
        Me.cboBankAccount = New System.Windows.Forms.ComboBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.BankTransactionsBatchHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvBankTransactions = New System.Windows.Forms.DataGridView
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdSaveBatch = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdPostBatch = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtBatchTotal = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtDebitTotal = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCreditTotal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboDeleteTransaction = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdDeleteTransaction = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.BankTransactionsBatchHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankTransactionsBatchHeaderTableAdapter
        Me.BankTransactionsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankTransactionsTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.BankTransactionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BankTransactionsBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBankTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveBatchToolStripMenuItem, Me.PrintBatchToolStripMenuItem, Me.DeleteBatchToolStripMenuItem, Me.ClearBatchToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveBatchToolStripMenuItem
        '
        Me.SaveBatchToolStripMenuItem.Name = "SaveBatchToolStripMenuItem"
        Me.SaveBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.SaveBatchToolStripMenuItem.Text = "Save Batch"
        '
        'PrintBatchToolStripMenuItem
        '
        Me.PrintBatchToolStripMenuItem.Name = "PrintBatchToolStripMenuItem"
        Me.PrintBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PrintBatchToolStripMenuItem.Text = "Print Batch"
        '
        'DeleteBatchToolStripMenuItem
        '
        Me.DeleteBatchToolStripMenuItem.Name = "DeleteBatchToolStripMenuItem"
        Me.DeleteBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.DeleteBatchToolStripMenuItem.Text = "Delete Batch"
        '
        'ClearBatchToolStripMenuItem
        '
        Me.ClearBatchToolStripMenuItem.Name = "ClearBatchToolStripMenuItem"
        Me.ClearBatchToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ClearBatchToolStripMenuItem.Text = "Clear Batch"
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdNewTransactionNumber)
        Me.GroupBox3.Controls.Add(Me.cboTransactionNumber)
        Me.GroupBox3.Controls.Add(Me.txtDebitAmount)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.txtTransactionComment)
        Me.GroupBox3.Controls.Add(Me.cmdClearBankTransaction)
        Me.GroupBox3.Controls.Add(Me.cmdEnterBankTransaction)
        Me.GroupBox3.Controls.Add(Me.txtCreditAmount)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.cboGLAccountName)
        Me.GroupBox3.Controls.Add(Me.cboGLAccountID)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.cboTransactionType)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 372)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 439)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Enter Bank Transaction"
        '
        'cmdNewTransactionNumber
        '
        Me.cmdNewTransactionNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdNewTransactionNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdNewTransactionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNewTransactionNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdNewTransactionNumber.Location = New System.Drawing.Point(72, 25)
        Me.cmdNewTransactionNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdNewTransactionNumber.Name = "cmdNewTransactionNumber"
        Me.cmdNewTransactionNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdNewTransactionNumber.TabIndex = 7
        Me.cmdNewTransactionNumber.Text = ">>"
        Me.cmdNewTransactionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdNewTransactionNumber.UseVisualStyleBackColor = False
        '
        'cboTransactionNumber
        '
        Me.cboTransactionNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTransactionNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTransactionNumber.DataSource = Me.BankTransactionsBindingSource
        Me.cboTransactionNumber.DisplayMember = "TransactionNumber"
        Me.cboTransactionNumber.FormattingEnabled = True
        Me.cboTransactionNumber.Location = New System.Drawing.Point(104, 25)
        Me.cboTransactionNumber.Name = "cboTransactionNumber"
        Me.cboTransactionNumber.Size = New System.Drawing.Size(181, 21)
        Me.cboTransactionNumber.TabIndex = 8
        '
        'BankTransactionsBindingSource
        '
        Me.BankTransactionsBindingSource.DataMember = "BankTransactions"
        Me.BankTransactionsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtDebitAmount
        '
        Me.txtDebitAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDebitAmount.Location = New System.Drawing.Point(139, 319)
        Me.txtDebitAmount.Name = "txtDebitAmount"
        Me.txtDebitAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtDebitAmount.TabIndex = 13
        Me.txtDebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(22, 319)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 20)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Debit Amount"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(20, 160)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 20)
        Me.Label24.TabIndex = 27
        Me.Label24.Text = "Comment"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransactionComment
        '
        Me.txtTransactionComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransactionComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransactionComment.Location = New System.Drawing.Point(23, 183)
        Me.txtTransactionComment.Multiline = True
        Me.txtTransactionComment.Name = "txtTransactionComment"
        Me.txtTransactionComment.Size = New System.Drawing.Size(262, 105)
        Me.txtTransactionComment.TabIndex = 12
        Me.txtTransactionComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClearBankTransaction
        '
        Me.cmdClearBankTransaction.Location = New System.Drawing.Point(216, 381)
        Me.cmdClearBankTransaction.Name = "cmdClearBankTransaction"
        Me.cmdClearBankTransaction.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearBankTransaction.TabIndex = 16
        Me.cmdClearBankTransaction.Text = "Clear"
        Me.cmdClearBankTransaction.UseVisualStyleBackColor = True
        '
        'cmdEnterBankTransaction
        '
        Me.cmdEnterBankTransaction.Location = New System.Drawing.Point(139, 381)
        Me.cmdEnterBankTransaction.Name = "cmdEnterBankTransaction"
        Me.cmdEnterBankTransaction.Size = New System.Drawing.Size(71, 40)
        Me.cmdEnterBankTransaction.TabIndex = 15
        Me.cmdEnterBankTransaction.Text = "Enter"
        Me.cmdEnterBankTransaction.UseVisualStyleBackColor = True
        '
        'txtCreditAmount
        '
        Me.txtCreditAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreditAmount.Location = New System.Drawing.Point(139, 345)
        Me.txtCreditAmount.Name = "txtCreditAmount"
        Me.txtCreditAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtCreditAmount.TabIndex = 14
        Me.txtCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(22, 345)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(100, 20)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "Credit Amount"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGLAccountName
        '
        Me.cboGLAccountName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccountName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccountName.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccountName.DisplayMember = "GLAccountShortDescription"
        Me.cboGLAccountName.FormattingEnabled = True
        Me.cboGLAccountName.Location = New System.Drawing.Point(23, 118)
        Me.cboGLAccountName.Name = "cboGLAccountName"
        Me.cboGLAccountName.Size = New System.Drawing.Size(262, 21)
        Me.cboGLAccountName.TabIndex = 11
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboGLAccountID
        '
        Me.cboGLAccountID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGLAccountID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGLAccountID.DataSource = Me.GLAccountsBindingSource
        Me.cboGLAccountID.DisplayMember = "GLAccountNumber"
        Me.cboGLAccountID.FormattingEnabled = True
        Me.cboGLAccountID.Location = New System.Drawing.Point(104, 87)
        Me.cboGLAccountID.Name = "cboGLAccountID"
        Me.cboGLAccountID.Size = New System.Drawing.Size(181, 21)
        Me.cboGLAccountID.TabIndex = 10
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(20, 88)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 20)
        Me.Label23.TabIndex = 19
        Me.Label23.Text = "GL Account"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTransactionType
        '
        Me.cboTransactionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTransactionType.FormattingEnabled = True
        Me.cboTransactionType.Items.AddRange(New Object() {"Check", "Deposit", "Withdrawal", "Bank Charge", "Bank Interest Earned", "Misc. Bank Credit", "Misc. Bank Debit", "Bank Transfer"})
        Me.cboTransactionType.Location = New System.Drawing.Point(104, 56)
        Me.cboTransactionType.Name = "cboTransactionType"
        Me.cboTransactionType.Size = New System.Drawing.Size(181, 21)
        Me.cboTransactionType.TabIndex = 9
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(17, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 20)
        Me.Label21.TabIndex = 12
        Me.Label21.Text = "Trans. Type"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Trans. #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(20, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(97, 20)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "Date"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTransactionDate.Location = New System.Drawing.Point(104, 88)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpTransactionDate.TabIndex = 3
        Me.dtpTransactionDate.Value = New Date(2017, 11, 16, 14, 42, 34, 0)
        '
        'cmdGenerateBatchNumber
        '
        Me.cmdGenerateBatchNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateBatchNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateBatchNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateBatchNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateBatchNumber.Location = New System.Drawing.Point(72, 28)
        Me.cmdGenerateBatchNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateBatchNumber.Name = "cmdGenerateBatchNumber"
        Me.cmdGenerateBatchNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateBatchNumber.TabIndex = 0
        Me.cmdGenerateBatchNumber.Text = ">>"
        Me.cmdGenerateBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateBatchNumber.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(20, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 20)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Batch #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteBatch
        '
        Me.cmdDeleteBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteBatch.Location = New System.Drawing.Point(882, 771)
        Me.cmdDeleteBatch.Name = "cmdDeleteBatch"
        Me.cmdDeleteBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteBatch.TabIndex = 19
        Me.cmdDeleteBatch.Text = "Delete Batch"
        Me.cmdDeleteBatch.UseVisualStyleBackColor = True
        '
        'cmdPrintBatch
        '
        Me.cmdPrintBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintBatch.Location = New System.Drawing.Point(805, 771)
        Me.cmdPrintBatch.Name = "cmdPrintBatch"
        Me.cmdPrintBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintBatch.TabIndex = 17
        Me.cmdPrintBatch.Text = "Print Batch"
        Me.cmdPrintBatch.UseVisualStyleBackColor = True
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtBatchComment)
        Me.GroupBox1.Controls.Add(Me.txtBatchStatus)
        Me.GroupBox1.Controls.Add(Me.cboBankAccount)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.cboBatchNumber)
        Me.GroupBox1.Controls.Add(Me.cmdGenerateBatchNumber)
        Me.GroupBox1.Controls.Add(Me.dtpTransactionDate)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 313)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create Batch"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(20, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Comment"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBatchComment
        '
        Me.txtBatchComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchComment.Location = New System.Drawing.Point(23, 196)
        Me.txtBatchComment.Multiline = True
        Me.txtBatchComment.Name = "txtBatchComment"
        Me.txtBatchComment.Size = New System.Drawing.Size(265, 104)
        Me.txtBatchComment.TabIndex = 6
        Me.txtBatchComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBatchStatus
        '
        Me.txtBatchStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchStatus.Enabled = False
        Me.txtBatchStatus.Location = New System.Drawing.Point(104, 147)
        Me.txtBatchStatus.Name = "txtBatchStatus"
        Me.txtBatchStatus.Size = New System.Drawing.Size(181, 20)
        Me.txtBatchStatus.TabIndex = 5
        Me.txtBatchStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboBankAccount
        '
        Me.cboBankAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBankAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBankAccount.FormattingEnabled = True
        Me.cboBankAccount.Items.AddRange(New Object() {"Checking", "Cash Receipts", "Petty Cash", "Payroll Checking", "Canadian Checking", "Canadian Cash Receipts"})
        Me.cboBankAccount.Location = New System.Drawing.Point(104, 117)
        Me.cboBankAccount.Name = "cboBankAccount"
        Me.cboBankAccount.Size = New System.Drawing.Size(181, 21)
        Me.cboBankAccount.TabIndex = 4
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(104, 58)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(181, 21)
        Me.cboDivisionID.TabIndex = 2
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.DataSource = Me.BankTransactionsBatchHeaderBindingSource
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(104, 28)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(181, 21)
        Me.cboBatchNumber.TabIndex = 1
        '
        'BankTransactionsBatchHeaderBindingSource
        '
        Me.BankTransactionsBatchHeaderBindingSource.DataMember = "BankTransactionsBatchHeader"
        Me.BankTransactionsBatchHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 20)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Status"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 20)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Bank Account"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 20)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Division ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvBankTransactions
        '
        Me.dgvBankTransactions.AllowUserToAddRows = False
        Me.dgvBankTransactions.AllowUserToDeleteRows = False
        Me.dgvBankTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBankTransactions.AutoGenerateColumns = False
        Me.dgvBankTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvBankTransactions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvBankTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBankTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransactionNumberColumn, Me.TransactionTypeColumn, Me.TransactionDateColumn, Me.GLAccountColumn, Me.DebitAmountColumn, Me.CreditAmountColumn, Me.CommentColumn, Me.BatchNumberColumn, Me.StatusColumn, Me.DivisionIDColumn})
        Me.dgvBankTransactions.DataSource = Me.BankTransactionsBindingSource
        Me.dgvBankTransactions.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvBankTransactions.Location = New System.Drawing.Point(345, 41)
        Me.dgvBankTransactions.Name = "dgvBankTransactions"
        Me.dgvBankTransactions.Size = New System.Drawing.Size(685, 562)
        Me.dgvBankTransactions.TabIndex = 21
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "Trans. #"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.ReadOnly = True
        Me.TransactionNumberColumn.Width = 85
        '
        'TransactionTypeColumn
        '
        Me.TransactionTypeColumn.DataPropertyName = "TransactionType"
        Me.TransactionTypeColumn.HeaderText = "Transaction Type"
        Me.TransactionTypeColumn.Name = "TransactionTypeColumn"
        Me.TransactionTypeColumn.ReadOnly = True
        '
        'TransactionDateColumn
        '
        Me.TransactionDateColumn.DataPropertyName = "TransactionDate"
        Me.TransactionDateColumn.HeaderText = "Date"
        Me.TransactionDateColumn.Name = "TransactionDateColumn"
        Me.TransactionDateColumn.ReadOnly = True
        '
        'GLAccountColumn
        '
        Me.GLAccountColumn.DataPropertyName = "GLAccount"
        Me.GLAccountColumn.HeaderText = "GL Account"
        Me.GLAccountColumn.Name = "GLAccountColumn"
        Me.GLAccountColumn.ReadOnly = True
        '
        'DebitAmountColumn
        '
        Me.DebitAmountColumn.DataPropertyName = "DebitAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.DebitAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DebitAmountColumn.HeaderText = "Debit Amount"
        Me.DebitAmountColumn.Name = "DebitAmountColumn"
        Me.DebitAmountColumn.ReadOnly = True
        '
        'CreditAmountColumn
        '
        Me.CreditAmountColumn.DataPropertyName = "CreditAmount"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.CreditAmountColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.CreditAmountColumn.HeaderText = "Credit Amount"
        Me.CreditAmountColumn.Name = "CreditAmountColumn"
        Me.CreditAmountColumn.ReadOnly = True
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.ReadOnly = True
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.ReadOnly = True
        Me.BatchNumberColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        Me.StatusColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'cmdSaveBatch
        '
        Me.cmdSaveBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveBatch.Location = New System.Drawing.Point(728, 771)
        Me.cmdSaveBatch.Name = "cmdSaveBatch"
        Me.cmdSaveBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdSaveBatch.TabIndex = 22
        Me.cmdSaveBatch.Text = "Save Batch"
        Me.cmdSaveBatch.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmdPostBatch)
        Me.GroupBox2.Location = New System.Drawing.Point(815, 624)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(215, 140)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Post Batch"
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(17, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 41)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Post all Bank Transactions in the grid."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPostBatch
        '
        Me.cmdPostBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPostBatch.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostBatch.Location = New System.Drawing.Point(126, 85)
        Me.cmdPostBatch.Name = "cmdPostBatch"
        Me.cmdPostBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostBatch.TabIndex = 24
        Me.cmdPostBatch.Text = "Post Batch"
        Me.cmdPostBatch.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.txtBatchTotal)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtDebitTotal)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtCreditTotal)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(589, 624)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(215, 140)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Batch Totals"
        '
        'txtBatchTotal
        '
        Me.txtBatchTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchTotal.Location = New System.Drawing.Point(85, 94)
        Me.txtBatchTotal.Name = "txtBatchTotal"
        Me.txtBatchTotal.ReadOnly = True
        Me.txtBatchTotal.Size = New System.Drawing.Size(115, 20)
        Me.txtBatchTotal.TabIndex = 41
        Me.txtBatchTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(13, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 20)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "Batch Total"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDebitTotal
        '
        Me.txtDebitTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebitTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDebitTotal.Location = New System.Drawing.Point(85, 62)
        Me.txtDebitTotal.Name = "txtDebitTotal"
        Me.txtDebitTotal.ReadOnly = True
        Me.txtDebitTotal.Size = New System.Drawing.Size(115, 20)
        Me.txtDebitTotal.TabIndex = 39
        Me.txtDebitTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(13, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 20)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Debit Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreditTotal
        '
        Me.txtCreditTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreditTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreditTotal.Location = New System.Drawing.Point(85, 30)
        Me.txtCreditTotal.Name = "txtCreditTotal"
        Me.txtCreditTotal.ReadOnly = True
        Me.txtCreditTotal.Size = New System.Drawing.Size(115, 20)
        Me.txtCreditTotal.TabIndex = 37
        Me.txtCreditTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(13, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 20)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Credit Total"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.cboDeleteTransaction)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.cmdDeleteTransaction)
        Me.GroupBox5.Location = New System.Drawing.Point(345, 624)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(233, 140)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Delete Transaction"
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(24, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(182, 29)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Delete selected transaction."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDeleteTransaction
        '
        Me.cboDeleteTransaction.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeleteTransaction.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeleteTransaction.DataSource = Me.BankTransactionsBindingSource
        Me.cboDeleteTransaction.DisplayMember = "TransactionNumber"
        Me.cboDeleteTransaction.FormattingEnabled = True
        Me.cboDeleteTransaction.Location = New System.Drawing.Point(64, 29)
        Me.cboDeleteTransaction.Name = "cboDeleteTransaction"
        Me.cboDeleteTransaction.Size = New System.Drawing.Size(153, 21)
        Me.cboDeleteTransaction.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 20)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Trans. #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteTransaction
        '
        Me.cmdDeleteTransaction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteTransaction.Location = New System.Drawing.Point(146, 88)
        Me.cmdDeleteTransaction.Name = "cmdDeleteTransaction"
        Me.cmdDeleteTransaction.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteTransaction.TabIndex = 28
        Me.cmdDeleteTransaction.Text = "Delete Transaction"
        Me.cmdDeleteTransaction.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(651, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 27
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'BankTransactionsBatchHeaderTableAdapter
        '
        Me.BankTransactionsBatchHeaderTableAdapter.ClearBeforeFill = True
        '
        'BankTransactionsTableAdapter
        '
        Me.BankTransactionsTableAdapter.ClearBeforeFill = True
        '
        'BankTransactionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdSaveBatch)
        Me.Controls.Add(Me.dgvBankTransactions)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdDeleteBatch)
        Me.Controls.Add(Me.cmdPrintBatch)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "BankTransactionEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Bank Transaction Entry"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.BankTransactionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BankTransactionsBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBankTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGenerateBatchNumber As System.Windows.Forms.Button
    Friend WithEvents cboTransactionNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDebitAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtTransactionComment As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearBankTransaction As System.Windows.Forms.Button
    Friend WithEvents cmdEnterBankTransaction As System.Windows.Forms.Button
    Friend WithEvents txtCreditAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboGLAccountName As System.Windows.Forms.ComboBox
    Friend WithEvents cboGLAccountID As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtpTransactionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTransactionType As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteBatch As System.Windows.Forms.Button
    Friend WithEvents cmdPrintBatch As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdNewTransactionNumber As System.Windows.Forms.Button
    Friend WithEvents dgvBankTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents BankAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OffsetAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdSaveBatch As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPostBatch As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboBankAccount As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDeleteTransaction As System.Windows.Forms.Button
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboDeleteTransaction As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBatchStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtDebitTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCreditTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BankTransactionsBatchHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BankTransactionsBatchHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankTransactionsBatchHeaderTableAdapter
    Friend WithEvents txtBatchComment As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBatchTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BankTransactionsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BankTransactionsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankTransactionsTableAdapter
    Friend WithEvents SaveBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearBatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
