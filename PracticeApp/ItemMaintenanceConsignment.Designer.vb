<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemMaintenanceConsignment
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblWarehouseCode = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboWareName = New System.Windows.Forms.ComboBox
        Me.FOBTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.FOBTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOBTableTableAdapter
        Me.dgvItemList = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchProdLineIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesProdLineIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.PurchaseProductLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PurchaseProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
        Me.SalesProductLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SalesProductLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboSPL = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboPPL = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPieceWeight = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtBoxCount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtBoxWeight = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtPiecesPerPallet = New System.Windows.Forms.TextBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtDivisionQOH = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtWarehouseQOH = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtPalletWeight = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPalletCount = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.FOBTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cboDivisionID)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lblWarehouseCode)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboWareName)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 144)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Warehouse"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Company Division"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Items.AddRange(New Object() {"TWD", "TWE", "TFF"})
        Me.cboDivisionID.Location = New System.Drawing.Point(124, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(159, 21)
        Me.cboDivisionID.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Warehouse Code"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWarehouseCode
        '
        Me.lblWarehouseCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWarehouseCode.Location = New System.Drawing.Point(124, 106)
        Me.lblWarehouseCode.Name = "lblWarehouseCode"
        Me.lblWarehouseCode.Size = New System.Drawing.Size(159, 23)
        Me.lblWarehouseCode.TabIndex = 4
        Me.lblWarehouseCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Warehouse Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboWareName
        '
        Me.cboWareName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboWareName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboWareName.DataSource = Me.FOBTableBindingSource
        Me.cboWareName.DisplayMember = "FOBName"
        Me.cboWareName.FormattingEnabled = True
        Me.cboWareName.Location = New System.Drawing.Point(124, 68)
        Me.cboWareName.Name = "cboWareName"
        Me.cboWareName.Size = New System.Drawing.Size(159, 21)
        Me.cboWareName.TabIndex = 3
        '
        'FOBTableBindingSource
        '
        Me.FOBTableBindingSource.DataMember = "FOBTable"
        Me.FOBTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FOBTableTableAdapter
        '
        Me.FOBTableTableAdapter.ClearBeforeFill = True
        '
        'dgvItemList
        '
        Me.dgvItemList.AllowUserToAddRows = False
        Me.dgvItemList.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvItemList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItemList.AutoGenerateColumns = False
        Me.dgvItemList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvItemList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.ItemIDColumn, Me.ShortDescriptionColumn, Me.ItemClassColumn, Me.PurchProdLineIDColumn, Me.SalesProdLineIDColumn, Me.PieceWeightColumn, Me.BoxCountColumn, Me.PalletCountColumn, Me.BoxWeightColumn})
        Me.dgvItemList.DataSource = Me.ItemListBindingSource
        Me.dgvItemList.GridColor = System.Drawing.Color.Lime
        Me.dgvItemList.Location = New System.Drawing.Point(346, 41)
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.Size = New System.Drawing.Size(684, 724)
        Me.dgvItemList.TabIndex = 3
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
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
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        '
        'PurchProdLineIDColumn
        '
        Me.PurchProdLineIDColumn.DataPropertyName = "PurchProdLineID"
        Me.PurchProdLineIDColumn.HeaderText = "PPL"
        Me.PurchProdLineIDColumn.Name = "PurchProdLineIDColumn"
        '
        'SalesProdLineIDColumn
        '
        Me.SalesProdLineIDColumn.DataPropertyName = "SalesProdLineID"
        Me.SalesProdLineIDColumn.HeaderText = "SPL"
        Me.SalesProdLineIDColumn.Name = "SalesProdLineIDColumn"
        '
        'PieceWeightColumn
        '
        Me.PieceWeightColumn.DataPropertyName = "PieceWeight"
        Me.PieceWeightColumn.HeaderText = "Piece Weight"
        Me.PieceWeightColumn.Name = "PieceWeightColumn"
        '
        'BoxCountColumn
        '
        Me.BoxCountColumn.DataPropertyName = "BoxCount"
        Me.BoxCountColumn.HeaderText = "Box Count"
        Me.BoxCountColumn.Name = "BoxCountColumn"
        '
        'PalletCountColumn
        '
        Me.PalletCountColumn.DataPropertyName = "PalletCount"
        Me.PalletCountColumn.HeaderText = "Pallet Count"
        Me.PalletCountColumn.Name = "PalletCountColumn"
        '
        'BoxWeightColumn
        '
        Me.BoxWeightColumn.DataPropertyName = "BoxWeight"
        Me.BoxWeightColumn.HeaderText = "Box Weight"
        Me.BoxWeightColumn.Name = "BoxWeightColumn"
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 775)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 31
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 775)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 32
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'PurchaseProductLineBindingSource
        '
        Me.PurchaseProductLineBindingSource.DataMember = "PurchaseProductLine"
        Me.PurchaseProductLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PurchaseProductLineTableAdapter
        '
        Me.PurchaseProductLineTableAdapter.ClearBeforeFill = True
        '
        'SalesProductLineBindingSource
        '
        Me.SalesProductLineBindingSource.DataMember = "SalesProductLine"
        Me.SalesProductLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SalesProductLineTableAdapter
        '
        Me.SalesProductLineTableAdapter.ClearBeforeFill = True
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(71, 34)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(212, 21)
        Me.cboPartNumber.TabIndex = 0
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(21, 65)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(262, 21)
        Me.cboPartDescription.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Part #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(135, 514)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 32
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(87, 119)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(196, 21)
        Me.cboItemClass.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 23)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Item Class"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSPL
        '
        Me.cboSPL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSPL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSPL.DataSource = Me.PurchaseProductLineBindingSource
        Me.cboSPL.DisplayMember = "PurchaseProductLineID"
        Me.cboSPL.FormattingEnabled = True
        Me.cboSPL.Location = New System.Drawing.Point(87, 156)
        Me.cboSPL.Name = "cboSPL"
        Me.cboSPL.Size = New System.Drawing.Size(196, 21)
        Me.cboSPL.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 23)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Sales Line"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPPL
        '
        Me.cboPPL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPPL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPPL.DataSource = Me.SalesProductLineBindingSource
        Me.cboPPL.DisplayMember = "SalesProdLineID"
        Me.cboPPL.FormattingEnabled = True
        Me.cboPPL.Location = New System.Drawing.Point(87, 192)
        Me.cboPPL.Name = "cboPPL"
        Me.cboPPL.Size = New System.Drawing.Size(196, 21)
        Me.cboPPL.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(18, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 23)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Purch. Line"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPieceWeight
        '
        Me.txtPieceWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPieceWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPieceWeight.Location = New System.Drawing.Point(124, 239)
        Me.txtPieceWeight.Name = "txtPieceWeight"
        Me.txtPieceWeight.Size = New System.Drawing.Size(159, 20)
        Me.txtPieceWeight.TabIndex = 39
        Me.txtPieceWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 272)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 23)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Box Count"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxCount
        '
        Me.txtBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxCount.Location = New System.Drawing.Point(124, 272)
        Me.txtBoxCount.Name = "txtBoxCount"
        Me.txtBoxCount.Size = New System.Drawing.Size(159, 20)
        Me.txtBoxCount.TabIndex = 41
        Me.txtBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 238)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Piece Weight"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxWeight
        '
        Me.txtBoxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxWeight.Location = New System.Drawing.Point(124, 305)
        Me.txtBoxWeight.Name = "txtBoxWeight"
        Me.txtBoxWeight.Size = New System.Drawing.Size(159, 20)
        Me.txtBoxWeight.TabIndex = 43
        Me.txtBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 305)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 23)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Box Weight"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cboPPL)
        Me.GroupBox1.Controls.Add(Me.cboSPL)
        Me.GroupBox1.Controls.Add(Me.txtPiecesPerPallet)
        Me.GroupBox1.Controls.Add(Me.cboItemClass)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtDivisionQOH)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtWarehouseQOH)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtPalletWeight)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtPalletCount)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtBoxWeight)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtBoxCount)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtPieceWeight)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmdSave)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboPartDescription)
        Me.GroupBox1.Controls.Add(Me.cboPartNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 241)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 570)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item Details"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(18, 371)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 23)
        Me.Label15.TabIndex = 54
        Me.Label15.Text = "Pieces/Pallet"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPiecesPerPallet
        '
        Me.txtPiecesPerPallet.BackColor = System.Drawing.Color.White
        Me.txtPiecesPerPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiecesPerPallet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPiecesPerPallet.Location = New System.Drawing.Point(124, 371)
        Me.txtPiecesPerPallet.Name = "txtPiecesPerPallet"
        Me.txtPiecesPerPallet.ReadOnly = True
        Me.txtPiecesPerPallet.Size = New System.Drawing.Size(159, 20)
        Me.txtPiecesPerPallet.TabIndex = 53
        Me.txtPiecesPerPallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(212, 514)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 33
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(18, 470)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 23)
        Me.Label14.TabIndex = 52
        Me.Label14.Text = "Division QOH"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDivisionQOH
        '
        Me.txtDivisionQOH.BackColor = System.Drawing.Color.White
        Me.txtDivisionQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDivisionQOH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDivisionQOH.ForeColor = System.Drawing.Color.Blue
        Me.txtDivisionQOH.Location = New System.Drawing.Point(124, 470)
        Me.txtDivisionQOH.Name = "txtDivisionQOH"
        Me.txtDivisionQOH.ReadOnly = True
        Me.txtDivisionQOH.Size = New System.Drawing.Size(159, 20)
        Me.txtDivisionQOH.TabIndex = 51
        Me.txtDivisionQOH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 437)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 23)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "Warehouse QOH"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtWarehouseQOH
        '
        Me.txtWarehouseQOH.BackColor = System.Drawing.Color.White
        Me.txtWarehouseQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWarehouseQOH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWarehouseQOH.ForeColor = System.Drawing.Color.Blue
        Me.txtWarehouseQOH.Location = New System.Drawing.Point(124, 437)
        Me.txtWarehouseQOH.Name = "txtWarehouseQOH"
        Me.txtWarehouseQOH.ReadOnly = True
        Me.txtWarehouseQOH.Size = New System.Drawing.Size(159, 20)
        Me.txtWarehouseQOH.TabIndex = 49
        Me.txtWarehouseQOH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(18, 404)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "Pallet Weight"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPalletWeight
        '
        Me.txtPalletWeight.BackColor = System.Drawing.Color.White
        Me.txtPalletWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPalletWeight.Location = New System.Drawing.Point(124, 404)
        Me.txtPalletWeight.Name = "txtPalletWeight"
        Me.txtPalletWeight.ReadOnly = True
        Me.txtPalletWeight.Size = New System.Drawing.Size(159, 20)
        Me.txtPalletWeight.TabIndex = 47
        Me.txtPalletWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(18, 338)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 23)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Boxes/Pallet"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPalletCount
        '
        Me.txtPalletCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPalletCount.Location = New System.Drawing.Point(124, 338)
        Me.txtPalletCount.Name = "txtPalletCount"
        Me.txtPalletCount.Size = New System.Drawing.Size(159, 20)
        Me.txtPalletCount.TabIndex = 45
        Me.txtPalletCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ItemMaintenanceConsignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvItemList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ItemMaintenanceConsignment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Consignment Item Maintenance"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.FOBTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesProductLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblWarehouseCode As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboWareName As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents FOBTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOBTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOBTableTableAdapter
    Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents PurchaseProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseProductLineTableAdapter
    Friend WithEvents SalesProductLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesProductLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesProductLineTableAdapter
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboSPL As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboPPL As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPieceWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBoxCount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBoxWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtWarehouseQOH As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPalletWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPalletCount As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDivisionQOH As System.Windows.Forms.TextBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPiecesPerPallet As System.Windows.Forms.TextBox
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchProdLineIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesProdLineIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
