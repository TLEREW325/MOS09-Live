<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatabaseMonitoring
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtUnpostedCheckBatches = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtUnpostedARReceipts = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtUnpostedAPVouchers = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtUnpostedVendorReturns = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtUnpostedCustomerReturns = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtShipmentsToBeInvoiced = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtUnpostedInvoiceBatches = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtUnpostedAdjustments = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUnpostedReceivers = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPendingInvoices = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.dgvDivisionData = New System.Windows.Forms.DataGridView
        Me.DivisionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PendingShipmentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PendingInvoicesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnpostedAPVouchersColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnpostedAPChecksColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnpostedInvoicebatchesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnpostedARCashReceiptsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnpostedReceiversColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnpostedAdjustmentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnpostedCustomerReturnsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnpostedvendorReturnsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdViewAll = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDivisionData, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtUnpostedCheckBatches)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtUnpostedARReceipts)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtUnpostedAPVouchers)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtUnpostedVendorReturns)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtUnpostedCustomerReturns)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtShipmentsToBeInvoiced)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtUnpostedInvoiceBatches)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtUnpostedAdjustments)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtUnpostedReceivers)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtPendingInvoices)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(297, 161)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(299, 471)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Monitoring"
        Me.GroupBox1.Visible = False
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(111, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(168, 21)
        Me.cboDivisionID.TabIndex = 3
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
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(161, 23)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Division"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnpostedCheckBatches
        '
        Me.txtUnpostedCheckBatches.BackColor = System.Drawing.Color.White
        Me.txtUnpostedCheckBatches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnpostedCheckBatches.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnpostedCheckBatches.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnpostedCheckBatches.Location = New System.Drawing.Point(178, 430)
        Me.txtUnpostedCheckBatches.Name = "txtUnpostedCheckBatches"
        Me.txtUnpostedCheckBatches.ReadOnly = True
        Me.txtUnpostedCheckBatches.Size = New System.Drawing.Size(101, 20)
        Me.txtUnpostedCheckBatches.TabIndex = 21
        Me.txtUnpostedCheckBatches.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 430)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(161, 23)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Unposted AP Check Batches"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnpostedARReceipts
        '
        Me.txtUnpostedARReceipts.BackColor = System.Drawing.Color.White
        Me.txtUnpostedARReceipts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnpostedARReceipts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnpostedARReceipts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnpostedARReceipts.Location = New System.Drawing.Point(178, 390)
        Me.txtUnpostedARReceipts.Name = "txtUnpostedARReceipts"
        Me.txtUnpostedARReceipts.ReadOnly = True
        Me.txtUnpostedARReceipts.Size = New System.Drawing.Size(101, 20)
        Me.txtUnpostedARReceipts.TabIndex = 19
        Me.txtUnpostedARReceipts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 390)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(161, 23)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Unposted AR Cash Receipts"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnpostedAPVouchers
        '
        Me.txtUnpostedAPVouchers.BackColor = System.Drawing.Color.White
        Me.txtUnpostedAPVouchers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnpostedAPVouchers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnpostedAPVouchers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnpostedAPVouchers.Location = New System.Drawing.Point(178, 350)
        Me.txtUnpostedAPVouchers.Name = "txtUnpostedAPVouchers"
        Me.txtUnpostedAPVouchers.ReadOnly = True
        Me.txtUnpostedAPVouchers.Size = New System.Drawing.Size(101, 20)
        Me.txtUnpostedAPVouchers.TabIndex = 17
        Me.txtUnpostedAPVouchers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 350)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(161, 23)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Unposted AP Vouchers"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnpostedVendorReturns
        '
        Me.txtUnpostedVendorReturns.BackColor = System.Drawing.Color.White
        Me.txtUnpostedVendorReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnpostedVendorReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnpostedVendorReturns.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnpostedVendorReturns.Location = New System.Drawing.Point(178, 310)
        Me.txtUnpostedVendorReturns.Name = "txtUnpostedVendorReturns"
        Me.txtUnpostedVendorReturns.ReadOnly = True
        Me.txtUnpostedVendorReturns.Size = New System.Drawing.Size(101, 20)
        Me.txtUnpostedVendorReturns.TabIndex = 15
        Me.txtUnpostedVendorReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(18, 310)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 23)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Unposted Vendor Returns"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnpostedCustomerReturns
        '
        Me.txtUnpostedCustomerReturns.BackColor = System.Drawing.Color.White
        Me.txtUnpostedCustomerReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnpostedCustomerReturns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnpostedCustomerReturns.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnpostedCustomerReturns.Location = New System.Drawing.Point(178, 270)
        Me.txtUnpostedCustomerReturns.Name = "txtUnpostedCustomerReturns"
        Me.txtUnpostedCustomerReturns.ReadOnly = True
        Me.txtUnpostedCustomerReturns.Size = New System.Drawing.Size(101, 20)
        Me.txtUnpostedCustomerReturns.TabIndex = 13
        Me.txtUnpostedCustomerReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(161, 23)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Unposted Customer Returns"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipmentsToBeInvoiced
        '
        Me.txtShipmentsToBeInvoiced.BackColor = System.Drawing.Color.White
        Me.txtShipmentsToBeInvoiced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentsToBeInvoiced.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipmentsToBeInvoiced.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipmentsToBeInvoiced.Location = New System.Drawing.Point(178, 230)
        Me.txtShipmentsToBeInvoiced.Name = "txtShipmentsToBeInvoiced"
        Me.txtShipmentsToBeInvoiced.ReadOnly = True
        Me.txtShipmentsToBeInvoiced.Size = New System.Drawing.Size(101, 20)
        Me.txtShipmentsToBeInvoiced.TabIndex = 11
        Me.txtShipmentsToBeInvoiced.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Shipments to be Invoiced"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnpostedInvoiceBatches
        '
        Me.txtUnpostedInvoiceBatches.BackColor = System.Drawing.Color.White
        Me.txtUnpostedInvoiceBatches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnpostedInvoiceBatches.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnpostedInvoiceBatches.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnpostedInvoiceBatches.Location = New System.Drawing.Point(178, 190)
        Me.txtUnpostedInvoiceBatches.Name = "txtUnpostedInvoiceBatches"
        Me.txtUnpostedInvoiceBatches.ReadOnly = True
        Me.txtUnpostedInvoiceBatches.Size = New System.Drawing.Size(101, 20)
        Me.txtUnpostedInvoiceBatches.TabIndex = 9
        Me.txtUnpostedInvoiceBatches.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 23)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Unposted Invoice Batches"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnpostedAdjustments
        '
        Me.txtUnpostedAdjustments.BackColor = System.Drawing.Color.White
        Me.txtUnpostedAdjustments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnpostedAdjustments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnpostedAdjustments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnpostedAdjustments.Location = New System.Drawing.Point(178, 150)
        Me.txtUnpostedAdjustments.Name = "txtUnpostedAdjustments"
        Me.txtUnpostedAdjustments.ReadOnly = True
        Me.txtUnpostedAdjustments.Size = New System.Drawing.Size(101, 20)
        Me.txtUnpostedAdjustments.TabIndex = 7
        Me.txtUnpostedAdjustments.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(161, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Unposted Adjustments"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnpostedReceivers
        '
        Me.txtUnpostedReceivers.BackColor = System.Drawing.Color.White
        Me.txtUnpostedReceivers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnpostedReceivers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnpostedReceivers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnpostedReceivers.Location = New System.Drawing.Point(178, 110)
        Me.txtUnpostedReceivers.Name = "txtUnpostedReceivers"
        Me.txtUnpostedReceivers.ReadOnly = True
        Me.txtUnpostedReceivers.Size = New System.Drawing.Size(101, 20)
        Me.txtUnpostedReceivers.TabIndex = 5
        Me.txtUnpostedReceivers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Unposted Receivers"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPendingInvoices
        '
        Me.txtPendingInvoices.BackColor = System.Drawing.Color.White
        Me.txtPendingInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPendingInvoices.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPendingInvoices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPendingInvoices.Location = New System.Drawing.Point(178, 70)
        Me.txtPendingInvoices.Name = "txtPendingInvoices"
        Me.txtPendingInvoices.ReadOnly = True
        Me.txtPendingInvoices.Size = New System.Drawing.Size(101, 20)
        Me.txtPendingInvoices.TabIndex = 3
        Me.txtPendingInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Pending Invoices"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvDivisionData
        '
        Me.dgvDivisionData.AllowUserToAddRows = False
        Me.dgvDivisionData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvDivisionData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDivisionData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDivisionData.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvDivisionData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvDivisionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDivisionData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionColumn, Me.PendingShipmentsColumn, Me.PendingInvoicesColumn, Me.UnpostedAPVouchersColumn, Me.UnpostedAPChecksColumn, Me.UnpostedInvoicebatchesColumn, Me.UnpostedARCashReceiptsColumn, Me.UnpostedReceiversColumn, Me.UnpostedAdjustmentsColumn, Me.UnpostedCustomerReturnsColumn, Me.UnpostedvendorReturnsColumn})
        Me.dgvDivisionData.GridColor = System.Drawing.Color.Teal
        Me.dgvDivisionData.Location = New System.Drawing.Point(12, 105)
        Me.dgvDivisionData.Name = "dgvDivisionData"
        Me.dgvDivisionData.Size = New System.Drawing.Size(1118, 644)
        Me.dgvDivisionData.TabIndex = 3
        '
        'DivisionColumn
        '
        Me.DivisionColumn.HeaderText = "Division"
        Me.DivisionColumn.Name = "DivisionColumn"
        Me.DivisionColumn.Width = 70
        '
        'PendingShipmentsColumn
        '
        Me.PendingShipmentsColumn.HeaderText = "Pending Shipments"
        Me.PendingShipmentsColumn.Name = "PendingShipmentsColumn"
        Me.PendingShipmentsColumn.Width = 90
        '
        'PendingInvoicesColumn
        '
        Me.PendingInvoicesColumn.HeaderText = "Pending Invoices"
        Me.PendingInvoicesColumn.Name = "PendingInvoicesColumn"
        Me.PendingInvoicesColumn.Width = 90
        '
        'UnpostedAPVouchersColumn
        '
        Me.UnpostedAPVouchersColumn.HeaderText = "Unposted Vouchers"
        Me.UnpostedAPVouchersColumn.Name = "UnpostedAPVouchersColumn"
        Me.UnpostedAPVouchersColumn.Width = 90
        '
        'UnpostedAPChecksColumn
        '
        Me.UnpostedAPChecksColumn.HeaderText = "Unposted AP Checks"
        Me.UnpostedAPChecksColumn.Name = "UnpostedAPChecksColumn"
        Me.UnpostedAPChecksColumn.Width = 90
        '
        'UnpostedInvoicebatchesColumn
        '
        Me.UnpostedInvoicebatchesColumn.HeaderText = "Unposted Invoice Batches"
        Me.UnpostedInvoicebatchesColumn.Name = "UnpostedInvoicebatchesColumn"
        '
        'UnpostedARCashReceiptsColumn
        '
        Me.UnpostedARCashReceiptsColumn.HeaderText = "Unposted Cash Receipts"
        Me.UnpostedARCashReceiptsColumn.Name = "UnpostedARCashReceiptsColumn"
        Me.UnpostedARCashReceiptsColumn.Width = 90
        '
        'UnpostedReceiversColumn
        '
        Me.UnpostedReceiversColumn.HeaderText = "Unposted Receivers"
        Me.UnpostedReceiversColumn.Name = "UnpostedReceiversColumn"
        Me.UnpostedReceiversColumn.Width = 90
        '
        'UnpostedAdjustmentsColumn
        '
        Me.UnpostedAdjustmentsColumn.HeaderText = "Unposted Adjustments"
        Me.UnpostedAdjustmentsColumn.Name = "UnpostedAdjustmentsColumn"
        Me.UnpostedAdjustmentsColumn.Width = 90
        '
        'UnpostedCustomerReturnsColumn
        '
        Me.UnpostedCustomerReturnsColumn.HeaderText = "Unposted Customer Returns"
        Me.UnpostedCustomerReturnsColumn.Name = "UnpostedCustomerReturnsColumn"
        Me.UnpostedCustomerReturnsColumn.Width = 90
        '
        'UnpostedvendorReturnsColumn
        '
        Me.UnpostedvendorReturnsColumn.HeaderText = "Unposted Vendor Returns"
        Me.UnpostedvendorReturnsColumn.Name = "UnpostedvendorReturnsColumn"
        Me.UnpostedvendorReturnsColumn.Width = 90
        '
        'cmdViewAll
        '
        Me.cmdViewAll.Location = New System.Drawing.Point(12, 50)
        Me.cmdViewAll.Name = "cmdViewAll"
        Me.cmdViewAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewAll.TabIndex = 4
        Me.cmdViewAll.Text = "View All"
        Me.cmdViewAll.UseVisualStyleBackColor = True
        '
        'DatabaseMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdViewAll)
        Me.Controls.Add(Me.dgvDivisionData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "DatabaseMonitoring"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Database Monitoring"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDivisionData, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtPendingInvoices As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUnpostedCheckBatches As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtUnpostedARReceipts As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtUnpostedAPVouchers As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtUnpostedVendorReturns As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUnpostedCustomerReturns As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtShipmentsToBeInvoiced As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUnpostedInvoiceBatches As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUnpostedAdjustments As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUnpostedReceivers As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dgvDivisionData As System.Windows.Forms.DataGridView
    Friend WithEvents cmdViewAll As System.Windows.Forms.Button
    Friend WithEvents DivisionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PendingShipmentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PendingInvoicesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnpostedAPVouchersColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnpostedAPChecksColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnpostedInvoicebatchesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnpostedARCashReceiptsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnpostedReceiversColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnpostedAdjustmentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnpostedCustomerReturnsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnpostedvendorReturnsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
