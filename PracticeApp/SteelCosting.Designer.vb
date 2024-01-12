<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SteelCosting
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
        Me.PrintReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxReturnSearchData = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.cboReferenceNumber = New System.Windows.Forms.ComboBox
        Me.SteelCostingTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblSteelSize = New System.Windows.Forms.Label
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.lblCarbon = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.SteelCostingTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelCostingTableTableAdapter
        Me.dgvSteelCosting = New System.Windows.Forms.DataGridView
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostPerPoundColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostingQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LowerLimitColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpperLimitColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxReturnSearchData.SuspendLayout()
        CType(Me.SteelCostingTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelCosting, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintReportToolStripMenuItem
        '
        Me.PrintReportToolStripMenuItem.Name = "PrintReportToolStripMenuItem"
        Me.PrintReportToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.PrintReportToolStripMenuItem.Text = "Print Report"
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 10
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 11
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxReturnSearchData
        '
        Me.gpxReturnSearchData.Controls.Add(Me.Label14)
        Me.gpxReturnSearchData.Controls.Add(Me.chkDateRange)
        Me.gpxReturnSearchData.Controls.Add(Me.cboReferenceNumber)
        Me.gpxReturnSearchData.Controls.Add(Me.dtpEndDate)
        Me.gpxReturnSearchData.Controls.Add(Me.Label1)
        Me.gpxReturnSearchData.Controls.Add(Me.dtpBeginDate)
        Me.gpxReturnSearchData.Controls.Add(Me.chkAllTypes)
        Me.gpxReturnSearchData.Controls.Add(Me.Label4)
        Me.gpxReturnSearchData.Controls.Add(Me.cboSteelSize)
        Me.gpxReturnSearchData.Controls.Add(Me.Label5)
        Me.gpxReturnSearchData.Controls.Add(Me.lblSteelSize)
        Me.gpxReturnSearchData.Controls.Add(Me.cboCarbon)
        Me.gpxReturnSearchData.Controls.Add(Me.lblCarbon)
        Me.gpxReturnSearchData.Controls.Add(Me.cmdView)
        Me.gpxReturnSearchData.Controls.Add(Me.cmdClear)
        Me.gpxReturnSearchData.Location = New System.Drawing.Point(12, 41)
        Me.gpxReturnSearchData.Name = "gpxReturnSearchData"
        Me.gpxReturnSearchData.Size = New System.Drawing.Size(300, 467)
        Me.gpxReturnSearchData.TabIndex = 0
        Me.gpxReturnSearchData.TabStop = False
        Me.gpxReturnSearchData.Text = "View By Filter"
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(16, 287)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(100, 323)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 4
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'cboReferenceNumber
        '
        Me.cboReferenceNumber.DataSource = Me.SteelCostingTableBindingSource
        Me.cboReferenceNumber.DisplayMember = "ReferenceNumber"
        Me.cboReferenceNumber.FormattingEnabled = True
        Me.cboReferenceNumber.Location = New System.Drawing.Point(95, 188)
        Me.cboReferenceNumber.Name = "cboReferenceNumber"
        Me.cboReferenceNumber.Size = New System.Drawing.Size(185, 21)
        Me.cboReferenceNumber.TabIndex = 3
        '
        'SteelCostingTableBindingSource
        '
        Me.SteelCostingTableBindingSource.DataMember = "SteelCostingTable"
        Me.SteelCostingTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(99, 382)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpEndDate.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Reference #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(99, 352)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpBeginDate.TabIndex = 5
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(95, 78)
        Me.chkAllTypes.Margin = New System.Windows.Forms.Padding(5)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(168, 17)
        Me.chkAllTypes.TabIndex = 1
        Me.chkAllTypes.Text = "Show all types for given grade"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(14, 352)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Begin Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(95, 117)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(185, 21)
        Me.cboSteelSize.TabIndex = 2
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(14, 382)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "End Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSteelSize
        '
        Me.lblSteelSize.Location = New System.Drawing.Point(15, 117)
        Me.lblSteelSize.Name = "lblSteelSize"
        Me.lblSteelSize.Size = New System.Drawing.Size(100, 20)
        Me.lblSteelSize.TabIndex = 14
        Me.lblSteelSize.Text = "Steel Size"
        Me.lblSteelSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCarbon
        '
        Me.cboCarbon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCarbon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCarbon.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboCarbon.DisplayMember = "Carbon"
        Me.cboCarbon.FormattingEnabled = True
        Me.cboCarbon.Location = New System.Drawing.Point(95, 35)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(185, 21)
        Me.cboCarbon.TabIndex = 0
        '
        'lblCarbon
        '
        Me.lblCarbon.Location = New System.Drawing.Point(15, 34)
        Me.lblCarbon.Name = "lblCarbon"
        Me.lblCarbon.Size = New System.Drawing.Size(100, 20)
        Me.lblCarbon.TabIndex = 10
        Me.lblCarbon.Text = "Carbon"
        Me.lblCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(132, 418)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 7
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(209, 418)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'SteelCostingTableTableAdapter
        '
        Me.SteelCostingTableTableAdapter.ClearBeforeFill = True
        '
        'dgvSteelCosting
        '
        Me.dgvSteelCosting.AllowUserToAddRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSteelCosting.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSteelCosting.AutoGenerateColumns = False
        Me.dgvSteelCosting.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelCosting.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelCosting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelCosting.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RMIDColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.CostingDateColumn, Me.SteelCostPerPoundColumn, Me.CostingQuantityColumn, Me.LowerLimitColumn, Me.UpperLimitColumn, Me.StatusColumn, Me.TransactionNumberColumn, Me.ReferenceNumberColumn, Me.ReferenceLineColumn})
        Me.dgvSteelCosting.DataSource = Me.SteelCostingTableBindingSource
        Me.dgvSteelCosting.Location = New System.Drawing.Point(329, 41)
        Me.dgvSteelCosting.Name = "dgvSteelCosting"
        Me.dgvSteelCosting.ReadOnly = True
        Me.dgvSteelCosting.Size = New System.Drawing.Size(701, 724)
        Me.dgvSteelCosting.TabIndex = 19
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        Me.RMIDColumn.Visible = False
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
        Me.SteelSizeColumn.HeaderText = "Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.ReadOnly = True
        Me.SteelSizeColumn.Width = 120
        '
        'CostingDateColumn
        '
        Me.CostingDateColumn.DataPropertyName = "CostingDate"
        Me.CostingDateColumn.HeaderText = "Date"
        Me.CostingDateColumn.Name = "CostingDateColumn"
        Me.CostingDateColumn.ReadOnly = True
        '
        'SteelCostPerPoundColumn
        '
        Me.SteelCostPerPoundColumn.DataPropertyName = "SteelCostPerPound"
        Me.SteelCostPerPoundColumn.HeaderText = "Cost (lb.)"
        Me.SteelCostPerPoundColumn.Name = "SteelCostPerPoundColumn"
        Me.SteelCostPerPoundColumn.ReadOnly = True
        '
        'CostingQuantityColumn
        '
        Me.CostingQuantityColumn.DataPropertyName = "CostingQuantity"
        Me.CostingQuantityColumn.HeaderText = "Quantity"
        Me.CostingQuantityColumn.Name = "CostingQuantityColumn"
        Me.CostingQuantityColumn.ReadOnly = True
        '
        'LowerLimitColumn
        '
        Me.LowerLimitColumn.DataPropertyName = "LowerLimit"
        Me.LowerLimitColumn.HeaderText = "Lower Limit"
        Me.LowerLimitColumn.Name = "LowerLimitColumn"
        Me.LowerLimitColumn.ReadOnly = True
        '
        'UpperLimitColumn
        '
        Me.UpperLimitColumn.DataPropertyName = "UpperLimit"
        Me.UpperLimitColumn.HeaderText = "Upper Limit"
        Me.UpperLimitColumn.Name = "UpperLimitColumn"
        Me.UpperLimitColumn.ReadOnly = True
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "Transaction #"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.ReadOnly = True
        '
        'ReferenceNumberColumn
        '
        Me.ReferenceNumberColumn.DataPropertyName = "ReferenceNumber"
        Me.ReferenceNumberColumn.HeaderText = "Reference #"
        Me.ReferenceNumberColumn.Name = "ReferenceNumberColumn"
        Me.ReferenceNumberColumn.ReadOnly = True
        '
        'ReferenceLineColumn
        '
        Me.ReferenceLineColumn.DataPropertyName = "ReferenceLine"
        Me.ReferenceLineColumn.HeaderText = "Line #"
        Me.ReferenceLineColumn.Name = "ReferenceLineColumn"
        Me.ReferenceLineColumn.ReadOnly = True
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'SteelCosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.dgvSteelCosting)
        Me.Controls.Add(Me.gpxReturnSearchData)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SteelCosting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Steel Cost Tiers"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxReturnSearchData.ResumeLayout(False)
        Me.gpxReturnSearchData.PerformLayout()
        CType(Me.SteelCostingTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelCosting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxReturnSearchData As System.Windows.Forms.GroupBox
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents lblCarbon As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents PrintReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblSteelSize As System.Windows.Forms.Label
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelCostingTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelCostingTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelCostingTableTableAdapter
    Friend WithEvents dgvSteelCosting As System.Windows.Forms.DataGridView
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostPerPoundColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostingQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LowerLimitColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpperLimitColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents cboReferenceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
