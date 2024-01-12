<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewConsignmentTotals
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
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblEndingDate = New System.Windows.Forms.Label
        Me.lblBeginningDate = New System.Windows.Forms.Label
        Me.dtpEndingDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvConsignmentTotals = New System.Windows.Forms.DataGridView
        Me.WarehouseIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WarehouseNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalShipmentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalInvoicesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalReturnsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalAdjustmentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BeginDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EndDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConsignmentTempTotalsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ConsignmentTempTotalsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ConsignmentTempTotalsTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtSRLIV = New System.Windows.Forms.TextBox
        Me.txtSeattleIV = New System.Windows.Forms.TextBox
        Me.txtTotalValue = New System.Windows.Forms.TextBox
        Me.txtRentonIV = New System.Windows.Forms.TextBox
        Me.txtPhoenixIV = New System.Windows.Forms.TextBox
        Me.txtLyndhurstIV = New System.Windows.Forms.TextBox
        Me.txtLakeStevensIV = New System.Windows.Forms.TextBox
        Me.txtLewisvilleIV = New System.Windows.Forms.TextBox
        Me.txtHaywardIV = New System.Windows.Forms.TextBox
        Me.txtDowneyIV = New System.Windows.Forms.TextBox
        Me.txtBessemerIV = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvConsignmentTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConsignmentTempTotalsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintReportToolStripMenuItem
        '
        Me.PrintReportToolStripMenuItem.Name = "PrintReportToolStripMenuItem"
        Me.PrintReportToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.PrintReportToolStripMenuItem.Text = "Print Report"
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
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(107, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(175, 21)
        Me.cboDivisionID.TabIndex = 2
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
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEndingDate)
        Me.GroupBox1.Controls.Add(Me.lblBeginningDate)
        Me.GroupBox1.Controls.Add(Me.dtpEndingDate)
        Me.GroupBox1.Controls.Add(Me.dtpBeginDate)
        Me.GroupBox1.Controls.Add(Me.cmdView)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 203)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View Consignment Totals"
        '
        'lblEndingDate
        '
        Me.lblEndingDate.Location = New System.Drawing.Point(12, 121)
        Me.lblEndingDate.Name = "lblEndingDate"
        Me.lblEndingDate.Size = New System.Drawing.Size(91, 20)
        Me.lblEndingDate.TabIndex = 27
        Me.lblEndingDate.Text = "Ending Date"
        Me.lblEndingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBeginningDate
        '
        Me.lblBeginningDate.Location = New System.Drawing.Point(12, 87)
        Me.lblBeginningDate.Name = "lblBeginningDate"
        Me.lblBeginningDate.Size = New System.Drawing.Size(91, 20)
        Me.lblBeginningDate.TabIndex = 26
        Me.lblBeginningDate.Text = "Beginning Date"
        Me.lblBeginningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndingDate.Location = New System.Drawing.Point(106, 119)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpEndingDate.TabIndex = 23
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(106, 85)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpBeginDate.TabIndex = 22
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(133, 152)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 24
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(210, 152)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 25
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 11
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvConsignmentTotals
        '
        Me.dgvConsignmentTotals.AllowUserToAddRows = False
        Me.dgvConsignmentTotals.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvConsignmentTotals.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvConsignmentTotals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConsignmentTotals.AutoGenerateColumns = False
        Me.dgvConsignmentTotals.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvConsignmentTotals.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvConsignmentTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsignmentTotals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WarehouseIDColumn, Me.WarehouseNameColumn, Me.TotalShipmentsColumn, Me.TotalInvoicesColumn, Me.TotalReturnsColumn, Me.TotalAdjustmentsColumn, Me.BeginDateColumn, Me.EndDateColumn})
        Me.dgvConsignmentTotals.DataSource = Me.ConsignmentTempTotalsBindingSource
        Me.dgvConsignmentTotals.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvConsignmentTotals.Location = New System.Drawing.Point(350, 41)
        Me.dgvConsignmentTotals.Name = "dgvConsignmentTotals"
        Me.dgvConsignmentTotals.ReadOnly = True
        Me.dgvConsignmentTotals.Size = New System.Drawing.Size(780, 706)
        Me.dgvConsignmentTotals.TabIndex = 13
        Me.dgvConsignmentTotals.TabStop = False
        '
        'WarehouseIDColumn
        '
        Me.WarehouseIDColumn.DataPropertyName = "WarehouseID"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WarehouseIDColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.WarehouseIDColumn.HeaderText = "Consignment Warehouse"
        Me.WarehouseIDColumn.Name = "WarehouseIDColumn"
        Me.WarehouseIDColumn.ReadOnly = True
        Me.WarehouseIDColumn.Visible = False
        '
        'WarehouseNameColumn
        '
        Me.WarehouseNameColumn.DataPropertyName = "WarehouseName"
        Me.WarehouseNameColumn.HeaderText = "Warehouse"
        Me.WarehouseNameColumn.Name = "WarehouseNameColumn"
        Me.WarehouseNameColumn.ReadOnly = True
        '
        'TotalShipmentsColumn
        '
        Me.TotalShipmentsColumn.DataPropertyName = "TotalShipments"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.TotalShipmentsColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.TotalShipmentsColumn.HeaderText = "Total Shipments (COS)"
        Me.TotalShipmentsColumn.Name = "TotalShipmentsColumn"
        Me.TotalShipmentsColumn.ReadOnly = True
        '
        'TotalInvoicesColumn
        '
        Me.TotalInvoicesColumn.DataPropertyName = "TotalInvoices"
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.TotalInvoicesColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.TotalInvoicesColumn.HeaderText = "Total Invoices"
        Me.TotalInvoicesColumn.Name = "TotalInvoicesColumn"
        Me.TotalInvoicesColumn.ReadOnly = True
        '
        'TotalReturnsColumn
        '
        Me.TotalReturnsColumn.DataPropertyName = "TotalReturns"
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.TotalReturnsColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.TotalReturnsColumn.HeaderText = "Total Returns"
        Me.TotalReturnsColumn.Name = "TotalReturnsColumn"
        Me.TotalReturnsColumn.ReadOnly = True
        '
        'TotalAdjustmentsColumn
        '
        Me.TotalAdjustmentsColumn.DataPropertyName = "TotalAdjustments"
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.TotalAdjustmentsColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.TotalAdjustmentsColumn.HeaderText = "Total Adjustments"
        Me.TotalAdjustmentsColumn.Name = "TotalAdjustmentsColumn"
        Me.TotalAdjustmentsColumn.ReadOnly = True
        '
        'BeginDateColumn
        '
        Me.BeginDateColumn.DataPropertyName = "BeginDate"
        Me.BeginDateColumn.HeaderText = "Begin Date"
        Me.BeginDateColumn.Name = "BeginDateColumn"
        Me.BeginDateColumn.ReadOnly = True
        '
        'EndDateColumn
        '
        Me.EndDateColumn.DataPropertyName = "EndDate"
        Me.EndDateColumn.HeaderText = "End Date"
        Me.EndDateColumn.Name = "EndDateColumn"
        Me.EndDateColumn.ReadOnly = True
        '
        'ConsignmentTempTotalsBindingSource
        '
        Me.ConsignmentTempTotalsBindingSource.DataMember = "ConsignmentTempTotals"
        Me.ConsignmentTempTotalsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ConsignmentTempTotalsTableAdapter
        '
        Me.ConsignmentTempTotalsTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtSRLIV)
        Me.GroupBox2.Controls.Add(Me.txtSeattleIV)
        Me.GroupBox2.Controls.Add(Me.txtTotalValue)
        Me.GroupBox2.Controls.Add(Me.txtRentonIV)
        Me.GroupBox2.Controls.Add(Me.txtPhoenixIV)
        Me.GroupBox2.Controls.Add(Me.txtLyndhurstIV)
        Me.GroupBox2.Controls.Add(Me.txtLakeStevensIV)
        Me.GroupBox2.Controls.Add(Me.txtLewisvilleIV)
        Me.GroupBox2.Controls.Add(Me.txtHaywardIV)
        Me.GroupBox2.Controls.Add(Me.txtDowneyIV)
        Me.GroupBox2.Controls.Add(Me.txtBessemerIV)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 317)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 494)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consignment Inventory Value (End Date)"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 454)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 20)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Total"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSRLIV
        '
        Me.txtSRLIV.BackColor = System.Drawing.Color.White
        Me.txtSRLIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSRLIV.Location = New System.Drawing.Point(122, 391)
        Me.txtSRLIV.Name = "txtSRLIV"
        Me.txtSRLIV.ReadOnly = True
        Me.txtSRLIV.Size = New System.Drawing.Size(159, 20)
        Me.txtSRLIV.TabIndex = 49
        Me.txtSRLIV.TabStop = False
        Me.txtSRLIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSeattleIV
        '
        Me.txtSeattleIV.BackColor = System.Drawing.Color.White
        Me.txtSeattleIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSeattleIV.Location = New System.Drawing.Point(122, 351)
        Me.txtSeattleIV.Name = "txtSeattleIV"
        Me.txtSeattleIV.ReadOnly = True
        Me.txtSeattleIV.Size = New System.Drawing.Size(159, 20)
        Me.txtSeattleIV.TabIndex = 48
        Me.txtSeattleIV.TabStop = False
        Me.txtSeattleIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalValue
        '
        Me.txtTotalValue.BackColor = System.Drawing.Color.White
        Me.txtTotalValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalValue.Location = New System.Drawing.Point(123, 454)
        Me.txtTotalValue.Name = "txtTotalValue"
        Me.txtTotalValue.ReadOnly = True
        Me.txtTotalValue.Size = New System.Drawing.Size(159, 20)
        Me.txtTotalValue.TabIndex = 47
        Me.txtTotalValue.TabStop = False
        Me.txtTotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRentonIV
        '
        Me.txtRentonIV.BackColor = System.Drawing.Color.White
        Me.txtRentonIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRentonIV.Location = New System.Drawing.Point(122, 312)
        Me.txtRentonIV.Name = "txtRentonIV"
        Me.txtRentonIV.ReadOnly = True
        Me.txtRentonIV.Size = New System.Drawing.Size(159, 20)
        Me.txtRentonIV.TabIndex = 44
        Me.txtRentonIV.TabStop = False
        Me.txtRentonIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPhoenixIV
        '
        Me.txtPhoenixIV.BackColor = System.Drawing.Color.White
        Me.txtPhoenixIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhoenixIV.Location = New System.Drawing.Point(122, 273)
        Me.txtPhoenixIV.Name = "txtPhoenixIV"
        Me.txtPhoenixIV.ReadOnly = True
        Me.txtPhoenixIV.Size = New System.Drawing.Size(159, 20)
        Me.txtPhoenixIV.TabIndex = 43
        Me.txtPhoenixIV.TabStop = False
        Me.txtPhoenixIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLyndhurstIV
        '
        Me.txtLyndhurstIV.BackColor = System.Drawing.Color.White
        Me.txtLyndhurstIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLyndhurstIV.Location = New System.Drawing.Point(122, 234)
        Me.txtLyndhurstIV.Name = "txtLyndhurstIV"
        Me.txtLyndhurstIV.ReadOnly = True
        Me.txtLyndhurstIV.Size = New System.Drawing.Size(159, 20)
        Me.txtLyndhurstIV.TabIndex = 42
        Me.txtLyndhurstIV.TabStop = False
        Me.txtLyndhurstIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLakeStevensIV
        '
        Me.txtLakeStevensIV.BackColor = System.Drawing.Color.White
        Me.txtLakeStevensIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLakeStevensIV.Location = New System.Drawing.Point(122, 195)
        Me.txtLakeStevensIV.Name = "txtLakeStevensIV"
        Me.txtLakeStevensIV.ReadOnly = True
        Me.txtLakeStevensIV.Size = New System.Drawing.Size(159, 20)
        Me.txtLakeStevensIV.TabIndex = 41
        Me.txtLakeStevensIV.TabStop = False
        Me.txtLakeStevensIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLewisvilleIV
        '
        Me.txtLewisvilleIV.BackColor = System.Drawing.Color.White
        Me.txtLewisvilleIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLewisvilleIV.Location = New System.Drawing.Point(122, 156)
        Me.txtLewisvilleIV.Name = "txtLewisvilleIV"
        Me.txtLewisvilleIV.ReadOnly = True
        Me.txtLewisvilleIV.Size = New System.Drawing.Size(159, 20)
        Me.txtLewisvilleIV.TabIndex = 40
        Me.txtLewisvilleIV.TabStop = False
        Me.txtLewisvilleIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHaywardIV
        '
        Me.txtHaywardIV.BackColor = System.Drawing.Color.White
        Me.txtHaywardIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHaywardIV.Location = New System.Drawing.Point(122, 117)
        Me.txtHaywardIV.Name = "txtHaywardIV"
        Me.txtHaywardIV.ReadOnly = True
        Me.txtHaywardIV.Size = New System.Drawing.Size(159, 20)
        Me.txtHaywardIV.TabIndex = 39
        Me.txtHaywardIV.TabStop = False
        Me.txtHaywardIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDowneyIV
        '
        Me.txtDowneyIV.BackColor = System.Drawing.Color.White
        Me.txtDowneyIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDowneyIV.Location = New System.Drawing.Point(122, 78)
        Me.txtDowneyIV.Name = "txtDowneyIV"
        Me.txtDowneyIV.ReadOnly = True
        Me.txtDowneyIV.Size = New System.Drawing.Size(159, 20)
        Me.txtDowneyIV.TabIndex = 38
        Me.txtDowneyIV.TabStop = False
        Me.txtDowneyIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBessemerIV
        '
        Me.txtBessemerIV.BackColor = System.Drawing.Color.White
        Me.txtBessemerIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBessemerIV.Location = New System.Drawing.Point(122, 39)
        Me.txtBessemerIV.Name = "txtBessemerIV"
        Me.txtBessemerIV.ReadOnly = True
        Me.txtBessemerIV.Size = New System.Drawing.Size(159, 20)
        Me.txtBessemerIV.TabIndex = 15
        Me.txtBessemerIV.TabStop = False
        Me.txtBessemerIV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(13, 390)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 20)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "SRL Industries"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(13, 351)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 20)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Seattle"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(13, 312)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 20)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Renton"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(13, 273)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 20)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Phoenix"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 20)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Lyndhurst"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(13, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 20)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Lake Stevens"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(13, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 20)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Lewisville"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 20)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Hayward"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 20)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Downey"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 20)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Bessemer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewConsignmentTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvConsignmentTotals)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewConsignmentTotals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Consignment Totals"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvConsignmentTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConsignmentTempTotalsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblEndingDate As System.Windows.Forms.Label
    Friend WithEvents lblBeginningDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ConsignmentTempTotalsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ConsignmentTempTotalsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ConsignmentTempTotalsTableAdapter
    Friend WithEvents dgvConsignmentTotals As System.Windows.Forms.DataGridView
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalValue As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents txtRentonIV As System.Windows.Forms.TextBox
    Friend WithEvents txtPhoenixIV As System.Windows.Forms.TextBox
    Friend WithEvents txtLyndhurstIV As System.Windows.Forms.TextBox
    Friend WithEvents txtLakeStevensIV As System.Windows.Forms.TextBox
    Friend WithEvents txtLewisvilleIV As System.Windows.Forms.TextBox
    Friend WithEvents txtHaywardIV As System.Windows.Forms.TextBox
    Friend WithEvents txtDowneyIV As System.Windows.Forms.TextBox
    Friend WithEvents txtBessemerIV As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSRLIV As System.Windows.Forms.TextBox
    Friend WithEvents txtSeattleIV As System.Windows.Forms.TextBox
    Friend WithEvents WarehouseIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarehouseNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalShipmentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalInvoicesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalReturnsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAdjustmentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeginDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PrintReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
