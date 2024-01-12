<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssemblyBuildForm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.grxItemInformation = New System.Windows.Forms.GroupBox
        Me.lblAdjusted = New System.Windows.Forms.Label
        Me.chkExchangeRate = New System.Windows.Forms.CheckBox
        Me.txtExchangeRate = New System.Windows.Forms.TextBox
        Me.txtAssemblyCost = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdViewAssemblyBOM = New System.Windows.Forms.Button
        Me.cboAssemblyPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtAssemblyDescription = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboAssemblyPartNumber = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblItemNumber = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdAddComponent = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.dgvAssemblyLines = New System.Windows.Forms.DataGridView
        Me.AssemblyPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AssemblyLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyLineTableTableAdapter
        Me.cmdBuildAssembly = New System.Windows.Forms.Button
        Me.txtBuildQuantity = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtBuildComment = New System.Windows.Forms.TextBox
        Me.dtpBuildDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdReverse = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtComponentQuantity = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboComponentDescription = New System.Windows.Forms.ComboBox
        Me.cboComponentPart = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDeletePartDescription = New System.Windows.Forms.ComboBox
        Me.cboDeletePartNumber = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdDeleteComponent = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.grxItemInformation.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAssemblyLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblyLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintBOMToolStripMenuItem, Me.ClearAllToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PrintBOMToolStripMenuItem
        '
        Me.PrintBOMToolStripMenuItem.Name = "PrintBOMToolStripMenuItem"
        Me.PrintBOMToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.PrintBOMToolStripMenuItem.Text = "Print BOM"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear All"
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
        'grxItemInformation
        '
        Me.grxItemInformation.Controls.Add(Me.lblAdjusted)
        Me.grxItemInformation.Controls.Add(Me.chkExchangeRate)
        Me.grxItemInformation.Controls.Add(Me.txtExchangeRate)
        Me.grxItemInformation.Controls.Add(Me.txtAssemblyCost)
        Me.grxItemInformation.Controls.Add(Me.Label8)
        Me.grxItemInformation.Controls.Add(Me.cmdViewAssemblyBOM)
        Me.grxItemInformation.Controls.Add(Me.cboAssemblyPartDescription)
        Me.grxItemInformation.Controls.Add(Me.txtAssemblyDescription)
        Me.grxItemInformation.Controls.Add(Me.Label11)
        Me.grxItemInformation.Controls.Add(Me.cboAssemblyPartNumber)
        Me.grxItemInformation.Controls.Add(Me.Label6)
        Me.grxItemInformation.Controls.Add(Me.lblItemNumber)
        Me.grxItemInformation.Controls.Add(Me.cboDivisionID)
        Me.grxItemInformation.Controls.Add(Me.Label4)
        Me.grxItemInformation.Location = New System.Drawing.Point(29, 41)
        Me.grxItemInformation.Name = "grxItemInformation"
        Me.grxItemInformation.Size = New System.Drawing.Size(300, 300)
        Me.grxItemInformation.TabIndex = 0
        Me.grxItemInformation.TabStop = False
        Me.grxItemInformation.Text = "Select Assembly Part Number"
        '
        'lblAdjusted
        '
        Me.lblAdjusted.ForeColor = System.Drawing.Color.Red
        Me.lblAdjusted.Location = New System.Drawing.Point(77, 229)
        Me.lblAdjusted.Name = "lblAdjusted"
        Me.lblAdjusted.Size = New System.Drawing.Size(75, 20)
        Me.lblAdjusted.TabIndex = 43
        Me.lblAdjusted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkExchangeRate
        '
        Me.chkExchangeRate.AutoSize = True
        Me.chkExchangeRate.Location = New System.Drawing.Point(22, 200)
        Me.chkExchangeRate.Name = "chkExchangeRate"
        Me.chkExchangeRate.Size = New System.Drawing.Size(136, 17)
        Me.chkExchangeRate.TabIndex = 42
        Me.chkExchangeRate.Text = "Adj. for Exchange Rate"
        Me.chkExchangeRate.UseVisualStyleBackColor = True
        '
        'txtExchangeRate
        '
        Me.txtExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExchangeRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExchangeRate.Enabled = False
        Me.txtExchangeRate.Location = New System.Drawing.Point(158, 198)
        Me.txtExchangeRate.Name = "txtExchangeRate"
        Me.txtExchangeRate.Size = New System.Drawing.Size(124, 20)
        Me.txtExchangeRate.TabIndex = 40
        Me.txtExchangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAssemblyCost
        '
        Me.txtAssemblyCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAssemblyCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAssemblyCost.Location = New System.Drawing.Point(158, 229)
        Me.txtAssemblyCost.Name = "txtAssemblyCost"
        Me.txtAssemblyCost.Size = New System.Drawing.Size(125, 20)
        Me.txtAssemblyCost.TabIndex = 38
        Me.txtAssemblyCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 20)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Total Cost"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewAssemblyBOM
        '
        Me.cmdViewAssemblyBOM.Location = New System.Drawing.Point(212, 260)
        Me.cmdViewAssemblyBOM.Name = "cmdViewAssemblyBOM"
        Me.cmdViewAssemblyBOM.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewAssemblyBOM.TabIndex = 16
        Me.cmdViewAssemblyBOM.Text = "View"
        Me.cmdViewAssemblyBOM.UseVisualStyleBackColor = True
        '
        'cboAssemblyPartDescription
        '
        Me.cboAssemblyPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssemblyPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssemblyPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboAssemblyPartDescription.DisplayMember = "ShortDescription"
        Me.cboAssemblyPartDescription.FormattingEnabled = True
        Me.cboAssemblyPartDescription.Location = New System.Drawing.Point(19, 95)
        Me.cboAssemblyPartDescription.Name = "cboAssemblyPartDescription"
        Me.cboAssemblyPartDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboAssemblyPartDescription.TabIndex = 2
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
        Me.txtAssemblyDescription.Location = New System.Drawing.Point(19, 128)
        Me.txtAssemblyDescription.Multiline = True
        Me.txtAssemblyDescription.Name = "txtAssemblyDescription"
        Me.txtAssemblyDescription.Size = New System.Drawing.Size(265, 57)
        Me.txtAssemblyDescription.TabIndex = 3
        Me.txtAssemblyDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(60, 263)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(146, 24)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "View Components in datagrid"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAssemblyPartNumber
        '
        Me.cboAssemblyPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssemblyPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssemblyPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboAssemblyPartNumber.DisplayMember = "ItemID"
        Me.cboAssemblyPartNumber.FormattingEnabled = True
        Me.cboAssemblyPartNumber.Location = New System.Drawing.Point(86, 62)
        Me.cboAssemblyPartNumber.Name = "cboAssemblyPartNumber"
        Me.cboAssemblyPartNumber.Size = New System.Drawing.Size(198, 21)
        Me.cboAssemblyPartNumber.TabIndex = 1
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
        Me.lblItemNumber.Location = New System.Drawing.Point(16, 62)
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
        Me.cboDivisionID.TabIndex = 0
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(980, 773)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 20
        Me.cmdPrint.Text = "Print BOM"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1057, 773)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 21
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdAddComponent
        '
        Me.cmdAddComponent.Location = New System.Drawing.Point(212, 139)
        Me.cmdAddComponent.Name = "cmdAddComponent"
        Me.cmdAddComponent.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddComponent.TabIndex = 9
        Me.cmdAddComponent.Text = "Add"
        Me.cmdAddComponent.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'dgvAssemblyLines
        '
        Me.dgvAssemblyLines.AllowUserToAddRows = False
        Me.dgvAssemblyLines.AllowUserToDeleteRows = False
        Me.dgvAssemblyLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAssemblyLines.AutoGenerateColumns = False
        Me.dgvAssemblyLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAssemblyLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAssemblyLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssemblyLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumberColumn, Me.ComponentPartNumberColumn, Me.ComponentPartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.ExtendedCostColumn, Me.LineCommentColumn, Me.DivisionIDColumn})
        Me.dgvAssemblyLines.DataSource = Me.AssemblyLineTableBindingSource
        Me.dgvAssemblyLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvAssemblyLines.Location = New System.Drawing.Point(348, 41)
        Me.dgvAssemblyLines.Name = "dgvAssemblyLines"
        Me.dgvAssemblyLines.Size = New System.Drawing.Size(782, 507)
        Me.dgvAssemblyLines.TabIndex = 22
        Me.dgvAssemblyLines.TabStop = False
        '
        'AssemblyPartNumberColumn
        '
        Me.AssemblyPartNumberColumn.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.HeaderText = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn.Name = "AssemblyPartNumberColumn"
        Me.AssemblyPartNumberColumn.ReadOnly = True
        Me.AssemblyPartNumberColumn.Visible = False
        '
        'ComponentPartNumberColumn
        '
        Me.ComponentPartNumberColumn.DataPropertyName = "ComponentPartNumber"
        Me.ComponentPartNumberColumn.HeaderText = "Part #"
        Me.ComponentPartNumberColumn.Name = "ComponentPartNumberColumn"
        Me.ComponentPartNumberColumn.ReadOnly = True
        Me.ComponentPartNumberColumn.Width = 150
        '
        'ComponentPartDescriptionColumn
        '
        Me.ComponentPartDescriptionColumn.DataPropertyName = "ComponentPartDescription"
        Me.ComponentPartDescriptionColumn.HeaderText = "Description"
        Me.ComponentPartDescriptionColumn.Name = "ComponentPartDescriptionColumn"
        Me.ComponentPartDescriptionColumn.ReadOnly = True
        Me.ComponentPartDescriptionColumn.Width = 180
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle4.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 90
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.ExtendedCostColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.ExtendedCostColumn.HeaderText = "Extended Cost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        Me.ExtendedCostColumn.ReadOnly = True
        Me.ExtendedCostColumn.Width = 90
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.Width = 120
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'AssemblyLineTableBindingSource
        '
        Me.AssemblyLineTableBindingSource.DataMember = "AssemblyLineTable"
        Me.AssemblyLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'AssemblyLineTableTableAdapter
        '
        Me.AssemblyLineTableTableAdapter.ClearBeforeFill = True
        '
        'cmdBuildAssembly
        '
        Me.cmdBuildAssembly.Location = New System.Drawing.Point(246, 47)
        Me.cmdBuildAssembly.Name = "cmdBuildAssembly"
        Me.cmdBuildAssembly.Size = New System.Drawing.Size(71, 40)
        Me.cmdBuildAssembly.TabIndex = 17
        Me.cmdBuildAssembly.Text = "Build"
        Me.cmdBuildAssembly.UseVisualStyleBackColor = True
        '
        'txtBuildQuantity
        '
        Me.txtBuildQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuildQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuildQuantity.Location = New System.Drawing.Point(157, 209)
        Me.txtBuildQuantity.Name = "txtBuildQuantity"
        Me.txtBuildQuantity.Size = New System.Drawing.Size(162, 20)
        Me.txtBuildQuantity.TabIndex = 15
        Me.txtBuildQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 207)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Build Quantity"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(802, 773)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 19
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtBuildComment)
        Me.GroupBox1.Controls.Add(Me.dtpBuildDate)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtBuildQuantity)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(348, 563)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 250)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Build Data"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 20)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Build Comment"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBuildComment
        '
        Me.txtBuildComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuildComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuildComment.Location = New System.Drawing.Point(16, 80)
        Me.txtBuildComment.Multiline = True
        Me.txtBuildComment.Name = "txtBuildComment"
        Me.txtBuildComment.Size = New System.Drawing.Size(303, 105)
        Me.txtBuildComment.TabIndex = 14
        Me.txtBuildComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpBuildDate
        '
        Me.dtpBuildDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBuildDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBuildDate.Location = New System.Drawing.Point(146, 25)
        Me.dtpBuildDate.Name = "dtpBuildDate"
        Me.dtpBuildDate.Size = New System.Drawing.Size(173, 20)
        Me.dtpBuildDate.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 20)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Build Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cmdReverse)
        Me.GroupBox2.Controls.Add(Me.cmdBuildAssembly)
        Me.GroupBox2.Location = New System.Drawing.Point(802, 563)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(328, 196)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Build / Reverse Assemblies"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(23, 41)
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
        Me.Label12.Location = New System.Drawing.Point(23, 132)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(217, 53)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "This process will un-assemble an Assembly Part and put the components back into i" & _
            "nventory."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdReverse
        '
        Me.cmdReverse.Location = New System.Drawing.Point(246, 132)
        Me.cmdReverse.Name = "cmdReverse"
        Me.cmdReverse.Size = New System.Drawing.Size(71, 40)
        Me.cmdReverse.TabIndex = 18
        Me.cmdReverse.Text = "Un-Build"
        Me.cmdReverse.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.txtUnitCost)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtComponentQuantity)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.cboComponentDescription)
        Me.GroupBox3.Controls.Add(Me.cboComponentPart)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cmdAddComponent)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 432)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 185)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Add Component"
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(18, 134)
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
        Me.txtUnitCost.Location = New System.Drawing.Point(131, 110)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(153, 20)
        Me.txtUnitCost.TabIndex = 8
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(19, 110)
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
        Me.txtComponentQuantity.Location = New System.Drawing.Point(131, 81)
        Me.txtComponentQuantity.Name = "txtComponentQuantity"
        Me.txtComponentQuantity.Size = New System.Drawing.Size(153, 20)
        Me.txtComponentQuantity.TabIndex = 7
        Me.txtComponentQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(19, 81)
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
        Me.cboComponentDescription.Location = New System.Drawing.Point(19, 51)
        Me.cboComponentDescription.Name = "cboComponentDescription"
        Me.cboComponentDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboComponentDescription.TabIndex = 6
        '
        'cboComponentPart
        '
        Me.cboComponentPart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboComponentPart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboComponentPart.DataSource = Me.ItemListBindingSource
        Me.cboComponentPart.DisplayMember = "ItemID"
        Me.cboComponentPart.FormattingEnabled = True
        Me.cboComponentPart.Location = New System.Drawing.Point(86, 21)
        Me.cboComponentPart.Name = "cboComponentPart"
        Me.cboComponentPart.Size = New System.Drawing.Size(198, 21)
        Me.cboComponentPart.TabIndex = 5
        Me.cboComponentPart.ValueMember = "ItemClassID"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Part #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.cboDeletePartDescription)
        Me.GroupBox4.Controls.Add(Me.cboDeletePartNumber)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.cmdDeleteComponent)
        Me.GroupBox4.Location = New System.Drawing.Point(29, 642)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(300, 168)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Delete Component"
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
        Me.cboDeletePartDescription.Location = New System.Drawing.Point(19, 85)
        Me.cboDeletePartDescription.Name = "cboDeletePartDescription"
        Me.cboDeletePartDescription.Size = New System.Drawing.Size(265, 21)
        Me.cboDeletePartDescription.TabIndex = 11
        '
        'cboDeletePartNumber
        '
        Me.cboDeletePartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDeletePartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDeletePartNumber.DataSource = Me.AssemblyLineTableBindingSource
        Me.cboDeletePartNumber.DisplayMember = "ComponentPartNumber"
        Me.cboDeletePartNumber.FormattingEnabled = True
        Me.cboDeletePartNumber.Location = New System.Drawing.Point(63, 52)
        Me.cboDeletePartNumber.Name = "cboDeletePartNumber"
        Me.cboDeletePartNumber.Size = New System.Drawing.Size(221, 21)
        Me.cboDeletePartNumber.TabIndex = 10
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
        Me.cmdDeleteComponent.TabIndex = 12
        Me.cmdDeleteComponent.Text = "Delete"
        Me.cmdDeleteComponent.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(29, 354)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(300, 55)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "Assemblies are created and maintained in Item Maintenance. You may add or delete " & _
            "components from this build using the modules below."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AssemblyBuildForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.dgvAssemblyLines)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.grxItemInformation)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "AssemblyBuildForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Build Assembly Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grxItemInformation.ResumeLayout(False)
        Me.grxItemInformation.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAssemblyLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblyLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grxItemInformation As System.Windows.Forms.GroupBox
    Friend WithEvents cboAssemblyPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboAssemblyPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblItemNumber As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdAddComponent As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents dgvAssemblyLines As System.Windows.Forms.DataGridView
    Friend WithEvents AssemblyLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblyLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyLineTableTableAdapter
    Friend WithEvents txtBuildQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdBuildAssembly As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBuildComment As System.Windows.Forms.TextBox
    Friend WithEvents dtpBuildDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAssemblyDescription As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PrintBOMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdReverse As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtComponentQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboComponentDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboComponentPart As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDeletePartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboDeletePartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteComponent As System.Windows.Forms.Button
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdViewAssemblyBOM As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAssemblyCost As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkExchangeRate As System.Windows.Forms.CheckBox
    Friend WithEvents txtExchangeRate As System.Windows.Forms.TextBox
    Friend WithEvents lblAdjusted As System.Windows.Forms.Label
    Friend WithEvents AssemblyPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
