<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryAdjustmentConsignment
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxCreateAdjustment = New System.Windows.Forms.GroupBox
        Me.lblQOH = New System.Windows.Forms.Label
        Me.chkSave = New System.Windows.Forms.CheckBox
        Me.cmdAddAdjustment = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.txtExtendedAmount = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboWarehouse = New System.Windows.Forms.ComboBox
        Me.dtpAdjustmentDate = New System.Windows.Forms.DateTimePicker
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvConsignmentAdjustments = New System.Windows.Forms.DataGridView
        Me.ConsignmentAdjustmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConsignmentAdjustmentTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ConsignmentAdjustmentTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ConsignmentAdjustmentTableTableAdapter
        Me.gpxFilterDatagrid = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.cmdPrintListing = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxCreateAdjustment.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvConsignmentAdjustments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConsignmentAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxFilterDatagrid.SuspendLayout()
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
        'gpxCreateAdjustment
        '
        Me.gpxCreateAdjustment.Controls.Add(Me.lblQOH)
        Me.gpxCreateAdjustment.Controls.Add(Me.chkSave)
        Me.gpxCreateAdjustment.Controls.Add(Me.cmdAddAdjustment)
        Me.gpxCreateAdjustment.Controls.Add(Me.cmdClear)
        Me.gpxCreateAdjustment.Controls.Add(Me.Label8)
        Me.gpxCreateAdjustment.Controls.Add(Me.txtComments)
        Me.gpxCreateAdjustment.Controls.Add(Me.txtExtendedAmount)
        Me.gpxCreateAdjustment.Controls.Add(Me.Label7)
        Me.gpxCreateAdjustment.Controls.Add(Me.txtUnitCost)
        Me.gpxCreateAdjustment.Controls.Add(Me.Label6)
        Me.gpxCreateAdjustment.Controls.Add(Me.txtQuantity)
        Me.gpxCreateAdjustment.Controls.Add(Me.Label5)
        Me.gpxCreateAdjustment.Controls.Add(Me.cboWarehouse)
        Me.gpxCreateAdjustment.Controls.Add(Me.dtpAdjustmentDate)
        Me.gpxCreateAdjustment.Controls.Add(Me.cboDivisionID)
        Me.gpxCreateAdjustment.Controls.Add(Me.cboDescription)
        Me.gpxCreateAdjustment.Controls.Add(Me.cboPartNumber)
        Me.gpxCreateAdjustment.Controls.Add(Me.Label4)
        Me.gpxCreateAdjustment.Controls.Add(Me.Label3)
        Me.gpxCreateAdjustment.Controls.Add(Me.Label2)
        Me.gpxCreateAdjustment.Controls.Add(Me.Label1)
        Me.gpxCreateAdjustment.Location = New System.Drawing.Point(29, 188)
        Me.gpxCreateAdjustment.Name = "gpxCreateAdjustment"
        Me.gpxCreateAdjustment.Size = New System.Drawing.Size(300, 623)
        Me.gpxCreateAdjustment.TabIndex = 1
        Me.gpxCreateAdjustment.TabStop = False
        Me.gpxCreateAdjustment.Text = "Create Part Number Adjustment"
        '
        'lblQOH
        '
        Me.lblQOH.ForeColor = System.Drawing.Color.Red
        Me.lblQOH.Location = New System.Drawing.Point(77, 300)
        Me.lblQOH.Name = "lblQOH"
        Me.lblQOH.Size = New System.Drawing.Size(62, 20)
        Me.lblQOH.TabIndex = 131
        Me.lblQOH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkSave
        '
        Me.chkSave.AutoSize = True
        Me.chkSave.Location = New System.Drawing.Point(94, 139)
        Me.chkSave.Name = "chkSave"
        Me.chkSave.Size = New System.Drawing.Size(195, 17)
        Me.chkSave.TabIndex = 5
        Me.chkSave.Text = "Save data above for multiple entries"
        Me.chkSave.UseVisualStyleBackColor = True
        '
        'cmdAddAdjustment
        '
        Me.cmdAddAdjustment.Location = New System.Drawing.Point(136, 583)
        Me.cmdAddAdjustment.Name = "cmdAddAdjustment"
        Me.cmdAddAdjustment.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddAdjustment.TabIndex = 12
        Me.cmdAddAdjustment.Text = "Add"
        Me.cmdAddAdjustment.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 583)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(20, 425)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(201, 20)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "Comments"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComments
        '
        Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComments.Location = New System.Drawing.Point(20, 448)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(264, 119)
        Me.txtComments.TabIndex = 11
        Me.txtComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExtendedAmount
        '
        Me.txtExtendedAmount.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedAmount.Location = New System.Drawing.Point(147, 377)
        Me.txtExtendedAmount.Name = "txtExtendedAmount"
        Me.txtExtendedAmount.ReadOnly = True
        Me.txtExtendedAmount.Size = New System.Drawing.Size(137, 20)
        Me.txtExtendedAmount.TabIndex = 10
        Me.txtExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 377)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 20)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "Ext. Amount"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitCost.Location = New System.Drawing.Point(147, 338)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(137, 20)
        Me.txtUnitCost.TabIndex = 9
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 338)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 20)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Unit Cost"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantity.Location = New System.Drawing.Point(147, 300)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(137, 20)
        Me.txtQuantity.TabIndex = 8
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 300)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Quantity"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboWarehouse
        '
        Me.cboWarehouse.FormattingEnabled = True
        Me.cboWarehouse.Items.AddRange(New Object() {"Bessemer", "Downey", "Hayward", "Lake Stevens", "Lewisville", "Lyndhurst", "Phoenix", "Renton", "SRL"})
        Me.cboWarehouse.Location = New System.Drawing.Point(94, 100)
        Me.cboWarehouse.Name = "cboWarehouse"
        Me.cboWarehouse.Size = New System.Drawing.Size(190, 21)
        Me.cboWarehouse.TabIndex = 4
        '
        'dtpAdjustmentDate
        '
        Me.dtpAdjustmentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAdjustmentDate.Location = New System.Drawing.Point(94, 65)
        Me.dtpAdjustmentDate.Name = "dtpAdjustmentDate"
        Me.dtpAdjustmentDate.Size = New System.Drawing.Size(190, 20)
        Me.dtpAdjustmentDate.TabIndex = 3
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(129, 29)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(155, 21)
        Me.cboDivisionID.TabIndex = 2
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
        'cboDescription
        '
        Me.cboDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDescription.DataSource = Me.ItemListBindingSource
        Me.cboDescription.DisplayMember = "ShortDescription"
        Me.cboDescription.FormattingEnabled = True
        Me.cboDescription.Location = New System.Drawing.Point(20, 237)
        Me.cboDescription.Name = "cboDescription"
        Me.cboDescription.Size = New System.Drawing.Size(264, 21)
        Me.cboDescription.TabIndex = 7
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(67, 201)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(217, 21)
        Me.cboPartNumber.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "Part #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Warehouse"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Adj. Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 129
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvConsignmentAdjustments
        '
        Me.dgvConsignmentAdjustments.AllowUserToAddRows = False
        Me.dgvConsignmentAdjustments.AllowUserToDeleteRows = False
        Me.dgvConsignmentAdjustments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConsignmentAdjustments.AutoGenerateColumns = False
        Me.dgvConsignmentAdjustments.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvConsignmentAdjustments.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvConsignmentAdjustments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsignmentAdjustments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ConsignmentAdjustmentNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.AdjustmentDateColumn, Me.CustomerClassColumn, Me.CommentColumn, Me.DivisionIDColumn})
        Me.dgvConsignmentAdjustments.DataSource = Me.ConsignmentAdjustmentTableBindingSource
        Me.dgvConsignmentAdjustments.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvConsignmentAdjustments.Location = New System.Drawing.Point(348, 41)
        Me.dgvConsignmentAdjustments.Name = "dgvConsignmentAdjustments"
        Me.dgvConsignmentAdjustments.Size = New System.Drawing.Size(682, 712)
        Me.dgvConsignmentAdjustments.TabIndex = 130
        '
        'ConsignmentAdjustmentNumberColumn
        '
        Me.ConsignmentAdjustmentNumberColumn.DataPropertyName = "ConsignmentAdjustmentNumber"
        Me.ConsignmentAdjustmentNumberColumn.HeaderText = "Adj. #"
        Me.ConsignmentAdjustmentNumberColumn.Name = "ConsignmentAdjustmentNumberColumn"
        Me.ConsignmentAdjustmentNumberColumn.ReadOnly = True
        Me.ConsignmentAdjustmentNumberColumn.Width = 80
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
        Me.PartDescriptionColumn.Width = 150
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.ReadOnly = True
        Me.QuantityColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.ReadOnly = True
        Me.UnitCostColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "Ext. Amt."
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Width = 80
        '
        'AdjustmentDateColumn
        '
        Me.AdjustmentDateColumn.DataPropertyName = "AdjustmentDate"
        Me.AdjustmentDateColumn.HeaderText = "Adj. Date"
        Me.AdjustmentDateColumn.Name = "AdjustmentDateColumn"
        '
        'CustomerClassColumn
        '
        Me.CustomerClassColumn.DataPropertyName = "CustomerClass"
        Me.CustomerClassColumn.HeaderText = "Warehouse ID"
        Me.CustomerClassColumn.Name = "CustomerClassColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        '
        'ConsignmentAdjustmentTableBindingSource
        '
        Me.ConsignmentAdjustmentTableBindingSource.DataMember = "ConsignmentAdjustmentTable"
        Me.ConsignmentAdjustmentTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ConsignmentAdjustmentTableTableAdapter
        '
        Me.ConsignmentAdjustmentTableTableAdapter.ClearBeforeFill = True
        '
        'gpxFilterDatagrid
        '
        Me.gpxFilterDatagrid.Controls.Add(Me.Label9)
        Me.gpxFilterDatagrid.Location = New System.Drawing.Point(29, 41)
        Me.gpxFilterDatagrid.Name = "gpxFilterDatagrid"
        Me.gpxFilterDatagrid.Size = New System.Drawing.Size(300, 120)
        Me.gpxFilterDatagrid.TabIndex = 0
        Me.gpxFilterDatagrid.TabStop = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(20, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(264, 93)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "The adjustments shown in the datagrid are adjustments that were entered on today'" & _
            "s date. To view other adjustments, go to the View Consignment Adjustment Form."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'cmdPrintListing
        '
        Me.cmdPrintListing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintListing.Enabled = False
        Me.cmdPrintListing.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrintListing.Name = "cmdPrintListing"
        Me.cmdPrintListing.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintListing.TabIndex = 131
        Me.cmdPrintListing.Text = "Print Listing"
        Me.cmdPrintListing.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(476, 783)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(137, 20)
        Me.TextBox1.TabIndex = 132
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(349, 783)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 20)
        Me.Label10.TabIndex = 133
        Me.Label10.Text = "Ext. Amount"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InventoryAdjustmentConsignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdPrintListing)
        Me.Controls.Add(Me.gpxFilterDatagrid)
        Me.Controls.Add(Me.dgvConsignmentAdjustments)
        Me.Controls.Add(Me.gpxCreateAdjustment)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdExit)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InventoryAdjustmentConsignment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Consignment Inventory Adjustment"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxCreateAdjustment.ResumeLayout(False)
        Me.gpxCreateAdjustment.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvConsignmentAdjustments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConsignmentAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxFilterDatagrid.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxCreateAdjustment As System.Windows.Forms.GroupBox
    Friend WithEvents cboWarehouse As System.Windows.Forms.ComboBox
    Friend WithEvents dtpAdjustmentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdAddAdjustment As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvConsignmentAdjustments As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ConsignmentAdjustmentTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ConsignmentAdjustmentTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ConsignmentAdjustmentTableTableAdapter
    Friend WithEvents ConsignmentAdjustmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gpxFilterDatagrid As System.Windows.Forms.GroupBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkSave As System.Windows.Forms.CheckBox
    Friend WithEvents lblQOH As System.Windows.Forms.Label
    Friend WithEvents cmdPrintListing As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
