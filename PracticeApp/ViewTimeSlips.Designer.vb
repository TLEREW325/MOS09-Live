<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewTimeSlips
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewTimeSlips))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxVendorSearchData = New System.Windows.Forms.GroupBox
        Me.txtEmployeeNumber = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtPartTextFilter = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblMachineName = New System.Windows.Forms.Label
        Me.chkShowFG = New System.Windows.Forms.CheckBox
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboSteelCarbon = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboMachineNumber = New System.Windows.Forms.ComboBox
        Me.MachineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.FOXTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.dgvTimeSlipPostings = New System.Windows.Forms.DataGridView
        Me.TimeSlipKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PostingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PiecesProducedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryPiecesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ScrapWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShiftColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineHoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SetupHoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolingHoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OtherHoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalHoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedSteelCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXStepColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmployeeIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TimeSlipCombinedDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrintListing = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.TimeSlipCombinedDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TimeSlipCombinedDataTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.FOXTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.MachineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MachineTableTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTotalSteelWeight = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtTotalProduction = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTotalCost = New System.Windows.Forms.TextBox
        Me.txtTotalOtherCost = New System.Windows.Forms.TextBox
        Me.txtTotalSteelCost = New System.Windows.Forms.TextBox
        Me.txtTotalInventoryPieces = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxVendorSearchData.SuspendLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MachineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTimeSlipPostings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeSlipCombinedDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'gpxVendorSearchData
        '
        Me.gpxVendorSearchData.Controls.Add(Me.txtEmployeeNumber)
        Me.gpxVendorSearchData.Controls.Add(Me.Label18)
        Me.gpxVendorSearchData.Controls.Add(Me.txtPartTextFilter)
        Me.gpxVendorSearchData.Controls.Add(Me.Label16)
        Me.gpxVendorSearchData.Controls.Add(Me.lblMachineName)
        Me.gpxVendorSearchData.Controls.Add(Me.chkShowFG)
        Me.gpxVendorSearchData.Controls.Add(Me.cboSteelSize)
        Me.gpxVendorSearchData.Controls.Add(Me.Label9)
        Me.gpxVendorSearchData.Controls.Add(Me.cboSteelCarbon)
        Me.gpxVendorSearchData.Controls.Add(Me.Label8)
        Me.gpxVendorSearchData.Controls.Add(Me.cboMachineNumber)
        Me.gpxVendorSearchData.Controls.Add(Me.cboPartDescription)
        Me.gpxVendorSearchData.Controls.Add(Me.Label14)
        Me.gpxVendorSearchData.Controls.Add(Me.chkDateRange)
        Me.gpxVendorSearchData.Controls.Add(Me.dtpEndDate)
        Me.gpxVendorSearchData.Controls.Add(Me.dtpBeginDate)
        Me.gpxVendorSearchData.Controls.Add(Me.Label3)
        Me.gpxVendorSearchData.Controls.Add(Me.Label4)
        Me.gpxVendorSearchData.Controls.Add(Me.Label12)
        Me.gpxVendorSearchData.Controls.Add(Me.txtTextFilter)
        Me.gpxVendorSearchData.Controls.Add(Me.Label7)
        Me.gpxVendorSearchData.Controls.Add(Me.cboFOXNumber)
        Me.gpxVendorSearchData.Controls.Add(Me.Label2)
        Me.gpxVendorSearchData.Controls.Add(Me.cmdViewByFilters)
        Me.gpxVendorSearchData.Controls.Add(Me.cboDivisionID)
        Me.gpxVendorSearchData.Controls.Add(Me.cmdClear)
        Me.gpxVendorSearchData.Controls.Add(Me.Label1)
        Me.gpxVendorSearchData.Controls.Add(Me.cboPartNumber)
        Me.gpxVendorSearchData.Controls.Add(Me.Label6)
        Me.gpxVendorSearchData.Controls.Add(Me.LinkLabel1)
        Me.gpxVendorSearchData.Location = New System.Drawing.Point(29, 41)
        Me.gpxVendorSearchData.Name = "gpxVendorSearchData"
        Me.gpxVendorSearchData.Size = New System.Drawing.Size(300, 770)
        Me.gpxVendorSearchData.TabIndex = 0
        Me.gpxVendorSearchData.TabStop = False
        Me.gpxVendorSearchData.Text = "View By Filters"
        '
        'txtEmployeeNumber
        '
        Me.txtEmployeeNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeNumber.Location = New System.Drawing.Point(157, 480)
        Me.txtEmployeeNumber.Name = "txtEmployeeNumber"
        Me.txtEmployeeNumber.Size = New System.Drawing.Size(125, 20)
        Me.txtEmployeeNumber.TabIndex = 10
        Me.txtEmployeeNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(17, 478)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 20)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Employee Number"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartTextFilter
        '
        Me.txtPartTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartTextFilter.Location = New System.Drawing.Point(17, 243)
        Me.txtPartTextFilter.Name = "txtPartTextFilter"
        Me.txtPartTextFilter.Size = New System.Drawing.Size(264, 20)
        Me.txtPartTextFilter.TabIndex = 4
        Me.txtPartTextFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(17, 220)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 20)
        Me.Label16.TabIndex = 58
        Me.Label16.Text = "Part # (text filter)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachineName
        '
        Me.lblMachineName.ForeColor = System.Drawing.Color.Blue
        Me.lblMachineName.Location = New System.Drawing.Point(17, 313)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(264, 23)
        Me.lblMachineName.TabIndex = 6
        Me.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkShowFG
        '
        Me.chkShowFG.AutoSize = True
        Me.chkShowFG.ForeColor = System.Drawing.Color.Blue
        Me.chkShowFG.Location = New System.Drawing.Point(17, 443)
        Me.chkShowFG.Name = "chkShowFG"
        Me.chkShowFG.Size = New System.Drawing.Size(196, 17)
        Me.chkShowFG.TabIndex = 9
        Me.chkShowFG.Text = "Show Only Finished Goods Postings"
        Me.chkShowFG.UseVisualStyleBackColor = True
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(96, 394)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(189, 21)
        Me.cboSteelSize.TabIndex = 8
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
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(17, 395)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "Steel Size"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelCarbon
        '
        Me.cboSteelCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelCarbon.DisplayMember = "Carbon"
        Me.cboSteelCarbon.FormattingEnabled = True
        Me.cboSteelCarbon.Location = New System.Drawing.Point(96, 357)
        Me.cboSteelCarbon.Name = "cboSteelCarbon"
        Me.cboSteelCarbon.Size = New System.Drawing.Size(189, 21)
        Me.cboSteelCarbon.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 358)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 20)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Carbon/Alloy"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMachineNumber
        '
        Me.cboMachineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMachineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMachineNumber.DataSource = Me.MachineTableBindingSource
        Me.cboMachineNumber.DisplayMember = "MachineID"
        Me.cboMachineNumber.FormattingEnabled = True
        Me.cboMachineNumber.Location = New System.Drawing.Point(95, 289)
        Me.cboMachineNumber.Name = "cboMachineNumber"
        Me.cboMachineNumber.Size = New System.Drawing.Size(190, 21)
        Me.cboMachineNumber.TabIndex = 5
        '
        'MachineTableBindingSource
        '
        Me.MachineTableBindingSource.DataMember = "MachineTable"
        Me.MachineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(17, 178)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(262, 21)
        Me.cboPartDescription.TabIndex = 3
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(17, 577)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(100, 613)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 12
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(101, 685)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpEndDate.TabIndex = 14
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(101, 645)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpBeginDate.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 685)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "End Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 645)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 20)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Begin Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(17, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 40)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.Location = New System.Drawing.Point(17, 540)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(261, 20)
        Me.txtTextFilter.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 517)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(261, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Employee Name (text filter)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.DataSource = Me.FOXTableBindingSource
        Me.cboFOXNumber.DisplayMember = "FOXNumber"
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(92, 108)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(187, 21)
        Me.cboFOXNumber.TabIndex = 1
        '
        'FOXTableBindingSource
        '
        Me.FOXTableBindingSource.DataMember = "FOXTable"
        Me.FOXTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "FOX #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(136, 722)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 15
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(98, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(187, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 722)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 16
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(62, 151)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(218, 21)
        Me.cboPartNumber.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Part #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(17, 289)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(100, 23)
        Me.LinkLabel1.TabIndex = 60
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Machine"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvTimeSlipPostings
        '
        Me.dgvTimeSlipPostings.AllowUserToAddRows = False
        Me.dgvTimeSlipPostings.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvTimeSlipPostings.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTimeSlipPostings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTimeSlipPostings.AutoGenerateColumns = False
        Me.dgvTimeSlipPostings.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTimeSlipPostings.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTimeSlipPostings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimeSlipPostings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TimeSlipKeyColumn, Me.LineKeyColumn, Me.PostingDateColumn, Me.FOXNumberColumn, Me.PartNumberColumn, Me.MachineNumberColumn, Me.PiecesProducedColumn, Me.InventoryPiecesColumn, Me.LineWeightColumn, Me.ScrapWeightColumn, Me.RMIDColumn, Me.EmployeeNameColumn, Me.ShiftColumn, Me.MachineHoursColumn, Me.SetupHoursColumn, Me.ToolingHoursColumn, Me.OtherHoursColumn, Me.TotalHoursColumn, Me.DivisionIDColumn, Me.StatusColumn, Me.CostColumn, Me.ExtendedCostColumn, Me.ExtendedSteelCostColumn, Me.CustomerIDColumn, Me.FOXStepColumn, Me.ProductionNumberColumn, Me.EmployeeIDColumn})
        Me.dgvTimeSlipPostings.DataSource = Me.TimeSlipCombinedDataBindingSource
        Me.dgvTimeSlipPostings.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvTimeSlipPostings.Location = New System.Drawing.Point(344, 41)
        Me.dgvTimeSlipPostings.Name = "dgvTimeSlipPostings"
        Me.dgvTimeSlipPostings.Size = New System.Drawing.Size(786, 560)
        Me.dgvTimeSlipPostings.TabIndex = 2
        '
        'TimeSlipKeyColumn
        '
        Me.TimeSlipKeyColumn.DataPropertyName = "TimeSlipKey"
        Me.TimeSlipKeyColumn.HeaderText = "TimeSlipKey"
        Me.TimeSlipKeyColumn.Name = "TimeSlipKeyColumn"
        Me.TimeSlipKeyColumn.Visible = False
        '
        'LineKeyColumn
        '
        Me.LineKeyColumn.DataPropertyName = "LineKey"
        Me.LineKeyColumn.HeaderText = "LineKey"
        Me.LineKeyColumn.Name = "LineKeyColumn"
        Me.LineKeyColumn.Visible = False
        '
        'PostingDateColumn
        '
        Me.PostingDateColumn.DataPropertyName = "PostingDate"
        Me.PostingDateColumn.HeaderText = "Posting Date"
        Me.PostingDateColumn.Name = "PostingDateColumn"
        Me.PostingDateColumn.Width = 80
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.Width = 80
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        '
        'MachineNumberColumn
        '
        Me.MachineNumberColumn.DataPropertyName = "MachineNumber"
        Me.MachineNumberColumn.HeaderText = "Machine #"
        Me.MachineNumberColumn.Name = "MachineNumberColumn"
        Me.MachineNumberColumn.Width = 60
        '
        'PiecesProducedColumn
        '
        Me.PiecesProducedColumn.DataPropertyName = "PiecesProduced"
        Me.PiecesProducedColumn.HeaderText = "Pieces Produced"
        Me.PiecesProducedColumn.Name = "PiecesProducedColumn"
        Me.PiecesProducedColumn.Width = 80
        '
        'InventoryPiecesColumn
        '
        Me.InventoryPiecesColumn.DataPropertyName = "InventoryPieces"
        Me.InventoryPiecesColumn.HeaderText = "Inventory Pieces"
        Me.InventoryPiecesColumn.Name = "InventoryPiecesColumn"
        Me.InventoryPiecesColumn.Width = 80
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        Me.LineWeightColumn.HeaderText = "Line Weight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.Width = 80
        '
        'ScrapWeightColumn
        '
        Me.ScrapWeightColumn.DataPropertyName = "ScrapWeight"
        Me.ScrapWeightColumn.HeaderText = "Scrap Weight"
        Me.ScrapWeightColumn.Name = "ScrapWeightColumn"
        Me.ScrapWeightColumn.Width = 80
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        '
        'EmployeeNameColumn
        '
        Me.EmployeeNameColumn.DataPropertyName = "EmployeeName"
        Me.EmployeeNameColumn.HeaderText = "Employee Name"
        Me.EmployeeNameColumn.Name = "EmployeeNameColumn"
        '
        'ShiftColumn
        '
        Me.ShiftColumn.DataPropertyName = "Shift"
        Me.ShiftColumn.HeaderText = "Shift"
        Me.ShiftColumn.Name = "ShiftColumn"
        Me.ShiftColumn.Width = 60
        '
        'MachineHoursColumn
        '
        Me.MachineHoursColumn.DataPropertyName = "MachineHours"
        Me.MachineHoursColumn.HeaderText = "Machine Hours"
        Me.MachineHoursColumn.Name = "MachineHoursColumn"
        '
        'SetupHoursColumn
        '
        Me.SetupHoursColumn.DataPropertyName = "SetupHours"
        Me.SetupHoursColumn.HeaderText = "Setup Hours"
        Me.SetupHoursColumn.Name = "SetupHoursColumn"
        '
        'ToolingHoursColumn
        '
        Me.ToolingHoursColumn.DataPropertyName = "ToolingHours"
        Me.ToolingHoursColumn.HeaderText = "Tooling Hours"
        Me.ToolingHoursColumn.Name = "ToolingHoursColumn"
        '
        'OtherHoursColumn
        '
        Me.OtherHoursColumn.DataPropertyName = "OtherHours"
        Me.OtherHoursColumn.HeaderText = "Other Hours"
        Me.OtherHoursColumn.Name = "OtherHoursColumn"
        '
        'TotalHoursColumn
        '
        Me.TotalHoursColumn.DataPropertyName = "TotalHours"
        Me.TotalHoursColumn.HeaderText = "Total Hours"
        Me.TotalHoursColumn.Name = "TotalHoursColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        '
        'CostColumn
        '
        Me.CostColumn.DataPropertyName = "Cost"
        Me.CostColumn.HeaderText = "Cost"
        Me.CostColumn.Name = "CostColumn"
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.ExtendedCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ExtendedCostColumn.HeaderText = "Ext. Cost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        '
        'ExtendedSteelCostColumn
        '
        Me.ExtendedSteelCostColumn.DataPropertyName = "ExtendedSteelCost"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedSteelCostColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedSteelCostColumn.HeaderText = "Ext. Steel Cost"
        Me.ExtendedSteelCostColumn.Name = "ExtendedSteelCostColumn"
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'FOXStepColumn
        '
        Me.FOXStepColumn.DataPropertyName = "FOXStep"
        Me.FOXStepColumn.HeaderText = "FOX Step"
        Me.FOXStepColumn.Name = "FOXStepColumn"
        '
        'ProductionNumberColumn
        '
        Me.ProductionNumberColumn.DataPropertyName = "ProductionNumber"
        Me.ProductionNumberColumn.HeaderText = "Production #"
        Me.ProductionNumberColumn.Name = "ProductionNumberColumn"
        '
        'EmployeeIDColumn
        '
        Me.EmployeeIDColumn.DataPropertyName = "EmployeeID"
        Me.EmployeeIDColumn.HeaderText = "Employee ID"
        Me.EmployeeIDColumn.Name = "EmployeeIDColumn"
        Me.EmployeeIDColumn.Visible = False
        '
        'TimeSlipCombinedDataBindingSource
        '
        Me.TimeSlipCombinedDataBindingSource.DataMember = "TimeSlipCombinedData"
        Me.TimeSlipCombinedDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrintListing
        '
        Me.cmdPrintListing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintListing.Enabled = False
        Me.cmdPrintListing.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrintListing.Name = "cmdPrintListing"
        Me.cmdPrintListing.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintListing.TabIndex = 14
        Me.cmdPrintListing.Text = "Print Listing"
        Me.cmdPrintListing.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 15
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'TimeSlipCombinedDataTableAdapter
        '
        Me.TimeSlipCombinedDataTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'FOXTableTableAdapter
        '
        Me.FOXTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'MachineTableTableAdapter
        '
        Me.MachineTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtTotalSteelWeight)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtTotalProduction)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtTotalCost)
        Me.GroupBox1.Controls.Add(Me.txtTotalOtherCost)
        Me.GroupBox1.Controls.Add(Me.txtTotalSteelCost)
        Me.GroupBox1.Controls.Add(Me.txtTotalInventoryPieces)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(344, 607)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 204)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datagrid Totals"
        '
        'txtTotalSteelWeight
        '
        Me.txtTotalSteelWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalSteelWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalSteelWeight.Location = New System.Drawing.Point(144, 53)
        Me.txtTotalSteelWeight.Name = "txtTotalSteelWeight"
        Me.txtTotalSteelWeight.Size = New System.Drawing.Size(164, 20)
        Me.txtTotalSteelWeight.TabIndex = 64
        Me.txtTotalSteelWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(10, 53)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(128, 20)
        Me.Label19.TabIndex = 65
        Me.Label19.Text = "Total Steel Weight"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalProduction
        '
        Me.txtTotalProduction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalProduction.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalProduction.Location = New System.Drawing.Point(144, 23)
        Me.txtTotalProduction.Name = "txtTotalProduction"
        Me.txtTotalProduction.Size = New System.Drawing.Size(164, 20)
        Me.txtTotalProduction.TabIndex = 62
        Me.txtTotalProduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(10, 23)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(128, 20)
        Me.Label17.TabIndex = 63
        Me.Label17.Text = "Total  Production"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalCost
        '
        Me.txtTotalCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalCost.Location = New System.Drawing.Point(144, 173)
        Me.txtTotalCost.Name = "txtTotalCost"
        Me.txtTotalCost.Size = New System.Drawing.Size(164, 20)
        Me.txtTotalCost.TabIndex = 58
        Me.txtTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalOtherCost
        '
        Me.txtTotalOtherCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalOtherCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalOtherCost.Location = New System.Drawing.Point(144, 143)
        Me.txtTotalOtherCost.Name = "txtTotalOtherCost"
        Me.txtTotalOtherCost.Size = New System.Drawing.Size(164, 20)
        Me.txtTotalOtherCost.TabIndex = 60
        Me.txtTotalOtherCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalSteelCost
        '
        Me.txtTotalSteelCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalSteelCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalSteelCost.Location = New System.Drawing.Point(144, 113)
        Me.txtTotalSteelCost.Name = "txtTotalSteelCost"
        Me.txtTotalSteelCost.Size = New System.Drawing.Size(164, 20)
        Me.txtTotalSteelCost.TabIndex = 58
        Me.txtTotalSteelCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalInventoryPieces
        '
        Me.txtTotalInventoryPieces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalInventoryPieces.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalInventoryPieces.Location = New System.Drawing.Point(144, 83)
        Me.txtTotalInventoryPieces.Name = "txtTotalInventoryPieces"
        Me.txtTotalInventoryPieces.Size = New System.Drawing.Size(164, 20)
        Me.txtTotalInventoryPieces.TabIndex = 0
        Me.txtTotalInventoryPieces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(10, 173)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 20)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Total Cost"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(10, 143)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 20)
        Me.Label13.TabIndex = 61
        Me.Label13.Text = "Total OH/Labor Cost"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(10, 113)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 20)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "Total Steel Cost"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(10, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 20)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Total Inventory Pieces"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(692, 618)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(311, 139)
        Me.Label20.TabIndex = 58
        Me.Label20.Text = resources.GetString("Label20.Text")
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewTimeSlips
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrintListing)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvTimeSlipPostings)
        Me.Controls.Add(Me.gpxVendorSearchData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewTimeSlips"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Time Slip Postings (All)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxVendorSearchData.ResumeLayout(False)
        Me.gpxVendorSearchData.PerformLayout()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MachineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTimeSlipPostings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeSlipCombinedDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gpxVendorSearchData As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvTimeSlipPostings As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents TimeSlipCombinedDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimeSlipCombinedDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TimeSlipCombinedDataTableAdapter
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cmdPrintListing As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents FOXTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOXTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents cboMachineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboSteelCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents chkShowFG As System.Windows.Forms.CheckBox
    Friend WithEvents MachineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MachineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.MachineTableTableAdapter
    Friend WithEvents lblMachineName As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCost As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalOtherCost As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSteelCost As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalInventoryPieces As System.Windows.Forms.TextBox
    Friend WithEvents txtPartTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TimeSlipKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PiecesProducedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryPiecesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScrapWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SetupHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolingHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtherHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedSteelCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXStepColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTotalProduction As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtEmployeeNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSteelWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
