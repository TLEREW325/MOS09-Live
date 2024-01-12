<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewQCNonConformance
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
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintQCHoldListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxQuotationFilter = New System.Windows.Forms.GroupBox
        Me.chkTrufit = New System.Windows.Forms.CheckBox
        Me.chkTruweld = New System.Windows.Forms.CheckBox
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvQCHoldAdjustment = New System.Windows.Forms.DataGridView
        Me.QCHoldAdjustmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.QCHoldAdjustmentTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.QCHoldAdjustmentTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.cmdOpenQCHold = New System.Windows.Forms.Button
        Me.QCTransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QCDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityOnHoldColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReworkHoursColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CorrectiveActionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentActionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NonConformanceReasonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReworkInstructionsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QCAgentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApprovedByColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApprovalDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineOperator = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MachineNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LongDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.gpxQuotationFilter.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvQCHoldAdjustment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QCHoldAdjustmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintQCHoldListingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintQCHoldListingToolStripMenuItem
        '
        Me.PrintQCHoldListingToolStripMenuItem.Name = "PrintQCHoldListingToolStripMenuItem"
        Me.PrintQCHoldListingToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PrintQCHoldListingToolStripMenuItem.Text = "Print QC Hold Listing"
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
        'gpxQuotationFilter
        '
        Me.gpxQuotationFilter.Controls.Add(Me.chkTrufit)
        Me.gpxQuotationFilter.Controls.Add(Me.chkTruweld)
        Me.gpxQuotationFilter.Controls.Add(Me.cboLotNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.Label7)
        Me.gpxQuotationFilter.Controls.Add(Me.Label14)
        Me.gpxQuotationFilter.Controls.Add(Me.chkDateRange)
        Me.gpxQuotationFilter.Controls.Add(Me.Label12)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpEndDate)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPartDescription)
        Me.gpxQuotationFilter.Controls.Add(Me.Label9)
        Me.gpxQuotationFilter.Controls.Add(Me.cboFOXNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.dtpBeginDate)
        Me.gpxQuotationFilter.Controls.Add(Me.Label8)
        Me.gpxQuotationFilter.Controls.Add(Me.Label1)
        Me.gpxQuotationFilter.Controls.Add(Me.cboStatus)
        Me.gpxQuotationFilter.Controls.Add(Me.Label6)
        Me.gpxQuotationFilter.Controls.Add(Me.cboPartNumber)
        Me.gpxQuotationFilter.Controls.Add(Me.Label3)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdClear)
        Me.gpxQuotationFilter.Controls.Add(Me.cmdView)
        Me.gpxQuotationFilter.Location = New System.Drawing.Point(29, 41)
        Me.gpxQuotationFilter.Name = "gpxQuotationFilter"
        Me.gpxQuotationFilter.Size = New System.Drawing.Size(300, 770)
        Me.gpxQuotationFilter.TabIndex = 0
        Me.gpxQuotationFilter.TabStop = False
        Me.gpxQuotationFilter.Text = "View By Filters"
        '
        'chkTrufit
        '
        Me.chkTrufit.AutoSize = True
        Me.chkTrufit.Location = New System.Drawing.Point(22, 465)
        Me.chkTrufit.Name = "chkTrufit"
        Me.chkTrufit.Size = New System.Drawing.Size(143, 17)
        Me.chkTrufit.TabIndex = 7
        Me.chkTrufit.Text = "Show only TRUFIT parts"
        Me.chkTrufit.UseVisualStyleBackColor = True
        '
        'chkTruweld
        '
        Me.chkTruweld.AutoSize = True
        Me.chkTruweld.Location = New System.Drawing.Point(22, 420)
        Me.chkTruweld.Name = "chkTruweld"
        Me.chkTruweld.Size = New System.Drawing.Size(159, 17)
        Me.chkTruweld.TabIndex = 6
        Me.chkTruweld.Text = "Show only TRUWELD parts"
        Me.chkTruweld.UseVisualStyleBackColor = True
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(92, 255)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(194, 21)
        Me.cboLotNumber.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(19, 255)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 20)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "LOT #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(16, 583)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(109, 619)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 8
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(18, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(267, 40)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(106, 683)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(18, 136)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(267, 21)
        Me.cboPartDescription.TabIndex = 2
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
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 683)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "End Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(91, 207)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(194, 21)
        Me.cboFOXNumber.TabIndex = 3
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(106, 650)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 650)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Begin Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 207)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "FOX #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "CLOSED"})
        Me.cboStatus.Location = New System.Drawing.Point(92, 303)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(194, 21)
        Me.cboStatus.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 303)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 20)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "QC Status"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(56, 106)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(229, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Part #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 724)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(139, 724)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 11
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 776)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 13
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 776)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvQCHoldAdjustment
        '
        Me.dgvQCHoldAdjustment.AllowUserToAddRows = False
        Me.dgvQCHoldAdjustment.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvQCHoldAdjustment.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvQCHoldAdjustment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvQCHoldAdjustment.AutoGenerateColumns = False
        Me.dgvQCHoldAdjustment.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvQCHoldAdjustment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvQCHoldAdjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQCHoldAdjustment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QCTransactionNumberColumn, Me.QCDateColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityOnHoldColumn, Me.LotNumberColumn, Me.FOXNumberColumn, Me.ReworkHoursColumn, Me.CorrectiveActionColumn, Me.AdjustmentActionColumn, Me.NonConformanceReasonColumn, Me.ReworkInstructionsColumn, Me.CommentColumn, Me.QCAgentColumn, Me.ApprovedByColumn, Me.ApprovalDateColumn, Me.MachineOperator, Me.MachineNumber, Me.StatusColumn, Me.LongDescriptionColumn})
        Me.dgvQCHoldAdjustment.DataSource = Me.QCHoldAdjustmentBindingSource
        Me.dgvQCHoldAdjustment.GridColor = System.Drawing.Color.Blue
        Me.dgvQCHoldAdjustment.Location = New System.Drawing.Point(344, 41)
        Me.dgvQCHoldAdjustment.Name = "dgvQCHoldAdjustment"
        Me.dgvQCHoldAdjustment.Size = New System.Drawing.Size(686, 714)
        Me.dgvQCHoldAdjustment.TabIndex = 21
        Me.dgvQCHoldAdjustment.TabStop = False
        '
        'QCHoldAdjustmentBindingSource
        '
        Me.QCHoldAdjustmentBindingSource.DataMember = "QCHoldAdjustment"
        Me.QCHoldAdjustmentBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'QCHoldAdjustmentTableAdapter
        '
        Me.QCHoldAdjustmentTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'cmdOpenQCHold
        '
        Me.cmdOpenQCHold.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenQCHold.ForeColor = System.Drawing.Color.Blue
        Me.cmdOpenQCHold.Location = New System.Drawing.Point(344, 776)
        Me.cmdOpenQCHold.Name = "cmdOpenQCHold"
        Me.cmdOpenQCHold.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenQCHold.TabIndex = 22
        Me.cmdOpenQCHold.Text = "Open QC Hold"
        Me.cmdOpenQCHold.UseVisualStyleBackColor = True
        '
        'QCTransactionNumberColumn
        '
        Me.QCTransactionNumberColumn.DataPropertyName = "QCTransactionNumber"
        Me.QCTransactionNumberColumn.HeaderText = "Trans. #"
        Me.QCTransactionNumberColumn.Name = "QCTransactionNumberColumn"
        Me.QCTransactionNumberColumn.ReadOnly = True
        Me.QCTransactionNumberColumn.Width = 80
        '
        'QCDateColumn
        '
        Me.QCDateColumn.DataPropertyName = "QCDate"
        Me.QCDateColumn.HeaderText = "Date"
        Me.QCDateColumn.Name = "QCDateColumn"
        Me.QCDateColumn.ReadOnly = True
        Me.QCDateColumn.Width = 80
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
        'QuantityOnHoldColumn
        '
        Me.QuantityOnHoldColumn.DataPropertyName = "QuantityOnHold"
        Me.QuantityOnHoldColumn.HeaderText = "Qty On Hold"
        Me.QuantityOnHoldColumn.Name = "QuantityOnHoldColumn"
        Me.QuantityOnHoldColumn.ReadOnly = True
        Me.QuantityOnHoldColumn.Width = 80
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot #"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        Me.LotNumberColumn.ReadOnly = True
        Me.LotNumberColumn.Width = 80
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        Me.FOXNumberColumn.Width = 80
        '
        'ReworkHoursColumn
        '
        Me.ReworkHoursColumn.DataPropertyName = "ReworkHours"
        Me.ReworkHoursColumn.HeaderText = "Rework Hours"
        Me.ReworkHoursColumn.Name = "ReworkHoursColumn"
        Me.ReworkHoursColumn.Width = 80
        '
        'CorrectiveActionColumn
        '
        Me.CorrectiveActionColumn.DataPropertyName = "CorrectiveAction"
        Me.CorrectiveActionColumn.HeaderText = "Corrective Action"
        Me.CorrectiveActionColumn.Name = "CorrectiveActionColumn"
        '
        'AdjustmentActionColumn
        '
        Me.AdjustmentActionColumn.DataPropertyName = "AdjustmentAction"
        Me.AdjustmentActionColumn.HeaderText = "Adjustment Action"
        Me.AdjustmentActionColumn.Name = "AdjustmentActionColumn"
        '
        'NonConformanceReasonColumn
        '
        Me.NonConformanceReasonColumn.DataPropertyName = "NonConformanceReason"
        Me.NonConformanceReasonColumn.HeaderText = "NonConformance Reason"
        Me.NonConformanceReasonColumn.Name = "NonConformanceReasonColumn"
        '
        'ReworkInstructionsColumn
        '
        Me.ReworkInstructionsColumn.DataPropertyName = "ReworkInstructions"
        Me.ReworkInstructionsColumn.HeaderText = "Rework Instructions"
        Me.ReworkInstructionsColumn.Name = "ReworkInstructionsColumn"
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'QCAgentColumn
        '
        Me.QCAgentColumn.DataPropertyName = "QCAgent"
        Me.QCAgentColumn.HeaderText = "QC Agent"
        Me.QCAgentColumn.Name = "QCAgentColumn"
        '
        'ApprovedByColumn
        '
        Me.ApprovedByColumn.DataPropertyName = "ApprovedBy"
        Me.ApprovedByColumn.HeaderText = "Approved By"
        Me.ApprovedByColumn.Name = "ApprovedByColumn"
        '
        'ApprovalDateColumn
        '
        Me.ApprovalDateColumn.DataPropertyName = "ApprovalDate"
        Me.ApprovalDateColumn.HeaderText = "Approval Date"
        Me.ApprovalDateColumn.Name = "ApprovalDateColumn"
        '
        'MachineOperator
        '
        Me.MachineOperator.DataPropertyName = "MachineOperator"
        Me.MachineOperator.HeaderText = "Machine Operator"
        Me.MachineOperator.Name = "MachineOperator"
        '
        'MachineNumber
        '
        Me.MachineNumber.DataPropertyName = "MachineNumber"
        Me.MachineNumber.HeaderText = "Machine Number"
        Me.MachineNumber.Name = "MachineNumber"
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        '
        'LongDescriptionColumn
        '
        Me.LongDescriptionColumn.DataPropertyName = "LongDescription"
        Me.LongDescriptionColumn.HeaderText = "LongDescription"
        Me.LongDescriptionColumn.Name = "LongDescriptionColumn"
        Me.LongDescriptionColumn.Visible = False
        '
        'ViewQCNonConformance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdOpenQCHold)
        Me.Controls.Add(Me.dgvQCHoldAdjustment)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxQuotationFilter)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewQCNonConformance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View TFP Corporation Quality Control Non-Conformance Listing"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxQuotationFilter.ResumeLayout(False)
        Me.gpxQuotationFilter.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvQCHoldAdjustment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QCHoldAdjustmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxQuotationFilter As System.Windows.Forms.GroupBox
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvQCHoldAdjustment As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents QCHoldAdjustmentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents QCHoldAdjustmentTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.QCHoldAdjustmentTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents chkTrufit As System.Windows.Forms.CheckBox
    Friend WithEvents chkTruweld As System.Windows.Forms.CheckBox
    Friend WithEvents PrintQCHoldListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdOpenQCHold As System.Windows.Forms.Button
    Friend WithEvents QCTransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QCDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityOnHoldColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReworkHoursColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CorrectiveActionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentActionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NonConformanceReasonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReworkInstructionsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QCAgentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovedByColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprovalDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineOperator As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MachineNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
