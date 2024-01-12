<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInventoryValueByFilter
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtClassTextFilter = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTextFilter5 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTextFilter4 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTextFilter3 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTextFilter2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTextFilter1 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.chkOmit = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.dgvADMInventoryTotals = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenSOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalShipQuantityPendingColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastYearShippedToDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinimumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaximumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalReceivedQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenPOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorReturnQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerReturnQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductionQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCProductionQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyBuildQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ADMInventoryTotalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ADMInventoryTotalTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ADMInventoryTotalTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdValueInventory = New System.Windows.Forms.Button
        Me.cmdPrintValueReport = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.dgvFIFOCurrentValue = New System.Windows.Forms.DataGridView
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FIFOCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FilterFieldDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryFIFOCurrentValueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventoryFIFOCurrentValueTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryFIFOCurrentValueTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvADMInventoryTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADMInventoryTotalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvFIFOCurrentValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryFIFOCurrentValueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtClassTextFilter)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtTextFilter5)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtTextFilter4)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtTextFilter3)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtTextFilter2)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtTextFilter1)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.cboPartNumber)
        Me.GroupBox3.Controls.Add(Me.cboPartDescription)
        Me.GroupBox3.Controls.Add(Me.chkOmit)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cmdClear)
        Me.GroupBox3.Controls.Add(Me.cmdViewByFilters)
        Me.GroupBox3.Controls.Add(Me.cboDivisionID)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cboItemClass)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 653)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "View By Filters"
        '
        'txtClassTextFilter
        '
        Me.txtClassTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClassTextFilter.Location = New System.Drawing.Point(98, 273)
        Me.txtClassTextFilter.Name = "txtClassTextFilter"
        Me.txtClassTextFilter.Size = New System.Drawing.Size(190, 20)
        Me.txtClassTextFilter.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(22, 273)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Class Filter"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(19, 334)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(269, 38)
        Me.Label13.TabIndex = 60
        Me.Label13.Text = "Use any or all of the text filters. These filters sort by the part short descript" & _
            "ion and part number."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter5
        '
        Me.txtTextFilter5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter5.Location = New System.Drawing.Point(98, 547)
        Me.txtTextFilter5.Name = "txtTextFilter5"
        Me.txtTextFilter5.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter5.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(19, 547)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Text Filter #5"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter4
        '
        Me.txtTextFilter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter4.Location = New System.Drawing.Point(98, 506)
        Me.txtTextFilter4.Name = "txtTextFilter4"
        Me.txtTextFilter4.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter4.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(19, 506)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Text Filter #4"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter3
        '
        Me.txtTextFilter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter3.Location = New System.Drawing.Point(98, 465)
        Me.txtTextFilter3.Name = "txtTextFilter3"
        Me.txtTextFilter3.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter3.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(19, 465)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Text Filter #3"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter2
        '
        Me.txtTextFilter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter2.Location = New System.Drawing.Point(98, 424)
        Me.txtTextFilter2.Name = "txtTextFilter2"
        Me.txtTextFilter2.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter2.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 424)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Text Filter #2"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter1
        '
        Me.txtTextFilter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter1.Location = New System.Drawing.Point(98, 383)
        Me.txtTextFilter1.Name = "txtTextFilter1"
        Me.txtTextFilter1.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter1.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 383)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Text Filter #1"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(21, 68)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(267, 40)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(64, 149)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(224, 21)
        Me.cboPartNumber.TabIndex = 2
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(19, 182)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(269, 21)
        Me.cboPartDescription.TabIndex = 3
        '
        'chkOmit
        '
        Me.chkOmit.AutoSize = True
        Me.chkOmit.Location = New System.Drawing.Point(22, 111)
        Me.chkOmit.Name = "chkOmit"
        Me.chkOmit.Size = New System.Drawing.Size(147, 17)
        Me.chkOmit.TabIndex = 1
        Me.chkOmit.Text = "Omit Items with zero QOH"
        Me.chkOmit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Part #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(217, 605)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(139, 605)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 11
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(92, 34)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(196, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(98, 234)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(190, 21)
        Me.cboItemClass.TabIndex = 4
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 235)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Item Class"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvADMInventoryTotals
        '
        Me.dgvADMInventoryTotals.AllowUserToAddRows = False
        Me.dgvADMInventoryTotals.AllowUserToDeleteRows = False
        Me.dgvADMInventoryTotals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvADMInventoryTotals.AutoGenerateColumns = False
        Me.dgvADMInventoryTotals.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvADMInventoryTotals.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvADMInventoryTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvADMInventoryTotals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.ItemIDColumn, Me.ShortDescriptionColumn, Me.QuantityOnHandColumn, Me.OpenSOQuantityColumn, Me.TotalShipQuantityPendingColumn, Me.LastYearShippedToDateColumn, Me.MinimumStockColumn, Me.MaximumStockColumn, Me.ItemClassColumn, Me.TotalQuantityShippedColumn, Me.TotalReceivedQuantityColumn, Me.OpenPOQuantityColumn, Me.AdjustmentQuantityColumn, Me.VendorReturnQuantityColumn, Me.CustomerReturnQuantityColumn, Me.ProductionQuantityColumn, Me.WCProductionQuantityColumn, Me.AssemblyBuildQuantityColumn, Me.StandardCostColumn, Me.StandardPriceColumn})
        Me.dgvADMInventoryTotals.DataSource = Me.ADMInventoryTotalBindingSource
        Me.dgvADMInventoryTotals.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvADMInventoryTotals.Location = New System.Drawing.Point(347, 41)
        Me.dgvADMInventoryTotals.Name = "dgvADMInventoryTotals"
        Me.dgvADMInventoryTotals.Size = New System.Drawing.Size(783, 713)
        Me.dgvADMInventoryTotals.TabIndex = 6
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "Part #"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "Description"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        Me.ShortDescriptionColumn.Width = 150
        '
        'QuantityOnHandColumn
        '
        Me.QuantityOnHandColumn.DataPropertyName = "QuantityOnHand"
        Me.QuantityOnHandColumn.HeaderText = "QOH"
        Me.QuantityOnHandColumn.Name = "QuantityOnHandColumn"
        Me.QuantityOnHandColumn.ReadOnly = True
        Me.QuantityOnHandColumn.Width = 80
        '
        'OpenSOQuantityColumn
        '
        Me.OpenSOQuantityColumn.DataPropertyName = "OpenSOQuantity"
        Me.OpenSOQuantityColumn.HeaderText = "Committed Qty"
        Me.OpenSOQuantityColumn.Name = "OpenSOQuantityColumn"
        Me.OpenSOQuantityColumn.ReadOnly = True
        Me.OpenSOQuantityColumn.Width = 80
        '
        'TotalShipQuantityPendingColumn
        '
        Me.TotalShipQuantityPendingColumn.DataPropertyName = "TotalShipQuantityPending"
        Me.TotalShipQuantityPendingColumn.HeaderText = "Qty Pending"
        Me.TotalShipQuantityPendingColumn.Name = "TotalShipQuantityPendingColumn"
        Me.TotalShipQuantityPendingColumn.ReadOnly = True
        Me.TotalShipQuantityPendingColumn.Width = 80
        '
        'LastYearShippedToDateColumn
        '
        Me.LastYearShippedToDateColumn.DataPropertyName = "LastYearShippedToDate"
        Me.LastYearShippedToDateColumn.HeaderText = "Sold (Last Year)"
        Me.LastYearShippedToDateColumn.Name = "LastYearShippedToDateColumn"
        Me.LastYearShippedToDateColumn.ReadOnly = True
        Me.LastYearShippedToDateColumn.Width = 80
        '
        'MinimumStockColumn
        '
        Me.MinimumStockColumn.DataPropertyName = "MinimumStock"
        Me.MinimumStockColumn.HeaderText = "Min Stock"
        Me.MinimumStockColumn.Name = "MinimumStockColumn"
        Me.MinimumStockColumn.ReadOnly = True
        Me.MinimumStockColumn.Width = 80
        '
        'MaximumStockColumn
        '
        Me.MaximumStockColumn.DataPropertyName = "MaximumStock"
        Me.MaximumStockColumn.HeaderText = "Max Stock"
        Me.MaximumStockColumn.Name = "MaximumStockColumn"
        Me.MaximumStockColumn.ReadOnly = True
        Me.MaximumStockColumn.Width = 80
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        '
        'TotalQuantityShippedColumn
        '
        Me.TotalQuantityShippedColumn.DataPropertyName = "TotalQuantityShipped"
        Me.TotalQuantityShippedColumn.HeaderText = "TotalQuantityShipped"
        Me.TotalQuantityShippedColumn.Name = "TotalQuantityShippedColumn"
        Me.TotalQuantityShippedColumn.ReadOnly = True
        Me.TotalQuantityShippedColumn.Visible = False
        '
        'TotalReceivedQuantityColumn
        '
        Me.TotalReceivedQuantityColumn.DataPropertyName = "TotalReceivedQuantity"
        Me.TotalReceivedQuantityColumn.HeaderText = "TotalReceivedQuantity"
        Me.TotalReceivedQuantityColumn.Name = "TotalReceivedQuantityColumn"
        Me.TotalReceivedQuantityColumn.ReadOnly = True
        Me.TotalReceivedQuantityColumn.Visible = False
        '
        'OpenPOQuantityColumn
        '
        Me.OpenPOQuantityColumn.DataPropertyName = "OpenPOQuantity"
        Me.OpenPOQuantityColumn.HeaderText = "OpenPOQuantity"
        Me.OpenPOQuantityColumn.Name = "OpenPOQuantityColumn"
        Me.OpenPOQuantityColumn.ReadOnly = True
        Me.OpenPOQuantityColumn.Visible = False
        '
        'AdjustmentQuantityColumn
        '
        Me.AdjustmentQuantityColumn.DataPropertyName = "AdjustmentQuantity"
        Me.AdjustmentQuantityColumn.HeaderText = "AdjustmentQuantity"
        Me.AdjustmentQuantityColumn.Name = "AdjustmentQuantityColumn"
        Me.AdjustmentQuantityColumn.ReadOnly = True
        Me.AdjustmentQuantityColumn.Visible = False
        '
        'VendorReturnQuantityColumn
        '
        Me.VendorReturnQuantityColumn.DataPropertyName = "VendorReturnQuantity"
        Me.VendorReturnQuantityColumn.HeaderText = "VendorReturnQuantity"
        Me.VendorReturnQuantityColumn.Name = "VendorReturnQuantityColumn"
        Me.VendorReturnQuantityColumn.ReadOnly = True
        Me.VendorReturnQuantityColumn.Visible = False
        '
        'CustomerReturnQuantityColumn
        '
        Me.CustomerReturnQuantityColumn.DataPropertyName = "CustomerReturnQuantity"
        Me.CustomerReturnQuantityColumn.HeaderText = "CustomerReturnQuantity"
        Me.CustomerReturnQuantityColumn.Name = "CustomerReturnQuantityColumn"
        Me.CustomerReturnQuantityColumn.ReadOnly = True
        Me.CustomerReturnQuantityColumn.Visible = False
        '
        'ProductionQuantityColumn
        '
        Me.ProductionQuantityColumn.DataPropertyName = "ProductionQuantity"
        Me.ProductionQuantityColumn.HeaderText = "ProductionQuantity"
        Me.ProductionQuantityColumn.Name = "ProductionQuantityColumn"
        Me.ProductionQuantityColumn.ReadOnly = True
        Me.ProductionQuantityColumn.Visible = False
        '
        'WCProductionQuantityColumn
        '
        Me.WCProductionQuantityColumn.DataPropertyName = "WCProductionQuantity"
        Me.WCProductionQuantityColumn.HeaderText = "WCProductionQuantity"
        Me.WCProductionQuantityColumn.Name = "WCProductionQuantityColumn"
        Me.WCProductionQuantityColumn.ReadOnly = True
        Me.WCProductionQuantityColumn.Visible = False
        '
        'AssemblyBuildQuantityColumn
        '
        Me.AssemblyBuildQuantityColumn.DataPropertyName = "AssemblyBuildQuantity"
        Me.AssemblyBuildQuantityColumn.HeaderText = "AssemblyBuildQuantity"
        Me.AssemblyBuildQuantityColumn.Name = "AssemblyBuildQuantityColumn"
        Me.AssemblyBuildQuantityColumn.ReadOnly = True
        Me.AssemblyBuildQuantityColumn.Visible = False
        '
        'StandardCostColumn
        '
        Me.StandardCostColumn.DataPropertyName = "StandardCost"
        Me.StandardCostColumn.HeaderText = "StandardCost"
        Me.StandardCostColumn.Name = "StandardCostColumn"
        Me.StandardCostColumn.Visible = False
        '
        'StandardPriceColumn
        '
        Me.StandardPriceColumn.DataPropertyName = "StandardPrice"
        Me.StandardPriceColumn.HeaderText = "StandardPrice"
        Me.StandardPriceColumn.Name = "StandardPriceColumn"
        Me.StandardPriceColumn.Visible = False
        '
        'ADMInventoryTotalBindingSource
        '
        Me.ADMInventoryTotalBindingSource.DataMember = "ADMInventoryTotal"
        Me.ADMInventoryTotalBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ADMInventoryTotalTableAdapter
        '
        Me.ADMInventoryTotalTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmdValueInventory)
        Me.GroupBox1.Controls.Add(Me.cmdPrintValueReport)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 700)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(299, 111)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Value Inventory"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(35, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(237, 24)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Value inventory based on filters used above."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdValueInventory
        '
        Me.cmdValueInventory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdValueInventory.ForeColor = System.Drawing.Color.Blue
        Me.cmdValueInventory.Location = New System.Drawing.Point(51, 54)
        Me.cmdValueInventory.Name = "cmdValueInventory"
        Me.cmdValueInventory.Size = New System.Drawing.Size(71, 40)
        Me.cmdValueInventory.TabIndex = 14
        Me.cmdValueInventory.Text = "Value Inventory"
        Me.cmdValueInventory.UseVisualStyleBackColor = True
        '
        'cmdPrintValueReport
        '
        Me.cmdPrintValueReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintValueReport.ForeColor = System.Drawing.Color.Blue
        Me.cmdPrintValueReport.Location = New System.Drawing.Point(184, 54)
        Me.cmdPrintValueReport.Name = "cmdPrintValueReport"
        Me.cmdPrintValueReport.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintValueReport.TabIndex = 15
        Me.cmdPrintValueReport.Text = "Print Value Report"
        Me.cmdPrintValueReport.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 16
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 17
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'dgvFIFOCurrentValue
        '
        Me.dgvFIFOCurrentValue.AllowUserToAddRows = False
        Me.dgvFIFOCurrentValue.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFIFOCurrentValue.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFIFOCurrentValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFIFOCurrentValue.AutoGenerateColumns = False
        Me.dgvFIFOCurrentValue.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFIFOCurrentValue.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFIFOCurrentValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFIFOCurrentValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumberDataGridViewTextBoxColumn, Me.PartDescriptionDataGridViewTextBoxColumn, Me.QuantityOnHandDataGridViewTextBoxColumn, Me.FIFOCostDataGridViewTextBoxColumn, Me.FIFOExtendedAmountDataGridViewTextBoxColumn, Me.ItemClassDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.FilterFieldDataGridViewTextBoxColumn})
        Me.dgvFIFOCurrentValue.DataSource = Me.InventoryFIFOCurrentValueBindingSource
        Me.dgvFIFOCurrentValue.GridColor = System.Drawing.Color.Red
        Me.dgvFIFOCurrentValue.Location = New System.Drawing.Point(347, 41)
        Me.dgvFIFOCurrentValue.Name = "dgvFIFOCurrentValue"
        Me.dgvFIFOCurrentValue.Size = New System.Drawing.Size(783, 713)
        Me.dgvFIFOCurrentValue.TabIndex = 24
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part Number"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.Width = 120
        '
        'PartDescriptionDataGridViewTextBoxColumn
        '
        Me.PartDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.PartDescriptionDataGridViewTextBoxColumn.Name = "PartDescriptionDataGridViewTextBoxColumn"
        Me.PartDescriptionDataGridViewTextBoxColumn.Width = 150
        '
        'QuantityOnHandDataGridViewTextBoxColumn
        '
        Me.QuantityOnHandDataGridViewTextBoxColumn.DataPropertyName = "QuantityOnHand"
        Me.QuantityOnHandDataGridViewTextBoxColumn.HeaderText = "QOH"
        Me.QuantityOnHandDataGridViewTextBoxColumn.Name = "QuantityOnHandDataGridViewTextBoxColumn"
        Me.QuantityOnHandDataGridViewTextBoxColumn.Width = 90
        '
        'FIFOCostDataGridViewTextBoxColumn
        '
        Me.FIFOCostDataGridViewTextBoxColumn.DataPropertyName = "FIFOCost"
        DataGridViewCellStyle2.Format = "N5"
        DataGridViewCellStyle2.NullValue = "0"
        Me.FIFOCostDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.FIFOCostDataGridViewTextBoxColumn.HeaderText = "FIFO Cost"
        Me.FIFOCostDataGridViewTextBoxColumn.Name = "FIFOCostDataGridViewTextBoxColumn"
        Me.FIFOCostDataGridViewTextBoxColumn.Width = 90
        '
        'FIFOExtendedAmountDataGridViewTextBoxColumn
        '
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn.DataPropertyName = "FIFOExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn.HeaderText = "Extended Amount"
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn.Name = "FIFOExtendedAmountDataGridViewTextBoxColumn"
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn.Width = 90
        '
        'ItemClassDataGridViewTextBoxColumn
        '
        Me.ItemClassDataGridViewTextBoxColumn.DataPropertyName = "ItemClass"
        Me.ItemClassDataGridViewTextBoxColumn.HeaderText = "Item Class"
        Me.ItemClassDataGridViewTextBoxColumn.Name = "ItemClassDataGridViewTextBoxColumn"
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'FilterFieldDataGridViewTextBoxColumn
        '
        Me.FilterFieldDataGridViewTextBoxColumn.DataPropertyName = "FilterField"
        Me.FilterFieldDataGridViewTextBoxColumn.HeaderText = "FilterField"
        Me.FilterFieldDataGridViewTextBoxColumn.Name = "FilterFieldDataGridViewTextBoxColumn"
        Me.FilterFieldDataGridViewTextBoxColumn.Visible = False
        '
        'InventoryFIFOCurrentValueBindingSource
        '
        Me.InventoryFIFOCurrentValueBindingSource.DataMember = "InventoryFIFOCurrentValue"
        Me.InventoryFIFOCurrentValueBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InventoryFIFOCurrentValueTableAdapter
        '
        Me.InventoryFIFOCurrentValueTableAdapter.ClearBeforeFill = True
        '
        'ViewInventoryValueByFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvFIFOCurrentValue)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvADMInventoryTotals)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewInventoryValueByFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Value"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvADMInventoryTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADMInventoryTotalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvFIFOCurrentValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryFIFOCurrentValueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter5 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter4 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents chkOmit As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvADMInventoryTotals As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ADMInventoryTotalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ADMInventoryTotalTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ADMInventoryTotalTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtClassTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdValueInventory As System.Windows.Forms.Button
    Friend WithEvents cmdPrintValueReport As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents dgvFIFOCurrentValue As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryFIFOCurrentValueBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryFIFOCurrentValueTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryFIFOCurrentValueTableAdapter
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenSOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalShipQuantityPendingColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastYearShippedToDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinimumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaximumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalReceivedQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenPOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorReturnQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerReturnQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCProductionQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyBuildQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeginningBalanceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIFOCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIFOExtendedAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilterFieldDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
