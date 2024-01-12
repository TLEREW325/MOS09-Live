<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShipmentCompletion
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdCompleteShipment = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdPrintShipmentConfirmation = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveShipmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteShipmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearShipmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TestAutoEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResetShipmentForCompletionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SendFedExEmailForDailyShipmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BillOfLadingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TruweldCertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PackingListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintShipmentToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintEmailShipmentConfirmationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReUploadPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AppendUploadedPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.gpxShipmentInfo = New System.Windows.Forms.GroupBox
        Me.llPickTicket = New System.Windows.Forms.LinkLabel
        Me.Label34 = New System.Windows.Forms.Label
        Me.cboPickTicketNumber = New System.Windows.Forms.ComboBox
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboShipmentNumber = New System.Windows.Forms.ComboBox
        Me.dtpShipmentDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSalesOrderNumber = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCustomerClass = New System.Windows.Forms.TextBox
        Me.PickListHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtNumberPallets = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtShippingWeight = New System.Windows.Forms.TextBox
        Me.txtActualFreight = New System.Windows.Forms.TextBox
        Me.txtQuotedFreight = New System.Windows.Forms.TextBox
        Me.txtFreightQuoteNumber = New System.Windows.Forms.TextBox
        Me.txtPRONumber = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtShippingCountry = New System.Windows.Forms.TextBox
        Me.txtShippingCity = New System.Windows.Forms.TextBox
        Me.txtShippingZip = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboShippingState = New System.Windows.Forms.ComboBox
        Me.StateTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboAdditionalShipTo = New System.Windows.Forms.ComboBox
        Me.AdditionalShipToBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtShippingAddress1 = New System.Windows.Forms.TextBox
        Me.txtShippingAddress2 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.dgvShipmentLines = New System.Windows.Forms.DataGridView
        Me.CompleteLineColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityShippedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineBoxesColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineWeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLDebitAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLCreditAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CertificationTypeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCompleteColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineTableTableAdapter
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.AdditionalShipToTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
        Me.StateTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.Label32 = New System.Windows.Forms.Label
        Me.cboShipmentLineNumber = New System.Windows.Forms.ComboBox
        Me.cmdDeleteLotNumber = New System.Windows.Forms.Button
        Me.cmdAddLotNumber = New System.Windows.Forms.Button
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.cboLotPartDescription = New System.Windows.Forms.ComboBox
        Me.cboLinePartNumber = New System.Windows.Forms.ComboBox
        Me.dgvAddedLotNumbers = New System.Windows.Forms.DataGridView
        Me.ShipmentNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotLineNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatQuantityColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PullTestNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineLotNumbersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShipmentLineLotNumbersTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineLotNumbersTableAdapter
        Me.tabShipDetails = New System.Windows.Forms.TabControl
        Me.tabShippingDetails = New System.Windows.Forms.TabPage
        Me.txtDoublePallets = New System.Windows.Forms.TextBox
        Me.txtTotalPalletsOnFloor = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.txtShippingAccount = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtThirdPartyShipper = New System.Windows.Forms.TextBox
        Me.cboShipMethod = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txtEstimatedWeight = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.tabShippingAddress = New System.Windows.Forms.TabPage
        Me.txtCustomerID = New System.Windows.Forms.TextBox
        Me.cboSTCountryName = New System.Windows.Forms.ComboBox
        Me.CountryCodesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtShipEmail = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmdPrintLabel = New System.Windows.Forms.Button
        Me.txtShipToName = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.tabCustomerOrders = New System.Windows.Forms.TabPage
        Me.Label35 = New System.Windows.Forms.Label
        Me.dgvOpenOrderLines = New System.Windows.Forms.DataGridView
        Me.OOSalesOrderColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OOSalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OOItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OODescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OOOpenSOQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OOPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OODivisionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OOSOStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OOCustomerIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OOLineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderLineQueryNoQOHBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabComment = New System.Windows.Forms.TabPage
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.txtHeaderComment = New System.Windows.Forms.TextBox
        Me.dgvUPSData = New System.Windows.Forms.DataGridView
        Me.PickTicketNumberColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TrackingNumberColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoidIndicatorColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UPSShippingDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabSpecialLabel = New System.Windows.Forms.TabPage
        Me.Label28 = New System.Windows.Forms.Label
        Me.cmdPrintCustomLabel = New System.Windows.Forms.Button
        Me.txtSpecialLabelLine3 = New System.Windows.Forms.TextBox
        Me.txtSpecialLabelLine2 = New System.Windows.Forms.TextBox
        Me.txtSpecialLabelLine1 = New System.Windows.Forms.TextBox
        Me.Label80 = New System.Windows.Forms.Label
        Me.Label79 = New System.Windows.Forms.Label
        Me.Label78 = New System.Windows.Forms.Label
        Me.Label77 = New System.Windows.Forms.Label
        Me.gpxShipmentLineLotNumbers = New System.Windows.Forms.GroupBox
        Me.cmdPrintBoxLabel = New System.Windows.Forms.Button
        Me.txtHeatQuantity = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtLotNumber = New System.Windows.Forms.TextBox
        Me.llViewLotNumbers = New System.Windows.Forms.LinkLabel
        Me.Label33 = New System.Windows.Forms.Label
        Me.PickListHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdPackingList = New System.Windows.Forms.Button
        Me.cmdTWCert = New System.Windows.Forms.Button
        Me.cmdBOL = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdPrintAll = New System.Windows.Forms.Button
        Me.cmdPrintShippingLabel = New System.Windows.Forms.Button
        Me.cmdSalesOrderForm = New System.Windows.Forms.Button
        Me.SalesOrderLineQueryNoQOHTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineQueryNoQOHTableAdapter
        Me.tabAddSubLines = New System.Windows.Forms.TabControl
        Me.tabAddLots = New System.Windows.Forms.TabPage
        Me.tabAddSerial = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdAddMultiple = New System.Windows.Forms.Button
        Me.txtLinePartDescription2 = New System.Windows.Forms.TextBox
        Me.txtLinePartNumber2 = New System.Windows.Forms.TextBox
        Me.dgvSerialLog = New System.Windows.Forms.DataGridView
        Me.SLShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLShipmentLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLSerialNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLSerialLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLSerialCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SLSerialQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentLineSerialNumbersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtLineSerialNumber2 = New System.Windows.Forms.TextBox
        Me.cboShipmentLineNumber2 = New System.Windows.Forms.ComboBox
        Me.cmdAddSerialNumber = New System.Windows.Forms.Button
        Me.cmdDeleteSerialNumber = New System.Windows.Forms.Button
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.ShipmentLineSerialNumbersTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineSerialNumbersTableAdapter
        Me.CountryCodesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CountryCodesTableAdapter
        Me.UPSShippingDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.UPSShippingDataTableAdapter
        Me.cmdUploadPickTicket = New System.Windows.Forms.Button
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.crxtwCert011 = New MOS09Program.CRXTWCert01
        Me.cmdViewPickTicket = New System.Windows.Forms.Button
        Me.crxnocertDetailPage1 = New MOS09Program.CRXNOCERTDetailPage
        Me.cmdRemoteScan = New System.Windows.Forms.Button
        Me.UploadPickTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.gpxShipmentInfo.SuspendLayout()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShipmentLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAddedLotNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentLineLotNumbersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabShipDetails.SuspendLayout()
        Me.tabShippingDetails.SuspendLayout()
        Me.tabShippingAddress.SuspendLayout()
        CType(Me.CountryCodesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCustomerOrders.SuspendLayout()
        CType(Me.dgvOpenOrderLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderLineQueryNoQOHBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabComment.SuspendLayout()
        CType(Me.dgvUPSData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UPSShippingDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSpecialLabel.SuspendLayout()
        Me.gpxShipmentLineLotNumbers.SuspendLayout()
        Me.tabAddSubLines.SuspendLayout()
        Me.tabAddLots.SuspendLayout()
        Me.tabAddSerial.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvSerialLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentLineSerialNumbersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(1060, 772)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 43
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdCompleteShipment
        '
        Me.cmdCompleteShipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCompleteShipment.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdCompleteShipment.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmdCompleteShipment.ForeColor = System.Drawing.Color.Blue
        Me.cmdCompleteShipment.Location = New System.Drawing.Point(536, 751)
        Me.cmdCompleteShipment.Name = "cmdCompleteShipment"
        Me.cmdCompleteShipment.Size = New System.Drawing.Size(71, 40)
        Me.cmdCompleteShipment.TabIndex = 38
        Me.cmdCompleteShipment.Text = "Complete Shipment"
        Me.cmdCompleteShipment.UseVisualStyleBackColor = False
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Location = New System.Drawing.Point(983, 772)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 42
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdPrintShipmentConfirmation
        '
        Me.cmdPrintShipmentConfirmation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintShipmentConfirmation.Location = New System.Drawing.Point(675, 723)
        Me.cmdPrintShipmentConfirmation.Name = "cmdPrintShipmentConfirmation"
        Me.cmdPrintShipmentConfirmation.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintShipmentConfirmation.TabIndex = 32
        Me.cmdPrintShipmentConfirmation.Text = "Print/Email Confirm."
        Me.cmdPrintShipmentConfirmation.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveShipmentToolStripMenuItem, Me.DeleteShipmentToolStripMenuItem, Me.ClearShipmentToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveShipmentToolStripMenuItem
        '
        Me.SaveShipmentToolStripMenuItem.Name = "SaveShipmentToolStripMenuItem"
        Me.SaveShipmentToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveShipmentToolStripMenuItem.Text = "Save Shipment"
        '
        'DeleteShipmentToolStripMenuItem
        '
        Me.DeleteShipmentToolStripMenuItem.Name = "DeleteShipmentToolStripMenuItem"
        Me.DeleteShipmentToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteShipmentToolStripMenuItem.Text = "Delete Shipment"
        '
        'ClearShipmentToolStripMenuItem
        '
        Me.ClearShipmentToolStripMenuItem.Name = "ClearShipmentToolStripMenuItem"
        Me.ClearShipmentToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ClearShipmentToolStripMenuItem.Text = "Clear Shipment"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestAutoEmailToolStripMenuItem, Me.ResetShipmentForCompletionToolStripMenuItem, Me.SendFedExEmailForDailyShipmentsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'TestAutoEmailToolStripMenuItem
        '
        Me.TestAutoEmailToolStripMenuItem.Name = "TestAutoEmailToolStripMenuItem"
        Me.TestAutoEmailToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.TestAutoEmailToolStripMenuItem.Text = "Test Auto-Email"
        '
        'ResetShipmentForCompletionToolStripMenuItem
        '
        Me.ResetShipmentForCompletionToolStripMenuItem.Name = "ResetShipmentForCompletionToolStripMenuItem"
        Me.ResetShipmentForCompletionToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.ResetShipmentForCompletionToolStripMenuItem.Text = "Reset Shipment for Completion"
        '
        'SendFedExEmailForDailyShipmentsToolStripMenuItem
        '
        Me.SendFedExEmailForDailyShipmentsToolStripMenuItem.Name = "SendFedExEmailForDailyShipmentsToolStripMenuItem"
        Me.SendFedExEmailForDailyShipmentsToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.SendFedExEmailForDailyShipmentsToolStripMenuItem.Text = "Send FedEx Email For Daily Shipments"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BillOfLadingToolStripMenuItem, Me.TruweldCertToolStripMenuItem, Me.PackingListToolStripMenuItem, Me.PrintAllToolStripMenuItem, Me.PrintShipmentToolStripMenuItem1, Me.PrintEmailShipmentConfirmationToolStripMenuItem, Me.ReUploadPickTicketToolStripMenuItem, Me.AppendUploadedPickTicketToolStripMenuItem, Me.UploadPickTicketToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'BillOfLadingToolStripMenuItem
        '
        Me.BillOfLadingToolStripMenuItem.Name = "BillOfLadingToolStripMenuItem"
        Me.BillOfLadingToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.BillOfLadingToolStripMenuItem.Text = "Print Bill Of Lading"
        '
        'TruweldCertToolStripMenuItem
        '
        Me.TruweldCertToolStripMenuItem.Name = "TruweldCertToolStripMenuItem"
        Me.TruweldCertToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.TruweldCertToolStripMenuItem.Text = "Print Truweld Cert"
        '
        'PackingListToolStripMenuItem
        '
        Me.PackingListToolStripMenuItem.Name = "PackingListToolStripMenuItem"
        Me.PackingListToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.PackingListToolStripMenuItem.Text = "Print Packing List"
        '
        'PrintAllToolStripMenuItem
        '
        Me.PrintAllToolStripMenuItem.Name = "PrintAllToolStripMenuItem"
        Me.PrintAllToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.PrintAllToolStripMenuItem.Text = "Print All"
        '
        'PrintShipmentToolStripMenuItem1
        '
        Me.PrintShipmentToolStripMenuItem1.Name = "PrintShipmentToolStripMenuItem1"
        Me.PrintShipmentToolStripMenuItem1.Size = New System.Drawing.Size(241, 22)
        Me.PrintShipmentToolStripMenuItem1.Text = "Print Shipment"
        '
        'PrintEmailShipmentConfirmationToolStripMenuItem
        '
        Me.PrintEmailShipmentConfirmationToolStripMenuItem.Name = "PrintEmailShipmentConfirmationToolStripMenuItem"
        Me.PrintEmailShipmentConfirmationToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.PrintEmailShipmentConfirmationToolStripMenuItem.Text = "Print / Email Shipment Confirmation"
        '
        'ReUploadPickTicketToolStripMenuItem
        '
        Me.ReUploadPickTicketToolStripMenuItem.Name = "ReUploadPickTicketToolStripMenuItem"
        Me.ReUploadPickTicketToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.ReUploadPickTicketToolStripMenuItem.Text = "Re-Upload Pick Ticket"
        '
        'AppendUploadedPickTicketToolStripMenuItem
        '
        Me.AppendUploadedPickTicketToolStripMenuItem.Name = "AppendUploadedPickTicketToolStripMenuItem"
        Me.AppendUploadedPickTicketToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
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
        'gpxShipmentInfo
        '
        Me.gpxShipmentInfo.Controls.Add(Me.llPickTicket)
        Me.gpxShipmentInfo.Controls.Add(Me.Label34)
        Me.gpxShipmentInfo.Controls.Add(Me.cboPickTicketNumber)
        Me.gpxShipmentInfo.Controls.Add(Me.txtCustomerPO)
        Me.gpxShipmentInfo.Controls.Add(Me.Label27)
        Me.gpxShipmentInfo.Controls.Add(Me.cboDivisionID)
        Me.gpxShipmentInfo.Controls.Add(Me.cboShipmentNumber)
        Me.gpxShipmentInfo.Controls.Add(Me.dtpShipmentDate)
        Me.gpxShipmentInfo.Controls.Add(Me.Label5)
        Me.gpxShipmentInfo.Controls.Add(Me.Label4)
        Me.gpxShipmentInfo.Controls.Add(Me.txtSalesOrderNumber)
        Me.gpxShipmentInfo.Controls.Add(Me.Label2)
        Me.gpxShipmentInfo.Controls.Add(Me.Label1)
        Me.gpxShipmentInfo.Controls.Add(Me.txtCustomerClass)
        Me.gpxShipmentInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpxShipmentInfo.Location = New System.Drawing.Point(33, 41)
        Me.gpxShipmentInfo.Name = "gpxShipmentInfo"
        Me.gpxShipmentInfo.Size = New System.Drawing.Size(332, 224)
        Me.gpxShipmentInfo.TabIndex = 0
        Me.gpxShipmentInfo.TabStop = False
        Me.gpxShipmentInfo.Text = "Shipment Information"
        '
        'llPickTicket
        '
        Me.llPickTicket.Location = New System.Drawing.Point(10, 52)
        Me.llPickTicket.Name = "llPickTicket"
        Me.llPickTicket.Size = New System.Drawing.Size(100, 23)
        Me.llPickTicket.TabIndex = 46
        Me.llPickTicket.TabStop = True
        Me.llPickTicket.Text = "Pick Ticket #"
        Me.llPickTicket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(10, 194)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(100, 20)
        Me.Label34.TabIndex = 45
        Me.Label34.Text = "Cust. Class"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPickTicketNumber
        '
        Me.cboPickTicketNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPickTicketNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPickTicketNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboPickTicketNumber.DisplayMember = "PickTicketNumber"
        Me.cboPickTicketNumber.FormattingEnabled = True
        Me.cboPickTicketNumber.Location = New System.Drawing.Point(116, 52)
        Me.cboPickTicketNumber.Name = "cboPickTicketNumber"
        Me.cboPickTicketNumber.Size = New System.Drawing.Size(200, 21)
        Me.cboPickTicketNumber.TabIndex = 1
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
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerPO.Location = New System.Drawing.Point(116, 166)
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(200, 20)
        Me.txtCustomerPO.TabIndex = 5
        Me.txtCustomerPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(10, 166)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(100, 20)
        Me.Label27.TabIndex = 14
        Me.Label27.Text = "Customer PO #"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDivisionID
        '
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(116, 109)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(200, 21)
        Me.cboDivisionID.TabIndex = 3
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboShipmentNumber
        '
        Me.cboShipmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentNumber.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.cboShipmentNumber.DisplayMember = "ShipmentNumber"
        Me.cboShipmentNumber.FormattingEnabled = True
        Me.cboShipmentNumber.Location = New System.Drawing.Point(116, 23)
        Me.cboShipmentNumber.Name = "cboShipmentNumber"
        Me.cboShipmentNumber.Size = New System.Drawing.Size(200, 21)
        Me.cboShipmentNumber.TabIndex = 0
        '
        'dtpShipmentDate
        '
        Me.dtpShipmentDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpShipmentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpShipmentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpShipmentDate.Location = New System.Drawing.Point(116, 138)
        Me.dtpShipmentDate.Name = "dtpShipmentDate"
        Me.dtpShipmentDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpShipmentDate.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(10, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(10, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Division ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesOrderNumber
        '
        Me.txtSalesOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesOrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesOrderNumber.Enabled = False
        Me.txtSalesOrderNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesOrderNumber.Location = New System.Drawing.Point(116, 81)
        Me.txtSalesOrderNumber.Name = "txtSalesOrderNumber"
        Me.txtSalesOrderNumber.Size = New System.Drawing.Size(200, 20)
        Me.txtSalesOrderNumber.TabIndex = 2
        Me.txtSalesOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Sales Order #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Shipment #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustomerClass
        '
        Me.txtCustomerClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerClass.Enabled = False
        Me.txtCustomerClass.Location = New System.Drawing.Point(116, 194)
        Me.txtCustomerClass.Name = "txtCustomerClass"
        Me.txtCustomerClass.Size = New System.Drawing.Size(200, 20)
        Me.txtCustomerClass.TabIndex = 6
        Me.txtCustomerClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PickListHeaderTableBindingSource
        '
        Me.PickListHeaderTableBindingSource.DataMember = "PickListHeaderTable"
        Me.PickListHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboShipVia
        '
        Me.cboShipVia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipVia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(90, 10)
        Me.cboShipVia.MaxLength = 50
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(222, 21)
        Me.cboShipVia.TabIndex = 7
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(15, 358)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(164, 20)
        Me.Label26.TabIndex = 28
        Me.Label26.Text = "Total # of Pallets"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumberPallets
        '
        Me.txtNumberPallets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumberPallets.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberPallets.Location = New System.Drawing.Point(182, 358)
        Me.txtNumberPallets.Name = "txtNumberPallets"
        Me.txtNumberPallets.Size = New System.Drawing.Size(130, 20)
        Me.txtNumberPallets.TabIndex = 15
        Me.txtNumberPallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(15, 292)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 20)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Quoted Freight"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(15, 264)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 20)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Freight Quote #"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(15, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 20)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "PRO Number"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(12, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 25)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Ship Via"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(15, 486)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Total Weight"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 320)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 20)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Billed Freight"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShippingWeight
        '
        Me.txtShippingWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShippingWeight.Location = New System.Drawing.Point(138, 486)
        Me.txtShippingWeight.Name = "txtShippingWeight"
        Me.txtShippingWeight.Size = New System.Drawing.Size(174, 20)
        Me.txtShippingWeight.TabIndex = 19
        Me.txtShippingWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtActualFreight
        '
        Me.txtActualFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualFreight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActualFreight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActualFreight.Location = New System.Drawing.Point(112, 320)
        Me.txtActualFreight.Name = "txtActualFreight"
        Me.txtActualFreight.Size = New System.Drawing.Size(200, 20)
        Me.txtActualFreight.TabIndex = 14
        Me.txtActualFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuotedFreight
        '
        Me.txtQuotedFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuotedFreight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuotedFreight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuotedFreight.Location = New System.Drawing.Point(112, 292)
        Me.txtQuotedFreight.Name = "txtQuotedFreight"
        Me.txtQuotedFreight.Size = New System.Drawing.Size(200, 20)
        Me.txtQuotedFreight.TabIndex = 13
        Me.txtQuotedFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightQuoteNumber
        '
        Me.txtFreightQuoteNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFreightQuoteNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFreightQuoteNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreightQuoteNumber.Location = New System.Drawing.Point(112, 264)
        Me.txtFreightQuoteNumber.Name = "txtFreightQuoteNumber"
        Me.txtFreightQuoteNumber.Size = New System.Drawing.Size(200, 20)
        Me.txtFreightQuoteNumber.TabIndex = 12
        Me.txtFreightQuoteNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPRONumber
        '
        Me.txtPRONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPRONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRONumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRONumber.Location = New System.Drawing.Point(112, 208)
        Me.txtPRONumber.Name = "txtPRONumber"
        Me.txtPRONumber.Size = New System.Drawing.Size(200, 20)
        Me.txtPRONumber.TabIndex = 10
        Me.txtPRONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(9, 388)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "State"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(9, 358)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 20)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "City"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShippingCountry
        '
        Me.txtShippingCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShippingCountry.Location = New System.Drawing.Point(251, 417)
        Me.txtShippingCountry.Name = "txtShippingCountry"
        Me.txtShippingCountry.ReadOnly = True
        Me.txtShippingCountry.Size = New System.Drawing.Size(61, 20)
        Me.txtShippingCountry.TabIndex = 23
        '
        'txtShippingCity
        '
        Me.txtShippingCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShippingCity.Location = New System.Drawing.Point(58, 358)
        Me.txtShippingCity.Name = "txtShippingCity"
        Me.txtShippingCity.Size = New System.Drawing.Size(254, 20)
        Me.txtShippingCity.TabIndex = 20
        '
        'txtShippingZip
        '
        Me.txtShippingZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShippingZip.Location = New System.Drawing.Point(195, 388)
        Me.txtShippingZip.Name = "txtShippingZip"
        Me.txtShippingZip.Size = New System.Drawing.Size(117, 20)
        Me.txtShippingZip.TabIndex = 22
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(9, 15)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(115, 20)
        Me.Label24.TabIndex = 31
        Me.Label24.Text = "Customer"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(9, 418)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 20)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "Country"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(161, 388)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 20)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "ZIP"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboShippingState
        '
        Me.cboShippingState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShippingState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShippingState.DataSource = Me.StateTableBindingSource
        Me.cboShippingState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShippingState.FormattingEnabled = True
        Me.cboShippingState.Location = New System.Drawing.Point(58, 387)
        Me.cboShippingState.Name = "cboShippingState"
        Me.cboShippingState.Size = New System.Drawing.Size(97, 21)
        Me.cboShippingState.TabIndex = 21
        '
        'StateTableBindingSource
        '
        Me.StateTableBindingSource.DataMember = "StateTable"
        Me.StateTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(9, 42)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 20)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Shipping ID"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAdditionalShipTo
        '
        Me.cboAdditionalShipTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAdditionalShipTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAdditionalShipTo.DataSource = Me.AdditionalShipToBindingSource
        Me.cboAdditionalShipTo.DisplayMember = "ShipToID"
        Me.cboAdditionalShipTo.DropDownWidth = 300
        Me.cboAdditionalShipTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAdditionalShipTo.FormattingEnabled = True
        Me.cboAdditionalShipTo.Location = New System.Drawing.Point(86, 42)
        Me.cboAdditionalShipTo.Name = "cboAdditionalShipTo"
        Me.cboAdditionalShipTo.Size = New System.Drawing.Size(226, 21)
        Me.cboAdditionalShipTo.TabIndex = 16
        '
        'AdditionalShipToBindingSource
        '
        Me.AdditionalShipToBindingSource.DataMember = "AdditionalShipTo"
        Me.AdditionalShipToBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtShippingAddress1
        '
        Me.txtShippingAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingAddress1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShippingAddress1.Location = New System.Drawing.Point(12, 171)
        Me.txtShippingAddress1.Multiline = True
        Me.txtShippingAddress1.Name = "txtShippingAddress1"
        Me.txtShippingAddress1.Size = New System.Drawing.Size(300, 70)
        Me.txtShippingAddress1.TabIndex = 18
        '
        'txtShippingAddress2
        '
        Me.txtShippingAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingAddress2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShippingAddress2.Location = New System.Drawing.Point(12, 273)
        Me.txtShippingAddress2.Multiline = True
        Me.txtShippingAddress2.Name = "txtShippingAddress2"
        Me.txtShippingAddress2.Size = New System.Drawing.Size(300, 70)
        Me.txtShippingAddress2.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(9, 145)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 23)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Address 1"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(9, 250)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 20)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Address 2"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvShipmentLines
        '
        Me.dgvShipmentLines.AllowUserToAddRows = False
        Me.dgvShipmentLines.AllowUserToDeleteRows = False
        Me.dgvShipmentLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvShipmentLines.AutoGenerateColumns = False
        Me.dgvShipmentLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvShipmentLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CompleteLineColumn, Me.ShipmentNumberColumn, Me.ShipmentLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityShippedColumn, Me.PriceColumn, Me.LineBoxesColumn, Me.BoxWeightColumn, Me.LineWeightColumn, Me.SerialNumberColumn, Me.LineCommentColumn, Me.SalesTaxColumn, Me.ExtendedAmountColumn, Me.LineStatusColumn, Me.DivisionIDColumn, Me.GLDebitAccountColumn, Me.GLCreditAccountColumn, Me.CertificationTypeColumn, Me.SOLineNumberColumn, Me.LineCompleteColumn})
        Me.dgvShipmentLines.DataSource = Me.ShipmentLineTableBindingSource
        Me.dgvShipmentLines.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvShipmentLines.Location = New System.Drawing.Point(379, 41)
        Me.dgvShipmentLines.Name = "dgvShipmentLines"
        Me.dgvShipmentLines.Size = New System.Drawing.Size(752, 405)
        Me.dgvShipmentLines.TabIndex = 35
        Me.dgvShipmentLines.TabStop = False
        '
        'CompleteLineColumn
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.NullValue = False
        Me.CompleteLineColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.CompleteLineColumn.FalseValue = "UNSELECTED"
        Me.CompleteLineColumn.HeaderText = "C?"
        Me.CompleteLineColumn.IndeterminateValue = ""
        Me.CompleteLineColumn.Name = "CompleteLineColumn"
        Me.CompleteLineColumn.TrueValue = "SELECTED"
        Me.CompleteLineColumn.Visible = False
        Me.CompleteLineColumn.Width = 35
        '
        'ShipmentNumberColumn
        '
        Me.ShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn.HeaderText = "ShipmentNumber"
        Me.ShipmentNumberColumn.Name = "ShipmentNumberColumn"
        Me.ShipmentNumberColumn.Visible = False
        '
        'ShipmentLineNumberColumn
        '
        Me.ShipmentLineNumberColumn.DataPropertyName = "ShipmentLineNumber"
        Me.ShipmentLineNumberColumn.HeaderText = "Line #"
        Me.ShipmentLineNumberColumn.Name = "ShipmentLineNumberColumn"
        Me.ShipmentLineNumberColumn.ReadOnly = True
        Me.ShipmentLineNumberColumn.Width = 40
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part Number"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        Me.PartNumberColumn.Width = 120
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Part Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.Width = 130
        '
        'QuantityShippedColumn
        '
        Me.QuantityShippedColumn.DataPropertyName = "QuantityShipped"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.NullValue = "0"
        Me.QuantityShippedColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.QuantityShippedColumn.HeaderText = "Qty Shipped"
        Me.QuantityShippedColumn.Name = "QuantityShippedColumn"
        Me.QuantityShippedColumn.Width = 80
        '
        'PriceColumn
        '
        Me.PriceColumn.DataPropertyName = "Price"
        DataGridViewCellStyle3.Format = "N4"
        DataGridViewCellStyle3.NullValue = "0"
        Me.PriceColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PriceColumn.HeaderText = "Price"
        Me.PriceColumn.Name = "PriceColumn"
        Me.PriceColumn.Visible = False
        Me.PriceColumn.Width = 80
        '
        'LineBoxesColumn
        '
        Me.LineBoxesColumn.DataPropertyName = "LineBoxes"
        DataGridViewCellStyle4.Format = "N1"
        DataGridViewCellStyle4.NullValue = "0"
        Me.LineBoxesColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.LineBoxesColumn.HeaderText = "Line Boxes"
        Me.LineBoxesColumn.Name = "LineBoxesColumn"
        Me.LineBoxesColumn.Width = 80
        '
        'BoxWeightColumn
        '
        Me.BoxWeightColumn.DataPropertyName = "BoxWeight"
        Me.BoxWeightColumn.HeaderText = "Box Weight"
        Me.BoxWeightColumn.Name = "BoxWeightColumn"
        Me.BoxWeightColumn.Visible = False
        Me.BoxWeightColumn.Width = 80
        '
        'LineWeightColumn
        '
        Me.LineWeightColumn.DataPropertyName = "LineWeight"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.LineWeightColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.LineWeightColumn.HeaderText = "Line Weight"
        Me.LineWeightColumn.Name = "LineWeightColumn"
        Me.LineWeightColumn.Width = 80
        '
        'SerialNumberColumn
        '
        Me.SerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SerialNumberColumn.HeaderText = "Heat # / Lot #"
        Me.SerialNumberColumn.Name = "SerialNumberColumn"
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Line Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Visible = False
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "ExtendedAmount"
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
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
        'CertificationTypeColumn
        '
        Me.CertificationTypeColumn.DataPropertyName = "CertificationType"
        Me.CertificationTypeColumn.HeaderText = "Certification Type"
        Me.CertificationTypeColumn.Name = "CertificationTypeColumn"
        Me.CertificationTypeColumn.ReadOnly = True
        '
        'SOLineNumberColumn
        '
        Me.SOLineNumberColumn.DataPropertyName = "SOLineNumber"
        Me.SOLineNumberColumn.HeaderText = "SOLineNumber"
        Me.SOLineNumberColumn.Name = "SOLineNumberColumn"
        Me.SOLineNumberColumn.Visible = False
        '
        'LineCompleteColumn
        '
        Me.LineCompleteColumn.DataPropertyName = "LineComplete"
        Me.LineCompleteColumn.HeaderText = "Complete?"
        Me.LineCompleteColumn.Name = "LineCompleteColumn"
        Me.LineCompleteColumn.Width = 80
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
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'AdditionalShipToTableAdapter
        '
        Me.AdditionalShipToTableAdapter.ClearBeforeFill = True
        '
        'StateTableTableAdapter
        '
        Me.StateTableTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(10, 21)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(194, 20)
        Me.Label32.TabIndex = 37
        Me.Label32.Text = "Shipment Line #"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipmentLineNumber
        '
        Me.cboShipmentLineNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentLineNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentLineNumber.DataSource = Me.ShipmentLineTableBindingSource
        Me.cboShipmentLineNumber.DisplayMember = "ShipmentLineNumber"
        Me.cboShipmentLineNumber.FormattingEnabled = True
        Me.cboShipmentLineNumber.Location = New System.Drawing.Point(208, 22)
        Me.cboShipmentLineNumber.Name = "cboShipmentLineNumber"
        Me.cboShipmentLineNumber.Size = New System.Drawing.Size(112, 21)
        Me.cboShipmentLineNumber.TabIndex = 24
        '
        'cmdDeleteLotNumber
        '
        Me.cmdDeleteLotNumber.Location = New System.Drawing.Point(660, 198)
        Me.cmdDeleteLotNumber.Name = "cmdDeleteLotNumber"
        Me.cmdDeleteLotNumber.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteLotNumber.TabIndex = 31
        Me.cmdDeleteLotNumber.Text = "Delete"
        Me.cmdDeleteLotNumber.UseVisualStyleBackColor = True
        '
        'cmdAddLotNumber
        '
        Me.cmdAddLotNumber.Location = New System.Drawing.Point(249, 189)
        Me.cmdAddLotNumber.Name = "cmdAddLotNumber"
        Me.cmdAddLotNumber.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddLotNumber.TabIndex = 29
        Me.cmdAddLotNumber.Text = "Add Lot Number"
        Me.cmdAddLotNumber.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(10, 89)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(194, 20)
        Me.Label30.TabIndex = 32
        Me.Label30.Text = "Part Description"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(10, 55)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(194, 20)
        Me.Label29.TabIndex = 31
        Me.Label29.Text = "Part Number"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLotPartDescription
        '
        Me.cboLotPartDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLotPartDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLotPartDescription.DataSource = Me.ShipmentLineTableBindingSource
        Me.cboLotPartDescription.DisplayMember = "PartDescription"
        Me.cboLotPartDescription.DropDownWidth = 300
        Me.cboLotPartDescription.FormattingEnabled = True
        Me.cboLotPartDescription.Location = New System.Drawing.Point(113, 88)
        Me.cboLotPartDescription.Name = "cboLotPartDescription"
        Me.cboLotPartDescription.Size = New System.Drawing.Size(207, 21)
        Me.cboLotPartDescription.TabIndex = 26
        '
        'cboLinePartNumber
        '
        Me.cboLinePartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLinePartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLinePartNumber.DataSource = Me.ShipmentLineTableBindingSource
        Me.cboLinePartNumber.DisplayMember = "PartNumber"
        Me.cboLinePartNumber.DropDownWidth = 250
        Me.cboLinePartNumber.FormattingEnabled = True
        Me.cboLinePartNumber.Location = New System.Drawing.Point(113, 55)
        Me.cboLinePartNumber.Name = "cboLinePartNumber"
        Me.cboLinePartNumber.Size = New System.Drawing.Size(207, 21)
        Me.cboLinePartNumber.TabIndex = 25
        '
        'dgvAddedLotNumbers
        '
        Me.dgvAddedLotNumbers.AllowUserToAddRows = False
        Me.dgvAddedLotNumbers.AllowUserToDeleteRows = False
        Me.dgvAddedLotNumbers.AutoGenerateColumns = False
        Me.dgvAddedLotNumbers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAddedLotNumbers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAddedLotNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAddedLotNumbers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipmentNumberColumn2, Me.ShipmentLineNumberColumn2, Me.LotLineNumberColumn2, Me.LotNumberColumn2, Me.HeatQuantityColumn2, Me.PullTestNumberColumn2})
        Me.dgvAddedLotNumbers.DataSource = Me.ShipmentLineLotNumbersBindingSource
        Me.dgvAddedLotNumbers.GridColor = System.Drawing.Color.DarkBlue
        Me.dgvAddedLotNumbers.Location = New System.Drawing.Point(344, 19)
        Me.dgvAddedLotNumbers.Name = "dgvAddedLotNumbers"
        Me.dgvAddedLotNumbers.Size = New System.Drawing.Size(387, 174)
        Me.dgvAddedLotNumbers.TabIndex = 30
        Me.dgvAddedLotNumbers.TabStop = False
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
        Me.ShipmentLineNumberColumn2.FillWeight = 71.06599!
        Me.ShipmentLineNumberColumn2.HeaderText = "Line #"
        Me.ShipmentLineNumberColumn2.Name = "ShipmentLineNumberColumn2"
        Me.ShipmentLineNumberColumn2.ReadOnly = True
        Me.ShipmentLineNumberColumn2.Width = 50
        '
        'LotLineNumberColumn2
        '
        Me.LotLineNumberColumn2.DataPropertyName = "LotLineNumber"
        Me.LotLineNumberColumn2.HeaderText = "LotLineNumber"
        Me.LotLineNumberColumn2.Name = "LotLineNumberColumn2"
        Me.LotLineNumberColumn2.ReadOnly = True
        Me.LotLineNumberColumn2.Visible = False
        '
        'LotNumberColumn2
        '
        Me.LotNumberColumn2.DataPropertyName = "LotNumber"
        Me.LotNumberColumn2.FillWeight = 140.0!
        Me.LotNumberColumn2.HeaderText = "Lot Number"
        Me.LotNumberColumn2.Name = "LotNumberColumn2"
        Me.LotNumberColumn2.ReadOnly = True
        Me.LotNumberColumn2.Width = 120
        '
        'HeatQuantityColumn2
        '
        Me.HeatQuantityColumn2.DataPropertyName = "HeatQuantity"
        Me.HeatQuantityColumn2.HeaderText = "Heat Qty"
        Me.HeatQuantityColumn2.Name = "HeatQuantityColumn2"
        Me.HeatQuantityColumn2.Width = 80
        '
        'PullTestNumberColumn2
        '
        Me.PullTestNumberColumn2.DataPropertyName = "PullTestNumber"
        Me.PullTestNumberColumn2.HeaderText = "Test #"
        Me.PullTestNumberColumn2.Name = "PullTestNumberColumn2"
        Me.PullTestNumberColumn2.ReadOnly = True
        '
        'ShipmentLineLotNumbersBindingSource
        '
        Me.ShipmentLineLotNumbersBindingSource.DataMember = "ShipmentLineLotNumbers"
        Me.ShipmentLineLotNumbersBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'ShipmentLineLotNumbersTableAdapter
        '
        Me.ShipmentLineLotNumbersTableAdapter.ClearBeforeFill = True
        '
        'tabShipDetails
        '
        Me.tabShipDetails.Controls.Add(Me.tabShippingDetails)
        Me.tabShipDetails.Controls.Add(Me.tabShippingAddress)
        Me.tabShipDetails.Controls.Add(Me.tabCustomerOrders)
        Me.tabShipDetails.Controls.Add(Me.tabComment)
        Me.tabShipDetails.Controls.Add(Me.tabSpecialLabel)
        Me.tabShipDetails.Location = New System.Drawing.Point(33, 271)
        Me.tabShipDetails.Name = "tabShipDetails"
        Me.tabShipDetails.SelectedIndex = 0
        Me.tabShipDetails.Size = New System.Drawing.Size(332, 540)
        Me.tabShipDetails.TabIndex = 7
        '
        'tabShippingDetails
        '
        Me.tabShippingDetails.Controls.Add(Me.txtDoublePallets)
        Me.tabShippingDetails.Controls.Add(Me.txtTotalPalletsOnFloor)
        Me.tabShippingDetails.Controls.Add(Me.txtNumberPallets)
        Me.tabShippingDetails.Controls.Add(Me.Label25)
        Me.tabShippingDetails.Controls.Add(Me.Label3)
        Me.tabShippingDetails.Controls.Add(Me.Label40)
        Me.tabShippingDetails.Controls.Add(Me.txtShippingAccount)
        Me.tabShippingDetails.Controls.Add(Me.Label39)
        Me.tabShippingDetails.Controls.Add(Me.txtThirdPartyShipper)
        Me.tabShippingDetails.Controls.Add(Me.cboShipMethod)
        Me.tabShippingDetails.Controls.Add(Me.Label38)
        Me.tabShippingDetails.Controls.Add(Me.txtEstimatedWeight)
        Me.tabShippingDetails.Controls.Add(Me.Label21)
        Me.tabShippingDetails.Controls.Add(Me.Label26)
        Me.tabShippingDetails.Controls.Add(Me.cboShipVia)
        Me.tabShippingDetails.Controls.Add(Me.txtPRONumber)
        Me.tabShippingDetails.Controls.Add(Me.Label10)
        Me.tabShippingDetails.Controls.Add(Me.txtFreightQuoteNumber)
        Me.tabShippingDetails.Controls.Add(Me.Label11)
        Me.tabShippingDetails.Controls.Add(Me.txtQuotedFreight)
        Me.tabShippingDetails.Controls.Add(Me.txtActualFreight)
        Me.tabShippingDetails.Controls.Add(Me.Label12)
        Me.tabShippingDetails.Controls.Add(Me.txtShippingWeight)
        Me.tabShippingDetails.Controls.Add(Me.Label13)
        Me.tabShippingDetails.Controls.Add(Me.Label9)
        Me.tabShippingDetails.Controls.Add(Me.Label8)
        Me.tabShippingDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabShippingDetails.Name = "tabShippingDetails"
        Me.tabShippingDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabShippingDetails.Size = New System.Drawing.Size(324, 514)
        Me.tabShippingDetails.TabIndex = 0
        Me.tabShippingDetails.Text = "Ship. Details"
        Me.tabShippingDetails.UseVisualStyleBackColor = True
        '
        'txtDoublePallets
        '
        Me.txtDoublePallets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDoublePallets.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDoublePallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDoublePallets.Location = New System.Drawing.Point(182, 388)
        Me.txtDoublePallets.Name = "txtDoublePallets"
        Me.txtDoublePallets.Size = New System.Drawing.Size(130, 20)
        Me.txtDoublePallets.TabIndex = 16
        Me.txtDoublePallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPalletsOnFloor
        '
        Me.txtTotalPalletsOnFloor.BackColor = System.Drawing.Color.White
        Me.txtTotalPalletsOnFloor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPalletsOnFloor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalPalletsOnFloor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPalletsOnFloor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotalPalletsOnFloor.Location = New System.Drawing.Point(182, 418)
        Me.txtTotalPalletsOnFloor.Name = "txtTotalPalletsOnFloor"
        Me.txtTotalPalletsOnFloor.ReadOnly = True
        Me.txtTotalPalletsOnFloor.Size = New System.Drawing.Size(130, 20)
        Me.txtTotalPalletsOnFloor.TabIndex = 16
        Me.txtTotalPalletsOnFloor.TabStop = False
        Me.txtTotalPalletsOnFloor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(15, 388)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(167, 20)
        Me.Label25.TabIndex = 52
        Me.Label25.Text = "Double-stacked Pallets"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 418)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 20)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Total # of Pallets (on floor)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(15, 236)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(97, 20)
        Me.Label40.TabIndex = 48
        Me.Label40.Text = "Shipping Account"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShippingAccount
        '
        Me.txtShippingAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShippingAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShippingAccount.Location = New System.Drawing.Point(112, 236)
        Me.txtShippingAccount.Name = "txtShippingAccount"
        Me.txtShippingAccount.Size = New System.Drawing.Size(200, 20)
        Me.txtShippingAccount.TabIndex = 11
        Me.txtShippingAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(12, 76)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(303, 20)
        Me.Label39.TabIndex = 46
        Me.Label39.Text = "Third Party Shipping"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtThirdPartyShipper
        '
        Me.txtThirdPartyShipper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThirdPartyShipper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtThirdPartyShipper.Enabled = False
        Me.txtThirdPartyShipper.Location = New System.Drawing.Point(15, 98)
        Me.txtThirdPartyShipper.MaxLength = 500
        Me.txtThirdPartyShipper.Multiline = True
        Me.txtThirdPartyShipper.Name = "txtThirdPartyShipper"
        Me.txtThirdPartyShipper.Size = New System.Drawing.Size(297, 99)
        Me.txtThirdPartyShipper.TabIndex = 9
        '
        'cboShipMethod
        '
        Me.cboShipMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShipMethod.FormattingEnabled = True
        Me.cboShipMethod.Items.AddRange(New Object() {"COLLECT", "PREPAID", "PREPAID/ADD", "PREPAID/NOADD", "THIRD PARTY", "OTHER"})
        Me.cboShipMethod.Location = New System.Drawing.Point(90, 45)
        Me.cboShipMethod.MaxLength = 50
        Me.cboShipMethod.Name = "cboShipMethod"
        Me.cboShipMethod.Size = New System.Drawing.Size(222, 21)
        Me.cboShipMethod.TabIndex = 8
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(12, 46)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(97, 20)
        Me.Label38.TabIndex = 42
        Me.Label38.Text = "Ship Method"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEstimatedWeight
        '
        Me.txtEstimatedWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstimatedWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstimatedWeight.Enabled = False
        Me.txtEstimatedWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstimatedWeight.Location = New System.Drawing.Point(138, 458)
        Me.txtEstimatedWeight.Name = "txtEstimatedWeight"
        Me.txtEstimatedWeight.Size = New System.Drawing.Size(174, 20)
        Me.txtEstimatedWeight.TabIndex = 18
        Me.txtEstimatedWeight.TabStop = False
        Me.txtEstimatedWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(15, 458)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(133, 20)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "Estimated Total Weight"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabShippingAddress
        '
        Me.tabShippingAddress.Controls.Add(Me.txtCustomerID)
        Me.tabShippingAddress.Controls.Add(Me.cboSTCountryName)
        Me.tabShippingAddress.Controls.Add(Me.txtShipEmail)
        Me.tabShippingAddress.Controls.Add(Me.Label46)
        Me.tabShippingAddress.Controls.Add(Me.cboAdditionalShipTo)
        Me.tabShippingAddress.Controls.Add(Me.Label23)
        Me.tabShippingAddress.Controls.Add(Me.cmdPrintLabel)
        Me.tabShippingAddress.Controls.Add(Me.txtShipToName)
        Me.tabShippingAddress.Controls.Add(Me.Label22)
        Me.tabShippingAddress.Controls.Add(Me.Label24)
        Me.tabShippingAddress.Controls.Add(Me.txtShippingZip)
        Me.tabShippingAddress.Controls.Add(Me.Label17)
        Me.tabShippingAddress.Controls.Add(Me.cboShippingState)
        Me.tabShippingAddress.Controls.Add(Me.txtShippingCity)
        Me.tabShippingAddress.Controls.Add(Me.Label16)
        Me.tabShippingAddress.Controls.Add(Me.txtShippingCountry)
        Me.tabShippingAddress.Controls.Add(Me.txtShippingAddress1)
        Me.tabShippingAddress.Controls.Add(Me.txtShippingAddress2)
        Me.tabShippingAddress.Controls.Add(Me.Label18)
        Me.tabShippingAddress.Controls.Add(Me.Label6)
        Me.tabShippingAddress.Controls.Add(Me.Label7)
        Me.tabShippingAddress.Controls.Add(Me.Label15)
        Me.tabShippingAddress.Controls.Add(Me.Label14)
        Me.tabShippingAddress.Location = New System.Drawing.Point(4, 22)
        Me.tabShippingAddress.Name = "tabShippingAddress"
        Me.tabShippingAddress.Padding = New System.Windows.Forms.Padding(3)
        Me.tabShippingAddress.Size = New System.Drawing.Size(324, 514)
        Me.tabShippingAddress.TabIndex = 1
        Me.tabShippingAddress.Text = "Ship Address"
        Me.tabShippingAddress.UseVisualStyleBackColor = True
        '
        'txtCustomerID
        '
        Me.txtCustomerID.BackColor = System.Drawing.Color.White
        Me.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerID.Enabled = False
        Me.txtCustomerID.Location = New System.Drawing.Point(86, 15)
        Me.txtCustomerID.Name = "txtCustomerID"
        Me.txtCustomerID.ReadOnly = True
        Me.txtCustomerID.Size = New System.Drawing.Size(226, 20)
        Me.txtCustomerID.TabIndex = 38
        Me.txtCustomerID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboSTCountryName
        '
        Me.cboSTCountryName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSTCountryName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSTCountryName.DataSource = Me.CountryCodesBindingSource
        Me.cboSTCountryName.DisplayMember = "Country"
        Me.cboSTCountryName.FormattingEnabled = True
        Me.cboSTCountryName.Location = New System.Drawing.Point(58, 417)
        Me.cboSTCountryName.Name = "cboSTCountryName"
        Me.cboSTCountryName.Size = New System.Drawing.Size(187, 21)
        Me.cboSTCountryName.TabIndex = 37
        '
        'CountryCodesBindingSource
        '
        Me.CountryCodesBindingSource.DataMember = "CountryCodes"
        Me.CountryCodesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtShipEmail
        '
        Me.txtShipEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipEmail.Location = New System.Drawing.Point(58, 447)
        Me.txtShipEmail.Name = "txtShipEmail"
        Me.txtShipEmail.Size = New System.Drawing.Size(254, 20)
        Me.txtShipEmail.TabIndex = 24
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(9, 450)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(83, 20)
        Me.Label46.TabIndex = 36
        Me.Label46.Text = "Email"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(30, 483)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(187, 20)
        Me.Label23.TabIndex = 34
        Me.Label23.Text = "Prints Shipping Label to label printer."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintLabel
        '
        Me.cmdPrintLabel.Location = New System.Drawing.Point(241, 478)
        Me.cmdPrintLabel.Name = "cmdPrintLabel"
        Me.cmdPrintLabel.Size = New System.Drawing.Size(71, 30)
        Me.cmdPrintLabel.TabIndex = 33
        Me.cmdPrintLabel.Text = "Ship Label"
        Me.cmdPrintLabel.UseVisualStyleBackColor = True
        '
        'txtShipToName
        '
        Me.txtShipToName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipToName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipToName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipToName.Location = New System.Drawing.Point(12, 94)
        Me.txtShipToName.Multiline = True
        Me.txtShipToName.Name = "txtShipToName"
        Me.txtShipToName.Size = New System.Drawing.Size(300, 48)
        Me.txtShipToName.TabIndex = 17
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(9, 76)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(75, 15)
        Me.Label22.TabIndex = 32
        Me.Label22.Text = "Ship To Name"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabCustomerOrders
        '
        Me.tabCustomerOrders.Controls.Add(Me.Label35)
        Me.tabCustomerOrders.Controls.Add(Me.dgvOpenOrderLines)
        Me.tabCustomerOrders.Location = New System.Drawing.Point(4, 22)
        Me.tabCustomerOrders.Name = "tabCustomerOrders"
        Me.tabCustomerOrders.Size = New System.Drawing.Size(324, 514)
        Me.tabCustomerOrders.TabIndex = 2
        Me.tabCustomerOrders.Text = "Open Orders"
        Me.tabCustomerOrders.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Blue
        Me.Label35.Location = New System.Drawing.Point(6, 478)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(292, 36)
        Me.Label35.TabIndex = 42
        Me.Label35.Text = "Double click item in datagrid to view the Sales Order."
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvOpenOrderLines
        '
        Me.dgvOpenOrderLines.AllowUserToAddRows = False
        Me.dgvOpenOrderLines.AllowUserToDeleteRows = False
        Me.dgvOpenOrderLines.AutoGenerateColumns = False
        Me.dgvOpenOrderLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvOpenOrderLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOpenOrderLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOpenOrderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpenOrderLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OOSalesOrderColumn, Me.OOSalesOrderKeyColumn, Me.OOItemIDColumn, Me.OODescriptionColumn, Me.OOOpenSOQuantityColumn, Me.OOPriceColumn, Me.OODivisionKeyColumn, Me.OOSOStatusColumn, Me.OOCustomerIDColumn, Me.OOLineStatusColumn})
        Me.dgvOpenOrderLines.DataSource = Me.SalesOrderLineQueryNoQOHBindingSource
        Me.dgvOpenOrderLines.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvOpenOrderLines.Location = New System.Drawing.Point(0, 0)
        Me.dgvOpenOrderLines.Name = "dgvOpenOrderLines"
        Me.dgvOpenOrderLines.ReadOnly = True
        Me.dgvOpenOrderLines.Size = New System.Drawing.Size(324, 475)
        Me.dgvOpenOrderLines.TabIndex = 0
        '
        'OOSalesOrderColumn
        '
        Me.OOSalesOrderColumn.DataPropertyName = "SalesOrderDate"
        Me.OOSalesOrderColumn.HeaderText = "SO Date"
        Me.OOSalesOrderColumn.Name = "OOSalesOrderColumn"
        Me.OOSalesOrderColumn.ReadOnly = True
        Me.OOSalesOrderColumn.Width = 60
        '
        'OOSalesOrderKeyColumn
        '
        Me.OOSalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.OOSalesOrderKeyColumn.HeaderText = "SO #"
        Me.OOSalesOrderKeyColumn.Name = "OOSalesOrderKeyColumn"
        Me.OOSalesOrderKeyColumn.ReadOnly = True
        Me.OOSalesOrderKeyColumn.Width = 60
        '
        'OOItemIDColumn
        '
        Me.OOItemIDColumn.DataPropertyName = "ItemID"
        Me.OOItemIDColumn.HeaderText = "Part #"
        Me.OOItemIDColumn.Name = "OOItemIDColumn"
        Me.OOItemIDColumn.ReadOnly = True
        '
        'OODescriptionColumn
        '
        Me.OODescriptionColumn.DataPropertyName = "Description"
        Me.OODescriptionColumn.HeaderText = "Description"
        Me.OODescriptionColumn.Name = "OODescriptionColumn"
        Me.OODescriptionColumn.ReadOnly = True
        '
        'OOOpenSOQuantityColumn
        '
        Me.OOOpenSOQuantityColumn.DataPropertyName = "OpenSOQuantity"
        Me.OOOpenSOQuantityColumn.HeaderText = "Open Qty"
        Me.OOOpenSOQuantityColumn.Name = "OOOpenSOQuantityColumn"
        Me.OOOpenSOQuantityColumn.ReadOnly = True
        Me.OOOpenSOQuantityColumn.Width = 60
        '
        'OOPriceColumn
        '
        Me.OOPriceColumn.DataPropertyName = "Price"
        Me.OOPriceColumn.HeaderText = "Price"
        Me.OOPriceColumn.Name = "OOPriceColumn"
        Me.OOPriceColumn.ReadOnly = True
        Me.OOPriceColumn.Width = 60
        '
        'OODivisionKeyColumn
        '
        Me.OODivisionKeyColumn.DataPropertyName = "DivisionKey"
        Me.OODivisionKeyColumn.HeaderText = "DivisionKey"
        Me.OODivisionKeyColumn.Name = "OODivisionKeyColumn"
        Me.OODivisionKeyColumn.ReadOnly = True
        Me.OODivisionKeyColumn.Visible = False
        '
        'OOSOStatusColumn
        '
        Me.OOSOStatusColumn.DataPropertyName = "SOStatus"
        Me.OOSOStatusColumn.HeaderText = "SOStatus"
        Me.OOSOStatusColumn.Name = "OOSOStatusColumn"
        Me.OOSOStatusColumn.ReadOnly = True
        Me.OOSOStatusColumn.Visible = False
        '
        'OOCustomerIDColumn
        '
        Me.OOCustomerIDColumn.DataPropertyName = "CustomerID"
        Me.OOCustomerIDColumn.HeaderText = "CustomerID"
        Me.OOCustomerIDColumn.Name = "OOCustomerIDColumn"
        Me.OOCustomerIDColumn.ReadOnly = True
        Me.OOCustomerIDColumn.Visible = False
        '
        'OOLineStatusColumn
        '
        Me.OOLineStatusColumn.DataPropertyName = "LineStatus"
        Me.OOLineStatusColumn.HeaderText = "LineStatus"
        Me.OOLineStatusColumn.Name = "OOLineStatusColumn"
        Me.OOLineStatusColumn.ReadOnly = True
        Me.OOLineStatusColumn.Visible = False
        '
        'SalesOrderLineQueryNoQOHBindingSource
        '
        Me.SalesOrderLineQueryNoQOHBindingSource.DataMember = "SalesOrderLineQueryNoQOH"
        Me.SalesOrderLineQueryNoQOHBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tabComment
        '
        Me.tabComment.Controls.Add(Me.Label20)
        Me.tabComment.Controls.Add(Me.txtComments)
        Me.tabComment.Controls.Add(Me.Label37)
        Me.tabComment.Controls.Add(Me.Label36)
        Me.tabComment.Controls.Add(Me.txtHeaderComment)
        Me.tabComment.Controls.Add(Me.dgvUPSData)
        Me.tabComment.Location = New System.Drawing.Point(4, 22)
        Me.tabComment.Name = "tabComment"
        Me.tabComment.Size = New System.Drawing.Size(324, 514)
        Me.tabComment.TabIndex = 3
        Me.tabComment.Text = "Comment"
        Me.tabComment.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(9, 313)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(303, 20)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "Special Instructions (500 Characters)"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComments
        '
        Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComments.Location = New System.Drawing.Point(12, 336)
        Me.txtComments.MaxLength = 500
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(300, 175)
        Me.txtComments.TabIndex = 43
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Blue
        Me.Label37.Location = New System.Drawing.Point(20, 240)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(292, 35)
        Me.Label37.TabIndex = 40
        Me.Label37.Text = "Header comments do not print out on external documents, only Special Shipping Ins" & _
            "tructions do. "
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(9, 12)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(303, 20)
        Me.Label36.TabIndex = 30
        Me.Label36.Text = "Header Comment (500 Characters)"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHeaderComment
        '
        Me.txtHeaderComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeaderComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeaderComment.Location = New System.Drawing.Point(12, 35)
        Me.txtHeaderComment.MaxLength = 500
        Me.txtHeaderComment.Multiline = True
        Me.txtHeaderComment.Name = "txtHeaderComment"
        Me.txtHeaderComment.Size = New System.Drawing.Size(300, 175)
        Me.txtHeaderComment.TabIndex = 15
        '
        'dgvUPSData
        '
        Me.dgvUPSData.AllowUserToAddRows = False
        Me.dgvUPSData.AllowUserToDeleteRows = False
        Me.dgvUPSData.AutoGenerateColumns = False
        Me.dgvUPSData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUPSData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PickTicketNumberColumn5, Me.TrackingNumberColumn5, Me.VoidIndicatorColumn5, Me.TransactionNumberColumn5})
        Me.dgvUPSData.DataSource = Me.UPSShippingDataBindingSource
        Me.dgvUPSData.Location = New System.Drawing.Point(27, 49)
        Me.dgvUPSData.Name = "dgvUPSData"
        Me.dgvUPSData.ReadOnly = True
        Me.dgvUPSData.Size = New System.Drawing.Size(274, 141)
        Me.dgvUPSData.TabIndex = 45
        Me.dgvUPSData.Visible = False
        '
        'PickTicketNumberColumn5
        '
        Me.PickTicketNumberColumn5.DataPropertyName = "PickTicketNumber"
        Me.PickTicketNumberColumn5.HeaderText = "PickTicketNumber"
        Me.PickTicketNumberColumn5.Name = "PickTicketNumberColumn5"
        Me.PickTicketNumberColumn5.ReadOnly = True
        '
        'TrackingNumberColumn5
        '
        Me.TrackingNumberColumn5.DataPropertyName = "TrackingNumber"
        Me.TrackingNumberColumn5.HeaderText = "TrackingNumber"
        Me.TrackingNumberColumn5.Name = "TrackingNumberColumn5"
        Me.TrackingNumberColumn5.ReadOnly = True
        '
        'VoidIndicatorColumn5
        '
        Me.VoidIndicatorColumn5.DataPropertyName = "VoidIndicator"
        Me.VoidIndicatorColumn5.HeaderText = "VoidIndicator"
        Me.VoidIndicatorColumn5.Name = "VoidIndicatorColumn5"
        Me.VoidIndicatorColumn5.ReadOnly = True
        '
        'TransactionNumberColumn5
        '
        Me.TransactionNumberColumn5.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn5.HeaderText = "TransactionNumber"
        Me.TransactionNumberColumn5.Name = "TransactionNumberColumn5"
        Me.TransactionNumberColumn5.ReadOnly = True
        '
        'UPSShippingDataBindingSource
        '
        Me.UPSShippingDataBindingSource.DataMember = "UPSShippingData"
        Me.UPSShippingDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tabSpecialLabel
        '
        Me.tabSpecialLabel.Controls.Add(Me.Label28)
        Me.tabSpecialLabel.Controls.Add(Me.cmdPrintCustomLabel)
        Me.tabSpecialLabel.Controls.Add(Me.txtSpecialLabelLine3)
        Me.tabSpecialLabel.Controls.Add(Me.txtSpecialLabelLine2)
        Me.tabSpecialLabel.Controls.Add(Me.txtSpecialLabelLine1)
        Me.tabSpecialLabel.Controls.Add(Me.Label80)
        Me.tabSpecialLabel.Controls.Add(Me.Label79)
        Me.tabSpecialLabel.Controls.Add(Me.Label78)
        Me.tabSpecialLabel.Controls.Add(Me.Label77)
        Me.tabSpecialLabel.Location = New System.Drawing.Point(4, 22)
        Me.tabSpecialLabel.Name = "tabSpecialLabel"
        Me.tabSpecialLabel.Size = New System.Drawing.Size(324, 514)
        Me.tabSpecialLabel.TabIndex = 4
        Me.tabSpecialLabel.Text = "Label"
        Me.tabSpecialLabel.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Blue
        Me.Label28.Location = New System.Drawing.Point(18, 347)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(279, 104)
        Me.Label28.TabIndex = 40
        Me.Label28.Text = "This will print a special label to mark every pallet with. (if # of pallets is ze" & _
            "ro, it will print one label). "
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdPrintCustomLabel
        '
        Me.cmdPrintCustomLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintCustomLabel.Location = New System.Drawing.Point(226, 294)
        Me.cmdPrintCustomLabel.Name = "cmdPrintCustomLabel"
        Me.cmdPrintCustomLabel.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintCustomLabel.TabIndex = 33
        Me.cmdPrintCustomLabel.Text = "Print Label"
        Me.cmdPrintCustomLabel.UseVisualStyleBackColor = True
        '
        'txtSpecialLabelLine3
        '
        Me.txtSpecialLabelLine3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialLabelLine3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpecialLabelLine3.Location = New System.Drawing.Point(21, 248)
        Me.txtSpecialLabelLine3.MaxLength = 25
        Me.txtSpecialLabelLine3.Name = "txtSpecialLabelLine3"
        Me.txtSpecialLabelLine3.Size = New System.Drawing.Size(276, 20)
        Me.txtSpecialLabelLine3.TabIndex = 22
        Me.txtSpecialLabelLine3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSpecialLabelLine2
        '
        Me.txtSpecialLabelLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialLabelLine2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpecialLabelLine2.Location = New System.Drawing.Point(21, 182)
        Me.txtSpecialLabelLine2.MaxLength = 25
        Me.txtSpecialLabelLine2.Name = "txtSpecialLabelLine2"
        Me.txtSpecialLabelLine2.Size = New System.Drawing.Size(276, 20)
        Me.txtSpecialLabelLine2.TabIndex = 21
        Me.txtSpecialLabelLine2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSpecialLabelLine1
        '
        Me.txtSpecialLabelLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialLabelLine1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpecialLabelLine1.Location = New System.Drawing.Point(21, 115)
        Me.txtSpecialLabelLine1.MaxLength = 25
        Me.txtSpecialLabelLine1.Name = "txtSpecialLabelLine1"
        Me.txtSpecialLabelLine1.Size = New System.Drawing.Size(276, 20)
        Me.txtSpecialLabelLine1.TabIndex = 20
        Me.txtSpecialLabelLine1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label80
        '
        Me.Label80.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.Location = New System.Drawing.Point(18, 159)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(89, 20)
        Me.Label80.TabIndex = 26
        Me.Label80.Text = "Line #2"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label79
        '
        Me.Label79.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.Location = New System.Drawing.Point(18, 225)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(89, 20)
        Me.Label79.TabIndex = 25
        Me.Label79.Text = "Line #3"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label78
        '
        Me.Label78.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.Location = New System.Drawing.Point(18, 92)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(89, 20)
        Me.Label78.TabIndex = 24
        Me.Label78.Text = "Line #1"
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label77
        '
        Me.Label77.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.Blue
        Me.Label77.Location = New System.Drawing.Point(18, 18)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(294, 54)
        Me.Label77.TabIndex = 23
        Me.Label77.Text = "Create custom label for shipping (MAX 24 characters per line)"
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxShipmentLineLotNumbers
        '
        Me.gpxShipmentLineLotNumbers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.cmdPrintBoxLabel)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.txtHeatQuantity)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.Label31)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.txtLotNumber)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.cboShipmentLineNumber)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.dgvAddedLotNumbers)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.cmdAddLotNumber)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.cboLotPartDescription)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.cmdDeleteLotNumber)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.cboLinePartNumber)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.llViewLotNumbers)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.Label33)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.Label29)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.Label32)
        Me.gpxShipmentLineLotNumbers.Controls.Add(Me.Label30)
        Me.gpxShipmentLineLotNumbers.Location = New System.Drawing.Point(6, 4)
        Me.gpxShipmentLineLotNumbers.Name = "gpxShipmentLineLotNumbers"
        Me.gpxShipmentLineLotNumbers.Size = New System.Drawing.Size(737, 235)
        Me.gpxShipmentLineLotNumbers.TabIndex = 24
        Me.gpxShipmentLineLotNumbers.TabStop = False
        Me.gpxShipmentLineLotNumbers.Text = "Add Line Lot Numbers"
        '
        'cmdPrintBoxLabel
        '
        Me.cmdPrintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintBoxLabel.ForeColor = System.Drawing.Color.Red
        Me.cmdPrintBoxLabel.Location = New System.Drawing.Point(147, 153)
        Me.cmdPrintBoxLabel.Name = "cmdPrintBoxLabel"
        Me.cmdPrintBoxLabel.Size = New System.Drawing.Size(30, 20)
        Me.cmdPrintBoxLabel.TabIndex = 44
        Me.cmdPrintBoxLabel.Text = ">>>"
        Me.cmdPrintBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrintBoxLabel.UseVisualStyleBackColor = True
        '
        'txtHeatQuantity
        '
        Me.txtHeatQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeatQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeatQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeatQuantity.Location = New System.Drawing.Point(183, 153)
        Me.txtHeatQuantity.Name = "txtHeatQuantity"
        Me.txtHeatQuantity.Size = New System.Drawing.Size(137, 20)
        Me.txtHeatQuantity.TabIndex = 28
        Me.txtHeatQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Blue
        Me.Label31.Location = New System.Drawing.Point(424, 197)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(163, 32)
        Me.Label31.TabIndex = 41
        Me.Label31.Text = "Select Lot # in grid to delete."
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLotNumber
        '
        Me.txtLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLotNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLotNumber.Location = New System.Drawing.Point(113, 121)
        Me.txtLotNumber.Name = "txtLotNumber"
        Me.txtLotNumber.Size = New System.Drawing.Size(207, 20)
        Me.txtLotNumber.TabIndex = 27
        Me.txtLotNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'llViewLotNumbers
        '
        Me.llViewLotNumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llViewLotNumbers.LinkColor = System.Drawing.Color.Black
        Me.llViewLotNumbers.Location = New System.Drawing.Point(10, 121)
        Me.llViewLotNumbers.Name = "llViewLotNumbers"
        Me.llViewLotNumbers.Size = New System.Drawing.Size(194, 20)
        Me.llViewLotNumbers.TabIndex = 45
        Me.llViewLotNumbers.TabStop = True
        Me.llViewLotNumbers.Text = "Lot Number"
        Me.llViewLotNumbers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(10, 153)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(194, 20)
        Me.Label33.TabIndex = 43
        Me.Label33.Text = "Qty of Heat # / Lot #"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PickListHeaderTableTableAdapter
        '
        Me.PickListHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(380, 751)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(147, 40)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "You must complete shipment before it can be invoiced."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(906, 772)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 41
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdPackingList
        '
        Me.cmdPackingList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPackingList.Location = New System.Drawing.Point(752, 723)
        Me.cmdPackingList.Name = "cmdPackingList"
        Me.cmdPackingList.Size = New System.Drawing.Size(71, 40)
        Me.cmdPackingList.TabIndex = 33
        Me.cmdPackingList.Text = "Packing List"
        Me.cmdPackingList.UseVisualStyleBackColor = True
        '
        'cmdTWCert
        '
        Me.cmdTWCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTWCert.Location = New System.Drawing.Point(983, 723)
        Me.cmdTWCert.Name = "cmdTWCert"
        Me.cmdTWCert.Size = New System.Drawing.Size(71, 40)
        Me.cmdTWCert.TabIndex = 36
        Me.cmdTWCert.Text = "TW Cert"
        Me.cmdTWCert.UseVisualStyleBackColor = True
        '
        'cmdBOL
        '
        Me.cmdBOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBOL.Location = New System.Drawing.Point(906, 723)
        Me.cmdBOL.Name = "cmdBOL"
        Me.cmdBOL.Size = New System.Drawing.Size(71, 40)
        Me.cmdBOL.TabIndex = 35
        Me.cmdBOL.Text = "Bill of Lading"
        Me.cmdBOL.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(829, 772)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(71, 40)
        Me.cmdClear.TabIndex = 40
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdPrintAll
        '
        Me.cmdPrintAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPrintAll.Location = New System.Drawing.Point(1059, 723)
        Me.cmdPrintAll.Name = "cmdPrintAll"
        Me.cmdPrintAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintAll.TabIndex = 37
        Me.cmdPrintAll.Text = "Print All Docs"
        Me.cmdPrintAll.UseVisualStyleBackColor = True
        '
        'cmdPrintShippingLabel
        '
        Me.cmdPrintShippingLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrintShippingLabel.Location = New System.Drawing.Point(829, 723)
        Me.cmdPrintShippingLabel.Name = "cmdPrintShippingLabel"
        Me.cmdPrintShippingLabel.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrintShippingLabel.TabIndex = 34
        Me.cmdPrintShippingLabel.Text = "Shipping Label"
        Me.cmdPrintShippingLabel.UseVisualStyleBackColor = True
        '
        'cmdSalesOrderForm
        '
        Me.cmdSalesOrderForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalesOrderForm.Location = New System.Drawing.Point(752, 772)
        Me.cmdSalesOrderForm.Name = "cmdSalesOrderForm"
        Me.cmdSalesOrderForm.Size = New System.Drawing.Size(71, 40)
        Me.cmdSalesOrderForm.TabIndex = 39
        Me.cmdSalesOrderForm.Text = "Sales Order"
        Me.cmdSalesOrderForm.UseVisualStyleBackColor = True
        '
        'SalesOrderLineQueryNoQOHTableAdapter
        '
        Me.SalesOrderLineQueryNoQOHTableAdapter.ClearBeforeFill = True
        '
        'tabAddSubLines
        '
        Me.tabAddSubLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabAddSubLines.Controls.Add(Me.tabAddLots)
        Me.tabAddSubLines.Controls.Add(Me.tabAddSerial)
        Me.tabAddSubLines.Location = New System.Drawing.Point(379, 452)
        Me.tabAddSubLines.Name = "tabAddSubLines"
        Me.tabAddSubLines.SelectedIndex = 0
        Me.tabAddSubLines.Size = New System.Drawing.Size(751, 265)
        Me.tabAddSubLines.TabIndex = 44
        '
        'tabAddLots
        '
        Me.tabAddLots.Controls.Add(Me.gpxShipmentLineLotNumbers)
        Me.tabAddLots.Location = New System.Drawing.Point(4, 22)
        Me.tabAddLots.Name = "tabAddLots"
        Me.tabAddLots.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAddLots.Size = New System.Drawing.Size(743, 239)
        Me.tabAddLots.TabIndex = 0
        Me.tabAddLots.Text = "Add Lot #"
        Me.tabAddLots.UseVisualStyleBackColor = True
        '
        'tabAddSerial
        '
        Me.tabAddSerial.Controls.Add(Me.GroupBox1)
        Me.tabAddSerial.Location = New System.Drawing.Point(4, 22)
        Me.tabAddSerial.Name = "tabAddSerial"
        Me.tabAddSerial.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAddSerial.Size = New System.Drawing.Size(743, 239)
        Me.tabAddSerial.TabIndex = 1
        Me.tabAddSerial.Text = "Add Serial #"
        Me.tabAddSerial.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdAddMultiple)
        Me.GroupBox1.Controls.Add(Me.txtLinePartDescription2)
        Me.GroupBox1.Controls.Add(Me.txtLinePartNumber2)
        Me.GroupBox1.Controls.Add(Me.dgvSerialLog)
        Me.GroupBox1.Controls.Add(Me.Label41)
        Me.GroupBox1.Controls.Add(Me.txtLineSerialNumber2)
        Me.GroupBox1.Controls.Add(Me.cboShipmentLineNumber2)
        Me.GroupBox1.Controls.Add(Me.cmdAddSerialNumber)
        Me.GroupBox1.Controls.Add(Me.cmdDeleteSerialNumber)
        Me.GroupBox1.Controls.Add(Me.Label42)
        Me.GroupBox1.Controls.Add(Me.Label43)
        Me.GroupBox1.Controls.Add(Me.Label44)
        Me.GroupBox1.Controls.Add(Me.Label45)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(740, 235)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Line Serial Numbers"
        '
        'cmdAddMultiple
        '
        Me.cmdAddMultiple.Location = New System.Drawing.Point(22, 189)
        Me.cmdAddMultiple.Name = "cmdAddMultiple"
        Me.cmdAddMultiple.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddMultiple.TabIndex = 45
        Me.cmdAddMultiple.Text = "Add Multiple"
        Me.cmdAddMultiple.UseVisualStyleBackColor = True
        '
        'txtLinePartDescription2
        '
        Me.txtLinePartDescription2.BackColor = System.Drawing.Color.White
        Me.txtLinePartDescription2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinePartDescription2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinePartDescription2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLinePartDescription2.Location = New System.Drawing.Point(113, 109)
        Me.txtLinePartDescription2.Name = "txtLinePartDescription2"
        Me.txtLinePartDescription2.ReadOnly = True
        Me.txtLinePartDescription2.Size = New System.Drawing.Size(207, 20)
        Me.txtLinePartDescription2.TabIndex = 44
        Me.txtLinePartDescription2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLinePartNumber2
        '
        Me.txtLinePartNumber2.BackColor = System.Drawing.Color.White
        Me.txtLinePartNumber2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLinePartNumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinePartNumber2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLinePartNumber2.Location = New System.Drawing.Point(113, 70)
        Me.txtLinePartNumber2.Name = "txtLinePartNumber2"
        Me.txtLinePartNumber2.ReadOnly = True
        Me.txtLinePartNumber2.Size = New System.Drawing.Size(207, 20)
        Me.txtLinePartNumber2.TabIndex = 43
        Me.txtLinePartNumber2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvSerialLog
        '
        Me.dgvSerialLog.AllowUserToAddRows = False
        Me.dgvSerialLog.AllowUserToDeleteRows = False
        Me.dgvSerialLog.AutoGenerateColumns = False
        Me.dgvSerialLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSerialLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSerialLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SLShipmentNumberColumn, Me.SLShipmentLineNumberColumn, Me.SLSerialNumberColumn, Me.SLSerialLineNumberColumn, Me.SLSerialCostColumn, Me.SLSerialQuantityColumn})
        Me.dgvSerialLog.DataSource = Me.ShipmentLineSerialNumbersBindingSource
        Me.dgvSerialLog.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvSerialLog.Location = New System.Drawing.Point(366, 19)
        Me.dgvSerialLog.Name = "dgvSerialLog"
        Me.dgvSerialLog.ReadOnly = True
        Me.dgvSerialLog.Size = New System.Drawing.Size(329, 166)
        Me.dgvSerialLog.TabIndex = 42
        '
        'SLShipmentNumberColumn
        '
        Me.SLShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.SLShipmentNumberColumn.HeaderText = "ShipmentNumber"
        Me.SLShipmentNumberColumn.Name = "SLShipmentNumberColumn"
        Me.SLShipmentNumberColumn.ReadOnly = True
        Me.SLShipmentNumberColumn.Visible = False
        '
        'SLShipmentLineNumberColumn
        '
        Me.SLShipmentLineNumberColumn.DataPropertyName = "ShipmentLineNumber"
        Me.SLShipmentLineNumberColumn.HeaderText = "Line #"
        Me.SLShipmentLineNumberColumn.Name = "SLShipmentLineNumberColumn"
        Me.SLShipmentLineNumberColumn.ReadOnly = True
        Me.SLShipmentLineNumberColumn.Width = 65
        '
        'SLSerialNumberColumn
        '
        Me.SLSerialNumberColumn.DataPropertyName = "SerialNumber"
        Me.SLSerialNumberColumn.HeaderText = "Serial #"
        Me.SLSerialNumberColumn.Name = "SLSerialNumberColumn"
        Me.SLSerialNumberColumn.ReadOnly = True
        Me.SLSerialNumberColumn.Width = 180
        '
        'SLSerialLineNumberColumn
        '
        Me.SLSerialLineNumberColumn.DataPropertyName = "SerialLineNumber"
        Me.SLSerialLineNumberColumn.HeaderText = "SerialLineNumber"
        Me.SLSerialLineNumberColumn.Name = "SLSerialLineNumberColumn"
        Me.SLSerialLineNumberColumn.ReadOnly = True
        Me.SLSerialLineNumberColumn.Visible = False
        '
        'SLSerialCostColumn
        '
        Me.SLSerialCostColumn.DataPropertyName = "SerialCost"
        Me.SLSerialCostColumn.HeaderText = "SerialCost"
        Me.SLSerialCostColumn.Name = "SLSerialCostColumn"
        Me.SLSerialCostColumn.ReadOnly = True
        Me.SLSerialCostColumn.Visible = False
        '
        'SLSerialQuantityColumn
        '
        Me.SLSerialQuantityColumn.DataPropertyName = "SerialQuantity"
        Me.SLSerialQuantityColumn.HeaderText = "SerialQuantity"
        Me.SLSerialQuantityColumn.Name = "SLSerialQuantityColumn"
        Me.SLSerialQuantityColumn.ReadOnly = True
        Me.SLSerialQuantityColumn.Visible = False
        '
        'ShipmentLineSerialNumbersBindingSource
        '
        Me.ShipmentLineSerialNumbersBindingSource.DataMember = "ShipmentLineSerialNumbers"
        Me.ShipmentLineSerialNumbersBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Blue
        Me.Label41.Location = New System.Drawing.Point(425, 197)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(163, 32)
        Me.Label41.TabIndex = 41
        Me.Label41.Text = "Select Serial # in grid to delete."
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineSerialNumber2
        '
        Me.txtLineSerialNumber2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineSerialNumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineSerialNumber2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLineSerialNumber2.Location = New System.Drawing.Point(113, 149)
        Me.txtLineSerialNumber2.Name = "txtLineSerialNumber2"
        Me.txtLineSerialNumber2.Size = New System.Drawing.Size(207, 20)
        Me.txtLineSerialNumber2.TabIndex = 27
        Me.txtLineSerialNumber2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboShipmentLineNumber2
        '
        Me.cboShipmentLineNumber2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipmentLineNumber2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipmentLineNumber2.DataSource = Me.ShipmentLineTableBindingSource
        Me.cboShipmentLineNumber2.DisplayMember = "ShipmentLineNumber"
        Me.cboShipmentLineNumber2.FormattingEnabled = True
        Me.cboShipmentLineNumber2.Location = New System.Drawing.Point(208, 29)
        Me.cboShipmentLineNumber2.Name = "cboShipmentLineNumber2"
        Me.cboShipmentLineNumber2.Size = New System.Drawing.Size(112, 21)
        Me.cboShipmentLineNumber2.TabIndex = 24
        '
        'cmdAddSerialNumber
        '
        Me.cmdAddSerialNumber.Location = New System.Drawing.Point(249, 189)
        Me.cmdAddSerialNumber.Name = "cmdAddSerialNumber"
        Me.cmdAddSerialNumber.Size = New System.Drawing.Size(71, 40)
        Me.cmdAddSerialNumber.TabIndex = 29
        Me.cmdAddSerialNumber.Text = "Add Serial Number"
        Me.cmdAddSerialNumber.UseVisualStyleBackColor = True
        '
        'cmdDeleteSerialNumber
        '
        Me.cmdDeleteSerialNumber.Location = New System.Drawing.Point(624, 195)
        Me.cmdDeleteSerialNumber.Name = "cmdDeleteSerialNumber"
        Me.cmdDeleteSerialNumber.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteSerialNumber.TabIndex = 31
        Me.cmdDeleteSerialNumber.Text = "Delete"
        Me.cmdDeleteSerialNumber.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(19, 70)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(124, 20)
        Me.Label42.TabIndex = 31
        Me.Label42.Text = "Part Number"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(19, 30)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(124, 20)
        Me.Label43.TabIndex = 37
        Me.Label43.Text = "Shipment Line #"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(19, 110)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(124, 20)
        Me.Label44.TabIndex = 32
        Me.Label44.Text = "Description"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(19, 149)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(124, 20)
        Me.Label45.TabIndex = 28
        Me.Label45.Text = "Serial Number"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShipmentLineSerialNumbersTableAdapter
        '
        Me.ShipmentLineSerialNumbersTableAdapter.ClearBeforeFill = True
        '
        'CountryCodesTableAdapter
        '
        Me.CountryCodesTableAdapter.ClearBeforeFill = True
        '
        'UPSShippingDataTableAdapter
        '
        Me.UPSShippingDataTableAdapter.ClearBeforeFill = True
        '
        'cmdUploadPickTicket
        '
        Me.cmdUploadPickTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadPickTicket.Location = New System.Drawing.Point(675, 772)
        Me.cmdUploadPickTicket.Name = "cmdUploadPickTicket"
        Me.cmdUploadPickTicket.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadPickTicket.TabIndex = 45
        Me.cmdUploadPickTicket.Text = "Upload Pick Ticket"
        Me.cmdUploadPickTicket.UseVisualStyleBackColor = True
        '
        'cmdViewPickTicket
        '
        Me.cmdViewPickTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPickTicket.Location = New System.Drawing.Point(675, 772)
        Me.cmdViewPickTicket.Name = "cmdViewPickTicket"
        Me.cmdViewPickTicket.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPickTicket.TabIndex = 46
        Me.cmdViewPickTicket.Text = "View Pick Ticket"
        Me.cmdViewPickTicket.UseVisualStyleBackColor = True
        '
        'cmdRemoteScan
        '
        Me.cmdRemoteScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoteScan.Location = New System.Drawing.Point(675, 772)
        Me.cmdRemoteScan.Name = "cmdRemoteScan"
        Me.cmdRemoteScan.Size = New System.Drawing.Size(71, 40)
        Me.cmdRemoteScan.TabIndex = 47
        Me.cmdRemoteScan.Text = "Upload Pick Ticket"
        Me.cmdRemoteScan.UseVisualStyleBackColor = True
        '
        'UploadPickTicketToolStripMenuItem
        '
        Me.UploadPickTicketToolStripMenuItem.Name = "UploadPickTicketToolStripMenuItem"
        Me.UploadPickTicketToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.UploadPickTicketToolStripMenuItem.Text = "Upload Pick Ticket"
        '
        'ShipmentCompletion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdRemoteScan)
        Me.Controls.Add(Me.cmdUploadPickTicket)
        Me.Controls.Add(Me.tabAddSubLines)
        Me.Controls.Add(Me.cmdSalesOrderForm)
        Me.Controls.Add(Me.cmdPrintShippingLabel)
        Me.Controls.Add(Me.cmdPrintAll)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdBOL)
        Me.Controls.Add(Me.cmdTWCert)
        Me.Controls.Add(Me.cmdPackingList)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.dgvShipmentLines)
        Me.Controls.Add(Me.tabShipDetails)
        Me.Controls.Add(Me.gpxShipmentInfo)
        Me.Controls.Add(Me.cmdPrintShipmentConfirmation)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdCompleteShipment)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmdViewPickTicket)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ShipmentCompletion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Shipment Completion"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxShipmentInfo.ResumeLayout(False)
        Me.gpxShipmentInfo.PerformLayout()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PickListHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StateTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShipmentLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAddedLotNumbers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentLineLotNumbersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabShipDetails.ResumeLayout(False)
        Me.tabShippingDetails.ResumeLayout(False)
        Me.tabShippingDetails.PerformLayout()
        Me.tabShippingAddress.ResumeLayout(False)
        Me.tabShippingAddress.PerformLayout()
        CType(Me.CountryCodesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCustomerOrders.ResumeLayout(False)
        CType(Me.dgvOpenOrderLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderLineQueryNoQOHBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabComment.ResumeLayout(False)
        Me.tabComment.PerformLayout()
        CType(Me.dgvUPSData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UPSShippingDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSpecialLabel.ResumeLayout(False)
        Me.tabSpecialLabel.PerformLayout()
        Me.gpxShipmentLineLotNumbers.ResumeLayout(False)
        Me.gpxShipmentLineLotNumbers.PerformLayout()
        Me.tabAddSubLines.ResumeLayout(False)
        Me.tabAddLots.ResumeLayout(False)
        Me.tabAddSerial.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvSerialLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentLineSerialNumbersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdCompleteShipment As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPrintShipmentConfirmation As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpxShipmentInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSalesOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents dtpShipmentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtShippingCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtShippingCity As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtShippingWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtActualFreight As System.Windows.Forms.TextBox
    Friend WithEvents txtQuotedFreight As System.Windows.Forms.TextBox
    Friend WithEvents txtFreightQuoteNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtPRONumber As System.Windows.Forms.TextBox
    Friend WithEvents txtShippingZip As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtShippingAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtShippingAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboAdditionalShipTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboShippingState As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtNumberPallets As System.Windows.Forms.TextBox
    Friend WithEvents cboShipmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents dgvShipmentLines As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineTableTableAdapter
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents AdditionalShipToBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdditionalShipToTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
    Friend WithEvents StateTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StateTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.StateTableTableAdapter
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents cboLinePartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDeleteLotNumber As System.Windows.Forms.Button
    Friend WithEvents cmdAddLotNumber As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cboLotPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cboShipmentLineNumber As System.Windows.Forms.ComboBox
    Friend WithEvents dgvAddedLotNumbers As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentLineLotNumbersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentLineLotNumbersTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineLotNumbersTableAdapter
    Friend WithEvents tabShipDetails As System.Windows.Forms.TabControl
    Friend WithEvents tabShippingDetails As System.Windows.Forms.TabPage
    Friend WithEvents tabShippingAddress As System.Windows.Forms.TabPage
    Friend WithEvents gpxShipmentLineLotNumbers As System.Windows.Forms.GroupBox
    Friend WithEvents PickListHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PickListHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PickListHeaderTableTableAdapter
    Friend WithEvents txtLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtEstimatedWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents SaveShipmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteShipmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearShipmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BillOfLadingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TruweldCertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PackingListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPackingList As System.Windows.Forms.Button
    Friend WithEvents cmdTWCert As System.Windows.Forms.Button
    Friend WithEvents cmdBOL As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents txtShipToName As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdPrintAll As System.Windows.Forms.Button
    Friend WithEvents PrintAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintShipmentToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrintShippingLabel As System.Windows.Forms.Button
    Friend WithEvents cmdPrintLabel As System.Windows.Forms.Button
    Friend WithEvents cboPickTicketNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents PrintEmailShipmentConfirmationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSalesOrderForm As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtHeatQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerClass As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents tabCustomerOrders As System.Windows.Forms.TabPage
    Friend WithEvents dgvOpenOrderLines As System.Windows.Forms.DataGridView
    Friend WithEvents SalesOrderLineQueryNoQOHBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderLineQueryNoQOHTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderLineQueryNoQOHTableAdapter
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents OOSalesOrderColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OOSalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OOItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OODescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OOOpenSOQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OOPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OODivisionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OOSOStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OOCustomerIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OOLineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabComment As System.Windows.Forms.TabPage
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtHeaderComment As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtThirdPartyShipper As System.Windows.Forms.TextBox
    Friend WithEvents tabAddSubLines As System.Windows.Forms.TabControl
    Friend WithEvents tabAddLots As System.Windows.Forms.TabPage
    Friend WithEvents tabAddSerial As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtLineSerialNumber2 As System.Windows.Forms.TextBox
    Friend WithEvents cboShipmentLineNumber2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAddSerialNumber As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteSerialNumber As System.Windows.Forms.Button
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents dgvSerialLog As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentLineSerialNumbersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentLineSerialNumbersTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentLineSerialNumbersTableAdapter
    Friend WithEvents txtLinePartDescription2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLinePartNumber2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddMultiple As System.Windows.Forms.Button
    Friend WithEvents SLShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLShipmentLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLSerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLSerialLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLSerialCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SLSerialQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompleteLineColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityShippedColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineBoxesColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineWeightColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLDebitAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLCreditAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CertificationTypeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCompleteColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtShippingAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtShipEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents cboSTCountryName As System.Windows.Forms.ComboBox
    Friend WithEvents CountryCodesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CountryCodesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CountryCodesTableAdapter
    Friend WithEvents dgvUPSData As System.Windows.Forms.DataGridView
    Friend WithEvents UPSShippingDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UPSShippingDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.UPSShippingDataTableAdapter
    Friend WithEvents PickTicketNumberColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrackingNumberColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoidIndicatorColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdUploadPickTicket As System.Windows.Forms.Button
    Friend WithEvents ReUploadPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppendUploadedPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCustomerID As System.Windows.Forms.TextBox
    Friend WithEvents cmdPrintBoxLabel As System.Windows.Forms.Button
    Friend WithEvents llViewLotNumbers As System.Windows.Forms.LinkLabel
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents tabSpecialLabel As System.Windows.Forms.TabPage
    Friend WithEvents cmdPrintCustomLabel As System.Windows.Forms.Button
    Friend WithEvents txtSpecialLabelLine3 As System.Windows.Forms.TextBox
    Friend WithEvents txtSpecialLabelLine2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSpecialLabelLine1 As System.Windows.Forms.TextBox
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents llPickTicket As System.Windows.Forms.LinkLabel
    Friend WithEvents TestAutoEmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents crxtwCert011 As MOS09Program.CRXTWCert01
    Friend WithEvents ResetShipmentForCompletionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtDoublePallets As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPalletsOnFloor As System.Windows.Forms.TextBox
    Friend WithEvents SendFedExEmailForDailyShipmentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdViewPickTicket As System.Windows.Forms.Button
    Friend WithEvents ShipmentNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentLineNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotLineNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatQuantityColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PullTestNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents crxnocertDetailPage1 As MOS09Program.CRXNOCERTDetailPage
    Friend WithEvents cmdRemoteScan As System.Windows.Forms.Button
    Friend WithEvents UploadPickTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
