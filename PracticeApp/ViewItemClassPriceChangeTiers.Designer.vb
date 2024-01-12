<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewItemClassPriceChangeTiers
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkFilterDate = New System.Windows.Forms.CheckBox
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdFilter = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpBracketDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExittToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdClearTier = New System.Windows.Forms.Button
        Me.cmdAddTier = New System.Windows.Forms.Button
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.nbrAddTierNumber = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAdjustmentRate = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboAddItemClass = New System.Windows.Forms.ComboBox
        Me.dgvPriceChangeTiers = New System.Windows.Forms.DataGridView
        Me.PriceClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BeginDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EndDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceAdjustmentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostTierNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemPriceChangeTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemPriceChangeTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemPriceChangeTableTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.cmdDeleteTier = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nbrAddTierNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPriceChangeTiers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemPriceChangeTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkFilterDate)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cmdFilter)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpBracketDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboItemClass)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 260)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View By Filters"
        '
        'chkFilterDate
        '
        Me.chkFilterDate.AutoSize = True
        Me.chkFilterDate.Location = New System.Drawing.Point(118, 136)
        Me.chkFilterDate.Name = "chkFilterDate"
        Me.chkFilterDate.Size = New System.Drawing.Size(88, 17)
        Me.chkFilterDate.TabIndex = 3
        Me.chkFilterDate.Text = "Filter by Date"
        Me.chkFilterDate.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 212)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 6
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdFilter
        '
        Me.cmdFilter.Location = New System.Drawing.Point(135, 212)
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdFilter.TabIndex = 5
        Me.cmdFilter.Text = "Filter"
        Me.cmdFilter.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Bracket Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBracketDate
        '
        Me.dtpBracketDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBracketDate.Location = New System.Drawing.Point(118, 169)
        Me.dtpBracketDate.Name = "dtpBracketDate"
        Me.dtpBracketDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpBracketDate.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Item Class"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(118, 82)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(165, 21)
        Me.cboItemClass.TabIndex = 2
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
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Division"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(118, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(165, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExittToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 1
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
        'ExittToolStripMenuItem
        '
        Me.ExittToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.ExittToolStripMenuItem.Name = "ExittToolStripMenuItem"
        Me.ExittToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExittToolStripMenuItem.Text = "Exit"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cmdClearTier)
        Me.GroupBox2.Controls.Add(Me.cmdAddTier)
        Me.GroupBox2.Controls.Add(Me.txtComment)
        Me.GroupBox2.Controls.Add(Me.nbrAddTierNumber)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtAdjustmentRate)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dtpEndDate)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dtpBeginDate)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cboAddItemClass)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 322)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 489)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add New Tier"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 299)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 23)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Comment"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearTier
        '
        Me.cmdClearTier.Location = New System.Drawing.Point(212, 439)
        Me.cmdClearTier.Name = "cmdClearTier"
        Me.cmdClearTier.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearTier.TabIndex = 16
        Me.cmdClearTier.Text = "Clear"
        Me.cmdClearTier.UseVisualStyleBackColor = True
        '
        'cmdAddTier
        '
        Me.cmdAddTier.Location = New System.Drawing.Point(135, 439)
        Me.cmdAddTier.Name = "cmdAddTier"
        Me.cmdAddTier.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddTier.TabIndex = 15
        Me.cmdAddTier.Text = "Add Tier"
        Me.cmdAddTier.UseVisualStyleBackColor = True
        '
        'txtComment
        '
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(20, 325)
        Me.txtComment.MaxLength = 100
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(263, 93)
        Me.txtComment.TabIndex = 14
        '
        'nbrAddTierNumber
        '
        Me.nbrAddTierNumber.Location = New System.Drawing.Point(163, 248)
        Me.nbrAddTierNumber.Name = "nbrAddTierNumber"
        Me.nbrAddTierNumber.Size = New System.Drawing.Size(120, 20)
        Me.nbrAddTierNumber.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 248)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 23)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Price Tier #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAdjustmentRate
        '
        Me.txtAdjustmentRate.Location = New System.Drawing.Point(118, 196)
        Me.txtAdjustmentRate.Name = "txtAdjustmentRate"
        Me.txtAdjustmentRate.Size = New System.Drawing.Size(165, 20)
        Me.txtAdjustmentRate.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 23)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Adj. Rate"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 23)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "End Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(118, 144)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 23)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Begin Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(118, 92)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 23)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Item Class"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAddItemClass
        '
        Me.cboAddItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAddItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAddItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboAddItemClass.DisplayMember = "ItemClassID"
        Me.cboAddItemClass.FormattingEnabled = True
        Me.cboAddItemClass.Location = New System.Drawing.Point(118, 39)
        Me.cboAddItemClass.Name = "cboAddItemClass"
        Me.cboAddItemClass.Size = New System.Drawing.Size(165, 21)
        Me.cboAddItemClass.TabIndex = 8
        '
        'dgvPriceChangeTiers
        '
        Me.dgvPriceChangeTiers.AllowUserToAddRows = False
        Me.dgvPriceChangeTiers.AllowUserToDeleteRows = False
        Me.dgvPriceChangeTiers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPriceChangeTiers.AutoGenerateColumns = False
        Me.dgvPriceChangeTiers.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvPriceChangeTiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPriceChangeTiers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PriceClassColumn, Me.BeginDateColumn, Me.EndDateColumn, Me.PriceAdjustmentColumn, Me.CostTierNumberColumn, Me.CommentColumn, Me.DivisionIDColumn})
        Me.dgvPriceChangeTiers.DataSource = Me.ItemPriceChangeTableBindingSource
        Me.dgvPriceChangeTiers.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvPriceChangeTiers.Location = New System.Drawing.Point(345, 41)
        Me.dgvPriceChangeTiers.Name = "dgvPriceChangeTiers"
        Me.dgvPriceChangeTiers.ReadOnly = True
        Me.dgvPriceChangeTiers.Size = New System.Drawing.Size(785, 710)
        Me.dgvPriceChangeTiers.TabIndex = 3
        '
        'PriceClassColumn
        '
        Me.PriceClassColumn.DataPropertyName = "PriceClass"
        Me.PriceClassColumn.HeaderText = "Price Class"
        Me.PriceClassColumn.Name = "PriceClassColumn"
        '
        'BeginDateColumn
        '
        Me.BeginDateColumn.DataPropertyName = "BeginDate"
        Me.BeginDateColumn.HeaderText = "Begin Date"
        Me.BeginDateColumn.Name = "BeginDateColumn"
        '
        'EndDateColumn
        '
        Me.EndDateColumn.DataPropertyName = "EndDate"
        Me.EndDateColumn.HeaderText = "End Date"
        Me.EndDateColumn.Name = "EndDateColumn"
        '
        'PriceAdjustmentColumn
        '
        Me.PriceAdjustmentColumn.DataPropertyName = "PriceAdjustment"
        Me.PriceAdjustmentColumn.HeaderText = "Price Adjustment"
        Me.PriceAdjustmentColumn.Name = "PriceAdjustmentColumn"
        '
        'CostTierNumberColumn
        '
        Me.CostTierNumberColumn.DataPropertyName = "CostTierNumber"
        Me.CostTierNumberColumn.HeaderText = "Cost Tier #"
        Me.CostTierNumberColumn.Name = "CostTierNumberColumn"
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
        'ItemPriceChangeTableBindingSource
        '
        Me.ItemPriceChangeTableBindingSource.DataMember = "ItemPriceChangeTable"
        Me.ItemPriceChangeTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemPriceChangeTableTableAdapter
        '
        Me.ItemPriceChangeTableTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'cmdDeleteTier
        '
        Me.cmdDeleteTier.Enabled = False
        Me.cmdDeleteTier.Location = New System.Drawing.Point(345, 771)
        Me.cmdDeleteTier.Name = "cmdDeleteTier"
        Me.cmdDeleteTier.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteTier.TabIndex = 19
        Me.cmdDeleteTier.Text = "Delete Tier"
        Me.cmdDeleteTier.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(422, 771)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(281, 40)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Select Price Change Tier in the datagrid to delete."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewItemClassPriceChangeTiers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdDeleteTier)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvPriceChangeTiers)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewItemClassPriceChangeTiers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Item Class Price Change Tiers"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nbrAddTierNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPriceChangeTiers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemPriceChangeTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExittToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPriceChangeTiers As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemPriceChangeTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemPriceChangeTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemPriceChangeTableTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdFilter As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpBracketDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents PriceClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeginDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceAdjustmentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostTierNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkFilterDate As System.Windows.Forms.CheckBox
    Friend WithEvents nbrAddTierNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAdjustmentRate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboAddItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdClearTier As System.Windows.Forms.Button
    Friend WithEvents cmdAddTier As System.Windows.Forms.Button
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents cmdDeleteTier As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
