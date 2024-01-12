<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewStockStatusValuation
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
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReOrderWorksheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InventoryUsageReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdReorder = New System.Windows.Forms.Button
        Me.cmdUsage = New System.Windows.Forms.Button
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.StockStatusValuationFinalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.gpxSelectCompany = New System.Windows.Forms.GroupBox
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkOmitEqualQty = New System.Windows.Forms.CheckBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.chkOmit = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdEnterDivision = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvStockStatus = New System.Windows.Forms.DataGridView
        Me.ItemIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValuationQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQuantityShippedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalReceivedQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductionQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorReturnQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerReturnQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCProductionQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyBuildQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenSOQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenPOQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AddValuationQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubtractValuationQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinimumStockDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaximumStockDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockStatusValuationFinalTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StockStatusValuationFinalTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StockStatusValuationFinalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxSelectCompany.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStockStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem, Me.ReOrderWorksheetToolStripMenuItem, Me.InventoryUsageReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
        '
        'ReOrderWorksheetToolStripMenuItem
        '
        Me.ReOrderWorksheetToolStripMenuItem.Name = "ReOrderWorksheetToolStripMenuItem"
        Me.ReOrderWorksheetToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.ReOrderWorksheetToolStripMenuItem.Text = "Re-Order Worksheet"
        '
        'InventoryUsageReportToolStripMenuItem
        '
        Me.InventoryUsageReportToolStripMenuItem.Name = "InventoryUsageReportToolStripMenuItem"
        Me.InventoryUsageReportToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.InventoryUsageReportToolStripMenuItem.Text = "Inventory Usage Report"
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmdReorder)
        Me.GroupBox2.Controls.Add(Me.cmdUsage)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 669)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 142)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "View / Print Reports"
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(16, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(199, 26)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Print Re-Order Worksheet"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(16, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(199, 26)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Print Inventory Shipped / QOH"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdReorder
        '
        Me.cmdReorder.Location = New System.Drawing.Point(217, 87)
        Me.cmdReorder.Name = "cmdReorder"
        Me.cmdReorder.Size = New System.Drawing.Size(71, 40)
        Me.cmdReorder.TabIndex = 7
        Me.cmdReorder.Text = "Re-Order Worksheet"
        Me.cmdReorder.UseVisualStyleBackColor = True
        '
        'cmdUsage
        '
        Me.cmdUsage.Location = New System.Drawing.Point(217, 31)
        Me.cmdUsage.Name = "cmdUsage"
        Me.cmdUsage.Size = New System.Drawing.Size(71, 40)
        Me.cmdUsage.TabIndex = 6
        Me.cmdUsage.Text = "Inventory Usage"
        Me.cmdUsage.UseVisualStyleBackColor = True
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(15, 247)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(269, 21)
        Me.cboPartDescription.TabIndex = 4
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
        'StockStatusValuationFinalBindingSource
        '
        Me.StockStatusValuationFinalBindingSource.DataMember = "StockStatusValuationFinal"
        Me.StockStatusValuationFinalBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 215)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Part #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(58, 214)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(226, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'gpxSelectCompany
        '
        Me.gpxSelectCompany.Controls.Add(Me.cboItemClass)
        Me.gpxSelectCompany.Controls.Add(Me.Label7)
        Me.gpxSelectCompany.Controls.Add(Me.chkOmitEqualQty)
        Me.gpxSelectCompany.Controls.Add(Me.cboDivisionID)
        Me.gpxSelectCompany.Controls.Add(Me.txtTextFilter)
        Me.gpxSelectCompany.Controls.Add(Me.chkOmit)
        Me.gpxSelectCompany.Controls.Add(Me.Label4)
        Me.gpxSelectCompany.Controls.Add(Me.cboPartDescription)
        Me.gpxSelectCompany.Controls.Add(Me.cmdClear)
        Me.gpxSelectCompany.Controls.Add(Me.cmdEnterDivision)
        Me.gpxSelectCompany.Controls.Add(Me.Label1)
        Me.gpxSelectCompany.Controls.Add(Me.cboPartNumber)
        Me.gpxSelectCompany.Controls.Add(Me.Label2)
        Me.gpxSelectCompany.Controls.Add(Me.Label3)
        Me.gpxSelectCompany.Location = New System.Drawing.Point(29, 41)
        Me.gpxSelectCompany.Name = "gpxSelectCompany"
        Me.gpxSelectCompany.Size = New System.Drawing.Size(300, 450)
        Me.gpxSelectCompany.TabIndex = 9
        Me.gpxSelectCompany.TabStop = False
        Me.gpxSelectCompany.Text = "Select Company"
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(82, 304)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(202, 21)
        Me.cboItemClass.TabIndex = 5
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 305)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Item Class"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkOmitEqualQty
        '
        Me.chkOmitEqualQty.AutoSize = True
        Me.chkOmitEqualQty.Location = New System.Drawing.Point(84, 157)
        Me.chkOmitEqualQty.Name = "chkOmitEqualQty"
        Me.chkOmitEqualQty.Size = New System.Drawing.Size(152, 17)
        Me.chkOmitEqualQty.TabIndex = 2
        Me.chkOmitEqualQty.Text = "Where QOH <> Value Qty."
        Me.chkOmitEqualQty.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(82, 65)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(202, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(82, 359)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(202, 20)
        Me.txtTextFilter.TabIndex = 6
        '
        'chkOmit
        '
        Me.chkOmit.AutoSize = True
        Me.chkOmit.Location = New System.Drawing.Point(84, 118)
        Me.chkOmit.Name = "chkOmit"
        Me.chkOmit.Size = New System.Drawing.Size(147, 17)
        Me.chkOmit.TabIndex = 1
        Me.chkOmit.Text = "Omit Items with zero QOH"
        Me.chkOmit.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(68, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(199, 26)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Enter Division ID to see Stock Status"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 403)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdEnterDivision
        '
        Me.cmdEnterDivision.Location = New System.Drawing.Point(136, 403)
        Me.cmdEnterDivision.Name = "cmdEnterDivision"
        Me.cmdEnterDivision.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnterDivision.TabIndex = 7
        Me.cmdEnterDivision.Text = "Enter"
        Me.cmdEnterDivision.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 359)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Text Filter"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 13
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvStockStatus
        '
        Me.dgvStockStatus.AllowUserToAddRows = False
        Me.dgvStockStatus.AllowUserToDeleteRows = False
        Me.dgvStockStatus.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvStockStatus.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStockStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStockStatus.AutoGenerateColumns = False
        Me.dgvStockStatus.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvStockStatus.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvStockStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStockStatus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemIDDataGridViewTextBoxColumn, Me.ShortDescriptionDataGridViewTextBoxColumn, Me.QuantityOnHandDataGridViewTextBoxColumn, Me.ValuationQuantityDataGridViewTextBoxColumn, Me.TotalQuantityShippedDataGridViewTextBoxColumn, Me.TotalReceivedQuantityDataGridViewTextBoxColumn, Me.AdjustmentQuantityDataGridViewTextBoxColumn, Me.ProductionQuantityDataGridViewTextBoxColumn, Me.VendorReturnQuantityDataGridViewTextBoxColumn, Me.CustomerReturnQuantityDataGridViewTextBoxColumn, Me.WCProductionQuantityDataGridViewTextBoxColumn, Me.AssemblyBuildQuantity, Me.OpenSOQuantityDataGridViewTextBoxColumn, Me.OpenPOQuantityDataGridViewTextBoxColumn, Me.AddValuationQuantityDataGridViewTextBoxColumn, Me.SubtractValuationQuantityDataGridViewTextBoxColumn, Me.MinimumStockDataGridViewTextBoxColumn, Me.MaximumStockDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn})
        Me.dgvStockStatus.DataSource = Me.StockStatusValuationFinalBindingSource
        Me.dgvStockStatus.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvStockStatus.Location = New System.Drawing.Point(345, 41)
        Me.dgvStockStatus.Name = "dgvStockStatus"
        Me.dgvStockStatus.Size = New System.Drawing.Size(685, 715)
        Me.dgvStockStatus.TabIndex = 14
        '
        'ItemIDDataGridViewTextBoxColumn
        '
        Me.ItemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID"
        Me.ItemIDDataGridViewTextBoxColumn.HeaderText = "Part Number"
        Me.ItemIDDataGridViewTextBoxColumn.Name = "ItemIDDataGridViewTextBoxColumn"
        '
        'ShortDescriptionDataGridViewTextBoxColumn
        '
        Me.ShortDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.ShortDescriptionDataGridViewTextBoxColumn.Name = "ShortDescriptionDataGridViewTextBoxColumn"
        '
        'QuantityOnHandDataGridViewTextBoxColumn
        '
        Me.QuantityOnHandDataGridViewTextBoxColumn.DataPropertyName = "QuantityOnHand"
        Me.QuantityOnHandDataGridViewTextBoxColumn.HeaderText = "QOH"
        Me.QuantityOnHandDataGridViewTextBoxColumn.Name = "QuantityOnHandDataGridViewTextBoxColumn"
        Me.QuantityOnHandDataGridViewTextBoxColumn.ReadOnly = True
        Me.QuantityOnHandDataGridViewTextBoxColumn.Width = 85
        '
        'ValuationQuantityDataGridViewTextBoxColumn
        '
        Me.ValuationQuantityDataGridViewTextBoxColumn.DataPropertyName = "ValuationQuantity"
        Me.ValuationQuantityDataGridViewTextBoxColumn.HeaderText = "Valuation Qty."
        Me.ValuationQuantityDataGridViewTextBoxColumn.Name = "ValuationQuantityDataGridViewTextBoxColumn"
        Me.ValuationQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.ValuationQuantityDataGridViewTextBoxColumn.Width = 85
        '
        'TotalQuantityShippedDataGridViewTextBoxColumn
        '
        Me.TotalQuantityShippedDataGridViewTextBoxColumn.DataPropertyName = "TotalQuantityShipped"
        Me.TotalQuantityShippedDataGridViewTextBoxColumn.HeaderText = "Shipped Qty."
        Me.TotalQuantityShippedDataGridViewTextBoxColumn.Name = "TotalQuantityShippedDataGridViewTextBoxColumn"
        Me.TotalQuantityShippedDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalQuantityShippedDataGridViewTextBoxColumn.Width = 85
        '
        'TotalReceivedQuantityDataGridViewTextBoxColumn
        '
        Me.TotalReceivedQuantityDataGridViewTextBoxColumn.DataPropertyName = "TotalReceivedQuantity"
        Me.TotalReceivedQuantityDataGridViewTextBoxColumn.HeaderText = "Received Qty."
        Me.TotalReceivedQuantityDataGridViewTextBoxColumn.Name = "TotalReceivedQuantityDataGridViewTextBoxColumn"
        Me.TotalReceivedQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalReceivedQuantityDataGridViewTextBoxColumn.Width = 85
        '
        'AdjustmentQuantityDataGridViewTextBoxColumn
        '
        Me.AdjustmentQuantityDataGridViewTextBoxColumn.DataPropertyName = "AdjustmentQuantity"
        Me.AdjustmentQuantityDataGridViewTextBoxColumn.HeaderText = "Adj. Qty."
        Me.AdjustmentQuantityDataGridViewTextBoxColumn.Name = "AdjustmentQuantityDataGridViewTextBoxColumn"
        Me.AdjustmentQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.AdjustmentQuantityDataGridViewTextBoxColumn.Width = 85
        '
        'ProductionQuantityDataGridViewTextBoxColumn
        '
        Me.ProductionQuantityDataGridViewTextBoxColumn.DataPropertyName = "ProductionQuantity"
        Me.ProductionQuantityDataGridViewTextBoxColumn.HeaderText = "Production Qty."
        Me.ProductionQuantityDataGridViewTextBoxColumn.Name = "ProductionQuantityDataGridViewTextBoxColumn"
        Me.ProductionQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProductionQuantityDataGridViewTextBoxColumn.Width = 85
        '
        'VendorReturnQuantityDataGridViewTextBoxColumn
        '
        Me.VendorReturnQuantityDataGridViewTextBoxColumn.DataPropertyName = "VendorReturnQuantity"
        Me.VendorReturnQuantityDataGridViewTextBoxColumn.HeaderText = "Vendor Return Qty."
        Me.VendorReturnQuantityDataGridViewTextBoxColumn.Name = "VendorReturnQuantityDataGridViewTextBoxColumn"
        Me.VendorReturnQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.VendorReturnQuantityDataGridViewTextBoxColumn.Width = 85
        '
        'CustomerReturnQuantityDataGridViewTextBoxColumn
        '
        Me.CustomerReturnQuantityDataGridViewTextBoxColumn.DataPropertyName = "CustomerReturnQuantity"
        Me.CustomerReturnQuantityDataGridViewTextBoxColumn.HeaderText = "Customer Return Qty."
        Me.CustomerReturnQuantityDataGridViewTextBoxColumn.Name = "CustomerReturnQuantityDataGridViewTextBoxColumn"
        Me.CustomerReturnQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.CustomerReturnQuantityDataGridViewTextBoxColumn.Width = 85
        '
        'WCProductionQuantityDataGridViewTextBoxColumn
        '
        Me.WCProductionQuantityDataGridViewTextBoxColumn.DataPropertyName = "WCProductionQuantity"
        Me.WCProductionQuantityDataGridViewTextBoxColumn.HeaderText = "WC Production Qty."
        Me.WCProductionQuantityDataGridViewTextBoxColumn.Name = "WCProductionQuantityDataGridViewTextBoxColumn"
        Me.WCProductionQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.WCProductionQuantityDataGridViewTextBoxColumn.Width = 85
        '
        'AssemblyBuildQuantity
        '
        Me.AssemblyBuildQuantity.DataPropertyName = "AssemblyBuildQuantity"
        Me.AssemblyBuildQuantity.HeaderText = "Build Qty."
        Me.AssemblyBuildQuantity.Name = "AssemblyBuildQuantity"
        Me.AssemblyBuildQuantity.ReadOnly = True
        '
        'OpenSOQuantityDataGridViewTextBoxColumn
        '
        Me.OpenSOQuantityDataGridViewTextBoxColumn.DataPropertyName = "OpenSOQuantity"
        Me.OpenSOQuantityDataGridViewTextBoxColumn.HeaderText = "Open SO Qty."
        Me.OpenSOQuantityDataGridViewTextBoxColumn.Name = "OpenSOQuantityDataGridViewTextBoxColumn"
        Me.OpenSOQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.OpenSOQuantityDataGridViewTextBoxColumn.Width = 85
        '
        'OpenPOQuantityDataGridViewTextBoxColumn
        '
        Me.OpenPOQuantityDataGridViewTextBoxColumn.DataPropertyName = "OpenPOQuantity"
        Me.OpenPOQuantityDataGridViewTextBoxColumn.HeaderText = "Open PO Qty."
        Me.OpenPOQuantityDataGridViewTextBoxColumn.Name = "OpenPOQuantityDataGridViewTextBoxColumn"
        Me.OpenPOQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.OpenPOQuantityDataGridViewTextBoxColumn.Width = 85
        '
        'AddValuationQuantityDataGridViewTextBoxColumn
        '
        Me.AddValuationQuantityDataGridViewTextBoxColumn.DataPropertyName = "AddValuationQuantity"
        Me.AddValuationQuantityDataGridViewTextBoxColumn.HeaderText = "AddValuationQuantity"
        Me.AddValuationQuantityDataGridViewTextBoxColumn.Name = "AddValuationQuantityDataGridViewTextBoxColumn"
        Me.AddValuationQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.AddValuationQuantityDataGridViewTextBoxColumn.Visible = False
        '
        'SubtractValuationQuantityDataGridViewTextBoxColumn
        '
        Me.SubtractValuationQuantityDataGridViewTextBoxColumn.DataPropertyName = "SubtractValuationQuantity"
        Me.SubtractValuationQuantityDataGridViewTextBoxColumn.HeaderText = "SubtractValuationQuantity"
        Me.SubtractValuationQuantityDataGridViewTextBoxColumn.Name = "SubtractValuationQuantityDataGridViewTextBoxColumn"
        Me.SubtractValuationQuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.SubtractValuationQuantityDataGridViewTextBoxColumn.Visible = False
        '
        'MinimumStockDataGridViewTextBoxColumn
        '
        Me.MinimumStockDataGridViewTextBoxColumn.DataPropertyName = "MinimumStock"
        Me.MinimumStockDataGridViewTextBoxColumn.HeaderText = "MinimumStock"
        Me.MinimumStockDataGridViewTextBoxColumn.Name = "MinimumStockDataGridViewTextBoxColumn"
        Me.MinimumStockDataGridViewTextBoxColumn.ReadOnly = True
        Me.MinimumStockDataGridViewTextBoxColumn.Visible = False
        '
        'MaximumStockDataGridViewTextBoxColumn
        '
        Me.MaximumStockDataGridViewTextBoxColumn.DataPropertyName = "MaximumStock"
        Me.MaximumStockDataGridViewTextBoxColumn.HeaderText = "MaximumStock"
        Me.MaximumStockDataGridViewTextBoxColumn.Name = "MaximumStockDataGridViewTextBoxColumn"
        Me.MaximumStockDataGridViewTextBoxColumn.ReadOnly = True
        Me.MaximumStockDataGridViewTextBoxColumn.Visible = False
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'StockStatusValuationFinalTableAdapter
        '
        Me.StockStatusValuationFinalTableAdapter.ClearBeforeFill = True
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
        'ViewStockStatusValuation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvStockStatus)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpxSelectCompany)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewStockStatusValuation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Stock Status w/Valuation"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StockStatusValuationFinalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxSelectCompany.ResumeLayout(False)
        Me.gpxSelectCompany.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStockStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdReorder As System.Windows.Forms.Button
    Friend WithEvents cmdUsage As System.Windows.Forms.Button
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents gpxSelectCompany As System.Windows.Forms.GroupBox
    Friend WithEvents chkOmit As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdEnterDivision As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvStockStatus As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents StockStatusValuationFinalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StockStatusValuationFinalTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StockStatusValuationFinalTableAdapter
    Friend WithEvents TransferQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeginningBalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReOrderWorksheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventoryUsageReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValuationQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQuantityShippedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalReceivedQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorReturnQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerReturnQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCProductionQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyBuildQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenSOQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenPOQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddValuationQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubtractValuationQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinimumStockDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaximumStockDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents chkOmitEqualQty As System.Windows.Forms.CheckBox
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
End Class
