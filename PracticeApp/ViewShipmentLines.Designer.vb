<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewShipmentLines
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
        Me.ViewAllLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLast3YearsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxViewShipmentLines = New System.Windows.Forms.GroupBox
        Me.chkExcludeZeroPrice = New System.Windows.Forms.CheckBox
        Me.chkShippedStatus = New System.Windows.Forms.CheckBox
        Me.txtShipProcess = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboPickTicketNumber = New System.Windows.Forms.ComboBox
        Me.PickListHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtShipCity = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtState = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.chkViewDropShips = New System.Windows.Forms.CheckBox
        Me.txtTextFilter = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkViewPending = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.chkDateRange = New System.Windows.Forms.CheckBox
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.dtpBeginDate = New System.Windows.Forms.DateTimePicker
        Me.cboSalesOrderKey = New System.Windows.Forms.ComboBox
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cboShipmentNumber = New System.Windows.Forms.ComboBox
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdViewByFilter = New System.Windows.Forms.Button
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtProductTotal = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTotalQuantity = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtProfitMargin = New System.Windows.Forms.TextBox
        Me.lblMargin = New System.Windows.Forms.Label
        Me.txtTotalCOS = New System.Windows.Forms.TextBox
        Me.lblCOGS = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdoZip = New System.Windows.Forms.RadioButton
        Me.rdoPart = New System.Windows.Forms.RadioButton
        Me.rdoCustomer = New System.Windows.Forms.RadioButton
        Me.rdoShipment = New System.Windows.Forms.RadioButton
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.dgvShipmentLineQuery = New System.Windows.Forms.DataGridView
        Me.CustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OpenSOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertsPulledColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PulledByColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerPOColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCOSColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertificationTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesmanIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOBColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PickTicketNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipStateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipZipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PRONumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightQuoteAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfPalletsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightActualAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipViaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TaxTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductTotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PackingSlipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLogColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertsAutoGeneratedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tax2TotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tax3TotalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropshipColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpecialInstructionsColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineQuery2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentLineQuery2TableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineQuery2TableAdapter
        Me.PickListHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdTWECerts = New System.Windows.Forms.Button
        Me.cmdPackingSlip = New System.Windows.Forms.Button
        Me.cmdCoC = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxViewShipmentLines.SuspendLayout()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvShipmentLineQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewAllLinesToolStripMenuItem, Me.ViewLast3YearsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ViewAllLinesToolStripMenuItem
        '
        Me.ViewAllLinesToolStripMenuItem.CheckOnClick = True
        Me.ViewAllLinesToolStripMenuItem.Name = "ViewAllLinesToolStripMenuItem"
        Me.ViewAllLinesToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ViewAllLinesToolStripMenuItem.Text = "View All Lines"
        '
        'ViewLast3YearsToolStripMenuItem
        '
        Me.ViewLast3YearsToolStripMenuItem.Checked = True
        Me.ViewLast3YearsToolStripMenuItem.CheckOnClick = True
        Me.ViewLast3YearsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ViewLast3YearsToolStripMenuItem.Name = "ViewLast3YearsToolStripMenuItem"
        Me.ViewLast3YearsToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ViewLast3YearsToolStripMenuItem.Text = "View Last 3 Years"
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
        'gpxViewShipmentLines
        '
        Me.gpxViewShipmentLines.Controls.Add(Me.chkExcludeZeroPrice)
        Me.gpxViewShipmentLines.Controls.Add(Me.chkShippedStatus)
        Me.gpxViewShipmentLines.Controls.Add(Me.txtShipProcess)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label19)
        Me.gpxViewShipmentLines.Controls.Add(Me.cboPickTicketNumber)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label18)
        Me.gpxViewShipmentLines.Controls.Add(Me.txtShipCity)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label17)
        Me.gpxViewShipmentLines.Controls.Add(Me.txtZip)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label13)
        Me.gpxViewShipmentLines.Controls.Add(Me.txtState)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label11)
        Me.gpxViewShipmentLines.Controls.Add(Me.chkViewDropShips)
        Me.gpxViewShipmentLines.Controls.Add(Me.txtTextFilter)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label7)
        Me.gpxViewShipmentLines.Controls.Add(Me.chkViewPending)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label12)
        Me.gpxViewShipmentLines.Controls.Add(Me.chkDateRange)
        Me.gpxViewShipmentLines.Controls.Add(Me.dtpEndDate)
        Me.gpxViewShipmentLines.Controls.Add(Me.dtpBeginDate)
        Me.gpxViewShipmentLines.Controls.Add(Me.cboSalesOrderKey)
        Me.gpxViewShipmentLines.Controls.Add(Me.cmdClear)
        Me.gpxViewShipmentLines.Controls.Add(Me.cboShipmentNumber)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label4)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label8)
        Me.gpxViewShipmentLines.Controls.Add(Me.cmdViewByFilter)
        Me.gpxViewShipmentLines.Controls.Add(Me.txtCustomerPO)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label2)
        Me.gpxViewShipmentLines.Controls.Add(Me.cboCustomerName)
        Me.gpxViewShipmentLines.Controls.Add(Me.cboPartDescription)
        Me.gpxViewShipmentLines.Controls.Add(Me.cboCustomerID)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label5)
        Me.gpxViewShipmentLines.Controls.Add(Me.cboPartNumber)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label3)
        Me.gpxViewShipmentLines.Controls.Add(Me.cboDivisionID)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label1)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label10)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label6)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label14)
        Me.gpxViewShipmentLines.Location = New System.Drawing.Point(29, 41)
        Me.gpxViewShipmentLines.Name = "gpxViewShipmentLines"
        Me.gpxViewShipmentLines.Size = New System.Drawing.Size(300, 774)
        Me.gpxViewShipmentLines.TabIndex = 0
        Me.gpxViewShipmentLines.TabStop = False
        Me.gpxViewShipmentLines.Text = "View By Filter Fields"
        '
        'chkExcludeZeroPrice
        '
        Me.chkExcludeZeroPrice.AutoSize = True
        Me.chkExcludeZeroPrice.Location = New System.Drawing.Point(28, 506)
        Me.chkExcludeZeroPrice.Name = "chkExcludeZeroPrice"
        Me.chkExcludeZeroPrice.Size = New System.Drawing.Size(144, 17)
        Me.chkExcludeZeroPrice.TabIndex = 47
        Me.chkExcludeZeroPrice.Text = "Exclude Zero Price Items"
        Me.chkExcludeZeroPrice.UseVisualStyleBackColor = True
        '
        'chkShippedStatus
        '
        Me.chkShippedStatus.AutoSize = True
        Me.chkShippedStatus.Location = New System.Drawing.Point(28, 530)
        Me.chkShippedStatus.Name = "chkShippedStatus"
        Me.chkShippedStatus.Size = New System.Drawing.Size(113, 17)
        Me.chkShippedStatus.TabIndex = 14
        Me.chkShippedStatus.Text = "View Shipped only"
        Me.chkShippedStatus.UseVisualStyleBackColor = True
        '
        'txtShipProcess
        '
        Me.txtShipProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipProcess.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipProcess.Location = New System.Drawing.Point(137, 469)
        Me.txtShipProcess.Name = "txtShipProcess"
        Me.txtShipProcess.Size = New System.Drawing.Size(151, 20)
        Me.txtShipProcess.TabIndex = 13
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(25, 469)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(114, 20)
        Me.Label19.TabIndex = 46
        Me.Label19.Text = "Ship Process Filter"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPickTicketNumber
        '
        Me.cboPickTicketNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPickTicketNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPickTicketNumber.DataSource = Me.PickListHeaderTableBindingSource
        Me.cboPickTicketNumber.DisplayMember = "PickListHeaderKey"
        Me.cboPickTicketNumber.FormattingEnabled = True
        Me.cboPickTicketNumber.Location = New System.Drawing.Point(100, 291)
        Me.cboPickTicketNumber.Name = "cboPickTicketNumber"
        Me.cboPickTicketNumber.Size = New System.Drawing.Size(188, 21)
        Me.cboPickTicketNumber.TabIndex = 7
        '
        'PickListHeaderTableBindingSource
        '
        Me.PickListHeaderTableBindingSource.DataMember = "PickListHeaderTable"
        Me.PickListHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(27, 293)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 20)
        Me.Label18.TabIndex = 44
        Me.Label18.Text = "Pick Ticket #"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipCity
        '
        Me.txtShipCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipCity.Location = New System.Drawing.Point(137, 417)
        Me.txtShipCity.Name = "txtShipCity"
        Me.txtShipCity.Size = New System.Drawing.Size(151, 20)
        Me.txtShipCity.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(25, 417)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 20)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "Ship City"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtZip
        '
        Me.txtZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZip.Location = New System.Drawing.Point(137, 443)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(151, 20)
        Me.txtZip.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(25, 443)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 20)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Ship Postal Code"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtState
        '
        Me.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtState.Location = New System.Drawing.Point(137, 391)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(151, 20)
        Me.txtState.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(25, 391)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 20)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Ship State/Province"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkViewDropShips
        '
        Me.chkViewDropShips.AutoSize = True
        Me.chkViewDropShips.Location = New System.Drawing.Point(28, 578)
        Me.chkViewDropShips.Name = "chkViewDropShips"
        Me.chkViewDropShips.Size = New System.Drawing.Size(128, 17)
        Me.chkViewDropShips.TabIndex = 16
        Me.chkViewDropShips.Text = "View Drop Ships Only"
        Me.chkViewDropShips.UseVisualStyleBackColor = True
        '
        'txtTextFilter
        '
        Me.txtTextFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTextFilter.Location = New System.Drawing.Point(100, 358)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(188, 20)
        Me.txtTextFilter.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(25, 358)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 20)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Text Filter"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkViewPending
        '
        Me.chkViewPending.AutoSize = True
        Me.chkViewPending.Location = New System.Drawing.Point(28, 554)
        Me.chkViewPending.Name = "chkViewPending"
        Me.chkViewPending.Size = New System.Drawing.Size(113, 17)
        Me.chkViewPending.TabIndex = 15
        Me.chkViewPending.Text = "View Pending only"
        Me.chkViewPending.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(19, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 40)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Select fields to filter selection. Select any number of fields to filter selectio" & _
            "n."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.ForeColor = System.Drawing.Color.Black
        Me.chkDateRange.Location = New System.Drawing.Point(100, 631)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(122, 17)
        Me.chkDateRange.TabIndex = 17
        Me.chkDateRange.Text = "Include Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(100, 697)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpEndDate.TabIndex = 19
        '
        'dtpBeginDate
        '
        Me.dtpBeginDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginDate.Location = New System.Drawing.Point(100, 659)
        Me.dtpBeginDate.Name = "dtpBeginDate"
        Me.dtpBeginDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpBeginDate.TabIndex = 18
        '
        'cboSalesOrderKey
        '
        Me.cboSalesOrderKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesOrderKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesOrderKey.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.cboSalesOrderKey.DisplayMember = "SalesOrderKey"
        Me.cboSalesOrderKey.FormattingEnabled = True
        Me.cboSalesOrderKey.Location = New System.Drawing.Point(100, 223)
        Me.cboSalesOrderKey.Name = "cboSalesOrderKey"
        Me.cboSalesOrderKey.Size = New System.Drawing.Size(188, 21)
        Me.cboSalesOrderKey.TabIndex = 5
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(217, 732)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 30)
        Me.cmdClear.TabIndex = 21
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cboShipmentNumber
        '
        Me.cboShipmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboShipmentNumber.DisplayMember = "ShipmentNumber"
        Me.cboShipmentNumber.FormattingEnabled = True
        Me.cboShipmentNumber.Location = New System.Drawing.Point(100, 257)
        Me.cboShipmentNumber.Name = "cboShipmentNumber"
        Me.cboShipmentNumber.Size = New System.Drawing.Size(188, 21)
        Me.cboShipmentNumber.TabIndex = 6
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(25, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Sales Order #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(25, 258)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 20)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Shipment #"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewByFilter
        '
        Me.cmdViewByFilter.Location = New System.Drawing.Point(140, 732)
        Me.cmdViewByFilter.Name = "cmdViewByFilter"
        Me.cmdViewByFilter.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewByFilter.TabIndex = 20
        Me.cmdViewByFilter.Text = "View"
        Me.cmdViewByFilter.UseVisualStyleBackColor = True
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Location = New System.Drawing.Point(100, 325)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(188, 20)
        Me.txtCustomerPO.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(25, 325)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cust. PO #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(22, 119)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(266, 21)
        Me.cboCustomerName.TabIndex = 2
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPartDescription
        '
        Me.cboPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(22, 186)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(266, 21)
        Me.cboPartDescription.TabIndex = 4
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(97, 92)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(191, 21)
        Me.cboCustomerID.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(22, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Customer"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(66, 157)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(222, 21)
        Me.cboPartNumber.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(22, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Part #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(97, 25)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(188, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(22, 697)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "End Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(22, 659)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Begin Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(19, 606)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(269, 28)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "To include date range in the filter, you must check the box."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Location = New System.Drawing.Point(982, 775)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 20
        Me.cmdPrint.Text = "Print Listing"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 775)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 21
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtProductTotal
        '
        Me.txtProductTotal.BackColor = System.Drawing.Color.White
        Me.txtProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductTotal.ForeColor = System.Drawing.Color.Black
        Me.txtProductTotal.Location = New System.Drawing.Point(118, 47)
        Me.txtProductTotal.Name = "txtProductTotal"
        Me.txtProductTotal.ReadOnly = True
        Me.txtProductTotal.Size = New System.Drawing.Size(155, 20)
        Me.txtProductTotal.TabIndex = 15
        Me.txtProductTotal.TabStop = False
        Me.txtProductTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(19, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(146, 20)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Product Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtTotalQuantity)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtProfitMargin)
        Me.GroupBox1.Controls.Add(Me.lblMargin)
        Me.GroupBox1.Controls.Add(Me.txtTotalCOS)
        Me.GroupBox1.Controls.Add(Me.lblCOGS)
        Me.GroupBox1.Controls.Add(Me.txtProductTotal)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(346, 675)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(289, 142)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Total from Datagrid"
        '
        'txtTotalQuantity
        '
        Me.txtTotalQuantity.BackColor = System.Drawing.Color.White
        Me.txtTotalQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQuantity.ForeColor = System.Drawing.Color.Black
        Me.txtTotalQuantity.Location = New System.Drawing.Point(118, 19)
        Me.txtTotalQuantity.Name = "txtTotalQuantity"
        Me.txtTotalQuantity.ReadOnly = True
        Me.txtTotalQuantity.Size = New System.Drawing.Size(155, 20)
        Me.txtTotalQuantity.TabIndex = 27
        Me.txtTotalQuantity.TabStop = False
        Me.txtTotalQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(19, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(146, 20)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Total Quantity"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProfitMargin
        '
        Me.txtProfitMargin.BackColor = System.Drawing.Color.White
        Me.txtProfitMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProfitMargin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProfitMargin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProfitMargin.ForeColor = System.Drawing.Color.Black
        Me.txtProfitMargin.Location = New System.Drawing.Point(118, 109)
        Me.txtProfitMargin.Name = "txtProfitMargin"
        Me.txtProfitMargin.ReadOnly = True
        Me.txtProfitMargin.Size = New System.Drawing.Size(155, 20)
        Me.txtProfitMargin.TabIndex = 17
        Me.txtProfitMargin.TabStop = False
        Me.txtProfitMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMargin
        '
        Me.lblMargin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMargin.Location = New System.Drawing.Point(19, 109)
        Me.lblMargin.Name = "lblMargin"
        Me.lblMargin.Size = New System.Drawing.Size(146, 20)
        Me.lblMargin.TabIndex = 26
        Me.lblMargin.Text = "Margin"
        Me.lblMargin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalCOS
        '
        Me.txtTotalCOS.BackColor = System.Drawing.Color.White
        Me.txtTotalCOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalCOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCOS.ForeColor = System.Drawing.Color.Black
        Me.txtTotalCOS.Location = New System.Drawing.Point(118, 78)
        Me.txtTotalCOS.Name = "txtTotalCOS"
        Me.txtTotalCOS.ReadOnly = True
        Me.txtTotalCOS.Size = New System.Drawing.Size(155, 20)
        Me.txtTotalCOS.TabIndex = 16
        Me.txtTotalCOS.TabStop = False
        Me.txtTotalCOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCOGS
        '
        Me.lblCOGS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOGS.Location = New System.Drawing.Point(19, 78)
        Me.lblCOGS.Name = "lblCOGS"
        Me.lblCOGS.Size = New System.Drawing.Size(146, 20)
        Me.lblCOGS.TabIndex = 24
        Me.lblCOGS.Text = "Total COS"
        Me.lblCOGS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(128, 45)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 57)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "Select grouping to print report."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.rdoZip)
        Me.GroupBox2.Controls.Add(Me.rdoPart)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.rdoCustomer)
        Me.GroupBox2.Controls.Add(Me.rdoShipment)
        Me.GroupBox2.Location = New System.Drawing.Point(641, 675)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(226, 142)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Grouping Level"
        '
        'rdoZip
        '
        Me.rdoZip.AutoSize = True
        Me.rdoZip.Location = New System.Drawing.Point(6, 111)
        Me.rdoZip.Name = "rdoZip"
        Me.rdoZip.Size = New System.Drawing.Size(86, 17)
        Me.rdoZip.TabIndex = 36
        Me.rdoZip.TabStop = True
        Me.rdoZip.Text = "Group by Zip"
        Me.rdoZip.UseVisualStyleBackColor = True
        '
        'rdoPart
        '
        Me.rdoPart.AutoSize = True
        Me.rdoPart.Location = New System.Drawing.Point(6, 83)
        Me.rdoPart.Name = "rdoPart"
        Me.rdoPart.Size = New System.Drawing.Size(101, 17)
        Me.rdoPart.TabIndex = 2
        Me.rdoPart.Text = "Group By Part #"
        Me.rdoPart.UseVisualStyleBackColor = True
        '
        'rdoCustomer
        '
        Me.rdoCustomer.AutoSize = True
        Me.rdoCustomer.Location = New System.Drawing.Point(6, 55)
        Me.rdoCustomer.Name = "rdoCustomer"
        Me.rdoCustomer.Size = New System.Drawing.Size(116, 17)
        Me.rdoCustomer.TabIndex = 1
        Me.rdoCustomer.Text = "Group By Customer"
        Me.rdoCustomer.UseVisualStyleBackColor = True
        '
        'rdoShipment
        '
        Me.rdoShipment.AutoSize = True
        Me.rdoShipment.Checked = True
        Me.rdoShipment.Location = New System.Drawing.Point(6, 27)
        Me.rdoShipment.Name = "rdoShipment"
        Me.rdoShipment.Size = New System.Drawing.Size(126, 17)
        Me.rdoShipment.TabIndex = 0
        Me.rdoShipment.TabStop = True
        Me.rdoShipment.Text = "Group By Shipment #"
        Me.rdoShipment.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'dgvShipmentLineQuery
        '
        Me.dgvShipmentLineQuery.AllowUserToAddRows = False
        Me.dgvShipmentLineQuery.AllowUserToDeleteRows = False
        Me.dgvShipmentLineQuery.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvShipmentLineQuery.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShipmentLineQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipmentLineQuery.AutoGenerateColumns = False
        Me.dgvShipmentLineQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentLineQuery.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvShipmentLineQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentLineQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDColumn, Me.ShipmentNumberColumn, Me.SalesOrderKeyColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.QuantityShippedColumn, Me.OpenSOQuantityColumn, Me.SerialNumberColumn, Me.CertsPulledColumn, Me.PulledByColumn, Me.CustomerPOColumn, Me.ShipDateColumn, Me.DivisionIDColumn, Me.PriceColumn, Me.LineCommentColumn, Me.ExtendedAmountColumn, Me.UnitCostColumn, Me.ExtendedCOSColumn, Me.LineWeightColumn, Me.LineBoxesColumn, Me.LineStatusColumn, Me.CertificationTypeColumn, Me.SalesmanIDColumn, Me.FOBColumn, Me.PickTicketNumberColumn, Me.ShipmentLineNumberColumn, Me.ShipCityColumn, Me.ShipStateColumn, Me.ShipZipColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn, Me.ShipmentTotalColumn, Me.PRONumberColumn, Me.FreightQuoteNumberColumn, Me.FreightQuoteAmountColumn, Me.ShippingWeightColumn, Me.NumberOfPalletsColumn, Me.FreightActualAmountColumn, Me.ShipViaColumn, Me.TaxTotalColumn, Me.ProductTotalColumn, Me.PackingSlipColumn, Me.SOLogColumn, Me.CertsAutoGeneratedColumn, Me.ShipmentStatusColumn, Me.SOLineNumberColumn, Me.SalesTaxColumn, Me.Tax2TotalColumn, Me.Tax3TotalColumn, Me.DropshipColumn, Me.SpecialInstructionsColumn})
        Me.dgvShipmentLineQuery.DataSource = Me.ShipmentLineQuery2BindingSource
        Me.dgvShipmentLineQuery.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipmentLineQuery.Location = New System.Drawing.Point(346, 41)
        Me.dgvShipmentLineQuery.Name = "dgvShipmentLineQuery"
        Me.dgvShipmentLineQuery.Size = New System.Drawing.Size(784, 614)
        Me.dgvShipmentLineQuery.TabIndex = 37
        '
        'CustomerIDColumn
        '
        Me.CustomerIDColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn.HeaderText = "Customer"
        Me.CustomerIDColumn.Name = "CustomerIDColumn"
        Me.CustomerIDColumn.ReadOnly = True
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "Ship. #"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        Me.ShipmentNumberColumn.Width = 80
        '
        'SalesOrderKeyColumn
        '
        Me.SalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SalesOrderKeyColumn.HeaderText = "SO #"
        Me.SalesOrderKeyColumn.Name = "SalesOrderKeyColumn"
        Me.SalesOrderKeyColumn.ReadOnly = True
        Me.SalesOrderKeyColumn.Width = 80
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
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Order Qty."
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.ReadOnly = True
        Me.QuantityColumn.Width = 80
        '
        'QuantityShippedColumn
        '
        Me.QuantityShippedColumn.DataPropertyName = "QuantityShipped"
        Me.QuantityShippedColumn.HeaderText = "Ship Qty."
        Me.QuantityShippedColumn.Name = "QuantityShippedColumn"
        Me.QuantityShippedColumn.ReadOnly = True
        Me.QuantityShippedColumn.Width = 80
        '
        'OpenSOQuantityColumn
        '
        Me.OpenSOQuantityColumn.DataPropertyName = "OpenSOQuantity"
        Me.OpenSOQuantityColumn.HeaderText = "Open Qty."
        Me.OpenSOQuantityColumn.Name = "OpenSOQuantityColumn"
        Me.OpenSOQuantityColumn.ReadOnly = True
        Me.OpenSOQuantityColumn.Width = 80
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Serial Number"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        '
        'CertsPulledColumn
        '
        Me.CertsPulledColumn.DataPropertyName = "CertsPulled"
        Me.CertsPulledColumn.HeaderText = "Certs Pulled?"
        Me.CertsPulledColumn.Name = "CertsPulledColumn"
        '
        'PulledByColumn
        '
        Me.PulledByColumn.DataPropertyName = "PulledBy"
        Me.PulledByColumn.HeaderText = "Pulled By?"
        Me.PulledByColumn.Name = "PulledByColumn"
        '
        'CustomerPOColumn
        '
        Me.CustomerPOColumn.DataPropertyName = "CustomerPO"
        Me.CustomerPOColumn.HeaderText = "Cust PO"
        Me.CustomerPOColumn.Name = "CustomerPOColumn"
        '
        'ShipDateColumn
        '
        Me.ShipDateColumn.DataPropertyName = "ShipDate"
        Me.ShipDateColumn.HeaderText = "Ship Date"
        Me.ShipDateColumn.Name = "ShipDateColumn"
        Me.ShipDateColumn.ReadOnly = True
        Me.ShipDateColumn.Width = 80
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "Division"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.ReadOnly = True
        Me.DivisionIDColumn.Visible = False
        Me.DivisionIDColumn.Width = 60
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.ReadOnly = True
        Me.PriceColumn.Width = 80
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "Ext Amt"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.ReadOnly = True
        Me.UnitCostColumn.Width = 80
        '
        'ExtendedCOSColumn
        '
        Me.ExtendedCOSColumn.DataPropertyName = "ExtendedCOS"
        Me.ExtendedCOSColumn.HeaderText = "Ext COS"
        Me.ExtendedCOSColumn.Name = "ExtendedCOSColumn"
        Me.ExtendedCOSColumn.Width = 80
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        Me.LineWeightColumn.HeaderText = "Line Weight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        '
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        Me.LineBoxesColumn.HeaderText = "Line Boxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        '
        'CertificationTypeColumn
        '
        Me.CertificationTypeColumn.DataPropertyName = "CertificationType"
        Me.CertificationTypeColumn.HeaderText = "Cert. Type"
        Me.CertificationTypeColumn.Name = "CertificationTypeColumn"
        '
        'SalesmanIDColumn
        '
        Me.SalesmanIDColumn.DataPropertyName = "SalesmanID"
        Me.SalesmanIDColumn.HeaderText = "Salesman"
        Me.SalesmanIDColumn.Name = "SalesmanIDColumn"
        '
        'FOBColumn
        '
        Me.FOBColumn.DataPropertyName = "FOB"
        Me.FOBColumn.HeaderText = "FOB"
        Me.FOBColumn.Name = "FOBColumn"
        Me.FOBColumn.ReadOnly = True
        '
        'PickTicketNumberColumn
        '
        Me.PickTicketNumberColumn.DataPropertyName = "PickTicketNumber"
        Me.PickTicketNumberColumn.HeaderText = "PickTicketNumber"
        Me.PickTicketNumberColumn.Name = "PickTicketNumberColumn"
        Me.PickTicketNumberColumn.Visible = False
        '
        'ShipmentLineNumberColumn
        '
        Me.ShipmentLineNumberColumn.DataPropertyName = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn.HeaderText = "Line #"
        Me.ShipmentLineNumberColumn.Name = "ShipmentLineNumberColumn"
        Me.ShipmentLineNumberColumn.ReadOnly = True
        Me.ShipmentLineNumberColumn.Visible = False
        Me.ShipmentLineNumberColumn.Width = 60
        '
        'ShipCityColumn
        '
        Me.ShipCityColumn.DataPropertyName = "ShipCity"
        Me.ShipCityColumn.HeaderText = "Ship City"
        Me.ShipCityColumn.Name = "ShipCityColumn"
        '
        'ShipStateColumn
        '
        Me.ShipStateColumn.DataPropertyName = "ShipState"
        Me.ShipStateColumn.HeaderText = "Ship State"
        Me.ShipStateColumn.Name = "ShipStateColumn"
        '
        'ShipZipColumn
        '
        Me.ShipZipColumn.DataPropertyName = "ShipZip"
        Me.ShipZipColumn.HeaderText = "Ship Zip"
        Me.ShipZipColumn.Name = "ShipZipColumn"
        '
        'GLDebitAccountColumn
        '
        Me.GLDebitAccountColumn.DataPropertyName = "GLDebitAccount"
        Me.GLDebitAccountColumn.HeaderText = "GLDebitAccount"
        Me.GLDebitAccountColumn.Name = "GLDebitAccountColumn"
        Me.GLDebitAccountColumn.Visible = False
        '
        'GLCreditAccountColumn
        '
        Me.GLCreditAccountColumn.DataPropertyName = "GLCreditAccount"
        Me.GLCreditAccountColumn.HeaderText = "GLCreditAccount"
        Me.GLCreditAccountColumn.Name = "GLCreditAccountColumn"
        Me.GLCreditAccountColumn.Visible = False
        '
        'ShipmentTotalColumn
        '
        Me.ShipmentTotalColumn.DataPropertyName = "ShipmentTotal"
        Me.ShipmentTotalColumn.HeaderText = "ShipmentTotal"
        Me.ShipmentTotalColumn.Name = "ShipmentTotalColumn"
        Me.ShipmentTotalColumn.Visible = False
        '
        'PRONumberColumn
        '
        Me.PRONumberColumn.DataPropertyName = "PRONumber"
        Me.PRONumberColumn.HeaderText = "PRONumber"
        Me.PRONumberColumn.Name = "PRONumberColumn"
        Me.PRONumberColumn.Visible = False
        '
        'FreightQuoteNumberColumn
        '
        Me.FreightQuoteNumberColumn.DataPropertyName = "FreightQuoteNumber"
        Me.FreightQuoteNumberColumn.HeaderText = "FreightQuoteNumber"
        Me.FreightQuoteNumberColumn.Name = "FreightQuoteNumberColumn"
        Me.FreightQuoteNumberColumn.Visible = False
        '
        'FreightQuoteAmountColumn
        '
        Me.FreightQuoteAmountColumn.DataPropertyName = "FreightQuoteAmount"
        Me.FreightQuoteAmountColumn.HeaderText = "FreightQuoteAmount"
        Me.FreightQuoteAmountColumn.Name = "FreightQuoteAmountColumn"
        Me.FreightQuoteAmountColumn.Visible = False
        '
        'ShippingWeightColumn
        '
        Me.ShippingWeightColumn.DataPropertyName = "ShippingWeight"
        Me.ShippingWeightColumn.HeaderText = "ShippingWeight"
        Me.ShippingWeightColumn.Name = "ShippingWeightColumn"
        Me.ShippingWeightColumn.Visible = False
        '
        'NumberOfPalletsColumn
        '
        Me.NumberOfPalletsColumn.DataPropertyName = "NumberOfPallets"
        Me.NumberOfPalletsColumn.HeaderText = "NumberOfPallets"
        Me.NumberOfPalletsColumn.Name = "NumberOfPalletsColumn"
        Me.NumberOfPalletsColumn.Visible = False
        '
        'FreightActualAmountColumn
        '
        Me.FreightActualAmountColumn.DataPropertyName = "FreightActualAmount"
        Me.FreightActualAmountColumn.HeaderText = "FreightActualAmount"
        Me.FreightActualAmountColumn.Name = "FreightActualAmountColumn"
        Me.FreightActualAmountColumn.Visible = False
        '
        'ShipViaColumn
        '
        Me.ShipViaColumn.DataPropertyName = "ShipVia"
        Me.ShipViaColumn.HeaderText = "Ship Via"
        Me.ShipViaColumn.Name = "ShipViaColumn"
        '
        'TaxTotalColumn
        '
        Me.TaxTotalColumn.DataPropertyName = "TaxTotal"
        Me.TaxTotalColumn.HeaderText = "TaxTotal"
        Me.TaxTotalColumn.Name = "TaxTotalColumn"
        Me.TaxTotalColumn.Visible = False
        '
        'ProductTotalColumn
        '
        Me.ProductTotalColumn.DataPropertyName = "ProductTotal"
        Me.ProductTotalColumn.HeaderText = "ProductTotal"
        Me.ProductTotalColumn.Name = "ProductTotalColumn"
        Me.ProductTotalColumn.Visible = False
        '
        'PackingSlipColumn
        '
        Me.PackingSlipColumn.DataPropertyName = "PackingSlip"
        Me.PackingSlipColumn.HeaderText = "Packing Slip"
        Me.PackingSlipColumn.Name = "PackingSlipColumn"
        '
        'SOLogColumn
        '
        Me.SOLogColumn.DataPropertyName = "SOLog"
        Me.SOLogColumn.HeaderText = "SO Log"
        Me.SOLogColumn.Name = "SOLogColumn"
        '
        'CertsAutoGeneratedColumn
        '
        Me.CertsAutoGeneratedColumn.DataPropertyName = "CertsAutoGenerated"
        Me.CertsAutoGeneratedColumn.HeaderText = "Certs Auto Generated?"
        Me.CertsAutoGeneratedColumn.Name = "CertsAutoGeneratedColumn"
        '
        'ShipmentStatusColumn
        '
        Me.ShipmentStatusColumn.DataPropertyName = "ShipmentStatus"
        Me.ShipmentStatusColumn.HeaderText = "ShipmentStatus"
        Me.ShipmentStatusColumn.Name = "ShipmentStatusColumn"
        Me.ShipmentStatusColumn.Visible = False
        '
        'SOLineNumberColumn
        '
        Me.SOLineNumberColumn.DataPropertyName = "SOLineNumber"
        Me.SOLineNumberColumn.HeaderText = "SOLineNumber"
        Me.SOLineNumberColumn.Name = "SOLineNumberColumn"
        Me.SOLineNumberColumn.Visible = False
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.Visible = False
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
        'DropshipColumn
        '
        Me.DropshipColumn.DataPropertyName = "Dropship"
        Me.DropshipColumn.HeaderText = "Dropship"
        Me.DropshipColumn.Name = "DropshipColumn"
        '
        'SpecialInstructionsColumn
        '
        Me.SpecialInstructionsColumn.DataPropertyName = "SpecialInstructions"
        Me.SpecialInstructionsColumn.HeaderText = "SpecialInstructions"
        Me.SpecialInstructionsColumn.Name = "SpecialInstructionsColumn"
        Me.SpecialInstructionsColumn.Visible = False
        '
        'ShipmentLineQuery2BindingSource
        '
        Me.ShipmentLineQuery2BindingSource.DataMember = "ShipmentLineQuery2"
        Me.ShipmentLineQuery2BindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentLineQuery2TableAdapter
        '
        Me.ShipmentLineQuery2TableAdapter.ClearBeforeFill = True
        '
        'PickListHeaderTableTableAdapter
        '
        Me.PickListHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cmdTWECerts)
        Me.GroupBox3.Controls.Add(Me.cmdPackingSlip)
        Me.GroupBox3.Controls.Add(Me.cmdCoC)
        Me.GroupBox3.Location = New System.Drawing.Point(873, 675)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(257, 83)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Print Structural Docs"
        '
        'cmdTWECerts
        '
        Me.cmdTWECerts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTWECerts.Location = New System.Drawing.Point(165, 25)
        Me.cmdTWECerts.Name = "cmdTWECerts"
        Me.cmdTWECerts.Size = New System.Drawing.Size(71, 40)
        Me.cmdTWECerts.TabIndex = 41
        Me.cmdTWECerts.Text = "Weld Stud Cert"
        Me.cmdTWECerts.UseVisualStyleBackColor = True
        '
        'cmdPackingSlip
        '
        Me.cmdPackingSlip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPackingSlip.AutoSize = True
        Me.cmdPackingSlip.Location = New System.Drawing.Point(88, 25)
        Me.cmdPackingSlip.Name = "cmdPackingSlip"
        Me.cmdPackingSlip.Size = New System.Drawing.Size(76, 40)
        Me.cmdPackingSlip.TabIndex = 40
        Me.cmdPackingSlip.Text = "Packing Slip"
        Me.cmdPackingSlip.UseVisualStyleBackColor = True
        '
        'cmdCoC
        '
        Me.cmdCoC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCoC.AutoSize = True
        Me.cmdCoC.Location = New System.Drawing.Point(16, 25)
        Me.cmdCoC.Name = "cmdCoC"
        Me.cmdCoC.Size = New System.Drawing.Size(71, 40)
        Me.cmdCoC.TabIndex = 21
        Me.cmdCoC.Text = "CoC"
        Me.cmdCoC.UseVisualStyleBackColor = True
        '
        'ViewShipmentLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgvShipmentLineQuery)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxViewShipmentLines)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ViewShipmentLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Shipment Line Details"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxViewShipmentLines.ResumeLayout(False)
        Me.gpxViewShipmentLines.PerformLayout()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvShipmentLineQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentLineQuery2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents gpxViewShipmentLines As System.Windows.Forms.GroupBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboShipmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents PrintListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtProductTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboSalesOrderKey As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdViewByFilter As System.Windows.Forms.Button
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCOS As System.Windows.Forms.TextBox
    Friend WithEvents lblCOGS As System.Windows.Forms.Label
    Friend WithEvents txtProfitMargin As System.Windows.Forms.TextBox
    Friend WithEvents lblMargin As System.Windows.Forms.Label
    Friend WithEvents txtTotalQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPart As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCustomer As System.Windows.Forms.RadioButton
    Friend WithEvents rdoShipment As System.Windows.Forms.RadioButton
    Friend WithEvents dgvShipmentLineQuery As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentLineQuery2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentLineQuery2TableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineQuery2TableAdapter
    Friend WithEvents chkViewPending As System.Windows.Forms.CheckBox
    Friend WithEvents txtTextFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkViewDropShips As System.Windows.Forms.CheckBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtShipCity As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents rdoZip As System.Windows.Forms.RadioButton
    Friend WithEvents cboPickTicketNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtShipProcess As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents chkShippedStatus As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcludeZeroPrice As System.Windows.Forms.CheckBox
    Friend WithEvents ViewAllLinesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLast3YearsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PickListHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PickListHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCoC As System.Windows.Forms.Button
    Friend WithEvents cmdPackingSlip As System.Windows.Forms.Button
    Friend WithEvents cmdTWECerts As System.Windows.Forms.Button
    Friend WithEvents CustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenSOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertsPulledColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PulledByColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerPOColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCOSColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertificationTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesmanIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOBColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickTicketNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipStateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipZipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRONumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightQuoteAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfPalletsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightActualAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipViaColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductTotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingSlipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLogColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertsAutoGeneratedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tax2TotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tax3TotalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropshipColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecialInstructionsColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
