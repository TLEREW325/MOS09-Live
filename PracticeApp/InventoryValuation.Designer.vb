<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryValuation
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
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseDivisionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BCWValuationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DCWValuationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HCWValuationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LCWValuationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PCWValuationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SCWValuationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.YCWValuationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ValuationByGLSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ValuationByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxDateSelect = New System.Windows.Forms.GroupBox
        Me.dtpValuationDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdValueInventory = New System.Windows.Forms.Button
        Me.cmdAddFilter = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.dgvInventoryTransactions = New System.Windows.Forms.DataGridView
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionMathColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryTransactionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventoryTransactionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryTransactionTableTableAdapter
        Me.dgvInventoryValuation = New System.Windows.Forms.DataGridView
        Me.VSDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VSItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VSShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VSLongDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VSSumQuantityAddColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VSSumQuantitySubtractColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VSNetQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VSSumCostAddColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VSSumCostSubtractColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VSNetCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AverageCost = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryValuationSummaryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventoryValuationSummaryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryValuationSummaryTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtTotalUnits = New System.Windows.Forms.TextBox
        Me.txtInventoryTotal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdPrintByGL = New System.Windows.Forms.Button
        Me.cmdShowFIFOCosting = New System.Windows.Forms.Button
        Me.cmdValueFIFO = New System.Windows.Forms.Button
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtFIFOQuantity = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.pbFIFOBar = New System.Windows.Forms.ProgressBar
        Me.txtFIFOTotal = New System.Windows.Forms.TextBox
        Me.cmdPrintFIFO = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgvFIFOInventory = New System.Windows.Forms.DataGridView
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FIFOCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLAccountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValuationDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryFIFOValuationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventoryFIFOValuationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryFIFOValuationTableAdapter
        Me.cmdViewInventoryValuation = New System.Windows.Forms.Button
        Me.cmdViewFIFOValuation = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pbWeldStudBar = New System.Windows.Forms.ProgressBar
        Me.cmdPrintWeldStuds = New System.Windows.Forms.Button
        Me.txtHeadedStuds = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNonHeadedStuds = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdValueWeldStuds = New System.Windows.Forms.Button
        Me.txtDebar = New System.Windows.Forms.TextBox
        Me.cmdShowWeldStuds = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTotalWeldStuds = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.pbInventoryValue = New System.Windows.Forms.ProgressBar
        Me.dgvInventoryTotals = New System.Windows.Forms.DataGridView
        Me.ITItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITQuantityOnHandColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITOpenSOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITOpenPOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITTotalShipQuantityPendingColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITLastYearShippedToDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITAdjustmentQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITVendorReturnQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITCustomerReturnQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITProductionQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITWCProductionQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITAssemblyBuildQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITStandardCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITStandardPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITMaximumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITMinimumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITTotalReceivedQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ITTotalQuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ADMInventoryTotalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ADMInventoryTotalTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ADMInventoryTotalTableAdapter
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdGetPartValue = New System.Windows.Forms.Button
        Me.txtPartQOH = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtPartValue = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.pbSteelBar = New System.Windows.Forms.ProgressBar
        Me.cmdPrintInventorySteel = New System.Windows.Forms.Button
        Me.cmdValueInventorySteel = New System.Windows.Forms.Button
        Me.cmdShowInventorySteel = New System.Windows.Forms.Button
        Me.dgvInventorySteelValue = New System.Windows.Forms.DataGridView
        Me.PartNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCarbonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostUnitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValuationDateDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventorySteelValuationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventorySteelValuationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventorySteelValuationTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxDateSelect.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventoryTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventoryValuation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryValuationSummaryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvFIFOInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryFIFOValuationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvInventoryTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADMInventoryTotalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvInventorySteelValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventorySteelValuationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseDivisionToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'CloseDivisionToolStripMenuItem
        '
        Me.CloseDivisionToolStripMenuItem.Name = "CloseDivisionToolStripMenuItem"
        Me.CloseDivisionToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.CloseDivisionToolStripMenuItem.Text = "Close Division"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BCWValuationToolStripMenuItem, Me.DCWValuationToolStripMenuItem, Me.HCWValuationToolStripMenuItem, Me.LCWValuationToolStripMenuItem, Me.PCWValuationToolStripMenuItem, Me.SCWValuationToolStripMenuItem, Me.YCWValuationToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'BCWValuationToolStripMenuItem
        '
        Me.BCWValuationToolStripMenuItem.Name = "BCWValuationToolStripMenuItem"
        Me.BCWValuationToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.BCWValuationToolStripMenuItem.Text = "BCW Valuation"
        '
        'DCWValuationToolStripMenuItem
        '
        Me.DCWValuationToolStripMenuItem.Name = "DCWValuationToolStripMenuItem"
        Me.DCWValuationToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.DCWValuationToolStripMenuItem.Text = "DCW Valuation"
        '
        'HCWValuationToolStripMenuItem
        '
        Me.HCWValuationToolStripMenuItem.Name = "HCWValuationToolStripMenuItem"
        Me.HCWValuationToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.HCWValuationToolStripMenuItem.Text = "HCW Valuation"
        '
        'LCWValuationToolStripMenuItem
        '
        Me.LCWValuationToolStripMenuItem.Name = "LCWValuationToolStripMenuItem"
        Me.LCWValuationToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.LCWValuationToolStripMenuItem.Text = "LCW Valuation"
        '
        'PCWValuationToolStripMenuItem
        '
        Me.PCWValuationToolStripMenuItem.Name = "PCWValuationToolStripMenuItem"
        Me.PCWValuationToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.PCWValuationToolStripMenuItem.Text = "PCW Valuation"
        '
        'SCWValuationToolStripMenuItem
        '
        Me.SCWValuationToolStripMenuItem.Name = "SCWValuationToolStripMenuItem"
        Me.SCWValuationToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.SCWValuationToolStripMenuItem.Text = "SCW Valuation"
        '
        'YCWValuationToolStripMenuItem
        '
        Me.YCWValuationToolStripMenuItem.Name = "YCWValuationToolStripMenuItem"
        Me.YCWValuationToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.YCWValuationToolStripMenuItem.Text = "YCW Valuation"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ValuationByGLSummaryToolStripMenuItem, Me.ValuationByToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ValuationByGLSummaryToolStripMenuItem
        '
        Me.ValuationByGLSummaryToolStripMenuItem.Name = "ValuationByGLSummaryToolStripMenuItem"
        Me.ValuationByGLSummaryToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ValuationByGLSummaryToolStripMenuItem.Text = "Valuation By GL Summary"
        '
        'ValuationByToolStripMenuItem
        '
        Me.ValuationByToolStripMenuItem.Name = "ValuationByToolStripMenuItem"
        Me.ValuationByToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ValuationByToolStripMenuItem.Text = "Valuation By FIFO Cost"
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
        'gpxDateSelect
        '
        Me.gpxDateSelect.Controls.Add(Me.dtpValuationDate)
        Me.gpxDateSelect.Controls.Add(Me.Label1)
        Me.gpxDateSelect.Controls.Add(Me.cboDivisionID)
        Me.gpxDateSelect.Controls.Add(Me.Label2)
        Me.gpxDateSelect.Location = New System.Drawing.Point(29, 41)
        Me.gpxDateSelect.Name = "gpxDateSelect"
        Me.gpxDateSelect.Size = New System.Drawing.Size(300, 93)
        Me.gpxDateSelect.TabIndex = 0
        Me.gpxDateSelect.TabStop = False
        Me.gpxDateSelect.Text = "Select Valuation Date and Division"
        '
        'dtpValuationDate
        '
        Me.dtpValuationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpValuationDate.Location = New System.Drawing.Point(109, 61)
        Me.dtpValuationDate.Name = "dtpValuationDate"
        Me.dtpValuationDate.Size = New System.Drawing.Size(172, 20)
        Me.dtpValuationDate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Valuation Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(109, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(172, 21)
        Me.cboDivisionID.TabIndex = 1
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Division ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdValueInventory
        '
        Me.cmdValueInventory.Location = New System.Drawing.Point(119, 35)
        Me.cmdValueInventory.Name = "cmdValueInventory"
        Me.cmdValueInventory.Size = New System.Drawing.Size(71, 40)
        Me.cmdValueInventory.TabIndex = 12
        Me.cmdValueInventory.Text = "Value Inventory"
        Me.cmdValueInventory.UseVisualStyleBackColor = True
        '
        'cmdAddFilter
        '
        Me.cmdAddFilter.Location = New System.Drawing.Point(42, 35)
        Me.cmdAddFilter.Name = "cmdAddFilter"
        Me.cmdAddFilter.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddFilter.TabIndex = 0
        Me.cmdAddFilter.Text = "Apply Filter"
        Me.cmdAddFilter.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvInventoryTransactions
        '
        Me.dgvInventoryTransactions.AllowUserToAddRows = False
        Me.dgvInventoryTransactions.AutoGenerateColumns = False
        Me.dgvInventoryTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransactionNumberColumn, Me.TransactionDateColumn, Me.TransactionTypeColumn, Me.TransactionTypeNumberColumn, Me.TransactionTypeLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.ItemCostColumn, Me.ExtendedCostColumn, Me.ItemPriceColumn, Me.ExtendedAmountColumn, Me.DivisionIDColumn, Me.TransactionMathColumn, Me.GLAccountColumn})
        Me.dgvInventoryTransactions.DataSource = Me.InventoryTransactionTableBindingSource
        Me.dgvInventoryTransactions.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInventoryTransactions.Location = New System.Drawing.Point(453, 119)
        Me.dgvInventoryTransactions.Name = "dgvInventoryTransactions"
        Me.dgvInventoryTransactions.Size = New System.Drawing.Size(514, 126)
        Me.dgvInventoryTransactions.TabIndex = 2
        Me.dgvInventoryTransactions.Visible = False
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "TransactionNumber"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.Visible = False
        '
        'TransactionDateColumn
        '
        Me.TransactionDateColumn.DataPropertyName = "TransactionDate"
        Me.TransactionDateColumn.HeaderText = "Date"
        Me.TransactionDateColumn.Name = "TransactionDateColumn"
        Me.TransactionDateColumn.Width = 80
        '
        'TransactionTypeColumn
        '
        Me.TransactionTypeColumn.DataPropertyName = "TransactionType"
        Me.TransactionTypeColumn.HeaderText = "Type"
        Me.TransactionTypeColumn.Name = "TransactionTypeColumn"
        Me.TransactionTypeColumn.Visible = False
        '
        'TransactionTypeNumberColumn
        '
        Me.TransactionTypeNumberColumn.DataPropertyName = "TransactionTypeNumber"
        Me.TransactionTypeNumberColumn.HeaderText = "TransactionTypeNumber"
        Me.TransactionTypeNumberColumn.Name = "TransactionTypeNumberColumn"
        Me.TransactionTypeNumberColumn.Visible = False
        '
        'TransactionTypeLineNumberColumn
        '
        Me.TransactionTypeLineNumberColumn.DataPropertyName = "TransactionTypeLineNumber"
        Me.TransactionTypeLineNumberColumn.HeaderText = "TransactionTypeLineNumber"
        Me.TransactionTypeLineNumberColumn.Name = "TransactionTypeLineNumberColumn"
        Me.TransactionTypeLineNumberColumn.Visible = False
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle33.Format = "N2"
        DataGridViewCellStyle33.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle33
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 80
        '
        'ItemCostColumn
        '
        Me.ItemCostColumn.DataPropertyName = "ItemCost"
        Me.ItemCostColumn.HeaderText = "Item Cost"
        Me.ItemCostColumn.Name = "ItemCostColumn"
        Me.ItemCostColumn.Width = 80
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        Me.ExtendedCostColumn.HeaderText = "Extended Cost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        Me.ExtendedCostColumn.Width = 80
        '
        'ItemPriceColumn
        '
        Me.ItemPriceColumn.DataPropertyName = "ItemPrice"
        Me.ItemPriceColumn.HeaderText = "ItemPrice"
        Me.ItemPriceColumn.Name = "ItemPriceColumn"
        Me.ItemPriceColumn.Visible = False
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "ExtendedAmount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'TransactionMathColumn
        '
        Me.TransactionMathColumn.DataPropertyName = "TransactionMath"
        Me.TransactionMathColumn.HeaderText = "TransactionMath"
        Me.TransactionMathColumn.Name = "TransactionMathColumn"
        Me.TransactionMathColumn.Visible = False
        '
        'GLAccountColumn
        '
        Me.GLAccountColumn.DataPropertyName = "GLAccount"
        Me.GLAccountColumn.HeaderText = "GLAccount"
        Me.GLAccountColumn.Name = "GLAccountColumn"
        '
        'InventoryTransactionTableBindingSource
        '
        Me.InventoryTransactionTableBindingSource.DataMember = "InventoryTransactionTable"
        Me.InventoryTransactionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InventoryTransactionTableTableAdapter
        '
        Me.InventoryTransactionTableTableAdapter.ClearBeforeFill = True
        '
        'dgvInventoryValuation
        '
        Me.dgvInventoryValuation.AllowUserToAddRows = False
        Me.dgvInventoryValuation.AllowUserToDeleteRows = False
        Me.dgvInventoryValuation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryValuation.AutoGenerateColumns = False
        Me.dgvInventoryValuation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInventoryValuation.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryValuation.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInventoryValuation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryValuation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VSDivisionIDColumn, Me.VSItemIDColumn, Me.VSShortDescriptionColumn, Me.VSLongDescriptionColumn, Me.VSSumQuantityAddColumn, Me.VSSumQuantitySubtractColumn, Me.VSNetQuantityColumn, Me.VSSumCostAddColumn, Me.VSSumCostSubtractColumn, Me.VSNetCostColumn, Me.AverageCost})
        Me.dgvInventoryValuation.DataSource = Me.InventoryValuationSummaryBindingSource
        Me.dgvInventoryValuation.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInventoryValuation.Location = New System.Drawing.Point(354, 41)
        Me.dgvInventoryValuation.Name = "dgvInventoryValuation"
        Me.dgvInventoryValuation.Size = New System.Drawing.Size(776, 639)
        Me.dgvInventoryValuation.TabIndex = 3
        '
        'VSDivisionIDColumn
        '
        Me.VSDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.VSDivisionIDColumn.HeaderText = "DivisionID"
        Me.VSDivisionIDColumn.Name = "VSDivisionIDColumn"
        Me.VSDivisionIDColumn.Visible = False
        '
        'VSItemIDColumn
        '
        Me.VSItemIDColumn.DataPropertyName = "ItemID"
        Me.VSItemIDColumn.HeaderText = "Part Number"
        Me.VSItemIDColumn.Name = "VSItemIDColumn"
        '
        'VSShortDescriptionColumn
        '
        Me.VSShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.VSShortDescriptionColumn.HeaderText = "Short Description"
        Me.VSShortDescriptionColumn.Name = "VSShortDescriptionColumn"
        '
        'VSLongDescriptionColumn
        '
        Me.VSLongDescriptionColumn.DataPropertyName = "LongDescription"
        Me.VSLongDescriptionColumn.HeaderText = "Long Description"
        Me.VSLongDescriptionColumn.Name = "VSLongDescriptionColumn"
        Me.VSLongDescriptionColumn.Visible = False
        '
        'VSSumQuantityAddColumn
        '
        Me.VSSumQuantityAddColumn.DataPropertyName = "SumQuantityAdd"
        Me.VSSumQuantityAddColumn.HeaderText = "SumQuantityAdd"
        Me.VSSumQuantityAddColumn.Name = "VSSumQuantityAddColumn"
        Me.VSSumQuantityAddColumn.ReadOnly = True
        Me.VSSumQuantityAddColumn.Visible = False
        '
        'VSSumQuantitySubtractColumn
        '
        Me.VSSumQuantitySubtractColumn.DataPropertyName = "SumQuantitySubtract"
        Me.VSSumQuantitySubtractColumn.HeaderText = "SumQuantitySubtract"
        Me.VSSumQuantitySubtractColumn.Name = "VSSumQuantitySubtractColumn"
        Me.VSSumQuantitySubtractColumn.ReadOnly = True
        Me.VSSumQuantitySubtractColumn.Visible = False
        '
        'VSNetQuantityColumn
        '
        Me.VSNetQuantityColumn.DataPropertyName = "NetQuantity"
        DataGridViewCellStyle34.Format = "N2"
        DataGridViewCellStyle34.NullValue = "0"
        Me.VSNetQuantityColumn.DefaultCellStyle = DataGridViewCellStyle34
        Me.VSNetQuantityColumn.HeaderText = "Net Quantity"
        Me.VSNetQuantityColumn.Name = "VSNetQuantityColumn"
        Me.VSNetQuantityColumn.ReadOnly = True
        '
        'VSSumCostAddColumn
        '
        Me.VSSumCostAddColumn.DataPropertyName = "SumCostAdd"
        Me.VSSumCostAddColumn.HeaderText = "SumCostAdd"
        Me.VSSumCostAddColumn.Name = "VSSumCostAddColumn"
        Me.VSSumCostAddColumn.ReadOnly = True
        Me.VSSumCostAddColumn.Visible = False
        '
        'VSSumCostSubtractColumn
        '
        Me.VSSumCostSubtractColumn.DataPropertyName = "SumCostSubtract"
        Me.VSSumCostSubtractColumn.HeaderText = "SumCostSubtract"
        Me.VSSumCostSubtractColumn.Name = "VSSumCostSubtractColumn"
        Me.VSSumCostSubtractColumn.ReadOnly = True
        Me.VSSumCostSubtractColumn.Visible = False
        '
        'VSNetCostColumn
        '
        Me.VSNetCostColumn.DataPropertyName = "NetCost"
        DataGridViewCellStyle35.Format = "N2"
        DataGridViewCellStyle35.NullValue = "0"
        Me.VSNetCostColumn.DefaultCellStyle = DataGridViewCellStyle35
        Me.VSNetCostColumn.HeaderText = "Net Cost"
        Me.VSNetCostColumn.Name = "VSNetCostColumn"
        Me.VSNetCostColumn.ReadOnly = True
        '
        'AverageCost
        '
        Me.AverageCost.DataPropertyName = "AverageCost"
        DataGridViewCellStyle36.Format = "N4"
        DataGridViewCellStyle36.NullValue = "0"
        Me.AverageCost.DefaultCellStyle = DataGridViewCellStyle36
        Me.AverageCost.HeaderText = "Average Cost"
        Me.AverageCost.Name = "AverageCost"
        Me.AverageCost.ReadOnly = True
        '
        'InventoryValuationSummaryBindingSource
        '
        Me.InventoryValuationSummaryBindingSource.DataMember = "InventoryValuationSummary"
        Me.InventoryValuationSummaryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InventoryValuationSummaryTableAdapter
        '
        Me.InventoryValuationSummaryTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 770)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 29
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 770)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 30
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtTotalUnits
        '
        Me.txtTotalUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalUnits.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalUnits.Location = New System.Drawing.Point(131, 117)
        Me.txtTotalUnits.Name = "txtTotalUnits"
        Me.txtTotalUnits.Size = New System.Drawing.Size(150, 20)
        Me.txtTotalUnits.TabIndex = 12
        Me.txtTotalUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInventoryTotal
        '
        Me.txtInventoryTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInventoryTotal.Location = New System.Drawing.Point(131, 143)
        Me.txtInventoryTotal.Name = "txtInventoryTotal"
        Me.txtInventoryTotal.Size = New System.Drawing.Size(150, 20)
        Me.txtInventoryTotal.TabIndex = 0
        Me.txtInventoryTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Inventory Total ($)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Inventory Total (Units)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintByGL
        '
        Me.cmdPrintByGL.Location = New System.Drawing.Point(196, 35)
        Me.cmdPrintByGL.Name = "cmdPrintByGL"
        Me.cmdPrintByGL.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintByGL.TabIndex = 7
        Me.cmdPrintByGL.Text = "Print"
        Me.cmdPrintByGL.UseVisualStyleBackColor = True
        '
        'cmdShowFIFOCosting
        '
        Me.cmdShowFIFOCosting.Location = New System.Drawing.Point(42, 29)
        Me.cmdShowFIFOCosting.Name = "cmdShowFIFOCosting"
        Me.cmdShowFIFOCosting.Size = New System.Drawing.Size(71, 40)
        Me.cmdShowFIFOCosting.TabIndex = 10
        Me.cmdShowFIFOCosting.Text = "Apply Filter"
        Me.cmdShowFIFOCosting.UseVisualStyleBackColor = True
        '
        'cmdValueFIFO
        '
        Me.cmdValueFIFO.Location = New System.Drawing.Point(119, 29)
        Me.cmdValueFIFO.Name = "cmdValueFIFO"
        Me.cmdValueFIFO.Size = New System.Drawing.Size(71, 40)
        Me.cmdValueFIFO.TabIndex = 11
        Me.cmdValueFIFO.Text = "Value Inventory"
        Me.cmdValueFIFO.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFIFOQuantity)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.pbFIFOBar)
        Me.GroupBox2.Controls.Add(Me.txtFIFOTotal)
        Me.GroupBox2.Controls.Add(Me.cmdPrintFIFO)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cmdValueFIFO)
        Me.GroupBox2.Controls.Add(Me.cmdShowFIFOCosting)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 368)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 214)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FIFO Inventory Valuation"
        '
        'txtFIFOQuantity
        '
        Me.txtFIFOQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFIFOQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIFOQuantity.Location = New System.Drawing.Point(131, 130)
        Me.txtFIFOQuantity.Name = "txtFIFOQuantity"
        Me.txtFIFOQuantity.Size = New System.Drawing.Size(150, 20)
        Me.txtFIFOQuantity.TabIndex = 13
        Me.txtFIFOQuantity.TabStop = False
        Me.txtFIFOQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Inventory Total (Units)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbFIFOBar
        '
        Me.pbFIFOBar.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pbFIFOBar.ForeColor = System.Drawing.Color.Lime
        Me.pbFIFOBar.Location = New System.Drawing.Point(42, 84)
        Me.pbFIFOBar.Name = "pbFIFOBar"
        Me.pbFIFOBar.Size = New System.Drawing.Size(225, 11)
        Me.pbFIFOBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbFIFOBar.TabIndex = 20
        Me.pbFIFOBar.Visible = False
        '
        'txtFIFOTotal
        '
        Me.txtFIFOTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFIFOTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIFOTotal.Location = New System.Drawing.Point(131, 156)
        Me.txtFIFOTotal.Name = "txtFIFOTotal"
        Me.txtFIFOTotal.Size = New System.Drawing.Size(150, 20)
        Me.txtFIFOTotal.TabIndex = 14
        Me.txtFIFOTotal.TabStop = False
        Me.txtFIFOTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdPrintFIFO
        '
        Me.cmdPrintFIFO.Location = New System.Drawing.Point(196, 29)
        Me.cmdPrintFIFO.Name = "cmdPrintFIFO"
        Me.cmdPrintFIFO.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintFIFO.TabIndex = 12
        Me.cmdPrintFIFO.Text = "Print"
        Me.cmdPrintFIFO.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 20)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Inventory Total ($)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvFIFOInventory
        '
        Me.dgvFIFOInventory.AllowUserToAddRows = False
        Me.dgvFIFOInventory.AllowUserToDeleteRows = False
        Me.dgvFIFOInventory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFIFOInventory.AutoGenerateColumns = False
        Me.dgvFIFOInventory.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFIFOInventory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFIFOInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFIFOInventory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumberDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.QuantityOnHandDataGridViewTextBoxColumn, Me.FIFOCostDataGridViewTextBoxColumn, Me.FIFOExtendedAmountDataGridViewTextBoxColumn, Me.GLAccountDataGridViewTextBoxColumn, Me.ValuationDateDataGridViewTextBoxColumn})
        Me.dgvFIFOInventory.DataSource = Me.InventoryFIFOValuationBindingSource
        Me.dgvFIFOInventory.Location = New System.Drawing.Point(354, 41)
        Me.dgvFIFOInventory.Name = "dgvFIFOInventory"
        Me.dgvFIFOInventory.ReadOnly = True
        Me.dgvFIFOInventory.Size = New System.Drawing.Size(776, 639)
        Me.dgvFIFOInventory.TabIndex = 15
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part Number"
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
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'QuantityOnHandDataGridViewTextBoxColumn
        '
        Me.QuantityOnHandDataGridViewTextBoxColumn.DataPropertyName = "QuantityOnHand"
        Me.QuantityOnHandDataGridViewTextBoxColumn.HeaderText = "QOH"
        Me.QuantityOnHandDataGridViewTextBoxColumn.Name = "QuantityOnHandDataGridViewTextBoxColumn"
        Me.QuantityOnHandDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FIFOCostDataGridViewTextBoxColumn
        '
        Me.FIFOCostDataGridViewTextBoxColumn.DataPropertyName = "FIFOCost"
        DataGridViewCellStyle37.Format = "N5"
        DataGridViewCellStyle37.NullValue = "0"
        Me.FIFOCostDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle37
        Me.FIFOCostDataGridViewTextBoxColumn.HeaderText = "FIFO Cost"
        Me.FIFOCostDataGridViewTextBoxColumn.Name = "FIFOCostDataGridViewTextBoxColumn"
        Me.FIFOCostDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FIFOExtendedAmountDataGridViewTextBoxColumn
        '
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn.DataPropertyName = "FIFOExtendedAmount"
        DataGridViewCellStyle38.Format = "N2"
        DataGridViewCellStyle38.NullValue = "0"
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle38
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn.HeaderText = "Inventory Value"
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn.Name = "FIFOExtendedAmountDataGridViewTextBoxColumn"
        Me.FIFOExtendedAmountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GLAccountDataGridViewTextBoxColumn
        '
        Me.GLAccountDataGridViewTextBoxColumn.DataPropertyName = "GLAccount"
        Me.GLAccountDataGridViewTextBoxColumn.HeaderText = "GL Account"
        Me.GLAccountDataGridViewTextBoxColumn.Name = "GLAccountDataGridViewTextBoxColumn"
        Me.GLAccountDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ValuationDateDataGridViewTextBoxColumn
        '
        Me.ValuationDateDataGridViewTextBoxColumn.DataPropertyName = "ValuationDate"
        Me.ValuationDateDataGridViewTextBoxColumn.HeaderText = "ValuationDate"
        Me.ValuationDateDataGridViewTextBoxColumn.Name = "ValuationDateDataGridViewTextBoxColumn"
        Me.ValuationDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.ValuationDateDataGridViewTextBoxColumn.Visible = False
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
        'cmdViewInventoryValuation
        '
        Me.cmdViewInventoryValuation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewInventoryValuation.ForeColor = System.Drawing.Color.Blue
        Me.cmdViewInventoryValuation.Location = New System.Drawing.Point(786, 771)
        Me.cmdViewInventoryValuation.Name = "cmdViewInventoryValuation"
        Me.cmdViewInventoryValuation.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewInventoryValuation.TabIndex = 27
        Me.cmdViewInventoryValuation.Text = "Inventory Valuation"
        Me.cmdViewInventoryValuation.UseVisualStyleBackColor = True
        '
        'cmdViewFIFOValuation
        '
        Me.cmdViewFIFOValuation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewFIFOValuation.ForeColor = System.Drawing.Color.Blue
        Me.cmdViewFIFOValuation.Location = New System.Drawing.Point(863, 771)
        Me.cmdViewFIFOValuation.Name = "cmdViewFIFOValuation"
        Me.cmdViewFIFOValuation.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewFIFOValuation.TabIndex = 28
        Me.cmdViewFIFOValuation.Text = "FIFO Valuation"
        Me.cmdViewFIFOValuation.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pbWeldStudBar)
        Me.GroupBox1.Controls.Add(Me.cmdPrintWeldStuds)
        Me.GroupBox1.Controls.Add(Me.txtHeadedStuds)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtNonHeadedStuds)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmdValueWeldStuds)
        Me.GroupBox1.Controls.Add(Me.txtDebar)
        Me.GroupBox1.Controls.Add(Me.cmdShowWeldStuds)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtTotalWeldStuds)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 600)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 208)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Value Weld Studs"
        '
        'pbWeldStudBar
        '
        Me.pbWeldStudBar.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pbWeldStudBar.ForeColor = System.Drawing.Color.Lime
        Me.pbWeldStudBar.Location = New System.Drawing.Point(42, 80)
        Me.pbWeldStudBar.Name = "pbWeldStudBar"
        Me.pbWeldStudBar.Size = New System.Drawing.Size(225, 11)
        Me.pbWeldStudBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbWeldStudBar.TabIndex = 28
        Me.pbWeldStudBar.Visible = False
        '
        'cmdPrintWeldStuds
        '
        Me.cmdPrintWeldStuds.Location = New System.Drawing.Point(196, 25)
        Me.cmdPrintWeldStuds.Name = "cmdPrintWeldStuds"
        Me.cmdPrintWeldStuds.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintWeldStuds.TabIndex = 18
        Me.cmdPrintWeldStuds.Text = "Print"
        Me.cmdPrintWeldStuds.UseVisualStyleBackColor = True
        '
        'txtHeadedStuds
        '
        Me.txtHeadedStuds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeadedStuds.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeadedStuds.Location = New System.Drawing.Point(131, 103)
        Me.txtHeadedStuds.Name = "txtHeadedStuds"
        Me.txtHeadedStuds.Size = New System.Drawing.Size(150, 20)
        Me.txtHeadedStuds.TabIndex = 19
        Me.txtHeadedStuds.TabStop = False
        Me.txtHeadedStuds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 20)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Headed Studs"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNonHeadedStuds
        '
        Me.txtNonHeadedStuds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNonHeadedStuds.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNonHeadedStuds.Location = New System.Drawing.Point(131, 128)
        Me.txtNonHeadedStuds.Name = "txtNonHeadedStuds"
        Me.txtNonHeadedStuds.Size = New System.Drawing.Size(150, 20)
        Me.txtNonHeadedStuds.TabIndex = 20
        Me.txtNonHeadedStuds.TabStop = False
        Me.txtNonHeadedStuds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 20)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Non-Headed Studs"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdValueWeldStuds
        '
        Me.cmdValueWeldStuds.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdValueWeldStuds.Location = New System.Drawing.Point(119, 25)
        Me.cmdValueWeldStuds.Name = "cmdValueWeldStuds"
        Me.cmdValueWeldStuds.Size = New System.Drawing.Size(71, 40)
        Me.cmdValueWeldStuds.TabIndex = 17
        Me.cmdValueWeldStuds.Text = "Value Inventory"
        Me.cmdValueWeldStuds.UseVisualStyleBackColor = True
        '
        'txtDebar
        '
        Me.txtDebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDebar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDebar.Location = New System.Drawing.Point(131, 153)
        Me.txtDebar.Name = "txtDebar"
        Me.txtDebar.Size = New System.Drawing.Size(150, 20)
        Me.txtDebar.TabIndex = 21
        Me.txtDebar.TabStop = False
        Me.txtDebar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdShowWeldStuds
        '
        Me.cmdShowWeldStuds.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdShowWeldStuds.Location = New System.Drawing.Point(42, 25)
        Me.cmdShowWeldStuds.Name = "cmdShowWeldStuds"
        Me.cmdShowWeldStuds.Size = New System.Drawing.Size(71, 40)
        Me.cmdShowWeldStuds.TabIndex = 16
        Me.cmdShowWeldStuds.Text = "Apply Filter"
        Me.cmdShowWeldStuds.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 20)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Debar"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalWeldStuds
        '
        Me.txtTotalWeldStuds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalWeldStuds.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalWeldStuds.Location = New System.Drawing.Point(131, 178)
        Me.txtTotalWeldStuds.Name = "txtTotalWeldStuds"
        Me.txtTotalWeldStuds.Size = New System.Drawing.Size(150, 20)
        Me.txtTotalWeldStuds.TabIndex = 22
        Me.txtTotalWeldStuds.TabStop = False
        Me.txtTotalWeldStuds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 178)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 20)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Total "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtTotalUnits)
        Me.GroupBox3.Controls.Add(Me.txtInventoryTotal)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cmdPrintByGL)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cmdAddFilter)
        Me.GroupBox3.Controls.Add(Me.cmdValueInventory)
        Me.GroupBox3.Controls.Add(Me.pbInventoryValue)
        Me.GroupBox3.Location = New System.Drawing.Point(476, 284)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 176)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Inventory Value By Transaction Table"
        '
        'pbInventoryValue
        '
        Me.pbInventoryValue.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pbInventoryValue.ForeColor = System.Drawing.Color.Lime
        Me.pbInventoryValue.Location = New System.Drawing.Point(42, 90)
        Me.pbInventoryValue.Name = "pbInventoryValue"
        Me.pbInventoryValue.Size = New System.Drawing.Size(225, 11)
        Me.pbInventoryValue.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbInventoryValue.TabIndex = 21
        Me.pbInventoryValue.Visible = False
        '
        'dgvInventoryTotals
        '
        Me.dgvInventoryTotals.AllowUserToAddRows = False
        Me.dgvInventoryTotals.AllowUserToDeleteRows = False
        Me.dgvInventoryTotals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryTotals.AutoGenerateColumns = False
        Me.dgvInventoryTotals.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryTotals.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInventoryTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryTotals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ITItemIDColumn, Me.ITShortDescriptionColumn, Me.ITQuantityOnHandColumn, Me.ITOpenSOQuantityColumn, Me.ITOpenPOQuantityColumn, Me.ITTotalShipQuantityPendingColumn, Me.ITLastYearShippedToDateColumn, Me.ITItemClassColumn, Me.ITDivisionIDColumn, Me.ITAdjustmentQuantityColumn, Me.ITVendorReturnQuantityColumn, Me.ITCustomerReturnQuantityColumn, Me.ITProductionQuantityColumn, Me.ITWCProductionQuantityColumn, Me.ITAssemblyBuildQuantityColumn, Me.ITStandardCostColumn, Me.ITStandardPriceColumn, Me.ITMaximumStockColumn, Me.ITMinimumStockColumn, Me.ITTotalReceivedQuantityColumn, Me.ITTotalQuantityShippedColumn})
        Me.dgvInventoryTotals.DataSource = Me.ADMInventoryTotalBindingSource
        Me.dgvInventoryTotals.GridColor = System.Drawing.Color.Purple
        Me.dgvInventoryTotals.Location = New System.Drawing.Point(354, 41)
        Me.dgvInventoryTotals.Name = "dgvInventoryTotals"
        Me.dgvInventoryTotals.Size = New System.Drawing.Size(776, 639)
        Me.dgvInventoryTotals.TabIndex = 20
        Me.dgvInventoryTotals.Visible = False
        '
        'ITItemIDColumn
        '
        Me.ITItemIDColumn.DataPropertyName = "ItemID"
        Me.ITItemIDColumn.HeaderText = "Part #"
        Me.ITItemIDColumn.Name = "ITItemIDColumn"
        '
        'ITShortDescriptionColumn
        '
        Me.ITShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ITShortDescriptionColumn.HeaderText = "Description"
        Me.ITShortDescriptionColumn.Name = "ITShortDescriptionColumn"
        '
        'ITQuantityOnHandColumn
        '
        Me.ITQuantityOnHandColumn.DataPropertyName = "QuantityOnHand"
        DataGridViewCellStyle39.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle39.Format = "N2"
        DataGridViewCellStyle39.NullValue = "0"
        Me.ITQuantityOnHandColumn.DefaultCellStyle = DataGridViewCellStyle39
        Me.ITQuantityOnHandColumn.HeaderText = "QOH"
        Me.ITQuantityOnHandColumn.Name = "ITQuantityOnHandColumn"
        Me.ITQuantityOnHandColumn.ReadOnly = True
        '
        'ITOpenSOQuantityColumn
        '
        Me.ITOpenSOQuantityColumn.DataPropertyName = "OpenSOQuantity"
        Me.ITOpenSOQuantityColumn.HeaderText = "Open SO Qty."
        Me.ITOpenSOQuantityColumn.Name = "ITOpenSOQuantityColumn"
        Me.ITOpenSOQuantityColumn.ReadOnly = True
        '
        'ITOpenPOQuantityColumn
        '
        Me.ITOpenPOQuantityColumn.DataPropertyName = "OpenPOQuantity"
        Me.ITOpenPOQuantityColumn.HeaderText = "Open PO Qty."
        Me.ITOpenPOQuantityColumn.Name = "ITOpenPOQuantityColumn"
        Me.ITOpenPOQuantityColumn.ReadOnly = True
        '
        'ITTotalShipQuantityPendingColumn
        '
        Me.ITTotalShipQuantityPendingColumn.DataPropertyName = "TotalShipQuantityPending"
        Me.ITTotalShipQuantityPendingColumn.HeaderText = "Ship Qty. Pending"
        Me.ITTotalShipQuantityPendingColumn.Name = "ITTotalShipQuantityPendingColumn"
        Me.ITTotalShipQuantityPendingColumn.ReadOnly = True
        '
        'ITLastYearShippedToDateColumn
        '
        Me.ITLastYearShippedToDateColumn.DataPropertyName = "LastYearShippedToDate"
        Me.ITLastYearShippedToDateColumn.HeaderText = "LY Ship-To-Date"
        Me.ITLastYearShippedToDateColumn.Name = "ITLastYearShippedToDateColumn"
        Me.ITLastYearShippedToDateColumn.ReadOnly = True
        '
        'ITItemClassColumn
        '
        Me.ITItemClassColumn.DataPropertyName = "ItemClass"
        Me.ITItemClassColumn.HeaderText = "Item Class"
        Me.ITItemClassColumn.Name = "ITItemClassColumn"
        '
        'ITDivisionIDColumn
        '
        Me.ITDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.ITDivisionIDColumn.HeaderText = "DivisionID"
        Me.ITDivisionIDColumn.Name = "ITDivisionIDColumn"
        Me.ITDivisionIDColumn.Visible = False
        '
        'ITAdjustmentQuantityColumn
        '
        Me.ITAdjustmentQuantityColumn.DataPropertyName = "AdjustmentQuantity"
        Me.ITAdjustmentQuantityColumn.HeaderText = "AdjustmentQuantity"
        Me.ITAdjustmentQuantityColumn.Name = "ITAdjustmentQuantityColumn"
        Me.ITAdjustmentQuantityColumn.ReadOnly = True
        Me.ITAdjustmentQuantityColumn.Visible = False
        '
        'ITVendorReturnQuantityColumn
        '
        Me.ITVendorReturnQuantityColumn.DataPropertyName = "VendorReturnQuantity"
        Me.ITVendorReturnQuantityColumn.HeaderText = "VendorReturnQuantity"
        Me.ITVendorReturnQuantityColumn.Name = "ITVendorReturnQuantityColumn"
        Me.ITVendorReturnQuantityColumn.ReadOnly = True
        Me.ITVendorReturnQuantityColumn.Visible = False
        '
        'ITCustomerReturnQuantityColumn
        '
        Me.ITCustomerReturnQuantityColumn.DataPropertyName = "CustomerReturnQuantity"
        Me.ITCustomerReturnQuantityColumn.HeaderText = "CustomerReturnQuantity"
        Me.ITCustomerReturnQuantityColumn.Name = "ITCustomerReturnQuantityColumn"
        Me.ITCustomerReturnQuantityColumn.ReadOnly = True
        Me.ITCustomerReturnQuantityColumn.Visible = False
        '
        'ITProductionQuantityColumn
        '
        Me.ITProductionQuantityColumn.DataPropertyName = "ProductionQuantity"
        Me.ITProductionQuantityColumn.HeaderText = "ProductionQuantity"
        Me.ITProductionQuantityColumn.Name = "ITProductionQuantityColumn"
        Me.ITProductionQuantityColumn.ReadOnly = True
        Me.ITProductionQuantityColumn.Visible = False
        '
        'ITWCProductionQuantityColumn
        '
        Me.ITWCProductionQuantityColumn.DataPropertyName = "WCProductionQuantity"
        Me.ITWCProductionQuantityColumn.HeaderText = "WCProductionQuantity"
        Me.ITWCProductionQuantityColumn.Name = "ITWCProductionQuantityColumn"
        Me.ITWCProductionQuantityColumn.ReadOnly = True
        Me.ITWCProductionQuantityColumn.Visible = False
        '
        'ITAssemblyBuildQuantityColumn
        '
        Me.ITAssemblyBuildQuantityColumn.DataPropertyName = "AssemblyBuildQuantity"
        Me.ITAssemblyBuildQuantityColumn.HeaderText = "AssemblyBuildQuantity"
        Me.ITAssemblyBuildQuantityColumn.Name = "ITAssemblyBuildQuantityColumn"
        Me.ITAssemblyBuildQuantityColumn.ReadOnly = True
        Me.ITAssemblyBuildQuantityColumn.Visible = False
        '
        'ITStandardCostColumn
        '
        Me.ITStandardCostColumn.DataPropertyName = "StandardCost"
        Me.ITStandardCostColumn.HeaderText = "StandardCost"
        Me.ITStandardCostColumn.Name = "ITStandardCostColumn"
        Me.ITStandardCostColumn.Visible = False
        '
        'ITStandardPriceColumn
        '
        Me.ITStandardPriceColumn.DataPropertyName = "StandardPrice"
        Me.ITStandardPriceColumn.HeaderText = "StandardPrice"
        Me.ITStandardPriceColumn.Name = "ITStandardPriceColumn"
        Me.ITStandardPriceColumn.Visible = False
        '
        'ITMaximumStockColumn
        '
        Me.ITMaximumStockColumn.DataPropertyName = "MaximumStock"
        Me.ITMaximumStockColumn.HeaderText = "MaximumStock"
        Me.ITMaximumStockColumn.Name = "ITMaximumStockColumn"
        Me.ITMaximumStockColumn.ReadOnly = True
        Me.ITMaximumStockColumn.Visible = False
        '
        'ITMinimumStockColumn
        '
        Me.ITMinimumStockColumn.DataPropertyName = "MinimumStock"
        Me.ITMinimumStockColumn.HeaderText = "MinimumStock"
        Me.ITMinimumStockColumn.Name = "ITMinimumStockColumn"
        Me.ITMinimumStockColumn.ReadOnly = True
        Me.ITMinimumStockColumn.Visible = False
        '
        'ITTotalReceivedQuantityColumn
        '
        Me.ITTotalReceivedQuantityColumn.DataPropertyName = "TotalReceivedQuantity"
        Me.ITTotalReceivedQuantityColumn.HeaderText = "TotalReceivedQuantity"
        Me.ITTotalReceivedQuantityColumn.Name = "ITTotalReceivedQuantityColumn"
        Me.ITTotalReceivedQuantityColumn.ReadOnly = True
        Me.ITTotalReceivedQuantityColumn.Visible = False
        '
        'ITTotalQuantityShippedColumn
        '
        Me.ITTotalQuantityShippedColumn.DataPropertyName = "TotalQuantityShipped"
        Me.ITTotalQuantityShippedColumn.HeaderText = "TotalQuantityShipped"
        Me.ITTotalQuantityShippedColumn.Name = "ITTotalQuantityShippedColumn"
        Me.ITTotalQuantityShippedColumn.ReadOnly = True
        Me.ITTotalQuantityShippedColumn.Visible = False
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.cmdGetPartValue)
        Me.GroupBox4.Controls.Add(Me.txtPartQOH)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.txtPartValue)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.cboPartDescription)
        Me.GroupBox4.Controls.Add(Me.cboPartNumber)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Location = New System.Drawing.Point(29, 140)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(300, 209)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Value Single Part Number"
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 95)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(185, 20)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "(value as of date selected above)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGetPartValue
        '
        Me.cmdGetPartValue.Location = New System.Drawing.Point(210, 85)
        Me.cmdGetPartValue.Name = "cmdGetPartValue"
        Me.cmdGetPartValue.Size = New System.Drawing.Size(71, 40)
        Me.cmdGetPartValue.TabIndex = 6
        Me.cmdGetPartValue.Text = "Get Value"
        Me.cmdGetPartValue.UseVisualStyleBackColor = True
        '
        'txtPartQOH
        '
        Me.txtPartQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartQOH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartQOH.Location = New System.Drawing.Point(131, 146)
        Me.txtPartQOH.Name = "txtPartQOH"
        Me.txtPartQOH.Size = New System.Drawing.Size(150, 20)
        Me.txtPartQOH.TabIndex = 7
        Me.txtPartQOH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 146)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 20)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Quantity On Hand"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartValue
        '
        Me.txtPartValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartValue.Location = New System.Drawing.Point(131, 172)
        Me.txtPartValue.Name = "txtPartValue"
        Me.txtPartValue.Size = New System.Drawing.Size(150, 20)
        Me.txtPartValue.TabIndex = 8
        Me.txtPartValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 172)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 20)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Inventory Value"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(19, 55)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(262, 21)
        Me.cboPartDescription.TabIndex = 5
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
        Me.cboPartNumber.Location = New System.Drawing.Point(64, 28)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(217, 21)
        Me.cboPartNumber.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(137, 20)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Part #"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.pbSteelBar)
        Me.GroupBox5.Controls.Add(Me.cmdPrintInventorySteel)
        Me.GroupBox5.Controls.Add(Me.cmdValueInventorySteel)
        Me.GroupBox5.Controls.Add(Me.cmdShowInventorySteel)
        Me.GroupBox5.Location = New System.Drawing.Point(354, 692)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(300, 116)
        Me.GroupBox5.TabIndex = 23
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Inventory Steel Value"
        '
        'pbSteelBar
        '
        Me.pbSteelBar.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pbSteelBar.ForeColor = System.Drawing.Color.Lime
        Me.pbSteelBar.Location = New System.Drawing.Point(42, 84)
        Me.pbSteelBar.Name = "pbSteelBar"
        Me.pbSteelBar.Size = New System.Drawing.Size(225, 11)
        Me.pbSteelBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbSteelBar.TabIndex = 20
        Me.pbSteelBar.Visible = False
        '
        'cmdPrintInventorySteel
        '
        Me.cmdPrintInventorySteel.Location = New System.Drawing.Point(196, 29)
        Me.cmdPrintInventorySteel.Name = "cmdPrintInventorySteel"
        Me.cmdPrintInventorySteel.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintInventorySteel.TabIndex = 26
        Me.cmdPrintInventorySteel.Text = "Print"
        Me.cmdPrintInventorySteel.UseVisualStyleBackColor = True
        '
        'cmdValueInventorySteel
        '
        Me.cmdValueInventorySteel.Location = New System.Drawing.Point(119, 29)
        Me.cmdValueInventorySteel.Name = "cmdValueInventorySteel"
        Me.cmdValueInventorySteel.Size = New System.Drawing.Size(71, 40)
        Me.cmdValueInventorySteel.TabIndex = 25
        Me.cmdValueInventorySteel.Text = "Value Steel"
        Me.cmdValueInventorySteel.UseVisualStyleBackColor = True
        '
        'cmdShowInventorySteel
        '
        Me.cmdShowInventorySteel.Location = New System.Drawing.Point(42, 29)
        Me.cmdShowInventorySteel.Name = "cmdShowInventorySteel"
        Me.cmdShowInventorySteel.Size = New System.Drawing.Size(71, 40)
        Me.cmdShowInventorySteel.TabIndex = 24
        Me.cmdShowInventorySteel.Text = "Apply Filter"
        Me.cmdShowInventorySteel.UseVisualStyleBackColor = True
        '
        'dgvInventorySteelValue
        '
        Me.dgvInventorySteelValue.AllowUserToAddRows = False
        Me.dgvInventorySteelValue.AllowUserToDeleteRows = False
        Me.dgvInventorySteelValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventorySteelValue.AutoGenerateColumns = False
        Me.dgvInventorySteelValue.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventorySteelValue.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInventorySteelValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventorySteelValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumberDataGridViewTextBoxColumn1, Me.DescriptionDataGridViewTextBoxColumn1, Me.QuantityOnHandDataGridViewTextBoxColumn1, Me.FOXNumberDataGridViewTextBoxColumn, Me.RMIDDataGridViewTextBoxColumn, Me.SteelCarbonDataGridViewTextBoxColumn, Me.SteelSizeDataGridViewTextBoxColumn, Me.SteelCostUnitDataGridViewTextBoxColumn, Me.SteelCostTotalDataGridViewTextBoxColumn, Me.ValuationDateDataGridViewTextBoxColumn1, Me.PieceWeightDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn1})
        Me.dgvInventorySteelValue.DataSource = Me.InventorySteelValuationBindingSource
        Me.dgvInventorySteelValue.GridColor = System.Drawing.Color.Lime
        Me.dgvInventorySteelValue.Location = New System.Drawing.Point(354, 41)
        Me.dgvInventorySteelValue.Name = "dgvInventorySteelValue"
        Me.dgvInventorySteelValue.ReadOnly = True
        Me.dgvInventorySteelValue.Size = New System.Drawing.Size(776, 639)
        Me.dgvInventorySteelValue.TabIndex = 24
        '
        'PartNumberDataGridViewTextBoxColumn1
        '
        Me.PartNumberDataGridViewTextBoxColumn1.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn1.HeaderText = "Part #"
        Me.PartNumberDataGridViewTextBoxColumn1.Name = "PartNumberDataGridViewTextBoxColumn1"
        Me.PartNumberDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DescriptionDataGridViewTextBoxColumn1
        '
        Me.DescriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn1.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn1.Name = "DescriptionDataGridViewTextBoxColumn1"
        Me.DescriptionDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'QuantityOnHandDataGridViewTextBoxColumn1
        '
        Me.QuantityOnHandDataGridViewTextBoxColumn1.DataPropertyName = "QuantityOnHand"
        DataGridViewCellStyle40.Format = "N2"
        DataGridViewCellStyle40.NullValue = "0"
        Me.QuantityOnHandDataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle40
        Me.QuantityOnHandDataGridViewTextBoxColumn1.HeaderText = "QOH"
        Me.QuantityOnHandDataGridViewTextBoxColumn1.Name = "QuantityOnHandDataGridViewTextBoxColumn1"
        Me.QuantityOnHandDataGridViewTextBoxColumn1.ReadOnly = True
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
        '
        'SteelCarbonDataGridViewTextBoxColumn
        '
        Me.SteelCarbonDataGridViewTextBoxColumn.DataPropertyName = "SteelCarbon"
        Me.SteelCarbonDataGridViewTextBoxColumn.HeaderText = "Steel Carbon"
        Me.SteelCarbonDataGridViewTextBoxColumn.Name = "SteelCarbonDataGridViewTextBoxColumn"
        Me.SteelCarbonDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SteelSizeDataGridViewTextBoxColumn
        '
        Me.SteelSizeDataGridViewTextBoxColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeDataGridViewTextBoxColumn.HeaderText = "Steel Size"
        Me.SteelSizeDataGridViewTextBoxColumn.Name = "SteelSizeDataGridViewTextBoxColumn"
        Me.SteelSizeDataGridViewTextBoxColumn.ReadOnly = True
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
        Me.SteelCostTotalDataGridViewTextBoxColumn.HeaderText = "Total Cost"
        Me.SteelCostTotalDataGridViewTextBoxColumn.Name = "SteelCostTotalDataGridViewTextBoxColumn"
        Me.SteelCostTotalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ValuationDateDataGridViewTextBoxColumn1
        '
        Me.ValuationDateDataGridViewTextBoxColumn1.DataPropertyName = "ValuationDate"
        Me.ValuationDateDataGridViewTextBoxColumn1.HeaderText = "Valuation Date"
        Me.ValuationDateDataGridViewTextBoxColumn1.Name = "ValuationDateDataGridViewTextBoxColumn1"
        Me.ValuationDateDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'PieceWeightDataGridViewTextBoxColumn
        '
        Me.PieceWeightDataGridViewTextBoxColumn.DataPropertyName = "PieceWeight"
        Me.PieceWeightDataGridViewTextBoxColumn.HeaderText = "Piece Weight"
        Me.PieceWeightDataGridViewTextBoxColumn.Name = "PieceWeightDataGridViewTextBoxColumn"
        Me.PieceWeightDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DivisionIDDataGridViewTextBoxColumn1
        '
        Me.DivisionIDDataGridViewTextBoxColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.HeaderText = "Division"
        Me.DivisionIDDataGridViewTextBoxColumn1.Name = "DivisionIDDataGridViewTextBoxColumn1"
        Me.DivisionIDDataGridViewTextBoxColumn1.ReadOnly = True
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
        'InventoryValuation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvInventorySteelValue)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.dgvInventoryTotals)
        Me.Controls.Add(Me.cmdViewFIFOValuation)
        Me.Controls.Add(Me.dgvFIFOInventory)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdViewInventoryValuation)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.gpxDateSelect)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvInventoryValuation)
        Me.Controls.Add(Me.dgvInventoryTransactions)
        Me.Controls.Add(Me.GroupBox3)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InventoryValuation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Valuation"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxDateSelect.ResumeLayout(False)
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventoryTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventoryValuation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryValuationSummaryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvFIFOInventory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryFIFOValuationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvInventoryTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADMInventoryTotalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgvInventorySteelValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventorySteelValuationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxDateSelect As System.Windows.Forms.GroupBox
    Friend WithEvents dtpValuationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdAddFilter As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dgvInventoryTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryTransactionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryTransactionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryTransactionTableTableAdapter
    Friend WithEvents dgvInventoryValuation As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryValuationSummaryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryValuationSummaryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryValuationSummaryTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdValueInventory As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInventoryTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalUnits As System.Windows.Forms.TextBox
    Friend WithEvents cmdPrintByGL As System.Windows.Forms.Button
    Friend WithEvents ValuationByGLSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdShowFIFOCosting As System.Windows.Forms.Button
    Friend WithEvents cmdValueFIFO As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvFIFOInventory As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryFIFOValuationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryFIFOValuationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryFIFOValuationTableAdapter
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIFOCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIFOExtendedAmountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValuationDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtFIFOQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txtFIFOTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdViewInventoryValuation As System.Windows.Forms.Button
    Friend WithEvents cmdViewFIFOValuation As System.Windows.Forms.Button
    Friend WithEvents cmdPrintFIFO As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ValuationByToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbFIFOBar As System.Windows.Forms.ProgressBar
    Friend WithEvents pbInventoryValue As System.Windows.Forms.ProgressBar
    Friend WithEvents dgvInventoryTotals As System.Windows.Forms.DataGridView
    Friend WithEvents ADMInventoryTotalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ADMInventoryTotalTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ADMInventoryTotalTableAdapter
    Friend WithEvents ITBeginningBalanceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdShowWeldStuds As System.Windows.Forms.Button
    Friend WithEvents cmdPrintWeldStuds As System.Windows.Forms.Button
    Friend WithEvents txtHeadedStuds As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNonHeadedStuds As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdValueWeldStuds As System.Windows.Forms.Button
    Friend WithEvents txtDebar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeldStuds As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pbWeldStudBar As System.Windows.Forms.ProgressBar
    Friend WithEvents BCWValuationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DCWValuationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HCWValuationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LCWValuationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PCWValuationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SCWValuationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YCWValuationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGetPartValue As System.Windows.Forms.Button
    Friend WithEvents txtPartQOH As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPartValue As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents pbSteelBar As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdPrintInventorySteel As System.Windows.Forms.Button
    Friend WithEvents cmdValueInventorySteel As System.Windows.Forms.Button
    Friend WithEvents cmdShowInventorySteel As System.Windows.Forms.Button
    Friend WithEvents dgvInventorySteelValue As System.Windows.Forms.DataGridView
    Friend WithEvents InventorySteelValuationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventorySteelValuationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventorySteelValuationTableAdapter
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionMathColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VSDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VSItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VSShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VSLongDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VSSumQuantityAddColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VSSumQuantitySubtractColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VSNetQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VSSumCostAddColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VSSumCostSubtractColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VSNetCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AverageCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITQuantityOnHandColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITOpenSOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITOpenPOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITTotalShipQuantityPendingColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITLastYearShippedToDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITAdjustmentQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITVendorReturnQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITCustomerReturnQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITProductionQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITWCProductionQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITAssemblyBuildQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITStandardCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITStandardPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITMaximumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITMinimumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITTotalReceivedQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITTotalQuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCarbonDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostUnitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValuationDateDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CloseDivisionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
