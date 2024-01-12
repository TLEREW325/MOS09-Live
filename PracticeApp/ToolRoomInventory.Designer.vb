<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToolRoomInventory
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvToolRoomInventory = New System.Windows.Forms.DataGridView
        Me.tabctrlSearchAdd = New System.Windows.Forms.TabControl
        Me.tabSearchRemoveTool = New System.Windows.Forms.TabPage
        Me.gpxSearch = New System.Windows.Forms.GroupBox
        Me.txtSearchInnerDiameterTolerance = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtSearchFirstInnerDiameter = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtSearchFirstLength = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtSearchSectionColumn = New System.Windows.Forms.TextBox
        Me.txtSearchSectionRow = New System.Windows.Forms.TextBox
        Me.txtSearchSection = New System.Windows.Forms.TextBox
        Me.lblSearchSectionColumn = New System.Windows.Forms.Label
        Me.lblSearchSectionRow = New System.Windows.Forms.Label
        Me.lblSearchSection = New System.Windows.Forms.Label
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.cmdClearSearch = New System.Windows.Forms.Button
        Me.cboWangType = New System.Windows.Forms.ComboBox
        Me.lblWangType = New System.Windows.Forms.Label
        Me.cboToolType = New System.Windows.Forms.ComboBox
        Me.lblToolType = New System.Windows.Forms.Label
        Me.lblBlueprintNumber = New System.Windows.Forms.Label
        Me.cboBlueprintNumber = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblRemoveMaterialType = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.lblRemoveBlueprintNumber = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblRemoveSectionColumnData = New System.Windows.Forms.Label
        Me.cmdRemoveTool = New System.Windows.Forms.Button
        Me.lblRemoveSectionRowData = New System.Windows.Forms.Label
        Me.cboRemoveToolType = New System.Windows.Forms.ComboBox
        Me.lblRemoveSectionData = New System.Windows.Forms.Label
        Me.lblDeleteToolType = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSection = New System.Windows.Forms.Label
        Me.lblSectionRow = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label5 = New System.Windows.Forms.Label
        Me.pnlAddTool = New System.Windows.Forms.Panel
        Me.cmdClearAddInventory = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkPrintLabel = New System.Windows.Forms.CheckBox
        Me.cmdAddToInventory = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAddInventorySectionColumn = New System.Windows.Forms.TextBox
        Me.txtAddInventoryDieSection = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAddInventoryRemarks = New System.Windows.Forms.TextBox
        Me.txtAddInventoryFourthID = New System.Windows.Forms.TextBox
        Me.txtAddInventoryFourthLength = New System.Windows.Forms.TextBox
        Me.txtAddInventorySectionRow = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtAddInventoryThirdID = New System.Windows.Forms.TextBox
        Me.txtAddInventorySection = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtAddInventoryThirdLength = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtAddInventorySecondID = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtAddInventorySecondLength = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtAddInventoryFirstID = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtAddInventoryFirstLength = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtAddInventoryOuterDiameter = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtAddInventoryMaterialType = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboAddInventoryWangType = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboAddInventoryToolType = New System.Windows.Forms.ComboBox
        Me.cboAddInventoryBlueprintNumber = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdPrintListing = New System.Windows.Forms.Button
        Me.cmdPrintLabel = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvToolRoomInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabctrlSearchAdd.SuspendLayout()
        Me.tabSearchRemoveTool.SuspendLayout()
        Me.gpxSearch.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.pnlAddTool.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1044, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintDataToolStripMenuItem})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PrintDataToolStripMenuItem
        '
        Me.PrintDataToolStripMenuItem.Name = "PrintDataToolStripMenuItem"
        Me.PrintDataToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.PrintDataToolStripMenuItem.Text = "Print Data"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 8.25!)
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
        Me.cmdExit.Location = New System.Drawing.Point(961, 618)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvToolRoomInventory
        '
        Me.dgvToolRoomInventory.AllowUserToAddRows = False
        Me.dgvToolRoomInventory.AllowUserToDeleteRows = False
        Me.dgvToolRoomInventory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvToolRoomInventory.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvToolRoomInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvToolRoomInventory.Location = New System.Drawing.Point(315, 27)
        Me.dgvToolRoomInventory.Name = "dgvToolRoomInventory"
        Me.dgvToolRoomInventory.Size = New System.Drawing.Size(715, 585)
        Me.dgvToolRoomInventory.TabIndex = 4
        Me.dgvToolRoomInventory.TabStop = False
        '
        'tabctrlSearchAdd
        '
        Me.tabctrlSearchAdd.Controls.Add(Me.tabSearchRemoveTool)
        Me.tabctrlSearchAdd.Controls.Add(Me.TabPage2)
        Me.tabctrlSearchAdd.Location = New System.Drawing.Point(0, 27)
        Me.tabctrlSearchAdd.Name = "tabctrlSearchAdd"
        Me.tabctrlSearchAdd.SelectedIndex = 0
        Me.tabctrlSearchAdd.Size = New System.Drawing.Size(309, 629)
        Me.tabctrlSearchAdd.TabIndex = 0
        '
        'tabSearchRemoveTool
        '
        Me.tabSearchRemoveTool.BackColor = System.Drawing.SystemColors.Control
        Me.tabSearchRemoveTool.Controls.Add(Me.gpxSearch)
        Me.tabSearchRemoveTool.Controls.Add(Me.GroupBox1)
        Me.tabSearchRemoveTool.Location = New System.Drawing.Point(4, 22)
        Me.tabSearchRemoveTool.Name = "tabSearchRemoveTool"
        Me.tabSearchRemoveTool.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSearchRemoveTool.Size = New System.Drawing.Size(301, 603)
        Me.tabSearchRemoveTool.TabIndex = 0
        Me.tabSearchRemoveTool.Text = "Search / Remove Tool"
        '
        'gpxSearch
        '
        Me.gpxSearch.Controls.Add(Me.txtSearchInnerDiameterTolerance)
        Me.gpxSearch.Controls.Add(Me.Label24)
        Me.gpxSearch.Controls.Add(Me.txtSearchFirstInnerDiameter)
        Me.gpxSearch.Controls.Add(Me.Label22)
        Me.gpxSearch.Controls.Add(Me.txtSearchFirstLength)
        Me.gpxSearch.Controls.Add(Me.Label20)
        Me.gpxSearch.Controls.Add(Me.txtSearchSectionColumn)
        Me.gpxSearch.Controls.Add(Me.txtSearchSectionRow)
        Me.gpxSearch.Controls.Add(Me.txtSearchSection)
        Me.gpxSearch.Controls.Add(Me.lblSearchSectionColumn)
        Me.gpxSearch.Controls.Add(Me.lblSearchSectionRow)
        Me.gpxSearch.Controls.Add(Me.lblSearchSection)
        Me.gpxSearch.Controls.Add(Me.cmdSearch)
        Me.gpxSearch.Controls.Add(Me.cmdClearSearch)
        Me.gpxSearch.Controls.Add(Me.cboWangType)
        Me.gpxSearch.Controls.Add(Me.lblWangType)
        Me.gpxSearch.Controls.Add(Me.cboToolType)
        Me.gpxSearch.Controls.Add(Me.lblToolType)
        Me.gpxSearch.Controls.Add(Me.lblBlueprintNumber)
        Me.gpxSearch.Controls.Add(Me.cboBlueprintNumber)
        Me.gpxSearch.Location = New System.Drawing.Point(6, 6)
        Me.gpxSearch.Name = "gpxSearch"
        Me.gpxSearch.Size = New System.Drawing.Size(286, 340)
        Me.gpxSearch.TabIndex = 0
        Me.gpxSearch.TabStop = False
        Me.gpxSearch.Text = "Search Inventory"
        '
        'txtSearchInnerDiameterTolerance
        '
        Me.txtSearchInnerDiameterTolerance.Location = New System.Drawing.Point(140, 262)
        Me.txtSearchInnerDiameterTolerance.Name = "txtSearchInnerDiameterTolerance"
        Me.txtSearchInnerDiameterTolerance.Size = New System.Drawing.Size(132, 20)
        Me.txtSearchInnerDiameterTolerance.TabIndex = 20
        Me.txtSearchInnerDiameterTolerance.Text = "0.2"
        Me.txtSearchInnerDiameterTolerance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(6, 265)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(128, 17)
        Me.Label24.TabIndex = 21
        Me.Label24.Text = "Inner Diameter Tolerance"
        '
        'txtSearchFirstInnerDiameter
        '
        Me.txtSearchFirstInnerDiameter.Location = New System.Drawing.Point(140, 236)
        Me.txtSearchFirstInnerDiameter.Name = "txtSearchFirstInnerDiameter"
        Me.txtSearchFirstInnerDiameter.Size = New System.Drawing.Size(132, 20)
        Me.txtSearchFirstInnerDiameter.TabIndex = 18
        Me.txtSearchFirstInnerDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 239)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 13)
        Me.Label22.TabIndex = 19
        Me.Label22.Text = "First Inner Diameter"
        '
        'txtSearchFirstLength
        '
        Me.txtSearchFirstLength.Location = New System.Drawing.Point(140, 210)
        Me.txtSearchFirstLength.Name = "txtSearchFirstLength"
        Me.txtSearchFirstLength.Size = New System.Drawing.Size(132, 20)
        Me.txtSearchFirstLength.TabIndex = 16
        Me.txtSearchFirstLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 213)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 13)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "First Length"
        '
        'txtSearchSectionColumn
        '
        Me.txtSearchSectionColumn.Location = New System.Drawing.Point(140, 184)
        Me.txtSearchSectionColumn.Name = "txtSearchSectionColumn"
        Me.txtSearchSectionColumn.Size = New System.Drawing.Size(132, 20)
        Me.txtSearchSectionColumn.TabIndex = 5
        Me.txtSearchSectionColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSearchSectionRow
        '
        Me.txtSearchSectionRow.Location = New System.Drawing.Point(140, 157)
        Me.txtSearchSectionRow.Name = "txtSearchSectionRow"
        Me.txtSearchSectionRow.Size = New System.Drawing.Size(132, 20)
        Me.txtSearchSectionRow.TabIndex = 4
        Me.txtSearchSectionRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSearchSection
        '
        Me.txtSearchSection.Location = New System.Drawing.Point(140, 130)
        Me.txtSearchSection.Name = "txtSearchSection"
        Me.txtSearchSection.Size = New System.Drawing.Size(132, 20)
        Me.txtSearchSection.TabIndex = 3
        Me.txtSearchSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSearchSectionColumn
        '
        Me.lblSearchSectionColumn.AutoSize = True
        Me.lblSearchSectionColumn.Location = New System.Drawing.Point(6, 187)
        Me.lblSearchSectionColumn.Name = "lblSearchSectionColumn"
        Me.lblSearchSectionColumn.Size = New System.Drawing.Size(81, 13)
        Me.lblSearchSectionColumn.TabIndex = 15
        Me.lblSearchSectionColumn.Text = "Section Column"
        '
        'lblSearchSectionRow
        '
        Me.lblSearchSectionRow.AutoSize = True
        Me.lblSearchSectionRow.Location = New System.Drawing.Point(6, 160)
        Me.lblSearchSectionRow.Name = "lblSearchSectionRow"
        Me.lblSearchSectionRow.Size = New System.Drawing.Size(68, 13)
        Me.lblSearchSectionRow.TabIndex = 13
        Me.lblSearchSectionRow.Text = "Section Row"
        '
        'lblSearchSection
        '
        Me.lblSearchSection.AutoSize = True
        Me.lblSearchSection.Location = New System.Drawing.Point(6, 133)
        Me.lblSearchSection.Name = "lblSearchSection"
        Me.lblSearchSection.Size = New System.Drawing.Size(43, 13)
        Me.lblSearchSection.TabIndex = 11
        Me.lblSearchSection.Text = "Section"
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(111, 288)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(71, 40)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cmdClearSearch
        '
        Me.cmdClearSearch.Location = New System.Drawing.Point(201, 288)
        Me.cmdClearSearch.Name = "cmdClearSearch"
        Me.cmdClearSearch.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearSearch.TabIndex = 7
        Me.cmdClearSearch.Text = "Clear Search"
        Me.cmdClearSearch.UseVisualStyleBackColor = True
        '
        'cboWangType
        '
        Me.cboWangType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboWangType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboWangType.FormattingEnabled = True
        Me.cboWangType.Location = New System.Drawing.Point(140, 103)
        Me.cboWangType.Name = "cboWangType"
        Me.cboWangType.Size = New System.Drawing.Size(132, 21)
        Me.cboWangType.TabIndex = 2
        '
        'lblWangType
        '
        Me.lblWangType.AutoSize = True
        Me.lblWangType.Location = New System.Drawing.Point(6, 106)
        Me.lblWangType.Name = "lblWangType"
        Me.lblWangType.Size = New System.Drawing.Size(63, 13)
        Me.lblWangType.TabIndex = 7
        Me.lblWangType.Text = "Wang Type"
        '
        'cboToolType
        '
        Me.cboToolType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboToolType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboToolType.FormattingEnabled = True
        Me.cboToolType.Location = New System.Drawing.Point(9, 76)
        Me.cboToolType.Name = "cboToolType"
        Me.cboToolType.Size = New System.Drawing.Size(263, 21)
        Me.cboToolType.TabIndex = 1
        '
        'lblToolType
        '
        Me.lblToolType.AutoSize = True
        Me.lblToolType.Location = New System.Drawing.Point(6, 60)
        Me.lblToolType.Name = "lblToolType"
        Me.lblToolType.Size = New System.Drawing.Size(55, 13)
        Me.lblToolType.TabIndex = 5
        Me.lblToolType.Text = "Tool Type"
        '
        'lblBlueprintNumber
        '
        Me.lblBlueprintNumber.AutoSize = True
        Me.lblBlueprintNumber.Location = New System.Drawing.Point(6, 31)
        Me.lblBlueprintNumber.Name = "lblBlueprintNumber"
        Me.lblBlueprintNumber.Size = New System.Drawing.Size(88, 13)
        Me.lblBlueprintNumber.TabIndex = 4
        Me.lblBlueprintNumber.Text = "Blueprint Number"
        '
        'cboBlueprintNumber
        '
        Me.cboBlueprintNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBlueprintNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBlueprintNumber.FormattingEnabled = True
        Me.cboBlueprintNumber.Location = New System.Drawing.Point(140, 28)
        Me.cboBlueprintNumber.Name = "cboBlueprintNumber"
        Me.cboBlueprintNumber.Size = New System.Drawing.Size(132, 21)
        Me.cboBlueprintNumber.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblRemoveMaterialType)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.lblRemoveBlueprintNumber)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.lblRemoveSectionColumnData)
        Me.GroupBox1.Controls.Add(Me.cmdRemoveTool)
        Me.GroupBox1.Controls.Add(Me.lblRemoveSectionRowData)
        Me.GroupBox1.Controls.Add(Me.cboRemoveToolType)
        Me.GroupBox1.Controls.Add(Me.lblRemoveSectionData)
        Me.GroupBox1.Controls.Add(Me.lblDeleteToolType)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblSection)
        Me.GroupBox1.Controls.Add(Me.lblSectionRow)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 352)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(286, 245)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Remove Tool"
        '
        'lblRemoveMaterialType
        '
        Me.lblRemoveMaterialType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemoveMaterialType.Location = New System.Drawing.Point(111, 167)
        Me.lblRemoveMaterialType.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRemoveMaterialType.Name = "lblRemoveMaterialType"
        Me.lblRemoveMaterialType.Size = New System.Drawing.Size(161, 21)
        Me.lblRemoveMaterialType.TabIndex = 21
        Me.lblRemoveMaterialType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 171)
        Me.Label23.Margin = New System.Windows.Forms.Padding(3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(71, 13)
        Me.Label23.TabIndex = 20
        Me.Label23.Text = "Material Type"
        '
        'lblRemoveBlueprintNumber
        '
        Me.lblRemoveBlueprintNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemoveBlueprintNumber.Location = New System.Drawing.Point(111, 140)
        Me.lblRemoveBlueprintNumber.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRemoveBlueprintNumber.Name = "lblRemoveBlueprintNumber"
        Me.lblRemoveBlueprintNumber.Size = New System.Drawing.Size(161, 21)
        Me.lblRemoveBlueprintNumber.TabIndex = 19
        Me.lblRemoveBlueprintNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 144)
        Me.Label21.Margin = New System.Windows.Forms.Padding(3)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(88, 13)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Blueprint Number"
        '
        'lblRemoveSectionColumnData
        '
        Me.lblRemoveSectionColumnData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemoveSectionColumnData.Location = New System.Drawing.Point(111, 113)
        Me.lblRemoveSectionColumnData.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRemoveSectionColumnData.Name = "lblRemoveSectionColumnData"
        Me.lblRemoveSectionColumnData.Size = New System.Drawing.Size(161, 21)
        Me.lblRemoveSectionColumnData.TabIndex = 16
        Me.lblRemoveSectionColumnData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdRemoveTool
        '
        Me.cmdRemoveTool.Location = New System.Drawing.Point(201, 194)
        Me.cmdRemoveTool.Name = "cmdRemoveTool"
        Me.cmdRemoveTool.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoveTool.TabIndex = 1
        Me.cmdRemoveTool.Text = "Delete"
        Me.cmdRemoveTool.UseVisualStyleBackColor = True
        '
        'lblRemoveSectionRowData
        '
        Me.lblRemoveSectionRowData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemoveSectionRowData.Location = New System.Drawing.Point(111, 86)
        Me.lblRemoveSectionRowData.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRemoveSectionRowData.Name = "lblRemoveSectionRowData"
        Me.lblRemoveSectionRowData.Size = New System.Drawing.Size(161, 21)
        Me.lblRemoveSectionRowData.TabIndex = 15
        Me.lblRemoveSectionRowData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRemoveToolType
        '
        Me.cboRemoveToolType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRemoveToolType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRemoveToolType.FormattingEnabled = True
        Me.cboRemoveToolType.Location = New System.Drawing.Point(9, 32)
        Me.cboRemoveToolType.Name = "cboRemoveToolType"
        Me.cboRemoveToolType.Size = New System.Drawing.Size(263, 21)
        Me.cboRemoveToolType.TabIndex = 0
        '
        'lblRemoveSectionData
        '
        Me.lblRemoveSectionData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemoveSectionData.Location = New System.Drawing.Point(111, 59)
        Me.lblRemoveSectionData.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRemoveSectionData.Name = "lblRemoveSectionData"
        Me.lblRemoveSectionData.Size = New System.Drawing.Size(161, 21)
        Me.lblRemoveSectionData.TabIndex = 14
        Me.lblRemoveSectionData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDeleteToolType
        '
        Me.lblDeleteToolType.AutoSize = True
        Me.lblDeleteToolType.Location = New System.Drawing.Point(6, 16)
        Me.lblDeleteToolType.Name = "lblDeleteToolType"
        Me.lblDeleteToolType.Size = New System.Drawing.Size(55, 13)
        Me.lblDeleteToolType.TabIndex = 17
        Me.lblDeleteToolType.Text = "Tool Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 117)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Section Column"
        '
        'lblSection
        '
        Me.lblSection.AutoSize = True
        Me.lblSection.Location = New System.Drawing.Point(6, 63)
        Me.lblSection.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(43, 13)
        Me.lblSection.TabIndex = 7
        Me.lblSection.Text = "Section"
        '
        'lblSectionRow
        '
        Me.lblSectionRow.AutoSize = True
        Me.lblSectionRow.Location = New System.Drawing.Point(6, 90)
        Me.lblSectionRow.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSectionRow.Name = "lblSectionRow"
        Me.lblSectionRow.Size = New System.Drawing.Size(68, 13)
        Me.lblSectionRow.TabIndex = 11
        Me.lblSectionRow.Text = "Section Row"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.pnlAddTool)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(301, 603)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Add To Inventory"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Wang Type"
        '
        'pnlAddTool
        '
        Me.pnlAddTool.Controls.Add(Me.cmdClearAddInventory)
        Me.pnlAddTool.Controls.Add(Me.Label6)
        Me.pnlAddTool.Controls.Add(Me.chkPrintLabel)
        Me.pnlAddTool.Controls.Add(Me.cmdAddToInventory)
        Me.pnlAddTool.Controls.Add(Me.Label18)
        Me.pnlAddTool.Controls.Add(Me.Label2)
        Me.pnlAddTool.Controls.Add(Me.Label19)
        Me.pnlAddTool.Controls.Add(Me.Label3)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventorySectionColumn)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventoryDieSection)
        Me.pnlAddTool.Controls.Add(Me.Label4)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventoryRemarks)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventoryFourthID)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventoryFourthLength)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventorySectionRow)
        Me.pnlAddTool.Controls.Add(Me.Label16)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventoryThirdID)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventorySection)
        Me.pnlAddTool.Controls.Add(Me.Label17)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventoryThirdLength)
        Me.pnlAddTool.Controls.Add(Me.Label14)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventorySecondID)
        Me.pnlAddTool.Controls.Add(Me.Label15)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventorySecondLength)
        Me.pnlAddTool.Controls.Add(Me.Label12)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventoryFirstID)
        Me.pnlAddTool.Controls.Add(Me.Label13)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventoryFirstLength)
        Me.pnlAddTool.Controls.Add(Me.Label11)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventoryOuterDiameter)
        Me.pnlAddTool.Controls.Add(Me.Label10)
        Me.pnlAddTool.Controls.Add(Me.txtAddInventoryMaterialType)
        Me.pnlAddTool.Controls.Add(Me.Label9)
        Me.pnlAddTool.Controls.Add(Me.cboAddInventoryWangType)
        Me.pnlAddTool.Controls.Add(Me.Label8)
        Me.pnlAddTool.Controls.Add(Me.cboAddInventoryToolType)
        Me.pnlAddTool.Controls.Add(Me.cboAddInventoryBlueprintNumber)
        Me.pnlAddTool.Controls.Add(Me.Label7)
        Me.pnlAddTool.Location = New System.Drawing.Point(1, 3)
        Me.pnlAddTool.Name = "pnlAddTool"
        Me.pnlAddTool.Size = New System.Drawing.Size(304, 607)
        Me.pnlAddTool.TabIndex = 5
        '
        'cmdClearAddInventory
        '
        Me.cmdClearAddInventory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAddInventory.Location = New System.Drawing.Point(219, 557)
        Me.cmdClearAddInventory.Name = "cmdClearAddInventory"
        Me.cmdClearAddInventory.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAddInventory.TabIndex = 20
        Me.cmdClearAddInventory.Text = "Clear Add Inventory"
        Me.cmdClearAddInventory.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Tool Type"
        '
        'chkPrintLabel
        '
        Me.chkPrintLabel.AutoSize = True
        Me.chkPrintLabel.Location = New System.Drawing.Point(32, 557)
        Me.chkPrintLabel.Name = "chkPrintLabel"
        Me.chkPrintLabel.Size = New System.Drawing.Size(76, 17)
        Me.chkPrintLabel.TabIndex = 18
        Me.chkPrintLabel.Text = "Print Label"
        Me.chkPrintLabel.UseVisualStyleBackColor = True
        '
        'cmdAddToInventory
        '
        Me.cmdAddToInventory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddToInventory.Location = New System.Drawing.Point(142, 557)
        Me.cmdAddToInventory.Name = "cmdAddToInventory"
        Me.cmdAddToInventory.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddToInventory.TabIndex = 19
        Me.cmdAddToInventory.Text = "Add To Inventory"
        Me.cmdAddToInventory.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 466)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 49
        Me.Label18.Text = "Remarks"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 447)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Section Column"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(10, 367)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 13)
        Me.Label19.TabIndex = 51
        Me.Label19.Text = "Die Section"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 420)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Section Row"
        '
        'txtAddInventorySectionColumn
        '
        Me.txtAddInventorySectionColumn.Location = New System.Drawing.Point(130, 444)
        Me.txtAddInventorySectionColumn.Name = "txtAddInventorySectionColumn"
        Me.txtAddInventorySectionColumn.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventorySectionColumn.TabIndex = 16
        '
        'txtAddInventoryDieSection
        '
        Me.txtAddInventoryDieSection.Location = New System.Drawing.Point(130, 364)
        Me.txtAddInventoryDieSection.Name = "txtAddInventoryDieSection"
        Me.txtAddInventoryDieSection.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventoryDieSection.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 393)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Section"
        '
        'txtAddInventoryRemarks
        '
        Me.txtAddInventoryRemarks.Location = New System.Drawing.Point(12, 483)
        Me.txtAddInventoryRemarks.MaxLength = 100
        Me.txtAddInventoryRemarks.Multiline = True
        Me.txtAddInventoryRemarks.Name = "txtAddInventoryRemarks"
        Me.txtAddInventoryRemarks.Size = New System.Drawing.Size(278, 68)
        Me.txtAddInventoryRemarks.TabIndex = 17
        '
        'txtAddInventoryFourthID
        '
        Me.txtAddInventoryFourthID.Location = New System.Drawing.Point(130, 338)
        Me.txtAddInventoryFourthID.Name = "txtAddInventoryFourthID"
        Me.txtAddInventoryFourthID.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventoryFourthID.TabIndex = 12
        '
        'txtAddInventoryFourthLength
        '
        Me.txtAddInventoryFourthLength.Location = New System.Drawing.Point(130, 312)
        Me.txtAddInventoryFourthLength.Name = "txtAddInventoryFourthLength"
        Me.txtAddInventoryFourthLength.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventoryFourthLength.TabIndex = 11
        '
        'txtAddInventorySectionRow
        '
        Me.txtAddInventorySectionRow.Location = New System.Drawing.Point(130, 417)
        Me.txtAddInventorySectionRow.Name = "txtAddInventorySectionRow"
        Me.txtAddInventorySectionRow.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventorySectionRow.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 341)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 13)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Fourth Inner Diameter"
        '
        'txtAddInventoryThirdID
        '
        Me.txtAddInventoryThirdID.Location = New System.Drawing.Point(130, 286)
        Me.txtAddInventoryThirdID.Name = "txtAddInventoryThirdID"
        Me.txtAddInventoryThirdID.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventoryThirdID.TabIndex = 10
        '
        'txtAddInventorySection
        '
        Me.txtAddInventorySection.Location = New System.Drawing.Point(130, 390)
        Me.txtAddInventorySection.Name = "txtAddInventorySection"
        Me.txtAddInventorySection.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventorySection.TabIndex = 14
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(10, 315)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 13)
        Me.Label17.TabIndex = 45
        Me.Label17.Text = "Fourth Length"
        '
        'txtAddInventoryThirdLength
        '
        Me.txtAddInventoryThirdLength.Location = New System.Drawing.Point(130, 260)
        Me.txtAddInventoryThirdLength.Name = "txtAddInventoryThirdLength"
        Me.txtAddInventoryThirdLength.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventoryThirdLength.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 289)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 13)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "Third Inner Diameter"
        '
        'txtAddInventorySecondID
        '
        Me.txtAddInventorySecondID.Location = New System.Drawing.Point(130, 234)
        Me.txtAddInventorySecondID.Name = "txtAddInventorySecondID"
        Me.txtAddInventorySecondID.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventorySecondID.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 263)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "Third Length"
        '
        'txtAddInventorySecondLength
        '
        Me.txtAddInventorySecondLength.Location = New System.Drawing.Point(130, 208)
        Me.txtAddInventorySecondLength.Name = "txtAddInventorySecondLength"
        Me.txtAddInventorySecondLength.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventorySecondLength.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 237)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 13)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Second Inner Diameter"
        '
        'txtAddInventoryFirstID
        '
        Me.txtAddInventoryFirstID.Location = New System.Drawing.Point(130, 182)
        Me.txtAddInventoryFirstID.Name = "txtAddInventoryFirstID"
        Me.txtAddInventoryFirstID.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventoryFirstID.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 211)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Second Length"
        '
        'txtAddInventoryFirstLength
        '
        Me.txtAddInventoryFirstLength.Location = New System.Drawing.Point(130, 156)
        Me.txtAddInventoryFirstLength.Name = "txtAddInventoryFirstLength"
        Me.txtAddInventoryFirstLength.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventoryFirstLength.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 185)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 13)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "First Inner Diameter"
        '
        'txtAddInventoryOuterDiameter
        '
        Me.txtAddInventoryOuterDiameter.Location = New System.Drawing.Point(130, 130)
        Me.txtAddInventoryOuterDiameter.Name = "txtAddInventoryOuterDiameter"
        Me.txtAddInventoryOuterDiameter.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventoryOuterDiameter.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 159)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "First Length"
        '
        'txtAddInventoryMaterialType
        '
        Me.txtAddInventoryMaterialType.Location = New System.Drawing.Point(130, 104)
        Me.txtAddInventoryMaterialType.Name = "txtAddInventoryMaterialType"
        Me.txtAddInventoryMaterialType.Size = New System.Drawing.Size(161, 20)
        Me.txtAddInventoryMaterialType.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 133)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Outer Diameter"
        '
        'cboAddInventoryWangType
        '
        Me.cboAddInventoryWangType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAddInventoryWangType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAddInventoryWangType.FormattingEnabled = True
        Me.cboAddInventoryWangType.Location = New System.Drawing.Point(130, 50)
        Me.cboAddInventoryWangType.Name = "cboAddInventoryWangType"
        Me.cboAddInventoryWangType.Size = New System.Drawing.Size(161, 21)
        Me.cboAddInventoryWangType.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Material Type"
        '
        'cboAddInventoryToolType
        '
        Me.cboAddInventoryToolType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAddInventoryToolType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAddInventoryToolType.FormattingEnabled = True
        Me.cboAddInventoryToolType.Location = New System.Drawing.Point(13, 21)
        Me.cboAddInventoryToolType.Name = "cboAddInventoryToolType"
        Me.cboAddInventoryToolType.Size = New System.Drawing.Size(278, 21)
        Me.cboAddInventoryToolType.TabIndex = 0
        '
        'cboAddInventoryBlueprintNumber
        '
        Me.cboAddInventoryBlueprintNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAddInventoryBlueprintNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAddInventoryBlueprintNumber.FormattingEnabled = True
        Me.cboAddInventoryBlueprintNumber.Location = New System.Drawing.Point(130, 77)
        Me.cboAddInventoryBlueprintNumber.Name = "cboAddInventoryBlueprintNumber"
        Me.cboAddInventoryBlueprintNumber.Size = New System.Drawing.Size(161, 21)
        Me.cboAddInventoryBlueprintNumber.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Blueprint Number"
        '
        'cmdPrintListing
        '
        Me.cmdPrintListing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintListing.Location = New System.Drawing.Point(866, 618)
        Me.cmdPrintListing.Name = "cmdPrintListing"
        Me.cmdPrintListing.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintListing.TabIndex = 3
        Me.cmdPrintListing.Text = "Print Listing"
        Me.cmdPrintListing.UseVisualStyleBackColor = True
        '
        'cmdPrintLabel
        '
        Me.cmdPrintLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintLabel.Location = New System.Drawing.Point(768, 618)
        Me.cmdPrintLabel.Name = "cmdPrintLabel"
        Me.cmdPrintLabel.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintLabel.TabIndex = 5
        Me.cmdPrintLabel.Text = "Print Label"
        Me.cmdPrintLabel.UseVisualStyleBackColor = True
        '
        'ToolRoomInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 670)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.tabctrlSearchAdd)
        Me.Controls.Add(Me.dgvToolRoomInventory)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdPrintLabel)
        Me.Controls.Add(Me.cmdPrintListing)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "ToolRoomInventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Misc. Tooling"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvToolRoomInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabctrlSearchAdd.ResumeLayout(False)
        Me.tabSearchRemoveTool.ResumeLayout(False)
        Me.gpxSearch.ResumeLayout(False)
        Me.gpxSearch.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.pnlAddTool.ResumeLayout(False)
        Me.pnlAddTool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents tabctrlSearchAdd As System.Windows.Forms.TabControl
    Friend WithEvents tabSearchRemoveTool As System.Windows.Forms.TabPage
    Friend WithEvents gpxSearch As System.Windows.Forms.GroupBox
    Friend WithEvents txtSearchInnerDiameterTolerance As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtSearchFirstInnerDiameter As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtSearchFirstLength As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtSearchSectionColumn As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchSectionRow As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchSection As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchSectionColumn As System.Windows.Forms.Label
    Friend WithEvents lblSearchSectionRow As System.Windows.Forms.Label
    Friend WithEvents lblSearchSection As System.Windows.Forms.Label
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdClearSearch As System.Windows.Forms.Button
    Friend WithEvents cboWangType As System.Windows.Forms.ComboBox
    Friend WithEvents lblWangType As System.Windows.Forms.Label
    Friend WithEvents cboToolType As System.Windows.Forms.ComboBox
    Friend WithEvents lblToolType As System.Windows.Forms.Label
    Friend WithEvents lblBlueprintNumber As System.Windows.Forms.Label
    Friend WithEvents cboBlueprintNumber As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRemoveMaterialType As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblRemoveBlueprintNumber As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblRemoveSectionColumnData As System.Windows.Forms.Label
    Friend WithEvents cmdRemoveTool As System.Windows.Forms.Button
    Friend WithEvents lblRemoveSectionRowData As System.Windows.Forms.Label
    Friend WithEvents cboRemoveToolType As System.Windows.Forms.ComboBox
    Friend WithEvents lblRemoveSectionData As System.Windows.Forms.Label
    Friend WithEvents lblDeleteToolType As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSection As System.Windows.Forms.Label
    Friend WithEvents lblSectionRow As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlAddTool As System.Windows.Forms.Panel
    Friend WithEvents cmdClearAddInventory As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkPrintLabel As System.Windows.Forms.CheckBox
    Friend WithEvents cmdAddToInventory As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAddInventorySectionColumn As System.Windows.Forms.TextBox
    Friend WithEvents txtAddInventoryDieSection As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAddInventoryRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtAddInventoryFourthID As System.Windows.Forms.TextBox
    Friend WithEvents txtAddInventoryFourthLength As System.Windows.Forms.TextBox
    Friend WithEvents txtAddInventorySectionRow As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAddInventoryThirdID As System.Windows.Forms.TextBox
    Friend WithEvents txtAddInventorySection As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAddInventoryThirdLength As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtAddInventorySecondID As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtAddInventorySecondLength As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAddInventoryFirstID As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAddInventoryFirstLength As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAddInventoryOuterDiameter As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAddInventoryMaterialType As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboAddInventoryWangType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboAddInventoryToolType As System.Windows.Forms.ComboBox
    Friend WithEvents cboAddInventoryBlueprintNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvToolRoomInventory As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrintListing As System.Windows.Forms.Button
    Friend WithEvents cmdPrintLabel As System.Windows.Forms.Button

End Class
