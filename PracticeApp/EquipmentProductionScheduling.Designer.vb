<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentProductionScheduling
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
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdLoadDatagrid = New System.Windows.Forms.Button
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvEquipmentScheduling = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TWEQOHColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TWEUsageColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MonthShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TWEPOQtyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenSOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastYearShippedToDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinimumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaximumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalShipQuantityPendingColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ADMInventoryTotalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ADMInventoryTotalTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ADMInventoryTotalTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrintListing = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEquipmentScheduling, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADMInventoryTotalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdLoadDatagrid)
        Me.GroupBox1.Controls.Add(Me.cboItemClass)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 693)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(342, 118)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Load By Item Class"
        '
        'cmdLoadDatagrid
        '
        Me.cmdLoadDatagrid.Location = New System.Drawing.Point(246, 70)
        Me.cmdLoadDatagrid.Name = "cmdLoadDatagrid"
        Me.cmdLoadDatagrid.Size = New System.Drawing.Size(71, 30)
        Me.cmdLoadDatagrid.TabIndex = 2
        Me.cmdLoadDatagrid.Text = "Load"
        Me.cmdLoadDatagrid.UseVisualStyleBackColor = True
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(107, 34)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(210, 21)
        Me.cboItemClass.TabIndex = 0
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
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Item Class"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvEquipmentScheduling
        '
        Me.dgvEquipmentScheduling.AllowUserToAddRows = False
        Me.dgvEquipmentScheduling.AllowUserToDeleteRows = False
        Me.dgvEquipmentScheduling.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEquipmentScheduling.AutoGenerateColumns = False
        Me.dgvEquipmentScheduling.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvEquipmentScheduling.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvEquipmentScheduling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEquipmentScheduling.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.FOXNumberColumn, Me.ItemIDColumn, Me.ShortDescriptionColumn, Me.QuantityOnHandColumn, Me.TWEQOHColumn, Me.TWEUsageColumn, Me.MonthShippedColumn, Me.AssemblyQuantityColumn, Me.TWEPOQtyColumn, Me.OpenSOQuantityColumn, Me.LastYearShippedToDateColumn, Me.MinimumStockColumn, Me.MaximumStockColumn, Me.PieceWeightColumn, Me.ItemClassColumn, Me.TotalShipQuantityPendingColumn})
        Me.dgvEquipmentScheduling.DataSource = Me.ADMInventoryTotalBindingSource
        Me.dgvEquipmentScheduling.GridColor = System.Drawing.Color.Purple
        Me.dgvEquipmentScheduling.Location = New System.Drawing.Point(29, 41)
        Me.dgvEquipmentScheduling.Name = "dgvEquipmentScheduling"
        Me.dgvEquipmentScheduling.Size = New System.Drawing.Size(1101, 646)
        Me.dgvEquipmentScheduling.TabIndex = 3
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.Width = 80
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "Part #"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.Width = 120
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "Description"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        Me.ShortDescriptionColumn.Width = 170
        '
        'QuantityOnHandColumn
        '
        Me.QuantityOnHandColumn.DataPropertyName = "QuantityOnHand"
        Me.QuantityOnHandColumn.HeaderText = "TWD QOH"
        Me.QuantityOnHandColumn.Name = "QuantityOnHandColumn"
        Me.QuantityOnHandColumn.ReadOnly = True
        Me.QuantityOnHandColumn.Width = 80
        '
        'TWEQOHColumn
        '
        Me.TWEQOHColumn.HeaderText = "TWE QOH"
        Me.TWEQOHColumn.Name = "TWEQOHColumn"
        Me.TWEQOHColumn.Width = 80
        '
        'TWEUsageColumn
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TWEUsageColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.TWEUsageColumn.HeaderText = "Usage (Last Month)"
        Me.TWEUsageColumn.Name = "TWEUsageColumn"
        Me.TWEUsageColumn.Width = 80
        '
        'MonthShippedColumn
        '
        Me.MonthShippedColumn.HeaderText = "Shipped (Last Month)"
        Me.MonthShippedColumn.Name = "MonthShippedColumn"
        Me.MonthShippedColumn.Width = 80
        '
        'AssemblyQuantityColumn
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.AssemblyQuantityColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.AssemblyQuantityColumn.HeaderText = "Assembly Qty (Last Month)"
        Me.AssemblyQuantityColumn.Name = "AssemblyQuantityColumn"
        Me.AssemblyQuantityColumn.Width = 80
        '
        'TWEPOQtyColumn
        '
        Me.TWEPOQtyColumn.HeaderText = "Open PO Qty"
        Me.TWEPOQtyColumn.Name = "TWEPOQtyColumn"
        Me.TWEPOQtyColumn.Width = 80
        '
        'OpenSOQuantityColumn
        '
        Me.OpenSOQuantityColumn.DataPropertyName = "OpenSOQuantity"
        Me.OpenSOQuantityColumn.HeaderText = "Open SO Qty"
        Me.OpenSOQuantityColumn.Name = "OpenSOQuantityColumn"
        Me.OpenSOQuantityColumn.ReadOnly = True
        Me.OpenSOQuantityColumn.Width = 80
        '
        'LastYearShippedToDateColumn
        '
        Me.LastYearShippedToDateColumn.DataPropertyName = "LastYearShippedToDate"
        Me.LastYearShippedToDateColumn.HeaderText = "Shipped (Last Year)"
        Me.LastYearShippedToDateColumn.Name = "LastYearShippedToDateColumn"
        Me.LastYearShippedToDateColumn.ReadOnly = True
        Me.LastYearShippedToDateColumn.Width = 80
        '
        'MinimumStockColumn
        '
        Me.MinimumStockColumn.DataPropertyName = "MinimumStock"
        Me.MinimumStockColumn.HeaderText = "MIN Stock"
        Me.MinimumStockColumn.Name = "MinimumStockColumn"
        Me.MinimumStockColumn.ReadOnly = True
        Me.MinimumStockColumn.Width = 80
        '
        'MaximumStockColumn
        '
        Me.MaximumStockColumn.DataPropertyName = "MaximumStock"
        Me.MaximumStockColumn.HeaderText = "MAX Stock"
        Me.MaximumStockColumn.Name = "MaximumStockColumn"
        Me.MaximumStockColumn.ReadOnly = True
        Me.MaximumStockColumn.Width = 80
        '
        'PieceWeightColumn
        '
        Me.PieceWeightColumn.DataPropertyName = "PieceWeight"
        Me.PieceWeightColumn.HeaderText = "Piece Weight"
        Me.PieceWeightColumn.Name = "PieceWeightColumn"
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.Visible = False
        '
        'TotalShipQuantityPendingColumn
        '
        Me.TotalShipQuantityPendingColumn.DataPropertyName = "TotalShipQuantityPending"
        Me.TotalShipQuantityPendingColumn.HeaderText = "Ship Qty Pending"
        Me.TotalShipQuantityPendingColumn.Name = "TotalShipQuantityPendingColumn"
        Me.TotalShipQuantityPendingColumn.ReadOnly = True
        Me.TotalShipQuantityPendingColumn.Visible = False
        Me.TotalShipQuantityPendingColumn.Width = 80
        '
        'ADMInventoryTotalBindingSource
        '
        Me.ADMInventoryTotalBindingSource.DataMember = "ADMInventoryTotal"
        Me.ADMInventoryTotalBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(947, 708)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(183, 21)
        Me.cboDivisionID.TabIndex = 4
        Me.cboDivisionID.Visible = False
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ADMInventoryTotalTableAdapter
        '
        Me.ADMInventoryTotalTableAdapter.ClearBeforeFill = True
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
        'cmdPrintListing
        '
        Me.cmdPrintListing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintListing.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrintListing.Name = "cmdPrintListing"
        Me.cmdPrintListing.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintListing.TabIndex = 5
        Me.cmdPrintListing.Text = "Print Listing"
        Me.cmdPrintListing.UseVisualStyleBackColor = True
        '
        'EquipmentProductionScheduling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdPrintListing)
        Me.Controls.Add(Me.cboDivisionID)
        Me.Controls.Add(Me.dgvEquipmentScheduling)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "EquipmentProductionScheduling"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Equipment Production Scheduling"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEquipmentScheduling, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADMInventoryTotalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvEquipmentScheduling As System.Windows.Forms.DataGridView
    Friend WithEvents cmdLoadDatagrid As System.Windows.Forms.Button
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ADMInventoryTotalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ADMInventoryTotalTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ADMInventoryTotalTableAdapter
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TWEQOHColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TWEUsageColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonthShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TWEPOQtyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenSOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastYearShippedToDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinimumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaximumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalShipQuantityPendingColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrintListing As System.Windows.Forms.Button
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
