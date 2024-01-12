<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSteelTransactions
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
        Me.grpFilterBy = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkAllTypes = New System.Windows.Forms.CheckBox
        Me.cboTransactionType = New System.Windows.Forms.ComboBox
        Me.SteelTransactionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.lblDateFilter = New System.Windows.Forms.Label
        Me.lblTransMessage = New System.Windows.Forms.Label
        Me.cboReferenceNumber = New System.Windows.Forms.ComboBox
        Me.lblTransactionType = New System.Windows.Forms.Label
        Me.cboSteelSize = New System.Windows.Forms.ComboBox
        Me.RawMaterialsTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblSteelSize = New System.Windows.Forms.Label
        Me.cboCarbon = New System.Windows.Forms.ComboBox
        Me.lblCarbon = New System.Windows.Forms.Label
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvSteelTransactions = New System.Windows.Forms.DataGridView
        Me.SteelTransactionDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelReferenceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionMathColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdPrintListing = New System.Windows.Forms.Button
        Me.SteelTransactionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelTransactionTableTableAdapter
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTotalMaterialAdded = New System.Windows.Forms.Label
        Me.lblTotalMaterialRemoved = New System.Windows.Forms.Label
        Me.RawMaterialsTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.grpFilterBy.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvSteelTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFilterBy
        '
        Me.grpFilterBy.Controls.Add(Me.cboDivisionID)
        Me.grpFilterBy.Controls.Add(Me.Label4)
        Me.grpFilterBy.Controls.Add(Me.chkAllTypes)
        Me.grpFilterBy.Controls.Add(Me.cboTransactionType)
        Me.grpFilterBy.Controls.Add(Me.Label1)
        Me.grpFilterBy.Controls.Add(Me.Label14)
        Me.grpFilterBy.Controls.Add(Me.chkDateRange)
        Me.grpFilterBy.Controls.Add(Me.dtpEndDate)
        Me.grpFilterBy.Controls.Add(Me.Label6)
        Me.grpFilterBy.Controls.Add(Me.dtpBeginDate)
        Me.grpFilterBy.Controls.Add(Me.lblDateFilter)
        Me.grpFilterBy.Controls.Add(Me.lblTransMessage)
        Me.grpFilterBy.Controls.Add(Me.cboReferenceNumber)
        Me.grpFilterBy.Controls.Add(Me.lblTransactionType)
        Me.grpFilterBy.Controls.Add(Me.cboSteelSize)
        Me.grpFilterBy.Controls.Add(Me.lblSteelSize)
        Me.grpFilterBy.Controls.Add(Me.cboCarbon)
        Me.grpFilterBy.Controls.Add(Me.lblCarbon)
        Me.grpFilterBy.Controls.Add(Me.cmdView)
        Me.grpFilterBy.Controls.Add(Me.cmdClear)
        Me.grpFilterBy.Location = New System.Drawing.Point(29, 41)
        Me.grpFilterBy.Name = "grpFilterBy"
        Me.grpFilterBy.Size = New System.Drawing.Size(300, 709)
        Me.grpFilterBy.TabIndex = 0
        Me.grpFilterBy.TabStop = False
        Me.grpFilterBy.Text = "View By Filters"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(112, 31)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(173, 21)
        Me.cboDivisionID.TabIndex = 44
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 20)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAllTypes
        '
        Me.chkAllTypes.AutoSize = True
        Me.chkAllTypes.Location = New System.Drawing.Point(112, 122)
        Me.chkAllTypes.Margin = New System.Windows.Forms.Padding(5)
        Me.chkAllTypes.Name = "chkAllTypes"
        Me.chkAllTypes.Size = New System.Drawing.Size(168, 17)
        Me.chkAllTypes.TabIndex = 1
        Me.chkAllTypes.Text = "Show all types for given grade"
        Me.chkAllTypes.UseVisualStyleBackColor = True
        '
        'cboTransactionType
        '
        Me.cboTransactionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTransactionType.DataSource = Me.SteelTransactionTableBindingSource
        Me.cboTransactionType.DisplayMember = "TransactionType"
        Me.cboTransactionType.FormattingEnabled = True
        Me.cboTransactionType.Location = New System.Drawing.Point(112, 384)
        Me.cboTransactionType.Name = "cboTransactionType"
        Me.cboTransactionType.Size = New System.Drawing.Size(173, 21)
        Me.cboTransactionType.TabIndex = 4
        '
        'SteelTransactionTableBindingSource
        '
        Me.SteelTransactionTableBindingSource.DataMember = "SteelTransactionTable"
        Me.SteelTransactionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 383)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 20)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Transaction Type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(21, 512)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(105, 548)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 5
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(105, 619)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpEndDate.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(21, 619)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "End Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(105, 583)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpBeginDate.TabIndex = 6
        '
        'lblDateFilter
        '
        Me.lblDateFilter.Location = New System.Drawing.Point(21, 583)
        Me.lblDateFilter.Name = "lblDateFilter"
        Me.lblDateFilter.Size = New System.Drawing.Size(100, 20)
        Me.lblDateFilter.TabIndex = 39
        Me.lblDateFilter.Text = "Begin Date"
        Me.lblDateFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTransMessage
        '
        Me.lblTransMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblTransMessage.Location = New System.Drawing.Point(16, 240)
        Me.lblTransMessage.Name = "lblTransMessage"
        Me.lblTransMessage.Size = New System.Drawing.Size(269, 43)
        Me.lblTransMessage.TabIndex = 29
        Me.lblTransMessage.Text = "Reference # may be a Receiver Number, Adjustment Number, etc. depending on the ty" & _
            "pe of Steel Transaction."
        '
        'cboReferenceNumber
        '
        Me.cboReferenceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReferenceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReferenceNumber.DataSource = Me.SteelTransactionTableBindingSource
        Me.cboReferenceNumber.DisplayMember = "SteelReferenceNumber"
        Me.cboReferenceNumber.FormattingEnabled = True
        Me.cboReferenceNumber.Location = New System.Drawing.Point(112, 298)
        Me.cboReferenceNumber.Name = "cboReferenceNumber"
        Me.cboReferenceNumber.Size = New System.Drawing.Size(173, 21)
        Me.cboReferenceNumber.TabIndex = 3
        '
        'lblTransactionType
        '
        Me.lblTransactionType.Location = New System.Drawing.Point(16, 299)
        Me.lblTransactionType.Name = "lblTransactionType"
        Me.lblTransactionType.Size = New System.Drawing.Size(90, 20)
        Me.lblTransactionType.TabIndex = 22
        Me.lblTransactionType.Text = "Reference #"
        Me.lblTransactionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSteelSize
        '
        Me.cboSteelSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSteelSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSteelSize.DataSource = Me.RawMaterialsTableBindingSource
        Me.cboSteelSize.DisplayMember = "SteelSize"
        Me.cboSteelSize.FormattingEnabled = True
        Me.cboSteelSize.Location = New System.Drawing.Point(112, 161)
        Me.cboSteelSize.Name = "cboSteelSize"
        Me.cboSteelSize.Size = New System.Drawing.Size(173, 21)
        Me.cboSteelSize.TabIndex = 2
        '
        'RawMaterialsTableBindingSource
        '
        Me.RawMaterialsTableBindingSource.DataMember = "RawMaterialsTable"
        Me.RawMaterialsTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblSteelSize
        '
        Me.lblSteelSize.Location = New System.Drawing.Point(16, 161)
        Me.lblSteelSize.Name = "lblSteelSize"
        Me.lblSteelSize.Size = New System.Drawing.Size(90, 20)
        Me.lblSteelSize.TabIndex = 20
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
        Me.cboCarbon.Location = New System.Drawing.Point(112, 79)
        Me.cboCarbon.Name = "cboCarbon"
        Me.cboCarbon.Size = New System.Drawing.Size(173, 21)
        Me.cboCarbon.TabIndex = 0
        '
        'lblCarbon
        '
        Me.lblCarbon.Location = New System.Drawing.Point(16, 78)
        Me.lblCarbon.Name = "lblCarbon"
        Me.lblCarbon.Size = New System.Drawing.Size(90, 20)
        Me.lblCarbon.TabIndex = 19
        Me.lblCarbon.Text = "Carbon"
        Me.lblCarbon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(137, 660)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(71, 30)
        Me.cmdView.TabIndex = 8
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(214, 660)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 6
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
        'dgvSteelTransactions
        '
        Me.dgvSteelTransactions.AllowUserToAddRows = False
        Me.dgvSteelTransactions.AllowUserToDeleteRows = False
        Me.dgvSteelTransactions.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSteelTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSteelTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSteelTransactions.AutoGenerateColumns = False
        Me.dgvSteelTransactions.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelTransactions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSteelTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelTransactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelTransactionDateColumn, Me.TransactionNumberColumn, Me.TransactionTypeColumn, Me.CarbonColumn, Me.SteelSizeColumn, Me.QuantityColumn, Me.SteelCostColumn, Me.ExtendedCostColumn, Me.SteelReferenceNumberColumn, Me.SteelReferenceLineColumn, Me.RMIDColumn, Me.TransactionMathColumn, Me.DivisionIDColumn})
        Me.dgvSteelTransactions.DataSource = Me.SteelTransactionTableBindingSource
        Me.dgvSteelTransactions.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvSteelTransactions.Location = New System.Drawing.Point(345, 41)
        Me.dgvSteelTransactions.Name = "dgvSteelTransactions"
        Me.dgvSteelTransactions.ReadOnly = True
        Me.dgvSteelTransactions.Size = New System.Drawing.Size(685, 709)
        Me.dgvSteelTransactions.TabIndex = 11
        Me.dgvSteelTransactions.TabStop = False
        '
        'SteelTransactionDateColumn
        '
        Me.SteelTransactionDateColumn.DataPropertyName = "SteelTransactionDate"
        Me.SteelTransactionDateColumn.HeaderText = "Date"
        Me.SteelTransactionDateColumn.Name = "SteelTransactionDateColumn"
        Me.SteelTransactionDateColumn.ReadOnly = True
        Me.SteelTransactionDateColumn.Width = 80
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "Trans. #"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.ReadOnly = True
        Me.TransactionNumberColumn.Width = 80
        '
        'TransactionTypeColumn
        '
        Me.TransactionTypeColumn.DataPropertyName = "TransactionType"
        Me.TransactionTypeColumn.HeaderText = "Trans. Type"
        Me.TransactionTypeColumn.Name = "TransactionTypeColumn"
        Me.TransactionTypeColumn.ReadOnly = True
        '
        'CarbonColumn
        '
        Me.CarbonColumn.DataPropertyName = "Carbon"
        Me.CarbonColumn.HeaderText = "Carbon/Alloy"
        Me.CarbonColumn.Name = "CarbonColumn"
        Me.CarbonColumn.ReadOnly = True
        '
        'SteelSizeColumn
        '
        Me.SteelSizeColumn.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn.HeaderText = "Size"
        Me.SteelSizeColumn.Name = "SteelSizeColumn"
        Me.SteelSizeColumn.ReadOnly = True
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.ReadOnly = True
        Me.QuantityColumn.Width = 90
        '
        'SteelCostColumn
        '
        Me.SteelCostColumn.DataPropertyName = "SteelCost"
        DataGridViewCellStyle2.Format = "N5"
        DataGridViewCellStyle2.NullValue = "0"
        Me.SteelCostColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.SteelCostColumn.HeaderText = "Cost/Lb"
        Me.SteelCostColumn.Name = "SteelCostColumn"
        Me.SteelCostColumn.ReadOnly = True
        Me.SteelCostColumn.Width = 90
        '
        'ExtendedCostColumn
        '
        Me.ExtendedCostColumn.DataPropertyName = "ExtendedCost"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedCostColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedCostColumn.HeaderText = "Extended Cost"
        Me.ExtendedCostColumn.Name = "ExtendedCostColumn"
        Me.ExtendedCostColumn.ReadOnly = True
        Me.ExtendedCostColumn.Width = 90
        '
        'SteelReferenceNumberColumn
        '
        Me.SteelReferenceNumberColumn.DataPropertyName = "SteelReferenceNumber"
        Me.SteelReferenceNumberColumn.HeaderText = "Ref. #"
        Me.SteelReferenceNumberColumn.Name = "SteelReferenceNumberColumn"
        Me.SteelReferenceNumberColumn.ReadOnly = True
        '
        'SteelReferenceLineColumn
        '
        Me.SteelReferenceLineColumn.DataPropertyName = "SteelReferenceLine"
        Me.SteelReferenceLineColumn.HeaderText = "Ref. Line"
        Me.SteelReferenceLineColumn.Name = "SteelReferenceLineColumn"
        Me.SteelReferenceLineColumn.ReadOnly = True
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "RMID"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        '
        'TransactionMathColumn
        '
        Me.TransactionMathColumn.DataPropertyName = "TransactionMath"
        Me.TransactionMathColumn.HeaderText = "TransactionMath"
        Me.TransactionMathColumn.Name = "TransactionMathColumn"
        Me.TransactionMathColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 10
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdPrintListing
        '
        Me.cmdPrintListing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintListing.Location = New System.Drawing.Point(882, 771)
        Me.cmdPrintListing.Name = "cmdPrintListing"
        Me.cmdPrintListing.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintListing.TabIndex = 9
        Me.cmdPrintListing.Text = "Print Listing"
        Me.cmdPrintListing.UseVisualStyleBackColor = True
        '
        'SteelTransactionTableTableAdapter
        '
        Me.SteelTransactionTableTableAdapter.ClearBeforeFill = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label2.Location = New System.Drawing.Point(349, 780)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 23)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Total Material Added"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label3.Location = New System.Drawing.Point(610, 781)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 21)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Total Material Removed"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalMaterialAdded
        '
        Me.lblTotalMaterialAdded.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblTotalMaterialAdded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalMaterialAdded.Location = New System.Drawing.Point(461, 781)
        Me.lblTotalMaterialAdded.Name = "lblTotalMaterialAdded"
        Me.lblTotalMaterialAdded.Size = New System.Drawing.Size(128, 21)
        Me.lblTotalMaterialAdded.TabIndex = 14
        Me.lblTotalMaterialAdded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalMaterialRemoved
        '
        Me.lblTotalMaterialRemoved.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblTotalMaterialRemoved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalMaterialRemoved.Location = New System.Drawing.Point(736, 781)
        Me.lblTotalMaterialRemoved.Name = "lblTotalMaterialRemoved"
        Me.lblTotalMaterialRemoved.Size = New System.Drawing.Size(128, 21)
        Me.lblTotalMaterialRemoved.TabIndex = 15
        Me.lblTotalMaterialRemoved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RawMaterialsTableTableAdapter
        '
        Me.RawMaterialsTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ViewSteelTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.lblTotalMaterialRemoved)
        Me.Controls.Add(Me.lblTotalMaterialAdded)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdPrintListing)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvSteelTransactions)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.grpFilterBy)
        Me.Name = "ViewSteelTransactions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Steel Transactions"
        Me.grpFilterBy.ResumeLayout(False)
        Me.grpFilterBy.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelTransactionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RawMaterialsTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvSteelTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpFilterBy As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvSteelTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents cboSteelSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblSteelSize As System.Windows.Forms.Label
    Friend WithEvents cboCarbon As System.Windows.Forms.ComboBox
    Friend WithEvents lblCarbon As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cboReferenceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents lblTransactionType As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents lblTransMessage As System.Windows.Forms.Label
    Friend WithEvents cmdPrintListing As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateFilter As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SteelTransactionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelTransactionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelTransactionTableTableAdapter
    Friend WithEvents cboTransactionType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotalMaterialAdded As System.Windows.Forms.Label
    Friend WithEvents lblTotalMaterialRemoved As System.Windows.Forms.Label
    Friend WithEvents chkAllTypes As System.Windows.Forms.CheckBox
    Friend WithEvents RawMaterialsTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RawMaterialsTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.RawMaterialsTableTableAdapter
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents SteelTransactionDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelReferenceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionMathColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
