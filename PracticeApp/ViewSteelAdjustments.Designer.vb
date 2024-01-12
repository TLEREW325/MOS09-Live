<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelAdjustments
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.dgvSteelAdjustments = New System.Windows.Forms.DataGridView
        Me.AdjustmentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelAdjustmentKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelAdjustmentTableBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.gpxReturnSearchData = New System.Windows.Forms.GroupBox
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.SteelAdjustmentTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cboAdjustmentNumber = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtpBegin = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdSteelAdjustment = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.SteelAdjustmentTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelAdjustmentTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvSteelAdjustments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelAdjustmentTableBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxReturnSearchData.SuspendLayout()
        CType(Me.SteelAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 11
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(961, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(884, 772)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 13
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'dgvSteelAdjustments
        '
        Me.dgvSteelAdjustments.AllowUserToAddRows = False
        Me.dgvSteelAdjustments.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSteelAdjustments.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSteelAdjustments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelAdjustments.AutoGenerateColumns = False
        Me.dgvSteelAdjustments.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelAdjustments.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelAdjustments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelAdjustments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AdjustmentDateColumn, Me.SteelAdjustmentKeyColumn, Me.BatchNumberColumn, Me.SteelCarbonColumn, Me.SteelSizeColumn, Me.AdjustmentWeightColumn, Me.AdjustmentCostColumn, Me.AdjustmentTotalColumn, Me.CommentColumn, Me.StatusColumn, Me.RMIDColumn, Me.DivisionIDColumn})
        Me.dgvSteelAdjustments.DataSource = Me.SteelAdjustmentTableBindingSource1
        Me.dgvSteelAdjustments.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSteelAdjustments.Location = New System.Drawing.Point(346, 41)
        Me.dgvSteelAdjustments.Name = "dgvSteelAdjustments"
        Me.dgvSteelAdjustments.Size = New System.Drawing.Size(686, 722)
        Me.dgvSteelAdjustments.TabIndex = 15
        Me.dgvSteelAdjustments.TabStop = False
        '
        'AdjustmentDateColumn
        '
        Me.AdjustmentDateColumn.DataPropertyName = "AdjustmentDate"
        Me.AdjustmentDateColumn.HeaderText = "Date"
        Me.AdjustmentDateColumn.Name = "AdjustmentDateColumn"
        Me.AdjustmentDateColumn.Width = 85
        '
        'SteelAdjustmentKeyColumn
        '
        Me.SteelAdjustmentKeyColumn.DataPropertyName = "SteelAdjustmentKey"
        Me.SteelAdjustmentKeyColumn.HeaderText = "Adj. #"
        Me.SteelAdjustmentKeyColumn.Name = "SteelAdjustmentKeyColumn"
        Me.SteelAdjustmentKeyColumn.Width = 85
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "Batch #"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Width = 85
        '
        'SteelCarbonColumn
        '
        Me.SteelCarbonColumn.DataPropertyName = "SteelCarbon"
        Me.SteelCarbonColumn.HeaderText = "Carbon/Alloy"
        Me.SteelCarbonColumn.Name = "SteelCarbonColumn"
        Me.SteelCarbonColumn.Width = 85
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Steel Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.Width = 85
        '
        'AdjustmentWeightColumn
        '
        Me.AdjustmentWeightColumn.DataPropertyName = "AdjustmentWeight"
        Me.AdjustmentWeightColumn.HeaderText = "Weight"
        Me.AdjustmentWeightColumn.Name = "AdjustmentWeightColumn"
        Me.AdjustmentWeightColumn.Width = 85
        '
        'AdjustmentCostColumn
        '
        Me.AdjustmentCostColumn.DataPropertyName = "AdjustmentCost"
        Me.AdjustmentCostColumn.HeaderText = "Cost"
        Me.AdjustmentCostColumn.Name = "AdjustmentCostColumn"
        Me.AdjustmentCostColumn.Width = 85
        '
        'AdjustmentTotalColumn
        '
        Me.AdjustmentTotalColumn.DataPropertyName = "AdjustmentTotal"
        Me.AdjustmentTotalColumn.HeaderText = "Total"
        Me.AdjustmentTotalColumn.Name = "AdjustmentTotalColumn"
        Me.AdjustmentTotalColumn.Width = 85
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        Me.CommentColumn.Width = 120
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.Visible = False
        Me.RMIDColumn.Width = 53
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        Me.DivisionIDColumn.Width = 54
        '
        'SteelAdjustmentTableBindingSource1
        '
        Me.SteelAdjustmentTableBindingSource1.DataMember = "SteelAdjustmentTable"
        Me.SteelAdjustmentTableBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gpxReturnSearchData
        '
        Me.gpxReturnSearchData.Controls.Add(Me.chkAllTypes)
        Me.gpxReturnSearchData.Controls.Add(Me.Label4)
        Me.gpxReturnSearchData.Controls.Add(Me.cboBatchNumber)
        Me.gpxReturnSearchData.Controls.Add(Me.Label10)
        Me.gpxReturnSearchData.Controls.Add(Me.Label14)
        Me.gpxReturnSearchData.Controls.Add(Me.chkDateRange)
        Me.gpxReturnSearchData.Controls.Add(Me.cboAdjustmentNumber)
        Me.gpxReturnSearchData.Controls.Add(Me.Label12)
        Me.gpxReturnSearchData.Controls.Add(Me.cboCarbon)
        Me.gpxReturnSearchData.Controls.Add(Me.dtpEnd)
        Me.gpxReturnSearchData.Controls.Add(Me.cboSteelSize)
        Me.gpxReturnSearchData.Controls.Add(Me.Label9)
        Me.gpxReturnSearchData.Controls.Add(Me.dtpBegin)
        Me.gpxReturnSearchData.Controls.Add(Me.Label3)
        Me.gpxReturnSearchData.Controls.Add(Me.Label2)
        Me.gpxReturnSearchData.Controls.Add(Me.Label1)
        Me.gpxReturnSearchData.Controls.Add(Me.cmdView)
        Me.gpxReturnSearchData.Controls.Add(Me.cmdClear)
        Me.gpxReturnSearchData.Location = New System.Drawing.Point(29, 41)
        Me.gpxReturnSearchData.Name = "gpxReturnSearchData"
        Me.gpxReturnSearchData.Size = New System.Drawing.Size(300, 610)
        Me.gpxReturnSearchData.TabIndex = 0
        Me.gpxReturnSearchData.TabStop = False
        Me.gpxReturnSearchData.Text = "View By Filters"
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(104, 130)
        Me.chkAllTypes.Margin = New System.Windows.Forms.Padding(5)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(168, 17)
        Me.chkAllTypes.TabIndex = 75
        Me.chkAllTypes.Text = "Show all types for given grade"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(21, 280)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 20)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Batch #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBatchNumber.DataSource = Me.SteelAdjustmentTableBindingSource
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(104, 279)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(181, 21)
        Me.cboBatchNumber.TabIndex = 5
        '
        'SteelAdjustmentTableBindingSource
        '
        Me.SteelAdjustmentTableBindingSource.DataMember = "SteelAdjustmentTable"
        Me.SteelAdjustmentTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(21, 229)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 20)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Adjustment #"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(21, 429)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(100, 465)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 6
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cboAdjustmentNumber
        '
        Me.cboAdjustmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAdjustmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAdjustmentNumber.DataSource = Me.SteelAdjustmentTableBindingSource
        Me.cboAdjustmentNumber.DisplayMember = "SteelAdjustmentKey"
        Me.cboAdjustmentNumber.FormattingEnabled = True
        Me.cboAdjustmentNumber.Location = New System.Drawing.Point(104, 228)
        Me.cboAdjustmentNumber.Name = "cboAdjustmentNumber"
        Me.cboAdjustmentNumber.Size = New System.Drawing.Size(181, 21)
        Me.cboAdjustmentNumber.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(21, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 40)
        Me.Label12.TabIndex = 49
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
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(104, 79)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(181, 21)
        Me.cboCarbon.TabIndex = 2
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpEnd
        '
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(104, 530)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(181, 20)
        Me.dtpEnd.TabIndex = 8
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(104, 177)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(181, 21)
        Me.cboSteelSize.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 530)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "End Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBegin
        '
        Me.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBegin.Location = New System.Drawing.Point(104, 494)
        Me.dtpBegin.Name = "dtpBegin"
        Me.dtpBegin.Size = New System.Drawing.Size(181, 20)
        Me.dtpBegin.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 494)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Begin Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Carbon"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 178)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Steel Size"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(137, 568)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 9
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 568)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdSteelAdjustment
        '
        Me.cmdSteelAdjustment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSteelAdjustment.ForeColor = System.Drawing.Color.Blue
        Me.cmdSteelAdjustment.Location = New System.Drawing.Point(214, 28)
        Me.cmdSteelAdjustment.Name = "cmdSteelAdjustment"
        Me.cmdSteelAdjustment.Size = New System.Drawing.Size(71, 40)
        Me.cmdSteelAdjustment.TabIndex = 12
        Me.cmdSteelAdjustment.Text = "Steel Adjustment"
        Me.cmdSteelAdjustment.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmdSteelAdjustment)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 724)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 87)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Open Steel Adjustments"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(15, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(190, 33)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Close this form and open adjustment form."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'SteelAdjustmentTableTableAdapter
        '
        Me.SteelAdjustmentTableTableAdapter.ClearBeforeFill = True
        '
        'ViewSteelAdjustments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpxReturnSearchData)
        Me.Controls.Add(Me.dgvSteelAdjustments)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewSteelAdjustments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Adjustments"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvSteelAdjustments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelAdjustmentTableBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxReturnSearchData.ResumeLayout(False)
        Me.gpxReturnSearchData.PerformLayout()
        CType(Me.SteelAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents dgvSteelAdjustments As System.Windows.Forms.DataGridView
    Friend WithEvents gpxReturnSearchData As System.Windows.Forms.GroupBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdSteelAdjustment As System.Windows.Forms.Button
    Friend WithEvents cboAdjustmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpBegin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents SteelAdjustmentTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelAdjustmentTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelAdjustmentTableTableAdapter
    Friend WithEvents SteelAdjustmentTableBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents AdjustmentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelAdjustmentKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
End Class
