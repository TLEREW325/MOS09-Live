<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemPriceSheet
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvPriceSheets = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B100To199Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B200To299Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B300To399Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B400To499Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B500To749Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B750To999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B1000To2499Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B2500To4999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B5000To9999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B10000To24999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B25000To49999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B50000To99999Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B100000AndUpColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardUnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardUnitPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchProdLineIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesProdLineIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemPriceSheetQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardUnitCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardUnitPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.To199DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gpxPartData = New System.Windows.Forms.GroupBox
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdOpenItemForm = New System.Windows.Forms.Button
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtAveragePrice = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtAverageCost = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtLastPrice = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtLastCost = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtStandardPrice = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtStandardCost = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ItemPriceSheetQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemPriceSheetQueryTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPriceSheets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemPriceSheetQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxPartData.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 772)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearDataToolStripMenuItem, Me.SaveDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear Data"
        '
        'SaveDataToolStripMenuItem
        '
        Me.SaveDataToolStripMenuItem.Name = "SaveDataToolStripMenuItem"
        Me.SaveDataToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.SaveDataToolStripMenuItem.Text = "Save Data"
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
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(137, 388)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 4
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 388)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 772)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(96, 26)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(189, 21)
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
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(96, 91)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvPriceSheets
        '
        Me.dgvPriceSheets.AllowUserToAddRows = False
        Me.dgvPriceSheets.AllowUserToDeleteRows = False
        Me.dgvPriceSheets.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvPriceSheets.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPriceSheets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPriceSheets.AutoGenerateColumns = False
        Me.dgvPriceSheets.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPriceSheets.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPriceSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPriceSheets.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.B100To199Column, Me.B200To299Column, Me.B300To399Column, Me.B400To499Column, Me.B500To749Column, Me.B750To999Column, Me.B1000To2499Column, Me.B2500To4999Column, Me.B5000To9999Column, Me.B10000To24999Column, Me.B25000To49999Column, Me.B50000To99999Column, Me.B100000AndUpColumn, Me.StandardUnitCostColumn, Me.StandardUnitPriceColumn, Me.ItemClassColumn, Me.PurchProdLineIDColumn, Me.SalesProdLineIDColumn})
        Me.dgvPriceSheets.DataSource = Me.ItemPriceSheetQueryBindingSource
        Me.dgvPriceSheets.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvPriceSheets.Location = New System.Drawing.Point(353, 41)
        Me.dgvPriceSheets.Name = "dgvPriceSheets"
        Me.dgvPriceSheets.ReadOnly = True
        Me.dgvPriceSheets.Size = New System.Drawing.Size(777, 724)
        Me.dgvPriceSheets.TabIndex = 6
        Me.dgvPriceSheets.TabStop = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        '
        'B100To199Column
        '
        Me.B100To199Column.DataPropertyName = "B100To199"
        Me.B100To199Column.HeaderText = "100 To 199"
        Me.B100To199Column.Name = "B100To199Column"
        Me.B100To199Column.ReadOnly = True
        '
        'B200To299Column
        '
        Me.B200To299Column.DataPropertyName = "B200To299"
        Me.B200To299Column.HeaderText = "200 To 299"
        Me.B200To299Column.Name = "B200To299Column"
        Me.B200To299Column.ReadOnly = True
        '
        'B300To399Column
        '
        Me.B300To399Column.DataPropertyName = "B300To399"
        Me.B300To399Column.HeaderText = "300 To 399"
        Me.B300To399Column.Name = "B300To399Column"
        Me.B300To399Column.ReadOnly = True
        '
        'B400To499Column
        '
        Me.B400To499Column.DataPropertyName = "B400To499"
        Me.B400To499Column.HeaderText = "400 To 499"
        Me.B400To499Column.Name = "B400To499Column"
        Me.B400To499Column.ReadOnly = True
        '
        'B500To749Column
        '
        Me.B500To749Column.DataPropertyName = "B500To749"
        Me.B500To749Column.HeaderText = "500 To 749"
        Me.B500To749Column.Name = "B500To749Column"
        Me.B500To749Column.ReadOnly = True
        '
        'B750To999Column
        '
        Me.B750To999Column.DataPropertyName = "B750To999"
        Me.B750To999Column.HeaderText = "750 To 999"
        Me.B750To999Column.Name = "B750To999Column"
        Me.B750To999Column.ReadOnly = True
        '
        'B1000To2499Column
        '
        Me.B1000To2499Column.DataPropertyName = "B1000To2499"
        Me.B1000To2499Column.HeaderText = "1000 To 2499"
        Me.B1000To2499Column.Name = "B1000To2499Column"
        Me.B1000To2499Column.ReadOnly = True
        '
        'B2500To4999Column
        '
        Me.B2500To4999Column.DataPropertyName = "B2500To4999"
        Me.B2500To4999Column.HeaderText = "2500 To 4999"
        Me.B2500To4999Column.Name = "B2500To4999Column"
        Me.B2500To4999Column.ReadOnly = True
        '
        'B5000To9999Column
        '
        Me.B5000To9999Column.DataPropertyName = "B5000To9999"
        Me.B5000To9999Column.HeaderText = "5000 To 9999"
        Me.B5000To9999Column.Name = "B5000To9999Column"
        Me.B5000To9999Column.ReadOnly = True
        '
        'B10000To24999Column
        '
        Me.B10000To24999Column.DataPropertyName = "B10000To24999"
        Me.B10000To24999Column.HeaderText = "10000 To 24999"
        Me.B10000To24999Column.Name = "B10000To24999Column"
        Me.B10000To24999Column.ReadOnly = True
        '
        'B25000To49999Column
        '
        Me.B25000To49999Column.DataPropertyName = "B25000To49999"
        Me.B25000To49999Column.HeaderText = "25000 To 49999"
        Me.B25000To49999Column.Name = "B25000To49999Column"
        Me.B25000To49999Column.ReadOnly = True
        '
        'B50000To99999Column
        '
        Me.B50000To99999Column.DataPropertyName = "B50000To99999"
        Me.B50000To99999Column.HeaderText = "50000 To 99999"
        Me.B50000To99999Column.Name = "B50000To99999Column"
        Me.B50000To99999Column.ReadOnly = True
        '
        'B100000AndUpColumn
        '
        Me.B100000AndUpColumn.DataPropertyName = "B100000AndUp"
        Me.B100000AndUpColumn.HeaderText = "100000 And Up"
        Me.B100000AndUpColumn.Name = "B100000AndUpColumn"
        Me.B100000AndUpColumn.ReadOnly = True
        '
        'StandardUnitCostColumn
        '
        Me.StandardUnitCostColumn.DataPropertyName = "StandardUnitCost"
        Me.StandardUnitCostColumn.HeaderText = "Std. Cost"
        Me.StandardUnitCostColumn.Name = "StandardUnitCostColumn"
        Me.StandardUnitCostColumn.ReadOnly = True
        '
        'StandardUnitPriceColumn
        '
        Me.StandardUnitPriceColumn.DataPropertyName = "StandardUnitPrice"
        Me.StandardUnitPriceColumn.HeaderText = "Std. Price"
        Me.StandardUnitPriceColumn.Name = "StandardUnitPriceColumn"
        Me.StandardUnitPriceColumn.ReadOnly = True
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.ReadOnly = True
        '
        'PurchProdLineIDColumn
        '
        Me.PurchProdLineIDColumn.DataPropertyName = "PurchProdLineID"
        Me.PurchProdLineIDColumn.HeaderText = "PurchProdLineID"
        Me.PurchProdLineIDColumn.Name = "PurchProdLineIDColumn"
        Me.PurchProdLineIDColumn.ReadOnly = True
        Me.PurchProdLineIDColumn.Visible = False
        '
        'SalesProdLineIDColumn
        '
        Me.SalesProdLineIDColumn.DataPropertyName = "SalesProdLineID"
        Me.SalesProdLineIDColumn.HeaderText = "SalesProdLineID"
        Me.SalesProdLineIDColumn.Name = "SalesProdLineIDColumn"
        Me.SalesProdLineIDColumn.ReadOnly = True
        Me.SalesProdLineIDColumn.Visible = False
        '
        'ItemPriceSheetQueryBindingSource
        '
        Me.ItemPriceSheetQueryBindingSource.DataMember = "ItemPriceSheetQuery"
        Me.ItemPriceSheetQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part Number"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        '
        'PartDescriptionDataGridViewTextBoxColumn
        '
        Me.PartDescriptionDataGridViewTextBoxColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionDataGridViewTextBoxColumn.HeaderText = "Part Description"
        Me.PartDescriptionDataGridViewTextBoxColumn.Name = "PartDescriptionDataGridViewTextBoxColumn"
        '
        'StandardUnitCostDataGridViewTextBoxColumn
        '
        Me.StandardUnitCostDataGridViewTextBoxColumn.DataPropertyName = "StandardUnitCost"
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.StandardUnitCostDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.StandardUnitCostDataGridViewTextBoxColumn.HeaderText = "Standard Unit Cost"
        Me.StandardUnitCostDataGridViewTextBoxColumn.Name = "StandardUnitCostDataGridViewTextBoxColumn"
        Me.StandardUnitCostDataGridViewTextBoxColumn.Width = 80
        '
        'StandardUnitPriceDataGridViewTextBoxColumn
        '
        Me.StandardUnitPriceDataGridViewTextBoxColumn.DataPropertyName = "StandardUnitPrice"
        DataGridViewCellStyle3.Format = "N4"
        DataGridViewCellStyle3.NullValue = "0"
        Me.StandardUnitPriceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.StandardUnitPriceDataGridViewTextBoxColumn.HeaderText = "Standard Unit Price"
        Me.StandardUnitPriceDataGridViewTextBoxColumn.Name = "StandardUnitPriceDataGridViewTextBoxColumn"
        Me.StandardUnitPriceDataGridViewTextBoxColumn.Width = 80
        '
        'To199DataGridViewTextBoxColumn
        '
        Me.To199DataGridViewTextBoxColumn.DataPropertyName = "100To199"
        DataGridViewCellStyle4.Format = "C4"
        DataGridViewCellStyle4.NullValue = "0"
        Me.To199DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.To199DataGridViewTextBoxColumn.HeaderText = "100 To 199"
        Me.To199DataGridViewTextBoxColumn.Name = "To199DataGridViewTextBoxColumn"
        Me.To199DataGridViewTextBoxColumn.Width = 80
        '
        'gpxPartData
        '
        Me.gpxPartData.Controls.Add(Me.txtSearch)
        Me.gpxPartData.Controls.Add(Me.Label11)
        Me.gpxPartData.Controls.Add(Me.cboItemClass)
        Me.gpxPartData.Controls.Add(Me.txtLongDescription)
        Me.gpxPartData.Controls.Add(Me.cboDivisionID)
        Me.gpxPartData.Controls.Add(Me.cboPartNumber)
        Me.gpxPartData.Controls.Add(Me.cboPartDescription)
        Me.gpxPartData.Controls.Add(Me.cmdClear)
        Me.gpxPartData.Controls.Add(Me.cmdView)
        Me.gpxPartData.Controls.Add(Me.Label4)
        Me.gpxPartData.Controls.Add(Me.Label5)
        Me.gpxPartData.Controls.Add(Me.Label3)
        Me.gpxPartData.Location = New System.Drawing.Point(29, 41)
        Me.gpxPartData.Name = "gpxPartData"
        Me.gpxPartData.Size = New System.Drawing.Size(300, 435)
        Me.gpxPartData.TabIndex = 0
        Me.gpxPartData.TabStop = False
        Me.gpxPartData.Text = "View By Filters"
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(96, 322)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(189, 20)
        Me.txtSearch.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(15, 322)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Text Search"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(96, 260)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(189, 21)
        Me.cboItemClass.TabIndex = 6
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BackColor = System.Drawing.SystemColors.Control
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLongDescription.Location = New System.Drawing.Point(18, 157)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(267, 66)
        Me.txtLongDescription.TabIndex = 3
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(18, 124)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(267, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Part Number"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Division ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 261)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Item Class"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenItemForm
        '
        Me.cmdOpenItemForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenItemForm.Location = New System.Drawing.Point(353, 772)
        Me.cmdOpenItemForm.Name = "cmdOpenItemForm"
        Me.cmdOpenItemForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenItemForm.TabIndex = 13
        Me.cmdOpenItemForm.Text = "Item Form"
        Me.cmdOpenItemForm.UseVisualStyleBackColor = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(430, 772)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 42)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Opens Item Maintenance Form and closes this form..."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtAveragePrice)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtAverageCost)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtLastPrice)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtLastCost)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtStandardPrice)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtStandardCost)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 540)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 271)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Part Number Cost / Price"
        '
        'txtAveragePrice
        '
        Me.txtAveragePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAveragePrice.Location = New System.Drawing.Point(137, 229)
        Me.txtAveragePrice.Name = "txtAveragePrice"
        Me.txtAveragePrice.Size = New System.Drawing.Size(150, 20)
        Me.txtAveragePrice.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 229)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Average Price"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAverageCost
        '
        Me.txtAverageCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAverageCost.Location = New System.Drawing.Point(137, 202)
        Me.txtAverageCost.Name = "txtAverageCost"
        Me.txtAverageCost.Size = New System.Drawing.Size(150, 20)
        Me.txtAverageCost.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 202)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Average Cost"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLastPrice
        '
        Me.txtLastPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastPrice.Location = New System.Drawing.Point(137, 141)
        Me.txtLastPrice.Name = "txtLastPrice"
        Me.txtLastPrice.Size = New System.Drawing.Size(150, 20)
        Me.txtLastPrice.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Last Sale Price"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLastCost
        '
        Me.txtLastCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastCost.Location = New System.Drawing.Point(137, 114)
        Me.txtLastCost.Name = "txtLastCost"
        Me.txtLastCost.Size = New System.Drawing.Size(150, 20)
        Me.txtLastCost.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Last Purchase Cost"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStandardPrice
        '
        Me.txtStandardPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStandardPrice.Location = New System.Drawing.Point(137, 55)
        Me.txtStandardPrice.Name = "txtStandardPrice"
        Me.txtStandardPrice.Size = New System.Drawing.Size(150, 20)
        Me.txtStandardPrice.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Standard Price"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStandardCost
        '
        Me.txtStandardCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStandardCost.Location = New System.Drawing.Point(137, 28)
        Me.txtStandardCost.Name = "txtStandardCost"
        Me.txtStandardCost.Size = New System.Drawing.Size(150, 20)
        Me.txtStandardCost.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Standard Cost"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ItemPriceSheetQueryTableAdapter
        '
        Me.ItemPriceSheetQueryTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'ItemPriceSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdOpenItemForm)
        Me.Controls.Add(Me.gpxPartData)
        Me.Controls.Add(Me.dgvPriceSheets)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ItemPriceSheet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Item Price Sheets"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPriceSheets, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemPriceSheetQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxPartData.ResumeLayout(False)
        Me.gpxPartData.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents dgvPriceSheets As System.Windows.Forms.DataGridView
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents To299DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardUnitCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardUnitPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To199DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To199DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To399DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To499DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To749DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To2499DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To4999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To9999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To24999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To49999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents To99999DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AndUpDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gpxPartData As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenItemForm As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAveragePrice As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAverageCost As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLastPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLastCost As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtStandardPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStandardCost As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ItemPriceSheetQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemPriceSheetQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemPriceSheetQueryTableAdapter
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B100To199Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B200To299Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B300To399Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B400To499Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B500To749Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B750To999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B1000To2499Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B2500To4999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B5000To9999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B10000To24999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B25000To49999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B50000To99999Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B100000AndUpColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardUnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardUnitPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchProdLineIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesProdLineIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
