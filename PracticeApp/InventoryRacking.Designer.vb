<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryRacking
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RackingUtilityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintRackContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.cmdClearAddItem = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtAddHeatNumber = New System.Windows.Forms.TextBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.txtAddLotNumber = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtAddTotalPieces = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAddRackingWeight = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtPiecesPerBox = New System.Windows.Forms.TextBox
        Me.txtBoxQuantity = New System.Windows.Forms.TextBox
        Me.cboRackNumber = New System.Windows.Forms.ComboBox
        Me.BinNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblChanges = New System.Windows.Forms.Label
        Me.lblPartBoxTotal = New System.Windows.Forms.Label
        Me.lblPieceTotal = New System.Windows.Forms.Label
        Me.lblInventoryTotal = New System.Windows.Forms.Label
        Me.txtPieceTotal = New System.Windows.Forms.TextBox
        Me.txtBoxTotal = New System.Windows.Forms.TextBox
        Me.grpbxPartTotals = New System.Windows.Forms.GroupBox
        Me.txtInventoryTotal = New System.Windows.Forms.TextBox
        Me.tabctrl = New System.Windows.Forms.TabControl
        Me.tabSearchDelete = New System.Windows.Forms.TabPage
        Me.txtSearchByDate = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblPartQOH = New System.Windows.Forms.Label
        Me.lblQOH = New System.Windows.Forms.Label
        Me.cboSearchByRack = New System.Windows.Forms.ComboBox
        Me.txtSearchByFOX = New System.Windows.Forms.TextBox
        Me.txtSearchByHeat = New System.Windows.Forms.TextBox
        Me.cboSearchPartNumber = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdDeleteEntireRack = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cboSearchPartDescription = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSearchByText = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmdRackSearch = New System.Windows.Forms.Button
        Me.cmdClearRackSearch = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.tabAddItem = New System.Windows.Forms.TabPage
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRackComment = New System.Windows.Forms.TextBox
        Me.lblPieceWeight = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPickTicketNumber = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdPrintItemLocations = New System.Windows.Forms.Button
        Me.pnlTotalEmptyLocations = New System.Windows.Forms.Panel
        Me.txtTotalEmptyLocations = New System.Windows.Forms.Label
        Me.llTotalEmptyRacks = New System.Windows.Forms.LinkLabel
        Me.dgvRackingTransactions = New System.Windows.Forms.DataGridView
        Me.RackingTransactionQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.RackingTransactionQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionQueryTableAdapter
        Me.BinNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinNumberTableAdapter
        Me.BinNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiecesPerBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActivityDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AddedByColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BinNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpbxPartTotals.SuspendLayout()
        Me.tabctrl.SuspendLayout()
        Me.tabSearchDelete.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabAddItem.SuspendLayout()
        Me.pnlTotalEmptyLocations.SuspendLayout()
        CType(Me.dgvRackingTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RackingTransactionQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1105, 771)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(1192, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RackingUtilityToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'RackingUtilityToolStripMenuItem
        '
        Me.RackingUtilityToolStripMenuItem.Enabled = False
        Me.RackingUtilityToolStripMenuItem.Name = "RackingUtilityToolStripMenuItem"
        Me.RackingUtilityToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.RackingUtilityToolStripMenuItem.Text = "Racking Utility"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintRackContentsToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintRackContentsToolStripMenuItem
        '
        Me.PrintRackContentsToolStripMenuItem.Name = "PrintRackContentsToolStripMenuItem"
        Me.PrintRackContentsToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PrintRackContentsToolStripMenuItem.Text = "Print Listing"
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
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(182, 491)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnter.TabIndex = 10
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdClearAddItem
        '
        Me.cmdClearAddItem.Location = New System.Drawing.Point(259, 491)
        Me.cmdClearAddItem.Name = "cmdClearAddItem"
        Me.cmdClearAddItem.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearAddItem.TabIndex = 11
        Me.cmdClearAddItem.Text = "Clear"
        Me.cmdClearAddItem.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(1028, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 25
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(17, 115)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(313, 21)
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
        'txtAddHeatNumber
        '
        Me.txtAddHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddHeatNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddHeatNumber.Location = New System.Drawing.Point(132, 302)
        Me.txtAddHeatNumber.Name = "txtAddHeatNumber"
        Me.txtAddHeatNumber.Size = New System.Drawing.Size(198, 20)
        Me.txtAddHeatNumber.TabIndex = 7
        Me.txtAddHeatNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(91, 81)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(239, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'txtAddLotNumber
        '
        Me.txtAddLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddLotNumber.Location = New System.Drawing.Point(93, 18)
        Me.txtAddLotNumber.Name = "txtAddLotNumber"
        Me.txtAddLotNumber.Size = New System.Drawing.Size(237, 20)
        Me.txtAddLotNumber.TabIndex = 0
        Me.txtAddLotNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 20)
        Me.Label15.TabIndex = 188
        Me.Label15.Text = "Lot Number"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(16, 303)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 20)
        Me.Label18.TabIndex = 189
        Me.Label18.Text = "Heat Number"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddTotalPieces
        '
        Me.txtAddTotalPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddTotalPieces.Location = New System.Drawing.Point(132, 209)
        Me.txtAddTotalPieces.Margin = New System.Windows.Forms.Padding(5)
        Me.txtAddTotalPieces.Name = "txtAddTotalPieces"
        Me.txtAddTotalPieces.Size = New System.Drawing.Size(198, 20)
        Me.txtAddTotalPieces.TabIndex = 5
        Me.txtAddTotalPieces.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Total Pieces"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddRackingWeight
        '
        Me.txtAddRackingWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddRackingWeight.Location = New System.Drawing.Point(132, 271)
        Me.txtAddRackingWeight.Margin = New System.Windows.Forms.Padding(5)
        Me.txtAddRackingWeight.Name = "txtAddRackingWeight"
        Me.txtAddRackingWeight.Size = New System.Drawing.Size(198, 20)
        Me.txtAddRackingWeight.TabIndex = 6
        Me.txtAddRackingWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(16, 271)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(114, 20)
        Me.Label24.TabIndex = 21
        Me.Label24.Text = "Total Weight"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPiecesPerBox
        '
        Me.txtPiecesPerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiecesPerBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPiecesPerBox.Location = New System.Drawing.Point(134, 178)
        Me.txtPiecesPerBox.Name = "txtPiecesPerBox"
        Me.txtPiecesPerBox.Size = New System.Drawing.Size(196, 20)
        Me.txtPiecesPerBox.TabIndex = 4
        Me.txtPiecesPerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxQuantity
        '
        Me.txtBoxQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxQuantity.Location = New System.Drawing.Point(132, 147)
        Me.txtBoxQuantity.Name = "txtBoxQuantity"
        Me.txtBoxQuantity.Size = New System.Drawing.Size(198, 20)
        Me.txtBoxQuantity.TabIndex = 3
        Me.txtBoxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboRackNumber
        '
        Me.cboRackNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRackNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRackNumber.DataSource = Me.BinNumberBindingSource
        Me.cboRackNumber.DisplayMember = "BinNumber"
        Me.cboRackNumber.FormattingEnabled = True
        Me.cboRackNumber.Location = New System.Drawing.Point(170, 333)
        Me.cboRackNumber.Name = "cboRackNumber"
        Me.cboRackNumber.Size = New System.Drawing.Size(160, 21)
        Me.cboRackNumber.TabIndex = 8
        '
        'BinNumberBindingSource
        '
        Me.BinNumberBindingSource.DataMember = "BinNumber"
        Me.BinNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "# of Boxes"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 20)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Pieces Per Box"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Part Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 334)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Rack Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChanges
        '
        Me.lblChanges.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChanges.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChanges.ForeColor = System.Drawing.Color.Blue
        Me.lblChanges.Location = New System.Drawing.Point(642, 762)
        Me.lblChanges.MinimumSize = New System.Drawing.Size(362, 59)
        Me.lblChanges.Name = "lblChanges"
        Me.lblChanges.Size = New System.Drawing.Size(362, 59)
        Me.lblChanges.TabIndex = 21
        Me.lblChanges.Text = "Changes made in the grid are automatically saved. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Blue text indicates a comme" & _
            "nt."
        Me.lblChanges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPartBoxTotal
        '
        Me.lblPartBoxTotal.Location = New System.Drawing.Point(17, 51)
        Me.lblPartBoxTotal.Name = "lblPartBoxTotal"
        Me.lblPartBoxTotal.Size = New System.Drawing.Size(88, 20)
        Me.lblPartBoxTotal.TabIndex = 28
        Me.lblPartBoxTotal.Text = "Box Total"
        Me.lblPartBoxTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPieceTotal
        '
        Me.lblPieceTotal.Location = New System.Drawing.Point(17, 19)
        Me.lblPieceTotal.Name = "lblPieceTotal"
        Me.lblPieceTotal.Size = New System.Drawing.Size(97, 20)
        Me.lblPieceTotal.TabIndex = 29
        Me.lblPieceTotal.Text = "Piece Total"
        Me.lblPieceTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInventoryTotal
        '
        Me.lblInventoryTotal.Location = New System.Drawing.Point(17, 82)
        Me.lblInventoryTotal.Name = "lblInventoryTotal"
        Me.lblInventoryTotal.Size = New System.Drawing.Size(141, 20)
        Me.lblInventoryTotal.TabIndex = 30
        Me.lblInventoryTotal.Text = "Inventory Total"
        Me.lblInventoryTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPieceTotal
        '
        Me.txtPieceTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtPieceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPieceTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPieceTotal.Location = New System.Drawing.Point(126, 19)
        Me.txtPieceTotal.Name = "txtPieceTotal"
        Me.txtPieceTotal.ReadOnly = True
        Me.txtPieceTotal.Size = New System.Drawing.Size(198, 20)
        Me.txtPieceTotal.TabIndex = 31
        Me.txtPieceTotal.TabStop = False
        Me.txtPieceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxTotal
        '
        Me.txtBoxTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtBoxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxTotal.Location = New System.Drawing.Point(126, 51)
        Me.txtBoxTotal.Name = "txtBoxTotal"
        Me.txtBoxTotal.ReadOnly = True
        Me.txtBoxTotal.Size = New System.Drawing.Size(198, 20)
        Me.txtBoxTotal.TabIndex = 32
        Me.txtBoxTotal.TabStop = False
        Me.txtBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpbxPartTotals
        '
        Me.grpbxPartTotals.Controls.Add(Me.txtInventoryTotal)
        Me.grpbxPartTotals.Controls.Add(Me.txtBoxTotal)
        Me.grpbxPartTotals.Controls.Add(Me.txtPieceTotal)
        Me.grpbxPartTotals.Controls.Add(Me.lblInventoryTotal)
        Me.grpbxPartTotals.Controls.Add(Me.lblPieceTotal)
        Me.grpbxPartTotals.Controls.Add(Me.lblPartBoxTotal)
        Me.grpbxPartTotals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpbxPartTotals.Location = New System.Drawing.Point(29, 614)
        Me.grpbxPartTotals.Name = "grpbxPartTotals"
        Me.grpbxPartTotals.Size = New System.Drawing.Size(354, 116)
        Me.grpbxPartTotals.TabIndex = 21
        Me.grpbxPartTotals.TabStop = False
        Me.grpbxPartTotals.Text = "Totals"
        '
        'txtInventoryTotal
        '
        Me.txtInventoryTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtInventoryTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInventoryTotal.Location = New System.Drawing.Point(126, 82)
        Me.txtInventoryTotal.Name = "txtInventoryTotal"
        Me.txtInventoryTotal.ReadOnly = True
        Me.txtInventoryTotal.Size = New System.Drawing.Size(198, 20)
        Me.txtInventoryTotal.TabIndex = 33
        Me.txtInventoryTotal.TabStop = False
        Me.txtInventoryTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tabctrl
        '
        Me.tabctrl.Controls.Add(Me.tabSearchDelete)
        Me.tabctrl.Controls.Add(Me.tabAddItem)
        Me.tabctrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabctrl.Location = New System.Drawing.Point(29, 41)
        Me.tabctrl.Name = "tabctrl"
        Me.tabctrl.SelectedIndex = 0
        Me.tabctrl.Size = New System.Drawing.Size(354, 567)
        Me.tabctrl.TabIndex = 0
        '
        'tabSearchDelete
        '
        Me.tabSearchDelete.BackColor = System.Drawing.Color.Transparent
        Me.tabSearchDelete.Controls.Add(Me.txtSearchByDate)
        Me.tabSearchDelete.Controls.Add(Me.Label14)
        Me.tabSearchDelete.Controls.Add(Me.lblPartQOH)
        Me.tabSearchDelete.Controls.Add(Me.lblQOH)
        Me.tabSearchDelete.Controls.Add(Me.cboSearchByRack)
        Me.tabSearchDelete.Controls.Add(Me.txtSearchByFOX)
        Me.tabSearchDelete.Controls.Add(Me.txtSearchByHeat)
        Me.tabSearchDelete.Controls.Add(Me.cboSearchPartNumber)
        Me.tabSearchDelete.Controls.Add(Me.GroupBox1)
        Me.tabSearchDelete.Controls.Add(Me.cboSearchPartDescription)
        Me.tabSearchDelete.Controls.Add(Me.Label1)
        Me.tabSearchDelete.Controls.Add(Me.Label2)
        Me.tabSearchDelete.Controls.Add(Me.txtSearchByText)
        Me.tabSearchDelete.Controls.Add(Me.Label13)
        Me.tabSearchDelete.Controls.Add(Me.Label23)
        Me.tabSearchDelete.Controls.Add(Me.cmdRackSearch)
        Me.tabSearchDelete.Controls.Add(Me.cmdClearRackSearch)
        Me.tabSearchDelete.Controls.Add(Me.Label10)
        Me.tabSearchDelete.Location = New System.Drawing.Point(4, 22)
        Me.tabSearchDelete.Name = "tabSearchDelete"
        Me.tabSearchDelete.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSearchDelete.Size = New System.Drawing.Size(346, 541)
        Me.tabSearchDelete.TabIndex = 0
        Me.tabSearchDelete.Text = "Search / Delete"
        Me.tabSearchDelete.UseVisualStyleBackColor = True
        '
        'txtSearchByDate
        '
        Me.txtSearchByDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchByDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchByDate.Location = New System.Drawing.Point(164, 292)
        Me.txtSearchByDate.Name = "txtSearchByDate"
        Me.txtSearchByDate.Size = New System.Drawing.Size(153, 20)
        Me.txtSearchByDate.TabIndex = 187
        Me.txtSearchByDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(13, 292)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(151, 20)
        Me.Label14.TabIndex = 188
        Me.Label14.Text = "Date Filter (MM/DD/YYYY)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPartQOH
        '
        Me.lblPartQOH.ForeColor = System.Drawing.Color.Blue
        Me.lblPartQOH.Location = New System.Drawing.Point(217, 100)
        Me.lblPartQOH.Name = "lblPartQOH"
        Me.lblPartQOH.Size = New System.Drawing.Size(100, 23)
        Me.lblPartQOH.TabIndex = 186
        Me.lblPartQOH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQOH
        '
        Me.lblQOH.ForeColor = System.Drawing.Color.Blue
        Me.lblQOH.Location = New System.Drawing.Point(161, 100)
        Me.lblQOH.Name = "lblQOH"
        Me.lblQOH.Size = New System.Drawing.Size(40, 23)
        Me.lblQOH.TabIndex = 185
        Me.lblQOH.Text = "QOH - "
        Me.lblQOH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSearchByRack
        '
        Me.cboSearchByRack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSearchByRack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSearchByRack.DataSource = Me.BinNumberBindingSource
        Me.cboSearchByRack.DisplayMember = "BinNumber"
        Me.cboSearchByRack.FormattingEnabled = True
        Me.cboSearchByRack.Location = New System.Drawing.Point(164, 151)
        Me.cboSearchByRack.Name = "cboSearchByRack"
        Me.cboSearchByRack.Size = New System.Drawing.Size(153, 21)
        Me.cboSearchByRack.TabIndex = 2
        '
        'txtSearchByFOX
        '
        Me.txtSearchByFOX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchByFOX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchByFOX.Location = New System.Drawing.Point(120, 222)
        Me.txtSearchByFOX.Name = "txtSearchByFOX"
        Me.txtSearchByFOX.Size = New System.Drawing.Size(197, 20)
        Me.txtSearchByFOX.TabIndex = 4
        Me.txtSearchByFOX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSearchByHeat
        '
        Me.txtSearchByHeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchByHeat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchByHeat.Location = New System.Drawing.Point(120, 187)
        Me.txtSearchByHeat.Name = "txtSearchByHeat"
        Me.txtSearchByHeat.Size = New System.Drawing.Size(197, 20)
        Me.txtSearchByHeat.TabIndex = 3
        Me.txtSearchByHeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboSearchPartNumber
        '
        Me.cboSearchPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSearchPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSearchPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboSearchPartNumber.DisplayMember = "ItemID"
        Me.cboSearchPartNumber.FormattingEnabled = True
        Me.cboSearchPartNumber.Location = New System.Drawing.Point(66, 27)
        Me.cboSearchPartNumber.Name = "cboSearchPartNumber"
        Me.cboSearchPartNumber.Size = New System.Drawing.Size(257, 21)
        Me.cboSearchPartNumber.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cmdDeleteEntireRack)
        Me.GroupBox1.Controls.Add(Me.cmdDelete)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 400)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 135)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Delete From Racks"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(14, 92)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(186, 13)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "Delete entire rack selected in datagrid"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 39)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(174, 13)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Delete line item selected in datagrid"
        '
        'cmdDeleteEntireRack
        '
        Me.cmdDeleteEntireRack.Location = New System.Drawing.Point(243, 78)
        Me.cmdDeleteEntireRack.Name = "cmdDeleteEntireRack"
        Me.cmdDeleteEntireRack.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteEntireRack.TabIndex = 10
        Me.cmdDeleteEntireRack.Text = "Delete Rack"
        Me.cmdDeleteEntireRack.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(243, 25)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 8
        Me.cmdDelete.Text = "Delete Selected"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cboSearchPartDescription
        '
        Me.cboSearchPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSearchPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSearchPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboSearchPartDescription.DisplayMember = "ShortDescription"
        Me.cboSearchPartDescription.FormattingEnabled = True
        Me.cboSearchPartDescription.Location = New System.Drawing.Point(13, 60)
        Me.cboSearchPartDescription.Name = "cboSearchPartDescription"
        Me.cboSearchPartDescription.Size = New System.Drawing.Size(310, 21)
        Me.cboSearchPartDescription.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Part #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Rack Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSearchByText
        '
        Me.txtSearchByText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchByText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchByText.Location = New System.Drawing.Point(120, 257)
        Me.txtSearchByText.Name = "txtSearchByText"
        Me.txtSearchByText.Size = New System.Drawing.Size(197, 20)
        Me.txtSearchByText.TabIndex = 5
        Me.txtSearchByText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(13, 187)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 20)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Heat Number"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(13, 257)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(107, 20)
        Me.Label23.TabIndex = 184
        Me.Label23.Text = "Text Filter"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdRackSearch
        '
        Me.cmdRackSearch.Location = New System.Drawing.Point(164, 345)
        Me.cmdRackSearch.Name = "cmdRackSearch"
        Me.cmdRackSearch.Size = New System.Drawing.Size(71, 30)
        Me.cmdRackSearch.TabIndex = 6
        Me.cmdRackSearch.Text = "View"
        Me.cmdRackSearch.UseVisualStyleBackColor = True
        '
        'cmdClearRackSearch
        '
        Me.cmdClearRackSearch.Location = New System.Drawing.Point(246, 345)
        Me.cmdClearRackSearch.Name = "cmdClearRackSearch"
        Me.cmdClearRackSearch.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearRackSearch.TabIndex = 7
        Me.cmdClearRackSearch.Text = "Clear"
        Me.cmdClearRackSearch.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(13, 222)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 20)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "FOX Number"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabAddItem
        '
        Me.tabAddItem.BackColor = System.Drawing.Color.Transparent
        Me.tabAddItem.Controls.Add(Me.Label7)
        Me.tabAddItem.Controls.Add(Me.txtRackComment)
        Me.tabAddItem.Controls.Add(Me.lblPieceWeight)
        Me.tabAddItem.Controls.Add(Me.Label12)
        Me.tabAddItem.Controls.Add(Me.Label4)
        Me.tabAddItem.Controls.Add(Me.cboPartDescription)
        Me.tabAddItem.Controls.Add(Me.cboPartNumber)
        Me.tabAddItem.Controls.Add(Me.txtAddHeatNumber)
        Me.tabAddItem.Controls.Add(Me.cmdClearAddItem)
        Me.tabAddItem.Controls.Add(Me.cboRackNumber)
        Me.tabAddItem.Controls.Add(Me.Label8)
        Me.tabAddItem.Controls.Add(Me.txtAddLotNumber)
        Me.tabAddItem.Controls.Add(Me.txtBoxQuantity)
        Me.tabAddItem.Controls.Add(Me.cmdEnter)
        Me.tabAddItem.Controls.Add(Me.Label3)
        Me.tabAddItem.Controls.Add(Me.Label15)
        Me.tabAddItem.Controls.Add(Me.txtPiecesPerBox)
        Me.tabAddItem.Controls.Add(Me.Label9)
        Me.tabAddItem.Controls.Add(Me.Label18)
        Me.tabAddItem.Controls.Add(Me.Label24)
        Me.tabAddItem.Controls.Add(Me.Label5)
        Me.tabAddItem.Controls.Add(Me.txtAddTotalPieces)
        Me.tabAddItem.Controls.Add(Me.txtAddRackingWeight)
        Me.tabAddItem.Controls.Add(Me.Label6)
        Me.tabAddItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAddItem.Location = New System.Drawing.Point(4, 22)
        Me.tabAddItem.Name = "tabAddItem"
        Me.tabAddItem.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAddItem.Size = New System.Drawing.Size(346, 541)
        Me.tabAddItem.TabIndex = 1
        Me.tabAddItem.Text = "Add To Rack"
        Me.tabAddItem.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 376)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(319, 20)
        Me.Label7.TabIndex = 194
        Me.Label7.Text = "Rack Comment (100 Characters MAX)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRackComment
        '
        Me.txtRackComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRackComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRackComment.Location = New System.Drawing.Point(19, 396)
        Me.txtRackComment.MaxLength = 100
        Me.txtRackComment.Multiline = True
        Me.txtRackComment.Name = "txtRackComment"
        Me.txtRackComment.Size = New System.Drawing.Size(311, 77)
        Me.txtRackComment.TabIndex = 9
        '
        'lblPieceWeight
        '
        Me.lblPieceWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPieceWeight.Location = New System.Drawing.Point(132, 240)
        Me.lblPieceWeight.Margin = New System.Windows.Forms.Padding(5)
        Me.lblPieceWeight.Name = "lblPieceWeight"
        Me.lblPieceWeight.Size = New System.Drawing.Size(198, 20)
        Me.lblPieceWeight.TabIndex = 191
        Me.lblPieceWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 240)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 20)
        Me.Label12.TabIndex = 192
        Me.Label12.Text = "Piece Weight"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(93, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(227, 20)
        Me.Label4.TabIndex = 190
        Me.Label4.Text = "Load by Lot # or Part Number"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPickTicketNumber
        '
        Me.txtPickTicketNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPickTicketNumber.Location = New System.Drawing.Point(46, 771)
        Me.txtPickTicketNumber.Name = "txtPickTicketNumber"
        Me.txtPickTicketNumber.Size = New System.Drawing.Size(188, 20)
        Me.txtPickTicketNumber.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(44, 753)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 13)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "Pick Ticket Number"
        '
        'cmdPrintItemLocations
        '
        Me.cmdPrintItemLocations.Location = New System.Drawing.Point(306, 760)
        Me.cmdPrintItemLocations.Name = "cmdPrintItemLocations"
        Me.cmdPrintItemLocations.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintItemLocations.TabIndex = 1
        Me.cmdPrintItemLocations.Text = "Print Item Locations"
        Me.cmdPrintItemLocations.UseVisualStyleBackColor = True
        '
        'pnlTotalEmptyLocations
        '
        Me.pnlTotalEmptyLocations.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTotalEmptyLocations.Controls.Add(Me.txtTotalEmptyLocations)
        Me.pnlTotalEmptyLocations.Controls.Add(Me.llTotalEmptyRacks)
        Me.pnlTotalEmptyLocations.Location = New System.Drawing.Point(395, 762)
        Me.pnlTotalEmptyLocations.Name = "pnlTotalEmptyLocations"
        Me.pnlTotalEmptyLocations.Size = New System.Drawing.Size(253, 49)
        Me.pnlTotalEmptyLocations.TabIndex = 175
        '
        'txtTotalEmptyLocations
        '
        Me.txtTotalEmptyLocations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalEmptyLocations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalEmptyLocations.Location = New System.Drawing.Point(120, 15)
        Me.txtTotalEmptyLocations.Name = "txtTotalEmptyLocations"
        Me.txtTotalEmptyLocations.Size = New System.Drawing.Size(121, 23)
        Me.txtTotalEmptyLocations.TabIndex = 1
        Me.txtTotalEmptyLocations.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'llTotalEmptyRacks
        '
        Me.llTotalEmptyRacks.Location = New System.Drawing.Point(14, 15)
        Me.llTotalEmptyRacks.Name = "llTotalEmptyRacks"
        Me.llTotalEmptyRacks.Size = New System.Drawing.Size(108, 23)
        Me.llTotalEmptyRacks.TabIndex = 2
        Me.llTotalEmptyRacks.TabStop = True
        Me.llTotalEmptyRacks.Text = "Total Empty Racks"
        Me.llTotalEmptyRacks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvRackingTransactions
        '
        Me.dgvRackingTransactions.AllowUserToAddRows = False
        Me.dgvRackingTransactions.AllowUserToDeleteRows = False
        Me.dgvRackingTransactions.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvRackingTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRackingTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRackingTransactions.AutoGenerateColumns = False
        Me.dgvRackingTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRackingTransactions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvRackingTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRackingTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BinNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.BoxQuantityColumn, Me.PiecesPerBoxColumn, Me.TotalPiecesColumn, Me.HeatNumberColumn, Me.LotNumberColumn, Me.FOXNumberColumn, Me.PieceWeightColumn, Me.RackingWeightColumn, Me.ActivityDateColumn, Me.CommentColumn, Me.AddedByColumn, Me.RackCommentColumn, Me.DivisionIDColumn, Me.BoxWeightColumn, Me.PalletWeightColumn, Me.BoxCountColumn, Me.PalletCountColumn, Me.PalletPiecesColumn, Me.ItemClassColumn, Me.CreationDateColumn, Me.RackingKeyColumn})
        Me.dgvRackingTransactions.DataSource = Me.RackingTransactionQueryBindingSource
        Me.dgvRackingTransactions.GridColor = System.Drawing.Color.Blue
        Me.dgvRackingTransactions.Location = New System.Drawing.Point(395, 63)
        Me.dgvRackingTransactions.Name = "dgvRackingTransactions"
        Me.dgvRackingTransactions.Size = New System.Drawing.Size(781, 693)
        Me.dgvRackingTransactions.TabIndex = 176
        '
        'RackingTransactionQueryBindingSource
        '
        Me.RackingTransactionQueryBindingSource.DataMember = "RackingTransactionQuery"
        Me.RackingTransactionQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'RackingTransactionQueryTableAdapter
        '
        Me.RackingTransactionQueryTableAdapter.ClearBeforeFill = True
        '
        'BinNumberTableAdapter
        '
        Me.BinNumberTableAdapter.ClearBeforeFill = True
        '
        'BinNumberColumn
        '
        Me.BinNumberColumn.DataPropertyName = "BinNumber"
        Me.BinNumberColumn.HeaderText = "Rack"
        Me.BinNumberColumn.Name = "BinNumberColumn"
        Me.BinNumberColumn.ReadOnly = True
        Me.BinNumberColumn.Width = 60
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        Me.PartNumberColumn.Width = 140
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        Me.PartDescriptionColumn.Width = 140
        '
        'BoxQuantityColumn
        '
        Me.BoxQuantityColumn.DataPropertyName = "BoxQuantity"
        Me.BoxQuantityColumn.HeaderText = "# of Boxes"
        Me.BoxQuantityColumn.Name = "BoxQuantityColumn"
        Me.BoxQuantityColumn.Width = 80
        '
        'PiecesPerBoxColumn
        '
        Me.PiecesPerBoxColumn.DataPropertyName = "PiecesPerBox"
        Me.PiecesPerBoxColumn.HeaderText = "Pcs/Box"
        Me.PiecesPerBoxColumn.Name = "PiecesPerBoxColumn"
        Me.PiecesPerBoxColumn.Width = 80
        '
        'TotalPiecesColumn
        '
        Me.TotalPiecesColumn.DataPropertyName = "TotalPieces"
        Me.TotalPiecesColumn.HeaderText = "Total Pieces"
        Me.TotalPiecesColumn.Name = "TotalPiecesColumn"
        Me.TotalPiecesColumn.ReadOnly = True
        Me.TotalPiecesColumn.Width = 80
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.ReadOnly = True
        Me.HeatNumberColumn.Width = 80
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        Me.LotNumberColumn.ReadOnly = True
        Me.LotNumberColumn.Width = 80
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        Me.FOXNumberColumn.Width = 80
        '
        'PieceWeightColumn
        '
        Me.PieceWeightColumn.DataPropertyName = "PieceWeight"
        Me.PieceWeightColumn.HeaderText = "Piece Weight"
        Me.PieceWeightColumn.Name = "PieceWeightColumn"
        Me.PieceWeightColumn.ReadOnly = True
        Me.PieceWeightColumn.Width = 80
        '
        'RackingWeightColumn
        '
        Me.RackingWeightColumn.DataPropertyName = "RackingWeight"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.RackingWeightColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.RackingWeightColumn.HeaderText = "Total Weight"
        Me.RackingWeightColumn.Name = "RackingWeightColumn"
        Me.RackingWeightColumn.ReadOnly = True
        Me.RackingWeightColumn.Width = 80
        '
        'ActivityDateColumn
        '
        Me.ActivityDateColumn.DataPropertyName = "ActivityDate"
        Me.ActivityDateColumn.HeaderText = "Activity Date"
        Me.ActivityDateColumn.Name = "ActivityDateColumn"
        Me.ActivityDateColumn.ReadOnly = True
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.ReadOnly = True
        '
        'AddedByColumn
        '
        Me.AddedByColumn.DataPropertyName = "AddedBy"
        Me.AddedByColumn.HeaderText = "Added By"
        Me.AddedByColumn.Name = "AddedByColumn"
        Me.AddedByColumn.ReadOnly = True
        '
        'RackCommentColumn
        '
        Me.RackCommentColumn.DataPropertyName = "RackComment"
        Me.RackCommentColumn.HeaderText = "Rack Comment"
        Me.RackCommentColumn.Name = "RackCommentColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
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
        'CreationDateColumn
        '
        Me.CreationDateColumn.DataPropertyName = "CreationDate"
        Me.CreationDateColumn.HeaderText = "CreationDate"
        Me.CreationDateColumn.Name = "CreationDateColumn"
        Me.CreationDateColumn.Visible = False
        '
        'RackingKeyColumn
        '
        Me.RackingKeyColumn.DataPropertyName = "RackingKey"
        Me.RackingKeyColumn.HeaderText = "RackingKey"
        Me.RackingKeyColumn.Name = "RackingKeyColumn"
        Me.RackingKeyColumn.Visible = False
        '
        'InventoryRacking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 823)
        Me.Controls.Add(Me.txtPickTicketNumber)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.dgvRackingTransactions)
        Me.Controls.Add(Me.pnlTotalEmptyLocations)
        Me.Controls.Add(Me.cmdPrintItemLocations)
        Me.Controls.Add(Me.grpbxPartTotals)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.tabctrl)
        Me.Controls.Add(Me.lblChanges)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(1200, 850)
        Me.Name = "InventoryRacking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Racking"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BinNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpbxPartTotals.ResumeLayout(False)
        Me.grpbxPartTotals.PerformLayout()
        Me.tabctrl.ResumeLayout(False)
        Me.tabSearchDelete.ResumeLayout(False)
        Me.tabSearchDelete.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabAddItem.ResumeLayout(False)
        Me.tabAddItem.PerformLayout()
        Me.pnlTotalEmptyLocations.ResumeLayout(False)
        CType(Me.dgvRackingTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RackingTransactionQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdClearAddItem As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPiecesPerBox As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PrintRackContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblChanges As System.Windows.Forms.Label
    Friend WithEvents cboRackNumber As System.Windows.Forms.ComboBox
    Friend WithEvents RackingUtilityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPartBoxTotal As System.Windows.Forms.Label
    Friend WithEvents lblPieceTotal As System.Windows.Forms.Label
    Friend WithEvents lblInventoryTotal As System.Windows.Forms.Label
    Friend WithEvents txtPieceTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxTotal As System.Windows.Forms.TextBox
    Friend WithEvents grpbxPartTotals As System.Windows.Forms.GroupBox
    Friend WithEvents tabctrl As System.Windows.Forms.TabControl
    Friend WithEvents tabAddItem As System.Windows.Forms.TabPage
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintItemLocations As System.Windows.Forms.Button
    Friend WithEvents txtInventoryTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtPickTicketNumber As System.Windows.Forms.TextBox
    Friend WithEvents pnlTotalEmptyLocations As System.Windows.Forms.Panel
    Friend WithEvents txtTotalEmptyLocations As System.Windows.Forms.Label
    Friend WithEvents txtAddHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtAddLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtAddTotalPieces As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAddRackingWeight As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents dgvRackingTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents RackingTransactionQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RackingTransactionQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionQueryTableAdapter
    Friend WithEvents tabSearchDelete As System.Windows.Forms.TabPage
    Friend WithEvents txtSearchByFOX As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchByHeat As System.Windows.Forms.TextBox
    Friend WithEvents cboSearchPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteEntireRack As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cboSearchPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSearchByText As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmdRackSearch As System.Windows.Forms.Button
    Friend WithEvents cmdClearRackSearch As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboSearchByRack As System.Windows.Forms.ComboBox
    Friend WithEvents BinNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BinNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinNumberTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPieceWeight As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents llTotalEmptyRacks As System.Windows.Forms.LinkLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRackComment As System.Windows.Forms.TextBox
    Friend WithEvents lblPartQOH As System.Windows.Forms.Label
    Friend WithEvents lblQOH As System.Windows.Forms.Label
    Friend WithEvents txtSearchByDate As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents BinNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesPerBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivityDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddedByColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class