<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryPriceLevels
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventoryPriceLevels))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxPartNumberData = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdUpdateLevels = New System.Windows.Forms.Button
        Me.cmdUpdateBase = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtBaseCost = New System.Windows.Forms.TextBox
        Me.txtLastPurchaseCost = New System.Windows.Forms.TextBox
        Me.txtMultiplier5 = New System.Windows.Forms.TextBox
        Me.txtMultiplier4 = New System.Windows.Forms.TextBox
        Me.txtMultiplier3 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtMultiplier2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtMultiplier1 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPriceLevel4 = New System.Windows.Forms.TextBox
        Me.txtPriceLevel2 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPriceLevel5 = New System.Windows.Forms.TextBox
        Me.txtPriceLevel1 = New System.Windows.Forms.TextBox
        Me.txtPriceLevel3 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtGrossMargin = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.chkUpdateStandard = New System.Windows.Forms.CheckBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmdUpdateItemClass = New System.Windows.Forms.Button
        Me.txtItemMultiplier5 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtItemMultiplier4 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtItemMultiplier3 = New System.Windows.Forms.TextBox
        Me.txtItemMultiplier1 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtItemMultiplier2 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.dgvItemList = New System.Windows.Forms.DataGridView
        Me.ItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LongDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchProdLineIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesProdLineIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxCountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletCountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardCostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StandardPriceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OldPartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MinimumStockDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaximumStockDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BeginningBalanceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalDiameterDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalLengthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AddAccessoryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PreferredVendorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtCalculatedMultiplier = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmdClearForm = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxPartNumberData.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
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
        'gpxPartNumberData
        '
        Me.gpxPartNumberData.Controls.Add(Me.cboDivisionID)
        Me.gpxPartNumberData.Controls.Add(Me.cboPartNumber)
        Me.gpxPartNumberData.Controls.Add(Me.txtLongDescription)
        Me.gpxPartNumberData.Controls.Add(Me.cboPartDescription)
        Me.gpxPartNumberData.Controls.Add(Me.Label2)
        Me.gpxPartNumberData.Controls.Add(Me.Label1)
        Me.gpxPartNumberData.Location = New System.Drawing.Point(29, 41)
        Me.gpxPartNumberData.Name = "gpxPartNumberData"
        Me.gpxPartNumberData.Size = New System.Drawing.Size(300, 203)
        Me.gpxPartNumberData.TabIndex = 0
        Me.gpxPartNumberData.TabStop = False
        Me.gpxPartNumberData.Text = "Part Number Information"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(103, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(182, 21)
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
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(103, 60)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(182, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLongDescription.Location = New System.Drawing.Point(23, 124)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(262, 65)
        Me.txtLongDescription.TabIndex = 3
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(23, 92)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(262, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Part Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Last Purchase Cost"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdUpdateLevels
        '
        Me.cmdUpdateLevels.Location = New System.Drawing.Point(215, 219)
        Me.cmdUpdateLevels.Name = "cmdUpdateLevels"
        Me.cmdUpdateLevels.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateLevels.TabIndex = 17
        Me.cmdUpdateLevels.Text = "Update Levels"
        Me.cmdUpdateLevels.UseVisualStyleBackColor = True
        '
        'cmdUpdateBase
        '
        Me.cmdUpdateBase.Location = New System.Drawing.Point(214, 126)
        Me.cmdUpdateBase.Name = "cmdUpdateBase"
        Me.cmdUpdateBase.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateBase.TabIndex = 6
        Me.cmdUpdateBase.Text = "Update Base Cost"
        Me.cmdUpdateBase.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 30
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 31
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtBaseCost)
        Me.GroupBox1.Controls.Add(Me.cmdUpdateBase)
        Me.GroupBox1.Controls.Add(Me.txtLastPurchaseCost)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 250)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 179)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item Cost"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 20)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Current Base Cost"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(14, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(271, 30)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "To update the current base cost, eneter the new cost into the designated field an" & _
            "d press ""Update"". "
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBaseCost
        '
        Me.txtBaseCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBaseCost.Location = New System.Drawing.Point(150, 55)
        Me.txtBaseCost.Name = "txtBaseCost"
        Me.txtBaseCost.Size = New System.Drawing.Size(136, 20)
        Me.txtBaseCost.TabIndex = 5
        Me.txtBaseCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLastPurchaseCost
        '
        Me.txtLastPurchaseCost.BackColor = System.Drawing.Color.White
        Me.txtLastPurchaseCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastPurchaseCost.Location = New System.Drawing.Point(149, 29)
        Me.txtLastPurchaseCost.Name = "txtLastPurchaseCost"
        Me.txtLastPurchaseCost.ReadOnly = True
        Me.txtLastPurchaseCost.Size = New System.Drawing.Size(136, 20)
        Me.txtLastPurchaseCost.TabIndex = 4
        Me.txtLastPurchaseCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMultiplier5
        '
        Me.txtMultiplier5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMultiplier5.Location = New System.Drawing.Point(63, 152)
        Me.txtMultiplier5.Name = "txtMultiplier5"
        Me.txtMultiplier5.Size = New System.Drawing.Size(79, 20)
        Me.txtMultiplier5.TabIndex = 11
        Me.txtMultiplier5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMultiplier4
        '
        Me.txtMultiplier4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMultiplier4.Location = New System.Drawing.Point(63, 124)
        Me.txtMultiplier4.Name = "txtMultiplier4"
        Me.txtMultiplier4.Size = New System.Drawing.Size(79, 20)
        Me.txtMultiplier4.TabIndex = 10
        Me.txtMultiplier4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMultiplier3
        '
        Me.txtMultiplier3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMultiplier3.Location = New System.Drawing.Point(63, 96)
        Me.txtMultiplier3.Name = "txtMultiplier3"
        Me.txtMultiplier3.Size = New System.Drawing.Size(79, 20)
        Me.txtMultiplier3.TabIndex = 9
        Me.txtMultiplier3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(171, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Price Level"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMultiplier2
        '
        Me.txtMultiplier2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMultiplier2.Location = New System.Drawing.Point(63, 68)
        Me.txtMultiplier2.Name = "txtMultiplier2"
        Me.txtMultiplier2.Size = New System.Drawing.Size(79, 20)
        Me.txtMultiplier2.TabIndex = 8
        Me.txtMultiplier2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 20)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "PL1"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(60, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Multiplier"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 20)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "PL2"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMultiplier1
        '
        Me.txtMultiplier1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMultiplier1.Location = New System.Drawing.Point(63, 40)
        Me.txtMultiplier1.Name = "txtMultiplier1"
        Me.txtMultiplier1.Size = New System.Drawing.Size(79, 20)
        Me.txtMultiplier1.TabIndex = 7
        Me.txtMultiplier1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(15, 152)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 20)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "PL5"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPriceLevel4
        '
        Me.txtPriceLevel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPriceLevel4.Location = New System.Drawing.Point(174, 124)
        Me.txtPriceLevel4.Name = "txtPriceLevel4"
        Me.txtPriceLevel4.Size = New System.Drawing.Size(112, 20)
        Me.txtPriceLevel4.TabIndex = 15
        Me.txtPriceLevel4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPriceLevel2
        '
        Me.txtPriceLevel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPriceLevel2.Location = New System.Drawing.Point(174, 68)
        Me.txtPriceLevel2.Name = "txtPriceLevel2"
        Me.txtPriceLevel2.Size = New System.Drawing.Size(112, 20)
        Me.txtPriceLevel2.TabIndex = 13
        Me.txtPriceLevel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 20)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "PL3"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPriceLevel5
        '
        Me.txtPriceLevel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPriceLevel5.Location = New System.Drawing.Point(174, 152)
        Me.txtPriceLevel5.Name = "txtPriceLevel5"
        Me.txtPriceLevel5.Size = New System.Drawing.Size(112, 20)
        Me.txtPriceLevel5.TabIndex = 16
        Me.txtPriceLevel5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPriceLevel1
        '
        Me.txtPriceLevel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPriceLevel1.Location = New System.Drawing.Point(174, 40)
        Me.txtPriceLevel1.Name = "txtPriceLevel1"
        Me.txtPriceLevel1.Size = New System.Drawing.Size(112, 20)
        Me.txtPriceLevel1.TabIndex = 12
        Me.txtPriceLevel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPriceLevel3
        '
        Me.txtPriceLevel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPriceLevel3.Location = New System.Drawing.Point(174, 96)
        Me.txtPriceLevel3.Name = "txtPriceLevel3"
        Me.txtPriceLevel3.Size = New System.Drawing.Size(112, 20)
        Me.txtPriceLevel3.TabIndex = 14
        Me.txtPriceLevel3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(15, 124)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 20)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "PL4"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(14, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 20)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Desired Profit Margin"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(14, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Calculated Multiplier"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGrossMargin
        '
        Me.txtGrossMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrossMargin.Location = New System.Drawing.Point(146, 42)
        Me.txtGrossMargin.Name = "txtGrossMargin"
        Me.txtGrossMargin.Size = New System.Drawing.Size(117, 20)
        Me.txtGrossMargin.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(15, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(271, 30)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Leave Multiplier Field blank to allow manual entry of any Price Level."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(15, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Item Class"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtMultiplier5)
        Me.GroupBox2.Controls.Add(Me.txtPriceLevel2)
        Me.GroupBox2.Controls.Add(Me.txtPriceLevel4)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtMultiplier4)
        Me.GroupBox2.Controls.Add(Me.cmdUpdateLevels)
        Me.GroupBox2.Controls.Add(Me.txtPriceLevel5)
        Me.GroupBox2.Controls.Add(Me.txtPriceLevel3)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtMultiplier3)
        Me.GroupBox2.Controls.Add(Me.txtMultiplier1)
        Me.GroupBox2.Controls.Add(Me.txtPriceLevel1)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtMultiplier2)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 435)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 276)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Price Levels"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.chkUpdateStandard)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.cmdUpdateItemClass)
        Me.GroupBox3.Controls.Add(Me.txtItemMultiplier5)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.txtItemMultiplier4)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtItemMultiplier3)
        Me.GroupBox3.Controls.Add(Me.txtItemMultiplier1)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.txtItemMultiplier2)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.cboItemClass)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(338, 41)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(278, 388)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Create Price Levels for Entire Item Class"
        '
        'Label25
        '
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(15, 345)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(162, 30)
        Me.Label25.TabIndex = 62
        Me.Label25.Text = "Updates Standard Cost, Standard Price in Item List."
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkUpdateStandard
        '
        Me.chkUpdateStandard.AutoSize = True
        Me.chkUpdateStandard.Location = New System.Drawing.Point(15, 317)
        Me.chkUpdateStandard.Name = "chkUpdateStandard"
        Me.chkUpdateStandard.Size = New System.Drawing.Size(109, 17)
        Me.chkUpdateStandard.TabIndex = 61
        Me.chkUpdateStandard.Text = "Update Item List?"
        Me.chkUpdateStandard.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.Location = New System.Drawing.Point(15, 224)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(249, 78)
        Me.Label22.TabIndex = 60
        Me.Label22.Text = resources.GetString("Label22.Text")
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdUpdateItemClass
        '
        Me.cmdUpdateItemClass.Location = New System.Drawing.Point(193, 335)
        Me.cmdUpdateItemClass.Name = "cmdUpdateItemClass"
        Me.cmdUpdateItemClass.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateItemClass.TabIndex = 24
        Me.cmdUpdateItemClass.Text = "Update Item Class"
        Me.cmdUpdateItemClass.UseVisualStyleBackColor = True
        '
        'txtItemMultiplier5
        '
        Me.txtItemMultiplier5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemMultiplier5.Location = New System.Drawing.Point(138, 192)
        Me.txtItemMultiplier5.Name = "txtItemMultiplier5"
        Me.txtItemMultiplier5.Size = New System.Drawing.Size(126, 20)
        Me.txtItemMultiplier5.TabIndex = 23
        Me.txtItemMultiplier5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(15, 134)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 20)
        Me.Label17.TabIndex = 51
        Me.Label17.Text = "Multiplier 3"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(15, 190)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(103, 20)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "Multiplier 5"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtItemMultiplier4
        '
        Me.txtItemMultiplier4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemMultiplier4.Location = New System.Drawing.Point(138, 164)
        Me.txtItemMultiplier4.Name = "txtItemMultiplier4"
        Me.txtItemMultiplier4.Size = New System.Drawing.Size(126, 20)
        Me.txtItemMultiplier4.TabIndex = 22
        Me.txtItemMultiplier4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(15, 162)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 20)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Multiplier 4"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtItemMultiplier3
        '
        Me.txtItemMultiplier3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemMultiplier3.Location = New System.Drawing.Point(138, 136)
        Me.txtItemMultiplier3.Name = "txtItemMultiplier3"
        Me.txtItemMultiplier3.Size = New System.Drawing.Size(126, 20)
        Me.txtItemMultiplier3.TabIndex = 21
        Me.txtItemMultiplier3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItemMultiplier1
        '
        Me.txtItemMultiplier1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemMultiplier1.Location = New System.Drawing.Point(138, 80)
        Me.txtItemMultiplier1.Name = "txtItemMultiplier1"
        Me.txtItemMultiplier1.Size = New System.Drawing.Size(126, 20)
        Me.txtItemMultiplier1.TabIndex = 19
        Me.txtItemMultiplier1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(15, 106)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 20)
        Me.Label20.TabIndex = 50
        Me.Label20.Text = "Multiplier 2"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtItemMultiplier2
        '
        Me.txtItemMultiplier2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemMultiplier2.Location = New System.Drawing.Point(138, 108)
        Me.txtItemMultiplier2.Name = "txtItemMultiplier2"
        Me.txtItemMultiplier2.Size = New System.Drawing.Size(126, 20)
        Me.txtItemMultiplier2.TabIndex = 20
        Me.txtItemMultiplier2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(15, 78)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(103, 20)
        Me.Label21.TabIndex = 52
        Me.Label21.Text = "Multiplier 1"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(85, 38)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(179, 21)
        Me.cboItemClass.TabIndex = 18
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'dgvItemList
        '
        Me.dgvItemList.AllowUserToAddRows = False
        Me.dgvItemList.AllowUserToDeleteRows = False
        Me.dgvItemList.AllowUserToOrderColumns = True
        Me.dgvItemList.AutoGenerateColumns = False
        Me.dgvItemList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvItemList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemIDColumn, Me.ShortDescriptionColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.LongDescriptionDataGridViewTextBoxColumn, Me.ItemClassDataGridViewTextBoxColumn, Me.PurchProdLineIDDataGridViewTextBoxColumn, Me.SalesProdLineIDDataGridViewTextBoxColumn, Me.PieceWeightDataGridViewTextBoxColumn, Me.BoxCountDataGridViewTextBoxColumn, Me.PalletCountDataGridViewTextBoxColumn, Me.StandardCostDataGridViewTextBoxColumn, Me.StandardPriceDataGridViewTextBoxColumn, Me.OldPartNumberDataGridViewTextBoxColumn, Me.MinimumStockDataGridViewTextBoxColumn, Me.MaximumStockDataGridViewTextBoxColumn, Me.CreationDateDataGridViewTextBoxColumn, Me.BeginningBalanceDataGridViewTextBoxColumn, Me.FOXNumberDataGridViewTextBoxColumn, Me.BoxTypeDataGridViewTextBoxColumn, Me.NominalDiameterDataGridViewTextBoxColumn, Me.NominalLengthDataGridViewTextBoxColumn, Me.AddAccessoryDataGridViewTextBoxColumn, Me.PreferredVendorDataGridViewTextBoxColumn})
        Me.dgvItemList.DataSource = Me.ItemListBindingSource
        Me.dgvItemList.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvItemList.Location = New System.Drawing.Point(634, 41)
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.ReadOnly = True
        Me.dgvItemList.Size = New System.Drawing.Size(496, 710)
        Me.dgvItemList.TabIndex = 32
        Me.dgvItemList.TabStop = False
        '
        'ItemIDColumn
        '
        Me.ItemIDColumn.DataPropertyName = "ItemID"
        Me.ItemIDColumn.HeaderText = "Part #"
        Me.ItemIDColumn.Name = "ItemIDColumn"
        Me.ItemIDColumn.ReadOnly = True
        Me.ItemIDColumn.Width = 101
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "Description"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        Me.ShortDescriptionColumn.ReadOnly = True
        Me.ShortDescriptionColumn.Width = 102
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.DivisionIDDataGridViewTextBoxColumn.Visible = False
        '
        'LongDescriptionDataGridViewTextBoxColumn
        '
        Me.LongDescriptionDataGridViewTextBoxColumn.DataPropertyName = "LongDescription"
        Me.LongDescriptionDataGridViewTextBoxColumn.HeaderText = "LongDescription"
        Me.LongDescriptionDataGridViewTextBoxColumn.Name = "LongDescriptionDataGridViewTextBoxColumn"
        Me.LongDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        Me.LongDescriptionDataGridViewTextBoxColumn.Visible = False
        '
        'ItemClassDataGridViewTextBoxColumn
        '
        Me.ItemClassDataGridViewTextBoxColumn.DataPropertyName = "ItemClass"
        Me.ItemClassDataGridViewTextBoxColumn.HeaderText = "ItemClass"
        Me.ItemClassDataGridViewTextBoxColumn.Name = "ItemClassDataGridViewTextBoxColumn"
        Me.ItemClassDataGridViewTextBoxColumn.ReadOnly = True
        Me.ItemClassDataGridViewTextBoxColumn.Visible = False
        '
        'PurchProdLineIDDataGridViewTextBoxColumn
        '
        Me.PurchProdLineIDDataGridViewTextBoxColumn.DataPropertyName = "PurchProdLineID"
        Me.PurchProdLineIDDataGridViewTextBoxColumn.HeaderText = "PurchProdLineID"
        Me.PurchProdLineIDDataGridViewTextBoxColumn.Name = "PurchProdLineIDDataGridViewTextBoxColumn"
        Me.PurchProdLineIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.PurchProdLineIDDataGridViewTextBoxColumn.Visible = False
        '
        'SalesProdLineIDDataGridViewTextBoxColumn
        '
        Me.SalesProdLineIDDataGridViewTextBoxColumn.DataPropertyName = "SalesProdLineID"
        Me.SalesProdLineIDDataGridViewTextBoxColumn.HeaderText = "SalesProdLineID"
        Me.SalesProdLineIDDataGridViewTextBoxColumn.Name = "SalesProdLineIDDataGridViewTextBoxColumn"
        Me.SalesProdLineIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SalesProdLineIDDataGridViewTextBoxColumn.Visible = False
        '
        'PieceWeightDataGridViewTextBoxColumn
        '
        Me.PieceWeightDataGridViewTextBoxColumn.DataPropertyName = "PieceWeight"
        Me.PieceWeightDataGridViewTextBoxColumn.HeaderText = "PieceWeight"
        Me.PieceWeightDataGridViewTextBoxColumn.Name = "PieceWeightDataGridViewTextBoxColumn"
        Me.PieceWeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.PieceWeightDataGridViewTextBoxColumn.Visible = False
        '
        'BoxCountDataGridViewTextBoxColumn
        '
        Me.BoxCountDataGridViewTextBoxColumn.DataPropertyName = "BoxCount"
        Me.BoxCountDataGridViewTextBoxColumn.HeaderText = "BoxCount"
        Me.BoxCountDataGridViewTextBoxColumn.Name = "BoxCountDataGridViewTextBoxColumn"
        Me.BoxCountDataGridViewTextBoxColumn.ReadOnly = True
        Me.BoxCountDataGridViewTextBoxColumn.Visible = False
        '
        'PalletCountDataGridViewTextBoxColumn
        '
        Me.PalletCountDataGridViewTextBoxColumn.DataPropertyName = "PalletCount"
        Me.PalletCountDataGridViewTextBoxColumn.HeaderText = "PalletCount"
        Me.PalletCountDataGridViewTextBoxColumn.Name = "PalletCountDataGridViewTextBoxColumn"
        Me.PalletCountDataGridViewTextBoxColumn.ReadOnly = True
        Me.PalletCountDataGridViewTextBoxColumn.Visible = False
        '
        'StandardCostDataGridViewTextBoxColumn
        '
        Me.StandardCostDataGridViewTextBoxColumn.DataPropertyName = "StandardCost"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N4"
        DataGridViewCellStyle1.NullValue = "0"
        Me.StandardCostDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.StandardCostDataGridViewTextBoxColumn.HeaderText = "Cost"
        Me.StandardCostDataGridViewTextBoxColumn.Name = "StandardCostDataGridViewTextBoxColumn"
        Me.StandardCostDataGridViewTextBoxColumn.ReadOnly = True
        Me.StandardCostDataGridViewTextBoxColumn.Width = 101
        '
        'StandardPriceDataGridViewTextBoxColumn
        '
        Me.StandardPriceDataGridViewTextBoxColumn.DataPropertyName = "StandardPrice"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = "0"
        Me.StandardPriceDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.StandardPriceDataGridViewTextBoxColumn.HeaderText = "Price"
        Me.StandardPriceDataGridViewTextBoxColumn.Name = "StandardPriceDataGridViewTextBoxColumn"
        Me.StandardPriceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OldPartNumberDataGridViewTextBoxColumn
        '
        Me.OldPartNumberDataGridViewTextBoxColumn.DataPropertyName = "OldPartNumber"
        Me.OldPartNumberDataGridViewTextBoxColumn.HeaderText = "OldPartNumber"
        Me.OldPartNumberDataGridViewTextBoxColumn.Name = "OldPartNumberDataGridViewTextBoxColumn"
        Me.OldPartNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.OldPartNumberDataGridViewTextBoxColumn.Visible = False
        '
        'MinimumStockDataGridViewTextBoxColumn
        '
        Me.MinimumStockDataGridViewTextBoxColumn.DataPropertyName = "MinimumStock"
        Me.MinimumStockDataGridViewTextBoxColumn.HeaderText = "MinimumStock"
        Me.MinimumStockDataGridViewTextBoxColumn.Name = "MinimumStockDataGridViewTextBoxColumn"
        Me.MinimumStockDataGridViewTextBoxColumn.ReadOnly = True
        Me.MinimumStockDataGridViewTextBoxColumn.Visible = False
        '
        'MaximumStockDataGridViewTextBoxColumn
        '
        Me.MaximumStockDataGridViewTextBoxColumn.DataPropertyName = "MaximumStock"
        Me.MaximumStockDataGridViewTextBoxColumn.HeaderText = "MaximumStock"
        Me.MaximumStockDataGridViewTextBoxColumn.Name = "MaximumStockDataGridViewTextBoxColumn"
        Me.MaximumStockDataGridViewTextBoxColumn.ReadOnly = True
        Me.MaximumStockDataGridViewTextBoxColumn.Visible = False
        '
        'CreationDateDataGridViewTextBoxColumn
        '
        Me.CreationDateDataGridViewTextBoxColumn.DataPropertyName = "CreationDate"
        Me.CreationDateDataGridViewTextBoxColumn.HeaderText = "CreationDate"
        Me.CreationDateDataGridViewTextBoxColumn.Name = "CreationDateDataGridViewTextBoxColumn"
        Me.CreationDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.CreationDateDataGridViewTextBoxColumn.Visible = False
        '
        'BeginningBalanceDataGridViewTextBoxColumn
        '
        Me.BeginningBalanceDataGridViewTextBoxColumn.DataPropertyName = "BeginningBalance"
        Me.BeginningBalanceDataGridViewTextBoxColumn.HeaderText = "BeginningBalance"
        Me.BeginningBalanceDataGridViewTextBoxColumn.Name = "BeginningBalanceDataGridViewTextBoxColumn"
        Me.BeginningBalanceDataGridViewTextBoxColumn.ReadOnly = True
        Me.BeginningBalanceDataGridViewTextBoxColumn.Visible = False
        '
        'FOXNumberDataGridViewTextBoxColumn
        '
        Me.FOXNumberDataGridViewTextBoxColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberDataGridViewTextBoxColumn.HeaderText = "FOXNumber"
        Me.FOXNumberDataGridViewTextBoxColumn.Name = "FOXNumberDataGridViewTextBoxColumn"
        Me.FOXNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.FOXNumberDataGridViewTextBoxColumn.Visible = False
        '
        'BoxTypeDataGridViewTextBoxColumn
        '
        Me.BoxTypeDataGridViewTextBoxColumn.DataPropertyName = "BoxType"
        Me.BoxTypeDataGridViewTextBoxColumn.HeaderText = "BoxType"
        Me.BoxTypeDataGridViewTextBoxColumn.Name = "BoxTypeDataGridViewTextBoxColumn"
        Me.BoxTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.BoxTypeDataGridViewTextBoxColumn.Visible = False
        '
        'NominalDiameterDataGridViewTextBoxColumn
        '
        Me.NominalDiameterDataGridViewTextBoxColumn.DataPropertyName = "NominalDiameter"
        Me.NominalDiameterDataGridViewTextBoxColumn.HeaderText = "NominalDiameter"
        Me.NominalDiameterDataGridViewTextBoxColumn.Name = "NominalDiameterDataGridViewTextBoxColumn"
        Me.NominalDiameterDataGridViewTextBoxColumn.ReadOnly = True
        Me.NominalDiameterDataGridViewTextBoxColumn.Visible = False
        '
        'NominalLengthDataGridViewTextBoxColumn
        '
        Me.NominalLengthDataGridViewTextBoxColumn.DataPropertyName = "NominalLength"
        Me.NominalLengthDataGridViewTextBoxColumn.HeaderText = "NominalLength"
        Me.NominalLengthDataGridViewTextBoxColumn.Name = "NominalLengthDataGridViewTextBoxColumn"
        Me.NominalLengthDataGridViewTextBoxColumn.ReadOnly = True
        Me.NominalLengthDataGridViewTextBoxColumn.Visible = False
        '
        'AddAccessoryDataGridViewTextBoxColumn
        '
        Me.AddAccessoryDataGridViewTextBoxColumn.DataPropertyName = "AddAccessory"
        Me.AddAccessoryDataGridViewTextBoxColumn.HeaderText = "AddAccessory"
        Me.AddAccessoryDataGridViewTextBoxColumn.Name = "AddAccessoryDataGridViewTextBoxColumn"
        Me.AddAccessoryDataGridViewTextBoxColumn.ReadOnly = True
        Me.AddAccessoryDataGridViewTextBoxColumn.Visible = False
        '
        'PreferredVendorDataGridViewTextBoxColumn
        '
        Me.PreferredVendorDataGridViewTextBoxColumn.DataPropertyName = "PreferredVendor"
        Me.PreferredVendorDataGridViewTextBoxColumn.HeaderText = "PreferredVendor"
        Me.PreferredVendorDataGridViewTextBoxColumn.Name = "PreferredVendorDataGridViewTextBoxColumn"
        Me.PreferredVendorDataGridViewTextBoxColumn.ReadOnly = True
        Me.PreferredVendorDataGridViewTextBoxColumn.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.txtCalculatedMultiplier)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.txtGrossMargin)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(339, 435)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(277, 275)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Calculate Item Muliplier"
        '
        'Label24
        '
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(17, 209)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(228, 30)
        Me.Label24.TabIndex = 32
        Me.Label24.Text = "Multiplier times the Unit Cost will determine the Price Level with the desired ma" & _
            "rgin."
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCalculatedMultiplier
        '
        Me.txtCalculatedMultiplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCalculatedMultiplier.Location = New System.Drawing.Point(146, 158)
        Me.txtCalculatedMultiplier.Name = "txtCalculatedMultiplier"
        Me.txtCalculatedMultiplier.Size = New System.Drawing.Size(117, 20)
        Me.txtCalculatedMultiplier.TabIndex = 27
        '
        'Label23
        '
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(14, 95)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(231, 30)
        Me.Label23.TabIndex = 30
        Me.Label23.Text = "Enter desired margin as a decimal to determine what the multiplier is."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearForm.Location = New System.Drawing.Point(734, 771)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearForm.TabIndex = 29
        Me.cmdClearForm.Text = "Clear Form"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'InventoryPriceLevels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.dgvItemList)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxPartNumberData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InventoryPriceLevels"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Price Levels"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxPartNumberData.ResumeLayout(False)
        Me.gpxPartNumberData.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxPartNumberData As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cmdUpdateLevels As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateBase As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLastPurchaseCost As System.Windows.Forms.TextBox
    Friend WithEvents txtPriceLevel3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPriceLevel5 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtGrossMargin As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMultiplier1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBaseCost As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPriceLevel4 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPriceLevel2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPriceLevel1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMultiplier5 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMultiplier4 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMultiplier3 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMultiplier2 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtItemMultiplier5 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtItemMultiplier4 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtItemMultiplier3 As System.Windows.Forms.TextBox
    Friend WithEvents txtItemMultiplier1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtItemMultiplier2 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents cmdUpdateItemClass As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtCalculatedMultiplier As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents chkUpdateStandard As System.Windows.Forms.CheckBox
    Friend WithEvents ItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchProdLineIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesProdLineIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxCountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletCountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardCostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardPriceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OldPartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinimumStockDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaximumStockDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeginningBalanceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalDiameterDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalLengthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddAccessoryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreferredVendorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdClearForm As System.Windows.Forms.Button
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
