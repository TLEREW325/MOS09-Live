<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewRackingActivityLog
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPickTicketNumber = New System.Windows.Forms.TextBox
        Me.chkSLCParts = New System.Windows.Forms.CheckBox
        Me.chkTrufit = New System.Windows.Forms.CheckBox
        Me.chkTruweld = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboLotNumber = New System.Windows.Forms.ComboBox
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cboHeatNumber = New System.Windows.Forms.ComboBox
        Me.HeatNumberLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboBinNumber = New System.Windows.Forms.ComboBox
        Me.BinNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dgvRackingActivityLog = New System.Windows.Forms.DataGridView
        Me.TFPRackingActivityLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.BinNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinNumberTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.TFPRackingActivityLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TFPRackingActivityLogTableAdapter
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.BinNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OriginalTotalPiecesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurrentTotalPiecesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalPiecesDifferenceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoginComputerColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ActivityDateTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackTimeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RackDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickTicketNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BinNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRackingActivityLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFPRackingActivityLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPickTicketNumber)
        Me.GroupBox1.Controls.Add(Me.chkSLCParts)
        Me.GroupBox1.Controls.Add(Me.chkTrufit)
        Me.GroupBox1.Controls.Add(Me.chkTruweld)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmdView)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cboLotNumber)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkDateRange)
        Me.GroupBox1.Controls.Add(Me.dtpEndDate)
        Me.GroupBox1.Controls.Add(Me.dtpBeginDate)
        Me.GroupBox1.Controls.Add(Me.cboHeatNumber)
        Me.GroupBox1.Controls.Add(Me.cboPartDescription)
        Me.GroupBox1.Controls.Add(Me.cboBinNumber)
        Me.GroupBox1.Controls.Add(Me.cboPartNumber)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 770)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View By Filters"
        '
        'txtPickTicketNumber
        '
        Me.txtPickTicketNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPickTicketNumber.Location = New System.Drawing.Point(98, 467)
        Me.txtPickTicketNumber.Name = "txtPickTicketNumber"
        Me.txtPickTicketNumber.Size = New System.Drawing.Size(184, 20)
        Me.txtPickTicketNumber.TabIndex = 8
        '
        'chkSLCParts
        '
        Me.chkSLCParts.AutoSize = True
        Me.chkSLCParts.Location = New System.Drawing.Point(17, 130)
        Me.chkSLCParts.Name = "chkSLCParts"
        Me.chkSLCParts.Size = New System.Drawing.Size(73, 17)
        Me.chkSLCParts.TabIndex = 39
        Me.chkSLCParts.Text = "SLC Parts"
        Me.chkSLCParts.UseVisualStyleBackColor = True
        '
        'chkTrufit
        '
        Me.chkTrufit.AutoSize = True
        Me.chkTrufit.Location = New System.Drawing.Point(17, 88)
        Me.chkTrufit.Name = "chkTrufit"
        Me.chkTrufit.Size = New System.Drawing.Size(77, 17)
        Me.chkTrufit.TabIndex = 2
        Me.chkTrufit.Text = "Trufit Parts"
        Me.chkTrufit.UseVisualStyleBackColor = True
        '
        'chkTruweld
        '
        Me.chkTruweld.AutoSize = True
        Me.chkTruweld.Location = New System.Drawing.Point(17, 46)
        Me.chkTruweld.Name = "chkTruweld"
        Me.chkTruweld.Size = New System.Drawing.Size(91, 17)
        Me.chkTruweld.TabIndex = 1
        Me.chkTruweld.Text = "Truweld Parts"
        Me.chkTruweld.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(18, 568)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(131, 721)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 12
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(211, 721)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboLotNumber
        '
        Me.cboLotNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotNumber.DataSource = Me.LotNumberBindingSource
        Me.cboLotNumber.DisplayMember = "LotNumber"
        Me.cboLotNumber.FormattingEnabled = True
        Me.cboLotNumber.Location = New System.Drawing.Point(71, 286)
        Me.cboLotNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(211, 21)
        Me.cboLotNumber.TabIndex = 5
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lot #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.Location = New System.Drawing.Point(101, 604)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(106, 17)
        Me.chkDateRange.TabIndex = 9
        Me.chkDateRange.Text = "Use Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(102, 681)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpEndDate.TabIndex = 11
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(102, 643)
        Me.dtpBeginDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpBeginDate.TabIndex = 10
        '
        'cboHeatNumber
        '
        Me.cboHeatNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHeatNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHeatNumber.DataSource = Me.HeatNumberLogBindingSource
        Me.cboHeatNumber.DisplayMember = "HeatNumber"
        Me.cboHeatNumber.FormattingEnabled = True
        Me.cboHeatNumber.Location = New System.Drawing.Point(71, 345)
        Me.cboHeatNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(211, 21)
        Me.cboHeatNumber.TabIndex = 6
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartDescription
        '
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(20, 227)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(264, 21)
        Me.cboPartDescription.TabIndex = 4
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboBinNumber
        '
        Me.cboBinNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBinNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBinNumber.DataSource = Me.BinNumberBindingSource
        Me.cboBinNumber.DisplayMember = "BinNumber"
        Me.cboBinNumber.FormattingEnabled = True
        Me.cboBinNumber.Location = New System.Drawing.Point(98, 404)
        Me.cboBinNumber.Margin = New System.Windows.Forms.Padding(5)
        Me.cboBinNumber.Name = "cboBinNumber"
        Me.cboBinNumber.Size = New System.Drawing.Size(184, 21)
        Me.cboBinNumber.TabIndex = 7
        '
        'BinNumberBindingSource
        '
        Me.BinNumberBindingSource.DataMember = "BinNumber"
        Me.BinNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(71, 191)
        Me.cboPartNumber.Margin = New System.Windows.Forms.Padding(5, 5, 5, 3)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(211, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 678)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "End Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 640)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Begin Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(20, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Part #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 345)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Heat #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(20, 405)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Bin Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 467)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Pick Ticket #"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvRackingActivityLog
        '
        Me.dgvRackingActivityLog.AllowUserToAddRows = False
        Me.dgvRackingActivityLog.AllowUserToDeleteRows = False
        Me.dgvRackingActivityLog.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvRackingActivityLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRackingActivityLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRackingActivityLog.AutoGenerateColumns = False
        Me.dgvRackingActivityLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRackingActivityLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvRackingActivityLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRackingActivityLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BinNumberDataGridViewTextBoxColumn, Me.PartNumberDataGridViewTextBoxColumn, Me.HeatNumberDataGridViewTextBoxColumn, Me.LotNumberDataGridViewTextBoxColumn, Me.OriginalTotalPiecesDataGridViewTextBoxColumn, Me.CurrentTotalPiecesDataGridViewTextBoxColumn, Me.TotalPiecesDifferenceDataGridViewTextBoxColumn, Me.TransactionTypeDataGridViewTextBoxColumn, Me.UserIDDataGridViewTextBoxColumn, Me.LoginComputerColumn, Me.ActivityDateTimeDataGridViewTextBoxColumn, Me.RackTimeColumn, Me.RackDateColumn, Me.DivisionIDDataGridViewTextBoxColumn, Me.PickTicketNumberColumn})
        Me.dgvRackingActivityLog.DataSource = Me.TFPRackingActivityLogBindingSource
        Me.dgvRackingActivityLog.GridColor = System.Drawing.Color.Teal
        Me.dgvRackingActivityLog.Location = New System.Drawing.Point(346, 41)
        Me.dgvRackingActivityLog.Name = "dgvRackingActivityLog"
        Me.dgvRackingActivityLog.ReadOnly = True
        Me.dgvRackingActivityLog.Size = New System.Drawing.Size(784, 720)
        Me.dgvRackingActivityLog.TabIndex = 2
        '
        'TFPRackingActivityLogBindingSource
        '
        Me.TFPRackingActivityLogBindingSource.DataMember = "TFPRackingActivityLog"
        Me.TFPRackingActivityLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 13
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'BinNumberTableAdapter
        '
        Me.BinNumberTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'TFPRackingActivityLogTableAdapter
        '
        Me.TFPRackingActivityLogTableAdapter.ClearBeforeFill = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 5
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
        'BinNumberDataGridViewTextBoxColumn
        '
        Me.BinNumberDataGridViewTextBoxColumn.DataPropertyName = "BinNumber"
        Me.BinNumberDataGridViewTextBoxColumn.HeaderText = "Bin #"
        Me.BinNumberDataGridViewTextBoxColumn.Name = "BinNumberDataGridViewTextBoxColumn"
        Me.BinNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.BinNumberDataGridViewTextBoxColumn.Width = 65
        '
        'PartNumberDataGridViewTextBoxColumn
        '
        Me.PartNumberDataGridViewTextBoxColumn.DataPropertyName = "PartNumber"
        Me.PartNumberDataGridViewTextBoxColumn.HeaderText = "Part #"
        Me.PartNumberDataGridViewTextBoxColumn.Name = "PartNumberDataGridViewTextBoxColumn"
        Me.PartNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.PartNumberDataGridViewTextBoxColumn.Width = 120
        '
        'HeatNumberDataGridViewTextBoxColumn
        '
        Me.HeatNumberDataGridViewTextBoxColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberDataGridViewTextBoxColumn.HeaderText = "Heat #"
        Me.HeatNumberDataGridViewTextBoxColumn.Name = "HeatNumberDataGridViewTextBoxColumn"
        Me.HeatNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LotNumberDataGridViewTextBoxColumn
        '
        Me.LotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber"
        Me.LotNumberDataGridViewTextBoxColumn.HeaderText = "Lot #"
        Me.LotNumberDataGridViewTextBoxColumn.Name = "LotNumberDataGridViewTextBoxColumn"
        Me.LotNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OriginalTotalPiecesDataGridViewTextBoxColumn
        '
        Me.OriginalTotalPiecesDataGridViewTextBoxColumn.DataPropertyName = "OriginalTotalPieces"
        Me.OriginalTotalPiecesDataGridViewTextBoxColumn.HeaderText = "Original Pieces"
        Me.OriginalTotalPiecesDataGridViewTextBoxColumn.Name = "OriginalTotalPiecesDataGridViewTextBoxColumn"
        Me.OriginalTotalPiecesDataGridViewTextBoxColumn.ReadOnly = True
        Me.OriginalTotalPiecesDataGridViewTextBoxColumn.Width = 90
        '
        'CurrentTotalPiecesDataGridViewTextBoxColumn
        '
        Me.CurrentTotalPiecesDataGridViewTextBoxColumn.DataPropertyName = "CurrentTotalPieces"
        Me.CurrentTotalPiecesDataGridViewTextBoxColumn.HeaderText = "Current Pieces"
        Me.CurrentTotalPiecesDataGridViewTextBoxColumn.Name = "CurrentTotalPiecesDataGridViewTextBoxColumn"
        Me.CurrentTotalPiecesDataGridViewTextBoxColumn.ReadOnly = True
        Me.CurrentTotalPiecesDataGridViewTextBoxColumn.Width = 90
        '
        'TotalPiecesDifferenceDataGridViewTextBoxColumn
        '
        Me.TotalPiecesDifferenceDataGridViewTextBoxColumn.DataPropertyName = "TotalPiecesDifference"
        Me.TotalPiecesDifferenceDataGridViewTextBoxColumn.HeaderText = "Difference"
        Me.TotalPiecesDifferenceDataGridViewTextBoxColumn.Name = "TotalPiecesDifferenceDataGridViewTextBoxColumn"
        Me.TotalPiecesDifferenceDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalPiecesDifferenceDataGridViewTextBoxColumn.Width = 90
        '
        'TransactionTypeDataGridViewTextBoxColumn
        '
        Me.TransactionTypeDataGridViewTextBoxColumn.DataPropertyName = "TransactionType"
        Me.TransactionTypeDataGridViewTextBoxColumn.HeaderText = "Transaction Type"
        Me.TransactionTypeDataGridViewTextBoxColumn.Name = "TransactionTypeDataGridViewTextBoxColumn"
        Me.TransactionTypeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UserIDDataGridViewTextBoxColumn
        '
        Me.UserIDDataGridViewTextBoxColumn.DataPropertyName = "UserID"
        Me.UserIDDataGridViewTextBoxColumn.HeaderText = "User"
        Me.UserIDDataGridViewTextBoxColumn.Name = "UserIDDataGridViewTextBoxColumn"
        Me.UserIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LoginComputerColumn
        '
        Me.LoginComputerColumn.DataPropertyName = "LoginComputer"
        Me.LoginComputerColumn.HeaderText = "Login PC"
        Me.LoginComputerColumn.Name = "LoginComputerColumn"
        Me.LoginComputerColumn.ReadOnly = True
        '
        'ActivityDateTimeDataGridViewTextBoxColumn
        '
        Me.ActivityDateTimeDataGridViewTextBoxColumn.DataPropertyName = "ActivityDateTime"
        Me.ActivityDateTimeDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.ActivityDateTimeDataGridViewTextBoxColumn.Name = "ActivityDateTimeDataGridViewTextBoxColumn"
        Me.ActivityDateTimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RackTimeColumn
        '
        Me.RackTimeColumn.DataPropertyName = "RackTime"
        Me.RackTimeColumn.HeaderText = "Rack Time"
        Me.RackTimeColumn.Name = "RackTimeColumn"
        Me.RackTimeColumn.ReadOnly = True
        '
        'RackDateColumn
        '
        Me.RackDateColumn.DataPropertyName = "RackDate"
        Me.RackDateColumn.HeaderText = "Rack Date"
        Me.RackDateColumn.Name = "RackDateColumn"
        Me.RackDateColumn.ReadOnly = True
        '
        'DivisionIDDataGridViewTextBoxColumn
        '
        Me.DivisionIDDataGridViewTextBoxColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDDataGridViewTextBoxColumn.HeaderText = "Division"
        Me.DivisionIDDataGridViewTextBoxColumn.Name = "DivisionIDDataGridViewTextBoxColumn"
        Me.DivisionIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PickTicketNumberColumn
        '
        Me.PickTicketNumberColumn.DataPropertyName = "PickTicketNumber"
        Me.PickTicketNumberColumn.HeaderText = "Pick Ticket #"
        Me.PickTicketNumberColumn.Name = "PickTicketNumberColumn"
        Me.PickTicketNumberColumn.ReadOnly = True
        '
        'ViewRackingActivityLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvRackingActivityLog)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "ViewRackingActivityLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Racking Activity"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BinNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRackingActivityLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFPRackingActivityLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboBinNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvRackingActivityLog As System.Windows.Forms.DataGridView
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents BinNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BinNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.BinNumberTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents chkTrufit As System.Windows.Forms.CheckBox
    Friend WithEvents chkTruweld As System.Windows.Forms.CheckBox
    Friend WithEvents TFPRackingActivityLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TFPRackingActivityLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TFPRackingActivityLogTableAdapter
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkSLCParts As System.Windows.Forms.CheckBox
    Friend WithEvents txtPickTicketNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BinNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OriginalTotalPiecesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrentTotalPiecesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalPiecesDifferenceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoginComputerColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ActivityDateTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackTimeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RackDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickTicketNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
