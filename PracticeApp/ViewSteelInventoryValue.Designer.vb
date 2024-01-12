<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelInventoryValue
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkOmit = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboSteelClass = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.dtpCostingDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.lblSteelSize = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.lblCarbon = New System.Windows.Forms.Label
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.dgvSteelValueTable = New System.Windows.Forms.DataGridView
        Me.SteelCarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValueQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValueCostPerPoundColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValueExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrintDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelValuationTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SteelValuationTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelValuationTableTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrintListing = New System.Windows.Forms.Button
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.dgvRawMaterials = New System.Windows.Forms.DataGridView
        Me.RMIDColumnRM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumnRM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumnRM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumnRM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelClassColumnRM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelStatusColumnRM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelValueTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelValuationTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRawMaterials, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkOmit)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboSteelClass)
        Me.GroupBox1.Controls.Add(Me.chkAllTypes)
        Me.GroupBox1.Controls.Add(Me.dtpCostingDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cmdView)
        Me.GroupBox1.Controls.Add(Me.lblSteelSize)
        Me.GroupBox1.Controls.Add(Me.cboSteelSize)
        Me.GroupBox1.Controls.Add(Me.lblCarbon)
        Me.GroupBox1.Controls.Add(Me.cboCarbon)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 368)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Steel Value Filters"
        '
        'chkOmit
        '
        Me.chkOmit.AutoSize = True
        Me.chkOmit.ForeColor = System.Drawing.Color.Blue
        Me.chkOmit.Location = New System.Drawing.Point(23, 267)
        Me.chkOmit.Name = "chkOmit"
        Me.chkOmit.Size = New System.Drawing.Size(147, 17)
        Me.chkOmit.TabIndex = 5
        Me.chkOmit.Text = "Omit Items with zero QOH"
        Me.chkOmit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Steel Class"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelClass
        '
        Me.cboSteelClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelClass.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelClass.DisplayMember = "SteelClass"
        Me.cboSteelClass.FormattingEnabled = True
        Me.cboSteelClass.Location = New System.Drawing.Point(106, 79)
        Me.cboSteelClass.Name = "cboSteelClass"
        Me.cboSteelClass.Size = New System.Drawing.Size(171, 21)
        Me.cboSteelClass.TabIndex = 9
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(109, 169)
        Me.chkAllTypes.Margin = New System.Windows.Forms.Padding(5)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(168, 17)
        Me.chkAllTypes.TabIndex = 9
        Me.chkAllTypes.Text = "Show all types for given grade"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'dtpCostingDate
        '
        Me.dtpCostingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCostingDate.Location = New System.Drawing.Point(106, 34)
        Me.dtpCostingDate.Name = "dtpCostingDate"
        Me.dtpCostingDate.Size = New System.Drawing.Size(171, 20)
        Me.dtpCostingDate.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 20)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Costing Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(206, 307)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 16
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(130, 307)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 15
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'lblSteelSize
        '
        Me.lblSteelSize.Location = New System.Drawing.Point(20, 210)
        Me.lblSteelSize.Name = "lblSteelSize"
        Me.lblSteelSize.Size = New System.Drawing.Size(76, 20)
        Me.lblSteelSize.TabIndex = 12
        Me.lblSteelSize.Text = "Steel Size"
        Me.lblSteelSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(106, 209)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(171, 21)
        Me.cboSteelSize.TabIndex = 11
        '
        'lblCarbon
        '
        Me.lblCarbon.Location = New System.Drawing.Point(20, 128)
        Me.lblCarbon.Name = "lblCarbon"
        Me.lblCarbon.Size = New System.Drawing.Size(76, 20)
        Me.lblCarbon.TabIndex = 10
        Me.lblCarbon.Text = "Carbon"
        Me.lblCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(106, 127)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(171, 21)
        Me.cboCarbon.TabIndex = 8
        '
        'dgvSteelValueTable
        '
        Me.dgvSteelValueTable.AllowUserToAddRows = False
        Me.dgvSteelValueTable.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSteelValueTable.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSteelValueTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelValueTable.AutoGenerateColumns = False
        Me.dgvSteelValueTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelValueTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelValueTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelValueTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelCarbonColumn, Me.SteelSizeColumn, Me.CostingDateColumn, Me.ValueQuantityColumn, Me.ValueCostPerPoundColumn, Me.ValueExtendedCostColumn, Me.RMIDColumn, Me.PrintDateColumn, Me.UserIDColumn})
        Me.dgvSteelValueTable.DataSource = Me.SteelValuationTableBindingSource
        Me.dgvSteelValueTable.GridColor = System.Drawing.Color.Cyan
        Me.dgvSteelValueTable.Location = New System.Drawing.Point(346, 41)
        Me.dgvSteelValueTable.Name = "dgvSteelValueTable"
        Me.dgvSteelValueTable.Size = New System.Drawing.Size(774, 710)
        Me.dgvSteelValueTable.TabIndex = 2
        '
        'SteelCarbonColumn
        '
        Me.SteelCarbonColumn.DataPropertyName = "SteelCarbon"
        Me.SteelCarbonColumn.HeaderText = "Carbon/Alloy"
        Me.SteelCarbonColumn.Name = "SteelCarbonColumn"
        Me.SteelCarbonColumn.Width = 130
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        '
        'CostingDateColumn
        '
        Me.CostingDateColumn.DataPropertyName = "CostingDate"
        Me.CostingDateColumn.HeaderText = "Costing Date"
        Me.CostingDateColumn.Name = "CostingDateColumn"
        '
        'ValueQuantityColumn
        '
        Me.ValueQuantityColumn.DataPropertyName = "ValueQuantity"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.ValueQuantityColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ValueQuantityColumn.HeaderText = "Quantity"
        Me.ValueQuantityColumn.Name = "ValueQuantityColumn"
        Me.ValueQuantityColumn.Width = 90
        '
        'ValueCostPerPoundColumn
        '
        Me.ValueCostPerPoundColumn.DataPropertyName = "ValueCostPerPound"
        DataGridViewCellStyle3.Format = "C4"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ValueCostPerPoundColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ValueCostPerPoundColumn.HeaderText = "Cost/Pound"
        Me.ValueCostPerPoundColumn.Name = "ValueCostPerPoundColumn"
        Me.ValueCostPerPoundColumn.Width = 90
        '
        'ValueExtendedCostColumn
        '
        Me.ValueExtendedCostColumn.DataPropertyName = "ValueExtendedCost"
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.ValueExtendedCostColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ValueExtendedCostColumn.HeaderText = "Extended Cost"
        Me.ValueExtendedCostColumn.Name = "ValueExtendedCostColumn"
        Me.ValueExtendedCostColumn.Width = 90
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.Width = 120
        '
        'PrintDateColumn
        '
        Me.PrintDateColumn.DataPropertyName = "PrintDate"
        Me.PrintDateColumn.HeaderText = "Print Date"
        Me.PrintDateColumn.Name = "PrintDateColumn"
        Me.PrintDateColumn.Visible = False
        '
        'UserIDColumn
        '
        Me.UserIDColumn.DataPropertyName = "UserID"
        Me.UserIDColumn.HeaderText = "UserID"
        Me.UserIDColumn.Name = "UserIDColumn"
        Me.UserIDColumn.Visible = False
        '
        'SteelValuationTableBindingSource
        '
        Me.SteelValuationTableBindingSource.DataMember = "SteelValuationTable"
        Me.SteelValuationTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SteelValuationTableTableAdapter
        '
        Me.SteelValuationTableTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(1049, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrintListing
        '
        Me.cmdPrintListing.Location = New System.Drawing.Point(973, 771)
        Me.cmdPrintListing.Name = "cmdPrintListing"
        Me.cmdPrintListing.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintListing.TabIndex = 17
        Me.cmdPrintListing.Text = "Print Listing"
        Me.cmdPrintListing.UseVisualStyleBackColor = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'dgvRawMaterials
        '
        Me.dgvRawMaterials.AllowUserToAddRows = False
        Me.dgvRawMaterials.AllowUserToDeleteRows = False
        Me.dgvRawMaterials.AutoGenerateColumns = False
        Me.dgvRawMaterials.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRawMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRawMaterials.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RMIDColumnRM, Me.CarbonColumnRM, Me.SteelSizeColumnRM, Me.DivisionIDColumnRM, Me.SteelClassColumnRM, Me.SteelStatusColumnRM})
        Me.dgvRawMaterials.DataSource = Me.RawMaterialsTableBindingSource
        Me.dgvRawMaterials.Location = New System.Drawing.Point(29, 431)
        Me.dgvRawMaterials.Name = "dgvRawMaterials"
        Me.dgvRawMaterials.ReadOnly = True
        Me.dgvRawMaterials.Size = New System.Drawing.Size(300, 320)
        Me.dgvRawMaterials.TabIndex = 19
        Me.dgvRawMaterials.Visible = False
        '
        'RMIDColumnRM
        '
        Me.RMIDColumnRM.DataPropertyName = "RMID"
        Me.RMIDColumnRM.HeaderText = "RMID"
        Me.RMIDColumnRM.Name = "RMIDColumnRM"
        Me.RMIDColumnRM.ReadOnly = True
        '
        'CarbonColumnRM
        '
        Me.CarbonColumnRM.DataPropertyName = "Carbon"
        Me.CarbonColumnRM.HeaderText = "Carbon"
        Me.CarbonColumnRM.Name = "CarbonColumnRM"
        Me.CarbonColumnRM.ReadOnly = True
        '
        'SteelSizeColumnRM
        '
        Me.SteelSizeColumnRM.DataPropertyName = "SteelSize"
        Me.SteelSizeColumnRM.HeaderText = "SteelSize"
        Me.SteelSizeColumnRM.Name = "SteelSizeColumnRM"
        Me.SteelSizeColumnRM.ReadOnly = True
        '
        'DivisionIDColumnRM
        '
        Me.DivisionIDColumnRM.DataPropertyName = "DivisionID"
        Me.DivisionIDColumnRM.HeaderText = "DivisionID"
        Me.DivisionIDColumnRM.Name = "DivisionIDColumnRM"
        Me.DivisionIDColumnRM.ReadOnly = True
        '
        'SteelClassColumnRM
        '
        Me.SteelClassColumnRM.DataPropertyName = "SteelClass"
        Me.SteelClassColumnRM.HeaderText = "SteelClass"
        Me.SteelClassColumnRM.Name = "SteelClassColumnRM"
        Me.SteelClassColumnRM.ReadOnly = True
        '
        'SteelStatusColumnRM
        '
        Me.SteelStatusColumnRM.DataPropertyName = "SteelStatus"
        Me.SteelStatusColumnRM.HeaderText = "SteelStatus"
        Me.SteelStatusColumnRM.Name = "SteelStatusColumnRM"
        Me.SteelStatusColumnRM.ReadOnly = True
        '
        'ViewSteelInventoryValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvRawMaterials)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrintListing)
        Me.Controls.Add(Me.dgvSteelValueTable)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewSteelInventoryValue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Inventory Value"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelValueTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelValuationTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRawMaterials, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSteelClass As System.Windows.Forms.ComboBox
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
    Friend WithEvents dtpCostingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents lblSteelSize As System.Windows.Forms.Label
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblCarbon As System.Windows.Forms.Label
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents chkOmit As System.Windows.Forms.CheckBox
    Friend WithEvents dgvSteelValueTable As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelValuationTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelValuationTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelValuationTableTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrintListing As System.Windows.Forms.Button
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents dgvRawMaterials As System.Windows.Forms.DataGridView
    Friend WithEvents RMIDColumnRM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumnRM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumnRM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumnRM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelClassColumnRM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelStatusColumnRM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValueQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValueCostPerPoundColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValueExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
