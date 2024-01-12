<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryCosting
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
        Me.SaveChangesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxReturnSearchData = New System.Windows.Forms.GroupBox
        Me.txtNextPieceSold = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTotalBoth = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTotalAssembled = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtQtySTD = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboConsignment = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.dgvInventoryCosting = New System.Windows.Forms.DataGridView
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LowerLimitColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpperLimitColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceLine = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryCostingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventoryCostingTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryCostingTableAdapter
        Me.gpxAddCostTier = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdEnterNewCostTier = New System.Windows.Forms.Button
        Me.cmdClearFields = New System.Windows.Forms.Button
        Me.cboCostDescription = New System.Windows.Forms.ComboBox
        Me.txtCostQuantity = New System.Windows.Forms.TextBox
        Me.txtItemCost = New System.Windows.Forms.TextBox
        Me.dtpCostingDate = New System.Windows.Forms.DateTimePicker
        Me.cboCostingPartNumber = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtCostTierDivision = New System.Windows.Forms.TextBox
        Me.txtCostTierPartNumber = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdViewCostTiers = New System.Windows.Forms.Button
        Me.cmdUpdateCostTiers = New System.Windows.Forms.Button
        Me.gpxRebuildCostTiers = New System.Windows.Forms.GroupBox
        Me.MenuStrip1.SuspendLayout()
        Me.gpxReturnSearchData.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventoryCosting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryCostingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxAddCostTier.SuspendLayout()
        Me.gpxRebuildCostTiers.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveChangesToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveChangesToolStripMenuItem
        '
        Me.SaveChangesToolStripMenuItem.Name = "SaveChangesToolStripMenuItem"
        Me.SaveChangesToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SaveChangesToolStripMenuItem.Text = "Save Changes"
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 14
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxReturnSearchData
        '
        Me.gpxReturnSearchData.Controls.Add(Me.txtNextPieceSold)
        Me.gpxReturnSearchData.Controls.Add(Me.Label14)
        Me.gpxReturnSearchData.Controls.Add(Me.txtTotalBoth)
        Me.gpxReturnSearchData.Controls.Add(Me.Label13)
        Me.gpxReturnSearchData.Controls.Add(Me.txtTotalAssembled)
        Me.gpxReturnSearchData.Controls.Add(Me.Label11)
        Me.gpxReturnSearchData.Controls.Add(Me.txtQtySTD)
        Me.gpxReturnSearchData.Controls.Add(Me.Label6)
        Me.gpxReturnSearchData.Controls.Add(Me.Label12)
        Me.gpxReturnSearchData.Controls.Add(Me.cboConsignment)
        Me.gpxReturnSearchData.Controls.Add(Me.Label4)
        Me.gpxReturnSearchData.Controls.Add(Me.cboPartDescription)
        Me.gpxReturnSearchData.Controls.Add(Me.cboPartNumber)
        Me.gpxReturnSearchData.Controls.Add(Me.cboDivisionID)
        Me.gpxReturnSearchData.Controls.Add(Me.Label3)
        Me.gpxReturnSearchData.Controls.Add(Me.cmdViewByFilters)
        Me.gpxReturnSearchData.Controls.Add(Me.cmdClear)
        Me.gpxReturnSearchData.Controls.Add(Me.Label1)
        Me.gpxReturnSearchData.Location = New System.Drawing.Point(29, 41)
        Me.gpxReturnSearchData.Name = "gpxReturnSearchData"
        Me.gpxReturnSearchData.Size = New System.Drawing.Size(300, 368)
        Me.gpxReturnSearchData.TabIndex = 18
        Me.gpxReturnSearchData.TabStop = False
        Me.gpxReturnSearchData.Text = "View By Filters"
        '
        'txtNextPieceSold
        '
        Me.txtNextPieceSold.BackColor = System.Drawing.Color.White
        Me.txtNextPieceSold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNextPieceSold.ForeColor = System.Drawing.Color.Blue
        Me.txtNextPieceSold.Location = New System.Drawing.Point(119, 263)
        Me.txtNextPieceSold.Name = "txtNextPieceSold"
        Me.txtNextPieceSold.ReadOnly = True
        Me.txtNextPieceSold.Size = New System.Drawing.Size(166, 20)
        Me.txtNextPieceSold.TabIndex = 6
        Me.txtNextPieceSold.TabStop = False
        Me.txtNextPieceSold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(20, 263)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(145, 20)
        Me.Label14.TabIndex = 53
        Me.Label14.Text = "Next Piece Sold"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalBoth
        '
        Me.txtTotalBoth.BackColor = System.Drawing.Color.White
        Me.txtTotalBoth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBoth.ForeColor = System.Drawing.Color.Blue
        Me.txtTotalBoth.Location = New System.Drawing.Point(119, 237)
        Me.txtTotalBoth.Name = "txtTotalBoth"
        Me.txtTotalBoth.ReadOnly = True
        Me.txtTotalBoth.Size = New System.Drawing.Size(166, 20)
        Me.txtTotalBoth.TabIndex = 5
        Me.txtTotalBoth.TabStop = False
        Me.txtTotalBoth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(20, 237)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(145, 20)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "Total Quantity"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalAssembled
        '
        Me.txtTotalAssembled.BackColor = System.Drawing.Color.White
        Me.txtTotalAssembled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAssembled.ForeColor = System.Drawing.Color.Blue
        Me.txtTotalAssembled.Location = New System.Drawing.Point(119, 211)
        Me.txtTotalAssembled.Name = "txtTotalAssembled"
        Me.txtTotalAssembled.ReadOnly = True
        Me.txtTotalAssembled.Size = New System.Drawing.Size(166, 20)
        Me.txtTotalAssembled.TabIndex = 4
        Me.txtTotalAssembled.TabStop = False
        Me.txtTotalAssembled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(20, 211)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(145, 20)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Qty. Assembled"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQtySTD
        '
        Me.txtQtySTD.BackColor = System.Drawing.Color.White
        Me.txtQtySTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtySTD.ForeColor = System.Drawing.Color.Blue
        Me.txtQtySTD.Location = New System.Drawing.Point(119, 185)
        Me.txtQtySTD.Name = "txtQtySTD"
        Me.txtQtySTD.ReadOnly = True
        Me.txtQtySTD.Size = New System.Drawing.Size(166, 20)
        Me.txtQtySTD.TabIndex = 3
        Me.txtQtySTD.TabStop = False
        Me.txtQtySTD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 185)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 20)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Qty. Ship-To-Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(15, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(270, 36)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboConsignment
        '
        Me.cboConsignment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboConsignment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboConsignment.Enabled = False
        Me.cboConsignment.FormattingEnabled = True
        Me.cboConsignment.Items.AddRange(New Object() {"Bessemer", "Downey", "Hayward", "Lake Stevens", "Lewisville", "Lyndhurst", "Phoenix", "Renton", "Seattle", "SRL"})
        Me.cboConsignment.Location = New System.Drawing.Point(119, 289)
        Me.cboConsignment.Name = "cboConsignment"
        Me.cboConsignment.Size = New System.Drawing.Size(166, 21)
        Me.cboConsignment.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 290)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Con. Warehouse"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(20, 156)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboPartDescription.TabIndex = 2
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
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(65, 125)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(220, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(119, 36)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(166, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Part #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(137, 326)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 8
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 326)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'dgvInventoryCosting
        '
        Me.dgvInventoryCosting.AllowUserToAddRows = False
        Me.dgvInventoryCosting.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvInventoryCosting.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventoryCosting.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryCosting.AutoGenerateColumns = False
        Me.dgvInventoryCosting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInventoryCosting.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryCosting.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInventoryCosting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryCosting.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumberColumn, Me.CostingDateColumn, Me.ItemCostColumn, Me.CostQuantityColumn, Me.LowerLimitColumn, Me.UpperLimitColumn, Me.StatusColumn, Me.DivisionIDColumn, Me.TransactionNumberColumn, Me.ReferenceNumber, Me.ReferenceLine})
        Me.dgvInventoryCosting.DataSource = Me.InventoryCostingBindingSource
        Me.dgvInventoryCosting.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInventoryCosting.Location = New System.Drawing.Point(348, 41)
        Me.dgvInventoryCosting.Name = "dgvInventoryCosting"
        Me.dgvInventoryCosting.Size = New System.Drawing.Size(782, 705)
        Me.dgvInventoryCosting.TabIndex = 16
        Me.dgvInventoryCosting.TabStop = False
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'CostingDateColumn
        '
        Me.CostingDateColumn.DataPropertyName = "CostingDate"
        Me.CostingDateColumn.HeaderText = "Date"
        Me.CostingDateColumn.Name = "CostingDateColumn"
        Me.CostingDateColumn.ReadOnly = True
        '
        'ItemCostColumn
        '
        Me.ItemCostColumn.DataPropertyName = "ItemCost"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.ItemCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ItemCostColumn.HeaderText = "Item Cost"
        Me.ItemCostColumn.Name = "ItemCostColumn"
        '
        'CostQuantityColumn
        '
        Me.CostQuantityColumn.DataPropertyName = "CostQuantity"
        DataGridViewCellStyle3.NullValue = "0"
        Me.CostQuantityColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.CostQuantityColumn.HeaderText = "Cost Quantity"
        Me.CostQuantityColumn.Name = "CostQuantityColumn"
        '
        'LowerLimitColumn
        '
        Me.LowerLimitColumn.DataPropertyName = "LowerLimit"
        DataGridViewCellStyle4.NullValue = "0"
        Me.LowerLimitColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.LowerLimitColumn.HeaderText = "Lower Limit"
        Me.LowerLimitColumn.Name = "LowerLimitColumn"
        '
        'UpperLimitColumn
        '
        Me.UpperLimitColumn.DataPropertyName = "UpperLimit"
        DataGridViewCellStyle5.NullValue = "0"
        Me.UpperLimitColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.UpperLimitColumn.HeaderText = "Upper Limit"
        Me.UpperLimitColumn.Name = "UpperLimitColumn"
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "Trans. #"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        '
        'ReferenceNumber
        '
        Me.ReferenceNumber.DataPropertyName = "ReferenceNumber"
        Me.ReferenceNumber.HeaderText = "Ref. #"
        Me.ReferenceNumber.Name = "ReferenceNumber"
        '
        'ReferenceLine
        '
        Me.ReferenceLine.DataPropertyName = "ReferenceLine"
        Me.ReferenceLine.HeaderText = "Ref. Line #"
        Me.ReferenceLine.Name = "ReferenceLine"
        '
        'InventoryCostingBindingSource
        '
        Me.InventoryCostingBindingSource.DataMember = "InventoryCosting"
        Me.InventoryCostingBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InventoryCostingTableAdapter
        '
        Me.InventoryCostingTableAdapter.ClearBeforeFill = True
        '
        'gpxAddCostTier
        '
        Me.gpxAddCostTier.Controls.Add(Me.Label9)
        Me.gpxAddCostTier.Controls.Add(Me.cmdEnterNewCostTier)
        Me.gpxAddCostTier.Controls.Add(Me.cmdClearFields)
        Me.gpxAddCostTier.Controls.Add(Me.cboCostDescription)
        Me.gpxAddCostTier.Controls.Add(Me.txtCostQuantity)
        Me.gpxAddCostTier.Controls.Add(Me.txtItemCost)
        Me.gpxAddCostTier.Controls.Add(Me.dtpCostingDate)
        Me.gpxAddCostTier.Controls.Add(Me.cboCostingPartNumber)
        Me.gpxAddCostTier.Controls.Add(Me.Label8)
        Me.gpxAddCostTier.Controls.Add(Me.Label7)
        Me.gpxAddCostTier.Controls.Add(Me.Label5)
        Me.gpxAddCostTier.Controls.Add(Me.Label2)
        Me.gpxAddCostTier.Location = New System.Drawing.Point(29, 415)
        Me.gpxAddCostTier.Name = "gpxAddCostTier"
        Me.gpxAddCostTier.Size = New System.Drawing.Size(300, 252)
        Me.gpxAddCostTier.TabIndex = 10
        Me.gpxAddCostTier.TabStop = False
        Me.gpxAddCostTier.Text = "Add Cost Tiers  (Admin / Accounting Only)"
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(20, 117)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(265, 35)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "New Cost Tiers will always be added at the end of any existing Cost Tiers."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdEnterNewCostTier
        '
        Me.cmdEnterNewCostTier.Location = New System.Drawing.Point(137, 210)
        Me.cmdEnterNewCostTier.Name = "cmdEnterNewCostTier"
        Me.cmdEnterNewCostTier.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnterNewCostTier.TabIndex = 16
        Me.cmdEnterNewCostTier.Text = "Enter"
        Me.cmdEnterNewCostTier.UseVisualStyleBackColor = True
        '
        'cmdClearFields
        '
        Me.cmdClearFields.Location = New System.Drawing.Point(214, 210)
        Me.cmdClearFields.Name = "cmdClearFields"
        Me.cmdClearFields.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearFields.TabIndex = 17
        Me.cmdClearFields.Text = "Clear"
        Me.cmdClearFields.UseVisualStyleBackColor = True
        '
        'cboCostDescription
        '
        Me.cboCostDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCostDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCostDescription.DataSource = Me.ItemListBindingSource
        Me.cboCostDescription.DisplayMember = "ItemID"
        Me.cboCostDescription.FormattingEnabled = True
        Me.cboCostDescription.Location = New System.Drawing.Point(20, 58)
        Me.cboCostDescription.Name = "cboCostDescription"
        Me.cboCostDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboCostDescription.TabIndex = 12
        '
        'txtCostQuantity
        '
        Me.txtCostQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCostQuantity.Location = New System.Drawing.Point(137, 181)
        Me.txtCostQuantity.Name = "txtCostQuantity"
        Me.txtCostQuantity.Size = New System.Drawing.Size(148, 20)
        Me.txtCostQuantity.TabIndex = 15
        Me.txtCostQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItemCost
        '
        Me.txtItemCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCost.Location = New System.Drawing.Point(137, 155)
        Me.txtItemCost.Name = "txtItemCost"
        Me.txtItemCost.Size = New System.Drawing.Size(148, 20)
        Me.txtItemCost.TabIndex = 14
        Me.txtItemCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpCostingDate
        '
        Me.dtpCostingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCostingDate.Location = New System.Drawing.Point(104, 94)
        Me.dtpCostingDate.Name = "dtpCostingDate"
        Me.dtpCostingDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpCostingDate.TabIndex = 13
        '
        'cboCostingPartNumber
        '
        Me.cboCostingPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCostingPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCostingPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboCostingPartNumber.DisplayMember = "ItemID"
        Me.cboCostingPartNumber.FormattingEnabled = True
        Me.cboCostingPartNumber.Location = New System.Drawing.Point(65, 31)
        Me.cboCostingPartNumber.Name = "cboCostingPartNumber"
        Me.cboCostingPartNumber.Size = New System.Drawing.Size(220, 21)
        Me.cboCostingPartNumber.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(31, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Quantity"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Item Cost"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Costing Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Part #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(419, 774)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(420, 35)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Item Cost may be edited in the datagrid ----   (ADMIN / Accounting Only)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(17, 55)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 23)
        Me.Label17.TabIndex = 70
        Me.Label17.Text = "Division"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCostTierDivision
        '
        Me.txtCostTierDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCostTierDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCostTierDivision.Location = New System.Drawing.Point(181, 61)
        Me.txtCostTierDivision.Name = "txtCostTierDivision"
        Me.txtCostTierDivision.Size = New System.Drawing.Size(106, 20)
        Me.txtCostTierDivision.TabIndex = 69
        '
        'txtCostTierPartNumber
        '
        Me.txtCostTierPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCostTierPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCostTierPartNumber.Location = New System.Drawing.Point(67, 35)
        Me.txtCostTierPartNumber.Name = "txtCostTierPartNumber"
        Me.txtCostTierPartNumber.Size = New System.Drawing.Size(220, 20)
        Me.txtCostTierPartNumber.TabIndex = 67
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(17, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 23)
        Me.Label16.TabIndex = 68
        Me.Label16.Text = "Part #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewCostTiers
        '
        Me.cmdViewCostTiers.Location = New System.Drawing.Point(139, 101)
        Me.cmdViewCostTiers.Name = "cmdViewCostTiers"
        Me.cmdViewCostTiers.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewCostTiers.TabIndex = 65
        Me.cmdViewCostTiers.Text = "View"
        Me.cmdViewCostTiers.UseVisualStyleBackColor = True
        '
        'cmdUpdateCostTiers
        '
        Me.cmdUpdateCostTiers.Location = New System.Drawing.Point(216, 101)
        Me.cmdUpdateCostTiers.Name = "cmdUpdateCostTiers"
        Me.cmdUpdateCostTiers.Size = New System.Drawing.Size(71, 30)
        Me.cmdUpdateCostTiers.TabIndex = 66
        Me.cmdUpdateCostTiers.Text = "Rebuild"
        Me.cmdUpdateCostTiers.UseVisualStyleBackColor = True
        '
        'gpxRebuildCostTiers
        '
        Me.gpxRebuildCostTiers.Controls.Add(Me.txtCostTierPartNumber)
        Me.gpxRebuildCostTiers.Controls.Add(Me.cmdUpdateCostTiers)
        Me.gpxRebuildCostTiers.Controls.Add(Me.cmdViewCostTiers)
        Me.gpxRebuildCostTiers.Controls.Add(Me.txtCostTierDivision)
        Me.gpxRebuildCostTiers.Controls.Add(Me.Label16)
        Me.gpxRebuildCostTiers.Controls.Add(Me.Label17)
        Me.gpxRebuildCostTiers.Location = New System.Drawing.Point(27, 673)
        Me.gpxRebuildCostTiers.Name = "gpxRebuildCostTiers"
        Me.gpxRebuildCostTiers.Size = New System.Drawing.Size(301, 144)
        Me.gpxRebuildCostTiers.TabIndex = 71
        Me.gpxRebuildCostTiers.TabStop = False
        Me.gpxRebuildCostTiers.Text = "Rebuild Cost Tier for a single part"
        '
        'InventoryCosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.gpxRebuildCostTiers)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.gpxAddCostTier)
        Me.Controls.Add(Me.dgvInventoryCosting)
        Me.Controls.Add(Me.gpxReturnSearchData)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InventoryCosting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Cost Tiers"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxReturnSearchData.ResumeLayout(False)
        Me.gpxReturnSearchData.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventoryCosting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryCostingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxAddCostTier.ResumeLayout(False)
        Me.gpxAddCostTier.PerformLayout()
        Me.gpxRebuildCostTiers.ResumeLayout(False)
        Me.gpxRebuildCostTiers.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxReturnSearchData As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents dgvInventoryCosting As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryCostingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryCostingTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryCostingTableAdapter
    Friend WithEvents gpxAddCostTier As System.Windows.Forms.GroupBox
    Friend WithEvents dtpCostingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboCostingPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCostQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txtItemCost As System.Windows.Forms.TextBox
    Friend WithEvents cmdEnterNewCostTier As System.Windows.Forms.Button
    Friend WithEvents cmdClearFields As System.Windows.Forms.Button
    Friend WithEvents cboCostDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PrintReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveChangesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboConsignment As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtQtySTD As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LowerLimitColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpperLimitColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTotalAssembled As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalBoth As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtNextPieceSold As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCostTierDivision As System.Windows.Forms.TextBox
    Friend WithEvents txtCostTierPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdViewCostTiers As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateCostTiers As System.Windows.Forms.Button
    Friend WithEvents gpxRebuildCostTiers As System.Windows.Forms.GroupBox
End Class
