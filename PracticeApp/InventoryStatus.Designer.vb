<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryStatus
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HideSOColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HidePOColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideStandardCostColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideStandardPriceColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideMinStockColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideMaxStockColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideFOXColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideQtyReceivedColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideQtyShippedColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideQtyAdjustedColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideCustomerReturnColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideVendorReturnColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideProductionQtyColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideWCProductionColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideAssemblyColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HidePrefVendorColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.HideLeadTimeColumn = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowAllColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InventoryUsageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReorderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InventoryCountSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingwPricingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NegativeInventoryReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InactivityReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WCFerruleProductionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.chkOmit = New System.Windows.Forms.CheckBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdUsage = New System.Windows.Forms.Button
        Me.cmdReorder = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkWithoutCommitted = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboSelectByItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdTWDInventory = New System.Windows.Forms.Button
        Me.cmdNegativeInventory = New System.Windows.Forms.Button
        Me.cmdCountSheet = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkShowFOX = New System.Windows.Forms.CheckBox
        Me.cboSPL = New System.Windows.Forms.ComboBox
        Me.SalesProductLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
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
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dgvInventoryTotals = New System.Windows.Forms.DataGridView
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenSOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenPOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinimumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaximumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LeadTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PreferredVendorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalReceivedQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalShipQuantityPendingColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorReturnQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerReturnQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductionQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WCProductionQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyBuildQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ADMInventoryTotalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblLoading = New System.Windows.Forms.Label
        Me.BGLoading = New System.ComponentModel.BackgroundWorker
        Me.ADMInventoryTotalTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ADMInventoryTotalTableAdapter
        Me.cmdItemMaintenance = New System.Windows.Forms.Button
        Me.cmdViewWIP = New System.Windows.Forms.Button
        Me.cmdPrintRackContents = New System.Windows.Forms.Button
        Me.SalesProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboItemClassReorderWorksheet = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventoryTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADMInventoryTotalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1053, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 26
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 1
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideSOColumn, Me.HidePOColumn, Me.HideStandardCostColumn, Me.HideStandardPriceColumn, Me.HideMinStockColumn, Me.HideMaxStockColumn, Me.HideFOXColumn, Me.HideQtyReceivedColumn, Me.HideQtyShippedColumn, Me.HideQtyAdjustedColumn, Me.HideCustomerReturnColumn, Me.HideVendorReturnColumn, Me.HideProductionQtyColumn, Me.HideWCProductionColumn, Me.HideAssemblyColumn, Me.HidePrefVendorColumn, Me.HideLeadTimeColumn, Me.ShowAllColumnsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'HideSOColumn
        '
        Me.HideSOColumn.CheckOnClick = True
        Me.HideSOColumn.Name = "HideSOColumn"
        Me.HideSOColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideSOColumn.Text = "Hide Open SO Column"
        '
        'HidePOColumn
        '
        Me.HidePOColumn.CheckOnClick = True
        Me.HidePOColumn.Name = "HidePOColumn"
        Me.HidePOColumn.Size = New System.Drawing.Size(218, 22)
        Me.HidePOColumn.Text = "Hide Open PO Column"
        '
        'HideStandardCostColumn
        '
        Me.HideStandardCostColumn.CheckOnClick = True
        Me.HideStandardCostColumn.Name = "HideStandardCostColumn"
        Me.HideStandardCostColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideStandardCostColumn.Text = "Hide Standard Cost Column"
        '
        'HideStandardPriceColumn
        '
        Me.HideStandardPriceColumn.CheckOnClick = True
        Me.HideStandardPriceColumn.Name = "HideStandardPriceColumn"
        Me.HideStandardPriceColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideStandardPriceColumn.Text = "Hide Standard Price Column"
        '
        'HideMinStockColumn
        '
        Me.HideMinStockColumn.CheckOnClick = True
        Me.HideMinStockColumn.Name = "HideMinStockColumn"
        Me.HideMinStockColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideMinStockColumn.Text = "Hide Min Stock Column"
        '
        'HideMaxStockColumn
        '
        Me.HideMaxStockColumn.CheckOnClick = True
        Me.HideMaxStockColumn.Name = "HideMaxStockColumn"
        Me.HideMaxStockColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideMaxStockColumn.Text = "Hide Max Stock Column"
        '
        'HideFOXColumn
        '
        Me.HideFOXColumn.CheckOnClick = True
        Me.HideFOXColumn.Name = "HideFOXColumn"
        Me.HideFOXColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideFOXColumn.Text = "Hide FOX # Column"
        '
        'HideQtyReceivedColumn
        '
        Me.HideQtyReceivedColumn.CheckOnClick = True
        Me.HideQtyReceivedColumn.Name = "HideQtyReceivedColumn"
        Me.HideQtyReceivedColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideQtyReceivedColumn.Text = "Hide Qty Received Column"
        '
        'HideQtyShippedColumn
        '
        Me.HideQtyShippedColumn.CheckOnClick = True
        Me.HideQtyShippedColumn.Name = "HideQtyShippedColumn"
        Me.HideQtyShippedColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideQtyShippedColumn.Text = "Hide Qty Shipped Column"
        '
        'HideQtyAdjustedColumn
        '
        Me.HideQtyAdjustedColumn.CheckOnClick = True
        Me.HideQtyAdjustedColumn.Name = "HideQtyAdjustedColumn"
        Me.HideQtyAdjustedColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideQtyAdjustedColumn.Text = "Hide Qty Adjusted Column"
        '
        'HideCustomerReturnColumn
        '
        Me.HideCustomerReturnColumn.CheckOnClick = True
        Me.HideCustomerReturnColumn.Name = "HideCustomerReturnColumn"
        Me.HideCustomerReturnColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideCustomerReturnColumn.Text = "Hide Customer Return Column"
        '
        'HideVendorReturnColumn
        '
        Me.HideVendorReturnColumn.CheckOnClick = True
        Me.HideVendorReturnColumn.Name = "HideVendorReturnColumn"
        Me.HideVendorReturnColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideVendorReturnColumn.Text = "Hide Vendor Return Column"
        '
        'HideProductionQtyColumn
        '
        Me.HideProductionQtyColumn.CheckOnClick = True
        Me.HideProductionQtyColumn.Name = "HideProductionQtyColumn"
        Me.HideProductionQtyColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideProductionQtyColumn.Text = "Hide Production Qty Column"
        '
        'HideWCProductionColumn
        '
        Me.HideWCProductionColumn.CheckOnClick = True
        Me.HideWCProductionColumn.Name = "HideWCProductionColumn"
        Me.HideWCProductionColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideWCProductionColumn.Text = "Hide WC Production Column"
        '
        'HideAssemblyColumn
        '
        Me.HideAssemblyColumn.CheckOnClick = True
        Me.HideAssemblyColumn.Name = "HideAssemblyColumn"
        Me.HideAssemblyColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideAssemblyColumn.Text = "Hide Assembly Column"
        '
        'HidePrefVendorColumn
        '
        Me.HidePrefVendorColumn.CheckOnClick = True
        Me.HidePrefVendorColumn.Name = "HidePrefVendorColumn"
        Me.HidePrefVendorColumn.Size = New System.Drawing.Size(218, 22)
        Me.HidePrefVendorColumn.Text = "Hide Pref. Vendor Column"
        '
        'HideLeadTimeColumn
        '
        Me.HideLeadTimeColumn.CheckOnClick = True
        Me.HideLeadTimeColumn.Name = "HideLeadTimeColumn"
        Me.HideLeadTimeColumn.Size = New System.Drawing.Size(218, 22)
        Me.HideLeadTimeColumn.Text = "Hide Lead Time Column"
        '
        'ShowAllColumnsToolStripMenuItem
        '
        Me.ShowAllColumnsToolStripMenuItem.Name = "ShowAllColumnsToolStripMenuItem"
        Me.ShowAllColumnsToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ShowAllColumnsToolStripMenuItem.Text = "Show All Columns"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InventoryUsageToolStripMenuItem, Me.ReorderToolStripMenuItem, Me.InventoryCountSheetToolStripMenuItem, Me.PrintListingwPricingToolStripMenuItem, Me.NegativeInventoryReportToolStripMenuItem, Me.InactivityReportToolStripMenuItem, Me.WCFerruleProductionToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'InventoryUsageToolStripMenuItem
        '
        Me.InventoryUsageToolStripMenuItem.Name = "InventoryUsageToolStripMenuItem"
        Me.InventoryUsageToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.InventoryUsageToolStripMenuItem.Text = "Inventory Usage"
        '
        'ReorderToolStripMenuItem
        '
        Me.ReorderToolStripMenuItem.Name = "ReorderToolStripMenuItem"
        Me.ReorderToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ReorderToolStripMenuItem.Text = "Re-Order Worksheet"
        '
        'InventoryCountSheetToolStripMenuItem
        '
        Me.InventoryCountSheetToolStripMenuItem.Name = "InventoryCountSheetToolStripMenuItem"
        Me.InventoryCountSheetToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.InventoryCountSheetToolStripMenuItem.Text = "Inventory Count Sheet"
        '
        'PrintListingwPricingToolStripMenuItem
        '
        Me.PrintListingwPricingToolStripMenuItem.Name = "PrintListingwPricingToolStripMenuItem"
        Me.PrintListingwPricingToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.PrintListingwPricingToolStripMenuItem.Text = "Print Listing (w/Pricing)"
        '
        'NegativeInventoryReportToolStripMenuItem
        '
        Me.NegativeInventoryReportToolStripMenuItem.Name = "NegativeInventoryReportToolStripMenuItem"
        Me.NegativeInventoryReportToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.NegativeInventoryReportToolStripMenuItem.Text = "Negative Inventory Report"
        '
        'InactivityReportToolStripMenuItem
        '
        Me.InactivityReportToolStripMenuItem.Name = "InactivityReportToolStripMenuItem"
        Me.InactivityReportToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.InactivityReportToolStripMenuItem.Text = "Inactivity Report"
        '
        'WCFerruleProductionToolStripMenuItem
        '
        Me.WCFerruleProductionToolStripMenuItem.Name = "WCFerruleProductionToolStripMenuItem"
        Me.WCFerruleProductionToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.WCFerruleProductionToolStripMenuItem.Text = "WC Ferrule Production"
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
        'chkOmit
        '
        Me.chkOmit.AutoSize = True
        Me.chkOmit.Location = New System.Drawing.Point(91, 96)
        Me.chkOmit.Name = "chkOmit"
        Me.chkOmit.Size = New System.Drawing.Size(147, 17)
        Me.chkOmit.TabIndex = 2
        Me.chkOmit.Text = "Omit Items with zero QOH"
        Me.chkOmit.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(216, 578)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(138, 578)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 13
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
        Me.cboDivisionID.Location = New System.Drawing.Point(88, 19)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(196, 21)
        Me.cboDivisionID.TabIndex = 0
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
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(977, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 25
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(55, 128)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(226, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(12, 161)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(269, 21)
        Me.cboPartDescription.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Part #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdUsage
        '
        Me.cmdUsage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUsage.Location = New System.Drawing.Point(825, 725)
        Me.cmdUsage.Name = "cmdUsage"
        Me.cmdUsage.Size = New System.Drawing.Size(71, 40)
        Me.cmdUsage.TabIndex = 19
        Me.cmdUsage.Text = "Inventory Usage"
        Me.cmdUsage.UseVisualStyleBackColor = True
        '
        'cmdReorder
        '
        Me.cmdReorder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReorder.Location = New System.Drawing.Point(286, 20)
        Me.cmdReorder.Name = "cmdReorder"
        Me.cmdReorder.Size = New System.Drawing.Size(71, 40)
        Me.cmdReorder.TabIndex = 18
        Me.cmdReorder.Text = "Re-Order Worksheet"
        Me.cmdReorder.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkWithoutCommitted)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboSelectByItemClass)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cmdTWDInventory)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 676)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 135)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print TWD Inventory"
        '
        'chkWithoutCommitted
        '
        Me.chkWithoutCommitted.AutoSize = True
        Me.chkWithoutCommitted.Location = New System.Drawing.Point(163, 51)
        Me.chkWithoutCommitted.Name = "chkWithoutCommitted"
        Me.chkWithoutCommitted.Size = New System.Drawing.Size(124, 17)
        Me.chkWithoutCommitted.TabIndex = 62
        Me.chkWithoutCommitted.Text = "W/O Committed Qty."
        Me.chkWithoutCommitted.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(9, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(201, 49)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Select Item Class to view inventory in TWD or leave blank to view all weld studs." & _
            ""
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSelectByItemClass
        '
        Me.cboSelectByItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSelectByItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSelectByItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboSelectByItemClass.DisplayMember = "ItemClassID"
        Me.cboSelectByItemClass.FormattingEnabled = True
        Me.cboSelectByItemClass.Location = New System.Drawing.Point(94, 19)
        Me.cboSelectByItemClass.Name = "cboSelectByItemClass"
        Me.cboSelectByItemClass.Size = New System.Drawing.Size(193, 21)
        Me.cboSelectByItemClass.TabIndex = 16
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Item Class"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdTWDInventory
        '
        Me.cmdTWDInventory.Location = New System.Drawing.Point(216, 79)
        Me.cmdTWDInventory.Name = "cmdTWDInventory"
        Me.cmdTWDInventory.Size = New System.Drawing.Size(71, 40)
        Me.cmdTWDInventory.TabIndex = 17
        Me.cmdTWDInventory.Text = "TWD Inventory"
        Me.cmdTWDInventory.UseVisualStyleBackColor = True
        '
        'cmdNegativeInventory
        '
        Me.cmdNegativeInventory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNegativeInventory.Location = New System.Drawing.Point(901, 725)
        Me.cmdNegativeInventory.Name = "cmdNegativeInventory"
        Me.cmdNegativeInventory.Size = New System.Drawing.Size(71, 40)
        Me.cmdNegativeInventory.TabIndex = 20
        Me.cmdNegativeInventory.Text = "Neg. Inv.  Report"
        Me.cmdNegativeInventory.UseVisualStyleBackColor = True
        '
        'cmdCountSheet
        '
        Me.cmdCountSheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCountSheet.Location = New System.Drawing.Point(977, 725)
        Me.cmdCountSheet.Name = "cmdCountSheet"
        Me.cmdCountSheet.Size = New System.Drawing.Size(71, 40)
        Me.cmdCountSheet.TabIndex = 21
        Me.cmdCountSheet.Text = "Count Sheet"
        Me.cmdCountSheet.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkShowFOX)
        Me.GroupBox3.Controls.Add(Me.cboSPL)
        Me.GroupBox3.Controls.Add(Me.Label14)
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
        Me.GroupBox3.Size = New System.Drawing.Size(300, 629)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "View By Filters"
        '
        'chkShowFOX
        '
        Me.chkShowFOX.AutoSize = True
        Me.chkShowFOX.ForeColor = System.Drawing.Color.Blue
        Me.chkShowFOX.Location = New System.Drawing.Point(21, 586)
        Me.chkShowFOX.Name = "chkShowFOX"
        Me.chkShowFOX.Size = New System.Drawing.Size(87, 17)
        Me.chkShowFOX.TabIndex = 64
        Me.chkShowFOX.Text = "Show FOX #"
        Me.chkShowFOX.UseVisualStyleBackColor = True
        '
        'cboSPL
        '
        Me.cboSPL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSPL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSPL.DataSource = Me.SalesProductLineBindingSource
        Me.cboSPL.DisplayMember = "SalesProdLineID"
        Me.cboSPL.FormattingEnabled = True
        Me.cboSPL.Location = New System.Drawing.Point(88, 297)
        Me.cboSPL.Name = "cboSPL"
        Me.cboSPL.Size = New System.Drawing.Size(193, 21)
        Me.cboSPL.TabIndex = 7
        '
        'SalesProductLineBindingSource
        '
        Me.SalesProductLineBindingSource.DataMember = "SalesProductLine"
        Me.SalesProductLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(15, 297)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 20)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "SPL"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClassTextFilter
        '
        Me.txtClassTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClassTextFilter.Location = New System.Drawing.Point(88, 259)
        Me.txtClassTextFilter.Name = "txtClassTextFilter"
        Me.txtClassTextFilter.Size = New System.Drawing.Size(190, 20)
        Me.txtClassTextFilter.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 259)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Class Filter"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(17, 345)
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
        Me.txtTextFilter5.Location = New System.Drawing.Point(96, 528)
        Me.txtTextFilter5.Name = "txtTextFilter5"
        Me.txtTextFilter5.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter5.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 528)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Contains;"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter4
        '
        Me.txtTextFilter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter4.Location = New System.Drawing.Point(96, 495)
        Me.txtTextFilter4.Name = "txtTextFilter4"
        Me.txtTextFilter4.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter4.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 495)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Contains;"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter3
        '
        Me.txtTextFilter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter3.Location = New System.Drawing.Point(96, 462)
        Me.txtTextFilter3.Name = "txtTextFilter3"
        Me.txtTextFilter3.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter3.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 462)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Contains;"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter2
        '
        Me.txtTextFilter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter2.Location = New System.Drawing.Point(96, 429)
        Me.txtTextFilter2.Name = "txtTextFilter2"
        Me.txtTextFilter2.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter2.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 429)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Contains;"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter1
        '
        Me.txtTextFilter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter1.Location = New System.Drawing.Point(96, 396)
        Me.txtTextFilter1.Name = "txtTextFilter1"
        Me.txtTextFilter1.Size = New System.Drawing.Size(190, 20)
        Me.txtTextFilter1.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 396)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Begins with;"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(17, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(267, 40)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(88, 220)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(193, 21)
        Me.cboItemClass.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 221)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Item Class"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvInventoryTotals
        '
        Me.dgvInventoryTotals.AllowUserToAddRows = False
        Me.dgvInventoryTotals.AllowUserToDeleteRows = False
        Me.dgvInventoryTotals.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvInventoryTotals.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventoryTotals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryTotals.AutoGenerateColumns = False
        Me.dgvInventoryTotals.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryTotals.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryTotals.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInventoryTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryTotals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FOXNumberColumn, Me.DivisionIDColumn, Me.ItemIDColumn, Me.ShortDescriptionColumn, Me.QuantityOnHandColumn, Me.OpenSOQuantityColumn, Me.OpenPOQuantityColumn, Me.StandardCostColumn, Me.StandardPriceColumn, Me.MinimumStockColumn, Me.MaximumStockColumn, Me.LeadTimeColumn, Me.PreferredVendorColumn, Me.TotalReceivedQuantityColumn, Me.TotalQuantityShippedColumn, Me.TotalShipQuantityPendingColumn, Me.AdjustmentQuantityColumn, Me.VendorReturnQuantityColumn, Me.CustomerReturnQuantityColumn, Me.ProductionQuantityColumn, Me.WCProductionQuantityColumn, Me.AssemblyBuildQuantityColumn, Me.ItemClassColumn})
        Me.dgvInventoryTotals.DataSource = Me.ADMInventoryTotalBindingSource
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInventoryTotals.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvInventoryTotals.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInventoryTotals.Location = New System.Drawing.Point(345, 41)
        Me.dgvInventoryTotals.Name = "dgvInventoryTotals"
        Me.dgvInventoryTotals.ReadOnly = True
        Me.dgvInventoryTotals.Size = New System.Drawing.Size(785, 674)
        Me.dgvInventoryTotals.TabIndex = 22
        Me.dgvInventoryTotals.TabStop = False
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        Me.FOXNumberColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "Part #"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "Description"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        Me.ShortDescriptionColumn.ReadOnly = True
        '
        'QuantityOnHandColumn
        '
        Me.QuantityOnHandColumn.DataPropertyName = "QuantityOnHand"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.QuantityOnHandColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.QuantityOnHandColumn.HeaderText = "QOH"
        Me.QuantityOnHandColumn.Name = "QuantityOnHandColumn"
        Me.QuantityOnHandColumn.ReadOnly = True
        '
        'OpenSOQuantityColumn
        '
        Me.OpenSOQuantityColumn.DataPropertyName = "OpenSOQuantity"
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.OpenSOQuantityColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.OpenSOQuantityColumn.HeaderText = "Open SO Qty"
        Me.OpenSOQuantityColumn.Name = "OpenSOQuantityColumn"
        Me.OpenSOQuantityColumn.ReadOnly = True
        '
        'OpenPOQuantityColumn
        '
        Me.OpenPOQuantityColumn.DataPropertyName = "OpenPOQuantity"
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.OpenPOQuantityColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.OpenPOQuantityColumn.HeaderText = "Open PO Qty"
        Me.OpenPOQuantityColumn.Name = "OpenPOQuantityColumn"
        Me.OpenPOQuantityColumn.ReadOnly = True
        '
        'StandardCostColumn
        '
        Me.StandardCostColumn.DataPropertyName = "StandardCost"
        DataGridViewCellStyle6.Format = "N5"
        DataGridViewCellStyle6.NullValue = "0"
        Me.StandardCostColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.StandardCostColumn.HeaderText = "Std Cost"
        Me.StandardCostColumn.Name = "StandardCostColumn"
        Me.StandardCostColumn.ReadOnly = True
        '
        'StandardPriceColumn
        '
        Me.StandardPriceColumn.DataPropertyName = "StandardPrice"
        DataGridViewCellStyle7.Format = "N5"
        DataGridViewCellStyle7.NullValue = "0"
        Me.StandardPriceColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.StandardPriceColumn.HeaderText = "Std Price"
        Me.StandardPriceColumn.Name = "StandardPriceColumn"
        Me.StandardPriceColumn.ReadOnly = True
        '
        'MinimumStockColumn
        '
        Me.MinimumStockColumn.DataPropertyName = "MinimumStock"
        Me.MinimumStockColumn.HeaderText = "Min Stock"
        Me.MinimumStockColumn.Name = "MinimumStockColumn"
        Me.MinimumStockColumn.ReadOnly = True
        '
        'MaximumStockColumn
        '
        Me.MaximumStockColumn.DataPropertyName = "MaximumStock"
        Me.MaximumStockColumn.HeaderText = "Max Stock"
        Me.MaximumStockColumn.Name = "MaximumStockColumn"
        Me.MaximumStockColumn.ReadOnly = True
        '
        'LeadTimeColumn
        '
        Me.LeadTimeColumn.DataPropertyName = "LeadTime"
        Me.LeadTimeColumn.HeaderText = "Lead Time"
        Me.LeadTimeColumn.Name = "LeadTimeColumn"
        Me.LeadTimeColumn.ReadOnly = True
        '
        'PreferredVendorColumn
        '
        Me.PreferredVendorColumn.DataPropertyName = "PreferredVendor"
        Me.PreferredVendorColumn.HeaderText = "Pref. Vendor"
        Me.PreferredVendorColumn.Name = "PreferredVendorColumn"
        Me.PreferredVendorColumn.ReadOnly = True
        '
        'TotalReceivedQuantityColumn
        '
        Me.TotalReceivedQuantityColumn.DataPropertyName = "TotalReceivedQuantity"
        Me.TotalReceivedQuantityColumn.HeaderText = "Total Qty Recvd"
        Me.TotalReceivedQuantityColumn.Name = "TotalReceivedQuantityColumn"
        Me.TotalReceivedQuantityColumn.ReadOnly = True
        '
        'TotalQuantityShippedColumn
        '
        Me.TotalQuantityShippedColumn.DataPropertyName = "TotalQuantityShipped"
        Me.TotalQuantityShippedColumn.HeaderText = "Total Qty Shipped"
        Me.TotalQuantityShippedColumn.Name = "TotalQuantityShippedColumn"
        Me.TotalQuantityShippedColumn.ReadOnly = True
        '
        'TotalShipQuantityPendingColumn
        '
        Me.TotalShipQuantityPendingColumn.DataPropertyName = "TotalShipQuantityPending"
        Me.TotalShipQuantityPendingColumn.HeaderText = "Total Ship Qty Pending "
        Me.TotalShipQuantityPendingColumn.Name = "TotalShipQuantityPendingColumn"
        Me.TotalShipQuantityPendingColumn.ReadOnly = True
        '
        'AdjustmentQuantityColumn
        '
        Me.AdjustmentQuantityColumn.DataPropertyName = "AdjustmentQuantity"
        Me.AdjustmentQuantityColumn.HeaderText = "Adj Qty"
        Me.AdjustmentQuantityColumn.Name = "AdjustmentQuantityColumn"
        Me.AdjustmentQuantityColumn.ReadOnly = True
        '
        'VendorReturnQuantityColumn
        '
        Me.VendorReturnQuantityColumn.DataPropertyName = "VendorReturnQuantity"
        Me.VendorReturnQuantityColumn.HeaderText = "Vendor Return Qty"
        Me.VendorReturnQuantityColumn.Name = "VendorReturnQuantityColumn"
        Me.VendorReturnQuantityColumn.ReadOnly = True
        '
        'CustomerReturnQuantityColumn
        '
        Me.CustomerReturnQuantityColumn.DataPropertyName = "CustomerReturnQuantity"
        Me.CustomerReturnQuantityColumn.HeaderText = "Cust. Return Qty"
        Me.CustomerReturnQuantityColumn.Name = "CustomerReturnQuantityColumn"
        Me.CustomerReturnQuantityColumn.ReadOnly = True
        '
        'ProductionQuantityColumn
        '
        Me.ProductionQuantityColumn.DataPropertyName = "ProductionQuantity"
        Me.ProductionQuantityColumn.HeaderText = "Production Qty"
        Me.ProductionQuantityColumn.Name = "ProductionQuantityColumn"
        Me.ProductionQuantityColumn.ReadOnly = True
        '
        'WCProductionQuantityColumn
        '
        Me.WCProductionQuantityColumn.DataPropertyName = "WCProductionQuantity"
        Me.WCProductionQuantityColumn.HeaderText = "WC Production Qty"
        Me.WCProductionQuantityColumn.Name = "WCProductionQuantityColumn"
        Me.WCProductionQuantityColumn.ReadOnly = True
        '
        'AssemblyBuildQuantityColumn
        '
        Me.AssemblyBuildQuantityColumn.DataPropertyName = "AssemblyBuildQuantity"
        Me.AssemblyBuildQuantityColumn.HeaderText = "Assembly Build Qty"
        Me.AssemblyBuildQuantityColumn.Name = "AssemblyBuildQuantityColumn"
        Me.AssemblyBuildQuantityColumn.ReadOnly = True
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.ReadOnly = True
        '
        'ADMInventoryTotalBindingSource
        '
        Me.ADMInventoryTotalBindingSource.DataMember = "ADMInventoryTotal"
        Me.ADMInventoryTotalBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblLoading
        '
        Me.lblLoading.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLoading.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.ForeColor = System.Drawing.Color.Blue
        Me.lblLoading.Location = New System.Drawing.Point(566, 320)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(380, 125)
        Me.lblLoading.TabIndex = 61
        Me.lblLoading.Text = "LOADING..."
        Me.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblLoading.Visible = False
        '
        'BGLoading
        '
        '
        'ADMInventoryTotalTableAdapter
        '
        Me.ADMInventoryTotalTableAdapter.ClearBeforeFill = True
        '
        'cmdItemMaintenance
        '
        Me.cmdItemMaintenance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdItemMaintenance.Location = New System.Drawing.Point(901, 771)
        Me.cmdItemMaintenance.Name = "cmdItemMaintenance"
        Me.cmdItemMaintenance.Size = New System.Drawing.Size(71, 40)
        Me.cmdItemMaintenance.TabIndex = 24
        Me.cmdItemMaintenance.Text = "Item Form"
        Me.cmdItemMaintenance.UseVisualStyleBackColor = True
        '
        'cmdViewWIP
        '
        Me.cmdViewWIP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewWIP.Location = New System.Drawing.Point(825, 771)
        Me.cmdViewWIP.Name = "cmdViewWIP"
        Me.cmdViewWIP.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewWIP.TabIndex = 23
        Me.cmdViewWIP.Text = "View WIP"
        Me.cmdViewWIP.UseVisualStyleBackColor = True
        Me.cmdViewWIP.Visible = False
        '
        'cmdPrintRackContents
        '
        Me.cmdPrintRackContents.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintRackContents.Location = New System.Drawing.Point(1053, 725)
        Me.cmdPrintRackContents.Name = "cmdPrintRackContents"
        Me.cmdPrintRackContents.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintRackContents.TabIndex = 22
        Me.cmdPrintRackContents.Text = "Rack Contents"
        Me.cmdPrintRackContents.UseVisualStyleBackColor = True
        '
        'SalesProductLineTableAdapter
        '
        Me.SalesProductLineTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cboItemClassReorderWorksheet)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cmdReorder)
        Me.GroupBox1.Location = New System.Drawing.Point(348, 734)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(374, 76)
        Me.GroupBox1.TabIndex = 62
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View Re-Order Worksheet"
        '
        'cboItemClassReorderWorksheet
        '
        Me.cboItemClassReorderWorksheet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClassReorderWorksheet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClassReorderWorksheet.DataSource = Me.ItemClassBindingSource
        Me.cboItemClassReorderWorksheet.DisplayMember = "ItemClassID"
        Me.cboItemClassReorderWorksheet.FormattingEnabled = True
        Me.cboItemClassReorderWorksheet.Location = New System.Drawing.Point(84, 30)
        Me.cboItemClassReorderWorksheet.Name = "cboItemClassReorderWorksheet"
        Me.cboItemClassReorderWorksheet.Size = New System.Drawing.Size(193, 21)
        Me.cboItemClassReorderWorksheet.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(11, 30)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 20)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Item Class"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InventoryStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrintRackContents)
        Me.Controls.Add(Me.cmdViewWIP)
        Me.Controls.Add(Me.cmdItemMaintenance)
        Me.Controls.Add(Me.lblLoading)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdCountSheet)
        Me.Controls.Add(Me.cmdNegativeInventory)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdUsage)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgvInventoryTotals)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InventoryStatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Status Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventoryTotals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADMInventoryTotalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents TotalPiecesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents chkOmit As System.Windows.Forms.CheckBox
    Friend WithEvents cmdUsage As System.Windows.Forms.Button
    Friend WithEvents InventoryUsageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdReorder As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents ReorderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventoryCountSheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdCountSheet As System.Windows.Forms.Button
    Friend WithEvents PrintListingwPricingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvInventoryTotals As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
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
    Friend WithEvents txtClassTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdNegativeInventory As System.Windows.Forms.Button
    Friend WithEvents NegativeInventoryReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdTWDInventory As System.Windows.Forms.Button
    Friend WithEvents cboSelectByItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents BGLoading As System.ComponentModel.BackgroundWorker
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ADMInventoryTotalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ADMInventoryTotalTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ADMInventoryTotalTableAdapter
    Friend WithEvents cmdItemMaintenance As System.Windows.Forms.Button
    Friend WithEvents cmdViewWIP As System.Windows.Forms.Button
    Friend WithEvents cmdPrintRackContents As System.Windows.Forms.Button
    Friend WithEvents cboSPL As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents SalesProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
    Friend WithEvents chkShowFOX As System.Windows.Forms.CheckBox
    Friend WithEvents HideSOColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HidePOColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideStandardCostColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideStandardPriceColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideMinStockColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideMaxStockColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideFOXColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideQtyReceivedColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideQtyShippedColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideQtyAdjustedColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideCustomerReturnColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideVendorReturnColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideProductionQtyColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideWCProductionColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideAssemblyColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InactivityReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents chkWithoutCommitted As System.Windows.Forms.CheckBox
    Friend WithEvents WCFerruleProductionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboItemClassReorderWorksheet As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenSOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenPOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinimumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaximumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreferredVendorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalReceivedQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalShipQuantityPendingColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorReturnQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerReturnQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WCProductionQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyBuildQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HidePrefVendorColumn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideLeadTimeColumn As System.Windows.Forms.ToolStripMenuItem
End Class
