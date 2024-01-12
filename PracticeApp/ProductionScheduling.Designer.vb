<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionScheduling
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewProductionOrderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintWorkOrderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintProductionOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdViewProductionOrder = New System.Windows.Forms.Button
        Me.cmdPrintWorkOrder = New System.Windows.Forms.Button
        Me.cmdProductionOrder = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvProductionScheduling = New System.Windows.Forms.DataGridView
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHandColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GetBlanksColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinimumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaximumStockColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommittedQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ManufactureQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelRequiredColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelQOHColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PromiseDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXPromiseDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesProdLineIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductionSchedulingFinishedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.ProductionSchedulingFinishedTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ProductionSchedulingFinishedTableAdapter
        Me.gpxFilters = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.FOXTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.cmdClearFilters = New System.Windows.Forms.Button
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.FOXTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblMessage = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvProductionScheduling, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductionSchedulingFinishedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxFilters.SuspendLayout()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1192, 24)
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewProductionOrderToolStripMenuItem1})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ViewProductionOrderToolStripMenuItem1
        '
        Me.ViewProductionOrderToolStripMenuItem1.Name = "ViewProductionOrderToolStripMenuItem1"
        Me.ViewProductionOrderToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ViewProductionOrderToolStripMenuItem1.Text = "View Production Order"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem, Me.PrintWorkOrderToolStripMenuItem1, Me.PrintProductionOrderToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
        '
        'PrintWorkOrderToolStripMenuItem1
        '
        Me.PrintWorkOrderToolStripMenuItem1.Name = "PrintWorkOrderToolStripMenuItem1"
        Me.PrintWorkOrderToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.PrintWorkOrderToolStripMenuItem1.Text = "Print Work Order"
        '
        'PrintProductionOrderToolStripMenuItem
        '
        Me.PrintProductionOrderToolStripMenuItem.Name = "PrintProductionOrderToolStripMenuItem"
        Me.PrintProductionOrderToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.PrintProductionOrderToolStripMenuItem.Text = "Print Production Order"
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
        'cmdViewProductionOrder
        '
        Me.cmdViewProductionOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewProductionOrder.Location = New System.Drawing.Point(497, 726)
        Me.cmdViewProductionOrder.Name = "cmdViewProductionOrder"
        Me.cmdViewProductionOrder.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewProductionOrder.TabIndex = 22
        Me.cmdViewProductionOrder.Text = "View Prod. Order"
        Me.cmdViewProductionOrder.UseVisualStyleBackColor = True
        '
        'cmdPrintWorkOrder
        '
        Me.cmdPrintWorkOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintWorkOrder.Location = New System.Drawing.Point(497, 672)
        Me.cmdPrintWorkOrder.Name = "cmdPrintWorkOrder"
        Me.cmdPrintWorkOrder.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintWorkOrder.TabIndex = 23
        Me.cmdPrintWorkOrder.Text = "Print Work Order"
        Me.cmdPrintWorkOrder.UseVisualStyleBackColor = True
        '
        'cmdProductionOrder
        '
        Me.cmdProductionOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdProductionOrder.Location = New System.Drawing.Point(497, 780)
        Me.cmdProductionOrder.Name = "cmdProductionOrder"
        Me.cmdProductionOrder.Size = New System.Drawing.Size(71, 40)
        Me.cmdProductionOrder.TabIndex = 24
        Me.cmdProductionOrder.Text = "Print Prod. Order"
        Me.cmdProductionOrder.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(1032, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 25
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1109, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 26
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvProductionScheduling
        '
        Me.dgvProductionScheduling.AllowUserToAddRows = False
        Me.dgvProductionScheduling.AllowUserToDeleteRows = False
        Me.dgvProductionScheduling.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProductionScheduling.AutoGenerateColumns = False
        Me.dgvProductionScheduling.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvProductionScheduling.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvProductionScheduling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductionScheduling.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FOXNumberColumn, Me.ShortDescriptionColumn, Me.ItemIDColumn, Me.QuantityOnHandColumn, Me.GetBlanksColumn, Me.MinimumStockColumn, Me.MaximumStockColumn, Me.CommittedQuantityColumn, Me.ManufactureQuantityColumn, Me.RMIDColumn, Me.SteelRequiredColumn, Me.SteelQOHColumn, Me.PromiseDateColumn, Me.FOXPromiseDateColumn, Me.PieceWeightColumn, Me.ItemClassColumn, Me.SalesProdLineIDColumn, Me.DivisionIDColumn})
        Me.dgvProductionScheduling.DataSource = Me.ProductionSchedulingFinishedBindingSource
        Me.dgvProductionScheduling.GridColor = System.Drawing.Color.Purple
        Me.dgvProductionScheduling.Location = New System.Drawing.Point(12, 27)
        Me.dgvProductionScheduling.Name = "dgvProductionScheduling"
        Me.dgvProductionScheduling.Size = New System.Drawing.Size(1168, 628)
        Me.dgvProductionScheduling.TabIndex = 27
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FOXNumberColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.FOXNumberColumn.Frozen = True
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        Me.FOXNumberColumn.Width = 70
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.Frozen = True
        Me.ShortDescriptionColumn.HeaderText = "Description"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        Me.ShortDescriptionColumn.ReadOnly = True
        Me.ShortDescriptionColumn.Width = 300
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.Frozen = True
        Me.ItemIDColumn.HeaderText = "Part #"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        Me.ItemIDColumn.Width = 120
        '
        'QuantityOnHandColumn
        '
        Me.QuantityOnHandColumn.DataPropertyName = "QuantityOnHand"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.QuantityOnHandColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.QuantityOnHandColumn.HeaderText = "QOH"
        Me.QuantityOnHandColumn.Name = "QuantityOnHandColumn"
        Me.QuantityOnHandColumn.ReadOnly = True
        Me.QuantityOnHandColumn.Width = 80
        '
        'GetBlanksColumn
        '
        Me.GetBlanksColumn.HeaderText = "Blanks"
        Me.GetBlanksColumn.Name = "GetBlanksColumn"
        Me.GetBlanksColumn.ReadOnly = True
        Me.GetBlanksColumn.Width = 80
        '
        'MinimumStockColumn
        '
        Me.MinimumStockColumn.DataPropertyName = "MinimumStock"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.MinimumStockColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.MinimumStockColumn.HeaderText = "Min Stock"
        Me.MinimumStockColumn.Name = "MinimumStockColumn"
        Me.MinimumStockColumn.ReadOnly = True
        Me.MinimumStockColumn.Width = 80
        '
        'MaximumStockColumn
        '
        Me.MaximumStockColumn.DataPropertyName = "MaximumStock"
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.MaximumStockColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.MaximumStockColumn.HeaderText = "Max Stock"
        Me.MaximumStockColumn.Name = "MaximumStockColumn"
        Me.MaximumStockColumn.ReadOnly = True
        Me.MaximumStockColumn.Width = 80
        '
        'CommittedQuantityColumn
        '
        Me.CommittedQuantityColumn.DataPropertyName = "CommittedQuantity"
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.CommittedQuantityColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.CommittedQuantityColumn.HeaderText = "Committed Qty"
        Me.CommittedQuantityColumn.Name = "CommittedQuantityColumn"
        Me.CommittedQuantityColumn.ReadOnly = True
        Me.CommittedQuantityColumn.Width = 80
        '
        'ManufactureQuantityColumn
        '
        Me.ManufactureQuantityColumn.DataPropertyName = "ManufactureQuantity"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.ManufactureQuantityColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ManufactureQuantityColumn.HeaderText = "Manufacture Qty"
        Me.ManufactureQuantityColumn.Name = "ManufactureQuantityColumn"
        Me.ManufactureQuantityColumn.ReadOnly = True
        Me.ManufactureQuantityColumn.Width = 80
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "Steel"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        '
        'SteelRequiredColumn
        '
        Me.SteelRequiredColumn.DataPropertyName = "SteelRequired"
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.SteelRequiredColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.SteelRequiredColumn.HeaderText = "Steel Req. (lbs)"
        Me.SteelRequiredColumn.Name = "SteelRequiredColumn"
        Me.SteelRequiredColumn.ReadOnly = True
        '
        'SteelQOHColumn
        '
        Me.SteelQOHColumn.DataPropertyName = "SteelQOH"
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = "0"
        Me.SteelQOHColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.SteelQOHColumn.HeaderText = "Steel QOH"
        Me.SteelQOHColumn.Name = "SteelQOHColumn"
        Me.SteelQOHColumn.ReadOnly = True
        '
        'PromiseDateColumn
        '
        Me.PromiseDateColumn.HeaderText = "Lead Time Date"
        Me.PromiseDateColumn.Name = "PromiseDateColumn"
        Me.PromiseDateColumn.ReadOnly = True
        '
        'FOXPromiseDateColumn
        '
        Me.FOXPromiseDateColumn.DataPropertyName = "FOXPromiseDate"
        Me.FOXPromiseDateColumn.HeaderText = "FOX Promise Date"
        Me.FOXPromiseDateColumn.Name = "FOXPromiseDateColumn"
        '
        'PieceWeightColumn
        '
        Me.PieceWeightColumn.DataPropertyName = "PieceWeight"
        Me.PieceWeightColumn.HeaderText = "Piece Weight"
        Me.PieceWeightColumn.Name = "PieceWeightColumn"
        Me.PieceWeightColumn.ReadOnly = True
        Me.PieceWeightColumn.Visible = False
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.ReadOnly = True
        Me.ItemClassColumn.Visible = False
        '
        'SalesProdLineIDColumn
        '
        Me.SalesProdLineIDColumn.DataPropertyName = "SalesProdLineID"
        Me.SalesProdLineIDColumn.HeaderText = "SalesProdLineID"
        Me.SalesProdLineIDColumn.Name = "SalesProdLineIDColumn"
        Me.SalesProdLineIDColumn.ReadOnly = True
        Me.SalesProdLineIDColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'ProductionSchedulingFinishedBindingSource
        '
        Me.ProductionSchedulingFinishedBindingSource.DataMember = "ProductionSchedulingFinished"
        Me.ProductionSchedulingFinishedBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProductionSchedulingFinishedTableAdapter
        '
        Me.ProductionSchedulingFinishedTableAdapter.ClearBeforeFill = True
        '
        'gpxFilters
        '
        Me.gpxFilters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpxFilters.Controls.Add(Me.Label2)
        Me.gpxFilters.Controls.Add(Me.Label3)
        Me.gpxFilters.Controls.Add(Me.cboFOXNumber)
        Me.gpxFilters.Controls.Add(Me.txtTextFilter)
        Me.gpxFilters.Controls.Add(Me.cmdClearFilters)
        Me.gpxFilters.Controls.Add(Me.cmdViewByFilter)
        Me.gpxFilters.Controls.Add(Me.Label1)
        Me.gpxFilters.Controls.Add(Me.cboItemClass)
        Me.gpxFilters.Location = New System.Drawing.Point(12, 661)
        Me.gpxFilters.Name = "gpxFilters"
        Me.gpxFilters.Size = New System.Drawing.Size(335, 159)
        Me.gpxFilters.TabIndex = 28
        Me.gpxFilters.TabStop = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Begins With"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "FOX #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.DataSource = Me.FOXTableBindingSource
        Me.cboFOXNumber.DisplayMember = "FOXNumber"
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(124, 52)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(196, 21)
        Me.cboFOXNumber.TabIndex = 29
        '
        'FOXTableBindingSource
        '
        Me.FOXTableBindingSource.DataMember = "FOXTable"
        Me.FOXTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(124, 83)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(196, 20)
        Me.txtTextFilter.TabIndex = 30
        '
        'cmdClearFilters
        '
        Me.cmdClearFilters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearFilters.Location = New System.Drawing.Point(249, 120)
        Me.cmdClearFilters.Name = "cmdClearFilters"
        Me.cmdClearFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearFilters.TabIndex = 29
        Me.cmdClearFilters.Text = "Clear"
        Me.cmdClearFilters.UseVisualStyleBackColor = True
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewByFilter.Location = New System.Drawing.Point(172, 120)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 23
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Item Class"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Items.AddRange(New Object() {"CA/SC/DSC", "TP/TT", "CS", "NT", "PSR", "DBA", "SWR/HSR", "GS", "KO", "HX", "TR/TDR", "Trufit Parts", "TWE Parts", "Misc Production"})
        Me.cboItemClass.Location = New System.Drawing.Point(124, 21)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(196, 21)
        Me.cboItemClass.TabIndex = 0
        '
        'FOXTableTableAdapter
        '
        Me.FOXTableTableAdapter.ClearBeforeFill = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(874, 718)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(298, 18)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "- Indicates material needed is greater than material on hand."
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.LightCoral
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Location = New System.Drawing.Point(843, 717)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 20)
        Me.Label7.TabIndex = 32
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(874, 682)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(306, 17)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "- Indicates Sales order quantity is greater than quantity on hand"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.LightBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(843, 680)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 20)
        Me.Label4.TabIndex = 30
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblMessage.Location = New System.Drawing.Point(585, 671)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(196, 40)
        Me.lblMessage.TabIndex = 29
        Me.lblMessage.Text = "Click here or double-click in datagrid to print Work Order."
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(585, 779)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(196, 40)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Click here to print Production Work Order."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(585, 725)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(196, 40)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Click here to view Work Order on screen."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductionScheduling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 823)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.gpxFilters)
        Me.Controls.Add(Me.dgvProductionScheduling)
        Me.Controls.Add(Me.cmdViewProductionOrder)
        Me.Controls.Add(Me.cmdPrintWorkOrder)
        Me.Controls.Add(Me.cmdProductionOrder)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ProductionScheduling"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Production Scheduling"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvProductionScheduling, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductionSchedulingFinishedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxFilters.ResumeLayout(False)
        Me.gpxFilters.PerformLayout()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdViewProductionOrder As System.Windows.Forms.Button
    Friend WithEvents cmdPrintWorkOrder As System.Windows.Forms.Button
    Friend WithEvents cmdProductionOrder As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvProductionScheduling As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ProductionSchedulingFinishedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProductionSchedulingFinishedTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ProductionSchedulingFinishedTableAdapter
    Friend WithEvents gpxFilters As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClearFilters As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents FOXTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOXTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ViewProductionOrderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintWorkOrderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintProductionOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHandColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GetBlanksColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinimumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaximumStockColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommittedQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ManufactureQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelRequiredColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelQOHColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PromiseDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXPromiseDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesProdLineIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
