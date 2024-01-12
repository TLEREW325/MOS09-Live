<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewLotNumbers
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadOutsideCertificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadOutsideCertificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewOutsideCertificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxViewLotNumbers = New System.Windows.Forms.GroupBox
        Me.cboHeatFileNumber = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.chkInspectedParts = New System.Windows.Forms.CheckBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtHeadMarking = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboVendorName = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtSteelSize = New System.Windows.Forms.TextBox
        Me.txtCarbon = New System.Windows.Forms.TextBox
        Me.cboSteelVendor = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtBlueprintNumber = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.FOXTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.FOXTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdOpenLotNumber = New System.Windows.Forms.Button
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.dgvLotNumber = New System.Windows.Forms.DataGridView
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlueprintNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletCountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalDiameterColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalLengthColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertificationTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FluxLoadNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AnnealedHeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeadMarkingColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QCInspectedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QCInspectorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelVendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelPONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RawMaterialWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ScrapWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FinishedWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreationDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LongDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrintTubPage = New System.Windows.Forms.Button
        Me.cmdPrintTubTag = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CRTubTag = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CRXTubtag1 = New MOS09Program.CRXTubtag
        Me.MenuStrip1.SuspendLayout()
        Me.gpxViewLotNumbers.SuspendLayout()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLotNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintListingToolStripMenuItem, Me.UploadOutsideCertificationToolStripMenuItem, Me.ReUploadOutsideCertificationToolStripMenuItem, Me.ViewOutsideCertificationToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintListingToolStripMenuItem
        '
        Me.PrintListingToolStripMenuItem.Name = "PrintListingToolStripMenuItem"
        Me.PrintListingToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.PrintListingToolStripMenuItem.Text = "Print Listing"
        '
        'UploadOutsideCertificationToolStripMenuItem
        '
        Me.UploadOutsideCertificationToolStripMenuItem.Enabled = False
        Me.UploadOutsideCertificationToolStripMenuItem.Name = "UploadOutsideCertificationToolStripMenuItem"
        Me.UploadOutsideCertificationToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.UploadOutsideCertificationToolStripMenuItem.Text = "Upload Outside Certification"
        '
        'ReUploadOutsideCertificationToolStripMenuItem
        '
        Me.ReUploadOutsideCertificationToolStripMenuItem.Enabled = False
        Me.ReUploadOutsideCertificationToolStripMenuItem.Name = "ReUploadOutsideCertificationToolStripMenuItem"
        Me.ReUploadOutsideCertificationToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ReUploadOutsideCertificationToolStripMenuItem.Text = "Re-Upload Outside Certification"
        '
        'ViewOutsideCertificationToolStripMenuItem
        '
        Me.ViewOutsideCertificationToolStripMenuItem.Enabled = False
        Me.ViewOutsideCertificationToolStripMenuItem.Name = "ViewOutsideCertificationToolStripMenuItem"
        Me.ViewOutsideCertificationToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ViewOutsideCertificationToolStripMenuItem.Text = "View Outside Certification"
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
        'gpxViewLotNumbers
        '
        Me.gpxViewLotNumbers.Controls.Add(Me.cboHeatFileNumber)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label13)
        Me.gpxViewLotNumbers.Controls.Add(Me.chkInspectedParts)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboStatus)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label11)
        Me.gpxViewLotNumbers.Controls.Add(Me.txtHeadMarking)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label9)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboVendorName)
        Me.gpxViewLotNumbers.Controls.Add(Me.txtSteelSize)
        Me.gpxViewLotNumbers.Controls.Add(Me.txtCarbon)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboSteelVendor)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label6)
        Me.gpxViewLotNumbers.Controls.Add(Me.txtBlueprintNumber)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label4)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label12)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboFOXNumber)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboPartDescription)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label2)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboPartNumber)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboDivisionID)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboLotNumber)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboHeatNumber)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label3)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label5)
        Me.gpxViewLotNumbers.Controls.Add(Me.cmdClear)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label10)
        Me.gpxViewLotNumbers.Controls.Add(Me.cmdViewByFilters)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label7)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label1)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label8)
        Me.gpxViewLotNumbers.Location = New System.Drawing.Point(29, 41)
        Me.gpxViewLotNumbers.Name = "gpxViewLotNumbers"
        Me.gpxViewLotNumbers.Size = New System.Drawing.Size(300, 773)
        Me.gpxViewLotNumbers.TabIndex = 0
        Me.gpxViewLotNumbers.TabStop = False
        Me.gpxViewLotNumbers.Text = "View By Filters"
        '
        'cboHeatFileNumber
        '
        Me.cboHeatFileNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatFileNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatFileNumber.FormattingEnabled = True
        Me.cboHeatFileNumber.Location = New System.Drawing.Point(96, 476)
        Me.cboHeatFileNumber.Margin = New System.Windows.Forms.Padding(10)
        Me.cboHeatFileNumber.Name = "cboHeatFileNumber"
        Me.cboHeatFileNumber.Size = New System.Drawing.Size(188, 21)
        Me.cboHeatFileNumber.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(17, 477)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(132, 20)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "Heat File"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkInspectedParts
        '
        Me.chkInspectedParts.AutoSize = True
        Me.chkInspectedParts.ForeColor = System.Drawing.Color.Blue
        Me.chkInspectedParts.Location = New System.Drawing.Point(97, 669)
        Me.chkInspectedParts.Name = "chkInspectedParts"
        Me.chkInspectedParts.Size = New System.Drawing.Size(159, 17)
        Me.chkInspectedParts.TabIndex = 13
        Me.chkInspectedParts.TabStop = False
        Me.chkInspectedParts.Text = "Lots requiring QC Inspection"
        Me.chkInspectedParts.UseVisualStyleBackColor = True
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "LOCKED"})
        Me.cboStatus.Location = New System.Drawing.Point(96, 622)
        Me.cboStatus.Margin = New System.Windows.Forms.Padding(10)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(188, 21)
        Me.cboStatus.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(17, 623)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 20)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Status"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHeadMarking
        '
        Me.txtHeadMarking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeadMarking.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeadMarking.Location = New System.Drawing.Point(96, 437)
        Me.txtHeadMarking.Margin = New System.Windows.Forms.Padding(10)
        Me.txtHeadMarking.Name = "txtHeadMarking"
        Me.txtHeadMarking.Size = New System.Drawing.Size(188, 20)
        Me.txtHeadMarking.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 437)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 20)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Head Marking"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorName
        '
        Me.cboVendorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorName.DataSource = Me.VendorBindingSource
        Me.cboVendorName.DisplayMember = "VendorName"
        Me.cboVendorName.FormattingEnabled = True
        Me.cboVendorName.Location = New System.Drawing.Point(17, 571)
        Me.cboVendorName.Margin = New System.Windows.Forms.Padding(10, 3, 10, 10)
        Me.cboVendorName.Name = "cboVendorName"
        Me.cboVendorName.Size = New System.Drawing.Size(267, 21)
        Me.cboVendorName.TabIndex = 12
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtSteelSize
        '
        Me.txtSteelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSteelSize.Location = New System.Drawing.Point(96, 398)
        Me.txtSteelSize.Margin = New System.Windows.Forms.Padding(10)
        Me.txtSteelSize.Name = "txtSteelSize"
        Me.txtSteelSize.Size = New System.Drawing.Size(188, 20)
        Me.txtSteelSize.TabIndex = 8
        '
        'txtCarbon
        '
        Me.txtCarbon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarbon.Location = New System.Drawing.Point(96, 359)
        Me.txtCarbon.Margin = New System.Windows.Forms.Padding(10)
        Me.txtCarbon.Name = "txtCarbon"
        Me.txtCarbon.Size = New System.Drawing.Size(188, 20)
        Me.txtCarbon.TabIndex = 7
        '
        'cboSteelVendor
        '
        Me.cboSteelVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelVendor.DataSource = Me.VendorBindingSource
        Me.cboSteelVendor.DisplayMember = "VendorCode"
        Me.cboSteelVendor.FormattingEnabled = True
        Me.cboSteelVendor.Location = New System.Drawing.Point(96, 538)
        Me.cboSteelVendor.Margin = New System.Windows.Forms.Padding(10, 10, 10, 3)
        Me.cboSteelVendor.Name = "cboSteelVendor"
        Me.cboSteelVendor.Size = New System.Drawing.Size(188, 21)
        Me.cboSteelVendor.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 539)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 20)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Steel Vendor"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBlueprintNumber
        '
        Me.txtBlueprintNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBlueprintNumber.Location = New System.Drawing.Point(96, 280)
        Me.txtBlueprintNumber.Margin = New System.Windows.Forms.Padding(10)
        Me.txtBlueprintNumber.Name = "txtBlueprintNumber"
        Me.txtBlueprintNumber.Size = New System.Drawing.Size(188, 20)
        Me.txtBlueprintNumber.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 280)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 20)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Blueprint #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(18, 68)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(267, 40)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.DataSource = Me.FOXTableBindingSource
        Me.cboFOXNumber.DisplayMember = "FOXNumber"
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(96, 200)
        Me.cboFOXNumber.Margin = New System.Windows.Forms.Padding(10)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(188, 21)
        Me.cboFOXNumber.TabIndex = 3
        '
        'FOXTableBindingSource
        '
        Me.FOXTableBindingSource.DataMember = "FOXTable"
        Me.FOXTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(17, 159)
        Me.cboPartDescription.Margin = New System.Windows.Forms.Padding(10, 3, 10, 10)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(267, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "FOX Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(64, 127)
        Me.cboPartNumber.Margin = New System.Windows.Forms.Padding(5, 5, 5, 3)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(220, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(108, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(177, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.DataSource = Me.LotNumberBindingSource
        Me.cboLotNumber.DisplayMember = "LotNumber"
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(96, 319)
        Me.cboLotNumber.Margin = New System.Windows.Forms.Padding(10)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(188, 21)
        Me.cboLotNumber.TabIndex = 6
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatNumber.DisplayMember = "HeatNumber"
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(96, 240)
        Me.cboHeatNumber.Margin = New System.Windows.Forms.Padding(10)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(188, 21)
        Me.cboHeatNumber.TabIndex = 4
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Part #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 319)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Lot Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 715)
        Me.cmdClear.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(17, 398)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 20)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Steel Size"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(137, 715)
        Me.cmdViewByFilters.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewByFilters.TabIndex = 14
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Heat Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 359)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 20)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Carbon"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'FOXTableTableAdapter
        '
        Me.FOXTableTableAdapter.ClearBeforeFill = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(981, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 19
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 20
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdOpenLotNumber
        '
        Me.cmdOpenLotNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenLotNumber.Location = New System.Drawing.Point(353, 774)
        Me.cmdOpenLotNumber.Name = "cmdOpenLotNumber"
        Me.cmdOpenLotNumber.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenLotNumber.TabIndex = 16
        Me.cmdOpenLotNumber.Text = "Lot # Form"
        Me.cmdOpenLotNumber.UseVisualStyleBackColor = True
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'dgvLotNumber
        '
        Me.dgvLotNumber.AllowUserToAddRows = False
        Me.dgvLotNumber.AllowUserToDeleteRows = False
        Me.dgvLotNumber.AllowUserToOrderColumns = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvLotNumber.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLotNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLotNumber.AutoGenerateColumns = False
        Me.dgvLotNumber.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvLotNumber.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvLotNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLotNumber.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LotNumberColumn, Me.HeatNumberColumn, Me.FOXNumberColumn, Me.PartNumberColumn, Me.ShortDescriptionColumn, Me.SteelTypeColumn, Me.SteelSizeColumn, Me.BlueprintNumberColumn, Me.PieceWeightColumn, Me.BoxWeightColumn, Me.PalletWeightColumn, Me.BoxCountColumn, Me.PalletCountColumn, Me.PalletPiecesColumn, Me.NominalDiameterColumn, Me.NominalLengthColumn, Me.BoxTypeColumn, Me.CommentColumn, Me.ItemClassColumn, Me.CertificationTypeColumn, Me.FluxLoadNumberColumn, Me.AnnealedHeatNumberColumn, Me.HeadMarkingColumn, Me.QCInspectedColumn, Me.QCInspectorColumn, Me.SteelVendorIDColumn, Me.SteelPONumberColumn, Me.HeatNumberIDColumn, Me.StatusColumn, Me.RawMaterialWeightColumn, Me.ScrapWeightColumn, Me.FinishedWeightColumn, Me.CreationDateColumn, Me.DateReceivedColumn, Me.RMIDColumn, Me.LongDescriptionColumn, Me.SteelDescriptionColumn, Me.DivisionIDColumn})
        Me.dgvLotNumber.DataSource = Me.LotNumberBindingSource1
        Me.dgvLotNumber.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvLotNumber.Location = New System.Drawing.Point(353, 41)
        Me.dgvLotNumber.Name = "dgvLotNumber"
        Me.dgvLotNumber.Size = New System.Drawing.Size(777, 724)
        Me.dgvLotNumber.TabIndex = 21
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot Number"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        Me.LotNumberColumn.ReadOnly = True
        Me.LotNumberColumn.Width = 85
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat Number"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.ReadOnly = True
        Me.HeatNumberColumn.Width = 85
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX Number"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        Me.FOXNumberColumn.Width = 85
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'ShortDescriptionColumn
        '
        Me.ShortDescriptionColumn.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn.HeaderText = "Description"
        Me.ShortDescriptionColumn.Name = "ShortDescriptionColumn"
        Me.ShortDescriptionColumn.ReadOnly = True
        '
        'SteelTypeColumn
        '
        Me.SteelTypeColumn.DataPropertyName = "SteelType"
        Me.SteelTypeColumn.HeaderText = "Steel Type"
        Me.SteelTypeColumn.Name = "SteelTypeColumn"
        Me.SteelTypeColumn.ReadOnly = True
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.ReadOnly = True
        '
        'BlueprintNumberColumn
        '
        Me.BlueprintNumberColumn.DataPropertyName = "BlueprintNumber"
        Me.BlueprintNumberColumn.HeaderText = "Blueprint #"
        Me.BlueprintNumberColumn.Name = "BlueprintNumberColumn"
        Me.BlueprintNumberColumn.ReadOnly = True
        '
        'PieceWeightColumn
        '
        Me.PieceWeightColumn.DataPropertyName = "PieceWeight"
        Me.PieceWeightColumn.HeaderText = "Piece Weight"
        Me.PieceWeightColumn.Name = "PieceWeightColumn"
        Me.PieceWeightColumn.ReadOnly = True
        '
        'BoxWeightColumn
        '
        Me.BoxWeightColumn.DataPropertyName = "BoxWeight"
        Me.BoxWeightColumn.HeaderText = "Box Weight"
        Me.BoxWeightColumn.Name = "BoxWeightColumn"
        Me.BoxWeightColumn.ReadOnly = True
        '
        'PalletWeightColumn
        '
        Me.PalletWeightColumn.DataPropertyName = "PalletWeight"
        Me.PalletWeightColumn.HeaderText = "Pallet Weight"
        Me.PalletWeightColumn.Name = "PalletWeightColumn"
        Me.PalletWeightColumn.ReadOnly = True
        '
        'BoxCountColumn
        '
        Me.BoxCountColumn.DataPropertyName = "BoxCount"
        Me.BoxCountColumn.HeaderText = "Box Count"
        Me.BoxCountColumn.Name = "BoxCountColumn"
        Me.BoxCountColumn.ReadOnly = True
        '
        'PalletCountColumn
        '
        Me.PalletCountColumn.DataPropertyName = "PalletCount"
        Me.PalletCountColumn.HeaderText = "Pallet Count"
        Me.PalletCountColumn.Name = "PalletCountColumn"
        Me.PalletCountColumn.ReadOnly = True
        '
        'PalletPiecesColumn
        '
        Me.PalletPiecesColumn.DataPropertyName = "PalletPieces"
        Me.PalletPiecesColumn.HeaderText = "Pallet Pieces"
        Me.PalletPiecesColumn.Name = "PalletPiecesColumn"
        Me.PalletPiecesColumn.ReadOnly = True
        '
        'NominalDiameterColumn
        '
        Me.NominalDiameterColumn.DataPropertyName = "NominalDiameter"
        Me.NominalDiameterColumn.HeaderText = "Nominal Diameter"
        Me.NominalDiameterColumn.Name = "NominalDiameterColumn"
        Me.NominalDiameterColumn.ReadOnly = True
        '
        'NominalLengthColumn
        '
        Me.NominalLengthColumn.DataPropertyName = "NominalLength"
        Me.NominalLengthColumn.HeaderText = "Nominal Length"
        Me.NominalLengthColumn.Name = "NominalLengthColumn"
        Me.NominalLengthColumn.ReadOnly = True
        '
        'BoxTypeColumn
        '
        Me.BoxTypeColumn.DataPropertyName = "BoxType"
        Me.BoxTypeColumn.HeaderText = "Box Type"
        Me.BoxTypeColumn.Name = "BoxTypeColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        Me.ItemClassColumn.ReadOnly = True
        '
        'CertificationTypeColumn
        '
        Me.CertificationTypeColumn.DataPropertyName = "CertificationType"
        Me.CertificationTypeColumn.HeaderText = "Certification Type"
        Me.CertificationTypeColumn.Name = "CertificationTypeColumn"
        Me.CertificationTypeColumn.ReadOnly = True
        '
        'FluxLoadNumberColumn
        '
        Me.FluxLoadNumberColumn.DataPropertyName = "FluxLoadNumber"
        Me.FluxLoadNumberColumn.HeaderText = "Flux Load #"
        Me.FluxLoadNumberColumn.Name = "FluxLoadNumberColumn"
        Me.FluxLoadNumberColumn.ReadOnly = True
        '
        'AnnealedHeatNumberColumn
        '
        Me.AnnealedHeatNumberColumn.DataPropertyName = "AnnealedHeatNumber"
        Me.AnnealedHeatNumberColumn.HeaderText = "Ann. Heat #"
        Me.AnnealedHeatNumberColumn.Name = "AnnealedHeatNumberColumn"
        Me.AnnealedHeatNumberColumn.ReadOnly = True
        '
        'HeadMarkingColumn
        '
        Me.HeadMarkingColumn.DataPropertyName = "HeadMarking"
        Me.HeadMarkingColumn.HeaderText = "Head Marking"
        Me.HeadMarkingColumn.Name = "HeadMarkingColumn"
        Me.HeadMarkingColumn.ReadOnly = True
        '
        'QCInspectedColumn
        '
        Me.QCInspectedColumn.DataPropertyName = "QCInspected"
        Me.QCInspectedColumn.HeaderText = "Inspected?"
        Me.QCInspectedColumn.Name = "QCInspectedColumn"
        Me.QCInspectedColumn.ReadOnly = True
        '
        'QCInspectorColumn
        '
        Me.QCInspectorColumn.DataPropertyName = "QCInspector"
        Me.QCInspectorColumn.HeaderText = "QC Inspector"
        Me.QCInspectorColumn.Name = "QCInspectorColumn"
        Me.QCInspectorColumn.ReadOnly = True
        '
        'SteelVendorIDColumn
        '
        Me.SteelVendorIDColumn.DataPropertyName = "SteelVendorID"
        Me.SteelVendorIDColumn.HeaderText = "Steel Vendor"
        Me.SteelVendorIDColumn.Name = "SteelVendorIDColumn"
        Me.SteelVendorIDColumn.ReadOnly = True
        '
        'SteelPONumberColumn
        '
        Me.SteelPONumberColumn.DataPropertyName = "SteelPONumber"
        Me.SteelPONumberColumn.HeaderText = "PO #"
        Me.SteelPONumberColumn.Name = "SteelPONumberColumn"
        Me.SteelPONumberColumn.ReadOnly = True
        '
        'HeatNumberIDColumn
        '
        Me.HeatNumberIDColumn.DataPropertyName = "HeatNumberID"
        Me.HeatNumberIDColumn.HeaderText = "Heat File #"
        Me.HeatNumberIDColumn.Name = "HeatNumberIDColumn"
        Me.HeatNumberIDColumn.ReadOnly = True
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        '
        'RawMaterialWeightColumn
        '
        Me.RawMaterialWeightColumn.DataPropertyName = "RawMaterialWeight"
        Me.RawMaterialWeightColumn.HeaderText = "Raw Material Wt."
        Me.RawMaterialWeightColumn.Name = "RawMaterialWeightColumn"
        Me.RawMaterialWeightColumn.ReadOnly = True
        '
        'ScrapWeightColumn
        '
        Me.ScrapWeightColumn.DataPropertyName = "ScrapWeight"
        Me.ScrapWeightColumn.HeaderText = "Scrap Weight"
        Me.ScrapWeightColumn.Name = "ScrapWeightColumn"
        Me.ScrapWeightColumn.ReadOnly = True
        '
        'FinishedWeightColumn
        '
        Me.FinishedWeightColumn.DataPropertyName = "FinishedWeight"
        Me.FinishedWeightColumn.HeaderText = "Finish Weight"
        Me.FinishedWeightColumn.Name = "FinishedWeightColumn"
        Me.FinishedWeightColumn.ReadOnly = True
        '
        'CreationDateColumn
        '
        Me.CreationDateColumn.DataPropertyName = "CreationDate"
        Me.CreationDateColumn.HeaderText = "Creation Date"
        Me.CreationDateColumn.Name = "CreationDateColumn"
        Me.CreationDateColumn.ReadOnly = True
        '
        'DateReceivedColumn
        '
        Me.DateReceivedColumn.DataPropertyName = "DateReceived"
        Me.DateReceivedColumn.HeaderText = "Date Received"
        Me.DateReceivedColumn.Name = "DateReceivedColumn"
        Me.DateReceivedColumn.ReadOnly = True
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.Visible = False
        '
        'LongDescriptionColumn
        '
        Me.LongDescriptionColumn.DataPropertyName = "LongDescription"
        Me.LongDescriptionColumn.HeaderText = "LongDescription"
        Me.LongDescriptionColumn.Name = "LongDescriptionColumn"
        Me.LongDescriptionColumn.Visible = False
        '
        'SteelDescriptionColumn
        '
        Me.SteelDescriptionColumn.DataPropertyName = "SteelDescription"
        Me.SteelDescriptionColumn.HeaderText = "SteelDescription"
        Me.SteelDescriptionColumn.Name = "SteelDescriptionColumn"
        Me.SteelDescriptionColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'LotNumberBindingSource1
        '
        Me.LotNumberBindingSource1.DataMember = "LotNumber"
        Me.LotNumberBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrintTubPage
        '
        Me.cmdPrintTubPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintTubPage.Enabled = False
        Me.cmdPrintTubPage.Location = New System.Drawing.Point(827, 771)
        Me.cmdPrintTubPage.Name = "cmdPrintTubPage"
        Me.cmdPrintTubPage.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintTubPage.TabIndex = 17
        Me.cmdPrintTubPage.Text = "Print Tub Page"
        Me.cmdPrintTubPage.UseVisualStyleBackColor = True
        '
        'cmdPrintTubTag
        '
        Me.cmdPrintTubTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintTubTag.Enabled = False
        Me.cmdPrintTubTag.Location = New System.Drawing.Point(904, 771)
        Me.cmdPrintTubTag.Name = "cmdPrintTubTag"
        Me.cmdPrintTubTag.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintTubTag.TabIndex = 18
        Me.cmdPrintTubTag.Text = "Print Tub Tag"
        Me.cmdPrintTubTag.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CRTubTag
        '
        Me.CRTubTag.ActiveViewIndex = 0
        Me.CRTubTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRTubTag.Location = New System.Drawing.Point(539, 774)
        Me.CRTubTag.Name = "CRTubTag"
        Me.CRTubTag.ReportSource = Me.CRXTubtag1
        Me.CRTubTag.Size = New System.Drawing.Size(59, 37)
        Me.CRTubTag.TabIndex = 22
        Me.CRTubTag.Visible = False
        '
        'ViewLotNumbers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.CRTubTag)
        Me.Controls.Add(Me.cmdPrintTubTag)
        Me.Controls.Add(Me.cmdPrintTubPage)
        Me.Controls.Add(Me.dgvLotNumber)
        Me.Controls.Add(Me.cmdOpenLotNumber)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxViewLotNumbers)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewLotNumbers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Lot Number Listing"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxViewLotNumbers.ResumeLayout(False)
        Me.gpxViewLotNumbers.PerformLayout()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLotNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxViewLotNumbers As System.Windows.Forms.GroupBox
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents FOXTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOXTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdOpenLotNumber As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboSteelVendor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBlueprintNumber As System.Windows.Forms.TextBox
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents txtSteelSize As System.Windows.Forms.TextBox
    Friend WithEvents txtCarbon As System.Windows.Forms.TextBox
    Friend WithEvents cboVendorName As System.Windows.Forms.ComboBox
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvLotNumber As System.Windows.Forms.DataGridView
    Friend WithEvents LotNumberBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtHeadMarking As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintTubPage As System.Windows.Forms.Button
    Friend WithEvents cmdPrintTubTag As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkInspectedParts As System.Windows.Forms.CheckBox
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlueprintNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletCountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalDiameterColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalLengthColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertificationTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FluxLoadNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnnealedHeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeadMarkingColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QCInspectedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QCInspectorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelVendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelPONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RawMaterialWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScrapWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinishedWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboHeatFileNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents UploadOutsideCertificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReUploadOutsideCertificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewOutsideCertificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRTubTag As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CRXTubtag1 As MOS09Program.CRXTubtag
End Class
