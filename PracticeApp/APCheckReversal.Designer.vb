<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APCheckReversal
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
        Me.ReverseCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteCheckPayableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintAPCheckLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboCheckNumber = New System.Windows.Forms.ComboBox
        Me.APCheckLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtBatchNumber = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtVendor = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCheckAmount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCheckDate = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.dgvCheckLines = New System.Windows.Forms.DataGridView
        Me.APCheckNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APVoucherNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APCheckLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.APCheckLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLinesTableAdapter
        Me.Label7 = New System.Windows.Forms.Label
        Me.dgvAPCheckLog = New System.Windows.Forms.DataGridView
        Me.CheckNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APBatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APCheckLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLogTableAdapter
        Me.gpcCancel = New System.Windows.Forms.GroupBox
        Me.dtpPostDate = New System.Windows.Forms.DateTimePicker
        Me.cmdReverse = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtpCancelPostDate = New System.Windows.Forms.DateTimePicker
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.APCheckLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCheckLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APCheckLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAPCheckLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpcCancel.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReverseCheckToolStripMenuItem, Me.DeleteCheckPayableToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ReverseCheckToolStripMenuItem
        '
        Me.ReverseCheckToolStripMenuItem.Name = "ReverseCheckToolStripMenuItem"
        Me.ReverseCheckToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ReverseCheckToolStripMenuItem.Text = "Reverse Check"
        '
        'DeleteCheckPayableToolStripMenuItem
        '
        Me.DeleteCheckPayableToolStripMenuItem.Name = "DeleteCheckPayableToolStripMenuItem"
        Me.DeleteCheckPayableToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.DeleteCheckPayableToolStripMenuItem.Text = "Delete Check and Payable"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintAPCheckLogToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintAPCheckLogToolStripMenuItem
        '
        Me.PrintAPCheckLogToolStripMenuItem.Name = "PrintAPCheckLogToolStripMenuItem"
        Me.PrintAPCheckLogToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.PrintAPCheckLogToolStripMenuItem.Text = "Print AP Check Log"
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
        Me.GroupBox1.Controls.Add(Me.cboCheckNumber)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 150)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Accounts Payable Checks"
        '
        'cboCheckNumber
        '
        Me.cboCheckNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCheckNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCheckNumber.DataSource = Me.APCheckLogBindingSource
        Me.cboCheckNumber.DisplayMember = "CheckNumber"
        Me.cboCheckNumber.FormattingEnabled = True
        Me.cboCheckNumber.Location = New System.Drawing.Point(103, 70)
        Me.cboCheckNumber.Name = "cboCheckNumber"
        Me.cboCheckNumber.Size = New System.Drawing.Size(164, 21)
        Me.cboCheckNumber.TabIndex = 18
        '
        'APCheckLogBindingSource
        '
        Me.APCheckLogBindingSource.DataMember = "APCheckLog"
        Me.APCheckLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 20)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Check Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(103, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(164, 21)
        Me.cboDivisionID.TabIndex = 16
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(18, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(249, 20)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Select Check #  to view Check Details"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 52)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Reverse Check re-opens the payable to be processed. Select Check # in grid or dro" & _
            "p down box."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtBatchNumber)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtVendor)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtCheckAmount)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCheckDate)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 210)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 154)
        Me.GroupBox2.TabIndex = 77
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Check Details"
        '
        'txtBatchNumber
        '
        Me.txtBatchNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchNumber.Location = New System.Drawing.Point(100, 116)
        Me.txtBatchNumber.Name = "txtBatchNumber"
        Me.txtBatchNumber.ReadOnly = True
        Me.txtBatchNumber.Size = New System.Drawing.Size(164, 20)
        Me.txtBatchNumber.TabIndex = 83
        Me.txtBatchNumber.TabStop = False
        Me.txtBatchNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(11, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 20)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Batch Number"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendor
        '
        Me.txtVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendor.Location = New System.Drawing.Point(100, 87)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.ReadOnly = True
        Me.txtVendor.Size = New System.Drawing.Size(164, 20)
        Me.txtVendor.TabIndex = 81
        Me.txtVendor.TabStop = False
        Me.txtVendor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(11, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 20)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Vendor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheckAmount
        '
        Me.txtCheckAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckAmount.Location = New System.Drawing.Point(100, 58)
        Me.txtCheckAmount.Name = "txtCheckAmount"
        Me.txtCheckAmount.ReadOnly = True
        Me.txtCheckAmount.Size = New System.Drawing.Size(164, 20)
        Me.txtCheckAmount.TabIndex = 79
        Me.txtCheckAmount.TabStop = False
        Me.txtCheckAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(11, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 20)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Check Amount"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCheckDate
        '
        Me.txtCheckDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheckDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckDate.Location = New System.Drawing.Point(100, 29)
        Me.txtCheckDate.Name = "txtCheckDate"
        Me.txtCheckDate.ReadOnly = True
        Me.txtCheckDate.Size = New System.Drawing.Size(164, 20)
        Me.txtCheckDate.TabIndex = 77
        Me.txtCheckDate.TabStop = False
        Me.txtCheckDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(11, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 20)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Check Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 81
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 80
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'dgvCheckLines
        '
        Me.dgvCheckLines.AllowUserToAddRows = False
        Me.dgvCheckLines.AllowUserToDeleteRows = False
        Me.dgvCheckLines.AutoGenerateColumns = False
        Me.dgvCheckLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCheckLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheckLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.APCheckNumberColumn, Me.APVoucherNumberColumn, Me.VoucherAmountColumn, Me.VoucherDateColumn})
        Me.dgvCheckLines.DataSource = Me.APCheckLinesBindingSource
        Me.dgvCheckLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvCheckLines.Location = New System.Drawing.Point(29, 407)
        Me.dgvCheckLines.Name = "dgvCheckLines"
        Me.dgvCheckLines.Size = New System.Drawing.Size(281, 404)
        Me.dgvCheckLines.TabIndex = 82
        '
        'APCheckNumberColumn
        '
        Me.APCheckNumberColumn.DataPropertyName = "APCheckNumber"
        Me.APCheckNumberColumn.HeaderText = "APCheckNumber"
        Me.APCheckNumberColumn.Name = "APCheckNumberColumn"
        Me.APCheckNumberColumn.ReadOnly = True
        Me.APCheckNumberColumn.Visible = False
        '
        'APVoucherNumberColumn
        '
        Me.APVoucherNumberColumn.DataPropertyName = "APVoucherNumber"
        Me.APVoucherNumberColumn.HeaderText = "Voucher #"
        Me.APVoucherNumberColumn.Name = "APVoucherNumberColumn"
        Me.APVoucherNumberColumn.ReadOnly = True
        Me.APVoucherNumberColumn.Width = 80
        '
        'VoucherAmountColumn
        '
        Me.VoucherAmountColumn.DataPropertyName = "VoucherAmount"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.VoucherAmountColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.VoucherAmountColumn.HeaderText = "Amount"
        Me.VoucherAmountColumn.Name = "VoucherAmountColumn"
        Me.VoucherAmountColumn.ReadOnly = True
        Me.VoucherAmountColumn.Width = 80
        '
        'VoucherDateColumn
        '
        Me.VoucherDateColumn.DataPropertyName = "VoucherDate"
        Me.VoucherDateColumn.HeaderText = "Date"
        Me.VoucherDateColumn.Name = "VoucherDateColumn"
        Me.VoucherDateColumn.ReadOnly = True
        Me.VoucherDateColumn.Width = 80
        '
        'APCheckLinesBindingSource
        '
        Me.APCheckLinesBindingSource.DataMember = "APCheckLines"
        Me.APCheckLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'APCheckLinesTableAdapter
        '
        Me.APCheckLinesTableAdapter.ClearBeforeFill = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(29, 384)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(281, 20)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Vouchers Paid by Selected Check"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvAPCheckLog
        '
        Me.dgvAPCheckLog.AllowUserToAddRows = False
        Me.dgvAPCheckLog.AllowUserToDeleteRows = False
        Me.dgvAPCheckLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAPCheckLog.AutoGenerateColumns = False
        Me.dgvAPCheckLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAPCheckLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPCheckLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CheckNumberDataGridViewTextBoxColumn, Me.VendorIDColumn, Me.CheckDateDataGridViewTextBoxColumn, Me.CheckAmountDataGridViewTextBoxColumn, Me.CheckStatusDataGridViewTextBoxColumn, Me.APBatchNumberColumn, Me.DivisionIDDataGridViewTextBoxColumn})
        Me.dgvAPCheckLog.DataSource = Me.APCheckLogBindingSource
        Me.dgvAPCheckLog.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvAPCheckLog.Location = New System.Drawing.Point(350, 41)
        Me.dgvAPCheckLog.Name = "dgvAPCheckLog"
        Me.dgvAPCheckLog.Size = New System.Drawing.Size(780, 565)
        Me.dgvAPCheckLog.TabIndex = 85
        '
        'CheckNumberDataGridViewTextBoxColumn
        '
        Me.CheckNumberDataGridViewTextBoxColumn.DataPropertyName = "CheckNumber"
        Me.CheckNumberDataGridViewTextBoxColumn.HeaderText = "Check #"
        Me.CheckNumberDataGridViewTextBoxColumn.Name = "CheckNumberDataGridViewTextBoxColumn"
        Me.CheckNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor ID"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.ReadOnly = True
        Me.VendorIDColumn.Width = 150
        '
        'CheckDateDataGridViewTextBoxColumn
        '
        Me.CheckDateDataGridViewTextBoxColumn.DataPropertyName = "CheckDate"
        Me.CheckDateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.CheckDateDataGridViewTextBoxColumn.Name = "CheckDateDataGridViewTextBoxColumn"
        Me.CheckDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.CheckDateDataGridViewTextBoxColumn.Width = 90
        '
        'CheckAmountDataGridViewTextBoxColumn
        '
        Me.CheckAmountDataGridViewTextBoxColumn.DataPropertyName = "CheckAmount"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.CheckAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.CheckAmountDataGridViewTextBoxColumn.HeaderText = "Amount"
        Me.CheckAmountDataGridViewTextBoxColumn.Name = "CheckAmountDataGridViewTextBoxColumn"
        Me.CheckAmountDataGridViewTextBoxColumn.ReadOnly = True
        Me.CheckAmountDataGridViewTextBoxColumn.Width = 90
        '
        'CheckStatusDataGridViewTextBoxColumn
        '
        Me.CheckStatusDataGridViewTextBoxColumn.DataPropertyName = "CheckStatus"
        Me.CheckStatusDataGridViewTextBoxColumn.HeaderText = "Check Status"
        Me.CheckStatusDataGridViewTextBoxColumn.Name = "CheckStatusDataGridViewTextBoxColumn"
        Me.CheckStatusDataGridViewTextBoxColumn.ReadOnly = True
        '
        'APBatchNumberColumn
        '
        Me.APBatchNumberColumn.DataPropertyName = "APBatchNumber"
        Me.APBatchNumberColumn.HeaderText = "Batch #"
        Me.APBatchNumberColumn.Name = "APBatchNumberColumn"
        Me.APBatchNumberColumn.ReadOnly = True
        Me.APBatchNumberColumn.Width = 90
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'APCheckLogTableAdapter
        '
        Me.APCheckLogTableAdapter.ClearBeforeFill = True
        '
        'gpcCancel
        '
        Me.gpcCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpcCancel.Controls.Add(Me.dtpPostDate)
        Me.gpcCancel.Controls.Add(Me.cmdReverse)
        Me.gpcCancel.Controls.Add(Me.Label2)
        Me.gpcCancel.Controls.Add(Me.Label9)
        Me.gpcCancel.Location = New System.Drawing.Point(350, 630)
        Me.gpcCancel.Name = "gpcCancel"
        Me.gpcCancel.Size = New System.Drawing.Size(322, 135)
        Me.gpcCancel.TabIndex = 86
        Me.gpcCancel.TabStop = False
        Me.gpcCancel.Text = " Reverse Check"
        '
        'dtpPostDate
        '
        Me.dtpPostDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPostDate.Location = New System.Drawing.Point(86, 88)
        Me.dtpPostDate.Name = "dtpPostDate"
        Me.dtpPostDate.Size = New System.Drawing.Size(126, 20)
        Me.dtpPostDate.TabIndex = 80
        '
        'cmdReverse
        '
        Me.cmdReverse.ForeColor = System.Drawing.Color.Blue
        Me.cmdReverse.Location = New System.Drawing.Point(234, 80)
        Me.cmdReverse.Name = "cmdReverse"
        Me.cmdReverse.Size = New System.Drawing.Size(71, 40)
        Me.cmdReverse.TabIndex = 79
        Me.cmdReverse.Text = "Reverse Check"
        Me.cmdReverse.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 20)
        Me.Label9.TabIndex = 87
        Me.Label9.Text = "Post Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.dtpCancelPostDate)
        Me.GroupBox3.Controls.Add(Me.cmdCancel)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(808, 630)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(322, 135)
        Me.GroupBox3.TabIndex = 87
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cancel / Delete Check"
        '
        'dtpCancelPostDate
        '
        Me.dtpCancelPostDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCancelPostDate.Location = New System.Drawing.Point(86, 88)
        Me.dtpCancelPostDate.Name = "dtpCancelPostDate"
        Me.dtpCancelPostDate.Size = New System.Drawing.Size(126, 20)
        Me.dtpCancelPostDate.TabIndex = 80
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Blue
        Me.cmdCancel.Location = New System.Drawing.Point(236, 80)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 40)
        Me.cmdCancel.TabIndex = 79
        Me.cmdCancel.Text = "Cancel Check"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(290, 52)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "Cancel Check cancels the check and the payable. Select Check # in the grid or dro" & _
            "p down box."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(17, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 20)
        Me.Label12.TabIndex = 87
        Me.Label12.Text = "Post Date"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'APCheckReversal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gpcCancel)
        Me.Controls.Add(Me.dgvAPCheckLog)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgvCheckLines)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "APCheckReversal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation AP Checks"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.APCheckLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvCheckLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APCheckLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAPCheckLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpcCancel.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cboCheckNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVendor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCheckAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCheckDate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents dgvCheckLines As System.Windows.Forms.DataGridView
    Friend WithEvents APCheckLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APCheckLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLinesTableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgvAPCheckLog As System.Windows.Forms.DataGridView
    Friend WithEvents APCheckLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APCheckLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APCheckLogTableAdapter
    Friend WithEvents gpcCancel As System.Windows.Forms.GroupBox
    Friend WithEvents cmdReverse As System.Windows.Forms.Button
    Friend WithEvents dtpPostDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpCancelPostDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ReverseCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteCheckPayableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintAPCheckLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents APCheckNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APVoucherNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APBatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
