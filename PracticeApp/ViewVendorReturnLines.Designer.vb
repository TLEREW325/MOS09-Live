<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewVendorReturnLines
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
        Me.gpxReturnSearchData = New System.Windows.Forms.GroupBox
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.cboReturnStatus = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboReturnNumber = New System.Windows.Forms.ComboBox
        Me.VendorReturnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboVendorID = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPONumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvVendorReturnLines = New System.Windows.Forms.DataGridView
        Me.VendorIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiverLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorReturnLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VendorReturnLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnLineQueryTableAdapter
        Me.cmdPrintListing = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.VendorReturnTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.gpxReturnSearchData.SuspendLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorReturnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvVendorReturnLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorReturnLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpxReturnSearchData
        '
        Me.gpxReturnSearchData.Controls.Add(Me.cboPartNumber)
        Me.gpxReturnSearchData.Controls.Add(Me.Label6)
        Me.gpxReturnSearchData.Controls.Add(Me.cboPartDescription)
        Me.gpxReturnSearchData.Controls.Add(Me.cboReturnStatus)
        Me.gpxReturnSearchData.Controls.Add(Me.Label4)
        Me.gpxReturnSearchData.Controls.Add(Me.Label14)
        Me.gpxReturnSearchData.Controls.Add(Me.chkDateRange)
        Me.gpxReturnSearchData.Controls.Add(Me.Label12)
        Me.gpxReturnSearchData.Controls.Add(Me.cboReturnNumber)
        Me.gpxReturnSearchData.Controls.Add(Me.txtVendorName)
        Me.gpxReturnSearchData.Controls.Add(Me.dtpEndDate)
        Me.gpxReturnSearchData.Controls.Add(Me.cboVendorID)
        Me.gpxReturnSearchData.Controls.Add(Me.cboPONumber)
        Me.gpxReturnSearchData.Controls.Add(Me.Label5)
        Me.gpxReturnSearchData.Controls.Add(Me.cboDivisionID)
        Me.gpxReturnSearchData.Controls.Add(Me.Label3)
        Me.gpxReturnSearchData.Controls.Add(Me.Label2)
        Me.gpxReturnSearchData.Controls.Add(Me.cmdViewByFilters)
        Me.gpxReturnSearchData.Controls.Add(Me.dtpBeginDate)
        Me.gpxReturnSearchData.Controls.Add(Me.cmdClear)
        Me.gpxReturnSearchData.Controls.Add(Me.Label8)
        Me.gpxReturnSearchData.Controls.Add(Me.Label1)
        Me.gpxReturnSearchData.Controls.Add(Me.Label7)
        Me.gpxReturnSearchData.Location = New System.Drawing.Point(29, 41)
        Me.gpxReturnSearchData.Name = "gpxReturnSearchData"
        Me.gpxReturnSearchData.Size = New System.Drawing.Size(300, 770)
        Me.gpxReturnSearchData.TabIndex = 0
        Me.gpxReturnSearchData.TabStop = False
        Me.gpxReturnSearchData.Text = "View By Filter"
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(66, 432)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(221, 21)
        Me.cboPartNumber.TabIndex = 6
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
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(20, 433)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 20)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Part #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(26, 468)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(261, 21)
        Me.cboPartDescription.TabIndex = 7
        '
        'cboReturnStatus
        '
        Me.cboReturnStatus.FormattingEnabled = True
        Me.cboReturnStatus.Items.AddRange(New Object() {"OPEN", "POSTED", "CLOSED"})
        Me.cboReturnStatus.Location = New System.Drawing.Point(105, 350)
        Me.cboReturnStatus.Name = "cboReturnStatus"
        Me.cboReturnStatus.Size = New System.Drawing.Size(182, 21)
        Me.cboReturnStatus.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(23, 351)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 20)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Status"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(20, 573)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(264, 33)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(104, 609)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 8
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(25, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(262, 40)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboReturnNumber
        '
        Me.cboReturnNumber.DataSource = Me.VendorReturnBindingSource
        Me.cboReturnNumber.DisplayMember = "ReturnNumber"
        Me.cboReturnNumber.FormattingEnabled = True
        Me.cboReturnNumber.Location = New System.Drawing.Point(105, 303)
        Me.cboReturnNumber.Name = "cboReturnNumber"
        Me.cboReturnNumber.Size = New System.Drawing.Size(182, 21)
        Me.cboReturnNumber.TabIndex = 4
        '
        'VendorReturnBindingSource
        '
        Me.VendorReturnBindingSource.DataMember = "VendorReturn"
        Me.VendorReturnBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtVendorName
        '
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(25, 149)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(262, 78)
        Me.txtVendorName.TabIndex = 2
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(105, 681)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpEndDate.TabIndex = 10
        '
        'cboVendorID
        '
        Me.cboVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorID.DataSource = Me.VendorBindingSource
        Me.cboVendorID.DisplayMember = "VendorCode"
        Me.cboVendorID.FormattingEnabled = True
        Me.cboVendorID.Location = New System.Drawing.Point(66, 115)
        Me.cboVendorID.Name = "cboVendorID"
        Me.cboVendorID.Size = New System.Drawing.Size(221, 21)
        Me.cboVendorID.TabIndex = 1
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPONumber
        '
        Me.cboPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPONumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPONumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPONumber.FormattingEnabled = True
        Me.cboPONumber.Location = New System.Drawing.Point(106, 256)
        Me.cboPONumber.Name = "cboPONumber"
        Me.cboPONumber.Size = New System.Drawing.Size(181, 21)
        Me.cboPONumber.TabIndex = 3
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(21, 304)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Return Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(106, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(181, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(22, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Vendor"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 257)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "PO Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(138, 723)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 11
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(105, 641)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(181, 20)
        Me.dtpBeginDate.TabIndex = 9
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(215, 723)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(20, 681)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(20, 641)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Begin Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 2
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
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
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
        'dgvVendorReturnLines
        '
        Me.dgvVendorReturnLines.AllowUserToAddRows = False
        Me.dgvVendorReturnLines.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvVendorReturnLines.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVendorReturnLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVendorReturnLines.AutoGenerateColumns = False
        Me.dgvVendorReturnLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvVendorReturnLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvVendorReturnLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVendorReturnLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VendorIDColumn, Me.ReturnDateColumn, Me.PONumberColumn, Me.ReturnNumberColumn, Me.ReturnLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.CostColumn, Me.ExtendedAmountColumn, Me.LineCommentColumn, Me.ReturnStatusColumn, Me.LineStatusColumn, Me.ReceiverNumberColumn, Me.ReceiverLineNumberColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.UserIDColumn, Me.DivisionIDColumn})
        Me.dgvVendorReturnLines.DataSource = Me.VendorReturnLineQueryBindingSource
        Me.dgvVendorReturnLines.GridColor = System.Drawing.Color.Cyan
        Me.dgvVendorReturnLines.Location = New System.Drawing.Point(345, 41)
        Me.dgvVendorReturnLines.Name = "dgvVendorReturnLines"
        Me.dgvVendorReturnLines.ReadOnly = True
        Me.dgvVendorReturnLines.Size = New System.Drawing.Size(785, 724)
        Me.dgvVendorReturnLines.TabIndex = 3
        '
        'VendorIDColumn
        '
        Me.VendorIDColumn.DataPropertyName = "VendorID"
        Me.VendorIDColumn.HeaderText = "Vendor"
        Me.VendorIDColumn.Name = "VendorIDColumn"
        Me.VendorIDColumn.ReadOnly = True
        '
        'ReturnDateColumn
        '
        Me.ReturnDateColumn.DataPropertyName = "ReturnDate"
        Me.ReturnDateColumn.HeaderText = "Return Date"
        Me.ReturnDateColumn.Name = "ReturnDateColumn"
        Me.ReturnDateColumn.ReadOnly = True
        Me.ReturnDateColumn.Width = 85
        '
        'PONumberColumn
        '
        Me.PONumberColumn.DataPropertyName = "PONumber"
        Me.PONumberColumn.HeaderText = "PO #"
        Me.PONumberColumn.Name = "PONumberColumn"
        Me.PONumberColumn.ReadOnly = True
        Me.PONumberColumn.Width = 85
        '
        'ReturnNumberColumn
        '
        Me.ReturnNumberColumn.DataPropertyName = "ReturnNumber"
        Me.ReturnNumberColumn.HeaderText = "Return #"
        Me.ReturnNumberColumn.Name = "ReturnNumberColumn"
        Me.ReturnNumberColumn.ReadOnly = True
        Me.ReturnNumberColumn.Width = 85
        '
        'ReturnLineNumberColumn
        '
        Me.ReturnLineNumberColumn.DataPropertyName = "ReturnLineNumber"
        Me.ReturnLineNumberColumn.HeaderText = "Line #"
        Me.ReturnLineNumberColumn.Name = "ReturnLineNumberColumn"
        Me.ReturnLineNumberColumn.ReadOnly = True
        Me.ReturnLineNumberColumn.Width = 60
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
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.ReadOnly = True
        Me.QuantityColumn.Width = 85
        '
        'CostColumn
        '
        Me.CostColumn.DataPropertyName = "Cost"
        Me.CostColumn.HeaderText = "Cost"
        Me.CostColumn.Name = "CostColumn"
        Me.CostColumn.ReadOnly = True
        Me.CostColumn.Width = 85
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "Ext Amt"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 85
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.ReadOnly = True
        '
        'ReturnStatusColumn
        '
        Me.ReturnStatusColumn.DataPropertyName = "ReturnStatus"
        Me.ReturnStatusColumn.HeaderText = "Return Status"
        Me.ReturnStatusColumn.Name = "ReturnStatusColumn"
        Me.ReturnStatusColumn.ReadOnly = True
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        '
        'ReceiverNumberColumn
        '
        Me.ReceiverNumberColumn.DataPropertyName = "ReceiverNumber"
        Me.ReceiverNumberColumn.HeaderText = "Receiver #"
        Me.ReceiverNumberColumn.Name = "ReceiverNumberColumn"
        Me.ReceiverNumberColumn.ReadOnly = True
        '
        'ReceiverLineNumberColumn
        '
        Me.ReceiverLineNumberColumn.DataPropertyName = "ReceiverLineNumber"
        Me.ReceiverLineNumberColumn.HeaderText = "Receiver Line #"
        Me.ReceiverLineNumberColumn.Name = "ReceiverLineNumberColumn"
        Me.ReceiverLineNumberColumn.ReadOnly = True
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit Account"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.ReadOnly = True
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "Credit Account"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.ReadOnly = True
        '
        'UserIDColumn
        '
        Me.UserIDColumn.DataPropertyName = "UserID"
        Me.UserIDColumn.HeaderText = "Entered By?"
        Me.UserIDColumn.Name = "UserIDColumn"
        Me.UserIDColumn.ReadOnly = True
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'VendorReturnLineQueryBindingSource
        '
        Me.VendorReturnLineQueryBindingSource.DataMember = "VendorReturnLineQuery"
        Me.VendorReturnLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'VendorReturnLineQueryTableAdapter
        '
        Me.VendorReturnLineQueryTableAdapter.ClearBeforeFill = True
        '
        'cmdPrintListing
        '
        Me.cmdPrintListing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'VendorReturnTableAdapter
        '
        Me.VendorReturnTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'ViewVendorReturnLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdPrintListing)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvVendorReturnLines)
        Me.Controls.Add(Me.gpxReturnSearchData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewVendorReturnLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Vendor Return Lines"
        Me.gpxReturnSearchData.ResumeLayout(False)
        Me.gpxReturnSearchData.PerformLayout()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorReturnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvVendorReturnLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorReturnLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpxReturnSearchData As System.Windows.Forms.GroupBox
    Friend WithEvents cboReturnStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboReturnNumber As System.Windows.Forms.ComboBox
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboVendorID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPONumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvVendorReturnLines As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents VendorReturnLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorReturnLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnLineQueryTableAdapter
    Friend WithEvents cmdPrintListing As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents VendorReturnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorReturnTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnTableAdapter
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents VendorIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiverLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
