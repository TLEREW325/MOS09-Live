<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInventoryAdjustments
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.gpxViewByPart = New System.Windows.Forms.GroupBox
        Me.cboAdjustmentNumber = New System.Windows.Forms.ComboBox
        Me.InventoryAdjustmentTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboAccountDescription = New System.Windows.Forms.ComboBox
        Me.GLAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkZeroCost = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboInventoryAccount = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.dgvInventoryAdjustments = New System.Windows.Forms.DataGridView
        Me.AdjustmentDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReasonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjustmentAgentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryAdjustmentTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryAdjustmentTableTableAdapter
        Me.cmdOpenAdjustmentForm = New System.Windows.Forms.Button
        Me.GLAccountsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTotalQuantity = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtNumberOfAdjustments = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTotalAdjustments = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.gpxViewByPart.SuspendLayout()
        CType(Me.InventoryAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventoryAdjustments, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 18
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(136, 688)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(150, 20)
        Me.dtpEndDate.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(22, 688)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "End Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(136, 652)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(150, 20)
        Me.dtpBeginDate.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(22, 652)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Begin Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxViewByPart
        '
        Me.gpxViewByPart.Controls.Add(Me.cboAdjustmentNumber)
        Me.gpxViewByPart.Controls.Add(Me.Label10)
        Me.gpxViewByPart.Controls.Add(Me.txtTextFilter)
        Me.gpxViewByPart.Controls.Add(Me.Label9)
        Me.gpxViewByPart.Controls.Add(Me.cboAccountDescription)
        Me.gpxViewByPart.Controls.Add(Me.chkZeroCost)
        Me.gpxViewByPart.Controls.Add(Me.Label14)
        Me.gpxViewByPart.Controls.Add(Me.chkDateRange)
        Me.gpxViewByPart.Controls.Add(Me.txtReason)
        Me.gpxViewByPart.Controls.Add(Me.cboStatus)
        Me.gpxViewByPart.Controls.Add(Me.Label6)
        Me.gpxViewByPart.Controls.Add(Me.cboInventoryAccount)
        Me.gpxViewByPart.Controls.Add(Me.Label5)
        Me.gpxViewByPart.Controls.Add(Me.Label12)
        Me.gpxViewByPart.Controls.Add(Me.cboBatchNumber)
        Me.gpxViewByPart.Controls.Add(Me.cboPartDescription)
        Me.gpxViewByPart.Controls.Add(Me.cboPartNumber)
        Me.gpxViewByPart.Controls.Add(Me.Label4)
        Me.gpxViewByPart.Controls.Add(Me.cboDivisionID)
        Me.gpxViewByPart.Controls.Add(Me.dtpEndDate)
        Me.gpxViewByPart.Controls.Add(Me.Label3)
        Me.gpxViewByPart.Controls.Add(Me.Label2)
        Me.gpxViewByPart.Controls.Add(Me.cmdViewByFilter)
        Me.gpxViewByPart.Controls.Add(Me.cmdClear)
        Me.gpxViewByPart.Controls.Add(Me.dtpBeginDate)
        Me.gpxViewByPart.Controls.Add(Me.Label7)
        Me.gpxViewByPart.Controls.Add(Me.Label1)
        Me.gpxViewByPart.Controls.Add(Me.Label8)
        Me.gpxViewByPart.Location = New System.Drawing.Point(29, 41)
        Me.gpxViewByPart.Name = "gpxViewByPart"
        Me.gpxViewByPart.Size = New System.Drawing.Size(300, 770)
        Me.gpxViewByPart.TabIndex = 0
        Me.gpxViewByPart.TabStop = False
        Me.gpxViewByPart.Text = "View By Filters"
        '
        'cboAdjustmentNumber
        '
        Me.cboAdjustmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAdjustmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAdjustmentNumber.DataSource = Me.InventoryAdjustmentTableBindingSource
        Me.cboAdjustmentNumber.DisplayMember = "AdjustmentNumber"
        Me.cboAdjustmentNumber.FormattingEnabled = True
        Me.cboAdjustmentNumber.Location = New System.Drawing.Point(88, 301)
        Me.cboAdjustmentNumber.Name = "cboAdjustmentNumber"
        Me.cboAdjustmentNumber.Size = New System.Drawing.Size(198, 21)
        Me.cboAdjustmentNumber.TabIndex = 5
        '
        'InventoryAdjustmentTableBindingSource
        '
        Me.InventoryAdjustmentTableBindingSource.DataMember = "InventoryAdjustmentTable"
        Me.InventoryAdjustmentTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(22, 302)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Adjust. #"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(88, 343)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(198, 20)
        Me.txtTextFilter.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(22, 343)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Text Filter"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAccountDescription
        '
        Me.cboAccountDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountDescription.DataSource = Me.GLAccountsBindingSource
        Me.cboAccountDescription.DisplayMember = "GLAccountShortDescription"
        Me.cboAccountDescription.FormattingEnabled = True
        Me.cboAccountDescription.Location = New System.Drawing.Point(28, 242)
        Me.cboAccountDescription.Name = "cboAccountDescription"
        Me.cboAccountDescription.Size = New System.Drawing.Size(258, 21)
        Me.cboAccountDescription.TabIndex = 4
        '
        'GLAccountsBindingSource
        '
        Me.GLAccountsBindingSource.DataMember = "GLAccounts"
        Me.GLAccountsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'chkZeroCost
        '
        Me.chkZeroCost.AutoSize = True
        Me.chkZeroCost.Location = New System.Drawing.Point(88, 522)
        Me.chkZeroCost.Name = "chkZeroCost"
        Me.chkZeroCost.Size = New System.Drawing.Size(182, 17)
        Me.chkZeroCost.TabIndex = 10
        Me.chkZeroCost.Text = "Check to view adj. with zero cost"
        Me.chkZeroCost.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(22, 587)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(136, 623)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 11
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'txtReason
        '
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReason.Location = New System.Drawing.Point(89, 468)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(198, 20)
        Me.txtReason.TabIndex = 9
        '
        'cboStatus
        '
        Me.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "POSTED"})
        Me.cboStatus.Location = New System.Drawing.Point(89, 384)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(198, 21)
        Me.cboStatus.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(22, 385)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Status"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboInventoryAccount
        '
        Me.cboInventoryAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInventoryAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInventoryAccount.DataSource = Me.GLAccountsBindingSource
        Me.cboInventoryAccount.DisplayMember = "GLAccountNumber"
        Me.cboInventoryAccount.FormattingEnabled = True
        Me.cboInventoryAccount.Location = New System.Drawing.Point(88, 206)
        Me.cboInventoryAccount.Name = "cboInventoryAccount"
        Me.cboInventoryAccount.Size = New System.Drawing.Size(198, 21)
        Me.cboInventoryAccount.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(25, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "GL Acct."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(25, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(261, 65)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBatchNumber.DataSource = Me.InventoryAdjustmentTableBindingSource
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(89, 426)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(198, 21)
        Me.cboBatchNumber.TabIndex = 8
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(25, 154)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(261, 21)
        Me.cboPartDescription.TabIndex = 2
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(63, 122)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(223, 21)
        Me.cboPartNumber.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(22, 424)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Batch #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(88, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(198, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(22, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Part #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(136, 724)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 14
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(215, 724)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(25, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(22, 468)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Reason"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'dgvInventoryAdjustments
        '
        Me.dgvInventoryAdjustments.AllowUserToAddRows = False
        Me.dgvInventoryAdjustments.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvInventoryAdjustments.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvInventoryAdjustments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryAdjustments.AutoGenerateColumns = False
        Me.dgvInventoryAdjustments.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryAdjustments.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInventoryAdjustments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryAdjustments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AdjustmentDateColumn, Me.PartNumberColumn, Me.DescriptionColumn, Me.QuantityColumn, Me.CostColumn, Me.TotalColumn, Me.BatchNumberColumn, Me.AdjustmentNumberColumn, Me.ReasonColumn, Me.StatusColumn, Me.InventoryAccountColumn, Me.AdjustmentAccountColumn, Me.LineCommentColumn, Me.DivisionIDColumn, Me.AdjustmentAgentColumn})
        Me.dgvInventoryAdjustments.DataSource = Me.InventoryAdjustmentTableBindingSource
        Me.dgvInventoryAdjustments.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInventoryAdjustments.Location = New System.Drawing.Point(343, 41)
        Me.dgvInventoryAdjustments.Name = "dgvInventoryAdjustments"
        Me.dgvInventoryAdjustments.Size = New System.Drawing.Size(787, 620)
        Me.dgvInventoryAdjustments.TabIndex = 16
        Me.dgvInventoryAdjustments.TabStop = False
        '
        'AdjustmentDateColumn
        '
        Me.AdjustmentDateColumn.DataPropertyName = "AdjustmentDate"
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.AdjustmentDateColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.AdjustmentDateColumn.HeaderText = "Date"
        Me.AdjustmentDateColumn.Name = "AdjustmentDateColumn"
        Me.AdjustmentDateColumn.Width = 65
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        '
        'DescriptionColumn
        '
        Me.DescriptionColumn.DataPropertyName = "Description"
        Me.DescriptionColumn.HeaderText = "Description"
        Me.DescriptionColumn.Name = "DescriptionColumn"
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        DataGridViewCellStyle8.NullValue = "0"
        Me.QuantityColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 85
        '
        'CostColumn
        '
        Me.CostColumn.DataPropertyName = "Cost"
        DataGridViewCellStyle9.Format = "N4"
        DataGridViewCellStyle9.NullValue = "0"
        Me.CostColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.CostColumn.HeaderText = "Cost"
        Me.CostColumn.Name = "CostColumn"
        Me.CostColumn.Width = 85
        '
        'TotalColumn
        '
        Me.TotalColumn.DataPropertyName = "Total"
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.TotalColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.TotalColumn.HeaderText = "Total"
        Me.TotalColumn.Name = "TotalColumn"
        Me.TotalColumn.Width = 85
        '
        'BatchNumberColumn
        '
        Me.BatchNumberColumn.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn.HeaderText = "Batch #"
        Me.BatchNumberColumn.Name = "BatchNumberColumn"
        Me.BatchNumberColumn.Width = 70
        '
        'AdjustmentNumberColumn
        '
        Me.AdjustmentNumberColumn.DataPropertyName = "AdjustmentNumber"
        Me.AdjustmentNumberColumn.HeaderText = "Adj. #"
        Me.AdjustmentNumberColumn.Name = "AdjustmentNumberColumn"
        Me.AdjustmentNumberColumn.Width = 65
        '
        'ReasonColumn
        '
        Me.ReasonColumn.DataPropertyName = "Reason"
        Me.ReasonColumn.HeaderText = "Reason"
        Me.ReasonColumn.Name = "ReasonColumn"
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        '
        'InventoryAccountColumn
        '
        Me.InventoryAccountColumn.DataPropertyName = "InventoryAccount"
        Me.InventoryAccountColumn.HeaderText = "Inventory Account"
        Me.InventoryAccountColumn.Name = "InventoryAccountColumn"
        '
        'AdjustmentAccountColumn
        '
        Me.AdjustmentAccountColumn.DataPropertyName = "AdjustmentAccount"
        Me.AdjustmentAccountColumn.HeaderText = "Adjustment Account"
        Me.AdjustmentAccountColumn.Name = "AdjustmentAccountColumn"
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'AdjustmentAgentColumn
        '
        Me.AdjustmentAgentColumn.DataPropertyName = "AdjustmentAgent"
        Me.AdjustmentAgentColumn.HeaderText = "Adj. By?"
        Me.AdjustmentAgentColumn.Name = "AdjustmentAgentColumn"
        '
        'InventoryAdjustmentTableTableAdapter
        '
        Me.InventoryAdjustmentTableTableAdapter.ClearBeforeFill = True
        '
        'cmdOpenAdjustmentForm
        '
        Me.cmdOpenAdjustmentForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenAdjustmentForm.Location = New System.Drawing.Point(905, 771)
        Me.cmdOpenAdjustmentForm.Name = "cmdOpenAdjustmentForm"
        Me.cmdOpenAdjustmentForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdOpenAdjustmentForm.TabIndex = 16
        Me.cmdOpenAdjustmentForm.Text = "Adjustment Form"
        Me.cmdOpenAdjustmentForm.UseVisualStyleBackColor = True
        '
        'GLAccountsTableAdapter
        '
        Me.GLAccountsTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.GroupBox1.Controls.Add(Me.txtTotalQuantity)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtNumberOfAdjustments)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtTotalAdjustments)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(343, 680)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 131)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totals From Datagrid"
        '
        'txtTotalQuantity
        '
        Me.txtTotalQuantity.BackColor = System.Drawing.Color.White
        Me.txtTotalQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQuantity.Location = New System.Drawing.Point(154, 60)
        Me.txtTotalQuantity.Name = "txtTotalQuantity"
        Me.txtTotalQuantity.ReadOnly = True
        Me.txtTotalQuantity.Size = New System.Drawing.Size(154, 20)
        Me.txtTotalQuantity.TabIndex = 47
        Me.txtTotalQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(18, 60)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(130, 20)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Total Quantity Adjusted"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumberOfAdjustments
        '
        Me.txtNumberOfAdjustments.BackColor = System.Drawing.Color.White
        Me.txtNumberOfAdjustments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfAdjustments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfAdjustments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfAdjustments.Location = New System.Drawing.Point(154, 28)
        Me.txtNumberOfAdjustments.Name = "txtNumberOfAdjustments"
        Me.txtNumberOfAdjustments.ReadOnly = True
        Me.txtNumberOfAdjustments.Size = New System.Drawing.Size(154, 20)
        Me.txtNumberOfAdjustments.TabIndex = 45
        Me.txtNumberOfAdjustments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(130, 20)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "# of Adjustments"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalAdjustments
        '
        Me.txtTotalAdjustments.BackColor = System.Drawing.Color.White
        Me.txtTotalAdjustments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAdjustments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalAdjustments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAdjustments.Location = New System.Drawing.Point(154, 92)
        Me.txtTotalAdjustments.Name = "txtTotalAdjustments"
        Me.txtTotalAdjustments.ReadOnly = True
        Me.txtTotalAdjustments.Size = New System.Drawing.Size(154, 20)
        Me.txtTotalAdjustments.TabIndex = 43
        Me.txtTotalAdjustments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(18, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(130, 20)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Total Adjustments"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ViewInventoryAdjustments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdOpenAdjustmentForm)
        Me.Controls.Add(Me.dgvInventoryAdjustments)
        Me.Controls.Add(Me.gpxViewByPart)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewInventoryAdjustments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Inventory Adjustments"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxViewByPart.ResumeLayout(False)
        Me.gpxViewByPart.PerformLayout()
        CType(Me.InventoryAdjustmentTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GLAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventoryAdjustments, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gpxViewByPart As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents dgvInventoryAdjustments As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryAdjustmentTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryAdjustmentTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryAdjustmentTableTableAdapter
    Friend WithEvents cboBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdOpenAdjustmentForm As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboInventoryAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkZeroCost As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents GLAccountsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GLAccountsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.GLAccountsTableAdapter
    Friend WithEvents cboAccountDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboAdjustmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents AdjustmentDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReasonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InventoryAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentAgentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumberOfAdjustments As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAdjustments As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
