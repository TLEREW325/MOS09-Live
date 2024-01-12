<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewIntercompanyShipments
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
        Me.dgvProExist = New System.Windows.Forms.DataGridView
        Me.CustomerPODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingMethodDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKey = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.gpxViewShippingStatus = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtShipViaSearch = New System.Windows.Forms.TextBox
        Me.cboShipStatus = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PickListHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.CachedCRXAnnealingLog1 = New MOS09Program.CachedCRXAnnealingLog
        Me.PickListHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.CustomerPO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ThirdPartyShipperDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingWeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdExit = New System.Windows.Forms.Button
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.grpbox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDropShip = New System.Windows.Forms.TextBox
        CType(Me.dgvProExist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxViewShippingStatus.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpbox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProExist
        '
        Me.dgvProExist.AllowUserToAddRows = False
        Me.dgvProExist.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvProExist.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProExist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProExist.AutoGenerateColumns = False
        Me.dgvProExist.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvProExist.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvProExist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProExist.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerPODataGridViewTextBoxColumn, Me.ShipViaDataGridViewTextBoxColumn1, Me.PRONumberDataGridViewTextBoxColumn1, Me.ShipDateDataGridViewTextBoxColumn1, Me.ShipToNameDataGridViewTextBoxColumn, Me.DivisionIDColumn, Me.ShipmentNumberColumn, Me.ShipmentTotalDataGridViewTextBoxColumn, Me.ShippingMethodDataGridViewTextBoxColumn, Me.SalesOrderKey})
        Me.dgvProExist.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.dgvProExist.GridColor = System.Drawing.Color.Blue
        Me.dgvProExist.Location = New System.Drawing.Point(326, 27)
        Me.dgvProExist.Name = "dgvProExist"
        Me.dgvProExist.Size = New System.Drawing.Size(816, 738)
        Me.dgvProExist.TabIndex = 10
        '
        'CustomerPODataGridViewTextBoxColumn
        '
        Me.CustomerPODataGridViewTextBoxColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPODataGridViewTextBoxColumn.HeaderText = "Customer PO"
        Me.CustomerPODataGridViewTextBoxColumn.Name = "CustomerPODataGridViewTextBoxColumn"
        Me.CustomerPODataGridViewTextBoxColumn.ReadOnly = True
        '
        'ShipViaDataGridViewTextBoxColumn1
        '
        Me.ShipViaDataGridViewTextBoxColumn1.DataPropertyName = "ShipVia"
        Me.ShipViaDataGridViewTextBoxColumn1.HeaderText = "Ship Via"
        Me.ShipViaDataGridViewTextBoxColumn1.Name = "ShipViaDataGridViewTextBoxColumn1"
        Me.ShipViaDataGridViewTextBoxColumn1.ReadOnly = True
        Me.ShipViaDataGridViewTextBoxColumn1.Width = 180
        '
        'PRONumberDataGridViewTextBoxColumn1
        '
        Me.PRONumberDataGridViewTextBoxColumn1.DataPropertyName = "PRONumber"
        Me.PRONumberDataGridViewTextBoxColumn1.HeaderText = "PRO Number"
        Me.PRONumberDataGridViewTextBoxColumn1.Name = "PRONumberDataGridViewTextBoxColumn1"
        Me.PRONumberDataGridViewTextBoxColumn1.Width = 135
        '
        'ShipDateDataGridViewTextBoxColumn1
        '
        Me.ShipDateDataGridViewTextBoxColumn1.DataPropertyName = "ShipDate"
        Me.ShipDateDataGridViewTextBoxColumn1.HeaderText = "Ship Date"
        Me.ShipDateDataGridViewTextBoxColumn1.Name = "ShipDateDataGridViewTextBoxColumn1"
        Me.ShipDateDataGridViewTextBoxColumn1.ReadOnly = True
        Me.ShipDateDataGridViewTextBoxColumn1.Width = 80
        '
        'ShipToNameDataGridViewTextBoxColumn
        '
        Me.ShipToNameDataGridViewTextBoxColumn.DataPropertyName = "ShipToName"
        Me.ShipToNameDataGridViewTextBoxColumn.HeaderText = "Ship To Name"
        Me.ShipToNameDataGridViewTextBoxColumn.Name = "ShipToNameDataGridViewTextBoxColumn"
        Me.ShipToNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipToNameDataGridViewTextBoxColumn.Width = 275
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division ID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Width = 50
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment Number"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        '
        'ShipmentTotalDataGridViewTextBoxColumn
        '
        Me.ShipmentTotalDataGridViewTextBoxColumn.DataPropertyName = "ShipmentTotal"
        Me.ShipmentTotalDataGridViewTextBoxColumn.HeaderText = "Shipment Total"
        Me.ShipmentTotalDataGridViewTextBoxColumn.Name = "ShipmentTotalDataGridViewTextBoxColumn"
        Me.ShipmentTotalDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipmentTotalDataGridViewTextBoxColumn.Width = 60
        '
        'ShippingMethodDataGridViewTextBoxColumn
        '
        Me.ShippingMethodDataGridViewTextBoxColumn.DataPropertyName = "ShippingMethod"
        Me.ShippingMethodDataGridViewTextBoxColumn.HeaderText = "Shipping Method"
        Me.ShippingMethodDataGridViewTextBoxColumn.Name = "ShippingMethodDataGridViewTextBoxColumn"
        Me.ShippingMethodDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShippingMethodDataGridViewTextBoxColumn.Width = 90
        '
        'SalesOrderKey
        '
        Me.SalesOrderKey.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKey.HeaderText = "Sales Order #"
        Me.SalesOrderKey.Name = "SalesOrderKey"
        Me.SalesOrderKey.ReadOnly = True
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gpxViewShippingStatus
        '
        Me.gpxViewShippingStatus.Controls.Add(Me.Label4)
        Me.gpxViewShippingStatus.Controls.Add(Me.txtShipViaSearch)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboShipStatus)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label15)
        Me.gpxViewShippingStatus.Controls.Add(Me.txtCustomerPO)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label14)
        Me.gpxViewShippingStatus.Controls.Add(Me.chkDateRange)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label7)
        Me.gpxViewShippingStatus.Controls.Add(Me.cmdClear)
        Me.gpxViewShippingStatus.Controls.Add(Me.cmdViewByFilters)
        Me.gpxViewShippingStatus.Controls.Add(Me.dtpEndDate)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label8)
        Me.gpxViewShippingStatus.Controls.Add(Me.dtpBeginDate)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label2)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboDivisionID)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label1)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label18)
        Me.gpxViewShippingStatus.Location = New System.Drawing.Point(12, 39)
        Me.gpxViewShippingStatus.Name = "gpxViewShippingStatus"
        Me.gpxViewShippingStatus.Size = New System.Drawing.Size(300, 391)
        Me.gpxViewShippingStatus.TabIndex = 0
        Me.gpxViewShippingStatus.TabStop = False
        Me.gpxViewShippingStatus.Text = "View By Filters"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 20)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Cust P.O. #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipViaSearch
        '
        Me.txtShipViaSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipViaSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipViaSearch.Location = New System.Drawing.Point(102, 175)
        Me.txtShipViaSearch.Name = "txtShipViaSearch"
        Me.txtShipViaSearch.Size = New System.Drawing.Size(179, 20)
        Me.txtShipViaSearch.TabIndex = 4
        '
        'cboShipStatus
        '
        Me.cboShipStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipStatus.FormattingEnabled = True
        Me.cboShipStatus.Items.AddRange(New Object() {"OPEN", "SHIPPED", "INVOICED"})
        Me.cboShipStatus.Location = New System.Drawing.Point(102, 142)
        Me.cboShipStatus.Name = "cboShipStatus"
        Me.cboShipStatus.Size = New System.Drawing.Size(179, 21)
        Me.cboShipStatus.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 142)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 20)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Status"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Location = New System.Drawing.Point(102, 109)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(179, 20)
        Me.txtCustomerPO.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(15, 228)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 19)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Check the box to include date range."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(98, 250)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 5
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(19, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(269, 29)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(213, 347)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(136, 347)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 8
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(100, 313)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpEndDate.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(14, 313)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 20)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(100, 278)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpBeginDate.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 278)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Begin Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(102, 28)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(183, 21)
        Me.cboDivisionID.TabIndex = 1
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(16, 175)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 20)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "Ship Via"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PickListHeaderTableBindingSource
        '
        Me.PickListHeaderTableBindingSource.DataMember = "PickListHeaderTable"
        Me.PickListHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 21
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
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'PickListHeaderTableTableAdapter
        '
        Me.PickListHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'CustomerPO
        '
        Me.CustomerPO.DataPropertyName = "CustomerPO"
        Me.CustomerPO.HeaderText = "Customer PO"
        Me.CustomerPO.Name = "CustomerPO"
        Me.CustomerPO.ReadOnly = True
        '
        'ShipViaDataGridViewTextBoxColumn
        '
        Me.ShipViaDataGridViewTextBoxColumn.DataPropertyName = "ShipVia"
        Me.ShipViaDataGridViewTextBoxColumn.HeaderText = "Ship Via"
        Me.ShipViaDataGridViewTextBoxColumn.Name = "ShipViaDataGridViewTextBoxColumn"
        Me.ShipViaDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipViaDataGridViewTextBoxColumn.Width = 175
        '
        'PRONumberDataGridViewTextBoxColumn
        '
        Me.PRONumberDataGridViewTextBoxColumn.DataPropertyName = "PRONumber"
        Me.PRONumberDataGridViewTextBoxColumn.HeaderText = "PRO Number"
        Me.PRONumberDataGridViewTextBoxColumn.Name = "PRONumberDataGridViewTextBoxColumn"
        Me.PRONumberDataGridViewTextBoxColumn.Width = 140
        '
        'ShipDateDataGridViewTextBoxColumn
        '
        Me.ShipDateDataGridViewTextBoxColumn.DataPropertyName = "ShipDate"
        Me.ShipDateDataGridViewTextBoxColumn.HeaderText = "Ship Date"
        Me.ShipDateDataGridViewTextBoxColumn.Name = "ShipDateDataGridViewTextBoxColumn"
        Me.ShipDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipDateDataGridViewTextBoxColumn.Width = 80
        '
        'ShipmentNumberDataGridViewTextBoxColumn
        '
        Me.ShipmentNumberDataGridViewTextBoxColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberDataGridViewTextBoxColumn.HeaderText = "Shipment Number"
        Me.ShipmentNumberDataGridViewTextBoxColumn.Name = "ShipmentNumberDataGridViewTextBoxColumn"
        Me.ShipmentNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipmentNumberDataGridViewTextBoxColumn.Width = 75
        '
        'ThirdPartyShipperDataGridViewTextBoxColumn
        '
        Me.ThirdPartyShipperDataGridViewTextBoxColumn.DataPropertyName = "ThirdPartyShipper"
        Me.ThirdPartyShipperDataGridViewTextBoxColumn.HeaderText = "Third Party Shipper"
        Me.ThirdPartyShipperDataGridViewTextBoxColumn.Name = "ThirdPartyShipperDataGridViewTextBoxColumn"
        Me.ThirdPartyShipperDataGridViewTextBoxColumn.ReadOnly = True
        Me.ThirdPartyShipperDataGridViewTextBoxColumn.Width = 225
        '
        'ShippingWeightDataGridViewTextBoxColumn
        '
        Me.ShippingWeightDataGridViewTextBoxColumn.DataPropertyName = "ShippingWeight"
        Me.ShippingWeightDataGridViewTextBoxColumn.HeaderText = "Shipping Weight"
        Me.ShippingWeightDataGridViewTextBoxColumn.Name = "ShippingWeightDataGridViewTextBoxColumn"
        Me.ShippingWeightDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShippingWeightDataGridViewTextBoxColumn.Width = 50
        '
        'ShipmentStatusDataGridViewTextBoxColumn
        '
        Me.ShipmentStatusDataGridViewTextBoxColumn.DataPropertyName = "ShipmentStatus"
        Me.ShipmentStatusDataGridViewTextBoxColumn.HeaderText = "Shipment Status"
        Me.ShipmentStatusDataGridViewTextBoxColumn.Name = "ShipmentStatusDataGridViewTextBoxColumn"
        Me.ShipmentStatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShipmentStatusDataGridViewTextBoxColumn.Width = 75
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(1059, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 11
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'grpbox2
        '
        Me.grpbox2.Controls.Add(Me.Label3)
        Me.grpbox2.Controls.Add(Me.txtDropShip)
        Me.grpbox2.Location = New System.Drawing.Point(12, 436)
        Me.grpbox2.Name = "grpbox2"
        Me.grpbox2.Size = New System.Drawing.Size(300, 71)
        Me.grpbox2.TabIndex = 22
        Me.grpbox2.TabStop = False
        Me.grpbox2.Text = "Data"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Drop Ship #:"
        '
        'txtDropShip
        '
        Me.txtDropShip.Location = New System.Drawing.Point(98, 31)
        Me.txtDropShip.Name = "txtDropShip"
        Me.txtDropShip.ReadOnly = True
        Me.txtDropShip.Size = New System.Drawing.Size(183, 20)
        Me.txtDropShip.TabIndex = 0
        '
        'ViewIntercompanyShipments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.grpbox2)
        Me.Controls.Add(Me.dgvProExist)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.gpxViewShippingStatus)
        Me.Name = "ViewIntercompanyShipments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Intercompany Shipments"
        CType(Me.dgvProExist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxViewShippingStatus.ResumeLayout(False)
        Me.gpxViewShippingStatus.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpbox2.ResumeLayout(False)
        Me.grpbox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProExist As System.Windows.Forms.DataGridView
    Friend WithEvents gpxViewShippingStatus As System.Windows.Forms.GroupBox
    Friend WithEvents txtShipViaSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboShipStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents CachedCRXAnnealingLog1 As MOS09Program.CachedCRXAnnealingLog
    Friend WithEvents PickListHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PickListHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents CustomerPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ThirdPartyShipperDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingWeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents CustomerPODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethodDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpbox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDropShip As System.Windows.Forms.TextBox
End Class
