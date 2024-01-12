<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewEditTrufitCerts
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
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboFOXNumber = New System.Windows.Forms.ComboBox
        Me.FOXTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvTrufitCerts = New System.Windows.Forms.DataGridView
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TrufitCertNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TorqueRequirementColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comment1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comment2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comment3Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TrufitCertificationQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.TrufitCertificationQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TrufitCertificationQueryTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.FOXTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdReprint = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTrufitCerts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrufitCertificationQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.cboFOXNumber)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.chkDateRange)
        Me.GroupBox1.Controls.Add(Me.dtpEndDate)
        Me.GroupBox1.Controls.Add(Me.dtpBeginDate)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmdViewByFilter)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cboSalesOrderNumber)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cboCustomerName)
        Me.GroupBox1.Controls.Add(Me.cboCustomerID)
        Me.GroupBox1.Controls.Add(Me.cboPartDescription)
        Me.GroupBox1.Controls.Add(Me.cboPartNumber)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 590)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View By Filters"
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(90, 29)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(194, 21)
        Me.cboDivisionID.TabIndex = 0
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
        'cboFOXNumber
        '
        Me.cboFOXNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFOXNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFOXNumber.DataSource = Me.FOXTableBindingSource
        Me.cboFOXNumber.DisplayMember = "FOXNumber"
        Me.cboFOXNumber.FormattingEnabled = True
        Me.cboFOXNumber.Location = New System.Drawing.Point(90, 345)
        Me.cboFOXNumber.Name = "cboFOXNumber"
        Me.cboFOXNumber.Size = New System.Drawing.Size(194, 21)
        Me.cboFOXNumber.TabIndex = 6
        '
        'FOXTableBindingSource
        '
        Me.FOXTableBindingSource.DataMember = "FOXTable"
        Me.FOXTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 346)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "FOX #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(18, 394)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(266, 33)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(104, 442)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 7
        Me.chkDateRange.TabStop = False
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(104, 502)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpEndDate.TabIndex = 9
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(104, 470)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpBeginDate.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 502)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "End Date"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(17, 472)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "Begin Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(136, 545)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 10
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 545)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 11
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboSalesOrderNumber
        '
        Me.cboSalesOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderNumber.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderNumber.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderNumber.FormattingEnabled = True
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(90, 299)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(194, 21)
        Me.cboSalesOrderNumber.TabIndex = 5
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 300)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "SO #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(15, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 40)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(19, 157)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(265, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(72, 126)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(212, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(14, 242)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(270, 21)
        Me.cboPartDescription.TabIndex = 4
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
        Me.cboPartNumber.Location = New System.Drawing.Point(72, 210)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(212, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Customer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Part #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvTrufitCerts
        '
        Me.dgvTrufitCerts.AllowUserToAddRows = False
        Me.dgvTrufitCerts.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvTrufitCerts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTrufitCerts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTrufitCerts.AutoGenerateColumns = False
        Me.dgvTrufitCerts.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTrufitCerts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTrufitCerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTrufitCerts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDColumn, Me.SalesOrderNumberColumn, Me.TrufitCertNumberColumn, Me.CertDateColumn, Me.FOXNumberColumn, Me.PartNumberColumn, Me.RMIDColumn, Me.QuantityColumn, Me.ShipDateColumn, Me.TorqueRequirementColumn, Me.Comment1Column, Me.Comment2Column, Me.Comment3Column, Me.DivisionIDColumn, Me.StatusColumn})
        Me.dgvTrufitCerts.DataSource = Me.TrufitCertificationQueryBindingSource
        Me.dgvTrufitCerts.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvTrufitCerts.Location = New System.Drawing.Point(345, 41)
        Me.dgvTrufitCerts.Name = "dgvTrufitCerts"
        Me.dgvTrufitCerts.Size = New System.Drawing.Size(785, 713)
        Me.dgvTrufitCerts.TabIndex = 2
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'SalesOrderNumberColumn
        '
        Me.SalesOrderNumberColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberColumn.HeaderText = "Order #"
        Me.SalesOrderNumberColumn.Name = "SalesOrderNumberColumn"
        Me.SalesOrderNumberColumn.ReadOnly = True
        '
        'TrufitCertNumberColumn
        '
        Me.TrufitCertNumberColumn.DataPropertyName = "TrufitCertNumber"
        Me.TrufitCertNumberColumn.HeaderText = "Cert #"
        Me.TrufitCertNumberColumn.Name = "TrufitCertNumberColumn"
        Me.TrufitCertNumberColumn.ReadOnly = True
        '
        'CertDateColumn
        '
        Me.CertDateColumn.DataPropertyName = "CertDate"
        Me.CertDateColumn.HeaderText = "Cert Date"
        Me.CertDateColumn.Name = "CertDateColumn"
        '
        'FOXNumberColumn
        '
        Me.FOXNumberColumn.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn.HeaderText = "FOX #"
        Me.FOXNumberColumn.Name = "FOXNumberColumn"
        Me.FOXNumberColumn.ReadOnly = True
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'RMIDColumn
        '
        Me.RMIDColumn.DataPropertyName = "RMID"
        Me.RMIDColumn.HeaderText = "Steel"
        Me.RMIDColumn.Name = "RMIDColumn"
        Me.RMIDColumn.ReadOnly = True
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        '
        'TorqueRequirementColumn
        '
        Me.TorqueRequirementColumn.DataPropertyName = "TorqueRequirement"
        Me.TorqueRequirementColumn.HeaderText = "Torque Req."
        Me.TorqueRequirementColumn.Name = "TorqueRequirementColumn"
        '
        'Comment1Column
        '
        Me.Comment1Column.DataPropertyName = "Comment1"
        Me.Comment1Column.HeaderText = "Comment 1"
        Me.Comment1Column.Name = "Comment1Column"
        '
        'Comment2Column
        '
        Me.Comment2Column.DataPropertyName = "Comment2"
        Me.Comment2Column.HeaderText = "Comment 2"
        Me.Comment2Column.Name = "Comment2Column"
        '
        'Comment3Column
        '
        Me.Comment3Column.DataPropertyName = "Comment3"
        Me.Comment3Column.HeaderText = "Comment 3"
        Me.Comment3Column.Name = "Comment3Column"
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        '
        'StatusColumn
        '
        Me.StatusColumn.DataPropertyName = "Status"
        Me.StatusColumn.HeaderText = "Status"
        Me.StatusColumn.Name = "StatusColumn"
        Me.StatusColumn.ReadOnly = True
        Me.StatusColumn.Visible = False
        '
        'TrufitCertificationQueryBindingSource
        '
        Me.TrufitCertificationQueryBindingSource.DataMember = "TrufitCertificationQuery"
        Me.TrufitCertificationQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Enabled = False
        Me.cmdPrint.Location = New System.Drawing.Point(981, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 14
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
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
        'TrufitCertificationQueryTableAdapter
        '
        Me.TrufitCertificationQueryTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'FOXTableTableAdapter
        '
        Me.FOXTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cmdReprint)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 650)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 161)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "EDIT / REPRINT CERT"
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(17, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(266, 81)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "You may edit certain fields in the datagrid. To reprint, select Cert in the datag" & _
            "rid and press ""Reprint Cert""."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdReprint
        '
        Me.cmdReprint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReprint.Location = New System.Drawing.Point(213, 103)
        Me.cmdReprint.Name = "cmdReprint"
        Me.cmdReprint.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprint.TabIndex = 13
        Me.cmdReprint.Text = "Reprint Cert"
        Me.cmdReprint.UseVisualStyleBackColor = True
        '
        'ViewEditTrufitCerts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvTrufitCerts)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewEditTrufitCerts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View / Edit Trufit Certs"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FOXTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTrufitCerts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrufitCertificationQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvTrufitCerts As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents TrufitCertificationQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TrufitCertificationQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TrufitCertificationQueryTableAdapter
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboFOXNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents FOXTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FOXTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.FOXTableTableAdapter
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrufitCertNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TorqueRequirementColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment3Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdReprint As System.Windows.Forms.Button
End Class
