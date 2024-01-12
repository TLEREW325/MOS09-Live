<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POForm
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POForm))
        Me.lblPONumber = New System.Windows.Forms.Label
        Me.lblVendorName = New System.Windows.Forms.Label
        Me.LabelPODate = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxPOHeaderData = New System.Windows.Forms.GroupBox
        Me.llVendorInfo = New System.Windows.Forms.LinkLabel
        Me.txtVendorName = New System.Windows.Forms.TextBox
        Me.dtpShipDatePicker = New System.Windows.Forms.DateTimePicker
        Me.txtPOStatus = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboVendorCode = New System.Windows.Forms.ComboBox
        Me.VendorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdGeneratePO = New System.Windows.Forms.Button
        Me.dtpPurchaseOrderDate = New System.Windows.Forms.DateTimePicker
        Me.cboPurchaseOrderNumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPaymentTerms = New System.Windows.Forms.ComboBox
        Me.PaymentTermsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblPaymentTerms = New System.Windows.Forms.Label
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblPOShipDate = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPOComment = New System.Windows.Forms.TextBox
        Me.txtFreightCharges = New System.Windows.Forms.TextBox
        Me.txtCustomerDSAddress1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdPrintPO = New System.Windows.Forms.Button
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.lblLastPurchaseCost = New System.Windows.Forms.Label
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.chkInventoryItem = New System.Windows.Forms.CheckBox
        Me.lblAmount = New System.Windows.Forms.Label
        Me.cmdAddItem = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.txtOrderQuantity = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCustomerDSAddress2 = New System.Windows.Forms.TextBox
        Me.txtCustomerDSZip = New System.Windows.Forms.TextBox
        Me.txtCustomerDSCity = New System.Windows.Forms.TextBox
        Me.cboCustomerDSName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClosePurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SavePurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReIssuePurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReOpenPurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeletePurchaseOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManuallyClosePOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManuallyOpenPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnLockPurchaseORderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewQuoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadQuoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewOpenPOsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewClosedPOsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPOPackListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintReceiversToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.txtCustomerCountry = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.chkDropShip = New System.Windows.Forms.CheckBox
        Me.cboDropShipState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdSavePO = New System.Windows.Forms.Button
        Me.cmdDeletePO = New System.Windows.Forms.Button
        Me.gpxOrderTotals = New System.Windows.Forms.GroupBox
        Me.lblOpenWeight = New System.Windows.Forms.Label
        Me.lblEstWeight = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.txtSalesTax = New System.Windows.Forms.TextBox
        Me.lblOrderTotal = New System.Windows.Forms.Label
        Me.lblPurchaseTotal = New System.Windows.Forms.Label
        Me.Label73 = New System.Windows.Forms.Label
        Me.Label74 = New System.Windows.Forms.Label
        Me.Label75 = New System.Windows.Forms.Label
        Me.Label76 = New System.Windows.Forms.Label
        Me.cmdPurchaseHistory = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdVendorForm = New System.Windows.Forms.Button
        Me.cmdReissuePO = New System.Windows.Forms.Button
        Me.tabPOlineDetails = New System.Windows.Forms.TabControl
        Me.POLineDetails = New System.Windows.Forms.TabPage
        Me.lstPartDescriptionSuggest = New System.Windows.Forms.ListBox
        Me.lstLinePartDescriptionSuggest = New System.Windows.Forms.ListBox
        Me.lblBoxCount = New System.Windows.Forms.Label
        Me.lblPalletCount = New System.Windows.Forms.Label
        Me.llLastPurchaseCost = New System.Windows.Forms.LinkLabel
        Me.llOrderQuantity = New System.Windows.Forms.LinkLabel
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboNewItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblItemClassNew = New System.Windows.Forms.Label
        Me.txtLineComment = New System.Windows.Forms.TextBox
        Me.GLLineDetails = New System.Windows.Forms.TabPage
        Me.txtIssuesAccount = New System.Windows.Forms.TextBox
        Me.txtAdjustmentAccount = New System.Windows.Forms.TextBox
        Me.txtSalesOffsetAccount = New System.Windows.Forms.TextBox
        Me.txtPurchaseAccount = New System.Windows.Forms.TextBox
        Me.txtCOGSAccount = New System.Windows.Forms.TextBox
        Me.txtInventoryAccount = New System.Windows.Forms.TextBox
        Me.txtReturnsAccount = New System.Windows.Forms.TextBox
        Me.txtSalesAccount = New System.Windows.Forms.TextBox
        Me.cboItemClass = New System.Windows.Forms.ComboBox
        Me.ItemClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.tabLineDetails = New System.Windows.Forms.TabPage
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtLineComment2 = New System.Windows.Forms.TextBox
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.txtLineGLCredit = New System.Windows.Forms.TextBox
        Me.cmdSaveLine = New System.Windows.Forms.Button
        Me.Label28 = New System.Windows.Forms.Label
        Me.cboLineNumber = New System.Windows.Forms.ComboBox
        Me.PurchaseOrderLineQueryQOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtLineGLDebit = New System.Windows.Forms.TextBox
        Me.cboLinePartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label30 = New System.Windows.Forms.Label
        Me.cboLineDescription = New System.Windows.Forms.ComboBox
        Me.txtLineUnitCost = New System.Windows.Forms.TextBox
        Me.txtLineExtendedCost = New System.Windows.Forms.TextBox
        Me.txtLineOrderQuantity = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.VendorTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.PaymentTermsTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.ItemClassTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.Label37 = New System.Windows.Forms.Label
        Me.cboShipToID = New System.Windows.Forms.ComboBox
        Me.AdditionalShipToBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AdditionalShipToTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
        Me.tabPODetails = New System.Windows.Forms.TabControl
        Me.tabPOLines = New System.Windows.Forms.TabPage
        Me.dgvPurchaseOrderLines = New System.Windows.Forms.DataGridView
        Me.PurchaseOrderLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityReceivedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityOpenColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderHeaderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tabOtherDetails = New System.Windows.Forms.TabPage
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.txtDivisionVendor = New System.Windows.Forms.TextBox
        Me.cmdGetDivisionPackList = New System.Windows.Forms.Button
        Me.Label42 = New System.Windows.Forms.Label
        Me.txtShippingWeight = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtNumberOfBoxes = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdLoadDefaultAddress = New System.Windows.Forms.Button
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdLinkPOAndSO = New System.Windows.Forms.Button
        Me.txtDSSalesOrderNumber = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtShippingName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.tabOrderTracking = New System.Windows.Forms.TabPage
        Me.dgvReturnTable = New System.Windows.Forms.DataGridView
        Me.ReturnNumberColumnRTT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnDateColumnRTT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnTotalColumnRTT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnStatusColumnRTT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumnRTT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VendorReturnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvReceiverTable = New System.Windows.Forms.DataGridView
        Me.ReceivingHeaderKeyColumnRT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingDateColumnRT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POTotalColumnRT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumnRT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumnRT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvROITable = New System.Windows.Forms.DataGridView
        Me.VoucherNumberColumnVT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumnVT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateColumnVT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumnVT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherStatusColumnVT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumnVT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptOfInvoiceBatchLineBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label47 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblDifference = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.lblNumberReceivers = New System.Windows.Forms.Label
        Me.lblNumberReturns = New System.Windows.Forms.Label
        Me.lblNumberVouchers = New System.Windows.Forms.Label
        Me.lblReturnTotal = New System.Windows.Forms.Label
        Me.lblVoucherTotal = New System.Windows.Forms.Label
        Me.lblReceiverTotal = New System.Windows.Forms.Label
        Me.Label71 = New System.Windows.Forms.Label
        Me.Label70 = New System.Windows.Forms.Label
        Me.Label69 = New System.Windows.Forms.Label
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.Label66 = New System.Windows.Forms.Label
        Me.gpxVendorData = New System.Windows.Forms.GroupBox
        Me.cboShipMethod = New System.Windows.Forms.ComboBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.CachedCRXGLWCProductionLines1 = New MOS09Program.CachedCRXGLWCProductionLines
        Me.PurchaseOrderLineQueryQOTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderLineQueryQOTableAdapter
        Me.ReceiptOfInvoiceBatchLineTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
        Me.ReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
        Me.VendorReturnTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnTableAdapter
        Me.cmdUploadQuote = New System.Windows.Forms.Button
        Me.cmdViewQuote = New System.Windows.Forms.Button
        Me.ofdPOQuotes = New System.Windows.Forms.OpenFileDialog
        Me.lblOpen = New System.Windows.Forms.Label
        Me.gpxPOHeaderData.SuspendLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpxOrderTotals.SuspendLayout()
        Me.tabPOlineDetails.SuspendLayout()
        Me.POLineDetails.SuspendLayout()
        CType(Me.ItemClassBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GLLineDetails.SuspendLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLineDetails.SuspendLayout()
        CType(Me.PurchaseOrderLineQueryQOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPODetails.SuspendLayout()
        Me.tabPOLines.SuspendLayout()
        CType(Me.dgvPurchaseOrderLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOtherDetails.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabOrderTracking.SuspendLayout()
        CType(Me.dgvReturnTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorReturnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReceiverTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvROITable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.gpxVendorData.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPONumber
        '
        Me.lblPONumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPONumber.Location = New System.Drawing.Point(18, 26)
        Me.lblPONumber.Name = "lblPONumber"
        Me.lblPONumber.Size = New System.Drawing.Size(98, 20)
        Me.lblPONumber.TabIndex = 1
        Me.lblPONumber.Text = "PO #"
        Me.lblPONumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVendorName
        '
        Me.lblVendorName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendorName.Location = New System.Drawing.Point(18, 54)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(98, 20)
        Me.lblVendorName.TabIndex = 3
        Me.lblVendorName.Text = "Division ID"
        Me.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelPODate
        '
        Me.LabelPODate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPODate.Location = New System.Drawing.Point(21, 203)
        Me.LabelPODate.Name = "LabelPODate"
        Me.LabelPODate.Size = New System.Drawing.Size(98, 20)
        Me.LabelPODate.TabIndex = 5
        Me.LabelPODate.Text = "Date Issued"
        Me.LabelPODate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1059, 769)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 34
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxPOHeaderData
        '
        Me.gpxPOHeaderData.Controls.Add(Me.llVendorInfo)
        Me.gpxPOHeaderData.Controls.Add(Me.txtVendorName)
        Me.gpxPOHeaderData.Controls.Add(Me.dtpShipDatePicker)
        Me.gpxPOHeaderData.Controls.Add(Me.txtPOStatus)
        Me.gpxPOHeaderData.Controls.Add(Me.Label27)
        Me.gpxPOHeaderData.Controls.Add(Me.cboDivisionID)
        Me.gpxPOHeaderData.Controls.Add(Me.Label2)
        Me.gpxPOHeaderData.Controls.Add(Me.cboVendorCode)
        Me.gpxPOHeaderData.Controls.Add(Me.cmdGeneratePO)
        Me.gpxPOHeaderData.Controls.Add(Me.dtpPurchaseOrderDate)
        Me.gpxPOHeaderData.Controls.Add(Me.cboPurchaseOrderNumber)
        Me.gpxPOHeaderData.Controls.Add(Me.LabelPODate)
        Me.gpxPOHeaderData.Controls.Add(Me.lblPONumber)
        Me.gpxPOHeaderData.Controls.Add(Me.lblVendorName)
        Me.gpxPOHeaderData.Location = New System.Drawing.Point(29, 41)
        Me.gpxPOHeaderData.Name = "gpxPOHeaderData"
        Me.gpxPOHeaderData.Size = New System.Drawing.Size(313, 262)
        Me.gpxPOHeaderData.TabIndex = 0
        Me.gpxPOHeaderData.TabStop = False
        Me.gpxPOHeaderData.Text = "Purchase Order Header Data"
        '
        'llVendorInfo
        '
        Me.llVendorInfo.AutoSize = True
        Me.llVendorInfo.Location = New System.Drawing.Point(15, 88)
        Me.llVendorInfo.Name = "llVendorInfo"
        Me.llVendorInfo.Size = New System.Drawing.Size(69, 13)
        Me.llVendorInfo.TabIndex = 42
        Me.llVendorInfo.TabStop = True
        Me.llVendorInfo.Text = "Vendor Code"
        '
        'txtVendorName
        '
        Me.txtVendorName.BackColor = System.Drawing.Color.White
        Me.txtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorName.Location = New System.Drawing.Point(19, 115)
        Me.txtVendorName.Multiline = True
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(284, 49)
        Me.txtVendorName.TabIndex = 4
        Me.txtVendorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpShipDatePicker
        '
        Me.dtpShipDatePicker.CustomFormat = "dd/MM/yyyy"
        Me.dtpShipDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpShipDatePicker.Location = New System.Drawing.Point(99, 230)
        Me.dtpShipDatePicker.Name = "dtpShipDatePicker"
        Me.dtpShipDatePicker.Size = New System.Drawing.Size(201, 20)
        Me.dtpShipDatePicker.TabIndex = 7
        '
        'txtPOStatus
        '
        Me.txtPOStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPOStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPOStatus.Enabled = False
        Me.txtPOStatus.Location = New System.Drawing.Point(99, 173)
        Me.txtPOStatus.Name = "txtPOStatus"
        Me.txtPOStatus.Size = New System.Drawing.Size(204, 20)
        Me.txtPOStatus.TabIndex = 5
        Me.txtPOStatus.TabStop = False
        Me.txtPOStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(18, 175)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 20)
        Me.Label27.TabIndex = 41
        Me.Label27.Text = "PO Status"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(99, 55)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(204, 21)
        Me.cboDivisionID.TabIndex = 2
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
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 230)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Due Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVendorCode
        '
        Me.cboVendorCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVendorCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVendorCode.DataSource = Me.VendorBindingSource
        Me.cboVendorCode.DisplayMember = "VendorCode"
        Me.cboVendorCode.DropDownWidth = 250
        Me.cboVendorCode.FormattingEnabled = True
        Me.cboVendorCode.Location = New System.Drawing.Point(99, 85)
        Me.cboVendorCode.Name = "cboVendorCode"
        Me.cboVendorCode.Size = New System.Drawing.Size(204, 21)
        Me.cboVendorCode.TabIndex = 3
        '
        'VendorBindingSource
        '
        Me.VendorBindingSource.DataMember = "Vendor"
        Me.VendorBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdGeneratePO
        '
        Me.cmdGeneratePO.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGeneratePO.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGeneratePO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGeneratePO.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGeneratePO.Location = New System.Drawing.Point(67, 26)
        Me.cmdGeneratePO.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGeneratePO.Name = "cmdGeneratePO"
        Me.cmdGeneratePO.Size = New System.Drawing.Size(29, 20)
        Me.cmdGeneratePO.TabIndex = 0
        Me.cmdGeneratePO.Text = ">>"
        Me.cmdGeneratePO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGeneratePO.UseVisualStyleBackColor = False
        '
        'dtpPurchaseOrderDate
        '
        Me.dtpPurchaseOrderDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpPurchaseOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPurchaseOrderDate.Location = New System.Drawing.Point(99, 203)
        Me.dtpPurchaseOrderDate.Name = "dtpPurchaseOrderDate"
        Me.dtpPurchaseOrderDate.Size = New System.Drawing.Size(201, 20)
        Me.dtpPurchaseOrderDate.TabIndex = 6
        '
        'cboPurchaseOrderNumber
        '
        Me.cboPurchaseOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPurchaseOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPurchaseOrderNumber.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.cboPurchaseOrderNumber.DisplayMember = "PurchaseOrderHeaderKey"
        Me.cboPurchaseOrderNumber.FormattingEnabled = True
        Me.cboPurchaseOrderNumber.Location = New System.Drawing.Point(99, 26)
        Me.cboPurchaseOrderNumber.Name = "cboPurchaseOrderNumber"
        Me.cboPurchaseOrderNumber.Size = New System.Drawing.Size(204, 21)
        Me.cboPurchaseOrderNumber.TabIndex = 1
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboPaymentTerms
        '
        Me.cboPaymentTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPaymentTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPaymentTerms.DataSource = Me.PaymentTermsBindingSource
        Me.cboPaymentTerms.DisplayMember = "PmtTermsID"
        Me.cboPaymentTerms.FormattingEnabled = True
        Me.cboPaymentTerms.Location = New System.Drawing.Point(106, 20)
        Me.cboPaymentTerms.MaxLength = 50
        Me.cboPaymentTerms.Name = "cboPaymentTerms"
        Me.cboPaymentTerms.Size = New System.Drawing.Size(254, 21)
        Me.cboPaymentTerms.TabIndex = 19
        '
        'PaymentTermsBindingSource
        '
        Me.PaymentTermsBindingSource.DataMember = "PaymentTerms"
        Me.PaymentTermsBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblPaymentTerms
        '
        Me.lblPaymentTerms.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentTerms.Location = New System.Drawing.Point(15, 21)
        Me.lblPaymentTerms.Name = "lblPaymentTerms"
        Me.lblPaymentTerms.Size = New System.Drawing.Size(138, 20)
        Me.lblPaymentTerms.TabIndex = 7
        Me.lblPaymentTerms.Text = "Payment Terms"
        Me.lblPaymentTerms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipVia
        '
        Me.cboShipVia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipVia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(106, 49)
        Me.cboShipVia.MaxLength = 50
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(254, 21)
        Me.cboShipVia.TabIndex = 20
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblPOShipDate
        '
        Me.lblPOShipDate.Location = New System.Drawing.Point(16, 50)
        Me.lblPOShipDate.Name = "lblPOShipDate"
        Me.lblPOShipDate.Size = New System.Drawing.Size(138, 20)
        Me.lblPOShipDate.TabIndex = 5
        Me.lblPOShipDate.Text = "Ship Via"
        Me.lblPOShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(17, 106)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 20)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Comments"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPOComment
        '
        Me.txtPOComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPOComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPOComment.Location = New System.Drawing.Point(18, 129)
        Me.txtPOComment.MaxLength = 500
        Me.txtPOComment.Multiline = True
        Me.txtPOComment.Name = "txtPOComment"
        Me.txtPOComment.Size = New System.Drawing.Size(342, 112)
        Me.txtPOComment.TabIndex = 22
        Me.txtPOComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightCharges
        '
        Me.txtFreightCharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightCharges.Location = New System.Drawing.Point(217, 75)
        Me.txtFreightCharges.Name = "txtFreightCharges"
        Me.txtFreightCharges.Size = New System.Drawing.Size(152, 20)
        Me.txtFreightCharges.TabIndex = 24
        Me.txtFreightCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCustomerDSAddress1
        '
        Me.txtCustomerDSAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerDSAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerDSAddress1.Location = New System.Drawing.Point(17, 142)
        Me.txtCustomerDSAddress1.Multiline = True
        Me.txtCustomerDSAddress1.Name = "txtCustomerDSAddress1"
        Me.txtCustomerDSAddress1.Size = New System.Drawing.Size(351, 90)
        Me.txtCustomerDSAddress1.TabIndex = 39
        Me.txtCustomerDSAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Customer"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintPO
        '
        Me.cmdPrintPO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintPO.Location = New System.Drawing.Point(982, 769)
        Me.cmdPrintPO.Name = "cmdPrintPO"
        Me.cmdPrintPO.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintPO.TabIndex = 33
        Me.cmdPrintPO.Text = "Print PO"
        Me.cmdPrintPO.UseVisualStyleBackColor = True
        '
        'cboPartDescription
        '
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 350
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(15, 74)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(279, 21)
        Me.cboPartDescription.TabIndex = 9
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
        Me.cboPartNumber.DropDownWidth = 250
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(60, 44)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(234, 21)
        Me.cboPartNumber.TabIndex = 8
        '
        'lblLastPurchaseCost
        '
        Me.lblLastPurchaseCost.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblLastPurchaseCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLastPurchaseCost.Location = New System.Drawing.Point(135, 343)
        Me.lblLastPurchaseCost.Name = "lblLastPurchaseCost"
        Me.lblLastPurchaseCost.Size = New System.Drawing.Size(157, 20)
        Me.lblLastPurchaseCost.TabIndex = 13
        Me.lblLastPurchaseCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLongDescription.Location = New System.Drawing.Point(15, 104)
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.Size = New System.Drawing.Size(279, 42)
        Me.txtLongDescription.TabIndex = 8
        Me.txtLongDescription.TabStop = False
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkInventoryItem
        '
        Me.chkInventoryItem.AutoSize = True
        Me.chkInventoryItem.Checked = True
        Me.chkInventoryItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInventoryItem.Location = New System.Drawing.Point(60, 21)
        Me.chkInventoryItem.Name = "chkInventoryItem"
        Me.chkInventoryItem.Size = New System.Drawing.Size(93, 17)
        Me.chkInventoryItem.TabIndex = 7
        Me.chkInventoryItem.TabStop = False
        Me.chkInventoryItem.Text = "Inventory Item"
        Me.chkInventoryItem.UseVisualStyleBackColor = True
        '
        'lblAmount
        '
        Me.lblAmount.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAmount.Location = New System.Drawing.Point(135, 402)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(157, 20)
        Me.lblAmount.TabIndex = 15
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAddItem
        '
        Me.cmdAddItem.Location = New System.Drawing.Point(135, 435)
        Me.cmdAddItem.Name = "cmdAddItem"
        Me.cmdAddItem.Size = New System.Drawing.Size(75, 35)
        Me.cmdAddItem.TabIndex = 16
        Me.cmdAddItem.Text = "Add"
        Me.cmdAddItem.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(217, 434)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 35)
        Me.cmdClear.TabIndex = 17
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 403)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(139, 20)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Amount"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 373)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(139, 20)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Unit Cost"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 314)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 20)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Order Quantity"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitCost.Location = New System.Drawing.Point(135, 373)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(157, 20)
        Me.txtUnitCost.TabIndex = 14
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOrderQuantity
        '
        Me.txtOrderQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrderQuantity.Location = New System.Drawing.Point(135, 314)
        Me.txtOrderQuantity.Name = "txtOrderQuantity"
        Me.txtOrderQuantity.Size = New System.Drawing.Size(157, 20)
        Me.txtOrderQuantity.TabIndex = 12
        Me.txtOrderQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 20)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Part #"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerDSAddress2
        '
        Me.txtCustomerDSAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerDSAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerDSAddress2.Location = New System.Drawing.Point(17, 259)
        Me.txtCustomerDSAddress2.Multiline = True
        Me.txtCustomerDSAddress2.Name = "txtCustomerDSAddress2"
        Me.txtCustomerDSAddress2.Size = New System.Drawing.Size(351, 90)
        Me.txtCustomerDSAddress2.TabIndex = 40
        Me.txtCustomerDSAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCustomerDSZip
        '
        Me.txtCustomerDSZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerDSZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerDSZip.Location = New System.Drawing.Point(233, 405)
        Me.txtCustomerDSZip.Name = "txtCustomerDSZip"
        Me.txtCustomerDSZip.Size = New System.Drawing.Size(135, 20)
        Me.txtCustomerDSZip.TabIndex = 43
        Me.txtCustomerDSZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCustomerDSCity
        '
        Me.txtCustomerDSCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerDSCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerDSCity.Location = New System.Drawing.Point(63, 366)
        Me.txtCustomerDSCity.Name = "txtCustomerDSCity"
        Me.txtCustomerDSCity.Size = New System.Drawing.Size(305, 20)
        Me.txtCustomerDSCity.TabIndex = 41
        Me.txtCustomerDSCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboCustomerDSName
        '
        Me.cboCustomerDSName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerDSName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerDSName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerDSName.DisplayMember = "CustomerID"
        Me.cboCustomerDSName.DropDownWidth = 300
        Me.cboCustomerDSName.FormattingEnabled = True
        Me.cboCustomerDSName.Location = New System.Drawing.Point(104, 27)
        Me.cboCustomerDSName.Name = "cboCustomerDSName"
        Me.cboCustomerDSName.Size = New System.Drawing.Size(264, 21)
        Me.cboCustomerDSName.TabIndex = 37
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 20)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Address 1"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 20)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Address 2"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 364)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 20)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "City"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(17, 405)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "State"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(196, 406)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 18)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "ZIP"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClosePurchaseOrderToolStripMenuItem, Me.SavePurchaseOrderToolStripMenuItem, Me.PrintPurchaseOrderToolStripMenuItem, Me.ReIssuePurchaseOrderToolStripMenuItem, Me.ReOpenPurchaseOrderToolStripMenuItem, Me.DeletePurchaseOrderToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClosePurchaseOrderToolStripMenuItem
        '
        Me.ClosePurchaseOrderToolStripMenuItem.Name = "ClosePurchaseOrderToolStripMenuItem"
        Me.ClosePurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ClosePurchaseOrderToolStripMenuItem.Text = "Close Purchase Order"
        '
        'SavePurchaseOrderToolStripMenuItem
        '
        Me.SavePurchaseOrderToolStripMenuItem.Name = "SavePurchaseOrderToolStripMenuItem"
        Me.SavePurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SavePurchaseOrderToolStripMenuItem.Text = "Save Purchase Order"
        '
        'PrintPurchaseOrderToolStripMenuItem
        '
        Me.PrintPurchaseOrderToolStripMenuItem.Name = "PrintPurchaseOrderToolStripMenuItem"
        Me.PrintPurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.PrintPurchaseOrderToolStripMenuItem.Text = "Print Purchase Order"
        '
        'ReIssuePurchaseOrderToolStripMenuItem
        '
        Me.ReIssuePurchaseOrderToolStripMenuItem.Name = "ReIssuePurchaseOrderToolStripMenuItem"
        Me.ReIssuePurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ReIssuePurchaseOrderToolStripMenuItem.Text = "Re-Issue Purchase Order"
        '
        'ReOpenPurchaseOrderToolStripMenuItem
        '
        Me.ReOpenPurchaseOrderToolStripMenuItem.Name = "ReOpenPurchaseOrderToolStripMenuItem"
        Me.ReOpenPurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ReOpenPurchaseOrderToolStripMenuItem.Text = "Re-Open Purchase Order"
        '
        'DeletePurchaseOrderToolStripMenuItem
        '
        Me.DeletePurchaseOrderToolStripMenuItem.Name = "DeletePurchaseOrderToolStripMenuItem"
        Me.DeletePurchaseOrderToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.DeletePurchaseOrderToolStripMenuItem.Text = "Delete Purchase Order"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManuallyClosePOToolStripMenuItem, Me.ManuallyOpenPOToolStripMenuItem, Me.UnLockPurchaseORderToolStripMenuItem, Me.ViewQuoteToolStripMenuItem, Me.UploadQuoteToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ManuallyClosePOToolStripMenuItem
        '
        Me.ManuallyClosePOToolStripMenuItem.Name = "ManuallyClosePOToolStripMenuItem"
        Me.ManuallyClosePOToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ManuallyClosePOToolStripMenuItem.Text = "Manually Close PO"
        '
        'ManuallyOpenPOToolStripMenuItem
        '
        Me.ManuallyOpenPOToolStripMenuItem.Name = "ManuallyOpenPOToolStripMenuItem"
        Me.ManuallyOpenPOToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ManuallyOpenPOToolStripMenuItem.Text = "Manually Open PO"
        '
        'UnLockPurchaseORderToolStripMenuItem
        '
        Me.UnLockPurchaseORderToolStripMenuItem.Name = "UnLockPurchaseORderToolStripMenuItem"
        Me.UnLockPurchaseORderToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.UnLockPurchaseORderToolStripMenuItem.Text = "Un-Lock Purchase Order"
        '
        'ViewQuoteToolStripMenuItem
        '
        Me.ViewQuoteToolStripMenuItem.Name = "ViewQuoteToolStripMenuItem"
        Me.ViewQuoteToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ViewQuoteToolStripMenuItem.Text = "View Quote"
        '
        'UploadQuoteToolStripMenuItem
        '
        Me.UploadQuoteToolStripMenuItem.Name = "UploadQuoteToolStripMenuItem"
        Me.UploadQuoteToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.UploadQuoteToolStripMenuItem.Text = "Upload Quote"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewOpenPOsToolStripMenuItem, Me.ViewClosedPOsToolStripMenuItem, Me.PrintPOPackListToolStripMenuItem, Me.PrintReceiversToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ViewOpenPOsToolStripMenuItem
        '
        Me.ViewOpenPOsToolStripMenuItem.Name = "ViewOpenPOsToolStripMenuItem"
        Me.ViewOpenPOsToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ViewOpenPOsToolStripMenuItem.Text = "View Open PO's"
        '
        'ViewClosedPOsToolStripMenuItem
        '
        Me.ViewClosedPOsToolStripMenuItem.Name = "ViewClosedPOsToolStripMenuItem"
        Me.ViewClosedPOsToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ViewClosedPOsToolStripMenuItem.Text = "View Closed PO's"
        '
        'PrintPOPackListToolStripMenuItem
        '
        Me.PrintPOPackListToolStripMenuItem.Name = "PrintPOPackListToolStripMenuItem"
        Me.PrintPOPackListToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.PrintPOPackListToolStripMenuItem.Text = "Print PO Pack List"
        '
        'PrintReceiversToolStripMenuItem
        '
        Me.PrintReceiversToolStripMenuItem.Name = "PrintReceiversToolStripMenuItem"
        Me.PrintReceiversToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.PrintReceiversToolStripMenuItem.Text = "Print Receivers"
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
        'txtCustomerCountry
        '
        Me.txtCustomerCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerCountry.Location = New System.Drawing.Point(63, 444)
        Me.txtCustomerCountry.Name = "txtCustomerCountry"
        Me.txtCustomerCountry.Size = New System.Drawing.Size(305, 20)
        Me.txtCustomerCountry.TabIndex = 44
        Me.txtCustomerCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(17, 443)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(116, 20)
        Me.Label26.TabIndex = 24
        Me.Label26.Text = "Country"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDropShip
        '
        Me.chkDropShip.AutoSize = True
        Me.chkDropShip.Location = New System.Drawing.Point(34, 18)
        Me.chkDropShip.Name = "chkDropShip"
        Me.chkDropShip.Size = New System.Drawing.Size(73, 17)
        Me.chkDropShip.TabIndex = 35
        Me.chkDropShip.Text = "Drop Ship"
        Me.chkDropShip.UseVisualStyleBackColor = True
        '
        'cboDropShipState
        '
        Me.cboDropShipState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDropShipState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDropShipState.DataSource = Me.StateTableBindingSource
        Me.cboDropShipState.DisplayMember = "StateCode"
        Me.cboDropShipState.FormattingEnabled = True
        Me.cboDropShipState.Location = New System.Drawing.Point(63, 405)
        Me.cboDropShipState.Name = "cboDropShipState"
        Me.cboDropShipState.Size = New System.Drawing.Size(106, 21)
        Me.cboDropShipState.TabIndex = 42
        '
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cmdSavePO
        '
        Me.cmdSavePO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSavePO.Location = New System.Drawing.Point(828, 769)
        Me.cmdSavePO.Name = "cmdSavePO"
        Me.cmdSavePO.Size = New System.Drawing.Size(71, 40)
        Me.cmdSavePO.TabIndex = 31
        Me.cmdSavePO.Text = "Save PO"
        Me.cmdSavePO.UseVisualStyleBackColor = True
        '
        'cmdDeletePO
        '
        Me.cmdDeletePO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeletePO.Location = New System.Drawing.Point(905, 769)
        Me.cmdDeletePO.Name = "cmdDeletePO"
        Me.cmdDeletePO.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeletePO.TabIndex = 32
        Me.cmdDeletePO.Text = "Delete PO"
        Me.cmdDeletePO.UseVisualStyleBackColor = True
        '
        'gpxOrderTotals
        '
        Me.gpxOrderTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxOrderTotals.Controls.Add(Me.lblOpen)
        Me.gpxOrderTotals.Controls.Add(Me.lblOpenWeight)
        Me.gpxOrderTotals.Controls.Add(Me.lblEstWeight)
        Me.gpxOrderTotals.Controls.Add(Me.Label43)
        Me.gpxOrderTotals.Controls.Add(Me.txtFreightCharges)
        Me.gpxOrderTotals.Controls.Add(Me.txtSalesTax)
        Me.gpxOrderTotals.Controls.Add(Me.lblOrderTotal)
        Me.gpxOrderTotals.Controls.Add(Me.lblPurchaseTotal)
        Me.gpxOrderTotals.Controls.Add(Me.Label73)
        Me.gpxOrderTotals.Controls.Add(Me.Label74)
        Me.gpxOrderTotals.Controls.Add(Me.Label75)
        Me.gpxOrderTotals.Controls.Add(Me.Label76)
        Me.gpxOrderTotals.Location = New System.Drawing.Point(751, 556)
        Me.gpxOrderTotals.Name = "gpxOrderTotals"
        Me.gpxOrderTotals.Size = New System.Drawing.Size(379, 162)
        Me.gpxOrderTotals.TabIndex = 22
        Me.gpxOrderTotals.TabStop = False
        Me.gpxOrderTotals.Text = "Order Totals"
        '
        'lblOpenWeight
        '
        Me.lblOpenWeight.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblOpenWeight.ForeColor = System.Drawing.Color.Blue
        Me.lblOpenWeight.Location = New System.Drawing.Point(104, 19)
        Me.lblOpenWeight.Name = "lblOpenWeight"
        Me.lblOpenWeight.Size = New System.Drawing.Size(59, 21)
        Me.lblOpenWeight.TabIndex = 79
        Me.lblOpenWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstWeight
        '
        Me.lblEstWeight.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblEstWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstWeight.Location = New System.Drawing.Point(217, 19)
        Me.lblEstWeight.Name = "lblEstWeight"
        Me.lblEstWeight.Size = New System.Drawing.Size(152, 21)
        Me.lblEstWeight.TabIndex = 77
        Me.lblEstWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(13, 19)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(144, 21)
        Me.Label43.TabIndex = 78
        Me.Label43.Text = "Est. Weight"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesTax
        '
        Me.txtSalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesTax.Location = New System.Drawing.Point(217, 102)
        Me.txtSalesTax.Name = "txtSalesTax"
        Me.txtSalesTax.Size = New System.Drawing.Size(152, 20)
        Me.txtSalesTax.TabIndex = 25
        Me.txtSalesTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOrderTotal
        '
        Me.lblOrderTotal.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblOrderTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderTotal.Location = New System.Drawing.Point(217, 129)
        Me.lblOrderTotal.Name = "lblOrderTotal"
        Me.lblOrderTotal.Size = New System.Drawing.Size(152, 21)
        Me.lblOrderTotal.TabIndex = 26
        Me.lblOrderTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPurchaseTotal
        '
        Me.lblPurchaseTotal.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblPurchaseTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPurchaseTotal.Location = New System.Drawing.Point(217, 47)
        Me.lblPurchaseTotal.Name = "lblPurchaseTotal"
        Me.lblPurchaseTotal.Size = New System.Drawing.Size(152, 21)
        Me.lblPurchaseTotal.TabIndex = 23
        Me.lblPurchaseTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label73
        '
        Me.Label73.Location = New System.Drawing.Point(13, 101)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(144, 21)
        Me.Label73.TabIndex = 76
        Me.Label73.Text = "Sales Tax"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label74
        '
        Me.Label74.Location = New System.Drawing.Point(13, 131)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(144, 21)
        Me.Label74.TabIndex = 75
        Me.Label74.Text = "Order Total"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label75
        '
        Me.Label75.Location = New System.Drawing.Point(13, 73)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(144, 21)
        Me.Label75.TabIndex = 74
        Me.Label75.Text = "Freight Charges"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label76
        '
        Me.Label76.Location = New System.Drawing.Point(13, 46)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(144, 21)
        Me.Label76.TabIndex = 73
        Me.Label76.Text = "Purchase Total"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPurchaseHistory
        '
        Me.cmdPurchaseHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPurchaseHistory.Location = New System.Drawing.Point(905, 724)
        Me.cmdPurchaseHistory.Name = "cmdPurchaseHistory"
        Me.cmdPurchaseHistory.Size = New System.Drawing.Size(71, 40)
        Me.cmdPurchaseHistory.TabIndex = 28
        Me.cmdPurchaseHistory.Text = "Purchase History"
        Me.cmdPurchaseHistory.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Location = New System.Drawing.Point(828, 724)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 27
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdVendorForm
        '
        Me.cmdVendorForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVendorForm.Location = New System.Drawing.Point(982, 724)
        Me.cmdVendorForm.Name = "cmdVendorForm"
        Me.cmdVendorForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdVendorForm.TabIndex = 29
        Me.cmdVendorForm.Text = "Vendor Info"
        Me.cmdVendorForm.UseVisualStyleBackColor = True
        '
        'cmdReissuePO
        '
        Me.cmdReissuePO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReissuePO.Location = New System.Drawing.Point(1059, 724)
        Me.cmdReissuePO.Name = "cmdReissuePO"
        Me.cmdReissuePO.Size = New System.Drawing.Size(71, 40)
        Me.cmdReissuePO.TabIndex = 30
        Me.cmdReissuePO.Text = "Reissue PO"
        Me.cmdReissuePO.UseVisualStyleBackColor = True
        '
        'tabPOlineDetails
        '
        Me.tabPOlineDetails.Controls.Add(Me.POLineDetails)
        Me.tabPOlineDetails.Controls.Add(Me.GLLineDetails)
        Me.tabPOlineDetails.Controls.Add(Me.tabLineDetails)
        Me.tabPOlineDetails.Location = New System.Drawing.Point(29, 309)
        Me.tabPOlineDetails.Name = "tabPOlineDetails"
        Me.tabPOlineDetails.SelectedIndex = 0
        Me.tabPOlineDetails.Size = New System.Drawing.Size(313, 502)
        Me.tabPOlineDetails.TabIndex = 7
        '
        'POLineDetails
        '
        Me.POLineDetails.Controls.Add(Me.lstPartDescriptionSuggest)
        Me.POLineDetails.Controls.Add(Me.lstLinePartDescriptionSuggest)
        Me.POLineDetails.Controls.Add(Me.lblBoxCount)
        Me.POLineDetails.Controls.Add(Me.lblPalletCount)
        Me.POLineDetails.Controls.Add(Me.llLastPurchaseCost)
        Me.POLineDetails.Controls.Add(Me.llOrderQuantity)
        Me.POLineDetails.Controls.Add(Me.Label10)
        Me.POLineDetails.Controls.Add(Me.cboNewItemClass)
        Me.POLineDetails.Controls.Add(Me.lblItemClassNew)
        Me.POLineDetails.Controls.Add(Me.txtLineComment)
        Me.POLineDetails.Controls.Add(Me.cboPartDescription)
        Me.POLineDetails.Controls.Add(Me.chkInventoryItem)
        Me.POLineDetails.Controls.Add(Me.cboPartNumber)
        Me.POLineDetails.Controls.Add(Me.Label9)
        Me.POLineDetails.Controls.Add(Me.txtOrderQuantity)
        Me.POLineDetails.Controls.Add(Me.lblLastPurchaseCost)
        Me.POLineDetails.Controls.Add(Me.txtUnitCost)
        Me.POLineDetails.Controls.Add(Me.txtLongDescription)
        Me.POLineDetails.Controls.Add(Me.lblAmount)
        Me.POLineDetails.Controls.Add(Me.cmdAddItem)
        Me.POLineDetails.Controls.Add(Me.cmdClear)
        Me.POLineDetails.Controls.Add(Me.Label12)
        Me.POLineDetails.Controls.Add(Me.Label13)
        Me.POLineDetails.Location = New System.Drawing.Point(4, 22)
        Me.POLineDetails.Name = "POLineDetails"
        Me.POLineDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.POLineDetails.Size = New System.Drawing.Size(305, 476)
        Me.POLineDetails.TabIndex = 0
        Me.POLineDetails.Text = "Add New Line"
        Me.POLineDetails.UseVisualStyleBackColor = True
        '
        'lstPartDescriptionSuggest
        '
        Me.lstPartDescriptionSuggest.FormattingEnabled = True
        Me.lstPartDescriptionSuggest.Location = New System.Drawing.Point(13, 95)
        Me.lstPartDescriptionSuggest.Name = "lstPartDescriptionSuggest"
        Me.lstPartDescriptionSuggest.Size = New System.Drawing.Size(120, 95)
        Me.lstPartDescriptionSuggest.TabIndex = 35
        Me.lstPartDescriptionSuggest.Visible = False
        '
        'lstLinePartDescriptionSuggest
        '
        Me.lstLinePartDescriptionSuggest.FormattingEnabled = True
        Me.lstLinePartDescriptionSuggest.Location = New System.Drawing.Point(13, 95)
        Me.lstLinePartDescriptionSuggest.Name = "lstLinePartDescriptionSuggest"
        Me.lstLinePartDescriptionSuggest.Size = New System.Drawing.Size(120, 95)
        Me.lstLinePartDescriptionSuggest.TabIndex = 36
        Me.lstLinePartDescriptionSuggest.Visible = False
        '
        'lblBoxCount
        '
        Me.lblBoxCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxCount.ForeColor = System.Drawing.Color.Red
        Me.lblBoxCount.Location = New System.Drawing.Point(13, 429)
        Me.lblBoxCount.Name = "lblBoxCount"
        Me.lblBoxCount.Size = New System.Drawing.Size(112, 20)
        Me.lblBoxCount.TabIndex = 63
        Me.lblBoxCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPalletCount
        '
        Me.lblPalletCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalletCount.ForeColor = System.Drawing.Color.Red
        Me.lblPalletCount.Location = New System.Drawing.Point(13, 449)
        Me.lblPalletCount.Name = "lblPalletCount"
        Me.lblPalletCount.Size = New System.Drawing.Size(112, 20)
        Me.lblPalletCount.TabIndex = 62
        Me.lblPalletCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'llLastPurchaseCost
        '
        Me.llLastPurchaseCost.Location = New System.Drawing.Point(14, 343)
        Me.llLastPurchaseCost.Name = "llLastPurchaseCost"
        Me.llLastPurchaseCost.Size = New System.Drawing.Size(100, 23)
        Me.llLastPurchaseCost.TabIndex = 61
        Me.llLastPurchaseCost.TabStop = True
        Me.llLastPurchaseCost.Text = "Last Purchase Cost"
        Me.llLastPurchaseCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'llOrderQuantity
        '
        Me.llOrderQuantity.Location = New System.Drawing.Point(14, 314)
        Me.llOrderQuantity.Name = "llOrderQuantity"
        Me.llOrderQuantity.Size = New System.Drawing.Size(100, 20)
        Me.llOrderQuantity.TabIndex = 58
        Me.llOrderQuantity.TabStop = True
        Me.llOrderQuantity.Text = "Order Quantity"
        Me.llOrderQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 198)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(171, 20)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Line Comment (500 Characters)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNewItemClass
        '
        Me.cboNewItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNewItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNewItemClass.DataSource = Me.ItemClassBindingSource1
        Me.cboNewItemClass.DisplayMember = "ItemClassID"
        Me.cboNewItemClass.FormattingEnabled = True
        Me.cboNewItemClass.Location = New System.Drawing.Point(98, 161)
        Me.cboNewItemClass.Name = "cboNewItemClass"
        Me.cboNewItemClass.Size = New System.Drawing.Size(196, 21)
        Me.cboNewItemClass.TabIndex = 10
        '
        'ItemClassBindingSource1
        '
        Me.ItemClassBindingSource1.DataMember = "ItemClass"
        Me.ItemClassBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'lblItemClassNew
        '
        Me.lblItemClassNew.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemClassNew.Location = New System.Drawing.Point(15, 161)
        Me.lblItemClassNew.Name = "lblItemClassNew"
        Me.lblItemClassNew.Size = New System.Drawing.Size(78, 20)
        Me.lblItemClassNew.TabIndex = 59
        Me.lblItemClassNew.Text = "Item Class"
        Me.lblItemClassNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineComment
        '
        Me.txtLineComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineComment.Location = New System.Drawing.Point(15, 221)
        Me.txtLineComment.MaxLength = 500
        Me.txtLineComment.Multiline = True
        Me.txtLineComment.Name = "txtLineComment"
        Me.txtLineComment.Size = New System.Drawing.Size(277, 77)
        Me.txtLineComment.TabIndex = 11
        Me.txtLineComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GLLineDetails
        '
        Me.GLLineDetails.Controls.Add(Me.txtIssuesAccount)
        Me.GLLineDetails.Controls.Add(Me.txtAdjustmentAccount)
        Me.GLLineDetails.Controls.Add(Me.txtSalesOffsetAccount)
        Me.GLLineDetails.Controls.Add(Me.txtPurchaseAccount)
        Me.GLLineDetails.Controls.Add(Me.txtCOGSAccount)
        Me.GLLineDetails.Controls.Add(Me.txtInventoryAccount)
        Me.GLLineDetails.Controls.Add(Me.txtReturnsAccount)
        Me.GLLineDetails.Controls.Add(Me.txtSalesAccount)
        Me.GLLineDetails.Controls.Add(Me.cboItemClass)
        Me.GLLineDetails.Controls.Add(Me.Label24)
        Me.GLLineDetails.Controls.Add(Me.Label25)
        Me.GLLineDetails.Controls.Add(Me.Label23)
        Me.GLLineDetails.Controls.Add(Me.Label22)
        Me.GLLineDetails.Controls.Add(Me.Label21)
        Me.GLLineDetails.Controls.Add(Me.Label20)
        Me.GLLineDetails.Controls.Add(Me.Label19)
        Me.GLLineDetails.Controls.Add(Me.Label18)
        Me.GLLineDetails.Controls.Add(Me.Label16)
        Me.GLLineDetails.Location = New System.Drawing.Point(4, 22)
        Me.GLLineDetails.Name = "GLLineDetails"
        Me.GLLineDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.GLLineDetails.Size = New System.Drawing.Size(305, 476)
        Me.GLLineDetails.TabIndex = 1
        Me.GLLineDetails.Text = "GL Line Details"
        Me.GLLineDetails.UseVisualStyleBackColor = True
        '
        'txtIssuesAccount
        '
        Me.txtIssuesAccount.BackColor = System.Drawing.Color.White
        Me.txtIssuesAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIssuesAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIssuesAccount.Enabled = False
        Me.txtIssuesAccount.Location = New System.Drawing.Point(123, 259)
        Me.txtIssuesAccount.Name = "txtIssuesAccount"
        Me.txtIssuesAccount.ReadOnly = True
        Me.txtIssuesAccount.Size = New System.Drawing.Size(170, 20)
        Me.txtIssuesAccount.TabIndex = 25
        Me.txtIssuesAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdjustmentAccount
        '
        Me.txtAdjustmentAccount.BackColor = System.Drawing.Color.White
        Me.txtAdjustmentAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdjustmentAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAdjustmentAccount.Enabled = False
        Me.txtAdjustmentAccount.Location = New System.Drawing.Point(123, 230)
        Me.txtAdjustmentAccount.Name = "txtAdjustmentAccount"
        Me.txtAdjustmentAccount.ReadOnly = True
        Me.txtAdjustmentAccount.Size = New System.Drawing.Size(170, 20)
        Me.txtAdjustmentAccount.TabIndex = 24
        Me.txtAdjustmentAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalesOffsetAccount
        '
        Me.txtSalesOffsetAccount.BackColor = System.Drawing.Color.White
        Me.txtSalesOffsetAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesOffsetAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesOffsetAccount.Enabled = False
        Me.txtSalesOffsetAccount.Location = New System.Drawing.Point(123, 201)
        Me.txtSalesOffsetAccount.Name = "txtSalesOffsetAccount"
        Me.txtSalesOffsetAccount.ReadOnly = True
        Me.txtSalesOffsetAccount.Size = New System.Drawing.Size(170, 20)
        Me.txtSalesOffsetAccount.TabIndex = 23
        Me.txtSalesOffsetAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPurchaseAccount
        '
        Me.txtPurchaseAccount.BackColor = System.Drawing.Color.White
        Me.txtPurchaseAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPurchaseAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPurchaseAccount.Enabled = False
        Me.txtPurchaseAccount.Location = New System.Drawing.Point(123, 172)
        Me.txtPurchaseAccount.Name = "txtPurchaseAccount"
        Me.txtPurchaseAccount.ReadOnly = True
        Me.txtPurchaseAccount.Size = New System.Drawing.Size(170, 20)
        Me.txtPurchaseAccount.TabIndex = 22
        Me.txtPurchaseAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCOGSAccount
        '
        Me.txtCOGSAccount.BackColor = System.Drawing.Color.White
        Me.txtCOGSAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCOGSAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCOGSAccount.Enabled = False
        Me.txtCOGSAccount.Location = New System.Drawing.Point(123, 143)
        Me.txtCOGSAccount.Name = "txtCOGSAccount"
        Me.txtCOGSAccount.ReadOnly = True
        Me.txtCOGSAccount.Size = New System.Drawing.Size(170, 20)
        Me.txtCOGSAccount.TabIndex = 21
        Me.txtCOGSAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInventoryAccount
        '
        Me.txtInventoryAccount.BackColor = System.Drawing.Color.White
        Me.txtInventoryAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoryAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInventoryAccount.Enabled = False
        Me.txtInventoryAccount.Location = New System.Drawing.Point(123, 114)
        Me.txtInventoryAccount.Name = "txtInventoryAccount"
        Me.txtInventoryAccount.ReadOnly = True
        Me.txtInventoryAccount.Size = New System.Drawing.Size(170, 20)
        Me.txtInventoryAccount.TabIndex = 20
        Me.txtInventoryAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReturnsAccount
        '
        Me.txtReturnsAccount.BackColor = System.Drawing.Color.White
        Me.txtReturnsAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnsAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReturnsAccount.Enabled = False
        Me.txtReturnsAccount.Location = New System.Drawing.Point(123, 85)
        Me.txtReturnsAccount.Name = "txtReturnsAccount"
        Me.txtReturnsAccount.ReadOnly = True
        Me.txtReturnsAccount.Size = New System.Drawing.Size(170, 20)
        Me.txtReturnsAccount.TabIndex = 19
        Me.txtReturnsAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSalesAccount
        '
        Me.txtSalesAccount.BackColor = System.Drawing.Color.White
        Me.txtSalesAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesAccount.Enabled = False
        Me.txtSalesAccount.Location = New System.Drawing.Point(123, 56)
        Me.txtSalesAccount.Name = "txtSalesAccount"
        Me.txtSalesAccount.ReadOnly = True
        Me.txtSalesAccount.Size = New System.Drawing.Size(170, 20)
        Me.txtSalesAccount.TabIndex = 18
        Me.txtSalesAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboItemClass
        '
        Me.cboItemClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemClass.DataSource = Me.ItemClassBindingSource
        Me.cboItemClass.DisplayMember = "ItemClassID"
        Me.cboItemClass.DropDownWidth = 200
        Me.cboItemClass.Enabled = False
        Me.cboItemClass.FormattingEnabled = True
        Me.cboItemClass.Location = New System.Drawing.Point(123, 18)
        Me.cboItemClass.Name = "cboItemClass"
        Me.cboItemClass.Size = New System.Drawing.Size(170, 21)
        Me.cboItemClass.TabIndex = 17
        '
        'ItemClassBindingSource
        '
        Me.ItemClassBindingSource.DataMember = "ItemClass"
        Me.ItemClassBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(12, 258)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 20)
        Me.Label24.TabIndex = 21
        Me.Label24.Text = "Issues Account"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(12, 229)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(112, 20)
        Me.Label25.TabIndex = 20
        Me.Label25.Text = "Adjustment Account"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(12, 200)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 20)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "Sales Offset Account"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(12, 172)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 20)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Purchases Account"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(12, 142)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 20)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "COGS Account"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(12, 113)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(112, 20)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "Inventory Account"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(12, 84)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 20)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Return Account"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(12, 55)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 20)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Sales Account"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(12, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 20)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Item Class"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabLineDetails
        '
        Me.tabLineDetails.Controls.Add(Me.Label35)
        Me.tabLineDetails.Controls.Add(Me.txtLineComment2)
        Me.tabLineDetails.Controls.Add(Me.cmdDeleteLine)
        Me.tabLineDetails.Controls.Add(Me.txtLineGLCredit)
        Me.tabLineDetails.Controls.Add(Me.cmdSaveLine)
        Me.tabLineDetails.Controls.Add(Me.Label28)
        Me.tabLineDetails.Controls.Add(Me.cboLineNumber)
        Me.tabLineDetails.Controls.Add(Me.txtLineGLDebit)
        Me.tabLineDetails.Controls.Add(Me.cboLinePartNumber)
        Me.tabLineDetails.Controls.Add(Me.Label30)
        Me.tabLineDetails.Controls.Add(Me.cboLineDescription)
        Me.tabLineDetails.Controls.Add(Me.txtLineUnitCost)
        Me.tabLineDetails.Controls.Add(Me.txtLineExtendedCost)
        Me.tabLineDetails.Controls.Add(Me.Label11)
        Me.tabLineDetails.Controls.Add(Me.txtLineOrderQuantity)
        Me.tabLineDetails.Controls.Add(Me.Label34)
        Me.tabLineDetails.Controls.Add(Me.Label36)
        Me.tabLineDetails.Controls.Add(Me.Label32)
        Me.tabLineDetails.Controls.Add(Me.Label29)
        Me.tabLineDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabLineDetails.Name = "tabLineDetails"
        Me.tabLineDetails.Size = New System.Drawing.Size(305, 476)
        Me.tabLineDetails.TabIndex = 2
        Me.tabLineDetails.Text = "Line Details"
        Me.tabLineDetails.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(13, 116)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(280, 20)
        Me.Label35.TabIndex = 57
        Me.Label35.Text = "Line Comment / Description (500 Characters)"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineComment2
        '
        Me.txtLineComment2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineComment2.Location = New System.Drawing.Point(12, 139)
        Me.txtLineComment2.MaxLength = 500
        Me.txtLineComment2.Multiline = True
        Me.txtLineComment2.Name = "txtLineComment2"
        Me.txtLineComment2.Size = New System.Drawing.Size(280, 129)
        Me.txtLineComment2.TabIndex = 57
        Me.txtLineComment2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Location = New System.Drawing.Point(221, 434)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteLine.TabIndex = 45
        Me.cmdDeleteLine.Text = "Delete Line"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'txtLineGLCredit
        '
        Me.txtLineGLCredit.BackColor = System.Drawing.Color.White
        Me.txtLineGLCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineGLCredit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineGLCredit.Enabled = False
        Me.txtLineGLCredit.Location = New System.Drawing.Point(144, 400)
        Me.txtLineGLCredit.Name = "txtLineGLCredit"
        Me.txtLineGLCredit.ReadOnly = True
        Me.txtLineGLCredit.Size = New System.Drawing.Size(147, 20)
        Me.txtLineGLCredit.TabIndex = 43
        Me.txtLineGLCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdSaveLine
        '
        Me.cmdSaveLine.Location = New System.Drawing.Point(144, 434)
        Me.cmdSaveLine.Name = "cmdSaveLine"
        Me.cmdSaveLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdSaveLine.TabIndex = 44
        Me.cmdSaveLine.Text = "Save Line"
        Me.cmdSaveLine.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(13, 18)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(117, 20)
        Me.Label28.TabIndex = 25
        Me.Label28.Text = "Purchase Order Line #"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLineNumber
        '
        Me.cboLineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLineNumber.DataSource = Me.PurchaseOrderLineQueryQOBindingSource
        Me.cboLineNumber.DisplayMember = "PurchaseOrderLineNumber"
        Me.cboLineNumber.FormattingEnabled = True
        Me.cboLineNumber.Location = New System.Drawing.Point(153, 17)
        Me.cboLineNumber.Name = "cboLineNumber"
        Me.cboLineNumber.Size = New System.Drawing.Size(141, 21)
        Me.cboLineNumber.TabIndex = 36
        '
        'PurchaseOrderLineQueryQOBindingSource
        '
        Me.PurchaseOrderLineQueryQOBindingSource.DataMember = "PurchaseOrderLineQueryQO"
        Me.PurchaseOrderLineQueryQOBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtLineGLDebit
        '
        Me.txtLineGLDebit.BackColor = System.Drawing.Color.White
        Me.txtLineGLDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineGLDebit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineGLDebit.Enabled = False
        Me.txtLineGLDebit.Location = New System.Drawing.Point(145, 372)
        Me.txtLineGLDebit.Name = "txtLineGLDebit"
        Me.txtLineGLDebit.ReadOnly = True
        Me.txtLineGLDebit.Size = New System.Drawing.Size(147, 20)
        Me.txtLineGLDebit.TabIndex = 42
        Me.txtLineGLDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboLinePartNumber
        '
        Me.cboLinePartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLinePartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLinePartNumber.DataSource = Me.ItemListBindingSource1
        Me.cboLinePartNumber.DisplayMember = "ItemID"
        Me.cboLinePartNumber.DropDownWidth = 250
        Me.cboLinePartNumber.FormattingEnabled = True
        Me.cboLinePartNumber.Location = New System.Drawing.Point(61, 54)
        Me.cboLinePartNumber.Name = "cboLinePartNumber"
        Me.cboLinePartNumber.Size = New System.Drawing.Size(233, 21)
        Me.cboLinePartNumber.TabIndex = 37
        '
        'ItemListBindingSource1
        '
        Me.ItemListBindingSource1.DataMember = "ItemList"
        Me.ItemListBindingSource1.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(14, 54)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(78, 20)
        Me.Label30.TabIndex = 28
        Me.Label30.Text = "Part #"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLineDescription
        '
        Me.cboLineDescription.DataSource = Me.ItemListBindingSource1
        Me.cboLineDescription.DisplayMember = "ShortDescription"
        Me.cboLineDescription.DropDownWidth = 300
        Me.cboLineDescription.FormattingEnabled = True
        Me.cboLineDescription.Location = New System.Drawing.Point(18, 83)
        Me.cboLineDescription.Name = "cboLineDescription"
        Me.cboLineDescription.Size = New System.Drawing.Size(276, 21)
        Me.cboLineDescription.TabIndex = 38
        '
        'txtLineUnitCost
        '
        Me.txtLineUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineUnitCost.Location = New System.Drawing.Point(145, 288)
        Me.txtLineUnitCost.Name = "txtLineUnitCost"
        Me.txtLineUnitCost.Size = New System.Drawing.Size(146, 20)
        Me.txtLineUnitCost.TabIndex = 39
        Me.txtLineUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineExtendedCost
        '
        Me.txtLineExtendedCost.BackColor = System.Drawing.Color.White
        Me.txtLineExtendedCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineExtendedCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineExtendedCost.Enabled = False
        Me.txtLineExtendedCost.Location = New System.Drawing.Point(145, 344)
        Me.txtLineExtendedCost.Name = "txtLineExtendedCost"
        Me.txtLineExtendedCost.ReadOnly = True
        Me.txtLineExtendedCost.Size = New System.Drawing.Size(147, 20)
        Me.txtLineExtendedCost.TabIndex = 41
        Me.txtLineExtendedCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineOrderQuantity
        '
        Me.txtLineOrderQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineOrderQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineOrderQuantity.Location = New System.Drawing.Point(145, 316)
        Me.txtLineOrderQuantity.Name = "txtLineOrderQuantity"
        Me.txtLineOrderQuantity.Size = New System.Drawing.Size(146, 20)
        Me.txtLineOrderQuantity.TabIndex = 40
        Me.txtLineOrderQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(12, 398)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(103, 20)
        Me.Label34.TabIndex = 47
        Me.Label34.Text = "Credit Account"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(12, 370)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(103, 20)
        Me.Label36.TabIndex = 45
        Me.Label36.Text = "Debit Account"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(12, 342)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(103, 20)
        Me.Label32.TabIndex = 38
        Me.Label32.Text = "Extended Cost"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(12, 286)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(103, 20)
        Me.Label29.TabIndex = 36
        Me.Label29.Text = "Unit Cost"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'VendorTableAdapter
        '
        Me.VendorTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'PaymentTermsTableAdapter
        '
        Me.PaymentTermsTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'ItemClassTableAdapter
        '
        Me.ItemClassTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(17, 58)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(86, 20)
        Me.Label37.TabIndex = 26
        Me.Label37.Text = "Ship To ID"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipToID
        '
        Me.cboShipToID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipToID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipToID.DataSource = Me.AdditionalShipToBindingSource
        Me.cboShipToID.DisplayMember = "ShipToID"
        Me.cboShipToID.DropDownWidth = 300
        Me.cboShipToID.FormattingEnabled = True
        Me.cboShipToID.Location = New System.Drawing.Point(104, 58)
        Me.cboShipToID.Name = "cboShipToID"
        Me.cboShipToID.Size = New System.Drawing.Size(264, 21)
        Me.cboShipToID.TabIndex = 38
        '
        'AdditionalShipToBindingSource
        '
        Me.AdditionalShipToBindingSource.DataMember = "AdditionalShipTo"
        Me.AdditionalShipToBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'AdditionalShipToTableAdapter
        '
        Me.AdditionalShipToTableAdapter.ClearBeforeFill = True
        '
        'tabPODetails
        '
        Me.tabPODetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabPODetails.Controls.Add(Me.tabPOLines)
        Me.tabPODetails.Controls.Add(Me.tabOtherDetails)
        Me.tabPODetails.Controls.Add(Me.tabOrderTracking)
        Me.tabPODetails.Location = New System.Drawing.Point(348, 41)
        Me.tabPODetails.Name = "tabPODetails"
        Me.tabPODetails.SelectedIndex = 0
        Me.tabPODetails.Size = New System.Drawing.Size(782, 509)
        Me.tabPODetails.TabIndex = 16
        '
        'tabPOLines
        '
        Me.tabPOLines.Controls.Add(Me.dgvPurchaseOrderLines)
        Me.tabPOLines.Location = New System.Drawing.Point(4, 22)
        Me.tabPOLines.Name = "tabPOLines"
        Me.tabPOLines.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPOLines.Size = New System.Drawing.Size(774, 483)
        Me.tabPOLines.TabIndex = 0
        Me.tabPOLines.Text = "Purchase Order Lines"
        Me.tabPOLines.UseVisualStyleBackColor = True
        '
        'dgvPurchaseOrderLines
        '
        Me.dgvPurchaseOrderLines.AllowUserToAddRows = False
        Me.dgvPurchaseOrderLines.AllowUserToDeleteRows = False
        Me.dgvPurchaseOrderLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPurchaseOrderLines.AutoGenerateColumns = False
        Me.dgvPurchaseOrderLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPurchaseOrderLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPurchaseOrderLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPurchaseOrderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPurchaseOrderLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PurchaseOrderLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.OrderQuantityColumn, Me.POQuantityReceivedColumn, Me.POQuantityOpenColumn, Me.UnitCostColumn, Me.ExtendedAmountColumn, Me.LineCommentColumn, Me.LineStatusColumn, Me.DebitGLAccountColumn, Me.CreditGLAccountColumn, Me.PurchaseOrderHeaderKeyColumn, Me.DivisionIDColumn})
        Me.dgvPurchaseOrderLines.DataSource = Me.PurchaseOrderLineQueryQOBindingSource
        Me.dgvPurchaseOrderLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvPurchaseOrderLines.Location = New System.Drawing.Point(0, 0)
        Me.dgvPurchaseOrderLines.Name = "dgvPurchaseOrderLines"
        Me.dgvPurchaseOrderLines.Size = New System.Drawing.Size(768, 483)
        Me.dgvPurchaseOrderLines.TabIndex = 0
        '
        'PurchaseOrderLineNumberColumn
        '
        Me.PurchaseOrderLineNumberColumn.DataPropertyName = "PurchaseOrderLineNumber"
        Me.PurchaseOrderLineNumberColumn.HeaderText = "Line #"
        Me.PurchaseOrderLineNumberColumn.Name = "PurchaseOrderLineNumberColumn"
        Me.PurchaseOrderLineNumberColumn.ReadOnly = True
        Me.PurchaseOrderLineNumberColumn.Width = 55
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
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 120
        '
        'OrderQuantityColumn
        '
        Me.OrderQuantityColumn.DataPropertyName = "OrderQuantity"
        Me.OrderQuantityColumn.HeaderText = "Order Qty"
        Me.OrderQuantityColumn.Name = "OrderQuantityColumn"
        Me.OrderQuantityColumn.Width = 80
        '
        'POQuantityReceivedColumn
        '
        Me.POQuantityReceivedColumn.DataPropertyName = "POQuantityReceived"
        Me.POQuantityReceivedColumn.HeaderText = "Qty Rcd"
        Me.POQuantityReceivedColumn.Name = "POQuantityReceivedColumn"
        Me.POQuantityReceivedColumn.ReadOnly = True
        Me.POQuantityReceivedColumn.Width = 80
        '
        'POQuantityOpenColumn
        '
        Me.POQuantityOpenColumn.DataPropertyName = "POQuantityOpen"
        Me.POQuantityOpenColumn.HeaderText = "Qty Open"
        Me.POQuantityOpenColumn.Name = "POQuantityOpenColumn"
        Me.POQuantityOpenColumn.ReadOnly = True
        Me.POQuantityOpenColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        DataGridViewCellStyle7.Format = "N5"
        DataGridViewCellStyle7.NullValue = "0"
        Me.UnitCostColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 80
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.ExtendedAmountColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.ExtendedAmountColumn.HeaderText = "Extended Amount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 80
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        Me.LineCommentColumn.Width = 180
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        Me.LineStatusColumn.Width = 82
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "Debit Account"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.ReadOnly = True
        Me.DebitGLAccountColumn.Width = 111
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "Credit Account"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.ReadOnly = True
        Me.CreditGLAccountColumn.Width = 113
        '
        'PurchaseOrderHeaderKeyColumn
        '
        Me.PurchaseOrderHeaderKeyColumn.DataPropertyName = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn.HeaderText = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn.Name = "PurchaseOrderHeaderKeyColumn"
        Me.PurchaseOrderHeaderKeyColumn.Visible = False
        Me.PurchaseOrderHeaderKeyColumn.Width = 156
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        Me.DivisionIDColumn.Width = 80
        '
        'tabOtherDetails
        '
        Me.tabOtherDetails.Controls.Add(Me.Label46)
        Me.tabOtherDetails.Controls.Add(Me.Label45)
        Me.tabOtherDetails.Controls.Add(Me.txtDivisionVendor)
        Me.tabOtherDetails.Controls.Add(Me.cmdGetDivisionPackList)
        Me.tabOtherDetails.Controls.Add(Me.Label42)
        Me.tabOtherDetails.Controls.Add(Me.txtShippingWeight)
        Me.tabOtherDetails.Controls.Add(Me.Label33)
        Me.tabOtherDetails.Controls.Add(Me.txtNumberOfBoxes)
        Me.tabOtherDetails.Controls.Add(Me.Label31)
        Me.tabOtherDetails.Controls.Add(Me.Label17)
        Me.tabOtherDetails.Controls.Add(Me.cmdLoadDefaultAddress)
        Me.tabOtherDetails.Controls.Add(Me.Label41)
        Me.tabOtherDetails.Controls.Add(Me.Label15)
        Me.tabOtherDetails.Controls.Add(Me.cmdLinkPOAndSO)
        Me.tabOtherDetails.Controls.Add(Me.txtDSSalesOrderNumber)
        Me.tabOtherDetails.Controls.Add(Me.Label40)
        Me.tabOtherDetails.Controls.Add(Me.Label39)
        Me.tabOtherDetails.Controls.Add(Me.GroupBox1)
        Me.tabOtherDetails.Controls.Add(Me.Label38)
        Me.tabOtherDetails.Controls.Add(Me.chkDropShip)
        Me.tabOtherDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabOtherDetails.Name = "tabOtherDetails"
        Me.tabOtherDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOtherDetails.Size = New System.Drawing.Size(774, 483)
        Me.tabOtherDetails.TabIndex = 1
        Me.tabOtherDetails.Text = "Drop Ship / Shipping Details"
        Me.tabOtherDetails.UseVisualStyleBackColor = True
        '
        'Label46
        '
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(162, 450)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(52, 20)
        Me.Label46.TabIndex = 90
        Me.Label46.Text = "Division"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.ForeColor = System.Drawing.Color.Blue
        Me.Label45.Location = New System.Drawing.Point(34, 422)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(191, 20)
        Me.Label45.TabIndex = 89
        Me.Label45.Text = "Get Pack List from division."
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDivisionVendor
        '
        Me.txtDivisionVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDivisionVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDivisionVendor.Location = New System.Drawing.Point(34, 450)
        Me.txtDivisionVendor.Name = "txtDivisionVendor"
        Me.txtDivisionVendor.Size = New System.Drawing.Size(123, 20)
        Me.txtDivisionVendor.TabIndex = 88
        Me.txtDivisionVendor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGetDivisionPackList
        '
        Me.cmdGetDivisionPackList.Location = New System.Drawing.Point(260, 429)
        Me.cmdGetDivisionPackList.Name = "cmdGetDivisionPackList"
        Me.cmdGetDivisionPackList.Size = New System.Drawing.Size(71, 40)
        Me.cmdGetDivisionPackList.TabIndex = 87
        Me.cmdGetDivisionPackList.Text = "Packing List"
        Me.cmdGetDivisionPackList.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.ForeColor = System.Drawing.Color.Blue
        Me.Label42.Location = New System.Drawing.Point(34, 332)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(296, 23)
        Me.Label42.TabIndex = 86
        Me.Label42.Text = "Manual Entry (Packing List)"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShippingWeight
        '
        Me.txtShippingWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingWeight.Location = New System.Drawing.Point(178, 389)
        Me.txtShippingWeight.Name = "txtShippingWeight"
        Me.txtShippingWeight.Size = New System.Drawing.Size(153, 20)
        Me.txtShippingWeight.TabIndex = 84
        Me.txtShippingWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(34, 389)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(132, 20)
        Me.Label33.TabIndex = 85
        Me.Label33.Text = "Shipping Weight"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumberOfBoxes
        '
        Me.txtNumberOfBoxes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberOfBoxes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberOfBoxes.Location = New System.Drawing.Point(177, 363)
        Me.txtNumberOfBoxes.Name = "txtNumberOfBoxes"
        Me.txtNumberOfBoxes.Size = New System.Drawing.Size(153, 20)
        Me.txtNumberOfBoxes.TabIndex = 82
        Me.txtNumberOfBoxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(34, 363)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(132, 20)
        Me.Label31.TabIndex = 83
        Me.Label31.Text = "Number of Boxes"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(137, 280)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(193, 44)
        Me.Label17.TabIndex = 81
        Me.Label17.Text = "This will re-load the default shipping address from the division if no Customer/S" & _
            "hip To ID is present."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdLoadDefaultAddress
        '
        Me.cmdLoadDefaultAddress.Location = New System.Drawing.Point(175, 282)
        Me.cmdLoadDefaultAddress.Name = "cmdLoadDefaultAddress"
        Me.cmdLoadDefaultAddress.Size = New System.Drawing.Size(71, 40)
        Me.cmdLoadDefaultAddress.TabIndex = 80
        Me.cmdLoadDefaultAddress.Text = "Default Address"
        Me.cmdLoadDefaultAddress.UseVisualStyleBackColor = True
        '
        'Label41
        '
        Me.Label41.ForeColor = System.Drawing.Color.Blue
        Me.Label41.Location = New System.Drawing.Point(137, 229)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(196, 44)
        Me.Label41.TabIndex = 79
        Me.Label41.Text = "For these to be linked, Part #'s and quantities for each line must match the PO a" & _
            "nd the SO."
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(34, 163)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(295, 56)
        Me.Label15.TabIndex = 78
        Me.Label15.Text = resources.GetString("Label15.Text")
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdLinkPOAndSO
        '
        Me.cmdLinkPOAndSO.Location = New System.Drawing.Point(34, 253)
        Me.cmdLinkPOAndSO.Name = "cmdLinkPOAndSO"
        Me.cmdLinkPOAndSO.Size = New System.Drawing.Size(71, 40)
        Me.cmdLinkPOAndSO.TabIndex = 77
        Me.cmdLinkPOAndSO.Text = "Link PO and SO"
        Me.cmdLinkPOAndSO.UseVisualStyleBackColor = True
        '
        'txtDSSalesOrderNumber
        '
        Me.txtDSSalesOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDSSalesOrderNumber.Location = New System.Drawing.Point(171, 73)
        Me.txtDSSalesOrderNumber.Name = "txtDSSalesOrderNumber"
        Me.txtDSSalesOrderNumber.Size = New System.Drawing.Size(158, 20)
        Me.txtDSSalesOrderNumber.TabIndex = 36
        Me.txtDSSalesOrderNumber.TabStop = False
        Me.txtDSSalesOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(34, 73)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(130, 21)
        Me.Label40.TabIndex = 76
        Me.Label40.Text = "Drop Ship SO #"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label39
        '
        Me.Label39.ForeColor = System.Drawing.Color.Blue
        Me.Label39.Location = New System.Drawing.Point(34, 100)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(295, 53)
        Me.Label39.TabIndex = 33
        Me.Label39.Text = "From the Sales Order you can automatically create the Drop Ship Purchase Order, b" & _
            "y using the function Create PO From SO in the Sales and Purchase modules."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtShippingName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCustomerCountry)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.cboDropShipState)
        Me.GroupBox1.Controls.Add(Me.txtCustomerDSCity)
        Me.GroupBox1.Controls.Add(Me.cboCustomerDSName)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCustomerDSZip)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cboShipToID)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.txtCustomerDSAddress1)
        Me.GroupBox1.Controls.Add(Me.txtCustomerDSAddress2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(374, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 477)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Drop Ship Customer / Shipping Details"
        '
        'txtShippingName
        '
        Me.txtShippingName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingName.Location = New System.Drawing.Point(63, 89)
        Me.txtShippingName.Name = "txtShippingName"
        Me.txtShippingName.Size = New System.Drawing.Size(305, 20)
        Me.txtShippingName.TabIndex = 45
        Me.txtShippingName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 20)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.ForeColor = System.Drawing.Color.Blue
        Me.Label38.Location = New System.Drawing.Point(34, 38)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(292, 32)
        Me.Label38.TabIndex = 31
        Me.Label38.Text = "Check box if this is a Drop Ship to a customer from the vendor."
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabOrderTracking
        '
        Me.tabOrderTracking.Controls.Add(Me.dgvReturnTable)
        Me.tabOrderTracking.Controls.Add(Me.dgvReceiverTable)
        Me.tabOrderTracking.Controls.Add(Me.dgvROITable)
        Me.tabOrderTracking.Controls.Add(Me.Label47)
        Me.tabOrderTracking.Controls.Add(Me.GroupBox2)
        Me.tabOrderTracking.Location = New System.Drawing.Point(4, 22)
        Me.tabOrderTracking.Name = "tabOrderTracking"
        Me.tabOrderTracking.Size = New System.Drawing.Size(774, 483)
        Me.tabOrderTracking.TabIndex = 2
        Me.tabOrderTracking.Text = "Order Tracking"
        Me.tabOrderTracking.UseVisualStyleBackColor = True
        '
        'dgvReturnTable
        '
        Me.dgvReturnTable.AllowUserToAddRows = False
        Me.dgvReturnTable.AllowUserToDeleteRows = False
        Me.dgvReturnTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReturnTable.AutoGenerateColumns = False
        Me.dgvReturnTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReturnTable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReturnTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReturnTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReturnNumberColumnRTT, Me.ReturnDateColumnRTT, Me.ReturnTotalColumnRTT, Me.ReturnStatusColumnRTT, Me.DivisionIDColumnRTT})
        Me.dgvReturnTable.DataSource = Me.VendorReturnBindingSource
        Me.dgvReturnTable.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvReturnTable.Location = New System.Drawing.Point(296, 167)
        Me.dgvReturnTable.Name = "dgvReturnTable"
        Me.dgvReturnTable.ReadOnly = True
        Me.dgvReturnTable.Size = New System.Drawing.Size(472, 140)
        Me.dgvReturnTable.TabIndex = 81
        '
        'ReturnNumberColumnRTT
        '
        Me.ReturnNumberColumnRTT.DataPropertyName = "ReturnNumber"
        Me.ReturnNumberColumnRTT.HeaderText = "Return #"
        Me.ReturnNumberColumnRTT.Name = "ReturnNumberColumnRTT"
        Me.ReturnNumberColumnRTT.ReadOnly = True
        '
        'ReturnDateColumnRTT
        '
        Me.ReturnDateColumnRTT.DataPropertyName = "ReturnDate"
        Me.ReturnDateColumnRTT.HeaderText = "Return Date"
        Me.ReturnDateColumnRTT.Name = "ReturnDateColumnRTT"
        Me.ReturnDateColumnRTT.ReadOnly = True
        '
        'ReturnTotalColumnRTT
        '
        Me.ReturnTotalColumnRTT.DataPropertyName = "ReturnTotal"
        Me.ReturnTotalColumnRTT.HeaderText = "Return Total"
        Me.ReturnTotalColumnRTT.Name = "ReturnTotalColumnRTT"
        Me.ReturnTotalColumnRTT.ReadOnly = True
        '
        'ReturnStatusColumnRTT
        '
        Me.ReturnStatusColumnRTT.DataPropertyName = "ReturnStatus"
        Me.ReturnStatusColumnRTT.HeaderText = "Return Status"
        Me.ReturnStatusColumnRTT.Name = "ReturnStatusColumnRTT"
        Me.ReturnStatusColumnRTT.ReadOnly = True
        '
        'DivisionIDColumnRTT
        '
        Me.DivisionIDColumnRTT.DataPropertyName = "DivisionID"
        Me.DivisionIDColumnRTT.HeaderText = "DivisionID"
        Me.DivisionIDColumnRTT.Name = "DivisionIDColumnRTT"
        Me.DivisionIDColumnRTT.ReadOnly = True
        Me.DivisionIDColumnRTT.Visible = False
        '
        'VendorReturnBindingSource
        '
        Me.VendorReturnBindingSource.DataMember = "VendorReturn"
        Me.VendorReturnBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvReceiverTable
        '
        Me.dgvReceiverTable.AllowUserToAddRows = False
        Me.dgvReceiverTable.AllowUserToDeleteRows = False
        Me.dgvReceiverTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReceiverTable.AutoGenerateColumns = False
        Me.dgvReceiverTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReceiverTable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReceiverTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceiverTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReceivingHeaderKeyColumnRT, Me.ReceivingDateColumnRT, Me.POTotalColumnRT, Me.StatusColumnRT, Me.DivisionIDColumnRT})
        Me.dgvReceiverTable.DataSource = Me.ReceivingHeaderTableBindingSource
        Me.dgvReceiverTable.GridColor = System.Drawing.Color.Lime
        Me.dgvReceiverTable.Location = New System.Drawing.Point(296, 13)
        Me.dgvReceiverTable.Name = "dgvReceiverTable"
        Me.dgvReceiverTable.ReadOnly = True
        Me.dgvReceiverTable.Size = New System.Drawing.Size(472, 140)
        Me.dgvReceiverTable.TabIndex = 80
        '
        'ReceivingHeaderKeyColumnRT
        '
        Me.ReceivingHeaderKeyColumnRT.DataPropertyName = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumnRT.HeaderText = "Receiver #"
        Me.ReceivingHeaderKeyColumnRT.Name = "ReceivingHeaderKeyColumnRT"
        Me.ReceivingHeaderKeyColumnRT.ReadOnly = True
        '
        'ReceivingDateColumnRT
        '
        Me.ReceivingDateColumnRT.DataPropertyName = "ReceivingDate"
        Me.ReceivingDateColumnRT.HeaderText = "Receiving Date"
        Me.ReceivingDateColumnRT.Name = "ReceivingDateColumnRT"
        Me.ReceivingDateColumnRT.ReadOnly = True
        '
        'POTotalColumnRT
        '
        Me.POTotalColumnRT.DataPropertyName = "POTotal"
        Me.POTotalColumnRT.HeaderText = "Receiver Total"
        Me.POTotalColumnRT.Name = "POTotalColumnRT"
        Me.POTotalColumnRT.ReadOnly = True
        '
        'StatusColumnRT
        '
        Me.StatusColumnRT.DataPropertyName = "Status"
        Me.StatusColumnRT.HeaderText = "Status"
        Me.StatusColumnRT.Name = "StatusColumnRT"
        Me.StatusColumnRT.ReadOnly = True
        '
        'DivisionIDColumnRT
        '
        Me.DivisionIDColumnRT.DataPropertyName = "DivisionID"
        Me.DivisionIDColumnRT.HeaderText = "DivisionID"
        Me.DivisionIDColumnRT.Name = "DivisionIDColumnRT"
        Me.DivisionIDColumnRT.ReadOnly = True
        Me.DivisionIDColumnRT.Visible = False
        '
        'ReceivingHeaderTableBindingSource
        '
        Me.ReceivingHeaderTableBindingSource.DataMember = "ReceivingHeaderTable"
        Me.ReceivingHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvROITable
        '
        Me.dgvROITable.AllowUserToAddRows = False
        Me.dgvROITable.AllowUserToDeleteRows = False
        Me.dgvROITable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvROITable.AutoGenerateColumns = False
        Me.dgvROITable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvROITable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvROITable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvROITable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VoucherNumberColumnVT, Me.InvoiceNumberColumnVT, Me.InvoiceDateColumnVT, Me.InvoiceTotalColumnVT, Me.VoucherStatusColumnVT, Me.DivisionIDColumnVT})
        Me.dgvROITable.DataSource = Me.ReceiptOfInvoiceBatchLineBindingSource
        Me.dgvROITable.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvROITable.Location = New System.Drawing.Point(296, 321)
        Me.dgvROITable.Name = "dgvROITable"
        Me.dgvROITable.ReadOnly = True
        Me.dgvROITable.Size = New System.Drawing.Size(472, 140)
        Me.dgvROITable.TabIndex = 79
        '
        'VoucherNumberColumnVT
        '
        Me.VoucherNumberColumnVT.DataPropertyName = "VoucherNumber"
        Me.VoucherNumberColumnVT.HeaderText = "Voucher #"
        Me.VoucherNumberColumnVT.Name = "VoucherNumberColumnVT"
        Me.VoucherNumberColumnVT.ReadOnly = True
        Me.VoucherNumberColumnVT.Width = 90
        '
        'InvoiceNumberColumnVT
        '
        Me.InvoiceNumberColumnVT.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumnVT.HeaderText = "Invoice #"
        Me.InvoiceNumberColumnVT.Name = "InvoiceNumberColumnVT"
        Me.InvoiceNumberColumnVT.ReadOnly = True
        Me.InvoiceNumberColumnVT.Width = 80
        '
        'InvoiceDateColumnVT
        '
        Me.InvoiceDateColumnVT.DataPropertyName = "InvoiceDate"
        Me.InvoiceDateColumnVT.HeaderText = "Invoice Date"
        Me.InvoiceDateColumnVT.Name = "InvoiceDateColumnVT"
        Me.InvoiceDateColumnVT.ReadOnly = True
        Me.InvoiceDateColumnVT.Width = 90
        '
        'InvoiceTotalColumnVT
        '
        Me.InvoiceTotalColumnVT.DataPropertyName = "InvoiceTotal"
        Me.InvoiceTotalColumnVT.HeaderText = "Invoice Total"
        Me.InvoiceTotalColumnVT.Name = "InvoiceTotalColumnVT"
        Me.InvoiceTotalColumnVT.ReadOnly = True
        Me.InvoiceTotalColumnVT.Width = 90
        '
        'VoucherStatusColumnVT
        '
        Me.VoucherStatusColumnVT.DataPropertyName = "VoucherStatus"
        Me.VoucherStatusColumnVT.HeaderText = "Status"
        Me.VoucherStatusColumnVT.Name = "VoucherStatusColumnVT"
        Me.VoucherStatusColumnVT.ReadOnly = True
        Me.VoucherStatusColumnVT.Width = 80
        '
        'DivisionIDColumnVT
        '
        Me.DivisionIDColumnVT.DataPropertyName = "DivisionID"
        Me.DivisionIDColumnVT.HeaderText = "DivisionID"
        Me.DivisionIDColumnVT.Name = "DivisionIDColumnVT"
        Me.DivisionIDColumnVT.ReadOnly = True
        Me.DivisionIDColumnVT.Visible = False
        '
        'ReceiptOfInvoiceBatchLineBindingSource
        '
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataMember = "ReceiptOfInvoiceBatchLine"
        Me.ReceiptOfInvoiceBatchLineBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Blue
        Me.Label47.Location = New System.Drawing.Point(47, 321)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(196, 115)
        Me.Label47.TabIndex = 78
        Me.Label47.Text = "Double-Click on any item in the datagrid to view the Receiver, Vendor Return, or " & _
            " Voucher."
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblDifference)
        Me.GroupBox2.Controls.Add(Me.Label61)
        Me.GroupBox2.Controls.Add(Me.lblNumberReceivers)
        Me.GroupBox2.Controls.Add(Me.lblNumberReturns)
        Me.GroupBox2.Controls.Add(Me.lblNumberVouchers)
        Me.GroupBox2.Controls.Add(Me.lblReturnTotal)
        Me.GroupBox2.Controls.Add(Me.lblVoucherTotal)
        Me.GroupBox2.Controls.Add(Me.lblReceiverTotal)
        Me.GroupBox2.Controls.Add(Me.Label71)
        Me.GroupBox2.Controls.Add(Me.Label70)
        Me.GroupBox2.Controls.Add(Me.Label69)
        Me.GroupBox2.Controls.Add(Me.Label68)
        Me.GroupBox2.Controls.Add(Me.Label67)
        Me.GroupBox2.Controls.Add(Me.Label66)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 269)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'lblDifference
        '
        Me.lblDifference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDifference.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDifference.Location = New System.Drawing.Point(107, 218)
        Me.lblDifference.Name = "lblDifference"
        Me.lblDifference.Size = New System.Drawing.Size(123, 20)
        Me.lblDifference.TabIndex = 87
        Me.lblDifference.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(19, 218)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(107, 20)
        Me.Label61.TabIndex = 88
        Me.Label61.Text = "Difference"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumberReceivers
        '
        Me.lblNumberReceivers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumberReceivers.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumberReceivers.Location = New System.Drawing.Point(107, 21)
        Me.lblNumberReceivers.Name = "lblNumberReceivers"
        Me.lblNumberReceivers.Size = New System.Drawing.Size(123, 20)
        Me.lblNumberReceivers.TabIndex = 77
        Me.lblNumberReceivers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumberReturns
        '
        Me.lblNumberReturns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumberReturns.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumberReturns.Location = New System.Drawing.Point(107, 51)
        Me.lblNumberReturns.Name = "lblNumberReturns"
        Me.lblNumberReturns.Size = New System.Drawing.Size(123, 20)
        Me.lblNumberReturns.TabIndex = 85
        Me.lblNumberReturns.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumberVouchers
        '
        Me.lblNumberVouchers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumberVouchers.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumberVouchers.Location = New System.Drawing.Point(107, 81)
        Me.lblNumberVouchers.Name = "lblNumberVouchers"
        Me.lblNumberVouchers.Size = New System.Drawing.Size(123, 20)
        Me.lblNumberVouchers.TabIndex = 79
        Me.lblNumberVouchers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReturnTotal
        '
        Me.lblReturnTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReturnTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReturnTotal.Location = New System.Drawing.Point(107, 158)
        Me.lblReturnTotal.Name = "lblReturnTotal"
        Me.lblReturnTotal.Size = New System.Drawing.Size(123, 20)
        Me.lblReturnTotal.TabIndex = 80
        Me.lblReturnTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVoucherTotal
        '
        Me.lblVoucherTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVoucherTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoucherTotal.Location = New System.Drawing.Point(107, 188)
        Me.lblVoucherTotal.Name = "lblVoucherTotal"
        Me.lblVoucherTotal.Size = New System.Drawing.Size(123, 20)
        Me.lblVoucherTotal.TabIndex = 78
        Me.lblVoucherTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReceiverTotal
        '
        Me.lblReceiverTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReceiverTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiverTotal.Location = New System.Drawing.Point(107, 128)
        Me.lblReceiverTotal.Name = "lblReceiverTotal"
        Me.lblReceiverTotal.Size = New System.Drawing.Size(123, 20)
        Me.lblReceiverTotal.TabIndex = 76
        Me.lblReceiverTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label71
        '
        Me.Label71.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(19, 128)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(107, 20)
        Me.Label71.TabIndex = 81
        Me.Label71.Text = "Receiver Total"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label70
        '
        Me.Label70.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(19, 21)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(107, 20)
        Me.Label70.TabIndex = 75
        Me.Label70.Text = "# of Receivers"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label69
        '
        Me.Label69.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(19, 158)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(107, 20)
        Me.Label69.TabIndex = 83
        Me.Label69.Text = "Return Total"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label68
        '
        Me.Label68.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(19, 188)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(107, 20)
        Me.Label68.TabIndex = 82
        Me.Label68.Text = "Voucher Total"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label67
        '
        Me.Label67.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(19, 81)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(107, 20)
        Me.Label67.TabIndex = 84
        Me.Label67.Text = "# of Vouchers"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label66
        '
        Me.Label66.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(19, 51)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(107, 20)
        Me.Label66.TabIndex = 86
        Me.Label66.Text = "# of Returns"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxVendorData
        '
        Me.gpxVendorData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxVendorData.Controls.Add(Me.cboShipMethod)
        Me.gpxVendorData.Controls.Add(Me.Label44)
        Me.gpxVendorData.Controls.Add(Me.Label14)
        Me.gpxVendorData.Controls.Add(Me.txtPOComment)
        Me.gpxVendorData.Controls.Add(Me.cboPaymentTerms)
        Me.gpxVendorData.Controls.Add(Me.cboShipVia)
        Me.gpxVendorData.Controls.Add(Me.lblPaymentTerms)
        Me.gpxVendorData.Controls.Add(Me.lblPOShipDate)
        Me.gpxVendorData.Location = New System.Drawing.Point(352, 556)
        Me.gpxVendorData.Name = "gpxVendorData"
        Me.gpxVendorData.Size = New System.Drawing.Size(379, 255)
        Me.gpxVendorData.TabIndex = 18
        Me.gpxVendorData.TabStop = False
        Me.gpxVendorData.Text = "Vendor / Shipping Info"
        '
        'cboShipMethod
        '
        Me.cboShipMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipMethod.FormattingEnabled = True
        Me.cboShipMethod.Items.AddRange(New Object() {"COLLECT", "PREPAID", "PREPAID/ADD", "PREPAID/NOADD", "THIRD PARTY", "OTHER"})
        Me.cboShipMethod.Location = New System.Drawing.Point(106, 78)
        Me.cboShipMethod.MaxLength = 50
        Me.cboShipMethod.Name = "cboShipMethod"
        Me.cboShipMethod.Size = New System.Drawing.Size(254, 21)
        Me.cboShipMethod.TabIndex = 21
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(17, 79)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(138, 20)
        Me.Label44.TabIndex = 22
        Me.Label44.Text = "Ship Method"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PurchaseOrderLineQueryQOTableAdapter
        '
        Me.PurchaseOrderLineQueryQOTableAdapter.ClearBeforeFill = True
        '
        'ReceiptOfInvoiceBatchLineTableAdapter
        '
        Me.ReceiptOfInvoiceBatchLineTableAdapter.ClearBeforeFill = True
        '
        'ReceivingHeaderTableTableAdapter
        '
        Me.ReceivingHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'VendorReturnTableAdapter
        '
        Me.VendorReturnTableAdapter.ClearBeforeFill = True
        '
        'cmdUploadQuote
        '
        Me.cmdUploadQuote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadQuote.Location = New System.Drawing.Point(751, 769)
        Me.cmdUploadQuote.Name = "cmdUploadQuote"
        Me.cmdUploadQuote.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadQuote.TabIndex = 35
        Me.cmdUploadQuote.Text = "Upload Quote"
        Me.cmdUploadQuote.UseVisualStyleBackColor = True
        '
        'cmdViewQuote
        '
        Me.cmdViewQuote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewQuote.Location = New System.Drawing.Point(751, 724)
        Me.cmdViewQuote.Name = "cmdViewQuote"
        Me.cmdViewQuote.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewQuote.TabIndex = 36
        Me.cmdViewQuote.Text = "View Quote"
        Me.cmdViewQuote.UseVisualStyleBackColor = True
        '
        'ofdPOQuotes
        '
        Me.ofdPOQuotes.FileName = "Select PO Quote"
        Me.ofdPOQuotes.Filter = "PDF Files|*.pdf|All Files|*.*"
        '
        'lblOpen
        '
        Me.lblOpen.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblOpen.ForeColor = System.Drawing.Color.Blue
        Me.lblOpen.Location = New System.Drawing.Point(169, 19)
        Me.lblOpen.Name = "lblOpen"
        Me.lblOpen.Size = New System.Drawing.Size(42, 21)
        Me.lblOpen.TabIndex = 80
        Me.lblOpen.Text = "OPEN"
        Me.lblOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblOpen.Visible = False
        '
        'POForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdViewQuote)
        Me.Controls.Add(Me.cmdUploadQuote)
        Me.Controls.Add(Me.gpxVendorData)
        Me.Controls.Add(Me.tabPODetails)
        Me.Controls.Add(Me.tabPOlineDetails)
        Me.Controls.Add(Me.cmdReissuePO)
        Me.Controls.Add(Me.cmdPurchaseHistory)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdVendorForm)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdDeletePO)
        Me.Controls.Add(Me.cmdSavePO)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdPrintPO)
        Me.Controls.Add(Me.gpxOrderTotals)
        Me.Controls.Add(Me.gpxPOHeaderData)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "POForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tru-Fit Products Corporation Purchase Order Form"
        Me.gpxPOHeaderData.ResumeLayout(False)
        Me.gpxPOHeaderData.PerformLayout()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentTermsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpxOrderTotals.ResumeLayout(False)
        Me.gpxOrderTotals.PerformLayout()
        Me.tabPOlineDetails.ResumeLayout(False)
        Me.POLineDetails.ResumeLayout(False)
        Me.POLineDetails.PerformLayout()
        CType(Me.ItemClassBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GLLineDetails.ResumeLayout(False)
        Me.GLLineDetails.PerformLayout()
        CType(Me.ItemClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLineDetails.ResumeLayout(False)
        Me.tabLineDetails.PerformLayout()
        CType(Me.PurchaseOrderLineQueryQOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPODetails.ResumeLayout(False)
        Me.tabPOLines.ResumeLayout(False)
        CType(Me.dgvPurchaseOrderLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOtherDetails.ResumeLayout(False)
        Me.tabOtherDetails.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabOrderTracking.ResumeLayout(False)
        CType(Me.dgvReturnTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorReturnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReceiverTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvROITable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchLineBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.gpxVendorData.ResumeLayout(False)
        Me.gpxVendorData.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPONumber As System.Windows.Forms.Label
    Friend WithEvents lblVendorName As System.Windows.Forms.Label
    Friend WithEvents LabelPODate As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxPOHeaderData As System.Windows.Forms.GroupBox
    Friend WithEvents lblPaymentTerms As System.Windows.Forms.Label
    Friend WithEvents lblPOShipDate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintPO As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerDSAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents dtpPurchaseOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboVendorCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboPaymentTerms As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerDSName As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustomerDSCity As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerDSZip As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerDSAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdAddItem As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderQuantity As System.Windows.Forms.TextBox
    Friend WithEvents cmdSavePO As System.Windows.Forms.Button
    Friend WithEvents cmdDeletePO As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPOComment As System.Windows.Forms.TextBox
    Friend WithEvents gpxOrderTotals As System.Windows.Forms.GroupBox
    Friend WithEvents lblPurchaseTotal As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents lblOrderTotal As System.Windows.Forms.Label
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents dtpShipDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboDropShipState As System.Windows.Forms.ComboBox
    Friend WithEvents chkDropShip As System.Windows.Forms.CheckBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents cboPurchaseOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents chkInventoryItem As System.Windows.Forms.CheckBox
    Friend WithEvents cmdGeneratePO As System.Windows.Forms.Button
    Friend WithEvents txtFreightCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesTax As System.Windows.Forms.TextBox
    Friend WithEvents ViewOpenPOsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewClosedPOsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents cmdPurchaseHistory As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdVendorForm As System.Windows.Forms.Button
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLastPurchaseCost As System.Windows.Forms.Label
    Friend WithEvents cmdReissuePO As System.Windows.Forms.Button
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents tabPOlineDetails As System.Windows.Forms.TabControl
    Friend WithEvents POLineDetails As System.Windows.Forms.TabPage
    Friend WithEvents GLLineDetails As System.Windows.Forms.TabPage
    Friend WithEvents txtSalesOffsetAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtPurchaseAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtCOGSAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtInventoryAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtReturnsAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSalesAccount As System.Windows.Forms.TextBox
    Friend WithEvents cboItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents txtIssuesAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjustmentAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ClosePurchaseOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SavePurchaseOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPurchaseOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReIssuePurchaseOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents VendorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents PaymentTermsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PaymentTermsTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PaymentTermsTableAdapter
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents ItemClassBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemClassTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemClassTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents txtCustomerCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ReOpenPurchaseOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtPOStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboLineDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboLinePartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cboShipToID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents cmdSaveLine As System.Windows.Forms.Button
    Friend WithEvents txtLineUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtLineExtendedCost As System.Windows.Forms.TextBox
    Friend WithEvents txtLineOrderQuantity As System.Windows.Forms.TextBox
    Friend WithEvents cboLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents AdditionalShipToBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdditionalShipToTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
    Friend WithEvents txtLineGLCredit As System.Windows.Forms.TextBox
    Friend WithEvents txtLineGLDebit As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents DeletePurchaseOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabPODetails As System.Windows.Forms.TabControl
    Friend WithEvents tabOtherDetails As System.Windows.Forms.TabPage
    Friend WithEvents tabLineDetails As System.Windows.Forms.TabPage
    Friend WithEvents txtLineComment As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtLineComment2 As System.Windows.Forms.TextBox
    Friend WithEvents gpxVendorData As System.Windows.Forms.GroupBox
    Friend WithEvents tabPOLines As System.Windows.Forms.TabPage
    Friend WithEvents dgvPurchaseOrderLines As System.Windows.Forms.DataGridView
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtDSSalesOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents ManuallyClosePOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManuallyOpenPOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboNewItemClass As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemClassNew As System.Windows.Forms.Label
    Friend WithEvents ItemClassBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents CachedCRXGLWCProductionLines1 As MOS09Program.CachedCRXGLWCProductionLines
    Friend WithEvents txtVendorName As System.Windows.Forms.TextBox
    Friend WithEvents cmdLinkPOAndSO As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblEstWeight As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents llVendorInfo As System.Windows.Forms.LinkLabel
    Friend WithEvents ItemListBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents llOrderQuantity As System.Windows.Forms.LinkLabel
    Friend WithEvents PrintPOPackListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents llLastPurchaseCost As System.Windows.Forms.LinkLabel
    Friend WithEvents PurchaseOrderLineQueryQOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderLineQueryQOTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderLineQueryQOTableAdapter
    Friend WithEvents PrintReceiversToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblBoxCount As System.Windows.Forms.Label
    Friend WithEvents lblPalletCount As System.Windows.Forms.Label
    Friend WithEvents UnLockPurchaseORderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstPartDescriptionSuggest As System.Windows.Forms.ListBox
    Friend WithEvents lstLinePartDescriptionSuggest As System.Windows.Forms.ListBox
    Friend WithEvents txtShippingName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdLoadDefaultAddress As System.Windows.Forms.Button
    Friend WithEvents txtShippingWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtNumberOfBoxes As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents PurchaseOrderLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityReceivedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityOpenColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderHeaderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtDivisionVendor As System.Windows.Forms.TextBox
    Friend WithEvents cmdGetDivisionPackList As System.Windows.Forms.Button
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents tabOrderTracking As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDifference As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents lblNumberReceivers As System.Windows.Forms.Label
    Friend WithEvents lblNumberReturns As System.Windows.Forms.Label
    Friend WithEvents lblNumberVouchers As System.Windows.Forms.Label
    Friend WithEvents lblReturnTotal As System.Windows.Forms.Label
    Friend WithEvents lblVoucherTotal As System.Windows.Forms.Label
    Friend WithEvents lblReceiverTotal As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents dgvROITable As System.Windows.Forms.DataGridView
    Friend WithEvents ReceiptOfInvoiceBatchLineBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchLineTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchLineTableAdapter
    Friend WithEvents VoucherNumberColumnVT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumnVT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateColumnVT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumnVT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherStatusColumnVT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumnVT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvReceiverTable As System.Windows.Forms.DataGridView
    Friend WithEvents ReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
    Friend WithEvents dgvReturnTable As System.Windows.Forms.DataGridView
    Friend WithEvents VendorReturnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendorReturnTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.VendorReturnTableAdapter
    Friend WithEvents ReturnNumberColumnRTT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnDateColumnRTT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnTotalColumnRTT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnStatusColumnRTT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumnRTT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingHeaderKeyColumnRT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivingDateColumnRT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POTotalColumnRT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumnRT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumnRT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdUploadQuote As System.Windows.Forms.Button
    Friend WithEvents cmdViewQuote As System.Windows.Forms.Button
    Friend WithEvents ofdPOQuotes As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ViewQuoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadQuoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblOpenWeight As System.Windows.Forms.Label
    Friend WithEvents lblOpen As System.Windows.Forms.Label
End Class
