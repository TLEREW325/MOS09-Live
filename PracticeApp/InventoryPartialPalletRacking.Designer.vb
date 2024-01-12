<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryPartialPalletRacking
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
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxLotNumberRacking = New System.Windows.Forms.GroupBox
        Me.txtLotNumber = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdClearLotNumber = New System.Windows.Forms.Button
        Me.gpxPalletItemInfo = New System.Windows.Forms.GroupBox
        Me.txtLabelCount = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.txtTotalWeight = New System.Windows.Forms.TextBox
        Me.dtpInventoryDate = New System.Windows.Forms.DateTimePicker
        Me.txtContainer = New System.Windows.Forms.TextBox
        Me.cboRackNumber = New System.Windows.Forms.ComboBox
        Me.txtBoxWeight = New System.Windows.Forms.TextBox
        Me.txtBoxPieces = New System.Windows.Forms.TextBox
        Me.txtHeatNumber = New System.Windows.Forms.TextBox
        Me.txtBoxCount = New System.Windows.Forms.TextBox
        Me.cmdAddToRack = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPartDescription = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblChanges = New System.Windows.Forms.Label
        Me.lstLotSuggest = New System.Windows.Forms.ListBox
        Me.bgwkLotSuggest = New System.ComponentModel.BackgroundWorker
        Me.lstRackSuggest = New System.Windows.Forms.ListBox
        Me.bgwkRackingSuggest = New System.ComponentModel.BackgroundWorker
        Me.dgvRackingView = New System.Windows.Forms.DataGridView
        Me.RackingKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BinNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiecesPerBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActivityDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AddedByColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackingTransactionQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.RackingTransactionQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionQueryTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtShipmentNumber = New System.Windows.Forms.TextBox
        Me.cmdPrintLotLines = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtEmptyRacks = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.gpxLotNumberRacking.SuspendLayout()
        Me.gpxPalletItemInfo.SuspendLayout()
        CType(Me.dgvRackingView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RackingTransactionQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem, Me.ClearToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1061, 773)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(984, 773)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxLotNumberRacking
        '
        Me.gpxLotNumberRacking.Controls.Add(Me.txtLotNumber)
        Me.gpxLotNumberRacking.Controls.Add(Me.Label12)
        Me.gpxLotNumberRacking.Controls.Add(Me.Label1)
        Me.gpxLotNumberRacking.Location = New System.Drawing.Point(31, 41)
        Me.gpxLotNumberRacking.Name = "gpxLotNumberRacking"
        Me.gpxLotNumberRacking.Size = New System.Drawing.Size(303, 119)
        Me.gpxLotNumberRacking.TabIndex = 0
        Me.gpxLotNumberRacking.TabStop = False
        Me.gpxLotNumberRacking.Text = "Enter Lot (Serial) Number"
        '
        'txtLotNumber
        '
        Me.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLotNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLotNumber.Location = New System.Drawing.Point(9, 53)
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.Size = New System.Drawing.Size(288, 20)
        Me.txtLotNumber.TabIndex = 1
        Me.txtLotNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(136, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(129, 28)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Scan or enter Lot #"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Lot Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearLotNumber
        '
        Me.cmdClearLotNumber.Location = New System.Drawing.Point(217, 500)
        Me.cmdClearLotNumber.Name = "cmdClearLotNumber"
        Me.cmdClearLotNumber.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearLotNumber.TabIndex = 7
        Me.cmdClearLotNumber.Text = "Clear"
        Me.cmdClearLotNumber.UseVisualStyleBackColor = True
        '
        'gpxPalletItemInfo
        '
        Me.gpxPalletItemInfo.Controls.Add(Me.txtLabelCount)
        Me.gpxPalletItemInfo.Controls.Add(Me.Label13)
        Me.gpxPalletItemInfo.Controls.Add(Me.txtPartNumber)
        Me.gpxPalletItemInfo.Controls.Add(Me.txtTotalWeight)
        Me.gpxPalletItemInfo.Controls.Add(Me.dtpInventoryDate)
        Me.gpxPalletItemInfo.Controls.Add(Me.txtContainer)
        Me.gpxPalletItemInfo.Controls.Add(Me.cboRackNumber)
        Me.gpxPalletItemInfo.Controls.Add(Me.txtBoxWeight)
        Me.gpxPalletItemInfo.Controls.Add(Me.txtBoxPieces)
        Me.gpxPalletItemInfo.Controls.Add(Me.txtHeatNumber)
        Me.gpxPalletItemInfo.Controls.Add(Me.txtBoxCount)
        Me.gpxPalletItemInfo.Controls.Add(Me.cmdAddToRack)
        Me.gpxPalletItemInfo.Controls.Add(Me.cmdClearLotNumber)
        Me.gpxPalletItemInfo.Controls.Add(Me.Label11)
        Me.gpxPalletItemInfo.Controls.Add(Me.Label10)
        Me.gpxPalletItemInfo.Controls.Add(Me.Label9)
        Me.gpxPalletItemInfo.Controls.Add(Me.Label8)
        Me.gpxPalletItemInfo.Controls.Add(Me.Label7)
        Me.gpxPalletItemInfo.Controls.Add(Me.Label6)
        Me.gpxPalletItemInfo.Controls.Add(Me.txtPartDescription)
        Me.gpxPalletItemInfo.Controls.Add(Me.Label5)
        Me.gpxPalletItemInfo.Controls.Add(Me.Label4)
        Me.gpxPalletItemInfo.Controls.Add(Me.Label3)
        Me.gpxPalletItemInfo.Controls.Add(Me.Label2)
        Me.gpxPalletItemInfo.Location = New System.Drawing.Point(31, 166)
        Me.gpxPalletItemInfo.Name = "gpxPalletItemInfo"
        Me.gpxPalletItemInfo.Size = New System.Drawing.Size(303, 554)
        Me.gpxPalletItemInfo.TabIndex = 2
        Me.gpxPalletItemInfo.TabStop = False
        Me.gpxPalletItemInfo.Text = "Item Information"
        '
        'txtLabelCount
        '
        Me.txtLabelCount.BackColor = System.Drawing.SystemColors.Window
        Me.txtLabelCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLabelCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLabelCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLabelCount.Location = New System.Drawing.Point(130, 462)
        Me.txtLabelCount.Name = "txtLabelCount"
        Me.txtLabelCount.Size = New System.Drawing.Size(158, 20)
        Me.txtLabelCount.TabIndex = 5
        Me.txtLabelCount.Text = "1"
        Me.txtLabelCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 460)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(133, 20)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Label Count"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartNumber
        '
        Me.txtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartNumber.Location = New System.Drawing.Point(9, 54)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.ReadOnly = True
        Me.txtPartNumber.Size = New System.Drawing.Size(279, 20)
        Me.txtPartNumber.TabIndex = 1
        Me.txtPartNumber.TabStop = False
        Me.txtPartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalWeight.Location = New System.Drawing.Point(130, 306)
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.ReadOnly = True
        Me.txtTotalWeight.Size = New System.Drawing.Size(158, 20)
        Me.txtTotalWeight.TabIndex = 6
        Me.txtTotalWeight.TabStop = False
        Me.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpInventoryDate
        '
        Me.dtpInventoryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInventoryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInventoryDate.Location = New System.Drawing.Point(130, 393)
        Me.dtpInventoryDate.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.dtpInventoryDate.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtpInventoryDate.Name = "dtpInventoryDate"
        Me.dtpInventoryDate.Size = New System.Drawing.Size(158, 20)
        Me.dtpInventoryDate.TabIndex = 9
        '
        'txtContainer
        '
        Me.txtContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContainer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContainer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContainer.Location = New System.Drawing.Point(130, 364)
        Me.txtContainer.Name = "txtContainer"
        Me.txtContainer.ReadOnly = True
        Me.txtContainer.Size = New System.Drawing.Size(158, 20)
        Me.txtContainer.TabIndex = 8
        Me.txtContainer.TabStop = False
        Me.txtContainer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboRackNumber
        '
        Me.cboRackNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRackNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboRackNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRackNumber.FormattingEnabled = True
        Me.cboRackNumber.Location = New System.Drawing.Point(130, 425)
        Me.cboRackNumber.Name = "cboRackNumber"
        Me.cboRackNumber.Size = New System.Drawing.Size(158, 21)
        Me.cboRackNumber.TabIndex = 4
        '
        'txtBoxWeight
        '
        Me.txtBoxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxWeight.Location = New System.Drawing.Point(130, 277)
        Me.txtBoxWeight.Name = "txtBoxWeight"
        Me.txtBoxWeight.ReadOnly = True
        Me.txtBoxWeight.Size = New System.Drawing.Size(158, 20)
        Me.txtBoxWeight.TabIndex = 5
        Me.txtBoxWeight.TabStop = False
        Me.txtBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxPieces
        '
        Me.txtBoxPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxPieces.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxPieces.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxPieces.Location = New System.Drawing.Point(130, 248)
        Me.txtBoxPieces.Name = "txtBoxPieces"
        Me.txtBoxPieces.Size = New System.Drawing.Size(158, 20)
        Me.txtBoxPieces.TabIndex = 4
        Me.txtBoxPieces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHeatNumber
        '
        Me.txtHeatNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeatNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeatNumber.Location = New System.Drawing.Point(130, 335)
        Me.txtHeatNumber.Name = "txtHeatNumber"
        Me.txtHeatNumber.ReadOnly = True
        Me.txtHeatNumber.Size = New System.Drawing.Size(158, 20)
        Me.txtHeatNumber.TabIndex = 7
        Me.txtHeatNumber.TabStop = False
        Me.txtHeatNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBoxCount
        '
        Me.txtBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxCount.Location = New System.Drawing.Point(130, 219)
        Me.txtBoxCount.Name = "txtBoxCount"
        Me.txtBoxCount.Size = New System.Drawing.Size(158, 20)
        Me.txtBoxCount.TabIndex = 3
        Me.txtBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdAddToRack
        '
        Me.cmdAddToRack.Location = New System.Drawing.Point(140, 500)
        Me.cmdAddToRack.Name = "cmdAddToRack"
        Me.cmdAddToRack.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddToRack.TabIndex = 6
        Me.cmdAddToRack.Text = "Add"
        Me.cmdAddToRack.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 304)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(133, 20)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Total Weight"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 426)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 20)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Rack Number"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 275)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 20)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Weight / Box"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 393)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Inventory Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 362)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Container Type"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 333)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Heat Number"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartDescription
        '
        Me.txtPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartDescription.Location = New System.Drawing.Point(9, 109)
        Me.txtPartDescription.Multiline = True
        Me.txtPartDescription.Name = "txtPartDescription"
        Me.txtPartDescription.ReadOnly = True
        Me.txtPartDescription.Size = New System.Drawing.Size(279, 48)
        Me.txtPartDescription.TabIndex = 2
        Me.txtPartDescription.TabStop = False
        Me.txtPartDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Part Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Part Description"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Number of Boxes"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 248)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Quantity / Box"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChanges
        '
        Me.lblChanges.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChanges.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChanges.ForeColor = System.Drawing.Color.Blue
        Me.lblChanges.Location = New System.Drawing.Point(660, 779)
        Me.lblChanges.Name = "lblChanges"
        Me.lblChanges.Size = New System.Drawing.Size(303, 28)
        Me.lblChanges.TabIndex = 22
        Me.lblChanges.Text = "Changes made in the grid are automatically saved."
        Me.lblChanges.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstLotSuggest
        '
        Me.lstLotSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLotSuggest.FormattingEnabled = True
        Me.lstLotSuggest.ItemHeight = 20
        Me.lstLotSuggest.Location = New System.Drawing.Point(40, 120)
        Me.lstLotSuggest.Name = "lstLotSuggest"
        Me.lstLotSuggest.Size = New System.Drawing.Size(159, 84)
        Me.lstLotSuggest.TabIndex = 80
        Me.lstLotSuggest.TabStop = False
        Me.lstLotSuggest.Visible = False
        '
        'bgwkLotSuggest
        '
        '
        'lstRackSuggest
        '
        Me.lstRackSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstRackSuggest.FormattingEnabled = True
        Me.lstRackSuggest.ItemHeight = 16
        Me.lstRackSuggest.Location = New System.Drawing.Point(161, 427)
        Me.lstRackSuggest.Name = "lstRackSuggest"
        Me.lstRackSuggest.Size = New System.Drawing.Size(159, 164)
        Me.lstRackSuggest.TabIndex = 84
        Me.lstRackSuggest.TabStop = False
        Me.lstRackSuggest.Visible = False
        '
        'bgwkRackingSuggest
        '
        Me.bgwkRackingSuggest.WorkerSupportsCancellation = True
        '
        'dgvRackingView
        '
        Me.dgvRackingView.AllowUserToAddRows = False
        Me.dgvRackingView.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvRackingView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRackingView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRackingView.AutoGenerateColumns = False
        Me.dgvRackingView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRackingView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvRackingView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRackingView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RackingKeyColumn, Me.BinNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.BoxQuantityColumn, Me.PiecesPerBoxColumn, Me.TotalPiecesColumn, Me.LotNumberColumn, Me.HeatNumberColumn, Me.RackingWeightColumn, Me.FOXNumberColumn, Me.RackCommentColumn, Me.CommentColumn, Me.ActivityDateColumn, Me.AddedByColumn, Me.PieceWeightColumn, Me.BoxWeightColumn, Me.PalletWeightColumn, Me.BoxCountColumn, Me.PalletCountColumn, Me.PalletPiecesColumn, Me.ItemClassColumn, Me.DivisionIDColumn})
        Me.dgvRackingView.DataSource = Me.RackingTransactionQueryBindingSource
        Me.dgvRackingView.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvRackingView.Location = New System.Drawing.Point(340, 41)
        Me.dgvRackingView.Name = "dgvRackingView"
        Me.dgvRackingView.Size = New System.Drawing.Size(790, 726)
        Me.dgvRackingView.TabIndex = 85
        '
        'RackingKeyColumn
        '
        Me.RackingKeyColumn.DataPropertyName = "RackingKey"
        Me.RackingKeyColumn.HeaderText = "RackingKey"
        Me.RackingKeyColumn.Name = "RackingKeyColumn"
        Me.RackingKeyColumn.ReadOnly = True
        Me.RackingKeyColumn.Visible = False
        '
        'BinNumberColumn
        '
        Me.BinNumberColumn.DataPropertyName = "BinNumber"
        Me.BinNumberColumn.HeaderText = "Bin #"
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
        Me.PartNumberColumn.Width = 120
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        Me.PartDescriptionColumn.Width = 160
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
        Me.PiecesPerBoxColumn.HeaderText = "Pieces/Box"
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
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        Me.LotNumberColumn.ReadOnly = True
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.ReadOnly = True
        '
        'RackingWeightColumn
        '
        Me.RackingWeightColumn.DataPropertyName = "RackingWeight"
        Me.RackingWeightColumn.HeaderText = "Weight"
        Me.RackingWeightColumn.Name = "RackingWeightColumn"
        Me.RackingWeightColumn.ReadOnly = True
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        '
        'RackCommentColumn
        '
        Me.RackCommentColumn.DataPropertyName = "RackComment"
        Me.RackCommentColumn.HeaderText = "Rack Comment"
        Me.RackCommentColumn.Name = "RackCommentColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Lot Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.ReadOnly = True
        '
        'ActivityDateColumn
        '
        Me.ActivityDateColumn.DataPropertyName = "ActivityDate"
        Me.ActivityDateColumn.HeaderText = "Activity Date"
        Me.ActivityDateColumn.Name = "ActivityDateColumn"
        Me.ActivityDateColumn.ReadOnly = True
        '
        'AddedByColumn
        '
        Me.AddedByColumn.DataPropertyName = "AddedBy"
        Me.AddedByColumn.HeaderText = "Added By"
        Me.AddedByColumn.Name = "AddedByColumn"
        Me.AddedByColumn.ReadOnly = True
        '
        'PieceWeightColumn
        '
        Me.PieceWeightColumn.DataPropertyName = "PieceWeight"
        Me.PieceWeightColumn.HeaderText = "Piece Weight"
        Me.PieceWeightColumn.Name = "PieceWeightColumn"
        Me.PieceWeightColumn.ReadOnly = True
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
        Me.DivisionIDColumn.Visible = False
        '
        'RackingTransactionQueryBindingSource
        '
        Me.RackingTransactionQueryBindingSource.DataMember = "RackingTransactionQuery"
        Me.RackingTransactionQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RackingTransactionQueryTableAdapter
        '
        Me.RackingTransactionQueryTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtShipmentNumber)
        Me.GroupBox1.Controls.Add(Me.cmdPrintLotLines)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 726)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 87)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Print Packing List Lot Lines"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(9, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(182, 20)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Shipment #"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipmentNumber
        '
        Me.txtShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipmentNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipmentNumber.Location = New System.Drawing.Point(12, 51)
        Me.txtShipmentNumber.Name = "txtShipmentNumber"
        Me.txtShipmentNumber.Size = New System.Drawing.Size(179, 20)
        Me.txtShipmentNumber.TabIndex = 9
        Me.txtShipmentNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdPrintLotLines
        '
        Me.cmdPrintLotLines.Location = New System.Drawing.Point(219, 41)
        Me.cmdPrintLotLines.Name = "cmdPrintLotLines"
        Me.cmdPrintLotLines.Size = New System.Drawing.Size(71, 30)
        Me.cmdPrintLotLines.TabIndex = 10
        Me.cmdPrintLotLines.Text = "Print"
        Me.cmdPrintLotLines.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(352, 779)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 28)
        Me.Label15.TabIndex = 86
        Me.Label15.Text = "Empty Racks"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmptyRacks
        '
        Me.txtEmptyRacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmptyRacks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmptyRacks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmptyRacks.ForeColor = System.Drawing.Color.Blue
        Me.txtEmptyRacks.Location = New System.Drawing.Point(441, 783)
        Me.txtEmptyRacks.Name = "txtEmptyRacks"
        Me.txtEmptyRacks.ReadOnly = True
        Me.txtEmptyRacks.Size = New System.Drawing.Size(122, 20)
        Me.txtEmptyRacks.TabIndex = 87
        Me.txtEmptyRacks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InventoryPartialPalletRacking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.txtEmptyRacks)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvRackingView)
        Me.Controls.Add(Me.lstRackSuggest)
        Me.Controls.Add(Me.lstLotSuggest)
        Me.Controls.Add(Me.lblChanges)
        Me.Controls.Add(Me.gpxPalletItemInfo)
        Me.Controls.Add(Me.gpxLotNumberRacking)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InventoryPartialPalletRacking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Racking By Full/Partial Pallet"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxLotNumberRacking.ResumeLayout(False)
        Me.gpxLotNumberRacking.PerformLayout()
        Me.gpxPalletItemInfo.ResumeLayout(False)
        Me.gpxPalletItemInfo.PerformLayout()
        CType(Me.dgvRackingView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RackingTransactionQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents gpxLotNumberRacking As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClearLotNumber As System.Windows.Forms.Button
    Friend WithEvents gpxPalletItemInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtBoxCount As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtPartDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxPieces As System.Windows.Forms.TextBox
    Friend WithEvents txtHeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtContainer As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpInventoryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdAddToRack As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboRackNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeight As System.Windows.Forms.TextBox
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblChanges As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lstLotSuggest As System.Windows.Forms.ListBox
    Friend WithEvents bgwkLotSuggest As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtLabelCount As System.Windows.Forms.TextBox
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents tmrScanTime As System.Windows.Forms.Timer
    Friend WithEvents lstRackSuggest As System.Windows.Forms.ListBox
    Friend WithEvents bgwkRackingSuggest As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgvRackingView As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RackingTransactionQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RackingTransactionQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RackingTransactionQueryTableAdapter
    Friend WithEvents RackingKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BinNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesPerBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivityDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddedByColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtShipmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdPrintLotLines As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtEmptyRacks As System.Windows.Forms.TextBox
End Class