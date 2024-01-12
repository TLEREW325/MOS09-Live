<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCertErrorLog
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
        Me.dgvCertErrorLog = New System.Windows.Forms.DataGridView
        Me.CertErrorLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.CertErrorLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CertErrorLogTableAdapter
        Me.gpxViewLotNumbers = New System.Windows.Forms.GroupBox
        Me.rdoClosed = New System.Windows.Forms.RadioButton
        Me.rdoOpen = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboShipmentNumber = New System.Windows.Forms.ComboBox
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdReprintCert = New System.Windows.Forms.Button
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.HeatNumberLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdCloseError = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvCertErrorLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CertErrorLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxViewLotNumbers.SuspendLayout()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCertErrorLog
        '
        Me.dgvCertErrorLog.AllowUserToAddRows = False
        Me.dgvCertErrorLog.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvCertErrorLog.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCertErrorLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCertErrorLog.AutoGenerateColumns = False
        Me.dgvCertErrorLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCertErrorLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCertErrorLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCertErrorLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.LotNumberColumn, Me.ShipmentNumberColumn, Me.DateColumn, Me.PartNumberColumn, Me.HeatNumberColumn, Me.CommentColumn, Me.UserID, Me.StatusColumn})
        Me.dgvCertErrorLog.DataSource = Me.CertErrorLogBindingSource
        Me.dgvCertErrorLog.GridColor = System.Drawing.Color.Red
        Me.dgvCertErrorLog.Location = New System.Drawing.Point(348, 41)
        Me.dgvCertErrorLog.Name = "dgvCertErrorLog"
        Me.dgvCertErrorLog.Size = New System.Drawing.Size(682, 582)
        Me.dgvCertErrorLog.TabIndex = 0
        '
        'CertErrorLogBindingSource
        '
        Me.CertErrorLogBindingSource.DataMember = "CertErrorLog"
        Me.CertErrorLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CertErrorLogTableAdapter
        '
        Me.CertErrorLogTableAdapter.ClearBeforeFill = True
        '
        'gpxViewLotNumbers
        '
        Me.gpxViewLotNumbers.Controls.Add(Me.rdoClosed)
        Me.gpxViewLotNumbers.Controls.Add(Me.rdoOpen)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label14)
        Me.gpxViewLotNumbers.Controls.Add(Me.chkDateRange)
        Me.gpxViewLotNumbers.Controls.Add(Me.dtpEndDate)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label9)
        Me.gpxViewLotNumbers.Controls.Add(Me.dtpBeginDate)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label8)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboShipmentNumber)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label2)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label12)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboPartDescription)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboPartNumber)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboDivisionID)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboLotNumber)
        Me.gpxViewLotNumbers.Controls.Add(Me.cboHeatNumber)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label3)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label5)
        Me.gpxViewLotNumbers.Controls.Add(Me.cmdClear)
        Me.gpxViewLotNumbers.Controls.Add(Me.cmdViewByFilters)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label7)
        Me.gpxViewLotNumbers.Controls.Add(Me.Label1)
        Me.gpxViewLotNumbers.Location = New System.Drawing.Point(29, 41)
        Me.gpxViewLotNumbers.Name = "gpxViewLotNumbers"
        Me.gpxViewLotNumbers.Size = New System.Drawing.Size(300, 582)
        Me.gpxViewLotNumbers.TabIndex = 0
        Me.gpxViewLotNumbers.TabStop = False
        Me.gpxViewLotNumbers.Text = "View By Filters"
        '
        'rdoClosed
        '
        Me.rdoClosed.AutoSize = True
        Me.rdoClosed.Location = New System.Drawing.Point(57, 377)
        Me.rdoClosed.Name = "rdoClosed"
        Me.rdoClosed.Size = New System.Drawing.Size(124, 17)
        Me.rdoClosed.TabIndex = 55
        Me.rdoClosed.Text = "View CLOSED Errors"
        Me.rdoClosed.UseVisualStyleBackColor = True
        '
        'rdoOpen
        '
        Me.rdoOpen.AutoSize = True
        Me.rdoOpen.Checked = True
        Me.rdoOpen.Location = New System.Drawing.Point(57, 343)
        Me.rdoOpen.Name = "rdoOpen"
        Me.rdoOpen.Size = New System.Drawing.Size(196, 17)
        Me.rdoOpen.TabIndex = 54
        Me.rdoOpen.TabStop = True
        Me.rdoOpen.Text = "View OPEN / UNRESOLVED Errors"
        Me.rdoOpen.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(18, 410)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 33)
        Me.Label14.TabIndex = 53
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(113, 446)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 6
        Me.chkDateRange.TabStop = False
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(110, 511)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpEndDate.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(22, 511)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 20)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "End Date"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(110, 476)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpBeginDate.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(22, 476)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 20)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Begin Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipmentNumber
        '
        Me.cboShipmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboShipmentNumber.DisplayMember = "ShipmentNumber"
        Me.cboShipmentNumber.FormattingEnabled = True
        Me.cboShipmentNumber.Location = New System.Drawing.Point(97, 300)
        Me.cboShipmentNumber.Name = "cboShipmentNumber"
        Me.cboShipmentNumber.Size = New System.Drawing.Size(188, 21)
        Me.cboShipmentNumber.TabIndex = 5
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 301)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Shipment #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(21, 159)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(264, 21)
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
        Me.cboPartNumber.Location = New System.Drawing.Point(97, 127)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(188, 21)
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
        Me.cboLotNumber.Location = New System.Drawing.Point(97, 254)
        Me.cboLotNumber.Name = "cboLotNumber"
        Me.cboLotNumber.Size = New System.Drawing.Size(188, 21)
        Me.cboLotNumber.TabIndex = 4
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
        Me.cboHeatNumber.Location = New System.Drawing.Point(97, 208)
        Me.cboHeatNumber.Name = "cboHeatNumber"
        Me.cboHeatNumber.Size = New System.Drawing.Size(188, 21)
        Me.cboHeatNumber.TabIndex = 3
        '
        'HeatNumberLogBindingSource
        '
        Me.HeatNumberLogBindingSource.DataMember = "HeatNumberLog"
        Me.HeatNumberLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(18, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Part Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(18, 255)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Lot Number"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(216, 542)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(139, 542)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 9
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(18, 209)
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
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
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
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(881, 721)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 16
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 721)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 17
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmdReprintCert)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 629)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 132)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reprint Cert w/chemistry only"
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(15, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(269, 43)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Select lot number in datagrid for the specific shipment to reprint cert with chem" & _
            "istry."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdReprintCert
        '
        Me.cmdReprintCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReprintCert.Location = New System.Drawing.Point(213, 74)
        Me.cmdReprintCert.Name = "cmdReprintCert"
        Me.cmdReprintCert.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprintCert.TabIndex = 17
        Me.cmdReprintCert.Text = "Re-Print Cert"
        Me.cmdReprintCert.UseVisualStyleBackColor = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'HeatNumberLogTableAdapter
        '
        Me.HeatNumberLogTableAdapter.ClearBeforeFill = True
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdCloseError)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(348, 629)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 132)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Close Error"
        '
        'cmdCloseError
        '
        Me.cmdCloseError.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCloseError.Location = New System.Drawing.Point(213, 74)
        Me.cmdCloseError.Name = "cmdCloseError"
        Me.cmdCloseError.Size = New System.Drawing.Size(71, 40)
        Me.cmdCloseError.TabIndex = 17
        Me.cmdCloseError.Text = "Close Error"
        Me.cmdCloseError.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(15, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(269, 48)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "To ""CLOSE"" error and remove it from this list, select in datagrid and press ""Clos" & _
            "e Error"""
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division "
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Width = 70
        '
        'LotNumberColumn
        '
        Me.LotNumberColumn.DataPropertyName = "LotNumber"
        Me.LotNumberColumn.HeaderText = "Lot Number"
        Me.LotNumberColumn.Name = "LotNumberColumn"
        Me.LotNumberColumn.ReadOnly = True
        Me.LotNumberColumn.Width = 80
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        Me.ShipmentNumberColumn.Width = 80
        '
        'DateColumn
        '
        Me.DateColumn.DataPropertyName = "Date"
        Me.DateColumn.HeaderText = "Date"
        Me.DateColumn.Name = "DateColumn"
        Me.DateColumn.ReadOnly = True
        Me.DateColumn.Width = 80
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'HeatNumberColumn
        '
        Me.HeatNumberColumn.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn.HeaderText = "Heat #"
        Me.HeatNumberColumn.Name = "HeatNumberColumn"
        Me.HeatNumberColumn.ReadOnly = True
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "User ID"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        Me.UserID.Width = 80
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        '
        'ViewCertErrorLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 773)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxViewLotNumbers)
        Me.Controls.Add(Me.dgvCertErrorLog)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewCertErrorLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Certification Error Log"
        CType(Me.dgvCertErrorLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CertErrorLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxViewLotNumbers.ResumeLayout(False)
        Me.gpxViewLotNumbers.PerformLayout()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeatNumberLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCertErrorLog As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CertErrorLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CertErrorLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CertErrorLogTableAdapter
    Friend WithEvents gpxViewLotNumbers As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cboLotNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboHeatNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboShipmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents HeatNumberLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeatNumberLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.HeatNumberLogTableAdapter
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rdoClosed As System.Windows.Forms.RadioButton
    Friend WithEvents rdoOpen As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdReprintCert As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCloseError As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
