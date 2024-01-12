<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPullTests
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
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PullTestQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdOpenForm = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboPullTestNumber = New System.Windows.Forms.ComboBox
        Me.gpxViewBy = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboCertCode = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.PullTestQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PullTestQueryTableAdapter
        Me.dgvPullTestQuery = New System.Windows.Forms.DataGridView
        Me.TestNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PullTestLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TestDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CrossSectionalAreaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UltimateYieldPSIColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Yield2PercentPSIColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReductionPercentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Elongation2PercentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalDiameterColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalLengthColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TestedByColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OldTestNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OldPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Yield2PercentPoundColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UltimateYieldPoundColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Elongation2InchColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reduction2InchColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TorqueFootPoundsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BreakLocationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BendTestColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PullTestQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxViewBy.SuspendLayout()
        CType(Me.dgvPullTestQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'PullTestQueryBindingSource
        '
        Me.PullTestQueryBindingSource.DataMember = "PullTestQuery"
        Me.PullTestQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(19, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 31)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "This will open the Pull Test Form and close the current form."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdOpenForm
        '
        Me.cmdOpenForm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdOpenForm.Location = New System.Drawing.Point(211, 45)
        Me.cmdOpenForm.Name = "cmdOpenForm"
        Me.cmdOpenForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenForm.TabIndex = 14
        Me.cmdOpenForm.Text = "Pull Test"
        Me.cmdOpenForm.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(984, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 15
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1061, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdOpenForm)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 693)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 118)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Open Pull Test Form"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Part #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "FOX #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(64, 115)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(219, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 526)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Begin Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(105, 191)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboFOXNumber.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 562)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(104, 526)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 237)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Heat #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(104, 562)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatNumber.DisplayMember = "HeatNumber"
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(105, 236)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboHeatNumber.TabIndex = 4
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(135, 597)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 11
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(212, 597)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(104, 30)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(178, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(100, 497)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 8
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 461)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(21, 282)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Pull Test #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPullTestNumber
        '
        Me.cboPullTestNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPullTestNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPullTestNumber.FormattingEnabled = True
        Me.cboPullTestNumber.Location = New System.Drawing.Point(105, 281)
        Me.cboPullTestNumber.Name = "cboPullTestNumber"
        Me.cboPullTestNumber.Size = New System.Drawing.Size(178, 21)
        Me.cboPullTestNumber.TabIndex = 5
        '
        'gpxViewBy
        '
        Me.gpxViewBy.Controls.Add(Me.Label12)
        Me.gpxViewBy.Controls.Add(Me.cboStatus)
        Me.gpxViewBy.Controls.Add(Me.Label10)
        Me.gpxViewBy.Controls.Add(Me.cboCertCode)
        Me.gpxViewBy.Controls.Add(Me.Label6)
        Me.gpxViewBy.Controls.Add(Me.cboPartDescription)
        Me.gpxViewBy.Controls.Add(Me.cboPullTestNumber)
        Me.gpxViewBy.Controls.Add(Me.Label9)
        Me.gpxViewBy.Controls.Add(Me.Label14)
        Me.gpxViewBy.Controls.Add(Me.chkDateRange)
        Me.gpxViewBy.Controls.Add(Me.cboDivisionID)
        Me.gpxViewBy.Controls.Add(Me.Label1)
        Me.gpxViewBy.Controls.Add(Me.cmdClear)
        Me.gpxViewBy.Controls.Add(Me.cmdViewByFilters)
        Me.gpxViewBy.Controls.Add(Me.cboHeatNumber)
        Me.gpxViewBy.Controls.Add(Me.dtpEndDate)
        Me.gpxViewBy.Controls.Add(Me.Label7)
        Me.gpxViewBy.Controls.Add(Me.dtpBeginDate)
        Me.gpxViewBy.Controls.Add(Me.Label8)
        Me.gpxViewBy.Controls.Add(Me.cboFOXNumber)
        Me.gpxViewBy.Controls.Add(Me.Label5)
        Me.gpxViewBy.Controls.Add(Me.cboPartNumber)
        Me.gpxViewBy.Controls.Add(Me.Label3)
        Me.gpxViewBy.Controls.Add(Me.Label2)
        Me.gpxViewBy.Location = New System.Drawing.Point(29, 41)
        Me.gpxViewBy.Name = "gpxViewBy"
        Me.gpxViewBy.Size = New System.Drawing.Size(300, 646)
        Me.gpxViewBy.TabIndex = 0
        Me.gpxViewBy.TabStop = False
        Me.gpxViewBy.Text = "View By Filters"
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(21, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 40)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "CLOSED"})
        Me.cboStatus.Location = New System.Drawing.Point(106, 371)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(178, 21)
        Me.cboStatus.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(21, 372)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Status"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCertCode
        '
        Me.cboCertCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCertCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCertCode.FormattingEnabled = True
        Me.cboCertCode.Items.AddRange(New Object() {"", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "CERT REQUIRED"})
        Me.cboCertCode.Location = New System.Drawing.Point(105, 326)
        Me.cboCertCode.Name = "cboCertCode"
        Me.cboCertCode.Size = New System.Drawing.Size(178, 21)
        Me.cboCertCode.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(21, 327)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Cert Code"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(21, 152)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(263, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'PullTestQueryTableAdapter
        '
        Me.PullTestQueryTableAdapter.ClearBeforeFill = True
        '
        'dgvPullTestQuery
        '
        Me.dgvPullTestQuery.AllowUserToAddRows = False
        Me.dgvPullTestQuery.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvPullTestQuery.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPullTestQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPullTestQuery.AutoGenerateColumns = False
        Me.dgvPullTestQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPullTestQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPullTestQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPullTestQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TestNumberColumn, Me.PullTestLineNumberColumn, Me.TestDateColumn, Me.FOXNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.HeatNumberColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.CrossSectionalAreaColumn, Me.UltimateYieldPSIColumn, Me.Yield2PercentPSIColumn, Me.ReductionPercentColumn, Me.Elongation2PercentColumn, Me.NominalDiameterColumn, Me.NominalLengthColumn, Me.TestedByColumn, Me.CommentColumn, Me.OldTestNumberColumn, Me.OldPartNumberColumn, Me.StatusColumn, Me.Yield2PercentPoundColumn, Me.UltimateYieldPoundColumn, Me.Elongation2InchColumn, Me.Reduction2InchColumn, Me.TorqueFootPoundsColumn, Me.BreakLocationColumn, Me.BendTestColumn, Me.CertCodeColumn, Me.ItemClassColumn, Me.ProcessTypeColumn, Me.DivisionIDColumn, Me.RMIDColumn, Me.DescriptionColumn})
        Me.dgvPullTestQuery.DataSource = Me.PullTestQueryBindingSource
        Me.dgvPullTestQuery.GridColor = System.Drawing.Color.Blue
        Me.dgvPullTestQuery.Location = New System.Drawing.Point(345, 41)
        Me.dgvPullTestQuery.Name = "dgvPullTestQuery"
        Me.dgvPullTestQuery.Size = New System.Drawing.Size(785, 714)
        Me.dgvPullTestQuery.TabIndex = 16
        '
        'TestNumberColumn
        '
        Me.TestNumberColumn.DataPropertyName = "TestNumber"
        Me.TestNumberColumn.HeaderText = "Test #"
        Me.TestNumberColumn.Name = "TestNumberColumn"
        Me.TestNumberColumn.ReadOnly = True
        Me.TestNumberColumn.Width = 80
        '
        'PullTestLineNumberColumn
        '
        Me.PullTestLineNumberColumn.DataPropertyName = "PullTestLineNumber"
        Me.PullTestLineNumberColumn.HeaderText = "Line #"
        Me.PullTestLineNumberColumn.Name = "PullTestLineNumberColumn"
        Me.PullTestLineNumberColumn.ReadOnly = True
        Me.PullTestLineNumberColumn.Width = 65
        '
        'TestDateColumn
        '
        Me.TestDateColumn.DataPropertyName = "TestDate"
        Me.TestDateColumn.HeaderText = "Date"
        Me.TestDateColumn.Name = "TestDateColumn"
        Me.TestDateColumn.ReadOnly = True
        Me.TestDateColumn.Width = 80
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        Me.FOXNumberColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.ReadOnly = True
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon"
        Me.CarbonColumn.Name = "CarbonColumn"
        Me.CarbonColumn.ReadOnly = True
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.ReadOnly = True
        '
        'CrossSectionalAreaColumn
        '
        Me.CrossSectionalAreaColumn.DataPropertyName = "CrossSectionalArea"
        Me.CrossSectionalAreaColumn.HeaderText = "Cross Sectional Area"
        Me.CrossSectionalAreaColumn.Name = "CrossSectionalAreaColumn"
        Me.CrossSectionalAreaColumn.ReadOnly = True
        Me.CrossSectionalAreaColumn.Width = 80
        '
        'UltimateYieldPSIColumn
        '
        Me.UltimateYieldPSIColumn.DataPropertyName = "UltimateYieldPSI"
        Me.UltimateYieldPSIColumn.HeaderText = "Tensile PSI"
        Me.UltimateYieldPSIColumn.Name = "UltimateYieldPSIColumn"
        Me.UltimateYieldPSIColumn.ReadOnly = True
        Me.UltimateYieldPSIColumn.Width = 80
        '
        'Yield2PercentPSIColumn
        '
        Me.Yield2PercentPSIColumn.DataPropertyName = "Yield2PercentPSI"
        Me.Yield2PercentPSIColumn.HeaderText = "Yield PSI"
        Me.Yield2PercentPSIColumn.Name = "Yield2PercentPSIColumn"
        Me.Yield2PercentPSIColumn.ReadOnly = True
        Me.Yield2PercentPSIColumn.Width = 80
        '
        'ReductionPercentColumn
        '
        Me.ReductionPercentColumn.DataPropertyName = "ReductionPercent"
        Me.ReductionPercentColumn.HeaderText = "Reduction %"
        Me.ReductionPercentColumn.Name = "ReductionPercentColumn"
        Me.ReductionPercentColumn.ReadOnly = True
        Me.ReductionPercentColumn.Width = 80
        '
        'Elongation2PercentColumn
        '
        Me.Elongation2PercentColumn.DataPropertyName = "Elongation2Percent"
        Me.Elongation2PercentColumn.HeaderText = "Elongation %"
        Me.Elongation2PercentColumn.Name = "Elongation2PercentColumn"
        Me.Elongation2PercentColumn.ReadOnly = True
        Me.Elongation2PercentColumn.Width = 80
        '
        'NominalDiameterColumn
        '
        Me.NominalDiameterColumn.DataPropertyName = "NominalDiameter"
        Me.NominalDiameterColumn.HeaderText = "Nom. Diameter"
        Me.NominalDiameterColumn.Name = "NominalDiameterColumn"
        Me.NominalDiameterColumn.ReadOnly = True
        Me.NominalDiameterColumn.Width = 80
        '
        'NominalLengthColumn
        '
        Me.NominalLengthColumn.DataPropertyName = "NominalLength"
        Me.NominalLengthColumn.HeaderText = "Nom. Length"
        Me.NominalLengthColumn.Name = "NominalLengthColumn"
        Me.NominalLengthColumn.ReadOnly = True
        Me.NominalLengthColumn.Width = 80
        '
        'TestedByColumn
        '
        Me.TestedByColumn.DataPropertyName = "TestedBy"
        Me.TestedByColumn.HeaderText = "Tested By"
        Me.TestedByColumn.Name = "TestedByColumn"
        Me.TestedByColumn.ReadOnly = True
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.ReadOnly = True
        '
        'OldTestNumberColumn
        '
        Me.OldTestNumberColumn.DataPropertyName = "OldTestNumber"
        Me.OldTestNumberColumn.HeaderText = "Old Test #"
        Me.OldTestNumberColumn.Name = "OldTestNumberColumn"
        Me.OldTestNumberColumn.ReadOnly = True
        '
        'OldPartNumberColumn
        '
        Me.OldPartNumberColumn.DataPropertyName = "OldPartNumber"
        Me.OldPartNumberColumn.HeaderText = "Old Part #"
        Me.OldPartNumberColumn.Name = "OldPartNumberColumn"
        Me.OldPartNumberColumn.ReadOnly = True
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        '
        'Yield2PercentPoundColumn
        '
        Me.Yield2PercentPoundColumn.DataPropertyName = "Yield2PercentPound"
        Me.Yield2PercentPoundColumn.HeaderText = "Yield 0.2% Pound"
        Me.Yield2PercentPoundColumn.Name = "Yield2PercentPoundColumn"
        Me.Yield2PercentPoundColumn.ReadOnly = True
        '
        'UltimateYieldPoundColumn
        '
        Me.UltimateYieldPoundColumn.DataPropertyName = "UltimateYieldPound"
        Me.UltimateYieldPoundColumn.HeaderText = "Ultimate Yield Pound"
        Me.UltimateYieldPoundColumn.Name = "UltimateYieldPoundColumn"
        Me.UltimateYieldPoundColumn.ReadOnly = True
        '
        'Elongation2InchColumn
        '
        Me.Elongation2InchColumn.DataPropertyName = "Elongation2Inch"
        Me.Elongation2InchColumn.HeaderText = "Elongation 2 Inch"
        Me.Elongation2InchColumn.Name = "Elongation2InchColumn"
        Me.Elongation2InchColumn.ReadOnly = True
        '
        'Reduction2InchColumn
        '
        Me.Reduction2InchColumn.DataPropertyName = "Reduction2Inch"
        Me.Reduction2InchColumn.HeaderText = "Reduction 2 Inch"
        Me.Reduction2InchColumn.Name = "Reduction2InchColumn"
        Me.Reduction2InchColumn.ReadOnly = True
        '
        'TorqueFootPoundsColumn
        '
        Me.TorqueFootPoundsColumn.DataPropertyName = "TorqueFootPounds"
        Me.TorqueFootPoundsColumn.HeaderText = "Torque Foot Pounds"
        Me.TorqueFootPoundsColumn.Name = "TorqueFootPoundsColumn"
        Me.TorqueFootPoundsColumn.ReadOnly = True
        '
        'BreakLocationColumn
        '
        Me.BreakLocationColumn.DataPropertyName = "BreakLocation"
        Me.BreakLocationColumn.HeaderText = "Break Location"
        Me.BreakLocationColumn.Name = "BreakLocationColumn"
        Me.BreakLocationColumn.ReadOnly = True
        '
        'BendTestColumn
        '
        Me.BendTestColumn.DataPropertyName = "BendTest"
        Me.BendTestColumn.HeaderText = "Bend Test"
        Me.BendTestColumn.Name = "BendTestColumn"
        Me.BendTestColumn.ReadOnly = True
        '
        'CertCodeColumn
        '
        Me.CertCodeColumn.DataPropertyName = "CertCode"
        Me.CertCodeColumn.HeaderText = "Cert Code"
        Me.CertCodeColumn.Name = "CertCodeColumn"
        Me.CertCodeColumn.ReadOnly = True
        '
        'ItemClassColumn
        '
        Me.ItemClassColumn.DataPropertyName = "ItemClass"
        Me.ItemClassColumn.HeaderText = "Item Class"
        Me.ItemClassColumn.Name = "ItemClassColumn"
        '
        'ProcessTypeColumn
        '
        Me.ProcessTypeColumn.DataPropertyName = "ProcessType"
        Me.ProcessTypeColumn.HeaderText = "ProcessType"
        Me.ProcessTypeColumn.Name = "ProcessTypeColumn"
        Me.ProcessTypeColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        Me.RMIDColumn.Visible = False
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Steel Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        Me.DescriptionColumn.ReadOnly = True
        Me.DescriptionColumn.Visible = False
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ViewPullTests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.dgvPullTestQuery)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.gpxViewBy)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewPullTests"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Pull Tests"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PullTestQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxViewBy.ResumeLayout(False)
        Me.gpxViewBy.PerformLayout()
        CType(Me.dgvPullTestQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdOpenForm As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboPullTestNumber As System.Windows.Forms.ComboBox
    Friend WithEvents gpxViewBy As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents cboCertCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PullTestQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PullTestQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PullTestQueryTableAdapter
    Friend WithEvents dgvPullTestQuery As System.Windows.Forms.DataGridView
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TestNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PullTestLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrossSectionalAreaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UltimateYieldPSIColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Yield2PercentPSIColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReductionPercentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Elongation2PercentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalDiameterColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalLengthColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestedByColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OldTestNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OldPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Yield2PercentPoundColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UltimateYieldPoundColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Elongation2InchColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reduction2InchColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TorqueFootPoundsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BreakLocationColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BendTestColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
End Class
