<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryTransactionMaintenance
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxInventoryFilters = New System.Windows.Forms.GroupBox
        Me.chkCreateCostTier = New System.Windows.Forms.CheckBox
        Me.txtReferenceLine = New System.Windows.Forms.TextBox
        Me.txtReferenceNumber = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboTransactionType = New System.Windows.Forms.ComboBox
        Me.InventoryTransactionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtpTransactionDate = New System.Windows.Forms.DateTimePicker
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.cboTransactionMath = New System.Windows.Forms.ComboBox
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.txtUnitPrice = New System.Windows.Forms.TextBox
        Me.txtExtendedCost = New System.Windows.Forms.TextBox
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTransactionNumber = New System.Windows.Forms.TextBox
        Me.cmdGenerateTransactionNumber = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdAddTransaction = New System.Windows.Forms.Button
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
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
        Me.InventoryTransactionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryTransactionTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxInventoryFilters.SuspendLayout()
        CType(Me.InventoryTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventoryTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ClearToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
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
        'gpxInventoryFilters
        '
        Me.gpxInventoryFilters.Controls.Add(Me.chkCreateCostTier)
        Me.gpxInventoryFilters.Controls.Add(Me.txtReferenceLine)
        Me.gpxInventoryFilters.Controls.Add(Me.txtReferenceNumber)
        Me.gpxInventoryFilters.Controls.Add(Me.Label14)
        Me.gpxInventoryFilters.Controls.Add(Me.Label15)
        Me.gpxInventoryFilters.Controls.Add(Me.cboTransactionType)
        Me.gpxInventoryFilters.Controls.Add(Me.Label13)
        Me.gpxInventoryFilters.Controls.Add(Me.dtpTransactionDate)
        Me.gpxInventoryFilters.Controls.Add(Me.txtLongDescription)
        Me.gpxInventoryFilters.Controls.Add(Me.cboTransactionMath)
        Me.gpxInventoryFilters.Controls.Add(Me.txtExtendedAmount)
        Me.gpxInventoryFilters.Controls.Add(Me.txtUnitPrice)
        Me.gpxInventoryFilters.Controls.Add(Me.txtExtendedCost)
        Me.gpxInventoryFilters.Controls.Add(Me.txtUnitCost)
        Me.gpxInventoryFilters.Controls.Add(Me.txtQuantity)
        Me.gpxInventoryFilters.Controls.Add(Me.Label10)
        Me.gpxInventoryFilters.Controls.Add(Me.txtTransactionNumber)
        Me.gpxInventoryFilters.Controls.Add(Me.cmdGenerateTransactionNumber)
        Me.gpxInventoryFilters.Controls.Add(Me.cmdClear)
        Me.gpxInventoryFilters.Controls.Add(Me.cboPartDescription)
        Me.gpxInventoryFilters.Controls.Add(Me.cmdAddTransaction)
        Me.gpxInventoryFilters.Controls.Add(Me.cboPartNumber)
        Me.gpxInventoryFilters.Controls.Add(Me.cboDivisionID)
        Me.gpxInventoryFilters.Controls.Add(Me.Label5)
        Me.gpxInventoryFilters.Controls.Add(Me.Label1)
        Me.gpxInventoryFilters.Controls.Add(Me.Label2)
        Me.gpxInventoryFilters.Controls.Add(Me.Label9)
        Me.gpxInventoryFilters.Controls.Add(Me.Label8)
        Me.gpxInventoryFilters.Controls.Add(Me.Label7)
        Me.gpxInventoryFilters.Controls.Add(Me.Label6)
        Me.gpxInventoryFilters.Controls.Add(Me.Label3)
        Me.gpxInventoryFilters.Controls.Add(Me.Label11)
        Me.gpxInventoryFilters.Controls.Add(Me.Label4)
        Me.gpxInventoryFilters.Location = New System.Drawing.Point(29, 41)
        Me.gpxInventoryFilters.Name = "gpxInventoryFilters"
        Me.gpxInventoryFilters.Size = New System.Drawing.Size(300, 720)
        Me.gpxInventoryFilters.TabIndex = 0
        Me.gpxInventoryFilters.TabStop = False
        Me.gpxInventoryFilters.Text = "Add New Inventory Transaction"
        '
        'chkCreateCostTier
        '
        Me.chkCreateCostTier.AutoSize = True
        Me.chkCreateCostTier.Location = New System.Drawing.Point(135, 637)
        Me.chkCreateCostTier.Name = "chkCreateCostTier"
        Me.chkCreateCostTier.Size = New System.Drawing.Size(102, 17)
        Me.chkCreateCostTier.TabIndex = 45
        Me.chkCreateCostTier.Text = "Create Cost Tier"
        Me.chkCreateCostTier.UseVisualStyleBackColor = True
        '
        'txtReferenceLine
        '
        Me.txtReferenceLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenceLine.Location = New System.Drawing.Point(138, 385)
        Me.txtReferenceLine.Name = "txtReferenceLine"
        Me.txtReferenceLine.Size = New System.Drawing.Size(145, 20)
        Me.txtReferenceLine.TabIndex = 9
        '
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferenceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenceNumber.Location = New System.Drawing.Point(100, 350)
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(183, 20)
        Me.txtReferenceNumber.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(17, 385)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 20)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "Ref. Line #"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(17, 352)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(136, 20)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Reference #"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTransactionType
        '
        Me.cboTransactionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTransactionType.DataSource = Me.InventoryTransactionTableBindingSource
        Me.cboTransactionType.DisplayMember = "TransactionType"
        Me.cboTransactionType.FormattingEnabled = True
        Me.cboTransactionType.Location = New System.Drawing.Point(100, 314)
        Me.cboTransactionType.Name = "cboTransactionType"
        Me.cboTransactionType.Size = New System.Drawing.Size(183, 21)
        Me.cboTransactionType.TabIndex = 7
        '
        'InventoryTransactionTableBindingSource
        '
        Me.InventoryTransactionTableBindingSource.DataMember = "InventoryTransactionTable"
        Me.InventoryTransactionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(17, 193)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 20)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Long Description"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTransactionDate.Location = New System.Drawing.Point(99, 102)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpTransactionDate.TabIndex = 3
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLongDescription.Location = New System.Drawing.Point(17, 216)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(266, 79)
        Me.txtLongDescription.TabIndex = 6
        '
        'cboTransactionMath
        '
        Me.cboTransactionMath.FormattingEnabled = True
        Me.cboTransactionMath.Items.AddRange(New Object() {"ADD", "SUBTRACT"})
        Me.cboTransactionMath.Location = New System.Drawing.Point(138, 595)
        Me.cboTransactionMath.Name = "cboTransactionMath"
        Me.cboTransactionMath.Size = New System.Drawing.Size(145, 21)
        Me.cboTransactionMath.TabIndex = 15
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedAmount.Enabled = False
        Me.txtExtendedAmount.Location = New System.Drawing.Point(138, 560)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.Size = New System.Drawing.Size(145, 20)
        Me.txtExtendedAmount.TabIndex = 14
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitPrice.Location = New System.Drawing.Point(138, 525)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(145, 20)
        Me.txtUnitPrice.TabIndex = 13
        '
        'txtExtendedCost
        '
        Me.txtExtendedCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedCost.Enabled = False
        Me.txtExtendedCost.Location = New System.Drawing.Point(138, 490)
        Me.txtExtendedCost.Name = "txtExtendedCost"
        Me.txtExtendedCost.Size = New System.Drawing.Size(145, 20)
        Me.txtExtendedCost.TabIndex = 12
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitCost.Location = New System.Drawing.Point(138, 455)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(145, 20)
        Me.txtUnitCost.TabIndex = 11
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantity.Location = New System.Drawing.Point(138, 420)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(145, 20)
        Me.txtQuantity.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 596)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 20)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Process"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransactionNumber
        '
        Me.txtTransactionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransactionNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransactionNumber.Location = New System.Drawing.Point(99, 68)
        Me.txtTransactionNumber.Name = "txtTransactionNumber"
        Me.txtTransactionNumber.Size = New System.Drawing.Size(184, 20)
        Me.txtTransactionNumber.TabIndex = 2
        '
        'cmdGenerateTransactionNumber
        '
        Me.cmdGenerateTransactionNumber.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateTransactionNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateTransactionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateTransactionNumber.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateTransactionNumber.Location = New System.Drawing.Point(67, 67)
        Me.cmdGenerateTransactionNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateTransactionNumber.Name = "cmdGenerateTransactionNumber"
        Me.cmdGenerateTransactionNumber.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateTransactionNumber.TabIndex = 1
        Me.cmdGenerateTransactionNumber.Text = ">>"
        Me.cmdGenerateTransactionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateTransactionNumber.UseVisualStyleBackColor = False
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 680)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 17
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(17, 170)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(266, 21)
        Me.cboPartDescription.TabIndex = 5
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdAddTransaction
        '
        Me.cmdAddTransaction.Location = New System.Drawing.Point(135, 680)
        Me.cmdAddTransaction.Name = "cmdAddTransaction"
        Me.cmdAddTransaction.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddTransaction.TabIndex = 16
        Me.cmdAddTransaction.Text = "Add"
        Me.cmdAddTransaction.UseVisualStyleBackColor = True
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(97, 135)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(186, 21)
        Me.cboPartNumber.TabIndex = 4
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(99, 33)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(184, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Part Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Trans. #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 560)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 20)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Extended Amount"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 525)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 20)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Unit Price"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 490)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 20)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Extended Cost"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 455)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 20)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Item Cost"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 420)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 20)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Quantity"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 102)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 20)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Trans. Date"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 314)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 20)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Trans. Type"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvInventoryTransactions
        '
        Me.dgvInventoryTransactions.AllowUserToAddRows = False
        Me.dgvInventoryTransactions.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvInventoryTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventoryTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryTransactions.AutoGenerateColumns = False
        Me.dgvInventoryTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryTransactions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInventoryTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransactionNumberColumn, Me.TransactionDateColumn, Me.TransactionTypeColumn, Me.TransactionTypeNumberColumn, Me.TransactionTypeLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.ItemCostColumn, Me.ExtendedCostColumn, Me.ItemPriceColumn, Me.ExtendedAmountColumn, Me.DivisionIDColumn, Me.TransactionMathColumn})
        Me.dgvInventoryTransactions.DataSource = Me.InventoryTransactionTableBindingSource
        Me.dgvInventoryTransactions.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInventoryTransactions.Location = New System.Drawing.Point(350, 45)
        Me.dgvInventoryTransactions.Name = "dgvInventoryTransactions"
        Me.dgvInventoryTransactions.Size = New System.Drawing.Size(777, 661)
        Me.dgvInventoryTransactions.TabIndex = 20
        Me.dgvInventoryTransactions.TabStop = False
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "Trans. #"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.ReadOnly = True
        '
        'TransactionDateColumn
        '
        Me.TransactionDateColumn.DataPropertyName = "TransactionDate"
        Me.TransactionDateColumn.HeaderText = "Date"
        Me.TransactionDateColumn.Name = "TransactionDateColumn"
        '
        'TransactionTypeColumn
        '
        Me.TransactionTypeColumn.DataPropertyName = "TransactionType"
        Me.TransactionTypeColumn.HeaderText = "Type"
        Me.TransactionTypeColumn.Name = "TransactionTypeColumn"
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
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle2.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        '
        'ItemCostColumn
        '
        Me.ItemCostColumn.DataPropertyName = "ItemCost"
        Me.ItemCostColumn.HeaderText = "Item Cost"
        Me.ItemCostColumn.Name = "ItemCostColumn"
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        Me.ExtendedCostColumn.HeaderText = "Extended Cost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        '
        'ItemPriceColumn
        '
        Me.ItemPriceColumn.DataPropertyName = "ItemPrice"
        Me.ItemPriceColumn.HeaderText = "Item Price"
        Me.ItemPriceColumn.Name = "ItemPriceColumn"
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
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
        Me.TransactionMathColumn.HeaderText = "Process"
        Me.TransactionMathColumn.Name = "TransactionMathColumn"
        '
        'InventoryTransactionTableTableAdapter
        '
        Me.InventoryTransactionTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(782, 721)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 17
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1056, 721)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 19
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(979, 721)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 18
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(447, 721)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(329, 40)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "To delete an Inventory Transaction, select the line in the datagrid and select De" & _
            "lete (ADMIN only)."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InventoryTransactionMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 773)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.dgvInventoryTransactions)
        Me.Controls.Add(Me.gpxInventoryFilters)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InventoryTransactionMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintain Inventory Transactions"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxInventoryFilters.ResumeLayout(False)
        Me.gpxInventoryFilters.PerformLayout()
        CType(Me.InventoryTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventoryTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxInventoryFilters As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAddTransaction As System.Windows.Forms.Button
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvInventoryTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents InventoryTransactionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryTransactionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryTransactionTableTableAdapter
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtExtendedCost As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txtTransactionNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdGenerateTransactionNumber As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboTransactionMath As System.Windows.Forms.ComboBox
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents dtpTransactionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboTransactionType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReferenceLine As System.Windows.Forms.TextBox
    Friend WithEvents txtReferenceNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
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
    Friend WithEvents chkCreateCostTier As System.Windows.Forms.CheckBox
End Class
