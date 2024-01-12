<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvoicingForm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoicingForm))
        Me.cmdExit = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddTaxToInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AutoEmailByPreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendUploadedPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScanPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrintInvoice = New System.Windows.Forms.Button
        Me.gpxInvoiceHeaderInfo = New System.Windows.Forms.GroupBox
        Me.txtShipmentNumber = New System.Windows.Forms.TextBox
        Me.txtSalesOrderNumber = New System.Windows.Forms.TextBox
        Me.cboBatchNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceProcessingBatchHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.cboInvoiceNumber = New System.Windows.Forms.ComboBox
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtHSTRate = New System.Windows.Forms.TextBox
        Me.chkAddPST = New System.Windows.Forms.CheckBox
        Me.chkAddHST = New System.Windows.Forms.CheckBox
        Me.cmdRemoveSalesTax = New System.Windows.Forms.Button
        Me.txtSalesTax3 = New System.Windows.Forms.TextBox
        Me.LabelHST = New System.Windows.Forms.Label
        Me.txtSalesTax2 = New System.Windows.Forms.TextBox
        Me.LabelPST = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.txtInvoiceStatus = New System.Windows.Forms.TextBox
        Me.txtInvoiceTotal = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtSalesTax = New System.Windows.Forms.TextBox
        Me.LabelSalesTax = New System.Windows.Forms.Label
        Me.txtDiscount = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtFreightBilled = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtProductSales = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdAddDiscount = New System.Windows.Forms.Button
        Me.dgvInvoiceLines = New System.Windows.Forms.DataGridView
        Me.InvoiceHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLineKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityBilledColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCOSColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InvoiceLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.cboInvoiceLineNumber = New System.Windows.Forms.ComboBox
        Me.cboLinePartNumber = New System.Windows.Forms.ComboBox
        Me.cboLinePartDescription = New System.Windows.Forms.ComboBox
        Me.tabLineDetails = New System.Windows.Forms.TabControl
        Me.tabInvoiceLineDetails = New System.Windows.Forms.TabPage
        Me.txtLineComment = New System.Windows.Forms.TextBox
        Me.txtLineExtendedAmount = New System.Windows.Forms.TextBox
        Me.txtLineSalesTax = New System.Windows.Forms.TextBox
        Me.txtLinePrice = New System.Windows.Forms.TextBox
        Me.txtLineQuantityBilled = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.tabInvoiceLineOther = New System.Windows.Forms.TabPage
        Me.txtGLPurchasesAccount = New System.Windows.Forms.TextBox
        Me.txtGLCOGSAccount = New System.Windows.Forms.TextBox
        Me.txtGLIssuesAccount = New System.Windows.Forms.TextBox
        Me.txtGLAdjustmentAccount = New System.Windows.Forms.TextBox
        Me.txtGLSalesOffsetAccount = New System.Windows.Forms.TextBox
        Me.txtGLInventoryAccount = New System.Windows.Forms.TextBox
        Me.txtGLReturnsAccount = New System.Windows.Forms.TextBox
        Me.txtGLSalesAccount = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabLotNumbers = New System.Windows.Forms.TabPage
        Me.Label19 = New System.Windows.Forms.Label
        Me.dgvInvoiceLotNumbers = New System.Windows.Forms.DataGridView
        Me.InvoiceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLineNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLotLineNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLotNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceHeatNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceHeatQuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceLotLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabSerialNumbers = New System.Windows.Forms.TabPage
        Me.dgvInvoiceSerialLineTable = New System.Windows.Forms.DataGridView
        Me.SLInvoiceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLInvoiceLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLInvoiceSerialLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLInvoiceSerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLInvoiceShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLSerialNumberCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLSerialNumberQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceSerialLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentLineLotNumbersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabAddDiscount = New System.Windows.Forms.TabPage
        Me.Label52 = New System.Windows.Forms.Label
        Me.txtSalesTaxRate = New System.Windows.Forms.TextBox
        Me.txtGSTRate = New System.Windows.Forms.TextBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.txtPSTRate = New System.Windows.Forms.TextBox
        Me.txtHSTRate2 = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.cmdAddTax = New System.Windows.Forms.Button
        Me.Label45 = New System.Windows.Forms.Label
        Me.cmdDeleteDiscount = New System.Windows.Forms.Button
        Me.txtDiscountAmount = New System.Windows.Forms.TextBox
        Me.txtDiscountPercent = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.tabBillingAddress = New System.Windows.Forms.TabPage
        Me.txtBTAddress1 = New System.Windows.Forms.TextBox
        Me.txtBTAddress2 = New System.Windows.Forms.TextBox
        Me.txtBTCity = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtThirdPartyShipper = New System.Windows.Forms.TextBox
        Me.txtBTZip = New System.Windows.Forms.TextBox
        Me.txtBTCountry = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboBTState = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.tabCustomerDetails = New System.Windows.Forms.TabPage
        Me.Label56 = New System.Windows.Forms.Label
        Me.txtCustomerNotes = New System.Windows.Forms.TextBox
        Me.txtQuotedFreight = New System.Windows.Forms.TextBox
        Me.Label55 = New System.Windows.Forms.Label
        Me.lblShipDate = New System.Windows.Forms.Label
        Me.cboShipMethod = New System.Windows.Forms.ComboBox
        Me.Label54 = New System.Windows.Forms.Label
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.txtBilledFreight = New System.Windows.Forms.TextBox
        Me.txtCustomerPONumber = New System.Windows.Forms.TextBox
        Me.txtProNumber = New System.Windows.Forms.TextBox
        Me.txtCustomerName = New System.Windows.Forms.TextBox
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblEmailInvoice = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabComments = New System.Windows.Forms.TabPage
        Me.txtSpecialInstructions = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.InvoiceProcessingBatchHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceProcessingBatchHeaderTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.ShipmentLineLotNumbersTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineLotNumbersTableAdapter
        Me.InvoiceLotLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLotLineTableTableAdapter
        Me.cmdEmailBoth = New System.Windows.Forms.Button
        Me.cmdPrintCerts = New System.Windows.Forms.Button
        Me.InvoiceSerialLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceSerialLineTableTableAdapter
        Me.cmdUploadShowPickTicket = New System.Windows.Forms.Button
        Me.cmdPrintPackList = New System.Windows.Forms.Button
        Me.lblEmailSent = New System.Windows.Forms.Label
        Me.crxInvoice1 = New MOS09Program.CRXInvoice
        Me.crxInvoiceTFF1 = New MOS09Program.CRXInvoiceTFF
        Me.crxPackingSlipTFP1 = New MOS09Program.CRXPackingSlipTFP
        Me.crxPackingSlip1 = New MOS09Program.CRXPackingSlip
        Me.crxtwCert011 = New MOS09Program.CRXTWCert01
        Me.TimeSlipLineItemTableTableAdapter1 = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TimeSlipLineItemTableTableAdapter
        Me.cmdViewPickTicket = New System.Windows.Forms.Button
        Me.CachedCRXCommissionReportbyTerritory1 = New MOS09Program.CachedCRXCommissionReportbyTerritory
        Me.cmdRemoteScan = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gpxInvoiceHeaderInfo.SuspendLayout()
        CType(Me.InvoiceProcessingBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoiceLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLineDetails.SuspendLayout()
        Me.tabInvoiceLineDetails.SuspendLayout()
        Me.tabInvoiceLineOther.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLotNumbers.SuspendLayout()
        CType(Me.dgvInvoiceLotNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceLotLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSerialNumbers.SuspendLayout()
        CType(Me.dgvInvoiceSerialLineTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceSerialLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentLineLotNumbersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAddDiscount.SuspendLayout()
        Me.tabBillingAddress.SuspendLayout()
        Me.tabCustomerDetails.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabComments.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1055, 775)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 52
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveInvoiceToolStripMenuItem, Me.DeleteInvoiceToolStripMenuItem, Me.ClearInvoiceToolStripMenuItem, Me.PrintInvoiceToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveInvoiceToolStripMenuItem
        '
        Me.SaveInvoiceToolStripMenuItem.Name = "SaveInvoiceToolStripMenuItem"
        Me.SaveInvoiceToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SaveInvoiceToolStripMenuItem.Text = "Save Invoice"
        '
        'DeleteInvoiceToolStripMenuItem
        '
        Me.DeleteInvoiceToolStripMenuItem.Name = "DeleteInvoiceToolStripMenuItem"
        Me.DeleteInvoiceToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.DeleteInvoiceToolStripMenuItem.Text = "Delete Invoice"
        '
        'ClearInvoiceToolStripMenuItem
        '
        Me.ClearInvoiceToolStripMenuItem.Name = "ClearInvoiceToolStripMenuItem"
        Me.ClearInvoiceToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.ClearInvoiceToolStripMenuItem.Text = "Clear Invoice"
        '
        'PrintInvoiceToolStripMenuItem
        '
        Me.PrintInvoiceToolStripMenuItem.Name = "PrintInvoiceToolStripMenuItem"
        Me.PrintInvoiceToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.PrintInvoiceToolStripMenuItem.Text = "Print Invoice"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddTaxToInvoiceToolStripMenuItem, Me.AutoEmailByPreferencesToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'AddTaxToInvoiceToolStripMenuItem
        '
        Me.AddTaxToInvoiceToolStripMenuItem.Name = "AddTaxToInvoiceToolStripMenuItem"
        Me.AddTaxToInvoiceToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.AddTaxToInvoiceToolStripMenuItem.Text = "Add Tax to Invoice"
        '
        'AutoEmailByPreferencesToolStripMenuItem
        '
        Me.AutoEmailByPreferencesToolStripMenuItem.Name = "AutoEmailByPreferencesToolStripMenuItem"
        Me.AutoEmailByPreferencesToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.AutoEmailByPreferencesToolStripMenuItem.Text = "Auto-Email by Preferences"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReUploadPickTicketToolStripMenuItem, Me.AppendUploadedPickTicketToolStripMenuItem, Me.ScanPickTicketToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
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
        'ScanPickTicketToolStripMenuItem
        '
        Me.ScanPickTicketToolStripMenuItem.Name = "ScanPickTicketToolStripMenuItem"
        Me.ScanPickTicketToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ScanPickTicketToolStripMenuItem.Text = "Scan Pick Ticket"
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
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(891, 776)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 50
        Me.cmdSave.Text = "Save Invoice"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(973, 775)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 51
        Me.cmdDelete.Text = "Delete Invoice"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrintInvoice
        '
        Me.cmdPrintInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintInvoice.Location = New System.Drawing.Point(1055, 729)
        Me.cmdPrintInvoice.Name = "cmdPrintInvoice"
        Me.cmdPrintInvoice.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintInvoice.TabIndex = 48
        Me.cmdPrintInvoice.Text = "Print Invoice"
        Me.cmdPrintInvoice.UseVisualStyleBackColor = True
        '
        'gpxInvoiceHeaderInfo
        '
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.txtShipmentNumber)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.txtSalesOrderNumber)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.cboBatchNumber)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.dtpInvoiceDate)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.cboInvoiceNumber)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.Label1)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.Label12)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.Label4)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.Label5)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.Label6)
        Me.gpxInvoiceHeaderInfo.Controls.Add(Me.Label46)
        Me.gpxInvoiceHeaderInfo.Location = New System.Drawing.Point(29, 41)
        Me.gpxInvoiceHeaderInfo.Name = "gpxInvoiceHeaderInfo"
        Me.gpxInvoiceHeaderInfo.Size = New System.Drawing.Size(349, 215)
        Me.gpxInvoiceHeaderInfo.TabIndex = 0
        Me.gpxInvoiceHeaderInfo.TabStop = False
        Me.gpxInvoiceHeaderInfo.Text = "Invoice Information"
        '
        'txtShipmentNumber
        '
        Me.txtShipmentNumber.BackColor = System.Drawing.Color.White
        Me.txtShipmentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipmentNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipmentNumber.Location = New System.Drawing.Point(142, 84)
        Me.txtShipmentNumber.Name = "txtShipmentNumber"
        Me.txtShipmentNumber.ReadOnly = True
        Me.txtShipmentNumber.Size = New System.Drawing.Size(186, 20)
        Me.txtShipmentNumber.TabIndex = 28
        Me.txtShipmentNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalesOrderNumber
        '
        Me.txtSalesOrderNumber.BackColor = System.Drawing.Color.White
        Me.txtSalesOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesOrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesOrderNumber.Location = New System.Drawing.Point(142, 116)
        Me.txtSalesOrderNumber.Name = "txtSalesOrderNumber"
        Me.txtSalesOrderNumber.ReadOnly = True
        Me.txtSalesOrderNumber.Size = New System.Drawing.Size(186, 20)
        Me.txtSalesOrderNumber.TabIndex = 3
        Me.txtSalesOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboBatchNumber
        '
        Me.cboBatchNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBatchNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBatchNumber.DataSource = Me.InvoiceProcessingBatchHeaderBindingSource
        Me.cboBatchNumber.DisplayMember = "BatchNumber"
        Me.cboBatchNumber.Enabled = False
        Me.cboBatchNumber.FormattingEnabled = True
        Me.cboBatchNumber.Location = New System.Drawing.Point(142, 20)
        Me.cboBatchNumber.Name = "cboBatchNumber"
        Me.cboBatchNumber.Size = New System.Drawing.Size(186, 21)
        Me.cboBatchNumber.TabIndex = 0
        '
        'InvoiceProcessingBatchHeaderBindingSource
        '
        Me.InvoiceProcessingBatchHeaderBindingSource.DataMember = "InvoiceProcessingBatchHeader"
        Me.InvoiceProcessingBatchHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(142, 178)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(186, 21)
        Me.cboDivisionID.TabIndex = 5
        Me.cboDivisionID.ValueMember = "ItemID"
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(142, 147)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(186, 20)
        Me.dtpInvoiceDate.TabIndex = 4
        '
        'cboInvoiceNumber
        '
        Me.cboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInvoiceNumber.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.cboInvoiceNumber.DisplayMember = "InvoiceNumber"
        Me.cboInvoiceNumber.FormattingEnabled = True
        Me.cboInvoiceNumber.Location = New System.Drawing.Point(142, 52)
        Me.cboInvoiceNumber.Name = "cboInvoiceNumber"
        Me.cboInvoiceNumber.Size = New System.Drawing.Size(186, 21)
        Me.cboInvoiceNumber.TabIndex = 1
        Me.cboInvoiceNumber.ValueMember = "ItemID"
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 21)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Sales Order #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(19, 174)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 21)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Division ID"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 21)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Invoice Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 21)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Invoice #"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 21)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Shipment #"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(19, 19)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(103, 21)
        Me.Label46.TabIndex = 27
        Me.Label46.Text = "Batch Number"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtHSTRate)
        Me.GroupBox1.Controls.Add(Me.chkAddPST)
        Me.GroupBox1.Controls.Add(Me.chkAddHST)
        Me.GroupBox1.Controls.Add(Me.cmdRemoveSalesTax)
        Me.GroupBox1.Controls.Add(Me.txtSalesTax3)
        Me.GroupBox1.Controls.Add(Me.LabelHST)
        Me.GroupBox1.Controls.Add(Me.txtSalesTax2)
        Me.GroupBox1.Controls.Add(Me.LabelPST)
        Me.GroupBox1.Controls.Add(Me.Label48)
        Me.GroupBox1.Controls.Add(Me.txtInvoiceStatus)
        Me.GroupBox1.Controls.Add(Me.txtInvoiceTotal)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtSalesTax)
        Me.GroupBox1.Controls.Add(Me.LabelSalesTax)
        Me.GroupBox1.Controls.Add(Me.txtDiscount)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtFreightBilled)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtProductSales)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(809, 486)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(319, 237)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Invoice Totals"
        '
        'txtHSTRate
        '
        Me.txtHSTRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHSTRate.Location = New System.Drawing.Point(97, 150)
        Me.txtHSTRate.Name = "txtHSTRate"
        Me.txtHSTRate.Size = New System.Drawing.Size(71, 20)
        Me.txtHSTRate.TabIndex = 88
        Me.txtHSTRate.Visible = False
        '
        'chkAddPST
        '
        Me.chkAddPST.AutoSize = True
        Me.chkAddPST.Location = New System.Drawing.Point(56, 128)
        Me.chkAddPST.Name = "chkAddPST"
        Me.chkAddPST.Size = New System.Drawing.Size(15, 14)
        Me.chkAddPST.TabIndex = 87
        Me.chkAddPST.UseVisualStyleBackColor = True
        '
        'chkAddHST
        '
        Me.chkAddHST.AutoSize = True
        Me.chkAddHST.Location = New System.Drawing.Point(56, 153)
        Me.chkAddHST.Name = "chkAddHST"
        Me.chkAddHST.Size = New System.Drawing.Size(15, 14)
        Me.chkAddHST.TabIndex = 86
        Me.chkAddHST.UseVisualStyleBackColor = True
        '
        'cmdRemoveSalesTax
        '
        Me.cmdRemoveSalesTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveSalesTax.ForeColor = System.Drawing.Color.Blue
        Me.cmdRemoveSalesTax.Location = New System.Drawing.Point(139, 98)
        Me.cmdRemoveSalesTax.Name = "cmdRemoveSalesTax"
        Me.cmdRemoveSalesTax.Size = New System.Drawing.Size(29, 20)
        Me.cmdRemoveSalesTax.TabIndex = 68
        Me.cmdRemoveSalesTax.Text = "<<"
        Me.cmdRemoveSalesTax.UseVisualStyleBackColor = True
        '
        'txtSalesTax3
        '
        Me.txtSalesTax3.BackColor = System.Drawing.Color.White
        Me.txtSalesTax3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax3.Enabled = False
        Me.txtSalesTax3.Location = New System.Drawing.Point(174, 150)
        Me.txtSalesTax3.Name = "txtSalesTax3"
        Me.txtSalesTax3.ReadOnly = True
        Me.txtSalesTax3.Size = New System.Drawing.Size(125, 20)
        Me.txtSalesTax3.TabIndex = 83
        Me.txtSalesTax3.TabStop = False
        Me.txtSalesTax3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelHST
        '
        Me.LabelHST.Location = New System.Drawing.Point(21, 150)
        Me.LabelHST.Name = "LabelHST"
        Me.LabelHST.Size = New System.Drawing.Size(101, 21)
        Me.LabelHST.TabIndex = 85
        Me.LabelHST.Text = "HST"
        Me.LabelHST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTax2
        '
        Me.txtSalesTax2.BackColor = System.Drawing.Color.White
        Me.txtSalesTax2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax2.Enabled = False
        Me.txtSalesTax2.Location = New System.Drawing.Point(174, 124)
        Me.txtSalesTax2.Name = "txtSalesTax2"
        Me.txtSalesTax2.ReadOnly = True
        Me.txtSalesTax2.Size = New System.Drawing.Size(125, 20)
        Me.txtSalesTax2.TabIndex = 82
        Me.txtSalesTax2.TabStop = False
        Me.txtSalesTax2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelPST
        '
        Me.LabelPST.Location = New System.Drawing.Point(21, 124)
        Me.LabelPST.Name = "LabelPST"
        Me.LabelPST.Size = New System.Drawing.Size(101, 21)
        Me.LabelPST.TabIndex = 84
        Me.LabelPST.Text = "PST"
        Me.LabelPST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(21, 202)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(101, 21)
        Me.Label48.TabIndex = 81
        Me.Label48.Text = "Invoice Status"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvoiceStatus
        '
        Me.txtInvoiceStatus.BackColor = System.Drawing.Color.White
        Me.txtInvoiceStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceStatus.Enabled = False
        Me.txtInvoiceStatus.Location = New System.Drawing.Point(174, 202)
        Me.txtInvoiceStatus.Name = "txtInvoiceStatus"
        Me.txtInvoiceStatus.ReadOnly = True
        Me.txtInvoiceStatus.Size = New System.Drawing.Size(125, 20)
        Me.txtInvoiceStatus.TabIndex = 80
        Me.txtInvoiceStatus.TabStop = False
        Me.txtInvoiceStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInvoiceTotal
        '
        Me.txtInvoiceTotal.BackColor = System.Drawing.Color.White
        Me.txtInvoiceTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvoiceTotal.Enabled = False
        Me.txtInvoiceTotal.Location = New System.Drawing.Point(174, 176)
        Me.txtInvoiceTotal.Name = "txtInvoiceTotal"
        Me.txtInvoiceTotal.ReadOnly = True
        Me.txtInvoiceTotal.Size = New System.Drawing.Size(125, 20)
        Me.txtInvoiceTotal.TabIndex = 30
        Me.txtInvoiceTotal.TabStop = False
        Me.txtInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(21, 176)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(101, 21)
        Me.Label20.TabIndex = 79
        Me.Label20.Text = "Invoice Total"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTax
        '
        Me.txtSalesTax.BackColor = System.Drawing.Color.White
        Me.txtSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax.Enabled = False
        Me.txtSalesTax.Location = New System.Drawing.Point(174, 98)
        Me.txtSalesTax.Name = "txtSalesTax"
        Me.txtSalesTax.ReadOnly = True
        Me.txtSalesTax.Size = New System.Drawing.Size(125, 20)
        Me.txtSalesTax.TabIndex = 29
        Me.txtSalesTax.TabStop = False
        Me.txtSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelSalesTax
        '
        Me.LabelSalesTax.Location = New System.Drawing.Point(21, 98)
        Me.LabelSalesTax.Name = "LabelSalesTax"
        Me.LabelSalesTax.Size = New System.Drawing.Size(101, 21)
        Me.LabelSalesTax.TabIndex = 77
        Me.LabelSalesTax.Text = "Sales Tax"
        Me.LabelSalesTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiscount
        '
        Me.txtDiscount.BackColor = System.Drawing.Color.White
        Me.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscount.Enabled = False
        Me.txtDiscount.Location = New System.Drawing.Point(174, 72)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.ReadOnly = True
        Me.txtDiscount.Size = New System.Drawing.Size(125, 20)
        Me.txtDiscount.TabIndex = 28
        Me.txtDiscount.TabStop = False
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(21, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 21)
        Me.Label18.TabIndex = 75
        Me.Label18.Text = "Discount"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreightBilled
        '
        Me.txtFreightBilled.BackColor = System.Drawing.Color.White
        Me.txtFreightBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightBilled.Enabled = False
        Me.txtFreightBilled.Location = New System.Drawing.Point(174, 46)
        Me.txtFreightBilled.Name = "txtFreightBilled"
        Me.txtFreightBilled.ReadOnly = True
        Me.txtFreightBilled.Size = New System.Drawing.Size(125, 20)
        Me.txtFreightBilled.TabIndex = 27
        Me.txtFreightBilled.TabStop = False
        Me.txtFreightBilled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(21, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 21)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "Freight Billed"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProductSales
        '
        Me.txtProductSales.BackColor = System.Drawing.Color.White
        Me.txtProductSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductSales.Enabled = False
        Me.txtProductSales.Location = New System.Drawing.Point(174, 20)
        Me.txtProductSales.Name = "txtProductSales"
        Me.txtProductSales.ReadOnly = True
        Me.txtProductSales.Size = New System.Drawing.Size(125, 20)
        Me.txtProductSales.TabIndex = 26
        Me.txtProductSales.TabStop = False
        Me.txtProductSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(21, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 21)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "Product Sales"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(592, 431)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 44
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdAddDiscount
        '
        Me.cmdAddDiscount.Location = New System.Drawing.Point(142, 190)
        Me.cmdAddDiscount.Name = "cmdAddDiscount"
        Me.cmdAddDiscount.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddDiscount.TabIndex = 23
        Me.cmdAddDiscount.Text = "Add Discount"
        Me.cmdAddDiscount.UseVisualStyleBackColor = True
        '
        'dgvInvoiceLines
        '
        Me.dgvInvoiceLines.AllowUserToAddRows = False
        Me.dgvInvoiceLines.AllowUserToDeleteRows = False
        Me.dgvInvoiceLines.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceLines.AutoGenerateColumns = False
        Me.dgvInvoiceLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInvoiceLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceHeaderKeyColumn, Me.InvoiceLineKeyColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityBilledColumn, Me.PriceColumn, Me.ExtendedAmountColumn, Me.ExtendedCOSColumn, Me.LineCommentColumn, Me.SerialNumberColumn, Me.SalesTaxColumn, Me.LineWeightColumn, Me.LineBoxesColumn, Me.LineStatusColumn, Me.DivisionIDColumn})
        Me.dgvInvoiceLines.DataSource = Me.InvoiceLineTableBindingSource
        Me.dgvInvoiceLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvInvoiceLines.Location = New System.Drawing.Point(388, 41)
        Me.dgvInvoiceLines.Name = "dgvInvoiceLines"
        Me.dgvInvoiceLines.Size = New System.Drawing.Size(740, 437)
        Me.dgvInvoiceLines.TabIndex = 35
        '
        'InvoiceHeaderKeyColumn
        '
        Me.InvoiceHeaderKeyColumn.DataPropertyName = "InvoiceHeaderKey"
        Me.InvoiceHeaderKeyColumn.HeaderText = "InvoiceHeaderKey"
        Me.InvoiceHeaderKeyColumn.Name = "InvoiceHeaderKeyColumn"
        Me.InvoiceHeaderKeyColumn.ReadOnly = True
        Me.InvoiceHeaderKeyColumn.Visible = False
        '
        'InvoiceLineKeyColumn
        '
        Me.InvoiceLineKeyColumn.DataPropertyName = "InvoiceLineKey"
        Me.InvoiceLineKeyColumn.HeaderText = "Line #"
        Me.InvoiceLineKeyColumn.Name = "InvoiceLineKeyColumn"
        Me.InvoiceLineKeyColumn.ReadOnly = True
        Me.InvoiceLineKeyColumn.Width = 60
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 150
        '
        'QuantityBilledColumn
        '
        Me.QuantityBilledColumn.DataPropertyName = "QuantityBilled"
        DataGridViewCellStyle1.NullValue = "0"
        Me.QuantityBilledColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.QuantityBilledColumn.HeaderText = "Quantity Billed"
        Me.QuantityBilledColumn.Name = "QuantityBilledColumn"
        Me.QuantityBilledColumn.ReadOnly = True
        Me.QuantityBilledColumn.Width = 80
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        DataGridViewCellStyle2.Format = "N5"
        DataGridViewCellStyle2.NullValue = "0"
        Me.PriceColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 80
        '
        'ExtendedCOSColumn
        '
        Me.ExtendedCOSColumn.DataPropertyName = "ExtendedCOS"
        Me.ExtendedCOSColumn.HeaderText = "ExtendedCOS"
        Me.ExtendedCOSColumn.Name = "ExtendedCOSColumn"
        Me.ExtendedCOSColumn.ReadOnly = True
        Me.ExtendedCOSColumn.Visible = False
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Lot# / Heat#"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.SalesTaxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.SalesTaxColumn.HeaderText = "Sales Tax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Width = 80
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        Me.LineWeightColumn.HeaderText = "LineWeight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.Visible = False
        '
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        Me.LineBoxesColumn.HeaderText = "LineBoxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        Me.LineBoxesColumn.Visible = False
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
        'InvoiceLineTableBindingSource
        '
        Me.InvoiceLineTableBindingSource.DataMember = "InvoiceLineTable"
        Me.InvoiceLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'InvoiceLineTableTableAdapter
        '
        Me.InvoiceLineTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'cboInvoiceLineNumber
        '
        Me.cboInvoiceLineNumber.DataSource = Me.InvoiceLineTableBindingSource
        Me.cboInvoiceLineNumber.DisplayMember = "InvoiceLineKey"
        Me.cboInvoiceLineNumber.FormattingEnabled = True
        Me.cboInvoiceLineNumber.Location = New System.Drawing.Point(231, 16)
        Me.cboInvoiceLineNumber.Name = "cboInvoiceLineNumber"
        Me.cboInvoiceLineNumber.Size = New System.Drawing.Size(146, 21)
        Me.cboInvoiceLineNumber.TabIndex = 26
        '
        'cboLinePartNumber
        '
        Me.cboLinePartNumber.DataSource = Me.InvoiceLineTableBindingSource
        Me.cboLinePartNumber.DisplayMember = "PartNumber"
        Me.cboLinePartNumber.DropDownWidth = 300
        Me.cboLinePartNumber.Enabled = False
        Me.cboLinePartNumber.FormattingEnabled = True
        Me.cboLinePartNumber.Location = New System.Drawing.Point(143, 45)
        Me.cboLinePartNumber.Name = "cboLinePartNumber"
        Me.cboLinePartNumber.Size = New System.Drawing.Size(234, 21)
        Me.cboLinePartNumber.TabIndex = 27
        '
        'cboLinePartDescription
        '
        Me.cboLinePartDescription.DataSource = Me.InvoiceLineTableBindingSource
        Me.cboLinePartDescription.DisplayMember = "PartDescription"
        Me.cboLinePartDescription.DropDownWidth = 300
        Me.cboLinePartDescription.Enabled = False
        Me.cboLinePartDescription.FormattingEnabled = True
        Me.cboLinePartDescription.Location = New System.Drawing.Point(143, 74)
        Me.cboLinePartDescription.Name = "cboLinePartDescription"
        Me.cboLinePartDescription.Size = New System.Drawing.Size(234, 21)
        Me.cboLinePartDescription.TabIndex = 28
        '
        'tabLineDetails
        '
        Me.tabLineDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabLineDetails.Controls.Add(Me.tabInvoiceLineDetails)
        Me.tabLineDetails.Controls.Add(Me.tabInvoiceLineOther)
        Me.tabLineDetails.Controls.Add(Me.tabLotNumbers)
        Me.tabLineDetails.Controls.Add(Me.tabSerialNumbers)
        Me.tabLineDetails.Location = New System.Drawing.Point(388, 484)
        Me.tabLineDetails.Name = "tabLineDetails"
        Me.tabLineDetails.SelectedIndex = 0
        Me.tabLineDetails.Size = New System.Drawing.Size(415, 332)
        Me.tabLineDetails.TabIndex = 35
        Me.tabLineDetails.TabStop = False
        '
        'tabInvoiceLineDetails
        '
        Me.tabInvoiceLineDetails.Controls.Add(Me.cboLinePartDescription)
        Me.tabInvoiceLineDetails.Controls.Add(Me.cboLinePartNumber)
        Me.tabInvoiceLineDetails.Controls.Add(Me.txtLineComment)
        Me.tabInvoiceLineDetails.Controls.Add(Me.txtLineExtendedAmount)
        Me.tabInvoiceLineDetails.Controls.Add(Me.txtLineSalesTax)
        Me.tabInvoiceLineDetails.Controls.Add(Me.txtLinePrice)
        Me.tabInvoiceLineDetails.Controls.Add(Me.txtLineQuantityBilled)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label8)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label29)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label30)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label31)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label33)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label34)
        Me.tabInvoiceLineDetails.Controls.Add(Me.cboInvoiceLineNumber)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label35)
        Me.tabInvoiceLineDetails.Controls.Add(Me.Label32)
        Me.tabInvoiceLineDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabInvoiceLineDetails.Name = "tabInvoiceLineDetails"
        Me.tabInvoiceLineDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInvoiceLineDetails.Size = New System.Drawing.Size(407, 306)
        Me.tabInvoiceLineDetails.TabIndex = 0
        Me.tabInvoiceLineDetails.Text = "Invoice Line Details"
        Me.tabInvoiceLineDetails.UseVisualStyleBackColor = True
        '
        'txtLineComment
        '
        Me.txtLineComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineComment.Location = New System.Drawing.Point(88, 227)
        Me.txtLineComment.Multiline = True
        Me.txtLineComment.Name = "txtLineComment"
        Me.txtLineComment.Size = New System.Drawing.Size(289, 73)
        Me.txtLineComment.TabIndex = 33
        Me.txtLineComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineExtendedAmount
        '
        Me.txtLineExtendedAmount.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtLineExtendedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineExtendedAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineExtendedAmount.Location = New System.Drawing.Point(231, 187)
        Me.txtLineExtendedAmount.Name = "txtLineExtendedAmount"
        Me.txtLineExtendedAmount.ReadOnly = True
        Me.txtLineExtendedAmount.Size = New System.Drawing.Size(146, 20)
        Me.txtLineExtendedAmount.TabIndex = 32
        Me.txtLineExtendedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineSalesTax
        '
        Me.txtLineSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineSalesTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineSalesTax.Location = New System.Drawing.Point(231, 159)
        Me.txtLineSalesTax.Name = "txtLineSalesTax"
        Me.txtLineSalesTax.ReadOnly = True
        Me.txtLineSalesTax.Size = New System.Drawing.Size(146, 20)
        Me.txtLineSalesTax.TabIndex = 31
        Me.txtLineSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLinePrice
        '
        Me.txtLinePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinePrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinePrice.Location = New System.Drawing.Point(231, 131)
        Me.txtLinePrice.Name = "txtLinePrice"
        Me.txtLinePrice.Size = New System.Drawing.Size(146, 20)
        Me.txtLinePrice.TabIndex = 30
        Me.txtLinePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineQuantityBilled
        '
        Me.txtLineQuantityBilled.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtLineQuantityBilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineQuantityBilled.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineQuantityBilled.Location = New System.Drawing.Point(231, 103)
        Me.txtLineQuantityBilled.Name = "txtLineQuantityBilled"
        Me.txtLineQuantityBilled.ReadOnly = True
        Me.txtLineQuantityBilled.Size = New System.Drawing.Size(146, 20)
        Me.txtLineQuantityBilled.TabIndex = 29
        Me.txtLineQuantityBilled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(9, 186)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 21)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Extended Amount"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(9, 158)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(101, 21)
        Me.Label29.TabIndex = 89
        Me.Label29.Text = "Sales Tax"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(9, 130)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(101, 21)
        Me.Label30.TabIndex = 88
        Me.Label30.Text = "Price"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(9, 15)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(101, 21)
        Me.Label31.TabIndex = 84
        Me.Label31.Text = "Line #"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(9, 102)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(101, 21)
        Me.Label33.TabIndex = 86
        Me.Label33.Text = "Quantity Billed"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(6, 44)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(101, 21)
        Me.Label34.TabIndex = 85
        Me.Label34.Text = "Part Number"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(9, 225)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(101, 21)
        Me.Label35.TabIndex = 91
        Me.Label35.Text = "Line Comment"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(9, 73)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(101, 21)
        Me.Label32.TabIndex = 87
        Me.Label32.Text = "Part Description"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabInvoiceLineOther
        '
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLPurchasesAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLCOGSAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLIssuesAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLAdjustmentAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLSalesOffsetAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLInventoryAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLReturnsAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.txtGLSalesAccount)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label44)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label36)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label37)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label38)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label39)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label40)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label41)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label42)
        Me.tabInvoiceLineOther.Controls.Add(Me.Label43)
        Me.tabInvoiceLineOther.Controls.Add(Me.cboItemClass)
        Me.tabInvoiceLineOther.Location = New System.Drawing.Point(4, 22)
        Me.tabInvoiceLineOther.Name = "tabInvoiceLineOther"
        Me.tabInvoiceLineOther.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInvoiceLineOther.Size = New System.Drawing.Size(407, 306)
        Me.tabInvoiceLineOther.TabIndex = 1
        Me.tabInvoiceLineOther.Text = "Line Accounts"
        Me.tabInvoiceLineOther.UseVisualStyleBackColor = True
        '
        'txtGLPurchasesAccount
        '
        Me.txtGLPurchasesAccount.BackColor = System.Drawing.Color.White
        Me.txtGLPurchasesAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLPurchasesAccount.Location = New System.Drawing.Point(191, 175)
        Me.txtGLPurchasesAccount.Name = "txtGLPurchasesAccount"
        Me.txtGLPurchasesAccount.ReadOnly = True
        Me.txtGLPurchasesAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLPurchasesAccount.TabIndex = 40
        Me.txtGLPurchasesAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLCOGSAccount
        '
        Me.txtGLCOGSAccount.BackColor = System.Drawing.Color.White
        Me.txtGLCOGSAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLCOGSAccount.Location = New System.Drawing.Point(191, 150)
        Me.txtGLCOGSAccount.Name = "txtGLCOGSAccount"
        Me.txtGLCOGSAccount.ReadOnly = True
        Me.txtGLCOGSAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLCOGSAccount.TabIndex = 39
        Me.txtGLCOGSAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLIssuesAccount
        '
        Me.txtGLIssuesAccount.BackColor = System.Drawing.Color.White
        Me.txtGLIssuesAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLIssuesAccount.Location = New System.Drawing.Point(191, 250)
        Me.txtGLIssuesAccount.Name = "txtGLIssuesAccount"
        Me.txtGLIssuesAccount.ReadOnly = True
        Me.txtGLIssuesAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLIssuesAccount.TabIndex = 43
        Me.txtGLIssuesAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLAdjustmentAccount
        '
        Me.txtGLAdjustmentAccount.BackColor = System.Drawing.Color.White
        Me.txtGLAdjustmentAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLAdjustmentAccount.Location = New System.Drawing.Point(191, 225)
        Me.txtGLAdjustmentAccount.Name = "txtGLAdjustmentAccount"
        Me.txtGLAdjustmentAccount.ReadOnly = True
        Me.txtGLAdjustmentAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLAdjustmentAccount.TabIndex = 42
        Me.txtGLAdjustmentAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLSalesOffsetAccount
        '
        Me.txtGLSalesOffsetAccount.BackColor = System.Drawing.Color.White
        Me.txtGLSalesOffsetAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLSalesOffsetAccount.Location = New System.Drawing.Point(191, 200)
        Me.txtGLSalesOffsetAccount.Name = "txtGLSalesOffsetAccount"
        Me.txtGLSalesOffsetAccount.ReadOnly = True
        Me.txtGLSalesOffsetAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLSalesOffsetAccount.TabIndex = 41
        Me.txtGLSalesOffsetAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLInventoryAccount
        '
        Me.txtGLInventoryAccount.BackColor = System.Drawing.Color.White
        Me.txtGLInventoryAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLInventoryAccount.Location = New System.Drawing.Point(191, 125)
        Me.txtGLInventoryAccount.Name = "txtGLInventoryAccount"
        Me.txtGLInventoryAccount.ReadOnly = True
        Me.txtGLInventoryAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLInventoryAccount.TabIndex = 38
        Me.txtGLInventoryAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLReturnsAccount
        '
        Me.txtGLReturnsAccount.BackColor = System.Drawing.Color.White
        Me.txtGLReturnsAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLReturnsAccount.Location = New System.Drawing.Point(191, 100)
        Me.txtGLReturnsAccount.Name = "txtGLReturnsAccount"
        Me.txtGLReturnsAccount.ReadOnly = True
        Me.txtGLReturnsAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLReturnsAccount.TabIndex = 37
        Me.txtGLReturnsAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGLSalesAccount
        '
        Me.txtGLSalesAccount.BackColor = System.Drawing.Color.White
        Me.txtGLSalesAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGLSalesAccount.Location = New System.Drawing.Point(191, 75)
        Me.txtGLSalesAccount.Name = "txtGLSalesAccount"
        Me.txtGLSalesAccount.ReadOnly = True
        Me.txtGLSalesAccount.Size = New System.Drawing.Size(153, 20)
        Me.txtGLSalesAccount.TabIndex = 36
        Me.txtGLSalesAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(17, 249)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(136, 21)
        Me.Label44.TabIndex = 101
        Me.Label44.Text = "GL Issues Account"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(17, 199)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(136, 21)
        Me.Label36.TabIndex = 98
        Me.Label36.Text = "GL Sales Offset Account"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(17, 174)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(136, 21)
        Me.Label37.TabIndex = 97
        Me.Label37.Text = "GL Purchases Account"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(17, 149)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(136, 21)
        Me.Label38.TabIndex = 96
        Me.Label38.Text = "GL COGS Account"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label39
        '
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(17, 35)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(136, 21)
        Me.Label39.TabIndex = 92
        Me.Label39.Text = "Item Class"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(17, 124)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(136, 21)
        Me.Label40.TabIndex = 94
        Me.Label40.Text = "GL Inventory Account"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(17, 74)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(136, 21)
        Me.Label41.TabIndex = 93
        Me.Label41.Text = "GL Sales Account"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(17, 224)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(136, 21)
        Me.Label42.TabIndex = 99
        Me.Label42.Text = "GL Adjustment Account"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(17, 100)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(136, 21)
        Me.Label43.TabIndex = 95
        Me.Label43.Text = "GL Returns Account"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(191, 36)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(153, 21)
        Me.cboItemClass.TabIndex = 35
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tabLotNumbers
        '
        Me.tabLotNumbers.Controls.Add(Me.Label19)
        Me.tabLotNumbers.Controls.Add(Me.dgvInvoiceLotNumbers)
        Me.tabLotNumbers.Location = New System.Drawing.Point(4, 22)
        Me.tabLotNumbers.Name = "tabLotNumbers"
        Me.tabLotNumbers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLotNumbers.Size = New System.Drawing.Size(407, 306)
        Me.tabLotNumbers.TabIndex = 2
        Me.tabLotNumbers.Text = "Lot Numbers"
        Me.tabLotNumbers.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(3, 279)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(343, 21)
        Me.Label19.TabIndex = 76
        Me.Label19.Text = "Double-click on any Lot # / Heat # to view/print certs."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvInvoiceLotNumbers
        '
        Me.dgvInvoiceLotNumbers.AllowUserToAddRows = False
        Me.dgvInvoiceLotNumbers.AllowUserToDeleteRows = False
        Me.dgvInvoiceLotNumbers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceLotNumbers.AutoGenerateColumns = False
        Me.dgvInvoiceLotNumbers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceLotNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInvoiceLotNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceLotNumbers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberDataGridViewTextBoxColumn, Me.InvoiceLineNumberDataGridViewTextBoxColumn, Me.InvoiceLotLineNumberDataGridViewTextBoxColumn, Me.InvoiceLotNumberDataGridViewTextBoxColumn, Me.InvoiceHeatNumberDataGridViewTextBoxColumn, Me.InvoiceHeatQuantityDataGridViewTextBoxColumn})
        Me.dgvInvoiceLotNumbers.DataSource = Me.InvoiceLotLineTableBindingSource
        Me.dgvInvoiceLotNumbers.GridColor = System.Drawing.Color.Red
        Me.dgvInvoiceLotNumbers.Location = New System.Drawing.Point(0, 0)
        Me.dgvInvoiceLotNumbers.Name = "dgvInvoiceLotNumbers"
        Me.dgvInvoiceLotNumbers.ReadOnly = True
        Me.dgvInvoiceLotNumbers.Size = New System.Drawing.Size(407, 306)
        Me.dgvInvoiceLotNumbers.TabIndex = 0
        '
        'InvoiceNumberDataGridViewTextBoxColumn
        '
        Me.InvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberDataGridViewTextBoxColumn.HeaderText = "InvoiceNumber"
        Me.InvoiceNumberDataGridViewTextBoxColumn.Name = "InvoiceNumberDataGridViewTextBoxColumn"
        Me.InvoiceNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.InvoiceNumberDataGridViewTextBoxColumn.Visible = False
        '
        'InvoiceLineNumberDataGridViewTextBoxColumn
        '
        Me.InvoiceLineNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceLineNumber"
        Me.InvoiceLineNumberDataGridViewTextBoxColumn.HeaderText = "InvoiceLineNumber"
        Me.InvoiceLineNumberDataGridViewTextBoxColumn.Name = "InvoiceLineNumberDataGridViewTextBoxColumn"
        Me.InvoiceLineNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.InvoiceLineNumberDataGridViewTextBoxColumn.Visible = False
        '
        'InvoiceLotLineNumberDataGridViewTextBoxColumn
        '
        Me.InvoiceLotLineNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceLotLineNumber"
        Me.InvoiceLotLineNumberDataGridViewTextBoxColumn.HeaderText = "InvoiceLotLineNumber"
        Me.InvoiceLotLineNumberDataGridViewTextBoxColumn.Name = "InvoiceLotLineNumberDataGridViewTextBoxColumn"
        Me.InvoiceLotLineNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.InvoiceLotLineNumberDataGridViewTextBoxColumn.Visible = False
        '
        'InvoiceLotNumberDataGridViewTextBoxColumn
        '
        Me.InvoiceLotNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceLotNumber"
        Me.InvoiceLotNumberDataGridViewTextBoxColumn.HeaderText = "Lot #"
        Me.InvoiceLotNumberDataGridViewTextBoxColumn.Name = "InvoiceLotNumberDataGridViewTextBoxColumn"
        Me.InvoiceLotNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.InvoiceLotNumberDataGridViewTextBoxColumn.Width = 120
        '
        'InvoiceHeatNumberDataGridViewTextBoxColumn
        '
        Me.InvoiceHeatNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceHeatNumber"
        Me.InvoiceHeatNumberDataGridViewTextBoxColumn.HeaderText = "Heat #"
        Me.InvoiceHeatNumberDataGridViewTextBoxColumn.Name = "InvoiceHeatNumberDataGridViewTextBoxColumn"
        Me.InvoiceHeatNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.InvoiceHeatNumberDataGridViewTextBoxColumn.Width = 120
        '
        'InvoiceHeatQuantityDataGridViewTextBoxColumn
        '
        Me.InvoiceHeatQuantityDataGridViewTextBoxColumn.DataPropertyName = "InvoiceHeatQuantity"
        Me.InvoiceHeatQuantityDataGridViewTextBoxColumn.HeaderText = "Qty."
        Me.InvoiceHeatQuantityDataGridViewTextBoxColumn.Name = "InvoiceHeatQuantityDataGridViewTextBoxColumn"
        Me.InvoiceHeatQuantityDataGridViewTextBoxColumn.ReadOnly = True
        '
        'InvoiceLotLineTableBindingSource
        '
        Me.InvoiceLotLineTableBindingSource.DataMember = "InvoiceLotLineTable"
        Me.InvoiceLotLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tabSerialNumbers
        '
        Me.tabSerialNumbers.Controls.Add(Me.dgvInvoiceSerialLineTable)
        Me.tabSerialNumbers.Location = New System.Drawing.Point(4, 22)
        Me.tabSerialNumbers.Name = "tabSerialNumbers"
        Me.tabSerialNumbers.Size = New System.Drawing.Size(407, 306)
        Me.tabSerialNumbers.TabIndex = 3
        Me.tabSerialNumbers.Text = "Serial #'s"
        Me.tabSerialNumbers.UseVisualStyleBackColor = True
        '
        'dgvInvoiceSerialLineTable
        '
        Me.dgvInvoiceSerialLineTable.AllowUserToAddRows = False
        Me.dgvInvoiceSerialLineTable.AllowUserToDeleteRows = False
        Me.dgvInvoiceSerialLineTable.AutoGenerateColumns = False
        Me.dgvInvoiceSerialLineTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceSerialLineTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInvoiceSerialLineTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceSerialLineTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SLInvoiceNumberColumn, Me.SLInvoiceLineNumberColumn, Me.SLInvoiceSerialLineNumberColumn, Me.SLInvoiceSerialNumberColumn, Me.SLInvoiceShipmentNumberColumn, Me.SLSerialNumberCostColumn, Me.SLSerialNumberQuantityColumn})
        Me.dgvInvoiceSerialLineTable.DataSource = Me.InvoiceSerialLineTableBindingSource
        Me.dgvInvoiceSerialLineTable.Location = New System.Drawing.Point(0, 0)
        Me.dgvInvoiceSerialLineTable.Name = "dgvInvoiceSerialLineTable"
        Me.dgvInvoiceSerialLineTable.ReadOnly = True
        Me.dgvInvoiceSerialLineTable.Size = New System.Drawing.Size(404, 306)
        Me.dgvInvoiceSerialLineTable.TabIndex = 0
        '
        'SLInvoiceNumberColumn
        '
        Me.SLInvoiceNumberColumn.DataPropertyName = "InvoiceNumber"
        Me.SLInvoiceNumberColumn.HeaderText = "InvoiceNumber"
        Me.SLInvoiceNumberColumn.Name = "SLInvoiceNumberColumn"
        Me.SLInvoiceNumberColumn.ReadOnly = True
        Me.SLInvoiceNumberColumn.Visible = False
        '
        'SLInvoiceLineNumberColumn
        '
        Me.SLInvoiceLineNumberColumn.DataPropertyName = "InvoiceLineNumber"
        Me.SLInvoiceLineNumberColumn.HeaderText = "Line #"
        Me.SLInvoiceLineNumberColumn.Name = "SLInvoiceLineNumberColumn"
        Me.SLInvoiceLineNumberColumn.ReadOnly = True
        Me.SLInvoiceLineNumberColumn.Width = 65
        '
        'SLInvoiceSerialLineNumberColumn
        '
        Me.SLInvoiceSerialLineNumberColumn.DataPropertyName = "InvoiceSerialLineNumber"
        Me.SLInvoiceSerialLineNumberColumn.HeaderText = "InvoiceSerialLineNumber"
        Me.SLInvoiceSerialLineNumberColumn.Name = "SLInvoiceSerialLineNumberColumn"
        Me.SLInvoiceSerialLineNumberColumn.ReadOnly = True
        Me.SLInvoiceSerialLineNumberColumn.Visible = False
        '
        'SLInvoiceSerialNumberColumn
        '
        Me.SLInvoiceSerialNumberColumn.DataPropertyName = "InvoiceSerialNumber"
        Me.SLInvoiceSerialNumberColumn.HeaderText = "Serial Number"
        Me.SLInvoiceSerialNumberColumn.Name = "SLInvoiceSerialNumberColumn"
        Me.SLInvoiceSerialNumberColumn.ReadOnly = True
        Me.SLInvoiceSerialNumberColumn.Width = 200
        '
        'SLInvoiceShipmentNumberColumn
        '
        Me.SLInvoiceShipmentNumberColumn.DataPropertyName = "InvoiceShipmentNumber"
        Me.SLInvoiceShipmentNumberColumn.HeaderText = "InvoiceShipmentNumber"
        Me.SLInvoiceShipmentNumberColumn.Name = "SLInvoiceShipmentNumberColumn"
        Me.SLInvoiceShipmentNumberColumn.ReadOnly = True
        Me.SLInvoiceShipmentNumberColumn.Visible = False
        '
        'SLSerialNumberCostColumn
        '
        Me.SLSerialNumberCostColumn.DataPropertyName = "SerialNumberCost"
        Me.SLSerialNumberCostColumn.HeaderText = "SerialNumberCost"
        Me.SLSerialNumberCostColumn.Name = "SLSerialNumberCostColumn"
        Me.SLSerialNumberCostColumn.ReadOnly = True
        Me.SLSerialNumberCostColumn.Visible = False
        '
        'SLSerialNumberQuantityColumn
        '
        Me.SLSerialNumberQuantityColumn.DataPropertyName = "SerialNumberQuantity"
        Me.SLSerialNumberQuantityColumn.HeaderText = "Quantity"
        Me.SLSerialNumberQuantityColumn.Name = "SLSerialNumberQuantityColumn"
        Me.SLSerialNumberQuantityColumn.ReadOnly = True
        Me.SLSerialNumberQuantityColumn.Width = 80
        '
        'InvoiceSerialLineTableBindingSource
        '
        Me.InvoiceSerialLineTableBindingSource.DataMember = "InvoiceSerialLineTable"
        Me.InvoiceSerialLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentLineLotNumbersBindingSource
        '
        Me.ShipmentLineLotNumbersBindingSource.DataMember = "ShipmentLineLotNumbers"
        Me.ShipmentLineLotNumbersBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tabAddDiscount
        '
        Me.tabAddDiscount.Controls.Add(Me.Label52)
        Me.tabAddDiscount.Controls.Add(Me.txtSalesTaxRate)
        Me.tabAddDiscount.Controls.Add(Me.txtGSTRate)
        Me.tabAddDiscount.Controls.Add(Me.Label50)
        Me.tabAddDiscount.Controls.Add(Me.Label51)
        Me.tabAddDiscount.Controls.Add(Me.txtPSTRate)
        Me.tabAddDiscount.Controls.Add(Me.txtHSTRate2)
        Me.tabAddDiscount.Controls.Add(Me.Label47)
        Me.tabAddDiscount.Controls.Add(Me.Label49)
        Me.tabAddDiscount.Controls.Add(Me.cmdAddTax)
        Me.tabAddDiscount.Controls.Add(Me.Label45)
        Me.tabAddDiscount.Controls.Add(Me.cmdDeleteDiscount)
        Me.tabAddDiscount.Controls.Add(Me.txtDiscountAmount)
        Me.tabAddDiscount.Controls.Add(Me.txtDiscountPercent)
        Me.tabAddDiscount.Controls.Add(Me.Label28)
        Me.tabAddDiscount.Controls.Add(Me.Label27)
        Me.tabAddDiscount.Controls.Add(Me.cmdAddDiscount)
        Me.tabAddDiscount.Location = New System.Drawing.Point(4, 22)
        Me.tabAddDiscount.Name = "tabAddDiscount"
        Me.tabAddDiscount.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAddDiscount.Size = New System.Drawing.Size(345, 528)
        Me.tabAddDiscount.TabIndex = 2
        Me.tabAddDiscount.Text = "Add Tax"
        Me.tabAddDiscount.UseVisualStyleBackColor = True
        '
        'Label52
        '
        Me.Label52.ForeColor = System.Drawing.Color.Blue
        Me.Label52.Location = New System.Drawing.Point(53, 404)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(133, 21)
        Me.Label52.TabIndex = 95
        Me.Label52.Text = "Enter rate as a decimal"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTaxRate
        '
        Me.txtSalesTaxRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTaxRate.Location = New System.Drawing.Point(158, 268)
        Me.txtSalesTaxRate.Name = "txtSalesTaxRate"
        Me.txtSalesTaxRate.Size = New System.Drawing.Size(132, 20)
        Me.txtSalesTaxRate.TabIndex = 91
        Me.txtSalesTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGSTRate
        '
        Me.txtGSTRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGSTRate.Location = New System.Drawing.Point(158, 309)
        Me.txtGSTRate.Name = "txtGSTRate"
        Me.txtGSTRate.Size = New System.Drawing.Size(132, 20)
        Me.txtGSTRate.TabIndex = 92
        Me.txtGSTRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(34, 268)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(118, 21)
        Me.Label50.TabIndex = 94
        Me.Label50.Text = "Sales Tax Rate (US)"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(34, 309)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(118, 21)
        Me.Label51.TabIndex = 93
        Me.Label51.Text = "GST Rate (Canada)"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPSTRate
        '
        Me.txtPSTRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPSTRate.Location = New System.Drawing.Point(158, 335)
        Me.txtPSTRate.Name = "txtPSTRate"
        Me.txtPSTRate.Size = New System.Drawing.Size(132, 20)
        Me.txtPSTRate.TabIndex = 87
        Me.txtPSTRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHSTRate2
        '
        Me.txtHSTRate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHSTRate2.Location = New System.Drawing.Point(158, 361)
        Me.txtHSTRate2.Name = "txtHSTRate2"
        Me.txtHSTRate2.Size = New System.Drawing.Size(132, 20)
        Me.txtHSTRate2.TabIndex = 88
        Me.txtHSTRate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(34, 336)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(118, 21)
        Me.Label47.TabIndex = 90
        Me.Label47.Text = "PST Rate (Canada)"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(34, 362)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(118, 21)
        Me.Label49.TabIndex = 89
        Me.Label49.Text = "HST Rate (Canada)"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddTax
        '
        Me.cmdAddTax.Location = New System.Drawing.Point(219, 394)
        Me.cmdAddTax.Name = "cmdAddTax"
        Me.cmdAddTax.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddTax.TabIndex = 86
        Me.cmdAddTax.Text = "Add Sales Tax"
        Me.cmdAddTax.UseVisualStyleBackColor = True
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Blue
        Me.Label45.Location = New System.Drawing.Point(18, 16)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(311, 102)
        Me.Label45.TabIndex = 85
        Me.Label45.Text = resources.GetString("Label45.Text")
        '
        'cmdDeleteDiscount
        '
        Me.cmdDeleteDiscount.Location = New System.Drawing.Point(219, 190)
        Me.cmdDeleteDiscount.Name = "cmdDeleteDiscount"
        Me.cmdDeleteDiscount.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteDiscount.TabIndex = 24
        Me.cmdDeleteDiscount.Text = "Delete Discount"
        Me.cmdDeleteDiscount.UseVisualStyleBackColor = True
        '
        'txtDiscountAmount
        '
        Me.txtDiscountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountAmount.Location = New System.Drawing.Point(142, 121)
        Me.txtDiscountAmount.Name = "txtDiscountAmount"
        Me.txtDiscountAmount.Size = New System.Drawing.Size(148, 20)
        Me.txtDiscountAmount.TabIndex = 21
        Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscountPercent
        '
        Me.txtDiscountPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiscountPercent.Location = New System.Drawing.Point(142, 147)
        Me.txtDiscountPercent.Name = "txtDiscountPercent"
        Me.txtDiscountPercent.Size = New System.Drawing.Size(148, 20)
        Me.txtDiscountPercent.TabIndex = 22
        Me.txtDiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(34, 120)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(101, 21)
        Me.Label28.TabIndex = 83
        Me.Label28.Text = "Discount Rate ($)"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(34, 147)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(101, 21)
        Me.Label27.TabIndex = 80
        Me.Label27.Text = "Discount Rate (%)"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabBillingAddress
        '
        Me.tabBillingAddress.Controls.Add(Me.txtBTAddress1)
        Me.tabBillingAddress.Controls.Add(Me.txtBTAddress2)
        Me.tabBillingAddress.Controls.Add(Me.txtBTCity)
        Me.tabBillingAddress.Controls.Add(Me.Label22)
        Me.tabBillingAddress.Controls.Add(Me.txtThirdPartyShipper)
        Me.tabBillingAddress.Controls.Add(Me.txtBTZip)
        Me.tabBillingAddress.Controls.Add(Me.txtBTCountry)
        Me.tabBillingAddress.Controls.Add(Me.Label10)
        Me.tabBillingAddress.Controls.Add(Me.Label9)
        Me.tabBillingAddress.Controls.Add(Me.cboBTState)
        Me.tabBillingAddress.Controls.Add(Me.Label13)
        Me.tabBillingAddress.Controls.Add(Me.Label15)
        Me.tabBillingAddress.Controls.Add(Me.Label11)
        Me.tabBillingAddress.Controls.Add(Me.Label14)
        Me.tabBillingAddress.Location = New System.Drawing.Point(4, 22)
        Me.tabBillingAddress.Name = "tabBillingAddress"
        Me.tabBillingAddress.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBillingAddress.Size = New System.Drawing.Size(345, 528)
        Me.tabBillingAddress.TabIndex = 1
        Me.tabBillingAddress.Text = "Billing Address"
        Me.tabBillingAddress.UseVisualStyleBackColor = True
        '
        'txtBTAddress1
        '
        Me.txtBTAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTAddress1.Location = New System.Drawing.Point(18, 42)
        Me.txtBTAddress1.Multiline = True
        Me.txtBTAddress1.Name = "txtBTAddress1"
        Me.txtBTAddress1.Size = New System.Drawing.Size(305, 22)
        Me.txtBTAddress1.TabIndex = 15
        Me.txtBTAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTAddress2
        '
        Me.txtBTAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTAddress2.Location = New System.Drawing.Point(18, 97)
        Me.txtBTAddress2.Multiline = True
        Me.txtBTAddress2.Name = "txtBTAddress2"
        Me.txtBTAddress2.Size = New System.Drawing.Size(305, 22)
        Me.txtBTAddress2.TabIndex = 16
        Me.txtBTAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTCity
        '
        Me.txtBTCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTCity.Location = New System.Drawing.Point(67, 138)
        Me.txtBTCity.Name = "txtBTCity"
        Me.txtBTCity.Size = New System.Drawing.Size(256, 20)
        Me.txtBTCity.TabIndex = 17
        Me.txtBTCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(18, 376)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(278, 21)
        Me.Label22.TabIndex = 93
        Me.Label22.Text = "Third Party Shipping Info"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtThirdPartyShipper
        '
        Me.txtThirdPartyShipper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThirdPartyShipper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtThirdPartyShipper.Enabled = False
        Me.txtThirdPartyShipper.Location = New System.Drawing.Point(21, 400)
        Me.txtThirdPartyShipper.Multiline = True
        Me.txtThirdPartyShipper.Name = "txtThirdPartyShipper"
        Me.txtThirdPartyShipper.Size = New System.Drawing.Size(309, 113)
        Me.txtThirdPartyShipper.TabIndex = 21
        Me.txtThirdPartyShipper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTZip
        '
        Me.txtBTZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTZip.Location = New System.Drawing.Point(67, 207)
        Me.txtBTZip.Name = "txtBTZip"
        Me.txtBTZip.Size = New System.Drawing.Size(135, 20)
        Me.txtBTZip.TabIndex = 19
        Me.txtBTZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBTCountry
        '
        Me.txtBTCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBTCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBTCountry.Location = New System.Drawing.Point(67, 241)
        Me.txtBTCountry.Name = "txtBTCountry"
        Me.txtBTCountry.Size = New System.Drawing.Size(256, 20)
        Me.txtBTCountry.TabIndex = 20
        Me.txtBTCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 21)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "Address 2"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 21)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "Address 1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBTState
        '
        Me.cboBTState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBTState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBTState.DataSource = Me.StateTableBindingSource
        Me.cboBTState.DisplayMember = "StateCode"
        Me.cboBTState.FormattingEnabled = True
        Me.cboBTState.Location = New System.Drawing.Point(67, 172)
        Me.cboBTState.Name = "cboBTState"
        Me.cboBTState.Size = New System.Drawing.Size(135, 21)
        Me.cboBTState.TabIndex = 18
        Me.cboBTState.ValueMember = "ItemID"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(18, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 21)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "City"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(18, 240)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 21)
        Me.Label15.TabIndex = 81
        Me.Label15.Text = "Country"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(18, 172)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 21)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "State"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(18, 207)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 21)
        Me.Label14.TabIndex = 78
        Me.Label14.Text = "ZIP"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabCustomerDetails
        '
        Me.tabCustomerDetails.Controls.Add(Me.Label56)
        Me.tabCustomerDetails.Controls.Add(Me.txtCustomerNotes)
        Me.tabCustomerDetails.Controls.Add(Me.txtQuotedFreight)
        Me.tabCustomerDetails.Controls.Add(Me.Label55)
        Me.tabCustomerDetails.Controls.Add(Me.lblShipDate)
        Me.tabCustomerDetails.Controls.Add(Me.cboShipMethod)
        Me.tabCustomerDetails.Controls.Add(Me.Label54)
        Me.tabCustomerDetails.Controls.Add(Me.cboShipVia)
        Me.tabCustomerDetails.Controls.Add(Me.cboPaymentTerms)
        Me.tabCustomerDetails.Controls.Add(Me.txtBilledFreight)
        Me.tabCustomerDetails.Controls.Add(Me.txtCustomerPONumber)
        Me.tabCustomerDetails.Controls.Add(Me.txtProNumber)
        Me.tabCustomerDetails.Controls.Add(Me.txtCustomerName)
        Me.tabCustomerDetails.Controls.Add(Me.cboCustomerID)
        Me.tabCustomerDetails.Controls.Add(Me.Label25)
        Me.tabCustomerDetails.Controls.Add(Me.Label26)
        Me.tabCustomerDetails.Controls.Add(Me.Label2)
        Me.tabCustomerDetails.Controls.Add(Me.Label7)
        Me.tabCustomerDetails.Controls.Add(Me.Label24)
        Me.tabCustomerDetails.Controls.Add(Me.Label23)
        Me.tabCustomerDetails.Controls.Add(Me.Label21)
        Me.tabCustomerDetails.Controls.Add(Me.lblEmailInvoice)
        Me.tabCustomerDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabCustomerDetails.Name = "tabCustomerDetails"
        Me.tabCustomerDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCustomerDetails.Size = New System.Drawing.Size(345, 528)
        Me.tabCustomerDetails.TabIndex = 0
        Me.tabCustomerDetails.Text = "Order Details"
        Me.tabCustomerDetails.UseVisualStyleBackColor = True
        '
        'Label56
        '
        Me.Label56.ForeColor = System.Drawing.Color.Blue
        Me.Label56.Location = New System.Drawing.Point(6, 381)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(318, 16)
        Me.Label56.TabIndex = 98
        Me.Label56.Text = "Customer Notes (Does not print on invoice)"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerNotes
        '
        Me.txtCustomerNotes.BackColor = System.Drawing.Color.White
        Me.txtCustomerNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerNotes.Enabled = False
        Me.txtCustomerNotes.Location = New System.Drawing.Point(6, 400)
        Me.txtCustomerNotes.Multiline = True
        Me.txtCustomerNotes.Name = "txtCustomerNotes"
        Me.txtCustomerNotes.ReadOnly = True
        Me.txtCustomerNotes.Size = New System.Drawing.Size(333, 122)
        Me.txtCustomerNotes.TabIndex = 17
        Me.txtCustomerNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuotedFreight
        '
        Me.txtQuotedFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuotedFreight.Location = New System.Drawing.Point(138, 346)
        Me.txtQuotedFreight.Name = "txtQuotedFreight"
        Me.txtQuotedFreight.Size = New System.Drawing.Size(186, 20)
        Me.txtQuotedFreight.TabIndex = 16
        Me.txtQuotedFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label55
        '
        Me.Label55.Location = New System.Drawing.Point(15, 346)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(110, 21)
        Me.Label55.TabIndex = 96
        Me.Label55.Text = "Quoted Freight"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShipDate
        '
        Me.lblShipDate.BackColor = System.Drawing.Color.White
        Me.lblShipDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblShipDate.Location = New System.Drawing.Point(104, 204)
        Me.lblShipDate.Name = "lblShipDate"
        Me.lblShipDate.Size = New System.Drawing.Size(220, 20)
        Me.lblShipDate.TabIndex = 11
        Me.lblShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboShipMethod
        '
        Me.cboShipMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipMethod.FormattingEnabled = True
        Me.cboShipMethod.Items.AddRange(New Object() {"COLLECT", "PREPAID", "PREPAID/ADD", "PREPAID/NOADD", "THIRD PARTY", "OTHER"})
        Me.cboShipMethod.Location = New System.Drawing.Point(87, 261)
        Me.cboShipMethod.MaxLength = 50
        Me.cboShipMethod.Name = "cboShipMethod"
        Me.cboShipMethod.Size = New System.Drawing.Size(237, 21)
        Me.cboShipMethod.TabIndex = 13
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(15, 262)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(110, 21)
        Me.Label54.TabIndex = 89
        Me.Label54.Text = "Ship Method"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipVia
        '
        Me.cboShipVia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipVia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(87, 232)
        Me.cboShipVia.MaxLength = 50
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(237, 21)
        Me.cboShipVia.TabIndex = 12
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.DisplayMember = "ItemID"
        Me.cboPaymentTerms.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Items.AddRange(New Object() {"N30", "COD", "CREDIT CARD", "Prepaid", "NetDue"})
        Me.cboPaymentTerms.Location = New System.Drawing.Point(104, 147)
        Me.cboPaymentTerms.MaxLength = 50
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(220, 21)
        Me.cboPaymentTerms.TabIndex = 9
        Me.cboPaymentTerms.ValueMember = "ItemID"
        '
        'txtBilledFreight
        '
        Me.txtBilledFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBilledFreight.Location = New System.Drawing.Point(138, 318)
        Me.txtBilledFreight.Name = "txtBilledFreight"
        Me.txtBilledFreight.Size = New System.Drawing.Size(186, 20)
        Me.txtBilledFreight.TabIndex = 15
        Me.txtBilledFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCustomerPONumber
        '
        Me.txtCustomerPONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPONumber.Location = New System.Drawing.Point(104, 176)
        Me.txtCustomerPONumber.Name = "txtCustomerPONumber"
        Me.txtCustomerPONumber.Size = New System.Drawing.Size(220, 20)
        Me.txtCustomerPONumber.TabIndex = 10
        '
        'txtProNumber
        '
        Me.txtProNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProNumber.Location = New System.Drawing.Point(138, 290)
        Me.txtProNumber.Name = "txtProNumber"
        Me.txtProNumber.Size = New System.Drawing.Size(186, 20)
        Me.txtProNumber.TabIndex = 14
        Me.txtProNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.White
        Me.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerName.Location = New System.Drawing.Point(15, 42)
        Me.txtCustomerName.Multiline = True
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(309, 66)
        Me.txtCustomerName.TabIndex = 7
        Me.txtCustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 300
        Me.cboCustomerID.Enabled = False
        Me.cboCustomerID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(69, 15)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(255, 21)
        Me.cboCustomerID.TabIndex = 6
        Me.cboCustomerID.ValueMember = "ItemID"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(15, 176)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(110, 21)
        Me.Label25.TabIndex = 83
        Me.Label25.Text = "Customer PO#"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(15, 318)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(110, 21)
        Me.Label26.TabIndex = 79
        Me.Label26.Text = "Billed Freight"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 21)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Payment Terms"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 21)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Customer"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(15, 234)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(110, 21)
        Me.Label24.TabIndex = 77
        Me.Label24.Text = "Ship Via"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(15, 203)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(110, 21)
        Me.Label23.TabIndex = 76
        Me.Label23.Text = "Ship Date"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(15, 290)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(110, 21)
        Me.Label21.TabIndex = 74
        Me.Label21.Text = "PRO Number"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmailInvoice
        '
        Me.lblEmailInvoice.ForeColor = System.Drawing.Color.Blue
        Me.lblEmailInvoice.Location = New System.Drawing.Point(15, 111)
        Me.lblEmailInvoice.Name = "lblEmailInvoice"
        Me.lblEmailInvoice.Size = New System.Drawing.Size(309, 33)
        Me.lblEmailInvoice.TabIndex = 8
        Me.lblEmailInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabCustomerDetails)
        Me.TabControl1.Controls.Add(Me.tabBillingAddress)
        Me.TabControl1.Controls.Add(Me.tabComments)
        Me.TabControl1.Controls.Add(Me.tabAddDiscount)
        Me.TabControl1.Location = New System.Drawing.Point(29, 262)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(353, 554)
        Me.TabControl1.TabIndex = 6
        '
        'tabComments
        '
        Me.tabComments.Controls.Add(Me.txtSpecialInstructions)
        Me.tabComments.Controls.Add(Me.Label3)
        Me.tabComments.Controls.Add(Me.Label53)
        Me.tabComments.Controls.Add(Me.txtComment)
        Me.tabComments.Location = New System.Drawing.Point(4, 22)
        Me.tabComments.Name = "tabComments"
        Me.tabComments.Size = New System.Drawing.Size(345, 528)
        Me.tabComments.TabIndex = 3
        Me.tabComments.Text = "Comments"
        Me.tabComments.UseVisualStyleBackColor = True
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpecialInstructions.Location = New System.Drawing.Point(20, 328)
        Me.txtSpecialInstructions.Multiline = True
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.Size = New System.Drawing.Size(307, 180)
        Me.txtSpecialInstructions.TabIndex = 23
        Me.txtSpecialInstructions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(17, 304)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(272, 21)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "Special Instructions/Notes (Prints on Invoice)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label53
        '
        Me.Label53.ForeColor = System.Drawing.Color.Blue
        Me.Label53.Location = New System.Drawing.Point(18, 13)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(273, 21)
        Me.Label53.TabIndex = 84
        Me.Label53.Text = "Comment (Internal use - does not print on Invoice)"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComment.Location = New System.Drawing.Point(18, 37)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(309, 180)
        Me.txtComment.TabIndex = 22
        Me.txtComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'InvoiceProcessingBatchHeaderTableAdapter
        '
        Me.InvoiceProcessingBatchHeaderTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'ShipmentLineLotNumbersTableAdapter
        '
        Me.ShipmentLineLotNumbersTableAdapter.ClearBeforeFill = True
        '
        'InvoiceLotLineTableTableAdapter
        '
        Me.InvoiceLotLineTableTableAdapter.ClearBeforeFill = True
        '
        'cmdEmailBoth
        '
        Me.cmdEmailBoth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEmailBoth.Location = New System.Drawing.Point(891, 729)
        Me.cmdEmailBoth.Name = "cmdEmailBoth"
        Me.cmdEmailBoth.Size = New System.Drawing.Size(71, 40)
        Me.cmdEmailBoth.TabIndex = 46
        Me.cmdEmailBoth.Text = "Email W/Certs"
        Me.cmdEmailBoth.UseVisualStyleBackColor = True
        '
        'cmdPrintCerts
        '
        Me.cmdPrintCerts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintCerts.Location = New System.Drawing.Point(973, 729)
        Me.cmdPrintCerts.Name = "cmdPrintCerts"
        Me.cmdPrintCerts.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintCerts.TabIndex = 47
        Me.cmdPrintCerts.Text = "Print All Certs"
        Me.cmdPrintCerts.UseVisualStyleBackColor = True
        '
        'InvoiceSerialLineTableTableAdapter
        '
        Me.InvoiceSerialLineTableTableAdapter.ClearBeforeFill = True
        '
        'cmdUploadShowPickTicket
        '
        Me.cmdUploadShowPickTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadShowPickTicket.Location = New System.Drawing.Point(809, 776)
        Me.cmdUploadShowPickTicket.Name = "cmdUploadShowPickTicket"
        Me.cmdUploadShowPickTicket.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadShowPickTicket.TabIndex = 49
        Me.cmdUploadShowPickTicket.Text = "Upload Pick Ticket"
        Me.cmdUploadShowPickTicket.UseVisualStyleBackColor = True
        '
        'cmdPrintPackList
        '
        Me.cmdPrintPackList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintPackList.Location = New System.Drawing.Point(809, 729)
        Me.cmdPrintPackList.Name = "cmdPrintPackList"
        Me.cmdPrintPackList.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintPackList.TabIndex = 45
        Me.cmdPrintPackList.Text = "Print Pack List"
        Me.cmdPrintPackList.UseVisualStyleBackColor = True
        '
        'lblEmailSent
        '
        Me.lblEmailSent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmailSent.ForeColor = System.Drawing.Color.Blue
        Me.lblEmailSent.Location = New System.Drawing.Point(654, 0)
        Me.lblEmailSent.Name = "lblEmailSent"
        Me.lblEmailSent.Size = New System.Drawing.Size(488, 20)
        Me.lblEmailSent.TabIndex = 53
        '
        'TimeSlipLineItemTableTableAdapter1
        '
        Me.TimeSlipLineItemTableTableAdapter1.ClearBeforeFill = True
        '
        'cmdViewPickTicket
        '
        Me.cmdViewPickTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPickTicket.Location = New System.Drawing.Point(809, 776)
        Me.cmdViewPickTicket.Name = "cmdViewPickTicket"
        Me.cmdViewPickTicket.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPickTicket.TabIndex = 92
        Me.cmdViewPickTicket.Text = "View Pick Ticket"
        Me.cmdViewPickTicket.UseVisualStyleBackColor = True
        '
        'cmdRemoteScan
        '
        Me.cmdRemoteScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoteScan.Location = New System.Drawing.Point(809, 776)
        Me.cmdRemoteScan.Name = "cmdRemoteScan"
        Me.cmdRemoteScan.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoteScan.TabIndex = 93
        Me.cmdRemoteScan.Text = "Upload Pick Ticket"
        Me.cmdRemoteScan.UseVisualStyleBackColor = True
        '
        'InvoicingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdRemoteScan)
        Me.Controls.Add(Me.cmdViewPickTicket)
        Me.Controls.Add(Me.lblEmailSent)
        Me.Controls.Add(Me.cmdPrintPackList)
        Me.Controls.Add(Me.cmdUploadShowPickTicket)
        Me.Controls.Add(Me.cmdEmailBoth)
        Me.Controls.Add(Me.cmdPrintCerts)
        Me.Controls.Add(Me.tabLineDetails)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.dgvInvoiceLines)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpxInvoiceHeaderInfo)
        Me.Controls.Add(Me.cmdPrintInvoice)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "InvoicingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Invoicing Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxInvoiceHeaderInfo.ResumeLayout(False)
        Me.gpxInvoiceHeaderInfo.PerformLayout()
        CType(Me.InvoiceProcessingBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoiceLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLineDetails.ResumeLayout(False)
        Me.tabInvoiceLineDetails.ResumeLayout(False)
        Me.tabInvoiceLineDetails.PerformLayout()
        Me.tabInvoiceLineOther.ResumeLayout(False)
        Me.tabInvoiceLineOther.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLotNumbers.ResumeLayout(False)
        CType(Me.dgvInvoiceLotNumbers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceLotLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSerialNumbers.ResumeLayout(False)
        CType(Me.dgvInvoiceSerialLineTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceSerialLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentLineLotNumbersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAddDiscount.ResumeLayout(False)
        Me.tabAddDiscount.PerformLayout()
        Me.tabBillingAddress.ResumeLayout(False)
        Me.tabBillingAddress.PerformLayout()
        Me.tabCustomerDetails.ResumeLayout(False)
        Me.tabCustomerDetails.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabComments.ResumeLayout(False)
        Me.tabComments.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrintInvoice As System.Windows.Forms.Button
    Friend WithEvents gpxInvoiceHeaderInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSalesTax As System.Windows.Forms.TextBox
    Friend WithEvents LabelSalesTax As System.Windows.Forms.Label
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtFreightBilled As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtProductSales As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdAddDiscount As System.Windows.Forms.Button
    Friend WithEvents QuantityShippedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PickedItemDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents dgvInvoiceLines As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLineTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents cboLinePartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboLinePartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cboInvoiceLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents tabLineDetails As System.Windows.Forms.TabControl
    Friend WithEvents tabInvoiceLineDetails As System.Windows.Forms.TabPage
    Friend WithEvents tabInvoiceLineOther As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtLineComment As System.Windows.Forms.TextBox
    Friend WithEvents txtLineExtendedAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtLineSalesTax As System.Windows.Forms.TextBox
    Friend WithEvents txtLinePrice As System.Windows.Forms.TextBox
    Friend WithEvents txtLineQuantityBilled As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents tabAddDiscount As System.Windows.Forms.TabPage
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscountPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tabBillingAddress As System.Windows.Forms.TabPage
    Friend WithEvents txtBTAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBTAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtBTCity As System.Windows.Forms.TextBox
    Friend WithEvents txtBTZip As System.Windows.Forms.TextBox
    Friend WithEvents txtBTCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboBTState As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tabCustomerDetails As System.Windows.Forms.TabPage
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBilledFreight As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerPONumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtProNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteDiscount As System.Windows.Forms.Button
    Friend WithEvents cboBatchNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents InvoiceProcessingBatchHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceProcessingBatchHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceProcessingBatchHeaderTableAdapter
    Friend WithEvents txtGLSalesAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLPurchasesAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLCOGSAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLIssuesAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLAdjustmentAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLSalesOffsetAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLInventoryAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtGLReturnsAccount As System.Windows.Forms.TextBox
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents tabLotNumbers As System.Windows.Forms.TabPage
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents ShipmentLineLotNumbersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentLineLotNumbersTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineLotNumbersTableAdapter
    Friend WithEvents SaveInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceStatus As System.Windows.Forms.TextBox
    Friend WithEvents PrintInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesTax3 As System.Windows.Forms.TextBox
    Friend WithEvents LabelHST As System.Windows.Forms.Label
    Friend WithEvents txtSalesTax2 As System.Windows.Forms.TextBox
    Friend WithEvents LabelPST As System.Windows.Forms.Label
    Friend WithEvents cmdRemoveSalesTax As System.Windows.Forms.Button
    Friend WithEvents chkAddPST As System.Windows.Forms.CheckBox
    Friend WithEvents chkAddHST As System.Windows.Forms.CheckBox
    Friend WithEvents txtHSTRate As System.Windows.Forms.TextBox
    Friend WithEvents lblEmailInvoice As System.Windows.Forms.Label
    Friend WithEvents dgvInvoiceLotNumbers As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceLotLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceLotLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceLotLineTableTableAdapter
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtSalesTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents txtGSTRate As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtPSTRate As System.Windows.Forms.TextBox
    Friend WithEvents txtHSTRate2 As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents cmdAddTax As System.Windows.Forms.Button
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents cmdEmailBoth As System.Windows.Forms.Button
    Friend WithEvents cmdPrintCerts As System.Windows.Forms.Button
    Friend WithEvents tabComments As System.Windows.Forms.TabPage
    Friend WithEvents txtSpecialInstructions As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtThirdPartyShipper As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents tabSerialNumbers As System.Windows.Forms.TabPage
    Friend WithEvents dgvInvoiceSerialLineTable As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceSerialLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceSerialLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceSerialLineTableTableAdapter
    Friend WithEvents InvoiceHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceLineKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityBilledColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCOSColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddTaxToInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblShipDate As System.Windows.Forms.Label
    Friend WithEvents txtShipmentNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtQuotedFreight As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents cmdUploadShowPickTicket As System.Windows.Forms.Button
    Friend WithEvents ReUploadPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendUploadedPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrintPackList As System.Windows.Forms.Button
    Friend WithEvents lblEmailSent As System.Windows.Forms.Label
    Friend WithEvents AutoEmailByPreferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents crxInvoice1 As MOS09Program.CRXInvoice
    Friend WithEvents crxInvoiceTFF1 As MOS09Program.CRXInvoiceTFF
    Friend WithEvents crxPackingSlipTFP1 As MOS09Program.CRXPackingSlipTFP
    Friend WithEvents crxPackingSlip1 As MOS09Program.CRXPackingSlip
    Friend WithEvents crxtwCert011 As MOS09Program.CRXTWCert01
    Friend WithEvents InvoiceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceLineNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceLotLineNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceLotNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceHeatNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceHeatQuantityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLInvoiceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLInvoiceLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLInvoiceSerialLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLInvoiceSerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLInvoiceShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLSerialNumberCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLSerialNumberQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeSlipLineItemTableTableAdapter1 As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TimeSlipLineItemTableTableAdapter
    Friend WithEvents cmdViewPickTicket As System.Windows.Forms.Button
    Friend WithEvents CachedCRXCommissionReportbyTerritory1 As MOS09Program.CachedCRXCommissionReportbyTerritory
    Friend WithEvents cmdRemoteScan As System.Windows.Forms.Button
    Friend WithEvents ScanPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerNotes As System.Windows.Forms.TextBox
End Class
