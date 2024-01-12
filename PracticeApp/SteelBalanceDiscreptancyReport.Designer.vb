<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelBalanceDiscreptancyReport
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
        Me.gpxSearchFields = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDoesNotContain = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTextSearch = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkZeroDiscrepancy = New System.Windows.Forms.CheckBox
        Me.chkZeroCoils = New System.Windows.Forms.CheckBox
        Me.chkZeroQOH = New System.Windows.Forms.CheckBox
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvInventory = New System.Windows.Forms.DataGridView
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CalculatedSteelBalanceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelBalanceFromCoilTableColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DifferenceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelBalanceDiscreptancyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxRawMaterialForm = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdOpenRawMaterialMaintenanceForm = New System.Windows.Forms.Button
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.SteelBalanceDiscreptancyTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelBalanceDiscreptancyTableAdapter
        Me.gpxSearchFields.SuspendLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelBalanceDiscreptancyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxRawMaterialForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpxSearchFields
        '
        Me.gpxSearchFields.Controls.Add(Me.Label6)
        Me.gpxSearchFields.Controls.Add(Me.txtDoesNotContain)
        Me.gpxSearchFields.Controls.Add(Me.Label5)
        Me.gpxSearchFields.Controls.Add(Me.txtTextSearch)
        Me.gpxSearchFields.Controls.Add(Me.Label3)
        Me.gpxSearchFields.Controls.Add(Me.chkZeroDiscrepancy)
        Me.gpxSearchFields.Controls.Add(Me.chkZeroCoils)
        Me.gpxSearchFields.Controls.Add(Me.chkZeroQOH)
        Me.gpxSearchFields.Controls.Add(Me.cboSteelSize)
        Me.gpxSearchFields.Controls.Add(Me.cboCarbon)
        Me.gpxSearchFields.Controls.Add(Me.cmdSearch)
        Me.gpxSearchFields.Controls.Add(Me.Label2)
        Me.gpxSearchFields.Controls.Add(Me.cmdClear)
        Me.gpxSearchFields.Controls.Add(Me.Label1)
        Me.gpxSearchFields.Location = New System.Drawing.Point(12, 44)
        Me.gpxSearchFields.Name = "gpxSearchFields"
        Me.gpxSearchFields.Size = New System.Drawing.Size(300, 523)
        Me.gpxSearchFields.TabIndex = 0
        Me.gpxSearchFields.TabStop = False
        Me.gpxSearchFields.Text = "View By Filters"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(18, 246)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(266, 49)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Filter where description ""Does Not Contain"" specific phrase"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDoesNotContain
        '
        Me.txtDoesNotContain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDoesNotContain.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDoesNotContain.Location = New System.Drawing.Point(117, 223)
        Me.txtDoesNotContain.Name = "txtDoesNotContain"
        Me.txtDoesNotContain.Size = New System.Drawing.Size(167, 20)
        Me.txtDoesNotContain.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(20, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 20)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Does Not Contain"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextSearch
        '
        Me.txtTextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextSearch.Location = New System.Drawing.Point(116, 160)
        Me.txtTextSearch.Name = "txtTextSearch"
        Me.txtTextSearch.Size = New System.Drawing.Size(168, 20)
        Me.txtTextSearch.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Text Filter"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkZeroDiscrepancy
        '
        Me.chkZeroDiscrepancy.AutoSize = True
        Me.chkZeroDiscrepancy.Location = New System.Drawing.Point(18, 426)
        Me.chkZeroDiscrepancy.Name = "chkZeroDiscrepancy"
        Me.chkZeroDiscrepancy.Size = New System.Drawing.Size(171, 17)
        Me.chkZeroDiscrepancy.TabIndex = 6
        Me.chkZeroDiscrepancy.Text = "Omit Steel with no discrepancy"
        Me.chkZeroDiscrepancy.UseVisualStyleBackColor = True
        '
        'chkZeroCoils
        '
        Me.chkZeroCoils.AutoSize = True
        Me.chkZeroCoils.Location = New System.Drawing.Point(18, 383)
        Me.chkZeroCoils.Name = "chkZeroCoils"
        Me.chkZeroCoils.Size = New System.Drawing.Size(158, 17)
        Me.chkZeroCoils.TabIndex = 5
        Me.chkZeroCoils.Text = "Omit Steel with no Coil QOH"
        Me.chkZeroCoils.UseVisualStyleBackColor = True
        '
        'chkZeroQOH
        '
        Me.chkZeroQOH.AutoSize = True
        Me.chkZeroQOH.Location = New System.Drawing.Point(18, 340)
        Me.chkZeroQOH.Name = "chkZeroQOH"
        Me.chkZeroQOH.Size = New System.Drawing.Size(138, 17)
        Me.chkZeroQOH.TabIndex = 4
        Me.chkZeroQOH.Text = "Omit Steel with no QOH"
        Me.chkZeroQOH.UseVisualStyleBackColor = True
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(94, 96)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(190, 21)
        Me.cboSteelSize.TabIndex = 1
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
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(94, 32)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(190, 21)
        Me.cboCarbon.TabIndex = 0
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(136, 478)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(71, 30)
        Me.cmdSearch.TabIndex = 7
        Me.cmdSearch.Text = "View"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Carbon"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 478)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Steel Size"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 2
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
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
        'dgvInventory
        '
        Me.dgvInventory.AllowUserToAddRows = False
        Me.dgvInventory.AllowUserToDeleteRows = False
        Me.dgvInventory.AllowUserToOrderColumns = True
        Me.dgvInventory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventory.AutoGenerateColumns = False
        Me.dgvInventory.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInventory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RMIDColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.DescriptionColumn, Me.CalculatedSteelBalanceColumn, Me.SteelBalanceFromCoilTableColumn, Me.DifferenceColumn})
        Me.dgvInventory.DataSource = Me.SteelBalanceDiscreptancyBindingSource
        Me.dgvInventory.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvInventory.Location = New System.Drawing.Point(330, 44)
        Me.dgvInventory.Name = "dgvInventory"
        Me.dgvInventory.ReadOnly = True
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.dgvInventory.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventory.Size = New System.Drawing.Size(700, 714)
        Me.dgvInventory.TabIndex = 13
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        Me.RMIDColumn.Visible = False
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon/Alloy"
        Me.CarbonColumn.Name = "CarbonColumn"
        Me.CarbonColumn.ReadOnly = True
        Me.CarbonColumn.Width = 110
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Diameter"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.ReadOnly = True
        Me.SteelSizeColumn.Width = 109
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.ReadOnly = True
        Me.DescriptionColumn.Width = 110
        '
        'CalculatedSteelBalanceColumn
        '
        Me.CalculatedSteelBalanceColumn.DataPropertyName = "CalculatedSteelBalance"
        Me.CalculatedSteelBalanceColumn.HeaderText = "Steel QOH"
        Me.CalculatedSteelBalanceColumn.Name = "CalculatedSteelBalanceColumn"
        Me.CalculatedSteelBalanceColumn.ReadOnly = True
        Me.CalculatedSteelBalanceColumn.Width = 109
        '
        'SteelBalanceFromCoilTableColumn
        '
        Me.SteelBalanceFromCoilTableColumn.DataPropertyName = "SteelBalanceFromCoilTable"
        Me.SteelBalanceFromCoilTableColumn.HeaderText = "Coil QOH"
        Me.SteelBalanceFromCoilTableColumn.Name = "SteelBalanceFromCoilTableColumn"
        Me.SteelBalanceFromCoilTableColumn.ReadOnly = True
        Me.SteelBalanceFromCoilTableColumn.Width = 110
        '
        'DifferenceColumn
        '
        Me.DifferenceColumn.DataPropertyName = "Difference"
        Me.DifferenceColumn.HeaderText = "Difference"
        Me.DifferenceColumn.Name = "DifferenceColumn"
        Me.DifferenceColumn.ReadOnly = True
        Me.DifferenceColumn.Width = 109
        '
        'SteelBalanceDiscreptancyBindingSource
        '
        Me.SteelBalanceDiscreptancyBindingSource.DataMember = "SteelBalanceDiscreptancy"
        Me.SteelBalanceDiscreptancyBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 10
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 11
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxRawMaterialForm
        '
        Me.gpxRawMaterialForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpxRawMaterialForm.Controls.Add(Me.Label4)
        Me.gpxRawMaterialForm.Controls.Add(Me.cmdOpenRawMaterialMaintenanceForm)
        Me.gpxRawMaterialForm.Location = New System.Drawing.Point(12, 723)
        Me.gpxRawMaterialForm.Name = "gpxRawMaterialForm"
        Me.gpxRawMaterialForm.Size = New System.Drawing.Size(300, 88)
        Me.gpxRawMaterialForm.TabIndex = 9
        Me.gpxRawMaterialForm.TabStop = False
        Me.gpxRawMaterialForm.Text = "Raw Material Maintenance"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(30, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 38)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Loads Raw Materials Form and closes this form..."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenRawMaterialMaintenanceForm
        '
        Me.cmdOpenRawMaterialMaintenanceForm.Location = New System.Drawing.Point(214, 30)
        Me.cmdOpenRawMaterialMaintenanceForm.Name = "cmdOpenRawMaterialMaintenanceForm"
        Me.cmdOpenRawMaterialMaintenanceForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenRawMaterialMaintenanceForm.TabIndex = 9
        Me.cmdOpenRawMaterialMaintenanceForm.Text = "Raw Materials"
        Me.cmdOpenRawMaterialMaintenanceForm.UseVisualStyleBackColor = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'SteelBalanceDiscreptancyTableAdapter
        '
        Me.SteelBalanceDiscreptancyTableAdapter.ClearBeforeFill = True
        '
        'SteelBalanceDiscreptancyReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.gpxRawMaterialForm)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvInventory)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.gpxSearchFields)
        Me.Name = "SteelBalanceDiscreptancyReport"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Steel Balance Discrepancy Report"
        Me.gpxSearchFields.ResumeLayout(False)
        Me.gpxSearchFields.PerformLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelBalanceDiscreptancyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxRawMaterialForm.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxSearchFields As System.Windows.Forms.GroupBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvInventory As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxRawMaterialForm As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdOpenRawMaterialMaintenanceForm As System.Windows.Forms.Button
    Friend WithEvents chkZeroQOH As System.Windows.Forms.CheckBox
    Friend WithEvents chkZeroDiscrepancy As System.Windows.Forms.CheckBox
    Friend WithEvents chkZeroCoils As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTextSearch As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents SteelBalanceDiscreptancyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelBalanceDiscreptancyTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelBalanceDiscreptancyTableAdapter
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalculatedSteelBalanceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelBalanceFromCoilTableColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DifferenceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDoesNotContain As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
