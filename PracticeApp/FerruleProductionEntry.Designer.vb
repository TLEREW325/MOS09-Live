<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FerruleProductionEntry
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxFerruleProductionData = New System.Windows.Forms.GroupBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdGenerateNewProductionNumber = New System.Windows.Forms.Button
        Me.cboFerruleProductionKey = New System.Windows.Forms.ComboBox
        Me.FerruleProductionHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblLongDescription = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtPiecesProduced = New System.Windows.Forms.TextBox
        Me.cmdClearAddLine = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdAddLine = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxBatchLines = New System.Windows.Forms.GroupBox
        Me.lblLineWeight = New System.Windows.Forms.Label
        Me.lblExtendedAmount = New System.Windows.Forms.Label
        Me.lblPieceWeight = New System.Windows.Forms.Label
        Me.lblUnitCost = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTotalWeight = New System.Windows.Forms.TextBox
        Me.txtTotalCost = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTotalUnits = New System.Windows.Forms.TextBox
        Me.text3 = New System.Windows.Forms.TextBox
        Me.text5 = New System.Windows.Forms.TextBox
        Me.text2 = New System.Windows.Forms.TextBox
        Me.text1 = New System.Windows.Forms.TextBox
        Me.text4 = New System.Windows.Forms.TextBox
        Me.text6 = New System.Windows.Forms.TextBox
        Me.gpxPostBatch = New System.Windows.Forms.GroupBox
        Me.cmdPost = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.cboDeleteLine = New System.Windows.Forms.ComboBox
        Me.FerruleProductionLinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label17 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.FerruleProductionHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FerruleProductionHeaderTableTableAdapter
        Me.FerruleProductionLinesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FerruleProductionLinesTableAdapter
        Me.dgvFerruleProductionGrid = New System.Windows.Forms.DataGridView
        Me.FerruleProductionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FerruleLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductionQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtpProductionDate = New System.Windows.Forms.DateTimePicker
        Me.MenuStrip1.SuspendLayout()
        Me.gpxFerruleProductionData.SuspendLayout()
        CType(Me.FerruleProductionHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxBatchLines.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpxPostBatch.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.FerruleProductionLinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFerruleProductionGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 20
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearFormToolStripMenuItem, Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear All"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
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
        'gpxFerruleProductionData
        '
        Me.gpxFerruleProductionData.Controls.Add(Me.dtpProductionDate)
        Me.gpxFerruleProductionData.Controls.Add(Me.lblStatus)
        Me.gpxFerruleProductionData.Controls.Add(Me.Label11)
        Me.gpxFerruleProductionData.Controls.Add(Me.cmdGenerateNewProductionNumber)
        Me.gpxFerruleProductionData.Controls.Add(Me.cboFerruleProductionKey)
        Me.gpxFerruleProductionData.Controls.Add(Me.Label1)
        Me.gpxFerruleProductionData.Controls.Add(Me.cboDivisionID)
        Me.gpxFerruleProductionData.Controls.Add(Me.Label13)
        Me.gpxFerruleProductionData.Controls.Add(Me.Label14)
        Me.gpxFerruleProductionData.Controls.Add(Me.txtComments)
        Me.gpxFerruleProductionData.Controls.Add(Me.Label2)
        Me.gpxFerruleProductionData.Location = New System.Drawing.Point(29, 41)
        Me.gpxFerruleProductionData.Name = "gpxFerruleProductionData"
        Me.gpxFerruleProductionData.Size = New System.Drawing.Size(335, 309)
        Me.gpxFerruleProductionData.TabIndex = 0
        Me.gpxFerruleProductionData.TabStop = False
        Me.gpxFerruleProductionData.Text = "Enter Ferrule/Tile Production"
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(135, 126)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(181, 20)
        Me.lblStatus.TabIndex = 51
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(24, 126)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 20)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Status"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGenerateNewProductionNumber
        '
        Me.cmdGenerateNewProductionNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewProductionNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewProductionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewProductionNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewProductionNumber.Location = New System.Drawing.Point(105, 28)
        Me.cmdGenerateNewProductionNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewProductionNumber.Name = "cmdGenerateNewProductionNumber"
        Me.cmdGenerateNewProductionNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewProductionNumber.TabIndex = 0
        Me.cmdGenerateNewProductionNumber.TabStop = False
        Me.cmdGenerateNewProductionNumber.Text = ">>"
        Me.cmdGenerateNewProductionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewProductionNumber.UseVisualStyleBackColor = False
        '
        'cboFerruleProductionKey
        '
        Me.cboFerruleProductionKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFerruleProductionKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFerruleProductionKey.DataSource = Me.FerruleProductionHeaderTableBindingSource
        Me.cboFerruleProductionKey.DisplayMember = "FerruleTransactionKey"
        Me.cboFerruleProductionKey.FormattingEnabled = True
        Me.cboFerruleProductionKey.Location = New System.Drawing.Point(135, 28)
        Me.cboFerruleProductionKey.Name = "cboFerruleProductionKey"
        Me.cboFerruleProductionKey.Size = New System.Drawing.Size(181, 21)
        Me.cboFerruleProductionKey.TabIndex = 1
        '
        'FerruleProductionHeaderTableBindingSource
        '
        Me.FerruleProductionHeaderTableBindingSource.DataMember = "FerruleProductionHeaderTable"
        Me.FerruleProductionHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 20)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Batch Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(135, 93)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(181, 21)
        Me.cboDivisionID.TabIndex = 3
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(24, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 20)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Date"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(24, 168)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(110, 20)
        Me.Label14.TabIndex = 39
        Me.Label14.Text = "Comment"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComments
        '
        Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComments.Location = New System.Drawing.Point(27, 191)
        Me.txtComments.MaxLength = 200
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(289, 102)
        Me.txtComments.TabIndex = 5
        Me.txtComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Division ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLongDescription
        '
        Me.lblLongDescription.Location = New System.Drawing.Point(15, 90)
        Me.lblLongDescription.Name = "lblLongDescription"
        Me.lblLongDescription.Size = New System.Drawing.Size(304, 47)
        Me.lblLongDescription.TabIndex = 6
        Me.lblLongDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DropDownWidth = 350
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(18, 60)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(301, 21)
        Me.cboPartDescription.TabIndex = 5
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DropDownWidth = 300
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(105, 29)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(214, 21)
        Me.cboPartNumber.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 20)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Part Number"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(15, 225)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(150, 20)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Estimated Extended Amount"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(15, 171)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(150, 20)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "Estimated Unit Cost"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPiecesProduced
        '
        Me.txtPiecesProduced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPiecesProduced.Location = New System.Drawing.Point(171, 144)
        Me.txtPiecesProduced.Name = "txtPiecesProduced"
        Me.txtPiecesProduced.Size = New System.Drawing.Size(148, 20)
        Me.txtPiecesProduced.TabIndex = 7
        Me.txtPiecesProduced.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdClearAddLine
        '
        Me.cmdClearAddLine.Location = New System.Drawing.Point(248, 285)
        Me.cmdClearAddLine.Name = "cmdClearAddLine"
        Me.cmdClearAddLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAddLine.TabIndex = 13
        Me.cmdClearAddLine.Text = "Clear"
        Me.cmdClearAddLine.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 20)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Pieces Produced"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddLine
        '
        Me.cmdAddLine.Location = New System.Drawing.Point(171, 285)
        Me.cmdAddLine.Name = "cmdAddLine"
        Me.cmdAddLine.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddLine.TabIndex = 12
        Me.cmdAddLine.Text = "Enter"
        Me.cmdAddLine.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(728, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 17
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(805, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 18
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 19
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxBatchLines
        '
        Me.gpxBatchLines.Controls.Add(Me.lblLineWeight)
        Me.gpxBatchLines.Controls.Add(Me.lblExtendedAmount)
        Me.gpxBatchLines.Controls.Add(Me.lblPieceWeight)
        Me.gpxBatchLines.Controls.Add(Me.lblUnitCost)
        Me.gpxBatchLines.Controls.Add(Me.lblLongDescription)
        Me.gpxBatchLines.Controls.Add(Me.Label10)
        Me.gpxBatchLines.Controls.Add(Me.Label4)
        Me.gpxBatchLines.Controls.Add(Me.cboPartNumber)
        Me.gpxBatchLines.Controls.Add(Me.cboPartDescription)
        Me.gpxBatchLines.Controls.Add(Me.Label9)
        Me.gpxBatchLines.Controls.Add(Me.Label15)
        Me.gpxBatchLines.Controls.Add(Me.Label16)
        Me.gpxBatchLines.Controls.Add(Me.txtPiecesProduced)
        Me.gpxBatchLines.Controls.Add(Me.cmdAddLine)
        Me.gpxBatchLines.Controls.Add(Me.Label3)
        Me.gpxBatchLines.Controls.Add(Me.cmdClearAddLine)
        Me.gpxBatchLines.Location = New System.Drawing.Point(29, 475)
        Me.gpxBatchLines.Name = "gpxBatchLines"
        Me.gpxBatchLines.Size = New System.Drawing.Size(335, 336)
        Me.gpxBatchLines.TabIndex = 6
        Me.gpxBatchLines.TabStop = False
        Me.gpxBatchLines.Text = "Enter Production Batch Lines"
        '
        'lblLineWeight
        '
        Me.lblLineWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLineWeight.Location = New System.Drawing.Point(171, 252)
        Me.lblLineWeight.Name = "lblLineWeight"
        Me.lblLineWeight.Size = New System.Drawing.Size(148, 20)
        Me.lblLineWeight.TabIndex = 55
        Me.lblLineWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblExtendedAmount
        '
        Me.lblExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExtendedAmount.Location = New System.Drawing.Point(171, 225)
        Me.lblExtendedAmount.Name = "lblExtendedAmount"
        Me.lblExtendedAmount.Size = New System.Drawing.Size(148, 20)
        Me.lblExtendedAmount.TabIndex = 54
        Me.lblExtendedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPieceWeight
        '
        Me.lblPieceWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPieceWeight.Location = New System.Drawing.Point(171, 198)
        Me.lblPieceWeight.Name = "lblPieceWeight"
        Me.lblPieceWeight.Size = New System.Drawing.Size(148, 20)
        Me.lblPieceWeight.TabIndex = 53
        Me.lblPieceWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUnitCost
        '
        Me.lblUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnitCost.Location = New System.Drawing.Point(171, 171)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(148, 20)
        Me.lblUnitCost.TabIndex = 52
        Me.lblUnitCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(15, 198)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 20)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Piece Weight"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 20)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Line Weight"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtTotalWeight)
        Me.GroupBox1.Controls.Add(Me.txtTotalCost)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtTotalUnits)
        Me.GroupBox1.Location = New System.Drawing.Point(379, 700)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(317, 111)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Production Totals"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(24, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 20)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Total Weight"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalWeight.Location = New System.Drawing.Point(140, 78)
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.ReadOnly = True
        Me.txtTotalWeight.Size = New System.Drawing.Size(161, 20)
        Me.txtTotalWeight.TabIndex = 49
        Me.txtTotalWeight.TabStop = False
        Me.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCost
        '
        Me.txtTotalCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCost.Location = New System.Drawing.Point(140, 22)
        Me.txtTotalCost.Name = "txtTotalCost"
        Me.txtTotalCost.ReadOnly = True
        Me.txtTotalCost.Size = New System.Drawing.Size(161, 20)
        Me.txtTotalCost.TabIndex = 45
        Me.txtTotalCost.TabStop = False
        Me.txtTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(24, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 20)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Total Units"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(24, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 20)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Total Cost"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalUnits
        '
        Me.txtTotalUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalUnits.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalUnits.Location = New System.Drawing.Point(140, 50)
        Me.txtTotalUnits.Name = "txtTotalUnits"
        Me.txtTotalUnits.ReadOnly = True
        Me.txtTotalUnits.Size = New System.Drawing.Size(161, 20)
        Me.txtTotalUnits.TabIndex = 46
        Me.txtTotalUnits.TabStop = False
        Me.txtTotalUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'text3
        '
        Me.text3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.text3.Location = New System.Drawing.Point(579, 292)
        Me.text3.Name = "text3"
        Me.text3.Size = New System.Drawing.Size(85, 20)
        Me.text3.TabIndex = 52
        Me.text3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'text5
        '
        Me.text5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.text5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.text5.Location = New System.Drawing.Point(579, 346)
        Me.text5.Name = "text5"
        Me.text5.Size = New System.Drawing.Size(85, 20)
        Me.text5.TabIndex = 51
        Me.text5.TabStop = False
        Me.text5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'text2
        '
        Me.text2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.text2.Location = New System.Drawing.Point(579, 265)
        Me.text2.Name = "text2"
        Me.text2.Size = New System.Drawing.Size(85, 20)
        Me.text2.TabIndex = 49
        Me.text2.TabStop = False
        Me.text2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'text1
        '
        Me.text1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.text1.Location = New System.Drawing.Point(579, 238)
        Me.text1.Name = "text1"
        Me.text1.Size = New System.Drawing.Size(85, 20)
        Me.text1.TabIndex = 48
        Me.text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'text4
        '
        Me.text4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.text4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.text4.Location = New System.Drawing.Point(579, 319)
        Me.text4.Name = "text4"
        Me.text4.Size = New System.Drawing.Size(85, 20)
        Me.text4.TabIndex = 50
        Me.text4.TabStop = False
        Me.text4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'text6
        '
        Me.text6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.text6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.text6.Location = New System.Drawing.Point(611, 314)
        Me.text6.Name = "text6"
        Me.text6.Size = New System.Drawing.Size(85, 20)
        Me.text6.TabIndex = 53
        Me.text6.TabStop = False
        Me.text6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gpxPostBatch
        '
        Me.gpxPostBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxPostBatch.Controls.Add(Me.cmdPost)
        Me.gpxPostBatch.Controls.Add(Me.Label12)
        Me.gpxPostBatch.Location = New System.Drawing.Point(728, 590)
        Me.gpxPostBatch.Name = "gpxPostBatch"
        Me.gpxPostBatch.Size = New System.Drawing.Size(300, 103)
        Me.gpxPostBatch.TabIndex = 54
        Me.gpxPostBatch.TabStop = False
        Me.gpxPostBatch.Text = "Post Batch"
        '
        'cmdPost
        '
        Me.cmdPost.ForeColor = System.Drawing.Color.Blue
        Me.cmdPost.Location = New System.Drawing.Point(191, 29)
        Me.cmdPost.Name = "cmdPost"
        Me.cmdPost.Size = New System.Drawing.Size(71, 40)
        Me.cmdPost.TabIndex = 51
        Me.cmdPost.Text = "Post"
        Me.cmdPost.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(19, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(166, 54)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Post all line items in batch to complete the process. No changes may be made afte" & _
            "r posting."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(728, 725)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 55
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdDeleteLine)
        Me.GroupBox2.Controls.Add(Me.cboDeleteLine)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Location = New System.Drawing.Point(379, 590)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 103)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Delete Line"
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Location = New System.Drawing.Point(230, 55)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteLine.TabIndex = 50
        Me.cmdDeleteLine.Text = "Delete Line "
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'cboDeleteLine
        '
        Me.cboDeleteLine.DataSource = Me.FerruleProductionLinesBindingSource
        Me.cboDeleteLine.DisplayMember = "FerruleLineKey"
        Me.cboDeleteLine.FormattingEnabled = True
        Me.cboDeleteLine.Location = New System.Drawing.Point(189, 19)
        Me.cboDeleteLine.Name = "cboDeleteLine"
        Me.cboDeleteLine.Size = New System.Drawing.Size(112, 21)
        Me.cboDeleteLine.TabIndex = 49
        '
        'FerruleProductionLinesBindingSource
        '
        Me.FerruleProductionLinesBindingSource.DataMember = "FerruleProductionLines"
        Me.FerruleProductionLinesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(6, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(166, 61)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "You may select the line from the drop down menu to the right, or the Grid Above."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'FerruleProductionHeaderTableTableAdapter
        '
        Me.FerruleProductionHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'FerruleProductionLinesTableAdapter
        '
        Me.FerruleProductionLinesTableAdapter.ClearBeforeFill = True
        '
        'dgvFerruleProductionGrid
        '
        Me.dgvFerruleProductionGrid.AllowUserToAddRows = False
        Me.dgvFerruleProductionGrid.AllowUserToDeleteRows = False
        Me.dgvFerruleProductionGrid.AllowUserToOrderColumns = True
        Me.dgvFerruleProductionGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFerruleProductionGrid.AutoGenerateColumns = False
        Me.dgvFerruleProductionGrid.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvFerruleProductionGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvFerruleProductionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFerruleProductionGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FerruleProductionKeyColumn, Me.FerruleLineKeyColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.ProductionQuantityColumn, Me.UnitCostColumn, Me.ExtendedCostColumn, Me.LineWeightColumn})
        Me.dgvFerruleProductionGrid.DataSource = Me.FerruleProductionLinesBindingSource
        Me.dgvFerruleProductionGrid.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvFerruleProductionGrid.Location = New System.Drawing.Point(379, 41)
        Me.dgvFerruleProductionGrid.Name = "dgvFerruleProductionGrid"
        Me.dgvFerruleProductionGrid.Size = New System.Drawing.Size(649, 543)
        Me.dgvFerruleProductionGrid.TabIndex = 57
        '
        'FerruleProductionKeyColumn
        '
        Me.FerruleProductionKeyColumn.DataPropertyName = "FerruleProductionKey"
        Me.FerruleProductionKeyColumn.HeaderText = "FerruleProductionKey"
        Me.FerruleProductionKeyColumn.Name = "FerruleProductionKeyColumn"
        Me.FerruleProductionKeyColumn.ReadOnly = True
        Me.FerruleProductionKeyColumn.Visible = False
        '
        'FerruleLineKeyColumn
        '
        Me.FerruleLineKeyColumn.DataPropertyName = "FerruleLineKey"
        Me.FerruleLineKeyColumn.HeaderText = "Line #"
        Me.FerruleLineKeyColumn.Name = "FerruleLineKeyColumn"
        Me.FerruleLineKeyColumn.ReadOnly = True
        Me.FerruleLineKeyColumn.Width = 60
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
        '
        'ProductionQuantityColumn
        '
        Me.ProductionQuantityColumn.DataPropertyName = "ProductionQuantity"
        Me.ProductionQuantityColumn.HeaderText = "Quantity"
        Me.ProductionQuantityColumn.Name = "ProductionQuantityColumn"
        Me.ProductionQuantityColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 80
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.ExtendedCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ExtendedCostColumn.HeaderText = "Extended Cost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        Me.ExtendedCostColumn.Width = 80
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        Me.LineWeightColumn.HeaderText = "Line Weight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.Width = 80
        '
        'dtpProductionDate
        '
        Me.dtpProductionDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProductionDate.Location = New System.Drawing.Point(135, 61)
        Me.dtpProductionDate.Name = "dtpProductionDate"
        Me.dtpProductionDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpProductionDate.TabIndex = 58
        '
        'FerruleProductionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvFerruleProductionGrid)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.gpxPostBatch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxBatchLines)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.gpxFerruleProductionData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.text6)
        Me.Controls.Add(Me.text3)
        Me.Controls.Add(Me.text5)
        Me.Controls.Add(Me.text2)
        Me.Controls.Add(Me.text1)
        Me.Controls.Add(Me.text4)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FerruleProductionEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Ferrule/Tile Production Entry"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxFerruleProductionData.ResumeLayout(False)
        Me.gpxFerruleProductionData.PerformLayout()
        CType(Me.FerruleProductionHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxBatchLines.ResumeLayout(False)
        Me.gpxBatchLines.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpxPostBatch.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.FerruleProductionLinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFerruleProductionGrid, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gpxFerruleProductionData As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPiecesProduced As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAddLine As System.Windows.Forms.Button
    Friend WithEvents cmdAddLine As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cboFerruleProductionKey As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateNewProductionNumber As System.Windows.Forms.Button
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents lblLongDescription As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents gpxBatchLines As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalCost As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalUnits As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents text3 As System.Windows.Forms.TextBox
    Friend WithEvents text5 As System.Windows.Forms.TextBox
    Friend WithEvents text2 As System.Windows.Forms.TextBox
    Friend WithEvents text1 As System.Windows.Forms.TextBox
    Friend WithEvents text4 As System.Windows.Forms.TextBox
    Friend WithEvents text6 As System.Windows.Forms.TextBox
    Friend WithEvents gpxPostBatch As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPost As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents cboDeleteLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblLineWeight As System.Windows.Forms.Label
    Friend WithEvents lblExtendedAmount As System.Windows.Forms.Label
    Friend WithEvents lblPieceWeight As System.Windows.Forms.Label
    Friend WithEvents lblUnitCost As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents FerruleProductionHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FerruleProductionHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FerruleProductionHeaderTableTableAdapter
    Friend WithEvents FerruleProductionLinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FerruleProductionLinesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FerruleProductionLinesTableAdapter
    Friend WithEvents dgvFerruleProductionGrid As System.Windows.Forms.DataGridView
    Friend WithEvents FerruleProductionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FerruleLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpProductionDate As System.Windows.Forms.DateTimePicker
End Class