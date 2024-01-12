<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewShipmentStatus
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
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AllShipmentsFilter = New System.Windows.Forms.ToolStripMenuItem
        Me.LastThreeFilter = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintShipmentMarginReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintMultiplePacklToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintMultipleBOLsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintFedexBOLTodayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.gpxViewShippingStatus = New System.Windows.Forms.GroupBox
        Me.cboSalesPerson = New System.Windows.Forms.ComboBox
        Me.EmployeeDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtShipViaSearch = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSearchByPro = New System.Windows.Forms.TextBox
        Me.cboPickNumber = New System.Windows.Forms.ComboBox
        Me.PickListHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboShipmentNumber2 = New System.Windows.Forms.ComboBox
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboShipStatus = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboSalesOrderNumber = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdViewByFilters = New System.Windows.Forms.Button
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.llFreightDetailForm = New System.Windows.Forms.LinkLabel
        Me.Label18 = New System.Windows.Forms.Label
        Me.dgvShipmentHeaders = New System.Windows.Forms.DataGridView
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingMethodColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightActualAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOBColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesmanIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfPalletsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DoubleStackedPalletsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletsOnFloorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PostedByColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipToIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress1Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress2Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCountryColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickTicketNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TaxTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tax2TotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tax3TotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.gpxEnterPRONumbers = New System.Windows.Forms.GroupBox
        Me.txtShipmentNumber = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtQuotedFreight = New System.Windows.Forms.TextBox
        Me.txtQuoteReferenceNumber = New System.Windows.Forms.TextBox
        Me.txtFreight = New System.Windows.Forms.TextBox
        Me.txtPRONumber = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdClearPRONumber = New System.Windows.Forms.Button
        Me.cmdEnterPRONumber = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdReprintPackList = New System.Windows.Forms.Button
        Me.cmdReprintCert = New System.Windows.Forms.Button
        Me.cmdReprintBOL = New System.Windows.Forms.Button
        Me.cmdReprintLabel = New System.Windows.Forms.Button
        Me.cmdReprintAll = New System.Windows.Forms.Button
        Me.cmdPrintConfirmation = New System.Windows.Forms.Button
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.CachedCRXAnnealingLog1 = New MOS09Program.CachedCRXAnnealingLog
        Me.cmdEmailAll = New System.Windows.Forms.Button
        Me.cmdViewUploadedPickTicket = New System.Windows.Forms.Button
        Me.PickListHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
        Me.EmployeeDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
        Me.MenuStrip1.SuspendLayout()
        Me.gpxViewShippingStatus.SuspendLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShipmentHeaders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxEnterPRONumbers.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1054, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 32
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllShipmentsFilter, Me.LastThreeFilter})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'AllShipmentsFilter
        '
        Me.AllShipmentsFilter.Name = "AllShipmentsFilter"
        Me.AllShipmentsFilter.Size = New System.Drawing.Size(155, 22)
        Me.AllShipmentsFilter.Text = "All Shipments"
        '
        'LastThreeFilter
        '
        Me.LastThreeFilter.Checked = True
        Me.LastThreeFilter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LastThreeFilter.Name = "LastThreeFilter"
        Me.LastThreeFilter.Size = New System.Drawing.Size(155, 22)
        Me.LastThreeFilter.Text = "Last Three Years"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintShipmentMarginReportToolStripMenuItem, Me.PrintMultiplePacklToolStripMenuItem, Me.PrintMultipleBOLsToolStripMenuItem, Me.PrintFedexBOLTodayToolStripMenuItem, Me.PrintPickTicketToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintShipmentMarginReportToolStripMenuItem
        '
        Me.PrintShipmentMarginReportToolStripMenuItem.Name = "PrintShipmentMarginReportToolStripMenuItem"
        Me.PrintShipmentMarginReportToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.PrintShipmentMarginReportToolStripMenuItem.Text = "Print Shipment Margin Report"
        '
        'PrintMultiplePacklToolStripMenuItem
        '
        Me.PrintMultiplePacklToolStripMenuItem.Name = "PrintMultiplePacklToolStripMenuItem"
        Me.PrintMultiplePacklToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.PrintMultiplePacklToolStripMenuItem.Text = "Print Multiple Packing Lists"
        '
        'PrintMultipleBOLsToolStripMenuItem
        '
        Me.PrintMultipleBOLsToolStripMenuItem.Name = "PrintMultipleBOLsToolStripMenuItem"
        Me.PrintMultipleBOLsToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.PrintMultipleBOLsToolStripMenuItem.Text = "Print Multiple BOL's"
        '
        'PrintFedexBOLTodayToolStripMenuItem
        '
        Me.PrintFedexBOLTodayToolStripMenuItem.Name = "PrintFedexBOLTodayToolStripMenuItem"
        Me.PrintFedexBOLTodayToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.PrintFedexBOLTodayToolStripMenuItem.Text = "Print Fedex BOL (Today)"
        '
        'PrintPickTicketToolStripMenuItem
        '
        Me.PrintPickTicketToolStripMenuItem.Name = "PrintPickTicketToolStripMenuItem"
        Me.PrintPickTicketToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.PrintPickTicketToolStripMenuItem.Text = "Print Pick Ticket"
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
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(975, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 31
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'gpxViewShippingStatus
        '
        Me.gpxViewShippingStatus.Controls.Add(Me.cboSalesPerson)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label19)
        Me.gpxViewShippingStatus.Controls.Add(Me.txtShipViaSearch)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label13)
        Me.gpxViewShippingStatus.Controls.Add(Me.txtSearchByPro)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboPickNumber)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label17)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboShipmentNumber2)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label16)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboShipStatus)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label15)
        Me.gpxViewShippingStatus.Controls.Add(Me.txtCustomerPO)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label14)
        Me.gpxViewShippingStatus.Controls.Add(Me.chkDateRange)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label7)
        Me.gpxViewShippingStatus.Controls.Add(Me.cmdClear)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboSalesOrderNumber)
        Me.gpxViewShippingStatus.Controls.Add(Me.cmdViewByFilters)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboCustomerName)
        Me.gpxViewShippingStatus.Controls.Add(Me.dtpEndDate)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboCustomerID)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label8)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label12)
        Me.gpxViewShippingStatus.Controls.Add(Me.dtpBeginDate)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label2)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label3)
        Me.gpxViewShippingStatus.Controls.Add(Me.cboDivisionID)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label1)
        Me.gpxViewShippingStatus.Controls.Add(Me.llFreightDetailForm)
        Me.gpxViewShippingStatus.Controls.Add(Me.Label18)
        Me.gpxViewShippingStatus.Location = New System.Drawing.Point(29, 41)
        Me.gpxViewShippingStatus.Name = "gpxViewShippingStatus"
        Me.gpxViewShippingStatus.Size = New System.Drawing.Size(300, 559)
        Me.gpxViewShippingStatus.TabIndex = 0
        Me.gpxViewShippingStatus.TabStop = False
        Me.gpxViewShippingStatus.Text = "View By Filters"
        '
        'cboSalesPerson
        '
        Me.cboSalesPerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesPerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesPerson.DataSource = Me.EmployeeDataBindingSource
        Me.cboSalesPerson.DisplayMember = "SalesPersonID"
        Me.cboSalesPerson.FormattingEnabled = True
        Me.cboSalesPerson.Location = New System.Drawing.Point(106, 364)
        Me.cboSalesPerson.Name = "cboSalesPerson"
        Me.cboSalesPerson.Size = New System.Drawing.Size(179, 21)
        Me.cboSalesPerson.TabIndex = 10
        '
        'EmployeeDataBindingSource
        '
        Me.EmployeeDataBindingSource.DataMember = "EmployeeData"
        Me.EmployeeDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(23, 365)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 20)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "Salesperson"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipViaSearch
        '
        Me.txtShipViaSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipViaSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipViaSearch.Location = New System.Drawing.Point(106, 334)
        Me.txtShipViaSearch.Name = "txtShipViaSearch"
        Me.txtShipViaSearch.Size = New System.Drawing.Size(179, 20)
        Me.txtShipViaSearch.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(23, 304)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 20)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "PRO #"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSearchByPro
        '
        Me.txtSearchByPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchByPro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearchByPro.Location = New System.Drawing.Point(106, 304)
        Me.txtSearchByPro.Name = "txtSearchByPro"
        Me.txtSearchByPro.Size = New System.Drawing.Size(179, 20)
        Me.txtSearchByPro.TabIndex = 8
        '
        'cboPickNumber
        '
        Me.cboPickNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPickNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPickNumber.DataSource = Me.PickListHeaderTableBindingSource
        Me.cboPickNumber.DisplayMember = "PickListHeaderKey"
        Me.cboPickNumber.FormattingEnabled = True
        Me.cboPickNumber.Location = New System.Drawing.Point(106, 181)
        Me.cboPickNumber.Name = "cboPickNumber"
        Me.cboPickNumber.Size = New System.Drawing.Size(179, 21)
        Me.cboPickNumber.TabIndex = 4
        '
        'PickListHeaderTableBindingSource
        '
        Me.PickListHeaderTableBindingSource.DataMember = "PickListHeaderTable"
        Me.PickListHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(23, 182)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 20)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "Pick Ticket #"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipmentNumber2
        '
        Me.cboShipmentNumber2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentNumber2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentNumber2.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboShipmentNumber2.DisplayMember = "ShipmentNumber"
        Me.cboShipmentNumber2.FormattingEnabled = True
        Me.cboShipmentNumber2.Location = New System.Drawing.Point(106, 212)
        Me.cboShipmentNumber2.Name = "cboShipmentNumber2"
        Me.cboShipmentNumber2.Size = New System.Drawing.Size(179, 21)
        Me.cboShipmentNumber2.TabIndex = 5
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(23, 213)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 20)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "Shipment #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipStatus
        '
        Me.cboShipStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipStatus.FormattingEnabled = True
        Me.cboShipStatus.Items.AddRange(New Object() {"OPEN", "SHIPPED", "INVOICED"})
        Me.cboShipStatus.Location = New System.Drawing.Point(106, 273)
        Me.cboShipStatus.Name = "cboShipStatus"
        Me.cboShipStatus.Size = New System.Drawing.Size(179, 21)
        Me.cboShipStatus.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(23, 274)
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
        Me.txtCustomerPO.Location = New System.Drawing.Point(106, 243)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(179, 20)
        Me.txtCustomerPO.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 402)
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
        Me.chkDateRange.Location = New System.Drawing.Point(102, 424)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 11
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
        Me.cmdClear.Location = New System.Drawing.Point(217, 521)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 15
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
        Me.cboSalesOrderNumber.Location = New System.Drawing.Point(106, 150)
        Me.cboSalesOrderNumber.Name = "cboSalesOrderNumber"
        Me.cboSalesOrderNumber.Size = New System.Drawing.Size(179, 21)
        Me.cboSalesOrderNumber.TabIndex = 3
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdViewByFilters
        '
        Me.cmdViewByFilters.Location = New System.Drawing.Point(140, 521)
        Me.cmdViewByFilters.Name = "cmdViewByFilters"
        Me.cmdViewByFilters.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilters.TabIndex = 14
        Me.cmdViewByFilters.Text = "View"
        Me.cmdViewByFilters.UseVisualStyleBackColor = True
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(19, 121)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(266, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(104, 487)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpEndDate.TabIndex = 13
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(75, 92)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(210, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 487)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 20)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "End Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(23, 151)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 20)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Sales Order #"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(104, 452)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpBeginDate.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 452)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Begin Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Customer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.cboDivisionID.TabIndex = 0
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
        'llFreightDetailForm
        '
        Me.llFreightDetailForm.Location = New System.Drawing.Point(23, 243)
        Me.llFreightDetailForm.Name = "llFreightDetailForm"
        Me.llFreightDetailForm.Size = New System.Drawing.Size(78, 20)
        Me.llFreightDetailForm.TabIndex = 47
        Me.llFreightDetailForm.TabStop = True
        Me.llFreightDetailForm.Text = "Cust. PO #"
        Me.llFreightDetailForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(23, 334)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 20)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "Ship Via"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvShipmentHeaders
        '
        Me.dgvShipmentHeaders.AllowUserToAddRows = False
        Me.dgvShipmentHeaders.AllowUserToDeleteRows = False
        Me.dgvShipmentHeaders.AllowUserToOrderColumns = True
        Me.dgvShipmentHeaders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipmentHeaders.AutoGenerateColumns = False
        Me.dgvShipmentHeaders.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentHeaders.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvShipmentHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentHeaders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DivisionIDColumn, Me.ShipDateColumn, Me.ShipmentNumberColumn, Me.SalesOrderKeyColumn, Me.CustomerIDColumn, Me.CustomerPOColumn, Me.PRONumberColumn, Me.ShipViaColumn, Me.ShippingMethodColumn, Me.FreightQuoteNumberColumn, Me.FreightQuoteAmountColumn, Me.FreightActualAmountColumn, Me.FOBColumn, Me.SalesmanIDColumn, Me.ShippingWeightColumn, Me.NumberOfPalletsColumn, Me.DoubleStackedPalletsColumn, Me.PalletsOnFloorColumn, Me.CommentColumn, Me.SpecialInstructionsColumn, Me.ShipmentStatusColumn, Me.PostedByColumn, Me.ShipToIDColumn, Me.ShipAddress1Column, Me.ShipAddress2Column, Me.ShipCityColumn, Me.ShipStateColumn, Me.ShipZipColumn, Me.ShipCountryColumn, Me.ShipmentTotalColumn, Me.PickTicketNumberColumn, Me.ProductTotalColumn, Me.TaxTotalColumn, Me.Tax2TotalColumn, Me.Tax3TotalColumn})
        Me.dgvShipmentHeaders.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.dgvShipmentHeaders.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipmentHeaders.Location = New System.Drawing.Point(343, 41)
        Me.dgvShipmentHeaders.Name = "dgvShipmentHeaders"
        Me.dgvShipmentHeaders.Size = New System.Drawing.Size(787, 712)
        Me.dgvShipmentHeaders.TabIndex = 25
        Me.dgvShipmentHeaders.TabStop = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        Me.DivisionIDColumn.Width = 65
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ShipDateColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.ReadOnly = True
        Me.ShipDateColumn.Width = 85
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Shipment #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        Me.ShipmentNumberColumn.Width = 85
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        Me.SalesOrderKeyColumn.ReadOnly = True
        Me.SalesOrderKeyColumn.Width = 85
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust. PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        '
        'PRONumberColumn
        '
        Me.PRONumberColumn.DataPropertyName = "PRONumber"
        Me.PRONumberColumn.HeaderText = "PRO #"
        Me.PRONumberColumn.Name = "PRONumberColumn"
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        '
        'ShippingMethodColumn
        '
        Me.ShippingMethodColumn.DataPropertyName = "ShippingMethod"
        Me.ShippingMethodColumn.HeaderText = "Ship Method"
        Me.ShippingMethodColumn.Name = "ShippingMethodColumn"
        '
        'FreightQuoteNumberColumn
        '
        Me.FreightQuoteNumberColumn.DataPropertyName = "FreightQuoteNumber"
        Me.FreightQuoteNumberColumn.HeaderText = "Freight Ref. #"
        Me.FreightQuoteNumberColumn.Name = "FreightQuoteNumberColumn"
        '
        'FreightQuoteAmountColumn
        '
        Me.FreightQuoteAmountColumn.DataPropertyName = "FreightQuoteAmount"
        Me.FreightQuoteAmountColumn.HeaderText = "Quoted Freight"
        Me.FreightQuoteAmountColumn.Name = "FreightQuoteAmountColumn"
        Me.FreightQuoteAmountColumn.Width = 85
        '
        'FreightActualAmountColumn
        '
        Me.FreightActualAmountColumn.DataPropertyName = "FreightActualAmount"
        Me.FreightActualAmountColumn.HeaderText = "Billed Freight"
        Me.FreightActualAmountColumn.Name = "FreightActualAmountColumn"
        Me.FreightActualAmountColumn.ReadOnly = True
        Me.FreightActualAmountColumn.Width = 85
        '
        'FOBColumn
        '
        Me.FOBColumn.DataPropertyName = "FOB"
        Me.FOBColumn.HeaderText = "FOB"
        Me.FOBColumn.Name = "FOBColumn"
        '
        'SalesmanIDColumn
        '
        Me.SalesmanIDColumn.DataPropertyName = "SalesmanID"
        Me.SalesmanIDColumn.HeaderText = "Salesman"
        Me.SalesmanIDColumn.Name = "SalesmanIDColumn"
        '
        'ShippingWeightColumn
        '
        Me.ShippingWeightColumn.DataPropertyName = "ShippingWeight"
        Me.ShippingWeightColumn.HeaderText = "Shipping Weight"
        Me.ShippingWeightColumn.Name = "ShippingWeightColumn"
        Me.ShippingWeightColumn.Width = 85
        '
        'NumberOfPalletsColumn
        '
        Me.NumberOfPalletsColumn.DataPropertyName = "NumberOfPallets"
        Me.NumberOfPalletsColumn.HeaderText = "# of Pallets"
        Me.NumberOfPalletsColumn.Name = "NumberOfPalletsColumn"
        '
        'DoubleStackedPalletsColumn
        '
        Me.DoubleStackedPalletsColumn.DataPropertyName = "DoubleStackedPallets"
        Me.DoubleStackedPalletsColumn.HeaderText = "Double Stacked Pallets"
        Me.DoubleStackedPalletsColumn.Name = "DoubleStackedPalletsColumn"
        '
        'PalletsOnFloorColumn
        '
        Me.PalletsOnFloorColumn.DataPropertyName = "PalletsOnFloor"
        Me.PalletsOnFloorColumn.HeaderText = "Pallets On Floor"
        Me.PalletsOnFloorColumn.Name = "PalletsOnFloorColumn"
        Me.PalletsOnFloorColumn.ReadOnly = True
        '
        'CommentColumn
        '
        Me.CommentColumn.DataPropertyName = "Comment"
        Me.CommentColumn.HeaderText = "Comment"
        Me.CommentColumn.Name = "CommentColumn"
        '
        'SpecialInstructionsColumn
        '
        Me.SpecialInstructionsColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsColumn.HeaderText = "Special Instructions"
        Me.SpecialInstructionsColumn.Name = "SpecialInstructionsColumn"
        '
        'ShipmentStatusColumn
        '
        Me.ShipmentStatusColumn.DataPropertyName = "ShipmentStatus"
        Me.ShipmentStatusColumn.HeaderText = "Status"
        Me.ShipmentStatusColumn.Name = "ShipmentStatusColumn"
        Me.ShipmentStatusColumn.ReadOnly = True
        '
        'PostedByColumn
        '
        Me.PostedByColumn.DataPropertyName = "PostedBy"
        Me.PostedByColumn.HeaderText = "Processed By?"
        Me.PostedByColumn.Name = "PostedByColumn"
        '
        'ShipToIDColumn
        '
        Me.ShipToIDColumn.DataPropertyName = "ShipToID"
        Me.ShipToIDColumn.HeaderText = "Ship ID"
        Me.ShipToIDColumn.Name = "ShipToIDColumn"
        Me.ShipToIDColumn.ReadOnly = True
        '
        'ShipAddress1Column
        '
        Me.ShipAddress1Column.DataPropertyName = "ShipAddress1"
        Me.ShipAddress1Column.HeaderText = "Address 1"
        Me.ShipAddress1Column.Name = "ShipAddress1Column"
        '
        'ShipAddress2Column
        '
        Me.ShipAddress2Column.DataPropertyName = "ShipAddress2"
        Me.ShipAddress2Column.HeaderText = "Address 2"
        Me.ShipAddress2Column.Name = "ShipAddress2Column"
        '
        'ShipCityColumn
        '
        Me.ShipCityColumn.DataPropertyName = "ShipCity"
        Me.ShipCityColumn.HeaderText = "City"
        Me.ShipCityColumn.Name = "ShipCityColumn"
        '
        'ShipStateColumn
        '
        Me.ShipStateColumn.DataPropertyName = "ShipState"
        Me.ShipStateColumn.HeaderText = "State"
        Me.ShipStateColumn.Name = "ShipStateColumn"
        '
        'ShipZipColumn
        '
        Me.ShipZipColumn.DataPropertyName = "ShipZip"
        Me.ShipZipColumn.HeaderText = "Zip"
        Me.ShipZipColumn.Name = "ShipZipColumn"
        '
        'ShipCountryColumn
        '
        Me.ShipCountryColumn.DataPropertyName = "ShipCountry"
        Me.ShipCountryColumn.HeaderText = "Country"
        Me.ShipCountryColumn.Name = "ShipCountryColumn"
        '
        'ShipmentTotalColumn
        '
        Me.ShipmentTotalColumn.DataPropertyName = "ShipmentTotal"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.ShipmentTotalColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.ShipmentTotalColumn.HeaderText = "Shipment Total"
        Me.ShipmentTotalColumn.Name = "ShipmentTotalColumn"
        Me.ShipmentTotalColumn.ReadOnly = True
        Me.ShipmentTotalColumn.Width = 85
        '
        'PickTicketNumberColumn
        '
        Me.PickTicketNumberColumn.DataPropertyName = "PickTicketNumber"
        Me.PickTicketNumberColumn.HeaderText = "Pick Ticket #"
        Me.PickTicketNumberColumn.Name = "PickTicketNumberColumn"
        Me.PickTicketNumberColumn.ReadOnly = True
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        Me.ProductTotalColumn.HeaderText = "ProductTotal"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.ReadOnly = True
        Me.ProductTotalColumn.Visible = False
        '
        'TaxTotalColumn
        '
        Me.TaxTotalColumn.DataPropertyName = "TaxTotal"
        Me.TaxTotalColumn.HeaderText = "TaxTotal"
        Me.TaxTotalColumn.Name = "TaxTotalColumn"
        Me.TaxTotalColumn.ReadOnly = True
        Me.TaxTotalColumn.Visible = False
        '
        'Tax2TotalColumn
        '
        Me.Tax2TotalColumn.DataPropertyName = "Tax2Total"
        Me.Tax2TotalColumn.HeaderText = "Tax2Total"
        Me.Tax2TotalColumn.Name = "Tax2TotalColumn"
        Me.Tax2TotalColumn.Visible = False
        '
        'Tax3TotalColumn
        '
        Me.Tax3TotalColumn.DataPropertyName = "Tax3Total"
        Me.Tax3TotalColumn.HeaderText = "Tax3Total"
        Me.Tax3TotalColumn.Name = "Tax3TotalColumn"
        Me.Tax3TotalColumn.Visible = False
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'gpxEnterPRONumbers
        '
        Me.gpxEnterPRONumbers.Controls.Add(Me.txtShipmentNumber)
        Me.gpxEnterPRONumbers.Controls.Add(Me.Label11)
        Me.gpxEnterPRONumbers.Controls.Add(Me.txtQuotedFreight)
        Me.gpxEnterPRONumbers.Controls.Add(Me.txtQuoteReferenceNumber)
        Me.gpxEnterPRONumbers.Controls.Add(Me.txtFreight)
        Me.gpxEnterPRONumbers.Controls.Add(Me.txtPRONumber)
        Me.gpxEnterPRONumbers.Controls.Add(Me.Label6)
        Me.gpxEnterPRONumbers.Controls.Add(Me.Label10)
        Me.gpxEnterPRONumbers.Controls.Add(Me.Label9)
        Me.gpxEnterPRONumbers.Controls.Add(Me.Label4)
        Me.gpxEnterPRONumbers.Controls.Add(Me.cmdClearPRONumber)
        Me.gpxEnterPRONumbers.Controls.Add(Me.cmdEnterPRONumber)
        Me.gpxEnterPRONumbers.Controls.Add(Me.Label5)
        Me.gpxEnterPRONumbers.Location = New System.Drawing.Point(29, 606)
        Me.gpxEnterPRONumbers.Name = "gpxEnterPRONumbers"
        Me.gpxEnterPRONumbers.Size = New System.Drawing.Size(300, 205)
        Me.gpxEnterPRONumbers.TabIndex = 16
        Me.gpxEnterPRONumbers.TabStop = False
        Me.gpxEnterPRONumbers.Text = "Enter Shipment PRO Numbers / Freight"
        '
        'txtShipmentNumber
        '
        Me.txtShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipmentNumber.Location = New System.Drawing.Point(100, 19)
        Me.txtShipmentNumber.Name = "txtShipmentNumber"
        Me.txtShipmentNumber.Size = New System.Drawing.Size(185, 20)
        Me.txtShipmentNumber.TabIndex = 17
        Me.txtShipmentNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(6, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 45)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "You can only add Billed Freight to a shipment that has not been invoiced."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQuotedFreight
        '
        Me.txtQuotedFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuotedFreight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuotedFreight.Location = New System.Drawing.Point(136, 73)
        Me.txtQuotedFreight.Name = "txtQuotedFreight"
        Me.txtQuotedFreight.Size = New System.Drawing.Size(150, 20)
        Me.txtQuotedFreight.TabIndex = 19
        Me.txtQuotedFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuoteReferenceNumber
        '
        Me.txtQuoteReferenceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuoteReferenceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuoteReferenceNumber.Location = New System.Drawing.Point(136, 100)
        Me.txtQuoteReferenceNumber.Name = "txtQuoteReferenceNumber"
        Me.txtQuoteReferenceNumber.Size = New System.Drawing.Size(150, 20)
        Me.txtQuoteReferenceNumber.TabIndex = 20
        Me.txtQuoteReferenceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreight
        '
        Me.txtFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreight.Location = New System.Drawing.Point(136, 127)
        Me.txtFreight.Name = "txtFreight"
        Me.txtFreight.Size = New System.Drawing.Size(150, 20)
        Me.txtFreight.TabIndex = 21
        Me.txtFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPRONumber
        '
        Me.txtPRONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPRONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRONumber.Location = New System.Drawing.Point(101, 46)
        Me.txtPRONumber.Name = "txtPRONumber"
        Me.txtPRONumber.Size = New System.Drawing.Size(185, 20)
        Me.txtPRONumber.TabIndex = 18
        Me.txtPRONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 20)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Billed Freight"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 20)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Quote Reference #"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Quoted Freight"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Shipment #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearPRONumber
        '
        Me.cmdClearPRONumber.Location = New System.Drawing.Point(216, 162)
        Me.cmdClearPRONumber.Name = "cmdClearPRONumber"
        Me.cmdClearPRONumber.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearPRONumber.TabIndex = 23
        Me.cmdClearPRONumber.Text = "Clear"
        Me.cmdClearPRONumber.UseVisualStyleBackColor = True
        '
        'cmdEnterPRONumber
        '
        Me.cmdEnterPRONumber.Location = New System.Drawing.Point(139, 162)
        Me.cmdEnterPRONumber.Name = "cmdEnterPRONumber"
        Me.cmdEnterPRONumber.Size = New System.Drawing.Size(71, 30)
        Me.cmdEnterPRONumber.TabIndex = 22
        Me.cmdEnterPRONumber.Text = "Save"
        Me.cmdEnterPRONumber.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "PRO #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdReprintPackList
        '
        Me.cmdReprintPackList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReprintPackList.ForeColor = System.Drawing.Color.Blue
        Me.cmdReprintPackList.Location = New System.Drawing.Point(422, 771)
        Me.cmdReprintPackList.Name = "cmdReprintPackList"
        Me.cmdReprintPackList.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprintPackList.TabIndex = 24
        Me.cmdReprintPackList.Text = "Reprint Pack List"
        Me.cmdReprintPackList.UseVisualStyleBackColor = True
        '
        'cmdReprintCert
        '
        Me.cmdReprintCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReprintCert.ForeColor = System.Drawing.Color.Blue
        Me.cmdReprintCert.Location = New System.Drawing.Point(501, 771)
        Me.cmdReprintCert.Name = "cmdReprintCert"
        Me.cmdReprintCert.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprintCert.TabIndex = 25
        Me.cmdReprintCert.Text = "Reprint Cert"
        Me.cmdReprintCert.UseVisualStyleBackColor = True
        '
        'cmdReprintBOL
        '
        Me.cmdReprintBOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReprintBOL.ForeColor = System.Drawing.Color.Blue
        Me.cmdReprintBOL.Location = New System.Drawing.Point(580, 771)
        Me.cmdReprintBOL.Name = "cmdReprintBOL"
        Me.cmdReprintBOL.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprintBOL.TabIndex = 26
        Me.cmdReprintBOL.Text = "Reprint BOL"
        Me.cmdReprintBOL.UseVisualStyleBackColor = True
        '
        'cmdReprintLabel
        '
        Me.cmdReprintLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReprintLabel.ForeColor = System.Drawing.Color.Blue
        Me.cmdReprintLabel.Location = New System.Drawing.Point(659, 771)
        Me.cmdReprintLabel.Name = "cmdReprintLabel"
        Me.cmdReprintLabel.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprintLabel.TabIndex = 27
        Me.cmdReprintLabel.Text = "Reprint Label"
        Me.cmdReprintLabel.UseVisualStyleBackColor = True
        '
        'cmdReprintAll
        '
        Me.cmdReprintAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReprintAll.ForeColor = System.Drawing.Color.Blue
        Me.cmdReprintAll.Location = New System.Drawing.Point(738, 771)
        Me.cmdReprintAll.Name = "cmdReprintAll"
        Me.cmdReprintAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdReprintAll.TabIndex = 28
        Me.cmdReprintAll.Text = "Reprint All"
        Me.cmdReprintAll.UseVisualStyleBackColor = True
        '
        'cmdPrintConfirmation
        '
        Me.cmdPrintConfirmation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintConfirmation.ForeColor = System.Drawing.Color.Blue
        Me.cmdPrintConfirmation.Location = New System.Drawing.Point(896, 771)
        Me.cmdPrintConfirmation.Name = "cmdPrintConfirmation"
        Me.cmdPrintConfirmation.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintConfirmation.TabIndex = 30
        Me.cmdPrintConfirmation.Text = "Print Confirm."
        Me.cmdPrintConfirmation.UseVisualStyleBackColor = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'cmdEmailAll
        '
        Me.cmdEmailAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEmailAll.ForeColor = System.Drawing.Color.Blue
        Me.cmdEmailAll.Location = New System.Drawing.Point(817, 771)
        Me.cmdEmailAll.Name = "cmdEmailAll"
        Me.cmdEmailAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdEmailAll.TabIndex = 29
        Me.cmdEmailAll.Text = "Email All"
        Me.cmdEmailAll.UseVisualStyleBackColor = True
        '
        'cmdViewUploadedPickTicket
        '
        Me.cmdViewUploadedPickTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewUploadedPickTicket.ForeColor = System.Drawing.Color.Blue
        Me.cmdViewUploadedPickTicket.Location = New System.Drawing.Point(345, 771)
        Me.cmdViewUploadedPickTicket.Name = "cmdViewUploadedPickTicket"
        Me.cmdViewUploadedPickTicket.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewUploadedPickTicket.TabIndex = 23
        Me.cmdViewUploadedPickTicket.Text = "View Pick Ticket"
        Me.cmdViewUploadedPickTicket.UseVisualStyleBackColor = True
        '
        'PickListHeaderTableTableAdapter
        '
        Me.PickListHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'EmployeeDataTableAdapter
        '
        Me.EmployeeDataTableAdapter.ClearBeforeFill = True
        '
        'ViewShipmentStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdViewUploadedPickTicket)
        Me.Controls.Add(Me.cmdEmailAll)
        Me.Controls.Add(Me.cmdPrintConfirmation)
        Me.Controls.Add(Me.cmdReprintAll)
        Me.Controls.Add(Me.cmdReprintLabel)
        Me.Controls.Add(Me.cmdReprintBOL)
        Me.Controls.Add(Me.cmdReprintCert)
        Me.Controls.Add(Me.cmdReprintPackList)
        Me.Controls.Add(Me.gpxEnterPRONumbers)
        Me.Controls.Add(Me.dgvShipmentHeaders)
        Me.Controls.Add(Me.gpxViewShippingStatus)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewShipmentStatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Shipment Status Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxViewShippingStatus.ResumeLayout(False)
        Me.gpxViewShippingStatus.PerformLayout()
        CType(Me.EmployeeDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShipmentHeaders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxEnterPRONumbers.ResumeLayout(False)
        Me.gpxEnterPRONumbers.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents gpxViewShippingStatus As System.Windows.Forms.GroupBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvShipmentHeaders As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents gpxEnterPRONumbers As System.Windows.Forms.GroupBox
    Friend WithEvents txtPRONumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdClearPRONumber As System.Windows.Forms.Button
    Friend WithEvents cmdEnterPRONumber As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdReprintPackList As System.Windows.Forms.Button
    Friend WithEvents cmdReprintCert As System.Windows.Forms.Button
    Friend WithEvents cmdReprintBOL As System.Windows.Forms.Button
    Friend WithEvents cmdReprintLabel As System.Windows.Forms.Button
    Friend WithEvents cmdReprintAll As System.Windows.Forms.Button
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFreight As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintConfirmation As System.Windows.Forms.Button
    Friend WithEvents txtQuotedFreight As System.Windows.Forms.TextBox
    Friend WithEvents txtQuoteReferenceNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PrintShipmentMarginReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboSalesOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdViewByFilters As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents CachedCRXAnnealingLog1 As MOS09Program.CachedCRXAnnealingLog
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents cboShipStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboShipmentNumber2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtShipmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdEmailAll As System.Windows.Forms.Button
    Friend WithEvents cmdViewUploadedPickTicket As System.Windows.Forms.Button
    Friend WithEvents cboPickNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PickListHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PickListHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
    Friend WithEvents llFreightDetailForm As System.Windows.Forms.LinkLabel
    Friend WithEvents PrintMultiplePacklToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintMultipleBOLsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintFedexBOLTodayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSearchByPro As System.Windows.Forms.TextBox
    Friend WithEvents PrintPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethodColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightActualAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOBColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesmanIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfPalletsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DoubleStackedPalletsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletsOnFloorColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PostedByColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipToIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress1Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress2Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCountryColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickTicketNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tax2TotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tax3TotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtShipViaSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboSalesPerson As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents EmployeeDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.EmployeeDataTableAdapter
    Friend WithEvents AllShipmentsFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LastThreeFilter As System.Windows.Forms.ToolStripMenuItem
End Class
