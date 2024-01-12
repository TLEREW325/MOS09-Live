<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BankReconciliation
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
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBankReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxBankData = New System.Windows.Forms.GroupBox
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtBatchStatus = New System.Windows.Forms.TextBox
        Me.cmdGenerateNewBatch = New System.Windows.Forms.Button
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.BankReconciliationBatchHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dtpPostDate = New System.Windows.Forms.DateTimePicker
        Me.cboBankAccount = New System.Windows.Forms.ComboBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtEndingStatementBalance = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdDeleteBatch = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblClearedVariance = New System.Windows.Forms.Label
        Me.lblClearedEndingTotal = New System.Windows.Forms.Label
        Me.lblClearedSubtotal = New System.Windows.Forms.Label
        Me.lblClearedCredits = New System.Windows.Forms.Label
        Me.lblClearedDebits = New System.Windows.Forms.Label
        Me.lblClearedStatementBalance = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblOSVariance = New System.Windows.Forms.Label
        Me.lblBookBalance = New System.Windows.Forms.Label
        Me.lblOSEndingTotal = New System.Windows.Forms.Label
        Me.lblOSCredits = New System.Windows.Forms.Label
        Me.lblOSDebits = New System.Windows.Forms.Label
        Me.lblOSStatementBalance = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdCheckAll = New System.Windows.Forms.Button
        Me.cmdUncheckAll = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdPostBatch = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.dgvBankRec = New System.Windows.Forms.DataGridView
        Me.SelectColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PayerPayeeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BankReconciliationLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BankReconciliationLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankReconciliationLineTableTableAdapter
        Me.BankReconciliationBatchHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankReconciliationBatchHeaderTableAdapter
        Me.dgvARPaymentLog = New System.Windows.Forms.DataGridView
        Me.ARPaymentIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARPaymentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARCustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARPaymentAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARPaymentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARPaymentTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARPaymentStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARPaymentLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ARPaymentLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARPaymentLogTableAdapter
        Me.dgvAPCheckLog = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorClassDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APBatchNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APCheckLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.APCheckLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLogTableAdapter
        Me.dgvBankTransactions = New System.Windows.Forms.DataGridView
        Me.BTTransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTTransactionTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTTransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BankTransactionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BankTransactionsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankTransactionsTableAdapter
        Me.txtOne = New System.Windows.Forms.TextBox
        Me.txtTwo = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.gpxBankData.SuspendLayout()
        CType(Me.BankReconciliationBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvBankRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BankReconciliationLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvARPaymentLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARPaymentLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAPCheckLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APCheckLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBankTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BankTransactionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintBankReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintBankReportToolStripMenuItem
        '
        Me.PrintBankReportToolStripMenuItem.Name = "PrintBankReportToolStripMenuItem"
        Me.PrintBankReportToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.PrintBankReportToolStripMenuItem.Text = "Print Bank Report"
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(885, 721)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 8
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 721)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 9
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxBankData
        '
        Me.gpxBankData.Controls.Add(Me.txtComment)
        Me.gpxBankData.Controls.Add(Me.Label32)
        Me.gpxBankData.Controls.Add(Me.txtBatchStatus)
        Me.gpxBankData.Controls.Add(Me.cmdGenerateNewBatch)
        Me.gpxBankData.Controls.Add(Me.cboBatchNumber)
        Me.gpxBankData.Controls.Add(Me.dtpPostDate)
        Me.gpxBankData.Controls.Add(Me.cboBankAccount)
        Me.gpxBankData.Controls.Add(Me.cboDivisionID)
        Me.gpxBankData.Controls.Add(Me.txtEndingStatementBalance)
        Me.gpxBankData.Controls.Add(Me.Label31)
        Me.gpxBankData.Controls.Add(Me.Label30)
        Me.gpxBankData.Controls.Add(Me.Label27)
        Me.gpxBankData.Controls.Add(Me.Label3)
        Me.gpxBankData.Controls.Add(Me.Label1)
        Me.gpxBankData.Controls.Add(Me.Label15)
        Me.gpxBankData.Location = New System.Drawing.Point(29, 41)
        Me.gpxBankData.Name = "gpxBankData"
        Me.gpxBankData.Size = New System.Drawing.Size(300, 379)
        Me.gpxBankData.TabIndex = 0
        Me.gpxBankData.TabStop = False
        Me.gpxBankData.Text = "Batch Data"
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(22, 264)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(264, 91)
        Me.txtComment.TabIndex = 7
        Me.txtComment.Text = "BANK REC BATCH"
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(21, 241)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(98, 20)
        Me.Label32.TabIndex = 22
        Me.Label32.Text = "Comment"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBatchStatus
        '
        Me.txtBatchStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchStatus.Location = New System.Drawing.Point(105, 211)
        Me.txtBatchStatus.Name = "txtBatchStatus"
        Me.txtBatchStatus.Size = New System.Drawing.Size(180, 20)
        Me.txtBatchStatus.TabIndex = 6
        Me.txtBatchStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGenerateNewBatch
        '
        Me.cmdGenerateNewBatch.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewBatch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewBatch.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewBatch.Location = New System.Drawing.Point(105, 28)
        Me.cmdGenerateNewBatch.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewBatch.Name = "cmdGenerateNewBatch"
        Me.cmdGenerateNewBatch.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewBatch.TabIndex = 0
        Me.cmdGenerateNewBatch.TabStop = False
        Me.cmdGenerateNewBatch.Text = ">>"
        Me.cmdGenerateNewBatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewBatch.UseVisualStyleBackColor = False
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBatchNumber.DataSource = Me.BankReconciliationBatchHeaderBindingSource
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(137, 28)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(149, 21)
        Me.cboBatchNumber.TabIndex = 1
        '
        'BankReconciliationBatchHeaderBindingSource
        '
        Me.BankReconciliationBatchHeaderBindingSource.DataMember = "BankReconciliationBatchHeader"
        Me.BankReconciliationBatchHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtpPostDate
        '
        Me.dtpPostDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPostDate.Location = New System.Drawing.Point(105, 102)
        Me.dtpPostDate.Name = "dtpPostDate"
        Me.dtpPostDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpPostDate.TabIndex = 3
        '
        'cboBankAccount
        '
        Me.cboBankAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBankAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBankAccount.FormattingEnabled = True
        Me.cboBankAccount.Items.AddRange(New Object() {"Cash Receipts", "Checking", "Due To Parent"})
        Me.cboBankAccount.Location = New System.Drawing.Point(105, 138)
        Me.cboBankAccount.Name = "cboBankAccount"
        Me.cboBankAccount.Size = New System.Drawing.Size(181, 21)
        Me.cboBankAccount.TabIndex = 4
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(105, 65)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(181, 21)
        Me.cboDivisionID.TabIndex = 2
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtEndingStatementBalance
        '
        Me.txtEndingStatementBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndingStatementBalance.Location = New System.Drawing.Point(105, 175)
        Me.txtEndingStatementBalance.Name = "txtEndingStatementBalance"
        Me.txtEndingStatementBalance.Size = New System.Drawing.Size(180, 20)
        Me.txtEndingStatementBalance.TabIndex = 5
        Me.txtEndingStatementBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(21, 211)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(98, 20)
        Me.Label31.TabIndex = 20
        Me.Label31.Text = "Status"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(21, 28)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(98, 20)
        Me.Label30.TabIndex = 17
        Me.Label30.Text = "Batch Number"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(21, 102)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 20)
        Me.Label27.TabIndex = 15
        Me.Label27.Text = "Post Date"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Bank Account"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(21, 175)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 20)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Ending Balance"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteBatch
        '
        Me.cmdDeleteBatch.Location = New System.Drawing.Point(24, 118)
        Me.cmdDeleteBatch.Name = "cmdDeleteBatch"
        Me.cmdDeleteBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteBatch.TabIndex = 9
        Me.cmdDeleteBatch.Text = "Delete"
        Me.cmdDeleteBatch.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(24, 46)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 8
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblClearedVariance)
        Me.GroupBox1.Controls.Add(Me.lblClearedEndingTotal)
        Me.GroupBox1.Controls.Add(Me.lblClearedSubtotal)
        Me.GroupBox1.Controls.Add(Me.lblClearedCredits)
        Me.GroupBox1.Controls.Add(Me.lblClearedDebits)
        Me.GroupBox1.Controls.Add(Me.lblClearedStatementBalance)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(336, 498)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 210)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cleared"
        '
        'lblClearedVariance
        '
        Me.lblClearedVariance.Location = New System.Drawing.Point(200, 166)
        Me.lblClearedVariance.Name = "lblClearedVariance"
        Me.lblClearedVariance.Size = New System.Drawing.Size(129, 23)
        Me.lblClearedVariance.TabIndex = 11
        Me.lblClearedVariance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClearedEndingTotal
        '
        Me.lblClearedEndingTotal.Location = New System.Drawing.Point(200, 138)
        Me.lblClearedEndingTotal.Name = "lblClearedEndingTotal"
        Me.lblClearedEndingTotal.Size = New System.Drawing.Size(129, 23)
        Me.lblClearedEndingTotal.TabIndex = 10
        Me.lblClearedEndingTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClearedSubtotal
        '
        Me.lblClearedSubtotal.Location = New System.Drawing.Point(200, 110)
        Me.lblClearedSubtotal.Name = "lblClearedSubtotal"
        Me.lblClearedSubtotal.Size = New System.Drawing.Size(129, 23)
        Me.lblClearedSubtotal.TabIndex = 9
        Me.lblClearedSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClearedCredits
        '
        Me.lblClearedCredits.Location = New System.Drawing.Point(200, 82)
        Me.lblClearedCredits.Name = "lblClearedCredits"
        Me.lblClearedCredits.Size = New System.Drawing.Size(129, 23)
        Me.lblClearedCredits.TabIndex = 8
        Me.lblClearedCredits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClearedDebits
        '
        Me.lblClearedDebits.Location = New System.Drawing.Point(200, 54)
        Me.lblClearedDebits.Name = "lblClearedDebits"
        Me.lblClearedDebits.Size = New System.Drawing.Size(129, 23)
        Me.lblClearedDebits.TabIndex = 7
        Me.lblClearedDebits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClearedStatementBalance
        '
        Me.lblClearedStatementBalance.Location = New System.Drawing.Point(200, 26)
        Me.lblClearedStatementBalance.Name = "lblClearedStatementBalance"
        Me.lblClearedStatementBalance.Size = New System.Drawing.Size(129, 23)
        Me.lblClearedStatementBalance.TabIndex = 6
        Me.lblClearedStatementBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(195, 23)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Variance"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(195, 23)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "End. Statement Total"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(195, 23)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Subtotal"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 23)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Cleared Credits"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(195, 23)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Cleared Debits"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Starting Statement Balance"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblOSVariance)
        Me.GroupBox2.Controls.Add(Me.lblBookBalance)
        Me.GroupBox2.Controls.Add(Me.lblOSEndingTotal)
        Me.GroupBox2.Controls.Add(Me.lblOSCredits)
        Me.GroupBox2.Controls.Add(Me.lblOSDebits)
        Me.GroupBox2.Controls.Add(Me.lblOSStatementBalance)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(694, 498)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 210)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Outstanding"
        '
        'lblOSVariance
        '
        Me.lblOSVariance.Location = New System.Drawing.Point(187, 166)
        Me.lblOSVariance.Name = "lblOSVariance"
        Me.lblOSVariance.Size = New System.Drawing.Size(129, 23)
        Me.lblOSVariance.TabIndex = 17
        Me.lblOSVariance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBookBalance
        '
        Me.lblBookBalance.Location = New System.Drawing.Point(187, 138)
        Me.lblBookBalance.Name = "lblBookBalance"
        Me.lblBookBalance.Size = New System.Drawing.Size(129, 23)
        Me.lblBookBalance.TabIndex = 16
        Me.lblBookBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOSEndingTotal
        '
        Me.lblOSEndingTotal.Location = New System.Drawing.Point(187, 110)
        Me.lblOSEndingTotal.Name = "lblOSEndingTotal"
        Me.lblOSEndingTotal.Size = New System.Drawing.Size(129, 23)
        Me.lblOSEndingTotal.TabIndex = 15
        Me.lblOSEndingTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOSCredits
        '
        Me.lblOSCredits.Location = New System.Drawing.Point(187, 82)
        Me.lblOSCredits.Name = "lblOSCredits"
        Me.lblOSCredits.Size = New System.Drawing.Size(129, 23)
        Me.lblOSCredits.TabIndex = 14
        Me.lblOSCredits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOSDebits
        '
        Me.lblOSDebits.Location = New System.Drawing.Point(187, 53)
        Me.lblOSDebits.Name = "lblOSDebits"
        Me.lblOSDebits.Size = New System.Drawing.Size(129, 23)
        Me.lblOSDebits.TabIndex = 13
        Me.lblOSDebits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOSStatementBalance
        '
        Me.lblOSStatementBalance.Location = New System.Drawing.Point(187, 26)
        Me.lblOSStatementBalance.Name = "lblOSStatementBalance"
        Me.lblOSStatementBalance.Size = New System.Drawing.Size(129, 23)
        Me.lblOSStatementBalance.TabIndex = 12
        Me.lblOSStatementBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 166)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(176, 23)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Variance"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(15, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(176, 23)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Book Balance"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(15, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(176, 23)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Ending Total"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(15, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(176, 23)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Outstanding Credits"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(15, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(176, 23)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Outstanding Debits"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(15, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(176, 23)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Ending Statement Balance"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 24)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 749)
        Me.Splitter1.TabIndex = 14
        Me.Splitter1.TabStop = False
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(105, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(180, 40)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "View Bank Transactions"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCheckAll
        '
        Me.cmdCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCheckAll.Location = New System.Drawing.Point(336, 442)
        Me.cmdCheckAll.Name = "cmdCheckAll"
        Me.cmdCheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdCheckAll.TabIndex = 19
        Me.cmdCheckAll.Text = "Check All"
        Me.cmdCheckAll.UseVisualStyleBackColor = True
        '
        'cmdUncheckAll
        '
        Me.cmdUncheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUncheckAll.Location = New System.Drawing.Point(412, 442)
        Me.cmdUncheckAll.Name = "cmdUncheckAll"
        Me.cmdUncheckAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdUncheckAll.TabIndex = 18
        Me.cmdUncheckAll.Text = "Uncheck All"
        Me.cmdUncheckAll.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.cmdPostBatch)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.cmdView)
        Me.GroupBox3.Controls.Add(Me.cmdDeleteBatch)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 430)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 331)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Banking Actions"
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(108, 118)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(177, 40)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Delete Batch"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPostBatch
        '
        Me.cmdPostBatch.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostBatch.Location = New System.Drawing.Point(24, 262)
        Me.cmdPostBatch.Name = "cmdPostBatch"
        Me.cmdPostBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostBatch.TabIndex = 11
        Me.cmdPostBatch.Text = "Post"
        Me.cmdPostBatch.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 190)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 40)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvBankRec
        '
        Me.dgvBankRec.AllowUserToAddRows = False
        Me.dgvBankRec.AllowUserToDeleteRows = False
        Me.dgvBankRec.AutoGenerateColumns = False
        Me.dgvBankRec.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvBankRec.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvBankRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBankRec.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectColumn, Me.TransactionDateColumn, Me.PayerPayeeColumn, Me.CheckNumberColumn, Me.PaymentNumberColumn, Me.DebitAmountColumn, Me.CreditAmountColumn, Me.TransactionNumberColumn, Me.TransactionTypeColumn, Me.DescriptionColumn, Me.DivisionIDColumn, Me.CommentColumn, Me.StatusColumn, Me.BatchNumberColumn})
        Me.dgvBankRec.DataSource = Me.BankReconciliationLineTableBindingSource
        Me.dgvBankRec.GridColor = System.Drawing.Color.Blue
        Me.dgvBankRec.Location = New System.Drawing.Point(335, 41)
        Me.dgvBankRec.Name = "dgvBankRec"
        Me.dgvBankRec.Size = New System.Drawing.Size(695, 395)
        Me.dgvBankRec.TabIndex = 20
        '
        'SelectColumn
        '
        Me.SelectColumn.DataPropertyName = "CheckOrUncheck"
        Me.SelectColumn.FalseValue = "UNCHECKED"
        Me.SelectColumn.HeaderText = "Select"
        Me.SelectColumn.IndeterminateValue = "UNCHECKED"
        Me.SelectColumn.Name = "SelectColumn"
        Me.SelectColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SelectColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SelectColumn.TrueValue = "CHECKED"
        Me.SelectColumn.Width = 80
        '
        'TransactionDateColumn
        '
        Me.TransactionDateColumn.DataPropertyName = "Date"
        Me.TransactionDateColumn.HeaderText = "Date"
        Me.TransactionDateColumn.Name = "TransactionDateColumn"
        Me.TransactionDateColumn.Width = 80
        '
        'PayerPayeeColumn
        '
        Me.PayerPayeeColumn.DataPropertyName = "PayerPayee"
        Me.PayerPayeeColumn.HeaderText = "Payer/Payee"
        Me.PayerPayeeColumn.Name = "PayerPayeeColumn"
        '
        'CheckNumberColumn
        '
        Me.CheckNumberColumn.DataPropertyName = "CheckNumber"
        Me.CheckNumberColumn.HeaderText = "Check #"
        Me.CheckNumberColumn.Name = "CheckNumberColumn"
        Me.CheckNumberColumn.Width = 80
        '
        'PaymentNumberColumn
        '
        Me.PaymentNumberColumn.DataPropertyName = "PaymentNumber"
        Me.PaymentNumberColumn.HeaderText = "Payment #"
        Me.PaymentNumberColumn.Name = "PaymentNumberColumn"
        Me.PaymentNumberColumn.Width = 80
        '
        'DebitAmountColumn
        '
        Me.DebitAmountColumn.DataPropertyName = "DebitAmount"
        Me.DebitAmountColumn.HeaderText = "Debit Amount"
        Me.DebitAmountColumn.Name = "DebitAmountColumn"
        Me.DebitAmountColumn.Width = 80
        '
        'CreditAmountColumn
        '
        Me.CreditAmountColumn.DataPropertyName = "CreditAmount"
        Me.CreditAmountColumn.HeaderText = "Credit Amount"
        Me.CreditAmountColumn.Name = "CreditAmountColumn"
        Me.CreditAmountColumn.Width = 80
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "Trans. #"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.Visible = False
        '
        'TransactionTypeColumn
        '
        Me.TransactionTypeColumn.DataPropertyName = "TransactionType"
        Me.TransactionTypeColumn.HeaderText = "Trans. Type"
        Me.TransactionTypeColumn.Name = "TransactionTypeColumn"
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "BatchNumber"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Visible = False
        '
        'BankReconciliationLineTableBindingSource
        '
        Me.BankReconciliationLineTableBindingSource.DataMember = "BankReconciliationLineTable"
        Me.BankReconciliationLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'BankReconciliationLineTableTableAdapter
        '
        Me.BankReconciliationLineTableTableAdapter.ClearBeforeFill = True
        '
        'BankReconciliationBatchHeaderTableAdapter
        '
        Me.BankReconciliationBatchHeaderTableAdapter.ClearBeforeFill = True
        '
        'dgvARPaymentLog
        '
        Me.dgvARPaymentLog.AllowUserToAddRows = False
        Me.dgvARPaymentLog.AllowUserToDeleteRows = False
        Me.dgvARPaymentLog.AutoGenerateColumns = False
        Me.dgvARPaymentLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvARPaymentLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ARPaymentIDColumn, Me.ARPaymentNumberColumn, Me.ARBatchNumberColumn, Me.ARCustomerIDColumn, Me.ARPaymentAmountColumn, Me.ARPaymentDateColumn, Me.ARDivisionIDColumn, Me.ARPaymentTypeColumn, Me.ARPaymentStatusColumn})
        Me.dgvARPaymentLog.DataSource = Me.ARPaymentLogBindingSource
        Me.dgvARPaymentLog.Location = New System.Drawing.Point(364, 227)
        Me.dgvARPaymentLog.Name = "dgvARPaymentLog"
        Me.dgvARPaymentLog.ReadOnly = True
        Me.dgvARPaymentLog.Size = New System.Drawing.Size(240, 150)
        Me.dgvARPaymentLog.TabIndex = 21
        '
        'ARPaymentIDColumn
        '
        Me.ARPaymentIDColumn.DataPropertyName = "PaymentID"
        Me.ARPaymentIDColumn.HeaderText = "PaymentID"
        Me.ARPaymentIDColumn.Name = "ARPaymentIDColumn"
        Me.ARPaymentIDColumn.ReadOnly = True
        '
        'ARPaymentNumberColumn
        '
        Me.ARPaymentNumberColumn.DataPropertyName = "ARPaymentNumber"
        Me.ARPaymentNumberColumn.HeaderText = "ARPaymentNumber"
        Me.ARPaymentNumberColumn.Name = "ARPaymentNumberColumn"
        Me.ARPaymentNumberColumn.ReadOnly = True
        '
        'ARBatchNumberColumn
        '
        Me.ARBatchNumberColumn.DataPropertyName = "ARBatchNumber"
        Me.ARBatchNumberColumn.HeaderText = "ARBatchNumber"
        Me.ARBatchNumberColumn.Name = "ARBatchNumberColumn"
        Me.ARBatchNumberColumn.ReadOnly = True
        '
        'ARCustomerIDColumn
        '
        Me.ARCustomerIDColumn.DataPropertyName = "CustomerID"
        Me.ARCustomerIDColumn.HeaderText = "CustomerID"
        Me.ARCustomerIDColumn.Name = "ARCustomerIDColumn"
        Me.ARCustomerIDColumn.ReadOnly = True
        '
        'ARPaymentAmountColumn
        '
        Me.ARPaymentAmountColumn.DataPropertyName = "PaymentAmount"
        Me.ARPaymentAmountColumn.HeaderText = "PaymentAmount"
        Me.ARPaymentAmountColumn.Name = "ARPaymentAmountColumn"
        Me.ARPaymentAmountColumn.ReadOnly = True
        '
        'ARPaymentDateColumn
        '
        Me.ARPaymentDateColumn.DataPropertyName = "PaymentDate"
        Me.ARPaymentDateColumn.HeaderText = "PaymentDate"
        Me.ARPaymentDateColumn.Name = "ARPaymentDateColumn"
        Me.ARPaymentDateColumn.ReadOnly = True
        '
        'ARDivisionIDColumn
        '
        Me.ARDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.ARDivisionIDColumn.HeaderText = "DivisionID"
        Me.ARDivisionIDColumn.Name = "ARDivisionIDColumn"
        Me.ARDivisionIDColumn.ReadOnly = True
        '
        'ARPaymentTypeColumn
        '
        Me.ARPaymentTypeColumn.DataPropertyName = "PaymentType"
        Me.ARPaymentTypeColumn.HeaderText = "PaymentType"
        Me.ARPaymentTypeColumn.Name = "ARPaymentTypeColumn"
        Me.ARPaymentTypeColumn.ReadOnly = True
        '
        'ARPaymentStatusColumn
        '
        Me.ARPaymentStatusColumn.DataPropertyName = "PaymentStatus"
        Me.ARPaymentStatusColumn.HeaderText = "PaymentStatus"
        Me.ARPaymentStatusColumn.Name = "ARPaymentStatusColumn"
        Me.ARPaymentStatusColumn.ReadOnly = True
        '
        'ARPaymentLogBindingSource
        '
        Me.ARPaymentLogBindingSource.DataMember = "ARPaymentLog"
        Me.ARPaymentLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ARPaymentLogTableAdapter
        '
        Me.ARPaymentLogTableAdapter.ClearBeforeFill = True
        '
        'dgvAPCheckLog
        '
        Me.dgvAPCheckLog.AllowUserToAddRows = False
        Me.dgvAPCheckLog.AllowUserToDeleteRows = False
        Me.dgvAPCheckLog.AutoGenerateColumns = False
        Me.dgvAPCheckLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPCheckLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.CheckAmountDataGridViewTextBoxColumn, Me.CheckDateDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn2, Me.VendorIDDataGridViewTextBoxColumn, Me.VendorClassDataGridViewTextBoxColumn, Me.APBatchNumberDataGridViewTextBoxColumn, Me.CheckStatusDataGridViewTextBoxColumn})
        Me.dgvAPCheckLog.DataSource = Me.APCheckLogBindingSource
        Me.dgvAPCheckLog.Location = New System.Drawing.Point(364, 180)
        Me.dgvAPCheckLog.Name = "dgvAPCheckLog"
        Me.dgvAPCheckLog.ReadOnly = True
        Me.dgvAPCheckLog.Size = New System.Drawing.Size(240, 150)
        Me.dgvAPCheckLog.TabIndex = 22
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CheckNumber"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CheckNumber"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'CheckAmountDataGridViewTextBoxColumn
        '
        Me.CheckAmountDataGridViewTextBoxColumn.DataPropertyName = "CheckAmount"
        Me.CheckAmountDataGridViewTextBoxColumn.HeaderText = "CheckAmount"
        Me.CheckAmountDataGridViewTextBoxColumn.Name = "CheckAmountDataGridViewTextBoxColumn"
        Me.CheckAmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CheckDateDataGridViewTextBoxColumn
        '
        Me.CheckDateDataGridViewTextBoxColumn.DataPropertyName = "CheckDate"
        Me.CheckDateDataGridViewTextBoxColumn.HeaderText = "CheckDate"
        Me.CheckDateDataGridViewTextBoxColumn.Name = "CheckDateDataGridViewTextBoxColumn"
        Me.CheckDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DivisionID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "DivisionID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'VendorIDDataGridViewTextBoxColumn
        '
        Me.VendorIDDataGridViewTextBoxColumn.DataPropertyName = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn.HeaderText = "VendorID"
        Me.VendorIDDataGridViewTextBoxColumn.Name = "VendorIDDataGridViewTextBoxColumn"
        Me.VendorIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VendorClassDataGridViewTextBoxColumn
        '
        Me.VendorClassDataGridViewTextBoxColumn.DataPropertyName = "VendorClass"
        Me.VendorClassDataGridViewTextBoxColumn.HeaderText = "VendorClass"
        Me.VendorClassDataGridViewTextBoxColumn.Name = "VendorClassDataGridViewTextBoxColumn"
        Me.VendorClassDataGridViewTextBoxColumn.ReadOnly = True
        '
        'APBatchNumberDataGridViewTextBoxColumn
        '
        Me.APBatchNumberDataGridViewTextBoxColumn.DataPropertyName = "APBatchNumber"
        Me.APBatchNumberDataGridViewTextBoxColumn.HeaderText = "APBatchNumber"
        Me.APBatchNumberDataGridViewTextBoxColumn.Name = "APBatchNumberDataGridViewTextBoxColumn"
        Me.APBatchNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CheckStatusDataGridViewTextBoxColumn
        '
        Me.CheckStatusDataGridViewTextBoxColumn.DataPropertyName = "CheckStatus"
        Me.CheckStatusDataGridViewTextBoxColumn.HeaderText = "CheckStatus"
        Me.CheckStatusDataGridViewTextBoxColumn.Name = "CheckStatusDataGridViewTextBoxColumn"
        Me.CheckStatusDataGridViewTextBoxColumn.ReadOnly = True
        '
        'APCheckLogBindingSource
        '
        Me.APCheckLogBindingSource.DataMember = "APCheckLog"
        Me.APCheckLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'APCheckLogTableAdapter
        '
        Me.APCheckLogTableAdapter.ClearBeforeFill = True
        '
        'dgvBankTransactions
        '
        Me.dgvBankTransactions.AllowUserToAddRows = False
        Me.dgvBankTransactions.AllowUserToDeleteRows = False
        Me.dgvBankTransactions.AutoGenerateColumns = False
        Me.dgvBankTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBankTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BTTransactionNumberColumn, Me.BTBatchNumberColumn, Me.BTDivisionIDColumn, Me.BTTransactionTypeColumn, Me.BTTransactionDateColumn, Me.BTDebitAmountColumn, Me.BTCreditAmountColumn, Me.BTCommentColumn, Me.BTStatusColumn, Me.BTGLAccountColumn})
        Me.dgvBankTransactions.DataSource = Me.BankTransactionsBindingSource
        Me.dgvBankTransactions.Location = New System.Drawing.Point(484, 179)
        Me.dgvBankTransactions.Name = "dgvBankTransactions"
        Me.dgvBankTransactions.ReadOnly = True
        Me.dgvBankTransactions.Size = New System.Drawing.Size(240, 150)
        Me.dgvBankTransactions.TabIndex = 23
        '
        'BTTransactionNumberColumn
        '
        Me.BTTransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.BTTransactionNumberColumn.HeaderText = "TransactionNumber"
        Me.BTTransactionNumberColumn.Name = "BTTransactionNumberColumn"
        Me.BTTransactionNumberColumn.ReadOnly = True
        '
        'BTBatchNumberColumn
        '
        Me.BTBatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BTBatchNumberColumn.HeaderText = "BatchNumber"
        Me.BTBatchNumberColumn.Name = "BTBatchNumberColumn"
        Me.BTBatchNumberColumn.ReadOnly = True
        '
        'BTDivisionIDColumn
        '
        Me.BTDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.BTDivisionIDColumn.HeaderText = "DivisionID"
        Me.BTDivisionIDColumn.Name = "BTDivisionIDColumn"
        Me.BTDivisionIDColumn.ReadOnly = True
        '
        'BTTransactionTypeColumn
        '
        Me.BTTransactionTypeColumn.DataPropertyName = "TransactionType"
        Me.BTTransactionTypeColumn.HeaderText = "TransactionType"
        Me.BTTransactionTypeColumn.Name = "BTTransactionTypeColumn"
        Me.BTTransactionTypeColumn.ReadOnly = True
        '
        'BTTransactionDateColumn
        '
        Me.BTTransactionDateColumn.DataPropertyName = "TransactionDate"
        Me.BTTransactionDateColumn.HeaderText = "TransactionDate"
        Me.BTTransactionDateColumn.Name = "BTTransactionDateColumn"
        Me.BTTransactionDateColumn.ReadOnly = True
        '
        'BTDebitAmountColumn
        '
        Me.BTDebitAmountColumn.DataPropertyName = "DebitAmount"
        Me.BTDebitAmountColumn.HeaderText = "DebitAmount"
        Me.BTDebitAmountColumn.Name = "BTDebitAmountColumn"
        Me.BTDebitAmountColumn.ReadOnly = True
        '
        'BTCreditAmountColumn
        '
        Me.BTCreditAmountColumn.DataPropertyName = "CreditAmount"
        Me.BTCreditAmountColumn.HeaderText = "CreditAmount"
        Me.BTCreditAmountColumn.Name = "BTCreditAmountColumn"
        Me.BTCreditAmountColumn.ReadOnly = True
        '
        'BTCommentColumn
        '
        Me.BTCommentColumn.DataPropertyName = "Comment"
        Me.BTCommentColumn.HeaderText = "Comment"
        Me.BTCommentColumn.Name = "BTCommentColumn"
        Me.BTCommentColumn.ReadOnly = True
        '
        'BTStatusColumn
        '
        Me.BTStatusColumn.DataPropertyName = "Status"
        Me.BTStatusColumn.HeaderText = "Status"
        Me.BTStatusColumn.Name = "BTStatusColumn"
        Me.BTStatusColumn.ReadOnly = True
        '
        'BTGLAccountColumn
        '
        Me.BTGLAccountColumn.DataPropertyName = "GLAccount"
        Me.BTGLAccountColumn.HeaderText = "GLAccount"
        Me.BTGLAccountColumn.Name = "BTGLAccountColumn"
        Me.BTGLAccountColumn.ReadOnly = True
        '
        'BankTransactionsBindingSource
        '
        Me.BankTransactionsBindingSource.DataMember = "BankTransactions"
        Me.BankTransactionsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'BankTransactionsTableAdapter
        '
        Me.BankTransactionsTableAdapter.ClearBeforeFill = True
        '
        'txtOne
        '
        Me.txtOne.Location = New System.Drawing.Point(514, 453)
        Me.txtOne.Name = "txtOne"
        Me.txtOne.Size = New System.Drawing.Size(244, 20)
        Me.txtOne.TabIndex = 24
        '
        'txtTwo
        '
        Me.txtTwo.Location = New System.Drawing.Point(766, 453)
        Me.txtTwo.Name = "txtTwo"
        Me.txtTwo.Size = New System.Drawing.Size(244, 20)
        Me.txtTwo.TabIndex = 25
        '
        'BankReconciliation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 773)
        Me.Controls.Add(Me.txtTwo)
        Me.Controls.Add(Me.txtOne)
        Me.Controls.Add(Me.dgvBankRec)
        Me.Controls.Add(Me.cmdCheckAll)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdUncheckAll)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.gpxBankData)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvARPaymentLog)
        Me.Controls.Add(Me.dgvAPCheckLog)
        Me.Controls.Add(Me.dgvBankTransactions)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "BankReconciliation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Bank Reconciliation"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxBankData.ResumeLayout(False)
        Me.gpxBankData.PerformLayout()
        CType(Me.BankReconciliationBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvBankRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BankReconciliationLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvARPaymentLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARPaymentLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAPCheckLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APCheckLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBankTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BankTransactionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxBankData As System.Windows.Forms.GroupBox
    Friend WithEvents cboBankAccount As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteBatch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblClearedVariance As System.Windows.Forms.Label
    Friend WithEvents lblClearedEndingTotal As System.Windows.Forms.Label
    Friend WithEvents lblClearedSubtotal As System.Windows.Forms.Label
    Friend WithEvents lblClearedCredits As System.Windows.Forms.Label
    Friend WithEvents lblClearedDebits As System.Windows.Forms.Label
    Friend WithEvents lblClearedStatementBalance As System.Windows.Forms.Label
    Friend WithEvents lblOSVariance As System.Windows.Forms.Label
    Friend WithEvents lblBookBalance As System.Windows.Forms.Label
    Friend WithEvents lblOSEndingTotal As System.Windows.Forms.Label
    Friend WithEvents lblOSCredits As System.Windows.Forms.Label
    Friend WithEvents lblOSDebits As System.Windows.Forms.Label
    Friend WithEvents lblOSStatementBalance As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents dtpPostDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmdCheckAll As System.Windows.Forms.Button
    Friend WithEvents cmdUncheckAll As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PrintBankReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BTBankAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTOffsetAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtEndingStatementBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cboBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateNewBatch As System.Windows.Forms.Button
    Friend WithEvents txtBatchStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPostBatch As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dgvBankRec As System.Windows.Forms.DataGridView
    Friend WithEvents CheckNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PayerPayeeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankReconciliationLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BankReconciliationLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankReconciliationLineTableTableAdapter
    Friend WithEvents BankReconciliationBatchHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BankReconciliationBatchHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankReconciliationBatchHeaderTableAdapter
    Friend WithEvents dgvARPaymentLog As System.Windows.Forms.DataGridView
    Friend WithEvents ARPaymentLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARPaymentLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARPaymentLogTableAdapter
    Friend WithEvents ARPaymentIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARPaymentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARCustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARPaymentAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARPaymentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARPaymentTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARPaymentStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvAPCheckLog As System.Windows.Forms.DataGridView
    Friend WithEvents APCheckLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APCheckLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLogTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorClassDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APBatchNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvBankTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents BankTransactionsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BankTransactionsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BankTransactionsTableAdapter
    Friend WithEvents BTTransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTTransactionTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTTransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PayerPayeeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtOne As System.Windows.Forms.TextBox
    Friend WithEvents txtTwo As System.Windows.Forms.TextBox
End Class
