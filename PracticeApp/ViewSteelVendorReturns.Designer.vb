<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelVendorReturns
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
        Me.FielToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtHeatNumber = New System.Windows.Forms.TextBox
        Me.cboSteelReceiver = New System.Windows.Forms.ComboBox
        Me.SteelReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboSteelReturnNumber = New System.Windows.Forms.ComboBox
        Me.SteelReturnHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboSteelPONumber = New System.Windows.Forms.ComboBox
        Me.SteelPurchaseOrderHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.chkUseDates = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.dgvReturnLineQuery = New System.Windows.Forms.DataGridView
        Me.SteelReturnLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelReturnLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnLineQueryTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.SteelPurchaseOrderHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
        Me.SteelReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingHeaderTableTableAdapter
        Me.SteelReturnHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnHeaderTableTableAdapter
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.SteelReturnNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceiverNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelVendorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilCostPerPoundColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OtherTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReturnLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceiverLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPOLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SteelReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReturnHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReturnLineQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReturnLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FielToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FielToolStripMenuItem
        '
        Me.FielToolStripMenuItem.Name = "FielToolStripMenuItem"
        Me.FielToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FielToolStripMenuItem.Text = "File"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintReportsToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintReportsToolStripMenuItem
        '
        Me.PrintReportsToolStripMenuItem.Name = "PrintReportsToolStripMenuItem"
        Me.PrintReportsToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PrintReportsToolStripMenuItem.Text = "Print Reports"
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
        Me.GroupBox1.Controls.Add(Me.cboStatus)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtHeatNumber)
        Me.GroupBox1.Controls.Add(Me.cboSteelReceiver)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboSteelReturnNumber)
        Me.GroupBox1.Controls.Add(Me.cboSteelPONumber)
        Me.GroupBox1.Controls.Add(Me.txtVendorName)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cmdView)
        Me.GroupBox1.Controls.Add(Me.chkUseDates)
        Me.GroupBox1.Controls.Add(Me.dtpEndDate)
        Me.GroupBox1.Controls.Add(Me.dtpBeginDate)
        Me.GroupBox1.Controls.Add(Me.cboSteelSize)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboCarbon)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboVendorID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 784)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filters"
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "CLOSED"})
        Me.cboStatus.Location = New System.Drawing.Point(116, 513)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(167, 21)
        Me.cboStatus.TabIndex = 87
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(23, 513)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 23)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Return Status"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHeatNumber
        '
        Me.txtHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatNumber.Location = New System.Drawing.Point(85, 423)
        Me.txtHeatNumber.Name = "txtHeatNumber"
        Me.txtHeatNumber.Size = New System.Drawing.Size(198, 20)
        Me.txtHeatNumber.TabIndex = 8
        '
        'cboSteelReceiver
        '
        Me.cboSteelReceiver.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelReceiver.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelReceiver.DataSource = Me.SteelReceivingHeaderTableBindingSource
        Me.cboSteelReceiver.DisplayMember = "SteelReceivingHeaderKey"
        Me.cboSteelReceiver.FormattingEnabled = True
        Me.cboSteelReceiver.Location = New System.Drawing.Point(116, 222)
        Me.cboSteelReceiver.Name = "cboSteelReceiver"
        Me.cboSteelReceiver.Size = New System.Drawing.Size(167, 21)
        Me.cboSteelReceiver.TabIndex = 4
        '
        'SteelReceivingHeaderTableBindingSource
        '
        Me.SteelReceivingHeaderTableBindingSource.DataMember = "SteelReceivingHeaderTable"
        Me.SteelReceivingHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(23, 222)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 23)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Steel Reciever #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelReturnNumber
        '
        Me.cboSteelReturnNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelReturnNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelReturnNumber.DataSource = Me.SteelReturnHeaderTableBindingSource
        Me.cboSteelReturnNumber.DisplayMember = "SteelReturnNumber"
        Me.cboSteelReturnNumber.FormattingEnabled = True
        Me.cboSteelReturnNumber.Location = New System.Drawing.Point(116, 266)
        Me.cboSteelReturnNumber.Name = "cboSteelReturnNumber"
        Me.cboSteelReturnNumber.Size = New System.Drawing.Size(167, 21)
        Me.cboSteelReturnNumber.TabIndex = 5
        '
        'SteelReturnHeaderTableBindingSource
        '
        Me.SteelReturnHeaderTableBindingSource.DataMember = "SteelReturnHeaderTable"
        Me.SteelReturnHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboSteelPONumber
        '
        Me.cboSteelPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelPONumber.DataSource = Me.SteelPurchaseOrderHeaderBindingSource
        Me.cboSteelPONumber.DisplayMember = "SteelPurchaseOrderKey"
        Me.cboSteelPONumber.FormattingEnabled = True
        Me.cboSteelPONumber.Location = New System.Drawing.Point(116, 178)
        Me.cboSteelPONumber.Name = "cboSteelPONumber"
        Me.cboSteelPONumber.Size = New System.Drawing.Size(167, 21)
        Me.cboSteelPONumber.TabIndex = 3
        '
        'SteelPurchaseOrderHeaderBindingSource
        '
        Me.SteelPurchaseOrderHeaderBindingSource.DataMember = "SteelPurchaseOrderHeader"
        Me.SteelPurchaseOrderHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(23, 66)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(260, 70)
        Me.txtVendorName.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(25, 581)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(258, 33)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 736)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(133, 736)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 12
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'chkUseDates
        '
        Me.chkUseDates.AutoSize = True
        Me.chkUseDates.Location = New System.Drawing.Point(116, 628)
        Me.chkUseDates.Name = "chkUseDates"
        Me.chkUseDates.Size = New System.Drawing.Size(106, 17)
        Me.chkUseDates.TabIndex = 9
        Me.chkUseDates.Text = "Use Date Range"
        Me.chkUseDates.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(116, 697)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(167, 20)
        Me.dtpEndDate.TabIndex = 11
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(116, 661)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(167, 20)
        Me.dtpBeginDate.TabIndex = 10
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(85, 381)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(198, 21)
        Me.cboSteelSize.TabIndex = 7
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 381)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Steel Size"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(85, 339)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(198, 21)
        Me.cboCarbon.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(23, 339)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Carbon"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(83, 30)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(200, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(23, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 697)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 23)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "End Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 661)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Begin Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(23, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 23)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "Steel Return #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(23, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 23)
        Me.Label7.TabIndex = 80
        Me.Label7.Text = "Steel PO #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(23, 423)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 23)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "Heat #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
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
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'dgvReturnLineQuery
        '
        Me.dgvReturnLineQuery.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvReturnLineQuery.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReturnLineQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReturnLineQuery.AutoGenerateColumns = False
        Me.dgvReturnLineQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReturnLineQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvReturnLineQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReturnLineQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelReturnNumberColumn, Me.SteelPONumberColumn, Me.SteelReceiverNumberColumn, Me.SteelVendorColumn, Me.ReturnDateColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.HeatNumberColumn, Me.CoilIDColumn, Me.CoilWeightColumn, Me.CoilCostPerPoundColumn, Me.CoilExtendedCostColumn, Me.LineCommentColumn, Me.ReturnQuantityColumn, Me.UnitCostColumn, Me.ExtendedCostColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn, Me.LineStatusColumn, Me.ReturnStatusColumn, Me.RMIDColumn, Me.DescriptionColumn, Me.ReturnCommentColumn, Me.ProductTotalColumn, Me.OtherTotalColumn, Me.FreightTotalColumn, Me.ReturnTotalColumn, Me.SteelReturnLineColumn, Me.SteelReceiverLineNumberColumn, Me.SteelPOLineColumn, Me.DivisionIDColumn})
        Me.dgvReturnLineQuery.DataSource = Me.SteelReturnLineQueryBindingSource
        Me.dgvReturnLineQuery.GridColor = System.Drawing.Color.Purple
        Me.dgvReturnLineQuery.Location = New System.Drawing.Point(349, 41)
        Me.dgvReturnLineQuery.Name = "dgvReturnLineQuery"
        Me.dgvReturnLineQuery.Size = New System.Drawing.Size(681, 720)
        Me.dgvReturnLineQuery.TabIndex = 17
        '
        'SteelReturnLineQueryBindingSource
        '
        Me.SteelReturnLineQueryBindingSource.DataMember = "SteelReturnLineQuery"
        Me.SteelReturnLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelReturnLineQueryTableAdapter
        '
        Me.SteelReturnLineQueryTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'SteelPurchaseOrderHeaderTableAdapter
        '
        Me.SteelPurchaseOrderHeaderTableAdapter.ClearBeforeFill = True
        '
        'SteelReceivingHeaderTableTableAdapter
        '
        Me.SteelReceivingHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'SteelReturnHeaderTableTableAdapter
        '
        Me.SteelReturnHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'SteelReturnNumberColumn
        '
        Me.SteelReturnNumberColumn.DataPropertyName = "SteelReturnNumber"
        Me.SteelReturnNumberColumn.HeaderText = "Return #"
        Me.SteelReturnNumberColumn.Name = "SteelReturnNumberColumn"
        Me.SteelReturnNumberColumn.ReadOnly = True
        Me.SteelReturnNumberColumn.Width = 80
        '
        'SteelPONumberColumn
        '
        Me.SteelPONumberColumn.DataPropertyName = "SteelPONumber"
        Me.SteelPONumberColumn.HeaderText = "PO #"
        Me.SteelPONumberColumn.Name = "SteelPONumberColumn"
        Me.SteelPONumberColumn.ReadOnly = True
        Me.SteelPONumberColumn.Width = 80
        '
        'SteelReceiverNumberColumn
        '
        Me.SteelReceiverNumberColumn.DataPropertyName = "SteelReceiverNumber"
        Me.SteelReceiverNumberColumn.HeaderText = "Receiver #"
        Me.SteelReceiverNumberColumn.Name = "SteelReceiverNumberColumn"
        Me.SteelReceiverNumberColumn.ReadOnly = True
        Me.SteelReceiverNumberColumn.Width = 80
        '
        'SteelVendorColumn
        '
        Me.SteelVendorColumn.DataPropertyName = "SteelVendor"
        Me.SteelVendorColumn.HeaderText = "Vendor"
        Me.SteelVendorColumn.Name = "SteelVendorColumn"
        Me.SteelVendorColumn.ReadOnly = True
        '
        'ReturnDateColumn
        '
        Me.ReturnDateColumn.DataPropertyName = "ReturnDate"
        Me.ReturnDateColumn.HeaderText = "Return Date"
        Me.ReturnDateColumn.Name = "ReturnDateColumn"
        Me.ReturnDateColumn.ReadOnly = True
        Me.ReturnDateColumn.Width = 90
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon/Alloy"
        Me.CarbonColumn.Name = "CarbonColumn"
        Me.CarbonColumn.ReadOnly = True
        Me.CarbonColumn.Width = 80
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.ReadOnly = True
        Me.SteelSizeColumn.Width = 80
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.ReadOnly = True
        Me.HeatNumberColumn.Width = 90
        '
        'CoilIDColumn
        '
        Me.CoilIDColumn.DataPropertyName = "CoilID"
        Me.CoilIDColumn.HeaderText = "Coil ID"
        Me.CoilIDColumn.Name = "CoilIDColumn"
        Me.CoilIDColumn.ReadOnly = True
        Me.CoilIDColumn.Width = 90
        '
        'CoilWeightColumn
        '
        Me.CoilWeightColumn.DataPropertyName = "CoilWeight"
        Me.CoilWeightColumn.HeaderText = "Coil Weight"
        Me.CoilWeightColumn.Name = "CoilWeightColumn"
        Me.CoilWeightColumn.ReadOnly = True
        Me.CoilWeightColumn.Width = 80
        '
        'CoilCostPerPoundColumn
        '
        Me.CoilCostPerPoundColumn.DataPropertyName = "CoilCostPerPound"
        Me.CoilCostPerPoundColumn.HeaderText = "Cost Per Pound"
        Me.CoilCostPerPoundColumn.Name = "CoilCostPerPoundColumn"
        Me.CoilCostPerPoundColumn.ReadOnly = True
        Me.CoilCostPerPoundColumn.Width = 80
        '
        'CoilExtendedCostColumn
        '
        Me.CoilExtendedCostColumn.DataPropertyName = "CoilExtendedCost"
        Me.CoilExtendedCostColumn.HeaderText = "Extended Cost"
        Me.CoilExtendedCostColumn.Name = "CoilExtendedCostColumn"
        Me.CoilExtendedCostColumn.ReadOnly = True
        Me.CoilExtendedCostColumn.Width = 80
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'ReturnQuantityColumn
        '
        Me.ReturnQuantityColumn.DataPropertyName = "ReturnQuantity"
        Me.ReturnQuantityColumn.HeaderText = "ReturnQuantity"
        Me.ReturnQuantityColumn.Name = "ReturnQuantityColumn"
        Me.ReturnQuantityColumn.Visible = False
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        Me.UnitCostColumn.HeaderText = "UnitCost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Visible = False
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        Me.ExtendedCostColumn.HeaderText = "ExtendedCost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        Me.ExtendedCostColumn.Visible = False
        '
        'GLDebitAccountColumn
        '
        Me.GLDebitAccountColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountColumn.HeaderText = "GLDebitAccount"
        Me.GLDebitAccountColumn.Name = "GLDebitAccountColumn"
        Me.GLDebitAccountColumn.ReadOnly = True
        '
        'GLCreditAccountColumn
        '
        Me.GLCreditAccountColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountColumn.HeaderText = "GLCreditAccount"
        Me.GLCreditAccountColumn.Name = "GLCreditAccountColumn"
        Me.GLCreditAccountColumn.ReadOnly = True
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        '
        'ReturnStatusColumn
        '
        Me.ReturnStatusColumn.DataPropertyName = "ReturnStatus"
        Me.ReturnStatusColumn.HeaderText = "Return Status"
        Me.ReturnStatusColumn.Name = "ReturnStatusColumn"
        Me.ReturnStatusColumn.ReadOnly = True
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.Visible = False
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.Visible = False
        '
        'ReturnCommentColumn
        '
        Me.ReturnCommentColumn.DataPropertyName = "ReturnComment"
        Me.ReturnCommentColumn.HeaderText = "ReturnComment"
        Me.ReturnCommentColumn.Name = "ReturnCommentColumn"
        Me.ReturnCommentColumn.Visible = False
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        Me.ProductTotalColumn.HeaderText = "ProductTotal"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.Visible = False
        '
        'OtherTotalColumn
        '
        Me.OtherTotalColumn.DataPropertyName = "OtherTotal"
        Me.OtherTotalColumn.HeaderText = "OtherTotal"
        Me.OtherTotalColumn.Name = "OtherTotalColumn"
        Me.OtherTotalColumn.Visible = False
        '
        'FreightTotalColumn
        '
        Me.FreightTotalColumn.DataPropertyName = "FreightTotal"
        Me.FreightTotalColumn.HeaderText = "FreightTotal"
        Me.FreightTotalColumn.Name = "FreightTotalColumn"
        Me.FreightTotalColumn.Visible = False
        '
        'ReturnTotalColumn
        '
        Me.ReturnTotalColumn.DataPropertyName = "ReturnTotal"
        Me.ReturnTotalColumn.HeaderText = "ReturnTotal"
        Me.ReturnTotalColumn.Name = "ReturnTotalColumn"
        Me.ReturnTotalColumn.Visible = False
        '
        'SteelReturnLineColumn
        '
        Me.SteelReturnLineColumn.DataPropertyName = "SteelReturnLine"
        Me.SteelReturnLineColumn.HeaderText = "SteelReturnLine"
        Me.SteelReturnLineColumn.Name = "SteelReturnLineColumn"
        Me.SteelReturnLineColumn.Visible = False
        '
        'SteelReceiverLineNumberColumn
        '
        Me.SteelReceiverLineNumberColumn.DataPropertyName = "SteelReceiverLineNumber"
        Me.SteelReceiverLineNumberColumn.HeaderText = "SteelReceiverLineNumber"
        Me.SteelReceiverLineNumberColumn.Name = "SteelReceiverLineNumberColumn"
        Me.SteelReceiverLineNumberColumn.Visible = False
        '
        'SteelPOLineColumn
        '
        Me.SteelPOLineColumn.DataPropertyName = "SteelPOLine"
        Me.SteelPOLineColumn.HeaderText = "SteelPOLine"
        Me.SteelPOLineColumn.Name = "SteelPOLineColumn"
        Me.SteelPOLineColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'ViewSteelVendorReturns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvReturnLineQuery)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewSteelVendorReturns"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Steel Vendor Returns"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SteelReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReturnHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReturnLineQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReturnLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FielToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkUseDates As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSteelReturnNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboSteelPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelReturnLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReturnLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnLineQueryTableAdapter
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvReturnLineQuery As System.Windows.Forms.DataGridView
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents SteelPurchaseOrderHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelPurchaseOrderHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
    Friend WithEvents SteelReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingHeaderTableTableAdapter
    Friend WithEvents SteelReturnHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReturnHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReturnHeaderTableTableAdapter
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents cboSteelReceiver As System.Windows.Forms.ComboBox
    Friend WithEvents SteelReturnNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceiverNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelVendorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilCostPerPoundColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtherTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReturnLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceiverLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPOLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
