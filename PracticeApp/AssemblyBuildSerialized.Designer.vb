<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssemblyBuildSerialized
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxItemInformation = New System.Windows.Forms.GroupBox
        Me.txtQOH = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtAssemblyCost = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboAssemblyPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtAssemblyDescription = New System.Windows.Forms.TextBox
        Me.cboAssemblyPartNumber = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblItemNumber = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.gpxDelete = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDeletePartDescription = New System.Windows.Forms.ComboBox
        Me.AssemblyLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDeletePartNumber = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdDeleteComponent = New System.Windows.Forms.Button
        Me.gpxAdd = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtComponentQuantity = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboComponentDescription = New System.Windows.Forms.ComboBox
        Me.cboComponentPart = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdAddComponent = New System.Windows.Forms.Button
        Me.dgvAssemblyLineTable = New System.Windows.Forms.DataGridView
        Me.AssemblyPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QOHColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyLineTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.gpxBuildGroupBox = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdReverse = New System.Windows.Forms.Button
        Me.cmdBuildAssembly = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpBuildDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtBuildComment = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBuildQuantity = New System.Windows.Forms.TextBox
        Me.AssemblySerialLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AssemblySerialLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialLogTableAdapter
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdClearTab = New System.Windows.Forms.Button
        Me.cmdContinue = New System.Windows.Forms.Button
        Me.dgvTempSerialLog = New System.Windows.Forms.DataGridView
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyPartNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.pnlSerialLog = New System.Windows.Forms.Panel
        Me.cmdRemoveSerialNumbers = New System.Windows.Forms.Button
        Me.pnlAssemblyLines = New System.Windows.Forms.Panel
        Me.MenuStrip1.SuspendLayout()
        Me.gpxItemInformation.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxDelete.SuspendLayout()
        CType(Me.AssemblyLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxAdd.SuspendLayout()
        CType(Me.dgvAssemblyLineTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxBuildGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AssemblySerialLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTempSerialLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSerialLog.SuspendLayout()
        Me.pnlAssemblyLines.SuspendLayout()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintBOMToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintBOMToolStripMenuItem
        '
        Me.PrintBOMToolStripMenuItem.Name = "PrintBOMToolStripMenuItem"
        Me.PrintBOMToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.PrintBOMToolStripMenuItem.Text = "Print BOM"
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
        'gpxItemInformation
        '
        Me.gpxItemInformation.Controls.Add(Me.txtQOH)
        Me.gpxItemInformation.Controls.Add(Me.Label18)
        Me.gpxItemInformation.Controls.Add(Me.txtAssemblyCost)
        Me.gpxItemInformation.Controls.Add(Me.Label11)
        Me.gpxItemInformation.Controls.Add(Me.cboAssemblyPartDescription)
        Me.gpxItemInformation.Controls.Add(Me.txtAssemblyDescription)
        Me.gpxItemInformation.Controls.Add(Me.cboAssemblyPartNumber)
        Me.gpxItemInformation.Controls.Add(Me.Label6)
        Me.gpxItemInformation.Controls.Add(Me.lblItemNumber)
        Me.gpxItemInformation.Controls.Add(Me.cboDivisionID)
        Me.gpxItemInformation.Controls.Add(Me.Label4)
        Me.gpxItemInformation.Location = New System.Drawing.Point(29, 41)
        Me.gpxItemInformation.Name = "gpxItemInformation"
        Me.gpxItemInformation.Size = New System.Drawing.Size(300, 311)
        Me.gpxItemInformation.TabIndex = 0
        Me.gpxItemInformation.TabStop = False
        Me.gpxItemInformation.Text = "Select Assembly Part Number"
        '
        'txtQOH
        '
        Me.txtQOH.BackColor = System.Drawing.Color.White
        Me.txtQOH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQOH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQOH.Location = New System.Drawing.Point(131, 275)
        Me.txtQOH.Name = "txtQOH"
        Me.txtQOH.ReadOnly = True
        Me.txtQOH.Size = New System.Drawing.Size(153, 20)
        Me.txtQOH.TabIndex = 6
        Me.txtQOH.TabStop = False
        Me.txtQOH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(18, 275)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(116, 20)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "Assembly QOH"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAssemblyCost
        '
        Me.txtAssemblyCost.BackColor = System.Drawing.Color.White
        Me.txtAssemblyCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAssemblyCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAssemblyCost.Location = New System.Drawing.Point(131, 249)
        Me.txtAssemblyCost.Name = "txtAssemblyCost"
        Me.txtAssemblyCost.ReadOnly = True
        Me.txtAssemblyCost.Size = New System.Drawing.Size(153, 20)
        Me.txtAssemblyCost.TabIndex = 5
        Me.txtAssemblyCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(18, 249)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 20)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Assembly Cost (BOM)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAssemblyPartDescription
        '
        Me.cboAssemblyPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssemblyPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssemblyPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboAssemblyPartDescription.DisplayMember = "ShortDescription"
        Me.cboAssemblyPartDescription.FormattingEnabled = True
        Me.cboAssemblyPartDescription.Location = New System.Drawing.Point(19, 99)
        Me.cboAssemblyPartDescription.Name = "cboAssemblyPartDescription"
        Me.cboAssemblyPartDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboAssemblyPartDescription.TabIndex = 3
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
        'txtAssemblyDescription
        '
        Me.txtAssemblyDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAssemblyDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAssemblyDescription.Location = New System.Drawing.Point(19, 135)
        Me.txtAssemblyDescription.Multiline = True
        Me.txtAssemblyDescription.Name = "txtAssemblyDescription"
        Me.txtAssemblyDescription.Size = New System.Drawing.Size(265, 96)
        Me.txtAssemblyDescription.TabIndex = 4
        Me.txtAssemblyDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboAssemblyPartNumber
        '
        Me.cboAssemblyPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssemblyPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssemblyPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboAssemblyPartNumber.DisplayMember = "ItemID"
        Me.cboAssemblyPartNumber.FormattingEnabled = True
        Me.cboAssemblyPartNumber.Location = New System.Drawing.Point(86, 64)
        Me.cboAssemblyPartNumber.Name = "cboAssemblyPartNumber"
        Me.cboAssemblyPartNumber.Size = New System.Drawing.Size(198, 21)
        Me.cboAssemblyPartNumber.TabIndex = 2
        Me.cboAssemblyPartNumber.ValueMember = "ItemClassID"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(202, -20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 17)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Long Description"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemNumber
        '
        Me.lblItemNumber.Location = New System.Drawing.Point(16, 65)
        Me.lblItemNumber.Name = "lblItemNumber"
        Me.lblItemNumber.Size = New System.Drawing.Size(107, 20)
        Me.lblItemNumber.TabIndex = 1
        Me.lblItemNumber.Text = "Part #"
        Me.lblItemNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(86, 29)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(198, 21)
        Me.cboDivisionID.TabIndex = 1
        Me.cboDivisionID.ValueMember = "ItemClassID"
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(29, 355)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(300, 52)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "Assemblies are created and maintained in Item Maintenance. You may add or delete " & _
            "components from this build using the modules below."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxDelete
        '
        Me.gpxDelete.Controls.Add(Me.Label16)
        Me.gpxDelete.Controls.Add(Me.Label1)
        Me.gpxDelete.Controls.Add(Me.cboDeletePartDescription)
        Me.gpxDelete.Controls.Add(Me.cboDeletePartNumber)
        Me.gpxDelete.Controls.Add(Me.Label5)
        Me.gpxDelete.Controls.Add(Me.cmdDeleteComponent)
        Me.gpxDelete.Location = New System.Drawing.Point(29, 641)
        Me.gpxDelete.Name = "gpxDelete"
        Me.gpxDelete.Size = New System.Drawing.Size(300, 168)
        Me.gpxDelete.TabIndex = 13
        Me.gpxDelete.TabStop = False
        Me.gpxDelete.Text = "Delete Component"
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(19, 122)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(188, 36)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Deleting a row removes it from this build, not the assembly itself."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(18, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(266, 33)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "To delete a component completely from this build, select in grid or from drop dow" & _
            "n box."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDeletePartDescription
        '
        Me.cboDeletePartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeletePartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeletePartDescription.DataSource = Me.AssemblyLineTableBindingSource
        Me.cboDeletePartDescription.DisplayMember = "ComponentPartDescription"
        Me.cboDeletePartDescription.FormattingEnabled = True
        Me.cboDeletePartDescription.Location = New System.Drawing.Point(19, 89)
        Me.cboDeletePartDescription.Name = "cboDeletePartDescription"
        Me.cboDeletePartDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboDeletePartDescription.TabIndex = 15
        '
        'AssemblyLineTableBindingSource
        '
        Me.AssemblyLineTableBindingSource.DataMember = "AssemblyLineTable"
        Me.AssemblyLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDeletePartNumber
        '
        Me.cboDeletePartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeletePartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeletePartNumber.DataSource = Me.AssemblyLineTableBindingSource
        Me.cboDeletePartNumber.DisplayMember = "ComponentPartNumber"
        Me.cboDeletePartNumber.FormattingEnabled = True
        Me.cboDeletePartNumber.Location = New System.Drawing.Point(86, 52)
        Me.cboDeletePartNumber.Name = "cboDeletePartNumber"
        Me.cboDeletePartNumber.Size = New System.Drawing.Size(198, 21)
        Me.cboDeletePartNumber.TabIndex = 14
        Me.cboDeletePartNumber.ValueMember = "ItemClassID"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 20)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Part #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteComponent
        '
        Me.cmdDeleteComponent.Location = New System.Drawing.Point(213, 122)
        Me.cmdDeleteComponent.Name = "cmdDeleteComponent"
        Me.cmdDeleteComponent.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteComponent.TabIndex = 16
        Me.cmdDeleteComponent.Text = "Delete"
        Me.cmdDeleteComponent.UseVisualStyleBackColor = True
        '
        'gpxAdd
        '
        Me.gpxAdd.Controls.Add(Me.Label15)
        Me.gpxAdd.Controls.Add(Me.txtUnitCost)
        Me.gpxAdd.Controls.Add(Me.Label14)
        Me.gpxAdd.Controls.Add(Me.txtComponentQuantity)
        Me.gpxAdd.Controls.Add(Me.Label13)
        Me.gpxAdd.Controls.Add(Me.cboComponentDescription)
        Me.gpxAdd.Controls.Add(Me.cboComponentPart)
        Me.gpxAdd.Controls.Add(Me.Label7)
        Me.gpxAdd.Controls.Add(Me.cmdAddComponent)
        Me.gpxAdd.Location = New System.Drawing.Point(29, 422)
        Me.gpxAdd.Name = "gpxAdd"
        Me.gpxAdd.Size = New System.Drawing.Size(300, 204)
        Me.gpxAdd.TabIndex = 7
        Me.gpxAdd.TabStop = False
        Me.gpxAdd.Text = "Add Component"
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(19, 155)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(188, 41)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Components will be added to this build only, not the assembly. That must be done " & _
            "in Item Maintenance."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitCost.Location = New System.Drawing.Point(131, 127)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(153, 20)
        Me.txtUnitCost.TabIndex = 11
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(18, 127)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 20)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Unit Cost"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComponentQuantity
        '
        Me.txtComponentQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComponentQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComponentQuantity.Location = New System.Drawing.Point(131, 95)
        Me.txtComponentQuantity.Name = "txtComponentQuantity"
        Me.txtComponentQuantity.Size = New System.Drawing.Size(153, 20)
        Me.txtComponentQuantity.TabIndex = 10
        Me.txtComponentQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 95)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 20)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Quantity"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboComponentDescription
        '
        Me.cboComponentDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboComponentDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboComponentDescription.DataSource = Me.ItemListBindingSource
        Me.cboComponentDescription.DisplayMember = "ShortDescription"
        Me.cboComponentDescription.FormattingEnabled = True
        Me.cboComponentDescription.Location = New System.Drawing.Point(19, 62)
        Me.cboComponentDescription.Name = "cboComponentDescription"
        Me.cboComponentDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboComponentDescription.TabIndex = 9
        '
        'cboComponentPart
        '
        Me.cboComponentPart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboComponentPart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboComponentPart.DataSource = Me.ItemListBindingSource
        Me.cboComponentPart.DisplayMember = "ItemID"
        Me.cboComponentPart.FormattingEnabled = True
        Me.cboComponentPart.Location = New System.Drawing.Point(86, 29)
        Me.cboComponentPart.Name = "cboComponentPart"
        Me.cboComponentPart.Size = New System.Drawing.Size(198, 21)
        Me.cboComponentPart.TabIndex = 8
        Me.cboComponentPart.ValueMember = "ItemClassID"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(18, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Part #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddComponent
        '
        Me.cmdAddComponent.Location = New System.Drawing.Point(213, 160)
        Me.cmdAddComponent.Name = "cmdAddComponent"
        Me.cmdAddComponent.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddComponent.TabIndex = 12
        Me.cmdAddComponent.Text = "Add"
        Me.cmdAddComponent.UseVisualStyleBackColor = True
        '
        'dgvAssemblyLineTable
        '
        Me.dgvAssemblyLineTable.AllowUserToAddRows = False
        Me.dgvAssemblyLineTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAssemblyLineTable.AutoGenerateColumns = False
        Me.dgvAssemblyLineTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAssemblyLineTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAssemblyLineTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssemblyLineTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumberColumn, Me.ComponentPartNumberColumn, Me.ComponentPartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.ExtendedCostColumn, Me.LineCommentColumn, Me.DivisionIDColumn, Me.QOHColumn})
        Me.dgvAssemblyLineTable.DataSource = Me.AssemblyLineTableBindingSource
        Me.dgvAssemblyLineTable.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvAssemblyLineTable.Location = New System.Drawing.Point(3, 0)
        Me.dgvAssemblyLineTable.Name = "dgvAssemblyLineTable"
        Me.dgvAssemblyLineTable.Size = New System.Drawing.Size(773, 544)
        Me.dgvAssemblyLineTable.TabIndex = 27
        '
        'AssemblyPartNumberColumn
        '
        Me.AssemblyPartNumberColumn.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.HeaderText = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.Name = "AssemblyPartNumberColumn"
        Me.AssemblyPartNumberColumn.Visible = False
        '
        'ComponentPartNumberColumn
        '
        Me.ComponentPartNumberColumn.DataPropertyName = "ComponentPartNumber"
        Me.ComponentPartNumberColumn.HeaderText = "Part #"
        Me.ComponentPartNumberColumn.Name = "ComponentPartNumberColumn"
        Me.ComponentPartNumberColumn.Width = 150
        '
        'ComponentPartDescriptionColumn
        '
        Me.ComponentPartDescriptionColumn.DataPropertyName = "ComponentPartDescription"
        Me.ComponentPartDescriptionColumn.HeaderText = "Description"
        Me.ComponentPartDescriptionColumn.Name = "ComponentPartDescriptionColumn"
        Me.ComponentPartDescriptionColumn.Width = 150
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 80
        '
        'QOHColumn
        '
        Me.QOHColumn.HeaderText = "QOH"
        Me.QOHColumn.Name = "QOHColumn"
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle3.Format = "N5"
        DataGridViewCellStyle3.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 80
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.ExtendedCostColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ExtendedCostColumn.HeaderText = "Extended Cost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        Me.ExtendedCostColumn.Width = 80
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'AssemblyLineTableTableAdapter
        '
        Me.AssemblyLineTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'gpxBuildGroupBox
        '
        Me.gpxBuildGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxBuildGroupBox.Controls.Add(Me.Label3)
        Me.gpxBuildGroupBox.Controls.Add(Me.Label12)
        Me.gpxBuildGroupBox.Controls.Add(Me.cmdReverse)
        Me.gpxBuildGroupBox.Controls.Add(Me.cmdBuildAssembly)
        Me.gpxBuildGroupBox.Location = New System.Drawing.Point(802, 604)
        Me.gpxBuildGroupBox.Name = "gpxBuildGroupBox"
        Me.gpxBuildGroupBox.Size = New System.Drawing.Size(328, 159)
        Me.gpxBuildGroupBox.TabIndex = 21
        Me.gpxBuildGroupBox.TabStop = False
        Me.gpxBuildGroupBox.Text = "Build / Reverse Assemblies"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(15, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(217, 53)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "This process will add an Assembly Part to inventory and remove the components fro" & _
            "m inventory."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(15, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(217, 53)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "This process will un-assemble an Assembly Part and put the components back into i" & _
            "nventory."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdReverse
        '
        Me.cmdReverse.Location = New System.Drawing.Point(238, 96)
        Me.cmdReverse.Name = "cmdReverse"
        Me.cmdReverse.Size = New System.Drawing.Size(71, 40)
        Me.cmdReverse.TabIndex = 23
        Me.cmdReverse.Text = "Un-Build"
        Me.cmdReverse.UseVisualStyleBackColor = True
        '
        'cmdBuildAssembly
        '
        Me.cmdBuildAssembly.Location = New System.Drawing.Point(238, 38)
        Me.cmdBuildAssembly.Name = "cmdBuildAssembly"
        Me.cmdBuildAssembly.Size = New System.Drawing.Size(71, 40)
        Me.cmdBuildAssembly.TabIndex = 22
        Me.cmdBuildAssembly.Text = "Build"
        Me.cmdBuildAssembly.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(802, 769)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 24
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(980, 769)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 25
        Me.cmdPrint.Text = "Print BOM"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1057, 769)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 26
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpBuildDate)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtBuildComment)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtBuildQuantity)
        Me.GroupBox1.Location = New System.Drawing.Point(352, 604)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 205)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Build Assemblies"
        '
        'dtpBuildDate
        '
        Me.dtpBuildDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBuildDate.Location = New System.Drawing.Point(163, 19)
        Me.dtpBuildDate.Name = "dtpBuildDate"
        Me.dtpBuildDate.Size = New System.Drawing.Size(158, 20)
        Me.dtpBuildDate.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(19, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 20)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Comment"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBuildComment
        '
        Me.txtBuildComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuildComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuildComment.Location = New System.Drawing.Point(22, 116)
        Me.txtBuildComment.MaxLength = 500
        Me.txtBuildComment.Multiline = True
        Me.txtBuildComment.Name = "txtBuildComment"
        Me.txtBuildComment.Size = New System.Drawing.Size(299, 77)
        Me.txtBuildComment.TabIndex = 20
        Me.txtBuildComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(19, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 20)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Build Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Build Quantity"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBuildQuantity
        '
        Me.txtBuildQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuildQuantity.Location = New System.Drawing.Point(163, 61)
        Me.txtBuildQuantity.Name = "txtBuildQuantity"
        Me.txtBuildQuantity.Size = New System.Drawing.Size(158, 20)
        Me.txtBuildQuantity.TabIndex = 19
        '
        'AssemblySerialLogBindingSource
        '
        Me.AssemblySerialLogBindingSource.DataMember = "AssemblySerialLog"
        Me.AssemblySerialLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'AssemblySerialLogTableAdapter
        '
        Me.AssemblySerialLogTableAdapter.ClearBeforeFill = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(19, 494)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(459, 40)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Select Serial Numbers in datagrid. Number must match the build quantity."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearTab
        '
        Me.cmdClearTab.Enabled = False
        Me.cmdClearTab.Location = New System.Drawing.Point(591, 494)
        Me.cmdClearTab.Name = "cmdClearTab"
        Me.cmdClearTab.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearTab.TabIndex = 41
        Me.cmdClearTab.TabStop = False
        Me.cmdClearTab.Text = "Clear"
        Me.cmdClearTab.UseVisualStyleBackColor = True
        '
        'cmdContinue
        '
        Me.cmdContinue.Enabled = False
        Me.cmdContinue.Location = New System.Drawing.Point(514, 494)
        Me.cmdContinue.Name = "cmdContinue"
        Me.cmdContinue.Size = New System.Drawing.Size(71, 40)
        Me.cmdContinue.TabIndex = 40
        Me.cmdContinue.TabStop = False
        Me.cmdContinue.Text = "Continue"
        Me.cmdContinue.UseVisualStyleBackColor = True
        '
        'dgvTempSerialLog
        '
        Me.dgvTempSerialLog.AllowUserToAddRows = False
        Me.dgvTempSerialLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTempSerialLog.AutoGenerateColumns = False
        Me.dgvTempSerialLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTempSerialLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTempSerialLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTempSerialLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTempSerialLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SerialNumberColumn, Me.StatusColumn, Me.TotalCostColumn, Me.BuildDateColumn, Me.TransactionNumberColumn, Me.CustomerIDColumn, Me.AssemblyPartNumberColumn2, Me.DataGridViewTextBoxColumn2, Me.CommentColumn, Me.SelectColumn})
        Me.dgvTempSerialLog.DataSource = Me.AssemblySerialLogBindingSource
        Me.dgvTempSerialLog.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvTempSerialLog.Location = New System.Drawing.Point(17, 29)
        Me.dgvTempSerialLog.Name = "dgvTempSerialLog"
        Me.dgvTempSerialLog.Size = New System.Drawing.Size(745, 447)
        Me.dgvTempSerialLog.TabIndex = 39
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Serial Number"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        Me.SerialNumberColumn.ReadOnly = True
        Me.SerialNumberColumn.Width = 320
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        Me.StatusColumn.Width = 180
        '
        'TotalCostColumn
        '
        Me.TotalCostColumn.DataPropertyName = "TotalCost"
        Me.TotalCostColumn.HeaderText = "TotalCost"
        Me.TotalCostColumn.Name = "TotalCostColumn"
        Me.TotalCostColumn.Visible = False
        '
        'BuildDateColumn
        '
        Me.BuildDateColumn.DataPropertyName = "BuildDate"
        Me.BuildDateColumn.HeaderText = "BuildDate"
        Me.BuildDateColumn.Name = "BuildDateColumn"
        Me.BuildDateColumn.Visible = False
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "TransactionNumber"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.Visible = False
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "CustomerID"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.Visible = False
        '
        'AssemblyPartNumberColumn2
        '
        Me.AssemblyPartNumberColumn2.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn2.HeaderText = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn2.Name = "AssemblyPartNumberColumn2"
        Me.AssemblyPartNumberColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DivisionID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "DivisionID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.Visible = False
        Me.CommentColumn.Width = 150
        '
        'SelectColumn
        '
        Me.SelectColumn.FalseValue = "UNSELECTED"
        Me.SelectColumn.HeaderText = "Select?"
        Me.SelectColumn.Name = "SelectColumn"
        Me.SelectColumn.TrueValue = "SELECTED"
        '
        'pnlSerialLog
        '
        Me.pnlSerialLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSerialLog.Controls.Add(Me.Label9)
        Me.pnlSerialLog.Controls.Add(Me.cmdRemoveSerialNumbers)
        Me.pnlSerialLog.Controls.Add(Me.cmdClearTab)
        Me.pnlSerialLog.Controls.Add(Me.cmdContinue)
        Me.pnlSerialLog.Controls.Add(Me.dgvTempSerialLog)
        Me.pnlSerialLog.Location = New System.Drawing.Point(349, 41)
        Me.pnlSerialLog.Name = "pnlSerialLog"
        Me.pnlSerialLog.Size = New System.Drawing.Size(779, 547)
        Me.pnlSerialLog.TabIndex = 45
        '
        'cmdRemoveSerialNumbers
        '
        Me.cmdRemoveSerialNumbers.Enabled = False
        Me.cmdRemoveSerialNumbers.Location = New System.Drawing.Point(514, 494)
        Me.cmdRemoveSerialNumbers.Name = "cmdRemoveSerialNumbers"
        Me.cmdRemoveSerialNumbers.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoveSerialNumbers.TabIndex = 45
        Me.cmdRemoveSerialNumbers.TabStop = False
        Me.cmdRemoveSerialNumbers.Text = "Remove"
        Me.cmdRemoveSerialNumbers.UseVisualStyleBackColor = True
        Me.cmdRemoveSerialNumbers.Visible = False
        '
        'pnlAssemblyLines
        '
        Me.pnlAssemblyLines.Controls.Add(Me.dgvAssemblyLineTable)
        Me.pnlAssemblyLines.Location = New System.Drawing.Point(349, 41)
        Me.pnlAssemblyLines.Name = "pnlAssemblyLines"
        Me.pnlAssemblyLines.Size = New System.Drawing.Size(779, 547)
        Me.pnlAssemblyLines.TabIndex = 46
        '
        'AssemblyBuildSerialized
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.pnlSerialLog)
        Me.Controls.Add(Me.pnlAssemblyLines)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxBuildGroupBox)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.gpxDelete)
        Me.Controls.Add(Me.gpxAdd)
        Me.Controls.Add(Me.gpxItemInformation)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "AssemblyBuildSerialized"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Maintain / Build Serialized Assemblies"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxItemInformation.ResumeLayout(False)
        Me.gpxItemInformation.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxDelete.ResumeLayout(False)
        CType(Me.AssemblyLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxAdd.ResumeLayout(False)
        Me.gpxAdd.PerformLayout()
        CType(Me.dgvAssemblyLineTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxBuildGroupBox.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AssemblySerialLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTempSerialLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSerialLog.ResumeLayout(False)
        Me.pnlAssemblyLines.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxItemInformation As System.Windows.Forms.GroupBox
    Friend WithEvents cboAssemblyPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents txtAssemblyDescription As System.Windows.Forms.TextBox
    Friend WithEvents cboAssemblyPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblItemNumber As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents gpxDelete As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDeletePartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDeletePartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteComponent As System.Windows.Forms.Button
    Friend WithEvents gpxAdd As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtComponentQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboComponentDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboComponentPart As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdAddComponent As System.Windows.Forms.Button
    Friend WithEvents dgvAssemblyLineTable As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents AssemblyLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblyLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyLineTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents gpxBuildGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdReverse As System.Windows.Forms.Button
    Friend WithEvents cmdBuildAssembly As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBuildQuantity As System.Windows.Forms.TextBox
    Friend WithEvents AssemblySerialLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblySerialLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialLogTableAdapter
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBuildComment As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdClearTab As System.Windows.Forms.Button
    Friend WithEvents cmdContinue As System.Windows.Forms.Button
    Friend WithEvents dgvTempSerialLog As System.Windows.Forms.DataGridView
    Friend WithEvents pnlSerialLog As System.Windows.Forms.Panel
    Friend WithEvents pnlAssemblyLines As System.Windows.Forms.Panel
    Friend WithEvents cmdRemoveSerialNumbers As System.Windows.Forms.Button
    Friend WithEvents dtpBuildDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssemblyPartNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AssemblyPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QOHColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtAssemblyCost As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PrintBOMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtQOH As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
