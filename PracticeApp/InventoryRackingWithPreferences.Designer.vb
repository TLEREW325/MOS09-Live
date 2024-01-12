<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryRackingWithPreferences
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
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxRackFilters = New System.Windows.Forms.GroupBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtPartTextStartsWith = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtRackTextContains = New System.Windows.Forms.TextBox
        Me.txtPartTextContains = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.txtLotNumber = New System.Windows.Forms.TextBox
        Me.txtHeatNumber = New System.Windows.Forms.TextBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cboRackNumber = New System.Windows.Forms.ComboBox
        Me.BinNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.dgvInventoryRacking = New System.Windows.Forms.DataGridView
        Me.RackingKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiecesPerBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActivityDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AddedByColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickTicketColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingTransactionQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RackingTransactionQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionQueryTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.BinNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinNumberTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.gpxAddToRack = New System.Windows.Forms.GroupBox
        Me.chkPalletLabel = New System.Windows.Forms.CheckBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.rdoAddBoxes = New System.Windows.Forms.RadioButton
        Me.rdoAddPallet = New System.Windows.Forms.RadioButton
        Me.txtPieceWeight = New System.Windows.Forms.TextBox
        Me.txtAddBoxWeight = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtRackComment = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboAddToPartDescription = New System.Windows.Forms.ComboBox
        Me.cboAddToPartNumber = New System.Windows.Forms.ComboBox
        Me.txtAddHeatNumber = New System.Windows.Forms.TextBox
        Me.cboAddToRackNumber = New System.Windows.Forms.ComboBox
        Me.EmptyBinQuerySLCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAddLotNumber = New System.Windows.Forms.TextBox
        Me.txtBoxQuantity = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtPiecesPerBox = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtAddTotalPieces = New System.Windows.Forms.Label
        Me.txtAddRackingWeight = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdClearAddToRack = New System.Windows.Forms.Button
        Me.cmdAddToRack = New System.Windows.Forms.Button
        Me.gpxRackTotals = New System.Windows.Forms.GroupBox
        Me.lblDifference = New System.Windows.Forms.TextBox
        Me.lblQuantityInRack = New System.Windows.Forms.TextBox
        Me.lblQOH = New System.Windows.Forms.TextBox
        Me.lblPartNumber = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.gpxDeleteGroup = New System.Windows.Forms.GroupBox
        Me.cmdDeleteRack = New System.Windows.Forms.Button
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher
        Me.lblEmptyRacks = New System.Windows.Forms.Label
        Me.tabRackingTabs = New System.Windows.Forms.TabControl
        Me.tabViewEdit = New System.Windows.Forms.TabPage
        Me.tabFullPallet = New System.Windows.Forms.TabPage
        Me.lblRackNumber = New System.Windows.Forms.Label
        Me.dgvRackContents = New System.Windows.Forms.DataGridView
        Me.PartNumberColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxQuantityColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiecesPerBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPiecesColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingKeyColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinNumberColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label22 = New System.Windows.Forms.Label
        Me.dgvSuggestedRacks = New System.Windows.Forms.DataGridView
        Me.BinNumberColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SumRackWeightColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BarWeightOpenColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SumRackPiecesColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfBoxesColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartnerBinNumberColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartnerBinWeightAppliedColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartnerBinWeightColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackPositionColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxBarWeightColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinRackingWeightDetailsSLCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmptyBinQuerySLCTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmptyBinQuerySLCTableAdapter
        Me.BinRackingWeightDetailsSLCTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinRackingWeightDetailsSLCTableAdapter
        Me.lblViewEmptyRacks = New System.Windows.Forms.Label
        Me.txtShipmentNumber = New System.Windows.Forms.TextBox
        Me.cmdPrintByShipment = New System.Windows.Forms.Button
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.cmdPrintPOBarcode = New System.Windows.Forms.Button
        Me.cboPurchaseOrderNumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.gpxRackFilters.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BinNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventoryRacking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RackingTransactionQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxAddToRack.SuspendLayout()
        CType(Me.EmptyBinQuerySLCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxRackTotals.SuspendLayout()
        Me.gpxDeleteGroup.SuspendLayout()
        Me.tabRackingTabs.SuspendLayout()
        Me.tabViewEdit.SuspendLayout()
        Me.tabFullPallet.SuspendLayout()
        CType(Me.dgvRackContents, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSuggestedRacks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BinRackingWeightDetailsSLCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gpxRackFilters
        '
        Me.gpxRackFilters.Controls.Add(Me.Label29)
        Me.gpxRackFilters.Controls.Add(Me.Label28)
        Me.gpxRackFilters.Controls.Add(Me.txtPartTextStartsWith)
        Me.gpxRackFilters.Controls.Add(Me.Label26)
        Me.gpxRackFilters.Controls.Add(Me.Label27)
        Me.gpxRackFilters.Controls.Add(Me.txtRackTextContains)
        Me.gpxRackFilters.Controls.Add(Me.txtPartTextContains)
        Me.gpxRackFilters.Controls.Add(Me.Label5)
        Me.gpxRackFilters.Controls.Add(Me.Label4)
        Me.gpxRackFilters.Controls.Add(Me.cmdClear)
        Me.gpxRackFilters.Controls.Add(Me.cmdViewByFilters)
        Me.gpxRackFilters.Controls.Add(Me.txtLotNumber)
        Me.gpxRackFilters.Controls.Add(Me.txtHeatNumber)
        Me.gpxRackFilters.Controls.Add(Me.cboPartDescription)
        Me.gpxRackFilters.Controls.Add(Me.Label2)
        Me.gpxRackFilters.Controls.Add(Me.cboPartNumber)
        Me.gpxRackFilters.Controls.Add(Me.cboRackNumber)
        Me.gpxRackFilters.Controls.Add(Me.cboDivisionID)
        Me.gpxRackFilters.Controls.Add(Me.Label1)
        Me.gpxRackFilters.Controls.Add(Me.Label3)
        Me.gpxRackFilters.Location = New System.Drawing.Point(9, 6)
        Me.gpxRackFilters.Name = "gpxRackFilters"
        Me.gpxRackFilters.Size = New System.Drawing.Size(300, 406)
        Me.gpxRackFilters.TabIndex = 0
        Me.gpxRackFilters.TabStop = False
        Me.gpxRackFilters.Text = "View Racking By Filters"
        '
        'Label29
        '
        Me.Label29.ForeColor = System.Drawing.Color.Blue
        Me.Label29.Location = New System.Drawing.Point(18, 236)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(264, 20)
        Me.Label29.TabIndex = 212
        Me.Label29.Text = "Text Searches / Filters"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(18, 268)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(113, 23)
        Me.Label28.TabIndex = 17
        Me.Label28.Text = "Part # (starts with)"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartTextStartsWith
        '
        Me.txtPartTextStartsWith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartTextStartsWith.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartTextStartsWith.Location = New System.Drawing.Point(134, 268)
        Me.txtPartTextStartsWith.Name = "txtPartTextStartsWith"
        Me.txtPartTextStartsWith.Size = New System.Drawing.Size(149, 20)
        Me.txtPartTextStartsWith.TabIndex = 7
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(18, 326)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(113, 23)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "Rack # (contains)"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(18, 297)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(113, 23)
        Me.Label27.TabIndex = 14
        Me.Label27.Text = "Part # (contains)"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRackTextContains
        '
        Me.txtRackTextContains.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRackTextContains.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRackTextContains.Location = New System.Drawing.Point(134, 326)
        Me.txtRackTextContains.Name = "txtRackTextContains"
        Me.txtRackTextContains.Size = New System.Drawing.Size(149, 20)
        Me.txtRackTextContains.TabIndex = 9
        '
        'txtPartTextContains
        '
        Me.txtPartTextContains.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartTextContains.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartTextContains.Location = New System.Drawing.Point(134, 297)
        Me.txtPartTextContains.Name = "txtPartTextContains"
        Me.txtPartTextContains.Size = New System.Drawing.Size(149, 20)
        Me.txtPartTextContains.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 23)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Lot #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 23)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Heat #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(211, 360)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 11
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(134, 360)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 10
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'txtLotNumber
        '
        Me.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLotNumber.Location = New System.Drawing.Point(62, 200)
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.Size = New System.Drawing.Size(221, 20)
        Me.txtLotNumber.TabIndex = 6
        '
        'txtHeatNumber
        '
        Me.txtHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeatNumber.Location = New System.Drawing.Point(62, 167)
        Me.txtHeatNumber.Name = "txtHeatNumber"
        Me.txtHeatNumber.Size = New System.Drawing.Size(221, 20)
        Me.txtHeatNumber.TabIndex = 5
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(18, 133)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(268, 21)
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Rack/Bin #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(62, 99)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(221, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'cboRackNumber
        '
        Me.cboRackNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRackNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRackNumber.DataSource = Me.BinNumberBindingSource
        Me.cboRackNumber.DisplayMember = "BinNumber"
        Me.cboRackNumber.FormattingEnabled = True
        Me.cboRackNumber.Location = New System.Drawing.Point(133, 65)
        Me.cboRackNumber.Name = "cboRackNumber"
        Me.cboRackNumber.Size = New System.Drawing.Size(150, 21)
        Me.cboRackNumber.TabIndex = 2
        '
        'BinNumberBindingSource
        '
        Me.BinNumberBindingSource.DataMember = "BinNumber"
        Me.BinNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDivisionID
        '
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(133, 31)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(150, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Part #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(1059, 780)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 32
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(982, 780)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 31
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'dgvInventoryRacking
        '
        Me.dgvInventoryRacking.AllowUserToAddRows = False
        Me.dgvInventoryRacking.AllowUserToDeleteRows = False
        Me.dgvInventoryRacking.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryRacking.AutoGenerateColumns = False
        Me.dgvInventoryRacking.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryRacking.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInventoryRacking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryRacking.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RackingKeyColumn, Me.BinNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.BoxQuantityColumn, Me.PiecesPerBoxColumn, Me.TotalPiecesColumn, Me.RackingWeightColumn, Me.LotNumberDataGridViewTextBoxColumn, Me.HeatNumberColumn, Me.RackCommentColumn, Me.ActivityDateColumn, Me.AddedByColumn, Me.CommentColumn, Me.PickTicketColumn, Me.PickDateColumn, Me.PieceWeightColumn, Me.BoxWeightColumn, Me.PalletWeightColumn, Me.BoxCountColumn, Me.PalletCountColumn, Me.PalletPiecesColumn, Me.ItemClassColumn, Me.DivisionIDColumn, Me.CreationDateColumn})
        Me.dgvInventoryRacking.DataSource = Me.RackingTransactionQueryBindingSource
        Me.dgvInventoryRacking.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvInventoryRacking.Location = New System.Drawing.Point(319, 6)
        Me.dgvInventoryRacking.Name = "dgvInventoryRacking"
        Me.dgvInventoryRacking.Size = New System.Drawing.Size(791, 705)
        Me.dgvInventoryRacking.TabIndex = 33
        '
        'RackingKeyColumn
        '
        Me.RackingKeyColumn.DataPropertyName = "RackingKey"
        Me.RackingKeyColumn.HeaderText = "RackingKey"
        Me.RackingKeyColumn.Name = "RackingKeyColumn"
        Me.RackingKeyColumn.Visible = False
        '
        'BinNumberColumn
        '
        Me.BinNumberColumn.DataPropertyName = "BinNumber"
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BinNumberColumn.DefaultCellStyle = DataGridViewCellStyle29
        Me.BinNumberColumn.HeaderText = "Bin #"
        Me.BinNumberColumn.MaxInputLength = 10
        Me.BinNumberColumn.Name = "BinNumberColumn"
        Me.BinNumberColumn.ReadOnly = True
        Me.BinNumberColumn.Width = 80
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartNumberColumn.DefaultCellStyle = DataGridViewCellStyle30
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        Me.PartNumberColumn.Width = 150
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartDescriptionColumn.DefaultCellStyle = DataGridViewCellStyle31
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        Me.PartDescriptionColumn.Width = 200
        '
        'BoxQuantityColumn
        '
        Me.BoxQuantityColumn.DataPropertyName = "BoxQuantity"
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxQuantityColumn.DefaultCellStyle = DataGridViewCellStyle32
        Me.BoxQuantityColumn.HeaderText = "# of Boxes"
        Me.BoxQuantityColumn.Name = "BoxQuantityColumn"
        '
        'PiecesPerBoxColumn
        '
        Me.PiecesPerBoxColumn.DataPropertyName = "PiecesPerBox"
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PiecesPerBoxColumn.DefaultCellStyle = DataGridViewCellStyle33
        Me.PiecesPerBoxColumn.HeaderText = "Pieces / Box"
        Me.PiecesPerBoxColumn.Name = "PiecesPerBoxColumn"
        '
        'TotalPiecesColumn
        '
        Me.TotalPiecesColumn.DataPropertyName = "TotalPieces"
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPiecesColumn.DefaultCellStyle = DataGridViewCellStyle34
        Me.TotalPiecesColumn.HeaderText = "Total Pieces"
        Me.TotalPiecesColumn.Name = "TotalPiecesColumn"
        Me.TotalPiecesColumn.ReadOnly = True
        '
        'RackingWeightColumn
        '
        Me.RackingWeightColumn.DataPropertyName = "RackingWeight"
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RackingWeightColumn.DefaultCellStyle = DataGridViewCellStyle35
        Me.RackingWeightColumn.HeaderText = "Line Weight"
        Me.RackingWeightColumn.Name = "RackingWeightColumn"
        Me.RackingWeightColumn.ReadOnly = True
        '
        'LotNumberDataGridViewTextBoxColumn
        '
        Me.LotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber"
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LotNumberDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle36
        Me.LotNumberDataGridViewTextBoxColumn.HeaderText = "Lot #"
        Me.LotNumberDataGridViewTextBoxColumn.Name = "LotNumberDataGridViewTextBoxColumn"
        Me.LotNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeatNumberColumn.DefaultCellStyle = DataGridViewCellStyle37
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.ReadOnly = True
        '
        'RackCommentColumn
        '
        Me.RackCommentColumn.DataPropertyName = "RackComment"
        DataGridViewCellStyle38.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RackCommentColumn.DefaultCellStyle = DataGridViewCellStyle38
        Me.RackCommentColumn.HeaderText = "Comment"
        Me.RackCommentColumn.Name = "RackCommentColumn"
        '
        'ActivityDateColumn
        '
        Me.ActivityDateColumn.DataPropertyName = "ActivityDate"
        DataGridViewCellStyle39.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActivityDateColumn.DefaultCellStyle = DataGridViewCellStyle39
        Me.ActivityDateColumn.HeaderText = "Activity Date"
        Me.ActivityDateColumn.Name = "ActivityDateColumn"
        Me.ActivityDateColumn.ReadOnly = True
        '
        'AddedByColumn
        '
        Me.AddedByColumn.DataPropertyName = "AddedBy"
        DataGridViewCellStyle40.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddedByColumn.DefaultCellStyle = DataGridViewCellStyle40
        Me.AddedByColumn.HeaderText = "Added By"
        Me.AddedByColumn.Name = "AddedByColumn"
        Me.AddedByColumn.ReadOnly = True
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        DataGridViewCellStyle41.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CommentColumn.DefaultCellStyle = DataGridViewCellStyle41
        Me.CommentColumn.HeaderText = "Lot Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.ReadOnly = True
        '
        'PickTicketColumn
        '
        Me.PickTicketColumn.DataPropertyName = "PickTicket"
        Me.PickTicketColumn.HeaderText = "PT #"
        Me.PickTicketColumn.Name = "PickTicketColumn"
        Me.PickTicketColumn.ReadOnly = True
        Me.PickTicketColumn.Visible = False
        '
        'PickDateColumn
        '
        Me.PickDateColumn.DataPropertyName = "PickDate"
        Me.PickDateColumn.HeaderText = "PickDate"
        Me.PickDateColumn.Name = "PickDateColumn"
        Me.PickDateColumn.ReadOnly = True
        Me.PickDateColumn.Visible = False
        '
        'PieceWeightColumn
        '
        Me.PieceWeightColumn.DataPropertyName = "PieceWeight"
        Me.PieceWeightColumn.HeaderText = "PieceWeight"
        Me.PieceWeightColumn.Name = "PieceWeightColumn"
        Me.PieceWeightColumn.ReadOnly = True
        Me.PieceWeightColumn.Visible = False
        '
        'BoxWeightColumn
        '
        Me.BoxWeightColumn.DataPropertyName = "BoxWeight"
        Me.BoxWeightColumn.HeaderText = "BoxWeight"
        Me.BoxWeightColumn.Name = "BoxWeightColumn"
        Me.BoxWeightColumn.ReadOnly = True
        Me.BoxWeightColumn.Visible = False
        '
        'PalletWeightColumn
        '
        Me.PalletWeightColumn.DataPropertyName = "PalletWeight"
        Me.PalletWeightColumn.HeaderText = "PalletWeight"
        Me.PalletWeightColumn.Name = "PalletWeightColumn"
        Me.PalletWeightColumn.ReadOnly = True
        Me.PalletWeightColumn.Visible = False
        '
        'BoxCountColumn
        '
        Me.BoxCountColumn.DataPropertyName = "BoxCount"
        Me.BoxCountColumn.HeaderText = "BoxCount"
        Me.BoxCountColumn.Name = "BoxCountColumn"
        Me.BoxCountColumn.ReadOnly = True
        Me.BoxCountColumn.Visible = False
        '
        'PalletCountColumn
        '
        Me.PalletCountColumn.DataPropertyName = "PalletCount"
        Me.PalletCountColumn.HeaderText = "PalletCount"
        Me.PalletCountColumn.Name = "PalletCountColumn"
        Me.PalletCountColumn.ReadOnly = True
        Me.PalletCountColumn.Visible = False
        '
        'PalletPiecesColumn
        '
        Me.PalletPiecesColumn.DataPropertyName = "PalletPieces"
        Me.PalletPiecesColumn.HeaderText = "PalletPieces"
        Me.PalletPiecesColumn.Name = "PalletPiecesColumn"
        Me.PalletPiecesColumn.ReadOnly = True
        Me.PalletPiecesColumn.Visible = False
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "ItemClass"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.ReadOnly = True
        Me.ItemClassColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'CreationDateColumn
        '
        Me.CreationDateColumn.DataPropertyName = "CreationDate"
        Me.CreationDateColumn.HeaderText = "CreationDate"
        Me.CreationDateColumn.Name = "CreationDateColumn"
        Me.CreationDateColumn.ReadOnly = True
        Me.CreationDateColumn.Visible = False
        '
        'RackingTransactionQueryBindingSource
        '
        Me.RackingTransactionQueryBindingSource.DataMember = "RackingTransactionQuery"
        Me.RackingTransactionQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'RackingTransactionQueryTableAdapter
        '
        Me.RackingTransactionQueryTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'BinNumberTableAdapter
        '
        Me.BinNumberTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'gpxAddToRack
        '
        Me.gpxAddToRack.Controls.Add(Me.chkPalletLabel)
        Me.gpxAddToRack.Controls.Add(Me.Label25)
        Me.gpxAddToRack.Controls.Add(Me.Label23)
        Me.gpxAddToRack.Controls.Add(Me.rdoAddBoxes)
        Me.gpxAddToRack.Controls.Add(Me.rdoAddPallet)
        Me.gpxAddToRack.Controls.Add(Me.txtPieceWeight)
        Me.gpxAddToRack.Controls.Add(Me.txtAddBoxWeight)
        Me.gpxAddToRack.Controls.Add(Me.Label13)
        Me.gpxAddToRack.Controls.Add(Me.txtRackComment)
        Me.gpxAddToRack.Controls.Add(Me.Label12)
        Me.gpxAddToRack.Controls.Add(Me.Label6)
        Me.gpxAddToRack.Controls.Add(Me.cboAddToPartDescription)
        Me.gpxAddToRack.Controls.Add(Me.cboAddToPartNumber)
        Me.gpxAddToRack.Controls.Add(Me.txtAddHeatNumber)
        Me.gpxAddToRack.Controls.Add(Me.cboAddToRackNumber)
        Me.gpxAddToRack.Controls.Add(Me.Label8)
        Me.gpxAddToRack.Controls.Add(Me.txtAddLotNumber)
        Me.gpxAddToRack.Controls.Add(Me.txtBoxQuantity)
        Me.gpxAddToRack.Controls.Add(Me.Label7)
        Me.gpxAddToRack.Controls.Add(Me.Label15)
        Me.gpxAddToRack.Controls.Add(Me.txtPiecesPerBox)
        Me.gpxAddToRack.Controls.Add(Me.Label9)
        Me.gpxAddToRack.Controls.Add(Me.Label18)
        Me.gpxAddToRack.Controls.Add(Me.Label24)
        Me.gpxAddToRack.Controls.Add(Me.Label10)
        Me.gpxAddToRack.Controls.Add(Me.txtAddTotalPieces)
        Me.gpxAddToRack.Controls.Add(Me.txtAddRackingWeight)
        Me.gpxAddToRack.Controls.Add(Me.Label11)
        Me.gpxAddToRack.Controls.Add(Me.cmdClearAddToRack)
        Me.gpxAddToRack.Controls.Add(Me.cmdAddToRack)
        Me.gpxAddToRack.Location = New System.Drawing.Point(3, 6)
        Me.gpxAddToRack.Name = "gpxAddToRack"
        Me.gpxAddToRack.Size = New System.Drawing.Size(300, 705)
        Me.gpxAddToRack.TabIndex = 9
        Me.gpxAddToRack.TabStop = False
        Me.gpxAddToRack.Text = "Add To Rack/Bin"
        '
        'chkPalletLabel
        '
        Me.chkPalletLabel.AutoSize = True
        Me.chkPalletLabel.Location = New System.Drawing.Point(137, 625)
        Me.chkPalletLabel.Name = "chkPalletLabel"
        Me.chkPalletLabel.Size = New System.Drawing.Size(105, 17)
        Me.chkPalletLabel.TabIndex = 219
        Me.chkPalletLabel.Text = "Print Pallet Label"
        Me.chkPalletLabel.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(155, 75)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(131, 20)
        Me.Label25.TabIndex = 218
        Me.Label25.Text = "Boxes Only (No Pallet)"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(155, 35)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(131, 20)
        Me.Label23.TabIndex = 217
        Me.Label23.Text = "Empty Racks Only"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdoAddBoxes
        '
        Me.rdoAddBoxes.AutoSize = True
        Me.rdoAddBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoAddBoxes.Location = New System.Drawing.Point(17, 78)
        Me.rdoAddBoxes.Name = "rdoAddBoxes"
        Me.rdoAddBoxes.Size = New System.Drawing.Size(134, 17)
        Me.rdoAddBoxes.TabIndex = 216
        Me.rdoAddBoxes.Text = "Add Boxes to Rack"
        Me.rdoAddBoxes.UseVisualStyleBackColor = True
        '
        'rdoAddPallet
        '
        Me.rdoAddPallet.AutoSize = True
        Me.rdoAddPallet.Checked = True
        Me.rdoAddPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoAddPallet.Location = New System.Drawing.Point(17, 35)
        Me.rdoAddPallet.Name = "rdoAddPallet"
        Me.rdoAddPallet.Size = New System.Drawing.Size(132, 17)
        Me.rdoAddPallet.TabIndex = 215
        Me.rdoAddPallet.TabStop = True
        Me.rdoAddPallet.Text = "Add Pallet to Rack"
        Me.rdoAddPallet.UseVisualStyleBackColor = True
        '
        'txtPieceWeight
        '
        Me.txtPieceWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPieceWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPieceWeight.Location = New System.Drawing.Point(17, 663)
        Me.txtPieceWeight.Name = "txtPieceWeight"
        Me.txtPieceWeight.Size = New System.Drawing.Size(112, 20)
        Me.txtPieceWeight.TabIndex = 16
        Me.txtPieceWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPieceWeight.Visible = False
        '
        'txtAddBoxWeight
        '
        Me.txtAddBoxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddBoxWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddBoxWeight.Location = New System.Drawing.Point(139, 375)
        Me.txtAddBoxWeight.Name = "txtAddBoxWeight"
        Me.txtAddBoxWeight.Size = New System.Drawing.Size(147, 20)
        Me.txtAddBoxWeight.TabIndex = 16
        Me.txtAddBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(17, 505)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(272, 20)
        Me.Label13.TabIndex = 214
        Me.Label13.Text = "Rack Comment (100 Characters MAX)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRackComment
        '
        Me.txtRackComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRackComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRackComment.Location = New System.Drawing.Point(17, 525)
        Me.txtRackComment.MaxLength = 100
        Me.txtRackComment.Multiline = True
        Me.txtRackComment.Name = "txtRackComment"
        Me.txtRackComment.Size = New System.Drawing.Size(269, 84)
        Me.txtRackComment.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(21, 375)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 20)
        Me.Label12.TabIndex = 212
        Me.Label12.Text = "Box Weight"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(64, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(221, 20)
        Me.Label6.TabIndex = 210
        Me.Label6.Text = "Load by Lot # or Part Number"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAddToPartDescription
        '
        Me.cboAddToPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAddToPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAddToPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboAddToPartDescription.DisplayMember = "ShortDescription"
        Me.cboAddToPartDescription.FormattingEnabled = True
        Me.cboAddToPartDescription.Location = New System.Drawing.Point(20, 238)
        Me.cboAddToPartDescription.Name = "cboAddToPartDescription"
        Me.cboAddToPartDescription.Size = New System.Drawing.Size(266, 21)
        Me.cboAddToPartDescription.TabIndex = 12
        '
        'cboAddToPartNumber
        '
        Me.cboAddToPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAddToPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAddToPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboAddToPartNumber.DisplayMember = "ItemID"
        Me.cboAddToPartNumber.FormattingEnabled = True
        Me.cboAddToPartNumber.Location = New System.Drawing.Point(68, 204)
        Me.cboAddToPartNumber.Name = "cboAddToPartNumber"
        Me.cboAddToPartNumber.Size = New System.Drawing.Size(218, 21)
        Me.cboAddToPartNumber.TabIndex = 11
        '
        'txtAddHeatNumber
        '
        Me.txtAddHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddHeatNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddHeatNumber.Location = New System.Drawing.Point(139, 437)
        Me.txtAddHeatNumber.Name = "txtAddHeatNumber"
        Me.txtAddHeatNumber.Size = New System.Drawing.Size(147, 20)
        Me.txtAddHeatNumber.TabIndex = 18
        Me.txtAddHeatNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboAddToRackNumber
        '
        Me.cboAddToRackNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAddToRackNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAddToRackNumber.DataSource = Me.EmptyBinQuerySLCBindingSource
        Me.cboAddToRackNumber.DisplayMember = "BinNumber"
        Me.cboAddToRackNumber.FormattingEnabled = True
        Me.cboAddToRackNumber.Location = New System.Drawing.Point(139, 468)
        Me.cboAddToRackNumber.Name = "cboAddToRackNumber"
        Me.cboAddToRackNumber.Size = New System.Drawing.Size(147, 21)
        Me.cboAddToRackNumber.TabIndex = 19
        '
        'EmptyBinQuerySLCBindingSource
        '
        Me.EmptyBinQuerySLCBindingSource.DataMember = "EmptyBinQuerySLC"
        Me.EmptyBinQuerySLCBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(21, 282)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 20)
        Me.Label8.TabIndex = 205
        Me.Label8.Text = "# of Boxes"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddLotNumber
        '
        Me.txtAddLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddLotNumber.Location = New System.Drawing.Point(67, 127)
        Me.txtAddLotNumber.Name = "txtAddLotNumber"
        Me.txtAddLotNumber.Size = New System.Drawing.Size(219, 20)
        Me.txtAddLotNumber.TabIndex = 10
        Me.txtAddLotNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxQuantity
        '
        Me.txtBoxQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxQuantity.Location = New System.Drawing.Point(139, 282)
        Me.txtBoxQuantity.Name = "txtBoxQuantity"
        Me.txtBoxQuantity.Size = New System.Drawing.Size(147, 20)
        Me.txtBoxQuantity.TabIndex = 13
        Me.txtBoxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 469)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 198
        Me.Label7.Text = "Rack Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(17, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(116, 20)
        Me.Label15.TabIndex = 208
        Me.Label15.Text = "Lot #"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPiecesPerBox
        '
        Me.txtPiecesPerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiecesPerBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPiecesPerBox.Location = New System.Drawing.Point(139, 313)
        Me.txtPiecesPerBox.Name = "txtPiecesPerBox"
        Me.txtPiecesPerBox.Size = New System.Drawing.Size(147, 20)
        Me.txtPiecesPerBox.TabIndex = 14
        Me.txtPiecesPerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(21, 313)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 20)
        Me.Label9.TabIndex = 204
        Me.Label9.Text = "Pieces Per Box"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(21, 438)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(116, 20)
        Me.Label18.TabIndex = 209
        Me.Label18.Text = "Heat Number"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(21, 406)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(116, 20)
        Me.Label24.TabIndex = 207
        Me.Label24.Text = "Total Weight"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 205)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(159, 20)
        Me.Label10.TabIndex = 201
        Me.Label10.Text = "Part #"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddTotalPieces
        '
        Me.txtAddTotalPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddTotalPieces.Location = New System.Drawing.Point(139, 344)
        Me.txtAddTotalPieces.Margin = New System.Windows.Forms.Padding(5)
        Me.txtAddTotalPieces.Name = "txtAddTotalPieces"
        Me.txtAddTotalPieces.Size = New System.Drawing.Size(147, 20)
        Me.txtAddTotalPieces.TabIndex = 15
        Me.txtAddTotalPieces.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAddRackingWeight
        '
        Me.txtAddRackingWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddRackingWeight.Location = New System.Drawing.Point(139, 406)
        Me.txtAddRackingWeight.Margin = New System.Windows.Forms.Padding(5)
        Me.txtAddRackingWeight.Name = "txtAddRackingWeight"
        Me.txtAddRackingWeight.Size = New System.Drawing.Size(147, 20)
        Me.txtAddRackingWeight.TabIndex = 17
        Me.txtAddRackingWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(21, 344)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 20)
        Me.Label11.TabIndex = 206
        Me.Label11.Text = "Total Pieces"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAddToRack
        '
        Me.cmdClearAddToRack.Location = New System.Drawing.Point(214, 657)
        Me.cmdClearAddToRack.Name = "cmdClearAddToRack"
        Me.cmdClearAddToRack.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearAddToRack.TabIndex = 22
        Me.cmdClearAddToRack.Text = "Clear"
        Me.cmdClearAddToRack.UseVisualStyleBackColor = True
        '
        'cmdAddToRack
        '
        Me.cmdAddToRack.Location = New System.Drawing.Point(137, 657)
        Me.cmdAddToRack.Name = "cmdAddToRack"
        Me.cmdAddToRack.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddToRack.TabIndex = 21
        Me.cmdAddToRack.Text = "Add"
        Me.cmdAddToRack.UseVisualStyleBackColor = True
        '
        'gpxRackTotals
        '
        Me.gpxRackTotals.Controls.Add(Me.lblDifference)
        Me.gpxRackTotals.Controls.Add(Me.lblQuantityInRack)
        Me.gpxRackTotals.Controls.Add(Me.lblQOH)
        Me.gpxRackTotals.Controls.Add(Me.lblPartNumber)
        Me.gpxRackTotals.Controls.Add(Me.Label21)
        Me.gpxRackTotals.Controls.Add(Me.Label20)
        Me.gpxRackTotals.Controls.Add(Me.Label19)
        Me.gpxRackTotals.Controls.Add(Me.Label17)
        Me.gpxRackTotals.Location = New System.Drawing.Point(9, 552)
        Me.gpxRackTotals.Name = "gpxRackTotals"
        Me.gpxRackTotals.Size = New System.Drawing.Size(300, 153)
        Me.gpxRackTotals.TabIndex = 15
        Me.gpxRackTotals.TabStop = False
        Me.gpxRackTotals.Text = "Rack Totals"
        '
        'lblDifference
        '
        Me.lblDifference.BackColor = System.Drawing.Color.White
        Me.lblDifference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDifference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblDifference.Location = New System.Drawing.Point(144, 115)
        Me.lblDifference.Name = "lblDifference"
        Me.lblDifference.ReadOnly = True
        Me.lblDifference.Size = New System.Drawing.Size(138, 20)
        Me.lblDifference.TabIndex = 19
        Me.lblDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblQuantityInRack
        '
        Me.lblQuantityInRack.BackColor = System.Drawing.Color.White
        Me.lblQuantityInRack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQuantityInRack.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblQuantityInRack.Location = New System.Drawing.Point(144, 86)
        Me.lblQuantityInRack.Name = "lblQuantityInRack"
        Me.lblQuantityInRack.ReadOnly = True
        Me.lblQuantityInRack.Size = New System.Drawing.Size(138, 20)
        Me.lblQuantityInRack.TabIndex = 18
        Me.lblQuantityInRack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblQOH
        '
        Me.lblQOH.BackColor = System.Drawing.Color.White
        Me.lblQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQOH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblQOH.Location = New System.Drawing.Point(144, 57)
        Me.lblQOH.Name = "lblQOH"
        Me.lblQOH.ReadOnly = True
        Me.lblQOH.Size = New System.Drawing.Size(138, 20)
        Me.lblQOH.TabIndex = 17
        Me.lblQOH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPartNumber
        '
        Me.lblPartNumber.BackColor = System.Drawing.Color.White
        Me.lblPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblPartNumber.Location = New System.Drawing.Point(59, 26)
        Me.lblPartNumber.Name = "lblPartNumber"
        Me.lblPartNumber.ReadOnly = True
        Me.lblPartNumber.Size = New System.Drawing.Size(223, 20)
        Me.lblPartNumber.TabIndex = 16
        Me.lblPartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(15, 26)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(126, 20)
        Me.Label21.TabIndex = 214
        Me.Label21.Text = "Part #"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(15, 115)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(126, 20)
        Me.Label20.TabIndex = 213
        Me.Label20.Text = "Difference"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(15, 86)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(126, 20)
        Me.Label19.TabIndex = 212
        Me.Label19.Text = "Quantity In Rack"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(15, 57)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(126, 20)
        Me.Label17.TabIndex = 211
        Me.Label17.Text = "Quantity On Hand"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxDeleteGroup
        '
        Me.gpxDeleteGroup.Controls.Add(Me.cmdDeleteRack)
        Me.gpxDeleteGroup.Controls.Add(Me.cmdDeleteLine)
        Me.gpxDeleteGroup.Controls.Add(Me.Label16)
        Me.gpxDeleteGroup.Controls.Add(Me.Label14)
        Me.gpxDeleteGroup.Location = New System.Drawing.Point(9, 418)
        Me.gpxDeleteGroup.Name = "gpxDeleteGroup"
        Me.gpxDeleteGroup.Size = New System.Drawing.Size(300, 128)
        Me.gpxDeleteGroup.TabIndex = 12
        Me.gpxDeleteGroup.TabStop = False
        Me.gpxDeleteGroup.Text = "Delete Lines / Racks"
        '
        'cmdDeleteRack
        '
        Me.cmdDeleteRack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteRack.Location = New System.Drawing.Point(212, 74)
        Me.cmdDeleteRack.Name = "cmdDeleteRack"
        Me.cmdDeleteRack.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteRack.TabIndex = 14
        Me.cmdDeleteRack.Text = "Delete Rack"
        Me.cmdDeleteRack.UseVisualStyleBackColor = True
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteLine.Location = New System.Drawing.Point(212, 19)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteLine.TabIndex = 13
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(21, 83)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(193, 23)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "DELETE ENTIRE RACK"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(21, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(193, 23)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "DELETE SELECTED LINE"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'lblEmptyRacks
        '
        Me.lblEmptyRacks.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmptyRacks.Location = New System.Drawing.Point(587, 784)
        Me.lblEmptyRacks.Name = "lblEmptyRacks"
        Me.lblEmptyRacks.Size = New System.Drawing.Size(130, 37)
        Me.lblEmptyRacks.TabIndex = 0
        Me.lblEmptyRacks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabRackingTabs
        '
        Me.tabRackingTabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabRackingTabs.Controls.Add(Me.tabViewEdit)
        Me.tabRackingTabs.Controls.Add(Me.tabFullPallet)
        Me.tabRackingTabs.Location = New System.Drawing.Point(12, 37)
        Me.tabRackingTabs.Name = "tabRackingTabs"
        Me.tabRackingTabs.SelectedIndex = 0
        Me.tabRackingTabs.Size = New System.Drawing.Size(1118, 737)
        Me.tabRackingTabs.TabIndex = 35
        '
        'tabViewEdit
        '
        Me.tabViewEdit.Controls.Add(Me.gpxRackFilters)
        Me.tabViewEdit.Controls.Add(Me.dgvInventoryRacking)
        Me.tabViewEdit.Controls.Add(Me.gpxRackTotals)
        Me.tabViewEdit.Controls.Add(Me.gpxDeleteGroup)
        Me.tabViewEdit.Location = New System.Drawing.Point(4, 22)
        Me.tabViewEdit.Name = "tabViewEdit"
        Me.tabViewEdit.Padding = New System.Windows.Forms.Padding(3)
        Me.tabViewEdit.Size = New System.Drawing.Size(1110, 711)
        Me.tabViewEdit.TabIndex = 0
        Me.tabViewEdit.Text = "View / Edit / Delete Racking"
        Me.tabViewEdit.UseVisualStyleBackColor = True
        '
        'tabFullPallet
        '
        Me.tabFullPallet.Controls.Add(Me.lblRackNumber)
        Me.tabFullPallet.Controls.Add(Me.dgvRackContents)
        Me.tabFullPallet.Controls.Add(Me.Label22)
        Me.tabFullPallet.Controls.Add(Me.dgvSuggestedRacks)
        Me.tabFullPallet.Controls.Add(Me.gpxAddToRack)
        Me.tabFullPallet.Location = New System.Drawing.Point(4, 22)
        Me.tabFullPallet.Name = "tabFullPallet"
        Me.tabFullPallet.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFullPallet.Size = New System.Drawing.Size(1110, 711)
        Me.tabFullPallet.TabIndex = 1
        Me.tabFullPallet.Text = "Enter Pallets / Boxes"
        Me.tabFullPallet.UseVisualStyleBackColor = True
        '
        'lblRackNumber
        '
        Me.lblRackNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRackNumber.ForeColor = System.Drawing.Color.Blue
        Me.lblRackNumber.Location = New System.Drawing.Point(807, 39)
        Me.lblRackNumber.Name = "lblRackNumber"
        Me.lblRackNumber.Size = New System.Drawing.Size(297, 31)
        Me.lblRackNumber.TabIndex = 213
        Me.lblRackNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvRackContents
        '
        Me.dgvRackContents.AllowUserToAddRows = False
        Me.dgvRackContents.AllowUserToDeleteRows = False
        Me.dgvRackContents.AutoGenerateColumns = False
        Me.dgvRackContents.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRackContents.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRackContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRackContents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumberColumn33, Me.BoxQuantityColumn33, Me.PiecesPerBoxColumn33, Me.TotalPiecesColumn33, Me.DivisionIDColumn33, Me.RackingKeyColumn33, Me.BinNumberColumn33, Me.PartDescriptionColumn33})
        Me.dgvRackContents.DataSource = Me.RackingTransactionQueryBindingSource
        Me.dgvRackContents.GridColor = System.Drawing.Color.Gray
        Me.dgvRackContents.Location = New System.Drawing.Point(807, 73)
        Me.dgvRackContents.Name = "dgvRackContents"
        Me.dgvRackContents.Size = New System.Drawing.Size(297, 620)
        Me.dgvRackContents.TabIndex = 212
        '
        'PartNumberColumn33
        '
        Me.PartNumberColumn33.DataPropertyName = "PartNumber"
        Me.PartNumberColumn33.HeaderText = "Part #"
        Me.PartNumberColumn33.Name = "PartNumberColumn33"
        Me.PartNumberColumn33.Width = 150
        '
        'BoxQuantityColumn33
        '
        Me.BoxQuantityColumn33.DataPropertyName = "BoxQuantity"
        Me.BoxQuantityColumn33.HeaderText = "# of Boxes"
        Me.BoxQuantityColumn33.Name = "BoxQuantityColumn33"
        '
        'PiecesPerBoxColumn33
        '
        Me.PiecesPerBoxColumn33.DataPropertyName = "PiecesPerBox"
        Me.PiecesPerBoxColumn33.HeaderText = "Pieces/Box"
        Me.PiecesPerBoxColumn33.Name = "PiecesPerBoxColumn33"
        Me.PiecesPerBoxColumn33.Visible = False
        Me.PiecesPerBoxColumn33.Width = 80
        '
        'TotalPiecesColumn33
        '
        Me.TotalPiecesColumn33.DataPropertyName = "TotalPieces"
        Me.TotalPiecesColumn33.HeaderText = "Total Pieces"
        Me.TotalPiecesColumn33.Name = "TotalPiecesColumn33"
        Me.TotalPiecesColumn33.Visible = False
        Me.TotalPiecesColumn33.Width = 80
        '
        'DivisionIDColumn33
        '
        Me.DivisionIDColumn33.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn33.HeaderText = "DivisionID"
        Me.DivisionIDColumn33.Name = "DivisionIDColumn33"
        Me.DivisionIDColumn33.Visible = False
        '
        'RackingKeyColumn33
        '
        Me.RackingKeyColumn33.DataPropertyName = "RackingKey"
        Me.RackingKeyColumn33.HeaderText = "RackingKey"
        Me.RackingKeyColumn33.Name = "RackingKeyColumn33"
        Me.RackingKeyColumn33.Visible = False
        '
        'BinNumberColumn33
        '
        Me.BinNumberColumn33.DataPropertyName = "BinNumber"
        Me.BinNumberColumn33.HeaderText = "Rack #"
        Me.BinNumberColumn33.Name = "BinNumberColumn33"
        Me.BinNumberColumn33.Visible = False
        '
        'PartDescriptionColumn33
        '
        Me.PartDescriptionColumn33.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn33.HeaderText = "PartDescription"
        Me.PartDescriptionColumn33.Name = "PartDescriptionColumn33"
        Me.PartDescriptionColumn33.Visible = False
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.Location = New System.Drawing.Point(324, 6)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(477, 31)
        Me.Label22.TabIndex = 211
        Me.Label22.Text = "Empty / Partial Racks"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvSuggestedRacks
        '
        Me.dgvSuggestedRacks.AllowUserToAddRows = False
        Me.dgvSuggestedRacks.AllowUserToDeleteRows = False
        Me.dgvSuggestedRacks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSuggestedRacks.AutoGenerateColumns = False
        Me.dgvSuggestedRacks.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSuggestedRacks.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSuggestedRacks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSuggestedRacks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BinNumberColumn22, Me.SumRackWeightColumn22, Me.BarWeightOpenColumn22, Me.SumRackPiecesColumn22, Me.NumberOfBoxesColumn22, Me.PartnerBinNumberColumn22, Me.PartnerBinWeightAppliedColumn22, Me.PartnerBinWeightColumn22, Me.RackPositionColumn22, Me.MaxBarWeightColumn22, Me.DivisionIDColumn22})
        Me.dgvSuggestedRacks.DataSource = Me.BinRackingWeightDetailsSLCBindingSource
        Me.dgvSuggestedRacks.GridColor = System.Drawing.Color.Purple
        Me.dgvSuggestedRacks.Location = New System.Drawing.Point(328, 41)
        Me.dgvSuggestedRacks.Name = "dgvSuggestedRacks"
        Me.dgvSuggestedRacks.Size = New System.Drawing.Size(473, 652)
        Me.dgvSuggestedRacks.TabIndex = 24
        '
        'BinNumberColumn22
        '
        Me.BinNumberColumn22.DataPropertyName = "BinNumber"
        Me.BinNumberColumn22.HeaderText = "Rack #"
        Me.BinNumberColumn22.Name = "BinNumberColumn22"
        Me.BinNumberColumn22.Width = 65
        '
        'SumRackWeightColumn22
        '
        Me.SumRackWeightColumn22.DataPropertyName = "SumRackWeight"
        Me.SumRackWeightColumn22.HeaderText = "Weight"
        Me.SumRackWeightColumn22.Name = "SumRackWeightColumn22"
        Me.SumRackWeightColumn22.ReadOnly = True
        Me.SumRackWeightColumn22.Width = 90
        '
        'BarWeightOpenColumn22
        '
        Me.BarWeightOpenColumn22.DataPropertyName = "BarWeightOpen"
        Me.BarWeightOpenColumn22.HeaderText = "Open Weight"
        Me.BarWeightOpenColumn22.Name = "BarWeightOpenColumn22"
        Me.BarWeightOpenColumn22.ReadOnly = True
        Me.BarWeightOpenColumn22.Width = 90
        '
        'SumRackPiecesColumn22
        '
        Me.SumRackPiecesColumn22.DataPropertyName = "SumRackPieces"
        Me.SumRackPiecesColumn22.HeaderText = "# of Pieces"
        Me.SumRackPiecesColumn22.Name = "SumRackPiecesColumn22"
        Me.SumRackPiecesColumn22.ReadOnly = True
        Me.SumRackPiecesColumn22.Width = 90
        '
        'NumberOfBoxesColumn22
        '
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NumberOfBoxesColumn22.DefaultCellStyle = DataGridViewCellStyle42
        Me.NumberOfBoxesColumn22.HeaderText = "# of Boxes"
        Me.NumberOfBoxesColumn22.Name = "NumberOfBoxesColumn22"
        Me.NumberOfBoxesColumn22.Width = 90
        '
        'PartnerBinNumberColumn22
        '
        Me.PartnerBinNumberColumn22.DataPropertyName = "PartnerBinNumber"
        Me.PartnerBinNumberColumn22.HeaderText = "PartnerBinNumber"
        Me.PartnerBinNumberColumn22.Name = "PartnerBinNumberColumn22"
        Me.PartnerBinNumberColumn22.Visible = False
        '
        'PartnerBinWeightAppliedColumn22
        '
        Me.PartnerBinWeightAppliedColumn22.DataPropertyName = "PartnerBinWeightApplied"
        Me.PartnerBinWeightAppliedColumn22.HeaderText = "PartnerBinWeightApplied"
        Me.PartnerBinWeightAppliedColumn22.Name = "PartnerBinWeightAppliedColumn22"
        Me.PartnerBinWeightAppliedColumn22.ReadOnly = True
        Me.PartnerBinWeightAppliedColumn22.Visible = False
        '
        'PartnerBinWeightColumn22
        '
        Me.PartnerBinWeightColumn22.DataPropertyName = "PartnerBinWeight"
        Me.PartnerBinWeightColumn22.HeaderText = "PartnerBinWeight"
        Me.PartnerBinWeightColumn22.Name = "PartnerBinWeightColumn22"
        Me.PartnerBinWeightColumn22.ReadOnly = True
        Me.PartnerBinWeightColumn22.Visible = False
        '
        'RackPositionColumn22
        '
        Me.RackPositionColumn22.DataPropertyName = "RackPosition"
        Me.RackPositionColumn22.HeaderText = "RackPosition"
        Me.RackPositionColumn22.Name = "RackPositionColumn22"
        Me.RackPositionColumn22.Visible = False
        '
        'MaxBarWeightColumn22
        '
        Me.MaxBarWeightColumn22.DataPropertyName = "MaxBarWeight"
        Me.MaxBarWeightColumn22.HeaderText = "MaxBarWeight"
        Me.MaxBarWeightColumn22.Name = "MaxBarWeightColumn22"
        Me.MaxBarWeightColumn22.ReadOnly = True
        Me.MaxBarWeightColumn22.Visible = False
        '
        'DivisionIDColumn22
        '
        Me.DivisionIDColumn22.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn22.HeaderText = "DivisionID"
        Me.DivisionIDColumn22.Name = "DivisionIDColumn22"
        Me.DivisionIDColumn22.Visible = False
        '
        'BinRackingWeightDetailsSLCBindingSource
        '
        Me.BinRackingWeightDetailsSLCBindingSource.DataMember = "BinRackingWeightDetailsSLC"
        Me.BinRackingWeightDetailsSLCBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'EmptyBinQuerySLCTableAdapter
        '
        Me.EmptyBinQuerySLCTableAdapter.ClearBeforeFill = True
        '
        'BinRackingWeightDetailsSLCTableAdapter
        '
        Me.BinRackingWeightDetailsSLCTableAdapter.ClearBeforeFill = True
        '
        'lblViewEmptyRacks
        '
        Me.lblViewEmptyRacks.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblViewEmptyRacks.Location = New System.Drawing.Point(426, 784)
        Me.lblViewEmptyRacks.Name = "lblViewEmptyRacks"
        Me.lblViewEmptyRacks.Size = New System.Drawing.Size(155, 37)
        Me.lblViewEmptyRacks.TabIndex = 36
        Me.lblViewEmptyRacks.Text = "Empty Racks"
        Me.lblViewEmptyRacks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipmentNumber
        '
        Me.txtShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipmentNumber.Location = New System.Drawing.Point(86, 789)
        Me.txtShipmentNumber.Name = "txtShipmentNumber"
        Me.txtShipmentNumber.Size = New System.Drawing.Size(156, 20)
        Me.txtShipmentNumber.TabIndex = 37
        Me.txtShipmentNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdPrintByShipment
        '
        Me.cmdPrintByShipment.Location = New System.Drawing.Point(248, 784)
        Me.cmdPrintByShipment.Name = "cmdPrintByShipment"
        Me.cmdPrintByShipment.Size = New System.Drawing.Size(71, 30)
        Me.cmdPrintByShipment.TabIndex = 38
        Me.cmdPrintByShipment.Text = "Print"
        Me.cmdPrintByShipment.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(16, 789)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(82, 20)
        Me.Label30.TabIndex = 208
        Me.Label30.Text = "Shipment #"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.ForeColor = System.Drawing.Color.Blue
        Me.Label31.Location = New System.Drawing.Point(325, 780)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(80, 40)
        Me.Label31.TabIndex = 218
        Me.Label31.Text = "Print Packing List Lot #'s"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintPOBarcode
        '
        Me.cmdPrintPOBarcode.Location = New System.Drawing.Point(905, 779)
        Me.cmdPrintPOBarcode.Name = "cmdPrintPOBarcode"
        Me.cmdPrintPOBarcode.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintPOBarcode.TabIndex = 219
        Me.cmdPrintPOBarcode.Text = "Print PO Barcode"
        Me.cmdPrintPOBarcode.UseVisualStyleBackColor = True
        '
        'cboPurchaseOrderNumber
        '
        Me.cboPurchaseOrderNumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPurchaseOrderNumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPurchaseOrderNumber.FormattingEnabled = True
        Me.cboPurchaseOrderNumber.Location = New System.Drawing.Point(723, 788)
        Me.cboPurchaseOrderNumber.Name = "cboPurchaseOrderNumber"
        Me.cboPurchaseOrderNumber.Size = New System.Drawing.Size(155, 21)
        Me.cboPurchaseOrderNumber.TabIndex = 220
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InventoryRackingWithPreferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cboPurchaseOrderNumber)
        Me.Controls.Add(Me.cmdPrintPOBarcode)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.cmdPrintByShipment)
        Me.Controls.Add(Me.txtShipmentNumber)
        Me.Controls.Add(Me.lblViewEmptyRacks)
        Me.Controls.Add(Me.lblEmptyRacks)
        Me.Controls.Add(Me.tabRackingTabs)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label30)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InventoryRackingWithPreferences"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Racking (by preference)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxRackFilters.ResumeLayout(False)
        Me.gpxRackFilters.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BinNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventoryRacking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RackingTransactionQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxAddToRack.ResumeLayout(False)
        Me.gpxAddToRack.PerformLayout()
        CType(Me.EmptyBinQuerySLCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxRackTotals.ResumeLayout(False)
        Me.gpxRackTotals.PerformLayout()
        Me.gpxDeleteGroup.ResumeLayout(False)
        Me.tabRackingTabs.ResumeLayout(False)
        Me.tabViewEdit.ResumeLayout(False)
        Me.tabFullPallet.ResumeLayout(False)
        CType(Me.dgvRackContents, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSuggestedRacks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BinRackingWeightDetailsSLCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxRackFilters As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents dgvInventoryRacking As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RackingTransactionQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RackingTransactionQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionQueryTableAdapter
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cboRackNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BinNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BinNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinNumberTableAdapter
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents gpxAddToRack As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClearAddToRack As System.Windows.Forms.Button
    Friend WithEvents cmdAddToRack As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboAddToPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboAddToPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtAddHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboAddToRackNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAddLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPiecesPerBox As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAddTotalPieces As System.Windows.Forms.Label
    Friend WithEvents txtAddRackingWeight As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRackComment As System.Windows.Forms.TextBox
    Friend WithEvents gpxRackTotals As System.Windows.Forms.GroupBox
    Friend WithEvents gpxDeleteGroup As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDeleteRack As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblDifference As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantityInRack As System.Windows.Forms.TextBox
    Friend WithEvents lblQOH As System.Windows.Forms.TextBox
    Friend WithEvents lblPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtPieceWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtAddBoxWeight As System.Windows.Forms.TextBox
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
    Friend WithEvents RackingKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BinNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesPerBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivityDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddedByColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickTicketColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblEmptyRacks As System.Windows.Forms.Label
    Friend WithEvents tabRackingTabs As System.Windows.Forms.TabControl
    Friend WithEvents tabViewEdit As System.Windows.Forms.TabPage
    Friend WithEvents tabFullPallet As System.Windows.Forms.TabPage
    Friend WithEvents rdoAddBoxes As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAddPallet As System.Windows.Forms.RadioButton
    Friend WithEvents EmptyBinQuerySLCBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmptyBinQuerySLCTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmptyBinQuerySLCTableAdapter
    Friend WithEvents dgvSuggestedRacks As System.Windows.Forms.DataGridView
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents BinRackingWeightDetailsSLCBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BinRackingWeightDetailsSLCTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinRackingWeightDetailsSLCTableAdapter
    Friend WithEvents dgvRackContents As System.Windows.Forms.DataGridView
    Friend WithEvents lblRackNumber As System.Windows.Forms.Label
    Friend WithEvents PartNumberColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxQuantityColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesPerBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPiecesColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingKeyColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BinNumberColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BinNumberColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SumRackWeightColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BarWeightOpenColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SumRackPiecesColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfBoxesColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartnerBinNumberColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartnerBinWeightAppliedColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartnerBinWeightColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackPositionColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxBarWeightColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblViewEmptyRacks As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtRackTextContains As System.Windows.Forms.TextBox
    Friend WithEvents txtPartTextContains As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtPartTextStartsWith As System.Windows.Forms.TextBox
    Friend WithEvents chkPalletLabel As System.Windows.Forms.CheckBox
    Friend WithEvents txtShipmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdPrintByShipment As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintPOBarcode As System.Windows.Forms.Button
    Friend WithEvents cboPurchaseOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
End Class
