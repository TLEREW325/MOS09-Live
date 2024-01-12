<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShipmentLineComments
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
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SetShipmentToShippedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SetShipmentToPendingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SetShipmentToClosedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintShipmentDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPackingListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintCertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintBOLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintProfitabilityReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintEmailConfirmationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendUploadedPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxViewShipmentLines = New System.Windows.Forms.GroupBox
        Me.cboPickTicketNumber = New System.Windows.Forms.ComboBox
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboShipmentNumber = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblSONumber = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtFreight = New System.Windows.Forms.TextBox
        Me.cmdBOL = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxShipmentDetails = New System.Windows.Forms.GroupBox
        Me.txtPRONumber = New System.Windows.Forms.TextBox
        Me.txtDoubleStackedPallets = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.txtShippingAccount = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtThirdParty = New System.Windows.Forms.TextBox
        Me.cboShipMethod = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblNumberBoxes = New System.Windows.Forms.Label
        Me.txtShipWeight = New System.Windows.Forms.TextBox
        Me.txtNumberPallets = New System.Windows.Forms.TextBox
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.txtFreightQuoteAmount = New System.Windows.Forms.TextBox
        Me.txtFreightQuoteNumber = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblShipDate = New System.Windows.Forms.Label
        Me.lblCustomerName = New System.Windows.Forms.Label
        Me.lblCustomerID = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblShipEmail = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.gpxShippingAddress = New System.Windows.Forms.GroupBox
        Me.cboShipToCountryName = New System.Windows.Forms.ComboBox
        Me.CountryCodesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.txtShipToName = New System.Windows.Forms.TextBox
        Me.cboShipToID = New System.Windows.Forms.ComboBox
        Me.AdditionalShipToBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.gpxShipmentTotals = New System.Windows.Forms.GroupBox
        Me.lblPalletsOnFloor = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.lblShipmentTotal = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.lblFreight = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.lblSalesTax = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.lblProductTotal = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.dgvShipLines = New System.Windows.Forms.DataGridView
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertificationTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineTableTableAdapter
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSpecialInstructions = New System.Windows.Forms.TextBox
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.cmdPackList = New System.Windows.Forms.Button
        Me.cmdCert = New System.Windows.Forms.Button
        Me.tabShipmentLines = New System.Windows.Forms.TabControl
        Me.tabLineComments = New System.Windows.Forms.TabPage
        Me.tabLineLotNumbers = New System.Windows.Forms.TabPage
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdDeleteLotNumber = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmdUpdateInvoice = New System.Windows.Forms.Button
        Me.txtHeatQuantity = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtLotNumber = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdAddLotNumber = New System.Windows.Forms.Button
        Me.lblPartDescription = New System.Windows.Forms.Label
        Me.lblPartNumber = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboShipmentLineNumber = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvLotNumbers = New System.Windows.Forms.DataGridView
        Me.ShipmentNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotLineNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatQuantityColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PullTestNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineLotNumbersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabSerialNumbers = New System.Windows.Forms.TabPage
        Me.cmdDeleteSerialNumber = New System.Windows.Forms.Button
        Me.cmdUpdateInvoiceWithSN = New System.Windows.Forms.Button
        Me.cmdAddSerialNumber = New System.Windows.Forms.Button
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtSerialNumber = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.lblSNPartDescription = New System.Windows.Forms.Label
        Me.lblSNPartNumber = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.cboSNShipmentLineNumber = New System.Windows.Forms.ComboBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.dgvShipmentLineSerialNumbers = New System.Windows.Forms.DataGridView
        Me.ShipmentNumberColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineNumberColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialLineNumberColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialCostColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialQuantityColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineSerialNumbersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentLineLotNumbersTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineLotNumbersTableAdapter
        Me.cmdSave = New System.Windows.Forms.Button
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.AdditionalShipToTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
        Me.cmdRePrintShippingLabel = New System.Windows.Forms.Button
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.ShipmentLineSerialNumbersTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineSerialNumbersTableAdapter
        Me.CountryCodesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CountryCodesTableAdapter
        Me.cmdUploadPickTicket = New System.Windows.Forms.Button
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tabCommentsTab = New System.Windows.Forms.TabControl
        Me.tabInstructions = New System.Windows.Forms.TabPage
        Me.tabComments = New System.Windows.Forms.TabPage
        Me.cmdViewULPicks = New System.Windows.Forms.Button
        Me.cmdRemoteScan = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxViewShipmentLines.SuspendLayout()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxShipmentDetails.SuspendLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxShippingAddress.SuspendLayout()
        CType(Me.CountryCodesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxShipmentTotals.SuspendLayout()
        CType(Me.dgvShipLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabShipmentLines.SuspendLayout()
        Me.tabLineComments.SuspendLayout()
        Me.tabLineLotNumbers.SuspendLayout()
        CType(Me.dgvLotNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentLineLotNumbersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSerialNumbers.SuspendLayout()
        CType(Me.dgvShipmentLineSerialNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentLineSerialNumbersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCommentsTab.SuspendLayout()
        Me.tabInstructions.SuspendLayout()
        Me.tabComments.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.ClearFormToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ClearFormToolStripMenuItem
        '
        Me.ClearFormToolStripMenuItem.Name = "ClearFormToolStripMenuItem"
        Me.ClearFormToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ClearFormToolStripMenuItem.Text = "Clear Form"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetShipmentToShippedToolStripMenuItem, Me.SetShipmentToPendingToolStripMenuItem, Me.SetShipmentToClosedToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SetShipmentToShippedToolStripMenuItem
        '
        Me.SetShipmentToShippedToolStripMenuItem.Enabled = False
        Me.SetShipmentToShippedToolStripMenuItem.Name = "SetShipmentToShippedToolStripMenuItem"
        Me.SetShipmentToShippedToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.SetShipmentToShippedToolStripMenuItem.Text = "Set Shipment to Shipped"
        '
        'SetShipmentToPendingToolStripMenuItem
        '
        Me.SetShipmentToPendingToolStripMenuItem.Enabled = False
        Me.SetShipmentToPendingToolStripMenuItem.Name = "SetShipmentToPendingToolStripMenuItem"
        Me.SetShipmentToPendingToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.SetShipmentToPendingToolStripMenuItem.Text = "Set Shipment to Pending"
        '
        'SetShipmentToClosedToolStripMenuItem
        '
        Me.SetShipmentToClosedToolStripMenuItem.Enabled = False
        Me.SetShipmentToClosedToolStripMenuItem.Name = "SetShipmentToClosedToolStripMenuItem"
        Me.SetShipmentToClosedToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.SetShipmentToClosedToolStripMenuItem.Text = "Set Shipment to Closed"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintShipmentDataToolStripMenuItem, Me.PrintPackingListToolStripMenuItem, Me.PrintCertToolStripMenuItem, Me.PrintBOLToolStripMenuItem, Me.PrintProfitabilityReportToolStripMenuItem, Me.PrintEmailConfirmationToolStripMenuItem, Me.ReUploadPickTicketToolStripMenuItem, Me.AppendUploadedPickTicketToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'PrintShipmentDataToolStripMenuItem
        '
        Me.PrintShipmentDataToolStripMenuItem.Name = "PrintShipmentDataToolStripMenuItem"
        Me.PrintShipmentDataToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.PrintShipmentDataToolStripMenuItem.Text = "Print Shipment Data"
        '
        'PrintPackingListToolStripMenuItem
        '
        Me.PrintPackingListToolStripMenuItem.Name = "PrintPackingListToolStripMenuItem"
        Me.PrintPackingListToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.PrintPackingListToolStripMenuItem.Text = "Print Packing List"
        '
        'PrintCertToolStripMenuItem
        '
        Me.PrintCertToolStripMenuItem.Name = "PrintCertToolStripMenuItem"
        Me.PrintCertToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.PrintCertToolStripMenuItem.Text = "Print Cert"
        '
        'PrintBOLToolStripMenuItem
        '
        Me.PrintBOLToolStripMenuItem.Name = "PrintBOLToolStripMenuItem"
        Me.PrintBOLToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.PrintBOLToolStripMenuItem.Text = "Print BOL"
        '
        'PrintProfitabilityReportToolStripMenuItem
        '
        Me.PrintProfitabilityReportToolStripMenuItem.Name = "PrintProfitabilityReportToolStripMenuItem"
        Me.PrintProfitabilityReportToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.PrintProfitabilityReportToolStripMenuItem.Text = "Print Profitability Report"
        '
        'PrintEmailConfirmationToolStripMenuItem
        '
        Me.PrintEmailConfirmationToolStripMenuItem.Name = "PrintEmailConfirmationToolStripMenuItem"
        Me.PrintEmailConfirmationToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.PrintEmailConfirmationToolStripMenuItem.Text = "Print / Email Confirmation"
        '
        'ReUploadPickTicketToolStripMenuItem
        '
        Me.ReUploadPickTicketToolStripMenuItem.Enabled = False
        Me.ReUploadPickTicketToolStripMenuItem.Name = "ReUploadPickTicketToolStripMenuItem"
        Me.ReUploadPickTicketToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ReUploadPickTicketToolStripMenuItem.Text = "Re-Upload Pick Ticket"
        '
        'AppendUploadedPickTicketToolStripMenuItem
        '
        Me.AppendUploadedPickTicketToolStripMenuItem.Enabled = False
        Me.AppendUploadedPickTicketToolStripMenuItem.Name = "AppendUploadedPickTicketToolStripMenuItem"
        Me.AppendUploadedPickTicketToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.AppendUploadedPickTicketToolStripMenuItem.Text = "Append Uploaded Pick Ticket"
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
        Me.gpxViewShipmentLines.Controls.Add(Me.cboPickTicketNumber)
        Me.gpxViewShipmentLines.Controls.Add(Me.cboShipmentNumber)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label3)
        Me.gpxViewShipmentLines.Controls.Add(Me.cboDivisionID)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label1)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label19)
        Me.gpxViewShipmentLines.Controls.Add(Me.lblSONumber)
        Me.gpxViewShipmentLines.Controls.Add(Me.Label23)
        Me.gpxViewShipmentLines.Location = New System.Drawing.Point(29, 41)
        Me.gpxViewShipmentLines.Name = "gpxViewShipmentLines"
        Me.gpxViewShipmentLines.Size = New System.Drawing.Size(300, 142)
        Me.gpxViewShipmentLines.TabIndex = 0
        Me.gpxViewShipmentLines.TabStop = False
        Me.gpxViewShipmentLines.Text = "Filter Shipment Lines"
        '
        'cboPickTicketNumber
        '
        Me.cboPickTicketNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPickTicketNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPickTicketNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboPickTicketNumber.DisplayMember = "PickTicketNumber"
        Me.cboPickTicketNumber.FormattingEnabled = True
        Me.cboPickTicketNumber.Location = New System.Drawing.Point(96, 84)
        Me.cboPickTicketNumber.Name = "cboPickTicketNumber"
        Me.cboPickTicketNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboPickTicketNumber.TabIndex = 2
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
        'cboShipmentNumber
        '
        Me.cboShipmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboShipmentNumber.DisplayMember = "ShipmentNumber"
        Me.cboShipmentNumber.FormattingEnabled = True
        Me.cboShipmentNumber.Location = New System.Drawing.Point(96, 54)
        Me.cboShipmentNumber.Name = "cboShipmentNumber"
        Me.cboShipmentNumber.Size = New System.Drawing.Size(189, 21)
        Me.cboShipmentNumber.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Shipment #"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.Enabled = False
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(96, 24)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(189, 21)
        Me.cboDivisionID.TabIndex = 0
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(13, 85)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 20)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Pick #"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSONumber
        '
        Me.lblSONumber.BackColor = System.Drawing.Color.White
        Me.lblSONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSONumber.Location = New System.Drawing.Point(96, 114)
        Me.lblSONumber.Name = "lblSONumber"
        Me.lblSONumber.Size = New System.Drawing.Size(189, 21)
        Me.lblSONumber.TabIndex = 3
        Me.lblSONumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(13, 113)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 20)
        Me.Label23.TabIndex = 22
        Me.Label23.Text = "Sales Order #"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreight
        '
        Me.txtFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreight.Location = New System.Drawing.Point(153, 479)
        Me.txtFreight.Name = "txtFreight"
        Me.txtFreight.Size = New System.Drawing.Size(132, 20)
        Me.txtFreight.TabIndex = 17
        Me.txtFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdBOL
        '
        Me.cmdBOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBOL.Location = New System.Drawing.Point(979, 772)
        Me.cmdBOL.Name = "cmdBOL"
        Me.cmdBOL.Size = New System.Drawing.Size(71, 40)
        Me.cmdBOL.TabIndex = 37
        Me.cmdBOL.Text = "Re-Print BOL"
        Me.cmdBOL.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1056, 772)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 38
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxShipmentDetails
        '
        Me.gpxShipmentDetails.Controls.Add(Me.txtPRONumber)
        Me.gpxShipmentDetails.Controls.Add(Me.txtDoubleStackedPallets)
        Me.gpxShipmentDetails.Controls.Add(Me.Label37)
        Me.gpxShipmentDetails.Controls.Add(Me.txtShippingAccount)
        Me.gpxShipmentDetails.Controls.Add(Me.Label31)
        Me.gpxShipmentDetails.Controls.Add(Me.lblStatus)
        Me.gpxShipmentDetails.Controls.Add(Me.Label24)
        Me.gpxShipmentDetails.Controls.Add(Me.txtThirdParty)
        Me.gpxShipmentDetails.Controls.Add(Me.cboShipMethod)
        Me.gpxShipmentDetails.Controls.Add(Me.Label15)
        Me.gpxShipmentDetails.Controls.Add(Me.cboShipVia)
        Me.gpxShipmentDetails.Controls.Add(Me.lblNumberBoxes)
        Me.gpxShipmentDetails.Controls.Add(Me.txtShipWeight)
        Me.gpxShipmentDetails.Controls.Add(Me.txtNumberPallets)
        Me.gpxShipmentDetails.Controls.Add(Me.txtCustomerPO)
        Me.gpxShipmentDetails.Controls.Add(Me.txtFreightQuoteAmount)
        Me.gpxShipmentDetails.Controls.Add(Me.txtFreightQuoteNumber)
        Me.gpxShipmentDetails.Controls.Add(Me.Label18)
        Me.gpxShipmentDetails.Controls.Add(Me.Label9)
        Me.gpxShipmentDetails.Controls.Add(Me.Label6)
        Me.gpxShipmentDetails.Controls.Add(Me.txtFreight)
        Me.gpxShipmentDetails.Controls.Add(Me.Label28)
        Me.gpxShipmentDetails.Controls.Add(Me.Label29)
        Me.gpxShipmentDetails.Controls.Add(Me.Label30)
        Me.gpxShipmentDetails.Controls.Add(Me.Label16)
        Me.gpxShipmentDetails.Controls.Add(Me.Label17)
        Me.gpxShipmentDetails.Controls.Add(Me.Label20)
        Me.gpxShipmentDetails.Controls.Add(Me.Label22)
        Me.gpxShipmentDetails.Controls.Add(Me.Label21)
        Me.gpxShipmentDetails.Controls.Add(Me.lblShipDate)
        Me.gpxShipmentDetails.Controls.Add(Me.lblCustomerName)
        Me.gpxShipmentDetails.Controls.Add(Me.lblCustomerID)
        Me.gpxShipmentDetails.Controls.Add(Me.Label2)
        Me.gpxShipmentDetails.Location = New System.Drawing.Point(29, 189)
        Me.gpxShipmentDetails.Name = "gpxShipmentDetails"
        Me.gpxShipmentDetails.Size = New System.Drawing.Size(300, 623)
        Me.gpxShipmentDetails.TabIndex = 4
        Me.gpxShipmentDetails.TabStop = False
        Me.gpxShipmentDetails.Text = "Shipment Details"
        '
        'txtPRONumber
        '
        Me.txtPRONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPRONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRONumber.Location = New System.Drawing.Point(109, 371)
        Me.txtPRONumber.Name = "txtPRONumber"
        Me.txtPRONumber.Size = New System.Drawing.Size(176, 20)
        Me.txtPRONumber.TabIndex = 13
        Me.txtPRONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDoubleStackedPallets
        '
        Me.txtDoubleStackedPallets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDoubleStackedPallets.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDoubleStackedPallets.Location = New System.Drawing.Point(153, 589)
        Me.txtDoubleStackedPallets.Name = "txtDoubleStackedPallets"
        Me.txtDoubleStackedPallets.Size = New System.Drawing.Size(132, 20)
        Me.txtDoubleStackedPallets.TabIndex = 37
        Me.txtDoubleStackedPallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.ForeColor = System.Drawing.Color.Blue
        Me.Label37.Location = New System.Drawing.Point(13, 560)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(134, 20)
        Me.Label37.TabIndex = 38
        Me.Label37.Text = "# of Pallets"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShippingAccount
        '
        Me.txtShippingAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingAccount.Location = New System.Drawing.Point(109, 398)
        Me.txtShippingAccount.Name = "txtShippingAccount"
        Me.txtShippingAccount.Size = New System.Drawing.Size(176, 20)
        Me.txtShippingAccount.TabIndex = 14
        Me.txtShippingAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.ForeColor = System.Drawing.Color.Blue
        Me.Label31.Location = New System.Drawing.Point(13, 398)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(100, 20)
        Me.Label31.TabIndex = 36
        Me.Label31.Text = "Freight Acct. #"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.White
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(83, 20)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(202, 20)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(13, 259)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(196, 20)
        Me.Label24.TabIndex = 34
        Me.Label24.Text = "Third Party Billing"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtThirdParty
        '
        Me.txtThirdParty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThirdParty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtThirdParty.Enabled = False
        Me.txtThirdParty.Location = New System.Drawing.Point(16, 280)
        Me.txtThirdParty.MaxLength = 500
        Me.txtThirdParty.Multiline = True
        Me.txtThirdParty.Name = "txtThirdParty"
        Me.txtThirdParty.Size = New System.Drawing.Size(269, 85)
        Me.txtThirdParty.TabIndex = 12
        '
        'cboShipMethod
        '
        Me.cboShipMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipMethod.FormattingEnabled = True
        Me.cboShipMethod.Items.AddRange(New Object() {"COLLECT", "PREPAID", "PREPAID/ADD", "PREPAID/NOADD", "THIRD PARTY", "OTHER"})
        Me.cboShipMethod.Location = New System.Drawing.Point(83, 230)
        Me.cboShipMethod.MaxLength = 50
        Me.cboShipMethod.Name = "cboShipMethod"
        Me.cboShipMethod.Size = New System.Drawing.Size(202, 21)
        Me.cboShipMethod.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(16, 230)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 20)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Ship Method"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipVia
        '
        Me.cboShipVia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipVia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(83, 200)
        Me.cboShipVia.MaxLength = 50
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(202, 21)
        Me.cboShipVia.TabIndex = 10
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblNumberBoxes
        '
        Me.lblNumberBoxes.BackColor = System.Drawing.Color.White
        Me.lblNumberBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumberBoxes.Location = New System.Drawing.Point(153, 533)
        Me.lblNumberBoxes.Name = "lblNumberBoxes"
        Me.lblNumberBoxes.Size = New System.Drawing.Size(132, 20)
        Me.lblNumberBoxes.TabIndex = 19
        Me.lblNumberBoxes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtShipWeight
        '
        Me.txtShipWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipWeight.Location = New System.Drawing.Point(153, 506)
        Me.txtShipWeight.Name = "txtShipWeight"
        Me.txtShipWeight.Size = New System.Drawing.Size(132, 20)
        Me.txtShipWeight.TabIndex = 18
        Me.txtShipWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumberPallets
        '
        Me.txtNumberPallets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberPallets.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberPallets.Location = New System.Drawing.Point(153, 562)
        Me.txtNumberPallets.Name = "txtNumberPallets"
        Me.txtNumberPallets.Size = New System.Drawing.Size(132, 20)
        Me.txtNumberPallets.TabIndex = 20
        Me.txtNumberPallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Location = New System.Drawing.Point(122, 142)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(163, 20)
        Me.txtCustomerPO.TabIndex = 8
        Me.txtCustomerPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightQuoteAmount
        '
        Me.txtFreightQuoteAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightQuoteAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightQuoteAmount.Location = New System.Drawing.Point(153, 452)
        Me.txtFreightQuoteAmount.Name = "txtFreightQuoteAmount"
        Me.txtFreightQuoteAmount.Size = New System.Drawing.Size(132, 20)
        Me.txtFreightQuoteAmount.TabIndex = 16
        Me.txtFreightQuoteAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightQuoteNumber
        '
        Me.txtFreightQuoteNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightQuoteNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightQuoteNumber.Location = New System.Drawing.Point(109, 425)
        Me.txtFreightQuoteNumber.Name = "txtFreightQuoteNumber"
        Me.txtFreightQuoteNumber.Size = New System.Drawing.Size(176, 20)
        Me.txtFreightQuoteNumber.TabIndex = 15
        Me.txtFreightQuoteNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(13, 371)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 20)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "PRO Number"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Status"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(13, 479)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Billed Freight"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(13, 533)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(134, 20)
        Me.Label28.TabIndex = 22
        Me.Label28.Text = "# of Boxes"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.ForeColor = System.Drawing.Color.Blue
        Me.Label29.Location = New System.Drawing.Point(13, 587)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(134, 20)
        Me.Label29.TabIndex = 23
        Me.Label29.Text = "Double Stacked Pallets"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.ForeColor = System.Drawing.Color.Blue
        Me.Label30.Location = New System.Drawing.Point(6, 506)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(134, 20)
        Me.Label30.TabIndex = 24
        Me.Label30.Text = "Shipping Weight"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(13, 452)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 20)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Freight Quote Amt."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(13, 425)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 20)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Freight Quote #"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(16, 171)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 20)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Ship Date"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.Location = New System.Drawing.Point(16, 142)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 20)
        Me.Label22.TabIndex = 21
        Me.Label22.Text = "Customer PO #"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(16, 201)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 20)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "Ship Via"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShipDate
        '
        Me.lblShipDate.BackColor = System.Drawing.Color.White
        Me.lblShipDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblShipDate.Location = New System.Drawing.Point(122, 171)
        Me.lblShipDate.Name = "lblShipDate"
        Me.lblShipDate.Size = New System.Drawing.Size(163, 20)
        Me.lblShipDate.TabIndex = 9
        Me.lblShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomerName
        '
        Me.lblCustomerName.BackColor = System.Drawing.Color.White
        Me.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustomerName.Location = New System.Drawing.Point(16, 78)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(269, 52)
        Me.lblCustomerName.TabIndex = 7
        Me.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomerID
        '
        Me.lblCustomerID.BackColor = System.Drawing.Color.White
        Me.lblCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustomerID.Location = New System.Drawing.Point(83, 49)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(202, 20)
        Me.lblCustomerID.TabIndex = 6
        Me.lblCustomerID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Customer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShipEmail
        '
        Me.lblShipEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblShipEmail.ForeColor = System.Drawing.Color.Blue
        Me.lblShipEmail.Location = New System.Drawing.Point(342, 773)
        Me.lblShipEmail.Name = "lblShipEmail"
        Me.lblShipEmail.Size = New System.Drawing.Size(169, 41)
        Me.lblShipEmail.TabIndex = 37
        Me.lblShipEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.ForeColor = System.Drawing.Color.Blue
        Me.Label27.Location = New System.Drawing.Point(16, 54)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(100, 20)
        Me.Label27.TabIndex = 21
        Me.Label27.Text = "Name"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxShippingAddress
        '
        Me.gpxShippingAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxShippingAddress.Controls.Add(Me.cboShipToCountryName)
        Me.gpxShippingAddress.Controls.Add(Me.cboState)
        Me.gpxShippingAddress.Controls.Add(Me.txtCountry)
        Me.gpxShippingAddress.Controls.Add(Me.txtZip)
        Me.gpxShippingAddress.Controls.Add(Me.txtCity)
        Me.gpxShippingAddress.Controls.Add(Me.txtAddress2)
        Me.gpxShippingAddress.Controls.Add(Me.txtAddress1)
        Me.gpxShippingAddress.Controls.Add(Me.txtShipToName)
        Me.gpxShippingAddress.Controls.Add(Me.cboShipToID)
        Me.gpxShippingAddress.Controls.Add(Me.Label27)
        Me.gpxShippingAddress.Controls.Add(Me.Label42)
        Me.gpxShippingAddress.Controls.Add(Me.Label44)
        Me.gpxShippingAddress.Controls.Add(Me.Label40)
        Me.gpxShippingAddress.Controls.Add(Me.Label38)
        Me.gpxShippingAddress.Controls.Add(Me.Label36)
        Me.gpxShippingAddress.Controls.Add(Me.Label34)
        Me.gpxShippingAddress.Controls.Add(Me.Label32)
        Me.gpxShippingAddress.Location = New System.Drawing.Point(714, 400)
        Me.gpxShippingAddress.Name = "gpxShippingAddress"
        Me.gpxShippingAddress.Size = New System.Drawing.Size(416, 363)
        Me.gpxShippingAddress.TabIndex = 28
        Me.gpxShippingAddress.TabStop = False
        Me.gpxShippingAddress.Text = "Shipping Address"
        '
        'cboShipToCountryName
        '
        Me.cboShipToCountryName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipToCountryName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipToCountryName.DataSource = Me.CountryCodesBindingSource
        Me.cboShipToCountryName.DisplayMember = "Country"
        Me.cboShipToCountryName.FormattingEnabled = True
        Me.cboShipToCountryName.Location = New System.Drawing.Point(89, 334)
        Me.cboShipToCountryName.Name = "cboShipToCountryName"
        Me.cboShipToCountryName.Size = New System.Drawing.Size(210, 21)
        Me.cboShipToCountryName.TabIndex = 36
        '
        'CountryCodesBindingSource
        '
        Me.CountryCodesBindingSource.DataMember = "CountryCodes"
        Me.CountryCodesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboState
        '
        Me.cboState.DataSource = Me.StateTableBindingSource
        Me.cboState.DisplayMember = "StateCode"
        Me.cboState.FormattingEnabled = True
        Me.cboState.Location = New System.Drawing.Point(89, 301)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(100, 21)
        Me.cboState.TabIndex = 34
        '
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtCountry
        '
        Me.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountry.Location = New System.Drawing.Point(305, 334)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.ReadOnly = True
        Me.txtCountry.Size = New System.Drawing.Size(94, 20)
        Me.txtCountry.TabIndex = 36
        Me.txtCountry.TabStop = False
        '
        'txtZip
        '
        Me.txtZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZip.Location = New System.Drawing.Point(242, 302)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(157, 20)
        Me.txtZip.TabIndex = 35
        '
        'txtCity
        '
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCity.Location = New System.Drawing.Point(89, 271)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(310, 20)
        Me.txtCity.TabIndex = 33
        '
        'txtAddress2
        '
        Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress2.Location = New System.Drawing.Point(89, 181)
        Me.txtAddress2.Multiline = True
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(310, 81)
        Me.txtAddress2.TabIndex = 32
        '
        'txtAddress1
        '
        Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress1.Location = New System.Drawing.Point(89, 85)
        Me.txtAddress1.Multiline = True
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(310, 81)
        Me.txtAddress1.TabIndex = 31
        '
        'txtShipToName
        '
        Me.txtShipToName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipToName.Location = New System.Drawing.Point(89, 54)
        Me.txtShipToName.Name = "txtShipToName"
        Me.txtShipToName.Size = New System.Drawing.Size(310, 20)
        Me.txtShipToName.TabIndex = 30
        '
        'cboShipToID
        '
        Me.cboShipToID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipToID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipToID.DataSource = Me.AdditionalShipToBindingSource
        Me.cboShipToID.DisplayMember = "ShipToID"
        Me.cboShipToID.FormattingEnabled = True
        Me.cboShipToID.Location = New System.Drawing.Point(89, 22)
        Me.cboShipToID.Name = "cboShipToID"
        Me.cboShipToID.Size = New System.Drawing.Size(310, 21)
        Me.cboShipToID.TabIndex = 29
        '
        'AdditionalShipToBindingSource
        '
        Me.AdditionalShipToBindingSource.DataMember = "AdditionalShipTo"
        Me.AdditionalShipToBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label42
        '
        Me.Label42.ForeColor = System.Drawing.Color.Blue
        Me.Label42.Location = New System.Drawing.Point(16, 303)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(61, 20)
        Me.Label42.TabIndex = 23
        Me.Label42.Text = "State"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label44
        '
        Me.Label44.ForeColor = System.Drawing.Color.Blue
        Me.Label44.Location = New System.Drawing.Point(203, 302)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(33, 20)
        Me.Label44.TabIndex = 25
        Me.Label44.Text = "ZIP"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.ForeColor = System.Drawing.Color.Blue
        Me.Label40.Location = New System.Drawing.Point(16, 333)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(100, 20)
        Me.Label40.TabIndex = 23
        Me.Label40.Text = "Country"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.ForeColor = System.Drawing.Color.Blue
        Me.Label38.Location = New System.Drawing.Point(16, 271)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(61, 20)
        Me.Label38.TabIndex = 23
        Me.Label38.Text = "City"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(16, 182)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(100, 20)
        Me.Label36.TabIndex = 23
        Me.Label36.Text = "Address 2"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(16, 85)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(100, 20)
        Me.Label34.TabIndex = 23
        Me.Label34.Text = "Address 1"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.ForeColor = System.Drawing.Color.Blue
        Me.Label32.Location = New System.Drawing.Point(16, 23)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(100, 20)
        Me.Label32.TabIndex = 16
        Me.Label32.Text = "Ship To ID"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxShipmentTotals
        '
        Me.gpxShipmentTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxShipmentTotals.Controls.Add(Me.lblPalletsOnFloor)
        Me.gpxShipmentTotals.Controls.Add(Me.Label45)
        Me.gpxShipmentTotals.Controls.Add(Me.lblShipmentTotal)
        Me.gpxShipmentTotals.Controls.Add(Me.Label53)
        Me.gpxShipmentTotals.Controls.Add(Me.lblFreight)
        Me.gpxShipmentTotals.Controls.Add(Me.Label51)
        Me.gpxShipmentTotals.Controls.Add(Me.lblSalesTax)
        Me.gpxShipmentTotals.Controls.Add(Me.Label49)
        Me.gpxShipmentTotals.Controls.Add(Me.lblProductTotal)
        Me.gpxShipmentTotals.Controls.Add(Me.Label47)
        Me.gpxShipmentTotals.Location = New System.Drawing.Point(343, 610)
        Me.gpxShipmentTotals.Name = "gpxShipmentTotals"
        Me.gpxShipmentTotals.Size = New System.Drawing.Size(354, 155)
        Me.gpxShipmentTotals.TabIndex = 23
        Me.gpxShipmentTotals.TabStop = False
        Me.gpxShipmentTotals.Text = "Shipment Totals"
        '
        'lblPalletsOnFloor
        '
        Me.lblPalletsOnFloor.BackColor = System.Drawing.Color.White
        Me.lblPalletsOnFloor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalletsOnFloor.Location = New System.Drawing.Point(183, 16)
        Me.lblPalletsOnFloor.Name = "lblPalletsOnFloor"
        Me.lblPalletsOnFloor.Size = New System.Drawing.Size(118, 20)
        Me.lblPalletsOnFloor.TabIndex = 29
        Me.lblPalletsOnFloor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(11, 16)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(138, 20)
        Me.Label45.TabIndex = 28
        Me.Label45.Text = "Total Pallets On Floor"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShipmentTotal
        '
        Me.lblShipmentTotal.BackColor = System.Drawing.Color.White
        Me.lblShipmentTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblShipmentTotal.Location = New System.Drawing.Point(156, 124)
        Me.lblShipmentTotal.Name = "lblShipmentTotal"
        Me.lblShipmentTotal.Size = New System.Drawing.Size(145, 20)
        Me.lblShipmentTotal.TabIndex = 27
        Me.lblShipmentTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(11, 124)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(100, 20)
        Me.Label53.TabIndex = 24
        Me.Label53.Text = "Shipment Total"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFreight
        '
        Me.lblFreight.BackColor = System.Drawing.Color.White
        Me.lblFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFreight.Location = New System.Drawing.Point(156, 97)
        Me.lblFreight.Name = "lblFreight"
        Me.lblFreight.Size = New System.Drawing.Size(145, 20)
        Me.lblFreight.TabIndex = 26
        Me.lblFreight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(11, 97)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(100, 20)
        Me.Label51.TabIndex = 24
        Me.Label51.Text = "Freight"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSalesTax
        '
        Me.lblSalesTax.BackColor = System.Drawing.Color.White
        Me.lblSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSalesTax.Location = New System.Drawing.Point(156, 70)
        Me.lblSalesTax.Name = "lblSalesTax"
        Me.lblSalesTax.Size = New System.Drawing.Size(145, 20)
        Me.lblSalesTax.TabIndex = 25
        Me.lblSalesTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(11, 70)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(100, 20)
        Me.Label49.TabIndex = 20
        Me.Label49.Text = "Sales Tax"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProductTotal
        '
        Me.lblProductTotal.BackColor = System.Drawing.Color.White
        Me.lblProductTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductTotal.Location = New System.Drawing.Point(156, 43)
        Me.lblProductTotal.Name = "lblProductTotal"
        Me.lblProductTotal.Size = New System.Drawing.Size(145, 20)
        Me.lblProductTotal.TabIndex = 24
        Me.lblProductTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(11, 43)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(100, 20)
        Me.Label47.TabIndex = 18
        Me.Label47.Text = "Product Total"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'dgvShipLines
        '
        Me.dgvShipLines.AllowUserToAddRows = False
        Me.dgvShipLines.AutoGenerateColumns = False
        Me.dgvShipLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvShipLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipmentNumberColumn, Me.ShipmentLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityShippedColumn, Me.PriceColumn, Me.LineCommentColumn, Me.SerialNumberColumn, Me.LineWeightColumn, Me.LineBoxesColumn, Me.CertificationTypeColumn, Me.SalesTaxColumn, Me.ExtendedAmountColumn, Me.LineStatusColumn, Me.DivisionIDColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn})
        Me.dgvShipLines.DataSource = Me.ShipmentLineTableBindingSource
        Me.dgvShipLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipLines.Location = New System.Drawing.Point(6, 0)
        Me.dgvShipLines.MultiSelect = False
        Me.dgvShipLines.Name = "dgvShipLines"
        Me.dgvShipLines.Size = New System.Drawing.Size(785, 327)
        Me.dgvShipLines.TabIndex = 36
        Me.dgvShipLines.TabStop = False
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "ShipmentNumber"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.ReadOnly = True
        Me.ShipmentNumberColumn.Visible = False
        '
        'ShipmentLineNumberColumn
        '
        Me.ShipmentLineNumberColumn.DataPropertyName = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn.HeaderText = "Line #"
        Me.ShipmentLineNumberColumn.Name = "ShipmentLineNumberColumn"
        Me.ShipmentLineNumberColumn.ReadOnly = True
        Me.ShipmentLineNumberColumn.Width = 50
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        Me.PartNumberColumn.Width = 120
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        Me.PartDescriptionColumn.Width = 150
        '
        'QuantityShippedColumn
        '
        Me.QuantityShippedColumn.DataPropertyName = "QuantityShipped"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityShippedColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityShippedColumn.HeaderText = "Qty Shipped"
        Me.QuantityShippedColumn.Name = "QuantityShippedColumn"
        Me.QuantityShippedColumn.ReadOnly = True
        Me.QuantityShippedColumn.Width = 85
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.Visible = False
        Me.PriceColumn.Width = 85
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.Width = 200
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Serial / Lot #"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        Me.LineWeightColumn.HeaderText = "Line Weight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.Width = 85
        '
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        Me.LineBoxesColumn.HeaderText = "Line Boxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        Me.LineBoxesColumn.Width = 85
        '
        'CertificationTypeColumn
        '
        Me.CertificationTypeColumn.DataPropertyName = "CertificationType"
        Me.CertificationTypeColumn.HeaderText = "Cert Code"
        Me.CertificationTypeColumn.Name = "CertificationTypeColumn"
        Me.CertificationTypeColumn.Width = 85
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.Visible = False
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "ExtendedAmount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.Visible = False
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "LineStatus"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
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
        'ShipmentLineTableBindingSource
        '
        Me.ShipmentLineTableBindingSource.DataMember = "ShipmentLineTable"
        Me.ShipmentLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentLineTableTableAdapter
        '
        Me.ShipmentLineTableTableAdapter.ClearBeforeFill = True
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(11, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 20)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Comments"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(11, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(196, 20)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Special Shipping Instructions"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpecialInstructions.Location = New System.Drawing.Point(10, 28)
        Me.txtSpecialInstructions.MaxLength = 500
        Me.txtSpecialInstructions.Multiline = True
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.Size = New System.Drawing.Size(330, 142)
        Me.txtSpecialInstructions.TabIndex = 23
        '
        'txtComments
        '
        Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComments.Location = New System.Drawing.Point(14, 26)
        Me.txtComments.MaxLength = 500
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(330, 142)
        Me.txtComments.TabIndex = 22
        '
        'cmdPackList
        '
        Me.cmdPackList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPackList.Location = New System.Drawing.Point(825, 772)
        Me.cmdPackList.Name = "cmdPackList"
        Me.cmdPackList.Size = New System.Drawing.Size(71, 40)
        Me.cmdPackList.TabIndex = 35
        Me.cmdPackList.Text = "Re-Print Pack Slip"
        Me.cmdPackList.UseVisualStyleBackColor = True
        '
        'cmdCert
        '
        Me.cmdCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCert.Location = New System.Drawing.Point(902, 772)
        Me.cmdCert.Name = "cmdCert"
        Me.cmdCert.Size = New System.Drawing.Size(71, 40)
        Me.cmdCert.TabIndex = 36
        Me.cmdCert.Text = "Re-Print Certs"
        Me.cmdCert.UseVisualStyleBackColor = True
        '
        'tabShipmentLines
        '
        Me.tabShipmentLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabShipmentLines.Controls.Add(Me.tabLineComments)
        Me.tabShipmentLines.Controls.Add(Me.tabLineLotNumbers)
        Me.tabShipmentLines.Controls.Add(Me.tabSerialNumbers)
        Me.tabShipmentLines.Location = New System.Drawing.Point(335, 41)
        Me.tabShipmentLines.Name = "tabShipmentLines"
        Me.tabShipmentLines.SelectedIndex = 0
        Me.tabShipmentLines.Size = New System.Drawing.Size(795, 353)
        Me.tabShipmentLines.TabIndex = 45
        '
        'tabLineComments
        '
        Me.tabLineComments.Controls.Add(Me.dgvShipLines)
        Me.tabLineComments.Location = New System.Drawing.Point(4, 22)
        Me.tabLineComments.Name = "tabLineComments"
        Me.tabLineComments.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLineComments.Size = New System.Drawing.Size(787, 327)
        Me.tabLineComments.TabIndex = 0
        Me.tabLineComments.Text = "Shipment Lines"
        Me.tabLineComments.UseVisualStyleBackColor = True
        '
        'tabLineLotNumbers
        '
        Me.tabLineLotNumbers.Controls.Add(Me.Label14)
        Me.tabLineLotNumbers.Controls.Add(Me.cmdDeleteLotNumber)
        Me.tabLineLotNumbers.Controls.Add(Me.Label12)
        Me.tabLineLotNumbers.Controls.Add(Me.cmdUpdateInvoice)
        Me.tabLineLotNumbers.Controls.Add(Me.txtHeatQuantity)
        Me.tabLineLotNumbers.Controls.Add(Me.Label13)
        Me.tabLineLotNumbers.Controls.Add(Me.txtLotNumber)
        Me.tabLineLotNumbers.Controls.Add(Me.Label8)
        Me.tabLineLotNumbers.Controls.Add(Me.Label7)
        Me.tabLineLotNumbers.Controls.Add(Me.cmdAddLotNumber)
        Me.tabLineLotNumbers.Controls.Add(Me.lblPartDescription)
        Me.tabLineLotNumbers.Controls.Add(Me.lblPartNumber)
        Me.tabLineLotNumbers.Controls.Add(Me.Label5)
        Me.tabLineLotNumbers.Controls.Add(Me.cboShipmentLineNumber)
        Me.tabLineLotNumbers.Controls.Add(Me.Label4)
        Me.tabLineLotNumbers.Controls.Add(Me.dgvLotNumbers)
        Me.tabLineLotNumbers.ForeColor = System.Drawing.Color.Black
        Me.tabLineLotNumbers.Location = New System.Drawing.Point(4, 22)
        Me.tabLineLotNumbers.Name = "tabLineLotNumbers"
        Me.tabLineLotNumbers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLineLotNumbers.Size = New System.Drawing.Size(787, 327)
        Me.tabLineLotNumbers.TabIndex = 1
        Me.tabLineLotNumbers.Text = "Lot Numbers"
        Me.tabLineLotNumbers.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(361, 289)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(232, 25)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "To delete, select line in grid and press delete."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLotNumber
        '
        Me.cmdDeleteLotNumber.Location = New System.Drawing.Point(610, 289)
        Me.cmdDeleteLotNumber.Name = "cmdDeleteLotNumber"
        Me.cmdDeleteLotNumber.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteLotNumber.TabIndex = 44
        Me.cmdDeleteLotNumber.Text = "Delete"
        Me.cmdDeleteLotNumber.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(12, 279)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(174, 40)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "If invoice exists, this will add lot numbers to invoice."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdUpdateInvoice
        '
        Me.cmdUpdateInvoice.Location = New System.Drawing.Point(234, 279)
        Me.cmdUpdateInvoice.Name = "cmdUpdateInvoice"
        Me.cmdUpdateInvoice.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateInvoice.TabIndex = 43
        Me.cmdUpdateInvoice.Text = "Update Invoice"
        Me.cmdUpdateInvoice.UseVisualStyleBackColor = True
        '
        'txtHeatQuantity
        '
        Me.txtHeatQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeatQuantity.Location = New System.Drawing.Point(127, 150)
        Me.txtHeatQuantity.Name = "txtHeatQuantity"
        Me.txtHeatQuantity.Size = New System.Drawing.Size(178, 20)
        Me.txtHeatQuantity.TabIndex = 40
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(11, 150)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Quantity Per Heat"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLotNumber
        '
        Me.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLotNumber.Location = New System.Drawing.Point(15, 195)
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.Size = New System.Drawing.Size(291, 20)
        Me.txtLotNumber.TabIndex = 41
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(12, 233)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(174, 40)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Select Shipment Line # to add Lot Number(s)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Lot Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddLotNumber
        '
        Me.cmdAddLotNumber.Location = New System.Drawing.Point(234, 233)
        Me.cmdAddLotNumber.Name = "cmdAddLotNumber"
        Me.cmdAddLotNumber.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddLotNumber.TabIndex = 42
        Me.cmdAddLotNumber.Text = "Add Lot Number"
        Me.cmdAddLotNumber.UseVisualStyleBackColor = True
        '
        'lblPartDescription
        '
        Me.lblPartDescription.BackColor = System.Drawing.Color.White
        Me.lblPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartDescription.Location = New System.Drawing.Point(14, 85)
        Me.lblPartDescription.Name = "lblPartDescription"
        Me.lblPartDescription.Size = New System.Drawing.Size(291, 53)
        Me.lblPartDescription.TabIndex = 39
        Me.lblPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPartNumber
        '
        Me.lblPartNumber.BackColor = System.Drawing.Color.White
        Me.lblPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartNumber.Location = New System.Drawing.Point(53, 48)
        Me.lblPartNumber.Name = "lblPartNumber"
        Me.lblPartNumber.Size = New System.Drawing.Size(252, 23)
        Me.lblPartNumber.TabIndex = 38
        Me.lblPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(11, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Part #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipmentLineNumber
        '
        Me.cboShipmentLineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentLineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentLineNumber.DataSource = Me.ShipmentLineTableBindingSource
        Me.cboShipmentLineNumber.DisplayMember = "ShipmentLineNumber"
        Me.cboShipmentLineNumber.FormattingEnabled = True
        Me.cboShipmentLineNumber.Location = New System.Drawing.Point(153, 15)
        Me.cboShipmentLineNumber.Name = "cboShipmentLineNumber"
        Me.cboShipmentLineNumber.Size = New System.Drawing.Size(152, 21)
        Me.cboShipmentLineNumber.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(11, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Shipment Line #"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvLotNumbers
        '
        Me.dgvLotNumbers.AllowUserToAddRows = False
        Me.dgvLotNumbers.AllowUserToDeleteRows = False
        Me.dgvLotNumbers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLotNumbers.AutoGenerateColumns = False
        Me.dgvLotNumbers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvLotNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLotNumbers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvLotNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLotNumbers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipmentNumberColumn2, Me.ShipmentLineNumberColumn2, Me.LotLineNumberColumn2, Me.LotNumberColumn2, Me.HeatQuantityColumn2, Me.PullTestNumberColumn2})
        Me.dgvLotNumbers.DataSource = Me.ShipmentLineLotNumbersBindingSource
        Me.dgvLotNumbers.GridColor = System.Drawing.Color.Red
        Me.dgvLotNumbers.Location = New System.Drawing.Point(332, 7)
        Me.dgvLotNumbers.Name = "dgvLotNumbers"
        Me.dgvLotNumbers.Size = New System.Drawing.Size(452, 266)
        Me.dgvLotNumbers.TabIndex = 0
        '
        'ShipmentNumberColumn2
        '
        Me.ShipmentNumberColumn2.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn2.HeaderText = "ShipmentNumber"
        Me.ShipmentNumberColumn2.Name = "ShipmentNumberColumn2"
        Me.ShipmentNumberColumn2.ReadOnly = True
        Me.ShipmentNumberColumn2.Visible = False
        '
        'ShipmentLineNumberColumn2
        '
        Me.ShipmentLineNumberColumn2.DataPropertyName = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn2.HeaderText = "Line #"
        Me.ShipmentLineNumberColumn2.Name = "ShipmentLineNumberColumn2"
        Me.ShipmentLineNumberColumn2.ReadOnly = True
        Me.ShipmentLineNumberColumn2.Width = 65
        '
        'LotLineNumberColumn2
        '
        Me.LotLineNumberColumn2.DataPropertyName = "LotLineNumber"
        Me.LotLineNumberColumn2.HeaderText = "Lot Line #"
        Me.LotLineNumberColumn2.Name = "LotLineNumberColumn2"
        Me.LotLineNumberColumn2.ReadOnly = True
        Me.LotLineNumberColumn2.Visible = False
        '
        'LotNumberColumn2
        '
        Me.LotNumberColumn2.DataPropertyName = "LotNumber"
        Me.LotNumberColumn2.HeaderText = "Lot #"
        Me.LotNumberColumn2.Name = "LotNumberColumn2"
        Me.LotNumberColumn2.ReadOnly = True
        Me.LotNumberColumn2.Width = 140
        '
        'HeatQuantityColumn2
        '
        Me.HeatQuantityColumn2.DataPropertyName = "HeatQuantity"
        Me.HeatQuantityColumn2.HeaderText = "Heat Quantity"
        Me.HeatQuantityColumn2.Name = "HeatQuantityColumn2"
        Me.HeatQuantityColumn2.Width = 120
        '
        'PullTestNumberColumn2
        '
        Me.PullTestNumberColumn2.DataPropertyName = "PullTestNumber"
        Me.PullTestNumberColumn2.HeaderText = "Pull Test #"
        Me.PullTestNumberColumn2.Name = "PullTestNumberColumn2"
        Me.PullTestNumberColumn2.Width = 120
        '
        'ShipmentLineLotNumbersBindingSource
        '
        Me.ShipmentLineLotNumbersBindingSource.DataMember = "ShipmentLineLotNumbers"
        Me.ShipmentLineLotNumbersBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tabSerialNumbers
        '
        Me.tabSerialNumbers.Controls.Add(Me.cmdDeleteSerialNumber)
        Me.tabSerialNumbers.Controls.Add(Me.cmdUpdateInvoiceWithSN)
        Me.tabSerialNumbers.Controls.Add(Me.cmdAddSerialNumber)
        Me.tabSerialNumbers.Controls.Add(Me.Label26)
        Me.tabSerialNumbers.Controls.Add(Me.txtSerialNumber)
        Me.tabSerialNumbers.Controls.Add(Me.Label33)
        Me.tabSerialNumbers.Controls.Add(Me.Label35)
        Me.tabSerialNumbers.Controls.Add(Me.lblSNPartDescription)
        Me.tabSerialNumbers.Controls.Add(Me.lblSNPartNumber)
        Me.tabSerialNumbers.Controls.Add(Me.Label41)
        Me.tabSerialNumbers.Controls.Add(Me.cboSNShipmentLineNumber)
        Me.tabSerialNumbers.Controls.Add(Me.Label43)
        Me.tabSerialNumbers.Controls.Add(Me.Label25)
        Me.tabSerialNumbers.Controls.Add(Me.dgvShipmentLineSerialNumbers)
        Me.tabSerialNumbers.ForeColor = System.Drawing.Color.Black
        Me.tabSerialNumbers.Location = New System.Drawing.Point(4, 22)
        Me.tabSerialNumbers.Name = "tabSerialNumbers"
        Me.tabSerialNumbers.Size = New System.Drawing.Size(787, 327)
        Me.tabSerialNumbers.TabIndex = 2
        Me.tabSerialNumbers.Text = "Serial Number's"
        Me.tabSerialNumbers.UseVisualStyleBackColor = True
        '
        'cmdDeleteSerialNumber
        '
        Me.cmdDeleteSerialNumber.Location = New System.Drawing.Point(603, 281)
        Me.cmdDeleteSerialNumber.Name = "cmdDeleteSerialNumber"
        Me.cmdDeleteSerialNumber.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteSerialNumber.TabIndex = 52
        Me.cmdDeleteSerialNumber.Text = "Delete"
        Me.cmdDeleteSerialNumber.UseVisualStyleBackColor = True
        '
        'cmdUpdateInvoiceWithSN
        '
        Me.cmdUpdateInvoiceWithSN.Location = New System.Drawing.Point(220, 279)
        Me.cmdUpdateInvoiceWithSN.Name = "cmdUpdateInvoiceWithSN"
        Me.cmdUpdateInvoiceWithSN.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateInvoiceWithSN.TabIndex = 51
        Me.cmdUpdateInvoiceWithSN.Text = "Update Invoice"
        Me.cmdUpdateInvoiceWithSN.UseVisualStyleBackColor = True
        '
        'cmdAddSerialNumber
        '
        Me.cmdAddSerialNumber.Location = New System.Drawing.Point(220, 233)
        Me.cmdAddSerialNumber.Name = "cmdAddSerialNumber"
        Me.cmdAddSerialNumber.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddSerialNumber.TabIndex = 50
        Me.cmdAddSerialNumber.Text = "Add Serial #"
        Me.cmdAddSerialNumber.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.ForeColor = System.Drawing.Color.Blue
        Me.Label26.Location = New System.Drawing.Point(14, 279)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(174, 40)
        Me.Label26.TabIndex = 61
        Me.Label26.Text = "If invoice exists, this will add lot numbers to invoice."
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerialNumber.Location = New System.Drawing.Point(16, 195)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(276, 20)
        Me.txtSerialNumber.TabIndex = 49
        '
        'Label33
        '
        Me.Label33.ForeColor = System.Drawing.Color.Blue
        Me.Label33.Location = New System.Drawing.Point(14, 233)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(174, 40)
        Me.Label33.TabIndex = 52
        Me.Label33.Text = "Select Shipment Line # to add Lot Number(s)"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(13, 178)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(100, 20)
        Me.Label35.TabIndex = 51
        Me.Label35.Text = "Serial Number"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSNPartDescription
        '
        Me.lblSNPartDescription.BackColor = System.Drawing.Color.White
        Me.lblSNPartDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSNPartDescription.Location = New System.Drawing.Point(15, 85)
        Me.lblSNPartDescription.Name = "lblSNPartDescription"
        Me.lblSNPartDescription.Size = New System.Drawing.Size(276, 53)
        Me.lblSNPartDescription.TabIndex = 48
        Me.lblSNPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSNPartNumber
        '
        Me.lblSNPartNumber.BackColor = System.Drawing.Color.White
        Me.lblSNPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSNPartNumber.Location = New System.Drawing.Point(54, 48)
        Me.lblSNPartNumber.Name = "lblSNPartNumber"
        Me.lblSNPartNumber.Size = New System.Drawing.Size(237, 23)
        Me.lblSNPartNumber.TabIndex = 47
        Me.lblSNPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(12, 51)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(100, 20)
        Me.Label41.TabIndex = 50
        Me.Label41.Text = "Part #"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSNShipmentLineNumber
        '
        Me.cboSNShipmentLineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSNShipmentLineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSNShipmentLineNumber.DataSource = Me.ShipmentLineTableBindingSource
        Me.cboSNShipmentLineNumber.DisplayMember = "ShipmentLineNumber"
        Me.cboSNShipmentLineNumber.FormattingEnabled = True
        Me.cboSNShipmentLineNumber.Location = New System.Drawing.Point(154, 15)
        Me.cboSNShipmentLineNumber.Name = "cboSNShipmentLineNumber"
        Me.cboSNShipmentLineNumber.Size = New System.Drawing.Size(137, 21)
        Me.cboSNShipmentLineNumber.TabIndex = 46
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(12, 15)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(100, 20)
        Me.Label43.TabIndex = 49
        Me.Label43.Text = "Shipment Line #"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.Location = New System.Drawing.Point(365, 284)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(232, 25)
        Me.Label25.TabIndex = 48
        Me.Label25.Text = "To delete, select line in grid and press delete."
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvShipmentLineSerialNumbers
        '
        Me.dgvShipmentLineSerialNumbers.AllowUserToAddRows = False
        Me.dgvShipmentLineSerialNumbers.AllowUserToDeleteRows = False
        Me.dgvShipmentLineSerialNumbers.AutoGenerateColumns = False
        Me.dgvShipmentLineSerialNumbers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentLineSerialNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvShipmentLineSerialNumbers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvShipmentLineSerialNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentLineSerialNumbers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipmentNumberColumn3, Me.ShipmentLineNumberColumn3, Me.SerialLineNumberColumn3, Me.SerialNumberColumn3, Me.SerialCostColumn3, Me.SerialQuantityColumn3})
        Me.dgvShipmentLineSerialNumbers.DataSource = Me.ShipmentLineSerialNumbersBindingSource
        Me.dgvShipmentLineSerialNumbers.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvShipmentLineSerialNumbers.Location = New System.Drawing.Point(321, 7)
        Me.dgvShipmentLineSerialNumbers.Name = "dgvShipmentLineSerialNumbers"
        Me.dgvShipmentLineSerialNumbers.ReadOnly = True
        Me.dgvShipmentLineSerialNumbers.Size = New System.Drawing.Size(453, 258)
        Me.dgvShipmentLineSerialNumbers.TabIndex = 0
        '
        'ShipmentNumberColumn3
        '
        Me.ShipmentNumberColumn3.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn3.HeaderText = "ShipmentNumber"
        Me.ShipmentNumberColumn3.Name = "ShipmentNumberColumn3"
        Me.ShipmentNumberColumn3.ReadOnly = True
        Me.ShipmentNumberColumn3.Visible = False
        '
        'ShipmentLineNumberColumn3
        '
        Me.ShipmentLineNumberColumn3.DataPropertyName = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn3.HeaderText = "Shipment Line #"
        Me.ShipmentLineNumberColumn3.Name = "ShipmentLineNumberColumn3"
        Me.ShipmentLineNumberColumn3.ReadOnly = True
        Me.ShipmentLineNumberColumn3.Width = 80
        '
        'SerialLineNumberColumn3
        '
        Me.SerialLineNumberColumn3.DataPropertyName = "SerialLineNumber"
        Me.SerialLineNumberColumn3.HeaderText = "Serial Line #"
        Me.SerialLineNumberColumn3.Name = "SerialLineNumberColumn3"
        Me.SerialLineNumberColumn3.ReadOnly = True
        Me.SerialLineNumberColumn3.Width = 80
        '
        'SerialNumberColumn3
        '
        Me.SerialNumberColumn3.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn3.HeaderText = "Serial Number"
        Me.SerialNumberColumn3.Name = "SerialNumberColumn3"
        Me.SerialNumberColumn3.ReadOnly = True
        Me.SerialNumberColumn3.Width = 200
        '
        'SerialCostColumn3
        '
        Me.SerialCostColumn3.DataPropertyName = "SerialCost"
        Me.SerialCostColumn3.HeaderText = "SerialCost"
        Me.SerialCostColumn3.Name = "SerialCostColumn3"
        Me.SerialCostColumn3.ReadOnly = True
        Me.SerialCostColumn3.Visible = False
        '
        'SerialQuantityColumn3
        '
        Me.SerialQuantityColumn3.DataPropertyName = "SerialQuantity"
        Me.SerialQuantityColumn3.HeaderText = "Serial Quantity"
        Me.SerialQuantityColumn3.Name = "SerialQuantityColumn3"
        Me.SerialQuantityColumn3.ReadOnly = True
        Me.SerialQuantityColumn3.Visible = False
        Me.SerialQuantityColumn3.Width = 70
        '
        'ShipmentLineSerialNumbersBindingSource
        '
        Me.ShipmentLineSerialNumbersBindingSource.DataMember = "ShipmentLineSerialNumbers"
        Me.ShipmentLineSerialNumbersBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentLineLotNumbersTableAdapter
        '
        Me.ShipmentLineLotNumbersTableAdapter.ClearBeforeFill = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(517, 772)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 31
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'AdditionalShipToTableAdapter
        '
        Me.AdditionalShipToTableAdapter.ClearBeforeFill = True
        '
        'cmdRePrintShippingLabel
        '
        Me.cmdRePrintShippingLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRePrintShippingLabel.Location = New System.Drawing.Point(748, 772)
        Me.cmdRePrintShippingLabel.Name = "cmdRePrintShippingLabel"
        Me.cmdRePrintShippingLabel.Size = New System.Drawing.Size(71, 40)
        Me.cmdRePrintShippingLabel.TabIndex = 34
        Me.cmdRePrintShippingLabel.Text = "Re-Print Ship Label"
        Me.cmdRePrintShippingLabel.UseVisualStyleBackColor = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'ShipmentLineSerialNumbersTableAdapter
        '
        Me.ShipmentLineSerialNumbersTableAdapter.ClearBeforeFill = True
        '
        'CountryCodesTableAdapter
        '
        Me.CountryCodesTableAdapter.ClearBeforeFill = True
        '
        'cmdUploadPickTicket
        '
        Me.cmdUploadPickTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadPickTicket.Location = New System.Drawing.Point(594, 772)
        Me.cmdUploadPickTicket.Name = "cmdUploadPickTicket"
        Me.cmdUploadPickTicket.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadPickTicket.TabIndex = 32
        Me.cmdUploadPickTicket.Text = "Upload Pick Ticket"
        Me.cmdUploadPickTicket.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'tabCommentsTab
        '
        Me.tabCommentsTab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabCommentsTab.Controls.Add(Me.tabInstructions)
        Me.tabCommentsTab.Controls.Add(Me.tabComments)
        Me.tabCommentsTab.Location = New System.Drawing.Point(339, 400)
        Me.tabCommentsTab.Name = "tabCommentsTab"
        Me.tabCommentsTab.SelectedIndex = 0
        Me.tabCommentsTab.Size = New System.Drawing.Size(358, 202)
        Me.tabCommentsTab.TabIndex = 47
        '
        'tabInstructions
        '
        Me.tabInstructions.Controls.Add(Me.Label10)
        Me.tabInstructions.Controls.Add(Me.txtSpecialInstructions)
        Me.tabInstructions.Location = New System.Drawing.Point(4, 22)
        Me.tabInstructions.Name = "tabInstructions"
        Me.tabInstructions.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInstructions.Size = New System.Drawing.Size(350, 176)
        Me.tabInstructions.TabIndex = 0
        Me.tabInstructions.Text = "Special Shipping Instructions"
        Me.tabInstructions.UseVisualStyleBackColor = True
        '
        'tabComments
        '
        Me.tabComments.Controls.Add(Me.Label11)
        Me.tabComments.Controls.Add(Me.txtComments)
        Me.tabComments.Location = New System.Drawing.Point(4, 22)
        Me.tabComments.Name = "tabComments"
        Me.tabComments.Padding = New System.Windows.Forms.Padding(3)
        Me.tabComments.Size = New System.Drawing.Size(350, 176)
        Me.tabComments.TabIndex = 1
        Me.tabComments.Text = "Shipping Comments"
        Me.tabComments.UseVisualStyleBackColor = True
        '
        'cmdViewULPicks
        '
        Me.cmdViewULPicks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewULPicks.Location = New System.Drawing.Point(671, 772)
        Me.cmdViewULPicks.Name = "cmdViewULPicks"
        Me.cmdViewULPicks.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewULPicks.TabIndex = 33
        Me.cmdViewULPicks.Text = "View U/L Pick Ticket"
        Me.cmdViewULPicks.UseVisualStyleBackColor = True
        '
        'cmdRemoteScan
        '
        Me.cmdRemoteScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoteScan.Location = New System.Drawing.Point(594, 772)
        Me.cmdRemoteScan.Name = "cmdRemoteScan"
        Me.cmdRemoteScan.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoteScan.TabIndex = 48
        Me.cmdRemoteScan.Text = "Upload Pick Ticket"
        Me.cmdRemoteScan.UseVisualStyleBackColor = True
        '
        'ShipmentLineComments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdViewULPicks)
        Me.Controls.Add(Me.cmdRemoteScan)
        Me.Controls.Add(Me.tabCommentsTab)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdUploadPickTicket)
        Me.Controls.Add(Me.lblShipEmail)
        Me.Controls.Add(Me.cmdRePrintShippingLabel)
        Me.Controls.Add(Me.cmdPackList)
        Me.Controls.Add(Me.tabShipmentLines)
        Me.Controls.Add(Me.cmdCert)
        Me.Controls.Add(Me.gpxShippingAddress)
        Me.Controls.Add(Me.gpxShipmentTotals)
        Me.Controls.Add(Me.gpxShipmentDetails)
        Me.Controls.Add(Me.cmdBOL)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.gpxViewShipmentLines)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ShipmentLineComments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation View/Edit Shipment"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxViewShipmentLines.ResumeLayout(False)
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxShipmentDetails.ResumeLayout(False)
        Me.gpxShipmentDetails.PerformLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxShippingAddress.ResumeLayout(False)
        Me.gpxShippingAddress.PerformLayout()
        CType(Me.CountryCodesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxShipmentTotals.ResumeLayout(False)
        CType(Me.dgvShipLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabShipmentLines.ResumeLayout(False)
        Me.tabLineComments.ResumeLayout(False)
        Me.tabLineLotNumbers.ResumeLayout(False)
        Me.tabLineLotNumbers.PerformLayout()
        CType(Me.dgvLotNumbers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentLineLotNumbersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSerialNumbers.ResumeLayout(False)
        Me.tabSerialNumbers.PerformLayout()
        CType(Me.dgvShipmentLineSerialNumbers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentLineSerialNumbersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCommentsTab.ResumeLayout(False)
        Me.tabInstructions.ResumeLayout(False)
        Me.tabInstructions.PerformLayout()
        Me.tabComments.ResumeLayout(False)
        Me.tabComments.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxViewShipmentLines As System.Windows.Forms.GroupBox
    Friend WithEvents cboShipmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdBOL As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxShipmentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lblShipDate As System.Windows.Forms.Label
    Friend WithEvents lblSONumber As System.Windows.Forms.Label
    Friend WithEvents lblCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblCustomerID As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents gpxShippingAddress As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents gpxShipmentTotals As System.Windows.Forms.GroupBox
    Friend WithEvents lblShipmentTotal As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents lblFreight As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents lblSalesTax As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lblProductTotal As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents dgvShipLines As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineTableTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPackList As System.Windows.Forms.Button
    Friend WithEvents cmdCert As System.Windows.Forms.Button
    Friend WithEvents PrintShipmentDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPackingListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintCertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintBOLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabLineComments As System.Windows.Forms.TabPage
    Friend WithEvents tabLineLotNumbers As System.Windows.Forms.TabPage
    Friend WithEvents dgvLotNumbers As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentLineLotNumbersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentLineLotNumbersTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineLotNumbersTableAdapter
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboShipmentLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdAddLotNumber As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtPRONumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents txtSpecialInstructions As System.Windows.Forms.TextBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtFreight As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtFreightQuoteAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtFreightQuoteNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents txtShipWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberPallets As System.Windows.Forms.TextBox
    Friend WithEvents lblNumberBoxes As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtShipToName As System.Windows.Forms.TextBox
    Friend WithEvents cboShipToID As System.Windows.Forms.ComboBox
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents AdditionalShipToBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdditionalShipToTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
    Friend WithEvents PrintProfitabilityReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintEmailConfirmationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdRePrintShippingLabel As System.Windows.Forms.Button
    Friend WithEvents SetShipmentToShippedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetShipmentToPendingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetShipmentToClosedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtHeatQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblPartDescription As System.Windows.Forms.Label
    Friend WithEvents lblPartNumber As System.Windows.Forms.Label
    Friend WithEvents ShipmentNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentLineNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotLineNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatQuantityColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PullTestNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdUpdateInvoice As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteLotNumber As System.Windows.Forms.Button
    Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtThirdParty As System.Windows.Forms.TextBox
    Friend WithEvents tabSerialNumbers As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentLineSerialNumbersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentLineSerialNumbersTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineSerialNumbersTableAdapter
    Friend WithEvents tabShipmentLines As System.Windows.Forms.TabControl
    Friend WithEvents dgvShipmentLineSerialNumbers As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertificationTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents lblSNPartDescription As System.Windows.Forms.Label
    Friend WithEvents lblSNPartNumber As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents cboSNShipmentLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteSerialNumber As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateInvoiceWithSN As System.Windows.Forms.Button
    Friend WithEvents cmdAddSerialNumber As System.Windows.Forms.Button
    Friend WithEvents ShipmentNumberColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentLineNumberColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialLineNumberColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialCostColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialQuantityColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtShippingAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblShipEmail As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboShipToCountryName As System.Windows.Forms.ComboBox
    Friend WithEvents CountryCodesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CountryCodesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CountryCodesTableAdapter
    Friend WithEvents cmdUploadPickTicket As System.Windows.Forms.Button
    Friend WithEvents ReUploadPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendUploadedPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboPickTicketNumber As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents txtDoubleStackedPallets As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents lblPalletsOnFloor As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents tabCommentsTab As System.Windows.Forms.TabControl
    Friend WithEvents tabInstructions As System.Windows.Forms.TabPage
    Friend WithEvents tabComments As System.Windows.Forms.TabPage
    Friend WithEvents cmdViewULPicks As System.Windows.Forms.Button
    Friend WithEvents cmdRemoteScan As System.Windows.Forms.Button
End Class
