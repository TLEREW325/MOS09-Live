<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryTubs
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
        Me.RemoveAllTubsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewPrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewPrintSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewPrintSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewPrintAllTagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewPrintSummaryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvInventoryTubs = New System.Windows.Forms.DataGridView
        Me.InventoryKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NetWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TubNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastProcessColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ScannedDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineLaborCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TFPInventoryTubsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtScanLotNumber = New System.Windows.Forms.TextBox
        Me.lblLotNumber = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTubNumber = New System.Windows.Forms.TextBox
        Me.dtpInventoryDate = New System.Windows.Forms.DateTimePicker
        Me.lblPartNumber = New System.Windows.Forms.Label
        Me.lblFOXNumber = New System.Windows.Forms.Label
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdDeleteSelected = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdPrintInventoryTags = New System.Windows.Forms.Button
        Me.cmdViewPrintSelected = New System.Windows.Forms.Button
        Me.cmdPrintSelected = New System.Windows.Forms.Button
        Me.cmdViewPrintList = New System.Windows.Forms.Button
        Me.cmdViewPrintSummary = New System.Windows.Forms.Button
        Me.cmdReLoadForm = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdClose = New System.Windows.Forms.Button
        Me.FOXNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessStepColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessIDColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessRemoveRMColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessAddFGColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gpxAdminControl = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdUpdateProcesses = New System.Windows.Forms.Button
        Me.dgvFoxProcesses = New System.Windows.Forms.DataGridView
        Me.FOXNumberColumnFP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessStepColumnFP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessIDColumnFP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessRemoveRMColumnFP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessAddFGColumnFP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FoxSchedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TFPInventoryTubsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TFPInventoryTubsTableAdapter
        Me.crxInventoryTubTag1 = New MOS09Program.CRXInventoryTubTag
        Me.FoxSchedTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FoxSchedTableAdapter
        Me.Label10 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvInventoryTubs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFPInventoryTubsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gpxAdminControl.SuspendLayout()
        CType(Me.dgvFoxProcesses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FoxSchedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewPrintToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveAllTubsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'RemoveAllTubsToolStripMenuItem
        '
        Me.RemoveAllTubsToolStripMenuItem.Enabled = False
        Me.RemoveAllTubsToolStripMenuItem.Name = "RemoveAllTubsToolStripMenuItem"
        Me.RemoveAllTubsToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.RemoveAllTubsToolStripMenuItem.Text = "Remove All Tubs"
        '
        'ViewPrintToolStripMenuItem
        '
        Me.ViewPrintToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewPrintSummaryToolStripMenuItem, Me.ViewPrintSelectedToolStripMenuItem, Me.ViewPrintAllTagsToolStripMenuItem, Me.ViewPrintSummaryToolStripMenuItem1})
        Me.ViewPrintToolStripMenuItem.Name = "ViewPrintToolStripMenuItem"
        Me.ViewPrintToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.ViewPrintToolStripMenuItem.Text = "View/Print"
        '
        'ViewPrintSummaryToolStripMenuItem
        '
        Me.ViewPrintSummaryToolStripMenuItem.Name = "ViewPrintSummaryToolStripMenuItem"
        Me.ViewPrintSummaryToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ViewPrintSummaryToolStripMenuItem.Text = "View/Print List"
        '
        'ViewPrintSelectedToolStripMenuItem
        '
        Me.ViewPrintSelectedToolStripMenuItem.Name = "ViewPrintSelectedToolStripMenuItem"
        Me.ViewPrintSelectedToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ViewPrintSelectedToolStripMenuItem.Text = "View / Print Selected"
        '
        'ViewPrintAllTagsToolStripMenuItem
        '
        Me.ViewPrintAllTagsToolStripMenuItem.Name = "ViewPrintAllTagsToolStripMenuItem"
        Me.ViewPrintAllTagsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ViewPrintAllTagsToolStripMenuItem.Text = "View / Print All Tags"
        '
        'ViewPrintSummaryToolStripMenuItem1
        '
        Me.ViewPrintSummaryToolStripMenuItem1.Name = "ViewPrintSummaryToolStripMenuItem1"
        Me.ViewPrintSummaryToolStripMenuItem1.Size = New System.Drawing.Size(172, 22)
        Me.ViewPrintSummaryToolStripMenuItem1.Text = "View/Print Summary"
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
        'dgvInventoryTubs
        '
        Me.dgvInventoryTubs.AllowUserToAddRows = False
        Me.dgvInventoryTubs.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvInventoryTubs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventoryTubs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryTubs.AutoGenerateColumns = False
        Me.dgvInventoryTubs.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryTubs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInventoryTubs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryTubs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InventoryKeyColumn, Me.InventoryLineNumberColumn, Me.LotNumberColumn, Me.FOXNumberColumn, Me.PartNumberColumn, Me.PieceCountColumn, Me.NetWeightColumn, Me.TubNumberColumn, Me.LastProcessColumn, Me.InventoryStatusColumn, Me.InventoryDateColumn, Me.ScannedDateColumn, Me.MachineLaborCostColumn})
        Me.dgvInventoryTubs.DataSource = Me.TFPInventoryTubsBindingSource
        Me.dgvInventoryTubs.GridColor = System.Drawing.Color.Purple
        Me.dgvInventoryTubs.Location = New System.Drawing.Point(336, 27)
        Me.dgvInventoryTubs.Name = "dgvInventoryTubs"
        Me.dgvInventoryTubs.Size = New System.Drawing.Size(794, 722)
        Me.dgvInventoryTubs.TabIndex = 1
        Me.dgvInventoryTubs.TabStop = False
        '
        'InventoryKeyColumn
        '
        Me.InventoryKeyColumn.DataPropertyName = "InventoryKey"
        Me.InventoryKeyColumn.HeaderText = "Inventory Key"
        Me.InventoryKeyColumn.Name = "InventoryKeyColumn"
        Me.InventoryKeyColumn.ReadOnly = True
        Me.InventoryKeyColumn.Width = 80
        '
        'InventoryLineNumberColumn
        '
        Me.InventoryLineNumberColumn.DataPropertyName = "InventoryLineNumber"
        Me.InventoryLineNumberColumn.HeaderText = "Line #"
        Me.InventoryLineNumberColumn.Name = "InventoryLineNumberColumn"
        Me.InventoryLineNumberColumn.ReadOnly = True
        Me.InventoryLineNumberColumn.Width = 80
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        Me.LotNumberColumn.ReadOnly = True
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        Me.FOXNumberColumn.Width = 80
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PieceCountColumn
        '
        Me.PieceCountColumn.DataPropertyName = "PieceCount"
        Me.PieceCountColumn.HeaderText = "Piece Count"
        Me.PieceCountColumn.Name = "PieceCountColumn"
        Me.PieceCountColumn.Width = 80
        '
        'NetWeightColumn
        '
        Me.NetWeightColumn.DataPropertyName = "NetWeight"
        Me.NetWeightColumn.HeaderText = "Net Weight"
        Me.NetWeightColumn.Name = "NetWeightColumn"
        Me.NetWeightColumn.Width = 80
        '
        'TubNumberColumn
        '
        Me.TubNumberColumn.DataPropertyName = "TubNumber"
        Me.TubNumberColumn.HeaderText = "Tub #"
        Me.TubNumberColumn.Name = "TubNumberColumn"
        '
        'LastProcessColumn
        '
        Me.LastProcessColumn.DataPropertyName = "LastProcess"
        Me.LastProcessColumn.HeaderText = "Last Process"
        Me.LastProcessColumn.Name = "LastProcessColumn"
        Me.LastProcessColumn.Width = 80
        '
        'InventoryStatusColumn
        '
        Me.InventoryStatusColumn.DataPropertyName = "InventoryStatus"
        Me.InventoryStatusColumn.HeaderText = "Status"
        Me.InventoryStatusColumn.Name = "InventoryStatusColumn"
        Me.InventoryStatusColumn.ReadOnly = True
        '
        'InventoryDateColumn
        '
        Me.InventoryDateColumn.DataPropertyName = "InventoryDate"
        Me.InventoryDateColumn.HeaderText = "Inventory Date"
        Me.InventoryDateColumn.Name = "InventoryDateColumn"
        '
        'ScannedDateColumn
        '
        Me.ScannedDateColumn.DataPropertyName = "ScannedDate"
        Me.ScannedDateColumn.HeaderText = "Scanned Date"
        Me.ScannedDateColumn.Name = "ScannedDateColumn"
        '
        'MachineLaborCostColumn
        '
        Me.MachineLaborCostColumn.DataPropertyName = "MachineLaborCost"
        Me.MachineLaborCostColumn.HeaderText = "Machine Labor Cost"
        Me.MachineLaborCostColumn.Name = "MachineLaborCostColumn"
        '
        'TFPInventoryTubsBindingSource
        '
        Me.TFPInventoryTubsBindingSource.DataMember = "TFPInventoryTubs"
        Me.TFPInventoryTubsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtScanLotNumber)
        Me.GroupBox1.Controls.Add(Me.lblLotNumber)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtTubNumber)
        Me.GroupBox1.Controls.Add(Me.dtpInventoryDate)
        Me.GroupBox1.Controls.Add(Me.lblPartNumber)
        Me.GroupBox1.Controls.Add(Me.lblFOXNumber)
        Me.GroupBox1.Controls.Add(Me.cmdAdd)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(318, 412)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Tub"
        '
        'txtScanLotNumber
        '
        Me.txtScanLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScanLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtScanLotNumber.Location = New System.Drawing.Point(6, 102)
        Me.txtScanLotNumber.Name = "txtScanLotNumber"
        Me.txtScanLotNumber.Size = New System.Drawing.Size(295, 20)
        Me.txtScanLotNumber.TabIndex = 2
        '
        'lblLotNumber
        '
        Me.lblLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotNumber.Location = New System.Drawing.Point(105, 156)
        Me.lblLotNumber.Name = "lblLotNumber"
        Me.lblLotNumber.Size = New System.Drawing.Size(196, 23)
        Me.lblLotNumber.TabIndex = 3
        Me.lblLotNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(9, 156)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 23)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "LotNumber"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTubNumber
        '
        Me.txtTubNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTubNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTubNumber.Location = New System.Drawing.Point(105, 300)
        Me.txtTubNumber.Name = "txtTubNumber"
        Me.txtTubNumber.Size = New System.Drawing.Size(196, 20)
        Me.txtTubNumber.TabIndex = 6
        '
        'dtpInventoryDate
        '
        Me.dtpInventoryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInventoryDate.Location = New System.Drawing.Point(153, 38)
        Me.dtpInventoryDate.Name = "dtpInventoryDate"
        Me.dtpInventoryDate.Size = New System.Drawing.Size(148, 20)
        Me.dtpInventoryDate.TabIndex = 1
        '
        'lblPartNumber
        '
        Me.lblPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartNumber.Location = New System.Drawing.Point(105, 252)
        Me.lblPartNumber.Name = "lblPartNumber"
        Me.lblPartNumber.Size = New System.Drawing.Size(196, 23)
        Me.lblPartNumber.TabIndex = 5
        Me.lblPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFOXNumber
        '
        Me.lblFOXNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFOXNumber.Location = New System.Drawing.Point(105, 204)
        Me.lblFOXNumber.Name = "lblFOXNumber"
        Me.lblFOXNumber.Size = New System.Drawing.Size(196, 23)
        Me.lblFOXNumber.TabIndex = 4
        Me.lblFOXNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(153, 351)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(71, 40)
        Me.cmdAdd.TabIndex = 7
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(230, 351)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(9, 300)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 23)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Tub # (Optional)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(9, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 23)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Inventory Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Part Number"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 204)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "FOX Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Scan or Enter Lot Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteSelected
        '
        Me.cmdDeleteSelected.Location = New System.Drawing.Point(230, 35)
        Me.cmdDeleteSelected.Name = "cmdDeleteSelected"
        Me.cmdDeleteSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteSelected.TabIndex = 4
        Me.cmdDeleteSelected.Text = "Delete Selected"
        Me.cmdDeleteSelected.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmdDeleteSelected)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 445)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(318, 100)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Delete Row"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(6, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 40)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Deletes the selcted row from the datagrid."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintInventoryTags
        '
        Me.cmdPrintInventoryTags.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintInventoryTags.Location = New System.Drawing.Point(828, 771)
        Me.cmdPrintInventoryTags.Name = "cmdPrintInventoryTags"
        Me.cmdPrintInventoryTags.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintInventoryTags.TabIndex = 6
        Me.cmdPrintInventoryTags.Text = "View/Print All Tags"
        Me.cmdPrintInventoryTags.UseVisualStyleBackColor = True
        '
        'cmdViewPrintSelected
        '
        Me.cmdViewPrintSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPrintSelected.Location = New System.Drawing.Point(674, 771)
        Me.cmdViewPrintSelected.Name = "cmdViewPrintSelected"
        Me.cmdViewPrintSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPrintSelected.TabIndex = 7
        Me.cmdViewPrintSelected.Text = "View/Print Selected"
        Me.cmdViewPrintSelected.UseVisualStyleBackColor = True
        '
        'cmdPrintSelected
        '
        Me.cmdPrintSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintSelected.Location = New System.Drawing.Point(751, 771)
        Me.cmdPrintSelected.Name = "cmdPrintSelected"
        Me.cmdPrintSelected.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintSelected.TabIndex = 99
        Me.cmdPrintSelected.Text = "Print Multiple"
        Me.cmdPrintSelected.UseVisualStyleBackColor = True
        '
        'cmdViewPrintList
        '
        Me.cmdViewPrintList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPrintList.Location = New System.Drawing.Point(982, 771)
        Me.cmdViewPrintList.Name = "cmdViewPrintList"
        Me.cmdViewPrintList.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPrintList.TabIndex = 100
        Me.cmdViewPrintList.Text = "View/Print List"
        Me.cmdViewPrintList.UseVisualStyleBackColor = True
        '
        'cmdViewPrintSummary
        '
        Me.cmdViewPrintSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPrintSummary.Location = New System.Drawing.Point(905, 771)
        Me.cmdViewPrintSummary.Name = "cmdViewPrintSummary"
        Me.cmdViewPrintSummary.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPrintSummary.TabIndex = 101
        Me.cmdViewPrintSummary.Text = "WIP Report"
        Me.cmdViewPrintSummary.UseVisualStyleBackColor = True
        '
        'cmdReLoadForm
        '
        Me.cmdReLoadForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReLoadForm.Location = New System.Drawing.Point(336, 771)
        Me.cmdReLoadForm.Name = "cmdReLoadForm"
        Me.cmdReLoadForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdReLoadForm.TabIndex = 102
        Me.cmdReLoadForm.Text = "Reload Form"
        Me.cmdReLoadForm.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.cmdClose)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 551)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(318, 100)
        Me.GroupBox3.TabIndex = 103
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Close All Rows"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(6, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(229, 40)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Closes all previous years and starts new."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(230, 35)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(71, 40)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'FOXNumberColumn2
        '
        Me.FOXNumberColumn2.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn2.HeaderText = "FOXNumber"
        Me.FOXNumberColumn2.Name = "FOXNumberColumn2"
        '
        'ProcessStepColumn2
        '
        Me.ProcessStepColumn2.DataPropertyName = "ProcessStep"
        Me.ProcessStepColumn2.HeaderText = "ProcessStep"
        Me.ProcessStepColumn2.Name = "ProcessStepColumn2"
        '
        'ProcessIDColumn2
        '
        Me.ProcessIDColumn2.DataPropertyName = "ProcessID"
        Me.ProcessIDColumn2.HeaderText = "ProcessID"
        Me.ProcessIDColumn2.Name = "ProcessIDColumn2"
        '
        'ProcessRemoveRMColumn2
        '
        Me.ProcessRemoveRMColumn2.DataPropertyName = "ProcessRemoveRM"
        Me.ProcessRemoveRMColumn2.HeaderText = "ProcessRemoveRM"
        Me.ProcessRemoveRMColumn2.Name = "ProcessRemoveRMColumn2"
        '
        'ProcessAddFGColumn2
        '
        Me.ProcessAddFGColumn2.DataPropertyName = "ProcessAddFG"
        Me.ProcessAddFGColumn2.HeaderText = "ProcessAddFG"
        Me.ProcessAddFGColumn2.Name = "ProcessAddFGColumn2"
        '
        'gpxAdminControl
        '
        Me.gpxAdminControl.Controls.Add(Me.Label3)
        Me.gpxAdminControl.Controls.Add(Me.cmdUpdateProcesses)
        Me.gpxAdminControl.Enabled = False
        Me.gpxAdminControl.Location = New System.Drawing.Point(12, 657)
        Me.gpxAdminControl.Name = "gpxAdminControl"
        Me.gpxAdminControl.Size = New System.Drawing.Size(318, 154)
        Me.gpxAdminControl.TabIndex = 104
        Me.gpxAdminControl.TabStop = False
        Me.gpxAdminControl.Text = "Admin Only"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(9, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(292, 66)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "This will reset the process step for all foxes listed in the datagrid."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdUpdateProcesses
        '
        Me.cmdUpdateProcesses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateProcesses.Location = New System.Drawing.Point(230, 95)
        Me.cmdUpdateProcesses.Name = "cmdUpdateProcesses"
        Me.cmdUpdateProcesses.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateProcesses.TabIndex = 103
        Me.cmdUpdateProcesses.Text = "Update Processes"
        Me.cmdUpdateProcesses.UseVisualStyleBackColor = True
        '
        'dgvFoxProcesses
        '
        Me.dgvFoxProcesses.AllowUserToAddRows = False
        Me.dgvFoxProcesses.AllowUserToDeleteRows = False
        Me.dgvFoxProcesses.AutoGenerateColumns = False
        Me.dgvFoxProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFoxProcesses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FOXNumberColumnFP, Me.ProcessStepColumnFP, Me.ProcessIDColumnFP, Me.ProcessRemoveRMColumnFP, Me.ProcessAddFGColumnFP})
        Me.dgvFoxProcesses.DataSource = Me.FoxSchedBindingSource
        Me.dgvFoxProcesses.Location = New System.Drawing.Point(371, 77)
        Me.dgvFoxProcesses.Name = "dgvFoxProcesses"
        Me.dgvFoxProcesses.ReadOnly = True
        Me.dgvFoxProcesses.Size = New System.Drawing.Size(634, 212)
        Me.dgvFoxProcesses.TabIndex = 105
        Me.dgvFoxProcesses.Visible = False
        '
        'FOXNumberColumnFP
        '
        Me.FOXNumberColumnFP.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumnFP.HeaderText = "FOXNumber"
        Me.FOXNumberColumnFP.Name = "FOXNumberColumnFP"
        Me.FOXNumberColumnFP.ReadOnly = True
        '
        'ProcessStepColumnFP
        '
        Me.ProcessStepColumnFP.DataPropertyName = "ProcessStep"
        Me.ProcessStepColumnFP.HeaderText = "ProcessStep"
        Me.ProcessStepColumnFP.Name = "ProcessStepColumnFP"
        Me.ProcessStepColumnFP.ReadOnly = True
        '
        'ProcessIDColumnFP
        '
        Me.ProcessIDColumnFP.DataPropertyName = "ProcessID"
        Me.ProcessIDColumnFP.HeaderText = "ProcessID"
        Me.ProcessIDColumnFP.Name = "ProcessIDColumnFP"
        Me.ProcessIDColumnFP.ReadOnly = True
        '
        'ProcessRemoveRMColumnFP
        '
        Me.ProcessRemoveRMColumnFP.DataPropertyName = "ProcessRemoveRM"
        Me.ProcessRemoveRMColumnFP.HeaderText = "ProcessRemoveRM"
        Me.ProcessRemoveRMColumnFP.Name = "ProcessRemoveRMColumnFP"
        Me.ProcessRemoveRMColumnFP.ReadOnly = True
        '
        'ProcessAddFGColumnFP
        '
        Me.ProcessAddFGColumnFP.DataPropertyName = "ProcessAddFG"
        Me.ProcessAddFGColumnFP.HeaderText = "ProcessAddFG"
        Me.ProcessAddFGColumnFP.Name = "ProcessAddFGColumnFP"
        Me.ProcessAddFGColumnFP.ReadOnly = True
        '
        'FoxSchedBindingSource
        '
        Me.FoxSchedBindingSource.DataMember = "FoxSched"
        Me.FoxSchedBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'TFPInventoryTubsTableAdapter
        '
        Me.TFPInventoryTubsTableAdapter.ClearBeforeFill = True
        '
        'FoxSchedTableAdapter
        '
        Me.FoxSchedTableAdapter.ClearBeforeFill = True
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(12, 323)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(289, 24)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "(or location of the tub)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InventoryTubs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.gpxAdminControl)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdReLoadForm)
        Me.Controls.Add(Me.cmdViewPrintSummary)
        Me.Controls.Add(Me.cmdViewPrintList)
        Me.Controls.Add(Me.cmdPrintSelected)
        Me.Controls.Add(Me.cmdViewPrintSelected)
        Me.Controls.Add(Me.cmdPrintInventoryTags)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvInventoryTubs)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvFoxProcesses)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InventoryTubs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Inventory Tubs"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvInventoryTubs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFPInventoryTubsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.gpxAdminControl.ResumeLayout(False)
        CType(Me.dgvFoxProcesses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FoxSchedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveAllTubsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvInventoryTubs As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lblFOXNumber As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPartNumber As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintInventoryTags As System.Windows.Forms.Button
    Friend WithEvents cmdViewPrintSelected As System.Windows.Forms.Button
    Friend WithEvents cmdPrintSelected As System.Windows.Forms.Button
    Friend WithEvents ViewPrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewPrintSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewPrintSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewPrintAllTagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdViewPrintList As System.Windows.Forms.Button
    Friend WithEvents cmdViewPrintSummary As System.Windows.Forms.Button
    Friend WithEvents ViewPrintSummaryToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpInventoryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTubNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdReLoadForm As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents TFPInventoryTubsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TFPInventoryTubsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TFPInventoryTubsTableAdapter
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents lblLotNumber As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtScanLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents InventoryKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NetWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TubNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastProcessColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScannedDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineLaborCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents FOXNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessStepColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessIDColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessRemoveRMColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessAddFGColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gpxAdminControl As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdUpdateProcesses As System.Windows.Forms.Button
    Friend WithEvents crxInventoryTubTag1 As MOS09Program.CRXInventoryTubTag
    Friend WithEvents dgvFoxProcesses As System.Windows.Forms.DataGridView
    Friend WithEvents FoxSchedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FoxSchedTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FoxSchedTableAdapter
    Friend WithEvents FOXNumberColumnFP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessStepColumnFP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessIDColumnFP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessRemoveRMColumnFP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessAddFGColumnFP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
