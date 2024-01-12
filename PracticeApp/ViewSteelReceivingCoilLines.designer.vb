<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelReceivingCoilLines
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
        Me.FIleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboCoilID = New System.Windows.Forms.ComboBox
        Me.CharterSteelCoilIdentificationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker
        Me.dtpBegin = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cboBOL = New System.Windows.Forms.ComboBox
        Me.lblBOL = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.SteelPurchaseOrderHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.cboSteelVendor = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.dgvSteelReceivingCoilLines = New System.Windows.Forms.DataGridView
        Me.SteelVendorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelBOLNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiveWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostPerPoundColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReceivingLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.lblTotalWeight = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.CharterSteelCoilIdentificationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
        Me.SteelPurchaseOrderHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.SteelReceivingLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingLineQueryTableAdapter
        Me.lblTotalCoilAmount = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblTotalCoils = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelReceivingCoilLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FIleToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FIleToolStripMenuItem
        '
        Me.FIleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem})
        Me.FIleToolStripMenuItem.Name = "FIleToolStripMenuItem"
        Me.FIleToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FIleToolStripMenuItem.Text = "File"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
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
        Me.GroupBox1.Controls.Add(Me.chkAllTypes)
        Me.GroupBox1.Controls.Add(Me.cboHeatNumber)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboCoilID)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.chkDateRange)
        Me.GroupBox1.Controls.Add(Me.dtpEnd)
        Me.GroupBox1.Controls.Add(Me.dtpBegin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmdView)
        Me.GroupBox1.Controls.Add(Me.cboBOL)
        Me.GroupBox1.Controls.Add(Me.lblBOL)
        Me.GroupBox1.Controls.Add(Me.cboSteelSize)
        Me.GroupBox1.Controls.Add(Me.cboCarbon)
        Me.GroupBox1.Controls.Add(Me.cboPONumber)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtVendorName)
        Me.GroupBox1.Controls.Add(Me.cboSteelVendor)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 768)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View By Filters"
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(103, 104)
        Me.chkAllTypes.Margin = New System.Windows.Forms.Padding(5)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(168, 17)
        Me.chkAllTypes.TabIndex = 2
        Me.chkAllTypes.Text = "Show all types for given grade"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatNumber.DisplayMember = "HeatNumber"
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(102, 529)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(180, 21)
        Me.cboHeatNumber.TabIndex = 9
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(13, 530)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Heat #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCoilID
        '
        Me.cboCoilID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCoilID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCoilID.DataSource = Me.CharterSteelCoilIdentificationBindingSource
        Me.cboCoilID.DisplayMember = "CoilID"
        Me.cboCoilID.FormattingEnabled = True
        Me.cboCoilID.Location = New System.Drawing.Point(13, 391)
        Me.cboCoilID.Name = "cboCoilID"
        Me.cboCoilID.Size = New System.Drawing.Size(269, 21)
        Me.cboCoilID.TabIndex = 6
        '
        'CharterSteelCoilIdentificationBindingSource
        '
        Me.CharterSteelCoilIdentificationBindingSource.DataMember = "CharterSteelCoilIdentification"
        Me.CharterSteelCoilIdentificationBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(13, 368)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Coil ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(13, 577)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(274, 33)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(103, 613)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 10
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEnd
        '
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(103, 684)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(180, 20)
        Me.dtpEnd.TabIndex = 12
        '
        'dtpBegin
        '
        Me.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBegin.Location = New System.Drawing.Point(103, 647)
        Me.dtpBegin.Name = "dtpBegin"
        Me.dtpBegin.Size = New System.Drawing.Size(180, 20)
        Me.dtpBegin.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 684)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "End Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 720)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 647)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Begin Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(133, 720)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 13
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cboBOL
        '
        Me.cboBOL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBOL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBOL.DataSource = Me.CharterSteelCoilIdentificationBindingSource
        Me.cboBOL.DisplayMember = "DespatchNumber"
        Me.cboBOL.FormattingEnabled = True
        Me.cboBOL.Location = New System.Drawing.Point(102, 493)
        Me.cboBOL.Name = "cboBOL"
        Me.cboBOL.Size = New System.Drawing.Size(180, 21)
        Me.cboBOL.TabIndex = 8
        '
        'lblBOL
        '
        Me.lblBOL.Location = New System.Drawing.Point(13, 494)
        Me.lblBOL.Name = "lblBOL"
        Me.lblBOL.Size = New System.Drawing.Size(100, 20)
        Me.lblBOL.TabIndex = 61
        Me.lblBOL.Text = "Bill of Lading #"
        Me.lblBOL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(103, 142)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(180, 21)
        Me.cboSteelSize.TabIndex = 3
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(103, 62)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(180, 21)
        Me.cboCarbon.TabIndex = 1
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.SteelPurchaseOrderHeaderBindingSource
        Me.cboPONumber.DisplayMember = "SteelPurchaseOrderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(102, 457)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(180, 21)
        Me.cboPONumber.TabIndex = 7
        '
        'SteelPurchaseOrderHeaderBindingSource
        '
        Me.SteelPurchaseOrderHeaderBindingSource.DataMember = "SteelPurchaseOrderHeader"
        Me.SteelPurchaseOrderHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 457)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Steel PO #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVendorName
        '
        Me.txtVendorName.BackColor = System.Drawing.Color.White
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(13, 261)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(270, 70)
        Me.txtVendorName.TabIndex = 5
        '
        'cboSteelVendor
        '
        Me.cboSteelVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelVendor.DataSource = Me.VendorBindingSource
        Me.cboSteelVendor.DisplayMember = "VendorCode"
        Me.cboSteelVendor.FormattingEnabled = True
        Me.cboSteelVendor.Location = New System.Drawing.Point(98, 224)
        Me.cboSteelVendor.Name = "cboSteelVendor"
        Me.cboSteelVendor.Size = New System.Drawing.Size(184, 21)
        Me.cboSteelVendor.TabIndex = 4
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(13, 223)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Steel Vendor"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Steel Size"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Steel Carbon"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(13, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 40)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvSteelReceivingCoilLines
        '
        Me.dgvSteelReceivingCoilLines.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSteelReceivingCoilLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSteelReceivingCoilLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelReceivingCoilLines.AutoGenerateColumns = False
        Me.dgvSteelReceivingCoilLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelReceivingCoilLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelReceivingCoilLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelReceivingCoilLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelVendorColumn, Me.ReceivingDateColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.CoilIDColumn, Me.CoilWeightColumn, Me.HeatNumberColumn, Me.SteelBOLNumberColumn, Me.PONumberColumn, Me.ReceiveWeightColumn, Me.SteelReceivingHeaderKeyColumn, Me.SteelReceivingLineKeyColumn, Me.SteelExtendedCostColumn, Me.DivisionIDColumn, Me.LineStatusColumn, Me.ReceivingStatusColumn, Me.POLineNumberColumn, Me.SteelCostPerPoundColumn, Me.SteelExtendedAmountColumn, Me.SteelPONumberColumn, Me.RMIDColumn, Me.DescriptionColumn})
        Me.dgvSteelReceivingCoilLines.DataSource = Me.SteelReceivingLineQueryBindingSource
        Me.dgvSteelReceivingCoilLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSteelReceivingCoilLines.Location = New System.Drawing.Point(346, 41)
        Me.dgvSteelReceivingCoilLines.Name = "dgvSteelReceivingCoilLines"
        Me.dgvSteelReceivingCoilLines.ReadOnly = True
        Me.dgvSteelReceivingCoilLines.Size = New System.Drawing.Size(684, 667)
        Me.dgvSteelReceivingCoilLines.TabIndex = 16
        '
        'SteelVendorColumn
        '
        Me.SteelVendorColumn.DataPropertyName = "SteelVendor"
        Me.SteelVendorColumn.HeaderText = "Vendor"
        Me.SteelVendorColumn.Name = "SteelVendorColumn"
        Me.SteelVendorColumn.ReadOnly = True
        '
        'ReceivingDateColumn
        '
        Me.ReceivingDateColumn.DataPropertyName = "ReceivingDate"
        Me.ReceivingDateColumn.HeaderText = "Date Rcd"
        Me.ReceivingDateColumn.Name = "ReceivingDateColumn"
        Me.ReceivingDateColumn.ReadOnly = True
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon/Alloy"
        Me.CarbonColumn.Name = "CarbonColumn"
        Me.CarbonColumn.ReadOnly = True
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.ReadOnly = True
        '
        'CoilIDColumn
        '
        Me.CoilIDColumn.DataPropertyName = "CoilID"
        Me.CoilIDColumn.HeaderText = "Coil ID"
        Me.CoilIDColumn.Name = "CoilIDColumn"
        Me.CoilIDColumn.ReadOnly = True
        '
        'CoilWeightColumn
        '
        Me.CoilWeightColumn.DataPropertyName = "CoilWeight"
        Me.CoilWeightColumn.HeaderText = "Coil Weight"
        Me.CoilWeightColumn.Name = "CoilWeightColumn"
        Me.CoilWeightColumn.ReadOnly = True
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.ReadOnly = True
        '
        'SteelBOLNumberColumn
        '
        Me.SteelBOLNumberColumn.DataPropertyName = "SteelBOLNumber"
        Me.SteelBOLNumberColumn.HeaderText = "BOL #"
        Me.SteelBOLNumberColumn.Name = "SteelBOLNumberColumn"
        Me.SteelBOLNumberColumn.ReadOnly = True
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PO #"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.ReadOnly = True
        '
        'ReceiveWeightColumn
        '
        Me.ReceiveWeightColumn.DataPropertyName = "ReceiveWeight"
        Me.ReceiveWeightColumn.HeaderText = "ReceiveWeight"
        Me.ReceiveWeightColumn.Name = "ReceiveWeightColumn"
        Me.ReceiveWeightColumn.ReadOnly = True
        Me.ReceiveWeightColumn.Visible = False
        '
        'SteelReceivingHeaderKeyColumn
        '
        Me.SteelReceivingHeaderKeyColumn.DataPropertyName = "SteelReceivingHeaderKey"
        Me.SteelReceivingHeaderKeyColumn.HeaderText = "SteelReceivingHeaderKey"
        Me.SteelReceivingHeaderKeyColumn.Name = "SteelReceivingHeaderKeyColumn"
        Me.SteelReceivingHeaderKeyColumn.ReadOnly = True
        Me.SteelReceivingHeaderKeyColumn.Visible = False
        '
        'SteelReceivingLineKeyColumn
        '
        Me.SteelReceivingLineKeyColumn.DataPropertyName = "SteelReceivingLineKey"
        Me.SteelReceivingLineKeyColumn.HeaderText = "SteelReceivingLineKey"
        Me.SteelReceivingLineKeyColumn.Name = "SteelReceivingLineKeyColumn"
        Me.SteelReceivingLineKeyColumn.ReadOnly = True
        Me.SteelReceivingLineKeyColumn.Visible = False
        '
        'SteelExtendedCostColumn
        '
        Me.SteelExtendedCostColumn.DataPropertyName = "SteelExtendedCost"
        Me.SteelExtendedCostColumn.HeaderText = "SteelExtendedCost"
        Me.SteelExtendedCostColumn.Name = "SteelExtendedCostColumn"
        Me.SteelExtendedCostColumn.ReadOnly = True
        Me.SteelExtendedCostColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        Me.LineStatusColumn.Visible = False
        '
        'ReceivingStatusColumn
        '
        Me.ReceivingStatusColumn.DataPropertyName = "ReceivingStatus"
        Me.ReceivingStatusColumn.HeaderText = "ReceivingStatus"
        Me.ReceivingStatusColumn.Name = "ReceivingStatusColumn"
        Me.ReceivingStatusColumn.ReadOnly = True
        Me.ReceivingStatusColumn.Visible = False
        '
        'POLineNumberColumn
        '
        Me.POLineNumberColumn.DataPropertyName = "POLineNumber"
        Me.POLineNumberColumn.HeaderText = "POLineNumber"
        Me.POLineNumberColumn.Name = "POLineNumberColumn"
        Me.POLineNumberColumn.ReadOnly = True
        Me.POLineNumberColumn.Visible = False
        '
        'SteelCostPerPoundColumn
        '
        Me.SteelCostPerPoundColumn.DataPropertyName = "SteelCostPerPound"
        Me.SteelCostPerPoundColumn.HeaderText = "SteelCostPerPound"
        Me.SteelCostPerPoundColumn.Name = "SteelCostPerPoundColumn"
        Me.SteelCostPerPoundColumn.ReadOnly = True
        Me.SteelCostPerPoundColumn.Visible = False
        '
        'SteelExtendedAmountColumn
        '
        Me.SteelExtendedAmountColumn.DataPropertyName = "SteelExtendedAmount"
        Me.SteelExtendedAmountColumn.HeaderText = "SteelExtendedAmount"
        Me.SteelExtendedAmountColumn.Name = "SteelExtendedAmountColumn"
        Me.SteelExtendedAmountColumn.ReadOnly = True
        Me.SteelExtendedAmountColumn.Visible = False
        '
        'SteelPONumberColumn
        '
        Me.SteelPONumberColumn.DataPropertyName = "SteelPONumber"
        Me.SteelPONumberColumn.HeaderText = "SteelPONumber"
        Me.SteelPONumberColumn.Name = "SteelPONumberColumn"
        Me.SteelPONumberColumn.ReadOnly = True
        Me.SteelPONumberColumn.Visible = False
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        Me.RMIDColumn.Visible = False
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.ReadOnly = True
        Me.DescriptionColumn.Visible = False
        '
        'SteelReceivingLineQueryBindingSource
        '
        Me.SteelReceivingLineQueryBindingSource.DataMember = "SteelReceivingLineQuery"
        Me.SteelReceivingLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 14
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'lblTotalWeight
        '
        Me.lblTotalWeight.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalWeight.Location = New System.Drawing.Point(446, 754)
        Me.lblTotalWeight.Name = "lblTotalWeight"
        Me.lblTotalWeight.Size = New System.Drawing.Size(154, 20)
        Me.lblTotalWeight.TabIndex = 48
        Me.lblTotalWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label9.Location = New System.Drawing.Point(346, 783)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 20)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Total Cost"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'CharterSteelCoilIdentificationTableAdapter
        '
        Me.CharterSteelCoilIdentificationTableAdapter.ClearBeforeFill = True
        '
        'SteelPurchaseOrderHeaderTableAdapter
        '
        Me.SteelPurchaseOrderHeaderTableAdapter.ClearBeforeFill = True
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'SteelReceivingLineQueryTableAdapter
        '
        Me.SteelReceivingLineQueryTableAdapter.ClearBeforeFill = True
        '
        'lblTotalCoilAmount
        '
        Me.lblTotalCoilAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblTotalCoilAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCoilAmount.Location = New System.Drawing.Point(446, 783)
        Me.lblTotalCoilAmount.Name = "lblTotalCoilAmount"
        Me.lblTotalCoilAmount.Size = New System.Drawing.Size(154, 20)
        Me.lblTotalCoilAmount.TabIndex = 50
        Me.lblTotalCoilAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label11.Location = New System.Drawing.Point(346, 727)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 20)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "# of Coils"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalCoils
        '
        Me.lblTotalCoils.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblTotalCoils.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCoils.Location = New System.Drawing.Point(446, 725)
        Me.lblTotalCoils.Name = "lblTotalCoils"
        Me.lblTotalCoils.Size = New System.Drawing.Size(154, 20)
        Me.lblTotalCoils.TabIndex = 52
        Me.lblTotalCoils.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label15.Location = New System.Drawing.Point(346, 755)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(107, 20)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Total Weight"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewSteelReceivingCoilLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.lblTotalCoils)
        Me.Controls.Add(Me.lblTotalCoilAmount)
        Me.Controls.Add(Me.lblTotalWeight)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgvSteelReceivingCoilLines)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "ViewSteelReceivingCoilLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Receiving (Coil Lines)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelReceivingCoilLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FIleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboBOL As System.Windows.Forms.ComboBox
    Friend WithEvents lblBOL As System.Windows.Forms.Label
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cboSteelVendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents dgvSteelReceivingCoilLines As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCoilID As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTotalWeight As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents CharterSteelCoilIdentificationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CharterSteelCoilIdentificationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
    Friend WithEvents SteelPurchaseOrderHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelPurchaseOrderHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents SteelReceivingLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelReceivingLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelReceivingLineQueryTableAdapter
    Friend WithEvents lblTotalCoilAmount As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCoils As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents SteelVendorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelBOLNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReceivingLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostPerPoundColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
