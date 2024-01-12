<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewConsignmentInventory
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkAllWarehouses = New System.Windows.Forms.CheckBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkQOH = New System.Windows.Forms.CheckBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboWarehouse = New System.Windows.Forms.ComboBox
        Me.FOBTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblFOXNumber = New System.Windows.Forms.Label
        Me.dgvConsignmentInventory = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityBilledColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityAdjustedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityReturnedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LongDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConsignmentInventoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.gpxVoucherMaintenance = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.ConsignmentInventoryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ConsignmentInventoryTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkValueAll = New System.Windows.Forms.CheckBox
        Me.cboValueDivision = New System.Windows.Forms.ComboBox
        Me.dtpValueDate = New System.Windows.Forms.DateTimePicker
        Me.cmdPrintValueReport = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdApplyFilter = New System.Windows.Forms.Button
        Me.cmdValueInventory = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.dgvFIFOValue = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FIFOCostColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FIFOExtendedAmountColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValuationDateColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryFIFOValuationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventoryFIFOValuationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryFIFOValuationTableAdapter
        Me.FOBTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOBTableTableAdapter
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdPrintInventorySteel = New System.Windows.Forms.Button
        Me.cmdValueInventorySteel = New System.Windows.Forms.Button
        Me.dgvFIFOSteelValue = New System.Windows.Forms.DataGridView
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostUnitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCarbonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValuationDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventorySteelValuationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventorySteelValuationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventorySteelValuationTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOBTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvConsignmentInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConsignmentInventoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxVoucherMaintenance.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvFIFOValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryFIFOValuationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvFIFOSteelValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventorySteelValuationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 48
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
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
        Me.cmdPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 8
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 9
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cboItemClass)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkAllWarehouses)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chkQOH)
        Me.GroupBox1.Controls.Add(Me.cboPartDescription)
        Me.GroupBox1.Controls.Add(Me.cboPartNumber)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdView)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cboWarehouse)
        Me.GroupBox1.Controls.Add(Me.lblFOXNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 292)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View By Filters"
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(97, 153)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(182, 21)
        Me.cboItemClass.TabIndex = 4
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Item Class"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAllWarehouses
        '
        Me.chkAllWarehouses.AutoSize = True
        Me.chkAllWarehouses.Location = New System.Drawing.Point(19, 193)
        Me.chkAllWarehouses.Name = "chkAllWarehouses"
        Me.chkAllWarehouses.Size = New System.Drawing.Size(126, 17)
        Me.chkAllWarehouses.TabIndex = 5
        Me.chkAllWarehouses.Text = "View All Warehouses"
        Me.chkAllWarehouses.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(97, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(182, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Division"
        '
        'chkQOH
        '
        Me.chkQOH.AutoSize = True
        Me.chkQOH.Location = New System.Drawing.Point(19, 220)
        Me.chkQOH.Name = "chkQOH"
        Me.chkQOH.Size = New System.Drawing.Size(129, 17)
        Me.chkQOH.TabIndex = 6
        Me.chkQOH.Text = "Quantity On Hand > 0"
        Me.chkQOH.UseVisualStyleBackColor = True
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(19, 89)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(260, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(68, 57)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(211, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Part #"
        '
        'cmdView
        '
        Me.cmdView.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdView.Location = New System.Drawing.Point(131, 248)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 7
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(208, 248)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboWarehouse
        '
        Me.cboWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboWarehouse.DataSource = Me.FOBTableBindingSource
        Me.cboWarehouse.DisplayMember = "FOBName"
        Me.cboWarehouse.FormattingEnabled = True
        Me.cboWarehouse.Location = New System.Drawing.Point(97, 121)
        Me.cboWarehouse.Name = "cboWarehouse"
        Me.cboWarehouse.Size = New System.Drawing.Size(182, 21)
        Me.cboWarehouse.TabIndex = 3
        '
        'FOBTableBindingSource
        '
        Me.FOBTableBindingSource.DataMember = "FOBTable"
        Me.FOBTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblFOXNumber
        '
        Me.lblFOXNumber.Location = New System.Drawing.Point(16, 124)
        Me.lblFOXNumber.Name = "lblFOXNumber"
        Me.lblFOXNumber.Size = New System.Drawing.Size(62, 20)
        Me.lblFOXNumber.TabIndex = 0
        Me.lblFOXNumber.Text = "Warehouse"
        Me.lblFOXNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvConsignmentInventory
        '
        Me.dgvConsignmentInventory.AllowUserToAddRows = False
        Me.dgvConsignmentInventory.AllowUserToDeleteRows = False
        Me.dgvConsignmentInventory.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvConsignmentInventory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvConsignmentInventory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConsignmentInventory.AutoGenerateColumns = False
        Me.dgvConsignmentInventory.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvConsignmentInventory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsignmentInventory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvConsignmentInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsignmentInventory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.PartNumberColumn, Me.ShortDescriptionColumn, Me.QuantityOnHandColumn, Me.QuantityShippedColumn, Me.QuantityBilledColumn, Me.QuantityAdjustedColumn, Me.QuantityReturnedColumn, Me.StandardCostColumn, Me.StandardPriceColumn, Me.ItemClassColumn, Me.LongDescriptionColumn})
        Me.dgvConsignmentInventory.DataSource = Me.ConsignmentInventoryBindingSource
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvConsignmentInventory.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvConsignmentInventory.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvConsignmentInventory.Location = New System.Drawing.Point(349, 41)
        Me.dgvConsignmentInventory.Name = "dgvConsignmentInventory"
        Me.dgvConsignmentInventory.ReadOnly = True
        Me.dgvConsignmentInventory.Size = New System.Drawing.Size(781, 645)
        Me.dgvConsignmentInventory.TabIndex = 51
        Me.dgvConsignmentInventory.TabStop = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Warehouse"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "Description"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        Me.ShortDescriptionColumn.ReadOnly = True
        Me.ShortDescriptionColumn.Width = 140
        '
        'QuantityOnHandColumn
        '
        Me.QuantityOnHandColumn.DataPropertyName = "QuantityOnHand"
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        Me.QuantityOnHandColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.QuantityOnHandColumn.HeaderText = "QOH"
        Me.QuantityOnHandColumn.Name = "QuantityOnHandColumn"
        Me.QuantityOnHandColumn.ReadOnly = True
        Me.QuantityOnHandColumn.Width = 65
        '
        'QuantityShippedColumn
        '
        Me.QuantityShippedColumn.DataPropertyName = "QuantityShipped"
        Me.QuantityShippedColumn.HeaderText = "Qty. Shipped"
        Me.QuantityShippedColumn.Name = "QuantityShippedColumn"
        Me.QuantityShippedColumn.ReadOnly = True
        Me.QuantityShippedColumn.Width = 65
        '
        'QuantityBilledColumn
        '
        Me.QuantityBilledColumn.DataPropertyName = "QuantityBilled"
        Me.QuantityBilledColumn.HeaderText = "Qty. Billed"
        Me.QuantityBilledColumn.Name = "QuantityBilledColumn"
        Me.QuantityBilledColumn.ReadOnly = True
        Me.QuantityBilledColumn.Width = 65
        '
        'QuantityAdjustedColumn
        '
        Me.QuantityAdjustedColumn.DataPropertyName = "QuantityAdjusted"
        Me.QuantityAdjustedColumn.HeaderText = "Qty. Adjusted"
        Me.QuantityAdjustedColumn.Name = "QuantityAdjustedColumn"
        Me.QuantityAdjustedColumn.ReadOnly = True
        Me.QuantityAdjustedColumn.Width = 65
        '
        'QuantityReturnedColumn
        '
        Me.QuantityReturnedColumn.DataPropertyName = "QuantityReturned"
        Me.QuantityReturnedColumn.HeaderText = "Qty. Returned"
        Me.QuantityReturnedColumn.Name = "QuantityReturnedColumn"
        Me.QuantityReturnedColumn.ReadOnly = True
        Me.QuantityReturnedColumn.Width = 65
        '
        'StandardCostColumn
        '
        Me.StandardCostColumn.DataPropertyName = "StandardCost"
        DataGridViewCellStyle4.Format = "N4"
        DataGridViewCellStyle4.NullValue = "0"
        Me.StandardCostColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.StandardCostColumn.HeaderText = "Std. Cost"
        Me.StandardCostColumn.Name = "StandardCostColumn"
        Me.StandardCostColumn.ReadOnly = True
        Me.StandardCostColumn.Width = 80
        '
        'StandardPriceColumn
        '
        Me.StandardPriceColumn.DataPropertyName = "StandardPrice"
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = "0"
        Me.StandardPriceColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.StandardPriceColumn.HeaderText = "Std. Price"
        Me.StandardPriceColumn.Name = "StandardPriceColumn"
        Me.StandardPriceColumn.ReadOnly = True
        Me.StandardPriceColumn.Width = 80
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "ItemClass"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.ReadOnly = True
        Me.ItemClassColumn.Visible = False
        '
        'LongDescriptionColumn
        '
        Me.LongDescriptionColumn.DataPropertyName = "LongDescription"
        Me.LongDescriptionColumn.HeaderText = "LongDescription"
        Me.LongDescriptionColumn.Name = "LongDescriptionColumn"
        Me.LongDescriptionColumn.ReadOnly = True
        Me.LongDescriptionColumn.Visible = False
        '
        'ConsignmentInventoryBindingSource
        '
        Me.ConsignmentInventoryBindingSource.DataMember = "ConsignmentInventory"
        Me.ConsignmentInventoryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'gpxVoucherMaintenance
        '
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label15)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label14)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label4)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label5)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label11)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label8)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label10)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label7)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label6)
        Me.gpxVoucherMaintenance.Controls.Add(Me.Label13)
        Me.gpxVoucherMaintenance.Location = New System.Drawing.Point(29, 339)
        Me.gpxVoucherMaintenance.Name = "gpxVoucherMaintenance"
        Me.gpxVoucherMaintenance.Size = New System.Drawing.Size(300, 283)
        Me.gpxVoucherMaintenance.TabIndex = 52
        Me.gpxVoucherMaintenance.TabStop = False
        Me.gpxVoucherMaintenance.Text = "Consignment Warehouse Key"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(16, 172)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(147, 21)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "RCW - Renton"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(16, 103)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(147, 21)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "LSCW - Lake Stevens"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(16, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 21)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "SRL - SRL Industries"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(16, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 21)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "LCW -  Lewisville"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(16, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(147, 21)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "DCW - Downey"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(16, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 21)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "SCW - Seattle"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(16, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(147, 21)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "HCW - Hayward"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(16, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 21)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "PCW - Phoenix"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(16, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 21)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "YCW - Lyndhurst"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(16, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(147, 21)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "BCW - Bessemer"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'ConsignmentInventoryTableAdapter
        '
        Me.ConsignmentInventoryTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkValueAll)
        Me.GroupBox2.Controls.Add(Me.cboValueDivision)
        Me.GroupBox2.Controls.Add(Me.dtpValueDate)
        Me.GroupBox2.Controls.Add(Me.cmdPrintValueReport)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cmdApplyFilter)
        Me.GroupBox2.Controls.Add(Me.cmdValueInventory)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 641)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 170)
        Me.GroupBox2.TabIndex = 53
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Inventory Value Report"
        '
        'chkValueAll
        '
        Me.chkValueAll.AutoSize = True
        Me.chkValueAll.Location = New System.Drawing.Point(107, 87)
        Me.chkValueAll.Name = "chkValueAll"
        Me.chkValueAll.Size = New System.Drawing.Size(100, 17)
        Me.chkValueAll.TabIndex = 58
        Me.chkValueAll.Text = "All Warehouses"
        Me.chkValueAll.UseVisualStyleBackColor = True
        '
        'cboValueDivision
        '
        Me.cboValueDivision.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboValueDivision.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboValueDivision.DataSource = Me.FOBTableBindingSource
        Me.cboValueDivision.DisplayMember = "FOBName"
        Me.cboValueDivision.FormattingEnabled = True
        Me.cboValueDivision.Location = New System.Drawing.Point(107, 57)
        Me.cboValueDivision.Name = "cboValueDivision"
        Me.cboValueDivision.Size = New System.Drawing.Size(172, 21)
        Me.cboValueDivision.TabIndex = 56
        '
        'dtpValueDate
        '
        Me.dtpValueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpValueDate.Location = New System.Drawing.Point(107, 25)
        Me.dtpValueDate.Name = "dtpValueDate"
        Me.dtpValueDate.Size = New System.Drawing.Size(172, 20)
        Me.dtpValueDate.TabIndex = 0
        '
        'cmdPrintValueReport
        '
        Me.cmdPrintValueReport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintValueReport.Location = New System.Drawing.Point(208, 118)
        Me.cmdPrintValueReport.Name = "cmdPrintValueReport"
        Me.cmdPrintValueReport.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintValueReport.TabIndex = 57
        Me.cmdPrintValueReport.Text = "Print"
        Me.cmdPrintValueReport.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "Warehouse"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdApplyFilter
        '
        Me.cmdApplyFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdApplyFilter.Location = New System.Drawing.Point(54, 118)
        Me.cmdApplyFilter.Name = "cmdApplyFilter"
        Me.cmdApplyFilter.Size = New System.Drawing.Size(71, 40)
        Me.cmdApplyFilter.TabIndex = 54
        Me.cmdApplyFilter.Text = "Apply Filter"
        Me.cmdApplyFilter.UseVisualStyleBackColor = True
        '
        'cmdValueInventory
        '
        Me.cmdValueInventory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdValueInventory.Location = New System.Drawing.Point(131, 118)
        Me.cmdValueInventory.Name = "cmdValueInventory"
        Me.cmdValueInventory.Size = New System.Drawing.Size(71, 40)
        Me.cmdValueInventory.TabIndex = 11
        Me.cmdValueInventory.Text = "Value Inventory"
        Me.cmdValueInventory.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Value Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvFIFOValue
        '
        Me.dgvFIFOValue.AllowUserToAddRows = False
        Me.dgvFIFOValue.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFIFOValue.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvFIFOValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFIFOValue.AutoGenerateColumns = False
        Me.dgvFIFOValue.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFIFOValue.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFIFOValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFIFOValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn2, Me.PartNumberColumn2, Me.DescriptionColumn2, Me.QuantityOnHandColumn2, Me.FIFOCostColumn2, Me.FIFOExtendedAmountColumn2, Me.GLAccountColumn2, Me.ValuationDateColumn2})
        Me.dgvFIFOValue.DataSource = Me.InventoryFIFOValuationBindingSource
        Me.dgvFIFOValue.GridColor = System.Drawing.Color.Purple
        Me.dgvFIFOValue.Location = New System.Drawing.Point(349, 41)
        Me.dgvFIFOValue.Name = "dgvFIFOValue"
        Me.dgvFIFOValue.ReadOnly = True
        Me.dgvFIFOValue.Size = New System.Drawing.Size(781, 645)
        Me.dgvFIFOValue.TabIndex = 54
        Me.dgvFIFOValue.Visible = False
        '
        'DivisionIDColumn2
        '
        Me.DivisionIDColumn2.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn2.HeaderText = "Division"
        Me.DivisionIDColumn2.Name = "DivisionIDColumn2"
        Me.DivisionIDColumn2.ReadOnly = True
        Me.DivisionIDColumn2.Width = 70
        '
        'PartNumberColumn2
        '
        Me.PartNumberColumn2.DataPropertyName = "PartNumber"
        Me.PartNumberColumn2.HeaderText = "Part Number"
        Me.PartNumberColumn2.Name = "PartNumberColumn2"
        Me.PartNumberColumn2.ReadOnly = True
        '
        'DescriptionColumn2
        '
        Me.DescriptionColumn2.DataPropertyName = "Description"
        Me.DescriptionColumn2.HeaderText = "Description"
        Me.DescriptionColumn2.Name = "DescriptionColumn2"
        Me.DescriptionColumn2.ReadOnly = True
        '
        'QuantityOnHandColumn2
        '
        Me.QuantityOnHandColumn2.DataPropertyName = "QuantityOnHand"
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = "0"
        Me.QuantityOnHandColumn2.DefaultCellStyle = DataGridViewCellStyle8
        Me.QuantityOnHandColumn2.HeaderText = "QOH"
        Me.QuantityOnHandColumn2.Name = "QuantityOnHandColumn2"
        Me.QuantityOnHandColumn2.ReadOnly = True
        '
        'FIFOCostColumn2
        '
        Me.FIFOCostColumn2.DataPropertyName = "FIFOCost"
        DataGridViewCellStyle9.Format = "N5"
        DataGridViewCellStyle9.NullValue = "0"
        Me.FIFOCostColumn2.DefaultCellStyle = DataGridViewCellStyle9
        Me.FIFOCostColumn2.HeaderText = "FIFO Cost"
        Me.FIFOCostColumn2.Name = "FIFOCostColumn2"
        Me.FIFOCostColumn2.ReadOnly = True
        '
        'FIFOExtendedAmountColumn2
        '
        Me.FIFOExtendedAmountColumn2.DataPropertyName = "FIFOExtendedAmount"
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.FIFOExtendedAmountColumn2.DefaultCellStyle = DataGridViewCellStyle10
        Me.FIFOExtendedAmountColumn2.HeaderText = "FIFO Extended Amount"
        Me.FIFOExtendedAmountColumn2.Name = "FIFOExtendedAmountColumn2"
        Me.FIFOExtendedAmountColumn2.ReadOnly = True
        '
        'GLAccountColumn2
        '
        Me.GLAccountColumn2.DataPropertyName = "GLAccount"
        Me.GLAccountColumn2.HeaderText = "GL Account"
        Me.GLAccountColumn2.Name = "GLAccountColumn2"
        Me.GLAccountColumn2.ReadOnly = True
        '
        'ValuationDateColumn2
        '
        Me.ValuationDateColumn2.DataPropertyName = "ValuationDate"
        Me.ValuationDateColumn2.HeaderText = "Valuation Date"
        Me.ValuationDateColumn2.Name = "ValuationDateColumn2"
        Me.ValuationDateColumn2.ReadOnly = True
        '
        'InventoryFIFOValuationBindingSource
        '
        Me.InventoryFIFOValuationBindingSource.DataMember = "InventoryFIFOValuation"
        Me.InventoryFIFOValuationBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InventoryFIFOValuationTableAdapter
        '
        Me.InventoryFIFOValuationTableAdapter.ClearBeforeFill = True
        '
        'FOBTableTableAdapter
        '
        Me.FOBTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.cmdPrintInventorySteel)
        Me.GroupBox5.Controls.Add(Me.cmdValueInventorySteel)
        Me.GroupBox5.Location = New System.Drawing.Point(349, 695)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(300, 116)
        Me.GroupBox5.TabIndex = 55
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Inventory Steel Value"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(109, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(167, 84)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "To value steel for consignment inventory, first run Inventory Value for the selec" & _
            "ted consignment warehouse (or all), then press the ""Value Steel"" button."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintInventorySteel
        '
        Me.cmdPrintInventorySteel.Location = New System.Drawing.Point(19, 64)
        Me.cmdPrintInventorySteel.Name = "cmdPrintInventorySteel"
        Me.cmdPrintInventorySteel.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintInventorySteel.TabIndex = 18
        Me.cmdPrintInventorySteel.Text = "Print"
        Me.cmdPrintInventorySteel.UseVisualStyleBackColor = True
        '
        'cmdValueInventorySteel
        '
        Me.cmdValueInventorySteel.Location = New System.Drawing.Point(19, 20)
        Me.cmdValueInventorySteel.Name = "cmdValueInventorySteel"
        Me.cmdValueInventorySteel.Size = New System.Drawing.Size(71, 40)
        Me.cmdValueInventorySteel.TabIndex = 13
        Me.cmdValueInventorySteel.Text = "Value Steel"
        Me.cmdValueInventorySteel.UseVisualStyleBackColor = True
        '
        'dgvFIFOSteelValue
        '
        Me.dgvFIFOSteelValue.AllowUserToAddRows = False
        Me.dgvFIFOSteelValue.AllowUserToDeleteRows = False
        Me.dgvFIFOSteelValue.AllowUserToOrderColumns = True
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFIFOSteelValue.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvFIFOSteelValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFIFOSteelValue.AutoGenerateColumns = False
        Me.dgvFIFOSteelValue.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFIFOSteelValue.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFIFOSteelValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFIFOSteelValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumberDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.QuantityOnHandDataGridViewTextBoxColumn, Me.SteelCostUnitDataGridViewTextBoxColumn, Me.SteelCostTotalDataGridViewTextBoxColumn, Me.FOXNumberDataGridViewTextBoxColumn, Me.RMIDDataGridViewTextBoxColumn, Me.SteelCarbonDataGridViewTextBoxColumn, Me.SteelSizeDataGridViewTextBoxColumn, Me.PieceWeightDataGridViewTextBoxColumn, Me.ValuationDateDataGridViewTextBoxColumn})
        Me.dgvFIFOSteelValue.DataSource = Me.InventorySteelValuationBindingSource
        Me.dgvFIFOSteelValue.GridColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvFIFOSteelValue.Location = New System.Drawing.Point(349, 41)
        Me.dgvFIFOSteelValue.Name = "dgvFIFOSteelValue"
        Me.dgvFIFOSteelValue.ReadOnly = True
        Me.dgvFIFOSteelValue.Size = New System.Drawing.Size(781, 645)
        Me.dgvFIFOSteelValue.TabIndex = 56
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part #"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "Division"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'QuantityOnHandDataGridViewTextBoxColumn
        '
        Me.QuantityOnHandDataGridViewTextBoxColumn.DataPropertyName = "QuantityOnHand"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.QuantityOnHandDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.QuantityOnHandDataGridViewTextBoxColumn.HeaderText = "QOH"
        Me.QuantityOnHandDataGridViewTextBoxColumn.Name = "QuantityOnHandDataGridViewTextBoxColumn"
        Me.QuantityOnHandDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SteelCostUnitDataGridViewTextBoxColumn
        '
        Me.SteelCostUnitDataGridViewTextBoxColumn.DataPropertyName = "SteelCostUnit"
        Me.SteelCostUnitDataGridViewTextBoxColumn.HeaderText = "Cost/Lb"
        Me.SteelCostUnitDataGridViewTextBoxColumn.Name = "SteelCostUnitDataGridViewTextBoxColumn"
        Me.SteelCostUnitDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SteelCostTotalDataGridViewTextBoxColumn
        '
        Me.SteelCostTotalDataGridViewTextBoxColumn.DataPropertyName = "SteelCostTotal"
        Me.SteelCostTotalDataGridViewTextBoxColumn.HeaderText = "Ext. Amount"
        Me.SteelCostTotalDataGridViewTextBoxColumn.Name = "SteelCostTotalDataGridViewTextBoxColumn"
        Me.SteelCostTotalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FOXNumberDataGridViewTextBoxColumn
        '
        Me.FOXNumberDataGridViewTextBoxColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberDataGridViewTextBoxColumn.HeaderText = "FOX #"
        Me.FOXNumberDataGridViewTextBoxColumn.Name = "FOXNumberDataGridViewTextBoxColumn"
        Me.FOXNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RMIDDataGridViewTextBoxColumn
        '
        Me.RMIDDataGridViewTextBoxColumn.DataPropertyName = "RMID"
        Me.RMIDDataGridViewTextBoxColumn.HeaderText = "RMID"
        Me.RMIDDataGridViewTextBoxColumn.Name = "RMIDDataGridViewTextBoxColumn"
        Me.RMIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.RMIDDataGridViewTextBoxColumn.Visible = False
        '
        'SteelCarbonDataGridViewTextBoxColumn
        '
        Me.SteelCarbonDataGridViewTextBoxColumn.DataPropertyName = "SteelCarbon"
        Me.SteelCarbonDataGridViewTextBoxColumn.HeaderText = "Carbon/Alloy"
        Me.SteelCarbonDataGridViewTextBoxColumn.Name = "SteelCarbonDataGridViewTextBoxColumn"
        Me.SteelCarbonDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SteelSizeDataGridViewTextBoxColumn
        '
        Me.SteelSizeDataGridViewTextBoxColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeDataGridViewTextBoxColumn.HeaderText = "Size"
        Me.SteelSizeDataGridViewTextBoxColumn.Name = "SteelSizeDataGridViewTextBoxColumn"
        Me.SteelSizeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PieceWeightDataGridViewTextBoxColumn
        '
        Me.PieceWeightDataGridViewTextBoxColumn.DataPropertyName = "PieceWeight"
        Me.PieceWeightDataGridViewTextBoxColumn.HeaderText = "PieceWeight"
        Me.PieceWeightDataGridViewTextBoxColumn.Name = "PieceWeightDataGridViewTextBoxColumn"
        Me.PieceWeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.PieceWeightDataGridViewTextBoxColumn.Visible = False
        '
        'ValuationDateDataGridViewTextBoxColumn
        '
        Me.ValuationDateDataGridViewTextBoxColumn.DataPropertyName = "ValuationDate"
        Me.ValuationDateDataGridViewTextBoxColumn.HeaderText = "Valuation Date"
        Me.ValuationDateDataGridViewTextBoxColumn.Name = "ValuationDateDataGridViewTextBoxColumn"
        Me.ValuationDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.ValuationDateDataGridViewTextBoxColumn.Visible = False
        '
        'InventorySteelValuationBindingSource
        '
        Me.InventorySteelValuationBindingSource.DataMember = "InventorySteelValuation"
        Me.InventorySteelValuationBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InventorySteelValuationTableAdapter
        '
        Me.InventorySteelValuationTableAdapter.ClearBeforeFill = True
        '
        'ViewConsignmentInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpxVoucherMaintenance)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvConsignmentInventory)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvFIFOSteelValue)
        Me.Controls.Add(Me.dgvFIFOValue)
        Me.Name = "ViewConsignmentInventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Consignment Inventory"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOBTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvConsignmentInventory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConsignmentInventoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxVoucherMaintenance.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvFIFOValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryFIFOValuationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgvFIFOSteelValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventorySteelValuationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboWarehouse As System.Windows.Forms.ComboBox
    Friend WithEvents lblFOXNumber As System.Windows.Forms.Label
    Friend WithEvents dgvConsignmentInventory As System.Windows.Forms.DataGridView
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkQOH As System.Windows.Forms.CheckBox
    Friend WithEvents gpxVoucherMaintenance As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents ConsignmentInventoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ConsignmentInventoryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ConsignmentInventoryTableAdapter
    Friend WithEvents chkAllWarehouses As System.Windows.Forms.CheckBox
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboValueDivision As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdApplyFilter As System.Windows.Forms.Button
    Friend WithEvents cmdValueInventory As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpValueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdPrintValueReport As System.Windows.Forms.Button
    Friend WithEvents dgvFIFOValue As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryFIFOValuationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryFIFOValuationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryFIFOValuationTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents FOBTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOBTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOBTableTableAdapter
    Friend WithEvents chkValueAll As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPrintInventorySteel As System.Windows.Forms.Button
    Friend WithEvents cmdValueInventorySteel As System.Windows.Forms.Button
    Friend WithEvents DivisionIDColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIFOCostColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIFOExtendedAmountColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValuationDateColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dgvFIFOSteelValue As System.Windows.Forms.DataGridView
    Friend WithEvents InventorySteelValuationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventorySteelValuationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventorySteelValuationTableAdapter
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostUnitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCarbonDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValuationDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityBilledColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityAdjustedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityReturnedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
