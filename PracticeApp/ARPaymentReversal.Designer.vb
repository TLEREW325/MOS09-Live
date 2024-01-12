<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ARPaymentReversal
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpcCancel = New System.Windows.Forms.GroupBox
        Me.dtpPostDate = New System.Windows.Forms.DateTimePicker
        Me.cmdReverse = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdViewByCustomer = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label11 = New System.Windows.Forms.Label
        Me.dgvARPaymentLog = New System.Windows.Forms.DataGridView
        Me.PaymentIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARPaymentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARPaymentLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ARPaymentLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARPaymentLogTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.cboPaymentID = New System.Windows.Forms.ComboBox
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvPaymentLines = New System.Windows.Forms.DataGridView
        Me.LinePaymentIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineARInvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LinePaymentAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LinePaymentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARPaymentLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ARPaymentLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARPaymentLinesTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpcCancel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvARPaymentLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARPaymentLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPaymentLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARPaymentLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.FileToolStripMenuItem.Text = "File "
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 83
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 82
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpcCancel
        '
        Me.gpcCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpcCancel.Controls.Add(Me.dtpPostDate)
        Me.gpcCancel.Controls.Add(Me.cmdReverse)
        Me.gpcCancel.Controls.Add(Me.Label2)
        Me.gpcCancel.Controls.Add(Me.Label9)
        Me.gpcCancel.Location = New System.Drawing.Point(329, 691)
        Me.gpcCancel.Name = "gpcCancel"
        Me.gpcCancel.Size = New System.Drawing.Size(322, 120)
        Me.gpcCancel.TabIndex = 87
        Me.gpcCancel.TabStop = False
        Me.gpcCancel.Text = " Reverse Payment"
        '
        'dtpPostDate
        '
        Me.dtpPostDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPostDate.Location = New System.Drawing.Point(86, 76)
        Me.dtpPostDate.Name = "dtpPostDate"
        Me.dtpPostDate.Size = New System.Drawing.Size(126, 20)
        Me.dtpPostDate.TabIndex = 80
        '
        'cmdReverse
        '
        Me.cmdReverse.ForeColor = System.Drawing.Color.Blue
        Me.cmdReverse.Location = New System.Drawing.Point(234, 68)
        Me.cmdReverse.Name = "cmdReverse"
        Me.cmdReverse.Size = New System.Drawing.Size(71, 40)
        Me.cmdReverse.TabIndex = 79
        Me.cmdReverse.Text = "Reverse Payment"
        Me.cmdReverse.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 40)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Reverse Payment re-opens the invoices to be processed. Select Payment ID in grid " & _
            "or drop down box."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 20)
        Me.Label9.TabIndex = 87
        Me.Label9.Text = "Post Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdViewByCustomer)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cboCustomerName)
        Me.GroupBox1.Controls.Add(Me.cboCustomerID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 190)
        Me.GroupBox1.TabIndex = 88
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "AR Cash Receipts -- View By Customer"
        '
        'cmdViewByCustomer
        '
        Me.cmdViewByCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmdViewByCustomer.Location = New System.Drawing.Point(119, 147)
        Me.cmdViewByCustomer.Name = "cmdViewByCustomer"
        Me.cmdViewByCustomer.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByCustomer.TabIndex = 91
        Me.cmdViewByCustomer.Text = "View"
        Me.cmdViewByCustomer.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.ForeColor = System.Drawing.Color.Black
        Me.cmdClear.Location = New System.Drawing.Point(196, 147)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 80
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(17, 105)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(250, 21)
        Me.cboCustomerName.TabIndex = 20
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(78, 70)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(189, 21)
        Me.cboCustomerID.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 20)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Customer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(78, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(189, 21)
        Me.cboDivisionID.TabIndex = 16
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(14, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 20)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Division ID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvARPaymentLog
        '
        Me.dgvARPaymentLog.AllowUserToAddRows = False
        Me.dgvARPaymentLog.AllowUserToDeleteRows = False
        Me.dgvARPaymentLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvARPaymentLog.AutoGenerateColumns = False
        Me.dgvARPaymentLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvARPaymentLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvARPaymentLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvARPaymentLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PaymentIDColumn, Me.ARPaymentNumberColumn, Me.CustomerIDColumn, Me.PaymentAmountColumn, Me.PaymentDateColumn, Me.ARBatchNumberColumn, Me.PaymentTypeColumn, Me.PaymentStatusColumn, Me.DivisionIDColumn})
        Me.dgvARPaymentLog.DataSource = Me.ARPaymentLogBindingSource
        Me.dgvARPaymentLog.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvARPaymentLog.Location = New System.Drawing.Point(329, 41)
        Me.dgvARPaymentLog.Name = "dgvARPaymentLog"
        Me.dgvARPaymentLog.ReadOnly = True
        Me.dgvARPaymentLog.Size = New System.Drawing.Size(701, 644)
        Me.dgvARPaymentLog.TabIndex = 89
        '
        'PaymentIDColumn
        '
        Me.PaymentIDColumn.DataPropertyName = "PaymentID"
        Me.PaymentIDColumn.HeaderText = "Payment ID"
        Me.PaymentIDColumn.Name = "PaymentIDColumn"
        Me.PaymentIDColumn.ReadOnly = True
        '
        'ARPaymentNumberColumn
        '
        Me.ARPaymentNumberColumn.DataPropertyName = "ARPaymentNumber"
        Me.ARPaymentNumberColumn.HeaderText = "Cust. Pay. #"
        Me.ARPaymentNumberColumn.Name = "ARPaymentNumberColumn"
        Me.ARPaymentNumberColumn.ReadOnly = True
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'PaymentAmountColumn
        '
        Me.PaymentAmountColumn.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.PaymentAmountColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.PaymentAmountColumn.HeaderText = "Payment Amount"
        Me.PaymentAmountColumn.Name = "PaymentAmountColumn"
        Me.PaymentAmountColumn.ReadOnly = True
        '
        'PaymentDateColumn
        '
        Me.PaymentDateColumn.DataPropertyName = "PaymentDate"
        Me.PaymentDateColumn.HeaderText = "Payment Date"
        Me.PaymentDateColumn.Name = "PaymentDateColumn"
        Me.PaymentDateColumn.ReadOnly = True
        '
        'ARBatchNumberColumn
        '
        Me.ARBatchNumberColumn.DataPropertyName = "ARBatchNumber"
        Me.ARBatchNumberColumn.HeaderText = "Batch #"
        Me.ARBatchNumberColumn.Name = "ARBatchNumberColumn"
        Me.ARBatchNumberColumn.ReadOnly = True
        '
        'PaymentTypeColumn
        '
        Me.PaymentTypeColumn.DataPropertyName = "PaymentType"
        Me.PaymentTypeColumn.HeaderText = "Payment Type"
        Me.PaymentTypeColumn.Name = "PaymentTypeColumn"
        Me.PaymentTypeColumn.ReadOnly = True
        '
        'PaymentStatusColumn
        '
        Me.PaymentStatusColumn.DataPropertyName = "PaymentStatus"
        Me.PaymentStatusColumn.HeaderText = "PaymentStatus"
        Me.PaymentStatusColumn.Name = "PaymentStatusColumn"
        Me.PaymentStatusColumn.ReadOnly = True
        Me.PaymentStatusColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
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
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'cboPaymentID
        '
        Me.cboPaymentID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentID.DataSource = Me.ARPaymentLogBindingSource
        Me.cboPaymentID.DisplayMember = "PaymentID"
        Me.cboPaymentID.FormattingEnabled = True
        Me.cboPaymentID.Location = New System.Drawing.Point(98, 33)
        Me.cboPaymentID.Name = "cboPaymentID"
        Me.cboPaymentID.Size = New System.Drawing.Size(170, 21)
        Me.cboPaymentID.TabIndex = 90
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cboPaymentID)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 250)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 109)
        Me.GroupBox2.TabIndex = 91
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "View Payment Lines For Payment ID"
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(15, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(253, 49)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Select Payment ID from drop down box to view invoices."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 20)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Payment ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvPaymentLines
        '
        Me.dgvPaymentLines.AllowUserToAddRows = False
        Me.dgvPaymentLines.AllowUserToDeleteRows = False
        Me.dgvPaymentLines.AutoGenerateColumns = False
        Me.dgvPaymentLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPaymentLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPaymentLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPaymentLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LinePaymentIDColumn, Me.LineNumberColumn, Me.LineARInvoiceNumberColumn, Me.LinePaymentAmountColumn, Me.LinePaymentDateColumn, Me.DivisionIDColumn2})
        Me.dgvPaymentLines.DataSource = Me.ARPaymentLinesBindingSource
        Me.dgvPaymentLines.Enabled = False
        Me.dgvPaymentLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvPaymentLines.Location = New System.Drawing.Point(28, 377)
        Me.dgvPaymentLines.Name = "dgvPaymentLines"
        Me.dgvPaymentLines.Size = New System.Drawing.Size(279, 434)
        Me.dgvPaymentLines.TabIndex = 92
        '
        'LinePaymentIDColumn
        '
        Me.LinePaymentIDColumn.DataPropertyName = "PaymentID"
        Me.LinePaymentIDColumn.HeaderText = "PaymentID"
        Me.LinePaymentIDColumn.Name = "LinePaymentIDColumn"
        Me.LinePaymentIDColumn.Visible = False
        '
        'LineNumberColumn
        '
        Me.LineNumberColumn.DataPropertyName = "LineNumber"
        Me.LineNumberColumn.HeaderText = "LineNumber"
        Me.LineNumberColumn.Name = "LineNumberColumn"
        Me.LineNumberColumn.Visible = False
        '
        'LineARInvoiceNumberColumn
        '
        Me.LineARInvoiceNumberColumn.DataPropertyName = "ARInvoiceNumber"
        Me.LineARInvoiceNumberColumn.HeaderText = "Invoice #"
        Me.LineARInvoiceNumberColumn.Name = "LineARInvoiceNumberColumn"
        '
        'LinePaymentAmountColumn
        '
        Me.LinePaymentAmountColumn.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.LinePaymentAmountColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.LinePaymentAmountColumn.HeaderText = "Payment Amount"
        Me.LinePaymentAmountColumn.Name = "LinePaymentAmountColumn"
        '
        'LinePaymentDateColumn
        '
        Me.LinePaymentDateColumn.DataPropertyName = "PaymentDate"
        Me.LinePaymentDateColumn.HeaderText = "Payment Date"
        Me.LinePaymentDateColumn.Name = "LinePaymentDateColumn"
        Me.LinePaymentDateColumn.Visible = False
        '
        'DivisionIDColumn2
        '
        Me.DivisionIDColumn2.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn2.HeaderText = "Division"
        Me.DivisionIDColumn2.Name = "DivisionIDColumn2"
        '
        'ARPaymentLinesBindingSource
        '
        Me.ARPaymentLinesBindingSource.DataMember = "ARPaymentLines"
        Me.ARPaymentLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ARPaymentLinesTableAdapter
        '
        Me.ARPaymentLinesTableAdapter.ClearBeforeFill = True
        '
        'ARPaymentReversal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvPaymentLines)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvARPaymentLog)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpcCancel)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ARPaymentReversal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AR Payment Reversal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpcCancel.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvARPaymentLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARPaymentLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvPaymentLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARPaymentLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents gpcCancel As System.Windows.Forms.GroupBox
    Friend WithEvents dtpPostDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdReverse As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgvARPaymentLog As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ARPaymentLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARPaymentLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARPaymentLogTableAdapter
    Friend WithEvents PaymentIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARPaymentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboPaymentID As System.Windows.Forms.ComboBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cmdViewByCustomer As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvPaymentLines As System.Windows.Forms.DataGridView
    Friend WithEvents ARPaymentLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARPaymentLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARPaymentLinesTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinePaymentIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineARInvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinePaymentAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinePaymentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
