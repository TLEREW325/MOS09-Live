<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelChangeCoilAndRMIDAdjustment
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtBatchStatus = New System.Windows.Forms.TextBox
        Me.cboAdjustmentBatchNumber = New System.Windows.Forms.ComboBox
        Me.SteelChangeCoilAndRMIDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cmdBatchNumber = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtpAdjustmentDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.SteelAdjustmentTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdClearCoils = New System.Windows.Forms.Button
        Me.cmdSelectCoils = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.dgvChangeCoils = New System.Windows.Forms.DataGridView
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReworkCarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReworkSteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReworkCoilIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReworkCoilWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelAdjustmentBatchColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelAdjustmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CoilCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReworkHeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReworkCoilCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReworkRMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelChangeCoilAndRMIDTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelChangeCoilAndRMIDTableAdapter
        Me.dgvCoilList = New System.Windows.Forms.DataGridView
        Me.SelectCoil = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CoilIDColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WeightColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiveDateColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DespatchNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LocationColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryIDColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AnnealLotColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CharterSteelCoilIdentificationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CharterSteelCoilIdentificationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdAddCoils = New System.Windows.Forms.Button
        Me.SteelAdjustmentTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelAdjustmentTableTableAdapter
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.cmdClearChecks = New System.Windows.Forms.Button
        Me.cmdRemoveCoils = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdPost = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvSteelAdjustments = New System.Windows.Forms.DataGridView
        Me.SteelAdjustmentKeyColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCarbonColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentDateColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentWeightColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentCostColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentTotalColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LockedColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIDColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrintDateColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChangeRMIDColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChangeCoilIDColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdCheckAll = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboReworkSteelSize = New System.Windows.Forms.ComboBox
        Me.cboReworkCoilCarbon = New System.Windows.Forms.ComboBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkKeepCoilIDs = New System.Windows.Forms.CheckBox
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SteelChangeCoilAndRMIDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvChangeCoils, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCoilList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvSteelAdjustments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
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
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 20)
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
        Me.GroupBox1.Controls.Add(Me.txtBatchStatus)
        Me.GroupBox1.Controls.Add(Me.cboAdjustmentBatchNumber)
        Me.GroupBox1.Controls.Add(Me.cmdBatchNumber)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dtpAdjustmentDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(308, 120)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create Steel Adjustment Batch"
        '
        'txtBatchStatus
        '
        Me.txtBatchStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBatchStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBatchStatus.Location = New System.Drawing.Point(115, 90)
        Me.txtBatchStatus.Name = "txtBatchStatus"
        Me.txtBatchStatus.ReadOnly = True
        Me.txtBatchStatus.Size = New System.Drawing.Size(178, 20)
        Me.txtBatchStatus.TabIndex = 2
        Me.txtBatchStatus.TabStop = False
        Me.txtBatchStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboAdjustmentBatchNumber
        '
        Me.cboAdjustmentBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAdjustmentBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAdjustmentBatchNumber.DataSource = Me.SteelChangeCoilAndRMIDBindingSource
        Me.cboAdjustmentBatchNumber.DisplayMember = "SteelAdjustmentBatch"
        Me.cboAdjustmentBatchNumber.FormattingEnabled = True
        Me.cboAdjustmentBatchNumber.Location = New System.Drawing.Point(115, 27)
        Me.cboAdjustmentBatchNumber.Name = "cboAdjustmentBatchNumber"
        Me.cboAdjustmentBatchNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboAdjustmentBatchNumber.TabIndex = 0
        '
        'SteelChangeCoilAndRMIDBindingSource
        '
        Me.SteelChangeCoilAndRMIDBindingSource.DataMember = "SteelChangeCoilAndRMID"
        Me.SteelChangeCoilAndRMIDBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdBatchNumber
        '
        Me.cmdBatchNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdBatchNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdBatchNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBatchNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdBatchNumber.Location = New System.Drawing.Point(83, 27)
        Me.cmdBatchNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdBatchNumber.Name = "cmdBatchNumber"
        Me.cmdBatchNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdBatchNumber.TabIndex = 0
        Me.cmdBatchNumber.Text = ">>"
        Me.cmdBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBatchNumber.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 20)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Batch #"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(16, 89)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 20)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Batch Status"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpAdjustmentDate
        '
        Me.dtpAdjustmentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAdjustmentDate.Location = New System.Drawing.Point(115, 59)
        Me.dtpAdjustmentDate.Name = "dtpAdjustmentDate"
        Me.dtpAdjustmentDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpAdjustmentDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 20)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Batch Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SteelAdjustmentTableBindingSource
        '
        Me.SteelAdjustmentTableBindingSource.DataMember = "SteelAdjustmentTable"
        Me.SteelAdjustmentTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdClearCoils)
        Me.GroupBox2.Controls.Add(Me.cmdSelectCoils)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboSteelSize)
        Me.GroupBox2.Controls.Add(Me.cboCarbon)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 167)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(308, 135)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select Coils"
        '
        'cmdClearCoils
        '
        Me.cmdClearCoils.Location = New System.Drawing.Point(222, 91)
        Me.cmdClearCoils.Name = "cmdClearCoils"
        Me.cmdClearCoils.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearCoils.TabIndex = 7
        Me.cmdClearCoils.Text = "Clear Coils"
        Me.cmdClearCoils.UseVisualStyleBackColor = True
        '
        'cmdSelectCoils
        '
        Me.cmdSelectCoils.Location = New System.Drawing.Point(145, 91)
        Me.cmdSelectCoils.Name = "cmdSelectCoils"
        Me.cmdSelectCoils.Size = New System.Drawing.Size(71, 30)
        Me.cmdSelectCoils.TabIndex = 6
        Me.cmdSelectCoils.Text = "Select Coils"
        Me.cmdSelectCoils.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 20)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Carbon"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Size"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(83, 55)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(210, 21)
        Me.cboSteelSize.TabIndex = 5
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
        Me.cboCarbon.Location = New System.Drawing.Point(83, 19)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(210, 21)
        Me.cboCarbon.TabIndex = 4
        '
        'dgvChangeCoils
        '
        Me.dgvChangeCoils.AllowUserToAddRows = False
        Me.dgvChangeCoils.AllowUserToDeleteRows = False
        Me.dgvChangeCoils.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvChangeCoils.AutoGenerateColumns = False
        Me.dgvChangeCoils.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvChangeCoils.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChangeCoils.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CarbonColumn, Me.SteelSizeColumn, Me.CoilIDColumn, Me.CoilWeightColumn, Me.ReworkCarbonColumn, Me.ReworkSteelSizeColumn, Me.ReworkCoilIDColumn, Me.ReworkCoilWeightColumn, Me.CommentsColumn, Me.BatchStatusColumn, Me.BatchTypeColumn, Me.SteelAdjustmentBatchColumn, Me.SteelAdjustmentNumberColumn, Me.DivisionIDColumn, Me.AdjustmentDateColumn, Me.HeatNumberColumn, Me.CoilCostColumn, Me.ReworkHeatNumberColumn, Me.ReworkCoilCostColumn, Me.UserNameColumn, Me.RMIDColumn, Me.ReworkRMIDColumn})
        Me.dgvChangeCoils.DataSource = Me.SteelChangeCoilAndRMIDBindingSource
        Me.dgvChangeCoils.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvChangeCoils.Location = New System.Drawing.Point(353, 41)
        Me.dgvChangeCoils.Name = "dgvChangeCoils"
        Me.dgvChangeCoils.Size = New System.Drawing.Size(677, 498)
        Me.dgvChangeCoils.TabIndex = 4
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CarbonColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.CarbonColumn.HeaderText = "Old Carbon"
        Me.CarbonColumn.Name = "CarbonColumn"
        Me.CarbonColumn.ReadOnly = True
        Me.CarbonColumn.Width = 70
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SteelSizeColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.SteelSizeColumn.HeaderText = "Old Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.ReadOnly = True
        Me.SteelSizeColumn.Width = 80
        '
        'CoilIDColumn
        '
        Me.CoilIDColumn.DataPropertyName = "CoilID"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CoilIDColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.CoilIDColumn.HeaderText = "Old Coil ID"
        Me.CoilIDColumn.Name = "CoilIDColumn"
        Me.CoilIDColumn.ReadOnly = True
        Me.CoilIDColumn.Width = 80
        '
        'CoilWeightColumn
        '
        Me.CoilWeightColumn.DataPropertyName = "CoilWeight"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CoilWeightColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.CoilWeightColumn.HeaderText = "Old Coil Weight"
        Me.CoilWeightColumn.Name = "CoilWeightColumn"
        Me.CoilWeightColumn.ReadOnly = True
        Me.CoilWeightColumn.Width = 80
        '
        'ReworkCarbonColumn
        '
        Me.ReworkCarbonColumn.DataPropertyName = "ReworkCarbon"
        Me.ReworkCarbonColumn.HeaderText = "New Carbon"
        Me.ReworkCarbonColumn.Name = "ReworkCarbonColumn"
        Me.ReworkCarbonColumn.Width = 70
        '
        'ReworkSteelSizeColumn
        '
        Me.ReworkSteelSizeColumn.DataPropertyName = "ReworkSteelSize"
        Me.ReworkSteelSizeColumn.HeaderText = "New Steel Size"
        Me.ReworkSteelSizeColumn.Name = "ReworkSteelSizeColumn"
        Me.ReworkSteelSizeColumn.Width = 80
        '
        'ReworkCoilIDColumn
        '
        Me.ReworkCoilIDColumn.DataPropertyName = "ReworkCoilID"
        Me.ReworkCoilIDColumn.HeaderText = "New Coil ID"
        Me.ReworkCoilIDColumn.Name = "ReworkCoilIDColumn"
        Me.ReworkCoilIDColumn.Width = 80
        '
        'ReworkCoilWeightColumn
        '
        Me.ReworkCoilWeightColumn.DataPropertyName = "ReworkCoilWeight"
        Me.ReworkCoilWeightColumn.HeaderText = "New Coil Weight"
        Me.ReworkCoilWeightColumn.Name = "ReworkCoilWeightColumn"
        Me.ReworkCoilWeightColumn.Width = 80
        '
        'CommentsColumn
        '
        Me.CommentsColumn.DataPropertyName = "Comments"
        Me.CommentsColumn.HeaderText = "Comments"
        Me.CommentsColumn.Name = "CommentsColumn"
        Me.CommentsColumn.Visible = False
        '
        'BatchStatusColumn
        '
        Me.BatchStatusColumn.DataPropertyName = "BatchStatus"
        Me.BatchStatusColumn.HeaderText = "BatchStatus"
        Me.BatchStatusColumn.Name = "BatchStatusColumn"
        Me.BatchStatusColumn.Visible = False
        '
        'BatchTypeColumn
        '
        Me.BatchTypeColumn.DataPropertyName = "BatchType"
        Me.BatchTypeColumn.HeaderText = "BatchType"
        Me.BatchTypeColumn.Name = "BatchTypeColumn"
        Me.BatchTypeColumn.Visible = False
        '
        'SteelAdjustmentBatchColumn
        '
        Me.SteelAdjustmentBatchColumn.DataPropertyName = "SteelAdjustmentBatch"
        Me.SteelAdjustmentBatchColumn.HeaderText = "SteelAdjustmentBatch"
        Me.SteelAdjustmentBatchColumn.Name = "SteelAdjustmentBatchColumn"
        Me.SteelAdjustmentBatchColumn.Visible = False
        '
        'SteelAdjustmentNumberColumn
        '
        Me.SteelAdjustmentNumberColumn.DataPropertyName = "SteelAdjustmentNumber"
        Me.SteelAdjustmentNumberColumn.HeaderText = "SteelAdjustmentNumber"
        Me.SteelAdjustmentNumberColumn.Name = "SteelAdjustmentNumberColumn"
        Me.SteelAdjustmentNumberColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'AdjustmentDateColumn
        '
        Me.AdjustmentDateColumn.DataPropertyName = "AdjustmentDate"
        Me.AdjustmentDateColumn.HeaderText = "AdjustmentDate"
        Me.AdjustmentDateColumn.Name = "AdjustmentDateColumn"
        Me.AdjustmentDateColumn.Visible = False
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "HeatNumber"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.Visible = False
        '
        'CoilCostColumn
        '
        Me.CoilCostColumn.DataPropertyName = "CoilCost"
        Me.CoilCostColumn.HeaderText = "CoilCost"
        Me.CoilCostColumn.Name = "CoilCostColumn"
        Me.CoilCostColumn.Visible = False
        '
        'ReworkHeatNumberColumn
        '
        Me.ReworkHeatNumberColumn.DataPropertyName = "ReworkHeatNumber"
        Me.ReworkHeatNumberColumn.HeaderText = "ReworkHeatNumber"
        Me.ReworkHeatNumberColumn.Name = "ReworkHeatNumberColumn"
        Me.ReworkHeatNumberColumn.Visible = False
        '
        'ReworkCoilCostColumn
        '
        Me.ReworkCoilCostColumn.DataPropertyName = "ReworkCoilCost"
        Me.ReworkCoilCostColumn.HeaderText = "ReworkCoilCost"
        Me.ReworkCoilCostColumn.Name = "ReworkCoilCostColumn"
        Me.ReworkCoilCostColumn.Visible = False
        '
        'UserNameColumn
        '
        Me.UserNameColumn.DataPropertyName = "UserName"
        Me.UserNameColumn.HeaderText = "UserName"
        Me.UserNameColumn.Name = "UserNameColumn"
        Me.UserNameColumn.Visible = False
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RMIDColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.RMIDColumn.HeaderText = "OLD RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        Me.RMIDColumn.Visible = False
        '
        'ReworkRMIDColumn
        '
        Me.ReworkRMIDColumn.DataPropertyName = "ReworkRMID"
        Me.ReworkRMIDColumn.HeaderText = "New RMID"
        Me.ReworkRMIDColumn.Name = "ReworkRMIDColumn"
        Me.ReworkRMIDColumn.Visible = False
        '
        'SteelChangeCoilAndRMIDTableAdapter
        '
        Me.SteelChangeCoilAndRMIDTableAdapter.ClearBeforeFill = True
        '
        'dgvCoilList
        '
        Me.dgvCoilList.AllowUserToAddRows = False
        Me.dgvCoilList.AllowUserToDeleteRows = False
        Me.dgvCoilList.AutoGenerateColumns = False
        Me.dgvCoilList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCoilList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCoilList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectCoil, Me.CoilIDColumn2, Me.WeightColumn2, Me.LotNumberColumn2, Me.CarbonColumn2, Me.SteelSizeColumn2, Me.ReceiveDateColumn2, Me.DespatchNumberColumn2, Me.SalesOrderNumberColumn2, Me.PurchaseOrderNumberColumn2, Me.DescriptionColumn2, Me.StatusColumn2, Me.LocationColumn2, Me.InventoryIDColumn2, Me.AnnealLotColumn2, Me.CommentColumn2, Me.HeatNumberColumn2})
        Me.dgvCoilList.DataSource = Me.CharterSteelCoilIdentificationBindingSource
        Me.dgvCoilList.GridColor = System.Drawing.Color.Green
        Me.dgvCoilList.Location = New System.Drawing.Point(29, 308)
        Me.dgvCoilList.Name = "dgvCoilList"
        Me.dgvCoilList.Size = New System.Drawing.Size(308, 457)
        Me.dgvCoilList.TabIndex = 8
        '
        'SelectCoil
        '
        Me.SelectCoil.FalseValue = "UNSELECTED"
        Me.SelectCoil.HeaderText = "Select"
        Me.SelectCoil.Name = "SelectCoil"
        Me.SelectCoil.TrueValue = "SELECTED"
        Me.SelectCoil.Width = 50
        '
        'CoilIDColumn2
        '
        Me.CoilIDColumn2.DataPropertyName = "CoilID"
        Me.CoilIDColumn2.HeaderText = "Coil ID"
        Me.CoilIDColumn2.Name = "CoilIDColumn2"
        Me.CoilIDColumn2.Width = 120
        '
        'WeightColumn2
        '
        Me.WeightColumn2.DataPropertyName = "Weight"
        Me.WeightColumn2.HeaderText = "Weight"
        Me.WeightColumn2.Name = "WeightColumn2"
        Me.WeightColumn2.Width = 85
        '
        'LotNumberColumn2
        '
        Me.LotNumberColumn2.DataPropertyName = "LotNumber"
        Me.LotNumberColumn2.HeaderText = "LotNumber"
        Me.LotNumberColumn2.Name = "LotNumberColumn2"
        Me.LotNumberColumn2.Visible = False
        '
        'CarbonColumn2
        '
        Me.CarbonColumn2.DataPropertyName = "Carbon"
        Me.CarbonColumn2.HeaderText = "Carbon"
        Me.CarbonColumn2.Name = "CarbonColumn2"
        Me.CarbonColumn2.Visible = False
        '
        'SteelSizeColumn2
        '
        Me.SteelSizeColumn2.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn2.HeaderText = "SteelSize"
        Me.SteelSizeColumn2.Name = "SteelSizeColumn2"
        Me.SteelSizeColumn2.Visible = False
        '
        'ReceiveDateColumn2
        '
        Me.ReceiveDateColumn2.DataPropertyName = "ReceiveDate"
        Me.ReceiveDateColumn2.HeaderText = "ReceiveDate"
        Me.ReceiveDateColumn2.Name = "ReceiveDateColumn2"
        Me.ReceiveDateColumn2.Visible = False
        '
        'DespatchNumberColumn2
        '
        Me.DespatchNumberColumn2.DataPropertyName = "DespatchNumber"
        Me.DespatchNumberColumn2.HeaderText = "DespatchNumber"
        Me.DespatchNumberColumn2.Name = "DespatchNumberColumn2"
        Me.DespatchNumberColumn2.Visible = False
        '
        'SalesOrderNumberColumn2
        '
        Me.SalesOrderNumberColumn2.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn2.HeaderText = "SalesOrderNumber"
        Me.SalesOrderNumberColumn2.Name = "SalesOrderNumberColumn2"
        Me.SalesOrderNumberColumn2.Visible = False
        '
        'PurchaseOrderNumberColumn2
        '
        Me.PurchaseOrderNumberColumn2.DataPropertyName = "PurchaseOrderNumber"
        Me.PurchaseOrderNumberColumn2.HeaderText = "PurchaseOrderNumber"
        Me.PurchaseOrderNumberColumn2.Name = "PurchaseOrderNumberColumn2"
        Me.PurchaseOrderNumberColumn2.Visible = False
        '
        'DescriptionColumn2
        '
        Me.DescriptionColumn2.DataPropertyName = "Description"
        Me.DescriptionColumn2.HeaderText = "Description"
        Me.DescriptionColumn2.Name = "DescriptionColumn2"
        Me.DescriptionColumn2.Visible = False
        '
        'StatusColumn2
        '
        Me.StatusColumn2.DataPropertyName = "Status"
        Me.StatusColumn2.HeaderText = "Status"
        Me.StatusColumn2.Name = "StatusColumn2"
        Me.StatusColumn2.Visible = False
        '
        'LocationColumn2
        '
        Me.LocationColumn2.DataPropertyName = "Location"
        Me.LocationColumn2.HeaderText = "Location"
        Me.LocationColumn2.Name = "LocationColumn2"
        Me.LocationColumn2.Visible = False
        '
        'InventoryIDColumn2
        '
        Me.InventoryIDColumn2.DataPropertyName = "InventoryID"
        Me.InventoryIDColumn2.HeaderText = "InventoryID"
        Me.InventoryIDColumn2.Name = "InventoryIDColumn2"
        Me.InventoryIDColumn2.Visible = False
        '
        'AnnealLotColumn2
        '
        Me.AnnealLotColumn2.DataPropertyName = "AnnealLot"
        Me.AnnealLotColumn2.HeaderText = "AnnealLot"
        Me.AnnealLotColumn2.Name = "AnnealLotColumn2"
        Me.AnnealLotColumn2.Visible = False
        '
        'CommentColumn2
        '
        Me.CommentColumn2.DataPropertyName = "Comment"
        Me.CommentColumn2.HeaderText = "Comment"
        Me.CommentColumn2.Name = "CommentColumn2"
        Me.CommentColumn2.Visible = False
        '
        'HeatNumberColumn2
        '
        Me.HeatNumberColumn2.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn2.HeaderText = "Heat #"
        Me.HeatNumberColumn2.Name = "HeatNumberColumn2"
        Me.HeatNumberColumn2.Visible = False
        '
        'CharterSteelCoilIdentificationBindingSource
        '
        Me.CharterSteelCoilIdentificationBindingSource.DataMember = "CharterSteelCoilIdentification"
        Me.CharterSteelCoilIdentificationBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'CharterSteelCoilIdentificationTableAdapter
        '
        Me.CharterSteelCoilIdentificationTableAdapter.ClearBeforeFill = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(805, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 16
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
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
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(728, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 15
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdAddCoils
        '
        Me.cmdAddCoils.Location = New System.Drawing.Point(279, 226)
        Me.cmdAddCoils.Name = "cmdAddCoils"
        Me.cmdAddCoils.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddCoils.TabIndex = 9
        Me.cmdAddCoils.Text = "Add Coils"
        Me.cmdAddCoils.UseVisualStyleBackColor = True
        '
        'SteelAdjustmentTableTableAdapter
        '
        Me.SteelAdjustmentTableTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'cmdClearChecks
        '
        Me.cmdClearChecks.Location = New System.Drawing.Point(102, 781)
        Me.cmdClearChecks.Name = "cmdClearChecks"
        Me.cmdClearChecks.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearChecks.TabIndex = 10
        Me.cmdClearChecks.Text = "Clear All"
        Me.cmdClearChecks.UseVisualStyleBackColor = True
        '
        'cmdRemoveCoils
        '
        Me.cmdRemoveCoils.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoveCoils.Location = New System.Drawing.Point(805, 725)
        Me.cmdRemoveCoils.Name = "cmdRemoveCoils"
        Me.cmdRemoveCoils.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoveCoils.TabIndex = 11
        Me.cmdRemoveCoils.Text = "Remove Coils"
        Me.cmdRemoveCoils.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdPost)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(728, 620)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(302, 77)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        '
        'cmdPost
        '
        Me.cmdPost.Location = New System.Drawing.Point(212, 22)
        Me.cmdPost.Name = "cmdPost"
        Me.cmdPost.Size = New System.Drawing.Size(71, 40)
        Me.cmdPost.TabIndex = 13
        Me.cmdPost.Text = "Post"
        Me.cmdPost.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(31, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(243, 32)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Corrects inventory and Coil ID's."
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComments.Location = New System.Drawing.Point(26, 146)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(324, 74)
        Me.txtComments.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(29, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(321, 20)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Comment"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvSteelAdjustments
        '
        Me.dgvSteelAdjustments.AllowUserToAddRows = False
        Me.dgvSteelAdjustments.AllowUserToDeleteRows = False
        Me.dgvSteelAdjustments.AutoGenerateColumns = False
        Me.dgvSteelAdjustments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelAdjustments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelAdjustmentKeyColumn3, Me.BatchNumberColumn3, Me.DivisionIDColumn3, Me.RMIDColumn3, Me.SteelCarbonColumn3, Me.SteelSizeColumn3, Me.AdjustmentDateColumn3, Me.AdjustmentWeightColumn3, Me.AdjustmentCostColumn3, Me.AdjustmentTotalColumn3, Me.CommentColumn3, Me.StatusColumn3, Me.LockedColumn3, Me.UserIDColumn3, Me.PrintDateColumn3, Me.ChangeRMIDColumn3, Me.ChangeCoilIDColumn3})
        Me.dgvSteelAdjustments.DataSource = Me.SteelAdjustmentTableBindingSource
        Me.dgvSteelAdjustments.Location = New System.Drawing.Point(580, 418)
        Me.dgvSteelAdjustments.Name = "dgvSteelAdjustments"
        Me.dgvSteelAdjustments.Size = New System.Drawing.Size(155, 40)
        Me.dgvSteelAdjustments.TabIndex = 46
        Me.dgvSteelAdjustments.Visible = False
        '
        'SteelAdjustmentKeyColumn3
        '
        Me.SteelAdjustmentKeyColumn3.DataPropertyName = "SteelAdjustmentKey"
        Me.SteelAdjustmentKeyColumn3.HeaderText = "SteelAdjustmentKey"
        Me.SteelAdjustmentKeyColumn3.Name = "SteelAdjustmentKeyColumn3"
        '
        'BatchNumberColumn3
        '
        Me.BatchNumberColumn3.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn3.HeaderText = "BatchNumber"
        Me.BatchNumberColumn3.Name = "BatchNumberColumn3"
        '
        'DivisionIDColumn3
        '
        Me.DivisionIDColumn3.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn3.HeaderText = "DivisionID"
        Me.DivisionIDColumn3.Name = "DivisionIDColumn3"
        '
        'RMIDColumn3
        '
        Me.RMIDColumn3.DataPropertyName = "RMID"
        Me.RMIDColumn3.HeaderText = "RMID"
        Me.RMIDColumn3.Name = "RMIDColumn3"
        '
        'SteelCarbonColumn3
        '
        Me.SteelCarbonColumn3.DataPropertyName = "SteelCarbon"
        Me.SteelCarbonColumn3.HeaderText = "SteelCarbon"
        Me.SteelCarbonColumn3.Name = "SteelCarbonColumn3"
        '
        'SteelSizeColumn3
        '
        Me.SteelSizeColumn3.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn3.HeaderText = "SteelSize"
        Me.SteelSizeColumn3.Name = "SteelSizeColumn3"
        '
        'AdjustmentDateColumn3
        '
        Me.AdjustmentDateColumn3.DataPropertyName = "AdjustmentDate"
        Me.AdjustmentDateColumn3.HeaderText = "AdjustmentDate"
        Me.AdjustmentDateColumn3.Name = "AdjustmentDateColumn3"
        '
        'AdjustmentWeightColumn3
        '
        Me.AdjustmentWeightColumn3.DataPropertyName = "AdjustmentWeight"
        Me.AdjustmentWeightColumn3.HeaderText = "AdjustmentWeight"
        Me.AdjustmentWeightColumn3.Name = "AdjustmentWeightColumn3"
        '
        'AdjustmentCostColumn3
        '
        Me.AdjustmentCostColumn3.DataPropertyName = "AdjustmentCost"
        Me.AdjustmentCostColumn3.HeaderText = "AdjustmentCost"
        Me.AdjustmentCostColumn3.Name = "AdjustmentCostColumn3"
        '
        'AdjustmentTotalColumn3
        '
        Me.AdjustmentTotalColumn3.DataPropertyName = "AdjustmentTotal"
        Me.AdjustmentTotalColumn3.HeaderText = "AdjustmentTotal"
        Me.AdjustmentTotalColumn3.Name = "AdjustmentTotalColumn3"
        '
        'CommentColumn3
        '
        Me.CommentColumn3.DataPropertyName = "Comment"
        Me.CommentColumn3.HeaderText = "Comment"
        Me.CommentColumn3.Name = "CommentColumn3"
        '
        'StatusColumn3
        '
        Me.StatusColumn3.DataPropertyName = "Status"
        Me.StatusColumn3.HeaderText = "Status"
        Me.StatusColumn3.Name = "StatusColumn3"
        '
        'LockedColumn3
        '
        Me.LockedColumn3.DataPropertyName = "Locked"
        Me.LockedColumn3.HeaderText = "Locked"
        Me.LockedColumn3.Name = "LockedColumn3"
        '
        'UserIDColumn3
        '
        Me.UserIDColumn3.DataPropertyName = "UserID"
        Me.UserIDColumn3.HeaderText = "UserID"
        Me.UserIDColumn3.Name = "UserIDColumn3"
        '
        'PrintDateColumn3
        '
        Me.PrintDateColumn3.DataPropertyName = "PrintDate"
        Me.PrintDateColumn3.HeaderText = "PrintDate"
        Me.PrintDateColumn3.Name = "PrintDateColumn3"
        '
        'ChangeRMIDColumn3
        '
        Me.ChangeRMIDColumn3.DataPropertyName = "ChangeRMID"
        Me.ChangeRMIDColumn3.HeaderText = "ChangeRMID"
        Me.ChangeRMIDColumn3.Name = "ChangeRMIDColumn3"
        '
        'ChangeCoilIDColumn3
        '
        Me.ChangeCoilIDColumn3.DataPropertyName = "ChangeCoilID"
        Me.ChangeCoilIDColumn3.HeaderText = "ChangeCoilID"
        Me.ChangeCoilIDColumn3.Name = "ChangeCoilIDColumn3"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(728, 563)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(302, 32)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "You must completely fill out the datagrid.  If the Coil ID does not change, type " & _
            "in the same in the ""New Coil ID"" field. "
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(728, 725)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 14
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdCheckAll
        '
        Me.cmdCheckAll.Location = New System.Drawing.Point(25, 781)
        Me.cmdCheckAll.Name = "cmdCheckAll"
        Me.cmdCheckAll.Size = New System.Drawing.Size(71, 30)
        Me.cmdCheckAll.TabIndex = 50
        Me.cmdCheckAll.Text = "Check All"
        Me.cmdCheckAll.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(23, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 20)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Carbon"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(23, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 20)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Size"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboReworkSteelSize
        '
        Me.cboReworkSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReworkSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReworkSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboReworkSteelSize.DisplayMember = "SteelSize"
        Me.cboReworkSteelSize.FormattingEnabled = True
        Me.cboReworkSteelSize.Location = New System.Drawing.Point(140, 59)
        Me.cboReworkSteelSize.Name = "cboReworkSteelSize"
        Me.cboReworkSteelSize.Size = New System.Drawing.Size(210, 21)
        Me.cboReworkSteelSize.TabIndex = 52
        '
        'cboReworkCoilCarbon
        '
        Me.cboReworkCoilCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReworkCoilCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReworkCoilCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboReworkCoilCarbon.DisplayMember = "Carbon"
        Me.cboReworkCoilCarbon.FormattingEnabled = True
        Me.cboReworkCoilCarbon.Location = New System.Drawing.Point(140, 29)
        Me.cboReworkCoilCarbon.Name = "cboReworkCoilCarbon"
        Me.cboReworkCoilCarbon.Size = New System.Drawing.Size(210, 21)
        Me.cboReworkCoilCarbon.TabIndex = 51
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.chkKeepCoilIDs)
        Me.GroupBox4.Controls.Add(Me.cmdAddCoils)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.cboReworkCoilCarbon)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.cboReworkSteelSize)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtComments)
        Me.GroupBox4.Location = New System.Drawing.Point(353, 545)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(369, 266)
        Me.GroupBox4.TabIndex = 55
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Add Coils to Batch"
        '
        'chkKeepCoilIDs
        '
        Me.chkKeepCoilIDs.AutoSize = True
        Me.chkKeepCoilIDs.ForeColor = System.Drawing.Color.Blue
        Me.chkKeepCoilIDs.Location = New System.Drawing.Point(26, 94)
        Me.chkKeepCoilIDs.Name = "chkKeepCoilIDs"
        Me.chkKeepCoilIDs.Size = New System.Drawing.Size(130, 17)
        Me.chkKeepCoilIDs.TabIndex = 55
        Me.chkKeepCoilIDs.Text = "Keep existing Coil ID's"
        Me.chkKeepCoilIDs.UseVisualStyleBackColor = True
        '
        'SteelChangeCoilAndRMIDAdjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cmdCheckAll)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdRemoveCoils)
        Me.Controls.Add(Me.cmdClearChecks)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.dgvCoilList)
        Me.Controls.Add(Me.dgvChangeCoils)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvSteelAdjustments)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SteelChangeCoilAndRMIDAdjustment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Change Coil ID and Raw Material"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SteelChangeCoilAndRMIDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvChangeCoils, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCoilList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvSteelAdjustments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBatchStatus As System.Windows.Forms.TextBox
    Friend WithEvents cboAdjustmentBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdBatchNumber As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtpAdjustmentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvChangeCoils As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelChangeCoilAndRMIDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelChangeCoilAndRMIDTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelChangeCoilAndRMIDTableAdapter
    Friend WithEvents cmdSelectCoils As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents dgvCoilList As System.Windows.Forms.DataGridView
    Friend WithEvents CharterSteelCoilIdentificationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CharterSteelCoilIdentificationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAddCoils As System.Windows.Forms.Button
    Friend WithEvents SteelAdjustmentTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelAdjustmentTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelAdjustmentTableTableAdapter
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents cmdClearCoils As System.Windows.Forms.Button
    Friend WithEvents cmdClearChecks As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveCoils As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SelectCoil As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CoilIDColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeightColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveDateColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DespatchNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocationColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryIDColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnnealLotColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdPost As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvSteelAdjustments As System.Windows.Forms.DataGridView
    Friend WithEvents SteelAdjustmentKeyColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCarbonColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentDateColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentWeightColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentCostColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentTotalColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LockedColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIDColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDateColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChangeRMIDColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChangeCoilIDColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdCheckAll As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboReworkSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboReworkCoilCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkKeepCoilIDs As System.Windows.Forms.CheckBox
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReworkCarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReworkSteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReworkCoilIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReworkCoilWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelAdjustmentBatchColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelAdjustmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CoilCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReworkHeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReworkCoilCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReworkRMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
