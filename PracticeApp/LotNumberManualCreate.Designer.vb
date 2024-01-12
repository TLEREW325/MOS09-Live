<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LotNumberManualCreate
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.cboRMID = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.FOXTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdCreateLotNumber = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtNewLotNumber = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.FOXTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.clbHeatFileRecords = New System.Windows.Forms.CheckedListBox
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtFOXAlternativeSteelSize = New System.Windows.Forms.TextBox
        Me.txtFOXAlterativeCarbon = New System.Windows.Forms.TextBox
        Me.txtFOXBoxType = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtFOXCertType = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtFOXBPRevision = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtFOXBlueprintNumber = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtFOXScrapWeight = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtFOXFinishedWeight = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtFOXRawMaterialWeight = New System.Windows.Forms.TextBox
        Me.txtFOXAlternateSteel = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtSteelDateReceived = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtSteelPONumber = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtSteelVendor = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtSteelSizeFromHeat = New System.Windows.Forms.TextBox
        Me.txtSteelCarbonFromHeat = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSteelDescription = New System.Windows.Forms.TextBox
        Me.txtSteelSizeFromRMID = New System.Windows.Forms.TextBox
        Me.txtSteelCarbonFromRMID = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtFOXComment = New System.Windows.Forms.TextBox
        Me.txtPartLongDescription = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtNominalLength = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtItemClass = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.txtNominalDiameter = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.txtPartShortDescription = New System.Windows.Forms.TextBox
        Me.txtPartNumber = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtPalletPieces = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtPalletBoxes = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtBoxCount = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.txtBoxWeight = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtPalletWeight = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.txtPieceWeight = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdTubTag = New System.Windows.Forms.Button
        Me.StockStatusEvaluationTableAdapter1 = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StockStatusEvaluationTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
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
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.cboRMID)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cboPartNumber)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboLotNumber)
        Me.GroupBox1.Controls.Add(Me.cboFOXNumber)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 249)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Load Data"
        '
        'Label38
        '
        Me.Label38.ForeColor = System.Drawing.Color.Red
        Me.Label38.Location = New System.Drawing.Point(71, 187)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(211, 20)
        Me.Label38.TabIndex = 15
        Me.Label38.Text = "OR LOAD DATA BY LOT #"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboRMID
        '
        Me.cboRMID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRMID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRMID.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboRMID.DisplayMember = "RMID"
        Me.cboRMID.FormattingEnabled = True
        Me.cboRMID.Location = New System.Drawing.Point(71, 150)
        Me.cboRMID.Name = "cboRMID"
        Me.cboRMID.Size = New System.Drawing.Size(212, 21)
        Me.cboRMID.TabIndex = 11
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
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(13, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "RMID"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(71, 112)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(212, 21)
        Me.cboPartNumber.TabIndex = 9
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Part #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.DataSource = Me.LotNumberBindingSource
        Me.cboLotNumber.DisplayMember = "LotNumber"
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(71, 212)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(212, 21)
        Me.cboLotNumber.TabIndex = 9
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.DataSource = Me.FOXTableBindingSource
        Me.cboFOXNumber.DisplayMember = "FOXNumber"
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(119, 74)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(164, 21)
        Me.cboFOXNumber.TabIndex = 6
        '
        'FOXTableBindingSource
        '
        Me.FOXTableBindingSource.DataMember = "FOXTable"
        Me.FOXTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "FOX #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 2
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
        Me.cboDivisionID.Location = New System.Drawing.Point(119, 36)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(164, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(13, 212)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Lot #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCreateLotNumber
        '
        Me.cmdCreateLotNumber.Location = New System.Drawing.Point(289, 100)
        Me.cmdCreateLotNumber.Name = "cmdCreateLotNumber"
        Me.cmdCreateLotNumber.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateLotNumber.TabIndex = 13
        Me.cmdCreateLotNumber.Text = "Create"
        Me.cmdCreateLotNumber.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(77, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(283, 39)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Manually type lot # to create."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNewLotNumber
        '
        Me.txtNewLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewLotNumber.Location = New System.Drawing.Point(119, 58)
        Me.txtNewLotNumber.Name = "txtNewLotNumber"
        Me.txtNewLotNumber.Size = New System.Drawing.Size(241, 20)
        Me.txtNewLotNumber.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Lot Number"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatNumber.DisplayMember = "HeatNumber"
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(70, 32)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(212, 21)
        Me.cboHeatNumber.TabIndex = 7
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Heat #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'FOXTableTableAdapter
        '
        Me.FOXTableTableAdapter.ClearBeforeFill = True
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 10
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.clbHeatFileRecords)
        Me.GroupBox2.Controls.Add(Me.cboHeatNumber)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 381)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(299, 430)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Heat Records"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(6, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(287, 23)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Select correct diameter for heat #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'clbHeatFileRecords
        '
        Me.clbHeatFileRecords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clbHeatFileRecords.FormattingEnabled = True
        Me.clbHeatFileRecords.Location = New System.Drawing.Point(6, 104)
        Me.clbHeatFileRecords.Name = "clbHeatFileRecords"
        Me.clbHeatFileRecords.Size = New System.Drawing.Size(287, 317)
        Me.clbHeatFileRecords.TabIndex = 0
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.txtNewLotNumber)
        Me.GroupBox3.Controls.Add(Me.cmdCreateLotNumber)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(750, 600)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(380, 152)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "New Lot Number"
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Blue
        Me.Label40.Location = New System.Drawing.Point(16, 100)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(259, 40)
        Me.Label40.TabIndex = 19
        Me.Label40.Text = "This utility will only create a new lot number - you cannot edit an existing one." & _
            ""
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.txtFOXAlternativeSteelSize)
        Me.GroupBox4.Controls.Add(Me.txtFOXAlterativeCarbon)
        Me.GroupBox4.Controls.Add(Me.txtFOXBoxType)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.txtFOXCertType)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.txtFOXBPRevision)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.txtFOXBlueprintNumber)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.txtFOXScrapWeight)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.txtFOXFinishedWeight)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.txtFOXRawMaterialWeight)
        Me.GroupBox4.Controls.Add(Me.txtFOXAlternateSteel)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Location = New System.Drawing.Point(345, 41)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(380, 339)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "FOX Data"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(9, 88)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(174, 23)
        Me.Label26.TabIndex = 34
        Me.Label26.Text = "Steel Size"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(9, 60)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(174, 23)
        Me.Label25.TabIndex = 33
        Me.Label25.Text = "Carbon / Alloy"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFOXAlternativeSteelSize
        '
        Me.txtFOXAlternativeSteelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXAlternativeSteelSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXAlternativeSteelSize.Location = New System.Drawing.Point(189, 88)
        Me.txtFOXAlternativeSteelSize.Name = "txtFOXAlternativeSteelSize"
        Me.txtFOXAlternativeSteelSize.Size = New System.Drawing.Size(175, 20)
        Me.txtFOXAlternativeSteelSize.TabIndex = 32
        Me.txtFOXAlternativeSteelSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFOXAlterativeCarbon
        '
        Me.txtFOXAlterativeCarbon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXAlterativeCarbon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXAlterativeCarbon.Location = New System.Drawing.Point(189, 60)
        Me.txtFOXAlterativeCarbon.Name = "txtFOXAlterativeCarbon"
        Me.txtFOXAlterativeCarbon.Size = New System.Drawing.Size(175, 20)
        Me.txtFOXAlterativeCarbon.TabIndex = 31
        Me.txtFOXAlterativeCarbon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFOXBoxType
        '
        Me.txtFOXBoxType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXBoxType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXBoxType.Location = New System.Drawing.Point(96, 299)
        Me.txtFOXBoxType.Name = "txtFOXBoxType"
        Me.txtFOXBoxType.Size = New System.Drawing.Size(268, 20)
        Me.txtFOXBoxType.TabIndex = 30
        Me.txtFOXBoxType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(9, 299)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(174, 23)
        Me.Label23.TabIndex = 29
        Me.Label23.Text = "Box Type"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFOXCertType
        '
        Me.txtFOXCertType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXCertType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXCertType.Location = New System.Drawing.Point(189, 271)
        Me.txtFOXCertType.Name = "txtFOXCertType"
        Me.txtFOXCertType.Size = New System.Drawing.Size(175, 20)
        Me.txtFOXCertType.TabIndex = 28
        Me.txtFOXCertType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(9, 267)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(174, 23)
        Me.Label24.TabIndex = 27
        Me.Label24.Text = "Certification Type"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFOXBPRevision
        '
        Me.txtFOXBPRevision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXBPRevision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXBPRevision.Location = New System.Drawing.Point(189, 243)
        Me.txtFOXBPRevision.Name = "txtFOXBPRevision"
        Me.txtFOXBPRevision.Size = New System.Drawing.Size(175, 20)
        Me.txtFOXBPRevision.TabIndex = 26
        Me.txtFOXBPRevision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(9, 239)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(174, 23)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "Blueprint Revision"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFOXBlueprintNumber
        '
        Me.txtFOXBlueprintNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXBlueprintNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXBlueprintNumber.Location = New System.Drawing.Point(189, 215)
        Me.txtFOXBlueprintNumber.Name = "txtFOXBlueprintNumber"
        Me.txtFOXBlueprintNumber.Size = New System.Drawing.Size(175, 20)
        Me.txtFOXBlueprintNumber.TabIndex = 24
        Me.txtFOXBlueprintNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(9, 211)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(174, 23)
        Me.Label21.TabIndex = 23
        Me.Label21.Text = "Blueprint #"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFOXScrapWeight
        '
        Me.txtFOXScrapWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXScrapWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXScrapWeight.Location = New System.Drawing.Point(189, 159)
        Me.txtFOXScrapWeight.Name = "txtFOXScrapWeight"
        Me.txtFOXScrapWeight.Size = New System.Drawing.Size(175, 20)
        Me.txtFOXScrapWeight.TabIndex = 22
        Me.txtFOXScrapWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(9, 155)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(174, 23)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "Scrap Weight"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFOXFinishedWeight
        '
        Me.txtFOXFinishedWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXFinishedWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXFinishedWeight.Location = New System.Drawing.Point(189, 187)
        Me.txtFOXFinishedWeight.Name = "txtFOXFinishedWeight"
        Me.txtFOXFinishedWeight.Size = New System.Drawing.Size(175, 20)
        Me.txtFOXFinishedWeight.TabIndex = 20
        Me.txtFOXFinishedWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(9, 183)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(174, 23)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "Finish Weight"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFOXRawMaterialWeight
        '
        Me.txtFOXRawMaterialWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXRawMaterialWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXRawMaterialWeight.Location = New System.Drawing.Point(189, 131)
        Me.txtFOXRawMaterialWeight.Name = "txtFOXRawMaterialWeight"
        Me.txtFOXRawMaterialWeight.Size = New System.Drawing.Size(175, 20)
        Me.txtFOXRawMaterialWeight.TabIndex = 18
        Me.txtFOXRawMaterialWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFOXAlternateSteel
        '
        Me.txtFOXAlternateSteel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXAlternateSteel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXAlternateSteel.Location = New System.Drawing.Point(96, 32)
        Me.txtFOXAlternateSteel.Name = "txtFOXAlternateSteel"
        Me.txtFOXAlternateSteel.Size = New System.Drawing.Size(268, 20)
        Me.txtFOXAlternateSteel.TabIndex = 17
        Me.txtFOXAlternateSteel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(9, 127)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(174, 23)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Raw Material Weight"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(9, 32)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(174, 23)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "Alternate Steel"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtSteelDateReceived)
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.Controls.Add(Me.txtSteelPONumber)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.txtSteelVendor)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.txtSteelSizeFromHeat)
        Me.GroupBox5.Controls.Add(Me.txtSteelCarbonFromHeat)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.txtSteelDescription)
        Me.GroupBox5.Controls.Add(Me.txtSteelSizeFromRMID)
        Me.GroupBox5.Controls.Add(Me.txtSteelCarbonFromRMID)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Location = New System.Drawing.Point(345, 386)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(380, 425)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Steel Data"
        '
        'txtSteelDateReceived
        '
        Me.txtSteelDateReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelDateReceived.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelDateReceived.Location = New System.Drawing.Point(189, 390)
        Me.txtSteelDateReceived.Name = "txtSteelDateReceived"
        Me.txtSteelDateReceived.Size = New System.Drawing.Size(175, 20)
        Me.txtSteelDateReceived.TabIndex = 34
        Me.txtSteelDateReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(15, 390)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(168, 23)
        Me.Label27.TabIndex = 33
        Me.Label27.Text = "Date Received"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelPONumber
        '
        Me.txtSteelPONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelPONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelPONumber.Location = New System.Drawing.Point(189, 362)
        Me.txtSteelPONumber.Name = "txtSteelPONumber"
        Me.txtSteelPONumber.Size = New System.Drawing.Size(175, 20)
        Me.txtSteelPONumber.TabIndex = 32
        Me.txtSteelPONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(15, 362)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(168, 23)
        Me.Label28.TabIndex = 31
        Me.Label28.Text = "Steel PO #"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelVendor
        '
        Me.txtSteelVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelVendor.Location = New System.Drawing.Point(127, 334)
        Me.txtSteelVendor.Name = "txtSteelVendor"
        Me.txtSteelVendor.Size = New System.Drawing.Size(237, 20)
        Me.txtSteelVendor.TabIndex = 30
        Me.txtSteelVendor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(15, 334)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(168, 23)
        Me.Label29.TabIndex = 29
        Me.Label29.Text = "Steel Vendor"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(6, 226)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(358, 23)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Steel Data From the Heat Record"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSteelSizeFromHeat
        '
        Me.txtSteelSizeFromHeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelSizeFromHeat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelSizeFromHeat.Location = New System.Drawing.Point(127, 288)
        Me.txtSteelSizeFromHeat.Name = "txtSteelSizeFromHeat"
        Me.txtSteelSizeFromHeat.Size = New System.Drawing.Size(237, 20)
        Me.txtSteelSizeFromHeat.TabIndex = 20
        Me.txtSteelSizeFromHeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSteelCarbonFromHeat
        '
        Me.txtSteelCarbonFromHeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelCarbonFromHeat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelCarbonFromHeat.Location = New System.Drawing.Point(127, 262)
        Me.txtSteelCarbonFromHeat.Name = "txtSteelCarbonFromHeat"
        Me.txtSteelCarbonFromHeat.Size = New System.Drawing.Size(237, 20)
        Me.txtSteelCarbonFromHeat.TabIndex = 19
        Me.txtSteelCarbonFromHeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(15, 288)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 23)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Steel Size"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(15, 259)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 23)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Steel Carbon / Alloy"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(12, 91)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 23)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Steel Description"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSteelDescription
        '
        Me.txtSteelDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelDescription.Location = New System.Drawing.Point(9, 117)
        Me.txtSteelDescription.Multiline = True
        Me.txtSteelDescription.Name = "txtSteelDescription"
        Me.txtSteelDescription.Size = New System.Drawing.Size(355, 88)
        Me.txtSteelDescription.TabIndex = 15
        Me.txtSteelDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSteelSizeFromRMID
        '
        Me.txtSteelSizeFromRMID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelSizeFromRMID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelSizeFromRMID.Location = New System.Drawing.Point(127, 58)
        Me.txtSteelSizeFromRMID.Name = "txtSteelSizeFromRMID"
        Me.txtSteelSizeFromRMID.Size = New System.Drawing.Size(237, 20)
        Me.txtSteelSizeFromRMID.TabIndex = 14
        Me.txtSteelSizeFromRMID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSteelCarbonFromRMID
        '
        Me.txtSteelCarbonFromRMID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelCarbonFromRMID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSteelCarbonFromRMID.Location = New System.Drawing.Point(127, 32)
        Me.txtSteelCarbonFromRMID.Name = "txtSteelCarbonFromRMID"
        Me.txtSteelCarbonFromRMID.Size = New System.Drawing.Size(237, 20)
        Me.txtSteelCarbonFromRMID.TabIndex = 13
        Me.txtSteelCarbonFromRMID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(12, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 23)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Steel Size"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(12, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 23)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Steel Carbon / Alloy"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtFOXComment)
        Me.GroupBox6.Controls.Add(Me.txtPartLongDescription)
        Me.GroupBox6.Controls.Add(Me.Label39)
        Me.GroupBox6.Controls.Add(Me.txtNominalLength)
        Me.GroupBox6.Controls.Add(Me.Label41)
        Me.GroupBox6.Controls.Add(Me.txtItemClass)
        Me.GroupBox6.Controls.Add(Me.Label42)
        Me.GroupBox6.Controls.Add(Me.txtNominalDiameter)
        Me.GroupBox6.Controls.Add(Me.Label43)
        Me.GroupBox6.Controls.Add(Me.txtPartShortDescription)
        Me.GroupBox6.Controls.Add(Me.txtPartNumber)
        Me.GroupBox6.Controls.Add(Me.Label30)
        Me.GroupBox6.Controls.Add(Me.Label31)
        Me.GroupBox6.Controls.Add(Me.txtPalletPieces)
        Me.GroupBox6.Controls.Add(Me.Label32)
        Me.GroupBox6.Controls.Add(Me.txtPalletBoxes)
        Me.GroupBox6.Controls.Add(Me.Label33)
        Me.GroupBox6.Controls.Add(Me.txtBoxCount)
        Me.GroupBox6.Controls.Add(Me.Label34)
        Me.GroupBox6.Controls.Add(Me.txtBoxWeight)
        Me.GroupBox6.Controls.Add(Me.Label35)
        Me.GroupBox6.Controls.Add(Me.txtPalletWeight)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.txtPieceWeight)
        Me.GroupBox6.Controls.Add(Me.Label37)
        Me.GroupBox6.Location = New System.Drawing.Point(750, 41)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(380, 550)
        Me.GroupBox6.TabIndex = 17
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Part Data"
        '
        'txtFOXComment
        '
        Me.txtFOXComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFOXComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFOXComment.Location = New System.Drawing.Point(16, 444)
        Me.txtFOXComment.Multiline = True
        Me.txtFOXComment.Name = "txtFOXComment"
        Me.txtFOXComment.Size = New System.Drawing.Size(352, 90)
        Me.txtFOXComment.TabIndex = 63
        Me.txtFOXComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartLongDescription
        '
        Me.txtPartLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartLongDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartLongDescription.Location = New System.Drawing.Point(16, 88)
        Me.txtPartLongDescription.Multiline = True
        Me.txtPartLongDescription.Name = "txtPartLongDescription"
        Me.txtPartLongDescription.Size = New System.Drawing.Size(352, 63)
        Me.txtPartLongDescription.TabIndex = 62
        Me.txtPartLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(13, 418)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(174, 23)
        Me.Label39.TabIndex = 59
        Me.Label39.Text = "Comment (from the FOX)"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNominalLength
        '
        Me.txtNominalLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNominalLength.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNominalLength.Location = New System.Drawing.Point(193, 358)
        Me.txtNominalLength.Name = "txtNominalLength"
        Me.txtNominalLength.Size = New System.Drawing.Size(175, 20)
        Me.txtNominalLength.TabIndex = 56
        Me.txtNominalLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(13, 358)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(174, 23)
        Me.Label41.TabIndex = 55
        Me.Label41.Text = "Nominal Length"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtItemClass
        '
        Me.txtItemClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemClass.Location = New System.Drawing.Point(193, 386)
        Me.txtItemClass.Name = "txtItemClass"
        Me.txtItemClass.Size = New System.Drawing.Size(175, 20)
        Me.txtItemClass.TabIndex = 54
        Me.txtItemClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(13, 386)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(174, 23)
        Me.Label42.TabIndex = 53
        Me.Label42.Text = "Item Class"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNominalDiameter
        '
        Me.txtNominalDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNominalDiameter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNominalDiameter.Location = New System.Drawing.Point(193, 330)
        Me.txtNominalDiameter.Name = "txtNominalDiameter"
        Me.txtNominalDiameter.Size = New System.Drawing.Size(175, 20)
        Me.txtNominalDiameter.TabIndex = 52
        Me.txtNominalDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(13, 330)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(174, 23)
        Me.Label43.TabIndex = 51
        Me.Label43.Text = "Nominal Diameter"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartShortDescription
        '
        Me.txtPartShortDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartShortDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartShortDescription.Location = New System.Drawing.Point(85, 57)
        Me.txtPartShortDescription.Name = "txtPartShortDescription"
        Me.txtPartShortDescription.Size = New System.Drawing.Size(283, 20)
        Me.txtPartShortDescription.TabIndex = 48
        Me.txtPartShortDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPartNumber
        '
        Me.txtPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(85, 29)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(283, 20)
        Me.txtPartNumber.TabIndex = 47
        Me.txtPartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(13, 57)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(174, 23)
        Me.Label30.TabIndex = 50
        Me.Label30.Text = "Description"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(13, 29)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(174, 23)
        Me.Label31.TabIndex = 49
        Me.Label31.Text = "Part #"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPalletPieces
        '
        Me.txtPalletPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletPieces.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPalletPieces.Location = New System.Drawing.Point(193, 302)
        Me.txtPalletPieces.Name = "txtPalletPieces"
        Me.txtPalletPieces.Size = New System.Drawing.Size(175, 20)
        Me.txtPalletPieces.TabIndex = 46
        Me.txtPalletPieces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(13, 302)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(174, 23)
        Me.Label32.TabIndex = 45
        Me.Label32.Text = "Pallet Count (Pieces)"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPalletBoxes
        '
        Me.txtPalletBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletBoxes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPalletBoxes.Location = New System.Drawing.Point(193, 274)
        Me.txtPalletBoxes.Name = "txtPalletBoxes"
        Me.txtPalletBoxes.Size = New System.Drawing.Size(175, 20)
        Me.txtPalletBoxes.TabIndex = 44
        Me.txtPalletBoxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(13, 274)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(174, 23)
        Me.Label33.TabIndex = 43
        Me.Label33.Text = "Pallet Count (Boxes)"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxCount
        '
        Me.txtBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxCount.Location = New System.Drawing.Point(193, 246)
        Me.txtBoxCount.Name = "txtBoxCount"
        Me.txtBoxCount.Size = New System.Drawing.Size(175, 20)
        Me.txtBoxCount.TabIndex = 42
        Me.txtBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(13, 246)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(174, 23)
        Me.Label34.TabIndex = 41
        Me.Label34.Text = "Box Count"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxWeight
        '
        Me.txtBoxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxWeight.Location = New System.Drawing.Point(193, 190)
        Me.txtBoxWeight.Name = "txtBoxWeight"
        Me.txtBoxWeight.Size = New System.Drawing.Size(175, 20)
        Me.txtBoxWeight.TabIndex = 40
        Me.txtBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(13, 190)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(174, 23)
        Me.Label35.TabIndex = 39
        Me.Label35.Text = "Box Weight"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPalletWeight
        '
        Me.txtPalletWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPalletWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPalletWeight.Location = New System.Drawing.Point(193, 218)
        Me.txtPalletWeight.Name = "txtPalletWeight"
        Me.txtPalletWeight.Size = New System.Drawing.Size(175, 20)
        Me.txtPalletWeight.TabIndex = 38
        Me.txtPalletWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(13, 218)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(174, 23)
        Me.Label36.TabIndex = 37
        Me.Label36.Text = "Pallet Weight"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPieceWeight
        '
        Me.txtPieceWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPieceWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPieceWeight.Location = New System.Drawing.Point(193, 162)
        Me.txtPieceWeight.Name = "txtPieceWeight"
        Me.txtPieceWeight.Size = New System.Drawing.Size(175, 20)
        Me.txtPieceWeight.TabIndex = 36
        Me.txtPieceWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(13, 162)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(174, 23)
        Me.Label37.TabIndex = 35
        Me.Label37.Text = "Piece Weight"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(42, 293)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(269, 75)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Select fields (FOX, Heat #, RMID, etc., or select an existing Lot Number to creat" & _
            "e a new Lot Number. The Lot # you are trying to create cannot already exist in t" & _
            "he database."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(982, 772)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 19
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdTubTag
        '
        Me.cmdTubTag.Location = New System.Drawing.Point(750, 771)
        Me.cmdTubTag.Name = "cmdTubTag"
        Me.cmdTubTag.Size = New System.Drawing.Size(71, 40)
        Me.cmdTubTag.TabIndex = 20
        Me.cmdTubTag.Text = "Tub Tag"
        Me.cmdTubTag.UseVisualStyleBackColor = True
        '
        'StockStatusEvaluationTableAdapter1
        '
        Me.StockStatusEvaluationTableAdapter1.ClearBeforeFill = True
        '
        'LotNumberManualCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdTubTag)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "LotNumberManualCreate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Create Lot # Manually"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
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
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents FOXTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOXTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboRMID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNewLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdCreateLotNumber As System.Windows.Forms.Button
    Friend WithEvents clbHeatFileRecords As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSteelSizeFromHeat As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelCarbonFromHeat As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSteelDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelSizeFromRMID As System.Windows.Forms.TextBox
    Friend WithEvents txtSteelCarbonFromRMID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdTubTag As System.Windows.Forms.Button
    Friend WithEvents txtFOXBPRevision As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtFOXBlueprintNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtFOXScrapWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtFOXFinishedWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtFOXRawMaterialWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtFOXAlternateSteel As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtFOXAlternativeSteelSize As System.Windows.Forms.TextBox
    Friend WithEvents txtFOXAlterativeCarbon As System.Windows.Forms.TextBox
    Friend WithEvents txtFOXBoxType As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtFOXCertType As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtSteelDateReceived As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtSteelPONumber As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtSteelVendor As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtPartLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtNominalLength As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtItemClass As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtNominalDiameter As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtPartShortDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtPalletPieces As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtPalletBoxes As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtBoxCount As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtBoxWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtPalletWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtPieceWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtFOXComment As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents StockStatusEvaluationTableAdapter1 As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StockStatusEvaluationTableAdapter
End Class
