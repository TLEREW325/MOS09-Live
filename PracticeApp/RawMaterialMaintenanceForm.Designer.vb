<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RawMaterialMaintenanceForm
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
        Dim lblSearchCarbon As System.Windows.Forms.Label
        Dim lblSearchSteelSize As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim lblSearchRMID As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxSearchRMData = New System.Windows.Forms.GroupBox
        Me.cboSearchRMID = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboSearchSteelSize = New System.Windows.Forms.ComboBox
        Me.cboSearchCarbon = New System.Windows.Forms.ComboBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.cmdClearSearch = New System.Windows.Forms.Button
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintSteelListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxEnterNewRawMaterial = New System.Windows.Forms.GroupBox
        Me.cboSteelClass = New System.Windows.Forms.ComboBox
        Me.txtRMID = New System.Windows.Forms.TextBox
        Me.txtCarbon = New System.Windows.Forms.TextBox
        Me.txtSteelSize = New System.Windows.Forms.TextBox
        Me.dtpCreationDate = New System.Windows.Forms.DateTimePicker
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.cmdEnter = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.grpDeleteSteel = New System.Windows.Forms.GroupBox
        Me.cmdReOpen = New System.Windows.Forms.Button
        Me.txtRMIDFromDatagrid = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdDeactivateSteel = New System.Windows.Forms.Button
        Me.dgvRawMaterials = New System.Windows.Forms.DataGridView
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelClassColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.CreationDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BeginningBalanceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        lblSearchCarbon = New System.Windows.Forms.Label
        lblSearchSteelSize = New System.Windows.Forms.Label
        Label13 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label10 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        lblSearchRMID = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Me.gpxSearchRMData.SuspendLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.gpxEnterNewRawMaterial.SuspendLayout()
        Me.grpDeleteSteel.SuspendLayout()
        CType(Me.dgvRawMaterials, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSearchCarbon
        '
        lblSearchCarbon.Location = New System.Drawing.Point(13, 60)
        lblSearchCarbon.Name = "lblSearchCarbon"
        lblSearchCarbon.Size = New System.Drawing.Size(120, 17)
        lblSearchCarbon.TabIndex = 71
        lblSearchCarbon.Text = "Carbon"
        lblSearchCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSearchSteelSize
        '
        lblSearchSteelSize.Location = New System.Drawing.Point(13, 91)
        lblSearchSteelSize.Name = "lblSearchSteelSize"
        lblSearchSteelSize.Size = New System.Drawing.Size(120, 17)
        lblSearchSteelSize.TabIndex = 75
        lblSearchSteelSize.Text = "Steel Size"
        lblSearchSteelSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Label13.Location = New System.Drawing.Point(13, 144)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(57, 20)
        Label13.TabIndex = 72
        Label13.Text = "Size"
        Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Label3.Location = New System.Drawing.Point(13, 181)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(116, 17)
        Label3.TabIndex = 68
        Label3.Text = "Description"
        Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Label4.Location = New System.Drawing.Point(13, 106)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(57, 20)
        Label4.TabIndex = 67
        Label4.Text = "Carbon"
        Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Label10.Location = New System.Drawing.Point(13, 68)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(57, 20)
        Label10.TabIndex = 74
        Label10.Text = "RMID"
        Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Label7.Location = New System.Drawing.Point(13, 30)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(116, 20)
        Label7.TabIndex = 85
        Label7.Text = "Creation Date"
        Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSearchRMID
        '
        lblSearchRMID.Location = New System.Drawing.Point(13, 29)
        lblSearchRMID.Name = "lblSearchRMID"
        lblSearchRMID.Size = New System.Drawing.Size(120, 17)
        lblSearchRMID.TabIndex = 78
        lblSearchRMID.Text = "RMID"
        lblSearchRMID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Label1.Location = New System.Drawing.Point(13, 318)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(116, 20)
        Label1.TabIndex = 92
        Label1.Text = "Steel Class"
        Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Label5.Location = New System.Drawing.Point(13, 109)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(46, 20)
        Label5.TabIndex = 78
        Label5.Text = "RMID"
        Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 22
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxSearchRMData
        '
        Me.gpxSearchRMData.Controls.Add(Me.cboSearchRMID)
        Me.gpxSearchRMData.Controls.Add(lblSearchRMID)
        Me.gpxSearchRMData.Controls.Add(Me.cboSearchSteelSize)
        Me.gpxSearchRMData.Controls.Add(Me.cboSearchCarbon)
        Me.gpxSearchRMData.Controls.Add(Me.cmdSearch)
        Me.gpxSearchRMData.Controls.Add(Me.cmdClearSearch)
        Me.gpxSearchRMData.Controls.Add(lblSearchSteelSize)
        Me.gpxSearchRMData.Controls.Add(lblSearchCarbon)
        Me.gpxSearchRMData.Location = New System.Drawing.Point(29, 41)
        Me.gpxSearchRMData.Name = "gpxSearchRMData"
        Me.gpxSearchRMData.Size = New System.Drawing.Size(300, 168)
        Me.gpxSearchRMData.TabIndex = 0
        Me.gpxSearchRMData.TabStop = False
        Me.gpxSearchRMData.Text = "Search Raw Materials"
        '
        'cboSearchRMID
        '
        Me.cboSearchRMID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSearchRMID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSearchRMID.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSearchRMID.DisplayMember = "RMID"
        Me.cboSearchRMID.FormattingEnabled = True
        Me.cboSearchRMID.Location = New System.Drawing.Point(76, 29)
        Me.cboSearchRMID.Name = "cboSearchRMID"
        Me.cboSearchRMID.Size = New System.Drawing.Size(211, 21)
        Me.cboSearchRMID.TabIndex = 1
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
        'cboSearchSteelSize
        '
        Me.cboSearchSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSearchSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSearchSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSearchSteelSize.DisplayMember = "SteelSize"
        Me.cboSearchSteelSize.FormattingEnabled = True
        Me.cboSearchSteelSize.Location = New System.Drawing.Point(76, 87)
        Me.cboSearchSteelSize.Name = "cboSearchSteelSize"
        Me.cboSearchSteelSize.Size = New System.Drawing.Size(211, 21)
        Me.cboSearchSteelSize.TabIndex = 3
        '
        'cboSearchCarbon
        '
        Me.cboSearchCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSearchCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSearchCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSearchCarbon.DisplayMember = "Carbon"
        Me.cboSearchCarbon.FormattingEnabled = True
        Me.cboSearchCarbon.Location = New System.Drawing.Point(76, 58)
        Me.cboSearchCarbon.Name = "cboSearchCarbon"
        Me.cboSearchCarbon.Size = New System.Drawing.Size(211, 21)
        Me.cboSearchCarbon.TabIndex = 2
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(139, 125)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(71, 30)
        Me.cmdSearch.TabIndex = 4
        Me.cmdSearch.Text = "View"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cmdClearSearch
        '
        Me.cmdClearSearch.Location = New System.Drawing.Point(216, 125)
        Me.cmdClearSearch.Name = "cmdClearSearch"
        Me.cmdClearSearch.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearSearch.TabIndex = 5
        Me.cmdClearSearch.Text = "Clear"
        Me.cmdClearSearch.UseVisualStyleBackColor = True
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip2.TabIndex = 72
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearDataToolStripMenuItem
        '
        Me.ClearDataToolStripMenuItem.Name = "ClearDataToolStripMenuItem"
        Me.ClearDataToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ClearDataToolStripMenuItem.Text = "Clear Data"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintSteelListToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintSteelListToolStripMenuItem
        '
        Me.PrintSteelListToolStripMenuItem.Name = "PrintSteelListToolStripMenuItem"
        Me.PrintSteelListToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.PrintSteelListToolStripMenuItem.Text = "Print Steel List"
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
        'gpxEnterNewRawMaterial
        '
        Me.gpxEnterNewRawMaterial.Controls.Add(Me.cboSteelClass)
        Me.gpxEnterNewRawMaterial.Controls.Add(Me.txtRMID)
        Me.gpxEnterNewRawMaterial.Controls.Add(Me.txtCarbon)
        Me.gpxEnterNewRawMaterial.Controls.Add(Me.txtSteelSize)
        Me.gpxEnterNewRawMaterial.Controls.Add(Me.dtpCreationDate)
        Me.gpxEnterNewRawMaterial.Controls.Add(Label7)
        Me.gpxEnterNewRawMaterial.Controls.Add(Me.txtDescription)
        Me.gpxEnterNewRawMaterial.Controls.Add(Me.cmdEnter)
        Me.gpxEnterNewRawMaterial.Controls.Add(Me.cmdClear)
        Me.gpxEnterNewRawMaterial.Controls.Add(Label10)
        Me.gpxEnterNewRawMaterial.Controls.Add(Label13)
        Me.gpxEnterNewRawMaterial.Controls.Add(Label3)
        Me.gpxEnterNewRawMaterial.Controls.Add(Label4)
        Me.gpxEnterNewRawMaterial.Controls.Add(Label1)
        Me.gpxEnterNewRawMaterial.Enabled = False
        Me.gpxEnterNewRawMaterial.Location = New System.Drawing.Point(29, 215)
        Me.gpxEnterNewRawMaterial.Name = "gpxEnterNewRawMaterial"
        Me.gpxEnterNewRawMaterial.Size = New System.Drawing.Size(300, 398)
        Me.gpxEnterNewRawMaterial.TabIndex = 6
        Me.gpxEnterNewRawMaterial.TabStop = False
        Me.gpxEnterNewRawMaterial.Text = "Create New Raw Material Item"
        '
        'cboSteelClass
        '
        Me.cboSteelClass.FormattingEnabled = True
        Me.cboSteelClass.Items.AddRange(New Object() {"TWD STEEL(INVENTORY)", "TWE STEEL (ACCESSORIES)", "TOOL STEEL", "ALUMINUM BALL", "OTHER"})
        Me.cboSteelClass.Location = New System.Drawing.Point(104, 317)
        Me.cboSteelClass.Name = "cboSteelClass"
        Me.cboSteelClass.Size = New System.Drawing.Size(183, 21)
        Me.cboSteelClass.TabIndex = 12
        '
        'txtRMID
        '
        Me.txtRMID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRMID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRMID.Location = New System.Drawing.Point(65, 68)
        Me.txtRMID.Name = "txtRMID"
        Me.txtRMID.ReadOnly = True
        Me.txtRMID.Size = New System.Drawing.Size(222, 20)
        Me.txtRMID.TabIndex = 8
        Me.txtRMID.TabStop = False
        '
        'txtCarbon
        '
        Me.txtCarbon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarbon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCarbon.Location = New System.Drawing.Point(65, 106)
        Me.txtCarbon.MaxLength = 14
        Me.txtCarbon.Name = "txtCarbon"
        Me.txtCarbon.Size = New System.Drawing.Size(222, 20)
        Me.txtCarbon.TabIndex = 9
        '
        'txtSteelSize
        '
        Me.txtSteelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelSize.Location = New System.Drawing.Point(65, 144)
        Me.txtSteelSize.MaxLength = 14
        Me.txtSteelSize.Name = "txtSteelSize"
        Me.txtSteelSize.Size = New System.Drawing.Size(222, 20)
        Me.txtSteelSize.TabIndex = 10
        '
        'dtpCreationDate
        '
        Me.dtpCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCreationDate.Location = New System.Drawing.Point(104, 30)
        Me.dtpCreationDate.Name = "dtpCreationDate"
        Me.dtpCreationDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpCreationDate.TabIndex = 7
        Me.dtpCreationDate.TabStop = False
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Location = New System.Drawing.Point(16, 201)
        Me.txtDescription.MaxLength = 100
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(271, 99)
        Me.txtDescription.TabIndex = 11
        Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdEnter
        '
        Me.cmdEnter.Location = New System.Drawing.Point(139, 355)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnter.TabIndex = 13
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(216, 355)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 21
        Me.cmdPrint.Text = "Print List"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(905, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 20
        Me.cmdClearAll.Text = "Clear Form"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(216, 152)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 30)
        Me.cmdDelete.TabIndex = 18
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'grpDeleteSteel
        '
        Me.grpDeleteSteel.Controls.Add(Me.cmdReOpen)
        Me.grpDeleteSteel.Controls.Add(Label5)
        Me.grpDeleteSteel.Controls.Add(Me.txtRMIDFromDatagrid)
        Me.grpDeleteSteel.Controls.Add(Me.Label2)
        Me.grpDeleteSteel.Controls.Add(Me.cmdDeactivateSteel)
        Me.grpDeleteSteel.Controls.Add(Me.cmdDelete)
        Me.grpDeleteSteel.Enabled = False
        Me.grpDeleteSteel.Location = New System.Drawing.Point(29, 619)
        Me.grpDeleteSteel.Name = "grpDeleteSteel"
        Me.grpDeleteSteel.Size = New System.Drawing.Size(300, 192)
        Me.grpDeleteSteel.TabIndex = 15
        Me.grpDeleteSteel.TabStop = False
        Me.grpDeleteSteel.Text = "CLOSE/RE-OPEN/DELETE Steel From Steel List"
        '
        'cmdReOpen
        '
        Me.cmdReOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReOpen.Location = New System.Drawing.Point(137, 152)
        Me.cmdReOpen.Name = "cmdReOpen"
        Me.cmdReOpen.Size = New System.Drawing.Size(71, 30)
        Me.cmdReOpen.TabIndex = 79
        Me.cmdReOpen.Text = "Re-Open"
        Me.cmdReOpen.UseVisualStyleBackColor = True
        '
        'txtRMIDFromDatagrid
        '
        Me.txtRMIDFromDatagrid.BackColor = System.Drawing.Color.White
        Me.txtRMIDFromDatagrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRMIDFromDatagrid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRMIDFromDatagrid.Location = New System.Drawing.Point(65, 109)
        Me.txtRMIDFromDatagrid.MaxLength = 14
        Me.txtRMIDFromDatagrid.Name = "txtRMIDFromDatagrid"
        Me.txtRMIDFromDatagrid.ReadOnly = True
        Me.txtRMIDFromDatagrid.Size = New System.Drawing.Size(222, 20)
        Me.txtRMIDFromDatagrid.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(13, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(274, 78)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Select steel in the datagrid to DELETE/DE-ACTIVATE/RE-OPEN. Steel with activity c" & _
            "annot be deleted and steel with QOH or on an open PO cannot be DE-ACTIVATED."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeactivateSteel
        '
        Me.cmdDeactivateSteel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeactivateSteel.Location = New System.Drawing.Point(58, 152)
        Me.cmdDeactivateSteel.Name = "cmdDeactivateSteel"
        Me.cmdDeactivateSteel.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeactivateSteel.TabIndex = 17
        Me.cmdDeactivateSteel.Text = "Close"
        Me.cmdDeactivateSteel.UseVisualStyleBackColor = True
        '
        'dgvRawMaterials
        '
        Me.dgvRawMaterials.AllowUserToAddRows = False
        Me.dgvRawMaterials.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvRawMaterials.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRawMaterials.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRawMaterials.AutoGenerateColumns = False
        Me.dgvRawMaterials.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRawMaterials.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvRawMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRawMaterials.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CarbonColumn, Me.SteelSizeColumn, Me.DescriptionColumn, Me.SteelClassColumn, Me.CreationDateColumn, Me.RMIDColumn, Me.SteelStatusColumn, Me.BeginningBalanceColumn, Me.DivisionIDColumn})
        Me.dgvRawMaterials.DataSource = Me.RawMaterialsTableBindingSource
        Me.dgvRawMaterials.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvRawMaterials.Location = New System.Drawing.Point(344, 46)
        Me.dgvRawMaterials.Name = "dgvRawMaterials"
        Me.dgvRawMaterials.Size = New System.Drawing.Size(786, 719)
        Me.dgvRawMaterials.TabIndex = 19
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon/Alloy"
        Me.CarbonColumn.Name = "CarbonColumn"
        Me.CarbonColumn.ReadOnly = True
        Me.CarbonColumn.Width = 120
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.ReadOnly = True
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.Width = 150
        '
        'SteelClassColumn
        '
        Me.SteelClassColumn.DataPropertyName = "SteelClass"
        Me.SteelClassColumn.HeaderText = "Steel Class"
        Me.SteelClassColumn.Items.AddRange(New Object() {"TWD STEEL(INVENTORY)", "TWE STEEL (ACCESSORIES)", "TOOL STEEL", "ALUMINUM BALL", "OTHER"})
        Me.SteelClassColumn.Name = "SteelClassColumn"
        Me.SteelClassColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SteelClassColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SteelClassColumn.Width = 150
        '
        'CreationDateColumn
        '
        Me.CreationDateColumn.DataPropertyName = "CreationDate"
        Me.CreationDateColumn.HeaderText = "Creation Date"
        Me.CreationDateColumn.Name = "CreationDateColumn"
        Me.CreationDateColumn.ReadOnly = True
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        '
        'SteelStatusColumn
        '
        Me.SteelStatusColumn.DataPropertyName = "SteelStatus"
        Me.SteelStatusColumn.HeaderText = "Status"
        Me.SteelStatusColumn.Name = "SteelStatusColumn"
        Me.SteelStatusColumn.ReadOnly = True
        '
        'BeginningBalanceColumn
        '
        Me.BeginningBalanceColumn.DataPropertyName = "BeginningBalance"
        Me.BeginningBalanceColumn.HeaderText = "BeginningBalance"
        Me.BeginningBalanceColumn.Name = "BeginningBalanceColumn"
        Me.BeginningBalanceColumn.ReadOnly = True
        Me.BeginningBalanceColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialMaintenanceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvRawMaterials)
        Me.Controls.Add(Me.grpDeleteSteel)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.gpxEnterNewRawMaterial)
        Me.Controls.Add(Me.gpxSearchRMData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Name = "RawMaterialMaintenanceForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Raw Material Maintenance"
        Me.gpxSearchRMData.ResumeLayout(False)
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.gpxEnterNewRawMaterial.ResumeLayout(False)
        Me.gpxEnterNewRawMaterial.PerformLayout()
        Me.grpDeleteSteel.ResumeLayout(False)
        Me.grpDeleteSteel.PerformLayout()
        CType(Me.dgvRawMaterials, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxSearchRMData As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxEnterNewRawMaterial As System.Windows.Forms.GroupBox
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents SizeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdClearSearch As System.Windows.Forms.Button
    Friend WithEvents dtpCreationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents txtCarbon As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelSize As System.Windows.Forms.TextBox
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboSearchSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearchCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearchRMID As System.Windows.Forms.ComboBox
    Friend WithEvents txtRMID As System.Windows.Forms.TextBox
    Friend WithEvents cboSteelClass As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents grpDeleteSteel As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDeactivateSteel As System.Windows.Forms.Button
    Friend WithEvents dgvRawMaterials As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRMIDFromDatagrid As System.Windows.Forms.TextBox
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintSteelListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelClassColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents CreationDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeginningBalanceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdReOpen As System.Windows.Forms.Button
End Class
