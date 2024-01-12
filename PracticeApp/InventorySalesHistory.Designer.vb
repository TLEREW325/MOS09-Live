<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventorySalesHistory
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvItemList = New System.Windows.Forms.DataGridView
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.dgvInventorySalesHistory = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinPriceColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxPriceColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearOneQuantityColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearOneSalesColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearTwoQuantityColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearTwoSalesColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearThreeQuantityColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearThreeSalesColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearFourQuantityColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearFourSalesColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearFiveQuantityColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearFiveSalesColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurrentDateColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryFiveYearHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventoryFiveYearHistoryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryFiveYearHistoryTableAdapter
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventorySalesHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryFiveYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboItemClass)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cmdView)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 171)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View By Item Class"
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(94, 66)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(189, 21)
        Me.cboItemClass.TabIndex = 12
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
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(94, 29)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(189, 21)
        Me.cboDivisionID.TabIndex = 19
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Division ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 114)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 11
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(135, 114)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 10
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Item Class"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "Print Listing"
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
        'dgvItemList
        '
        Me.dgvItemList.AllowUserToAddRows = False
        Me.dgvItemList.AllowUserToDeleteRows = False
        Me.dgvItemList.AutoGenerateColumns = False
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemIDColumn, Me.DivisionIDColumn, Me.ShortDescriptionColumn})
        Me.dgvItemList.DataSource = Me.ItemListBindingSource
        Me.dgvItemList.Location = New System.Drawing.Point(29, 455)
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.ReadOnly = True
        Me.dgvItemList.Size = New System.Drawing.Size(300, 356)
        Me.dgvItemList.TabIndex = 21
        Me.dgvItemList.Visible = False
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "ItemID"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "ShortDescription"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        Me.ShortDescriptionColumn.ReadOnly = True
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'dgvInventorySalesHistory
        '
        Me.dgvInventorySalesHistory.AllowUserToAddRows = False
        Me.dgvInventorySalesHistory.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvInventorySalesHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventorySalesHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventorySalesHistory.AutoGenerateColumns = False
        Me.dgvInventorySalesHistory.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventorySalesHistory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventorySalesHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInventorySalesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventorySalesHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn1, Me.PartNumberColumn1, Me.PartDescriptionColumn1, Me.MinPriceColumn1, Me.MaxPriceColumn1, Me.YearOneQuantityColumn1, Me.YearOneSalesColumn1, Me.YearTwoQuantityColumn1, Me.YearTwoSalesColumn1, Me.YearThreeQuantityColumn1, Me.YearThreeSalesColumn1, Me.YearFourQuantityColumn1, Me.YearFourSalesColumn1, Me.YearFiveQuantityColumn1, Me.YearFiveSalesColumn1, Me.ItemClassColumn1, Me.CurrentDateColumn1})
        Me.dgvInventorySalesHistory.DataSource = Me.InventoryFiveYearHistoryBindingSource
        Me.dgvInventorySalesHistory.Location = New System.Drawing.Point(353, 41)
        Me.dgvInventorySalesHistory.Name = "dgvInventorySalesHistory"
        Me.dgvInventorySalesHistory.ReadOnly = True
        Me.dgvInventorySalesHistory.Size = New System.Drawing.Size(677, 710)
        Me.dgvInventorySalesHistory.TabIndex = 22
        '
        'DivisionIDColumn1
        '
        Me.DivisionIDColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn1.HeaderText = "Division"
        Me.DivisionIDColumn1.Name = "DivisionIDColumn1"
        Me.DivisionIDColumn1.ReadOnly = True
        Me.DivisionIDColumn1.Visible = False
        '
        'PartNumberColumn1
        '
        Me.PartNumberColumn1.DataPropertyName = "PartNumber"
        Me.PartNumberColumn1.HeaderText = "Part #"
        Me.PartNumberColumn1.Name = "PartNumberColumn1"
        Me.PartNumberColumn1.ReadOnly = True
        '
        'PartDescriptionColumn1
        '
        Me.PartDescriptionColumn1.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn1.HeaderText = "Description"
        Me.PartDescriptionColumn1.Name = "PartDescriptionColumn1"
        Me.PartDescriptionColumn1.ReadOnly = True
        '
        'MinPriceColumn1
        '
        Me.MinPriceColumn1.DataPropertyName = "MinPrice"
        DataGridViewCellStyle3.Format = "N5"
        DataGridViewCellStyle3.NullValue = "0"
        Me.MinPriceColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.MinPriceColumn1.HeaderText = "Lowest Price (5 yr)"
        Me.MinPriceColumn1.Name = "MinPriceColumn1"
        Me.MinPriceColumn1.ReadOnly = True
        Me.MinPriceColumn1.Width = 90
        '
        'MaxPriceColumn1
        '
        Me.MaxPriceColumn1.DataPropertyName = "MaxPrice"
        DataGridViewCellStyle4.Format = "N5"
        DataGridViewCellStyle4.NullValue = "0"
        Me.MaxPriceColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.MaxPriceColumn1.HeaderText = "Highest Price (5 yr)"
        Me.MaxPriceColumn1.Name = "MaxPriceColumn1"
        Me.MaxPriceColumn1.ReadOnly = True
        Me.MaxPriceColumn1.Width = 90
        '
        'YearOneQuantityColumn1
        '
        Me.YearOneQuantityColumn1.DataPropertyName = "YearOneQuantity"
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.YearOneQuantityColumn1.DefaultCellStyle = DataGridViewCellStyle5
        Me.YearOneQuantityColumn1.HeaderText = "Quantity Sold (1)"
        Me.YearOneQuantityColumn1.Name = "YearOneQuantityColumn1"
        Me.YearOneQuantityColumn1.ReadOnly = True
        Me.YearOneQuantityColumn1.Width = 90
        '
        'YearOneSalesColumn1
        '
        Me.YearOneSalesColumn1.DataPropertyName = "YearOneSales"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.YearOneSalesColumn1.DefaultCellStyle = DataGridViewCellStyle6
        Me.YearOneSalesColumn1.HeaderText = "Total Sales (1)"
        Me.YearOneSalesColumn1.Name = "YearOneSalesColumn1"
        Me.YearOneSalesColumn1.ReadOnly = True
        Me.YearOneSalesColumn1.Width = 90
        '
        'YearTwoQuantityColumn1
        '
        Me.YearTwoQuantityColumn1.DataPropertyName = "YearTwoQuantity"
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.YearTwoQuantityColumn1.DefaultCellStyle = DataGridViewCellStyle7
        Me.YearTwoQuantityColumn1.HeaderText = "Quantity Sold (2)"
        Me.YearTwoQuantityColumn1.Name = "YearTwoQuantityColumn1"
        Me.YearTwoQuantityColumn1.ReadOnly = True
        Me.YearTwoQuantityColumn1.Width = 90
        '
        'YearTwoSalesColumn1
        '
        Me.YearTwoSalesColumn1.DataPropertyName = "YearTwoSales"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.YearTwoSalesColumn1.DefaultCellStyle = DataGridViewCellStyle8
        Me.YearTwoSalesColumn1.HeaderText = "Total Sales (2)"
        Me.YearTwoSalesColumn1.Name = "YearTwoSalesColumn1"
        Me.YearTwoSalesColumn1.ReadOnly = True
        Me.YearTwoSalesColumn1.Width = 90
        '
        'YearThreeQuantityColumn1
        '
        Me.YearThreeQuantityColumn1.DataPropertyName = "YearThreeQuantity"
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = "0"
        Me.YearThreeQuantityColumn1.DefaultCellStyle = DataGridViewCellStyle9
        Me.YearThreeQuantityColumn1.HeaderText = "Quantity Sold (3)"
        Me.YearThreeQuantityColumn1.Name = "YearThreeQuantityColumn1"
        Me.YearThreeQuantityColumn1.ReadOnly = True
        Me.YearThreeQuantityColumn1.Width = 90
        '
        'YearThreeSalesColumn1
        '
        Me.YearThreeSalesColumn1.DataPropertyName = "YearThreeSales"
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.YearThreeSalesColumn1.DefaultCellStyle = DataGridViewCellStyle10
        Me.YearThreeSalesColumn1.HeaderText = "Total Sales (3)"
        Me.YearThreeSalesColumn1.Name = "YearThreeSalesColumn1"
        Me.YearThreeSalesColumn1.ReadOnly = True
        Me.YearThreeSalesColumn1.Width = 90
        '
        'YearFourQuantityColumn1
        '
        Me.YearFourQuantityColumn1.DataPropertyName = "YearFourQuantity"
        DataGridViewCellStyle11.Format = "N0"
        DataGridViewCellStyle11.NullValue = "0"
        Me.YearFourQuantityColumn1.DefaultCellStyle = DataGridViewCellStyle11
        Me.YearFourQuantityColumn1.HeaderText = "Quantity Sold (4)"
        Me.YearFourQuantityColumn1.Name = "YearFourQuantityColumn1"
        Me.YearFourQuantityColumn1.ReadOnly = True
        Me.YearFourQuantityColumn1.Width = 90
        '
        'YearFourSalesColumn1
        '
        Me.YearFourSalesColumn1.DataPropertyName = "YearFourSales"
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = "0"
        Me.YearFourSalesColumn1.DefaultCellStyle = DataGridViewCellStyle12
        Me.YearFourSalesColumn1.HeaderText = "Total Sales (4)"
        Me.YearFourSalesColumn1.Name = "YearFourSalesColumn1"
        Me.YearFourSalesColumn1.ReadOnly = True
        Me.YearFourSalesColumn1.Width = 90
        '
        'YearFiveQuantityColumn1
        '
        Me.YearFiveQuantityColumn1.DataPropertyName = "YearFiveQuantity"
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.NullValue = "0"
        Me.YearFiveQuantityColumn1.DefaultCellStyle = DataGridViewCellStyle13
        Me.YearFiveQuantityColumn1.HeaderText = "Quantity Sold (5)"
        Me.YearFiveQuantityColumn1.Name = "YearFiveQuantityColumn1"
        Me.YearFiveQuantityColumn1.ReadOnly = True
        Me.YearFiveQuantityColumn1.Width = 90
        '
        'YearFiveSalesColumn1
        '
        Me.YearFiveSalesColumn1.DataPropertyName = "YearFiveSales"
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = "0"
        Me.YearFiveSalesColumn1.DefaultCellStyle = DataGridViewCellStyle14
        Me.YearFiveSalesColumn1.HeaderText = "Total Sales (5)"
        Me.YearFiveSalesColumn1.Name = "YearFiveSalesColumn1"
        Me.YearFiveSalesColumn1.ReadOnly = True
        Me.YearFiveSalesColumn1.Width = 90
        '
        'ItemClassColumn1
        '
        Me.ItemClassColumn1.DataPropertyName = "ItemClass"
        Me.ItemClassColumn1.HeaderText = "Item Class"
        Me.ItemClassColumn1.Name = "ItemClassColumn1"
        Me.ItemClassColumn1.ReadOnly = True
        Me.ItemClassColumn1.Visible = False
        '
        'CurrentDateColumn1
        '
        Me.CurrentDateColumn1.DataPropertyName = "CurrentDate"
        Me.CurrentDateColumn1.HeaderText = "Date"
        Me.CurrentDateColumn1.Name = "CurrentDateColumn1"
        Me.CurrentDateColumn1.ReadOnly = True
        '
        'InventoryFiveYearHistoryBindingSource
        '
        Me.InventoryFiveYearHistoryBindingSource.DataMember = "InventoryFiveYearHistory"
        Me.InventoryFiveYearHistoryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InventoryFiveYearHistoryTableAdapter
        '
        Me.InventoryFiveYearHistoryTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(29, 255)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(300, 76)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "This process may take a few moments depending on how many part numbers are in the" & _
            " specified item class."
        '
        'InventorySalesHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvInventorySalesHistory)
        Me.Controls.Add(Me.dgvItemList)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InventorySalesHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Sales History"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventorySalesHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryFiveYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvInventorySalesHistory As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryFiveYearHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryFiveYearHistoryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryFiveYearHistoryTableAdapter
    Friend WithEvents DivisionIDColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinPriceColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxPriceColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearOneQuantityColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearOneSalesColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearTwoQuantityColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearTwoSalesColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearThreeQuantityColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearThreeSalesColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearFourQuantityColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearFourSalesColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearFiveQuantityColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearFiveSalesColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrentDateColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
