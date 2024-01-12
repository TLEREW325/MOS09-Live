<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FinancialReports
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
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdoTwoYear = New System.Windows.Forms.RadioButton
        Me.rdoStandard = New System.Windows.Forms.RadioButton
        Me.cmdIncomeStatement = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpIncomeSelectDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpBalanceSheetSelectDate = New System.Windows.Forms.DateTimePicker
        Me.cmdPrintBalanceSheet = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdInventoryValuation = New System.Windows.Forms.Button
        Me.dtpInventorySelectDate = New System.Windows.Forms.DateTimePicker
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chkNonZero = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdPrintTrialBalance = New System.Windows.Forms.Button
        Me.dtpTrialBalanceSelectDate = New System.Windows.Forms.DateTimePicker
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.cmdAgedPayables = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.cmdAgedReceivables = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgvInventoryTransactions = New System.Windows.Forms.DataGridView
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityDataColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionMathColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryTransactionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventoryTransactionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryTransactionTableTableAdapter
        Me.dgvValuationSummary = New System.Windows.Forms.DataGridView
        Me.DivisionIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LongDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SumQuantityAddDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SumQuantitySubtractDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NetQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SumCostAddDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SumCostSubtractDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NetCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AverageCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLInventoryAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ADDGLAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SUBTRACTGLAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryValuationSummaryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventoryValuationSummaryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryValuationSummaryTableAdapter
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.cmdPrintInvoiceLinesReport = New System.Windows.Forms.Button
        Me.ofdBlueprints = New System.Windows.Forms.OpenFileDialog
        Me.cmdTestOpenFile = New System.Windows.Forms.Button
        Me.dgvGLTransactions = New System.Windows.Forms.DataGridView
        Me.GLAccountNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLJournalIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLReferenceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountCashFlowCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionMasterListQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLTransactionMasterListQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListQueryTableAdapter
        Me.dgvGLValuation = New System.Windows.Forms.DataGridView
        Me.GLAccountNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountShortDescriptionDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BeginningBalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EndingBalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLTransactionValuationFinalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GLTransactionValuationFinalTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionValuationFinalTableAdapter
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.lblMonth = New System.Windows.Forms.Label
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.rdoSalesByTerritory = New System.Windows.Forms.RadioButton
        Me.rdoSalesByState = New System.Windows.Forms.RadioButton
        Me.rdoSalesByItemClass = New System.Windows.Forms.RadioButton
        Me.rdoConsignmentSales = New System.Windows.Forms.RadioButton
        Me.rdoDailySales = New System.Windows.Forms.RadioButton
        Me.cmdReprintMonthReports = New System.Windows.Forms.Button
        Me.CRMonthViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXConsignmentBillingMonth1 = New MOS09Program.CRXConsignmentBillingMonth
        Me.CRXInvoiceDailyTotalsMonth1 = New MOS09Program.CRXInvoiceDailyTotalsMonth
        Me.CRXSalesByItemClass_TWDMonth1 = New MOS09Program.CRXSalesByItemClass_TWDMonth
        Me.CRXCustMTD_YTDInvoicesbyStateMonth1 = New MOS09Program.CRXCustMTD_YTDInvoicesbyStateMonth
        Me.CRXCustMTD_YTDInvoicesbyTerritoryMonth1 = New MOS09Program.CRXCustMTD_YTDInvoicesbyTerritoryMonth
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.dgvInventoryTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvValuationSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryValuationSummaryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.dgvGLTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLTransactionMasterListQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGLValuation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLTransactionValuationFinalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 671)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 11
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 671)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoTwoYear)
        Me.GroupBox1.Controls.Add(Me.rdoStandard)
        Me.GroupBox1.Controls.Add(Me.cmdIncomeStatement)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpIncomeSelectDate)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 167)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Income Statement"
        '
        'rdoTwoYear
        '
        Me.rdoTwoYear.AutoSize = True
        Me.rdoTwoYear.Location = New System.Drawing.Point(24, 125)
        Me.rdoTwoYear.Name = "rdoTwoYear"
        Me.rdoTwoYear.Size = New System.Drawing.Size(160, 17)
        Me.rdoTwoYear.TabIndex = 15
        Me.rdoTwoYear.TabStop = True
        Me.rdoTwoYear.Text = "Two Year Income Statement"
        Me.rdoTwoYear.UseVisualStyleBackColor = True
        '
        'rdoStandard
        '
        Me.rdoStandard.AutoSize = True
        Me.rdoStandard.Checked = True
        Me.rdoStandard.Location = New System.Drawing.Point(24, 90)
        Me.rdoStandard.Name = "rdoStandard"
        Me.rdoStandard.Size = New System.Drawing.Size(157, 17)
        Me.rdoStandard.TabIndex = 14
        Me.rdoStandard.TabStop = True
        Me.rdoStandard.Text = "Standard Income Statement"
        Me.rdoStandard.UseVisualStyleBackColor = True
        '
        'cmdIncomeStatement
        '
        Me.cmdIncomeStatement.Location = New System.Drawing.Point(253, 107)
        Me.cmdIncomeStatement.Name = "cmdIncomeStatement"
        Me.cmdIncomeStatement.Size = New System.Drawing.Size(71, 40)
        Me.cmdIncomeStatement.TabIndex = 13
        Me.cmdIncomeStatement.Text = "Print"
        Me.cmdIncomeStatement.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(23, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Select Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpIncomeSelectDate
        '
        Me.dtpIncomeSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIncomeSelectDate.Location = New System.Drawing.Point(142, 42)
        Me.dtpIncomeSelectDate.Name = "dtpIncomeSelectDate"
        Me.dtpIncomeSelectDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpIncomeSelectDate.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(22, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Select Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBalanceSheetSelectDate
        '
        Me.dtpBalanceSheetSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBalanceSheetSelectDate.Location = New System.Drawing.Point(143, 25)
        Me.dtpBalanceSheetSelectDate.Name = "dtpBalanceSheetSelectDate"
        Me.dtpBalanceSheetSelectDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpBalanceSheetSelectDate.TabIndex = 15
        '
        'cmdPrintBalanceSheet
        '
        Me.cmdPrintBalanceSheet.Location = New System.Drawing.Point(253, 61)
        Me.cmdPrintBalanceSheet.Name = "cmdPrintBalanceSheet"
        Me.cmdPrintBalanceSheet.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintBalanceSheet.TabIndex = 14
        Me.cmdPrintBalanceSheet.Text = "Print"
        Me.cmdPrintBalanceSheet.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cboDivisionID)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(350, 88)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Company Division"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(23, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(142, 39)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(182, 21)
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
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.cmdPrintBalanceSheet)
        Me.GroupBox4.Controls.Add(Me.dtpBalanceSheetSelectDate)
        Me.GroupBox4.Location = New System.Drawing.Point(29, 326)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(350, 118)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Balance Sheet"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cmdInventoryValuation)
        Me.GroupBox2.Controls.Add(Me.dtpInventorySelectDate)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 459)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(350, 118)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Inventory Valuation"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Select Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdInventoryValuation
        '
        Me.cmdInventoryValuation.Location = New System.Drawing.Point(252, 61)
        Me.cmdInventoryValuation.Name = "cmdInventoryValuation"
        Me.cmdInventoryValuation.Size = New System.Drawing.Size(71, 40)
        Me.cmdInventoryValuation.TabIndex = 17
        Me.cmdInventoryValuation.Text = "Print"
        Me.cmdInventoryValuation.UseVisualStyleBackColor = True
        '
        'dtpInventorySelectDate
        '
        Me.dtpInventorySelectDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInventorySelectDate.Location = New System.Drawing.Point(142, 25)
        Me.dtpInventorySelectDate.Name = "dtpInventorySelectDate"
        Me.dtpInventorySelectDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpInventorySelectDate.TabIndex = 18
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkNonZero)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.cmdPrintTrialBalance)
        Me.GroupBox5.Controls.Add(Me.dtpTrialBalanceSelectDate)
        Me.GroupBox5.Location = New System.Drawing.Point(29, 593)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(350, 118)
        Me.GroupBox5.TabIndex = 18
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Trial Balance"
        '
        'chkNonZero
        '
        Me.chkNonZero.AutoSize = True
        Me.chkNonZero.Checked = True
        Me.chkNonZero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNonZero.ForeColor = System.Drawing.Color.Blue
        Me.chkNonZero.Location = New System.Drawing.Point(21, 74)
        Me.chkNonZero.Name = "chkNonZero"
        Me.chkNonZero.Size = New System.Drawing.Size(209, 17)
        Me.chkNonZero.TabIndex = 23
        Me.chkNonZero.Text = "Suppress accounts that have all zeros."
        Me.chkNonZero.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(24, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Select Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintTrialBalance
        '
        Me.cmdPrintTrialBalance.Location = New System.Drawing.Point(252, 61)
        Me.cmdPrintTrialBalance.Name = "cmdPrintTrialBalance"
        Me.cmdPrintTrialBalance.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintTrialBalance.TabIndex = 20
        Me.cmdPrintTrialBalance.Text = "Print"
        Me.cmdPrintTrialBalance.UseVisualStyleBackColor = True
        '
        'dtpTrialBalanceSelectDate
        '
        Me.dtpTrialBalanceSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTrialBalanceSelectDate.Location = New System.Drawing.Point(145, 25)
        Me.dtpTrialBalanceSelectDate.Name = "dtpTrialBalanceSelectDate"
        Me.dtpTrialBalanceSelectDate.Size = New System.Drawing.Size(182, 20)
        Me.dtpTrialBalanceSelectDate.TabIndex = 21
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cmdAgedPayables)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Location = New System.Drawing.Point(399, 41)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(299, 92)
        Me.GroupBox6.TabIndex = 19
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Aged Payables By Date"
        '
        'cmdAgedPayables
        '
        Me.cmdAgedPayables.Location = New System.Drawing.Point(215, 30)
        Me.cmdAgedPayables.Name = "cmdAgedPayables"
        Me.cmdAgedPayables.Size = New System.Drawing.Size(71, 40)
        Me.cmdAgedPayables.TabIndex = 17
        Me.cmdAgedPayables.Text = "Open"
        Me.cmdAgedPayables.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(16, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 40)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Opens Payable Aging by Date Form"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cmdAgedReceivables)
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Location = New System.Drawing.Point(399, 139)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(299, 92)
        Me.GroupBox7.TabIndex = 20
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Aged Receivables By Date"
        '
        'cmdAgedReceivables
        '
        Me.cmdAgedReceivables.Location = New System.Drawing.Point(215, 31)
        Me.cmdAgedReceivables.Name = "cmdAgedReceivables"
        Me.cmdAgedReceivables.Size = New System.Drawing.Size(71, 40)
        Me.cmdAgedReceivables.TabIndex = 17
        Me.cmdAgedReceivables.Text = "Open"
        Me.cmdAgedReceivables.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(16, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(218, 40)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Opens Receivable Aging by Date Form"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvInventoryTransactions
        '
        Me.dgvInventoryTransactions.AllowUserToAddRows = False
        Me.dgvInventoryTransactions.AllowUserToDeleteRows = False
        Me.dgvInventoryTransactions.AutoGenerateColumns = False
        Me.dgvInventoryTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransactionNumberColumn, Me.TransactionDateColumn, Me.TransactionTypeColumn, Me.TransactionTypeNumberColumn, Me.TransactionTypeLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityDataColumn, Me.ItemCostColumn, Me.ExtendedCostColumn, Me.ItemPriceColumn, Me.ExtendedAmountColumn, Me.DivisionIDColumn, Me.TransactionMathColumn, Me.GLAccountColumn})
        Me.dgvInventoryTransactions.DataSource = Me.InventoryTransactionTableBindingSource
        Me.dgvInventoryTransactions.Location = New System.Drawing.Point(87, 470)
        Me.dgvInventoryTransactions.Name = "dgvInventoryTransactions"
        Me.dgvInventoryTransactions.ReadOnly = True
        Me.dgvInventoryTransactions.Size = New System.Drawing.Size(240, 61)
        Me.dgvInventoryTransactions.TabIndex = 21
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "TransactionNumber"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.ReadOnly = True
        '
        'TransactionDateColumn
        '
        Me.TransactionDateColumn.DataPropertyName = "TransactionDate"
        Me.TransactionDateColumn.HeaderText = "TransactionDate"
        Me.TransactionDateColumn.Name = "TransactionDateColumn"
        Me.TransactionDateColumn.ReadOnly = True
        '
        'TransactionTypeColumn
        '
        Me.TransactionTypeColumn.DataPropertyName = "TransactionType"
        Me.TransactionTypeColumn.HeaderText = "TransactionType"
        Me.TransactionTypeColumn.Name = "TransactionTypeColumn"
        Me.TransactionTypeColumn.ReadOnly = True
        '
        'TransactionTypeNumberColumn
        '
        Me.TransactionTypeNumberColumn.DataPropertyName = "TransactionTypeNumber"
        Me.TransactionTypeNumberColumn.HeaderText = "TransactionTypeNumber"
        Me.TransactionTypeNumberColumn.Name = "TransactionTypeNumberColumn"
        Me.TransactionTypeNumberColumn.ReadOnly = True
        '
        'TransactionTypeLineNumberColumn
        '
        Me.TransactionTypeLineNumberColumn.DataPropertyName = "TransactionTypeLineNumber"
        Me.TransactionTypeLineNumberColumn.HeaderText = "TransactionTypeLineNumber"
        Me.TransactionTypeLineNumberColumn.Name = "TransactionTypeLineNumberColumn"
        Me.TransactionTypeLineNumberColumn.ReadOnly = True
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "PartNumber"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "PartDescription"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        '
        'QuantityDataColumn
        '
        Me.QuantityDataColumn.DataPropertyName = "Quantity"
        Me.QuantityDataColumn.HeaderText = "Quantity"
        Me.QuantityDataColumn.Name = "QuantityDataColumn"
        Me.QuantityDataColumn.ReadOnly = True
        '
        'ItemCostColumn
        '
        Me.ItemCostColumn.DataPropertyName = "ItemCost"
        Me.ItemCostColumn.HeaderText = "ItemCost"
        Me.ItemCostColumn.Name = "ItemCostColumn"
        Me.ItemCostColumn.ReadOnly = True
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        Me.ExtendedCostColumn.HeaderText = "ExtendedCost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        Me.ExtendedCostColumn.ReadOnly = True
        '
        'ItemPriceColumn
        '
        Me.ItemPriceColumn.DataPropertyName = "ItemPrice"
        Me.ItemPriceColumn.HeaderText = "ItemPrice"
        Me.ItemPriceColumn.Name = "ItemPriceColumn"
        Me.ItemPriceColumn.ReadOnly = True
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "ExtendedAmount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        '
        'TransactionMathColumn
        '
        Me.TransactionMathColumn.DataPropertyName = "TransactionMath"
        Me.TransactionMathColumn.HeaderText = "TransactionMath"
        Me.TransactionMathColumn.Name = "TransactionMathColumn"
        Me.TransactionMathColumn.ReadOnly = True
        '
        'GLAccountColumn
        '
        Me.GLAccountColumn.DataPropertyName = "GLAccount"
        Me.GLAccountColumn.HeaderText = "GLAccount"
        Me.GLAccountColumn.Name = "GLAccountColumn"
        Me.GLAccountColumn.ReadOnly = True
        '
        'InventoryTransactionTableBindingSource
        '
        Me.InventoryTransactionTableBindingSource.DataMember = "InventoryTransactionTable"
        Me.InventoryTransactionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InventoryTransactionTableTableAdapter
        '
        Me.InventoryTransactionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvValuationSummary
        '
        Me.dgvValuationSummary.AllowUserToAddRows = False
        Me.dgvValuationSummary.AllowUserToDeleteRows = False
        Me.dgvValuationSummary.AutoGenerateColumns = False
        Me.dgvValuationSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvValuationSummary.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDDataGridViewTextBoxColumn1, Me.ItemIDDataGridViewTextBoxColumn, Me.ShortDescriptionDataGridViewTextBoxColumn, Me.LongDescriptionDataGridViewTextBoxColumn, Me.SumQuantityAddDataGridViewTextBoxColumn, Me.SumQuantitySubtractDataGridViewTextBoxColumn, Me.NetQuantityDataGridViewTextBoxColumn, Me.SumCostAddDataGridViewTextBoxColumn, Me.SumCostSubtractDataGridViewTextBoxColumn, Me.NetCostDataGridViewTextBoxColumn, Me.AverageCostDataGridViewTextBoxColumn, Me.GLInventoryAccountDataGridViewTextBoxColumn, Me.ADDGLAccountDataGridViewTextBoxColumn, Me.SUBTRACTGLAccountDataGridViewTextBoxColumn})
        Me.dgvValuationSummary.DataSource = Me.InventoryValuationSummaryBindingSource
        Me.dgvValuationSummary.Location = New System.Drawing.Point(87, 465)
        Me.dgvValuationSummary.Name = "dgvValuationSummary"
        Me.dgvValuationSummary.ReadOnly = True
        Me.dgvValuationSummary.Size = New System.Drawing.Size(240, 66)
        Me.dgvValuationSummary.TabIndex = 22
        '
        'DivisionIDDataGridViewTextBoxColumn1
        '
        Me.DivisionIDDataGridViewTextBoxColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.Name = "DivisionIDDataGridViewTextBoxColumn1"
        Me.DivisionIDDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'ItemIDDataGridViewTextBoxColumn
        '
        Me.ItemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID"
        Me.ItemIDDataGridViewTextBoxColumn.HeaderText = "ItemID"
        Me.ItemIDDataGridViewTextBoxColumn.Name = "ItemIDDataGridViewTextBoxColumn"
        Me.ItemIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ShortDescriptionDataGridViewTextBoxColumn
        '
        Me.ShortDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionDataGridViewTextBoxColumn.HeaderText = "ShortDescription"
        Me.ShortDescriptionDataGridViewTextBoxColumn.Name = "ShortDescriptionDataGridViewTextBoxColumn"
        Me.ShortDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LongDescriptionDataGridViewTextBoxColumn
        '
        Me.LongDescriptionDataGridViewTextBoxColumn.DataPropertyName = "LongDescription"
        Me.LongDescriptionDataGridViewTextBoxColumn.HeaderText = "LongDescription"
        Me.LongDescriptionDataGridViewTextBoxColumn.Name = "LongDescriptionDataGridViewTextBoxColumn"
        Me.LongDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SumQuantityAddDataGridViewTextBoxColumn
        '
        Me.SumQuantityAddDataGridViewTextBoxColumn.DataPropertyName = "SumQuantityAdd"
        Me.SumQuantityAddDataGridViewTextBoxColumn.HeaderText = "SumQuantityAdd"
        Me.SumQuantityAddDataGridViewTextBoxColumn.Name = "SumQuantityAddDataGridViewTextBoxColumn"
        Me.SumQuantityAddDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SumQuantitySubtractDataGridViewTextBoxColumn
        '
        Me.SumQuantitySubtractDataGridViewTextBoxColumn.DataPropertyName = "SumQuantitySubtract"
        Me.SumQuantitySubtractDataGridViewTextBoxColumn.HeaderText = "SumQuantitySubtract"
        Me.SumQuantitySubtractDataGridViewTextBoxColumn.Name = "SumQuantitySubtractDataGridViewTextBoxColumn"
        Me.SumQuantitySubtractDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NetQuantityDataGridViewTextBoxColumn
        '
        Me.NetQuantityDataGridViewTextBoxColumn.DataPropertyName = "NetQuantity"
        Me.NetQuantityDataGridViewTextBoxColumn.HeaderText = "NetQuantity"
        Me.NetQuantityDataGridViewTextBoxColumn.Name = "NetQuantityDataGridViewTextBoxColumn"
        Me.NetQuantityDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SumCostAddDataGridViewTextBoxColumn
        '
        Me.SumCostAddDataGridViewTextBoxColumn.DataPropertyName = "SumCostAdd"
        Me.SumCostAddDataGridViewTextBoxColumn.HeaderText = "SumCostAdd"
        Me.SumCostAddDataGridViewTextBoxColumn.Name = "SumCostAddDataGridViewTextBoxColumn"
        Me.SumCostAddDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SumCostSubtractDataGridViewTextBoxColumn
        '
        Me.SumCostSubtractDataGridViewTextBoxColumn.DataPropertyName = "SumCostSubtract"
        Me.SumCostSubtractDataGridViewTextBoxColumn.HeaderText = "SumCostSubtract"
        Me.SumCostSubtractDataGridViewTextBoxColumn.Name = "SumCostSubtractDataGridViewTextBoxColumn"
        Me.SumCostSubtractDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NetCostDataGridViewTextBoxColumn
        '
        Me.NetCostDataGridViewTextBoxColumn.DataPropertyName = "NetCost"
        Me.NetCostDataGridViewTextBoxColumn.HeaderText = "NetCost"
        Me.NetCostDataGridViewTextBoxColumn.Name = "NetCostDataGridViewTextBoxColumn"
        Me.NetCostDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AverageCostDataGridViewTextBoxColumn
        '
        Me.AverageCostDataGridViewTextBoxColumn.DataPropertyName = "AverageCost"
        Me.AverageCostDataGridViewTextBoxColumn.HeaderText = "AverageCost"
        Me.AverageCostDataGridViewTextBoxColumn.Name = "AverageCostDataGridViewTextBoxColumn"
        Me.AverageCostDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLInventoryAccountDataGridViewTextBoxColumn
        '
        Me.GLInventoryAccountDataGridViewTextBoxColumn.DataPropertyName = "GLInventoryAccount"
        Me.GLInventoryAccountDataGridViewTextBoxColumn.HeaderText = "GLInventoryAccount"
        Me.GLInventoryAccountDataGridViewTextBoxColumn.Name = "GLInventoryAccountDataGridViewTextBoxColumn"
        Me.GLInventoryAccountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ADDGLAccountDataGridViewTextBoxColumn
        '
        Me.ADDGLAccountDataGridViewTextBoxColumn.DataPropertyName = "ADDGLAccount"
        Me.ADDGLAccountDataGridViewTextBoxColumn.HeaderText = "ADDGLAccount"
        Me.ADDGLAccountDataGridViewTextBoxColumn.Name = "ADDGLAccountDataGridViewTextBoxColumn"
        Me.ADDGLAccountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SUBTRACTGLAccountDataGridViewTextBoxColumn
        '
        Me.SUBTRACTGLAccountDataGridViewTextBoxColumn.DataPropertyName = "SUBTRACTGLAccount"
        Me.SUBTRACTGLAccountDataGridViewTextBoxColumn.HeaderText = "SUBTRACTGLAccount"
        Me.SUBTRACTGLAccountDataGridViewTextBoxColumn.Name = "SUBTRACTGLAccountDataGridViewTextBoxColumn"
        Me.SUBTRACTGLAccountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'InventoryValuationSummaryBindingSource
        '
        Me.InventoryValuationSummaryBindingSource.DataMember = "InventoryValuationSummary"
        Me.InventoryValuationSummaryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InventoryValuationSummaryTableAdapter
        '
        Me.InventoryValuationSummaryTableAdapter.ClearBeforeFill = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.cmdPrintInvoiceLinesReport)
        Me.GroupBox8.Location = New System.Drawing.Point(399, 625)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(299, 86)
        Me.GroupBox8.TabIndex = 23
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "View Un-posted Invoice Lines"
        '
        'cmdPrintInvoiceLinesReport
        '
        Me.cmdPrintInvoiceLinesReport.Location = New System.Drawing.Point(215, 31)
        Me.cmdPrintInvoiceLinesReport.Name = "cmdPrintInvoiceLinesReport"
        Me.cmdPrintInvoiceLinesReport.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintInvoiceLinesReport.TabIndex = 18
        Me.cmdPrintInvoiceLinesReport.Text = "Print"
        Me.cmdPrintInvoiceLinesReport.UseVisualStyleBackColor = True
        '
        'ofdBlueprints
        '
        Me.ofdBlueprints.FileName = "OpenFileDialog1"
        '
        'cmdTestOpenFile
        '
        Me.cmdTestOpenFile.Location = New System.Drawing.Point(895, 69)
        Me.cmdTestOpenFile.Name = "cmdTestOpenFile"
        Me.cmdTestOpenFile.Size = New System.Drawing.Size(71, 40)
        Me.cmdTestOpenFile.TabIndex = 24
        Me.cmdTestOpenFile.Text = "Print"
        Me.cmdTestOpenFile.UseVisualStyleBackColor = True
        '
        'dgvGLTransactions
        '
        Me.dgvGLTransactions.AllowUserToAddRows = False
        Me.dgvGLTransactions.AllowUserToDeleteRows = False
        Me.dgvGLTransactions.AutoGenerateColumns = False
        Me.dgvGLTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLAccountNumberColumn, Me.GLTransactionKeyColumn, Me.GLTransactionDescriptionColumn, Me.GLTransactionDateColumn, Me.GLDebitAmountColumn, Me.GLCreditAmountColumn, Me.GLTransactionCommentColumn, Me.GLDivisionIDColumn, Me.GLJournalIDColumn, Me.GLBatchNumberColumn, Me.GLReferenceNumberColumn, Me.GLReferenceLineColumn, Me.GLTransactionStatusColumn, Me.GLAccountShortDescriptionColumn, Me.GLAccountCashFlowCodeColumn})
        Me.dgvGLTransactions.DataSource = Me.GLTransactionMasterListQueryBindingSource
        Me.dgvGLTransactions.Location = New System.Drawing.Point(87, 625)
        Me.dgvGLTransactions.Name = "dgvGLTransactions"
        Me.dgvGLTransactions.Size = New System.Drawing.Size(234, 60)
        Me.dgvGLTransactions.TabIndex = 25
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
        'GLDebitAmountColumn
        '
        Me.GLDebitAmountColumn.DataPropertyName = "GLTransactionDebitAmount"
        Me.GLDebitAmountColumn.HeaderText = "GLTransactionDebitAmount"
        Me.GLDebitAmountColumn.Name = "GLDebitAmountColumn"
        '
        'GLCreditAmountColumn
        '
        Me.GLCreditAmountColumn.DataPropertyName = "GLTransactionCreditAmount"
        Me.GLCreditAmountColumn.HeaderText = "GLTransactionCreditAmount"
        Me.GLCreditAmountColumn.Name = "GLCreditAmountColumn"
        '
        'GLTransactionCommentColumn
        '
        Me.GLTransactionCommentColumn.DataPropertyName = "GLTransactionComment"
        Me.GLTransactionCommentColumn.HeaderText = "GLTransactionComment"
        Me.GLTransactionCommentColumn.Name = "GLTransactionCommentColumn"
        '
        'GLDivisionIDColumn
        '
        Me.GLDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.GLDivisionIDColumn.HeaderText = "DivisionID"
        Me.GLDivisionIDColumn.Name = "GLDivisionIDColumn"
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
        'dgvGLValuation
        '
        Me.dgvGLValuation.AllowUserToAddRows = False
        Me.dgvGLValuation.AllowUserToDeleteRows = False
        Me.dgvGLValuation.AutoGenerateColumns = False
        Me.dgvGLValuation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGLValuation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GLAccountNumberDataGridViewTextBoxColumn1, Me.GLAccountShortDescriptionDataGridViewTextBoxColumn1, Me.GLAccountDescriptionDataGridViewTextBoxColumn, Me.BeginningBalanceDataGridViewTextBoxColumn, Me.DebitsDataGridViewTextBoxColumn, Me.CreditsDataGridViewTextBoxColumn, Me.EndingBalanceDataGridViewTextBoxColumn})
        Me.dgvGLValuation.DataSource = Me.GLTransactionValuationFinalBindingSource
        Me.dgvGLValuation.Location = New System.Drawing.Point(87, 625)
        Me.dgvGLValuation.Name = "dgvGLValuation"
        Me.dgvGLValuation.Size = New System.Drawing.Size(234, 53)
        Me.dgvGLValuation.TabIndex = 26
        '
        'GLAccountNumberDataGridViewTextBoxColumn1
        '
        Me.GLAccountNumberDataGridViewTextBoxColumn1.DataPropertyName = "GLAccountNumber"
        Me.GLAccountNumberDataGridViewTextBoxColumn1.HeaderText = "GLAccountNumber"
        Me.GLAccountNumberDataGridViewTextBoxColumn1.Name = "GLAccountNumberDataGridViewTextBoxColumn1"
        '
        'GLAccountShortDescriptionDataGridViewTextBoxColumn1
        '
        Me.GLAccountShortDescriptionDataGridViewTextBoxColumn1.DataPropertyName = "GLAccountShortDescription"
        Me.GLAccountShortDescriptionDataGridViewTextBoxColumn1.HeaderText = "GLAccountShortDescription"
        Me.GLAccountShortDescriptionDataGridViewTextBoxColumn1.Name = "GLAccountShortDescriptionDataGridViewTextBoxColumn1"
        '
        'GLAccountDescriptionDataGridViewTextBoxColumn
        '
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.DataPropertyName = "GLAccountDescription"
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.HeaderText = "GLAccountDescription"
        Me.GLAccountDescriptionDataGridViewTextBoxColumn.Name = "GLAccountDescriptionDataGridViewTextBoxColumn"
        '
        'BeginningBalanceDataGridViewTextBoxColumn
        '
        Me.BeginningBalanceDataGridViewTextBoxColumn.DataPropertyName = "BeginningBalance"
        Me.BeginningBalanceDataGridViewTextBoxColumn.HeaderText = "BeginningBalance"
        Me.BeginningBalanceDataGridViewTextBoxColumn.Name = "BeginningBalanceDataGridViewTextBoxColumn"
        Me.BeginningBalanceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DebitsDataGridViewTextBoxColumn
        '
        Me.DebitsDataGridViewTextBoxColumn.DataPropertyName = "Debits"
        Me.DebitsDataGridViewTextBoxColumn.HeaderText = "Debits"
        Me.DebitsDataGridViewTextBoxColumn.Name = "DebitsDataGridViewTextBoxColumn"
        Me.DebitsDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CreditsDataGridViewTextBoxColumn
        '
        Me.CreditsDataGridViewTextBoxColumn.DataPropertyName = "Credits"
        Me.CreditsDataGridViewTextBoxColumn.HeaderText = "Credits"
        Me.CreditsDataGridViewTextBoxColumn.Name = "CreditsDataGridViewTextBoxColumn"
        Me.CreditsDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EndingBalanceDataGridViewTextBoxColumn
        '
        Me.EndingBalanceDataGridViewTextBoxColumn.DataPropertyName = "EndingBalance"
        Me.EndingBalanceDataGridViewTextBoxColumn.HeaderText = "EndingBalance"
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
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.CRMonthViewer)
        Me.GroupBox9.Controls.Add(Me.Label8)
        Me.GroupBox9.Controls.Add(Me.cboYear)
        Me.GroupBox9.Controls.Add(Me.lblMonth)
        Me.GroupBox9.Controls.Add(Me.cboMonth)
        Me.GroupBox9.Controls.Add(Me.rdoSalesByTerritory)
        Me.GroupBox9.Controls.Add(Me.rdoSalesByState)
        Me.GroupBox9.Controls.Add(Me.rdoSalesByItemClass)
        Me.GroupBox9.Controls.Add(Me.rdoConsignmentSales)
        Me.GroupBox9.Controls.Add(Me.rdoDailySales)
        Me.GroupBox9.Controls.Add(Me.cmdReprintMonthReports)
        Me.GroupBox9.Location = New System.Drawing.Point(399, 237)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(299, 304)
        Me.GroupBox9.TabIndex = 27
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Reprint Month End Sales Reports"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 23)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Year"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboYear
        '
        Me.cboYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Items.AddRange(New Object() {"2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020"})
        Me.cboYear.Location = New System.Drawing.Point(78, 60)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(174, 21)
        Me.cboYear.TabIndex = 29
        '
        'lblMonth
        '
        Me.lblMonth.Location = New System.Drawing.Point(17, 32)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(55, 23)
        Me.lblMonth.TabIndex = 28
        Me.lblMonth.Text = "Month"
        Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMonth
        '
        Me.cboMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(78, 33)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(174, 21)
        Me.cboMonth.TabIndex = 27
        '
        'rdoSalesByTerritory
        '
        Me.rdoSalesByTerritory.AutoSize = True
        Me.rdoSalesByTerritory.Location = New System.Drawing.Point(20, 242)
        Me.rdoSalesByTerritory.Name = "rdoSalesByTerritory"
        Me.rdoSalesByTerritory.Size = New System.Drawing.Size(107, 17)
        Me.rdoSalesByTerritory.TabIndex = 26
        Me.rdoSalesByTerritory.Text = "Sales By Territory"
        Me.rdoSalesByTerritory.UseVisualStyleBackColor = True
        '
        'rdoSalesByState
        '
        Me.rdoSalesByState.AutoSize = True
        Me.rdoSalesByState.Location = New System.Drawing.Point(20, 210)
        Me.rdoSalesByState.Name = "rdoSalesByState"
        Me.rdoSalesByState.Size = New System.Drawing.Size(94, 17)
        Me.rdoSalesByState.TabIndex = 25
        Me.rdoSalesByState.Text = "Sales By State"
        Me.rdoSalesByState.UseVisualStyleBackColor = True
        '
        'rdoSalesByItemClass
        '
        Me.rdoSalesByItemClass.AutoSize = True
        Me.rdoSalesByItemClass.Checked = True
        Me.rdoSalesByItemClass.Location = New System.Drawing.Point(20, 114)
        Me.rdoSalesByItemClass.Name = "rdoSalesByItemClass"
        Me.rdoSalesByItemClass.Size = New System.Drawing.Size(117, 17)
        Me.rdoSalesByItemClass.TabIndex = 24
        Me.rdoSalesByItemClass.TabStop = True
        Me.rdoSalesByItemClass.Text = "Sales By Item Class"
        Me.rdoSalesByItemClass.UseVisualStyleBackColor = True
        '
        'rdoConsignmentSales
        '
        Me.rdoConsignmentSales.AutoSize = True
        Me.rdoConsignmentSales.Location = New System.Drawing.Point(20, 178)
        Me.rdoConsignmentSales.Name = "rdoConsignmentSales"
        Me.rdoConsignmentSales.Size = New System.Drawing.Size(115, 17)
        Me.rdoConsignmentSales.TabIndex = 23
        Me.rdoConsignmentSales.Text = "Consignment Sales"
        Me.rdoConsignmentSales.UseVisualStyleBackColor = True
        '
        'rdoDailySales
        '
        Me.rdoDailySales.AutoSize = True
        Me.rdoDailySales.Location = New System.Drawing.Point(20, 146)
        Me.rdoDailySales.Name = "rdoDailySales"
        Me.rdoDailySales.Size = New System.Drawing.Size(112, 17)
        Me.rdoDailySales.TabIndex = 22
        Me.rdoDailySales.Text = "Daily Sales Report"
        Me.rdoDailySales.UseVisualStyleBackColor = True
        '
        'cmdReprintMonthReports
        '
        Me.cmdReprintMonthReports.Location = New System.Drawing.Point(215, 251)
        Me.cmdReprintMonthReports.Name = "cmdReprintMonthReports"
        Me.cmdReprintMonthReports.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprintMonthReports.TabIndex = 21
        Me.cmdReprintMonthReports.Text = "Print"
        Me.cmdReprintMonthReports.UseVisualStyleBackColor = True
        '
        'CRMonthViewer
        '
        Me.CRMonthViewer.ActiveViewIndex = 0
        Me.CRMonthViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRMonthViewer.Location = New System.Drawing.Point(164, 96)
        Me.CRMonthViewer.Name = "CRMonthViewer"
        Me.CRMonthViewer.ReportSource = Me.CRXCustMTD_YTDInvoicesbyTerritoryMonth1
        Me.CRMonthViewer.Size = New System.Drawing.Size(122, 131)
        Me.CRMonthViewer.TabIndex = 31
        Me.CRMonthViewer.Visible = False
        '
        'FinancialReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 723)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.cmdTestOpenFile)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvInventoryTransactions)
        Me.Controls.Add(Me.dgvValuationSummary)
        Me.Controls.Add(Me.dgvGLValuation)
        Me.Controls.Add(Me.dgvGLTransactions)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FinancialReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Financial Reports"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.dgvInventoryTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvValuationSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryValuationSummaryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.dgvGLTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLTransactionMasterListQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGLValuation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLTransactionValuationFinalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdIncomeStatement As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpIncomeSelectDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdPrintBalanceSheet As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpBalanceSheetSelectDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoTwoYear As System.Windows.Forms.RadioButton
    Friend WithEvents rdoStandard As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdInventoryValuation As System.Windows.Forms.Button
    Friend WithEvents dtpInventorySelectDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAgedPayables As System.Windows.Forms.Button
    Friend WithEvents cmdAgedReceivables As System.Windows.Forms.Button
    Friend WithEvents dgvInventoryTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryTransactionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryTransactionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryTransactionTableTableAdapter
    Friend WithEvents dgvValuationSummary As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryValuationSummaryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryValuationSummaryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryValuationSummaryTableAdapter
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SumQuantityAddDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SumQuantitySubtractDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NetQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SumCostAddDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SumCostSubtractDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NetCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AverageCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLInventoryAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDGLAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUBTRACTGLAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityDataColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionMathColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPrintInvoiceLinesReport As System.Windows.Forms.Button
    Friend WithEvents ofdBlueprints As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdTestOpenFile As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintTrialBalance As System.Windows.Forms.Button
    Friend WithEvents dtpTrialBalanceSelectDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkNonZero As System.Windows.Forms.CheckBox
    Friend WithEvents dgvGLTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents GLTransactionMasterListQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLTransactionMasterListQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionMasterListQueryTableAdapter
    Friend WithEvents dgvGLValuation As System.Windows.Forms.DataGridView
    Friend WithEvents GLTransactionValuationFinalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLTransactionValuationFinalTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLTransactionValuationFinalTableAdapter
    Friend WithEvents GLAccountNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountShortDescriptionDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeginningBalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndingBalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLJournalIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLReferenceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLTransactionStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountCashFlowCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoDailySales As System.Windows.Forms.RadioButton
    Friend WithEvents cmdReprintMonthReports As System.Windows.Forms.Button
    Friend WithEvents rdoSalesByItemClass As System.Windows.Forms.RadioButton
    Friend WithEvents rdoConsignmentSales As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSalesByTerritory As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSalesByState As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents CRMonthViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXConsignmentBillingMonth1 As MOS09Program.CRXConsignmentBillingMonth
    Friend WithEvents CRXInvoiceDailyTotalsMonth1 As MOS09Program.CRXInvoiceDailyTotalsMonth
    Friend WithEvents CRXCustMTD_YTDInvoicesbyTerritoryMonth1 As MOS09Program.CRXCustMTD_YTDInvoicesbyTerritoryMonth
    Friend WithEvents CRXSalesByItemClass_TWDMonth1 As MOS09Program.CRXSalesByItemClass_TWDMonth
    Friend WithEvents CRXCustMTD_YTDInvoicesbyStateMonth1 As MOS09Program.CRXCustMTD_YTDInvoicesbyStateMonth
End Class
