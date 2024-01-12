<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManufacturingMaintenance
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtTonnage = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtMaxLength = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtMinLength = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtMaxDiameter = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtMinDiameter = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtMaxPiecesPerHour = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtMachineCost = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboMachineClass = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdClear1 = New System.Windows.Forms.Button
        Me.cmdAddUpdateMachine = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtMachineDescription = New System.Windows.Forms.TextBox
        Me.MachineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMachineID = New System.Windows.Forms.ComboBox
        Me.dgvMachineTable = New System.Windows.Forms.DataGridView
        Me.MachineIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineCostPerHour = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxPiecesPerHour = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinDiameter = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxDiameter = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinLength = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaxLength = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tonnage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineClass = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdClear2 = New System.Windows.Forms.Button
        Me.txtDepartmentDescription = New System.Windows.Forms.TextBox
        Me.DepartmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvDepartmentTable = New System.Windows.Forms.DataGridView
        Me.DepartmentIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DepartmentNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DepartmentDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdAddDepartment = New System.Windows.Forms.Button
        Me.txtDepartmentName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboDepartmentID = New System.Windows.Forms.ComboBox
        Me.MachineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MachineTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.DepartmentsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DepartmentsTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tbMachines = New System.Windows.Forms.TabPage
        Me.tbDepartments = New System.Windows.Forms.TabPage
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MachineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMachineTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DepartmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDepartmentTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tbMachines.SuspendLayout()
        Me.tbDepartments.SuspendLayout()
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtTonnage
        '
        Me.txtTonnage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTonnage.Location = New System.Drawing.Point(192, 479)
        Me.txtTonnage.Margin = New System.Windows.Forms.Padding(7)
        Me.txtTonnage.MaxLength = 10
        Me.txtTonnage.Name = "txtTonnage"
        Me.txtTonnage.Size = New System.Drawing.Size(148, 20)
        Me.txtTonnage.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(22, 479)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 20)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Tonnage"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMaxLength
        '
        Me.txtMaxLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxLength.Location = New System.Drawing.Point(192, 442)
        Me.txtMaxLength.Margin = New System.Windows.Forms.Padding(7)
        Me.txtMaxLength.MaxLength = 10
        Me.txtMaxLength.Name = "txtMaxLength"
        Me.txtMaxLength.Size = New System.Drawing.Size(148, 20)
        Me.txtMaxLength.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(22, 442)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 20)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Maximum Length"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMinLength
        '
        Me.txtMinLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMinLength.Location = New System.Drawing.Point(192, 405)
        Me.txtMinLength.Margin = New System.Windows.Forms.Padding(7)
        Me.txtMinLength.MaxLength = 10
        Me.txtMinLength.Name = "txtMinLength"
        Me.txtMinLength.Size = New System.Drawing.Size(148, 20)
        Me.txtMinLength.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(22, 405)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 20)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Minimum Length"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMaxDiameter
        '
        Me.txtMaxDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxDiameter.Location = New System.Drawing.Point(192, 368)
        Me.txtMaxDiameter.Margin = New System.Windows.Forms.Padding(7)
        Me.txtMaxDiameter.MaxLength = 10
        Me.txtMaxDiameter.Name = "txtMaxDiameter"
        Me.txtMaxDiameter.Size = New System.Drawing.Size(148, 20)
        Me.txtMaxDiameter.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(22, 368)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 20)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Maximum Diameter"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMinDiameter
        '
        Me.txtMinDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMinDiameter.Location = New System.Drawing.Point(192, 331)
        Me.txtMinDiameter.Margin = New System.Windows.Forms.Padding(7)
        Me.txtMinDiameter.MaxLength = 10
        Me.txtMinDiameter.Name = "txtMinDiameter"
        Me.txtMinDiameter.Size = New System.Drawing.Size(148, 20)
        Me.txtMinDiameter.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(22, 331)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 20)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Minimum Diameter"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMaxPiecesPerHour
        '
        Me.txtMaxPiecesPerHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxPiecesPerHour.Location = New System.Drawing.Point(192, 294)
        Me.txtMaxPiecesPerHour.Margin = New System.Windows.Forms.Padding(7)
        Me.txtMaxPiecesPerHour.MaxLength = 10
        Me.txtMaxPiecesPerHour.Name = "txtMaxPiecesPerHour"
        Me.txtMaxPiecesPerHour.Size = New System.Drawing.Size(148, 20)
        Me.txtMaxPiecesPerHour.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(22, 294)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 20)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Max Pieces Per Hour"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMachineCost
        '
        Me.txtMachineCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineCost.Location = New System.Drawing.Point(192, 257)
        Me.txtMachineCost.Margin = New System.Windows.Forms.Padding(7)
        Me.txtMachineCost.Name = "txtMachineCost"
        Me.txtMachineCost.Size = New System.Drawing.Size(148, 20)
        Me.txtMachineCost.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(22, 257)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 20)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Machine Cost"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMachineClass
        '
        Me.cboMachineClass.DataSource = Me.MachineTableBindingSource
        Me.cboMachineClass.DisplayMember = "MachineClass"
        Me.cboMachineClass.FormattingEnabled = True
        Me.cboMachineClass.Location = New System.Drawing.Point(115, 211)
        Me.cboMachineClass.Margin = New System.Windows.Forms.Padding(7)
        Me.cboMachineClass.Name = "cboMachineClass"
        Me.cboMachineClass.Size = New System.Drawing.Size(225, 21)
        Me.cboMachineClass.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(22, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 20)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Machine Class"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear1
        '
        Me.cmdClear1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClear1.Location = New System.Drawing.Point(269, 523)
        Me.cmdClear1.Name = "cmdClear1"
        Me.cmdClear1.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear1.TabIndex = 12
        Me.cmdClear1.Text = "Clear Machine"
        Me.cmdClear1.UseVisualStyleBackColor = True
        '
        'cmdAddUpdateMachine
        '
        Me.cmdAddUpdateMachine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAddUpdateMachine.Location = New System.Drawing.Point(192, 523)
        Me.cmdAddUpdateMachine.Name = "cmdAddUpdateMachine"
        Me.cmdAddUpdateMachine.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddUpdateMachine.TabIndex = 11
        Me.cmdAddUpdateMachine.Text = "Add / Update"
        Me.cmdAddUpdateMachine.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(149, 23)
        Me.cboDivisionID.Margin = New System.Windows.Forms.Padding(7)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(195, 21)
        Me.cboDivisionID.TabIndex = 0
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
        'txtMachineDescription
        '
        Me.txtMachineDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMachineDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MachineTableBindingSource, "Description", True))
        Me.txtMachineDescription.Location = New System.Drawing.Point(22, 120)
        Me.txtMachineDescription.Margin = New System.Windows.Forms.Padding(7)
        Me.txtMachineDescription.Multiline = True
        Me.txtMachineDescription.Name = "txtMachineDescription"
        Me.txtMachineDescription.Size = New System.Drawing.Size(315, 63)
        Me.txtMachineDescription.TabIndex = 2
        '
        'MachineTableBindingSource
        '
        Me.MachineTableBindingSource.DataMember = "MachineTable"
        Me.MachineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(22, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Machine Description"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(22, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Division ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(22, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Machine ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMachineID
        '
        Me.cboMachineID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMachineID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMachineID.DataSource = Me.MachineTableBindingSource
        Me.cboMachineID.DisplayMember = "MachineID"
        Me.cboMachineID.FormattingEnabled = True
        Me.cboMachineID.Location = New System.Drawing.Point(115, 58)
        Me.cboMachineID.Margin = New System.Windows.Forms.Padding(7)
        Me.cboMachineID.Name = "cboMachineID"
        Me.cboMachineID.Size = New System.Drawing.Size(229, 21)
        Me.cboMachineID.TabIndex = 1
        '
        'dgvMachineTable
        '
        Me.dgvMachineTable.AllowUserToAddRows = False
        Me.dgvMachineTable.AllowUserToDeleteRows = False
        Me.dgvMachineTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMachineTable.AutoGenerateColumns = False
        Me.dgvMachineTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvMachineTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvMachineTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMachineTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MachineIDDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn, Me.MachineCostPerHour, Me.MaxPiecesPerHour, Me.MinDiameter, Me.MaxDiameter, Me.MinLength, Me.MaxLength, Me.Tonnage, Me.MachineClass})
        Me.dgvMachineTable.DataSource = Me.MachineTableBindingSource
        Me.dgvMachineTable.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvMachineTable.Location = New System.Drawing.Point(363, 0)
        Me.dgvMachineTable.Name = "dgvMachineTable"
        Me.dgvMachineTable.ReadOnly = True
        Me.dgvMachineTable.Size = New System.Drawing.Size(623, 686)
        Me.dgvMachineTable.TabIndex = 22
        '
        'MachineIDDataGridViewTextBoxColumn
        '
        Me.MachineIDDataGridViewTextBoxColumn.DataPropertyName = "MachineID"
        Me.MachineIDDataGridViewTextBoxColumn.FillWeight = 81.47208!
        Me.MachineIDDataGridViewTextBoxColumn.HeaderText = "Machine ID"
        Me.MachineIDDataGridViewTextBoxColumn.Name = "MachineIDDataGridViewTextBoxColumn"
        Me.MachineIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.MachineIDDataGridViewTextBoxColumn.Width = 150
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.FillWeight = 81.47208!
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescriptionDataGridViewTextBoxColumn.Width = 150
        '
        'MachineCostPerHour
        '
        Me.MachineCostPerHour.DataPropertyName = "MachineCostPerHour"
        Me.MachineCostPerHour.HeaderText = "Machine Cost Per Hour"
        Me.MachineCostPerHour.Name = "MachineCostPerHour"
        Me.MachineCostPerHour.ReadOnly = True
        '
        'MaxPiecesPerHour
        '
        Me.MaxPiecesPerHour.DataPropertyName = "MaxPiecesPerHour"
        Me.MaxPiecesPerHour.HeaderText = "Max Pieces Per Hour"
        Me.MaxPiecesPerHour.Name = "MaxPiecesPerHour"
        Me.MaxPiecesPerHour.ReadOnly = True
        '
        'MinDiameter
        '
        Me.MinDiameter.DataPropertyName = "MinDiameter"
        Me.MinDiameter.HeaderText = "Min Diameter"
        Me.MinDiameter.Name = "MinDiameter"
        Me.MinDiameter.ReadOnly = True
        '
        'MaxDiameter
        '
        Me.MaxDiameter.DataPropertyName = "MaxDiameter"
        Me.MaxDiameter.HeaderText = "Max Diameter"
        Me.MaxDiameter.Name = "MaxDiameter"
        Me.MaxDiameter.ReadOnly = True
        '
        'MinLength
        '
        Me.MinLength.DataPropertyName = "MinLength"
        Me.MinLength.HeaderText = "Min Length"
        Me.MinLength.Name = "MinLength"
        Me.MinLength.ReadOnly = True
        '
        'MaxLength
        '
        Me.MaxLength.DataPropertyName = "MaxLength"
        Me.MaxLength.HeaderText = "Max Length"
        Me.MaxLength.Name = "MaxLength"
        Me.MaxLength.ReadOnly = True
        '
        'Tonnage
        '
        Me.Tonnage.DataPropertyName = "Tonnage"
        Me.Tonnage.HeaderText = "Tonnage"
        Me.Tonnage.Name = "Tonnage"
        Me.Tonnage.ReadOnly = True
        '
        'MachineClass
        '
        Me.MachineClass.DataPropertyName = "MachineClass"
        Me.MachineClass.HeaderText = "Machine Class"
        Me.MachineClass.Name = "MachineClass"
        Me.MachineClass.ReadOnly = True
        '
        'cmdClear2
        '
        Me.cmdClear2.Location = New System.Drawing.Point(268, 250)
        Me.cmdClear2.Name = "cmdClear2"
        Me.cmdClear2.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear2.TabIndex = 6
        Me.cmdClear2.Text = "Clear Department"
        Me.cmdClear2.UseVisualStyleBackColor = True
        '
        'txtDepartmentDescription
        '
        Me.txtDepartmentDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartmentDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartmentDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DepartmentsBindingSource, "DepartmentName", True))
        Me.txtDepartmentDescription.Location = New System.Drawing.Point(21, 144)
        Me.txtDepartmentDescription.Multiline = True
        Me.txtDepartmentDescription.Name = "txtDepartmentDescription"
        Me.txtDepartmentDescription.Size = New System.Drawing.Size(318, 81)
        Me.txtDepartmentDescription.TabIndex = 18
        '
        'DepartmentsBindingSource
        '
        Me.DepartmentsBindingSource.DataMember = "Departments"
        Me.DepartmentsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvDepartmentTable
        '
        Me.dgvDepartmentTable.AllowUserToAddRows = False
        Me.dgvDepartmentTable.AllowUserToDeleteRows = False
        Me.dgvDepartmentTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDepartmentTable.AutoGenerateColumns = False
        Me.dgvDepartmentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDepartmentTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvDepartmentTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvDepartmentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDepartmentTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DepartmentIDDataGridViewTextBoxColumn, Me.DepartmentNameDataGridViewTextBoxColumn, Me.DepartmentDescriptionDataGridViewTextBoxColumn, Me.DivisionIDDataGridViewTextBoxColumn1})
        Me.dgvDepartmentTable.DataSource = Me.DepartmentsBindingSource
        Me.dgvDepartmentTable.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvDepartmentTable.Location = New System.Drawing.Point(358, 6)
        Me.dgvDepartmentTable.Name = "dgvDepartmentTable"
        Me.dgvDepartmentTable.Size = New System.Drawing.Size(634, 686)
        Me.dgvDepartmentTable.TabIndex = 17
        '
        'DepartmentIDDataGridViewTextBoxColumn
        '
        Me.DepartmentIDDataGridViewTextBoxColumn.DataPropertyName = "DepartmentID"
        Me.DepartmentIDDataGridViewTextBoxColumn.HeaderText = "Department ID"
        Me.DepartmentIDDataGridViewTextBoxColumn.Name = "DepartmentIDDataGridViewTextBoxColumn"
        '
        'DepartmentNameDataGridViewTextBoxColumn
        '
        Me.DepartmentNameDataGridViewTextBoxColumn.DataPropertyName = "DepartmentName"
        Me.DepartmentNameDataGridViewTextBoxColumn.HeaderText = "Department Name"
        Me.DepartmentNameDataGridViewTextBoxColumn.Name = "DepartmentNameDataGridViewTextBoxColumn"
        '
        'DepartmentDescriptionDataGridViewTextBoxColumn
        '
        Me.DepartmentDescriptionDataGridViewTextBoxColumn.DataPropertyName = "DepartmentDescription"
        Me.DepartmentDescriptionDataGridViewTextBoxColumn.HeaderText = "Department Description"
        Me.DepartmentDescriptionDataGridViewTextBoxColumn.Name = "DepartmentDescriptionDataGridViewTextBoxColumn"
        '
        'DivisionIDDataGridViewTextBoxColumn1
        '
        Me.DivisionIDDataGridViewTextBoxColumn1.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn1.HeaderText = "Division ID"
        Me.DivisionIDDataGridViewTextBoxColumn1.Name = "DivisionIDDataGridViewTextBoxColumn1"
        '
        'cmdAddDepartment
        '
        Me.cmdAddDepartment.Location = New System.Drawing.Point(191, 250)
        Me.cmdAddDepartment.Name = "cmdAddDepartment"
        Me.cmdAddDepartment.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddDepartment.TabIndex = 14
        Me.cmdAddDepartment.Text = "Add / Update"
        Me.cmdAddDepartment.UseVisualStyleBackColor = True
        '
        'txtDepartmentName
        '
        Me.txtDepartmentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartmentName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartmentName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DepartmentsBindingSource, "DepartmentName", True))
        Me.txtDepartmentName.Location = New System.Drawing.Point(114, 76)
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.Size = New System.Drawing.Size(225, 20)
        Me.txtDepartmentName.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(18, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Department Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Description"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(18, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 20)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Department ID"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDepartmentID
        '
        Me.cboDepartmentID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDepartmentID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDepartmentID.DataSource = Me.DepartmentsBindingSource
        Me.cboDepartmentID.DisplayMember = "DepartmentID"
        Me.cboDepartmentID.FormattingEnabled = True
        Me.cboDepartmentID.Location = New System.Drawing.Point(114, 32)
        Me.cboDepartmentID.Name = "cboDepartmentID"
        Me.cboDepartmentID.Size = New System.Drawing.Size(225, 21)
        Me.cboDepartmentID.TabIndex = 8
        '
        'MachineTableTableAdapter
        '
        Me.MachineTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'DepartmentsTableAdapter
        '
        Me.DepartmentsTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 4
        Me.cmdPrint.Text = "Print Machines"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tbMachines)
        Me.TabControl1.Controls.Add(Me.tbDepartments)
        Me.TabControl1.Location = New System.Drawing.Point(29, 41)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1000, 724)
        Me.TabControl1.TabIndex = 5
        '
        'tbMachines
        '
        Me.tbMachines.Controls.Add(Me.txtMachineCost)
        Me.tbMachines.Controls.Add(Me.txtTonnage)
        Me.tbMachines.Controls.Add(Me.Label8)
        Me.tbMachines.Controls.Add(Me.cboMachineClass)
        Me.tbMachines.Controls.Add(Me.cmdClear1)
        Me.tbMachines.Controls.Add(Me.Label14)
        Me.tbMachines.Controls.Add(Me.cmdAddUpdateMachine)
        Me.tbMachines.Controls.Add(Me.Label7)
        Me.tbMachines.Controls.Add(Me.dgvMachineTable)
        Me.tbMachines.Controls.Add(Me.txtMachineDescription)
        Me.tbMachines.Controls.Add(Me.txtMaxLength)
        Me.tbMachines.Controls.Add(Me.Label3)
        Me.tbMachines.Controls.Add(Me.cboDivisionID)
        Me.tbMachines.Controls.Add(Me.Label13)
        Me.tbMachines.Controls.Add(Me.cboMachineID)
        Me.tbMachines.Controls.Add(Me.Label2)
        Me.tbMachines.Controls.Add(Me.txtMinLength)
        Me.tbMachines.Controls.Add(Me.Label9)
        Me.tbMachines.Controls.Add(Me.Label12)
        Me.tbMachines.Controls.Add(Me.txtMaxPiecesPerHour)
        Me.tbMachines.Controls.Add(Me.txtMaxDiameter)
        Me.tbMachines.Controls.Add(Me.Label10)
        Me.tbMachines.Controls.Add(Me.Label11)
        Me.tbMachines.Controls.Add(Me.txtMinDiameter)
        Me.tbMachines.Controls.Add(Me.Label1)
        Me.tbMachines.Location = New System.Drawing.Point(4, 22)
        Me.tbMachines.Name = "tbMachines"
        Me.tbMachines.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMachines.Size = New System.Drawing.Size(992, 698)
        Me.tbMachines.TabIndex = 0
        Me.tbMachines.Text = "Machines"
        Me.tbMachines.UseVisualStyleBackColor = True
        '
        'tbDepartments
        '
        Me.tbDepartments.Controls.Add(Me.cboDepartmentID)
        Me.tbDepartments.Controls.Add(Me.cmdClear2)
        Me.tbDepartments.Controls.Add(Me.txtDepartmentDescription)
        Me.tbDepartments.Controls.Add(Me.txtDepartmentName)
        Me.tbDepartments.Controls.Add(Me.dgvDepartmentTable)
        Me.tbDepartments.Controls.Add(Me.Label5)
        Me.tbDepartments.Controls.Add(Me.Label6)
        Me.tbDepartments.Controls.Add(Me.cmdAddDepartment)
        Me.tbDepartments.Controls.Add(Me.Label4)
        Me.tbDepartments.Location = New System.Drawing.Point(4, 22)
        Me.tbDepartments.Name = "tbDepartments"
        Me.tbDepartments.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDepartments.Size = New System.Drawing.Size(992, 698)
        Me.tbDepartments.TabIndex = 1
        Me.tbDepartments.Text = "Departments"
        Me.tbDepartments.UseVisualStyleBackColor = True
        '
        'ManufacturingMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ManufacturingMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Manufacturing Maintenance"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MachineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMachineTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DepartmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDepartmentTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tbMachines.ResumeLayout(False)
        Me.tbMachines.PerformLayout()
        Me.tbDepartments.ResumeLayout(False)
        Me.tbDepartments.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboMachineID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMachineDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdAddUpdateMachine As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents dgvMachineTable As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents MachineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MachineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MachineTableTableAdapter
    Friend WithEvents cmdAddDepartment As System.Windows.Forms.Button
    Friend WithEvents txtDepartmentName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboDepartmentID As System.Windows.Forms.ComboBox
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents dgvDepartmentTable As System.Windows.Forms.DataGridView
    Friend WithEvents DepartmentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DepartmentsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DepartmentsTableAdapter
    Friend WithEvents DepartmentIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepartmentNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepartmentDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents txtDepartmentDescription As System.Windows.Forms.TextBox
    Friend WithEvents cmdClear1 As System.Windows.Forms.Button
    Friend WithEvents cmdClear2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboMachineClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMachineCost As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxPiecesPerHour As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbMachines As System.Windows.Forms.TabPage
    Friend WithEvents tbDepartments As System.Windows.Forms.TabPage
    Friend WithEvents txtTonnage As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMaxLength As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMinLength As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMaxDiameter As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMinDiameter As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MachineIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineCostPerHour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxPiecesPerHour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinDiameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxDiameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinLength As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxLength As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tonnage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineClass As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
