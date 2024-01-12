<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelCoils
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewCoilsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddNewCoilDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseCoilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintCoilTagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxInventorySPL = New System.Windows.Forms.GroupBox
        Me.chkShowAllTypes = New System.Windows.Forms.CheckBox
        Me.txtInventoryID = New System.Windows.Forms.TextBox
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.cboAnnealingLot = New System.Windows.Forms.ComboBox
        Me.AnnealingLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDespatchNumber = New System.Windows.Forms.ComboBox
        Me.CharterSteelCoilIdentificationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.SteelPurchaseOrderHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCoilID = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvSteelCoils = New System.Windows.Forms.DataGridView
        Me.CoilIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LocationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AnnealLotColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DespatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiveDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTotalWeight = New System.Windows.Forms.TextBox
        Me.txtTotalCoils = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdPrintCoilTag = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.CharterSteelCoilIdentificationTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.AnnealingLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AnnealingLogTableAdapter
        Me.SteelPurchaseOrderHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTextSearch = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxInventorySPL.SuspendLayout()
        CType(Me.AnnealingLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelCoils, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewCoilsToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ViewCoilsToolStripMenuItem
        '
        Me.ViewCoilsToolStripMenuItem.Name = "ViewCoilsToolStripMenuItem"
        Me.ViewCoilsToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ViewCoilsToolStripMenuItem.Text = "View Coils"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewCoilDataToolStripMenuItem, Me.CloseCoilToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'AddNewCoilDataToolStripMenuItem
        '
        Me.AddNewCoilDataToolStripMenuItem.Name = "AddNewCoilDataToolStripMenuItem"
        Me.AddNewCoilDataToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.AddNewCoilDataToolStripMenuItem.Text = "Add New Coil Data"
        '
        'CloseCoilToolStripMenuItem
        '
        Me.CloseCoilToolStripMenuItem.Name = "CloseCoilToolStripMenuItem"
        Me.CloseCoilToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.CloseCoilToolStripMenuItem.Text = "Close Coil"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem, Me.PrintCoilTagToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
        '
        'PrintCoilTagToolStripMenuItem
        '
        Me.PrintCoilTagToolStripMenuItem.Name = "PrintCoilTagToolStripMenuItem"
        Me.PrintCoilTagToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PrintCoilTagToolStripMenuItem.Text = "Print Coil Tag"
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
        'gpxInventorySPL
        '
        Me.gpxInventorySPL.Controls.Add(Me.txtTextSearch)
        Me.gpxInventorySPL.Controls.Add(Me.Label19)
        Me.gpxInventorySPL.Controls.Add(Me.chkShowAllTypes)
        Me.gpxInventorySPL.Controls.Add(Me.txtInventoryID)
        Me.gpxInventorySPL.Controls.Add(Me.txtLocation)
        Me.gpxInventorySPL.Controls.Add(Me.cboAnnealingLot)
        Me.gpxInventorySPL.Controls.Add(Me.cboDespatchNumber)
        Me.gpxInventorySPL.Controls.Add(Me.cboStatus)
        Me.gpxInventorySPL.Controls.Add(Me.cboSteelSize)
        Me.gpxInventorySPL.Controls.Add(Me.cboPONumber)
        Me.gpxInventorySPL.Controls.Add(Me.cboHeatNumber)
        Me.gpxInventorySPL.Controls.Add(Me.Label16)
        Me.gpxInventorySPL.Controls.Add(Me.Label15)
        Me.gpxInventorySPL.Controls.Add(Me.Label4)
        Me.gpxInventorySPL.Controls.Add(Me.Label3)
        Me.gpxInventorySPL.Controls.Add(Me.cboCoilID)
        Me.gpxInventorySPL.Controls.Add(Me.Label2)
        Me.gpxInventorySPL.Controls.Add(Me.dtpEndDate)
        Me.gpxInventorySPL.Controls.Add(Me.dtpBeginDate)
        Me.gpxInventorySPL.Controls.Add(Me.Label14)
        Me.gpxInventorySPL.Controls.Add(Me.chkDateRange)
        Me.gpxInventorySPL.Controls.Add(Me.Label10)
        Me.gpxInventorySPL.Controls.Add(Me.Label9)
        Me.gpxInventorySPL.Controls.Add(Me.Label1)
        Me.gpxInventorySPL.Controls.Add(Me.Label12)
        Me.gpxInventorySPL.Controls.Add(Me.cboCarbon)
        Me.gpxInventorySPL.Controls.Add(Me.Label5)
        Me.gpxInventorySPL.Controls.Add(Me.cmdClear)
        Me.gpxInventorySPL.Controls.Add(Me.Label6)
        Me.gpxInventorySPL.Controls.Add(Me.Label8)
        Me.gpxInventorySPL.Controls.Add(Me.cmdView)
        Me.gpxInventorySPL.Controls.Add(Me.Label7)
        Me.gpxInventorySPL.Location = New System.Drawing.Point(29, 41)
        Me.gpxInventorySPL.Name = "gpxInventorySPL"
        Me.gpxInventorySPL.Size = New System.Drawing.Size(300, 772)
        Me.gpxInventorySPL.TabIndex = 1
        Me.gpxInventorySPL.TabStop = False
        Me.gpxInventorySPL.Text = "View By Filter"
        '
        'chkShowAllTypes
        '
        Me.chkShowAllTypes.AutoSize = True
        Me.chkShowAllTypes.Location = New System.Drawing.Point(95, 156)
        Me.chkShowAllTypes.Name = "chkShowAllTypes"
        Me.chkShowAllTypes.Size = New System.Drawing.Size(94, 17)
        Me.chkShowAllTypes.TabIndex = 2
        Me.chkShowAllTypes.Text = "Show all types"
        Me.chkShowAllTypes.UseVisualStyleBackColor = True
        '
        'txtInventoryID
        '
        Me.txtInventoryID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInventoryID.Location = New System.Drawing.Point(94, 546)
        Me.txtInventoryID.Margin = New System.Windows.Forms.Padding(5)
        Me.txtInventoryID.Name = "txtInventoryID"
        Me.txtInventoryID.Size = New System.Drawing.Size(190, 20)
        Me.txtInventoryID.TabIndex = 11
        '
        'txtLocation
        '
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocation.Location = New System.Drawing.Point(94, 505)
        Me.txtLocation.Margin = New System.Windows.Forms.Padding(5)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(190, 20)
        Me.txtLocation.TabIndex = 10
        '
        'cboAnnealingLot
        '
        Me.cboAnnealingLot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAnnealingLot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAnnealingLot.DataSource = Me.AnnealingLogBindingSource
        Me.cboAnnealingLot.DisplayMember = "AnnealLotNumber"
        Me.cboAnnealingLot.DropDownWidth = 250
        Me.cboAnnealingLot.FormattingEnabled = True
        Me.cboAnnealingLot.Location = New System.Drawing.Point(94, 422)
        Me.cboAnnealingLot.Margin = New System.Windows.Forms.Padding(5)
        Me.cboAnnealingLot.Name = "cboAnnealingLot"
        Me.cboAnnealingLot.Size = New System.Drawing.Size(190, 21)
        Me.cboAnnealingLot.TabIndex = 8
        '
        'AnnealingLogBindingSource
        '
        Me.AnnealingLogBindingSource.DataMember = "AnnealingLog"
        Me.AnnealingLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboDespatchNumber
        '
        Me.cboDespatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDespatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDespatchNumber.DataSource = Me.CharterSteelCoilIdentificationBindingSource
        Me.cboDespatchNumber.DisplayMember = "DespatchNumber"
        Me.cboDespatchNumber.DropDownWidth = 250
        Me.cboDespatchNumber.FormattingEnabled = True
        Me.cboDespatchNumber.Location = New System.Drawing.Point(94, 383)
        Me.cboDespatchNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboDespatchNumber.Name = "cboDespatchNumber"
        Me.cboDespatchNumber.Size = New System.Drawing.Size(190, 21)
        Me.cboDespatchNumber.TabIndex = 7
        '
        'CharterSteelCoilIdentificationBindingSource
        '
        Me.CharterSteelCoilIdentificationBindingSource.DataMember = "CharterSteelCoilIdentification"
        Me.CharterSteelCoilIdentificationBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.DropDownWidth = 250
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "RAW", "WIP", "CLOSED"})
        Me.cboStatus.Location = New System.Drawing.Point(94, 463)
        Me.cboStatus.Margin = New System.Windows.Forms.Padding(5)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(190, 21)
        Me.cboStatus.TabIndex = 9
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.DropDownWidth = 300
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(95, 191)
        Me.cboSteelSize.Margin = New System.Windows.Forms.Padding(5)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(190, 21)
        Me.cboSteelSize.TabIndex = 3
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.SteelPurchaseOrderHeaderBindingSource
        Me.cboPONumber.DisplayMember = "SteelPurchaseOrderKey"
        Me.cboPONumber.DropDownWidth = 250
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(94, 344)
        Me.cboPONumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(190, 21)
        Me.cboPONumber.TabIndex = 6
        '
        'SteelPurchaseOrderHeaderBindingSource
        '
        Me.SteelPurchaseOrderHeaderBindingSource.DataMember = "SteelPurchaseOrderHeader"
        Me.SteelPurchaseOrderHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatNumber.DisplayMember = "HeatNumber"
        Me.cboHeatNumber.DropDownWidth = 250
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(95, 230)
        Me.cboHeatNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(190, 21)
        Me.cboHeatNumber.TabIndex = 4
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(14, 547)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(102, 20)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "Inventory ID"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(14, 505)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 20)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "Location"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(14, 423)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 20)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Annealing Lot"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 384)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 20)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Despatch #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCoilID
        '
        Me.cboCoilID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCoilID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCoilID.DataSource = Me.CharterSteelCoilIdentificationBindingSource
        Me.cboCoilID.DisplayMember = "CoilID"
        Me.cboCoilID.DropDownWidth = 250
        Me.cboCoilID.FormattingEnabled = True
        Me.cboCoilID.Location = New System.Drawing.Point(20, 74)
        Me.cboCoilID.Margin = New System.Windows.Forms.Padding(5)
        Me.cboCoilID.Name = "cboCoilID"
        Me.cboCoilID.Size = New System.Drawing.Size(265, 21)
        Me.cboCoilID.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Coil ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(104, 683)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpEndDate.TabIndex = 14
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(104, 653)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpBeginDate.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(18, 587)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(266, 33)
        Me.Label14.TabIndex = 65
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(106, 623)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 12
        Me.chkDateRange.TabStop = False
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 683)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "End Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 653)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "Begin Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 464)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 20)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Status"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(15, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(270, 36)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.DropDownWidth = 250
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(95, 117)
        Me.cboCarbon.Margin = New System.Windows.Forms.Padding(5)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(190, 21)
        Me.cboCarbon.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Grade"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 719)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 16
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 345)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 20)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "PO #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 230)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 20)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Heat #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(136, 719)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 40)
        Me.cmdView.TabIndex = 15
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 20)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Size"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(977, 772)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 13
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1054, 772)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvSteelCoils
        '
        Me.dgvSteelCoils.AllowUserToAddRows = False
        Me.dgvSteelCoils.AllowUserToDeleteRows = False
        Me.dgvSteelCoils.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSteelCoils.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSteelCoils.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelCoils.AutoGenerateColumns = False
        Me.dgvSteelCoils.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelCoils.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelCoils.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelCoils.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CoilIDColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.HeatNumberColumn, Me.WeightColumn, Me.LocationColumn, Me.StatusColumn, Me.CommentColumn, Me.PurchaseOrderNumberColumn, Me.AnnealLotColumn, Me.DespatchNumberColumn, Me.ReceiveDateColumn, Me.DescriptionColumn, Me.InventoryIDColumn, Me.LotNumberColumn, Me.SalesOrderNumberColumn})
        Me.dgvSteelCoils.DataSource = Me.CharterSteelCoilIdentificationBindingSource
        Me.dgvSteelCoils.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvSteelCoils.Location = New System.Drawing.Point(349, 41)
        Me.dgvSteelCoils.Name = "dgvSteelCoils"
        Me.dgvSteelCoils.Size = New System.Drawing.Size(781, 665)
        Me.dgvSteelCoils.TabIndex = 28
        Me.dgvSteelCoils.TabStop = False
        '
        'CoilIDColumn
        '
        Me.CoilIDColumn.DataPropertyName = "CoilID"
        Me.CoilIDColumn.HeaderText = "Coil ID"
        Me.CoilIDColumn.Name = "CoilIDColumn"
        Me.CoilIDColumn.ReadOnly = True
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon"
        Me.CarbonColumn.Name = "CarbonColumn"
        Me.CarbonColumn.Width = 80
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.Width = 80
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.Width = 80
        '
        'WeightColumn
        '
        Me.WeightColumn.DataPropertyName = "Weight"
        Me.WeightColumn.HeaderText = "Weight"
        Me.WeightColumn.Name = "WeightColumn"
        Me.WeightColumn.ReadOnly = True
        Me.WeightColumn.Width = 80
        '
        'LocationColumn
        '
        Me.LocationColumn.DataPropertyName = "Location"
        Me.LocationColumn.HeaderText = "Location"
        Me.LocationColumn.Name = "LocationColumn"
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'PurchaseOrderNumberColumn
        '
        Me.PurchaseOrderNumberColumn.DataPropertyName = "PurchaseOrderNumber"
        Me.PurchaseOrderNumberColumn.HeaderText = "PO #"
        Me.PurchaseOrderNumberColumn.Name = "PurchaseOrderNumberColumn"
        Me.PurchaseOrderNumberColumn.ReadOnly = True
        '
        'AnnealLotColumn
        '
        Me.AnnealLotColumn.DataPropertyName = "AnnealLot"
        Me.AnnealLotColumn.HeaderText = "AnnealLot"
        Me.AnnealLotColumn.Name = "AnnealLotColumn"
        '
        'DespatchNumberColumn
        '
        Me.DespatchNumberColumn.DataPropertyName = "DespatchNumber"
        Me.DespatchNumberColumn.HeaderText = "Despatch #"
        Me.DespatchNumberColumn.Name = "DespatchNumberColumn"
        Me.DespatchNumberColumn.ReadOnly = True
        '
        'ReceiveDateColumn
        '
        Me.ReceiveDateColumn.DataPropertyName = "ReceiveDate"
        Me.ReceiveDateColumn.HeaderText = "Date Received"
        Me.ReceiveDateColumn.Name = "ReceiveDateColumn"
        Me.ReceiveDateColumn.ReadOnly = True
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        '
        'InventoryIDColumn
        '
        Me.InventoryIDColumn.DataPropertyName = "InventoryID"
        Me.InventoryIDColumn.HeaderText = "Inventory ID"
        Me.InventoryIDColumn.Name = "InventoryIDColumn"
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        Me.LotNumberColumn.ReadOnly = True
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "SO #"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtTotalWeight)
        Me.GroupBox1.Controls.Add(Me.txtTotalCoils)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(349, 713)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(294, 100)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Steel Totals"
        '
        'txtTotalWeight
        '
        Me.txtTotalWeight.BackColor = System.Drawing.Color.White
        Me.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalWeight.Location = New System.Drawing.Point(108, 57)
        Me.txtTotalWeight.Name = "txtTotalWeight"
        Me.txtTotalWeight.ReadOnly = True
        Me.txtTotalWeight.Size = New System.Drawing.Size(170, 20)
        Me.txtTotalWeight.TabIndex = 1
        Me.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCoils
        '
        Me.txtTotalCoils.BackColor = System.Drawing.Color.White
        Me.txtTotalCoils.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCoils.Location = New System.Drawing.Point(108, 24)
        Me.txtTotalCoils.Name = "txtTotalCoils"
        Me.txtTotalCoils.ReadOnly = True
        Me.txtTotalCoils.Size = New System.Drawing.Size(170, 20)
        Me.txtTotalCoils.TabIndex = 0
        Me.txtTotalCoils.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 20)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "Total Weight"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 20)
        Me.Label11.TabIndex = 70
        Me.Label11.Text = "Total Coils (#)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintCoilTag
        '
        Me.cmdPrintCoilTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintCoilTag.Location = New System.Drawing.Point(900, 772)
        Me.cmdPrintCoilTag.Name = "cmdPrintCoilTag"
        Me.cmdPrintCoilTag.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintCoilTag.TabIndex = 30
        Me.cmdPrintCoilTag.Text = "Print Coil Tag"
        Me.cmdPrintCoilTag.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(761, 713)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(364, 25)
        Me.Label18.TabIndex = 71
        Me.Label18.Text = "Datagrid rows colored blue have a coil comment"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CharterSteelCoilIdentificationTableAdapter
        '
        Me.CharterSteelCoilIdentificationTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'AnnealingLogTableAdapter
        '
        Me.AnnealingLogTableAdapter.ClearBeforeFill = True
        '
        'SteelPurchaseOrderHeaderTableAdapter
        '
        Me.SteelPurchaseOrderHeaderTableAdapter.ClearBeforeFill = True
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(761, 737)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(364, 25)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "Double-click on coil in the datagrid to add a comment or coil location to."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextSearch
        '
        Me.txtTextSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextSearch.Location = New System.Drawing.Point(94, 285)
        Me.txtTextSearch.Margin = New System.Windows.Forms.Padding(5)
        Me.txtTextSearch.Name = "txtTextSearch"
        Me.txtTextSearch.Size = New System.Drawing.Size(190, 20)
        Me.txtTextSearch.TabIndex = 5
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(14, 285)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(102, 20)
        Me.Label19.TabIndex = 77
        Me.Label19.Text = "Text Search"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewSteelCoils
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmdPrintCoilTag)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvSteelCoils)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxInventorySPL)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewSteelCoils"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View Steel Coils"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxInventorySPL.ResumeLayout(False)
        Me.gpxInventorySPL.PerformLayout()
        CType(Me.AnnealingLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CharterSteelCoilIdentificationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelPurchaseOrderHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelCoils, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxInventorySPL As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvSteelCoils As System.Windows.Forms.DataGridView
    Friend WithEvents cboCoilID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDespatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCoils As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboAnnealingLot As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtInventoryID As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintCoilTag As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CharterSteelCoilIdentificationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CharterSteelCoilIdentificationTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CharterSteelCoilIdentificationTableAdapter
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents AnnealingLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AnnealingLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AnnealingLogTableAdapter
    Friend WithEvents SteelPurchaseOrderHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelPurchaseOrderHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelPurchaseOrderHeaderTableAdapter
    Friend WithEvents CoilIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocationColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnnealLotColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DespatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkShowAllTypes As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents AddNewCoilDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseCoilToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewCoilsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintCoilTagToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTextSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
